/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FBaseStandardDialogForm.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.17
--  Description     : FAMate Core FaUIs Base Standard Dialog Form Class
--  History         : Created by spike.lee at 2011.01.17
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FBaseStandardDialogForm : Nexplant.MC.Core.FaUIs.FBaseStandardForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private bool m_resizable = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FBaseStandardDialogForm(
            )
        {
            InitializeComponent();
            // --
            m_resizable = true;
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

                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties
                
        public bool resizable
        {
            get
            {
                try
                {
                    return m_resizable;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError("FBaseStandardDialogForm", ex, null);
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
                    m_resizable = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError("FBaseStandardDialogForm", ex, null);
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
            if (
                m.Msg == (int)FNativeAPIs.FWinMsgs.WM_SETCURSOR ||
                (m.Msg == (int)FNativeAPIs.FWinMsgs.WM_NCLBUTTONDOWN && m.WParam.ToInt32() != (int)FNativeAPIs.FNCHITTEST.HTCAPTION)
                )
            {
                try
                {
                    if (!m_resizable)
                    {
                        return;
                    }                        
                }
                catch (Exception ex)
                {
                    FMessageBox.showError("FBaseStandardDialogForm", ex, null);
                }
                finally
                {

                }
            }            
            base.WndProc(ref m);
        }

        #endregion

        //-------------------------------------------------------------------------------------------------------------------------

        #region FBaseStandardDialogForm Form Event Handler

        private void FBaseStandardDialogForm_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FFormCommon.dockDialogClientArea(pnlClient, pnlDialogClient);
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardDialogForm", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //-------------------------------------------------------------------------------------------------------------------------

        #region pnlClient Control Event Handler

        private void pnlClient_Paint(
            object sender, 
            PaintEventArgs e
            )
        {
            try
            {
                FFormCommon.paintDialogAreaBar(this.BackColor, base.pnlClient);
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardDialogForm", ex, null);
            }
            finally
            {

            }
        }

        //-------------------------------------------------------------------------------------------------------------------------

        private void pnlClient_Resize(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FFormCommon.paintDialogAreaBar(this.BackColor, base.pnlClient);
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseStandardDialogForm", ex, null);
            }
            finally
            {

            }
        }

        #endregion        

        //-------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namepsace end
