/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FBaseControlForm.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.25
--  Description     : FAMate Core FaUIs Base Control Form Class
--  History         : Created by spike.lee at 2011.01.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Infragistics.Win.Misc;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FBaseControlForm : Nexplant.MC.Core.FaUIs.FBaseForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private UltraTile m_tile = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FBaseControlForm(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_tile = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public UltraTile tile
        {
            get
            {
                try
                {
                    return m_tile;
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

        internal void setTile(
            UltraTile tile
            )
        {
            try
            {
                m_tile = tile;
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

        public void activate(
            )
        {
            try
            {
                m_tile.State = TileState.Large;
                this.Activate();
                foreach (Control t in this.Controls)
                {
                    if (t.CanFocus)
                    {
                        t.Focus();
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

        #region FBaseControlForm Form Event Handler

        private void FBaseControlForm_TextChanged(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                if (m_tile != null)
                {
                    m_tile.Caption = this.Text;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseControlForm", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
