/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FBaseStandardGroupForm.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.17
--  Description     : FAMate Core FaUIs Base Standard Group Form Class
--  History         : Created by spike.lee at 2011.01.17
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Nexplant.MC.Core.FaCommon;
using Infragistics.Win.Misc;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FBaseStandardGroupForm : Nexplant.MC.Core.FaUIs.FBaseStandardForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FBaseStandardGroupForm(
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

                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FBaseTabChildForm[] fChilds
        {
            get
            {
                FBaseTabChildForm[] array = null;

                try
                {
                    array = new FBaseTabChildForm[tpnClient.Tiles.Count];
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = (FBaseTabChildForm)tpnClient.Tiles[i].Control;
                    }
                    return array;
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

        public void showChild(
            FBaseControlForm fControlFormBase
            )
        {
            try
            {
                showChild(fControlFormBase, TileState.Normal);
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

        public void showChild(
            FBaseControlForm fControlFormBase,
            TileState tileState
            )
        {
            UltraTile tile = null;

            try
            {
                fControlFormBase.TopLevel = false;
                // --
                if (base.fUIWizard == null)
                {
                    tile = new UltraTile(fControlFormBase.Text);
                }
                else
                {
                    tile = new UltraTile(base.fUIWizard.searchCaption(fControlFormBase.Text));
                }
                tile.Control = fControlFormBase;
                // --
                fControlFormBase.BringToFront();
                fControlFormBase.setTile(tile);
                tpnClient.Tiles.Add(tile);
                // --
                fControlFormBase.Show();
                tile.State = tileState;
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

        public FBaseControlForm getChild(
            Type type
            )
        {
            try
            {
                foreach (UltraTile t in tpnClient.Tiles)
                {
                    if (t.Control == null)
                    {
                        continue;
                    }

                    if (((FBaseControlForm)t.Control).GetType() == type)
                    {
                        return (FBaseControlForm)t.Control;
                    }
                }
                return null;
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

        public FBaseControlForm getChild(
            string name
            )
        {
            try
            {
                foreach (UltraTile t in tpnClient.Tiles)
                {
                    if (t.Control == null)
                    {
                        continue;
                    }

                    if (((FBaseControlForm)t.Control).Name == name)
                    {
                        return (FBaseControlForm)t.Control;
                    }
                }
                return null;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FBaseStandardGroupForm Form Event Handler

        private void FBaseStandardGroupForm_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                tpnClient.TileStateChanged += new TileStateChangedEventHandler(tpnClient_TileStateChanged);
                tpnClient.TileClosing += new TileClosingEventHandler(tpnClient_TileClosing);
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseTabChildGroupForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FBaseStandardGroupForm_FormClosing(
            object sender,
            FormClosingEventArgs e
            )
        {
            try
            {
                tpnClient.TileStateChanged -= new TileStateChangedEventHandler(tpnClient_TileStateChanged);
                tpnClient.TileClosing -= new TileClosingEventHandler(tpnClient_TileClosing);
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

        #region tpnClient Control Event Handler

        private void tpnClient_TileStateChanged(
            object sender,
            TileStateChangedEventArgs e
            )
        {
            try
            {
                if (e.Tile.State == TileState.Large)
                {
                    if (e.Tile.Control != null)
                    {
                        ((FBaseControlForm)e.Tile.Control).activate();
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseTabChildGroupForm", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tpnClient_TileClosing(
            object sender,
            TileClosingEventArgs e
            )
        {
            try
            {
                if (e.Tile.Control != null)
                {
                    ((FBaseControlForm)e.Tile.Control).Close();
                    if (e.Tile.Control != null)
                    {
                        e.Cancel = true;
                        return;
                    }
                    e.Tile.Control = null;
                    tpnClient.Tiles.Remove(e.Tile);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseTabChildGroupForm", ex, null);
            }
            finally
            {

            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
