/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FExplorerBar.cs
--  Creator         : mj.kim
--  Create Date     : 2011.09.30
--  Description     : FAMate Core FaUIs ExplorerBar Control
--  History         : Created by mj.kim at 2011.09.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using Infragistics.Win;
using Infragistics.Win.UltraWinExplorerBar;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FExplorerBar : UltraExplorerBar 
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FExplorerBar(
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
                this.HandleCreated += new EventHandler(FExplorerBar_HandleCreated);
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
                this.HandleCreated -= new EventHandler(FExplorerBar_HandleCreated);
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

        public Appearance getActiveAppearance(
            )
        {
            Appearance appearance = null;

            try
            {
                appearance = new Appearance();
                appearance.BackColor = Color.LightSteelBlue;
                appearance.BorderColor = Color.Silver;
                appearance.FontData.Bold = DefaultableBoolean.True;
                appearance.ForeColor = Color.Black;
                appearance.Image = Properties.Resources.FExplorerbar_Item_Checked;
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

        public void beginUpdate(
            )
        {
            try
            {
                this.BeginUpdate();
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

        public void endUpdate(
            )
        {
            try
            {
                this.EndUpdate();
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

        #region FExplorerBar Control Event Handler

        private void FExplorerBar_HandleCreated(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                //this.Font = new Font("Verdana", 9F);
                //// --
                //this.Appearance.BackColor = Color.WhiteSmoke;//System.Drawing.Color.FromArgb(246, 250, 254);
                ////this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(214, 222, 234);
                //this.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.None;//.Vertical;
                //this.Appearance.BorderColor = Color.Silver;
                //this.Appearance.ForeColor = Color.Black;
                //// --
                //this.GroupSettings.HeaderVisible = Infragistics.Win.DefaultableBoolean.False;
                //this.GroupSettings.AppearancesSmall.Appearance.BackColor = Color.Transparent;
                //this.GroupSettings.AppearancesSmall.Appearance.BackGradientStyle = GradientStyle.None;
                //// --
                //this.ItemSettings.AppearancesSmall.Appearance.BackColor = Color.Transparent;
                //this.ItemSettings.AppearancesSmall.Appearance.BackGradientStyle = GradientStyle.None;
                //this.ItemSettings.AppearancesSmall.Appearance.BorderColor = Color.Transparent;
                //this.ItemSettings.AppearancesSmall.Appearance.Image = Properties.Resources.FExplorerbar_Item;
                //this.ItemSettings.AppearancesSmall.ActiveAppearance = getActiveAppearance();
                //// --
                //this.AutoSize = false;
                //this.ShowDefaultContextMenu = false;
                //this.Style = UltraExplorerBarStyle.VisualStudio2005Toolbox;
                //this.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                //this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                
                // --
                
                this.Groups.Clear();
                this.Groups.Add("Default Group", "New Group");
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FExplorerBar", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
