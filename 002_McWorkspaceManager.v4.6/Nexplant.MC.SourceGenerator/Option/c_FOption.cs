/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOption.cs
--  Creator         : baehyun.seo
--  Create Date     : 2011.11.14
--  Description     : FAMate SQL Manager Option Class 
--  History         : Created by baehyun seo at 2011.11.14
                    : Modified by kitae at 2012.03.20
                        - Recent Library 
                        - CreateOption
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;


namespace Nexplant.MC.SourceGenerator
{
    public class FOption : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FScgCore m_fScgCore = null;
        private FXmlDocument m_optionFXmlDoc = null;
        // --
        private string m_optionFileName = string.Empty;
        private string m_optionSavePath = string.Empty;
        private string m_optionCreator = string.Empty;
        private string m_optionDescription = string.Empty;
        private string m_optionCopyright = string.Empty;
        private string m_optionUsingNamespace = string.Empty;            
        // --
        private string m_paramGenerator = string.Empty;
        private string m_funcGenerator = string.Empty;
        private string m_h101BaseGenerator = string.Empty;
        private string m_internalClass = string.Empty;        
        private string m_oldFilesClear = string.Empty;
        // --
        private string m_recentOpenPath = string.Empty;
        private string m_recentSavePath = string.Empty;
        // --
        private List<string> m_recentFileList = null;
        // --
        private bool m_isConnect = false;
        // --
        private string m_fontName = string.Empty;        
        private float m_fontSize = 0;
        // --
        private FFormList m_fChildFormList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOption(
            FScgCore fScgCore
            )
        {
            m_fScgCore = fScgCore;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOption(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                term();
                // --
                m_fScgCore = null;
            }
            m_disposed = true;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region IDisposable member

        public void Dispose(
            )
        {
            myDispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public string optionFileName
        {
            get 
            {
                try
                {
                    return m_optionFileName;
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
            
            set
            {
                try
                {
                    m_optionFileName = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string fontName
        {
            get
            {
                try
                {
                    return m_fontName;
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

            set
            {
                try
                {
                    m_fontName = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }                
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public float fontSize
        {
            get
            {
                try
                {
                    return m_fontSize;
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

            set
            {
                try
                {
                    m_fontSize = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }                
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string optionSavePath
        {
            get 
            {
                try
                {
                    return m_optionSavePath;
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
            
            set
            {
                try
                {
                    m_optionSavePath = value; 
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string optionCreator
        {
            get
            {
                try
                {
                    return m_optionCreator;
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
            
            set 
            {
                try
                {
                    m_optionCreator = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string optionDescription
        {
            get 
            {
                try
                {
                    return m_optionDescription;
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
            
            set
            {
                try
                {
                    m_optionDescription = value; 
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string optionCopyright
        {
            get 
            {
                try
                {
                    return m_optionCopyright;
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

            set
            {
                try
                {
                    m_optionCopyright = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
 
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string optionUsingNamespace
        {
            get 
            {
                try
                {
                    return m_optionUsingNamespace; 
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
            
            set 
            {
                try
                {
                    m_optionUsingNamespace = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
 
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool isConnect
        {
            get
            {
                try
                {
                    return m_isConnect;
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
            
            set 
            {
                try
                {
                    m_isConnect = value; 
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string recentOpenPath
        {
            get
            {
                try
                {
                    return m_recentOpenPath;
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

            set
            {
                try
                {
                    m_recentOpenPath = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string recentSavePath
        {
            get
            {
                try
                {
                    return m_recentSavePath;
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

            set
            {
                try
                {
                    m_recentSavePath = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public List<string> recentGenFileList
        {
            get
            {
                try
                {
                    return m_recentFileList;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool paramGenerator
        {
            get
            {
                try
                {
                    return m_paramGenerator == "T" ? true : false;
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

            set
            {
                try
                {
                    m_paramGenerator = value ? "T" : "F";
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool funcGenerator
        {
            get
            {
                try
                {
                    return m_funcGenerator == "T" ? true : false;
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

            set
            {
                try
                {
                    m_funcGenerator = value ? "T" : "F";
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool h101BaseGenerator
        {
            get
            {
                try
                {
                    return m_h101BaseGenerator == "T" ? true : false;
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

            set
            {
                try
                {
                    m_h101BaseGenerator = value ? "T" : "F";
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool internalClass
        {
            get
            {
                try
                {
                    return m_internalClass == "T" ? true : false; 
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

            set
            {
                try
                {
                    m_internalClass = value ? "T" : "F";
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }    
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool oldFilesClear
        {
            get
            {
                try
                {
                    return m_oldFilesClear == "T" ? true : false;
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
            set
            {
                try
                {
                    m_oldFilesClear = value ? "T" : "F";
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
 
                }                
            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        public FFormList fChildFormList
        {
            get
            {
                try
                {
                    return m_fChildFormList;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                m_optionFileName = Path.Combine(m_fScgCore.fWsmCore.optionPath, "NexplantMCSourceGenerator.cfg");

                m_recentFileList = new List<string>(FConstants.RecentMaxCount);

                // --

                m_fChildFormList = new FFormList(m_fScgCore);

                // --

                if (File.Exists(m_optionFileName))
                {
                    loadOption();
                }
                else
                {
                    createOption();
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

        private void term(
            )
        {
            try
            {   
                if (m_fChildFormList != null)
                {
                    m_fChildFormList.Dispose();
                    m_fChildFormList = null;
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

        private void loadOption(
            )
        {            
            FXmlNode fXmlNodeSgo = null;

            try
            {
                // ***
                // Option Xml Document Load 
                // ***
                m_optionFXmlDoc = new FXmlDocument();
                m_optionFXmlDoc.preserveWhiteSpace = false;
                m_optionFXmlDoc.load(m_optionFileName);

                // --

                // ***
                // Source Generator Option Load
                // ***       
                fXmlNodeSgo = m_optionFXmlDoc.selectSingleNode(FXmlTagFAMate.E_FAMate + "/" + FXmlTagSCGOption.E_SCGOption);
                // --
                m_optionSavePath = fXmlNodeSgo.get_attrVal(FXmlTagSCGOption.A_SavePath, FXmlTagSCGOption.D_SavePath);
                m_optionCreator = fXmlNodeSgo.get_attrVal(FXmlTagSCGOption.A_Creator, FXmlTagSCGOption.D_Creator);
                m_optionDescription = fXmlNodeSgo.get_attrVal(FXmlTagSCGOption.A_Description, FXmlTagSCGOption.D_Description);
                m_optionCopyright = fXmlNodeSgo.get_attrVal(FXmlTagSCGOption.A_CopyRightContents, FXmlTagSCGOption.D_CopyRightContens);
                m_optionUsingNamespace = fXmlNodeSgo.get_attrVal(FXmlTagSCGOption.A_UsingNamespace, FXmlTagSCGOption.D_UsingNamespace);
                // --
                m_paramGenerator = fXmlNodeSgo.get_attrVal(FXmlTagSCGOption.A_ParamGenerator, FXmlTagSCGOption.D_ParamGenerator);
                m_funcGenerator = fXmlNodeSgo.get_attrVal(FXmlTagSCGOption.A_FuncGenerator, FXmlTagSCGOption.D_FuncGenerator);
                m_h101BaseGenerator = fXmlNodeSgo.get_attrVal(FXmlTagSCGOption.A_H101BaseGenerator, FXmlTagSCGOption.D_H101BaseGenerator);
                m_internalClass = fXmlNodeSgo.get_attrVal(FXmlTagSCGOption.A_InternalClass, FXmlTagSCGOption.D_InternalClass);
                m_oldFilesClear = fXmlNodeSgo.get_attrVal(FXmlTagSCGOption.A_OldFilesClear, FXmlTagSCGOption.D_OldFilesClear);
                // --
                m_recentOpenPath = fXmlNodeSgo.get_attrVal(FXmlTagSCGOption.A_RecentOpenPath, FXmlTagSCGOption.D_RecentOpenPath);
                if (!Directory.Exists(m_recentOpenPath))
                {
                    m_recentOpenPath = m_fScgCore.fWsmCore.usrPath;
                }
                // --
                m_recentSavePath = fXmlNodeSgo.get_attrVal(FXmlTagSCGOption.A_RecentSavePath, FXmlTagSCGOption.D_RecentSavePath);
                if (!Directory.Exists(m_recentSavePath))
                {
                    m_recentSavePath = m_fScgCore.fWsmCore.usrPath;
                }
                // --
                m_fontName = fXmlNodeSgo.get_attrVal(FXmlTagSCGOption.A_FontName, FXmlTagSCGOption.D_FontName);
                m_fontSize = int.Parse(fXmlNodeSgo.get_attrVal(FXmlTagSCGOption.A_FontSize, FXmlTagSCGOption.D_FontSize));

                // ***
                // Recent File Load
                // ***    
                foreach (FXmlNode n in fXmlNodeSgo.selectNodes(FXmlTagSCGOption.E_Recent))
                {
                    m_recentFileList.Add(n.get_attrVal(FXmlTagSCGOption.A_File, FXmlTagSCGOption.D_File));
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeSgo != null)
                {
                    fXmlNodeSgo.Dispose();
                    fXmlNodeSgo = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void createOption(
            )
        {
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeSgo = null;
            string creationTime = string.Empty;
            string dirName = string.Empty;

            try
            {
                creationTime = FDataConvert.defaultNowDateTimeToString();

                // --

                // ***
                // Default Value Set                
                // ***
                m_optionSavePath = m_fScgCore.fWsmCore.appPath;
                m_optionCreator = FXmlTagSCGOption.D_Creator;
                m_optionDescription = FXmlTagSCGOption.D_Description; 
                m_optionCopyright =
                    "--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가" + Environment.NewLine +
                    "--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의" + Environment.NewLine +
                    "--  지적재산권 침해에 해당됩니다." + Environment.NewLine +
                    "--  (Copyright ⓒ 2014 Miracom Inc. All Rights Reserved | Confidential)";
                m_optionUsingNamespace = FXmlTagSCGOption.D_UsingNamespace;
                
                // --
                m_paramGenerator = FXmlTagSCGOption.D_ParamGenerator;
                m_funcGenerator = FXmlTagSCGOption.D_FuncGenerator;
                m_h101BaseGenerator = FXmlTagSCGOption.D_H101BaseGenerator;
                m_internalClass = FXmlTagSCGOption.D_InternalClass;
                m_oldFilesClear = FXmlTagSCGOption.D_OldFilesClear;
                
                // --
                m_recentOpenPath = m_fScgCore.fWsmCore.usrPath;
                m_recentSavePath = m_fScgCore.fWsmCore.usrPath;
                // --

                // ***
                // Font Information Option Element Create
                // ***
                fontName = FXmlTagSCGOption.D_FontName;
                fontSize = int.Parse(FXmlTagSCGOption.D_FontSize);

                // --

                // ***
                // Option Xml Document Create
                // ***
                m_optionFXmlDoc = new FXmlDocument();
                m_optionFXmlDoc.preserveWhiteSpace = false;
                m_optionFXmlDoc.appendChild(m_optionFXmlDoc.createXmlDeclaration("1.0", string.Empty, string.Empty));

                // --

                // ***
                // FAMate Element Create
                // ***
                fXmlNodeFam = m_optionFXmlDoc.appendChild(m_optionFXmlDoc.createNode(FXmlTagFAMate.E_FAMate));
                // --
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileFormat, FXmlTagFAMate.D_FileFormat, "CFG");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileVersion, FXmlTagFAMate.D_FileVersion, "4.5.1.10");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileCreationTime, FXmlTagFAMate.D_FileCreationTime, creationTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileUpdateTime, FXmlTagFAMate.D_FileUpdateTime, creationTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileDescription, FXmlTagFAMate.D_FileDescription, "Nexplant MC Source Generator Option File");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_UniqueIdPointer, FXmlTagFAMate.D_UniqueIdPointer, "0");

                // --

                // ***
                // Source Generator Option Element Create
                // ***
                fXmlNodeSgo = fXmlNodeFam.appendChild(m_optionFXmlDoc.createNode(FXmlTagSCGOption.E_SCGOption));
                // --
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_SavePath, FXmlTagSCGOption.D_SavePath, optionSavePath);
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_Creator, FXmlTagSCGOption.D_Creator, optionCreator);
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_Description, FXmlTagSCGOption.D_Description, optionDescription);
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_CopyRightContents, FXmlTagSCGOption.D_CopyRightContens, optionCopyright);
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_UsingNamespace, FXmlTagSCGOption.D_UsingNamespace, optionUsingNamespace);
                // --
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_ParamGenerator, FXmlTagSCGOption.D_ParamGenerator, m_paramGenerator);
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_FuncGenerator, FXmlTagSCGOption.D_FuncGenerator, m_funcGenerator);
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_H101BaseGenerator, FXmlTagSCGOption.D_H101BaseGenerator, m_h101BaseGenerator);
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_InternalClass, FXmlTagSCGOption.D_InternalClass, m_internalClass);
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_OldFilesClear, FXmlTagSCGOption.D_OldFilesClear, m_oldFilesClear);
                // --
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_RecentOpenPath, FXmlTagSCGOption.D_RecentOpenPath, recentOpenPath);
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_RecentSavePath, FXmlTagSCGOption.D_RecentSavePath, recentSavePath);

                // --

                // ***
                // Option Save
                // ***
                dirName = Path.GetDirectoryName(m_optionFileName);

                if (!Directory.Exists(dirName))
                {
                    Directory.CreateDirectory(dirName);
                }
                m_optionFXmlDoc.save(m_optionFileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeSgo != null)
                {
                    fXmlNodeSgo.Dispose();
                    fXmlNodeSgo = null;
                }
                if (fXmlNodeFam != null)
                {
                    fXmlNodeFam.Dispose();
                    fXmlNodeFam = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void save(
            )
        {
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeSgo = null;
            string updateTime = string.Empty;
            string dirName = string.Empty;

            try
            {                

                if (m_optionFXmlDoc == null)
                {
                    return;
                }

                // --

                updateTime = FDataConvert.defaultNowDateTimeToString();

                // --

                // ***
                // FAMate Element Set
                // ***
                fXmlNodeFam = m_optionFXmlDoc.selectSingleNode(FXmlTagFAMate.E_FAMate);
                // --
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileUpdateTime, FXmlTagFAMate.D_FileUpdateTime, updateTime);
                
                // ***
                // Source Generator Option Element set
                // ***
                fXmlNodeSgo = fXmlNodeFam.selectSingleNode(FXmlTagSCGOption.E_SCGOption);
                // --
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_SavePath, FXmlTagSCGOption.D_SavePath, m_optionSavePath);
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_Creator, FXmlTagSCGOption.D_Creator, m_optionCreator);
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_Description, FXmlTagSCGOption.D_Description, m_optionDescription);
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_CopyRightContents, FXmlTagSCGOption.D_CopyRightContens, m_optionCopyright);
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_UsingNamespace, FXmlTagSCGOption.D_UsingNamespace, m_optionUsingNamespace);
                // --
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_ParamGenerator, FXmlTagSCGOption.D_ParamGenerator, m_paramGenerator);
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_FuncGenerator, FXmlTagSCGOption.D_FuncGenerator, m_funcGenerator);
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_H101BaseGenerator, FXmlTagSCGOption.D_H101BaseGenerator, m_h101BaseGenerator);
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_InternalClass, FXmlTagSCGOption.D_InternalClass, m_internalClass);
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_OldFilesClear, FXmlTagSCGOption.D_OldFilesClear, m_oldFilesClear);
                // --
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_RecentOpenPath, FXmlTagSCGOption.D_RecentOpenPath, recentOpenPath);
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_RecentSavePath, FXmlTagSCGOption.D_RecentSavePath, recentSavePath);
                // --
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_FontName, FXmlTagSCGOption.D_FontName, fontName);
                fXmlNodeSgo.set_attrVal(FXmlTagSCGOption.A_FontSize, FXmlTagSCGOption.D_FontSize, fontSize.ToString());

                // ***
                // Recent File
                // ***
                foreach (FXmlNode n in fXmlNodeSgo.selectNodes(FXmlTagSCGOption.E_Recent))
                {
                    fXmlNodeSgo.removeChild(n);
                }
                foreach (string s in m_recentFileList)
                {
                    fXmlNodeSgo.add_elem(FXmlTagSCGOption.E_Recent).
                        set_attrVal(FXmlTagSCGOption.A_File, FXmlTagSCGOption.D_File, s);
                }

                // --

                // ***
                // Option Save
                // ***
                dirName = Path.GetDirectoryName(m_optionFileName);
                if (!Directory.Exists(dirName))
                {
                    Directory.CreateDirectory(dirName);
                }
                m_optionFXmlDoc.save(m_optionFileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeSgo != null)
                {
                    fXmlNodeSgo.Dispose();
                    fXmlNodeSgo = null;
                }
                if (fXmlNodeFam != null)
                {
                    fXmlNodeFam.Dispose();
                    fXmlNodeFam = null;
                }
            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
    
    }   // Class end
}   // Namespace end