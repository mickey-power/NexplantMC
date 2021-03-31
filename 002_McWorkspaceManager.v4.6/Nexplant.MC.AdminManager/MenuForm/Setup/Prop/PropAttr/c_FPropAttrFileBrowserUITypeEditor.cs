/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrFileBrowserUITypeEditor.cs
--  Creator         : mj.kim
--  Create Date     : 2012.04.10
--  Description     : FAMate Admin Manager File Browser UI Property Attribute Type Editor  
--  History         : Created by mj.kim at 2012.04.10
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

namespace Nexplant.MC.AdminManager
{
    public class FPropAttrFileBrowserUITypeEditor : UITypeEditor
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
            FDynPropBase fProp = null;
            OpenFileDialog ofd = null;

            try
            {
                fProp = (FDynPropBase)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                // --

                if (fProp is FPropHostDriver)
                {
                    ofd = new OpenFileDialog();
                    ofd.Title = "Open Host Driver File";
                    ofd.InitialDirectory = "";
                    ofd.Filter = FConstants.HdrFileFilter;
                    ofd.Multiselect = false;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        ((FPropHostDriver)fProp).file = ofd.FileName;
                        fProp.fPropGrid.Refresh();
                    }
                }
                else if (fProp is FPropComponentVersion)
                {
                    ofd = new OpenFileDialog();
                    ofd.Title = "Open Component File";
                    ofd.InitialDirectory = "";
                    ofd.Filter = FConstants.ComFileFilter;
                    ofd.Multiselect = false;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        ((FPropComponentVersion)fProp).newFile = ofd.FileName;
                        fProp.fPropGrid.Refresh();
                    }
                }
                else if (fProp is FPropModelVersion)
                {
                    ofd = new OpenFileDialog();
                    ofd.Title = "Open Model File";
                    ofd.InitialDirectory = "";
                    // --
                    if (((FPropModelVersion)fProp).modelType == FEapType.SECS.ToString())
                    {
                        ofd.Filter = FConstants.SsmFileFilter;
                    }
                    //else if (((FPropModelVersion)fProp).modelType == FEapType.PLC.ToString()) 
                    //{
                    //    ofd.Filter = FConstants.PsmFileFilter;
                    //}
                    else if (((FPropModelVersion)fProp).modelType == FEapType.OPC.ToString()) 
                    {
                        ofd.Filter = FConstants.OsmFileFilter;
                    }
                    else if (((FPropModelVersion)fProp).modelType == FEapType.TCP.ToString())
                    {
                        ofd.Filter = FConstants.TsmFileFilter;
                    }
                    // --
                    ofd.Multiselect = false;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        ((FPropModelVersion)fProp).newFile = ofd.FileName;
                        fProp.fPropGrid.Refresh();
                    }
                }
                else if (fProp is FPropModelManual)
                {
                    ofd = new OpenFileDialog();
                    ofd.Title = "Open Model Manual";
                    ofd.InitialDirectory = "";
                    // --
                    ofd.Filter = FConstants.AllFileFilter;
                    ofd.Multiselect = false;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        ((FPropModelManual)fProp).NewFile = ofd.FileName;
                        fProp.fPropGrid.Refresh();
                    }
                }

                // --

                return null;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {
                if (ofd != null)
                {
                    ofd.Dispose();
                    ofd = null;
                }
                fProp = null;
            }
            return null;
        }

        #endregion 

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
