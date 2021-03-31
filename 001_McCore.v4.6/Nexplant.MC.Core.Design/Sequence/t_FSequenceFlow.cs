/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FSequenceFlow.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.28
--  Description     : FAMate Core FaUIs Sequence Flow Control
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
using System.Drawing.Drawing2D;
using Nexplant.MC.Core.FaCommon;
using Infragistics.Win;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FSequenceFlow : UserControl
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSequenceFlowContainer m_sfcContainer = null;
        private string m_key = string.Empty;
        // --
        private int m_width = 0;
        private bool m_activeEnabled = false;
        private FGrid m_focusedGrid = null;
        // --
        private FSequenceFlowType m_sequenceFlowType = FSequenceFlowType.SecsMessageTransmitter;
        private bool m_useCondition = false;
        private bool m_usePrologue = false;
        private bool m_useEpilogue = false;
        private bool m_useNegation = false;
        private bool m_useBranch = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSequenceFlow(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSequenceFlow(
            FSequenceFlowContainer sfcContainer,
            string key
            )
            : this()
        {
            m_sfcContainer = sfcContainer;
            m_key = key;
            // --
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
                    // --
                    m_sfcContainer = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FSequenceFlowType sequenceFlowType
        {
            get
            {
                try
                {
                    return m_sequenceFlowType;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }                
                return FSequenceFlowType.SecsMessageTransmitter;
            }

            set
            {
                try
                {
                    if (m_sequenceFlowType == value)
                    {
                        return;
                    }
                    m_sequenceFlowType = value;
                    setSequenceFlowType();
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

        public bool useCondition
        {
            get
            {
                try
                {
                    return m_useCondition;
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
                    if (m_useCondition == value)
                    {
                        return;
                    }

                    // --

                    m_useCondition = value;
                    resizeClientArea();
                    paintClientArea();
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

        public bool usePrologue
        {
            get
            {
                try
                {
                    return m_usePrologue;
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
                    if (m_usePrologue == value)
                    {
                        return;
                    }

                    // --

                    m_usePrologue = value;
                    resizeClientArea();
                    paintClientArea();
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

        public bool useEpilogue
        {
            get
            {
                try
                {
                    return m_useEpilogue;
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
                    if (m_useEpilogue == value)
                    {
                        return;
                    }

                    // --

                    m_useEpilogue = value;
                    resizeClientArea();
                    paintClientArea();
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

        public bool useNegation
        {
            get
            {
                try
                {
                    return m_useNegation;
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
                    if (m_useNegation == value)
                    {
                        return;
                    }
                    
                    // --

                    m_useNegation = value;
                    resizeClientArea();
                    paintClientArea();
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

        public bool useBranch
        {
            get
            {
                try
                {
                    return m_useBranch;
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
                    if (m_useBranch == value)
                    {
                        return;
                    }

                    // --

                    m_useBranch = value;
                    resizeClientArea();
                    paintClientArea();
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

        public int index
        {
            get
            {
                try
                {
                    return m_sfcContainer.fSequenceFlowList.IndexOf(this);
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

        public FGrid fSequenceGrid
        {
            get
            {
                try
                {
                    return grdSequence;
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

        public FGrid fConditionGrid
        {
            get
            {
                try
                {
                    return grdCondition;
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

        public FGrid fPrologueGrid
        {
            get
            {
                try
                {
                    return grdPrologue;
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

        public FGrid fEpilogueGrid
        {
            get
            {
                try
                {
                    return grdEpilogue;
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

        public FGrid fNegationGrid
        {
            get
            {
                try
                {
                    return grdNegation;
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

        public FGrid fBranchGrid
        {
            get
            {
                try
                {
                    return grdBranch;
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
                this.HandleCreated += new EventHandler(FSequenceFlow_HandleCreated);
                this.HandleDestroyed += new EventHandler(FSequenceFlow_HandleDestroyed);
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
                this.HandleCreated -= new EventHandler(FSequenceFlow_HandleCreated);
                this.HandleDestroyed -= new EventHandler(FSequenceFlow_HandleDestroyed);
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

        private void paintClientArea(
            )
        {
            Graphics g = null;
            Pen pen = null;
            int x1 = 0;
            int x2 = 0;
            int y1 = 0;
            int y2 = 0;
            Color penColor;

            try
            {
                if (m_sequenceFlowType == FSequenceFlowType.SecsMessageTrigger)
                {
                    penColor = Color.Red;
                }
                else if (m_sequenceFlowType == FSequenceFlowType.SecsMessageTransmitter)
                {
                    penColor = Color.Green;
                }
                else if (m_sequenceFlowType == FSequenceFlowType.HostMessageTrigger)
                {
                    penColor = Color.Chocolate;
                }
                else
                {
                    penColor = Color.Blue;
                }

                // --

                g = this.CreateGraphics();

                // --

                x1 = this.Width / 2;                
                y1 = 0;
                x2 = x1;
                y2 = this.Height;
                // --
                pen = new Pen(penColor, 3);
                pen.StartCap = LineCap.SquareAnchor;
                g.DrawLine(pen, x1, y1, x2, y2 - 6);
                pen.Dispose();
                pen = null;
                // --
                pen = new Pen(penColor, 5);
                pen.EndCap = LineCap.ArrowAnchor;                
                g.DrawLine(pen, x2, y2 - 6, x2, y2);
                pen.Dispose();
                pen = null;                                                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (g != null)
                {
                    g.Dispose();
                    g = null;
                }
                if (pen != null)
                {
                    pen.Dispose();
                    pen = null;
                }               
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void resizeClientArea(
            )
        {
            int y = 0;
            int width = 0;
            int height = 0;
            int height2 = 0;

            try
            {
                grdCondition.Visible = m_useCondition;
                grdPrologue.Visible = m_usePrologue;
                grdEpilogue.Visible = m_useEpilogue;
                grdNegation.Visible = m_useNegation;
                grdBranch.Visible = m_useBranch;

                // --

                // ***
                // Control X, Width Set
                // ***
                width = this.Width / 2 - 10;
                // --
                grdSequence.Left = (this.Width - width) / 2;
                grdSequence.Width = width;
                // --
                grdPrologue.Width = width;
                grdEpilogue.Width = width;
                // --
                grdNegation.Left = (this.Width / 2) + 8;
                grdNegation.Width = width;
                // --
                grdBranch.Left = grdSequence.Left;
                grdBranch.Width = width;

                // --

                // ***
                // Control Y, Height Set
                // ***
                y = 6;
                height = grdSequence.Rows.CardAreaHeight + 2;
                grdSequence.Top = y;
                grdSequence.Height = height;
                // --
                if (m_usePrologue)
                {
                    y += (height + 4);
                    height = (grdPrologue.Rows.CardAreaHeight * grdPrologue.dataSource.Rows.Count) + grdPrologue.dataSource.Rows.Count + 1;
                    grdPrologue.Top = y;
                    grdPrologue.Height = height;
                }                               
                // --          
                if (m_useCondition)
                {
                    y += (height + 4);
                    height = (grdCondition.Rows.CardAreaHeight * grdCondition.dataSource.Rows.Count) + grdCondition.dataSource.Rows.Count + 1;
                    grdCondition.Top = y;
                    grdCondition.Height = height;                    
                }                
                // --
                if (m_useEpilogue)
                {
                    y += (height + 4);
                    height = (grdEpilogue.Rows.CardAreaHeight * grdEpilogue.dataSource.Rows.Count) + grdEpilogue.dataSource.Rows.Count + 1;
                    grdEpilogue.Top = y;
                    grdEpilogue.Height = height;
                }                
                // --
                if (m_useNegation)
                {
                    if (m_useEpilogue)
                    {
                        height2 = grdNegation.Rows.CardAreaHeight + 2;
                        grdNegation.Top = grdEpilogue.Top;
                        grdNegation.Height = height2;

                        if (height2 > height)
                        {
                            height = height2;
                        }
                    }
                    else
                    {
                        y += (height + 4);
                        height = grdNegation.Rows.CardAreaHeight + 2;
                        grdNegation.Top = y;
                        grdNegation.Height = height;
                    }
                }                
                // --
                if (m_useBranch)
                {
                    y += (height + 4);                    
                    height = grdBranch.Rows.CardAreaHeight + 2;
                    grdBranch.Top = y;
                    grdBranch.Height = height;
                }                
                // --
                y += (height + 12);
                this.Height = y;
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

        private void designGridOfBase(
            FGrid fGrid
            )
        {
            try
            {
                fGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = GradientStyle.None;
                fGrid.DisplayLayout.Override.HeaderAppearance.FontData.Bold = DefaultableBoolean.True;
                fGrid.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
                fGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                fGrid.DisplayLayout.Override.ActiveAppearancesEnabled = DefaultableBoolean.False;
                fGrid.DisplayLayout.Override.CellAppearance = m_sfcContainer.deactiveRowApperance;
                fGrid.DisplayLayout.Override.CellAppearance.TextVAlign = VAlign.Middle;                
                fGrid.DisplayLayout.Override.CellAppearance.TextTrimming = TextTrimming.EllipsisCharacter;
                // --
                fGrid.DisplayLayout.Override.TipStyleHeader = TipStyle.Show;
                fGrid.DisplayLayout.Override.TipStyleCell = TipStyle.Show;                
                // --
                fGrid.DisplayLayout.Bands[0].CardView = true;
                fGrid.DisplayLayout.Bands[0].ColHeadersVisible = false;
                fGrid.DisplayLayout.Bands[0].CardSettings.AutoFit = true;
                fGrid.DisplayLayout.Bands[0].CardSettings.CardScrollbars = CardScrollbars.None;
                fGrid.DisplayLayout.Bands[0].CardSettings.ShowCaption = false;                
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

        private void designGridOfSequence(
            )
        {
            UltraDataSource uds = null;

            try
            {
                designGridOfBase(grdSequence);                

                // --

                uds = grdSequence.dataSource;
                uds.Band.Columns.Add("General");

                // --

                grdSequence.DisplayLayout.Override.CellAppearance.TextHAlign = HAlign.Center;

                // --

                // ***
                // Default Empty Data Append
                // ***
                grdSequence.appendDataRow(m_key, new object[] { string.Empty });               
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

        private void designGridOfPrologue(
            )
        {
            UltraDataSource uds = null;

            try
            {
                designGridOfBase(grdPrologue);

                // --

                uds = grdPrologue.dataSource;
                uds.Band.Columns.Add("General");

                // --

                grdPrologue.DisplayLayout.Override.CellAppearance.TextHAlign = HAlign.Left;
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

        private void designGridOfCondition(
            )
        {
            UltraDataSource uds = null;

            try
            {
                designGridOfBase(grdCondition);

                // --

                uds = grdCondition.dataSource;
                uds.Band.Columns.Add("General");
                uds.Band.Columns.Add("Message");
                uds.Band.Columns.Add("Expression");
                
                // --                

                grdCondition.DisplayLayout.Override.CellAppearance.TextHAlign = HAlign.Center;
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

        private void designGridOfEpilogue(
            )
        {
            UltraDataSource uds = null;

            try
            {
                designGridOfBase(grdEpilogue);

                // --

                uds = grdEpilogue.dataSource;
                uds.Band.Columns.Add("General");

                // --

                grdEpilogue.DisplayLayout.Override.CellAppearance.TextHAlign = HAlign.Left;
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

        private void designGridOfNegation(
            )
        {
            UltraDataSource uds = null;

            try
            {
                designGridOfBase(grdNegation);

                // --

                uds = grdNegation.dataSource;
                uds.Band.Columns.Add("General");

                // --

                grdNegation.DisplayLayout.Override.CellAppearance.TextHAlign = HAlign.Left;
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

        private void designGridOfBranch(
            )
        {
            UltraDataSource uds = null;

            try
            {
                designGridOfBase(grdBranch);

                // --

                uds = grdBranch.dataSource;
                uds.Band.Columns.Add("General");

                // --

                grdBranch.DisplayLayout.Override.CellAppearance.TextHAlign = HAlign.Left;
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

        internal void setFontName(
            string fontName
            )
        {
            try
            {
                grdSequence.Font = new Font(fontName, grdSequence.Font.Size, grdSequence.Font.Style);
                grdCondition.Font = new Font(fontName, grdCondition.Font.Size, grdCondition.Font.Style);
                grdPrologue.Font = new Font(fontName, grdPrologue.Font.Size, grdPrologue.Font.Style);
                grdEpilogue.Font = new Font(fontName, grdEpilogue.Font.Size, grdEpilogue.Font.Style);
                grdNegation.Font = new Font(fontName, grdNegation.Font.Size, grdNegation.Font.Style);
                grdBranch.Font = new Font(fontName, grdBranch.Font.Size, grdBranch.Font.Style);
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

        internal void setActiveEnabled(
            )
        {
            try
            {
                m_activeEnabled = true;
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

        private void setSequenceFlowType(
            )
        {
            Color backColor;

            try
            {
                if (m_sequenceFlowType == FSequenceFlowType.SecsMessageTrigger)
                {
                    backColor = Color.Red;
                }
                else if (m_sequenceFlowType == FSequenceFlowType.SecsMessageTransmitter)
                {
                    backColor = Color.Green;
                }
                else if (m_sequenceFlowType == FSequenceFlowType.HostMessageTrigger)
                {
                    backColor = Color.Chocolate;
                }
                else
                {
                    backColor = Color.Blue;
                }

                // --

                grdSequence.DisplayLayout.Appearance.BorderColor = backColor;
                grdPrologue.DisplayLayout.Appearance.BorderColor = backColor;
                grdCondition.DisplayLayout.Appearance.BorderColor = backColor;
                grdEpilogue.DisplayLayout.Appearance.BorderColor = backColor;
                grdNegation.DisplayLayout.Appearance.BorderColor = backColor;
                grdBranch.DisplayLayout.Appearance.BorderColor = backColor;

                // --

                if (m_sequenceFlowType == FSequenceFlowType.SecsMessageTrigger || m_sequenceFlowType == FSequenceFlowType.HostMessageTrigger)
                {
                    grdCondition.DisplayLayout.Bands[0].Columns["Expression"].Hidden = false;
                }
                else
                {
                    grdCondition.DisplayLayout.Bands[0].Columns["Expression"].Hidden = true;
                }

                // --

                resizeClientArea();
                paintClientArea();
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
            FGrid fGrid
            )
        {
            try
            {
                if (
                    !m_activeEnabled ||
                    fGrid.ActiveRow == null ||                     
                    m_sfcContainer.activeGridRow == fGrid.ActiveRow
                    )
                {
                    return;
                }                

                // --

                if (m_sfcContainer.activeGridRow != null)
                {
                    m_sfcContainer.activeGridRow.Appearance = m_sfcContainer.deactiveRowApperance;
                    // --
                    if (m_sfcContainer.fActiveGrid != fGrid)
                    {
                        m_sfcContainer.fActiveGrid.ActiveRow = null;
                    }
                }
                fGrid.ActiveRow.Appearance = m_sfcContainer.activeRowApperance;
                m_sfcContainer.setActiveData(this, fGrid, fGrid.ActiveRow);
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

        private void activateDataRow(
            FGrid fGrid,
            UltraDataRow dataRow
            )
        {
            UltraGridRow gridRow = null;

            try
            {
                gridRow = fGrid.Rows.GetRowWithListIndex(dataRow.Index);
                if (gridRow == null)
                {
                    return;
                }

                // --

                m_focusedGrid = fGrid;
                m_focusedGrid.ActiveRow = gridRow;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                gridRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void activateSequenceFlow(
            )
        {
            try
            {
                activateDataRow(grdSequence, grdSequence.dataSource.Rows[0]);                
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

        public void activateSequence(
            UltraDataRow dataRow
            )
        {
            try
            {
                activateDataRow(grdSequence, dataRow);
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

        public void activateCondition(
            UltraDataRow dataRow
            )
        {
            try
            {
                activateDataRow(grdCondition, dataRow);
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

        public void activatePrologue(
            UltraDataRow dataRow
            )
        {
            try
            {
                activateDataRow(grdPrologue, dataRow);
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

        public void activateEpilogue(
            UltraDataRow dataRow
            )
        {
            try
            {
                activateDataRow(grdEpilogue, dataRow);
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

        public void activateNegation(
            UltraDataRow dataRow
            )
        {
            try
            {
                activateDataRow(grdNegation, dataRow);
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

        public void activateBranch(
            UltraDataRow dataRow
            )
        {
            try
            {
                activateDataRow(grdBranch, dataRow);
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

        public UltraDataRow updateSequence(
            string data
            )
        {
            try
            {
                return grdSequence.updateDataRow(m_key, new object[] { data });
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

        private UltraDataRow append(
            FGrid fGrid, 
            string key, 
            object[] data, 
            bool isActive
            )
        {
            UltraDataRow dataRow = null;

            try
            {
                dataRow = fGrid.appendDataRow(key, data);
                resizeClientArea();
                paintClientArea();               

                // --

                m_sfcContainer.dataRows.Add(key, dataRow);
                m_sfcContainer.gridRows.Add(key, fGrid.Rows.GetRowWithListIndex(dataRow.Index));

                // --

                if (isActive)
                {
                    m_focusedGrid = fGrid;
                    m_focusedGrid.ActiveRow = m_focusedGrid.Rows.GetRowWithListIndex(dataRow.Index);
                }

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

        private UltraDataRow insertBefore(
            FGrid fGrid,
            string key,
            object[] data,
            UltraDataRow refDataRow,
            bool isActive
            )
        {
            UltraDataRow dataRow = null;

            try
            {
                dataRow = fGrid.insertBeforeDataRow(refDataRow.Index, key, data);
                resizeClientArea();
                paintClientArea();

                // --

                m_sfcContainer.dataRows.Add(key, dataRow);
                m_sfcContainer.gridRows.Add(key, fGrid.Rows.GetRowWithListIndex(dataRow.Index));

                // --

                if (isActive)
                {
                    m_focusedGrid = fGrid;
                    m_focusedGrid.ActiveRow = m_focusedGrid.Rows.GetRowWithListIndex(dataRow.Index);
                }

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

        private UltraDataRow insertAfter(
            FGrid fGrid,
            string key,
            object[] data,
            UltraDataRow refDataRow,
            bool isActive
            )
        {
            UltraDataRow dataRow = null;

            try
            {
                dataRow = fGrid.insertBeforeDataRow(refDataRow.Index + 1, key, data);
                resizeClientArea();
                paintClientArea();

                // --

                m_sfcContainer.dataRows.Add(key, dataRow);
                m_sfcContainer.gridRows.Add(key, fGrid.Rows.GetRowWithListIndex(dataRow.Index));

                // --

                if (isActive)
                {
                    m_focusedGrid = fGrid;
                    m_focusedGrid.ActiveRow = m_focusedGrid.Rows.GetRowWithListIndex(dataRow.Index);
                }

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

        private void remove(
            FGrid fGrid,
            UltraDataRow dataRow
            )
        {
            string key = string.Empty;

            try
            {
                key = fGrid.getDataRowKey(dataRow.Index);                
                fGrid.removeDataRow(key);
                resizeClientArea();
                paintClientArea();

                // --

                m_sfcContainer.dataRows.Remove(key);
                m_sfcContainer.gridRows.Remove(key);

                // --

                if (m_sfcContainer.fActiveGrid == fGrid && fGrid.dataSource.Rows.Count == 0)
                {
                    m_focusedGrid = grdSequence;
                    grdSequence.ActiveRow = m_focusedGrid.Rows[0];
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

        private void removeAll(
            FGrid fGrid
            )
        {
            string key = string.Empty;

            try
            {
                for (int i = 0; i < fGrid.Rows.Count; i++)
                {
                    key = fGrid.getDataRowKey(i);
                    m_sfcContainer.dataRows.Remove(key);
                    m_sfcContainer.gridRows.Remove(key);
                }
                
                // --

                fGrid.removeAllDataRow();
                resizeClientArea();
                paintClientArea();

                // --

                if (m_sfcContainer.fActiveGrid == fGrid)
                {
                    m_focusedGrid = grdSequence;
                    grdSequence.ActiveRow = m_focusedGrid.Rows[0];
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

        private void addGridAllRowToSequenceFlow(
            FGrid fGrid
            )
        {
            string key = string.Empty;
            UltraDataRow dataRow = null;

            try
            {
                for (int i = 0; i < fGrid.Rows.Count; i++)
                {
                    key = fGrid.getDataRowKey(index);
                    if (!m_sfcContainer.dataRows.ContainsKey(key))
                    {
                        dataRow = fGrid.getDataRow(key);
                        m_sfcContainer.dataRows.Add(key, dataRow);
                        m_sfcContainer.gridRows.Add(key, fGrid.Rows.GetRowWithListIndex(dataRow.Index));
                    }                    
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void removeGridAllRowToSequenceFlow(
            FGrid fGrid
            )
        {
            string key = string.Empty;

            try
            {
                for (int i = 0; i < fGrid.Rows.Count; i++)
                {
                    key = fGrid.getDataRowKey(i);
                    if (m_sfcContainer.dataRows.ContainsKey(key))
                    {
                        m_sfcContainer.dataRows.Remove(key);
                        m_sfcContainer.gridRows.Remove(key);
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

        public UltraDataRow appendCondition(
            string key, 
            string general, 
            string message,
            string expression,
            bool isActive
            )
        {
            try
            {
                return append(grdCondition, key, new object[] {general, message, expression}, isActive);
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

        public UltraDataRow insertBeforeCondition(
            string key, 
            string general, 
            string message,
            string expression,
            UltraDataRow refDataRow, 
            bool isActive
            )
        {
            try
            {
                return insertBefore(grdCondition, key, new object[] {general, message, expression}, refDataRow, isActive);
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

        public UltraDataRow insertAfterCondition(
            string key,
            string general,
            string message,
            string expression,
            UltraDataRow refDataRow,
            bool isActive
            )
        {
            try
            {
                return insertAfter(grdCondition, key, new object[] {general, message, expression}, refDataRow, isActive);
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

        public void removeCondition(
            UltraDataRow dataRow
            )
        {
            try
            {
                remove(grdCondition, dataRow);
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

        public void removeAllCondition(
            )
        {
            try
            {
                removeAll(grdCondition);
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

        public UltraDataRow appendPrologue(
            string key,
            string general,
            bool isActive
            )
        {
            try
            {
                return append(grdPrologue, key, new object[] { general }, isActive);
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

        public UltraDataRow insertBeforePrologue(
            string key,
            string general,
            UltraDataRow refDataRow,
            bool isActive
            )
        {
            try
            {
                return insertBefore(grdPrologue, key, new object[] { general }, refDataRow, isActive);
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

        public UltraDataRow insertAfterPrologue(
            string key,
            string general,
            UltraDataRow refDataRow,
            bool isActive
            )
        {
            try
            {
                return insertAfter(grdPrologue, key, new object[] {general}, refDataRow, isActive);
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

        public void removePrologue(
            UltraDataRow dataRow
            )
        {
            try
            {
                remove(grdPrologue, dataRow);
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

        public void removeAllPrologue(
            )
        {
            try
            {
                removeAll(grdPrologue);
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

        public UltraDataRow appendEpilogue(
            string key,
            string general,
            bool isActive
            )
        {
            try
            {
                return append(grdEpilogue, key, new object[] { general }, isActive);
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

        public UltraDataRow insertBeforeEpilogue(
            string key,
            string general,
            UltraDataRow refDataRow,
            bool isActive
            )
        {
            try
            {
                return insertBefore(grdEpilogue, key, new object[] { general }, refDataRow, isActive);
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

        public UltraDataRow insertAfterEpilogue(
            string key,
            string general,
            UltraDataRow refDataRow,
            bool isActive
            )
        {
            try
            {
                return insertAfter(grdEpilogue, key, new object[] { general }, refDataRow, isActive);
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

        public void removeEpilogue(
            UltraDataRow dataRow
            )
        {
            try
            {
                remove(grdEpilogue, dataRow);
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

        public void removeAllEpilogue(
            )
        {
            try
            {
                removeAll(grdEpilogue);
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

        public UltraDataRow appendNegation(
            string key,
            string general,
            bool isActive
            )
        {
            try
            {
                return append(grdNegation, key, new object[] { general }, isActive);
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

        public UltraDataRow insertBeforeNegation(
            string key,
            string general,
            UltraDataRow refDataRow,
            bool isActive
            )
        {
            try
            {
                return insertBefore(grdNegation, key, new object[] { general }, refDataRow, isActive);
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

        public UltraDataRow insertAfterNegation(
            string key,
            string general,
            UltraDataRow refDataRow,
            bool isActive
            )
        {
            try
            {
                return insertAfter(grdNegation, key, new object[] { general }, refDataRow, isActive);
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

        public void removeNegation(
            UltraDataRow dataRow
            )
        {
            try
            {
                remove(grdNegation, dataRow);
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

        public void removeAllNegation(
            )
        {
            try
            {
                removeAll(grdNegation);
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

        public UltraDataRow appendBranch(
            string key,
            string general,
            bool isActive
            )
        {
            try
            {
                return append(grdBranch, key, new object[] { general }, isActive);
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

        public UltraDataRow insertBeforeBranch(
            string key,
            string general,
            UltraDataRow refDataRow,
            bool isActive
            )
        {
            try
            {
                return insertBefore(grdBranch, key, new object[] { general }, refDataRow, isActive);
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

        public UltraDataRow insertAfterBranch(
            string key,
            string general,
            UltraDataRow refDataRow,
            bool isActive
            )
        {
            try
            {
                return insertAfter(grdBranch, key, new object[] { general }, refDataRow, isActive);
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

        public void removeBranch(
            UltraDataRow dataRow
            )
        {
            try
            {
                remove(grdBranch, dataRow);
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

        public void removeAllBranch(
            )
        {
            try
            {
                removeAll(grdBranch);
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

        #region FSequenceFlow Control Event Handler

        private void FSequenceFlow_HandleCreated(
            object sender,
            EventArgs e
            )
        {
            try
            {
                grdSequence.Enter += new EventHandler(grdCommon_Enter);
                grdSequence.AfterRowActivate += new EventHandler(grdCommon_AfterRowActivate);
                grdSequence.MouseDown += new MouseEventHandler(grdCommon_MouseDown);
                // --
                grdPrologue.Enter += new EventHandler(grdCommon_Enter);
                grdPrologue.AfterRowActivate += new EventHandler(grdCommon_AfterRowActivate);
                grdPrologue.MouseDown += new MouseEventHandler(grdCommon_MouseDown);
                // --
                grdCondition.Enter += new EventHandler(grdCommon_Enter);
                grdCondition.AfterRowActivate += new EventHandler(grdCommon_AfterRowActivate);
                grdCondition.MouseDown += new MouseEventHandler(grdCommon_MouseDown);
                // --
                grdEpilogue.Enter += new EventHandler(grdCommon_Enter);
                grdEpilogue.AfterRowActivate += new EventHandler(grdCommon_AfterRowActivate);
                grdEpilogue.MouseDown += new MouseEventHandler(grdCommon_MouseDown);
                // --
                grdNegation.Enter += new EventHandler(grdCommon_Enter);
                grdNegation.AfterRowActivate += new EventHandler(grdCommon_AfterRowActivate);
                grdNegation.MouseDown += new MouseEventHandler(grdCommon_MouseDown);
                // --
                grdBranch.Enter += new EventHandler(grdCommon_Enter);                
                grdBranch.AfterRowActivate += new EventHandler(grdCommon_AfterRowActivate);
                grdBranch.MouseDown += new MouseEventHandler(grdCommon_MouseDown);
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FSequenceFlow", ex, null);
            }
            finally
            {

            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        private void FSequenceFlow_HandleDestroyed(
            object sender,
            EventArgs e
            )
        {
            try
            {
                grdSequence.Enter -= new EventHandler(grdCommon_Enter);                
                grdSequence.AfterRowActivate -= new EventHandler(grdCommon_AfterRowActivate);
                grdSequence.MouseDown -= new MouseEventHandler(grdCommon_MouseDown);
                // --
                grdPrologue.Enter -= new EventHandler(grdCommon_Enter);
                grdPrologue.AfterRowActivate -= new EventHandler(grdCommon_AfterRowActivate);
                grdPrologue.MouseDown -= new MouseEventHandler(grdCommon_MouseDown);
                // --
                grdCondition.Enter -= new EventHandler(grdCommon_Enter);
                grdCondition.AfterRowActivate -= new EventHandler(grdCommon_AfterRowActivate);
                grdCondition.MouseDown -= new MouseEventHandler(grdCommon_MouseDown);
                // --
                grdEpilogue.Enter -= new EventHandler(grdCommon_Enter);
                grdEpilogue.AfterRowActivate -= new EventHandler(grdCommon_AfterRowActivate);
                grdEpilogue.MouseDown -= new MouseEventHandler(grdCommon_MouseDown);
                // --
                grdNegation.Enter -= new EventHandler(grdCommon_Enter);
                grdNegation.AfterRowActivate -= new EventHandler(grdCommon_AfterRowActivate);
                grdNegation.MouseDown -= new MouseEventHandler(grdCommon_MouseDown);
                // --
                grdBranch.Enter -= new EventHandler(grdCommon_Enter);
                grdBranch.AfterRowActivate -= new EventHandler(grdCommon_AfterRowActivate);
                grdBranch.MouseDown -= new MouseEventHandler(grdCommon_MouseDown);
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FSequenceFlow", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FSequenceFlow_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                m_width = this.Width;

                // --

                designGridOfSequence();
                designGridOfPrologue();
                designGridOfCondition();
                designGridOfEpilogue();
                designGridOfNegation();
                designGridOfBranch();

                // --

                resizeClientArea();
                setSequenceFlowType();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FSequenceFlow", ex, null);
            }
            finally
            {

            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        private void FSequenceFlow_Paint(
            object sender, 
            PaintEventArgs e
            )
        {
            int width = 0;

            try
            {
                if (!this.IsHandleCreated)
                {
                    return;
                }

                // --

                paintClientArea();

                // --

                width = this.Width;
                if (m_width == width)
                {
                    return;
                }

                // --

                resizeClientArea();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FSequenceFlow", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FSequenceFlow_ParentChanged(
            object sender,
            EventArgs e
            )
        {
            string key = string.Empty;

            try
            {
                if (m_sfcContainer == null)
                {
                    return;
                }

                // --

                if (this.Parent == null)
                {
                    // ***
                    // SequenceFlow Remove
                    // ***
                    removeGridAllRowToSequenceFlow(fSequenceGrid);
                    removeGridAllRowToSequenceFlow(fConditionGrid);
                    removeGridAllRowToSequenceFlow(fPrologueGrid);
                    removeGridAllRowToSequenceFlow(fEpilogueGrid);
                    removeGridAllRowToSequenceFlow(fNegationGrid);
                    removeGridAllRowToSequenceFlow(fBranchGrid);
                }
                else
                {
                    // ***
                    // SequenceFlow Add
                    // ***
                    addGridAllRowToSequenceFlow(fSequenceGrid);
                    addGridAllRowToSequenceFlow(fConditionGrid);
                    addGridAllRowToSequenceFlow(fPrologueGrid);
                    addGridAllRowToSequenceFlow(fEpilogueGrid);
                    addGridAllRowToSequenceFlow(fNegationGrid);
                    addGridAllRowToSequenceFlow(fBranchGrid);                    
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FSequenceFlow", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Grid Control Common Event Handler

        private void grdCommon_Enter(
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
                FMessageBox.showError("FSequenceFlow", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdCommon_AfterRowActivate(
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
                changeActiveRow((FGrid)sender);    
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FSequenceFlow", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdCommon_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            FGrid fGrid = null;
            UIElement element = null;
            UltraGridRow activeRow = null;

            try
            {
                if (
                    e.Button != System.Windows.Forms.MouseButtons.Right ||
                    m_sfcContainer == null ||
                    m_sfcContainer.popupMenu == null
                    )
                {
                    return;
                }

                // --

                fGrid = (FGrid)sender;
                element = fGrid.DisplayLayout.UIElement.ElementFromPoint(e.Location);
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

                m_focusedGrid = fGrid;
                m_focusedGrid.ActiveRow = activeRow;                

                // --

                // ***
                // Poupup Menu 처리
                // ***
                m_sfcContainer.popupMenu.ShowPopup(fGrid.PointToScreen(e.Location), fGrid);
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FSequenceFlow", ex, null);
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
