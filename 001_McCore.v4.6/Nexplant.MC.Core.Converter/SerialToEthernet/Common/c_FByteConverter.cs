/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FByteConverter.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.23
--  Description     : FAmate Converter FaSerialToEthernet Byte Converter Class
--  History         : Created by spike.lee at 2019.09.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Text;
using Nexplant.MC.Core.FaCommon;
using System.Collections.Generic;

namespace Nexplant.MC.Core.FaSerialToEthernet
{
    public static class FByteConverter
    {

        //------------------------------------------------------------------------------------------------------------------------       

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------       

        #region Methods

        public static byte[] getBytes(
            UInt16 value,
            bool isReverse
            )
        {
            byte[] buf = null;

            try
            {
                buf = BitConverter.GetBytes(value);                
                if (isReverse)
                {
                    Array.Reverse(buf);
                }
                return buf;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                buf = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------       

        public static byte[] getBytes(
            UInt32 value,
            bool isReverse
            )
        {
            byte[] buf = null;

            try
            {
                buf = BitConverter.GetBytes(value);
                if (isReverse)
                {
                    Array.Reverse(buf);
                }
                return buf;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                buf = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------       

        public static byte[] getBytes(
            string byteValue
            )
        {
            List<byte> buf = null;

            try
            {
                buf = new List<byte>();
                if(byteValue== string.Empty)
                {
                    return null;
                }
                // --
                foreach (string s in byteValue.Split(' '))
                {
                    buf.Add(Convert.ToByte(s, 16));
                }
                return buf.ToArray();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                buf = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string toString(
            byte[] data
            )
        {
            StringBuilder val = null;

            try
            {
                val = new StringBuilder();
                if (data == null)
                {
                    return string.Empty;
                }

                // --

                for (int i = 0; i < data.Length; i++)
                {
                    val.Append(" ");
                    val.Append(data[i].ToString("X2"));
                }
                // --
                if (val.Length > 0)
                {
                    val.Remove(0, 1);
                }

                // --

                return val.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                val = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string toString(
            byte byteValue
            )
        {
            string s = string.Empty;

            try
            {
                if (byteValue == FAsciiByte.LF)
                {
                    s = "{LF}";
                }
                else if (byteValue == FAsciiByte.CR)
                {
                    s = "{CR}";
                }
                else if (byteValue == FAsciiByte.SP)
                {
                    s = "{SP}";
                }
                else
                {
                    s = Encoding.Default.GetString(new byte[] { byteValue });
                }

                return s;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------       

    }   // Class end
}   // Namespace end
