/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEapTypeSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2013.12.18
--  Description     : FAMate Admin Manager EAP Type Selector Form Class 
--  History         : Created by spike.lee at 2013.12.18 
 ----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;

namespace Nexplant.MC.AdminManager
{
    // ***
    // 작업중... (jungyoul)
    // ***
    public partial class FEapTypeSelector2 : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FAdmCore m_fAdmCore = null;
        private FEapType m_fEapType = FEapType.SECS;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEapTypeSelector2(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEapTypeSelector2(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;            
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
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties
       
        public FEapType fEapType
        {
            get
            {
                try
                {
                    return m_fEapType;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FEapType.SECS;
            }
        }
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void designGridOfEapType(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Check", typeof(bool));
                uds.Band.Columns.Add("EAP Type");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add(" "); // Dummy

                // --

                grdList.DisplayLayout.Bands[0].Columns["EAP Type"].CellAppearance.Image = Properties.Resources.Eap;
                
                // --

                grdList.DisplayLayout.Bands[0].Columns["EAP Type"].CellClickAction = CellClickAction.RowSelect;
                grdList.DisplayLayout.Bands[0].Columns["Description"].CellClickAction = CellClickAction.RowSelect;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = string.Empty;
                grdList.DisplayLayout.Bands[0].Columns["Check"].Header.CheckBoxVisibility = Infragistics.Win.UltraWinGrid.HeaderCheckBoxVisibility.Always;
                grdList.DisplayLayout.Bands[0].Columns["Check"].Header.Fixed = true;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Check"].Width = 22;
                grdList.DisplayLayout.Bands[0].Columns["EAP Type"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 180;
                
                // --

                grdList.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
                grdList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Default;
                grdList.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                uds = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfEapType(
            )
        {
            object[] cellValues = null;
            string desc = string.Empty;

            try
            {
                grdList.removeAllDataRow();
                grdList.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --
                
                grdList.beginUpdate();

                // --

                foreach (FEapType eapType in Enum.GetValues(typeof(FEapType)))
                {
                    desc = eapType == FEapType.CHD ? 
                        "EAP Wizard for Custom Host Driver" : string.Format("EAP Wizard for {0}", eapType.ToString());

                    // --

                    cellValues = new object[] {
                        false,
                        eapType.ToString(),
                        desc
                        };
                    // --
                    grdList.appendDataRow(eapType.ToString(), cellValues);
                }

                // --

                grdList.endUpdate();
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {
                cellValues = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FEapTypeSelector Form Event Handler

        private void FEapTypeSelector_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfEapType();
                // --
                refreshGridOfEapType();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region  btnOk Control Event Handler

        private void btnOk_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                

                // --
                
                this.DialogResult = DialogResult.OK;
                this.Close();
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdList Control Event Handler

        private void grdList_CellChange(
            object sender, 
            CellEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                foreach (UltraGridRow row in grdList.Rows)
                {
                    if (e.Cell.Row != row)
                    {
                        
                    }
                }
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
