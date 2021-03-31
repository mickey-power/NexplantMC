/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHostCondition.cs
--  Creator         : spike.lee
--  Create Date     : 2011.05.31
--  Description     : FAMate Core FaSecsDriver Host Condition Class 
--  History         : Created by spike.lee at 2011.05.31
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FHostCondition : FBaseObject<FHostCondition>, FIObject
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHostCondition(
            FSecsDriver fSecsDriver
            )
            : base(fSecsDriver.fScdCore, FSecsDriverCommon.createXmlNodeHCN(fSecsDriver.fScdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FHostCondition(
            FScdCore fScdCore,
            FXmlNode fXmlNode
            )
            : base(fScdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHostCondition(
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
                    return FObjectType.HostCondition;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.HostCondition;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHCN.A_UniqueId, FXmlTagHCN.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHCN.A_Name, FXmlTagHCN.D_Name);
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
                    FSecsDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagHCN.A_Name, FXmlTagHCN.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHCN.A_Description, FXmlTagHCN.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagHCN.A_Description, FXmlTagHCN.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagHCN.A_FontColor, FXmlTagHCN.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagHCN.A_FontColor, FXmlTagHCN.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHCN.A_FontBold, FXmlTagHCN.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagHCN.A_FontBold, FXmlTagHCN.D_FontBold, FBoolean.fromBool(value), true);
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
                    return FEnumConverter.toConditionMode(this.fXmlNode.get_attrVal(FXmlTagHCN.A_ConditionMode, FXmlTagHCN.D_ConditionMode));
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

                    // --

                    // ***
                    // 자식이 존재하는 FSecsCondition의 ConditionMode는 변경할 수 없다.
                    // ***
                    if (this.hasChild)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0013, "Object's Child"));
                    }

                    // --

                    // ***
                    // 2013.08.12 by spike.lee
                    // Condition Mode가 변경될 경우 Device와 Message가 Lock이 해제되니 않는 문제가 발생
                    // Condition Mode가 변경될 경우 Device와 Message의 Lock이 해제되도록 처리
                    // ***
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
                        this.fXmlNode.set_attrVal(FXmlTagHCN.A_ConnectionState, FXmlTagHCN.D_ConnectionState, FEnumConverter.fromDeviceState(FDeviceState.Closed));
                    }
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagHCN.A_ConditionMode, FXmlTagHCN.D_ConditionMode, FEnumConverter.fromConditionMode(value), true);
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
                    return FEnumConverter.toDeviceState(this.fXmlNode.get_attrVal(FXmlTagHCN.A_ConnectionState, FXmlTagHCN.D_ConnectionState));
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

                    this.fXmlNode.set_attrVal(FXmlTagHCN.A_ConnectionState, FXmlTagHCN.D_ConnectionState, FEnumConverter.fromDeviceState(value), true);
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

        public FHostDevice fDevice
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagHCN.A_HostDeviceId, FXmlTagHCN.D_HostDeviceId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagHDM.E_HostDeviceModeling +
                        "/" + FXmlTagHDV.E_HostDevice + "[@" + FXmlTagHDV.A_UniqueId + "='" + id + "']";
                    // --
                    return new FHostDevice(this.fScdCore, this.fSecsDriver.fXmlNode.selectSingleNode(xpath));
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

        public FHostSession fSession
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagHCN.A_HostSessionId, FXmlTagHCN.D_HostSessionId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagHDM.E_HostDeviceModeling +
                        "/" + FXmlTagHDV.E_HostDevice +
                        "/" + FXmlTagHSN.E_HostSession + "[@" + FXmlTagHSN.A_UniqueId + "='" + id + "']";
                    // --
                    return new FHostSession(this.fScdCore, this.fSecsDriver.fXmlNode.selectSingleNode(xpath));
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

        public FHostMessage fMessage
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagHCN.A_HostMessageId, FXmlTagHCN.D_HostMessageId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagHLM.E_HostLibraryModeling +
                        "/" + FXmlTagHLG.E_HostLibraryGroup +
                        "/" + FXmlTagHLB.E_HostLibrary +
                        "/" + FXmlTagHML.E_HostMessageList +
                        "/" + FXmlTagHMS.E_HostMessages +
                        "/" + FXmlTagHMG.E_HostMessage + "[@" + FXmlTagHMG.A_UniqueId + "='" + id + "']";
                    // --
                    return new FHostMessage(this.fScdCore, this.fSecsDriver.fXmlNode.selectSingleNode(xpath));
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagHCN.A_RetryLimit, FXmlTagHCN.D_RetryLimit));
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
                    this.fXmlNode.set_attrVal(FXmlTagHCN.A_RetryLimit, FXmlTagHCN.D_RetryLimit, value.ToString(), true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHCN.A_UserTag1, FXmlTagHCN.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagHCN.A_UserTag1, FXmlTagHCN.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHCN.A_UserTag2, FXmlTagHCN.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagHCN.A_UserTag2, FXmlTagHCN.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHCN.A_UserTag3, FXmlTagHCN.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagHCN.A_UserTag3, FXmlTagHCN.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHCN.A_UserTag4, FXmlTagHCN.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagHCN.A_UserTag4, FXmlTagHCN.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHCN.A_UserTag5, FXmlTagHCN.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagHCN.A_UserTag5, FXmlTagHCN.D_UserTag5, value, true);
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

        public FHostTrigger fParent
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

                    return new FHostTrigger(this.fScdCore, this.fXmlNode.fParentNode);
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

        public FHostCondition fPreviousSibling
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

                    return new FHostCondition(this.fScdCore, this.fXmlNode.fPreviousSibling);
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

        public FHostCondition fNextSibling
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

                    return new FHostCondition(this.fScdCore, this.fXmlNode.fNextSibling);
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

        public FHostExpressionCollection fChildHostExpressionCollection
        {
            get
            {
                try
                {
                    return new FHostExpressionCollection(this.fScdCore, this.fXmlNode.selectNodes(FXmlTagHEP.E_HostExpression));
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
                            "../../" + FXmlTagHTR.E_HostTrigger + "[@" + FXmlTagHTR.A_UniqueId + "='" + fParent.uniqueIdToString + "']";
                    }
                    return new FObjectCollection(this.fScdCore, this.fXmlNode.selectNodes(xpath));
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
                            "../../../../../../" + FXmlTagHDM.E_HostDeviceModeling +
                            "/" + FXmlTagHDV.E_HostDevice + "[@" + FXmlTagHDV.A_UniqueId + "='" + this.fDevice.uniqueIdToString + "']";
                        // --
                        if (this.hasSession && this.hasMessage)
                        {
                            xpath += 
                                " | " +
                                "../../../../../../" + FXmlTagHDM.E_HostDeviceModeling +
                                "/" + FXmlTagHDV.E_HostDevice +
                                "/" + FXmlTagHSN.E_HostSession + "[@" + FXmlTagHSN.A_UniqueId + "='" + this.fSession.uniqueIdToString + "']" +
                                " | " +
                                "../../../../../../" + FXmlTagHLM.E_HostLibraryModeling +
                                "/" + FXmlTagHLG.E_HostLibraryGroup +
                                "/" + FXmlTagHLB.E_HostLibrary +
                                "/" + FXmlTagHML.E_HostMessageList +
                                "/" + FXmlTagHMS.E_HostMessages +
                                "/" + FXmlTagHMG.E_HostMessage + "[@" + FXmlTagHMG.A_UniqueId + "='" + this.fMessage.uniqueIdToString + "']";
                        }
                    }
                    else
                    {
                        xpath = "NULL";
                    }

                    // --
                    
                    return new FObjectCollection(this.fScdCore, this.fXmlNode.selectNodes(xpath));
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
                    return this.fXmlNode.containsNode(FXmlTagHEP.E_HostExpression);
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
                    if (this.fXmlNode.get_attrVal(FXmlTagHCN.A_HostDeviceId, FXmlTagHCN.D_HostDeviceId) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagHCN.A_HostSessionId, FXmlTagHCN.D_HostSessionId) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagHCN.A_HostMessageId, FXmlTagHCN.D_HostMessageId) == string.Empty)
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
                    if (this.fConditionMode == FConditionMode.Timeout || this.fConditionMode == FConditionMode.Connection)
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
                        !FClipboard.containsData(FCbObjectFormat.HostCondition)
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
                    if (!FClipboard.containsData(FCbObjectFormat.HostExpression))
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
            FHostMessage fHmg = null;
            string info = string.Empty;

            try
            {
                info = this.name;
                
                // --

                if (option == FStringOption.Detail)
                {
                    if (this.hasMessage)
                    {
                        fHmg = this.fMessage;
                        // --
                        info +=
                            " Msg.=[" + this.fDevice.name + " / " + this.fSession.name + " /" +
                            " " + fHmg.command + " V" + fHmg.version.ToString() + " : " + fHmg.name + "]";
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
                fHmg = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostExpression appendChildHostExpression(
            FHostExpression fNewChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // ***
                // Host Condition의 Mode가 Timeout일 경우 Host Expression를 추가할 수 없다.                
                // ***
                if (this.fConditionMode == FConditionMode.Timeout || this.fConditionMode == FConditionMode.Connection)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Condition's Mode", "Expression"));
                }

                // --

                fNewChild.replace(this.fScdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));                
                // --                
                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fSecsDriver, this, fNewChild)
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

        public FHostExpression insertBeforeChildHostExpression(
            FHostExpression fNewChild,
            FHostExpression fRefChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // ***
                // Host Condition의 Mode가 Timeout일 경우 Host Expression를 추가할 수 없다.                
                // ***
                if (this.fConditionMode == FConditionMode.Timeout || this.fConditionMode == FConditionMode.Connection)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Condition's Mode", "Expression"));
                }

                // --

                fNewChild.replace(this.fScdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                // --                
                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // ---
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this.fSecsDriver, this, fNewChild)
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

        public FHostExpression insertAfterChildHostExpression(
            FHostExpression fNewChild,
            FHostExpression fRefChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // ***
                // Host Condition의 Mode가 Timeout일 경우 Host Expression를 추가할 수 없다.                
                // ***
                if (this.fConditionMode == FConditionMode.Timeout || this.fConditionMode == FConditionMode.Connection)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Condition's Mode", "Expression"));
                }

                // --

                fNewChild.replace(this.fScdCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                // --                
                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this.fSecsDriver, this, fNewChild)
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
                FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);                

                // --

                resetRelation();

                // --

                fParent = this.fParent;
                isModelingObject = this.isModelingObject;
                this.replace(this.fScdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));

                // --

                if (isModelingObject)
                {
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fSecsDriver, fParent, this)
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

        public FHostExpression removeChildHostExpression(
            FHostExpression fChild
            )
        {
            try
            {
                FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode, fChild.fXmlNode);

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

        public void removeChildHostExpression(
            FHostExpression[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FHostExpression fHep in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode, fHep.fXmlNode);
                }

                // --

                foreach (FHostExpression fHep in fChilds)
                {
                    fHep.remove();
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

        public void removeAllChildHostExpression(
            )
        {
            FHostExpressionCollection fHepCollction = null;

            try
            {
                fHepCollction = this.fChildHostExpressionCollection;
                if (fHepCollction.count == 0)
                {
                    return;
                }

                // --

                foreach (FHostExpression fHep in fHepCollction)
                {
                    fHep.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fHepCollction != null)
                {
                    fHepCollction.Dispose();
                    fHepCollction = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void setMessage(
            FHostDevice fHostDevice,
            FHostSession fHostSession,
            FHostMessage fHostMessage
            )
        {
            string oldHdvId = string.Empty;
            string oldHsnId = string.Empty;
            string oldHmgId = string.Empty;
            string newHdvId = string.Empty;
            string newHsnId = string.Empty;
            string newHmgId = string.Empty;

            try
            {
                // ***
                // Host Device 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fHostDevice.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Device", "Modeling File"));
                }

                // ***
                // Host Session 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fHostSession.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Session", "Modeling File"));
                }

                // ***
                // Host Message 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fHostMessage.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Message", "Modeling File"));
                }

                // ***
                // Host Condition 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Condition", "Modeling File"));
                }

                // ***
                // Host Device와 Host Condition의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fHostDevice))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Host Device and the Host Condition", "same"));
                }

                // ***
                // Host Session과 Host Condition의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fHostSession))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Host Session and the Host Condition", "same"));
                }

                // ***
                // Host Message와 Host Condition의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fHostMessage))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Host Message and the Host Condition", "same"));
                }

                // ***
                // Host Session 개체가 Host Device 개체의 자식인지 검사
                // ***
                if (!fHostDevice.containsObject(fHostSession))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Session", "Host Device"));
                }

                // ***
                // Host Session의 Library와 Host Message의 Library가 동일한지 검사
                // ***
                if (fHostSession.fLibrary != fHostMessage.fAncestorHostLibrary)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Host Library of the Host Session and the Host Message", "same"));
                }

                // --

                oldHdvId = this.fXmlNode.get_attrVal(FXmlTagHCN.A_HostDeviceId, FXmlTagHCN.D_HostDeviceId);
                oldHsnId = this.fXmlNode.get_attrVal(FXmlTagHCN.A_HostSessionId, FXmlTagHCN.D_HostSessionId);
                oldHmgId = this.fXmlNode.get_attrVal(FXmlTagHCN.A_HostMessageId, FXmlTagHCN.D_HostMessageId);
                // --
                newHdvId = fHostDevice.uniqueIdToString;
                newHsnId = fHostSession.uniqueIdToString;
                newHmgId = fHostMessage.uniqueIdToString;
                // --
                if (oldHdvId == newHdvId && oldHsnId == newHsnId && oldHmgId == newHmgId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 Host Message가 존재할 경우 Reset 한다.
                // ***
                if (oldHmgId != string.Empty)
                {
                    resetMessage(false, true);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagHCN.A_HostDeviceId, FXmlTagHCN.D_HostDeviceId, newHdvId, false);
                this.fXmlNode.set_attrVal(FXmlTagHCN.A_HostSessionId, FXmlTagHCN.D_HostSessionId, newHsnId, false);
                this.fXmlNode.set_attrVal(FXmlTagHCN.A_HostMessageId, FXmlTagHCN.D_HostMessageId, newHmgId, true);
                // --
                fHostSession.lockObject();
                fHostMessage.lockObject();
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
            FHostDevice fHdv = null;
            FHostSession fHsn = null;
            FHostMessage fHmg = null;

            try
            {
                fHdv = this.fDevice;
                fHsn = this.fSession;
                fHmg = this.fMessage;
                if (fHdv == null && fHsn == null && fHmg == null)
                {
                    return;
                }

                // --

                // ***
                // 자식 Host Expression Reset 처리
                // ***
                foreach (FHostExpression fHep in this.fChildHostExpressionCollection)
                {
                    fHep.resetOperand(isExpressionModifyEvent);
                    fHep.resetDataConversionSet(isExpressionModifyEvent);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagHCN.A_RetryLimit, FXmlTagHCN.D_RetryLimit, "0", false);
                this.fXmlNode.set_attrVal(FXmlTagHCN.A_HostDeviceId, FXmlTagHCN.D_HostDeviceId, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagHCN.A_HostSessionId, FXmlTagHCN.D_HostSessionId, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagHCN.A_HostMessageId, FXmlTagHCN.D_HostMessageId, string.Empty, isConditionModifyEvent);
                
                // --

                if (fHmg != null)
                {
                    fHmg.unlockObject();
                }

                if (fHsn != null)
                {
                    fHsn.unlockObject();
                }

                if (fHdv != null)
                {
                    fHdv.unlockObject();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHdv = null;
                fHsn = null;
                fHmg = null;
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
            FHostDevice fHostDevice
            )
        {
            string oldHdvId = string.Empty;
            string newHdvId = string.Empty;

            try
            {
                // ***
                // Host Device 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fHostDevice.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Device", "Modeling File"));
                }
                               
                // ***
                // Host Condition 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Condition", "Modeling File"));
                }

                // ***
                // Host Device와 Host Condition의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fHostDevice))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Host Device and the Host Condition", "same"));
                }
                
                // --

                oldHdvId = this.fXmlNode.get_attrVal(FXmlTagHCN.A_HostDeviceId, FXmlTagHCN.D_HostDeviceId);
                newHdvId = fHostDevice.uniqueIdToString;
                // --
                if (oldHdvId == newHdvId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 Host Message가 존재할 경우 Reset 한다.
                // ***
                if (oldHdvId != string.Empty)
                {
                    resetDevice(false);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagHCN.A_HostDeviceId, FXmlTagHCN.D_HostDeviceId, newHdvId, false);
                // --
                fHostDevice.lockObject();
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
            FHostDevice fHdv = null;

            try
            {
                fHdv = this.fDevice;
                if (fHdv == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagHCN.A_ConnectionState, FXmlTagHCN.D_ConnectionState, "", false);
                this.fXmlNode.set_attrVal(FXmlTagHCN.A_HostDeviceId, FXmlTagHCN.D_HostDeviceId, string.Empty, isConditionModifyEvent);
                // --
                fHdv.unlockObject();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHdv = null;
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
                foreach (FHostExpression fHep in this.fChildHostExpressionCollection)
                {
                    buildExpression(fHep, exp);
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
            FHostExpression fHep,
            StringBuilder exp
            )
        {
            FIHostOperand fOpd = null;
            FFormat fFormat;

            try
            {
                if (fHep.fPreviousSibling != null)
                {
                    exp.Append(" " + FEnumConverter.toLogicalExp(fHep.fLogical) + " ");
                }

                // --

                if (fHep.fExpressionType == FExpressionType.Bracket)
                {
                    exp.Append("(");
                    foreach (FHostExpression fChild in fHep.fChildHostExpressionCollection)
                    {
                        buildExpression(fChild, exp);
                    }
                    exp.Append(")");
                }
                else
                {
                    fFormat = fHep.fValueFormat;
                    fOpd = fHep.fOperand;

                    // --

                    if (fOpd == null)
                    {
                        exp.Append("'N/A'");
                    }
                    else if (fOpd.fHostOperandType == FHostOperandType.HostItem)
                    {
                        exp.Append(((FHostItem)fOpd).name);
                    }
                    else if (fOpd.fHostOperandType == FHostOperandType.Environment)
                    {
                        exp.Append(((FEnvironment)fOpd).name);
                    }
                    else if (fOpd.fHostOperandType == FHostOperandType.EquipmentState)
                    {
                        exp.Append(((FEquipmentState)fOpd).name);
                    }
                    // --
                    exp.Append("[" + fHep.operandIndex.ToString() + "]");
                    // --
                    exp.Append(" " + FEnumConverter.toOperationExp(fHep.fOperation) + " ");
                    // --
                    if (fHep.fExpressionValueType == FExpressionValueType.Value)
                    {
                        if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2 || fFormat == FFormat.Char)
                        {
                            exp.Append("\"" + fHep.encodingValue + "\"");
                        }
                        else
                        {
                            exp.Append("\"" + fHep.stringValue + "\"");
                        }
                    }
                    else
                    {
                        exp.Append(fHep.fResource.ToString());
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
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fSecsDriver, this.fParent, this)
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
                fXmlNode.set_attrVal(FXmlTagHCN.A_HostDeviceId, FXmlTagHCN.D_HostDeviceId, FXmlTagHCN.D_HostDeviceId);
                fXmlNode.set_attrVal(FXmlTagHCN.A_HostSessionId, FXmlTagHCN.D_HostSessionId, FXmlTagHCN.D_HostSessionId);
                fXmlNode.set_attrVal(FXmlTagHCN.A_HostMessageId, FXmlTagHCN.D_HostMessageId, FXmlTagHCN.D_HostMessageId);

                // --

                foreach (FXmlNode fXmlNodeHep in fXmlNode.selectNodes(FXmlTagHEP.E_HostExpression))
                {
                    FHostExpression.resetFlowNode(fXmlNodeHep);
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
                this.copyObject(FCbObjectFormat.HostCondition, fXmlNode);
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
                FSecsDriverCommon.validateCutObject(this.fXmlNode);

                // --

                this.remove();

                // --

                resetFlowNode(this.fXmlNode);
                this.copyObject(FCbObjectFormat.HostCondition, this.fXmlNode);
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

        public FHostCondition pasteSibling(
            )
        {
            FHostCondition fHostCondition = null;

            try
            {
                FSecsDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.HostCondition);

                // --

                fHostCondition = (FHostCondition)this.pasteObject(FCbObjectFormat.HostCondition);
                return this.fParent.insertAfterChildHostCondition(fHostCondition, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostCondition = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostExpression pasteChild(
            )
        {
            FHostExpression fHostExpression = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.HostExpression);

                // --

                fHostExpression = (FHostExpression)this.pasteObject(FCbObjectFormat.HostExpression);
                return this.appendChildHostExpression(fHostExpression);
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
                FSecsDriverCommon.validateMoveUpObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fScdCore, this.fXmlNode.moveUp());

                // --

                if (isModelingObject)
                {
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveUpCompleted, this.fSecsDriver, fParent, this)
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
                FSecsDriverCommon.validateMoveDownObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fScdCore, this.fXmlNode.moveDown());

                // --

                if (isModelingObject)
                {
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveDownCompleted, this.fSecsDriver, fParent, this)
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
            FHostCondition fRefObject
            )
        {
            try
            {
                FSecsDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

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

                this.replace(this.fScdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fScdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fSecsDriver, this, fRefObject)
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
            FHostTrigger fRefObject
            )
        {
            try
            {
                FSecsDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

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

                if (fRefObject.fChildHostConditionCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildHostConditionCollection[fRefObject.fChildHostConditionCollection.count - 1]))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "same localtion"));
                    }
                }

                // --

                this.replace(this.fScdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fScdCore, fRefObject.fXmlNode.appendChild(this.fXmlNode));

                // --

                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fSecsDriver, this, fRefObject)
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

        public FHostExpressionCollection selectHostExpressionByName(
            string name
            )
        {
            const string xpath = FXmlTagHEP.E_HostExpression + "[@" + FXmlTagHEP.A_Name + "='{0}']";

            try
            {
                return new FHostExpressionCollection(
                    this.fScdCore,
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

        public FHostExpression selectSingleHostExpressionByName(
            string name
            )
        {
            const string xpath = FXmlTagHEP.E_HostExpression + "[@" + FXmlTagHEP.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostExpression(this.fScdCore, fXmlNode);
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
