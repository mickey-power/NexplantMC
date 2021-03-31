/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FExcelExporter.cs
--  Creator         : kitae
--  Create Date     : 2012.05.09
--  Description     : FAMate Core FaCommon Excel Exporter Class
--  History         : Created by kitae at 2012.05.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using Infragistics.Documents.Excel;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using Infragistics.Win.UltraWinListView;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public class FExcelExporter : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private const string CardViewGridColumn = "Header";

        private bool m_disposed = false;
        private Workbook m_workbook = null;
        private Worksheet m_worksheet = null;
        private IWorksheetCellFormat m_cardFormat = null;
        private IWorksheetCellFormat m_headerFormat = null;
        private IWorksheetCellFormat m_cellFormat = null;
        private UltraGridExcelExporter m_gridExcelExporter = null;
        private string m_fileName = string.Empty;
        private int m_rowIndex = 0;
        private int m_cellIndex = 0;
        private int m_dateCellIndex = 0;
        private bool exportFlag = false;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FExcelExporter(
            )
        {
            m_workbook = new Workbook();            
            m_headerFormat = m_workbook.CreateNewWorksheetCellFormat();
            m_cardFormat = m_workbook.CreateNewWorksheetCellFormat();
            m_cellFormat = m_workbook.CreateNewWorksheetCellFormat();
            // --
            addUserDefindStyle(ref m_workbook, ref m_headerFormat, ref m_cardFormat, ref m_cellFormat);
            // --
            m_gridExcelExporter = new UltraGridExcelExporter();
            m_gridExcelExporter.HeaderCellExported += new HeaderCellExportedEventHandler(gridExcelExporter_HeaderCellExported);
            m_gridExcelExporter.CellExported += new CellExportedEventHandler(gridExcelExporter_CellExported);
            m_gridExcelExporter.HeaderRowExporting +=new HeaderRowExportingEventHandler(m_gridExcelExporter_HeaderRowExporting);
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FExcelExporter(
            string fileName,
            string title
            )
            : this()
        {
            m_fileName = fileName;

            if (Path.GetExtension(m_fileName).ToLower() == ".xlsx")
            {
                m_workbook.SetCurrentFormat(WorkbookFormat.Excel2007);
            }

            IWorksheetCellFormat titleFormat = m_workbook.CreateNewWorksheetCellFormat();
            titleFormat.Alignment = HorizontalCellAlignment.Center;
            titleFormat.Font.Name = "Tahoma";
            titleFormat.Font.Height = 20 * 20;
            titleFormat.Font.Bold = ExcelDefaultableBoolean.True;            

            m_rowIndex = 0;

            m_worksheet = m_workbook.Worksheets.Add("Sheet1");

            WorksheetMergedCellsRegion mergedCell = null;
            mergedCell = m_worksheet.MergedCellsRegions.Add(m_rowIndex, 0, ++m_rowIndex, 3);
            mergedCell.Value = title;            
            mergedCell.CellFormat.SetFormatting(titleFormat);
            
            // --

            
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FExcelExporter(
            string fileName
            )
            : this()
        {
            m_fileName = fileName;
            
            if (Path.GetExtension(m_fileName).ToLower() == ".xlsx")
            {
                m_workbook.SetCurrentFormat(WorkbookFormat.Excel2007);
            }

            IWorksheetCellFormat titleFormat = m_workbook.CreateNewWorksheetCellFormat();
            titleFormat.Alignment = HorizontalCellAlignment.Center;
            titleFormat.Font.Name = "Tahoma";
            titleFormat.Font.Height = 20 * 20;
            titleFormat.Font.Bold = ExcelDefaultableBoolean.True;            

            m_rowIndex = 0;            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FExcelExporter(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
            bool disposiong
            )
        {
            if (!m_disposed)
            {
                if (disposiong)
                {

                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region IDisposable 멤버

        public void Dispose(
            )
        {
            myDispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void addUserDefindStyle(
            ref Workbook workbook,
            ref IWorksheetCellFormat headerFormat,
            ref IWorksheetCellFormat cardFormat,
            ref IWorksheetCellFormat cellFormat
            )
        {
            Infragistics.Win.Appearance headerAppearance = null;

            try
            {
                headerAppearance = FaUIs.FGridCommon.getHeaderAppearance();
                // --
                headerFormat.BottomBorderColor = Color.LightGray;
                headerFormat.BottomBorderStyle = CellBorderLineStyle.Medium;
                headerFormat.Font.Name = "Tahoma";
                headerFormat.Font.Height = 8 * 20;
                headerFormat.Font.Bold = ExcelDefaultableBoolean.True;
                headerFormat.VerticalAlignment = VerticalCellAlignment.Center;                
                headerFormat.FillPattern = FillPatternStyle.Solid;
                headerFormat.FillPatternForegroundColor = headerAppearance.BackColor;                
                headerFormat.Alignment = HorizontalCellAlignment.Center;
                
                // --

                cardFormat.Alignment = HorizontalCellAlignment.Center;                
                cardFormat.LeftBorderColor = Color.LightGray;
                cardFormat.RightBorderColor = Color.LightGray;
                cardFormat.TopBorderColor = Color.LightGray;
                cardFormat.BottomBorderColor = Color.LightGray;
                cardFormat.FillPattern = FillPatternStyle.None;                 
                cardFormat.Font.Name = "Tahoma";
                cardFormat.Font.Height = 8 * 20;
                cardFormat.Font.Bold = ExcelDefaultableBoolean.True;
                cardFormat.VerticalAlignment = VerticalCellAlignment.Center;                    

                // --

                cellFormat.BottomBorderColor = Color.LightGray;
                cellFormat.BottomBorderStyle = CellBorderLineStyle.Thin;
                cellFormat.Font.Name = "Tahoma";
                cellFormat.Font.Height = 8 * 20;
                cellFormat.VerticalAlignment = VerticalCellAlignment.Center;
                cellFormat.LeftBorderColor = Color.LightGray;
                cellFormat.RightBorderColor = Color.LightGray;
                cellFormat.TopBorderColor = Color.LightGray;
                cellFormat.BottomBorderColor = Color.LightGray;
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

        public void insertBlankCell(
            )
        {
            try
            {
                m_cellIndex += 1 ;                
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

        public void insertBlankRow(            
            )
        {
            try
            {
                m_cellIndex = 0;
                m_rowIndex += 2;
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

        public void excelExport(            
            FaUIs.FTitleLabel fLabel,
            string value
            )
        {
            IWorksheetCellFormat labelFormat = m_workbook.CreateNewWorksheetCellFormat();
            WorksheetMergedCellsRegion mergedCell = null;
            
            try
            {
                exportFlag = false;
                
                // --

                labelFormat.Font.Name = fLabel.Font.Name;
                labelFormat.Font.Height =(int)(fLabel.Font.Size * 20);
                // --
                labelFormat.Alignment = HorizontalCellAlignment.Center;
                labelFormat.LeftBorderColor = Color.LightGray;
                labelFormat.RightBorderColor = Color.LightGray;
                labelFormat.TopBorderColor = Color.LightGray;
                labelFormat.BottomBorderColor = Color.LightGray;
                labelFormat.VerticalAlignment = VerticalCellAlignment.Center;
                labelFormat.ShrinkToFit = ExcelDefaultableBoolean.True;
                // --
                labelFormat.Font.Bold = fLabel.Font.Bold == true ? ExcelDefaultableBoolean.True : ExcelDefaultableBoolean.False;                
                labelFormat.FillPatternBackgroundColor = fLabel.Appearance.BackColor;
                labelFormat.FillPatternForegroundColor = fLabel.Appearance.BackColor;               
                
                // --

                m_worksheet.Rows[m_rowIndex].Cells[m_cellIndex].Value = fLabel.Text;
                m_worksheet.Rows[m_rowIndex].Cells[m_cellIndex].CellFormat.SetFormatting(labelFormat);
                mergedCell = m_worksheet.MergedCellsRegions.Add(m_rowIndex, ++m_cellIndex, m_rowIndex, m_cellIndex);
                mergedCell.Value = value;
                mergedCell.CellFormat.SetFormatting(m_cellFormat);                                                           
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

        public void excelExport(
            UltraGrid basegrid
            )
        {
            IWorksheetCellFormat format = m_workbook.CreateNewWorksheetCellFormat();
            WorksheetMergedCellsRegion mergedCell = null;
            UltraGridCell[] cell = null;
            int colsNo = 0;
            int rowsNo = 0;
            int i = 0;

            try
            {
                exportFlag = false;
                
                // --

                if (
                    basegrid.DisplayLayout.Bands[0].ColHeadersVisible ||
                    basegrid.DisplayLayout.Bands[0].Groups.Count > 0
                  )
                {
                    colsNo = basegrid.DisplayLayout.Bands[0].Columns.Count - 1;
                    if (basegrid.DisplayLayout.Bands[0].Columns[colsNo].Hidden)
                    {
                        colsNo--;
                    }
                    
                    // --

                    format.Alignment = HorizontalCellAlignment.Right;
                    format.Font.Name = "Tahoma";
                    format.Font.Height = 8 * 20;
                    format.ShrinkToFit = ExcelDefaultableBoolean.True;
                    
                    // --


                    m_worksheet.Rows[m_rowIndex].Cells[colsNo].CellFormat.SetFormatting(format);
                    rowsNo = basegrid.Rows.Count;
                    if (basegrid.DisplayLayout.Bands[0].Columns[0].MergedCellStyle == MergedCellStyle.Always)
                    {
                        rowsNo = 0;
                        for (i = 0; i < basegrid.Rows.Count; i++)
                        {
                            rowsNo++;
                            cell = basegrid.Rows[i].Cells[0].GetMergedCells();
                            if (cell != null)
                            {
                                i += (cell.GetLength(0) - 1);
                            }
                        }
                    }
                    m_worksheet.Rows[m_rowIndex].Cells[colsNo].Value = string.Format("Total Count : {0}", rowsNo);
                    m_dateCellIndex = colsNo;
                }

                // --

                if (
                    basegrid.DisplayLayout.Bands[0].ColHeadersVisible == false &&
                    basegrid.DisplayLayout.Bands[0].Groups.Count > 0
                    )
                {                    
                    colsNo = 0;
                    foreach (UltraGridGroup group in basegrid.DisplayLayout.Bands[0].Groups)
                    {
                        mergedCell = m_worksheet.MergedCellsRegions.Add(m_rowIndex, colsNo, m_rowIndex, colsNo + group.Columns.Count - 1);
                        mergedCell.CellFormat.SetFormatting(m_cardFormat);
                        mergedCell.Value = group.Header.Caption;
                        colsNo += group.Columns.Count;
                    }
                }

                // --
                m_rowIndex++;
                // --
                m_gridExcelExporter.FileLimitBehaviour = FileLimitBehaviour.TruncateData;                
                m_gridExcelExporter.Export(basegrid, m_workbook, m_rowIndex, 0);                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                format = null;
                mergedCell = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void excelExport(
            UltraGrid basegrid,
            string sheetName
            )
        {
            IWorksheetCellFormat format = m_workbook.CreateNewWorksheetCellFormat();
            WorksheetMergedCellsRegion mergedCell = null;
            UltraGridCell[] cell = null;
            int colsNo = 0;
            int rowsNo = 0;
            int i = 0;

            try
            {
                m_worksheet = m_workbook.Worksheets.Add(sheetName);
                
                // --
                
                exportFlag = true;
                
                // --

                m_rowIndex = 1;

                if (
                    basegrid.DisplayLayout.Bands[0].ColHeadersVisible ||
                    basegrid.DisplayLayout.Bands[0].Groups.Count > 0
                    )
                {
                    colsNo = basegrid.DisplayLayout.Bands[0].Columns.Count - 1;
                    if (basegrid.DisplayLayout.Bands[0].Columns[colsNo].Hidden)
                    {
                        colsNo--;
                    }

                    // --

                    format.Alignment = HorizontalCellAlignment.Right;
                    format.Font.Name = "Tahoma";
                    format.Font.Height = 8 * 20;
                    format.ShrinkToFit = ExcelDefaultableBoolean.True;

                    // --


                    m_worksheet.Rows[m_rowIndex].Cells[colsNo].CellFormat.SetFormatting(format);
                    rowsNo = basegrid.Rows.Count;
                    if (basegrid.DisplayLayout.Bands[0].Columns[0].MergedCellStyle == MergedCellStyle.Always)
                    {
                        rowsNo = 0;
                        for (i = 0; i < basegrid.Rows.Count; i++)
                        {
                            rowsNo++;
                            cell = basegrid.Rows[i].Cells[0].GetMergedCells();
                            if (cell != null)
                            {
                                i += (cell.GetLength(0) - 1);
                            }
                        }
                    }
                    m_dateCellIndex = colsNo;
                }

                // --

                if (
                    basegrid.DisplayLayout.Bands[0].ColHeadersVisible == false &&
                    basegrid.DisplayLayout.Bands[0].Groups.Count > 0
                    )
                {
                    colsNo = 1;
                    foreach (UltraGridGroup group in basegrid.DisplayLayout.Bands[0].Groups)
                    {
                        mergedCell = m_worksheet.MergedCellsRegions.Add(m_rowIndex, colsNo, m_rowIndex, colsNo + group.Columns.Count - 1);
                        mergedCell.CellFormat.SetFormatting(m_cardFormat);
                        mergedCell.Value = group.Header.Caption;
                        colsNo += group.Columns.Count;
                    }
                }

                // --

                m_gridExcelExporter.FileLimitBehaviour = FileLimitBehaviour.TruncateData;                
                m_gridExcelExporter.Export(basegrid, m_worksheet, m_rowIndex, 1);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                format = null;
                mergedCell = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public void excelExport(
           FaUIs.FTreeView treeView
            )
        {            
            WorksheetImage imageShape = null;
            Bitmap saveimage = null;
            int imageWidth = 0 ;
            int imageHeight = 0;
            int colsNo = 0;           

            try
            {
                exportFlag = false;
                
                // --

                saveimage = new Bitmap(treeView.Width, treeView.Height);
                treeView.ExpandAll();
                treeView.DrawToBitmap(saveimage, new Rectangle(treeView.Location,treeView.Size));
                imageShape = new WorksheetImage(saveimage);
                imageShape.TopLeftCornerCell = m_worksheet.Rows[m_rowIndex].Cells[0];
                imageShape.TopLeftCornerPosition = new PointF(0, 0);

                imageHeight = 0;
                do
                {
                    imageHeight += m_worksheet.Rows[m_rowIndex].Height > -1 ?
                        m_worksheet.Rows[m_rowIndex].Height / 11 :
                        m_worksheet.DefaultRowHeight / 11;
                    m_rowIndex++;
                }
                while (imageShape.Image.Height >= imageHeight);

                imageWidth = 0;
                colsNo = 0;
                do
                {
                    imageWidth += m_worksheet.Columns[colsNo].Width > -1 ?
                        m_worksheet.Columns[colsNo].Width / 24 :
                        m_worksheet.DefaultColumnWidth / 24;
                    colsNo++;
                }
                while (imageShape.Image.Width >= imageWidth);
                // --
                imageShape.BottomRightCornerCell = m_worksheet.Rows[m_rowIndex].Cells[colsNo];
                imageShape.BottomRightCornerPosition = new PointF(100, 100);
                // --
                m_worksheet.Shapes.Add(imageShape);                
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

        public void save(
            )
        {
            IWorksheetCellFormat format = null;
            int imageWidth = -1;
            int cellIndex = 0;

            try
            {
                foreach (WorksheetImage shape in m_worksheet.Shapes)
                {
                    imageWidth = 0;
                    cellIndex = 0;

                    do
                    {
                        imageWidth += m_worksheet.Columns[cellIndex].Width > -1 ?
                            m_worksheet.Columns[cellIndex].Width / 24 :
                            m_worksheet.DefaultColumnWidth / 24;
                        cellIndex++;
                    }
                    while (shape.Image.Width >= imageWidth);

                    shape.BottomRightCornerCell = m_worksheet.Rows[shape.BottomRightCornerCell.RowIndex].Cells[cellIndex];
                }

                if (cellIndex > m_dateCellIndex)
                {
                    m_dateCellIndex = cellIndex;
                }

                format = m_workbook.CreateNewWorksheetCellFormat();
                format.Font.Name = "Tahoma";
                format.Font.Height = 8 * 20;
                format.Alignment = HorizontalCellAlignment.Right;               

                m_workbook.Save(m_fileName);
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

        //-----------------------------------------------------------------------------------------------------------------------\

        #region  gridExcelExporter Event Handler

        private void gridExcelExporter_HeaderCellExported(
           object sender,
           HeaderCellExportedEventArgs e
           )
        {            
            try
            {                         
                m_worksheet.Rows[e.CurrentRowIndex].Cells[e.CurrentColumnIndex].CellFormat.SetFormatting(m_headerFormat);                
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

        private void m_gridExcelExporter_HeaderRowExporting(
            object sender,
            HeaderRowExportingEventArgs e
            )
        {
            try
            {
                if (exportFlag)
                {
                    e.CurrentColumnIndex = 1;
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

        private void gridExcelExporter_CellExported(
            object sender,
            CellExportedEventArgs e
            )
        {
            IWorksheetCellFormat format = null;
            UltraGridCell[] cell = null;
            Color backColor = Color.Empty;

            try
            {                
                format = e.GridColumn.Tag != null && e.GridColumn.Tag.Equals(CardViewGridColumn) ? m_cardFormat : m_cellFormat;
                m_worksheet.Columns[e.CurrentColumnIndex].Width = e.GridColumn.Width * 40;
                m_worksheet.Rows[e.CurrentRowIndex].Cells[e.CurrentColumnIndex].CellFormat.SetFormatting(format);                

                if (e.CurrentColumnIndex >= e.GridRow.Cells.Count)
                {
                    return;
                }

                if (e.GridColumn.MergedCellStyle == MergedCellStyle.Always)
                {
                    cell = e.GridRow.Cells[0].GetMergedCells();
                    if (cell != null && e.GridRow.Index == cell[0].Row.Index)
                    {
                        m_worksheet.MergedCellsRegions.Add(e.CurrentRowIndex, e.CurrentColumnIndex, e.CurrentRowIndex + cell.GetLength(0) - 1, e.CurrentColumnIndex);
                    }
                }

                //backColor = e.GridColumn.CellAppearance.BackColor;
                //if (
                //    e.Value.Equals(System.DBNull.Value) &&
                //    backColor.IsEmpty == false
                //   )
                //{
                //    m_worksheet.Rows[e.CurrentRowIndex].Cells[e.CurrentColumnIndex].CellFormat.FillPattern = FillPatternStyle.None;
                //}

                //m_worksheet.Rows[e.CurrentRowIndex].Cells[e.CurrentColumnIndex].CellFormat.FillPatternForegroundColor = backColor;
                //m_worksheet.Rows[e.CurrentRowIndex].Cells[e.CurrentColumnIndex].CellFormat.FillPatternBackgroundColor = backColor;

                m_rowIndex = e.CurrentRowIndex;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                format = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
