/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrEwdOpcHdvDriverOptionUITypeEditor.cs
--  Creator         : spike.lee
--  Create Date     : 2015.07.24
--  Description     : FAMate Admin Manager Host Device Host Driver Option Setup for OPC UI Type Editor Property Class 
--  History         : Created by spike.lee at 2013.12.20
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.AdminManager
{
    public class FPropAttrEwdOpcHdvDriverOptionUITypeEditor : UITypeEditor
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context
            )
        {
            FPropEwdOpcHdv fPropEwdHdv = null;

            try
            {
                fPropEwdHdv = (FPropEwdOpcHdv)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                // --

                if (fPropEwdHdv.fHostDevice.driver == string.Empty)
                {
                    return UITypeEditorEditStyle.None;
                }
                return UITypeEditorEditStyle.Modal;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {
                fPropEwdHdv = null;
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
            FPropEwdOpcHdv fPropEwdHdv = null;

            try
            {
                fPropEwdHdv = (FPropEwdOpcHdv)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                fPropEwdHdv.fHostDevice.createHostDriverOption().showDialog(fPropEwdHdv.mainObject.fWsmCore.fWsmContainer);
                // --
                fPropEwdHdv.setHostDriverOption(fPropEwdHdv.fHostDevice.driverOption);
                // --
                return string.Empty;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {
                fPropEwdHdv = null;
            }
 	        return base.EditValue(context, provider, value);
        }        
    
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
