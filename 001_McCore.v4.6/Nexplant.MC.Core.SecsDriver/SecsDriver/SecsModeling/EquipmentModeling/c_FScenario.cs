/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FScenario.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.24
--  Description     : FAMate Core FaSecsDriver Scenario Class 
--  History         : Created by spike.lee at 2011.03.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FScenario : FBaseObject<FScenario>, FIObject
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FScenario(
            FSecsDriver fSecsDriver
            )
            : base(fSecsDriver.fScdCore, FSecsDriverCommon.createXmlNodeSNR(fSecsDriver.fScdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FScenario(
            FScdCore fScdCore,
            FXmlNode fXmlNode
            )
            : base(fScdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FScenario(
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
                    return FObjectType.Scenario;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.Scenario;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSNR.A_UniqueId, FXmlTagSNR.D_UniqueId);
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

        public bool locked
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSNR.A_Locked, FXmlTagSNR.D_Locked));
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

        public string name
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSNR.A_Name, FXmlTagSNR.D_Name);
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

                    this.fXmlNode.set_attrVal(FXmlTagSNR.A_Name, FXmlTagSNR.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSNR.A_Description, FXmlTagSNR.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagSNR.A_Description, FXmlTagSNR.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagSNR.A_FontColor, FXmlTagSNR.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagSNR.A_FontColor, FXmlTagSNR.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSNR.A_FontBold, FXmlTagSNR.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagSNR.A_FontBold, FXmlTagSNR.D_FontBold, FBoolean.fromBool(value), true);
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

        public bool logEnabled
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSNR.A_LogEnabled, FXmlTagSNR.D_LogEnabled));
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
                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSNR.A_LogEnabled, FXmlTagSNR.D_LogEnabled, FBoolean.fromBool(value), true);
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

        // ***
        // 2017.07.04 by spike.lee
        // Log Level Add
        // ***
        public FLogLevel logLevel
        {
            get
            {
                try
                {
                    return FEnumConverter.toLogLevel(this.fXmlNode.get_attrVal(FXmlTagSNR.A_LogLevel, FXmlTagSNR.D_LogLevel));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FLogLevel.Level1;
            }

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagSNR.A_LogLevel, FXmlTagSNR.D_LogLevel, FEnumConverter.fromLogLevel(value), true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSNR.A_UserTag1, FXmlTagSNR.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagSNR.A_UserTag1, FXmlTagSNR.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSNR.A_UserTag2, FXmlTagSNR.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagSNR.A_UserTag2, FXmlTagSNR.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSNR.A_UserTag3, FXmlTagSNR.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagSNR.A_UserTag3, FXmlTagSNR.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSNR.A_UserTag4, FXmlTagSNR.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagSNR.A_UserTag4, FXmlTagSNR.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSNR.A_UserTag5, FXmlTagSNR.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagSNR.A_UserTag5, FXmlTagSNR.D_UserTag5, value, true);
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

        public FScenarioGroup fParent
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

                    return new FScenarioGroup(this.fScdCore, this.fXmlNode.fParentNode);
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

        public FScenario fPreviousSibling
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fPreviousSibling == null)
                    {
                        return null;
                    }
                    return new FScenario(this.fScdCore, this.fXmlNode.fPreviousSibling);
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

        public FScenario fNextSibling
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fNextSibling == null)
                    {
                        return null;
                    }
                    return new FScenario(this.fScdCore, this.fXmlNode.fNextSibling);
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

        public FFlowCollection fChildFlowCollection
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath =
                        FXmlTagSTR.E_SecsTrigger +
                        " | " +
                        FXmlTagSTN.E_SecsTransmitter +
                        " | " +
                        FXmlTagHTR.E_HostTrigger +
                        " | " +
                        FXmlTagHTN.E_HostTransmitter +
                        " | " +
                        FXmlTagESA.E_EquipmentStateSetAlterer +
                        " | " +
                        FXmlTagJDM.E_Judgement +
                        " | " +
                        FXmlTagMAP.E_Mapper +
                        " | " +
                        FXmlTagSTG.E_Storage +
                        " | " +
                        FXmlTagCBK.E_Callback +
                        " | " +
                        FXmlTagBRN.E_Branch +
                        " | " +
                        FXmlTagCMT.E_Comment +
                        " | " +
                        FXmlTagPAU.E_Pauser +
                        " | " +
                        FXmlTagETP.E_EntryPoint;
                    // --
                    return new FFlowCollection(this.fScdCore, this.fXmlNode.selectNodes(xpath));
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
                    xpath =
                        "../../../../" + FXmlTagEQM.E_EquipmentModeling +
                        "/" + FXmlTagEQP.E_Equipment +
                        "/" + FXmlTagSNG.E_ScenarioGroup +
                        "/" + FXmlTagSNR.E_Scenario +
                        "/" + FXmlTagJDM.E_Judgement + "[@" + FXmlTagJDM.A_LocationId + "='" + this.uniqueIdToString + "']" +
                        " | " +
                        "../../../../" + FXmlTagEQM.E_EquipmentModeling +
                        "/" + FXmlTagEQP.E_Equipment +
                        "/" + FXmlTagSNG.E_ScenarioGroup +
                        "/" + FXmlTagSNR.E_Scenario +
                        "/" + FXmlTagBRN.E_Branch + "[@" + FXmlTagBRN.A_LocationId + "='" + this.uniqueIdToString + "']" +
                        " | " +
                        "../../../../" + FXmlTagEQM.E_EquipmentModeling +
                        "/" + FXmlTagEQP.E_Equipment +
                        "/" + FXmlTagSNG.E_ScenarioGroup +
                        "/" + FXmlTagSNR.E_Scenario +
                        "/" + FXmlTagSTG.E_Storage + "[@" + FXmlTagSTG.A_LocationId + "='" + this.uniqueIdToString + "']";
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

        public FObjectCollection fInclusionObjectCollection
        {
            get
            {
                try
                {
                    return new FObjectCollection(this.fScdCore, this.fXmlNode.selectNodes("NULL"));
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
                string xpath = string.Empty;

                try
                {
                    xpath =
                        FXmlTagSTR.E_SecsTrigger +
                        " | " +
                        FXmlTagSTN.E_SecsTransmitter +
                        " | " +
                        FXmlTagHTR.E_HostTrigger +
                        " | " +
                        FXmlTagHTN.E_HostTransmitter +
                        " | " +
                        FXmlTagESA.E_EquipmentStateSetAlterer +
                        " | " +
                        FXmlTagJDM.E_Judgement +
                        " | " +
                        FXmlTagMAP.E_Mapper +
                        " | " +
                        FXmlTagSTG.E_Storage +
                        " | " +
                        FXmlTagCBK.E_Callback +
                        " | " +
                        FXmlTagBRN.E_Branch +
                        " | " +
                        FXmlTagCMT.E_Comment +
                        " | " +
                        FXmlTagETP.E_EntryPoint;
                    // --
                    return this.fXmlNode.containsNode(xpath);
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
                    if (this.fXmlNode.fParentNode == null || this.locked)
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
                    if (this.fXmlNode.fParentNode == null || this.locked)
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
                        !FClipboard.containsData(FCbObjectFormat.Scenario)
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
                    if (
                        FClipboard.containsData(FCbObjectFormat.SecsTrigger) ||
                        FClipboard.containsData(FCbObjectFormat.SecsTransmitter) ||
                        FClipboard.containsData(FCbObjectFormat.HostTrigger) ||
                        FClipboard.containsData(FCbObjectFormat.HostTransmitter) ||
                        FClipboard.containsData(FCbObjectFormat.EquipmentStateSetAlterer) ||
                        FClipboard.containsData(FCbObjectFormat.Judgement) ||
                        FClipboard.containsData(FCbObjectFormat.Mapper) ||
                        FClipboard.containsData(FCbObjectFormat.Storage) ||
                        FClipboard.containsData(FCbObjectFormat.Callback) ||
                        FClipboard.containsData(FCbObjectFormat.Branch) ||
                        FClipboard.containsData(FCbObjectFormat.Pauser) ||
                        FClipboard.containsData(FCbObjectFormat.Comment) ||
                        FClipboard.containsData(FCbObjectFormat.EntryPoint)
                        )
                    {
                        return true;
                    }
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public string ToString(
            FStringOption option
            )
        {
            string info = string.Empty;

            try
            {
                info = this.name;
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

            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void replaceChildFlow(
            FIFlow fNewChild, 
            FXmlNode fXmlNodeNewChild
            )
        {
            try
            {
                if (fNewChild.fFlowType == FFlowType.SecsTrigger)
                {
                    ((FSecsTrigger)fNewChild).replace(this.fScdCore, fXmlNodeNewChild);
                }
                else if (fNewChild.fFlowType == FFlowType.SecsTransmitter)
                {
                    ((FSecsTransmitter)fNewChild).replace(this.fScdCore, fXmlNodeNewChild);
                }
                else if (fNewChild.fFlowType == FFlowType.HostTrigger)
                {
                    ((FHostTrigger)fNewChild).replace(this.fScdCore, fXmlNodeNewChild);
                }
                else if (fNewChild.fFlowType == FFlowType.HostTransmitter)
                {
                    ((FHostTransmitter)fNewChild).replace(this.fScdCore, fXmlNodeNewChild);
                }
                else if (fNewChild.fFlowType == FFlowType.EquipmentStateSetAlterer)
                {
                    ((FEquipmentStateSetAlterer)fNewChild).replace(this.fScdCore, fXmlNodeNewChild);
                }
                else if (fNewChild.fFlowType == FFlowType.Judgement)
                {
                    ((FJudgement)fNewChild).replace(this.fScdCore, fXmlNodeNewChild);
                }
                else if (fNewChild.fFlowType == FFlowType.Mapper)
                {
                    ((FMapper)fNewChild).replace(this.fScdCore, fXmlNodeNewChild);
                }
                else if (fNewChild.fFlowType == FFlowType.Storage)
                {
                    ((FStorage)fNewChild).replace(this.fScdCore, fXmlNodeNewChild);
                }
                else if (fNewChild.fFlowType == FFlowType.Callback)
                {
                    ((FCallback)fNewChild).replace(this.fScdCore, fXmlNodeNewChild);
                }
                else if (fNewChild.fFlowType == FFlowType.Branch)
                {
                    ((FBranch)fNewChild).replace(this.fScdCore, fXmlNodeNewChild);
                }
                else if (fNewChild.fFlowType == FFlowType.Comment)
                {
                    ((FComment)fNewChild).replace(this.fScdCore, fXmlNodeNewChild);
                }
                else if (fNewChild.fFlowType == FFlowType.Pauser)
                {
                    ((FPauser)fNewChild).replace(this.fScdCore, fXmlNodeNewChild);
                }
                else if (fNewChild.fFlowType == FFlowType.EntryPoint)
                {
                    ((FEntryPoint)fNewChild).replace(this.fScdCore, fXmlNodeNewChild);
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

        public FIFlow appendChildFlow(
            FIFlow fNewChild
            )
        {
            FXmlNode fXmlNodeNewChild = null;

            try
            {
                fXmlNodeNewChild = FSecsDriverCommon.getObjectXmlNode((FIObject)fNewChild);
                FSecsDriverCommon.validateNewChildObject(fXmlNodeNewChild);

                // --

                replaceChildFlow(fNewChild, this.fXmlNode.appendChild(fXmlNodeNewChild));                
                // --
                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fXmlNodeNewChild);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fSecsDriver, this, (FIObject)fNewChild)
                        );
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
                fXmlNodeNewChild = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIFlow insertBeforeChildFlow(
            FIFlow fNewChild,
            FIFlow fRefChild
            )
        {
            FXmlNode fXmlNodeNewChild = null;
            FXmlNode fXmlNodeRefChild = null;

            try
            {
                fXmlNodeNewChild = FSecsDriverCommon.getObjectXmlNode((FIObject)fNewChild);
                fXmlNodeRefChild = FSecsDriverCommon.getObjectXmlNode((FIObject)fRefChild);
                FSecsDriverCommon.validateNewChildObject(fXmlNodeNewChild);                
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fXmlNodeRefChild);

                // --

                replaceChildFlow(fNewChild, this.fXmlNode.insertBefore(fXmlNodeNewChild, fXmlNodeRefChild));                
                // --                
                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fXmlNodeNewChild);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this.fSecsDriver, this, (FIObject)fNewChild)
                        );
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
                fXmlNodeNewChild = null;
                fXmlNodeRefChild = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIFlow insertAfterChildFlow(
            FIFlow fNewChild,
            FIFlow fRefChild
            )
        {
            FXmlNode fXmlNodeNewChild = null;
            FXmlNode fXmlNodeRefChild = null;

            try
            {
                fXmlNodeNewChild = FSecsDriverCommon.getObjectXmlNode((FIObject)fNewChild);
                fXmlNodeRefChild = FSecsDriverCommon.getObjectXmlNode((FIObject)fRefChild);
                FSecsDriverCommon.validateNewChildObject(fXmlNodeNewChild);
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fXmlNodeRefChild);

                // --

                replaceChildFlow(fNewChild, this.fXmlNode.insertAfter(fXmlNodeNewChild, fXmlNodeRefChild));                
                // --                
                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fXmlNodeNewChild);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this.fSecsDriver, this, (FIObject)fNewChild)
                        );
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
                fXmlNodeNewChild = null;
                fXmlNodeRefChild = null;
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

        private void removeChild(
            FIFlow fChild
            )
        {
            try
            {
                if (fChild.fFlowType == FFlowType.SecsTrigger)
                {
                    ((FSecsTrigger)fChild).remove();
                }
                else if (fChild.fFlowType == FFlowType.SecsTransmitter)
                {
                    ((FSecsTransmitter)fChild).remove();
                }
                else if (fChild.fFlowType == FFlowType.HostTrigger)
                {
                    ((FHostTrigger)fChild).remove();
                }
                else if (fChild.fFlowType == FFlowType.HostTransmitter)
                {
                    ((FHostTransmitter)fChild).remove();
                }
                else if (fChild.fFlowType == FFlowType.EquipmentStateSetAlterer)
                {
                    ((FEquipmentStateSetAlterer)fChild).remove();
                }
                else if (fChild.fFlowType == FFlowType.Judgement)
                {
                    ((FJudgement)fChild).remove();
                }
                else if (fChild.fFlowType == FFlowType.Mapper)
                {
                    ((FMapper)fChild).remove();
                }
                else if (fChild.fFlowType == FFlowType.Storage)
                {
                    ((FStorage)fChild).remove();
                }
                else if (fChild.fFlowType == FFlowType.Callback)
                {
                    ((FCallback)fChild).remove();
                }
                else if (fChild.fFlowType == FFlowType.Branch)
                {
                    ((FBranch)fChild).remove();
                }
                else if (fChild.fFlowType == FFlowType.Comment)
                {
                    ((FComment)fChild).remove();
                }
                else if (fChild.fFlowType == FFlowType.Pauser)
                {
                    ((FPauser)fChild).remove();
                }
                else if (fChild.fFlowType == FFlowType.EntryPoint)
                {
                    ((FEntryPoint)fChild).remove();
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

        public FIFlow removeChildFlow(
            FIFlow fChild
            )
        {
            FXmlNode fXmlNodeChild = null;

            try
            {
                fXmlNodeChild = FSecsDriverCommon.getObjectXmlNode((FIObject)fChild);
                FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode, fXmlNodeChild);                

                // --

                removeChild(fChild);

                // --

                return fChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeChild = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeChildFlow(
            FIFlow[] fChilds
            )
        {
            FXmlNode fXmlNodeChild = null;

            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FIFlow fFlw in fChilds)
                {
                    fXmlNodeChild = FSecsDriverCommon.getObjectXmlNode((FIObject)fXmlNodeChild);
                    FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode, fXmlNodeChild);                    
                }

                // --

                foreach (FIFlow fFlw in fChilds)
                {
                    removeChild(fFlw);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAllChildFlow(
            )
        {
            FFlowCollection fFlwCollection = null;

            try
            {
                fFlwCollection = this.fChildFlowCollection;
                if (fFlwCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FIFlow fFlw in fFlwCollection)
                {
                    removeChild(fFlw);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fFlwCollection != null)
                {
                    fFlwCollection.Dispose();
                    fFlwCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void resetRelation(
            )
        {
            try
            {
                foreach (FIFlow fFlw in this.fChildFlowCollection)
                {
                    if (fFlw.fFlowType == FFlowType.SecsTrigger)
                    {
                        ((FSecsTrigger)fFlw).resetRelation();
                    }
                    else if (fFlw.fFlowType == FFlowType.SecsTransmitter)
                    {
                        ((FSecsTransmitter)fFlw).resetRelation();
                    }
                    else if (fFlw.fFlowType == FFlowType.HostTrigger)
                    {
                        ((FHostTrigger)fFlw).resetRelation();
                    }
                    else if (fFlw.fFlowType == FFlowType.HostTransmitter)
                    {
                        ((FHostTransmitter)fFlw).resetRelation();
                    }
                    else if (fFlw.fFlowType == FFlowType.EquipmentStateSetAlterer)
                    {
                        ((FEquipmentStateSetAlterer)fFlw).resetRelation();
                    }
                    else if (fFlw.fFlowType == FFlowType.Judgement)
                    {
                        ((FJudgement)fFlw).resetRelation();
                    }
                    else if (fFlw.fFlowType == FFlowType.Mapper)
                    {
                        ((FMapper)fFlw).resetRelation();
                    }
                    else if (fFlw.fFlowType == FFlowType.Storage)
                    {
                        ((FStorage)fFlw).resetRelation();
                    }
                    else if (fFlw.fFlowType == FFlowType.Branch)
                    {
                        ((FBranch)fFlw).resetRelation();
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void lockObject(
            )
        {
            try
            {
                if (this.locked)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagSNR.A_Locked, FXmlTagSNR.D_Locked, FBoolean.True, true);
                this.fParent.lockObject();
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

        internal void unlockObject(
            )
        {
            string xpath = string.Empty;

            try
            {
                if (!this.locked)
                {
                    return;
                }

                // ---

                // ***
                // Scenario 개체가 Branch 개체에 사용되어 있을 경우 Unlock 작업을 취소한다.
                // ***
                xpath =
                    FXmlTagEQM.E_EquipmentModeling +
                    "/" + FXmlTagEQP.E_Equipment +
                    "/" + FXmlTagSNG.E_ScenarioGroup +
                    "/" + FXmlTagSNR.E_Scenario +
                    "/" + FXmlTagBRN.E_Branch + "[@" + FXmlTagBRN.A_LocationId + "='" + this.uniqueIdToString + "']" +
                    " | " +
                    FXmlTagEQM.E_EquipmentModeling +
                    "/" + FXmlTagEQP.E_Equipment +
                    "/" + FXmlTagSNG.E_ScenarioGroup +
                    "/" + FXmlTagSNR.E_Scenario +
                    "/" + FXmlTagJDM.E_Judgement + "[@" + FXmlTagJDM.A_LocationId + "='" + this.uniqueIdToString + "']" +
                    " | " +
                    FXmlTagEQM.E_EquipmentModeling +
                    "/" + FXmlTagEQP.E_Equipment +
                    "/" + FXmlTagSNG.E_ScenarioGroup +
                    "/" + FXmlTagSNR.E_Scenario +
                    "/" + FXmlTagSTG.E_Storage + "[@" + FXmlTagSTG.A_LocationId + "='" + this.uniqueIdToString + "']";
                // --
                if (this.fSecsDriver.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagSNR.A_Locked, FXmlTagSNR.D_Locked, FBoolean.False, true);
                this.fParent.unlockObject();
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
                this.copyObject(FCbObjectFormat.Scenario, fXmlNode);
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
                this.copyObject(FCbObjectFormat.Scenario, this.fXmlNode);
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

        public FScenario pasteSibling(
            )
        {
            FScenario fScenario = null;

            try
            {
                FSecsDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.Scenario);

                // --

                fScenario = (FScenario)this.pasteObject(FCbObjectFormat.Scenario);
                return this.fParent.insertAfterChildScenario(fScenario, this);
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

        public FIFlow pasteChild(
            )
        {
            FIFlow fNewFlowObject = null;

            try
            {
                if (FClipboard.containsData(FCbObjectFormat.SecsTrigger))
                {
                    fNewFlowObject = (FSecsTrigger)this.pasteObject(FCbObjectFormat.SecsTrigger);
                }
                else if (FClipboard.containsData(FCbObjectFormat.SecsTransmitter))
                {
                    fNewFlowObject = (FSecsTransmitter)this.pasteObject(FCbObjectFormat.SecsTransmitter);
                }
                else if (FClipboard.containsData(FCbObjectFormat.HostTrigger))
                {
                    fNewFlowObject = (FHostTrigger)this.pasteObject(FCbObjectFormat.HostTrigger);
                }
                else if (FClipboard.containsData(FCbObjectFormat.HostTransmitter))
                {
                    fNewFlowObject = (FHostTransmitter)this.pasteObject(FCbObjectFormat.HostTransmitter);
                }
                else if (FClipboard.containsData(FCbObjectFormat.EquipmentStateSetAlterer))
                {
                    fNewFlowObject = (FEquipmentStateSetAlterer)this.pasteObject(FCbObjectFormat.EquipmentStateSetAlterer);
                }
                else if (FClipboard.containsData(FCbObjectFormat.Judgement))
                {
                    fNewFlowObject = (FJudgement)this.pasteObject(FCbObjectFormat.Judgement);
                }
                else if (FClipboard.containsData(FCbObjectFormat.Mapper))
                {
                    fNewFlowObject = (FMapper)this.pasteObject(FCbObjectFormat.Mapper);
                }
                else if (FClipboard.containsData(FCbObjectFormat.Storage))
                {
                    fNewFlowObject = (FStorage)this.pasteObject(FCbObjectFormat.Storage);
                }
                else if (FClipboard.containsData(FCbObjectFormat.Callback))
                {
                    fNewFlowObject = (FCallback)this.pasteObject(FCbObjectFormat.Callback);
                }
                else if (FClipboard.containsData(FCbObjectFormat.Branch))
                {
                    fNewFlowObject = (FBranch)this.pasteObject(FCbObjectFormat.Branch);
                }
                else if (FClipboard.containsData(FCbObjectFormat.Comment))
                {
                    fNewFlowObject = (FComment)this.pasteObject(FCbObjectFormat.Comment);
                }
                else if (FClipboard.containsData(FCbObjectFormat.Pauser))
                {
                    fNewFlowObject = (FPauser)this.pasteObject(FCbObjectFormat.Pauser);
                }
                else if (FClipboard.containsData(FCbObjectFormat.EntryPoint))
                {
                    fNewFlowObject = (FEntryPoint)this.pasteObject(FCbObjectFormat.EntryPoint);
                }
                else
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0015, "Object Type"));
                }

                // --

                return this.appendChildFlow(fNewFlowObject);
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
            FScenario fRefObject
            )
        {
            FScenarioGroup fOldParent = null;

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

                // --                

                fOldParent = this.fParent;

                // --

                this.replace(this.fScdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fScdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                if (!this.fParent.Equals(fOldParent) && this.locked)
                {
                    fOldParent.unlockObject();
                    this.fParent.lockObject();
                }

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
                fOldParent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void moveTo(
            FScenarioGroup fRefObject
            )
        {
            FScenarioGroup fOldParent = null;

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

                if (fRefObject.fChildScenarioCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildScenarioCollection[fRefObject.fChildScenarioCollection.count - 1]))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "same localtion"));
                    }
                }

                // --

                fOldParent = this.fParent;

                // --                

                this.replace(this.fScdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fScdCore, fRefObject.fXmlNode.appendChild(this.fXmlNode));

                // --

                if (!fRefObject.Equals(fOldParent) && this.locked)
                {
                    fOldParent.unlockObject();
                    fRefObject.lockObject();
                }

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
                fOldParent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal static void resetFlowNode(
            FXmlNode fXmlNode
            )
        {
            FXmlNodeList fXmlNodeListFlw = null;
            string xpath = string.Empty;

            try
            {
                xpath =
                    FXmlTagSTR.E_SecsTrigger + 
                    " | " +
                    FXmlTagSTN.E_SecsTransmitter + 
                    " | " +
                    FXmlTagHTR.E_HostTrigger + 
                    " | " +
                    FXmlTagHTN.E_HostTransmitter + 
                    " | " +
                    FXmlTagESA.E_EquipmentStateSetAlterer + 
                    " | " +
                    FXmlTagJDM.E_Judgement + 
                    " | " +
                    FXmlTagMAP.E_Mapper + 
                    " | " +
                    FXmlTagSTG.E_Storage + 
                    " | " +
                    FXmlTagCBK.E_Callback + 
                    " | " +
                    FXmlTagBRN.E_Branch;
                // --
                fXmlNodeListFlw = fXmlNode.selectNodes(xpath);
                // --
                foreach (FXmlNode fXmlNodeFlw in fXmlNodeListFlw)
                {
                    if (fXmlNodeFlw.name == FXmlTagSTR.E_SecsTrigger)
                    {
                        FSecsTrigger.resetFlowNode(fXmlNodeFlw);
                    }
                    else if (fXmlNodeFlw.name == FXmlTagSTN.E_SecsTransmitter)
                    {
                        FSecsTransmitter.resetFlowNode(fXmlNodeFlw);
                    }
                    else if (fXmlNodeFlw.name == FXmlTagHTR.E_HostTrigger)
                    {
                        FHostTrigger.resetFlowNode(fXmlNodeFlw);
                    }
                    else if (fXmlNodeFlw.name == FXmlTagHTN.E_HostTransmitter)
                    {
                        FHostTransmitter.resetFlowNode(fXmlNodeFlw);
                    }
                    else if (fXmlNodeFlw.name == FXmlTagESA.E_EquipmentStateSetAlterer)
                    {
                        FEquipmentStateSetAlterer.resetFlowNode(fXmlNodeFlw);
                    }
                    else if (fXmlNodeFlw.name == FXmlTagJDM.E_Judgement)
                    {
                        FJudgement.resetFlowNode(fXmlNodeFlw);
                    }
                    else if (fXmlNodeFlw.name == FXmlTagMAP.E_Mapper)
                    {
                        FMapper.resetFlowNode(fXmlNodeFlw);
                    }
                    else if (fXmlNodeFlw.name == FXmlTagSTG.E_Storage)
                    {
                        FStorage.resetFlowNode(fXmlNodeFlw);
                    }
                    else if (fXmlNodeFlw.name == FXmlTagBRN.E_Branch)
                    {
                        FBranch.resetFlowNode(fXmlNodeFlw);
                    }                   
                }   
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListFlw = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsTrigger selectSingleSecsTriggerByName(
            string name
            )
        {
            const string xpath = FXmlTagSTR.E_SecsTrigger + "[@" + FXmlTagSTR.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsTrigger(this.fScdCore, fXmlNode);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsTransmitter selectSingleSecsTransmitterByName(
            string name
            )
        {
            const string xpath = FXmlTagSTN.E_SecsTransmitter + "[@" + FXmlTagSTN.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsTransmitter(this.fScdCore, fXmlNode);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FHostTrigger selectSingleHostTriggerByName(
            string name
            )
        {
            const string xpath = FXmlTagHTR.E_HostTrigger + "[@" + FXmlTagHTR.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostTrigger(this.fScdCore, fXmlNode);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FHostTransmitter selectSingleHostTransmitterByName(
            string name
            )
        {
            const string xpath = FXmlTagHTN.E_HostTransmitter + "[@" + FXmlTagHTN.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostTransmitter(this.fScdCore, fXmlNode);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentStateSetAlterer selectSingleEquipmentStateSetAltererByName(
            string name
            )
        {
            const string xpath = FXmlTagESA.E_EquipmentStateSetAlterer + "[@" + FXmlTagESA.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FEquipmentStateSetAlterer(this.fScdCore, fXmlNode);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FJudgement selectSingleJudgementByName(
            string name
            )
        {
            const string xpath = FXmlTagJDM.E_Judgement + "[@" + FXmlTagJDM.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FJudgement(this.fScdCore, fXmlNode);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FMapper selectSingleMapperByName(
            string name
            )
        {
            const string xpath = FXmlTagMAP.E_Mapper + "[@" + FXmlTagMAP.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FMapper(this.fScdCore, fXmlNode);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FStorage selectSingleStorageByName(
            string name
            )
        {
            const string xpath = FXmlTagSTG.E_Storage + "[@" + FXmlTagSTG.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FStorage(this.fScdCore, fXmlNode);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FCallback selectSingleCallbackByName(
            string name
            )
        {
            const string xpath = FXmlTagCBK.E_Callback + "[@" + FXmlTagCBK.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FCallback(this.fScdCore, fXmlNode);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FBranch selectSingleBranchByName(
            string name
            )
        {
            const string xpath = FXmlTagBRN.E_Branch + "[@" + FXmlTagBRN.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FBranch(this.fScdCore, fXmlNode);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FPauser selectSinglePauserByName(
            string name
            )
        {
            const string xpath = FXmlTagPAU.E_Pauser + "[@" + FXmlTagPAU.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FPauser(this.fScdCore, fXmlNode);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FComment selectSingleCommentByName(
            string name
            )
        {
            const string xpath = FXmlTagCMT.E_Comment + "[@" + FXmlTagCMT.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FComment(this.fScdCore, fXmlNode);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FEntryPoint selectSingleEntryPointByName(
            string name
            )
        {
            const string xpath = FXmlTagETP.E_EntryPoint + "[@" + FXmlTagETP.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FEntryPoint(this.fScdCore, fXmlNode);
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

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2016.04.26 by spike.lee
        // Clone 추가
        // ***
        public FScenario clone(
            )
        {
            FScenario fScenario = null;
            string xpath = string.Empty;

            try
            {
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Scenario", "Modeling File"));
                }

                // --

                // ***
                // 2017.04.20 by spike.lee
                // Clone된 개체의 Lock 제거
                // ***
                fScenario = new FScenario(this.fScdCore, this.fXmlNode.clone(true));
                // --
                fScenario.fXmlNode.set_attrVal(FXmlTagSNR.A_Locked, FXmlTagSNR.D_Locked, FBoolean.False);

                // -

                return this.fParent.insertAfterChildScenario(fScenario, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fScenario = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2018.01.16 by Jeff.Kim
        // Merge를 하기 위한 강제 복사 추가
        // ***
        public void merge(
            FScenario fSourceScenario
            )
        {
            FIFlow fIChildFlow = null;
            try
            {
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Scenario", "Modeling File"));
                }

                // --

                foreach (FIFlow fIFlow in fSourceScenario.fChildFlowCollection)
                {
                    // --

                    if (fIFlow.fFlowType == FFlowType.SecsTransmitter)
                    {
                        fIChildFlow = new FSecsTransmitter(this.fScdCore, ((FSecsTransmitter)fIFlow).fXmlNode.clone(true));
                    }
                    else if (fIFlow.fFlowType == FFlowType.SecsTrigger)
                    {
                        fIChildFlow = new FSecsTrigger(this.fScdCore, ((FSecsTrigger)fIFlow).fXmlNode.clone(true));
                    }
                    else if (fIFlow.fFlowType == FFlowType.HostTransmitter)
                    {
                        fIChildFlow = new FHostTransmitter(this.fScdCore, ((FHostTransmitter)fIFlow).fXmlNode.clone(true));
                    }
                    else if (fIFlow.fFlowType == FFlowType.HostTrigger)
                    {
                        fIChildFlow = new FHostTrigger(this.fScdCore, ((FHostTrigger)fIFlow).fXmlNode.clone(true));
                    }
                    else if (fIFlow.fFlowType == FFlowType.EquipmentStateSetAlterer)
                    {
                        fIChildFlow = new FEquipmentStateSetAlterer(this.fScdCore, ((FEquipmentStateSetAlterer)fIFlow).fXmlNode.clone(true));
                    }
                    else if (fIFlow.fFlowType == FFlowType.Judgement)
                    {
                        fIChildFlow = new FJudgement(this.fScdCore, ((FJudgement)fIFlow).fXmlNode.clone(true));
                    }
                    else if (fIFlow.fFlowType == FFlowType.Mapper)
                    {
                        fIChildFlow = new FMapper(this.fScdCore, ((FMapper)fIFlow).fXmlNode.clone(true));
                    }
                    else if (fIFlow.fFlowType == FFlowType.Storage)
                    {
                        fIChildFlow = new FStorage(this.fScdCore, ((FStorage)fIFlow).fXmlNode.clone(true));
                    }
                    else if (fIFlow.fFlowType == FFlowType.Callback)
                    {
                        fIChildFlow = new FCallback(this.fScdCore, ((FCallback)fIFlow).fXmlNode.clone(true));
                    }
                    else if (fIFlow.fFlowType == FFlowType.Branch)
                    {
                        fIChildFlow = new FBranch(this.fScdCore, ((FBranch)fIFlow).fXmlNode.clone(true));
                    }
                    else if (fIFlow.fFlowType == FFlowType.Comment)
                    {
                        fIChildFlow = new FComment(this.fScdCore, ((FComment)fIFlow).fXmlNode.clone(true));
                    }
                    else if (fIFlow.fFlowType == FFlowType.Pauser)
                    {
                        fIChildFlow = new FPauser(this.fScdCore, ((FPauser)fIFlow).fXmlNode.clone(true));
                    }   
                    // --
                    this.appendChildFlow(fIChildFlow);
                }

                // --
                fSourceScenario.remove();

                // -
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fIChildFlow = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
