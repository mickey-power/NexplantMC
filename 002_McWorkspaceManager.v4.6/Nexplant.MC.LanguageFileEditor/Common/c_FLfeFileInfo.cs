/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FLfeFileInfo.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.03
--  Description     : FAMate Language File Editor Language File Information Class 
--  History         : Created by spike.lee at 2011.01.03
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
    public class FLfeFileInfo : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FLanguageFileModifiedEventHandler LanguageFileModified = null;

        // --

        private bool m_disposed = false;
        // --
        private FLfeCore m_fLfeCore = null;
        private static FIDPointer32 m_fFileIdPointer = new FIDPointer32();
        // --
        private bool m_isClosedFile = true;
        private bool m_isNewFile = false;
        private bool m_isModifiedFile = false;
        // --
        private string m_fileFullName = string.Empty;
        private string m_fileName = string.Empty;
        private FXmlDocument m_fXmlDocLanguage = null;  // Language Xml Document        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FLfeFileInfo(
            FLfeCore fLfeCore            
            )
        {
            m_fLfeCore = fLfeCore;            
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FLfeFileInfo(
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
                if (disposing)
                {
                    term();
                    // --                    
                    m_fLfeCore = null;                    
                }                

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region IDisposable 멤버

        public void Dispose(
            )
        {
            myDispose(true);
            GC.SuppressFinalize(this);            
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public string fileFullName
        {
            get
            {
                try
                {
                    return m_fileFullName;
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

        public string fileName
        {
            get
            {
                try
                {
                    return m_fileName;
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

        public bool isClosedFile
        {
            get
            {
                try
                {
                    return m_isClosedFile;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool isNewFile
        {
            get
            {
                try
                {
                    return m_isNewFile;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool isModifiedFile
        {
            get
            {
                try
                {
                    return m_isModifiedFile;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlDocument fXmlDocLanguage
        {
            get
            {
                try
                {
                    return m_fXmlDocLanguage;
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
                if (m_fXmlDocLanguage != null)
                {
                    m_fXmlDocLanguage.Dispose();
                    m_fXmlDocLanguage = null;
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

        private string createDefaultFileName(
            )
        {
            const string DefaultFileName = "NexplantMcLanguageFile{0}.xml";

            try
            {
                return string.Format(DefaultFileName, FLfeFileInfo.m_fFileIdPointer.uniqueId.ToString());
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

        public void newFile(
            )
        {
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeCgp = null;
            FXmlNode fXmlNodeMgp = null;
            string creationTime = string.Empty;

            try
            {
                if (m_fXmlDocLanguage != null)
                {
                    m_fXmlDocLanguage.Dispose();
                    m_fXmlDocLanguage = null;
                }

                // --

                creationTime = FDataConvert.defaultNowDateTimeToString();                

                // --

                // ***
                // Language XML Document Create
                // ***
                m_fXmlDocLanguage = new FXmlDocument();
                m_fXmlDocLanguage.preserveWhiteSpace = false;
                m_fXmlDocLanguage.appendChild(m_fXmlDocLanguage.createXmlDeclaration("1.0", string.Empty, string.Empty));
                
                // --

                // ***
                // FAMate Element Create
                // ***
                fXmlNodeFam = m_fXmlDocLanguage.appendChild(m_fXmlDocLanguage.createNode(FXmlTagFAMate.E_FAMate));
                // --
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileFormat, FXmlTagFAMate.D_FileFormat, "LNG");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileVersion, FXmlTagFAMate.D_FileVersion, "4.1.0.1");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileCreationTime, FXmlTagFAMate.D_FileCreationTime, creationTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileUpdateTime, FXmlTagFAMate.D_FileUpdateTime, creationTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileDescription, FXmlTagFAMate.D_FileDescription, "Nexplant MC Language File");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_UniqueIdPointer, FXmlTagFAMate.D_UniqueIdPointer, "0");

                // --

                // ***
                // Caption Group and Message Group Element Create
                // ***
                fXmlNodeCgp = fXmlNodeFam.appendChild(m_fXmlDocLanguage.createNode(FXmlTagCaptionGroup.E_CaptionGroup));
                fXmlNodeMgp = fXmlNodeFam.appendChild(m_fXmlDocLanguage.createNode(FXmlTagMessageGroup.E_MessageGroup));

                // --

                m_fileFullName = createDefaultFileName();
                m_fileName = m_fileFullName;
                m_isClosedFile = false;
                m_isNewFile = true;
                m_isModifiedFile = false;
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

                if (fXmlNodeCgp != null)
                {
                    fXmlNodeCgp.Dispose();
                    fXmlNodeCgp = null;
                }

                if (fXmlNodeMgp != null)
                {
                    fXmlNodeMgp.Dispose();
                    fXmlNodeMgp = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void openFile(
            string fileName
            )
        {
            try
            {
                if (m_fXmlDocLanguage != null)
                {
                    m_fXmlDocLanguage.Dispose();
                    m_fXmlDocLanguage = null;
                }

                // --

                // ***
                // Language XML Document Load
                // ***
                m_fXmlDocLanguage = new FXmlDocument();
                m_fXmlDocLanguage.load(fileName);

                // --

                m_fileFullName = fileName;
                m_fileName = Path.GetFileName(fileName);
                m_isClosedFile = false;
                m_isNewFile = false;
                m_isModifiedFile = false;
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

        public void saveFile(
            string fileName
            )
        {
            FXmlNode fXmlNodeFam = null;            
            string dir = string.Empty;
            string updateTime = string.Empty;

            try
            {
                dir = Path.GetDirectoryName(fileName);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                // --

                updateTime = FDataConvert.defaultNowDateTimeToString();

                // --

                fXmlNodeFam = m_fXmlDocLanguage.selectSingleNode(FXmlTagFAMate.E_FAMate);
                // --
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileUpdateTime, FXmlTagFAMate.D_FileUpdateTime, updateTime);
                // --               
                m_fXmlDocLanguage.save(fileName);

                // --

                m_fileFullName = fileName;
                m_fileName = Path.GetFileName(fileName);
                m_isNewFile = false;
                m_isModifiedFile = false;
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
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void closeFile(
            )
        {
            try
            {
                if (m_fXmlDocLanguage != null)
                {
                    m_fXmlDocLanguage.Dispose();
                    m_fXmlDocLanguage = null;
                }

                // --

                m_fileFullName = string.Empty;
                m_fileName = Path.GetFileName(string.Empty);
                m_isClosedFile = true;
                m_isNewFile = false;
                m_isModifiedFile = false;
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

        public void onLanguageFileModified(
            )
        {
            try
            {
                if (m_isModifiedFile)
                {
                    return;
                }
                m_isModifiedFile = true;

                // --

                if (LanguageFileModified != null)
                {
                    LanguageFileModified(this, new FLanguageFileModifiedEventArgs(this));
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
