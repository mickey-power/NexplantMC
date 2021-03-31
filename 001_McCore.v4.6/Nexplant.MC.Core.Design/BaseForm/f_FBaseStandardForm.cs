/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FBaseStandardForm.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.14
--  Description     : FAMate Core FaUIs Base Standard Form Class
--  History         : Created by spike.lee at 2011.01.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FBaseStandardForm : Nexplant.MC.Core.FaUIs.FBaseForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private bool m_actived = false;
        private FormWindowState m_winState = FormWindowState.Normal;
        private bool m_isMoveCapture = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FBaseStandardForm(
            )
        {
            InitializeComponent();
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
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        protected FormWindowState winState
        {
            get
            {
                try
                {
                    return m_winState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FormWindowState.Normal;
            }

            set
            {
                try
                {
                    m_winState = value;
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

        public new bool ControlBox
        {
            get
            {
                try
                {
                    return base.ControlBox;
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
                    base.ControlBox = value;
                    refreshTitleButton();
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

        public new bool MinimizeBox
        {
            get
            {
                try
                {
                    return base.MinimizeBox;
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
                    base.MinimizeBox = value;
                    refreshTitleButton();
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

        public new bool MaximizeBox
        {
            get
            {
                try
                {
                    return base.MaximizeBox;
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
                    base.MaximizeBox = value;
                    refreshTitleButton();
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
        
        [LocalizableAttribute(true)]
        public new Icon Icon
        {
            get
            {
                try
                {
                    return base.Icon;
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
                    base.Icon = value;
                    picTitleIcon.Image = value.ToBitmap();
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

        public new bool ShowIcon
        {
            get
            {
                try
                {
                    return base.ShowIcon;
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
                    base.ShowIcon = value;
                    refreshTitleButton();
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

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(
            ref Message m
            )
        {            
            // --

            // ***
            // Form 선택 시, Form이 Active되도록 한다. (Form의 Enter Event가 발생되도록 한다.)
            // ***
            if (!this.DesignMode)
            {
                if (m.Msg == (int)FNativeAPIs.FWinMsgs.WM_PARENTNOTIFY)
                {
                    FNativeAPIs.ReleaseCapture();
                    FNativeAPIs.SendMessage(this.Handle, FNativeAPIs.FWinMsgs.WM_NCLBUTTONDOWN, FNativeAPIs.FNCHITTEST.HTCAPTION, 0);
                    FNativeAPIs.SendMessage(this.Handle, FNativeAPIs.FWinMsgs.WM_NCLBUTTONUP, FNativeAPIs.FNCHITTEST.HTCAPTION, 0);                
                }
                else if (m.Msg == (int)FNativeAPIs.FWinMsgs.WM_NCHITTEST)
                {
                    if (
                        base.FormBorderStyle == System.Windows.Forms.FormBorderStyle.Fixed3D ||
                        base.FormBorderStyle == System.Windows.Forms.FormBorderStyle.FixedDialog ||
                        base.FormBorderStyle == System.Windows.Forms.FormBorderStyle.FixedSingle ||
                        base.FormBorderStyle == System.Windows.Forms.FormBorderStyle.FixedToolWindow
                        )
                    {
                        return;
                    }
                }                
            }                        

            base.WndProc(ref m);
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void disalbeOriginalTitle(
            )
        {
            int capHeight = 0;
            uint ret = 0;

            try
            {
                if (!this.DesignMode)
                {
                    // ***
                    // Base Title Bar (Caption) Width Get
                    // ***
                    capHeight = FNativeAPIs.GetSystemMetrics((int)FNativeAPIs.FSysMetrics.SM_CYCAPTION);

                    // --

                    // ***
                    // Form Caption (Title Bar) Disable
                    // ***
                    ret = (uint)FNativeAPIs.GetWindowLong(this.Handle, -16);                    
                    ret &= 0xFF3FFFFF;                    
                    // --                    
                    ret |= (uint)FNativeAPIs.FWinStyles.WS_BORDER;
                    // ret |= (uint)FNativeAPIs.FWinStyles.WS_THICKFRAME;
                    FNativeAPIs.SetWindowLong(this.Handle, -16, (int)ret);
                    // --
                    this.Height -= capHeight;                    
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

        private void setTitleButton(
            PictureBox buttion,
            bool visible,
            bool enabled,
            Bitmap image
            )
        {
            try
            {
                buttion.Visible = visible;
                buttion.Enabled = enabled;
                buttion.Image = image;
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

        protected virtual void refreshTitleButton(
            )
        {
            try
            {
                if (!base.ControlBox || !base.ShowIcon)
                {
                    picTitleIcon.Visible = false;
                }
                else
                {
                    picTitleIcon.Visible = true;
                }

                // --

                if (base.ControlBox)
                {
                    if (base.MinimizeBox && base.MaximizeBox)
                    {
                        setTitleButton(picMinimize, true, true, Properties.Resources.UIForm_TitleMinimize);
                        setTitleButton(
                            picMaximize, 
                            true, 
                            true, 
                            m_winState == FormWindowState.Maximized ?  Properties.Resources.UIForm_TitleRestore : Properties.Resources.UIForm_TitleMaximize
                            );
                    }
                    else if (base.MinimizeBox)
                    {
                        setTitleButton(picMinimize, true, true, Properties.Resources.UIForm_TitleMinimize);
                        setTitleButton(
                            picMaximize,
                            true,
                            false,
                            m_winState == FormWindowState.Maximized ? Properties.Resources.UIForm_TitleRestoreDisabled : Properties.Resources.UIForm_TitleMaximizeDisabled
                            );                        
                    }
                    else if (base.MaximizeBox)
                    {
                        setTitleButton(picMinimize, true, false, Properties.Resources.UIForm_TitleMinimizeDisabled);
                        setTitleButton(
                            picMaximize,
                            true,
                            true,
                            m_winState == FormWindowState.Maximized ? Properties.Resources.UIForm_TitleRestore : Properties.Resources.UIForm_TitleMaximize
                            );                        
                    }
                    else
                    {
                        setTitleButton(picMinimize, false, false, Properties.Resources.UIForm_TitleMinimizeDisabled);
                        setTitleButton(
                            picMaximize,
                            false,
                            false,
                            m_winState == FormWindowState.Maximized ? Properties.Resources.UIForm_TitleRestoreDisabled : Properties.Resources.UIForm_TitleMaximizeDisabled
                            );                           
                    }
                    // --
                    setTitleButton(picClose, true, true, Properties.Resources.UIForm_TitleClose);
                }
                else
                {
                    setTitleButton(picMinimize, false, false, Properties.Resources.UIForm_TitleMinimizeDisabled);
                    setTitleButton(
                            picMaximize,
                            false,
                            false,
                            m_winState == FormWindowState.Maximized ? Properties.Resources.UIForm_TitleRestoreDisabled : Properties.Resources.UIForm_TitleMaximizeDisabled
                            );  
                    setTitleButton(picClose, false, false, Properties.Resources.UIForm_TitleCloseDisabled);
                }

                // --

                paintTitleArea();
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

        private void paintTitleArea(
            )
        {
            Graphics g = null;
            Rectangle rect;
            Brush brush = null;
            Pen pen = null;
            Font font = null;
            StringFormat stringFormat = null;

            try
            {
                this.pnlTitle.SuspendLayout();
                
                // --

                if (!this.Visible || m_winState == FormWindowState.Minimized)
                {
                    return;
                }

                // --
                
                rect = this.pnlTitle.ClientRectangle;
                if (rect.Width <= 0)
                {
                    return;
                }

                // --

                g = this.pnlTitle.CreateGraphics();

                // --

                using (BufferedGraphics bGraphic = BufferedGraphicsManager.Current.Allocate(g, rect))
                {
                    bGraphic.Graphics.Clear(pnlTitle.BackColor);
                    bGraphic.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    bGraphic.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    bGraphic.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);

                    // --

                    // ***
                    // Background paint
                    // ***            
                    if (m_actived)
                    {
                        brush = new LinearGradientBrush(
                            rect,
                            Color.LightSteelBlue,
                            Color.Lavender,
                            LinearGradientMode.Vertical
                            );
                    }
                    else
                    {
                        brush = new LinearGradientBrush(
                            rect,
                            Color.Lavender,
                            Color.Gainsboro,
                            LinearGradientMode.Vertical
                            );
                    }
                    bGraphic.Graphics.FillRectangle(brush, rect);
                    // --
                    brush.Dispose();
                    brush = null;

                    // --

                    // ***
                    // Caption (Text) write
                    // ***
                    if (this.Text != string.Empty)
                    {
                        if (m_actived)
                        {
                            brush = new SolidBrush(Color.Black);
                        }
                        else
                        {
                            brush = new SolidBrush(Color.Gray);
                        }

                        font = new Font(this.Font.Name, 9, FontStyle.Regular);
                        stringFormat = new StringFormat();
                        stringFormat.Trimming = StringTrimming.EllipsisCharacter;
                        if (!base.ControlBox || !base.ShowIcon)
                        {
                            bGraphic.Graphics.DrawString(this.Text, font, brush, new Rectangle(4, 7, picMinimize.Left - 26, font.Height), stringFormat);
                        }
                        else
                        {
                            bGraphic.Graphics.DrawString(this.Text, font, brush, new Rectangle(24, 7, picMinimize.Left - 26, font.Height), stringFormat);
                        }

                        font.Dispose();
                        font = null;
                        brush.Dispose();
                        brush = null;
                        stringFormat.Dispose();
                        stringFormat = null;
                    }

                    // --

                    // ***
                    // Frame draw
                    // ***                                
                    pen = new Pen(Color.LightSteelBlue, 4);
                    bGraphic.Graphics.DrawLine(pen, rect.Left, rect.Top, rect.Right, rect.Top);
                    bGraphic.Graphics.DrawLine(pen, rect.Left, rect.Top, rect.Left, rect.Bottom);
                    bGraphic.Graphics.DrawLine(pen, rect.Right, rect.Top, rect.Right, rect.Bottom);
                    pen.Dispose();
                    pen = null;

                    // --

                    bGraphic.Render(g);

                    // --

                    g.Dispose();
                    g = null;
                }

                // --

                g = this.picTitleIcon.CreateGraphics();
                rect = this.picTitleIcon.ClientRectangle;
                // --
                using (BufferedGraphics bGraphic = BufferedGraphicsManager.Current.Allocate(g, rect))
                {
                    bGraphic.Graphics.Clear(picTitleIcon.BackColor);
                    bGraphic.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    bGraphic.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    bGraphic.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);

                    // --

                    if (m_actived)
                    {
                        brush = new LinearGradientBrush(rect, Color.LightSteelBlue, Color.Lavender, LinearGradientMode.Vertical);
                    }
                    else
                    {
                        brush = new LinearGradientBrush(rect, Color.Lavender, Color.Gainsboro, LinearGradientMode.Vertical);
                    }
                    bGraphic.Graphics.FillRectangle(brush, rect);
                    brush.Dispose();
                    brush = null;

                    // --

                    bGraphic.Graphics.DrawImage(this.Icon.ToBitmap(), rect);    

                    // --

                    bGraphic.Render(g);

                    // --

                    g.Dispose();
                    g = null;
                }                           
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

                if (brush != null)
                {
                    brush.Dispose();
                    brush = null;
                }

                if (pen != null)
                {
                    pen.Dispose();
                    pen = null;
                }

                if (font != null)
                {
                    font.Dispose();
                    font = null;
                }

                if (stringFormat != null)
                {
                    stringFormat.Dispose();
                    stringFormat = null;
                }

                this.pnlTitle.ResumeLayout();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void paintTitleArea_back(
            )
        {
            Graphics g = null;
            Rectangle rect;
            Brush brush = null;
            Pen pen = null;
            Font font = null;
            StringFormat stringFormat = null;

            try
            {
                this.pnlTitle.SuspendLayout();

                // --

                if (!this.Visible || m_winState == FormWindowState.Minimized)
                {
                    return;
                }

                // --

                g = this.pnlTitle.CreateGraphics();

                // --

                rect = this.pnlTitle.ClientRectangle;
                if (rect.Width <= 0)
                {
                    return;
                }

                // --

                // ***
                // Background paint
                // ***            
                if (m_actived)
                {
                    brush = new LinearGradientBrush(
                        rect,
                        Color.LightSteelBlue,
                        Color.Lavender,
                        LinearGradientMode.Vertical
                        );
                }
                else
                {
                    brush = new LinearGradientBrush(
                        rect,
                        Color.Lavender,
                        Color.Gainsboro,
                        LinearGradientMode.Vertical
                        );
                }
                g.FillRectangle(brush, rect);

                brush.Dispose();
                brush = null;

                // --

                // ***
                // Caption (Text) write
                // ***
                if (this.Text != string.Empty)
                {
                    if (m_actived)
                    {
                        brush = new SolidBrush(Color.Black);
                    }
                    else
                    {
                        brush = new SolidBrush(Color.Gray);
                    }

                    font = new Font(this.Font.Name, 9, FontStyle.Regular);
                    stringFormat = new StringFormat();
                    stringFormat.Trimming = StringTrimming.EllipsisCharacter;
                    if (!base.ControlBox || !base.ShowIcon)
                    {
                        g.DrawString(this.Text, font, brush, new Rectangle(4, 7, picMinimize.Left - 26, font.Height), stringFormat);
                    }
                    else
                    {
                        g.DrawString(this.Text, font, brush, new Rectangle(24, 7, picMinimize.Left - 26, font.Height), stringFormat);
                    }

                    font.Dispose();
                    font = null;
                    brush.Dispose();
                    brush = null;
                    stringFormat.Dispose();
                    stringFormat = null;
                }

                // --

                // ***
                // Frame draw
                // ***                
                // pen = new Pen(Color.White, 4);
                pen = new Pen(Color.LightSteelBlue, 4);
                g.DrawLine(pen, rect.Left, rect.Top, rect.Right, rect.Top);
                g.DrawLine(pen, rect.Left, rect.Top, rect.Left, rect.Bottom);
                g.DrawLine(pen, rect.Right, rect.Top, rect.Right, rect.Bottom);
                pen.Dispose();
                pen = null;

                // --

                g = this.picTitleIcon.CreateGraphics();
                rect = this.picTitleIcon.ClientRectangle;

                if (m_actived)
                {
                    brush = new LinearGradientBrush(rect, Color.LightSteelBlue, Color.Lavender, LinearGradientMode.Vertical);
                }
                else
                {
                    brush = new LinearGradientBrush(rect, Color.Lavender, Color.Gainsboro, LinearGradientMode.Vertical);
                }
                g.FillRectangle(brush, rect);
                brush.Dispose();
                brush = null;

                // --

                g.DrawImage(this.Icon.ToBitmap(), rect);
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

                if (brush != null)
                {
                    brush.Dispose();
                    brush = null;
                }

                if (pen != null)
                {
                    pen.Dispose();
                    pen = null;
                }

                if (font != null)
                {
                    font.Dispose();
                    font = null;
                }

                if (stringFormat != null)
                {
                    stringFormat.Dispose();
                    stringFormat = null;
                }

                this.pnlTitle.ResumeLayout();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void paintClientArea(
            )
        {
            Graphics g = null;
            Rectangle rect;
            Brush brush = null;
            Pen pen = null;

            try
            {
                this.pnlClient.SuspendLayout();                

                // --

                if (!this.Visible || m_winState == FormWindowState.Minimized)
                {
                    return;
                }

                // --
                
                rect = this.pnlClient.ClientRectangle;
                if (rect.Width <= 0)
                {
                    return;
                }

                // --

                g = this.pnlClient.CreateGraphics();

                // --

                using (BufferedGraphics bGraphic = BufferedGraphicsManager.Current.Allocate(g, rect))
                {
                    bGraphic.Graphics.Clear(base.BackColor);
                    bGraphic.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    bGraphic.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    bGraphic.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);

                    // ---

                    // ***
                    // Frame draw
                    // ***
                    pen = new Pen(Color.LightSteelBlue, 4);
                    bGraphic.Graphics.DrawRectangle(pen, rect);                    
                    pen.Dispose();
                    pen = null;

                    // --

                    bGraphic.Render(g);

                    // --

                    g.Dispose();
                    g = null;
                }
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

                if (brush != null)
                {
                    brush.Dispose();
                    brush = null;
                }

                if (pen != null)
                {
                    pen.Dispose();
                    pen = null;
                }

                this.pnlClient.ResumeLayout();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void paintClientArea_back(
            )
        {
            Graphics g = null;
            Rectangle rect;
            Brush brush = null;
            Pen pen = null;

            try
            {
                this.pnlClient.SuspendLayout();

                // --

                if (!this.Visible || m_winState == FormWindowState.Minimized)
                {
                    return;
                }

                // --

                g = this.pnlClient.CreateGraphics();

                // --

                rect = this.pnlClient.ClientRectangle;
                if (rect.Width <= 0)
                {
                    return;
                }

                // --

                // ***
                // Clear
                // ***
                brush = new SolidBrush(base.BackColor);
                g.FillRectangle(brush, rect);
                brush.Dispose();
                brush = null;

                // ---

                // ***
                // Frame draw
                // ***
                // pen = new Pen(Color.White, 4);
                pen = new Pen(Color.LightSteelBlue, 4);
                g.DrawRectangle(pen, rect);
                g.DrawRectangle(pen, rect);
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

                if (brush != null)
                {
                    brush.Dispose();
                    brush = null;
                }

                if (pen != null)
                {
                    pen.Dispose();
                    pen = null;
                }

                this.pnlClient.ResumeLayout();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void changeWindowState(
            FormWindowState state
            )
        {
            try
            {
                if (!this.Visible || m_winState == state)
                {
                    return;
                }

                // --

                m_winState = state;
                this.WindowState = state;
                // --
                refreshTitleButton();
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

        #region FBaseStandardForm Form Event Handler

        private void FBaseStandardForm_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {   
                disalbeOriginalTitle();
                refreshTitleButton();               
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FBaseStandardForm_Activated(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                if (!m_actived)
                {
                    m_actived = true;
                    paintTitleArea();
                }                
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FBaseStandardForm_Deactivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                if (m_actived)
                {
                    m_actived = false;
                    paintTitleArea();
                }                
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FBaseStandardForm_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                if (!m_actived)
                {
                    m_actived = true;
                    paintTitleArea();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FBaseStandardForm_Leave(object sender, EventArgs e)
        {
            try
            {
                if (m_actived)
                {
                    m_actived = false;
                    paintTitleArea();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FBaseStandardForm_TextChanged(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                paintTitleArea();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region pnlTitle Control Event Handler

        private void pnlTitle_Paint(
            object sender, 
            PaintEventArgs e
            )
        {
            try
            {
                
                paintTitleArea();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void pnlTitle_Resize(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                paintTitleArea();
                changeWindowState(this.WindowState);                
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void pnlTitle_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            try
            {
                if (m_winState == FormWindowState.Normal && e.Button == MouseButtons.Left)
                {
                    m_isMoveCapture = false;                    
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void pnlTitle_MouseMove(
            object sender, 
            MouseEventArgs e
            )
        {
            try
            {
                if (!m_isMoveCapture && m_winState == FormWindowState.Normal && e.Button == MouseButtons.Left)
                {
                    m_isMoveCapture = true;
                    FNativeAPIs.ReleaseCapture();
                    FNativeAPIs.SendMessage(this.Handle, FNativeAPIs.FWinMsgs.WM_NCLBUTTONDOWN, FNativeAPIs.FNCHITTEST.HTCAPTION, 0);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void pnlTitle_MouseDoubleClick(
            object sender, 
            MouseEventArgs e
            )
        {
            try
            {
                if (base.MaximizeBox && e.Button == MouseButtons.Left)
                {
                    if (m_winState == FormWindowState.Maximized)
                    {
                        changeWindowState(FormWindowState.Normal);
                    }
                    else if (m_winState == FormWindowState.Normal)
                    {
                        changeWindowState(FormWindowState.Maximized);
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

        #region pnlClient Control Event Handler

        private void pnlClient_Paint(
            object sender, 
            PaintEventArgs e
            )
        {
            try
            {
                paintClientArea();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void pnlClient_Resize(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                paintClientArea();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

        #region picMinimize Control Event Handler

        private void picMinimize_MouseEnter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                picMinimize.Image = Properties.Resources.UIForm_TitleMinimizeHotTrack;
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void picMinimize_MouseLeave(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                picMinimize.Image = Properties.Resources.UIForm_TitleMinimize;
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void picMinimize_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    picMinimize.Image = Properties.Resources.UIForm_TitleMinimizePressed;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void picMinimize_MouseUp(
            object sender, 
            MouseEventArgs e
            )
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    changeWindowState(FormWindowState.Minimized);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region picMaximize Control Event Handler

        private void picMaximize_MouseEnter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                if (m_winState == FormWindowState.Normal)
                {
                    picMaximize.Image = Properties.Resources.UIForm_TitleMaximizeHotTrack;
                }
                else
                {
                    picMaximize.Image = Properties.Resources.UIForm_TitleRestoreHotTrack;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void picMaximize_MouseLeave(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                if (m_winState == FormWindowState.Normal)
                {
                    picMaximize.Image = Properties.Resources.UIForm_TitleMaximize;
                }
                else
                {
                    picMaximize.Image = Properties.Resources.UIForm_TitleRestore;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void picMaximize_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (m_winState == FormWindowState.Normal)
                    {
                        picMaximize.Image = Properties.Resources.UIForm_TitleMaximizePressed;
                    }
                    else
                    {
                        picMaximize.Image = Properties.Resources.UIForm_TitleRestorePressed;
                    }
                } 
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void picMaximize_MouseUp(
            object sender, 
            MouseEventArgs e
            )
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (m_winState == FormWindowState.Maximized)
                    {
                        changeWindowState(FormWindowState.Normal);
                    }
                    else
                    {
                        changeWindowState(FormWindowState.Maximized);
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region plcClose Control Evnent Handler

        private void picClose_MouseEnter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                picClose.Image = Properties.Resources.UIForm_TitleCloseHotTrack;
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void picClose_MouseLeave(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                picClose.Image = Properties.Resources.UIForm_TitleClose;
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void picClose_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    picClose.Image = Properties.Resources.UIForm_TitleClosePressed;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void picClose_MouseUp(
            object sender, 
            MouseEventArgs e
            )
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    picClose.Image = Properties.Resources.UIForm_TitleCloseHotTrack;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

        #region picTitleIcon Control Event Handler

        private void picTitleIcon_MouseDoubleClick(
            object sender, 
            MouseEventArgs e
            )
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardForm", ex, null);
            }
            finally
            {

            }
        }

        #endregion                                

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
