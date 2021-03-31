/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrMesEquipmentUITypeEditor.cs
--  Creator         : iskim
--  Create Date     : 2014.09.04
--  Description     : FAMate Admin Manager Equipment Property Attribute Type Editor  
--  History         : Created by iskim at 2014.09.04
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public class FPropAttrMesEquipmentUITypeEditor : UITypeEditor
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
            FPropEquipment fProp = null;
            FMesEquipmentSelector dialog = null;
            

            try
            {
                fProp = (FPropEquipment)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                // --

                dialog = new FMesEquipmentSelector(
                    fProp.mainObject,
                    (string)value
                    );
                if (dialog.ShowDialog() == DialogResult.Cancel)
                {
                    return fProp.Equipment;
                }
                
                // --
                
                fProp.EquipmentId = dialog.selectedEqpId;
                fProp.Description = dialog.selectedEqpDesc;
                fProp.Type = dialog.selectedEqpType;
                fProp.Area = dialog.selectedEqpArea;
                fProp.Line = dialog.selectedEqpLine;
                // --
                return dialog.selectedEqpName;
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
