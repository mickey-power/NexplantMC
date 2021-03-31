/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrHepOperandUITypeEditor.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2011.08.11
--  Description     : FAMate TCP Modeler Host Expression Operand UI Type Editor Property Class 
--  History         : Created by Jeff.Kim at 2011.08.11
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
    public class FPropAttrHepOperandUITypeEditor : UITypeEditor
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context
            )
        {
            FPropHep fPropHep = null;

            try
            {
                fPropHep = (FPropHep)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                if (
                    fPropHep.fHostExpression.fAncestorHostCondition != null &&
                    fPropHep.fHostExpression.fAncestorHostCondition.hasMessage
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

        public override object  EditValue(
            ITypeDescriptorContext context, 
            IServiceProvider provider, 
            object value
            )
        {
            FPropHep fPropHep = null;
            FHostOperandType fOperandType;
            FHostItemSelector fHostItemSelector = null;
            FEnvironmentSelector fEnvironmentSelector = null;
            FEquipmentStateSelector2 fEquipmentStateSelector = null;
            FIHostOperand fOpd = null;

            try
            {
                fPropHep = (FPropHep)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                fOperandType = fPropHep.fHostExpression.fOperandType;

                // --

                if (fOperandType == FHostOperandType.HostItem)
                {
                    fHostItemSelector = new FHostItemSelector(
                        fPropHep.mainObject,
                        fPropHep.fHostExpression.fComparisonMode,
                        fPropHep.fHostExpression.fAncestorHostCondition.fMessage,
                        (FHostItem)fPropHep.fHostExpression.fOperand
                        );
                    if (fHostItemSelector.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return string.Empty;
                    }

                    // --

                    fOpd = fHostItemSelector.fSelectedItem;
                }
                else if (fOperandType == FHostOperandType.Environment)
                {
                    fEnvironmentSelector = new FEnvironmentSelector(
                        fPropHep.mainObject,
                        (FEnvironment)fPropHep.fHostExpression.fOperand
                        );
                    if (fEnvironmentSelector.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return string.Empty;
                    }

                    // --

                    fOpd = fEnvironmentSelector.fSelectedEnvironment;
                }
                else if (fOperandType == FHostOperandType.EquipmentState)
                {
                    fEquipmentStateSelector = new FEquipmentStateSelector2(
                        fPropHep.mainObject,
                        (FEquipmentState)fPropHep.fHostExpression.fOperand
                        );
                    if (fEquipmentStateSelector.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return string.Empty;
                    }

                    // --

                    fOpd = fEquipmentStateSelector.fSelectedEquipmentState;
                }

                // --

                if (fOpd == fPropHep.fHostExpression.fOperand)
                {
                    return string.Empty;
                }

                // --

                if (fOpd == null)
                {
                    fPropHep.fHostExpression.resetOperand();
                }
                else
                {
                    fPropHep.fHostExpression.setOperand(fOpd);
                }
                fPropHep.setChangedOperand();

                // --

                return string.Empty;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {
                if (fHostItemSelector != null)
                {
                    fHostItemSelector.Dispose();
                    fHostItemSelector = null;
                }

                if (fEnvironmentSelector != null)
                {
                    fEnvironmentSelector.Dispose();
                    fEnvironmentSelector = null;
                }

                fPropHep = null;
                fOpd = null;
            }
 	        return base.EditValue(context, provider, value);
        }        
    
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
