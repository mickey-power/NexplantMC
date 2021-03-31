/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrGeneralCodeDataUITypeEditor.cs
--  Creator         : mjkim
--  Create Date     : 2013.12.13
--  Description     : FAMate Admin Manager General Code Data Property Attribute Type Editor  
--  History         : Created by mjkim at 2013.12.13
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public class FPropAttrGeneralCodeDataUITypeEditor : UITypeEditor
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
            FDynPropBase fProp = null;
            FGeneralCodeDataSelector dialog = null;
            string tableName = string.Empty;

            try
            {

                fProp = (FDynPropBase)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                // --

                if (fProp is FPropModelManual)
                {
                    if (context.PropertyDescriptor.Name == "ManualType")
                    {
                        tableName = "ADM_MANUAL_TYPE";
                    }

                    // --

                    dialog = new FGeneralCodeDataSelector(((FPropModelManual)fProp).mainObject, tableName, (string)value);
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (context.PropertyDescriptor.Name == "ManualType")
                        {
                            ((FPropModelManual)fProp).ManualType = dialog.selectedData;
                        }
                    }
                }
                else if (fProp is FPropSecs1ToHsmsConverter)
                {
                    if (context.PropertyDescriptor.Name == "Type")
                    {
                        tableName = "ADM_S2H_CVT_TYPE";
                    }

                    // --

                    dialog = new FGeneralCodeDataSelector(((FPropSecs1ToHsmsConverter)fProp).mainObject, tableName, (string)value);
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (context.PropertyDescriptor.Name == "Type")
                        {
                            ((FPropSecs1ToHsmsConverter)fProp).Type = dialog.selectedData;
                        }
                    }
                }
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
