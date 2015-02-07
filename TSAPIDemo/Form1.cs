﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tsapi;

namespace TSAPIDemo
{
    public partial class mainForm : Form
    {
        private const int WM_USER = 0x0400;
        private const int WM_TSAPI_EVENT = WM_USER + 99;

        public mainForm()
        {
            InitializeComponent();
            try
            {
                this.serverID_textBox.Text = config.AppSettings.Settings["ServerID"].Value;
                this.login_textBox.Text = config.AppSettings.Settings["TSAPI login"].Value;
                this.password_textBox.Text = config.AppSettings.Settings["Password"].Value;
                this.appName_textBox.Text = config.AppSettings.Settings["ApplicationName"].Value;
                this.apiVer_textBox.Text = config.AppSettings.Settings["ApiVersion"].Value;
                this.configured = true;
            }
            catch
            {
                this.configured = false;
                this.mainTabs.SelectTab(configTab);
            }
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            if (!configured)
            {
                MessageBox.Show("Application is not configured");
                this.mainTabs.SelectTab(configTab);
                return;
            }
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5  || !streamCheckbox.Checked) { return; }
            Csta.DeviceID_t currentDevice = deviceTextBox.Text;
            Acs.InvokeID_t invokeId = new Acs.InvokeID_t();
            Acs.RetCode_t retCode = Csta.cstaSnapshotDeviceReq(this.acsHandle,
                                                 invokeId,
                                                 ref currentDevice,
                                                 privData);
            if (retCode._value < 0)
            {
                MessageBox.Show("cstaSnapshotDeviceReq error: " + retCode);
                return;
            }
            Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvents);
            if (retCode._value < 0)
            {
                MessageBox.Show("acsGetEventBlock error: " + retCode);
                return;
            }
            if (evtBuf.evt.eventHeader.eventClass.eventClass != Csta.CSTACONFIRMATION || evtBuf.evt.eventHeader.eventType.eventType != Csta.CSTA_SNAPSHOT_DEVICE_CONF)
            {
                if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_UNIVERSAL_FAILURE_CONF)
                {
                    MessageBox.Show("Snapshot device failed. Error: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
                }
                return;
            }
            int callCountForSnapshotDevice = evtBuf.evt.cstaConfirmation.snapshotDevice.snapshotData.count;
            Csta.ConnectionID_t tmpConn;
            this.snapShotDataTree.Nodes.Clear();
            for (int i = 0; i < callCountForSnapshotDevice; i++)
            {
                var snapDeviceInfoArray = (Csta.CSTASnapshotDeviceResponseInfo_t[])evtBuf.auxData["snapDeviceInfo"];
                tmpConn = snapDeviceInfoArray[i].callIdentifier;
                CallNode callNode = new CallNode();
                callNode.Text = GetUcid(tmpConn).ToString();
                this.snapShotDataTree.Nodes.Add(callNode);

                callNode.connection = tmpConn;
                this.snapShotDataTree.Nodes[i].Text += ". States: ";
                for (int j = 0; j < snapDeviceInfoArray[i].localCallState.count; j++)
                {
                    var snapDeviceStateArray = (Csta.LocalConnectionState_t[])evtBuf.auxData["snapDeviceState" + i];
                    this.snapShotDataTree.Nodes[i].Text += "#" + (j+1) + ": " + snapDeviceStateArray[j] + " ";
                }
                Csta.EventBuffer_t snapCallEvt = snapshotCall(ref tmpConn);
                this.snapShotDataTree.Nodes[i].Nodes.Clear();
                int callCountForSnapshotCall = snapCallEvt.evt.cstaConfirmation.snapshotCall.snapshotData.count;
                var snapCallInfoArray = (Csta.CSTASnapshotCallResponseInfo_t[])snapCallEvt.auxData["snapCallInfo"];
                for (int j = 0; j < callCountForSnapshotCall; j++)
                {
                    TreeNode t = new TreeNode(snapCallInfoArray[j].deviceOnCall.deviceID.ToString() + "; " + snapCallInfoArray[j].deviceOnCall.deviceIDType + "; " + snapCallInfoArray[j].deviceOnCall.deviceIDStatus);
                    this.snapShotDataTree.Nodes[i].Nodes.Add(t);
                }
                this.snapShotDataTree.Nodes[i].Expand();
            }

