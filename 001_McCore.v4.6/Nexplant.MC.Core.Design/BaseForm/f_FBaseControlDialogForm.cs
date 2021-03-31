/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FBaseControlForm.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.25
--  Description     : FAMate Core FaUIs Base Control Form Class
--  History         : Created by spike.lee at 2011.01.25
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
    public partial class FBaseControlDialogForm : Nexplant.MC.Core.FaUIs.FBaseControlForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FBaseControlDialogForm(
            )
        {
            InitializeComponent();
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FBaseControlDialogForm Form Event Handler

        private void FBaseControlDialogForm_Paint(
            object sender, 
            PaintEventArgs e
            )
        {
            try
            {
                FFormCommon.paintDialogAreaBar(this.BackColor, this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseControlDialogForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FBaseControlDialogForm_Resize(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FFormCommon.paintDialogAreaBar(this.BackColor, this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseControlDialogForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FBaseControlDialogForm_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FFormCommon.dockDialogClientArea(this, pnlDialogClient);
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseControlDialogForm", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
