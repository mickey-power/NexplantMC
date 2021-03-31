/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FSequenceFlowContainer.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.28
--  Description     : FAMate Core FaUIs Sequence Flow Container Control
--  History         : Created by spike.lee at 2011.03.28
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
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FSequenceFlowContainer : UserControl
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FScenarioActivatedEventHandler ScenarioActivated = null;
        public event FSequenceFlowActivatedEventHandler SequenceFlowActivated = null;

        // --

        private bool m_disposed = false;
        // --
        private string m_key = "";  // Senarion Key
        private int m_width = 0;
        private PopupMenuTool m_popupMenu = null;
        // --
        private Infragistics.Win.Appearance m_activeRowAppearance = null;
        private Infragistics.Win.Appearance m_deactiveRowAppearance = null;
        private FGrid m_focusedGrid = null;        
        // --
        private List<FSequenceFlow> m_fSequenceFlowList = null;
        private Dictionary<string, UltraDataRow> m_dataRows = null;
        private Dictionary<string, UltraGridRow> m_gridRows = null;
        private FSequenceFlow m_fActiveSequenceFlow = null;        
        private FGrid m_fActiveGrid = null;
        private UltraGridRow m_activeGridRow = null;
        private UltraDataRow m_activeDataRow = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSequenceFlowContainer(
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
                    m_fActiveSequenceFlow = null;
                    m_fActiveGrid = null;
                    m_activeGridRow = null;
                    m_activeDataRow = null;
                    // --
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

        internal List<FSequenceFlow> fSequenceFlowList
        {
            get
            {
                try
                {
                    return m_fSequenceFlowList;
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

        internal Dictionary<string, UltraDataRow> dataRows
        {
            get
            {
                try
                {
                    return m_dataRows;
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

        internal Dictionary<string, UltraGridRow> gridRows
        {
            get
            {
                try
                {
                    return m_gridRows;
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

        internal Infragistics.Win.Appearance activeRowApperance
        {
            get
            {
                try
                {
                    return m_activeRowAppearance;
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

        internal Infragistics.Win.Appearance deactiveRowApperance
        {
            get
            {
                try
                {
                    return m_deactiveRowAppearance;
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

        public FSequenceFlow fActiveSequenceFlow
        {
            get
            {
                try
                {
                    return m_fActiveSequenceFlow;
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

        public FGrid fActiveGrid
        {
            get
            {
                try
                {
                    return m_fActiveGrid;
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

        public UltraGridRow activeGridRow
        {
            get
            {
                try
                {
                    return m_activeGridRow;
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

        public UltraDataRow activeDataRow
        {
            get
            {
                try
                {
                    return m_activeDataRow;
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

        public FSequenceFlowCollection fSequenceFlowCollection
        {
            get
            {
                try
                {
                    return new FSequenceFlowCollection(m_fSequenceFlowList);
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

        public FGrid fScenarioGrid
        {
            get
            {
                try
                {
                    return grdScenario;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {

                m_fSequenceFlowList = new List<FSequenceFlow>();
                m_dataRows = new Dictionary<string, UltraDataRow>();
                m_gridRows = new Dictionary<string, UltraGridRow>();
                // --
                m_activeRowAppearance = FGridCommon.getActiveAppearance();               
                // --
                m_deactiveRowAppearance = FGridCommon.getRowCellAppearance();
                m_deactiveRowAppearance.BackColor = Color.White;
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
                m_fSequenceFlowList = null;
                m_dataRows = null;
                m_gridRows = null;
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
                if (!pnlContainer.IsUpdating)
                {
                    pnlContainer.BeginUpdate();
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
                if (pnlContainer.IsUpdating)
                {
                    pnlContainer.EndUpdate();
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

        private void designGridOfScenario(
            )
        {
            UltraDataSource uds = null;

            try
            {
                //grdScenario.DisplayLayout.Override.HeaderAppearance = FGridCommon.getHeaderAppearance();
                //grdScenario.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                //grdScenario.DisplayLayout.Override.ActiveAppearancesEnabled = DefaultableBoolean.False;

                grdScenario.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = GradientStyle.None;
                grdScenario.DisplayLayout.Override.HeaderAppearance.FontData.Bold = DefaultableBoolean.True;
                grdScenario.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
                grdScenario.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                grdScenario.DisplayLayout.Override.ActiveAppearancesEnabled = DefaultableBoolean.False;
                grdScenario.DisplayLayout.Override.CellAppearance = this.deactiveRowApperance;
                grdScenario.DisplayLayout.Override.CellAppearance.TextVAlign = VAlign.Middle;
                grdScenario.DisplayLayout.Override.CellAppearance.TextTrimming = TextTrimming.EllipsisCharacter;
                // --
                grdScenario.DisplayLayout.Override.TipStyleHeader = TipStyle.Show;
                grdScenario.DisplayLayout.Override.TipStyleCell = TipStyle.Show;
                // --
                grdScenario.DisplayLayout.Bands[0].CardView = true;
                grdScenario.DisplayLayout.Bands[0].ColHeadersVisible = false;
                grdScenario.DisplayLayout.Bands[0].CardSettings.AutoFit = true;
                grdScenario.DisplayLayout.Bands[0].CardSettings.CardScrollbars = CardScrollbars.None;
                grdScenario.DisplayLayout.Bands[0].CardSettings.ShowCaption = false;    
            

                // --

                uds = grdScenario.dataSource;
                // --
                uds.Band.Columns.Add("Scenario");
                grdScenario.DisplayLayout.Override.CellAppearance.TextHAlign = HAlign.Center;
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

        private void resizeSequenceFlow(
            FSequenceFlow fSequenceFlow
            )
        {
            try
            {
                fSequenceFlow.Width = m_width - 30;
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

        private void resizeAllSequenceflow(
            )
        {
            try
            {
                beginUpdate();

                // --                                
                
                foreach (FSequenceFlow sf in m_fSequenceFlowList)
                {
                    resizeSequenceFlow(sf);
                }

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

        private void setActiveData(
            FGrid fGrid, 
            UltraGridRow gridRow
            )
        {
            try
            {
                m_fActiveSequenceFlow = null;
                m_fActiveGrid = fGrid;
                m_activeGridRow = gridRow;
                m_activeDataRow = gridRow == null ? null : fGrid.dataSource.Rows[gridRow.ListIndex];

                // --

                if (ScenarioActivated != null)
                {
                    ScenarioActivated(
                        this,
                        new FScenarioActivatedEventArgs(m_fActiveGrid, m_activeGridRow, m_activeDataRow)
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

        internal void setActiveData(
            FSequenceFlow fSequenceFlow,
            FGrid fGrid, 
            UltraGridRow gridRow
            )
        {
            try
            {
                m_fActiveSequenceFlow = fSequenceFlow;
                m_fActiveGrid = fGrid;
                m_activeGridRow = gridRow;
                m_activeDataRow = gridRow == null ? null : fGrid.dataSource.Rows[gridRow.ListIndex];

                // --

                if (SequenceFlowActivated != null)
                {
                    SequenceFlowActivated(
                        this,
                        new FSequenceFlowActivatedEventArgs(m_fActiveSequenceFlow, m_fActiveGrid, m_activeGridRow, m_activeDataRow)
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

        private void changeActiveRow(
            )
        {
            try
            {
                if (grdScenario.ActiveRow == null || this.activeGridRow == grdScenario.ActiveRow)
                {
                    return;
                }

                // --

                if (this.activeGridRow != null)
                {
                    this.activeGridRow.Appearance = this.deactiveRowApperance;
                    // --
                    if (this.fActiveGrid != grdScenario)
                    {
                        this.fActiveGrid.ActiveRow = null;
                    }
                }
                grdScenario.ActiveRow.Appearance = this.activeRowApperance;
                setActiveData(grdScenario, grdScenario.ActiveRow);
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

        public void activateScenario(
            )
        {
            try
            {
                if (grdScenario.Rows.Count == 0)
                {
                    return;
                }

                // --

                m_focusedGrid = grdScenario;
                m_focusedGrid.ActiveRow = grdScenario.Rows[0];
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

        public void activateSequenceFlow(
            FSequenceFlow fSequenceFlow
            )
        {
            try
            {
                fSequenceFlow.activateSequenceFlow();
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

        public UltraDataRow updateScenario(
            string key, 
            string data
            )
        {
            UltraDataRow dataRow = null;

            try
            {
                if (m_key != string.Empty && m_key != key)
                {
                    grdScenario.removeDataRow(m_key);
                    this.dataRows.Remove(m_key);
                    this.gridRows.Remove(m_key);
                }

                // --

                dataRow = grdScenario.appendDataRow(key, new object[] { data });
                m_dataRows.Add(key, dataRow);
                m_gridRows.Add(key, grdScenario.Rows.GetRowWithListIndex(dataRow.Index));
                // --
                return dataRow;
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

        public FSequenceFlow appendSequenceFlow(
            string key
            )
        {
            FSequenceFlow fNewSequenceFlow = null;
            UltraDataRow dataRow = null;

            try
            {
                beginUpdate();

                // --

                fNewSequenceFlow = new FSequenceFlow(this, key);
                fNewSequenceFlow.Name = key;
                fNewSequenceFlow.setFontName(this.Font.Name);
                // --
                resizeSequenceFlow(fNewSequenceFlow);
                pnlContainer.ClientArea.Controls.Add(fNewSequenceFlow);                                
                fNewSequenceFlow.Show();                
                pnlContainer.ClientArea.ScrollControlIntoView(fNewSequenceFlow);
                fNewSequenceFlow.setActiveEnabled();
                // --
                m_fSequenceFlowList.Add(fNewSequenceFlow);
                dataRow = fNewSequenceFlow.fSequenceGrid.getDataRow(key);
                this.dataRows.Add(key, dataRow);
                this.gridRows.Add(key, fNewSequenceFlow.fSequenceGrid.Rows.GetRowWithListIndex(dataRow.Index));                

                // --
                
                endUpdate();                

                // --

                return fNewSequenceFlow;
            }
            catch (Exception ex)
            {
                endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSequenceFlow insertBeforeSequenceFlow(
            string key,
            FSequenceFlow fRefSequenceFlow
            )
        {
            FSequenceFlow fNewSequenceFlow = null;
            UltraDataRow dataRow = null;

            try
            {
                beginUpdate();

                // --

                fNewSequenceFlow = new FSequenceFlow(this, key);
                fNewSequenceFlow.Name = key;
                fNewSequenceFlow.setFontName(this.Font.Name);
                // --
                resizeSequenceFlow(fNewSequenceFlow);
                pnlContainer.ClientArea.Controls.Add(fNewSequenceFlow);
                pnlContainer.ClientArea.Controls.SetChildIndex(fNewSequenceFlow, fRefSequenceFlow.index);                
                fNewSequenceFlow.Show();                
                pnlContainer.ClientArea.ScrollControlIntoView(fNewSequenceFlow);
                fNewSequenceFlow.setActiveEnabled();                
                // --
                m_fSequenceFlowList.Insert(fRefSequenceFlow.index, fNewSequenceFlow);
                dataRow = fNewSequenceFlow.fSequenceGrid.getDataRow(key);
                this.dataRows.Add(key, dataRow);
                this.gridRows.Add(key, fNewSequenceFlow.fSequenceGrid.Rows.GetRowWithListIndex(dataRow.Index));                

                // --

                endUpdate();

                // --

                return fNewSequenceFlow;
            }
            catch (Exception ex)
            {
                endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSequenceFlow insertAfterSequenceFlow(
            string key,
            FSequenceFlow fRefSequenceFlow
            )
        {
            FSequenceFlow fNewSequenceFlow = null;
            UltraDataRow dataRow = null;

            try
            {
                beginUpdate();

                // --

                fNewSequenceFlow = new FSequenceFlow(this, key);
                fNewSequenceFlow.Name = key;
                fNewSequenceFlow.setFontName(this.Font.Name);
                // --
                resizeSequenceFlow(fNewSequenceFlow);
                pnlContainer.ClientArea.Controls.Add(fNewSequenceFlow);
                pnlContainer.ClientArea.Controls.SetChildIndex(fNewSequenceFlow, fRefSequenceFlow.index + 1);
                fNewSequenceFlow.Show();                
                pnlContainer.ClientArea.ScrollControlIntoView(fNewSequenceFlow);
                fNewSequenceFlow.setActiveEnabled();
                // --
                m_fSequenceFlowList.Insert(fRefSequenceFlow.index + 1, fNewSequenceFlow);
                dataRow = fNewSequenceFlow.fSequenceGrid.getDataRow(key);
                this.dataRows.Add(key, dataRow);
                this.gridRows.Add(key, fNewSequenceFlow.fSequenceGrid.Rows.GetRowWithListIndex(dataRow.Index));                

                // --

                endUpdate();

                // --

                return fNewSequenceFlow;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeSequenceFlow(
            FSequenceFlow fSequenceFlow
            )
        {
            int index = 0;

            try
            {
                index = fSequenceFlow.index;
                // --
                pnlContainer.ClientArea.Controls.Remove(fSequenceFlow);
                m_fSequenceFlowList.Remove(fSequenceFlow);

                // --

                if (m_fSequenceFlowList.Count == 0)
                {
                    activateScenario();
                }
                else
                {
                    if (index < m_fSequenceFlowList.Count)
                    {
                        activateSequenceFlow(m_fSequenceFlowList[index]);
                    }
                    else
                    {
                        activateSequenceFlow(m_fSequenceFlowList[index - 1]);
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

        public void removeAllSequenceFlow(
            )
        {
            try
            {
                pnlContainer.ClientArea.Controls.Clear();
                m_fSequenceFlowList.Clear();

                // --

                activateScenario();
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

        public FSequenceFlow getSequenceFlow(
            string key
            )
        {
            try
            {
                if (!pnlContainer.ClientArea.Controls.ContainsKey(key))
                {
                    return null;
                }
                return (FSequenceFlow)pnlContainer.ClientArea.Controls[key];
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

        public UltraDataRow getDataRow(
            string key
            )
        {
            try
            {
                if (!this.dataRows.ContainsKey(key))
                {
                    return null;
                }
                return this.dataRows[key];
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

        public UltraGridRow getGridRow(
            string key
            )
        {
            try
            {
                if (!this.gridRows.ContainsKey(key))
                {
                    return null;
                }
                return this.gridRows[key];
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

        #region FSequenceFlowContainer Form Event Handler

        private void FSequenceFlowContainer_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                m_width = pnlContainer.Width;

                // --

                designGridOfScenario();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FSequenceFlowContainer", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region pnlContainer Control Event Handler

        private void pnlContainer_PaintClient(
            object sender,
            PaintEventArgs e
            )
        {
            int width = 0;

            try
            {
                if (!pnlContainer.IsHandleCreated)
                {
                    return;
                }

                // --

                width = pnlContainer.Width;
                if (m_width == width)
                {
                    return;
                }

                // --
                
                m_width = width;
                resizeAllSequenceflow();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FSequenceFlowContainer", ex, null);
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
                m_focusedGrid = (FGrid)sender;
                // --
                if (m_focusedGrid.ActiveRow == null && m_focusedGrid.Rows.Count > 0)
                {
                    m_focusedGrid.ActiveRow = m_focusedGrid.Rows[0];
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FSequenceFlowContainer", ex, null);
            }
            finally
            { 

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdScenario_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                if ((FGrid)sender != m_focusedGrid)
                {
                    ((FGrid)sender).ActiveRow = null;
                    return;
                }

                // --

                changeActiveRow();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FSequenceFlowContainer", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdScenario_Leave(
            object sender,
            EventArgs e
            )
        {
            try
            {
                m_focusedGrid = null;
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FSequenceFlowContainer", ex, null);
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
            UltraGridRow activeRow = null;

            try
            {
                if (e.Button != System.Windows.Forms.MouseButtons.Right || this.popupMenu == null)
                {
                    return;
                }

                // --

                element = grdScenario.DisplayLayout.UIElement.ElementFromPoint(e.Location);
                if (element == null)
                {
                    return;
                }

                activeRow = (UltraGridRow)element.GetContext(typeof(UltraGridRow));
                if (activeRow == null)
                {
                    return;
                }

                // --

                m_focusedGrid = grdScenario;
                m_focusedGrid.ActiveRow = activeRow;

                // --

                // ***
                // Poupup Menu 처리
                // ***
                this.popupMenu.ShowPopup(grdScenario.PointToScreen(e.Location), grdScenario);
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FSequenceFlowContainer", ex, null);
            }
            finally
            {
                element = null;
                activeRow = null;
            }
        }        

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
