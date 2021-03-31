/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrBackupServerUITypeEditor.cs
--  Creator         : spike.lee
--  Create Date     : 2012.03.21
--  Description     : FAMate Admin Manager Backup Server Property Attribute Type Editor  
--  History         : Created by spike.lee at 2012.03.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public class FPropAttrBackupServerUITypeEditor : UITypeEditor
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
            FPropServer fProp = null;
            FServerSelector fDialog = null;

            try
            {
                fProp = (FPropServer)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                // --

                fDialog = new FServerSelector(fProp.mainObject, fProp.ServerType.ToString(),fProp.BackupServer, "N");
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return string.Empty;
                }

                if (fDialog.selectedServer == fProp.BackupServer)
                {
                    return string.Empty;
                }                

                // --

                fProp.BackupServer = fDialog.selectedServer;
                return string.Empty;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {
                if (fDialog != null)
                {
                    fDialog.Dispose();
                    fDialog = null;
                }
                fProp = null;
            }
            return base.EditValue(context, provider, value);
        }

        #endregion 

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
