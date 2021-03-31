/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FDownloadDbSelector.cs
--  Creator         : tjkim
--  Create Date     : 2013.10.10
--  Description     : FAMate SQL Manager Download DB Select Dialog Form Class 
--  History         : Created by tjkim at 2013.10.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
//using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.SqlManager
{
    public partial class FDatabaseSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSqmCore m_fSqmCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDatabaseSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDatabaseSelector(
            FSqmCore fSqmCore
            )
            : this()
        {
            base.fUIWizard = fSqmCore.fUIWizard;
            m_fSqmCore = fSqmCore;
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

        private void refreshChkDb(
            )
        {
            string[] downDbList = null;

            try
            {
                if (m_fSqmCore.fOption.downloadDatabase == string.Empty)
                {
                    return;
                }

                // --

                downDbList = m_fSqmCore.fOption.downloadDatabase.Split(';');

                foreach (string db in downDbList)
                {
                    if (db == string.Empty)
                    {
                        continue;
                    }

                    // --

                    if (db == FDbProvider.MsSqlServer.ToString())
                    {
                        chkMsSql.Checked = true;
                    }
                    else if (db == FDbProvider.Oracle.ToString())
                    {
                        chkOracle.Checked = true;
                    }
                    else if (db == FDbProvider.MySql.ToString())
                    {
                        chkMySql.Checked = true;
                    }
                    else if (db == FDbProvider.MariaDb.ToString())
                    {
                        chkMariaDb.Checked = true;
                    }
                    else if (db == FDbProvider.PostgreSql.ToString())
                    {
                        chkPostgreSql.Checked = true;
                    }
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

        #region FDownloadDbSelector Form Event Handler

        private void FDownloadDbSelector_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();
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

        private void FDownloadDbSelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshChkDb();
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnOk Control Event Handler

        private void btnOk_Click(
            object sender, 
            EventArgs e
            )
        {
            string dbList = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                if (chkMsSql.Checked == true)
                {
                    dbList += (FDbProvider.MsSqlServer.ToString() + ";");
                }
                if (chkOracle.Checked == true)
                {
                    dbList += (FDbProvider.Oracle.ToString() + ";");
                }
                if (chkMySql.Checked == true)
                {
                    dbList += (FDbProvider.MySql.ToString() + ";");
                }
                if (chkMariaDb.Checked == true)
                {
                    dbList += (FDbProvider.MariaDb.ToString() + ";");
                }
                if (chkPostgreSql.Checked == true)
                {
                    dbList += (FDbProvider.PostgreSql.ToString() + ";");
                }

                // --

                if (dbList == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0025", new object[] { "Database Type" }));
                }

                // --

                m_fSqmCore.fOption.downloadDatabase = dbList.TrimEnd(';');

                // --

                this.DialogResult = DialogResult.OK;
                this.Close();
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
