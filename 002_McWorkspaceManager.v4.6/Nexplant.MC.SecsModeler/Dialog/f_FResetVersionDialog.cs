/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FReplaceNameDialog.cs
--  Creator         : spike.lee
--  Create Date     : 2016.04.25
--  Description     : FAMate SECS Modeler Replace Name Dialog Form Class
--  History         : Created by spike.lee at 2016.04.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;
using System.Collections;
// --
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
// --
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaSecsDriver;

namespace Nexplant.MC.SecsModeler
{
    public partial class FResetVersionDialog : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private FSecsMessageList m_fMsgList = null;
        private int m_stream = 0;
        private int m_function = 0;
        private int m_version = 0;
        // --
        private SortedDictionary<int, List<int>> m_msgData = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FResetVersionDialog(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FResetVersionDialog(
            FSsmCore fSsmCore,
            FSecsMessageList fMsgList
            )
            : this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;
            m_fMsgList = fMsgList;            
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
                    m_fSsmCore = null;
                }
                m_disposed = true;
            }
        }

        #endregion  

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public int stream
        {
            get
            {
                try
                {
                    return m_stream;
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

        public int function
        {
            get
            {
                try
                {
                    return m_function;
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

        public int version
        {
            get
            {
                try
                {
                    return m_version;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void setTitle(
            )
        {
            string caption = string.Empty;

            try
            {
                caption = m_fSsmCore.fUIWizard.searchCaption(this.Text);
                this.Text = caption;
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
                setTitle();
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

        private void designComboOfStream(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = ucbStream.dataSource;
                // --
                uds.Band.Columns.Add("Stream");

                // --

                ucbStream.Appearance.Image = Properties.Resources.SecsMessage;
                // --
                ucbStream.DisplayLayout.Bands[0].Columns["Stream"].CellAppearance.Image = Properties.Resources.SecsMessage;
                ucbStream.DisplayLayout.Bands[0].Columns["Stream"].Width = ucbStream.Width - 2;
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

        private void designComboOfFunction(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = ucbFunction.dataSource;
                // --
                uds.Band.Columns.Add("Function");

                // --

                ucbFunction.Appearance.Image = Properties.Resources.SecsMessage;
                // --
                ucbFunction.DisplayLayout.Bands[0].Columns["Function"].CellAppearance.Image = Properties.Resources.SecsMessage;
                ucbFunction.DisplayLayout.Bands[0].Columns["Function"].Width = ucbFunction.Width - 2;
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

        private void refreshComboOfStream(
             )
        {
            try
            {
                ucbStream.beginUpdate(false);
                ucbStream.removeAllDataRow();

                // --

                foreach (int s in m_msgData.Keys)
                {
                    ucbStream.appendDataRow(s.ToString(), new object[] { s });
                }
                ucbStream.ActiveRow = ucbStream.Rows[0];
                // --

                ucbStream.endUpdate(false);

                // --

                ucbStream.Text = ucbStream.activeDataRowKey;
            }
            catch (Exception ex)
            {
                ucbStream.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshComboOfFunction(
             )
        {
            int stream = 0;
            try
            {
                ucbFunction.beginUpdate(false);
                ucbFunction.removeAllDataRow();

                // --
                stream = int.Parse(ucbStream.Text);

                // --

                foreach (int s in m_msgData[stream])
                {
                    ucbFunction.appendDataRow(s.ToString(), new object[] { s });
                }
                ucbFunction.ActiveRow = ucbFunction.Rows[0];
                // --
                
                ucbFunction.endUpdate(false);

                // --

                ucbFunction.Text = ucbFunction.activeDataRowKey;
            }
            catch (Exception ex)
            {
                ucbStream.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FResetVersionDialog Form Event Handler

        private void FResetVersionDialog_Load(
            object sender,
            EventArgs e
            )
        {
            List<int> functions = null;
            try
            {
                // --
                m_msgData = new SortedDictionary<int, List<int>>();
                foreach (FSecsMessages fSecsMessages in m_fMsgList.fChildSecsMessagesCollection)
                {
                    if (!m_msgData.ContainsKey(fSecsMessages.stream))
                    {
                        // --
                        functions = new List<int>();
                        functions.Add(fSecsMessages.function);

                        // --
                        m_msgData.Add(fSecsMessages.stream, functions);
                    }
                    else
                    {
                        if (!m_msgData[fSecsMessages.stream].Contains(fSecsMessages.function))
                        {
                            m_msgData[fSecsMessages.stream].Add(fSecsMessages.function);
                        }
                    }
                }

                // --

                designComboOfStream();
                designComboOfFunction();

                // --
                refreshComboOfStream();
                
                // --
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                functions = null;
            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

        #region btnOk Control Event Handler

        private void btnOk_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (ucbStream.Text.Trim() == string.Empty)
                {
                    FDebug.throwFException(
                        m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0004", new object[] { "Stream" })
                        );
                }

                // --

                if (ucbFunction.Text.Trim() == string.Empty)
                {
                    FDebug.throwFException(
                        m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0004", new object[] { "Function" })
                        );
                }

                // --

                if (!int.TryParse(txtInitVersion.Text.Trim(), out m_version))
                {
                    FDebug.throwFException(
                        m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0015", new object[] { "Init Version" })
                        );
                }

                // --

                m_stream = int.Parse(ucbStream.Text);
                m_function = int.Parse(ucbFunction.Text);

                // --

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();                
            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

        #region ucbStream Control Event Handler

        private void ucbStream_TextChanged(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                refreshComboOfFunction();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion


        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
