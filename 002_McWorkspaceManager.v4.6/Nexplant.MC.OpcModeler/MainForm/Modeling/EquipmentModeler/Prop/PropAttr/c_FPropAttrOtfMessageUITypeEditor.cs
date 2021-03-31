/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrOtfMessageUITypeEditor.cs
--  Creator         : spike.lee
--  Create Date     : 2013.08.27
--  Description     : FAMate OPC Modeler OPC Transfer Message Selector UI Type Editor Property Class 
--  History         : Created by spike.lee at 2013.08.27
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
    public class FPropAttrOtfMessageUITypeEditor : UITypeEditor
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
            FPropOtf fPropPtf = null;
            FOpcMessageSelector dialog = null;

            try
            {
                fPropPtf = (FPropOtf)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                // --

                dialog = new FOpcMessageSelector(
                    fPropPtf.mainObject,
                    fPropPtf.fOpcTransfer.fDevice,
                    fPropPtf.fOpcTransfer.fSession,
                    fPropPtf.fOpcTransfer.fMessage
                    );
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return string.Empty;
                }

                if (
                    dialog.fSelectedDevice == fPropPtf.fOpcTransfer.fDevice &&
                    dialog.fSelectedSession == fPropPtf.fOpcTransfer.fSession &&
                    dialog.fSelectedMessage == fPropPtf.fOpcTransfer.fMessage
                    )
                {
                    return string.Empty;
                }

                // --

                if (dialog.fSelectedMessage == null)
                {
                    fPropPtf.fOpcTransfer.resetMessage();
                }
                else
                {
                    fPropPtf.fOpcTransfer.setMessage(
                        dialog.fSelectedDevice,
                        dialog.fSelectedSession,
                        (FOpcMessage)dialog.fSelectedMessage
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
                fPropPtf = null;
            }
            return base.EditValue(context, provider, value);
        }

        #endregion 

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
