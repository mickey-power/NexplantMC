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

namespace Nexplant.MC.LogViewer
{
    public class FOption : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FLvwCore m_fLvwCore = null;
        private FXmlDocument m_optionFXmlDoc = null;
        // --
        private string m_optionFileName = string.Empty;
        // --
        private string m_fontName = string.Empty;        
        private float m_fontSize = 0;       
        // --        
        private FFormList m_fChildFormList = null;
        // --
        private string m_bngViewerRecentOpenPath = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOption(
            FLvwCore fAlvCore
            )
        {
            m_fLvwCore = fAlvCore;
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
                m_fLvwCore = null;
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

        //------------------------------------------------------------------------------------------------------------------------

        public string bngViewerRecentOpenPath
        {
            get
            {
                try
                {
                    return m_bngViewerRecentOpenPath;
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
                    m_bngViewerRecentOpenPath = Directory.Exists(value) ? value : Path.Combine(m_fLvwCore.fWsmCore.usrPath, "Log");
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                m_optionFileName = Path.Combine(m_fLvwCore.fWsmCore.optionPath, "NexplantMCLogViewer.cfg");

                // --

                m_fChildFormList = new FFormList(m_fLvwCore);

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
            FXmlNode fXmlNodeLvo = null;

            try
            {
                // ***
                // Option Xml Document Load 
                // ***
                m_optionFXmlDoc = new FXmlDocument();
                m_optionFXmlDoc.preserveWhiteSpace = false;
                m_optionFXmlDoc.load(m_optionFileName);

                // --

                fXmlNodeLvo = m_optionFXmlDoc.selectSingleNode(FXmlTagFAMate.E_FAMate + "/" + FXmlTagLvwOption.E_LVWOption);

                // --

                // ***
                // Secs Log Viewer Font Information Load
                // ***
                m_fontName = fXmlNodeLvo.get_attrVal(FXmlTagLvwOption.A_FontName, FXmlTagLvwOption.D_FontName);
                m_fontSize = int.Parse(fXmlNodeLvo.get_attrVal(FXmlTagLvwOption.A_FontSize, FXmlTagLvwOption.D_FontSize));
                m_bngViewerRecentOpenPath = fXmlNodeLvo.get_attrVal(FXmlTagLvwOption.A_BngViewerRecentOpenPath, FXmlTagLvwOption.D_BngViewerRecentOpenPath);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeLvo != null)
                {
                    fXmlNodeLvo.Dispose();
                    fXmlNodeLvo = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void createOption(
            )
        {
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeLvo = null;
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
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileVersion, FXmlTagFAMate.D_FileVersion, "4.6.1.1");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileCreationTime, FXmlTagFAMate.D_FileCreationTime, creationTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileUpdateTime, FXmlTagFAMate.D_FileUpdateTime, creationTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileDescription, FXmlTagFAMate.D_FileDescription, "Nexplant MC Log Viewer Option File");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_UniqueIdPointer, FXmlTagFAMate.D_UniqueIdPointer, "0");

                // --

                // ***
                // Log Viewer Option Element Create
                // ***
                fXmlNodeLvo = fXmlNodeFam.appendChild(m_optionFXmlDoc.createNode(FXmlTagLvwOption.E_LVWOption));

                // --

                // ***
                // Log Viewer Log File Font Information Option Element Create
                // ***
                m_fontName = FXmlTagLvwOption.D_FontName;
                m_fontSize = int.Parse(FXmlTagLvwOption.D_FontSize);
                m_bngViewerRecentOpenPath = Path.Combine(m_fLvwCore.fWsmCore.usrPath, "Log");

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
                }
                if (fXmlNodeLvo != null)
                {
                    fXmlNodeLvo.Dispose();
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void save(
            )
        {
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeLvo = null;
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
                fXmlNodeLvo = fXmlNodeFam.selectSingleNode(FXmlTagLvwOption.E_LVWOption);
                // --
                fXmlNodeLvo.set_attrVal(FXmlTagLvwOption.A_FontName, FXmlTagLvwOption.D_FontName, m_fontName);
                fXmlNodeLvo.set_attrVal(FXmlTagLvwOption.A_FontSize, FXmlTagLvwOption.D_FontSize, m_fontSize.ToString());
                fXmlNodeLvo.set_attrVal(FXmlTagLvwOption.A_BngViewerRecentOpenPath, FXmlTagLvwOption.D_BngViewerRecentOpenPath, m_bngViewerRecentOpenPath);

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