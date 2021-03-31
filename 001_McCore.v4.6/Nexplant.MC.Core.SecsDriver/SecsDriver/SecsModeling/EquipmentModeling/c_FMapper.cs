/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMapper.cs
--  Creator         : spike.lee
--  Create Date     : 2011.11.30
--  Description     : FAMate Core FaSecsDriver FMapper Class 
--  History         : Created by spike.lee at 2011.11.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FMapper : FBaseObject<FMapper>, FIObject, FIFlow
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FMapper(
            FSecsDriver fSecsDriver
            )
            : base(fSecsDriver.fScdCore, FSecsDriverCommon.createXmlNodeMAP(fSecsDriver.fScdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FMapper(
            FScdCore fScdCore,
            FXmlNode fXmlNode
            )
            : base(fScdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FMapper(
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
                    return FObjectType.Mapper;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.Mapper;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FFlowType fFlowType
        {
            get
            {
                try
                {
                    return FFlowType.Mapper;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FFlowType.Mapper;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagMAP.A_UniqueId, FXmlTagMAP.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagMAP.A_Name, FXmlTagMAP.D_Name);
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

                    this.fXmlNode.set_attrVal(FXmlTagMAP.A_Name, FXmlTagMAP.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagMAP.A_Description, FXmlTagMAP.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagMAP.A_Description, FXmlTagMAP.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagMAP.A_FontColor, FXmlTagMAP.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagMAP.A_FontColor, FXmlTagMAP.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagMAP.A_FontBold, FXmlTagMAP.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagMAP.A_FontBold, FXmlTagMAP.D_FontBold, FBoolean.fromBool(value), true);
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

        public FDataSet fDataSet
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagMAP.A_DataSetId, FXmlTagMAP.D_DataSetId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagSET.E_Setup +
                        "/" + FXmlTagDSD.E_DataSetDefinition +
                        "/" + FXmlTagDSL.E_DataSetList +
                        "/" + FXmlTagDTS.E_DataSet + "[@" + FXmlTagDTS.A_UniqueId + "='" + id + "']";
                    // --
                    return new FDataSet(this.fScdCore, this.fSecsDriver.fXmlNode.selectSingleNode(xpath));
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

        public string userTag1
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagMAP.A_UserTag1, FXmlTagMAP.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagMAP.A_UserTag1, FXmlTagMAP.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagMAP.A_UserTag2, FXmlTagMAP.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagMAP.A_UserTag2, FXmlTagMAP.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagMAP.A_UserTag3, FXmlTagMAP.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagMAP.A_UserTag3, FXmlTagMAP.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagMAP.A_UserTag4, FXmlTagMAP.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagMAP.A_UserTag4, FXmlTagMAP.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagMAP.A_UserTag5, FXmlTagMAP.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagMAP.A_UserTag5, FXmlTagMAP.D_UserTag5, value, true);
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

        public FScenario fParent
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

                    return new FScenario(this.fScdCore, this.fXmlNode.fParentNode);
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

        public FIFlow fPreviousSibling
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

                    return (FIFlow)FSecsDriverCommon.createObject(this.fScdCore, this.fXmlNode.fPreviousSibling);
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

        public FIFlow fNextSibling
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

                    return (FIFlow)FSecsDriverCommon.createObject(this.fScdCore, this.fXmlNode.fNextSibling);
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
                            "../../" + FXmlTagSNR.E_Scenario + "[@" + FXmlTagSNR.A_UniqueId + "='" + fParent.uniqueIdToString + "']";
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
                    if (this.fDataSet != null)
                    {
                        xpath =
                        "../../../../../" + FXmlTagSET.E_Setup + "/" + FXmlTagDSD.E_DataSetDefinition +
                        "/" + FXmlTagDSL.E_DataSetList +
                        "/" + FXmlTagDTS.E_DataSet + "[@" + FXmlTagDTS.A_UniqueId + "='" + this.fDataSet.uniqueIdToString + "']";
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

        public bool hasDataSet
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagMAP.A_DataSetId, FXmlTagMAP.D_DataSetId) == string.Empty)
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
                    if (this.fXmlNode.fParentNode == null)
                    {
                        return false;
                    }
                    // --
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
                    // --
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

        public bool canPasteChild
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
                if (option == FStringOption.Default)
                {
                    info = this.name;
                }
                else
                {
                    info = this.name;
                    if (this.hasDataSet)
                    {
                        info += " Dts.=[" + this.fDataSet.name + "]";
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

            }
            return string.Empty;
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

        internal static void resetFlowNode(
            FXmlNode fXmlNode
            )
        {
            try
            {
                fXmlNode.set_attrVal(FXmlTagMAP.A_DataSetId, FXmlTagMAP.D_DataSetId, FXmlTagMAP.D_DataSetId);
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
                this.copyObject(FCbObjectFormat.Mapper, fXmlNode);
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
                this.copyObject(FCbObjectFormat.Mapper, this.fXmlNode);
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

        public FIFlow pasteSibling(
           )
        {
            FIFlow fNewFlowObject = null;

            try
            {
                if (fXmlNode.fParentNode == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Parent"));
                }

                // --

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

                return this.fParent.insertAfterChildFlow(fNewFlowObject, this);
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

        public void setDataSet(
            FDataSet fDataSet
            )
        {
            string oldId = string.Empty;
            string newId = string.Empty;

            try
            {
                // ***
                // Data Set 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fDataSet.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Data Set", "Modeling File"));
                }

                // ***
                // 이 Mapper 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Mapper", "Modeling File"));
                }

                // ***
                // Data Set와 Mapper의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fDataSet))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Data Set and the Mapper", "same"));
                }

                // --

                oldId = this.fXmlNode.get_attrVal(FXmlTagMAP.A_DataSetId, FXmlTagMAP.D_DataSetId);
                newId = fDataSet.uniqueIdToString;
                if (oldId == newId)
                {
                    return;
                }

                // --

                // ***
                // Mapper에 이전에 설정한 Data Set이 존재할 경우 Reset 한다.
                // ***
                if (oldId != string.Empty)
                {
                    resetDataSet(false);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagMAP.A_DataSetId, FXmlTagMAP.D_DataSetId, newId, true);
                fDataSet.lockObject();
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

        internal void resetDataSet(
            bool isModifyEvent
            )
        {
            FDataSet fDataSet = null;

            try
            {

                fDataSet = this.fDataSet;
                if (fDataSet == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagMAP.A_DataSetId, FXmlTagMAP.D_DataSetId, string.Empty, isModifyEvent);
                fDataSet.unlockObject();
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

        public void resetDataSet(
            )
        {
            try
            {
                resetDataSet(true);
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
                resetDataSet(false);
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
            FIFlow fRefObject
            )
        {
            FXmlNode fRefXmlNode = null;

            try
            {
                fRefXmlNode = FSecsDriverCommon.getObjectXmlNode((FIObject)fRefObject);

                // --

                FSecsDriverCommon.validateMoveToObject(this.fXmlNode, fRefXmlNode);

                // --

                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "Modeling Object"));
                }

                if (!this.equalsModelingFile((FIObject)fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Modeling File", "same"));
                }

                if (!this.fXmlNode.fParentNode.Equals(fRefXmlNode.fParentNode))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0008, "Object", "Parent"));
                }

                // --                               

                this.replace(this.fScdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fScdCore, fRefXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefXmlNode));

                // --

                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fSecsDriver, this, (FIObject)fRefObject)
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fRefXmlNode = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
