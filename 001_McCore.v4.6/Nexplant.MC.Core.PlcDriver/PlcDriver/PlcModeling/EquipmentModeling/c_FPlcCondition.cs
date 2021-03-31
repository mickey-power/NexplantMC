/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPlcCondition.cs
--  Creator         : spike.lee
--  Create Date     : 2013.08.09
--  Description     : FAMate Core FaPlcDriver Plc Condition Class 
--  History         : Created by spike.lee at 2013.08.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    public class FPlcCondition : FBaseObject<FPlcCondition>, FIObject
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPlcCondition(
            FPlcDriver fPlcDriver
            )
            : base(fPlcDriver.fPcdCore, FPlcDriverCommon.createXmlNodePCN(fPlcDriver.fPcdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FPlcCondition(
            FPcdCore fPcdCore,
            FXmlNode fXmlNode
            )
            : base(fPcdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPlcCondition(
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
                    return FObjectType.PlcCondition;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.PlcCondition;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagPCN.A_UniqueId, FXmlTagPCN.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCN.A_Name, FXmlTagPCN.D_Name);
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
                    FPlcDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagPCN.A_Name, FXmlTagPCN.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCN.A_Description, FXmlTagPCN.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagPCN.A_Description, FXmlTagPCN.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagPCN.A_FontColor, FXmlTagPCN.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagPCN.A_FontColor, FXmlTagPCN.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagPCN.A_FontBold, FXmlTagPCN.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagPCN.A_FontBold, FXmlTagPCN.D_FontBold, FBoolean.fromBool(value), true);
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

        public FPlcConditionMode fConditionMode
        {
            get
            {
                try
                {
                    return FEnumConverter.toPlcConditionMode(this.fXmlNode.get_attrVal(FXmlTagPCN.A_ConditionMode, FXmlTagPCN.D_ConditionMode));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FPlcConditionMode.Expression;
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
                    // 자식이 존재하는 FPlcCondition의 ConditionMode는 변경할 수 없다.
                    // ***
                    if (this.hasChild)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0013, "Object's Child"));
                    }

                    // --

                    if (this.fConditionMode == FPlcConditionMode.Expression)
                    {
                        resetMessage(false);
                    }
                    else
                    {
                        resetDevice(false);
                    }

                    // --

                    if (value == FPlcConditionMode.Connection)
                    {
                        this.fXmlNode.set_attrVal(FXmlTagPCN.A_ConnectionState, FXmlTagPCN.D_ConnectionState, FEnumConverter.fromDeviceState(FDeviceState.Closed));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagPCN.A_ConditionMode, FXmlTagPCN.D_ConditionMode, FEnumConverter.fromPlcConditionMode(value), true);
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
                    return FEnumConverter.toDeviceState(this.fXmlNode.get_attrVal(FXmlTagPCN.A_ConnectionState, FXmlTagPCN.D_ConnectionState));
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
                    if (this.fConditionMode != FPlcConditionMode.Connection)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Condition Mode", "Connection"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagPCN.A_ConnectionState, FXmlTagPCN.D_ConnectionState, FEnumConverter.fromDeviceState(value), true);
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

        public FPlcDevice fDevice
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagPCN.A_PlcDeviceId, FXmlTagPCN.D_PlcDeviceId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagPDM.E_PlcDeviceModeling +
                        "/" + FXmlTagPDV.E_PlcDevice + "[@" + FXmlTagPDV.A_UniqueId + "='" + id + "']";
                    // --
                    return new FPlcDevice(this.fPcdCore, this.fPlcDriver.fXmlNode.selectSingleNode(xpath));
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

        public FPlcSession fSession
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagPCN.A_PlcSessionId, FXmlTagPCN.D_PlcSessionId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagPDM.E_PlcDeviceModeling +
                        "/" + FXmlTagPDV.E_PlcDevice +
                        "/" + FXmlTagPSN.E_PlcSession + "[@" + FXmlTagPSN.A_UniqueId + "='" + id + "']";
                    // --
                    return new FPlcSession(this.fPcdCore, this.fPlcDriver.fXmlNode.selectSingleNode(xpath));
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

        public FPlcMessage fMessage
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagPCN.A_PlcMessageId, FXmlTagPCN.D_PlcMessageId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagPLM.E_PlcLibraryModeling +
                        "/" + FXmlTagPLG.E_PlcLibraryGroup +
                        "/" + FXmlTagPLB.E_PlcLibrary +
                        "/" + FXmlTagPML.E_PlcMessageList +
                        "/" + FXmlTagPMS.E_PlcMessages +
                        "/" + FXmlTagPMG.E_PlcMessage + "[@" + FXmlTagPMG.A_UniqueId + "='" + id + "']";
                    // --
                    return new FPlcMessage(this.fPcdCore, this.fPlcDriver.fXmlNode.selectSingleNode(xpath));
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

        public string userTag1
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagPCN.A_UserTag1, FXmlTagPCN.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagPCN.A_UserTag1, FXmlTagPCN.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCN.A_UserTag2, FXmlTagPCN.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagPCN.A_UserTag2, FXmlTagPCN.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCN.A_UserTag3, FXmlTagPCN.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagPCN.A_UserTag3, FXmlTagPCN.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCN.A_UserTag4, FXmlTagPCN.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagPCN.A_UserTag4, FXmlTagPCN.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCN.A_UserTag5, FXmlTagPCN.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagPCN.A_UserTag5, FXmlTagPCN.D_UserTag5, value, true);
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

        public FPlcTrigger fParent
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

                    return new FPlcTrigger(this.fPcdCore, this.fXmlNode.fParentNode);
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

        public FPlcCondition fPreviousSibling
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

                    return new FPlcCondition(this.fPcdCore, this.fXmlNode.fPreviousSibling);
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

        public FPlcCondition fNextSibling
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

                    return new FPlcCondition(this.fPcdCore, this.fXmlNode.fNextSibling);
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

        public FPlcExpressionCollection fChildPlcExpressionCollection
        {
            get
            {
                try
                {
                    return new FPlcExpressionCollection(this.fPcdCore, this.fXmlNode.selectNodes(FXmlTagPEP.E_PlcExpression));
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
                            "../../" + FXmlTagPTR.E_PlcTrigger + "[@" + FXmlTagPTR.A_UniqueId + "='" + fParent.uniqueIdToString + "']";
                    }
                    return new FObjectCollection(this.fPcdCore, this.fXmlNode.selectNodes(xpath));
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
                            "../../../../../../" + FXmlTagPDM.E_PlcDeviceModeling +
                            "/" + FXmlTagPDV.E_PlcDevice + "[@" + FXmlTagPDV.A_UniqueId + "='" + this.fDevice.uniqueIdToString + "']";
                        // --
                        if (this.hasSession && this.hasMessage)
                        {
                            xpath +=
                                " | " +
                                "../../../../../../" + FXmlTagPDM.E_PlcDeviceModeling +
                                "/" + FXmlTagPDV.E_PlcDevice +
                                "/" + FXmlTagPSN.E_PlcSession + "[@" + FXmlTagPSN.A_UniqueId + "='" + this.fSession.uniqueIdToString + "']" +
                                " | " +
                                "../../../../../../" + FXmlTagPLM.E_PlcLibraryModeling +
                                "/" + FXmlTagPLG.E_PlcLibraryGroup +
                                "/" + FXmlTagPLB.E_PlcLibrary +
                                "/" + FXmlTagPML.E_PlcMessageList +
                                "/" + FXmlTagPMS.E_PlcMessages +
                                "/" + FXmlTagPMG.E_PlcMessage + "[@" + FXmlTagPMG.A_UniqueId + "='" + this.fMessage.uniqueIdToString + "']";
                        }
                    }
                    else
                    {
                        xpath = "NULL";
                    }
                    
                    // --
                    
                    return new FObjectCollection(this.fPcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return this.fXmlNode.containsNode(FXmlTagPEP.E_PlcExpression);
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
                    if (this.fXmlNode.get_attrVal(FXmlTagPCN.A_PlcDeviceId, FXmlTagPCN.D_PlcDeviceId) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagPCN.A_PlcSessionId, FXmlTagPCN.D_PlcSessionId) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagPCN.A_PlcMessageId, FXmlTagPCN.D_PlcMessageId) == string.Empty)
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
                    if (this.fConditionMode == FPlcConditionMode.Connection)
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
                        !FClipboard.containsData(FCbObjectFormat.PlcCondition)
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
                    if (!FClipboard.containsData(FCbObjectFormat.PlcExpression))
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
            FPlcMessage fPmg = null;
            string info = string.Empty;

            try
            {
                info = this.name;
                
                // --

                if (option == FStringOption.Detail)
                {
                    if (this.hasMessage)
                    {
                        fPmg = this.fMessage;
                        // --
                        info +=
                            " Msg.=[" + this.fDevice.name + " / " + this.fSession.name + " / " + fPmg.name + "]";
                    }
                    else
                    {
                        if (this.fConditionMode == FPlcConditionMode.Connection)
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
                fPmg = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPlcExpression appendChildPlcExpression(
            FPlcExpression fNewChild
            )
        {
            try
            {
                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // ***
                // PLC Condition의 Mode가 Connection일 경우 PLC Expression를 추가할 수 없다.                
                // ***
                if (this.fConditionMode == FPlcConditionMode.Connection)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Condition's Mode", "Expression"));
                }

                // --

                fNewChild.replace(this.fPcdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));
                // --                
                if (this.isModelingObject)
                {
                    FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fPcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fPlcDriver, this, fNewChild)
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

        public FPlcExpression insertBeforeChildPlcExpression(
            FPlcExpression fNewChild,
            FPlcExpression fRefChild
            )
        {
            try
            {
                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // ***
                // PLC Condition의 Mode가 Connection일 경우 PLC Expression를 추가할 수 없다.                
                // ***
                if (this.fConditionMode == FPlcConditionMode.Connection)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Condition's Mode", "Expression"));
                }

                // --

                fNewChild.replace(this.fPcdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                // --                
                if (this.isModelingObject)
                {
                    FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                    // ---
                    this.fPcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this.fPlcDriver, this, fNewChild)
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

        public FPlcExpression insertAfterChildPlcExpression(
            FPlcExpression fNewChild,
            FPlcExpression fRefChild
            )
        {
            try
            {
                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // ***
                // PLC Condition의 Mode가 Connection일 경우 PLC Expression를 추가할 수 없다.                
                // ***
                if (this.fConditionMode == FPlcConditionMode.Connection)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Condition's Mode", "Expression"));
                }

                // --

                fNewChild.replace(this.fPcdCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                // --                
                if (this.isModelingObject)
                {
                    FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fPcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this.fPlcDriver, this, fNewChild)
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
                FPlcDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);                

                // --

                resetRelation();

                // --

                fParent = this.fParent;
                isModelingObject = this.isModelingObject;
                this.replace(this.fPcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));

                // --

                if (isModelingObject)
                {
                    this.fPcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fPlcDriver, fParent, this)
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

        public FPlcExpression removeChildPlcExpression(
            FPlcExpression fChild
            )
        {
            try
            {
                FPlcDriverCommon.validateRemoveChildObject(this.fXmlNode, fChild.fXmlNode);

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

        public void removeChildPlcExpression(
            FPlcExpression[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FPlcExpression fPep in fChilds)
                {
                    FPlcDriverCommon.validateRemoveChildObject(this.fXmlNode, fPep.fXmlNode);
                }

                // --

                foreach (FPlcExpression fPep in fChilds)
                {
                    fPep.remove();
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

        public void removeAllChildPlcExpression(
            )
        {
            FPlcExpressionCollection fPepCollction = null;

            try
            {
                fPepCollction = this.fChildPlcExpressionCollection;
                if (fPepCollction.count == 0)
                {
                    return;
                }

                // --

                foreach (FPlcExpression fPep in fPepCollction)
                {
                    fPep.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fPepCollction != null)
                {
                    fPepCollction.Dispose();
                    fPepCollction = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void setMessage(
            FPlcDevice fPlcDevice,
            FPlcSession fPlcSession,
            FPlcMessage fPlcMessage
            )
        {
            string oldPdvId = string.Empty;
            string oldPsnId = string.Empty;
            string oldPmgId = string.Empty;
            string newPdvId = string.Empty;
            string newPsnId = string.Empty;
            string newPmgId = string.Empty;

            try
            {
                // ***
                // PLC Device 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fPlcDevice.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "PLC Device", "Modeling File"));
                }

                // ***
                // PLC Session 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fPlcSession.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "PLC Session", "Modeling File"));
                }

                // ***
                // PLC Message 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fPlcMessage.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "PLC Message", "Modeling File"));
                }

                // ***
                // PLC Condition 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "PLC Condition", "Modeling File"));
                }

                // ***
                // PLC Device와 PLC Condition의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fPlcDevice))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the PLC Device and the PLC Condition", "same"));
                }

                // ***
                // PLC Session과 PLC Condition의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fPlcSession))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the PLC Session and the PLC Condition", "same"));
                }

                // ***
                // PLC Message와 PLC Condition의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fPlcMessage))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the PLC Message and the PLC Condition", "same"));
                }

                // ***
                // PLC Session 개체가 PLC Device 개체의 자식인지 검사
                // ***
                if (!fPlcDevice.containsObject(fPlcSession))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "PLC Session", "PLC Device"));
                }

                // ***
                // PLC Session의 Library와 PLC Message의 Library가 동일한지 검사
                // ***
                if (fPlcSession.fLibrary != fPlcMessage.fAncestorPlcLibrary)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "PLC Library of the PLC Session and the PLC Message", "same"));
                }

                // --

                oldPdvId = this.fXmlNode.get_attrVal(FXmlTagPCN.A_PlcDeviceId, FXmlTagPCN.D_PlcDeviceId);
                oldPsnId = this.fXmlNode.get_attrVal(FXmlTagPCN.A_PlcSessionId, FXmlTagPCN.D_PlcSessionId);
                oldPmgId = this.fXmlNode.get_attrVal(FXmlTagPCN.A_PlcMessageId, FXmlTagPCN.D_PlcMessageId);
                // --
                newPdvId = fPlcDevice.uniqueIdToString;
                newPsnId = fPlcSession.uniqueIdToString;
                newPmgId = fPlcMessage.uniqueIdToString;
                // --
                if (oldPdvId == newPdvId && oldPsnId == newPsnId && oldPmgId == newPmgId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 PLC Message가 존재할 경우 Reset 한다.
                // ***
                if (oldPmgId != string.Empty)
                {
                    resetMessage(false, true);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagPCN.A_PlcDeviceId, FXmlTagPCN.D_PlcDeviceId, newPdvId, false);
                this.fXmlNode.set_attrVal(FXmlTagPCN.A_PlcSessionId, FXmlTagPCN.D_PlcSessionId, newPsnId, false);
                this.fXmlNode.set_attrVal(FXmlTagPCN.A_PlcMessageId, FXmlTagPCN.D_PlcMessageId, newPmgId, true);
                // --
                fPlcSession.lockObject();
                fPlcMessage.lockObject();
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
            FPlcDevice fPdv = null;
            FPlcSession fPsn = null;
            FPlcMessage fPmg = null;

            try
            {
                fPdv = this.fDevice;
                fPsn = this.fSession;
                fPmg = this.fMessage;
                if (fPdv == null && fPsn == null && fPmg == null)
                {
                    return;
                }

                // --

                // ***
                // 자식 PLC Expression Reset 처리
                // ***
                foreach (FPlcExpression fPep in this.fChildPlcExpressionCollection)
                {
                    fPep.resetOperand(isExpressionModifyEvent);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagPCN.A_PlcDeviceId, FXmlTagPCN.D_PlcDeviceId, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagPCN.A_PlcSessionId, FXmlTagPCN.D_PlcSessionId, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagPCN.A_PlcMessageId, FXmlTagPCN.D_PlcMessageId, string.Empty, isConditionModifyEvent);
                
                // --

                if (fPmg != null)
                {
                    fPmg.unlockObject();
                }

                if (fPsn != null)
                {
                    fPsn.unlockObject();
                }

                if (fPdv != null)
                {
                    fPdv.unlockObject();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPdv = null;
                fPsn = null;
                fPmg = null;
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
            FPlcDevice fPlcDevice
            )
        {
            string oldPdvId = string.Empty;
            string newPdvId = string.Empty;

            try
            {
                // ***
                // PLC Device 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fPlcDevice.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "PLC Device", "Modeling File"));
                }
                               
                // ***
                // PLC Condition 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "PLC Condition", "Modeling File"));
                }

                // ***
                // PLC Device와 PLC Condition의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fPlcDevice))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the PLC Device and the PLC Condition", "same"));
                }
                
                // --

                oldPdvId = this.fXmlNode.get_attrVal(FXmlTagPCN.A_PlcDeviceId, FXmlTagPCN.D_PlcDeviceId);
                // --
                newPdvId = fPlcDevice.uniqueIdToString;
                // --
                if (oldPdvId == newPdvId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 PLC Device가 존재할 경우 Reset 한다.
                // ***
                if (oldPdvId != string.Empty)
                {
                    resetDevice(false);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagPCN.A_PlcDeviceId, FXmlTagPCN.D_PlcDeviceId, newPdvId, true);
                // --
                fPlcDevice.lockObject();
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
            FPlcDevice fPlcDevice = null;
            try
            {
                fPlcDevice = this.fDevice;
                if (fPlcDevice == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagPCN.A_ConnectionState, FXmlTagPCN.D_ConnectionState, "", false);
                this.fXmlNode.set_attrVal(FXmlTagPCN.A_PlcDeviceId, FXmlTagPCN.D_PlcDeviceId, string.Empty, isConditionModifyEvent);
                // --
                fPlcDevice.unlockObject();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPlcDevice = null;
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
                foreach (FPlcExpression fPep in this.fChildPlcExpressionCollection)
                {
                    buildExpression(fPep, exp);
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
            FPlcExpression fPep,
            StringBuilder exp
            )
        {
            FIPlcOperand fOpd = null;
            FFormat fFormat;

            try
            {
                if (fPep.fPreviousSibling != null)
                {
                    exp.Append(" " + FEnumConverter.toLogicalExp(fPep.fLogical) + " ");
                }

                // --

                if (fPep.fExpressionType == FExpressionType.Bracket)
                {
                    exp.Append("(");
                    foreach (FPlcExpression fChild in fPep.fChildPlcExpressionCollection)
                    {
                        buildExpression(fChild, exp);
                    }
                    exp.Append(")");
                }
                else
                {
                    fFormat = fPep.fValueFormat;
                    fOpd = fPep.fOperand;

                    // --

                    if (fOpd == null)
                    {
                        exp.Append("'N/A'");
                    }
                    else if (fOpd.fPlcOperandType == FPlcOperandType.PlcWord)
                    {
                        exp.Append(((FPlcWord)fOpd).name);
                    }
                    else if (fOpd.fPlcOperandType == FPlcOperandType.Environment)
                    {
                        exp.Append(((FEnvironment)fOpd).name);
                    }
                    else if (fOpd.fPlcOperandType == FPlcOperandType.EquipmentState)
                    {
                        exp.Append(((FEquipmentState)fOpd).name);
                    }
                    // --
                    exp.Append("[" + fPep.operandIndex.ToString() + "]");
                    // --
                    exp.Append(" " + FEnumConverter.toOperationExp(fPep.fOperation) + " ");
                    // --
                    if (fPep.fExpressionValueType == FExpressionValueType.Value)
                    {
                        if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                        {
                            exp.Append("\"" + fPep.encodingValue + "\"");
                        }
                        else
                        {
                            exp.Append("\"" + fPep.stringValue + "\"");
                        }
                    }
                    else
                    {
                        exp.Append(fPep.fResource.ToString());
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
                    this.fPcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fPlcDriver, this.fParent, this)
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
                fXmlNode.set_attrVal(FXmlTagPCN.A_PlcDeviceId, FXmlTagPCN.D_PlcDeviceId, FXmlTagPCN.D_PlcDeviceId);
                fXmlNode.set_attrVal(FXmlTagPCN.A_PlcSessionId, FXmlTagPCN.D_PlcSessionId, FXmlTagPCN.D_PlcSessionId);
                fXmlNode.set_attrVal(FXmlTagPCN.A_PlcMessageId, FXmlTagPCN.D_PlcMessageId, FXmlTagPCN.D_PlcMessageId);

                // --

                foreach (FXmlNode fXmlNodePep in fXmlNode.selectNodes(FXmlTagPEP.E_PlcExpression))
                {
                    FPlcExpression.resetFlowNode(fXmlNodePep);
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
                this.copyObject(FCbObjectFormat.PlcCondition, fXmlNode);
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
                FPlcDriverCommon.validateCutObject(this.fXmlNode);

                // --

                this.remove();

                // --

                resetFlowNode(this.fXmlNode);
                this.copyObject(FCbObjectFormat.PlcCondition, this.fXmlNode);
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

        public FPlcCondition pasteSibling(
            )
        {
            FPlcCondition fPlcCondition = null;

            try
            {
                FPlcDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.PlcCondition);

                // --

                fPlcCondition = (FPlcCondition)this.pasteObject(FCbObjectFormat.PlcCondition);
                return this.fParent.insertAfterChildPlcCondition(fPlcCondition, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPlcCondition = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPlcExpression pasteChild(
            )
        {
            FPlcExpression fPlcExpression = null;

            try
            {
                FPlcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.PlcExpression);

                // --

                fPlcExpression = (FPlcExpression)this.pasteObject(FCbObjectFormat.PlcExpression);
                return this.appendChildPlcExpression(fPlcExpression);
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
                FPlcDriverCommon.validateMoveUpObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fPcdCore, this.fXmlNode.moveUp());

                // --

                if (isModelingObject)
                {
                    this.fPcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveUpCompleted, this.fPlcDriver, fParent, this)
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
                FPlcDriverCommon.validateMoveDownObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fPcdCore, this.fXmlNode.moveDown());

                // --

                if (isModelingObject)
                {
                    this.fPcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveDownCompleted, this.fPlcDriver, fParent, this)
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
            FPlcCondition fRefObject
            )
        {
            try
            {
                FPlcDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

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

                this.replace(this.fPcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fPcdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                this.fPcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fPlcDriver, this, fRefObject)
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
            FPlcTrigger fRefObject
            )
        {
            try
            {
                FPlcDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

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

                if (fRefObject.fChildPlcConditionCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildPlcConditionCollection[fRefObject.fChildPlcConditionCollection.count - 1]))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "same localtion"));
                    }
                }

                // --

                this.replace(this.fPcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fPcdCore, fRefObject.fXmlNode.appendChild(this.fXmlNode));

                // --

                this.fPcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fPlcDriver, this, fRefObject)
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

        public FPlcExpressionCollection selectPlcExpressionByName(
            string name
            )
        {
            const string xpath = FXmlTagPEP.E_PlcExpression + "[@" + FXmlTagPEP.A_Name + "='{0}']";

            try
            {
                return new FPlcExpressionCollection(
                    this.fPcdCore,
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

        public FPlcExpression selectSinglePlcExpressionByName(
            string name
            )
        {
            const string xpath = FXmlTagPEP.E_PlcExpression + "[@" + FXmlTagPEP.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FPlcExpression(this.fPcdCore, fXmlNode);
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
