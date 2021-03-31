/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FPreconditionViewer.cs
--  Creator         : byjeon
--  Create Date     : 2013.12.06
--  Description     : FAMate Log Viewer Precondition Viewer Form Class 
--  History         : Created by byjeon at 2013.12.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager.FaOpcLogViewer
{
    public partial class FPreconditionViewer : Nexplant.MC.Core.FaUIs.FBaseStandardForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private FFormat m_fFormat = FFormat.Ascii;
        private FIPreconditionLog m_fPreconditionLog = null;
        // --
        private int m_keyIndex = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPreconditionViewer()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPreconditionViewer(
            FAdmCore fAdmCore,
            FFormat fFormat,
            FIPreconditionLog fPreconditionLog
            )
            :this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            m_fFormat = fFormat;
            m_fPreconditionLog = fPreconditionLog;
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
                    m_fAdmCore = null;
                    m_fPreconditionLog = null;
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

        private void designGridOfValue(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Key");
                uds.Band.Columns.Add("Index");
                uds.Band.Columns.Add("Precondition Value");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Index"].CellAppearance.Image = Properties.Resources.Value;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Key"].Hidden = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Index"].Width = 60;
                grdList.DisplayLayout.Bands[0].Columns["Precondition Value"].Width = 120;

                // --

                grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
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

        private void refreshGridOfValue(
            )
        {
            FIPreconditionValueCollection fPreconditionValueCollection = null;
            string value = string.Empty;
            object[] cellValues = null;
            UltraDataRow dataRow = null;

            try
            {
                grdList.beginUpdate();

                // --

                fPreconditionValueCollection = m_fPreconditionLog.fPreconditionValueCollection;
                // --
                for (int i = 0; i < fPreconditionValueCollection.count; i++)
                {
                    value = fPreconditionValueCollection[i];
                    // --
                    cellValues = new object[] 
                    {
                        m_keyIndex.ToString(),
                        i.ToString(),
                        value
                    };
                    // --
                    dataRow = grdList.appendDataRow((string)cellValues[0], cellValues);
                    dataRow.Tag = value;

                    // --

                    m_keyIndex++;
                }

                // --

                grdList.endUpdate();

                // --

                if (grdList.Rows.Count > 0)
                {
                    grdList.ActiveRow = grdList.Rows[0];
                }
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fPreconditionValueCollection = null;
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void updateValueIndex(
            )
        {
            try
            {
                grdList.beginUpdate();

                // --

                for (int i = 0; i < grdList.Rows.Count; i++)
                {
                    grdList.getDataRow(i).SetCellValue("Index", i.ToString());
                }

                // --

                grdList.endUpdate();
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FPreconditionViewer Form Event Handler
        
        private void FPreconditionViewer_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfValue();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FPreconditionViewer_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfValue();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FPrconditionViewer_KeyDown(
            object sender,
            KeyEventArgs e
            )
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
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

    }   // Class end
}   // Namespcae end
