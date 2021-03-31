/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FBaseTabChildForm.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.17
--  Description     : FAMate Core FaUIs Base TAB Child Form Class
--  History         : Created by spike.lee at 2011.01.17
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
    public partial class FBaseTabChildForm : Nexplant.MC.Core.FaUIs.FBaseStandardForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;        
        // --
        private FTabChildIcon m_fTabChildIcon = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FBaseTabChildForm(
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

        internal FTabChildIcon fTabChildIcon
        {
            get
            {
                try
                {
                    return m_fTabChildIcon; 
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

        protected override void changeWindowState(
            FormWindowState state
            )
        {
            try
            {
                if (base.winState == state)
                {
                    return;
                }

                // --

                if (state == FormWindowState.Minimized)
                {
                    minimize();
                }
                else
                {
                    base.changeWindowState(state);
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

        private void minimize(
            )
        {
            try
            {
                this.Visible = false;   
             
                // --

                if (m_fTabChildIcon != null)
                {
                    m_fTabChildIcon.Dispose();
                    m_fTabChildIcon = null;
                }
                m_fTabChildIcon = new FTabChildIcon(this);

                // --

                ((FBaseTabMdiChildForm)this.Parent.Parent).showIcon(m_fTabChildIcon);
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

        public void activate(
            )
        {
            try
            {
                if (m_fTabChildIcon != null)
                {
                    m_fTabChildIcon.Close();
                    m_fTabChildIcon.Dispose();
                    m_fTabChildIcon = null;
                }

                // --

                if (!this.Visible)
                {
                    this.Visible = true;
                }

                // --

                this.BringToFront();
                this.Activate();
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

        #region FBaseTabChildForm Form Event Handler

        private void FBaseTabChildForm_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                foreach (Control t in this.Controls)
                {
                    if (t is Form)
                    {
                        ((Form)t).Close();
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseTabChildForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FBaseTabChildForm_VisibleChanged(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                if (this.Visible)
                {
                    this.BringToFront();
                    this.Activate();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseTabChildForm", ex, null);
            }
            finally
            {

            }
        }

        #endregion                

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
