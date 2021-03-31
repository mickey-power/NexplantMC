/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FFlowContainer.cs
--  Creator         : spike.lee
--  Create Date     : 2011.05.31
--  Description     : FAMate Core FaUIs Flow Container Control
--  History         : Created by spike.lee at 2011.05.31
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Nexplant.MC.Core.FaCommon;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.Misc;
using Infragistics.Win;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FFlowContainer : UserControl
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FFlowContainerActivatedEventHandler FlowContainerActivated = null;
        public event FFlowCtrlActivatedEventHandler FlowCtrlActivated = null;

        // --

        private bool m_disposed = false;
        // --
        private List<FIFlowCtrl> m_flowCtrlList = null;
        private Dictionary<string, FIFlowCtrl> m_flowCtrlKeys = null;
        private int m_updateCount = 0;
        private int m_headerWidth = 0;
        private int m_bodyWidth = 0;        
        private UltraGrid m_activeGrid = null;
        private UltraGridRow m_activeGridRow = null;
        private FIFlowCtrl m_fActiveFlowCtrl = null;
        private Infragistics.Win.Appearance m_activeRowAppearance = null;
        private Infragistics.Win.Appearance m_deactiveRowAppearance = null;
        private string m_text = "flowContainer";
        private Color m_fontColor = Color.Black;
        private bool m_fontBold = false;
        private PopupMenuTool m_popupMenu = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FFlowContainer(
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
                    m_activeGrid = null;
                    m_activeGridRow = null;
                    m_fActiveFlowCtrl = null;
                    m_popupMenu = null;

                    // --
                    
                    term();                    
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public string text
        {
            get
            {
                try
                {
                    return m_text;
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
                    if (grdScenario.Rows.Count < 1)
                    {
                        return;
                    }

                    m_text = value;
                    grdScenario.Rows[0].Cells[0].Value = m_text;
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
                    return m_fontColor;
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
                    m_fontColor = value;
                    if (grdScenario.Rows.Count > 0 && grdScenario.Rows[0].Cells.Count > 0)
                    {
                        grdScenario.Rows[0].Cells[0].Appearance.ForeColor = m_fontColor;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool fontBold
        {
            get
            {
                try
                {
                    return m_fontBold;
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
                    m_fontBold = value;
                    if (grdScenario.Rows.Count > 0 && grdScenario.Rows[0].Cells.Count > 0)
                    {
                        grdScenario.Rows[0].Cells[0].Appearance.FontData.Bold = (m_fontBold ? DefaultableBoolean.True : DefaultableBoolean.False);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FFlowCtrlCollection fFlowCtrlCollection
        {
            get
            {
                try
                {
                    return new FFlowCtrlCollection(m_flowCtrlList);
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

        public FIFlowCtrl fActiveFlowCtrl
        {
            get
            {
                try
                {
                    return m_fActiveFlowCtrl;
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

        public bool isActive
        {
            get
            {
                try
                {
                    if (m_fActiveFlowCtrl == null)
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

        //------------------------------------------------------------------------------------------------------------------------

        internal PopupMenuTool popupMenu
        {
            get
            {
                try
                {
                    return m_popupMenu;
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

        internal UltraPanelClientArea clientArea
        {
            get
            {
                try
                {
                    return pnlBody.ClientArea;
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

        public string eqAlias
        {
            get
            {
                try
                {
                    return lblEq.Text;
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
                    lblEq.Text = value;
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

        public string eapAlias
        {
            get
            {
                try
                {
                    return lblEap.Text;
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
                    lblEap.Text = value;
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

        public string hostAlias
        {
            get
            {
                try
                {
                    return lblHost.Text;
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
                    lblHost.Text = value;
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
                m_flowCtrlList = new List<FIFlowCtrl>();
                m_flowCtrlKeys = new Dictionary<string, FIFlowCtrl>();

                // --

                m_activeRowAppearance = FGridCommon.getActiveAppearance();
                m_activeRowAppearance.TextVAlign = VAlign.Middle;
                m_activeRowAppearance.TextTrimming = TextTrimming.EllipsisCharacter;
                // --
                m_deactiveRowAppearance = FGridCommon.getRowCellAppearance();
                m_deactiveRowAppearance.TextVAlign = VAlign.Middle;
                m_deactiveRowAppearance.TextTrimming = TextTrimming.EllipsisCharacter;                
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

        public void beginUpdate(
            )
        {
            try
            {
                if (!pnlBody.IsUpdating)
                {
                    pnlBody.SuspendLayout();
                    pnlBody.BeginUpdate();                          
                }
                m_updateCount++;
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
                m_updateCount--;
                if (m_updateCount > 0)
                {
                    return;
                }

                // --

                if (pnlBody.IsUpdating)
                {
                    pnlBody.EndUpdate();
                    pnlBody.ResumeLayout();
                }
                m_updateCount = 0;
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

        private void designGridOfScenario(
            )
        {
            UltraDataSource uds = null;

            try
            {
                grdScenario.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
                grdScenario.DisplayLayout.Bands[0].ColHeadersVisible = false;
                grdScenario.DisplayLayout.Override.ActiveAppearancesEnabled = DefaultableBoolean.False;
                grdScenario.DisplayLayout.Override.MinRowHeight = 19;
                grdScenario.DisplayLayout.Override.DefaultRowHeight = 19;
                // --
                grdScenario.DisplayLayout.Override.CellAppearance = m_deactiveRowAppearance;         
                // --
                grdScenario.valueCopyOfClickedCell = false;

                // --

                uds = grdScenario.dataSource;
                // --
                uds.Band.Columns.Add("Scenario");
                grdScenario.DisplayLayout.Override.CellAppearance.TextHAlign = HAlign.Left;

                // --
                
                uds.Rows.Add(new object[] { m_text });
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                uds = null;
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

        internal void onKeyDown(
            KeyEventArgs e
            )
        {
            try
            {
                this.OnKeyDown(e);
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

        private void resizeFlowCtrl(
            Control ctrl
            )
        {
            int width = 0;

            try
            {
                width = m_bodyWidth - 18;
                if (width < 0)
                {
                    return;
                }
                ctrl.Width = width;
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

        private void resizeAllFlowCtrl(
            )
        {
            try
            {
                foreach (Control c in pnlBody.ClientArea.Controls)
                {
                    resizeFlowCtrl(c);
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

        private void arrangeFlowCtrl(
            int startPos
            )
        {
            int oldVal = 0;
            // int tabIndex = 0;
            int y = 0;

            try
            {
                beginUpdate();

                // --                

                oldVal = pnlBody.ClientArea.VerticalScroll.Value;
                pnlBody.ClientArea.VerticalScroll.Value = 0;
                y = 2;
                for (int i = 0; i < pnlBody.ClientArea.Controls.Count; i++)
                {
                    pnlBody.ClientArea.Controls[i].TabIndex = i;
                    if (i >= startPos)
                    {
                        pnlBody.ClientArea.Controls[i].Top = y;
                    }
                    y += 34;                    
                }
                pnlBody.ClientArea.VerticalScroll.Value = oldVal;

                // --

                endUpdate();
            }
            catch (Exception ex)
            {
                endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIFlowCtrl appendFlowCtrl(
            FIFlowCtrl fNewFlowCtrl
            )
        {
            Control newCtrl = null;

            try
            {
                newCtrl = (Control)fNewFlowCtrl;

                // --

                if (newCtrl.Parent != null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "New Object", "Parent"));
                }

                // --                
                
                m_flowCtrlList.Add(fNewFlowCtrl);
                m_flowCtrlKeys.Add(fNewFlowCtrl.key, fNewFlowCtrl);                

                // --

                beginUpdate();

                // --
                
                resizeFlowCtrl(newCtrl);
                pnlBody.ClientArea.Controls.Add(newCtrl);
                FUIWizard.changeControlFontName(this.Font.Name, newCtrl);
                newCtrl.Show();                
                // --
                arrangeFlowCtrl(pnlBody.ClientArea.Controls.Count - 1);

                // --

                endUpdate();

                // --

                return fNewFlowCtrl;
            }
            catch (Exception ex)
            {
                endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                newCtrl = null;                
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIFlowCtrl insertBeforeFlowCtrl(
            FIFlowCtrl fNewFlowCtrl, 
            FIFlowCtrl fRefFlowCtrl
            )
        {
            Control newCtrl = null;
            Control refCtrl = null;
            int index = 0;

            try
            {
                newCtrl = (Control)fNewFlowCtrl;
                refCtrl = (Control)fRefFlowCtrl;

                // --

                if (newCtrl.Parent != null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "New Object", "Parent"));
                }

                if (!pnlBody.ClientArea.Contains(refCtrl))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Reference Object", "Child"));
                }

                // --

                index = pnlBody.ClientArea.Controls.GetChildIndex(refCtrl);
                m_flowCtrlList.Insert(index, fNewFlowCtrl);
                m_flowCtrlKeys.Add(fNewFlowCtrl.key, fNewFlowCtrl);                

                // --

                beginUpdate();

                // --

                resizeFlowCtrl(newCtrl);
                pnlBody.ClientArea.Controls.Add(newCtrl);                
                pnlBody.ClientArea.Controls.SetChildIndex(newCtrl, index);
                FUIWizard.changeControlFontName(this.Font.Name, newCtrl);
                newCtrl.Show();
                // --
                arrangeFlowCtrl(index);

                // --

                endUpdate();

                // --

                return fNewFlowCtrl;
            }
            catch (Exception ex)
            {
                endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                newCtrl = null;
                refCtrl = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIFlowCtrl insertAfterFlowCtrl(
            FIFlowCtrl fNewFlowCtrl,
            FIFlowCtrl fRefFlowCtrl
            )
        {
            Control newCtrl = null;
            Control refCtrl = null;
            int index = 0;

            try
            {
                newCtrl = (Control)fNewFlowCtrl;
                refCtrl = (Control)fRefFlowCtrl;

                // --

                if (newCtrl.Parent != null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "New Object", "Parent"));
                }

                if (!pnlBody.ClientArea.Contains(refCtrl))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Reference Object", "Child"));
                }

                // --

                index = pnlBody.ClientArea.Controls.GetChildIndex(refCtrl) + 1;
                m_flowCtrlList.Insert(index, fNewFlowCtrl);
                m_flowCtrlKeys.Add(fNewFlowCtrl.key, fNewFlowCtrl);

                // --

                beginUpdate();

                // --

                resizeFlowCtrl(newCtrl);
                pnlBody.ClientArea.Controls.Add(newCtrl);
                pnlBody.ClientArea.Controls.SetChildIndex(newCtrl, index);
                FUIWizard.changeControlFontName(this.Font.Name, newCtrl);
                newCtrl.Show();
                // --
                arrangeFlowCtrl(index);                

                // --

                endUpdate();

                // --

                return fNewFlowCtrl;
            }
            catch (Exception ex)
            {
                endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                newCtrl = null;
                refCtrl = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIFlowCtrl removeFlowCtrl(
            FIFlowCtrl fFlowCtrl
            )
        {
            Control ctrl = null;
            FIFlowCtrl fOldActiveFlowCtrl = null;
            FIFlowCtrl fActiveFlowCtrl = null;
            int index = 0;


            try
            {
                ctrl = (Control)fFlowCtrl;

                // --

                if (ctrl.Parent == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0005, "Object"));
                }

                if (!pnlBody.ClientArea.Contains(ctrl))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "Child"));
                }

                // --

                index = m_flowCtrlList.IndexOf(fFlowCtrl);
                fOldActiveFlowCtrl = m_fActiveFlowCtrl;
                m_flowCtrlList.Remove(fFlowCtrl);
                m_flowCtrlKeys.Remove(fFlowCtrl.key);

                // --

                beginUpdate();
                pnlBody.ClientArea.Controls.Remove(ctrl);
                arrangeFlowCtrl(index);
                // --
                if (fOldActiveFlowCtrl == fFlowCtrl)
                {
                    if (m_flowCtrlList.Count > 0)
                    {
                        if (index >= m_flowCtrlList.Count)
                        {
                            fActiveFlowCtrl = m_flowCtrlList[index - 1];
                        }
                        else
                        {
                            fActiveFlowCtrl = m_flowCtrlList[index];
                        }
                        activateControl((Control)fActiveFlowCtrl, ((FBaseFlowCtrl)fActiveFlowCtrl).grid, ((FBaseFlowCtrl)fActiveFlowCtrl).grid.Rows[0], false);
                    }
                    else
                    {
                        activateControl(this, grdScenario, grdScenario.Rows[0], false);
                    }                    
                }
                endUpdate();

                // --

                return fFlowCtrl;
            }
            catch (Exception ex)
            {
                endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                ctrl = null;
                fOldActiveFlowCtrl = null;
                fActiveFlowCtrl = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAllFlowCtrl(
            )
        {
            try
            {
                m_flowCtrlList.Clear();
                m_flowCtrlKeys.Clear();

                // --

                beginUpdate();
                pnlBody.ClientArea.Controls.Clear();
                // --
                if (m_fActiveFlowCtrl != null)
                {
                    activateControl(this, grdScenario, grdScenario.Rows[0], false);
                }
                endUpdate();
            }
            catch (Exception ex)
            {
                endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIFlowCtrl getFlowCtrl(
            string key
            )
        {
            try
            {
                if (m_flowCtrlKeys.ContainsKey(key))
                {
                    return m_flowCtrlKeys[key];
                }
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

        //------------------------------------------------------------------------------------------------------------------------

        public FIFlowCtrl getFlowCtrl(
            int index
            )
        {
            try
            {
                return m_flowCtrlList[index];
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

        internal void activateControl(
            Control sender,
            UltraGrid grid, 
            UltraGridRow gridRow,
            bool isOption
            )
        {
            try
            {
                if (isOption && grid == m_activeGrid && gridRow == m_activeGridRow)
                {
                    return;
                }

                // --

                if (m_activeGrid != null)
                {
                    m_activeGridRow.CellAppearance = m_deactiveRowAppearance;
                }
                gridRow.CellAppearance = m_activeRowAppearance;

                // --

                m_activeGrid = grid;
                m_activeGridRow = gridRow;
                m_activeGrid.Focus();

                // --

                if (sender is FBaseFlowCtrl)
                {
                    m_fActiveFlowCtrl = (FIFlowCtrl)sender;                    
                    // --
                    if (FlowCtrlActivated != null)
                    {
                        FlowCtrlActivated(this, new FFlowCtrlActivatedEventArgs(m_fActiveFlowCtrl));
                    }
                }
                else
                {
                    m_fActiveFlowCtrl = null;
                    // --
                    if (FlowContainerActivated != null)
                    {
                        FlowContainerActivated(this, new FFlowContainerActivatedEventArgs(this));
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

        public void activateFlowContainer(
            )
        {
            try
            {
                activateControl(this, grdScenario, grdScenario.Rows[0], false);
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

        public void activateFlowCtrl(
            FIFlowCtrl fFlowCtrl
            )
        {
            try
            {
                if (!pnlBody.ClientArea.Contains((Control)fFlowCtrl))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "Child"));
                }

                // --

                ((FBaseFlowCtrl)fFlowCtrl).activate(true);
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

        public void moveUpFlowCtrl(
            FIFlowCtrl fFlowCtrl
            )
        {
            Control ctrl = null;
            Control refCtrl = null;

            FIFlowCtrl fOldActiveFlowCtrl = null;            
            int index = 0;

            try
            {
                ctrl = (Control)fFlowCtrl;
                
                
                // --

                if (ctrl.Parent == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0005, "Object"));
                }

                if (!pnlBody.ClientArea.Contains(ctrl))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "Child"));
                }

                if (fFlowCtrl.fPreviousSibling == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "PreviousSibling"));                    
                }

                refCtrl = (Control)fFlowCtrl.fPreviousSibling;

                index = m_flowCtrlList.IndexOf(fFlowCtrl);
                fOldActiveFlowCtrl = m_fActiveFlowCtrl;
                m_flowCtrlList.Remove(fFlowCtrl);
                m_flowCtrlKeys.Remove(fFlowCtrl.key);
                
                // --

                beginUpdate();
                
                // --

                pnlBody.ClientArea.Controls.Remove(ctrl);
                arrangeFlowCtrl(index);

                // --
                
                index = pnlBody.ClientArea.Controls.GetChildIndex(refCtrl);
                m_flowCtrlList.Insert(index, fOldActiveFlowCtrl);
                m_flowCtrlKeys.Add(fOldActiveFlowCtrl.key, fOldActiveFlowCtrl);

                // --

                resizeFlowCtrl(ctrl);
                pnlBody.ClientArea.Controls.Add(ctrl);
                pnlBody.ClientArea.Controls.SetChildIndex(ctrl, index);
                FUIWizard.changeControlFontName(this.Font.Name, ctrl);
                ctrl.Show();
                // --
                arrangeFlowCtrl(index);

                // --

                endUpdate();
            }
            catch (Exception ex)
            {
                endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void moveDownFlowCtrl(
            FIFlowCtrl fFlowCtrl
            )
        {
            Control ctrl = null;
            Control refCtrl = null;

            FIFlowCtrl fOldActiveFlowCtrl = null;           
            int index = 0;

            try
            {
                ctrl = (Control)fFlowCtrl;


                // --

                if (ctrl.Parent == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0005, "Object"));
                }

                if (!pnlBody.ClientArea.Contains(ctrl))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "Child"));
                }

                if (fFlowCtrl.fNextSibling == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "NextSibling"));
                }

                refCtrl = (Control)fFlowCtrl.fNextSibling;

                index = m_flowCtrlList.IndexOf(fFlowCtrl);
                fOldActiveFlowCtrl = m_fActiveFlowCtrl;
                m_flowCtrlList.Remove(fFlowCtrl);
                m_flowCtrlKeys.Remove(fFlowCtrl.key);

                // --

                beginUpdate();
                
                // --
                
                pnlBody.ClientArea.Controls.Remove(ctrl);
                arrangeFlowCtrl(index);                

                // --

                index = pnlBody.ClientArea.Controls.GetChildIndex(refCtrl) + 1;
                m_flowCtrlList.Insert(index, fOldActiveFlowCtrl);
                m_flowCtrlKeys.Add(fOldActiveFlowCtrl.key, fOldActiveFlowCtrl);
                
                // --

                resizeFlowCtrl(ctrl);
                pnlBody.ClientArea.Controls.Add(ctrl);
                pnlBody.ClientArea.Controls.SetChildIndex(ctrl, index);
                FUIWizard.changeControlFontName(this.Font.Name, ctrl);
                ctrl.Show();
                // --
                arrangeFlowCtrl(index);

                // --

                endUpdate();
            }
            catch (Exception ex)
            {
                endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FFlowContainer Form Event Handler

        private void FFlowContainer_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                m_headerWidth = pnlHeader.Width;
                m_bodyWidth = pnlBody.Width;

                // --

                designGridOfScenario();

                // --                

                pnlBody.ClientArea.ControlAdded += new ControlEventHandler(ClientArea_ControlAdded);
                pnlBody.ClientArea.ControlRemoved += new ControlEventHandler(ClientArea_ControlRemoved);
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FFlowContainer", ex, null);
            }
            finally
            {

            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region pnlHeader Control Event Handler

        private void pnlHeader_PaintClient(
            object sender, 
            PaintEventArgs e
            )
        {
            int left = 0;

            try
            {
                if (!pnlHeader.IsHandleCreated)
                {
                    return;
                }

                // --
                
                if (pnlHeader.Width == m_headerWidth)
                {
                    return;
                }
                m_headerWidth = pnlHeader.Width;

                // --

                beginUpdate();       

                // --

                lblEq.Left = 2;
                // --
                left = (m_headerWidth / 2) - (lblEap.Width / 2);
                if (left > 0)
                {
                    lblEap.Left = left;
                }
                // --
                left = m_headerWidth - lblEap.Width - 2;
                if (left > 0)
                {
                    lblHost.Left = left;
                }

                // --

                endUpdate();
            }
            catch (Exception ex)
            {
                endUpdate();
                FMessageBox.showError("FFlowContainer", ex, null);
            }
            finally
            {
                
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region pnlBody Control Event Handler

        private void pnlBody_PaintClient(
            object sender,
            PaintEventArgs e
            )
        {
            Pen pen = null;
            int x = 0;
            int x1 = 0;
            int x2 = 0;
            int y = 0;
            int y1 = 0;
            int y2 = 0;

            try
            {
                if (!pnlBody.IsHandleCreated)
                {
                    return;
                }

                // --

                beginUpdate();

                // --

                pen = new Pen(Color.Gray, 2);

                // --

                // ***
                // EQ Line
                // ***
                x = 28;
                y = pnlBody.Height - 2;
                // --
                x1 = x;
                x2 = x;
                y1 = 0;
                y2 = y;
                e.Graphics.DrawLine(pen, x1, y1, x2, y2);
                // --
                x1 = x - 4;
                x2 = x + 4;
                y1 = 1;
                y2 = 1;
                e.Graphics.DrawLine(pen, x1, y1, x2, y2);

                // --

                // ***
                // EAP Line
                // ***
                x = pnlBody.Width / 2;
                y = pnlBody.Height - 2;
                // --
                x1 = x;
                x2 = x;
                y1 = 0;
                y2 = y;
                e.Graphics.DrawLine(pen, x1, y1, x2, y2);
                // --
                x1 = x - 4;
                x2 = x + 4;
                y1 = 1;
                y2 = 1;
                e.Graphics.DrawLine(pen, x1, y1, x2, y2);

                // --

                // ***
                // Host Line
                // ***
                x = pnlBody.Width - 28;
                y = pnlBody.Height - 2;
                // --
                x1 = x;
                x2 = x;
                y1 = 0;
                y2 = y;
                e.Graphics.DrawLine(pen, x1, y1, x2, y2);                
                // --
                x1 = x - 4;
                x2 = x + 4;
                y1 = 1;
                y2 = 1;
                e.Graphics.DrawLine(pen, x1, y1, x2, y2);    
            
                // --

                endUpdate();
            }
            catch (Exception ex)
            {
                endUpdate();
                FMessageBox.showError("FFlowContainer", ex, null);
            }
            finally
            {
                if (pen != null)
                {
                    pen.Dispose();
                    pen = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void pnlBody_Resize(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                if (pnlBody.Width == m_bodyWidth)
                {
                    return;
                }

                // --

                beginUpdate();

                // --

                m_bodyWidth = pnlBody.Width;
                resizeAllFlowCtrl();

                // --

                endUpdate();
            }
            catch (Exception ex)
            {
                endUpdate();
                FMessageBox.showError("FFlowContainer", ex, null);
            }
            finally
            {
                
            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region pnlBody.ClientArea Control Event Handler

        private void ClientArea_ControlAdded(
            object sender, 
            ControlEventArgs e
            )
        {
            try
            {
                if (e.Control is FBaseFlowCtrl)
                {
                    ((FBaseFlowCtrl)e.Control).setParent(this);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FFlowContainer", ex, null);
            }
            finally
            {

            }   
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void ClientArea_ControlRemoved(
            object sender, 
            ControlEventArgs e
            )
        {
            try
            {
                if (e.Control is FBaseFlowCtrl)
                {
                    ((FBaseFlowCtrl)e.Control).setParent(null);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FFlowContainer", ex, null);
            }
            finally
            {

            }   
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdScenario Control Event Handler

        private void grdScenario_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                activateControl(this, grdScenario, grdScenario.Rows[0], false);
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

        private void grdScenario_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            UIElement element = null;
            UltraGridRow gridRow = null;

            try
            {
                element = grdScenario.DisplayLayout.UIElement.ElementFromPoint(e.Location);
                if (element == null)
                {
                    return;
                }

                gridRow = (UltraGridRow)element.GetContext(typeof(UltraGridRow));
                if (gridRow == null)
                {
                    return;
                }

                // --
                
                activateControl(this, grdScenario, gridRow, true);

                // --

                if (m_popupMenu != null && e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    m_popupMenu.ShowPopup();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FFlowContainer", ex, null);
            }
            finally
            {
                element = null;
                gridRow = null;
            }
        }

        #endregion                

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
