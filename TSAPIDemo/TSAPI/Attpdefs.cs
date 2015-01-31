﻿using System;
using System.Runtime.InteropServices;

namespace Tsapi
{
    using ATTPrivateData_t = Acs.PrivateData_t;
    public partial class Att
    {

        #region ATT event types

        public const int ATTV5_CLEAR_CONNECTION = 1;
        public const int FIRST_PRIV_TYPE = ATTV5_CLEAR_CONNECTION;
        public const int ATTV5_CONSULTATION_CALL = 2;
        public const int ATTV5_MAKE_CALL = 3;
        public const int ATTV5_DIRECT_AGENT_CALL = 4;
        public const int ATTV5_MAKE_PREDICTIVE_CALL = 5;
        public const int ATTV5_SUPERVISOR_ASSIST_CALL = 6;
        public const int ATTV5_RECONNECT_CALL = 7;
        public const int ATTV4_SENDDTMF_TONE = 8;
        public const int ATT_SENDDTMF_TONE_CONF = 9;
        public const int ATTV4_SET_AGENT_STATE = 10;
        public const int ATT_QUERY_ACD_SPLIT = 11;
        public const int ATT_QUERY_ACD_SPLIT_CONF = 12;
        public const int ATT_QUERY_AGENT_LOGIN = 13;
        public const int ATT_QUERY_AGENT_LOGIN_CONF = 14;
        public const int ATT_QUERY_AGENT_LOGIN_RESP = 15;
        public const int ATT_QUERY_AGENT_STATE = 16;
        public const int ATTV4_QUERY_AGENT_STATE_CONF = 17;
        public const int ATT_QUERY_CALL_CLASSIFIER = 18;
        public const int ATT_QUERY_CALL_CLASSIFIER_CONF = 19;
        public const int ATTV4_QUERY_DEVICE_INFO_CONF = 20;
        public const int ATT_QUERY_MWI_CONF = 21;
        public const int ATT_QUERY_STATION_STATUS = 22;
        public const int ATT_QUERY_STATION_STATUS_CONF = 23;
        public const int ATT_QUERY_TOD = 24;
        public const int ATT_QUERY_TOD_CONF = 25;
        public const int ATT_QUERY_TG = 26;
        public const int ATT_QUERY_TG_CONF = 27;
        public const int ATTV4_SNAPSHOT_DEVICE_CONF = 28;
        public const int ATTV4_MONITOR_FILTER = 29;
        public const int ATTV4_MONITOR_CONF = 30;
        public const int ATT_MONITOR_STOP_ON_CALL = 31;
        public const int ATT_MONITOR_STOP_ON_CALL_CONF = 32;
        public const int ATTV4_MONITOR_CALL_CONF = 33;
        public const int ATT_CALL_CLEARED = 34;
        public const int ATTV3_CONFERENCED = 35;
        public const int ATTV5_CONNECTION_CLEARED = 36;
        public const int ATTV3_DELIVERED = 37;
        public const int ATT_ENTERED_DIGITS = 38;
        public const int ATTV3_ESTABLISHED = 39;
        public const int ATTV4_NETWORK_REACHED = 40;
        public const int ATTV3_TRANSFERRED = 41;
        public const int ATTV4_ROUTE_REQUEST = 42;
        public const int ATTV5_ROUTE_SELECT = 43;
        public const int ATT_ROUTE_USED = 44;
        public const int ATT_SYS_STAT = 45;
        public const int ATTV3_LINK_STATUS = 46;
        public const int ATTV5_ORIGINATED = 47;
        public const int ATT_LOGGED_ON = 48;
        public const int ATT_QUERY_DEVICE_NAME = 49;
        public const int ATTV4_QUERY_DEVICE_NAME_CONF = 50;
        public const int ATT_QUERY_AGENT_MEASUREMENTS = 51;
        public const int ATT_QUERY_AGENT_MEASUREMENTS_CONF = 52;
        public const int ATT_QUERY_SPLIT_SKILL_MEASUREMENTS = 53;
        public const int ATT_QUERY_SPLIT_SKILL_MEASUREMENTS_CONF = 54;
        public const int ATT_QUERY_TRUNK_GROUP_MEASUREMENTS = 55;
        public const int ATT_QUERY_TRUNK_GROUP_MEASUREMENTS_CONF = 56;
        public const int ATT_QUERY_VDN_MEASUREMENTS = 57;
        public const int ATT_QUERY_VDN_MEASUREMENTS_CONF = 58;
        public const int ATTV4_CONFERENCED = 59;
        public const int ATTV4_DELIVERED = 60;
        public const int ATTV4_ESTABLISHED = 61;
        public const int ATTV4_TRANSFERRED = 62;
        public const int ATTV4_LINK_STATUS = 63;
        public const int ATTV4_GETAPI_CAPS_CONF = 64;
        public const int ATT_SINGLE_STEP_CONFERENCE_CALL = 65;
        public const int ATT_SINGLE_STEP_CONFERENCE_CALL_CONF = 66;
        public const int ATT_SELECTIVE_LISTENING_HOLD = 67;
        public const int ATT_SELECTIVE_LISTENING_HOLD_CONF = 68;
        public const int ATT_SELECTIVE_LISTENING_RETRIEVE = 69;
        public const int ATT_SELECTIVE_LISTENING_RETRIEVE_CONF = 70;
        public const int ATT_SENDDTMF_TONE = 71;
        public const int ATT_SNAPSHOT_DEVICE_CONF = 72;
        public const int ATT_LINK_STATUS = 73;
        public const int ATT_SET_BILL_RATE = 74;
        public const int ATT_SET_BILL_RATE_CONF = 75;
        public const int ATT_QUERY_UCID = 76;
        public const int ATT_QUERY_UCID_CONF = 77;
        public const int ATTV5_CONFERENCED = 78;
        public const int ATT_LOGGED_OFF = 79;
        public const int ATTV5_DELIVERED = 80;
        public const int ATTV5_ESTABLISHED = 81;
        public const int ATTV5_TRANSFERRED = 82;
        public const int ATTV5_ROUTE_REQUEST = 83;
        public const int ATT_CONSULTATION_CALL_CONF = 84;
        public const int ATT_MAKE_CALL_CONF = 85;
        public const int ATT_MAKE_PREDICTIVE_CALL_CONF = 86;
        public const int ATTV5_SET_AGENT_STATE = 87;
        public const int ATTV5_QUERY_AGENT_STATE_CONF = 88;
        public const int ATT_QUERY_DEVICE_NAME_CONF = 89;
        public const int ATT_CONFERENCE_CALL_CONF = 90;
        public const int ATT_TRANSFER_CALL_CONF = 91;
        public const int ATT_MONITOR_FILTER = 92;
        public const int ATT_MONITOR_CONF = 93;
        public const int ATT_MONITOR_CALL_CONF = 94;
        public const int ATT_SERVICE_INITIATED = 95;
        public const int ATT_CHARGE_ADVICE = 96;
        public const int ATT_GETAPI_CAPS_CONF = 97;
        public const int ATT_QUERY_DEVICE_INFO_CONF = 98;
        public const int ATT_SET_ADVICE_OF_CHARGE = 99;
        public const int ATT_SET_ADVICE_OF_CHARGE_CONF = 100;
        public const int ATT_NETWORK_REACHED = 101;
        public const int ATT_SET_AGENT_STATE = 102;
        public const int ATT_SET_AGENT_STATE_CONF = 103;
        public const int ATT_QUERY_AGENT_STATE_CONF = 104;
        public const int ATT_ROUTE_REQUEST = 105;
        public const int ATT_TRANSFERRED = 106;
        public const int ATT_CONFERENCED = 107;
        public const int ATT_CLEAR_CONNECTION = 108;
        public const int ATT_CONSULTATION_CALL = 109;
        public const int ATT_MAKE_CALL = 110;
        public const int ATT_DIRECT_AGENT_CALL = 111;
        public const int ATT_MAKE_PREDICTIVE_CALL = 112;
        public const int ATT_SUPERVISOR_ASSIST_CALL = 113;
        public const int ATT_RECONNECT_CALL = 114;
        public const int ATT_CONNECTION_CLEARED = 115;
        public const int ATT_ROUTE_SELECT = 116;
        public const int ATT_DELIVERED = 117;
        public const int ATT_ESTABLISHED = 118;
        public const int ATT_ORIGINATED = 119;

