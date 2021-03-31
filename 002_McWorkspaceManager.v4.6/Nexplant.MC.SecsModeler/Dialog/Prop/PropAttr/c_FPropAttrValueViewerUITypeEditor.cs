/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrValueViewerUITypeEditor.cs
--  Creator         : kitae
--  Create Date     : 2011.10.20
--  Description     : FAMate SECS Modeler Value Viewer UI Type Editor Property Class 
--  History         : Created by kitae at 2011.10.20
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Drawing.Design;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using System.Text;

namespace Nexplant.MC.SecsModeler
{
    public class FPropAttrValueViewerUITypeEditor : UITypeEditor
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

        public override object EditValue(
            ITypeDescriptorContext context, 
            System.IServiceProvider provider, 
            object value
            )
        {
            FDynPropCusBase<FSsmCore> fProp = null;
            FValueViewer dialog = null;
            string hint = string.Empty;
            StringBuilder val = null;

            try
            {
                fProp = (FDynPropCusBase<FSsmCore>)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                val = new StringBuilder();

                // --

                hint = "" + fProp.fPropGrid.Tag;                
                // --
                if (fProp is FPropSit)
                {
                    if (hint == "OriginalEncodingValue")
                    {
                        val.Append(((FPropSit)fProp).fSecsItem.originalEncodingValue);
                    }
                    else if (hint == "Value")
                    {
                        val.Append(((FPropSit)fProp).fSecsItem.stringValue);
                    }
                    else if (hint == "EncodingValue")
                    {
                        val.Append(((FPropSit)fProp).fSecsItem.encodingValue);
                    }
                }
                else if (fProp is FPropSitl)
                {
                    if (hint == "OriginalValue")
                    {
                        val.Append(((FPropSitl)fProp).fSecsItemLog.originalStringValue);
                    }
                    if (hint == "OriginalEncodingValue")
                    {
                        val.Append(((FPropSitl)fProp).fSecsItemLog.originalEncodingValue);
                    }
                    else if (hint == "Value")
                    {
                        val.Append(((FPropSitl)fProp).fSecsItemLog.stringValue);
                    }
                    else if (hint == "EncodingValue")
                    {
                        val.Append(((FPropSitl)fProp).fSecsItemLog.encodingValue);
                    }
                }
                else if (fProp is FPropHit)
                {
                    if (hint == "OriginalEncodingValue")
                    {
                        val.Append(((FPropHit)fProp).fHostItem.originalEncodingValue);
                    }
                    else if (hint == "Value")
                    {
                        val.Append(((FPropHit)fProp).fHostItem.stringValue);
                    }
                    else if (hint == "EncodingValue")
                    {
                        val.Append(((FPropHit)fProp).fHostItem.encodingValue);
                    }
                }
                else if (fProp is FPropHitl)
                {
                    if (hint == "OriginalValue")
                    {
                        val.Append(((FPropHitl)fProp).fHostItemLog.originalStringValue);
                    }
                    if (hint == "OriginalEncodingValue")
                    {
                        val.Append(((FPropHitl)fProp).fHostItemLog.originalEncodingValue);
                    }
                    else if (hint == "Value")
                    {
                        val.Append(((FPropHitl)fProp).fHostItemLog.stringValue);
                    }
                    else if (hint == "EncodingValue")
                    {
                        val.Append(((FPropHitl)fProp).fHostItemLog.encodingValue);
                    }
                }
                else if (fProp is FPropEnv)
                {
                    if (hint == "EncodingValue")
                    {
                        val.Append(((FPropEnv)fProp).fEnvironment.encodingValue);
                    }
                }
                else if (fProp is FPropCol)
                {
                    if (hint == "OriginalEncodingValue")
                    {
                        val.Append(((FPropCol)fProp).fColumn.originalEncodingValue);
                    }
                    else if (hint == "Value")
                    {
                        val.Append(((FPropCol)fProp).fColumn.stringValue);
                    }
                    else if (hint == "EncodingValue")
                    {
                        val.Append(((FPropCol)fProp).fColumn.encodingValue);
                    }
                }
                else if (fProp is FPropColl)
                {
                    if (hint == "OriginalValue")
                    {
                        val.Append(((FPropColl)fProp).fColumnLog.originalStringValue);
                    }
                    if (hint == "OriginalEncodingValue")
                    {
                        val.Append(((FPropColl)fProp).fColumnLog.originalEncodingValue);
                    }
                    else if (hint == "Value")
                    {
                        val.Append(((FPropColl)fProp).fColumnLog.stringValue);
                    }
                    else if (hint == "EncodingValue")
                    {
                        val.Append(((FPropColl)fProp).fColumnLog.encodingValue);
                    }
                }
                else if (fProp is FPropDat)
                {
                    if (hint == "OriginalEncodingValue")
                    {
                        val.Append(((FPropDat)fProp).fData.originalEncodingValue);
                    }
                    else if (hint == "Value")
                    {
                        val.Append(((FPropDat)fProp).fData.stringValue);
                    }
                    else if (hint == "EncodingValue")
                    {
                        val.Append(((FPropDat)fProp).fData.encodingValue);
                    }
                }
                else if (fProp is FPropDatl)
                {
                    if (hint == "OriginalValue")
                    {
                        val.Append(((FPropDatl)fProp).fDataLog.originalStringValue);
                    }
                    if (hint == "OriginalEncodingValue")
                    {
                        val.Append(((FPropDatl)fProp).fDataLog.originalEncodingValue);
                    }
                    else if (hint == "Value")
                    {
                        val.Append(((FPropDatl)fProp).fDataLog.stringValue);
                    }
                    else if (hint == "EncodingValue")
                    {
                        val.Append(((FPropDatl)fProp).fDataLog.encodingValue);
                    }
                }
                else
                {
                    val.Append((string)value);
                }

                // --

                dialog = new FValueViewer(fProp.mainObject, val);                
                dialog.ShowDialog();

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
            }
            return base.EditValue(context, provider, value);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
