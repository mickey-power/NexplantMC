/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPlcValueConverter.cs
--  Creator         : spike.lee
--  Create Date     : 2015.06.16
--  Description     : FAMate Core FaOpcDriver OPC Value Converter Class 
--  History         : Created by spike.lee at 2015.06.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    internal static class FOpcValueConverter
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static Type getValueType(
            FOpcFormat fFormat
            )
        {
            try
            {
                if (fFormat == FOpcFormat.Binary)
                {
                    return typeof(byte);
                }
                else if (fFormat == FOpcFormat.Boolean)
                {
                    return typeof(bool);
                }
                else if (fFormat == FOpcFormat.Ascii)
                {
                    return typeof(string);
                }
                else if (fFormat == FOpcFormat.I8)
                {
                    return typeof(Int64);
                }
                else if (fFormat == FOpcFormat.I4)
                {
                    return typeof(Int32);
                }
                else if (fFormat == FOpcFormat.I2)
                {
                    return typeof(Int16);
                }
                else if (fFormat == FOpcFormat.I1)
                {
                    return typeof(SByte);
                }
                else if (fFormat == FOpcFormat.F8)
                {
                    return typeof(Double);
                }
                else if (fFormat == FOpcFormat.F4)
                {
                    return typeof(Single);
                }
                else if (fFormat == FOpcFormat.U8)
                {
                    return typeof(UInt64);
                }
                else if (fFormat == FOpcFormat.U4)
                {
                    return typeof(UInt32);
                }
                else if (fFormat == FOpcFormat.U2)
                {
                    return typeof(UInt16);
                }
                else if (fFormat == FOpcFormat.U1)
                {
                    return typeof(byte);
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

        public static bool validateOpcValueType(
            FOpcFormat fFormat,
            string opcValue
            )
        {
            try
            {
                if (fFormat == FOpcFormat.Binary)
                {
                    byte v = 0;
                    return byte.TryParse(opcValue, out v);
                }
                else if (fFormat == FOpcFormat.Boolean)
                {
                    return true;
                }
                else if (fFormat == FOpcFormat.Ascii)
                {
                    return true;
                }
                else if (fFormat == FOpcFormat.I8)
                {
                    Int64 v = 0;
                    return Int64.TryParse(opcValue, out v); 
                }
                else if (fFormat == FOpcFormat.I4)
                {
                    Int32 v = 0;
                    return Int32.TryParse(opcValue, out v); 
                }
                else if (fFormat == FOpcFormat.I2)
                {
                    Int16 v = 0;
                    return Int16.TryParse(opcValue, out v); 
                }
                else if (fFormat == FOpcFormat.I1)
                {
                    sbyte v = 0;
                    return sbyte.TryParse(opcValue, out v); 
                }
                else if (fFormat == FOpcFormat.F8)
                {
                    double v = 0;
                    return double.TryParse(opcValue, out v); 
                }
                else if (fFormat == FOpcFormat.F4)
                {
                    float v = 0;
                    return float.TryParse(opcValue, out v); 
                }
                else if (fFormat == FOpcFormat.U8)
                {
                    UInt64 v = 0;
                    return UInt64.TryParse(opcValue, out v); 
                }
                else if (fFormat == FOpcFormat.U4)
                {
                    UInt32 v = 0;
                    return UInt32.TryParse(opcValue, out v); 
                }
                else if (fFormat == FOpcFormat.U2)
                {
                    UInt16 v = 0;
                    return UInt16.TryParse(opcValue, out v); 
                }
                else if (fFormat == FOpcFormat.U1)
                {
                    byte v = 0;
                    return byte.TryParse(opcValue, out v); 
                }
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

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromStringValue(
            FOpcFormat fFormat,
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

                if (fFormat == FOpcFormat.Binary)
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
                else if (fFormat == FOpcFormat.Boolean)
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
                else if (fFormat == FOpcFormat.Ascii)
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
                else if (fFormat == FOpcFormat.I8)
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
                else if (fFormat == FOpcFormat.I4)
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
                else if (fFormat == FOpcFormat.I2)
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
                else if (fFormat == FOpcFormat.I1)
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
                else if (fFormat == FOpcFormat.F8)
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
                else if (fFormat == FOpcFormat.F4)
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
                else if (fFormat == FOpcFormat.U8)
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
                else if (fFormat == FOpcFormat.U4)
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
                else if (fFormat == FOpcFormat.U2)
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
                else if (fFormat == FOpcFormat.U1)
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

        public static string fromStringValueByOriginalValue(
            FOpcFormat fFormat,
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

                if (fFormat == FOpcFormat.Ascii)
                {
                    int cur = 0;
                    int len = 0;
                    byte[] bytes = null;

                    while (cur < value.Length)
                    {
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
                            if (b <= 0x1F || b >= 0x7F || b == 0x7B || b == 0x7D)
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
                }
                else 
                {
                    // --
                    // Modify by Jeff.Kim 2015.10.22
                    // Opc read 이후에서 Ascii Parsing은 '{'를 체크 하지 않기 위해 변경
                    val.Append(
                        fromStringValue(fFormat, value, out length)
                        );
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
            length = 0;
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromStringArrayValue(
            FOpcFormat fFormat,
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

                if (fFormat == FOpcFormat.Binary)
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
                else if (fFormat == FOpcFormat.Boolean)
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
                else if (fFormat == FOpcFormat.Ascii)
                {
                    int len = 0;

                    foreach (string s in value)
                    {
                        val.Append(fromStringValue(fFormat, s, out len));
                        length += len;
                    }
                }
                else if (fFormat == FOpcFormat.I8)
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
                else if (fFormat == FOpcFormat.I4)
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
                else if (fFormat == FOpcFormat.I2)
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
                else if (fFormat == FOpcFormat.I1)
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
                else if (fFormat == FOpcFormat.F8)
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
                else if (fFormat == FOpcFormat.F4)
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
                else if (fFormat == FOpcFormat.U8)
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
                else if (fFormat == FOpcFormat.U4)
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
                else if (fFormat == FOpcFormat.U2)
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
                else if (fFormat == FOpcFormat.U1)
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

        public static string[] toStringArrayValue(
            FOpcFormat fFormat,
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

                if (fFormat == FOpcFormat.Ascii)
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

        public static string fromValue(
            FOpcFormat fFormat,
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

                if (fFormat == FOpcFormat.Binary)
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
                else if (fFormat == FOpcFormat.Boolean)
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
                        length = 1;
                    }
                }
                else if (fFormat == FOpcFormat.Ascii)
                {
                    int len = 0;

                    if (value.GetType().IsArray)
                    {
                        foreach (object o in (Array)value)
                        {
                            val.Append(fromStringValue(fFormat, Convert.ToString(o), out len));
                            length += len;
                        }
                    }
                    else
                    {
                        val.Append(fromStringValue(fFormat, Convert.ToString(value), out length));
                    }
                }
                else if (fFormat == FOpcFormat.I8)
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
                else if (fFormat == FOpcFormat.I4)
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
                else if (fFormat == FOpcFormat.I2)
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
                else if (fFormat == FOpcFormat.I1)
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
                else if (fFormat == FOpcFormat.F8)
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
                else if (fFormat == FOpcFormat.F4)
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
                else if (fFormat == FOpcFormat.U8)
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
                else if (fFormat == FOpcFormat.U4)
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
                else if (fFormat == FOpcFormat.U2)
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
                else if (fFormat == FOpcFormat.U1)
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

        public static object toValue(
            FOpcFormat fFormat,
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

                if (fFormat == FOpcFormat.Binary)
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
                else if (fFormat == FOpcFormat.Boolean)
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
                else if (fFormat == FOpcFormat.Ascii)
                {                       
                    val = toEncodingValue(fFormat, value);
                }
                else if (fFormat == FOpcFormat.I8)
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
                else if (fFormat == FOpcFormat.I4)
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
                else if (fFormat == FOpcFormat.I2)
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
                else if (fFormat == FOpcFormat.I1)
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
                else if (fFormat == FOpcFormat.F8)
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
                else if (fFormat == FOpcFormat.F4)
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
                else if (fFormat == FOpcFormat.U8)
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
                else if (fFormat == FOpcFormat.U4)
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
                else if (fFormat == FOpcFormat.U2)
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
                else if (fFormat == FOpcFormat.U1)
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

                // --

                return val;
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

        public static string toEncodingValue(
            FOpcFormat fFormat, 
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

                if (fFormat == FOpcFormat.Binary)
                {
                    // ***
                    // 2014.04.21 by spike.lee
                    // 대용량 Binary 데이터 처리 시, UI Performance 문제로 Encoding 값을 Hex 표현식 그대로 사용하도록 수정
                    // ***
                    return value;

                    //StringBuilder val = new StringBuilder();

                    //foreach (string s in value.Split(' '))
                    //{
                    //    val.Append(' ');
                    //    val.Append(Convert.ToByte(s, 16).ToString());
                    //}
                    //// --
                    //if (val.Length > 0)
                    //{
                    //    val.Remove(0, 1);
                    //}
                    //return val.ToString();
                }
                else if (fFormat == FOpcFormat.Ascii)
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

        public static string fromLength(
            FOpcFormat fFormat,
            string value,
            int length
            )
        {
            StringBuilder val = null;
            string[] arrVal = null;
            int plcByteLen = 0;

            try
            {
                if (length == 0)
                {
                    return string.Empty;
                }

                // --

                val = new StringBuilder();

                // --

                if (fFormat == FOpcFormat.Binary)
                {
                    plcByteLen = length * 2;
                    arrVal = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    // --
                    if (plcByteLen == arrVal.Length)
                    {
                        return value;
                    }
                    
                    // --

                    for (int i = 0; i < (arrVal.Length > plcByteLen ? plcByteLen : arrVal.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(arrVal[i]);
                    }
                    // --
                    for (int i = 0; i < plcByteLen - arrVal.Length; i++)
                    {
                        val.Append(' ');
                        val.Append("00");
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FOpcFormat.Boolean)
                {
                    plcByteLen = length * 2;
                    arrVal = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    // --
                    if (plcByteLen == arrVal.Length)
                    {
                        return value;
                    }

                    // --

                    for (int i = 0; i < (arrVal.Length > plcByteLen ? plcByteLen : arrVal.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(arrVal[i]);
                    }
                    // --
                    for (int i = 0; i < plcByteLen - arrVal.Length; i++)
                    {
                        val.Append(' ');
                        val.Append(FBoolean.False);
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FOpcFormat.Ascii)
                {
                    int cur = 0;
                    int len = 0;
                    int valLen = 0;
                    int pos1 = 0;
                    int pos2 = 0;

                    // --

                    plcByteLen = length * 2;

                    // --

                    while (cur < value.Length && valLen < plcByteLen)
                    {
                        // ***
                        // Hex 문자 시작점 검색
                        // ***
                        pos1 = value.IndexOf('{', cur);
                        pos2 = value.IndexOf('}', cur);

                        // --

                        if (pos1 == -1)
                        {
                            len = value.Length - cur;
                            if (valLen + len > plcByteLen)
                            {
                                len = plcByteLen - valLen;
                            }
                            val.Append(value.Substring(cur, len));
                            // --
                            valLen += len;
                            cur += len;
                        }
                        else
                        {
                            len = pos1 - cur;
                            if (len > 0)
                            {
                                if (valLen + len > plcByteLen)
                                {
                                    len = plcByteLen - valLen;
                                }
                                val.Append(value.Substring(cur, len));
                                // --
                                valLen += len;
                            }

                            // --

                            if (valLen < plcByteLen)
                            {
                                len = pos2 - pos1 + 1;
                                val.Append(value.Substring(pos1, len));
                                // --
                                valLen++;
                            }
                            // --
                            cur = pos2 + 1;
                        }
                    }

                    // --

                    //if (valLen < plcByteLen)
                    //{
                    //    val.Append(new string(' ', plcByteLen - valLen));
                    //}
                }
                else
                {
                    if (fFormat == FOpcFormat.I8)
                    {
                        if (length < 4 || length % 4 > 0)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Length for the Format"));
                        }
                        plcByteLen = length / 4;
                    }
                    else if (fFormat == FOpcFormat.I4)
                    {
                        if (length < 2 || length % 2 > 0)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Length for the Format"));
                        }
                        plcByteLen = length / 2;
                    }
                    else if (fFormat == FOpcFormat.I2)
                    {
                        plcByteLen = length;
                    }
                    else if (fFormat == FOpcFormat.I1)
                    {
                        plcByteLen = length * 2;
                    }
                    else if (fFormat == FOpcFormat.F8)
                    {
                        if (length < 4 || length % 4 > 0)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Length for the Format"));
                        }
                        plcByteLen = length / 4;
                    }
                    else if (fFormat == FOpcFormat.F4)
                    {
                        if (length < 2 || length % 2 > 0)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Length for the Format"));
                        }
                        plcByteLen = length / 2;
                    }
                    else if (fFormat == FOpcFormat.U8)
                    {
                        if (length < 4 || length % 4 > 0)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Length for the Format"));
                        }
                        plcByteLen = length / 4;
                    }
                    else if (fFormat == FOpcFormat.U4)
                    {
                        if (length < 2 || length % 2 > 0)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Length for the Format"));
                        }
                        plcByteLen = length / 2;
                    }
                    else if (fFormat == FOpcFormat.U2)
                    {
                        plcByteLen = length;
                    }
                    else if (fFormat == FOpcFormat.U1)
                    {
                        plcByteLen = length * 2;
                    }
                    // --
                    arrVal = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // --

                    if (plcByteLen == arrVal.Length)
                    {
                        return value;
                    }

                    // --

                    for (int i = 0; i < (arrVal.Length > plcByteLen ? plcByteLen : arrVal.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(arrVal[i]);
                    }
                    // --
                    for (int i = 0; i < plcByteLen - arrVal.Length; i++)
                    {
                        val.Append(' ');
                        val.Append('0');
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
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

        public static string fromBinValue(
            FOpcFormat fFormat,
            byte[] value,
            int length,
            int formatBytes
            )
        {
            StringBuilder strVal = null;
            byte[] byteArr = null;
            int index = 0;

            try
            {
                if (length == 0)
                {
                    return string.Empty;
                }

                // --

                strVal = new StringBuilder();

                // --

                if (fFormat == FOpcFormat.Binary)
                {
                    for (int i = 0; i < length; i++)
                    {
                        strVal.Append(' ');
                        strVal.Append(value[index].ToString("X2"));
                        index += formatBytes;
                    }
                    strVal.Remove(0, 1);
                }
                else if (fFormat == FOpcFormat.Boolean)
                {
                    for (int i = 0; i < length; i++)
                    {
                        strVal.Append(' ');
                        strVal.Append(FByteConverter.toBoolean(value[index]));
                        index += formatBytes;
                    }
                    strVal.Remove(0, 1);
                }
                else if (fFormat == FOpcFormat.Ascii)
                {
                    for (int i = 0; i < length; i++)
                    {
                        if (value[index] == 0x00)
                        {
                            // continue;   // Null 문제 제거
                        }
                        // ***
                        // 2016.04.21 by spike.lee 
                        // '{'와 '}' 문자 Hex 표현 처리
                        // '{'=0x7B, '}'=0x7D
                        // ***
                        else if (value[index] <= 0x1F || value[index] >= 0x7F || value[index] == 0x7B || value[index] == 0x7D)
                        {
                            strVal.Append("{" + value[index].ToString("X2") + "}");
                        }
                        else
                        {
                            strVal.Append((char)value[index]);
                        }
                        index += formatBytes;
                    }
                }
                else if (fFormat == FOpcFormat.I8)
                {
                    for (int i = 0; i < length; i++)
                    {
                        byteArr = new byte[formatBytes];
                        for (int j = 0; j < formatBytes; j++)
                        {
                            byteArr[j] = value[index + j];
                        }

                        // --

                        strVal.Append(' ');
                        strVal.Append(FByteConverter.toInt64(byteArr, false));
                        index += formatBytes;
                    }
                    strVal.Remove(0, 1);
                }
                else if (fFormat == FOpcFormat.I4)
                {
                    for (int i = 0; i < length; i++)
                    {
                        byteArr = new byte[formatBytes];
                        for (int j = 0; j < formatBytes; j++)
                        {
                            byteArr[j] = value[index + j];
                        }

                        // --

                        strVal.Append(' ');
                        strVal.Append(FByteConverter.toInt32(byteArr, false));
                        index += formatBytes;
                    }
                    strVal.Remove(0, 1);
                }
                else if (fFormat == FOpcFormat.I2)
                {
                    for (int i = 0; i < length; i++)
                    {
                        byteArr = new byte[formatBytes];
                        for (int j = 0; j < formatBytes; j++)
                        {
                            byteArr[j] = value[index + j];
                        }

                        // --

                        strVal.Append(' ');
                        strVal.Append(FByteConverter.toInt16(byteArr, false));
                        index += formatBytes;
                    }
                    strVal.Remove(0, 1);
                }
                else if (fFormat == FOpcFormat.I1)
                {
                    for (int i = 0; i < length; i++)
                    {
                        strVal.Append(' ');
                        strVal.Append(value[index]);
                        index += formatBytes;
                    }
                    strVal.Remove(0, 1);
                }
                else if (fFormat == FOpcFormat.F8)
                {
                    for (int i = 0; i < length; i++)
                    {
                        byteArr = new byte[formatBytes];
                        for (int j = 0; j < formatBytes; j++)
                        {
                            byteArr[j] = value[index + j];
                        }

                        // --

                        strVal.Append(' ');
                        strVal.Append(FByteConverter.toFloat8(byteArr, false));
                        index += formatBytes;
                    }
                    strVal.Remove(0, 1);
                }
                else if (fFormat == FOpcFormat.F4)
                {
                    for (int i = 0; i < length; i++)
                    {
                        byteArr = new byte[formatBytes];
                        for (int j = 0; j < formatBytes; j++)
                        {
                            byteArr[j] = value[index + j];
                        }

                        // --

                        strVal.Append(' ');
                        strVal.Append(FByteConverter.toFloat4(byteArr, false));
                        index += formatBytes;
                    }
                    strVal.Remove(0, 1);
                }
                else if (fFormat == FOpcFormat.U8)
                {
                    for (int i = 0; i < length; i++)
                    {
                        byteArr = new byte[formatBytes];
                        for (int j = 0; j < formatBytes; j++)
                        {
                            byteArr[j] = value[index + j];
                        }

                        // -- 

                        strVal.Append(' ');
                        strVal.Append(FByteConverter.toUInt64(byteArr, false));
                        index += formatBytes;
                    }
                    strVal.Remove(0, 1);
                }
                else if (fFormat == FOpcFormat.U4)
                {
                    for (int i = 0; i < length; i++)
                    {
                        byteArr = new byte[formatBytes];
                        for (int j = 0; j < formatBytes; j++)
                        {
                            byteArr[j] = value[index + j];
                        }

                        // -- 

                        strVal.Append(' ');
                        strVal.Append(FByteConverter.toUInt32(byteArr, false));
                        index += formatBytes;
                    }
                    strVal.Remove(0, 1);
                }
                else if (fFormat == FOpcFormat.U2)
                {
                    for (int i = 0; i < length; i++)
                    {
                        byteArr = new byte[formatBytes];
                        for (int j = 0; j < formatBytes; j++)
                        {
                            byteArr[j] = value[index + j];
                        }

                        // -- 

                        strVal.Append(' ');
                        strVal.Append(FByteConverter.toUInt16(byteArr, false));
                        index += formatBytes;
                    }
                    strVal.Remove(0, 1);
                }
                else if (fFormat == FOpcFormat.U1)
                {
                    for (int i = 0; i < length; i++)
                    {
                        strVal.Append(' ');
                        strVal.Append(value[index]);
                        index += formatBytes;
                    }
                    strVal.Remove(0, 1);
                }
                
                // --

                return strVal.ToString();
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

        public static byte[] toBinValue(
            FOpcFormat fFormat, 
            string value, 
            int length
            )
        {
            string[] arrVal = null;
            List<byte> byteVal = null;

            try
            {
                if (length == 0)
                {
                    return null;
                }

                // --

                //if (fFormat != FOpcFormat.Ascii)
                //{
                //    arrVal = value.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                //}

                arrVal = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                byteVal = new List<byte>();

                // --

                if (fFormat == FOpcFormat.Binary)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.Add(byte.Parse(s, System.Globalization.NumberStyles.HexNumber));
                    }
                }
                else if (fFormat == FOpcFormat.Boolean)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.AddRange(FByteConverter.getBytes(FBoolean.toBool(s),  false));
                    }
                }
                else if (fFormat == FOpcFormat.Ascii)
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
                    byteVal.AddRange(bytes);
                }
                else if (fFormat == FOpcFormat.I8)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.AddRange(FByteConverter.getBytes(Convert.ToInt64(s), false));
                    }
                }
                else if (fFormat == FOpcFormat.I4)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.AddRange(FByteConverter.getBytes(Convert.ToInt32(s), false));
                    }
                }
                else if (fFormat == FOpcFormat.I2)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.AddRange(FByteConverter.getBytes(Convert.ToInt16(s), false));
                    }
                }
                else if (fFormat == FOpcFormat.I1)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.Add((byte)sbyte.Parse(s));
                    }
                }
                else if (fFormat == FOpcFormat.F8)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.AddRange(FByteConverter.getBytes(Convert.ToDouble(s), false));
                    }
                }
                else if (fFormat == FOpcFormat.F4)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.AddRange(FByteConverter.getBytes(Convert.ToSingle(s), false));
                    }
                }
                else if (fFormat == FOpcFormat.U8)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.AddRange(FByteConverter.getBytes(Convert.ToUInt64(s), false));
                    }
                }
                else if (fFormat == FOpcFormat.U4)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.AddRange(FByteConverter.getBytes(Convert.ToUInt32(s), false));
                    }
                }
                else if (fFormat == FOpcFormat.U2)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.AddRange(FByteConverter.getBytes(Convert.ToUInt16(s), false));
                    }
                }
                else if (fFormat == FOpcFormat.U1)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.Add(byte.Parse(s));
                    }
                }
                    
                // --

                return byteVal.ToArray();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                byteVal = null;
                arrVal = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static int getFormatBytes(
            FOpcFormat fFormat
            )
        {
            try
            {
                if (fFormat == FOpcFormat.Binary)
                {
                    return 1;
                }
                else if (fFormat == FOpcFormat.Boolean)
                {
                    return 1;
                }
                else if (fFormat == FOpcFormat.Ascii)
                {
                    return 1;
                }
                else if (fFormat == FOpcFormat.I8)
                {
                    return 8;
                }
                else if (fFormat == FOpcFormat.I4)
                {
                    return 4;
                }
                else if (fFormat == FOpcFormat.I2)
                {
                    return 2;
                }
                else if (fFormat == FOpcFormat.I1)
                {
                    return 1;
                }
                else if (fFormat == FOpcFormat.F8)
                {
                    return 8;
                }
                else if (fFormat == FOpcFormat.F4)
                {
                    return 4;
                }
                else if (fFormat == FOpcFormat.U8)
                {
                    return 8;
                }
                else if (fFormat == FOpcFormat.U4)
                {
                    return 4;
                }
                else if (fFormat == FOpcFormat.U2)
                {
                    return 2;
                }
                else if (fFormat == FOpcFormat.U1)
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
