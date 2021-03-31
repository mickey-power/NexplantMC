/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpCondition.cs
--  Creator         : spike.lee
--  Create Date     : 2013.08.09
--  Description     : FAMate Core FaTcpDriver TCP Condition Class 
--  History         : Created by spike.lee at 2013.08.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public class FTcpCondition : FBaseObject<FTcpCondition>, FIObject
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpCondition(
            FTcpDriver fTcpDriver
            )
            : base(fTcpDriver.fTcdCore, FTcpDriverCommon.createXmlNodeTCN(fTcpDriver.fTcdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FTcpCondition(
            FTcdCore fTcdCore,
            FXmlNode fXmlNode
            )
            : base(fTcdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpCondition(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    
                }                

                m_disposed = true;

                // --
                
                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FObjectType fObjectType
        {
            get
            {
                try
                {
                    return FObjectType.TcpCondition;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.TcpCondition;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTCN.A_UniqueId, FXmlTagTCN.D_UniqueId);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public UInt64 uniqueId
        {
            get
            {
                try
                {
                    return UInt64.Parse(this.uniqueIdToString);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string name
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTCN.A_Name, FXmlTagTCN.D_Name);
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

            set
            {
                try
                {
                    FTcpDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagTCN.A_Name, FXmlTagTCN.D_Name, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string description
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTCN.A_Description, FXmlTagTCN.D_Description);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagTCN.A_Description, FXmlTagTCN.D_Description, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public Color fontColor
        {
            get
            {
                try
                {
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagTCN.A_FontColor, FXmlTagTCN.D_FontColor));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return Color.Black;
            }

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagTCN.A_FontColor, FXmlTagTCN.D_FontColor, value.Name, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool fontBold
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagTCN.A_FontBold, FXmlTagTCN.D_FontBold));
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagTCN.A_FontBold, FXmlTagTCN.D_FontBold, FBoolean.fromBool(value), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public FConditionMode fConditionMode
        {
            get
            {
                try
                {
                    return FEnumConverter.toConditionMode(this.fXmlNode.get_attrVal(FXmlTagTCN.A_ConditionMode, FXmlTagTCN.D_ConditionMode));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FConditionMode.Expression;
            }

            set
            {
                try
                {
                    if (this.fConditionMode == value)
                    {
                        return;
                    }


                    // ***
                    // 자식이 존재하는 FTcpCondition의 ConditionMode는 변경할 수 없다.
                    // ***
                    if (this.hasChild)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0013, "Object's Child"));
                    }

                    // --

                    if (this.fConditionMode == FConditionMode.Expression || this.fConditionMode == FConditionMode.Timeout)
                    {
                        resetMessage(false);
                    }
                    else
                    {
                        resetDevice(false);
                    }

                    // --

                    if (value == FConditionMode.Connection)
                    {
                        this.fXmlNode.set_attrVal(FXmlTagTCN.A_ConnectionState, FXmlTagTCN.D_ConnectionState, FEnumConverter.fromDeviceState(FDeviceState.Closed));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagTCN.A_ConditionMode, FXmlTagTCN.D_ConditionMode, FEnumConverter.fromConditionMode(value), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDeviceState fConnectionState
        {
            get
            {
                try
                {
                    return FEnumConverter.toDeviceState(this.fXmlNode.get_attrVal(FXmlTagTCN.A_ConnectionState, FXmlTagTCN.D_ConnectionState));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDeviceState.Closed;
            }

            set
            {
                try
                {
                    if (this.fConditionMode != FConditionMode.Connection)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Condition Mode", "Connection"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagTCN.A_ConnectionState, FXmlTagTCN.D_ConnectionState, FEnumConverter.fromDeviceState(value), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpDevice fDevice
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagTCN.A_TcpDeviceId, FXmlTagTCN.D_TcpDeviceId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagTDM.E_TcpDeviceModeling +
                        "/" + FXmlTagTDV.E_TcpDevice + "[@" + FXmlTagTDV.A_UniqueId + "='" + id + "']";
                    // --
                    return new FTcpDevice(this.fTcdCore, this.fTcpDriver.fXmlNode.selectSingleNode(xpath));
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpSession fSession
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagTCN.A_TcpSessionId, FXmlTagTCN.D_TcpSessionId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagTDM.E_TcpDeviceModeling +
                        "/" + FXmlTagTDV.E_TcpDevice +
                        "/" + FXmlTagTSN.E_TcpSession + "[@" + FXmlTagTSN.A_UniqueId + "='" + id + "']";
                    // --
                    return new FTcpSession(this.fTcdCore, this.fTcpDriver.fXmlNode.selectSingleNode(xpath));
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpMessage fMessage
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagTCN.A_TcpMessageId, FXmlTagTCN.D_TcpMessageId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagTLM.E_TcpLibraryModeling +
                        "/" + FXmlTagTLG.E_TcpLibraryGroup +
                        "/" + FXmlTagTLB.E_TcpLibrary +
                        "/" + FXmlTagTML.E_TcpMessageList +
                        "/" + FXmlTagTMS.E_TcpMessages +
                        "/" + FXmlTagTMG.E_TcpMessage + "[@" + FXmlTagTMG.A_UniqueId + "='" + id + "']";
                    // --
                    return new FTcpMessage(this.fTcdCore, this.fTcpDriver.fXmlNode.selectSingleNode(xpath));
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
        }     

        //------------------------------------------------------------------------------------------------------------------------

        public string expression
        {
            get
            {
                try
                {
                    return buildExpression();
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
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        public int retryLimit
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagTCN.A_RetryLimit, FXmlTagTCN.D_RetryLimit));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }

            set
            {
                try
                {
                    if (value < 0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Retry Limit"));
                    }
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagTCN.A_RetryLimit, FXmlTagTCN.D_RetryLimit, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag1
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTCN.A_UserTag1, FXmlTagTCN.D_UserTag1);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagTCN.A_UserTag1, FXmlTagTCN.D_UserTag1, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag2
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTCN.A_UserTag2, FXmlTagTCN.D_UserTag2);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagTCN.A_UserTag2, FXmlTagTCN.D_UserTag2, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag3
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTCN.A_UserTag3, FXmlTagTCN.D_UserTag3);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagTCN.A_UserTag3, FXmlTagTCN.D_UserTag3, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag4
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTCN.A_UserTag4, FXmlTagTCN.D_UserTag4);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagTCN.A_UserTag4, FXmlTagTCN.D_UserTag4, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag5
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTCN.A_UserTag5, FXmlTagTCN.D_UserTag5);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagTCN.A_UserTag5, FXmlTagTCN.D_UserTag5, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string defUserTagName1
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(1);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string defUserTagName2
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(2);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string defUserTagName3
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(3);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string defUserTagName4
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(4);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string defUserTagName5
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(5);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpTrigger fParent
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null)
                    {
                        return null;
                    }

                    // --

                    return new FTcpTrigger(this.fTcdCore, this.fXmlNode.fParentNode);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpCondition fPreviousSibling
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fPreviousSibling == null)
                    {
                        return null;
                    }

                    // --

                    return new FTcpCondition(this.fTcdCore, this.fXmlNode.fPreviousSibling);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpCondition fNextSibling
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fNextSibling == null)
                    {
                        return null;
                    }

                    // --

                    return new FTcpCondition(this.fTcdCore, this.fXmlNode.fNextSibling);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpExpressionCollection fChildTcpExpressionCollection
        {
            get
            {
                try
                {
                    return new FTcpExpressionCollection(this.fTcdCore, this.fXmlNode.selectNodes(FXmlTagTEP.E_TcpExpression));
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FObjectNameCollection fObjectNameCollection
        {
            get
            {
                try
                {
                    return this.getObjectNameCollection();
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FObjectCollection fReferenceObjectCollection
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    if (this.fParent != null)
                    {
                        xpath =
                            "../../" + FXmlTagTTR.E_TcpTrigger + "[@" + FXmlTagTTR.A_UniqueId + "='" + fParent.uniqueIdToString + "']";
                    }
                    return new FObjectCollection(this.fTcdCore, this.fXmlNode.selectNodes(xpath));
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FObjectCollection fInclusionObjectCollection
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    if (this.hasDevice)
                    {
                        xpath =
                            "../../../../../../" + FXmlTagTDM.E_TcpDeviceModeling +
                            "/" + FXmlTagTDV.E_TcpDevice + "[@" + FXmlTagTDV.A_UniqueId + "='" + this.fDevice.uniqueIdToString + "']";
                        // --
                        if (this.hasSession && this.hasMessage)
                        {
                            xpath +=
                                " | " +
                                "../../../../../../" + FXmlTagTDM.E_TcpDeviceModeling +
                                "/" + FXmlTagTDV.E_TcpDevice +
                                "/" + FXmlTagTSN.E_TcpSession + "[@" + FXmlTagTSN.A_UniqueId + "='" + this.fSession.uniqueIdToString + "']" +
                                " | " +
                                "../../../../../../" + FXmlTagTLM.E_TcpLibraryModeling +
                                "/" + FXmlTagTLG.E_TcpLibraryGroup +
                                "/" + FXmlTagTLB.E_TcpLibrary +
                                "/" + FXmlTagTML.E_TcpMessageList +
                                "/" + FXmlTagTMS.E_TcpMessages +
                                "/" + FXmlTagTMG.E_TcpMessage + "[@" + FXmlTagTMG.A_UniqueId + "='" + this.fMessage.uniqueIdToString + "']";
                        }
                    }
                    else
                    {
                        xpath = "NULL";
                    }
                    
                    // --
                    
                    return new FObjectCollection(this.fTcdCore, this.fXmlNode.selectNodes(xpath));
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool hasChild
        {
            get
            {
                try
                {
                    return this.fXmlNode.containsNode(FXmlTagTEP.E_TcpExpression);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool hasHashTagChild
        {
            get
            {
                try
                {
                    return false;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool hasDevice
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagTCN.A_TcpDeviceId, FXmlTagTCN.D_TcpDeviceId) == string.Empty)
                    {
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool hasSession
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagTCN.A_TcpSessionId, FXmlTagTCN.D_TcpSessionId) == string.Empty)
                    {
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool hasMessage
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagTCN.A_TcpMessageId, FXmlTagTCN.D_TcpMessageId) == string.Empty)
                    {
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canAppendChild
        {
            get
            {
                try
                {
                    if (this.fConditionMode == FConditionMode.Connection || this.fConditionMode == FConditionMode.Timeout)
                    {
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
        }

        //-----------------------------------------------------------------------------------------------------------------------

        public bool canInsertBefore
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null)
                    {
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canInsertAfter
        {
            get
            {
                try
                {
                    return this.canInsertBefore;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canRemove
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null)
                    {
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canMoveUp
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null || this.fXmlNode.fPreviousSibling == null)
                    {
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canMoveDown
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null || this.fXmlNode.fNextSibling == null)
                    {
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canCopy
        {
            get
            {
                try
                {
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canCut
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null)
                    {
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canPasteSibling
        {
            get
            {
                try
                {
                    if (
                        this.fXmlNode.fParentNode == null ||
                        !FClipboard.containsData(FCbObjectFormat.TcpCondition)
                        )
                    {
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canPasteChild
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.TcpExpression))
                    {
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public string ToString(
            FStringOption option
            )
        {
            FTcpMessage fTmg = null;
            string info = string.Empty;

            try
            {
                info = this.name;
                
                // --

                if (option == FStringOption.Detail)
                {
                    if (this.hasMessage)
                    {                        
                        fTmg = this.fMessage;
                        // --
                        info +=
                            " Msg.=[" + this.fDevice.name + " / " + this.fSession.name + " /" +
                            " " + fTmg.command + " V" + fTmg.version.ToString() + " : " + fTmg.name + "]";
                    }
                    else
                    {
                        if (this.fConditionMode == FConditionMode.Connection)
                        {
                            if (this.hasDevice)
                            {
                                info += " Dv.=[" + this.fDevice.name + " == " + this.fConnectionState.ToString() + "]";
                            }
                            else
                            {
                                info += " Dv.=[ == " + this.fConnectionState.ToString() + "]";
                            }
                        }
                    }

                    if (this.hasChild)
                    {
                        info += " Exp.=[" + this.expression + "]";
                    }
                }                
                
                // --
                
                if (this.description != string.Empty)
                {
                    info += (" Desc=[" + this.description + "]");
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
                fTmg = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpExpression appendChildTcpExpression(
            FTcpExpression fNewChild
            )
        {
            try
            {
                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // ***
                // TCP Condition의 Mode가 Timeout일 경우 TCP Expression를 추가할 수 없다.                
                // ***
                if (this.fConditionMode == FConditionMode.Timeout || this.fConditionMode == FConditionMode.Connection)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Condition's Mode", "Expression"));
                }

                // --

                fNewChild.replace(this.fTcdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));
                // --                
                if (this.isModelingObject)
                {
                    FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fTcpDriver, this, fNewChild)
                        );
                    noticeChildModified();
                }

                // --

                return fNewChild;
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

        public FTcpExpression insertBeforeChildTcpExpression(
            FTcpExpression fNewChild,
            FTcpExpression fRefChild
            )
        {
            try
            {
                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // ***
                // TCP Condition의 Mode가 Timeout일 경우 TCP Expression를 추가할 수 없다.                
                // ***
                if (this.fConditionMode == FConditionMode.Timeout || this.fConditionMode == FConditionMode.Connection)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Condition's Mode", "Expression"));
                }

                // --

                fNewChild.replace(this.fTcdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                // --                
                if (this.isModelingObject)
                {
                    FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                    // ---
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this.fTcpDriver, this, fNewChild)
                        );
                    noticeChildModified();
                }

                // --

                return fNewChild;
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

        public FTcpExpression insertAfterChildTcpExpression(
            FTcpExpression fNewChild,
            FTcpExpression fRefChild
            )
        {
            try
            {
                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // ***
                // TCP Condition의 Mode가 Timeout일 경우 TCP Expression를 추가할 수 없다.                
                // ***
                if (this.fConditionMode == FConditionMode.Timeout || this.fConditionMode == FConditionMode.Connection)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Condition's Mode", "Expression"));
                }

                // --

                fNewChild.replace(this.fTcdCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                // --                
                if (this.isModelingObject)
                {
                    FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this.fTcpDriver, this, fNewChild)
                        );
                    noticeChildModified();
                }

                // --

                return fNewChild;
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

        public void remove(
            )
        {
            FIObject fParent = null;
            bool isModelingObject = false;

            try
            {
                FTcpDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);                

                // --

                resetRelation();

                // --

                fParent = this.fParent;
                isModelingObject = this.isModelingObject;
                this.replace(this.fTcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));

                // --

                if (isModelingObject)
                {
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fTcpDriver, fParent, this)
                        );
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpExpression removeChildTcpExpression(
            FTcpExpression fChild
            )
        {
            try
            {
                FTcpDriverCommon.validateRemoveChildObject(this.fXmlNode, fChild.fXmlNode);

                // --

                fChild.remove();

                // --

                return fChild;
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

        public void removeChildTcpExpression(
            FTcpExpression[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FTcpExpression fTep in fChilds)
                {
                    FTcpDriverCommon.validateRemoveChildObject(this.fXmlNode, fTep.fXmlNode);
                }

                // --

                foreach (FTcpExpression fTep in fChilds)
                {
                    fTep.remove();
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

        public void removeAllChildTcpExpression(
            )
        {
            FTcpExpressionCollection fTepCollction = null;

            try
            {
                fTepCollction = this.fChildTcpExpressionCollection;
                if (fTepCollction.count == 0)
                {
                    return;
                }

                // --

                foreach (FTcpExpression fTep in fTepCollction)
                {
                    fTep.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fTepCollction != null)
                {
                    fTepCollction.Dispose();
                    fTepCollction = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void setMessage(
            FTcpDevice fTcpDevice,
            FTcpSession fTcpSession,
            FTcpMessage fTcpMessage
            )
        {
            string oldTdvId = string.Empty;
            string oldTsnId = string.Empty;
            string oldTmgId = string.Empty;
            string newTdvId = string.Empty;
            string newTsnId = string.Empty;
            string newTmgId = string.Empty;

            try
            {
                // ***
                // TCP Device 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fTcpDevice.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "TCP Device", "Modeling File"));
                }

                // ***
                // TCP Session 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fTcpSession.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "TCP Session", "Modeling File"));
                }

                // ***
                // TCP Message 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fTcpMessage.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "TCP Message", "Modeling File"));
                }

                // ***
                // TCP Condition 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "TCP Condition", "Modeling File"));
                }

                // ***
                // TCP Device와 TCP Condition의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fTcpDevice))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the TCP Device and the TCP Condition", "same"));
                }

                // ***
                // TCP Session과 TCP Condition의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fTcpSession))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the TCP Session and the TCP Condition", "same"));
                }

                // ***
                // TCP Message와 TCP Condition의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fTcpMessage))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the TCP Message and the TCP Condition", "same"));
                }

                // ***
                // TCP Session 개체가 TCP Device 개체의 자식인지 검사
                // ***
                if (!fTcpDevice.containsObject(fTcpSession))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "TCP Session", "TCP Device"));
                }

                // ***
                // TCP Session의 Library와 TCP Message의 Library가 동일한지 검사
                // ***
                if (fTcpSession.fLibrary != fTcpMessage.fAncestorTcpLibrary)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "TCP Library of the TCP Session and the TCP Message", "same"));
                }

                // --

                oldTdvId = this.fXmlNode.get_attrVal(FXmlTagTCN.A_TcpDeviceId, FXmlTagTCN.D_TcpDeviceId);
                oldTsnId = this.fXmlNode.get_attrVal(FXmlTagTCN.A_TcpSessionId, FXmlTagTCN.D_TcpSessionId);
                oldTmgId = this.fXmlNode.get_attrVal(FXmlTagTCN.A_TcpMessageId, FXmlTagTCN.D_TcpMessageId);
                // --
                newTdvId = fTcpDevice.uniqueIdToString;
                newTsnId = fTcpSession.uniqueIdToString;
                newTmgId = fTcpMessage.uniqueIdToString;
                // --
                if (oldTdvId == newTdvId && oldTsnId == newTsnId && oldTmgId == newTmgId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 TCP Message가 존재할 경우 Reset 한다.
                // ***
                if (oldTmgId != string.Empty)
                {
                    resetMessage(false, true);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagTCN.A_TcpDeviceId, FXmlTagTCN.D_TcpDeviceId, newTdvId, false);
                this.fXmlNode.set_attrVal(FXmlTagTCN.A_TcpSessionId, FXmlTagTCN.D_TcpSessionId, newTsnId, false);
                this.fXmlNode.set_attrVal(FXmlTagTCN.A_TcpMessageId, FXmlTagTCN.D_TcpMessageId, newTmgId, true);
                // --
                fTcpSession.lockObject();
                fTcpMessage.lockObject();
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

        internal void resetMessage(
            bool isModifyEvent
            )
        {
            try
            {
                resetMessage(isModifyEvent, isModifyEvent);
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

        internal void resetMessage(
            bool isConditionModifyEvent,
            bool isExpressionModifyEvent
            )
        {
            FTcpDevice fTdv = null;
            FTcpSession fTsn = null;
            FTcpMessage fTmg = null;

            try
            {
                fTdv = this.fDevice;
                fTsn = this.fSession;
                fTmg = this.fMessage;
                if (fTdv == null && fTsn == null && fTmg == null)
                {
                    return;
                }

                // --

                // ***
                // 자식 TCP Expression Reset 처리
                // ***
                foreach (FTcpExpression fTep in this.fChildTcpExpressionCollection)
                {
                    fTep.resetOperand(isExpressionModifyEvent);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagTCN.A_TcpDeviceId, FXmlTagTCN.D_TcpDeviceId, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagTCN.A_TcpSessionId, FXmlTagTCN.D_TcpSessionId, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagTCN.A_TcpMessageId, FXmlTagTCN.D_TcpMessageId, string.Empty, isConditionModifyEvent);
                
                // --

                if (fTmg != null)
                {
                    fTmg.unlockObject();
                }

                if (fTsn != null)
                {
                    fTsn.unlockObject();
                }

                if (fTdv != null)
                {
                    fTdv.unlockObject();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTdv = null;
                fTsn = null;
                fTmg = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void resetMessage(
            )
        {
            try
            {
                resetMessage(true);
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

        public void setDevice(
            FTcpDevice fTcpDevice
            )
        {
            string oldTdvId = string.Empty;
            string newTdvId = string.Empty;

            try
            {
                // ***
                // TCP Device 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fTcpDevice.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "TCP Device", "Modeling File"));
                }
                               
                // ***
                // TCP Condition 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "TCP Condition", "Modeling File"));
                }

                // ***
                // TCP Device와 TCP Condition의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fTcpDevice))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the TCP Device and the TCP Condition", "same"));
                }
                
                // --

                oldTdvId = this.fXmlNode.get_attrVal(FXmlTagTCN.A_TcpDeviceId, FXmlTagTCN.D_TcpDeviceId);
                // --
                newTdvId = fTcpDevice.uniqueIdToString;
                // --
                if (oldTdvId == newTdvId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 TCP Device가 존재할 경우 Reset 한다.
                // ***
                if (oldTdvId != string.Empty)
                {
                    resetDevice(false);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagTCN.A_TcpDeviceId, FXmlTagTCN.D_TcpDeviceId, newTdvId, true);
                // --
                fTcpDevice.lockObject();
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

        internal void resetDevice(
            bool isConditionModifyEvent
            )
        {
            FTcpDevice fTcpDevice = null;
            try
            {
                fTcpDevice = this.fDevice;
                if (fTcpDevice == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagTCN.A_ConnectionState, FXmlTagTCN.D_ConnectionState, "", false);
                this.fXmlNode.set_attrVal(FXmlTagTCN.A_TcpDeviceId, FXmlTagTCN.D_TcpDeviceId, string.Empty, isConditionModifyEvent);
                // --
                fTcpDevice.unlockObject();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTcpDevice = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void resetDevice(
            )
        {
            try
            {
                resetDevice(true);
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

        internal void resetRelation(
            )
        {
            try
            {
                resetMessage(false);
                resetDevice(false);
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

        private string buildExpression(
           )
        {
            StringBuilder exp = null;

            try
            {
                exp = new StringBuilder();
                foreach (FTcpExpression fTep in this.fChildTcpExpressionCollection)
                {
                    buildExpression(fTep, exp);
                }
                return exp.ToString();
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

        private void buildExpression(
            FTcpExpression fTep,
            StringBuilder exp
            )
        {
            FITcpOperand fOpd = null;
            FFormat fFormat;

            try
            {
                if (fTep.fPreviousSibling != null)
                {
                    exp.Append(" " + FEnumConverter.toLogicalExp(fTep.fLogical) + " ");
                }

                // --

                if (fTep.fExpressionType == FExpressionType.Bracket)
                {
                    exp.Append("(");
                    foreach (FTcpExpression fChild in fTep.fChildTcpExpressionCollection)
                    {
                        buildExpression(fChild, exp);
                    }
                    exp.Append(")");
                }
                else
                {
                    fFormat = fTep.fValueFormat;
                    fOpd = fTep.fOperand;

                    // --

                    if (fOpd == null)
                    {
                        exp.Append("'N/A'");
                    }
                    else if (fOpd.fTcpOperandType == FTcpOperandType.TcpItem)
                    {
                        exp.Append(((FTcpItem)fOpd).name);
                    }                    
                    else if (fOpd.fTcpOperandType == FTcpOperandType.Environment)
                    {
                        exp.Append(((FEnvironment)fOpd).name);
                    }
                    else if (fOpd.fTcpOperandType == FTcpOperandType.EquipmentState)
                    {
                        exp.Append(((FEquipmentState)fOpd).name);
                    }
                    // --
                    exp.Append("[" + fTep.operandIndex.ToString() + "]");
                    // --
                    exp.Append(" " + FEnumConverter.toOperationExp(fTep.fOperation) + " ");
                    // --
                    if (fTep.fExpressionValueType == FExpressionValueType.Value)
                    {
                        if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                        {
                            exp.Append("\"" + fTep.encodingValue + "\"");
                        }
                        else
                        {
                            exp.Append("\"" + fTep.stringValue + "\"");
                        }
                    }
                    else
                    {
                        exp.Append(fTep.fResource.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOpd = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void noticeChildModified(
            )
        {
            try
            {
                if (this.isModelingObject)
                {
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fTcpDriver, this.fParent, this)
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

        internal static void resetFlowNode(
           FXmlNode fXmlNode
           )
        {
            try
            {
                fXmlNode.set_attrVal(FXmlTagTCN.A_TcpDeviceId, FXmlTagTCN.D_TcpDeviceId, FXmlTagTCN.D_TcpDeviceId);
                fXmlNode.set_attrVal(FXmlTagTCN.A_TcpSessionId, FXmlTagTCN.D_TcpSessionId, FXmlTagTCN.D_TcpSessionId);
                fXmlNode.set_attrVal(FXmlTagTCN.A_TcpMessageId, FXmlTagTCN.D_TcpMessageId, FXmlTagTCN.D_TcpMessageId);

                // --

                foreach (FXmlNode fXmlNodePep in fXmlNode.selectNodes(FXmlTagTEP.E_TcpExpression))
                {
                    FTcpExpression.resetFlowNode(fXmlNodePep);
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

        public void copy(
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.clone(true);
                // --

                resetFlowNode(fXmlNode);
                this.copyObject(FCbObjectFormat.TcpCondition, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void cut(
            )
        {
            try
            {
                FTcpDriverCommon.validateCutObject(this.fXmlNode);

                // --

                this.remove();

                // --

                resetFlowNode(this.fXmlNode);
                this.copyObject(FCbObjectFormat.TcpCondition, this.fXmlNode);
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

        public FTcpCondition pasteSibling(
            )
        {
            FTcpCondition fTcpCondition = null;

            try
            {
                FTcpDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.TcpCondition);

                // --

                fTcpCondition = (FTcpCondition)this.pasteObject(FCbObjectFormat.TcpCondition);
                return this.fParent.insertAfterChildTcpCondition(fTcpCondition, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTcpCondition = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpExpression pasteChild(
            )
        {
            FTcpExpression fTcpExpression = null;

            try
            {
                FTcpDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.TcpExpression);

                // --

                fTcpExpression = (FTcpExpression)this.pasteObject(FCbObjectFormat.TcpExpression);
                return this.appendChildTcpExpression(fTcpExpression);
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

        public void moveUp(
            )
        {
            bool isModelingObject = false;

            try
            {
                FTcpDriverCommon.validateMoveUpObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fTcdCore, this.fXmlNode.moveUp());

                // --

                if (isModelingObject)
                {
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveUpCompleted, this.fTcpDriver, fParent, this)
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

        public void moveDown(
            )
        {
            bool isModelingObject = false;

            try
            {
                FTcpDriverCommon.validateMoveDownObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fTcdCore, this.fXmlNode.moveDown());

                // --

                if (isModelingObject)
                {
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveDownCompleted, this.fTcpDriver, fParent, this)
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

        public void moveTo(
            FTcpCondition fRefObject
            )
        {
            try
            {
                FTcpDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

                // --

                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "Modeling Object"));
                }

                if (!fRefObject.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Reference Object", "Modeling Object"));
                }

                if (!this.equalsModelingFile(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Modeling File", "same"));
                }

                if (!this.fParent.Equals(fRefObject.fParent))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0008, "Object", "Parent"));
                }

                // --

                this.replace(this.fTcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fTcdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                this.fTcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fTcpDriver, this, fRefObject)
                    );
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

        public void moveTo(
            FTcpTrigger fRefObject
            )
        {
            try
            {
                FTcpDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

                // --

                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "Modeling Object"));
                }

                if (!fRefObject.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Reference Object", "Modeling Object"));
                }

                if (!this.equalsModelingFile(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Modeling File", "same"));
                }

                if (!this.fParent.Equals(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0008, "Object", "Parent"));
                }

                if (fRefObject.fChildTcpConditionCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildTcpConditionCollection[fRefObject.fChildTcpConditionCollection.count - 1]))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "same localtion"));
                    }
                }

                // --

                this.replace(this.fTcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fTcdCore, fRefObject.fXmlNode.appendChild(this.fXmlNode));

                // --

                this.fTcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fTcpDriver, this, fRefObject)
                    );
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

        public FTcpExpressionCollection selectTcpExpressionByName(
            string name
            )
        {
            const string xpath = FXmlTagTEP.E_TcpExpression + "[@" + FXmlTagTEP.A_Name + "='{0}']";

            try
            {
                return new FTcpExpressionCollection(
                    this.fTcdCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, name))
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

        public FTcpExpression selectSingleTcpExpressionByName(
            string name
            )
        {
            const string xpath = FXmlTagTEP.E_TcpExpression + "[@" + FXmlTagTEP.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FTcpExpression(this.fTcdCore, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
