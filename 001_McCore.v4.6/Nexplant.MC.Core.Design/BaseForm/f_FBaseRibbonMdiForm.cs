/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FBaseRibbonMdiForm.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.29
--  Description     : FAMate Core FaUIs Ribbon MDI Form Base Class
--  History         : Created by spike.lee at 2010.12.29
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FBaseRibbonMdiForm : FBaseForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // -- 
        private Color m_backColor;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FBaseRibbonMdiForm(
            )
        {
            InitializeComponent();
            // -- 
            m_backColor = this.BackColor;
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

        public Color backColor
        {
            get
            {
                try
                {
                    return this.m_backColor;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    
                }
                return Color.Silver;
            }

            set
            {
                MdiClient mdiControl = null;

                try
                {
                    foreach (Control control in this.Controls)
                    {
                        // ***
                        // 2014.05.27 by spike.lee
                        // 아래 코드 적용 시, Form의 Activate 및 Closing 이벤트가 발생하지 않는 문제로 우선 주석 처리합니다.
                        // ***
                        //if (
                        //    control is FStatusBar ||
                        //    control is Infragistics.Win.UltraWinDock.AutoHideControl ||
                        //    control is Infragistics.Win.UltraWinDock.UnpinnedTabArea ||
                        //    control is Infragistics.Win.UltraWinDock.WindowDockingArea ||
                        //    control is Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
                        //    )
                        //{
                        //    continue;
                        //}

                        if (
                            control is FStatusBar ||
                            control is Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
                            )
                        {
                            continue;
                        }

                        // -- 

                        mdiControl = (MdiClient)control;
                        mdiControl.BackColor = value;
                    }

                    // -- 

                    this.m_backColor = value;                    
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    mdiControl = null;
                }
            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
                base.fUIWizard.changeControlCaption(mnuMenu);
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

        protected override void changeControlFontName(
            )
        {
            try
            {
                base.changeControlFontName();
                base.fUIWizard.changeControlFontName(mnuMenu);
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

        public void showTabMdiChild(
            FBaseTabMdiChildForm fTabMdiChildForm
            )
        {
            // Infragistics.Win.UltraWinDock.DockableControlPane dcpMdiChildForm;

            try
            {
                fTabMdiChildForm.MdiParent = this;
                fTabMdiChildForm.Show();                


                // ***
                // 2014.05.27 by spike.lee
                // 아래 코드 적용 시, Form의 Activate 및 Closing 이벤트가 발생하지 않는 문제로 우선 주석 처리합니다.
                // ***
                //fTabMdiChildForm.MdiParent = this;
                //fTabMdiChildForm.TextChanged += new EventHandler(fTabMdiChildForm_TextChanged);

                //// --

                //dcpMdiChildForm = new Infragistics.Win.UltraWinDock.DockableControlPane();
                //dcpMdiChildForm.Control = fTabMdiChildForm;
                //dcpMdiChildForm.IsMdiChild = true;
                //dcpMdiChildForm.Text = fTabMdiChildForm.Text;
                //// --
                //dockManager.DockAreas[0].Panes.Add(dcpMdiChildForm);               

                //// --

                //fTabMdiChildForm.Show();
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

        #region FBaseRibbonMdiForm Form Event Handler

        private void FBaseRibbonMdiForm_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                //for (int i = dockManager.DockAreas[0].Panes.Count; i > 0; i--)
                //{
                //    dockManager.DockAreas[0].Panes[i - 1].Close();
                //}
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseRibbonMdiForm", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region fTabMdiChildForm Object Event Handler

        private void fTabMdiChildForm_TextChanged(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                //foreach (Infragistics.Win.UltraWinDock.DockableControlPane dcp in dockManager.DockAreas[0].Panes)
                //{
                //    if (dcp.Closed == true)
                //    {
                //        continue;
                //    }

                //    // --

                //    dcp.Text = dcp.Control.Text;
                //}
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseRibbonMdiForm", ex, null);
            }
            finally
            {

            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
