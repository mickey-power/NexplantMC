/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrSepOperandUITypeEditor.cs
--  Creator         : spike.lee
--  Create Date     : 2011.08.08
--  Description     : FAMate SECS Modeler SECS Expression Operand UI Type Editor Property Class 
--  History         : Created by spike.lee at 2011.08.08
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
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.SecsModeler
{
    public class FPropAttrSepOperandUITypeEditor : UITypeEditor
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context
            )
        {
            FPropSep fPropSep = null;

            try
            {
                fPropSep = (FPropSep)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                if (
                    fPropSep.fSecsExpression.fAncestorSecsCondition != null &&
                    fPropSep.fSecsExpression.fAncestorSecsCondition.hasMessage
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
            FPropSep fPropSep = null;
            FSecsOperandType fOperandType;
            FSecsItemSelector fSecsItemSelector = null;
            FEnvironmentSelector fEnvironmentSelector = null;
            FEquipmentStateSelector2 fEquipmentStateSelector = null;
            FISecsOperand fOpd = null;

            try
            {
                fPropSep = (FPropSep)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                fOperandType = fPropSep.fSecsExpression.fOperandType;

                // --

                if (fOperandType == FSecsOperandType.SecsItem)
                {
                    fSecsItemSelector = new FSecsItemSelector(
                        fPropSep.mainObject,
                        fPropSep.fSecsExpression.fComparisonMode,
                        fPropSep.fSecsExpression.fAncestorSecsCondition.fMessage,
                        (FSecsItem)fPropSep.fSecsExpression.fOperand
                        );
                    if (fSecsItemSelector.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return string.Empty;
                    }

                    // --

                    fOpd = fSecsItemSelector.fSelectedItem;
                }
                else if (fOperandType == FSecsOperandType.Environment)
                {
                    fEnvironmentSelector = new FEnvironmentSelector(
                        fPropSep.mainObject,                        
                        (FEnvironment)fPropSep.fSecsExpression.fOperand
                        );
                    if (fEnvironmentSelector.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return string.Empty;
                    }                    

                    // --

                    fOpd = fEnvironmentSelector.fSelectedEnvironment;
                }
                else if (fOperandType == FSecsOperandType.EquipmentState)
                {
                    fEquipmentStateSelector = new FEquipmentStateSelector2(
                        fPropSep.mainObject,
                        (FEquipmentState)fPropSep.fSecsExpression.fOperand
                        );
                    if (fEquipmentStateSelector.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return string.Empty;
                    }

                    // --

                    fOpd = fEquipmentStateSelector.fSelectedEquipmentState;
                }

                // --

                if (fOpd == fPropSep.fSecsExpression.fOperand)
                {
                    return string.Empty;
                }

                // --

                if (fOpd == null)
                {
                    fPropSep.fSecsExpression.resetOperand();
                }
                else
                {
                    fPropSep.fSecsExpression.setOperand(fOpd);
                }
                fPropSep.setChangedOperand();

                // --

                return string.Empty;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {
                if (fSecsItemSelector != null)
                {
                    fSecsItemSelector.Dispose();
                    fSecsItemSelector = null;
                }

                if (fEnvironmentSelector != null)
                {
                    fEnvironmentSelector.Dispose();
                    fEnvironmentSelector = null;
                }

                if (fEquipmentStateSelector != null)
                {
                    fEquipmentStateSelector.Dispose();
                    fEquipmentStateSelector = null;
                }

                fPropSep = null;
                fOpd = null;
            }
 	        return base.EditValue(context, provider, value);
        }        
    
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
