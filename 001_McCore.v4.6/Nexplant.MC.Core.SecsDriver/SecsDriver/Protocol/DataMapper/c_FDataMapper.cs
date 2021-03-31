/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDataMapper.cs
--  Creator         : spike.lee
--  Create Date     : 2011.12.19
--  Description     : FAMate Core FaSecsDriver Data Mapper Class 
--  History         : Created by spike.lee at 2011.12.19
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal static class FDataMapper
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Common Methods

        private static void collectResourceData(
           FScenarioData fScenarioData
           )
        {
            try
            {
                fScenarioData.fResourceData.clear();
                // --
                fScenarioData.fResourceData.setEapName(fScenarioData.fScdCore.fSecsDriver.eapName);
                fScenarioData.fResourceData.setEquipmentName(fScenarioData.fEquipment.name);
                // --
                if (fScenarioData.fDataMessageReceivedLog != null)
                {
                    if (fScenarioData.fDataMessageReceivedLog.fMessageLogType == FMessageLogType.SecsDeviceDataMessageReceivedLog)
                    {
                        fScenarioData.fResourceData.setSecsDeviceName(((FSecsDeviceDataMessageReceivedLog)fScenarioData.fDataMessageReceivedLog).deviceName);
                        fScenarioData.fResourceData.setSecsSessionName(((FSecsDeviceDataMessageReceivedLog)fScenarioData.fDataMessageReceivedLog).sessionName);
                        fScenarioData.fResourceData.setSecsSessionId(((FSecsDeviceDataMessageReceivedLog)fScenarioData.fDataMessageReceivedLog).sessionId.ToString());
                    }
                    else if (fScenarioData.fDataMessageReceivedLog.fMessageLogType == FMessageLogType.HostDeviceDataMessageReceivedLog)
                    {
                        fScenarioData.fResourceData.setHostDeviceName(((FHostDeviceDataMessageReceivedLog)fScenarioData.fDataMessageReceivedLog).deviceName);
                        fScenarioData.fResourceData.setHostSessionName(((FHostDeviceDataMessageReceivedLog)fScenarioData.fDataMessageReceivedLog).sessionName);
                        fScenarioData.fResourceData.setHostSessionId(((FHostDeviceDataMessageReceivedLog)fScenarioData.fDataMessageReceivedLog).sessionId.ToString());
                        fScenarioData.fResourceData.setHostMachineId(((FHostDeviceDataMessageReceivedLog)fScenarioData.fDataMessageReceivedLog).machineId.ToString());
                    }
                }
                else if (fScenarioData.fIObjectLog != null)
                {
                    // Device State Change
                    if (fScenarioData.fIObjectLog.fObjectLogType == FObjectLogType.SecsDeviceStateChangedLog)
                    {
                        fScenarioData.fResourceData.setSecsDeviceName(fScenarioData.fIObjectLog.name);
                    }
                    else if (fScenarioData.fIObjectLog.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                    {
                        fScenarioData.fResourceData.setHostDeviceName(fScenarioData.fIObjectLog.name);
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

        private static FXmlNode collectEquipmentState(
            FScenarioData fScenarioData,
            string estName
            )
        {
            const string EquipmentStateQuery =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagESD.E_EquipmentStateSetDefinition +
                "/" + FXmlTagESL.E_EquipmentStateSetList +
                "/" + FXmlTagESS.E_EquipmentStateSet +
                "/" + FXmlTagEST.E_EquipmentState + "[@" + FXmlTagEST.A_Name + "='{0}']";

            // --

            string xpath = string.Empty;

            try
            {
                xpath = string.Format(EquipmentStateQuery, estName);
                return fScenarioData.fScdCore.fSecsDriver.fXmlNode.selectSingleNode(xpath);
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

        private static FXmlNodeList collectEnvironmentByGlobalScan(
            FScenarioData fScenarioData,
            string envName
            )
        {
            const string EnvironmentQuery =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagEND.E_EnvironmentDefinition +
                "/" + FXmlTagENL.E_EnvironmentList +
                "//" + FXmlTagENV.E_Environment + "[@" + FXmlTagENV.A_Name + "='{0}']";

            // --

            string xpath = string.Empty;

            try
            {
                xpath = string.Format(EnvironmentQuery, envName);
                return fScenarioData.fScdCore.fSecsDriver.fXmlNode.selectNodes(xpath);
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

        private static FXmlNodeList collectEnvironmentByLocalScan(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeParentEnv,
            string envName
            )
        {
            const string EnvironmentQuery1 =
                "../" + FXmlTagENV.E_Environment + "[@" + FXmlTagENV.A_UniqueId + "='{0}' and @" + FXmlTagENV.A_Name + "='{1}'] | " +
                ".//" + FXmlTagENV.E_Environment + "[@" + FXmlTagENV.A_Name + "='{1}']";
            // --
            const string EnvironmentQuery2 =                
                ".//" + FXmlTagENV.E_Environment + "[@" + FXmlTagENV.A_Name + "='{0}']";

            // --

            FXmlNodeList fXmlNodeListEnv = null;
            FXmlNode fXmlNodeParent = null;
            string uniqueId = string.Empty;
            string xpath = string.Empty;

            try
            {
                // ***
                // Parent가 존재하지 않을 경우 전체 Environment 목록을 검색한다.
                // ***
                if (fXmlNodeParentEnv == null)
                {
                    return collectEnvironmentByGlobalScan(fScenarioData, envName);
                }

                // --

                // ***
                // 부모 Environment 검색에서 조회되지 않을 경우, 조상 Environment에서 조회한다.
                // ***
                fXmlNodeParent = fXmlNodeParentEnv;
                if (fXmlNodeParent.name == FXmlTagENV.E_Environment)
                {
                    uniqueId = fXmlNodeParent.get_attrVal(FXmlTagENV.A_UniqueId, FXmlTagENV.D_UniqueId);
                }

                // --
                
                while (
                    fXmlNodeParent.name == FXmlTagEND.E_EnvironmentDefinition ||
                    fXmlNodeParent.name == FXmlTagENL.E_EnvironmentList ||
                    fXmlNodeParent.name == FXmlTagENV.E_Environment
                    )
                {
                    if (
                        fXmlNodeParent.get_attrVal(FXmlTagENV.A_UniqueId, FXmlTagENV.D_UniqueId) == uniqueId &&
                        fXmlNodeParent.get_attrVal(FXmlTagENV.A_Name, FXmlTagENV.D_Name) == envName
                        )
                    {
                        xpath = string.Format(EnvironmentQuery1, uniqueId, envName);
                    }
                    else
                    {
                        xpath = string.Format(EnvironmentQuery2, envName);
                    }

                    // --

                    fXmlNodeListEnv = fXmlNodeParent.selectNodes(xpath);
                    if (fXmlNodeListEnv.count > 0)
                    {
                        return fXmlNodeListEnv;
                    }

                    // --

                    fXmlNodeParent = fXmlNodeParent.fParentNode;
                    if (fXmlNodeParent == null)
                    {
                        break;
                    }
                }

                // --

                return fXmlNodeListEnv;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeParent = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static FXmlNodeList collectEnvironmentByVariable(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeParentEnv,
            string envName
            )
        {
            const string EnvironmentQuery = ".//" + FXmlTagENV.E_Environment + "[@" + FXmlTagENV.A_Name + "='{0}']";

            try
            {
                // ***
                // Parent가 존재하지 않을 경우 전체 Environment 목록을 검색한다.
                // ***
                if (fXmlNodeParentEnv == null)
                {
                    return collectEnvironmentByGlobalScan(fScenarioData, envName);
                }

                // --

                return fXmlNodeParentEnv.selectNodes(string.Format(EnvironmentQuery, envName));
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

        private static int calculateEnvironmentRawBytes(
            FXmlNode fXmlNodeEnv
            )
        {
            FFormat fFormat;
            int length = 0;
            int rawBytes = 0;

            try
            {
                fFormat = FEnumConverter.toFormat(fXmlNodeEnv.get_attrVal(FXmlTagENV.A_Format, FXmlTagENV.D_Format));
                length = int.Parse(fXmlNodeEnv.get_attrVal(FXmlTagENV.A_Length, FXmlTagENV.D_Length));

                // --

                rawBytes = 1;   // Format Byte 1로 설정
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                {
                    foreach (FXmlNode x in fXmlNodeEnv.selectNodes(FXmlTagENV.E_Environment))
                    {
                        rawBytes += calculateEnvironmentRawBytes(x);
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

        private static FXmlNodeList collectSecsItemLogByGlobalScan(
            FScenarioData fScenarioData,
            string sitlName
            )
        {
            const string SecsItemLogQuery =
                ".//" + FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_Name + "='{0}']";

            // --

            string xpath = string.Empty;

            try
            {
                xpath = string.Format(SecsItemLogQuery, sitlName);
                return ((FSecsDeviceDataMessageReceivedLog)fScenarioData.fDataMessageReceivedLog).fXmlNode.selectNodes(xpath);
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

        private static FXmlNodeList collectSecsItemLogByLocalScan(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeParentSitl,
            string sitlName
            )
        {
            const string SecsItemLogQuery1 =
                "../" + FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_UniqueId + "='{0}' and @" + FXmlTagSITL.A_Name + "='{1}'] | " +
                ".//" + FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_Name + "='{1}']";
            // --
            const string SecsItemLogQuery2 =                
                ".//" + FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_Name + "='{0}']";

            // --

            FXmlNodeList fXmlNodeListSitl = null;
            FXmlNode fXmlNodeParent = null;
            string uniqueId = string.Empty;
            string xpath = string.Empty;

            try
            {
                // ***
                // Parent가 존재하지 않을 경우 전체 Secs Item Log 목록을 검색한다.
                // ***
                if (fXmlNodeParentSitl == null)
                {
                    return collectSecsItemLogByGlobalScan(fScenarioData, sitlName);
                }

                // --

                // ***
                // 부모 Secs Item Log 검색에서 조회되지 않을 경우, 조상 Secs Item Log에서 조회한다.
                // ***
                fXmlNodeParent = fXmlNodeParentSitl;
                if (fXmlNodeParent.name == FXmlTagSITL.E_SecsItem)
                {
                    uniqueId = fXmlNodeParent.get_attrVal(FXmlTagSITL.A_UniqueId, FXmlTagSITL.D_UniqueId);
                }
                
                // --
                
                while (
                    fXmlNodeParent.name == FXmlTagSMGL.E_SecsMessage ||
                    fXmlNodeParent.name == FXmlTagSITL.E_SecsItem
                    )
                {
                    if (
                        fXmlNodeParent.get_attrVal(FXmlTagSITL.A_UniqueId, FXmlTagSITL.D_UniqueId) == uniqueId &&
                        fXmlNodeParent.get_attrVal(FXmlTagSITL.A_Name, FXmlTagSITL.D_Name) == sitlName
                        )
                    {
                        xpath = string.Format(SecsItemLogQuery1, uniqueId, sitlName);
                    }
                    else
                    {
                        xpath = string.Format(SecsItemLogQuery2, sitlName);
                    }

                    // --

                    fXmlNodeListSitl = fXmlNodeParent.selectNodes(xpath);
                    if (fXmlNodeListSitl.count > 0)
                    {
                        return fXmlNodeListSitl;
                    }

                    // --

                    fXmlNodeParent = fXmlNodeParent.fParentNode;
                    if (fXmlNodeParent == null)
                    {
                        break;
                    }
                }

                // --

                return fXmlNodeListSitl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeParent = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static FXmlNodeList collectSecsItemLogByVariable(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeParentSitl,
            string sitlName
            )
        {
            const string SecsItemLogQuery = ".//" + FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_Name + "='{0}']";

            try
            {
                // ***
                // Parent가 존재하지 않을 경우 전체 Secs Item Log 목록을 검색한다.
                // ***
                if (fXmlNodeParentSitl == null)
                {
                    return collectSecsItemLogByGlobalScan(fScenarioData, sitlName);
                }

                // --

                return fXmlNodeParentSitl.selectNodes(string.Format(SecsItemLogQuery, sitlName));
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

        private static int calculateSecsItemLogRawBytes(
            FXmlNode fXmlNodeSitl
            )
        {
            FFormat fFormat;
            int length = 0;
            int rawBytes = 0;

            try
            {
                fFormat = FEnumConverter.toFormat(fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Format, FXmlTagSITL.D_Format));
                length = int.Parse(fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Length, FXmlTagSITL.D_Length));

                // --

                rawBytes = 1;   // Format Byte 1로 설정
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                {
                    foreach (FXmlNode x in fXmlNodeSitl.selectNodes(FXmlTagSITL.E_SecsItem))
                    {
                        rawBytes += calculateSecsItemLogRawBytes(x);
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

        private static FXmlNodeList collectHostItemLogByGlobalScan(
            FScenarioData fScenarioData,
            string hitlName
            )
        {
            const string HostItemLogQuery =
                ".//" + FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_Name + "='{0}']";

            // --

            string xpath = string.Empty;

            try
            {
                xpath = string.Format(HostItemLogQuery, hitlName);
                return ((FHostDeviceDataMessageReceivedLog)fScenarioData.fDataMessageReceivedLog).fXmlNode.selectNodes(xpath);
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

        private static FXmlNodeList collectHostItemLogByLocalScan(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeParentHitl,
            string hitlName
            )
        {
            const string HostItemLogQuery1 =
                "../" + FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_UniqueId + "='{0}' and @" + FXmlTagHITL.A_Name + "='{1}'] | " +
                ".//" + FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_Name + "='{1}']";
            // --
            const string HostItemLogQuery2 =                
                ".//" + FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_Name + "='{0}']";

            // --

            FXmlNodeList fXmlNodeListHitl = null;
            FXmlNode fXmlNodeParent = null;
            FFormat fFormat = FFormat.List;
            string uniqueId = string.Empty;
            string xpath = string.Empty;

            try
            {
                // ***
                // Parent가 존재하지 않을 경우 전체 Host Item Log 목록을 검색한다.
                // ***
                if (fXmlNodeParentHitl == null)
                {
                    return collectHostItemLogByGlobalScan(fScenarioData, hitlName);
                }

                // --

                // ***
                // 부모 Host Item Log 검색에서 조회되지 않을 경우, 조상 Host Item Log에서 조회한다.
                // ***
                fXmlNodeParent = fXmlNodeParentHitl;
                if (fXmlNodeParent.name == FXmlTagHITL.E_HostItem)
                {
                    uniqueId = fXmlNodeParent.get_attrVal(FXmlTagHITL.A_UniqueId, FXmlTagHITL.D_UniqueId);
                }
                
                // --
                
                while (
                    fXmlNodeParent.name == FXmlTagHMGL.E_HostMessage ||
                    fXmlNodeParent.name == FXmlTagHITL.E_HostItem
                    )
                {
                    if (
                        fXmlNodeParent.get_attrVal(FXmlTagHITL.A_UniqueId, FXmlTagHITL.D_UniqueId) == uniqueId &&
                        fXmlNodeParent.get_attrVal(FXmlTagHITL.A_Name, FXmlTagHITL.D_Name) == hitlName
                        )
                    {
                        xpath = string.Format(HostItemLogQuery1, uniqueId, hitlName);
                    }
                    else
                    {
                        xpath = string.Format(HostItemLogQuery2, hitlName);
                    }

                    // --

                    fXmlNodeListHitl = fXmlNodeParent.selectNodes(xpath);
                    if (fXmlNodeListHitl.count > 0)
                    {
                        return fXmlNodeListHitl;
                    }
                    else
                    {
                        // --
                        // Add by Jeff.Kim 2018.04.23
                        // fXmlNodeParent 의 Format이 List 일경우에는 한번 찾아서 Item이 없을 경우 Break.
                        fFormat = FEnumConverter.toFormat(fXmlNodeParent.get_attrVal(FXmlTagHITL.A_Format, FXmlTagHITL.D_Format));
                        if (fFormat == FFormat.List)
                        {
                           break;
                        }
                    }

                    // --

                    fXmlNodeParent = fXmlNodeParent.fParentNode;
                    if (fXmlNodeParent == null)
                    {
                        break;
                    }
                }
                return fXmlNodeListHitl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeParent = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static FXmlNodeList collectHostItemLogByVariable(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeParentHitl,
            string hitlName
            )
        {
            const string HostItemLogQuery = ".//" + FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_Name + "='{0}']";

            try
            {
                // ***
                // Parent가 존재하지 않을 경우 전체 Host Item Log 목록을 검색한다.
                // ***
                if (fXmlNodeParentHitl == null)
                {
                    return collectHostItemLogByGlobalScan(fScenarioData, hitlName);
                }

                // --

                return fXmlNodeParentHitl.selectNodes(string.Format(HostItemLogQuery, hitlName));
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

        private static int calculateHostItemLogRawBytes(
            FXmlNode fXmlNodeHitl
            )
        {
            FFormat fFormat;
            int length = 0;
            int rawBytes = 0;

            try
            {
                fFormat = FEnumConverter.toFormat(fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Format, FXmlTagHITL.D_Format));
                length = int.Parse(fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Length, FXmlTagHITL.D_Length));

                // --

                rawBytes = 1;   // Format Byte 1로 설정
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                {
                    foreach (FXmlNode x in fXmlNodeHitl.selectNodes(FXmlTagHITL.E_HostItem))
                    {
                        rawBytes += calculateHostItemLogRawBytes(x);
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

        private static FXmlNodeList collectDataLogByGlobalScan(
            FScenarioData fScenarioData,
            FDataTargetType fTargetType,
            string datlName
            )
        {
            const string DataLogQuery1 =
                ".//" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_TargetType + "='{0}' and @" + FXmlTagDATL.A_TargetColumn + "='{1}']";
            // --
            const string DataLogQuery2 =
                ".//" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_TargetType + "='{0}' and @" + FXmlTagDATL.A_TargetItem + "='{1}']";

            // --

            string xpath = string.Empty;

            try
            {
                if (fTargetType == FDataTargetType.Column)
                {
                    xpath = string.Format(DataLogQuery1, FEnumConverter.fromDataTargetType(FDataTargetType.Column), datlName);
                }
                else
                {
                    xpath = string.Format(DataLogQuery2, FEnumConverter.fromDataTargetType(FDataTargetType.Item), datlName);
                }
                return ((FMapperPerformedLog)fScenarioData.fMapperPerformedLog).fXmlNode.selectNodes(xpath);
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

        private static FXmlNodeList collectDataLogByLocalScan(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeParentDatl,
            FDataTargetType fTargetType,
            string datlName
            )
        {
            // ***
            // 2017.09.28 by spike.lee
            // XML XPath에 or (|) 연산을 수행 할 경우 처리 속도가 현저히 저하되는 문제가 발생 함.
            // 우선 임시적으로 or (|) 연산을 최소로 호출 하는 방식으로 변경
            // ***
            const string DataLogByColumnQuery1 =
                "../" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_UniqueId + "='{0}'] | " +
                ".//" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_TargetType + "='{1}' and @" + FXmlTagDATL.A_TargetColumn + "='{2}']";
            // --
            const string DataLogByColumnQuery2 =
                ".//" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_TargetType + "='{0}' and @" + FXmlTagDATL.A_TargetColumn + "='{1}']";

            // --
            
            const string DataLogByItemQuery1 =
                "../" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_UniqueId + "='{0}'] | " +
                ".//" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_TargetType + "='{1}' and @" + FXmlTagDATL.A_TargetItem + "='{2}']";
            // --
            const string DataLogByItemQuery2 =
                ".//" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_TargetType + "='{0}' and @" + FXmlTagDATL.A_TargetItem + "='{1}']";

            // --

            FXmlNodeList fXmlNodeListDatl = null;
            FXmlNode fXmlNodeParent = null;
            string uniqueId = string.Empty;
            string targetType = string.Empty;
            string xpath = string.Empty;            

            try
            {
                // ***
                // Parent가 존재하지 않을 경우 전체 Data Log 목록을 검색한다.
                // ***
                if (fXmlNodeParentDatl == null)
                {
                    return collectDataLogByGlobalScan(fScenarioData, fTargetType, datlName);
                }

                // --

                // ***
                // 부모 Secs Item Log 검색에서 조회되지 않을 경우, 조상 Secs Item Log에서 조회한다.
                // ***
                fXmlNodeParent = fXmlNodeParentDatl;
                if (fXmlNodeParent.name == FXmlTagDATL.E_Data)
                {
                    uniqueId = fXmlNodeParent.get_attrVal(FXmlTagDATL.A_UniqueId, FXmlTagDATL.D_UniqueId);
                }

                // --

                if (fTargetType == FDataTargetType.Column)
                {
                    targetType = FEnumConverter.fromDataTargetType(FDataTargetType.Column);
                }
                else
                {
                    targetType = FEnumConverter.fromDataTargetType(FDataTargetType.Item);
                }

                // --
                
                while (
                    fXmlNodeParent.name == FXmlTagDTSL.E_DataSet ||
                    fXmlNodeParent.name == FXmlTagDATL.E_Data
                    )
                {
                    if (fTargetType == FDataTargetType.Column)
                    {
                        if (
                            fXmlNodeParent.get_attrVal(FXmlTagDATL.A_UniqueId, FXmlTagDATL.D_UniqueId) == uniqueId &&
                            fXmlNodeParent.get_attrVal(FXmlTagDATL.A_TargetType, FXmlTagDATL.D_TargetType) == targetType &&
                            fXmlNodeParent.get_attrVal(FXmlTagDATL.A_TargetColumn, FXmlTagDATL.D_TargetColumn) == datlName
                            )
                        {
                            xpath = string.Format(DataLogByColumnQuery1, uniqueId, targetType, datlName);
                        }
                        else
                        {
                            xpath = string.Format(DataLogByColumnQuery2, targetType, datlName);
                        }
                    }
                    else
                    {
                        if (
                            fXmlNodeParent.get_attrVal(FXmlTagDATL.A_UniqueId, FXmlTagDATL.D_UniqueId) == uniqueId &&
                            fXmlNodeParent.get_attrVal(FXmlTagDATL.A_TargetType, FXmlTagDATL.D_TargetType) == targetType &&
                            fXmlNodeParent.get_attrVal(FXmlTagDATL.A_TargetColumn, FXmlTagDATL.D_TargetItem) == datlName
                            )
                        {
                            xpath = string.Format(DataLogByItemQuery1, uniqueId, targetType, datlName);
                        }
                        else
                        {
                            xpath = string.Format(DataLogByItemQuery2, targetType, datlName);
                        }
                    }

                    // --
                    
                    fXmlNodeListDatl = fXmlNodeParent.selectNodes(xpath);
                    // --
                    if (fXmlNodeListDatl.count > 0)
                    {
                        return fXmlNodeListDatl;
                    }

                    // --

                    fXmlNodeParent = fXmlNodeParent.fParentNode;
                    if (fXmlNodeParent == null)
                    {
                        break;
                    }
                }

                // --

                return fXmlNodeListDatl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeParent = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static FXmlNodeList collectDataLogByVariableLocalScan(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeParentDatl,
            FDataTargetType fTargetType,
            string datlName
            )
        {
            // ***
            // 2017.09.28 by spike.lee
            // XML XPath에 or (|) 연산을 수행 할 경우 처리 속도가 현저히 저하되는 문제가 발생 함.
            // 우선 임시적으로 or (|) 연산을 최소로 호출 하는 방식으로 변경
            // ***
            const string DataLogByColumnQuery1 =
                "../" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_UniqueId + "='{0}'] | " +
                ".//" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_TargetType + "='{1}' and @" + FXmlTagDATL.A_TargetColumn + "='{2}']";
            // --
            const string DataLogByColumnQuery2 =
                ".//" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_TargetType + "='{0}' and @" + FXmlTagDATL.A_TargetColumn + "='{1}']";

            // --

            const string DataLogByItemQuery1 =
                "../" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_UniqueId + "='{0}'] | " +
                ".//" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_TargetType + "='{1}' and @" + FXmlTagDATL.A_TargetItem + "='{2}']";
            // --
            const string DataLogByItemQuery2 =
                ".//" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_TargetType + "='{0}' and @" + FXmlTagDATL.A_TargetItem + "='{1}']";

            // --

            FXmlNodeList fXmlNodeListDatl = null;
            FXmlNode fXmlNodeParent = null;
            string uniqueId = string.Empty;
            string targetType = string.Empty;
            string xpath = string.Empty;

            try
            {
                // ***
                // Parent가 존재하지 않을 경우 전체 Data Log 목록을 검색한다.
                // ***
                if (fXmlNodeParentDatl == null)
                {
                    return collectDataLogByGlobalScan(fScenarioData, fTargetType, datlName);
                }

                // --

                // ***
                // 부모 Secs Item Log 검색에서 조회되지 않을 경우, 조상 Secs Item Log에서 조회한다.
                // ***
                fXmlNodeParent = fXmlNodeParentDatl;
                if (fXmlNodeParent.name == FXmlTagDATL.E_Data)
                {
                    uniqueId = fXmlNodeParent.get_attrVal(FXmlTagDATL.A_UniqueId, FXmlTagDATL.D_UniqueId);
                }

                // --

                if (fTargetType == FDataTargetType.Column)
                {
                    targetType = FEnumConverter.fromDataTargetType(FDataTargetType.Column);
                }
                else
                {
                    targetType = FEnumConverter.fromDataTargetType(FDataTargetType.Item);
                }

                // --
                // 2018.04.06 by Jeff.Kim
                // fXmlNodeParent 로 처음 찾았을 경우, 만족하는 XmlNode가 없을 경우 while문으로 Parent를 찾아 Query를 할경우
                // DataList
                //     Data
                //     Data
                // DataList
                // DataList
                // 위와 같이 첫번째만 Data가 있고, 2, 3번째는 값이 없지만, While을 돌면서 Parent를 올려서 Query 하면, 첫번째 Data
                // 가 2, 3 에도 들어가는 현상 발생하여 한번만 검색하는것으로 변경.                
                if (fTargetType == FDataTargetType.Column)
                {
                    if (
                        fXmlNodeParent.get_attrVal(FXmlTagDATL.A_UniqueId, FXmlTagDATL.D_UniqueId) == uniqueId &&
                        fXmlNodeParent.get_attrVal(FXmlTagDATL.A_TargetType, FXmlTagDATL.D_TargetType) == targetType &&
                        fXmlNodeParent.get_attrVal(FXmlTagDATL.A_TargetColumn, FXmlTagDATL.D_TargetColumn) == datlName
                        )
                    {
                        xpath = string.Format(DataLogByColumnQuery1, uniqueId, targetType, datlName);
                    }
                    else
                    {
                        xpath = string.Format(DataLogByColumnQuery2, targetType, datlName);
                    }
                }
                else
                {
                    if (
                        fXmlNodeParent.get_attrVal(FXmlTagDATL.A_UniqueId, FXmlTagDATL.D_UniqueId) == uniqueId &&
                        fXmlNodeParent.get_attrVal(FXmlTagDATL.A_TargetType, FXmlTagDATL.D_TargetType) == targetType &&
                        fXmlNodeParent.get_attrVal(FXmlTagDATL.A_TargetColumn, FXmlTagDATL.D_TargetItem) == datlName
                        )
                    {
                        xpath = string.Format(DataLogByItemQuery1, uniqueId, targetType, datlName);
                    }
                    else
                    {
                        xpath = string.Format(DataLogByItemQuery2, targetType, datlName);
                    }
                }

                // --

                fXmlNodeListDatl = fXmlNodeParent.selectNodes(xpath);

                // --

                return fXmlNodeListDatl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeParent = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static FXmlNodeList collectDataLogByVariable(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeParentDatl,
            FDataTargetType fTargetType,
            string datlName
            )
        {
            const string DataLogQuery1 =
                ".//" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_TargetType + "='{0}' and @" + FXmlTagDATL.A_TargetColumn + "='{1}']";
            // --
            const string DataLogQuery2 =
                ".//" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_TargetType + "='{0}' and @" + FXmlTagDATL.A_TargetItem + "='{1}']";

            // --

            string xpath = string.Empty;

            try
            {
                // ***
                // Parent가 존재하지 않을 경우 전체 Data Log 목록을 검색한다.
                // ***
                if (fXmlNodeParentDatl == null)
                {
                    return collectDataLogByGlobalScan(fScenarioData, fTargetType, datlName);
                }

                // --

                if (fTargetType == FDataTargetType.Column)
                {
                    xpath = string.Format(DataLogQuery1, FEnumConverter.fromDataTargetType(FDataTargetType.Column), datlName);
                }
                else
                {
                    xpath = string.Format(DataLogQuery2, FEnumConverter.fromDataTargetType(FDataTargetType.Item), datlName);
                }

                // --

                return fXmlNodeParentDatl.selectNodes(xpath);
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

        private static int calculateDataLogRawBytes(
            FXmlNode fXmlNodeDatl
            )
        {
            FFormat fFormat;
            int length = 0;
            int rawBytes = 0;

            try
            {
                fFormat = FEnumConverter.toFormat(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format));
                length = int.Parse(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length));

                // --

                rawBytes = 1;   // Format Byte 1로 설정
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                {
                    foreach (FXmlNode x in fXmlNodeDatl.selectNodes(FXmlTagDATL.E_Data))
                    {
                        rawBytes += calculateDataLogRawBytes(x);
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

        private static FXmlNodeList collectColumnByGlobalScan(
            FScenarioData fScenarioData,
            string colName
            )
        {
            const string ColumnQuery = ".//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_Name + "='{0}']";

            // --

            string xpath = string.Empty;

            try
            {
                xpath = string.Format(ColumnQuery, colName);

                // --

                // ***
                // 2017.03.30 by spike.lee
                // Repository Material에서 검색하는 부분을 Part 지원을 위해 Repository Log에서 검색하도록 수정
                // ***
                if (
                    fScenarioData.fStoragePerformedLog != null &&
                    fScenarioData.fStoragePerformedLog.fChildRepositoryLogCollection.count > 0
                    )
                {
                    return fScenarioData.fStoragePerformedLog.fChildRepositoryLogCollection[0].fXmlNode.selectNodes(xpath);
                }                  
                return ((FRepositoryMaterial)fScenarioData.fRepositoryMaterial).fXmlNode.selectNodes(xpath);
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

        private static FXmlNodeList collectColumnByLocalScan(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeParentCol,
            string colName
            )
        {
            const string ColumnQuery1 =
                "../" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_UniqueId + "='{0}' and @" + FXmlTagCOL.A_Name + "='{1}'] | " +
                ".//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_Name + "='{1}']";
            // --
            const string ColumnQuery2 =
                ".//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_Name + "='{0}']";

            // --

            FXmlNodeList fXmlNodeListCol = null;
            FXmlNode fXmlNodeParent = null;
            string uniqueId = string.Empty;
            string xpath = string.Empty;

            try
            {
                // ***
                // Parent가 존재하지 않을 경우 전체 Column 목록을 검색한다.
                // ***
                if (fXmlNodeParentCol == null)
                {
                    return collectColumnByGlobalScan(fScenarioData, colName);
                }

                // --

                // ***
                // 부모 Column 검색에서 조회되지 않을 경우, 조상 Column에서 조회한다.
                // ***
                fXmlNodeParent = fXmlNodeParentCol;
                if (fXmlNodeParent.name == FXmlTagCOL.E_Column)
                {
                    uniqueId = fXmlNodeParent.get_attrVal(FXmlTagCOL.A_UniqueId, FXmlTagCOL.D_UniqueId);
                }

                // --
                
                while (
                    fXmlNodeParent.name == FXmlTagRPS.E_Repository ||
                    fXmlNodeParent.name == FXmlTagCOL.E_Column
                    )
                {
                    if (
                        fXmlNodeParent.get_attrVal(FXmlTagCOL.A_UniqueId, FXmlTagCOL.D_UniqueId) == uniqueId &&
                        fXmlNodeParent.get_attrVal(FXmlTagCOL.A_Name, FXmlTagCOL.D_Name) == colName
                        )
                    {
                        xpath = string.Format(ColumnQuery1, uniqueId, colName);
                    }
                    else
                    {
                        xpath = string.Format(ColumnQuery2, colName);
                    }

                    // --

                    fXmlNodeListCol = fXmlNodeParent.selectNodes(xpath);
                    if (fXmlNodeListCol.count > 0)
                    {
                        return fXmlNodeListCol;
                    }

                    // --

                    fXmlNodeParent = fXmlNodeParent.fParentNode;
                    if (fXmlNodeParent == null)
                    {
                        break;
                    }
                }
                return fXmlNodeListCol;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeParent = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static FXmlNodeList collectColumnByVariable(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeParentCol,
            string colName
            )
        {
            const string ColumnQuery = ".//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_Name + "='{0}']";

            try
            {
                // ***
                // Parent가 존재하지 않을 경우 전체 Column 목록을 검색한다.
                // ***
                if (fXmlNodeParentCol == null)
                {
                    return collectColumnByGlobalScan(fScenarioData, colName);
                }

                // --

                return fXmlNodeParentCol.selectNodes(string.Format(ColumnQuery, colName));
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

        private static int calculateColumnRawBytes(
            FXmlNode fXmlNodeCol
            )
        {
            FFormat fFormat;
            int length = 0;
            int rawBytes = 0;

            try
            {
                fFormat = FEnumConverter.toFormat(fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Format, FXmlTagCOL.D_Format));
                length = int.Parse(fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length));

                // --

                rawBytes = 1;   // Format Byte 1로 설정
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                {
                    foreach (FXmlNode x in fXmlNodeCol.selectNodes(FXmlTagCOL.E_Column))
                    {
                        rawBytes += calculateColumnRawBytes(x);
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

        private static string getSecsItemLogValueBySourceType(
            FDataSourceType fSourceType,
            FXmlNode fXmlNodeSitl
            )
        {
            try
            {
                if (fSourceType == FDataSourceType.ItemTag1)
                {
                    return fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_UserTag1, FXmlTagSITL.D_UserTag1);
                }
                else if (fSourceType == FDataSourceType.ItemTag2)
                {
                    return fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_UserTag2, FXmlTagSITL.D_UserTag2);
                }
                else if (fSourceType == FDataSourceType.ItemTag3)
                {
                    return fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_UserTag3, FXmlTagSITL.D_UserTag3);
                }
                else if (fSourceType == FDataSourceType.ItemTag4)
                {
                    return fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_UserTag4, FXmlTagSITL.D_UserTag4);
                }
                else if (fSourceType == FDataSourceType.ItemTag5)
                {
                    return fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_UserTag5, FXmlTagSITL.D_UserTag5);
                }
                // --
                return string.Empty;
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

        private static string getHostItemLogValueBySourceType(
            FDataSourceType fSourceType,
            FXmlNode fXmlNodeHitl
            )
        {
            try
            {
                if (fSourceType == FDataSourceType.ItemTag1)
                {
                    return fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_UserTag1, FXmlTagHITL.D_UserTag1);
                }
                else if (fSourceType == FDataSourceType.ItemTag2)
                {
                    return fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_UserTag2, FXmlTagHITL.D_UserTag2);
                }
                else if (fSourceType == FDataSourceType.ItemTag3)
                {
                    return fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_UserTag3, FXmlTagHITL.D_UserTag3);
                }
                else if (fSourceType == FDataSourceType.ItemTag4)
                {
                    return fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_UserTag4, FXmlTagHITL.D_UserTag4);
                }
                else if (fSourceType == FDataSourceType.ItemTag5)
                {
                    return fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_UserTag5, FXmlTagHITL.D_UserTag5);
                }
                // --
                return string.Empty;
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

        #region DataSetLog Generation Methods

        public static FXmlNode generateDataSetLog(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeDts        // Modeling된 Data Set
            )
        {
            const string EnvQuery = "//" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_SourceType + "='{0}']";

            FXmlNode fXmlNodeDtsl = null;

            try
            {
                // ***
                // Resource Mapping
                // ***
                generateDataSetLogByResource(fScenarioData, fXmlNodeDts);
                fXmlNodeDtsl = fXmlNodeDts;

                // ***
                // Message SystemBytes Mapping
                // ***
                if (fScenarioData.hasDataMessageReceivedLog)
                {
                    if (fScenarioData.fDataMessageReceivedLog.fMessageLogType == FMessageLogType.SecsDeviceDataMessageReceivedLog)
                    {                        
                        generateDataSetLogByMessage(fScenarioData, fXmlNodeDts);
                        fXmlNodeDtsl = fXmlNodeDts;
                    }
                }

                // --

                // ***
                // EquipmentState Mapping
                // ***
                generateDataSetLogByEquipmentState(fScenarioData, fXmlNodeDts);
                fXmlNodeDtsl = fXmlNodeDts;

                // --

                // ***
                // Environment Mapping
                // Source Type이 Environment가 존재할 경우에만 수행
                // ***
                if (fXmlNodeDtsl.containsNode(string.Format(EnvQuery, FEnumConverter.fromDataSourceType(FDataSourceType.Environment))))
                {
                    fXmlNodeDtsl = generateDataSetLogByEnvironment(fScenarioData, fXmlNodeDtsl);
                }

                // --

                // ***
                // Repository Material Mapping
                // ***
                if (fScenarioData.hasRepositoryMaterial)
                {
                    fXmlNodeDtsl = generateDataSetLogByRepositoryMaterial(fScenarioData, fXmlNodeDtsl);
                }
                

                // --

                // ***
                // Receive된 SECS 메시지 또는 Host 메시지 Mapping
                // ***
                if (fScenarioData.hasDataMessageReceivedLog)
                {
                    if (fScenarioData.fDataMessageReceivedLog.fMessageLogType == FMessageLogType.SecsDeviceDataMessageReceivedLog)
                    {
                        fXmlNodeDtsl = generateDataSetLogBySecsMessageLog(fScenarioData, fXmlNodeDtsl);
                    }
                    else
                    {
                        fXmlNodeDtsl = generateDataSetLogByHostMessageLog(fScenarioData, fXmlNodeDtsl);
                    }
                }

                // --

                // ***
                // Mapping되지 않은 Variable(제거)과 Fixed(확장) 데이터 처리
                // *** 
                generateDataLogByPattern(
                    fScenarioData,
                    fXmlNodeDtsl,
                    fXmlNodeDtsl.selectNodes(FXmlTagDATL.E_Data)
                    );

                // --

                return fXmlNodeDtsl;
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

        private static void generateDataSetLogByResource(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeDtsl
            )
        {
            const string DataLogQuery = "//" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_SourceType + "='{0}']";

            // --

            string xpath = string.Empty;
            FResourceSourceType fResourceSourceType;
            string val = string.Empty;
            int len = 0;

            try
            {
                collectResourceData(fScenarioData);

                // --

                xpath = string.Format(DataLogQuery, FEnumConverter.fromDataSourceType(FDataSourceType.Resource));
                // --
                foreach (FXmlNode fXmlNodeDatl in fXmlNodeDtsl.selectNodes(xpath))
                {
                    fResourceSourceType = FEnumConverter.toResourceSourceType(
                        fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_SourceResource, FXmlTagDATL.D_SourceResource)
                        );

                    // --

                    if (fResourceSourceType == FResourceSourceType.None)
                    {
                        val = string.Empty;
                    }
                    else if (fResourceSourceType == FResourceSourceType.EapName)
                    {
                        val = fScenarioData.fResourceData.eapName;
                    }
                    else if (fResourceSourceType == FResourceSourceType.EquipmentName)
                    {
                        val = fScenarioData.fResourceData.equipmentName;
                    }
                    else if (fResourceSourceType == FResourceSourceType.SecsDeviceName)
                    {
                        val = fScenarioData.fResourceData.secsDeviceName;
                    }
                    else if (fResourceSourceType == FResourceSourceType.SecsSessionName)
                    {
                        val = fScenarioData.fResourceData.secsSessionName;
                    }
                    else if (fResourceSourceType == FResourceSourceType.SecsSessionId)
                    {
                        val = fScenarioData.fResourceData.secsSessionId;
                    }
                    else if (fResourceSourceType == FResourceSourceType.HostDeviceName)
                    {
                        val = fScenarioData.fResourceData.hostDeviceName;
                    }
                    else if (fResourceSourceType == FResourceSourceType.HostSessionName)
                    {
                        val = fScenarioData.fResourceData.hostSessionName;
                    }
                    else if (fResourceSourceType == FResourceSourceType.HostSessionId)
                    {
                        val = fScenarioData.fResourceData.hostSessionId;
                    }
                    else if (fResourceSourceType == FResourceSourceType.HostMachineId)
                    {
                        val = fScenarioData.fResourceData.hostMachineId;
                    }

                    // --

                    len = 0;
                    val = FValueConverter.fromStringValue(FFormat.Ascii, val, out len);

                    // --

                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
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

        private static void generateDataSetLogByMessage(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeDtsl
            )
        {
            const string DataLogQuery = "//" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_SourceType + "='{0}']";

            // --

            string xpath = string.Empty;
            FMessageSourceType fMessageSourceType;
            string val = string.Empty;
            int len = 0;

            try
            {
                collectResourceData(fScenarioData);

                // --

                xpath = string.Format(DataLogQuery, FEnumConverter.fromDataSourceType(FDataSourceType.Message));
                // --
                foreach (FXmlNode fXmlNodeDatl in fXmlNodeDtsl.selectNodes(xpath))
                {
                    fMessageSourceType = FEnumConverter.toMessageSourceType(
                        fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_SourceMessage, FXmlTagDATL.D_SourceMessage)
                        );

                    // --

                    if (fMessageSourceType == FMessageSourceType.None)
                    {
                        val = string.Empty;
                    }
                    else if (fMessageSourceType == FMessageSourceType.SystemBytes)
                    {
                        val = ((FSecsDeviceDataMessageReceivedLog)fScenarioData.fDataMessageReceivedLog).systemBytes.ToString();
                    }

                    // --

                    len = 0;
                    val = FValueConverter.fromStringValue(FFormat.Ascii, val, out len);

                    // --

                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
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

        private static void generateDataSetLogByEquipmentState(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeDtsl
            )
        {
            const string DataLogQuery = "//" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_SourceType + "='{0}']";

            // --

            FXmlNode fXmlNodeEst = null;
            FEquipmentStateMaterial fEquipmentStateMaterial = null;
            string xpath = string.Empty;
            string estName = string.Empty;
            string eqpUniqueId = string.Empty;
            string estUniqueId = string.Empty;
            string val = string.Empty;
            int len = 0;

            try
            {
                eqpUniqueId = fScenarioData.fEquipment.uniqueIdToString;

                // --

                xpath = string.Format(DataLogQuery, FEnumConverter.fromDataSourceType(FDataSourceType.EquipmentState));
                // --
                foreach (FXmlNode fXmlNodeDatl in fXmlNodeDtsl.selectNodes(xpath))
                {
                    estName = fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_SourceEquipmentState, FXmlTagDATL.D_SourceEquipmentState);

                    // --

                    fXmlNodeEst = collectEquipmentState(fScenarioData, estName);
                    if (fXmlNodeEst == null)
                    {
                        continue;
                    }
                    // --
                    estUniqueId = fXmlNodeEst.get_attrVal(FXmlTagEST.A_UniqueId, FXmlTagEST.D_UniqueId);

                    // --

                    fEquipmentStateMaterial = fScenarioData.fScdCore.fEquipmentStateMaterialStorage.getEquipmentStateMaterial(eqpUniqueId, estUniqueId);
                    if (fEquipmentStateMaterial == null)
                    {
                        val = fXmlNodeEst.get_attrVal(FXmlTagEST.A_DefaultValue, FXmlTagEST.D_DefaultValue);
                    }
                    else
                    {
                        val = fEquipmentStateMaterial.stateValue;
                    }

                    // --

                    len = 0;
                    val = FValueConverter.fromStringValue(FFormat.Ascii, val, out len);

                    // --

                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeEst = null;
                fEquipmentStateMaterial = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static FXmlNode generateDataSetLogByEnvironment(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeDts
            )
        {
            Dictionary<string, int> gEnvPosition = null;              // Environment Position (Environment Name, Position)
            Dictionary<string, FXmlNodeList> gEnvPositionData = null; // Environment Position Data (Environment Name, Environment Node List)
            FXmlNode fXmlNodeDtsl = null;

            try
            {
                // ***
                // Global Scan 용 Environment Data 저장소 생성
                // ***
                gEnvPosition = new Dictionary<string, int>();
                gEnvPositionData = new Dictionary<string, FXmlNodeList>();

                // --

                fXmlNodeDtsl = fXmlNodeDts.clone(false);
                // --
                generateDataLogByEnvironment(
                    fScenarioData,
                    fXmlNodeDtsl,
                    fXmlNodeDts.selectNodes(FXmlTagDAT.E_Data),
                    gEnvPosition,
                    gEnvPositionData,
                    null
                    );

                // --

                return fXmlNodeDtsl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                gEnvPosition = null;
                gEnvPositionData = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void generateDataLogByEnvironment(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeParent,
            FXmlNodeList fXmlNodeListDat,
            Dictionary<string, int> gEnvPositionKey,
            Dictionary<string, FXmlNodeList> gEnvPositionData,
            FXmlNode fXmlNodeParentEnv
            )
        {
            FXmlNode fXmlNodeDat = null;
            FXmlNode fXmlNodeDatl = null;
            FXmlNodeList fXmlNodeListEnv = null;
            FXmlNode fXmlNodeEnv = null;
            FXmlNode fXmlNodeSrc = null;
            FXmlNode fXmlNodeTgt = null;
            int datCount = 0;
            int index = 0;
            Dictionary<string, int> envPositionKey = null;
            Dictionary<string, FXmlNodeList> envPositionData = null;
            Dictionary<string, int> varNameCount = null;
            Dictionary<string, int> fixNameCount = null;
            int envPos = 0;
            FDataSourceType fSourceType;
            string envName = string.Empty;
            FFormat fFormat;
            FPattern fPattern;
            int fixedLength = 0;
            FDataScanMode fScanMode;
            int fixLen = 0;
            int varLen = 0;
            int varCnt = 0;
            int calVarCnt = 0;
            string val = string.Empty;
            int len = 0;
            string genName = string.Empty;
            FFormat fItemFormat;

            try
            {
                // ***
                // 동일한 이름의 Environment가 사용된 회수를 보관하기 위한 Storage 생성 (Local Scan 용)
                // ***
                envPositionKey = new Dictionary<string, int>();
                envPositionData = new Dictionary<string, FXmlNodeList>();
                datCount = fXmlNodeListDat.count;

                // --

                while (index < datCount)
                {
                    fXmlNodeDat = fXmlNodeListDat[index];
                    fSourceType = FEnumConverter.toDataSourceType(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_SourceType, FXmlTagDAT.D_SourceType));
                    fFormat = FEnumConverter.toFormat(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_Format, FXmlTagDAT.D_Format));

                    // --

                    // ***
                    // Source Type이 Environment가 아닌 개체 처리
                    // ***
                    if (fSourceType != FDataSourceType.Environment)
                    {
                        fXmlNodeDatl = fXmlNodeParent.appendChild(fXmlNodeDat.clone(false));

                        // --

                        if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                        {
                            generateDataLogByEnvironment(
                                fScenarioData,
                                fXmlNodeDatl,
                                fXmlNodeDat.selectNodes(FXmlTagDATL.E_Data),
                                gEnvPositionKey,
                                gEnvPositionData,
                                fXmlNodeParentEnv
                                );
                        }
                        index++;
                        continue;
                    }

                    // --

                    fPattern = FEnumConverter.toPattern(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_Pattern, FXmlTagDAT.D_Pattern));
                    // --
                    if (fPattern == FPattern.Fixed)
                    {
                        #region Fixed

                        fScanMode = FEnumConverter.toDataScanMode(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_ScanMode, FXmlTagDAT.D_ScanMode));
                        envName = fXmlNodeDat.get_attrVal(FXmlTagDAT.A_SourceEnvironment, FXmlTagDAT.D_SourceEnvironment);
                        // --
                        if (fScanMode == FDataScanMode.Local)
                        {
                            if (envPositionKey.ContainsKey(envName))
                            {
                                envPos = envPositionKey[envName];
                                fXmlNodeListEnv = envPositionData[envName];
                            }
                            else
                            {
                                envPos = 0;
                                fXmlNodeListEnv = collectEnvironmentByLocalScan(fScenarioData, fXmlNodeParentEnv, envName);
                                // --
                                envPositionKey.Add(envName, envPos);
                                envPositionData.Add(envName, fXmlNodeListEnv);
                            }
                        }
                        else
                        {
                            if (gEnvPositionKey.ContainsKey(envName))
                            {
                                envPos = gEnvPositionKey[envName];
                                fXmlNodeListEnv = gEnvPositionData[envName];
                            }
                            else
                            {
                                envPos = 0;
                                fXmlNodeListEnv = collectEnvironmentByGlobalScan(fScenarioData, envName);
                                // --
                                gEnvPositionKey.Add(envName, envPos);
                                gEnvPositionData.Add(envName, fXmlNodeListEnv);
                            }
                        }

                        // --

                        fixedLength = int.Parse(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_FixedLength, FXmlTagDAT.D_FixedLength));
                        // --
                        for (int i = 0; i < fixedLength; i++)
                        {
                            fXmlNodeDatl = fXmlNodeParent.appendChild(fXmlNodeDat.clone(false));
                            fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_FixedLength, FXmlTagDATL.D_FixedLength, "1");

                            // --

                            // ***
                            // Fixed일 경우 Environment Position이 초과할 경우 다시 순환시킨다.
                            // ***
                            if (fXmlNodeListEnv.count == 0)
                            {
                                fXmlNodeEnv = null;
                            }
                            else
                            {
                                if (envPos >= fXmlNodeListEnv.count)
                                {
                                    envPos = 0; // 순환
                                }
                                fXmlNodeEnv = fXmlNodeListEnv[envPos];
                                envPos++;

                                // --

                                // ***
                                // 2017.03.23 by spike.lee
                                // Unknown Format에 List Format이 적용될 경우 Child 처리에 Position이 저장되지 않아 무한루프 도는 문제가 발생하여
                                // Position 저장 위치를 변경 함.
                                // *** 
                                if (fScanMode == FDataScanMode.Local)
                                {
                                    envPositionKey[envName] = envPos;
                                }
                                else
                                {
                                    gEnvPositionKey[envName] = envPos;
                                }
                            }

                            // --

                            if (fXmlNodeEnv == null)
                            {
                                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                                {
                                    generateDataLogByEnvironment(
                                        fScenarioData,
                                        fXmlNodeDatl,
                                        fXmlNodeDat.selectNodes(FXmlTagDAT.E_Data),
                                        gEnvPositionKey,
                                        gEnvPositionData,
                                        fXmlNodeParentEnv
                                        );
                                }
                            }
                            else
                            {
                                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                                {
                                    generateDataLogByEnvironment(
                                        fScenarioData,
                                        fXmlNodeDatl,
                                        fXmlNodeDat.selectNodes(FXmlTagDATL.E_Data),
                                        gEnvPositionKey,
                                        gEnvPositionData,
                                        fXmlNodeEnv
                                        );
                                }
                                else if (fFormat == FFormat.Unknown)
                                {
                                    // ***
                                    // Unknown Data Log 복제
                                    // ***
                                    fXmlNodeSrc = fXmlNodeDat.clone(false);

                                    // --

                                    // ***
                                    // Data Log의 Format를 Environment Format으로 설정
                                    // ***
                                    // --
                                    // ***
                                    // 2017.03.23 by spike.lee
                                    // fFormat를 fItemFormat으로 변경
                                    // ***
                                    fItemFormat = FEnumConverter.toFormat(fXmlNodeEnv.get_attrVal(FXmlTagENV.A_Format, FXmlTagENV.D_Format));
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format, FEnumConverter.fromFormat(fItemFormat));

                                    // --

                                    if (fItemFormat == FFormat.List || fItemFormat == FFormat.AsciiList)
                                    {
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // fXmlNodeTgt를 fXmlNodeDatl에 Append하고 generteDataLogBySecsItemLog에서 또 Append하여 Item이 2배 생성되는 문제 발생
                                        // Unknown Foramt Data인 경우 하위 Child Data에 _(Depth)를 붙여 이름을 Generate
                                        // ***
                                        len = 0;
                                        // genName = fXmlNodeSrc.get_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name) + "_";
                                        genName = fXmlNodeSrc.get_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name) + "_n";
                                        foreach (FXmlNode x in fXmlNodeEnv.selectNodes(FXmlTagENV.E_Environment))
                                        {
                                            fXmlNodeTgt = fXmlNodeSrc.clone(false);
                                            // fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name, genName + (len + 1).ToString());
                                            fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name, genName);
                                            fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_FixedLength, FXmlTagDATL.D_FixedLength, "1");                                                
                                            fXmlNodeTgt.set_attrVal(
                                                FXmlTagDATL.A_SourceEnvironment,
                                                FXmlTagDATL.D_SourceEnvironment,
                                                x.get_attrVal(FXmlTagENV.A_Name, FXmlTagENV.D_Name)
                                                );
                                            // ***
                                            // fXmlNodeTgt = fXmlNodeDatl.appendChild(fXmlNodeTgt);
                                            // ***
                                            // --
                                            generateDataLogByEnvironment(
                                                fScenarioData,
                                                fXmlNodeDatl,
                                                fXmlNodeTgt.selectNodes("."),
                                                gEnvPositionKey,
                                                gEnvPositionData,
                                                x
                                                );
                                            // --
                                            len++;
                                        }
                                        // --
                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                    }
                                    else if (fItemFormat == FFormat.Raw)
                                    {
                                        fXmlNodeDatl.set_attrVal(
                                            FXmlTagDATL.A_Length,
                                            FXmlTagDATL.D_Length,
                                            fXmlNodeEnv.get_attrVal(FXmlTagENV.A_Length, FXmlTagENV.D_Length)
                                            );
                                    }
                                    else if (fItemFormat != FFormat.Unknown)
                                    {
                                        fXmlNodeDatl.set_attrVal(
                                            FXmlTagDATL.A_Value,
                                            FXmlTagDATL.D_Value,
                                            fXmlNodeEnv.get_attrVal(FXmlTagENV.A_Value, FXmlTagENV.D_Value)
                                            );
                                        // --
                                        fXmlNodeDatl.set_attrVal(
                                            FXmlTagDATL.A_Length,
                                            FXmlTagDATL.D_Length,
                                            fXmlNodeEnv.get_attrVal(FXmlTagENV.A_Length, FXmlTagENV.D_Length)
                                            );
                                    }
                                }
                                else if (fFormat == FFormat.Raw)
                                {
                                    len = calculateEnvironmentRawBytes(fXmlNodeEnv);
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                }
                                else
                                {
                                    val = fXmlNodeEnv.get_attrVal(FXmlTagENV.A_Value, FXmlTagENV.D_Value);
                                    // --
                                    len = 0;
                                    val = FValueConverter.convertStringValue(fFormat, val, out len);
                                    // --
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                }
                            }
                        }   // fixedLength for end

                        // --

                        // ***
                        // Parent가 FData일 경우 Length 설정
                        // ***
                        if (fixedLength > 1 || fXmlNodeParent.name == FXmlTagDATL.E_Data)
                        {
                            len = int.Parse(fXmlNodeParent.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length)) + fixedLength - 1;
                            fXmlNodeParent.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                        }

                        // --

                        index++;

                        #endregion
                    }
                    else   // Variable
                    {
                        #region Variable

                        fixLen = 0;
                        varLen = 0;
                        varCnt = 0;
                        calVarCnt = 0;
                        // --
                        varNameCount = new Dictionary<string, int>();
                        fixNameCount = new Dictionary<string, int>();

                        // --

                        for (int i = index; i < datCount; i++)
                        {
                            fXmlNodeSrc = fXmlNodeListDat[i];
                            // --
                            fSourceType = FEnumConverter.toDataSourceType(fXmlNodeSrc.get_attrVal(FXmlTagDAT.A_SourceType, FXmlTagDAT.D_SourceType));
                            if (fSourceType != FDataSourceType.Environment)
                            {
                                continue;
                            }

                            // --

                            // ***
                            // 1. Previous Data Log는 Fixed 형식으로 처리
                            // 2. Variable Data Log는 연속적으로 정의되어 있어 우선 처리
                            // 3. Next Data Log는 Variable Data Log 처리 이후 Fixed 형식으로 처리
                            // ***
                            fPattern = FEnumConverter.toPattern(fXmlNodeSrc.get_attrVal(FXmlTagDAT.A_Pattern, FXmlTagDAT.D_Pattern));
                            envName = fXmlNodeSrc.get_attrVal(FXmlTagDAT.A_SourceEnvironment, FXmlTagDAT.D_SourceEnvironment);
                            // --
                            if (fPattern == FPattern.Variable)
                            {
                                if (varNameCount.ContainsKey(envName))
                                {
                                    varNameCount[envName] = varNameCount[envName] + 1;
                                }
                                else
                                {
                                    varNameCount.Add(envName, 1);
                                    fixNameCount.Add(envName, 0);
                                }
                                varLen++;

                                // --

                                if (!envPositionKey.ContainsKey(envName))
                                {
                                    envPositionKey.Add(envName, 0);
                                    envPositionData.Add(envName, collectEnvironmentByVariable(fScenarioData, fXmlNodeParentEnv, envName));
                                }
                            }
                            else
                            {
                                // ***
                                // Scan Mode가 Global인 Fixed Data Log는 Variable 계산에 미포함
                                // ***
                                fScanMode = FEnumConverter.toDataScanMode(fXmlNodeSrc.get_attrVal(FXmlTagDAT.A_ScanMode, FXmlTagDAT.D_ScanMode));
                                if (fScanMode == FDataScanMode.Local && fixNameCount.ContainsKey(envName))
                                {
                                    fixLen = int.Parse(fXmlNodeSrc.get_attrVal(FXmlTagDAT.A_FixedLength, FXmlTagDAT.D_FixedLength));
                                    fixNameCount[envName] = fixNameCount[envName] + fixLen;
                                }
                            }
                        }

                        // --

                        // ***
                        // Variable 회수 구하기 (Minimum)                        
                        // ***
                        foreach (string s in varNameCount.Keys)
                        {
                            calVarCnt = (envPositionData[s].count - envPositionKey[s] - fixNameCount[s]) / varNameCount[s];
                            if (calVarCnt < 1)
                            {
                                varCnt = 0;
                                break;
                            }
                            // --
                            if (varCnt == 0)
                            {
                                varCnt = calVarCnt;
                            }
                            else if (varCnt > calVarCnt)
                            {
                                varCnt = calVarCnt;
                            }
                        }

                        // --

                        for (int i = 0; i < varCnt; i++)
                        {
                            for (int j = 0; j < varLen; j++)
                            {
                                fXmlNodeDat = fXmlNodeListDat[index + j];
                                fFormat = FEnumConverter.toFormat(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_Format, FXmlTagDAT.D_Format));
                                // --
                                envName = fXmlNodeDat.get_attrVal(FXmlTagDATL.A_SourceEnvironment, FXmlTagDATL.D_SourceEnvironment);
                                envPos = envPositionKey[envName];
                                fXmlNodeEnv = envPositionData[envName][envPos];
                                envPos++;

                                // --

                                // ***
                                // 2017.03.23 by spike.lee
                                // Unknown Format에 List Format이 적용될 경우 Child 처리에 Position이 저장되지 않아 무한루프 도는 문제가 발생하여
                                // Position 저장 위치를 변경 함.
                                // *** 
                                envPositionKey[envName] = envPos;

                                // --

                                fXmlNodeDatl = fXmlNodeParent.appendChild(fXmlNodeDat.clone(false));
                                fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Pattern, FXmlTagDATL.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));

                                // --

                                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                                {
                                    generateDataLogByEnvironment(
                                        fScenarioData,
                                        fXmlNodeDatl,
                                        fXmlNodeDat.selectNodes(FXmlTagDAT.E_Data),
                                        gEnvPositionKey,
                                        gEnvPositionData,
                                        fXmlNodeEnv
                                        );
                                }
                                else if (fFormat == FFormat.Unknown)
                                {
                                    // ***
                                    // Unknown Data Log 복제
                                    // ***
                                    fXmlNodeSrc = fXmlNodeDat.clone(false);

                                    // --

                                    // ***
                                    // Data Log의 Format를 Environment Format으로 설정
                                    // ***
                                    // --
                                    // ***
                                    // 2017.03.23 by spike.lee
                                    // fFormat를 fItemFormat으로 변경
                                    // ***
                                    fItemFormat = FEnumConverter.toFormat(fXmlNodeEnv.get_attrVal(FXmlTagENV.A_Format, FXmlTagENV.D_Format));
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format, FEnumConverter.fromFormat(fItemFormat));

                                    // --

                                    if (fItemFormat == FFormat.List || fItemFormat == FFormat.AsciiList)
                                    {
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // Unknown Foramt Data인 경우 하위 Child Data에 _(Depth)를 붙여 이름을 Generate
                                        // 추가되는 fXmlNodeTgt Variable 속성을 Fixed로 변경
                                        // ***
                                        len = 0;
                                        // genName = fXmlNodeSrc.get_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name) + "_";
                                        genName = fXmlNodeSrc.get_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name) + "_n";
                                        foreach (FXmlNode x in fXmlNodeEnv.selectNodes(FXmlTagENV.E_Environment))
                                        {
                                            fXmlNodeTgt = fXmlNodeSrc.clone(false);
                                            // fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name, genName + (len + 1).ToString());
                                            fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name, genName);
                                            fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_Pattern, FXmlTagDATL.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                                            fXmlNodeTgt.set_attrVal(
                                                FXmlTagDATL.A_SourceEnvironment,
                                                FXmlTagDATL.D_SourceEnvironment,
                                                x.get_attrVal(FXmlTagENV.A_Name, FXmlTagENV.D_Name)
                                                );
                                            // ***
                                            // fXmlNodeTgt = fXmlNodeDatl.appendChild(fXmlNodeTgt);
                                            // *** 
                                            // --
                                            generateDataLogByEnvironment(
                                                fScenarioData,
                                                fXmlNodeDatl,
                                                fXmlNodeTgt.selectNodes("."),
                                                gEnvPositionKey,
                                                gEnvPositionData,
                                                x
                                                );
                                            // --
                                            len++;
                                        }
                                        // --
                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                    }
                                    else if (fItemFormat == FFormat.Raw)
                                    {
                                        fXmlNodeDatl.set_attrVal(
                                            FXmlTagDATL.A_Length,
                                            FXmlTagDATL.D_Length,
                                            fXmlNodeEnv.get_attrVal(FXmlTagENV.A_Length, FXmlTagENV.D_Length)
                                            );
                                    }
                                    else if (fItemFormat != FFormat.Unknown)
                                    {
                                        fXmlNodeDatl.set_attrVal(
                                            FXmlTagDATL.A_Value,
                                            FXmlTagDATL.D_Value,
                                            fXmlNodeEnv.get_attrVal(FXmlTagENV.A_Value, FXmlTagENV.D_Value)
                                            );
                                        // --
                                        fXmlNodeDatl.set_attrVal(
                                            FXmlTagDATL.A_Length,
                                            FXmlTagDATL.D_Length,
                                            fXmlNodeEnv.get_attrVal(FXmlTagENV.A_Length, FXmlTagENV.D_Length)
                                            );
                                    }
                                }
                                else if (fFormat == FFormat.Raw)
                                {
                                    len = calculateEnvironmentRawBytes(fXmlNodeEnv);
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                }
                                else
                                {
                                    val = fXmlNodeEnv.get_attrVal(FXmlTagENV.A_Value, FXmlTagENV.D_Value);
                                    // --
                                    len = 0;
                                    val = FValueConverter.convertStringValue(fFormat, val, out len);
                                    // --
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                }
                            }   // for end
                        }   // for end

                        // --

                        // ***
                        // Parent가 Data Log일 경우 추가된 Variable Data Log 만큼 Length 증가
                        // ***
                        if (fXmlNodeParent.name == FXmlTagDATL.E_Data)
                        {
                            len = int.Parse(fXmlNodeParent.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length)) + ((varCnt - 1) * varLen);
                            fXmlNodeParent.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                        }

                        // --                        

                        index += varLen;

                        #endregion
                    }
                }   // while end
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeDat = null;
                fXmlNodeDatl = null;
                fXmlNodeListEnv = null;
                fXmlNodeEnv = null;
                fXmlNodeSrc = null;
                fXmlNodeTgt = null;
                envPositionKey = null;
                envPositionData = null;
                varNameCount = null;
                fixNameCount = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static FXmlNode generateDataSetLogByRepositoryMaterial(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeDts
            )
        {
            Dictionary<string, int> gColPositionKey = null;              // Column Name, Position
            Dictionary<string, FXmlNodeList> gColPositionData = null;    // Column Name, Column Node List 
            FXmlNode fXmlNodeDtsl = null;

            try
            {
                gColPositionKey = new Dictionary<string, int>();
                gColPositionData = new Dictionary<string, FXmlNodeList>();

                // --

                fXmlNodeDtsl = fXmlNodeDts.clone(false);
                // --
                generateDataLogByColumn(
                    fScenarioData,
                    fXmlNodeDtsl,
                    fXmlNodeDts.selectNodes(FXmlTagDAT.E_Data),
                    gColPositionKey,
                    gColPositionData,
                    null
                    );

                // --

                return fXmlNodeDtsl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                gColPositionKey = null;
                gColPositionData = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void generateDataLogByColumn(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeParent,
            FXmlNodeList fXmlNodeListDat,
            Dictionary<string, int> gColPositionKey,
            Dictionary<string, FXmlNodeList> gColPositionData,
            FXmlNode fXmlNodeParentCol
            )
        {
            FXmlNode fXmlNodeDat = null;
            FXmlNode fXmlNodeDatl = null;
            FXmlNodeList fXmlNodeListCol = null;
            FXmlNode fXmlNodeCol = null;
            FXmlNode fXmlNodeSrc = null;
            FXmlNode fXmlNodeTgt = null;
            int datCount = 0;
            int index = 0;
            Dictionary<string, int> colPositionKey = null;
            Dictionary<string, FXmlNodeList> colPositionData = null;
            Dictionary<string, int> varNameCount = null;
            Dictionary<string, int> fixNameCount = null;
            int colPos = 0;
            FDataSourceType fSourceType;
            string colName = string.Empty;
            FFormat fFormat;
            FPattern fPattern;
            int fixedLength = 0;
            FDataScanMode fScanMode;
            int fixLen = 0;
            int varLen = 0;
            int varCnt = 0;
            int calVarCnt = 0;
            string val = string.Empty;
            int len = 0;
            string genName = string.Empty;
            FFormat fItemFormat;

            try
            {
                // ***
                // 동일한 이름의 Column이 사용된 회수를 보관하기 위한 Storage 생성
                // ***
                colPositionKey = new Dictionary<string, int>();
                colPositionData = new Dictionary<string, FXmlNodeList>();
                datCount = fXmlNodeListDat.count;

                // --

                while (index < datCount)
                {
                    fXmlNodeDat = fXmlNodeListDat[index];
                    fSourceType = FEnumConverter.toDataSourceType(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_SourceType, FXmlTagDAT.D_SourceType));
                    fFormat = FEnumConverter.toFormat(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_Format, FXmlTagDAT.D_Format));

                    // --

                    // ***
                    // Source Type이 Column이 아닌 개체 처리
                    // ***
                    if (fSourceType != FDataSourceType.Column)
                    {
                        fXmlNodeDatl = fXmlNodeParent.appendChild(fXmlNodeDat.clone(false));

                        // --

                        if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                        {
                            generateDataLogByColumn(
                                fScenarioData,
                                fXmlNodeDatl,
                                fXmlNodeDat.selectNodes(FXmlTagDATL.E_Data),
                                gColPositionKey,
                                gColPositionData,
                                fXmlNodeParentCol
                                );
                        }
                        index++;
                        continue;
                    }

                    // --

                    fPattern = FEnumConverter.toPattern(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_Pattern, FXmlTagDAT.D_Pattern));
                    // --
                    if (fPattern == FPattern.Fixed)
                    {
                        #region Fixed

                        fScanMode = FEnumConverter.toDataScanMode(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_ScanMode, FXmlTagDAT.D_ScanMode));
                        colName = fXmlNodeDat.get_attrVal(FXmlTagDAT.A_SourceColumn, FXmlTagDAT.D_SourceColumn);
                        // --
                        if (fScanMode == FDataScanMode.Local)
                        {
                            if (colPositionKey.ContainsKey(colName))
                            {
                                colPos = colPositionKey[colName];
                                fXmlNodeListCol = colPositionData[colName];
                            }
                            else
                            {
                                colPos = 0;
                                fXmlNodeListCol = collectColumnByLocalScan(fScenarioData, fXmlNodeParentCol, colName);
                                // --
                                colPositionKey.Add(colName, colPos);
                                colPositionData.Add(colName, fXmlNodeListCol);
                            }
                        }
                        else
                        {
                            if (gColPositionKey.ContainsKey(colName))
                            {
                                colPos = gColPositionKey[colName];
                                fXmlNodeListCol = gColPositionData[colName];
                            }
                            else
                            {
                                colPos = 0;
                                fXmlNodeListCol = collectColumnByGlobalScan(fScenarioData, colName);
                                // --
                                gColPositionKey.Add(colName, colPos);
                                gColPositionData.Add(colName, fXmlNodeListCol);
                            }
                        }

                        // --

                        fixedLength = int.Parse(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_FixedLength, FXmlTagDAT.D_FixedLength));
                        // --
                        for (int i = 0; i < fixedLength; i++)
                        {
                            fXmlNodeDatl = fXmlNodeParent.appendChild(fXmlNodeDat.clone(false));
                            fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_FixedLength, FXmlTagDATL.D_FixedLength, "1");

                            // --

                            // ***
                            // Fixed일 경우 Column Position이 초과할 경우 다시 순환시킨다.
                            // ***
                            if (fXmlNodeListCol.count == 0)
                            {
                                fXmlNodeCol = null;
                            }
                            else
                            {
                                if (colPos >= fXmlNodeListCol.count)
                                {
                                    colPos = 0; // 순환
                                }
                                fXmlNodeCol = fXmlNodeListCol[colPos];
                                colPos++;

                                // --

                                // ***
                                // 2017.03.23 by spike.lee
                                // Unknown Format에 List Format이 적용될 경우 Child 처리에 Position이 저장되지 않아 무한루프 도는 문제가 발생하여
                                // Position 저장 위치를 변경 함.
                                // *** 
                                if (fScanMode == FDataScanMode.Local)
                                {
                                    colPositionKey[colName] = colPos;
                                }
                                else
                                {
                                    gColPositionKey[colName] = colPos;
                                }
                            }

                            // --

                            if (fXmlNodeCol == null)
                            {
                                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                                {
                                    generateDataLogByColumn(
                                        fScenarioData,
                                        fXmlNodeDatl,
                                        fXmlNodeDat.selectNodes(FXmlTagDAT.E_Data),
                                        gColPositionKey,
                                        gColPositionData,
                                        fXmlNodeParentCol
                                        );
                                }
                            }
                            else
                            {
                                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                                {
                                    generateDataLogByColumn(
                                        fScenarioData,
                                        fXmlNodeDatl,
                                        fXmlNodeDat.selectNodes(FXmlTagDAT.E_Data),
                                        gColPositionKey,
                                        gColPositionData,
                                        fXmlNodeCol
                                        );
                                }
                                else if (fFormat == FFormat.Unknown)
                                {
                                    // ***
                                    // Unknown Data Log 복제
                                    // ***
                                    fXmlNodeSrc = fXmlNodeDat.clone(false);

                                    // --

                                    // ***
                                    // Data Log의 Format를 Column Format으로 설정
                                    // ***
                                    // --
                                    // ***
                                    // 2017.03.23 by spike.lee
                                    // fFormat를 fItemFormat으로 변경
                                    // ***
                                    fItemFormat = FEnumConverter.toFormat(fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Format, FXmlTagCOL.D_Format));
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format, FEnumConverter.fromFormat(fItemFormat));

                                    // --

                                    if (fItemFormat == FFormat.List || fItemFormat == FFormat.AsciiList)
                                    {
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // fXmlNodeTgt를 fXmlNodeDatl에 Append하고 generteDataLogBySecsItemLog에서 또 Append하여 Item이 2배 생성되는 문제 발생
                                        // Unknown Foramt Data인 경우 하위 Child Data에 _(Depth)를 붙여 이름을 Generate
                                        // ***
                                        len = 0;
                                        // genName = fXmlNodeSrc.get_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name) + "_";
                                        genName = fXmlNodeSrc.get_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name) + "_n";
                                        foreach (FXmlNode x in fXmlNodeCol.selectNodes(FXmlTagCOL.E_Column))
                                        {
                                            fXmlNodeTgt = fXmlNodeSrc.clone(false);
                                            // fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name, genName + (len + 1).ToString());
                                            fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name, genName);
                                            fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_FixedLength, FXmlTagDATL.D_FixedLength, "1");       
                                            fXmlNodeTgt.set_attrVal(
                                                FXmlTagDATL.A_SourceColumn,
                                                FXmlTagDATL.D_SourceColumn,
                                                x.get_attrVal(FXmlTagCOL.A_Name, FXmlTagCOL.D_Name)
                                                );
                                            // ***
                                            // fXmlNodeTgt = fXmlNodeDatl.appendChild(fXmlNodeTgt);
                                            // *** 
                                            // --
                                            generateDataLogByColumn(
                                                fScenarioData,
                                                fXmlNodeDatl,
                                                fXmlNodeTgt.selectNodes("."),
                                                gColPositionKey,
                                                gColPositionData,
                                                x
                                                );
                                            // --
                                            len++;
                                        }
                                        // --
                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                    }
                                    else if (fItemFormat == FFormat.Raw)
                                    {
                                        fXmlNodeDatl.set_attrVal(
                                            FXmlTagDATL.A_Length,
                                            FXmlTagDATL.D_Length,
                                            fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length)
                                            );
                                    }
                                    else if (fItemFormat != FFormat.Unknown)
                                    {
                                        len = int.Parse(fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length));
                                        val = FValueConverter.toDataConversionStringValue(
                                            fFormat,
                                            fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Value, FXmlTagCOL.D_Value),
                                            fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Transformer, FXmlTagCOL.D_Transformer),
                                            fXmlNodeCol.get_attrVal(FXmlTagCOL.A_DataConversionSetExpression, FXmlTagCOL.D_DataConversionSetExpression),
                                            ref len
                                            );
                                        // --
                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                    }
                                }
                                else if (fFormat == FFormat.Raw)
                                {
                                    len = calculateColumnRawBytes(fXmlNodeCol);
                                    fXmlNodeDat.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                }
                                else
                                {
                                    val = FValueConverter.toDataConversionStringValue(
                                        FEnumConverter.toFormat(fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Format, FXmlTagCOL.D_Format)),
                                        fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Value, FXmlTagCOL.D_Value),
                                        fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Transformer, FXmlTagCOL.D_Transformer),
                                        fXmlNodeCol.get_attrVal(FXmlTagCOL.A_DataConversionSetExpression, FXmlTagCOL.D_DataConversionSetExpression)
                                        );
                                    // --
                                    len = 0;
                                    val = FValueConverter.convertStringValue(fFormat, val, out len);
                                    // --
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                }
                            }
                        }   // fixed length for end

                        // --

                        // ***
                        // Parent가 Data일 경우 Length 설정
                        // ***
                        if (fixedLength > 1 || fXmlNodeParent.name == FXmlTagDATL.E_Data)
                        {
                            len = int.Parse(fXmlNodeParent.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length)) + fixedLength - 1;
                            fXmlNodeParent.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                        }

                        // --

                        index++;

                        #endregion
                    }
                    else   // Variable
                    {
                        #region Variable

                        fixLen = 0;
                        varLen = 0;
                        varCnt = 0;
                        calVarCnt = 0;
                        // --
                        varNameCount = new Dictionary<string, int>();
                        fixNameCount = new Dictionary<string, int>();

                        // --

                        for (int i = index; i < datCount; i++)
                        {
                            fXmlNodeSrc = fXmlNodeListDat[i];
                            // --
                            fSourceType = FEnumConverter.toDataSourceType(fXmlNodeSrc.get_attrVal(FXmlTagDAT.A_SourceType, FXmlTagDAT.D_SourceType));
                            if (fSourceType != FDataSourceType.Column)
                            {
                                continue;
                            }

                            // --

                            // ***
                            // 1. Previous Data Log는 Fixed 형식으로 처리
                            // 2. Variable Data Log는 연속적으로 정의되어 있어 우선 처리
                            // 3. Next Data Log는 Variable Data Log 처리 이후 Fixed 형식으로 처리
                            // ***
                            fPattern = FEnumConverter.toPattern(fXmlNodeSrc.get_attrVal(FXmlTagDAT.A_Pattern, FXmlTagDAT.D_Pattern));
                            colName = fXmlNodeSrc.get_attrVal(FXmlTagDAT.A_SourceColumn, FXmlTagDAT.D_SourceColumn);
                            // --
                            if (fPattern == FPattern.Variable)
                            {
                                if (varNameCount.ContainsKey(colName))
                                {
                                    varNameCount[colName] = varNameCount[colName] + 1;
                                }
                                else
                                {
                                    varNameCount.Add(colName, 1);
                                    fixNameCount.Add(colName, 0);
                                }
                                varLen++;

                                // --

                                if (!colPositionKey.ContainsKey(colName))
                                {
                                    colPositionKey.Add(colName, 0);
                                    colPositionData.Add(colName, collectColumnByVariable(fScenarioData, fXmlNodeParentCol, colName));
                                }
                            }
                            else
                            {
                                // ***
                                // Scan Mode가 Global인 Fixed Data Log는 Variable 계산에 미포함
                                // ***
                                fScanMode = FEnumConverter.toDataScanMode(fXmlNodeSrc.get_attrVal(FXmlTagDAT.A_ScanMode, FXmlTagDAT.D_ScanMode));
                                if (fScanMode == FDataScanMode.Local && fixNameCount.ContainsKey(colName))
                                {
                                    fixLen = int.Parse(fXmlNodeSrc.get_attrVal(FXmlTagDAT.A_FixedLength, FXmlTagDAT.D_FixedLength));
                                    fixNameCount[colName] = fixNameCount[colName] + fixLen;
                                }
                            }
                        }

                        // --

                        // ***
                        // Variable 회수 구하기 (Minimum)                        
                        // ***
                        foreach (string s in varNameCount.Keys)
                        {
                            calVarCnt = (colPositionData[s].count - colPositionKey[s] - fixNameCount[s]) / varNameCount[s];
                            if (calVarCnt < 1)
                            {
                                varCnt = 0;
                                break;
                            }
                            // --
                            if (varCnt == 0)
                            {
                                varCnt = calVarCnt;
                            }
                            else if (varCnt > calVarCnt)
                            {
                                varCnt = calVarCnt;
                            }
                        }

                        // --

                        for (int i = 0; i < varCnt; i++)
                        {
                            for (int j = 0; j < varLen; j++)
                            {
                                fXmlNodeDat = fXmlNodeListDat[index + j];
                                fFormat = FEnumConverter.toFormat(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_Format, FXmlTagDAT.D_Format));
                                // --
                                colName = fXmlNodeDat.get_attrVal(FXmlTagDATL.A_SourceColumn, FXmlTagDATL.D_SourceColumn);
                                colPos = colPositionKey[colName];
                                fXmlNodeCol = colPositionData[colName][colPos];
                                colPos++;

                                // --

                                // ***
                                // 2017.03.23 by spike.lee
                                // Unknown Format에 List Format이 적용될 경우 Child 처리에 Position이 저장되지 않아 무한루프 도는 문제가 발생하여
                                // Position 저장 위치를 변경 함.
                                // *** 
                                colPositionKey[colName] = colPos;

                                // --

                                fXmlNodeDatl = fXmlNodeParent.appendChild(fXmlNodeDat.clone(false));
                                fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Pattern, FXmlTagDATL.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));

                                // --

                                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                                {
                                    generateDataLogByColumn(
                                        fScenarioData,
                                        fXmlNodeDatl,
                                        fXmlNodeDat.selectNodes(FXmlTagDATL.E_Data),
                                        gColPositionKey,
                                        gColPositionData,
                                        fXmlNodeCol
                                        );
                                }
                                else if (fFormat == FFormat.Unknown)
                                {
                                    // ***
                                    // Unknown Data Log 복제
                                    // ***
                                    fXmlNodeSrc = fXmlNodeDat.clone(false);

                                    // --

                                    // ***
                                    // Data Log의 Format를 Column Format으로 설정
                                    // ***
                                    // --
                                    // ***
                                    // 2017.03.23 by spike.lee
                                    // fFormat를 fItemFormat으로 변경
                                    // ***
                                    fItemFormat = FEnumConverter.toFormat(fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Format, FXmlTagCOL.D_Format));
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format, FEnumConverter.fromFormat(fItemFormat));

                                    // --

                                    if (fItemFormat == FFormat.List || fItemFormat == FFormat.AsciiList)
                                    {
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // Unknown Foramt Data인 경우 하위 Child Data에 _(Depth)를 붙여 이름을 Generate
                                        // 추가되는 fXmlNodeTgt Variable 속성을 Fixed로 변경
                                        // ***
                                        len = 0;
                                        // genName = fXmlNodeSrc.get_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name) + "_";
                                        genName = fXmlNodeSrc.get_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name) + "_n";
                                        foreach (FXmlNode x in fXmlNodeCol.selectNodes(FXmlTagCOL.E_Column))
                                        {
                                            fXmlNodeTgt = fXmlNodeSrc.clone(false);
                                            // fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name, genName + (len + 1).ToString());
                                            fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name, genName);
                                            fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_Pattern, FXmlTagDATL.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                                            fXmlNodeTgt.set_attrVal(
                                                FXmlTagDATL.A_SourceColumn,
                                                FXmlTagDATL.D_SourceColumn,
                                                x.get_attrVal(FXmlTagCOL.A_Name, FXmlTagCOL.D_Name)
                                                );
                                            // ***
                                            // fXmlNodeTgt = fXmlNodeDatl.appendChild(fXmlNodeTgt);
                                            // ***
                                            // --
                                            generateDataLogByColumn(
                                                fScenarioData,
                                                fXmlNodeDatl,
                                                fXmlNodeTgt.selectNodes("."),
                                                gColPositionKey,
                                                gColPositionData,
                                                x
                                                );
                                            // --
                                            len++;
                                        }
                                        // --
                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                    }
                                    else if (fItemFormat == FFormat.Raw)
                                    {
                                        fXmlNodeDatl.set_attrVal(
                                            FXmlTagDATL.A_Length,
                                            FXmlTagDATL.D_Length,
                                            fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length)
                                            );
                                    }
                                    else if (fItemFormat != FFormat.Unknown)
                                    {
                                        len = int.Parse(fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length));
                                        val = FValueConverter.toDataConversionStringValue(
                                            fFormat,
                                            fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Value, FXmlTagCOL.D_Value),
                                            fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Transformer, FXmlTagCOL.D_Transformer),
                                            fXmlNodeCol.get_attrVal(FXmlTagCOL.A_DataConversionSetExpression, FXmlTagCOL.D_DataConversionSetExpression),
                                            ref len
                                            );
                                        // --
                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                    }
                                }
                                else if (fFormat == FFormat.Raw)
                                {
                                    len = calculateColumnRawBytes(fXmlNodeCol);
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                }
                                else
                                {
                                    val = FValueConverter.toDataConversionStringValue(
                                        FEnumConverter.toFormat(fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Format, FXmlTagCOL.D_Format)),
                                        fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Value, FXmlTagCOL.D_Value),
                                        fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Transformer, FXmlTagCOL.D_Transformer),
                                        fXmlNodeCol.get_attrVal(FXmlTagCOL.A_DataConversionSetExpression, FXmlTagCOL.D_DataConversionSetExpression)
                                        );
                                    // --
                                    len = 0;
                                    val = FValueConverter.convertStringValue(fFormat, val, out len);
                                    // --
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                }
                            }   // for end
                        }   // for end 

                        // --

                        // ***
                        // Parent가 Data Log일 경우 추가된 Variable Data Log 만큼 Length 증가
                        // ***
                        if (fXmlNodeParent.name == FXmlTagDATL.E_Data)
                        {
                            len = int.Parse(fXmlNodeParent.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length)) + ((varCnt - 1) * varLen);
                            fXmlNodeParent.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                        }

                        // --

                        index += varLen;

                        #endregion
                    }
                }   // while end
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeDat = null;
                fXmlNodeDatl = null;
                fXmlNodeListCol = null;
                fXmlNodeCol = null;
                fXmlNodeSrc = null;
                fXmlNodeTgt = null;
                colPositionKey = null;
                colPositionData = null;
                varNameCount = null;
                fixNameCount = null;

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static FXmlNode generateDataSetLogBySecsMessageLog(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeDts
            )
        {
            Dictionary<string, int[]> gSitlPositionKey = null;              // Secs Item Log Name, Position
            Dictionary<string, FXmlNodeList> gSitlPositionData = null;      // Secs Item Log Name, Secs Item Log Node List 
            FXmlNode fXmlNodeDtsl = null;

            try
            {
                gSitlPositionKey = new Dictionary<string, int[]>();
                gSitlPositionData = new Dictionary<string, FXmlNodeList>();

                // --

                fXmlNodeDtsl = fXmlNodeDts.clone(false);
                // --
                generateDataLogBySecsItemLog(
                    fScenarioData,
                    fXmlNodeDtsl,
                    fXmlNodeDts.selectNodes(FXmlTagDAT.E_Data),
                    gSitlPositionKey,
                    gSitlPositionData,
                    null
                    );

                // --
                // Add by Jeff.Kim 2018.01.23
                // Data Merge Flag 가 True인 Data 들의 값을 Merge Flag가 설정된 첫번째 Data 값으로 병합하여 설정 해준다. 
                // --
                mergeDataLog(
                    fXmlNodeDtsl,
                    fXmlNodeDtsl.selectNodes(FXmlTagDATL.E_Data)
                    );

                // --

                return fXmlNodeDtsl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                gSitlPositionKey = null;
                gSitlPositionData = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void mergeDataLog(
            FXmlNode fXmlNodeParent,
            FXmlNodeList fXmlNodeListDatl
            )
        {            
            // --
            FXmlNode fFirstDataNode = null;
            FFormat fFormat;
            // --
            bool mergeFlag = false;
            StringBuilder mergeData = null;
            string val = string.Empty;
            int len = 0;
            try
            {               
                // --
                mergeData = new StringBuilder();
                foreach (FXmlNode fXmlNodeDatl in fXmlNodeListDatl)
                {
                    fFormat = FEnumConverter.toFormat(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format));                    
                    // --
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                    {
                        mergeDataLog(
                            fXmlNodeDatl,
                            fXmlNodeDatl.selectNodes(FXmlTagDATL.E_Data)
                            );
                    }
                    else
                    {
                        mergeFlag = FBoolean.toBool(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Merge, FXmlTagDATL.D_Merge));
                        if (mergeFlag)
                        {
                            // --
                            if (fFirstDataNode == null)
                                fFirstDataNode = fXmlNodeDatl;

                            // ***
                            // 2017.03.23 by spike.lee
                            // fFormat를 fItemFormat으로 변경
                            // ***
                            len = int.Parse(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length));
                            val = FValueConverter.toDataConversionStringValue(
                                fFormat,
                                fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value),
                                fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                                fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression),
                                ref len
                                );
                            
                            // --
                            mergeData.Append(val);
                            // --
                        }
                    }
                }

                // --

                if (fFirstDataNode != null)
                {
                    // --
                    val = FValueConverter.fromStringValue(FFormat.Ascii, mergeData.ToString(), out len);
                    // --
                    fFirstDataNode.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                    fFirstDataNode.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                    // --
                }

                // --
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                // --
                fFirstDataNode = null;
                mergeData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        private static void generateDataLogBySecsItemLog(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeParent,
            FXmlNodeList fXmlNodeListDat,
            Dictionary<string, int[]> gSitlPositionKey,
            Dictionary<string, FXmlNodeList> gSitlPositionData,
            FXmlNode fXmlNodeParentSitl
            )
        {
            FXmlNode fXmlNodeDat = null;
            FXmlNode fXmlNodeDatl = null;
            FXmlNodeList fXmlNodeListSitl = null;
            FXmlNode fXmlNodeSitl = null;
            FXmlNode fXmlNodeSrc = null;
            FXmlNode fXmlNodeTgt = null;
            int datCount = 0;
            int index = 0;
            Dictionary<string, int[]> sitlPositionKey = null;
            Dictionary<string, FXmlNodeList> sitlPositionData = null;
            Dictionary<string, int> varNameCount = null;
            Dictionary<string, int> fixNameCount = null;
            int sitlPos = 0;
            FDataSourceType fSourceType;
            string sitlName = string.Empty;
            FFormat fFormat;
            FPattern fPattern;
            int fixedLength = 0;
            FDataScanMode fScanMode;
            int fixLen = 0;
            int varLen = 0;
            int varCnt = 0;
            int calVarCnt = 0;
            string val = string.Empty;
            int len = 0;
            string genName = string.Empty;
            FFormat fItemFormat;

            try
            {
                // ***
                // 동일한 이름의 Secs Item Log가 사용된 회수를 보관하기 위한 Storage 생성
                // ***
                sitlPositionKey = new Dictionary<string, int[]>();
                sitlPositionData = new Dictionary<string, FXmlNodeList>();
                datCount = fXmlNodeListDat.count;

                // --

                while (index < datCount)
                {
                    #region Loop

                    fXmlNodeDat = fXmlNodeListDat[index];
                    fSourceType = FEnumConverter.toDataSourceType(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_SourceType, FXmlTagDAT.D_SourceType));
                    fFormat = FEnumConverter.toFormat(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_Format, FXmlTagDAT.D_Format));

                    // --

                    // ***
                    // Source Type이 Item이 아닌 개체 처리
                    // ***
                    if (
                        fSourceType != FDataSourceType.Item &&
                        fSourceType != FDataSourceType.ItemTag1 &&
                        fSourceType != FDataSourceType.ItemTag2 &&
                        fSourceType != FDataSourceType.ItemTag3 &&
                        fSourceType != FDataSourceType.ItemTag4 &&
                        fSourceType != FDataSourceType.ItemTag5
                        )
                    {
                        fXmlNodeDatl = fXmlNodeParent.appendChild(fXmlNodeDat.clone(false));

                        // --

                        if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                        {
                            generateDataLogBySecsItemLog(
                                fScenarioData,
                                fXmlNodeDatl,
                                fXmlNodeDat.selectNodes(FXmlTagDAT.E_Data),
                                gSitlPositionKey,
                                gSitlPositionData,
                                fXmlNodeParentSitl
                                );
                        }
                        index++;
                        continue;
                    }

                    // --

                    fPattern = FEnumConverter.toPattern(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_Pattern, FXmlTagDAT.D_Pattern));
                    // --
                    if (fPattern == FPattern.Fixed)
                    {
                        #region Fixed

                        fScanMode = FEnumConverter.toDataScanMode(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_ScanMode, FXmlTagDAT.D_ScanMode));
                        sitlName = fXmlNodeDat.get_attrVal(FXmlTagDAT.A_SourceItem, FXmlTagDAT.D_SourceItem);
                        // --
                        if (fScanMode == FDataScanMode.Local)
                        {
                            #region Local

                            if (sitlPositionKey.ContainsKey(sitlName))
                            {
                                if (fSourceType == FDataSourceType.Item)
                                {
                                    sitlPos = sitlPositionKey[sitlName][0];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag1)
                                {
                                    sitlPos = sitlPositionKey[sitlName][1];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag2)
                                {
                                    sitlPos = sitlPositionKey[sitlName][2];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag3)
                                {
                                    sitlPos = sitlPositionKey[sitlName][3];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag4)
                                {
                                    sitlPos = sitlPositionKey[sitlName][4];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag5)
                                {
                                    sitlPos = sitlPositionKey[sitlName][5];
                                }
                                // --
                                fXmlNodeListSitl = sitlPositionData[sitlName];
                            }
                            else
                            {
                                sitlPos = 0;
                                fXmlNodeListSitl = collectSecsItemLogByLocalScan(fScenarioData, fXmlNodeParentSitl, sitlName);
                                // --
                                sitlPositionKey.Add(sitlName, new int[] { 0, 0, 0, 0, 0, 0 });
                                sitlPositionData.Add(sitlName, fXmlNodeListSitl);
                            }

                            #endregion
                        }
                        else
                        {
                            #region Global

                            if (gSitlPositionKey.ContainsKey(sitlName))
                            {
                                if (fSourceType == FDataSourceType.Item)
                                {
                                    sitlPos = gSitlPositionKey[sitlName][0];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag1)
                                {
                                    sitlPos = gSitlPositionKey[sitlName][1];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag2)
                                {
                                    sitlPos = gSitlPositionKey[sitlName][2];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag3)
                                {
                                    sitlPos = gSitlPositionKey[sitlName][3];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag4)
                                {
                                    sitlPos = gSitlPositionKey[sitlName][4];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag5)
                                {
                                    sitlPos = gSitlPositionKey[sitlName][5];
                                }
                                // --
                                fXmlNodeListSitl = gSitlPositionData[sitlName];
                            }
                            else
                            {
                                sitlPos = 0;
                                fXmlNodeListSitl = collectSecsItemLogByGlobalScan(fScenarioData, sitlName);
                                // --
                                gSitlPositionKey.Add(sitlName, new int[] { 0, 0, 0, 0, 0, 0 });
                                gSitlPositionData.Add(sitlName, fXmlNodeListSitl);
                            }

                            #endregion
                        }

                        // --

                        fixedLength = int.Parse(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_FixedLength, FXmlTagDAT.D_FixedLength));
                        // --
                        for (int i = 0; i < fixedLength; i++)
                        {
                            fXmlNodeDatl = fXmlNodeParent.appendChild(fXmlNodeDat.clone(false));
                            fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_FixedLength, FXmlTagDATL.D_FixedLength, "1");

                            // --

                            // ***
                            // Fixed일 경우 Secs Item Log Position이 초과할 경우 다시 순환시킨다.
                            // ***
                            if (fXmlNodeListSitl.count == 0)
                            {
                                fXmlNodeSitl = null;
                            }
                            else
                            {
                                if (sitlPos >= fXmlNodeListSitl.count)
                                {
                                    sitlPos = 0; // 순환
                                }
                                fXmlNodeSitl = fXmlNodeListSitl[sitlPos];
                                sitlPos++;

                                // --

                                // ***
                                // 2017.03.23 by spike.lee
                                // Unknown Format에 List Format이 적용될 경우 Child 처리에 Position이 저장되지 않아 무한루프 도는 문제가 발생하여
                                // Position 저장 위치를 변경 함.
                                // *** 
                                if (fScanMode == FDataScanMode.Local)
                                {
                                    #region Local

                                    if (fSourceType == FDataSourceType.Item)
                                    {
                                        sitlPositionKey[sitlName][0] = sitlPos;
                                    }
                                    else if (fSourceType == FDataSourceType.ItemTag1)
                                    {
                                        sitlPositionKey[sitlName][1] = sitlPos;
                                    }
                                    else if (fSourceType == FDataSourceType.ItemTag2)
                                    {
                                        sitlPositionKey[sitlName][2] = sitlPos;
                                    }
                                    else if (fSourceType == FDataSourceType.ItemTag3)
                                    {
                                        sitlPositionKey[sitlName][3] = sitlPos;
                                    }
                                    else if (fSourceType == FDataSourceType.ItemTag4)
                                    {
                                        sitlPositionKey[sitlName][4] = sitlPos;
                                    }
                                    else if (fSourceType == FDataSourceType.ItemTag5)
                                    {
                                        sitlPositionKey[sitlName][5] = sitlPos;
                                    }

                                    #endregion
                                }
                                else
                                {
                                    #region Global

                                    if (fSourceType == FDataSourceType.Item)
                                    {
                                        gSitlPositionKey[sitlName][0] = sitlPos;
                                    }
                                    else if (fSourceType == FDataSourceType.ItemTag1)
                                    {
                                        gSitlPositionKey[sitlName][1] = sitlPos;
                                    }
                                    else if (fSourceType == FDataSourceType.ItemTag2)
                                    {
                                        gSitlPositionKey[sitlName][2] = sitlPos;
                                    }
                                    else if (fSourceType == FDataSourceType.ItemTag3)
                                    {
                                        gSitlPositionKey[sitlName][3] = sitlPos;
                                    }
                                    else if (fSourceType == FDataSourceType.ItemTag4)
                                    {
                                        gSitlPositionKey[sitlName][4] = sitlPos;
                                    }
                                    else if (fSourceType == FDataSourceType.ItemTag5)
                                    {
                                        gSitlPositionKey[sitlName][5] = sitlPos;
                                    }

                                    #endregion
                                }
                            }

                            // --

                            if (fXmlNodeSitl == null)
                            {
                                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                                {
                                    generateDataLogBySecsItemLog(
                                        fScenarioData,
                                        fXmlNodeDatl,
                                        fXmlNodeDat.selectNodes(FXmlTagDAT.E_Data),
                                        gSitlPositionKey,
                                        gSitlPositionData,
                                        fXmlNodeParentSitl
                                        );
                                }
                            }
                            else
                            {
                                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                                {
                                    generateDataLogBySecsItemLog(
                                        fScenarioData,
                                        fXmlNodeDatl,
                                        fXmlNodeDat.selectNodes(FXmlTagDAT.E_Data),
                                        gSitlPositionKey,
                                        gSitlPositionData,
                                        fXmlNodeSitl
                                        );
                                }
                                else if (fFormat == FFormat.Unknown)
                                {
                                    // ***
                                    // Unknown Data Log 복제
                                    // ***
                                    fXmlNodeSrc = fXmlNodeDat.clone(false);

                                    // --

                                    if (
                                        fSourceType == FDataSourceType.ItemTag1 ||
                                        fSourceType == FDataSourceType.ItemTag2 ||
                                        fSourceType == FDataSourceType.ItemTag3 ||
                                        fSourceType == FDataSourceType.ItemTag4 ||
                                        fSourceType == FDataSourceType.ItemTag5
                                        )
                                    {
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // fFormat를 fItemFormat으로 변경
                                        // ***
                                        fItemFormat = FFormat.Ascii;
                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format, FEnumConverter.fromFormat(fItemFormat));

                                        // --

                                        val = getSecsItemLogValueBySourceType(fSourceType, fXmlNodeSitl);
                                        len = 0;
                                        // --
                                        val = FValueConverter.fromStringValue(FFormat.Ascii, val, out len);

                                        // --

                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                    }
                                    else
                                    {
                                        // ***
                                        // Data Log의 Format를 Secs Item Log Format으로 설정
                                        // ***
                                        // --
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // fFormat를 fItemFormat으로 변경
                                        // ***
                                        fItemFormat = FEnumConverter.toFormat(fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Format, FXmlTagSITL.D_Format));
                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format, FEnumConverter.fromFormat(fItemFormat));

                                        // --

                                        if (fItemFormat == FFormat.List || fItemFormat == FFormat.AsciiList)
                                        {
                                            // ***
                                            // 2017.03.23 by spike.lee
                                            // fXmlNodeTgt를 fXmlNodeDatl에 Append하고 generteDataLogBySecsItemLog에서 또 Append하여 Item이 2배 생성되는 문제 발생
                                            // Unknown Foramt Data인 경우 하위 Child Data에 _(Depth)를 붙여 이름을 Generate
                                            // ***
                                            len = 0;
                                            // genName = fXmlNodeSrc.get_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name) + "_";
                                            genName = fXmlNodeSrc.get_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name) + "_n";
                                            foreach (FXmlNode x in fXmlNodeSitl.selectNodes(FXmlTagSITL.E_SecsItem))
                                            {
                                                fXmlNodeTgt = fXmlNodeSrc.clone(false);
                                                // fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name, genName + (len + 1).ToString());
                                                fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name, genName);
                                                fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_FixedLength, FXmlTagDATL.D_FixedLength, "1");
                                                fXmlNodeTgt.set_attrVal(
                                                    FXmlTagDATL.A_SourceItem,
                                                    FXmlTagDATL.D_SourceItem,
                                                    x.get_attrVal(FXmlTagSITL.A_Name, FXmlTagSITL.D_Name)
                                                    );
                                                // ***
                                                // fXmlNodeTgt = fXmlNodeDatl.appendChild(fXmlNodeTgt);
                                                // ***
                                                // --
                                                generateDataLogBySecsItemLog(
                                                    fScenarioData,
                                                    fXmlNodeDatl,
                                                    fXmlNodeTgt.selectNodes("."),
                                                    gSitlPositionKey,
                                                    gSitlPositionData,
                                                    x
                                                    );
                                                // --
                                                len++;
                                            }
                                            // --
                                            fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                        }
                                        else if (fItemFormat == FFormat.Raw)
                                        {
                                            fXmlNodeDatl.set_attrVal(
                                                FXmlTagDATL.A_Length,
                                                FXmlTagDATL.D_Length,
                                                fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Length, FXmlTagSITL.D_Length)
                                                );
                                        }
                                        else if (fItemFormat != FFormat.Unknown)
                                        {
                                            // ***
                                            // 2017.03.23 by spike.lee
                                            // fFormat를 fItemFormat으로 변경
                                            // ***
                                            len = int.Parse(fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Length, FXmlTagSITL.D_Length));
                                            val = FValueConverter.toDataConversionStringValue(
                                                fItemFormat,
                                                fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Value, FXmlTagSITL.D_Value),
                                                fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Transformer, FXmlTagSITL.D_Transformer),
                                                fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_DataConversionSetExpression, FXmlTagSITL.D_DataConversionSetExpression),
                                                ref len
                                                );
                                            // --
                                            fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                                            fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                        }
                                    }
                                }
                                else if (fFormat == FFormat.Raw)
                                {
                                    if (
                                        fSourceType == FDataSourceType.ItemTag1 ||
                                        fSourceType == FDataSourceType.ItemTag2 ||
                                        fSourceType == FDataSourceType.ItemTag3 ||
                                        fSourceType == FDataSourceType.ItemTag4 ||
                                        fSourceType == FDataSourceType.ItemTag5
                                        )
                                    {
                                        val = getSecsItemLogValueBySourceType(fSourceType, fXmlNodeSitl);
                                        len = 0;
                                        // --
                                        val = FValueConverter.fromStringValue(FFormat.Ascii, val, out len);
                                    }
                                    else
                                    {
                                        len = calculateSecsItemLogRawBytes(fXmlNodeSitl);
                                    }
                                    // --
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                }
                                else
                                {
                                    if (
                                        fSourceType == FDataSourceType.ItemTag1 ||
                                        fSourceType == FDataSourceType.ItemTag2 ||
                                        fSourceType == FDataSourceType.ItemTag3 ||
                                        fSourceType == FDataSourceType.ItemTag4 ||
                                        fSourceType == FDataSourceType.ItemTag5
                                        )
                                    {
                                        val = getSecsItemLogValueBySourceType(fSourceType, fXmlNodeSitl);
                                    }
                                    else
                                    {
                                        val = FValueConverter.toDataConversionStringValue(
                                            FEnumConverter.toFormat(fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Format, FXmlTagSITL.D_Format)),
                                            fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Value, FXmlTagSITL.D_Value),
                                            fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Transformer, FXmlTagSITL.D_Transformer),
                                            fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_DataConversionSetExpression, FXmlTagSITL.D_DataConversionSetExpression)
                                            );
                                    }
                                    // --
                                    len = 0;
                                    val = FValueConverter.convertStringValue(fFormat, val, out len);
                                    // --
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                }
                            }

                        }   // fixed length for end

                        // --

                        // ***
                        // Parent가 Data일 경우 Length 설정
                        // ***
                        if (fixedLength > 1 || fXmlNodeParent.name == FXmlTagDATL.E_Data)
                        {
                            len = int.Parse(fXmlNodeParent.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length)) + fixedLength - 1;
                            fXmlNodeParent.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                        }

                        // --
                        
                        index++;

                        #endregion
                    }
                    else   // Variable
                    {
                        #region Variable

                        fixLen = 0;
                        varLen = 0;
                        varCnt = 0;
                        calVarCnt = 0;
                        // --
                        varNameCount = new Dictionary<string, int>();
                        fixNameCount = new Dictionary<string, int>();

                        // --

                        for (int i = index; i < datCount; i++)
                        {
                            fXmlNodeSrc = fXmlNodeListDat[i];
                            // --
                            fSourceType = FEnumConverter.toDataSourceType(fXmlNodeSrc.get_attrVal(FXmlTagDAT.A_SourceType, FXmlTagDAT.D_SourceType));
                            if (
                                fSourceType != FDataSourceType.Item &&
                                fSourceType != FDataSourceType.ItemTag1 &&
                                fSourceType != FDataSourceType.ItemTag2 &&
                                fSourceType != FDataSourceType.ItemTag3 &&
                                fSourceType != FDataSourceType.ItemTag4 &&
                                fSourceType != FDataSourceType.ItemTag5
                                )
                            {
                                continue;
                            }

                            // --

                            // ***
                            // 1. Previous Data Log는 Fixed 형식으로 처리
                            // 2. Variable Data Log는 연속적으로 정의되어 있어 우선 처리
                            // 3. Next Data Log는 Variable Data Log 처리 이후 Fixed 형식으로 처리
                            // ***
                            fPattern = FEnumConverter.toPattern(fXmlNodeSrc.get_attrVal(FXmlTagDAT.A_Pattern, FXmlTagDAT.D_Pattern));
                            sitlName = fXmlNodeSrc.get_attrVal(FXmlTagDAT.A_SourceItem, FXmlTagDAT.D_SourceItem);
                            // --
                            if (fPattern == FPattern.Variable)
                            {
                                if (varNameCount.ContainsKey(sitlName))
                                {
                                    varNameCount[sitlName] = varNameCount[sitlName] + 1;
                                }
                                else
                                {
                                    varNameCount.Add(sitlName, 1);
                                    fixNameCount.Add(sitlName, 0);
                                }
                                varLen++;

                                // --

                                if (!sitlPositionKey.ContainsKey(sitlName))
                                {
                                    sitlPositionKey.Add(sitlName, new int[] { 0, 0, 0, 0, 0, 0 });
                                    sitlPositionData.Add(sitlName, collectSecsItemLogByVariable(fScenarioData, fXmlNodeParentSitl, sitlName));
                                }
                            }
                            else
                            {
                                // ***
                                // Scan Mode가 Global인 Fixed Data Log는 Variable 계산에 미포함
                                // ***
                                fScanMode = FEnumConverter.toDataScanMode(fXmlNodeSrc.get_attrVal(FXmlTagDAT.A_ScanMode, FXmlTagDAT.D_ScanMode));
                                if (fScanMode == FDataScanMode.Local && fixNameCount.ContainsKey(sitlName))
                                {
                                    fixLen = int.Parse(fXmlNodeSrc.get_attrVal(FXmlTagDAT.A_FixedLength, FXmlTagDAT.D_FixedLength));
                                    fixNameCount[sitlName] = fixNameCount[sitlName] + fixLen;
                                }
                            }
                        } // for

                        // --

                        // ***
                        // Variable 회수 구하기 (Minimum)                        
                        // ***
                        foreach (string s in varNameCount.Keys)
                        {
                            if (fSourceType == FDataSourceType.Item)
                            {
                                calVarCnt = sitlPositionKey[s][0];
                            }
                            else if (fSourceType == FDataSourceType.ItemTag1)
                            {
                                calVarCnt = sitlPositionKey[s][1];
                            }
                            else if (fSourceType == FDataSourceType.ItemTag2)
                            {
                                calVarCnt = sitlPositionKey[s][2];
                            }
                            else if (fSourceType == FDataSourceType.ItemTag3)
                            {
                                calVarCnt = sitlPositionKey[s][3];
                            }
                            else if (fSourceType == FDataSourceType.ItemTag4)
                            {
                                calVarCnt = sitlPositionKey[s][4];
                            }
                            else if (fSourceType == FDataSourceType.ItemTag5)
                            {
                                calVarCnt = sitlPositionKey[s][5];
                            }

                            // --

                            calVarCnt = (sitlPositionData[s].count - calVarCnt - fixNameCount[s]) / varNameCount[s];
                            if (calVarCnt < 1)
                            {
                                varCnt = 0;
                                break;
                            }
                            // --
                            if (varCnt == 0)
                            {
                                varCnt = calVarCnt;
                            }
                            else if (varCnt > calVarCnt)
                            {
                                varCnt = calVarCnt;
                            }
                        }

                        // --

                        for (int i = 0; i < varCnt; i++)
                        {
                            for (int j = 0; j < varLen; j++)
                            {
                                fXmlNodeDat = fXmlNodeListDat[index + j];
                                fFormat = FEnumConverter.toFormat(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_Format, FXmlTagDAT.D_Format));
                                // --
                                sitlName = fXmlNodeDat.get_attrVal(FXmlTagDATL.A_SourceItem, FXmlTagDATL.D_SourceItem);
                                // --
                                if (fSourceType == FDataSourceType.Item)
                                {
                                    sitlPos = sitlPositionKey[sitlName][0];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag1)
                                {
                                    sitlPos = sitlPositionKey[sitlName][1];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag2)
                                {
                                    sitlPos = sitlPositionKey[sitlName][2];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag3)
                                {
                                    sitlPos = sitlPositionKey[sitlName][3];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag4)
                                {
                                    sitlPos = sitlPositionKey[sitlName][4];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag5)
                                {
                                    sitlPos = sitlPositionKey[sitlName][5];
                                }
                                // --
                                fXmlNodeSitl = sitlPositionData[sitlName][sitlPos];
                                sitlPos++;

                                // --

                                // ***
                                // 2017.03.23 by spike.lee
                                // Unknown Format에 List Format이 적용될 경우 Child 처리에 Position이 저장되지 않아 무한루프 도는 문제가 발생하여
                                // Position 저장 위치를 변경 함.
                                // *** 
                                if (fSourceType == FDataSourceType.Item)
                                {
                                    sitlPositionKey[sitlName][0] = sitlPos;
                                }
                                else if (fSourceType == FDataSourceType.ItemTag1)
                                {
                                    sitlPositionKey[sitlName][1] = sitlPos;
                                }
                                else if (fSourceType == FDataSourceType.ItemTag2)
                                {
                                    sitlPositionKey[sitlName][2] = sitlPos;
                                }
                                else if (fSourceType == FDataSourceType.ItemTag3)
                                {
                                    sitlPositionKey[sitlName][3] = sitlPos;
                                }
                                else if (fSourceType == FDataSourceType.ItemTag4)
                                {
                                    sitlPositionKey[sitlName][4] = sitlPos;
                                }
                                else if (fSourceType == FDataSourceType.ItemTag5)
                                {
                                    sitlPositionKey[sitlName][5] = sitlPos;
                                }

                                // --

                                fXmlNodeDatl = fXmlNodeParent.appendChild(fXmlNodeDat.clone(false));
                                fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Pattern, FXmlTagDATL.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));

                                // --

                                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                                {
                                    generateDataLogBySecsItemLog(
                                        fScenarioData,
                                        fXmlNodeDatl,
                                        fXmlNodeDat.selectNodes(FXmlTagDAT.E_Data),
                                        gSitlPositionKey,
                                        gSitlPositionData,
                                        fXmlNodeSitl
                                        );
                                }
                                else if (fFormat == FFormat.Unknown)
                                {
                                    // ***
                                    // Unknown Data Log 복제
                                    // ***
                                    fXmlNodeSrc = fXmlNodeDat.clone(false);

                                    // --

                                    if (
                                        fSourceType == FDataSourceType.ItemTag1 ||
                                        fSourceType == FDataSourceType.ItemTag2 ||
                                        fSourceType == FDataSourceType.ItemTag3 ||
                                        fSourceType == FDataSourceType.ItemTag4 ||
                                        fSourceType == FDataSourceType.ItemTag5
                                        )
                                    {
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // fFormat를 fItemFormat으로 변경
                                        // ***
                                        fItemFormat = FFormat.Ascii;
                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format, FEnumConverter.fromFormat(fItemFormat));

                                        // --

                                        val = getSecsItemLogValueBySourceType(fSourceType, fXmlNodeSitl);
                                        len = 0;
                                        // --
                                        val = FValueConverter.fromStringValue(FFormat.Ascii, val, out len);

                                        // --

                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                    }
                                    else
                                    {
                                        // ***
                                        // Data Log의 Format를 Secs Item Log Format으로 설정
                                        // ***
                                        // --
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // fFormat를 fItemFormat으로 변경
                                        // ***
                                        fItemFormat = FEnumConverter.toFormat(fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Format, FXmlTagSITL.D_Format));
                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format, FEnumConverter.fromFormat(fItemFormat));

                                        // --

                                        if (fItemFormat == FFormat.List || fItemFormat == FFormat.AsciiList)
                                        {
                                            // ***
                                            // 2017.03.23 by spike.lee
                                            // Unknown Foramt Data인 경우 하위 Child Data에 _(Depth)를 붙여 이름을 Generate
                                            // 추가되는 fXmlNodeTgt Variable 속성을 Fixed로 변경
                                            // ***
                                            len = 0;
                                            // genName = fXmlNodeSrc.get_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name) + "_";
                                            genName = fXmlNodeSrc.get_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name) + "_n";
                                            foreach (FXmlNode x in fXmlNodeSitl.selectNodes(FXmlTagSITL.E_SecsItem))
                                            {
                                                fXmlNodeTgt = fXmlNodeSrc.clone(false);
                                                // fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name, genName + (len + 1).ToString());
                                                fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name, genName);
                                                fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_Pattern, FXmlTagDATL.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                                                fXmlNodeTgt.set_attrVal(
                                                    FXmlTagDATL.A_SourceItem,
                                                    FXmlTagDATL.D_SourceItem,
                                                    x.get_attrVal(FXmlTagSITL.A_Name, FXmlTagSITL.D_Name)
                                                    );
                                                // *** 
                                                // fXmlNodeTgt = fXmlNodeDatl.appendChild(fXmlNodeTgt);
                                                // ***
                                                // --
                                                generateDataLogBySecsItemLog(
                                                    fScenarioData,
                                                    fXmlNodeDatl,
                                                    fXmlNodeTgt.selectNodes("."),
                                                    gSitlPositionKey,
                                                    gSitlPositionData,
                                                    x
                                                    );
                                                // --
                                                len++;
                                            }
                                            // --
                                            fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                        }
                                        else if (fItemFormat == FFormat.Raw)
                                        {
                                            fXmlNodeDatl.set_attrVal(
                                                FXmlTagDATL.A_Length,
                                                FXmlTagDATL.D_Length,
                                                fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Length, FXmlTagSITL.D_Length)
                                                );
                                        }
                                        else if (fItemFormat != FFormat.Unknown)
                                        {
                                            // ***
                                            // 2017.03.23 by spike.lee
                                            // fFormat를 fItemFormat으로 변경
                                            // ***
                                            len = int.Parse(fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Length, FXmlTagSITL.D_Length));
                                            val = FValueConverter.toDataConversionStringValue(
                                                fItemFormat,
                                                fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Value, FXmlTagSITL.D_Value),
                                                fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Transformer, FXmlTagSITL.D_Transformer),
                                                fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_DataConversionSetExpression, FXmlTagSITL.D_DataConversionSetExpression),
                                                ref len
                                                );
                                            // --
                                            fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                                            fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                        }
                                    }
                                }
                                else if (fFormat == FFormat.Raw)
                                {
                                    if (
                                        fSourceType == FDataSourceType.ItemTag1 ||
                                        fSourceType == FDataSourceType.ItemTag2 ||
                                        fSourceType == FDataSourceType.ItemTag3 ||
                                        fSourceType == FDataSourceType.ItemTag4 ||
                                        fSourceType == FDataSourceType.ItemTag5
                                        )
                                    {
                                        val = getSecsItemLogValueBySourceType(fSourceType, fXmlNodeSitl);
                                        len = 0;
                                        // --
                                        val = FValueConverter.fromStringValue(FFormat.Ascii, val, out len);
                                    }
                                    else
                                    {
                                        len = calculateSecsItemLogRawBytes(fXmlNodeSitl);
                                    }
                                    // --
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                }
                                else
                                {
                                    if (
                                        fSourceType == FDataSourceType.ItemTag1 ||
                                        fSourceType == FDataSourceType.ItemTag2 ||
                                        fSourceType == FDataSourceType.ItemTag3 ||
                                        fSourceType == FDataSourceType.ItemTag4 ||
                                        fSourceType == FDataSourceType.ItemTag5
                                        )
                                    {
                                        val = getSecsItemLogValueBySourceType(fSourceType, fXmlNodeSitl);
                                    }
                                    else
                                    {
                                        val = FValueConverter.toDataConversionStringValue(
                                            FEnumConverter.toFormat(fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Format, FXmlTagSITL.D_Format)),
                                            fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Value, FXmlTagSITL.D_Value),
                                            fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Transformer, FXmlTagSITL.D_Transformer),
                                            fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_DataConversionSetExpression, FXmlTagSITL.D_DataConversionSetExpression)
                                            );
                                    }
                                    // --
                                    len = 0;
                                    val = FValueConverter.convertStringValue(fFormat, val, out len);
                                    // --
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                }
                            }   // for end
                        }   // for end

                        // --

                        // ***
                        // Parent가 Data Log일 경우 추가된 Variable Data Log 만큼 Length 증가
                        // ***
                        if (fXmlNodeParent.name == FXmlTagDATL.E_Data)
                        {
                            len = int.Parse(fXmlNodeParent.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length)) + ((varCnt - 1) * varLen);
                            fXmlNodeParent.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                        }

                        // --

                        index += varLen;

                        #endregion
                    }

                    #endregion
                }   // while end
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeDat = null;
                fXmlNodeDatl = null;
                fXmlNodeListSitl = null;
                fXmlNodeSitl = null;
                fXmlNodeSrc = null;
                fXmlNodeTgt = null;
                sitlPositionKey = null;
                sitlPositionData = null;
                varNameCount = null;
                fixNameCount = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static FXmlNode generateDataSetLogByHostMessageLog(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeDts
            )
        {
            Dictionary<string, int[]> gHitlPositionKey = null;              // Host Item Log Name, Position
            Dictionary<string, FXmlNodeList> gHitlPositionData = null;      // Host Item Log Name, Secs Item Log Node List 
            FXmlNode fXmlNodeDtsl = null;

            try
            {
                gHitlPositionKey = new Dictionary<string, int[]>();
                gHitlPositionData = new Dictionary<string, FXmlNodeList>();

                // --

                fXmlNodeDtsl = fXmlNodeDts.clone(false);
                // --
                generateDataLogByHostItemLog(
                    fScenarioData,
                    fXmlNodeDtsl,
                    fXmlNodeDts.selectNodes(FXmlTagDAT.E_Data),
                    gHitlPositionKey,
                    gHitlPositionData,
                    null
                    );

                // --
                // Add by Jeff.Kim 2018.01.23
                // Data Merge Flag 가 True인 Data 들의 값을 Merge Flag가 설정된 첫번째 Data 값으로 병합하여 설정 해준다. 
                // --
                mergeDataLog(
                    fXmlNodeDtsl,
                    fXmlNodeDtsl.selectNodes(FXmlTagDATL.E_Data)
                    );

                // --

                return fXmlNodeDtsl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                gHitlPositionKey = null;
                gHitlPositionKey = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void generateDataLogByHostItemLog(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeParent,
            FXmlNodeList fXmlNodeListDat,
            Dictionary<string, int[]> gHitlPositionKey,
            Dictionary<string, FXmlNodeList> gHitlPositionData,
            FXmlNode fXmlNodeParentHitl
            )
        {
            FXmlNode fXmlNodeDat = null;
            FXmlNode fXmlNodeDatl = null;
            FXmlNodeList fXmlNodeListHitl = null;
            FXmlNode fXmlNodeHitl = null;
            FXmlNode fXmlNodeSrc = null;
            FXmlNode fXmlNodeTgt = null;
            int datCount = 0;
            int index = 0;
            Dictionary<string, int[]> hitlPositionKey = null;
            Dictionary<string, FXmlNodeList> hitlPositionData = null;
            Dictionary<string, int> varNameCount = null;
            Dictionary<string, int> fixNameCount = null;
            int hitlPos = 0;
            FDataSourceType fSourceType;
            string hitlName = string.Empty;
            FFormat fFormat;
            FPattern fPattern;
            int fixedLength = 0;
            FDataScanMode fScanMode;
            int fixLen = 0;
            int varLen = 0;
            int varCnt = 0;
            int calVarCnt = 0;
            string val = string.Empty;
            int len = 0;
            string genName = string.Empty;
            FFormat fItemFormat;

            try
            {
                // ***
                // 동일한 이름의 Host Item Log가 사용된 회수를 보관하기 위한 Storage 생성
                // ***
                hitlPositionKey = new Dictionary<string, int[]>();
                hitlPositionData = new Dictionary<string, FXmlNodeList>();
                datCount = fXmlNodeListDat.count;

                // --

                while (index < datCount)
                {
                    fXmlNodeDat = fXmlNodeListDat[index];
                    fSourceType = FEnumConverter.toDataSourceType(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_SourceType, FXmlTagDAT.D_SourceType));
                    fFormat = FEnumConverter.toFormat(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_Format, FXmlTagDAT.D_Format));

                    // --

                    // ***
                    // Source Type이 Item이 아닌 개체 처리
                    // ***
                    if (
                        fSourceType != FDataSourceType.Item &&
                        fSourceType != FDataSourceType.ItemTag1 &&
                        fSourceType != FDataSourceType.ItemTag2 &&
                        fSourceType != FDataSourceType.ItemTag3 &&
                        fSourceType != FDataSourceType.ItemTag4 &&
                        fSourceType != FDataSourceType.ItemTag5
                        )
                    {
                        fXmlNodeDatl = fXmlNodeParent.appendChild(fXmlNodeDat.clone(false));

                        // --

                        if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                        {
                            generateDataLogByHostItemLog(
                                fScenarioData,
                                fXmlNodeDatl,
                                fXmlNodeDat.selectNodes(FXmlTagDAT.E_Data),
                                gHitlPositionKey,
                                gHitlPositionData,
                                fXmlNodeParentHitl
                                );
                        }
                        index++;
                        continue;
                    }

                    // --

                    fPattern = FEnumConverter.toPattern(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_Pattern, FXmlTagDAT.D_Pattern));
                    // --
                    if (fPattern == FPattern.Fixed)
                    {
                        #region Fixed

                        fScanMode = FEnumConverter.toDataScanMode(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_ScanMode, FXmlTagDAT.D_ScanMode));
                        hitlName = fXmlNodeDat.get_attrVal(FXmlTagDAT.A_SourceItem, FXmlTagDAT.D_SourceItem);
                        // --
                        if (fScanMode == FDataScanMode.Local)
                        {
                            if (hitlPositionKey.ContainsKey(hitlName))
                            {
                                if (fSourceType == FDataSourceType.Item)
                                {
                                    hitlPos = hitlPositionKey[hitlName][0];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag1)
                                {
                                    hitlPos = hitlPositionKey[hitlName][1];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag2)
                                {
                                    hitlPos = hitlPositionKey[hitlName][2];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag3)
                                {
                                    hitlPos = hitlPositionKey[hitlName][3];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag4)
                                {
                                    hitlPos = hitlPositionKey[hitlName][4];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag5)
                                {
                                    hitlPos = hitlPositionKey[hitlName][5];
                                }
                                // --
                                fXmlNodeListHitl = hitlPositionData[hitlName];
                            }
                            else
                            {
                                hitlPos = 0;
                                fXmlNodeListHitl = collectHostItemLogByLocalScan(fScenarioData, fXmlNodeParentHitl, hitlName);
                                // --
                                hitlPositionKey.Add(hitlName, new int[] { 0, 0, 0, 0, 0, 0 });
                                hitlPositionData.Add(hitlName, fXmlNodeListHitl);
                            }
                        }
                        else
                        {
                            if (gHitlPositionKey.ContainsKey(hitlName))
                            {
                                if (fSourceType == FDataSourceType.Item)
                                {
                                    hitlPos = gHitlPositionKey[hitlName][0];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag1)
                                {
                                    hitlPos = gHitlPositionKey[hitlName][1];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag2)
                                {
                                    hitlPos = gHitlPositionKey[hitlName][2];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag3)
                                {
                                    hitlPos = gHitlPositionKey[hitlName][3];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag4)
                                {
                                    hitlPos = gHitlPositionKey[hitlName][4];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag5)
                                {
                                    hitlPos = gHitlPositionKey[hitlName][5];
                                }
                                // --
                                fXmlNodeListHitl = gHitlPositionData[hitlName];
                            }
                            else
                            {
                                hitlPos = 0;
                                fXmlNodeListHitl = collectHostItemLogByGlobalScan(fScenarioData, hitlName);
                                // --
                                gHitlPositionKey.Add(hitlName, new int[] { 0, 0, 0, 0, 0, 0 });
                                gHitlPositionData.Add(hitlName, fXmlNodeListHitl);
                            }
                        }

                        // --

                        fixedLength = int.Parse(fXmlNodeDat.get_attrVal(FXmlTagDATL.A_FixedLength, FXmlTagDATL.D_FixedLength));
                        // --
                        for (int i = 0; i < fixedLength; i++)
                        {
                            fXmlNodeDatl = fXmlNodeParent.appendChild(fXmlNodeDat.clone(false));
                            fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_FixedLength, FXmlTagDATL.D_FixedLength, "1");

                            // --

                            // ***
                            // Fixed일 경우 Host Item Log Position이 초과할 경우 다시 순환시킨다.
                            // ***
                            if (fXmlNodeListHitl.count == 0)
                            {
                                fXmlNodeHitl = null;
                            }
                            else
                            {
                                if (hitlPos >= fXmlNodeListHitl.count)
                                {
                                    hitlPos = 0; // 순환
                                }
                                fXmlNodeHitl = fXmlNodeListHitl[hitlPos];
                                hitlPos++;

                                // --

                                // ***
                                // 2017.03.23 by spike.lee
                                // Unknown Format에 List Format이 적용될 경우 Child 처리에 Position이 저장되지 않아 무한루프 도는 문제가 발생하여
                                // Position 저장 위치를 변경 함.
                                // *** 
                                if (fScanMode == FDataScanMode.Local)
                                {
                                    if (fSourceType == FDataSourceType.Item)
                                    {
                                        hitlPositionKey[hitlName][0] = hitlPos;
                                    }
                                    else if (fSourceType == FDataSourceType.ItemTag1)
                                    {
                                        hitlPositionKey[hitlName][1] = hitlPos;
                                    }
                                    else if (fSourceType == FDataSourceType.ItemTag2)
                                    {
                                        hitlPositionKey[hitlName][2] = hitlPos;
                                    }
                                    else if (fSourceType == FDataSourceType.ItemTag3)
                                    {
                                        hitlPositionKey[hitlName][3] = hitlPos;
                                    }
                                    else if (fSourceType == FDataSourceType.ItemTag4)
                                    {
                                        hitlPositionKey[hitlName][4] = hitlPos;
                                    }
                                    else if (fSourceType == FDataSourceType.ItemTag5)
                                    {
                                        hitlPositionKey[hitlName][5] = hitlPos;
                                    }
                                }
                                else
                                {
                                    if (fSourceType == FDataSourceType.Item)
                                    {
                                        gHitlPositionKey[hitlName][0] = hitlPos;
                                    }
                                    else if (fSourceType == FDataSourceType.ItemTag1)
                                    {
                                        gHitlPositionKey[hitlName][1] = hitlPos;
                                    }
                                    else if (fSourceType == FDataSourceType.ItemTag2)
                                    {
                                        gHitlPositionKey[hitlName][2] = hitlPos;
                                    }
                                    else if (fSourceType == FDataSourceType.ItemTag3)
                                    {
                                        gHitlPositionKey[hitlName][3] = hitlPos;
                                    }
                                    else if (fSourceType == FDataSourceType.ItemTag4)
                                    {
                                        gHitlPositionKey[hitlName][4] = hitlPos;
                                    }
                                    else if (fSourceType == FDataSourceType.ItemTag5)
                                    {
                                        gHitlPositionKey[hitlName][5] = hitlPos;
                                    }
                                }
                            }

                            // --

                            if (fXmlNodeHitl == null)
                            {
                                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                                {
                                    generateDataLogByHostItemLog(
                                        fScenarioData,
                                        fXmlNodeDatl,
                                        fXmlNodeDat.selectNodes(FXmlTagDAT.E_Data),
                                        gHitlPositionKey,
                                        gHitlPositionData,
                                        fXmlNodeParentHitl
                                        );
                                }
                            }
                            else
                            {
                                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                                {
                                    generateDataLogByHostItemLog(
                                        fScenarioData,
                                        fXmlNodeDatl,
                                        fXmlNodeDat.selectNodes(FXmlTagDAT.E_Data),
                                        gHitlPositionKey,
                                        gHitlPositionData,
                                        fXmlNodeHitl
                                        );
                                }
                                else if (fFormat == FFormat.Unknown)
                                {
                                    // ***
                                    // Unknown Data Log 복제
                                    // ***
                                    fXmlNodeSrc = fXmlNodeDat.clone(false);

                                    // --

                                    if (
                                        fSourceType == FDataSourceType.ItemTag1 ||
                                        fSourceType == FDataSourceType.ItemTag2 ||
                                        fSourceType == FDataSourceType.ItemTag3 ||
                                        fSourceType == FDataSourceType.ItemTag4 ||
                                        fSourceType == FDataSourceType.ItemTag5
                                        )
                                    {
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // fFormat를 fItemFormat으로 변경
                                        // ***
                                        fItemFormat = FFormat.Ascii;
                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format, FEnumConverter.fromFormat(fItemFormat));

                                        // --

                                        val = getHostItemLogValueBySourceType(fSourceType, fXmlNodeHitl);
                                        len = 0;
                                        // --
                                        val = FValueConverter.fromStringValue(FFormat.Ascii, val, out len);

                                        // --

                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                    }
                                    else
                                    {
                                        // ***
                                        // Data Log의 Format를 Host Item Log Format으로 설정
                                        // ***
                                        // --
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // fFormat를 fItemFormat으로 변경
                                        // ***
                                        fItemFormat = FEnumConverter.toFormat(fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Format, FXmlTagHITL.D_Format));
                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format, FEnumConverter.fromFormat(fItemFormat));

                                        // --

                                        if (fItemFormat == FFormat.List || fItemFormat == FFormat.AsciiList)
                                        {
                                            // ***
                                            // 2017.03.23 by spike.lee
                                            // fXmlNodeTgt를 fXmlNodeDatl에 Append하고 generteDataLogByHostItemLog에서 또 Append하여 Item이 2배 생성되는 문제 발생
                                            // Unknown Foramt Data인 경우 하위 Child Data에 _(Depth)를 붙여 이름을 Generate
                                            // ***
                                            len = 0;
                                            // genName = fXmlNodeSrc.get_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name) + "_";
                                            genName = fXmlNodeSrc.get_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name) + "_n";
                                            foreach (FXmlNode x in fXmlNodeHitl.selectNodes(FXmlTagHITL.E_HostItem))
                                            {
                                                fXmlNodeTgt = fXmlNodeSrc.clone(false);
                                                // fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name, genName + (len + 1).ToString());
                                                fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name, genName);
                                                fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_FixedLength, FXmlTagDATL.D_FixedLength, "1");
                                                fXmlNodeTgt.set_attrVal(
                                                    FXmlTagDATL.A_SourceItem,
                                                    FXmlTagDATL.D_SourceItem,
                                                    x.get_attrVal(FXmlTagHITL.A_Name, FXmlTagHITL.D_Name)
                                                    );
                                                // ***
                                                // fXmlNodeTgt = fXmlNodeDatl.appendChild(fXmlNodeTgt);
                                                // ***
                                                // --
                                                generateDataLogByHostItemLog(
                                                    fScenarioData,
                                                    fXmlNodeDatl,
                                                    fXmlNodeTgt.selectNodes("."),
                                                    gHitlPositionKey,
                                                    gHitlPositionData,
                                                    x
                                                    );
                                                // --
                                                len++;
                                            }
                                            // --
                                            fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                        }
                                        else if (fItemFormat == FFormat.Raw)
                                        {
                                            fXmlNodeDatl.set_attrVal(
                                                FXmlTagDATL.A_Length,
                                                FXmlTagDATL.D_Length,
                                                fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Length, FXmlTagHITL.D_Length)
                                                );
                                        }
                                        else if (fItemFormat != FFormat.Unknown)
                                        {
                                            // ***
                                            // 2017.03.23 by spike.lee
                                            // fFormat를 fItemFormat으로 변경
                                            // ***
                                            len = int.Parse(fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Length, FXmlTagHITL.D_Length));
                                            val = FValueConverter.toDataConversionStringValue(
                                                fItemFormat,
                                                fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Value, FXmlTagHITL.D_Value),
                                                fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Transformer, FXmlTagHITL.D_Transformer),
                                                fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_DataConversionSetExpression, FXmlTagHITL.D_DataConversionSetExpression),
                                                ref len
                                                );
                                            // --
                                            fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                                            fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                        }
                                    }                                    
                                }
                                else if (fFormat == FFormat.Raw)
                                {
                                    if (
                                        fSourceType == FDataSourceType.ItemTag1 ||
                                        fSourceType == FDataSourceType.ItemTag2 ||
                                        fSourceType == FDataSourceType.ItemTag3 ||
                                        fSourceType == FDataSourceType.ItemTag4 ||
                                        fSourceType == FDataSourceType.ItemTag5
                                        )
                                    {
                                        val = getHostItemLogValueBySourceType(fSourceType, fXmlNodeHitl);
                                        len = 0;
                                        // --
                                        val = FValueConverter.fromStringValue(FFormat.Ascii, val, out len);
                                    }
                                    else
                                    {
                                        len = calculateHostItemLogRawBytes(fXmlNodeHitl);
                                    }
                                    // --                                    
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                }
                                else
                                {
                                    if (
                                        fSourceType == FDataSourceType.ItemTag1 ||
                                        fSourceType == FDataSourceType.ItemTag2 ||
                                        fSourceType == FDataSourceType.ItemTag3 ||
                                        fSourceType == FDataSourceType.ItemTag4 ||
                                        fSourceType == FDataSourceType.ItemTag5
                                        )
                                    {
                                        val = getHostItemLogValueBySourceType(fSourceType, fXmlNodeHitl);
                                    }
                                    else
                                    {
                                        val = FValueConverter.toDataConversionStringValue(
                                            FEnumConverter.toFormat(fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Format, FXmlTagHITL.D_Format)),
                                            fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Value, FXmlTagHITL.D_Value),
                                            fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Transformer, FXmlTagHITL.D_Transformer),
                                            fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_DataConversionSetExpression, FXmlTagHITL.D_DataConversionSetExpression)
                                            );
                                    }
                                    // --
                                    len = 0;
                                    val = FValueConverter.convertStringValue(fFormat, val, out len);
                                    // --
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                }
                            }
                        }   // fixed length for end

                        // --

                        // ***
                        // Parent가 Data일 경우 Length 설정
                        // ***
                        if (fixedLength > 1 || fXmlNodeParent.name == FXmlTagDATL.E_Data)
                        {
                            len = int.Parse(fXmlNodeParent.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length)) + fixedLength - 1;
                            fXmlNodeParent.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                        }

                        // --
                        
                        index++;

                        #endregion
                    }
                    else  // Variable
                    {
                        #region Variable

                        fixLen = 0;
                        varLen = 0;
                        varCnt = 0;
                        calVarCnt = 0;
                        // --
                        varNameCount = new Dictionary<string, int>();
                        fixNameCount = new Dictionary<string, int>();

                        // --

                        for (int i = index; i < datCount; i++)
                        {
                            fXmlNodeSrc = fXmlNodeListDat[i];
                            // --
                            fSourceType = FEnumConverter.toDataSourceType(fXmlNodeSrc.get_attrVal(FXmlTagDAT.A_SourceType, FXmlTagDAT.D_SourceType));
                            if (
                                fSourceType != FDataSourceType.Item &&
                                fSourceType != FDataSourceType.ItemTag1 &&
                                fSourceType != FDataSourceType.ItemTag2 &&
                                fSourceType != FDataSourceType.ItemTag3 &&
                                fSourceType != FDataSourceType.ItemTag4 &&
                                fSourceType != FDataSourceType.ItemTag5 
                                )
                            {
                                continue;
                            }

                            // --

                            // ***
                            // 1. Previous Data Log는 Fixed 형식으로 처리
                            // 2. Variable Data Log는 연속적으로 정의되어 있어 우선 처리
                            // 3. Next Data Log는 Variable Data Log 처리 이후 Fixed 형식으로 처리
                            // ***
                            fPattern = FEnumConverter.toPattern(fXmlNodeSrc.get_attrVal(FXmlTagDAT.A_Pattern, FXmlTagDAT.D_Pattern));
                            hitlName = fXmlNodeSrc.get_attrVal(FXmlTagDAT.A_SourceItem, FXmlTagDAT.D_SourceItem);
                            // --
                            if (fPattern == FPattern.Variable)
                            {
                                if (varNameCount.ContainsKey(hitlName))
                                {
                                    varNameCount[hitlName] = varNameCount[hitlName] + 1;
                                }
                                else
                                {
                                    varNameCount.Add(hitlName, 1);
                                    fixNameCount.Add(hitlName, 0);
                                }
                                varLen++;

                                // --

                                if (!hitlPositionKey.ContainsKey(hitlName))
                                {
                                    hitlPositionKey.Add(hitlName, new int[] { 0, 0, 0, 0, 0, 0 });
                                    hitlPositionData.Add(hitlName, collectHostItemLogByVariable(fScenarioData, fXmlNodeParentHitl, hitlName));
                                }
                            }
                            else
                            {
                                // ***
                                // Scan Mode가 Global인 Fixed Data Log는 Variable 계산에 미포함
                                // ***
                                fScanMode = FEnumConverter.toDataScanMode(fXmlNodeSrc.get_attrVal(FXmlTagDAT.A_ScanMode, FXmlTagDAT.D_ScanMode));
                                if (fScanMode == FDataScanMode.Local && fixNameCount.ContainsKey(hitlName))
                                {
                                    fixLen = int.Parse(fXmlNodeSrc.get_attrVal(FXmlTagDATL.A_FixedLength, FXmlTagDATL.D_FixedLength));
                                    fixNameCount[hitlName] = fixNameCount[hitlName] + fixLen;
                                }
                            }
                        } // for

                        // --

                        // ***
                        // Variable 회수 구하기 (Minimum)                        
                        // ***
                        foreach (string s in varNameCount.Keys)
                        {
                            if (fSourceType == FDataSourceType.Item)
                            {
                                calVarCnt = hitlPositionKey[s][0];
                            }
                            else if (fSourceType == FDataSourceType.ItemTag1)
                            {
                                calVarCnt = hitlPositionKey[s][1];
                            }
                            else if (fSourceType == FDataSourceType.ItemTag2)
                            {
                                calVarCnt = hitlPositionKey[s][2];
                            }
                            else if (fSourceType == FDataSourceType.ItemTag3)
                            {
                                calVarCnt = hitlPositionKey[s][3];
                            }
                            else if (fSourceType == FDataSourceType.ItemTag4)
                            {
                                calVarCnt = hitlPositionKey[s][4];
                            }
                            else if (fSourceType == FDataSourceType.ItemTag5)
                            {
                                calVarCnt = hitlPositionKey[s][5];
                            }

                            // --

                            calVarCnt = (hitlPositionData[s].count - calVarCnt - fixNameCount[s]) / varNameCount[s];
                            if (calVarCnt < 1)
                            {
                                varCnt = 0;
                                break;
                            }
                            // --
                            if (varCnt == 0)
                            {
                                varCnt = calVarCnt;
                            }
                            else if (varCnt > calVarCnt)
                            {
                                varCnt = calVarCnt;
                            }
                        }

                        // --

                        for (int i = 0; i < varCnt; i++)
                        {
                            for (int j = 0; j < varLen; j++)
                            {
                                fXmlNodeDat = fXmlNodeListDat[index + j];
                                fFormat = FEnumConverter.toFormat(fXmlNodeDat.get_attrVal(FXmlTagDAT.A_Format, FXmlTagDAT.D_Format));
                                // --
                                hitlName = fXmlNodeDat.get_attrVal(FXmlTagDATL.A_SourceItem, FXmlTagDATL.D_SourceItem);
                                // --
                                if (fSourceType == FDataSourceType.Item)
                                {
                                    hitlPos = hitlPositionKey[hitlName][0];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag1)
                                {
                                    hitlPos = hitlPositionKey[hitlName][1];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag2)
                                {
                                    hitlPos = hitlPositionKey[hitlName][2];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag3)
                                {
                                    hitlPos = hitlPositionKey[hitlName][3];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag4)
                                {
                                    hitlPos = hitlPositionKey[hitlName][4];
                                }
                                else if (fSourceType == FDataSourceType.ItemTag5)
                                {
                                    hitlPos = hitlPositionKey[hitlName][5];
                                }           
                                // --
                                fXmlNodeHitl = hitlPositionData[hitlName][hitlPos];
                                hitlPos++;

                                // --

                                // ***
                                // 2017.03.23 by spike.lee
                                // Unknown Format에 List Format이 적용될 경우 Child 처리에 Position이 저장되지 않아 무한루프 도는 문제가 발생하여
                                // Position 저장 위치를 변경 함.
                                // *** 
                                if (fSourceType == FDataSourceType.Item)
                                {
                                    hitlPositionKey[hitlName][0] = hitlPos;
                                }
                                else if (fSourceType == FDataSourceType.ItemTag1)
                                {
                                    hitlPositionKey[hitlName][1] = hitlPos;
                                }
                                else if (fSourceType == FDataSourceType.ItemTag2)
                                {
                                    hitlPositionKey[hitlName][2] = hitlPos;
                                }
                                else if (fSourceType == FDataSourceType.ItemTag3)
                                {
                                    hitlPositionKey[hitlName][3] = hitlPos;
                                }
                                else if (fSourceType == FDataSourceType.ItemTag4)
                                {
                                    hitlPositionKey[hitlName][4] = hitlPos;
                                }
                                else if (fSourceType == FDataSourceType.ItemTag5)
                                {
                                    hitlPositionKey[hitlName][5] = hitlPos;
                                }

                                // --

                                fXmlNodeDatl = fXmlNodeParent.appendChild(fXmlNodeDat.clone(false));
                                fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Pattern, FXmlTagDATL.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));

                                // --

                                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                                {
                                    generateDataLogByHostItemLog(
                                        fScenarioData,
                                        fXmlNodeDatl,
                                        fXmlNodeDat.selectNodes(FXmlTagDAT.E_Data),
                                        gHitlPositionKey,
                                        gHitlPositionData,
                                        fXmlNodeHitl
                                        );
                                }
                                else if (fFormat == FFormat.Unknown)
                                {
                                    // ***
                                    // Unknown Data Log 복제
                                    // ***
                                    fXmlNodeSrc = fXmlNodeDat.clone(false);

                                    // --

                                    if (
                                        fSourceType == FDataSourceType.ItemTag1 ||
                                        fSourceType == FDataSourceType.ItemTag2 ||
                                        fSourceType == FDataSourceType.ItemTag3 ||
                                        fSourceType == FDataSourceType.ItemTag4 ||
                                        fSourceType == FDataSourceType.ItemTag5
                                        )
                                    {
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // fFormat를 fItemFormat으로 변경
                                        // ***
                                        fItemFormat = FFormat.Ascii;
                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format, FEnumConverter.fromFormat(fItemFormat));

                                        // --

                                        val = getHostItemLogValueBySourceType(fSourceType, fXmlNodeHitl);
                                        len = 0;
                                        // --
                                        val = FValueConverter.fromStringValue(FFormat.Ascii, val, out len);

                                        // --

                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                    }
                                    else
                                    {
                                        // ***
                                        // Data Log의 Format를 Host Item Log Format으로 설정
                                        // ***
                                        // --
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // fFormat를 fItemFormat으로 변경
                                        // ***
                                        fItemFormat = FEnumConverter.toFormat(fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Format, FXmlTagHITL.D_Format));
                                        fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format, FEnumConverter.fromFormat(fItemFormat));

                                        // --

                                        if (fItemFormat == FFormat.List || fItemFormat == FFormat.AsciiList)
                                        {
                                            // ***
                                            // 2017.03.23 by spike.lee
                                            // Unknown Foramt Data인 경우 하위 Child Data에 _(Depth)를 붙여 이름을 Generate
                                            // 추가되는 fXmlNodeTgt Variable 속성을 Fixed로 변경
                                            // ***
                                            len = 0;
                                            // genName = fXmlNodeSrc.get_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name) + "_";
                                            genName = fXmlNodeSrc.get_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name) + "_n";
                                            foreach (FXmlNode x in fXmlNodeHitl.selectNodes(FXmlTagHITL.E_HostItem))
                                            {
                                                fXmlNodeTgt = fXmlNodeSrc.clone(false);
                                                // fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name, genName + (len + 1).ToString());
                                                fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name, genName);
                                                fXmlNodeTgt.set_attrVal(FXmlTagDATL.A_Pattern, FXmlTagDATL.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                                                fXmlNodeTgt.set_attrVal(
                                                    FXmlTagDATL.A_SourceItem,
                                                    FXmlTagDATL.D_SourceItem,
                                                    x.get_attrVal(FXmlTagHITL.A_Name, FXmlTagHITL.D_Name)
                                                    );
                                                // ***
                                                // fXmlNodeTgt = fXmlNodeDatl.appendChild(fXmlNodeTgt);
                                                // ***
                                                // --
                                                generateDataLogByHostItemLog(
                                                    fScenarioData,
                                                    fXmlNodeDatl,
                                                    fXmlNodeTgt.selectNodes("."),
                                                    gHitlPositionKey,
                                                    gHitlPositionData,
                                                    x
                                                    );
                                                // --
                                                len++;
                                            }
                                            // --
                                            fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                        }
                                        else if (fItemFormat == FFormat.Raw)
                                        {
                                            fXmlNodeDatl.set_attrVal(
                                                FXmlTagDATL.A_Length,
                                                FXmlTagDATL.D_Length,
                                                fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Length, FXmlTagHITL.D_Length)
                                                );
                                        }
                                        else if (fItemFormat != FFormat.Unknown)
                                        {
                                            // ***
                                            // 2017.03.23 by spike.lee
                                            // fFormat를 fItemFormat으로 변경
                                            // ***
                                            len = int.Parse(fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Length, FXmlTagHITL.D_Length));
                                            val = FValueConverter.toDataConversionStringValue(
                                                fItemFormat,
                                                fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Value, FXmlTagHITL.D_Value),
                                                fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Transformer, FXmlTagHITL.D_Transformer),
                                                fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_DataConversionSetExpression, FXmlTagHITL.D_DataConversionSetExpression),
                                                ref len
                                                );
                                            // --
                                            fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                                            fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                        }
                                    }                                    
                                }
                                else if (fFormat == FFormat.Raw)
                                {
                                    if (
                                        fSourceType == FDataSourceType.ItemTag1 ||
                                        fSourceType == FDataSourceType.ItemTag2 ||
                                        fSourceType == FDataSourceType.ItemTag3 ||
                                        fSourceType == FDataSourceType.ItemTag4 ||
                                        fSourceType == FDataSourceType.ItemTag5
                                        )
                                    {
                                        val = getHostItemLogValueBySourceType(fSourceType, fXmlNodeHitl);
                                        len = 0;
                                        // --
                                        val = FValueConverter.fromStringValue(FFormat.Ascii, val, out len);  
                                    }
                                    else
                                    {
                                        len = calculateHostItemLogRawBytes(fXmlNodeHitl);
                                    }
                                    // --
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                }
                                else
                                {
                                    if (
                                        fSourceType == FDataSourceType.ItemTag1 ||
                                        fSourceType == FDataSourceType.ItemTag2 ||
                                        fSourceType == FDataSourceType.ItemTag3 ||
                                        fSourceType == FDataSourceType.ItemTag4 ||
                                        fSourceType == FDataSourceType.ItemTag5
                                        )
                                    {
                                        val = getHostItemLogValueBySourceType(fSourceType, fXmlNodeHitl);
                                    }
                                    else
                                    {
                                        val = FValueConverter.toDataConversionStringValue(
                                            FEnumConverter.toFormat(fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Format, FXmlTagHITL.D_Format)),
                                            fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Value, FXmlTagHITL.D_Value),
                                            fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Transformer, FXmlTagHITL.D_Transformer),
                                            fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_DataConversionSetExpression, FXmlTagHITL.D_DataConversionSetExpression)
                                            );
                                    }
                                    // --
                                    len = 0;
                                    val = FValueConverter.convertStringValue(fFormat, val, out len);
                                    // --
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value, val);
                                    fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                                }
                            }   // for end
                        }   // for end

                        // --

                        // ***
                        // Parent가 Data Log일 경우 추가된 Variable Data Log 만큼 Length 증가
                        // ***
                        if (fXmlNodeParent.name == FXmlTagDATL.E_Data)
                        {
                            len = int.Parse(fXmlNodeParent.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length)) + ((varCnt - 1) * varLen);
                            fXmlNodeParent.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, len.ToString());
                        }

                        // --

                        index += varLen;

                        #endregion
                    }
                }   // while end
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeDat = null;
                fXmlNodeDatl = null;
                fXmlNodeListHitl = null;
                fXmlNodeHitl = null;
                fXmlNodeSrc = null;
                fXmlNodeTgt = null;
                hitlPositionKey = null;
                hitlPositionData = null;
                varNameCount = null;
                fixNameCount = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void generateDataLogByPattern(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeParent,
            FXmlNodeList fXmlNodeListDatl
            )
        {
            FXmlNode fXmlNodeDatl = null;
            FPattern fPattern;
            FFormat fFormat;
            int fixLen = 0;
            int len = 0;

            try
            {
                for (int i = 0; i < fXmlNodeListDatl.count; i++)
                {
                    fXmlNodeDatl = fXmlNodeListDatl[i];
                    fPattern = FEnumConverter.toPattern(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Pattern, FXmlTagDATL.D_Pattern));

                    // --

                    if (fPattern == FPattern.Fixed)
                    {
                        fFormat = FEnumConverter.toFormat(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format));
                        fixLen = int.Parse(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_FixedLength, FXmlTagDATL.D_FixedLength));

                        // --

                        if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                        {
                            generateColumnByPattern(
                                fScenarioData,
                                fXmlNodeDatl,
                                fXmlNodeDatl.selectNodes(FXmlTagDATL.E_Data)
                                );
                        }

                        // --

                        if (fixLen > 1)
                        {
                            fXmlNodeDatl.set_attrVal(FXmlTagDATL.A_FixedLength, FXmlTagDATL.D_FixedLength, "1");

                            // --

                            for (int j = 1; j < fixLen; j++)
                            {
                                fXmlNodeDatl = fXmlNodeParent.insertAfter(fXmlNodeDatl.clone(true), fXmlNodeDatl);
                            }

                            // --

                            // ***
                            // Parent가 FDataLog인 경우 Length 추가
                            // ***
                            if (fXmlNodeParent.name == FXmlTagDATL.E_Data)
                            {
                                len = int.Parse(fXmlNodeParent.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length));
                                fXmlNodeParent.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, (len + fixLen - 1).ToString());
                            }
                        }
                    }
                    else
                    {
                        fXmlNodeParent.removeChild(fXmlNodeDatl);

                        // --

                        if (fXmlNodeParent.name == FXmlTagDATL.E_Data)
                        {
                            len = int.Parse(fXmlNodeParent.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length));
                            fXmlNodeParent.set_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length, (len - 1).ToString());
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
                fXmlNodeDatl = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region SecsMessageTransfer Generation Methods

        public static FXmlNode generateSecsMessageTransfer(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeDtsl,
            FXmlNode fXmlNodeSmg
            )
        {
            Dictionary<string, int> gDatlPositionKey = null;              // Data Log Name, Position
            Dictionary<string, FXmlNodeList> gDatlPositionData = null;    // Data Log Name, Data Log Node List 
            FXmlNode fXmlNodeSmt = null;

            try
            {
                gDatlPositionKey = new Dictionary<string, int>();
                gDatlPositionData = new Dictionary<string, FXmlNodeList>();

                // --

                fXmlNodeSmt = fXmlNodeSmg.clone(false);
                // --
                generateSecsItemByDataLog(
                    fScenarioData,
                    fXmlNodeSmt,
                    fXmlNodeSmg.selectNodes(FXmlTagSIT.E_SecsItem),
                    gDatlPositionKey,
                    gDatlPositionData,
                    null
                    );

                // --

                return fXmlNodeSmt;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                gDatlPositionKey = null;
                gDatlPositionData = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void generateSecsItemByDataLog(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeParent,
            FXmlNodeList fXmlNodeListSit,
            Dictionary<string, int> gDatlPositionKey,
            Dictionary<string, FXmlNodeList> gDatlPositionData,
            FXmlNode fXmlNodeParentDatl
            )
        {
            FXmlNode fXmlNodeSit = null;
            FXmlNode fXmlNodeSit2 = null;
            FXmlNodeList fXmlNodeListDatl = null;
            FXmlNode fXmlNodeDatl = null;
            FXmlNode fXmlNodeSrc = null;
            FXmlNode fXmlNodeTgt = null;
            int sitCount = 0;
            int index = 0;
            Dictionary<string, int> datlPositionKey = null;
            Dictionary<string, FXmlNodeList> datlPositionData = null;
            Dictionary<string, int> varNameCount = null;
            Dictionary<string, int> fixNameCount = null;
            int datlPos = 0;
            string datlName = string.Empty;
            FFormat fFormat;
            FPattern fPattern;
            int fixedLength = 0;
            FDataScanMode fScanMode;
            int fixLen = 0;
            int varLen = 0;
            int varCnt = 0;
            int calVarCnt = 0;
            string val = string.Empty;
            int len = 0;
            string xpath = string.Empty;
            FFormat fItemFormat;

            try
            {
                // ***
                // 동일한 이름의 Data Log가 사용된 회수를 보관하기 위한 Storage 생성
                // ***
                datlPositionKey = new Dictionary<string, int>();
                datlPositionData = new Dictionary<string, FXmlNodeList>();
                sitCount = fXmlNodeListSit.count;

                // --

                while (index < sitCount)
                {
                    fXmlNodeSit = fXmlNodeListSit[index];
                    fPattern = FEnumConverter.toPattern(fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Pattern, FXmlTagSIT.D_Pattern));
                    fFormat = FEnumConverter.toFormat(fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Format, FXmlTagSIT.D_Format));

                    // --

                    if (fPattern == FPattern.Fixed)
                    {
                        #region Fixed

                        fScanMode = FEnumConverter.toDataScanMode(fXmlNodeSit.get_attrVal(FXmlTagSIT.A_ScanMode, FXmlTagSIT.D_ScanMode));
                        datlName = fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Name, FXmlTagSIT.D_Name);
                        // --
                        if (fScanMode == FDataScanMode.Local)
                        {
                            if (datlPositionKey.ContainsKey(datlName))
                            {
                                datlPos = datlPositionKey[datlName];
                                fXmlNodeListDatl = datlPositionData[datlName];
                            }
                            else
                            {
                                datlPos = 0;
                                fXmlNodeListDatl = collectDataLogByLocalScan(fScenarioData, fXmlNodeParentDatl, FDataTargetType.Item, datlName);
                                // --
                                datlPositionKey.Add(datlName, datlPos);
                                datlPositionData.Add(datlName, fXmlNodeListDatl);
                            }
                        }
                        else
                        {
                            if (gDatlPositionKey.ContainsKey(datlName))
                            {
                                datlPos = gDatlPositionKey[datlName];
                                fXmlNodeListDatl = gDatlPositionData[datlName];
                            }
                            else
                            {
                                datlPos = 0;
                                fXmlNodeListDatl = collectDataLogByGlobalScan(fScenarioData, FDataTargetType.Item, datlName);
                                // --
                                gDatlPositionKey.Add(datlName, datlPos);
                                gDatlPositionData.Add(datlName, fXmlNodeListDatl);
                            }
                        }

                        // --

                        fixedLength = int.Parse(fXmlNodeSit.get_attrVal(FXmlTagSIT.A_FixedLength, FXmlTagSIT.D_FixedLength));
                        // --
                        for (int i = 0; i < fixedLength; i++)
                        {
                            fXmlNodeSit2 = fXmlNodeParent.appendChild(fXmlNodeSit.clone(false));
                            fXmlNodeSit2.set_attrVal(FXmlTagSIT.A_FixedLength, FXmlTagSIT.D_FixedLength, "1");

                            // --

                            // ***
                            // Fixed일 경우 Data Log Position이 초과할 경우 다시 순환시킨다.
                            // ***
                            if (fXmlNodeListDatl.count == 0)
                            {
                                fXmlNodeDatl = null;
                            }
                            else
                            {
                                if (datlPos >= fXmlNodeListDatl.count)
                                {
                                    datlPos = 0; // 순환
                                }
                                fXmlNodeDatl = fXmlNodeListDatl[datlPos];
                                datlPos++;

                                // --

                                // ***
                                // 2017.03.23 by spike.lee
                                // Unknown Format에 List Format이 적용될 경우 Child 처리에 Position이 저장되지 않아 무한루프 도는 문제가 발생하여
                                // Position 저장 위치를 변경 함.
                                // *** 
                                if (fScanMode == FDataScanMode.Local)
                                {
                                    datlPositionKey[datlName] = datlPos;
                                }
                                else
                                {
                                    gDatlPositionKey[datlName] = datlPos;
                                }
                            }

                            // --

                            if (fXmlNodeDatl == null)
                            {
                                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                                {
                                    generateSecsItemByDataLog(
                                        fScenarioData,
                                        fXmlNodeSit2,
                                        fXmlNodeSit.selectNodes(FXmlTagSIT.E_SecsItem),
                                        gDatlPositionKey,
                                        gDatlPositionData,
                                        fXmlNodeParentDatl
                                        );
                                }
                            }
                            else
                            {
                                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                                {
                                    generateSecsItemByDataLog(
                                        fScenarioData,
                                        fXmlNodeSit2,
                                        fXmlNodeSit.selectNodes(FXmlTagSIT.E_SecsItem),
                                        gDatlPositionKey,
                                        gDatlPositionData,
                                        fXmlNodeDatl
                                        );
                                }
                                else if (fFormat == FFormat.Unknown)
                                {
                                    // ***
                                    // Unknown Secs Item 복제
                                    // ***
                                    fXmlNodeSrc = fXmlNodeSit.clone(false);

                                    // --

                                    // ***
                                    // Secs Item의 Format를 Data Log Format으로 설정
                                    // ***
                                    // --
                                    // ***
                                    // 2017.03.23 by spike.lee
                                    // fFormat를 fItemFormat으로 변경
                                    // ***
                                    fItemFormat = FEnumConverter.toFormat(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format));
                                    fXmlNodeSit2.set_attrVal(FXmlTagSIT.A_Format, FXmlTagSIT.D_Format, FEnumConverter.fromFormat(fItemFormat));

                                    // --

                                    if (fItemFormat == FFormat.List || fItemFormat == FFormat.AsciiList)
                                    {
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // fXmlNodeTgt를 fXmlNodeDatl에 Append하고 generteDataLogBySecsItemLog에서 또 Append하여 Item이 2배 생성되는 문제 발생
                                        // ***
                                        len = 0;
                                        xpath = FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_TargetType + "='" + FEnumConverter.fromDataTargetType(FDataTargetType.Item) + "']";
                                        foreach (FXmlNode x in fXmlNodeDatl.selectNodes(xpath))
                                        {
                                            fXmlNodeTgt = fXmlNodeSrc.clone(false);
                                            fXmlNodeTgt.set_attrVal(FXmlTagSIT.A_FixedLength, FXmlTagSIT.D_FixedLength, "1");
                                            fXmlNodeTgt.set_attrVal(
                                                FXmlTagSIT.A_Name,
                                                FXmlTagSIT.D_Name,
                                                x.get_attrVal(FXmlTagDATL.A_TargetItem, FXmlTagDATL.D_TargetItem)
                                                );
                                            // ***
                                            // fXmlNodeTgt = fXmlNodeSit2.appendChild(fXmlNodeTgt);
                                            // ***
                                            // --
                                            generateSecsItemByDataLog(
                                                fScenarioData,
                                                fXmlNodeSit2,
                                                fXmlNodeTgt.selectNodes("."),
                                                gDatlPositionKey,
                                                gDatlPositionData,
                                                x
                                                );
                                            // --
                                            len++;
                                        }
                                        // --
                                        fXmlNodeSit2.set_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length, len.ToString());
                                    }
                                    else if (fItemFormat == FFormat.Raw)
                                    {
                                        fXmlNodeSit2.set_attrVal(
                                            FXmlTagSIT.A_Length,
                                            FXmlTagSIT.D_Length,
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length)
                                            );
                                    }
                                    else if (fItemFormat != FFormat.Unknown)
                                    {
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // fFormat를 fItemFormat으로 변경
                                        // ***
                                        len = int.Parse(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length));
                                        val = FValueConverter.toDataConversionStringValue(
                                            fItemFormat,
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value),
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression),
                                            ref len
                                            );
                                        // --
                                        fXmlNodeSit2.set_attrVal(FXmlTagSIT.A_Value, FXmlTagSIT.D_Value, val);
                                        fXmlNodeSit2.set_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length, len.ToString());
                                    }
                                }
                                else if (fFormat == FFormat.Raw)
                                {
                                    len = calculateDataLogRawBytes(fXmlNodeDatl);
                                    fXmlNodeSit2.set_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length, len.ToString());
                                }
                                else
                                {
                                    val = FValueConverter.toDataConversionStringValue(
                                        FEnumConverter.toFormat(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format)),
                                        fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value),
                                        fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                                        fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression)
                                        );
                                    // --
                                    len = 0;
                                    val = FValueConverter.convertStringValue(fFormat, val, out len);
                                    // --
                                    fXmlNodeSit2.set_attrVal(FXmlTagSIT.A_Value, FXmlTagSIT.D_Value, val);
                                    fXmlNodeSit2.set_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length, len.ToString());
                                }
                            }
                        }   // fixedLength for end

                        // --

                        // ***
                        // Parent가 Secs Item일 경우 Length 설정
                        // ***
                        if (fixedLength > 1 || fXmlNodeParent.name == FXmlTagSIT.E_SecsItem)
                        {
                            len = int.Parse(fXmlNodeParent.get_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length)) + fixedLength - 1;
                            fXmlNodeParent.set_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length, len.ToString());
                        }

                        // --

                        index++;

                        #endregion
                    }
                    else  // Variable
                    {
                        #region Variable

                        fixLen = 0;
                        varLen = 0;
                        varCnt = 0;
                        calVarCnt = 0;
                        // --
                        varNameCount = new Dictionary<string, int>();
                        fixNameCount = new Dictionary<string, int>();

                        // --

                        for (int i = index; i < sitCount; i++)
                        {
                            fXmlNodeSrc = fXmlNodeListSit[i];

                            // --

                            // ***
                            // 1. Previous Secs Item은 Fixed 형식으로 처리
                            // 2. Variable Secs Item은 연속적으로 정의되어 있어 우선 처리
                            // 3. Next Secs Item은 Variable Secs Item 처리 이후 Fixed 형식으로 처리
                            // ***
                            fPattern = FEnumConverter.toPattern(fXmlNodeSrc.get_attrVal(FXmlTagSIT.A_Pattern, FXmlTagSIT.D_Pattern));
                            datlName = fXmlNodeSrc.get_attrVal(FXmlTagSIT.A_Name, FXmlTagSIT.A_Name);
                            // --
                            if (fPattern == FPattern.Variable)
                            {
                                if (varNameCount.ContainsKey(datlName))
                                {
                                    varNameCount[datlName] = varNameCount[datlName] + 1;
                                }
                                else
                                {
                                    varNameCount.Add(datlName, 1);
                                    fixNameCount.Add(datlName, 0);
                                }
                                varLen++;

                                // --

                                if (!datlPositionKey.ContainsKey(datlName))
                                {
                                    datlPositionKey.Add(datlName, 0);
                                    datlPositionData.Add(datlName, collectDataLogByVariableLocalScan(fScenarioData, fXmlNodeParentDatl, FDataTargetType.Item, datlName));
                                }
                            }
                            else
                            {
                                // ***
                                // Scan Mode가 Global인 Secs Item는 Variable 계산에 미포함
                                // ***
                                fScanMode = FEnumConverter.toDataScanMode(fXmlNodeSrc.get_attrVal(FXmlTagSIT.A_ScanMode, FXmlTagSIT.D_ScanMode));
                                if (fScanMode == FDataScanMode.Local && fixNameCount.ContainsKey(datlName))
                                {
                                    fixLen = int.Parse(fXmlNodeSrc.get_attrVal(FXmlTagSIT.A_FixedLength, FXmlTagSIT.D_FixedLength));
                                    fixNameCount[datlName] = fixNameCount[datlName] + fixLen;
                                }
                            }
                        }

                        // --

                        // ***
                        // Variable 회수 구하기 (Minimum)                        
                        // ***
                        foreach (string s in varNameCount.Keys)
                        {
                            calVarCnt = (datlPositionData[s].count - datlPositionKey[s] - fixNameCount[s]) / varNameCount[s];
                            if (calVarCnt < 1)
                            {
                                varCnt = 0;
                                break;
                            }
                            // --
                            if (varCnt == 0)
                            {
                                varCnt = calVarCnt;
                            }
                            else if (varCnt > calVarCnt)
                            {
                                varCnt = calVarCnt;
                            }
                        }

                        // --

                        for (int i = 0; i < varCnt; i++)
                        {
                            for (int j = 0; j < varLen; j++)
                            {
                                fXmlNodeSit = fXmlNodeListSit[index + j];
                                fFormat = FEnumConverter.toFormat(fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Format, FXmlTagSIT.D_Format));
                                // --
                                datlName = fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Name, FXmlTagSIT.D_Name);
                                datlPos = datlPositionKey[datlName];
                                
                                // --
                                // 2018.04.06 by Jeff.Kim
                                // Data가 없을 경우 추가.
                                fXmlNodeDatl = null;
                                if (datlPositionData[datlName] != null && datlPositionData[datlName].count > 0)
                                {
                                    fXmlNodeDatl = datlPositionData[datlName][datlPos];
                                }      

                                datlPos++;

                                // --

                                // ***
                                // 2017.03.23 by spike.lee
                                // Position 저장 위치 변경
                                // ***
                                datlPositionKey[datlName] = datlPos;

                                // --
                                // 2018.04.06 by Jeff.Kim
                                // Data가 없을 경우 Item gernerator 하지 않음
                                if (fXmlNodeDatl == null)
                                {
                                    continue;
                                }

                                // --

                                fXmlNodeSit2 = fXmlNodeParent.appendChild(fXmlNodeSit.clone(false));
                                fXmlNodeSit2.set_attrVal(FXmlTagSIT.A_Pattern, FXmlTagSIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));

                                // --

                                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                                {
                                    generateSecsItemByDataLog(
                                        fScenarioData,
                                        fXmlNodeSit2,
                                        fXmlNodeSit.selectNodes(FXmlTagSIT.E_SecsItem),
                                        gDatlPositionKey,
                                        gDatlPositionData,
                                        fXmlNodeDatl
                                        );
                                }
                                else if (fFormat == FFormat.Unknown)
                                {
                                    // ***
                                    // Unknown Secs Item 복제
                                    // ***
                                    fXmlNodeSrc = fXmlNodeSit.clone(false);

                                    // --

                                    // ***
                                    // Secs Item의 Format를 Data Log Format으로 설정
                                    // ***
                                    // --
                                    // ***
                                    // 2017.03.23 by spike.lee
                                    // fFormat를 fItemFormat으로 변경
                                    // ***
                                    fItemFormat = FEnumConverter.toFormat(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format));
                                    fXmlNodeSit2.set_attrVal(FXmlTagSIT.A_Format, FXmlTagSIT.D_Format, FEnumConverter.fromFormat(fItemFormat));

                                    // --

                                    if (fItemFormat == FFormat.List || fItemFormat == FFormat.AsciiList)
                                    {
                                        len = 0;
                                        xpath = FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_TargetType + "='" + FEnumConverter.fromDataTargetType(FDataTargetType.Item) + "']";
                                        foreach (FXmlNode x in fXmlNodeDatl.selectNodes(xpath))
                                        {
                                            // ***
                                            // 2017.03.23 by spike.lee
                                            // 추가되는 fXmlNodeTgt Variable 속성을 Fixed로 변경
                                            // ***
                                            fXmlNodeTgt = fXmlNodeSrc.clone(false);
                                            fXmlNodeTgt.set_attrVal(FXmlTagSIT.A_Pattern, FXmlTagSIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                                            fXmlNodeTgt.set_attrVal(
                                                FXmlTagSIT.A_Name,
                                                FXmlTagSIT.D_Name,
                                                x.get_attrVal(FXmlTagDATL.A_TargetItem, FXmlTagDATL.D_TargetItem)
                                                );
                                            // ***
                                            // fXmlNodeTgt = fXmlNodeSit2.appendChild(fXmlNodeTgt);
                                            // ***
                                            // --
                                            generateSecsItemByDataLog(
                                                fScenarioData,
                                                fXmlNodeSit2,
                                                fXmlNodeTgt.selectNodes("."),
                                                gDatlPositionKey,
                                                gDatlPositionData,
                                                x
                                                );
                                            // --
                                            len++;
                                        }
                                        // --
                                        fXmlNodeSit2.set_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length, len.ToString());
                                    }
                                    else if (fItemFormat == FFormat.Raw)
                                    {
                                        fXmlNodeSit2.set_attrVal(
                                            FXmlTagSIT.A_Length,
                                            FXmlTagSIT.D_Length,
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length)
                                            );
                                    }
                                    else if (fItemFormat != FFormat.Unknown)
                                    {
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // fFormat를 fItemFormat으로 변경
                                        // ***
                                        len = int.Parse(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length));
                                        val = FValueConverter.toDataConversionStringValue(
                                            fItemFormat,
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value),
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression),
                                            ref len
                                            );
                                        // --
                                        fXmlNodeSit2.set_attrVal(FXmlTagSIT.A_Value, FXmlTagSIT.D_Value, val);
                                        fXmlNodeSit2.set_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length, len.ToString());
                                    }
                                }
                                else if (fFormat == FFormat.Raw)
                                {
                                    len = calculateDataLogRawBytes(fXmlNodeDatl);
                                    fXmlNodeSit2.set_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length, len.ToString());
                                }
                                else
                                {
                                    val = FValueConverter.toDataConversionStringValue(
                                        FEnumConverter.toFormat(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format)),
                                        fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value),
                                        fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                                        fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression)
                                        );
                                    // --
                                    len = 0;
                                    val = FValueConverter.convertStringValue(fFormat, val, out len);
                                    // --
                                    fXmlNodeSit2.set_attrVal(FXmlTagSIT.A_Value, FXmlTagSIT.D_Value, val);
                                    fXmlNodeSit2.set_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length, len.ToString());
                                }
                            }   // for end
                        }   // for end

                        // --

                        // ***
                        // Parent가 Secs Item일 경우 추가된 Variable Secs Item 만큼 Length 증가
                        // ***
                        if (fXmlNodeParent.name == FXmlTagSIT.E_SecsItem)
                        {
                            len = int.Parse(fXmlNodeParent.get_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length)) + ((varCnt - 1) * varLen);
                            fXmlNodeParent.set_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length, len.ToString());
                        }

                        // --

                        index += varLen;

                        #endregion
                    }
                }   // while end
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeSit = null;
                fXmlNodeSit2 = null;
                fXmlNodeListDatl = null;
                fXmlNodeDatl = null;
                fXmlNodeSrc = null;
                fXmlNodeTgt = null;
                datlPositionKey = null;
                gDatlPositionData = null;
                varNameCount = null;
                fixNameCount = null;
            }
        }

        #endregion

        //-----------------------------------------------------------------------------------------------------------------------

        #region HostMessageTransfer Generation Methods

        public static FXmlNode generateHostMessageTransfer(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeDtsl,
            FXmlNode fXmlNodeHmg
            )
        {
            Dictionary<string, int> gDatlPositionKey = null;              // Data Log Name, Position
            Dictionary<string, FXmlNodeList> gDatlPositionData = null;    // Data Log Name, Data Log Node List 
            FXmlNode fXmlNodeHmt = null;

            try
            {
                gDatlPositionKey = new Dictionary<string, int>();
                gDatlPositionData = new Dictionary<string, FXmlNodeList>();

                // --

                fXmlNodeHmt = fXmlNodeHmg.clone(false);
                // --
                generateHostItemByDataLog(
                    fScenarioData,
                    fXmlNodeHmt,
                    fXmlNodeHmg.selectNodes(FXmlTagHIT.E_HostItem),
                    gDatlPositionKey,
                    gDatlPositionData,
                    null
                    );

                // --

                return fXmlNodeHmt;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                gDatlPositionKey = null;
                gDatlPositionData = null;
            }
            return null;
        }

        //-----------------------------------------------------------------------------------------------------------------------

        private static void generateHostItemByDataLog(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeParent,
            FXmlNodeList fXmlNodeListHit,
            Dictionary<string, int> gDatlPositionKey,
            Dictionary<string, FXmlNodeList> gDatlPositionData,
            FXmlNode fXmlNodeParentDatl
            )
        {
            FXmlNode fXmlNodeHit = null;
            FXmlNode fXmlNodeHit2 = null;
            FXmlNodeList fXmlNodeListDatl = null;
            FXmlNode fXmlNodeDatl = null;
            FXmlNode fXmlNodeSrc = null;
            FXmlNode fXmlNodeTgt = null;
            int hitCount = 0;
            int index = 0;
            Dictionary<string, int> datlPositionKey = null;
            Dictionary<string, FXmlNodeList> datlPositionData = null;
            Dictionary<string, int> varNameCount = null;
            Dictionary<string, int> fixNameCount = null;
            int datlPos = 0;
            string datlName = string.Empty;
            FFormat fFormat;
            FPattern fPattern;
            int fixedLength = 0;
            FDataScanMode fScanMode;
            int fixLen = 0;
            int varLen = 0;
            int varCnt = 0;
            int calVarCnt = 0;
            string val = string.Empty;
            int len = 0;
            string xpath = string.Empty;
            FFormat fItemFormat;

            try
            {
                // ***
                // 동일한 이름의 Data Log가 사용된 회수를 보관하기 위한 Storage 생성
                // ***
                datlPositionKey = new Dictionary<string, int>();
                datlPositionData = new Dictionary<string, FXmlNodeList>();
                hitCount = fXmlNodeListHit.count;

                // --

                while (index < hitCount)
                {
                    fXmlNodeHit = fXmlNodeListHit[index];
                    fPattern = FEnumConverter.toPattern(fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern));
                    fFormat = FEnumConverter.toFormat(fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format));

                    // --

                    if (fPattern == FPattern.Fixed)
                    {
                        #region Fixed

                        fScanMode = FEnumConverter.toDataScanMode(fXmlNodeHit.get_attrVal(FXmlTagHIT.A_ScanMode, FXmlTagHIT.D_ScanMode));
                        datlName = fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Name, FXmlTagHIT.D_Name);
                        // --
                        if (fScanMode == FDataScanMode.Local)
                        {
                            if (datlPositionKey.ContainsKey(datlName))
                            {
                                datlPos = datlPositionKey[datlName];
                                fXmlNodeListDatl = datlPositionData[datlName];
                            }
                            else
                            {
                                datlPos = 0;
                                fXmlNodeListDatl = collectDataLogByLocalScan(fScenarioData, fXmlNodeParentDatl, FDataTargetType.Item, datlName);
                                // --
                                datlPositionKey.Add(datlName, datlPos);
                                datlPositionData.Add(datlName, fXmlNodeListDatl);
                            }
                        }
                        else
                        {
                            if (gDatlPositionKey.ContainsKey(datlName))
                            {
                                datlPos = gDatlPositionKey[datlName];
                                fXmlNodeListDatl = gDatlPositionData[datlName];
                            }
                            else
                            {
                                datlPos = 0;
                                fXmlNodeListDatl = collectDataLogByGlobalScan(fScenarioData, FDataTargetType.Item, datlName);
                                // --
                                gDatlPositionKey.Add(datlName, datlPos);
                                gDatlPositionData.Add(datlName, fXmlNodeListDatl);
                            }
                        }

                        // --

                        fixedLength = int.Parse(fXmlNodeHit.get_attrVal(FXmlTagHIT.A_FixedLength, FXmlTagHIT.D_FixedLength));
                        // --
                        for (int i = 0; i < fixedLength; i++)
                        {
                            fXmlNodeHit2 = fXmlNodeParent.appendChild(fXmlNodeHit.clone(false));
                            fXmlNodeHit2.set_attrVal(FXmlTagHIT.A_FixedLength, FXmlTagHIT.D_FixedLength, "1");

                            // --

                            // ***
                            // Fixed일 경우 Data Log Position이 초과할 경우 다시 순환시킨다.
                            // ***
                            if (fXmlNodeListDatl.count == 0)
                            {
                                fXmlNodeDatl = null;
                            }
                            else
                            {
                                if (datlPos >= fXmlNodeListDatl.count)
                                {
                                    datlPos = 0; // 순환
                                }
                                fXmlNodeDatl = fXmlNodeListDatl[datlPos];
                                datlPos++;

                                // --

                                // ***
                                // 2017.03.23 by spike.lee
                                // Unknown Format에 List Format이 적용될 경우 Child 처리에 Position이 저장되지 않아 무한루프 도는 문제가 발생하여
                                // Position 저장 위치를 변경 함.
                                // *** 
                                if (fScanMode == FDataScanMode.Local)
                                {
                                    datlPositionKey[datlName] = datlPos;
                                }
                                else
                                {
                                    gDatlPositionKey[datlName] = datlPos;
                                }
                            }

                            // --

                            if (fXmlNodeDatl == null)
                            {
                                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                                {
                                    generateHostItemByDataLog(
                                        fScenarioData,
                                        fXmlNodeHit2,
                                        fXmlNodeHit.selectNodes(FXmlTagHIT.E_HostItem),
                                        gDatlPositionKey,
                                        gDatlPositionData,
                                        fXmlNodeParentDatl
                                        );
                                }
                            }
                            else
                            {
                                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                                {
                                    generateHostItemByDataLog(
                                        fScenarioData,
                                        fXmlNodeHit2,
                                        fXmlNodeHit.selectNodes(FXmlTagHIT.E_HostItem),
                                        gDatlPositionKey,
                                        gDatlPositionData,
                                        fXmlNodeDatl
                                        );
                                }
                                else if (fFormat == FFormat.Unknown)
                                {
                                    // ***
                                    // Unknown Host Item 복제
                                    // ***
                                    fXmlNodeSrc = fXmlNodeHit.clone(false);

                                    // --

                                    // ***
                                    // Host Item의 Format를 Data Log Format으로 설정
                                    // ***
                                    // --
                                    // ***
                                    // 2017.03.23 by spike.lee
                                    // fFormat를 fItemFormat으로 변경
                                    // ***
                                    fItemFormat = FEnumConverter.toFormat(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format));
                                    fXmlNodeHit2.set_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format, FEnumConverter.fromFormat(fItemFormat));

                                    // --

                                    if (fItemFormat == FFormat.List || fItemFormat == FFormat.AsciiList)
                                    {
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // fXmlNodeTgt를 fXmlNodeDatl에 Append하고 generteDataLogBySecsItemLog에서 또 Append하여 Item이 2배 생성되는 문제 발생
                                        // ***
                                        len = 0;
                                        xpath = FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_TargetType + "='" + FEnumConverter.fromDataTargetType(FDataTargetType.Item) + "']";
                                        foreach (FXmlNode x in fXmlNodeDatl.selectNodes(xpath))
                                        {
                                            fXmlNodeTgt = fXmlNodeSrc.clone(false);                                            
                                            fXmlNodeTgt.set_attrVal(FXmlTagHIT.A_FixedLength, FXmlTagHIT.D_FixedLength, "1");
                                            fXmlNodeTgt.set_attrVal(
                                                FXmlTagHIT.A_Name,
                                                FXmlTagHIT.D_Name,
                                                x.get_attrVal(FXmlTagDATL.A_TargetItem, FXmlTagDATL.D_TargetItem)
                                                );
                                            // ***
                                            // fXmlNodeTgt = fXmlNodeHit2.appendChild(fXmlNodeTgt);
                                            // ***
                                            // --
                                            generateHostItemByDataLog(
                                                fScenarioData,
                                                fXmlNodeHit2,
                                                fXmlNodeTgt.selectNodes("."),
                                                gDatlPositionKey,
                                                gDatlPositionData,
                                                x
                                                );
                                            // --
                                            len++;
                                        }
                                        // --
                                        fXmlNodeHit2.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, len.ToString());
                                    }
                                    else if (fItemFormat == FFormat.Raw)
                                    {
                                        fXmlNodeHit2.set_attrVal(
                                            FXmlTagHIT.A_Length,
                                            FXmlTagHIT.D_Length,
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length)
                                            );
                                    }
                                    else if (fItemFormat != FFormat.Unknown)
                                    {
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // fFormat를 fItemFormat으로 변경
                                        // ***
                                        len = int.Parse(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length));
                                        val = FValueConverter.toDataConversionStringValue(
                                            fItemFormat,
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value),
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression),
                                            ref len
                                            );
                                        // --
                                        fXmlNodeHit2.set_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value, val);
                                        fXmlNodeHit2.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, len.ToString());
                                    }
                                }
                                else if (fFormat == FFormat.Raw)
                                {
                                    len = calculateDataLogRawBytes(fXmlNodeDatl);
                                    fXmlNodeHit2.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, len.ToString());
                                }
                                else
                                {
                                    val = FValueConverter.toDataConversionStringValue(
                                        FEnumConverter.toFormat(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format)),
                                        fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value),
                                        fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                                        fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression)
                                        );
                                    // --
                                    len = 0;
                                    val = FValueConverter.convertStringValue(fFormat, val, out len);
                                    // --
                                    fXmlNodeHit2.set_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value, val);
                                    fXmlNodeHit2.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, len.ToString());
                                }
                            }
                        }   // fixedLength for end

                        // --

                        // ***
                        // Parent가 Host Item일 경우 Length 설정
                        // ***
                        if (fixedLength > 1 || fXmlNodeParent.name == FXmlTagHIT.E_HostItem)
                        {
                            len = int.Parse(fXmlNodeParent.get_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length)) + fixedLength - 1;
                            fXmlNodeParent.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, len.ToString());
                        }

                        // --

                        index++;

                        #endregion
                    }
                    else  // Variable
                    {
                        #region Variable

                        fixLen = 0;
                        varLen = 0;
                        varCnt = 0;
                        calVarCnt = 0;
                        // --
                        varNameCount = new Dictionary<string, int>();
                        fixNameCount = new Dictionary<string, int>();

                        // --

                        for (int i = index; i < hitCount; i++)
                        {
                            fXmlNodeSrc = fXmlNodeListHit[i];

                            // --

                            // ***
                            // 1. Previous Host Item은 Fixed 형식으로 처리
                            // 2. Variable Host Item은 연속적으로 정의되어 있어 우선 처리
                            // 3. Next Host Item은 Variable Host Item 처리 이후 Fixed 형식으로 처리
                            // ***
                            fPattern = FEnumConverter.toPattern(fXmlNodeSrc.get_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern));
                            datlName = fXmlNodeSrc.get_attrVal(FXmlTagHIT.A_Name, FXmlTagHIT.A_Name);
                            // --
                            if (fPattern == FPattern.Variable)
                            {
                                if (varNameCount.ContainsKey(datlName))
                                {
                                    varNameCount[datlName] = varNameCount[datlName] + 1;
                                }
                                else
                                {
                                    varNameCount.Add(datlName, 1);
                                    fixNameCount.Add(datlName, 0);
                                }
                                varLen++;

                                // --

                                if (!datlPositionKey.ContainsKey(datlName))
                                {
                                    datlPositionKey.Add(datlName, 0);
                                    datlPositionData.Add(datlName, collectDataLogByVariableLocalScan(fScenarioData, fXmlNodeParentDatl, FDataTargetType.Item, datlName));
                                }
                            }
                            else
                            {
                                // ***
                                // Scan Mode가 Global인 Host Item는 Variable 계산에 미포함
                                // ***
                                fScanMode = FEnumConverter.toDataScanMode(fXmlNodeSrc.get_attrVal(FXmlTagHIT.A_ScanMode, FXmlTagHIT.D_ScanMode));
                                if (fScanMode == FDataScanMode.Local && fixNameCount.ContainsKey(datlName))
                                {
                                    fixLen = int.Parse(fXmlNodeSrc.get_attrVal(FXmlTagHIT.A_FixedLength, FXmlTagHIT.D_FixedLength));
                                    fixNameCount[datlName] = fixNameCount[datlName] + fixLen;
                                }
                            }
                        }

                        // --

                        // ***
                        // Variable 회수 구하기 (Minimum)                        
                        // ***
                        foreach (string s in varNameCount.Keys)
                        {
                            calVarCnt = (datlPositionData[s].count - datlPositionKey[s] - fixNameCount[s]) / varNameCount[s];
                            if (calVarCnt < 1)
                            {
                                varCnt = 0;
                                break;
                            }
                            // --
                            if (varCnt == 0)
                            {
                                varCnt = calVarCnt;
                            }
                            else if (varCnt > calVarCnt)
                            {
                                varCnt = calVarCnt;
                            }
                        }

                        // --

                        for (int i = 0; i < varCnt; i++)
                        {
                            for (int j = 0; j < varLen; j++)
                            {
                                fXmlNodeHit = fXmlNodeListHit[index + j];
                                fFormat = FEnumConverter.toFormat(fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format));
                                // --
                                datlName = fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Name, FXmlTagHIT.D_Name);
                                datlPos = datlPositionKey[datlName];
                                // --
                                // 2018.04.06 by Jeff.Kim
                                // Data가 없을 경우 추가.
                                fXmlNodeDatl = null;
                                if (datlPositionData[datlName] != null && datlPositionData[datlName].count > 0)
                                {
                                    fXmlNodeDatl = datlPositionData[datlName][datlPos];
                                }                                
                                datlPos++;

                                //--

                                // ***
                                // 2017.03.23 by spike.lee
                                // Position 저장 위치 변경
                                // ***
                                datlPositionKey[datlName] = datlPos;

                                // --
                                // 2018.04.06 by Jeff.Kim
                                // Data가 없을 경우 Item gernerator 하지 않음
                                if (fXmlNodeDatl == null)
                                    continue;

                                // --

                                fXmlNodeHit2 = fXmlNodeParent.appendChild(fXmlNodeHit.clone(false));
                                fXmlNodeHit2.set_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));

                                // --

                                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                                {
                                    generateHostItemByDataLog(
                                        fScenarioData,
                                        fXmlNodeHit2,
                                        fXmlNodeHit.selectNodes(FXmlTagHIT.E_HostItem),
                                        gDatlPositionKey,
                                        gDatlPositionData,
                                        fXmlNodeDatl
                                        );
                                }
                                else if (fFormat == FFormat.Unknown)
                                {
                                    // ***
                                    // Unknown Host Item 복제
                                    // ***
                                    fXmlNodeSrc = fXmlNodeHit.clone(false);

                                    // --

                                    // ***
                                    // Host Item의 Format를 Data Log Format으로 설정
                                    // ***
                                    // --
                                    // ***
                                    // 2017.03.23 by spike.lee
                                    // fFormat를 fItemFormat으로 변경
                                    // ***
                                    fItemFormat = FEnumConverter.toFormat(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format));
                                    fXmlNodeHit2.set_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format, FEnumConverter.fromFormat(fItemFormat));

                                    // --

                                    if (fItemFormat == FFormat.List || fItemFormat == FFormat.AsciiList)
                                    {
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // 추가되는 fXmlNodeTgt Variable 속성을 Fixed로 변경
                                        // ***
                                        len = 0;
                                        xpath = FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_TargetType + "='" + FEnumConverter.fromDataTargetType(FDataTargetType.Item) + "']";
                                        foreach (FXmlNode x in fXmlNodeDatl.selectNodes(xpath))
                                        {
                                            fXmlNodeTgt = fXmlNodeSrc.clone(false);
                                            fXmlNodeTgt.set_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                                            fXmlNodeTgt.set_attrVal(
                                                FXmlTagHIT.A_Name,
                                                FXmlTagHIT.D_Name,
                                                x.get_attrVal(FXmlTagDATL.A_TargetItem, FXmlTagDATL.D_TargetItem)
                                                );
                                            // ***
                                            // fXmlNodeTgt = fXmlNodeHit.appendChild(fXmlNodeTgt);
                                            // ***
                                            // --
                                            generateHostItemByDataLog(
                                                fScenarioData,
                                                fXmlNodeHit2,
                                                fXmlNodeTgt.selectNodes("."),
                                                gDatlPositionKey,
                                                gDatlPositionData,
                                                x
                                                );
                                            // --
                                            len++;
                                        }
                                        // --
                                        fXmlNodeHit2.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, len.ToString());
                                    }
                                    else if (fItemFormat == FFormat.Raw)
                                    {
                                        fXmlNodeHit2.set_attrVal(
                                            FXmlTagHIT.A_Length,
                                            FXmlTagHIT.D_Length,
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length)
                                            );
                                    }
                                    else if (fItemFormat != FFormat.Unknown)
                                    {
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // fFormat를 fItemFormat으로 변경
                                        // ***
                                        len = int.Parse(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length));
                                        val = FValueConverter.toDataConversionStringValue(
                                            fItemFormat,
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value),
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression),
                                            ref len
                                            );
                                        // --
                                        fXmlNodeHit2.set_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value, val);
                                        fXmlNodeHit2.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, len.ToString());
                                    }
                                }
                                else if (fFormat == FFormat.Raw)
                                {
                                    len = calculateDataLogRawBytes(fXmlNodeDatl);
                                    fXmlNodeHit2.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, len.ToString());
                                }
                                else
                                {
                                    val = FValueConverter.toDataConversionStringValue(
                                        FEnumConverter.toFormat(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format)),
                                        fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value),
                                        fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                                        fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression)
                                        );
                                    // --
                                    len = 0;
                                    val = FValueConverter.convertStringValue(fFormat, val, out len);
                                    // --
                                    fXmlNodeHit2.set_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value, val);
                                    fXmlNodeHit2.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, len.ToString());
                                }
                            }   // for end
                        }   // for end

                        // --

                        // ***
                        // Parent가 Host Item일 경우 추가된 Variable Host Item 만큼 Length 증가
                        // ***
                        if (fXmlNodeParent.name == FXmlTagHIT.E_HostItem)
                        {
                            len = int.Parse(fXmlNodeParent.get_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length)) + ((varCnt - 1) * varLen);
                            fXmlNodeParent.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, len.ToString());
                        }

                        // --

                        index += varLen;

                        #endregion
                    }
                }   // while end
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeHit = null;
                fXmlNodeHit2 = null;
                fXmlNodeListDatl = null;
                fXmlNodeDatl = null;
                fXmlNodeSrc = null;
                fXmlNodeTgt = null;
                datlPositionKey = null;
                gDatlPositionData = null;
                varNameCount = null;
                fixNameCount = null;
            }
        }

        #endregion

        //-----------------------------------------------------------------------------------------------------------------------

        #region Respsitory Generation Methods

        public static FXmlNode generateRepository(
            FScenarioData fScenarioData, 
            FXmlNode fXmlNodeRps
            )
        {
            Dictionary<string, int> gDatlPositionKey = null;              // Data Log Name, Position
            Dictionary<string, FXmlNodeList> gDatlPositionData = null;    // Data Log Name, Data Log Node List 
            FXmlNode fXmlNodeRpsl = null;

            try
            {
                gDatlPositionKey = new Dictionary<string, int>();
                gDatlPositionData = new Dictionary<string, FXmlNodeList>();

                // --

                fXmlNodeRpsl = fXmlNodeRps.clone(false);
                // --
                generateColumnByDataLog(
                    fScenarioData,
                    fXmlNodeRpsl,
                    fXmlNodeRps.selectNodes(FXmlTagCOL.E_Column),
                    gDatlPositionKey,
                    gDatlPositionData,
                    null
                    );

                // --

                return fXmlNodeRpsl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                gDatlPositionKey = null;
                gDatlPositionData = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void generateRepositoryByPattern(
            FScenarioData fScenarioData, 
            FXmlNode fXmlNodeRps
            )
        {
            try
            {
                // ***
                // Pattern에 의한 Repository 생성
                // ***
                generateColumnByPattern(
                    fScenarioData, 
                    fXmlNodeRps, 
                    fXmlNodeRps.selectNodes(FXmlTagCOL.E_Column)
                    );
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

        private static void generateColumnByDataLog(
            FScenarioData fScenarioData,
            FXmlNode fXmlNodeParent,
            FXmlNodeList fXmlNodeListCol,
            Dictionary<string, int> gDatlPositionKey,
            Dictionary<string, FXmlNodeList> gDatlPositionData,
            FXmlNode fXmlNodeParentDatl
            )
        {
            FXmlNode fXmlNodeCol = null;
            FXmlNode fXmlNodeColl = null;
            FXmlNodeList fXmlNodeListDatl = null;
            FXmlNode fXmlNodeDatl = null;
            FXmlNode fXmlNodeSrc = null;
            FXmlNode fXmlNodeTgt = null;
            int colCount = 0;
            int index = 0;
            Dictionary<string, int> datlPositionKey = null;
            Dictionary<string, FXmlNodeList> datlPositionData = null;
            Dictionary<string, int> varNameCount = null;
            Dictionary<string, int> fixNameCount = null;
            int datlPos = 0;
            string datlName = string.Empty;
            FFormat fFormat;
            FPattern fPattern;
            int fixedLength = 0;
            FDataScanMode fScanMode;
            int fixLen = 0;
            int varLen = 0;
            int varCnt = 0;
            int calVarCnt = 0;
            string val = string.Empty;
            int len = 0;
            string xpath = string.Empty;
            FFormat fItemFormat;

            try
            {
                // ***
                // 동일한 이름의 Data Log가 사용된 회수를 보관하기 위한 Storage 생성
                // ***
                datlPositionKey = new Dictionary<string, int>();
                datlPositionData = new Dictionary<string, FXmlNodeList>();
                colCount = fXmlNodeListCol.count;

                // --

                while (index < colCount)
                {
                    fXmlNodeCol = fXmlNodeListCol[index];
                    fPattern = FEnumConverter.toPattern(fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Pattern, FXmlTagCOL.D_Pattern));
                    fFormat = FEnumConverter.toFormat(fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Format, FXmlTagCOL.D_Format));

                    // --

                    if (fPattern == FPattern.Fixed)
                    {
                        #region Fixed

                        fScanMode = FEnumConverter.toDataScanMode(fXmlNodeCol.get_attrVal(FXmlTagCOL.A_ScanMode, FXmlTagCOL.D_ScanMode));
                        datlName = fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Name, FXmlTagCOL.D_Name);
                        // --
                        if (fScanMode == FDataScanMode.Local)
                        {
                            if (datlPositionKey.ContainsKey(datlName))
                            {
                                datlPos = datlPositionKey[datlName];
                                fXmlNodeListDatl = datlPositionData[datlName];
                            }
                            else
                            {
                                datlPos = 0;
                                fXmlNodeListDatl = collectDataLogByLocalScan(fScenarioData, fXmlNodeParentDatl, FDataTargetType.Column, datlName);
                                // --
                                datlPositionKey.Add(datlName, datlPos);
                                datlPositionData.Add(datlName, fXmlNodeListDatl);
                            }
                        }
                        else
                        {
                            if (gDatlPositionKey.ContainsKey(datlName))
                            {
                                datlPos = gDatlPositionKey[datlName];
                                fXmlNodeListDatl = gDatlPositionData[datlName];
                            }
                            else
                            {
                                datlPos = 0;
                                fXmlNodeListDatl = collectDataLogByGlobalScan(fScenarioData, FDataTargetType.Column, datlName);
                                // --
                                gDatlPositionKey.Add(datlName, datlPos);
                                gDatlPositionData.Add(datlName, fXmlNodeListDatl);
                            }
                        }

                        // --

                        fixedLength = int.Parse(fXmlNodeCol.get_attrVal(FXmlTagCOL.A_FixedLength, FXmlTagCOL.D_FixedLength));
                        // --
                        for (int i = 0; i < fixedLength; i++)
                        {
                            fXmlNodeColl = fXmlNodeParent.appendChild(fXmlNodeCol.clone(false));
                            fXmlNodeColl.set_attrVal(FXmlTagCOLL.A_FixedLength, FXmlTagCOLL.D_FixedLength, "1");

                            // --

                            // ***
                            // Fixed일 경우 Data Log Position이 초과할 경우 다시 순환시킨다.
                            // ***
                            if (fXmlNodeListDatl.count == 0)
                            {
                                fXmlNodeDatl = null;
                            }
                            else
                            {
                                if (datlPos >= fXmlNodeListDatl.count)
                                {
                                    datlPos = 0; // 순환
                                }
                                fXmlNodeDatl = fXmlNodeListDatl[datlPos];
                                datlPos++;

                                // --

                                // ***
                                // 2017.03.23 by spike.lee
                                // Unknown Format에 List Format이 적용될 경우 Child 처리에 Position이 저장되지 않아 무한루프 도는 문제가 발생하여
                                // Position 저장 위치를 변경 함.
                                // *** 
                                if (fScanMode == FDataScanMode.Local)
                                {
                                    datlPositionKey[datlName] = datlPos;
                                }
                                else
                                {
                                    gDatlPositionKey[datlName] = datlPos;
                                }
                            }

                            // --

                            if (fXmlNodeDatl == null)
                            {
                                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                                {
                                    generateColumnByDataLog(
                                        fScenarioData,
                                        fXmlNodeColl,
                                        fXmlNodeCol.selectNodes(FXmlTagCOL.E_Column),
                                        gDatlPositionKey,
                                        gDatlPositionData,
                                        fXmlNodeParentDatl
                                        );
                                }
                            }
                            else
                            {
                                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                                {
                                    generateColumnByDataLog(
                                        fScenarioData,
                                        fXmlNodeColl,
                                        fXmlNodeCol.selectNodes(FXmlTagCOL.E_Column),
                                        gDatlPositionKey,
                                        gDatlPositionData,
                                        fXmlNodeDatl
                                        );
                                }
                                else if (fFormat == FFormat.Unknown)
                                {
                                    // ***
                                    // Unknown Column 복제
                                    // ***
                                    fXmlNodeSrc = fXmlNodeCol.clone(false);

                                    // --

                                    // ***
                                    // Column의 Format를 Data Log Format으로 설정
                                    // ***
                                    // --
                                    // ***
                                    // 2017.03.23 by spike.lee
                                    // fFormat를 fItemFormat으로 변경
                                    // ***
                                    fItemFormat = FEnumConverter.toFormat(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format));
                                    fXmlNodeColl.set_attrVal(FXmlTagCOLL.A_Format, FXmlTagCOLL.D_Format, FEnumConverter.fromFormat(fItemFormat));

                                    // --

                                    if (fItemFormat == FFormat.List || fItemFormat == FFormat.AsciiList)
                                    {
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // fXmlNodeTgt를 fXmlNodeDatl에 Append하고 generteDataLogBySecsItemLog에서 또 Append하여 Item이 2배 생성되는 문제 발생
                                        // ***
                                        len = 0;
                                        xpath = FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_TargetType + "='" + FEnumConverter.fromDataTargetType(FDataTargetType.Column) + "']";
                                        // --
                                        foreach (FXmlNode x in fXmlNodeDatl.selectNodes(xpath))
                                        {
                                            fXmlNodeTgt = fXmlNodeSrc.clone(false);
                                            fXmlNodeTgt.set_attrVal(FXmlTagCOLL.A_FixedLength, FXmlTagCOLL.D_FixedLength, "1");
                                            fXmlNodeTgt.set_attrVal(
                                                FXmlTagCOLL.A_Name,
                                                FXmlTagCOLL.D_Name,
                                                x.get_attrVal(FXmlTagDATL.A_TargetColumn, FXmlTagDATL.D_TargetColumn)
                                                );
                                            // ***
                                            // fXmlNodeTgt = fXmlNodeColl.appendChild(fXmlNodeTgt);
                                            // ***
                                            // --
                                            generateColumnByDataLog(
                                                fScenarioData,
                                                fXmlNodeColl,
                                                fXmlNodeTgt.selectNodes("."),
                                                gDatlPositionKey,
                                                gDatlPositionData,
                                                x
                                                );
                                            // --
                                            len++;
                                        }
                                        // --
                                        fXmlNodeColl.set_attrVal(FXmlTagCOLL.A_Length, FXmlTagCOLL.D_Length, len.ToString());
                                    }
                                    else if (fItemFormat == FFormat.Raw)
                                    {
                                        fXmlNodeColl.set_attrVal(
                                            FXmlTagCOLL.A_Length,
                                            FXmlTagCOLL.D_Length,
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length)
                                            );
                                    }
                                    else if (fItemFormat != FFormat.Unknown)
                                    {
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // fFormat를 fItemFormat으로 변경
                                        // ***
                                        len = int.Parse(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length));
                                        val = FValueConverter.toDataConversionStringValue(
                                            fItemFormat,
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value),
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression),
                                            ref len
                                            );
                                        // --
                                        fXmlNodeColl.set_attrVal(FXmlTagCOLL.A_Value, FXmlTagCOLL.D_Value, val);
                                        fXmlNodeColl.set_attrVal(FXmlTagCOLL.A_Length, FXmlTagCOLL.D_Length, len.ToString());
                                    }
                                }
                                else if (fFormat == FFormat.Raw)
                                {
                                    len = calculateDataLogRawBytes(fXmlNodeDatl);
                                    fXmlNodeColl.set_attrVal(FXmlTagCOLL.A_Length, FXmlTagCOLL.D_Length, len.ToString());
                                }
                                else
                                {
                                    val = FValueConverter.toDataConversionStringValue(
                                        FEnumConverter.toFormat(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format)),
                                        fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value),
                                        fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                                        fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression)
                                        );
                                    // --
                                    len = 0;
                                    val = FValueConverter.convertStringValue(fFormat, val, out len);
                                    // --
                                    fXmlNodeColl.set_attrVal(FXmlTagCOLL.A_Value, FXmlTagCOLL.D_Value, val);
                                    fXmlNodeColl.set_attrVal(FXmlTagCOLL.A_Length, FXmlTagCOLL.D_Length, len.ToString());
                                }
                            }
                        }   // fixedLength for end

                        // --

                        // ***
                        // Parent가 Column일 경우 Length 설정
                        // ***
                        if (fixedLength > 1 || fXmlNodeParent.name == FXmlTagCOLL.E_Column)
                        {
                            len = int.Parse(fXmlNodeParent.get_attrVal(FXmlTagCOLL.A_Length, FXmlTagCOLL.D_Length)) + fixedLength - 1;
                            fXmlNodeParent.set_attrVal(FXmlTagCOLL.A_Length, FXmlTagCOLL.D_Length, len.ToString());
                        }

                        // --

                        index++;

                        #endregion
                    }
                    else  // Variable
                    {
                        #region Variable

                        fixLen = 0;
                        varLen = 0;
                        varCnt = 0;
                        calVarCnt = 0;
                        // --
                        varNameCount = new Dictionary<string, int>();
                        fixNameCount = new Dictionary<string, int>();

                        // --

                        for (int i = index; i < colCount; i++)
                        {
                            fXmlNodeSrc = fXmlNodeListCol[i];

                            // --

                            // ***
                            // 1. Previous Column은 Fixed 형식으로 처리
                            // 2. Variable Column은 연속적으로 정의되어 있어 우선 처리
                            // 3. Next Column은 Variable Column 처리 이후 Fixed 형식으로 처리
                            // ***
                            fPattern = FEnumConverter.toPattern(fXmlNodeSrc.get_attrVal(FXmlTagCOLL.A_Pattern, FXmlTagCOLL.D_Pattern));
                            datlName = fXmlNodeSrc.get_attrVal(FXmlTagCOLL.A_Name, FXmlTagCOLL.A_Name);
                            // --
                            if (fPattern == FPattern.Variable)
                            {
                                if (varNameCount.ContainsKey(datlName))
                                {
                                    varNameCount[datlName] = varNameCount[datlName] + 1;
                                }
                                else
                                {
                                    varNameCount.Add(datlName, 1);
                                    fixNameCount.Add(datlName, 0);
                                }
                                varLen++;

                                // --

                                if (!datlPositionKey.ContainsKey(datlName))
                                {
                                    datlPositionKey.Add(datlName, 0);
                                    datlPositionData.Add(
                                        datlName, 
                                        collectDataLogByVariable(fScenarioData, fXmlNodeParentDatl, FDataTargetType.Column, datlName)
                                        );
                                }
                            }
                            else
                            {
                                // ***
                                // Scan Mode가 Global인 Column는 Variable 계산에 미포함
                                // ***
                                fScanMode = FEnumConverter.toDataScanMode(fXmlNodeSrc.get_attrVal(FXmlTagCOL.A_ScanMode, FXmlTagCOL.D_ScanMode));
                                if (fScanMode == FDataScanMode.Local && fixNameCount.ContainsKey(datlName))
                                {
                                    fixLen = int.Parse(fXmlNodeSrc.get_attrVal(FXmlTagCOL.A_FixedLength, FXmlTagCOL.D_FixedLength));
                                    fixNameCount[datlName] = fixNameCount[datlName] + fixLen;
                                }
                            }
                        }

                        // --

                        // ***
                        // Variable 회수 구하기 (Minimum)                        
                        // ***
                        foreach (string s in varNameCount.Keys)
                        {
                            calVarCnt = (datlPositionData[s].count - datlPositionKey[s] - fixNameCount[s]) / varNameCount[s];
                            if (calVarCnt < 1)
                            {
                                varCnt = 0;
                                break;
                            }
                            // --
                            if (varCnt == 0)
                            {
                                varCnt = calVarCnt;
                            }
                            else if (varCnt > calVarCnt)
                            {
                                varCnt = calVarCnt;
                            }
                        }

                        // --

                        for (int i = 0; i < varCnt; i++)
                        {
                            for (int j = 0; j < varLen; j++)
                            {
                                fXmlNodeCol = fXmlNodeListCol[index + j];
                                fFormat = FEnumConverter.toFormat(fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Format, FXmlTagCOL.D_Format));
                                // --
                                datlName = fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Name, FXmlTagCOL.D_Name);
                                datlPos = datlPositionKey[datlName];
                                fXmlNodeDatl = datlPositionData[datlName][datlPos];
                                datlPos++;

                                // --

                                // ***
                                // 2017.03.23 by spike.lee
                                // Position 저장 위치 변경
                                // ***
                                datlPositionKey[datlName] = datlPos;

                                // --

                                fXmlNodeColl = fXmlNodeParent.appendChild(fXmlNodeCol.clone(false));
                                fXmlNodeColl.set_attrVal(FXmlTagCOLL.A_Pattern, FXmlTagCOLL.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                                
                                // --

                                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                                {
                                    generateColumnByDataLog(
                                        fScenarioData,
                                        fXmlNodeColl,
                                        fXmlNodeCol.selectNodes(FXmlTagCOL.E_Column),
                                        gDatlPositionKey,
                                        gDatlPositionData,
                                        fXmlNodeDatl
                                        );
                                }
                                else if (fFormat == FFormat.Unknown)
                                {
                                    // ***
                                    // Unknown Column 복제
                                    // ***
                                    fXmlNodeSrc = fXmlNodeCol.clone(false);

                                    // --

                                    // ***
                                    // Column의 Format를 Data Log Format으로 설정
                                    // ***
                                    // --
                                    // ***
                                    // 2017.03.23 by spike.lee
                                    // fFormat를 fItemFormat으로 변경
                                    // ***
                                    fItemFormat = FEnumConverter.toFormat(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format));
                                    fXmlNodeColl.set_attrVal(FXmlTagCOLL.A_Format, FXmlTagCOLL.D_Format, FEnumConverter.fromFormat(fItemFormat));

                                    // --

                                    if (fItemFormat == FFormat.List || fItemFormat == FFormat.AsciiList)
                                    {
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // 추가되는 fXmlNodeTgt Variable 속성을 Fixed로 변경
                                        // ***
                                        len = 0;
                                        xpath = FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_TargetType + "='" + FEnumConverter.fromDataTargetType(FDataTargetType.Column) + "']";
                                        // --
                                        foreach (FXmlNode x in fXmlNodeDatl.selectNodes(xpath))
                                        {
                                            fXmlNodeTgt = fXmlNodeSrc.clone(false);
                                            fXmlNodeTgt.set_attrVal(FXmlTagCOLL.A_Pattern, FXmlTagCOLL.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                                            fXmlNodeTgt.set_attrVal(
                                                FXmlTagCOLL.A_Name,
                                                FXmlTagCOLL.D_Name,
                                                x.get_attrVal(FXmlTagDATL.A_TargetItem, FXmlTagDATL.D_TargetItem)
                                                );
                                            // ***
                                            // fXmlNodeTgt = fXmlNodeCol.appendChild(fXmlNodeTgt);
                                            // ***
                                            // --
                                            generateColumnByDataLog(
                                                fScenarioData,
                                                fXmlNodeColl,
                                                fXmlNodeTgt.selectNodes("."),
                                                gDatlPositionKey,
                                                gDatlPositionData,
                                                x
                                                );
                                            // --
                                            len++;
                                        }
                                        // --
                                        fXmlNodeColl.set_attrVal(FXmlTagCOLL.A_Length, FXmlTagCOLL.D_Length, len.ToString());
                                    }
                                    else if (fItemFormat == FFormat.Raw)
                                    {
                                        fXmlNodeColl.set_attrVal(
                                            FXmlTagCOLL.A_Length,
                                            FXmlTagCOLL.D_Length,
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length)
                                            );
                                    }
                                    else if (fItemFormat != FFormat.Unknown)
                                    {
                                        // ***
                                        // 2017.03.23 by spike.lee
                                        // fFormat를 fItemFormat으로 변경
                                        // ***
                                        len = int.Parse(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length));
                                        val = FValueConverter.toDataConversionStringValue(
                                            fItemFormat,
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value),
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression),
                                            ref len
                                            );
                                        // --
                                        fXmlNodeColl.set_attrVal(FXmlTagCOLL.A_Value, FXmlTagCOLL.D_Value, val);
                                        fXmlNodeColl.set_attrVal(FXmlTagCOLL.A_Length, FXmlTagCOLL.D_Length, len.ToString());
                                    }
                                }
                                else if (fFormat == FFormat.Raw)
                                {
                                    len = calculateDataLogRawBytes(fXmlNodeDatl);
                                    fXmlNodeColl.set_attrVal(FXmlTagCOLL.A_Length, FXmlTagCOLL.D_Length, len.ToString());
                                }
                                else
                                {
                                    val = FValueConverter.toDataConversionStringValue(
                                        FEnumConverter.toFormat(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format)),
                                        fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value),
                                        fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                                        fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression)
                                        );
                                    // --
                                    len = 0;
                                    val = FValueConverter.convertStringValue(fFormat, val, out len);
                                    // --
                                    fXmlNodeColl.set_attrVal(FXmlTagCOLL.A_Value, FXmlTagCOLL.D_Value, val);
                                    fXmlNodeColl.set_attrVal(FXmlTagCOLL.A_Length, FXmlTagCOLL.D_Length, len.ToString());
                                }
                            }   // for end
                        }   // for end

                        // --

                        // ***
                        // Parent가 Column일 경우 추가된 Variable Column 만큼 Length 증가
                        // ***
                        if (fXmlNodeParent.name == FXmlTagCOLL.E_Column)
                        {
                            len = int.Parse(fXmlNodeParent.get_attrVal(FXmlTagCOLL.A_Length, FXmlTagCOLL.D_Length)) + ((varCnt - 1) * varLen);
                            fXmlNodeParent.set_attrVal(FXmlTagCOLL.A_Length, FXmlTagCOLL.D_Length, len.ToString());
                        }

                        // --

                        index += varLen;

                        #endregion
                    }
                }   // while end
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeCol = null;
                fXmlNodeColl = null;
                fXmlNodeListDatl = null;
                fXmlNodeDatl = null;
                fXmlNodeSrc = null;
                fXmlNodeTgt = null;
                datlPositionKey = null;
                gDatlPositionData = null;
                varNameCount = null;
                fixNameCount = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void generateColumnByPattern(
            FScenarioData fScenarioData, 
            FXmlNode fXmlNodeParent, 
            FXmlNodeList fXmlNodeListCol
            )
        {
            FXmlNode fXmlNodeCol = null;
            FPattern fPattern;
            FFormat fFormat;
            int fixLen = 0;
            int len = 0;

            try
            {
                for (int i = 0; i < fXmlNodeListCol.count; i++)
                {
                    fXmlNodeCol = fXmlNodeListCol[i];
                    fPattern = FEnumConverter.toPattern(fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Pattern, FXmlTagCOL.D_Pattern));

                    // --

                    if (fPattern == FPattern.Fixed)
                    {
                        fFormat = FEnumConverter.toFormat(fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Format, FXmlTagCOL.D_Format));
                        fixLen = int.Parse(fXmlNodeCol.get_attrVal(FXmlTagCOL.A_FixedLength, FXmlTagCOL.D_FixedLength));

                        // --

                        if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                        {
                            generateColumnByPattern(
                                fScenarioData, 
                                fXmlNodeCol, 
                                fXmlNodeCol.selectNodes(FXmlTagCOL.E_Column)
                                );
                        }

                        // --

                        if (fixLen > 1)
                        {
                            fXmlNodeCol.set_attrVal(FXmlTagCOL.A_FixedLength, FXmlTagCOL.D_FixedLength, "1");

                            // --

                            for (int j = 1; j < fixLen; j++)
                            {
                                fXmlNodeCol = fXmlNodeParent.insertAfter(fXmlNodeCol.clone(true), fXmlNodeCol);    
                            }
                            
                            // --

                            // ***
                            // Parent가 FColumn인 경우 Length 추가
                            // ***
                            if (fXmlNodeParent.name == FXmlTagCOL.E_Column)
                            {
                                len = int.Parse(fXmlNodeParent.get_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length));
                                fXmlNodeParent.set_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length, (len + fixLen - 1).ToString());
                            }
                        }
                    }
                    else
                    {
                        fXmlNodeParent.removeChild(fXmlNodeCol);

                        // --

                        if (fXmlNodeParent.name == FXmlTagCOL.E_Column)
                        {
                            len = int.Parse(fXmlNodeParent.get_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length));
                            fXmlNodeParent.set_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length, (len - 1).ToString());
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
                fXmlNodeCol = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
