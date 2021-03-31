/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrVfmTypeStringConverter.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.03
--  Description     : FAMate OPC Modeler Value Formula Type String Conveter Attribute Class 
--  History         : Created by spike.lee at 2011.03.03
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
    public class FPropAttrVfmTypeStringConverter : StringConverter
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override bool GetStandardValuesExclusive(
            ITypeDescriptorContext context
            )
        {
            try
            {
                return true;   // Keyboard Input Disalbe
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {

            }
            return base.GetStandardValuesExclusive(context);
        }

        //------------------------------------------------------------------------------------------------------------------------

        public override bool GetStandardValuesSupported(
            ITypeDescriptorContext context
            )
        {
            try
            {
                return true;    // Standard Input Enable
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {

            }
            return base.GetStandardValuesSupported(context);
        }

        //------------------------------------------------------------------------------------------------------------------------

        public override StandardValuesCollection GetStandardValues(
            ITypeDescriptorContext context
            )
        {
            FPropVfm fPropVfm = null;
            string[] values = null;

            try
            {
                fPropVfm = (FPropVfm)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                
                // --
                
                if (
                    fPropVfm.fValueTransformer.fFormat == FFormat.Ascii ||
                    fPropVfm.fValueTransformer.fFormat == FFormat.A2 ||
                    fPropVfm.fValueTransformer.fFormat == FFormat.JIS8
                    )
                {
                    values = new string[]{
                        FValueFormulaType.Choose.ToString(),
                        FValueFormulaType.ChooseR.ToString(),
                        FValueFormulaType.ChooseIncluded.ToString(),
                        FValueFormulaType.ChooseIncludedR.ToString(),
                        FValueFormulaType.DateTime.ToString(),
                        FValueFormulaType.DecimalToHex.ToString(),      // 2017.03.27 by spike.lee
                        FValueFormulaType.FixLength.ToString(),
                        FValueFormulaType.FixLengthR.ToString(),
                        FValueFormulaType.HexToDecimal.ToString(),      // 2017.03.27 by spike.lee
                        FValueFormulaType.Insert.ToString(),
                        FValueFormulaType.InsertR.ToString(),
                        FValueFormulaType.Length.ToString(),
                        FValueFormulaType.PadLeft.ToString(),
                        FValueFormulaType.PadRight.ToString(),
                        FValueFormulaType.Prefix.ToString(),
                        FValueFormulaType.Remove.ToString(),
                        FValueFormulaType.RemoveR.ToString(),
                        FValueFormulaType.Replace.ToString(),
                        FValueFormulaType.Select.ToString(),
                        FValueFormulaType.SelectR.ToString(),
                        FValueFormulaType.SelectIncluded.ToString(),
                        FValueFormulaType.SelectIncludedR.ToString(),
                        FValueFormulaType.StringCount.ToString(),
                        FValueFormulaType.SubString.ToString(),
                        FValueFormulaType.SubStringR.ToString(),
                        FValueFormulaType.Suffix.ToString(),
                        FValueFormulaType.ToLower.ToString(),
                        FValueFormulaType.ToUpper.ToString(),
                        FValueFormulaType.Trim.ToString(),
                        FValueFormulaType.TrimAll.ToString(),
                        FValueFormulaType.TrimStart.ToString(),
                        FValueFormulaType.TrimEnd.ToString()
                        };
                }
                else
                {
                    values = new string[]{
                        FValueFormulaType.SelectArray.ToString(),
                        FValueFormulaType.SelectArrayR.ToString(),
                        FValueFormulaType.Add.ToString(),
                        FValueFormulaType.Subtract.ToString(),
                        FValueFormulaType.Multiply.ToString(),
                        FValueFormulaType.Divide.ToString(),
                        FValueFormulaType.Round.ToString(),
                        FValueFormulaType.Trunc.ToString(),
                        FValueFormulaType.Ceil.ToString(),
                        FValueFormulaType.Mod.ToString(),
                        };
                }

                // --

                return new StandardValuesCollection(values);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {

            }
            return base.GetStandardValues(context);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
