/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FRefreshAndSearchToolbar.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.04
--  Description     : FAMate Core FaUIs Refresh and Search Toolbar Control
--  History         : Created by spike.lee at 2011.01.04
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

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FRefreshAndSearchToolbar : UserControl
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FRefreshRequestedEventHandler RefreshRequested = null;
        public event FSearchRequestedEventHandler SearchRequested = null;

        // --

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FRefreshAndSearchToolbar(
            )
        {
            InitializeComponent();
            
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

        public bool refreshEnabled
        {
            get
            {
                try
                {
                    return btnRefresh.Visible;
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
                    btnRefresh.Visible = value;
                    // --
                    if (value)
                    {
                        txtSearchWord.Left = 23;
                        txtSearchWord.Width = btnSearch.Left - 25;
                    }
                    else
                    {
                        txtSearchWord.Left = 0;
                        txtSearchWord.Width = btnSearch.Left - 2;
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

        private void onRefreshRequested(
            )
        {
            try
            {
                if (RefreshRequested != null)
                {
                    RefreshRequested(this, new EventArgs());
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

        private void onSearchRequested(
            )
        {
            try
            {
                if (SearchRequested != null && txtSearchWord.Text.Trim() != string.Empty)
                {
                    SearchRequested(this, new FSearchRequestedEventArgs(txtSearchWord.Text));
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

        public void onSearchRequested(
            string searchWord
            )
        {
            try
            {
                txtSearchWord.Text = searchWord;
                onSearchRequested();
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

        #region btnRefresh Control Event Handler

        private void btnRefresh_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                onRefreshRequested();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FRefreshAndSearchToolbar", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region txtSearchWord Control Event Handler

        private void txtSearchWord_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    onSearchRequested();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FRefreshAndSearchToolbar", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnSearch Control Event Handler

        private void btnSearch_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                onSearchRequested();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FRefreshAndSearchToolbar", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
