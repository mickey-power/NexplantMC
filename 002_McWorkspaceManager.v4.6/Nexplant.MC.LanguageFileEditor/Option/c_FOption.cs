/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOption.cs
--  Creator         : kitae
--  Create Date     : 2011.03.28
--  Description     : FAMate Language File Editor Option Class 
--  History         : Created by kitae at 2012.03.28

----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;


namespace Nexplant.MC.LanguageFileEditor
{
    public class FOption : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FLfeCore m_fLfeCore = null;
        private FXmlDocument m_optionFXmlDoc = null;
        // --       
        private string m_optionFileName = string.Empty;
        // --
        private string m_recentOpenPath = string.Empty;
        private string m_recentSavePath = string.Empty;      
        private string m_recentExportPath = string.Empty;
        private string m_recentImportPath = string.Empty;
        // --
        private FFormList m_fChildFormList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOption(
            FLfeCore fLfeCore
            )
        {
            m_fLfeCore = fLfeCore;
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
                m_fLfeCore = null;
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

        public string recentExportPath
        {
            get
            {
                try
                {
                    return m_recentExportPath;
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
                    m_recentExportPath = value;
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

        public string recentImportPath
        {
            get
            {
                try
                {
                    return m_recentImportPath;
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
                    m_recentImportPath = value;
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
                m_optionFileName = Path.Combine(m_fLfeCore.fWsmCore.optionPath, "NexplantMcLanguageFileEditor.cfg");

                // --

                m_fChildFormList = new FFormList(m_fLfeCore);
                
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
            FXmlNode fXmlNodeLfo = null;

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
                // Language File Editor Option Load
                // ***       
                fXmlNodeLfo = m_optionFXmlDoc.selectSingleNode(FXmlTagFAMate.E_FAMate + "/" + FXmlTagLFEOption.E_LFEOption);
                // --                
                m_recentOpenPath = fXmlNodeLfo.get_attrVal(FXmlTagLFEOption.A_RecentLibraryOpenPath, FXmlTagLFEOption.D_RecentLibraryOpenPath);
                m_recentSavePath = fXmlNodeLfo.get_attrVal(FXmlTagLFEOption.A_RecentLibrarySavePath, FXmlTagLFEOption.D_RecentLibrarySavePath);
                m_recentExportPath = fXmlNodeLfo.get_attrVal(FXmlTagLFEOption.A_RecentExportPath, FXmlTagLFEOption.D_RecentExportPath);
                m_recentImportPath = fXmlNodeLfo.get_attrVal(FXmlTagLFEOption.A_RecentImportPath, FXmlTagLFEOption.D_RecentImportPath);   
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeLfo != null)
                {
                    fXmlNodeLfo.Dispose();
                    fXmlNodeLfo = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void createOption(
            )
        {
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeLfo = null;            
            string creationTime = string.Empty;
            string dirName = string.Empty;

            try
            {
                creationTime = FDataConvert.defaultNowDateTimeToString();

                // --

                // ***
                // Default Value Set                
                // ***                               
                
                m_recentOpenPath = m_fLfeCore.fWsmCore.appPath;
                m_recentSavePath = m_fLfeCore.fWsmCore.appPath;
                m_recentExportPath = m_fLfeCore.fWsmCore.appPath;
                m_recentImportPath = m_fLfeCore.fWsmCore.appPath;                
                    
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
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileVersion, FXmlTagFAMate.D_FileVersion, "4.1.0.1");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileCreationTime, FXmlTagFAMate.D_FileCreationTime, creationTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileUpdateTime, FXmlTagFAMate.D_FileUpdateTime, creationTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileDescription, FXmlTagFAMate.D_FileDescription, "Nexplant MC Source Generator Option File");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_UniqueIdPointer, FXmlTagFAMate.D_UniqueIdPointer, "0");

                // --

                // ***
                // Source Generator Option Element Create
                // ***
                fXmlNodeLfo = fXmlNodeFam.appendChild(m_optionFXmlDoc.createNode(FXmlTagLFEOption.E_LFEOption));
                // --
                fXmlNodeLfo.set_attrVal(FXmlTagLFEOption.A_RecentLibraryOpenPath, FXmlTagLFEOption.D_RecentLibraryOpenPath, recentOpenPath);
                fXmlNodeLfo.set_attrVal(FXmlTagLFEOption.A_RecentLibrarySavePath, FXmlTagLFEOption.D_RecentLibrarySavePath, recentSavePath);
                fXmlNodeLfo.set_attrVal(FXmlTagLFEOption.A_RecentExportPath, FXmlTagLFEOption.D_RecentExportPath, recentExportPath);
                fXmlNodeLfo.set_attrVal(FXmlTagLFEOption.A_RecentImportPath, FXmlTagLFEOption.D_RecentImportPath, recentImportPath);   

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
                if (fXmlNodeFam != null)
                {
                    fXmlNodeFam.Dispose();
                    fXmlNodeFam = null;
                }
                // --
                if (fXmlNodeLfo != null)
                {
                    fXmlNodeLfo.Dispose();
                    fXmlNodeLfo = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void saveOption(
            )
        {
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeLfo = null;
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
                fXmlNodeLfo = fXmlNodeFam.selectSingleNode(FXmlTagLFEOption.E_LFEOption);
                // --
                fXmlNodeLfo.set_attrVal(FXmlTagLFEOption.A_RecentLibraryOpenPath, FXmlTagLFEOption.D_RecentLibraryOpenPath, recentOpenPath);
                fXmlNodeLfo.set_attrVal(FXmlTagLFEOption.A_RecentLibrarySavePath, FXmlTagLFEOption.D_RecentLibrarySavePath, recentSavePath);
                fXmlNodeLfo.set_attrVal(FXmlTagLFEOption.A_RecentExportPath, FXmlTagLFEOption.D_RecentExportPath, recentExportPath);
                fXmlNodeLfo.set_attrVal(FXmlTagLFEOption.A_RecentImportPath, FXmlTagLFEOption.D_RecentImportPath, recentImportPath);   

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
                
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void save(
            )
        {
            try
            {
                saveOption();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
                throw;
            }
            finally
            {

            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public void changeOption(
            )
        {
            try
            {
                saveOption();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
 
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
    
    }   // Class end
}   // Namespace end