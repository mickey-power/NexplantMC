/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FHsmsOptionDialog.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.10
--  Description     : Nexplant MC Counter HSMS Option Dialog Form Class
--  History         : Created by mjkim at 2019.09.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecs1ToHsms;

namespace Nexplant.MC.Counter
{
    public partial class FHsmsOptionDialog : Form
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FCntCore m_fCntCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHsmsOptionDialog(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHsmsOptionDialog(
            FCntCore fCntCore
            )
            : this()
        {
            m_fCntCore = fCntCore;
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
                    m_fCntCore = null;   
                }
            }

            m_disposed = true;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Proeprties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FHsmsOptionDialog Form Event Handler

        private void FHsmsOptionDialog_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                // ***
                // Connect Mode 기준 정보 등록
                // ***
                cboConnectMode.Items.Add(FConnectMode.Passive.ToString());
                cboConnectMode.Items.Add(FConnectMode.Active.ToString());

                // --

                // ***
                // HSMS Option Load
                // ***
                txtSessionId.Text = m_fCntCore.fOption.hsmsSessionId.ToString();
                cboConnectMode.Text = m_fCntCore.fOption.hsmsConnectMode.ToString();
                txtLocalIp.Text = m_fCntCore.fOption.hsmsLocalIp;
                txtLocalPort.Text = m_fCntCore.fOption.hsmsLocalPort.ToString();
                txtRemoteIp.Text = m_fCntCore.fOption.hsmsRemoteIp;
                txtRemotePort.Text = m_fCntCore.fOption.hsmsRemotePort.ToString();
                txtLinkTestPeriod.Text = m_fCntCore.fOption.hsmsLinkTestPeriod.ToString();
                txtT3Timeout.Text = m_fCntCore.fOption.hsmsT3Timeout.ToString();
                txtT5Timeout.Text = m_fCntCore.fOption.hsmsT5Timeout.ToString();
                txtT6Timeout.Text = m_fCntCore.fOption.hsmsT6Timeout.ToString();
                txtT7Timeout.Text = m_fCntCore.fOption.hsmsT7Timeout.ToString();
                txtT8Timeout.Text = m_fCntCore.fOption.hsmsT8Timeout.ToString();
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnCancel Control Event Handler

        private void btnCancel_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                this.Close();                
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

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
            UInt16 ui16Val = 0;
            int iVal = 0;
            FConnectMode fConnectMode = FConnectMode.Passive;

            try
            {
                if (!UInt16.TryParse(txtSessionId.Text, out ui16Val) || ui16Val > 32767)
                {
                    txtSessionId.Focus();
                    FDebug.throwFException("Session ID의 값이 유효하지 않습니다.");
                }

                if (!Enum.TryParse<FConnectMode>(cboConnectMode.Text, out fConnectMode))
                {
                    cboConnectMode.Focus();
                    FDebug.throwFException("Connect Mode의 값이 유효하지 않습니다.");
                }

                if (txtLocalIp.Text.Trim() == string.Empty)
                {
                    cboConnectMode.Focus();
                    FDebug.throwFException("Local IP의 값이 유효하지 않습니다.");
                }

                if (!int.TryParse(txtLocalPort.Text, out iVal) || iVal < 0 || iVal > 65535)
                {
                    txtLocalPort.Focus();
                    FDebug.throwFException("Local Port의 값이 유효하지 않습니다.");
                }

                if (fConnectMode == FConnectMode.Active)                
                {
                    if (txtRemoteIp.Text.Trim() == string.Empty)
                    {
                        txtRemoteIp.Focus();
                        FDebug.throwFException("Remote IP의 값이 유효하지 않습니다.");
                    }                    
                }

                if (!int.TryParse(txtRemotePort.Text, out iVal) || iVal < 0 || iVal > 65535)
                {
                    txtRemotePort.Focus();
                    FDebug.throwFException("Remote Port의 값이 유효하지 않습니다.");
                }

                if (!int.TryParse(txtLinkTestPeriod.Text, out iVal) || iVal < 0 || iVal > 240)
                {
                    txtLinkTestPeriod.Focus();
                    FDebug.throwFException("Link Test Period의 값이 유효하지 않습니다.");
                }

                if (!int.TryParse(txtT3Timeout.Text, out iVal) || iVal < 1 || iVal > 120)
                {
                    txtT3Timeout.Focus();
                    FDebug.throwFException("T3 Timeout의 값이 유효하지 않습니다.");
                }

                if (!int.TryParse(txtT5Timeout.Text, out iVal) || iVal < 1 || iVal > 240)
                {
                    txtT5Timeout.Focus();
                    FDebug.throwFException("T5 Timeout의 값이 유효하지 않습니다.");
                }

                if (!int.TryParse(txtT6Timeout.Text, out iVal) || iVal < 1 || iVal > 240)
                {
                    txtT6Timeout.Focus();
                    FDebug.throwFException("T6 Timeout의 값이 유효하지 않습니다.");
                }

                if (!int.TryParse(txtT7Timeout.Text, out iVal) || iVal < 1 || iVal > 240)
                {
                    txtT7Timeout.Focus();
                    FDebug.throwFException("T7 Timeout의 값이 유효하지 않습니다.");
                }

                if (!int.TryParse(txtT8Timeout.Text, out iVal) || iVal < 1 || iVal > 120)
                {
                    txtT8Timeout.Focus();
                    FDebug.throwFException("T8 Timeout의 값이 유효하지 않습니다.");
                }

                // --

                if (FCommon.showConfirmMessageBox(this, "HSMS 옵션을 변경하시겠습니까?") == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                // --

                m_fCntCore.fOption.hsmsSessionId = UInt16.Parse(txtSessionId.Text);
                m_fCntCore.fOption.hsmsConnectMode = (FConnectMode)Enum.Parse(typeof(FConnectMode), cboConnectMode.Text);
                m_fCntCore.fOption.hsmsLocalIp = txtLocalIp.Text;
                m_fCntCore.fOption.hsmsLocalPort = int.Parse(txtLocalPort.Text);
                m_fCntCore.fOption.hsmsRemoteIp = txtRemoteIp.Text;
                m_fCntCore.fOption.hsmsRemotePort = int.Parse(txtRemotePort.Text);
                m_fCntCore.fOption.hsmsLinkTestPeriod = int.Parse(txtLinkTestPeriod.Text);
                m_fCntCore.fOption.hsmsT3Timeout = int.Parse(txtT3Timeout.Text);
                m_fCntCore.fOption.hsmsT5Timeout = int.Parse(txtT5Timeout.Text);
                m_fCntCore.fOption.hsmsT6Timeout = int.Parse(txtT6Timeout.Text);
                m_fCntCore.fOption.hsmsT7Timeout = int.Parse(txtT7Timeout.Text);
                m_fCntCore.fOption.hsmsT8Timeout = int.Parse(txtT8Timeout.Text);
                // --
                m_fCntCore.fOption.save();

                // --

                this.Close();
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // class end
}   // namespace end
