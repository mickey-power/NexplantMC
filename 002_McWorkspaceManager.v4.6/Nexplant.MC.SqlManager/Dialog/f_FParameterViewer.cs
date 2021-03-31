/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FParameterViewer.cs
--  Creator         : mjkim
--  Create Date     : 2013.02.21
--  Description     : FAMate SQL Manager Parameter Viewer Form Class 
--  History         : Created by mjkim at 2013.02.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.SqlManager
{
    public partial class FParameterViewer : Nexplant.MC.Core.FaUIs.FBaseStandardForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSqmCore m_fSqmCore = null;
        private FXmlNode m_fXmlNode = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FParameterViewer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FParameterViewer(
            FSqmCore fSqmCore,
            FXmlNode fXmlNode
            )
            : this()
        {
            base.fUIWizard = fSqmCore.fUIWizard;
            m_fSqmCore = fSqmCore;
            m_fXmlNode = fXmlNode;
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
                    m_fSqmCore = null;
                    m_fXmlNode = null;
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

        private void designGridOfList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --                
                uds.Band.Columns.Add("Microsoft SQL Server");
                uds.Band.Columns.Add("Oracle Database");
                uds.Band.Columns.Add("MySQL");
                uds.Band.Columns.Add("MariaDB");
                uds.Band.Columns.Add("PostgreSQL");

                // --

                grdList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Microsoft SQL Server"].CellAppearance.Image = Properties.Resources.Parameter;
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

        private void refreshGridOfList(
            )
        {
            string colume = string.Empty;
            int index = 0;

            try
            {
                grdList.beginUpdate(false);
                grdList.removeAllDataRow();

                // --

                foreach (FXmlNode n in m_fXmlNode.get_elemList(FXmlTagSqlQuery.E_SqlQuery))
                {
                    if (n.get_elemVal(FXmlTagSqlQuery.A_DbProvider, FXmlTagSqlQuery.D_DbProvider) == FDbProvider.MsSqlServer.ToString())
                    {
                        colume = "Microsoft SQL Server";
                    }
                    else if (
                        n.get_elemVal(FXmlTagSqlQuery.A_DbProvider, FXmlTagSqlQuery.D_DbProvider) == FDbProvider.Oracle.ToString() ||
                        n.get_elemVal(FXmlTagSqlQuery.A_DbProvider, FXmlTagSqlQuery.D_DbProvider) == FDbProvider.OracleEx.ToString() 
                        )
                    {
                        colume = "Oracle Database";
                    }
                    else if (n.get_elemVal(FXmlTagSqlQuery.A_DbProvider, FXmlTagSqlQuery.D_DbProvider) == FDbProvider.MySql.ToString())
                    {
                        colume = "MySQL";
                    }
                    else if (n.get_elemVal(FXmlTagSqlQuery.A_DbProvider, FXmlTagSqlQuery.D_DbProvider) == FDbProvider.MariaDb.ToString())
                    {
                        colume = "MariaDB";
                    }
                    else if (n.get_elemVal(FXmlTagSqlQuery.A_DbProvider, FXmlTagSqlQuery.D_DbProvider) == FDbProvider.PostgreSql.ToString())
                    {
                        colume = "PostgreSQL";
                    }

                    index = 0;
                    foreach (FXmlNode n2 in n.get_elemList(FXmlTagSqlParameter.E_SqlParameter))
                    {
                        grdList.appendOrUpdateDataRow(index.ToString(), new object[] { });
                        grdList.Rows[index].Cells[colume].Value = n2.get_elemVal(FXmlTagSqlParameter.A_SqlParameter, FXmlTagSqlParameter.D_SqlParameter);
                        index++;
                    }
                }

                // --

                grdList.endUpdate(false);
            }
            catch (Exception ex)
            {
                grdList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FParameterViewer Form Event Handler

        private void FParameterViewer_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfList();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FParameterViewer_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfList();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }

        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FParameterViewer_KeyDown(
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
}   // Namespace end
