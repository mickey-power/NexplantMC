/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrFunParameterStringConverter.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2011.08.16
--  Description     : FAMate TCP Modeler Funtion Parameter String Conveter Attribute Class 
--  History         : Created by Jeff.Kim at 2011.08.16
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
    public class FPropAttrFunParameterStringConverter : StringConverter
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override bool GetStandardValuesExclusive(
            ITypeDescriptorContext context
            )
        {
            try
            {
                return false;   // Keyboard Input Enable
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
            FPropFun fPropFun = null;
            string name = string.Empty;
            string[] values = null;

            try
            {
                fPropFun = (FPropFun)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                name = context.PropertyDescriptor.Name;

                // --

                if (name == "Parameter1")
                {
                    values = fPropFun.fFunction.defParameterValues1;
                }
                else if (name == "Parameter2")
                {
                    values = fPropFun.fFunction.defParameterValues2;
                }
                else if (name == "Parameter3")
                {
                    values = fPropFun.fFunction.defParameterValues3;
                }
                else if (name == "Parameter4")
                {
                    values = fPropFun.fFunction.defParameterValues4;
                }
                else if (name == "Parameter5")
                {
                    values = fPropFun.fFunction.defParameterValues5;
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
                fPropFun = null;                
            }
            return base.GetStandardValues(context);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
