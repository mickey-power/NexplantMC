/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrOcnDeviceUITypeEditor.cs
--  Creator         : spike.lee
--  Create Date     : 2013.08.26
--  Description     : FAMate OPC Modeler OPC Condition Device Selector UI Type Editor Property Class 
--  History         : Created by spike.lee at 2013.08.26
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
    public class FPropAttrOcnDeviceUITypeEditor : UITypeEditor
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context
            )
        {
            FPropOcn fPropPcn = null;
            try
            {
                fPropPcn = (FPropOcn)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                if (fPropPcn.ConditionMode == FOpcConditionMode.Connection)
                    return UITypeEditorEditStyle.Modal;
                return UITypeEditorEditStyle.None;
            }
            catch(Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {
                fPropPcn = null;
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
            FPropOcn fPropPcn = null;
            FOpcDeviceSelector dialog = null;

            try
            {
                fPropPcn = (FPropOcn)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                // --

                dialog = new FOpcDeviceSelector(
                    fPropPcn.mainObject,
                    fPropPcn.fOpcCondition.fDevice
                    );
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return string.Empty;
                }

                if (dialog.fSelectedDevice == fPropPcn.fOpcCondition.fDevice)
                {
                    return string.Empty;
                }

                // --

                if (dialog.fSelectedDevice == null)
                {
                    fPropPcn.fOpcCondition.resetDevice();
                }
                else
                {
                    fPropPcn.fOpcCondition.setDevice(
                        dialog.fSelectedDevice
                        );
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
                fPropPcn = null;
            }
            return base.EditValue(context, provider, value);
        }

        #endregion 

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
