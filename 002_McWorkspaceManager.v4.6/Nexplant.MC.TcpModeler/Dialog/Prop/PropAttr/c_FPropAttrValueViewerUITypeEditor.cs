/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrValueTransformerUITypeEditor.cs
--  Creator         : kitae
--  Create Date     : 2011.10.20
--  Description     : FAMate TCP Modeler TCP Item Log Value Transformer UI Type Editor Property Class 
--  History         : Created by kitae at 2011.10.20
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Text;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.TcpModeler
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
            FDynPropCusBase<FTcmCore> fProp = null;
            FValueViewer dialog = null;
            StringBuilder val = null;
            string hint = string.Empty;

            try
            {
                fProp = (FDynPropCusBase<FTcmCore>)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                val = new StringBuilder();

                // --

                hint = "" + fProp.fPropGrid.Tag;
                // --
                if (fProp is FPropTit)
                {
                    if (hint == "OriginalEncodingValue")
                    {
                        val.Append(((FPropTit)fProp).fTcpItem.originalEncodingValue);
                    }
                    else if (hint == "Value")
                    {
                        val.Append(((FPropTit)fProp).fTcpItem.stringValue);
                    }
                    else if (hint == "EncodingValue")
                    {
                        val.Append(((FPropTit)fProp).fTcpItem.encodingValue);
                    }
                }
                else if (fProp is FPropTitl)
                {
                    if (hint == "OriginalValue")
                    {
                        val.Append(((FPropTitl)fProp).fTcpItemLog.originalValue);
                    }
                    else if (hint == "OriginalEncodingValue")
                    {
                        val.Append(((FPropTitl)fProp).fTcpItemLog.originalEncodingValue);
                    }
                    else if (hint == "Value")
                    {
                        val.Append(((FPropTitl)fProp).fTcpItemLog.stringValue);
                    }
                    else if (hint == "EncodingValue")
                    {
                        val.Append(((FPropTitl)fProp).fTcpItemLog.encodingValue);
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
