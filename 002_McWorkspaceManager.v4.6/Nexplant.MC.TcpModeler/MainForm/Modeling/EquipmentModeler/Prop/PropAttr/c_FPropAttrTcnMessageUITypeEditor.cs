/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrTcnMessageUITypeEditor.cs
--  Creator         : spike.lee
--  Create Date     : 2013.08.26
--  Description     : FAMate TCP Modeler TCP Condition Message Selector UI Type Editor Property Class 
--  History         : Created by spike.lee at 2013.08.26
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
    public class FPropAttrTcnMessageUITypeEditor : UITypeEditor
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
            catch(Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {
                
            }            
            return base.GetEditStyle(context);
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public override object EditValue(
            ITypeDescriptorContext context, 
            IServiceProvider provider, 
            object value
            )
        {
            FPropTcn fPropTcn = null;
            FTcpMessageSelector dialog = null;

            try
            {
                fPropTcn = (FPropTcn)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                // --

                dialog = new FTcpMessageSelector(
                    fPropTcn.mainObject,
                    fPropTcn.fTcpCondition.fDevice,
                    fPropTcn.fTcpCondition.fSession,
                    fPropTcn.fTcpCondition.fMessage
                    );
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return string.Empty;
                }

                if (
                    dialog.fSelectedDevice == fPropTcn.fTcpCondition.fDevice &&
                    dialog.fSelectedSession == fPropTcn.fTcpCondition.fSession &&
                    dialog.fSelectedMessage == fPropTcn.fTcpCondition.fMessage
                    )
                {
                    return string.Empty;
                }

                 // --

                if (dialog.fSelectedMessage == null)
                {
                    fPropTcn.fTcpCondition.resetMessage();
                }
                else
                {
                    fPropTcn.fTcpCondition.setMessage(
                        dialog.fSelectedDevice,
                        dialog.fSelectedSession,
                        (FTcpMessage)dialog.fSelectedMessage
                        );
                }                

                // --

                return string.Empty;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {
                if (dialog != null)
                {
                    dialog.Dispose();
                    dialog = null;
                }
                fPropTcn = null;
            }
            return base.EditValue(context, provider, value);
        }

        #endregion 

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
