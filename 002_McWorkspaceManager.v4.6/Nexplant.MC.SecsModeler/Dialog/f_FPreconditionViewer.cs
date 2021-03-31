/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FPreconditionViewer.cs
--  Creator         : kitae. Kim
--  Create Date     : 2011.10.20
--  Description     : FAMate SECS Modeler Precondition Viewer Form Class 
--  History         : Created by kitae. Kim at 2011.10.20
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Nexplant.MC.SecsModeler
{
    public partial class FPreconditionViewer : Nexplant.MC.Core.FaUIs.FBaseStandardForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
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
            FSsmCore fSsmCore,
            FFormat fFormat,
            FIPreconditionLog fPreconditionLog
            )
            :this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;
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
                    m_fSsmCore = null;
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2012.11.26 by mjkim
        // Escape 키를 사용하여 폼을 닫으려면,
        // 사용하지 않을 버튼을 만들어 CancelButton로 설정하는 것보다 폼의 Key Event를 사용하는 게 현명한 선택.
        // 그리고, Key Event를 사용하려면, 'KeyPreview' Property를 'True'로 설정해야 한다. 
        // ***
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
