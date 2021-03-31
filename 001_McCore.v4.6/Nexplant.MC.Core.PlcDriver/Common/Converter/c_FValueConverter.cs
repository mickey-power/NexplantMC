/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FValueConverter.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.15
--  Description     : FAMate Core FaPlcDriver Value Converter Class 
--  History         : Created by Jeff.Kim at 2013.07.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal static class FValueConverter
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static string getDataTypeMin(
            Type type
            )
        {
            try
            {
                if (type.Equals(typeof(UInt64)))
                {
                    return UInt64.MinValue.ToString();
                }
                else if (type.Equals(typeof(UInt32)))
                {
                    return UInt32.MinValue.ToString();
                }
                else if (type.Equals(typeof(UInt16)))
                {
                    return UInt16.MinValue.ToString();
                }
                else if (type.Equals(typeof(Int64)))
                {
                    return Int64.MinValue.ToString();
                }
                else if (type.Equals(typeof(Int32)))
                {
                    return Int32.MinValue.ToString();
                }
                else if (type.Equals(typeof(Int16)))
                {
                    return Int16.MinValue.ToString();
                }
                else if (type.Equals(typeof(byte)))
                {
                    return byte.MinValue.ToString();
                }
                else if (type.Equals(typeof(SByte)))
                {
                    return SByte.MinValue.ToString();
                }
                else if (type.Equals(typeof(Double)))
                {
                    return Single.MinValue.ToString("r");
                }
                else if (type.Equals(typeof(Single)))
                {
                    return Single.MinValue.ToString("r");
                }
                return "0";
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

        public static string getDataTypeMax(
            Type type
            )
        {
            try
            {
                if (type.Equals(typeof(UInt64)))
                {
                    return UInt64.MaxValue.ToString();
                }
                else if (type.Equals(typeof(UInt32)))
                {
                    return UInt32.MaxValue.ToString();
                }
                else if (type.Equals(typeof(UInt16)))
                {
                    return UInt16.MaxValue.ToString();
                }
                else if (type.Equals(typeof(Int64)))
                {
                    return Int64.MaxValue.ToString();
                }
                else if (type.Equals(typeof(Int32)))
                {
                    return Int32.MaxValue.ToString();
                }
                else if (type.Equals(typeof(Int16)))
                {
                    return Int16.MaxValue.ToString();
                }
                else if (type.Equals(typeof(byte)))
                {
                    return byte.MaxValue.ToString();
                }
                else if (type.Equals(typeof(SByte)))
                {
                    return SByte.MaxValue.ToString();
                }
                else if (type.Equals(typeof(Double)))
                {
                    return Single.MaxValue.ToString("r");
                }
                else if (type.Equals(typeof(Single)))
                {
                    return Single.MaxValue.ToString("r");
                }
                return "0";
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

        public static UInt32 getFormatBytes(
            FFormat fFormat
            )
        {
            try
            {
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                {
                    return 1;
                }
                else if (fFormat == FFormat.Binary)
                {
                    return 1;
                }
                else if (fFormat == FFormat.Boolean)
                {
                    return 1;
                }
                else if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                {
                    return 1;
                }
                else if (fFormat == FFormat.I8)
                {
                    return 8;
                }
                else if (fFormat == FFormat.I4)
                {
                    return 4;
                }
                else if (fFormat == FFormat.I2)
                {
                    return 2;
                }
                else if (fFormat == FFormat.I1)
                {
                    return 1;
                }
                else if (fFormat == FFormat.F8)
                {
                    return 8;
                }
                else if (fFormat == FFormat.F4)
                {
                    return 4;
                }
                else if (fFormat == FFormat.U8)
                {
                    return 8;
                }
                else if (fFormat == FFormat.U4)
                {
                    return 4;
                }
                else if (fFormat == FFormat.U2)
                {
                    return 2;
                }
                else if (fFormat == FFormat.U1)
                {
                    return 1;
                }
                else if (fFormat == FFormat.Unknown)
                {
                    return 1;
                }
                else if (fFormat == FFormat.Raw)
                {
                    return 1;
                }
                return 0;
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

        public static FSecsLengthBytes getLengthBytes(
            int length
            )
        {
            try
            {
                if (length <= 0xFF)
                {
                    return FSecsLengthBytes.Byte1;
                }
                else if (length <= 0xFFFF)
                {
                    return FSecsLengthBytes.Byte2;
                }
                return FSecsLengthBytes.Byte3;
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

        public static Type getValueType(
            FFormat fFormat
            )
        {
            try
            {
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                {
                    return typeof(object);
                }
                else if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                {
                    return typeof(string);
                }
                else if (fFormat == FFormat.Binary)
                {
                    return typeof(byte);
                }
                else if (fFormat == FFormat.Boolean)
                {
                    return typeof(bool);
                }
                else if (fFormat == FFormat.U8)
                {
                    return typeof(UInt64);
                }
                else if (fFormat == FFormat.U4)
                {
                    return typeof(UInt32);
                }
                else if (fFormat == FFormat.U2)
                {
                    return typeof(UInt16);
                }
                else if (fFormat == FFormat.U1)
                {
                    return typeof(byte);
                }
                else if (fFormat == FFormat.F8)
                {
                    return typeof(double);
                }
                else if (fFormat == FFormat.F4)
                {
                    return typeof(float);
                }
                else if (fFormat == FFormat.I8)
                {
                    return typeof(Int64);
                }
                else if (fFormat == FFormat.I4)
                {
                    return typeof(Int32);
                }
                else if (fFormat == FFormat.I2)
                {
                    return typeof(Int16);
                }
                else if (fFormat == FFormat.I1)
                {
                    return typeof(sbyte);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return typeof(object);
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void validateLengthBytes(            
            FFormat fFormat, 
            FSecsLengthBytes lengthBytes,
            int length
            )
        {
            int byteCount = 0;

            try
            {
                // ***
                // 데이터의 길이가 정의한 LengthBytes의 범위를 초과하는지 검사한다.
                // ***
                byteCount = length * (int)getFormatBytes(fFormat);
                if (lengthBytes == FSecsLengthBytes.Byte1)
                {
                    if (byteCount > 0xFF)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0014, "LengthBytes"));
                    }
                }
                else if (lengthBytes == FSecsLengthBytes.Byte2)
                {
                    if (byteCount > 0xFFFF)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0014, "LengthBytes"));
                    }
                }
                else
                {
                    if (byteCount > 0xFFFFFF)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0014, "LengthBytes"));
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromStringValue(
            FFormat fFormat,
            FSecsLengthBytes lengthBytes,
            string value,
            out int length
            )
        {
            StringBuilder val = null;            

            try
            {
                length = 0;
                if (value == string.Empty)
                {
                    return string.Empty;
                }

                // --

                val = new StringBuilder();

                // --

                if (fFormat == FFormat.Binary)
                {
                    // ***
                    // Hex 형식의 Byte 처리
                    // ***
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToByte(s, 16).ToString("X2"));                        
                        length++;                        
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.Boolean)
                {
                    // ***
                    // Boolean는 0 or F or f or FALSE or False or false를 False로 처리한다.
                    // 값은 True를 T로 False를 F로 표기한다.
                    // ***
                    value = value.ToLower();
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        if (s == "0" || s == "f" || s == "false")
                        {
                            val.Append(FBoolean.False);
                        }
                        else
                        {
                            val.Append(FBoolean.True);
                        }
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.Ascii || fFormat == FFormat.A2)
                {
                    int cur = 0;
                    int len = 0;
                    int pos1 = 0;
                    int pos2 = 0;                    
                    byte[] bytes = null;
                    byte hByte = 0;

                    while (cur < value.Length)
                    {
                        // ***
                        // Hex 문자 시작점 검색
                        // ***
                        pos1 = value.IndexOf('{', cur);
                        pos2 = value.IndexOf('}', cur);
                        if (pos1 > pos2)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                        }

                        if (pos1 == -1)
                        {
                            // ***
                            // Hex 문자의 시작점 없이 종료점이 있을 경우 오류 처리
                            // ***                            
                            if (pos2 != -1)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                            }

                            // ***
                            // Hex 문자가 없을 경우 cur 위치 부터 끝까지 복사
                            // ***
                            len = value.Length - cur;
                            bytes = Encoding.Default.GetBytes(value.Substring(cur, len));                            
                            foreach (byte b in bytes)
                            {
                                // ***
                                // Ascii 문자 중에 Multi-Bytes 문자나 기능 문자일 경우 Hex 문자 형식으로 변환
                                // ***    
                                if (b <= 0x1F || b >= 0x7F)
                                {
                                    val.Append("{" + b.ToString("X2") + "}");
                                }
                                else
                                {
                                    val.Append((char)b);
                                }
                            }
                            // --
                            cur += len;
                            length += bytes.Length;
                        }
                        else
                        {
                            // ***
                            // cur 위치부터 Hex 문자 시작 이전 위치까지의 복사
                            // ***
                            len = pos1 - cur;
                            if (len > 0)
                            {
                                bytes = Encoding.Default.GetBytes(value.Substring(cur, len));
                                foreach (byte b in bytes)
                                {
                                    // ***
                                    // Ascii 문자 중에 Multi-Bytes 문자나 기능 문자일 경우 Hex 문자 형식으로 변환
                                    // ***    
                                    if (b <= 0x1F || b >= 0x7F)
                                    {
                                        val.Append("{" + b.ToString("X2") + "}");
                                    }
                                    else
                                    {
                                        val.Append((char)b);
                                    }
                                }
                                // --
                                length += bytes.Length;
                            }

                            // --

                            // ***
                            // Hex 문자 복사 (Hex 문자가 Ascii로 표현이 가능할 경우 Ascii 문자로 변환한다.)
                            // ***
                            len = pos2 - pos1 - 1;
                            if (len <= 0)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                            }
                            hByte = Convert.ToByte(value.Substring(pos1 + 1, len), 16);

                            // ***
                            // '{'=0x7B, '}'=0x7D
                            // ***
                            if (hByte <= 0x1F || hByte >= 0x7F || hByte == 0x7B || hByte == 0x7D)
                            {
                                val.Append("{" + hByte.ToString("X2") + "}");
                            }
                            else
                            {
                                val.Append((char)hByte);
                            }
                            // --
                            cur = pos2 + 1;
                            length++;
                        }
                    }
                }                                
                else if (fFormat == FFormat.I8)
                {
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToInt64(s).ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.I4)
                {
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToInt32(s).ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.I2)
                {
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToInt16(s).ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.I1)
                {
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToSByte(s).ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.F8)
                {
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToDouble(s).ToString("R"));
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.F4)
                {
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToSingle(s).ToString("R"));
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.U8)
                {
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToUInt64(s).ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.U4)
                {
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToUInt32(s).ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.U2)
                {
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToUInt16(s).ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.U1)
                {
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToByte(s).ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.JIS8)
                {
                    int cur = 0;
                    int len = 0;
                    int pos1 = 0;
                    int pos2 = 0;
                    byte[] bytes = null;
                    byte hByte = 0;

                    while (cur < value.Length)
                    {
                        // ***
                        // Hex 문자 시작점 검색
                        // ***
                        pos1 = value.IndexOf('{', cur);
                        pos2 = value.IndexOf('}', cur);
                        if (pos1 > pos2)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                        }

                        if (pos1 == -1)
                        {
                            // ***
                            // Hex 문자의 시작점 없이 종료점이 있을 경우 오류 처리
                            // ***                            
                            if (pos2 != -1)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                            }

                            // ***
                            // Hex 문자가 없을 경우 cur 위치 부터 끝까지 복사
                            // ***                            

                            len = value.Length - cur;
                            bytes = Encoding.Default.GetBytes(value.Substring(cur, len));
                            foreach (byte b in bytes)
                            {
                                // ***
                                // Ascii 문자 중에 Multi-Bytes 문자나 기능 문자일 경우 Hex 문자 형식으로 변환
                                // ***    
                                if (b <= 0x1F || b >= 0x7F)
                                {
                                    val.Append("{" + b.ToString("X2") + "}");
                                }                                
                                else
                                {
                                    val.Append((char)b);
                                }
                            }
                            // --
                            cur += len;
                            length += bytes.Length;
                        }
                        else
                        {
                            // ***
                            // cur 위치부터 Hex 문자 시작 이전 위치까지의 복사
                            // ***
                            len = pos1 - cur;
                            if (len > 0)
                            {
                                bytes = Encoding.Default.GetBytes(value.Substring(cur, len));
                                foreach (byte b in bytes)
                                {
                                    // ***
                                    // Ascii 문자 중에 Multi-Bytes 문자나 기능 문자일 경우 Hex 문자 형식으로 변환
                                    // ***    
                                    if (b <= 0x1F || b >= 0x7F)
                                    {
                                        val.Append("{" + b.ToString("X2") + "}");
                                    }
                                    else
                                    {
                                        val.Append((char)b);
                                    }
                                }
                                // --
                                length += bytes.Length;
                            }

                            // --

                            // ***
                            // Hex 문자 복사 (Hex 문자가 Ascii로 표현이 가능할 경우 Ascii 문자로 변환한다.)
                            // ***
                            len = pos2 - pos1 - 1;
                            if (len <= 0)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                            }
                            hByte = Convert.ToByte(value.Substring(pos1 + 1, len), 16);

                            // ***
                            // '{'=0x7B, '}'=0x7D
                            // ***
                            if (hByte <= 0x1F || hByte >= 0x7F || hByte == 0x7B || hByte == 0x7D)
                            {
                                val.Append("{" + hByte.ToString("X2") + "}");
                            }
                            else
                            {
                                val.Append((char)hByte);
                            }
                            // --
                            cur = pos2 + 1;
                            length++;
                        }
                    }
                } 
                
                // --

                // ***
                // LengthBytes Validate
                // ***
                validateLengthBytes(fFormat, lengthBytes, length);

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
            length = 0;
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromStringValue(
            FFormat fFormat,
            string value,
            out int length
            )
        {
            try
            {
                return fromStringValue(fFormat, FSecsLengthBytes.Auto, value, out length);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            length = 0;
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromStringValue(
            FFormat fFormat, 
            string value
            )
        {
            int length = 0;

            try
            {
                return fromStringValue(fFormat, FSecsLengthBytes.Auto, value, out length);
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

        public static string toEncodingValue(       
            FFormat fFormat,
            string value 
            )
        {
            try
            {
                if (value == string.Empty)
                {
                    return string.Empty;
                }                

                // --

                if (fFormat == FFormat.Binary)
                {
                    // ***
                    // 2014.04.21 by spike.lee
                    // 대용량 Binary 데이터 처리 시, UI Performance 문제로 Encoding 값을 Hex 표현식 그대로 사용하도록 수정
                    // ***
                    return value;

                    /*
                    StringBuilder val = new StringBuilder();

                    foreach (string s in value.Split(' '))
                    {
                        val.Append(' ');
                        val.Append(Convert.ToByte(s, 16).ToString());
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                    return val.ToString();
                    */
                }
                else if (fFormat == FFormat.Ascii || fFormat == FFormat.A2)
                {
                    int cur = 0;
                    int len = 0;
                    int pos1 = 0;
                    int pos2 = 0;
                    List<byte> bytes = new List<byte>();

                    while (cur < value.Length)
                    {
                        // ***
                        // Hex 문자 시작점 검색
                        // ***
                        pos1 = value.IndexOf('{', cur);

                        if (pos1 == -1)
                        {
                            // ***
                            // Hex 문자의 시작점 없이 종료점이 있을 경우 오류 처리
                            // ***
                            pos2 = value.IndexOf('}', cur);
                            if (pos2 != -1)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                            }

                            // --

                            len = value.Length - cur;
                            bytes.AddRange(Encoding.Default.GetBytes(value.Substring(cur, len)));
                            cur += len;
                        }
                        else
                        {
                            // ***
                            // Hex 문자의 종료점이 없을 경우 오류 처리
                            // ***
                            pos2 = value.IndexOf('}', cur);
                            if (pos2 == -1)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                            }

                            // --

                            len = pos1 - cur;
                            if (len > 0)
                            {
                                bytes.AddRange(Encoding.Default.GetBytes(value.Substring(cur, len)));
                            }

                            // --

                            len = pos2 - pos1 - 1;
                            bytes.Add(Convert.ToByte(value.Substring(pos1 + 1, len), 16));
                            cur = pos2 + 1;
                        }
                    }
                    return Encoding.Default.GetString(bytes.ToArray());
                }
                else if (fFormat == FFormat.JIS8)
                {
                    int cur = 0;
                    int len = 0;
                    int pos1 = 0;
                    int pos2 = 0;
                    List<byte> bytes = new List<byte>();

                    while (cur < value.Length)
                    {
                        // ***
                        // Hex 문자 시작점 검색
                        // ***
                        pos1 = value.IndexOf('{', cur);

                        if (pos1 == -1)
                        {
                            // ***
                            // Hex 문자의 시작점 없이 종료점이 있을 경우 오류 처리
                            // ***     
                            
                            pos2 = value.IndexOf('}', cur);
                            if (pos2 != -1)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                            }

                            // --

                            len = value.Length - cur;
                            bytes.AddRange(Encoding.Default.GetBytes(value.Substring(cur, len)));
                            cur += len;
                        }
                        else
                        {
                            // ***
                            // Hex 문자의 종료점이 없을 경우 오류 처리
                            // ***
                            pos2 = value.IndexOf('}', cur);
                            if (pos2 == -1)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                            }

                            // --

                            len = pos1 - cur;
                            if (len > 0)
                            {
                                bytes.AddRange(Encoding.Default.GetBytes(value.Substring(cur, len)));
                            }

                            // --

                            len = pos2 - pos1 - 1;
                            bytes.Add(Convert.ToByte(value.Substring(pos1 + 1, len), 16));
                            cur = pos2 + 1;
                        }
                    }

                    return (Encoding.Default.GetString(bytes.ToArray()).Replace((char)0x5C, '¥')).Replace((char)0x7, '‾');
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

        public static string fromStringArrayValue(
            FFormat fFormat,
            FSecsLengthBytes lengthBytes,
            string[] value,
            out int length
            )
        {
            StringBuilder val = null;

            try
            {
                length = 0;
                if (value == null || value.Length == 0)
                {
                    return string.Empty;
                }

                // --

                val = new StringBuilder();

                // --

                if (fFormat == FFormat.Binary)
                {
                    foreach (string s in value)
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToByte(s, 16).ToString("X2"));
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.Boolean)
                {
                    string v = string.Empty;
                    
                    // ***
                    // Boolean는 0 or F or f or FALSE or False or false를 False로 처리한다.
                    // 값은 True를 T로 False를 F로 표기한다.
                    // ***                    
                    foreach (string s in value)
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        v = s.ToLower();
                        if (v == "0" || v == "f" || v == "false")
                        {
                            val.Append(FBoolean.False);
                        }
                        else
                        {
                            val.Append(FBoolean.True);
                        }
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                {
                    int len = 0;

                    foreach (string s in value)
                    {
                        val.Append(fromStringValue(fFormat, lengthBytes, s, out len));
                        length += len;
                    }
                }
                else if (fFormat == FFormat.I8)
                {
                    foreach (string s in value)
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToInt64(s).ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.I4)
                {
                    foreach (string s in value)
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToInt32(s).ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.I2)
                {
                    foreach (string s in value)
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToInt16(s).ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.I1)
                {
                    foreach (string s in value)
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToSByte(s).ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.F8)
                {
                    foreach (string s in value)
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToDouble(s).ToString("R"));
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.F4)
                {
                    foreach (string s in value)
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToSingle(s).ToString("R"));
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.U8)
                {
                    foreach (string s in value)
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToUInt64(s).ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.U4)
                {
                    foreach (string s in value)
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToUInt32(s).ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.U2)
                {
                    foreach (string s in value)
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToUInt16(s).ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.U1)
                {
                    foreach (string s in value)
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        val.Append(Convert.ToByte(s).ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }

                // --

                // ***
                // LengthBytes Validate
                // ***
                validateLengthBytes(fFormat, lengthBytes, length);

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
            length = 0;
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromStringArrayValue(
            FFormat fFormat,
            string[] value,
            out int length
            )
        {
            try
            {
                return fromStringArrayValue(fFormat, FSecsLengthBytes.Auto, value, out length);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            length = 0;
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromStringArrayValue(
            FFormat fFormat, 
            string[] value
            )
        {
            int length = 0;

            try
            {
                return fromStringArrayValue(fFormat, FSecsLengthBytes.Auto, value, out length);
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

        public static string[] toStringArrayValue(
            FFormat fFormat,
            string value
            )
        {
            List<string> val = null;

            try
            {
                if (value == string.Empty)
                {
                    return null;
                }

                // --

                val = new List<string>();

                // --

                if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                {
                    val.Add(value);
                }
                else
                {
                    foreach (string s in value.Split(' '))
                    {
                        val.Add(s);
                    }
                }

                // --

                return val.ToArray();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                val = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static object toValue(
            FFormat fFormat,            
            string value,
            int length
            )
        {
            object val = null;

            try
            {
                if (value == string.Empty)
                {
                    return null;
                }

                // --

                if (fFormat == FFormat.Binary)
                {
                    List<byte> arrVal = new List<byte>();

                    if (length > 1)
                    {
                        foreach (string s in value.Split(' '))
                        {
                            arrVal.Add(Convert.ToByte(s, 16));
                        }
                        val = arrVal.ToArray();
                    }
                    else
                    {
                        val = Convert.ToByte(value, 16);
                    }
                }
                else if (fFormat == FFormat.Boolean)
                {
                    List<bool> arrVal = new List<bool>();

                    if (length > 1)
                    {
                        foreach (string s in value.Split(' '))
                        {
                            arrVal.Add(s == FBoolean.True ? true : false);
                        }
                        val = arrVal.ToArray();
                    }
                    else
                    {
                        val = (value == FBoolean.True ? true : false);
                    }
                }
                else if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                {
                    val = toEncodingValue(fFormat, value);
                }
                else if (fFormat == FFormat.I8)
                {
                    List<Int64> arrVal = new List<Int64>();

                    if (length > 1)
                    {
                        foreach (string s in value.Split(' '))
                        {
                            arrVal.Add(Convert.ToInt64(s));
                        }
                        val = arrVal.ToArray();
                    }
                    else
                    {
                        val = Convert.ToInt64(value);
                    }
                }
                else if (fFormat == FFormat.I4)
                {
                    List<Int32> arrVal = new List<Int32>();

                    if (length > 1)
                    {
                        foreach (string s in value.Split(' '))
                        {
                            arrVal.Add(Convert.ToInt32(s));
                        }
                        val = arrVal.ToArray();
                    }
                    else
                    {
                        val = Convert.ToInt32(value);
                    }
                }
                else if (fFormat == FFormat.I2)
                {
                    List<Int16> arrVal = new List<Int16>();

                    if (length > 1)
                    {
                        foreach (string s in value.Split(' '))
                        {
                            arrVal.Add(Convert.ToInt16(s));
                        }
                        val = arrVal.ToArray();
                    }
                    else
                    {
                        val = Convert.ToInt16(value);
                    }
                }
                else if (fFormat == FFormat.I1)
                {
                    List<sbyte> arrVal = new List<sbyte>();

                    if (length > 1)
                    {
                        foreach (string s in value.Split(' '))
                        {
                            arrVal.Add(Convert.ToSByte(s));
                        }
                        val = arrVal.ToArray();
                    }
                    else
                    {
                        val = Convert.ToSByte(value);
                    }
                }
                else if (fFormat == FFormat.F8)
                {
                    List<Double> arrVal = new List<Double>();

                    if (length > 1)
                    {
                        foreach (string s in value.Split(' '))
                        {
                            arrVal.Add(Convert.ToDouble(s));
                        }
                        val = arrVal.ToArray();
                    }
                    else
                    {
                        val = Convert.ToDouble(value);
                    }
                }
                else if (fFormat == FFormat.F4)
                {
                    List<Single> arrVal = new List<Single>();

                    if (length > 1)
                    {
                        foreach (string s in value.Split(' '))
                        {
                            arrVal.Add(Convert.ToSingle(s));
                        }
                        val = arrVal.ToArray();
                    }
                    else
                    {
                        val = Convert.ToSingle(value);
                    }
                }
                else if (fFormat == FFormat.U8)
                {
                    List<UInt64> arrVal = new List<UInt64>();

                    if (length > 1)
                    {
                        foreach (string s in value.Split(' '))
                        {
                            arrVal.Add(Convert.ToUInt64(s));
                        }
                        val = arrVal.ToArray();
                    }
                    else
                    {
                        val = Convert.ToUInt64(value);
                    }
                }
                else if (fFormat == FFormat.U4)
                {
                    List<UInt32> arrVal = new List<UInt32>();

                    if (length > 1)
                    {
                        foreach (string s in value.Split(' '))
                        {
                            arrVal.Add(Convert.ToUInt32(s));
                        }
                        val = arrVal.ToArray();
                    }
                    else
                    {
                        val = Convert.ToUInt32(value);
                    }
                }
                else if (fFormat == FFormat.U2)
                {
                    List<UInt16> arrVal = new List<UInt16>();

                    if (length > 1)
                    {
                        foreach (string s in value.Split(' '))
                        {
                            arrVal.Add(Convert.ToUInt16(s));
                        }
                        val = arrVal.ToArray();
                    }
                    else
                    {
                        val = Convert.ToUInt16(value);
                    }
                }
                else if (fFormat == FFormat.U1)
                {
                    List<byte> arrVal = new List<byte>();

                    if (length > 1)
                    {
                        foreach (string s in value.Split(' '))
                        {
                            arrVal.Add(Convert.ToByte(s));
                        }
                        val = arrVal.ToArray();
                    }
                    else
                    {
                        val = Convert.ToByte(value);
                    }
                }

                return val;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                val = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static object toValue(
            FFormat fFormat, 
            string value
            )
        {
            try
            {
                return toValue(fFormat, value, 1);
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

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromValue(            
            FFormat fFormat,
            FSecsLengthBytes lengthBytes,
            object value,
            out int length
            )
        {
            StringBuilder val = null;

            try
            {
                length = 0;
                if (value == null)
                {
                    return string.Empty;
                }
                // --
                if (value is string && (string)value == string.Empty)
                {
                    return string.Empty;
                }

                // --

                val = new StringBuilder();

                // --                

                if (fFormat == FFormat.Binary)
                {
                    if (value.GetType().IsArray)
                    {
                        foreach (object o in (Array)value)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToByte(o).ToString("X2"));
                        }
                        // --
                        if (val.Length > 0)
                        {
                            val.Remove(0, 1);
                        }
                        length = ((Array)value).Length;
                    }
                    else
                    {
                        val.Append(Convert.ToByte(value).ToString("X2"));
                        length = 1;
                    }
                }
                else if (fFormat == FFormat.Boolean)
                {
                    if (value.GetType().IsArray)
                    {
                        foreach (object o in (Array)value)
                        {
                            val.Append(' ');
                            // --
                            bool boolTemp = false;
                            if (Boolean.TryParse(o.ToString(), out boolTemp))
                            {
                                val.Append(boolTemp ? FBoolean.True : FBoolean.False);
                            }
                            else
                            {
                                val.Append(o.ToString().ToUpper());
                            }
                        }
                        // --
                        if (val.Length > 0)
                        {
                            val.Remove(0, 1);
                        }
                        length = ((Array)value).Length;
                    }
                    else
                    {
                        // --
                        bool boolTemp = false;
                        if (Boolean.TryParse(value.ToString(), out boolTemp))
                        {
                            val.Append(boolTemp ? FBoolean.True : FBoolean.False);
                        }
                        else
                        {
                            val.Append(value.ToString().ToUpper());
                        }
                        // --
                        length = 1;
                    }
                }
                else if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                {
                    int len = 0;

                    if (value.GetType().IsArray)
                    {
                        foreach (object o in (Array)value)
                        {
                            val.Append(fromStringValue(fFormat, lengthBytes, Convert.ToString(o), out len));
                            length += len;
                        }
                    }
                    else
                    {
                        val.Append(fromStringValue(fFormat, lengthBytes, Convert.ToString(value), out length));
                    }
                }
                else if (fFormat == FFormat.I8)
                {
                    if (value.GetType().IsArray)
                    {
                        foreach (object o in (Array)value)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToInt64(o));
                        }
                        // --
                        if (val.Length > 0)
                        {
                            val.Remove(0, 1);
                        }
                        length = ((Array)value).Length;
                    }
                    else
                    {
                        val.Append(Convert.ToInt64(value));
                        length = 1;
                    }
                }
                else if (fFormat == FFormat.I4)
                {
                    if (value.GetType().IsArray)
                    {
                        foreach (object o in (Array)value)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToInt32(o));
                        }
                        // --
                        if (val.Length > 0)
                        {
                            val.Remove(0, 1);
                        }
                        length = ((Array)value).Length;
                    }
                    else
                    {
                        val.Append(Convert.ToInt32(value));
                        length = 1;
                    }
                }
                else if (fFormat == FFormat.I2)
                {
                    if (value.GetType().IsArray)
                    {
                        foreach (object o in (Array)value)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToInt16(o));
                        }
                        // --
                        if (val.Length > 0)
                        {
                            val.Remove(0, 1);
                        }
                        length = ((Array)value).Length;
                    }
                    else
                    {
                        val.Append(Convert.ToInt16(value));
                        length = 1;
                    }
                }
                else if (fFormat == FFormat.I1)
                {
                    if (value.GetType().IsArray)
                    {
                        foreach (object o in (Array)value)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToSByte(o));
                        }
                        // --
                        if (val.Length > 0)
                        {
                            val.Remove(0, 1);
                        }
                        length = ((Array)value).Length;
                    }
                    else
                    {
                        val.Append(Convert.ToSByte(value));
                        length = 1;
                    }
                }
                else if (fFormat == FFormat.F8)
                {
                    if (value.GetType().IsArray)
                    {
                        foreach (object o in (Array)value)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToDouble(o).ToString("R"));
                        }
                        // --
                        if (val.Length > 0)
                        {
                            val.Remove(0, 1);
                        }
                        length = ((Array)value).Length;
                    }
                    else
                    {
                        val.Append(Convert.ToDouble(value).ToString("R"));
                        length = 1;
                    }
                }
                else if (fFormat == FFormat.F4)
                {
                    if (value.GetType().IsArray)
                    {
                        foreach (object o in (Array)value)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToSingle(o).ToString("R"));
                        }
                        // --
                        if (val.Length > 0)
                        {
                            val.Remove(0, 1);
                        }
                        length = ((Array)value).Length;
                    }
                    else
                    {
                        val.Append(Convert.ToSingle(value).ToString("R"));
                        length = 1;
                    }
                }
                else if (fFormat == FFormat.U8)
                {
                    if (value.GetType().IsArray)
                    {
                        foreach (object o in (Array)value)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToUInt64(o));
                        }
                        // --
                        if (val.Length > 0)
                        {
                            val.Remove(0, 1);
                        }
                        length = ((Array)value).Length;
                    }
                    else
                    {
                        val.Append(Convert.ToUInt64(value));
                        length = 1;
                    }
                }
                else if (fFormat == FFormat.U4)
                {
                    if (value.GetType().IsArray)
                    {
                        foreach (object o in (Array)value)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToUInt32(o));
                        }
                        // --
                        if (val.Length > 0)
                        {
                            val.Remove(0, 1);
                        }
                        length = ((Array)value).Length;
                    }
                    else
                    {
                        val.Append(Convert.ToUInt32(value));
                        length = 1;
                    }
                }
                else if (fFormat == FFormat.U2)
                {
                    if (value.GetType().IsArray)
                    {
                        foreach (object o in (Array)value)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToUInt16(o));
                        }
                        // --
                        if (val.Length > 0)
                        {
                            val.Remove(0, 1);
                        }
                        length = ((Array)value).Length;
                    }
                    else
                    {
                        val.Append(Convert.ToUInt16(value));
                        length = 1;
                    }
                }
                else if (fFormat == FFormat.U1)
                {
                    if (value.GetType().IsArray)
                    {
                        foreach (object o in (Array)value)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToByte(o));
                        }
                        // --
                        if (val.Length > 0)
                        {
                            val.Remove(0, 1);
                        }
                        length = ((Array)value).Length;
                    }
                    else
                    {
                        val.Append(Convert.ToByte(value));
                        length = 1;
                    }
                }

                // --

                // ***
                // LengthBytes Validate
                // ***
                validateLengthBytes(fFormat, lengthBytes, length);

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
            length = 0;
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromValue(
            FFormat fFormat,
            object value,
            out int length
            )
        {
            try
            {
                return fromValue(fFormat, FSecsLengthBytes.Auto, value, out length);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            length = 0;
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromValue(
            FFormat fFormat, 
            object value
            )
        {
            int length = 0;

            try
            {
                return fromValue(fFormat, FSecsLengthBytes.Auto, value, out length);
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

        public static string toTransformedStringValue(
            FFormat fFormat,
            string value,
            string transformer,
            ref int length,
            ref FResultCode resultCode
            )
        {
            string[] valueFormulaList = null;
            FIValueFormula fValueFormula = null;
            string val = string.Empty;
            resultCode = FResultCode.Success;

            try
            {
                if (transformer == string.Empty)
                {
                    return value;
                }
                valueFormulaList = transformer.Split(FConstants.ValueFormulaSeparator);

                // --

                if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                {
                    #region FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2

                    val = FValueConverter.toEncodingValue(fFormat, value);

                    // --

                    foreach (string valueFormula in valueFormulaList)
                    {
                        fValueFormula = FValueFormulaBase.createValueFormula(valueFormula);

                        // --

                        if (fValueFormula.fType == FValueFormulaType.Choose || fValueFormula.fType == FValueFormulaType.ChooseIncluded)
                        {
                            string startString = string.Empty;
                            int startPosition = 0;
                            string endString = string.Empty;
                            int endPosition = 0;
                            int startIndex = -1;
                            int endIndex = -1;
                            int pos = 0;

                            // --

                            if (fValueFormula.fType == FValueFormulaType.Choose)
                            {
                                FChoose fChoose = (FChoose)fValueFormula;
                                startString = FValueConverter.toEncodingValue(fFormat, fChoose.startString);
                                startPosition = fChoose.startPosition;
                                endString = FValueConverter.toEncodingValue(fFormat, fChoose.endString);
                                endPosition = fChoose.endPosition;
                            }
                            else
                            {
                                FChooseIncluded fChooseIncluded = (FChooseIncluded)fValueFormula;
                                startString = FValueConverter.toEncodingValue(fFormat, fChooseIncluded.startString);
                                startPosition = fChooseIncluded.startPosition;
                                endString = FValueConverter.toEncodingValue(fFormat, fChooseIncluded.endString);
                                endPosition = fChooseIncluded.endPosition;
                            }

                            // --

                            // ***
                            // Start Index 검색
                            // ***
                            pos = 0;
                            for (int i = 0; i <= startPosition; i++)
                            {
                                if (pos >= val.Length)
                                {
                                    startIndex = -1;
                                    break;
                                }
                                // --
                                startIndex = val.IndexOf(startString, pos);
                                if (startIndex == -1)
                                {
                                    break;
                                }
                                // --
                                pos = startIndex + 1;
                            }
                            // --
                            if (startIndex == -1)
                            {
                                val = string.Empty;
                                continue;
                            }

                            // --

                            // ***
                            // End Index 검색
                            // ***
                            pos = startIndex + 1;
                            for (int i = 0; i <= endPosition; i++)
                            {
                                if (pos >= val.Length)
                                {
                                    endIndex = -1;
                                    break;
                                }
                                // --
                                endIndex = val.IndexOf(endString, pos);
                                if (endIndex == -1)
                                {
                                    break;
                                }
                                // --
                                pos = endIndex + 1;
                            }
                            // --
                            if (endIndex == -1)
                            {
                                val = string.Empty;
                                continue;
                            }

                            // --

                            startIndex = startIndex + startString.Length;
                            // --
                            if (fValueFormula.fType == FValueFormulaType.Choose)
                            {
                                val = val.Substring(startIndex, endIndex - startIndex);
                            }
                            else
                            {
                                val = startString + val.Substring(startIndex, endIndex - startIndex) + endString;
                            }
                        }
                        else if (fValueFormula.fType == FValueFormulaType.ChooseR || fValueFormula.fType == FValueFormulaType.ChooseIncludedR)
                        {
                            string startString = string.Empty;
                            int startPosition = 0;
                            string endString = string.Empty;
                            int endPosition = 0;
                            int startIndex = -1;
                            int endIndex = -1;
                            int pos = 0;

                            // --

                            if (fValueFormula.fType == FValueFormulaType.ChooseR)
                            {
                                FChooseR fChooseR = (FChooseR)fValueFormula;
                                startString = FValueConverter.toEncodingValue(fFormat, fChooseR.startString);
                                startPosition = fChooseR.startPosition;
                                endString = FValueConverter.toEncodingValue(fFormat, fChooseR.endString);
                                endPosition = fChooseR.endPosition;
                            }
                            else
                            {
                                FChooseIncludedR fChooseIncludedR = (FChooseIncludedR)fValueFormula;
                                startString = FValueConverter.toEncodingValue(fFormat, fChooseIncludedR.startString);
                                startPosition = fChooseIncludedR.startPosition;
                                endString = FValueConverter.toEncodingValue(fFormat, fChooseIncludedR.endString);
                                endPosition = fChooseIncludedR.endPosition;
                            }

                            // --

                            // ***
                            // Start Index 검색
                            // ***
                            pos = val.Length - 1;
                            for (int i = 0; i <= startPosition; i++)
                            {
                                if (pos < 0)
                                {
                                    startIndex = -1;
                                    break;
                                }
                                // --
                                startIndex = val.LastIndexOf(startString, pos);
                                if (startIndex == -1)
                                {
                                    break;
                                }
                                // --
                                pos = startIndex - 1;
                            }
                            // --
                            if (startIndex == -1)
                            {
                                val = string.Empty;
                                continue;
                            }

                            // --

                            // ***
                            // End Index 검색
                            // ***
                            pos = startIndex - 1;
                            for (int i = 0; i <= endPosition; i++)
                            {
                                if (pos < 0)
                                {
                                    endIndex = -1;
                                    break;
                                }
                                // --
                                endIndex = val.LastIndexOf(endString, pos);
                                if (endIndex == -1)
                                {
                                    break;
                                }
                                // --
                                pos = endIndex - 1;
                            }
                            // --
                            if (endIndex == -1)
                            {
                                val = string.Empty;
                                continue;
                            }

                            // --

                            endIndex = endIndex + endString.Length;
                            // --
                            if (fValueFormula.fType == FValueFormulaType.ChooseR)
                            {
                                val = val.Substring(endIndex, startIndex - endIndex);
                            }
                            else
                            {
                                val = endString + val.Substring(endIndex, startIndex - endIndex) + startString;
                            }
                        }
                        else if (fValueFormula.fType == FValueFormulaType.DateTime)
                        {
                            FDateTime fDateTime = (FDateTime)fValueFormula;

                            // --

                            val += FValueConverter.toEncodingValue(fFormat, DateTime.Now.ToString(fDateTime.format));
                        }
                        else if (fValueFormula.fType == FValueFormulaType.FixLength)
                        {
                            int fixStringLength = 0;
                            string fixString = string.Empty;

                            // --

                            FFixLength fFixLength = (FFixLength)fValueFormula;
                            fixStringLength = fFixLength.length;
                            fixString = FValueConverter.toEncodingValue(fFormat, fFixLength.fixString);

                            // --

                            List<byte> arrVal = new List<byte>(Encoding.Default.GetBytes(val));
                            List<byte> arrFixString = new List<byte>(Encoding.Default.GetBytes(fixString));
                            int valCount = arrVal.Count;
                            int rest = 0;

                            // --

                            if (valCount >= fixStringLength)
                            {
                                val = Encoding.Default.GetString(arrVal.ToArray(), 0, fixStringLength);
                            }
                            else
                            {
                                for (int i = 0; i < (fixStringLength - valCount) / arrFixString.Count; i++)
                                {
                                    arrVal.AddRange(arrFixString);
                                }
                                rest = (fixStringLength - valCount) % arrFixString.Count;
                                arrVal.AddRange(arrFixString.GetRange(0, rest));
                                // --
                                val = Encoding.Default.GetString(arrVal.ToArray());
                            }
                        }
                        else if (fValueFormula.fType == FValueFormulaType.FixLengthR)
                        {
                            int fixStringLength = 0;
                            string fixString = string.Empty;

                            // --

                            FFixLengthR fFixLengthR = (FFixLengthR)fValueFormula;
                            fixStringLength = fFixLengthR.length;
                            fixString = FValueConverter.toEncodingValue(fFormat, fFixLengthR.fixString);

                            // --

                            List<byte> arrVal = new List<byte>(Encoding.Default.GetBytes(val));
                            List<byte> arrFixString = new List<byte>(Encoding.Default.GetBytes(fixString));
                            int valCount = arrVal.Count;
                            int rest = 0;

                            // --

                            if (valCount >= fixStringLength)
                            {
                                val = Encoding.Default.GetString(arrVal.ToArray(), valCount - fixStringLength, fixStringLength);
                            }
                            else
                            {
                                for (int i = 0; i < (fixStringLength - valCount) / arrFixString.Count; i++)
                                {
                                    arrVal.InsertRange(0, arrFixString);
                                }
                                rest = (fixStringLength - valCount) % arrFixString.Count;
                                arrVal.InsertRange(0, arrFixString.GetRange(arrFixString.Count - rest, rest));
                                // --
                                val = Encoding.Default.GetString(arrVal.ToArray());
                            }
                        }
                        else if (fValueFormula.fType == FValueFormulaType.Insert)
                        {
                            int startIndex = 0;
                            string insertValue = string.Empty;

                            // --

                            FInsert fInsert = (FInsert)fValueFormula;
                            startIndex = fInsert.startIndex;
                            insertValue = FValueConverter.toEncodingValue(fFormat, fInsert.value);

                            // --

                            List<byte> arrVal = new List<byte>(Encoding.Default.GetBytes(val));
                            List<byte> arrInsertValue = new List<byte>(Encoding.Default.GetBytes(insertValue));
                            int valCount = arrVal.Count;

                            // --

                            if (valCount > startIndex)
                            {
                                arrVal.InsertRange(startIndex, arrInsertValue);
                            }
                            else
                            {
                                arrVal.AddRange(arrInsertValue);
                            }
                            // --
                            val = Encoding.Default.GetString(arrVal.ToArray());
                        }
                        else if (fValueFormula.fType == FValueFormulaType.InsertR)
                        {
                            int startIndex = 0;
                            string insertValue = string.Empty;

                            // --

                            FInsertR fInsertR = (FInsertR)fValueFormula;
                            startIndex = fInsertR.startIndex;
                            insertValue = FValueConverter.toEncodingValue(fFormat, fInsertR.value);

                            // --

                            List<byte> arrVal = new List<byte>(Encoding.Default.GetBytes(val));
                            List<byte> arrInsertValue = new List<byte>(Encoding.Default.GetBytes(insertValue));
                            int valCount = arrVal.Count;

                            // --

                            if (valCount > startIndex)
                            {
                                arrVal.InsertRange(valCount - startIndex, arrInsertValue);
                            }
                            else
                            {
                                arrVal.InsertRange(0, arrInsertValue);
                            }
                            // --
                            val = Encoding.Default.GetString(arrVal.ToArray());
                        }
                        else if (fValueFormula.fType == FValueFormulaType.PadLeft)
                        {
                            int totalWidth = 0;
                            string padString = string.Empty;
                            int padLength = 0;
                            int rest = 0;

                            // --

                            FPadLeft fPadLeft = (FPadLeft)fValueFormula;
                            totalWidth = fPadLeft.totalWidth;
                            padString = FValueConverter.toEncodingValue(fFormat, fPadLeft.padString);

                            // --

                            List<byte> arrVal = new List<byte>(Encoding.Default.GetBytes(val));
                            List<byte> arrPadString = new List<byte>(Encoding.Default.GetBytes(padString));
                            int valCount = arrVal.Count;

                            // --

                            if (valCount < totalWidth)
                            {
                                padLength = (totalWidth - valCount) / arrPadString.Count;
                                rest = (totalWidth - valCount) % arrPadString.Count;
                                // --
                                arrVal.InsertRange(0, arrPadString.GetRange(0, rest));
                                for (int i = 0; i < padLength; i++)
                                {
                                    arrVal.InsertRange(0, arrPadString);
                                }
                                // --
                                val = Encoding.Default.GetString(arrVal.ToArray());
                            }
                        }
                        else if (fValueFormula.fType == FValueFormulaType.PadRight)
                        {
                            int totalWidth = 0;
                            string padString = string.Empty;
                            int padLength = 0;
                            int rest = 0;

                            // --

                            FPadRight fPadRight = (FPadRight)fValueFormula;
                            totalWidth = fPadRight.totalWidth;
                            padString = FValueConverter.toEncodingValue(fFormat, fPadRight.padString);

                            // --

                            List<byte> arrVal = new List<byte>(Encoding.Default.GetBytes(val));
                            List<byte> arrPadString = new List<byte>(Encoding.Default.GetBytes(padString));
                            int valCount = arrVal.Count;

                            // --

                            if (valCount < totalWidth)
                            {
                                padLength = (totalWidth - valCount) / arrPadString.Count;
                                rest = (totalWidth - valCount) % arrPadString.Count;
                                // --                                
                                for (int i = 0; i < padLength; i++)
                                {
                                    arrVal.AddRange(arrPadString);
                                }
                                arrVal.AddRange(arrPadString.GetRange(0, rest));
                                // --
                                val = Encoding.Default.GetString(arrVal.ToArray());
                            }
                        }
                        else if (fValueFormula.fType == FValueFormulaType.Prefix)
                        {
                            FPrefix fPrefix = (FPrefix)fValueFormula;

                            // --

                            val = FValueConverter.toEncodingValue(fFormat, fPrefix.prefixString) + val;
                        }
                        else if (fValueFormula.fType == FValueFormulaType.Remove)
                        {
                            int startIndex = 0;
                            int removeLength = 0;

                            // --

                            FRemove fRemove = (FRemove)fValueFormula;
                            startIndex = fRemove.startIndex;
                            removeLength = fRemove.length;

                            // --

                            List<byte> arrVal = new List<byte>(Encoding.Default.GetBytes(val));
                            int valCount = arrVal.Count;

                            // --

                            if (valCount > startIndex)
                            {
                                if (valCount < startIndex + removeLength)
                                {
                                    removeLength = valCount - startIndex;
                                }
                                arrVal.RemoveRange(startIndex, removeLength);
                                // --
                                val = Encoding.Default.GetString(arrVal.ToArray());
                            }
                        }
                        else if (fValueFormula.fType == FValueFormulaType.RemoveR)
                        {
                            int startIndex = 0;
                            int removeLength = 0;

                            // --

                            FRemoveR fRemoveR = (FRemoveR)fValueFormula;
                            startIndex = fRemoveR.startIndex;
                            removeLength = fRemoveR.length;

                            // --

                            List<byte> arrVal = new List<byte>(Encoding.Default.GetBytes(val));
                            int valCount = arrVal.Count;

                            // --

                            if (valCount > startIndex)
                            {
                                if (valCount < startIndex + removeLength)
                                {
                                    removeLength = valCount - startIndex;
                                }
                                arrVal.RemoveRange(valCount - startIndex - removeLength, removeLength);
                                // --
                                val = Encoding.Default.GetString(arrVal.ToArray());
                            }
                        }
                        else if (fValueFormula.fType == FValueFormulaType.Replace)
                        {
                            string oldValue = string.Empty;
                            string newValue = string.Empty;

                            // --

                            FReplace fReplace = (FReplace)fValueFormula;
                            oldValue = FValueConverter.toEncodingValue(fFormat, fReplace.oldValue);
                            newValue = FValueConverter.toEncodingValue(fFormat, fReplace.newValue);

                            // --

                            val = val.Replace(oldValue, newValue);
                        }
                        else if (fValueFormula.fType == FValueFormulaType.Select || fValueFormula.fType == FValueFormulaType.SelectIncluded)
                        {
                            string selectString = string.Empty;
                            int selectPosition = 0;
                            int selectLength = 0;
                            int startIndex = -1;
                            int pos = 0;

                            // --

                            if (fValueFormula.fType == FValueFormulaType.Select)
                            {
                                FSelect fSelect = (FSelect)fValueFormula;
                                selectString = FValueConverter.toEncodingValue(fFormat, fSelect.selectString);
                                selectPosition = fSelect.selectPosition;
                                selectLength = fSelect.length;
                            }
                            else
                            {
                                FSelectIncluded fSelectIncluded = (FSelectIncluded)fValueFormula;
                                selectString = FValueConverter.toEncodingValue(fFormat, fSelectIncluded.selectString);
                                selectPosition = fSelectIncluded.selectPosition;
                                selectLength = fSelectIncluded.length;
                            }

                            // --

                            // ***
                            // Start Index 검색
                            // ***
                            pos = 0;
                            for (int i = 0; i <= selectPosition; i++)
                            {
                                if (pos >= val.Length)
                                {
                                    startIndex = -1;
                                    break;
                                }
                                // --
                                startIndex = val.IndexOf(selectString, pos);
                                if (startIndex == -1)
                                {
                                    break;
                                }
                                // --
                                pos = startIndex + 1;
                            }
                            // --
                            if (startIndex == -1)
                            {
                                val = string.Empty;
                                continue;
                            }

                            // --

                            List<byte> arrVal = new List<byte>(Encoding.Default.GetBytes(val.Substring(startIndex + selectString.Length)));
                            int valCount = arrVal.Count;

                            // --                            

                            // --
                            if (fValueFormula.fType == FValueFormulaType.Select)
                            {
                                if (valCount == 0)
                                {
                                    val = string.Empty;
                                    continue;
                                }
                                // --
                                if (valCount < selectLength)
                                {
                                    selectLength = valCount;
                                }
                                // --
                                val = Encoding.Default.GetString(arrVal.GetRange(0, selectLength).ToArray());
                            }
                            else
                            {
                                if (valCount == 0)
                                {
                                    val = selectString;
                                    continue;
                                }
                                // --
                                if (valCount < selectLength)
                                {
                                    selectLength = valCount;
                                }
                                // --
                                val = selectString + Encoding.Default.GetString(arrVal.GetRange(0, selectLength).ToArray());
                            }
                        }
                        else if (fValueFormula.fType == FValueFormulaType.SelectR || fValueFormula.fType == FValueFormulaType.SelectIncludedR)
                        {
                            string selectString = string.Empty;
                            int selectPosition = 0;
                            int selectLength = 0;
                            int startIndex = -1;
                            int pos = 0;

                            // --

                            if (fValueFormula.fType == FValueFormulaType.SelectR)
                            {
                                FSelectR fSelectR = (FSelectR)fValueFormula;
                                selectString = FValueConverter.toEncodingValue(fFormat, fSelectR.selectString);
                                selectPosition = fSelectR.selectPosition;
                                selectLength = fSelectR.length;
                            }
                            else
                            {
                                FSelectIncludedR fSelectIncludedR = (FSelectIncludedR)fValueFormula;
                                selectString = FValueConverter.toEncodingValue(fFormat, fSelectIncludedR.selectString);
                                selectPosition = fSelectIncludedR.selectPosition;
                                selectLength = fSelectIncludedR.length;
                            }

                            // --

                            // ***
                            // Start Index 검색
                            // ***
                            pos = val.Length - 1;
                            for (int i = 0; i <= selectPosition; i++)
                            {
                                if (pos < 0)
                                {
                                    startIndex = -1;
                                    break;
                                }
                                // --
                                startIndex = val.LastIndexOf(selectString, pos);
                                if (startIndex == -1)
                                {
                                    break;
                                }
                                // --
                                pos = startIndex - 1;
                            }
                            // --
                            if (startIndex == -1)
                            {
                                val = string.Empty;
                                continue;
                            }

                            // --

                            List<byte> arrVal = new List<byte>(Encoding.Default.GetBytes(val.Substring(0, startIndex)));
                            int valCount = arrVal.Count;

                            // --

                            if (fValueFormula.fType == FValueFormulaType.SelectR)
                            {
                                if (valCount == 0)
                                {
                                    val = string.Empty;
                                    continue;
                                }
                                // --
                                if (valCount < selectLength)
                                {
                                    selectLength = valCount;
                                }
                                // --
                                val = Encoding.Default.GetString(arrVal.GetRange(valCount - selectLength, selectLength).ToArray());
                            }
                            else
                            {
                                if (valCount == 0)
                                {
                                    val = selectString;
                                    continue;
                                }
                                // --
                                if (valCount < selectLength)
                                {
                                    selectLength = valCount;
                                }
                                // --
                                val = Encoding.Default.GetString(arrVal.GetRange(valCount - selectLength, selectLength).ToArray()) + selectString;
                            }
                        }
                        else if (fValueFormula.fType == FValueFormulaType.SubString)
                        {
                            int startIndex = 0;
                            int subStringLength = 0;

                            // --

                            FSubString fSubString = (FSubString)fValueFormula;
                            startIndex = fSubString.startIndex;
                            subStringLength = fSubString.length;

                            // --

                            List<byte> arrVal = new List<byte>(Encoding.Default.GetBytes(val));
                            int valCount = arrVal.Count;

                            // --

                            if (valCount < startIndex)
                            {
                                val = string.Empty;
                                continue;
                            }
                            // --
                            if (valCount < startIndex + subStringLength)
                            {
                                subStringLength = valCount - startIndex;
                            }
                            // --
                            val = Encoding.Default.GetString(arrVal.GetRange(startIndex, subStringLength).ToArray());
                        }
                        else if (fValueFormula.fType == FValueFormulaType.SubStringR)
                        {
                            int startIndex = 0;
                            int subStringLength = 0;

                            // --

                            FSubStringR fSubStringR = (FSubStringR)fValueFormula;
                            startIndex = fSubStringR.startIndex;
                            subStringLength = fSubStringR.length;

                            // --

                            List<byte> arrVal = new List<byte>(Encoding.Default.GetBytes(val));
                            int valCount = arrVal.Count;

                            // --

                            if (valCount < startIndex)
                            {
                                val = string.Empty;
                                continue;
                            }
                            // --
                            if (valCount < startIndex + subStringLength)
                            {
                                subStringLength = valCount - startIndex;
                            }
                            // --
                            val = Encoding.Default.GetString(arrVal.GetRange(valCount - startIndex - subStringLength, subStringLength).ToArray());
                        }
                        else if (fValueFormula.fType == FValueFormulaType.Suffix)
                        {
                            FSuffix fSuffix = (FSuffix)fValueFormula;

                            // --

                            val = val + FValueConverter.toEncodingValue(fFormat, fSuffix.suffixString);
                        }
                        else if (fValueFormula.fType == FValueFormulaType.ToLower)
                        {
                            val = val.ToLower();
                        }
                        else if (fValueFormula.fType == FValueFormulaType.ToUpper)
                        {
                            val = val.ToUpper();
                        }
                        else if (fValueFormula.fType == FValueFormulaType.Trim)
                        {
                            string trimString = string.Empty;
                            int trimLength = 0;

                            // --

                            FTrim fTrim = (FTrim)fValueFormula;
                            trimString = FValueConverter.toEncodingValue(fFormat, fTrim.trimString);
                            trimLength = trimString.Length;

                            // --

                            // ***
                            // Trim Start
                            // ***
                            while (true)
                            {
                                if (val.Length < trimLength || val.Substring(0, trimLength) != trimString)
                                {
                                    break;
                                }
                                // --
                                val = val.Remove(0, trimLength);
                            }

                            // --

                            // ***
                            // Trim End
                            // ***
                            while (true)
                            {
                                if (val.Length < trimLength || val.Substring(val.Length - trimLength, trimLength) != trimString)
                                {
                                    break;
                                }
                                // --
                                val = val.Remove(val.Length - trimLength, trimLength);
                            }
                        }
                        else if (fValueFormula.fType == FValueFormulaType.TrimAll)
                        {
                            // --
                            // Add by Jeff.Kim 2015.12.04
                            // {0D} {0A} 개행 문자 제거를 위해 추가
                            val = val.Trim();
                        }
                        else if (fValueFormula.fType == FValueFormulaType.TrimStart)
                        {
                            string trimString = string.Empty;
                            int trimLength = 0;

                            // --

                            FTrimStart fTrimStart = (FTrimStart)fValueFormula;
                            trimString = FValueConverter.toEncodingValue(fFormat, fTrimStart.trimString);
                            trimLength = trimString.Length;

                            // --

                            while (true)
                            {
                                if (val.Length < trimLength || val.Substring(0, trimLength) != trimString)
                                {
                                    break;
                                }
                                // --
                                val = val.Remove(0, trimLength);
                            }
                        }
                        else if (fValueFormula.fType == FValueFormulaType.TrimEnd)
                        {
                            string trimString = string.Empty;
                            int trimLength = 0;

                            // --

                            FTrimEnd fTrimEnd = (FTrimEnd)fValueFormula;
                            trimString = FValueConverter.toEncodingValue(fFormat, fTrimEnd.trimString);
                            trimLength = trimString.Length;

                            // --

                            while (true)
                            {
                                if (val.Length < trimLength || val.Substring(val.Length - trimLength, trimLength) != trimString)
                                {
                                    break;
                                }
                                // --
                                val = val.Remove(val.Length - trimLength, trimLength);
                            }
                        }
                        else if (fValueFormula.fType == FValueFormulaType.StringCount)
                        {
                            string countString = string.Empty;

                            // --

                            FStringCount fStringCount = (FStringCount)fValueFormula;
                            countString = FValueConverter.toEncodingValue(fFormat, fStringCount.countString);

                            // --                            

                            val = (val.Split(new string[] { countString }, StringSplitOptions.None).Length - 1).ToString();
                        }
                        else if (fValueFormula.fType == FValueFormulaType.Length)
                        {
                            val = Encoding.Default.GetByteCount(FValueConverter.toEncodingValue(fFormat, val)).ToString();
                        }
                        else if (fValueFormula.fType == FValueFormulaType.DecimalToHex)      // 2017.03.27 by spike.lee add
                        {
                            int iVal = 0;
                            if (int.TryParse(val, out iVal))
                            {
                                val = iVal.ToString("X");
                            }
                        }
                        else if (fValueFormula.fType == FValueFormulaType.HexToDecimal)      // 2017.03.27 by spike.lee add
                        {
                            int iVal = 0;
                            if (int.TryParse(val, System.Globalization.NumberStyles.HexNumber, null, out iVal))
                            {
                                val = iVal.ToString();
                            }
                        }
                    }   // for end

                    // --

                    length = Encoding.Default.GetByteCount(val);
                    val = fromStringValue(fFormat, val);

                    #endregion
                }
                else
                {
                    if (value == string.Empty)
                    {
                        return value;
                    }

                    // --

                    List<string> arrVal = new List<string>(value.Split(' '));
                    // --
                    foreach (string valueFormula in valueFormulaList)
                    {
                        fValueFormula = FValueFormulaBase.createValueFormula(valueFormula);

                        // --

                        if (fValueFormula.fType == FValueFormulaType.SelectArray)
                        {
                            #region FValueFormulaType.SelectArray
                            int startIndex = 0;
                            int selectLength = 0;

                            // --

                            FSelectArray fSelectArray = (FSelectArray)fValueFormula;
                            startIndex = fSelectArray.startIndex;
                            selectLength = fSelectArray.length;

                            // --

                            if (arrVal.Count <= startIndex)
                            {
                                arrVal = new List<string>();
                                continue;
                            }
                            // --
                            if (arrVal.Count < startIndex + selectLength)
                            {
                                selectLength = arrVal.Count - startIndex;
                            }
                            // --
                            arrVal = arrVal.GetRange(startIndex, selectLength);
                            #endregion
                        }
                        else if (fValueFormula.fType == FValueFormulaType.SelectArrayR)
                        {
                            #region FValueFormulaType.SelectArrayR
                            int startIndex = 0;
                            int selectLength = 0;

                            // --

                            FSelectArrayR fSelectArrayR = (FSelectArrayR)fValueFormula;
                            startIndex = fSelectArrayR.startIndex;
                            selectLength = fSelectArrayR.length;

                            // --

                            if (arrVal.Count <= startIndex)
                            {
                                arrVal = new List<string>();
                                continue;
                            }
                            // --
                            if (arrVal.Count < startIndex + selectLength)
                            {
                                selectLength = arrVal.Count - startIndex;
                            }
                            // --
                            arrVal = arrVal.GetRange(arrVal.Count - startIndex - selectLength, selectLength);
                            #endregion
                        }
                        else if (fValueFormula.fType == FValueFormulaType.ToBit)
                        {
                            #region FValueFormulaType.ToBit
                            List<string> newArrVal = new List<string>();
                            string cVal = string.Empty;

                            if (fFormat == FFormat.Binary)
                            {
                                foreach (string v in arrVal)
                                {
                                    cVal = Convert.ToString(Convert.ToByte(v, 16), 2).PadLeft(8, '0');
                                    for (int i = cVal.Length - 1; i >= 0; i--)
                                    {
                                        newArrVal.Add(cVal[i] == '0' ? "00" : "01");
                                    }
                                }
                            }
                            else if (fFormat == FFormat.Boolean)
                            {
                                foreach (string v in arrVal)
                                {
                                    cVal = Convert.ToString(Convert.ToByte(v == FBoolean.True ? "FF" : "00", 16), 2).PadLeft(8, '0');
                                    for (int i = cVal.Length - 1; i >= 0; i--)
                                    {
                                        newArrVal.Add(cVal[i] == '0' ? "F" : "T");
                                    }
                                }
                            }
                            else if (fFormat == FFormat.I8)
                            {
                                foreach (string v in arrVal)
                                {
                                    foreach (byte b in BitConverter.GetBytes(Int64.Parse(v)))
                                    {
                                        cVal = Convert.ToString(b, 2).PadLeft(8, '0');
                                        for (int i = cVal.Length - 1; i >= 0; i--)
                                        {
                                            newArrVal.Add(cVal[i].ToString());
                                        }
                                    }
                                }
                            }
                            else if (fFormat == FFormat.I4)
                            {
                                foreach (string v in arrVal)
                                {
                                    foreach (byte b in BitConverter.GetBytes(Int32.Parse(v)))
                                    {
                                        cVal = Convert.ToString(b, 2).PadLeft(8, '0');
                                        for (int i = cVal.Length - 1; i >= 0; i--)
                                        {
                                            newArrVal.Add(cVal[i].ToString());
                                        }
                                    }
                                }
                            }
                            else if (fFormat == FFormat.I2)
                            {
                                foreach (string v in arrVal)
                                {
                                    foreach (byte b in BitConverter.GetBytes(Int16.Parse(v)))
                                    {
                                        cVal = Convert.ToString(b, 2).PadLeft(8, '0');
                                        for (int i = cVal.Length - 1; i >= 0; i--)
                                        {
                                            newArrVal.Add(cVal[i].ToString());
                                        }
                                    }
                                }
                            }
                            else if (fFormat == FFormat.I1)
                            {
                                foreach (string v in arrVal)
                                {
                                    cVal = Convert.ToString((byte)sbyte.Parse(v), 2).PadLeft(8, '0');
                                    for (int i = cVal.Length - 1; i >= 0; i--)
                                    {
                                        newArrVal.Add(cVal[i].ToString());
                                    }
                                }
                            }
                            else if (fFormat == FFormat.F8)
                            {
                                foreach (string v in arrVal)
                                {
                                    foreach (byte b in BitConverter.GetBytes(Convert.ToDouble(v)))
                                    {
                                        cVal = Convert.ToString(b, 2).PadLeft(8, '0');
                                        for (int i = cVal.Length - 1; i >= 0; i--)
                                        {
                                            newArrVal.Add(cVal[i].ToString());
                                        }
                                    }
                                }
                            }
                            else if (fFormat == FFormat.F4)
                            {
                                foreach (string v in arrVal)
                                {
                                    foreach (byte b in BitConverter.GetBytes(Convert.ToSingle(v)))
                                    {
                                        cVal = Convert.ToString(b, 2).PadLeft(8, '0');
                                        for (int i = cVal.Length - 1; i >= 0; i--)
                                        {
                                            newArrVal.Add(cVal[i].ToString());
                                        }
                                    }
                                }
                            }
                            else if (fFormat == FFormat.U8)
                            {
                                foreach (string v in arrVal)
                                {
                                    foreach (byte b in BitConverter.GetBytes(UInt64.Parse(v)))
                                    {
                                        cVal = Convert.ToString(b, 2).PadLeft(8, '0');
                                        for (int i = cVal.Length - 1; i >= 0; i--)
                                        {
                                            newArrVal.Add(cVal[i].ToString());
                                        }
                                    }
                                }
                            }
                            else if (fFormat == FFormat.U4)
                            {
                                foreach (string v in arrVal)
                                {
                                    foreach (byte b in BitConverter.GetBytes(UInt32.Parse(v)))
                                    {
                                        cVal = Convert.ToString(b, 2).PadLeft(8, '0');
                                        for (int i = cVal.Length - 1; i >= 0; i--)
                                        {
                                            newArrVal.Add(cVal[i].ToString());
                                        }
                                    }
                                }
                            }
                            else if (fFormat == FFormat.U2)
                            {
                                foreach (string v in arrVal)
                                {
                                    foreach (byte b in BitConverter.GetBytes(UInt16.Parse(v)))
                                    {
                                        cVal = Convert.ToString(b, 2).PadLeft(8, '0');
                                        for (int i = cVal.Length - 1; i >= 0; i--)
                                        {
                                            newArrVal.Add(cVal[i].ToString());
                                        }
                                    }
                                }
                            }
                            else if (fFormat == FFormat.U1)
                            {
                                foreach (string v in arrVal)
                                {
                                    cVal = Convert.ToString(byte.Parse(v), 2).PadLeft(8, '0');
                                    for (int i = cVal.Length - 1; i >= 0; i--)
                                    {
                                        newArrVal.Add(cVal[i].ToString());
                                    }
                                }
                            }

                            arrVal = newArrVal;
                            #endregion
                        }
                        else if (fValueFormula.fType == FValueFormulaType.Add)
                        {
                            #region FValueFormulaType.Add
                            List<string> newArrVal = new List<string>();
                            string cVal = string.Empty;

                            // --

                            FAdd fAdd = (FAdd)fValueFormula;

                            // --

                            foreach (string v in arrVal)
                            {
                                if (fFormat == FFormat.Binary)
                                {
                                    byte bVal = byte.Parse(v);
                                    long aVal = long.Parse(fAdd.addValue);
                                    long valResult = (byte)aVal + bVal;
                                    if (byte.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.I8)
                                {
                                    Int64 bVal = Int64.Parse(v);
                                    long aVal = long.Parse(fAdd.addValue);
                                    long valResult = (Int64)aVal + bVal;
                                    if (Int64.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.I4)
                                {
                                    Int32 bVal = Int32.Parse(v);
                                    long aVal = long.Parse(fAdd.addValue);
                                    long valResult = (Int32)aVal + bVal;
                                    if (Int32.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.I2)
                                {
                                    Int16 bVal = Int16.Parse(v);
                                    long aVal = long.Parse(fAdd.addValue);
                                    long valResult = (Int16)aVal + bVal;
                                    if (Int16.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.I1)
                                {
                                    sbyte bVal = sbyte.Parse(v);
                                    long aVal = long.Parse(fAdd.addValue);
                                    long valResult = (sbyte)aVal + bVal;
                                    if (sbyte.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.F8)
                                {
                                    double bVal = double.Parse(v);
                                    double aVal = double.Parse(fAdd.addValue);
                                    double valResult = (double)aVal + bVal;
                                    if (double.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.F4)
                                {
                                    float bVal = float.Parse(v);
                                    float aVal = float.Parse(fAdd.addValue);
                                    double valResult = aVal + bVal;
                                    if (float.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.U8)
                                {
                                    UInt64 bVal = UInt64.Parse(v);
                                    ulong aVal = ulong.Parse(fAdd.addValue);
                                    ulong valResult = aVal + bVal;
                                    if (UInt64.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.U4)
                                {
                                    UInt32 bVal = UInt32.Parse(v);
                                    ulong aVal = ulong.Parse(fAdd.addValue);
                                    ulong valResult = aVal + bVal;
                                    if (UInt32.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.U2)
                                {
                                    UInt16 bVal = UInt16.Parse(v);
                                    ulong aVal = ulong.Parse(fAdd.addValue);
                                    ulong valResult = aVal + bVal;
                                    if (UInt16.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.U1)
                                {
                                    byte bVal = byte.Parse(v);
                                    ulong aVal = ulong.Parse(fAdd.addValue);
                                    ulong valResult = aVal + bVal;
                                    if (UInt16.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }

                                // --
                                newArrVal.Add(cVal);
                            }

                            // --

                            if (resultCode == FResultCode.Success)
                                arrVal = newArrVal;

                            // --

                            #endregion
                        }
                        else if (fValueFormula.fType == FValueFormulaType.Subtract)
                        {
                            #region FValueFormulaType.Subtract
                            List<string> newArrVal = new List<string>();
                            string cVal = string.Empty;

                            // --

                            FSubtract fSubtract = (FSubtract)fValueFormula;

                            // --

                            foreach (string v in arrVal)
                            {
                                if (fFormat == FFormat.Binary)
                                {
                                    byte bVal = byte.Parse(v);
                                    long aVal = long.Parse(fSubtract.subtractValue);
                                    if (bVal < aVal)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }

                                    // --

                                    long valResult = bVal - aVal;
                                    if (byte.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.I8)
                                {
                                    Int64 bVal = Int64.Parse(v);
                                    long aVal = long.Parse(fSubtract.subtractValue);
                                    if (bVal < aVal)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }

                                    // --

                                    long valResult = bVal - aVal;
                                    if (Int64.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.I4)
                                {
                                    Int32 bVal = Int32.Parse(v);
                                    long aVal = long.Parse(fSubtract.subtractValue);
                                    if (bVal < aVal)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }

                                    // --

                                    long valResult = bVal - aVal;
                                    if (Int32.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.I2)
                                {
                                    Int16 bVal = Int16.Parse(v);
                                    long aVal = long.Parse(fSubtract.subtractValue);
                                    if (bVal < aVal)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }

                                    // --

                                    long valResult = bVal - aVal;
                                    if (Int16.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.I1)
                                {
                                    sbyte bVal = sbyte.Parse(v);
                                    long aVal = long.Parse(fSubtract.subtractValue);
                                    if (bVal < aVal)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }

                                    // --

                                    long valResult = bVal - aVal;
                                    if (sbyte.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.F8)
                                {
                                    double bVal = double.Parse(v);
                                    double aVal = double.Parse(fSubtract.subtractValue);
                                    if (bVal < aVal)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }

                                    // --

                                    double valResult = bVal - aVal;
                                    if (double.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.F4)
                                {
                                    float bVal = float.Parse(v);
                                    float aVal = float.Parse(fSubtract.subtractValue);
                                    if (bVal < aVal)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }

                                    // --

                                    double valResult = bVal - aVal;
                                    if (float.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.U8)
                                {
                                    UInt64 bVal = UInt64.Parse(v);
                                    ulong aVal = ulong.Parse(fSubtract.subtractValue);
                                    if (bVal < aVal)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }

                                    // --

                                    ulong valResult = bVal - aVal;
                                    if (UInt64.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.U4)
                                {
                                    UInt32 bVal = UInt32.Parse(v);
                                    ulong aVal = ulong.Parse(fSubtract.subtractValue);
                                    if (bVal < aVal)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }

                                    // --

                                    ulong valResult = bVal - aVal;
                                    if (UInt32.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.U2)
                                {
                                    UInt16 bVal = UInt16.Parse(v);
                                    ulong aVal = ulong.Parse(fSubtract.subtractValue);
                                    if (bVal < aVal)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }

                                    // --

                                    ulong valResult = bVal - aVal;
                                    if (UInt16.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.U1)
                                {
                                    byte bVal = byte.Parse(v);
                                    ulong aVal = ulong.Parse(fSubtract.subtractValue);

                                    if (bVal < aVal)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }

                                    // --

                                    ulong valResult = bVal - aVal;
                                    if (UInt16.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                newArrVal.Add(cVal);
                            }

                            if (resultCode == FResultCode.Success)
                                arrVal = newArrVal;

                            // --

                            #endregion
                        }
                        else if (fValueFormula.fType == FValueFormulaType.Multiply)
                        {
                            #region FValueFormulaType.Multiply
                            List<string> newArrVal = new List<string>();
                            string cVal = string.Empty;

                            // --

                            FMultiply fMultiply = (FMultiply)fValueFormula;

                            // --

                            foreach (string v in arrVal)
                            {
                                if (fFormat == FFormat.Binary)
                                {
                                    byte bVal = byte.Parse(v);
                                    long aVal = long.Parse(fMultiply.multiplyValue);

                                    // --

                                    long valResult = bVal * aVal;
                                    if (byte.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.I8)
                                {
                                    Int64 bVal = Int64.Parse(v);
                                    long aVal = long.Parse(fMultiply.multiplyValue);

                                    // --

                                    long valResult = bVal * aVal;
                                    if (Int64.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.I4)
                                {
                                    Int32 bVal = Int32.Parse(v);
                                    long aVal = long.Parse(fMultiply.multiplyValue);

                                    // --

                                    long valResult = bVal * aVal;
                                    if (Int32.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.I2)
                                {
                                    Int16 bVal = Int16.Parse(v);
                                    long aVal = long.Parse(fMultiply.multiplyValue);

                                    // --

                                    long valResult = bVal * aVal;
                                    if (Int16.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.I1)
                                {
                                    sbyte bVal = sbyte.Parse(v);
                                    long aVal = long.Parse(fMultiply.multiplyValue);

                                    // --

                                    long valResult = bVal * aVal;
                                    if (sbyte.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.F8)
                                {
                                    double bVal = double.Parse(v);
                                    double aVal = double.Parse(fMultiply.multiplyValue);

                                    // --

                                    double valResult = bVal * aVal;
                                    if (double.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.F4)
                                {
                                    float bVal = float.Parse(v);
                                    float aVal = float.Parse(fMultiply.multiplyValue);

                                    // --

                                    double valResult = bVal * aVal;
                                    if (float.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.U8)
                                {
                                    UInt64 bVal = UInt64.Parse(v);
                                    ulong aVal = ulong.Parse(fMultiply.multiplyValue);

                                    // --

                                    ulong valResult = bVal * aVal;
                                    if (UInt64.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.U4)
                                {
                                    UInt32 bVal = UInt32.Parse(v);
                                    ulong aVal = ulong.Parse(fMultiply.multiplyValue);

                                    // --

                                    ulong valResult = bVal * aVal;
                                    if (UInt32.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.U2)
                                {
                                    UInt16 bVal = UInt16.Parse(v);
                                    ulong aVal = ulong.Parse(fMultiply.multiplyValue);

                                    // --

                                    ulong valResult = bVal * aVal;
                                    if (UInt16.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                else if (fFormat == FFormat.U1)
                                {
                                    byte bVal = byte.Parse(v);
                                    ulong aVal = ulong.Parse(fMultiply.multiplyValue);

                                    // --

                                    ulong valResult = bVal * aVal;
                                    if (UInt16.MaxValue < valResult)
                                    {
                                        resultCode = FResultCode.Warninig;
                                        break;
                                    }
                                    cVal = Convert.ToString(valResult);
                                }
                                newArrVal.Add(cVal);
                            }

                            if (resultCode == FResultCode.Success)
                                arrVal = newArrVal;

                            // --

                            #endregion
                        }
                        else if (fValueFormula.fType == FValueFormulaType.Divide)
                        {
                            #region FValueFormulaType.Divide
                            List<string> newArrVal = new List<string>();
                            string cVal = string.Empty;

                            // --

                            FDivide fDivide = (FDivide)fValueFormula;

                            // --

                            foreach (string v in arrVal)
                            {
                                if (fFormat == FFormat.Binary ||
                                    fFormat == FFormat.I8 ||
                                    fFormat == FFormat.I4 ||
                                    fFormat == FFormat.I2 ||
                                    fFormat == FFormat.I1)
                                {
                                    cVal = Convert.ToString(Int64.Parse(v) / long.Parse(fDivide.divideValue));
                                }
                                else if (fFormat == FFormat.F8 ||
                                    fFormat == FFormat.F4)
                                {
                                    cVal = Convert.ToString(Convert.ToDouble(v) / double.Parse(fDivide.divideValue));
                                }
                                else if (fFormat == FFormat.U8 ||
                                    fFormat == FFormat.U4 ||
                                    fFormat == FFormat.U2 ||
                                    fFormat == FFormat.U1)
                                {
                                    cVal = Convert.ToString(UInt64.Parse(v) / ulong.Parse(fDivide.divideValue));
                                }
                                newArrVal.Add(cVal);
                            }
                            arrVal = newArrVal;

                            // --

                            #endregion
                        }
                        else if (fValueFormula.fType == FValueFormulaType.Round)
                        {
                            #region FValueFormulaType.Round
                            List<string> newArrVal = new List<string>();
                            string cVal = string.Empty;

                            // --

                            FRound fRound = (FRound)fValueFormula;

                            // --

                            foreach (string v in arrVal)
                            {
                                if (fRound.digits == 0)
                                {
                                    cVal = Convert.ToString(Math.Round(Convert.ToDouble(v)));
                                }
                                else
                                {
                                    cVal = Convert.ToString(Math.Round(Convert.ToDouble(v), fRound.digits));
                                }
                                newArrVal.Add(cVal);
                            }
                            arrVal = newArrVal;

                            // --

                            #endregion
                        }
                        else if (fValueFormula.fType == FValueFormulaType.Trunc)
                        {
                            #region FValueFormulaType.Trunc
                            List<string> newArrVal = new List<string>();
                            string cVal = string.Empty;

                            // --

                            foreach (string v in arrVal)
                            {
                                cVal = Convert.ToString(Math.Truncate(Convert.ToDouble(v)));
                                newArrVal.Add(cVal);
                            }
                            arrVal = newArrVal;

                            // --

                            #endregion
                        }
                        else if (fValueFormula.fType == FValueFormulaType.Ceil)
                        {
                            #region FValueFormulaType.Ceil
                            List<string> newArrVal = new List<string>();
                            string cVal = string.Empty;

                            // --

                            foreach (string v in arrVal)
                            {
                                cVal = Convert.ToString(Math.Ceiling(Convert.ToDouble(v)));
                                newArrVal.Add(cVal);
                            }
                            arrVal = newArrVal;

                            // --

                            #endregion
                        }
                        else if (fValueFormula.fType == FValueFormulaType.Mod)
                        {
                            #region FValueFormulaType.Ceil
                            List<string> newArrVal = new List<string>();
                            string cVal = string.Empty;

                            // --

                            FMod fMod = (FMod)fValueFormula;

                            // --

                            foreach (string v in arrVal)
                            {
                                if (fFormat == FFormat.Binary ||
                                        fFormat == FFormat.I8 ||
                                        fFormat == FFormat.I4 ||
                                        fFormat == FFormat.I2 ||
                                        fFormat == FFormat.I1)
                                {
                                    cVal = Convert.ToString(Int64.Parse(v) % long.Parse(fMod.modValue));
                                }
                                else if (fFormat == FFormat.F8 ||
                                    fFormat == FFormat.F4)
                                {
                                    cVal = Convert.ToString(Convert.ToDouble(v) % double.Parse(fMod.modValue));
                                }
                                else if (fFormat == FFormat.U8 ||
                                    fFormat == FFormat.U4 ||
                                    fFormat == FFormat.U2 ||
                                    fFormat == FFormat.U1)
                                {
                                    cVal = Convert.ToString(UInt64.Parse(v) % ulong.Parse(fMod.modValue));
                                }
                                newArrVal.Add(cVal);
                            }
                            arrVal = newArrVal;

                            // --

                            #endregion
                        }
                    }   // for end

                    // --                    

                    length = arrVal.Count;
                    val = string.Join(" ", arrVal.ToArray());
                }

                return val;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fValueFormula = null;
            }

            resultCode = FResultCode.Warninig;
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string toTransformedStringValue(
            FFormat fFormat,
            string value,
            string transformer,
            ref int length
            )
        {      
            FResultCode result = FResultCode.Success;
            try
            {
                return toTransformedStringValue(
                    fFormat, 
                    value, 
                    transformer, 
                    ref length, 
                    ref result
                    );
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

        public static string toTransformedStringValue(
            FFormat fFormat,
            string value,
            string transformer            
            )
        {
            int length = 0;

            try
            {
                return toEncodingValue(
                    fFormat,
                    toTransformedStringValue(fFormat, value, transformer, ref length)
                    );
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

        public static string toTransformedEncodingValue(
           FFormat fFormat,
           string value,
           string transformer,
           ref int length
           )
        {
            try
            {
                return toEncodingValue(
                    fFormat,
                    toTransformedStringValue(fFormat, value, transformer, ref length)
                    );
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

        public static string toTransformedEncodingValue(
            FFormat fFormat,
            string value,
            string transformer            
            )
        {
            int length = 0;

            try
            {
                return toTransformedEncodingValue(fFormat, value, transformer, ref length);
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

        public static string[] toTransformedStringArrayValue(
            FFormat fFormat,
            string value,
            string transformer
            )
        {
            int length = 0;

            try
            {
                return toStringArrayValue(
                    fFormat, 
                    toTransformedStringValue(fFormat, value, transformer, ref length)
                    );
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

        //------------------------------------------------------------------------------------------------------------------------

        public static object toTransformedValue(
            FFormat fFormat,
            string value,
            string transformer,
            int length
            )
        {
            try
            {
                return toValue(
                    fFormat, 
                    toTransformedStringValue(fFormat, value, transformer, ref length), 
                    length
                    );
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

        //------------------------------------------------------------------------------------------------------------------------

        public static object toTransformedValue(
            FFormat fFormat,
            string value,
            string transformer
            )
        {
            int length = 0;

            try
            {
                length = 1;
                return toValue(
                    fFormat,
                    toTransformedStringValue(fFormat, value, transformer, ref length),
                    length
                    );
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

        //------------------------------------------------------------------------------------------------------------------------

        public static string convertStringValue(
            FFormat fFormat, 
            FSecsLengthBytes lengthBytes,
            string value, 
            out int length
            )
        {
            StringBuilder val = null;

            try
            {
                length = 0;
                if (value == string.Empty)
                {
                    return string.Empty;
                }

                // --

                val = new StringBuilder();

                // --

                if (fFormat == FFormat.Binary)
                {
                    byte v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!byte.TryParse(s, System.Globalization.NumberStyles.HexNumber, null, out v))
                        {
                            return string.Empty;
                        }                    
                        val.Append(' ');
                        val.Append(v.ToString("X2"));
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.Boolean)
                {
                    value = value.ToLower();
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        val.Append(' ');
                        if (s == "0" || s == "f" || s == "false")
                        {
                            val.Append(FBoolean.False);
                        }
                        else
                        {
                            val.Append(FBoolean.True);
                        }
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.Ascii || fFormat == FFormat.A2)
                {
                    int cur = 0;
                    int len = 0;
                    int pos1 = 0;
                    int pos2 = 0;
                    byte[] bytes = null;
                    byte hByte = 0;

                    while (cur < value.Length)
                    {
                        // ***
                        // Hex 문자 시작점 검색
                        // ***
                        pos1 = value.IndexOf('{', cur);
                        pos2 = value.IndexOf('}', cur);
                        if (pos1 > pos2)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                        }

                        if (pos1 == -1)
                        {
                            // ***
                            // Hex 문자의 시작점 없이 종료점이 있을 경우 오류 처리
                            // ***                            
                            if (pos2 != -1)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                            }

                            // ***
                            // Hex 문자가 없을 경우 cur 위치 부터 끝까지 복사
                            // ***
                            len = value.Length - cur;
                            bytes = Encoding.Default.GetBytes(value.Substring(cur, len));
                            foreach (byte b in bytes)
                            {
                                // ***
                                // Ascii 문자 중에 Multi-Bytes 문자나 기능 문자일 경우 Hex 문자 형식으로 변환
                                // ***    
                                if (b <= 0x1F || b >= 0x7F)
                                {
                                    val.Append("{" + b.ToString("X2") + "}");
                                }
                                else
                                {
                                    val.Append((char)b);
                                }
                            }
                            // --
                            cur += len;
                            length += bytes.Length;
                        }
                        else
                        {
                            // ***
                            // cur 위치부터 Hex 문자 시작 이전 위치까지의 복사
                            // ***
                            len = pos1 - cur;
                            if (len > 0)
                            {
                                bytes = Encoding.Default.GetBytes(value.Substring(cur, len));
                                foreach (byte b in bytes)
                                {
                                    // ***
                                    // Ascii 문자 중에 Multi-Bytes 문자나 기능 문자일 경우 Hex 문자 형식으로 변환
                                    // ***    
                                    if (b <= 0x1F || b >= 0x7F)
                                    {
                                        val.Append("{" + b.ToString("X2") + "}");
                                    }
                                    else
                                    {
                                        val.Append((char)b);
                                    }
                                }
                                // --
                                length += bytes.Length;
                            }

                            // --

                            // ***
                            // Hex 문자 복사 (Hex 문자가 Ascii로 표현이 가능할 경우 Ascii 문자로 변환한다.)
                            // ***
                            len = pos2 - pos1 - 1;
                            if (len <= 0)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                            }
                            hByte = Convert.ToByte(value.Substring(pos1 + 1, len), 16);

                            // ***
                            // '{'=0x7B, '}'=0x7D
                            // ***
                            if (hByte <= 0x1F || hByte >= 0x7F || hByte == 0x7B || hByte == 0x7D)
                            {
                                val.Append("{" + hByte.ToString("X2") + "}");
                            }
                            else
                            {
                                val.Append((char)hByte);
                            }
                            // --
                            cur = pos2 + 1;
                            length++;
                        }
                    }
                }
                else if (fFormat == FFormat.I8)
                {
                    long v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!Int64.TryParse(s, out v))
                        {
                            return string.Empty;
                        }
                        val.Append(' ');
                        val.Append(v.ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.I4)
                {
                    int v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!Int32.TryParse(s, out v))
                        {
                            return string.Empty;
                        }
                        val.Append(' ');
                        val.Append(v.ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.I2)
                {
                    short v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!Int16.TryParse(s, out v))
                        {
                            return string.Empty;
                        }
                        val.Append(' ');
                        val.Append(v.ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.I1)
                {
                    sbyte v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!sbyte.TryParse(s, out v))
                        {
                            return string.Empty;
                        }
                        val.Append(' ');
                        val.Append(v.ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.F8)
                {
                    double v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!Double.TryParse(s, out v))
                        {
                            return string.Empty;
                        }
                        val.Append(' ');
                        val.Append(v.ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.F4)
                {
                    float v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!Single.TryParse(s, out v))
                        {
                            return string.Empty;
                        }
                        val.Append(' ');
                        val.Append(v.ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.U8)
                {
                    ulong v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!UInt64.TryParse(s, out v))
                        {
                            return string.Empty;
                        }
                        val.Append(' ');
                        val.Append(v.ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.U4)
                {
                    uint v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!UInt32.TryParse(s, out v))
                        {
                            return string.Empty;
                        }
                        val.Append(' ');
                        val.Append(v.ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.U2)
                {
                    ushort v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!UInt16.TryParse(s, out v))
                        {
                            return string.Empty;
                        }
                        val.Append(' ');
                        val.Append(v.ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.U1)
                {
                    byte v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!Byte.TryParse(s, out v))
                        {
                            return string.Empty;
                        }
                        val.Append(' ');
                        val.Append(v.ToString());
                        length++;
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FFormat.JIS8)
                {
                    int cur = 0;
                    int len = 0;
                    int pos1 = 0;
                    int pos2 = 0;
                    byte[] bytes = null;
                    byte hByte = 0;

                    while (cur < value.Length)
                    {
                        // ***
                        // Hex 문자 시작점 검색
                        // ***
                        pos1 = value.IndexOf('{', cur);
                        pos2 = value.IndexOf('}', cur);
                        if (pos1 > pos2)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                        }

                        if (pos1 == -1)
                        {
                            // ***
                            // Hex 문자의 시작점 없이 종료점이 있을 경우 오류 처리
                            // ***                            
                            if (pos2 != -1)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                            }

                            // ***
                            // Hex 문자가 없을 경우 cur 위치 부터 끝까지 복사
                            // ***                            

                            len = value.Length - cur;
                            bytes = Encoding.Default.GetBytes(value.Substring(cur, len));
                            foreach (byte b in bytes)
                            {
                                // ***
                                // Ascii 문자 중에 Multi-Bytes 문자나 기능 문자일 경우 Hex 문자 형식으로 변환
                                // ***    
                                if (b <= 0x1F || b >= 0x7F)
                                {
                                    val.Append("{" + b.ToString("X2") + "}");
                                }
                                else
                                {
                                    val.Append((char)b);
                                }
                            }
                            // --
                            cur += len;
                            length += bytes.Length;
                        }
                        else
                        {
                            // ***
                            // cur 위치부터 Hex 문자 시작 이전 위치까지의 복사
                            // ***
                            len = pos1 - cur;
                            if (len > 0)
                            {
                                bytes = Encoding.Default.GetBytes(value.Substring(cur, len));
                                foreach (byte b in bytes)
                                {
                                    // ***
                                    // Ascii 문자 중에 Multi-Bytes 문자나 기능 문자일 경우 Hex 문자 형식으로 변환
                                    // ***    
                                    if (b <= 0x1F || b >= 0x7F)
                                    {
                                        val.Append("{" + b.ToString("X2") + "}");
                                    }
                                    else
                                    {
                                        val.Append((char)b);
                                    }
                                }
                                // --
                                length += bytes.Length;
                            }

                            // --

                            // ***
                            // Hex 문자 복사 (Hex 문자가 Ascii로 표현이 가능할 경우 Ascii 문자로 변환한다.)
                            // ***
                            len = pos2 - pos1 - 1;
                            if (len <= 0)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                            }
                            hByte = Convert.ToByte(value.Substring(pos1 + 1, len), 16);

                            // ***
                            // '{'=0x7B, '}'=0x7D
                            // ***
                            if (hByte <= 0x1F || hByte >= 0x7F || hByte == 0x7B || hByte == 0x7D)
                            {
                                val.Append("{" + hByte.ToString("X2") + "}");
                            }
                            else
                            {
                                val.Append((char)hByte);
                            }
                            // --
                            cur = pos2 + 1;
                            length++;
                        }
                    }
                }

                // --

                // ***
                // LengthBytes Validate
                // ***
                validateLengthBytes(fFormat, lengthBytes, length);

                // --

                return val.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            length = 0;
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string convertStringValue(
            FFormat fFormat, 
            string value, 
            out int length
            )
        {
            try
            {
                return convertStringValue(fFormat, FSecsLengthBytes.Auto, value, out length);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            length = 0;
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string convertStringValue(
            FFormat fFormat, 
            string value
            )
        {
            int length = 0;

            try
            {
                return convertStringValue(fFormat, FSecsLengthBytes.Auto, value, out length);
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

        public static bool canConvertStringValue(
            FFormat format,
            string value
            )
        {
            try
            {
                if (value == string.Empty)
                {
                    return true;
                }

                // --

                if (format == FFormat.Binary)
                {
                    byte v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!byte.TryParse(s, System.Globalization.NumberStyles.HexNumber, null, out v))
                        {
                            return false;
                        }
                    }                    
                }
                else if (format == FFormat.Boolean)
                {
                    return true;
                }
                else if (format == FFormat.Ascii || format == FFormat.A2 || format == FFormat.JIS8)
                {
                    return true;
                }
                else if (format == FFormat.I8)
                {
                    long v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!long.TryParse(s, out v))
                        {
                            return false;
                        }
                    }
                }
                else if (format == FFormat.I4)
                {
                    int v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!int.TryParse(s, out v))
                        {
                            return false;
                        }
                    }
                }
                else if (format == FFormat.I2)
                {
                    short v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!short.TryParse(s, out v))
                        {
                            return false;
                        }
                    }
                }
                else if (format == FFormat.I1)
                {
                    sbyte v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!sbyte.TryParse(s, out v))
                        {
                            return false;
                        }
                    }
                }
                else if (format == FFormat.F8)
                {
                    double v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!double.TryParse(s, out v))
                        {
                            return false;
                        }
                    }
                }
                else if (format == FFormat.F4)
                {
                    float v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!float.TryParse(s, out v))
                        {
                            return false;
                        }
                    }
                }
                else if (format == FFormat.U8)
                {
                    ulong v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!ulong.TryParse(s, out v))
                        {
                            return false;
                        }
                    }
                }
                else if (format == FFormat.U4)
                {
                    uint v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!uint.TryParse(s, out v))
                        {
                            return false;
                        }
                    }
                }
                else if (format == FFormat.U2)
                {
                    ushort v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!ushort.TryParse(s, out v))
                        {
                            return false;
                        }
                    }
                }
                else if (format == FFormat.U1)
                {
                    byte v = 0;
                    foreach (string s in value.Split(' '))
                    {
                        if (s == string.Empty)
                        {
                            continue;
                        }
                        // --
                        if (!byte.TryParse(s, out v))
                        {
                            return false;
                        }
                    }       
                }

                // --

                return true;
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

        public static string toDataConversionStringValue(
            FFormat fFormat,
            string value,
            string transformer,
            string conversionExpressionList
            )
        {
            int length = 0;
            FResultCode rc = FResultCode.Success;

            try
            {
                return toDataConversionStringValue(
                    fFormat,
                    value,
                    transformer,
                    conversionExpressionList,
                    ref length,
                    ref rc
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return value;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string toDataConversionStringValue(
            FFormat fFormat,
            string value,
            string transformer,
            string conversionExpressionList,
            ref int length
            )
        {
            FResultCode rc = FResultCode.Success;
            try
            {
                return toDataConversionStringValue(
                    fFormat,
                    value,
                    transformer,
                    conversionExpressionList,
                    ref length,
                    ref rc
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return value;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string toDataConversionStringValue(
            FFormat fFormat,
            string value,
            string transformer,
            string conversionExpressionList,
            ref int length,
            ref FResultCode resultCode
            )
        {
            string[] conversionExpList = null;
            FDataConversionExpression fDce = null;
            int operandValueLength = 0;
            int newLength = 0;
            int newLengthValueTransform = 0;
            string conversionValue = string.Empty;
            string newValue = string.Empty;
            string newValueTransform = string.Empty;
            object oVal1 = null;
            object oVal2 = null;
            bool conditionCheckResult = false;
            resultCode = FResultCode.Warninig;

            try
            {
                // --

                newValueTransform = toTransformedStringValue(
                    fFormat,
                    value,
                    transformer,
                    ref length
                    );

                // --

                if (conversionExpressionList == string.Empty)
                {
                    return newValueTransform;
                }
                conversionExpList = conversionExpressionList.Split(FConstants.DataConversionSeparator);

                // --

                newValue = newValueTransform;
                newLengthValueTransform = length;
                foreach (string valueFormula in conversionExpList)
                {
                    if (valueFormula == string.Empty)
                        continue;

                    // --

                    fDce = FDataConversionExpression.createDataConversionExpression(valueFormula);
                    if (fDce.valueTransformerExpression != string.Empty)
                    {
                        newValue = toTransformedStringValue(
                            fFormat,
                            newValue,
                            fDce.valueTransformerExpression,
                            ref length
                            );
                    }

                    // --

                    // Format 을 비교하여 Item Format 표현범위보다 큰 Format 이면 Pass.
                    if (!dataConversionValidateFormat(fDce.fOperandFormat, fFormat))
                        continue;

                    // --

                    conversionValue = fDce.conversionValue;

                    // --
                    if (fDce.fComparisonMode == FComparisonMode.Value)
                    {
                        #region Value
                        if (fFormat == FFormat.Ascii || fFormat == FFormat.A2 || fFormat == FFormat.JIS8)
                        {
                            #region fFormat == FFormat.Ascii || fFormat == FFormat.A2 || fFormat == FFormat.JIS8
                            if (fDce.fOperation == FOperation.Equal)
                            {
                                conditionCheckResult = (string.Compare(newValue, fDce.stringValue) == 0 ? true : false);
                            }
                            else if (fDce.fOperation == FOperation.NotEqual)
                            {
                                conditionCheckResult = (string.Compare(newValue, fDce.stringValue) != 0 ? true : false);
                            }
                            else if (fDce.fOperation == FOperation.MoreThan)
                            {
                                conditionCheckResult = (string.Compare(newValue, fDce.stringValue) > 0 ? true : false);
                            }
                            else if (fDce.fOperation == FOperation.MoreThanOrEqual)
                            {
                                conditionCheckResult = (string.Compare(newValue, fDce.stringValue) >= 0 ? true : false);
                            }
                            else if (fDce.fOperation == FOperation.LessThan)
                            {
                                conditionCheckResult = (string.Compare(newValue, fDce.stringValue) < 0 ? true : false);
                            }
                            else if (fDce.fOperation == FOperation.LessThanOrEqual)
                            {
                                conditionCheckResult = (string.Compare(newValue, fDce.stringValue) <= 0 ? true : false);
                            }

                            if (conditionCheckResult)
                                newLength = Encoding.Default.GetByteCount(conversionValue);

                            #endregion
                        }
                        else
                        {
                            List<string> arrVal = new List<string>(newValue.Split(' '));
                            // --
                            if (fDce.operandIndex >= arrVal.Count)
                            {
                                continue;
                            }
                            // --
                            newValue = arrVal[fDce.operandIndex];
                            newLength = arrVal.Count;

                            // --

                            // Operand Value 가 실제 Item 의 Format 으로 표현할수 없으면 Pass.
                            if (!FPlcDriverCommon.validateFormatRange(fFormat, fDce.stringValue))
                            {
                                continue;
                            }

                            // Covversion Value 가 실제 Item 의 Format 으로 표현할수 없으면 Pass.
                            if (!FPlcDriverCommon.validateFormatRange(fFormat, conversionValue))
                            {
                                continue;
                            }

                            // --
                            oVal1 = FValueConverter.toValue(fFormat, newValue);
                            oVal2 = FValueConverter.toValue(fFormat, fDce.stringValue); // Format 은 Value 기준으로 변경

                            // --

                            if (oVal1 == null)
                                continue;

                            // --
                            if (fDce.fConversionMode == FConversionMode.Value)
                            {
                                #region Value

                                // --

                                if (fFormat == FFormat.Binary)
                                {
                                    #region FFormat.Binary

                                    if (fDce.fOperation == FOperation.Equal)
                                    {
                                        conditionCheckResult = ((byte)oVal1 == (byte)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.NotEqual)
                                    {
                                        conditionCheckResult = ((byte)oVal1 != (byte)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThan)
                                    {
                                        conditionCheckResult = ((byte)oVal1 > (byte)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        conditionCheckResult = ((byte)oVal1 >= (byte)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThan)
                                    {
                                        conditionCheckResult = ((byte)oVal1 < (byte)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThanOrEqual)
                                    {
                                        conditionCheckResult = ((byte)oVal1 <= (byte)oVal2 ? true : false);
                                    }
                                    #endregion
                                }
                                else if (fFormat == FFormat.Boolean)
                                {
                                    #region FFormat.Boolean
                                    if (fFormat != fDce.fOperandFormat)
                                    {
                                        conditionCheckResult = false;
                                        continue;
                                    }

                                    if (
                                        fDce.fOperation == FOperation.Equal ||
                                        fDce.fOperation == FOperation.MoreThanOrEqual ||
                                        fDce.fOperation == FOperation.LessThanOrEqual
                                        )
                                    {
                                        conditionCheckResult = ((bool)oVal1 == (bool)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.NotEqual)
                                    {
                                        conditionCheckResult = ((bool)oVal1 != (bool)oVal2 ? true : false);
                                    }
                                    #endregion
                                }
                                else if (fFormat == FFormat.I8)
                                {
                                    #region FFormat.I8
                                    if (fDce.fOperation == FOperation.Equal)
                                    {
                                        conditionCheckResult = ((Int64)oVal1 == (Int64)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.NotEqual)
                                    {
                                        conditionCheckResult = ((Int64)oVal1 != (Int64)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThan)
                                    {
                                        conditionCheckResult = ((Int64)oVal1 > (Int64)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        conditionCheckResult = ((Int64)oVal1 >= (Int64)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThan)
                                    {
                                        conditionCheckResult = ((Int64)oVal1 < (Int64)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThanOrEqual)
                                    {
                                        conditionCheckResult = ((Int64)oVal1 <= (Int64)oVal2 ? true : false);
                                    }
                                    #endregion
                                }
                                else if (fFormat == FFormat.I4)
                                {
                                    #region FFormat.I4
                                    if (fDce.fOperation == FOperation.Equal)
                                    {
                                        conditionCheckResult = ((Int32)oVal1 == (Int32)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.NotEqual)
                                    {
                                        conditionCheckResult = ((Int32)oVal1 != (Int32)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThan)
                                    {
                                        conditionCheckResult = ((Int32)oVal1 > (Int32)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        conditionCheckResult = ((Int32)oVal1 >= (Int32)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThan)
                                    {
                                        conditionCheckResult = ((Int32)oVal1 < (Int32)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThanOrEqual)
                                    {
                                        conditionCheckResult = ((Int32)oVal1 <= (Int32)oVal2 ? true : false);
                                    }
                                    #endregion
                                }
                                else if (fFormat == FFormat.I2)
                                {
                                    #region FFormat.I2
                                    if (fDce.fOperation == FOperation.Equal)
                                    {
                                        conditionCheckResult = ((Int16)oVal1 == (Int16)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.NotEqual)
                                    {
                                        conditionCheckResult = ((Int16)oVal1 != (Int16)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThan)
                                    {
                                        conditionCheckResult = ((Int16)oVal1 > (Int16)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        conditionCheckResult = ((Int16)oVal1 >= (Int16)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThan)
                                    {
                                        conditionCheckResult = ((Int16)oVal1 < (Int16)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThanOrEqual)
                                    {
                                        conditionCheckResult = ((Int16)oVal1 <= (Int16)oVal2 ? true : false);
                                    }
                                    #endregion
                                }
                                else if (fFormat == FFormat.I1)
                                {
                                    #region FFormat.I1
                                    if (fDce.fOperation == FOperation.Equal)
                                    {
                                        conditionCheckResult = ((sbyte)oVal1 == (sbyte)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.NotEqual)
                                    {
                                        conditionCheckResult = ((sbyte)oVal1 != (sbyte)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThan)
                                    {
                                        conditionCheckResult = ((sbyte)oVal1 > (sbyte)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        conditionCheckResult = ((sbyte)oVal1 >= (sbyte)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThan)
                                    {
                                        conditionCheckResult = ((sbyte)oVal1 < (sbyte)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThanOrEqual)
                                    {
                                        conditionCheckResult = ((sbyte)oVal1 <= (sbyte)oVal2 ? true : false);
                                    }
                                    #endregion
                                }
                                else if (fFormat == FFormat.F8)
                                {
                                    #region FFormat.F8

                                    if (fDce.fOperation == FOperation.Equal)
                                    {
                                        conditionCheckResult = ((Double)oVal1 == (Double)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.NotEqual)
                                    {
                                        conditionCheckResult = ((Double)oVal1 != (Double)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThan)
                                    {
                                        conditionCheckResult = ((Double)oVal1 > (Double)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        conditionCheckResult = ((Double)oVal1 >= (Double)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThan)
                                    {
                                        conditionCheckResult = ((Double)oVal1 < (Double)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThanOrEqual)
                                    {
                                        conditionCheckResult = ((Double)oVal1 <= (Double)oVal2 ? true : false);
                                    }
                                    #endregion
                                }
                                else if (fFormat == FFormat.F4)
                                {
                                    #region FFormat.F4
                                    if (fDce.fOperation == FOperation.Equal)
                                    {
                                        conditionCheckResult = ((Single)oVal1 == (Single)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.NotEqual)
                                    {
                                        conditionCheckResult = ((Single)oVal1 != (Single)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThan)
                                    {
                                        conditionCheckResult = ((Single)oVal1 > (Single)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        conditionCheckResult = ((Single)oVal1 >= (Single)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThan)
                                    {
                                        conditionCheckResult = ((Single)oVal1 < (Single)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThanOrEqual)
                                    {
                                        conditionCheckResult = ((Single)oVal1 <= (Single)oVal2 ? true : false);
                                    }
                                    #endregion
                                }
                                else if (fFormat == FFormat.U8)
                                {
                                    #region FFormat.U8
                                    if (fDce.fOperation == FOperation.Equal)
                                    {
                                        conditionCheckResult = ((UInt64)oVal1 == (UInt64)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.NotEqual)
                                    {
                                        conditionCheckResult = ((UInt64)oVal1 != (UInt64)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThan)
                                    {
                                        conditionCheckResult = ((UInt64)oVal1 > (UInt64)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        conditionCheckResult = ((UInt64)oVal1 >= (UInt64)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThan)
                                    {
                                        conditionCheckResult = ((UInt64)oVal1 < (UInt64)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThanOrEqual)
                                    {
                                        conditionCheckResult = ((UInt64)oVal1 <= (UInt64)oVal2 ? true : false);
                                    }
                                    #endregion
                                }
                                else if (fFormat == FFormat.U4)
                                {
                                    #region FFormat.U4
                                    if (fDce.fOperation == FOperation.Equal)
                                    {
                                        conditionCheckResult = ((UInt32)oVal1 == (UInt32)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.NotEqual)
                                    {
                                        conditionCheckResult = ((UInt32)oVal1 != (UInt32)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThan)
                                    {
                                        conditionCheckResult = ((UInt32)oVal1 > (UInt32)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        conditionCheckResult = ((UInt32)oVal1 >= (UInt32)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThan)
                                    {
                                        conditionCheckResult = ((UInt32)oVal1 < (UInt32)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThanOrEqual)
                                    {
                                        conditionCheckResult = ((UInt32)oVal1 <= (UInt32)oVal2 ? true : false);
                                    }
                                    #endregion
                                }
                                else if (fFormat == FFormat.U2)
                                {
                                    #region FFormat.U2
                                    if (fDce.fOperation == FOperation.Equal)
                                    {
                                        conditionCheckResult = ((UInt16)oVal1 == (UInt16)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.NotEqual)
                                    {
                                        conditionCheckResult = ((UInt16)oVal1 != (UInt16)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThan)
                                    {
                                        conditionCheckResult = ((UInt16)oVal1 > (UInt16)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        conditionCheckResult = ((UInt16)oVal1 >= (UInt16)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThan)
                                    {
                                        conditionCheckResult = ((UInt16)oVal1 < (UInt16)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThanOrEqual)
                                    {
                                        conditionCheckResult = ((UInt16)oVal1 <= (UInt16)oVal2 ? true : false);
                                    }
                                    #endregion
                                }
                                else if (fFormat == FFormat.U1)
                                {
                                    #region FFormat.U1
                                    if (fDce.fOperation == FOperation.Equal)
                                    {
                                        conditionCheckResult = ((byte)oVal1 == (byte)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.NotEqual)
                                    {
                                        conditionCheckResult = ((byte)oVal1 != (byte)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThan)
                                    {
                                        conditionCheckResult = ((byte)oVal1 > (byte)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        conditionCheckResult = ((byte)oVal1 >= (byte)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThan)
                                    {
                                        conditionCheckResult = ((byte)oVal1 < (byte)oVal2 ? true : false);
                                    }
                                    else if (fDce.fOperation == FOperation.LessThanOrEqual)
                                    {
                                        conditionCheckResult = ((byte)oVal1 <= (byte)oVal2 ? true : false);
                                    }
                                    #endregion
                                }

                                #endregion
                            }
                            else // Range
                            {
                                #region Range

                                if (fFormat == FFormat.Binary)
                                {
                                    // --

                                    int min = int.Parse(fDce.min);
                                    int max = int.Parse(fDce.max);

                                    conditionCheckResult = ((byte)oVal1 >= min && (byte)oVal1 <= max ? true : false);
                                }
                                else if (fFormat == FFormat.I8 ||
                                    fFormat == FFormat.I4 ||
                                    fFormat == FFormat.I2 ||
                                    fFormat == FFormat.I1
                                    )
                                {
                                    // --

                                    Int64 min = Int64.Parse(fDce.min);
                                    Int64 max = Int64.Parse(fDce.max);
                                    conditionCheckResult = ((Int64)oVal1 >= min && (Int64)oVal1 <= max ? true : false);
                                }
                                else if (fFormat == FFormat.F8 || fFormat == FFormat.F4)
                                {
                                    double min = double.Parse(fDce.min);
                                    double max = double.Parse(fDce.max);
                                    conditionCheckResult = ((double)oVal1 >= min && (double)oVal1 <= max ? true : false);
                                }
                                else if (fFormat == FFormat.U8 ||
                                    fFormat == FFormat.U4 ||
                                    fFormat == FFormat.U2 ||
                                    fFormat == FFormat.U1)
                                {
                                    UInt64 min = UInt64.Parse(fDce.min);
                                    UInt64 max = UInt64.Parse(fDce.max);
                                    conditionCheckResult = ((UInt64)oVal1 >= min && (UInt64)oVal1 <= max ? true : false);
                                }

                                #endregion
                            }
                        }   // ascii or no ascii if end     
                        #endregion
                    }
                    else
                    {
                        #region Length

                        // --

                        // Parsing 이 안될경우 다음 Conversion 식 확인
                        if (!int.TryParse(fDce.stringValue, out operandValueLength))
                        {
                            continue;
                        }

                        // --

                        if (fDce.fOperation == FOperation.Equal)
                        {
                            conditionCheckResult = (length == operandValueLength ? true : false);
                        }
                        else if (fDce.fOperation == FOperation.NotEqual)
                        {
                            conditionCheckResult = (length != operandValueLength ? true : false);
                        }
                        else if (fDce.fOperation == FOperation.MoreThan)
                        {
                            conditionCheckResult = (length < operandValueLength ? true : false);
                        }
                        else if (fDce.fOperation == FOperation.MoreThanOrEqual)
                        {
                            conditionCheckResult = (length <= operandValueLength ? true : false);
                        }
                        else if (fDce.fOperation == FOperation.LessThan)
                        {
                            conditionCheckResult = (length > operandValueLength ? true : false);
                        }
                        else if (fDce.fOperation == FOperation.LessThanOrEqual)
                        {
                            conditionCheckResult = (length >= operandValueLength ? true : false);
                        }

                        // --

                        if (conditionCheckResult)
                            newLength = Encoding.Default.GetByteCount(conversionValue);

                        #endregion
                    }   // comparison if end

                    // --

                    if (conditionCheckResult)
                    {
                        break;
                    }
                }

                // --

                // 조건을 만족하는 Conversion이 없을 경우 Value Transform 까지 수행한 값을 반환한다.             
                if (conditionCheckResult)
                {
                    newValue = conversionValue;
                    length = newLength;
                    resultCode = FResultCode.Success;
                }
                else
                {
                    newValue = newValueTransform;
                    length = newLengthValueTransform;
                }
                return newValue;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                conversionExpList = null;
                fDce = null;
            }
            return value;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static object toDataConversionedValue(
            FFormat fFormat,
            string value,
            string transformer,
            string conversionExpression,
            int length
            )
        {
            try
            {
                return toValue(
                    fFormat,
                    toDataConversionStringValue(fFormat, value, transformer, conversionExpression, ref length),
                    length
                    );
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

        //------------------------------------------------------------------------------------------------------------------------

        public static string toDataConversionedEncodingValue(
           FFormat fFormat,
           string value,
           string transformer,
           string conversionExpression,
           ref int length
           )
        {
            try
            {
                // --

                return toEncodingValue(
                    fFormat,
                    toDataConversionStringValue(fFormat, value, transformer, conversionExpression, ref length)
                    );
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

        public static string toDataConversionedEncodingValue(
            FFormat fFormat,
            string value,
            string transformer,
            string conversionExpression
            )
        {
            int length = 0;

            try
            {
                return toDataConversionedEncodingValue(fFormat, value, transformer, conversionExpression, ref length);
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

        public static string[] toConversionedStringArrayValue(
            FFormat fFormat,
            string value,
            string transformer,
            string conversionExpression
            )
        {
            int length = 0;

            try
            {
                return toStringArrayValue(
                    fFormat,
                    toDataConversionStringValue(fFormat, value, transformer, conversionExpression, ref length)
                    );
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

        //------------------------------------------------------------------------------------------------------------------------

        private static bool dataConversionValidateFormat(
            FFormat fConversionFormat,
            FFormat fOperandFormat
            )
        {
            bool result = false;
            try
            {
                if (fOperandFormat == FFormat.Ascii || fOperandFormat == FFormat.A2 || fOperandFormat == FFormat.JIS8)
                {
                    if (fConversionFormat == FFormat.Ascii || fConversionFormat == FFormat.A2 || fConversionFormat == FFormat.JIS8)
                    {
                        result = true;
                    }
                }
                else if (fOperandFormat == FFormat.Binary)
                {
                    if (fOperandFormat == fConversionFormat)
                        result = true;
                }
                else if (fOperandFormat == FFormat.Boolean)
                {
                    if (fOperandFormat == fConversionFormat)
                        result = true;
                }
                else if (fOperandFormat == FFormat.I8)
                {
                    if (fConversionFormat == FFormat.I8 ||
                        fConversionFormat == FFormat.I4 ||
                        fConversionFormat == FFormat.I2 ||
                        fConversionFormat == FFormat.I1)
                        result = true;
                }
                else if (fOperandFormat == FFormat.I4)
                {
                    if (fConversionFormat == FFormat.I4 ||
                        fConversionFormat == FFormat.I2 ||
                        fConversionFormat == FFormat.I1)
                        result = true;
                }
                else if (fOperandFormat == FFormat.I2)
                {
                    if (fConversionFormat == FFormat.I2 ||
                        fConversionFormat == FFormat.I1)
                        result = true;
                }
                else if (fOperandFormat == FFormat.I1)
                {
                    if (fConversionFormat == fOperandFormat)
                        result = true;
                }
                else if (fOperandFormat == FFormat.F8)
                {
                    if (fConversionFormat == FFormat.F8 ||
                        fConversionFormat == FFormat.F4)
                        result = true;
                }
                else if (fOperandFormat == FFormat.F4)
                {
                    if (fConversionFormat == fOperandFormat)
                        result = true;
                }
                else if (fOperandFormat == FFormat.U8)
                {
                    if (fConversionFormat == FFormat.U8 ||
                        fConversionFormat == FFormat.U4 ||
                        fConversionFormat == FFormat.U2 ||
                        fConversionFormat == FFormat.U1)
                        result = true;
                }
                else if (fOperandFormat == FFormat.U4)
                {
                    if (fConversionFormat == FFormat.U4 ||
                        fConversionFormat == FFormat.U2 ||
                        fConversionFormat == FFormat.U1)
                        result = true;
                }
                else if (fOperandFormat == FFormat.U2)
                {
                    if (fConversionFormat == FFormat.U2 ||
                        fConversionFormat == FFormat.U1)
                        result = true;
                }
                else if (fOperandFormat == FFormat.U1)
                {
                    if (fConversionFormat == FFormat.U1 ||
                        fConversionFormat == FFormat.Binary)
                        result = true;
                }

                return result;
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
}   // Namespace end
