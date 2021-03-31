/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHost2.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.16
--  Description     : FAMate Core FaOpcDriver Host2 Parser Class
--  History         : Created by Jeff.Kim at 2013.07.16                    
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    internal static class FHost2
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private static void setHostMessageLogInfo(
            FXmlNode fXmlNodeHmgl,
            FXmlNode fXmlNodeHdv,
            FXmlNode fXmlNodeHsn,
            string machineId,
            int sessionId,
            FHostMessageType fHostMessageType,
            UInt32 tid
            )
        {
            try
            {
                if (fXmlNodeHdv != null)
                {
                    fXmlNodeHmgl.set_attrVal(FXmlTagHMGL.A_HostDeviceId, FXmlTagHMGL.D_HostDeviceId, fXmlNodeHdv.get_attrVal(FXmlTagHDV.A_UniqueId, FXmlTagHDV.D_UniqueId));
                    fXmlNodeHmgl.set_attrVal(FXmlTagHMGL.A_HostDeviceName, FXmlTagHMGL.D_HostDeviceName, fXmlNodeHdv.get_attrVal(FXmlTagHDV.A_Name, FXmlTagHDV.D_Name));
                }
                // --
                if (fXmlNodeHsn != null)
                {
                    fXmlNodeHmgl.set_attrVal(FXmlTagHMGL.A_HostSessionId, FXmlTagHMGL.D_HostSessionId, fXmlNodeHsn.get_attrVal(FXmlTagHSN.A_UniqueId, FXmlTagHSN.D_UniqueId));
                    fXmlNodeHmgl.set_attrVal(FXmlTagHMGL.A_HostSessionName, FXmlTagHMGL.D_HostSessionName, fXmlNodeHsn.get_attrVal(FXmlTagHSN.A_Name, FXmlTagHSN.D_Name));
                }
                // --
                fXmlNodeHmgl.set_attrVal(FXmlTagHMGL.A_MachineId, FXmlTagHMGL.D_MachineId, machineId);
                fXmlNodeHmgl.set_attrVal(FXmlTagHMGL.A_SessionId, FXmlTagHMGL.D_SessionId, sessionId.ToString());
                fXmlNodeHmgl.set_attrVal(FXmlTagHMGL.A_HostMessageType, FXmlTagHMGL.D_HostMessageType, FEnumConverter.fromHostMessageType(fHostMessageType));
                fXmlNodeHmgl.set_attrVal(FXmlTagHMGL.A_TID, FXmlTagHMGL.D_TID, tid.ToString());                
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

        private static void setHostMessageLogInfo(
            FXmlNode fXmlNodeHmgl,
            FXmlNode fXmlNodeHdv,
            FXmlNode fXmlNodeHsn,
            string machineId,
            int sessionId,
            string command,
            int version,
            FHostMessageType fHostMessageType,
            UInt32 tid
            )
        {
            try
            {
                setHostMessageLogInfo(fXmlNodeHmgl, fXmlNodeHdv, fXmlNodeHsn, machineId, sessionId, fHostMessageType, tid);
                // --
                fXmlNodeHmgl.set_attrVal(FXmlTagHMGL.A_UniqueId, FXmlTagHMGL.D_UniqueId, "0");
                fXmlNodeHmgl.set_attrVal(FXmlTagHMGL.A_Command, FXmlTagHMGL.D_Command, command);
                fXmlNodeHmgl.set_attrVal(FXmlTagHMGL.A_Version, FXmlTagHMGL.D_Version, version.ToString());
                fXmlNodeHmgl.set_attrVal(FXmlTagHMGL.A_AutoReply, FXmlTagHMGL.D_AutoReply, FBoolean.False);
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

        public static void setHostMessageLogInfo(
            FXmlNode fXmlNodeHmgl,
            FXmlNode fXmlNodeHdv,
            FXmlNode fXmlNodeHsn
            )
        {
            try
            {
                if (fXmlNodeHdv != null)
                {
                    fXmlNodeHmgl.set_attrVal(FXmlTagHMGL.A_HostDeviceId, FXmlTagHMGL.D_HostDeviceId, fXmlNodeHdv.get_attrVal(FXmlTagHDV.A_UniqueId, FXmlTagHDV.D_UniqueId));
                    fXmlNodeHmgl.set_attrVal(FXmlTagHMGL.A_HostDeviceName, FXmlTagHMGL.D_HostDeviceName, fXmlNodeHdv.get_attrVal(FXmlTagHDV.A_Name, FXmlTagHDV.D_Name));
                }
                // --
                if (fXmlNodeHsn != null)
                {
                    fXmlNodeHmgl.set_attrVal(FXmlTagHMGL.A_HostSessionId, FXmlTagHMGL.D_HostSessionId, fXmlNodeHsn.get_attrVal(FXmlTagHSN.A_UniqueId, FXmlTagHSN.D_UniqueId));
                    fXmlNodeHmgl.set_attrVal(FXmlTagHMGL.A_HostSessionName, FXmlTagHMGL.D_HostSessionName, fXmlNodeHsn.get_attrVal(FXmlTagHSN.A_Name, FXmlTagHSN.D_Name));
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

        public static FXmlNode parseHdmgToHmg(
            FOpcDriver fOcd,
            FHostDevice fHdv,
            FHostDriverDataMessage fHdmg,
            bool ignoreMachineId,
            bool ignoreFormat,
            ref FResultCode fResultCode,
            ref string resultMessage,
            ref FXmlNode fXmlNodeHsn,
            ref FXmlNode fXmlNodeRepHmg
            )
        {
            const string HostSessionQuery1 = FXmlTagHSN.E_HostSession + "[@" + FXmlTagHSN.A_MachineId + "='{0}']";
            const string HostSessionQuery2 = FXmlTagHSN.E_HostSession + "[@" + FXmlTagHSN.A_SessionId + "='{0}']";
            // --
            const string HostMessageQuery =
                FXmlTagHLM.E_HostLibraryModeling +
                "/" + FXmlTagHLG.E_HostLibraryGroup +
                "/" + FXmlTagHLB.E_HostLibrary + "[@" + FXmlTagHLB.A_UniqueId + "='{0}']" +
                "/" + FXmlTagHML.E_HostMessageList +
                "/" + FXmlTagHMS.E_HostMessages + "[@" + FXmlTagHMS.A_Direction + "='{1}' or @" + FXmlTagHMS.A_Direction + "='{2}' or @" + FXmlTagHMS.A_Direction + "='{3}']" +
                "/" + FXmlTagHMG.E_HostMessage + "[@" + FXmlTagHMG.A_Command + "='{4}']";

            // --

            FXmlNodeList fXmlNodeListHmg = null;
            FXmlNode fXmlNodeHmg = null;
            FXmlNode fXmlNodeHmgl = null;
            string direction1 = string.Empty;
            string direction2 = string.Empty;
            string direction3 = string.Empty;
            string xpath = string.Empty;

            try
            {
                // ***
                // Host Session 검색 (Machine ID로 검색 후, 존재하지 않을 경우 Session ID로 재검색)
                // ***
                if (fXmlNodeHsn == null)
                {
                    if (!ignoreMachineId && fHdmg.machineId != string.Empty)
                    {
                        fXmlNodeHsn = fHdv.fXmlNode.selectSingleNode(
                            string.Format(HostSessionQuery1, fHdmg.machineId)
                            );
                    }

                    // --

                    if (fXmlNodeHsn == null)
                    {
                        fXmlNodeHsn = fHdv.fXmlNode.selectSingleNode(
                            string.Format(HostSessionQuery2, fHdmg.sessionId.ToString())
                            );
                    }
                }

                // --

                if (fXmlNodeHsn == null)
                {
                    // ***
                    // Not Define Session
                    // ***
                    fXmlNodeHmgl = FOpcDriverLogCommon.createXmlNodeHMGL(fOcd.fOcdCore.fXmlDoc);
                    setHostMessageLogInfo(fXmlNodeHmgl, fHdv.fXmlNode, fXmlNodeHsn, fHdmg.machineId, fHdmg.sessionId, fHdmg.command, 0, fHdmg.fHostMessageType, fHdmg.tid);
                    fXmlNodeHmgl.set_attrVal(FXmlTagHMGL.A_Name, FXmlTagHMGL.D_Name, "Undefined");
                    // --
                    generateHdmgToHmg(fXmlNodeHmgl, fHdmg);
                    // --
                    fResultCode = FResultCode.Warninig;
                    resultMessage = string.Format(FConstants.err_m_0028, "Session");
                    // --
                    return fXmlNodeHmgl;
                }

                // --

                // ***
                // Host Message 검색
                // ***
                if (fXmlNodeRepHmg == null)
                {
                    direction1 = FEnumConverter.fromDirection(FDirection.Both);
                    if (fHdmg.fHostMessageType == FHostMessageType.Command || fHdmg.fHostMessageType == FHostMessageType.Unsolicited)
                    {
                        // ***
                        // Primary Host Message
                        // ***
                        if (fHdv.fDeviceMode == FDeviceMode.Equipment)
                        {
                            direction2 = FEnumConverter.fromDirection(FDirection.Host);
                            direction3 = FEnumConverter.fromDirection(FDirection.Host);
                        }
                        else if (fHdv.fDeviceMode == FDeviceMode.Host)
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
                        // Secondary Host Message
                        // ***
                        if (fHdv.fDeviceMode == FDeviceMode.Equipment)
                        {
                            direction2 = FEnumConverter.fromDirection(FDirection.Equipment);
                            direction3 = FEnumConverter.fromDirection(FDirection.Equipment);
                        }
                        else if (fHdv.fDeviceMode == FDeviceMode.Host)
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
                        HostMessageQuery,
                        fXmlNodeHsn.get_attrVal(FXmlTagHSN.A_HostLibraryId, FXmlTagHSN.D_HostLibraryId),
                        direction1,
                        direction2,
                        direction3,
                        fHdmg.command
                        );
                    // --
                    fXmlNodeListHmg = fOcd.fXmlNode.selectNodes(xpath);
                    // --
                    foreach (FXmlNode x in fXmlNodeListHmg)
                    {
                        if (compareHdmgWithHmg(x, fHdmg.fXmlNode, ignoreFormat))
                        {
                            fXmlNodeHmg = x.clone(true);
                            break;
                        }
                    }
                }
                else
                {
                    if (compareHdmgWithHmg(fXmlNodeRepHmg, fHdmg.fXmlNode, ignoreFormat))
                    {
                        fXmlNodeHmg = fXmlNodeRepHmg.clone(true);
                    }
                }

                // --

                // ***
                // Not Define Message
                // ***
                if (fXmlNodeHmg == null)
                {
                    fXmlNodeHmgl = FOpcDriverLogCommon.createXmlNodeHMGL(fOcd.fOcdCore.fXmlDoc);
                    setHostMessageLogInfo(fXmlNodeHmgl, fHdv.fXmlNode, fXmlNodeHsn, fHdmg.machineId, fHdmg.sessionId, fHdmg.command, 0, fHdmg.fHostMessageType, fHdmg.tid);
                    fXmlNodeHmgl.set_attrVal(FXmlTagOMGL.A_Name, FXmlTagOMGL.D_Name, "Undefined");
                    // --
                    generateHdmgToHmg(fXmlNodeHmgl, fHdmg);
                    // --
                    fResultCode = FResultCode.Warninig;
                    resultMessage = string.Format(FConstants.err_m_0028, "Message");
                    // --
                    return fXmlNodeHmgl;
                }

                // --

                fXmlNodeHmgl = fXmlNodeHmg.clone(false);
                setHostMessageLogInfo(fXmlNodeHmgl, fHdv.fXmlNode, fXmlNodeHsn, fHdmg.machineId, fHdmg.sessionId, fHdmg.fHostMessageType, fHdmg.tid);
                // --
                parseHdmgToHit(
                    fXmlNodeHmgl,
                    fXmlNodeHmg.selectNodes(FXmlTagHIT.E_HostItem),
                    fHdmg.fXmlNode.selectNodes(FXmlTagHIT.E_HostItem),
                    ignoreFormat
                    );

                // --

                fResultCode = FResultCode.Success;
                return fXmlNodeHmgl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListHmg = null;
                fXmlNodeHmg = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void parseHdmgToHit(
            FXmlNode fXmlNodeParent,            // Host Message Log 계열 Parent
            FXmlNodeList fXmlNodeListHit1,      // Host Message Item
            FXmlNodeList fXmlNodeListHit2,      // Host Driver Data Message Item List
            bool ignoreFormat
            )
        {
            FXmlNode fXmlNodeHit1 = null;
            FXmlNode fXmlNodeHit2 = null;
            FXmlNode fXmlNodeHitL = null;   // 1과 l이 햇갈려서 L로 표현했음.
            FXmlNode fXmlNodeHitC = null;
            FXmlNode fXmlNodeHitChild = null;
            FXmlNodeList fXmlNodeListChildHit2 = null;
            int len1 = 0;
            int len2 = 0;
            int index1 = 0;
            int index2 = 0;
            FPattern fPattern;
            FFormat fFormat1;
            FFormat fFormat2;
            int fixLen = 0;
            int varLen = 0;
            int varCnt = 0;
            int rawBytes = 0;
            string value = string.Empty;
            int length = 0;
            string genName = string.Empty;

            try
            {
                len1 = fXmlNodeListHit1.count;
                len2 = fXmlNodeListHit2.count;
                if (len1 == 0 && len2 == 0)
                {
                    return;
                }

                // --

                while (index1 < len1)
                {
                    fXmlNodeHit1 = fXmlNodeListHit1[index1];
                    fPattern = FEnumConverter.toPattern(fXmlNodeHit1.get_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern));

                    // --

                    fixLen = 0;
                    varLen = 0;
                    varCnt = 0;

                    // --

                    if (fPattern == FPattern.Fixed)
                    {
                        #region Fixed

                        fFormat1 = FEnumConverter.toFormat(fXmlNodeHit1.get_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format));
                        fixLen = int.Parse(fXmlNodeHit1.get_attrVal(FXmlTagHIT.A_FixedLength, FXmlTagHIT.D_FixedLength));

                        // --

                        for (int i = 0; i < fixLen; i++)
                        {
                            fXmlNodeHit2 = fXmlNodeListHit2[index2 + i];
                            fFormat2 = FEnumConverter.toFormat(fXmlNodeHit2.get_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format));

                            // --

                            fXmlNodeHitL = fXmlNodeParent.appendChild(fXmlNodeHit1.clone(false));
                            fXmlNodeHitL.set_attrVal(FXmlTagHITL.A_FixedLength, FXmlTagHITL.D_FixedLength, "1");

                            // --

                            if (fFormat1 == FFormat.Raw)
                            {
                                rawBytes = calculateHdmgToRawBytes(fXmlNodeHit2);
                                // --
                                fXmlNodeHitL.set_attrVal(FXmlTagHITL.A_Length, FXmlTagHITL.D_Length, rawBytes.ToString());
                            }
                            else if (fFormat1 == FFormat.Unknown)
                            {
                                if (fFormat2 == FFormat.List || fFormat2 == FFormat.AsciiList)
                                {
                                    // ***
                                    // 2017.03.23 by spike.lee
                                    // Unknown Format Item 하위 Item이 동일 이름으로 생성되어 DataSet에서 원하는 구조로 Parsing 할 수 없어 이름을
                                    // 다르게 생성하도록 처리
                                    // Fixed Length 처리에 fXmlNodeHit1에 Child를 Append하여 원본이 틀려저서 복사본(fXmlNodeHitC)으로 처리
                                    // fXmlNodeHitChild에 FixedLength가 원본을 사용하고 있어 문제가 발생 함. fXmlNodeHitChild에 Fixed Length를 1로 초기화
                                    // ***
                                    // genName = fXmlNodeHit1.get_attrVal(FXmlTagHITL.A_Name, FXmlTagHITL.D_Name) + "_";
                                    genName = fXmlNodeHit1.get_attrVal(FXmlTagHITL.A_Name, FXmlTagHITL.D_Name) + "_n";
                                    fXmlNodeHitC = fXmlNodeHit1.clone(false);
                                    fXmlNodeHitC.set_attrVal(FXmlTagHITL.A_FixedLength, FXmlTagHITL.D_FixedLength, "1");
                                    fXmlNodeListChildHit2 = fXmlNodeHit2.selectNodes(FXmlTagHIT.E_HostItem);
                                    for (int j = 0; j < fXmlNodeListChildHit2.count; j++)
                                    {
                                        fXmlNodeHitChild = fXmlNodeHitC.clone(false);
                                        // fXmlNodeHitChild.set_attrVal(FXmlTagHITL.A_Name, FXmlTagHITL.D_Name, genName + (j + 1).ToString());
                                        fXmlNodeHitChild.set_attrVal(FXmlTagHITL.A_Name, FXmlTagHITL.D_Name, genName);
                                        // --
                                        fXmlNodeHitC.appendChild(fXmlNodeHitChild);
                                    }
                                    parseHdmgToHit(
                                        fXmlNodeHitL,
                                        fXmlNodeHitC.selectNodes(FXmlTagHIT.E_HostItem),
                                        fXmlNodeListChildHit2,
                                        ignoreFormat
                                        );

                                    // --

                                    fXmlNodeHitL.set_attrVal(FXmlTagHITL.A_Format, FXmlTagHITL.D_Format, FEnumConverter.fromFormat(fFormat2));
                                    fXmlNodeHitL.set_attrVal(FXmlTagHITL.A_Length, FXmlTagHITL.D_Length, fXmlNodeListChildHit2.count.ToString());
                                }
                                else
                                {
                                    fXmlNodeHitL.set_attrVal(
                                        FXmlTagHITL.A_Format,
                                        FXmlTagHITL.D_Format,
                                        FEnumConverter.fromFormat(fFormat2)
                                        );
                                    fXmlNodeHitL.set_attrVal(
                                        FXmlTagHITL.A_Length,
                                        FXmlTagHITL.D_Length,
                                        fXmlNodeHit2.get_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length)
                                        );
                                    fXmlNodeHitL.set_attrVal(
                                        FXmlTagHITL.A_Value,
                                        FXmlTagHITL.D_Value,
                                        fXmlNodeHit2.get_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value)
                                        );
                                }
                            }
                            else
                            {
                                // ***
                                // 2012.10.24 by spike.lee
                                // ignoreFormat이 true일 경우 Define된 Host Item Format으로 처리
                                // ***
                                if (ignoreFormat)
                                {
                                    if (fFormat1 == FFormat.List || fFormat1 == FFormat.AsciiList)
                                    {
                                        fXmlNodeListChildHit2 = fXmlNodeHit2.selectNodes(FXmlTagHIT.E_HostItem);
                                        // --
                                        parseHdmgToHit(
                                            fXmlNodeHitL,
                                            fXmlNodeHit1.selectNodes(FXmlTagHIT.E_HostItem),
                                            fXmlNodeListChildHit2,
                                            ignoreFormat
                                            );

                                        // --

                                        fXmlNodeHitL.set_attrVal(FXmlTagHITL.A_Length, FXmlTagHITL.D_Length, fXmlNodeListChildHit2.count.ToString());
                                    }
                                    else
                                    {
                                        // ***
                                        // 2012.10.24 by spike.lee
                                        // ignore Format일 경우 Define된 Host Item의 Format으로 Host Driver Item의 값을
                                        // 변환하여 설정 한다.
                                        // ***
                                        length = 0;
                                        value = FValueConverter.fromStringValue(
                                            fFormat1,
                                            fXmlNodeHit2.get_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value),
                                            out length
                                            );

                                        // --

                                        fXmlNodeHitL.set_attrVal(FXmlTagHITL.A_Length, FXmlTagHITL.D_Length, length.ToString());
                                        fXmlNodeHitL.set_attrVal(FXmlTagHITL.A_Value, FXmlTagHITL.D_Value, value);
                                    }
                                }
                                else
                                {
                                    fXmlNodeHitL.set_attrVal(
                                        FXmlTagHITL.A_Length,
                                        FXmlTagHITL.D_Length,
                                        fXmlNodeHit2.get_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length)
                                        );
                                    // --
                                    if (fFormat1 == FFormat.List || fFormat1 == FFormat.AsciiList)
                                    {
                                        parseHdmgToHit(
                                            fXmlNodeHitL,
                                            fXmlNodeHit1.selectNodes(FXmlTagHIT.E_HostItem),
                                            fXmlNodeHit2.selectNodes(FXmlTagHIT.E_HostItem),
                                            ignoreFormat
                                            );
                                    }
                                    else
                                    {
                                        fXmlNodeHitL.set_attrVal(
                                            FXmlTagHITL.A_Value,
                                            FXmlTagHITL.D_Value,
                                            fXmlNodeHit2.get_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value)
                                            );
                                    }
                                }
                            }
                        }
                        index1++;
                        index2 += fixLen;

                        #endregion
                    }
                    else  // Vairable Start
                    {
                        #region Variable

                        for (int i = index1; i < len1; i++)
                        {
                            fXmlNodeHit1 = fXmlNodeListHit1[i];
                            fPattern = FEnumConverter.toPattern(fXmlNodeHit1.get_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern));
                            // --
                            if (fPattern == FPattern.Variable)
                            {
                                varLen++;
                            }
                            else
                            {
                                fixLen += int.Parse(fXmlNodeHit1.get_attrVal(FXmlTagHIT.A_FixedLength, FXmlTagHIT.D_FixedLength));
                            }
                        }

                        // --

                        varCnt = (len2 - index2 - fixLen) / varLen;

                        // --

                        for (int i = 0; i < varCnt; i++)
                        {
                            for (int j = 0; j < varLen; j++)
                            {
                                fXmlNodeHit1 = fXmlNodeListHit1[index1 + j];
                                fFormat1 = FEnumConverter.toFormat(fXmlNodeHit1.get_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format));
                                // --
                                fXmlNodeHit2 = fXmlNodeListHit2[index2];
                                fFormat2 = FEnumConverter.toFormat(fXmlNodeHit2.get_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format));
                                index2++;

                                // --

                                fXmlNodeHitL = fXmlNodeParent.appendChild(fXmlNodeHit1.clone(false));
                                fXmlNodeHitL.set_attrVal(FXmlTagHITL.A_Pattern, FXmlTagHITL.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));

                                // --

                                if (fFormat1 == FFormat.Raw)
                                {
                                    rawBytes = calculateHdmgToRawBytes(fXmlNodeHit2);
                                    // --
                                    fXmlNodeHitL.set_attrVal(FXmlTagHITL.A_Length, FXmlTagHITL.D_Length, rawBytes.ToString());
                                }
                                else if (fFormat1 == FFormat.Unknown)
                                {
                                    if (fFormat2 == FFormat.List || fFormat2 == FFormat.AsciiList)
                                    {
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // Unknown Format Item 하위 Item이 동일 이름으로 생성되어 DataSet에서 원하는 구조로 Parsing 할 수 없어 이름을
                                        // 다르게 생성하도록 처리
                                        // Variable 처리에 fXmlNodeHit1에 Child를 Append하여 원본이 틀려저서 복사본(fXmlNodeHitC)으로 처리
                                        // ***
                                        // genName = fXmlNodeHit1.get_attrVal(FXmlTagHITL.A_Name, FXmlTagHITL.D_Name) + "_";
                                        genName = fXmlNodeHit1.get_attrVal(FXmlTagHITL.A_Name, FXmlTagHITL.D_Name) + "_n";
                                        fXmlNodeHitC = fXmlNodeHit1.clone(false);
                                        fXmlNodeListChildHit2 = fXmlNodeHit2.selectNodes(FXmlTagHIT.E_HostItem);
                                        for (int k = 0; k < fXmlNodeListChildHit2.count; k++)
                                        {
                                            fXmlNodeHitChild = fXmlNodeHitC.clone(false);
                                            // fXmlNodeHitChild.set_attrVal(FXmlTagHITL.A_Name, FXmlTagHITL.D_Name, genName + (k + 1).ToString());
                                            fXmlNodeHitChild.set_attrVal(FXmlTagHITL.A_Name, FXmlTagHITL.D_Name, genName);
                                            // --
                                            fXmlNodeHitC.appendChild(fXmlNodeHitChild);
                                        }
                                        parseHdmgToHit(
                                            fXmlNodeHitL,
                                            fXmlNodeHitC.selectNodes(FXmlTagHIT.E_HostItem),
                                            fXmlNodeListChildHit2,
                                            ignoreFormat
                                            );

                                        // --

                                        fXmlNodeHitL.set_attrVal(FXmlTagHITL.A_Format, FXmlTagHITL.D_Format, FEnumConverter.fromFormat(fFormat2));
                                        fXmlNodeHitL.set_attrVal(FXmlTagHITL.A_Length, FXmlTagHITL.D_Length, fXmlNodeListChildHit2.count.ToString());
                                    }
                                    else
                                    {
                                        fXmlNodeHitL.set_attrVal(
                                            FXmlTagHITL.A_Format,
                                            FXmlTagHITL.D_Format,
                                            FEnumConverter.fromFormat(fFormat2)
                                            );
                                        fXmlNodeHitL.set_attrVal(
                                            FXmlTagHITL.A_Length,
                                            FXmlTagHITL.D_Length,
                                            fXmlNodeHit2.get_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length)
                                            );
                                        fXmlNodeHitL.set_attrVal(
                                            FXmlTagHITL.A_Value,
                                            FXmlTagHITL.D_Value,
                                            fXmlNodeHit2.get_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value)
                                            );
                                    }
                                }
                                else
                                {
                                    // ***
                                    // 2012.10.24 by spike.lee
                                    // ignoreFormat이 true일 경우 Define된 Host Item Format으로 처리
                                    // ***
                                    if (ignoreFormat)
                                    {
                                        if (fFormat1 == FFormat.List || fFormat1 == FFormat.AsciiList)
                                        {
                                            fXmlNodeListChildHit2 = fXmlNodeHit2.selectNodes(FXmlTagHIT.E_HostItem);
                                            // --
                                            parseHdmgToHit(
                                                fXmlNodeHitL,
                                                fXmlNodeHit1.selectNodes(FXmlTagHIT.E_HostItem),
                                                fXmlNodeListChildHit2,
                                                ignoreFormat
                                                );

                                            // --

                                            fXmlNodeHitL.set_attrVal(FXmlTagHITL.A_Length, FXmlTagHITL.D_Length, fXmlNodeListChildHit2.count.ToString());
                                        }
                                        else
                                        {
                                            // ***
                                            // 2012.10.24 by spike.lee
                                            // ignore Format일 경우 Define된 Host Item의 Format으로 Host Driver Item의 값을
                                            // 변환하여 설정 한다.
                                            // ***
                                            length = 0;
                                            value = FValueConverter.fromStringValue(
                                                fFormat1,
                                                fXmlNodeHit2.get_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value),
                                                out length
                                                );

                                            // --

                                            fXmlNodeHitL.set_attrVal(FXmlTagHITL.A_Length, FXmlTagHITL.D_Length, length.ToString());
                                            fXmlNodeHitL.set_attrVal(FXmlTagHITL.A_Value, FXmlTagHITL.D_Value, value);
                                        }
                                    }
                                    else
                                    {
                                        fXmlNodeHitL.set_attrVal(
                                            FXmlTagHITL.A_Length,
                                            FXmlTagHITL.D_Length,
                                            fXmlNodeHit2.get_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length)
                                            );
                                        // --
                                        if (fFormat1 == FFormat.List || fFormat1 == FFormat.AsciiList)
                                        {
                                            parseHdmgToHit(
                                                fXmlNodeHitL,
                                                fXmlNodeHit1.selectNodes(FXmlTagHIT.E_HostItem),
                                                fXmlNodeHit2.selectNodes(FXmlTagHIT.E_HostItem),
                                                ignoreFormat
                                                );
                                        }
                                        else
                                        {
                                            fXmlNodeHitL.set_attrVal(
                                                FXmlTagHITL.A_Value,
                                                FXmlTagHITL.D_Value,
                                                fXmlNodeHit2.get_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value)
                                                );
                                        }
                                    }
                                }
                            }   // for end (j)
                        }   // for end (i)
                        // --
                        index1 += varLen;

                        #endregion
                    }   // pattern end
                }   // while end
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeHit1 = null;
                fXmlNodeHit2 = null;
                fXmlNodeHitL = null;
                fXmlNodeHitC = null;
                fXmlNodeHitChild = null;
                fXmlNodeListChildHit2 = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static int calculateHdmgToRawBytes(
            FXmlNode fXmlNodeHit
            )
        {
            FFormat fFormat;
            int length = 0;
            int rawBytes = 0;

            try
            {
                fFormat = FEnumConverter.toFormat(fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format));
                length = int.Parse(fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length));
                
                // --

                rawBytes = 1;   // Format Byte 1로 설정
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                {
                    foreach (FXmlNode x in fXmlNodeHit.selectNodes(FXmlTagHIT.E_HostItem))
                    {
                        rawBytes += calculateHdmgToRawBytes(x);
                    }
                }
                else
                {
                    rawBytes += length * (int)FValueConverter.getFormatBytes(fFormat);
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

        private static bool compareHdmgWithHmg(
            FXmlNode fXmlNodeHmg, 
            FXmlNode fXmlNodeHdmg,
            bool ignoreFormat
            )
        {
            try
            {
                return compareHdmgWithHit(
                    fXmlNodeHmg.selectNodes(FXmlTagHIT.E_HostItem), 
                    fXmlNodeHdmg.selectNodes(FXmlTagHIT.E_HostItem),
                    ignoreFormat
                    );
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

        private static bool compareHdmgWithHit(
            FXmlNodeList fXmlNodeListHit1,      // Host Message Item List
            FXmlNodeList fXmlNodeListHit2,      // Host Driver Data Message Item List            
            bool ignoreFormat
            )
        {
            FXmlNode fXmlNodeHit1 = null;
            FXmlNode fXmlNodeHit2 = null;            
            int len1 = 0;
            int len2 = 0;
            int index1 = 0;
            int index2 = 0;
            FPattern fPattern;
            FFormat fFormat1;
            FFormat fFormat2;
            int fixLen = 0;
            int varLen = 0;
            int varCnt = 0;
            string preCon = string.Empty;
            bool isPreCon = false;
            int valLen = 0;
            string val = string.Empty;

            try
            {
                len1 = fXmlNodeListHit1.count;
                len2 = fXmlNodeListHit2.count;
                if (len1 == 0 && len2 == 0)
                {
                    return true;
                }

                // --

                while (index1 < len1)
                {
                    fXmlNodeHit1 = fXmlNodeListHit1[index1];
                    fPattern = FEnumConverter.toPattern(fXmlNodeHit1.get_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern));

                    // --

                    fixLen = 0;
                    varLen = 0;
                    varCnt = 0;

                    // --

                    if (fPattern == FPattern.Fixed)
                    {
                        fixLen = int.Parse(fXmlNodeHit1.get_attrVal(FXmlTagHIT.A_FixedLength, FXmlTagHIT.D_FixedLength));
                        if (index2 + fixLen > len2)
                        {
                            return false;
                        }

                        // --

                        fFormat1 = FEnumConverter.toFormat(fXmlNodeHit1.get_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format));
                        for (int i = 0; i < fixLen; i++)
                        {
                            if (fFormat1 == FFormat.Unknown || fFormat1 == FFormat.Raw)
                            {
                                continue;
                            }

                            // --

                            fXmlNodeHit2 = fXmlNodeListHit2[index2 + i];
                            fFormat2 = FEnumConverter.toFormat(fXmlNodeHit2.get_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format));                            
                            
                            // --

                            // ***
                            // 2012.10.23 by spike.lee
                            // ignoreFormat이 true일 경우 Format를 비교하지 않고
                            // Structure만 비교하도록 처리
                            // ***                            
                            if (!ignoreFormat && fFormat1 != fFormat2)
                            {
                                return false;
                            }
                            
                            // --

                            if (fFormat1 == FFormat.List || fFormat1 == FFormat.AsciiList)
                            {
                                if (!compareHdmgWithHit(fXmlNodeHit1.selectNodes(FXmlTagHIT.E_HostItem), fXmlNodeHit2.selectNodes(FXmlTagHIT.E_HostItem), ignoreFormat))
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                // ***
                                // 2012.10.23 by spike.lee
                                // ignoreFormat이 true일 경우 Structure 비교와 value Converting이 가능한지를 판단하도록 처리
                                // value가 Define된 Host Item Format로 변경 가능한지 검사
                                // ***
                                if (ignoreFormat)
                                {
                                    if (!FValueConverter.canConvertStringValue(fFormat1, fXmlNodeHit2.get_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value)))
                                    {
                                        return false;
                                    }
                                }
                                
                                // --
                                
                                // ***
                                // Precondition 적용 
                                // ***
                                valLen = int.Parse(fXmlNodeHit2.get_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length));
                                if (fFormat1 == FFormat.Ascii || fFormat1 == FFormat.JIS8 || fFormat1 == FFormat.A2 || valLen == 1)
                                {
                                    preCon = fXmlNodeHit1.get_attrVal(FXmlTagHIT.A_Precondition, FXmlTagHIT.D_Precondition);
                                    if (preCon != string.Empty)
                                    {
                                        val = fXmlNodeHit2.get_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value);
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
                            }
                        }   // for end
                        index1++;
                        index2 += fixLen;
                    }
                    else
                    {
                        for (int i = index1; i < len1; i++)
                        {
                            fXmlNodeHit1 = fXmlNodeListHit1[i];
                            fPattern = FEnumConverter.toPattern(fXmlNodeHit1.get_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern));
                            // --
                            if (fPattern == FPattern.Variable)
                            {
                                varLen++;
                            }
                            else
                            {
                                fixLen += int.Parse(fXmlNodeHit1.get_attrVal(FXmlTagHIT.A_FixedLength, FXmlTagHIT.D_FixedLength));
                            }
                        }

                        // --

                        // ***
                        // Variable 회수 구하기
                        // ***
                        if (index2 + fixLen > len2)
                        {
                            return false;   // Fixed Item 개수가 부족할 경우
                        }
                        varCnt = (len2 - index2 - fixLen) / varLen;

                        // --

                        for (int i = 0; i < varCnt; i++)
                        {
                            for (int j = 0; j < varLen; j++)
                            {
                                fXmlNodeHit1 = fXmlNodeListHit1[index1 + j];
                                fFormat1 = FEnumConverter.toFormat(fXmlNodeHit1.get_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format));
                                // --
                                fXmlNodeHit2 = fXmlNodeListHit2[index2];
                                fFormat2 = FEnumConverter.toFormat(fXmlNodeHit2.get_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format));
                                index2++;

                                // --

                                if (fFormat1 == FFormat.Unknown || fFormat1 == FFormat.Raw)
                                {
                                    continue;
                                }                                
                                else
                                {
                                    // ***
                                    // 2012.10.23 by spike.lee
                                    // ignoreFormat이 true일 경우 Format를 비교하지 않고
                                    // Structure만 비교하도록 처리
                                    // ***
                                    if (!ignoreFormat && fFormat1 != fFormat2)
                                    {
                                        return false;
                                    }

                                    // --

                                    if (fFormat1 == FFormat.List || fFormat1 == FFormat.AsciiList)
                                    {
                                        if (!compareHdmgWithHit(fXmlNodeHit1.selectNodes(FXmlTagHIT.E_HostItem), fXmlNodeHit2.selectNodes(FXmlTagHIT.E_HostItem), ignoreFormat))
                                        {
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        // ***
                                        // 2012.10.23 by spike.lee
                                        // ignoreFormat이 true일 경우 Structure 비교와 value Converting이 가능한지를 판단하도록 처리
                                        // value가 Define된 Host Item Format로 변경 가능한지 검사
                                        // ***
                                        if (ignoreFormat)
                                        {
                                            if (!FValueConverter.canConvertStringValue(fFormat1, fXmlNodeHit2.get_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value)))
                                            {
                                                return false;
                                            }
                                        }

                                        // --

                                        // ***
                                        // Precondition 적용 
                                        // ***
                                        valLen = int.Parse(fXmlNodeHit2.get_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length));
                                        if (fFormat1 == FFormat.Ascii || fFormat1 == FFormat.JIS8 || fFormat1 == FFormat.A2 || valLen == 1)
                                        {
                                            preCon = fXmlNodeHit1.get_attrVal(FXmlTagHIT.A_Precondition, FXmlTagHIT.D_Precondition);
                                            if (preCon != string.Empty)
                                            {
                                                val = fXmlNodeHit2.get_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value);
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
                                    }
                                }                                
                            }   // for end
                        }   // for end                        
                        index1 += varLen;
                    }   // Pattern end
                }   // while end

                // --

                if (index2 != len2)
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
                fXmlNodeHit1 = null;
                fXmlNodeHit2 = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void generateHdmgToHmg(
            FXmlNode fXmlNodeHmgl, 
            FHostDriverDataMessage fHdmg
            )
        {
            FXmlNodeList fXmlNodeListHit = null;

            try
            {
                fXmlNodeListHit = fHdmg.fXmlNode.selectNodes(FXmlTagHIT.E_HostItem);
                if (fXmlNodeListHit.count == 0)
                {
                    return;
                }

                // --

                foreach (FXmlNode fXmlNodeHit in fXmlNodeListHit)
                {
                    fXmlNodeHmgl.appendChild(fXmlNodeHit.clone(true));                    
                }

                // --

                foreach (FXmlNode fXmlNodeHitl in fXmlNodeHmgl.selectNodes(FXmlTagHITL.E_HostItem))
                {
                    generateHdmgToHit(fXmlNodeHitl);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListHit = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void generateHdmgToHit(
            FXmlNode fXmlNodeHitl
            )
        {
            FFormat fFormat = FFormat.Unknown;            

            try
            {
                fFormat = FEnumConverter.toFormat(fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Format, FXmlTagHITL.D_Format));

                // --

                if (fFormat == FFormat.Raw)
                {
                    fFormat = FFormat.Binary;
                    fXmlNodeHitl.set_attrVal(FXmlTagHITL.A_Format, FXmlTagHITL.D_Format, FEnumConverter.fromFormat(fFormat));
                }
                else if (fFormat == FFormat.Unknown)
                {
                    fFormat = FFormat.List;
                    fXmlNodeHitl.set_attrVal(FXmlTagHITL.A_Format, FXmlTagHITL.D_Format, FEnumConverter.fromFormat(fFormat));
                }
                // --
                fXmlNodeHitl.set_attrVal(FXmlTagHITL.A_Pattern, FXmlTagHITL.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                fXmlNodeHitl.set_attrVal(FXmlTagHITL.A_FixedLength, FXmlTagHITL.D_FixedLength, "1");

                // --

                // ***
                // 2017.04.21 by spike.lee
                // Host Driver에서 설정한 Host Item의 이름이 있을 경우에 Host Driver에서 설정한 Host Item 이름을 사용하도록 수정
                // *** 
                if (fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Name, FXmlTagHITL.D_Name) == string.Empty)
                {
                    fXmlNodeHitl.set_attrVal(FXmlTagHITL.A_Name, FXmlTagHITL.D_Name, fFormat == FFormat.List ? "L" : "I");
                }               

                // --

                if (fFormat == FFormat.List)
                {
                    foreach (FXmlNode fXmlNodeChild in fXmlNodeHitl.selectNodes(FXmlTagHITL.E_HostItem))
                    {
                        generateHdmgToHit(fXmlNodeChild);
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

        public static FXmlNode parseHmtToHdmg(
            FXmlNode fXmlNodeHmt,
            string machineId, 
            int sessionId, 
            UInt32 tid
            )
        {
            FXmlNode fXmlNodeHdmg = null;

            try
            {
                fXmlNodeHdmg = fXmlNodeHmt.clone(true);
                // --
                fXmlNodeHdmg.set_attrVal(FXmlTagHDMG.A_MachineId, FXmlTagHDMG.D_MachineId, machineId);
                fXmlNodeHdmg.set_attrVal(FXmlTagHDMG.A_SessionId, FXmlTagHDMG.D_SessionId, sessionId.ToString());
                fXmlNodeHdmg.set_attrVal(FXmlTagHDMG.A_TID, FXmlTagHDMG.D_TID, tid.ToString());
                
                // --
                
                parseHitToHdmg(fXmlNodeHdmg, fXmlNodeHdmg.selectNodes(FXmlTagHIT.E_HostItem));
                
                // --
                
                return fXmlNodeHdmg;
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

        public static void parseHitToHdmg(
            FXmlNode fXmlNodeParent, 
            FXmlNodeList fXmlNodeListHit
            )
        {
            FXmlNode fXmlNodeHit = null;
            FPattern fPattern;
            FFormat fFormat;
            int fixLen = 0;
            int len = 0;

            try
            {
                for (int i = 0; i < fXmlNodeListHit.count; i++)
                {
                    fXmlNodeHit = fXmlNodeListHit[i];
                    fPattern = FEnumConverter.toPattern(fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern));

                    // --

                    if (fPattern == FPattern.Fixed)
                    {
                        fFormat = FEnumConverter.toFormat(fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format));
                        fixLen = int.Parse(fXmlNodeHit.get_attrVal(FXmlTagHIT.A_FixedLength, FXmlTagHIT.D_FixedLength));

                        // --

                        if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                        {
                            parseHitToHdmg(fXmlNodeHit, fXmlNodeHit.selectNodes(FXmlTagHIT.E_HostItem));
                        }

                        // --

                        if (fixLen > 1)
                        {
                            fXmlNodeHit.set_attrVal(FXmlTagHIT.A_FixedLength, FXmlTagHIT.D_FixedLength, "1");

                            // --

                            for (int j = 1; j < fixLen; j++)
                            {
                                fXmlNodeHit = fXmlNodeParent.insertAfter(fXmlNodeHit.clone(true), fXmlNodeHit);
                            }

                            // --

                            // ***
                            // Parent가 Host Item인 경우 Length 추가
                            // ***
                            if (fXmlNodeParent.name == FXmlTagHIT.E_HostItem)
                            {
                                len = int.Parse(fXmlNodeParent.get_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length));
                                fXmlNodeParent.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, (len + fixLen - 1).ToString());
                            }
                        }
                    }
                    else
                    {
                        //
                        fXmlNodeParent.removeChild(fXmlNodeHit);

                        // --

                        if (fXmlNodeParent.name == FXmlTagHIT.E_HostItem)
                        {
                            len = int.Parse(fXmlNodeParent.get_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length));
                            fXmlNodeParent.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, (len - 1).ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeHit = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode parseHdmgToHmg(
            FHostDevice fHdv,
            FHostDriverDataMessage fHdmg,
            ref FResultCode fResultCode,
            ref string resultMessage,
            ref FXmlNode fXmlNodeHsn
            )
        {
            const string HostSessionQuery = FXmlTagHSN.E_HostSession + "[@" + FXmlTagHSN.A_SessionId + "='{0}']";

            // --

            FXmlNode fXmlNodeHmgl = null;

            try
            {
                fXmlNodeHsn = fHdv.fXmlNode.selectSingleNode(
                    string.Format(HostSessionQuery, fHdmg.sessionId.ToString())
                    );

                // --

                fXmlNodeHmgl = fHdmg.fXmlNode.clone(true);
                setHostMessageLogInfo(fXmlNodeHmgl, fHdv.fXmlNode, fXmlNodeHsn);

                if (fXmlNodeHsn == null)
                {
                    fResultCode = FResultCode.Warninig;
                    resultMessage = string.Format(FConstants.err_m_0028, "Session");
                }
                else
                {
                    fResultCode = FResultCode.Success;
                }
                return fXmlNodeHmgl;
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
            FOpcDriver fOcd,
            FXmlNode fXmlNodeHsn,
            string primaryUniqueId
            )
        {
            const string HostMessageQuery =
                FXmlTagHLM.E_HostLibraryModeling +
                "/" + FXmlTagHLG.E_HostLibraryGroup +
                "/" + FXmlTagHLB.E_HostLibrary + "[@" + FXmlTagHLB.A_UniqueId + "='{0}']" +
                "/" + FXmlTagHML.E_HostMessageList +
                "/" + FXmlTagHMS.E_HostMessages +
                "/" + FXmlTagHMG.E_HostMessage + "[@" + FXmlTagHMG.A_UniqueId + "='{1}']";

            // --

            FXmlNode fXmlNodeHmg = null;

            try
            {
                fXmlNodeHmg = fOcd.fXmlNode.selectSingleNode(
                    string.Format(HostMessageQuery, fXmlNodeHsn.get_attrVal(FXmlTagHSN.A_HostLibraryId, FXmlTagHSN.D_HostLibraryId), primaryUniqueId)
                    );
                if (fXmlNodeHmg == null)
                {
                    return null;
                }
                return fXmlNodeHmg.fNextSibling;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeHmg = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode[] parseTimeoutTrigger(
            FOpcDriver fPcd, 
            FXmlNode fXmlNodeHmgl,
            ref FXmlNode fXmlNodeRetryHcn
            )
        {
            const string HostConditionQuery =
                FXmlTagEQM.E_EquipmentModeling +
                "/" + FXmlTagEQP.E_Equipment +
                "/" + FXmlTagSNG.E_ScenarioGroup +
                "/" + FXmlTagSNR.E_Scenario +
                "/" + FXmlTagHTR.E_HostTrigger +
                "/" + FXmlTagHCN.E_HostCondition +
                "[@" + FXmlTagHCN.A_ConditionMode + "='{0}' and" +
                " @" + FXmlTagHCN.A_HostDeviceId + "='{1}' and" +
                " @" + FXmlTagHCN.A_HostSessionId + "='{2}' and" +
                " @" + FXmlTagHCN.A_HostMessageId + "='{3}']";

            // --

            FXmlNodeList fXmlNodeListHcn = null;
            FXmlNode fXmlNodeHtr = null;
            HashSet<string> htrKeys = null;
            ArrayList htrList = null;
            string htrUniqueId = string.Empty;
            string xpath = string.Empty;

            try
            {
                xpath = string.Format(
                    HostConditionQuery,
                    FEnumConverter.fromConditionMode(FConditionMode.Timeout),
                    fXmlNodeHmgl.get_attrVal(FXmlTagHMGL.A_HostDeviceId, FXmlTagHMGL.D_HostDeviceId),
                    fXmlNodeHmgl.get_attrVal(FXmlTagHMGL.A_HostSessionId, FXmlTagHMGL.D_HostSessionId),
                    fXmlNodeHmgl.get_attrVal(FXmlTagHMGL.A_UniqueId, FXmlTagHMGL.D_UniqueId)
                    );
                fXmlNodeListHcn = fPcd.fXmlNode.selectNodes(xpath);

                // --

                htrKeys = new HashSet<string>();
                htrList = new ArrayList();
                // --
                foreach (FXmlNode fXmlNodeHcn in fXmlNodeListHcn)
                {
                    // ***
                    // 첫번째 Retry Limit가 설정되어 있는 Condition 검색
                    // ***
                    if (fXmlNodeRetryHcn == null)
                    {
                        if (fXmlNodeHcn.get_attrVal(FXmlTagHCN.A_RetryLimit, FXmlTagHCN.D_RetryLimit) != "0")
                        {
                            fXmlNodeRetryHcn = fXmlNodeHcn;
                        }
                    }

                    // --

                    // ***
                    // 중복 조건 검사
                    // ***
                    fXmlNodeHtr = fXmlNodeHcn.fParentNode;
                    htrUniqueId = fXmlNodeHtr.get_attrVal(FXmlTagHTR.A_UniqueId, FXmlTagHTR.D_UniqueId);
                    if (htrKeys.Contains(htrUniqueId))
                    {
                        continue;
                    }

                    // --

                    htrList.Add(fXmlNodeHtr);
                    htrKeys.Add(htrUniqueId);
                }

                // --

                return (FXmlNode[])htrList.ToArray(typeof(FXmlNode));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListHcn = null;
                htrKeys = null;
                htrList = null;
                fXmlNodeHtr = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode[] parseExpressionTrigger(
            FOpcDriver fPcd, 
            FXmlNode fXmlNodeHmgl
            )
        {
            const string HostConditionQuery =
                FXmlTagEQM.E_EquipmentModeling +
                "/" + FXmlTagEQP.E_Equipment +
                "/" + FXmlTagSNG.E_ScenarioGroup +
                "/" + FXmlTagSNR.E_Scenario +
                "/" + FXmlTagHTR.E_HostTrigger +
                "/" + FXmlTagHCN.E_HostCondition +
                "[@" + FXmlTagHCN.A_ConditionMode + "='{0}' and" +
                " @" + FXmlTagHCN.A_HostDeviceId + "='{1}' and" +
                " @" + FXmlTagHCN.A_HostSessionId + "='{2}' and" +
                " @" + FXmlTagHCN.A_HostMessageId + "='{3}']";

            // --

            FXmlNodeList fXmlNodeListHcn = null;
            FXmlNodeList fXmlNodeListHep = null;
            FXmlNode fXmlNodeHtr = null;
            bool result = false;
            string xpath = string.Empty;
            HashSet<string> htrKeys = null;
            ArrayList htrList = null;
            string htrUniqueId = string.Empty;

            try
            {
                xpath = string.Format(
                    HostConditionQuery,
                    FEnumConverter.fromConditionMode(FConditionMode.Expression),
                    fXmlNodeHmgl.get_attrVal(FXmlTagHMGL.A_HostDeviceId, FXmlTagHMGL.D_HostDeviceId),
                    fXmlNodeHmgl.get_attrVal(FXmlTagHMGL.A_HostSessionId, FXmlTagHMGL.D_HostSessionId),
                    fXmlNodeHmgl.get_attrVal(FXmlTagHMGL.A_UniqueId, FXmlTagHMGL.D_UniqueId)
                    );
                fXmlNodeListHcn = fPcd.fXmlNode.selectNodes(xpath);

                // --

                htrKeys = new HashSet<string>();
                htrList = new ArrayList();
                // --
                foreach (FXmlNode fXmlNodeHcn in fXmlNodeListHcn)
                {
                    // ***
                    // 중복 조건 검색
                    // ***
                    fXmlNodeHtr = fXmlNodeHcn.fParentNode;
                    htrUniqueId = fXmlNodeHtr.get_attrVal(FXmlTagHTR.A_UniqueId, FXmlTagHTR.D_UniqueId);
                    if (htrKeys.Contains(htrUniqueId))
                    {
                        continue;
                    }

                    // --

                    result = true;
                    fXmlNodeListHep = fXmlNodeHcn.selectNodes(FXmlTagHEP.E_HostExpression);
                    foreach (FXmlNode fXmlNodeHep in fXmlNodeListHep)
                    {
                        compareCondition(fPcd, fXmlNodeHmgl, fXmlNodeHep, ref result);
                    }

                    if (result)
                    {
                        htrList.Add(fXmlNodeHtr);
                        htrKeys.Add(htrUniqueId);
                    }
                }

                // --

                return (FXmlNode[])htrList.ToArray(typeof(FXmlNode));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListHcn = null;
                fXmlNodeListHep = null;
                fXmlNodeHtr = null;
                htrKeys = null;
                htrList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode[] parseConnectionTrigger(
            FOpcDriver fPcd,
            FXmlNode fXmlNodeHdv,
            FDeviceState fDeviceState
            )
        {
            const string HostConditionQuery =
                FXmlTagEQM.E_EquipmentModeling +
                "/" + FXmlTagEQP.E_Equipment +
                "/" + FXmlTagSNG.E_ScenarioGroup +
                "/" + FXmlTagSNR.E_Scenario +
                "/" + FXmlTagHTR.E_HostTrigger +
                "/" + FXmlTagHCN.E_HostCondition +
                "[@" + FXmlTagHCN.A_ConditionMode + "='{0}' and" +
                " @" + FXmlTagHCN.A_HostDeviceId + "='{1}' and" +
                " @" + FXmlTagHCN.A_ConnectionState + "='{2}']";

            // --

            FXmlNodeList fXmlNodeListHcn = null;
            FXmlNode fXmlNodeHtr = null;
            string xpath = string.Empty;
            HashSet<string> htrKeys = null;
            ArrayList htrList = null;
            string htrUniqueId = string.Empty;

            try
            {
                xpath = string.Format(
                    HostConditionQuery,
                    FEnumConverter.fromConditionMode(FConditionMode.Connection),
                    fXmlNodeHdv.get_attrVal(FXmlTagHDV.A_UniqueId, FXmlTagHDV.D_UniqueId),
                    FEnumConverter.fromDeviceState(fDeviceState)
                    );
                fXmlNodeListHcn = fPcd.fXmlNode.selectNodes(xpath);

                // --

                htrKeys = new HashSet<string>();
                htrList = new ArrayList();
                // --
                foreach (FXmlNode fXmlNodeHcn in fXmlNodeListHcn)
                {
                    // ***
                    // 중복 조건 검색
                    // ***
                    fXmlNodeHtr = fXmlNodeHcn.fParentNode;
                    htrUniqueId = fXmlNodeHtr.get_attrVal(FXmlTagHTR.A_UniqueId, FXmlTagHTR.D_UniqueId);
                    if (htrKeys.Contains(htrUniqueId))
                    {
                        continue;
                    }

                    // --

                    htrList.Add(fXmlNodeHtr);
                    htrKeys.Add(htrUniqueId);
                }

                // --

                return (FXmlNode[])htrList.ToArray(typeof(FXmlNode));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListHcn = null;
                fXmlNodeHtr = null;
                htrKeys = null;
                htrList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void compareCondition(
            FOpcDriver fPcd, 
            FXmlNode fXmlNodeHmgl, 
            FXmlNode fXmlNodeHep, 
            ref bool oldResult
            )
        {
            const string HostItemLogQuery = ".//" + FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_UniqueId + "='{0}']";
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
            FHostOperandType fOperandType = FHostOperandType.HostItem;
            FExpressionValueType fExpressionValueType = FExpressionValueType.Value;
            FHostResourceSourceType fResourceSourceType = FHostResourceSourceType.None;
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
                fExpressionType = FEnumConverter.toExpressionType(fXmlNodeHep.get_attrVal(FXmlTagHEP.A_ExpressionType, FXmlTagHEP.D_ExpressionType));
                fLogical = FEnumConverter.toLogical(fXmlNodeHep.get_attrVal(FXmlTagHEP.A_Logical, FXmlTagHEP.D_Logical));

                // --

                if (fExpressionType == FExpressionType.Bracket)
                {
                    newResult = true;
                    fXmlNodeListChild = fXmlNodeHep.selectNodes(FXmlTagHEP.E_HostExpression);
                    foreach (FXmlNode fXmlNodeChild in fXmlNodeListChild)
                    {
                        compareCondition(fPcd, fXmlNodeHmgl, fXmlNodeChild, ref newResult);
                    }
                    oldResult = compareResult(fLogical, oldResult, newResult);
                    return;
                }

                // --

                // ***
                // Operand가 존재하지 않을 경우 False 설정
                // ***
                operandUniqueId = fXmlNodeHep.get_attrVal(FXmlTagHEP.A_OperandId, FXmlTagHEP.D_OperandId);
                if (operandUniqueId == string.Empty)
                {
                    oldResult = compareResult(fLogical, oldResult, false);
                    return;
                }

                // --

                fComparisonMode = FEnumConverter.toComparisonMode(fXmlNodeHep.get_attrVal(FXmlTagHEP.A_ComparisonMode, FXmlTagHEP.D_ComparisonMode));
                operandIndex = int.Parse(fXmlNodeHep.get_attrVal(FXmlTagHEP.A_OperandIndex, FXmlTagHEP.D_OperandIndex));
                fOperation = FEnumConverter.toOperation(fXmlNodeHep.get_attrVal(FXmlTagHEP.A_Operation, FXmlTagHEP.D_Operation));
                fOperandType = FEnumConverter.toHostOperandType(fXmlNodeHep.get_attrVal(FXmlTagHEP.A_OperandType, FXmlTagHEP.D_OperandType));
                fOperandFormat = FEnumConverter.toFormat(fXmlNodeHep.get_attrVal(FXmlTagHEP.A_OperandFormat, FXmlTagHEP.D_OperandFormat));
                fExpressionValueType = FEnumConverter.toExpressionValueType(fXmlNodeHep.get_attrVal(FXmlTagHEP.A_ExpressionValueType, FXmlTagHEP.D_ExpressionValueType));

                // --

                // ***
                // Operand Length는 Ascii 계열이외에만 사용되고 Operand Length는 0 또는 1만을 가질수 있기 때문에
                // 값이 존재하지 않을 경우 0처리하고 값이 존재할 경우 1처리한다.
                // Operand Format이 Ascii 계열인 경우 Operand Length를 사용하지 않는다.
                // ***
                if (fExpressionValueType == FExpressionValueType.Value)
                {
                    operandValue = fXmlNodeHep.get_attrVal(FXmlTagHEP.A_Value, FXmlTagHEP.D_Value);
                }
                else
                {
                    // --

                    fResourceSourceType = FEnumConverter.toHostResourceSourceType(fXmlNodeHep.get_attrVal(FXmlTagHEP.A_Resource, FXmlTagHEP.D_Resource));

                    // --

                    if (fResourceSourceType == FHostResourceSourceType.EapName)
                    {
                        operandValue = fPcd.eapName;
                    }
                    else if (fResourceSourceType == FHostResourceSourceType.EquipmentName)
                    {
                        fXmlNodeEq = fXmlNodeHep.fParentNode.fParentNode.fParentNode.fParentNode.fParentNode;
                        operandValue = fXmlNodeEq.get_attrVal(FXmlTagEQP.A_Name, FXmlTagEQP.D_Name);
                    }
                    else if (fResourceSourceType == FHostResourceSourceType.HostDeviceName)
                    {
                        operandValue = fXmlNodeHmgl.get_attrVal(FXmlTagHMGL.A_HostDeviceName, FXmlTagHMGL.D_HostDeviceName);
                    }
                    else if (fResourceSourceType == FHostResourceSourceType.HostSessionName)
                    {
                        operandValue = fXmlNodeHmgl.get_attrVal(FXmlTagHMGL.A_HostSessionName, FXmlTagHMGL.D_HostSessionName);
                    }
                    else if (fResourceSourceType == FHostResourceSourceType.HostSessionId)
                    {
                        operandValue = fXmlNodeHmgl.get_attrVal(FXmlTagHMGL.A_HostSessionId, FXmlTagHMGL.D_HostSessionId);
                    }
                    else if (fResourceSourceType == FHostResourceSourceType.HostMachineId)
                    {
                        operandValue = fXmlNodeHmgl.get_attrVal(FXmlTagHMGL.A_MachineId, FXmlTagHMGL.D_MachineId);
                    }
                    else
                    {
                        operandValue = string.Empty;
                    }
                }

                operandValueLength = (operandValue == string.Empty ? 0 : 1);

                // --

                if (fOperandType == FHostOperandType.HostItem)
                {
                    // ***
                    // Operand가 존재하지 않을 경우 False 설정
                    // ***
                    fXmlNodeListOpe = fXmlNodeHmgl.selectNodes(string.Format(HostItemLogQuery, operandUniqueId));
                    if (operandIndex >= fXmlNodeListOpe.count)
                    {
                        oldResult = compareResult(fLogical, oldResult, false);
                        return;
                    }

                    // --

                    fXmlNodeOpe = fXmlNodeListOpe[operandIndex];
                    length = int.Parse(fXmlNodeOpe.get_attrVal(FXmlTagHITL.A_Length, FXmlTagHITL.D_Length));
                    value = FValueConverter.toDataConversionStringValue(
                        fOperandFormat,
                        fXmlNodeOpe.get_attrVal(FXmlTagHITL.A_Value, FXmlTagHITL.D_Value),
                        fXmlNodeOpe.get_attrVal(FXmlTagHITL.A_Transformer, FXmlTagHITL.D_Transformer),
                        fXmlNodeOpe.get_attrVal(FXmlTagHITL.A_DataConversionSetExpression, FXmlTagHITL.D_DataConversionSetExpression),
                        ref length
                        );
                }
                else if (fOperandType == FHostOperandType.Environment)
                {
                    // ***
                    // Operand가 존재하지 않을 경우 False 설정
                    // ***
                    fXmlNodeListOpe = fPcd.fXmlNode.selectNodes(string.Format(EnvironmentQuery, operandUniqueId));
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
                else if (fOperandType == FHostOperandType.EquipmentState)
                {
                    // ***
                    // Operand가 존재하지 않을 경우 False 설정
                    // ***
                    fXmlNodeListOpe = fPcd.fXmlNode.selectNodes(string.Format(EquipmentStateQuery, operandUniqueId));
                    if (operandIndex >= fXmlNodeListOpe.count)
                    {
                        oldResult = compareResult(fLogical, oldResult, false);
                        return;
                    }

                    // --

                    fXmlNodeEq = fXmlNodeHep.fParentNode.fParentNode.fParentNode.fParentNode.fParentNode;
                    eqUniqueId = fXmlNodeEq.get_attrVal(FXmlTagEQP.A_UniqueId, FXmlTagEQP.D_UniqueId);

                    // --

                    fEquipmentStateMaterial = fPcd.fEquipmentStateMaterialStorage.getEquipmentStateMaterial(
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
                // Host Expression Transformer 적용
                // ***
                value = FValueConverter.toDataConversionStringValue(
                    fOperandFormat,
                    value,
                    fXmlNodeHep.get_attrVal(FXmlTagHEP.A_Transformer, FXmlTagHEP.D_Transformer),
                    fXmlNodeHep.get_attrVal(FXmlTagHEP.A_DataConversionSetExpression, FXmlTagHEP.D_DataConversionSetExpression),
                    ref length
                    );

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
                        newResult = (length < operandValueLength ? true : false);
                    }
                    else if (fOperation == FOperation.MoreThanOrEqual)
                    {
                        newResult = (length <= operandValueLength ? true : false);
                    }
                    else if (fOperation == FOperation.LessThan)
                    {
                        newResult = (length > operandValueLength ? true : false);
                    }
                    else if (fOperation == FOperation.LessThanOrEqual)
                    {
                        newResult = (length >= operandValueLength ? true : false);
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
            FOpcDriver fScd,
            FXmlNode fXmlNodeHmgl
            )
        {
            const string HostConditionQuery =
                FXmlTagEQM.E_EquipmentModeling +
                "/" + FXmlTagEQP.E_Equipment +
                "/" + FXmlTagSNG.E_ScenarioGroup +
                "/" + FXmlTagSNR.E_Scenario +
                "/" + FXmlTagHTR.E_HostTrigger +
                "/" + FXmlTagHCN.E_HostCondition +
                "[@" + FXmlTagHCN.A_ConditionMode + "='{0}' and" +
                " @" + FXmlTagHCN.A_HostDeviceId + "='{1}' and" +
                " @" + FXmlTagHCN.A_HostSessionId + "='{2}' and" +
                " @" + FXmlTagHCN.A_HostMessageId + "='{3}' and" +
                " @" + FXmlTagHCN.A_RetryCount + "!='0']";

            // --

            string xpath = string.Empty;

            try
            {
                xpath = string.Format(
                   HostConditionQuery,
                   FEnumConverter.fromConditionMode(FConditionMode.Timeout),
                   fXmlNodeHmgl.get_attrVal(FXmlTagHMGL.A_HostDeviceId, FXmlTagHMGL.D_HostDeviceId),
                   fXmlNodeHmgl.get_attrVal(FXmlTagHMGL.A_HostSessionId, FXmlTagHMGL.D_HostSessionId),
                   fXmlNodeHmgl.get_attrVal(FXmlTagHMGL.A_UniqueId, FXmlTagHMGL.D_UniqueId)
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
