/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FExcelSheet.cs
--  Creator         : spike.lee
--  Create Date     : 2012.11.26
--  Description     : FAMate Core FaCommon Excel Exporter Class
--  History         : Created by spike.lee at 2012.11.26
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using Infragistics.Documents.Excel;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using Infragistics.Win.UltraWinListView;
using Infragistics.Win;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public class FExcelSheet : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private const int FontRate = 20;
        private const int WidthRate = 266;
        private const int DefaultColumnWidth = 18 * WidthRate;

        // --

        private bool m_disposed = false;
        // --
        private string m_defaultFontName = "Tahoma";
        private int m_defaultFontSize = 9;
        private int m_rowIndex = 0;
        private Worksheet m_worksheet = null;
        // --
        private Dictionary<int, double> m_columnWidthDic = null;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FExcelSheet(
            string defaultFontName,
            int defaultFontSize,
            Worksheet worksheet
            )            
        {
            m_worksheet = worksheet;
            m_defaultFontName = defaultFontName;
            m_defaultFontSize = defaultFontSize;
            m_columnWidthDic = new Dictionary<int, double>();
            // --
            init();
        }                

        //------------------------------------------------------------------------------------------------------------------------

        ~FExcelSheet(
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
                    term();
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

        public string name
        {
            get
            {
                try
                {
                    return m_worksheet.Name;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal Worksheet worksheet
        {
            get
            {
                try
                {
                    return m_worksheet;
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
        
        private void init(
            )
        {
            try
            {

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

        private void term(
            )
        {
            try
            {
                m_worksheet = null;
                m_columnWidthDic = null;
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

        public void autoFitColumn(
            )
        {     
            try
            {
                // --

                foreach (int cellIndex in m_columnWidthDic.Keys)
                {
                    m_worksheet.Columns[cellIndex].Width = (int)m_worksheet.Workbook.PixelsToCharacterWidth256ths(m_columnWidthDic[cellIndex]);
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

        private IWorksheetCellFormat createFontFormat(
            string fontName, 
            int fontSize, 
            bool fontBold
            )
        {
            IWorksheetCellFormat cellFormat = null;

            try
            {
                cellFormat = m_worksheet.Workbook.CreateNewWorksheetCellFormat();
                cellFormat.Font.Name = fontName;
                cellFormat.Font.Height = fontSize * FontRate;
                cellFormat.Font.Bold = fontBold ? ExcelDefaultableBoolean.True : ExcelDefaultableBoolean.False;

                // --

                return cellFormat;
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

        private IWorksheetCellFormat createCaptionFormat(
            string fontName,
            int fontSize,
            bool fontBold
            )
        {
            IWorksheetCellFormat cellFormat = null;

            try
            {
                cellFormat = createFontFormat(fontName, fontSize, fontBold);
                // --
                cellFormat.Alignment = HorizontalCellAlignment.Center;
                cellFormat.VerticalAlignment = VerticalCellAlignment.Center;
                // --
                cellFormat.LeftBorderColor = Color.Silver;                
                cellFormat.RightBorderColor = cellFormat.LeftBorderColor;
                cellFormat.TopBorderColor = cellFormat.LeftBorderColor;
                cellFormat.BottomBorderColor = cellFormat.LeftBorderColor;
                // --
                cellFormat.FillPatternForegroundColor = Color.LightSteelBlue;
                cellFormat.FillPatternBackgroundColor = Color.Lavender;                
                cellFormat.FillPattern = FillPatternStyle.Gray75percent;

                // --

                return cellFormat;
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

        private IWorksheetCellFormat createCaptionValueFormat(
            string fontName,
            int fontSize,
            bool fontBold
            )
        {
            IWorksheetCellFormat cellFormat = null;

            try
            {
                cellFormat = createFontFormat(fontName, fontSize, fontBold);
                // --
                cellFormat.Alignment = HorizontalCellAlignment.Left;
                cellFormat.VerticalAlignment = VerticalCellAlignment.Center;
                // --                
                cellFormat.LeftBorderColor = Color.Silver;
                cellFormat.RightBorderColor = cellFormat.LeftBorderColor;
                cellFormat.TopBorderColor = cellFormat.LeftBorderColor;
                cellFormat.BottomBorderColor = cellFormat.LeftBorderColor;

                // --

                return cellFormat;
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

        private IWorksheetCellFormat createGridColumnFormat(
            string fontName,
            int fontSize,
            bool fontBold
            )
        {
            IWorksheetCellFormat cellFormat = null;

            try
            {
                cellFormat = createFontFormat(fontName, fontSize, fontBold);
                // --
                cellFormat.Alignment = HorizontalCellAlignment.Center;
                cellFormat.VerticalAlignment = VerticalCellAlignment.Center;
                // --                
                cellFormat.LeftBorderColor = Color.Silver;
                cellFormat.RightBorderColor = cellFormat.LeftBorderColor;
                cellFormat.TopBorderColor = cellFormat.LeftBorderColor;
                cellFormat.BottomBorderColor = cellFormat.LeftBorderColor;
                // --
                cellFormat.FillPatternForegroundColor = Color.LightSteelBlue;
                cellFormat.FillPatternBackgroundColor = Color.Lavender;
                cellFormat.FillPattern = FillPatternStyle.Gray75percent;

                // --

                return cellFormat;
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

        private IWorksheetCellFormat createGridCellFormat(
            string fontName,
            int fontSize,
            AppearanceBase colAppBase,
            AppearanceBase cellAppBase
            )
        {
            IWorksheetCellFormat cellFormat = null;

            try
            {
                cellFormat = createFontFormat(fontName, fontSize, cellAppBase.FontData.Bold == DefaultableBoolean.True ? true : false);
                cellFormat.Font.Color = cellAppBase.ForeColor;
                // --
                cellFormat.LeftBorderColor = Color.Silver;
                cellFormat.RightBorderColor = cellFormat.LeftBorderColor;
                cellFormat.TopBorderColor = cellFormat.LeftBorderColor;
                cellFormat.BottomBorderColor = cellFormat.LeftBorderColor;
                
                // --
                
                if (colAppBase.TextHAlign == HAlign.Center)
                {
                    cellFormat.Alignment = HorizontalCellAlignment.Center;
                }
                else if (colAppBase.TextHAlign == HAlign.Right)
                {
                    cellFormat.Alignment = HorizontalCellAlignment.Right;
                }
                else
                {
                    cellFormat.Alignment = HorizontalCellAlignment.Left;
                }
                // --
                if (colAppBase.TextVAlign == VAlign.Top)
                {
                    cellFormat.VerticalAlignment = VerticalCellAlignment.Top;
                }
                else if (colAppBase.TextVAlign == VAlign.Bottom)
                {
                    cellFormat.VerticalAlignment = VerticalCellAlignment.Bottom;
                }
                else
                {
                    cellFormat.VerticalAlignment = VerticalCellAlignment.Center;
                }

                // --

                return cellFormat;
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

        public void mergedRow(
            int firstRowIndex,
            int lastRowIndex,
            int firstColIndex,
            int lastColIndex
            )
        {
            WorksheetCell cell = null;

            try
            {
                // --

                m_worksheet.MergedCellsRegions.Add(
                    firstRowIndex, 
                    firstColIndex, 
                    lastRowIndex, 
                    lastColIndex
                    );

                // --

                cell = m_worksheet.Rows[firstRowIndex].Cells[firstColIndex];
                cell.CellFormat.VerticalAlignment = VerticalCellAlignment.Center;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                cell = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void writeTitle(
            string title,
            int rowIndex,
            int cellIndex,
            string fontName,
            int fontSize,
            bool fontBold
            )
        {
            WorksheetCell cell = null;

            try
            {
                cell = m_worksheet.Rows[rowIndex].Cells[cellIndex];
                cell.CellFormat.SetFormatting(createFontFormat(fontName, fontSize, fontBold));
                cell.Value = title;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                cell = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void writeTitle(
            string title,
            int rowIndex,
            int cellIndex
            )
        {
            try
            {
                writeTitle(title, rowIndex, cellIndex, m_defaultFontName, 22, true);
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

        public void writeSubTitle(
            string title,
            int rowIndex,
            int cellIndex,
            string fontName,
            int fontSize,
            bool fontBold
            )
        {
            WorksheetCell cell = null;

            try
            {
                cell = m_worksheet.Rows[rowIndex].Cells[cellIndex];
                cell.CellFormat.SetFormatting(createFontFormat(fontName, fontSize, fontBold));
                cell.Value = title;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                cell = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void writeSubTitle(
            string title,
            int rowIndex,
            int cellIndex
            )
        {
            try
            {
                writeSubTitle(title, rowIndex, cellIndex, m_defaultFontName, 12, true);
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

        public void writeCondition(
            string caption, 
            string value,
            int rowIndex,
            int cellIndex,
            string fontName,
            int fontSize,
            bool fontBold
            )
        {
            WorksheetCell cell = null;

            try
            {
                // ***
                // Caption Write
                // ***
                cell = m_worksheet.Rows[rowIndex].Cells[cellIndex];
                cell.CellFormat.SetFormatting(createCaptionFormat(fontName, fontSize, fontBold));
                cell.Value = caption;
                m_worksheet.Columns[cellIndex].Width = DefaultColumnWidth;                

                // --                

                // ***
                // Value Write
                // ***
                cell = m_worksheet.Rows[rowIndex].Cells[cellIndex + 1];
                cell.CellFormat.SetFormatting(createCaptionValueFormat(fontName, fontSize, fontBold));
                cell.Value = value;
                m_worksheet.Columns[cellIndex + 1].Width = DefaultColumnWidth;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                cell = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void writeCondition(
            string caption,
            string value,
            int rowIndex,
            int cellIndex
            )
        {
            try
            {
                writeCondition(caption, value, rowIndex, cellIndex, m_defaultFontName, m_defaultFontSize, false);
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

        public void writeHeaderText(
            string text,
            int rowIndex,
            int cellIndex,
            string fontName,
            int fontSize,
            bool fontBold
            )
        {
            try
            {
                writeHeaderText(text, rowIndex, cellIndex, 2, m_defaultFontName, m_defaultFontSize, false);
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

        public void writeHeaderText(
            string text,
            int rowIndex,
            int cellIndex,
            int hCellAlignment,
            string fontName,
            int fontSize,
            bool fontBold
            )
        {
            WorksheetCell cell = null;
            Size size;
            Font font = null;
            double widthInPixes = 0;

            try
            {
                // ***
                // Value Write
                // ***
                cell = m_worksheet.Rows[rowIndex].Cells[cellIndex];
                cell.CellFormat.SetFormatting(createFontFormat(fontName, fontSize, fontBold));
                cell.CellFormat.Alignment = (HorizontalCellAlignment)hCellAlignment;
                cell.CellFormat.Fill = CellFill.CreateSolidFill(Color.LightGray);
                cell.CellFormat.TopBorderStyle = CellBorderLineStyle.Thin;
                cell.CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin;
                cell.CellFormat.RightBorderStyle = CellBorderLineStyle.Thin;
                cell.CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin;
                cell.Value = text;

                // --

                font = new Font(fontName, fontSize, FontStyle.Bold);
                size = new Size(Int32.MaxValue, Int32.MaxValue);
                size = System.Windows.Forms.TextRenderer.MeasureText(text, font, size);

                // --

                widthInPixes = size.Width;
                if (m_columnWidthDic.ContainsKey(cellIndex))
                {
                    if (widthInPixes > m_columnWidthDic[cellIndex])
                    {
                        m_columnWidthDic[cellIndex] = widthInPixes;
                    }
                }
                else
                {
                    m_columnWidthDic.Add(cellIndex, widthInPixes);
                }

                // --

                m_worksheet.Columns[cellIndex + 1].Width = DefaultColumnWidth;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                cell = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void writeHeaderText(
            string text,
            int rowIndex,
            int cellIndex,
            int hCellAlignment
            )
        {
            try
            {
                writeHeaderText(text, rowIndex, cellIndex, hCellAlignment, m_defaultFontName, m_defaultFontSize, false);
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

        public void writeText(
            string text,
            int rowIndex,
            int cellIndex,
            string fontName,
            int fontSize,
            bool fontBold
            )
        {
            WorksheetCell cell = null;
            Size size;
            Font font = null;
            double widthInPixes = 0;

            try
            {
                // ***
                // Value Write
                // ***
                cell = m_worksheet.Rows[rowIndex].Cells[cellIndex];
                cell.CellFormat.SetFormatting(createFontFormat(fontName, fontSize, fontBold));
                cell.Value = text;

                // --

                font = new Font(fontName, fontSize, FontStyle.Bold);
                size = new Size(Int32.MaxValue, Int32.MaxValue);
                size = System.Windows.Forms.TextRenderer.MeasureText(text, font, size);

                // --

                widthInPixes = size.Width;
                if (m_columnWidthDic.ContainsKey(cellIndex))
                {
                    if (widthInPixes > m_columnWidthDic[cellIndex])
                    {
                        m_columnWidthDic[cellIndex] = widthInPixes;
                    }
                }
                else
                {
                    m_columnWidthDic.Add(cellIndex, widthInPixes);
                }
                
                // --

                m_worksheet.Columns[cellIndex + 1].Width = DefaultColumnWidth;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                cell = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void writeText(
            string text, 
            int rowIndex, 
            int cellIndex
            )
        {
            try
            {
                writeText(text, rowIndex, cellIndex, m_defaultFontName, m_defaultFontSize, false);
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

        public int writeGrid(
            FGrid fGrid,
            int rowIndex,
            int cellIndex,
            string fontName,
            int fontSize
            )
        {
            IWorksheetCellFormat colFormat = null;            
            WorksheetCell cell = null;
            int rowPos = 0;
            int cellPos = 0;
            int rowOffset = 0;            
            int cellOffset = 0;

            try
            {
                // ***
                // Grid Column Write
                // ***
                colFormat = createGridColumnFormat(fontName, fontSize, false);
                // --
                foreach (UltraGridColumn col in fGrid.DisplayLayout.Bands[0].Columns)
                {
                    rowPos = rowIndex + rowOffset;
                    cellPos = cellIndex + cellOffset;

                    // --

                    cell = m_worksheet.Rows[rowPos].Cells[cellPos];
                    cell.CellFormat.SetFormatting(colFormat);
                    cell.Value = col.Header.Caption;
                    m_worksheet.Columns[cellPos].Width = DefaultColumnWidth;

                    // --

                    cellOffset++;
                }
                rowOffset++;
                
                // --

                // ***
                // Grid Row Write
                // ***
                foreach (UltraGridRow row in fGrid.Rows)
                {
                    rowPos = rowIndex + rowOffset;
                    cellOffset = 0;

                    // --

                    foreach (UltraGridCell c in row.Cells)
                    {
                        cellPos = cellIndex + cellOffset;
                     
                        // --

                        cell = m_worksheet.Rows[rowPos].Cells[cellPos];
                        cell.CellFormat.SetFormatting(createGridCellFormat(fontName, fontSize, c.Column.CellAppearance, c.Appearance));
                        cell.Value = c.Text;                        

                        // --

                        cellOffset++;
                    }

                    // --

                    rowOffset++;
                }

                // --

                return rowPos;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                colFormat = null;
                cell = null;
            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int writeGrid(
            FGrid fGrid, 
            int rowIndex, 
            int cellIndex
            )
        {
            try
            {
                return writeGrid(fGrid, rowIndex, cellIndex, m_defaultFontName, m_defaultFontSize);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int writeGridGroup(
            FGrid fGrid,
            int rowIndex,
            int cellIndex
            )
        {
            UltraGridExcelExporter excelExporter = null;
            IWorksheetCellFormat colFormat = null;
            int rowPos = 0;

            try
            {
                colFormat = createGridColumnFormat(m_defaultFontName, m_defaultFontSize, false);

                // --

                excelExporter = new UltraGridExcelExporter();
                excelExporter.HeaderCellExported += new HeaderCellExportedEventHandler(excelExporter_HeaderCellExported);
                excelExporter.CellExported += new CellExportedEventHandler(excelExporter_CellExported);
                excelExporter.Export(fGrid, m_worksheet, rowIndex, cellIndex);

                // --
                rowPos = m_rowIndex;
                return rowPos;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int writeMultiBandGrid(
            FGrid fGrid,
            int rowIndex,
            int cellIndex
            )
        {
            UltraGridExcelExporter excelExporter =null;
            IWorksheetCellFormat colFormat = null;  
            int rowPos = 0;

            try
            {
                colFormat = createGridColumnFormat(m_defaultFontName, m_defaultFontSize, false);
                
                // --

                excelExporter = new UltraGridExcelExporter();
                excelExporter.CellExported += new CellExportedEventHandler(excelExporter_CellExported);
                excelExporter.Export(fGrid,m_worksheet,rowIndex,cellIndex);

                // --
                rowPos = m_rowIndex;
                return rowPos;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        void excelExporter_HeaderCellExported(
            object sender, 
            HeaderCellExportedEventArgs e
            )
        {
            try
            {
                m_worksheet.Rows[e.CurrentRowIndex].Cells[e.CurrentColumnIndex].CellFormat.SetFormatting(
                    createGridColumnFormat(m_defaultFontName, m_defaultFontSize, false)
                    );
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

        public void excelExporter_CellExported(
            object sender, 
            CellExportedEventArgs e
            )
        {
            UltraGridCell[] cell = null;

            try
            {
                m_worksheet.Rows[e.CurrentRowIndex].Cells[e.CurrentColumnIndex].CellFormat.SetFormatting(
                    createGridCellFormat(m_defaultFontName, m_defaultFontSize, e.GridColumn.CellAppearance, e.GridRow.Cells[0].Appearance)
                    ); 
                
                // --

                if (e.GridColumn.MergedCellStyle == MergedCellStyle.Always)
                {
                    cell = e.GridRow.Cells[e.GridColumn.Index].GetMergedCells();
                    if (cell != null && e.GridRow.Index == cell[0].Row.Index)
                    {
                        m_worksheet.MergedCellsRegions.Add(e.CurrentRowIndex, e.CurrentColumnIndex, e.CurrentRowIndex + cell.GetLength(0) - 1, e.CurrentColumnIndex);
                    }
                }

                // --

                m_rowIndex = e.CurrentRowIndex;
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

        public int writeDetailViewGrid(
            FDetailViewGrid fDetailViewGrid,
            int rowIndex,
            int cellIndex,
            string fontName,
            int fontSize
            )
        {
            IWorksheetCellFormat colFormat = null;
            WorksheetCell cell = null;
            int rowPos = 0;
            int cellPos = 0;
            int rowOffset = 0;
            int cellOffset = 0;

            try
            {
                colFormat = createGridColumnFormat(fontName, fontSize, false);

                // --

                foreach (UltraGridColumn col in fDetailViewGrid.DisplayLayout.Bands[0].Columns)
                {
                    cellPos = cellIndex + cellOffset;

                    // --

                    cell = m_worksheet.Rows[rowIndex].Cells[cellPos];
                    cell.CellFormat.SetFormatting(colFormat);
                    cell.Value = col.Header.Caption;
                    m_worksheet.Columns[cellPos].Width = DefaultColumnWidth;

                    // --

                    cellOffset++;
                }

                // --                
                
                foreach (UltraGridRow row in fDetailViewGrid.Rows)
                {
                    // ***
                    // 2017.07.06 by spike.lee
                    // Hidden Row는 기록하지 않도록 수정
                    // *** 
                    if (row.Hidden)
                    {
                        continue;
                    }

                    // --

                    rowPos = rowIndex + rowOffset;
                    cellOffset = 0;

                    // --

                    foreach (UltraGridCell c in row.Cells)
                    {
                        cellPos = cellIndex + cellOffset;

                        // --

                        cell = m_worksheet.Rows[rowPos].Cells[cellPos];
                        // --
                        // ***
                        // Header인지 Data인지 구분 (짝수면 Header, 홀수면 Data)
                        // ***
                        if (cellOffset % 2 == 0)
                        {
                            cell.CellFormat.SetFormatting(createGridColumnFormat(fontName, fontSize, false));
                        }
                        else
                        {
                            cell.CellFormat.SetFormatting(createGridCellFormat(fontName, fontSize, c.Column.CellAppearance, c.Appearance));
                        }
                        // --
                        cell.Value = c.Text;

                        // --

                        cellOffset++;
                    }

                    // --

                    rowOffset++;
                }

                return rowPos;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                colFormat = null;
                cell = null;
            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int writeDetailViewGrid(
            FDetailViewGrid fDetailViewGrid,
            int rowIndex,
            int cellIndex
            )
        {
            try
            {
                return writeDetailViewGrid(fDetailViewGrid, rowIndex, cellIndex, m_defaultFontName, m_defaultFontSize);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void writeTreeView(
            FTreeView fTreeView,
            int rowTopIndex,
            int cellLeftIndex,
            int rowBottomIndex,
            int cellRightIndex
            )
        {
            WorksheetImage wsi = null;
            Bitmap image = null;
            
            try
            {
                image = new Bitmap(fTreeView.Width, fTreeView.Height);
                fTreeView.DrawToBitmap(image, new Rectangle(fTreeView.Location, fTreeView.Size));

                // --

                wsi = new WorksheetImage(image);
                // --
                wsi.TopLeftCornerCell = m_worksheet.Rows[rowTopIndex].Cells[cellLeftIndex];
                wsi.BottomRightCornerCell = m_worksheet.Rows[rowBottomIndex].Cells[cellRightIndex];
                // --
                m_worksheet.Shapes.Add(wsi);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                image = null;
                wsi = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void writeChart(
            Chart chart,
            int rowTopIndex,
            int cellLeftIndex,
            int rowBottomIndex,
            int cellRightIndex
            )
        {
            WorksheetImage wsi = null;
            Bitmap image = null;

            try
            {
                image = new Bitmap(chart.Width, chart.Height);
                chart.DrawToBitmap(image, new Rectangle(0,0,chart.Width,chart.Height));
                
                // --

                wsi = new WorksheetImage(image);
                // --
                wsi.TopLeftCornerCell = m_worksheet.Rows[rowTopIndex].Cells[cellLeftIndex];
                wsi.BottomRightCornerCell = m_worksheet.Rows[rowBottomIndex].Cells[cellRightIndex];
                // --
                m_worksheet.Shapes.Add(wsi);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                image = null;
                wsi = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void writeImage(
            Bitmap image,
            int rowTopIndex,
            int cellLeftIndex,
            int rowBottomIndex,
            int cellRightIndex
            )
        {
            WorksheetImage wsi = null;

            try
            {
                // --

                wsi = new WorksheetImage(image);
                wsi.Outline = ShapeOutline.FromColor(Color.Black);

                // --                
                wsi.TopLeftCornerCell = m_worksheet.Rows[rowTopIndex].Cells[cellLeftIndex];
                wsi.BottomRightCornerCell = m_worksheet.Rows[rowBottomIndex].Cells[cellRightIndex];
                // --
                m_worksheet.Shapes.Add(wsi);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                wsi = null;
            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
