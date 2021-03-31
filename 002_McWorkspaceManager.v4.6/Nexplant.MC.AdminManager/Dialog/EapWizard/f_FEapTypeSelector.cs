/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEapTypeSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2013.12.18
--  Description     : FAMate Admin Manager EAP Type Selector Form Class 
--  History         : Created by spike.lee at 2013.12.18
 ----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public partial class FEapTypeSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FAdmCore m_fAdmCore = null;
        private FEapType m_fEapType = FEapType.SECS;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEapTypeSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEapTypeSelector(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;            
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
                    m_fAdmCore = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties
       
        public FEapType fEapType
        {
            get
            {
                try
                {
                    return m_fEapType;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FEapType.SECS;
            }
        }
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FCommentEditor Form Event Handler

        private void FCommentEditor_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region  btnOk Control Event Handler

        private void btnOk_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!chkSecs.Checked && !chkOpc.Checked && !chkTcp.Checked && !chkPrc.Checked && !chkFile.Checked)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0020"));
                }

                // --
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Common CheckBox Event Handler

        private void chkCommon_CheckedChanged(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                if (sender == chkSecs)
                {
                    if (chkSecs.Checked)
                    {
                        m_fEapType = FEapType.SECS;
                        // --
                        //chkPlc.Checked = false;
                        chkOpc.Checked = false;
                        chkTcp.Checked = false;
                        chkPrc.Checked = false;
                        chkFile.Checked = false;
                    }                    
                }
                //else if (sender == chkPlc)
                //{
                //    if (chkPlc.Checked)
                //    {
                //        m_fEapType = FEapType.PLC;
                //        // --
                //        chkSecs.Checked = false;
                //        chkOpc.Checked = false;
                //        chkTcp.Checked = false;
                //        chkPrc.Checked = false;
                //        chkFile.Checked = false;
                //    }
                //}
                else if (sender == chkOpc)
                {
                    if (chkOpc.Checked)
                    {
                        m_fEapType = FEapType.OPC;
                        // --
                        chkSecs.Checked = false;
                        //chkPlc.Checked = false;
                        chkPrc.Checked = false;
                        chkTcp.Checked = false;
                        chkFile.Checked = false;
                    }
                }
                else if (sender == chkTcp)
                {
                    if (chkTcp.Checked)
                    {
                        m_fEapType = FEapType.TCP;
                        // --
                        chkSecs.Checked = false;
                        //chkPlc.Checked = false;
                        chkOpc.Checked = false;
                        chkPrc.Checked = false;
                        chkFile.Checked = false;
                    }
                }
                else if (sender == chkPrc)
                {
                    if (chkPrc.Checked)
                    {
                        m_fEapType = FEapType.Process;
                        // --
                        chkSecs.Checked = false;
                        //chkPlc.Checked = false;
                        chkOpc.Checked = false;
                        chkTcp.Checked = false;
                        chkFile.Checked = false;
                    }
                }
                else if (sender == chkFile)
                {
                    if (chkFile.Checked)
                    {
                        m_fEapType = FEapType.FILE;
                        // --
                        chkSecs.Checked = false;
                        //chkPlc.Checked = false;
                        chkOpc.Checked = false;
                        chkTcp.Checked = false;
                        chkPrc.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
