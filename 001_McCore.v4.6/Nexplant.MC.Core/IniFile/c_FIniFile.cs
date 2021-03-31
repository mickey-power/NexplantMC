/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FIniFile.cs
--  Creator         : spike.lee
--  Create Date     : 2017.06.19
--  Description     : FAmate Core FaCommon Ini File Read/Write Class
--  History         : Created by spike.lee at 2017.06.19
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public static class FIniFile
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        static FIniFile(
            )
        {

        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static string readIniFile(
            string section,
            string key,
            string iniFileName
            )
        {
            int ret = 0;
            StringBuilder value = null;

            try
            {
                value = new StringBuilder(65535);
                ret = FNativeAPIs.GetPrivateProfileString(section, key, string.Empty, value, 65535, iniFileName);
                return value.ToString();
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

        public static string readIniFile(
            string section,
            string key,
            string iniFileName,
            string defaultValue
            )
        {
            string value = string.Empty;

            try
            {
                value = readIniFile(section, key, iniFileName);
                if (value == string.Empty)
                {
                    return defaultValue;
                }
                return value;
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

        public static void writeIniFile(
            string section,
            string key,
            string value,
            string iniFileName
            )
        {
            try
            {
                FNativeAPIs.WritePrivateProfileString(section, key, value, iniFileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end    
}   // Namespace end
