/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FDateTimeBox.cs
--  Creator         : mj.kim
--  Create Date     : 2011.08.30
--  Description     : FAMate Core FaUIs DateTime Edit Box Control
--  History         : Created by mj.kim at 2011.08.30
----------------------------------------------------------------------------------------------------------*/
using System;
using Infragistics.Win.UltraWinEditors;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FDateTimeBox : UltraDateTimeEditor
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDateTimeBox(
            )
        {
            InitializeComponent();
            // --
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
                this.ButtonsLeft.ItemAdding +=new EditorButtonEventHandler(ButtonsLeft_ItemAdding);
                this.ButtonsRight.ItemAdding += new EditorButtonEventHandler(ButtonsRight_ItemAdding);
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
                this.ButtonsLeft.ItemAdding -= new EditorButtonEventHandler(ButtonsLeft_ItemAdding);
                this.ButtonsRight.ItemAdding += new EditorButtonEventHandler(ButtonsRight_ItemAdding);
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

        #region FDateTimeBox Control Event Handler

        void ButtonsLeft_ItemAdding(
            object sender,
            EditorButtonEventArgs e
            )
        {
            try
            {
                if (e.Button is StateEditorButton)
                {
                    e.Button.Appearance = FDateTimeBoxCommon.stateButtonAppearance;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FDateTimeBox", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        void ButtonsRight_ItemAdding(
            object sender, 
            EditorButtonEventArgs e
            )
        {
            try
            {
                if (e.Button is SpinEditorButton)
                {
                    this.Appearance = FDateTimeBoxCommon.spinButtonAppearance;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FDateTimeBox", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
