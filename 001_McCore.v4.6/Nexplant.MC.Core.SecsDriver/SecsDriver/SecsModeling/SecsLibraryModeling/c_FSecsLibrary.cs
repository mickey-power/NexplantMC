/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsLibrary.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.31
--  Description     : FAMate Core FaSecsDriver SECS Library Class 
--  History         : Created by spike.lee at 2011.01.31
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FSecsLibrary : FBaseObject<FSecsLibrary>, FIObject, FILibrary
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecsLibrary(
            FSecsDriver fSecsDriver
            )
            : base(fSecsDriver.fScdCore, FSecsDriverCommon.createXmlNodeSLB(fSecsDriver.fScdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FSecsLibrary(
            FScdCore fScdCore,
            FXmlNode fXmlNode
            )
            : base(fScdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsLibrary(
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
                    return FObjectType.SecsLibrary;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.SecsDriver;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FLibraryType fLibraryType
        {
            get
            {
                try
                {
                    return FLibraryType.SecsLibrary;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FLibraryType.SecsLibrary;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSLB.A_UniqueId, FXmlTagSLB.D_UniqueId);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSLB.A_Locked, FXmlTagSLB.D_Locked));
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
                    return this.fXmlNode.get_attrVal(FXmlTagSLB.A_Name, FXmlTagSLB.D_Name);
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

                    this.fXmlNode.set_attrVal(FXmlTagSLB.A_Name, FXmlTagSLB.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSLB.A_Description, FXmlTagSLB.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagSLB.A_Description, FXmlTagSLB.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagSLB.A_FontColor, FXmlTagSLB.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagSLB.A_FontColor, FXmlTagSLB.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSLB.A_FontBold, FXmlTagSLB.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagSLB.A_FontBold, FXmlTagSLB.D_FontBold, FBoolean.fromBool(value), true);
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

        public string Comment
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSLB.A_Comment, FXmlTagSLB.D_Comment);
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
                    this.fXmlNode.set_attrVal(FXmlTagSLB.A_Comment, FXmlTagSLB.D_Comment, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSLB.A_UserTag1, FXmlTagSLB.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagSLB.A_UserTag1, FXmlTagSLB.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSLB.A_UserTag2, FXmlTagSLB.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagSLB.A_UserTag2, FXmlTagSLB.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSLB.A_UserTag3, FXmlTagSLB.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagSLB.A_UserTag3, FXmlTagSLB.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSLB.A_UserTag4, FXmlTagSLB.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagSLB.A_UserTag4, FXmlTagSLB.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSLB.A_UserTag5, FXmlTagSLB.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagSLB.A_UserTag5, FXmlTagSLB.D_UserTag5, value, true);
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

        public FSecsLibraryGroup fParent
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

                    return new FSecsLibraryGroup(this.fScdCore, this.fXmlNode.fParentNode);
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

        public FSecsLibrary fPreviousSibling
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

                    return new FSecsLibrary(this.fScdCore, this.fXmlNode.fPreviousSibling);
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

        public FSecsLibrary fNextSibling
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

                    return new FSecsLibrary(this.fScdCore, this.fXmlNode.fNextSibling);
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

        public FSecsMessageListCollection fChildSecsMessageListCollection
        {
            get
            {
                try
                {
                    return new FSecsMessageListCollection(this.fScdCore, this.fXmlNode.selectNodes(FXmlTagSML.E_SecsMessageList));
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
                        "../../../" + FXmlTagSDM.E_SecsDeviceModeling +
                        "/" + FXmlTagSDV.E_SecsDevice +
                        "/" + FXmlTagSSN.E_SecsSession + "[@" + FXmlTagSSN.A_SecsLibraryId + "='" + this.uniqueIdToString + "']";
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
                try
                {
                    return this.fXmlNode.containsNode(FXmlTagSML.E_SecsMessageList);
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

        public bool canPasteSibling
        {
            get
            {
                try
                {
                    if (
                        this.fXmlNode.fParentNode == null ||
                        !FClipboard.containsData(FCbObjectFormat.SecsLibrary)
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
                    if(!FClipboard.containsData(FCbObjectFormat.SecsMessageList))
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

        public FSecsMessageList appendChildSecsMessageList(
            FSecsMessageList fNewChild
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

        public FSecsMessageList insertBeforeChildSecsMessageList(
            FSecsMessageList fNewChild,
            FSecsMessageList fRefChild
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
                    // --
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

        public FSecsMessageList insertAfterChildSecsMessageList(
            FSecsMessageList fNewChild,
            FSecsMessageList fRefChild
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

        public FSecsMessageList removeChildSecsMessageList(
            FSecsMessageList fChild
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

        public void removeChildSecsMessageList(
            FSecsMessageList[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FSecsMessageList fSml in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode, fSml.fXmlNode);
                }

                // --

                foreach (FSecsMessageList fSml in fChilds)
                {
                    fSml.remove();
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

        public void removeAllChildSecsMessageList(
            )
        {
            FSecsMessageListCollection fSmlCollection = null;

            try
            {
                fSmlCollection = this.fChildSecsMessageListCollection;
                if (fSmlCollection.count == 0)
                {
                    return;
                }               

                // --

                foreach (FSecsMessageList fSml in fSmlCollection)
                {
                    if (fSml.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FSecsMessageList fSml in fSmlCollection)
                {
                    fSml.remove();
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fSmlCollection != null)
                {
                    fSmlCollection.Dispose();
                    fSmlCollection = null;
                }
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
            FSecsLibrary fRefObject
            )
        {
            FSecsLibraryGroup fOldParent = null;

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
            FSecsLibraryGroup fRefObject
            )
        {
            FSecsLibraryGroup fOldParent = null;

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

                if (fRefObject.fChildSecsLibraryCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildSecsLibraryCollection[fRefObject.fChildSecsLibraryCollection.count - 1]))
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

                // ***
                // SECS Library에 대한 Lock 처리
                // ***
                this.fXmlNode.set_attrVal(FXmlTagSLB.A_Locked, FXmlTagSLB.D_Locked, FBoolean.True, true);
                
                // --

                // ***
                // Parent인 SECS Library Group에 대한 Lock 처리
                // ***
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

                // --

                // ***
                // SECS Library가 SECS Session에 사용되어 있을 경우 Unlock 작업을 취소한다.
                // ***
                xpath =
                    FXmlTagSDM.E_SecsDeviceModeling +
                    "/" + FXmlTagSDV.E_SecsDevice +
                    "/" + FXmlTagSSN.E_SecsSession + "[@" + FXmlTagSSN.A_SecsLibraryId + "='" + this.uniqueIdToString + "']";                    
                if (this.fSecsDriver.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagSLB.A_Locked, FXmlTagSLB.D_Locked, FBoolean.False, true);

                // --

                // ***
                // Parent인 SECS Library Group에 대한 Unlock 처리
                // ***
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
                this.copyObject(FCbObjectFormat.SecsLibrary, fXmlNode);
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
                this.copyObject(FCbObjectFormat.SecsLibrary, this.fXmlNode);
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

        public FSecsLibrary pasteSibling(
            )
        {
            FSecsLibrary fSecsLibrary = null;

            try
            {
                FSecsDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.SecsLibrary);
                
                // --

                fSecsLibrary = (FSecsLibrary)this.pasteObject(FCbObjectFormat.SecsLibrary);
                return this.fParent.insertAfterChildSecsLibrary(fSecsLibrary, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsLibrary = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsMessageList pasteChild(
            )
        {
            FSecsMessageList fSecsMessageList = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.SecsMessageList);

                // --

                fSecsMessageList = (FSecsMessageList)this.pasteObject(FCbObjectFormat.SecsMessageList);
                return this.appendChildSecsMessageList(fSecsMessageList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsMessageList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsMessageListCollection selectSecsMessageListByName(
            string name
            )
        {
            const string xpath = FXmlTagSML.E_SecsMessageList + "[@" + FXmlTagSML.A_Name + "='{0}']";

            try
            {
                return new FSecsMessageListCollection(
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

        public FSecsMessageList selectSingleSecsMessageListByName(
            string name
            )
        {
            const string xpath = FXmlTagSML.E_SecsMessageList + "[@" + FXmlTagSML.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsMessageList(this.fScdCore, fXmlNode);
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

        internal void resetRelation(
            )
        {
            try
            {
                foreach (FSecsMessageList fSml in this.fChildSecsMessageListCollection)
                {
                    fSml.resetRelation();
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
                foreach (FXmlNode fXmlNodeSml in fXmlNode.selectNodes(FXmlTagSML.E_SecsMessageList))
                {
                    FSecsMessageList.resetFlowNode(fXmlNodeSml);
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

    }   // Class end
}   // Namespace end
