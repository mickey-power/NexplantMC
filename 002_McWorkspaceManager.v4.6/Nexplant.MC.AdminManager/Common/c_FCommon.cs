/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FCommon.cs
--  Creator         : mj.kim
--  Create Date     : 2012.01.09
--  Description     : FAMate Admin Manager Common Function Class 
--  History         : Created by mj.kim at 2012.01.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;
using System.Collections.Generic;
using Nexplant.MC.Adminmanager;
using System.Runtime.Remoting.Metadata;

namespace Nexplant.MC.AdminManager
{
    public static class FCommon
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static void validateName(
            string name,
            bool emptyError,
            FUIWizard fUIWizard,
            params object[] args
            )
        {
            char[] c = { ' ', '\\', '/', '.', ',', '\'', '"', '&', '|', '[', ']', '(', ')', ':', ';', '`', '~', '!', '@', '#', '$', '%', '^', '*', '+', '=', '\n', '\r' };

            try
            {
                if (name == string.Empty && emptyError)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", args));
                }

                if (name.IndexOfAny(c) > -1)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0015", args));
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static bool validateName(
            string name, 
            bool emptyError,             
            ref string errorMessage,
            FUIWizard fUIWizard, 
            params object[] args
            )
        {
            char[] c = { ' ', '\\', '/', '.', ',', '\'', '"', '&', '|', '[', ']', '(', ')', ':', ';', '`', '~', '!', '@', '#', '$', '%', '^', '*', '+', '=', '\n', '\r' };

            try
            {
                errorMessage = string.Empty;

                if (name == string.Empty && emptyError)
                {
                    errorMessage = fUIWizard.generateMessage("E0004", args);
                    return false;
                }

                if (name.IndexOfAny(c) > -1)
                {
                    errorMessage = fUIWizard.generateMessage("E0015", args);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNode(
            string elementName
            )
        {
            FXmlDocument fXmlDoc = null;

            try
            {
                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;
                fXmlDoc.appendChild(fXmlDoc.createNode(elementName));
                // --
                return fXmlDoc.fFirstChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static DataTable requestCommonSqlQuery(
            FAdmCore fAdmCore,
            string module,
            string function,
            string sqlCode,
            FSqlParams fSqlParams,
            bool isZeroRowError,
            ref int nextRowNumber
            )
        {
            FSqlParam fSqlParam = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInQuery = null;
            FXmlNode fXmlNodeInParams = null;
            FXmlNode fXmlNodeInParam = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutTbl = null;            

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_ComSqlQuery_In.E_ADMADS_ComSqlQuery_In);
                fXmlNodeIn.set_elemVal(FADMADS_ComSqlQuery_In.A_hLanguage, FADMADS_ComSqlQuery_In.D_hLanguage, fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_ComSqlQuery_In.A_hFactory, FADMADS_ComSqlQuery_In.D_hFactory, fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_ComSqlQuery_In.A_hUserId, FADMADS_ComSqlQuery_In.D_hUserId, fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_ComSqlQuery_In.A_hStep, FADMADS_ComSqlQuery_In.D_hStep, "1");
                // --
                fXmlNodeInQuery = fXmlNodeIn.set_elem(FADMADS_ComSqlQuery_In.FQuery.E_Query);
                fXmlNodeInQuery.set_elemVal(FADMADS_ComSqlQuery_In.FQuery.A_Module, FADMADS_ComSqlQuery_In.FQuery.D_Module, module);
                fXmlNodeInQuery.set_elemVal(FADMADS_ComSqlQuery_In.FQuery.A_Function, FADMADS_ComSqlQuery_In.FQuery.D_Function, function);
                fXmlNodeInQuery.set_elemVal(FADMADS_ComSqlQuery_In.FQuery.A_SqlCode, FADMADS_ComSqlQuery_In.FQuery.D_SqlCode, sqlCode);
                // --
                fXmlNodeInParams = fXmlNodeInQuery.set_elem(FADMADS_ComSqlQuery_In.FQuery.FParams.E_Params);
                for (int i = 0; i < fSqlParams.count; i++)
                {
                    fSqlParam = fSqlParams[i];
                    // --
                    fXmlNodeInParam = fXmlNodeInParams.add_elem(FADMADS_ComSqlQuery_In.FQuery.FParams.FParam.E_Param);
                    fXmlNodeInParam.set_elemVal(FADMADS_ComSqlQuery_In.FQuery.FParams.FParam.A_Name, FADMADS_ComSqlQuery_In.FQuery.FParams.FParam.D_Name, fSqlParam.name);
                    fXmlNodeInParam.set_elemVal(FADMADS_ComSqlQuery_In.FQuery.FParams.FParam.A_Value, FADMADS_ComSqlQuery_In.FQuery.FParams.FParam.D_Name, fSqlParam.value);
                    fXmlNodeInParam.set_elemVal(FADMADS_ComSqlQuery_In.FQuery.FParams.FParam.A_IsNullValue, FADMADS_ComSqlQuery_In.FQuery.FParams.FParam.D_IsNullValue, fSqlParam.isNullValue.ToString());
                }
                // --
                fXmlNodeInQuery.set_elemVal(FADMADS_ComSqlQuery_In.FQuery.A_IsRowZeroError, FADMADS_ComSqlQuery_In.FQuery.D_IsRowZeroError, isZeroRowError.ToString());
                fXmlNodeInQuery.set_elemVal(FADMADS_ComSqlQuery_In.FQuery.A_NextRowNumber, FADMADS_ComSqlQuery_In.FQuery.D_NextRowNumber, nextRowNumber.ToString());

                // --

                FADMADSCaster.ADMADS_ComSqlQuery_Req(
                    fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_ComSqlQuery_Out.A_hStatus, FADMADS_ComSqlQuery_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_ComSqlQuery_Out.A_hStatusMessage, FADMADS_ComSqlQuery_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutTbl = fXmlNodeOut.get_elem(FADMADS_ComSqlQuery_Out.FTable.E_Table);
                // --
                nextRowNumber = int.Parse(
                    fXmlNodeOutTbl.get_elemVal(FADMADS_ComSqlQuery_Out.FTable.A_NextRowNumber, FADMADS_ComSqlQuery_Out.FTable.D_NextRowNumber)
                    );

                // --

                return FDbWizard.stringToDataTable(
                    fXmlNodeOutTbl.get_elemVal(FADMADS_ComSqlQuery_Out.FTable.A_Columns, FADMADS_ComSqlQuery_Out.FTable.D_Columns),
                    fXmlNodeOutTbl.get_elemVal(FADMADS_ComSqlQuery_Out.FTable.A_Rows, FADMADS_ComSqlQuery_Out.FTable.D_Rows)
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParam = null;
                fXmlNodeIn = null;
                fXmlNodeInQuery = null;
                fXmlNodeInParams = null;
                fXmlNodeInParam = null;
                fXmlNodeOut = null;
                fXmlNodeOutTbl = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static DataTable requestCommonSqlQuery(
            FAdmCore fAdmCore,
            string module,
            string function,
            string sqlCode,
            FSqlParams fSqlParams,
            bool isZeroRowError
            )
        {
            int nextRowNumber = 0;

            try
            {
                return requestCommonSqlQuery(
                    fAdmCore, 
                    module, 
                    function, 
                    sqlCode, 
                    fSqlParams, 
                    isZeroRowError, 
                    ref nextRowNumber
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static DataTable requestCommonSqlQuery(
            FAdmCore fAdmCore,
            string module,
            string function,
            string sqlCode,
            FSqlParams fSqlParams,
            bool isZeroRowError,
            bool isTrim,
            ref int nextRowNumber
            )
        {
            FSqlParam fSqlParam = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInQuery = null;
            FXmlNode fXmlNodeInParams = null;
            FXmlNode fXmlNodeInParam = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutTbl = null;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_ComSqlQuery_In.E_ADMADS_ComSqlQuery_In);
                fXmlNodeIn.set_elemVal(FADMADS_ComSqlQuery_In.A_hLanguage, FADMADS_ComSqlQuery_In.D_hLanguage, fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_ComSqlQuery_In.A_hFactory, FADMADS_ComSqlQuery_In.D_hFactory, fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_ComSqlQuery_In.A_hUserId, FADMADS_ComSqlQuery_In.D_hUserId, fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_ComSqlQuery_In.A_hStep, FADMADS_ComSqlQuery_In.D_hStep, "1");
                // --
                fXmlNodeInQuery = fXmlNodeIn.set_elem(FADMADS_ComSqlQuery_In.FQuery.E_Query);
                fXmlNodeInQuery.set_elemVal(FADMADS_ComSqlQuery_In.FQuery.A_Module, FADMADS_ComSqlQuery_In.FQuery.D_Module, module);
                fXmlNodeInQuery.set_elemVal(FADMADS_ComSqlQuery_In.FQuery.A_Function, FADMADS_ComSqlQuery_In.FQuery.D_Function, function);
                fXmlNodeInQuery.set_elemVal(FADMADS_ComSqlQuery_In.FQuery.A_SqlCode, FADMADS_ComSqlQuery_In.FQuery.D_SqlCode, sqlCode);
                // --
                fXmlNodeInParams = fXmlNodeInQuery.set_elem(FADMADS_ComSqlQuery_In.FQuery.FParams.E_Params);
                for (int i = 0; i < fSqlParams.count; i++)
                {
                    fSqlParam = fSqlParams[i];
                    // --
                    fXmlNodeInParam = fXmlNodeInParams.add_elem(FADMADS_ComSqlQuery_In.FQuery.FParams.FParam.E_Param);
                    fXmlNodeInParam.set_elemVal(FADMADS_ComSqlQuery_In.FQuery.FParams.FParam.A_Name, FADMADS_ComSqlQuery_In.FQuery.FParams.FParam.D_Name, fSqlParam.name);
                    fXmlNodeInParam.set_elemVal(FADMADS_ComSqlQuery_In.FQuery.FParams.FParam.A_Value, FADMADS_ComSqlQuery_In.FQuery.FParams.FParam.D_Name, fSqlParam.value);
                    fXmlNodeInParam.set_elemVal(FADMADS_ComSqlQuery_In.FQuery.FParams.FParam.A_IsNullValue, FADMADS_ComSqlQuery_In.FQuery.FParams.FParam.D_IsNullValue, fSqlParam.isNullValue.ToString());
                }
                // --
                fXmlNodeInQuery.set_elemVal(FADMADS_ComSqlQuery_In.FQuery.A_IsRowZeroError, FADMADS_ComSqlQuery_In.FQuery.D_IsRowZeroError, isZeroRowError.ToString());
                fXmlNodeInQuery.set_elemVal(FADMADS_ComSqlQuery_In.FQuery.A_IsTrim, FADMADS_ComSqlQuery_In.FQuery.D_IsTrim, isTrim.ToString());
                fXmlNodeInQuery.set_elemVal(FADMADS_ComSqlQuery_In.FQuery.A_NextRowNumber, FADMADS_ComSqlQuery_In.FQuery.D_NextRowNumber, nextRowNumber.ToString());

                // --

                FADMADSCaster.ADMADS_ComSqlQuery_Req(
                    fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_ComSqlQuery_Out.A_hStatus, FADMADS_ComSqlQuery_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_ComSqlQuery_Out.A_hStatusMessage, FADMADS_ComSqlQuery_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutTbl = fXmlNodeOut.get_elem(FADMADS_ComSqlQuery_Out.FTable.E_Table);
                // --
                nextRowNumber = int.Parse(
                    fXmlNodeOutTbl.get_elemVal(FADMADS_ComSqlQuery_Out.FTable.A_NextRowNumber, FADMADS_ComSqlQuery_Out.FTable.D_NextRowNumber)
                    );

                // --

                return FDbWizard.stringToDataTable(
                    fXmlNodeOutTbl.get_elemVal(FADMADS_ComSqlQuery_Out.FTable.A_Columns, FADMADS_ComSqlQuery_Out.FTable.D_Columns),
                    fXmlNodeOutTbl.get_elemVal(FADMADS_ComSqlQuery_Out.FTable.A_Rows, FADMADS_ComSqlQuery_Out.FTable.D_Rows)
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParam = null;
                fXmlNodeIn = null;
                fXmlNodeInQuery = null;
                fXmlNodeInParams = null;
                fXmlNodeInParam = null;
                fXmlNodeOut = null;
                fXmlNodeOutTbl = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static DataTable requestCommonSqlQuery(
            FAdmCore fAdmCore,
            string module,
            string function,
            string sqlCode,
            FSqlParams fSqlParams,
            bool isZeroRowError,
            bool isTrim
            )
        {
            int nextRowNumber = 0;

            try
            {
                return requestCommonSqlQuery(
                    fAdmCore,
                    module,
                    function,
                    sqlCode,
                    fSqlParams,
                    isZeroRowError,
                    isTrim,
                    ref nextRowNumber
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FFtp createFtp(
            FAdmCore fAdmCore
            )
        {
            try
            {
                if (fAdmCore.fOption.ftpUsedAnonymous)
                {
                    return new FFtp(false, fAdmCore.fOption.ftpIp);
                }
                return new FFtp(false, fAdmCore.fOption.ftpIp, fAdmCore.fOption.ftpUser, fAdmCore.fOption.ftpPassword);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static bool stringEquals(
            string a,
            params string[] b
            )
        {
            try
            {
                foreach (string s in b)
                {
                    if (!a.Equals(s))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return true;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static bool hasFunctionAuthority(
            FAdmCore fAdmCore,
            FUserFunction function
            )
        {
            try
            {
                return fAdmCore.fOption.authority.hasFunctionAuthority(function.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static bool hasTransactionAuthority(
            FAdmCore fAdmCore,
            FUserFunction function
            )
        {
            try
            {
                return fAdmCore.fOption.authority.hasTransactionAuthority(function.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void refreshTreeNodeOfObjectLog(
            FIObjectLog fObjectLog,
            FTreeView tvwTree,
            UltraTreeNode tNode
            )
        {
            FResultCode fResultCode = FResultCode.Success;

            try
            {
                tNode.Text = fObjectLog.ToString(FStringOption.Detail);
                // --
                tNode.Override.NodeAppearance.ForeColor = fObjectLog.fontColor;
                tNode.Override.NodeAppearance.FontData.Bold = fObjectLog.fontBold ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False;
                // --
                tNode.Override.ActiveNodeAppearance.ForeColor = fObjectLog.fontColor;
                tNode.Override.ActiveNodeAppearance.FontData.Bold = fObjectLog.fontBold ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False;
                // --
                tNode.Override.SelectedNodeAppearance.ForeColor = fObjectLog.fontColor;
                tNode.Override.SelectedNodeAppearance.FontData.Bold = fObjectLog.fontBold ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False;
                // --
                tNode.Override.ImageSize = new System.Drawing.Size(16, 16);
                tNode.Override.NodeAppearance.Image = getImageOfObjectLog(fObjectLog, tvwTree);

                // --

                fResultCode = getResultCode(fObjectLog);
                if (fResultCode != FResultCode.Success)
                {
                    tNode.LeftImages.Add(fResultCode == FResultCode.Warninig ?
                        tvwTree.ImageList.Images["Result_Warning"] : tvwTree.ImageList.Images["Result_Error"]
                        );
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static Image getImageOfObjectLog(
            FIObjectLog fObjectLog,
            FTreeView tvwTree
            )
        {
            FDeviceState fDeviceState;
            FHostMessageType fHostMessageType;

            try
            {
                // ***
                // SecsDriver
                // ***
                if (fObjectLog.fObjectLogType == FObjectLogType.SecsDriverLog)
                {
                    return tvwTree.ImageList.Images["SecsDriverLog"];
                }
                // ***
                // SecsDevice
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceStateChangedLog)
                {
                    fDeviceState = ((FSecsDeviceStateChangedLog)fObjectLog).fState;
                    if (fDeviceState == FDeviceState.Opened)
                    {
                        return tvwTree.ImageList.Images["SdvStateChangedLog_Opened"];
                    }
                    else if (fDeviceState == FDeviceState.Connected)
                    {
                        return tvwTree.ImageList.Images["SdvStateChangedLog_Connected"];
                    }
                    else if (fDeviceState == FDeviceState.Selected)
                    {
                        return tvwTree.ImageList.Images["SdvStateChangedLog_Selected"];
                    }
                    else if (fDeviceState == FDeviceState.Closed)
                    {
                        return tvwTree.ImageList.Images["SdvStateChangedLog_Closed"];
                    }
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceControlMessageReceivedLog)
                {
                    return tvwTree.ImageList.Images["SdvControlMessageReceivedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceControlMessageSentLog)
                {
                    return tvwTree.ImageList.Images["SdvControlMessageSentLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketReceivedLog)
                {
                    return tvwTree.ImageList.Images["SdvTelnetPacketReceivedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketSentLog)
                {
                    return tvwTree.ImageList.Images["SdvTelnetPacketSentLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetStateChangedLog)
                {
                    return tvwTree.ImageList.Images["SdvTelnetStateChangedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceHandshakeReceivedLog)
                {
                    return tvwTree.ImageList.Images["SdvHandshakeReceivedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceHandshakeSentLog)
                {
                    return tvwTree.ImageList.Images["SdvHandshakeSentLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceBlockReceivedLog)
                {
                    return tvwTree.ImageList.Images["SdvBlockReceivedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceBlockSentLog)
                {
                    return tvwTree.ImageList.Images["SdvBlockSentLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                {
                    return ((FSecsDeviceDataMessageReceivedLog)fObjectLog).isPrimary ? tvwTree.ImageList.Images["SdvDataMessageReceivedLog_Primary"] : tvwTree.ImageList.Images["SdvDataMessageReceivedLog_Secondary"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                {
                    return ((FSecsDeviceDataMessageSentLog)fObjectLog).isPrimary ? tvwTree.ImageList.Images["SdvDataMessageSentLog_Primary"] : tvwTree.ImageList.Images["SdvDataMessageSentLog_Secondary"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsItemLog)
                {
                    return ((FSecsItemLog)fObjectLog).fFormat == FFormat.List ? tvwTree.ImageList.Images["SecsItemLog_List"] : tvwTree.ImageList.Images["SecsItemLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataReceivedLog)
                {
                    return tvwTree.ImageList.Images["SdvDataReceivedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataSentLog)
                {
                    return tvwTree.ImageList.Images["SdvDataSentLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceSmlReceivedLog)
                {
                    return tvwTree.ImageList.Images["SdvSmlReceivedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceSmlSentLog)
                {
                    return tvwTree.ImageList.Images["SdvSmlSentLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceErrorRaisedLog)
                {
                    return tvwTree.ImageList.Images["SdvErrorRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTimeoutRaisedLog)
                {
                    return tvwTree.ImageList.Images["SdvTimeoutRaisedLog"];
                }
                // ***
                // HostDevice
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                {
                    fDeviceState = ((FHostDeviceStateChangedLog)fObjectLog).fState;
                    if (fDeviceState == FDeviceState.Opened)
                    {
                        return tvwTree.ImageList.Images["HdvStateChangedLog_Opened"];
                    }
                    else if (fDeviceState == FDeviceState.Connected)
                    {
                        return tvwTree.ImageList.Images["HdvStateChangedLog_Connected"];
                    }
                    else if (fDeviceState == FDeviceState.Selected)
                    {
                        return tvwTree.ImageList.Images["HdvStateChangedLog_Selected"];
                    }
                    else if (fDeviceState == FDeviceState.Closed)
                    {
                        return tvwTree.ImageList.Images["HdvStateChangedLog_Closed"];
                    }
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    fHostMessageType = ((FHostDeviceDataMessageReceivedLog)fObjectLog).fHostMessageType;
                    if (fHostMessageType == FHostMessageType.Command)
                    {
                        return tvwTree.ImageList.Images["HdvDataMessageReceivedLog_Command"];
                    }
                    else if (fHostMessageType == FHostMessageType.Unsolicited)
                    {
                        return tvwTree.ImageList.Images["HdvDataMessageReceivedLog_Unsolicited"];
                    }
                    else if (fHostMessageType == FHostMessageType.Reply)
                    {
                        return tvwTree.ImageList.Images["HdvDataMessageReceivedLog_Reply"];
                    }
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    fHostMessageType = ((FHostDeviceDataMessageSentLog)fObjectLog).fHostMessageType;
                    if (fHostMessageType == FHostMessageType.Command)
                    {
                        return tvwTree.ImageList.Images["HdvDataMessageSentLog_Command"];
                    }
                    else if (fHostMessageType == FHostMessageType.Unsolicited)
                    {
                        return tvwTree.ImageList.Images["HdvDataMessageSentLog_Unsolicited"];
                    }
                    else if (fHostMessageType == FHostMessageType.Reply)
                    {
                        return tvwTree.ImageList.Images["HdvDataMessageSentLog_Reply"];
                    }
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostItemLog)
                {
                    return ((FHostItemLog)fObjectLog).fFormat == FFormat.List ? tvwTree.ImageList.Images["HostItemLog_List"] : tvwTree.ImageList.Images["HostItemLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiReceivedLog)
                {
                    return tvwTree.ImageList.Images["HdvVfeiReceivedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiSentLog)
                {
                    return tvwTree.ImageList.Images["HdvVfeiSentLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceErrorRaisedLog)
                {
                    return tvwTree.ImageList.Images["HdvErrorRaisedLog"];
                }
                // ***
                // Scenario
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsTriggerRaisedLog)
                {
                    return tvwTree.ImageList.Images["SecsTriggerRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsTransmitterRaisedLog)
                {
                    return tvwTree.ImageList.Images["SecsTransmitterRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTriggerRaisedLog)
                {
                    return tvwTree.ImageList.Images["HostTriggerRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTransmitterRaisedLog)
                {
                    return tvwTree.ImageList.Images["HostTransmitterRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.JudgementPerformedLog)
                {
                    return tvwTree.ImageList.Images["JudgementPerformedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.MapperPerformedLog)
                {
                    return tvwTree.ImageList.Images["MapperPerformedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                {
                    return tvwTree.ImageList.Images["EquipmentStateSetAltererPerformedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateAltererLog)
                {
                    return tvwTree.ImageList.Images["EquipmentStateAltererLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.DataSetLog)
                {
                    return tvwTree.ImageList.Images["DataSetLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.DataLog)
                {
                    return ((FDataLog)fObjectLog).fFormat == FFormat.List ? tvwTree.ImageList.Images["DataLog_List"] : tvwTree.ImageList.Images["DataLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.StoragePerformedLog)
                {
                    return tvwTree.ImageList.Images["StoragePerformedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.RepositoryLog)
                {
                    return tvwTree.ImageList.Images["RepositoryLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.ColumnLog)
                {
                    return ((FColumnLog)fObjectLog).fFormat == FFormat.List ? tvwTree.ImageList.Images["ColumnLog_List"] : tvwTree.ImageList.Images["ColumnLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CallbackRaisedLog)
                {
                    return tvwTree.ImageList.Images["CallbackRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.BranchRaisedLog)
                {
                    return tvwTree.ImageList.Images["BranchRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.FunctionCalledLog)
                {
                    return tvwTree.ImageList.Images["FunctionCalledLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CommentWrittenLog)
                {
                    return tvwTree.ImageList.Images["CommentWritedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PauserRaisedLog)
                {
                    return tvwTree.ImageList.Images["PauserRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EntryPointCalledLog)
                {
                    return tvwTree.ImageList.Images["EntryPointCalledLog"];
                }
                // ***
                // Application
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                {
                    return tvwTree.ImageList.Images["ApplicationWritedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.ContentLog)
                {
                    return ((FContentLog)fObjectLog).fFormat == FFormat.List ? tvwTree.ImageList.Images["ContentLog_List"] : tvwTree.ImageList.Images["ContentLog"];
                }

                // --

                return null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FResultCode getResultCode(
            FIObjectLog fObjectLog
            )
        {
            FResultCode fResultCode = FResultCode.Success;

            try
            {
                // ***
                // SecsDevice
                // ***
                if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceStateChangedLog)
                {
                    fResultCode = ((FSecsDeviceStateChangedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceControlMessageReceivedLog)
                {
                    fResultCode = ((FSecsDeviceControlMessageReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceControlMessageSentLog)
                {
                    fResultCode = ((FSecsDeviceControlMessageSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketReceivedLog)
                {
                    fResultCode = ((FSecsDeviceTelnetPacketReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketSentLog)
                {
                    fResultCode = ((FSecsDeviceTelnetPacketSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetStateChangedLog)
                {
                    fResultCode = ((FSecsDeviceTelnetStateChangedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceHandshakeReceivedLog)
                {
                    fResultCode = ((FSecsDeviceHandshakeReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceHandshakeSentLog)
                {
                    fResultCode = ((FSecsDeviceHandshakeSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceBlockReceivedLog)
                {
                    fResultCode = ((FSecsDeviceBlockReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceBlockSentLog)
                {
                    fResultCode = ((FSecsDeviceBlockSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                {
                    fResultCode = ((FSecsDeviceDataMessageReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                {
                    fResultCode = ((FSecsDeviceDataMessageSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataReceivedLog)
                {
                    fResultCode = ((FSecsDeviceDataReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataSentLog)
                {
                    fResultCode = ((FSecsDeviceDataSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceSmlReceivedLog)
                {
                    fResultCode = ((FSecsDeviceSmlReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceSmlSentLog)
                {
                    fResultCode = ((FSecsDeviceSmlSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceErrorRaisedLog)
                {
                    fResultCode = ((FSecsDeviceErrorRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTimeoutRaisedLog)
                {
                    fResultCode = ((FSecsDeviceTimeoutRaisedLog)fObjectLog).fResultCode;
                }
                // ***
                // HostDevice
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                {
                    fResultCode = ((FHostDeviceStateChangedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    fResultCode = ((FHostDeviceDataMessageReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    fResultCode = ((FHostDeviceDataMessageSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiReceivedLog)
                {
                    fResultCode = ((FHostDeviceVfeiReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiSentLog)
                {
                    fResultCode = ((FHostDeviceVfeiSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceErrorRaisedLog)
                {
                    fResultCode = ((FHostDeviceErrorRaisedLog)fObjectLog).fResultCode;
                }
                // ***
                // Scenario
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsTriggerRaisedLog)
                {
                    fResultCode = ((FSecsTriggerRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsTransmitterRaisedLog)
                {
                    fResultCode = ((FSecsTransmitterRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTriggerRaisedLog)
                {
                    fResultCode = ((FHostTriggerRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTransmitterRaisedLog)
                {
                    fResultCode = ((FHostTransmitterRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.JudgementPerformedLog)
                {
                    fResultCode = ((FJudgementPerformedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.MapperPerformedLog)
                {
                    fResultCode = ((FMapperPerformedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                {
                    fResultCode = ((FEquipmentStateSetAltererPerformedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.StoragePerformedLog)
                {
                    fResultCode = ((FStoragePerformedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CallbackRaisedLog)
                {
                    fResultCode = ((FCallbackRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.BranchRaisedLog)
                {
                    fResultCode = ((FBranchRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.FunctionCalledLog)
                {
                    fResultCode = ((FFunctionCalledLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CommentWrittenLog)
                {
                    fResultCode = ((FCommentWrittenLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PauserRaisedLog)
                {
                    fResultCode = ((FPauserRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EntryPointCalledLog)
                {
                    fResultCode = ((FEntryPointCalledLog)fObjectLog).fResultCode;
                }
                // ***
                // Application
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                {
                    fResultCode = ((FApplicationWrittenLog)fObjectLog).fResultCode;
                }

                // --

                return fResultCode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FResultCode.Success;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static Image getImageOfServer(
            FGrid grid,
            string upDown,
            string status,
            string alarm
            )
        {
            try
            {
                if (status == FServerStatusEnum.Main.ToString())
                {
                    if (upDown == FUpDown.Down.ToString())
                    {
                        return grid.ImageList.Images["Server_Main_Down"];
                    }
                    else if (alarm == FYesNo.Yes.ToString())
                    {
                        return grid.ImageList.Images["Server_Main_Alarm"];
                    }
                    else
                    {
                        return grid.ImageList.Images["Server_Main_Up"];
                    }
                }
                else
                {
                    if (upDown == FUpDown.Down.ToString())
                    {
                        return grid.ImageList.Images["Server_Backup_Down"];
                    }
                    else if (alarm == FYesNo.Yes.ToString())
                    {
                        return grid.ImageList.Images["Server_Backup_Alarm"];
                    }
                    else
                    {
                        return grid.ImageList.Images["Server_Backup_Up"];
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------   

        public static Image getImageOfPackage(
            FGrid grid,
            string eapType
            )
        {
            try
            {
                if (eapType == FEapType.SECS.ToString() || eapType == FEapType.FILE.ToString())
                {
                    return grid.ImageList.Images["Package_Secs"];
                }
                //else if (eapType == FEapType.PLC.ToString())
                //{
                //    return grid.ImageList.Images["Package_Plc"];
                //}
                else if (eapType == FEapType.OPC.ToString() || eapType == FEapType.CHD.ToString())
                {
                    return grid.ImageList.Images["Package_Opc"];
                }
                else if (eapType == FEapType.TCP.ToString())
                {
                    return grid.ImageList.Images["Package_Tcp"];
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return grid.ImageList.Images["Package"]; 
        }

        //------------------------------------------------------------------------------------------------------------------------   

        public static Image getImageOfPackageVersion(
            FGrid grid,
            string eapType
            )
        {
            try
            {
                if (eapType == FEapType.SECS.ToString() && eapType == FEapType.FILE.ToString())
                {
                    return grid.ImageList.Images["PackageVersion_Secs"];
                }
                //else if (eapType == FEapType.PLC.ToString())
                //{
                //    return grid.ImageList.Images["PackageVersion_Plc"];
                //}
                else if (eapType == FEapType.OPC.ToString() || eapType == FEapType.CHD.ToString())
                {
                    return grid.ImageList.Images["PackageVersion_Opc"];
                }
                else if (eapType == FEapType.TCP.ToString())
                {
                    return grid.ImageList.Images["PackageVersion_Tcp"];
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return grid.ImageList.Images["PackageVersion"];
        }

        //------------------------------------------------------------------------------------------------------------------------   

        public static Image getImageOfModel(
            FGrid grid,
            string eapType
            )
        {
            try
            {
                if (eapType == FEapType.SECS.ToString())
                {
                    return grid.ImageList.Images["Model_Secs"];
                }
                //else if (eapType == FEapType.PLC.ToString())
                //{
                //    return grid.ImageList.Images["Model_Plc"];
                //}
                else if (eapType == FEapType.OPC.ToString() || eapType == FEapType.CHD.ToString())
                {
                    return grid.ImageList.Images["Model_Opc"];
                }
                else if (eapType == FEapType.TCP.ToString())
                {
                    return grid.ImageList.Images["Model_Tcp"];
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return grid.ImageList.Images["Model"];
        }

        //------------------------------------------------------------------------------------------------------------------------   

        public static Image getImageOfModelVersion(
            FGrid grid,
            string eapType
            )
        {
            try
            {
                if (eapType == FEapType.SECS.ToString())
                {
                    return grid.ImageList.Images["ModelVersion_Secs"];
                }
                //else if (eapType == FEapType.PLC.ToString())
                //{
                //    return grid.ImageList.Images["ModelVersion_Plc"];
                //}
                else if (eapType == FEapType.OPC.ToString() || eapType == FEapType.CHD.ToString())
                {
                    return grid.ImageList.Images["ModelVersion_Opc"];
                }
                else if (eapType == FEapType.TCP.ToString())
                {
                    return grid.ImageList.Images["ModelVersion_Tcp"];
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return grid.ImageList.Images["ModelVersion"];
        }

        //------------------------------------------------------------------------------------------------------------------------   

        public static Image getImageOfComponent(
            FGrid grid,
            string eapType
            )
        {
            try
            {
                if (eapType == FEapType.SECS.ToString() || eapType == FEapType.FILE.ToString())
                {
                    return grid.ImageList.Images["Component_Secs"];
                }
                //else if (eapType == FEapType.PLC.ToString())
                //{
                //    return grid.ImageList.Images["Component_Plc"];
                //}
                else if (eapType == FEapType.OPC.ToString() || eapType == FEapType.CHD.ToString())
                {
                    return grid.ImageList.Images["Component_Opc"];
                }
                else if (eapType == FEapType.TCP.ToString())
                {
                    return grid.ImageList.Images["Component_Tcp"];
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return grid.ImageList.Images["Component"];
        }

        //------------------------------------------------------------------------------------------------------------------------   

        public static Image getImageOfComponentVersion(
            FGrid grid,
            string eapType
            )
        {
            try
            {
                if (eapType == FEapType.SECS.ToString())
                {
                    return grid.ImageList.Images["ComponentVersion_Secs"];
                }
                //else if (eapType == FEapType.PLC.ToString())
                //{
                //    return grid.ImageList.Images["ComponentVersion_Plc"];
                //}
                else if (eapType == FEapType.OPC.ToString() || eapType == FEapType.CHD.ToString())
                {
                    return grid.ImageList.Images["ComponentVersion_Opc"];
                }
                else if (eapType == FEapType.TCP.ToString())
                {
                    return grid.ImageList.Images["ComponentVersion_Tcp"];
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return grid.ImageList.Images["ComponentVersion"];
        }

        //------------------------------------------------------------------------------------------------------------------------   

        public static Image getImageOfEap(
            FGrid grid,
            string eapType
            )
        {
            try
            {
                if (eapType == FEapType.SECS.ToString() || eapType == FEapType.FILE.ToString())
                {
                    return grid.ImageList.Images["Eap_Secs"];
                }
                //else if (eapType == FEapType.PLC.ToString())
                //{
                //    return grid.ImageList.Images["Eap_Plc"];
                //}
                else if (eapType == FEapType.OPC.ToString() || eapType == FEapType.CHD.ToString())
                {
                    return grid.ImageList.Images["Eap_Opc"];
                }
                else if (eapType == FEapType.Process.ToString())
                {
                    return grid.ImageList.Images["Eap_Process"];
                }
                else if (eapType == FEapType.TCP.ToString())
                {
                    return grid.ImageList.Images["Eap_Tcp"];
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return grid.ImageList.Images["Eap"];
        }

        //------------------------------------------------------------------------------------------------------------------------   

        public static Image getImageOfEap(
            FGrid grid,
            string eapType,
            string eapUpDown,
            string eapStatus,
            string eapAlarm
            )
        {
            try
            {
                if (eapType == FEapType.SECS.ToString() || eapType == FEapType.FILE.ToString())
                {
                    if (eapStatus == FEapStatusEnum.Main.ToString())
                    {
                        if (eapUpDown == FUpDown.Down.ToString())
                        {
                            return grid.ImageList.Images["Eap_Secs_Main_Down"];
                        }
                        else if (eapAlarm == FYesNo.Yes.ToString())
                        {
                            return grid.ImageList.Images["Eap_Secs_Main_Alarm"];
                        }
                        else
                        {
                            return grid.ImageList.Images["Eap_Secs_Main_Up"];
                        }
                    }
                    else if (eapStatus == FEapStatusEnum.Backup.ToString())
                    {
                        if (eapUpDown == FUpDown.Down.ToString())
                        {
                            return grid.ImageList.Images["Eap_Secs_Backup_Down"];
                        }
                        else if (eapAlarm == FYesNo.Yes.ToString())
                        {
                            return grid.ImageList.Images["Eap_Secs_Backup_Alarm"];
                        }
                        else
                        {
                            return grid.ImageList.Images["Eap_Secs_Backup_Up"];
                        }
                    }
                }
                //else if (eapType == FEapType.PLC.ToString())
                //{
                //    if (eapStatus == FEapStatusEnum.Main.ToString())
                //    {
                //        if (eapUpDown == FUpDown.Down.ToString())
                //        {
                //            return grid.ImageList.Images["Eap_Plc_Main_Down"];
                //        }
                //        else if (eapAlarm == FYesNo.Yes.ToString())
                //        {
                //            return grid.ImageList.Images["Eap_Plc_Main_Alarm"];
                //        }
                //        else
                //        {
                //            return grid.ImageList.Images["Eap_Plc_Main_Up"];
                //        }
                //    }
                //    else if (eapStatus == FEapStatusEnum.Backup.ToString())
                //    {
                //        if (eapUpDown == FUpDown.Down.ToString())
                //        {
                //            return grid.ImageList.Images["Eap_Plc_Backup_Down"];
                //        }
                //        else if (eapAlarm == FYesNo.Yes.ToString())
                //        {
                //            return grid.ImageList.Images["Eap_Plc_Backup_Alarm"];
                //        }
                //        else
                //        {
                //            return grid.ImageList.Images["Eap_Plc_Backup_Up"];
                //        }
                //    }
                //}
                else if (eapType == FEapType.OPC.ToString() || eapType == FEapType.CHD.ToString())
                {
                    if (eapStatus == FEapStatusEnum.Main.ToString())
                    {
                        if (eapUpDown == FUpDown.Down.ToString())
                        {
                            return grid.ImageList.Images["Eap_Opc_Main_Down"];
                        }
                        else if (eapAlarm == FYesNo.Yes.ToString())
                        {
                            return grid.ImageList.Images["Eap_Opc_Main_Alarm"];
                        }
                        else
                        {
                            return grid.ImageList.Images["Eap_Opc_Main_Up"];
                        }
                    }
                    else if (eapStatus == FEapStatusEnum.Backup.ToString())
                    {
                        if (eapUpDown == FUpDown.Down.ToString())
                        {
                            return grid.ImageList.Images["Eap_Opc_Backup_Down"];
                        }
                        else if (eapAlarm == FYesNo.Yes.ToString())
                        {
                            return grid.ImageList.Images["Eap_Opc_Backup_Alarm"];
                        }
                        else
                        {
                            return grid.ImageList.Images["Eap_Opc_Backup_Up"];
                        }
                    }
                }
                else if (eapType == FEapType.Process.ToString())
                {
                    if (eapStatus == FEapStatusEnum.Main.ToString())
                    {
                        if (eapUpDown == FUpDown.Down.ToString())
                        {
                            return grid.ImageList.Images["Eap_Process_Main_Down"];
                        }
                        else if (eapAlarm == FYesNo.Yes.ToString())
                        {
                            return grid.ImageList.Images["Eap_Process_Main_Alarm"];
                        }
                        else
                        {
                            return grid.ImageList.Images["Eap_Process_Main_Up"];
                        }
                    }
                    else if (eapStatus == FEapStatusEnum.Backup.ToString())
                    {
                        if (eapUpDown == FUpDown.Down.ToString())
                        {
                            return grid.ImageList.Images["Eap_Process_Backup_Down"];
                        }
                        else if (eapAlarm == FYesNo.Yes.ToString())
                        {
                            return grid.ImageList.Images["Eap_Process_Backup_Alarm"];
                        }
                        else
                        {
                            return grid.ImageList.Images["Eap_Process_Backup_Up"];
                        }
                    }
                }
                else if (eapType == FEapType.TCP.ToString())
                {
                    if (eapStatus == FEapStatusEnum.Main.ToString())
                    {
                        if (eapUpDown == FUpDown.Down.ToString())
                        {
                            return grid.ImageList.Images["Eap_Tcp_Main_Down"];
                        }
                        else if (eapAlarm == FYesNo.Yes.ToString())
                        {
                            return grid.ImageList.Images["Eap_Tcp_Main_Alarm"];
                        }
                        else
                        {
                            return grid.ImageList.Images["Eap_Tcp_Main_Up"];
                        }
                    }
                    else if (eapStatus == FEapStatusEnum.Backup.ToString())
                    {
                        if (eapUpDown == FUpDown.Down.ToString())
                        {
                            return grid.ImageList.Images["Eap_Tcp_Backup_Down"];
                        }
                        else if (eapAlarm == FYesNo.Yes.ToString())
                        {
                            return grid.ImageList.Images["Eap_Tcp_Backup_Alarm"];
                        }
                        else
                        {
                            return grid.ImageList.Images["Eap_Tcp_Backup_Up"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------   

        public static Image getImageOfEquipment(
            FGrid grid,
            string controlMode
            )
        {
            try
            {
                if (controlMode == FEquipmentControlMode.OnlineRemote.ToString())
                {
                    return grid.ImageList.Images["Equipment_OnlineRemote"];
                }
                else if (controlMode == FEquipmentControlMode.OnlineLocal.ToString())
                {
                    return grid.ImageList.Images["Equipment_OnlineLocal"];
                }
                else if (controlMode == FEquipmentControlMode.Offline.ToString())
                {
                    return grid.ImageList.Images["Equipment_Offline"];
                }
                else
                {
                    return grid.ImageList.Images["Equipment_Unknown"];
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------   

        public static void deleteDirectory(
           string path
           )
        {
            try
            {
                if (path != string.Empty && Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void deleteFile(
            string fileName
            )
        {
            try
            {
                if (fileName != string.Empty && File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static List<string[]> generateRequestTimes(
            DateTime fromTime,
            DateTime toTime
            )
        {
            List<string[]> lstReqTimes = null;
            DateTime tmpTime = DateTime.Now;
            
            try
            {
                lstReqTimes = new List<string[]>();

                // --

                tmpTime = toTime.Subtract(fromTime).TotalMilliseconds > FConstants.HistorySearchPeriod ? fromTime.AddMilliseconds(FConstants.HistorySearchPeriod) : toTime;
                // --

                do
                {
                    lstReqTimes.Add(new string[] { fromTime.ToString("yyyyMMddHHmmssfff"), tmpTime.ToString("yyyyMMddHHmmssfff") });
                    // --

                    fromTime = tmpTime.AddMilliseconds(1);
                    tmpTime = toTime.Subtract(fromTime).TotalMilliseconds > FConstants.HistorySearchPeriod ? fromTime.AddMilliseconds(FConstants.HistorySearchPeriod) : toTime;

                } while (toTime.Subtract(fromTime).TotalMilliseconds >= 0);

                // --

                return lstReqTimes;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                lstReqTimes = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static DateTime convertStringToDateTime(
            string strDateTime
            )
        {
            try
            {
                if (strDateTime.Trim() == string.Empty)
                {
                    return DateTime.Now;
                }

                return new DateTime(
                    int.Parse(strDateTime.Substring(0, 4)),         // Year
                    int.Parse(strDateTime.Substring(4, 2)),         // Month
                    int.Parse(strDateTime.Substring(6, 2)),         // Day
                    int.Parse(strDateTime.Substring(8, 2)),         // Hour
                    int.Parse(strDateTime.Substring(10, 2)),        // Minuth
                    int.Parse(strDateTime.Substring(12, 2)),        // Second
                    int.Parse(strDateTime.Substring(14, 3))         // Millisecond
                    );
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
            return DateTime.Now;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string[] getGridColumnList(
            FGrid grid,
            string columName
            )
        {

            string[] stringValues = new string[grid.selectedDataRows.Length];
            int i = 0;
            try
            {
                foreach (Infragistics.Win.UltraWinDataSource.UltraDataRow dataRow in grid.selectedDataRows)
                {
                    stringValues[i] = (string)dataRow.GetCellValue(columName);
                    i++;
                }

                return stringValues;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return stringValues;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string convertDesktopAlertString(
            string oldValue
            )
        {
            string newValue = string.Empty;

            try
            {
                newValue = oldValue.Replace("&", "&amp;");
                newValue = newValue.Replace("<", "&lt;");
                newValue = newValue.Replace(">", "&gt;");
                newValue = newValue.Replace("'", "&apos;");
                newValue = newValue.Replace("\"", "&quot;");
                // --
                return newValue;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return string.Empty;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Generate String

        public static string generateStringForPackage(
            string package,
            string ver
            )
        {
            try
            {
                if (
                    package.Trim() == string.Empty || 
                    package == "N/A"
                   )
                {
                    return "N/A";
                }

                // --

                return string.Format("{0} [ver. {1}]", package, ver);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string generateStringForModel(
            string model,
            string ver
            )
        {
            try
            {
                if (
                    model.Trim() == string.Empty ||
                    model == "N/A"
                   )
                {
                    return "N/A";
                }

                // --

                return string.Format("{0} [ver. {1}]", model, ver);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string generateStringForComponent(
            string used,
            string component,
            string ver
            )
        {
            try
            {
                if (
                    used.Trim() == string.Empty ||
                    used == "N/A" 
                   )
                {
                    return "N/A";
                }

                // --

                if (used == FYesNo.Yes.ToString())
                {
                    return string.Format("({0}) {1} [ver. {2}]", used, component, ver);
                }
                else
                {
                    return string.Format("({0})", used);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string generatePackageForString(
            string package
            )
        {
            try
            {
                if (
                    package.Trim() == string.Empty ||
                    package == "N/A"                    
                    )
                {
                    return string.Empty;
                }

                // --
                
                return package.Split(' ')[0].Trim();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string generateModelForString(
            string model
            )
        {
            try
            {
                if(
                    model.Trim() == string.Empty ||
                    model == "N/A"
                    )
                {
                    return string.Empty;
                }

                // --

                return model.Split(' ')[0].Trim();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string generateComponentForString(
            string component
            )
        {
            try
            {
                if (
                    component.Trim() == string.Empty ||
                    component == "N/A"
                    )
                {
                    return string.Empty;
                }

                // --
                
                return component.Split(' ')[1].Trim();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return string.Empty;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Design Grid Cell

        public static void designGridCellForEapNeedAction(
            UltraGridCell cell
            )
        {
            try
            {
                if (cell.Text.Trim() != string.Empty)
                {
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void designGridCellForEapNextNeedAction(
            UltraGridCell cell
            )
        {
            try
            {
                if (cell.Text.Trim() != string.Empty)
                {
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void designGridCellForEap(
            UltraGridCell cell
            )
        {
            try
            {
                if (cell.Text == "N/A")
                {
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void designGridCellForEapServer(
            UltraGridCell cell
            )
        {
            try
            {
                if (cell.Text == "N/A")
                {
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void designGridCellForEapUpDown(
            UltraGridCell cell
            )
        {
            try
            {
                if (cell.Text == FUpDown.Up.ToString())
                {
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                    cell.Appearance.ForeColor = Color.Black;
                } 
                else 
                {
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void designGridCellForEapStatus(
            UltraGridCell cell
            )
        {
            try
            {
                if (cell.Text == FEapStatusEnum.Main.ToString())
                {
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                    cell.Appearance.ForeColor = Color.Black;
                }
                else
                {
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void designGridCellForEapStep(
            UltraGridCell cell
            )
        {
            try
            {
                if (cell.Text == FEapAttrCategory.Applied.ToString())
                {
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                    cell.Appearance.ForeColor = Color.Black;
                }
                else
                {
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void designGridCellForEapPackage(
            UltraGridCell cell
            )
        {
            try
            {
                if (cell.Text == "N/A")
                {
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void designGridCellForEapModel(
            UltraGridCell cell
            )
        {
            try
            {
                if (cell.Text == "N/A")
                {
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void designGridCellForEapComponent(
            UltraGridCell cell
            )
        {
            try
            {
                if (cell.Text == "N/A")
                {
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void designGridCellForEditButton(
            UltraGridCell cell
            )
        {
            try
            {
                if (cell.Text != string.Empty)
                {
                    cell.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
 
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void designGridCellForControlMode(
            UltraGridCell cell
            )
        {
            try
            {
                if (cell.Text == "Offline")
                {
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Red;
                }
                else
                {
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                    cell.Appearance.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void designGridCellForNotApplicable(
            UltraGridCell cell
            )
        {
            try
            {
                if (cell.Text == "N/A")
                {
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Common EAP Schema Search Methods

        public static Image getImageOfEapDriver(
            FTreeView tvwTree,
            FXmlNode fXmlNode
            )
        {
            string type = string.Empty;

            try
            {
                if (fXmlNode.name == FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.E_SecsDriver)
                {
                    type = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.A_EapType,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.D_EapType
                        );
                    // --
                    if (type == FEapType.SECS.ToString())
                    {
                        return tvwTree.ImageList.Images["SecsDriver"];
                    }
                    //else if (type == FEapType.PLC.ToString())
                    //{
                    //    return tvwTree.ImageList.Images["PlcDriver"];
                    //}
                    else if (type == FEapType.OPC.ToString() || type == FEapType.CHD.ToString())
                    {
                        return tvwTree.ImageList.Images["OpcDriver"];
                    }
                    else if (type == FEapType.TCP.ToString())
                    {
                        return tvwTree.ImageList.Images["TcpDriver"];
                    }
                    else if (type == FEapType.FILE.ToString())
                    {
                        return tvwTree.ImageList.Images["FileDriver"];
                    }

                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static Image getImageOfEapSchemaSecsDevice(
            FTreeView tvwTree, 
            FXmlNode fXmlNode
            )
        {
            string type = string.Empty;
            string state = string.Empty;

            try
            {
                if (fXmlNode.name == FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.E_SecsDevice)
                {
                    type = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_EapType,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_EapType
                        );
                    state = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_State,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_State
                        );
                    // --
                    if (type == FEapType.SECS.ToString())
                    {
                        if (state == FDeviceState.Opened.ToString())
                        {
                            return tvwTree.ImageList.Images["SecsDevice_Opened"];
                        }
                        else if (state == FDeviceState.Connected.ToString())
                        {
                            return tvwTree.ImageList.Images["SecsDevice_Connected"];
                        }
                        else if (state == FDeviceState.Selected.ToString())
                        {
                            return tvwTree.ImageList.Images["SecsDevice_Selected"];
                        }
                        else if (state == FDeviceState.Closed.ToString())
                        {
                            return tvwTree.ImageList.Images["SecsDevice_Closed"];
                        }
                        else
                        {
                            return tvwTree.ImageList.Images["SecsDevice_Unknown"];
                        }
                    }
                    //else if (type == FEapType.PLC.ToString())
                    //{
                    //    if (state == FDeviceState.Opened.ToString())
                    //    {
                    //        return tvwTree.ImageList.Images["PlcDevice_Opened"];
                    //    }
                    //    else if (state == FDeviceState.Connected.ToString())
                    //    {
                    //        return tvwTree.ImageList.Images["PlcDevice_Connected"];
                    //    }
                    //    else if (state == FDeviceState.Selected.ToString())
                    //    {
                    //        return tvwTree.ImageList.Images["PlcDevice_Selected"];
                    //    }
                    //    else if (state == FDeviceState.Closed.ToString())
                    //    {
                    //        return tvwTree.ImageList.Images["PlcDevice_Closed"];
                    //    }
                    //    else
                    //    {
                    //        return tvwTree.ImageList.Images["PlcDevice_Unknown"];
                    //    }
                    //}
                    else if (type == FEapType.OPC.ToString())
                    {
                        if (state == FDeviceState.Opened.ToString())
                        {
                            return tvwTree.ImageList.Images["OpcDevice_Opened"];
                        }
                        else if (state == FDeviceState.Connected.ToString())
                        {
                            return tvwTree.ImageList.Images["OpcDevice_Connected"];
                        }
                        else if (state == FDeviceState.Selected.ToString())
                        {
                            return tvwTree.ImageList.Images["OpcDevice_Selected"];
                        }
                        else if (state == FDeviceState.Closed.ToString())
                        {
                            return tvwTree.ImageList.Images["OpcDevice_Closed"];
                        }
                        else if (
                            state == Nexplant.MC.Core.FaOpcDriver.FDeviceState.ErrorShutdown.ToString() ||
                            state == Nexplant.MC.Core.FaOpcDriver.FDeviceState.ErrorWatchDog.ToString() ||
                            state == Nexplant.MC.Core.FaOpcDriver.FDeviceState.Undefined.ToString()
                            )
                        {
                            return tvwTree.ImageList.Images["OpcDevice_Error"];
                        }
                        else
                        {
                            return tvwTree.ImageList.Images["OpcDevice_Unknown"];
                        }
                    }
                    else if (type == FEapType.TCP.ToString())
                    {
                        if (state == FDeviceState.Opened.ToString())
                        {
                            return tvwTree.ImageList.Images["TcpDevice_Opened"];
                        }
                        else if (state == FDeviceState.Connected.ToString())
                        {
                            return tvwTree.ImageList.Images["TcpDevice_Connected"];
                        }
                        else if (state == FDeviceState.Selected.ToString())
                        {
                            return tvwTree.ImageList.Images["TcpDevice_Selected"];
                        }
                        else if (state == FDeviceState.Closed.ToString())
                        {
                            return tvwTree.ImageList.Images["TcpDevice_Closed"];
                        }
                        else
                        {
                            return tvwTree.ImageList.Images["TcpDevice_Unknown"];
                        }
                    }
                    else if (type == FEapType.FILE.ToString())
                    {
                        if (state == FDeviceState.Opened.ToString())
                        {
                            return tvwTree.ImageList.Images["FileDevice_Opened"];
                        }
                        else if (state == FDeviceState.Connected.ToString())
                        {
                            return tvwTree.ImageList.Images["FileDevice_Connected"];
                        }
                        else if (state == FDeviceState.Selected.ToString())
                        {
                            return tvwTree.ImageList.Images["FileDevice_Selected"];
                        }
                        else if (state == FDeviceState.Closed.ToString())
                        {
                            return tvwTree.ImageList.Images["FileDevice_Closed"];
                        }
                        else
                        {
                            return tvwTree.ImageList.Images["FileDevice_Unknown"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static Image getImageOfEapSchemaHostDevice(
            FTreeView tvwTree,
            FXmlNode fXmlNode
            )
        {
            string state = string.Empty;

            try
            {
                if (fXmlNode.name == FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.E_HostDevice)
                {
                    state = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_State,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_State
                        );
                    // --
                    if (state == FDeviceState.Opened.ToString())
                    {
                        return tvwTree.ImageList.Images["HostDevice_Opened"];
                    }
                    else if (state == FDeviceState.Connected.ToString())
                    {
                        return tvwTree.ImageList.Images["HostDevice_Connected"];
                    }
                    else if (state == FDeviceState.Selected.ToString())
                    {
                        return tvwTree.ImageList.Images["HostDevice_Selected"];
                    }
                    else if (state == FDeviceState.Closed.ToString())
                    {
                        return tvwTree.ImageList.Images["HostDevice_Closed"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["HostDevice_Unknown"];
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static Image getImageOfEapSession(
            FTreeView tvwTree,
            FXmlNode fXmlNode
            )
        {
            string type = string.Empty;

            try
            {
                if (fXmlNode.name == FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.E_SecsSession)
                {
                    type = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_EapType,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_EapType
                        );
                    // --
                    if (type == FEapType.SECS.ToString())
                    {
                        return tvwTree.ImageList.Images["SecsSession"];
                    }
                    //else if (type == FEapType.PLC.ToString())
                    //{
                    //    return tvwTree.ImageList.Images["PlcSession"];
                    //}
                    else if (type == FEapType.OPC.ToString())
                    {
                        return tvwTree.ImageList.Images["OpcSession"];
                    }
                    else if (type == FEapType.TCP.ToString())
                    {
                        return tvwTree.ImageList.Images["TcpSession"];
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static Image getImageOfEapSchemaEquipment(
            FTreeView tvwTree,
            FXmlNode fXmlNode
            )
        {
            string ctrlMode = string.Empty;

            try
            {
                if (fXmlNode.name == FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.E_Equipment)
                {
                    ctrlMode = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.A_ControlMode,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.D_ControlMode
                        );
                    // --
                   
                    if (ctrlMode == FEquipmentControlMode.OnlineRemote.ToString())
                    {
                        return tvwTree.ImageList.Images["Equipment_OnlineRemote"];
                    }
                    else if (ctrlMode == FEquipmentControlMode.OnlineLocal.ToString())
                    {
                        return tvwTree.ImageList.Images["Equipment_OnlineLocal"];
                    }
                    else if (ctrlMode == FEquipmentControlMode.Offline.ToString())
                    {
                        return tvwTree.ImageList.Images["Equipment_Offline"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["Equipment_Unknown"];
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------   

        public static Image getImageOfEapSchemaEnvironment(
            FTreeView tvwTree, 
            FXmlNode fXmlNode
            )
        {
            FFormat fFormat;

            try
            {
                fFormat = (FFormat)Enum.Parse(typeof(FFormat), fXmlNode.get_elemVal(
                   FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Format,
                   FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Format
                   ));
                // --
                if (fFormat == FFormat.List)
                {
                    return tvwTree.ImageList.Images["Environment_List"];
                }
                else
                {
                    return tvwTree.ImageList.Images["Environment"];
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode refreshEapSchema(
            FAdmCore fAdmCore,
            string eap,
            string category
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEap = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                if (eap == string.Empty || eap == "N/A")
                {
                    return null;
                }
                
                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_ComEapSchemaSearch_In.E_ADMADS_ComEapSchemaSearch_In);
                fXmlNodeIn.set_elemVal(FADMADS_ComEapSchemaSearch_In.A_hLanguage, FADMADS_ComEapSchemaSearch_In.D_hLanguage, fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_ComEapSchemaSearch_In.A_hFactory, FADMADS_ComEapSchemaSearch_In.D_hFactory, fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_ComEapSchemaSearch_In.A_hUserId, FADMADS_ComEapSchemaSearch_In.D_hUserId, fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_ComEapSchemaSearch_In.A_hStep, FADMADS_ComEapSchemaSearch_In.D_hStep, "1");
                // --
                fXmlNodeInEap = fXmlNodeIn.set_elem(FADMADS_ComEapSchemaSearch_In.FEap.E_Eap);
                fXmlNodeInEap.set_elemVal(FADMADS_ComEapSchemaSearch_In.FEap.A_Name, FADMADS_ComEapSchemaSearch_In.FEap.D_Name, eap);
                fXmlNodeInEap.set_elemVal(FADMADS_ComEapSchemaSearch_In.FEap.A_Category, FADMADS_ComEapSchemaSearch_In.FEap.D_Category, category);

                // --

                FADMADSCaster.ADMADS_ComEapSchemaSearch_Req(
                    fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_ComEapSchemaSearch_Out.A_hStatus, FADMADS_ComEapSchemaSearch_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_ComEapSchemaSearch_Out.A_hStatusMessage, FADMADS_ComEapSchemaSearch_Out.D_hStatusMessage)
                        );
                }

                // --

                return fXmlNodeOut.get_elem(FADMADS_ComEapSchemaSearch_Out.FSchema.E_Schema).get_elem(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.E_SecsDriver);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInEap = null;
            }
            return null; 
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string getEapSchemaObjectText(
            FXmlNode fXmlNode
            )
        {
            string info = string.Empty;
            // --
            string name = string.Empty;
            string desc = string.Empty;
            string format = string.Empty;
            string eaptype = string.Empty;
            string value = string.Empty;
            string length = string.Empty;            
            FFormat fFormat = FFormat.Unknown;

            try
            {
                if (fXmlNode.name == FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.E_SecsDriver)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.A_Name,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.A_Description,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.D_Description
                        ).Trim();
                    // --
                    info = name;
                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }
                else if (fXmlNode.name == FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.E_SecsDevice)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Name,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Description,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Description
                        ).Trim();
                    // --
                    info = name;
                    eaptype = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_EapType,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_EapType
                        ).Trim();
                    if (eaptype != FEapType.FILE.ToString())
                    {
                        info += " Protocol=[";
                        info += fXmlNode.get_elemVal(
                            FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Protocol,
                            FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Protocol
                            ).Trim();
                        info += "]";
                        // --
                        if (desc != string.Empty)
                        {
                            info += " Desc=[" + desc + "]";
                        }
                    }
                    else
                    {
                        info += " Path=[";
                        info += fXmlNode.get_elemVal(
                            FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcUrl,
                            FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcUrl
                            ).Trim();
                        info += "]";
                    }
                    
                    // --

                    
                }
                else if (fXmlNode.name == FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.E_SecsSession)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_Name,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_Description,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_Description
                        ).Trim();
                    // --
                    info = name;
                    // --
                    info += " SessionID=[";
                    info += fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_SessionId,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_SessionId
                        ).Trim();
                    info += "]";
                    // --
                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }
                else if (fXmlNode.name == FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.E_HostDevice)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Name,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Description,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Description
                        ).Trim();
                    // --
                    info = name;

                    // --

                    eaptype = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_EapType,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_EapType
                        ).Trim();
                    // --
                    if (eaptype != FEapType.FILE.ToString())
                    {
                        info += " Driver=[";
                        info += fXmlNode.get_elemVal(
                            FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Driver,
                            FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Driver
                            ).Trim();
                        info += "]";
                        // --

                        if (desc != string.Empty)
                        {
                            info += " Desc=[" + desc + "]";

                        }
                    }
                    else
                    {
                        info += " ConnectString=[";
                        info += FCommon.ConvertFileEapHostOptionStringtoXml(
                                fXmlNode.get_elemVal(
                                    FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_DriverOption,
                                    FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_DriverOption
                                    ).Trim()).get_elemVal(
                                          FFileDriver.FHostDevice.FHostOption.A_StationConnectString,
                                          FFileDriver.FHostDevice.FHostOption.D_StationConnectString);
                        info += "]";
                    }
                }
                else if (fXmlNode.name == FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.E_HostSession)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.A_Name,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.A_Description,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.D_Description
                        ).Trim();
                    // --
                    info = name;
                    // --
                    info += " MachineID=[";
                    info += fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.A_MachineId,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.D_MachineId
                        ).Trim();
                    info += "]";
                    // --
                    info += " SessionID=[";
                    info += fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.A_SessionId,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.D_SessionId
                        ).Trim();
                    info += "]";
                    // --
                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }
                else if (fXmlNode.name == FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.E_Equipment)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.A_Name,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.A_Description,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.D_Description
                        ).Trim();
                    // --                    
                    info += name;
                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }
                else if (fXmlNode.name == FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.E_EnvironmentList)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.A_Name,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.A_Description,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.D_Description
                        ).Trim();
                    // --
                    info = name;
                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }
                else if (fXmlNode.name == FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.E_Environment)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Name,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Description,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Description
                        ).Trim();
                    format = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Format,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Format
                        ).Trim();
                    value = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Value,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Value
                        ).Trim();
                    length = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Length,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Length
                        ).Trim();
                    // --
                    fFormat = (FFormat)Enum.Parse(typeof(FFormat), format);
                    info = ((FFormatShortName)fFormat).ToString() + "[" + length + "]";
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        info += " " + name;
                    }
                    else
                    {
                        info += " " + name + "=\"" + value + "\"";
                    }
                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }

                // --

                return info;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void setPropertyOfEapSchemaObject(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FXmlNode fXmlNode
            )
        {
            try
            {
                if (fXmlNode == null)
                {
                    fPropGrid.selectedObject = null;
                    return;
                }

                // --

                if (fXmlNode.name == FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.E_SecsDriver)
                {
                    fPropGrid.selectedObject = new FPropEshScd(fAdmCore, fPropGrid, fXmlNode);
                }
                else if (fXmlNode.name == FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.E_SecsDevice)
                {
                    fPropGrid.selectedObject = new FPropEshSdv(fAdmCore, fPropGrid, fXmlNode);
                }
                else if (fXmlNode.name == FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.E_SecsSession)
                {
                    fPropGrid.selectedObject = new FPropEshSsn(fAdmCore, fPropGrid, fXmlNode);
                }
                else if (fXmlNode.name == FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.E_HostDevice)
                {
                    fPropGrid.selectedObject = new FPropEshHdv(fAdmCore, fPropGrid, fXmlNode);
                }
                else if (fXmlNode.name == FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.E_HostSession)
                {
                    fPropGrid.selectedObject = new FPropEshHsn(fAdmCore, fPropGrid, fXmlNode);
                }
                else if (fXmlNode.name == FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.E_Equipment)
                {
                    fPropGrid.selectedObject = new FPropEshEqp(fAdmCore, fPropGrid, fXmlNode);
                }
                else if (fXmlNode.name == FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.E_EnvironmentList)
                {
                    fPropGrid.selectedObject = new FPropEshEnl(fAdmCore, fPropGrid, fXmlNode);
                }
                else if (fXmlNode.name == FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.E_Environment)
                {
                    fPropGrid.selectedObject = new FPropEshEnv(fAdmCore, fPropGrid, fXmlNode);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string ConvertFileEapHostOptionXmltoString(
            FXmlNode hostDriverOption
            )
        {
            char OptionSeparator = (char)0x1E;        // Record Separator
            char OptionUnitSeparator = (char)0x1F;     // Unit Separator
            StringBuilder data = null;

            try
            {
                data = new StringBuilder();
                // --
                data.Append(
                    FFileDriver.FHostDevice.FHostOption.A_StationConnectString
                    + OptionUnitSeparator  
                    + hostDriverOption.get_elemVal(FFileDriver.FHostDevice.FHostOption.A_StationConnectString, FFileDriver.FHostDevice.FHostOption.D_StationConnectString)  
                    + OptionSeparator
                    );
                data.Append(
                    FFileDriver.FHostDevice.FHostOption.A_StationVersion
                    + OptionUnitSeparator 
                    + hostDriverOption.get_elemVal(FFileDriver.FHostDevice.FHostOption.A_StationVersion, FFileDriver.FHostDevice.FHostOption.D_StationVersion)
                    + OptionSeparator
                    );
                data.Append(
                    FFileDriver.FHostDevice.FHostOption.A_StationTimeOut
                    + OptionUnitSeparator
                    + hostDriverOption.get_elemVal(FFileDriver.FHostDevice.FHostOption.A_StationTimeOut, FFileDriver.FHostDevice.FHostOption.D_StationTimeOut)
                    + OptionSeparator
                    ) ;
                data.Append(
                    FFileDriver.FHostDevice.FHostOption.A_GuaranteedtimeOut 
                    + OptionUnitSeparator 
                    + hostDriverOption.get_elemVal(FFileDriver.FHostDevice.FHostOption.A_GuaranteedtimeOut, FFileDriver.FHostDevice.FHostOption.D_GuaranteedtimeOut)
                    + OptionSeparator
                    );
                data.Append(
                    FFileDriver.FHostDevice.FHostOption.A_MaxSpoling
                    + OptionUnitSeparator 
                    + hostDriverOption.get_elemVal(FFileDriver.FHostDevice.FHostOption.A_MaxSpoling, FFileDriver.FHostDevice.FHostOption.D_MaxSpoling)
                    + OptionSeparator);
                // --
                data.Append(
                    FFileDriver.FHostDevice.FHostOption.A_SessionId
                    + OptionUnitSeparator 
                    + hostDriverOption.get_elemVal(FFileDriver.FHostDevice.FHostOption.A_SessionId, FFileDriver.FHostDevice.FHostOption.D_SessionId)
                    + OptionSeparator
                    );
                data.Append(
                    FFileDriver.FHostDevice.FHostOption.A_ModuleName
                    + OptionUnitSeparator 
                    + hostDriverOption.get_elemVal(FFileDriver.FHostDevice.FHostOption.A_ModuleName, FFileDriver.FHostDevice.FHostOption.D_ModuleName)
                    + OptionSeparator
                    );
                data.Append(
                    FFileDriver.FHostDevice.FHostOption.A_TuneChannel
                    + OptionUnitSeparator
                    + hostDriverOption.get_elemVal(FFileDriver.FHostDevice.FHostOption.A_TuneChannel, FFileDriver.FHostDevice.FHostOption.D_TuneChannel)
                    + OptionSeparator
                    );
                data.Append(
                    FFileDriver.FHostDevice.FHostOption.A_CastChannel
                    + OptionUnitSeparator 
                    + hostDriverOption.get_elemVal(FFileDriver.FHostDevice.FHostOption.A_CastChannel, FFileDriver.FHostDevice.FHostOption.D_CastChannel)
                    + OptionSeparator
                    );
                data.Append(
                   FFileDriver.FHostDevice.FHostOption.A_ParsingType
                   + OptionUnitSeparator
                   + hostDriverOption.get_elemVal(FFileDriver.FHostDevice.FHostOption.A_ParsingType, FFileDriver.FHostDevice.FHostOption.D_ParsingType)                   
                   );
                // -

                return data.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return string.Empty;
        }
        
        //------------------------------------------------------------------------------------------------------------------------
        
        public static FXmlNode ConvertFileEapHostOptionStringtoXml(
            string hostDriverOption
            )
        {
            char OptionSeparator = (char)0x1E;        // Record Separator
            char OptionUnitSeparator = (char)0x1F;     // Unit Separator
            
            // --
            
            Dictionary<string, string> optionList = null;
            string[] optionData = null;
            string[] optionUnit = null;
            
            // --

            FXmlNode fXmlHostOption = null;
            
            try
            {
                // ***
                // Option Load
                // ***
                optionList = new Dictionary<string, string>();
                if (hostDriverOption != string.Empty)
                {
                    optionData = hostDriverOption.Split(OptionSeparator);
                    foreach (string option in optionData)
                    {
                        optionUnit = option.Split(OptionUnitSeparator);
                        optionList.Add(optionUnit[0], optionUnit[1]);
                    }

                    fXmlHostOption = createXmlNode(FFileDriver.FHostDevice.FHostOption.E_HostOption);
                    // --
                    if (optionList.ContainsKey(FFileDriver.FHostDevice.FHostOption.A_StationConnectString))
                    {
                        fXmlHostOption.set_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_StationConnectString,
                            FFileDriver.FHostDevice.FHostOption.D_StationConnectString,
                            optionList[FFileDriver.FHostDevice.FHostOption.A_StationConnectString]
                            );
                    }
                    if (optionList.ContainsKey(FFileDriver.FHostDevice.FHostOption.A_StationVersion))
                    {
                        fXmlHostOption.set_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_StationVersion,
                            FFileDriver.FHostDevice.FHostOption.D_StationVersion,
                            optionList[FFileDriver.FHostDevice.FHostOption.A_StationVersion]
                            );
                    }
                    if (optionList.ContainsKey(FFileDriver.FHostDevice.FHostOption.A_StationTimeOut))
                    {
                        fXmlHostOption.set_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_StationTimeOut,
                            FFileDriver.FHostDevice.FHostOption.D_StationTimeOut,
                            optionList[FFileDriver.FHostDevice.FHostOption.A_StationTimeOut]
                            );
                    }
                    if (optionList.ContainsKey(FFileDriver.FHostDevice.FHostOption.A_GuaranteedtimeOut))
                    {
                        fXmlHostOption.set_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_GuaranteedtimeOut,
                            FFileDriver.FHostDevice.FHostOption.D_GuaranteedtimeOut,
                            optionList[FFileDriver.FHostDevice.FHostOption.A_GuaranteedtimeOut]
                            );
                    }
                    if (optionList.ContainsKey(FFileDriver.FHostDevice.FHostOption.A_MaxSpoling))
                    {
                        fXmlHostOption.set_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_MaxSpoling,
                            FFileDriver.FHostDevice.FHostOption.D_MaxSpoling,
                            optionList[FFileDriver.FHostDevice.FHostOption.A_MaxSpoling]
                            );
                    }
                    // --
                    if (optionList.ContainsKey(FFileDriver.FHostDevice.FHostOption.A_SessionId))
                    {
                        fXmlHostOption.set_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_SessionId,
                            FFileDriver.FHostDevice.FHostOption.D_SessionId,
                            optionList[FFileDriver.FHostDevice.FHostOption.A_SessionId]
                            );
                    }
                    if (optionList.ContainsKey(FFileDriver.FHostDevice.FHostOption.A_ModuleName))
                    {
                        fXmlHostOption.set_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_ModuleName,
                            FFileDriver.FHostDevice.FHostOption.D_ModuleName,
                            optionList[FFileDriver.FHostDevice.FHostOption.A_ModuleName]
                            );
                    }
                    if (optionList.ContainsKey(FFileDriver.FHostDevice.FHostOption.A_TuneChannel))
                    {
                        fXmlHostOption.set_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_TuneChannel,
                            FFileDriver.FHostDevice.FHostOption.D_TuneChannel,
                            optionList[FFileDriver.FHostDevice.FHostOption.A_TuneChannel]
                            );
                    }
                    if (optionList.ContainsKey(FFileDriver.FHostDevice.FHostOption.A_CastChannel))
                    {
                        fXmlHostOption.set_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_CastChannel,
                            FFileDriver.FHostDevice.FHostOption.D_CastChannel,
                            optionList[FFileDriver.FHostDevice.FHostOption.A_CastChannel]
                            );
                    }
                    if (optionList.ContainsKey(FFileDriver.FHostDevice.FHostOption.A_ParsingType))
                    {
                        fXmlHostOption.set_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_ParsingType,
                            FFileDriver.FHostDevice.FHostOption.D_ParsingType,
                            optionList[FFileDriver.FHostDevice.FHostOption.A_ParsingType]
                            );
                    }
                }
                return fXmlHostOption;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return null;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
    }   // Class end
}   // Namespace end
