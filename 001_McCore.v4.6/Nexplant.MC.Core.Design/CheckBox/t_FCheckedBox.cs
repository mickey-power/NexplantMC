/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FCheckedBox.cs
--  Creator         : mj.kim
--  Create Date     : 2011.08.30
--  Description     : FAMate Core FaUIs Checked Edit Box Control
--  History         : Created by mj.kim at 2011.08.30
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
    public partial class FCheckedBox : UltraCheckEditor
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FCheckedBox(
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
                this.HandleCreated += new EventHandler(FCheckedBox_HandleCreated);
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
                this.HandleCreated -= new EventHandler(FCheckedBox_HandleCreated);
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

        #region FCheckedBox Control Event Handler

        private void FCheckedBox_HandleCreated(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                //this.Font = new Font("Verdana", 9F);
                //// --
                //this.Appearance.BackColor = Color.Transparent;
                //this.Appearance.BorderColor = Color.Silver;
                //this.Appearance.ForeColor = Color.Black;
                //// --
                //this.AutoSize = false;
                //this.GlyphInfo = Infragistics.Win.UIElementDrawParams.Office2010CheckBoxGlyphInfo;
                //this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                //this.Height = 21;
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FCheckedBox", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
