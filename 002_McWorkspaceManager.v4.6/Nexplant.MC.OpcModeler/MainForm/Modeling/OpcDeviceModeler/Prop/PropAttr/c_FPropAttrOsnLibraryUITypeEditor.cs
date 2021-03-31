/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrOsnLibraryUITypeEditor.cs
--  Creator         : duchoi
--  Create Date     : 2013.07.24
--  Description     : FAMate OPC Modeler OPC Session Library Select UI Type Editor Property Class 
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
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.OpcModeler
{
    public class FPropAttrOsnLibraryUITypeEditor : UITypeEditor
    {

        //------------------------------------------------------------------------------------------------------------------------
        
        #region Methods

        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context
            )
        {
            FPropOsn fPropOsn = null;

            try
            {
                fPropOsn = (FPropOsn)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                if (fPropOsn.fOpcSession.locked)
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
                fPropOsn = null;
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
            FPropOsn fPropOsn = null;
            FOpcLibrarySelector dialog = null;

            try
            {
                fPropOsn = (FPropOsn)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                // --

                dialog = new FOpcLibrarySelector(fPropOsn.mainObject, fPropOsn.fOpcSession.fLibrary);
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return string.Empty;
                }

                if (dialog.fSelectedOpcLibrary == fPropOsn.fOpcSession.fLibrary)
                {
                    return string.Empty;
                }

                // --

                if (dialog.fSelectedOpcLibrary == null)
                {
                    fPropOsn.fOpcSession.resetLibrary();
                }
                else
                {
                    fPropOsn.fOpcSession.setLibrary(dialog.fSelectedOpcLibrary);
                }                

                // --

                fPropOsn.fPropGrid.onDynPropNoticeRaised(fPropOsn, "LibraryChanged");

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
                fPropOsn = null;

            }
 	        return base.EditValue(context, provider, value);
        }        
    
        #endregion
        
        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
