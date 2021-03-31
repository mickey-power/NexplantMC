/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FByteConverter.cs
--  Creator         : spike.lee
--  Create Date     : 2013.10.28
--  Description     : FAMate Core FaPlcDriver Byte Converter Class 
--  History         : Created by spike.lee at 2013.10.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal static class FByteConverter
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
            UInt64 value,
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
            char value,
            bool isReverse
            )
        {
            byte[] buf = null;

            try
            {
                //Encoding.Default.GetBytes(

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
            bool value,
            bool isReverse
            )
        {
            byte[] buf = null;

            try
            {
                buf = new byte[1];
                if(!value)
                {
                    buf[0] = 0x00;
                }
                else
                {
                    buf[0] = 0x01;
                }
                
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
            Int64 value,
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
            Int32 value,
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
            Int16 value,
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
            double value,
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
            Single value,
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

        public static UInt16 toUInt16(
            byte[] bytes,
            bool isReverse
            )
        {
            try
            {
                if (isReverse)
                {
                    Array.Reverse(bytes);
                }
                return BitConverter.ToUInt16(bytes, 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------       

        public static UInt32 toUInt32(
            byte[] bytes,
            bool isReverse
            )
        {
            try
            {
                if (isReverse)
                {
                    Array.Reverse(bytes);
                }
                return BitConverter.ToUInt32(bytes, 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------       

        public static UInt64 toUInt64(
            byte[] bytes,
            bool isReverse
            )
        {
            try
            {
                if (isReverse)
                {
                    Array.Reverse(bytes);
                }
                return BitConverter.ToUInt64(bytes, 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return 0;
        }        

        //------------------------------------------------------------------------------------------------------------------------       

        public static Int16 toInt16(
            byte[] bytes,
            bool isReverse
            )
        {
            try
            {
                if (isReverse)
                {
                    Array.Reverse(bytes);
                }
                return BitConverter.ToInt16(bytes, 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------       

        public static Int32 toInt32(
            byte[] bytes,
            bool isReverse
            )
        {
            try
            {
                if (isReverse)
                {
                    Array.Reverse(bytes);
                }
                return BitConverter.ToInt32(bytes, 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return 0;
        }
        
        //------------------------------------------------------------------------------------------------------------------------       
        
        public static Int64 toInt64(
            byte[] bytes,
            bool isReverse
            )
        {
            try
            {
                if (isReverse)
                {
                    Array.Reverse(bytes);
                }
                return BitConverter.ToInt64(bytes, 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------       

        public static Single toFloat4(
            byte[] bytes,
            bool isReverse
            )
        {
            try
            {
                if (isReverse)
                {
                    Array.Reverse(bytes);
                }
                return BitConverter.ToSingle(bytes, 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------       

        public static Double toFloat8(
            byte[] bytes,
            bool isReverse
            )
        {
            try
            {
                if (isReverse)
                {
                    Array.Reverse(bytes);
                }
                return BitConverter.ToDouble(bytes, 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return 0;
        }


        //------------------------------------------------------------------------------------------------------------------------       

        public static string toBoolean(
            byte bytes            
            )
        {
            try
            {
                if (bytes == 0x00)
                {
                    return "F";
                }
                else
                {
                    return "T";
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return "F";
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------       

    }   // Class end
}   // Namespace end
