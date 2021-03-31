/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FRepositoryHandler.cs
--  Creator         : spike.lee
--  Create Date     : 2013.11.14
--  Description     : FAMate Core FaTcpDriver Repository Handler Class 
--  History         : Created by spike.lee at 2013.11.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    internal static class FRepositoryHandler
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static FXmlNode createRepository(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeStg,
            ref FRepositoryMaterial fRepositoryMaterial
            )
        {
            const string RepositoryQuery =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagRPD.E_RepositoryDefinition +
                "/" + FXmlTagRPL.E_RepositoryList +
                "/" + FXmlTagRPS.E_Repository + "[@" + FXmlTagRPS.A_UniqueId + "='{0}']";

            // --

            FXmlNode fXmlNodeRps = null;
            FXmlNode fXmlNodeRpsl = null;
            FXmlNode fXmlNodeRpm = null;
            string id = string.Empty;
            string xpath = string.Empty;

            try
            {
                fRepositoryMaterial = null;

                // --

                id = fXmlNodeStg.get_attrVal(FXmlTagSTG.A_RepositoryId, FXmlTagSTG.D_RepositoryId);
                if (id == string.Empty)
                {
                    return null;
                }

                // --

                xpath = string.Format(RepositoryQuery, id);
                fXmlNodeRps = fScenarioData.fTcdCore.fTcpDriver.fXmlNode.selectSingleNode(xpath).clone(true);                

                // --

                if (fScenarioData.hasMapperPerformedLog && fScenarioData.fMapperPerformedLog.hasDataSetLog)
                {
                    fXmlNodeRpsl = FDataMapper.generateRepository(
                        fScenarioData,
                        fXmlNodeRps
                        );
                }
                // --
                FDataMapper.generateRepositoryByPattern(fScenarioData, fXmlNodeRpsl);

                // --

                // ***
                // 2017.04.04 by spike.lee
                // Repository Material Save 구현
                // Repository Material ID 부여
                // Repository Material Last Access Time 설정
                // ***
                fXmlNodeRpsl.set_attrVal(FXmlTagRPSL.A_RpmId, FXmlTagRPSL.D_RpmId, fScenarioData.fTcdCore.fRpmIdPointer.uniqueId.ToString());
                fXmlNodeRpsl.set_attrVal(FXmlTagRPSL.A_LastAccessTime, FXmlTagRPSL.D_LastAccessTime, FDataConvert.defaultNowDateTimeToString());

                // --

                // ***
                // RepositoryMaterial 저장
                // ***
                fXmlNodeRpm = fXmlNodeRpsl.clone(true);
                fXmlNodeRpm.set_attrVal(FXmlTagRPM.A_RepositoryType, FXmlTagRPM.D_RepositoryType, FXmlTagRPM.R_RepositoryMaterial);
                fRepositoryMaterial = new FRepositoryMaterial(fScenarioData.fTcdCore, fXmlNodeRpm);                

                // --

                return fXmlNodeRpsl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeRps = null;
            }
            return null;
        }                

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode selectRepository(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeStg,
            ref FRepositoryMaterial fRepositoryMaterial
            )
        {
            const string RepositoryQuery =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagRPD.E_RepositoryDefinition +
                "/" + FXmlTagRPL.E_RepositoryList +
                "/" + FXmlTagRPS.E_Repository + "[@" + FXmlTagRPS.A_UniqueId + "='{0}']";
            // --
            const string PartColumnQuery = ".//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_PartTag + "]";
            //--
            const string PartListColumnQuery =
                ".//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_PartTag + " and (@" + FXmlTagCOL.A_Format + "='{0}' or @" + FXmlTagCOL.A_Format + "='{1}')]";

            // --

            FXmlNode fXmlNodeRps = null;
            FXmlNode fXmlNodeRpm = null;
            FXmlNode fXmlNodeDtsl = null;
            FXmlNode fXmlNodeRpsl = null;
            FXmlNode fXmlNodeParent = null;
            FXmlNodeList fXmlNodeListChild = null;
            List<FXmlNode> fSourceList = null;
            List<FXmlNode> fTargetList = null;
            FMessageLogType fMessageLogType;
            FHostDeviceDataMessageReceivedLog fHdmrl = null;
            FHostDeviceDataMessageSentLog fHdmsl = null;            
            string id = string.Empty;            
            string xpath = string.Empty;
            UInt64 deviceUniqueId = 0;
            UInt64 sessionUniqueId = 0;
            UInt32 tid = 0;
            List<List<string>> colXPathList = null;
            FFormat fFormat = FFormat.List;
            int childCnt = 0;

            try
            {
                fRepositoryMaterial = null;

                // --

                id = fXmlNodeStg.get_attrVal(FXmlTagSTG.A_RepositoryId, FXmlTagSTG.D_RepositoryId);
                if (id == string.Empty)
                {
                    return null;
                }

                // --

                // ***
                // Data Set에 의한 Repository Material 검색
                // ***
                #region Search Repository Material by Data Set

                if (fScenarioData.hasMapperPerformedLog && fScenarioData.fMapperPerformedLog.hasDataSetLog)
                {
                    colXPathList = new List<List<string>>();

                    // --

                    xpath = string.Format(RepositoryQuery, id);
                    fXmlNodeRps = fScenarioData.fTcdCore.fTcpDriver.fXmlNode.selectSingleNode(xpath);       

                    // --

                    fXmlNodeDtsl = fScenarioData.fMapperPerformedLog.getDataSetLog().fXmlNode;
                    makeRepositorySelectPath(fXmlNodeRps, fXmlNodeDtsl.selectNodes(FXmlTagDATL.E_Data), colXPathList);

                    // --

                    if (colXPathList.Count > 0)
                    {
                        foreach (FRepositoryMaterial fRpm in fScenarioData.fTcdCore.fRepositoryMaterialStorage.fRepositoryMaterialCollection)
                        {
                            if (id != fRpm.uniqueIdToString)
                            {
                                continue;
                            }

                            // --

                            fRepositoryMaterial = fRpm;
                            fXmlNodeRpm = fRepositoryMaterial.fXmlNode;
                            // --
                            fSourceList = new List<FXmlNode>();
                            fSourceList.Add(fXmlNodeRpm);
                            // --
                            foreach (List<string> colXPath in colXPathList)
                            {
                                if (colXPath.Count == 0)
                                {
                                    fRepositoryMaterial = null;
                                    continue;
                                }
                                else
                                {
                                    fRepositoryMaterial = fRpm;
                                }

                                // --

                                fTargetList = new List<FXmlNode>();
                                // --
                                foreach (string key in colXPath)
                                {
                                    foreach (FXmlNode fXmlNodeSrc in fSourceList)
                                    {
                                        if (fXmlNodeSrc.containsNode(key))
                                        {
                                            foreach (FXmlNode fXmlNodeTgt in fXmlNodeSrc.selectNodes(key))
                                            {
                                                fTargetList.Add(fXmlNodeTgt.fParentNode);
                                            }
                                        }
                                        else
                                        {
                                            fRepositoryMaterial = null;
                                            break;
                                        }
                                    }   // fXmlNodeSrc end
                                    // --
                                    if (fRepositoryMaterial == null)
                                    {
                                        break;
                                    }
                                }   // colXPath end
                                // --
                                if (fRepositoryMaterial == null)
                                {
                                    break;
                                }
                                // --
                                fSourceList = fTargetList;
                            }   // colXPathList end
                            // --
                            if (fRepositoryMaterial != null)
                            {
                                break;
                            }
                        }
                    }
                }

                #endregion

                // --

                // ***
                // Reply Key에 의한 Repository Material 검색
                // ***
                #region Search Repository by Reply Key

                if (fRepositoryMaterial == null && fScenarioData.hasDataMessageReceivedLog)
                {
                    fMessageLogType = fScenarioData.fDataMessageReceivedLog.fMessageLogType;
                    // --                    
                    if (fMessageLogType == FMessageLogType.HostDeviceDataMessageReceivedLog)
                    {
                        fHdmrl = (FHostDeviceDataMessageReceivedLog)fScenarioData.fDataMessageReceivedLog;
                        if (fHdmrl.isSecondary)
                        {
                            deviceUniqueId = fHdmrl.deviceUniqueId;
                            sessionUniqueId = fHdmrl.sessionUniqueId;
                            tid = fHdmrl.tid;
                            // --
                            foreach (FRepositoryMaterial fRtm in fScenarioData.fTcdCore.fRepositoryMaterialStorage.fRepositoryMaterialCollection)
                            {
                                if (
                                    id == fRtm.uniqueIdToString &&
                                    fRtm.containsHostReplyKey(deviceUniqueId, sessionUniqueId, tid)
                                    )
                                {
                                    fRepositoryMaterial = fRtm;
                                    break;
                                }
                            }
                        }
                    }
                    else if (fMessageLogType == FMessageLogType.HostDeviceDataMessageSentLog)
                    {
                        fHdmsl = (FHostDeviceDataMessageSentLog)fScenarioData.fDataMessageReceivedLog;
                        if (fHdmsl.isPrimary)
                        {
                            deviceUniqueId = fHdmsl.deviceUniqueId;
                            sessionUniqueId = fHdmsl.sessionUniqueId;
                            tid = fHdmsl.tid;
                            // --
                            foreach (FRepositoryMaterial fRtm in fScenarioData.fTcdCore.fRepositoryMaterialStorage.fRepositoryMaterialCollection)
                            {
                                if (
                                    id == fRtm.uniqueIdToString &&
                                    fRtm.containsHostReplyKey(deviceUniqueId, sessionUniqueId, tid)
                                    )
                                {
                                    fRepositoryMaterial = fRtm;
                                    break;
                                }
                            }
                        }
                    }
                }

                #endregion

                // --

                if (fRepositoryMaterial != null)
                {
                    fXmlNodeRpm = fRepositoryMaterial.fXmlNode;

                    // --

                    // ***
                    // 2017.04.04 by spike.lee
                    // Repository Material Save 구현
                    // Repository Material Last Access Time 설정
                    // ***
                    fXmlNodeRpm.set_attrVal(FXmlTagRPM.A_LastAccessTime, FXmlTagRPM.D_LastAccessTime, FDataConvert.defaultNowDateTimeToString());

                    // --

                    // ***
                    // Repository Material의 모든 Column의 Part Tag 제거
                    // ***
                    foreach (FXmlNode fXmlNode in fXmlNodeRpm.selectNodes(PartColumnQuery))
                    {
                        fXmlNode.set_attrVal(FXmlTagCOL.A_PartTag, FXmlTagCOL.D_PartTag, FXmlTagCOL.D_PartTag);
                    }

                    // --

                    if (
                        colXPathList != null &&
                        colXPathList.Count > 0 &&
                        fXmlNodeStg.get_attrVal(FXmlTagSTG.A_Mode, FXmlTagSTG.D_Mode) == FEnumConverter.fromStorageMode(FStorageMode.Part)
                        )
                    {
                        #region Part Repository

                        // ***
                        // Repository Material의 Part Column Marking
                        // ***
                        fSourceList = new List<FXmlNode>();
                        fSourceList.Add(fXmlNodeRpm);
                        // --
                        foreach (List<string> colXPath in colXPathList)
                        {
                            if (colXPath.Count == 0)
                            {
                                continue;
                            }

                            // --
                            fTargetList = new List<FXmlNode>();
                            // --
                            foreach (string key in colXPath)
                            {
                                foreach (FXmlNode fXmlNodeSrc in fSourceList)
                                {
                                    foreach (FXmlNode fXmlNodeTgt in fXmlNodeSrc.selectNodes(key))
                                    {
                                        fXmlNodeParent = fXmlNodeTgt.fParentNode;
                                        fTargetList.Add(fXmlNodeParent);
                                        while (fXmlNodeParent.name == FXmlTagCOL.E_Column)
                                        {
                                            fXmlNodeParent.set_attrVal(FXmlTagCOL.A_PartTag, FXmlTagCOL.D_PartTag, FBoolean.True);
                                            fXmlNodeParent = fXmlNodeParent.fParentNode;
                                        }
                                    }
                                }
                            }
                            // --
                            fSourceList = fTargetList;
                        }

                        // --

                        // ***
                        // Repository Log의 Part Column이 아닌 Column 제거
                        // ***
                        fXmlNodeRpsl = fXmlNodeRpm.clone(true);
                        // --
                        xpath = string.Format(PartListColumnQuery, FFormatShortName.L.ToString(), FFormatShortName.AL.ToString());
                        foreach (FXmlNode fXmlNode in fXmlNodeRpsl.selectNodes(xpath))
                        {
                            fXmlNodeParent = fXmlNode.fParentNode;
                            // --
                            fXmlNodeListChild = fXmlNodeParent.selectNodes(FXmlTagCOLL.E_Column);
                            childCnt = fXmlNodeListChild.count;
                            foreach (FXmlNode fXmlNodeChild in fXmlNodeListChild)
                            {
                                fFormat = FEnumConverter.toFormat(fXmlNodeChild.get_attrVal(FXmlTagCOLL.A_Format, FXmlTagCOLL.D_Format));
                                if (fFormat != FFormat.List && fFormat != FFormat.AsciiList)
                                {
                                    continue;
                                }
                                // --
                                if (fXmlNodeChild.get_attrVal(FXmlTagCOLL.A_PartTag, FXmlTagCOLL.D_PartTag) != FBoolean.True)
                                {
                                    fXmlNodeParent.removeChild(fXmlNodeChild);
                                    childCnt -= 1;
                                }
                            }
                            // --
                            if (fXmlNodeParent.name == FXmlTagCOLL.E_Column)
                            {
                                fXmlNodeParent.set_attrVal(FXmlTagCOLL.A_Length, FXmlTagCOLL.D_Length, childCnt.ToString());
                            }
                        }

                        // --

                        // ***
                        // Repository Log의 모든 Column의 Part Tag 제거
                        // ***
                        foreach (FXmlNode fXmlNode in fXmlNodeRpsl.selectNodes(PartColumnQuery))
                        {
                            fXmlNode.set_attrVal(FXmlTagCOL.A_PartTag, FXmlTagCOL.D_PartTag, FXmlTagCOL.D_PartTag);
                        }

                        #endregion
                    }
                    else
                    {
                        #region All Repository

                        fXmlNodeRpsl = fXmlNodeRpm.clone(true);

                        #endregion
                    }

                    // --

                    fXmlNodeRpsl.set_attrVal(FXmlTagRPSL.A_RepositoryType, FXmlTagRPSL.D_RepositoryType, FXmlTagRPSL.R_Repository);
                }

                // --

                return fXmlNodeRpsl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeRps = null;
                fXmlNodeRpm = null;
                fXmlNodeDtsl = null;
                fXmlNodeParent = null;
                fXmlNodeListChild = null;
                fHdmrl = null;
                colXPathList = null;
                fSourceList = null;
                fTargetList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode selectRepositoryByKey(
        FScenarioData fScenarioData,
        FXmlNode fXmlNodeStg,
        ref FRepositoryMaterial fRepositoryMaterial
        )
        {
            const string RepositoryQuery =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagRPD.E_RepositoryDefinition +
                "/" + FXmlTagRPL.E_RepositoryList +
                "/" + FXmlTagRPS.E_Repository + "[@" + FXmlTagRPS.A_UniqueId + "='{0}']";
            // --
            const string PartColumnQuery = ".//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_PartTag + "]";
            //--
            const string PartListColumnQuery =
                ".//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_PartTag + " and (@" + FXmlTagCOL.A_Format + "='{0}' or @" + FXmlTagCOL.A_Format + "='{1}')]";

            // --

            FXmlNode fXmlNodeRps = null;
            FXmlNode fXmlNodeRpm = null;
            FXmlNode fXmlNodeDtsl = null;
            FXmlNode fXmlNodeRpsl = null;
            FXmlNode fXmlNodeParent = null;
            FXmlNodeList fXmlNodeListChild = null;
            List<FXmlNode> fSourceList = null;
            List<FXmlNode> fTargetList = null;
            FMessageLogType fMessageLogType;
            FHostDeviceDataMessageReceivedLog fHdmrl = null;
            FHostDeviceDataMessageSentLog fHdmsl = null;
            string id = string.Empty;
            string xpath = string.Empty;
            UInt64 deviceUniqueId = 0;
            UInt64 sessionUniqueId = 0;
            UInt32 tid = 0;
            List<List<string>> colXPathList = null;
            FFormat fFormat = FFormat.List;
            int childCnt = 0;

            try
            {
                fRepositoryMaterial = null;

                // --

                id = fXmlNodeStg.get_attrVal(FXmlTagSTG.A_RepositoryId, FXmlTagSTG.D_RepositoryId);
                if (id == string.Empty)
                {
                    return null;
                }

                // --

                // ***
                // Data Set에 의한 Repository Material 검색
                // ***
                #region Search Repository Material by Data Set

                if (fScenarioData.hasMapperPerformedLog && fScenarioData.fMapperPerformedLog.hasDataSetLog)
                {
                    colXPathList = new List<List<string>>();

                    // --

                    xpath = string.Format(RepositoryQuery, id);
                    fXmlNodeRps = fScenarioData.fTcdCore.fTcpDriver.fXmlNode.selectSingleNode(xpath);

                    // --

                    fXmlNodeDtsl = fScenarioData.fMapperPerformedLog.getDataSetLog().fXmlNode;
                    makeRepositorySelectPathByKey(fXmlNodeRps, fXmlNodeDtsl.selectNodes(FXmlTagDATL.E_Data), colXPathList);

                    // --

                    if (colXPathList.Count > 0)
                    {
                        foreach (FRepositoryMaterial fRpm in fScenarioData.fTcdCore.fRepositoryMaterialStorage.fRepositoryMaterialCollection)
                        {
                            if (id != fRpm.uniqueIdToString)
                            {
                                continue;
                            }

                            // --

                            fRepositoryMaterial = fRpm;
                            fXmlNodeRpm = fRepositoryMaterial.fXmlNode;
                            // --
                            fSourceList = new List<FXmlNode>();
                            fSourceList.Add(fXmlNodeRpm);
                            // --
                            foreach (List<string> colXPath in colXPathList)
                            {
                                if (colXPath.Count == 0)
                                {
                                    fRepositoryMaterial = null;
                                    continue;
                                }
                                else
                                {
                                    fRepositoryMaterial = fRpm;
                                }

                                // --

                                fTargetList = new List<FXmlNode>();
                                // --
                                foreach (string key in colXPath)
                                {
                                    foreach (FXmlNode fXmlNodeSrc in fSourceList)
                                    {
                                        if (fXmlNodeSrc.containsNode(key))
                                        {
                                            foreach (FXmlNode fXmlNodeTgt in fXmlNodeSrc.selectNodes(key))
                                            {
                                                fTargetList.Add(fXmlNodeTgt.fParentNode);
                                            }
                                        }
                                        else
                                        {
                                            fRepositoryMaterial = null;
                                            break;
                                        }
                                    }   // fXmlNodeSrc end
                                    // --
                                    if (fRepositoryMaterial == null)
                                    {
                                        break;
                                    }
                                }   // colXPath end
                                // --
                                if (fRepositoryMaterial == null)
                                {
                                    break;
                                }
                                // --
                                fSourceList = fTargetList;
                            }   // colXPathList end
                            // --
                            if (fRepositoryMaterial != null)
                            {
                                break;
                            }
                        }
                    }
                }

                #endregion

                // --

                // ***
                // Reply Key에 의한 Repository Material 검색
                // ***
                #region Search Repository by Reply Key

                if (fRepositoryMaterial == null && fScenarioData.hasDataMessageReceivedLog)
                {
                    fMessageLogType = fScenarioData.fDataMessageReceivedLog.fMessageLogType;
                    // --                    
                    if (fMessageLogType == FMessageLogType.HostDeviceDataMessageReceivedLog)
                    {
                        fHdmrl = (FHostDeviceDataMessageReceivedLog)fScenarioData.fDataMessageReceivedLog;
                        if (fHdmrl.isSecondary)
                        {
                            deviceUniqueId = fHdmrl.deviceUniqueId;
                            sessionUniqueId = fHdmrl.sessionUniqueId;
                            tid = fHdmrl.tid;
                            // --
                            foreach (FRepositoryMaterial fRtm in fScenarioData.fTcdCore.fRepositoryMaterialStorage.fRepositoryMaterialCollection)
                            {
                                if (
                                    id == fRtm.uniqueIdToString &&
                                    fRtm.containsHostReplyKey(deviceUniqueId, sessionUniqueId, tid)
                                    )
                                {
                                    fRepositoryMaterial = fRtm;
                                    break;
                                }
                            }
                        }
                    }
                    else if (fMessageLogType == FMessageLogType.HostDeviceDataMessageSentLog)
                    {
                        fHdmsl = (FHostDeviceDataMessageSentLog)fScenarioData.fDataMessageReceivedLog;
                        if (fHdmsl.isPrimary)
                        {
                            deviceUniqueId = fHdmsl.deviceUniqueId;
                            sessionUniqueId = fHdmsl.sessionUniqueId;
                            tid = fHdmsl.tid;
                            // --
                            foreach (FRepositoryMaterial fRtm in fScenarioData.fTcdCore.fRepositoryMaterialStorage.fRepositoryMaterialCollection)
                            {
                                if (
                                    id == fRtm.uniqueIdToString &&
                                    fRtm.containsHostReplyKey(deviceUniqueId, sessionUniqueId, tid)
                                    )
                                {
                                    fRepositoryMaterial = fRtm;
                                    break;
                                }
                            }
                        }
                    }
                }

                #endregion

                // --

                if (fRepositoryMaterial != null)
                {
                    fXmlNodeRpm = fRepositoryMaterial.fXmlNode;

                    // --

                    // ***
                    // 2017.04.04 by spike.lee
                    // Repository Material Save 구현
                    // Repository Material Last Access Time 설정
                    // ***
                    fXmlNodeRpm.set_attrVal(FXmlTagRPM.A_LastAccessTime, FXmlTagRPM.D_LastAccessTime, FDataConvert.defaultNowDateTimeToString());

                    // --

                    // ***
                    // Repository Material의 모든 Column의 Part Tag 제거
                    // ***
                    foreach (FXmlNode fXmlNode in fXmlNodeRpm.selectNodes(PartColumnQuery))
                    {
                        fXmlNode.set_attrVal(FXmlTagCOL.A_PartTag, FXmlTagCOL.D_PartTag, FXmlTagCOL.D_PartTag);
                    }

                    // --

                    if (
                        colXPathList != null &&
                        colXPathList.Count > 0 &&
                        fXmlNodeStg.get_attrVal(FXmlTagSTG.A_Mode, FXmlTagSTG.D_Mode) == FEnumConverter.fromStorageMode(FStorageMode.Part)
                        )
                    {
                        #region Part Repository

                        // ***
                        // Repository Material의 Part Column Marking
                        // ***
                        fSourceList = new List<FXmlNode>();
                        fSourceList.Add(fXmlNodeRpm);
                        // --
                        foreach (List<string> colXPath in colXPathList)
                        {
                            if (colXPath.Count == 0)
                            {
                                continue;
                            }

                            // --
                            fTargetList = new List<FXmlNode>();
                            // --
                            foreach (string key in colXPath)
                            {
                                foreach (FXmlNode fXmlNodeSrc in fSourceList)
                                {
                                    foreach (FXmlNode fXmlNodeTgt in fXmlNodeSrc.selectNodes(key))
                                    {
                                        fXmlNodeParent = fXmlNodeTgt.fParentNode;
                                        fTargetList.Add(fXmlNodeParent);
                                        while (fXmlNodeParent.name == FXmlTagCOL.E_Column)
                                        {
                                            fXmlNodeParent.set_attrVal(FXmlTagCOL.A_PartTag, FXmlTagCOL.D_PartTag, FBoolean.True);
                                            fXmlNodeParent = fXmlNodeParent.fParentNode;
                                        }
                                    }
                                }
                            }
                            // --
                            fSourceList = fTargetList;
                        }

                        // --

                        // ***
                        // Repository Log의 Part Column이 아닌 Column 제거
                        // ***
                        fXmlNodeRpsl = fXmlNodeRpm.clone(true);
                        // --
                        xpath = string.Format(PartListColumnQuery, FFormatShortName.L.ToString(), FFormatShortName.AL.ToString());
                        foreach (FXmlNode fXmlNode in fXmlNodeRpsl.selectNodes(xpath))
                        {
                            fXmlNodeParent = fXmlNode.fParentNode;
                            // --
                            fXmlNodeListChild = fXmlNodeParent.selectNodes(FXmlTagCOLL.E_Column);
                            childCnt = fXmlNodeListChild.count;
                            foreach (FXmlNode fXmlNodeChild in fXmlNodeListChild)
                            {
                                fFormat = FEnumConverter.toFormat(fXmlNodeChild.get_attrVal(FXmlTagCOLL.A_Format, FXmlTagCOLL.D_Format));
                                if (fFormat != FFormat.List && fFormat != FFormat.AsciiList)
                                {
                                    continue;
                                }
                                // --
                                if (fXmlNodeChild.get_attrVal(FXmlTagCOLL.A_PartTag, FXmlTagCOLL.D_PartTag) != FBoolean.True)
                                {
                                    fXmlNodeParent.removeChild(fXmlNodeChild);
                                    childCnt -= 1;
                                }
                            }
                            // --
                            if (fXmlNodeParent.name == FXmlTagCOLL.E_Column)
                            {
                                fXmlNodeParent.set_attrVal(FXmlTagCOLL.A_Length, FXmlTagCOLL.D_Length, childCnt.ToString());
                            }
                        }

                        // --

                        // ***
                        // Repository Log의 모든 Column의 Part Tag 제거
                        // ***
                        foreach (FXmlNode fXmlNode in fXmlNodeRpsl.selectNodes(PartColumnQuery))
                        {
                            fXmlNode.set_attrVal(FXmlTagCOL.A_PartTag, FXmlTagCOL.D_PartTag, FXmlTagCOL.D_PartTag);
                        }

                        #endregion
                    }
                    else
                    {
                        #region All Repository

                        fXmlNodeRpsl = fXmlNodeRpm.clone(true);

                        #endregion
                    }

                    // --

                    fXmlNodeRpsl.set_attrVal(FXmlTagRPSL.A_RepositoryType, FXmlTagRPSL.D_RepositoryType, FXmlTagRPSL.R_Repository);
                }

                // --

                return fXmlNodeRpsl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeRps = null;
                fXmlNodeRpm = null;
                fXmlNodeDtsl = null;
                fXmlNodeRpsl = null;
                fXmlNodeParent = null;
                fXmlNodeListChild = null;
                fHdmrl = null;
                fHdmsl = null;
                colXPathList = null;
                fSourceList = null;
                fTargetList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode updateRepository(
           FScenarioData fScenarioData,
           FXmlNode fXmlNodeStg
           )
        {
            const string RepositoryQuery =
               FXmlTagSET.E_Setup +
               "/" + FXmlTagRPD.E_RepositoryDefinition +
               "/" + FXmlTagRPL.E_RepositoryList +
               "/" + FXmlTagRPS.E_Repository + "[@" + FXmlTagRPS.A_UniqueId + "='{0}']";
            // --            
            const string PartColumnQuery = ".//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_PartTag + "]";

            // --

            FXmlNode fXmlNodeRpm = null;
            FXmlNode fXmlNodeRps = null;
            FXmlNodeList fXmlNodeColList = null;
            FXmlNode fXmlNodeRpsl = null;
            FXmlNode fXmlNodeDtsl = null;
            FXmlNode fXmlNodeParent = null;
            FXmlNodeList fXmlNodeListChild = null;
            List<string> colXPath = null;
            List<string> colXPathVal = null;
            FFormat fFormat = FFormat.List;
            int childCnt = 0;
            string id = string.Empty;
            string xpath = string.Empty;
            FStorageMode fMode;
            int index = 0;

            try
            {
                fXmlNodeRpm = fScenarioData.fRepositoryMaterial.fXmlNode;
                fMode = FEnumConverter.toStorageMode(fXmlNodeStg.get_attrVal(FXmlTagSTG.A_Mode, FXmlTagSTG.D_Mode));

                // --

                id = fXmlNodeStg.get_attrVal(FXmlTagSTG.A_RepositoryId, FXmlTagSTG.D_RepositoryId);
                if (id == string.Empty || id != fXmlNodeRpm.get_attrVal(FXmlTagRPM.A_UniqueId, FXmlTagRPM.D_UniqueId))
                {
                    return null;
                }

                if (!fScenarioData.hasMapperPerformedLog || !fScenarioData.fMapperPerformedLog.hasDataSetLog)
                {
                    return null;
                }

                // --

                // ***
                // Update Column의 XPath 검색
                // ***
                colXPath = new List<string>();
                colXPathVal = new List<string>();
                // --
                xpath = string.Format(RepositoryQuery, id);
                fXmlNodeRps = fScenarioData.fTcdCore.fTcpDriver.fXmlNode.selectSingleNode(xpath);
                // --
                fXmlNodeDtsl = fScenarioData.fMapperPerformedLog.getDataSetLog().fXmlNode;
                makeRepositoryUpdatePath(fXmlNodeRps, fXmlNodeDtsl.selectNodes(FXmlTagDATL.E_Data), colXPath, colXPathVal);

                // --

                // *** 
                // Repository Material의 Column를 Update 
                // *** 
                foreach (string key in colXPath)
                {
                    fXmlNodeColList = fXmlNodeRpm.selectNodes(key);
                    foreach (FXmlNode fXmlNodeCol in fXmlNodeColList)
                    {
                        if (
                            fMode == FStorageMode.Part &&
                            fXmlNodeCol.fParentNode.name == FXmlTagCOL.E_Column &&
                            fXmlNodeCol.fParentNode.get_attrVal(FXmlTagCOL.A_PartTag, FXmlTagCOL.D_PartTag) != FBoolean.True
                            )
                        {
                            continue;
                        }
                        fXmlNodeCol.set_attrVal(FXmlTagCOL.A_Value, FXmlTagCOL.D_Value, colXPathVal[index]);
                    }
                    index++;
                }

                // -- 

                // ***
                // 2017.04.04 by spike.lee
                // Repository Material Save 구현
                // Repository Material Last Access Time 설정
                // ***
                fXmlNodeRpm.set_attrVal(FXmlTagRPM.A_LastAccessTime, FXmlTagRPM.D_LastAccessTime, FDataConvert.defaultNowDateTimeToString());

                // --

                fXmlNodeRpsl = fXmlNodeRpm.clone(true);

                // --

                if (fMode == FStorageMode.Part)
                {
                    // ***
                    // Repository Log의 Part Column이 아닌 Column 제거
                    // ***
                    foreach (FXmlNode fXmlNode in fXmlNodeRpsl.selectNodes(PartColumnQuery))
                    {
                        fXmlNodeParent = fXmlNode.fParentNode;
                        // --
                        fXmlNodeListChild = fXmlNodeParent.selectNodes(FXmlTagCOLL.E_Column);
                        childCnt = fXmlNodeListChild.count;
                        foreach (FXmlNode fXmlNodeChild in fXmlNodeListChild)
                        {
                            fFormat = FEnumConverter.toFormat(fXmlNodeChild.get_attrVal(FXmlTagCOLL.A_Format, FXmlTagCOLL.D_Format));
                            if (fFormat != FFormat.List && fFormat != FFormat.AsciiList)
                            {
                                continue;
                            }
                            // --
                            if (fXmlNodeChild.get_attrVal(FXmlTagCOLL.A_PartTag, FXmlTagCOLL.D_PartTag) != FBoolean.True)
                            {
                                fXmlNodeParent.removeChild(fXmlNodeChild);
                                childCnt -= 1;
                            }
                        }
                        // --
                        if (fXmlNodeParent.name == FXmlTagCOLL.E_Column)
                        {
                            fXmlNodeParent.set_attrVal(FXmlTagCOLL.A_Length, FXmlTagCOLL.D_Length, childCnt.ToString());
                        }
                    }
                }

                // --

                // ***
                // Repository Log의 모든 Column의 Part Tag 제거
                // ***
                foreach (FXmlNode fXmlNode in fXmlNodeRpsl.selectNodes(PartColumnQuery))
                {
                    fXmlNode.set_attrVal(FXmlTagCOL.A_PartTag, FXmlTagCOL.D_PartTag, FXmlTagCOL.D_PartTag);
                }
                fXmlNodeRpsl.set_attrVal(FXmlTagRPSL.A_RepositoryType, FXmlTagRPSL.D_RepositoryType, FXmlTagRPSL.R_Repository);

                // --

                return fXmlNodeRpsl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeRpm = null;
                fXmlNodeRps = null;
                fXmlNodeColList = null;
                fXmlNodeRpsl = null;
                fXmlNodeDtsl = null;
                fXmlNodeParent = null;
                fXmlNodeListChild = null;
                colXPath = null;
                colXPathVal = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode removeRepository(
           FScenarioData fScenarioData,
           FXmlNode fXmlNodeStg
           )
        {
            const string PartColumnQuery = ".//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_PartTag + "]";
            const string PartListColumnQuery =
                ".//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_PartTag + " and (@" + FXmlTagCOL.A_Format + "='{0}' or @" + FXmlTagCOL.A_Format + "='{1}')]";

            // --

            FXmlNode fXmlNodeRpm = null;
            FXmlNode fXmlNodeRpsl = null;
            FXmlNode fXmlNodeParent = null;
            FXmlNodeList fXmlNodeListChild = null;
            FFormat fFormat = FFormat.List;
            int childCnt = 0;
            string xpath = string.Empty;
            string rpsId1 = string.Empty;
            string rpsId2 = string.Empty;

            try
            {
                fXmlNodeRpm = fScenarioData.fRepositoryMaterial.fXmlNode;

                // --

                // ***
                // 2017.08.16 by spike.lee
                // Storage에 등록한 Repository와 Repository Material의 Repository가 동일한지 검사
                // ***
                rpsId1 = fXmlNodeStg.get_attrVal(FXmlTagSTG.A_RepositoryId, FXmlTagSTG.D_RepositoryId);
                rpsId2 = fXmlNodeRpm.get_attrVal(FXmlTagRPM.A_UniqueId, FXmlTagRPM.D_UniqueId);
                // --
                if (rpsId1 != rpsId2)
                {
                    return null;
                }

                // --

                // ***
                // 2017.04.04 by spike.lee
                // Repository Material Save 구현
                // Repository Material Last Access Time 설정
                // ***
                fXmlNodeRpm.set_attrVal(FXmlTagRPM.A_LastAccessTime, FXmlTagRPM.D_LastAccessTime, FDataConvert.defaultNowDateTimeToString());

                // --

                fXmlNodeRpsl = fXmlNodeRpm.clone(true);

                // --

                if (fXmlNodeStg.get_attrVal(FXmlTagSTG.A_Mode, FXmlTagSTG.D_Mode) == FEnumConverter.fromStorageMode(FStorageMode.Part))
                {
                    #region Part Repository

                    // ***
                    // Repository Material에 Part Column 제거
                    // *** 
                    xpath = string.Format(PartListColumnQuery, FFormatShortName.L.ToString(), FFormatShortName.AL.ToString());
                    foreach (FXmlNode fXmlNode in fXmlNodeRpm.selectNodes(PartColumnQuery))
                    {
                        fFormat = FEnumConverter.toFormat(fXmlNode.get_attrVal(FXmlTagCOLL.A_Format, FXmlTagCOLL.D_Format));
                        if (fFormat != FFormat.List && fFormat != FFormat.AsciiList)
                        {
                            continue;
                        }
                        // --
                        if (fXmlNode.selectNodes(xpath).count == 0)
                        {
                            fXmlNode.fParentNode.removeChild(fXmlNode);
                        }
                    }

                    // --

                    // ***
                    // Repository Material에 Column 항목이 없을 경우 제거
                    // ***
                    if (fXmlNodeRpm.fChildNodes.count == 0)
                    {
                        fScenarioData.fTcdCore.fRepositoryMaterialStorage.remove(fScenarioData.fRepositoryMaterial);
                    }

                    // --

                    // ***
                    // Repository Log의 Part Column이 아닌 Column 제거
                    // ***
                    foreach (FXmlNode fXmlNode in fXmlNodeRpsl.selectNodes(PartColumnQuery))
                    {
                        fXmlNodeParent = fXmlNode.fParentNode;
                        // --
                        fXmlNodeListChild = fXmlNodeParent.selectNodes(FXmlTagCOLL.E_Column);
                        childCnt = fXmlNodeListChild.count;
                        foreach (FXmlNode fXmlNodeChild in fXmlNodeListChild)
                        {
                            fFormat = FEnumConverter.toFormat(fXmlNodeChild.get_attrVal(FXmlTagCOLL.A_Format, FXmlTagCOLL.D_Format));
                            if (fFormat != FFormat.List && fFormat != FFormat.AsciiList)
                            {
                                continue;
                            }
                            // --
                            if (fXmlNodeChild.get_attrVal(FXmlTagCOLL.A_PartTag, FXmlTagCOLL.D_PartTag) != FBoolean.True)
                            {
                                fXmlNodeParent.removeChild(fXmlNodeChild);
                                childCnt -= 1;
                            }
                        }
                        // --
                        if (fXmlNodeParent.name == FXmlTagCOLL.E_Column)
                        {
                            fXmlNodeParent.set_attrVal(FXmlTagCOLL.A_Length, FXmlTagCOLL.D_Length, childCnt.ToString());
                        }
                    }

                    #endregion
                }
                else
                {
                    #region All Repository

                    fScenarioData.fTcdCore.fRepositoryMaterialStorage.remove(fScenarioData.fRepositoryMaterial);

                    #endregion
                }

                // --

                // ***
                // Repository Log의 모든 Column의 Part Tag 제거
                // ***
                foreach (FXmlNode fXmlNode in fXmlNodeRpsl.selectNodes(PartColumnQuery))
                {
                    fXmlNode.set_attrVal(FXmlTagCOL.A_PartTag, FXmlTagCOL.D_PartTag, FXmlTagCOL.D_PartTag);
                }
                fXmlNodeRpsl.set_attrVal(FXmlTagRPSL.A_RepositoryType, FXmlTagRPSL.D_RepositoryType, FXmlTagRPSL.R_Repository);

                // --

                return fXmlNodeRpsl;
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

        public static FXmlNode[] removeAllRepository(
           FScenarioData fScenarioData
           )
        {
            // ***
            // 2017.03.31 by spike.lee
            // Repository Material All Remove 구현
            // ***
            List<FXmlNode> fXmlNodeRpslList = null;
            FXmlNode fXmlNodeRpsl = null;

            try
            {
                fXmlNodeRpslList = new List<FXmlNode>();

                // --

                foreach (FRepositoryMaterial fRpm in fScenarioData.fTcdCore.fRepositoryMaterialStorage.fRepositoryMaterialCollection)
                {
                    // ***
                    // 2017.04.04 by spike.lee
                    // Repository Material Save 구현
                    // Repository Material Last Access Time 설정
                    // ***
                    fRpm.fXmlNode.set_attrVal(FXmlTagRPM.A_LastAccessTime, FXmlTagRPM.D_LastAccessTime, FDataConvert.defaultNowDateTimeToString());

                    // --

                    fXmlNodeRpsl = fRpm.fXmlNode.clone(true);
                    fXmlNodeRpsl.set_attrVal(FXmlTagRPSL.A_RepositoryType, FXmlTagRPSL.D_RepositoryType, FXmlTagRPSL.R_Repository);
                    // --
                    fXmlNodeRpslList.Add(fXmlNodeRpsl);
                }
                fScenarioData.fTcdCore.fRepositoryMaterialStorage.clear();

                // --

                return fXmlNodeRpslList.ToArray();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeRpsl = null;
                fXmlNodeRpslList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void makeRepositorySelectPath(
            FXmlNode fXmlNodeRps,
            FXmlNodeList fXmlNodeListDatl,
            List<List<string>> colXPathList
            )
        {
            const string ColumnQuery1 = ".//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_Name + "='{0}']";
            const string ColumnQuery2 = ".//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_Name + "='{0}' and @" + FXmlTagCOL.A_Value + "='{1}']";

            // --

            FXmlNode fXmlNodeCol = null;
            FFormat fDatlFormat;
            FFormat fColFormat;
            string name = string.Empty;
            string val = string.Empty;
            string xpath = string.Empty;
            List<string> colXPath = null;

            try
            {
                colXPath = new List<string>();
                colXPathList.Add(colXPath);

                // -- 

                foreach (FXmlNode fXmlNodeDatl in fXmlNodeListDatl)
                {
                    fDatlFormat = FEnumConverter.toFormat(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format));

                    // --

                    // ***
                    // Raw Format은 Select Path로 사용하지 않음.
                    // ***
                    if (fDatlFormat == FFormat.Raw)
                    {
                        continue;
                    }

                    // --

                    if (fDatlFormat == FFormat.List || fDatlFormat == FFormat.AsciiList)
                    {
                        // ***
                        // List 계열 Format은 Select Path에 사용하지 않으나 Child는 Path에 포함
                        // ***
                        makeRepositorySelectPath(fXmlNodeRps, fXmlNodeDatl.selectNodes(FXmlTagDATL.E_Data), colXPathList);
                    }
                    else
                    {
                        // ***
                        // Data Log의 Target Type이 Column이 아닐 경우 조건에서 제외
                        // ***
                        if (FEnumConverter.toDataTargetType(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_TargetType, FXmlTagDATL.D_TargetType)) != FDataTargetType.Column)
                        {
                            continue;
                        }

                        // --

                        name = fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_TargetColumn, FXmlTagDATL.D_TargetColumn);

                        // --

                        xpath = string.Format(ColumnQuery1, name);
                        fXmlNodeCol = fXmlNodeRps.selectSingleNode(xpath);
                        if (fXmlNodeCol == null)
                        {
                            fColFormat = fDatlFormat;
                        }
                        else
                        {
                            fColFormat = FEnumConverter.toFormat(fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Format, FXmlTagCOL.D_Format));
                        }

                        // --

                        //*** 2017.02.13
                        val = FValueConverter.toDataConversionedEncodingValue(
                            fDatlFormat,
                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value),
                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression)
                            );
                        // --
                        val = FValueConverter.convertStringValue(fColFormat, val);

                        // --                        

                        colXPath.Add(string.Format(ColumnQuery2, name, val));
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeCol = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void makeRepositorySelectPathByKey(
        FXmlNode fXmlNodeRps,
        FXmlNodeList fXmlNodeListDatl,
        List<List<string>> colXPathList
        )
        {
            const string ColumnQuery1 = ".//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_Name + "='{0}' and @" + FXmlTagCOL.A_PrimaryKey + "='T']";
            const string ColumnQuery2 = ".//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_Name + "='{0}' and @" + FXmlTagCOL.A_Value + "='{1}']";

            // --

            FXmlNode fXmlNodeCol = null;
            FFormat fDatlFormat;
            FFormat fColFormat;
            string name = string.Empty;
            string val = string.Empty;
            string xpath = string.Empty;
            List<string> colXPath = null;

            try
            {
                colXPath = new List<string>();
                colXPathList.Add(colXPath);

                // -- 

                foreach (FXmlNode fXmlNodeDatl in fXmlNodeListDatl)
                {
                    fDatlFormat = FEnumConverter.toFormat(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format));

                    // --

                    // ***
                    // Raw Format은 Select Path로 사용하지 않음.
                    // ***
                    if (fDatlFormat == FFormat.Raw)
                    {
                        continue;
                    }

                    // --

                    if (fDatlFormat == FFormat.List || fDatlFormat == FFormat.AsciiList)
                    {
                        // ***
                        // List 계열 Format은 Select Path에 사용하지 않으나 Child는 Path에 포함
                        // ***
                        makeRepositorySelectPath(fXmlNodeRps, fXmlNodeDatl.selectNodes(FXmlTagDATL.E_Data), colXPathList);
                    }
                    else
                    {
                        // ***
                        // Data Log의 Target Type이 Column이 아닐 경우 조건에서 제외
                        // ***
                        if (FEnumConverter.toDataTargetType(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_TargetType, FXmlTagDATL.D_TargetType)) != FDataTargetType.Column)
                        {
                            continue;
                        }

                        // --

                        name = fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_TargetColumn, FXmlTagDATL.D_TargetColumn);

                        // --

                        xpath = string.Format(ColumnQuery1, name);
                        fXmlNodeCol = fXmlNodeRps.selectSingleNode(xpath);
                        if (fXmlNodeCol == null)
                        {
                            continue;
                        }

                        // --
                        fColFormat = FEnumConverter.toFormat(fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Format, FXmlTagCOL.D_Format));

                        // --

                        //*** 2017.02.13
                        val = FValueConverter.toDataConversionedEncodingValue(
                            fDatlFormat,
                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value),
                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression)
                            );
                        // --
                        val = FValueConverter.convertStringValue(fColFormat, val);

                        // --                        

                        colXPath.Add(string.Format(ColumnQuery2, name, val));
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeCol = null;
                colXPath = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void makeRepositoryUpdatePath(
            FXmlNode fXmlNodeRps,
            FXmlNodeList fXmlNodeListDatl,
            List<string> colXPath,
            List<string> colXPathVal
            )
        {
            const string ColumnQuery = ".//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_Name + "='{0}']";

            // --

            FXmlNode fXmlNodeCol = null;
            FFormat fDatlFormat;
            FFormat fColFormat;
            string name = string.Empty;
            string val = string.Empty;
            string xpath = string.Empty;

            try
            {
                foreach (FXmlNode fXmlNodeDatl in fXmlNodeListDatl)
                {
                    fDatlFormat = FEnumConverter.toFormat(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format));

                    // --

                    // ***
                    // Raw Format은 Select Path로 사용하지 않음.
                    // ***
                    if (fDatlFormat == FFormat.Raw)
                    {
                        continue;
                    }

                    // --

                    if (fDatlFormat == FFormat.List || fDatlFormat == FFormat.AsciiList)
                    {
                        // ***
                        // List 계열 Format은 Update Path에 사용하지 않으나 Child는 Path에 포함
                        // ***
                        makeRepositoryUpdatePath(fXmlNodeRps, fXmlNodeDatl.selectNodes(FXmlTagDATL.E_Data), colXPath, colXPathVal);
                    }
                    else
                    {
                        // ***
                        // Data Log의 Target Type이 Column이 아닐 경우 조건에서 제외
                        // ***
                        if (FEnumConverter.toDataTargetType(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_TargetType, FXmlTagDATL.D_TargetType)) != FDataTargetType.Column)
                        {
                            continue;
                        }

                        // --

                        name = fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_TargetColumn, FXmlTagDATL.D_TargetColumn);
                        xpath = string.Format(ColumnQuery, name);
                        fXmlNodeCol = fXmlNodeRps.selectSingleNode(xpath);
                        if (fXmlNodeCol == null)
                        {
                            fColFormat = fDatlFormat;
                        }
                        else
                        {
                            fColFormat = FEnumConverter.toFormat(fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Format, FXmlTagCOL.D_Format));
                        }

                        // --

                        val = FValueConverter.toDataConversionedEncodingValue(
                            fDatlFormat,
                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value),
                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression)
                            );
                        // --
                        val = FValueConverter.convertStringValue(fColFormat, val);

                        // --

                        colXPath.Add(xpath);
                        colXPathVal.Add(val);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeCol = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
