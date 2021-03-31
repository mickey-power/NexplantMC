/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FTextBox.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.03
--  Description     : FAMate Core FaUIs Normal Text Box Control
--  History         : Created by spike.lee at 2011.01.03
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
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FTextBox : UltraTextEditor
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTextBox(
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
                this.HandleCreated += new EventHandler(FTextBox_HandleCreated);
                this.ButtonsLeft.ItemAdding += new EditorButtonEventHandler(ButtonsLeft_ItemAdding);
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
                this.HandleCreated -= new EventHandler(FTextBox_HandleCreated);
                this.ButtonsLeft.ItemAdding -= new EditorButtonEventHandler(ButtonsLeft_ItemAdding);
                this.ButtonsRight.ItemAdding -= new EditorButtonEventHandler(ButtonsRight_ItemAdding);
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

        #region FTextBox Control Event Handler

        private void FTextBox_HandleCreated(
            object sender, 
            EventArgs e
            )
        {
            try
            {

            }
            catch (Exception ex)
            {
                FMessageBox.showError("FTextBox", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void ButtonsLeft_ItemAdding(
            object sender,
            EditorButtonEventArgs e
            )
        {
            try
            {
                if (e.Button is StateEditorButton)
                {
                    e.Button.Appearance = FTextBoxCommon.stateButtonAppearance;
                }                
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FTextBox", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void ButtonsRight_ItemAdding(
            object sender,
            EditorButtonEventArgs e
            )
        {
            try
            {
                if (e.Button is EditorButton)
                {
                    e.Button.Appearance = FTextBoxCommon.editButtonAppearance;                    
                    ((EditorButton)e.Button).PressedAppearance = FTextBoxCommon.editButtonPressedAppearance;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FTextBox", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end