            if (callCountForSnapshotDevice < 1)
            {
                MessageBox.Show("No active calls");
            }
        }

        private void deviceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                goButton_Click(sender, e);
            }
        }

        private void EventReactionHandler(uint esrparam)
        {
            //MessageBox.Show("[acsSetESR Test] stream = " + esrparam);
            Debug.WriteLine("[acsSetESR Test] stream = " + esrparam);
        }

        private bool acsEnumServerNamesCallbackHandler(StringBuilder serverName, uint lParam)
        {
            Debug.WriteLine("[acsEnumServerNames Test] server = " + serverName );
            MessageBox.Show("Found server:\n" + serverName);
            if (serverName.ToString() != string.Empty) return true; else return false;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            if (this.configured)
            {
                openStream();
            }
            else
            {
                this.configTab.Select();
            }
        }

        private void openStream()
        {
            this.acsHandle = new Acs.ACSHandle_t();
            var invokeIdType = Acs.InvokeIDType_t.LIB_GEN_ID;
            var invokeId = new Acs.InvokeID_t();
            var streamType = Acs.StreamType_t.ST_CSTA;
            Acs.ServerID_t serverId = config.AppSettings.Settings["ServerID"].Value;
            Acs.LoginID_t loginId = config.AppSettings.Settings["TSAPI login"].Value;
            Acs.Passwd_t passwd = config.AppSettings.Settings["Password"].Value;
            Acs.AppName_t appName = config.AppSettings.Settings["ApplicationName"].Value;
            Acs.Level_t acsLevelReq = Acs.Level_t.ACS_LEVEL1;
            Acs.Version_t apiVer = config.AppSettings.Settings["ApiVersion"].Value;
            ushort sendQSize = 0;
            ushort sendExtraBufs = 0;
            ushort recvQSize = 0;
            ushort recvExtraBufs = 0;
            var  currentDevice = deviceTextBox.Text;
            // Get supportedVersion string
            string requestedVersion = "3-7";
            System.Text.StringBuilder supportedVersion = new System.Text.StringBuilder();
            Acs.RetCode_t attrc = Att.attMakeVersionString(requestedVersion, supportedVersion);
            // Set PrivateData request
            this.privData = new Acs.PrivateData_t();
            this.privData.vendor = "VERSION";
            this.privData.data = new byte[1024];
            this.privData.data[0] = Acs.PRIVATE_DATA_ENCODING;
            for (int i = 0; i < supportedVersion.Length; i++)
            {
                privData.data[i + 1] = (byte)supportedVersion[i];
            }
            privData.length = Att.ATT_MAX_PRIVATE_DATA;
            Acs.RetCode_t retCode = Acs.acsOpenStream(out this.acsHandle,
                                                          invokeIdType,
                                                          invokeId,
                                                          streamType,
                                                          ref serverId,
                                                          ref loginId,
                                                          ref passwd,
                                                          ref appName,
                                                          acsLevelReq,
                                                          ref apiVer,
                                                          sendQSize,
                                                          sendExtraBufs,
                                                          recvQSize,
                                                          recvExtraBufs,
                                                          privData);
            Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents = 0;

            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                     evtBuf,
                                     ref eventBufSize,
                                     privData,
                                     out numEvents);
            if (evtBuf.evt.eventHeader.eventClass.eventClass != 2 || evtBuf.evt.eventHeader.eventType.eventType != 2)
            {
                MessageBox.Show("Could not open stream. ErrorCode = " + evtBuf.evt.acsConfirmation.failureEvent.error);
                streamCheckbox.Checked = false;
                this.goButton.Enabled = false;
                return;
            }
            else
            {
                streamCheckbox.Text = "Connected to AES server. Handle = " + this.acsHandle;
                streamCheckbox.Checked = true;
                this.goButton.Enabled = true;
            }
            Acs.EsrDelegate eventReaction = new Acs.EsrDelegate(EventReactionHandler);
            Acs.acsSetESR(this.acsHandle, eventReaction, this.acsHandle._value, false);
            Acs.acsEventNotify(this.acsHandle, this.Handle, WM_TSAPI_EVENT, false);
        }


        public Att.ATTUCID_t GetUcid(Csta.ConnectionID_t conn)
        {
            Acs.InvokeID_t invokeId = new Acs.InvokeID_t();
            Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents = 0;
            Acs.RetCode_t retCode = Att.attQueryUCID(this.privData, ref conn);
            retCode = Csta.cstaEscapeService(acsHandle, invokeId, privData);
            privData.length = Att.ATT_MAX_PRIVATE_DATA;
            retCode = Acs.acsGetEventBlock(acsHandle,
                                         evtBuf,
                                         ref eventBufSize,
                                         privData,
                                         out numEvents);

            Att.ATTEvent_t attevt;
            retCode = Att.attPrivateData(privData, out attevt);
            return attevt.queryUCID.ucid;
        }



        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Acs.acsAbortStream(this.acsHandle, null);
            WriteConfig();
        }

        private void WriteConfig()
        {
            try
            {
               config.Save(ConfigurationSaveMode.Modified);
            }
            catch { }
        }


        private void serverID_textBox_Leave(object sender, EventArgs e)
        {
            if (serverID_textBox.Text == string.Empty) this.configured = false;
            if (config.AppSettings.Settings["ServerID"] == null)
            {
                config.AppSettings.Settings.Add("ServerID", serverID_textBox.Text);
            }
            else
            {
                config.AppSettings.Settings["ServerID"].Value = serverID_textBox.Text;
            }
        }

        private void login_textBox_Leave(object sender, EventArgs e)
        {
            if (login_textBox.Text == string.Empty) this.configured = false;
            if (config.AppSettings.Settings["TSAPI login"] == null)
            {
                config.AppSettings.Settings.Add("TSAPI login", login_textBox.Text);
            }
            else
            {
                config.AppSettings.Settings["TSAPI login"].Value = login_textBox.Text;
            }
        }

        private void password_textBox_Leave(object sender, EventArgs e)
        {
            if (config.AppSettings.Settings["Password"] == null)
            {
                config.AppSettings.Settings.Add("Password", password_textBox.Text);
            }
            else
            {
                config.AppSettings.Settings["Password"].Value = password_textBox.Text;
            }
        }

        private void appName_textBox_Leave(object sender, EventArgs e)
        {
            if (appName_textBox.Text == string.Empty) this.configured = false;
            if (config.AppSettings.Settings["ApplicationName"] == null)
            {
                config.AppSettings.Settings.Add("ApplicationName", appName_textBox.Text);
            }
            else
            {
                config.AppSettings.Settings["ApplicationName"].Value = appName_textBox.Text;
            }
        }

        private void apiVer_textBox_Leave(object sender, EventArgs e)
        {
            if (apiVer_textBox.Text == string.Empty) this.configured = false;
            if (config.AppSettings.Settings["ApiVersion"] == null)
            {
                config.AppSettings.Settings.Add("ApiVersion", apiVer_textBox.Text);
            }
            else
            {
                config.AppSettings.Settings["ApiVersion"].Value = apiVer_textBox.Text;
            }
        }

        private void connectionCheckbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (!this.configured)
            {
                this.streamCheckbox.Checked = false;
                MessageBox.Show("Application is not configured");
                this.mainTabs.SelectTab(configTab);
                return;
            }
            if (!this.streamCheckbox.Checked)
            {
                closeStream(this.acsHandle);
                streamCheckbox.Text = "Disconnected from AES server";
                this.goButton.Enabled = false;
            }
            else
            {
                openStream();
            }
        }


        private Csta.EventBuffer_t snapshotCall(ref Csta.ConnectionID_t cId)
        {
            Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
            Acs.InvokeID_t invokeId = new Acs.InvokeID_t();
            Acs.RetCode_t retCode = Csta.cstaSnapshotCallReq(this.acsHandle,
                                                 invokeId,
                                                 ref cId,
                                                 this.privData);
            if (retCode._value < 0)
            {
                MessageBox.Show("cstaSnapshotCallReq error: " + retCode);
                return null;
            }
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvents);
            if (retCode._value < 0)
            {
                MessageBox.Show("acsGetEventBlock error: " + retCode);
                return null;
            }
            if (evtBuf.evt.eventHeader.eventClass.eventClass != Csta.CSTACONFIRMATION ||
                evtBuf.evt.eventHeader.eventType.eventType != Csta.CSTA_SNAPSHOT_CALL_CONF)
            {
                if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION
                    && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_UNIVERSAL_FAILURE_CONF)
                {
                    MessageBox.Show("Snapshot call failed. Error: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
                }
            }
            return evtBuf;
        }

        private Csta.EventBuffer_t clearCall(ref Csta.ConnectionID_t cId)
        {
            Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
            Acs.InvokeID_t invokeId = new Acs.InvokeID_t();
            Acs.RetCode_t retCode = Csta.cstaClearCall(this.acsHandle,
                                                 invokeId,
                                                 ref cId,
                                                 this.privData);
            if (retCode._value < 0)
            {
                MessageBox.Show("cstaClearCall error: " + retCode);
                return null;
            }
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvents);
            if (retCode._value < 0)
            {
                MessageBox.Show("acsGetEventBlock error: " + retCode);
                return null;
            }
            if (evtBuf.evt.eventHeader.eventClass.eventClass != Csta.CSTACONFIRMATION ||
                evtBuf.evt.eventHeader.eventType.eventType != Csta.CSTA_CLEAR_CALL_CONF)
            {
                if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION
                    && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_UNIVERSAL_FAILURE_CONF)
                {
                    MessageBox.Show("Clear call failed. Error: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
                }
            }
            return evtBuf;
        }

        private Csta.EventBuffer_t closeStream(Acs.ACSHandle_t acsHandle)
        {
            Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
            Acs.RetCode_t retCode = Acs.acsCloseStream(acsHandle, new Acs.InvokeID_t(), null);
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          null,
                                          out numEvents);
            if (retCode._value < 0)
            {
                MessageBox.Show("acsGetEventBlock error: " + retCode);
                return null;
            }
            if (evtBuf.evt.eventHeader.eventClass.eventClass != Acs.ACSCONFIRMATION ||
                evtBuf.evt.eventHeader.eventType.eventType != Acs.ACS_CLOSE_STREAM_CONF)
            {
                if (evtBuf.evt.eventHeader.eventClass.eventClass == Acs.ACSCONFIRMATION
                    && evtBuf.evt.eventHeader.eventType.eventType == Acs.ACS_UNIVERSAL_FAILURE_CONF)
                {
                    MessageBox.Show("Clear call failed. Error: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
                }
            }
            return evtBuf;
        }

        private Csta.EventBuffer_t getDeviceList(Acs.ACSHandle_t acsHandle)
        {
            Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
            Acs.PrivateData_t privData = new Acs.PrivateData_t();
            int idx = -1;
            Acs.RetCode_t retCode = Csta.cstaGetDeviceList(acsHandle, new Acs.InvokeID_t(), idx, Csta.CSTALevel_t.CSTA_HOME_WORK_TOP);
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            ushort eventBufSize = Csta.CSTA_MAX_HEAP * 2;
            ushort numEvents;
            Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvents);

            idx = evtBuf.evt.cstaConfirmation.getDeviceList.index;
            retCode = Csta.cstaGetDeviceList(acsHandle, new Acs.InvokeID_t(), idx, Csta.CSTALevel_t.CSTA_HOME_WORK_TOP);

            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            eventBufSize = Csta.CSTA_MAX_HEAP;
            Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvents);
            return evtBuf;
        }

        private void mainTabs_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage != this.configTab)
            {
                configured = false;
                if (serverID_textBox.Text != string.Empty &&
                    login_textBox.Text != string.Empty &&
                    password_textBox.Text != string.Empty &&
                    appName_textBox.Text != string.Empty &&
                    apiVer_textBox.Text != string.Empty)
                {
                    configured = true;
                }
                WriteConfig();
            }
        }

        private void snapShotDataTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Right) { return; }
            snapShotDataTree.SelectedNode = e.Node;
            CallNode tmpNode = (CallNode)e.Node;
            Csta.ConnectionID_t selectedConnId = tmpNode.connection;
            ContextMenuStrip snapShotDataTreeContextMenu = new ContextMenuStrip();
            ToolStripItem snapShotCallContextMenuItem = snapShotDataTreeContextMenu.Items.Add("cstaClearCall");
            snapShotDataTreeContextMenu.Click += (s, ev) => {
                Csta.EventBuffer_t evtbuf = clearCall(ref selectedConnId);
                snapShotDataTree.Nodes.Remove(tmpNode);
            };
            
            snapShotDataTreeContextMenu.Show(Cursor.Position);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Csta.EventBuffer_t evtbuf =  getDeviceList(this.acsHandle);
            //MessageBox.Show("Number of devices = " + evtbuf.evt.cstaConfirmation.getDeviceList.devList.count);
        }

        //[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_TSAPI_EVENT:
                {
                    short[] wmEventData = Aux.SplitPtr(m.LParam);
                    //MessageBox.Show(string.Format("TSAPI lib has an event for us! AcsHandle = {0}, EventClass = {1}, EventType = {2}", m.WParam, wmEventData[0], wmEventData[1]));
                    Debug.WriteLine(string.Format("[acsEventNotify Test] Got event: AcsHandle = {0}, EventClass = {1}, EventType = {2}", m.WParam, wmEventData[0], wmEventData[1]));
                    break;
                }
            }
            base.WndProc(ref m);
        }

        private void flushEventQueueButton_Click(object sender, EventArgs e)
        {
            Acs.RetCode_t retCode =  Acs.acsFlushEventQueue(this.acsHandle);
            if (retCode._value == 0)
            {
                MessageBox.Show("Events flushed successfully!");
            }
            else if (retCode._value > 0)
            {
                MessageBox.Show("acsFlushEventQueue result: " + retCode._value);
            }
            else
            {
                MessageBox.Show("acsFlushEventQueue failed. Error: " + retCode._value);
            }
        }

        private void enumServerNamesButton_Click(object sender, EventArgs e)
        {

            Acs.EnumServerNamesCB callback = new Acs.EnumServerNamesCB(acsEnumServerNamesCallbackHandler);
            Acs.acsEnumServerNames(Acs.StreamType_t.ST_CSTA, callback, 0);
        }
    }

    class CallNode : TreeNode
    {
        public Csta.ConnectionID_t connection;
    }
}
