/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FProgressDialog.cs
--  Creator         : spike.lee
--  Create Date     : 2010.11.26
--  Description     : FAMate Core FaCommon Progress Dialog Form
--  History         : Created by spike.lee at 2010.11.26
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FProgressDialog : Form
    {

        //------------------------------------------------------------------------------------------------------------------------

        internal const int DialogWidth = 130;
        internal const int DialogHeight = 128;

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FProgressDialog(
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

        #region FProgressDialog Form Event Handler

        private void FProgressDialog_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                this.Region = new Region(
                    FGraphics.calculateGraphicsPath(new Bitmap(picBox.Image))
                    );
            }
            catch (Exception ex)
            {
                FMessageBox.showError("Progress Dialog", ex, this);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