        #endregion

        public const int LAST_PRIV_TYPE = ATT_ORIGINATED;  // Please keep this up to data when private types are added
        public const int EXPOSED_PRIV_TYPE = LAST_PRIV_TYPE;

        public enum ATTUUIProtocolType_t
        {
            UUI_NONE = -1,
            UUI_USER_SPECIFIC = 0,
            UUI_IA5_ASCII = 4
        }

        public struct ATTV5UserToUserInfo_t
        {
            ATTUUIProtocolType_t type;
            public struct data
            {
                short length;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
                byte[] value;
            };
        }

        public enum ATTInterflow_t
        {
            LAI_NO_INTERFLOW = -1,
            LAI_ALL_INTERFLOW = 0,
            LAI_THRESHOLD_INTERFLOW = 1,
            LAI_VECTORING_INTERFLOW = 2
        }

        public enum ATTPriority_t
        {
            LAI_NOT_IN_QUEUE = 0,
            LAI_LOW = 1,
            LAI_MEDIUM = 2,
            LAI_HIGH = 3,
            LAI_TOP = 4
        }

        public struct ATTV4LookaheadInfo_t
        {
            ATTInterflow_t type;
            ATTPriority_t priority;
            short hours;
            short minutes;
            short seconds;
            Csta.DeviceID_t sourceVDN;
        }

        public enum ATTUserEnteredCodeType_t
        {
            UE_NONE = -1,
            UE_ANY = 0,
            UE_LOGIN_DIGITS = 2,
            UE_CALL_PROMPTER = 5,
            UE_DATA_BASE_PROVIDED = 17,
            UE_TONE_DETECTOR = 32
        }

        public enum ATTUserEnteredCodeIndicator_t
        {
            UE_COLLECT = 0,
            UE_ENTERED = 1
        }

