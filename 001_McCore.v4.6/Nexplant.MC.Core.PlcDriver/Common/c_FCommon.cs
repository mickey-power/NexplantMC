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

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal static class FCommon
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static string toValue(
            FFormat fFormat,
            string value
            )
        {
            try
            {
                if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                {
                    return FValueConverter.toEncodingValue(fFormat, value);
                }
                else
                {
                    return value;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static bool contains(
            string nodeName,
            string searchWord
            )
        {
            try
            {
                nodeName = nodeName.ToLower();
                searchWord = searchWord.ToLower();

                return nodeName.Contains(searchWord);
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

        //------------------------------------------------------------------------------------------------------------------------

        public static bool contains(
            FXmlNode fXmlNode,
            string searchWord
            )
        {
            string encodingValue = string.Empty;

            try
            {
                if (fXmlNode.name == FXmlTagPWDL.E_PlcWord)
                {
                    encodingValue = toValue(
                        FEnumConverter.toFormat(fXmlNode.get_attrVal(FXmlTagPWDL.A_Format, FXmlTagPWDL.D_Format)),
                        fXmlNode.get_attrVal(FXmlTagPWDL.A_Value, FXmlTagPWDL.D_Value)
                        );
                    if (
                        contains(fXmlNode.get_attrVal(FXmlTagPWDL.A_Name, FXmlTagPWDL.D_Name), searchWord) ||
                        contains(encodingValue, searchWord)
                        )
                    {
                        return true;
                    }
                }
                else if (fXmlNode.name == FXmlTagHITL.E_HostItem)
                {
                    encodingValue = toValue(
                        FEnumConverter.toFormat(fXmlNode.get_attrVal(FXmlTagHITL.A_Format, FXmlTagHITL.D_Format)),
                        fXmlNode.get_attrVal(FXmlTagHITL.A_Value, FXmlTagHITL.D_Value)
                        );
                    if (
                        contains(fXmlNode.get_attrVal(FXmlTagHITL.A_Name, FXmlTagHITL.D_Name), searchWord) ||
                        contains(encodingValue, searchWord)
                        )
                    {
                        return true;
                    }
                }
                else if (fXmlNode.name == FXmlTagCOLL.E_Column)
                {
                    encodingValue = toValue(
                        FEnumConverter.toFormat(fXmlNode.get_attrVal(FXmlTagCOLL.A_Format, FXmlTagCOLL.D_Format)),
                        fXmlNode.get_attrVal(FXmlTagCOLL.A_Value, FXmlTagCOLL.D_Value)
                        );
                    if (
                        contains(fXmlNode.get_attrVal(FXmlTagCOLL.A_Name, FXmlTagCOLL.D_Name), searchWord) ||
                        contains(encodingValue, searchWord)
                        )
                    {
                        return true;
                    }
                }
                else
                {
                    if (contains(fXmlNode.get_attrVal(FXmlTagCommon.A_Name, FXmlTagCommon.D_Name), searchWord))
                    {
                        return true;
                    }
                }
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

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode getNextNode(
            FXmlNode fXmlNode,
            FXmlNode fXmlNodeRoot
            )
        {
            FXmlNode fXmlNodeNext = null;

            try
            {
                fXmlNodeNext = fXmlNode.fNextSibling;
                while (fXmlNodeNext == null)
                {
                    fXmlNodeNext = fXmlNode.fParentNode == null ? fXmlNodeRoot : getNextNode(fXmlNode.fParentNode, fXmlNodeRoot);
                }

                // --

                return fXmlNodeNext;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return null;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namesapce end
