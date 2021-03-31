/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FOpcLibraryModeler.cs
--  Creator         : HyunJun.Youn
--  Create Date     : 2013.07.18
--  Description     : FAMate OPC Modeler OPC Library Modeler Form Class 
--  History         : Created by spike.lee at 2013.07.18
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinToolbars;

namespace Nexplant.MC.OpcModeler
{
    public partial class FOpcLibraryModeler : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private FEventHandler m_fEventHandler = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOpcLibraryModeler(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcLibraryModeler(
            FOpmCore fOpmCore
            )
            : this()
        {
            base.fUIWizard = fOpmCore.fUIWizard;
            m_fOpmCore = fOpmCore;
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
                    m_fOpmCore = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
                base.fUIWizard.changeControlCaption(mnuMenu);
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

        protected override void changeControlFontName(
            )
        {
            try
            {
                base.changeControlFontName();
                base.fUIWizard.changeControlFontName(mnuMenu);
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

        private void designTreeOfOpcLibraryModeler(
            )
        {
            try
            {
                tvwTree.ImageList = new ImageList();
                // --
                tvwTree.ImageList.Images.Add("OpcDriver", Properties.Resources.OpcDriver);
                tvwTree.ImageList.Images.Add("OpcLibraryGroup_unlock", Properties.Resources.OpcLibraryGroup_unlock);
                tvwTree.ImageList.Images.Add("OpcLibraryGroup_lock", Properties.Resources.OpcLibraryGroup_lock);
                tvwTree.ImageList.Images.Add("OpcLibrary_unlock", Properties.Resources.OpcLibrary_unlock);
                tvwTree.ImageList.Images.Add("OpcLibrary_lock", Properties.Resources.OpcLibrary_lock);
                tvwTree.ImageList.Images.Add("OpcMessageList_unlock", Properties.Resources.OpcMessageList_unlock);
                tvwTree.ImageList.Images.Add("OpcMessageList_lock", Properties.Resources.OpcMessageList_lock);
                tvwTree.ImageList.Images.Add("OpcMessages_Read_unlock", Properties.Resources.OpcMessages_Read_unlock);
                tvwTree.ImageList.Images.Add("OpcMessages_Read_lock", Properties.Resources.OpcMessages_Read_lock);
                tvwTree.ImageList.Images.Add("OpcMessages_Write_unlock", Properties.Resources.OpcMessages_Write_unlock);
                tvwTree.ImageList.Images.Add("OpcMessages_Write_lock", Properties.Resources.OpcMessages_Write_lock);
                tvwTree.ImageList.Images.Add("OpcMessage_Primary_unlock", Properties.Resources.OpcMessage_Primary_unlock);
                tvwTree.ImageList.Images.Add("OpcMessage_Primary_lock", Properties.Resources.OpcMessage_Primary_lock);
                tvwTree.ImageList.Images.Add("OpcMessage_Secondary_unlock", Properties.Resources.OpcMessage_Secondary_unlock);
                tvwTree.ImageList.Images.Add("OpcMessage_Secondary_lock", Properties.Resources.OpcMessage_Secondary_lock);
                tvwTree.ImageList.Images.Add("OpcEventItemList_unlock", Properties.Resources.OpcEventItemList_unlock);
                tvwTree.ImageList.Images.Add("OpcEventItemList_lock", Properties.Resources.OpcEventItemList_lock);
                tvwTree.ImageList.Images.Add("OpcEventItem_unlock", Properties.Resources.OpcEventItem_unlock);
                tvwTree.ImageList.Images.Add("OpcEventItem_lock", Properties.Resources.OpcEventItem_lock);
                tvwTree.ImageList.Images.Add("OpcItemList_unlock", Properties.Resources.OpcItemList_unlock);
                tvwTree.ImageList.Images.Add("OpcItemList_lock", Properties.Resources.OpcItemList_lock);
                tvwTree.ImageList.Images.Add("OpcItem_unlock", Properties.Resources.OpcItem_unlock);
                tvwTree.ImageList.Images.Add("OpcItem_lock", Properties.Resources.OpcItem_lock);
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

        private void controlMenu(
            )
        {
            FIObject fObject = null;

            try
            {
                mnuMenu.beginUpdate();

                // --

                foreach (ToolBase t in mnuMenu.Tools)
                {
                    if (
                        t.Key == FMenuKey.MenuOpmExpand ||
                        t.Key == FMenuKey.MenuOpmCollapse ||
                        t.Key == FMenuKey.MenuOpmRelation
                        )
                    {
                        continue;
                    }
                    else if (
                        t.Key == FMenuKey.MenuOpmReplace ||
                        t.Key == FMenuKey.MenuOpmCut ||
                        t.Key == FMenuKey.MenuOpmCopy ||
                        t.Key == FMenuKey.MenuOpmPasteSibling ||
                        t.Key == FMenuKey.MenuOpmPasteChild ||
                        t.Key == FMenuKey.MenuOpmRemove ||
                        t.Key == FMenuKey.MenuOpmMoveUp ||
                        t.Key == FMenuKey.MenuOpmMoveDown 
                        )
                    {
                        t.SharedProps.Enabled = false;
                    }
                    else
                    {
                        t.SharedProps.Visible = false;
                    }
                }

                // --

                fObject = (FIObject)tvwTree.ActiveNode.Tag;
                if (fObject.fObjectType == FObjectType.OpcDriver)
                {
                    mnuMenu.Tools[FMenuKey.MenuOpmAppendOpcLibraryGroup].SharedProps.Visible = ((FOpcDriver)fObject).canAppendChildOpcLibraryGroup;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuOpmPasteChild].SharedProps.Enabled = ((FOpcDriver)fObject).canPasteChildOpcLibraryGroup;
                    // --
                    //mnuMenu.Tools[FMenuKey.MenuOpmValidationOPCItem].SharedProps.Visible = true;
                    //mnuMenu.Tools[FMenuKey.MenuOpmValidationOPCItem].SharedProps.Enabled = true;
                }
                else if (fObject.fObjectType == FObjectType.OpcLibraryGroup)
                {
                    mnuMenu.Tools[FMenuKey.MenuOpmInsertBeforeOpcLibraryGroup].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuOpmInsertAfterOpcLibraryGroup].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuOpmAppendOpcLibrary].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.OpcLibrary)
                {
                    mnuMenu.Tools[FMenuKey.MenuOpmInsertBeforeOpcLibrary].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuOpmInsertAfterOpcLibrary].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuOpmAppendOpcMessageList].SharedProps.Visible = fObject.canAppendChild;                    
                }
                else if (fObject.fObjectType == FObjectType.OpcMessageList)
                {
                    mnuMenu.Tools[FMenuKey.MenuOpmInsertBeforeOpcMessageList].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuOpmInsertAfterOpcMessageList].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuOpmAppendOpcMessages].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.OpcMessages)
                {
                    mnuMenu.Tools[FMenuKey.MenuOpmInsertBeforeOpcMessages].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuOpmInsertAfterOpcMessages].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuOpmAppendPrimaryOpcMessage].SharedProps.Visible = ((FOpcMessages)fObject).canAppendChildPrimaryOpcMessage;
                    if (((FOpcMessages)fObject).canAppendChildSecondaryOpcMessage)
                    {
                        mnuMenu.Tools[FMenuKey.MenuOpmAppendSecondaryOpcMessage].SharedProps.Visible = true;
                        // --
                        mnuMenu.Toolbars[0].Tools[FMenuKey.MenuOpmAppendSecondaryOpcMessage].InstanceProps.IsFirstInGroup = !((FOpcMessages)fObject).canAppendChildPrimaryOpcMessage;
                        ((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuOpmPopupMenu]).Tools[FMenuKey.MenuOpmAppendSecondaryOpcMessage].InstanceProps.IsFirstInGroup = !((FOpcMessages)fObject).canAppendChildPrimaryOpcMessage;
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcMessage)
                {
                    // --
                    mnuMenu.Tools[FMenuKey.MenuOpmImportTagByCsv].SharedProps.Visible = true;
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItemList)
                {
                    mnuMenu.Tools[FMenuKey.MenuOpmAppendOpcEventItem].SharedProps.Visible = fObject.canAppendChild;
                    // --
                    //mnuMenu.Tools[FMenuKey.MenuOpmImportTagByText].SharedProps.Visible = true;
                    //mnuMenu.Tools[FMenuKey.MenuOpmImportTagByText].SharedProps.Enabled = true;
                    // --
                    //mnuMenu.Tools[FMenuKey.MenuOpmMultiItemEditor].SharedProps.Visible = true;
                    //mnuMenu.Tools[FMenuKey.MenuOpmMultiItemEditor].SharedProps.Enabled = true;
                    // --
                    //mnuMenu.Tools[FMenuKey.MenuOpmResetItemList].SharedProps.Visible = true;
                    //mnuMenu.Tools[FMenuKey.MenuOpmResetItemList].SharedProps.Enabled = true;
                }
                else if (fObject.fObjectType == FObjectType.OpcItemList)
                {
                    mnuMenu.Tools[FMenuKey.MenuOpmAppendOpcItem].SharedProps.Visible = fObject.canAppendChild;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuOpmCopyValues].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuOpmCopyValues].SharedProps.Enabled = true;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuOpmPasteValues].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuOpmPasteValues].SharedProps.Enabled = ((FOpcItemList)fObject).canPasteValues;
                    // --
                    //mnuMenu.Tools[FMenuKey.MenuOpmResetItemValue].SharedProps.Visible = true;
                    //mnuMenu.Tools[FMenuKey.MenuOpmResetItemValue].SharedProps.Enabled = true;
                    // --
                    //mnuMenu.Tools[FMenuKey.MenuOpmImportTagByText].SharedProps.Visible = true;
                    //mnuMenu.Tools[FMenuKey.MenuOpmImportTagByText].SharedProps.Enabled = true;
                    // --
                    //mnuMenu.Tools[FMenuKey.MenuOpmMultiItemEditor].SharedProps.Visible = true;
                    //mnuMenu.Tools[FMenuKey.MenuOpmMultiItemEditor].SharedProps.Enabled = true;
                    // --
                    //mnuMenu.Tools[FMenuKey.MenuOpmResetItemList].SharedProps.Visible = true;
                    //mnuMenu.Tools[FMenuKey.MenuOpmResetItemList].SharedProps.Enabled = true;
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItem)
                {
                    mnuMenu.Tools[FMenuKey.MenuOpmInsertBeforeOpcEventItem].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuOpmInsertAfterOpcEventItem].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    // mnuMenu.Tools[FMenuKey.MenuOdmPlcAddressEditor].SharedProps.Visible = true;
                }
                else if (fObject.fObjectType == FObjectType.OpcItem)
                {
                    mnuMenu.Tools[FMenuKey.MenuOpmInsertBeforeOpcItem].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuOpmInsertAfterOpcItem].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    // mnuMenu.Tools[FMenuKey.MenuOdmPlcAddressEditor].SharedProps.Visible = true;
                }

                if (
                    fObject.fObjectType == FObjectType.OpcLibraryGroup ||
                    fObject.fObjectType == FObjectType.OpcLibrary ||
                    fObject.fObjectType == FObjectType.OpcMessageList ||
                    fObject.fObjectType == FObjectType.OpcMessages ||
                    fObject.fObjectType == FObjectType.OpcMessage ||
                    fObject.fObjectType == FObjectType.OpcEventItemList ||
                    fObject.fObjectType == FObjectType.OpcItemList ||
                    fObject.fObjectType == FObjectType.OpcEventItem ||
                    fObject.fObjectType == FObjectType.OpcItem
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuOpmPasteSibling].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuOpmPasteChild].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuOpmPastePrimaryOpcMessage].SharedProps.Visible = false;
                    mnuMenu.Tools[FMenuKey.MenuOpmPasteSecondaryOpcMessage].SharedProps.Visible = false;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuOpmRemove].SharedProps.Enabled = fObject.canRemove;
                    //--
                    mnuMenu.Tools[FMenuKey.MenuOpmMoveUp].SharedProps.Enabled = fObject.canMoveUp;
                    mnuMenu.Tools[FMenuKey.MenuOpmMoveDown].SharedProps.Enabled = fObject.canMoveDown;
                    // -- 
                    mnuMenu.Tools[FMenuKey.MenuOpmCut].SharedProps.Enabled = fObject.canCut;
                    mnuMenu.Tools[FMenuKey.MenuOpmCopy].SharedProps.Enabled = fObject.canCopy;
                    mnuMenu.Tools[FMenuKey.MenuOpmPasteSibling].SharedProps.Enabled = fObject.canPasteSibling;

                    // --
                    mnuMenu.Tools[FMenuKey.MenuOpmPasteChild].SharedProps.Enabled = fObject.canPasteChild;
                }

                // --
                // OPC List를 붙여넣기 가능하게 하기 위해 추가
                // Add by Jeff.Kim 2015.08.03
                if (fObject.fObjectType == FObjectType.OpcEventItemList ||
                    fObject.fObjectType == FObjectType.OpcItemList 
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuOpmCopy].SharedProps.Enabled = true;

                    // --
                                        
                    if (FClipboard.containsData("FAMATE_OPC_EVENT_ITEM_LIST") ||
                        FClipboard.containsData("FAMATE_OPC_ITEM_LIST"))
                    {
                        // --
                        mnuMenu.Tools[FMenuKey.MenuOpmPasteChild].SharedProps.Visible = true;
                        mnuMenu.Tools[FMenuKey.MenuOpmPasteChild].SharedProps.Enabled = true;
                    }
                }

                // --

                if (fObject.fObjectType == FObjectType.OpcMessages)
                {
                    if (
                        ((FOpcMessages)fObject).canPastePrimaryOpcMessage ||
                        ((FOpcMessages)fObject).canPasteSecondaryOpcMessage
                        )
                    {
                        mnuMenu.Tools[FMenuKey.MenuOpmPasteSibling].SharedProps.Visible = false;
                        mnuMenu.Tools[FMenuKey.MenuOpmPasteChild].SharedProps.Visible = false;
                        mnuMenu.Tools[FMenuKey.MenuOpmPastePrimaryOpcMessage].SharedProps.Visible = true;
                        mnuMenu.Tools[FMenuKey.MenuOpmPasteSecondaryOpcMessage].SharedProps.Visible = true;
                    }
                    // --
                    mnuMenu.Tools[FMenuKey.MenuOpmPastePrimaryOpcMessage].SharedProps.Enabled = ((FOpcMessages)fObject).canPastePrimaryOpcMessage;
                    mnuMenu.Tools[FMenuKey.MenuOpmPasteSecondaryOpcMessage].SharedProps.Enabled = ((FOpcMessages)fObject).canPasteSecondaryOpcMessage;
                }

                // --

                // ***
                // 2016.04.26 by spike.lee
                // Replace Menu 제어
                // ***
                if (
                    fObject.fObjectType == FObjectType.OpcMessages ||
                    fObject.fObjectType == FObjectType.OpcMessage ||
                    fObject.fObjectType == FObjectType.OpcEventItemList ||
                    fObject.fObjectType == FObjectType.OpcEventItem ||
                    fObject.fObjectType == FObjectType.OpcItemList ||
                    fObject.fObjectType == FObjectType.OpcItem
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuOpmReplace].SharedProps.Enabled = true;
                }

                // --

                mnuMenu.endUpdate();
            }
            catch (Exception ex)
            {
                mnuMenu.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfObject(
            )
        {
            FOpcDriver fOcd = null;
            UltraTreeNode tNodeOcd = null;
            UltraTreeNode tNodeOlg = null;
            UltraTreeNode tNodeOlb = null;
            UltraTreeNode tNodeOml = null;
            UltraTreeNode tNodeOms = null;
            UltraTreeNode tNodeOmg = null;
            UltraTreeNode tNodeOel = null;
            UltraTreeNode tNodeOil = null;
            UltraTreeNode tNodeOei = null;
            UltraTreeNode tNodeOit = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                // ***
                // OPC Driver Load
                // ***
                fOcd = m_fOpmCore.fOpmFileInfo.fOpcDriver;
                tNodeOcd = new UltraTreeNode(fOcd.uniqueIdToString);
                tNodeOcd.Tag = fOcd;
                FCommon.refreshTreeNodeOfObject(fOcd, tvwTree, tNodeOcd);

                // --

                // ***
                // OPC Library Group Load
                // ***
                foreach (FOpcLibraryGroup fOlg in fOcd.fChildOpcLibraryGroupCollection)
                {
                    tNodeOlg = new UltraTreeNode(fOlg.uniqueIdToString);
                    tNodeOlg.Tag = fOlg;
                    FCommon.refreshTreeNodeOfObject(fOlg, tvwTree, tNodeOlg);

                    // --

                    // ***
                    // OPC Library Load
                    // ***
                    foreach (FOpcLibrary fOlb in fOlg.fChildOpcLibraryCollection)
                    {
                        tNodeOlb = new UltraTreeNode(fOlb.uniqueIdToString);
                        tNodeOlb.Tag = fOlb;
                        FCommon.refreshTreeNodeOfObject(fOlb, tvwTree, tNodeOlb);

                        // --

                        // ***
                        // OPC Message List Load
                        // ***
                        foreach (FOpcMessageList fOml in fOlb.fChildOpcMessageListCollection)
                        {
                            tNodeOml = new UltraTreeNode(fOml.uniqueIdToString);
                            tNodeOml.Tag = fOml;
                            FCommon.refreshTreeNodeOfObject(fOml, tvwTree, tNodeOml);

                            // ***
                            // OPC Messages Load
                            // ***
                            foreach (FOpcMessages fOms in fOml.fChildOpcMessagesCollection)
                            {
                                tNodeOms = new UltraTreeNode(fOms.uniqueIdToString);
                                tNodeOms.Tag = fOms;
                                FCommon.refreshTreeNodeOfObject(fOms, tvwTree, tNodeOms);

                                // ***
                                // OPC Message Load
                                // ***
                                foreach (FOpcMessage fOmg in fOms.fChildOpcMessageCollection)
                                {
                                    tNodeOmg = new UltraTreeNode(fOmg.uniqueIdToString);
                                    tNodeOmg.Tag = fOmg;
                                    FCommon.refreshTreeNodeOfObject(fOmg, tvwTree, tNodeOmg);

                                    // ***
                                    // OPC Event Item List Load
                                    // ***
                                    foreach (FOpcEventItemList fOel in fOmg.fChildOpcEventItemListCollection)
                                    {
                                        tNodeOel = new UltraTreeNode(fOel.uniqueIdToString);
                                        tNodeOel.Tag = fOel;
                                        FCommon.refreshTreeNodeOfObject(fOel, tvwTree, tNodeOel);

                                        // ***
                                        // OPC Event Item Load
                                        // ***
                                        foreach (FOpcEventItem fOei in fOel.fChildOpcEventItemCollection)
                                        {
                                            tNodeOei = new UltraTreeNode(fOei.uniqueIdToString);
                                            tNodeOei.Tag = fOei;
                                            FCommon.refreshTreeNodeOfObject(fOei, tvwTree, tNodeOei);
                                            // --
                                            tNodeOei.Expanded = false;
                                            tNodeOel.Nodes.Add(tNodeOei);
                                        }
                                        
                                        tNodeOel.Expanded = false;
                                        tNodeOmg.Nodes.Add(tNodeOel);

                                    }

                                    // ***
                                    // OPC Item List Load
                                    // ***
                                    foreach (FOpcItemList fOil in fOmg.fChildOpcItemListCollection)
                                    {
                                        tNodeOil = new UltraTreeNode(fOil.uniqueIdToString);
                                        tNodeOil.Tag = fOil;
                                        FCommon.refreshTreeNodeOfObject(fOil, tvwTree, tNodeOil);

                                        // ***
                                        // OPC Item Load
                                        // ***
                                        foreach (FOpcItem fOit in fOil.fChildOpcItemCollection)
                                        {
                                            tNodeOit = new UltraTreeNode(fOit.uniqueIdToString);
                                            tNodeOit.Tag = fOit;
                                            FCommon.refreshTreeNodeOfObject(fOit, tvwTree, tNodeOit);
                                            // --
                                            tNodeOit.Expanded = false;
                                            tNodeOil.Nodes.Add(tNodeOit);
                                        }

                                        tNodeOil.Expanded = false;
                                        tNodeOmg.Nodes.Add(tNodeOil);
                                    }

                                    tNodeOmg.Expanded = false;
                                    tNodeOms.Nodes.Add(tNodeOmg);
                                }
   
                                tNodeOms.Expanded = false;
                                tNodeOml.Nodes.Add(tNodeOms);
                            }
                            
                            tNodeOml.Expanded = true;
                            tNodeOlb.Nodes.Add(tNodeOml);
                        }

                        tNodeOlb.Expanded = true;
                        tNodeOlg.Nodes.Add(tNodeOlb);
                    }

                    tNodeOlg.Expanded = true;
                    tNodeOcd.Nodes.Add(tNodeOlg);
                }

                // --

                tNodeOcd.Expanded = true;
                tvwTree.Nodes.Add(tNodeOcd);
                tvwTree.ActiveNode = tNodeOcd;

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fOcd = null;
                tNodeOcd = null;
                tNodeOlg = null;
                tNodeOlb = null;
                tNodeOml = null;
                tNodeOms = null;
                tNodeOmg = null;
                tNodeOel = null;
                tNodeOil = null;
                tNodeOei = null;
                tNodeOit = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfChildObject(
            UltraTreeNode tNodeParent
            )
        {
            FIObject fParent = null;
            UltraTreeNode tNodeChild = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                fParent = (FIObject)tNodeParent.Tag;
                // --
                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    foreach (FOpcLibraryGroup fOlg in ((FOpcDriver)fParent).fChildOpcLibraryGroupCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOlg.uniqueIdToString);
                        tNodeChild.Tag = fOlg;
                        FCommon.refreshTreeNodeOfObject(fOlg, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcLibraryGroup)
                {
                    foreach (FOpcLibrary fOlb in ((FOpcLibraryGroup)fParent).fChildOpcLibraryCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOlb.uniqueIdToString);
                        tNodeChild.Tag = fOlb;
                        FCommon.refreshTreeNodeOfObject(fOlb, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcLibrary)
                {
                    foreach (FOpcMessageList fOml in ((FOpcLibrary)fParent).fChildOpcMessageListCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOml.uniqueIdToString);
                        tNodeChild.Tag = fOml;
                        FCommon.refreshTreeNodeOfObject(fOml, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcMessageList)
                {
                    foreach (FOpcMessages fOms in ((FOpcMessageList)fParent).fChildOpcMessagesCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOms.uniqueIdToString);
                        tNodeChild.Tag = fOms;
                        FCommon.refreshTreeNodeOfObject(fOms, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcMessages)
                {
                    foreach (FOpcMessage fOmg in ((FOpcMessages)fParent).fChildOpcMessageCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOmg.uniqueIdToString);
                        tNodeChild.Tag = fOmg;
                        FCommon.refreshTreeNodeOfObject(fOmg, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcMessage)
                {
                    foreach (FOpcEventItemList fOel in ((FOpcMessage)fParent).fChildOpcEventItemListCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOel.uniqueIdToString);
                        tNodeChild.Tag = fOel;
                        FCommon.refreshTreeNodeOfObject(fOel, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }

                    foreach (FOpcItemList fOil in ((FOpcMessage)fParent).fChildOpcItemListCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOil.uniqueIdToString);
                        tNodeChild.Tag = fOil;
                        FCommon.refreshTreeNodeOfObject(fOil, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcEventItemList)
                {
                    foreach (FOpcEventItem fOei in ((FOpcEventItemList)fParent).fChildOpcEventItemCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOei.uniqueIdToString);
                        tNodeChild.Tag = fOei;
                        FCommon.refreshTreeNodeOfObject(fOei, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcItemList)
                {
                    foreach (FOpcItem fOit in ((FOpcItemList)fParent).fChildOpcItemCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOit.uniqueIdToString);
                        tNodeChild.Tag = fOit;
                        FCommon.refreshTreeNodeOfObject(fOit, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                //else if (fParent.fObjectType == FObjectType.OpcBit)
                //{
                //    foreach (FOpcBit fPbt in ((FOpcBit)fParent).fChildOpcBitCollection)
                //    {
                //        tNodeChild = new UltraTreeNode(fPbt.uniqueIdToString);
                //        tNodeChild.Tag = fPbt;
                //        FCommon.refreshTreeNodeOfObject(fPbt, tvwTree, tNodeChild);
                //        tNodeParent.Nodes.Add(tNodeChild);
                //    }
                //}
                //else if (fParent.fObjectType == FObjectType.OpcItem)
                //{
                //    foreach (FOpcWord fPwd in ((FOpcWord)fParent).fChildOpcWordCollection)
                //    {
                //        tNodeChild = new UltraTreeNode(fPwd.uniqueIdToString);
                //        tNodeChild.Tag = fPwd;
                //        FCommon.refreshTreeNodeOfObject(fPwd, tvwTree, tNodeChild);
                //        tNodeParent.Nodes.Add(tNodeChild);
                //    }
                //}

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
                tNodeChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void addTreeOfObject(
            FIObject fParent,
            FIObject fNewChild
            )
        {
            FIObject fRefChild = null;
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeNewChild = null;
            UltraTreeNode tNodeRefChild = null;

            try
            {
                tNodeNewChild = tvwTree.GetNodeByKey(fNewChild.uniqueIdToString);
                if (tNodeNewChild != null)
                {
                    return;
                }

                // --

                if (fNewChild.fObjectType == FObjectType.OpcLibraryGroup)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);
                    fRefChild = ((FOpcLibraryGroup)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.OpcLibrary)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);
                    if (
                        tNodeParent == null ||
                        (!tNodeParent.Parent.Expanded && tNodeParent.Nodes.Count == 0)
                        )
                    {
                        if (tNodeParent != null && tNodeParent.Expanded)
                        {
                            tNodeParent.Expanded = false;
                        }
                        return;
                    }
                    fRefChild = ((FOpcLibrary)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.OpcMessageList)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);
                    if (
                        tNodeParent == null ||
                        (!tNodeParent.Parent.Expanded && tNodeParent.Nodes.Count == 0)
                        )
                    {
                        if (tNodeParent != null && tNodeParent.Expanded)
                        {
                            tNodeParent.Expanded = false;
                        }
                        return;
                    }
                    fRefChild = ((FOpcMessageList)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.OpcMessages)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);
                    if (
                         tNodeParent == null ||
                         (!tNodeParent.Parent.Expanded && tNodeParent.Nodes.Count == 0)
                         )
                    {
                        if (tNodeParent != null && tNodeParent.Expanded)
                        {
                            tNodeParent.Expanded = false;
                        }
                        return;
                    }
                    fRefChild = ((FOpcMessages)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.OpcMessage)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);
                    if (
                          tNodeParent == null ||
                          (!tNodeParent.Parent.Expanded && tNodeParent.Nodes.Count == 0)
                          )
                    {
                        if (tNodeParent != null && tNodeParent.Expanded)
                        {
                            tNodeParent.Expanded = false;
                        }
                        return;
                    }
                    fRefChild = ((FOpcMessage)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.OpcEventItemList)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);
                    if (
                          tNodeParent == null ||
                          (!tNodeParent.Parent.Expanded && tNodeParent.Nodes.Count == 0)
                          )
                    {
                        if (tNodeParent != null && tNodeParent.Expanded)
                        {
                            tNodeParent.Expanded = false;
                        }
                        return;
                    }
                    fRefChild = ((FOpcEventItem)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.OpcItemList)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);
                    if (
                          tNodeParent == null ||
                          (!tNodeParent.Parent.Expanded && tNodeParent.Nodes.Count == 0)
                          )
                    {
                        if (tNodeParent != null && tNodeParent.Expanded)
                        {
                            tNodeParent.Expanded = false;
                        }
                        return;
                    }
                    fRefChild = ((FOpcItemList)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.OpcEventItem)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);
                    if (
                          tNodeParent == null ||
                          (!tNodeParent.Parent.Expanded && tNodeParent.Nodes.Count == 0)
                          )
                    {
                        if (tNodeParent != null && tNodeParent.Expanded)
                        {
                            tNodeParent.Expanded = false;
                        }
                        return;
                    }
                    fRefChild = ((FOpcEventItem)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.OpcItem)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);
                    if (
                          tNodeParent == null ||
                          (!tNodeParent.Parent.Expanded && tNodeParent.Nodes.Count == 0)
                          )
                    {
                        if (tNodeParent != null && tNodeParent.Expanded)
                        {
                            tNodeParent.Expanded = false;
                        }
                        return;
                    }
                    fRefChild = ((FOpcItem)fNewChild).fNextSibling;
                }
                else
                {
                    return;
                }

                // --

                tvwTree.beginUpdate();

                // --

                tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);

                // --

                if (fRefChild != null)
                {
                    tNodeRefChild = tvwTree.GetNodeByKey(fRefChild.uniqueIdToString);
                }
                // --
                if (tNodeRefChild != null)
                {
                    tNodeParent.Nodes.Insert(tNodeRefChild.Index, tNodeNewChild);
                }
                else
                {
                    tNodeParent.Nodes.Add(tNodeNewChild);
                }

                // --

                loadTreeOfChildObject(tNodeNewChild);

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fRefChild = null;
                tNodeParent = null;
                tNodeNewChild = null;
                tNodeRefChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void removeTreeOfObject(
            FIObject fChild
            )
        {
            UltraTreeNode tNodeChild = null;

            try
            {
                tNodeChild = tvwTree.GetNodeByKey(fChild.uniqueIdToString);
                if (tNodeChild == null)
                {
                    return;
                }

                // --

                tvwTree.beginUpdate();
                tNodeChild.Remove();
                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void moveUpTreeOfObject(
            FIObject fObject
            )
        {
            UltraTreeNode tNode = null;
            UltraTreeNode tPrevNode = null;

            try
            {
                tNode = tvwTree.GetNodeByKey(fObject.uniqueIdToString);
                if (tNode == null)
                {
                    return;
                }
                tPrevNode = tNode.GetSibling(NodePosition.Previous);

                // --

                if (fObject.fObjectType == FObjectType.OpcLibraryGroup)
                {
                    if (((FOpcLibraryGroup)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcLibraryGroup)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcLibrary)
                {
                    if (((FOpcLibrary)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcLibrary)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcMessageList)
                {
                    if (((FOpcMessageList)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcMessageList)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcMessages)
                {
                    if (((FOpcMessages)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcMessages)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcMessage)
                {
                    if (((FOpcMessage)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcMessage)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItemList)
                {
                    if (((FOpcEventItemList)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcEventItemList)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcItemList)
                {
                    if (((FOpcItemList)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcItemList)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItem)
                {
                    if (((FOpcEventItem)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcEventItem)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcItem)
                {
                    if (((FOpcItem)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcItem)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }

                // --

                tvwTree.beginUpdate();
                tvwTree.moveUpNode(tNode);
                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                tPrevNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void moveDownTreeOfObject(
            FIObject fObject
            )
        {
            UltraTreeNode tNode = null;
            UltraTreeNode tNextNode = null;

            try
            {
                tNode = tvwTree.GetNodeByKey(fObject.uniqueIdToString);
                if (tNode == null)
                {
                    return;
                }
                tNextNode = tNode.GetSibling(NodePosition.Next);

                // --

                if (fObject.fObjectType == FObjectType.OpcLibraryGroup)
                {
                    if (((FOpcLibraryGroup)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcLibraryGroup)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcLibrary)
                {
                    if (((FOpcLibrary)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcLibrary)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcMessageList)
                {
                    if (((FOpcMessageList)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcMessageList)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcMessages)
                {
                    if (((FOpcMessages)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcMessages)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcMessage)
                {
                    if (((FOpcMessage)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcMessage)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItemList)
                {
                    if (((FOpcEventItemList)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcEventItemList)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcItemList)
                {
                    if (((FOpcItemList)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcItemList)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItem)
                {
                    if (((FOpcEventItem)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcEventItem)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcItem)
                {
                    if (((FOpcItem)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcItem)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }

                // -- 

                tvwTree.beginUpdate();
                tvwTree.moveDownNode(tNode);
                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                tNextNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void moveToTreeOfObject(
            FIObject fObject,
            FIObject fRefObject
            )
        {
            UltraTreeNode tRefNode = null;
            UltraTreeNode tNode = null;

            try
            {
                tvwTree.beginUpdate();

                // --                

                tRefNode = tvwTree.GetNodeByKey(fRefObject.uniqueIdToString);
                tNode = tvwTree.GetNodeByKey(fObject.uniqueIdToString);

                // --

                if (tRefNode == null)
                {
                    if (tNode != null)
                    {
                        tNode.Remove();
                    }
                }
                else
                {
                    if (tNode != null)
                    {
                        if (fRefObject.fObjectType == fObject.fObjectType)
                        {
                            if (tRefNode.Parent != tNode.Parent || tRefNode.Index != tNode.Index - 1)
                            {
                                tNode.Remove();
                                tNode = null;
                            }
                        }
                        else
                        {
                            if (tRefNode.Nodes.Count == 0 || tRefNode.Nodes[tRefNode.Nodes.Count - 1] != tNode)
                            {
                                tNode.Remove();
                                tNode = null;
                            }  
                        }
                    }
                    // --
                    if (tNode == null)
                    {
                        tNode = new UltraTreeNode(fObject.uniqueIdToString);
                        tNode.Tag = fObject;
                        FCommon.refreshTreeNodeOfObject(fObject, tvwTree, tNode);

                        // --

                        if (fRefObject.fObjectType == fObject.fObjectType)
                        {
                            tRefNode.Parent.Nodes.Insert(tRefNode.Index + 1, tNode);
                            loadTreeOfChildObject(tNode);
                        }
                        else
                        {
                            if (tRefNode.Nodes.Count == 0)
                            {
                                loadTreeOfChildObject(tRefNode);
                                // --
                                if (tRefNode.Nodes.Exists(tNode.Key))
                                {
                                    tNode = tRefNode.Nodes[tNode.Key];
                                    loadTreeOfChildObject(tNode);
                                }  
                                // --
                                tRefNode.Expanded = false;
                            }
                            else
                            {
                                tRefNode.Nodes.Add(tNode);
                                loadTreeOfChildObject(tNode);
                            }
                        }  
                    }
                }

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tRefNode = null;
                tNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshObject(
            FIObject fObject
            )
        {
            UltraTreeNode tNode = null;

            try
            {
                tNode = tvwTree.GetNodeByKey(fObject.uniqueIdToString);
                if (tNode == null)
                {
                    return;
                }

                // --

                if (tNode.IsActive && !pgdProp.Focused)
                {
                    pgdProp.onDynPropGridRefreshRequested();
                }

                // --

                tvwTree.beginUpdate();
                FCommon.refreshTreeNodeOfObject(fObject, tvwTree, tNode);
                tvwTree.endUpdate();

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshObjectAddress(
            UltraTreeNode tNode,
            int dataBlock,
            int adjustValue
            )
        {
            FIObject fIObject = null;
            // --

            try
            {
                tvwTree.beginUpdate();

                // --

                do
                {
                    // --
                    fIObject = (FIObject)tNode.Tag;

                    // --

                    if (fIObject.fObjectType == FObjectType.OpcEventItem)
                    {
                        ((FOpcEventItem)fIObject).itemName = FCommon.addressConverter(((FOpcEventItem)fIObject).itemName, dataBlock, adjustValue);
                    }
                    else if (fIObject.fObjectType == FObjectType.OpcItem)
                    {
                        ((FOpcItem)fIObject).itemName = FCommon.addressConverter(((FOpcItem)fIObject).itemName, dataBlock, adjustValue);
                    }
                    else
                    {
                        break;
                    }

                    // --

                    refreshObject(fIObject);

                    // --

                } while ((tNode = tNode.NextVisibleNode) != null);

                // --  

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fIObject = null;
            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshParentNode(
            FIObject fObject
            )
        {
            UltraTreeNode tNodeParent = null;
            FIObject parent = null;

            try
            {
                // --

                if (fObject.fObjectType != FObjectType.OpcEventItemList &&
                    fObject.fObjectType != FObjectType.OpcItemList &&
                    fObject.fObjectType != FObjectType.OpcEventItem &&
                    fObject.fObjectType != FObjectType.OpcItem)
                {
                    return;
                }

                // --

                tvwTree.beginUpdate();

                // --

                if (fObject.fObjectType != FObjectType.OpcEventItemList &&
                    fObject.fObjectType != FObjectType.OpcItemList)
                {
                    if (fObject.fObjectType == FObjectType.OpcEventItem)
                    {
                        parent = ((FOpcEventItem)fObject).fParent;
                    }
                    else if (fObject.fObjectType == FObjectType.OpcItem)
                    {
                        parent = ((FOpcItem)fObject).fParent;
                    }
                }
                else
                {
                    parent = fObject;
                }

                // --

                tNodeParent = tvwTree.GetNodeByKey(parent.uniqueIdToString);
                if (tNodeParent != null)
                {
                    FCommon.refreshTreeNodeOfObject(parent, tvwTree, tNodeParent);               
                }               

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeParent = null;
                parent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAppendObject(
            string menuKey
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeNewChild = null;
            FIObject fParent = null;
            FIObject fNewChild = null;
            

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeParent = tvwTree.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fNewChild = ((FOpcDriver)fParent).appendChildOpcLibraryGroup(new FOpcLibraryGroup(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.OpcLibraryGroup)
                {
                    fNewChild = ((FOpcLibraryGroup)fParent).appendChildOpcLibrary(new FOpcLibrary(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.OpcLibrary)
                {
                    fNewChild = ((FOpcLibrary)fParent).appendChildOpcMessageList(new FOpcMessageList(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.OpcMessageList)
                {
                    fNewChild = ((FOpcMessageList)fParent).appendChildOpcMessages(new FOpcMessages(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.OpcMessages)
                {
                    if (menuKey == FMenuKey.MenuOpmAppendPrimaryOpcMessage)
                    {
                        fNewChild = ((FOpcMessages)fParent).appendChildPrimaryOpcMessage(new FOpcMessage(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                    }
                    else
                    {
                        fNewChild = ((FOpcMessages)fParent).appendChildSecondaryOpcMessage(new FOpcMessage(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcMessage)
                {
                    // --
                }
                else if (fParent.fObjectType == FObjectType.OpcEventItemList)
                {
                    fNewChild = ((FOpcEventItemList)fParent).appendChildOpcEventItem(new FOpcEventItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.OpcItemList)
                {
                    fNewChild = ((FOpcItemList)fParent).appendChildOpcItem(new FOpcItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.OpcEventItem)
                {
                    fNewChild = new FOpcEventItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver);
                }
                else if (fParent.fObjectType == FObjectType.OpcItem)
                {
                    fNewChild = new FOpcItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver);
                }

                // --

                tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);
                // --
                if (fParent.fObjectType == FObjectType.OpcMessages)
                {
                    if (((FOpcMessage)fNewChild).isPrimary)
                    {
                        tNodeParent.Nodes.Insert(0, tNodeNewChild);
                    }
                    else
                    {
                        tNodeParent.Nodes.Add(tNodeNewChild);
                    }
                }
                else
                {
                    tNodeParent.Nodes.Add(tNodeNewChild);
                }
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeNewChild;

                // --

                loadTreeOfChildObject(tNodeNewChild);

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeParent = null;
                tNodeNewChild = null;
                fParent = null;
                fNewChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuInsertBeforeObject(
            string menuKey
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeRefChild = null;
            UltraTreeNode tNodeNewChild = null;
            FIObject fParent = null;
            FIObject fRefChild = null;
            FIObject fNewChild = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeRefChild = tvwTree.ActiveNode;
                tNodeParent = tNodeRefChild.Parent;
                fRefChild = (FIObject)tNodeRefChild.Tag;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fNewChild = ((FOpcDriver)fParent).insertBeforeChildOpcLibraryGroup(
                        new FOpcLibraryGroup(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FOpcLibraryGroup)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.OpcLibraryGroup)
                {
                    fNewChild = ((FOpcLibraryGroup)fParent).insertBeforeChildOpcLibrary(
                        new FOpcLibrary(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FOpcLibrary)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.OpcLibrary)
                {
                    fNewChild = ((FOpcLibrary)fParent).insertBeforeChildOpcMessageList(
                        new FOpcMessageList(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FOpcMessageList)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.OpcMessageList)
                {
                    fNewChild = ((FOpcMessageList)fParent).insertBeforeChildOpcMessages(
                        new FOpcMessages(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FOpcMessages)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.OpcMessages)
                {
                    // --
                }
                else if (fParent.fObjectType == FObjectType.OpcMessage)
                {
                    // --
                }
                else if (fParent.fObjectType == FObjectType.OpcEventItemList)
                {
                    fNewChild = new FOpcEventItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver);
                    fNewChild = ((FOpcEventItemList)fParent).insertBeforeChildOpcEventItem((FOpcEventItem)fNewChild, (FOpcEventItem)fRefChild);
                }
                else if (fParent.fObjectType == FObjectType.OpcItemList)
                {
                    fNewChild = new FOpcItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver);
                    fNewChild = ((FOpcItemList)fParent).insertBeforeChildOpcItem((FOpcItem)fNewChild, (FOpcItem)fRefChild);
                }
                else if (fParent.fObjectType == FObjectType.OpcEventItem)
                {
                    // --
                }
                else if (fParent.fObjectType == FObjectType.OpcItem)
                {
                    // --
                }

                // --

                tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);
                tNodeParent.Nodes.Insert(tNodeRefChild.Index, tNodeNewChild);
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeNewChild;
                loadTreeOfChildObject(tNodeNewChild);
                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeParent = null;
                tNodeRefChild = null;
                tNodeNewChild = null;
                fParent = null;
                fRefChild = null;
                fNewChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuInsertAfterObject(
            string menuKey
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeRefChild = null;
            UltraTreeNode tNodeNewChild = null;
            FIObject fParent = null;
            FIObject fRefChild = null;
            FIObject fNewChild = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeRefChild = tvwTree.ActiveNode;
                tNodeParent = tNodeRefChild.Parent;
                fRefChild = (FIObject)tNodeRefChild.Tag;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fNewChild = ((FOpcDriver)fParent).insertAfterChildOpcLibraryGroup(
                        new FOpcLibraryGroup(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FOpcLibraryGroup)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.OpcLibraryGroup)
                {
                    fNewChild = ((FOpcLibraryGroup)fParent).insertAfterChildOpcLibrary(
                        new FOpcLibrary(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FOpcLibrary)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.OpcLibrary)
                {
                    fNewChild = ((FOpcLibrary)fParent).insertAfterChildOpcMessageList(
                        new FOpcMessageList(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FOpcMessageList)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.OpcMessageList)
                {
                    fNewChild = ((FOpcMessageList)fParent).insertAfterChildOpcMessages(
                        new FOpcMessages(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FOpcMessages)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.OpcMessages)
                {
                    // --
                }
                else if (fParent.fObjectType == FObjectType.OpcMessage)
                {
                    // --
                }
                else if (fParent.fObjectType == FObjectType.OpcEventItemList)
                {
                    fNewChild = new FOpcEventItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver);
                    fNewChild = ((FOpcEventItemList)fParent).insertAfterChildOpcEventItem((FOpcEventItem)fNewChild, (FOpcEventItem)fRefChild);
                }
                else if (fParent.fObjectType == FObjectType.OpcItemList)
                {
                    fNewChild = new FOpcItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver);
                    fNewChild = ((FOpcItemList)fParent).insertAfterChildOpcItem((FOpcItem)fNewChild, (FOpcItem)fRefChild);
                }
                else if (fParent.fObjectType == FObjectType.OpcEventItem)
                {
                    // --
                }
                else if (fParent.fObjectType == FObjectType.OpcItem)
                {
                    // --
                }

                // --

                tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);
                tNodeParent.Nodes.Insert(tNodeRefChild.Index + 1, tNodeNewChild);
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeNewChild;
                loadTreeOfChildObject(tNodeNewChild);
                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeParent = null;
                tNodeRefChild = null;
                tNodeNewChild = null;
                fParent = null;
                fRefChild = null;
                fNewChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRemoveObject(
            )
        {
            UltraTreeNode tNodeParent = null;
            FIObject fParent = null;
            FIObject fChild = null;
            FIObject[] fChilds = null;
            DialogResult dialogResult;

            try
            {
                tvwTree.ActiveNode.Selected = true;
                tNodeParent = tvwTree.ActiveNode.Parent;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                // ***
                // Removing OPC Object Validate
                // ***
                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FOpcLibraryGroup)fChild).locked)
                        {
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcLibraryGroup)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FOpcLibrary)fChild).locked)
                        {
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcLibrary)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FOpcMessageList)fChild).locked)
                        {
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcMessageList)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FOpcMessages)fChild).locked)
                        {
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                    
                }
                else if (fParent.fObjectType == FObjectType.OpcMessages)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FOpcMessage)fChild).locked)
                        {
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcMessage)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (fChild.fObjectType == FObjectType.OpcEventItemList)
                        {
                            if (((FOpcEventItemList)fChild).locked)
                            {
                                FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                            }
                        }
                        else
                        {
                            if (((FOpcItemList)fChild).locked)
                            {
                                FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                            }
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcEventItemList)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FOpcEventItem)fChild).locked)
                        {
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcItemList)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FOpcItem)fChild).locked)
                        {
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcEventItem)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FOpcItem)fChild).locked)
                        {
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcItem)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FOpcItem)fChild).locked)
                        {
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }

                // --

                // ***
                // Remove OPC Object가 1개 이상일 경우 사용자에게 Confirm를 받는다.
                // ***
                if (tvwTree.SelectedNodes.Count > 1)
                {
                    dialogResult = FMessageBox.showQuestion(
                        FConstants.ApplicationName,
                        m_fOpmCore.fWsmCore.fUIWizard.generateMessage("Q0004", new object[] { "Object" }),
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button2,
                        m_fOpmCore.fWsmCore.fWsmContainer
                        );
                    if (dialogResult == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }

                // --

                // ***
                // OPC Object Remove
                // ***
                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fChilds = new FOpcLibraryGroup[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FOpcLibraryGroup)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FOpcDriver)fParent).removeChildOpcLibraryGroup((FOpcLibraryGroup[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.OpcLibraryGroup)
                {
                    fChilds = new FOpcLibrary[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FOpcLibrary)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FOpcLibraryGroup)fParent).removeChildOpcLibrary((FOpcLibrary[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.OpcLibrary)
                {
                    fChilds = new FOpcMessageList[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FOpcMessageList)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FOpcLibrary)fParent).removeChildOpcMessageList((FOpcMessageList[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.OpcMessageList)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChilds = new FOpcMessages[tvwTree.SelectedNodes.Count];
                        // --
                        for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                        {
                            fChilds[i] = (FOpcMessages)tvwTree.SelectedNodes[i].Tag;
                        }
                        // --
                        ((FOpcMessageList)fParent).removeChildOpcMessages((FOpcMessages[])fChilds);
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcMessages)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChilds = new FOpcMessage[tvwTree.SelectedNodes.Count];
                        // --
                        for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                        {
                            fChilds[i] = (FOpcMessage)tvwTree.SelectedNodes[i].Tag;
                        }
                        // --
                        ((FOpcMessages)fParent).removeChildOpcMessage((FOpcMessage[])fChilds);
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcMessage)
                {
                    // --
                }
                else if (fParent.fObjectType == FObjectType.OpcEventItemList)
                {
                    fChilds = new FOpcEventItem[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FOpcEventItem)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FOpcEventItemList)fParent).removeChildOpcEventItem((FOpcEventItem[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.OpcItemList)
                {
                    fChilds = new FOpcItem[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FOpcItem)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FOpcItemList)fParent).removeChildOpcItem((FOpcItem[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.OpcEventItem)
                {
                    // --
                }
                else if (fParent.fObjectType == FObjectType.OpcItem)
                {
                    // --
                }

                // --

                tvwTree.beginUpdate();

                // --

                foreach (FIObject f in fChilds)
                {
                    tvwTree.GetNodeByKey(f.uniqueIdToString).Remove();
                }

                // --

                // ***
                // 모든 자식 노드가 삭제될 경우 Parent Node가 Active되게 처리
                // (그렇지 않을 경우 Root Node가 Active되나 Active Event가 발생하지 않음)
                // ***
                if (tNodeParent.Nodes.Count == 0)
                {
                    tvwTree.ActiveNode = tNodeParent;
                }

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeParent = null;
                fParent = null;
                fChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuResetItemList(
            )
        {
            UltraTreeNode tNode = null;
            FIObject fIObject = null;
            FIObject fChild = null;
            FIObject[] fChilds = null;
            string psnUniqueId = string.Empty;

            try
            {
                tNode = tvwTree.ActiveNode;
                fIObject = (FIObject)tNode.Tag;

                // --

                // ***
                // Removing OPC Object Validate
                // ***
                if (fIObject.fObjectType == FObjectType.OpcEventItemList)
                {
                    foreach (UltraTreeNode tChildNode in tNode.Nodes)
                    {
                        fChild = (FIObject)tChildNode.Tag;
                        if (((FOpcEventItem)fChild).locked)
                        {
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fIObject.fObjectType == FObjectType.OpcItemList)
                {
                    foreach (UltraTreeNode tChildNode in tNode.Nodes)
                    {
                        fChild = (FIObject)tChildNode.Tag;
                        if (((FOpcItem)fChild).locked)
                        {
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }

                // --

                // ***
                // OPC Object Remove
                // ***
                if (fIObject.fObjectType == FObjectType.OpcEventItemList)
                {
                    fChilds = new FOpcEventItem[tNode.Nodes.Count];
                    // --
                    for (int i = 0; i < tNode.Nodes.Count; i++)
                    {
                        fChilds[i] = (FOpcEventItem)tNode.Nodes[i].Tag;
                    }
                    // --
                    ((FOpcEventItemList)fIObject).removeChildOpcEventItem((FOpcEventItem[])fChilds);
                }
                else if (fIObject.fObjectType == FObjectType.OpcItemList)
                {
                    fChilds = new FOpcItem[tNode.Nodes.Count];
                    // --
                    for (int i = 0; i < tNode.Nodes.Count; i++)
                    {
                        fChilds[i] = (FOpcItem)tNode.Nodes[i].Tag;
                    }
                    // --
                    ((FOpcItemList)fIObject).removeChildOpcItem((FOpcItem[])fChilds);
                }

                // --

                tvwTree.beginUpdate();

                // --

                foreach (FIObject f in fChilds)
                {
                    tvwTree.GetNodeByKey(f.uniqueIdToString).Remove();
                }

                // --

                // ***
                // 모든 자식 노드가 삭제될 경우 Parent Node가 Active되게 처리
                // (그렇지 않을 경우 Root Node가 Active되나 Active Event가 발생하지 않음)
                // ***
                if (tNode.Nodes.Count == 0)
                {
                    tvwTree.ActiveNode = tNode;
                }

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                fIObject = null;
                fChild = null;
                fChilds = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuResetItemValue(
            )
        {
            UltraTreeNode tNode = null;
            FIObject fIObject = null;
            try
            {
                tNode = tvwTree.ActiveNode;
                fIObject = (FIObject)tNode.Tag;

                // --
                if (fIObject.fObjectType == FObjectType.OpcItemList)
                {
                    foreach (FOpcItem fOpcItem in ((FOpcItemList)fIObject).fChildOpcItemCollection)
                    {
                        fOpcItem.originalStringValue = string.Empty;
                        // --
                        refreshObject(fOpcItem);
                    }
                }

                // --
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                fIObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuMoveUpObject(
            string menuKey
            )
        {
            UltraTreeNode tNode = null;
            FIObject fObject = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                tNode = tvwTree.ActiveNode;
                fObject = (FIObject)tNode.Tag;

                //--

                if (fObject.fObjectType == FObjectType.OpcLibraryGroup)
                {
                    ((FOpcLibraryGroup)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.OpcLibrary)
                {
                    ((FOpcLibrary)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.OpcMessageList)
                {
                    ((FOpcMessageList)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.OpcMessages)
                {
                    ((FOpcMessages)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.OpcMessage)
                {
                    // --
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItemList)
                {
                    // --
                }
                else if (fObject.fObjectType == FObjectType.OpcItemList)
                {
                    // --
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItem)
                {
                    ((FOpcEventItem)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.OpcItem)
                {
                    ((FOpcItem)fObject).moveUp();
                }

                // -- 

                tvwTree.moveUpNode(tNode);
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNode;

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuMoveDownObject(
            string menuKey
            )
        {
            UltraTreeNode tNode = null;
            FIObject fObject = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                tNode = tvwTree.ActiveNode;
                fObject = (FIObject)tNode.Tag;

                //--

                if (fObject.fObjectType == FObjectType.OpcLibraryGroup)
                {
                    ((FOpcLibraryGroup)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.OpcLibrary)
                {
                    ((FOpcLibrary)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.OpcMessageList)
                {
                    ((FOpcMessageList)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.OpcMessages)
                {
                    ((FOpcMessages)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.OpcMessage)
                {
                    // --
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItemList)
                {
                    // --
                }
                else if (fObject.fObjectType == FObjectType.OpcItemList)
                {
                    // --
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItem)
                {
                    ((FOpcEventItem)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.OpcItem)
                {
                    ((FOpcItem)fObject).moveDown();
                }

                // --

                tvwTree.moveDownNode(tNode);
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNode;

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRelation(
            )
        {
            try
            {
                if (tvwTree.ActiveNode == null)
                {
                    return;
                }

                // --

                m_fOpmCore.fOpmContainer.showRelationViewer((FIObject)tvwTree.ActiveNode.Tag);
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

        private void procMenuValidation(
            )
        {
            try
            {
                if (tvwTree.ActiveNode == null)
                {
                    return;
                }

                // --

                m_fOpmCore.fOpmContainer.showValidationViewer();
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

        private void procMenuImportTagByText(
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeNewChild = null;
            FIObject fParent = null;
            FIObject fNewChild = null;
            try
            {
                if (tvwTree.ActiveNode == null)
                {
                    return;
                }

                // --

                tvwTree.beginUpdate();

                // --
                tNodeParent = tvwTree.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                using (FImportTagEditor fte = new FImportTagEditor(m_fOpmCore))
                {
                    if (fte.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string[] lineSplited = fte.ImportedText.Split(new string[] { "\n" }, StringSplitOptions.None);
                        // --
                        foreach (string il in lineSplited)
                        {
                            // address,addr type,format,name
                            string[] cols = il.Split(new string[] { "," }, StringSplitOptions.None);
                            if (cols.Length < 5)
                                continue;

                            // --

                            if (fParent.fObjectType == FObjectType.OpcEventItemList)
                            {
                                fNewChild = ((FOpcEventItemList)fParent).appendChildOpcEventItem(new FOpcEventItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                                // --
                                ((FOpcEventItem)fNewChild).itemName = cols[0].Trim();
                                ((FOpcEventItem)fNewChild).fItemFormat = (FTagFormat)Enum.Parse(typeof(FTagFormat), cols[1]);
                                ((FOpcEventItem)fNewChild).fFormat = (FOpcFormat)Enum.Parse(typeof(FOpcFormat), cols[2]);
                                ((FOpcEventItem)fNewChild).name = cols[3].Trim();
                                ((FOpcEventItem)fNewChild).description = cols[4].Trim();
                            }
                            else
                            {
                                fNewChild = ((FOpcItemList)fParent).appendChildOpcItem(new FOpcItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                                // --
                                ((FOpcItem)fNewChild).itemName = cols[0].Trim();
                                ((FOpcItem)fNewChild).fItemFormat = (FTagFormat)Enum.Parse(typeof(FTagFormat), cols[1]);
                                ((FOpcItem)fNewChild).fFormat = (FOpcFormat)Enum.Parse(typeof(FOpcFormat), cols[2]);
                                ((FOpcItem)fNewChild).name = cols[3].Trim();
                                ((FOpcItem)fNewChild).description = cols[4].Trim();
                            }
                            // --

                            tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
                            tNodeNewChild.Tag = fNewChild;
                            FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);
                            // --
                           
                            tNodeParent.Nodes.Add(tNodeNewChild);
                            tvwTree.SelectedNodes.Clear();
                            tvwTree.ActiveNode = tNodeNewChild;
                            
                            // --
                        }                        
                    }
                }

                // --

                tvwTree.endUpdate();
                
                // --
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuMultiItemEditor(
            )
        {
            UltraTreeNode tNodeParent = null;
            FIObject fParent = null;
            FIObject fNewChild = null;
            // --
            FOpcEventItemList opcEventItemList = null;
            FOpcEventItem opcEventItem = null;
            FOpcEventItem tempfOpcEventItem = null;
            // --
            FOpcItemList opcItemList = null;
            FOpcItem tempfOpcItem = null;
            FOpcItem opcItem = null;
            // --            
            int i = 0;
            int length = 0;
            try
            {
                if (tvwTree.ActiveNode == null)
                {
                    return;
                }

                // --

                tvwTree.beginUpdate();

                // --
                tNodeParent = tvwTree.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;
                if (!fParent.hasChild)
                    throw new Exception("The child node is not exist.");

                // --
                if (fParent.fObjectType == FObjectType.OpcEventItemList)
                {
                    fNewChild = new FOpcEventItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver);
                }
                else
                {
                    fNewChild = new FOpcItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver);
                }

                // --

                using (FMultiItemEditor fte = new FMultiItemEditor(m_fOpmCore, fNewChild))
                {
                    if (fte.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        // --
                        if (fParent.fObjectType == FObjectType.OpcEventItemList)
                        {
                            opcEventItemList = fParent as FOpcEventItemList;
                            tempfOpcEventItem = fte.fIObject as FOpcEventItem;
                            // --
                            i = fte.ApplyAll ? 0 : fte.StartIndex;
                            length = fte.ApplyAll ? opcEventItemList.fChildOpcEventItemCollection.count : (fte.EndIndex + 1);

                            // --
                            // 범위를 초과할 경우 전체 Count 적용
                            if (length > opcEventItemList.fChildOpcEventItemCollection.count)
                            {
                                length = opcEventItemList.fChildOpcEventItemCollection.count;
                            }

                            // --

                            for (; i < length; i++)
                            {
                                opcEventItem = opcEventItemList.fChildOpcEventItemCollection[i];
                                foreach (string lbl in fte.ChangedPropertyList)
                                {
                                    if (lbl == "Name")
                                    {
                                        opcEventItem.name = tempfOpcEventItem.name;
                                    }
                                    else if (lbl == "Description")
                                    {
                                        opcEventItem.description = tempfOpcEventItem.description;
                                    }
                                    else if (lbl == "Color")
                                    {
                                        opcEventItem.fontColor = tempfOpcEventItem.fontColor;
                                    }
                                    else if (lbl == "Bold")
                                    {
                                        opcEventItem.fontBold = tempfOpcEventItem.fontBold;
                                    }
                                    else if (lbl == "Item Format")
                                    {
                                        opcEventItem.fItemFormat = tempfOpcEventItem.fItemFormat;
                                    }
                                    else if (lbl == "Item Array")
                                    {
                                        opcEventItem.itemArray = tempfOpcEventItem.itemArray;
                                    }
                                    else if (lbl == "Always Event")
                                    {
                                        opcEventItem.alwaysEvent = tempfOpcEventItem.alwaysEvent;
                                    }
                                    else if (lbl == "Ignore First")
                                    {
                                        opcEventItem.ignoreFirst = tempfOpcEventItem.ignoreFirst;
                                    }                                    
                                    else if (lbl == "Format")
                                    {
                                        opcEventItem.fFormat = tempfOpcEventItem.fFormat;
                                    }
                                    else if (lbl == tempfOpcEventItem.defUserTagName1)
                                    {
                                        opcEventItem.userTag1 = tempfOpcEventItem.userTag1;
                                    }
                                    else if (lbl == tempfOpcEventItem.defUserTagName2)
                                    {
                                        opcEventItem.userTag2 = tempfOpcEventItem.userTag2;
                                    }
                                    else if (lbl == tempfOpcEventItem.defUserTagName3)
                                    {
                                        opcEventItem.userTag3 = tempfOpcEventItem.userTag3;
                                    }
                                    else if (lbl == tempfOpcEventItem.defUserTagName4)
                                    {
                                        opcEventItem.userTag4 = tempfOpcEventItem.userTag4;
                                    }
                                    else if (lbl == tempfOpcEventItem.defUserTagName5)
                                    {
                                        opcEventItem.userTag5 = tempfOpcEventItem.userTag5;
                                    }
                                }
                            }
                        }
                        else
                        {
                            tempfOpcItem = fte.fIObject as FOpcItem;
                            opcItemList = fParent as FOpcItemList;

                            // --
                            i = fte.ApplyAll ? 0 : fte.StartIndex;
                            length = fte.ApplyAll ? opcItemList.fChildOpcItemCollection.count : (fte.EndIndex + 1);

                            // --
                            // 범위를 초과할 경우 전체 Count 적용
                            if (length > opcItemList.fChildOpcItemCollection.count)
                            {
                                length = opcItemList.fChildOpcItemCollection.count;
                            }

                            // --

                            for (; i < length; i++)
                            {
                                opcItem = opcItemList.fChildOpcItemCollection[i];
                                foreach (string lbl in fte.ChangedPropertyList)
                                {
                                    if (lbl == "Name")
                                    {
                                        opcItem.name = tempfOpcItem.name;
                                    }
                                    else if (lbl == "Description")
                                    {
                                        opcItem.description = tempfOpcItem.description;
                                    }
                                    else if (lbl == "Color")
                                    {
                                        opcItem.fontColor = tempfOpcItem.fontColor;
                                    }
                                    else if (lbl == "Bold")
                                    {
                                        opcItem.fontBold = tempfOpcItem.fontBold;
                                    }
                                    else if (lbl == "Item Format")
                                    {
                                        opcItem.fItemFormat = tempfOpcItem.fItemFormat;
                                    }
                                    else if (lbl == "Item Array")
                                    {
                                        opcItem.itemArray = tempfOpcItem.itemArray;
                                    }
                                    else if (lbl == "Format")
                                    {
                                        opcItem.fFormat = tempfOpcItem.fFormat;
                                    }
                                    else if (lbl == "Scan Mode")
                                    {
                                        opcItem.fScanMode = tempfOpcItem.fScanMode;
                                    }
                                    else if (lbl == "Reserved Word")
                                    {
                                        opcItem.reservedWord = tempfOpcItem.reservedWord;
                                    }
                                    else if (lbl == "Extraction")
                                    {
                                        opcItem.extraction = tempfOpcItem.extraction;
                                    }
                                    else if (lbl == tempfOpcItem.defUserTagName1)
                                    {
                                        opcItem.userTag1 = tempfOpcItem.userTag1;
                                    }
                                    else if (lbl == tempfOpcItem.defUserTagName2)
                                    {
                                        opcItem.userTag2 = tempfOpcItem.userTag2;
                                    }
                                    else if (lbl == tempfOpcItem.defUserTagName3)
                                    {
                                        opcItem.userTag3 = tempfOpcItem.userTag3;
                                    }
                                    else if (lbl == tempfOpcItem.defUserTagName4)
                                    {
                                        opcItem.userTag4 = tempfOpcItem.userTag4;
                                    }
                                    else if (lbl == tempfOpcItem.defUserTagName5)
                                    {
                                        opcItem.userTag5 = tempfOpcItem.userTag5;
                                    }
                                }
                            }
                        }
                    }
                }

                // --

                tvwTree.endUpdate();

                // --
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeParent = null;
                fParent = null;
                fNewChild = null;      
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPlcAddressEditor(
            )
        {
            UltraTreeNode tActiveNode = null;
            FIObject fIObject = null;
            
            try
            {
                if (tvwTree.ActiveNode == null)
                {
                    return;
                }

                // --

                tvwTree.beginUpdate();

                // --
                tActiveNode = tvwTree.ActiveNode;
                fIObject = (FIObject)tActiveNode.Tag;

                // --

                using (FPlcAddressEditor fte = new FPlcAddressEditor(m_fOpmCore, fIObject))
                {
                    if (fte.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        // --
                        // Tag Name상에 Address를 변경한다.
                        refreshObjectAddress(tActiveNode, fte.DataBlock, fte.AdjustValue);

                        // --
                    }
                }

                // --

                tvwTree.endUpdate();

                // --
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {
                tActiveNode = null;
                fIObject = null;
                // --
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuExpand(
            )
        {
            FIObject fObject = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                fObject = (FIObject)tvwTree.ActiveNode.Tag;

                // --

                if (fObject.fObjectType == FObjectType.OpcDriver)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeOlg in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeOlg.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeOlb in tNodeOlg.Nodes)
                        {
                            tNodeOlb.Expanded = true;
                            // --
                            foreach (UltraTreeNode tNodeOml in tNodeOlb.Nodes)
                            {
                                tNodeOml.Expanded = true;
                            }
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcLibraryGroup)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeOlb in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeOlb.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeOml in tNodeOlb.Nodes)
                        {
                            tNodeOml.Expanded = true;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcLibrary)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeOml in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeOml.Expanded = true;
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcMessageList)
                {
                    tvwTree.ActiveNode.Expanded = true;
                }
                else
                {
                    tvwTree.ActiveNode.ExpandAll();
                }

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCollapse(
            )
        {
            FIObject fObject = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                fObject = (FIObject)tvwTree.ActiveNode.Tag;

                // --

                if (fObject.fObjectType == FObjectType.OpcDriver)
                {
                    // OPC Libary Group
                    foreach (UltraTreeNode tNodeOlg in tvwTree.ActiveNode.Nodes)
                    {
                        // OPC Libary
                        foreach (UltraTreeNode tNodeOlb in tNodeOlg.Nodes)
                        {
                            // OPC Message List
                            foreach (UltraTreeNode tNodeOml in tNodeOlb.Nodes)
                            {
                                // OPC Messages
                                foreach (UltraTreeNode tNodeOms in tNodeOml.Nodes)
                                {
                                    // OPC Message
                                    foreach (UltraTreeNode tNodeOmg in tNodeOms.Nodes)
                                    {
                                        tNodeOmg.Expanded = false;
                                    }
                                    // --
                                    tNodeOms.Expanded = false;
                                }
                                // --
                                tNodeOml.Expanded = false;
                            }
                            // --
                            tNodeOlb.Expanded = false;
                        }
                        // --
                        tNodeOlg.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.OpcLibraryGroup)
                {
                    // OPC Libary
                    foreach (UltraTreeNode tNodeOlb in tvwTree.ActiveNode.Nodes)
                    {
                        // OPC Message List
                        foreach (UltraTreeNode tNodeOml in tNodeOlb.Nodes)
                        {
                            // OPC Messages
                            foreach (UltraTreeNode tNodeOms in tNodeOml.Nodes)
                            {
                                // OPC Message
                                foreach (UltraTreeNode tNodeOmg in tNodeOms.Nodes)
                                {
                                    tNodeOmg.Expanded = false;
                                }
                                // --
                                tNodeOms.Expanded = false;
                            }
                            // --
                            tNodeOml.Expanded = false;
                        }
                        // --
                        tNodeOlb.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.OpcLibrary)
                {
                    // OPC Message List
                    foreach (UltraTreeNode tNodeOml in tvwTree.ActiveNode.Nodes)
                    {
                        // OPC Messages
                        foreach (UltraTreeNode tNodeOms in tNodeOml.Nodes)
                        {
                            // OPC Message
                            foreach (UltraTreeNode tNodeOmg in tNodeOms.Nodes)
                            {
                                tNodeOmg.Expanded = false;
                            }
                            // --
                            tNodeOms.Expanded = false;
                        }
                        // --
                        tNodeOml.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.OpcMessageList)
                {
                    // OPC Messages
                    foreach (UltraTreeNode tNodeOms in tvwTree.ActiveNode.Nodes)
                    {
                        // OPC Message
                        foreach (UltraTreeNode tNodeOmg in tNodeOms.Nodes)
                        {
                            tNodeOmg.Expanded = false;
                        }
                        // --
                        tNodeOms.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.OpcMessages)
                {
                    // OPC Message
                    foreach (UltraTreeNode tNodeOmg in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeOmg.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else
                {
                    tvwTree.ActiveNode.CollapseAll();
                }

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuReplace(
            )
        {
            FReplaceNameDialog dialog = null;
            FIObject fObject = null;
            string findWhat = string.Empty;

            try
            {
                fObject = (FIObject)tvwTree.ActiveNode.Tag;
                if (fObject.fObjectType == FObjectType.OpcMessages)
                {
                    findWhat = ((FOpcMessages)fObject).name;
                }
                else if (fObject.fObjectType == FObjectType.OpcMessage)
                {
                    findWhat = ((FOpcMessage)fObject).name;
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItemList)
                {
                    findWhat = ((FOpcEventItemList)fObject).name;
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItem)
                {
                    findWhat = ((FOpcEventItem)fObject).name;
                }
                else if (fObject.fObjectType == FObjectType.OpcItemList)
                {
                    findWhat = ((FOpcItemList)fObject).name;
                }
                else if (fObject.fObjectType == FObjectType.OpcItem)
                {
                    findWhat = ((FOpcItem)fObject).name;
                }
                else
                {
                    return;
                }

                // --

                dialog = new FReplaceNameDialog(
                    m_fOpmCore,
                    findWhat
                    );
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                // --

                procMenuReplaceObject(fObject, dialog.findWhat, dialog.replaceWith);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (dialog != null)
                {
                    dialog.Dispose();
                    dialog = null;
                }
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuReplaceObject(
            FIObject fObject,
            string findWhat,
            string replaceWith
            )
        {
            try
            {
                if (fObject.fObjectType == FObjectType.OpcMessages)
                {
                    foreach (FIObject o in ((FOpcMessages)fObject).fChildOpcMessageCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FOpcMessages)fObject).name = ((FOpcMessages)fObject).name.Replace(findWhat, replaceWith);
                    ((FOpcMessages)fObject).description = ((FOpcMessages)fObject).description.Replace(findWhat, replaceWith);                    
                }
                else if (fObject.fObjectType == FObjectType.OpcMessage)
                {
                    foreach (FIObject o in ((FOpcMessage)fObject).fChildOpcEventItemListCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    foreach (FIObject o in ((FOpcMessage)fObject).fChildOpcItemListCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FOpcMessage)fObject).name = ((FOpcMessage)fObject).name.Replace(findWhat, replaceWith);
                    ((FOpcMessage)fObject).description = ((FOpcMessage)fObject).description.Replace(findWhat, replaceWith);                    
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItemList)
                {
                    foreach (FIObject o in ((FOpcEventItemList)fObject).fChildOpcEventItemCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FOpcEventItemList)fObject).name = ((FOpcEventItemList)fObject).name.Replace(findWhat, replaceWith);
                    ((FOpcEventItemList)fObject).description = ((FOpcEventItemList)fObject).description.Replace(findWhat, replaceWith);                    
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItem)
                {
                    ((FOpcEventItem)fObject).name = ((FOpcEventItem)fObject).name.Replace(findWhat, replaceWith);
                    ((FOpcEventItem)fObject).description = ((FOpcEventItem)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.OpcItemList)
                {
                    foreach (FIObject o in ((FOpcItemList)fObject).fChildOpcItemCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FOpcItemList)fObject).name = ((FOpcItemList)fObject).name.Replace(findWhat, replaceWith);
                    ((FOpcItemList)fObject).description = ((FOpcItemList)fObject).description.Replace(findWhat, replaceWith);                    
                }
                else if (fObject.fObjectType == FObjectType.OpcItem)
                {
                    ((FOpcItem)fObject).name = ((FOpcItem)fObject).name.Replace(findWhat, replaceWith);
                    ((FOpcItem)fObject).description = ((FOpcItem)fObject).description.Replace(findWhat, replaceWith);                    
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

        private void procMenuCut(
            )
        {
            UltraTreeNode tNode = null;
            UltraTreeNode tNodeParent = null;
            FIObject fObject = null;

            try
            {
                tNode = tvwTree.ActiveNode;
                tNodeParent = tNode.Parent;
                fObject = (FIObject)tNode.Tag;

                // --

                if (fObject.fObjectType == FObjectType.OpcLibraryGroup)
                {
                    ((FOpcLibraryGroup)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.OpcLibrary)
                {
                    ((FOpcLibrary)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.OpcMessageList)
                {
                    ((FOpcMessageList)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.OpcMessages)
                {
                    ((FOpcMessages)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.OpcMessage)
                {
                    ((FOpcMessage)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItemList)
                {
                    // --
                }
                else if (fObject.fObjectType == FObjectType.OpcItemList)
                {
                    // --
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItem)
                {
                    ((FOpcEventItem)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.OpcItem)
                {
                    ((FOpcItem)fObject).cut();
                }
                // --

                tvwTree.beginUpdate();

                // --                

                tNode.Remove();

                // -- 

                // ***
                // 모든 자식 노드가 삭제될 경우 Parent Node가 Active되게 처리
                // (그렇지 않을 경우 Root Node가 Active되나 Active Event가 발생하지 않음)
                // ***
                if (tNodeParent.Nodes.Count == 0)
                {
                    tvwTree.ActiveNode = tNodeParent;
                }

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                tNodeParent = null;
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCopy(
            )
        {
            UltraTreeNode tNode = null;
            FIObject fObject = null;

            try
            {
                tNode = tvwTree.ActiveNode;
                fObject = (FIObject)tNode.Tag;

                // --

                if (fObject.fObjectType == FObjectType.OpcLibraryGroup)
                {
                    ((FOpcLibraryGroup)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.OpcLibrary)
                {
                    ((FOpcLibrary)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.OpcMessageList)
                {
                    ((FOpcMessageList)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.OpcMessages)
                {
                    ((FOpcMessages)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.OpcMessage)
                {
                    ((FOpcMessage)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItemList)
                {
                    // --
                    FClipboard.setStringData("FAMATE_OPC_EVENT_ITEM_LIST", fObject.uniqueIdToString);
                }
                else if (fObject.fObjectType == FObjectType.OpcItemList)
                {
                    // --
                    FClipboard.setStringData("FAMATE_OPC_ITEM_LIST", fObject.uniqueIdToString);
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItem)
                {
                    ((FOpcEventItem)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.OpcItem)
                {
                    ((FOpcItem)fObject).copy();
                }

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCopyValues(
            )
        {
            UltraTreeNode tNode = null;
            FIObject fObject = null;

            try
            {
                tNode = tvwTree.ActiveNode;
                fObject = (FIObject)tNode.Tag;

                // --
                                
                if (fObject.fObjectType == FObjectType.OpcItemList)
                {
                    // --
                    ((FOpcItemList)fObject).copyValues();
                }
                
                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPasteValues(
            )
        {
            UltraTreeNode tNodeRef = null;
            FIObject fRefObject = null;

            try
            {
                tNodeRef = tvwTree.ActiveNode;
                fRefObject = (FIObject)tNodeRef.Tag;

                // --

                tvwTree.beginUpdate();
                // --
                
                if (fRefObject.fObjectType == FObjectType.OpcItemList)
                {
                    // --
                    ((FOpcItemList)fRefObject).pasteValues();
                    // --
                    foreach (FOpcItem fOpcItem in ((FOpcItemList)fRefObject).fChildOpcItemCollection)
                    {
                        refreshObject(fOpcItem);
                    }

                    // --
                }
                
                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeRef = null;
                fRefObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPasteSibling(
            )
        {
            UltraTreeNode tNodeRef = null;
            UltraTreeNode tNodeNew = null;
            FIObject fRefObject = null;
            FIObject fNewObject = null;

            try
            {
                tNodeRef = tvwTree.ActiveNode;
                fRefObject = (FIObject)tNodeRef.Tag;

                // --

                tvwTree.beginUpdate();
                // --
                if (fRefObject.fObjectType == FObjectType.OpcLibraryGroup)
                {
                    fNewObject = ((FOpcLibraryGroup)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.OpcLibrary)
                {
                    fNewObject = ((FOpcLibrary)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.OpcMessageList)
                {
                    fNewObject = ((FOpcMessageList)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.OpcMessages)
                {
                    fNewObject = ((FOpcMessages)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.OpcMessage)
                {
                    // --
                }
                else if (fRefObject.fObjectType == FObjectType.OpcEventItemList)
                {
                    // --
                }
                else if (fRefObject.fObjectType == FObjectType.OpcItemList)
                {
                    // --
                }
                else if (fRefObject.fObjectType == FObjectType.OpcEventItem)
                {
                    fNewObject = ((FOpcEventItem)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.OpcItem)
                {
                    fNewObject = ((FOpcItem)fRefObject).pasteSibling();
                }


                tNodeNew = new UltraTreeNode(fNewObject.uniqueIdToString);
                tNodeNew.Tag = fNewObject;
                FCommon.refreshTreeNodeOfObject(fNewObject, tvwTree, tNodeNew);

                // --

                loadTreeOfChildObject(tNodeNew);
                tNodeRef.Parent.Nodes.Insert(tNodeRef.Index + 1, tNodeNew);
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeNew;

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeRef = null;
                tNodeNew = null;
                fRefObject = null;
                fNewObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPasteChild(
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeChild = null;
            FIObject fParent = null;
            FIObject fChild = null;

            try
            {
                tNodeParent = tvwTree.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fChild = ((FOpcDriver)fParent).pasteChildOpcLibraryGroup();
                }
                else if (fParent.fObjectType == FObjectType.OpcLibraryGroup)
                {
                    fChild = ((FOpcLibraryGroup)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.OpcLibrary)
                {
                    fChild = ((FOpcLibrary)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.OpcMessageList)
                {
                    fChild = ((FOpcMessageList)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.OpcMessages)
                {
                    // --
                }
                else if (fParent.fObjectType == FObjectType.OpcMessage)
                {
                    // --
                }
                else if (fParent.fObjectType == FObjectType.OpcEventItemList)
                {
                    string tempData = FClipboard.getStringData("FAMATE_OPC_EVENT_ITEM_LIST");
                    if (tempData == null)
                    {
                        tempData = FClipboard.getStringData("FAMATE_OPC_ITEM_LIST");
                        if (tempData == null)
                        {
                            fChild = ((FOpcEventItemList)fParent).pasteChild();
                        }
                        else
                        {
                            procPasteEventItemList(tempData);
                            return;
                        }
                    }
                    else
                    {
                        procPasteEventItemList(tempData);
                        return;
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcItemList)
                {
                    string tempData = FClipboard.getStringData("FAMATE_OPC_EVENT_ITEM_LIST");
                    if (tempData == null)
                    {
                        tempData = FClipboard.getStringData("FAMATE_OPC_ITEM_LIST");
                        if (tempData == null)
                        {
                            fChild = ((FOpcItemList)fParent).pasteChild();
                        }
                        else
                        {
                            procPasteItemList(tempData);
                            return;
                        }
                    }
                    else
                    {
                        procPasteItemList(tempData);
                        return;
                    }                    
                }
                else if (fParent.fObjectType == FObjectType.OpcEventItem)
                {
                    // --
                }
                else if (fParent.fObjectType == FObjectType.OpcItem)
                {
                    // --
                }

                tNodeChild = new UltraTreeNode(fChild.uniqueIdToString);
                tNodeChild.Tag = fChild;
                FCommon.refreshTreeNodeOfObject(fChild, tvwTree, tNodeChild);

                // --

                loadTreeOfChildObject(tNodeChild);
                tNodeParent.Nodes.Add(tNodeChild);
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeChild;

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeParent = null;
                tNodeChild = null;
                fParent = null;
                fChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPastePrimaryOpcMessage(
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeChild = null;
            FIObject fParent = null;
            FIObject fChild = null;

            try
            {
                tNodeParent = tvwTree.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.OpcMessages)
                {
                    fChild = ((FOpcMessages)fParent).pastePrimaryOpcMessage();
                }


                tNodeChild = new UltraTreeNode(fChild.uniqueIdToString);
                tNodeChild.Tag = fChild;
                FCommon.refreshTreeNodeOfObject(fChild, tvwTree, tNodeChild);

                // --

                loadTreeOfChildObject(tNodeChild);
                tNodeParent.Nodes.Insert(0, tNodeChild);
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeChild;

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeParent = null;
                tNodeChild = null;
                fParent = null;
                fChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPasteSecondaryOpcMessage(
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeChild = null;
            FIObject fParent = null;
            FIObject fChild = null;

            try
            {
                tNodeParent = tvwTree.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.OpcMessages)
                {
                    fChild = ((FOpcMessages)fParent).pasteSecondaryOpcMessage();
                }

                // --

                tNodeChild = new UltraTreeNode(fChild.uniqueIdToString);
                tNodeChild.Tag = fChild;
                FCommon.refreshTreeNodeOfObject(fChild, tvwTree, tNodeChild);

                // --

                loadTreeOfChildObject(tNodeChild);
                tNodeParent.Nodes.Add(tNodeChild);
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeChild;

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeParent = null;
                tNodeChild = null;
                fParent = null;
                fChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSearch(
            string searchWord
            )
        {
            UltraTreeNode tNode = null;
            FIObject fBase = null;
            FIObject fResult = null;

            try
            {
                tNode = tvwTree.ActiveNode;
                fBase = (FIObject)tNode.Tag;

                // --

                fResult = m_fOpmCore.fOpmFileInfo.fOpcDriver.searchOpcLibrarySeries(fBase, searchWord);
                if (fResult == null)
                {
                    FMessageBox.showInformation("Search", m_fOpmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
                    return;
                }

                // --

                tvwTree.beginUpdate();

                // --

                expandTreeForSearch(fResult);
                tNode = tvwTree.GetNodeByKey(fResult.uniqueIdToString);
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNode;

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                fBase = null;
                fResult = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procPasteItemList(
            string uid
            )
        {
            UltraTreeNode sourcetNodeParent = null;
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeNewChild = null;
            FIObject fParent = null;
            FIObject sourcefParent = null;
            FIObject fNewChild = null;
            try
            {
                sourcetNodeParent = tvwTree.GetNodeByKey(uid);
                if (sourcetNodeParent == null)
                {
                    return;
                }

                // --
                tNodeParent = tvwTree.ActiveNode;

                // --

                tvwTree.beginUpdate();

                // --
                fParent = (FIObject)tNodeParent.Tag;
                sourcefParent = (FIObject)sourcetNodeParent.Tag;

                // --

                if (sourcefParent.fObjectType == FObjectType.OpcEventItemList)
                {
                    // --
                    foreach (FOpcEventItem fOpcEventItem in ((FOpcEventItemList)sourcefParent).fChildOpcEventItemCollection)
                    {                        
                        // --

                        fNewChild = ((FOpcItemList)fParent).appendChildOpcItem(new FOpcItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                        // --
                        ((FOpcItem)fNewChild).itemName = fOpcEventItem.itemName;
                        ((FOpcItem)fNewChild).fItemFormat = fOpcEventItem.fItemFormat;
                        ((FOpcItem)fNewChild).fFormat = fOpcEventItem.fFormat;
                        ((FOpcItem)fNewChild).name = fOpcEventItem.name;
                        ((FOpcItem)fNewChild).description = fOpcEventItem.description;

                        // --

                        tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
                        tNodeNewChild.Tag = fNewChild;
                        FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);
                        // --

                        tNodeParent.Nodes.Add(tNodeNewChild);

                        // --
                    }
                }
                else 
                {
                    // --

                    foreach (FOpcItem fOpcItem in ((FOpcItemList)sourcefParent).fChildOpcItemCollection)
                    {
                        // --

                        fNewChild = ((FOpcItemList)fParent).appendChildOpcItem(new FOpcItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                        // --
                        ((FOpcItem)fNewChild).itemName = fOpcItem.itemName;
                        ((FOpcItem)fNewChild).fItemFormat = fOpcItem.fItemFormat;
                        ((FOpcItem)fNewChild).fFormat = fOpcItem.fFormat;
                        ((FOpcItem)fNewChild).name = fOpcItem.name;
                        ((FOpcItem)fNewChild).description = fOpcItem.description;

                        // --

                        tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
                        tNodeNewChild.Tag = fNewChild;
                        FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);
                        // --

                        tNodeParent.Nodes.Add(tNodeNewChild);

                        // --
                    }
                }
                

                // --

                tvwTree.endUpdate();

                // --
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {
                sourcetNodeParent = null;
                tNodeParent = null;
                tNodeNewChild = null;
                fParent = null;
                sourcefParent = null;
                fNewChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procPasteEventItemList(
            string uid
            )
        {
            UltraTreeNode sourcetNodeParent = null;
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeNewChild = null;
            FIObject fParent = null;
            FIObject sourcefParent = null;
            FIObject fNewChild = null;
            try
            {
                sourcetNodeParent = tvwTree.GetNodeByKey(uid);
                if (sourcetNodeParent == null)
                {
                    return;
                }

                // --
                tNodeParent = tvwTree.ActiveNode;

                // --

                tvwTree.beginUpdate();

                // --
                fParent = (FIObject)tNodeParent.Tag;
                sourcefParent = (FIObject)sourcetNodeParent.Tag;

                // --

                if (sourcefParent.fObjectType == FObjectType.OpcEventItemList)
                {
                    // --
                    foreach (FOpcEventItem fOpcEventItem in ((FOpcEventItemList)sourcefParent).fChildOpcEventItemCollection)
                    {
                        // --

                        fNewChild = ((FOpcEventItemList)fParent).appendChildOpcEventItem(new FOpcEventItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                        // --
                        ((FOpcEventItem)fNewChild).itemName = fOpcEventItem.itemName;
                        ((FOpcEventItem)fNewChild).fItemFormat = fOpcEventItem.fItemFormat;
                        ((FOpcEventItem)fNewChild).fFormat = fOpcEventItem.fFormat;
                        ((FOpcEventItem)fNewChild).name = fOpcEventItem.name;
                        ((FOpcEventItem)fNewChild).description = fOpcEventItem.description;

                        // --

                        tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
                        tNodeNewChild.Tag = fNewChild;
                        FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);
                        // --

                        tNodeParent.Nodes.Add(tNodeNewChild);

                        // --
                    }
                }
                else
                {
                    // --

                    foreach (FOpcItem fOpcItem in ((FOpcItemList)sourcefParent).fChildOpcItemCollection)
                    {
                        // --

                        fNewChild = ((FOpcEventItemList)fParent).appendChildOpcEventItem(new FOpcEventItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                        // --
                        ((FOpcEventItem)fNewChild).itemName = fOpcItem.itemName;
                        ((FOpcEventItem)fNewChild).fItemFormat = fOpcItem.fItemFormat;
                        ((FOpcEventItem)fNewChild).fFormat = fOpcItem.fFormat;
                        ((FOpcEventItem)fNewChild).name = fOpcItem.name;
                        ((FOpcEventItem)fNewChild).description = fOpcItem.description;

                        // --

                        tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
                        tNodeNewChild.Tag = fNewChild;
                        FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);
                        // --

                        tNodeParent.Nodes.Add(tNodeNewChild);

                        // --
                    }
                }


                // --

                tvwTree.endUpdate();

                // --
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {
                sourcetNodeParent = null;
                tNodeParent = null;
                tNodeNewChild = null;
                fParent = null;
                sourcefParent = null;
                fNewChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void searchObject(
            FIObject fObject
            )
        {
            UltraTreeNode tNode = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                expandTreeForSearch(fObject);
                tNode = tvwTree.GetNodeByKey(fObject.uniqueIdToString);
                tvwTree.ActiveNode = tNode;

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void expandTreeForSearch(
            FIObject fObject
            )
        {
            FIObject fParent = null;
            UltraTreeNode tNodeParent = null;

            try
            {
                if (fObject.fObjectType == FObjectType.OpcDriver)
                {
                    return;
                }

                // --

                fParent = m_fOpmCore.fOpmFileInfo.fOpcDriver.getParentOfObject(fObject);

                // --

                tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);
                if (tNodeParent == null || !tNodeParent.Expanded)
                {
                    expandTreeForSearch(fParent);
                }

                // --

                if (tNodeParent == null)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);
                }
                tNodeParent.Expanded = true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
                tNodeParent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuImportTagByCsv(
            )
        {
            UltraTreeNode tNode = null;
            UltraTreeNode tNewNode = null;
            FIObject fObject = null;
            FIObject fNewChild = null;
            string[] splitName = null;
            char[] splitOption = { '.' };

            try
            {
                if (tvwTree.ActiveNode == null)
                {
                    return;
                }

                // --

                tvwTree.beginUpdate();

                // --

                tNode = tvwTree.ActiveNode;
                fObject = (FIObject)tNode.Tag;

                // --

                using (FOpcTagSelector fOts = new FOpcTagSelector(m_fOpmCore))
                {
                    if (fOts.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        foreach (FOpcEventItemList fOel in ((FOpcMessage)fObject).fChildOpcEventItemListCollection)
                        {
                            foreach (object[] etag in fOts.fSelectEventTagList)
                            {
                                fNewChild = fOel.appendChildOpcEventItem(new FOpcEventItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                                // --
                                ((FOpcEventItem)fNewChild).itemName = etag[FConstants.OtsEName].ToString();
                                ((FOpcEventItem)fNewChild).fItemFormat = (FTagFormat)Enum.Parse(typeof(FTagFormat), etag[FConstants.OtsEDataType].ToString());
                                ((FOpcEventItem)fNewChild).fFormat = (FOpcFormat)Enum.Parse(typeof(FOpcFormat), etag[FConstants.OtsEFormat].ToString());
                                ((FOpcEventItem)fNewChild).itemArray = (Boolean)etag[FConstants.OtsEArray];
                                ((FOpcEventItem)fNewChild).alwaysEvent = (Boolean)etag[FConstants.OtsEAlwaysEvent];
                                ((FOpcEventItem)fNewChild).ignoreFirst = (Boolean)etag[FConstants.OtsEIgnoreFirst];

                                splitName = etag[FConstants.OtsEName].ToString().Split(splitOption, StringSplitOptions.RemoveEmptyEntries);
                                fNewChild.name = splitName[splitName.Length - 1];
                                //--
                                fNewChild.description = etag[FConstants.OtsEDescription].ToString();
                                // --
                                tNewNode = new UltraTreeNode(fNewChild.uniqueIdToString);
                                tNewNode.Tag = fNewChild;
                                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNewNode);
                                //--
                                tNode.Nodes[0].Nodes.Add(tNewNode);
                            }
                        }

                        foreach (FOpcItemList fOil in ((FOpcMessage)fObject).fChildOpcItemListCollection)
                        {
                            foreach (object[] itag in fOts.fSelectTagList)
                            {
                                fNewChild = fOil.appendChildOpcItem(new FOpcItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                                // --
                                ((FOpcItem)fNewChild).itemName = itag[FConstants.OtsName].ToString();
                                ((FOpcItem)fNewChild).fItemFormat = (FTagFormat)Enum.Parse(typeof(FTagFormat), itag[FConstants.OtsDataType].ToString());
                                ((FOpcItem)fNewChild).fFormat = (FOpcFormat)Enum.Parse(typeof(FOpcFormat), itag[FConstants.OtsFormat].ToString());
                                ((FOpcItem)fNewChild).itemArray = (Boolean)itag[FConstants.OtsArray];

                                splitName = itag[FConstants.OtsName].ToString().Split(splitOption, StringSplitOptions.RemoveEmptyEntries);
                                fNewChild.name = splitName[splitName.Length - 1];
                                // --
                                fNewChild.description = itag[FConstants.OtsDescription].ToString();
                                //--
                                tNewNode = new UltraTreeNode(fNewChild.uniqueIdToString);
                                tNewNode.Tag = fNewChild;
                                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNewNode);
                                //--
                                tNode.Nodes[1].Nodes.Add(tNewNode);
                            }
                        }

                        // --

                        if (tNewNode != null)
                        {
                            tvwTree.SelectedNodes.Clear();
                            tvwTree.ActiveNode = tNode;
                            tvwTree.ActiveNode.ExpandAll();
                        }
                    }
                }

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                tNewNode = null;
                fObject = null;
                fNewChild = null;
                splitName = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FOpcLibraryModeler Form Event Handler

        private void FOpcLibraryModeler_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designTreeOfOpcLibraryModeler();

                // --

                tvwTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuOpmPopupMenu]);

                // --

                m_fEventHandler = new FEventHandler(m_fOpmCore.fOpmFileInfo.fOpcDriver, tvwTree);
                // --
                m_fEventHandler.ObjectInsertBeforeCompleted += new FObjectInsertBeforeCompletedEventHandler(m_fEventHandler_ObjectInsertBeforeCompleted);
                m_fEventHandler.ObjectInsertAfterCompleted += new FObjectInsertAfterCompletedEventHandler(m_fEventHandler_ObjectInsertAfterCompleted);
                m_fEventHandler.ObjectAppendCompleted += new FObjectAppendCompletedEventHandler(m_fEventHandler_ObjectAppendCompleted);
                m_fEventHandler.ObjectRemoveCompleted += new FObjectRemoveCompletedEventHandler(m_fEventHandler_ObjectRemoveCompleted);
                m_fEventHandler.ObjectMoveUpCompleted += new FObjectMoveUpCompletedEventHandler(m_fEventHandler_ObjectMoveUpCompleted);
                m_fEventHandler.ObjectMoveDownCompleted += new FObjectMoveDownCompletedEventHandler(m_fEventHandler_ObjectMoveDownCompleted);
                m_fEventHandler.ObjectMoveToCompleted += new FObjectMoveToCompletedEventHandler(m_fEventHandler_ObjectMoveToCompleted);
                m_fEventHandler.ObjectModifyCompleted += new FObjectModifyCompletedEventHandler(m_fEventHandler_ObjectModifyCompleted);

                // --

                m_fOpmCore.fOption.fChildFormList.add(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void FOpcLibraryModeler_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                loadTreeOfObject();

                // --

                tvwTree.Focus();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FOpcLibraryModeler_FormClosing(
            object sender,
            FormClosingEventArgs e
            )
        {
            try
            {
                if (m_fEventHandler != null)
                {
                    m_fOpmCore.fOpmFileInfo.fOpcDriver.waitEventHandlingCompleted();

                    // --

                    m_fEventHandler.Dispose();
                    // --
                    m_fEventHandler.ObjectInsertBeforeCompleted -= new FObjectInsertBeforeCompletedEventHandler(m_fEventHandler_ObjectInsertBeforeCompleted);
                    m_fEventHandler.ObjectInsertAfterCompleted -= new FObjectInsertAfterCompletedEventHandler(m_fEventHandler_ObjectInsertAfterCompleted);
                    m_fEventHandler.ObjectAppendCompleted -= new FObjectAppendCompletedEventHandler(m_fEventHandler_ObjectAppendCompleted);
                    m_fEventHandler.ObjectRemoveCompleted -= new FObjectRemoveCompletedEventHandler(m_fEventHandler_ObjectRemoveCompleted);
                    m_fEventHandler.ObjectMoveUpCompleted -= new FObjectMoveUpCompletedEventHandler(m_fEventHandler_ObjectMoveUpCompleted);
                    m_fEventHandler.ObjectMoveDownCompleted -= new FObjectMoveDownCompletedEventHandler(m_fEventHandler_ObjectMoveDownCompleted);
                    m_fEventHandler.ObjectMoveToCompleted -= new FObjectMoveToCompletedEventHandler(m_fEventHandler_ObjectMoveToCompleted);
                    m_fEventHandler.ObjectModifyCompleted -= new FObjectModifyCompletedEventHandler(m_fEventHandler_ObjectModifyCompleted);
                    // --                    
                    m_fEventHandler = null;
                }

                // --

                m_fOpmCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fEventHandler Object Evnet Handler

        private void m_fEventHandler_ObjectInsertBeforeCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.OpcLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.OpcLibrary ||
                    e.fObject.fObjectType == FObjectType.OpcMessageList ||
                    e.fObject.fObjectType == FObjectType.OpcMessages ||
                    e.fObject.fObjectType == FObjectType.OpcMessage ||
                    e.fObject.fObjectType == FObjectType.OpcEventItemList ||
                    e.fObject.fObjectType == FObjectType.OpcItemList ||
                    e.fObject.fObjectType == FObjectType.OpcEventItem ||
                    e.fObject.fObjectType == FObjectType.OpcItem
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
                    // --
                    refreshParentNode(e.fParentObject);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ObjectInsertAfterCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.OpcLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.OpcLibrary ||
                    e.fObject.fObjectType == FObjectType.OpcMessageList ||
                    e.fObject.fObjectType == FObjectType.OpcMessages ||
                    e.fObject.fObjectType == FObjectType.OpcMessage ||
                    e.fObject.fObjectType == FObjectType.OpcEventItemList ||
                    e.fObject.fObjectType == FObjectType.OpcItemList ||
                    e.fObject.fObjectType == FObjectType.OpcEventItem ||
                    e.fObject.fObjectType == FObjectType.OpcItem
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
                    // --
                    refreshParentNode(e.fParentObject);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ObjectAppendCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.OpcLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.OpcLibrary ||
                    e.fObject.fObjectType == FObjectType.OpcMessageList ||
                    e.fObject.fObjectType == FObjectType.OpcMessages ||
                    e.fObject.fObjectType == FObjectType.OpcMessage ||
                    e.fObject.fObjectType == FObjectType.OpcEventItemList ||
                    e.fObject.fObjectType == FObjectType.OpcItemList ||
                    e.fObject.fObjectType == FObjectType.OpcEventItem ||
                    e.fObject.fObjectType == FObjectType.OpcItem
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
                    // --
                    refreshParentNode(e.fParentObject);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ObjectRemoveCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.OpcLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.OpcLibrary ||
                    e.fObject.fObjectType == FObjectType.OpcMessageList ||
                    e.fObject.fObjectType == FObjectType.OpcMessages ||
                    e.fObject.fObjectType == FObjectType.OpcMessage ||
                    e.fObject.fObjectType == FObjectType.OpcEventItemList ||
                    e.fObject.fObjectType == FObjectType.OpcItemList ||
                    e.fObject.fObjectType == FObjectType.OpcEventItem ||
                    e.fObject.fObjectType == FObjectType.OpcItem
                    )
                {
                    removeTreeOfObject(e.fObject);
                    // --
                    refreshParentNode(e.fParentObject);
                }
                else if (e.fObject.fObjectType == FObjectType.DataConversion)
                {
                    foreach (FIObject fObject in e.fParentObject.fReferenceObjectCollection)
                    {
                        if (fObject.fObjectType == FObjectType.OpcItem)
                        {
                            refreshObject(fObject);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ObjectMoveUpCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.OpcLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.OpcLibrary ||
                    e.fObject.fObjectType == FObjectType.OpcMessageList ||
                    e.fObject.fObjectType == FObjectType.OpcMessages ||
                    e.fObject.fObjectType == FObjectType.OpcMessage ||
                    e.fObject.fObjectType == FObjectType.OpcEventItemList ||
                    e.fObject.fObjectType == FObjectType.OpcItemList ||
                    e.fObject.fObjectType == FObjectType.OpcEventItem ||
                    e.fObject.fObjectType == FObjectType.OpcItem
                    )
                {
                    moveUpTreeOfObject(e.fObject);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ObjectMoveDownCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.OpcLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.OpcLibrary ||
                    e.fObject.fObjectType == FObjectType.OpcMessageList ||
                    e.fObject.fObjectType == FObjectType.OpcMessages ||
                    e.fObject.fObjectType == FObjectType.OpcMessage ||
                    e.fObject.fObjectType == FObjectType.OpcEventItemList ||
                    e.fObject.fObjectType == FObjectType.OpcItemList ||
                    e.fObject.fObjectType == FObjectType.OpcEventItem ||
                    e.fObject.fObjectType == FObjectType.OpcItem
                    )
                {
                    moveDownTreeOfObject(e.fObject);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ObjectMoveToCompleted(
            object sender, 
            FObjectMoveToCompletedEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.OpcLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.OpcLibrary ||
                    e.fObject.fObjectType == FObjectType.OpcMessageList ||
                    e.fObject.fObjectType == FObjectType.OpcMessages ||
                    e.fObject.fObjectType == FObjectType.OpcMessage ||
                    e.fObject.fObjectType == FObjectType.OpcEventItem ||
                    e.fObject.fObjectType == FObjectType.OpcItem
                    )
                {
                    moveToTreeOfObject(e.fObject, e.fRefObject);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        private void m_fEventHandler_ObjectModifyCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.OpcDriver ||
                    e.fObject.fObjectType == FObjectType.OpcLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.OpcLibrary ||
                    e.fObject.fObjectType == FObjectType.OpcMessageList ||
                    e.fObject.fObjectType == FObjectType.OpcMessages ||
                    e.fObject.fObjectType == FObjectType.OpcMessage ||
                    e.fObject.fObjectType == FObjectType.OpcEventItemList ||
                    e.fObject.fObjectType == FObjectType.OpcItemList ||
                    e.fObject.fObjectType == FObjectType.OpcEventItem ||
                    e.fObject.fObjectType == FObjectType.OpcItem
                    )
                {
                    refreshObject(e.fObject);
                }
                else if (e.fObject.fObjectType == FObjectType.DataSet)
                {
                    foreach (FIObject fObject in ((FDataSet)e.fObject).fReferenceObjectCollection)
                    {
                        if (fObject.fObjectType == FObjectType.OpcMessage)
                        {
                            refreshObject(fObject);
                        }
                    }
                }
                else if (e.fObject.fObjectType == FObjectType.DataConversionSet)
                {
                    foreach (FIObject fObject in ((FDataConversionSet)e.fObject).fReferenceObjectCollection)
                    {
                        if (fObject.fObjectType == FObjectType.OpcItem)
                        {
                            refreshObject(fObject);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region tvwTree Control Event Handler

        private void tvwTree_AfterExpand(
            object sender,
            NodeEventArgs e
            )
        {
            try
            {
                tvwTree.beginUpdate();

                // --

                foreach (UltraTreeNode tNode in e.TreeNode.Nodes)
                {
                    if (tNode.Nodes.Count > 0)
                    {
                        continue;
                    }
                    loadTreeOfChildObject(tNode);
                }

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        private void tvwTree_AfterActivate(
            object sender, 
            NodeEventArgs e
            )
        {
            FIObject fObject = null;

            try
            {
                if (tvwTree.ActiveNode == null)
                {
                    return;
                }

                // --

                fObject = (FIObject)tvwTree.ActiveNode.Tag;
                // --
                if (fObject.fObjectType == FObjectType.OpcDriver)
                {
                    pgdProp.selectedObject = new FPropOcd(m_fOpmCore, pgdProp, (FOpcDriver)fObject);
                }
                else if (fObject.fObjectType == FObjectType.OpcLibraryGroup)
                {
                    pgdProp.selectedObject = new FPropOlg(m_fOpmCore, pgdProp, (FOpcLibraryGroup)fObject);
                }
                else if (fObject.fObjectType == FObjectType.OpcLibrary)
                {
                    pgdProp.selectedObject = new FPropOlb(m_fOpmCore, pgdProp, (FOpcLibrary)fObject);
                }
                else if (fObject.fObjectType == FObjectType.OpcMessageList)
                {
                    pgdProp.selectedObject = new FPropOml(m_fOpmCore, pgdProp, (FOpcMessageList)fObject);
                }
                else if (fObject.fObjectType == FObjectType.OpcMessages)
                {
                    pgdProp.selectedObject = new FPropOms(m_fOpmCore, pgdProp, (FOpcMessages)fObject);
                }
                else if (fObject.fObjectType == FObjectType.OpcMessage)
                {
                    pgdProp.selectedObject = new FPropOmg(m_fOpmCore, pgdProp, (FOpcMessage)fObject);
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItemList)
                {
                    pgdProp.selectedObject = new FPropOel(m_fOpmCore, pgdProp, (FOpcEventItemList)fObject);
                }
                else if (fObject.fObjectType == FObjectType.OpcItemList)
                {
                    pgdProp.selectedObject = new FPropOil(m_fOpmCore, pgdProp, (FOpcItemList)fObject);
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItem)
                {
                    pgdProp.selectedObject = new FPropOei(m_fOpmCore, pgdProp, (FOpcEventItem)fObject);
                }
                else if (fObject.fObjectType == FObjectType.OpcItem)
                {
                    pgdProp.selectedObject = new FPropOit(m_fOpmCore, pgdProp, (FOpcItem)fObject);
                }

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwTree_KeyDown(
            object sender,
            KeyEventArgs e
            )
        {
            FIObject fObject = null;

            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuOpmRemove].SharedProps.Enabled == true)
                    {
                        procMenuRemoveObject();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.X)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuOpmCut].SharedProps.Enabled == true)
                    {
                        procMenuCut();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.C)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuOpmCopy].SharedProps.Enabled == true)
                    {
                        procMenuCopy();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    fObject = (FIObject)this.tvwTree.ActiveNode.Tag;

                    if (fObject.fObjectType == FObjectType.OpcMessages)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuOpmPasteSibling].SharedProps.Enabled == true)
                        {
                            procMenuPasteSibling();
                        }
                        else if (mnuMenu.Tools[FMenuKey.MenuOpmPastePrimaryOpcMessage].SharedProps.Enabled == true)
                        {
                            procMenuPastePrimaryOpcMessage();
                        }
                    }
                    else
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuOpmPasteSibling].SharedProps.Enabled == true)
                        {
                            procMenuPasteSibling();
                        }
                    }
                }
                else if (e.Control && e.KeyCode == Keys.B)
                {
                    fObject = (FIObject)this.tvwTree.ActiveNode.Tag;

                    if (fObject.fObjectType == FObjectType.OpcMessages)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuOpmPasteChild].SharedProps.Enabled == true)
                        {
                            procMenuPasteChild();
                        }
                        else if (mnuMenu.Tools[FMenuKey.MenuOpmPasteSecondaryOpcMessage].SharedProps.Enabled == true)
                        {
                            procMenuPasteSecondaryOpcMessage();
                        }
                    }
                    else
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuOpmPasteChild].SharedProps.Enabled == true)
                        {
                            procMenuPasteChild();
                        }
                    }
                }
                else if (e.Control && e.KeyCode == Keys.U)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuOpmMoveUp].SharedProps.Enabled == true)
                    {
                        procMenuMoveUpObject(FMenuKey.MenuOpmMoveUp);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.D)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuOpmMoveDown].SharedProps.Enabled == true)
                    {
                        procMenuMoveDownObject(FMenuKey.MenuOpmMoveDown);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.E)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuOpmExpand].SharedProps.Enabled == true)
                    {
                        procMenuExpand();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.L)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuOpmCollapse].SharedProps.Enabled == true)
                    {
                        procMenuCollapse();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.R)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuOpmRelation].SharedProps.Enabled == true)
                    {
                        procMenuRelation();
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwTree_Enter(
            object sender,
            EventArgs e
            )
        {
            try
            {
                if (tvwTree.ActiveNode != null)
                {
                    controlMenu();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwTree_MouseMove(
            object sender, 
            MouseEventArgs e
            )
        {
            UltraTreeNode tNode = null;
            FIObject fObject = null;
            FDragDropData fDragDropData = null;

            try
            {
                if (e.Button != System.Windows.Forms.MouseButtons.Left)
                {
                    return;
                }

                // --

                tNode = tvwTree.GetNodeFromPoint(e.X, e.Y);
                if (tNode == null)
                {
                    return;
                }

                // --                               

                fObject = (FIObject)tNode.Tag;
                fDragDropData = new FDragDropData(fObject);
                // --
                tvwTree.DoDragDrop(new DataObject(fDragDropData), DragDropEffects.All);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                tNode = null;
                fObject = null;
                fDragDropData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwTree_DragOver(
            object sender, 
            DragEventArgs e
            )
        {
            FDragDropData fDragDropData = null;
            UltraTreeNode tRefNode = null;
            FIObject fRefObject = null;
            int cnt = 0;
            
            try
            {
                tRefNode = tvwTree.GetNodeFromPoint(tvwTree.PointToClient(new System.Drawing.Point(e.X, e.Y)));
                fDragDropData = e.Data.GetData(typeof(FDragDropData).ToString(), true) as FDragDropData;
                if (tRefNode == null || fDragDropData == null || !fDragDropData.serializableSuccess)
                {
                    if (fDragDropData != null && fDragDropData.oldRefNode != null)
                    {
                        FCommon.resetDragOverTreeNode(fDragDropData.oldRefNode);
                        fDragDropData.oldRefNode = null;
                    }
                    // --
                    e.Effect = DragDropEffects.None;
                    return;
                }

                // --

                if (fDragDropData.oldRefNode != null)
                {
                    FCommon.resetDragOverTreeNode(fDragDropData.oldRefNode);
                }
                // --
                FCommon.setDragOverTreeNode(tRefNode);
                fDragDropData.oldRefNode = tRefNode;

                // --

                fRefObject = (FIObject)tRefNode.Tag;

                // --

                if (fDragDropData.fObject != null)
                {
                    #region FObject

                    if (fRefObject.fObjectType == FObjectType.OpcDriver)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcLibraryGroup)
                        {
                            #region OpcLibraryGroup

                            if (((FOpcDriver)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FOpcDriver)fRefObject).fChildOpcLibraryGroupCollection.count;
                                fRefObject = ((FOpcDriver)fRefObject).fChildOpcLibraryGroupCollection[cnt - 1];
                                if (!fRefObject.Equals(fDragDropData.fObject))
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcLibraryGroup)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcLibraryGroup)
                        {
                            #region OpcLibraryGroup

                            if (((FOpcLibraryGroup)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FOpcLibraryGroup)fRefObject).fNextSibling == null || !((FOpcLibraryGroup)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcLibrary)
                        {
                            #region OpcLibrary

                            if (((FOpcLibraryGroup)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FOpcLibraryGroup)fRefObject).fChildOpcLibraryCollection.count;
                                if (cnt == 0)
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                                else
                                {
                                    fRefObject = ((FOpcLibraryGroup)fRefObject).fChildOpcLibraryCollection[cnt - 1];
                                    if (!fRefObject.Equals(fDragDropData.fObject))
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcLibrary)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcLibrary)
                        {
                            #region OpcLibrary

                            if (((FOpcLibrary)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FOpcLibrary)fRefObject).fNextSibling == null || !((FOpcLibrary)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessageList)
                        {
                            #region OpcMessageList

                            if (((FOpcLibrary)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                // ***
                                // OPC Message List는 다른 OPC Library로 Move 할 수 없다.
                                // ***
                                if (
                                    fDragDropData.sessionUniqueId == string.Empty &&
                                    ((FOpcLibrary)fRefObject).Equals(((FOpcMessageList)fDragDropData.fObject).fParent)
                                    )
                                {
                                    cnt = ((FOpcLibrary)fRefObject).fChildOpcMessageListCollection.count;
                                    fRefObject = ((FOpcLibrary)fRefObject).fChildOpcMessageListCollection[cnt - 1];
                                    if (!fRefObject.Equals(fDragDropData.fObject))
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcMessageList)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessageList)
                        {
                            #region OpcMessageList

                            if (!fRefObject.Equals(fDragDropData.fObject))
                            {
                                if (((FOpcMessageList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                                {
                                    // ***
                                    // OPC Message List는 다른 OPC Library로 Move 할 수 없다.
                                    // ***
                                    if (
                                        fDragDropData.sessionUniqueId == string.Empty &&
                                        ((FOpcMessageList)fRefObject).fParent.Equals(((FOpcMessageList)fDragDropData.fObject).fParent)
                                        )
                                    {
                                        if (
                                            ((FOpcMessageList)fRefObject).fNextSibling == null ||
                                            !((FOpcMessageList)fRefObject).fNextSibling.Equals(fDragDropData.fObject)
                                            )
                                        {
                                            e.Effect = DragDropEffects.Move;
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessages)
                        {
                            #region OpcMessages

                            if (((FOpcMessageList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                // ***
                                // OPC Messages는 다른 OPC Library로 Move 할 수 없다.
                                // ***
                                if (
                                    fDragDropData.sessionUniqueId == string.Empty &&
                                    ((FOpcMessageList)fRefObject).fAncestorOpcLibrary.Equals(((FOpcMessages)fDragDropData.fObject).fAncestorOpcLibrary)
                                    )
                                {
                                    cnt = ((FOpcMessageList)fRefObject).fChildOpcMessagesCollection.count;
                                    if (cnt == 0)
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                    else
                                    {
                                        fRefObject = ((FOpcMessageList)fRefObject).fChildOpcMessagesCollection[cnt - 1];
                                        if (!fRefObject.Equals(fDragDropData.fObject))
                                        {
                                            e.Effect = DragDropEffects.Move;
                                            return;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcMessages)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessages)
                        {
                            #region OpcMessages

                            if (((FOpcMessages)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                // ***
                                // OPC Messages는 다른 OPC Library로 Move 할 수 없다.
                                // ***
                                if (
                                    fDragDropData.sessionUniqueId == string.Empty &&
                                    ((FOpcMessages)fRefObject).fAncestorOpcLibrary.Equals(((FOpcMessages)fDragDropData.fObject).fAncestorOpcLibrary)
                                    )
                                {
                                    if (
                                        !fRefObject.Equals(fDragDropData.fObject) &&
                                        (((FOpcMessages)fRefObject).fNextSibling == null || !((FOpcMessages)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                        )
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessage)
                        {
                            #region OpcMessage

                            if (!((FOpcMessages)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FOpcMessage)fDragDropData.fObject).isPrimary)
                                {
                                    if (((FOpcMessages)fRefObject).canAppendChildPrimaryOpcMessage)
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                                else
                                {
                                    if (((FOpcMessages)fRefObject).canAppendChildSecondaryOpcMessage)
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                            }

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcMessage)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.DataSet)
                        {
                            #region DataSet

                            if (((FOpcMessage)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (!((FDataSet)fDragDropData.fObject).hasChild)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcEventItemList)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcEventItem)
                        {
                            #region OpcEventItem

                            if (((FOpcEventItemList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    fDragDropData.sessionUniqueId == string.Empty &&
                                    ((FOpcEventItemList)fRefObject).fParent.Equals(((FOpcEventItem)fDragDropData.fObject).fAncestorOpcMessage)
                                    )
                                {
                                    cnt = ((FOpcEventItemList)fRefObject).fChildOpcEventItemCollection.count;
                                    fRefObject = ((FOpcEventItemList)fRefObject).fChildOpcEventItemCollection[cnt - 1];
                                    if (!fRefObject.Equals(fDragDropData.fObject))
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcEventItem)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcEventItem)
                        {
                            #region OpcEventItem

                            if (((FOpcEventItem)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    fDragDropData.sessionUniqueId == string.Empty &&
                                    ((FOpcEventItem)fRefObject).fAncestorOpcMessage.Equals(((FOpcEventItem)fDragDropData.fObject).fAncestorOpcMessage) &&
                                    (((FOpcEventItem)fRefObject).fNextSibling == null || !(((FOpcEventItem)fRefObject).fNextSibling.Equals((FOpcEventItem)fDragDropData.fObject)))
                                    )
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Data)
                        {
                            #region Data

                            if (((FOpcEventItem)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcItemList)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcItem)
                        {
                            #region OpcItem

                            if (((FOpcItemList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    fDragDropData.sessionUniqueId == string.Empty &&
                                    ((FOpcItemList)fRefObject).fParent.Equals(((FOpcItem)fDragDropData.fObject).fAncestorOpcMessage)
                                    )
                                {
                                    cnt = ((FOpcItemList)fRefObject).fChildOpcItemCollection.count;
                                    fRefObject = ((FOpcItemList)fRefObject).fChildOpcItemCollection[cnt - 1];
                                    if (!fRefObject.Equals(fDragDropData.fObject))
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcItem)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcItem)
                        {
                            #region OpcItem

                            if (((FOpcItem)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    fDragDropData.sessionUniqueId == string.Empty &&
                                    ((FOpcItem)fRefObject).fAncestorOpcMessage.Equals(((FOpcItem)fDragDropData.fObject).fAncestorOpcMessage) &&
                                    (((FOpcItem)fRefObject).fNextSibling == null || !(((FOpcItem)fRefObject).fNextSibling.Equals((FOpcItem)fDragDropData.fObject)))
                                    )
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataConversionSet)
                        {
                            #region DataConversionSet

                            if (((FOpcItem)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Data)
                        {
                            #region Data

                            if (((FOpcItem)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                    }

                    #endregion
                }
                else if (fDragDropData.fObjectLog != null)
                {
                    #region FObjectLog

                    if (fRefObject.fObjectType == FObjectType.OpcMessageList)
                    {
                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageWrittenLog
                            )
                        {
                            #region OpcMessageLog

                            e.Effect = DragDropEffects.Copy;
                            return;

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcMessages)
                    {
                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageWrittenLog
                            )
                        {
                            #region OpcMessageLog

                            e.Effect = DragDropEffects.Copy;
                            return;

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcEventItemList)
                    {
                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.OpcEventItemLog)
                        {
                            #region OpcEventItemLog

                            e.Effect = DragDropEffects.Copy;
                            return;

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcEventItem)
                    {
                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.OpcEventItemLog)
                        {
                            #region OpcEventItemLog

                            e.Effect = DragDropEffects.Copy;
                            return;

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcItemList)
                    {
                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.OpcItemLog)
                        {
                            #region OpcItemLog

                            e.Effect = DragDropEffects.Copy;
                            return;

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcItem)
                    {
                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.OpcItemLog)
                        {
                            #region OpcItemLog

                            e.Effect = DragDropEffects.Copy;
                            return;

                            #endregion
                        }
                    }

                    #endregion
                }

                // --

                FCommon.resetDragOverTreeNode(tRefNode);
                e.Effect = DragDropEffects.None;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                tRefNode = null;
                fRefObject = null;
                fDragDropData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwTree_DragDrop(
            object sender, 
            DragEventArgs e
            )
        {
            FDragDropAction fAction = FDragDropAction.Move;
            FDragDropData fDragDropData = null;
            UltraTreeNode tRefNode = null;
            UltraTreeNode tNode = null;
            FIObject fRefObject = null;
            int cnt = 0;
            string uniqueId = string.Empty;
            string refUniqueId = string.Empty;
            FOpcMessages fOms = null;
            FDataSetGenerator fDataSetGenertor = null;

            try
            {
                tRefNode = tvwTree.GetNodeFromPoint(tvwTree.PointToClient(new System.Drawing.Point(e.X, e.Y)));
                fDragDropData = e.Data.GetData(typeof(FDragDropData).ToString(), true) as FDragDropData;
                if (tRefNode == null || fDragDropData == null)
                {
                    if (fDragDropData != null && fDragDropData.oldRefNode != null)
                    {
                        FCommon.resetDragOverTreeNode(fDragDropData.oldRefNode);
                        fDragDropData.oldRefNode = null;
                    }
                    return;
                }

                // --

                if (fDragDropData.oldRefNode != null)
                {
                    FCommon.resetDragOverTreeNode(fDragDropData.oldRefNode);
                }

                // --

                fRefObject = (FIObject)tRefNode.Tag;

                // --

                if (fDragDropData.fObject != null)
                {
                    #region FObject

                    if (fRefObject.fObjectType == FObjectType.OpcDriver)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcLibraryGroup)
                        {
                            #region OpcLibraryGroup

                            if (e.Effect == DragDropEffects.Move)
                            {
                                cnt = ((FOpcDriver)fRefObject).fChildOpcLibraryGroupCollection.count;
                                fRefObject = ((FOpcDriver)fRefObject).fChildOpcLibraryGroupCollection[cnt - 1];
                                ((FOpcLibraryGroup)fDragDropData.fObject).moveTo((FOpcLibraryGroup)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcLibraryGroup)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcDriver)fRefObject).pasteChildOpcLibraryGroup();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcLibraryGroup)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcLibraryGroup)
                        {
                            #region OpcLibraryGroup

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FOpcLibraryGroup)fDragDropData.fObject).moveTo((FOpcLibraryGroup)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcLibraryGroup)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcLibraryGroup)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcLibrary)
                        {
                            #region OpcLibrary

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FOpcLibrary)fDragDropData.fObject).moveTo((FOpcLibraryGroup)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcLibrary)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcLibraryGroup)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcLibrary)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcLibrary)
                        {
                            #region OpcLibrary

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FOpcLibrary)fDragDropData.fObject).moveTo((FOpcLibrary)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcLibrary)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcLibrary)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessageList)
                        {
                            #region OpcMessageList

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FOpcMessageList)fDragDropData.fObject).moveTo((FOpcLibrary)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcMessageList)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcLibrary)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcMessageList)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessageList)
                        {
                            #region OpcMessageList

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FOpcMessageList)fDragDropData.fObject).moveTo((FOpcMessageList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcMessageList)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcMessageList)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessages)
                        {
                            #region OpcMessages

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FOpcMessages)fDragDropData.fObject).moveTo((FOpcMessageList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcMessages)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcMessageList)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcMessages)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessages)
                        {
                            #region OpcMessages

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FOpcMessages)fDragDropData.fObject).moveTo((FOpcMessages)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcMessages)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcMessages)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessage)
                        {
                            #region OpcMessage

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcMessage)fDragDropData.fObject).copy();
                                // --
                                if (((FOpcMessage)fDragDropData.fObject).isPrimary)
                                {
                                    fDragDropData.fObject = ((FOpcMessages)fRefObject).pastePrimaryOpcMessage();
                                    fAction = FDragDropAction.Copy;
                                }
                                else
                                {
                                    fDragDropData.fObject = ((FOpcMessages)fRefObject).pasteSecondaryOpcMessage();
                                    fAction = FDragDropAction.Copy;
                                }
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcMessage)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.DataSet)
                        {
                            #region DataSet

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fDataSetGenertor = new FDataSetGenerator(m_fOpmCore, (FDataSet)fDragDropData.fObject, fRefObject);
                                if (fDataSetGenertor.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                                {
                                    return;
                                }
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcEventItemList)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcEventItem)
                        {
                            #region OpcEventItem

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FOpcEventItem)fDragDropData.fObject).moveTo((FOpcEventItemList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcEventItem)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcEventItemList)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcEventItem)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcEventItem)
                        {
                            #region OpcEventItem

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FOpcEventItem)fDragDropData.fObject).moveTo((FOpcEventItem)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcEventItem)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcEventItem)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Data)
                        {
                            #region Data

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FData)fDragDropData.fObject).fTargetType = FDataTargetType.Item;
                                ((FData)fDragDropData.fObject).name = fRefObject.name;
                                ((FData)fDragDropData.fObject).targetItem = fRefObject.name;
                                ((FData)fDragDropData.fObject).fontBold = fRefObject.fontBold;
                                ((FData)fDragDropData.fObject).fontColor = fRefObject.fontColor;
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcItemList)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcItem)
                        {
                            #region OpcItem

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FOpcItem)fDragDropData.fObject).moveTo((FOpcItemList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcItem)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcItemList)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcItem)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcItem)
                        {
                            #region OpcItem

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FOpcItem)fDragDropData.fObject).moveTo((FOpcItem)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcItem)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcItem)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataConversionSet)
                        {
                            #region DataConversionSet

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcItem)fRefObject).setDataConversionSet((FDataConversionSet)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Data)
                        {
                            #region Data

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FData)fDragDropData.fObject).fTargetType = FDataTargetType.Item;
                                ((FData)fDragDropData.fObject).name = fRefObject.name;
                                ((FData)fDragDropData.fObject).targetItem = fRefObject.name;
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }

                    #endregion
                }
                else if (fDragDropData.fObjectLog != null)
                {
                    #region FObjectLog

                    if (fRefObject.fObjectType == FObjectType.OpcMessageList)
                    {
                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageWrittenLog
                            )
                        {
                            #region OpcMessageLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fOms = new FOpcMessages(m_fOpmCore.fOpmFileInfo.fOpcDriver);

                                if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog)
                                {
                                    ((FOpcDeviceDataMessageReadLog)fDragDropData.fObjectLog).copy();
                                    // --                                    
                                    fOms.name = ((FOpcDeviceDataMessageReadLog)fDragDropData.fObjectLog).name;
                                    fOms.description = ((FOpcDeviceDataMessageReadLog)fDragDropData.fObjectLog).description;
                                    fOms.fDirection = FOpcDirection.Read;
                                    // --
                                    fDragDropData.fObject = fOms.pastePrimaryOpcMessage();                                    
                                }
                                else
                                {
                                    ((FOpcDeviceDataMessageWrittenLog)fDragDropData.fObjectLog).copy();
                                    // --                                    
                                    fOms.name = ((FOpcDeviceDataMessageWrittenLog)fDragDropData.fObjectLog).name;
                                    fOms.description = ((FOpcDeviceDataMessageWrittenLog)fDragDropData.fObjectLog).description;
                                    fOms.fDirection = FOpcDirection.Write;
                                    // --
                                    fDragDropData.fObject = fOms.pastePrimaryOpcMessage();                                    
                                }

                                // --

                                tvwTree.beginUpdate();

                                // --

                                fOms = ((FOpcMessageList)fRefObject).appendChildOpcMessages(fOms);
                                tNode = new UltraTreeNode(fOms.uniqueIdToString);
                                tNode.Tag = fOms;
                                FCommon.refreshTreeNodeOfObject(fOms, tvwTree, tNode);
                                tRefNode.Nodes.Add(tNode);

                                // --

                                fRefObject = fOms;
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcMessages)
                    {
                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageWrittenLog
                            )
                        {
                            #region OpcMessageLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fOms = new FOpcMessages(m_fOpmCore.fOpmFileInfo.fOpcDriver);

                                if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog)
                                {
                                    ((FOpcDeviceDataMessageReadLog)fDragDropData.fObjectLog).copy();
                                    // --                                    
                                    fOms.name = ((FOpcDeviceDataMessageReadLog)fDragDropData.fObjectLog).name;
                                    fOms.description = ((FOpcDeviceDataMessageReadLog)fDragDropData.fObjectLog).description;
                                    fOms.fDirection = FOpcDirection.Read;
                                    // --
                                    fDragDropData.fObject = fOms.pastePrimaryOpcMessage();                                    
                                }
                                else
                                {
                                    ((FOpcDeviceDataMessageWrittenLog)fDragDropData.fObjectLog).copy();
                                    // --                                    
                                    fOms.name = ((FOpcDeviceDataMessageWrittenLog)fDragDropData.fObjectLog).name;
                                    fOms.description = ((FOpcDeviceDataMessageWrittenLog)fDragDropData.fObjectLog).description;
                                    fOms.fDirection = FOpcDirection.Write;
                                    // --
                                    fDragDropData.fObject = fOms.pastePrimaryOpcMessage();                                    
                                }

                                // --

                                tvwTree.beginUpdate();

                                // --

                                fOms = ((FOpcMessages)fRefObject).fParent.insertAfterChildOpcMessages(fOms, (FOpcMessages)fRefObject);
                                tNode = new UltraTreeNode(fOms.uniqueIdToString);
                                tNode.Tag = fOms;
                                FCommon.refreshTreeNodeOfObject(fOms, tvwTree, tNode);
                                tRefNode.Parent.Nodes.Insert(tRefNode.Index + 1, tNode);

                                // --

                                fRefObject = fOms;
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcEventItemList)
                    {
                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.OpcEventItemLog)
                        {
                            #region OpcEventItemLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcEventItemLog)fDragDropData.fObjectLog).copy();
                                fDragDropData.fObject = ((FOpcEventItemList)fRefObject).pasteChild();
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcEventItem)
                    {
                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.OpcEventItemLog)
                        {
                            #region OpcEventItemLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcEventItemLog)fDragDropData.fObjectLog).copy();
                                fDragDropData.fObject = ((FOpcEventItem)fRefObject).pasteSibling();
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcItemList)
                    {
                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.OpcItemLog)
                        {
                            #region OpcItemLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcItemLog)fDragDropData.fObjectLog).copy();
                                fDragDropData.fObject = ((FOpcItemList)fRefObject).pasteChild();
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcItem)
                    {
                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.OpcItemLog)
                        {
                            #region OpcItemLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcItemLog)fDragDropData.fObjectLog).copy();
                                fDragDropData.fObject = ((FOpcItem)fRefObject).pasteSibling();
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }

                    #endregion
                }
                else
                {
                    return;
                }

                // --

                tvwTree.beginUpdate();

                // --

                if (fAction == FDragDropAction.Move || fAction == FDragDropAction.Copy)
                {
                    uniqueId = fDragDropData.fObject.uniqueIdToString;
                    tNode = tvwTree.GetNodeByKey(uniqueId);
                    if (tNode != null)
                    {
                        tNode.Remove();
                    }
                    tNode = new UltraTreeNode(uniqueId);
                    tNode.Tag = fDragDropData.fObject;
                    FCommon.refreshTreeNodeOfObject(fDragDropData.fObject, tvwTree, tNode);
                    loadTreeOfChildObject(tNode);

                    // --

                    refUniqueId = fRefObject.uniqueIdToString;
                    tRefNode = tvwTree.GetNodeByKey(refUniqueId);
                    if (fRefObject.fObjectType == fDragDropData.fObject.fObjectType)
                    {
                        tRefNode.Parent.Nodes.Insert(tRefNode.Index + 1, tNode);
                    }
                    else
                    {
                        tRefNode.Nodes.Add(tNode);
                    }
                    // --
                    tvwTree.SelectedNodes.Clear();
                    tvwTree.ActiveNode = tNode;
                }
                else if (fAction == FDragDropAction.Set)
                {                    
                    if (
                        fRefObject.fObjectType == FObjectType.OpcMessage ||
                        fRefObject.fObjectType == FObjectType.OpcEventItem ||
                        fRefObject.fObjectType == FObjectType.OpcItem
                        )
                    {
                        tRefNode = tvwTree.GetNodeByKey(fRefObject.uniqueIdToString);
                        if (tRefNode != null)
                        {
                            tvwTree.SelectedNodes.Clear();
                            tvwTree.ActiveNode = tRefNode;
                        }
                    }                    
                }

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fDragDropData = null;
                tRefNode = null;
                tNode = null;
                fRefObject = null;
                fOms = null;
                // --
                if (fDataSetGenertor != null)
                {
                    fDataSetGenertor.Dispose();
                    fDataSetGenertor = null;
                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region mnuMenu Control Event Handler

        private void mnuMenu_ToolClick(
            object sender,
            ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuOpmExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuOpmCollapse)
                {
                    procMenuCollapse();
                }
                else if (e.Tool.Key == FMenuKey.MenuOpmReplace)
                {
                    procMenuReplace();
                }
                else if (e.Tool.Key == FMenuKey.MenuOpmCut)
                {
                    procMenuCut();
                }
                else if (e.Tool.Key == FMenuKey.MenuOpmCopy)
                {
                    procMenuCopy();
                }
                else if (e.Tool.Key == FMenuKey.MenuOpmCopyValues)
                {
                    procMenuCopyValues();
                }
                else if (e.Tool.Key == FMenuKey.MenuOpmPasteValues)
                {
                    procMenuPasteValues();
                }
                else if (e.Tool.Key == FMenuKey.MenuOpmPasteSibling)
                {
                    procMenuPasteSibling();
                }
                else if (e.Tool.Key == FMenuKey.MenuOpmPasteChild)
                {
                    procMenuPasteChild();
                }
                else if (e.Tool.Key == FMenuKey.MenuOpmPastePrimaryOpcMessage)
                {
                    procMenuPastePrimaryOpcMessage();
                }
                else if (e.Tool.Key == FMenuKey.MenuOpmPasteSecondaryOpcMessage)
                {
                    procMenuPasteSecondaryOpcMessage();
                }
                else if (e.Tool.Key == FMenuKey.MenuOpmRemove)
                {
                    procMenuRemoveObject();
                }
                else if (e.Tool.Key == FMenuKey.MenuOpmMoveUp)
                {
                    procMenuMoveUpObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuOpmMoveDown)
                {
                    procMenuMoveDownObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuOpmRelation)
                {
                    procMenuRelation();
                }
                else if (e.Tool.Key == FMenuKey.MenuOpmImportTagByCsv)
                {
                    procMenuImportTagByCsv();
                }
                //else if (e.Tool.Key == FMenuKey.MenuOpmImportTagByText)
                //{
                //    procMenuImportTagByText();
                //}
                //else if (e.Tool.Key == FMenuKey.MenuOpmMultiItemEditor)
                //{
                //    procMenuMultiItemEditor();
                //}
                //else if (e.Tool.Key == FMenuKey.MenuOdmPlcAddressEditor)
                //{
                //    procMenuPlcAddressEditor();
                //}
                //else if (e.Tool.Key == FMenuKey.MenuOpmValidationOPCItem)
                //{
                //    procMenuValidation();
                //}
                //else if (e.Tool.Key == FMenuKey.MenuOpmResetItemList)
                //{
                //    procMenuResetItemList();
                //}
                //else if (e.Tool.Key == FMenuKey.MenuOpmResetItemValue)
                //{
                //    procMenuResetItemValue();
                //}
                else if (
                    e.Tool.Key == FMenuKey.MenuOpmInsertBeforeOpcLibraryGroup ||
                    e.Tool.Key == FMenuKey.MenuOpmInsertBeforeOpcLibrary ||
                    e.Tool.Key == FMenuKey.MenuOpmInsertBeforeOpcMessageList ||
                    e.Tool.Key == FMenuKey.MenuOpmInsertBeforeOpcMessages ||
                    e.Tool.Key == FMenuKey.MenuOpmInsertBeforeOpcEventItem ||
                    e.Tool.Key == FMenuKey.MenuOpmInsertBeforeOpcItem
                    )
                {
                    procMenuInsertBeforeObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuOpmInsertAfterOpcLibraryGroup ||
                    e.Tool.Key == FMenuKey.MenuOpmInsertAfterOpcLibrary ||
                    e.Tool.Key == FMenuKey.MenuOpmInsertAfterOpcMessageList ||
                    e.Tool.Key == FMenuKey.MenuOpmInsertAfterOpcMessages ||
                    e.Tool.Key == FMenuKey.MenuOpmInsertAfterOpcEventItem ||
                    e.Tool.Key == FMenuKey.MenuOpmInsertAfterOpcItem
                    )
                {
                    procMenuInsertAfterObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuOpmAppendOpcLibraryGroup ||
                    e.Tool.Key == FMenuKey.MenuOpmAppendOpcLibrary ||
                    e.Tool.Key == FMenuKey.MenuOpmAppendOpcMessageList ||
                    e.Tool.Key == FMenuKey.MenuOpmAppendOpcMessages ||
                    e.Tool.Key == FMenuKey.MenuOpmAppendPrimaryOpcMessage ||
                    e.Tool.Key == FMenuKey.MenuOpmAppendSecondaryOpcMessage ||
                    e.Tool.Key == FMenuKey.MenuOpmAppendOpcEventItem ||
                    e.Tool.Key == FMenuKey.MenuOpmAppendOpcItem
                    )
                {
                    procMenuAppendObject(e.Tool.Key);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region rstToolbar Control Event Handler

        private void rstToolbar_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                procMenuSearch(e.searchWord);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
