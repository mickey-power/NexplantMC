/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FGridCommon.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.12
--  Description     : FAMate Core FaUIs Grid Common Function Class
--  History         : Created by spike.lee at 2011.01.12
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
    internal static class FGridCommon
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        static FGridCommon(
            )
        {

        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static Appearance getHeaderAppearance(
            )
        {
            Appearance appearance = null;

            try
            {
                appearance = new Appearance();
                appearance.BackColor = Color.LightSteelBlue;
                appearance.BackColor2 = Color.Lavender;
                appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                appearance.BorderColor = Color.Silver;
                appearance.ForeColor = Color.Black;
                appearance.ForeColorDisabled = Color.Black;
                appearance.TextHAlign = HAlign.Center;
                appearance.TextVAlign = VAlign.Middle;
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

        //------------------------------------------------------------------------------------------------------------------------

        public static Appearance getRowCellAppearance(
            )
        {
            Appearance appearance = null;

            try
            {
                appearance = new Appearance();
                appearance.BackColor = Color.WhiteSmoke;
                appearance.BorderColor = Color.Silver;
                appearance.ForeColor = Color.Black;
                appearance.TextVAlign = VAlign.Middle;
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

        //------------------------------------------------------------------------------------------------------------------------

        public static Appearance getAppearance(
            )
        {
            Appearance appearance = null;

            try
            {
                appearance = new Appearance();                
                appearance.BackColor = Color.WhiteSmoke;
                appearance.BorderColor = Color.Silver;
                appearance.ForeColor = Color.Black;
                appearance.TextVAlign = VAlign.Middle;
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

        //------------------------------------------------------------------------------------------------------------------------

        public static Appearance getActiveAppearance(
            )
        {
            Appearance appearance = null;

            try
            {
                appearance = new Appearance();
                appearance.BackColor = Color.WhiteSmoke;
                appearance.BackColor2 = Color.LightSteelBlue;
                appearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
                appearance.BorderColor = Color.Silver;
                appearance.ForeColor = Color.Black;
                appearance.TextVAlign = VAlign.Middle;
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

        //------------------------------------------------------------------------------------------------------------------------

        public static Appearance getSelectedAppearance(
            )
        {
            Appearance appearance = null;

            try
            {
                appearance = new Appearance();
                appearance.BackColor = Color.WhiteSmoke;
                appearance.BackColor2 = Color.LightGray;
                appearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
                appearance.BorderColor = Color.Silver;
                appearance.ForeColor = Color.Black;
                appearance.TextVAlign = VAlign.Middle;
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

        //------------------------------------------------------------------------------------------------------------------------

        public static void designGrid(
            UltraGrid grid
            )
        {
            try
            {
                grid.Font = new Font("Verdana", 8.25F);
                grid.DataSource = new UltraDataSource();

                // --                

                grid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                grid.DisplayLayout.TabNavigation = TabNavigation.NextControl;
                grid.DisplayLayout.UseFixedHeaders = true;

                // --

                grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
                grid.DisplayLayout.Override.AllowColMoving = AllowColMoving.NotAllowed;
                grid.DisplayLayout.Override.AllowColSizing = AllowColSizing.Free;
                grid.DisplayLayout.Override.AllowColSwapping = AllowColSwapping.NotAllowed;
                grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
                grid.DisplayLayout.Override.AllowMultiCellOperations = AllowMultiCellOperation.None;
                grid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
                // --
                grid.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
                grid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
                grid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;

                // --

                grid.DisplayLayout.ScrollBarLook.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
                grid.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
                grid.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;

                // --

                grid.DisplayLayout.Appearance = getAppearance();

                // --

                grid.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
                grid.DisplayLayout.Override.HeaderAppearance = getHeaderAppearance();

                // --

                grid.DisplayLayout.Override.RowAppearance = getRowCellAppearance();
                grid.DisplayLayout.Override.CellAppearance = grid.DisplayLayout.Override.RowAppearance;                     

                // --

                grid.UseFlatMode = DefaultableBoolean.True;
                grid.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
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

        public static void designRowGrid(
            UltraGrid grid
            )
        {
            try
            {
                FGridCommon.designGrid(grid);

                // --

                grid.DisplayLayout.Override.ActiveRowAppearance = getActiveAppearance();
                grid.DisplayLayout.Override.SelectedRowAppearance = getSelectedAppearance();                

                // --

                grid.DisplayLayout.Override.SelectTypeCell = SelectType.None;
                grid.DisplayLayout.Override.SelectTypeCol = SelectType.None;
                grid.DisplayLayout.Override.SelectTypeGroupByRow = SelectType.None;                                
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

        public static void designColumnGrid(
            UltraGrid grid
            )
        {
            try
            {
                FGridCommon.designGrid(grid);

                // --

                grid.DisplayLayout.Override.ActiveRowAppearance = grid.DisplayLayout.Override.RowAppearance;
                grid.DisplayLayout.Override.SelectedRowAppearance = grid.DisplayLayout.Override.RowAppearance;

                // --

                grid.DisplayLayout.Override.ActiveCellAppearance = getActiveAppearance();
                grid.DisplayLayout.Override.SelectedCellAppearance = getSelectedAppearance();

                // --

                grid.DisplayLayout.Override.SelectTypeCol = SelectType.None;
                grid.DisplayLayout.Override.SelectTypeGroupByRow = SelectType.None;                
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
