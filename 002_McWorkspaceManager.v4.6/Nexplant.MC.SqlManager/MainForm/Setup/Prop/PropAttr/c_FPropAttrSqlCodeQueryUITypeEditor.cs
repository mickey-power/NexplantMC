/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrSqlCodeQueryUITypeEditor.cs
--  Creator         : mj.kim
--  Create Date     : 2011.10.13
--  Description     : FAMate SQL Manager Sql Code Query UI Property Attribute Type Editor  
--  History         : Created by mj.kim at 2011.10.13
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.SqlManager
{
    public class FPropAttrSqlCodeQueryUITypeEditor : UITypeEditor
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context
            )
        {
            try
            {
                return UITypeEditorEditStyle.Modal;
            }
            catch(Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {

            }            
            return base.GetEditStyle(context);
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public override object EditValue(
            ITypeDescriptorContext context, 
            IServiceProvider provider, 
            object value
            )
        {
            FPropSqlCode fPropSqlCode = null;
            FQueryEditor fQueryEditor = null;

            try
            {
                fPropSqlCode = (FPropSqlCode)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                // --

                fQueryEditor = new FQueryEditor(fPropSqlCode.mainObject, (string)value, fPropSqlCode.UsedMigration.ToString());
                if (fQueryEditor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (fQueryEditor.copyToOtherQuery)
                    {
                        if (context.PropertyDescriptor.Name == "MsSqlQuery")
                        {
                            fPropSqlCode.OracleQuery = FDbAdapter.exportQueryFromMsSqlServer(FDbProvider.Oracle, fQueryEditor.query);
                            fPropSqlCode.MySqlQuery = FDbAdapter.exportQueryFromMsSqlServer(FDbProvider.MySql, fQueryEditor.query);
                            fPropSqlCode.MariaDbQuery = FDbAdapter.exportQueryFromMsSqlServer(FDbProvider.MariaDb, fQueryEditor.query);
                            fPropSqlCode.PostgreSqlQuery = FDbAdapter.exportQueryFromMsSqlServer(FDbProvider.PostgreSql, fQueryEditor.query);
                            fPropSqlCode.mainObject.onSqlQueryValueChanged(this, new System.Windows.Forms.PropertyValueChangedEventArgs(null, fPropSqlCode.MsSqlQuery));
                        }
                        else if (context.PropertyDescriptor.Name == "OracleQuery")
                        {
                            fPropSqlCode.MsSqlQuery = FDbAdapter.exportQueryFromOracle(FDbProvider.MsSqlServer, fQueryEditor.query);
                            fPropSqlCode.MySqlQuery = FDbAdapter.exportQueryFromOracle(FDbProvider.MySql, fQueryEditor.query);
                            fPropSqlCode.MariaDbQuery = FDbAdapter.exportQueryFromOracle(FDbProvider.MariaDb, fQueryEditor.query);
                            fPropSqlCode.PostgreSqlQuery = FDbAdapter.exportQueryFromOracle(FDbProvider.PostgreSql, fQueryEditor.query);
                            fPropSqlCode.mainObject.onSqlQueryValueChanged(this, new System.Windows.Forms.PropertyValueChangedEventArgs(null, fPropSqlCode.OracleQuery));
                        }
                        else if (context.PropertyDescriptor.Name == "MySqlQuery")
                        {
                            fPropSqlCode.MsSqlQuery = FDbAdapter.exportQueryFromMySql(FDbProvider.MsSqlServer, fQueryEditor.query);
                            fPropSqlCode.OracleQuery = FDbAdapter.exportQueryFromMySql(FDbProvider.Oracle, fQueryEditor.query);
                            fPropSqlCode.MariaDbQuery = FDbAdapter.exportQueryFromMySql(FDbProvider.MariaDb, fQueryEditor.query);
                            fPropSqlCode.PostgreSqlQuery = FDbAdapter.exportQueryFromMySql(FDbProvider.PostgreSql, fQueryEditor.query);
                            fPropSqlCode.mainObject.onSqlQueryValueChanged(this, new System.Windows.Forms.PropertyValueChangedEventArgs(null, fPropSqlCode.MySqlQuery));
                        }
                        else if (context.PropertyDescriptor.Name == "MariaDbQuery")
                        {
                            fPropSqlCode.MsSqlQuery = FDbAdapter.exportQueryFromMariaDb(FDbProvider.MsSqlServer, fQueryEditor.query);
                            fPropSqlCode.OracleQuery = FDbAdapter.exportQueryFromMariaDb(FDbProvider.Oracle, fQueryEditor.query);
                            fPropSqlCode.MySqlQuery = FDbAdapter.exportQueryFromMariaDb(FDbProvider.MySql, fQueryEditor.query);
                            fPropSqlCode.PostgreSqlQuery = FDbAdapter.exportQueryFromMariaDb(FDbProvider.PostgreSql, fQueryEditor.query);
                            fPropSqlCode.mainObject.onSqlQueryValueChanged(this, new System.Windows.Forms.PropertyValueChangedEventArgs(null, fPropSqlCode.MariaDbQuery));
                        }
                        else if (context.PropertyDescriptor.Name == "PostgreSqlQuery")
                        {
                            fPropSqlCode.MsSqlQuery = FDbAdapter.exportQueryFromPostgreSql(FDbProvider.MsSqlServer, fQueryEditor.query);
                            fPropSqlCode.OracleQuery = FDbAdapter.exportQueryFromPostgreSql(FDbProvider.Oracle, fQueryEditor.query);
                            fPropSqlCode.MySqlQuery = FDbAdapter.exportQueryFromPostgreSql(FDbProvider.MySql, fQueryEditor.query);
                            fPropSqlCode.MariaDbQuery = FDbAdapter.exportQueryFromPostgreSql(FDbProvider.MariaDb, fQueryEditor.query);
                            fPropSqlCode.mainObject.onSqlQueryValueChanged(this, new System.Windows.Forms.PropertyValueChangedEventArgs(null, fPropSqlCode.PostgreSqlQuery));
                        }
                    }
                    return fQueryEditor.query;
                }

                return value;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {
                if (fQueryEditor != null)
                {
                    fQueryEditor.Dispose();
                    fQueryEditor = null;
                }

                // --

                fPropSqlCode = null;
            }
            return base.EditValue(context, provider, value);
        }

        #endregion 

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
