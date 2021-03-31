/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOpcCondition.cs
--  Creator         : spike.lee
--  Create Date     : 2013.08.09
--  Description     : FAMate Core FaOpcDriver OPC Condition Class 
--  History         : Created by spike.lee at 2013.08.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public class FOpcCondition : FBaseObject<FOpcCondition>, FIObject
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOpcCondition(
            FOpcDriver fOpcDriver
            )
            : base(fOpcDriver.fOcdCore, FOpcDriverCommon.createXmlNodeOCN(fOpcDriver.fOcdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FOpcCondition(
            FOcdCore fOcdCore,
            FXmlNode fXmlNode
            )
            : base(fOcdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOpcCondition(
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
                    return FObjectType.OpcCondition;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.OpcCondition;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOCN.A_UniqueId, FXmlTagOCN.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCN.A_Name, FXmlTagOCN.D_Name);
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
                    FOpcDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagOCN.A_Name, FXmlTagOCN.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCN.A_Description, FXmlTagOCN.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagOCN.A_Description, FXmlTagOCN.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagOCN.A_FontColor, FXmlTagOCN.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagOCN.A_FontColor, FXmlTagOCN.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOCN.A_FontBold, FXmlTagOCN.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagOCN.A_FontBold, FXmlTagOCN.D_FontBold, FBoolean.fromBool(value), true);
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

        public FOpcConditionMode fConditionMode
        {
            get
            {
                try
                {
                    return FEnumConverter.toOpcConditionMode(this.fXmlNode.get_attrVal(FXmlTagOCN.A_ConditionMode, FXmlTagOCN.D_ConditionMode));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FOpcConditionMode.Expression;
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
                    // 자식이 존재하는 FOpcCondition의 ConditionMode는 변경할 수 없다.
                    // ***
                    if (this.hasChild)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0013, "Object's Child"));
                    }

                    // --

                    if (this.fConditionMode == FOpcConditionMode.Expression)
                    {
                        resetMessage(false);
                    }
                    else
                    {
                        resetDevice(false);
                    }

                    // --

                    if (value == FOpcConditionMode.Connection)
                    {
                        this.fXmlNode.set_attrVal(FXmlTagOCN.A_ConnectionState, FXmlTagOCN.D_ConnectionState, FEnumConverter.fromDeviceState(FDeviceState.Closed));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagOCN.A_ConditionMode, FXmlTagOCN.D_ConditionMode, FEnumConverter.fromOpcConditionMode(value), true);
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
                    return FEnumConverter.toDeviceState(this.fXmlNode.get_attrVal(FXmlTagOCN.A_ConnectionState, FXmlTagOCN.D_ConnectionState));
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
                    if (this.fConditionMode != FOpcConditionMode.Connection)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Condition Mode", "Connection"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagOCN.A_ConnectionState, FXmlTagOCN.D_ConnectionState, FEnumConverter.fromDeviceState(value), true);
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

        public FOpcDevice fDevice
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagOCN.A_OpcDeviceId, FXmlTagOCN.D_OpcDeviceId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagODM.E_OpcDeviceModeling +
                        "/" + FXmlTagODV.E_OpcDevice + "[@" + FXmlTagODV.A_UniqueId + "='" + id + "']";
                    // --
                    return new FOpcDevice(this.fOcdCore, this.fOpcDriver.fXmlNode.selectSingleNode(xpath));
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

        public FOpcSession fSession
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagOCN.A_OpcSessionId, FXmlTagOCN.D_OpcSessionId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagODM.E_OpcDeviceModeling +
                        "/" + FXmlTagODV.E_OpcDevice +
                        "/" + FXmlTagOSN.E_OpcSession + "[@" + FXmlTagOSN.A_UniqueId + "='" + id + "']";
                    // --
                    return new FOpcSession(this.fOcdCore, this.fOpcDriver.fXmlNode.selectSingleNode(xpath));
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

        public FOpcMessage fMessage
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagOCN.A_OpcMessageId, FXmlTagOCN.D_OpcMessageId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagOLM.E_OpcLibraryModeling +
                        "/" + FXmlTagOLG.E_OpcLibraryGroup +
                        "/" + FXmlTagOLB.E_OpcLibrary +
                        "/" + FXmlTagOML.E_OpcMessageList +
                        "/" + FXmlTagOMS.E_OpcMessages +
                        "/" + FXmlTagOMG.E_OpcMessage + "[@" + FXmlTagOMG.A_UniqueId + "='" + id + "']";
                    // --
                    return new FOpcMessage(this.fOcdCore, this.fOpcDriver.fXmlNode.selectSingleNode(xpath));
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

        internal string messageName
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOCN.A_OpcMessageName, FXmlTagOCN.D_OpcMessageName);
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
                    // --

                    this.fXmlNode.set_attrVal(FXmlTagOCN.A_OpcMessageName, FXmlTagOCN.D_OpcMessageName, value);
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

        internal string parentName
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOCN.A_ParentName, FXmlTagOCN.D_ParentName);
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
                    // --

                    this.fXmlNode.set_attrVal(FXmlTagOCN.A_ParentName, FXmlTagOCN.D_ParentName, value);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCN.A_UserTag1, FXmlTagOCN.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagOCN.A_UserTag1, FXmlTagOCN.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCN.A_UserTag2, FXmlTagOCN.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagOCN.A_UserTag2, FXmlTagOCN.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCN.A_UserTag3, FXmlTagOCN.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagOCN.A_UserTag3, FXmlTagOCN.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCN.A_UserTag4, FXmlTagOCN.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagOCN.A_UserTag4, FXmlTagOCN.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCN.A_UserTag5, FXmlTagOCN.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagOCN.A_UserTag5, FXmlTagOCN.D_UserTag5, value, true);
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

        public FOpcTrigger fParent
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

                    return new FOpcTrigger(this.fOcdCore, this.fXmlNode.fParentNode);
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

        public FOpcCondition fPreviousSibling
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

                    return new FOpcCondition(this.fOcdCore, this.fXmlNode.fPreviousSibling);
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

        public FOpcCondition fNextSibling
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

                    return new FOpcCondition(this.fOcdCore, this.fXmlNode.fNextSibling);
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

        public FOpcExpressionCollection fChildOpcExpressionCollection
        {
            get
            {
                try
                {
                    return new FOpcExpressionCollection(this.fOcdCore, this.fXmlNode.selectNodes(FXmlTagOEP.E_OpcExpression));
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
                            "../../" + FXmlTagOTR.E_OpcTrigger + "[@" + FXmlTagOTR.A_UniqueId + "='" + fParent.uniqueIdToString + "']";
                    }
                    return new FObjectCollection(this.fOcdCore, this.fXmlNode.selectNodes(xpath));
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
                            "../../../../../../" + FXmlTagODM.E_OpcDeviceModeling +
                            "/" + FXmlTagODV.E_OpcDevice + "[@" + FXmlTagODV.A_UniqueId + "='" + this.fDevice.uniqueIdToString + "']";
                        // --
                        if (this.hasSession && this.hasMessage)
                        {
                            xpath +=
                                " | " +
                                "../../../../../../" + FXmlTagODM.E_OpcDeviceModeling +
                                "/" + FXmlTagODV.E_OpcDevice +
                                "/" + FXmlTagOSN.E_OpcSession + "[@" + FXmlTagOSN.A_UniqueId + "='" + this.fSession.uniqueIdToString + "']" +
                                " | " +
                                "../../../../../../" + FXmlTagOLM.E_OpcLibraryModeling +
                                "/" + FXmlTagOLG.E_OpcLibraryGroup +
                                "/" + FXmlTagOLB.E_OpcLibrary +
                                "/" + FXmlTagOML.E_OpcMessageList +
                                "/" + FXmlTagOMS.E_OpcMessages +
                                "/" + FXmlTagOMG.E_OpcMessage + "[@" + FXmlTagOMG.A_UniqueId + "='" + this.fMessage.uniqueIdToString + "']";
                        }
                    }
                    else
                    {
                        xpath = "NULL";
                    }
                    
                    // --
                    
                    return new FObjectCollection(this.fOcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return this.fXmlNode.containsNode(FXmlTagOEP.E_OpcExpression);
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
                    if (this.fXmlNode.get_attrVal(FXmlTagOCN.A_OpcDeviceId, FXmlTagOCN.D_OpcDeviceId) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagOCN.A_OpcSessionId, FXmlTagOCN.D_OpcSessionId) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagOCN.A_OpcMessageId, FXmlTagOCN.D_OpcMessageId) == string.Empty)
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
                    if (this.fConditionMode == FOpcConditionMode.Connection)
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
                        !FClipboard.containsData(FCbObjectFormat.OpcCondition)
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
                    if (!FClipboard.containsData(FCbObjectFormat.OpcExpression))
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
            FOpcMessage fOmg = null;
            string info = string.Empty;

            try
            {
                info = this.name;
                
                // --

                if (option == FStringOption.Detail)
                {
                    if (this.hasMessage)
                    {
                        fOmg = this.fMessage;
                        // --
                        info +=
                            " Msg.=[" + this.fDevice.name + " / " + this.fSession.name + " / " + fOmg.name + "]";
                    }
                    else
                    {
                        if (this.fConditionMode == FOpcConditionMode.Connection)
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
                fOmg = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcExpression appendChildOpcExpression(
            FOpcExpression fNewChild
            )
        {
            try
            {
                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // ***
                // OPC Condition의 Mode가 Connection일 경우 OPC Expression를 추가할 수 없다.                
                // ***
                if (this.fConditionMode == FOpcConditionMode.Connection)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Condition's Mode", "Expression"));
                }

                // --

                fNewChild.replace(this.fOcdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));                
                // --                
                if (this.isModelingObject)
                {
                    FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fOpcDriver, this, fNewChild)
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

        public FOpcExpression insertBeforeChildOpcExpression(
            FOpcExpression fNewChild,
            FOpcExpression fRefChild
            )
        {
            try
            {
                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // ***
                // OPC Condition의 Mode가 Connection일 경우 OPC Expression를 추가할 수 없다.                
                // ***
                if (this.fConditionMode == FOpcConditionMode.Connection)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Condition's Mode", "Expression"));
                }

                // --

                fNewChild.replace(this.fOcdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                // --                
                if (this.isModelingObject)
                {
                    FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                    // ---
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this.fOpcDriver, this, fNewChild)
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

        public FOpcExpression insertAfterChildOpcExpression(
            FOpcExpression fNewChild,
            FOpcExpression fRefChild
            )
        {
            try
            {
                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // ***
                // OPC Condition의 Mode가 Connection일 경우 OPC Expression를 추가할 수 없다.
                // ***
                if (this.fConditionMode == FOpcConditionMode.Connection)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Condition's Mode", "Expression"));
                }

                // --

                fNewChild.replace(this.fOcdCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                // --                
                if (this.isModelingObject)
                {
                    FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this.fOpcDriver, this, fNewChild)
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
                FOpcDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);                

                // --

                resetRelation();

                // --

                fParent = this.fParent;
                isModelingObject = this.isModelingObject;
                this.replace(this.fOcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));

                // --

                if (isModelingObject)
                {
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fOpcDriver, fParent, this)
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

        public FOpcExpression removeChildOpcExpression(
            FOpcExpression fChild
            )
        {
            try
            {
                FOpcDriverCommon.validateRemoveChildObject(this.fXmlNode, fChild.fXmlNode);

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

        public void removeChildOpcExpression(
            FOpcExpression[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FOpcExpression fOep in fChilds)
                {
                    FOpcDriverCommon.validateRemoveChildObject(this.fXmlNode, fOep.fXmlNode);
                }

                // --

                foreach (FOpcExpression fOep in fChilds)
                {
                    fOep.remove();
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

        public void removeAllChildOpcExpression(
            )
        {
            FOpcExpressionCollection fOepCollction = null;

            try
            {
                fOepCollction = this.fChildOpcExpressionCollection;
                if (fOepCollction.count == 0)
                {
                    return;
                }

                // --

                foreach (FOpcExpression fPep in fOepCollction)
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
                if (fOepCollction != null)
                {
                    fOepCollction.Dispose();
                    fOepCollction = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void setMessage(
            FOpcDevice fOpcDevice,
            FOpcSession fOpcSession,
            FOpcMessage fOpcMessage
            )
        {
            string oldOdvId = string.Empty;
            string oldOsnId = string.Empty;
            string oldOmgId = string.Empty;
            string newOdvId = string.Empty;
            string newOsnId = string.Empty;
            string newOmgId = string.Empty;

            try
            {
                // ***
                // OPc Device 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fOpcDevice.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "OPC Device", "Modeling File"));
                }

                // ***
                // OPC Session 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fOpcSession.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "OPC Session", "Modeling File"));
                }

                // ***
                // OPC Message 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fOpcMessage.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "OPC Message", "Modeling File"));
                }

                // ***
                // OPC Condition 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "OPC Condition", "Modeling File"));
                }

                // ***
                // OPC Device와 OPC Condition의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fOpcDevice))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the OPC Device and the OPC Condition", "same"));
                }

                // ***
                // OPC Session과 OPC Condition의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fOpcSession))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the OPC Session and the OPC Condition", "same"));
                }

                // ***
                // OPC Message와 OPC Condition의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fOpcMessage))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the OPC Message and the OPC Condition", "same"));
                }

                // ***
                // OPC Session 개체가 OPC Device 개체의 자식인지 검사
                // ***
                if (!fOpcDevice.containsObject(fOpcSession))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "OPC Session", "OPC Device"));
                }

                // ***
                // OPC Session의 Library와 OPC Message의 Library가 동일한지 검사
                // ***
                if (fOpcSession.fLibrary != fOpcMessage.fAncestorOpcLibrary)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "OPC Library of the OPC Session and the OPC Message", "same"));
                }

                // --

                oldOdvId = this.fXmlNode.get_attrVal(FXmlTagOCN.A_OpcDeviceId, FXmlTagOCN.D_OpcDeviceId);
                oldOsnId = this.fXmlNode.get_attrVal(FXmlTagOCN.A_OpcSessionId, FXmlTagOCN.D_OpcSessionId);
                oldOmgId = this.fXmlNode.get_attrVal(FXmlTagOCN.A_OpcMessageId, FXmlTagOCN.D_OpcMessageId);
                // --
                newOdvId = fOpcDevice.uniqueIdToString;
                newOsnId = fOpcSession.uniqueIdToString;
                newOmgId = fOpcMessage.uniqueIdToString;
                // --
                if (oldOdvId == newOdvId && oldOsnId == newOsnId && oldOmgId == newOmgId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 OPC Message가 존재할 경우 Reset 한다.
                // ***
                if (oldOmgId != string.Empty)
                {
                    resetMessage(false, true);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagOCN.A_OpcDeviceId, FXmlTagOCN.D_OpcDeviceId, newOdvId, false);
                this.fXmlNode.set_attrVal(FXmlTagOCN.A_OpcSessionId, FXmlTagOCN.D_OpcSessionId, newOsnId, false);
                this.fXmlNode.set_attrVal(FXmlTagOCN.A_OpcMessageId, FXmlTagOCN.D_OpcMessageId, newOmgId, true);
                // --
                fOpcSession.lockObject();
                fOpcMessage.lockObject();
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
            FOpcDevice fOdv = null;
            FOpcSession fOsn = null;
            FOpcMessage fOmg = null;

            try
            {
                fOdv = this.fDevice;
                fOsn = this.fSession;
                fOmg = this.fMessage;
                if (fOdv == null && fOsn == null && fOmg == null)
                {
                    return;
                }

                // --

                // ***
                // 자식 OPC Expression Reset 처리
                // ***
                foreach (FOpcExpression fOep in this.fChildOpcExpressionCollection)
                {
                    fOep.resetOperand(isExpressionModifyEvent);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagOCN.A_OpcDeviceId, FXmlTagOCN.D_OpcDeviceId, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagOCN.A_OpcSessionId, FXmlTagOCN.D_OpcSessionId, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagOCN.A_OpcMessageId, FXmlTagOCN.D_OpcMessageId, string.Empty, isConditionModifyEvent);
                
                // --

                if (fOmg != null)
                {
                    fOmg.unlockObject();
                }

                if (fOsn != null)
                {
                    fOsn.unlockObject();
                }

                if (fOdv != null)
                {
                    fOdv.unlockObject();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOdv = null;
                fOsn = null;
                fOmg = null;
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
            FOpcDevice fOpcDevice
            )
        {
            string oldOdvId = string.Empty;
            string newOdvId = string.Empty;

            try
            {
                // ***
                // OPC Device 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fOpcDevice.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "OPC Device", "Modeling File"));
                }
                               
                // ***
                // OPC Condition 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "OPC Condition", "Modeling File"));
                }

                // ***
                // OPC Device와 OPC Condition의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fOpcDevice))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the OPC Device and the OPC Condition", "same"));
                }
                
                // --

                oldOdvId = this.fXmlNode.get_attrVal(FXmlTagOCN.A_OpcDeviceId, FXmlTagOCN.D_OpcDeviceId);
                // --
                newOdvId = fOpcDevice.uniqueIdToString;
                // --
                if (oldOdvId == newOdvId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 OPC Device가 존재할 경우 Reset 한다.
                // ***
                if (oldOdvId != string.Empty)
                {
                    resetDevice(false);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagOCN.A_OpcDeviceId, FXmlTagOCN.D_OpcDeviceId, newOdvId, true);
                // --
                fOpcDevice.lockObject();
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
            FOpcDevice fOpcDevice = null;
            try
            {
                fOpcDevice = this.fDevice;
                if (fOpcDevice == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagOCN.A_ConnectionState, FXmlTagOCN.D_ConnectionState, "", false);
                this.fXmlNode.set_attrVal(FXmlTagOCN.A_OpcDeviceId, FXmlTagOCN.D_OpcDeviceId, string.Empty, isConditionModifyEvent);
                // --
                fOpcDevice.unlockObject();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOpcDevice = null;
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
                foreach (FOpcExpression fOep in this.fChildOpcExpressionCollection)
                {
                    buildExpression(fOep, exp);
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
            FOpcExpression fOep,
            StringBuilder exp
            )
        {
            FIOpcOperand fOpd = null;
            FFormat fFormat;

            try
            {
                if (fOep.fPreviousSibling != null)
                {
                    exp.Append(" " + FEnumConverter.toLogicalExp(fOep.fLogical) + " ");
                }

                // --

                if (fOep.fExpressionType == FExpressionType.Bracket)
                {
                    exp.Append("(");
                    foreach (FOpcExpression fChild in fOep.fChildOpcExpressionCollection)
                    {
                        buildExpression(fChild, exp);
                    }
                    exp.Append(")");
                }
                else
                {
                    fFormat = fOep.fValueFormat;
                    fOpd = fOep.fOperand;

                    // --

                    if (fOpd == null)
                    {
                        exp.Append("'N/A'");
                    }
                    else if (fOpd.fOpcOperandType == FOpcOperandType.OpcItem)
                    {
                        exp.Append(((FOpcItem)fOpd).name);
                    }
                    else if (fOpd.fOpcOperandType == FOpcOperandType.OpcEventItem)
                    {
                        exp.Append(((FOpcEventItem)fOpd).name);
                    }
                    else if (fOpd.fOpcOperandType == FOpcOperandType.Environment)
                    {
                        exp.Append(((FEnvironment)fOpd).name);
                    }
                    else if (fOpd.fOpcOperandType == FOpcOperandType.EquipmentState)
                    {
                        exp.Append(((FEquipmentState)fOpd).name);
                    }
                    // --
                    exp.Append("[" + fOep.operandIndex.ToString() + "]");
                    // --
                    exp.Append(" " + FEnumConverter.toOperationExp(fOep.fOperation) + " ");
                    // --
                    if (fOep.fExpressionValueType == FExpressionValueType.Value)
                    {
                        if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                        {
                            exp.Append("\"" + fOep.encodingValue + "\"");
                        }
                        else
                        {
                            exp.Append("\"" + fOep.stringValue + "\"");
                        }
                    }
                    else
                    {
                        exp.Append(fOep.fResource.ToString());
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
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fOpcDriver, this.fParent, this)
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
                fXmlNode.set_attrVal(FXmlTagOCN.A_OpcDeviceId, FXmlTagOCN.D_OpcDeviceId, FXmlTagOCN.D_OpcDeviceId);
                fXmlNode.set_attrVal(FXmlTagOCN.A_OpcSessionId, FXmlTagOCN.D_OpcSessionId, FXmlTagOCN.D_OpcSessionId);
                fXmlNode.set_attrVal(FXmlTagOCN.A_OpcMessageId, FXmlTagOCN.D_OpcMessageId, FXmlTagOCN.D_OpcMessageId);

                // --

                foreach (FXmlNode fXmlNodePep in fXmlNode.selectNodes(FXmlTagOEP.E_OpcExpression))
                {
                    FOpcExpression.resetFlowNode(fXmlNodePep);
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
                this.copyObject(FCbObjectFormat.OpcCondition, fXmlNode);
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
        
        // Add by Jeff.Kim 2015.12.01
        // Flow Reset 없이 Copy 한다. Expression 정보를 그대로 사용하기 위함.
        public void forceCopy(
            )
        {
            FIOpcOperand fOpd = null;
            // --
            FXmlNode fXmlNode = null;
            string name = string.Empty;

            try
            {
                // --
                foreach (FOpcExpression fOpcExp in fChildOpcExpressionCollection)
                {
                    // --
                    if (fOpcExp.hasOperand)
                    {
                        fOpd = fOpcExp.fOperand;
                        if (fOpd.fOpcOperandType == FOpcOperandType.OpcItem)
                        {
                            name = ((FOpcItem)fOpd).name;
                        }
                        else if (fOpd.fOpcOperandType == FOpcOperandType.OpcEventItem)
                        {
                            name =  ((FOpcEventItem)fOpd).name;
                        }
                        else if (fOpd.fOpcOperandType == FOpcOperandType.Environment)
                        {
                            name =  ((FEnvironment)fOpd).name;
                        }
                        else if (fOpd.fOpcOperandType == FOpcOperandType.EquipmentState)
                        {
                            name =  ((FEquipmentState)fOpd).name;
                        }
                        // --
                        fOpcExp.operandName2 = name;
                    }
                }

                // --

                fXmlNode = this.fXmlNode.clone(true);
                // --
                // Add by Jeff.Kim 2015.12.01
                // Expression osm 파일 일괄 적용을 위해서, Message Name을 Set 한다. 
                // 대상 Osm 파일에 해당 Message를 사용하는 Condition을 찾기 위함.
                if (fMessage != null)
                {
                    fXmlNode.set_attrVal(FXmlTagOCN.A_OpcMessageName, FXmlTagOCN.D_OpcMessageName, fMessage.name);
                }

                // --

                if (fParent != null)
                {
                    fXmlNode.set_attrVal(FXmlTagOCN.A_ParentName, FXmlTagOCN.D_ParentName, fParent.name);
                }

                // --
                // 기존 Operand 정보는 Reset
                fXmlNode.set_attrVal(FXmlTagOCN.A_OpcDeviceId, FXmlTagOCN.D_OpcDeviceId, FXmlTagOCN.D_OpcDeviceId);
                fXmlNode.set_attrVal(FXmlTagOCN.A_OpcSessionId, FXmlTagOCN.D_OpcSessionId, FXmlTagOCN.D_OpcSessionId);
                fXmlNode.set_attrVal(FXmlTagOCN.A_OpcMessageId, FXmlTagOCN.D_OpcMessageId, FXmlTagOCN.D_OpcMessageId);

                // --
                this.copyObject(FCbObjectFormat.OpcCondition, fXmlNode);

                // --
                // Operand Name 2값 Reset
                foreach (FOpcExpression fOpcExp in fChildOpcExpressionCollection)
                {
                    // --                    
                    fOpcExp.operandName2 = string.Empty;
                }
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
                FOpcDriverCommon.validateCutObject(this.fXmlNode);

                // --

                this.remove();

                // --

                resetFlowNode(this.fXmlNode);
                this.copyObject(FCbObjectFormat.OpcCondition, this.fXmlNode);
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

        public FOpcCondition pasteSibling(
            )
        {
            FOpcCondition fOpcCondition = null;

            try
            {
                FOpcDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.OpcCondition);

                // --

                fOpcCondition = (FOpcCondition)this.pasteObject(FCbObjectFormat.OpcCondition);
                return this.fParent.insertAfterChildOpcCondition(fOpcCondition, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOpcCondition = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcExpression pasteChild(
            )
        {
            FOpcExpression fOpcExpression = null;

            try
            {
                FOpcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.OpcExpression);

                // --

                fOpcExpression = (FOpcExpression)this.pasteObject(FCbObjectFormat.OpcExpression);
                return this.appendChildOpcExpression(fOpcExpression);
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
                FOpcDriverCommon.validateMoveUpObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fOcdCore, this.fXmlNode.moveUp());

                // --

                if (isModelingObject)
                {
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveUpCompleted, this.fOpcDriver, fParent, this)
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
                FOpcDriverCommon.validateMoveDownObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fOcdCore, this.fXmlNode.moveDown());

                // --

                if (isModelingObject)
                {
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveDownCompleted, this.fOpcDriver, fParent, this)
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
            FOpcCondition fRefObject
            )
        {
            try
            {
                FOpcDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

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

                this.replace(this.fOcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fOcdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                this.fOcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fOpcDriver, this, fRefObject)
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
            FOpcTrigger fRefObject
            )
        {
            try
            {
                FOpcDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

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

                if (fRefObject.fChildOpcConditionCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildOpcConditionCollection[fRefObject.fChildOpcConditionCollection.count - 1]))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "same localtion"));
                    }
                }

                // --

                this.replace(this.fOcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fOcdCore, fRefObject.fXmlNode.appendChild(this.fXmlNode));                

                // --

                this.fOcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fOpcDriver, this, fRefObject)
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

        public FOpcExpressionCollection selectOpcExpressionByName(
            string name
            )
        {
            const string xpath = FXmlTagOEP.E_OpcExpression + "[@" + FXmlTagOEP.A_Name + "='{0}']";

            try
            {
                return new FOpcExpressionCollection(
                    this.fOcdCore,
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

        public FOpcExpression selectSingleOpcExpressionByName(
            string name
            )
        {
            const string xpath = FXmlTagOEP.E_OpcExpression + "[@" + FXmlTagOEP.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FOpcExpression(this.fOcdCore, fXmlNode);
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
