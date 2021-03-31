/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FSplitter.cs
--  Creator         : mj.kim
--  Create Date     : 2011.10.25
--  Description     : FAMate Core FaUIs Splitter Control
--  History         : Created by mj.kim at 2011.10.25
----------------------------------------------------------------------------------------------------------*/
using System;
using Infragistics.Win.Misc;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FSplitter : UltraSplitter
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSplitter(
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
                this.HandleCreated += new EventHandler(FSplitter_HandleCreated);
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
                this.HandleCreated -= new EventHandler(FSplitter_HandleCreated);
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

        #region FSplitter Control Event Handler

        private void FSplitter_HandleCreated(
            object sender, 
            EventArgs e
            )
        {
            try
            {

                //this.Appearance.BackColor = Color.Transparent;
                //// --
                //this.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
                //// --
                //this.ButtonAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20;
                //// --
                //this.ButtonExtent = 100;
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FSplitter", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
