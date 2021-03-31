/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FCommon.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.28
--  Description     : FAMate Core FaSecsDriver Common Function Class 
--  History         : Created by spike.lee at 2011.01.28
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal static class FCommon
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods        

        public static bool compareSearchObject(
            FXmlNode fXmlNode,
            string searchWord
            )
        {
            string encodingValue = string.Empty;

            try
            {
                if (fXmlNode.name == FXmlTagSIT.E_SecsItem)
                {
                    encodingValue = FValueConverter.toDataConversionedEncodingValue(
                        FEnumConverter.toFormat(fXmlNode.get_attrVal(FXmlTagSIT.A_Format, FXmlTagSIT.D_Format)),
                        fXmlNode.get_attrVal(FXmlTagSIT.A_Value, FXmlTagSIT.D_Value),
                        fXmlNode.get_attrVal(FXmlTagSIT.A_Transformer, FXmlTagSIT.D_Transformer),
                        fXmlNode.get_attrVal(FXmlTagSIT.A_DataConversionSetExpression, FXmlTagSIT.D_DataConversionSetExpression)
                        );
                    if (encodingValue.ToLower().Contains(searchWord))
                    {
                        return true;
                    }
                }
                else if (fXmlNode.name == FXmlTagHMS.E_HostMessages)
                {
                    if (fXmlNode.get_attrVal(FXmlTagHMS.A_Command, FXmlTagHMS.D_Command).ToLower().Contains(searchWord))
                    {
                        return true;
                    }
                }
                else if (fXmlNode.name == FXmlTagHMG.E_HostMessage)
                {
                    if (fXmlNode.get_attrVal(FXmlTagHMG.A_Command, FXmlTagHMG.D_Command).ToLower().Contains(searchWord))
                    {
                        return true;
                    }
                }
                else if (fXmlNode.name == FXmlTagHIT.E_HostItem)
                {
                    encodingValue = FValueConverter.toDataConversionedEncodingValue(
                        FEnumConverter.toFormat(fXmlNode.get_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format)),
                        fXmlNode.get_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value),
                        fXmlNode.get_attrVal(FXmlTagHIT.A_Transformer, FXmlTagHIT.D_Transformer),
                        fXmlNode.get_attrVal(FXmlTagHIT.A_DataConversionSetExpression, FXmlTagHIT.D_DataConversionSetExpression)
                        );
                    if (encodingValue.ToLower().Contains(searchWord))
                    {
                        return true;
                    }
                }
                else if (fXmlNode.name == FXmlTagUTN.E_UserTagName)
                {
                    if (
                        fXmlNode.get_attrVal(FXmlTagUTN.A_UserTagName1, FXmlTagUTN.D_UserTagName1).ToLower().Contains(searchWord) ||
                        fXmlNode.get_attrVal(FXmlTagUTN.A_UserTagName2, FXmlTagUTN.D_UserTagName2).ToLower().Contains(searchWord) ||
                        fXmlNode.get_attrVal(FXmlTagUTN.A_UserTagName3, FXmlTagUTN.D_UserTagName3).ToLower().Contains(searchWord) ||
                        fXmlNode.get_attrVal(FXmlTagUTN.A_UserTagName4, FXmlTagUTN.D_UserTagName4).ToLower().Contains(searchWord) ||
                        fXmlNode.get_attrVal(FXmlTagUTN.A_UserTagName5, FXmlTagUTN.D_UserTagName5).ToLower().Contains(searchWord)
                        )
                    {
                        return true;
                    }
                }
                else if (fXmlNode.name == FXmlTagDCV.E_DataConversion)
                {
                    encodingValue = FValueConverter.toTransformedEncodingValue(
                        FEnumConverter.toFormat(fXmlNode.get_attrVal(FXmlTagDCV.A_OperandFormat, FXmlTagDCV.D_OperandFormat)),
                        fXmlNode.get_attrVal(FXmlTagDCV.A_Value, FXmlTagDCV.D_Value),
                        fXmlNode.get_attrVal(FXmlTagDCV.A_Transformer, FXmlTagDCV.D_Transformer)
                        );
                    if (encodingValue.ToLower().Contains(searchWord))
                    {
                        return true;
                    }

                    if (fXmlNode.get_attrVal(FXmlTagDCV.A_ConversionValue, FXmlTagDCV.D_ConversionValue).ToLower().Contains(searchWord))
                    {
                        return true;
                    }
                }
                else if (fXmlNode.name == FXmlTagCOL.E_Column)
                {
                    encodingValue = FValueConverter.toDataConversionedEncodingValue(
                        FEnumConverter.toFormat(fXmlNode.get_attrVal(FXmlTagCOL.A_Format, FXmlTagCOL.D_Format)),
                        fXmlNode.get_attrVal(FXmlTagCOL.A_Value, FXmlTagCOL.D_Value),
                        fXmlNode.get_attrVal(FXmlTagCOL.A_Transformer, FXmlTagCOL.D_Transformer),
                        fXmlNode.get_attrVal(FXmlTagCOL.A_DataConversionSetExpression, FXmlTagCOL.D_DataConversionSetExpression)
                        );
                    if (encodingValue.ToLower().Contains(searchWord))
                    {
                        return true;
                    }
                }
                else if (fXmlNode.name == FXmlTagENV.E_Environment)
                {
                    encodingValue = FValueConverter.toEncodingValue(
                        FEnumConverter.toFormat(fXmlNode.get_attrVal(FXmlTagENV.A_Format, FXmlTagENV.D_Format)),
                        fXmlNode.get_attrVal(FXmlTagENV.A_Value, FXmlTagENV.D_Value)
                        );
                    if (encodingValue.ToLower().Contains(searchWord))
                    {
                        return true;
                    }
                }
                else if (fXmlNode.name == FXmlTagDAT.E_Data)
                {
                    encodingValue = FValueConverter.toDataConversionedEncodingValue(
                        FEnumConverter.toFormat(fXmlNode.get_attrVal(FXmlTagDAT.A_Format, FXmlTagDAT.D_Format)),
                        fXmlNode.get_attrVal(FXmlTagDAT.A_Value, FXmlTagDAT.D_Value),
                        fXmlNode.get_attrVal(FXmlTagDAT.A_Transformer, FXmlTagDAT.D_Transformer),
                        fXmlNode.get_attrVal(FXmlTagDAT.A_DataConversionSetExpression, FXmlTagDAT.D_DataConversionSetExpression)
                        );
                    if (encodingValue.ToLower().Contains(searchWord))
                    {
                        return true;
                    }
                }

                // --

                if (
                    fXmlNode.get_attrVal(FXmlTagCommon.A_Name, FXmlTagCommon.D_Name).ToLower().Contains(searchWord) ||
                    fXmlNode.get_attrVal(FXmlTagCommon.A_Description, FXmlTagCommon.D_Description).ToLower().Contains(searchWord)
                    )
                {
                    return true;
                }
                // --
                return false;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return false;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namesapce end
