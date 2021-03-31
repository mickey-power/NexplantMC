/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FNumericBox.cs
--  Creator         : mj.kim
--  Create Date     : 2011.08.25
--  Description     : FAMate Core FaUIs Numeric Edit Box Control
--  History         : Created by mj.kim at 2011.08.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

using Infragistics.Win.UltraWinEditors;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FNumericBox : UltraNumericEditor
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FNumericBox(
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
                this.HandleCreated += new EventHandler(FNumericBox_HandleCreated);
                this.ButtonsLeft.ItemAdding += new EditorButtonEventHandler(ButtonsLeft_ItemAdding);
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
                this.HandleCreated -= new EventHandler(FNumericBox_HandleCreated);
                this.ButtonsLeft.ItemAdding -= new EditorButtonEventHandler(ButtonsLeft_ItemAdding);
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

        #region FNumericBox Control Event Handler

        private void FNumericBox_HandleCreated(
            object sender,
            EventArgs e
            )
        {
            // int i = 0;

            try
            {
                //this.Font = new Font("Verdana", 9F);
                //// --
                //this.Appearance.BackColor = Color.White;
                //this.Appearance.BorderColor = Color.Silver;
                //// --
                //this.AutoSize = false;
                //this.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
                //this.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
                //this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;

                //for (i = 0; i < this.ButtonsLeft.Count; i++)
                //{
                //    if (this.ButtonsLeft[i] is StateEditorButton)
                //    {
                //        this.ButtonsLeft[i].Appearance = FNumericBoxCommon.stateButtonAppearance;
                //    }
                //}

                //for (i = 0; i < this.ButtonsRight.Count; i++)
                //{
                //    if (this.ButtonsRight[i] is SpinEditorButton)
                //    {
                //        this.ButtonsRight[i].Appearance = FNumericBoxCommon.spinButtonAppearance;
                //    }
                //}
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FNumericBox", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        void ButtonsLeft_ItemAdding(
            object sender, 
            EditorButtonEventArgs e
            )
        {
            try
            {
                if (e.Button is StateEditorButton)
                {
                    e.Button.Appearance = FNumericBoxCommon.stateButtonAppearance;
                }
                else if (e.Button is SpinEditorButton)
                {
                    e.Button.Appearance = FNumericBoxCommon.spinButtonAppearance;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FNumericBox", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
