/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPlcValueConverter.cs
--  Creator         : heonsik
--  Create Date     : 2013.07.15
--  Description     : FAMate Core FaPlcDriver PLC Value Converter Class 
--  History         : Created by heonsik at 2013.07.25
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
    internal static class FPlcValueConverter
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static byte toMelseceDeviceCode(
            string code
            )
        {
            try
            {
                if (code.Equals("X"))
                {
                    return 0x9C;
                }
                else if (code.Equals("Y"))
                {
                    return 0x9D;
                }
                else if (code.Equals("M"))
                {
                    return 0x90;
                }
                else if (code.Equals("L"))
                {
                    return 0x92;
                }
                else if (code.Equals("S"))
                {
                    return 0x98;
                }
                else if (code.Equals("B"))
                {
                    return 0xA0;
                }
                else if (code.Equals("F"))
                {
                    return 0x93;
                }
                else if (code.Equals("TS"))
                {
                    return 0xC1;
                }
                else if (code.Equals("TC"))
                {
                    return 0xC0;
                }
                else if (code.Equals("TN"))
                {
                    return 0xC2;
                }
                else if (code.Equals("CS"))
                {
                    return 0xC4;
                }
                else if (code.Equals("CC"))
                {
                    return 0xC3;
                }
                else if (code.Equals("CN"))
                {
                    return 0xC5;
                }
                else if (code.Equals("D"))
                {
                    return 0xA8;
                }
                else if (code.Equals("W"))
                {
                    return 0xB4;
                }
                else if (code.Equals("R"))
                {
                    return 0xAF;
                }
                else if (code.Equals("ZR"))
                {
                    return 0xB0;
                }
                return 0x92; // Default L 영역
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
            FPlcWordFormat fFormat
            )
        {
            try
            {
                if (fFormat == FPlcWordFormat.Binary)
                {
                    return typeof(byte);
                }
                else if (fFormat == FPlcWordFormat.Boolean)
                {
                    return typeof(bool);
                }
                else if (fFormat == FPlcWordFormat.Ascii)
                {
                    return typeof(string);
                }
                else if (fFormat == FPlcWordFormat.I8)
                {
                    return typeof(Int64);
                }
                else if (fFormat == FPlcWordFormat.I4)
                {
                    return typeof(Int32);
                }
                else if (fFormat == FPlcWordFormat.I2)
                {
                    return typeof(Int16);
                }
                else if (fFormat == FPlcWordFormat.I1)
                {
                    return typeof(SByte);
                }
                else if (fFormat == FPlcWordFormat.F8)
                {
                    return typeof(Double);
                }
                else if (fFormat == FPlcWordFormat.F4)
                {
                    return typeof(Single);
                }
                else if (fFormat == FPlcWordFormat.U8)
                {
                    return typeof(UInt64);
                }
                else if (fFormat == FPlcWordFormat.U4)
                {
                    return typeof(UInt32);
                }
                else if (fFormat == FPlcWordFormat.U2)
                {
                    return typeof(UInt16);
                }
                else if (fFormat == FPlcWordFormat.U1)
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

        public static string fromLinkMapValue(
            FLinkMapExpression fLme,
            string value
            )
        {
            int val = 0;

            try
            {
                if (value == string.Empty)
                {
                    return val.ToString();
                }
                if (fLme == FLinkMapExpression.Decimal)
                {
                    val = Int32.Parse(value);
                    if (val < 0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0014, "value"));
                    }
                    // --
                    return val.ToString();
                }
                return Convert.ToInt64(value, 16).ToString();
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

        public static string toLinkMapValue(
            FLinkMapExpression fLme,
            string value
            )
        {
            int val = 0;
            try
            {
                if (value == string.Empty)
                {
                    return val.ToString();
                }

                if (fLme == FLinkMapExpression.Decimal)
                {
                    return value;
                }

                return Int32.Parse(value).ToString("X");

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

        public static string fromBitStringValue(
            string value,
            int length
            )
        {
            string[] arrVal = null;
            StringBuilder val = null;

            try
            {
                if (length == 0)
                {
                    return string.Empty;
                }

                // --

                arrVal = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                val = new StringBuilder();

                // --

                for (int i = 0; i < (arrVal.Length > length ? length : arrVal.Length); i++)
                {
                    val.Append(' ');
                    // --
                    if (arrVal[i] == "0")
                    {
                        val.Append('0');
                    }
                    else
                    {
                        val.Append('1');
                    }
                }
                // --
                for (int i = 0; i < length - arrVal.Length; i++)
                {
                    val.Append(' ');
                    val.Append('0');
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

        public static string fromBitStringArrayValue(
            string[] value, 
            int length
            )
        {
            StringBuilder val = null;

            try
            {
                if (length == 0)
                {
                    return string.Empty;
                }

                // --

                val = new StringBuilder();

                // --

                if (value == null)
                {
                    for (int i = 0; i < length; i++)
                    {
                        val.Append(' ');
                        val.Append('0');
                    }
                }
                else
                {
                    for (int i = 0; i < (value.Length > length ? length : value.Length); i++)
                    {
                        val.Append(' ');
                        // --
                        if (value[i] == "0")
                        {
                            val.Append('0');
                        }
                        else
                        {
                            val.Append('1');
                        }
                    }
                    // --
                    for (int i = 0; i < length - value.Length; i++)
                    {
                        val.Append(' ');
                        val.Append('0');
                    }
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
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------
    
        public static string[] toBitStringArrayValue(
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
                foreach (string s in value.Split(' '))
                {
                    val.Add(s);
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

        public static string fromBitValue(
            object value, 
            int length
            )
        {
            StringBuilder val = null;
            byte byteVal = 0;

            try
            {
                if (length == 0)
                {
                    return string.Empty;
                }

                // --

                val = new StringBuilder();

                // --

                if (value == null)
                {
                    for (int i = 0; i < length; i++)
                    {
                        val.Append(' ');
                        val.Append('0');
                    }
                }
                else if (!value.GetType().IsArray)
                {
                    val.Append(' ');
                    // --
                    byteVal = Convert.ToByte(value);
                    if (byteVal == 0)
                    {
                        val.Append('0');
                    }
                    else
                    {
                        val.Append('1');
                    }
                    // --
                    for (int i = 0; i < length - 1; i++)
                    {
                        val.Append(' ');
                        val.Append('0');
                    }
                }
                else
                {
                    for (int i = 0; i < (((Array)value).Length > length ? length : ((Array)value).Length) ; i++)
                    {
                        val.Append(' ');
                        // --
                        byteVal = Convert.ToByte(((Array)value).GetValue(i));
                        if (byteVal == 0)
                        {
                            val.Append('0');
                        }
                        else
                        {
                            val.Append('1');
                        }
                    }
                    // --
                    for (int i = 0; i < length - ((Array)value).Length; i++)
                    {
                        val.Append(' ');
                        val.Append('0');
                    }
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

        public static object toBitValue(
            string value,
            int length
            )
        {
            object val = null;
            List<byte> arrVal = null;

            try
            {
                if (value == string.Empty)
                {
                    return null;
                }

                // --

                if (length > 1)
                {
                    arrVal = new List<byte>();
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

                // --

                return val;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                arrVal = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromBitLength(
            string value,
            int length
            )
        {
            StringBuilder val = null;
            string[] arrVal = null;

            try
            {
                arrVal = value.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                if (arrVal.Length == length)
                {
                    return value;
                }

                // --

                val = new StringBuilder();

                // --

                for (int i = 0; i < (arrVal.Length > length ? length : arrVal.Length); i++)
                {
                    val.Append(' ');
                    val.Append(arrVal[i]);
                }
                // --
                for (int i = 0; i < length - arrVal.Length; i++)
                {
                    val.Append(' ');
                    val.Append('0');
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

        public static string fromWordStringValue(
            FPlcWordFormat fFormat,
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

                if (fFormat == FPlcWordFormat.Binary)
                {
                    plcByteLen = length * 2;
                    arrVal = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // --

                    for (int i = 0; i < (arrVal.Length > plcByteLen ? plcByteLen : arrVal.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToByte(arrVal[i], 16).ToString("X2"));
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
                else if (fFormat == FPlcWordFormat.Boolean)
                {
                    // ***
                    // Boolean는 0 or F or f or FALSE or False or false를 False로 처리한다.
                    // 값은 True를 T로 False를 F로 표기한다.
                    // ***
                    plcByteLen = length * 2;
                    arrVal = value.ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // --

                    for (int i = 0; i < (arrVal.Length > plcByteLen ? plcByteLen : arrVal.Length); i++)
                    {
                        val.Append(' ');
                        // --
                        if (arrVal[i] == "0" || arrVal[i] == "f" || arrVal[i] == "false")
                        {
                            val.Append(FBoolean.False);
                        }
                        else
                        {
                            val.Append(FBoolean.True);
                        }
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
                else if (fFormat == FPlcWordFormat.Ascii)
                {
                    int cur = 0;
                    int len = 0;
                    int valLen = 0;
                    int pos1 = 0;
                    int pos2 = 0;
                    byte[] bytes = null;
                    byte hByte = 0;

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
                        if (pos1 > pos2)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                        }

                        // --

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
                            if (valLen + len > plcByteLen)
                            {
                                len = plcByteLen - valLen;
                            }

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
                            valLen += bytes.Length;
                        }
                        else
                        {
                            // ***
                            // cur 위치부터 Hex 문자 시작 이전 위치까지의 복사
                            // ***
                            len = pos1 - cur;
                            if (len > 0)
                            {
                                if (valLen + len > plcByteLen)
                                {
                                    len = plcByteLen - valLen;
                                }

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
                                valLen += bytes.Length;
                            }

                            // --

                            if (valLen < plcByteLen)
                            {
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
                else if (fFormat == FPlcWordFormat.I8)
                {
                    plcByteLen = length / 4;
                    arrVal = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // --

                    for (int i = 0; i < (arrVal.Length > plcByteLen ? plcByteLen : arrVal.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToInt64(arrVal[i]).ToString());
                    }
                    // --
                    for (int i = 0; i < plcByteLen - arrVal.Length; i++)
                    {
                        val.Append(' ');
                        val.Append("0");
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.I4)
                {
                    plcByteLen = length / 2;
                    arrVal = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // --

                    for (int i = 0; i < (arrVal.Length > plcByteLen ? plcByteLen : arrVal.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToInt32(arrVal[i]).ToString());
                    }
                    // --
                    for (int i = 0; i < plcByteLen - arrVal.Length; i++)
                    {
                        val.Append(' ');
                        val.Append("0");
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.I2)
                {
                    plcByteLen = length;
                    arrVal = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // --

                    for (int i = 0; i < (arrVal.Length > plcByteLen ? plcByteLen : arrVal.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToInt16(arrVal[i]).ToString());
                    }
                    // --
                    for (int i = 0; i < plcByteLen - arrVal.Length; i++)
                    {
                        val.Append(' ');
                        val.Append("0");
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.I1)
                {
                    plcByteLen = length * 2;
                    arrVal = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // --

                    for (int i = 0; i < (arrVal.Length > plcByteLen ? plcByteLen : arrVal.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToSByte(arrVal[i]).ToString());
                    }
                    // --
                    for (int i = 0; i < plcByteLen - arrVal.Length; i++)
                    {
                        val.Append(' ');
                        val.Append("0");
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.F8)
                {
                    plcByteLen = length / 4;
                    arrVal = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // --

                    for (int i = 0; i < (arrVal.Length > plcByteLen ? plcByteLen : arrVal.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToDouble(arrVal[i]).ToString());
                    }
                    // --
                    for (int i = 0; i < plcByteLen - arrVal.Length; i++)
                    {
                        val.Append(' ');
                        val.Append("0");
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.F4)
                {
                    plcByteLen = length / 2;
                    arrVal = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // --

                    for (int i = 0; i < (arrVal.Length > plcByteLen ? plcByteLen : arrVal.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToSingle(arrVal[i]).ToString());
                    }
                    // --
                    for (int i = 0; i < plcByteLen - arrVal.Length; i++)
                    {
                        val.Append(' ');
                        val.Append("0");
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.U8)
                {
                    plcByteLen = length / 4;
                    arrVal = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // --

                    for (int i = 0; i < (arrVal.Length > plcByteLen ? plcByteLen : arrVal.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToUInt64(arrVal[i]).ToString());
                    }
                    // --
                    for (int i = 0; i < plcByteLen - arrVal.Length; i++)
                    {
                        val.Append(' ');
                        val.Append("0");
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.U4)
                {
                    plcByteLen = length / 2;
                    arrVal = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // --

                    for (int i = 0; i < (arrVal.Length > plcByteLen ? plcByteLen : arrVal.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToUInt32(arrVal[i]).ToString());
                    }
                    // --
                    for (int i = 0; i < plcByteLen - arrVal.Length; i++)
                    {
                        val.Append(' ');
                        val.Append("0");
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.U2)
                {
                    plcByteLen = length;
                    arrVal = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // --

                    for (int i = 0; i < (arrVal.Length > plcByteLen ? plcByteLen : arrVal.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToUInt16(arrVal[i]).ToString());
                    }
                    // --
                    for (int i = 0; i < plcByteLen - arrVal.Length; i++)
                    {
                        val.Append(' ');
                        val.Append("0");
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.U1)
                {
                    plcByteLen = length * 2;
                    arrVal = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // --

                    for (int i = 0; i < (arrVal.Length > plcByteLen ? plcByteLen : arrVal.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToByte(arrVal[i]).ToString());
                    }
                    // --
                    for (int i = 0; i < plcByteLen - arrVal.Length; i++)
                    {
                        val.Append(' ');
                        val.Append("0");
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

        public static string fromWordStringArrayValue(
            FPlcWordFormat fFormat,
            string[] value,
            int length
            )
        {
            StringBuilder val = null;
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

                if (fFormat == FPlcWordFormat.Binary)
                {
                    plcByteLen = length * 2;

                    // --

                    for (int i = 0; i < (value.Length > plcByteLen ? plcByteLen : value.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToByte(value[i], 16).ToString("X2"));

                    }
                    // --
                    for (int i = 0; i < plcByteLen - value.Length; i++)
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
                else if (fFormat == FPlcWordFormat.Boolean)
                {
                    plcByteLen = length * 2;

                    // --

                    for (int i = 0; i < (value.Length > plcByteLen ? plcByteLen : value.Length); i++)
                    {
                        val.Append(' ');
                        // --
                        value[i] = value[i].ToLower();
                        if (value[i] == "0" || value[i] == "f" || value[i] == "false")
                        {
                            val.Append(FBoolean.False);
                        }
                        else
                        {
                            val.Append(FBoolean.True);
                        }
                    }
                    // --
                    for (int i = 0; i < plcByteLen - value.Length; i++)
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
                else if (fFormat == FPlcWordFormat.Ascii)
                {
                    string strVal = string.Empty;
                    int cur = 0;
                    int len = 0;
                    int valLen = 0;
                    int pos1 = 0;
                    int pos2 = 0;
                    byte[] bytes = null;
                    byte hByte = 0;

                    // --

                    plcByteLen = length * 2;

                    // --

                    foreach (string s in value)
                    {
                        strVal += s;
                    }

                    // --

                    while (cur < strVal.Length && valLen < plcByteLen)
                    {
                        // ***
                        // Hex 문자 시작점 검색
                        // ***
                        pos1 = strVal.IndexOf('{', cur);
                        pos2 = strVal.IndexOf('}', cur);
                        if (pos1 > pos2)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                        }

                        // --

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
                            len = strVal.Length - cur;
                            if (valLen + len > plcByteLen)
                            {
                                len = plcByteLen - valLen;
                            }

                            bytes = Encoding.Default.GetBytes(strVal.Substring(cur, len));
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
                            valLen += bytes.Length;
                        }
                        else
                        {
                            // ***
                            // cur 위치부터 Hex 문자 시작 이전 위치까지의 복사
                            // ***
                            len = pos1 - cur;
                            if (len > 0)
                            {
                                if (valLen + len > plcByteLen)
                                {
                                    len = plcByteLen - valLen;
                                }

                                bytes = Encoding.Default.GetBytes(strVal.Substring(cur, len));
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
                                valLen += bytes.Length;
                            }

                            // --

                            if (valLen < plcByteLen)
                            {
                                len = pos2 - pos1 - 1;
                                if (len <= 0)
                                {
                                    FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                                }
                                hByte = Convert.ToByte(strVal.Substring(pos1 + 1, len), 16);

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
                                valLen++;
                            }

                            // --

                            cur = pos2 + 1;
                        }
                    }

                    // --

                    if (valLen < plcByteLen)
                    {
                        val.Append(new string(' ', plcByteLen - valLen));
                    }
                }
                else if (fFormat == FPlcWordFormat.I8)
                {
                    plcByteLen = length / 4;

                    // --

                    for (int i = 0; i < (value.Length > plcByteLen ? plcByteLen : value.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToInt64(value[i]).ToString());

                    }
                    // --
                    for (int i = 0; i < plcByteLen - value.Length; i++)
                    {
                        val.Append(' ');
                        val.Append("0");
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.I4)
                {
                    plcByteLen = length / 2;

                    // --

                    for (int i = 0; i < (value.Length > plcByteLen ? plcByteLen : value.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToInt32(value[i]).ToString());

                    }
                    // --
                    for (int i = 0; i < plcByteLen - value.Length; i++)
                    {
                        val.Append(' ');
                        val.Append("0");
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.I2)
                {
                    plcByteLen = length;

                    // --

                    for (int i = 0; i < (value.Length > plcByteLen ? plcByteLen : value.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToInt16(value[i]).ToString());

                    }
                    // --
                    for (int i = 0; i < plcByteLen - value.Length; i++)
                    {
                        val.Append(' ');
                        val.Append("0");
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.I1)
                {
                    plcByteLen = length * 2;

                    // --

                    for (int i = 0; i < (value.Length > plcByteLen ? plcByteLen : value.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToSByte(value[i]).ToString());

                    }
                    // --
                    for (int i = 0; i < plcByteLen - value.Length; i++)
                    {
                        val.Append(' ');
                        val.Append("0");
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.F8)
                {
                    plcByteLen = length / 4;

                    // --

                    for (int i = 0; i < (value.Length > plcByteLen ? plcByteLen : value.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToDouble(value[i]).ToString());

                    }
                    // --
                    for (int i = 0; i < plcByteLen - value.Length; i++)
                    {
                        val.Append(' ');
                        val.Append("0");
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.F4)
                {
                    plcByteLen = length / 2;

                    // --

                    for (int i = 0; i < (value.Length > plcByteLen ? plcByteLen : value.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToSingle(value[i]).ToString());

                    }
                    // --
                    for (int i = 0; i < plcByteLen - value.Length; i++)
                    {
                        val.Append(' ');
                        val.Append("0");
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.U8)
                {
                    plcByteLen = length / 4;

                    // --

                    for (int i = 0; i < (value.Length > plcByteLen ? plcByteLen : value.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToUInt64(value[i]).ToString());

                    }
                    // --
                    for (int i = 0; i < plcByteLen - value.Length; i++)
                    {
                        val.Append(' ');
                        val.Append("0");
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.U4)
                {
                    plcByteLen = length / 2;

                    // --

                    for (int i = 0; i < (value.Length > plcByteLen ? plcByteLen : value.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToUInt32(value[i]).ToString());

                    }
                    // --
                    for (int i = 0; i < plcByteLen - value.Length; i++)
                    {
                        val.Append(' ');
                        val.Append("0");
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.U2)
                {
                    plcByteLen = length;

                    // --

                    for (int i = 0; i < (value.Length > plcByteLen ? plcByteLen : value.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToUInt16(value[i]).ToString());

                    }
                    // --
                    for (int i = 0; i < plcByteLen - value.Length; i++)
                    {
                        val.Append(' ');
                        val.Append("0");
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.U1)
                {
                    plcByteLen = length * 2;

                    // --

                    for (int i = 0; i < (value.Length > plcByteLen ? plcByteLen : value.Length); i++)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToByte(value[i]).ToString());

                    }
                    // --
                    for (int i = 0; i < plcByteLen - value.Length; i++)
                    {
                        val.Append(' ');
                        val.Append("0");
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

        public static string[] toWordStringArrayValue(
            FPlcWordFormat fFormat,
            string value,
            int length
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

                if (fFormat == FPlcWordFormat.Ascii)
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

        public static string fromWordValue(
            FPlcWordFormat fFormat,
            object value,
            int length
            )
        {
            StringBuilder val = null;
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

                if (fFormat == FPlcWordFormat.Binary)
                {
                    plcByteLen = length * 2;

                    // --

                    if (value == null)
                    {
                        for (int i = 0; i < plcByteLen; i++)
                        {
                            val.Append(' ');
                            val.Append("00");
                        }
                    }
                    else if (!value.GetType().IsArray)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToByte(value).ToString("X2"));
                        // --
                        for (int i = 0; i < plcByteLen - 1; i++)
                        {
                            val.Append(' ');
                            val.Append("00");
                        }
                    }
                    else
                    {
                        for (int i = 0; i < (((Array)value).Length > plcByteLen ? plcByteLen : ((Array)value).Length); i++)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToByte(((Array)value).GetValue(i)).ToString("X2"));
                        }
                        // --
                        for (int i = 0; i < plcByteLen - ((Array)value).Length; i++)
                        {
                            val.Append(' ');
                            val.Append("00");
                        }
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.Boolean)
                {
                    plcByteLen = length * 2;

                    // --

                    if (value == null)
                    {
                        for (int i = 0; i < plcByteLen; i++)
                        {
                            val.Append(' ');
                            val.Append(FBoolean.False);
                        }
                    }
                    else if (!value.GetType().IsArray)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToBoolean(value) ? FBoolean.True : FBoolean.False);
                        // --
                        for (int i = 0; i < plcByteLen - 1; i++)
                        {
                            val.Append(' ');
                            val.Append(FBoolean.False);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < (((Array)value).Length > plcByteLen ? plcByteLen : ((Array)value).Length); i++)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToBoolean(((Array)value).GetValue(i)) ? FBoolean.True : FBoolean.False);
                        }
                        // --
                        for (int i = 0; i < plcByteLen - ((Array)value).Length; i++)
                        {
                            val.Append(' ');
                            val.Append(FBoolean.False);
                        }
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.Ascii)
                {
                    string strVal = string.Empty;
                    int cur = 0;
                    int len = 0;
                    int valLen = 0;
                    int pos1 = 0;
                    int pos2 = 0;
                    byte[] bytes = null;
                    byte hByte = 0;

                    // --

                    plcByteLen = length * 2;

                    // --

                    if (value == null)
                    {
                        strVal = string.Empty;
                    }
                    else if (!value.GetType().IsArray)
                    {
                        strVal = Convert.ToString(value);
                    }
                    else
                    {
                        foreach (string s in (Array)value)
                        {
                            strVal += s;
                        }
                    }

                    // --

                    while (cur < strVal.Length && valLen < plcByteLen)
                    {
                        // ***
                        // Hex 문자 시작점 검색
                        // ***
                        pos1 = strVal.IndexOf('{', cur);
                        pos2 = strVal.IndexOf('}', cur);
                        if (pos1 > pos2)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                        }

                        // --

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
                            len = strVal.Length - cur;
                            if (valLen + len > plcByteLen)
                            {
                                len = plcByteLen - valLen;
                            }

                            bytes = Encoding.Default.GetBytes(strVal.Substring(cur, len));
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
                            valLen += bytes.Length;
                        }
                        else
                        {
                            // ***
                            // cur 위치부터 Hex 문자 시작 이전 위치까지의 복사
                            // ***
                            len = pos1 - cur;
                            if (len > 0)
                            {
                                if (valLen + len > plcByteLen)
                                {
                                    len = plcByteLen - valLen;
                                }

                                bytes = Encoding.Default.GetBytes(strVal.Substring(cur, len));
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
                                valLen += bytes.Length;
                            }

                            // --

                            if (valLen < plcByteLen)
                            {
                                len = pos2 - pos1 - 1;
                                if (len <= 0)
                                {
                                    FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                                }
                                hByte = Convert.ToByte(strVal.Substring(pos1 + 1, len), 16);

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
                                valLen++;
                            }

                            // --

                            cur = pos2 + 1;
                        }
                    }

                    // --

                    if (valLen < plcByteLen)
                    {
                        val.Append(new string(' ', plcByteLen - valLen));
                    }
                }
                else if (fFormat == FPlcWordFormat.I8)
                {
                    plcByteLen = length / 4;

                    // --

                    if (value == null)
                    {
                        for (int i = 0; i < plcByteLen; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    else if (!value.GetType().IsArray)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToInt64(value).ToString());
                        // --
                        for (int i = 0; i < plcByteLen - 1; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    else
                    {
                        for (int i = 0; i < (((Array)value).Length > plcByteLen ? plcByteLen : ((Array)value).Length); i++)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToInt64(((Array)value).GetValue(i)).ToString());
                        }
                        // --
                        for (int i = 0; i < plcByteLen - ((Array)value).Length; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.I4)
                {
                    plcByteLen = length / 2;

                    // --

                    if (value == null)
                    {
                        for (int i = 0; i < plcByteLen; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    else if (!value.GetType().IsArray)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToInt32(value).ToString());
                        // --
                        for (int i = 0; i < plcByteLen - 1; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    else
                    {
                        for (int i = 0; i < (((Array)value).Length > plcByteLen ? plcByteLen : ((Array)value).Length); i++)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToInt32(((Array)value).GetValue(i)).ToString());
                        }
                        // --
                        for (int i = 0; i < plcByteLen - ((Array)value).Length; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.I2)
                {
                    plcByteLen = length;

                    // --

                    if (value == null)
                    {
                        for (int i = 0; i < plcByteLen; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    else if (!value.GetType().IsArray)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToInt16(value).ToString());
                        // --
                        for (int i = 0; i < plcByteLen - 1; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    else
                    {
                        for (int i = 0; i < (((Array)value).Length > plcByteLen ? plcByteLen : ((Array)value).Length); i++)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToInt16(((Array)value).GetValue(i)).ToString());
                        }
                        // --
                        for (int i = 0; i < plcByteLen - ((Array)value).Length; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.I1)
                {
                    plcByteLen = length * 2;

                    // --

                    if (value == null)
                    {
                        for (int i = 0; i < plcByteLen; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    else if (!value.GetType().IsArray)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToSByte(value).ToString());
                        // --
                        for (int i = 0; i < plcByteLen - 1; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    else
                    {
                        for (int i = 0; i < (((Array)value).Length > plcByteLen ? plcByteLen : ((Array)value).Length); i++)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToSByte(((Array)value).GetValue(i)).ToString());
                        }
                        // --
                        for (int i = 0; i < plcByteLen - ((Array)value).Length; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.F8)
                {
                    plcByteLen = length / 4;

                    // --

                    if (value == null)
                    {
                        for (int i = 0; i < plcByteLen; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    else if (!value.GetType().IsArray)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToDouble(value).ToString());
                        // --
                        for (int i = 0; i < plcByteLen - 1; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    else
                    {
                        for (int i = 0; i < (((Array)value).Length > plcByteLen ? plcByteLen : ((Array)value).Length); i++)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToDouble(((Array)value).GetValue(i)).ToString());
                        }
                        // --
                        for (int i = 0; i < plcByteLen - ((Array)value).Length; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.F4)
                {
                    plcByteLen = length / 2;

                    // --

                    if (value == null)
                    {
                        for (int i = 0; i < plcByteLen; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    else if (!value.GetType().IsArray)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToSingle(value).ToString());
                        // --
                        for (int i = 0; i < plcByteLen - 1; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    else
                    {
                        for (int i = 0; i < (((Array)value).Length > plcByteLen ? plcByteLen : ((Array)value).Length); i++)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToSingle(((Array)value).GetValue(i)).ToString());
                        }
                        // --
                        for (int i = 0; i < plcByteLen - ((Array)value).Length; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.U8)
                {
                    plcByteLen = length / 4;

                    // --

                    if (value == null)
                    {
                        for (int i = 0; i < plcByteLen; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    else if (!value.GetType().IsArray)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToUInt64(value).ToString());
                        // --
                        for (int i = 0; i < plcByteLen - 1; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    else
                    {
                        for (int i = 0; i < (((Array)value).Length > plcByteLen ? plcByteLen : ((Array)value).Length); i++)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToUInt64(((Array)value).GetValue(i)).ToString());
                        }
                        // --
                        for (int i = 0; i < plcByteLen - ((Array)value).Length; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.U4)
                {
                    plcByteLen = length / 2;

                    // --

                    if (value == null)
                    {
                        for (int i = 0; i < plcByteLen; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    else if (!value.GetType().IsArray)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToUInt32(value).ToString());
                        // --
                        for (int i = 0; i < plcByteLen - 1; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    else
                    {
                        for (int i = 0; i < (((Array)value).Length > plcByteLen ? plcByteLen : ((Array)value).Length); i++)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToUInt32(((Array)value).GetValue(i)).ToString());
                        }
                        // --
                        for (int i = 0; i < plcByteLen - ((Array)value).Length; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.U2)
                {
                    plcByteLen = length;

                    // --

                    if (value == null)
                    {
                        for (int i = 0; i < plcByteLen; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    else if (!value.GetType().IsArray)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToUInt16(value).ToString());
                        // --
                        for (int i = 0; i < plcByteLen - 1; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    else
                    {
                        for (int i = 0; i < (((Array)value).Length > plcByteLen ? plcByteLen : ((Array)value).Length); i++)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToUInt16(((Array)value).GetValue(i)).ToString());
                        }
                        // --
                        for (int i = 0; i < plcByteLen - ((Array)value).Length; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    // --
                    if (val.Length > 0)
                    {
                        val.Remove(0, 1);
                    }
                }
                else if (fFormat == FPlcWordFormat.U1)
                {
                    plcByteLen = length * 2;

                    // --

                    if (value == null)
                    {
                        for (int i = 0; i < plcByteLen; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    else if (!value.GetType().IsArray)
                    {
                        val.Append(' ');
                        val.Append(Convert.ToByte(value).ToString());
                        // --
                        for (int i = 0; i < plcByteLen - 1; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
                    }
                    else
                    {
                        for (int i = 0; i < (((Array)value).Length > plcByteLen ? plcByteLen : ((Array)value).Length); i++)
                        {
                            val.Append(' ');
                            val.Append(Convert.ToByte(((Array)value).GetValue(i)).ToString());
                        }
                        // --
                        for (int i = 0; i < plcByteLen - ((Array)value).Length; i++)
                        {
                            val.Append(' ');
                            val.Append("0");
                        }
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

        public static object toWordValue(
            FPlcWordFormat fFormat,
            string value,
            int length
            )
        {
            object val = null;
            int plcByteLen = 0;

            try
            {
                if (length == 0)
                {
                    return null;
                }

                // --

                if (fFormat == FPlcWordFormat.Binary)
                {
                    List<byte> arrVal = new List<byte>();
                    foreach (string s in value.Split(' '))
                    {
                        arrVal.Add(Convert.ToByte(s, 16));
                    }
                    val = arrVal.ToArray();
                }
                else if (fFormat == FPlcWordFormat.Boolean)
                {
                    List<bool> arrVal = new List<bool>();
                    foreach (string s in value.Split(' '))
                    {
                        arrVal.Add(s == FBoolean.True ? true : false);
                    }
                    val = arrVal.ToArray();
                }
                else if (fFormat == FPlcWordFormat.Ascii)
                {                    
                    val = toWordEncodingValue(fFormat, value); 
                }
                else if (fFormat == FPlcWordFormat.I8)
                {
                    plcByteLen = length / 4;
                    // --
                    if (plcByteLen > 1)
                    {
                        List<Int64> arrVal = new List<Int64>();
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
                else if (fFormat == FPlcWordFormat.I4)
                {
                    plcByteLen = length / 2;
                    // --
                    if (plcByteLen > 1)
                    {
                        List<Int32> arrVal = new List<Int32>();
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
                else if (fFormat == FPlcWordFormat.I2)
                {
                    plcByteLen = length;
                    // --
                    if (plcByteLen > 1)
                    {
                        List<Int16> arrVal = new List<Int16>();
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
                else if (fFormat == FPlcWordFormat.I1)
                {
                    List<SByte> arrVal = new List<SByte>();
                    foreach (string s in value.Split(' '))
                    {
                        arrVal.Add(Convert.ToSByte(s));
                    }
                    val = arrVal.ToArray();
                }
                else if (fFormat == FPlcWordFormat.F8)
                {
                    plcByteLen = length / 4;
                    // --
                    if (plcByteLen > 1)
                    {
                        List<Double> arrVal = new List<Double>();
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
                else if (fFormat == FPlcWordFormat.F4)
                {
                    plcByteLen = length / 2;
                    // --
                    if (plcByteLen > 1)
                    {
                        List<Single> arrVal = new List<Single>();
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
                else if (fFormat == FPlcWordFormat.U8)
                {
                    plcByteLen = length / 4;
                    // --
                    if (plcByteLen > 1)
                    {
                        List<UInt64> arrVal = new List<UInt64>();
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
                else if (fFormat == FPlcWordFormat.U4)
                {
                    plcByteLen = length / 2;
                    // --
                    if (plcByteLen > 1)
                    {
                        List<UInt32> arrVal = new List<UInt32>();
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
                else if (fFormat == FPlcWordFormat.U2)
                {
                    plcByteLen = length;
                    // --
                    if (plcByteLen > 1)
                    {
                        List<UInt16> arrVal = new List<UInt16>();
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
                else if (fFormat == FPlcWordFormat.U1)
                {
                    List<Byte> arrVal = new List<Byte>();
                    foreach (string s in value.Split(' '))
                    {
                        arrVal.Add(Convert.ToByte(s));
                    }
                    val = arrVal.ToArray();
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

        public static string toWordEncodingValue(
            FPlcWordFormat fFormat, 
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

                if (fFormat == FPlcWordFormat.Binary)
                {
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
                }
                else if (fFormat == FPlcWordFormat.Ascii)
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

        public static string fromWordLength(
            FPlcWordFormat fFormat,
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

                if (fFormat == FPlcWordFormat.Binary)
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
                else if (fFormat == FPlcWordFormat.Boolean)
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
                else if (fFormat == FPlcWordFormat.Ascii)
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
                    if (fFormat == FPlcWordFormat.I8)
                    {
                        if (length < 4 || length % 4 > 0)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Length for the Format"));
                        }
                        plcByteLen = length / 4;
                    }
                    else if (fFormat == FPlcWordFormat.I4)
                    {
                        if (length < 2 || length % 2 > 0)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Length for the Format"));
                        }
                        plcByteLen = length / 2;
                    }
                    else if (fFormat == FPlcWordFormat.I2)
                    {
                        plcByteLen = length;
                    }
                    else if (fFormat == FPlcWordFormat.I1)
                    {
                        plcByteLen = length * 2;
                    }
                    else if (fFormat == FPlcWordFormat.F8)
                    {
                        if (length < 4 || length % 4 > 0)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Length for the Format"));
                        }
                        plcByteLen = length / 4;
                    }
                    else if (fFormat == FPlcWordFormat.F4)
                    {
                        if (length < 2 || length % 2 > 0)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Length for the Format"));
                        }
                        plcByteLen = length / 2;
                    }
                    else if (fFormat == FPlcWordFormat.U8)
                    {
                        if (length < 4 || length % 4 > 0)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Length for the Format"));
                        }
                        plcByteLen = length / 4;
                    }
                    else if (fFormat == FPlcWordFormat.U4)
                    {
                        if (length < 2 || length % 2 > 0)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Length for the Format"));
                        }
                        plcByteLen = length / 2;
                    }
                    else if (fFormat == FPlcWordFormat.U2)
                    {
                        plcByteLen = length;
                    }
                    else if (fFormat == FPlcWordFormat.U1)
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

        public static string fromWordFormat(
            FPlcWordFormat fFormat, 
            int length
            )
        {
            StringBuilder val = null;
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

                if (fFormat == FPlcWordFormat.Binary)
                {
                    plcByteLen = length * 2;

                    // --

                    for (int i = 0; i < plcByteLen; i++)
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
                else if (fFormat == FPlcWordFormat.Boolean)
                {
                    plcByteLen = length * 2;

                    // --

                    for (int i = 0; i < plcByteLen; i++)
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
                else if (fFormat == FPlcWordFormat.Ascii)
                {
                    plcByteLen = length * 2;
                    // --
                    val.Append(new string(' ', plcByteLen));
                }
                else
                {
                    if (fFormat == FPlcWordFormat.I8)
                    {
                        if (length < 4 || length % 4 > 0)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Length for the Format"));
                        }
                        plcByteLen = length / 4;
                    }
                    else if (fFormat == FPlcWordFormat.I4)
                    {
                        if (length < 2 || length % 2 > 0)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Length for the Format"));
                        }
                        plcByteLen = length / 2;
                    }
                    else if (fFormat == FPlcWordFormat.I2)
                    {
                        plcByteLen = length;
                    }
                    else if (fFormat == FPlcWordFormat.I1)
                    {
                        plcByteLen = length * 2;
                    }
                    else if (fFormat == FPlcWordFormat.F8)
                    {
                        if (length < 4 || length % 4 > 0)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Length for the Format"));
                        }
                        plcByteLen = length / 4;
                    }
                    else if (fFormat == FPlcWordFormat.F4)
                    {
                        if (length < 2 || length % 2 > 0)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Length for the Format"));
                        }
                        plcByteLen = length / 2;
                    }
                    else if (fFormat == FPlcWordFormat.U8)
                    {
                        if (length < 4 || length % 4 > 0)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Length for the Format"));
                        }
                        plcByteLen = length / 4;
                    }
                    else if (fFormat == FPlcWordFormat.U4)
                    {
                        if (length < 2 || length % 2 > 0)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Length for the Format"));
                        }
                        plcByteLen = length / 2;
                    }
                    else if (fFormat == FPlcWordFormat.U2)
                    {
                        plcByteLen = length;
                    }
                    else if (fFormat == FPlcWordFormat.U1)
                    {
                        plcByteLen = length * 2;
                    }

                    // --

                    for (int i = 0; i < plcByteLen; i++)
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

        public static string fromWordBinValue(
            FPlcWordFormat fFormat,
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

                if (fFormat == FPlcWordFormat.Binary)
                {
                    for (int i = 0; i < length; i++)
                    {
                        strVal.Append(' ');
                        strVal.Append(value[index].ToString("X2"));
                        index += formatBytes;
                    }
                    strVal.Remove(0, 1);
                }
                else if (fFormat == FPlcWordFormat.Boolean)
                {
                    for (int i = 0; i < length; i++)
                    {
                        strVal.Append(' ');
                        strVal.Append(FByteConverter.toBoolean(value[index]));
                        index += formatBytes;
                    }
                    strVal.Remove(0, 1);
                }
                else if (fFormat == FPlcWordFormat.Ascii)
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
                        else if (value[index] <= 0x1F || value[index] >= 0x7F)
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
                else if (fFormat == FPlcWordFormat.I8)
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
                else if (fFormat == FPlcWordFormat.I4)
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
                else if (fFormat == FPlcWordFormat.I2)
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
                else if (fFormat == FPlcWordFormat.I1)
                {
                    for (int i = 0; i < length; i++)
                    {
                        strVal.Append(' ');
                        strVal.Append(value[index]);
                        index += formatBytes;
                    }
                    strVal.Remove(0, 1);
                }
                else if (fFormat == FPlcWordFormat.F8)
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
                else if (fFormat == FPlcWordFormat.F4)
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
                else if (fFormat == FPlcWordFormat.U8)
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
                else if (fFormat == FPlcWordFormat.U4)
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
                else if (fFormat == FPlcWordFormat.U2)
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
                else if (fFormat == FPlcWordFormat.U1)
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

        public static byte[] toWordBinValue(
            FPlcWordFormat fFormat, 
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

                if (fFormat != FPlcWordFormat.Ascii)
                {
                    arrVal = value.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                }

                byteVal = new List<byte>();

                // --

                if (fFormat == FPlcWordFormat.Binary)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.Add(byte.Parse(s, System.Globalization.NumberStyles.HexNumber));
                    }
                }
                else if (fFormat == FPlcWordFormat.Boolean)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.AddRange(FByteConverter.getBytes(FBoolean.toBool(s),  false));
                    }
                }
                else if (fFormat == FPlcWordFormat.Ascii)
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
                else if (fFormat == FPlcWordFormat.I8)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.AddRange(FByteConverter.getBytes(Convert.ToInt64(s), false));
                    }
                }
                else if (fFormat == FPlcWordFormat.I4)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.AddRange(FByteConverter.getBytes(Convert.ToInt32(s), false));
                    }
                }
                else if (fFormat == FPlcWordFormat.I2)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.AddRange(FByteConverter.getBytes(Convert.ToInt16(s), false));
                    }
                }
                else if (fFormat == FPlcWordFormat.I1)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.Add((byte)sbyte.Parse(s));
                    }
                }
                else if (fFormat == FPlcWordFormat.F8)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.AddRange(FByteConverter.getBytes(Convert.ToDouble(s), false));
                    }
                }
                else if (fFormat == FPlcWordFormat.F4)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.AddRange(FByteConverter.getBytes(Convert.ToSingle(s), false));
                    }
                }
                else if (fFormat == FPlcWordFormat.U8)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.AddRange(FByteConverter.getBytes(Convert.ToUInt64(s), false));
                    }
                }
                else if (fFormat == FPlcWordFormat.U4)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.AddRange(FByteConverter.getBytes(Convert.ToUInt32(s), false));
                    }
                }
                else if (fFormat == FPlcWordFormat.U2)
                {
                    foreach (string s in arrVal)
                    {
                        byteVal.AddRange(FByteConverter.getBytes(Convert.ToUInt16(s), false));
                    }
                }
                else if (fFormat == FPlcWordFormat.U1)
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

        public static int getPlcWordFormatBytes(
            FPlcWordFormat fFormat
            )
        {
            try
            {
                if (fFormat == FPlcWordFormat.Binary)
                {
                    return 1;
                }
                else if (fFormat == FPlcWordFormat.Boolean)
                {
                    return 1;
                }
                else if (fFormat == FPlcWordFormat.Ascii)
                {
                    return 1;
                }
                else if (fFormat == FPlcWordFormat.I8)
                {
                    return 8;
                }
                else if (fFormat == FPlcWordFormat.I4)
                {
                    return 4;
                }
                else if (fFormat == FPlcWordFormat.I2)
                {
                    return 2;
                }
                else if (fFormat == FPlcWordFormat.I1)
                {
                    return 1;
                }
                else if (fFormat == FPlcWordFormat.F8)
                {
                    return 8;
                }
                else if (fFormat == FPlcWordFormat.F4)
                {
                    return 4;
                }
                else if (fFormat == FPlcWordFormat.U8)
                {
                    return 8;
                }
                else if (fFormat == FPlcWordFormat.U4)
                {
                    return 4;
                }
                else if (fFormat == FPlcWordFormat.U2)
                {
                    return 2;
                }
                else if (fFormat == FPlcWordFormat.U1)
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
