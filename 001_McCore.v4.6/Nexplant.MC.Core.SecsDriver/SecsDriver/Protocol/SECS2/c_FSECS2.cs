/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSECS2.cs
--  Creator         : kitae
--  Create Date     : 2011.09.09
--  Description     : FAMate Core FaSecsDriver SECS2 Parser Class
--  History         : Created by kitae at 2011.09.09
                    : Modify by spike.lee at 2011.10.06
                        - Binary to SECS Data Message (FIObject) Parse 추가
                        - Binary to SECS Data Message (FIObject) Generate 추가
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal static class FSECS2
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private static void setSecsMessageLogInfo(
            FXmlNode fXmlNodeSmgl,
            FXmlNode fXmlNodeSdv, 
            FXmlNode fXmlNodeSsn, 
            int sessionId,             
            bool wbit, 
            UInt32 systemBytes, 
            UInt32 length
            )
        {
            try
            {
                if (fXmlNodeSdv != null)
                {
                    fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_SecsDeviceId, FXmlTagSMGL.D_SecsDeviceId, fXmlNodeSdv.get_attrVal(FXmlTagSDV.A_UniqueId, FXmlTagSDV.D_UniqueId));
                    fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_SecsDeviceName, FXmlTagSMGL.D_SecsDeviceName, fXmlNodeSdv.get_attrVal(FXmlTagSDV.A_Name, FXmlTagSDV.D_Name));
                }
                // --
                if (fXmlNodeSsn != null)
                {
                    fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_SecsSessionId, FXmlTagSMGL.D_SecsSessionId, fXmlNodeSsn.get_attrVal(FXmlTagSSN.A_UniqueId, FXmlTagSSN.D_UniqueId));
                    fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_SecsSessionName, FXmlTagSMGL.D_SecsSessionName, fXmlNodeSsn.get_attrVal(FXmlTagSSN.A_Name, FXmlTagSSN.D_Name));
                }
                // --
                fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_SessionId, FXmlTagSMGL.D_SessionId, sessionId.ToString());
                fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_WBit, FXmlTagSMGL.D_WBit, FBoolean.fromBool(wbit));
                fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_SystemBytes, FXmlTagSMGL.D_SystemBytes, systemBytes.ToString());
                fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_Length, FXmlTagSMGL.D_Length, length.ToString());
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

        private static void setSecsMessageLogInfo(
            FXmlNode fXmlNodeSmgl,
            FXmlNode fXmlNodeSdv,
            FXmlNode fXmlNodeSsn,
            int sessionId,
            int stream,
            int function,
            int version,
            bool wbit,
            UInt32 systemBytes,
            UInt32 length
            )
        {
            try
            {
                setSecsMessageLogInfo(fXmlNodeSmgl, fXmlNodeSdv, fXmlNodeSsn, sessionId, wbit, systemBytes, length);
                // --
                fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_UniqueId, FXmlTagSMGL.D_UniqueId, "0");
                fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_Stream, FXmlTagSMGL.D_Stream, stream.ToString());
                fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_Function, FXmlTagSMGL.D_Function, function.ToString());
                fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_Version, FXmlTagSMGL.D_Version, version.ToString());
                fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_AutoReply, FXmlTagSMGL.D_AutoReply, FBoolean.False);
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

        private static void setSecsMessageLogInfo(
            FXmlNode fXmlNodeSmgl,
            FXmlNode fXmlNodeSdv,
            FXmlNode fXmlNodeSsn,
            int sessionId,            
            UInt32 systemBytes,
            UInt32 length
            )
        {
            try
            {
                if (fXmlNodeSdv != null)
                {
                    fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_SecsDeviceId, FXmlTagSMGL.D_SecsDeviceId, fXmlNodeSdv.get_attrVal(FXmlTagSDV.A_UniqueId, FXmlTagSDV.D_UniqueId));
                    fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_SecsDeviceName, FXmlTagSMGL.D_SecsDeviceName, fXmlNodeSdv.get_attrVal(FXmlTagSDV.A_Name, FXmlTagSDV.D_Name));
                }
                // --
                if (fXmlNodeSsn != null)
                {
                    fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_SecsSessionId, FXmlTagSMGL.D_SecsSessionId, fXmlNodeSsn.get_attrVal(FXmlTagSSN.A_UniqueId, FXmlTagSSN.D_UniqueId));
                    fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_SecsSessionName, FXmlTagSMGL.D_SecsSessionName, fXmlNodeSsn.get_attrVal(FXmlTagSSN.A_Name, FXmlTagSSN.D_Name));
                }
                // --
                fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_SessionId, FXmlTagSMGL.D_SessionId, sessionId.ToString());                
                fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_SystemBytes, FXmlTagSMGL.D_SystemBytes, systemBytes.ToString());
                fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_Length, FXmlTagSMGL.D_Length, length.ToString());
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

        private static bool parseBinFormatLength(
           byte[] body,
           UInt32 bodyLength,
           ref UInt32 index,
           ref FFormat fFormat,
           ref FSecsLengthBytes fLengthBytes,
           ref UInt32 length,
           ref UInt32 formatBytes
           )
        {
            UInt32 lenBytes = 0;

            try
            {
                return parseBinFormatLength(body, bodyLength, ref index, ref fFormat, ref fLengthBytes, ref length, ref formatBytes, ref lenBytes);
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

        private static bool parseBinFormatLength(
            byte[] body,
            UInt32 bodyLength,
            ref UInt32 index,
            ref FFormat fFormat, 
            ref FSecsLengthBytes fLengthBytes, 
            ref UInt32 length,
            ref UInt32 formatBytes,
            ref UInt32 lenBytes
            )
        {
            byte[] lenArr = null;

            try
            {
                if (index >= bodyLength)
                {
                    return false;
                }

                // --

                fFormat = FEnumConverter.toFormat(body[index] >> 2);
                if (fFormat == FFormat.Unknown)
                {
                    return false;
                }
                lenBytes = (UInt32)(body[index] & 0x03);
                index++;   

                // -- 

                if (lenBytes == 0 || index + lenBytes - 1 >= bodyLength)
                {
                    return false;
                }

                // --

                // ***
                // Length Parsing
                // ***
                lenArr = new byte[4];
                if (lenBytes == 1)
                {
                    lenArr[0] = body[index];
                    fLengthBytes = FSecsLengthBytes.Byte1;
                }
                else if (lenBytes == 2)
                {
                    lenArr[0] = body[index + 1];
                    lenArr[1] = body[index];
                    fLengthBytes = FSecsLengthBytes.Byte2;
                }
                else
                {
                    lenArr[0] = body[index + 2];
                    lenArr[1] = body[index + 1];
                    lenArr[2] = body[index];
                    fLengthBytes = FSecsLengthBytes.Byte3;
                }
                length = FByteConverter.toUInt32(lenArr, false);
                index += (UInt32)lenBytes;

                // --

                formatBytes = FValueConverter.getFormatBytes(fFormat);
                if (length % formatBytes != 0)
                {
                    return false;
                }

                // --

                if (fFormat != FFormat.List)
                {
                    if (index + length - 1 >= bodyLength)
                    {
                        return false;
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
                lenArr = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode parseBinToSmg(
            FSecsDriver fScd,
            FSecsDevice fSdv,
            int sessionId,
            int stream,
            int function,
            bool wbit,
            UInt32 systemBytes,
            byte[] body,
            UInt32 length,
            ref FResultCode fResultCode,
            ref string resultMessage,
            ref FXmlNode fXmlNodeSsn,
            ref FXmlNode fXmlNodeSmg
            )
        {
            const string SecsSessionQuery = FXmlTagSSN.E_SecsSession + "[@" + FXmlTagSSN.A_SessionId + "='{0}']";
            // --
            const string SecsMessageQuery =
                FXmlTagSLM.E_SecsLibraryModeling +
                "/" + FXmlTagSLG.E_SecsLibraryGroup +
                "/" + FXmlTagSLB.E_SecsLibrary + "[@" + FXmlTagSLB.A_UniqueId + "='{0}']" +
                "/" + FXmlTagSML.E_SecsMessageList +
                "/" + FXmlTagSMS.E_SecsMessages + "[@" + FXmlTagSMS.A_Direction + "='{1}' or @" + FXmlTagSMS.A_Direction + "='{2}' or @" + FXmlTagSMS.A_Direction + "='{3}']" +
                "/" + FXmlTagSMG.E_SecsMessage + "[@" + FXmlTagSMG.A_Stream + "='{4}' and @" + FXmlTagSMG.A_Function + "='{5}']";

            // --

            FXmlNodeList fXmlNodeListSmg = null;
            FXmlNode fXmlNodeSmgl = null;
            FXmlNode fXmlNodeSitl = null;
            FFormat fFormat;
            UInt32 index = 0;
            string direction1 = string.Empty;
            string direction2 = string.Empty;
            string direction3 = string.Empty;
            string xpath = string.Empty;

            try
            {
                // ***
                // SECS Session 검색
                // ***
                if (fXmlNodeSsn == null)
                {
                    fXmlNodeSsn = fSdv.fXmlNode.selectSingleNode(
                        string.Format(SecsSessionQuery, sessionId.ToString())
                        );
                }

                // --
                
                if (fXmlNodeSsn == null)
                {
                    // ***
                    // Not Define Session 
                    // ***
                    fXmlNodeSmgl = FSecsDriverLogCommon.createXmlNodeSMGL(fScd.fScdCore.fXmlDoc);
                    setSecsMessageLogInfo(fXmlNodeSmgl, fSdv.fXmlNode, fXmlNodeSsn, sessionId, stream, function, 0, wbit, systemBytes, length);
                    fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_Name, FXmlTagSMGL.D_Name, "Undefined");
                    // --
                    if (!generateBinToSmg(fScd.fScdCore.fXmlDoc, fXmlNodeSmgl, body))
                    {
                        fResultCode = FResultCode.Error;
                        resultMessage = string.Format(FConstants.err_m_0015, "Message Structure");
                    }
                    else
                    {
                        fResultCode = FResultCode.Warninig;
                        resultMessage = string.Format(FConstants.err_m_0028, "Session");
                    }
                    // --
                    return fXmlNodeSmgl;                    
                }

                // --

                // ***
                // SECS Message 검색
                // ***
                if (fXmlNodeSmg == null)
                {
                    direction1 = FEnumConverter.fromDirection(FDirection.Both);                    
                    if (function == 0 || function % 2 == 1)
                    {
                        // ***
                        // Primary SECS Message
                        // ***                       
                        if (fSdv.fDeviceMode == FDeviceMode.Equipment)
                        {
                            direction2 = FEnumConverter.fromDirection(FDirection.Host);
                            direction3 = FEnumConverter.fromDirection(FDirection.Host);
                        }
                        else if (fSdv.fDeviceMode == FDeviceMode.Host)
                        {
                            direction2 = FEnumConverter.fromDirection(FDirection.Equipment);
                            direction3 = FEnumConverter.fromDirection(FDirection.Equipment);
                        }
                        else
                        {
                            direction2 = FEnumConverter.fromDirection(FDirection.Host);
                            direction3 = FEnumConverter.fromDirection(FDirection.Equipment);
                        }
                    }
                    else
                    {
                        // ***
                        // Secondary SECS Message
                        // ***
                        if (fSdv.fDeviceMode == FDeviceMode.Equipment)
                        {
                            direction2 = FEnumConverter.fromDirection(FDirection.Equipment);
                            direction3 = FEnumConverter.fromDirection(FDirection.Equipment);
                        }
                        else if (fSdv.fDeviceMode == FDeviceMode.Host)
                        {
                            direction2 = FEnumConverter.fromDirection(FDirection.Host);
                            direction3 = FEnumConverter.fromDirection(FDirection.Host);
                        }
                        else
                        {
                            direction2 = FEnumConverter.fromDirection(FDirection.Host);
                            direction3 = FEnumConverter.fromDirection(FDirection.Equipment);
                        }
                    }                    

                    // --

                    xpath = string.Format(
                        SecsMessageQuery,
                        fXmlNodeSsn.get_attrVal(FXmlTagSSN.A_SecsLibraryId, FXmlTagSSN.D_SecsLibraryId),
                        direction1,
                        direction2,
                        direction3,
                        stream.ToString(),
                        function.ToString()
                        );
                    // --
                    fXmlNodeListSmg = fScd.fXmlNode.selectNodes(xpath);                        
                    // --
                    foreach (FXmlNode x in fXmlNodeListSmg)
                    {
                        if (compareBinWithSmg(x, body))
                        {
                            fXmlNodeSmgl = x.clone(true);
                            break;
                        }
                    }
                }
                else
                {
                    if (compareBinWithSmg(fXmlNodeSmg, body))
                    {
                        fXmlNodeSmgl = fXmlNodeSmg.clone(true);
                    }
                }                

                // --

                // ***
                // Not Define Message
                // ***
                if (fXmlNodeSmgl == null)
                {
                    fXmlNodeSmgl = FSecsDriverLogCommon.createXmlNodeSMGL(fScd.fScdCore.fXmlDoc);
                    setSecsMessageLogInfo(fXmlNodeSmgl, fSdv.fXmlNode, fXmlNodeSsn, sessionId, stream, function, 0, wbit, systemBytes, length);
                    fXmlNodeSmgl.set_attrVal(FXmlTagSMGL.A_Name, FXmlTagSMGL.D_Name, "Undefined");
                    // --
                    if (!generateBinToSmg(fScd.fScdCore.fXmlDoc, fXmlNodeSmgl, body))
                    {
                        fResultCode = FResultCode.Error;
                        resultMessage = string.Format(FConstants.err_m_0015, "Message Structure");
                    }
                    else
                    {
                        fResultCode = FResultCode.Warninig;
                        resultMessage = string.Format(FConstants.err_m_0028, "Message");
                    }
                    // --
                    return fXmlNodeSmgl;
                }

                // --

                setSecsMessageLogInfo(fXmlNodeSmgl, fSdv.fXmlNode, fXmlNodeSsn, sessionId, wbit, systemBytes, length);
                // --
                fXmlNodeSitl = fXmlNodeSmgl.selectSingleNode(FXmlTagSITL.E_SecsItem);
                if (fXmlNodeSitl != null)
                {
                    fFormat = FEnumConverter.toFormat(fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Format, FXmlTagSITL.D_Format));
                    parseBinToSit(fXmlNodeSitl, fFormat, body, (UInt32)body.LongLength, ref index);
                }

                // --

                fResultCode = FResultCode.Success;
                return fXmlNodeSmgl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListSmg = null;
                fXmlNodeSitl = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void parseBinToSit(
            FXmlNode fXmlNodeSitl,
            FFormat fSitFormat,
            byte[] body,         
            UInt32 length,
            ref UInt32 index
            )
        {
            FFormat fBinFormat = FFormat.Unknown;
            FSecsLengthBytes fLengthBytes = FSecsLengthBytes.Auto;
            UInt32 len = 0;
            UInt32 formatBytes = 0;
            UInt32 lenBytes = 0;
            int valLen = 0;
            UInt32 rawBytes = 0;                        
            FXmlNodeList fXmlNodeChildList = null;
            FXmlNode fXmlNodeChild = null;
            FXmlNode fXmlNodeTmp = null;
            int childCount = 0;
            int childIndex = 0;
            int listIndex = 0;
            FPattern fPattern;
            FFormat fFormat;
            int fixLen = 0;
            int varLen = 0;
            int varCnt = 0;
            string genName = string.Empty;            

            try
            {
                parseBinFormatLength(body, length, ref index, ref fBinFormat, ref fLengthBytes, ref len, ref formatBytes, ref lenBytes);
                valLen = (int)(len / formatBytes);

                // --                

                if (fSitFormat == FFormat.Raw)
                {
                    // ***
                    // Raw Format일 경우 Length만 사용 (length는 byte 길이 사용)
                    // ***
                    rawBytes = 1 + lenBytes;
                    if (fBinFormat == FFormat.List)
                    {
                        for (int i = 0; i < len; i++)
                        {
                            rawBytes += calculateBinToRawBytes(body, length, ref index);
                        }                        
                    }
                    else
                    {
                        rawBytes += len;
                        index += len;
                    }

                    // --

                    fLengthBytes = FValueConverter.getLengthBytes((int)rawBytes);
                    // --
                    fXmlNodeSitl.set_attrVal(FXmlTagSITL.A_LengthBytes, FXmlTagSITL.D_LengthBytes, FEnumConverter.fromSecsLengthBytes(fLengthBytes));
                    fXmlNodeSitl.set_attrVal(FXmlTagSITL.A_Length, FXmlTagSITL.D_Length, rawBytes.ToString());                    
                }
                else if (fSitFormat == FFormat.Unknown)
                {
                    if (fBinFormat == FFormat.List)
                    {
                        // ***
                        // 2017.03.23 by spike.lee
                        // Unknown Format Item 하위 Item이 동일 이름으로 생성되어 DataSet에서 원하는 구조로 Parsing 할 수 없어 이름을
                        // 다르게 생성하도록 처리
                        // ***
                        // genName = fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Name, FXmlTagSITL.D_Name) + "_";
                        genName = fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Name, FXmlTagSITL.D_Name) + "_n";
                        for (int i = 0; i < valLen; i++)
                        {
                            fXmlNodeChild = fXmlNodeSitl.clone(false);
                            // fXmlNodeChild.set_attrVal(FXmlTagSITL.A_Name, FXmlTagSIT.D_Name, genName + (i + 1).ToString());
                            fXmlNodeChild.set_attrVal(FXmlTagSITL.A_Name, FXmlTagSIT.D_Name, genName);
                            // --
                            parseBinToSit(fXmlNodeChild, fSitFormat, body, length, ref index);
                            fXmlNodeSitl.appendChild(fXmlNodeChild);
                        }
                    }
                    else
                    {
                        fXmlNodeSitl.set_attrVal(
                            FXmlTagSITL.A_Value, 
                            FXmlTagSITL.D_Value, 
                            FValueConverter.fromBinValue(fBinFormat, body, index, valLen, formatBytes)
                            );
                        index += len;
                    }

                    // --

                    fXmlNodeSitl.set_attrVal(FXmlTagSITL.A_Format, FXmlTagSITL.D_Format, FEnumConverter.fromFormat(fBinFormat));
                    fXmlNodeSitl.set_attrVal(FXmlTagSITL.A_LengthBytes, FXmlTagSITL.D_LengthBytes, FEnumConverter.fromSecsLengthBytes(fLengthBytes));
                    fXmlNodeSitl.set_attrVal(FXmlTagSITL.A_Length, FXmlTagSITL.D_Length, valLen.ToString());
                }                
                else if (fSitFormat == FFormat.List || fSitFormat == FFormat.AsciiList)
                {
                    fXmlNodeChildList = fXmlNodeSitl.selectNodes(FXmlTagSITL.E_SecsItem);
                    childCount = fXmlNodeChildList.count;
                    childIndex = 0;
                    listIndex = 0;

                    // --

                    while (childIndex < childCount)
                    {
                        fixLen = 0;
                        varLen = 0;
                        varCnt = 0;

                        // --

                        fXmlNodeChild = fXmlNodeChildList[childIndex];
                        fPattern = FEnumConverter.toPattern(fXmlNodeChild.get_attrVal(FXmlTagSITL.A_Pattern, FXmlTagSITL.D_Pattern));
                        fFormat = FEnumConverter.toFormat(fXmlNodeChild.get_attrVal(FXmlTagSITL.A_Format, FXmlTagSITL.D_Format));

                        // --

                        // ***
                        // XML Node Generate
                        // ***
                        if (fPattern == FPattern.Fixed)
                        {
                            fixLen = int.Parse(fXmlNodeChild.get_attrVal(FXmlTagSITL.A_FixedLength, FXmlTagSITL.D_FixedLength));
                            fXmlNodeChild.set_attrVal(FXmlTagSITL.A_FixedLength, FXmlTagSITL.D_FixedLength, "1");   // Fixed Length 1로 설정
                            // --
                            for (int i = 0; i < fixLen - 1; i++)
                            {
                                fXmlNodeChild = fXmlNodeSitl.insertAfter(fXmlNodeChild.clone(true), fXmlNodeChild);
                            }
                            listIndex += fixLen;
                            childIndex++;
                        }
                        else if (fPattern == FPattern.Variable)
                        {
                            // ***
                            // Variable Item과 나머지 Fixed Item 개수 구하기 개수 구하기
                            // ***
                            for (int i = childIndex; i < childCount; i++)
                            {
                                fXmlNodeChild = fXmlNodeChildList[i];
                                fPattern = FEnumConverter.toPattern(fXmlNodeChild.get_attrVal(FXmlTagSIT.A_Pattern, FXmlTagSIT.D_Pattern));
                                // --
                                if (fPattern == FPattern.Variable)
                                {
                                    varLen++;
                                }
                                else
                                {
                                    fixLen += int.Parse(fXmlNodeChild.get_attrVal(FXmlTagSIT.A_FixedLength, FXmlTagSIT.D_FixedLength));
                                }
                            }

                            // --

                            varCnt = (valLen - listIndex - fixLen) / varLen;

                            // --

                            if (varCnt == 0)
                            {
                                for (int i = childIndex; i < childIndex + varLen; i++)
                                {
                                    fXmlNodeSitl.removeChild(fXmlNodeChildList[i]);
                                }
                            }
                            else
                            {
                                fXmlNodeTmp = fXmlNodeChildList[childIndex + varLen - 1];
                                for (int i = 0; i < varCnt - 1; i++)
                                {
                                    for (int j = 0; j < varLen; j++)
                                    {
                                        fXmlNodeChild = fXmlNodeChildList[childIndex + j];
                                        fXmlNodeTmp = fXmlNodeSitl.insertAfter(fXmlNodeChild.clone(true), fXmlNodeTmp);
                                    }
                                    listIndex++;
                                }
                            }
                            childIndex += varLen;
                        }
                    }   // while end

                    // --

                    fXmlNodeChildList = fXmlNodeSitl.selectNodes(FXmlTagSITL.E_SecsItem);
                    for (int i = 0; i < valLen; i++)
                    {
                        fXmlNodeChild = fXmlNodeChildList[i];
                        fFormat = FEnumConverter.toFormat(fXmlNodeChild.get_attrVal(FXmlTagSITL.A_Format, FXmlTagSITL.D_Format));
                        // --
                        parseBinToSit(fXmlNodeChild, fFormat, body, length, ref index);
                    }

                    // --

                    fXmlNodeSitl.set_attrVal(FXmlTagSITL.A_LengthBytes, FXmlTagSITL.D_LengthBytes, FEnumConverter.fromSecsLengthBytes(fLengthBytes));
                    fXmlNodeSitl.set_attrVal(FXmlTagSITL.A_Length, FXmlTagSITL.D_Length, valLen.ToString());
                }
                else
                {
                    fXmlNodeSitl.set_attrVal(FXmlTagSITL.A_LengthBytes, FXmlTagSITL.D_LengthBytes, FEnumConverter.fromSecsLengthBytes(fLengthBytes));
                    fXmlNodeSitl.set_attrVal(FXmlTagSITL.A_Length, FXmlTagSITL.D_Length, valLen.ToString());
                    // --
                    fXmlNodeSitl.set_attrVal(
                        FXmlTagSITL.A_Value,
                        FXmlTagSITL.D_Value,
                        FValueConverter.fromBinValue(fBinFormat, body, index, valLen, formatBytes)
                        );
                    index += len;
                }    
            
                // --

                fXmlNodeSitl.set_attrVal(FXmlTagSITL.A_Pattern, FXmlTagSITL.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                fXmlNodeSitl.set_attrVal(FXmlTagSITL.A_FixedLength, FXmlTagSITL.D_FixedLength, "1");
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeChildList = null;
                fXmlNodeChild = null;
                fXmlNodeTmp = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static UInt32 calculateBinToRawBytes(
            byte[] body,
            UInt32 length,
            ref UInt32 index
            )
        {
            FFormat fBinFormat = FFormat.Unknown;
            FSecsLengthBytes fLengthBytes = FSecsLengthBytes.Auto;
            UInt32 len = 0;
            UInt32 formatBytes = 0;
            UInt32 lenBytes = 0;
            UInt32 rawBytes = 0;

            try
            {
                parseBinFormatLength(body, length, ref index, ref fBinFormat, ref fLengthBytes, ref len, ref formatBytes, ref lenBytes);

                // --

                rawBytes = 1 + lenBytes;
                if (fBinFormat == FFormat.List)
                {
                    for (int i = 0; i < len; i++)
                    {
                        rawBytes += calculateBinToRawBytes(body, length, ref index);
                    }
                }
                else
                {
                    rawBytes += len;
                    index += len;
                }

                // --

                return rawBytes;
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

        private static bool compareBinWithSmg(
            FXmlNode FXmlNodeSmg, 
            byte[] body
            )
        {
            FXmlNode fXmlNodeSit = null;
            UInt32 length = 0;
            UInt32 index = 0;
            FFormat fSitFormat;

            try
            {
                fXmlNodeSit = FXmlNodeSmg.selectSingleNode(FXmlTagSIT.E_SecsItem);
                if (body != null)
                {
                    length = (UInt32)body.LongLength;
                }                
                
                // ***
                // Header Only SECS Message
                // ***
                if (fXmlNodeSit == null)
                {
                    return length == 0 ? true : false;                    
                }

                // --

                fSitFormat = FEnumConverter.toFormat(fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Format, FXmlTagSIT.D_Format));
                if (!compareBinWithSit(fXmlNodeSit, fSitFormat, body, length, ref index) || index != length)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeSit = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static bool compareBinWithSit(
            FXmlNode fXmlNodeSit,             
            FFormat fSitFormat,
            byte[] body, 
            UInt32 length,
            ref UInt32 index
            )
        {
            FFormat fBinFormat = FFormat.Unknown;
            FSecsLengthBytes fLengthBytes = FSecsLengthBytes.Auto;            
            UInt32 len = 0;
            UInt32 formatBytes = 0;            
            int valLen = 0;            
            string val = string.Empty;            
            FXmlNodeList fXmlNodeChildList = null;
            FXmlNode fXmlNodeChild = null;            
            int childCount = 0;
            int childIndex = 0;
            int listIndex = 0;
            FPattern fPattern;
            FFormat fFormat;
            int fixLen = 0;
            int varLen = 0;
            int varCnt = 0;
            string preCon = string.Empty;
            bool isPreCon = false;

            try
            {
                if (!parseBinFormatLength(body, length, ref index, ref fBinFormat, ref fLengthBytes, ref len, ref formatBytes))
                {
                    return false;
                }                
                valLen = (int)(len / formatBytes);

                // --

                if (fSitFormat == FFormat.Unknown || fSitFormat == FFormat.Raw)
                {
                    #region fSitFormat == FFormat.Unknown || fSitFormat == FFormat.Raw

                    if (fBinFormat == FFormat.List)
                    {
                        for (int i = 0; i < valLen; i++)
                        {
                            if (!compareBinWithSit(fXmlNodeSit, fSitFormat, body, length, ref index))
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        // ***
                        // Invalid Structure Check
                        // ***
                        if (index + len - 1 >= length)
                        {
                            return false;
                        }                        
                        index += len;
                    }

                    #endregion
                }
                else if (fSitFormat == FFormat.List || fSitFormat == FFormat.AsciiList)
                {
                    #region fSitFormat == FFormat.List || fSitFormat == FFormat.AsciiList

                    if (fBinFormat != FFormat.List)
                    {
                        return false;
                    }

                    // --

                    fXmlNodeChildList = fXmlNodeSit.selectNodes(FXmlTagSIT.E_SecsItem);
                    childCount = fXmlNodeChildList.count;
                    childIndex = 0;
                    listIndex = 0;

                    // --
                    
                    while (childIndex < childCount)
                    {
                        fixLen = 0;
                        varLen = 0;
                        varCnt = 0;

                        // --
                        
                        fXmlNodeChild = fXmlNodeChildList[childIndex];
                        fPattern = FEnumConverter.toPattern(fXmlNodeChild.get_attrVal(FXmlTagSIT.A_Pattern, FXmlTagSIT.D_Pattern));
                        fFormat = FEnumConverter.toFormat(fXmlNodeChild.get_attrVal(FXmlTagSIT.A_Format, FXmlTagSIT.D_Format));
                        
                        // --

                        if (fPattern == FPattern.Fixed)
                        {
                            fixLen = int.Parse(fXmlNodeChild.get_attrVal(FXmlTagSIT.A_FixedLength, FXmlTagSIT.D_FixedLength));
                            if (listIndex + fixLen > len)
                            {
                                return false;
                            }

                            // --
                            
                            for (int i = 0; i < fixLen; i++)
                            {
                                if (!compareBinWithSit(fXmlNodeChild, fFormat, body, length, ref index))
                                {
                                    return false;
                                }                                
                            }
                            listIndex += fixLen;
                            childIndex++;
                        }
                        else if (fPattern == FPattern.Variable)
                        {
                            // ***
                            // Variable Item과 나머지 Fixed Item 개수 구하기 개수 구하기
                            // ***
                            for (int i = childIndex; i < childCount; i++)
                            {
                                fXmlNodeChild = fXmlNodeChildList[i];
                                fPattern = FEnumConverter.toPattern(fXmlNodeChild.get_attrVal(FXmlTagSIT.A_Pattern, FXmlTagSIT.D_Pattern));
                                // --
                                if (fPattern == FPattern.Variable)
                                {
                                    varLen++;
                                }
                                else
                                {
                                    fixLen += int.Parse(fXmlNodeChild.get_attrVal(FXmlTagSIT.A_FixedLength, FXmlTagSIT.D_FixedLength));
                                }
                            }

                            // --

                            // ***
                            // Variable 회수 구하기
                            // ***
                            if (listIndex + fixLen > len)
                            {
                                return false;
                            }
                            varCnt = (int)(len - listIndex - fixLen) / varLen;

                            // --

                            for (int i = 0; i < varCnt; i++)
                            {
                                for (int j = 0; j < varLen; j++)
                                {
                                    fXmlNodeChild = fXmlNodeChildList[childIndex + j];
                                    fFormat = FEnumConverter.toFormat(fXmlNodeChild.get_attrVal(FXmlTagSIT.A_Format, FXmlTagSIT.D_Format));
                                    // --
                                    if (!compareBinWithSit(fXmlNodeChild, fFormat, body, length, ref index))
                                    {
                                        return false;
                                    }
                                    listIndex++;
                                }
                            }                            
                            childIndex += varLen;
                        }                        
                    }   // while end

                    #endregion
                }
                else
                {
                    if (fBinFormat != fSitFormat)
                    {
                        return false;
                    }

                    if (index + len - 1 >= length)
                    {
                        return false;
                    }  

                    // --

                    // ***
                    // Precondition 적용 (Ascii 계열이거나 Value 개수가 1일 경우에만 적용)
                    // ***
                    if (fBinFormat == FFormat.Ascii || fBinFormat == FFormat.JIS8 || fBinFormat == FFormat.A2 || valLen == 1)
                    {
                        preCon = fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Precondition, FXmlTagSIT.D_Precondition);
                        if (preCon != string.Empty)
                        {
                            val = FValueConverter.fromBinValue(fBinFormat, body, index, valLen, formatBytes);
                            isPreCon = false;
                            // --
                            foreach (string s in preCon.Split(FConstants.PreconditionValueSeparator))
                            {
                                if (val == s)
                                {
                                    isPreCon = true;
                                    break;
                                }
                            }
                            // --
                            if (!isPreCon)
                            {
                                return false;
                            }
                        }
                    }                    

                    // --

                    index += len;
                }
                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeChildList = null;
                fXmlNodeChild = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static bool generateBinToSmg(
            FXmlDocument fXmlDoc,
            FXmlNode fXmlNodeSmgl,
            byte[] body
            )
        {
            FXmlNode fXmlNodeSitl = null;
            UInt32 length = 0;
            UInt32 index = 0;

            try
            {
                if (body == null)
                {
                    return true;
                }

                // --

                length = (UInt32)body.LongLength;
                fXmlNodeSitl = FSecsDriverLogCommon.createXmlNodeSITL(fXmlDoc);
                if (!generateBinToSit(fXmlDoc, fXmlNodeSitl, body, length, ref index) || length != index)
                {
                    return false;
                }
                fXmlNodeSmgl.appendChild(fXmlNodeSitl);

                // --

                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeSitl = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static bool generateBinToSit(
            FXmlDocument fXmlDoc, 
            FXmlNode fXmlNodeSitl, 
            byte[] body, 
            UInt32 length, 
            ref UInt32 index
            )
        {
            FFormat fBinFormat = FFormat.Unknown;
            FSecsLengthBytes fLengthBytes = FSecsLengthBytes.Auto;     
            UInt32 len = 0;
            UInt32 formatBytes = 0;
            int valLen = 0;
            FXmlNode fXmlNodeChild = null;

            try
            {
                if (!parseBinFormatLength(body, length, ref index, ref fBinFormat, ref fLengthBytes, ref len, ref formatBytes))
                {
                    return false;
                }
                valLen = (int)(len / formatBytes);

                // --

                fXmlNodeSitl.set_attrVal(FXmlTagSITL.A_Name, FXmlTagSITL.D_Name, fBinFormat == FFormat.List ? "L" : "I");
                fXmlNodeSitl.set_attrVal(FXmlTagSITL.A_Format, FXmlTagSITL.D_Format, FEnumConverter.fromFormat(fBinFormat));
                fXmlNodeSitl.set_attrVal(FXmlTagSITL.A_LengthBytes, FXmlTagSITL.D_LengthBytes, FEnumConverter.fromSecsLengthBytes(fLengthBytes));
                fXmlNodeSitl.set_attrVal(FXmlTagSITL.A_Length, FXmlTagSITL.D_Length, valLen.ToString());
                // --
                if (fBinFormat == FFormat.List)
                {
                    for (int i = 0; i < valLen; i++)
                    {
                        fXmlNodeChild = FSecsDriverLogCommon.createXmlNodeSITL(fXmlDoc);
                        if (!generateBinToSit(fXmlDoc, fXmlNodeChild, body, length, ref index))
                        {
                            return false;
                        }
                        fXmlNodeSitl.appendChild(fXmlNodeChild);
                    }
                }
                else
                {
                    fXmlNodeSitl.set_attrVal(
                        FXmlTagSITL.A_Value, 
                        FXmlTagSITL.D_Value, 
                        FValueConverter.fromBinValue(fBinFormat, body, index, valLen, formatBytes)
                        );
                    index += len;
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
                fXmlNodeChild = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode parseSmgToBin(            
            FSecsDevice fSdv,
            FXmlNode fXmlNodeSsn,
            FXmlNode fXmlNodeSmt,
            UInt32 systemBytes,            
            ref int sessionId,
            ref int stream,
            ref int function,
            ref bool wbit,
            ref ArrayList body
            )
        {
            FXmlNode fXmlNodeSmgl = null;
            FXmlNode fXmlNodeSitl = null;
            FFormat fFormat;
            UInt32 length = 0;

            try
            {
                fXmlNodeSmgl = fXmlNodeSmt.clone(true);                

                // --

                // ***
                // Header
                // ***
                sessionId = int.Parse(fXmlNodeSsn.get_attrVal(FXmlTagSSN.A_SessionId, FXmlTagSSN.D_SessionId));
                stream = int.Parse(fXmlNodeSmgl.get_attrVal(FXmlTagSMGL.A_Stream, FXmlTagSMGL.D_Stream));
                function = int.Parse(fXmlNodeSmgl.get_attrVal(FXmlTagSMGL.A_Function, FXmlTagSMGL.D_Function));
                wbit = FBoolean.toBool(fXmlNodeSmgl.get_attrVal(FXmlTagSMGL.A_WBit, FXmlTagSMGL.D_WBit));
                length = 10;
                body = null;

                // --                

                // ***
                // Body
                // ***
                fXmlNodeSitl = fXmlNodeSmgl.selectSingleNode(FXmlTagSITL.E_SecsItem);
                if (fXmlNodeSitl != null)
                {
                    body = new ArrayList();
                    // --
                    fFormat = FEnumConverter.toFormat(fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Format, FXmlTagSITL.D_Format));
                    parseSitToBin(fXmlNodeSitl, fFormat, body);
                    // --
                    length += (UInt32)body.Count;
                }

                // --

                setSecsMessageLogInfo(fXmlNodeSmgl, fSdv.fXmlNode, fXmlNodeSsn, sessionId, systemBytes, length);
                
                // --

                return fXmlNodeSmgl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeSitl = null;
                fXmlNodeSmgl = null;
            }
            return null;
        }        

        //------------------------------------------------------------------------------------------------------------------------

        private static void parseSitToBin(
            FXmlNode fXmlNodeSitl,
            FFormat fSitFormat,
            ArrayList body
            )
        {
            FSecsLengthBytes fLengthBytes = FSecsLengthBytes.Auto;
            UInt32 formatBytes = 0;
            int valLen = 0;
            int len = 0;
            string val = string.Empty;
            byte formatCode = 0;
            byte[] lenArr = null;
            byte[] valArr = null;
            byte[] byteArr = null;
            FXmlNodeList fXmlNodeListChild = null;
            FXmlNode fXmlNodeChild = null;
            FPattern fPattern;
            FFormat fFormat;
            int fixLen = 0;

            try
            {
                if (fSitFormat == FFormat.Raw)
                {
                    fSitFormat = FFormat.Binary;
                    fXmlNodeSitl.set_attrVal(FXmlTagSITL.A_Format, FXmlTagSITL.D_Format, FEnumConverter.fromFormat(fSitFormat));
                }
                else if (fSitFormat == FFormat.Unknown || fSitFormat == FFormat.AsciiList)
                {
                    fSitFormat = FFormat.List;
                    fXmlNodeSitl.set_attrVal(FXmlTagSITL.A_Format, FXmlTagSITL.D_Format, FEnumConverter.fromFormat(fSitFormat));
                }

                // --

                formatBytes = FValueConverter.getFormatBytes(fSitFormat);
                fLengthBytes = FEnumConverter.toSecsLengthBytes(fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_LengthBytes, FXmlTagSITL.D_LengthBytes));
                valLen = int.Parse(fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Length, FXmlTagSITL.D_Length));

                // --

                if (fSitFormat == FFormat.List)
                {
                    fXmlNodeListChild = fXmlNodeSitl.selectNodes(FXmlTagSITL.E_SecsItem);
                    for (int i = 0; i < fXmlNodeListChild.count; i++)
                    {
                        fXmlNodeChild = fXmlNodeListChild[i];
                        fPattern = FEnumConverter.toPattern(fXmlNodeChild.get_attrVal(FXmlTagSITL.A_Pattern, FXmlTagSITL.D_Pattern));
                        // --
                        if (fPattern == FPattern.Fixed)
                        {
                            fixLen = int.Parse(fXmlNodeChild.get_attrVal(FXmlTagSITL.A_FixedLength, FXmlTagSITL.D_FixedLength));
                            if (fixLen > 1)
                            {
                                fXmlNodeChild.set_attrVal(FXmlTagSITL.A_FixedLength, FXmlTagSITL.D_FixedLength, "1");
                                // --
                                for (int j = 1; j < fixLen; j++)
                                {
                                    fXmlNodeChild = fXmlNodeSitl.insertAfter(fXmlNodeChild.clone(true), fXmlNodeChild);
                                }
                                valLen += (fixLen - 1);
                            }
                        }
                        else
                        {
                            fXmlNodeSitl.removeChild(fXmlNodeChild);
                            valLen--;
                        }
                    }
                    // --
                    fXmlNodeSitl.set_attrVal(FXmlTagSITL.A_Length, FXmlTagSITL.D_Length, valLen.ToString());
                }
                else
                {
                    val = FValueConverter.toTransformedStringValue(
                        fSitFormat,
                        fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Value, FXmlTagSITL.D_Value),
                        fXmlNodeSitl.get_attrVal(FXmlTagSIT.A_Transformer, FXmlTagSIT.D_Transformer),
                        ref valLen
                        );
                    if (valLen > 0)
                    {
                        valArr = FValueConverter.toBinValue(fSitFormat, val, valLen, formatBytes);
                    }
                }

                // --
                
                len = (int)(valLen * formatBytes);
                if (fLengthBytes == FSecsLengthBytes.Auto)
                {
                    fLengthBytes = FValueConverter.getLengthBytes(len);
                    fXmlNodeSitl.set_attrVal(FXmlTagSITL.A_LengthBytes, FXmlTagSITL.D_LengthBytes, FEnumConverter.fromSecsLengthBytes(fLengthBytes));
                }

                // --

                formatCode = (byte)((int)fSitFormat << 2);
                if (fLengthBytes == FSecsLengthBytes.Byte1)
                {
                    formatCode |= 0x01;
                    lenArr = new byte[1] { (byte)len };
                }
                else if (fLengthBytes == FSecsLengthBytes.Byte2)
                {
                    formatCode |= 0x02;
                    lenArr = FByteConverter.getBytes((UInt16)len, true);
                }
                else
                {
                    formatCode |= 0x03;
                    byteArr = FByteConverter.getBytes((UInt32)len, true);
                    // --
                    lenArr = new byte[3];
                    lenArr[0] = byteArr[1];
                    lenArr[1] = byteArr[2];
                    lenArr[2] = byteArr[3];
                }

                // --

                body.Add(formatCode);
                body.AddRange(lenArr);
                // --
                if (valArr != null)
                {
                    body.AddRange(valArr);
                }

                // --

                if (fSitFormat == FFormat.List)
                {
                    fXmlNodeListChild = fXmlNodeSitl.selectNodes(FXmlTagSITL.E_SecsItem);
                    for (int i = 0; i < fXmlNodeListChild.count; i++)
                    {
                        fXmlNodeChild = fXmlNodeListChild[i];
                        fFormat = FEnumConverter.toFormat(fXmlNodeChild.get_attrVal(FXmlTagSITL.A_Format, FXmlTagSITL.D_Format));
                        parseSitToBin(fXmlNodeChild, fFormat, body);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                lenArr = null;
                byteArr = null;
                valArr = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode getReplyMessage(
            FSecsDriver fScd,
            FXmlNode fXmlNodeSsn, 
            string primaryUniqueId
            )
        {
            const string SecsMessageQuery =
                FXmlTagSLM.E_SecsLibraryModeling +
                "/" + FXmlTagSLG.E_SecsLibraryGroup +
                "/" + FXmlTagSLB.E_SecsLibrary + "[@" + FXmlTagSLB.A_UniqueId + "='{0}']" +
                "/" + FXmlTagSML.E_SecsMessageList +
                "/" + FXmlTagSMS.E_SecsMessages +
                "/" + FXmlTagSMG.E_SecsMessage + "[@" + FXmlTagSMG.A_UniqueId + "='{1}']";

            // --

            FXmlNode fXmlNodeSmg = null;

            try
            {
                fXmlNodeSmg = fScd.fXmlNode.selectSingleNode(
                    string.Format(SecsMessageQuery, fXmlNodeSsn.get_attrVal(FXmlTagSSN.A_SecsLibraryId, FXmlTagSSN.D_SecsLibraryId), primaryUniqueId)
                    );
                if (fXmlNodeSmg == null)
                {
                    return null;
                }
                return fXmlNodeSmg.fNextSibling;                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeSmg = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode[] parseTimeoutTrigger(
            FSecsDriver fScd, 
            FXmlNode fXmlNodeSmgl,
            ref FXmlNode fXmlNodeRetryScn
            )
        {
            const string SecsConditionQuery =
                FXmlTagEQM.E_EquipmentModeling +
                "/" + FXmlTagEQP.E_Equipment +
                "/" + FXmlTagSNG.E_ScenarioGroup +
                "/" + FXmlTagSNR.E_Scenario +
                "/" + FXmlTagSTR.E_SecsTrigger +
                "/" + FXmlTagSCN.E_SecsCondition +
                "[@" + FXmlTagSCN.A_ConditionMode + "='{0}' and" +
                " @" + FXmlTagSCN.A_SecsDeviceId  + "='{1}' and" +
                " @" + FXmlTagSCN.A_SecsSessionId + "='{2}' and" +
                " @" + FXmlTagSCN.A_SecsMessageId + "='{3}']";                

            // --

            FXmlNodeList fXmlNodeListScn = null;
            FXmlNode fXmlNodeStr = null;
            HashSet<string> strKeys = null;
            ArrayList strList = null;
            string strUniqueId = string.Empty;
            string xpath = string.Empty;            

            try
            {
                xpath = string.Format(
                    SecsConditionQuery,
                    FEnumConverter.fromConditionMode(FConditionMode.Timeout),
                    fXmlNodeSmgl.get_attrVal(FXmlTagSMGL.A_SecsDeviceId, FXmlTagSMGL.D_SecsDeviceId),
                    fXmlNodeSmgl.get_attrVal(FXmlTagSMGL.A_SecsSessionId, FXmlTagSMGL.D_SecsSessionId),
                    fXmlNodeSmgl.get_attrVal(FXmlTagSMGL.A_UniqueId, FXmlTagSMGL.D_UniqueId)
                    );
                fXmlNodeListScn = fScd.fXmlNode.selectNodes(xpath);

                // --

                strKeys = new HashSet<string>();
                strList = new ArrayList();
                // --
                foreach (FXmlNode fXmlNodeScn in fXmlNodeListScn)
                {
                    // ***
                    // 첫번째 Retry Limit가 설정되어 있는 SECS Condition 검색
                    // ***
                    if (fXmlNodeRetryScn == null)
                    {
                        if (fXmlNodeScn.get_attrVal(FXmlTagSCN.A_RetryLimit, FXmlTagSCN.D_RetryLimit) != "0")
                        {
                            fXmlNodeRetryScn = fXmlNodeScn;
                        }
                    }
                    
                    // --
                    
                    // ***
                    // 중복 조건 검사
                    // ***
                    fXmlNodeStr = fXmlNodeScn.fParentNode;
                    strUniqueId = fXmlNodeStr.get_attrVal(FXmlTagSTR.A_UniqueId, FXmlTagSTR.D_UniqueId);
                    if (strKeys.Contains(strUniqueId))
                    {
                        continue;
                    }

                    // --

                    strList.Add(fXmlNodeStr);
                    strKeys.Add(strUniqueId);
                }

                // --

                return (FXmlNode[])strList.ToArray(typeof(FXmlNode));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListScn = null;
                strKeys = null;
                strList = null;
                fXmlNodeStr = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode[] parseExpressionTrigger(
            FSecsDriver fScd,
            FXmlNode fXmlNodeSmgl
            )
        {
            const string SecsConditionQuery =
                FXmlTagEQM.E_EquipmentModeling +
                "/" + FXmlTagEQP.E_Equipment +
                "/" + FXmlTagSNG.E_ScenarioGroup +
                "/" + FXmlTagSNR.E_Scenario +
                "/" + FXmlTagSTR.E_SecsTrigger +
                "/" + FXmlTagSCN.E_SecsCondition + 
                "[@" + FXmlTagSCN.A_ConditionMode + "='{0}' and" +
                " @" + FXmlTagSCN.A_SecsDeviceId  + "='{1}' and" + 
                " @" + FXmlTagSCN.A_SecsSessionId + "='{2}' and" +
                " @" + FXmlTagSCN.A_SecsMessageId + "='{3}']";                

            // --

            FXmlNodeList fXmlNodeListScn = null;
            FXmlNodeList fXmlNodeListSep = null;
            FXmlNode fXmlNodeStr = null;
            bool result = false;
            string xpath = string.Empty;
            HashSet<string> strKeys = null;
            List<FXmlNode> strList = null;
            string strUniqueId = string.Empty;

            try
            {
                xpath = string.Format(
                    SecsConditionQuery,
                    FEnumConverter.fromConditionMode(FConditionMode.Expression),
                    fXmlNodeSmgl.get_attrVal(FXmlTagSMGL.A_SecsDeviceId, FXmlTagSMGL.D_SecsDeviceId),
                    fXmlNodeSmgl.get_attrVal(FXmlTagSMGL.A_SecsSessionId, FXmlTagSMGL.D_SecsSessionId),
                    fXmlNodeSmgl.get_attrVal(FXmlTagSMGL.A_UniqueId, FXmlTagSMGL.D_UniqueId)
                    );
                fXmlNodeListScn = fScd.fXmlNode.selectNodes(xpath);
                    
                // --

                strKeys = new HashSet<string>();
                strList = new List<FXmlNode>();
                // --
                foreach (FXmlNode fXmlNodeScn in fXmlNodeListScn)
                {
                    // ***
                    // 중복 조건 검사
                    // ***
                    fXmlNodeStr = fXmlNodeScn.fParentNode;
                    strUniqueId = fXmlNodeStr.get_attrVal(FXmlTagSTR.A_UniqueId, FXmlTagSTR.D_UniqueId);
                    if (strKeys.Contains(strUniqueId))
                    {
                        continue;
                    }

                    // --

                    result = true;
                    fXmlNodeListSep = fXmlNodeScn.selectNodes(FXmlTagSEP.E_SecsExpression);
                    foreach (FXmlNode fXmlNodeSep in fXmlNodeListSep)
                    {
                        compareCondition(fScd, fXmlNodeSmgl, fXmlNodeSep, ref result);                        
                    }

                    if (result)
                    {
                        strList.Add(fXmlNodeStr);
                        strKeys.Add(strUniqueId);
                    }
                }    
            
                // --

                return strList.ToArray();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);                
            }
            finally
            {
                fXmlNodeListScn = null;
                fXmlNodeListSep = null;
                fXmlNodeStr = null;
                strKeys = null;
                strList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode[] parseConnectionTrigger(
            FSecsDriver fScd,
            FXmlNode fXmlNodeDvcl,
            FDeviceState fDeviceState
            )
        {
            const string SecsConditionQuery =
                FXmlTagEQM.E_EquipmentModeling +
                "/" + FXmlTagEQP.E_Equipment +
                "/" + FXmlTagSNG.E_ScenarioGroup +
                "/" + FXmlTagSNR.E_Scenario +
                "/" + FXmlTagSTR.E_SecsTrigger +
                "/" + FXmlTagSCN.E_SecsCondition +
                "[@" + FXmlTagSCN.A_ConditionMode + "='{0}' and" +
                " @" + FXmlTagSCN.A_SecsDeviceId + "='{1}' and" +
                " @" + FXmlTagSCN.A_ConnectionState + "='{2}']";

            // --

            FXmlNodeList fXmlNodeListScn = null;
            FXmlNode fXmlNodeStr = null;
            string xpath = string.Empty;
            HashSet<string> strKeys = null;
            List<FXmlNode> strList = null;
            string strUniqueId = string.Empty;

            try
            {
                xpath = string.Format(
                    SecsConditionQuery,
                    FEnumConverter.fromConditionMode(FConditionMode.Connection),
                    fXmlNodeDvcl.get_attrVal(FXmlTagSDV.A_UniqueId, FXmlTagSDV.D_UniqueId),
                    FEnumConverter.fromDeviceState(fDeviceState)
                    );
                fXmlNodeListScn = fScd.fXmlNode.selectNodes(xpath);

                // --

                strKeys = new HashSet<string>();
                strList = new List<FXmlNode>();
                // --
                foreach (FXmlNode fXmlNodeScn in fXmlNodeListScn)
                {
                    // ***
                    // 중복 조건 검사
                    // ***
                    fXmlNodeStr = fXmlNodeScn.fParentNode;
                    strUniqueId = fXmlNodeStr.get_attrVal(FXmlTagSTR.A_UniqueId, FXmlTagSTR.D_UniqueId);
                    if (strKeys.Contains(strUniqueId))
                    {
                        continue;
                    }

                    // --

                    strList.Add(fXmlNodeStr);
                    strKeys.Add(strUniqueId);
                }

                // --

                return strList.ToArray();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListScn = null;
                fXmlNodeStr = null;
                strKeys = null;
                strList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void compareCondition(
            FSecsDriver fScd,
            FXmlNode fXmlNodeSmgl,
            FXmlNode fXmlNodeSep,
            ref bool oldResult
            )
        {
            const string SecsItemLogQuery = ".//" + FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_UniqueId + "='{0}']";
            // --
            const string EnvironmentQuery =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagEND.E_EnvironmentDefinition +
                "/" + FXmlTagENL.E_EnvironmentList +
                "//" + FXmlTagENV.E_Environment + "[@" + FXmlTagENV.A_UniqueId + "='{0}']";
            // --
            const string EquipmentStateQuery =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagESD.E_EquipmentStateSetDefinition +
                "/" + FXmlTagESL.E_EquipmentStateSetList +
                "/" + FXmlTagESS.E_EquipmentStateSet +
                "/" + FXmlTagEST.E_EquipmentState + "[@" + FXmlTagEST.A_UniqueId + "='{0}']";

            // --

            FXmlNodeList fXmlNodeListChild = null;
            FXmlNodeList fXmlNodeListOpe = null;
            FXmlNode fXmlNodeOpe = null;
            FXmlNode fXmlNodeEq = null;
            string operandUniqueId = string.Empty;
            int operandIndex = 0;
            FFormat fOperandFormat = FFormat.Ascii;
            FOperation fOperation = FOperation.Equal;
            FLogical fLogical = FLogical.And;
            FExpressionType fExpressionType = FExpressionType.Bracket;
            FComparisonMode fComparisonMode = FComparisonMode.Value;
            FSecsOperandType fOperandType = FSecsOperandType.SecsItem;
            FExpressionValueType fExpressionValueType = FExpressionValueType.Value;
            FSecsResourceSourceType fResourceSourceType = FSecsResourceSourceType.None;
            FEquipmentStateMaterial fEquipmentStateMaterial = null;
            string operandValue = string.Empty;
            int operandValueLength = 0;
            string value = string.Empty;
            string eqUniqueId = string.Empty;
            int length = 0;
            object oVal1 = null;
            object oVal2 = null;
            bool newResult = false;

            try
            {
                fExpressionType = FEnumConverter.toExpressionType(fXmlNodeSep.get_attrVal(FXmlTagSEP.A_ExpressionType, FXmlTagSEP.D_ExpressionType));
                fLogical = FEnumConverter.toLogical(fXmlNodeSep.get_attrVal(FXmlTagSEP.A_Logical, FXmlTagSEP.D_Logical));

                // --

                if (fExpressionType == FExpressionType.Bracket)
                {
                    newResult = true;
                    fXmlNodeListChild = fXmlNodeSep.selectNodes(FXmlTagSEP.E_SecsExpression);
                    foreach (FXmlNode fXmlNodeChild in fXmlNodeListChild)
                    {
                        compareCondition(fScd, fXmlNodeSmgl, fXmlNodeChild, ref newResult);
                    }
                    oldResult = compareResult(fLogical, oldResult, newResult);
                    return;
                }

                // --

                // ***
                // Operand가 존재하지 않을 경우 False 설정
                // ***
                operandUniqueId = fXmlNodeSep.get_attrVal(FXmlTagSEP.A_OperandId, FXmlTagSEP.D_OperandId);
                if (operandUniqueId == string.Empty)
                {
                    oldResult = compareResult(fLogical, oldResult, false);
                    return;
                }

                // --

                fComparisonMode = FEnumConverter.toComparisonMode(fXmlNodeSep.get_attrVal(FXmlTagSEP.A_ComparisonMode, FXmlTagSEP.D_ComparisonMode));
                operandIndex = int.Parse(fXmlNodeSep.get_attrVal(FXmlTagSEP.A_OperandIndex, FXmlTagSEP.D_OperandIndex));
                fOperation = FEnumConverter.toOperation(fXmlNodeSep.get_attrVal(FXmlTagSEP.A_Operation, FXmlTagSEP.D_Operation));
                fOperandType = FEnumConverter.toSecsOperandType(fXmlNodeSep.get_attrVal(FXmlTagSEP.A_OperandType, FXmlTagSEP.D_OperandType));
                fOperandFormat = FEnumConverter.toFormat(fXmlNodeSep.get_attrVal(FXmlTagSEP.A_OperandFormat, FXmlTagSEP.D_OperandFormat));
                fExpressionValueType = FEnumConverter.toExpressionValueType(fXmlNodeSep.get_attrVal(FXmlTagSEP.A_ExpressionValueType, FXmlTagSEP.D_ExpressionValueType));

                // --

                // ***
                // Operand Length는 Ascii 계열이외에만 사용되고 Operand Length는 0 또는 1만을 가질수 있기 때문에
                // 값이 존재하지 않을 경우 0처리하고 값이 존재할 경우 1처리한다.
                // Operand Format이 Ascii 계열인 경우 Operand Length를 사용하지 않는다.
                // ***
                if (fExpressionValueType == FExpressionValueType.Value)
                {
                    operandValue = fXmlNodeSep.get_attrVal(FXmlTagSEP.A_Value, FXmlTagSEP.D_Value);
                }
                else
                {
                    fResourceSourceType = FEnumConverter.toSecsResourceSourceType(fXmlNodeSep.get_attrVal(FXmlTagSEP.A_Resource, FXmlTagSEP.D_Resource));

                    // --

                    if (fResourceSourceType == FSecsResourceSourceType.EapName)
                    {
                        operandValue = fScd.eapName;
                    }
                    else if (fResourceSourceType == FSecsResourceSourceType.EquipmentName)
                    {
                        fXmlNodeEq = fXmlNodeSep.fParentNode.fParentNode.fParentNode.fParentNode.fParentNode;
                        operandValue = fXmlNodeEq.get_attrVal(FXmlTagEQP.A_Name, FXmlTagEQP.D_Name);
                    }
                    else if (fResourceSourceType == FSecsResourceSourceType.SecsDeviceName)
                    {
                        operandValue = fXmlNodeSmgl.get_attrVal(FXmlTagSMGL.A_SecsDeviceName, FXmlTagSMGL.D_SecsDeviceName);
                    }
                    else if (fResourceSourceType == FSecsResourceSourceType.SecsSessionName)
                    {
                        operandValue = fXmlNodeSmgl.get_attrVal(FXmlTagSMGL.A_SecsSessionName, FXmlTagSMGL.D_SecsSessionName);
                    }
                    else if (fResourceSourceType == FSecsResourceSourceType.SecsSessionId)
                    {
                        operandValue = fXmlNodeSmgl.get_attrVal(FXmlTagSMGL.A_SecsSessionId, FXmlTagSMGL.D_SecsSessionId);
                    }
                    else
                    {
                        operandValue = string.Empty;
                    }
                }
                operandValueLength = (operandValue == string.Empty ? 0 : 1);

                // --                    

                if (fOperandType == FSecsOperandType.SecsItem)
                {
                    // ***
                    // Operand가 존재하지 않을 경우 False 설정
                    // ***
                    fXmlNodeListOpe = fXmlNodeSmgl.selectNodes(string.Format(SecsItemLogQuery, operandUniqueId));
                    if (operandIndex >= fXmlNodeListOpe.count)
                    {
                        oldResult = compareResult(fLogical, oldResult, false);
                        return;
                    }

                    // --

                    fXmlNodeOpe = fXmlNodeListOpe[operandIndex];
                    length = int.Parse(fXmlNodeOpe.get_attrVal(FXmlTagSITL.A_Length, FXmlTagSITL.D_Length));
                    value = FValueConverter.toDataConversionStringValue(
                        fOperandFormat,
                        fXmlNodeOpe.get_attrVal(FXmlTagSITL.A_Value, FXmlTagSITL.D_Value),
                        fXmlNodeOpe.get_attrVal(FXmlTagSITL.A_Transformer, FXmlTagSITL.D_Transformer),
                        fXmlNodeOpe.get_attrVal(FXmlTagSITL.A_DataConversionSetExpression, FXmlTagSITL.D_DataConversionSetExpression),
                        ref length
                        );
                }
                else if (fOperandType == FSecsOperandType.Environment)
                {
                    // ***
                    // Operand가 존재하지 않을 경우 False 설정
                    // ***
                    fXmlNodeListOpe = fScd.fXmlNode.selectNodes(string.Format(EnvironmentQuery, operandUniqueId));
                    if (operandIndex >= fXmlNodeListOpe.count)
                    {
                        oldResult = compareResult(fLogical, oldResult, false);
                        return;
                    }

                    // --

                    fXmlNodeOpe = fXmlNodeListOpe[operandIndex];
                    length = int.Parse(fXmlNodeOpe.get_attrVal(FXmlTagENV.A_Length, FXmlTagENV.D_Length));
                    value = fXmlNodeOpe.get_attrVal(FXmlTagENV.A_Value, FXmlTagENV.D_Value);
                }
                else if (fOperandType == FSecsOperandType.EquipmentState)
                {
                    // ***
                    // Operand가 존재하지 않을 경우 False 설정
                    // ***
                    fXmlNodeListOpe = fScd.fXmlNode.selectNodes(string.Format(EquipmentStateQuery, operandUniqueId));
                    if (operandIndex >= fXmlNodeListOpe.count)
                    {
                        oldResult = compareResult(fLogical, oldResult, false);
                        return;
                    }

                    // --

                    fXmlNodeEq = fXmlNodeSep.fParentNode.fParentNode.fParentNode.fParentNode.fParentNode;
                    eqUniqueId = fXmlNodeEq.get_attrVal(FXmlTagEQP.A_UniqueId, FXmlTagEQP.D_UniqueId);

                    // --

                    fEquipmentStateMaterial = fScd.fEquipmentStateMaterialStorage.getEquipmentStateMaterial(
                        eqUniqueId,
                        operandUniqueId
                        );
                    if (fEquipmentStateMaterial == null)
                    {
                        oldResult = compareResult(fLogical, oldResult, false);
                        return;
                    }

                    // --

                    length = 1;
                    value = fEquipmentStateMaterial.stateValue;
                }

                // --

                // ***
                // SECS Expression Transformer 적용
                // ***
                value = FValueConverter.toDataConversionStringValue(
                    fOperandFormat,
                    value,
                    fXmlNodeSep.get_attrVal(FXmlTagSEP.A_Transformer, FXmlTagSEP.D_Transformer),
                    fXmlNodeSep.get_attrVal(FXmlTagSEP.A_DataConversionSetExpression, FXmlTagSEP.D_DataConversionSetExpression),
                    ref length
                    );

                // --

                newResult = true;

                // --

                if (fComparisonMode == FComparisonMode.Value)
                {
                    if (fOperandFormat == FFormat.Ascii || fOperandFormat == FFormat.A2 || fOperandFormat == FFormat.JIS8)
                    {
                        if (fOperation == FOperation.Equal)
                        {
                            newResult = (string.Compare(value, operandValue) == 0 ? true : false);
                        }
                        else if (fOperation == FOperation.NotEqual)
                        {
                            newResult = (string.Compare(value, operandValue) != 0 ? true : false);
                        }
                        else if (fOperation == FOperation.MoreThan)
                        {
                            newResult = (string.Compare(value, operandValue) > 0 ? true : false);
                        }
                        else if (fOperation == FOperation.MoreThanOrEqual)
                        {
                            newResult = (string.Compare(value, operandValue) >= 0 ? true : false);
                        }
                        else if (fOperation == FOperation.LessThan)
                        {
                            newResult = (string.Compare(value, operandValue) < 0 ? true : false);
                        }
                        else if (fOperation == FOperation.LessThanOrEqual)
                        {
                            newResult = (string.Compare(value, operandValue) <= 0 ? true : false);
                        }
                    }
                    else
                    {
                        if (length > 1)
                        {
                            // ***
                            // Ascii 계열이 아니고 Length가 1 보다 클 경우 False 처리
                            // ***
                            newResult = false;
                        }
                        else if (length == 0)
                        {
                            if (operandValueLength > 1)
                            {
                                newResult = false;
                            }
                            else if (operandValueLength == 0)
                            {
                                if (
                                    fOperation == FOperation.Equal ||
                                    fOperation == FOperation.MoreThanOrEqual ||
                                    fOperation == FOperation.LessThanOrEqual
                                    )
                                {
                                    newResult = true;
                                }
                                else
                                {
                                    newResult = false;
                                }
                            }
                            else
                            {
                                if (
                                    fOperation == FOperation.NotEqual ||
                                    fOperation == FOperation.LessThan ||
                                    fOperation == FOperation.LessThanOrEqual
                                    )
                                {
                                    newResult = true;
                                }
                                else
                                {
                                    newResult = false;
                                }
                            }
                        }
                        else
                        {
                            oVal1 = FValueConverter.toValue(fOperandFormat, value);

                            // --

                            if (operandValueLength > 1)
                            {
                                newResult = false;
                            }
                            else if (operandValueLength == 0)
                            {
                                if (
                                    fOperation == FOperation.NotEqual ||
                                    fOperation == FOperation.MoreThan ||
                                    fOperation == FOperation.MoreThanOrEqual
                                    )
                                {
                                    newResult = true;
                                }
                                else
                                {
                                    newResult = false;
                                }
                            }
                            else
                            {
                                oVal2 = FValueConverter.toValue(fOperandFormat, operandValue);

                                // --

                                if (fOperandFormat == FFormat.Binary)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((byte)oVal1 == (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((byte)oVal1 != (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((byte)oVal1 > (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((byte)oVal1 >= (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((byte)oVal1 < (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((byte)oVal1 <= (byte)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.Boolean)
                                {
                                    if (
                                        fOperation == FOperation.Equal ||
                                        fOperation == FOperation.MoreThanOrEqual ||
                                        fOperation == FOperation.LessThanOrEqual
                                        )
                                    {
                                        newResult = ((bool)oVal1 == (bool)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((bool)oVal1 != (bool)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.I8)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((Int64)oVal1 == (Int64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((Int64)oVal1 != (Int64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((Int64)oVal1 > (Int64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((Int64)oVal1 >= (Int64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((Int64)oVal1 < (Int64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((Int64)oVal1 <= (Int64)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.I4)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((Int32)oVal1 == (Int32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((Int32)oVal1 != (Int32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((Int32)oVal1 > (Int32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((Int32)oVal1 >= (Int32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((Int32)oVal1 < (Int32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((Int32)oVal1 <= (Int32)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.I2)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((Int16)oVal1 == (Int16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((Int16)oVal1 != (Int16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((Int16)oVal1 > (Int16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((Int16)oVal1 >= (Int16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((Int16)oVal1 < (Int16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((Int16)oVal1 <= (Int16)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.I1)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((sbyte)oVal1 == (sbyte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((sbyte)oVal1 != (sbyte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((sbyte)oVal1 > (sbyte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((sbyte)oVal1 >= (sbyte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((sbyte)oVal1 < (sbyte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((sbyte)oVal1 <= (sbyte)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.F8)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((Double)oVal1 == (Double)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((Double)oVal1 != (Double)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((Double)oVal1 > (Double)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((Double)oVal1 >= (Double)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((Double)oVal1 < (Double)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((Double)oVal1 <= (Double)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.F4)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((Single)oVal1 == (Single)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((Single)oVal1 != (Single)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((Single)oVal1 > (Single)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((Single)oVal1 >= (Single)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((Single)oVal1 < (Single)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((Single)oVal1 <= (Single)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.U8)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((UInt64)oVal1 == (UInt64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((UInt64)oVal1 != (UInt64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((UInt64)oVal1 > (UInt64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((UInt64)oVal1 >= (UInt64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((UInt64)oVal1 < (UInt64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((UInt64)oVal1 <= (UInt64)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.U4)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((UInt32)oVal1 == (UInt32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((UInt32)oVal1 != (UInt32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((UInt32)oVal1 > (UInt32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((UInt32)oVal1 >= (UInt32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((UInt32)oVal1 < (UInt32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((UInt32)oVal1 <= (UInt32)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.U2)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((UInt16)oVal1 == (UInt16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((UInt16)oVal1 != (UInt16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((UInt16)oVal1 > (UInt16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((UInt16)oVal1 >= (UInt16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((UInt16)oVal1 < (UInt16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((UInt16)oVal1 <= (UInt16)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.U1)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((byte)oVal1 == (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((byte)oVal1 != (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((byte)oVal1 > (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((byte)oVal1 >= (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((byte)oVal1 < (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((byte)oVal1 <= (byte)oVal2 ? true : false);
                                    }
                                }
                            }
                        }   // length compare end
                    }   // ascii or no ascii if end                          
                }
                else
                {
                    if (!int.TryParse(operandValue, out operandValueLength))
                    {
                        newResult = false;
                    }
                    else
                    {
                        if (fOperation == FOperation.Equal)
                        {
                            newResult = (length == operandValueLength ? true : false);
                        }
                        else if (fOperation == FOperation.NotEqual)
                        {
                            newResult = (length != operandValueLength ? true : false);
                        }
                        else if (fOperation == FOperation.MoreThan)
                        {
                            newResult = (length > operandValueLength ? true : false);
                        }
                        else if (fOperation == FOperation.MoreThanOrEqual)
                        {
                            newResult = (length >= operandValueLength ? true : false);
                        }
                        else if (fOperation == FOperation.LessThan)
                        {
                            newResult = (length < operandValueLength ? true : false);
                        }
                        else if (fOperation == FOperation.LessThanOrEqual)
                        {
                            newResult = (length <= operandValueLength ? true : false);
                        }
                    }
                }   // comparison if end

                // --

                oldResult = compareResult(fLogical, oldResult, newResult);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListChild = null;
                fXmlNodeListOpe = null;
                fXmlNodeOpe = null;
                fXmlNodeEq = null;
                fEquipmentStateMaterial = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static bool compareResult(
            FLogical fLogical, 
            bool oldResult, 
            bool newResult
            )
        {
            try
            {
                if (fLogical == FLogical.And)
                {
                    return oldResult & newResult;
                }
                return oldResult | newResult;
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

        public static FXmlNodeList getRetryCondition(
            FSecsDriver fScd, 
            FXmlNode fXmlNodeSmgl
            )
        {
            const string SecsConditionQuery =
                FXmlTagEQM.E_EquipmentModeling +
                "/" + FXmlTagEQP.E_Equipment +
                "/" + FXmlTagSNG.E_ScenarioGroup +
                "/" + FXmlTagSNR.E_Scenario +
                "/" + FXmlTagSTR.E_SecsTrigger +
                "/" + FXmlTagSCN.E_SecsCondition +
                "[@" + FXmlTagSCN.A_ConditionMode + "='{0}' and" +
                " @" + FXmlTagSCN.A_SecsDeviceId  + "='{1}' and" +
                " @" + FXmlTagSCN.A_SecsSessionId + "='{2}' and" +
                " @" + FXmlTagSCN.A_SecsMessageId + "='{3}' and" +
                " @" + FXmlTagSCN.A_RetryCount    + "!='0']";

            // --

            string xpath = string.Empty;  

            try
            {
                xpath = string.Format(
                   SecsConditionQuery,
                   FEnumConverter.fromConditionMode(FConditionMode.Timeout),
                   fXmlNodeSmgl.get_attrVal(FXmlTagSMGL.A_SecsDeviceId, FXmlTagSMGL.D_SecsDeviceId),
                   fXmlNodeSmgl.get_attrVal(FXmlTagSMGL.A_SecsSessionId, FXmlTagSMGL.D_SecsSessionId),
                   fXmlNodeSmgl.get_attrVal(FXmlTagSMGL.A_UniqueId, FXmlTagSMGL.D_UniqueId)
                   );
                return fScd.fXmlNode.selectNodes(xpath);
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

        public static FXmlNodeList getAutoActionAlwaysSelectTransmitter(
            FSecsDriver fScd, 
            FSecsDevice fSdv
            )
        {
            const string AutoActionAlwaysSelectTransmitterQuery = 
                FXmlTagEQM.E_EquipmentModeling + "/" + 
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagSTN.E_SecsTransmitter + 
                "[" +
                "@" + FXmlTagSTN.A_AutoActionAlwaysSelect + "='{0}' and " +
                FXmlTagSTF.E_SecsTransfer + "[@" + FXmlTagSTF.A_SecsDeviceId + "='{1}']" + 
                "]";

            try
            {
                return fScd.fXmlNode.selectNodes(
                    string.Format(AutoActionAlwaysSelectTransmitterQuery, FBoolean.True, fSdv.uniqueIdToString)
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

        public static FXmlNodeList getAutoActionAlwaysCloseTransmitter(
            FSecsDriver fScd,
            FSecsDevice fSdv
            )
        {
            const string AutoActionAlwaysCloseTransmitterQuery =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagSTN.E_SecsTransmitter +
                "[" +
                "@" + FXmlTagSTN.A_AutoActionAlwaysClose + "='{0}' and " +
                FXmlTagSTF.E_SecsTransfer + "[@" + FXmlTagSTF.A_SecsDeviceId + "='{1}']" +
                "]";

            try
            {
                return fScd.fXmlNode.selectNodes(
                    string.Format(AutoActionAlwaysCloseTransmitterQuery, FBoolean.True, fSdv.uniqueIdToString)
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
