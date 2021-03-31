/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrEatEquipmentStateUITypeEditor.cs
--  Creator         : spike.lee
--  Create Date     : 2012.03.14
--  Description     : FAMate OPC Modeler Equipment State Alterer Equipment State Selector UI Type Editor Property Class 
--  History         : Created by spike.lee at 2012.03.14
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
    public class FPropAttrEatEquipmentStateUITypeEditor : UITypeEditor
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context
            )
        {
            FPropEat fPropEat = null;

            try
            {
                fPropEat = (FPropEat)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                if (
                    fPropEat.fEquipmentStateAlterer.fParent != null &&
                    fPropEat.fEquipmentStateAlterer.fParent.hasEquipmentStateSet
                    )
                {
                    return UITypeEditorEditStyle.Modal;
                }
                return UITypeEditorEditStyle.None;
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
            FPropEat fPropEat = null;
            FEquipmentStateSelector dialog = null;

            try
            {
                fPropEat = (FPropEat)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                // --

                dialog = new FEquipmentStateSelector(
                    fPropEat.mainObject, 
                    fPropEat.fEquipmentStateAlterer.fParent.fEquipmentStateSet,
                    fPropEat.fEquipmentStateAlterer.fEquipmentState
                    );
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return string.Empty;
                }

                if (dialog.fSelectedEquipmentState == fPropEat.fEquipmentStateAlterer.fEquipmentState)
                {
                    return string.Empty;
                }

                // --

                if (dialog.fSelectedEquipmentState == null)
                {
                    fPropEat.fEquipmentStateAlterer.resetEquipmentState();
                }
                else
                {
                    fPropEat.fEquipmentStateAlterer.setEquipmentState(dialog.fSelectedEquipmentState);
                }                

                // --

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
                fPropEat = null;
            }
            return base.EditValue(context, provider, value);
        }

        #endregion 

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
