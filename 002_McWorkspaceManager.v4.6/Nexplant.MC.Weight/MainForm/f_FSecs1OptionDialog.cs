/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSecs1OptionDialog.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.10
--  Description     : Nexplant MC Counter SECS1 Option Dialog Form Class
--  History         : Created by mjkim at 2019.09.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Counter
{
    public partial class FSecs1OptionDialog : Form
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FCntCore m_fCntCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecs1OptionDialog(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecs1OptionDialog(
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

        #region FSecs1OptionDialog Form Event Handler

        private void FSecs1OptionDialog_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                // ***
                // Serial Port 기준 정보 등록
                // ***
                for (int i = 1; i <= 48; i++)
                {
                    cboSerialPort.Items.Add("COM" + i.ToString());
                }

                // --

                // ***
                // Baud 기준 정보 등록
                // ***
                cboBaud.Items.Add("150");
                cboBaud.Items.Add("300");
                cboBaud.Items.Add("1200");
                cboBaud.Items.Add("2400");
                cboBaud.Items.Add("4800");
                cboBaud.Items.Add("9600");
                cboBaud.Items.Add("14400");
                cboBaud.Items.Add("19200");
                cboBaud.Items.Add("28800");
                cboBaud.Items.Add("33600");
                cboBaud.Items.Add("57600");

                // --

                // ***
                // SECS1 Option Load
                // ***
                txtSessionId.Text = m_fCntCore.fOption.secs1SessionId.ToString();
                cboSerialPort.Text = m_fCntCore.fOption.secs1SerialPort;
                cboBaud.Text = m_fCntCore.fOption.secs1Baud.ToString();
                chkRBit.Checked = m_fCntCore.fOption.secs1Rbit;
                chkInterleave.Checked = m_fCntCore.fOption.secs1Interleave;
                chkDuplicateError.Checked = m_fCntCore.fOption.secs1DuplicateError;
                chkIgnoreSystemBytes.Checked = m_fCntCore.fOption.secs1IgnoreSystemBytes;
                txtRetryLimit.Text = m_fCntCore.fOption.secs1RetryLimit.ToString();
                txtT1Timeout.Text = m_fCntCore.fOption.secs1T1Timeout.ToString();
                txtT2Timeout.Text = m_fCntCore.fOption.secs1T2Timeout.ToString();
                txtT3Timeout.Text = m_fCntCore.fOption.secs1T3Timeout.ToString();
                txtT4Timeout.Text = m_fCntCore.fOption.secs1T4Timeout.ToString();
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
            float fVal = 0;

            try
            {
                if (!UInt16.TryParse(txtSessionId.Text, out ui16Val) || ui16Val > 32767)
                {
                    txtSessionId.Focus();
                    FDebug.throwFException("Session ID의 값이 유효하지 않습니다.");                    
                }

                if (!int.TryParse(cboBaud.Text, out iVal) || iVal <= 0)
                {
                    cboBaud.Focus();
                    FDebug.throwFException("Baud의 값이 유효하지 않습니다.");
                }

                if (!int.TryParse(txtRetryLimit.Text, out iVal) || iVal < 0 || iVal > 31)
                {
                    txtRetryLimit.Focus();
                    FDebug.throwFException("Retry Limit의 값이 유효하지 않습니다.");
                }

                if (!float.TryParse(txtT1Timeout.Text, out fVal) || iVal < 0.1F || iVal > 10.0F)
                {
                    txtT1Timeout.Focus();
                    FDebug.throwFException("T1 Timeout의 값이 유효하지 않습니다.");
                }

                if (!float.TryParse(txtT2Timeout.Text, out fVal) || iVal < 0.1F || iVal > 10.0F)
                {
                    txtT2Timeout.Focus();
                    FDebug.throwFException("T2 Timeout의 값이 유효하지 않습니다.");
                }

                if (!int.TryParse(txtT3Timeout.Text, out iVal) || iVal < 1 || iVal > 120)
                {
                    txtT3Timeout.Focus();
                    FDebug.throwFException("T3 Timeout의 값이 유효하지 않습니다.");
                }

                if (!int.TryParse(txtT4Timeout.Text, out iVal) || iVal < 1 || iVal > 120)
                {
                    txtT4Timeout.Focus();
                    FDebug.throwFException("T4 Timeout의 값이 유효하지 않습니다.");
                }

                // --

                if (FCommon.showConfirmMessageBox(this, "SECS1 옵션을 변경하시겠습니까?") == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                // --

                m_fCntCore.fOption.secs1SessionId = UInt16.Parse(txtSessionId.Text);
                m_fCntCore.fOption.secs1SerialPort = cboSerialPort.Text;
                m_fCntCore.fOption.secs1Baud = int.Parse(cboBaud.Text);
                m_fCntCore.fOption.secs1Rbit = chkRBit.Checked;
                m_fCntCore.fOption.secs1Interleave = chkInterleave.Checked;
                m_fCntCore.fOption.secs1DuplicateError = chkDuplicateError.Checked;
                m_fCntCore.fOption.secs1IgnoreSystemBytes = chkIgnoreSystemBytes.Checked;
                m_fCntCore.fOption.secs1RetryLimit = int.Parse(txtRetryLimit.Text);
                m_fCntCore.fOption.secs1T1Timeout = float.Parse(txtT1Timeout.Text);
                m_fCntCore.fOption.secs1T2Timeout = float.Parse(txtT2Timeout.Text);
                m_fCntCore.fOption.secs1T3Timeout = int.Parse(txtT3Timeout.Text);
                m_fCntCore.fOption.secs1T4Timeout = int.Parse(txtT4Timeout.Text);
                // --
                m_fCntCore.fOption.save();

                // --

                this.Close();
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // class end
}   // namespace end
