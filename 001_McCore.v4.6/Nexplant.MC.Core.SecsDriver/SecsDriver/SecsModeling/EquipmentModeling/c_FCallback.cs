/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FCallback.cs
--  Creator         : spike.lee
--  Create Date     : 2011.05.30
--  Description     : FAMate Core FaSecsDriver FCallback Class 
--  History         : Created by spike.lee at 2011.05.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FCallback : FBaseObject<FCallback>, FIObject, FIFlow
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FCallback(
            FSecsDriver fSecsDriver
            )
            : base(fSecsDriver.fScdCore, FSecsDriverCommon.createXmlNodeCBK(fSecsDriver.fScdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FCallback(
            FScdCore fScdCore,
            FXmlNode fXmlNode
            )
            : base(fScdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FCallback(
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
                    return FObjectType.Callback;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.Callback;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FFlowType fFlowType
        {
            get
            {
                try
                {
                    return FFlowType.Callback;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FFlowType.Callback;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagCBK.A_UniqueId, FXmlTagCBK.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCBK.A_Name, FXmlTagCBK.D_Name);
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

                    this.fXmlNode.set_attrVal(FXmlTagCBK.A_Name, FXmlTagCBK.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCBK.A_Description, FXmlTagCBK.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagCBK.A_Description, FXmlTagCBK.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagCBK.A_FontColor, FXmlTagCBK.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagCBK.A_FontColor, FXmlTagCBK.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagCBK.A_FontBold, FXmlTagCBK.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagCBK.A_FontBold, FXmlTagCBK.D_FontBold, FBoolean.fromBool(value), true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCBK.A_UserTag1, FXmlTagCBK.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagCBK.A_UserTag1, FXmlTagCBK.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCBK.A_UserTag2, FXmlTagCBK.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagCBK.A_UserTag2, FXmlTagCBK.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCBK.A_UserTag3, FXmlTagCBK.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagCBK.A_UserTag3, FXmlTagCBK.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCBK.A_UserTag4, FXmlTagCBK.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagCBK.A_UserTag4, FXmlTagCBK.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCBK.A_UserTag5, FXmlTagCBK.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagCBK.A_UserTag5, FXmlTagCBK.D_UserTag5, value, true);
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

        public FFunctionCollection fChildFunctionCollection
        {
            get
            {
                try
                {
                    return new FFunctionCollection(this.fScdCore, this.fXmlNode.selectNodes(FXmlTagFUN.E_Function));
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
                            "../../" + FXmlTagSNR.E_Scenario + "[@" + FXmlTagSNR.A_UniqueId + "='" + this.fParent.uniqueIdToString + "']";
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
                try
                {
                    return this.fXmlNode.containsNode(FXmlTagFUN.E_Function);
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
                        this.fXmlNode.fParentNode == null
                        )
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
                    if(!FClipboard.containsData(FCbObjectFormat.Function))
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

        public FFunction appendChildFunction(
            FFunction fNewChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

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

        public FFunction insertBeforeChildFunction(
            FFunction fNewChild,
            FFunction fRefChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

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

        public FFunction insertAfterChildFunction(
            FFunction fNewChild,
            FFunction fRefChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

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

        public FFunction removeChildFunction(
           FFunction fChild
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

        public void removeChildFunction(
            FFunction[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FFunction fFun in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode, fFun.fXmlNode);
                }

                // --

                foreach (FFunction fFun in fChilds)
                {
                    fFun.remove();
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

        public void removeAllChildFunction(
            )
        {
            FFunctionCollection fFunCollction = null;

            try
            {
                fFunCollction = this.fChildFunctionCollection;
                if (fFunCollction.count == 0)
                {
                    return;
                }

                // --

                foreach (FFunction fFun in fFunCollction)
                {
                    fFun.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fFunCollction != null)
                {
                    fFunCollction.Dispose();
                    fFunCollction = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal static void resetFlowNode(
            FXmlNode fXmlNode
            )
        {
            try
            {
                foreach (FXmlNode fXmlNodeFun in fXmlNode.selectNodes(FXmlTagFUN.E_Function))
                {
                    FFunction.resetFlowNode(fXmlNodeFun);
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

                this.copyObject(FCbObjectFormat.Callback, fXmlNode);
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

                this.copyObject(FCbObjectFormat.Callback, this.fXmlNode);
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

        public FFunction pasteChild(
            )
        {
            FFunction fFunction = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.Function);

                // --

                fFunction = (FFunction)this.pasteObject(FCbObjectFormat.Function);
                return this.appendChildFunction(fFunction);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fFunction = null;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FFunctionCollection selectFunctionByName(
            string name
            )
        {
            const string xpath = FXmlTagFUN.E_Function + "[@" + FXmlTagFUN.A_Name + "='{0}']";

            try
            {
                return new FFunctionCollection(
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

        public FFunction selectSingleFunctionByName(
            string name
            )
        {
            const string xpath = FXmlTagFUN.E_Function + "[@" + FXmlTagFUN.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FFunction(this.fScdCore, fXmlNode);
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
