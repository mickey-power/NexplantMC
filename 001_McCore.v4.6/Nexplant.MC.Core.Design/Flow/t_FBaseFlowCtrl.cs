/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FBaseFlowCtrl.cs
--  Creator         : spike.lee
--  Create Date     : 2011.06.02
--  Description     : FAMate Core FaUIs Base Flow Control
--  History         : Created by spike.lee at 2011.06.02
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
using Infragistics.Win;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FBaseFlowCtrl : UserControl
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_text = "BaseFlowCtrl";
        private FFlowContainer m_fParent = null;
        private Color m_fontColor = Color.Black;
        private bool m_fontBold = false;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FBaseFlowCtrl(
            )
        {
            InitializeComponent();
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FBaseFlowCtrl(
            string text
            )
            : this()
        {
            m_text = text;
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void myDispose(
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
                    m_text = value;
                    grdContents.Rows[0].Cells[0].Value = m_text;
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

        public Image image
        {
            get
            {
                try
                {
                    return (Image)grdContents.Rows[0].Cells[0].Appearance.Image;
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

            set
            {
                try
                {
                    grdContents.Rows[0].Cells[0].Appearance.Image = value;
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

        public FFlowContainer fParent
        {
            get
            {
                try
                {
                    return m_fParent;
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
                    if (grdContents.Rows.Count > 0 && grdContents.Rows[0].Cells.Count > 0)
                    {
                        grdContents.Rows[0].Cells[0].Appearance.ForeColor = m_fontColor;
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
                    if (grdContents.Rows.Count > 0 && grdContents.Rows[0].Cells.Count > 0)
                    {
                        grdContents.Rows[0].Cells[0].Appearance.FontData.Bold = (m_fontBold ? DefaultableBoolean.True : DefaultableBoolean.False);
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

        public bool isActive
        {
            get
            {
                try
                {
                    if (m_fParent != null && m_fParent.fActiveFlowCtrl == this)
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

        internal UltraGrid grid
        {
            get
            {
                try
                {
                    return grdContents;
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

        public FIFlowCtrl fPreviousSibling
        {
            get
            {
                try
                {
                    if (m_fParent == null)
                    {
                        return null;
                    }

                    return (FIFlowCtrl)m_fParent.clientArea.GetNextControl(this, false);
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

        public FIFlowCtrl fNextSibling
        {
            get
            {
                try
                {
                    if (m_fParent == null)
                    {
                        return null;
                    }

                    return (FIFlowCtrl)m_fParent.clientArea.GetNextControl(this, true);
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

        private void designGridOfContents(
            )
        {
            UltraDataSource uds = null;

            try
            {
                grdContents.DisplayLayout.BorderStyle = UIElementBorderStyle.None;                
                grdContents.DisplayLayout.Bands[0].ColHeadersVisible = false;
                grdContents.DisplayLayout.Override.ActiveAppearancesEnabled = DefaultableBoolean.False;
                grdContents.DisplayLayout.Override.MinRowHeight = 19;
                grdContents.DisplayLayout.Override.DefaultRowHeight = 19;
                grdContents.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
                grdContents.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.None;
                // --
                grdContents.DisplayLayout.Override.CellAppearance = FGridCommon.getRowCellAppearance();
                grdContents.DisplayLayout.Override.CellAppearance.TextVAlign = VAlign.Middle;
                grdContents.DisplayLayout.Override.CellAppearance.TextTrimming = TextTrimming.EllipsisCharacter;
                // --
                grdContents.valueCopyOfClickedCell = false;

                // --

                uds = grdContents.dataSource;
                // --
                uds.Band.Columns.Add("Contents");
                grdContents.DisplayLayout.Override.CellAppearance.TextHAlign = HAlign.Left;

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

        internal void setParent(
            FFlowContainer fParent
            )
        {
            try
            {
                m_fParent = fParent;
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

        internal void activate(
            bool isOption
            )
        {
            try
            {
                if (m_fParent != null)
                {
                    m_fParent.activateControl(this, grdContents, grdContents.Rows[0], isOption);
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

        #region FBaseFlowCtrl Control Event Handler

        private void FBaseFlowCtrl_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                designGridOfContents();

                grdContents.ActiveRow = null;
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseFlowCtrl", ex, null);
            }
            finally
            {

            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

        #region pnlMain Control Event Handler

        private void pnlMain_PaintClient(
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
                if (!this.IsHandleCreated)
                {
                    return;
                }

                // --

                pen = new Pen(Color.Gray, 2);

                // ***
                // EQ Line
                // ***
                x = 28;
                y = pnlMain.Height;
                // --
                x1 = x;
                x2 = x;
                y1 = 0;
                y2 = y;
                e.Graphics.DrawLine(pen, x1, y1, x2, y2);

                // ***
                // EAP Line
                // ***
                x = pnlMain.Width / 2 + 9;
                y = pnlMain.Height;
                // --
                x1 = x;
                x2 = x;
                y1 = 0;
                y2 = y;
                e.Graphics.DrawLine(pen, x1, y1, x2, y2);

                // ***
                // Host Line
                // ***
                x = pnlMain.Width - 10;
                y = pnlMain.Height;
                // --
                x1 = x;
                x2 = x;
                y1 = 0;
                y2 = y;
                e.Graphics.DrawLine(pen, x1, y1, x2, y2);
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseFlowCtrl", ex, null);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdContents Control Evnet Handler

        private void grdContents_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                activate(false);
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

        private void grdContents_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            UIElement element = null;
            UltraGridRow gridRow = null;

            try
            {
                element = grdContents.DisplayLayout.UIElement.ElementFromPoint(e.Location);
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

                activate(true);

                // --

                if (m_fParent.popupMenu != null && e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    if (!this.Focused)
                    {
                        this.Focus();
                    }
                    m_fParent.popupMenu.ShowPopup();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseFlowCtrl", ex, null);
            }
            finally
            {
                element = null;
                gridRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdContents_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                this.OnKeyDown(e);
                if (m_fParent != null)
                {
                    m_fParent.onKeyDown(e);   
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseFlowCtrl", ex, null);
            }
            finally
            {
                
            }
        }

        #endregion                

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
