/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrEwdEqpSelectUITypeEditor.cs
--  Creator         : kitae
--  Create Date     : 2012.04.04
--  Description     : FAMate Admin Manager Equipment Select Property Attribute Type Editor  
--  History         : Created by kitae at 2012.04.04
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Collections;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public class FPropAttrEwdEqpSelectUITypeEditor : UITypeEditor
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
            object fProp = null;
            FPropEwdSecsEqp fPropSecs = null;
            //FPropEwdPlcEqp fPropPlc = null;
            FPropEwdOpcEqp fPropOpc = null;
            FPropEwdTcpEqp fPropTcp = null;
            FAdmCore fAdmCore = null;
            string eqp = string.Empty;
            FEquipmentSelector dialog = null;

            try
            {
                fProp = ((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                if (fProp is FPropEwdSecsEqp)
                {
                    fPropSecs = (FPropEwdSecsEqp)fProp;
                    fAdmCore = fPropSecs.mainObject;
                    eqp = fPropSecs.Name;
                }
                //else if (fProp is FPropEwdPlcEqp)
                //{
                //    fPropPlc = (FPropEwdPlcEqp)fProp;
                //    fAdmCore = fPropPlc.mainObject;
                //    eqp = fPropPlc.Name;
                //}
                else if (fProp is FPropEwdOpcEqp)
                {
                    fPropOpc = (FPropEwdOpcEqp)fProp;
                    fAdmCore = fPropOpc.mainObject;
                    eqp = fPropOpc.Name;
                }
                else if (fProp is FPropEwdTcpEqp)
                {
                    fPropTcp = (FPropEwdTcpEqp)fProp;
                    fAdmCore = fPropTcp.mainObject;
                    eqp = fPropTcp.Name;
                }
                else
                {
                    return string.Empty;
                }

                // --

                dialog = new FEquipmentSelector(fAdmCore, eqp, "N");
                if (dialog.ShowDialog() == DialogResult.Cancel)
                {
                    return string.Empty;
                }

                // --
                
                if (fProp is FPropEwdSecsEqp)
                {
                    fPropSecs.Name = dialog.selectedEqpName;
                    fPropSecs.Description = dialog.selectedEqpDesc;
                }
                //else if (fProp is FPropEwdPlcEqp)
                //{
                //    fPropPlc.Name = dialog.selectedEqpName;
                //    fPropPlc.Description = dialog.selectedEqpDesc;
                //}
                else if (fProp is FPropEwdOpcEqp)
                {
                    fPropOpc.Name = dialog.selectedEqpName;
                    fPropOpc.Description = dialog.selectedEqpDesc;
                }
                else if (fProp is FPropEwdTcpEqp)
                {
                    fPropTcp.Name = dialog.selectedEqpName;
                    fPropTcp.Description = dialog.selectedEqpDesc;
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
                fProp = null;
                fPropSecs = null;
                //fPropPlc = null;
                fPropOpc = null;
                fPropTcp = null;
            }
            return base.EditValue(context, provider, value);
        }

        #endregion 

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
