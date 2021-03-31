/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FInquiryProgress.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2016.04.20
--  Description     : FAMate Admin Manager Inquiry Progress Dialog Form Class 
--  History         : Created by jungyoul.moon at 2016.04.20
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public partial class FInquiryProgress : FBaseForm
    {
        public event EventHandler<EventArgs> Canceled;

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private FIInquiry m_fParent = null;
        private List<double> m_lstRspTimes = null;
        private int m_reqCount= 0;
        // --
        Stopwatch m_swRspTime = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FInquiryProgress(
            )
        {
            InitializeComponent();
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public FInquiryProgress(
            FAdmCore fAdmCore,
            FIInquiry fParent
            ) : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            // --
            m_fAdmCore = fAdmCore;
            m_fParent = fParent;
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
                    m_fParent = null;
                    m_lstRspTimes = null;
                    m_swRspTime = null;
                    // --
                    m_fAdmCore = null;
                }
                m_disposed = true;
            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public int ReqCount
        {
            set
            {
                try
                {
                    m_reqCount = value;
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

        public void changedProgress(
            int procCount,
            int dataCount
            )
        {
            try
            {
                if (procCount == 0)
                {
                    m_swRspTime = new Stopwatch();
                    m_swRspTime.Start();

                    // --

                    m_lstRspTimes = new List<double>();
                }
                else
                {
                    m_swRspTime.Stop();
                    m_lstRspTimes.Add(m_swRspTime.ElapsedMilliseconds);

                    // --

                    this.Pgb.Value = procCount;
                    // --
                    this.lblPercentage.Text = string.Format("{0:N0} %", double.Parse(procCount.ToString()) / double.Parse(m_reqCount.ToString()) * 100);
                    this.lblCollectCount.Text = string.Format("{0}: {1:N0}", this.fUIWizard.searchCaption("Collected Data"), dataCount);
                    this.lblRemaining.Text = string.Format("{0:N0} {1}", TimeSpan.FromMilliseconds(m_lstRspTimes.Average() * (m_reqCount - procCount)).TotalSeconds, this.fUIWizard.searchCaption("Seconds Remaining"));

                    // --

                    m_swRspTime.Reset();
                    m_swRspTime.Start();
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

        private void procProcess(
            )
        {
            try
            {
                m_fParent.request();
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

        #region FInquiryProgress Form Event Handler

        private void FInquiryProgress_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                Pgb.Minimum = 0;
                Pgb.Maximum = m_reqCount;
                Pgb.Value = 0;
                // --

                this.lblPercentage.Text = "0 %";
                this.lblCollectCount.Text = string.Format("{0} : 0", this.fUIWizard.searchCaption("Collected Data"));
                this.lblRemaining.Text = string.Format("{0}...", this.fUIWizard.searchCaption("Calculating"));
                // --
                
                this.BeginInvoke(new MethodInvoker(
                    delegate()
                    {
                        procProcess();
                    }
                ));
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FInquiryProgress_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
               
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

        #region btnStop Control Event Handler

        private void btnStop_Click(
            object sender, 
            EventArgs e
            )
        {
            EventHandler<EventArgs> args = null;

            try
            {
                if ((args = Canceled) != null)
                {
                    args(this, e);
                }

                // --

                this.lblRemaining.Text = "Stopping...";
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                args = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
