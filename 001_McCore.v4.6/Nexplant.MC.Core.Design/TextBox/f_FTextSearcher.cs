/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTextSearcher.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.25
--  Description     : FAMate Core FaUIs Text Search Form Class
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
using Infragistics.Win.UltraWinDataSource;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FTextSearcher : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FSearchWordSelectionRequestedEventHandler SearchWordSelectionRequested = null;

        // --

        private bool m_disposed = false;
        // --
        private string m_logData = string.Empty;
        private int m_searchWordLength = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FTextSearcher(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FTextSearcher(
            string logData
            ) : this()
        {
            m_logData = logData;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void designListOfResult(
            )
        {
            UltraDataSource uds = null;

            try
            {
                grdList.multiSelected = false;

                // --

                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Row", typeof(int));
                uds.Band.Columns.Add("Column", typeof(int));
                uds.Band.Columns.Add("Contents");                

                // --

                grdList.DisplayLayout.Bands[0].Columns["Row"].Width = 50;
                grdList.DisplayLayout.Bands[0].Columns["Column"].Width = 50;
                grdList.DisplayLayout.Bands[0].Columns["Contents"].Width = 200;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Row"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdList.DisplayLayout.Bands[0].Columns["Column"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
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

        private void refreshListOfResult(
            string searchWord
            )
        {
            int rowStart = 0;
            int rowEnd = 0;
            int row = 0;
            int column = 0;
            int position = 0;
            object[] cellValues = null;

            try
            {
                grdList.beginUpdate();

                // --

                m_searchWordLength = searchWord.Length;
                grdList.removeAllDataRow();

                do
                {
                    rowEnd = m_logData.IndexOf(Environment.NewLine, rowStart);
                    if (rowEnd > -1)
                    {
                        position = m_logData.IndexOf(searchWord, rowStart, rowEnd - rowStart);
                        if (position > -1)
                        {
                            column = position - rowStart;

                            cellValues = new object[] 
                            {
                                row,
                                column,
                                m_logData.Substring(rowStart, rowEnd - rowStart)
                             };
                            // --
                            grdList.appendDataRow(position.ToString(), cellValues);
                        }

                        // --

                        rowStart = rowEnd + Environment.NewLine.Length;
                        row++;
                    }
                } while (rowEnd > -1);

                // --

                grdList.endUpdate();

                // --

                lblTotalCountValue.Text = grdList.Rows.Count.ToString();
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

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void onSearchWordSelectionRequested(
            )
        {
            int position = 0;

            try
            {
                if (grdList.ActiveRow == null)
                {
                    return;
                }

                // --

                if (SearchWordSelectionRequested != null)
                {
                    position = int.Parse(grdList.activeDataRowKey);
                    // --
                    SearchWordSelectionRequested(
                        this, 
                        new FSearchWordSelectionRequestedEventArgs(position, m_searchWordLength)
                        );
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

        //------------------------------------------------------------------------------------------------------------------------

        internal void search(
            string searchWord
            )
        {
            try
            {
                rstToolbar.onSearchRequested(searchWord);                
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

        #region FTextSearcher Form Event Handler

        private void FTextSearcher_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designListOfResult();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FTextSearcher", ex, null);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region rstToolbar Control Event Handler

        private void rstToolbar_SearchRequested(
            object sender, 
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshListOfResult(e.searchWord);
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FTextSearcher", ex, null);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdList Control Event Handler

        private void grdList_DoubleClickRow(
            object sender, 
            Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --               

                onSearchWordSelectionRequested();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FTextSearcher", ex, null);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdList_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.KeyCode == Keys.Enter)
                {
                    onSearchWordSelectionRequested();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FTextSearcher", ex, null);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnClose Control Event Handler

        private void btnClose_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FTextSearcher", ex, null);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        private void FTextSearcher_KeyDown(
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
                throw;
            }
            finally
            {
 
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
