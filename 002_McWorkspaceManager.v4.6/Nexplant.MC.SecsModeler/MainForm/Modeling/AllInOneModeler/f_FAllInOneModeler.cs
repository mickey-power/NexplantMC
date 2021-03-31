/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSecsLibraryGemInspector.cs
--  Creator         : mjkim
--  Create Date     : 2018.05.04
--  Description     : FAMate SECS Modeler GEM Inspectory Form Class 
--  History         : Created by mjkim at 2018.05.04
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.SecsModeler
{
    public partial class FAllInOneModeler : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FAllInOneModeler(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FAllInOneModeler(
            FSsmCore fSsmCore
            )
            : this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;
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
                    m_fSsmCore = null;
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

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
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

        private void procMenuSecsDeviceModeler(
            )
        {
            FUcSecsDeviceModeler fSecsDeviceModeler = null;

            try
            {   
                // --
                fSecsDeviceModeler = new FUcSecsDeviceModeler(m_fSsmCore);
                fSecsDeviceModeler.Dock = DockStyle.Fill;
                // --
                pnlLeft.Controls.Add(
                    fSecsDeviceModeler
                    );
                // --    
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsDeviceModeler = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEquipmentModeler(
            )
        {
            FUcEquipmentModeler fEquipmentModeler = null;

            try
            {
                // --
                fEquipmentModeler = new FUcEquipmentModeler(m_fSsmCore);
                fEquipmentModeler.Dock = DockStyle.Fill;
                // --
                pnlCenter.Controls.Add(
                    fEquipmentModeler
                    );
                // --    
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentModeler = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuHostDeviceModeler(
            )
        {
            FUcHostDeviceModeler fHostDeviceModeler = null;

            try
            {
                // --
                fHostDeviceModeler = new FUcHostDeviceModeler(m_fSsmCore);
                fHostDeviceModeler.Dock = DockStyle.Fill;
                // --
                pnlRight.Controls.Add(
                    fHostDeviceModeler
                    );
                // --    
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostDeviceModeler = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FSecsLibraryGemInspector Form Event Handler

        private void FAllInOneModeler_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
                procMenuSecsDeviceModeler();
                // --
                procMenuHostDeviceModeler();
                // --
                procMenuEquipmentModeler();
                // --

                m_fSsmCore.fOption.fChildFormList.add(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FAllInOneModeler_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();
                
                // --

                // --
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FAllInOneModeler_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fSsmCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
