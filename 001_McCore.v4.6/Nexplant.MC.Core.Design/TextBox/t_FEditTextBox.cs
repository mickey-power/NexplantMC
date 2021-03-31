/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FEditTextBox.cs
--  Creator         : Kimsh
--  Create Date     : 2011.02.22
--  Description     : FAMate Core FaUIs Edit Text Box Control
--  History         : Created by Kimsh at 2011.02.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FEditTextBox : UltraTextEditor
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        //--
        private FBaseForm m_ownerForm = null;
        private FTextSearcher m_fTextSearcher = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region class Construction and Destruction

        public FEditTextBox(
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                this.HandleCreated += new EventHandler(FEditTextBox_HandleCreated);
                this.HandleDestroyed += new EventHandler(FEditTextBox_HandleDestroyed);
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
                this.HandleCreated -= new EventHandler(FEditTextBox_HandleCreated);
                this.HandleDestroyed -= new EventHandler(FEditTextBox_HandleDestroyed);

                // --

                closeSearcher();
            }
            catch (FException ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void showSearcher(
            )
        {
            try
            {
                if (m_fTextSearcher == null)
                {
                    m_fTextSearcher = new FTextSearcher(this.Text);
                    m_fTextSearcher.fUIWizard = m_ownerForm.fUIWizard;
                    m_fTextSearcher.SearchWordSelectionRequested += new FSearchWordSelectionRequestedEventHandler(m_fTextSearcher_SearchWordSelectionRequested);                    
                    m_fTextSearcher.FormClosing += new FormClosingEventHandler(m_fTextSearcher_FormClosing);

                    // --

                    m_fTextSearcher.Show(m_ownerForm);
                }

                // --

                if (this.SelectedText != string.Empty)
                {
                    m_fTextSearcher.search(this.SelectedText);
                }
            }
            catch (FException ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        internal void closeSearcher(
            )
        {
            try
            {
                if (m_fTextSearcher != null)
                {
                    m_fTextSearcher.Close();
                    m_fTextSearcher = null;
                }
            }
            catch (FException ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FEditTextBox Control Event Handler

        private void FEditTextBox_HandleCreated(
            object sender,
            EventArgs e
            )
        {
            try
            {
                m_ownerForm = (FBaseForm)this.FindForm();
                if (m_ownerForm != null)
                {
                    m_ownerForm.Enter += new EventHandler(m_ownerForm_Enter);
                    m_ownerForm.Leave += new EventHandler(m_ownerForm_Leave);
                }

                // --

                //this.Font = new Font("Verdana", 8.25F);

                //// --

                //this.Appearance.BackColor = Color.WhiteSmoke;
                //this.Appearance.BorderColor = Color.Silver;
                //this.Appearance.ForeColor = Color.Black;
                //// --
                //this.MaxLength = Int32.MaxValue;
                //this.AutoSize = false;
                //this.AlwaysInEditMode = true;
                //this.HideSelection = false;
                //this.Multiline = true;
                //this.ReadOnly = false;
                //this.Scrollbars = ScrollBars.Both;
                //this.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
                //this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                //this.WordWrap = false;
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FEditTextBox", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FEditTextBox_HandleDestroyed(
            object sender,
            EventArgs e
            )
        {
            try
            {
                closeSearcher();

                // --

                if (m_ownerForm != null)
                {
                    m_ownerForm.Enter -= new EventHandler(m_ownerForm_Enter);
                    m_ownerForm.Leave -= new EventHandler(m_ownerForm_Leave);
                    m_ownerForm = null;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FEditTextBox", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_ownerForm Form Event Handler

        private void m_ownerForm_Enter(
            object sender,
            EventArgs e
            )
        {
            try
            {
                if (m_fTextSearcher != null && !m_fTextSearcher.Visible)
                {
                    m_fTextSearcher.Visible = true;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FEditTextBox", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_ownerForm_Leave(
            object sender,
            EventArgs e
            )
        {
            try
            {
                if (m_fTextSearcher != null && m_fTextSearcher.Visible)
                {
                    m_fTextSearcher.Visible = false;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FEditTextBox", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region fTextSearcher Form Event Handler

        private void m_fTextSearcher_SearchWordSelectionRequested(
            object sender,
            FSearchWordSelectionRequestedEventArgs e
            )
        {
            try
            {
                this.Select(e.position, e.length);
                this.ScrollToCaret();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FEditTextBox", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTextSearcher_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                m_fTextSearcher.SearchWordSelectionRequested -= new FSearchWordSelectionRequestedEventHandler(m_fTextSearcher_SearchWordSelectionRequested);
                m_fTextSearcher.FormClosing -= new FormClosingEventHandler(m_fTextSearcher_FormClosing);
                m_fTextSearcher = null;
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FEditTextBox", ex, null);
            }
            finally
            {

            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   //Namespace end
