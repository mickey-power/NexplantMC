/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FBaseTabMdiChildForm.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.30
--  Description     : FAMate Core FaUIs Base TAB MDI Child Form Class
--  History         : Created by spike.lee at 2010.12.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FBaseTabMdiChildForm : FBaseForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private List<FBaseTabChildForm> m_fChilds = null;
        private HashSet<FTabChildIcon> m_fIcons = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FBaseTabMdiChildForm(
            )
        {
            InitializeComponent();
            init();
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
                    term();
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FBaseTabChildForm[] fChilds
        {
            get
            {
                FBaseTabChildForm[] array = null;
                int i = 0;

                try
                {
                    array = new FBaseTabChildForm[m_fChilds.Count];
                    foreach (FBaseTabChildForm f in m_fChilds)
                    {
                        array[i++] = f;    
                    }
                    return array;
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
                m_fChilds = new List<FBaseTabChildForm>();
                m_fIcons = new HashSet<FTabChildIcon>();
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
                if (m_fChilds != null)
                {
                    m_fChilds.Clear();
                    m_fChilds = null;
                }

                if (m_fIcons != null)
                {
                    m_fIcons.Clear();
                    m_fIcons = null;
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

        public void showChild(
            FBaseTabChildForm fTabChildForm
            )
        {
            try
            {
                fTabChildForm.TopLevel = false;
                pnlClient.Controls.Add(fTabChildForm);
                fTabChildForm.Show();
                fTabChildForm.BringToFront();
                fTabChildForm.Activate();
                
                // --

                m_fChilds.Add(fTabChildForm);
                fTabChildForm.FormClosing += new FormClosingEventHandler(childForm_FormClosing);
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

        internal void showIcon(
            FTabChildIcon fTabChildIcon
            )
        {
            int left = 0;
            int top = 0;
            int width = 0;
            int height = 0;
            bool comp = false;

            try
            {
                fTabChildIcon.TopLevel = false;                
                pnlClient.Controls.Add(fTabChildIcon);
                fTabChildIcon.Show();

                // --

                left = 0;
                top = pnlClient.ClientSize.Height - fTabChildIcon.Height;
                width = fTabChildIcon.Width;
                height = fTabChildIcon.Height;

                // --

                while (m_fIcons.Count > 0 && !comp)
                {
                    comp = true;
                    foreach (FTabChildIcon f in m_fIcons)
                    {
                        if (f.Bounds.IntersectsWith(new Rectangle(left, top, width, height)))
                        {
                            comp = false;
                            break;
                        }
                    }

                    // --

                    if (comp)
                    {
                        break;
                    }

                    // --

                    left += (fTabChildIcon.Width + 4);
                    if (left + width > pnlClient.ClientSize.Width)
                    {
                        left = 0;
                        top -= (height + 2);
                    }
                }

                fTabChildIcon.Location = new Point(left, top);

                // --

                m_fIcons.Add(fTabChildIcon);
                fTabChildIcon.FormClosing += new FormClosingEventHandler(childForm_FormClosing);
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

        public FBaseTabChildForm getChild(
            Type type
            )
        {
            try
            {
                foreach (FBaseTabChildForm f in m_fChilds)
                {
                    if (f.GetType() == type)
                    {
                        return f;
                    }                           
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

        public FBaseTabChildForm getChild(
            string name
            )
        {
            try
            {
                foreach (FBaseTabChildForm f in m_fChilds)
                {
                    if (f.Name == name)
                    {
                        return f;
                    }
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

        public bool closeAllChilds(
            )
        {
            FBaseTabChildForm fForm = null;
            FTabChildIcon fIcon = null;

            try
            {
                for (int i = m_fChilds.Count - 1; i >= 0; i--)
                {
                    fForm = m_fChilds[i];
                    fIcon = fForm.fTabChildIcon;

                    // --

                    fForm.Close();
                    if (fForm.IsHandleCreated)
                    {
                        return false;
                    }                                        

                    // --

                    if (fIcon != null && m_fIcons.Contains(fIcon))
                    {
                        fIcon.Close();
                        if (fIcon.IsHandleCreated)
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FBaseTabMdiChildForm Event Handler

        private void FBaseTabMdiChildForm_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                // ***
                // 2012.11.20 by spike.lee
                // Ribbon MDI Form에서 CloseConfirm Event를 발생시킬 때 Child Form도 CloseConfirm Event가 발생함.
                // 여기서 Child를 Close 함으로 인해 Child Form에 CloseConfirm Event가 두번 발생함.
                // 우선 주석처리하지만 이후 다른 문제가 발생할 경우 전반적인 점검이 필요할 것으로 생각됨.
                // ***
                // this.closeAllChilds();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseTabMdiChildForm", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region childForm Form Event Handler

        private void childForm_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            FBaseForm fFormBase = null;

            try
            {
                fFormBase = (FBaseForm)sender;

                // --

                if (fFormBase is FBaseTabChildForm)
                {
                    if (m_fChilds.Contains((FBaseTabChildForm)fFormBase))
                    {
                        fFormBase.FormClosing -= new FormClosingEventHandler(childForm_FormClosing);
                        m_fChilds.Remove((FBaseTabChildForm)fFormBase);
                    }
                }
                else if (fFormBase is FTabChildIcon)
                {
                    if (m_fIcons.Contains((FTabChildIcon)fFormBase))
                    {
                        fFormBase.FormClosing -= new FormClosingEventHandler(childForm_FormClosing);
                        m_fIcons.Remove((FTabChildIcon)fFormBase);
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseTabMdiChildForm", ex, null);
            }
            finally
            {
                
            }
        }        

        #endregion                        

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
