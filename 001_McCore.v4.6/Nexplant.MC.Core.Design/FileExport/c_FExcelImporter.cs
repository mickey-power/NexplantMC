/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FExcelImporter.cs
--  Creator         : kitae
--  Create Date     : 2012.05.29
--  Description     : FAMate Core FaCommon Excel Importer Class
--  History         : Created by kitae at 2012.05.29
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Data;
using System.Data.OleDb;
using Infragistics.Documents.Excel;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public class FExcelImporter : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;        
        private string m_fileName = string.Empty;
        private string m_excelCon = string.Empty;
        private string m_excelSql = "select * from[{0}$]";

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FExcelImporter(
            )
        {
            excelConnection();        
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FExcelImporter(
            string fileName
            )
            :this()
        {
            m_fileName = fileName;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FExcelImporter(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
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

        private string excelConnection(
            )
        {
            try
            {
                m_excelCon =
                    "Provider=Microsoft.ACE.OLEDB.12.0;" +
                    "Data Source=\"" + m_fileName + "\";" +
                    "Mode=ReadWrite|Share Deny None;" +
                    "Extended Properties='Excel 12.0; HDR={1}; IMEX={2}';" +
                    "Persist Security Info=False";
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

        //------------------------------------------------------------------------------------------------------------------------

        public DataSet excelImport(
            string sheetName
            )
        {
            OleDbConnection excelConn = null;
            OleDbDataAdapter excelAdapter = null;
            DataSet excelDs = null;

            try
            {
                excelConnection();
                excelConn = new OleDbConnection(m_excelCon);
                excelConn.Open();
                excelAdapter = new OleDbDataAdapter(string.Format(m_excelSql, sheetName), excelConn);
                excelDs = new DataSet();
                excelAdapter.Fill(excelDs);

                return excelDs;
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

        public DataSet excelImport(
            string fileName,
            string sheetName
            )
        {
            try
            {
                m_fileName = fileName;
                excelConnection();
                return excelImport(sheetName);
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

    }   // Class end
}   // Namespace end
