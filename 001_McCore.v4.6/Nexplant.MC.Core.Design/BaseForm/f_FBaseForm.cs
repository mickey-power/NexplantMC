/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FBaseForm.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.29
--  Description     : FAMate Core FaUIs Base Form Class
--  History         : Created by spike.lee at 2010.12.29
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FBaseForm : Form
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FFormCloseConfirmEventHandler FormCloseConfirm = null;

        private bool m_disposed = false;
        // --
        private FUIWizard m_fUIWizard = null;        
        private bool m_isWmCloseOwner = false;
        private static bool m_wmCloseStarted = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FBaseForm(
            )
        {
            InitializeComponent();            
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
                    m_fUIWizard = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        [Browsable(false)]
        public FUIWizard fUIWizard
        {
            get
            {
                try
                {
                    return m_fUIWizard;
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
                    m_fUIWizard = value;
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

        protected override void WndProc(
            ref Message m
            )
        {
            //IntPtr p = FNativeAPIs.FindWindow(null, "Demo Mode");
            //if (m.Msg == 134 && p != IntPtr.Zero)
            //{
            //    System.Diagnostics.Debug.WriteLine("찾았다 (" + m.Msg.ToString() + ")");
            //    FNativeAPIs.CloseWindow(p);
            //    return;
            //}
            

            //if (m.Msg == (int)FNativeAPIs.FWinMsgs.WM_CREATE || m.Msg == (int)FNativeAPIs.FWinMsgs.WM_ACTIVATE)
            //{
            //    int len = FNativeAPIs.GetWindowTextLength(m.HWnd);
            //    StringBuilder cap = new StringBuilder(len + 1);
            //    FNativeAPIs.GetWindowText(m.HWnd, cap, cap.Capacity);

            //    System.Diagnostics.Debug.WriteLine("Caption=" + cap.ToString());
            //}
            if (m.Msg == (int)FNativeAPIs.FWinMsgs.WM_CLOSE)
            {
                try
                {
                    // System.Diagnostics.Debug.WriteLine("WM_CLOSE Name=" + this.Name);

                    // ***
                    // 2011.09.27 by spike.lee
                    //  - Form Close 시, Form Closing Event 처리 전에 Form Close Confirm Event로 대체하기 
                    //    위해 WM_CLOSE 메시지 Hooking
                    // ***
                    if (!m_wmCloseStarted)
                    {
                        m_isWmCloseOwner = true;
                        m_wmCloseStarted = true;
                        // --
                        if (!confirmFormClose())
                        {
                            m_isWmCloseOwner = false;
                            m_wmCloseStarted = false;
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    FMessageBox.showError("FBaseForm", ex, null);
                }
                finally
                {

                }
            }            
            base.WndProc(ref m);
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool confirmFormClose(
            )
        {
            try
            {
                if (!onFormCloseConfirm())
                {
                    return false;
                }

                // --

                closeChildForm(this.Controls);

                // --

                return true;
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseForm", ex, null);
            }
            finally
            {

            }
            return false;
        }


        //------------------------------------------------------------------------------------------------------------------------

        internal bool onFormCloseConfirm(
            )
        {
            FFormCloseConfirmEventArgs e = null;

            try
            {
                if (FormCloseConfirm != null)
                {
                    e = new FFormCloseConfirmEventArgs();
                    // --
                    FormCloseConfirm(this, e);
                    if (e.cancel)
                    {
                        return false;
                    }
                }

                // --

                if (!onChildFormCloseConfirm(this.Controls))
                {
                    return false;
                }                
                return true;
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseForm", ex, null);
            }
            finally
            {

            }
            return false;
        }       

        //------------------------------------------------------------------------------------------------------------------------

        private bool onChildFormCloseConfirm(
            Control.ControlCollection childs
            )
        {
            try
            {
                foreach (Control c in childs)
                {
                    if (c is FBaseForm)
                    {
                        if (!((FBaseForm)c).onFormCloseConfirm())
                        {
                            return false;
                        }                        
                    }
                    else
                    {
                        if (!onChildFormCloseConfirm(c.Controls))
                        {
                            return false;
                        }
                    }                    
                }                
                return true;
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

        //------------------------------------------------------------------------------------------------------------------------

        internal void closeChildForm(
            Control.ControlCollection childs
            )
        {
            try
            {
                foreach (Control c in childs)
                {
                    if (c is FBaseForm)
                    {
                        ((FBaseForm)c).Close();
                    }
                    else
                    {
                        closeChildForm(c.Controls);
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

        protected virtual void changeControlCaption(
            )
        {
            try
            {
                m_fUIWizard.changeControlCaption(this);
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

        protected virtual void changeControlFontName(
            )
        {
            try
            {
                m_fUIWizard.changeControlFontName(this);
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

        #region FBaseForm Form Event Handler

        private void FBaseForm_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                if (m_fUIWizard != null)
                {
                    m_fUIWizard.LanguageChanged += new FLanguageChangedEventHandler(m_fUIWizard_LanguageChanged);
                    m_fUIWizard.FontNameChanged += new FFontNameChangedEventHandler(m_fUIWizard_FontNameChanged);
                    // --                    
                    changeControlFontName();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseForm", ex, null);
            }
            finally
            {

            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        private void FBaseForm_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                if (m_fUIWizard != null)
                {
                    changeControlCaption();                   
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FBaseForm_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                if (m_fUIWizard != null)
                {
                    m_fUIWizard.LanguageChanged -= new FLanguageChangedEventHandler(m_fUIWizard_LanguageChanged);
                    m_fUIWizard.FontNameChanged -= new FFontNameChangedEventHandler(m_fUIWizard_FontNameChanged);
                }

                // --

                if (m_isWmCloseOwner)
                {
                    m_wmCloseStarted = false;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseForm", ex, null);
            }
            finally
            {

            }
        }
         
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fUIWizard Object Event Handler

        public void m_fUIWizard_LanguageChanged(
            object sender, 
            FLanguageChangedEventArgs e
            )
        {
            try
            {
                changeControlCaption();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void m_fUIWizard_FontNameChanged(
            object sender,
            FFontNameChangedEventArgs e
            )
        {
            try
            {
                changeControlFontName();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseForm", ex, null);
            }
            finally
            {

            }
        }

        #endregion                               

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
