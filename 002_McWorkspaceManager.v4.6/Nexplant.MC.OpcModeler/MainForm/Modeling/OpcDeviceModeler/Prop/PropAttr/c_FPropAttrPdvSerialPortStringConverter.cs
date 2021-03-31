/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrSdvSerialPortStringConverter.cs
--  Creator         : duchoi
--  Create Date     : 2013.07.24
--  Description     : FAMate PLC Modeler PLC Device Serial Port String Conveter Attribute Class 
--  History         : Created by duchoi at 2013.07.24
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
//using Nexplant.MC.Core.FaPlcDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.OpcModeler
{
    public class FPropAttrSdvSerialPortStringConverter : StringConverter
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
            string[] values = null;

            try
            {
                values = new string[48];
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = "COM" + (i + 1).ToString();
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
