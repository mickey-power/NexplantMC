/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FExcelExporter2.cs
--  Creator         : spike.lee
--  Create Date     : 2012.11.26
--  Description     : FAMate Core FaCommon Excel Exporter2 Class
--  History         : Created by spike.lee at 2012.11.26 
                        - 확장성이 없어 다시 만듭니다.
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
    public class FExcelExporter2 : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_fileName = string.Empty;
        private string m_defaultFontName = "Tahoma";
        private int m_defaultFontSize = 9;
        private Workbook m_workbook = null;
        private List<FExcelSheet> m_fExcelSheetList = null;
        private Dictionary<string, FExcelSheet> m_fExcelSheetDict = null;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FExcelExporter2(
            string fileName
            )            
        {
            m_fileName = fileName;
            // --
            init();
        }        

        //------------------------------------------------------------------------------------------------------------------------

        public FExcelExporter2(
            string fileName, 
            string defaultFontName, 
            int defaultFontSize
            )
        {
            m_fileName = fileName;
            m_defaultFontName = defaultFontName;
            m_defaultFontSize = defaultFontSize;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FExcelExporter2(
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods 

        private void init(
            )
        {
            try
            {
                m_workbook = new Workbook();
                if (Path.GetExtension(m_fileName).ToLower() == ".xlsx")
                {
                    m_workbook.SetCurrentFormat(WorkbookFormat.Excel2007);
                }               
 
                // --

                m_fExcelSheetList = new List<FExcelSheet>();
                m_fExcelSheetDict = new Dictionary<string, FExcelSheet>();
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
                if (m_fExcelSheetList != null)
                {
                    m_fExcelSheetList.Clear();
                    m_fExcelSheetList = null;
                }
             
                // --

                if (m_fExcelSheetDict != null)
                {
                    m_fExcelSheetDict.Clear();
                    m_fExcelSheetDict = null;
                }

                // --

                m_workbook = null;
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

        public int getExcelSheetCount(
            )
        {
            try
            {
                return m_fExcelSheetList.Count;
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

        public FExcelSheet getExcelSheet(
            string name
            )
        {
            try
            {
                if (!m_fExcelSheetDict.ContainsKey(name))
                {
                    return null;
                }

                // --

                return m_fExcelSheetDict[name];
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

        public FExcelSheet getExcelSheet(
            int index
            )
        {
            try
            {
                if (index < 0 || index > m_fExcelSheetList.Count - 1)
                {
                    return null;
                }

                // --

                return m_fExcelSheetList[index];
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

        public FExcelSheet addExcelSheet(
            string name
            )
        {
            FExcelSheet fExcelSht = null;

            try
            {
                if (m_fExcelSheetDict.ContainsKey(name))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "Excel Sheet"));
                }

                // --

                fExcelSht = new FExcelSheet(
                    m_defaultFontName, 
                    m_defaultFontSize, 
                    m_workbook.Worksheets.Add(name)
                    );

                // --

                m_fExcelSheetList.Add(fExcelSht);
                m_fExcelSheetDict.Add(name, fExcelSht);

                // --

                return fExcelSht;
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

        public void removeExcelSheet(
            string name
            )
        {
            FExcelSheet fExcelSht = null;

            try
            {
                if (!m_fExcelSheetDict.ContainsKey(name))
                {
                    return;
                }

                // --

                fExcelSht = m_fExcelSheetDict[name];
                // --
                m_fExcelSheetList.Remove(fExcelSht);                
                m_fExcelSheetDict.Remove(name);
                
                // --
                
                m_workbook.Worksheets.Remove(fExcelSht.worksheet);                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fExcelSht = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAllExcelSheet(
            )
        {
            try
            {
                m_fExcelSheetList.Clear();
                m_fExcelSheetDict.Clear();

                // --

                m_workbook.Worksheets.Clear();
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
            try
            {
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

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
