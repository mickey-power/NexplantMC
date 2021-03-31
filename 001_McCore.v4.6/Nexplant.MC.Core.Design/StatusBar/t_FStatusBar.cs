/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FStatusBar.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.04
--  Description     : FAMate Core FaUIs Status Bar Control
--  History         : Created by spike.lee at 2011.01.04
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Infragistics.Win.UltraWinStatusBar;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FStatusBar : UltraStatusBar
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FStatusBar(
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
                this.HandleCreated += new EventHandler(FStatusBar_HandleCreated);
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
                this.HandleCreated -= new EventHandler(FStatusBar_HandleCreated);
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

        #region FStatusBar Control Event Handler

        private void FStatusBar_HandleCreated(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                //this.Appearance.FontData.Name = "Verdana";
                //this.Appearance.FontData.SizeInPoints = 8.25F;
                //this.BorderStylePanel = Infragistics.Win.UIElementBorderStyle.Solid;
                //this.Padding.Top = 2;
                //this.PanelAppearance.BorderColor = Color.White;
                //this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                //this.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2007;
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FStatusBar", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
