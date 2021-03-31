/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTcpDeviceModeler.cs
--  Creator         : duchoi
--  Create Date     : 2013.07.24
--  Description     : FAMate TCP Modeler TCP Device Modeler Form Class 
--  History         : Created by duchoi at 2013.07.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using System.Text;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.TcpModeler
{
    public partial class FTcpDeviceModeler : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcmCore m_fTcmCore = null;
        private FEventHandler m_fEventHandler = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpDeviceModeler(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpDeviceModeler(
            FTcmCore fTcmCore
            )
            : this()
        {
            base.fUIWizard = fTcmCore.fUIWizard;
            m_fTcmCore = fTcmCore;
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
                    m_fTcmCore = null;
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

        private void designTreeOfTcpDeviceModeler(
            )
        {
            try
            {
                tvwTree.ImageList = new ImageList();
                // --
                tvwTree.ImageList.Images.Add("TcpDriver", Properties.Resources.TcpDriver);
                // --
                tvwTree.ImageList.Images.Add("TcpDevice", Properties.Resources.TcpDevice);
                tvwTree.ImageList.Images.Add("TcpDevice_Closed_unlock", Properties.Resources.TcpDevice_Closed_unlock);
                tvwTree.ImageList.Images.Add("TcpDevice_Closed_lock", Properties.Resources.TcpDevice_Closed_lock);
                tvwTree.ImageList.Images.Add("TcpDevice_Opened_unlock", Properties.Resources.TcpDevice_Opened_unlock);
                tvwTree.ImageList.Images.Add("TcpDevice_Opened_lock", Properties.Resources.TcpDevice_Opened_lock);
                tvwTree.ImageList.Images.Add("TcpDevice_Connected_unlock", Properties.Resources.TcpDevice_Connected_unlock);
                tvwTree.ImageList.Images.Add("TcpDevice_Connected_lock", Properties.Resources.TcpDevice_Connected_lock);
                tvwTree.ImageList.Images.Add("TcpDevice_Selected_unlock", Properties.Resources.TcpDevice_Selected_unlock);
                tvwTree.ImageList.Images.Add("TcpDevice_Selected_lock", Properties.Resources.TcpDevice_Selected_lock);
                // --
                tvwTree.ImageList.Images.Add("TcpSession_unlock", Properties.Resources.TcpSession_unlock);
                tvwTree.ImageList.Images.Add("TcpSession_lock", Properties.Resources.TcpSession_lock);
                // --
                tvwTree.ImageList.Images.Add("TcpMessageList_unlock", Properties.Resources.TcpMessageList_unlock);
                tvwTree.ImageList.Images.Add("TcpMessageList_lock", Properties.Resources.TcpMessageList_lock);
                // --
                tvwTree.ImageList.Images.Add("TcpMessages_Eq_unlock", Properties.Resources.TcpMessages_Eq_unlock);
                tvwTree.ImageList.Images.Add("TcpMessages_Eq_lock", Properties.Resources.TcpMessages_Eq_lock);
                tvwTree.ImageList.Images.Add("TcpMessages_Host_unlock", Properties.Resources.TcpMessages_Host_unlock);
                tvwTree.ImageList.Images.Add("TcpMessages_Host_lock", Properties.Resources.TcpMessages_Host_lock);
                tvwTree.ImageList.Images.Add("TcpMessages_Both_unlock", Properties.Resources.TcpMessages_Both_unlock);
                tvwTree.ImageList.Images.Add("TcpMessages_Both_lock", Properties.Resources.TcpMessages_Both_lock);
                // --
                tvwTree.ImageList.Images.Add("TcpMessage_Command_unlock", Properties.Resources.TcpMessage_Command_unlock);
                tvwTree.ImageList.Images.Add("TcpMessage_Command_lock", Properties.Resources.TcpMessage_Command_lock);
                tvwTree.ImageList.Images.Add("TcpMessage_Reply_unlock", Properties.Resources.TcpMessage_Reply_unlock);
                tvwTree.ImageList.Images.Add("TcpMessage_Reply_lock", Properties.Resources.TcpMessage_Reply_lock);
                tvwTree.ImageList.Images.Add("TcpMessage_Unsolicited_unlock", Properties.Resources.TcpMessage_Unsolicited_unlock);
                tvwTree.ImageList.Images.Add("TcpMessage_Unsolicited_lock", Properties.Resources.TcpMessage_Unsolicited_lock);
                // --
                tvwTree.ImageList.Images.Add("TcpItem_List_unlock", Properties.Resources.TcpItem_List_unlock);
                tvwTree.ImageList.Images.Add("TcpItem_List_lock", Properties.Resources.TcpItem_List_lock);
                tvwTree.ImageList.Images.Add("TcpItem_unlock", Properties.Resources.TcpItem_unlock);
                tvwTree.ImageList.Images.Add("TcpItem_lock", Properties.Resources.TcpItem_lock);
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
                        t.Key == FMenuKey.MenuTdmExpand ||
                        t.Key == FMenuKey.MenuTdmCollapse ||
                        t.Key == FMenuKey.MenuTdmRelation 
                        )
                    {
                        continue;
                    }
                    else if (
                        t.Key == FMenuKey.MenuTdmOpenTcpDevice ||
                        t.Key == FMenuKey.MenuTdmCloseTcpDevice ||
                        t.Key == FMenuKey.MenuTdmSendTcpMessage ||
                        t.Key == FMenuKey.MenuTdmReplace ||
                        t.Key == FMenuKey.MenuTdmCut ||
                        t.Key == FMenuKey.MenuTdmCopy ||
                        t.Key == FMenuKey.MenuTdmPasteSibling ||
                        t.Key == FMenuKey.MenuTdmPasteChild ||
                        t.Key == FMenuKey.MenuTdmPastePrimaryTcpMessage ||
                        t.Key == FMenuKey.MenuTdmPasteSecondaryTcpMessage ||
                        t.Key == FMenuKey.MenuTdmRemove ||
                        t.Key == FMenuKey.MenuTdmMoveUp ||
                        t.Key == FMenuKey.MenuTdmMoveDown ||
                        t.Key == FMenuKey.MenuTdmConvertToXlg
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
                if (fObject.fObjectType == FObjectType.TcpDriver)
                {
                    mnuMenu.Tools[FMenuKey.MenuTdmAppendTcpDevice].SharedProps.Visible = ((FTcpDriver)fObject).canAppendChildTcpDevice;
                    //--
                    mnuMenu.Tools[FMenuKey.MenuTdmPasteChild].SharedProps.Enabled = ((FTcpDriver)fObject).canPasteChildTcpDevice; 
                }
                else if (fObject.fObjectType == FObjectType.TcpDevice)
                {
                    if (((FTcpDevice)fObject).fState == FDeviceState.Closed)
                    {
                        mnuMenu.Tools[FMenuKey.MenuTdmOpenTcpDevice].SharedProps.Enabled = true;
                    }
                    else
                    {
                        mnuMenu.Tools[FMenuKey.MenuTdmCloseTcpDevice].SharedProps.Enabled = true;
                    }
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTdmInsertBeforeTcpDevice].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuTdmInsertAfterTcpDevice].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTdmAppendTcpSession].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.TcpSession)
                {
                    mnuMenu.Tools[FMenuKey.MenuTdmInsertBeforeTcpSession].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuTdmInsertAfterTcpSession].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTdmAppendTcpMessageList].SharedProps.Visible = ((FTcpSession)fObject).hasLibrary;
                }
                else if (fObject.fObjectType == FObjectType.TcpMessageList)
                {
                    mnuMenu.Tools[FMenuKey.MenuTdmInsertBeforeTcpMessageList].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuTdmInsertAfterTcpMessageList].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTdmAppendTcpMessages].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.TcpMessages)
                {
                    mnuMenu.Tools[FMenuKey.MenuTdmInsertBeforeTcpMessages].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuTdmInsertAfterTcpMessages].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTdmAppendPrimaryTcpMessage].SharedProps.Visible = ((FTcpMessages)fObject).canAppendChildPrimaryTcpMessage;
                    if (((FTcpMessages)fObject).canAppendChildSecondaryTcpMessage)
                    {
                        mnuMenu.Tools[FMenuKey.MenuTdmAppendSecondaryTcpMessage].SharedProps.Visible = true;
                        // --
                        mnuMenu.Toolbars[0].Tools[FMenuKey.MenuTdmAppendSecondaryTcpMessage].InstanceProps.IsFirstInGroup = !((FTcpMessages)fObject).canAppendChildPrimaryTcpMessage;
                        ((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuTdmPopupMenu]).Tools[FMenuKey.MenuTdmAppendSecondaryTcpMessage].InstanceProps.IsFirstInGroup = !((FTcpMessages)fObject).canAppendChildPrimaryTcpMessage;
                    }

                    // -- 

                    if (((FTcpDevice)tvwTree.ActiveNode.Parent.Parent.Parent.Tag).fState == FDeviceState.Selected)
                    {
                        foreach (FTcpMessage fTmg in ((FTcpMessages)tvwTree.ActiveNode.Tag).fChildTcpMessageCollection)
                        {
                            if (fTmg.isPrimary)
                            {
                                mnuMenu.Tools[FMenuKey.MenuTdmSendTcpMessage].SharedProps.Enabled = true;
                                break;
                            }
                        }
                    }

                    // --

                    mnuMenu.Tools[FMenuKey.MenuTdmConvertToXlg].SharedProps.Enabled = true;
                }
                else if (fObject.fObjectType == FObjectType.TcpMessage)
                {
                    if (((FTcpDevice)tvwTree.ActiveNode.Parent.Parent.Parent.Parent.Tag).fState == FDeviceState.Selected)
                    {
                        mnuMenu.Tools[FMenuKey.MenuTdmSendTcpMessage].SharedProps.Enabled = true;
                    }
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTdmAppendTcpItem].SharedProps.Visible = fObject.canAppendChild;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTdmConvertToXlg].SharedProps.Enabled = true;
                }
                else if (fObject.fObjectType == FObjectType.TcpItem)
                {
                    mnuMenu.Tools[FMenuKey.MenuTdmInsertBeforeTcpItem].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuTdmInsertAfterTcpItem].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTdmAppendTcpItem].SharedProps.Visible = fObject.canAppendChild;                    
                }

                // --

                if (
                    fObject.fObjectType == FObjectType.TcpDevice ||
                    fObject.fObjectType == FObjectType.TcpSession ||
                    fObject.fObjectType == FObjectType.TcpMessageList ||
                    fObject.fObjectType == FObjectType.TcpMessages ||
                    fObject.fObjectType == FObjectType.TcpMessage ||
                    fObject.fObjectType == FObjectType.TcpItem
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuTdmPasteSibling].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuTdmPasteChild].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuTdmPastePrimaryTcpMessage].SharedProps.Visible = false;
                    mnuMenu.Tools[FMenuKey.MenuTdmPasteSecondaryTcpMessage].SharedProps.Visible = false;
                    // -
                    mnuMenu.Tools[FMenuKey.MenuTdmRemove].SharedProps.Enabled = fObject.canRemove;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTdmMoveUp].SharedProps.Enabled = fObject.canMoveUp;
                    mnuMenu.Tools[FMenuKey.MenuTdmMoveDown].SharedProps.Enabled = fObject.canMoveDown;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTdmCut].SharedProps.Enabled = fObject.canCut;
                    mnuMenu.Tools[FMenuKey.MenuTdmCopy].SharedProps.Enabled = fObject.canCopy;
                    mnuMenu.Tools[FMenuKey.MenuTdmPasteSibling].SharedProps.Enabled = fObject.canPasteSibling;
                    if (fObject.fObjectType == FObjectType.TcpSession)
                    {
                        mnuMenu.Tools[FMenuKey.MenuTdmPasteChild].SharedProps.Enabled =
                            ((FTcpSession)fObject).hasLibrary ? fObject.canPasteChild : false; 
                    }
                    else
                    {
                        mnuMenu.Tools[FMenuKey.MenuTdmPasteChild].SharedProps.Enabled = fObject.canPasteChild;
                    }
                }

                // --

                if (fObject.fObjectType == FObjectType.TcpMessages)
                {
                    if (
                        ((FTcpMessages)fObject).canPastePrimaryTcpMessage ||
                        ((FTcpMessages)fObject).canPasteSecondaryTcpMessage
                        )
                    {
                        mnuMenu.Tools[FMenuKey.MenuTdmPasteSibling].SharedProps.Visible = false;
                        mnuMenu.Tools[FMenuKey.MenuTdmPasteChild].SharedProps.Visible = false;
                        mnuMenu.Tools[FMenuKey.MenuTdmPastePrimaryTcpMessage].SharedProps.Visible = true;
                        mnuMenu.Tools[FMenuKey.MenuTdmPasteSecondaryTcpMessage].SharedProps.Visible = true;
                    }                    
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTdmPastePrimaryTcpMessage].SharedProps.Enabled = ((FTcpMessages)fObject).canPastePrimaryTcpMessage;
                    mnuMenu.Tools[FMenuKey.MenuTdmPasteSecondaryTcpMessage].SharedProps.Enabled = ((FTcpMessages)fObject).canPasteSecondaryTcpMessage;                    
                }

                // --

                // ***
                // 2016.04.26 by spike.lee
                // Replace Menu 제어
                // ***
                if (
                    fObject.fObjectType == FObjectType.TcpMessages ||
                    fObject.fObjectType == FObjectType.TcpMessage ||
                    fObject.fObjectType == FObjectType.TcpItem
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuTdmReplace].SharedProps.Enabled = true;
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

        private string createTreeId(
            string tsnUniqueId,
            string objUniqueId
            )
        {
            try
            {
                return tsnUniqueId + "-" + objUniqueId;
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

        private string getTcpSessionId(
            string uniqueId
            )
        {
            try
            {
                return uniqueId.Substring(0, uniqueId.IndexOf("-"));
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

        private void loadTreeOfObject(
            )
        {
            FTcpDriver fTcd = null;
            UltraTreeNode tNodeTcd = null;
            UltraTreeNode tNodeTdv = null;
            UltraTreeNode tNodeTsn = null;
            UltraTreeNode tNodeTml = null;
            UltraTreeNode tNodeTms = null;
            UltraTreeNode tNodeTmg = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                // ***
                // TCP Driver Load
                // ***
                fTcd = m_fTcmCore.fTcmFileInfo.fTcpDriver;
                tNodeTcd = new UltraTreeNode(fTcd.uniqueIdToString);
                tNodeTcd.Tag = fTcd;
                FCommon.refreshTreeNodeOfObject(fTcd, tvwTree, tNodeTcd);

                // --

                // ***
                // TCP Device Load
                // ***
                foreach (FTcpDevice fTdv in fTcd.fChildTcpDeviceCollection)
                {
                    tNodeTdv = new UltraTreeNode(fTdv.uniqueIdToString);
                    tNodeTdv.Tag = fTdv;
                    FCommon.refreshTreeNodeOfObject(fTdv, tvwTree, tNodeTdv);

                    // --

                    // ***
                    // TCP Session Load
                    // ***
                    foreach (FTcpSession fTsn in fTdv.fChildTcpSessionCollection)
                    {
                        tNodeTsn = new UltraTreeNode(fTsn.uniqueIdToString);
                        tNodeTsn.Tag = fTsn;
                        FCommon.refreshTreeNodeOfObject(fTsn, tvwTree, tNodeTsn);

                        // --

                        // ***
                        // TCP Message List, TCP Messages, TCP Item 개체의 Tree Node ID는
                        // TCP Session 개체의 ID와 해당 개체의 ID를 조합으로 구성한다.
                        // (TcpSessionUniqueID + "-" + ObjectUniqueID)
                        // ***
                        if (fTsn.hasLibrary)
                        {
                            // ***
                            // TCP Message List Load
                            // *** 
                            foreach (FTcpMessageList fTml in fTsn.fLibrary.fChildTcpMessageListCollection)
                            {
                                tNodeTml = new UltraTreeNode(createTreeId(fTsn.uniqueIdToString, fTml.uniqueIdToString));
                                tNodeTml.Tag = fTml;
                                FCommon.refreshTreeNodeOfObject(fTml, tvwTree, tNodeTml);

                                // --

                                // ***
                                // TCP Messages Load
                                // ***
                                foreach (FTcpMessages fTms in fTml.fChildTcpMessagesCollection)
                                {
                                    tNodeTms = new UltraTreeNode(createTreeId(fTsn.uniqueIdToString, fTms.uniqueIdToString));
                                    tNodeTms.Tag = fTms;
                                    FCommon.refreshTreeNodeOfObject(fTms, tvwTree, tNodeTms);

                                    // --

                                    // ***
                                    // TCP Message Load
                                    // ***
                                    foreach (FTcpMessage fTmg in fTms.fChildTcpMessageCollection)
                                    {
                                        tNodeTmg = new UltraTreeNode(createTreeId(fTsn.uniqueIdToString, fTmg.uniqueIdToString));
                                        tNodeTmg.Tag = fTmg;
                                        FCommon.refreshTreeNodeOfObject(fTmg, tvwTree, tNodeTmg);
                                        // --
                                        tNodeTmg.Expanded = false;
                                        tNodeTms.Nodes.Add(tNodeTmg);
                                    }

                                    // --

                                    tNodeTms.Expanded = false;
                                    tNodeTml.Nodes.Add(tNodeTms);
                                }

                                // --

                                tNodeTml.Expanded = true;
                                tNodeTsn.Nodes.Add(tNodeTml);
                            }
                        }

                        // --

                        tNodeTsn.Expanded = true;
                        tNodeTdv.Nodes.Add(tNodeTsn);
                    }

                    // --

                    tNodeTdv.Expanded = true;
                    tNodeTcd.Nodes.Add(tNodeTdv);
                }

                // --

                tNodeTcd.Expanded = true;
                tvwTree.Nodes.Add(tNodeTcd);
                tvwTree.ActiveNode = tNodeTcd;

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
                fTcd = null;
                tNodeTcd = null;
                tNodeTdv = null;
                tNodeTsn = null;
                tNodeTml = null;
                tNodeTms = null;
                tNodeTmg = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfChildObject(
            UltraTreeNode tNodeParent
            )
        {
            FIObject fParent = null;
            UltraTreeNode tNodeChild = null;
            string tsnUniqueId = string.Empty;

            try
            {
                tvwTree.beginUpdate();

                // --

                fParent = (FIObject)tNodeParent.Tag;
                // --
                if (fParent.fObjectType == FObjectType.TcpDriver)
                {
                    foreach (FTcpDevice fTdv in ((FTcpDriver)fParent).fChildTcpDeviceCollection)
                    {
                        tNodeChild = new UltraTreeNode(fTdv.uniqueIdToString);
                        tNodeChild.Tag = fTdv;
                        FCommon.refreshTreeNodeOfObject(fTdv, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpDevice)
                {
                    foreach (FTcpSession fTsn in ((FTcpDevice)fParent).fChildTcpSessionCollection)
                    {
                        tNodeChild = new UltraTreeNode(fTsn.uniqueIdToString);
                        tNodeChild.Tag = fTsn;
                        FCommon.refreshTreeNodeOfObject(fTsn, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpSession)
                {
                    if (((FTcpSession)fParent).hasLibrary)
                    {
                        tsnUniqueId = ((FTcpSession)fParent).uniqueIdToString;
                        foreach (FTcpMessageList fTml in (((FTcpSession)fParent).fLibrary.fChildTcpMessageListCollection))
                        {
                            tNodeChild = new UltraTreeNode(createTreeId(tsnUniqueId, fTml.uniqueIdToString));
                            tNodeChild.Tag = fTml;
                            FCommon.refreshTreeNodeOfObject(fTml, tvwTree, tNodeChild);
                            tNodeParent.Nodes.Add(tNodeChild);
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpMessageList)
                {
                    tsnUniqueId = getTcpSessionId(tNodeParent.Key);
                    foreach (FTcpMessages fTms in ((FTcpMessageList)fParent).fChildTcpMessagesCollection)
                    {
                        tNodeChild = new UltraTreeNode(createTreeId(tsnUniqueId, fTms.uniqueIdToString));
                        tNodeChild.Tag = fTms;
                        FCommon.refreshTreeNodeOfObject(fTms, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpMessages)
                {
                    tsnUniqueId = getTcpSessionId(tNodeParent.Key);
                    foreach (FTcpMessage fTmg in ((FTcpMessages)fParent).fChildTcpMessageCollection)
                    {
                        tNodeChild = new UltraTreeNode(createTreeId(tsnUniqueId, fTmg.uniqueIdToString));
                        tNodeChild.Tag = fTmg;
                        FCommon.refreshTreeNodeOfObject(fTmg, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpMessage)
                {
                    tsnUniqueId = getTcpSessionId(tNodeParent.Key);
                    foreach (FTcpItem fTit in ((FTcpMessage)fParent).fChildTcpItemCollection)
                    {
                        tNodeChild = new UltraTreeNode(createTreeId(tsnUniqueId, fTit.uniqueIdToString));
                        tNodeChild.Tag = fTit;
                        FCommon.refreshTreeNodeOfObject(fTit, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpItem)
                {
                    tsnUniqueId = getTcpSessionId(tNodeParent.Key);
                    foreach (FTcpItem fTit in ((FTcpItem)fParent).fChildTcpItemCollection)
                    {
                        tNodeChild = new UltraTreeNode(createTreeId(tsnUniqueId, fTit.uniqueIdToString));
                        tNodeChild.Tag = fTit;
                        FCommon.refreshTreeNodeOfObject(fTit, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
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

                if (fNewChild.fObjectType == FObjectType.TcpDevice)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);                    
                    fRefChild = ((FTcpDevice)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.TcpSession)
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
                    fRefChild = ((FTcpSession)fNewChild).fNextSibling;
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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

        private void addTreeOfObject2(
            FIObject fParent,
            FIObject fNewChild
            )
        {
            FTcpLibrary fTlb = null;
            FIObject fRefChild = null;
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeNewChild = null;
            UltraTreeNode tNodeRefChild = null;
            string uniqueId = string.Empty;

            try
            {
                if (fNewChild.fObjectType == FObjectType.TcpMessageList)
                {
                    fTlb = ((FTcpMessageList)fNewChild).fAncestorTcpLibrary;
                }
                else if (fNewChild.fObjectType == FObjectType.TcpMessages)
                {
                    fTlb = ((FTcpMessages)fNewChild).fAncestorTcpLibrary;
                }
                else if (fNewChild.fObjectType == FObjectType.TcpMessage)
                {
                    fTlb = ((FTcpMessage)fNewChild).fAncestorTcpLibrary;
                }
                else if (fNewChild.fObjectType == FObjectType.TcpItem)
                {
                    fTlb = ((FTcpItem)fNewChild).fAncestorTcpLibrary;
                }
                else
                {
                    return;
                }

                // --

                tvwTree.beginUpdate();

                // --

                foreach (FTcpDevice fTdv in this.m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildTcpDeviceCollection)
                {
                    foreach (FTcpSession fTsn in fTdv.fChildTcpSessionCollection)
                    {
                        if (fTsn.fLibrary != fTlb)
                        {
                            continue;
                        }

                        // --

                        uniqueId = createTreeId(fTsn.uniqueIdToString, fNewChild.uniqueIdToString);
                        tNodeNewChild = tvwTree.GetNodeByKey(uniqueId);
                        if (tNodeNewChild != null)
                        {
                            continue;
                        }

                        // --

                        if (fNewChild.fObjectType == FObjectType.TcpMessageList)
                        {
                            tNodeParent = tvwTree.GetNodeByKey(fTsn.uniqueIdToString);
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
                            fRefChild = ((FTcpMessageList)fNewChild).fNextSibling;
                        }
                        else if (fNewChild.fObjectType == FObjectType.TcpMessages)
                        {
                            tNodeParent = tvwTree.GetNodeByKey(createTreeId(fTsn.uniqueIdToString, fParent.uniqueIdToString));
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
                            fRefChild = ((FTcpMessages)fNewChild).fNextSibling;
                        }
                        else if (fNewChild.fObjectType == FObjectType.TcpMessage)
                        {
                            tNodeParent = tvwTree.GetNodeByKey(createTreeId(fTsn.uniqueIdToString, fParent.uniqueIdToString));
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
                            fRefChild = ((FTcpMessage)fNewChild).fNextSibling;
                        }
                        else if (fNewChild.fObjectType == FObjectType.TcpItem)
                        {
                            tNodeParent = tvwTree.GetNodeByKey(createTreeId(fTsn.uniqueIdToString, fParent.uniqueIdToString));
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
                            fRefChild = ((FTcpItem)fNewChild).fNextSibling;
                        }

                        // --

                        tNodeNewChild = new UltraTreeNode(uniqueId);
                        tNodeNewChild.Tag = fNewChild;
                        FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);

                        // --

                        if (fRefChild != null)
                        {
                            tNodeRefChild = tvwTree.GetNodeByKey(createTreeId(fTsn.uniqueIdToString, fRefChild.uniqueIdToString));
                        }
                        else
                        {
                            tNodeRefChild = null;
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
                    }
                }

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fTlb = null;
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

        private void removeTreeOfObject2(
            FIObject fChild
            )
        {
            UltraTreeNode tNodeChild = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                foreach (FTcpDevice fTdv in this.m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildTcpDeviceCollection)
                {
                    foreach (FTcpSession fTsn in fTdv.fChildTcpSessionCollection)
                    {
                        tNodeChild = tvwTree.GetNodeByKey(createTreeId(fTsn.uniqueIdToString, fChild.uniqueIdToString));
                        if (tNodeChild == null)
                        {
                            continue;
                        }

                        // --

                        tNodeChild.Remove();
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

                if (fObject.fObjectType == FObjectType.TcpDevice)
                {
                    if (((FTcpDevice)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FTcpDevice)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.TcpSession)
                {
                    if (((FTcpSession)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FTcpSession)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else
                {
                    return;
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

        private void moveUpTreeOfObject2(
            FIObject fObject
            )
        {
            UltraTreeNode tNode = null;
            UltraTreeNode tPrevNode = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                foreach (FTcpDevice fTdv in this.m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildTcpDeviceCollection)
                {
                    foreach (FTcpSession fTsn in fTdv.fChildTcpSessionCollection)
                    {
                        tNode = tvwTree.GetNodeByKey(createTreeId(fTsn.uniqueIdToString, fObject.uniqueIdToString));
                        if (tNode == null)
                        {
                            continue;
                        }
                        tPrevNode = tNode.GetSibling(NodePosition.Previous);

                        // --
                                                
                        if (fObject.fObjectType == FObjectType.TcpMessageList)
                        {
                            if (((FTcpMessageList)fObject).fPreviousSibling == null)
                            {
                                if (tPrevNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FTcpMessageList)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.TcpMessages)
                        {
                            if (((FTcpMessages)fObject).fPreviousSibling == null)
                            {
                                if (tPrevNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FTcpMessages)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.TcpMessage)
                        {
                            if (((FTcpMessage)fObject).fPreviousSibling == null)
                            {
                                if (tPrevNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FTcpMessage)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.TcpItem)
                        {
                            if (((FTcpItem)fObject).fPreviousSibling == null)
                            {
                                if (tPrevNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FTcpItem)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }

                        // --
                                         
                        tvwTree.moveUpNode(tNode);
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

                if (fObject.fObjectType == FObjectType.TcpDevice)
                {
                    if (((FTcpDevice)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FTcpDevice)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.TcpSession)
                {
                    if (((FTcpSession)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FTcpSession)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else
                {
                    return;
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

        private void moveDownTreeOfObject2(
            FIObject fObject
            )
        {
            UltraTreeNode tNode = null;
            UltraTreeNode tNextNode = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                foreach (FTcpDevice fTdv in this.m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildTcpDeviceCollection)
                {
                    foreach (FTcpSession fTsn in fTdv.fChildTcpSessionCollection)
                    {
                        tNode = tvwTree.GetNodeByKey(createTreeId(fTsn.uniqueIdToString, fObject.uniqueIdToString));
                        if (tNode == null)
                        {
                            continue;
                        }
                        tNextNode = tNode.GetSibling(NodePosition.Next);

                        // --
                                                
                        if (fObject.fObjectType == FObjectType.TcpMessageList)
                        {
                            if (((FTcpMessageList)fObject).fNextSibling == null)
                            {
                                if (tNextNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FTcpMessageList)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.TcpMessages)
                        {
                            if (((FTcpMessages)fObject).fNextSibling == null)
                            {
                                if (tNextNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FTcpMessages)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.TcpMessage)
                        {
                            if (((FTcpMessage)fObject).fNextSibling == null)
                            {
                                if (tNextNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FTcpMessage)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.TcpItem)
                        {
                            if (((FTcpItem)fObject).fNextSibling == null)
                            {
                                if (tNextNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FTcpItem)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }

                        // --
                        
                        tvwTree.moveDownNode(tNode);
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

        private void moveToTreeOfObject2(
            FIObject fObject,
            FIObject fRefObject
            )
        {
            FTcpLibrary fTlb = null;
            UltraTreeNode tRefNode = null;
            UltraTreeNode tNode = null;

            try
            {
                if (fObject.fObjectType == FObjectType.TcpMessageList)
                {
                    fTlb = ((FTcpMessageList)fObject).fAncestorTcpLibrary;
                }
                else if (fObject.fObjectType == FObjectType.TcpMessages)
                {
                    fTlb = ((FTcpMessages)fObject).fAncestorTcpLibrary;
                }
                else if (fObject.fObjectType == FObjectType.TcpMessage)
                {
                    fTlb = ((FTcpMessage)fObject).fAncestorTcpLibrary;
                }
                else if (fObject.fObjectType == FObjectType.TcpItem)
                {
                    fTlb = ((FTcpItem)fObject).fAncestorTcpLibrary;
                }
                else
                {
                    return;
                }

                // --

                tvwTree.beginUpdate();

                // --

                foreach (FTcpDevice fTdv in this.m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildTcpDeviceCollection)
                {
                    foreach (FTcpSession fTsn in fTdv.fChildTcpSessionCollection)
                    {
                        if (fTsn.fLibrary != fTlb)
                        {
                            continue;
                        }

                        // --

                        if (fRefObject.fObjectType == FObjectType.TcpLibrary)
                        {
                            tRefNode = tvwTree.GetNodeByKey(fTsn.uniqueIdToString);
                        }
                        else
                        {
                            tRefNode = tvwTree.GetNodeByKey(createTreeId(fTsn.uniqueIdToString, fRefObject.uniqueIdToString));
                        }
                        tNode = tvwTree.GetNodeByKey(createTreeId(fTsn.uniqueIdToString, fObject.uniqueIdToString));

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
                                tNode = new UltraTreeNode(createTreeId(fTsn.uniqueIdToString, fObject.uniqueIdToString));
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
                    }
                }

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fTlb = null;
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

        private void refreshObject2(
            FIObject fObject
            )
        {
            UltraTreeNode tNode = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                foreach (FTcpDevice fTdv in this.m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildTcpDeviceCollection)
                {
                    foreach (FTcpSession fTsn in fTdv.fChildTcpSessionCollection)
                    {
                        tNode = tvwTree.GetNodeByKey(createTreeId(fTsn.uniqueIdToString, fObject.uniqueIdToString));
                        if (tNode == null)
                        {
                            continue;
                        }

                        // --

                        if (tNode.IsActive && !pgdProp.Focused)
                        {
                            pgdProp.onDynPropGridRefreshRequested();
                        }

                        // --

                        FCommon.refreshTreeNodeOfObject(fObject, tvwTree, tNode);
                    }
                }

                // --

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

        private void changeTcpSessionLibrary(
            FTcpSession fTsn
            )
        {
            UltraTreeNode tNodeTsn = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeTsn = tvwTree.GetNodeByKey(fTsn.uniqueIdToString);
                tNodeTsn.Expanded = false;
                tNodeTsn.Nodes.Clear();

                // --

                if (fTsn.hasLibrary)
                {
                    loadTreeOfChildObject(tNodeTsn);

                    // --
                    tNodeTsn.Expanded = true;
                    foreach (UltraTreeNode tNodeTml in tNodeTsn.Nodes)
                    {
                        tNodeTml.Expanded = true;
                        foreach (UltraTreeNode tNodeTms in tNodeTml.Nodes)
                        {
                            tNodeTms.Expanded = false;
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
                tNodeTsn = null;
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
            string uniqueId = string.Empty;

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeParent = tvwTree.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.TcpDriver)
                {
                    fNewChild = ((FTcpDriver)fParent).appendChildTcpDevice(new FTcpDevice(this.m_fTcmCore.fTcmFileInfo.fTcpDriver));
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.TcpDevice)
                {
                    fNewChild = ((FTcpDevice)fParent).appendChildTcpSession(new FTcpSession(this.m_fTcmCore.fTcmFileInfo.fTcpDriver));
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.TcpSession)
                {
                    fNewChild = ((FTcpSession)fParent).fLibrary.appendChildTcpMessageList(new FTcpMessageList(this.m_fTcmCore.fTcmFileInfo.fTcpDriver));
                    uniqueId = createTreeId(tNodeParent.Key, fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.TcpMessageList)
                {
                    fNewChild = ((FTcpMessageList)fParent).appendChildTcpMessages(new FTcpMessages(this.m_fTcmCore.fTcmFileInfo.fTcpDriver));
                    uniqueId = createTreeId(getTcpSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.TcpMessages)
                {
                    if (menuKey == FMenuKey.MenuTdmAppendPrimaryTcpMessage)
                    {
                        fNewChild = ((FTcpMessages)fParent).appendChildPrimaryTcpMessage(new FTcpMessage(this.m_fTcmCore.fTcmFileInfo.fTcpDriver));
                    }
                    else
                    {
                        fNewChild = ((FTcpMessages)fParent).appendChildSecondaryTcpMessage(new FTcpMessage(this.m_fTcmCore.fTcmFileInfo.fTcpDriver));
                    }
                    uniqueId = createTreeId(getTcpSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.TcpMessage)
                {
                    fNewChild = ((FTcpMessage)fParent).appendChildTcpItem(new FTcpItem(this.m_fTcmCore.fTcmFileInfo.fTcpDriver));
                    uniqueId = createTreeId(getTcpSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.TcpItem)
                {
                    fNewChild = new FTcpItem(this.m_fTcmCore.fTcmFileInfo.fTcpDriver);
                    if (((FTcpItem)fParent).fFormat == FFormat.AsciiList)
                    {
                        ((FTcpItem)fNewChild).fFormat = FFormat.Ascii;
                    }
                    fNewChild = ((FTcpItem)fParent).appendChildTcpItem((FTcpItem)fNewChild);
                    uniqueId = createTreeId(getTcpSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);

                }

                // --

                tNodeNewChild = new UltraTreeNode(uniqueId);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);
                // --
                if (fParent.fObjectType == FObjectType.TcpMessages)
                {
                    if (((FTcpMessage)fNewChild).isPrimary)
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
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeNewChild;

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
            string uniqueId = string.Empty;

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeRefChild = tvwTree.ActiveNode;
                tNodeParent = tNodeRefChild.Parent;
                fRefChild = (FIObject)tNodeRefChild.Tag;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.TcpDriver)
                {
                    fNewChild = ((FTcpDriver)fParent).insertBeforeChildTcpDevice(
                        new FTcpDevice(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FTcpDevice)fRefChild
                        );
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.TcpDevice)
                {
                    fNewChild = ((FTcpDevice)fParent).insertBeforeChildTcpSession(
                        new FTcpSession(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FTcpSession)fRefChild
                        );
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.TcpSession)
                {
                    fNewChild = ((FTcpSession)fParent).fLibrary.insertBeforeChildTcpMessageList(
                        new FTcpMessageList(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FTcpMessageList)fRefChild
                        );
                    uniqueId = createTreeId(tNodeParent.Key, fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.TcpMessageList)
                {
                    fNewChild = ((FTcpMessageList)fParent).insertBeforeChildTcpMessages(
                        new FTcpMessages(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FTcpMessages)fRefChild
                        );
                    uniqueId = createTreeId(getTcpSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.TcpMessages)
                {
                    // ***
                    // 사용안함.
                    // ***
                }
                else if (fParent.fObjectType == FObjectType.TcpMessage)
                {
                    fNewChild = ((FTcpMessage)fParent).insertBeforeChildTcpItem(
                        new FTcpItem(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FTcpItem)fRefChild
                        );
                    uniqueId = createTreeId(getTcpSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.TcpItem)
                {
                    fNewChild = new FTcpItem(this.m_fTcmCore.fTcmFileInfo.fTcpDriver);
                    if (((FTcpItem)fParent).fFormat == FFormat.AsciiList)
                    {
                        ((FTcpItem)fNewChild).fFormat = FFormat.Ascii;
                    }
                    fNewChild = ((FTcpItem)fParent).insertBeforeChildTcpItem((FTcpItem)fNewChild, (FTcpItem)fRefChild);
                    uniqueId = createTreeId(getTcpSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }

                // --

                tNodeNewChild = new UltraTreeNode(uniqueId);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);
                tNodeParent.Nodes.Insert(tNodeRefChild.Index, tNodeNewChild);
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeNewChild;

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
            string uniqueId = string.Empty;

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeRefChild = tvwTree.ActiveNode;
                tNodeParent = tNodeRefChild.Parent;
                fRefChild = (FIObject)tNodeRefChild.Tag;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.TcpDriver)
                {
                    fNewChild = ((FTcpDriver)fParent).insertAfterChildTcpDevice(
                        new FTcpDevice(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FTcpDevice)fRefChild
                        );
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.TcpDevice)
                {
                    fNewChild = ((FTcpDevice)fParent).insertAfterChildTcpSession(
                        new FTcpSession(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FTcpSession)fRefChild
                        );
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.TcpSession)
                {
                    fNewChild = ((FTcpSession)fParent).fLibrary.insertAfterChildTcpMessageList(
                        new FTcpMessageList(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FTcpMessageList)fRefChild
                        );
                    uniqueId = createTreeId(tNodeParent.Key, fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.TcpMessageList)
                {
                    fNewChild = ((FTcpMessageList)fParent).insertAfterChildTcpMessages(
                        new FTcpMessages(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FTcpMessages)fRefChild
                        );
                    uniqueId = createTreeId(getTcpSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.TcpMessages)
                {
                    // ***
                    // 사용안함.
                    // ***
                }
                else if (fParent.fObjectType == FObjectType.TcpMessage)
                {
                    fNewChild = ((FTcpMessage)fParent).insertAfterChildTcpItem(
                        new FTcpItem(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FTcpItem)fRefChild
                        );
                    uniqueId = createTreeId(getTcpSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.TcpItem)
                {
                    fNewChild = new FTcpItem(this.m_fTcmCore.fTcmFileInfo.fTcpDriver);
                    if (((FTcpItem)fParent).fFormat == FFormat.AsciiList)
                    {
                        ((FTcpItem)fNewChild).fFormat = FFormat.Ascii;
                    }
                    fNewChild = ((FTcpItem)fParent).insertAfterChildTcpItem((FTcpItem)fNewChild, (FTcpItem)fRefChild);
                    uniqueId = createTreeId(getTcpSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }

                // --

                tNodeNewChild = new UltraTreeNode(uniqueId);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);
                tNodeParent.Nodes.Insert(tNodeRefChild.Index + 1, tNodeNewChild);
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeNewChild;

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
            string tsnUniqueId = string.Empty;

            try
            {
                tvwTree.ActiveNode.Selected = true;
                tNodeParent = tvwTree.ActiveNode.Parent;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                // ***
                // Removing TCP Object Validate
                // ***
                if (fParent.fObjectType == FObjectType.TcpDriver)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FTcpDevice)fChild).locked)
                        {
                            FDebug.throwFException(m_fTcmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpDevice)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FTcpSession)fChild).locked)
                        {
                            FDebug.throwFException(m_fTcmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpSession)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FTcpMessageList)fChild).locked)
                        {
                            FDebug.throwFException(m_fTcmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpMessageList)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FTcpMessages)fChild).locked)
                        {
                            FDebug.throwFException(m_fTcmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpMessages)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FTcpMessage)fChild).locked)
                        {
                            FDebug.throwFException(m_fTcmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpMessage)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FTcpItem)fChild).locked)
                        {
                            FDebug.throwFException(m_fTcmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpItem)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FTcpItem)fChild).locked)
                        {
                            FDebug.throwFException(m_fTcmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }

                // --

                // ***
                // Remove TCP Object가 1개 이상일 경우 사용자에게 Confirm를 받는다.
                // ***
                if (tvwTree.SelectedNodes.Count > 1)
                {
                    dialogResult = FMessageBox.showQuestion(
                        FConstants.ApplicationName,
                        m_fTcmCore.fWsmCore.fUIWizard.generateMessage("Q0004", new object[] { "Object" }),
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button2,
                        m_fTcmCore.fWsmCore.fWsmContainer
                        );
                    if (dialogResult == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }

                // --

                // ***
                // TCP Object Remove
                // ***
                if (fParent.fObjectType == FObjectType.TcpDriver)
                {
                    fChilds = new FTcpDevice[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FTcpDevice)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FTcpDriver)fParent).removeChildTcpDevice((FTcpDevice[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.TcpDevice)
                {
                    fChilds = new FTcpSession[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FTcpSession)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FTcpDevice)fParent).removeChildTcpSession((FTcpSession[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.TcpSession)
                {
                    fChilds = new FTcpMessageList[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FTcpMessageList)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FTcpSession)fParent).fLibrary.removeChildTcpMessageList((FTcpMessageList[])fChilds);
                    tsnUniqueId = tNodeParent.Key;
                }
                else if (fParent.fObjectType == FObjectType.TcpMessageList)
                {
                    fChilds = new FTcpMessages[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FTcpMessages)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FTcpMessageList)fParent).removeChildTcpMessages((FTcpMessages[])fChilds);
                    tsnUniqueId = getTcpSessionId(tNodeParent.Key);
                }
                else if (fParent.fObjectType == FObjectType.TcpMessages)
                {
                    fChilds = new FTcpMessage[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FTcpMessage)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FTcpMessages)fParent).removeChildTcpMessage((FTcpMessage[])fChilds);
                    tsnUniqueId = getTcpSessionId(tNodeParent.Key);
                }
                else if (fParent.fObjectType == FObjectType.TcpMessage)
                {
                    fChilds = new FTcpItem[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FTcpItem)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FTcpMessage)fParent).removeChildTcpItem((FTcpItem[])fChilds);
                    tsnUniqueId = getTcpSessionId(tNodeParent.Key);
                }
                else if (fParent.fObjectType == FObjectType.TcpItem)
                {
                    fChilds = new FTcpItem[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FTcpItem)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FTcpItem)fParent).removeChildTcpItem((FTcpItem[])fChilds);
                    tsnUniqueId = getTcpSessionId(tNodeParent.Key);
                }

                // --

                tvwTree.beginUpdate();

                // --

                if (tsnUniqueId == string.Empty)
                {
                    foreach (FIObject f in fChilds)
                    {
                        tvwTree.GetNodeByKey(f.uniqueIdToString).Remove();
                    }
                }
                else
                {
                    foreach (FIObject f in fChilds)
                    {
                        tvwTree.GetNodeByKey(createTreeId(tsnUniqueId, f.uniqueIdToString)).Remove();
                    }
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

                if (fObject.fObjectType == FObjectType.TcpDevice)
                {
                    ((FTcpDevice)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.TcpSession)
                {
                    ((FTcpSession)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessageList)
                {
                    ((FTcpMessageList)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessages)
                {
                    ((FTcpMessages)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessage)
                {
                    
                }
                else if (fObject.fObjectType == FObjectType.TcpItem)
                {
                    ((FTcpItem)fObject).moveUp();
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

                if (fObject.fObjectType == FObjectType.TcpDevice)
                {
                    ((FTcpDevice)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.TcpSession)
                {
                    ((FTcpSession)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessageList)
                {
                    ((FTcpMessageList)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessages)
                {
                    ((FTcpMessages)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessage)
                {
                    
                }
                else if (fObject.fObjectType == FObjectType.TcpItem)
                {
                    ((FTcpItem)fObject).moveDown();
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

                m_fTcmCore.fTcmContainer.showRelationViewer((FIObject)tvwTree.ActiveNode.Tag);
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

        private void procMenuXlgViewer(
            )
        {
            FTcpProtocolSelector fProtocolSelector = null;
            FXlgViewer fXlgViewer = null;
            FIObject fObject = null;
            StringBuilder sb = null;

            try
            {
                fProtocolSelector = new FTcpProtocolSelector(m_fTcmCore);
                if (fProtocolSelector.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }

                // --

                fXlgViewer = (FXlgViewer)m_fTcmCore.fTcmContainer.getChild(typeof(FXlgViewer));
                if (fXlgViewer == null)
                {
                    fXlgViewer = new FXlgViewer(m_fTcmCore);
                    m_fTcmCore.fTcmContainer.showChild(fXlgViewer);
                }
                fXlgViewer.activate();

                // --

                sb = new StringBuilder();
                foreach (UltraTreeNode node in tvwTree.SelectedNodes)
                {
                    fObject = (FIObject)node.Tag;
                    // --
                    if (fObject.fObjectType == FObjectType.TcpMessage)
                    {
                        sb.Append(((FTcpMessage)fObject).convertToXml(fProtocolSelector.fSelectedProtocol));
                    }
                    else if (fObject.fObjectType == FObjectType.TcpMessages)
                    {
                        sb.Append(((FTcpMessages)fObject).convertToXml(fProtocolSelector.fSelectedProtocol));
                    }
                }
                // --
                fXlgViewer.appendXlg(sb.ToString());
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fProtocolSelector = null;
                fXlgViewer = null;
                fObject = null;
                sb = null;
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

                if (fObject.fObjectType == FObjectType.TcpDriver)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeTdv in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeTdv.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeTsn in tNodeTdv.Nodes)
                        {
                            tNodeTsn.Expanded = true;
                            // --
                            foreach (UltraTreeNode tNodeTml in tNodeTsn.Nodes)
                            {
                                tNodeTml.Expanded = true;
                                // --
                                foreach (UltraTreeNode tNodeTms in tNodeTml.Nodes)
                                {
                                    tNodeTms.Expanded = true;
                                }
                            }
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.TcpDevice)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeTsn in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeTsn.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeTml in tNodeTsn.Nodes)
                        {
                            tNodeTml.Expanded = true;
                            // --
                            foreach (UltraTreeNode tNodeTms in tNodeTml.Nodes)
                            {
                                tNodeTms.Expanded = true;
                            }
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.TcpSession)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeTml in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeTml.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeTms in tNodeTml.Nodes)
                        {
                            tNodeTms.Expanded = true;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.TcpMessageList)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeTms in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeTms.Expanded = true;
                    }
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

                if (fObject.fObjectType == FObjectType.TcpDriver)
                {
                    foreach (UltraTreeNode tNodeTdv in tvwTree.ActiveNode.Nodes)
                    {
                        foreach (UltraTreeNode tNodeTsn in tNodeTdv.Nodes)
                        {
                            foreach (UltraTreeNode tNodeTml in tNodeTsn.Nodes)
                            {
                                foreach (UltraTreeNode tNodeTms in tNodeTml.Nodes)
                                {
                                    tNodeTms.Expanded = false;
                                }
                                // --
                                tNodeTml.Expanded = false;
                            }
                            // --
                            tNodeTsn.Expanded = false;
                        }
                        // --
                        tNodeTdv.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.TcpDevice)
                {
                    foreach (UltraTreeNode tNodeTsn in tvwTree.ActiveNode.Nodes)
                    {
                        foreach (UltraTreeNode tNodeTml in tNodeTsn.Nodes)
                        {
                            foreach (UltraTreeNode tNodeTms in tNodeTml.Nodes)
                            {
                                tNodeTms.Expanded = false;
                            }
                            // --
                            tNodeTml.Expanded = false;
                        }
                        // --
                        tNodeTsn.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.TcpSession)
                {
                    foreach (UltraTreeNode tNodeTml in tvwTree.ActiveNode.Nodes)
                    {
                        foreach (UltraTreeNode tNodeTms in tNodeTml.Nodes)
                        {
                            tNodeTms.Expanded = false;
                        }
                        // --
                        tNodeTml.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.TcpMessageList)
                {
                    foreach (UltraTreeNode tNodeTms in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeTms.Expanded = false;
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

        private void procMenuOpenTcpDevice(
            )
        {
            FTcpDevice tTcpDevice = null;

            try
            {
                tTcpDevice = (FTcpDevice)tvwTree.ActiveNode.Tag;
                tTcpDevice.open();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tTcpDevice = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCloseTcpDevice(
            )
        {
            FTcpDevice tTcpDevice = null;

            try
            {
                tTcpDevice = (FTcpDevice)tvwTree.ActiveNode.Tag;
                tTcpDevice.close();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tTcpDevice = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSendTcpMessage(
            )
        {
            FIObject fObject = null;
            FTcpMessageTransfer FTcpMessageTransfer = null;

            try
            {
                fObject = (FIObject)tvwTree.ActiveNode.Tag;
                if (fObject.fObjectType == FObjectType.TcpMessages)
                {
                    foreach (FTcpMessage fTmg in ((FTcpMessages)fObject).fChildTcpMessageCollection)
                    {
                        if (fTmg.isPrimary)
                        {
                            FTcpMessageTransfer = fTmg.createTransfer();
                            FTcpMessageTransfer.send((FTcpSession)tvwTree.ActiveNode.Parent.Parent.Tag);
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.TcpMessage)
                {
                    FTcpMessageTransfer = ((FTcpMessage)tvwTree.ActiveNode.Tag).createTransfer();
                    // --
                    FTcpMessageTransfer.send((FTcpSession)tvwTree.ActiveNode.Parent.Parent.Parent.Tag);
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fObject = null;
                FTcpMessageTransfer = null;
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
                if (fObject.fObjectType == FObjectType.TcpMessages)
                {
                    findWhat = ((FTcpMessages)fObject).name;
                }
                else if (fObject.fObjectType == FObjectType.TcpMessage)
                {
                    findWhat = ((FTcpMessage)fObject).name;
                }
                else if (fObject.fObjectType == FObjectType.TcpItem)
                {
                    findWhat = ((FTcpItem)fObject).name;
                }
                else
                {
                    return;
                }

                // --

                dialog = new FReplaceNameDialog(
                    m_fTcmCore,
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
                if (fObject.fObjectType == FObjectType.TcpMessages)
                {
                    foreach (FIObject o in ((FTcpMessages)fObject).fChildTcpMessageCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FTcpMessages)fObject).name = ((FTcpMessages)fObject).name.Replace(findWhat, replaceWith);
                    ((FTcpMessages)fObject).command = ((FTcpMessages)fObject).command.Replace(findWhat, replaceWith);
                    ((FTcpMessages)fObject).description = ((FTcpMessages)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.TcpMessage)
                {
                    foreach (FIObject o in ((FTcpMessage)fObject).fChildTcpItemCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FTcpMessage)fObject).name = ((FTcpMessage)fObject).name.Replace(findWhat, replaceWith);
                    ((FTcpMessage)fObject).command = ((FTcpMessage)fObject).command.Replace(findWhat, replaceWith);
                    ((FTcpMessage)fObject).description = ((FTcpMessage)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.TcpItem)
                {
                    foreach (FIObject o in ((FTcpItem)fObject).fChildTcpItemCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FTcpItem)fObject).name = ((FTcpItem)fObject).name.Replace(findWhat, replaceWith);
                    ((FTcpItem)fObject).description = ((FTcpItem)fObject).description.Replace(findWhat, replaceWith);
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

                if (fObject.fObjectType == FObjectType.TcpDevice)
                {
                    ((FTcpDevice)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.TcpSession)
                {
                    ((FTcpSession)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessageList)
                {
                    ((FTcpMessageList)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessages)
                {
                    ((FTcpMessages)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessage)
                {
                    ((FTcpMessage)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.TcpItem)
                {
                    ((FTcpItem)fObject).cut();
                }

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

                if (fObject.fObjectType == FObjectType.TcpDevice)
                {
                    ((FTcpDevice)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.TcpSession)
                {
                    ((FTcpSession)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessageList)
                {
                    ((FTcpMessageList)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessages)
                {
                    ((FTcpMessages)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessage)
                {
                    ((FTcpMessage)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.TcpItem)
                {
                    ((FTcpItem)fObject).copy();
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

        private void procMenuPasteSibling(
            )
        {
            UltraTreeNode tNodeRef = null;
            UltraTreeNode tNodeNew = null;
            FIObject fRefObject = null;
            FIObject fNewObject = null;
            string uniqueId = string.Empty;

            try
            {
                tNodeRef = tvwTree.ActiveNode;
                fRefObject = (FIObject)tNodeRef.Tag;

                // --

                tvwTree.beginUpdate();

                // --

                if (fRefObject.fObjectType == FObjectType.TcpDevice)
                {
                    fNewObject = ((FTcpDevice)fRefObject).pasteSibling();
                    uniqueId = fNewObject.uniqueIdToString;
                }
                else if (fRefObject.fObjectType == FObjectType.TcpSession)
                {
                    fNewObject = ((FTcpSession)fRefObject).pasteSibling();
                    uniqueId = fNewObject.uniqueIdToString;
                }
                else if (fRefObject.fObjectType == FObjectType.TcpMessageList)
                {
                    fNewObject = ((FTcpMessageList)fRefObject).pasteSibling();
                    uniqueId = createTreeId(getTcpSessionId(tNodeRef.Key), fNewObject.uniqueIdToString);
                }
                else if (fRefObject.fObjectType == FObjectType.TcpMessages)
                {
                    fNewObject = ((FTcpMessages)fRefObject).pasteSibling();
                    uniqueId = createTreeId(getTcpSessionId(tNodeRef.Key), fNewObject.uniqueIdToString);
                }
                else if (fRefObject.fObjectType == FObjectType.TcpMessage)
                {
                    // ***
                    // 사용하지 않음
                    // ***
                }
                else if (fRefObject.fObjectType == FObjectType.TcpItem)
                {
                    fNewObject = ((FTcpItem)fRefObject).pasteSibling();
                    uniqueId = createTreeId(getTcpSessionId(tNodeRef.Key), fNewObject.uniqueIdToString);
                }

                tNodeNew = new UltraTreeNode(uniqueId);
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
            UltraTreeNode tNodeNewChild = null;
            FIObject fParent = null;
            FIObject fNewChild = null;
            string uniqueId = string.Empty;

            try
            {
                tNodeParent = tvwTree.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                tvwTree.beginUpdate();

                // --

                if (fParent.fObjectType == FObjectType.TcpDriver)
                {
                    fNewChild = ((FTcpDriver)fParent).pasteChildTcpDevice();
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.TcpDevice)
                {
                    fNewChild = ((FTcpDevice)fParent).pasteChild();
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.TcpSession)
                {
                    fNewChild = ((FTcpSession)fParent).fLibrary.pasteChild();
                    uniqueId = createTreeId(tNodeParent.Key, fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.TcpMessageList)
                {
                    fNewChild = ((FTcpMessageList)fParent).pasteChild();
                    uniqueId = createTreeId(getTcpSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.TcpMessages)
                {
                    // ***
                    // 사용하지 않음
                    // ***
                }
                else if (fParent.fObjectType == FObjectType.TcpMessage)
                {
                    fNewChild = ((FTcpMessage)fParent).pasteChild();
                    uniqueId = createTreeId(getTcpSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.TcpItem)
                {
                    fNewChild = ((FTcpItem)fParent).pasteChild();
                    uniqueId = createTreeId(getTcpSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }

                tNodeNewChild = new UltraTreeNode(uniqueId);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);

                // --

                loadTreeOfChildObject(tNodeNewChild);
                tNodeParent.Nodes.Add(tNodeNewChild);
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeNewChild;

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

        private void procMenuPastePrimaryTcpMessage(
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeNewChild = null;
            FIObject fParent = null;
            FIObject fNewChild = null;
            string uniqueId = string.Empty;

            try
            {                
                tNodeParent = tvwTree.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;
               
                // --

                tvwTree.beginUpdate();

                // --              

                if (fParent.fObjectType == FObjectType.TcpMessages)
                {
                    fNewChild = ((FTcpMessages)fParent).pastePrimaryTcpMessage();
                    uniqueId = createTreeId(getTcpSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }

                // --

                tNodeNewChild = new UltraTreeNode(uniqueId);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);
                
                // --
                
                loadTreeOfChildObject(tNodeNewChild);
                tNodeParent.Nodes.Insert(0, tNodeNewChild);
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeNewChild;

                // --

                tvwTree.endUpdate();
            }
            catch (Exception Ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(Ex);
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

        private void procMenuPasteSecondaryTcpMessage(
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeNewChild = null;
            FIObject fParent = null;
            FIObject fNewChild = null;
            string uniqueId = string.Empty;

            try
            {
                tNodeParent = tvwTree.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                tvwTree.beginUpdate();

                // --              

                if (fParent.fObjectType == FObjectType.TcpMessages)
                {
                    fNewChild = ((FTcpMessages)fParent).pasteSecondaryTcpMessage();
                    uniqueId = createTreeId(getTcpSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }

                // --

                tNodeNewChild = new UltraTreeNode(uniqueId);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);
                
                // --

                loadTreeOfChildObject(tNodeNewChild);
                tNodeParent.Nodes.Add(tNodeNewChild);
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeNewChild;

                // --

                tvwTree.endUpdate();
            }
            catch (Exception Ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(Ex);
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

        private void procMenuSearch(
            string searchWord
            )
        {
            UltraTreeNode tNode = null;
            FIObject fBase = null;
            FTcpSession fTsn = null;
            FIObject fResult = null;            
            string uniqueId = null;
            string[] uniqueIds = null;

            try
            {
                tNode = tvwTree.ActiveNode;
                fBase = (FIObject)tNode.Tag;

                // --              

                uniqueIds = tNode.Key.Split('-');
                if (uniqueIds.Length == 2)
                {
                    fTsn = (FTcpSession)tvwTree.GetNodeByKey(uniqueIds[0]).Tag;
                }     

                // --

                fResult = m_fTcmCore.fTcmFileInfo.fTcpDriver.searchTcpDeviceSeries(fBase, ref fTsn, searchWord);
                if (fResult == null)
                {
                    FMessageBox.showInformation("Search", m_fTcmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
                    return;
                }

                // --

                tvwTree.beginUpdate();

                // --

                expandTreeForSearch(fTsn, fResult);
                // --
                if (fTsn == null)
                {
                    uniqueId = fResult.uniqueIdToString;
                }
                else
                {
                    uniqueId = createTreeId(fTsn.uniqueIdToString, fResult.uniqueIdToString);
                }
                tNode = tvwTree.GetNodeByKey(uniqueId);
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
                fTsn = null;
                fResult = null;
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

                // ***
                // TCP Device와 TCP Session 검색에만 사용된다.
                // *** 
                expandTreeForSearch(null, fObject);
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
            FIObject fTsn,
            FIObject fObject
            )
        {
            FIObject fParent = null;
            UltraTreeNode tNodeParent = null;
            string parentUid = string.Empty;

            try
            {
                if (fObject.fObjectType == FObjectType.TcpDriver)
                {
                    return;
                }
               
                // --

                fParent = m_fTcmCore.fTcmFileInfo.fTcpDriver.getParentOfObject(fObject);

                // --             

                if (
                    fParent.fObjectType == FObjectType.TcpDriver ||
                    fParent.fObjectType == FObjectType.TcpDevice ||
                    fParent.fObjectType == FObjectType.TcpSession
                    )
                {
                    parentUid = fParent.uniqueIdToString;
                }
                else
                {
                    parentUid = string.Format("{0}-{1}", fTsn.uniqueIdToString, fParent.uniqueIdToString);
                }

                // --

                tNodeParent = tvwTree.GetNodeByKey(parentUid);
                if (tNodeParent == null || !tNodeParent.Expanded)
                {
                    expandTreeForSearch(fTsn, fParent);
                }

                // --

                if (tNodeParent == null)
                {
                    tNodeParent = tvwTree.GetNodeByKey(parentUid);
                }

                if (tNodeParent != null)
                {
                    tNodeParent.Expanded = true;
                }
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FTcpDeviceModeler Form Event Handler

        private void FTcpDeviceModeler_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designTreeOfTcpDeviceModeler();

                // --

                tvwTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuTdmPopupMenu]);

                // --

                m_fEventHandler = new FEventHandler(m_fTcmCore.fTcmFileInfo.fTcpDriver, tvwTree);
                // --
                m_fEventHandler.ObjectModifyCompleted += new FObjectModifyCompletedEventHandler(m_fEventHandler_ObjectModifyCompleted);                
                m_fEventHandler.ObjectInsertBeforeCompleted += new FObjectInsertBeforeCompletedEventHandler(m_fEventHandler_ObjectInsertBeforeCompleted);
                m_fEventHandler.ObjectInsertAfterCompleted += new FObjectInsertAfterCompletedEventHandler(m_fEventHandler_ObjectInsertAfterCompleted);
                m_fEventHandler.ObjectAppendCompleted += new FObjectAppendCompletedEventHandler(m_fEventHandler_ObjectAppendCompleted);
                m_fEventHandler.ObjectRemoveCompleted += new FObjectRemoveCompletedEventHandler(m_fEventHandler_ObjectRemoveCompleted);
                m_fEventHandler.ObjectMoveUpCompleted += new FObjectMoveUpCompletedEventHandler(m_fEventHandler_ObjectMoveUpCompleted);
                m_fEventHandler.ObjectMoveDownCompleted += new FObjectMoveDownCompletedEventHandler(m_fEventHandler_ObjectMoveDownCompleted);
                m_fEventHandler.ObjectMoveToCompleted += new FObjectMoveToCompletedEventHandler(m_fEventHandler_ObjectMoveToCompleted);
                m_fEventHandler.TcpDeviceStateChanged += new FTcpDeviceStateChangedEventHandler(m_fEventHandler_TcpDeviceStateChanged);                

                // --

                pgdProp.DynPropNoticeRaised += new FDynPropNoticeRaisedEventHandler(pgdProp_DynPropNoticeRaised);

                // --

                m_fTcmCore.fOption.fChildFormList.add(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        private void FTcpDeviceModeler_Shown(
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FTcpDeviceModeler_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                if (m_fEventHandler != null)
                {
                    m_fTcmCore.fTcmFileInfo.fTcpDriver.waitEventHandlingCompleted();

                    // --

                    m_fEventHandler.Dispose();                    
                    // --
                    m_fEventHandler.ObjectModifyCompleted -= new FObjectModifyCompletedEventHandler(m_fEventHandler_ObjectModifyCompleted);
                    m_fEventHandler.ObjectInsertBeforeCompleted -= new FObjectInsertBeforeCompletedEventHandler(m_fEventHandler_ObjectInsertBeforeCompleted);                    
                    m_fEventHandler.ObjectInsertAfterCompleted -= new FObjectInsertAfterCompletedEventHandler(m_fEventHandler_ObjectInsertAfterCompleted);
                    m_fEventHandler.ObjectAppendCompleted -= new FObjectAppendCompletedEventHandler(m_fEventHandler_ObjectAppendCompleted);
                    m_fEventHandler.ObjectRemoveCompleted -= new FObjectRemoveCompletedEventHandler(m_fEventHandler_ObjectRemoveCompleted);
                    m_fEventHandler.ObjectMoveUpCompleted -= new FObjectMoveUpCompletedEventHandler(m_fEventHandler_ObjectMoveUpCompleted);
                    m_fEventHandler.ObjectMoveDownCompleted -= new FObjectMoveDownCompletedEventHandler(m_fEventHandler_ObjectMoveDownCompleted);
                    m_fEventHandler.ObjectMoveToCompleted -= new FObjectMoveToCompletedEventHandler(m_fEventHandler_ObjectMoveToCompleted);
                    m_fEventHandler.TcpDeviceStateChanged -= new FTcpDeviceStateChangedEventHandler(m_fEventHandler_TcpDeviceStateChanged);                    
                    // --                    
                    m_fEventHandler = null;
                }

                // --

                pgdProp.DynPropNoticeRaised -= new FDynPropNoticeRaisedEventHandler(pgdProp_DynPropNoticeRaised);

                // --

                m_fTcmCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                    e.fObject.fObjectType == FObjectType.TcpDevice ||
                    e.fObject.fObjectType == FObjectType.TcpSession
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.TcpMessageList ||
                    e.fObject.fObjectType == FObjectType.TcpMessages ||
                    e.fObject.fObjectType == FObjectType.TcpMessage ||
                    e.fObject.fObjectType == FObjectType.TcpItem
                    )
                {
                    addTreeOfObject2(e.fParentObject, e.fObject);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                    e.fObject.fObjectType == FObjectType.TcpDevice ||
                    e.fObject.fObjectType == FObjectType.TcpSession
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.TcpMessageList ||
                    e.fObject.fObjectType == FObjectType.TcpMessages ||
                    e.fObject.fObjectType == FObjectType.TcpMessage ||
                    e.fObject.fObjectType == FObjectType.TcpItem
                    )
                {
                    addTreeOfObject2(e.fParentObject, e.fObject);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                    e.fObject.fObjectType == FObjectType.TcpDevice ||
                    e.fObject.fObjectType == FObjectType.TcpSession
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.TcpMessageList ||
                    e.fObject.fObjectType == FObjectType.TcpMessages ||
                    e.fObject.fObjectType == FObjectType.TcpMessage ||
                    e.fObject.fObjectType == FObjectType.TcpItem
                    )
                {
                    addTreeOfObject2(e.fParentObject, e.fObject);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                    e.fObject.fObjectType == FObjectType.TcpDevice ||
                    e.fObject.fObjectType == FObjectType.TcpSession
                    )
                {
                    removeTreeOfObject(e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.TcpMessageList ||
                    e.fObject.fObjectType == FObjectType.TcpMessages ||
                    e.fObject.fObjectType == FObjectType.TcpMessage ||
                    e.fObject.fObjectType == FObjectType.TcpItem
                    )
                {
                    removeTreeOfObject2(e.fObject);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                    e.fObject.fObjectType == FObjectType.TcpDevice ||
                    e.fObject.fObjectType == FObjectType.TcpSession
                    )
                {
                    moveUpTreeOfObject(e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.TcpMessageList ||
                    e.fObject.fObjectType == FObjectType.TcpMessages ||
                    e.fObject.fObjectType == FObjectType.TcpMessage ||
                    e.fObject.fObjectType == FObjectType.TcpItem
                    )
                {

                    moveUpTreeOfObject2(e.fObject);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                    e.fObject.fObjectType == FObjectType.TcpDevice ||
                    e.fObject.fObjectType == FObjectType.TcpSession 
                    )
                {
                    moveDownTreeOfObject(e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.TcpMessageList ||
                    e.fObject.fObjectType == FObjectType.TcpMessages ||
                    e.fObject.fObjectType == FObjectType.TcpMessage ||
                    e.fObject.fObjectType == FObjectType.TcpItem
                    )
                {
                    moveDownTreeOfObject2(e.fObject);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                    e.fObject.fObjectType == FObjectType.TcpDevice ||
                    e.fObject.fObjectType == FObjectType.TcpSession
                    )
                {
                    moveToTreeOfObject(e.fObject, e.fRefObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.TcpMessageList ||
                    e.fObject.fObjectType == FObjectType.TcpMessages ||
                    e.fObject.fObjectType == FObjectType.TcpMessage ||
                    e.fObject.fObjectType == FObjectType.TcpItem
                    )
                {
                    moveToTreeOfObject2(e.fObject, e.fRefObject);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                    e.fObject.fObjectType == FObjectType.TcpDriver ||
                    e.fObject.fObjectType == FObjectType.TcpDevice ||
                    e.fObject.fObjectType == FObjectType.TcpSession
                    )
                {
                    refreshObject(e.fObject);
                }
                else if (e.fObject.fObjectType == FObjectType.TcpLibrary)
                {
                    foreach (FIObject fObject in ((FTcpLibrary)e.fObject).fReferenceObjectCollection)
                    {
                        if (fObject.fObjectType == FObjectType.TcpSession)
                        {
                            refreshObject(fObject);
                        }
                    }
                }
                else if (
                    e.fObject.fObjectType == FObjectType.TcpMessageList ||
                    e.fObject.fObjectType == FObjectType.TcpMessages ||
                    e.fObject.fObjectType == FObjectType.TcpMessage ||
                    e.fObject.fObjectType == FObjectType.TcpItem
                    )
                {
                    refreshObject2(e.fObject);
                }
                /*
                else if (e.fObject.fObjectType == FObjectType.DataSet)
                {
                    foreach (FIObject fObject in ((FDataSet)e.fObject).fReferenceObjectCollection)
                    {
                        if (fObject.fObjectType == FObjectType.TcpMessage)
                        {
                            refreshObject2(fObject);
                        }
                    }
                }
                */
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_TcpDeviceStateChanged(
            object sender, 
            FTcpDeviceStateChangedEventArgs e
            )
        {
            UltraTreeNode tNode = null;

            try
            {
                if (e.fTcpDeviceStateChangedLog.fResultCode != FResultCode.Success)
                {
                    return;
                }

                // --

                tNode = tvwTree.GetNodeByKey(e.fTcpDeviceStateChangedLog.uniqueIdToString);
                if (
                    e.fTcpDeviceStateChangedLog.fState == FDeviceState.Opened ||
                    e.fTcpDeviceStateChangedLog.fState == FDeviceState.Closed
                    )
                {                    
                    if (tNode != null && tNode.IsActive)
                    {
                        ((FPropTdv)pgdProp.selectedObject).setChangedState(e.fTcpDeviceStateChangedLog.fState);
                        controlMenu();
                    }
                }

                // --

                if (tvwTree.ActiveNode != null && ((FIObject)tvwTree.ActiveNode.Tag).fObjectType == FObjectType.TcpMessage)
                {
                    if (
                        ((FIObject)tvwTree.ActiveNode.Tag).fObjectType == FObjectType.TcpMessages ||
                        ((FIObject)tvwTree.ActiveNode.Tag).fObjectType == FObjectType.TcpMessage
                        )
                    {
                        controlMenu();
                    }                    
                }

                // --

                FCommon.refreshTreeNodeOfObject((FIObject)tNode.Tag, tvwTree, tNode);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                if (fObject.fObjectType == FObjectType.TcpDriver)
                {
                    pgdProp.selectedObject = new FPropTcd(m_fTcmCore, pgdProp, (FTcpDriver)fObject);
                }
                else if (fObject.fObjectType == FObjectType.TcpDevice)
                {
                    pgdProp.selectedObject = new FPropTdv(m_fTcmCore, pgdProp, (FTcpDevice)fObject);
                }
                else if (fObject.fObjectType == FObjectType.TcpSession)
                {
                    pgdProp.selectedObject = new FPropTsn(m_fTcmCore, pgdProp, (FTcpSession)fObject);
                }
                else if (fObject.fObjectType == FObjectType.TcpMessageList)
                {
                    pgdProp.selectedObject = new FPropTml(m_fTcmCore, pgdProp, (FTcpMessageList)fObject);
                }
                else if (fObject.fObjectType == FObjectType.TcpMessages)
                {
                    pgdProp.selectedObject = new FPropTms(m_fTcmCore, pgdProp, (FTcpMessages)fObject);
                }
                else if (fObject.fObjectType == FObjectType.TcpMessage)
                {
                    pgdProp.selectedObject = new FPropTmg(m_fTcmCore, pgdProp, (FTcpMessage)fObject);
                }
                else if (fObject.fObjectType == FObjectType.TcpItem)
                {
                    if (((FTcpItem)fObject).removed)
                    {
                        return;
                    }
                    pgdProp.selectedObject = new FPropTit(m_fTcmCore, pgdProp, (FTcpItem)fObject);
                }

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
                if (fObject.fObjectType == FObjectType.TcpDevice)
                {
                    pgdProp.selectedObject = new FPropTdv(m_fTcmCore, pgdProp, (FTcpDevice)fObject);
                }
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
                    if (mnuMenu.Tools[FMenuKey.MenuHlmRemove].SharedProps.Enabled)
                    {
                        procMenuRemoveObject();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.X)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHlmCut].SharedProps.Enabled)
                    {
                        procMenuCut();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.C)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHlmCopy].SharedProps.Enabled)
                    {
                        procMenuCopy();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    fObject = (FIObject)this.tvwTree.ActiveNode.Tag;

                    if (fObject.fObjectType == FObjectType.TcpMessages)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuTlmPastePrimaryTcpMessage].SharedProps.Enabled)
                        {
                            procMenuPastePrimaryTcpMessage();
                        }
                        else if (mnuMenu.Tools[FMenuKey.MenuHlmPasteSibling].SharedProps.Enabled)
                        {
                            procMenuPasteSibling();
                        }
                        else if (mnuMenu.Tools[FMenuKey.MenuTlmPasteSecondaryTcpMessage].SharedProps.Enabled)
                        {
                            procMenuPasteSecondaryTcpMessage();
                        }
                    }
                    else
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuHlmPasteSibling].SharedProps.Enabled)
                        {
                            procMenuPasteSibling();
                        }
                    }
                }
                else if (e.Control && e.KeyCode == Keys.B)
                {
                    fObject = (FIObject)this.tvwTree.ActiveNode.Tag;

                    if (fObject.fObjectType == FObjectType.TcpMessages)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuTlmPasteSecondaryTcpMessage].SharedProps.Enabled)
                        {
                            procMenuPasteSecondaryTcpMessage();
                        }
                    }
                    else
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuHlmPasteChild].SharedProps.Enabled)
                        {
                            procMenuPasteChild();
                        }
                    }
                }
                else if (e.Control && e.KeyCode == Keys.U)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHlmMoveUp].SharedProps.Enabled)
                    {
                        procMenuMoveUpObject(FMenuKey.MenuHlmMoveUp);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.D)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHlmMoveDown].SharedProps.Enabled)
                    {
                        procMenuMoveDownObject(FMenuKey.MenuHlmMoveDown);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.E)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHlmExpand].SharedProps.Enabled)
                    {
                        procMenuExpand();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.L)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHlmCollapse].SharedProps.Enabled)
                    {
                        procMenuCollapse();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.R)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuTdmRelation].SharedProps.Enabled)
                    {
                        procMenuRelation();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.S)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuTdmSendTcpMessage].SharedProps.Enabled)
                    {
                        procMenuSendTcpMessage();
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                if (
                    fObject.fObjectType != FObjectType.TcpDriver &&
                    fObject.fObjectType != FObjectType.TcpDevice &&
                    fObject.fObjectType != FObjectType.TcpSession
                    )
                {
                    fDragDropData.sessionUniqueId = getTcpSessionId(tNode.Key);
                }
                // --
                tvwTree.DoDragDrop(new DataObject(fDragDropData), DragDropEffects.All);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
            string tsnUniqueId = string.Empty;
            FFormat fFormat = FFormat.Unknown;

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

                    if (fRefObject.fObjectType == FObjectType.TcpDriver)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpDevice)
                        {
                            #region TcpDevice

                            if (((FTcpDriver)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FTcpDriver)fRefObject).fChildTcpDeviceCollection.count;
                                fRefObject = ((FTcpDriver)fRefObject).fChildTcpDeviceCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.TcpDevice)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpDevice)
                        {
                            #region TcpDevice

                            if (((FTcpDevice)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FTcpDevice)fRefObject).fNextSibling == null || !((FTcpDevice)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.TcpSession)
                        {
                            #region TcpSession

                            if (((FTcpDevice)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FTcpDevice)fRefObject).fChildTcpSessionCollection.count;
                                if (cnt == 0)
                                {
                                    if (!((FTcpSession)fDragDropData.fObject).locked)
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                                else
                                {
                                    fRefObject = ((FTcpDevice)fRefObject).fChildTcpSessionCollection[cnt - 1];
                                    if (!fRefObject.Equals(fDragDropData.fObject))
                                    {
                                        if (((FTcpSession)fDragDropData.fObject).locked)
                                        {
                                            if (((FTcpSession)fRefObject).fParent == ((FTcpSession)fDragDropData.fObject).fParent)
                                            {
                                                e.Effect = DragDropEffects.Move;
                                                return;
                                            }
                                        }
                                        else
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
                    else if (fRefObject.fObjectType == FObjectType.TcpSession)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpSession)
                        {
                            #region TcpSession

                            if (((FTcpSession)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FTcpSession)fRefObject).fNextSibling == null || !((FTcpSession)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    if (((FTcpSession)fDragDropData.fObject).locked)
                                    {
                                        if (((FTcpSession)fRefObject).fParent == ((FTcpSession)fDragDropData.fObject).fParent)
                                        {
                                            e.Effect = DragDropEffects.Move;
                                            return;
                                        }
                                    }
                                    else
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.TcpLibrary)
                        {
                            #region TcpLibrary

                            if (
                                !((FTcpSession)fRefObject).locked &&
                                ((FTcpSession)fRefObject).equalsModelingFile(fDragDropData.fObject)
                                )
                            {
                                if (((FTcpSession)fRefObject).hasLibrary)
                                {
                                    if (!((FTcpSession)fRefObject).fLibrary.Equals((FTcpLibrary)fDragDropData.fObject))
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.TcpMessageList)
                        {
                            #region TcpMessageList

                            if (((FTcpSession)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (fRefObject.uniqueIdToString == fDragDropData.sessionUniqueId)
                                {
                                    cnt = ((FTcpSession)fRefObject).fLibrary.fChildTcpMessageListCollection.count;
                                    fRefObject = ((FTcpSession)fRefObject).fLibrary.fChildTcpMessageListCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.TcpMessageList)
                    {
                        tsnUniqueId = getTcpSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpMessageList)
                        {
                            #region TcpMessageList

                            if (((FTcpMessageList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (tsnUniqueId == fDragDropData.sessionUniqueId)
                                {
                                    if (
                                        !fRefObject.Equals(fDragDropData.fObject) &&
                                        (((FTcpMessageList)fRefObject).fNextSibling == null || !((FTcpMessageList)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.TcpMessages)
                        {
                            #region TcpMessages

                            if (((FTcpMessageList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                // ***
                                // TCP Messages는 다른 TCP Library로 Move 할 수 없다.
                                // ***
                                if (
                                    fDragDropData.sessionUniqueId == tsnUniqueId &&
                                    ((FTcpMessageList)fRefObject).fAncestorTcpLibrary.Equals(((FTcpMessages)fDragDropData.fObject).fAncestorTcpLibrary)
                                    )
                                {
                                    cnt = ((FTcpMessageList)fRefObject).fChildTcpMessagesCollection.count;
                                    if (cnt == 0)
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                    else
                                    {
                                        fRefObject = ((FTcpMessageList)fRefObject).fChildTcpMessagesCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.TcpMessages)
                    {
                        tsnUniqueId = getTcpSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpMessages)
                        {
                            #region TcpMessages

                            if (((FTcpMessages)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                // ***
                                // TCP Messages는 다른 TCP Library로 Move 할 수 없다.
                                // ***
                                if (
                                    fDragDropData.sessionUniqueId == tsnUniqueId &&
                                    ((FTcpMessages)fRefObject).fAncestorTcpLibrary.Equals(((FTcpMessages)fDragDropData.fObject).fAncestorTcpLibrary)
                                    )
                                {
                                    if (
                                        !fRefObject.Equals(fDragDropData.fObject) &&
                                        (((FTcpMessages)fRefObject).fNextSibling == null || !((FTcpMessages)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.TcpMessage)
                        {
                            #region TcpMessage

                            if (!((FTcpMessages)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FTcpMessage)fDragDropData.fObject).isPrimary)
                                {
                                    if (((FTcpMessages)fRefObject).canAppendChildPrimaryTcpMessage)
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                                else
                                {
                                    if (((FTcpMessages)fRefObject).canAppendChildSecondaryTcpMessage)
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                            }

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.TcpMessage)
                    {
                        tsnUniqueId = getTcpSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpItem)
                        {
                            #region TcpItem

                            if (((FTcpMessage)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FTcpMessage)fRefObject).Equals(((FTcpItem)fDragDropData.fObject).fAncestorTcpMessage) &&
                                    !((FTcpMessage)fRefObject).fChildTcpItemCollection[((FTcpMessage)fRefObject).fChildTcpItemCollection.count - 1].Equals(fDragDropData.fObject) &&
                                    fDragDropData.sessionUniqueId == tsnUniqueId
                                    )
                                {
                                    if (((FTcpMessage)fRefObject).hasVariableChild)
                                    {
                                        if (((FTcpItem)fDragDropData.fObject).fPattern == FPattern.Variable)
                                        {
                                            if (
                                                ((FTcpMessage)fRefObject).Equals(((FTcpItem)fDragDropData.fObject).fParent) &&
                                                (((FTcpItem)fDragDropData.fObject).fPreviousSibling == null || ((FTcpItem)fDragDropData.fObject).fPreviousSibling.fPattern == FPattern.Fixed) &&
                                                (((FTcpItem)fDragDropData.fObject).fNextSibling == null || ((FTcpItem)fDragDropData.fObject).fNextSibling.fPattern == FPattern.Fixed)
                                                )
                                            {
                                                e.Effect = DragDropEffects.Move;
                                                return;
                                            }
                                            else if (((FTcpMessage)fRefObject).fChildTcpItemCollection[((FTcpMessage)fRefObject).fChildTcpItemCollection.count - 1].fPattern == FPattern.Variable)
                                            {
                                                e.Effect = DragDropEffects.Move;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            e.Effect = DragDropEffects.Move;
                                            return;
                                        }
                                    }
                                    else
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataSet)
                        {
                            #region DataSet

                            if (((FTcpMessage)fRefObject).equalsModelingFile(fDragDropData.fObject))
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
                    else if (fRefObject.fObjectType == FObjectType.TcpItem)
                    {
                        tsnUniqueId = getTcpSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpItem)
                        {
                            #region TcpItem

                            if (((FTcpItem)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    fDragDropData.sessionUniqueId == tsnUniqueId &&
                                    !((FTcpItem)fDragDropData.fObject).containsObject(fRefObject) &&                                    
                                    ((FTcpItem)fRefObject).fAncestorTcpMessage.Equals(((FTcpItem)fDragDropData.fObject).fAncestorTcpMessage) &&
                                    (((FTcpItem)fRefObject).fNextSibling == null || !(((FTcpItem)fRefObject).fNextSibling.Equals((FTcpItem)fDragDropData.fObject)))
                                    )
                                {
                                    if (
                                        (((FTcpItem)fRefObject).fParent.fObjectType == FObjectType.TcpMessage && ((FTcpMessage)((FTcpItem)fRefObject).fParent).hasVariableChild) ||
                                        (((FTcpItem)fRefObject).fParent.fObjectType == FObjectType.TcpItem && ((FTcpItem)((FTcpItem)fRefObject).fParent).hasVariableChild)
                                        )
                                    {
                                        if (((FTcpItem)fDragDropData.fObject).fPattern == FPattern.Variable)
                                        {
                                            if (
                                                ((FTcpItem)fDragDropData.fObject).fParent.Equals(((FTcpItem)fRefObject).fParent) &&
                                                (((FTcpItem)fDragDropData.fObject).fPreviousSibling == null || ((FTcpItem)fDragDropData.fObject).fPreviousSibling.fPattern == FPattern.Fixed) &&
                                                (((FTcpItem)fDragDropData.fObject).fNextSibling == null || ((FTcpItem)fDragDropData.fObject).fNextSibling.fPattern == FPattern.Fixed)
                                                )
                                            {
                                                e.Effect = DragDropEffects.Move;
                                                return;
                                            }
                                            else if (
                                                ((FTcpItem)fRefObject).fPattern == FPattern.Variable ||
                                                (((FTcpItem)fRefObject).fNextSibling != null && ((FTcpItem)fRefObject).fNextSibling.fPattern == FPattern.Variable)
                                                )
                                            {
                                                e.Effect = DragDropEffects.Move;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            if (
                                                ((FTcpItem)fRefObject).fPattern == FPattern.Fixed ||
                                                ((FTcpItem)fRefObject).fNextSibling == null ||
                                                ((FTcpItem)fRefObject).fNextSibling.fPattern == FPattern.Fixed
                                                )
                                            {
                                                e.Effect = DragDropEffects.Move;
                                                return;
                                            }
                                        }
                                    }
                                    else
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataConversionSet)
                        {
                            #region DataConversionSet

                            if (((FTcpItem)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                fFormat = ((FTcpItem)fRefObject).fFormat;
                                // --
                                if (
                                    fFormat != FFormat.List &&
                                    fFormat != FFormat.AsciiList &&
                                    fFormat != FFormat.Raw &&
                                    fFormat != FFormat.Unknown
                                    )
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Data)
                        {
                            #region Data

                            if (((FTcpItem)fRefObject).equalsModelingFile(fDragDropData.fObject))
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

                    if (fRefObject.fObjectType == FObjectType.TcpMessageList)
                    {
                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog
                            )
                        {
                            #region TcpMessageLog

                            e.Effect = DragDropEffects.Copy;
                            return;

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.TcpMessages)
                    {
                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog
                            )
                        {
                            #region TcpMessageLog

                            e.Effect = DragDropEffects.Copy;
                            return;

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.TcpMessage)
                    {
                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpItemLog)
                        {
                            #region TcpItemLog

                            e.Effect = DragDropEffects.Copy;
                            return;

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.TcpItem)
                    {
                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpItemLog)
                        {
                            #region TcpItemLog

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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
            FTcpMessages fTms = null;
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

                    if (fRefObject.fObjectType == FObjectType.TcpDriver)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpDevice)
                        {
                            #region TcpDevice

                            if (e.Effect == DragDropEffects.Move)
                            {
                                cnt = ((FTcpDriver)fRefObject).fChildTcpDeviceCollection.count;
                                fRefObject = ((FTcpDriver)fRefObject).fChildTcpDeviceCollection[cnt - 1];
                                ((FTcpDevice)fDragDropData.fObject).moveTo((FTcpDevice)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpDevice)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FTcpDriver)fRefObject).pasteChildTcpDevice();
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
                    else if (fRefObject.fObjectType == FObjectType.TcpDevice)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpDevice)
                        {
                            #region TcpDevice

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FTcpDevice)fDragDropData.fObject).moveTo((FTcpDevice)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpDevice)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FTcpDevice)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.TcpSession)
                        {
                            #region TcpSession

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FTcpSession)fDragDropData.fObject).moveTo((FTcpDevice)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpSession)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FTcpDevice)fRefObject).pasteChild();
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
                    else if (fRefObject.fObjectType == FObjectType.TcpSession)
                    {
                        fDragDropData.refSessionUniqueId = tRefNode.Key;

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpSession)
                        {
                            #region TcpSession

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FTcpSession)fDragDropData.fObject).moveTo((FTcpSession)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpSession)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FTcpSession)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.TcpLibrary)
                        {
                            #region TcpLibrary

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpSession)fRefObject).setLibrary((FTcpLibrary)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.TcpMessageList)
                        {
                            #region TcpMessageList

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FTcpMessageList)fDragDropData.fObject).moveTo(((FTcpSession)fRefObject).fLibrary);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpMessageList)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FTcpSession)fRefObject).fLibrary.pasteChild();
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
                    else if (fRefObject.fObjectType == FObjectType.TcpMessageList)
                    {
                        fDragDropData.refSessionUniqueId = getTcpSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpMessageList)
                        {
                            #region TcpMessageList

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FTcpMessageList)fDragDropData.fObject).moveTo((FTcpMessageList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpMessageList)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FTcpMessageList)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.TcpMessages)
                        {
                            #region TcpMessages

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FTcpMessages)fDragDropData.fObject).moveTo((FTcpMessageList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpMessages)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FTcpMessageList)fRefObject).pasteChild();
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
                    else if (fRefObject.fObjectType == FObjectType.TcpMessages)
                    {
                        fDragDropData.refSessionUniqueId = getTcpSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpMessages)
                        {
                            #region TcpMessages

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FTcpMessages)fDragDropData.fObject).moveTo((FTcpMessages)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpMessages)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FTcpMessages)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.TcpMessage)
                        {
                            #region TcpMessage

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpMessage)fDragDropData.fObject).copy();
                                // --
                                if (((FTcpMessage)fDragDropData.fObject).isPrimary)
                                {
                                    fDragDropData.fObject = ((FTcpMessages)fRefObject).pastePrimaryTcpMessage();
                                    fAction = FDragDropAction.Copy;
                                }
                                else
                                {
                                    fDragDropData.fObject = ((FTcpMessages)fRefObject).pasteSecondaryTcpMessage();
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
                    else if (fRefObject.fObjectType == FObjectType.TcpMessage)
                    {
                        fDragDropData.refSessionUniqueId = getTcpSessionId(tRefNode.Key);

                        // -- 

                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpItem)
                        {
                            #region TcpItem

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FTcpItem)fDragDropData.fObject).moveTo((FTcpMessage)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpItem)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FTcpMessage)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataSet)
                        {
                            #region DataSet

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fDataSetGenertor = new FDataSetGenerator(m_fTcmCore, (FDataSet)fDragDropData.fObject, fRefObject);
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
                    else if (fRefObject.fObjectType == FObjectType.TcpItem)
                    {
                        fDragDropData.refSessionUniqueId = getTcpSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpItem)
                        {
                            #region TcpItem

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FTcpItem)fDragDropData.fObject).moveTo((FTcpItem)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpItem)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FTcpItem)fRefObject).pasteSibling();
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
                                ((FTcpItem)fRefObject).setDataConversionSet((FDataConversionSet)fDragDropData.fObject);
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
                    else
                    {
                        return;
                    }

                    #endregion
                }
                else if (fDragDropData.fObjectLog != null)
                {
                    #region FObjectLog

                    if (fRefObject.fObjectType == FObjectType.TcpMessageList)
                    {
                        fDragDropData.refSessionUniqueId = getTcpSessionId(tRefNode.Key);

                        // --

                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog
                            )
                        {
                            #region TcpMessageLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fTms = new FTcpMessages(m_fTcmCore.fTcmFileInfo.fTcpDriver);

                                if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                                {
                                    ((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).copy();
                                    // --
                                    fTms.command = ((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).command;
                                    fTms.version = ((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).version;
                                    fTms.name = ((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).name;
                                    fTms.description = ((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).description;
                                    // --
                                    if (((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).isPrimary)
                                    {   
                                        fDragDropData.fObject = fTms.pastePrimaryTcpMessage();
                                    }
                                    else
                                    {                                        
                                        fDragDropData.fObject = fTms.pasteSecondaryTcpMessage();
                                    }
                                }
                                else
                                {
                                    ((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).copy();
                                    // --
                                    fTms.command = ((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).command;
                                    fTms.version = ((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).version;
                                    fTms.name = ((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).name;
                                    fTms.description = ((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).description;
                                    // --
                                    if (((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).isPrimary)
                                    {
                                        fDragDropData.fObject = fTms.pastePrimaryTcpMessage();
                                    }
                                    else
                                    {
                                        fDragDropData.fObject = fTms.pasteSecondaryTcpMessage();
                                    }
                                }

                                // --

                                tvwTree.beginUpdate();

                                // --

                                fTms = ((FTcpMessageList)fRefObject).appendChildTcpMessages(fTms);
                                tNode = new UltraTreeNode(createTreeId(fDragDropData.refSessionUniqueId, fTms.uniqueIdToString));
                                tNode.Tag = fTms;
                                FCommon.refreshTreeNodeOfObject(fTms, tvwTree, tNode);
                                tRefNode.Nodes.Add(tNode);

                                // --

                                fRefObject = fTms;
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
                    else if (fRefObject.fObjectType == FObjectType.TcpMessages)
                    {
                        fDragDropData.refSessionUniqueId = getTcpSessionId(tRefNode.Key);

                        // --

                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog
                            )
                        {
                            #region TcpMessageLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fTms = new FTcpMessages(m_fTcmCore.fTcmFileInfo.fTcpDriver);

                                if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                                {
                                    ((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).copy();
                                    // --
                                    fTms.command = ((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).command;
                                    fTms.version = ((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).version;
                                    fTms.name = ((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).name;
                                    fTms.description = ((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).description;
                                    // --
                                    if (((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).isPrimary)
                                    {
                                        fDragDropData.fObject = fTms.pastePrimaryTcpMessage();
                                    }
                                    else
                                    {
                                        fDragDropData.fObject = fTms.pasteSecondaryTcpMessage();
                                    }
                                }
                                else
                                {
                                    ((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).copy();
                                    // --
                                    fTms.command = ((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).command;
                                    fTms.version = ((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).version;
                                    fTms.name = ((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).name;
                                    fTms.description = ((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).description;
                                    // --
                                    if (((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).isPrimary)
                                    {
                                        fDragDropData.fObject = fTms.pastePrimaryTcpMessage();
                                    }
                                    else
                                    {
                                        fDragDropData.fObject = fTms.pasteSecondaryTcpMessage();
                                    }
                                }

                                // --

                                tvwTree.beginUpdate();

                                // --

                                fTms = ((FTcpMessages)fRefObject).fParent.insertAfterChildTcpMessages(fTms, (FTcpMessages)fRefObject);
                                tNode = new UltraTreeNode(createTreeId(fDragDropData.refSessionUniqueId, fTms.uniqueIdToString));
                                tNode.Tag = fTms;
                                FCommon.refreshTreeNodeOfObject(fTms, tvwTree, tNode);
                                tRefNode.Parent.Nodes.Insert(tRefNode.Index + 1, tNode);

                                // --

                                fRefObject = fTms;
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
                    else if (fRefObject.fObjectType == FObjectType.TcpMessage)
                    {
                        fDragDropData.refSessionUniqueId = getTcpSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpItemLog)
                        {
                            #region TcpItemLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpItemLog)fDragDropData.fObjectLog).copy();
                                fDragDropData.fObject = ((FTcpMessage)fRefObject).pasteChild();
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.TcpItem)
                    {
                        fDragDropData.refSessionUniqueId = getTcpSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpItemLog)
                        {
                            #region TcpItemLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpItemLog)fDragDropData.fObjectLog).copy();
                                fDragDropData.fObject = ((FTcpItem)fRefObject).pasteSibling();
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
                    if (
                        fDragDropData.fObject.fObjectType == FObjectType.TcpDriver ||
                        fDragDropData.fObject.fObjectType == FObjectType.TcpDevice ||
                        fDragDropData.fObject.fObjectType == FObjectType.TcpSession
                        )
                    {
                        uniqueId = fDragDropData.fObject.uniqueIdToString;
                    }
                    else
                    {
                        uniqueId = createTreeId(fDragDropData.refSessionUniqueId, fDragDropData.fObject.uniqueIdToString);
                    }
                    // --
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

                    if (
                        fRefObject.fObjectType == FObjectType.TcpDriver ||
                        fRefObject.fObjectType == FObjectType.TcpDevice ||
                        fRefObject.fObjectType == FObjectType.TcpSession
                        )
                    {
                        refUniqueId = fRefObject.uniqueIdToString;
                    }
                    else
                    {
                        refUniqueId = createTreeId(fDragDropData.refSessionUniqueId, fRefObject.uniqueIdToString);
                    }
                    // --
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
                    if (fRefObject.fObjectType == FObjectType.TcpSession)
                    {
                        changeTcpSessionLibrary((FTcpSession)fRefObject);
                        // --
                        tRefNode = tvwTree.GetNodeByKey(fRefObject.uniqueIdToString);
                        if (tRefNode != null)
                        {
                            tvwTree.SelectedNodes.Clear();
                            tvwTree.ActiveNode = tRefNode;
                        }
                    }
                    else if (
                        fRefObject.fObjectType == FObjectType.TcpMessage ||
                        fRefObject.fObjectType == FObjectType.TcpItem
                        )
                    {
                        refUniqueId = createTreeId(fDragDropData.refSessionUniqueId, fRefObject.uniqueIdToString);
                        // --
                        tRefNode = tvwTree.GetNodeByKey(refUniqueId);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fDragDropData = null;
                tRefNode = null;
                tNode = null;
                fRefObject = null;
                fTms = null;
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

                if (e.Tool.Key == FMenuKey.MenuTdmOpenTcpDevice)
                {
                    procMenuOpenTcpDevice();
                }
                else if (e.Tool.Key == FMenuKey.MenuTdmCloseTcpDevice)
                {
                    procMenuCloseTcpDevice();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuTdmSendTcpMessage)
                {
                    procMenuSendTcpMessage();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuTdmExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuTdmCollapse)
                {
                    procMenuCollapse();
                }
                else if (e.Tool.Key == FMenuKey.MenuTdmReplace)
                {
                    procMenuReplace(); 
                }
                else if (e.Tool.Key == FMenuKey.MenuTdmCut)
                {
                    procMenuCut();
                }
                else if (e.Tool.Key == FMenuKey.MenuTdmCopy)
                {
                    procMenuCopy();
                }
                else if (e.Tool.Key == FMenuKey.MenuTdmPasteSibling)
                {
                    procMenuPasteSibling();
                }
                else if (e.Tool.Key == FMenuKey.MenuTdmPasteChild)
                {
                    procMenuPasteChild();
                }
                else if (e.Tool.Key == FMenuKey.MenuTdmPastePrimaryTcpMessage)
                {
                    procMenuPastePrimaryTcpMessage();
                }
                else if (e.Tool.Key == FMenuKey.MenuTdmPasteSecondaryTcpMessage)
                {
                    procMenuPasteSecondaryTcpMessage();
                }
                else if (e.Tool.Key == FMenuKey.MenuTdmRemove)
                {
                    procMenuRemoveObject();
                }
                else if (e.Tool.Key == FMenuKey.MenuTdmMoveUp)
                {
                    procMenuMoveUpObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuTdmMoveDown)
                {
                    procMenuMoveDownObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuTdmRelation)
                {
                    procMenuRelation();
                }
                else if (e.Tool.Key == FMenuKey.MenuTdmConvertToXlg)
                {
                    procMenuXlgViewer();
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuTdmInsertBeforeTcpDevice ||
                    e.Tool.Key == FMenuKey.MenuTdmInsertBeforeTcpSession ||
                    e.Tool.Key == FMenuKey.MenuTdmInsertBeforeTcpMessageList ||
                    e.Tool.Key == FMenuKey.MenuTdmInsertBeforeTcpMessages ||
                    e.Tool.Key == FMenuKey.MenuTdmInsertBeforeTcpItem
                    )
                {
                    procMenuInsertBeforeObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuTdmInsertAfterTcpDevice ||
                    e.Tool.Key == FMenuKey.MenuTdmInsertAfterTcpSession ||
                    e.Tool.Key == FMenuKey.MenuTdmInsertAfterTcpMessageList ||
                    e.Tool.Key == FMenuKey.MenuTdmInsertAfterTcpMessages ||
                    e.Tool.Key == FMenuKey.MenuTdmInsertAfterTcpItem
                    )
                {
                    procMenuInsertAfterObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuTdmAppendTcpDevice ||
                    e.Tool.Key == FMenuKey.MenuTdmAppendTcpSession ||
                    e.Tool.Key == FMenuKey.MenuTdmAppendTcpMessageList ||
                    e.Tool.Key == FMenuKey.MenuTdmAppendTcpMessages ||
                    e.Tool.Key == FMenuKey.MenuTdmAppendPrimaryTcpMessage ||
                    e.Tool.Key == FMenuKey.MenuTdmAppendSecondaryTcpMessage ||
                    e.Tool.Key == FMenuKey.MenuTdmAppendTcpItem
                    )
                {
                    procMenuAppendObject(e.Tool.Key);
                }                              
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region pgdProp Control Event Handler

        private void pgdProp_DynPropNoticeRaised(
            object sender,
            FDynPropNoticeRaisedEventArgs e
            )
        {
            try
            {
                if (e.fDynProp is FPropTsn)
                {
                    if (e.contents == "LibraryChanged")
                    {
                        changeTcpSessionLibrary(((FPropTsn)e.fDynProp).fTcpSession);
                    }                    
                }                
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }
        
        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
