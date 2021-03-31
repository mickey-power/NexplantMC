/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTabChildIcon.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.20
--  Description     : FAMate Core FaUIs TAB Child Icon Form Class
--  History         : Created by spike.lee at 2011.01.20
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
    public partial class FTabChildIcon : FBaseForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FBaseTabChildForm m_owner = null;
        private string m_caption = string.Empty;
        private bool m_isMoveCapture = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FTabChildIcon(
            FBaseTabChildForm owner
            )            
        {
            InitializeComponent();
            this.fUIWizard = owner.fUIWizard;
            m_owner = owner;
            m_caption = owner.Text;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
                paintIconArea();
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
                paintIconArea();
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

        private void paintIconArea(
            )
        {
            Bitmap bitmap = null;
            Graphics g = null;
            Brush brush = null;
            Font font = null;
            StringFormat stringFormat = null;

            try
            {
                bitmap = new Bitmap(60, 60, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                g = Graphics.FromImage(bitmap);
                g.DrawImage(m_owner.Icon.ToBitmap(), 14, 2, 32, 32);

                // --

                brush = new SolidBrush(Color.DimGray);
                font = new Font((this.fUIWizard == null ? m_owner.Font.Name : this.fUIWizard.fontName), 9F, FontStyle.Bold);
                stringFormat = new StringFormat();
                stringFormat.Trimming = StringTrimming.EllipsisCharacter;
                stringFormat.Alignment = StringAlignment.Center;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                g.DrawString(
                    (this.fUIWizard == null ? m_caption : this.fUIWizard.searchCaption(m_caption)), 
                    font, 
                    brush, 
                    new RectangleF(0, 34, bitmap.Width, font.Height), 
                    stringFormat
                    );
                // --
                brush.Dispose();
                brush = null;
                font.Dispose();
                font = null;

                // --

                this.MinimumSize = new Size(10, 10);
                this.BackgroundImage = bitmap;
                this.Region = new Region(FGraphics.calculateGraphicsPath(bitmap));
                this.ClientSize = new Size(bitmap.Width, bitmap.Height);
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

                if (font != null)
                {
                    font.Dispose();
                    font = null;
                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FTabChildIcon Form Event Handler

        private void FTabChildIcon_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                paintIconArea();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FTabChildIcon", ex, null);
            }
            finally
            {
                
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FTabChildIcon_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    m_isMoveCapture = false;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FTabChildIcon", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FTabChildIcon_MouseMove(
            object sender, 
            MouseEventArgs e
            )
        {
            try
            {
                if (!m_isMoveCapture && e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    m_isMoveCapture = true;
                    FNativeAPIs.ReleaseCapture();
                    FNativeAPIs.SendMessage(this.Handle, FNativeAPIs.FWinMsgs.WM_NCLBUTTONDOWN, FNativeAPIs.FNCHITTEST.HTCAPTION, 0);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FTabChildIcon", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FTabChildIcon_MouseUp(
            object sender, 
            MouseEventArgs e
            )
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    m_owner.Visible = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FTabChildIcon", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FTabChildIcon_MouseDoubleClick(
            object sender, 
            MouseEventArgs e
            )
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    m_owner.Visible = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FTabChildIcon", ex, null);
            }
            finally
            {

            }
        }

        #endregion               

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
