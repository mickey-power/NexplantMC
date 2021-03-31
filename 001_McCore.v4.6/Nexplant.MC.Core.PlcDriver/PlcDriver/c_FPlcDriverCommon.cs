/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPlcDriverCommon.cs
--  Creator         : spike.lee
--  Create Date     : 2013.07.10
--  Description     : FAMate Core FaPlcDriver PLC Driver Common Function Class 
--  History         : Created by spike.lee at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal static class FPlcDriverCommon
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static void validateName(
            string name,
            bool emptyError
            )
        {
            char[] c = { ' ', '\\', '/', '.', ',', '\'', '"', '&', '|', '[', ']', '(', ')', ':', ';', '`', '~', '!', '@', '#', '$', '%', '^', '*', '+', '=', '\n', '\r' };

            try
            {
                if (name == string.Empty && emptyError)
                {
                    FDebug.throwFException(FConstants.err_m_0002);
                }

                if (name.IndexOfAny(c) > -1)
                {
                    FDebug.throwFException(FConstants.err_m_0001);
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

        public static void validateNewChildObject(
            FXmlNode fXmlNodeNew
            )
        {
            try
            {
                if (fXmlNodeNew.fParentNode != null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "New Object", "Parent"));
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

        public static void validateRefChildObject(
            FXmlNode fXmlNodeParent, 
            FXmlNode fXmlNodeRef
            )
        {
            try
            {
                if (fXmlNodeParent != fXmlNodeRef.fParentNode)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Reference Object", "Child"));
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

        public static void validateRemoveChildObject(
            FXmlNode fXmlNodeParent, 
            FXmlNode fXmlNode
            )
        {
            try
            {
                if (fXmlNode.fParentNode == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0005, "Object"));
                }

                // --

                if (fXmlNode.get_attrVal(FXmlTagCommon.A_Locked, FXmlTagCommon.D_Locked) == FBoolean.True)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                }    

                // --
                
                if (fXmlNodeParent != fXmlNode.fParentNode)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "Child"));
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

        public static void validateMoveUpObject(
            FXmlNode fXmlNode
            )
        {
            try
            {
                if (fXmlNode.fParentNode == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Parent"));
                }

                // --
                
                if (fXmlNode.fPreviousSibling == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Previous Sibling"));
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

        public static void validateMoveDownObject(
            FXmlNode fXmlNode
            )
        {
            try
            {
                if (fXmlNode.fParentNode == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Parent"));
                }

                // --
                
                if (fXmlNode.fNextSibling == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Next Sibling"));
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

        public static void validateMoveToObject(
            FXmlNode fXmlNode,
            FXmlNode fRefXmlNode
            )
        {
            try
            {
                if (fXmlNode.fParentNode == null || fRefXmlNode.fParentNode == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Parent"));
                }

                // -- 

                if (fXmlNode == fRefXmlNode)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "same localtion"));
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

        public static void validateCutObject(            
            FXmlNode fXmlNode
            )
        {
            try
            {
                if (fXmlNode.fParentNode == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0005, "Object"));
                }

                if (fXmlNode.get_attrVal(FXmlTagCommon.A_Locked, FXmlTagCommon.D_Locked) == FBoolean.True)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
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

        public static void validatePasteSiblingObject(
            FXmlNode fXmlNode, 
            string format
            )
        {
            try
            {
                if (fXmlNode.fParentNode == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Parent"));
                }

                if (!FClipboard.containsData(format))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0015, "Object Type"));
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

        public static void validatePasteChildObject(
            FXmlNode fXmlNode,
            string format
            )
        {
            try
            {
                if (!FClipboard.containsData(format))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0015, "Object Type"));
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

        public static FXmlNode createXmlNodeFAM(
            FXmlDocument fXmlDoc
            )
        {
            string dateTime = string.Empty;
            FXmlNode fXmlNode = null;

            try
            {
                dateTime = FDataConvert.defaultNowDateTimeToString();
                // --
                fXmlNode = fXmlDoc.createNode(FXmlTagFAM.E_FAMate);
                // --
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileFormat, FXmlTagFAM.D_FileFormat, "PSM");
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileVersion, FXmlTagFAM.D_FileVersion, "4.1.0.1");
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileCreationTime, FXmlTagFAM.D_FileCreationTime, dateTime);
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileUpdateTime, FXmlTagFAM.D_FileUpdateTime, dateTime);
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileDescription, FXmlTagFAM.D_FileDescription, "FAMate PLC Modeling File");
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodePCD(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPCD.E_PlcDriver);
                // --
                fXmlNode.set_attrVal(FXmlTagPCD.A_UniqueId, FXmlTagPCD.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagPCD.A_Locked, FXmlTagPCD.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name, "PlcDriver");
                fXmlNode.set_attrVal(FXmlTagPCD.A_Description, FXmlTagPCD.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPCD.A_FontColor, FXmlTagPCD.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagPCD.A_FontBold, FXmlTagPCD.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagPCD.A_EapName, FXmlTagPCD.D_EapName, "EAP");
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodePLB(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPLB.E_PlcLibrary);
                // --
                fXmlNode.set_attrVal(FXmlTagPLB.A_UniqueId, FXmlTagPLB.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagPLB.A_Locked, FXmlTagPLB.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagPLB.A_Name, FXmlTagPLB.D_Name, "PlcLibrary");
                fXmlNode.set_attrVal(FXmlTagPLB.A_Description, FXmlTagPLB.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPLB.A_FontColor, FXmlTagPLB.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagPLB.A_FontBold, FXmlTagPLB.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagPLB.A_Comment, FXmlTagPLB.D_Comment, FXmlTagPLB.D_Comment);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodePLG(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPLG.E_PlcLibraryGroup);
                // --
                fXmlNode.set_attrVal(FXmlTagPLG.A_UniqueId, FXmlTagPLG.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagPLG.A_Locked, FXmlTagPLG.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagPLG.A_Name, FXmlTagPLG.D_Name, "PlcLibraryGroup");
                fXmlNode.set_attrVal(FXmlTagPLG.A_Description, FXmlTagPLG.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPLG.A_FontColor, FXmlTagPLG.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagPLG.A_FontBold, FXmlTagPLG.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeSET(
            FXmlDocument fXmlDoc
            )
        {
            try
            {
                return fXmlDoc.createNode(FXmlTagSET.E_Setup);
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

        public static FXmlNode createXmlNodeOND(
            FXmlDocument fXmlDoc
            )
        {
            try
            {
                return fXmlDoc.createNode(FXmlTagOND.E_ObjectNameDefinition);
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

        public static FXmlNode createXmlNodeONL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagONL.E_ObjectNameList);
                // --
                fXmlNode.set_attrVal(FXmlTagONL.A_UniqueId, FXmlTagONL.D_UniqueId, "0");                
                fXmlNode.set_attrVal(FXmlTagONL.A_Name, FXmlTagONL.D_Name, "ObjectNameList");
                fXmlNode.set_attrVal(FXmlTagONL.A_Description, FXmlTagONL.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagONL.A_FontColor, FXmlTagONL.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagONL.A_FontBold, FXmlTagONL.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagONL.A_ObjectType, FXmlTagONL.D_ObjectType, FObjectType.PlcDriver.ToString());
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeMAP(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagMAP.E_Mapper);
                // --
                fXmlNode.set_attrVal(FXmlTagMAP.A_UniqueId, FXmlTagMAP.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagMAP.A_Name, FXmlTagMAP.D_Name, "Mapper");
                fXmlNode.set_attrVal(FXmlTagMAP.A_Description, FXmlTagMAP.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagMAP.A_FontColor, FXmlTagMAP.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagMAP.A_FontBold, FXmlTagMAP.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagMAP.A_DataSetId, FXmlTagMAP.D_DataSetId, FXmlTagMAP.D_DataSetId);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeONA(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagONA.E_ObjectName);
                // --
                fXmlNode.set_attrVal(FXmlTagONA.A_UniqueId, FXmlTagONA.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagONA.A_Name, FXmlTagONA.D_Name, "ObjectName");
                fXmlNode.set_attrVal(FXmlTagONA.A_Description, FXmlTagONA.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagONA.A_FontColor, FXmlTagONA.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagONA.A_FontBold, FXmlTagONA.D_FontBold, FBoolean.False);                
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeFND(
            FXmlDocument fXmlDoc
            )
        {
            try
            {
                return fXmlDoc.createNode(FXmlTagFND.E_FunctionNameDefinition);
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

        public static FXmlNode createXmlNodeFNL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagFNL.E_FunctionNameList);
                // --
                fXmlNode.set_attrVal(FXmlTagFNL.A_UniqueId, FXmlTagFNL.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagFNL.A_Name, FXmlTagFNL.D_Name, "FunctionNameList");
                fXmlNode.set_attrVal(FXmlTagFNL.A_Description, FXmlTagFNL.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagFNL.A_FontColor, FXmlTagFNL.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagFNL.A_FontBold, FXmlTagFNL.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeFNA(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagFNA.E_FunctionName);
                // --
                fXmlNode.set_attrVal(FXmlTagFNA.A_UniqueId, FXmlTagFNA.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagFNA.A_Name, FXmlTagFNA.D_Name, "FunctiontName");
                fXmlNode.set_attrVal(FXmlTagFNA.A_Description, FXmlTagFNA.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagFNA.A_FontColor, FXmlTagFNA.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagFNA.A_FontBold, FXmlTagFNA.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodePAN(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPAN.E_ParameterName);
                // --
                fXmlNode.set_attrVal(FXmlTagPAN.A_UniqueId, FXmlTagPAN.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagPAN.A_Name, FXmlTagPAN.D_Name, "ParameterName");
                fXmlNode.set_attrVal(FXmlTagPAN.A_Description, FXmlTagPAN.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPAN.A_FontColor, FXmlTagPAN.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagPAN.A_FontBold, FXmlTagPAN.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeARG(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagARG.E_Argument);
                // --
                fXmlNode.set_attrVal(FXmlTagARG.A_UniqueId, FXmlTagARG.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagARG.A_Name, FXmlTagARG.D_Name, "Argument");
                fXmlNode.set_attrVal(FXmlTagARG.A_Description, FXmlTagARG.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagARG.A_FontColor, FXmlTagARG.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagARG.A_FontBold, FXmlTagARG.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeUTD(
            FXmlDocument fXmlDoc
            )
        {
            try
            {
                return fXmlDoc.createNode(FXmlTagUTD.E_UserTagNameDefinition);
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

        public static FXmlNode createXmlNodeUTN(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagUTN.E_UserTagName);
                // --
                fXmlNode.set_attrVal(FXmlTagUTN.A_UniqueId, FXmlTagUTN.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagUTN.A_Name, FXmlTagUTN.D_Name, "UserTagName");
                fXmlNode.set_attrVal(FXmlTagUTN.A_Description, FXmlTagUTN.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagUTN.A_FontColor, FXmlTagUTN.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagUTN.A_FontBold, FXmlTagUTN.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagUTN.A_ObjectType, FXmlTagUTN.D_ObjectType, FXmlTagUTN.D_ObjectType);
                // --
                fXmlNode.set_attrVal(FXmlTagUTN.A_UserTagName1, FXmlTagUTN.D_UserTagName1, string.Empty);
                fXmlNode.set_attrVal(FXmlTagUTN.A_UserTagName2, FXmlTagUTN.D_UserTagName2, string.Empty);
                fXmlNode.set_attrVal(FXmlTagUTN.A_UserTagName3, FXmlTagUTN.D_UserTagName3, string.Empty);
                fXmlNode.set_attrVal(FXmlTagUTN.A_UserTagName4, FXmlTagUTN.D_UserTagName4, string.Empty);
                fXmlNode.set_attrVal(FXmlTagUTN.A_UserTagName5, FXmlTagUTN.D_UserTagName5, string.Empty);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeDCD(
            FXmlDocument fXmlDoc
            )
        {
            try
            {
                return fXmlDoc.createNode(FXmlTagDCD.E_DataConversionSetDefinition);
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

        public static FXmlNode createXmlNodeDCL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagDCL.E_DataConversionSetList);
                // --
                fXmlNode.set_attrVal(FXmlTagDCL.A_UniqueId, FXmlTagDCL.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagDCL.A_Locked, FXmlTagDCL.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagDCL.A_Name, FXmlTagDCL.D_Name, "DataConversionSetList");
                fXmlNode.set_attrVal(FXmlTagDCL.A_Description, FXmlTagDCL.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagDCL.A_FontColor, FXmlTagDCL.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagDCL.A_FontBold, FXmlTagDCL.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeDCS(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagDCS.E_DataConversionSet);
                // --
                fXmlNode.set_attrVal(FXmlTagDCS.A_UniqueId, FXmlTagDCS.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagDCS.A_Locked, FXmlTagDCS.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagDCS.A_Name, FXmlTagDCS.D_Name, "DataConversionSet");
                fXmlNode.set_attrVal(FXmlTagDCS.A_Description, FXmlTagDCS.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagDCS.A_FontColor, FXmlTagDCS.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagDCS.A_FontBold, FXmlTagDCS.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeDCV(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagDCV.E_DataConversion);
                // --
                fXmlNode.set_attrVal(FXmlTagDCV.A_UniqueId, FXmlTagDCV.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagDCV.A_Locked, FXmlTagDCV.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagDCV.A_Name, FXmlTagDCV.D_Name, "DataConversion");
                fXmlNode.set_attrVal(FXmlTagDCV.A_Description, FXmlTagDCV.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagDCV.A_FontColor, FXmlTagDCV.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagDCV.A_FontBold, FXmlTagDCV.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }


        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeESD(
            FXmlDocument fXmlDoc
            )
        {
            try
            {
                return fXmlDoc.createNode(FXmlTagESD.E_EquipmentStateSetDefinition);
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

        public static FXmlNode createXmlNodeESA(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagESA.E_EquipmentStateSetAlterer);
                // --
                fXmlNode.set_attrVal(FXmlTagESA.A_UniqueId, FXmlTagESA.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagESA.A_Name, FXmlTagESA.D_Name, "EquipmentStateSetAlterer");
                fXmlNode.set_attrVal(FXmlTagESA.A_Description, FXmlTagESA.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagESA.A_FontColor, FXmlTagESA.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagESA.A_FontBold, FXmlTagESA.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagESA.A_EquipmentStateSetId, FXmlTagESA.D_EquipmentStateSetId, string.Empty);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeESL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagESL.E_EquipmentStateSetList);
                // --
                fXmlNode.set_attrVal(FXmlTagESL.A_UniqueId, FXmlTagESL.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagESL.A_Locked, FXmlTagESL.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagESL.A_Name, FXmlTagESL.D_Name, "EquipmentStateSetList");
                fXmlNode.set_attrVal(FXmlTagESL.A_Description, FXmlTagESL.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagESL.A_FontColor, FXmlTagESL.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagESL.A_FontBold, FXmlTagESL.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeESS(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagESS.E_EquipmentStateSet);
                // --
                fXmlNode.set_attrVal(FXmlTagESS.A_UniqueId, FXmlTagESS.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagESS.A_Locked, FXmlTagESS.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagESS.A_Name, FXmlTagESS.D_Name, "EquipmentStateSet");
                fXmlNode.set_attrVal(FXmlTagESS.A_Description, FXmlTagESS.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagESS.A_FontColor, FXmlTagESS.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagESS.A_FontBold, FXmlTagESS.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeEST(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagEST.E_EquipmentState);
                // --
                fXmlNode.set_attrVal(FXmlTagEST.A_EquipmentStateType, FXmlTagEST.D_EquipmentStateType, FXmlTagEST.D_EquipmentStateType);
                // --
                fXmlNode.set_attrVal(FXmlTagEST.A_UniqueId, FXmlTagEST.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagEST.A_Locked, FXmlTagEST.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagEST.A_Name, FXmlTagEST.D_Name, "EquipmentState");
                fXmlNode.set_attrVal(FXmlTagEST.A_Description, FXmlTagEST.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagEST.A_FontColor, FXmlTagEST.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagEST.A_FontBold, FXmlTagEST.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagEST.A_DefaultValue, FXmlTagEST.D_DefaultValue, string.Empty);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------


        public static FXmlNode createXmlNodeEAT(
             FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagEAT.E_EquipmentStateAlterer);
                // --
                fXmlNode.set_attrVal(FXmlTagEAT.A_UniqueId, FXmlTagEAT.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagEAT.A_Name, FXmlTagEAT.D_Name, "EquipmentStateAlterer");
                fXmlNode.set_attrVal(FXmlTagEAT.A_Description, FXmlTagEAT.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagEAT.A_FontColor, FXmlTagEAT.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagEAT.A_FontBold, FXmlTagEAT.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagEAT.A_EquipmentStateId, FXmlTagEAT.D_EquipmentStateId, string.Empty);
                fXmlNode.set_attrVal(FXmlTagEAT.A_Value, FXmlTagEAT.D_Value, string.Empty);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeEND(
            FXmlDocument fXmlDoc
            )
        {
            try
            {
                return fXmlDoc.createNode(FXmlTagEND.E_EnvironmentDefinition);
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

        public static FXmlNode createXmlNodeENL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagENL.E_EnvironmentList);
                // --
                fXmlNode.set_attrVal(FXmlTagENL.A_UniqueId, FXmlTagENL.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagENL.A_Locked, FXmlTagENL.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagENL.A_Name, FXmlTagENL.D_Name, "EnvironmentList");
                fXmlNode.set_attrVal(FXmlTagENL.A_Description, FXmlTagENL.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagENL.A_FontColor, FXmlTagENL.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagENL.A_FontBold, FXmlTagENL.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeENV(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagENV.E_Environment);
                // --
                fXmlNode.set_attrVal(FXmlTagENV.A_UniqueId, FXmlTagENV.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagENV.A_Locked, FXmlTagENV.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagENV.A_Name, FXmlTagENV.D_Name, "Environment");
                fXmlNode.set_attrVal(FXmlTagENV.A_Description, FXmlTagENV.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagENV.A_FontColor, FXmlTagENV.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagENV.A_FontBold, FXmlTagENV.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagENV.A_Format, FXmlTagENV.D_Format, "L");
                fXmlNode.set_attrVal(FXmlTagENV.A_Value, FXmlTagENV.D_Value, FXmlTagENV.D_Value);
                fXmlNode.set_attrVal(FXmlTagENV.A_Length, FXmlTagENV.D_Length, FXmlTagENV.D_Length);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeSTG(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagSTG.E_Storage);
                // --
                fXmlNode.set_attrVal(FXmlTagSTG.A_UniqueId, FXmlTagSTG.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagSTG.A_Name, FXmlTagSTG.D_Name, "Storage");
                fXmlNode.set_attrVal(FXmlTagSTG.A_Description, FXmlTagSTG.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagSTG.A_FontColor, FXmlTagSTG.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagSTG.A_FontBold, FXmlTagSTG.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagSTG.A_Action, FXmlTagSTG.D_Action, FXmlTagSTG.D_Action);
                fXmlNode.set_attrVal(FXmlTagSTG.A_RepositoryId, FXmlTagSTG.D_RepositoryId, FXmlTagSTG.D_RepositoryId);
                // --
                fXmlNode.set_attrVal(FXmlTagSTG.A_UsedBranch, FXmlTagSTG.D_UsedBranch, FXmlTagSTG.D_UsedBranch);
                fXmlNode.set_attrVal(FXmlTagSTG.A_LocationId, FXmlTagSTG.D_LocationId, string.Empty);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeSTV(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagSTV.E_StateValue);
                // --
                fXmlNode.set_attrVal(FXmlTagSTV.A_UniqueId, FXmlTagSTV.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagSTV.A_Name, FXmlTagSTV.D_Name, "StateValue");
                fXmlNode.set_attrVal(FXmlTagSTV.A_Description, FXmlTagSTV.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagSTV.A_FontColor, FXmlTagSTV.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagSTV.A_FontBold, FXmlTagSTV.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeRPD(
            FXmlDocument fXmlDoc
            )
        {
            try
            {
                return fXmlDoc.createNode(FXmlTagRPD.E_RepositoryDefinition);
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

        public static FXmlNode createXmlNodeRPL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagRPL.E_RepositoryList);
                // --
                fXmlNode.set_attrVal(FXmlTagRPL.A_UniqueId, FXmlTagRPL.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagRPL.A_Locked, FXmlTagRPL.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagRPL.A_Name, FXmlTagRPL.D_Name, "RepositoryList");
                fXmlNode.set_attrVal(FXmlTagRPL.A_Description, FXmlTagRPL.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagRPL.A_FontColor, FXmlTagRPL.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagRPL.A_FontBold, FXmlTagRPL.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeRPS(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagRPS.E_Repository);
                // --
                fXmlNode.set_attrVal(FXmlTagRPS.A_RepositoryType, FXmlTagRPS.D_RepositoryType, FXmlTagRPS.D_RepositoryType);
                // --
                fXmlNode.set_attrVal(FXmlTagRPS.A_UniqueId, FXmlTagRPS.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagRPS.A_Locked, FXmlTagRPS.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagRPS.A_Name, FXmlTagRPS.D_Name, "Repository");
                fXmlNode.set_attrVal(FXmlTagRPS.A_Description, FXmlTagRPS.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagRPS.A_FontColor, FXmlTagRPS.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagRPS.A_FontBold, FXmlTagRPS.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeCOL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagCOL.E_Column);
                // --
                fXmlNode.set_attrVal(FXmlTagCOL.A_UniqueId, FXmlTagCOL.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagCOL.A_Name, FXmlTagCOL.D_Name, "Column");
                fXmlNode.set_attrVal(FXmlTagCOL.A_Description, FXmlTagCOL.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagCOL.A_FontColor, FXmlTagCOL.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagCOL.A_FontBold, FXmlTagCOL.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagCOL.A_PrimaryKey, FXmlTagCOL.D_PrimaryKey, FXmlTagCOL.D_PrimaryKey);
                fXmlNode.set_attrVal(FXmlTagCOL.A_DuplicationKey, FXmlTagCOL.D_DuplicationKey, FXmlTagCOL.D_DuplicationKey);
                // --
                fXmlNode.set_attrVal(FXmlTagCOL.A_Pattern, FXmlTagCOL.D_Pattern, "F");
                fXmlNode.set_attrVal(FXmlTagCOL.A_FixedLength, FXmlTagCOL.D_FixedLength, "1");
                fXmlNode.set_attrVal(FXmlTagCOL.A_Format, FXmlTagCOL.D_Format, "L");
                // --
                fXmlNode.set_attrVal(FXmlTagCOL.A_ScanMode, FXmlTagCOL.D_ScanMode, "L");
                // --
                fXmlNode.set_attrVal(FXmlTagCOL.A_Value, FXmlTagCOL.D_Value, FXmlTagCOL.D_Value);
                fXmlNode.set_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length, FXmlTagCOL.D_Length);
                // --
                fXmlNode.set_attrVal(FXmlTagCOL.A_Transformer, FXmlTagCOL.D_Transformer, FXmlTagCOL.D_Transformer);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeDSD(
            FXmlDocument fXmlDoc
            )
        {
            try
            {
                return fXmlDoc.createNode(FXmlTagDSD.E_DataSetDefinition);
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

        public static FXmlNode createXmlNodeDSL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagDSL.E_DataSetList);
                // --
                fXmlNode.set_attrVal(FXmlTagDSL.A_UniqueId, FXmlTagDSL.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagDSL.A_Locked, FXmlTagDSL.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagDSL.A_Name, FXmlTagDSL.D_Name, "DataSetList");
                fXmlNode.set_attrVal(FXmlTagDSL.A_Description, FXmlTagDSL.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagDSL.A_FontColor, FXmlTagDSL.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagDSL.A_FontBold, FXmlTagDSL.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeDTS(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagDTS.E_DataSet);
                // --
                fXmlNode.set_attrVal(FXmlTagDTS.A_UniqueId, FXmlTagDTS.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagDTS.A_Locked, FXmlTagDTS.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagDTS.A_Name, FXmlTagDTS.D_Name, "DataSet");
                fXmlNode.set_attrVal(FXmlTagDTS.A_Description, FXmlTagDTS.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagDTS.A_FontColor, FXmlTagDTS.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagDTS.A_FontBold, FXmlTagDTS.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeDAT(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagDAT.E_Data);
                // --
                fXmlNode.set_attrVal(FXmlTagDAT.A_UniqueId, FXmlTagDAT.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagDAT.A_Locked, FXmlTagDAT.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagDAT.A_Name, FXmlTagDAT.D_Name, "Data");
                fXmlNode.set_attrVal(FXmlTagDAT.A_Description, FXmlTagDAT.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagDAT.A_FontColor, FXmlTagDAT.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagDAT.A_FontBold, FXmlTagDAT.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagDAT.A_SourceType, FXmlTagDAT.D_SourceType, "C");
                fXmlNode.set_attrVal(FXmlTagDAT.A_SourceConstant, FXmlTagDAT.D_SourceConstant, "Constant");
                fXmlNode.set_attrVal(FXmlTagDAT.A_SourceResource, FXmlTagDAT.D_SourceResource, "");
                fXmlNode.set_attrVal(FXmlTagDAT.A_SourceEnvironment, FXmlTagDAT.D_SourceEnvironment, "");
                fXmlNode.set_attrVal(FXmlTagDAT.A_SourceColumn, FXmlTagDAT.D_SourceColumn, "");
                fXmlNode.set_attrVal(FXmlTagDAT.A_SourceItem, FXmlTagDAT.D_SourceItem, "");
                // --
                fXmlNode.set_attrVal(FXmlTagDAT.A_TargetType, FXmlTagDAT.D_TargetType, "C");
                fXmlNode.set_attrVal(FXmlTagDAT.A_TargetConstant, FXmlTagDAT.D_TargetConstant, "Constant");
                fXmlNode.set_attrVal(FXmlTagDAT.A_TargetColumn, FXmlTagDAT.D_TargetColumn, "");
                fXmlNode.set_attrVal(FXmlTagDAT.A_TargetItem, FXmlTagDAT.D_TargetItem, "");
                // --                
                fXmlNode.set_attrVal(FXmlTagDAT.A_Pattern, FXmlTagDAT.D_Pattern, "F");
                fXmlNode.set_attrVal(FXmlTagDAT.A_FixedLength, FXmlTagDAT.D_FixedLength, FXmlTagDAT.D_FixedLength);
                fXmlNode.set_attrVal(FXmlTagDAT.A_Format, FXmlTagDAT.D_Format, "L");
                // --
                fXmlNode.set_attrVal(FXmlTagDAT.A_ScanMode, FXmlTagDAT.D_ScanMode, FXmlTagDAT.D_ScanMode);
                // --
                fXmlNode.set_attrVal(FXmlTagDAT.A_Value, FXmlTagDAT.D_Value, FXmlTagDAT.D_Value);
                fXmlNode.set_attrVal(FXmlTagDAT.A_Length, FXmlTagDAT.D_Length, FXmlTagDAT.D_Length);
                // --
                fXmlNode.set_attrVal(FXmlTagDAT.A_Transformer, FXmlTagDAT.D_Transformer, FXmlTagDAT.D_Transformer);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodePSN(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPSN.E_PlcSession);
                // --
                fXmlNode.set_attrVal(FXmlTagPSN.A_UniqueId, FXmlTagPSN.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagPSN.A_Locked, FXmlTagPSN.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagPSN.A_Name, FXmlTagPSN.D_Name, "PlcSession");
                fXmlNode.set_attrVal(FXmlTagPSN.A_Description, FXmlTagPSN.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPSN.A_FontColor, FXmlTagPSN.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagPSN.A_FontBold, FXmlTagPSN.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagPSN.A_SessionId, FXmlTagPSN.D_SessionId, "0");
                fXmlNode.set_attrVal(FXmlTagPSN.A_PlcLibraryId, FXmlTagPSN.D_PlcLibraryId, FXmlTagPSN.D_PlcLibraryId);
                //--
                fXmlNode.set_attrVal(FXmlTagPSN.A_ScanTime, FXmlTagPSN.D_ScanTime, FXmlTagPSN.D_ScanTime);
                fXmlNode.set_attrVal(FXmlTagPSN.A_ReadBitDeviceCode, FXmlTagPSN.D_ReadBitDeviceCode, FXmlTagPSN.D_ReadBitDeviceCode);
                fXmlNode.set_attrVal(FXmlTagPSN.A_ReadBitStartAddress, FXmlTagPSN.D_ReadBitStartAddress, FXmlTagPSN.D_ReadBitStartAddress);
                fXmlNode.set_attrVal(FXmlTagPSN.A_ReadBitLength, FXmlTagPSN.D_ReadBitLength, FXmlTagPSN.D_ReadBitLength);
                fXmlNode.set_attrVal(FXmlTagPSN.A_ReadWordDeviceCode, FXmlTagPSN.D_ReadWordDeviceCode, FXmlTagPSN.D_ReadWordDeviceCode);
                fXmlNode.set_attrVal(FXmlTagPSN.A_ReadWordStartAddress, FXmlTagPSN.D_ReadWordStartAddress, FXmlTagPSN.D_ReadWordStartAddress);
                fXmlNode.set_attrVal(FXmlTagPSN.A_ReadWordLength, FXmlTagPSN.D_ReadWordLength, FXmlTagPSN.D_ReadWordLength);
                fXmlNode.set_attrVal(FXmlTagPSN.A_WriteBitDeviceCode, FXmlTagPSN.D_WriteBitDeviceCode, FXmlTagPSN.D_WriteBitDeviceCode);
                fXmlNode.set_attrVal(FXmlTagPSN.A_WriteBitStartAddress, FXmlTagPSN.D_WriteBitStartAddress, FXmlTagPSN.D_WriteBitStartAddress);
                fXmlNode.set_attrVal(FXmlTagPSN.A_WriteBitLength, FXmlTagPSN.D_WriteBitLength, FXmlTagPSN.D_WriteBitLength);
                fXmlNode.set_attrVal(FXmlTagPSN.A_WriteWordDeviceCode, FXmlTagPSN.D_WriteWordDeviceCode, FXmlTagPSN.D_WriteWordDeviceCode);
                fXmlNode.set_attrVal(FXmlTagPSN.A_WriteWordStartAddress, FXmlTagPSN.D_WriteWordStartAddress, FXmlTagPSN.D_WriteWordStartAddress);
                fXmlNode.set_attrVal(FXmlTagPSN.A_WriteWordLength, FXmlTagPSN.D_WriteWordLength, FXmlTagPSN.D_WriteWordLength);
                //--
                fXmlNode.set_attrVal(FXmlTagPSN.A_AutoClear, FXmlTagPSN.D_AutoClear, FXmlTagPSN.D_AutoClear);
                
                // --

                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeHLM(
            FXmlDocument fXmlDoc
            )
        {
            try
            {
                return fXmlDoc.createNode(FXmlTagHLM.E_HostLibraryModeling);
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

        public static FXmlNode createXmlNodeHLG(
             FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagHLG.E_HostLibraryGroup);
                // --
                fXmlNode.set_attrVal(FXmlTagHLG.A_UniqueId, FXmlTagHLG.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagHLG.A_Locked, FXmlTagHLG.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagHLG.A_Name, FXmlTagHLG.D_Name, "HostLibraryGroup");
                fXmlNode.set_attrVal(FXmlTagHLG.A_Description, FXmlTagHLG.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagHLG.A_FontColor, FXmlTagHLG.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagHLG.A_FontBold, FXmlTagHLG.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeHLB(
            FXmlDocument FxmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = FxmlDoc.createNode(FXmlTagHLB.E_HostLibrary);
                // --
                fXmlNode.set_attrVal(FXmlTagHLB.A_UniqueId, FXmlTagHLB.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagHLB.A_Locked, FXmlTagHLB.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagHLB.A_Name, FXmlTagHLB.D_Name, "HostLibrary");
                fXmlNode.set_attrVal(FXmlTagHLB.A_Description, FXmlTagHLB.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagHLB.A_FontColor, FXmlTagHLB.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagHLB.A_FontBold, FXmlTagHLB.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagHLB.A_Comment, FXmlTagHLB.D_Comment, FXmlTagHLB.D_Comment);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeHML(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagHML.E_HostMessageList);
                // --
                fXmlNode.set_attrVal(FXmlTagHML.A_UniqueId, FXmlTagHML.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagHML.A_Locked, FXmlTagHML.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagHML.A_Name, FXmlTagHML.D_Name, "HostMessageList");
                fXmlNode.set_attrVal(FXmlTagHML.A_Description, FXmlTagHML.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagHML.A_FontColor, FXmlTagHML.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagHML.A_FontBold, FXmlTagHML.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeHMS(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagHMS.E_HostMessages);
                // --
                fXmlNode.set_attrVal(FXmlTagHMS.A_UniqueId, FXmlTagHMS.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagHMS.A_Locked, FXmlTagHMS.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagHMS.A_Name, FXmlTagHMS.D_Name, "HostMessages");
                fXmlNode.set_attrVal(FXmlTagHMS.A_Description, FXmlTagHMS.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagHMS.A_FontColor, FXmlTagHMS.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagHMS.A_FontBold, FXmlTagHMS.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagHMS.A_Command, FXmlTagHMS.D_Command, "Command");
                fXmlNode.set_attrVal(FXmlTagHMS.A_Version, FXmlTagHMS.D_Version, "0");
                fXmlNode.set_attrVal(FXmlTagHMS.A_Direction, FXmlTagHMS.D_Direction, FEnumConverter.fromDirection(FDirection.Both));
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeHMG(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagHMG.E_HostMessage);
                // --
                fXmlNode.set_attrVal(FXmlTagHMG.A_MessageType, FXmlTagHMG.D_MessageType, FXmlTagHMG.M_Message);
                // --
                fXmlNode.set_attrVal(FXmlTagHMG.A_UniqueId, FXmlTagHMG.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagHMG.A_Locked, FXmlTagHMG.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagHMG.A_Name, FXmlTagHMG.D_Name, "HostMessage");
                fXmlNode.set_attrVal(FXmlTagHMG.A_Description, FXmlTagHMG.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagHMG.A_FontColor, FXmlTagHMG.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagHMG.A_FontBold, FXmlTagHMG.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagHMG.A_Command, FXmlTagHMG.D_Command, "Command");
                fXmlNode.set_attrVal(FXmlTagHMG.A_Version, FXmlTagHMG.D_Version, "0");
                fXmlNode.set_attrVal(FXmlTagHMG.A_HostMessageType, FXmlTagHMG.D_HostMessageType, "C");
                // --
                fXmlNode.set_attrVal(FXmlTagHMG.A_AutoReply, FXmlTagHMG.D_AutoReply, FBoolean.True);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeHMT(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagHMG.E_HostMessage);
                // --
                fXmlNode.set_attrVal(FXmlTagHMG.A_MessageType, FXmlTagHMG.D_MessageType, FXmlTagHMG.M_MessageTransfer);
                // --
                fXmlNode.set_attrVal(FXmlTagHMG.A_UniqueId, FXmlTagHMG.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagHMG.A_Locked, FXmlTagHMG.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagHMG.A_Name, FXmlTagHMG.D_Name, "HostMessage");
                fXmlNode.set_attrVal(FXmlTagHMG.A_Description, FXmlTagHMG.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagHMG.A_FontColor, FXmlTagHMG.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagHMG.A_FontBold, FXmlTagHMG.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagHMG.A_Command, FXmlTagHMG.D_Command, "Command");
                fXmlNode.set_attrVal(FXmlTagHMG.A_Version, FXmlTagHMG.D_Version, "0");
                fXmlNode.set_attrVal(FXmlTagHMG.A_HostMessageType, FXmlTagHMG.D_HostMessageType, "C");
                // --
                fXmlNode.set_attrVal(FXmlTagHMG.A_AutoReply, FXmlTagHMG.D_AutoReply, FBoolean.True);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeHDMG(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagHDMG.E_HostMessage);
                // --
                fXmlNode.set_attrVal(FXmlTagHDMG.A_MessageType, FXmlTagHDMG.D_MessageType, FXmlTagHDMG.M_HostDriverDataMessage);
                // --
                fXmlNode.set_attrVal(FXmlTagHDMG.A_UniqueId, FXmlTagHDMG.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagHDMG.A_Name, FXmlTagHDMG.D_Name, "HostMessage");
                fXmlNode.set_attrVal(FXmlTagHDMG.A_Description, FXmlTagHDMG.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagHDMG.A_FontColor, FXmlTagHDMG.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagHDMG.A_FontBold, FXmlTagHDMG.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagHDMG.A_SessionId, FXmlTagHDMG.D_SessionId, "0");
                fXmlNode.set_attrVal(FXmlTagHDMG.A_Command, FXmlTagHDMG.D_Command, "Command");
                fXmlNode.set_attrVal(FXmlTagHDMG.A_Version, FXmlTagHDMG.D_Version, "0");
                fXmlNode.set_attrVal(FXmlTagHDMG.A_HostMessageType, FXmlTagHDMG.D_HostMessageType, "C");
                fXmlNode.set_attrVal(FXmlTagHDMG.A_TID, FXmlTagHDMG.D_TID, "0");
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeHIT(
            FXmlDocument fXmlDoc
            )
        {
            try
            {
                return createXmlNodeHIT(fXmlDoc, "HostItem", FFormat.List, string.Empty);
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

        public static FXmlNode createXmlNodeHIT(
            FXmlDocument fXmlDoc,
            string name,
            FFormat fFormat,
            string stringValue
            )
        {
            FXmlNode fXmlNode = null;
            int length = 0;
            string val = string.Empty;

            try
            {
                FPlcDriverCommon.validateName(name, true);

                // --

                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                {
                    length = 0;
                    val = string.Empty;
                }
                else
                {
                    val = FValueConverter.fromStringValue(fFormat, stringValue, out length);
                }

                fXmlNode = fXmlDoc.createNode(FXmlTagHIT.E_HostItem);
                // --
                fXmlNode.set_attrVal(FXmlTagHIT.A_UniqueId, FXmlTagHIT.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagHIT.A_Locked, FXmlTagHIT.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagHIT.A_Name, FXmlTagHIT.D_Name, name);
                fXmlNode.set_attrVal(FXmlTagHIT.A_Description, FXmlTagHIT.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagHIT.A_FontColor, FXmlTagHIT.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagHIT.A_FontBold, FXmlTagHIT.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern, "F");
                fXmlNode.set_attrVal(FXmlTagHIT.A_FixedLength, FXmlTagHIT.D_FixedLength, FXmlTagHIT.D_FixedLength);
                fXmlNode.set_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format, FEnumConverter.fromFormat(fFormat));
                // --
                fXmlNode.set_attrVal(FXmlTagHIT.A_ScanMode, FXmlTagHIT.D_ScanMode, FXmlTagHIT.D_ScanMode);
                // --
                fXmlNode.set_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value, val);
                fXmlNode.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, length.ToString());
                // --
                fXmlNode.set_attrVal(FXmlTagHIT.A_Transformer, FXmlTagHIT.D_Transformer, FXmlTagHIT.D_Transformer);
                // --
                fXmlNode.set_attrVal(FXmlTagHIT.A_Precondition, FXmlTagHIT.D_Precondition, FXmlTagHIT.D_Precondition);
                // --
                fXmlNode.set_attrVal(FXmlTagHIT.A_ReservedWord, FXmlTagHIT.D_ReservedWord, FXmlTagHIT.D_ReservedWord);
                fXmlNode.set_attrVal(FXmlTagHIT.A_Extraction, FXmlTagHIT.D_Extraction, FXmlTagHIT.D_Extraction);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeHDM(
            FXmlDocument fXmlDoc
            )
        {
            try
            {
                return fXmlDoc.createNode(FXmlTagHDM.E_HostDeviceModeling);
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

        public static FXmlNode createXmlNodeHDV(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagHDV.E_HostDevice);
                // --
                fXmlNode.set_attrVal(FXmlTagHDV.A_UniqueId, FXmlTagHDV.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagHDV.A_Locked, FXmlTagHDV.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagHDV.A_Name, FXmlTagHDV.D_Name, "HostDevice");
                fXmlNode.set_attrVal(FXmlTagHDV.A_Description, FXmlTagHDV.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagHDV.A_FontColor, FXmlTagHDV.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagHDV.A_FontBold, FXmlTagHDV.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagHDV.A_Mode, FXmlTagHDV.D_Mode, FXmlTagHDV.D_Mode);
                fXmlNode.set_attrVal(FXmlTagHDV.A_Driver, FXmlTagHDV.D_Driver, FXmlTagHDV.D_Driver);
                fXmlNode.set_attrVal(FXmlTagHDV.A_DriverDescription, FXmlTagHDV.D_DriverDescription, FXmlTagHDV.D_DriverDescription);
                fXmlNode.set_attrVal(FXmlTagHDV.A_DriverOption, FXmlTagHDV.D_DriverOption, FXmlTagHDV.D_DriverOption);
                // --
                fXmlNode.set_attrVal(FXmlTagHDV.A_TransactionTimeout, FXmlTagHDV.D_TransactionTimeout, FXmlTagHDV.D_TransactionTimeout);
                // --
                fXmlNode.set_attrVal(FXmlTagHDV.A_State, FXmlTagHDV.D_State, FXmlTagHDV.D_State);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeHSN(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagHSN.E_HostSession);
                // --
                fXmlNode.set_attrVal(FXmlTagHSN.A_UniqueId, FXmlTagHSN.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagHSN.A_Locked, FXmlTagHSN.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagHSN.A_Name, FXmlTagHSN.D_Name, "HostSession");
                fXmlNode.set_attrVal(FXmlTagHSN.A_Description, FXmlTagHSN.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagHSN.A_FontColor, FXmlTagHSN.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagHSN.A_FontBold, FXmlTagHSN.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagHSN.A_SessionId, FXmlTagHSN.D_SessionId, "0");
                fXmlNode.set_attrVal(FXmlTagHSN.A_HostLibraryId, FXmlTagHSN.D_HostLibraryId, FXmlTagHSN.D_HostLibraryId);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeEQM(
            FXmlDocument fXmlDoc
            )
        {
            try
            {
                return fXmlDoc.createNode(FXmlTagEQM.E_EquipmentModeling);
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

        public static FXmlNode createXmlNodeEQP(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagEQP.E_Equipment);
                // --
                fXmlNode.set_attrVal(FXmlTagEQP.A_UniqueId, FXmlTagEQP.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagEQP.A_Locked, FXmlTagEQP.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagEQP.A_Name, FXmlTagEQP.D_Name, "Equipment");
                fXmlNode.set_attrVal(FXmlTagEQP.A_Description, FXmlTagEQP.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagEQP.A_FontColor, FXmlTagEQP.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagEQP.A_FontBold, FXmlTagEQP.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeSNG(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagSNG.E_ScenarioGroup);
                // --
                fXmlNode.set_attrVal(FXmlTagSNG.A_UniqueId, FXmlTagSNG.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagSNG.A_Locked, FXmlTagSNG.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagSNG.A_Name, FXmlTagSNG.D_Name, "ScenarioGroup");
                fXmlNode.set_attrVal(FXmlTagSNG.A_Description, FXmlTagSNG.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagSNG.A_FontColor, FXmlTagSNG.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagSNG.A_FontBold, FXmlTagSNG.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagSNG.A_EquipmentAlias, FXmlTagSNG.D_EquipmentAlias, FXmlTagSNG.D_EquipmentAlias);
                fXmlNode.set_attrVal(FXmlTagSNG.A_EapAlias, FXmlTagSNG.D_EapAlias, FXmlTagSNG.D_EapAlias);
                fXmlNode.set_attrVal(FXmlTagSNG.A_HostAlias, FXmlTagSNG.D_HostAlias, FXmlTagSNG.D_HostAlias);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeSNR(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagSNR.E_Scenario);
                // --
                fXmlNode.set_attrVal(FXmlTagSNR.A_UniqueId, FXmlTagSNR.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagSNR.A_Locked, FXmlTagSNR.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagSNR.A_Name, FXmlTagSNR.D_Name, "Scenario");
                fXmlNode.set_attrVal(FXmlTagSNR.A_Description, FXmlTagSNR.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagSNR.A_FontColor, FXmlTagSNR.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagSNR.A_FontBold, FXmlTagSNR.D_FontBold, FBoolean.False);
                // --                
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodePTR(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPTR.E_PlcTrigger);
                // --
                fXmlNode.set_attrVal(FXmlTagPTR.A_UniqueId, FXmlTagPTR.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagPTR.A_Name, FXmlTagPTR.D_Name, "PlcTrigger");
                fXmlNode.set_attrVal(FXmlTagPTR.A_Description, FXmlTagPTR.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPTR.A_FontColor, FXmlTagPTR.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagPTR.A_FontBold, FXmlTagPTR.D_FontBold, FBoolean.False);
                // --                
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodePCN(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPCN.E_PlcCondition);
                // --
                fXmlNode.set_attrVal(FXmlTagPCN.A_UniqueId, FXmlTagPCN.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagPCN.A_Name, FXmlTagPCN.D_Name, "PlcCondition");
                fXmlNode.set_attrVal(FXmlTagPCN.A_Description, FXmlTagPCN.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPCN.A_FontColor, FXmlTagPCN.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagPCN.A_FontBold, FXmlTagPCN.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagPCN.A_ConditionMode, FXmlTagPCN.D_ConditionMode, "E");
                // --
                fXmlNode.set_attrVal(FXmlTagPCN.A_PlcDeviceId, FXmlTagPCN.D_PlcDeviceId, string.Empty);
                fXmlNode.set_attrVal(FXmlTagPCN.A_PlcSessionId, FXmlTagPCN.D_PlcSessionId, string.Empty);
                fXmlNode.set_attrVal(FXmlTagPCN.A_PlcMessageId, FXmlTagPCN.D_PlcMessageId, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPCN.A_ConnectionState, FXmlTagPCN.D_ConnectionState, FXmlTagPCN.D_ConnectionState);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodePEP(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPEP.E_PlcExpression);
                // --
                fXmlNode.set_attrVal(FXmlTagPEP.A_UniqueId, FXmlTagPEP.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagPEP.A_Name, FXmlTagPEP.D_Name, "PlcExpression");
                fXmlNode.set_attrVal(FXmlTagPEP.A_Description, FXmlTagPEP.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPEP.A_FontColor, FXmlTagPEP.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagPEP.A_FontBold, FXmlTagPEP.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagPEP.A_Logical, FXmlTagPEP.D_Logical, "A");
                // --
                fXmlNode.set_attrVal(FXmlTagPEP.A_ExpressionType, FXmlTagPEP.D_ExpressionType, "C");
                fXmlNode.set_attrVal(FXmlTagPEP.A_ComparisonMode, FXmlTagPEP.D_ComparisonMode, "V");
                // --
                fXmlNode.set_attrVal(FXmlTagPEP.A_OperandType, FXmlTagPEP.D_OperandType, "S");
                fXmlNode.set_attrVal(FXmlTagPEP.A_OperandId, FXmlTagPEP.D_OperandId, string.Empty);
                fXmlNode.set_attrVal(FXmlTagPEP.A_OperandFormat, FXmlTagPEP.D_OperandFormat, "A");
                fXmlNode.set_attrVal(FXmlTagPEP.A_OperandIndex, FXmlTagPEP.D_OperandIndex, "0");
                // --
                fXmlNode.set_attrVal(FXmlTagPEP.A_Operation, FXmlTagPEP.D_Operation, "E");
                // --
                fXmlNode.set_attrVal(FXmlTagPEP.A_Value, FXmlTagPEP.D_Value, "");
                fXmlNode.set_attrVal(FXmlTagHEP.A_Transformer, FXmlTagHEP.D_Transformer, "");
                // --

                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodePTN(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPTN.E_PlcTransmitter);
                // --
                fXmlNode.set_attrVal(FXmlTagPTN.A_UniqueId, FXmlTagPTN.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagPTN.A_Name, FXmlTagPTN.D_Name, "PlcTransmitter");
                fXmlNode.set_attrVal(FXmlTagPTN.A_Description, FXmlTagPTN.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPTN.A_FontColor, FXmlTagPTN.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagPTN.A_FontBold, FXmlTagPTN.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagPTN.A_AutoActionFirstSelect, FXmlTagPTN.D_AutoActionFirstSelect, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagPTN.A_AutoActionFirstClose, FXmlTagPTN.D_AutoActionFirstClose, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagPTN.A_AutoActionAlwaysSelect, FXmlTagPTN.D_AutoActionAlwaysSelect, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagPTN.A_AutoActionAlwaysClose, FXmlTagPTN.D_AutoActionAlwaysClose, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagPTN.A_UsedAutoCycle, FXmlTagPTN.D_UsedAutoCycle, FXmlTagPTN.D_UsedAutoCycle);
                fXmlNode.set_attrVal(FXmlTagPTN.A_AutoCyclePeriod, FXmlTagPTN.D_AutoCyclePeriod, FXmlTagPTN.D_AutoCyclePeriod);
                fXmlNode.set_attrVal(FXmlTagPTN.A_AutoCycleAction, FXmlTagPTN.D_AutoCycleAction, FXmlTagPTN.D_AutoCycleAction);
                // --                
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodePTF(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPTF.E_PlcTransfer);
                // --
                fXmlNode.set_attrVal(FXmlTagPTF.A_UniqueId, FXmlTagPTF.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagPTF.A_Name, FXmlTagPTF.D_Name, "PlcTransfer");
                fXmlNode.set_attrVal(FXmlTagPTF.A_Description, FXmlTagPTF.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPTF.A_FontColor, FXmlTagPTF.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagPTF.A_FontBold, FXmlTagPTF.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagPTF.A_PlcDeviceId, FXmlTagPTF.D_PlcDeviceId, string.Empty);
                fXmlNode.set_attrVal(FXmlTagPTF.A_PlcSessionId, FXmlTagPTF.D_PlcSessionId, string.Empty);
                fXmlNode.set_attrVal(FXmlTagPTF.A_PlcMessageId, FXmlTagPTF.D_PlcMessageId, string.Empty);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeJDM(
             FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagJDM.E_Judgement);
                // --
                fXmlNode.set_attrVal(FXmlTagJDM.A_UniqueId, FXmlTagJDM.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagJDM.A_Name, FXmlTagJDM.D_Name, "Judgement");
                fXmlNode.set_attrVal(FXmlTagJDM.A_Description, FXmlTagJDM.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagJDM.A_FontColor, FXmlTagJDM.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagJDM.A_FontBold, FXmlTagJDM.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagJDM.A_UsedBranch, FXmlTagJDM.D_UsedBranch, FXmlTagJDM.D_UsedBranch);
                fXmlNode.set_attrVal(FXmlTagJDM.A_LocationId, FXmlTagJDM.D_LocationId, string.Empty);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeJCN(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagJCN.E_JudgementCondition);
                // --
                fXmlNode.set_attrVal(FXmlTagJCN.A_UniqueId, FXmlTagJCN.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagJCN.A_Name, FXmlTagJCN.D_Name, "JudgementCondition");
                fXmlNode.set_attrVal(FXmlTagJCN.A_Description, FXmlTagJCN.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagJCN.A_FontColor, FXmlTagJCN.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagJCN.A_FontBold, FXmlTagJCN.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagJCN.A_DataSetId, FXmlTagJCN.D_DataSetId, string.Empty);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeJEP(
             FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagJEP.E_JudgementExpression);
                // --
                fXmlNode.set_attrVal(FXmlTagJEP.A_UniqueId, FXmlTagJEP.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagJEP.A_Name, FXmlTagJEP.D_Name, "JudgementExpression");
                fXmlNode.set_attrVal(FXmlTagJEP.A_Description, FXmlTagJEP.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagJEP.A_FontColor, FXmlTagJEP.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagJEP.A_FontBold, FXmlTagJEP.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagJEP.A_Logical, FXmlTagJEP.D_Logical, FXmlTagJEP.D_Logical);
                // --
                fXmlNode.set_attrVal(FXmlTagJEP.A_ExpressionType, FXmlTagJEP.D_ExpressionType, FXmlTagJEP.D_ExpressionType);
                fXmlNode.set_attrVal(FXmlTagJEP.A_ComparisonMode, FXmlTagJEP.D_ComparisonMode, FXmlTagJEP.D_ComparisonMode);
                // --
                fXmlNode.set_attrVal(FXmlTagJEP.A_OperandId, FXmlTagJEP.D_OperandId, string.Empty);
                fXmlNode.set_attrVal(FXmlTagJEP.A_OperandFormat, FXmlTagJEP.D_OperandFormat, "A");
                fXmlNode.set_attrVal(FXmlTagJEP.A_OperandIndexType, FXmlTagJEP.D_OperandIndexType, "A");
                fXmlNode.set_attrVal(FXmlTagJEP.A_OperandIndexOption, FXmlTagJEP.D_OperandIndexOption, "O");
                fXmlNode.set_attrVal(FXmlTagJEP.A_OperandIndex, FXmlTagJEP.D_OperandIndex, "0");
                // --
                fXmlNode.set_attrVal(FXmlTagJEP.A_Operation, FXmlTagJEP.D_Operation, "E");
                // --
                fXmlNode.set_attrVal(FXmlTagJEP.A_OperandValueType, FXmlTagJEP.D_OperandValueType, "V");
                fXmlNode.set_attrVal(FXmlTagJEP.A_OperandValueIndexType, FXmlTagJEP.D_OperandValueIndexType, "A");
                fXmlNode.set_attrVal(FXmlTagJEP.A_OperandValueIndexOption, FXmlTagJEP.D_OperandValueIndexOption, "O");
                fXmlNode.set_attrVal(FXmlTagJEP.A_OperandValueIndex, FXmlTagJEP.D_OperandValueIndex, "0");
                fXmlNode.set_attrVal(FXmlTagJEP.A_Value, FXmlTagJEP.D_Value, string.Empty);
                fXmlNode.set_attrVal(FXmlTagJEP.A_ValueId, FXmlTagJEP.D_ValueId, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagJEP.A_Transformer, FXmlTagJEP.D_Transformer, string.Empty);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeHTR(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagHTR.E_HostTrigger);
                // --
                fXmlNode.set_attrVal(FXmlTagHTR.A_UniqueId, FXmlTagHTR.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagHTR.A_Name, FXmlTagHTR.D_Name, "HostTrigger");
                fXmlNode.set_attrVal(FXmlTagHTR.A_Description, FXmlTagHTR.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagHTR.A_FontColor, FXmlTagHTR.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagHTR.A_FontBold, FXmlTagHTR.D_FontBold, FBoolean.False);
                // --                
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeHCN(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagHCN.E_HostCondition);
                // --
                fXmlNode.set_attrVal(FXmlTagHCN.A_UniqueId, FXmlTagHCN.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagHCN.A_Name, FXmlTagHCN.D_Name, "HostCondition");
                fXmlNode.set_attrVal(FXmlTagHCN.A_Description, FXmlTagHCN.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagHCN.A_FontColor, FXmlTagHCN.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagHCN.A_FontBold, FXmlTagHCN.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagHCN.A_ConditionMode, FXmlTagHCN.D_ConditionMode, "E");
                // --
                fXmlNode.set_attrVal(FXmlTagHCN.A_RetryLimit, FXmlTagHCN.D_RetryLimit, FXmlTagHCN.D_RetryLimit);
                fXmlNode.set_attrVal(FXmlTagHCN.A_RetryCount, FXmlTagHCN.D_RetryCount, FXmlTagHCN.D_RetryCount);
                // --
                fXmlNode.set_attrVal(FXmlTagHCN.A_HostDeviceId, FXmlTagHCN.D_HostDeviceId, string.Empty);
                fXmlNode.set_attrVal(FXmlTagHCN.A_HostSessionId, FXmlTagHCN.D_HostSessionId, string.Empty);
                fXmlNode.set_attrVal(FXmlTagHCN.A_HostMessageId, FXmlTagHCN.D_HostMessageId, string.Empty);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeHEP(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagHEP.E_HostExpression);
                // --
                fXmlNode.set_attrVal(FXmlTagHEP.A_UniqueId, FXmlTagHEP.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagHEP.A_Name, FXmlTagHEP.D_Name, "HostExpression");
                fXmlNode.set_attrVal(FXmlTagHEP.A_Description, FXmlTagHEP.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagHEP.A_FontColor, FXmlTagHEP.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagHEP.A_FontBold, FXmlTagHEP.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagHEP.A_Logical, FXmlTagHEP.D_Logical, "A");
                // --
                fXmlNode.set_attrVal(FXmlTagHEP.A_ExpressionType, FXmlTagHEP.D_ExpressionType, "C");
                fXmlNode.set_attrVal(FXmlTagHEP.A_ComparisonMode, FXmlTagHEP.D_ComparisonMode, "V");
                // --
                fXmlNode.set_attrVal(FXmlTagHEP.A_OperandType, FXmlTagHEP.D_OperandType, "H");
                fXmlNode.set_attrVal(FXmlTagHEP.A_OperandId, FXmlTagHEP.D_OperandId, string.Empty);
                fXmlNode.set_attrVal(FXmlTagHEP.A_OperandFormat, FXmlTagHEP.D_OperandFormat, "A");
                fXmlNode.set_attrVal(FXmlTagHEP.A_OperandIndex, FXmlTagHEP.D_OperandIndex, "0");
                // --
                fXmlNode.set_attrVal(FXmlTagHEP.A_Operation, FXmlTagHEP.D_Operation, "E");
                // --
                fXmlNode.set_attrVal(FXmlTagHEP.A_Value, FXmlTagHEP.D_Value, "");
                fXmlNode.set_attrVal(FXmlTagHEP.A_Transformer, FXmlTagHEP.D_Transformer, "");
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeHTN(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagHTN.E_HostTransmitter);
                // --
                fXmlNode.set_attrVal(FXmlTagHTN.A_UniqueId, FXmlTagHTN.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagHTN.A_Name, FXmlTagHTN.D_Name, "HostTransmitter");
                fXmlNode.set_attrVal(FXmlTagHTN.A_Description, FXmlTagHTN.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagHTN.A_FontColor, FXmlTagHTN.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagHTN.A_FontBold, FXmlTagHTN.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagHTN.A_AutoActionFirstSelect, FXmlTagHTN.D_AutoActionFirstSelect, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagHTN.A_AutoActionFirstClose, FXmlTagHTN.D_AutoActionFirstClose, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagHTN.A_AutoActionAlwaysSelect, FXmlTagHTN.D_AutoActionAlwaysSelect, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagHTN.A_AutoActionAlwaysClose, FXmlTagHTN.D_AutoActionAlwaysClose, FBoolean.False);
                // -
                fXmlNode.set_attrVal(FXmlTagHTN.A_UsedAutoCycle, FXmlTagHTN.D_UsedAutoCycle, FXmlTagHTN.D_UsedAutoCycle);
                fXmlNode.set_attrVal(FXmlTagHTN.A_AutoCyclePeriod, FXmlTagHTN.D_AutoCyclePeriod, FXmlTagHTN.D_AutoCyclePeriod);
                fXmlNode.set_attrVal(FXmlTagHTN.A_AutoCycleAction, FXmlTagHTN.D_AutoCycleAction, FXmlTagHTN.D_AutoCycleAction);
                // --                
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeHTF(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagHTF.E_HostTransfer);
                // --
                fXmlNode.set_attrVal(FXmlTagHTF.A_UniqueId, FXmlTagHTF.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagHTF.A_Name, FXmlTagHTF.D_Name, "HostTransfer");
                fXmlNode.set_attrVal(FXmlTagHTF.A_Description, FXmlTagHTF.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagHTF.A_FontColor, FXmlTagHTF.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagHTF.A_FontBold, FXmlTagHTF.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagHTF.A_HostDeviceId, FXmlTagHTF.D_HostDeviceId, string.Empty);
                fXmlNode.set_attrVal(FXmlTagHTF.A_HostSessionId, FXmlTagHTF.D_HostSessionId, string.Empty);
                fXmlNode.set_attrVal(FXmlTagHTF.A_HostMessageId, FXmlTagHTF.D_HostMessageId, string.Empty);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeCBK(
             FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagCBK.E_Callback);
                // --
                fXmlNode.set_attrVal(FXmlTagCBK.A_UniqueId, FXmlTagCBK.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagCBK.A_Name, FXmlTagCBK.D_Name, "Callback");
                fXmlNode.set_attrVal(FXmlTagCBK.A_Description, FXmlTagCBK.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagCBK.A_FontColor, FXmlTagCBK.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagCBK.A_FontBold, FXmlTagCBK.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeFUN(
             FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagFUN.E_Function);
                // --
                fXmlNode.set_attrVal(FXmlTagFUN.A_UniqueId, FXmlTagFUN.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagFUN.A_Name, FXmlTagFUN.D_Name, "Function");
                fXmlNode.set_attrVal(FXmlTagFUN.A_Description, FXmlTagFUN.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagFUN.A_FontColor, FXmlTagFUN.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagFUN.A_FontBold, FXmlTagFUN.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagFUN.A_FunctionName, FXmlTagFUN.D_FunctionName, string.Empty);
                fXmlNode.set_attrVal(FXmlTagFUN.A_Parameter1, FXmlTagFUN.D_Parameter1, string.Empty);
                fXmlNode.set_attrVal(FXmlTagFUN.A_Parameter2, FXmlTagFUN.D_Parameter2, string.Empty);
                fXmlNode.set_attrVal(FXmlTagFUN.A_Parameter3, FXmlTagFUN.D_Parameter3, string.Empty);
                fXmlNode.set_attrVal(FXmlTagFUN.A_Parameter4, FXmlTagFUN.D_Parameter4, string.Empty);
                fXmlNode.set_attrVal(FXmlTagFUN.A_Parameter5, FXmlTagFUN.D_Parameter5, string.Empty);
                fXmlNode.set_attrVal(FXmlTagFUN.A_ErrorAction, FXmlTagFUN.D_ErrorAction, "S");
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeBRN(
             FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagBRN.E_Branch);
                // --
                fXmlNode.set_attrVal(FXmlTagBRN.A_UniqueId, FXmlTagBRN.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagBRN.A_Name, FXmlTagBRN.D_Name, "Branch");
                fXmlNode.set_attrVal(FXmlTagBRN.A_Description, FXmlTagBRN.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagBRN.A_FontColor, FXmlTagBRN.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagBRN.A_FontBold, FXmlTagBRN.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagBRN.A_LocationId, FXmlTagBRN.D_LocationId, string.Empty);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeCMT(
             FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagCMT.E_Comment);
                // --
                fXmlNode.set_attrVal(FXmlTagCMT.A_UniqueId, FXmlTagCMT.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagCMT.A_Name, FXmlTagCMT.D_Name, "Comment");
                fXmlNode.set_attrVal(FXmlTagCMT.A_Description, FXmlTagCMT.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagCMT.A_FontColor, FXmlTagCMT.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagCMT.A_FontBold, FXmlTagCMT.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }


        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodePAU(
             FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPAU.E_Pauser);
                // --
                fXmlNode.set_attrVal(FXmlTagPAU.A_UniqueId, FXmlTagPAU.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagPAU.A_Name, FXmlTagPAU.D_Name, "Pauser");
                fXmlNode.set_attrVal(FXmlTagPAU.A_Description, FXmlTagPAU.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPAU.A_FontColor, FXmlTagPAU.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagPAU.A_FontBold, FXmlTagPAU.D_FontBold, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagPAU.A_PauseTime, FXmlTagPAU.D_PauseTime, FXmlTagPAU.D_PauseTime);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodePLM(
            FXmlDocument fXmlDoc
            )
        {
            try
            {
                return fXmlDoc.createNode(FXmlTagPLM.E_PlcLibraryModeling);
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

        public static FXmlNode createXmlNodePDM(
            FXmlDocument fXmlDoc
            )
        {
            try
            {
                return fXmlDoc.createNode(FXmlTagPDM.E_PlcDeviceModeling);
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

        public static FXmlNode createXmlNodePDV(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPDV.E_PlcDevice);
                // --
                fXmlNode.set_attrVal(FXmlTagPDV.A_UniqueId, FXmlTagPDV.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagPDV.A_Locked, FXmlTagPDV.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagPDV.A_Name, FXmlTagPDV.D_Name, "PlcDevice");
                fXmlNode.set_attrVal(FXmlTagPDV.A_Description, FXmlTagPDV.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPDV.A_FontColor, FXmlTagPDV.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagPDV.A_FontBold, FXmlTagPDV.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagPDV.A_Protocol, FXmlTagPDV.D_Protocol, FXmlTagPDV.D_Protocol);
                fXmlNode.set_attrVal(FXmlTagPDV.A_LocalIp, FXmlTagPDV.D_LocalIp, FXmlTagPDV.D_LocalIp);
                fXmlNode.set_attrVal(FXmlTagPDV.A_LocalPort, FXmlTagPDV.D_LocalPort, FXmlTagPDV.D_LocalPort);
                fXmlNode.set_attrVal(FXmlTagPDV.A_RemoteIp, FXmlTagPDV.D_RemoteIp, FXmlTagPDV.D_RemoteIp);
                fXmlNode.set_attrVal(FXmlTagPDV.A_RemotePort, FXmlTagPDV.D_RemotePort, FXmlTagPDV.D_RemotePort);
                fXmlNode.set_attrVal(FXmlTagPDV.A_Timeout, FXmlTagPDV.D_Timeout, FXmlTagPDV.D_Timeout);
                // --
                fXmlNode.set_attrVal(FXmlTagPDV.A_State, FXmlTagPDV.D_State, FXmlTagPDV.D_State);
 
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodePML(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPML.E_PlcMessageList);
                // --
                fXmlNode.set_attrVal(FXmlTagPML.A_UniqueId, FXmlTagPML.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagPML.A_Locked, FXmlTagPML.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagPML.A_Name, FXmlTagPML.D_Name, "PlcMessageList");
                fXmlNode.set_attrVal(FXmlTagPML.A_Description, FXmlTagPML.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPML.A_FontColor, FXmlTagPML.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagPML.A_FontBold, FXmlTagPML.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodePMS(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPMS.E_PlcMessages);
                // --
                fXmlNode.set_attrVal(FXmlTagPMS.A_UniqueId, FXmlTagPMS.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagPMS.A_Locked, FXmlTagPMS.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagPMS.A_Name, FXmlTagPMS.D_Name, "PlcMessages");
                fXmlNode.set_attrVal(FXmlTagPMS.A_Description, FXmlTagPMS.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPMS.A_FontColor, FXmlTagPMS.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagPMS.A_FontBold, FXmlTagPMS.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagPMS.A_Direction, FXmlTagPMS.D_Direction, "R");
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodePMG(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;
            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPMG.E_PlcMessage);
                // --
                fXmlNode.set_attrVal(FXmlTagPMG.A_MessageType, FXmlTagPMG.D_MessageType, FXmlTagPMG.M_Message);
                // --
                fXmlNode.set_attrVal(FXmlTagPMG.A_UniqueId, FXmlTagPMG.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagPMG.A_Locked, FXmlTagPMG.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagPMG.A_Name, FXmlTagPMG.D_Name, "PlcMessage");
                fXmlNode.set_attrVal(FXmlTagPMG.A_Description, FXmlTagPMG.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPMG.A_FontColor, FXmlTagPMG.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagPMG.A_FontBold, FXmlTagPMG.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagPMG.A_AutoReply, FXmlTagPMG.D_AutoReply, FBoolean.True);
                fXmlNode.set_attrVal(FXmlTagPMG.A_AutoReset, FXmlTagPMG.D_AutoReset, FBoolean.True);
                // --
                fXmlNode.set_attrVal(FXmlTagPMG.A_LogEnabled, FXmlTagPMG.D_LogEnabled, FBoolean.True);
                // --
                fXmlNode.set_attrVal(FXmlTagPMG.A_IsPrimary, FXmlTagPMG.D_IsPrimary, FBoolean.True);

                // --

                // **
                // PLC Message 생성시 PLC Bit List 와 PLC Word List 를 추가 한다.
                //**
                fXmlNode.appendChild(FPlcDriverCommon.createXmlNodePBL(fXmlDoc));
                fXmlNode.appendChild(FPlcDriverCommon.createXmlNodePWL(fXmlDoc));

                // --

                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodePMT(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;
            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPMT.E_PlcMessage);
                // --
                fXmlNode.set_attrVal(FXmlTagPMT.A_MessageType, FXmlTagPMT.D_MessageType, FXmlTagPMT.M_MessageTransfer);
                // --
                fXmlNode.set_attrVal(FXmlTagPMT.A_UniqueId, FXmlTagPMT.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagPMT.A_Name, FXmlTagPMT.D_Name, "PlcMessage");
                fXmlNode.set_attrVal(FXmlTagPMT.A_Description, FXmlTagPMT.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPMT.A_FontColor, FXmlTagPMT.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagPMT.A_FontBold, FXmlTagPMT.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagPMT.A_AutoReply, FXmlTagPMT.D_AutoReply, FBoolean.True);
                fXmlNode.set_attrVal(FXmlTagPMT.A_AutoReset, FXmlTagPMT.D_AutoReset, FBoolean.True);
                // --
                fXmlNode.set_attrVal(FXmlTagPMT.A_LogEnabled, FXmlTagPMT.D_LogEnabled, FBoolean.True);
                // --
                fXmlNode.set_attrVal(FXmlTagPMT.A_IsPrimary, FXmlTagPMT.D_IsPrimary, FBoolean.True);

                // --

                fXmlNode.appendChild(FPlcDriverCommon.createXmlNodePBL(fXmlDoc));
                fXmlNode.appendChild(FPlcDriverCommon.createXmlNodePWL(fXmlDoc));

                // --

                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodePBL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPBL.E_PlcBitList);
                // --
                fXmlNode.set_attrVal(FXmlTagPBL.A_UniqueId, FXmlTagPBL.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagPBL.A_Locked, FXmlTagPBL.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagPBL.A_Name, FXmlTagPBL.D_Name, "PlcBitList");
                fXmlNode.set_attrVal(FXmlTagPBL.A_Description, FXmlTagPBL.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPBL.A_FontColor, FXmlTagPBL.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagPBL.A_FontBold, FXmlTagPBL.D_FontBold, FBoolean.False);
                // --

                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodePBT(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPBT.E_PlcBit);
                // --
                fXmlNode.set_attrVal(FXmlTagPBT.A_UniqueId, FXmlTagPBT.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagPBT.A_Locked, FXmlTagPBT.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagPBT.A_Name, FXmlTagPBT.D_Name, "PlcBit");
                fXmlNode.set_attrVal(FXmlTagPBT.A_Description, FXmlTagPBT.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPBT.A_FontColor, FXmlTagPBT.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagPBT.A_FontBold, FXmlTagPBT.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagPBT.A_Address, FXmlTagPBT.D_Address, "0");
                fXmlNode.set_attrVal(FXmlTagPBT.A_Length, FXmlTagPBT.D_Length, FXmlTagPBT.D_Length);
                fXmlNode.set_attrVal(FXmlTagPBT.A_Value, FXmlTagPBT.D_Value, "0");
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodePWL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPWL.E_PlcWordList);
                // --
                fXmlNode.set_attrVal(FXmlTagPWL.A_UniqueId, FXmlTagPWL.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagPWL.A_Locked, FXmlTagPWL.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagPWL.A_Name, FXmlTagPWL.D_Name, "PlcWordList");
                fXmlNode.set_attrVal(FXmlTagPWL.A_Description, FXmlTagPWL.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPWL.A_FontColor, FXmlTagPBL.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagPWL.A_FontBold, FXmlTagPWL.D_FontBold, FBoolean.False);
                // --

                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodePWD(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPWD.E_PlcWord);
                // --
                fXmlNode.set_attrVal(FXmlTagPWD.A_UniqueId, FXmlTagPWD.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagPWD.A_Locked, FXmlTagPWD.D_Locked, FBoolean.False);
                fXmlNode.set_attrVal(FXmlTagPWD.A_Name, FXmlTagPWD.D_Name, "PlcWord");
                fXmlNode.set_attrVal(FXmlTagPWD.A_Description, FXmlTagPWD.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPWD.A_FontColor, FXmlTagPWD.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagPWD.A_FontBold, FXmlTagPWD.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagPWD.A_Address, FXmlTagPWD.D_Address, "0");
                fXmlNode.set_attrVal(FXmlTagPWD.A_Length, FXmlTagPWD.D_Length, "1");
                fXmlNode.set_attrVal(FXmlTagPWD.A_Format, FXmlTagPWD.D_Format, FEnumConverter.fromPlcWordFormat(FPlcWordFormat.Ascii));
                // --
                fXmlNode.set_attrVal(FXmlTagPWD.A_Value, FXmlTagPWD.D_Value, "");
                // --
                fXmlNode.set_attrVal(FXmlTagPWD.A_Transformer, FXmlTagPWD.D_Transformer, FXmlTagPWD.D_Transformer);
                // --
                fXmlNode.set_attrVal(FXmlTagPWD.A_DataConversionSetID, FXmlTagPWD.D_DataConversionSetID, FXmlTagPWD.D_DataConversionSetID);
                fXmlNode.set_attrVal(FXmlTagPWD.A_DataConversionSetName, FXmlTagPWD.D_DataConversionSetName, FXmlTagPWD.D_DataConversionSetName);
                fXmlNode.set_attrVal(FXmlTagPWD.A_DataConversionSetExpression, FXmlTagPWD.D_DataConversionSetExpression, FXmlTagPWD.D_DataConversionSetExpression);
                // --
                fXmlNode.set_attrVal(FXmlTagPWD.A_ReservedWord, FXmlTagPWD.D_ReservedWord, FXmlTagPWD.D_ReservedWord);
                fXmlNode.set_attrVal(FXmlTagPWD.A_Extraction, FXmlTagPWD.D_Extraction, FXmlTagPWD.D_Extraction);

                // --
                
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNodeETP(
             FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagETP.E_EntryPoint);
                // --
                fXmlNode.set_attrVal(FXmlTagETP.A_UniqueId, FXmlTagETP.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagETP.A_Name, FXmlTagETP.D_Name, "EntryPoint");
                fXmlNode.set_attrVal(FXmlTagETP.A_Description, FXmlTagETP.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagETP.A_FontColor, FXmlTagETP.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagETP.A_FontBold, FXmlTagETP.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FIObject createObject(
            FPcdCore fPcdCore, 
            FXmlNode fXmlNode
            )
        {
            FIObject fObject = null;
            string name = string.Empty;
            string typeValue = string.Empty;

            try
            {
                name = fXmlNode.name;

                // --

                if (name == FXmlTagPCD.E_PlcDriver)
                {
                    fObject = new FPlcDriver(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagONL.E_ObjectNameList)
                {
                    fObject = new FObjectNameList(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagONA.E_ObjectName)
                {
                    fObject = new FObjectName(fPcdCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagFNL.E_FunctionNameList)
                {
                    fObject = new FFunctionNameList(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagFNA.E_FunctionName)
                {
                    fObject = new FFunctionName(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagPAN.E_ParameterName)
                {
                    fObject = new FParameterName(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagARG.E_Argument)
                {
                    fObject = new FArgument(fPcdCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagUTN.E_UserTagName)
                {
                    fObject = new FUserTagName(fPcdCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagDCL.E_DataConversionSetList)
                {
                    fObject = new FDataConversionSetList(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagDCS.E_DataConversionSet)
                {
                    fObject = new FDataConversionSet(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagDCV.E_DataConversion)
                {
                    fObject = new FDataConversion(fPcdCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagESL.E_EquipmentStateSetList)
                {
                    fObject = new FEquipmentStateSetList(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagESS.E_EquipmentStateSet)
                {
                    fObject = new FEquipmentStateSet(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagEST.E_EquipmentState)
                {
                    fObject = new FEquipmentState(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagSTV.E_StateValue)
                {
                    fObject = new FStateValue(fPcdCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagRPL.E_RepositoryList)
                {
                    fObject = new FRepositoryList(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagRPS.E_Repository)
                {
                    typeValue = fXmlNode.get_attrVal(FXmlTagRPS.A_RepositoryType, FXmlTagRPS.D_RepositoryType);
                    if (typeValue == FXmlTagRPS.R_Repository)
                    {
                        fObject = new FRepository(fPcdCore, fXmlNode);
                    }
                    else
                    {
                        fObject = new FRepositoryMaterial(fPcdCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagCOL.E_Column)
                {
                    fObject = new FColumn(fPcdCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagENL.E_EnvironmentList)
                {
                    fObject = new FEnvironmentList(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagENV.E_Environment)
                {
                    fObject = new FEnvironment(fPcdCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagDSL.E_DataSetList)
                {
                    fObject = new FDataSetList(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagDTS.E_DataSet)
                {
                    fObject = new FDataSet(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagDAT.E_Data)
                {
                    fObject = new FData(fPcdCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagPLG.E_PlcLibraryGroup)
                {
                    fObject = new FPlcLibraryGroup(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagPLB.E_PlcLibrary)
                {
                    fObject = new FPlcLibrary(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagPML.E_PlcMessageList)
                {
                    fObject = new FPlcMessageList(fPcdCore, fXmlNode);
                }
                // ***
                else if (name == FXmlTagPMS.E_PlcMessages)
                {
                    fObject = new FPlcMessages(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagPMG.E_PlcMessage)
                {
                    fObject = new FPlcMessage(fPcdCore, fXmlNode);
                }                
                else if (name == FXmlTagPBL.E_PlcBitList)
                {
                    fObject = new FPlcBitList(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagPWL.E_PlcWordList)
                {
                    fObject = new FPlcWordList(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagPBT.E_PlcBit)
                {
                    fObject = new FPlcBit(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagPWD.E_PlcWord)
                {
                    fObject = new FPlcWord(fPcdCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagPDV.E_PlcDevice)
                {
                    fObject = new FPlcDevice(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagPSN.E_PlcSession)
                {
                    fObject = new FPlcSession(fPcdCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagHLG.E_HostLibraryGroup)
                {
                    fObject = new FHostLibraryGroup(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagHLB.E_HostLibrary)
                {
                    fObject = new FHostLibrary(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagHML.E_HostMessageList)
                {
                    fObject = new FHostMessageList(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagHMS.E_HostMessages)
                {
                    fObject = new FHostMessages(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagHMG.E_HostMessage)
                {
                    typeValue = fXmlNode.get_attrVal(FXmlTagHMG.A_MessageType, FXmlTagHMG.D_MessageType);
                    if (typeValue == FXmlTagHMG.M_Message)
                    {
                        fObject = new FHostMessage(fPcdCore, fXmlNode);
                    }
                    else if (typeValue == FXmlTagHMG.M_MessageTransfer)
                    {
                        fObject = new FHostMessage(fPcdCore, fXmlNode);
                    }
                    else if (typeValue == FXmlTagHMG.M_HostDriverDataMessage)
                    {
                        fObject = new FHostDriverDataMessage(fPcdCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagHIT.E_HostItem)
                {
                    fObject = new FHostItem(fPcdCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagHDV.E_HostDevice)
                {
                    fObject = new FHostDevice(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagHSN.E_HostSession)
                {
                    fObject = new FHostSession(fPcdCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagEQP.E_Equipment)
                {
                    fObject = new FEquipment(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagSNG.E_ScenarioGroup)
                {
                    fObject = new FScenarioGroup(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagSNR.E_Scenario)
                {
                    fObject = new FScenario(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagPTR.E_PlcTrigger)
                {
                    fObject = new FPlcTrigger(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagPCN.E_PlcCondition)
                {
                    fObject = new FPlcCondition(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagPEP.E_PlcExpression)
                {
                    fObject = new FPlcExpression(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagPTN.E_PlcTransmitter)
                {
                    fObject = new FPlcTransmitter(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagPTF.E_PlcTransfer)
                {
                    fObject = new FPlcTransfer(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagHTR.E_HostTrigger)
                {
                    fObject = new FHostTrigger(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagHCN.E_HostCondition)
                {
                    fObject = new FHostCondition(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagHEP.E_HostExpression)
                {
                    fObject = new FHostExpression(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagHTN.E_HostTransmitter)
                {
                    fObject = new FHostTransmitter(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagHTF.E_HostTransfer)
                {
                    fObject = new FHostTransfer(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagESA.E_EquipmentStateSetAlterer)
                {
                    fObject = new FEquipmentStateSetAlterer(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagEAT.E_EquipmentStateAlterer)
                {
                    fObject = new FEquipmentStateAlterer(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagJDM.E_Judgement)
                {
                    fObject = new FJudgement(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagJCN.E_JudgementCondition)
                {
                    fObject = new FJudgementCondition(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagJEP.E_JudgementExpression)
                {
                    fObject = new FJudgementExpression(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagMAP.E_Mapper)
                {
                    fObject = new FMapper(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagSTG.E_Storage)
                {
                    fObject = new FStorage(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagCBK.E_Callback)
                {
                    fObject = new FCallback(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagFUN.E_Function)
                {
                    fObject = new FFunction(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagBRN.E_Branch)
                {
                    fObject = new FBranch(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagCMT.E_Comment)
                {
                    fObject = new FComment(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagPAU.E_Pauser)
                {
                    fObject = new FPauser(fPcdCore, fXmlNode);
                }
                else if (name == FXmlTagETP.E_EntryPoint)
                {
                    fObject = new FEntryPoint(fPcdCore, fXmlNode);
                }

                return fObject;
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

        public static FObjectType getObjectType(
            FXmlNode fXmlNode
            )
        {
            FObjectType type = FObjectType.PlcDriver;
            string name = string.Empty;
            string typeValue = string.Empty;

            try
            {
                name = fXmlNode.name;

                // --

                if (name == FXmlTagPCD.E_PlcDriver)
                {
                    type = FObjectType.PlcDriver;
                }
                else if (name == FXmlTagONL.E_ObjectNameList)
                {
                    type = FObjectType.ObjectNameList;
                }
                else if (name == FXmlTagONA.E_ObjectName)
                {
                    type = FObjectType.ObjectName;
                }
                // --
                else if (name == FXmlTagFNL.E_FunctionNameList)
                {
                    type = FObjectType.FunctionNameList;
                }
                else if (name == FXmlTagFNA.E_FunctionName)
                {
                    type = FObjectType.FunctionName;
                }
                else if (name == FXmlTagPAN.E_ParameterName)
                {
                    type = FObjectType.ParameterName;
                }
                else if (name == FXmlTagARG.E_Argument)
                {
                    type = FObjectType.Argument;
                }
                // --
                else if (name == FXmlTagUTN.E_UserTagName)
                {
                    type = FObjectType.UserTagName;
                }
                // --
                else if (name == FXmlTagDCL.E_DataConversionSetList)
                {
                    type = FObjectType.DataConversionSetList;
                }
                else if (name == FXmlTagDCS.E_DataConversionSet)
                {
                    type = FObjectType.DataConversionSet;
                }
                else if (name == FXmlTagDCV.E_DataConversion)
                {
                    type = FObjectType.DataConversion;
                }
                // --
                else if (name == FXmlTagESL.E_EquipmentStateSetList)
                {
                    type = FObjectType.EquipmentStateSetList;
                }
                else if (name == FXmlTagESS.E_EquipmentStateSet)
                {
                    type = FObjectType.EquipmentStateSet;
                }
                else if (name == FXmlTagEST.E_EquipmentState)
                {
                    type = FObjectType.EquipmentState;
                }
                else if (name == FXmlTagSTV.E_StateValue)
                {
                    type = FObjectType.StateValue;
                }
                // --
                else if (name == FXmlTagRPL.E_RepositoryList)
                {
                    type = FObjectType.RepositoryList;
                }
                else if (name == FXmlTagRPS.E_Repository)
                {
                    typeValue = fXmlNode.get_attrVal(FXmlTagRPS.A_RepositoryType, FXmlTagRPS.D_RepositoryType);
                    if (typeValue == FXmlTagRPS.R_Repository)
                    {
                        type = FObjectType.Repository;
                    }
                    else
                    {
                        type = FObjectType.RepositoryMaterial;
                    }
                }
                else if (name == FXmlTagCOL.E_Column)
                {
                    type = FObjectType.Column;
                }
                // --
                else if (name == FXmlTagENL.E_EnvironmentList)
                {
                    type = FObjectType.EnvironmentList;
                }
                else if (name == FXmlTagENV.E_Environment)
                {
                    type = FObjectType.Environment;
                }
                // --
                else if (name == FXmlTagDSL.E_DataSetList)
                {
                    type = FObjectType.DataSetList;
                }
                else if (name == FXmlTagDTS.E_DataSet)
                {
                    type = FObjectType.DataSet;
                }
                else if (name == FXmlTagDAT.E_Data)
                {
                    type = FObjectType.Data;
                }
                // --
                else if (name == FXmlTagPLG.E_PlcLibraryGroup)
                {
                    type = FObjectType.PlcLibraryGroup;
                }
                else if (name == FXmlTagPLB.E_PlcLibrary)
                {
                    type = FObjectType.PlcLibrary;
                }
                else if (name == FXmlTagPML.E_PlcMessageList)
                {
                    type = FObjectType.PlcMessageList;
                }
                else if (name == FXmlTagPMS.E_PlcMessages)
                {
                    type = FObjectType.PlcMessages;
                }
                else if (name == FXmlTagPMG.E_PlcMessage)
                {
                    type = FObjectType.PlcMessage;
                }
                else if (name == FXmlTagPBL.E_PlcBitList)
                {
                    type = FObjectType.PlcBitList;
                }
                else if (name == FXmlTagPBT.E_PlcBit)
                {
                    type = FObjectType.PlcBit;
                }
                else if (name == FXmlTagPWL.E_PlcWordList)
                {
                    type = FObjectType.PlcWordList;
                }
                else if (name == FXmlTagPWD.E_PlcWord)
                {
                    type = FObjectType.PlcWord;
                }
                // --
                else if (name == FXmlTagPDV.E_PlcDevice)
                {
                    type = FObjectType.PlcDevice;
                }
                else if (name == FXmlTagPSN.E_PlcSession)
                {
                    type = FObjectType.PlcSession;
                }
                // --
                else if (name == FXmlTagHLG.E_HostLibraryGroup)
                {
                    type = FObjectType.HostLibraryGroup;
                }
                else if (name == FXmlTagHLB.E_HostLibrary)
                {
                    type = FObjectType.HostLibrary;
                }
                else if (name == FXmlTagHML.E_HostMessageList)
                {
                    type = FObjectType.HostMessageList;
                }
                else if (name == FXmlTagHMS.E_HostMessages)
                {
                    type = FObjectType.HostMessages;
                }
                else if (name == FXmlTagHMG.E_HostMessage)
                {
                    type = FObjectType.HostMessage;

                    typeValue = fXmlNode.get_attrVal(FXmlTagHMG.A_MessageType, FXmlTagHMG.D_MessageType);
                    if (typeValue == FXmlTagHMG.M_Message)
                    {
                        type = FObjectType.HostMessage;
                    }
                    else if (typeValue == FXmlTagHMG.M_MessageTransfer)
                    {
                        type = FObjectType.HostMessageTransfer;
                    }
                    else if (typeValue == FXmlTagHMG.M_HostDriverDataMessage)
                    {
                        type = FObjectType.HostDriverDataMessage;
                    }
                }
                else if (name == FXmlTagHIT.E_HostItem)
                {
                    type = FObjectType.HostItem;
                }
                // --
                else if (name == FXmlTagHDV.E_HostDevice)
                {
                    type = FObjectType.HostDevice;
                }
                else if (name == FXmlTagHSN.E_HostSession)
                {
                    type = FObjectType.HostSession;
                }
                // --
                else if (name == FXmlTagEQP.E_Equipment)
                {
                    type = FObjectType.Equipment;
                }
                else if (name == FXmlTagSNG.E_ScenarioGroup)
                {
                    type = FObjectType.ScenarioGroup;
                }
                else if (name == FXmlTagSNR.E_Scenario)
                {
                    type = FObjectType.Scenario;
                }
                else if (name == FXmlTagPTR.E_PlcTrigger)
                {
                    type = FObjectType.PlcTrigger;
                }
                else if (name == FXmlTagPCN.E_PlcCondition)
                {
                    type = FObjectType.PlcCondition;
                }
                else if (name == FXmlTagPEP.E_PlcExpression)
                {
                    type = FObjectType.PlcExpression;
                }
                else if (name == FXmlTagPTN.E_PlcTransmitter)
                {
                    type = FObjectType.PlcTransmitter;
                }
                else if (name == FXmlTagPTF.E_PlcTransfer)
                {
                    type = FObjectType.PlcTransfer;
                }
                else if (name == FXmlTagHTR.E_HostTrigger)
                {
                    type = FObjectType.HostTrigger;
                }
                else if (name == FXmlTagHCN.E_HostCondition)
                {
                    type = FObjectType.HostCondition;
                }
                else if (name == FXmlTagHEP.E_HostExpression)
                {
                    type = FObjectType.HostExpression;
                }
                else if (name == FXmlTagHTN.E_HostTransmitter)
                {
                    type = FObjectType.HostTransmitter;
                }
                else if (name == FXmlTagHTF.E_HostTransfer)
                {
                    type = FObjectType.HostTransfer;
                }
                else if (name == FXmlTagESA.E_EquipmentStateSetAlterer)
                {
                    type = FObjectType.EquipmentStateSetAlterer;
                }
                else if (name == FXmlTagEAT.E_EquipmentStateAlterer)
                {
                    type = FObjectType.EquipmentStateAlterer;
                }
                else if (name == FXmlTagJDM.E_Judgement)
                {
                    type = FObjectType.Judgement;
                }
                else if (name == FXmlTagJCN.E_JudgementCondition)
                {
                    type = FObjectType.JudgementCondition;
                }
                else if (name == FXmlTagJEP.E_JudgementExpression)
                {
                    type = FObjectType.JudgementExpression;
                }
                else if (name == FXmlTagMAP.E_Mapper)
                {
                    type = FObjectType.Mapper;
                }
                else if (name == FXmlTagSTG.E_Storage)
                {
                    type = FObjectType.Storage;
                }
                else if (name == FXmlTagCBK.E_Callback)
                {
                    type = FObjectType.Callback;
                }
                else if (name == FXmlTagFUN.E_Function)
                {
                    type = FObjectType.Function;
                }
                else if (name == FXmlTagBRN.E_Branch)
                {
                    type = FObjectType.Branch;
                }
                else if (name == FXmlTagCMT.E_Comment)
                {
                    type = FObjectType.Comment;
                }
                else if (name == FXmlTagPAU.E_Pauser)
                {
                    type = FObjectType.Pauser;
                }
                else if (name == FXmlTagETP.E_EntryPoint)
                {
                    type = FObjectType.EntryPoint;
                }

                // --

                return type;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FObjectType.PlcDriver;
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode getObjectXmlNode(
            FIObject fObject
            )
        {
            FXmlNode fXmlNode = null;           

            try
            {
                if (fObject.fObjectType == FObjectType.PlcDriver)
                {
                    fXmlNode = ((FPlcDriver)fObject).fXmlNode;
                }
                // --
                else if (fObject.fObjectType == FObjectType.ObjectNameList)
                {
                    fXmlNode = ((FObjectNameList)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.ObjectName)
                {
                    fXmlNode = ((FObjectName)fObject).fXmlNode;
                }
                // --
                else if (fObject.fObjectType == FObjectType.FunctionNameList)
                {
                    fXmlNode = ((FFunctionNameList)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.FunctionName)
                {
                    fXmlNode = ((FFunctionName)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.ParameterName)
                {
                    fXmlNode = ((FParameterName)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.Argument)
                {
                    fXmlNode = ((FArgument)fObject).fXmlNode;
                }
                // --
                else if (fObject.fObjectType == FObjectType.UserTagName)
                {
                    fXmlNode = ((FUserTagName)fObject).fXmlNode;
                }
                // --
                else if (fObject.fObjectType == FObjectType.DataConversionSetList)
                {
                    fXmlNode = ((FDataConversionSetList)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.DataConversionSet)
                {
                    fXmlNode = ((FDataConversionSet)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.DataConversion)
                {
                    fXmlNode = ((FDataConversion)fObject).fXmlNode;
                }
                // --
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetList)
                {
                    fXmlNode = ((FEquipmentStateSetList)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSet)
                {
                    fXmlNode = ((FEquipmentStateSet)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.EquipmentState)
                {
                    fXmlNode = ((FEquipmentState)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.StateValue)
                {
                    fXmlNode = ((FStateValue)fObject).fXmlNode;
                }
                // --
                else if (fObject.fObjectType == FObjectType.RepositoryList)
                {
                    fXmlNode = ((FRepositoryList)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.Repository)
                {
                    fXmlNode = ((FRepository)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.RepositoryMaterial)
                {
                    fXmlNode = ((FRepositoryMaterial)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.Column)
                {
                    fXmlNode = ((FColumn)fObject).fXmlNode;
                }
                // --
                else if (fObject.fObjectType == FObjectType.EnvironmentList)
                {
                    fXmlNode = ((FEnvironmentList)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.Environment)
                {
                    fXmlNode = ((FEnvironment)fObject).fXmlNode;
                }
                // --
                else if (fObject.fObjectType == FObjectType.DataSetList)
                {
                    fXmlNode = ((FDataSetList)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.DataSet)
                {
                    fXmlNode = ((FDataSet)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.Data)
                {
                    fXmlNode = ((FData)fObject).fXmlNode;
                }
                //--
                else if (fObject.fObjectType == FObjectType.PlcLibraryGroup)
                {
                    fXmlNode = ((FPlcLibraryGroup)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.PlcLibrary)
                {
                    fXmlNode = ((FPlcLibrary)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.PlcMessageList)
                {
                    fXmlNode = ((FPlcMessageList)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.PlcMessages)
                {
                    fXmlNode = ((FPlcMessages)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.PlcMessage)
                {
                    fXmlNode = ((FPlcMessage)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.PlcBitList)
                {
                    fXmlNode = ((FPlcBitList)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.PlcBit)
                {
                    fXmlNode = ((FPlcBit)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.PlcWordList)
                {
                    fXmlNode = ((FPlcWordList)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.PlcWord)
                {
                    fXmlNode = ((FPlcWord)fObject).fXmlNode;
                }
                // --
                else if (fObject.fObjectType == FObjectType.PlcDevice)
                {
                    fXmlNode = ((FPlcDevice)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.PlcSession)
                {
                    fXmlNode = ((FPlcSession)fObject).fXmlNode;
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostLibraryGroup)
                {
                    fXmlNode = ((FHostLibraryGroup)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.HostLibrary)
                {
                    fXmlNode = ((FHostLibrary)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.HostMessageList)
                {
                    fXmlNode = ((FHostMessageList)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.HostMessages)
                {
                    fXmlNode = ((FHostMessages)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.HostMessage)
                {
                    fXmlNode = ((FHostMessage)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.HostMessageTransfer)
                {
                    fXmlNode = ((FHostMessageTransfer)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.HostDriverDataMessage)
                {
                    fXmlNode = ((FHostDriverDataMessage)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.HostItem)
                {
                    fXmlNode = ((FHostItem)fObject).fXmlNode;
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostDevice)
                {
                    fXmlNode = ((FHostDevice)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.HostSession)
                {
                    fXmlNode = ((FHostSession)fObject).fXmlNode;
                }
                // --
                else if (fObject.fObjectType == FObjectType.Equipment)
                {
                    fXmlNode = ((FEquipment)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.ScenarioGroup)
                {
                    fXmlNode = ((FScenarioGroup)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.Scenario)
                {
                    fXmlNode = ((FScenario)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.PlcTrigger)
                {
                    fXmlNode = ((FPlcTrigger)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.PlcCondition)
                {
                    fXmlNode = ((FPlcCondition)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.PlcExpression)
                {
                    fXmlNode = ((FPlcExpression)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.PlcTransmitter)
                {
                    fXmlNode = ((FPlcTransmitter)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.PlcTransfer)
                {
                    fXmlNode = ((FPlcTransfer)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.HostTrigger)
                {
                    fXmlNode = ((FHostTrigger)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.HostCondition)
                {
                    fXmlNode = ((FHostCondition)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.HostExpression)
                {
                    fXmlNode = ((FHostExpression)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.HostTransmitter)
                {
                    fXmlNode = ((FHostTransmitter)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.HostTransfer)
                {
                    fXmlNode = ((FHostTransfer)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    fXmlNode = ((FEquipmentStateSetAlterer)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateAlterer)
                {
                    fXmlNode = ((FEquipmentStateAlterer)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.Judgement)
                {
                    fXmlNode = ((FJudgement)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.JudgementCondition)
                {
                    fXmlNode = ((FJudgementCondition)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.JudgementExpression)
                {
                    fXmlNode = ((FJudgementExpression)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.Mapper)
                {
                    fXmlNode = ((FMapper)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.Storage)
                {
                    fXmlNode = ((FStorage)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.Callback)
                {
                    fXmlNode = ((FCallback)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.Function)
                {
                    fXmlNode = ((FFunction)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.Branch)
                {
                    fXmlNode = ((FBranch)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.Comment)
                {
                    fXmlNode = ((FComment)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.Pauser)
                {
                    fXmlNode = ((FPauser)fObject).fXmlNode;
                }
                else if (fObject.fObjectType == FObjectType.EntryPoint)
                {
                    fXmlNode = ((FEntryPoint)fObject).fXmlNode;
                }

                return fXmlNode;
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

        public static void resetUniqueId(
            FIDPointer64 fIdPointer,
            FXmlNode fXmlNode
            )
        {
            FXmlNodeList fXmlNodeList = null;

            try
            {
                fXmlNodeList = fXmlNode.selectNodes(". | .//*");
                // --
                foreach (FXmlNode n in fXmlNodeList)
                {
                    if (n.fAttributes[FXmlTagCommon.A_UniqueId] == null)
                    {
                        continue;
                    }
                    n.set_attrVal(FXmlTagCommon.A_UniqueId, FXmlTagCommon.D_UniqueId, fIdPointer.uniqueId.ToString());
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeList != null)
                {
                    fXmlNodeList.Dispose();
                    fXmlNodeList = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void resetLocked(
            FXmlNode fXmlNode
            )
        {
            FXmlNodeList fXmlNodeList = null;
            string xpath = string.Empty;

            try
            {
                xpath = ". | .//*[@" + FXmlTagCommon.A_Locked + "='" + FBoolean.True + "']";                
                fXmlNodeList = fXmlNode.selectNodes(xpath);
                // --
                foreach (FXmlNode n in fXmlNodeList)
                {
                    n.set_attrVal(FXmlTagCommon.A_Locked, FXmlTagCommon.D_Locked, FBoolean.False);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeList != null)
                {
                    fXmlNodeList.Dispose();
                    fXmlNodeList = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void resetName(
            FXmlNode fXmlNodeParent,
            FXmlNode fXmlNode
            )
        {
            string xpath = string.Empty;
            string baseName = string.Empty;
            string uniqueName = string.Empty;            
            int index = 0;

            try
            {
                xpath = fXmlNode.name + "[@" + FXmlTagCommon.A_Name + "='{0}']";
                baseName = fXmlNode.get_attrVal(FXmlTagCommon.A_Name, FXmlTagCommon.D_Name);                
                
                // --

                if (fXmlNodeParent.containsNode(string.Format(xpath, baseName)))
                {
                    baseName += "-";
                    // --
                    do
                    {
                        index++;
                        uniqueName = baseName + index.ToString();
                    } while (fXmlNodeParent.containsNode((string.Format(xpath, uniqueName))));
                }
                else
                {
                    uniqueName = baseName;
                }

                // --

                fXmlNode.set_attrVal(FXmlTagCommon.A_Name, FXmlTagCommon.D_Name, uniqueName);
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

        public static void setHostItemRandomValue(
            FXmlNode fXmlNodeMsg
            )
        {
            const string ItemQuery =
                "//" + FXmlTagHIT.E_HostItem + "[@" +
                FXmlTagHIT.A_RandomValue + "='{0}']";

            // --

            FXmlNodeList fXmlNodeListItems = null;

            try
            {
                // ***
                // Item 에 Random Value 가 설정된 Item 을 모두 가져온다.
                // ***
                fXmlNodeListItems = fXmlNodeMsg.selectNodes(string.Format(ItemQuery, FBoolean.True));

                // --

                if (fXmlNodeListItems.count == 0)
                {
                    return;
                }

                // --

                foreach (FXmlNode fXmlNodeItem in fXmlNodeListItems)
                {
                    setRandomValue(fXmlNodeItem);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListItems = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void setPlcWordRandomValue(
            FXmlNode fXmlNodeMsg
            )
        {
            const string ItemQuery =
                "//" + FXmlTagPWD.E_PlcWord + "[@" +
                FXmlTagPWD.A_RandomValue + "='{0}']";

            // --

            FXmlNodeList fXmlNodeListItems = null;

            try
            {
                // Item 에 Random Value 가 설정된 Item 을 모두 가져온다.
                fXmlNodeListItems = fXmlNodeMsg.selectNodes(string.Format(ItemQuery, FBoolean.True));

                // --

                if (fXmlNodeListItems.count == 0)
                    return;

                // --

                foreach (FXmlNode fXmlNodeItem in fXmlNodeListItems)
                {
                    // --

                    setRandomValue(fXmlNodeItem);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListItems = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void setRandomValue(
            FXmlNode fXmlNodeItem
            )
        {
            Random rnd = null;
            string sMin = string.Empty;
            string sMax = string.Empty;
            try
            {
                // --
                rnd = new Random();

                 

                FFormat format = FEnumConverter.toFormat(
                    fXmlNodeItem.get_attrVal(FXmlTagPWD.A_Format, FXmlTagPWD.D_Format)
                    );
                sMin = fXmlNodeItem.get_attrVal(FXmlTagPWD.A_RandomValueMin, FXmlTagPWD.D_RandomValueMin);
                sMax = fXmlNodeItem.get_attrVal(FXmlTagPWD.A_RandomValueMax, FXmlTagPWD.D_RandomValueMax);

                // --

                if (sMin == FXmlTagPWD.D_RandomValueMin &&
                    sMax == FXmlTagPWD.D_RandomValueMax)
                {
                    return;
                }

                // --

                if (format == FFormat.Binary ||
                    format == FFormat.I4 ||
                    format == FFormat.I2 ||
                    format == FFormat.I1)
                {
                    Int64 min = Int64.Parse(sMin);
                    Int64 max = Int64.Parse(sMax);

                    // --
                    
                    Int64 val = (Int64)(rnd.NextDouble() * (max - min) + min);
                    fXmlNodeItem.set_attrVal(FXmlTagPWD.A_Value, FXmlTagPWD.D_Value, val.ToString());
                }
                else if (format == FFormat.I8)
                {
                    Double min = Double.Parse(sMin);
                    Double max = Double.Parse(sMax);

                    // -- 

                    Int64 val = (Int64)(rnd.NextDouble() * (max - min) + min);
                    fXmlNodeItem.set_attrVal(FXmlTagPWD.A_Value, FXmlTagPWD.D_Value, val.ToString());
                }
                else if (
                    format == FFormat.F8 ||
                    format == FFormat.F4)
                {
                    Double min = Double.Parse(sMin);
                    Double max = Double.Parse(sMax);

                    // --

                    Double val = rnd.NextDouble() * (max - min) + min;
                    fXmlNodeItem.set_attrVal(FXmlTagPWD.A_Value, FXmlTagPWD.D_Value, val.ToString());
                }
                else if (format == FFormat.U8 ||
                    format == FFormat.U4 ||
                    format == FFormat.U2 ||
                    format == FFormat.U1)
                {
                    // --
                    UInt64 min = UInt64.Parse(sMin);
                    UInt64 max = UInt64.Parse(sMax);

                    // --

                    UInt64 val = (UInt64)(rnd.NextDouble() * (max - min) + min);
                    fXmlNodeItem.set_attrVal(FXmlTagPWD.A_Value, FXmlTagPWD.D_Value, val.ToString());
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                rnd = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static bool validateFormatRange(
            FFormat format,
            string value
            )
        {
            bool result = true;
            try
            {
                if (format == FFormat.Binary)
                {
                    byte val = 0;
                    result = byte.TryParse(value, out val);
                }
                else if (format == FFormat.I8)
                {
                    Int64 val = 0;
                    result = Int64.TryParse(value, out val);
                }
                else if (format == FFormat.I4)
                {
                    Int32 val = 0;
                    result = Int32.TryParse(value, out val);
                }
                else if (format == FFormat.I2)
                {
                    Int16 val = 0;
                    result = Int16.TryParse(value, out val);
                }
                else if (format == FFormat.I1)
                {
                    sbyte val = 0;
                    result = sbyte.TryParse(value, out val);
                }
                else if (format == FFormat.F8)
                {
                    double val = 0;
                    result = double.TryParse(value, out val);
                }
                else if (format == FFormat.F4)
                {
                    float val = 0;
                    result = float.TryParse(value, out val);
                }
                else if (format == FFormat.U8)
                {
                    UInt64 val = 0;
                    result = UInt64.TryParse(value, out val);
                }
                else if (format == FFormat.U4)
                {
                    UInt32 val = 0;
                    result = UInt32.TryParse(value, out val);
                }
                else if (format == FFormat.U2)
                {
                    UInt16 val = 0;
                    result = UInt16.TryParse(value, out val);
                }
                else if (format == FFormat.U1)
                {
                    byte val = 0;
                    result = byte.TryParse(value, out val);
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

        //------------------------------------------------------------------------------------------------------------------------

        public static bool validateMinMax(
            FFormat format,
            string min,
            string max
            )
        {
            object oValMin = null;
            object oValMax = null;
            bool result = false;
            try
            {
                if (min == string.Empty || max == string.Empty)
                    return true;

                oValMin = FValueConverter.toValue(format, min);
                oValMax = FValueConverter.toValue(format, max);

                // --

                if (format == FFormat.Binary)
                {
                    result = ((byte)oValMin < (byte)oValMax ? true : false);
                }
                else if (format == FFormat.I8)
                {
                    result = ((Int64)oValMin < (Int64)oValMax ? true : false);
                }
                else if (format == FFormat.I4)
                {
                    result = ((Int32)oValMin < (Int32)oValMax ? true : false);
                }
                else if (format == FFormat.I2)
                {
                    result = ((Int16)oValMin < (Int16)oValMax ? true : false);
                }
                else if (format == FFormat.I1)
                {
                    result = ((sbyte)oValMin < (sbyte)oValMax ? true : false);
                }
                else if (format == FFormat.F8)
                {
                    result = ((double)oValMin < (double)oValMax ? true : false);
                }
                else if (format == FFormat.F4)
                {
                    result = ((float)oValMin < (float)oValMax ? true : false);
                }
                else if (format == FFormat.U8)
                {
                    result = ((UInt64)oValMin < (UInt64)oValMax ? true : false);
                }
                else if (format == FFormat.U4)
                {
                    result = ((UInt32)oValMin < (UInt32)oValMax ? true : false);
                }
                else if (format == FFormat.U2)
                {
                    result = ((UInt16)oValMin < (UInt16)oValMax ? true : false);
                }
                else if (format == FFormat.U1)
                {
                    result = ((byte)oValMin < (byte)oValMax ? true : false);
                }
                return result;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                oValMin = null;
                oValMax = null;
            }
            return false;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
