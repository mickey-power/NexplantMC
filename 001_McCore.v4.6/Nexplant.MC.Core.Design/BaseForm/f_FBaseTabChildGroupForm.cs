/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FBaseTabChildGroupForm.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.25
--  Description     : FAMate Core FaUIs Base TAB Child Group Form Class
--  History         : Created by spike.lee at 2011.01.25
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
    public partial class FBaseTabChildGroupForm : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private List<UltraTile> m_tileList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FBaseTabChildGroupForm(
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

        public FBaseControlForm[] fChilds
        {
            get
            {
                FBaseControlForm[] array = null;

                try
                {
                    array = new FBaseControlForm[tpnClient.Tiles.Count];
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = (FBaseControlForm)tpnClient.Tiles[i].Control;
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

        private void addTile(
            UltraTile tile
            )
        {
            try
            {
                if (m_tileList.Contains(tile))
                {
                    m_tileList.Remove(tile);
                }
                m_tileList.Insert(0, tile);
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
                fControlFormBase.FormClosed += new FormClosedEventHandler(fControlFormBase_FormClosed);
                // --
                fControlFormBase.Show();
                tile.State = tileState;         
       
                // --

                addTile(tile);
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

        #region FBaseTabChildGroupForm Form Event Handler

        private void FBaseTabChildGroupForm_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                m_tileList = new List<UltraTile>();
                // --
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

        private void FBaseTabChildGroupForm_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            UltraTile t = null;

            try
            {
                tpnClient.TileStateChanged -= new TileStateChangedEventHandler(tpnClient_TileStateChanged);
                tpnClient.TileClosing -= new TileClosingEventHandler(tpnClient_TileClosing);
        
                // --

                for (int i = tpnClient.Tiles.Count - 1; i >= 0; i--)
                {
                    t = tpnClient.Tiles[i];
                    // --
                    if (t.Control != null)
                    {
                        ((FBaseControlForm)t.Control).Close();
                    }
                }

                // --

                m_tileList = null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                t = null;
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
                    // --
                    addTile(e.Tile);
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

                    // --

                    m_tileList.Remove(e.Tile);
                    if (m_tileList.Count > 0)
                    {
                        m_tileList[0].State = TileState.Large;
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

        #endregion               

        //------------------------------------------------------------------------------------------------------------------------

        #region fConrolFormBase Form Event Handler

        private void fControlFormBase_FormClosed(
            object sender, 
            FormClosedEventArgs e
            )
        {
            UltraTile ownerTile = null;

            try
            {
                ((FBaseControlForm)sender).FormClosed -= new FormClosedEventHandler(fControlFormBase_FormClosed);

                //--

                foreach (UltraTile t in tpnClient.Tiles)
                {
                    if (t.Control == sender)
                    {
                        ownerTile = t;
                        break;
                    }
                }

                // --

                if (ownerTile != null)
                {
                    ownerTile.Control = null;
                    tpnClient.Tiles.Remove(ownerTile);
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
