/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrTepOperandUITypeEditor.cs
--  Creator         : spike.lee
--  Create Date     : 2011.08.11
--  Description     : FAMate TCP Modeler TCP Expression Operand UI Type Editor Property Class 
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
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.TcpModeler
{
    public class FPropAttrTepOperandUITypeEditor : UITypeEditor
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context
            )
        {
            FPropTep fPropTep = null;

            try
            {
                fPropTep = (FPropTep)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                if (
                    fPropTep.fTcpExpression.fAncestorTcpCondition != null &&
                    fPropTep.fTcpExpression.fAncestorTcpCondition.hasMessage
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
            FPropTep fPropTep = null;
            FTcpItemSelector fTcpItemSelector = null;
            FEnvironmentSelector fEnvironmentSelector = null;
            FEquipmentStateSelector2 fEquipmentStateSelector = null;
            FITcpOperand fTpd = null;
            // --
            FTcpOperandType fOperandType = FTcpOperandType.TcpItem;

            try
            {
                fPropTep = (FPropTep)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                fOperandType = fPropTep.fTcpExpression.fOperandType;

                // --

                if (fOperandType == FTcpOperandType.TcpItem)
                {
                    fTcpItemSelector = new FTcpItemSelector(
                        fPropTep.mainObject,
                        fPropTep.fTcpExpression.fComparisonMode,
                        fPropTep.fTcpExpression.fAncestorTcpCondition.fMessage,
                        (FTcpItem)fPropTep.fTcpExpression.fOperand
                        );
                    if (fTcpItemSelector.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return string.Empty;
                    }

                    // --

                    fTpd = fTcpItemSelector.fSelectedItem;
                }
                else if (fOperandType == FTcpOperandType.Environment)
                {
                    fEnvironmentSelector = new FEnvironmentSelector(
                        fPropTep.mainObject,
                        (FEnvironment)fPropTep.fTcpExpression.fOperand
                        );
                    if (fEnvironmentSelector.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return string.Empty;
                    }

                    // --

                    fTpd = fEnvironmentSelector.fSelectedEnvironment;
                }
                else if (fOperandType == FTcpOperandType.EquipmentState)
                {
                    fEquipmentStateSelector = new FEquipmentStateSelector2(
                        fPropTep.mainObject,
                        (FEquipmentState)fPropTep.fTcpExpression.fOperand
                        );
                    if (fEquipmentStateSelector.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return string.Empty;
                    }

                    // --

                    fTpd = fEquipmentStateSelector.fSelectedEquipmentState;
                }

                // --

                if (fTpd == fPropTep.fTcpExpression.fOperand)
                {
                    return string.Empty;
                }

                // --

                if (fTpd == null)
                {
                    fPropTep.fTcpExpression.resetOperand();
                }
                else
                {
                    fPropTep.fTcpExpression.setOperand(fTpd);
                }
                fPropTep.setChangedOperand();

                // --

                return string.Empty;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {
                fPropTep = null;
                fTcpItemSelector = null;
                fEnvironmentSelector = null;
                fEquipmentStateSelector = null;
                fTpd = null;
            }
 	        return base.EditValue(context, provider, value);
        }        
    
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
