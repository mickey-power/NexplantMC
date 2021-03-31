/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrHcnExpressionUITypeEditor.cs
--  Creator         : kitae kim
--  Create Date     : 2011.08.30
--  Description     : FAMate TCP Modeler Function Function UI Type Editor Property Class 
--  History         : Created by kitae kim at 2011.08.30 
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
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.TcpModeler
{
    public class FPropAttrFunFunctionUITypeEditor : UITypeEditor
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context
            )
        {
            FPropFun fPropFun = null;

            try
            {
                fPropFun = (FPropFun)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);                
                return UITypeEditorEditStyle.Modal;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {
                fPropFun = null;
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
            FPropFun fPropFun = null;
            FFunctionSelector dialog = null;
            try
            {
                fPropFun = (FPropFun)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                // --

                dialog = new FFunctionSelector(fPropFun.mainObject , fPropFun.fFunction);
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return fPropFun.fFunction.functionName;                    
                }

                if (dialog.fSelectedFunctionName == fPropFun.fFunction.functionName)
                {
                    return fPropFun.fFunction.functionName;
                }

                if (dialog.fSelectedFunctionName == null)
                {
                    return string.Empty;
                }
                else
                {                    
                    return dialog.fSelectedFunctionName.name;                    
                }                
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {
                if(dialog != null)
                {
                    dialog.Dispose();
                    dialog = null;
                }
                fPropFun = null;
            }
            return base.EditValue(context, provider, value);
        }

        #endregion
        
        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
