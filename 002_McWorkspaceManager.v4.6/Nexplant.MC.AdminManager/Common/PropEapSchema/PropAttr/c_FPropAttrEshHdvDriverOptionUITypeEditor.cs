/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrEshHdvDriverOptionUITypeEditor.cs
--  Creator         : mjkim
--  Create Date     : 2013.07.08
--  Description     : FAMate Admin Manager Host Device Host Driver Option Setup UI Type Editor Property Class 
--  History         : Created by mjkim at 2013.07.08
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
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.AdminManager
{
    public class FPropAttrEshHdvDriverOptionUITypeEditor : UITypeEditor
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context
            )
        {
            try
            {
                return UITypeEditorEditStyle.Modal;
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
            const string SecsHostDriverTypeName = "Nexplant.MC.HostDriver.SECS.FHostDriverOption";
            const string OpcHostDriverTypeName = "Nexplant.MC.HostDriver.OPC.FHostDriverOption";
            const string TcpHostDriverTypeName = "Nexplant.MC.HostDriver.TCP.FHostDriverOption";
            const string DriverOptionInvokeDialog = "showDialog";
            // --

            FPropEshHdv fPropHdv = null;
            string typeName = string.Empty;
            object obj = null;
            Type type;
            string filePath = string.Empty;
            FHdvOptionView dialog = null;
            FDynPropCusBase<FAdmCore> m_fProp = null;

            try
            {
                fPropHdv = (FPropEshHdv)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                // --
                if (fPropHdv.fEapType == FEapType.SECS)
                {
                    typeName = SecsHostDriverTypeName;
                }
                else if (fPropHdv.fEapType == FEapType.OPC)
                {
                    typeName = OpcHostDriverTypeName;
                }
                else if (fPropHdv.fEapType == FEapType.TCP)
                {
                    typeName = TcpHostDriverTypeName;
                }

                // --
                if (fPropHdv.fEapType != FEapType.FILE)
                {
                    filePath = fPropHdv.mainObject.fWsmCore.hostDriverPath + "\\" + fPropHdv.Driver;
                    obj = FReflection.createInstance(filePath, typeName);
                    type = FReflection.getType(filePath, typeName);
                    FReflection.invokeMethod(
                        obj,
                        type,
                        DriverOptionInvokeDialog,
                        new object[] { fPropHdv.mainObject.fWsmCore.fWsmContainer, fPropHdv.DriverOption, true }
                        );
                    // --
                    return string.Empty;
                }
                else
                {
                    m_fProp = (FDynPropCusBase<FAdmCore>)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                    // --

                    dialog = new FHdvOptionView(m_fProp.mainObject, (string)value, true);
                    dialog.ShowDialog();

                    // --

                    return value;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {
                fPropHdv = null;

                if (dialog != null)
                {
                    dialog.Dispose();
                    dialog = null;
                }
            }
 	        return base.EditValue(context, provider, value);
        }        
    
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
