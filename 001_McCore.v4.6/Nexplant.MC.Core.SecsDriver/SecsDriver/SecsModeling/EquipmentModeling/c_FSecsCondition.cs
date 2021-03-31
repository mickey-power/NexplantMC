/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsCondition.cs
--  Creator         : spike.lee
--  Create Date     : 2011.05.31
--  Description     : FAMate Core FaSecsDriver SECS Condition Class 
--  History         : Created by spike.lee at 2011.05.31
                    : Modified by spike.lee at 2011.08.10
                        - Build Expression 추가
                        - Notice Child Modified 추가
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FSecsCondition : FBaseObject<FSecsCondition>, FIObject
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecsCondition(
            FSecsDriver fSecsDriver
            )
            : base(fSecsDriver.fScdCore, FSecsDriverCommon.createXmlNodeSCN(fSecsDriver.fScdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FSecsCondition(
            FScdCore fScdCore,
            FXmlNode fXmlNode
            )
            : base(fScdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsCondition(
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
                    return FObjectType.SecsCondition;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.SecsCondition;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSCN.A_UniqueId, FXmlTagSCN.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSCN.A_Name, FXmlTagSCN.D_Name);
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

                    this.fXmlNode.set_attrVal(FXmlTagSCN.A_Name, FXmlTagSCN.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSCN.A_Description, FXmlTagSCN.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagSCN.A_Description, FXmlTagSCN.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagSCN.A_FontColor, FXmlTagSCN.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagSCN.A_FontColor, FXmlTagSCN.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSCN.A_FontBold, FXmlTagSCN.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagSCN.A_FontBold, FXmlTagSCN.D_FontBold, FBoolean.fromBool(value), true);
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
                    return FEnumConverter.toConditionMode(this.fXmlNode.get_attrVal(FXmlTagSCN.A_ConditionMode, FXmlTagSCN.D_ConditionMode));                    
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
                        this.fXmlNode.set_attrVal(FXmlTagSCN.A_ConnectionState, FXmlTagSCN.D_ConnectionState, FEnumConverter.fromDeviceState(FDeviceState.Closed));
                    }
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagSCN.A_ConditionMode, FXmlTagSCN.D_ConditionMode, FEnumConverter.fromConditionMode(value), true);
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
                    return FEnumConverter.toDeviceState(this.fXmlNode.get_attrVal(FXmlTagSCN.A_ConnectionState, FXmlTagSCN.D_ConnectionState));
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

                    this.fXmlNode.set_attrVal(FXmlTagSCN.A_ConnectionState, FXmlTagSCN.D_ConnectionState, FEnumConverter.fromDeviceState(value), true);
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

        public FSecsDevice fDevice
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;                

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagSCN.A_SecsDeviceId, FXmlTagSCN.D_SecsDeviceId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagSDM.E_SecsDeviceModeling +
                        "/" + FXmlTagSDV.E_SecsDevice + "[@" + FXmlTagSDV.A_UniqueId + "='" + id + "']";                        
                    // --
                    return new FSecsDevice(this.fScdCore, this.fSecsDriver.fXmlNode.selectSingleNode(xpath));
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

        public FSecsSession fSession
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagSCN.A_SecsSessionId, FXmlTagSCN.D_SecsSessionId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagSDM.E_SecsDeviceModeling +
                        "/" + FXmlTagSDV.E_SecsDevice +
                        "/" + FXmlTagSSN.E_SecsSession + "[@" + FXmlTagSSN.A_UniqueId + "='" + id + "']";
                    // --
                    return new FSecsSession(this.fScdCore, this.fSecsDriver.fXmlNode.selectSingleNode(xpath));
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

        public FSecsMessage fMessage
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagSCN.A_SecsMessageId, FXmlTagSCN.D_SecsMessageId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagSLM.E_SecsLibraryModeling +
                        "/" + FXmlTagSLG.E_SecsLibraryGroup +
                        "/" + FXmlTagSLB.E_SecsLibrary +
                        "/" + FXmlTagSML.E_SecsMessageList +
                        "/" + FXmlTagSMS.E_SecsMessages +
                        "/" + FXmlTagSMG.E_SecsMessage + "[@" + FXmlTagSMG.A_UniqueId + "='" + id + "']"; 
                    // --
                    return new FSecsMessage(this.fScdCore, this.fSecsDriver.fXmlNode.selectSingleNode(xpath));
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSCN.A_RetryLimit, FXmlTagSCN.D_RetryLimit));
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
                    this.fXmlNode.set_attrVal(FXmlTagSCN.A_RetryLimit, FXmlTagSCN.D_RetryLimit, value.ToString(), true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSCN.A_UserTag1, FXmlTagSCN.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagSCN.A_UserTag1, FXmlTagSCN.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSCN.A_UserTag2, FXmlTagSCN.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagSCN.A_UserTag2, FXmlTagSCN.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSCN.A_UserTag3, FXmlTagSCN.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagSCN.A_UserTag3, FXmlTagSCN.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSCN.A_UserTag4, FXmlTagSCN.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagSCN.A_UserTag4, FXmlTagSCN.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSCN.A_UserTag5, FXmlTagSCN.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagSCN.A_UserTag5, FXmlTagSCN.D_UserTag5, value, true);
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

        public FSecsTrigger fParent
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

                    return new FSecsTrigger(this.fScdCore, this.fXmlNode.fParentNode);
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

        public FSecsCondition fPreviousSibling
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

                    return new FSecsCondition(this.fScdCore, this.fXmlNode.fPreviousSibling);
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

        public FSecsCondition fNextSibling
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

                    return new FSecsCondition(this.fScdCore, this.fXmlNode.fNextSibling);
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

        public FSecsExpressionCollection fChildSecsExpressionCollection
        {
            get
            {
                try
                {
                    return new FSecsExpressionCollection(this.fScdCore, this.fXmlNode.selectNodes(FXmlTagSEP.E_SecsExpression));
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
                            "../../" + FXmlTagSTR.E_SecsTrigger + "[@" + FXmlTagSTR.A_UniqueId + "='" + fParent.uniqueIdToString + "']";
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
                            "../../../../../../" + FXmlTagSDM.E_SecsDeviceModeling +
                            "/" + FXmlTagSDV.E_SecsDevice + "[@" + FXmlTagSDV.A_UniqueId + "='" + this.fDevice.uniqueIdToString + "']";
                        // --
                        if (this.hasSession && this.hasMessage)
                        {
                            xpath += 
                                " | " +
                                "../../../../../../" + FXmlTagSDM.E_SecsDeviceModeling +
                                "/" + FXmlTagSDV.E_SecsDevice +
                                "/" + FXmlTagSSN.E_SecsSession + "[@" + FXmlTagSSN.A_UniqueId + "='" + this.fSession.uniqueIdToString + "']" +
                                " | " +
                                "../../../../../../" + FXmlTagSLM.E_SecsLibraryModeling +
                                "/" + FXmlTagSLG.E_SecsLibraryGroup +
                                "/" + FXmlTagSLB.E_SecsLibrary +
                                "/" + FXmlTagSML.E_SecsMessageList +
                                "/" + FXmlTagSMS.E_SecsMessages +
                                "/" + FXmlTagSMG.E_SecsMessage + "[@" + FXmlTagSMG.A_UniqueId + "='" + this.fMessage.uniqueIdToString + "']";
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
                    return this.fXmlNode.containsNode(FXmlTagSEP.E_SecsExpression);
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
                    if (this.fXmlNode.get_attrVal(FXmlTagSCN.A_SecsDeviceId, FXmlTagSCN.D_SecsDeviceId) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagSCN.A_SecsSessionId, FXmlTagSCN.D_SecsSessionId) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagSCN.A_SecsMessageId, FXmlTagSCN.D_SecsMessageId) == string.Empty)
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
                        !FClipboard.containsData(FCbObjectFormat.SecsCondition)
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
                    if (!FClipboard.containsData(FCbObjectFormat.SecsExpression))
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
            FSecsMessage fSmg = null;
            string info = string.Empty;

            try
            {
                info = this.name;

                // --            

                if (option == FStringOption.Detail)
                {
                    if (this.hasMessage)
                    {
                        fSmg = this.fMessage;
                        // --
                        info +=
                            " Msg.=[" + this.fDevice.name + " / " + this.fSession.name + " /" +
                            " S" + fSmg.stream.ToString() + " F" + fSmg.function.ToString() + " V" + fSmg.version.ToString() + " : " + fSmg.name + "]";
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
                fSmg = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsExpression appendChildSecsExpression(
            FSecsExpression fNewChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // ***
                // SECS Condition의 Mode가 Timeout일 경우 SECS Expression를 추가할 수 없다.                
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

        public FSecsExpression insertBeforeChildSecsExpression(
            FSecsExpression fNewChild,
            FSecsExpression fRefChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // ***
                // SECS Condition의 Mode가 Timeout일 경우 SECS Expression를 추가할 수 없다.                
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

        public FSecsExpression insertAfterChildSecsExpression(
            FSecsExpression fNewChild,
            FSecsExpression fRefChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // ***
                // SECS Condition의 Mode가 Timeout일 경우 SECS Expression를 추가할 수 없다.                
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

        public FSecsExpression removeChildSecsExpression(
            FSecsExpression fChild
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

        public void removeChildSecsExpression(
            FSecsExpression[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FSecsExpression fSep in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode, fSep.fXmlNode);
                }

                // --

                foreach (FSecsExpression fSep in fChilds)
                {
                    fSep.remove();
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

        public void removeAllChildSecsExpression(
            )
        {
            FSecsExpressionCollection fSepCollction = null;

            try
            {
                fSepCollction = this.fChildSecsExpressionCollection;
                if (fSepCollction.count == 0)
                {
                    return;
                }

                // --

                foreach (FSecsExpression fSep in fSepCollction)
                {
                    fSep.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fSepCollction != null)
                {
                    fSepCollction.Dispose();
                    fSepCollction = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void setMessage(
            FSecsDevice fSecsDevice,
            FSecsSession fSecsSession,
            FSecsMessage fSecsMessage
            )
        {
            string oldSdvId = string.Empty;
            string oldSsnId = string.Empty;
            string oldSmgId = string.Empty;
            string newSdvId = string.Empty;
            string newSsnId = string.Empty;
            string newSmgId = string.Empty;

            try
            {
                // ***
                // SECS Device 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fSecsDevice.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "SECS Device", "Modeling File"));
                }

                // ***
                // SECS Session 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fSecsSession.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "SECS Session", "Modeling File"));
                }

                // ***
                // SECS Message 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fSecsMessage.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "SECS Message", "Modeling File"));
                }

                // ***
                // SECS Condition 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "SECS Condition", "Modeling File"));
                }

                // ***
                // SECS Device와 SECS Condition의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fSecsDevice))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the SECS Device and the SECS Condition", "same"));
                }

                // ***
                // SECS Session과 SECS Condition의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fSecsSession))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the SECS Session and the SECS Condition", "same"));
                }

                // ***
                // SECS Message와 SECS Condition의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fSecsMessage))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the SECS Message and the SECS Condition", "same"));
                }

                // ***
                // SECS Session 개체가 SECS Device 개체의 자식인지 검사
                // ***
                if (!fSecsDevice.containsObject(fSecsSession))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "SECS Session", "SECS Device"));
                }

                // ***
                // SECS Session의 Library와 SECS Message의 Library가 동일한지 검사
                // ***
                if (fSecsSession.fLibrary != fSecsMessage.fAncestorSecsLibrary)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "SECS Library of the SECS Session and the SECS Message", "same"));
                }

                // --

                oldSdvId = this.fXmlNode.get_attrVal(FXmlTagSCN.A_SecsDeviceId, FXmlTagSCN.D_SecsDeviceId);
                oldSsnId = this.fXmlNode.get_attrVal(FXmlTagSCN.A_SecsSessionId, FXmlTagSCN.D_SecsSessionId);
                oldSmgId = this.fXmlNode.get_attrVal(FXmlTagSCN.A_SecsMessageId, FXmlTagSCN.D_SecsMessageId);
                // --
                newSdvId = fSecsDevice.uniqueIdToString;
                newSsnId = fSecsSession.uniqueIdToString;
                newSmgId = fSecsMessage.uniqueIdToString;
                // --
                if (oldSdvId == newSdvId && oldSsnId == newSsnId && oldSmgId == newSmgId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 SECS Message가 존재할 경우 Reset 한다.
                // ***
                if (oldSmgId != string.Empty)
                {
                    resetMessage(false, true);
                }
                
                // --

                this.fXmlNode.set_attrVal(FXmlTagSCN.A_SecsDeviceId, FXmlTagSCN.D_SecsDeviceId, newSdvId, false);
                this.fXmlNode.set_attrVal(FXmlTagSCN.A_SecsSessionId, FXmlTagSCN.D_SecsSessionId, newSsnId, false);
                this.fXmlNode.set_attrVal(FXmlTagSCN.A_SecsMessageId, FXmlTagSCN.D_SecsMessageId, newSmgId, true);
                // --
                fSecsSession.lockObject();
                fSecsMessage.lockObject();
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
            FSecsDevice fSdv = null;
            FSecsSession fSsn = null;
            FSecsMessage fSmg = null;

            try
            {
                fSdv = this.fDevice;
                fSsn = this.fSession;
                fSmg = this.fMessage;
                if (fSdv == null && fSsn == null && fSmg == null)
                {
                    return;
                }

                // --

                // ***
                // 자식 SECS Expression Reset 처리
                // ***
                foreach (FSecsExpression fSep in this.fChildSecsExpressionCollection)
                {
                    fSep.resetOperand(isExpressionModifyEvent);
                    fSep.resetDataConversionSet(isExpressionModifyEvent);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagSCN.A_RetryLimit, FXmlTagSCN.D_RetryLimit, "0", false);
                this.fXmlNode.set_attrVal(FXmlTagSCN.A_SecsDeviceId, FXmlTagSCN.D_SecsDeviceId, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagSCN.A_SecsSessionId, FXmlTagSCN.D_SecsSessionId, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagSCN.A_SecsMessageId, FXmlTagSCN.D_SecsMessageId, string.Empty, isConditionModifyEvent);

                // --

                if (fSmg != null)
                {
                    fSmg.unlockObject();
                }

                if (fSsn != null)
                {
                    fSsn.unlockObject();
                }

                if (fSdv != null)
                {
                    fSdv.unlockObject();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSdv = null;
                fSsn = null;
                fSmg = null;
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
            FSecsDevice fSecsDevice
            )
        {
            string oldSdvId = string.Empty;
            string newSdvId = string.Empty;

            try
            {
                // ***
                // SECS Device 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fSecsDevice.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "SECS Device", "Modeling File"));
                }

                // ***
                // SECS Condition 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "SECS Condition", "Modeling File"));
                }

                // ***
                // SECS Device와 SECS Condition의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fSecsDevice))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the SECS Device and the SECS Condition", "same"));
                }
                
                // --

                oldSdvId = this.fXmlNode.get_attrVal(FXmlTagSCN.A_SecsDeviceId, FXmlTagSCN.D_SecsDeviceId);
                // --
                newSdvId = fSecsDevice.uniqueIdToString;
                // --
                if (oldSdvId == newSdvId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 SECS Message가 존재할 경우 Reset 한다.
                // ***
                if (oldSdvId != string.Empty)
                {
                    resetMessage(false, true);
                }
                
                // --

                this.fXmlNode.set_attrVal(FXmlTagSCN.A_SecsDeviceId, FXmlTagSCN.D_SecsDeviceId, newSdvId, true);
                // --
                fSecsDevice.lockObject();
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
            FSecsDevice fDevice = null;
            try
            {
                // --
                fDevice = this.fDevice;
                if (fDevice == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagSCN.A_ConnectionState, FXmlTagSCN.D_ConnectionState, "", false);
                this.fXmlNode.set_attrVal(FXmlTagSCN.A_SecsDeviceId, FXmlTagSCN.D_SecsDeviceId, string.Empty, isConditionModifyEvent);
                // --
                fDevice.unlockObject();
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
                foreach (FSecsExpression fSep in this.fChildSecsExpressionCollection)
                {
                    buildExpression(fSep, exp);
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
            FSecsExpression fSep, 
            StringBuilder exp
            )
        {
            FISecsOperand fOpd = null;
            FFormat fFormat;

            try
            {
                if (fSep.fPreviousSibling != null)
                {
                    exp.Append(" " + FEnumConverter.toLogicalExp(fSep.fLogical) + " ");
                }

                // --

                if (fSep.fExpressionType == FExpressionType.Bracket)
                {
                    exp.Append("(");
                    foreach (FSecsExpression fChild in fSep.fChildSecsExpressionCollection)
                    {
                        buildExpression(fChild, exp);
                    }
                    exp.Append(")");
                }
                else
                {
                    fFormat = fSep.fValueFormat;
                    fOpd = fSep.fOperand;

                    // --

                    if (fOpd == null)
                    {
                        exp.Append("'N/A'");
                    }
                    else if (fOpd.fSecsOperandType == FSecsOperandType.SecsItem)
                    {
                        exp.Append(((FSecsItem)fOpd).name);
                    }
                    else if (fOpd.fSecsOperandType == FSecsOperandType.Environment)
                    {
                        exp.Append(((FEnvironment)fOpd).name);
                    }
                    else if (fOpd.fSecsOperandType == FSecsOperandType.EquipmentState)
                    {
                        exp.Append(((FEquipmentState)fOpd).name);
                    }
                    // --
                    exp.Append("[" + fSep.operandIndex.ToString() + "]");

                    // --
                    
                    exp.Append(" " + FEnumConverter.toOperationExp(fSep.fOperation) + " ");
                    
                    // --

                    if (fSep.fExpressionValueType == FExpressionValueType.Value)
                    {
                        if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2 || fFormat == FFormat.Char)
                        {
                            exp.Append("\"" + fSep.encodingValue + "\"");
                        }
                        else
                        {
                            exp.Append("\"" + fSep.stringValue + "\"");
                        }
                    }
                    else
                    {
                        exp.Append(fSep.fResource.ToString());
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
                fXmlNode.set_attrVal(FXmlTagSCN.A_SecsDeviceId, FXmlTagSCN.D_SecsDeviceId, FXmlTagSCN.D_SecsDeviceId);
                fXmlNode.set_attrVal(FXmlTagSCN.A_SecsSessionId, FXmlTagSCN.D_SecsSessionId, FXmlTagSCN.D_SecsSessionId);
                fXmlNode.set_attrVal(FXmlTagSCN.A_SecsMessageId, FXmlTagSCN.D_SecsMessageId, FXmlTagSCN.D_SecsMessageId);
                
                // --

                foreach (FXmlNode fXmlNodeSep in fXmlNode.selectNodes(FXmlTagSEP.E_SecsExpression))
                {
                    FSecsExpression.resetFlowNode(fXmlNodeSep);
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
                this.copyObject(FCbObjectFormat.SecsCondition, fXmlNode);
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
                this.copyObject(FCbObjectFormat.SecsCondition, this.fXmlNode);
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

        public FSecsCondition pasteSibling(
            )
        {
            FSecsCondition fSecsCondition = null;

            try
            {
                FSecsDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.SecsCondition);
                
                // --

                fSecsCondition = (FSecsCondition)this.pasteObject(FCbObjectFormat.SecsCondition);
                return this.fParent.insertAfterChildSecsCondition(fSecsCondition, this);                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsCondition = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsExpression pasteChild(
            )
        {
            FSecsExpression fSecsExpression = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.SecsExpression);

                // --

                fSecsExpression = (FSecsExpression)this.pasteObject(FCbObjectFormat.SecsExpression);
                return this.appendChildSecsExpression(fSecsExpression);
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
            FSecsCondition fRefObject
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
            FSecsTrigger fRefObject
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

                if (fRefObject.fChildSecsConditionCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildSecsConditionCollection[fRefObject.fChildSecsConditionCollection.count - 1]))
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

        public FSecsExpressionCollection selectSecsExpressionByName(
            string name
            )
        {
            const string xpath = FXmlTagSEP.E_SecsExpression + "[@" + FXmlTagSEP.A_Name + "='{0}']";

            try
            {
                return new FSecsExpressionCollection(
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

        public FSecsExpression selectSingleSecsExpressionByName(
            string name
            )
        {
            const string xpath = FXmlTagSEP.E_SecsExpression + "[@" + FXmlTagSEP.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsExpression(this.fScdCore, fXmlNode);
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
