/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSearchNode.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.16
--  Description     : FAMate Core FaPlcDriver Search Node Class 
--  History         : Created by Jeff.Kim at 2013.07.16
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
    public static class FSearchNode
    {
        private static int m_stepCount = 0;
        private static bool m_isSearched = false;
        private static string m_lastSession = string.Empty;
        private static string m_flowId = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------       

        #region Properties
        
        public static string lastSession
        {
            get
            {
                try
                {                    
                    return m_lastSession;
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
        }

        //------------------------------------------------------------------------------------------------------------------------       

        public static string flowId
        {
            get
            {
                try
                {
                    return m_flowId;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------       

        #region Methods

        public static FXmlNode searchPlcLibraryNode(
           FXmlNode fXmlNode,
           FXmlNode fXmlNodeStart,
           FXmlNode fXmlNodeRoot,
           string searchWord
           )
        {
            FXmlNode fXmlNodeNext = null;
            FXmlNode fXmlNodeResult = null;

            FFormat fFormat;
            string originalStringValue = string.Empty;
            string originalEncodingValue = string.Empty;

            try
            {
                m_stepCount++;

                // --

                if (fXmlNode != null)
                {
                    if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagPLM.E_PlcLibraryModeling)
                    {

                    }
                    else if (fXmlNode.name == FXmlTagPLG.E_PlcLibraryGroup)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPLG.A_Name, FXmlTagPLG.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagPLB.E_PlcLibrary)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPLB.A_Name, FXmlTagPLB.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagPML.E_PlcMessageList)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPML.A_Name, FXmlTagPML.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagPMS.E_PlcMessages)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPMS.A_Name, FXmlTagPMS.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagPMG.E_PlcMessage)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPMG.A_Name, FXmlTagPMG.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagPBL.E_PlcBitList)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPBL.A_Name, FXmlTagPBL.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagPBT.E_PlcBit)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPBT.A_Name, FXmlTagPBT.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagPWL.E_PlcWordList)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPWL.A_Name, FXmlTagPWL.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagPWD.E_PlcWord)
                    {
                        fFormat = FEnumConverter.toFormat(fXmlNode.get_attrVal(FXmlTagPWD.A_Format, FXmlTagPWD.D_Format));
                        originalStringValue = fXmlNode.get_attrVal(FXmlTagPWD.A_Value, FXmlTagPWD.D_Value);
                        originalEncodingValue = toValue(fFormat, originalStringValue);

                        if (
                            contains(fXmlNode.get_attrVal(FXmlTagPWD.A_Name, FXmlTagPWD.D_Name), searchWord) ||
                            contains(originalEncodingValue, searchWord)
                            )
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }

                    // --

                    if (fXmlNode == fXmlNodeStart)
                    {
                        m_isSearched = true;
                    }

                    // --

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fFirstChild != null)
                    {
                        fXmlNodeResult = searchPlcLibraryNode(fXmlNode.fFirstChild, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }

                    // --

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fNextSibling != null)
                    {
                        fXmlNodeResult = searchPlcLibraryNode(fXmlNode.fNextSibling, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                // --

                m_stepCount--;

                // --

                if (m_stepCount == 0)
                {
                    if (fXmlNode != null)
                    {
                        fXmlNodeNext = getNextNode(fXmlNode, fXmlNodeRoot);
                    }

                    // --

                    if (fXmlNodeNext.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeNext = fXmlNodeRoot;
                    }

                    // --
                    if (fXmlNodeNext == fXmlNodeRoot)
                    {
                        if (
                            (fXmlNodeNext.fParentNode != null) &&
                            contains(fXmlNodeNext.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                            )
                        {
                            fXmlNodeResult = fXmlNodeNext.fParentNode;
                        }
                        else
                        {
                            fXmlNodeResult = searchPlcLibraryNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                        }
                    }
                    else if (fXmlNodeNext != null)
                    {
                        fXmlNodeResult = searchPlcLibraryNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                return fXmlNodeResult;
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

        public static FXmlNode searchPlcDeviceNode(
            FXmlNode fXmlNode,
            FXmlNode fXmlNodeStart,
            FXmlNode fXmlNodeRoot,
            string searchWord,
            string baseSessionId
            )
        {
            FXmlNode fXmlNodeNext = null;
            FXmlNode fXmlNodeResult = null;
            FXmlNode fXmlNodePlcDriver = null;
            FXmlNode fXmlNodePlcLibrary = null;
            FXmlNode fXmlNodeSession = null;
            string xpath = string.Empty;
            int stepCount = 0;

            try
            {
                m_stepCount++;

                // --

                if (fXmlNode != null)
                {
                    if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_lastSession = string.Empty;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagPDM.E_PlcDeviceModeling)
                    {
                        if (contains(fXmlNode.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode.fParentNode;
                            m_lastSession = string.Empty;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagPDV.E_PlcDevice)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPDV.A_Name, FXmlTagPDV.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_lastSession = string.Empty;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagPSN.E_PlcSession)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPSN.A_Name, FXmlTagPSN.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_lastSession = string.Empty;
                            m_isSearched = true;
                        }
                        else
                        {
                            fXmlNodePlcDriver = fXmlNodeRoot.fParentNode;

                            // --                            
                            fXmlNodeSession = fXmlNode;
                            m_lastSession = fXmlNodeSession.get_attrVal(FXmlTagPSN.A_UniqueId, FXmlTagPSN.D_UniqueId);
                            // --

                            xpath = FXmlTagPLM.E_PlcLibraryModeling + "//" + FXmlTagPLB.E_PlcLibrary +
                                "[@" + FXmlTagCommon.A_UniqueId + "='" + fXmlNodeSession.get_attrVal(FXmlTagPSN.A_PlcLibraryId, FXmlTagPSN.D_PlcLibraryId) + "']";
                            // --                            

                            fXmlNodePlcLibrary = fXmlNodePlcDriver.selectSingleNode(xpath);

                            // --

                            stepCount = m_stepCount;
                            m_stepCount = 0;

                            // --
                            if (
                                (fXmlNodePlcLibrary != null) &&
                                (fXmlNodePlcLibrary.fFirstChild != null)
                                )
                            {
                                fXmlNodeResult = searchPlcLibraryNode(fXmlNodePlcLibrary.fFirstChild, fXmlNodePlcLibrary, fXmlNodePlcLibrary, searchWord);
                            }

                            m_stepCount = stepCount;

                            // --

                            if (fXmlNodeResult == null)
                            {
                                m_isSearched = false;
                            }

                            // --

                            if (m_isSearched)
                            {
                                return fXmlNodeResult;
                            }

                            // --

                            if (
                                (fXmlNodeSession != null) &&
                                (fXmlNodeSession.fNextSibling != null)
                                )
                            {
                                fXmlNode = fXmlNodeSession;
                            }

                            // --

                            if (fXmlNodeResult == fXmlNodePlcLibrary)
                            {
                                fXmlNodeResult = null;
                            }
                        }
                    }
                    else if (
                        fXmlNode.name == FXmlTagPLB.E_PlcLibrary ||
                        fXmlNode.name == FXmlTagPML.E_PlcMessageList ||
                        fXmlNode.name == FXmlTagPMS.E_PlcMessages ||
                        fXmlNode.name == FXmlTagPMG.E_PlcMessage ||
                        fXmlNode.name == FXmlTagPBL.E_PlcBitList ||
                        fXmlNode.name == FXmlTagPBT.E_PlcBit ||
                        fXmlNode.name == FXmlTagPWL.E_PlcWordList ||
                        fXmlNode.name == FXmlTagPWD.E_PlcWord
                        )
                    {
                        fXmlNodePlcDriver = fXmlNodeRoot.fParentNode;

                        // --

                        xpath = "//" + FXmlTagPSN.E_PlcSession + "[@" + FXmlTagPSN.A_UniqueId + "='" + baseSessionId + "']";
                        fXmlNodeSession = fXmlNodeRoot.selectSingleNode(xpath);
                        m_lastSession = fXmlNodeSession.get_attrVal(FXmlTagPSN.A_UniqueId, FXmlTagPSN.D_UniqueId);

                        // --

                        xpath = FXmlTagPLM.E_PlcLibraryModeling + "//" + FXmlTagPLB.E_PlcLibrary +
                            "[@" + FXmlTagCommon.A_UniqueId + "='" + fXmlNodeSession.get_attrVal(FXmlTagPSN.A_PlcLibraryId, FXmlTagPSN.D_PlcLibraryId) + "']";

                        // --                            

                        fXmlNodePlcLibrary = fXmlNodePlcDriver.selectSingleNode(xpath);

                        // --

                        stepCount = m_stepCount;
                        m_stepCount = 0;
                        // --
                        if (
                            (fXmlNodeSession != null) &&
                            (fXmlNode.fFirstChild != null)
                            )
                        {
                            fXmlNodeResult = searchPlcLibraryNode(fXmlNode, fXmlNodePlcLibrary, fXmlNodePlcLibrary, searchWord);
                        }
                        else
                        {
                            if (fXmlNode.name == FXmlTagPML.E_PlcMessageList)
                            {
                                xpath = "//*[@" + FXmlTagCommon.A_UniqueId + "=" + fXmlNode.get_attrVal(FXmlTagCommon.A_UniqueId, FXmlTagCommon.D_UniqueId) + "]";
                            }
                            else
                            {
                                xpath = "*//*[@" + FXmlTagCommon.A_UniqueId + "=" + fXmlNode.get_attrVal(FXmlTagCommon.A_UniqueId, FXmlTagCommon.D_UniqueId) + "]";
                            }

                            // --

                            if (fXmlNodePlcLibrary.selectSingleNode(xpath) != null)
                            {
                                fXmlNodeResult = searchPlcLibraryNode(fXmlNode, fXmlNodePlcLibrary, fXmlNodePlcLibrary, searchWord);
                            }
                        }
                        m_stepCount = stepCount;
                        // --

                        if (fXmlNodeResult == null)
                        {
                            m_isSearched = false;
                        }

                        // --

                        if (m_isSearched)
                        {
                            return fXmlNodeResult;
                        }

                        // --

                        fXmlNode = fXmlNodeSession;

                        // --

                        if (fXmlNodeResult == fXmlNodePlcLibrary)
                        {
                            fXmlNodeResult = null;
                        }
                    }
                    else
                    {
                        fXmlNodePlcDriver = fXmlNodeRoot.fParentNode;

                        // --        
                        xpath = "//" + FXmlTagPSN.E_PlcSession + "[@" + FXmlTagPSN.A_UniqueId + "='" + baseSessionId + "']";
                        fXmlNodeSession = fXmlNodeRoot.selectSingleNode(xpath);
                        m_lastSession = fXmlNodeSession.get_attrVal(FXmlTagPSN.A_UniqueId, FXmlTagPSN.D_UniqueId);

                        // --
                        fXmlNode = fXmlNodeSession;
                    }

                    // --

                    if (
                        fXmlNode == fXmlNodeStart &&
                        (fXmlNode.name != FXmlTagPSN.E_PlcSession)
                        )
                    {
                        m_isSearched = true;
                    }

                    // --

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fFirstChild != null)
                    {
                        fXmlNodeResult = searchPlcDeviceNode(fXmlNode.fFirstChild, fXmlNodeStart, fXmlNodeRoot, searchWord, baseSessionId);
                    }

                    // --

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    if (fXmlNode.fNextSibling != null)
                    {
                        fXmlNodeResult = searchPlcDeviceNode(fXmlNode.fNextSibling, fXmlNodeStart, fXmlNodeRoot, searchWord, baseSessionId);
                    }
                }

                // --

                m_stepCount--;

                // --

                if (m_stepCount == 0)
                {
                    if (fXmlNode != null)
                    {
                        fXmlNodeNext = getNextNode(fXmlNode, fXmlNodeRoot);
                    }

                    // --                   

                    if (fXmlNodeNext != null)
                    {
                        if (fXmlNodeNext.fPreviousSibling == fXmlNodeRoot)
                        {
                            fXmlNodeNext = fXmlNodeRoot;
                        }

                        // --

                        if (fXmlNodeNext == fXmlNodeRoot)
                        {
                            if (
                                fXmlNodeNext.fParentNode != null &&
                                contains(fXmlNodeNext.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                                )
                            {
                                m_lastSession = string.Empty;
                                fXmlNodeResult = fXmlNodeNext.fParentNode;
                            }
                            else
                            {
                                fXmlNodeResult = searchPlcDeviceNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord, baseSessionId);
                            }
                        }
                        else if (fXmlNodeNext != null)
                        {
                            fXmlNodeResult = searchPlcDeviceNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord, baseSessionId);
                        }
                    }
                    else if (
                        fXmlNodeNext == null &&
                        contains(fXmlNodeRoot.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                        )
                    {
                        fXmlNodeResult = fXmlNodeRoot.fParentNode;
                        m_isSearched = true;
                        m_lastSession = string.Empty;
                    }
                }

                return fXmlNodeResult;
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

        public static FXmlNode searchHostLibraryNode(
           FXmlNode fXmlNode,
           FXmlNode fXmlNodeStart,
           FXmlNode fXmlNodeRoot,
           string searchWord
           )
        {
            FXmlNode fXmlNodeNext = null;
            FXmlNode fXmlNodeResult = null;
            
            FFormat fFormat;
            string originalStringValue = string.Empty;
            string originalEncodingValue = string.Empty;

            try
            {
                m_stepCount++;

                // --

                if (fXmlNode != null)
                {
                    if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagHLM.E_HostLibraryModeling)
                    {

                    }
                    else if (fXmlNode.name == FXmlTagHLG.E_HostLibraryGroup)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagHLG.A_Name, FXmlTagHLG.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagHLB.E_HostLibrary)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagHLB.A_Name, FXmlTagHLB.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagHML.E_HostMessageList)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagHML.A_Name, FXmlTagHML.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagHMS.E_HostMessages)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagHMS.A_Name, FXmlTagHMS.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagHMG.E_HostMessage)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagHMG.A_Name, FXmlTagHMG.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagHIT.E_HostItem)
                    {
                        fFormat = FEnumConverter.toFormat(fXmlNode.get_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format));
                        originalStringValue = fXmlNode.get_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value);
                        originalEncodingValue = toValue(fFormat, originalStringValue);

                        if (
                            contains(fXmlNode.get_attrVal(FXmlTagHIT.A_Name, FXmlTagHIT.D_Name), searchWord) ||
                            contains(originalEncodingValue, searchWord)
                            )
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }                        
                    }

                    // --

                    if (fXmlNode == fXmlNodeStart)
                    {
                        m_isSearched = true;
                    }

                    // --

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fFirstChild != null)
                    {
                        fXmlNodeResult = searchHostLibraryNode(fXmlNode.fFirstChild, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }

                    // --

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fNextSibling != null)
                    {
                        fXmlNodeResult = searchHostLibraryNode(fXmlNode.fNextSibling, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                // --

                m_stepCount--;

                // --

                if (m_stepCount == 0)
                {
                    if (fXmlNode != null)
                    {
                        fXmlNodeNext = getNextNode(fXmlNode, fXmlNodeRoot);
                    }

                    // --

                    if (fXmlNodeNext.fPreviousSibling == fXmlNodeRoot)
                    {                        
                        fXmlNodeNext = fXmlNodeRoot;
                    }

                    // --
                    if (fXmlNodeNext == fXmlNodeRoot)
                    {
                        if (
                            (fXmlNodeNext.fParentNode != null) &&
                            contains(fXmlNodeNext.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                            )
                        {
                            fXmlNodeResult = fXmlNodeNext.fParentNode;
                        }
                        else
                        {
                            fXmlNodeResult = searchHostLibraryNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                        }
                    }
                    else if (fXmlNodeNext != null)
                    {
                        fXmlNodeResult = searchHostLibraryNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                return fXmlNodeResult;
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

        public static FXmlNode searchHostDeviceNode(
            FXmlNode fXmlNode,
            FXmlNode fXmlNodeStart,
            FXmlNode fXmlNodeRoot,
            string searchWord,
            string baseSessionId
            )
        {
            FXmlNode fXmlNodeNext = null;
            FXmlNode fXmlNodeResult = null;
            FXmlNode fXmlNodeSecsDriver = null;
            FXmlNode fXmlNodeHostLibrary = null;
            FXmlNode fXmlNodeSession = null;
            string xpath = string.Empty;
            int stepCount = 0;

            try
            {
                m_stepCount++;

                // --

                if (fXmlNode != null)
                {
                    if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_lastSession = string.Empty;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagHDM.E_HostDeviceModeling)
                    {
                        // ***
                        // HostDeviceModeling Element의 경우 실질적으로 Modeler에서 표현되지 않기 때문에 
                        // HostDeviceModeling Element의 Parent(SecsDriver)를 검사
                        // Modified by kt.Kim
                        // ***
                        if (contains(fXmlNode.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode.fParentNode;
                            m_lastSession = string.Empty;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagHDV.E_HostDevice)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagHDV.A_Name, FXmlTagHDV.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_lastSession = string.Empty;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagHSN.E_HostSession)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagHSN.A_Name, FXmlTagHSN.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_lastSession = string.Empty;
                            m_isSearched = true;
                        }
                        else
                        {
                            fXmlNodeSecsDriver = fXmlNodeRoot.fParentNode;

                            // --                            
                            fXmlNodeSession = fXmlNode;
                            m_lastSession = fXmlNodeSession.get_attrVal(FXmlTagHSN.A_UniqueId, FXmlTagHSN.D_UniqueId);
                            // --

                            xpath = FXmlTagHLM.E_HostLibraryModeling + "//" + FXmlTagHLB.E_HostLibrary +
                                "[@" + FXmlTagCommon.A_UniqueId + "='" + fXmlNodeSession.get_attrVal(FXmlTagHSN.A_HostLibraryId, FXmlTagHSN.D_HostLibraryId) + "']";
                            // --                            

                            fXmlNodeHostLibrary = fXmlNodeSecsDriver.selectSingleNode(xpath);

                            // --

                            stepCount = m_stepCount;
                            m_stepCount = 0;

                            // --
                            if (
                                (fXmlNodeHostLibrary != null) &&
                                (fXmlNodeHostLibrary.fFirstChild != null)
                                )
                            {
                                fXmlNodeResult = searchHostLibraryNode(fXmlNodeHostLibrary.fFirstChild, fXmlNodeHostLibrary, fXmlNodeHostLibrary, searchWord);
                            }

                            m_stepCount = stepCount;
                            
                            // --

                            if (fXmlNodeResult == null)
                            {
                                m_isSearched = false;
                            }

                            // --

                            if (m_isSearched)
                            {
                                return fXmlNodeResult;
                            }

                            // --

                            if (
                                (fXmlNodeSession != null) &&
                                (fXmlNodeSession.fNextSibling != null)
                                )
                            {
                                fXmlNode = fXmlNodeSession;
                            }

                            // --

                            if (fXmlNodeResult == fXmlNodeHostLibrary)
                            {
                                fXmlNodeResult = null;
                            }
                        }
                    }
                    else if (
                        fXmlNode.name == FXmlTagHLB.E_HostLibrary ||
                        fXmlNode.name == FXmlTagHML.E_HostMessageList ||
                        fXmlNode.name == FXmlTagHMS.E_HostMessages ||
                        fXmlNode.name == FXmlTagHMG.E_HostMessage ||
                        fXmlNode.name == FXmlTagHIT.E_HostItem
                        )
                    {
                        fXmlNodeSecsDriver = fXmlNodeRoot.fParentNode;

                        // --

                        xpath = "//" + FXmlTagHSN.E_HostSession + "[@" + FXmlTagHSN.A_UniqueId + "='" + baseSessionId + "']";
                        fXmlNodeSession = fXmlNodeRoot.selectSingleNode(xpath);
                        m_lastSession = fXmlNodeSession.get_attrVal(FXmlTagHSN.A_UniqueId, FXmlTagHSN.D_UniqueId);

                        // --

                        xpath = FXmlTagHLM.E_HostLibraryModeling + "//" + FXmlTagHLB.E_HostLibrary +
                            "[@" + FXmlTagCommon.A_UniqueId + "='" + fXmlNodeSession.get_attrVal(FXmlTagHSN.A_HostLibraryId, FXmlTagHSN.D_HostLibraryId) + "']";

                        // --                            

                        fXmlNodeHostLibrary = fXmlNodeSecsDriver.selectSingleNode(xpath);

                        // --

                        stepCount = m_stepCount;
                        m_stepCount = 0;
                        // --
                        if (
                            (fXmlNodeSession != null) &&
                            (fXmlNode.fFirstChild != null)
                            )
                        {
                            fXmlNodeResult = searchHostLibraryNode(fXmlNode, fXmlNodeHostLibrary, fXmlNodeHostLibrary, searchWord);
                        }
                        else
                        {
                            if (fXmlNode.name == FXmlTagHML.E_HostMessageList)
                            {
                                xpath = "//*[@" + FXmlTagCommon.A_UniqueId + "=" + fXmlNode.get_attrVal(FXmlTagCommon.A_UniqueId, FXmlTagCommon.D_UniqueId) + "]";
                            }
                            else
                            {
                                xpath = "*//*[@" + FXmlTagCommon.A_UniqueId + "=" + fXmlNode.get_attrVal(FXmlTagCommon.A_UniqueId, FXmlTagCommon.D_UniqueId) + "]";
                            }

                            // --

                            if (fXmlNodeHostLibrary.selectSingleNode(xpath) != null)
                            {
                                fXmlNodeResult = searchHostLibraryNode(fXmlNode, fXmlNodeHostLibrary, fXmlNodeHostLibrary, searchWord);
                            }
                        }
                        m_stepCount = stepCount;
                        // --

                        if (fXmlNodeResult == null)
                        {
                            m_isSearched = false;
                        }

                        // --

                        if (m_isSearched)
                        {
                            return fXmlNodeResult;
                        }

                        // --

                        fXmlNode = fXmlNodeSession;

                        // --

                        if (fXmlNodeResult == fXmlNodeHostLibrary)
                        {
                            fXmlNodeResult = null;
                        }
                    }
                    else
                    {
                        fXmlNodeSecsDriver = fXmlNodeRoot.fParentNode;

                        // --        
                        xpath = "//" + FXmlTagHSN.E_HostSession + "[@" + FXmlTagHSN.A_UniqueId + "='" + baseSessionId + "']";
                        fXmlNodeSession = fXmlNodeRoot.selectSingleNode(xpath);
                        m_lastSession = fXmlNodeSession.get_attrVal(FXmlTagHSN.A_UniqueId, FXmlTagHSN.D_UniqueId);
                        
                        // --
                        fXmlNode = fXmlNodeSession;
                    }

                    // --
                    
                    if (
                        fXmlNode == fXmlNodeStart &&
                        (fXmlNode.name != FXmlTagHSN.E_HostSession)
                        )
                    {
                        m_isSearched = true;
                    }
                    
                    // --

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fFirstChild != null)
                    {
                        fXmlNodeResult = searchHostDeviceNode(fXmlNode.fFirstChild, fXmlNodeStart, fXmlNodeRoot, searchWord, baseSessionId);
                    }

                    // --

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    if (fXmlNode.fNextSibling != null)
                    {
                        fXmlNodeResult = searchHostDeviceNode(fXmlNode.fNextSibling, fXmlNodeStart, fXmlNodeRoot, searchWord, baseSessionId);
                    }
                }

                // --

                m_stepCount--;

                // --

                if (m_stepCount == 0)
                {
                    if (fXmlNode != null)
                    {
                        fXmlNodeNext = getNextNode(fXmlNode, fXmlNodeRoot);
                    }

                    // --                   

                    if (fXmlNodeNext != null)
                    {
                        if (fXmlNodeNext.fPreviousSibling == fXmlNodeRoot)
                        {
                            fXmlNodeNext = fXmlNodeRoot;
                        }

                        // --

                        if (fXmlNodeNext == fXmlNodeRoot)
                        {
                            if (
                                fXmlNodeNext.fParentNode != null &&
                                contains(fXmlNodeNext.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                                )
                            {
                                m_lastSession = string.Empty;
                                fXmlNodeResult = fXmlNodeNext.fParentNode;
                            }
                            else
                            {
                                fXmlNodeResult = searchHostDeviceNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord, baseSessionId);
                            }
                        }
                        else if (fXmlNodeNext != null)
                        {
                            fXmlNodeResult = searchHostDeviceNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord, baseSessionId);
                        }
                    }
                    else if (
                        fXmlNodeNext == null &&
                        contains(fXmlNodeRoot.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                        )
                    {
                        fXmlNodeResult = fXmlNodeRoot.fParentNode;
                        m_isSearched = true;
                        m_lastSession = string.Empty;
                    }
                }
                
                return fXmlNodeResult;
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

        public static FXmlNode searchRepositoryNode(
            FXmlNode fXmlNode,
            FXmlNode fXmlNodeStart,
            FXmlNode fXmlNodeRoot,
            string searchWord
            )
        {
            FXmlNode fXmlNodeNext = null;
            FXmlNode fXmlNodeResult = null;
            FFormat fFormat;
            // --
            string originalStringValue;
            string originalEncodingValue;

            try
            {
                m_stepCount++;

                // --

                if (fXmlNode != null)
                {
                    if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagRPD.E_RepositoryDefinition)
                    {

                    }
                    else if (fXmlNode.name == FXmlTagRPL.E_RepositoryList)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagRPL.A_Name, FXmlTagRPL.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagRPS.E_Repository)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagRPS.A_Name, FXmlTagRPS.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagCOL.E_Column)
                    {
                        fFormat = FEnumConverter.toFormat(fXmlNode.get_attrVal(FXmlTagCOL.A_Format, FXmlTagCOL.D_Format));
                        originalStringValue = fXmlNode.get_attrVal(FXmlTagCOL.A_Value, FXmlTagCOL.D_Value);
                        originalEncodingValue = toValue(fFormat, originalStringValue);

                        if (
                            contains(fXmlNode.get_attrVal(FXmlTagCOL.A_Name, FXmlTagCOL.D_Name), searchWord) ||
                            contains(originalEncodingValue, searchWord)
                            )
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }

                    // --

                    if (fXmlNode == fXmlNodeStart)
                    {
                        m_isSearched = true;
                    }

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fFirstChild != null)
                    {
                        fXmlNodeResult = searchRepositoryNode(fXmlNode.fFirstChild, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }

                    // --

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fNextSibling != null)
                    {
                        fXmlNodeResult = searchRepositoryNode(fXmlNode.fNextSibling, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                // --

                m_stepCount--;

                // --

                if (m_stepCount == 0)
                {
                    if (fXmlNode != null)
                    {
                        fXmlNodeNext = getNextNode(fXmlNode, fXmlNodeRoot);
                    }

                    // --

                    if (fXmlNodeNext.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeNext = fXmlNodeRoot;
                    }

                    // --
                    if (fXmlNodeNext == fXmlNodeRoot)
                    {
                        if (
                            fXmlNodeNext.fParentNode.fParentNode != null &&
                            contains(fXmlNodeNext.fParentNode.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                            )
                        {
                            fXmlNodeResult = fXmlNodeNext.fParentNode.fParentNode;
                        }
                        else
                        {
                            fXmlNodeResult = searchRepositoryNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                        }
                    }
                    else if (fXmlNodeNext != null)
                    {
                        fXmlNodeResult = searchRepositoryNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                return fXmlNodeResult;
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

        public static FXmlNode searchEquipmentNode(
            FXmlNode fXmlNode,
            FXmlNode fXmlNodeStart,
            FXmlNode fXmlNodeRoot,
            string searchWord
            )
        {
            FXmlNode fXmlNodeNext = null;
            FXmlNode fXmlNodeResult = null;

            try
            {
                m_stepCount++;

                // --

                if (fXmlNode != null)
                {
                    if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagEQM.E_EquipmentModeling)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagEQP.E_Equipment)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagEQP.A_Name, FXmlTagEQP.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagSNG.E_ScenarioGroup)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagSNG.A_Name, FXmlTagSNG.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagSNR.E_Scenario)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagSNR.A_Name, FXmlTagSNR.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }

                    // --

                    if (fXmlNode == fXmlNodeStart)
                    {
                        m_isSearched = true;
                    }

                    // --

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (
                        (fXmlNode.fFirstChild != null) &&
                        (fXmlNode.name != FXmlTagSNR.E_Scenario)
                        )
                    {
                        fXmlNodeResult = searchEquipmentNode(fXmlNode.fFirstChild, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }

                    // --

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fNextSibling != null)
                    {
                        fXmlNodeResult = searchEquipmentNode(fXmlNode.fNextSibling, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                // --

                m_stepCount--;

                // --

                if (m_stepCount == 0)
                {
                    fXmlNodeNext = getNextNode(fXmlNode, fXmlNodeRoot);

                    // --

                    if (fXmlNodeNext.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeNext = fXmlNodeRoot;
                    }

                    // --
                    if (fXmlNodeNext == fXmlNodeRoot)
                    {
                        if (
                            (fXmlNodeNext.fParentNode != null) &&
                            contains(fXmlNodeNext.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                            )
                        {
                            fXmlNodeResult = fXmlNodeNext.fParentNode;
                        }
                        else
                        {
                            fXmlNodeResult = searchEquipmentNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                        }
                    }
                    else if (
                        (fXmlNodeNext != null) &&
                        (fXmlNodeNext.name != FXmlTagEQM.E_EquipmentModeling)
                        )
                    {
                        fXmlNodeResult = searchEquipmentNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                return fXmlNodeResult;
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

        public static FXmlNode searchObjectNameNode(
            FXmlNode fXmlNode,
            FXmlNode fXmlNodeStart,
            FXmlNode fXmlNodeRoot,
            string searchWord
            )
        {
            FXmlNode fXmlNodeNext = null;
            FXmlNode fXmlNodeResult = null;

            try
            {
                m_stepCount++;

                // --

                if (fXmlNode != null)
                {
                    if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagOND.E_ObjectNameDefinition)
                    {

                    }
                    else if (fXmlNode.name == FXmlTagONL.E_ObjectNameList)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagONL.A_Name, FXmlTagONL.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagONA.E_ObjectName)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagONA.A_Name, FXmlTagONA.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }                   

                    // --

                    if (fXmlNode == fXmlNodeStart)
                    {
                        m_isSearched = true;
                    }

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fFirstChild != null)
                    {
                        fXmlNodeResult = searchObjectNameNode(fXmlNode.fFirstChild, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }

                    // --

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fNextSibling != null)
                    {
                        fXmlNodeResult = searchObjectNameNode(fXmlNode.fNextSibling, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                // --

                m_stepCount--;

                // --

                if (m_stepCount == 0)
                {
                    if (fXmlNode != null)
                    {
                        fXmlNodeNext = getNextNode(fXmlNode, fXmlNodeRoot);
                    }

                    // --

                    if (fXmlNodeNext.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeNext = fXmlNodeRoot;
                    }

                    // --
                    if (fXmlNodeNext == fXmlNodeRoot)
                    {
                        if (
                            fXmlNodeNext.fParentNode.fParentNode != null &&
                            contains(fXmlNodeNext.fParentNode.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                            )
                        {
                            fXmlNodeResult = fXmlNodeNext.fParentNode.fParentNode;
                        }
                        else
                        {
                            fXmlNodeResult = searchObjectNameNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                        }
                    }
                    else if (fXmlNodeNext != null)
                    {
                        fXmlNodeResult = searchObjectNameNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                return fXmlNodeResult;
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

        public static FXmlNode searchFunctionNameNode(
            FXmlNode fXmlNode,
            FXmlNode fXmlNodeStart,
            FXmlNode fXmlNodeRoot,
            string searchWord
            )
        {
            FXmlNode fXmlNodeNext = null;
            FXmlNode fXmlNodeResult = null;
       
            try
            {
                m_stepCount++;

                // --

                if (fXmlNode != null)
                {
                    if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagFND.E_FunctionNameDefinition)
                    {

                    }
                    else if (fXmlNode.name == FXmlTagFNL.E_FunctionNameList)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagFNL.A_Name, FXmlTagFNL.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagFNA.E_FunctionName)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagFNA.A_Name, FXmlTagFNA.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagPAN.E_ParameterName)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPAN.A_Name, FXmlTagPAN.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagARG.E_Argument)
                    {               
                        if (contains(fXmlNode.get_attrVal(FXmlTagARG.A_Name, FXmlTagARG.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }

                    // --

                    if (fXmlNode == fXmlNodeStart)
                    {
                        m_isSearched = true;
                    }

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fFirstChild != null)
                    {
                        fXmlNodeResult = searchFunctionNameNode(fXmlNode.fFirstChild, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }

                    // --

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fNextSibling != null)
                    {
                        fXmlNodeResult = searchFunctionNameNode(fXmlNode.fNextSibling, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                // --

                m_stepCount--;

                // --

                if (m_stepCount == 0)
                {
                    if (fXmlNode != null)
                    {
                        fXmlNodeNext = getNextNode(fXmlNode, fXmlNodeRoot);
                    }

                    // --

                    if (fXmlNodeNext.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeNext = fXmlNodeRoot;
                    }

                    // --
                    if (fXmlNodeNext == fXmlNodeRoot)
                    {
                        if (
                            fXmlNodeNext.fParentNode.fParentNode != null &&
                            contains(fXmlNodeNext.fParentNode.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                            )
                        {
                            fXmlNodeResult = fXmlNodeNext.fParentNode.fParentNode;
                        }
                        else
                        {
                            fXmlNodeResult = searchFunctionNameNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                        }
                    }
                    else if (fXmlNodeNext != null)
                    {
                        fXmlNodeResult = searchFunctionNameNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                return fXmlNodeResult;
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

        public static FXmlNode searchDataConversionNode(
            FXmlNode fXmlNode,
            FXmlNode fXmlNodeStart,
            FXmlNode fXmlNodeRoot,
            string searchWord
            )
        {
            FXmlNode fXmlNodeNext = null;
            FXmlNode fXmlNodeResult = null;

            try
            {
                m_stepCount++;

                // --

                if (fXmlNode != null)
                {
                    if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagDCD.E_DataConversionSetDefinition)
                    {

                    }
                    else if (fXmlNode.name == FXmlTagDCL.E_DataConversionSetList)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagDCL.A_Name, FXmlTagDCL.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagDCS.E_DataConversionSet)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagDCS.A_Name, FXmlTagDCS.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagDCV.E_DataConversion)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagDCV.A_Name, FXmlTagDCV.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }

                    // --

                    if (fXmlNode == fXmlNodeStart)
                    {
                        m_isSearched = true;
                    }

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fFirstChild != null)
                    {
                        fXmlNodeResult = searchDataConversionNode(fXmlNode.fFirstChild, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }

                    // --

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fNextSibling != null)
                    {
                        fXmlNodeResult = searchDataConversionNode(fXmlNode.fNextSibling, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                // --

                m_stepCount--;

                // --

                if (m_stepCount == 0)
                {
                    if (fXmlNode != null)
                    {
                        fXmlNodeNext = getNextNode(fXmlNode, fXmlNodeRoot);
                    }

                    // --

                    if (fXmlNodeNext.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeNext = fXmlNodeRoot;
                    }

                    // --
                    if (fXmlNodeNext == fXmlNodeRoot)
                    {
                        if (
                            fXmlNodeNext.fParentNode.fParentNode != null &&
                            contains(fXmlNodeNext.fParentNode.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                            )
                        {
                            fXmlNodeResult = fXmlNodeNext.fParentNode.fParentNode;
                        }
                        else
                        {
                            fXmlNodeResult = searchDataConversionNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                        }
                    }
                    else if (fXmlNodeNext != null)
                    {
                        fXmlNodeResult = searchDataConversionNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                return fXmlNodeResult;
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

        public static FXmlNode searchDataSetNode(
            FXmlNode fXmlNode,
            FXmlNode fXmlNodeStart,
            FXmlNode fXmlNodeRoot,
            string searchWord
            )
        {
            FXmlNode fXmlNodeNext = null;
            FXmlNode fXmlNodeResult = null;
            FFormat fFormat;
            // --
            string originalStringValue;
            string originalEncodingValue;

            try
            {
                m_stepCount++;

                // --

                if (fXmlNode != null)
                {
                    if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagDSD.E_DataSetDefinition)
                    {

                    }
                    else if (fXmlNode.name == FXmlTagDSL.E_DataSetList)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagDSL.A_Name, FXmlTagDSL.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagDTS.E_DataSet)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagDTS.A_Name, FXmlTagDTS.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagDAT.E_Data)
                    {
                        fFormat = FEnumConverter.toFormat(fXmlNode.get_attrVal(FXmlTagDAT.A_Format, FXmlTagDAT.D_Format));
                        originalStringValue = fXmlNode.get_attrVal(FXmlTagDAT.A_Value, FXmlTagDAT.D_Value);
                        originalEncodingValue = toValue(fFormat, originalStringValue);
                        // --
                        if (
                            contains(fXmlNode.get_attrVal(FXmlTagDAT.A_Name, FXmlTagDAT.D_Name), searchWord) ||
                            contains(originalEncodingValue, searchWord)
                            )
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }

                    // --

                    if (fXmlNode == fXmlNodeStart)
                    {
                        m_isSearched = true;
                    }

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fFirstChild != null)
                    {
                        fXmlNodeResult = searchDataSetNode(fXmlNode.fFirstChild, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }

                    // --

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fNextSibling != null)
                    {
                        fXmlNodeResult = searchDataSetNode(fXmlNode.fNextSibling, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                // --

                m_stepCount--;

                // --

                if (m_stepCount == 0)
                {
                    if (fXmlNode != null)
                    {
                        fXmlNodeNext = getNextNode(fXmlNode, fXmlNodeRoot);
                    }

                    // --

                    if (fXmlNodeNext.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeNext = fXmlNodeRoot;
                    }

                    // --
                    if (fXmlNodeNext == fXmlNodeRoot)
                    {
                        if (
                            fXmlNodeNext.fParentNode.fParentNode != null &&
                            contains(fXmlNodeNext.fParentNode.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                            )
                        {
                            fXmlNodeResult = fXmlNodeNext.fParentNode.fParentNode;
                        }
                        else
                        {
                            fXmlNodeResult = searchDataSetNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                        }
                    }
                    else if (fXmlNodeNext != null)
                    {
                        fXmlNodeResult = searchDataSetNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                return fXmlNodeResult;
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

        public static FXmlNode searchEquipmentStateSetNode(
            FXmlNode fXmlNode,
            FXmlNode fXmlNodeStart,
            FXmlNode fXmlNodeRoot,
            string searchWord
            )
        {
            FXmlNode fXmlNodeNext = null;
            FXmlNode fXmlNodeResult = null;

            try
            {
                m_stepCount++;

                // --

                if (fXmlNode != null)
                {
                    if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagESD.E_EquipmentStateSetDefinition)
                    {

                    }
                    else if (fXmlNode.name == FXmlTagESL.E_EquipmentStateSetList)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagESL.A_Name, FXmlTagESL.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagESS.E_EquipmentStateSet)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagESL.A_Name, FXmlTagESL.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagEST.E_EquipmentState)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagESL.A_Name, FXmlTagESL.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagSTV.E_StateValue)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagSTV.A_Name, FXmlTagSTV.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }

                    // --

                    if (fXmlNode == fXmlNodeStart)
                    {
                        m_isSearched = true;
                    }

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fFirstChild != null)
                    {
                        fXmlNodeResult = searchEquipmentStateSetNode(fXmlNode.fFirstChild, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }

                    // --

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fNextSibling != null)
                    {
                        fXmlNodeResult = searchEquipmentStateSetNode(fXmlNode.fNextSibling, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                // --

                m_stepCount--;

                // --

                if (m_stepCount == 0)
                {
                    if (fXmlNode != null)
                    {
                        fXmlNodeNext = getNextNode(fXmlNode, fXmlNodeRoot);
                    }

                    // --

                    if (fXmlNodeNext.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeNext = fXmlNodeRoot;
                    }

                    // --
                    if (fXmlNodeNext == fXmlNodeRoot)
                    {
                        if (
                            fXmlNodeNext.fParentNode.fParentNode != null &&
                            contains(fXmlNodeNext.fParentNode.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                            )
                        {
                            fXmlNodeResult = fXmlNodeNext.fParentNode.fParentNode;
                        }
                        else
                        {
                            fXmlNodeResult = searchEquipmentStateSetNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                        }
                    }
                    else if (fXmlNodeNext != null)
                    {
                        fXmlNodeResult = searchEquipmentStateSetNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                return fXmlNodeResult;
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

        public static FXmlNode searchEnvironmentNode(
            FXmlNode fXmlNode,
            FXmlNode fXmlNodeStart,
            FXmlNode fXmlNodeRoot,
            string searchWord
            )
        {
            FXmlNode fXmlNodeNext = null;
            FXmlNode fXmlNodeResult = null;
            FFormat fFormat;
            // --
            string originalStringValue;
            string originalEncodingValue;

            try
            {
                m_stepCount++;

                // --

                if (fXmlNode != null)
                {
                    if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagEND.E_EnvironmentDefinition)
                    {

                    }
                    else if (fXmlNode.name == FXmlTagENL.E_EnvironmentList)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagENL.A_Name, FXmlTagENL.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagENV.E_Environment)
                    {
                        fFormat = FEnumConverter.toFormat(fXmlNode.get_attrVal(FXmlTagENV.A_Format, FXmlTagENV.D_Format));
                        originalStringValue = fXmlNode.get_attrVal(FXmlTagENV.A_Value, FXmlTagENV.D_Value);
                        originalEncodingValue = toValue(fFormat, originalStringValue);
                        // --
                        if (
                            contains(fXmlNode.get_attrVal(FXmlTagENV.A_Name, FXmlTagENV.D_Name), searchWord) ||
                            contains(originalEncodingValue, searchWord)
                            )
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }

                    // --

                    if (fXmlNode == fXmlNodeStart)
                    {
                        m_isSearched = true;
                    }

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fFirstChild != null)
                    {
                        fXmlNodeResult = searchEnvironmentNode(fXmlNode.fFirstChild, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }

                    // --

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fNextSibling != null)
                    {
                        fXmlNodeResult = searchEnvironmentNode(fXmlNode.fNextSibling, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                // --

                m_stepCount--;

                // --

                if (m_stepCount == 0)
                {
                    if (fXmlNode != null)
                    {
                        fXmlNodeNext = getNextNode(fXmlNode, fXmlNodeRoot);
                    }

                    // --

                    if (fXmlNodeNext.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeNext = fXmlNodeRoot;
                    }

                    // --
                    if (fXmlNodeNext == fXmlNodeRoot)
                    {
                        if (
                            fXmlNodeNext.fParentNode.fParentNode != null &&
                            contains(fXmlNodeNext.fParentNode.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                            )
                        {
                            fXmlNodeResult = fXmlNodeNext.fParentNode.fParentNode;
                        }
                        else
                        {
                            fXmlNodeResult = searchEnvironmentNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                        }
                    }
                    else if (fXmlNodeNext != null)
                    {
                        fXmlNodeResult = searchEnvironmentNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                return fXmlNodeResult;
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

        public static FXmlNode searchLogNode(
            FXmlNode fXmlNode,
            FXmlNode fXmlNodeStart,
            FXmlNode fXmlNodeRoot,
            string searchWord
            )
        {
            FXmlNode fXmlNodeNext = null;
            FXmlNode fXmlNodeResult = null;
            FFormat fFormat;
            string value;
            string encodingValue;

            try
            {
                m_stepCount++;

                // --

                if (fXmlNode != null)
                {
                    if (fXmlNode.name == FXmlTagHITL.E_HostItem)
                    {
                        fFormat = FEnumConverter.toFormat(fXmlNode.get_attrVal(FXmlTagHITL.A_Format, FXmlTagHITL.D_Format));
                        value = fXmlNode.get_attrVal(FXmlTagHITL.A_Value, FXmlTagHITL.D_Value);
                        encodingValue = toValue(fFormat, value);
                        // --
                        if (
                            contains(fXmlNode.get_attrVal(FXmlTagHITL.A_Name, FXmlTagHITL.D_Name), searchWord) ||
                            contains(encodingValue, searchWord)
                            )
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }                   
                    else
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagCommon.A_Name, FXmlTagCommon.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }

                    // --

                    if (fXmlNode == fXmlNodeStart)
                    {
                        m_isSearched = true;
                    }

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fFirstChild != null)
                    {
                        fXmlNodeResult = searchLogNode(fXmlNode.fFirstChild, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }

                    // --

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fNextSibling != null)
                    {
                        fXmlNodeResult = searchLogNode(fXmlNode.fNextSibling, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                // --

                m_stepCount--;

                // --

                if (m_stepCount == 0)
                {
                    if (fXmlNode != null)
                    {
                        fXmlNodeNext = getNextNode(fXmlNode, fXmlNodeRoot);
                    }

                    // --

                    if (fXmlNodeNext.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeNext = fXmlNodeRoot;
                    }

                    // --
                    if (fXmlNodeNext == fXmlNodeRoot)
                    {
                        if (contains(fXmlNodeNext.get_attrVal(FXmlTagPCDL.A_Name, FXmlTagPCDL.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNodeNext;
                        }
                        else
                        {
                            fXmlNodeResult = searchLogNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                        }
                    }
                    else if (fXmlNodeNext != null)
                    {
                        fXmlNodeResult = searchLogNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                return fXmlNodeResult;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeNext = null;
                fXmlNodeResult = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode searchScenarioNode(
            FXmlNode fXmlNode,
            FXmlNode fXmlNodeStart,
            FXmlNode fXmlNodeRoot,
            string searchWord
            )
        {
            FXmlNode fXmlNodeNext = null;
            FXmlNode fXmlNodeResult = null;

            try
            {
                m_stepCount++;

                // --

                if (fXmlNode != null)
                {
                    if (fXmlNode.name == FXmlTagPTR.E_PlcTrigger)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPTR.A_Name, FXmlTagPTR.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                        // --
                        m_flowId = fXmlNode.get_attrVal(FXmlTagPTR.A_UniqueId, FXmlTagPTR.D_UniqueId);
                    }
                    else if (fXmlNode.name == FXmlTagPCN.E_PlcCondition)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPCN.A_Name, FXmlTagPCN.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagPEP.E_PlcExpression)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPEP.A_Name, FXmlTagPEP.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagPTN.E_PlcTransmitter)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPTN.A_Name, FXmlTagPTN.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                        // --
                        m_flowId = fXmlNode.get_attrVal(FXmlTagPTN.A_UniqueId, FXmlTagPTN.D_UniqueId);
                    }
                    else if (fXmlNode.name == FXmlTagPTF.E_PlcTransfer)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPTF.A_Name, FXmlTagPTF.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagHTR.E_HostTrigger)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagHTR.A_Name, FXmlTagHTR.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                        // --
                        m_flowId = fXmlNode.get_attrVal(FXmlTagHTR.A_UniqueId, FXmlTagHTR.D_UniqueId);
                    }
                    else if (fXmlNode.name == FXmlTagHCN.E_HostCondition)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagHCN.A_Name, FXmlTagHCN.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagHEP.E_HostExpression)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagHEP.A_Name, FXmlTagHEP.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagHTN.E_HostTransmitter)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagHTN.A_Name, FXmlTagHTN.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                        // --
                        m_flowId = fXmlNode.get_attrVal(FXmlTagHTN.A_UniqueId, FXmlTagHTN.D_UniqueId);
                    }
                    else if (fXmlNode.name == FXmlTagHTF.E_HostTransfer)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagHTF.A_Name, FXmlTagHTF.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagJDM.E_Judgement)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagJDM.A_Name, FXmlTagJDM.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                        // --
                        m_flowId = fXmlNode.get_attrVal(FXmlTagJDM.A_UniqueId, FXmlTagJDM.D_UniqueId);
                    }
                    else if (fXmlNode.name == FXmlTagJCN.E_JudgementCondition)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagJCN.A_Name, FXmlTagJCN.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagJEP.E_JudgementExpression)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagJEP.A_Name, FXmlTagJEP.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagMAP.E_Mapper)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagMAP.A_Name, FXmlTagMAP.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                        // --
                        m_flowId = fXmlNode.get_attrVal(FXmlTagMAP.A_UniqueId, FXmlTagMAP.D_UniqueId);
                    }
                    else if (fXmlNode.name == FXmlTagSTG.E_Storage)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagSTG.A_Name, FXmlTagSTG.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                        // --
                        m_flowId = fXmlNode.get_attrVal(FXmlTagSTG.A_UniqueId, FXmlTagSTG.D_UniqueId);
                    }
                    else if (fXmlNode.name == FXmlTagCBK.E_Callback)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagCBK.A_Name, FXmlTagCBK.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                        // --
                        m_flowId = fXmlNode.get_attrVal(FXmlTagCBK.A_UniqueId, FXmlTagCBK.D_UniqueId);
                    }
                    else if (fXmlNode.name == FXmlTagFUN.E_Function)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagFUN.A_Name, FXmlTagFUN.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                    }
                    else if (fXmlNode.name == FXmlTagBRN.E_Branch)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagBRN.A_Name, FXmlTagBRN.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                        // --
                        m_flowId = fXmlNode.get_attrVal(FXmlTagBRN.A_UniqueId, FXmlTagBRN.D_UniqueId);
                    }
                    else if (fXmlNode.name == FXmlTagCMT.E_Comment)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagCMT.A_Name, FXmlTagCMT.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                        // --
                        m_flowId = fXmlNode.get_attrVal(FXmlTagCMT.A_UniqueId, FXmlTagCMT.D_UniqueId);
                    }
                    else if (fXmlNode.name == FXmlTagPAU.E_Pauser)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagPAU.A_Name, FXmlTagPAU.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                        // --
                        m_flowId = fXmlNode.get_attrVal(FXmlTagPAU.A_UniqueId, FXmlTagPAU.D_UniqueId);
                    }
                    else if (fXmlNode.name == FXmlTagETP.E_EntryPoint)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagETP.A_Name, FXmlTagETP.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                        // --
                        m_flowId = fXmlNode.get_attrVal(FXmlTagETP.A_UniqueId, FXmlTagETP.D_UniqueId);
                    }
                    else if (fXmlNode.name == FXmlTagESA.E_EquipmentStateSetAlterer)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagESA.A_Name, FXmlTagESA.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                        // --
                        m_flowId = fXmlNode.get_attrVal(FXmlTagESA.A_UniqueId, FXmlTagESA.D_UniqueId);
                    }
                    else if (fXmlNode.name == FXmlTagEAT.E_EquipmentStateAlterer)
                    {
                        if (contains(fXmlNode.get_attrVal(FXmlTagEAT.A_Name, FXmlTagEAT.D_Name), searchWord))
                        {
                            fXmlNodeResult = fXmlNode;
                            m_isSearched = true;
                        }
                        // --
                        m_flowId = fXmlNode.get_attrVal(FXmlTagEAT.A_UniqueId, FXmlTagEAT.D_UniqueId);
                    }

                    // --

                    if (fXmlNode == fXmlNodeStart)
                    {
                        m_isSearched = true;
                    }

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fFirstChild != null)
                    {
                        fXmlNodeResult = searchScenarioNode(fXmlNode.fFirstChild, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }

                    // --

                    if (m_isSearched)
                    {
                        return fXmlNodeResult;
                    }

                    // --

                    if (fXmlNode.fNextSibling != null)
                    {
                        fXmlNodeResult = searchScenarioNode(fXmlNode.fNextSibling, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                // --

                m_stepCount--;

                // --

                if (m_stepCount == 0)
                {
                    if (fXmlNode != null)
                    {
                        fXmlNodeNext = getNextNode(fXmlNode, fXmlNodeRoot);
                    }

                    // --

                    if (fXmlNodeNext.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeNext = fXmlNodeRoot;
                    }

                    // --
                    if (fXmlNodeNext == fXmlNodeRoot)
                    {
                        if (
                            fXmlNodeNext.fParentNode != null &&
                            contains(fXmlNodeNext.fParentNode.get_attrVal(FXmlTagSNR.A_Name, FXmlTagSNR.D_Name), searchWord)
                            )
                        {
                            fXmlNodeResult = fXmlNodeNext.fParentNode;
                        }
                        else
                        {
                            fXmlNodeResult = searchScenarioNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                        }
                    }
                    else if (fXmlNodeNext != null)
                    {
                        fXmlNodeResult = searchScenarioNode(fXmlNodeNext, fXmlNodeStart, fXmlNodeRoot, searchWord);
                    }
                }

                return fXmlNodeResult;
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

        public static void resetResource(
            )
        {
            try
            {
                m_isSearched = false;
                m_stepCount = 0;
                m_lastSession = string.Empty;
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

        public static FXmlNode getNextNode(
            FXmlNode fXmlNode,
            FXmlNode fXmlNodeRoot            
            )
        {
            try
            {
                if (fXmlNode.fParentNode == fXmlNodeRoot)
                {
                    return fXmlNodeRoot;
                }
                else if (fXmlNode.fParentNode.fNextSibling != null)                   
                {
                    return fXmlNode.fParentNode.fNextSibling;
                }                          
                else if (fXmlNode == fXmlNodeRoot)
                {
                    return null;
                }
                else
                {
                    return getNextNode(fXmlNode.fParentNode, fXmlNodeRoot);
                }
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

        public static bool contains(
            string nodeName, 
            string searchWord
            )
        {
            try
            {
                nodeName = nodeName.ToLower();
                searchWord = searchWord.ToLower();   
                                
                return nodeName.Contains(searchWord);
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

        public static string toValue(
            FFormat fFormat, 
            string value
            )
        {
            try
            {
                if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                {
                    return FValueConverter.toEncodingValue(fFormat, value);
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
        
        #endregion
        
        //------------------------------------------------------------------------------------------------------------------------       
        
    }   // Class end
}   // Namespace end
