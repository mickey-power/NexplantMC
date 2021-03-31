/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTextBoxCommon.cs
--  Creator         : mj.kim
--  Create Date     : 2012.05.04
--  Description     : FAMate Core FaUIs TextBox Common Function Class
--  History         : Created by mj.kim at 2012.05.04
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    internal static class FTextBoxCommon
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        static FTextBoxCommon(
            )
        {

        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public static Appearance stateButtonAppearance
        {
            get
            {
                Appearance appearance = null;

                try
                {
                    appearance = new Appearance();
                    appearance.BackColorAlpha = Alpha.Transparent;
                    appearance.BorderColor = Color.Transparent;
                    return appearance;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static Appearance editButtonAppearance
        {
            get
            {
                Appearance appearance = null;

                try
                {
                    appearance = new Appearance();
                    appearance.BackColor = Color.Transparent;
                    appearance.Image = Properties.Resources.ToolEdit;
                    appearance.ImageHAlign = HAlign.Center;
                    return appearance;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static Appearance editButtonDisabledAppearance
        {
            get
            {
                Appearance appearance = null;

                try
                {
                    appearance = new Appearance();
                    // --
                    return appearance;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static Appearance editButtonPressedAppearance
        {
            get
            {
                Appearance appearance = null;

                try
                {
                    appearance = new Appearance();
                    appearance.Image = Properties.Resources.ToolEdit_Clicked;
                    appearance.ImageHAlign = HAlign.Center;
                    return appearance;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static void designTextBox(
            UltraTextEditor textBox
            )
        {
            try
            {
                textBox.Font = new Font("Verdana", 9F);
                // --
                textBox.Appearance.BackColor = Color.White;
                textBox.Appearance.BorderColor = Color.Silver;
                textBox.Appearance.ForeColor = Color.Black;
                // --
                textBox.AutoSize = false;
                textBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                textBox.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
                textBox.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                textBox.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                // --
                textBox.Height = 21;

                // --

                for (int i = 0; i < textBox.ButtonsLeft.Count; i++)
                {
                    if (textBox.ButtonsLeft[i] is Infragistics.Win.UltraWinEditors.StateEditorButton)
                    {
                        textBox.ButtonsLeft[i].Appearance = FTextBoxCommon.stateButtonAppearance;
                    }
                }

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

    }   // Class end
}   // Namespace end