        public struct ATTUserEnteredCode_t
        {
            ATTUserEnteredCodeType_t type;
            ATTUserEnteredCodeIndicator_t indicator;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 25)]
            byte[] data;
            Csta.DeviceID_t collectVDN;
        };

        public struct ATTV4ConnIDList_t
        {
            short count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            Csta.ConnectionID_t[] party;
        };

        public enum ATTProgressLocation_t
        {
            PL_NONE = -1,
            PL_USER = 0,
            PL_PUB_LOCAL = 1,
            PL_PUB_REMOTE = 4,
            PL_PRIV_REMOTE = 5
        };

        public enum ATTProgressDescription_t
        {
            PD_NONE = -1,
            PD_CALL_OFF_ISDN = 1,
            PD_DEST_NOT_ISDN = 2,
            PD_ORIG_NOT_ISDN = 3,
            PD_CALL_ON_ISDN = 4,
            PD_INBAND = 8
        };

        public enum ATTWorkMode_t
        {
            WM_NONE = -1,
            WM_AUX_WORK = 1,
            WM_AFTCAL_WK = 2,
            WM_AUTO_IN = 3,
            WM_MANUAL_IN = 4
        };

        public enum ATTTalkState_t
        {
            TS_ON_CALL = 0,
            TS_IDLE = 1
        };

        public enum ATTExtensionClass_t
        {
            EC_VDN = 0,
            EC_ACD_SPLIT = 1,
            EC_ANNOUNCEMENT = 2,
            EC_DATA = 4,
            EC_ANALOG = 5,
            EC_PROPRIETARY = 6,
            EC_BRI = 7,
            EC_CTI = 8,
            EC_LOGICAL_AGENT = 9,
            EC_OTHER = 10
        };

        public enum ATTAnswerTreat_t
        {
            AT_NO_TREATMENT = 0,
            AT_NONE = 1,
            AT_DROP = 2,
            AT_CONNECT = 3
        };

        public struct ATTMwiApplication_t
        {
            byte _value;
        }
        public const byte AT_MCS = 0x01;
        public const byte AT_VOICE = 0x02;
        public const byte AT_PROPMGT = 0x04;
        public const byte AT_LWC = 0x08;
        public const byte AT_CTI = 0x10;

        public struct ATTV4PrivateFilter_t
        {
            byte _value;
        }

        public const byte ATT_V4_ENTERED_DIGITS_FILTER = 0x80;

        public struct ATTV4SnapshotCall_t
        {
            short count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            Csta.CSTASnapshotCallResponseInfo_t[] info;
        };

        public enum ATTLocalCallState_t
        {
            ATT_CS_INITIATED = 1,
            ATT_CS_ALERTING = 2,
            ATT_CS_CONNECTED = 3,
            ATT_CS_HELD = 4,
            ATT_CS_BRIDGED = 5,
            ATT_CS_OTHER = 6
        };

        public struct ATTSnapshotDevice_t
        {
            Csta.ConnectionID_t call;
            ATTLocalCallState_t state;
        };

        public enum ATTCollectCodeType_t
        {
            UC_NONE = 0,
            UC_TONE_DETECTOR = 32
        };

        public enum ATTProvidedCodeType_t
        {
            UP_NONE = 0,
            UP_DATA_BASE_PROVIDED = 17
        };

        public struct ATTUserProvidedCode_t
        {
            ATTProvidedCodeType_t type;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 25)]
            byte[] data;
        };

        public enum ATTSpecificEvent_t
        {
            SE_ANSWER = 11,
            SE_DISCONNECT = 4
        };

        public struct ATTUserCollectCode_t
        {
            ATTCollectCodeType_t type;
            short digitsToBeCollected;
            short timeout;
            Csta.ConnectionID_t collectParty;
            ATTSpecificEvent_t specificEvent;
        };

        public enum ATTDropResource_t
        {
            DR_NONE = -1,
            DR_CALL_CLASSIFIER = 0,
            DR_TONE_GENERATOR = 1
        };

        public struct ATTV5ClearConnection_t
        {
            ATTDropResource_t dropResource;
            ATTV5UserToUserInfo_t userInfo;
        };

        public struct ATTV5ConsultationCall_t
        {
            Csta.DeviceID_t destRoute;
            Boolean priorityCalling;
            ATTV5UserToUserInfo_t userInfo;
        };

        public struct ATTV5MakeCall_t
        {
            Csta.DeviceID_t destRoute;
            Boolean priorityCalling;
            ATTV5UserToUserInfo_t userInfo;
        };

        public struct ATTV5DirectAgentCall_t
        {
            Csta.DeviceID_t split;
            Boolean priorityCalling;
            ATTV5UserToUserInfo_t userInfo;
        };

        public struct ATTV5MakePredictiveCall_t
        {
            Boolean priorityCalling;
            short maxRings;
            ATTAnswerTreat_t answerTreat;
            Csta.DeviceID_t destRoute;
            ATTV5UserToUserInfo_t userInfo;
        };

        public struct ATTV5SupervisorAssistCall_t
        {
            Csta.DeviceID_t split;
            ATTV5UserToUserInfo_t userInfo;
        };

        public struct ATTV5ReconnectCall_t
        {
            ATTDropResource_t dropResource;
            ATTV5UserToUserInfo_t userInfo;
        };

        public struct ATTV4SendDTMFTone_t
        {
            Csta.ConnectionID_t sender;
            ATTV4ConnIDList_t receivers;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
            byte[] tones;
            short toneDuration;
            short pauseDuration;
        };

        public struct ATTSendDTMFToneConfEvent_t
        {
            Acs.Nulltype dummy;
        };

        public struct ATTV4SetAgentState_t
        {
            ATTWorkMode_t workMode;
        };

        public struct ATTQueryAcdSplit_t
        {
            Csta.DeviceID_t device;
        };

        public struct ATTQueryAcdSplitConfEvent_t
        {
            short availableAgents;
            short callsInQueue;
            short agentsLoggedIn;
        };

        public struct ATTQueryAgentLogin_t
        {
            Csta.DeviceID_t device;
        };

        public struct ATTPrivEventCrossRefID_t
        {
            int _value;
        };

        public struct ATTQueryAgentLoginConfEvent_t
        {
            ATTPrivEventCrossRefID_t privEventCrossRefID;
        };

        public struct ATTQueryAgentLoginResp_t
        {
            ATTPrivEventCrossRefID_t privEventCrossRefID;
            private struct list
            {
                short count;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
                Csta.DeviceID_t[] device;
            }
        };

        public struct ATTQueryAgentState_t
        {
            Csta.DeviceID_t split;
        };

        public struct ATTV4QueryAgentStateConfEvent_t
        {
            ATTWorkMode_t workMode;
            ATTTalkState_t talkState;
        };

        public struct ATTQueryCallClassifier_t
        {
            Acs.Nulltype dummy;
        };

        public struct ATTQueryCallClassifierConfEvent_t
        {
            short numAvailPorts;
            short numInUsePorts;
        };

        public struct ATTV4QueryDeviceInfoConfEvent_t
        {
            ATTExtensionClass_t extensionClass;
        };

        public struct ATTQueryMwiConfEvent_t
        {
            ATTMwiApplication_t applicationType;
        };

        public struct ATTQueryStationStatus_t
        {
            Csta.DeviceID_t device;
        };

        public struct ATTQueryStationStatusConfEvent_t
        {
            Boolean stationStatus;
        };

        public struct ATTQueryTod_t
        {
            Acs.Nulltype dummy;
        };

        public struct ATTQueryTodConfEvent_t
        {
            short year;
            short month;
            short day;
            short hour;
            short minute;
            short second;
        };

        public struct ATTQueryTg_t
        {
            Csta.DeviceID_t device;
        };

        public struct ATTQueryTgConfEvent_t
        {
            short idleTrunks;
            short usedTrunks;
        };

        public struct ATTV4SnapshotDeviceConfEvent_t
        {
            short count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            ATTSnapshotDevice_t[] snapshotDevice;
        };

        public struct ATTV4MonitorFilter_t
        {
            ATTV4PrivateFilter_t privateFilter;
        };

        public struct ATTV4MonitorConfEvent_t
        {
            ATTV4PrivateFilter_t usedFilter;
        };

        public struct ATTMonitorStopOnCall_t
        {
            Csta.CSTAMonitorCrossRefID_t monitorCrossRefID;
            Csta.ConnectionID_t call;
        };

        public struct ATTMonitorStopOnCallConfEvent_t
        {
            Acs.Nulltype dummy;
        };

        public struct ATTV4MonitorCallConfEvent_t
        {
            ATTV4PrivateFilter_t usedFilter;
            ATTV4SnapshotCall_t snapshotCall;
        };

        public enum ATTReasonCode_t
        {
            AR_NONE = 0,
            AR_ANSWER_NORMAL = 1,
            AR_ANSWER_TIMED = 2,
            AR_ANSWER_VOICE_ENERGY = 3,
            AR_ANSWER_MACHINE_DETECTED = 4,
            AR_SIT_REORDER = 5,
            AR_SIT_NO_CIRCUIT = 6,
            AR_SIT_INTERCEPT = 7,
            AR_SIT_VACANT_CODE = 8,
            AR_SIT_INEFFECTIVE_OTHER = 9,
            AR_SIT_UNKNOWN = 10,
            AR_IN_QUEUE = 11,
            AR_SERVICE_OBSERVER = 12
        };

        public enum ATTReasonForCallInfo_t
        {
            OR_NONE = 0,
            OR_CONSULTATION = 1,
            OR_CONFERENCED = 2,
            OR_TRANSFERRED = 3,
            OR_NEW_CALL = 4
        };

        public struct ATTV4OriginalCallInfo_t
        {
            ATTReasonForCallInfo_t reason;
            Csta.CallingDeviceID_t callingDevice;
            Csta.CalledDeviceID_t calledDevice;
            Csta.DeviceID_t trunk;
            Csta.DeviceID_t trunkMember;
            ATTV4LookaheadInfo_t lookaheadInfo;
            ATTUserEnteredCode_t userEnteredCode;
            ATTV5UserToUserInfo_t userInfo;
        };

        public struct ATTCallClearedEvent_t
        {
            ATTReasonCode_t reason;
        };

        public struct ATTV3ConferencedEvent_t
        {
            ATTV4OriginalCallInfo_t originalCallInfo;
        };

        public struct ATTV5ConnectionClearedEvent_t
        {
            ATTV5UserToUserInfo_t userInfo;
        };

        public enum ATTDeliveredType_t
        {
            DELIVERED_TO_ACD = 1,
            DELIVERED_TO_STATION = 2,
            DELIVERED_OTHER = 3
        };

        public struct ATTV3DeliveredEvent_t
        {
            ATTDeliveredType_t deliveredType;
            Csta.DeviceID_t trunk;
            Csta.DeviceID_t trunkMember;
            Csta.DeviceID_t split;
            ATTV4LookaheadInfo_t lookaheadInfo;
            ATTUserEnteredCode_t userEnteredCode;
            ATTV5UserToUserInfo_t userInfo;
            ATTReasonCode_t reason;
            ATTV4OriginalCallInfo_t originalCallInfo;
        };

        public struct ATTEnteredDigitsEvent_t
        {
            Csta.ConnectionID_t connection;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 25)]
            string digits;
            Csta.LocalConnectionState_t localConnectionInfo;
            Csta.CSTAEventCause_t cause;
        };

        public struct ATTV3EstablishedEvent_t
        {
            Csta.DeviceID_t trunk;
            Csta.DeviceID_t trunkMember;
            Csta.DeviceID_t split;
            ATTV4LookaheadInfo_t lookaheadInfo;
            ATTUserEnteredCode_t userEnteredCode;
            ATTV5UserToUserInfo_t userInfo;
            ATTReasonCode_t reason;
            ATTV4OriginalCallInfo_t originalCallInfo;
        };

        public struct ATTV4NetworkReachedEvent_t
        {
            ATTProgressLocation_t progressLocation;
            ATTProgressDescription_t progressDescription;
        };

        public struct ATTV3TransferredEvent_t
        {
            ATTV4OriginalCallInfo_t originalCallInfo;
        };

        public struct ATTV4RouteRequestEvent_t
        {
            Csta.DeviceID_t trunk;
            ATTV4LookaheadInfo_t lookaheadInfo;
            ATTUserEnteredCode_t userEnteredCode;
            ATTV5UserToUserInfo_t userInfo;
        };

        public struct ATTV5RouteSelect_t
        {
            Csta.DeviceID_t callingDevice;
            Csta.DeviceID_t directAgentCallSplit;
            Boolean priorityCalling;
            Csta.DeviceID_t destRoute;
            ATTUserCollectCode_t collectCode;
            ATTUserProvidedCode_t userProvidedCode;
            ATTV5UserToUserInfo_t userInfo;
        };

        public struct ATTRouteUsedEvent_t
        {
            Csta.DeviceID_t destRoute;
        };

        public struct ATTSysStat_t
        {
            Boolean linkStatusReq;
        };

        public enum ATTLinkState_t
        {
            LS_LINK_UNAVAIL = 0,
            LS_LINK_UP = 1,
            LS_LINK_DOWN = 2
        };

        public struct ATTLinkStatus_t
        {
            short linkID;
            ATTLinkState_t linkState;
        };

        public struct ATTV3LinkStatusEvent_t
        {
            short count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            ATTLinkStatus_t[] linkStatus;
        };

        public struct ATTV5OriginatedEvent_t
        {
            Csta.DeviceID_t logicalAgent;
            ATTV5UserToUserInfo_t userInfo;
        };

        public struct ATTLoggedOnEvent_t
        {
            ATTWorkMode_t workMode;
        };

        public enum ATTDeviceType_t
        {
            ATT_DT_ACD_SPLIT = 1,
            ATT_DT_ANNOUNCEMENT = 2,
            ATT_DT_DATA = 3,
            ATT_DT_LOGICAL_AGENT = 4,
            ATT_DT_STATION = 5,
            ATT_DT_TRUNK_ACCESS_CODE = 6,
            ATT_DT_VDN = 7
        };

        public struct ATTQueryDeviceName_t
        {
            Csta.DeviceID_t device;
        };

        public struct ATTV4QueryDeviceNameConfEvent_t
        {
            ATTDeviceType_t deviceType;
            Csta.DeviceID_t device;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            string name;
        };

        public enum ATTAgentTypeID_t
        {
            EXTENSION_ID = 0,
            LOGICAL_ID = 1
        };

        public enum ATTSplitSkill_t
        {
            SPLIT_SKILL_NONE = -1,
            SPLIT_SKILL_ALL = 0,
            SPLIT_SKILL1 = 1,
            SPLIT_SKILL2 = 2,
            SPLIT_SKILL3 = 3,
            SPLIT_SKILL4 = 4
        };

        public struct ATTInterval_t
        {
            public short _value;
        }
  
        public const int intvCurrent = -1;
        public const int intvDay = -2;
        public const int intvLast = -3;

        public struct ATTAgentMeasurements_t
        {
            int acdCalls;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
            string extension;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            string name;
            byte state;
            int avgACDTalkTime;
            int avgExtensionTime;
            int callRate;
            short elapsedTime;
            int extensionCalls;
            int extensionIncomingCalls;
            int extensionOutgoingCalls;
            int shiftACDCalls;
            int shiftAvgACDTalkTime;
            short splitAcceptableSvcLevel;
            int splitACDCalls;
            int splitAfterCallSessions;
            short splitAgentsAvailable;
            short splitAgentsInAfterCall;
            short splitAgentsInAux;
            short splitAgentsInOther;
            short splitAgentsOnACDCalls;
            short splitAgentsOnExtCalls;
            short splitAgentsStaffed;
            int splitAvgACDTalkTime;
            int splitAvgAfterCallTime;
            short splitAvgSpeedOfAnswer;
            short splitAvgTimeToAbandon;
            int splitCallRate;
            int splitCallsAbandoned;
            int splitCallsFlowedIn;
            int splitCallsFlowedOut;
            short splitCallsWaiting;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            string splitName;
            short splitNumber;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
            byte[] splitExtension;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
            byte[] splitObjective;
            short splitOldestCallWaiting;
            byte splitPercentInSvcLevel;
            int splitTotalACDTalkTime;
            int splitTotalAfterCallTime;
            int splitTotalAuxTime;
            int timeAgentEnteredState;
            int totalACDTalkTime;
            int totalAfterCallTime;
            int totalAuxTime;
            int totalAvailableTime;
            int totalHoldTime;
            int totalStaffedTime;
            int totalACDCallTime;
            int avgACDCallTime;
        };

        public struct ATTSplitSkillMeasurements_t
        {
            short acceptableSvcLevel;
            int acdCalls;
            int afterCallSessions;
            short agentsAvailable;
            short agentsInAfterCall;
            short agentsInAux;
            short agentsInOther;
            short onACDCalls;
            short agentsOnExtensionCalls;
            short agentsStaffed;
            int avgACDTalkTime;
            int afterCallTime;
            short avgSpeedOfAnswer;
            short avgTimeToAbandon;
            int callRate;
            int callsAbandoned;
            int callsFlowedIn;
            int callsFlowedOut;
            short callsWaiting;
            short oldestCallWaiting;
            byte percentInSvcLevel;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            string name;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            byte[] extension;
            short number;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            byte[] objective;
            int totalAfterCallTime;
            int totalAuxTime;
            int totalACDTalkTime;
        };

        public struct ATTTrunkGroupMeasurements_t
        {
            int avgIncomingCallTime;
            int avgOutgoingCallTime;
            int incomingAbandonedCalls;
            int incomingCalls;
            int incomingUsage;
            short numberOfTrunks;
            int outgoingCalls;
            int outgoingCompletedCalls;
            int outgoingUsage;
            byte percentAllTrunksBusy;
            byte percentTrunksMaintBusy;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            string trunkGroupName;
            short trunkGroupNumber;
            short trunksInUse;
            short trunksMaintBusy;
        };

        public struct ATTVdnMeasurements_t
        {
            short acceptableSvcLevel;
            int acdCalls;
            int avgACDTalkTime;
            short avgSpeedOfAnswer;
            short avgTimeToAbandon;
            int callsAbandoned;
            int callsFlowedOut;
            int callsForcedBusyDisc;
            int callsOffered;
            short callsWaiting;
            int callsNonACD;
            short oldestCallWaiting;
            byte percentInSvcLevel;
            int totalACDTalkTime;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            byte extension;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            string name;
        };

        public struct ATTAgentMeasurementsPresent_t
        {
            Boolean allMeasurements;
            Boolean acdCalls;
            Boolean extension;
            Boolean name;
            Boolean state;
            Boolean avgACDTalkTime;
            Boolean avgExtensionTime;
            Boolean callRate;
            Boolean elapsedTime;
            Boolean extensionCalls;
            Boolean extensionIncomingCalls;
            Boolean extensionOutgoingCalls;
            Boolean shiftACDCalls;
            Boolean shiftAvgACDTalkTime;
            Boolean splitAcceptableSvcLevel;
            Boolean splitACDCalls;
            Boolean splitAfterCallSessions;
            Boolean splitAgentsAvailable;
            Boolean splitAgentsInAfterCall;
            Boolean splitAgentsInAux;
            Boolean splitAgentsInOther;
            Boolean splitAgentsOnACDCalls;
            Boolean splitAgentsOnExtCalls;
            Boolean splitAgentsStaffed;
            Boolean splitAvgACDTalkTime;
            Boolean splitAvgAfterCallTime;
            Boolean splitAvgSpeedOfAnswer;
            Boolean splitAvgTimeToAbandon;
            Boolean splitCallRate;
            Boolean splitCallsAbandoned;
            Boolean splitCallsFlowedIn;
            Boolean splitCallsFlowedOut;
            Boolean splitCallsWaiting;
            Boolean splitName;
            Boolean splitNumber;
            Boolean splitExtension;
            Boolean splitObjective;
            Boolean splitOldestCallWaiting;
            Boolean splitPercentInSvcLevel;
            Boolean splitTotalACDTalkTime;
            Boolean splitTotalAfterCallTime;
            Boolean splitTotalAuxTime;
            Boolean timeAgentEnteredState;
            Boolean totalACDTalkTime;
            Boolean totalAfterCallTime;
            Boolean totalAuxTime;
            Boolean totalAvailableTime;
            Boolean totalHoldTime;
            Boolean totalStaffedTime;
            Boolean totalACDCallTime;
            Boolean avgACDCallTime;
        };

        public struct ATTSplitSkillMeasurementsPresent_t
        {
            Boolean allMeasurements;
            Boolean acceptableSvcLevel;
            Boolean acdCalls;
            Boolean afterCallSessions;
            Boolean agentsAvailable;
            Boolean agentsInAfterCall;
            Boolean agentsInAux;
            Boolean agentsInOther;
            Boolean onACDCalls;
            Boolean agentsOnExtensionCalls;
            Boolean agentsStaffed;
            Boolean avgACDTalkTime;
            Boolean afterCallTime;
            Boolean avgSpeedOfAnswer;
            Boolean avgTimeToAbandon;
            Boolean callRate;
            Boolean callsAbandoned;
            Boolean callsFlowedIn;
            Boolean callsFlowedOut;
            Boolean callsWaiting;
            Boolean oldestCallWaiting;
            Boolean percentInSvcLevel;
            Boolean name;
            Boolean extension;
            Boolean number;
            Boolean objective;
            Boolean totalAfterCallTime;
            Boolean totalAuxTime;
            Boolean totalACDTalkTime;
        };

        public struct ATTTrunkGroupMeasurementsPresent_t
        {
            Boolean allMeasurements;
            Boolean avgIncomingCallTime;
            Boolean avgOutgoingCallTime;
            Boolean incomingAbandonedCalls;
            Boolean incomingCalls;
            Boolean incomingUsage;
            Boolean numberOfTrunks;
            Boolean outgoingCalls;
            Boolean outgoingCompletedCalls;
            Boolean outgoingUsage;
            Boolean percentAllTrunksBusy;
            Boolean percentTrunksMaintBusy;
            Boolean trunkGroupName;
            Boolean trunkGroupNumber;
            Boolean trunksInUse;
            Boolean trunksMaintBusy;
        };

        public struct ATTVdnMeasurementsPresent_t
        {
            Boolean allMeasurements;
            Boolean acceptableSvcLevel;
            Boolean acdCalls;
            Boolean avgACDTalkTime;
            Boolean avgSpeedOfAnswer;
            Boolean avgTimeToAbandon;
            Boolean callsAbandoned;
            Boolean callsFlowedOut;
            Boolean callsForcedBusyDisc;
            Boolean callsOffered;
            Boolean callsWaiting;
            Boolean callsNonACD;
            Boolean oldestCallWaiting;
            Boolean percentInSvcLevel;
            Boolean totalACDTalkTime;
            Boolean extension;
            Boolean name;
        };

        public struct ATTQueryAgentMeasurements_t
        {
            Csta.DeviceID_t agentID;
            ATTAgentTypeID_t typeID;
            ATTSplitSkill_t splitSkill;
            ATTAgentMeasurementsPresent_t requestItems;
            ATTInterval_t interval;
        };

        public struct ATTQueryAgentMeasurementsConfEvent_t
        {
            ATTAgentMeasurementsPresent_t returnedItems;
            ATTAgentMeasurements_t values;
        };

        public struct ATTQuerySplitSkillMeasurements_t
        {
            Csta.DeviceID_t device;
            ATTSplitSkillMeasurementsPresent_t requestItems;
            ATTInterval_t interval;
        };

        public struct ATTQuerySplitSkillMeasurementsConfEvent_t
        {
            ATTSplitSkillMeasurementsPresent_t returnedItems;
            ATTSplitSkillMeasurements_t values;
        };

        public struct ATTQueryTrunkGroupMeasurements_t
        {
            Csta.DeviceID_t device;
            ATTTrunkGroupMeasurementsPresent_t requestItems;
            ATTInterval_t interval;
        };

        public struct ATTQueryTrunkGroupMeasurementsConfEvent_t
        {
            ATTTrunkGroupMeasurementsPresent_t returnedItems;
            ATTTrunkGroupMeasurements_t values;
        };

        public struct ATTQueryVdnMeasurements_t
        {
            Csta.DeviceID_t device;
            ATTVdnMeasurementsPresent_t requestItems;
            ATTInterval_t interval;
        };

        public struct ATTQueryVdnMeasurementsConfEvent_t
        {
            ATTVdnMeasurementsPresent_t returnedItems;
            ATTVdnMeasurements_t values;
        };

        public struct ATTV4ConferencedEvent_t
        {
            ATTV4OriginalCallInfo_t originalCallInfo;
            Csta.CalledDeviceID_t distributingDevice;
        };

        public struct ATTV4DeliveredEvent_t
        {
            ATTDeliveredType_t deliveredType;
            Csta.DeviceID_t trunk;
            Csta.DeviceID_t trunkMember;
            Csta.DeviceID_t split;
            ATTV4LookaheadInfo_t lookaheadInfo;
            ATTUserEnteredCode_t userEnteredCode;
            ATTV5UserToUserInfo_t userInfo;
            ATTReasonCode_t reason;
            ATTV4OriginalCallInfo_t originalCallInfo;
            Csta.CalledDeviceID_t distributingDevice;
        };

        public struct ATTV4EstablishedEvent_t
        {
            Csta.DeviceID_t trunk;
            Csta.DeviceID_t trunkMember;
            Csta.DeviceID_t split;
            ATTV4LookaheadInfo_t lookaheadInfo;
            ATTUserEnteredCode_t userEnteredCode;
            ATTV5UserToUserInfo_t userInfo;
            ATTReasonCode_t reason;
            ATTV4OriginalCallInfo_t originalCallInfo;
            Csta.CalledDeviceID_t distributingDevice;
        };

        public struct ATTV4TransferredEvent_t
        {
            ATTV4OriginalCallInfo_t originalCallInfo;
            Csta.CalledDeviceID_t distributingDevice;
        };

        public struct ATTV4LinkStatusEvent_t
        {
            short count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            ATTLinkStatus_t[] linkStatus;
        };

        public struct ATTV4GetAPICapsConfEvent_t
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            string switchVersion;
            Boolean sendDTMFTone;
            Boolean enteredDigitsEvent;
            Boolean queryDeviceName;
            Boolean queryAgentMeas;
            Boolean querySplitSkillMeas;
            Boolean queryTrunkGroupMeas;
            Boolean queryVdnMeas;
            Boolean reserved1;
            Boolean reserved2;
        };

        public enum ATTParticipationType_t
        {
            PT_ACTIVE = 1,
            PT_SILENT = 0
        };

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct ATTUCID_t
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            private string data;

            public ATTUCID_t(string value)
            {
                data = value;
            }

            public static implicit operator ATTUCID_t(string value)
            {
                return new ATTUCID_t(value);
            }

            public override string ToString()
            {
                return data;
            }
        }

        public struct ATTSingleStepConferenceCall_t
        {
            Csta.ConnectionID_t activeCall;
            Csta.DeviceID_t deviceToBeJoin;
            ATTParticipationType_t participationType;
            Boolean alertDestination;
        };

        public struct ATTSingleStepConferenceCallConfEvent_t
        {
            Csta.ConnectionID_t newCall;
            Csta.ConnectionList_t connList;
            ATTUCID_t ucid;
        };

        public struct ATTSelectiveListeningHold_t
        {
            Csta.ConnectionID_t subjectConnection;
            Boolean allParties;
            Csta.ConnectionID_t selectedParty;
        };

        public struct ATTSelectiveListeningHoldConfEvent_t
        {
            Acs.Nulltype dummy;
        };

        public struct ATTSelectiveListeningRetrieve_t
        {
            Csta.ConnectionID_t subjectConnection;
            Boolean allParties;
            Csta.ConnectionID_t selectedParty;
        };

        public struct ATTSelectiveListeningRetrieveConfEvent_t
        {
            Acs.Nulltype dummy;
        };

        public struct ATTUnicodeDeviceID_t
        {
            short count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            ushort[] value;
        };

        public struct ATTLookaheadInfo_t
        {
            ATTInterflow_t type;
            ATTPriority_t priority;
            short hours;
            short minutes;
            short seconds;
            Csta.DeviceID_t sourceVDN;
            ATTUnicodeDeviceID_t uSourceVDN;
        };

        public struct ATTCallOriginatorInfo_t
        {
            Boolean hasInfo;
            short callOriginatorType;
        };

        public struct ATTV5OriginalCallInfo_t
        {
            ATTReasonForCallInfo_t reason;
            Csta.CallingDeviceID_t callingDevice;
            Csta.CalledDeviceID_t calledDevice;
            Csta.DeviceID_t trunkGroup;
            Csta.DeviceID_t trunkMember;
            ATTLookaheadInfo_t lookaheadInfo;
            ATTUserEnteredCode_t userEnteredCode;
            ATTV5UserToUserInfo_t userInfo;
            ATTUCID_t ucid;
            ATTCallOriginatorInfo_t callOriginatorInfo;
            Boolean flexibleBilling;
        };

        public struct ATTConnIDList_t
        {
            int count;
            IntPtr pParty; //Csta.ConnectionID_t  FAR *pParty;
        };

        public struct ATTSendDTMFTone_t
        {
            Csta.ConnectionID_t sender;
            ATTConnIDList_t receivers;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
            byte[] tones;
            short toneDuration;
            short pauseDuration;
        };

        public struct ATTSnapshotDeviceConfEvent_t
        {
            int count;
            IntPtr pSnapshotDevice; //ATTSnapshotDevice_t FAR *pSnapshotDevice;
        };

        public struct ATTLinkStatusEvent_t
        {
            int count;
            IntPtr pLinkStatus; //ATTLinkStatus_t FAR *pLinkStatus;
        };

        public enum ATTBillType_t
        {
            BT_NEW_RATE = 16,
            BT_FLAT_RATE = 17,
            BT_PREMIUM_CHARGE = 18,
            BT_PREMIUM_CREDIT = 19,
            BT_FREE_CALL = 24
        };

        public struct ATTSetBillRate_t
        {
            Csta.ConnectionID_t call;
            ATTBillType_t billType;
            float billRate;
        };

        public struct ATTSetBillRateConfEvent_t
        {
            Acs.Nulltype dummy;
        };

        public struct ATTQueryUcid_t
        {
            Csta.ConnectionID_t call;
        };

        public struct ATTQueryUcidConfEvent_t
        {
            ATTUCID_t _ucid;

            public ATTUCID_t ucid
            {
                get { return _ucid; }
                set { _ucid = value; }
            }

            public override string ToString()
            {
                return _ucid.ToString();
            }
        };

        public struct ATTV5ConferencedEvent_t
        {
            ATTV5OriginalCallInfo_t originalCallInfo;
            Csta.CalledDeviceID_t distributingDevice;
            ATTUCID_t ucid;
        };

        public struct ATTLoggedOffEvent_t
        {
            int reasonCode;
        };

        public struct ATTV5DeliveredEvent_t
        {
            ATTDeliveredType_t deliveredType;
            Csta.DeviceID_t trunkGroup;
            Csta.DeviceID_t trunkMember;
            Csta.DeviceID_t split;
            ATTLookaheadInfo_t lookaheadInfo;
            ATTUserEnteredCode_t userEnteredCode;
            ATTV5UserToUserInfo_t userInfo;
            ATTReasonCode_t reason;
            ATTV5OriginalCallInfo_t originalCallInfo;
            Csta.CalledDeviceID_t distributingDevice;
            ATTUCID_t ucid;
            ATTCallOriginatorInfo_t callOriginatorInfo;
            Boolean flexibleBilling;
        };

        public struct ATTV5EstablishedEvent_t
        {
            Csta.DeviceID_t trunkGroup;
            Csta.DeviceID_t trunkMember;
            Csta.DeviceID_t split;
            ATTLookaheadInfo_t lookaheadInfo;
            ATTUserEnteredCode_t userEnteredCode;
            ATTV5UserToUserInfo_t userInfo;
            ATTReasonCode_t reason;
            ATTV5OriginalCallInfo_t originalCallInfo;
            Csta.CalledDeviceID_t distributingDevice;
            ATTUCID_t ucid;
            ATTCallOriginatorInfo_t callOriginatorInfo;
            Boolean flexibleBilling;
        };

        public struct ATTV5TransferredEvent_t
        {
            ATTV5OriginalCallInfo_t originalCallInfo;
            Csta.CalledDeviceID_t distributingDevice;
            ATTUCID_t ucid;
        };

        public struct ATTV5RouteRequestEvent_t
        {
            Csta.DeviceID_t trunkGroup;
            ATTLookaheadInfo_t lookaheadInfo;
            ATTUserEnteredCode_t userEnteredCode;
            ATTV5UserToUserInfo_t userInfo;
            ATTUCID_t ucid;
            ATTCallOriginatorInfo_t callOriginatorInfo;
            Boolean flexibleBilling;
        };

        public struct ATTPrivateFilter_t
        {
            public byte _value;
        }
       
        public const byte ATT_ENTERED_DIGITS_FILTER = 0x80;
        public const byte ATT_CHARGE_ADVICE_FILTER = 0x40;

        public struct ATTConsultationCallConfEvent_t
        {
            ATTUCID_t ucid;
        };

        public struct ATTMakeCallConfEvent_t
        {
            ATTUCID_t ucid;
        };

        public struct ATTMakePredictiveCallConfEvent_t
        {
            ATTUCID_t ucid;
        };

        public struct ATTV5SetAgentState_t
        {
            ATTWorkMode_t workMode;
            int reasonCode;
        };

        public struct ATTV5QueryAgentStateConfEvent_t
        {
            ATTWorkMode_t workMode;
            ATTTalkState_t talkState;
            int reasonCode;
        };

        public struct ATTQueryDeviceNameConfEvent_t
        {
            ATTDeviceType_t deviceType;
            Csta.DeviceID_t device;
            Csta.DeviceID_t name;
            ATTUnicodeDeviceID_t uname;
        };

        public struct ATTConferenceCallConfEvent_t
        {
            ATTUCID_t ucid;
        };

        public struct ATTTransferCallConfEvent_t
        {
            ATTUCID_t ucid;
        };

        public struct ATTMonitorFilter_t
        {
            ATTPrivateFilter_t privateFilter;
        };

        public struct ATTMonitorConfEvent_t
        {
            ATTPrivateFilter_t usedFilter;
        };

        public struct ATTSnapshotCall_t
        {
            int count;
            IntPtr pInfo; //CSTASnapshotCallResponseInfo_t FAR *pInfo;
        };

        public struct ATTMonitorCallConfEvent_t
        {
            ATTPrivateFilter_t usedFilter;
            ATTSnapshotCall_t snapshotCall;
        };

        public struct ATTServiceInitiatedEvent_t
        {
            ATTUCID_t ucid;
        };

        public enum ATTChargeType_t
        {
            CT_INTERMEDIATE_CHARGE = 1,
            CT_FINAL_CHARGE = 2,
            CT_SPLIT_CHARGE = 3
        };

        public enum ATTChargeError_t
        {
            CE_NONE = 0,
            CE_NO_FINAL_CHARGE = 1,
            CE_LESS_FINAL_CHARGE = 2,
            CE_CHARGE_TOO_LARGE = 3,
            CE_NETWORK_BUSY = 4
        };

        public struct ATTChargeAdviceEvent_t
        {
            Csta.ConnectionID_t connection;
            Csta.DeviceID_t calledDevice;
            Csta.DeviceID_t chargingDevice;
            Csta.DeviceID_t trunkGroup;
            Csta.DeviceID_t trunkMember;
            ATTChargeType_t chargeType;
            int charge;
            ATTChargeError_t error;
        };

        public struct ATTGetAPICapsConfEvent_t
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            string switchVersion;
            Boolean sendDTMFTone;
            Boolean enteredDigitsEvent;
            Boolean queryDeviceName;
            Boolean queryAgentMeas;
            Boolean querySplitSkillMeas;
            Boolean queryTrunkGroupMeas;
            Boolean queryVdnMeas;
            Boolean singleStepConference;
            Boolean selectiveListeningHold;
            Boolean selectiveListeningRetrieve;
            Boolean setBillingRate;
            Boolean queryUCID;
            Boolean chargeAdviceEvent;
            Boolean reserved1;
            Boolean reserved2;
        };

        public struct ATTQueryDeviceInfoConfEvent_t
        {
            ATTExtensionClass_t extensionClass;
            ATTExtensionClass_t associatedClass;
            Csta.DeviceID_t associatedDevice;
        };

        public struct ATTSetAdviceOfCharge_t
        {
            Boolean featureFlag;
        };

        public struct ATTSetAdviceOfChargeConfEvent_t
        {
            Acs.Nulltype dummy;
        };

        public struct ATTNetworkReachedEvent_t
        {
            ATTProgressLocation_t progressLocation;
            ATTProgressDescription_t progressDescription;
            Csta.DeviceID_t trunkGroup;
            Csta.DeviceID_t trunkMember;
        };

        public struct ATTSetAgentState_t
        {
            ATTWorkMode_t workMode;
            int reasonCode;
            Boolean enablePending;
        };

        public struct ATTSetAgentStateConfEvent_t
        {
            Boolean isPending;
        };

        public struct ATTQueryAgentStateConfEvent_t
        {
            ATTWorkMode_t workMode;
            ATTTalkState_t talkState;
            int reasonCode;
            ATTWorkMode_t pendingWorkMode;
            int pendingReasonCode;
        };

        public struct ATTUserToUserInfo_t
        {
            ATTUUIProtocolType_t type;
            public struct data
            {
                short length;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
                byte[] value;
            };
        };

        public struct ATTRouteRequestEvent_t
        {
            Csta.DeviceID_t trunkGroup;
            ATTLookaheadInfo_t lookaheadInfo;
            ATTUserEnteredCode_t userEnteredCode;
            ATTUserToUserInfo_t userInfo;
            ATTUCID_t ucid;
            ATTCallOriginatorInfo_t callOriginatorInfo;
            Boolean flexibleBilling;
            Csta.DeviceID_t trunkMember;
        };

        public struct ATTOriginalCallInfo_t
        {
            ATTReasonForCallInfo_t reason;
            Csta.CallingDeviceID_t callingDevice;
            Csta.CalledDeviceID_t calledDevice;
            Csta.DeviceID_t trunkGroup;
            Csta.DeviceID_t trunkMember;
            ATTLookaheadInfo_t lookaheadInfo;
            ATTUserEnteredCode_t userEnteredCode;
            ATTUserToUserInfo_t userInfo;
            ATTUCID_t ucid;
            ATTCallOriginatorInfo_t callOriginatorInfo;
            Boolean flexibleBilling;
        };

        public struct ATTTrunkInfo_t
        {
            Csta.ConnectionID_t connection;
            Csta.DeviceID_t trunkGroup;
            Csta.DeviceID_t trunkMember;
        };

        public const int MAX_TRUNKS = 5;

        public struct ATTTrunkList_t
        {
            short count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_TRUNKS)]
            ATTTrunkInfo_t[] trunks;
        };

        public struct ATTTransferredEvent_t
        {
            ATTOriginalCallInfo_t originalCallInfo;
            Csta.CalledDeviceID_t distributingDevice;
            ATTUCID_t ucid;
            ATTTrunkList_t trunkList;
        };

        public struct ATTConferencedEvent_t
        {
            ATTOriginalCallInfo_t originalCallInfo;
            Csta.CalledDeviceID_t distributingDevice;
            ATTUCID_t ucid;
            ATTTrunkList_t trunkList;
        };

        public struct ATTClearConnection_t
        {
            ATTDropResource_t dropResource;
            ATTUserToUserInfo_t userInfo;
        };

        public struct ATTConsultationCall_t
        {
            Csta.DeviceID_t destRoute;
            Boolean priorityCalling;
            ATTUserToUserInfo_t userInfo;
        };

        public struct ATTMakeCall_t
        {
            Csta.DeviceID_t destRoute;
            Boolean priorityCalling;
            ATTUserToUserInfo_t userInfo;
        };

        public struct ATTDirectAgentCall_t
        {
            Csta.DeviceID_t split;
            Boolean priorityCalling;
            ATTUserToUserInfo_t userInfo;
        };

        public struct ATTMakePredictiveCall_t
        {
            Boolean priorityCalling;
            short maxRings;
            ATTAnswerTreat_t answerTreat;
            Csta.DeviceID_t destRoute;
            ATTUserToUserInfo_t userInfo;
        };

        public struct ATTSupervisorAssistCall_t
        {
            Csta.DeviceID_t split;
            ATTUserToUserInfo_t userInfo;
        };

        public struct ATTReconnectCall_t
        {
            ATTDropResource_t dropResource;
            ATTUserToUserInfo_t userInfo;
        };

        public struct ATTConnectionClearedEvent_t
        {
            ATTUserToUserInfo_t userInfo;
        };

        public struct ATTRouteSelect_t
        {
            Csta.DeviceID_t callingDevice;
            Csta.DeviceID_t directAgentCallSplit;
            Boolean priorityCalling;
            Csta.DeviceID_t destRoute;
            ATTUserCollectCode_t collectCode;
            ATTUserProvidedCode_t userProvidedCode;
            ATTUserToUserInfo_t userInfo;
        };

        public struct ATTDeliveredEvent_t
        {
            ATTDeliveredType_t deliveredType;
            Csta.DeviceID_t trunkGroup;
            Csta.DeviceID_t trunkMember;
            Csta.DeviceID_t split;
            ATTLookaheadInfo_t lookaheadInfo;
            ATTUserEnteredCode_t userEnteredCode;
            ATTUserToUserInfo_t userInfo;
            ATTReasonCode_t reason;
            ATTOriginalCallInfo_t originalCallInfo;
            Csta.CalledDeviceID_t distributingDevice;
            ATTUCID_t ucid;
            ATTCallOriginatorInfo_t callOriginatorInfo;
            Boolean flexibleBilling;
        };

        public struct ATTEstablishedEvent_t
        {
            Csta.DeviceID_t trunkGroup;
            Csta.DeviceID_t trunkMember;
            Csta.DeviceID_t split;
            ATTLookaheadInfo_t lookaheadInfo;
            ATTUserEnteredCode_t userEnteredCode;
            ATTUserToUserInfo_t userInfo;
            ATTReasonCode_t reason;
            ATTOriginalCallInfo_t originalCallInfo;
            Csta.CalledDeviceID_t distributingDevice;
            ATTUCID_t ucid;
            ATTCallOriginatorInfo_t callOriginatorInfo;
            Boolean flexibleBilling;
        };

        public struct ATTOriginatedEvent_t
        {
            Csta.DeviceID_t logicalAgent;
            ATTUserToUserInfo_t userInfo;
        };
    }
}
