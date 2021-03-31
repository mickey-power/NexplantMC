/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrMakerUITypeEditor.cs
--  Creator         : tjkim
--  Create Date     : 2013.05.21
--  Description     : FAMate Admin Manager Maker Property Attribute Type Editor  
--  History         : Created by tjkim at 2013.05.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public class FPropAttrEquipmentTypeMakerUITypeEditor : UITypeEditor
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
            catch (Exception ex)
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
            FPropEquipmentType fProp = null;
            FMakerSelector dialog = null;

            try
            {
                fProp = (FPropEquipmentType)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                // --

                dialog = new FMakerSelector(
                    fProp.mainObject,
                    fProp.Maker
                    );
                if (dialog.ShowDialog() == DialogResult.Cancel)
                {
                    return string.Empty;
                }

                //if (dialog.selectedMaker == fProp.Maker)
                //{
                //    return string.Empty;
                //}

                fProp.Maker = dialog.selectedMaker;
                return string.Empty;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {
                if (dialog != null)
                {
                    dialog.Dispose();
                    dialog = null;
                }
                fProp = null;
            }
            return base.EditValue(context, provider, value);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
