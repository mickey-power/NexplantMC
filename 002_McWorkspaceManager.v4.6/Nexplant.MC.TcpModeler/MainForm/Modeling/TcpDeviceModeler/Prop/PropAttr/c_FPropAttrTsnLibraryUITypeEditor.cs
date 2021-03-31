/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrTsnLibraryUITypeEditor.cs
--  Creator         : duchoi
--  Create Date     : 2013.07.24
--  Description     : FAMate TCP Modeler TCP Session Library Select UI Type Editor Property Class 
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
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.TcpModeler
{
    public class FPropAttrTsnLibraryUITypeEditor : UITypeEditor
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context
            )
        {
            FPropTsn fPropTsn = null;

            try
            {
                fPropTsn = (FPropTsn)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                if (fPropTsn.fTcpSession.locked)
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
                fPropTsn = null;
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
            FPropTsn fPropTsn = null;
            FTcpLibrarySelector dialog = null;

            try
            {
                fPropTsn = (FPropTsn)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                // --

                dialog = new FTcpLibrarySelector(fPropTsn.mainObject, fPropTsn.fTcpSession.fLibrary);
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return string.Empty;
                }

                if (dialog.fSelectedTcpLibrary == fPropTsn.fTcpSession.fLibrary)
                {
                    return string.Empty;
                }

                // --

                if (dialog.fSelectedTcpLibrary == null)
                {
                    fPropTsn.fTcpSession.resetLibrary();
                }
                else
                {
                    fPropTsn.fTcpSession.setLibrary(dialog.fSelectedTcpLibrary);
                }

                // --

                fPropTsn.fPropGrid.onDynPropNoticeRaised(fPropTsn, "LibraryChanged");

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
                fPropTsn = null;

            }
            return base.EditValue(context, provider, value);
        }        
    
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
