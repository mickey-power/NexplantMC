/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FButton.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.29
--  Description     : FAMate Core FaUIs Normal Button Control
--  History         : Created by spike.lee at 2010.12.29
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.Misc;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FToolButton : UltraButton
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FToolButton(
            )
        {
            InitializeComponent();
            init();
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                this.HandleCreated += new EventHandler(FToolButton_HandleCreated);
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
                this.HandleCreated -= new EventHandler(FToolButton_HandleCreated);
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

        #region FToolButton Control Event Handler

        private void FToolButton_HandleCreated(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                //this.Font = new Font("Verdana", 9F);
                //this.AcceptsFocus = true;
                //this.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
                //this.ShowFocusRect = false;
                //this.ShowOutline = false;
                //this.Size = new Size(21, 21);
                //this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                //this.Text = string.Empty;
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FToolButton", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
