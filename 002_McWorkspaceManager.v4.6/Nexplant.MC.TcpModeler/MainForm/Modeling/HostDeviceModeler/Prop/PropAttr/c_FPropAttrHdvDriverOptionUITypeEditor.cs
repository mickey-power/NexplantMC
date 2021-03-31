/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrHdvDriverOptionUITypeEditor.cs
--  Creator         : duchoi
--  Create Date     : 2013.07.24
--  Description     : FAMate TCP Modeler Host Device Host Driver Option Setup UI Type Editor Property Class 
--  History         : Created by duchoi at 2013.07.24
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
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.TcpModeler
{
    public class FPropAttrHdvDriverOptionUITypeEditor : UITypeEditor
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context
            )
        {
            FPropHdv fPropHdv = null;

            try
            {
                fPropHdv = (FPropHdv)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                // --

                if (
                    fPropHdv.fHostDevice.driver == string.Empty ||
                    fPropHdv.fHostDevice.fState != FDeviceState.Closed
                    )
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
                fPropHdv = null;
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
            FPropHdv fPropHdv = null;

            try
            {
                fPropHdv = (FPropHdv)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                fPropHdv.fHostDevice.createHostDriverOption().showDialog(fPropHdv.mainObject.fWsmCore.fWsmContainer);
                // --
                return string.Empty;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {
                fPropHdv = null;
            }
 	        return base.EditValue(context, provider, value);
        }        
    
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
