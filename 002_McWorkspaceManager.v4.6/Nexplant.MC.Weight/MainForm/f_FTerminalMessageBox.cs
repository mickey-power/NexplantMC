/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTerminalMessageBox.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.10
--  Description     : Nexplant MC Counter Termianl Message Form Class
--  History         : Created by mjkim at 2019.09.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Counter
{
    public partial class FTerminalMessageBox : Form
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FCntCore m_fCntCore = null;
        private List<string> m_dateList = null;
        private List<string> m_messageList = null;
        private int m_cursor = -1;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTerminalMessageBox(
            )
        {
            InitializeComponent();
            m_dateList = new List<string>();
            m_messageList = new List<string>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTerminalMessageBox(
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

        public void initMessage(
            )
        {
            try
            {
                if (m_cursor == -1)
                {
                    return;
                }

                // --

                m_cursor = m_dateList.Count - 1;
                // --
                txtNo.Text = "No. " + (m_cursor + 1).ToString();
                txtDate.Text = m_dateList[m_cursor];
                txtMessage.Text = m_messageList[m_cursor];
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

        public void writeMessage(
            string message
            )
        {
            // const int MaxCount = 5;
            const int MaxCount = 100;

            try
            {
                m_dateList.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                m_messageList.Add(message);

                // --

                if (m_dateList.Count > MaxCount)
                {
                    m_dateList.RemoveRange(0, m_dateList.Count - MaxCount);
                    m_messageList.RemoveRange(0, m_messageList.Count - MaxCount);
                }

                // --

                m_cursor = m_dateList.Count - 1;
                // --
                txtNo.Text = "No. " + m_dateList.Count.ToString();
                txtDate.Text = m_dateList.Last();
                txtMessage.Text = m_messageList.Last();
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

        public void previousMessage(
            )
        {
            try
            {
                if (m_cursor == -1 || m_cursor == 0)
                {
                    return;
                }

                // --

                m_cursor--;
                // --
                txtNo.Text = "No. " + (m_cursor + 1).ToString();
                txtDate.Text = m_dateList[m_cursor];
                txtMessage.Text = m_messageList[m_cursor];
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

        public void nextMessage(
            )
        {
            try
            {
                if (m_cursor == -1 || m_cursor == m_dateList.Count - 1)
                {
                    return;
                }

                // --

                m_cursor++;
                // --
                txtNo.Text = "No. " + (m_cursor + 1).ToString();
                txtDate.Text = m_dateList[m_cursor];
                txtMessage.Text = m_messageList[m_cursor];
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

        #region FTermianlMessageBox Form Event Handler

        private void FTerminalMessageBox_Activated(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                m_fCntCore.fMainContainer.focusBcrRead();
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
