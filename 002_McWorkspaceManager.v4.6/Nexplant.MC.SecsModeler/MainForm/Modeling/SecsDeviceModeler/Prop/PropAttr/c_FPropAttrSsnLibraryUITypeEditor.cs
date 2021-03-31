/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrSsnLibraryUITypeEditor.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.10
--  Description     : FAMate SECS Modeler SECS Session Library Select UI Type Editor Property Class 
--  History         : Created by spike.lee at 2011.03.10
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
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.SecsModeler
{
    public class FPropAttrSsnLibraryUITypeEditor : UITypeEditor
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context
            )
        {
            FPropSsn fPropSsn = null;

            try
            {
                fPropSsn = (FPropSsn)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                if (fPropSsn.fSecsSession.locked)
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
                fPropSsn = null;
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
            FPropSsn fPropSsn = null;
            FSecsLibrarySelector dialog = null;

            try
            {
                fPropSsn = (FPropSsn)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                // --

                dialog = new FSecsLibrarySelector(fPropSsn.mainObject, fPropSsn.fSecsSession.fLibrary);
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return string.Empty;
                }

                if (dialog.fSelectedSecsLibrary == fPropSsn.fSecsSession.fLibrary)
                {
                    return string.Empty;
                }

                // --

                if (dialog.fSelectedSecsLibrary == null)
                {
                    fPropSsn.fSecsSession.resetLibrary();
                }
                else
                {
                    fPropSsn.fSecsSession.setLibrary(dialog.fSelectedSecsLibrary);
                }                

                // --

                fPropSsn.fPropGrid.onDynPropNoticeRaised(fPropSsn, "LibraryChanged");

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
                fPropSsn = null;

            }
 	        return base.EditValue(context, provider, value);
        }        
    
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
