/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSmlConverter.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.14
--  Description     : FAmate Converter FaSecs1ToHsms SML Converter Class
--  History         : Created by spike.lee at 2017.04.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    internal static class FSecsConverter
    {

        //------------------------------------------------------------------------------------------------------------------------

        public static string convertBinToSml(
            byte[] binData
            )
        {
            StringBuilder smlData = null;
            UInt32 pos = 0;

            try
            { 
                smlData = new StringBuilder();
                smlData.AppendLine("--");
                convertBinToSml(binData, ref pos, smlData, 0);
                smlData.Append(".");
                return smlData.ToString();
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

        public static void convertBinToSml(
            byte[] binData, 
            ref UInt32 pos, 
            StringBuilder smlData,
            int depth
            )
        {
            FFormat fFormat;
            int lenBytes = 0;
            UInt32 len = 0;
            byte tmpByte = 0;
            byte[] byteArr = null;
            string depthStr = string.Empty;
            UInt32 formatBytes = 0;
            UInt32 itemLen = 0;
            string val = string.Empty;

            try
            {
                if (depth > 0)
                {
                    depthStr = depthStr.PadRight(depth * 2, ' ');
                    smlData.AppendLine();
                }
                depth++;

                // --

                // ***
                // Format parse
                // ***
                tmpByte = binData[pos++];
                fFormat = getFormat(tmpByte >> 2);
                lenBytes = tmpByte & 0x03;

                // --

                // ***
                // Length parse
                // ***
                byteArr = new byte[4];
                if (lenBytes == 1)
                {
                    byteArr[0] = binData[pos++];
                }
                else if (lenBytes == 2)
                {
                    byteArr[0] = binData[pos++];
                    byteArr[1] = binData[pos++];
                }
                else
                {
                    byteArr[0] = binData[pos++];
                    byteArr[1] = binData[pos++];
                    byteArr[2] = binData[pos++];
                }
                len = FByteConverter.toUInt32(byteArr, false);

                // -

                smlData.Append(depthStr + "<" + fFormat.ToString());
                if (fFormat == FFormat.L)
                {
                    if (len > 1)
                    {
                        smlData.Append("[" + len + "]");
                    }
                    // --
                    for (int i = 0; i < len; i++)
                    {
                        convertBinToSml(binData, ref pos, smlData, depth);
                    }
                    // --
                    if (len > 0)
                    {
                        smlData.AppendLine();
                        smlData.Append(depthStr + ">");
                    }
                    else
                    {
                        smlData.Append(">");
                    }                    
                }
                else
                {
                    formatBytes = getFormatBytes(fFormat);
                    itemLen = len / formatBytes;
                    if (itemLen > 1)
                    {
                        smlData.Append("[" + itemLen.ToString() + "] ");
                    }
                    // --
                    if (itemLen > 0)
                    {
                        smlData.Append(" ");
                    }
                    val = getBinToValue(fFormat, binData, pos, itemLen, formatBytes);
                    pos += len;

                    // --

                    if (fFormat == FFormat.A || fFormat == FFormat.A2 || fFormat == FFormat.J8)
                    {
                        if (len > 0)
                        {
                            smlData.Append("'" + val + "'");
                        }
                    }
                    else
                    {
                        smlData.Append(val);
                    }
                    smlData.Append(">");
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

        public static FXmlNode convertBinToXmlNode(
            UInt16 sessionId,
            byte stream, 
            byte function, 
            bool wbit, 
            UInt32 systemBytes,
            byte[] binData
            )
        {
            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlNodeSmg = null;
            UInt32 pos = 0;

            try
            {
                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;

                // --

                // ***
                // Header
                // ***
                fXmlNodeSmg = fXmlDoc.createNode(FSecsTag.E_SecsMessage);
                fXmlNodeSmg.set_attrVal(FSecsTag.A_SessionId, sessionId.ToString());
                fXmlNodeSmg.set_attrVal(FSecsTag.A_Stream, stream.ToString());
                fXmlNodeSmg.set_attrVal(FSecsTag.A_Function, function.ToString());
                fXmlNodeSmg.set_attrVal(FSecsTag.A_WBit, wbit.ToString());
                fXmlNodeSmg.set_attrVal(FSecsTag.A_SystemBytes, systemBytes.ToString());

                // --

                // ***
                // Body
                // ***
                if (binData.Length > 0)
                {
                    convertBinToXmlNode(fXmlDoc, fXmlNodeSmg, binData, ref pos);
                }

                // --

                return fXmlNodeSmg;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlDoc = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void convertBinToXmlNode(
            FXmlDocument fXmlDoc,
            FXmlNode fXmlNodeParent,
            Byte[] binData,
            ref UInt32 pos
            )
        {
            FFormat fFormat;
            int lenBytes = 0;
            UInt32 len = 0;
            byte tmpByte = 0;
            byte[] byteArr = null;
            string depthStr = string.Empty;
            UInt32 formatBytes = 0;
            UInt32 itemLen = 0;
            string val = string.Empty;
            FXmlNode fXmlNodeSit = null;

            try
            {
                fXmlNodeSit = fXmlDoc.createNode(FSecsTag.E_SecsItem);

                // --

                // ***
                // Format Parse
                // ***
                tmpByte = binData[pos++];
                fFormat = FSecsConverter.getFormat(tmpByte >> 2);
                lenBytes = tmpByte & 0x03;
                fXmlNodeSit.set_attrVal(FSecsTag.A_Format, fFormat.ToString());

                // --

                // ***
                // Length Parse
                // ***
                byteArr = new byte[4];
                if (lenBytes == 1)
                {
                    byteArr[0] = binData[pos++];
                }
                else if (lenBytes == 2)
                {
                    byteArr[0] = binData[pos++];
                    byteArr[1] = binData[pos++];
                }
                else
                {
                    byteArr[0] = binData[pos++];
                    byteArr[1] = binData[pos++];
                    byteArr[2] = binData[pos++];
                }
                len = FByteConverter.toUInt32(byteArr, false);
                formatBytes = getFormatBytes(fFormat);
                itemLen = len / formatBytes;
                fXmlNodeSit.set_attrVal(FSecsTag.A_Length, itemLen.ToString());

                // --

                if (fFormat == FFormat.L)
                {
                    for (int i = 0; i < itemLen; i++)
                    {
                        convertBinToXmlNode(fXmlDoc, fXmlNodeSit, binData, ref pos);
                    }                    
                }
                else
                {
                    val = getBinToValue(fFormat, binData, pos, itemLen, formatBytes);
                    pos += len;
                    fXmlNodeSit.set_attrVal(FSecsTag.A_Value, val);
                }

                // --

                fXmlNodeParent.appendChild(fXmlNodeSit);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeSit = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FSecsDataMessage convertXmlToSecsDataMessage(
            FSecs1ToHsms fSecs1ToHsms,
            FXmlNode fXmlNodeSmg
            )
        {
            UInt16 sessionId = 0;
            byte stream = 0;
            byte function = 0;
            bool wbit = false;
            UInt32 systemBytes = 0;
            string val = string.Empty;
            List<byte> binData = null;

            try
            {
                sessionId = UInt16.Parse(fXmlNodeSmg.get_attrVal(FSecsTag.A_SessionId, "0"));
                stream = byte.Parse(fXmlNodeSmg.get_attrVal(FSecsTag.A_Stream, "0"));
                function = byte.Parse(fXmlNodeSmg.get_attrVal(FSecsTag.A_Function, "0"));
                wbit = bool.Parse(fXmlNodeSmg.get_attrVal(FSecsTag.A_WBit, "false"));
                // --
                val = fXmlNodeSmg.get_attrVal(FSecsTag.A_SystemBytes, string.Empty);
                if (val != string.Empty)
                {
                    systemBytes = UInt32.Parse(val);
                }

                // --

                binData = new List<byte>();
                if (fXmlNodeSmg.hasChildNode)
                {
                    convertXmlToSecsItem(fXmlNodeSmg.selectSingleNode(FSecsTag.E_SecsItem), binData);
                }

                // --

                return new FSecsDataMessage(fSecs1ToHsms, sessionId, wbit, stream, function, systemBytes, binData.ToArray());
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

        public static void convertXmlToSecsItem(
            FXmlNode fXmlNodeSit, 
            List<byte> binData
            )
        {
            FFormat fFormat;
            byte formatCode = 0;
            UInt32 formatBytes = 0;            
            UInt32 len = 0;
            byte lenBytes = 0;
            UInt32 itemLen = 0;
            byte[] lenArr = null;
            byte[] byteArr = null;
            byte[] valArr = null;
            FXmlNodeList fXmlNodeChilds = null;            

            try
            {
                fFormat = (FFormat)Enum.Parse(typeof(FFormat), fXmlNodeSit.get_attrVal(FSecsTag.A_Format));
                formatCode = (byte)((int)fFormat << 2);
                formatBytes = getFormatBytes(fFormat);

                // --

                if (fFormat == FFormat.L)
                {
                    fXmlNodeChilds = fXmlNodeSit.selectNodes(FSecsTag.E_SecsItem);
                    len = (UInt32)fXmlNodeChilds.count;
                    lenBytes = getLengthBytes(len);
                    // --
                    if (lenBytes == 1)
                    {
                        formatCode |= 0x01;
                        lenArr = new byte[1] { (byte)len };
                    }
                    else if (lenBytes == 2)
                    {
                        formatCode |= 0x02;
                        lenArr = FByteConverter.getBytes((UInt16)len, true);
                    }
                    else
                    {
                        formatCode |= 0x03;
                        byteArr = FByteConverter.getBytes((UInt32)len, true);
                        lenArr = new byte[3];
                        lenArr[0] = byteArr[1];
                        lenArr[1] = byteArr[2];
                        lenArr[2] = byteArr[3];
                    }
                    // --
                    binData.Add(formatCode);
                    binData.AddRange(lenArr);
                    // --
                    foreach (FXmlNode c in fXmlNodeChilds)
                    {
                        convertXmlToSecsItem(c, binData);
                    }
                }
                else
                {
                    valArr = getStringToBinValue(fFormat, fXmlNodeSit.get_attrVal(FSecsTag.A_Value, string.Empty), ref itemLen);
                    len = itemLen * formatBytes;
                    lenBytes = getLengthBytes(len);
                    // --
                    if (lenBytes == 1)
                    {
                        formatCode |= 0x01;
                        lenArr = new byte[1] { (byte)len };
                    }
                    else if (lenBytes == 2)
                    {
                        formatCode |= 0x02;
                        lenArr = FByteConverter.getBytes((UInt16)len, true);
                    }
                    else
                    {
                        formatCode |= 0x03;
                        byteArr = FByteConverter.getBytes((UInt32)len, true);
                        lenArr = new byte[3];
                        lenArr[0] = byteArr[1];
                        lenArr[1] = byteArr[2];
                        lenArr[2] = byteArr[3];
                    }
                    // --
                    binData.Add(formatCode);
                    binData.AddRange(lenArr);
                    // --
                    if (valArr != null)
                    {
                        binData.AddRange(valArr);
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

        public static FFormat getFormat(
            int value
            )
        {
            try
            {
                if (value == 0)
                {
                    return FFormat.L;
                }
                else if (value == 8)
                {
                    return FFormat.B;
                }
                else if (value == 9)
                {
                    return FFormat.BL;
                }
                else if (value == 16)
                {
                    return FFormat.A;
                }
                else if (value == 17)
                {
                    return FFormat.J8;
                }
                else if (value == 18)
                {
                    return FFormat.A2;
                }
                else if (value == 24)
                {
                    return FFormat.I8;
                }
                else if (value == 28)
                {
                    return FFormat.I4;
                }
                else if (value == 26)
                {
                    return FFormat.I2;
                }
                else if (value == 25)
                {
                    return FFormat.I1;
                }
                else if (value == 32)
                {
                    return FFormat.F8;
                }
                else if (value == 36)
                {
                    return FFormat.F4;
                }
                else if (value == 40)
                {
                    return FFormat.U8;
                }
                else if (value == 44)
                {
                    return FFormat.U4;
                }
                else if (value == 42)
                {
                    return FFormat.U2;
                }
                else if (value == 41)
                {
                    return FFormat.U1;
                }
                return FFormat.A;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FFormat.A;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static UInt32 getFormatBytes(
            FFormat fFormat
            )
        {
            try
            {
                if (fFormat == FFormat.L)
                {
                    return 1;
                }
                else if (fFormat == FFormat.B)
                {
                    return 1;
                }
                else if (fFormat == FFormat.BL)
                {
                    return 1;
                }
                else if (fFormat == FFormat.A || fFormat == FFormat.J8 || fFormat == FFormat.A2)
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

        public static byte getLengthBytes(
            UInt32 length
            )
        {
            try
            {
                if (length <= 0xFF)
                {
                    return 1;
                }
                else if (length <= 0xFFFF)
                {
                    return 2;
                }
                return 3;
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

        public static string getBinToValue(
            FFormat fFormat,
            byte[] value,
            UInt32 index,
            UInt32 length,
            UInt32 formatBytes
            )
        {
            StringBuilder returnValue = null;
            byte[] byteArr = null;

            try
            {
                if (length == 0)
                {
                    return string.Empty;
                }

                // --

                returnValue = new StringBuilder();

                // --

                if (fFormat == FFormat.B)
                {
                    for (int i = 0; i < length; i++)
                    {
                        returnValue.Append(' ');
                        returnValue.Append(value[index].ToString("X2"));
                        index += formatBytes;
                    }
                    returnValue.Remove(0, 1);
                }
                else if (fFormat == FFormat.BL)
                {
                    for (int i = 0; i < length; i++)
                    {
                        returnValue.Append(' ');
                        returnValue.Append(FByteConverter.toBoolean(value[index]));
                        index += formatBytes;
                    }
                    returnValue.Remove(0, 1);
                }
                else if (fFormat == FFormat.A || fFormat == FFormat.A2)
                {
                    returnValue.Append(Encoding.Default.GetString(value, (int)index, (int)length));
                }
                else if (fFormat == FFormat.I8)
                {
                    for (int i = 0; i < length; i++)
                    {
                        byteArr = new byte[formatBytes];
                        for (int j = 0; j < formatBytes; j++)
                        {
                            byteArr[j] = value[index + j];
                        }

                        // --

                        returnValue.Append(' ');
                        returnValue.Append(FByteConverter.toInt64(byteArr, true));
                        index += formatBytes;
                    }
                    returnValue.Remove(0, 1);
                }
                else if (fFormat == FFormat.I4)
                {
                    for (int i = 0; i < length; i++)
                    {
                        byteArr = new byte[formatBytes];
                        for (int j = 0; j < formatBytes; j++)
                        {
                            byteArr[j] = value[index + j];
                        }

                        // --

                        returnValue.Append(' ');
                        returnValue.Append(FByteConverter.toInt32(byteArr, true));
                        index += formatBytes;
                    }
                    returnValue.Remove(0, 1);
                }
                else if (fFormat == FFormat.I2)
                {
                    for (int i = 0; i < length; i++)
                    {
                        byteArr = new byte[formatBytes];
                        for (int j = 0; j < formatBytes; j++)
                        {
                            byteArr[j] = value[index + j];
                        }

                        // --

                        returnValue.Append(' ');
                        returnValue.Append(FByteConverter.toInt16(byteArr, true));
                        index += formatBytes;
                    }
                    returnValue.Remove(0, 1);
                }
                else if (fFormat == FFormat.I1)
                {
                    for (int i = 0; i < length; i++)
                    {
                        returnValue.Append(' ');
                        returnValue.Append(value[index]);
                        index += formatBytes;
                    }
                    returnValue.Remove(0, 1);
                }
                else if (fFormat == FFormat.F8)
                {
                    for (int i = 0; i < length; i++)
                    {
                        byteArr = new byte[formatBytes];
                        for (int j = 0; j < formatBytes; j++)
                        {
                            byteArr[j] = value[index + j];
                        }

                        // --

                        returnValue.Append(' ');
                        returnValue.Append(FByteConverter.toFloat8(byteArr, true));
                        index += formatBytes;
                    }
                    returnValue.Remove(0, 1);
                }
                else if (fFormat == FFormat.F4)
                {
                    for (int i = 0; i < length; i++)
                    {
                        byteArr = new byte[formatBytes];
                        for (int j = 0; j < formatBytes; j++)
                        {
                            byteArr[j] = value[index + j];
                        }

                        // --

                        returnValue.Append(' ');
                        returnValue.Append(FByteConverter.toFloat4(byteArr, true));
                        index += formatBytes;
                    }
                    returnValue.Remove(0, 1);
                }
                else if (fFormat == FFormat.U8)
                {
                    for (int i = 0; i < length; i++)
                    {
                        byteArr = new byte[formatBytes];
                        for (int j = 0; j < formatBytes; j++)
                        {
                            byteArr[j] = value[index + j];
                        }

                        // -- 

                        returnValue.Append(' ');
                        returnValue.Append(FByteConverter.toUInt64(byteArr, true));
                        index += formatBytes;
                    }
                    returnValue.Remove(0, 1);
                }
                else if (fFormat == FFormat.U4)
                {
                    for (int i = 0; i < length; i++)
                    {
                        byteArr = new byte[formatBytes];
                        for (int j = 0; j < formatBytes; j++)
                        {
                            byteArr[j] = value[index + j];
                        }

                        // -- 

                        returnValue.Append(' ');
                        returnValue.Append(FByteConverter.toUInt32(byteArr, true));
                        index += formatBytes;
                    }
                    returnValue.Remove(0, 1);
                }
                else if (fFormat == FFormat.U2)
                {
                    for (int i = 0; i < length; i++)
                    {
                        byteArr = new byte[formatBytes];
                        for (int j = 0; j < formatBytes; j++)
                        {
                            byteArr[j] = value[index + j];
                        }

                        // -- 

                        returnValue.Append(' ');
                        returnValue.Append(FByteConverter.toUInt16(byteArr, true));
                        index += formatBytes;
                    }
                    returnValue.Remove(0, 1);
                }
                else if (fFormat == FFormat.U1)
                {
                    for (int i = 0; i < length; i++)
                    {
                        returnValue.Append(' ');
                        returnValue.Append(value[index]);
                        index += formatBytes;
                    }
                    returnValue.Remove(0, 1);
                }
                else if (fFormat == FFormat.J8)
                {
                    for (int i = 0; i < length; i++)
                    {
                        if (value[index] == 0x5C)
                        {
                            returnValue.Append(@"¥");
                        }
                        else if (value[index] == 0x7E)
                        {
                            returnValue.Append(@"‾");
                        }
                        else
                        {
                            returnValue.Append((char)value[index]);
                        }
                        index += formatBytes;
                    }
                }
                return returnValue.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                returnValue = null;
                byteArr = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static byte[] getStringToBinValue(
            FFormat fFormat, 
            string value, 
            ref UInt32 length
            )
        {
            string[] arrVal = null;
            List<byte> binValue = null;

            try
            {
                if (value == string.Empty)
                {
                    length = 0;
                    return null;
                }

                // --

                binValue = new List<byte>();

                if (fFormat != FFormat.A && fFormat != FFormat.A2)
                {
                    arrVal = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                }

                // --

                if (fFormat == FFormat.L)
                {
                    length = 0;
                    return null;
                }
                else if (fFormat == FFormat.B)
                {                    
                    length = (UInt32)arrVal.Length;
                    foreach (string v in arrVal)
                    {
                        binValue.Add(byte.Parse(v, System.Globalization.NumberStyles.HexNumber));
                    }
                }
                else if (fFormat == FFormat.BL)
                {
                    length = (UInt32)arrVal.Length;
                    foreach (string v in arrVal)
                    {
                        if (v.ToUpper() == "TRUE")
                        {
                            binValue.Add(0x01);
                        }
                        else
                        {
                            binValue.Add(0x00);
                        }
                    }
                }
                else if (fFormat == FFormat.A || fFormat == FFormat.A2)
                {
                    length = (UInt32)Encoding.Default.GetByteCount(value);
                    binValue.AddRange(Encoding.Default.GetBytes(value));
                }
                else if (fFormat == FFormat.I8)
                {
                    length = (UInt32)arrVal.Length;
                    foreach (string v in arrVal)
                    {
                        binValue.AddRange(FByteConverter.getBytes(Convert.ToInt64(v), true));
                    }
                }
                else if (fFormat == FFormat.I4)
                {
                    length = (UInt32)arrVal.Length;
                    foreach (string v in arrVal)
                    {
                        binValue.AddRange(FByteConverter.getBytes(Convert.ToInt32(v), true));
                    }
                }
                else if (fFormat == FFormat.I2)
                {
                    length = (UInt32)arrVal.Length;
                    foreach (string v in arrVal)
                    {
                        binValue.AddRange(FByteConverter.getBytes(Convert.ToInt16(v), true));
                    }
                }
                else if (fFormat == FFormat.I1)
                {
                    length = (UInt32)arrVal.Length;
                    foreach (string v in arrVal)
                    {
                        binValue.Add((byte)sbyte.Parse(v));
                    }
                }
                else if (fFormat == FFormat.U8)
                {
                    length = (UInt32)arrVal.Length;
                    foreach (string v in arrVal)
                    {
                        binValue.AddRange(FByteConverter.getBytes(Convert.ToUInt64(v), true));
                    }
                }
                else if (fFormat == FFormat.U4)
                {
                    length = (UInt32)arrVal.Length;
                    foreach (string v in arrVal)
                    {
                        binValue.AddRange(FByteConverter.getBytes(Convert.ToUInt32(v), true));
                    }
                }
                else if (fFormat == FFormat.U2)
                {
                    length = (UInt32)arrVal.Length;
                    foreach (string v in arrVal)
                    {
                        binValue.AddRange(FByteConverter.getBytes(Convert.ToUInt16(v), true));
                    }
                }
                else if (fFormat == FFormat.U1)
                {
                    length = (UInt32)arrVal.Length;
                    foreach (string v in arrVal)
                    {
                        binValue.Add(byte.Parse(v));
                    }
                }
                else if (fFormat == FFormat.F8)
                {
                    length = (UInt32)arrVal.Length;
                    foreach (string v in arrVal)
                    {
                        binValue.AddRange(FByteConverter.getBytes(Convert.ToDouble(v), true));
                    }
                }
                else if (fFormat == FFormat.F4)
                {
                    length = (UInt32)arrVal.Length;
                    foreach (string v in arrVal)
                    {
                        binValue.AddRange(FByteConverter.getBytes(Convert.ToSingle(v), true));
                    }
                }

                // --

                return binValue.ToArray();
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

    }   // Class end
}   // Namespace end
