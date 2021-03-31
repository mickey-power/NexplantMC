/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOption.cs
--  Creator         : baehyun seo
--  Create Date     : 2012.08.13
--  Description     : FAMate Application log Viewer Option Class 
--  History         : Created by baehyun seo at 2012.08.13
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.ApplicationLogViewer
{
    public class FOption : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAlvCore m_fAlvCore = null;
        private FXmlDocument m_optionFXmlDoc = null;
        // --
        private string m_optionFileName = string.Empty;
        // --
        private string m_fontName = string.Empty;        
        private float m_fontSize = 0;       
        // --        
        private FFormList m_fChildFormList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOption(
            FAlvCore fAlvCore
            )
        {
            m_fAlvCore = fAlvCore;
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
                m_fAlvCore = null;
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
                m_optionFileName = Path.Combine(m_fAlvCore.fWsmCore.optionPath, "NexplantMCApplicationLogViewer.cfg");

                // --

                m_fChildFormList = new FFormList(m_fAlvCore);

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
            FXmlNode fXmlNodeAvo = null;

            try
            {
                // ***
                // Option Xml Document Load 
                // ***
                m_optionFXmlDoc = new FXmlDocument();
                m_optionFXmlDoc.preserveWhiteSpace = false;
                m_optionFXmlDoc.load(m_optionFileName);

                // --

                fXmlNodeAvo = m_optionFXmlDoc.selectSingleNode(FXmlTagFAMate.E_FAMate + "/" + FXmlTagALVOption.E_ALVOption);

                // --

                // ***
                // Secs Log Viewer Font Information Load
                // ***
                m_fontName = fXmlNodeAvo.get_attrVal(FXmlTagALVOption.A_FontName, FXmlTagALVOption.D_FontName);
                m_fontSize = int.Parse(fXmlNodeAvo.get_attrVal(FXmlTagALVOption.A_FontSize, FXmlTagALVOption.D_FontSize));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeAvo != null)
                {
                    fXmlNodeAvo.Dispose();
                    fXmlNodeAvo = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void createOption(
            )
        {
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeAvo = null;
            string creationTime = string.Empty;
            string dirName = string.Empty;

            try
            {
                creationTime = FDataConvert.defaultNowDateTimeToString();             
                                
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
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileDescription, FXmlTagFAMate.D_FileDescription, "Nexplant MC SECS Log Viewer Option File");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_UniqueIdPointer, FXmlTagFAMate.D_UniqueIdPointer, "0");

                // --

                // ***
                // Application Log Viewer Option Element Create
                // ***
                fXmlNodeAvo = fXmlNodeFam.appendChild(m_optionFXmlDoc.createNode(FXmlTagALVOption.E_ALVOption));

                // --

                // ***
                // Secs Log Viewer Log File Font Information Option Element Create
                // ***
                m_fontName = FXmlTagALVOption.D_FontName;
                m_fontSize = int.Parse(FXmlTagALVOption.D_FontSize);

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
                if (fXmlNodeAvo != null)
                {
                    fXmlNodeAvo.Dispose();
                    fXmlNodeAvo = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void save(
            )
        {
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeAvo = null;
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
                // Secs Log Viewer Log File Font Information Option Element set
                // ***
                fXmlNodeAvo = fXmlNodeFam.selectSingleNode(FXmlTagALVOption.E_ALVOption);
                // --
                fXmlNodeAvo.set_attrVal(FXmlTagALVOption.A_FontName, FXmlTagALVOption.D_FontName, m_fontName);
                fXmlNodeAvo.set_attrVal(FXmlTagALVOption.A_FontSize, FXmlTagALVOption.D_FontSize, m_fontSize.ToString());
                                
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
    
    }   // Class end
}   // Namespace end