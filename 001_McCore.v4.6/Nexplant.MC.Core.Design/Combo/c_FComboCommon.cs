/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FComboCommon.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.16
--  Description     : FAMate Core FaUIs Combo Common Function Class
--  History         : Created by spike.lee at 2011.03.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinDataSource;

namespace Nexplant.MC.Core.FaUIs
{
    internal static class FComboCommon
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        static FComboCommon(
            )
        {

        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

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

        public static void designCombo(
            UltraCombo combo
            )
        {
            try
            {
                combo.Font = new Font("Verdana", 9F);
                combo.DataSource = new UltraDataSource();

                // --

                combo.Appearance.BackColor = Color.White;
                combo.Appearance.BorderColor = Color.Silver;
                combo.AutoSize = false;
                combo.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                combo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
                combo.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                combo.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;

                // --

                combo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                combo.DisplayLayout.TabNavigation = TabNavigation.NextControl;
                combo.DisplayLayout.UseFixedHeaders = true;

                // --

                combo.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
                combo.DisplayLayout.Override.AllowColMoving = AllowColMoving.NotAllowed;
                combo.DisplayLayout.Override.AllowColSizing = AllowColSizing.Free;
                combo.DisplayLayout.Override.AllowColSwapping = AllowColSwapping.NotAllowed;
                combo.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
                combo.DisplayLayout.Override.AllowMultiCellOperations = AllowMultiCellOperation.None;
                combo.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                combo.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
                // --
                combo.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
                combo.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
                combo.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;

                // --

                combo.DisplayLayout.ScrollBarLook.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
                combo.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
                combo.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;

                // --

                combo.DisplayLayout.Appearance.FontData.SizeInPoints = 8.25F;

                combo.DisplayLayout.Appearance.BackColor = Color.White;
                combo.DisplayLayout.Appearance.BorderColor = Color.Silver;
                combo.DisplayLayout.Appearance.ForeColor = Color.Black;
                combo.DisplayLayout.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;

                // --

                combo.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard;
                combo.DisplayLayout.Override.HeaderAppearance.BackColor = Color.LightSteelBlue;
                combo.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.Lavender;
                combo.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                combo.DisplayLayout.Override.HeaderAppearance.BorderColor = Color.Silver;
                combo.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.Black;
                combo.DisplayLayout.Override.HeaderAppearance.ForeColorDisabled = Color.Black;
                combo.DisplayLayout.Override.HeaderAppearance.TextHAlign = HAlign.Center;
                combo.DisplayLayout.Override.HeaderAppearance.TextVAlign = VAlign.Middle;

                // --

                combo.DisplayLayout.Override.RowAppearance.BackColor = Color.White;
                combo.DisplayLayout.Override.RowAppearance.BorderColor = Color.Silver;
                combo.DisplayLayout.Override.RowAppearance.ForeColor = Color.Black;
                combo.DisplayLayout.Override.RowAppearance.TextVAlign = VAlign.Middle;

                // --

                combo.DisplayLayout.Override.CellAppearance = combo.DisplayLayout.Override.RowAppearance;

                // --

                combo.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.WhiteSmoke;
                combo.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = Color.LightSteelBlue;
                combo.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
                combo.DisplayLayout.Override.ActiveRowAppearance.BorderColor = Color.Silver;
                combo.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;
                combo.DisplayLayout.Override.ActiveRowAppearance.TextVAlign = VAlign.Middle;

                // --

                combo.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.WhiteSmoke;
                combo.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = Color.LightGray;
                combo.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
                combo.DisplayLayout.Override.SelectedRowAppearance.BorderColor = Color.Silver;
                combo.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Black;
                combo.DisplayLayout.Override.SelectedRowAppearance.TextVAlign = VAlign.Middle;

                // --

                combo.DisplayLayout.Override.SelectTypeCell = SelectType.None;
                combo.DisplayLayout.Override.SelectTypeCol = SelectType.None;
                combo.DisplayLayout.Override.SelectTypeGroupByRow = SelectType.None;   

                // --

                combo.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;

                // --                

                combo.DisplayLayout.ViewStyle = ViewStyle.SingleBand;
                combo.DisplayLayout.ViewStyleBand = ViewStyleBand.Vertical;

                // --                

                combo.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
                combo.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
                combo.DisplayLayout.Override.AllowColSizing = AllowColSizing.Free;

                // --                

                combo.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;
                combo.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;

                // --                

                combo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
                combo.DisplayLayout.Override.RowSizing = RowSizing.Fixed;

                // --

                combo.DisplayLayout.Override.TipStyleCell = TipStyle.Hide;
                combo.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;    

                // --

                combo.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
                combo.DisplayLayout.Override.SelectTypeRow = SelectType.Single;
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
