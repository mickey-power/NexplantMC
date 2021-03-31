/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMELSECE2.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.29
--  Description     : FAMate Core FaPlcDriver MELSECE2 Parser Class
--  History         : Created by Jeff.Kim at 2013.07.29
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal static class FMelsece2
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private static void setPlcMessageLogInfo(
            FXmlNode fXmlNodePmgl,
            FXmlNode fXmlNodePdv,
            FPlcSession fPlcSession,
            string bitDeviceCode,
            UInt32 bitStartAddress,
            string wordDeviceCode,
            UInt32 wordStartAddress
            )
        {
            try
            {
                if (fXmlNodePdv != null)
                {
                    fXmlNodePmgl.set_attrVal(FXmlTagPMGL.A_PlcDeviceId, FXmlTagPMGL.D_PlcDeviceId, fXmlNodePdv.get_attrVal(FXmlTagPDV.A_UniqueId, FXmlTagPDV.D_UniqueId));
                    fXmlNodePmgl.set_attrVal(FXmlTagPMGL.A_PlcDeviceName, FXmlTagPMGL.D_PlcDeviceName, fXmlNodePdv.get_attrVal(FXmlTagPDV.A_Name, FXmlTagPDV.D_Name));
                }
                // --
                if (fPlcSession != null)
                {
                    fXmlNodePmgl.set_attrVal(FXmlTagPMGL.A_PlcSessionId, FXmlTagPMGL.D_PlcSessionId, fPlcSession.uniqueIdToString);
                    fXmlNodePmgl.set_attrVal(FXmlTagPMGL.A_PlcSessionName, FXmlTagPMGL.D_PlcSessionName, fPlcSession.name);
                    fXmlNodePmgl.set_attrVal(FXmlTagPMGL.A_SessionId, FXmlTagPMGL.D_SessionId, fPlcSession.sessionId.ToString());
                    fXmlNodePmgl.set_attrVal(
                        FXmlTagPMGL.A_LinkMapExpression, 
                        FXmlTagPMGL.D_LinkMapExpression, 
                        fPlcSession.fXmlNode.get_attrVal(FXmlTagPSN.A_LinkMapExpression, FXmlTagPSN.D_LinkMapExpression)
                        );
                }
                // --
                fXmlNodePmgl.set_attrVal(FXmlTagPMGL.A_BitDeviceCode, FXmlTagPMGL.D_BitDeviceCode, bitDeviceCode);
                fXmlNodePmgl.set_attrVal(FXmlTagPMGL.A_BitStartAddress, FXmlTagPMGL.D_BitStartAddress, bitStartAddress.ToString());
                fXmlNodePmgl.set_attrVal(FXmlTagPMGL.A_WordDeviceCode, FXmlTagPMGL.D_WordDeviceCode, wordDeviceCode);
                fXmlNodePmgl.set_attrVal(FXmlTagPMGL.A_WordStartAddress, FXmlTagPMGL.D_WordStartAddress, wordStartAddress.ToString());
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

        public static FXmlNodeList getReadMessage(
            FPlcDriver fPcd,
            FPlcSession fPsn,
            UInt32 bitAddress,
            byte bit
            )
        {
            const string PlcMessageQuery =
                FXmlTagPLM.E_PlcLibraryModeling+
                "/" + FXmlTagPLG.E_PlcLibraryGroup +
                "/" + FXmlTagPLB.E_PlcLibrary + "[@" + FXmlTagPLB.A_UniqueId + "='{0}']"  +
                "/" + FXmlTagPML.E_PlcMessageList +
                "/" + FXmlTagPMS.E_PlcMessages + "[@" + FXmlTagPMS.A_Direction + "='{1}']" +
                "/" + FXmlTagPMG.E_PlcMessage +
                "[" +
                "@" + FXmlTagPMG.A_IsPrimary + "='{2}' and " +
                "(" + FXmlTagPBL.E_PlcBitList + "/" + FXmlTagPBT.E_PlcBit + "[@" + FXmlTagPBT.A_Address + "='{3}' and @" + FXmlTagPBT.A_Value + "='{4}'])" +
                "]";

            // --

            string xpath = string.Empty;

            try
            {
                xpath = string.Format(
                    PlcMessageQuery, 
                    fPsn.fLibrary.uniqueIdToString, 
                    FEnumConverter.fromPlcDirection(FPlcDirection.Read),
                    FBoolean.True,
                    bitAddress.ToString(), 
                    bit.ToString()
                    );
                // --
                return fPcd.fXmlNode.selectNodes(xpath);
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

        public static FXmlNodeList getBitOfReadMessage(
            FXmlNode fXmlNodePrm
            )
        {
            try
            {
                return fXmlNodePrm.selectNodes(
                    FXmlTagPBL.E_PlcBitList + "/" + FXmlTagPBT.E_PlcBit
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

        public static FXmlNode getReplyMessage(
            FPlcDriver fPcd,
            FPlcSession fPsn,
            string primaryUniqueId
            )
        {
            const string PlcMessageQuery =
                FXmlTagPLM.E_PlcLibraryModeling +
                "/" + FXmlTagPLG.E_PlcLibraryGroup +
                "/" + FXmlTagPLB.E_PlcLibrary + "[@" + FXmlTagPLB.A_UniqueId + "='{0}']" +
                "/" + FXmlTagPML.E_PlcMessageList +
                "/" + FXmlTagPMS.E_PlcMessages +
                "/" + FXmlTagPMG.E_PlcMessage + "[@" + FXmlTagPMG.A_UniqueId + "='{1}']";

            // --

            FXmlNode fXmlNodePmg = null;

            try
            {
                fXmlNodePmg = fPcd.fXmlNode.selectSingleNode(
                    string.Format(PlcMessageQuery, fPsn.fLibrary.uniqueIdToString, primaryUniqueId)
                    );
                if (fXmlNodePmg == null)
                {
                    return null;
                }
                return fXmlNodePmg.fNextSibling;                
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

        public static FXmlNode parseSessionBinToPmg(
            FPlcDevice fPdv,
            FMelseceSession fMsn,
            FXmlNode fXmlNodePmg,
            string bitDeviceCode,
            UInt32 bitStartAddress,
            string wordDeviceCode,
            UInt32 wordStartAddress
            )
        {
            FXmlNode fXmlNodePmgl = null;
            FXmlNode fXmlNodePwll = null;
            FXmlNode fXmlNodePwdlCloned = null;
            FXmlNodeList fXmlNodeListPwdl = null;
            FPlcWordFormat fFormat = FPlcWordFormat.Ascii;
            UInt32 addr = 0;
            UInt32 fixedLen = 0;
            UInt32 wordLen = 0;
            UInt32 byteLen = 0;
            UInt32 formatBytes = 0;
            UInt32 length = 0;
            string value = string.Empty;

            try
            {
                fXmlNodePmgl = fXmlNodePmg.clone(true);

                // --

                // ***
                // Word Data Parsing
                // ***
                fXmlNodeListPwdl = fXmlNodePmgl.selectNodes(FXmlTagPWLL.E_PlcWordList + "/" + FXmlTagPWDL.E_PlcWord);
                foreach (FXmlNode fXmlNodePwdl in fXmlNodeListPwdl)
                {
                    fFormat = FEnumConverter.toPlcWordFormat(fXmlNodePwdl.get_attrVal(FXmlTagPWDL.A_Format, FXmlTagPWDL.D_Format));
                    addr = UInt32.Parse(fXmlNodePwdl.get_attrVal(FXmlTagPWDL.A_Address, FXmlTagPWDL.D_Address));
                    fixedLen = UInt32.Parse(fXmlNodePwdl.get_attrVal(FXmlTagPWDL.A_FixedLength, FXmlTagPWDL.D_FixedLength));
                    wordLen = UInt32.Parse(fXmlNodePwdl.get_attrVal(FXmlTagPWDL.A_Length, FXmlTagPWDL.D_Length));
                    byteLen = wordLen * 2;
                    // --
                    formatBytes = (uint)FPlcValueConverter.getPlcWordFormatBytes(fFormat);
                    length = byteLen / formatBytes;
                    
                    // --

                    fXmlNodePwll = fXmlNodePmgl.selectSingleNode(FXmlTagPWLL.E_PlcWordList);
                    fXmlNodePwdl.set_attrVal(FXmlTagPWDL.A_FixedLength, FXmlTagPWDL.D_FixedLength, FXmlTagPWDL.D_FixedLength);
                    for (int i = 0; i < fixedLen; i++)
                    {
                        value =
                            FPlcValueConverter.fromWordBinValue(
                                fFormat,
                                fMsn.getReadWord(addr, (int)byteLen),
                                (int)length,
                                (int)formatBytes
                                );
                        
                        // --
                        
                        if (i == 0)
                        {
                            fXmlNodePwdl.set_attrVal(FXmlTagPWDL.A_Value, FXmlTagPWDL.D_Value, value);
                        }
                        else
                        {
                            fXmlNodePwdlCloned = fXmlNodePwdl.clone(true);
                            fXmlNodePwdlCloned.set_attrVal(FXmlTagPWDL.A_Address, FXmlTagPWDL.D_Address, addr.ToString());
                            fXmlNodePwdlCloned.set_attrVal(FXmlTagPWDL.A_Value, FXmlTagPWDL.D_Value, value);
                            fXmlNodePwll.appendChild(fXmlNodePwdlCloned);
                        }
                        addr += wordLen;
                    }

                    
                }

                // --

                // ***
                // Device Code와 Start Address 기록하도록 수정
                // ***
                setPlcMessageLogInfo(fXmlNodePmgl, fPdv.fXmlNode, fMsn.fPlcSession, bitDeviceCode, bitStartAddress, wordDeviceCode, wordStartAddress);

                // --

                return fXmlNodePmgl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodePmgl = null;
                fXmlNodePwll = null;
                fXmlNodePwdlCloned = null;
                fXmlNodeListPwdl = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode parseMessageBinToPmg(
            FPlcDevice fPdv,
            FMelseceSession fMsn,
            FXmlNode fXmlNodePmg,
            byte[] bitBytes,
            byte[] wordBytes
            )
        {
            FXmlNode fXmlNodePmgl = null;
            FXmlNodeList fXmlNodeListPbtl = null;
            FXmlNodeList fXmlNodeListPwdl = null;
            FPlcWordFormat fFormat = FPlcWordFormat.Ascii;
            UInt32 addr = 0;
            byte[] bytes = null;
            byte bit = 0;
            UInt32 fixedLen = 0;
            UInt32 wordLen = 0;
            UInt32 byteLen = 0;
            UInt32 formatBytes = 0;
            UInt32 length = 0;
            string value = string.Empty;
            int index = 0;

            try
            {
                fXmlNodePmgl = fXmlNodePmg.clone(true);

                // --

                // ***
                // Bit Area Parse
                // ***
                index = 0;
                bytes = new byte[2];
                fXmlNodeListPbtl = fXmlNodePmgl.selectNodes(FXmlTagPBLL.E_PlcBitList + "/" + FXmlTagPBTL.E_PlcBit);                
                foreach (FXmlNode fXmlNodePbtl in fXmlNodeListPbtl)
                {
                    addr = UInt32.Parse(fXmlNodePbtl.get_attrVal(FXmlTagPBTL.A_Address, FXmlTagPBTL.D_Address));
                    // --
                    bytes[0] = bitBytes[index];
                    bytes[1] = bitBytes[index + 1];
                    bit = (byte)(FByteConverter.toUInt16(bytes, false) & 1);
                    // --
                    fXmlNodePbtl.set_attrVal(FXmlTagPBTL.A_Value, FXmlTagPBTL.D_Value, bit.ToString());
                    // --
                    index += 2; // 1 Word 단위 증가
                }

                // --

                // ***
                // Word Area Parse
                // ***
                index = 0;
                fXmlNodeListPwdl = fXmlNodePmgl.selectNodes(FXmlTagPWLL.E_PlcWordList + "/" + FXmlTagPWDL.E_PlcWord);
                foreach (FXmlNode fXmlNodePwdl in fXmlNodeListPwdl)
                {
                    fFormat = FEnumConverter.toPlcWordFormat(fXmlNodePwdl.get_attrVal(FXmlTagPWDL.A_Format, FXmlTagPWDL.D_Format));
                    fixedLen = UInt32.Parse(fXmlNodePwdl.get_attrVal(FXmlTagPWDL.A_FixedLength, FXmlTagPWDL.D_FixedLength));
                    wordLen = UInt32.Parse(fXmlNodePwdl.get_attrVal(FXmlTagPWDL.A_Length, FXmlTagPWDL.D_Length));
                    byteLen = wordLen * 2;
                    // --
                    formatBytes = (uint)FPlcValueConverter.getPlcWordFormatBytes(fFormat);
                    length = byteLen / (uint)formatBytes;
                    // --
                    for (int i = 0; i < fixedLen; i++)
                    {
                        bytes = new byte[byteLen];
                        Array.Copy(wordBytes, index, bytes, 0, byteLen);
                        index += (int)byteLen;
                        // --
                        value = FPlcValueConverter.fromWordBinValue(
                            fFormat,
                            bytes,
                            (int)length,
                            (int)formatBytes
                            );
                        // --
                        fXmlNodePwdl.set_attrVal(FXmlTagPWDL.A_Value, FXmlTagPWDL.D_Value, value);
                    }
                }

                // --

                return fXmlNodePmgl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                bytes = null;
                fXmlNodePmgl = null;
                fXmlNodeListPbtl = null;
                fXmlNodeListPwdl = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode parseWritePmgToBin(
            FPlcDevice fPdv,
            FMelseceSession fMsn,
            FXmlNode fXmlNodePmg,       
            string bitDeviceCode,
            UInt32 bitStartAddress,
            string wordDeviceCode,
            UInt32 wordStartAddress,
            FMelseceRandomParam fParam
            )
        {
            FXmlNode fXmlNodePmgl = null;
            FXmlNode fXmlNodePwll = null;
            FXmlNode fXmlNodePwdlCloned = null;
            FXmlNodeList fXmlNodeListPbtl = null;
            FXmlNodeList fXmlNodeListPwdl = null;
            FPlcWordFormat fFormat = FPlcWordFormat.Ascii;
            UInt32 addr = 0;
            UInt32 addrIndex = 0;
            UInt32 fixedLen = 0;
            UInt32 wordLen = 0;
            UInt32 byteLen = 0;
            UInt32 formatBytes = 0;
            UInt32 length = 0;
            string strVal = string.Empty;
            List<byte> byteVal = null;

            try
            {
                fXmlNodePmgl = fXmlNodePmg.clone(true);

                // --

                // ***
                // Bit Area Parse
                // ***
                fXmlNodeListPbtl = fXmlNodePmgl.selectNodes(FXmlTagPBLL.E_PlcBitList + "/" + FXmlTagPBTL.E_PlcBit);
                foreach (FXmlNode fXmlNodePbtl in fXmlNodeListPbtl)
                {
                    addr = UInt32.Parse(fXmlNodePbtl.get_attrVal(FXmlTagPBTL.A_Address, FXmlTagPBTL.D_Address));
                    strVal = fXmlNodePbtl.get_attrVal(FXmlTagPBTL.A_Value, FXmlTagPBTL.D_Value);   
                    // --
                    fParam.bitAddresses.Add(addr);
                    fParam.bits.Add((byte)(strVal == "0" ? 0x00 : 0x01));
                }

                // --

                // ***
                // Word Area Parse
                // ***
                fXmlNodeListPwdl = fXmlNodePmgl.selectNodes(FXmlTagPWLL.E_PlcWordList + "/" + FXmlTagPWDL.E_PlcWord);
                foreach (FXmlNode fXmlNodePwdl in fXmlNodeListPwdl)
                {
                    fFormat = FEnumConverter.toPlcWordFormat(fXmlNodePwdl.get_attrVal(FXmlTagPWDL.A_Format, FXmlTagPWDL.D_Format));
                    addr = UInt32.Parse(fXmlNodePwdl.get_attrVal(FXmlTagPWDL.A_Address, FXmlTagPWDL.D_Address));
                    fixedLen = UInt32.Parse(fXmlNodePwdl.get_attrVal(FXmlTagPWDL.A_FixedLength, FXmlTagPWDL.D_FixedLength));
                    wordLen = UInt32.Parse(fXmlNodePwdl.get_attrVal(FXmlTagPWDL.A_Length, FXmlTagPWDL.D_Length));
                    byteLen = wordLen * 2;
                    // --
                    // ***
                    // 2014.05.07 by spike.lee
                    // Write Word에 Value Transform 적용
                    // ***
                    strVal = FValueConverter.toTransformedStringValue(
                        (FFormat)fFormat,
                        fXmlNodePwdl.get_attrVal(FXmlTagPWDL.A_Value, FXmlTagPWDL.D_Value),
                        fXmlNodePwdl.get_attrVal(FXmlTagPWDL.A_Transformer, FXmlTagPWDL.D_Transformer)
                        );                    
                    // --
                    formatBytes = (uint)FPlcValueConverter.getPlcWordFormatBytes(fFormat);
                    length = byteLen / formatBytes;

                    // -- 

                    fXmlNodePwll = fXmlNodePmgl.selectSingleNode(FXmlTagPWLL.E_PlcWordList);
                    fXmlNodePwdl.set_attrVal(FXmlTagPWDL.A_FixedLength, FXmlTagPWDL.D_FixedLength, FXmlTagPWDL.D_FixedLength);
                    for (int i = 0; i < fixedLen; i++)
                    {
                        byteVal = new List<byte>();

                        // --

                        if (length > 0)
                        {
                            byteVal.AddRange(FPlcValueConverter.toWordBinValue(fFormat, strVal, (int)length));
                        }
                        // --
                        if (byteVal.Count < byteLen)
                        {
                            byteVal.AddRange(new byte[byteLen - byteVal.Count]);
                        }
                        else if (byteVal.Count > byteLen)
                        {
                            byteVal.RemoveRange(byteVal.Count - 1, byteVal.Count - (int)byteLen);
                        }

                        // --

                        addrIndex = 0;
                        for (int j = 0; j < byteLen; j += 2)
                        {
                            fParam.wordAddresses.Add(addr + addrIndex);
                            fParam.words.Add(byteVal.GetRange(j, 2).ToArray());
                            addrIndex++;
                        }

                        // -- 

                        if (i != 0)
                        {
                            fXmlNodePwdlCloned = fXmlNodePwdl.clone(true);
                            fXmlNodePwdlCloned.set_attrVal(FXmlTagPWDL.A_Address, FXmlTagPWDL.D_Address, addr.ToString());
                            fXmlNodePwll.appendChild(fXmlNodePwdlCloned);
                        }
                        addr += wordLen;
                    }
                }

                // --

                setPlcMessageLogInfo(fXmlNodePmgl, fPdv.fXmlNode, fMsn.fPlcSession, bitDeviceCode, bitStartAddress, wordDeviceCode, wordStartAddress);

                // --

                return fXmlNodePmgl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                byteVal = null;
                fXmlNodePmgl = null;
                fXmlNodePwll = null;
                fXmlNodePwdlCloned = null;
                fXmlNodeListPbtl = null;
                fXmlNodeListPwdl = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode parseReadPmgToBin(
            FPlcDevice fPdv,
            FMelseceSession fMsn,
            FXmlNode fXmlNodePmt,
            string bitDeviceCode,
            UInt32 bitStartAddress,
            string wordDeviceCode,
            UInt32 wordStartAddress,
            FMelseceRandomParam fParam
            )
        {
            FXmlNode fXmlNodePmgl = null;
            FXmlNode fXmlNodePwll = null;
            FXmlNode fXmlNodePwdlCloned = null;
            FXmlNodeList fXmlNodeListPbtl = null;
            FXmlNodeList fXmlNodeListPwdl = null;
            UInt32 addr = 0;
            UInt32 addrIndex = 0;
            UInt32 fixedLen = 0;
            UInt32 byteLen = 0;
            UInt32 wordLen = 0;

            try
            {
                fXmlNodePmgl = fXmlNodePmt.clone(true);

                // --

                // ***
                // Bit Area Parse
                // ***
                fXmlNodeListPbtl = fXmlNodePmgl.selectNodes(FXmlTagPBLL.E_PlcBitList + "/" + FXmlTagPBTL.E_PlcBit);
                foreach (FXmlNode fXmlNodePbtl in fXmlNodeListPbtl)
                {
                    addr = UInt32.Parse(fXmlNodePbtl.get_attrVal(FXmlTagPBTL.A_Address, FXmlTagPBTL.D_Address));
                    // --
                    fParam.bitAddresses.Add(addr);                    
                }

                // --

                // ***
                // Word Area Parse
                // ***
                fXmlNodeListPwdl = fXmlNodePmgl.selectNodes(FXmlTagPWLL.E_PlcWordList + "/" + FXmlTagPWDL.E_PlcWord);
                foreach (FXmlNode fXmlNodePwdl in fXmlNodeListPwdl)
                {
                    addr = UInt32.Parse(fXmlNodePwdl.get_attrVal(FXmlTagPWDL.A_Address, FXmlTagPWDL.D_Address));
                    fixedLen = UInt32.Parse(fXmlNodePwdl.get_attrVal(FXmlTagPWDL.A_FixedLength, FXmlTagPWDL.D_FixedLength));
                    wordLen = UInt32.Parse(fXmlNodePwdl.get_attrVal(FXmlTagPWDL.A_Length, FXmlTagPWDL.D_Length));
                    byteLen = wordLen * 2;
                    
                    // --                   

                    fXmlNodePwll = fXmlNodePmgl.selectSingleNode(FXmlTagPWLL.E_PlcWordList);
                    fXmlNodePwdl.set_attrVal(FXmlTagPWDL.A_FixedLength, FXmlTagPWDL.D_FixedLength, FXmlTagPWDL.D_FixedLength);
                    for (int i = 0; i < fixedLen; i++)
                    {
                        addrIndex = 0;
                        for (int j = 0; j < byteLen; j += 2)
                        {
                            fParam.wordAddresses.Add(addr + addrIndex);
                            addrIndex++;
                        }

                        // -- 

                        if (i != 0)
                        {
                            fXmlNodePwdlCloned = fXmlNodePwdl.clone(true);
                            fXmlNodePwdlCloned.set_attrVal(FXmlTagPWDL.A_Address, FXmlTagPWDL.D_Address, addr.ToString());
                            fXmlNodePwll.appendChild(fXmlNodePwdlCloned);
                        }
                        addr += wordLen;
                    }
                }

                // --

                setPlcMessageLogInfo(fXmlNodePmgl, fPdv.fXmlNode, fMsn.fPlcSession, bitDeviceCode, bitStartAddress, wordDeviceCode, wordStartAddress);

                // --

                return fXmlNodePmgl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodePmgl = null;
                fXmlNodePwll = null;
                fXmlNodePwdlCloned = null;
                fXmlNodeListPbtl = null;
                fXmlNodeListPwdl = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode[] parseExpressionTrigger(
            FPlcDriver fPcd, 
            FXmlNode fXmlNodePmgl
            )
        {
            const string PlcConditionQuery =
                FXmlTagEQM.E_EquipmentModeling +
                "/" + FXmlTagEQP.E_Equipment +
                "/" + FXmlTagSNG.E_ScenarioGroup +
                "/" + FXmlTagSNR.E_Scenario +
                "/" + FXmlTagPTR.E_PlcTrigger +
                "/" + FXmlTagPCN.E_PlcCondition +
                "[@" + FXmlTagPCN.A_ConditionMode + "='{0}' and" +
                " @" + FXmlTagPCN.A_PlcDeviceId   + "='{1}' and" +
                " @" + FXmlTagPCN.A_PlcSessionId  + "='{2}' and" +
                " @" + FXmlTagPCN.A_PlcMessageId  + "='{3}']";         

            // --

            FXmlNodeList fXmlNodeListPcn = null;
            FXmlNodeList fXmlNodeListPep = null;
            FXmlNode fXmlNodePtr = null;
            bool result = false;
            string xpath = string.Empty;
            HashSet<string> ptrKeys = null;
            List<FXmlNode> ptrList = null;
            string ptrUniqueId = string.Empty;

            try
            {
                ptrKeys = new HashSet<string>();
                ptrList = new List<FXmlNode>();

                xpath = string.Format(
                    PlcConditionQuery,
                    FEnumConverter.fromConditionMode(FConditionMode.Expression),
                    fXmlNodePmgl.get_attrVal(FXmlTagPMGL.A_PlcDeviceId, FXmlTagPMGL.D_PlcDeviceId),
                    fXmlNodePmgl.get_attrVal(FXmlTagPMGL.A_PlcSessionId, FXmlTagPMGL.D_PlcSessionId),
                    fXmlNodePmgl.get_attrVal(FXmlTagPMGL.A_UniqueId, FXmlTagPMGL.D_UniqueId)
                    );
                // --
                fXmlNodeListPcn = fPcd.fXmlNode.selectNodes(xpath);
                foreach (FXmlNode fXmlNodePcn in fXmlNodeListPcn)
                {
                    // ***
                    // 중복 조건 검사
                    // ***
                    fXmlNodePtr = fXmlNodePcn.fParentNode;
                    ptrUniqueId = fXmlNodePtr.get_attrVal(FXmlTagPTR.A_UniqueId, FXmlTagPTR.D_UniqueId);
                    if (ptrKeys.Contains(ptrUniqueId))
                    {
                        continue;
                    }

                    // --

                    result = true;
                    fXmlNodeListPep = fXmlNodePcn.selectNodes(FXmlTagPEP.E_PlcExpression);
                    foreach (FXmlNode fXmlNodePep in fXmlNodeListPep)
                    {
                        compareCondition(fPcd, fXmlNodePmgl, fXmlNodePep, ref result);
                    }

                    if (result)
                    {
                        ptrList.Add(fXmlNodePtr);
                        ptrKeys.Add(ptrUniqueId);
                    }
                }

                // --

                return ptrList.ToArray();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListPcn = null;
                fXmlNodeListPep = null;
                fXmlNodePtr = null;
                ptrKeys = null;
                ptrList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode[] parseConnectionTrigger(
            FPlcDriver fPcd,
            FXmlNode fXmlNodeDvcl,
            FDeviceState fDeviceState
            )
        {
            const string PlcConditionQuery =
                FXmlTagEQM.E_EquipmentModeling +
                "/" + FXmlTagEQP.E_Equipment +
                "/" + FXmlTagSNG.E_ScenarioGroup +
                "/" + FXmlTagSNR.E_Scenario +
                "/" + FXmlTagPTR.E_PlcTrigger +
                "/" + FXmlTagPCN.E_PlcCondition + "[@" + FXmlTagPCN.A_ConditionMode + "='{0}' and @" + FXmlTagPCN.A_PlcDeviceId + "='{1}' and @" + FXmlTagPCN.A_ConnectionState + "='{2}']";

            // --

            FXmlNodeList fXmlNodeListScn = null;
            FXmlNode fXmlNodeStr = null;
            string xpath = string.Empty;
            HashSet<string> strKeys = null;
            ArrayList strList = null;
            string strUniqueId = string.Empty;

            try
            {
                strKeys = new HashSet<string>();
                strList = new ArrayList();

                xpath = string.Format(
                    PlcConditionQuery,
                    FEnumConverter.fromConditionMode(FConditionMode.Connection),
                    fXmlNodeDvcl.get_attrVal(FXmlTagPDV.A_UniqueId, FXmlTagPDV.D_UniqueId),
                    FEnumConverter.fromDeviceState(fDeviceState)
                    );
                // -- 
                fXmlNodeListScn = fPcd.fXmlNode.selectNodes(xpath);
                foreach (FXmlNode fXmlNodeScn in fXmlNodeListScn)
                {

                    // ***
                    // 중복 조건 검사
                    // ***
                    fXmlNodeStr = fXmlNodeScn.fParentNode;
                    strUniqueId = fXmlNodeStr.get_attrVal(FXmlTagPTR.A_UniqueId, FXmlTagPTR.D_UniqueId);
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
                fXmlNodeStr = null;
                strKeys = null;
                strList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void compareCondition(
           FPlcDriver fScd,
           FXmlNode fXmlNodePmgl,
           FXmlNode fXmlNodePep,
           ref bool oldResult
           )
        {
            const string PlcWordLogQuery = 
                FXmlTagPWLL.E_PlcWordList +
                "/" + FXmlTagPWDL.E_PlcWord + "[@" + FXmlTagPWDL.A_UniqueId + "='{0}']";
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
            FPlcOperandType fOperandType = FPlcOperandType.PlcWord;
            FExpressionValueType fExpressionValueType = FExpressionValueType.Value;
            FPlcResourceSourceType fResourceSourceType = FPlcResourceSourceType.None;
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
                fExpressionType = FEnumConverter.toExpressionType(fXmlNodePep.get_attrVal(FXmlTagPEP.A_ExpressionType, FXmlTagPEP.D_ExpressionType));
                fLogical = FEnumConverter.toLogical(fXmlNodePep.get_attrVal(FXmlTagPEP.A_Logical, FXmlTagPEP.D_Logical));

                // --

                if (fExpressionType == FExpressionType.Bracket)
                {
                    newResult = true;
                    fXmlNodeListChild = fXmlNodePep.selectNodes(FXmlTagPEP.E_PlcExpression);
                    foreach (FXmlNode fXmlNodeChild in fXmlNodeListChild)
                    {
                        compareCondition(fScd, fXmlNodePmgl, fXmlNodeChild, ref newResult);
                    }
                    oldResult = compareResult(fLogical, oldResult, newResult);
                    return;
                }

                // --

                // ***
                // Operand가 존재하지 않을 경우 False 설정
                // ***
                operandUniqueId = fXmlNodePep.get_attrVal(FXmlTagPEP.A_OperandId, FXmlTagPEP.D_OperandId);
                if (operandUniqueId == string.Empty)
                {
                    oldResult = compareResult(fLogical, oldResult, false);
                    return;
                }

                // --

                fComparisonMode = FEnumConverter.toComparisonMode(fXmlNodePep.get_attrVal(FXmlTagPEP.A_ComparisonMode, FXmlTagPEP.D_ComparisonMode));
                operandIndex = int.Parse(fXmlNodePep.get_attrVal(FXmlTagPEP.A_OperandIndex, FXmlTagPEP.D_OperandIndex));
                fOperation = FEnumConverter.toOperation(fXmlNodePep.get_attrVal(FXmlTagPEP.A_Operation, FXmlTagPEP.D_Operation));
                fOperandType = FEnumConverter.toPlcOperandType(fXmlNodePep.get_attrVal(FXmlTagPEP.A_OperandType, FXmlTagPEP.D_OperandType));
                fOperandFormat = FEnumConverter.toFormat(fXmlNodePep.get_attrVal(FXmlTagPEP.A_OperandFormat, FXmlTagPEP.D_OperandFormat));
                fExpressionValueType = FEnumConverter.toExpressionValueType(fXmlNodePep.get_attrVal(FXmlTagPEP.A_ExpressionValueType, FXmlTagPEP.D_ExpressionValueType));

                // --

                // ***
                // Operand Length는 Ascii 계열이외에만 사용되고 Operand Length는 0 또는 1만을 가질수 있기 때문에
                // 값이 존재하지 않을 경우 0처리하고 값이 존재할 경우 1처리한다.
                // Operand Format이 Ascii 계열인 경우 Operand Length를 사용하지 않는다.
                // ***
                if (fExpressionValueType == FExpressionValueType.Value)
                {
                    operandValue = fXmlNodePep.get_attrVal(FXmlTagPEP.A_Value, FXmlTagPEP.D_Value);
                }
                else
                {
                    fResourceSourceType = FEnumConverter.toPlcResourceSourceType(fXmlNodePep.get_attrVal(FXmlTagPEP.A_Resource, FXmlTagPEP.D_Resource));

                    // --

                    if (fResourceSourceType == FPlcResourceSourceType.EapName)
                    {
                        operandValue = fScd.eapName;
                    }
                    else if (fResourceSourceType == FPlcResourceSourceType.EquipmentName)
                    {
                        fXmlNodeEq = fXmlNodePep.fParentNode.fParentNode.fParentNode.fParentNode.fParentNode;
                        operandValue = fXmlNodeEq.get_attrVal(FXmlTagEQP.A_Name, FXmlTagEQP.D_Name);
                    }
                    else if (fResourceSourceType == FPlcResourceSourceType.PlcDeviceName)
                    {
                        operandValue = fXmlNodePmgl.get_attrVal(FXmlTagPMGL.A_PlcDeviceName, FXmlTagPMGL.D_PlcDeviceName);
                    }
                    else if (fResourceSourceType == FPlcResourceSourceType.PlcSessionName)
                    {
                        operandValue = fXmlNodePmgl.get_attrVal(FXmlTagPMGL.A_PlcSessionName, FXmlTagPMGL.D_PlcSessionName);
                    }
                    else if (fResourceSourceType == FPlcResourceSourceType.PlcSessionId)
                    {
                        operandValue = fXmlNodePmgl.get_attrVal(FXmlTagPMGL.A_PlcSessionId, FXmlTagPMGL.D_PlcSessionId);
                    }
                    else
                    {
                        operandValue = string.Empty;
                    }
                }
                operandValueLength = (operandValue == string.Empty ? 0 : 1);

                // --

                if (fOperandType == FPlcOperandType.PlcWord)
                {
                    // ***
                    // Operand가 존재하지 않을 경우 False 설정
                    // ***
                    fXmlNodeListOpe = fXmlNodePmgl.selectNodes(string.Format(PlcWordLogQuery, operandUniqueId));
                    if (operandIndex >= fXmlNodeListOpe.count)
                    {
                        oldResult = compareResult(fLogical, oldResult, false);
                        return;
                    }

                    // --

                    fXmlNodeOpe = fXmlNodeListOpe[operandIndex];
                    length = int.Parse(fXmlNodeOpe.get_attrVal(FXmlTagPWDL.A_Length, FXmlTagPWDL.D_Length));
                    length = (length * 2) / FPlcValueConverter.getPlcWordFormatBytes((FPlcWordFormat)fOperandFormat); // 실제 Value Length로 변환
                    value = FValueConverter.toDataConversionStringValue(
                        fOperandFormat,
                        fXmlNodeOpe.get_attrVal(FXmlTagPWDL.A_Value, FXmlTagPWDL.D_Value),
                        fXmlNodeOpe.get_attrVal(FXmlTagPWDL.A_Transformer, FXmlTagPWDL.D_Transformer),
                        fXmlNodeOpe.get_attrVal(FXmlTagPWDL.A_DataConversionSetExpression, FXmlTagPWDL.D_DataConversionSetExpression),
                        ref length
                        );
                }
                else if (fOperandType == FPlcOperandType.Environment)
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
                else if (fOperandType == FPlcOperandType.EquipmentState)
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

                    fXmlNodeEq = fXmlNodePep.fParentNode.fParentNode.fParentNode.fParentNode.fParentNode;
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
                // PLC Expression Transformer 적용
                // ***
                value = FValueConverter.toDataConversionStringValue(
                    fOperandFormat,
                    value,
                    fXmlNodePep.get_attrVal(FXmlTagPEP.A_Transformer, FXmlTagPEP.D_Transformer),
                    fXmlNodePep.get_attrVal(FXmlTagPEP.A_DataConversionSetExpression, FXmlTagPEP.D_DataConversionSetExpression),
                    ref length
                    );

                // --

                newResult = true;

                // --

                if (fComparisonMode == FComparisonMode.Value)
                {
                    if (fOperandFormat == FFormat.Ascii)
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
