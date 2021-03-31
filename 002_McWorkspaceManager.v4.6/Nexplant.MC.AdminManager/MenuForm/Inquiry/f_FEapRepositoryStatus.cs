/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEapRepositoryStatus.cs
--  Creator         : spike.lee
--  Create Date     : 2017.06.05
--  Description     : FAmate Admin Manager EAP Repository Status Form Class 
--  History         : Created by baehyun.seo at 2017.06.05
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using Infragistics.Win;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinToolbars;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FEapRepositoryStatus : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private FSecsDriver m_fSecsDriver = null;
        private FOpcDriver m_fOpcDriver = null;
        private FTcpDriver m_fTcpDriver = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEapRepositoryStatus(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEapRepositoryStatus(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
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
                    if (m_fSecsDriver != null)
                    {
                        m_fSecsDriver.Dispose();
                        m_fSecsDriver = null;
                    }
                    if (m_fOpcDriver != null)
                    {
                        m_fOpcDriver.Dispose();
                        m_fOpcDriver = null;
                    }
                    if (m_fTcpDriver != null)
                    {
                        m_fTcpDriver.Dispose();
                        m_fTcpDriver = null;
                    }
                    // --
                    m_fAdmCore = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        private string eapType
        {
            get
            {
                try
                {
                    if (txtEapName.Tag != null)
                    { 
                        return txtEapName.Tag.ToString();
                    }
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

        private void designGridOfRepository(
           )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Last Access Time");
                uds.Band.Columns.Add("ID");
                uds.Band.Columns.Add("Repository");                

                // --

                grdList.DisplayLayout.Bands[0].Columns["Last Access Time"].CellAppearance.Image = Properties.Resources.RepositoryLog;

                // --
                
                grdList.DisplayLayout.Bands[0].Columns["Last Access Time"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["ID"].Width = 70;
                grdList.DisplayLayout.Bands[0].Columns["Repository"].Width = 250;
                
                // --

                grdList.DisplayLayout.Bands[0].Columns["ID"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                // --

                grdList.multiSelected = true;
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

        private void designTreeOfRepository(
            )
        {
            try
            {
                tvwTree.ImageList = new ImageList();
                // --
                tvwTree.ImageList.Images.Add("RepositoryLog", Properties.Resources.RepositoryLog);
                tvwTree.ImageList.Images.Add("ColumnLog_List", Properties.Resources.ColumnLog_List);
                tvwTree.ImageList.Images.Add("ColumnLog", Properties.Resources.ColumnLog);

                // --

                tvwTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuPopupMenuTree]);
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
            try
            {
                mnuMenu.beginUpdate();

                // --

                if (grdList.activeDataRow == null)
                {
                    mnuMenu.Tools[FMenuKey.MenuEtsExpand].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuEtsCollapse].SharedProps.Enabled = false;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuEtsRepositoryRemove].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuEtsRepositoryClear].SharedProps.Enabled = false;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuEtsExpand].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuEtsCollapse].SharedProps.Enabled = true;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuEtsRepositoryRemove].SharedProps.Enabled = m_tranEnabled;
                    mnuMenu.Tools[FMenuKey.MenuEtsRepositoryClear].SharedProps.Enabled = m_tranEnabled;
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

        private void clear(
            )
        {
            try
            {
                if (this.eapType == FEapType.SECS.ToString())
                {
                    m_fSecsDriver.fRepositoryMaterialStorage.clear();
                }
                else if (this.eapType == FEapType.OPC.ToString())
                {
                    m_fOpcDriver.fRepositoryMaterialStorage.clear();
                }
                else if (this.eapType == FEapType.TCP.ToString())
                {
                    m_fTcpDriver.fRepositoryMaterialStorage.clear();
                }

                // --

                grdList.beginUpdate();
                grdList.removeAllDataRow();
                grdList.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdList.endUpdate();

                // --

                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();
                tvwTree.endUpdate();

                // --

                controlMenu();

                // --

                lblTotal.Text = grdList.Rows.Count.ToString("#,##0");
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshGridOfEapRepository(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            StringBuilder rawData = null;
            object[] cellValues = null;            
            string beforeKey = string.Empty;
            int nextRowNumber = 0;
            UltraDataRow dataRow = null;
            UltraGridRow gridRow = null;

            try
            {
                if (txtEapName.Text.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { "EAP" }));
                }

                // --

                beforeKey = grdList.activeDataRowKey;

                // --

                clear();

                // --

                rawData = new StringBuilder();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("eap", txtEapName.Text);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EapRepositoryStatus", "ListEapRepository", fSqlParams, false, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        rawData.Append(r[0].ToString());
                    }
                } while (nextRowNumber >= 0);

                // --

                if (rawData.Length == 0)
                {
                    return;
                }

                // --

                grdList.beginUpdate(false);

                // --

                if (this.eapType == FEapType.SECS.ToString())
                {
                    m_fSecsDriver.loadRepository(rawData.ToString());
                    foreach (Core.FaSecsDriver.FRepositoryMaterial rpm in m_fSecsDriver.fRepositoryMaterialStorage.fRepositoryMaterialCollection)
                    {
                        cellValues = new object[] {
                        rpm.lastAccessTime,
                        rpm.rpmId.ToString(),
                        rpm.name
                        };
                        // --
                        dataRow = grdList.appendDataRow(rpm.rpmId.ToString(), cellValues);
                        dataRow.Tag = rpm;
                        // --
                        gridRow = grdList.Rows.GetRowWithListIndex(dataRow.Index);
                        gridRow.Appearance.FontData.Bold = (rpm.fontBold ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False);
                        gridRow.Appearance.ForeColor = rpm.fontColor;
                    }
                }
                else if (this.eapType == FEapType.OPC.ToString())
                {
                    m_fOpcDriver.loadRepository(rawData.ToString());
                    foreach (Core.FaOpcDriver.FRepositoryMaterial rpm in m_fOpcDriver.fRepositoryMaterialStorage.fRepositoryMaterialCollection)
                    {
                        cellValues = new object[] {
                        rpm.lastAccessTime,
                        rpm.rpmId.ToString(),
                        rpm.name
                        };
                        // --
                        dataRow = grdList.appendDataRow(rpm.rpmId.ToString(), cellValues);
                        dataRow.Tag = rpm;
                        // --
                        gridRow = grdList.Rows.GetRowWithListIndex(dataRow.Index);
                        gridRow.Appearance.FontData.Bold = (rpm.fontBold ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False);
                        gridRow.Appearance.ForeColor = rpm.fontColor;
                    }
                }
                else if (this.eapType == FEapType.TCP.ToString())
                {
                    m_fTcpDriver.loadRepository(rawData.ToString());
                    foreach (Core.FaTcpDriver.FRepositoryMaterial rpm in m_fTcpDriver.fRepositoryMaterialStorage.fRepositoryMaterialCollection)
                    {
                        cellValues = new object[] {
                        rpm.lastAccessTime,
                        rpm.rpmId.ToString(),
                        rpm.name
                        };
                        // --
                        dataRow = grdList.appendDataRow(rpm.rpmId.ToString(), cellValues);
                        dataRow.Tag = rpm;
                        // --
                        gridRow = grdList.Rows.GetRowWithListIndex(dataRow.Index);
                        gridRow.Appearance.FontData.Bold = (rpm.fontBold ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False);
                        gridRow.Appearance.ForeColor = rpm.fontColor;
                    }
                }

                // --

                grdList.endUpdate(false);

                // --

                if (grdList.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdList.activateDataRow(beforeKey);
                    }
                    if (grdList.activeDataRow == null)
                    {
                        grdList.ActiveRow = grdList.Rows[0];
                    }
                }

                // --

                controlMenu();

                // --

                lblTotal.Text = grdList.Rows.Count.ToString("#,##0");

                // --

                grdList.Focus();
            }
            catch (Exception ex)
            {
                grdList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                rawData = null;
                dataRow = null;
                gridRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        #region SECS Driver 

        private void loadTreeOfSecsObject(
            Core.FaSecsDriver.FRepositoryMaterial fRpm
            )
        {
            UltraTreeNode tNode = null;
            int index = 0;

            try
            {
                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();

                // --

                tNode = new UltraTreeNode(index.ToString(), fRpm.ToString(Core.FaSecsDriver.FStringOption.Detail));
                index++;
                tNode.Tag = fRpm;
                refreshTreeNodeOfSecsObject(fRpm, tvwTree, tNode);

                // --

                loadTreeOfChildSecsObject(tNode, ref index);

                // --

                tNode.ExpandAll();
                tvwTree.Nodes.Add(tNode);
                tvwTree.ActiveNode = tNode;

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

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfChildSecsObject(
            UltraTreeNode tNodeParent,
            ref int index
            )
        {
            Core.FaSecsDriver.FIObject fParent = null;
            UltraTreeNode tNodeChild = null;

            try
            {
                fParent = (Core.FaSecsDriver.FIObject)tNodeParent.Tag;
                // --
                if (fParent.fObjectType == Core.FaSecsDriver.FObjectType.RepositoryMaterial)
                {
                    foreach (Core.FaSecsDriver.FColumn fCol in ((Core.FaSecsDriver.FRepositoryMaterial)fParent).fChildColumnCollection)
                    {
                        tNodeChild = new UltraTreeNode(index.ToString());
                        index++;
                        tNodeChild.Tag = fCol;
                        refreshTreeNodeOfSecsObject(fCol, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadTreeOfChildSecsObject(tNodeChild, ref index);
                    }
                }
                else if (fParent.fObjectType == Core.FaSecsDriver.FObjectType.Column)
                {
                    foreach (Core.FaSecsDriver.FColumn fCol in ((Core.FaSecsDriver.FColumn)fParent).fChildColumnCollection)
                    {
                        tNodeChild = new UltraTreeNode(index.ToString());
                        index++;
                        tNodeChild.Tag = fCol;
                        refreshTreeNodeOfSecsObject(fCol, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadTreeOfChildSecsObject(tNodeChild, ref index);
                    }
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
                tNodeChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshTreeNodeOfSecsObject(
            Core.FaSecsDriver.FIObject fObject,
            FTreeView tvwTree,
            UltraTreeNode tNode
            )
        {
            try
            {
                tNode.Text = fObject.ToString(Core.FaSecsDriver.FStringOption.Detail);
                // --
                tNode.Override.NodeAppearance.ForeColor = fObject.fontColor;
                tNode.Override.NodeAppearance.FontData.Bold = fObject.fontBold ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False;
                // --
                tNode.Override.ActiveNodeAppearance.ForeColor = fObject.fontColor;
                tNode.Override.ActiveNodeAppearance.FontData.Bold = fObject.fontBold ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False;
                // --
                tNode.Override.SelectedNodeAppearance.ForeColor = fObject.fontColor;
                tNode.Override.SelectedNodeAppearance.FontData.Bold = fObject.fontBold ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False;
                // --
                tNode.Override.ImageSize = new System.Drawing.Size(16, 16);
                tNode.Override.NodeAppearance.Image = getImageOfSecsObject(fObject, tvwTree);
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

        private Image getImageOfSecsObject(
            Core.FaSecsDriver.FIObject fObject,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fObject.fObjectType == Core.FaSecsDriver.FObjectType.RepositoryMaterial)
                {
                    return tvwTree.ImageList.Images["RepositoryLog"];
                }
                else if (fObject.fObjectType == Core.FaSecsDriver.FObjectType.Column)
                {
                    return ((Core.FaSecsDriver.FColumn)fObject).fFormat == Core.FaSecsDriver.FFormat.List ? tvwTree.ImageList.Images["ColumnLog_List"] : tvwTree.ImageList.Images["ColumnLog"];
                }               
                // --
                return null;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region OPC Driver 

        private void loadTreeOfOpcObject(
            Core.FaOpcDriver.FRepositoryMaterial fRpm
            )
        {
            UltraTreeNode tNode = null;
            int index = 0;

            try
            {
                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();

                // --

                tNode = new UltraTreeNode(index.ToString(), fRpm.ToString(Core.FaOpcDriver.FStringOption.Detail));
                index++;
                tNode.Tag = fRpm;
                refreshTreeNodeOfOpcObject(fRpm, tvwTree, tNode);

                // --

                loadTreeOfChildOpcObject(tNode, ref index);

                // --

                tNode.ExpandAll();
                tvwTree.Nodes.Add(tNode);
                tvwTree.ActiveNode = tNode;

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

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfChildOpcObject(
            UltraTreeNode tNodeParent,
            ref int index
            )
        {
            Core.FaOpcDriver.FIObject fParent = null;
            UltraTreeNode tNodeChild = null;

            try
            {
                fParent = (Core.FaOpcDriver.FIObject)tNodeParent.Tag;
                // --
                if (fParent.fObjectType == Core.FaOpcDriver.FObjectType.RepositoryMaterial)
                {
                    foreach (Core.FaOpcDriver.FColumn fCol in ((Core.FaOpcDriver.FRepositoryMaterial)fParent).fChildColumnCollection)
                    {
                        tNodeChild = new UltraTreeNode(index.ToString());
                        index++;
                        tNodeChild.Tag = fCol;
                        refreshTreeNodeOfOpcObject(fCol, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadTreeOfChildOpcObject(tNodeChild, ref index);
                    }
                }
                else if (fParent.fObjectType == Core.FaOpcDriver.FObjectType.Column)
                {
                    foreach (Core.FaOpcDriver.FColumn fCol in ((Core.FaOpcDriver.FColumn)fParent).fChildColumnCollection)
                    {
                        tNodeChild = new UltraTreeNode(index.ToString());
                        index++;
                        tNodeChild.Tag = fCol;
                        refreshTreeNodeOfOpcObject(fCol, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadTreeOfChildOpcObject(tNodeChild, ref index);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
                tNodeChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshTreeNodeOfOpcObject(
            Core.FaOpcDriver.FIObject fObject,
            FTreeView tvwTree,
            UltraTreeNode tNode
            )
        {
            try
            {
                tNode.Text = fObject.ToString(Core.FaOpcDriver.FStringOption.Detail);
                // --
                tNode.Override.NodeAppearance.ForeColor = fObject.fontColor;
                tNode.Override.NodeAppearance.FontData.Bold = fObject.fontBold ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False;
                // --
                tNode.Override.ActiveNodeAppearance.ForeColor = fObject.fontColor;
                tNode.Override.ActiveNodeAppearance.FontData.Bold = fObject.fontBold ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False;
                // --
                tNode.Override.SelectedNodeAppearance.ForeColor = fObject.fontColor;
                tNode.Override.SelectedNodeAppearance.FontData.Bold = fObject.fontBold ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False;
                // --
                tNode.Override.ImageSize = new System.Drawing.Size(16, 16);
                tNode.Override.NodeAppearance.Image = getImageOfOpcObject(fObject, tvwTree);
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

        private Image getImageOfOpcObject(
            Core.FaOpcDriver.FIObject fObject,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fObject.fObjectType == Core.FaOpcDriver.FObjectType.RepositoryMaterial)
                {
                    return tvwTree.ImageList.Images["RepositoryLog"];
                }
                else if (fObject.fObjectType == Core.FaOpcDriver.FObjectType.Column)
                {
                    return ((Core.FaOpcDriver.FColumn)fObject).fFormat == Core.FaOpcDriver.FFormat.List ? tvwTree.ImageList.Images["ColumnLog_List"] : tvwTree.ImageList.Images["ColumnLog"];
                }
                // --
                return null;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region TCP Driver

        private void loadTreeOfTcpObject(
            Core.FaTcpDriver.FRepositoryMaterial fRpm
            )
        {
            UltraTreeNode tNode = null;
            int index = 0;

            try
            {
                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();

                // --

                tNode = new UltraTreeNode(index.ToString(), fRpm.ToString(Core.FaTcpDriver.FStringOption.Detail));
                index++;
                tNode.Tag = fRpm;
                refreshTreeNodeOfTcpObject(fRpm, tvwTree, tNode);

                // --

                loadTreeOfChildTcpObject(tNode, ref index);

                // --

                tNode.ExpandAll();
                tvwTree.Nodes.Add(tNode);
                tvwTree.ActiveNode = tNode;

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

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfChildTcpObject(
            UltraTreeNode tNodeParent,
            ref int index
            )
        {
            Core.FaTcpDriver.FIObject fParent = null;
            UltraTreeNode tNodeChild = null;

            try
            {
                fParent = (Core.FaTcpDriver.FIObject)tNodeParent.Tag;
                // --
                if (fParent.fObjectType == Core.FaTcpDriver.FObjectType.RepositoryMaterial)
                {
                    foreach (Core.FaTcpDriver.FColumn fCol in ((Core.FaTcpDriver.FRepositoryMaterial)fParent).fChildColumnCollection)
                    {
                        tNodeChild = new UltraTreeNode(index.ToString());
                        index++;
                        tNodeChild.Tag = fCol;
                        refreshTreeNodeOfTcpObject(fCol, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadTreeOfChildTcpObject(tNodeChild, ref index);
                    }
                }
                else if (fParent.fObjectType == Core.FaTcpDriver.FObjectType.Column)
                {
                    foreach (Core.FaTcpDriver.FColumn fCol in ((Core.FaTcpDriver.FColumn)fParent).fChildColumnCollection)
                    {
                        tNodeChild = new UltraTreeNode(index.ToString());
                        index++;
                        tNodeChild.Tag = fCol;
                        refreshTreeNodeOfTcpObject(fCol, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadTreeOfChildTcpObject(tNodeChild, ref index);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
                tNodeChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshTreeNodeOfTcpObject(
            Core.FaTcpDriver.FIObject fObject,
            FTreeView tvwTree,
            UltraTreeNode tNode
            )
        {
            try
            {
                tNode.Text = fObject.ToString(Core.FaTcpDriver.FStringOption.Detail);
                // --
                tNode.Override.NodeAppearance.ForeColor = fObject.fontColor;
                tNode.Override.NodeAppearance.FontData.Bold = fObject.fontBold ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False;
                // --
                tNode.Override.ActiveNodeAppearance.ForeColor = fObject.fontColor;
                tNode.Override.ActiveNodeAppearance.FontData.Bold = fObject.fontBold ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False;
                // --
                tNode.Override.SelectedNodeAppearance.ForeColor = fObject.fontColor;
                tNode.Override.SelectedNodeAppearance.FontData.Bold = fObject.fontBold ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False;
                // --
                tNode.Override.ImageSize = new System.Drawing.Size(16, 16);
                tNode.Override.NodeAppearance.Image = getImageOfTcpObject(fObject, tvwTree);
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

        private Image getImageOfTcpObject(
            Core.FaTcpDriver.FIObject fObject,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fObject.fObjectType == Core.FaTcpDriver.FObjectType.RepositoryMaterial)
                {
                    return tvwTree.ImageList.Images["RepositoryLog"];
                }
                else if (fObject.fObjectType == Core.FaTcpDriver.FObjectType.Column)
                {
                    return ((Core.FaTcpDriver.FColumn)fObject).fFormat == Core.FaTcpDriver.FFormat.List ? tvwTree.ImageList.Images["ColumnLog_List"] : tvwTree.ImageList.Images["ColumnLog"];
                }
                // --
                return null;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        private void validateLicense(
            string eapType
            )
        {
            try
            {
                if (eapType == FEapType.SECS.ToString())
                {
                    m_fSecsDriver = new FSecsDriver(m_fAdmCore.fWsmCore.appPath + "\\License\\license.lic");
                    m_fSecsDriver.enabledRepositorySave = false;
                    m_fSecsDriver.enabledRepositoryAutoRemove = false;
                }
                else if (eapType == FEapType.OPC.ToString())
                {
                    m_fOpcDriver = new FOpcDriver(m_fAdmCore.fWsmCore.appPath + "\\License\\license.lic", FOpcRunMode.WorkspaceManager);
                    m_fOpcDriver.enabledRepositorySave = false;
                    m_fOpcDriver.enabledRepositoryAutoRemove = false;
                }
                else if (eapType == FEapType.TCP.ToString())
                {
                    m_fTcpDriver = new FTcpDriver(m_fAdmCore.fWsmCore.appPath + "\\License\\license.lic");
                    m_fTcpDriver.enabledRepositorySave = false;
                    m_fTcpDriver.enabledRepositoryAutoRemove = false;
                }
                else
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0043", new object[] {"EAP Type"}));
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

        public void attach(
            string eapName,
            string eapType
            )
        {
            try
            {
                txtEapName.Text = eapName;
                txtEapName.Tag = eapType;

                // --

                validateLicense(eapType);

                // --

                refreshGridOfEapRepository();

                // --

                txtEapName.Focus();
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

        private void procMenuExpand(
            )
        {
            try
            {
                tvwTree.beginUpdate();

                // -- 

                tvwTree.ActiveNode.ExpandAll();

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

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCollapse(
            )
        {
            try
            {
                tvwTree.beginUpdate();

                // --

                tvwTree.ActiveNode.CollapseAll();

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

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRepositoryRemove(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEap = null;
            FXmlNode fXmlNodeInRps = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                if (
                    FMessageBox.showQuestion(
                        FConstants.ApplicationName,
                        m_fAdmCore.fUIWizard.generateMessage("Q0004", new object[] { "Repository" }),
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button2,
                        this
                        ) == DialogResult.No
                    )
                {
                    return;
                }

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TrnEapRepositoryRemove_In.E_ADMADS_TrnEapRepositoryRemove_In);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapRepositoryRemove_In.A_hLanguage, FADMADS_TrnEapRepositoryRemove_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapRepositoryRemove_In.A_hFactory, FADMADS_TrnEapRepositoryRemove_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapRepositoryRemove_In.A_hUserId, FADMADS_TrnEapRepositoryRemove_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapRepositoryRemove_In.A_hHostIp, FADMADS_TrnEapRepositoryRemove_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapRepositoryRemove_In.A_hHostName, FADMADS_TrnEapRepositoryRemove_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapRepositoryRemove_In.A_hStep, FADMADS_TrnEapRepositoryRemove_In.D_hStep, "1");
                // --
                fXmlNodeInEap = fXmlNodeIn.set_elem(FADMADS_TrnEapRepositoryRemove_In.FEap.E_Eap);
                fXmlNodeInEap.set_elemVal(FADMADS_TrnEapRepositoryRemove_In.FEap.A_EapId, FADMADS_TrnEapRepositoryRemove_In.FEap.D_EapId, txtEapName.Text);
                // --
                fXmlNodeInRps = fXmlNodeInEap.set_elem(FADMADS_TrnEapRepositoryRemove_In.FEap.FRepository.E_Repository);
                foreach (string s in grdList.selectedDataRowKeys)
                {
                    fXmlNodeInRps.add_elemVal(
                        FADMADS_TrnEapRepositoryRemove_In.FEap.FRepository.A_RpmId,
                        FADMADS_TrnEapRepositoryRemove_In.FEap.FRepository.D_RpmId,
                        s
                        );
                }

                // --

                FADMADSCaster.ADMADS_TrnEapRepositoryRemove_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TrnEapRepositoryRemove_Out.A_hStatus, FADMADS_TrnEapRepositoryRemove_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_TrnEapRepositoryRemove_Out.A_hStatusMessage, FADMADS_TrnEapRepositoryRemove_Out.D_hStatusMessage));
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInEap = null;
                fXmlNodeInRps = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRepositoryClear(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEap = null;
            FXmlNode fXmlNodeInRps = null;
            FXmlNode fXmlNodeOut = null;
            string rawData = string.Empty;

            try
            {
                if (
                    FMessageBox.showQuestion(
                        FConstants.ApplicationName,
                        m_fAdmCore.fUIWizard.generateMessage("Q0021", new object[] { "Repository" }),
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button2,
                        this
                        ) == DialogResult.No
                    )
                {
                    return;
                }

                // --

                if (this.eapType == FEapType.SECS.ToString())
                {
                    m_fSecsDriver.fRepositoryMaterialStorage.clear();
                    rawData = m_fSecsDriver.getRepositoryRawData();
                }
                else if (this.eapType == FEapType.OPC.ToString())
                {
                    m_fOpcDriver.fRepositoryMaterialStorage.clear();
                    rawData = m_fOpcDriver.getRepositoryRawData();
                }
                else if (this.eapType == FEapType.TCP.ToString())
                {
                    m_fTcpDriver.fRepositoryMaterialStorage.clear();
                    rawData = m_fTcpDriver.getRepositoryRawData();
                }

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TrnEapRepositoryClear_In.E_ADMADS_TrnEapRepositoryClear_In);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapRepositoryClear_In.A_hLanguage, FADMADS_TrnEapRepositoryClear_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapRepositoryClear_In.A_hFactory, FADMADS_TrnEapRepositoryClear_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapRepositoryClear_In.A_hUserId, FADMADS_TrnEapRepositoryClear_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapRepositoryClear_In.A_hHostIp, FADMADS_TrnEapRepositoryClear_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapRepositoryClear_In.A_hHostName, FADMADS_TrnEapRepositoryClear_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapRepositoryClear_In.A_hStep, FADMADS_TrnEapRepositoryClear_In.D_hStep, "1");
                // --
                fXmlNodeInEap = fXmlNodeIn.set_elem(FADMADS_TrnEapRepositoryClear_In.FEap.E_Eap);
                fXmlNodeInEap.set_elemVal(FADMADS_TrnEapRepositoryClear_In.FEap.A_EapId, FADMADS_TrnEapRepositoryClear_In.FEap.D_EapId, txtEapName.Text);
                // --
                fXmlNodeInRps = fXmlNodeInEap.set_elem(FADMADS_TrnEapRepositoryClear_In.FEap.FRepository.E_Repository);
                fXmlNodeInRps.set_elemVal(FADMADS_TrnEapRepositoryClear_In.FEap.FRepository.A_RawData, FADMADS_TrnEapRepositoryClear_In.FEap.FRepository.D_RawData, rawData);

                // --

                FADMADSCaster.ADMADS_TrnEapRepositoryClear_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TrnEapRepositoryClear_Out.A_hStatus, FADMADS_TrnEapRepositoryClear_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_TrnEapRepositoryClear_Out.A_hStatusMessage, FADMADS_TrnEapRepositoryClear_Out.D_hStatusMessage));
                }

                // --

                refreshGridOfEapRepository();
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

        #region FEapRepositoryStatus Form Event Handler

        private void FEapRepositoryStatus_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.EapRepositoryStatus);

                // --

                designGridOfRepository();
                designTreeOfRepository();

                // --

               m_fAdmCore.fOption.fChildFormList.add(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void FEapRepositoryStatus_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                controlMenu();

                // --

                txtEapName.Focus();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void FEapRepositoryStatus_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fSecsDriver != null)
                {
                    m_fSecsDriver.Dispose();
                    m_fSecsDriver = null;
                }
                if (m_fOpcDriver != null)
                {
                    m_fOpcDriver.Dispose();
                    m_fOpcDriver = null;
                }
                if (m_fTcpDriver != null)
                {
                    m_fTcpDriver.Dispose();
                    m_fTcpDriver = null;
                }

                // --

                m_fAdmCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void FEapRepositoryStatus_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    FCursor.waitCursor();
                    // --
                    refreshGridOfEapRepository();
                    // --
                    FCursor.defaultCursor();
                }
            }
            catch (Exception ex)
            {
                FCursor.defaultCursor();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region txtEapName Control Event Handler

        private void txtEapName_EditorButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            FEapSelector fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FEapSelector(m_fAdmCore, txtEapName.Text, "N");
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                validateLicense(fDialog.selectedType);

                // --

                txtEapName.Text = fDialog.selectedEapName;
                txtEapName.Tag = fDialog.selectedType;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                if (fDialog != null)
                {
                    fDialog.Dispose();
                    fDialog = null;
                }

                // --

                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void txtEapName_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                clear();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region mnuMenu Control Event Handler

        private void mnuMenu_ToolClick(
            object sender,
            Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuEtsRefresh)
                {
                    refreshGridOfEapRepository();
                }
                else if (e.Tool.Key == FMenuKey.MenuEtsExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuEtsCollapse)
                {
                    procMenuCollapse();
                }
                else if (e.Tool.Key == FMenuKey.MenuEtsRepositoryRemove)
                {
                    procMenuRepositoryRemove();
                }
                else if (e.Tool.Key == FMenuKey.MenuEtsRepositoryClear)
                {
                    procMenuRepositoryClear();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdList Control Event Handler

        private void grdList_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (grdList.ActiveRow == null)
                {
                    tvwTree.beginUpdate();
                    tvwTree.Nodes.Clear();
                    tvwTree.endUpdate();
                }
                else
                {
                    if (this.eapType == FEapType.SECS.ToString())
                    {
                        loadTreeOfSecsObject((Core.FaSecsDriver.FRepositoryMaterial)grdList.activeDataRow.Tag);
                    }
                    else if (this.eapType == FEapType.OPC.ToString())
                    {
                        loadTreeOfOpcObject((Core.FaOpcDriver.FRepositoryMaterial)grdList.activeDataRow.Tag);
                    }
                    else if (this.eapType == FEapType.TCP.ToString())
                    {
                        loadTreeOfTcpObject((Core.FaTcpDriver.FRepositoryMaterial)grdList.activeDataRow.Tag);
                    }
                }
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                // --

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
                FCursor.waitCursor();

                // --

                if (!grdList.searchGridRow(e.searchWord))
                {
                    FMessageBox.showInformation("Search", m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
