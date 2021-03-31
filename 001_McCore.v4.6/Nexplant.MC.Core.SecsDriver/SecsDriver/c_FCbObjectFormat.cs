/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FCbObjectFormat.cs
--  Creator         : byjeon
--  Create Date     : 2011.08.16
--  Description     : FAMate Core FaSecsDriver Clipboard Object Format Class 
--  History         : Created by byjeon at 2011.08.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal static class FCbObjectFormat
    {

        //------------------------------------------------------------------------------------------------------------------------       

        private static string Prefix = "FAMATE_SECS_";

        // --

        public static string SecsDriver = Prefix + FXmlTagSCD.E_SecsDriver;
        // --
        public static string ObjectNameList = Prefix + FXmlTagONL.E_ObjectNameList;
        public static string ObjectName = Prefix + FXmlTagONA.E_ObjectName;
        // --
        public static string FunctionNameList = Prefix + FXmlTagFNL.E_FunctionNameList;
        public static string FunctionName = Prefix + FXmlTagFNA.E_FunctionName;
        public static string ParameterName = Prefix + FXmlTagPAN.E_ParameterName;
        public static string Argument = Prefix + FXmlTagARG.E_Argument;
        // --
        public static string UserTagName = Prefix + FXmlTagUTN.E_UserTagName;
        // --
        public static string DataConversionSetList = Prefix + FXmlTagDCL.E_DataConversionSetList;
        public static string DataConversionSet = Prefix + FXmlTagDCS.E_DataConversionSet;
        public static string DataConversion = Prefix + FXmlTagDCV.E_DataConversion;
        // --
        public static string EquipmentStateSetList = Prefix + FXmlTagESL.E_EquipmentStateSetList;
        public static string EquipmentStateSet = Prefix + FXmlTagESS.E_EquipmentStateSet;
        public static string EquipmentState = Prefix + FXmlTagEST.E_EquipmentState;
        public static string StateValue = Prefix + FXmlTagSTV.E_StateValue;
        // --
        public static string RepositoryList = Prefix + FXmlTagRPL.E_RepositoryList;
        public static string Repository = Prefix + FXmlTagRPS.E_Repository;
        public static string Column = Prefix + FXmlTagCOL.E_Column;
        // --
        public static string EnvironmentList = Prefix + FXmlTagENL.E_EnvironmentList;
        public static string Environment = Prefix + FXmlTagENV.E_Environment;
        // --        
        public static string DataSetList = Prefix + FXmlTagDSL.E_DataSetList;
        public static string DataSet = Prefix + FXmlTagDTS.E_DataSet;
        public static string Data = Prefix + FXmlTagDAT.E_Data;        
        // --
        public static string SecsLibraryGroup = Prefix + FXmlTagSLG.E_SecsLibraryGroup;
        public static string SecsLibrary = Prefix + FXmlTagSLB.E_SecsLibrary;
        public static string SecsMessageList = Prefix + FXmlTagSML.E_SecsMessageList;
        public static string SecsMessages = Prefix + FXmlTagSMS.E_SecsMessages;
        public static string SecsMessage = Prefix + FXmlTagSMG.E_SecsMessage;
        public static string SecsItem = Prefix + FXmlTagSIT.E_SecsItem;
        // --
        public static string SecsDevice = Prefix + FXmlTagSDV.E_SecsDevice;
        public static string SecsSession = Prefix + FXmlTagSSN.E_SecsSession;
        // --
        public static string HostLibraryGroup = Prefix + FXmlTagHLG.E_HostLibraryGroup;
        public static string HostLibrary = Prefix + FXmlTagHLB.E_HostLibrary;
        public static string HostMessageList = Prefix + FXmlTagHML.E_HostMessageList;
        public static string HostMessages = Prefix + FXmlTagHMS.E_HostMessages;
        public static string HostMessage = Prefix + FXmlTagHMG.E_HostMessage;
        public static string HostItem = Prefix + FXmlTagHIT.E_HostItem;
        // --
        public static string HostDevice = Prefix + FXmlTagHDV.E_HostDevice;
        public static string HostSession = Prefix + FXmlTagHSN.E_HostSession;
        // --
        public static string Equipment = Prefix + FXmlTagEQP.E_Equipment;
        public static string ScenarioGroup = Prefix + FXmlTagSNG.E_ScenarioGroup;
        public static string Scenario = Prefix + FXmlTagSNR.E_Scenario;
        public static string SecsTrigger = Prefix + FXmlTagSTR.E_SecsTrigger;
        public static string SecsCondition = Prefix + FXmlTagSCN.E_SecsCondition;
        public static string SecsExpression = Prefix + FXmlTagSEP.E_SecsExpression;
        public static string SecsTransmitter = Prefix + FXmlTagSTN.E_SecsTransmitter;
        public static string SecsTransfer = Prefix + FXmlTagSTF.E_SecsTransfer;
        public static string HostTrigger = Prefix + FXmlTagHTR.E_HostTrigger;
        public static string HostCondition = Prefix + FXmlTagHCN.E_HostCondition;
        public static string HostExpression = Prefix + FXmlTagHEP.E_HostExpression;
        public static string HostTransmitter = Prefix + FXmlTagHTN.E_HostTransmitter;
        public static string HostTransfer = Prefix + FXmlTagHTF.E_HostTransfer;
        public static string EquipmentStateSetAlterer = Prefix + FXmlTagESA.E_EquipmentStateSetAlterer;
        public static string EquipmentStateAlterer = Prefix + FXmlTagEAT.E_EquipmentStateAlterer;
        public static string Judgement = Prefix + FXmlTagJDM.E_Judgement;
        public static string JudgementCondition = Prefix + FXmlTagJCN.E_JudgementCondition;
        public static string JudgementExpression = Prefix + FXmlTagJEP.E_JudgementExpression;
        public static string Mapper = Prefix + FXmlTagMAP.E_Mapper;
        public static string Storage = Prefix + FXmlTagSTG.E_Storage;
        public static string Callback = Prefix + FXmlTagCBK.E_Callback;
        public static string Function = Prefix + FXmlTagFUN.E_Function;
        public static string Branch = Prefix + FXmlTagBRN.E_Branch;
        public static string Comment = Prefix + FXmlTagCMT.E_Comment;
        public static string Pauser = Prefix + FXmlTagPAU.E_Pauser;
        public static string EntryPoint = Prefix + FXmlTagETP.E_EntryPoint;

        //------------------------------------------------------------------------------------------------------------------------       

    }   // Class end
}   // Namespace end