/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrOeiItemNameUITypeEditor.cs
--  Creator         : spike.lee
--  Create Date     : 2015.07.13
--  Description     : FAMate OPC Modeler Item Name of OPC Event Item UI Type Editor Property Class 
--  History         : Created by spike.lee at 2015.07.13
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
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.OpcModeler
{
    public class FPropAttrOeiItemNameUITypeEditor : UITypeEditor
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context
            )
        {
            FPropOei fPropOei = null;

            try
            {
                fPropOei = (FPropOei)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                // --

                if (fPropOei.fOpcSession == null)
                {
                    return UITypeEditorEditStyle.None;
                }
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
            FPropOei fPropOei = null;
            FItemNameSelector dialog = null;

            try
            {
                fPropOei = (FPropOei)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                // --

                dialog = new FItemNameSelector(fPropOei.mainObject, fPropOei.fOpcSession, fPropOei.ItemName);
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    fPropOei.ItemName = dialog.fSelectedItemName.name;
                    fPropOei.ItemFormat = dialog.fSelectedItemName.fItemFormat;
                    fPropOei.ItemArray = dialog.fSelectedItemName.itemArray;
                }

                return fPropOei.ItemName;
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
                fPropOei = null;
            }
            return base.EditValue(context, provider, value);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
