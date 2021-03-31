/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrOepOperandUITypeEditor.cs
--  Creator         : spike.lee
--  Create Date     : 2011.08.11
--  Description     : FAMate OPC Modeler OPC Expression Operand UI Type Editor Property Class 
--  History         : Created by spike.lee at 2012.08.26
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
    public class FPropAttrOepOperandUITypeEditor : UITypeEditor
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context
            )
        {
            FPropOep fPropPep = null;

            try
            {
                fPropPep = (FPropOep)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                if (
                    fPropPep.fOpcExpression.fAncestorOpcCondition != null &&
                    fPropPep.fOpcExpression.fAncestorOpcCondition.hasMessage
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
            FPropOep fPropPep = null;
            FOpcOperandType fOperandType;
            FOpcItemSelector fOpcItemSelector = null;
            FOpcEventItemSelector fOpcEventItemSelector = null;
            FEnvironmentSelector fEnvironmentSelector = null;
            FEquipmentStateSelector2 fEquipmentStateSelector = null;
            FIOpcOperand fOpd = null;

            try
            {
                fPropPep = (FPropOep)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                fOperandType = fPropPep.fOpcExpression.fOperandType;

                // --

                if (fOperandType == FOpcOperandType.OpcItem)
                {
                    fOpcItemSelector = new FOpcItemSelector(
                        fPropPep.mainObject,
                        fPropPep.fOpcExpression.fComparisonMode,
                        fPropPep.fOpcExpression.fAncestorOpcCondition.fMessage,
                        (FIOpcOperand)fPropPep.fOpcExpression.fOperand,
                        FOpcOperandType.OpcItem
                        );
                    if (fOpcItemSelector.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return string.Empty;
                    }

                    // --

                    fOpd = fOpcItemSelector.fSelectedItem;
                }
                else if (fOperandType == FOpcOperandType.OpcEventItem)
                {
                    fOpcEventItemSelector = new FOpcEventItemSelector(
                        fPropPep.mainObject,
                        fPropPep.fOpcExpression.fComparisonMode,
                        fPropPep.fOpcExpression.fAncestorOpcCondition.fMessage,
                        (FIOpcOperand)fPropPep.fOpcExpression.fOperand,
                        FOpcOperandType.OpcEventItem
                        );
                    if (fOpcEventItemSelector.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return string.Empty;
                    }

                    // --

                    fOpd = fOpcEventItemSelector.fSelectedItem;
                }
                else if (fOperandType == FOpcOperandType.Environment)
                {
                    fEnvironmentSelector = new FEnvironmentSelector(
                        fPropPep.mainObject,
                        (FEnvironment)fPropPep.fOpcExpression.fOperand
                        );
                    if (fEnvironmentSelector.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return string.Empty;
                    }

                    // --

                    fOpd = fEnvironmentSelector.fSelectedEnvironment;
                }
                else if (fOperandType == FOpcOperandType.EquipmentState)
                {
                    fEquipmentStateSelector = new FEquipmentStateSelector2(
                        fPropPep.mainObject,
                        (FEquipmentState)fPropPep.fOpcExpression.fOperand
                        );
                    if (fEquipmentStateSelector.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return string.Empty;
                    }

                    // --

                    fOpd = fEquipmentStateSelector.fSelectedEquipmentState;
                }

                // --

                if (fOpd == fPropPep.fOpcExpression.fOperand)
                {
                    return string.Empty;
                }

                // --

                if (fOpd == null)
                {
                    fPropPep.fOpcExpression.resetOperand();
                }
                else
                {
                    fPropPep.fOpcExpression.setOperand(fOpd);
                }
                fPropPep.setChangedOperand();

                // --

                return string.Empty;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {
                //if (fHostItemSelector != null)
                //{
                //    fHostItemSelector.Dispose();
                //    fHostItemSelector = null;
                //}
                fOpcItemSelector = null;
                fOpcEventItemSelector = null;
                if (fEnvironmentSelector != null)
                {
                    fEnvironmentSelector.Dispose();
                    fEnvironmentSelector = null;
                }

                fPropPep = null;
                fOpd = null;
            }
 	        return base.EditValue(context, provider, value);
        }        
    
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
