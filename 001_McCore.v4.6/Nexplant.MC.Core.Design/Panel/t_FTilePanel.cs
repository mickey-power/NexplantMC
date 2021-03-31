/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FTilePancel.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.17
--  Description     : FAMate Core FaUIs Tile Panel Control
--  History         : Created by spike.lee at 2011.01.17
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
    public partial class FTilePanel : UltraTilePanel
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTilePanel(
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
                this.HandleCreated += new EventHandler(FTilePanel_HandleCreated);
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
                this.HandleCreated -= new EventHandler(FTilePanel_HandleCreated);
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

        #region FTilePanel Control Event Handler

        private void FTilePanel_HandleCreated(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                //this.Font = new Font("Verdana", 9F);
                //// --
                //this.Appearance.BackColor = Color.WhiteSmoke;
                //// --
                //this.ScrollBarLook.ShowMinMaxButtons = DefaultableBoolean.True;
                //this.ScrollBarLook.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
                //// --
                //this.TileSettings.Appearance.BackColor = Color.WhiteSmoke;
                //this.TileSettings.Appearance.BorderColor = Color.DarkGray;
                //// --
                //this.TileSettings.HeaderAppearance.BackColor = Color.LightSteelBlue;
                //this.TileSettings.HeaderAppearance.BackColor2 = Color.Lavender;
                //this.TileSettings.HeaderAppearance.BackGradientStyle = GradientStyle.Vertical;
                //this.TileSettings.HeaderAppearance.BorderColor = Color.LightSteelBlue;
                ////
                //this.TileSettings.ShowCloseButton = DefaultableBoolean.True;
                //this.TileSettings.ShowStateChangeButton = DefaultableBoolean.True;
                //// --
                //this.UseOsThemes = DefaultableBoolean.False;
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FTilePanel", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
