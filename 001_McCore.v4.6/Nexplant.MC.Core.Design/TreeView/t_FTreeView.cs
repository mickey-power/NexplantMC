/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FTreeView.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.31
--  Description     : FAMate Core FaUIs Tree View Control
--  History         : Created by spike.lee at 2011.01.31
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinToolbars;
//using Nexplant.MC.Core.FaSecsDriver;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FTreeView : UltraTree
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FTreeViewBeforeMouseDownEventHandler BeforeMouseDown = null;
  
        // --

        private bool m_disposed = false;
        // --
        private bool m_multiSelected = false;
        private PopupMenuTool m_popupMenu = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTreeView(
            )
        {
            InitializeComponent();
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    term();
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public bool multiSelected
        {
            get
            {
                try
                {
                    return m_multiSelected;
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
                    this.Override.SelectionType = value ? SelectType.Extended : SelectType.None;
                    m_multiSelected = value;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                this.HandleCreated += new EventHandler(FTreeView_HandleCreated);
                this.AfterActivate += new AfterNodeChangedEventHandler(FTreeView_AfterActivate);
                this.MouseDown += new MouseEventHandler(FTreeView_MouseDown);                
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

        private void term(
            )
        {
            try
            {
                this.HandleCreated -= new EventHandler(FTreeView_HandleCreated);
                this.AfterActivate -= new AfterNodeChangedEventHandler(FTreeView_AfterActivate);
                this.MouseDown -= new MouseEventHandler(FTreeView_MouseDown);
                // --
                m_popupMenu = null;
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

        public void moveUpNode(
            UltraTreeNode tNode
            )
        {
            UltraTreeNode tParentNode = null;
            int movingNodeIndex = -1;

            try
            {
                tParentNode = tNode.Parent;
                movingNodeIndex = tNode.Index;
                tParentNode.Nodes.Remove(tNode);
                tParentNode.Nodes.Insert(movingNodeIndex - 1, tNode);                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tParentNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void moveDownNode(
            UltraTreeNode tNode
            )
        {
            UltraTreeNode tParentNode = null;
            int movingNodeIndex = -1;
            try
            {
                tParentNode = tNode.Parent;
                movingNodeIndex = tNode.Index;
                tParentNode.Nodes.Remove(tNode);
                tParentNode.Nodes.Insert(movingNodeIndex + 1, tNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tParentNode = null;
            }
        }
                
        //------------------------------------------------------------------------------------------------------------------------

        public void beginUpdate(
            )
        {
            try
            {
                if (!this.IsUpdating)
                {
                    this.BeginUpdate();
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

        public void endUpdate(
            )
        {
            try
            {
                if (this.IsUpdating)
                {
                    this.EndUpdate();
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

        public void setPopupMenu(
            PopupMenuTool popupMenu
            )
        {
            try
            {
                m_popupMenu = popupMenu;
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

        private void onBeforeMouseDown(
            UltraTreeNode tNode
            )
        {
            try
            {
                if (BeforeMouseDown != null)
                {
                    BeforeMouseDown(this, new FTreeViewBeforeMouseDownEventArgs(tNode));
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

        #region FTreeView Control Event Handler

        private void FTreeView_HandleCreated(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                //this.Font = new Font("Verdana", 9F);
                //// --
                //this.Appearance.BackColor = Color.WhiteSmoke;
                //this.Appearance.BorderColor = Color.Silver;
                //// --
                //this.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                //this.DisplayStyle = UltraTreeDisplayStyle.Standard;
                //this.DrawsFocusRect = Infragistics.Win.DefaultableBoolean.False;
                //this.HideSelection = false;
                //this.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.Solid;
                //// --
                //this.Override.NodeAppearance.BackColor = Color.WhiteSmoke;                
                //this.Override.NodeAppearance.ForeColor = Color.Black;
                //// --
                //this.Override.ActiveNodeAppearance.BackColor = Color.WhiteSmoke;
                //this.Override.ActiveNodeAppearance.BackColor2 = Color.LightSteelBlue;
                //this.Override.ActiveNodeAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
                //this.Override.ActiveNodeAppearance.ForeColor = Color.Black;
                //// --
                //this.Override.SelectedNodeAppearance.BackColor = Color.WhiteSmoke;
                //this.Override.SelectedNodeAppearance.BackColor2 = Color.LightGray;
                //this.Override.SelectedNodeAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
                //this.Override.SelectedNodeAppearance.ForeColor = Color.Black;
                //// --
                //this.Override.CellClickAction = CellClickAction.ActivateCell;
                //this.Override.ItemHeight = 18;
                //this.Override.Multiline = Infragistics.Win.DefaultableBoolean.False;                
                //this.Override.TipStyleNode = TipStyleNode.Hide;
                //this.Override.UseEditor = Infragistics.Win.DefaultableBoolean.False;
                //// --
                //this.ScrollBarLook.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
                //// --
                //this.UseFlatMode = Infragistics.Win.DefaultableBoolean.True; 
                //this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;

                //// --

                //this.Override.SelectionType = m_multiSelected ? SelectType.Extended : SelectType.None;                
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FTreeView", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------             

        private void FTreeView_AfterActivate(
            object sender, 
            NodeEventArgs e
            )
        {
            try
            {
                if (!m_multiSelected || e.TreeNode.Parent == null)
                {
                    return;
                }

                // --

                for (int i = this.SelectedNodes.Count - 1; i >= 0; i--)
                {
                    if (this.SelectedNodes[i].Parent != e.TreeNode.Parent)
                    {
                        this.SelectedNodes[i].Selected = false;
                    }
                }                
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FTreeView", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------             

        private void FTreeView_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            UltraTreeNode tNode = null;

            try
            {
                if (m_popupMenu == null || e.Button != System.Windows.Forms.MouseButtons.Right)
                {
                    return;
                }

                // --

                tNode = this.GetNodeFromPoint(e.Location);
                if (tNode == null)
                {
                    return;
                }

                onBeforeMouseDown(tNode);

                // --

                this.ActiveNode = tNode;
                m_popupMenu.ShowPopup();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FTreeView", ex, null);
            }
            finally
            {
                tNode = null;
            }
        }
      
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
