/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FTitleLabel.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.15
--  Description     : FAMate Core FaUIs Title Label Control
--  History         : Created by spike.lee at 2011.03.15
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
using Infragistics.Win;
using Infragistics.Win.Misc;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FTitleLabel : UltraLabel
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTitleLabel(
            )
        {
            InitializeComponent();
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void myDispose(
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
                this.HandleCreated += new EventHandler(FTitleLabel_HandleCreated);
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
                this.HandleCreated -= new EventHandler(FTitleLabel_HandleCreated);
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

        #region FTitleLabel Control Event Handler

        private void FTitleLabel_HandleCreated(
            object sender,
            EventArgs e
            )
        {
            try
            {
                //this.Font = new Font("Verdana", 9F);
                //// --
                //this.BorderStyleOuter = UIElementBorderStyle.Solid;
                //this.Appearance.BackColor = Color.LightSteelBlue;
                //this.Appearance.BackColor2 = Color.Lavender;
                //this.Appearance.BackGradientStyle = GradientStyle.Vertical;
                //this.Appearance.BorderColor = Color.Silver;                
                //this.Appearance.ForeColor = Color.Black;
                //this.Appearance.TextHAlign = HAlign.Center;
                //this.Appearance.TextVAlign = VAlign.Middle;
                //// --
                //this.UseOsThemes = DefaultableBoolean.False;
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FTitleLabel", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
