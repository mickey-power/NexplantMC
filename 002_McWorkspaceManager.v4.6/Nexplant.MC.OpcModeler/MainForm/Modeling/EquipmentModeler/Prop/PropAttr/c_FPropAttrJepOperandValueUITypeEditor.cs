/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrJepOperandValueUITypeEditor.cs
--  Creator         : spike.lee
--  Create Date     : 2012.01.31
--  Description     : FAMate OPC Modeler Judgement Expression Operand Value UI Type Editor Property Class 
--  History         : Created by spike.lee at 2012.01.31
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
    public class FPropAttrJepOperandValueUITypeEditor : UITypeEditor
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context
            )
        {
            FPropJep fPropJep = null;

            try
            {
                fPropJep = (FPropJep)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                if (
                    fPropJep.fJudgementExpression.fAncestorJudgementCondition != null &&
                    fPropJep.fJudgementExpression.fAncestorJudgementCondition.hasDataSet
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
            FPropJep fPropJep = null;            
            FDataSelector fDataSelector = null;            
            FData fDat = null;

            try
            {
                fPropJep = (FPropJep)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                // --

                fDataSelector = new FDataSelector(
                    fPropJep.mainObject,
                    fPropJep.fJudgementExpression.fComparisonMode,
                    fPropJep.fJudgementExpression.fAncestorJudgementCondition.fDataSet,
                    (FData)fPropJep.fJudgementExpression.fOperandValue
                    );
                if (fDataSelector.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return string.Empty;
                }

                // --

                fDat = fDataSelector.fSelectedData;
                // --
                if (fDat == fPropJep.fJudgementExpression.fOperandValue)
                {
                    return string.Empty;
                }

                // --

                if (fDat == null)
                {
                    fPropJep.fJudgementExpression.resetOperandValue();
                }
                else
                {
                    fPropJep.fJudgementExpression.setOperandValue(fDat);
                }
                fPropJep.fPropGrid.Refresh();

                // --

                return string.Empty;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {
                if (fDataSelector != null)
                {
                    fDataSelector.Dispose();
                    fDataSelector = null;
                }
                fPropJep = null;
                fDat = null;
            }
 	        return base.EditValue(context, provider, value);
        }        
    
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
