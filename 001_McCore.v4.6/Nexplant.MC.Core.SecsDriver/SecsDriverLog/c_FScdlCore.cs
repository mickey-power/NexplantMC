/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FScdlCore.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.28
--  Description     : FAMate Core FaSecsDriver SECS Driver Log Core Class 
--  History         : Created by spike.lee at 2011.09.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal class FScdlCore : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSecsDriverLog m_fSecsDriverLog = null;
        private FXmlDocument m_fXmlDoc = null;
        private FXmlNode m_fXmlNodeScdl = null;
        private FIDPointer64 m_fIdPointer = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FScdlCore(            
            )           
        {
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FScdlCore(
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

        public FXmlDocument fXmlDoc
        {
            get
            {
                try
                {
                    return m_fXmlDoc;
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

        public FXmlNode fXmlNodeScdl
        {
            get
            {
                try
                {
                    return m_fXmlNodeScdl;
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

        public FIDPointer64 fIdPointer
        {
            get
            {
                try
                {
                    return m_fIdPointer;
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

        public FSecsDriverLog fSecsDriverLog
        {
            get
            {
                try
                {
                    return m_fSecsDriverLog;
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
                    m_fSecsDriverLog = value;
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
            FXmlNode fXmlNodeFam = null;

            try
            {
                m_fIdPointer = new FIDPointer64();
                m_fXmlDoc = new FXmlDocument();
                m_fXmlDoc.preserveWhiteSpace = false;
                m_fXmlDoc.appendChild(m_fXmlDoc.createXmlDeclaration("1.0", string.Empty, string.Empty));

                // --

                fXmlNodeFam = m_fXmlDoc.appendChild(FSecsDriverLogCommon.createXmlNodeFAM(m_fXmlDoc));
                // --
                m_fXmlNodeScdl = fXmlNodeFam.appendChild(FSecsDriverLogCommon.createXmlNodeSCDL(m_fXmlDoc));
                m_fXmlNodeScdl.set_attrVal(FXmlTagSCDL.A_UniqueId, FXmlTagSCDL.D_UniqueId, m_fIdPointer.uniqueId.ToString());
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

        private void term(
            )
        {
            try
            {
                m_fSecsDriverLog = null;

                // --

                if (m_fXmlNodeScdl != null)
                {
                    m_fXmlNodeScdl.Dispose();
                    m_fXmlNodeScdl = null;
                }

                if (m_fXmlDoc != null)
                {
                    m_fXmlDoc.Dispose();
                    m_fXmlDoc = null;
                }

                if (m_fIdPointer != null)
                {
                    m_fIdPointer.Dispose();
                    m_fIdPointer = null;
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

        public void openLogFile(
            string fileName
            )
        {
            FIDPointer64 fIdPointer = null;
            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeScdl = null;

            try
            {
                fIdPointer = new FIDPointer64();
                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;
                fXmlDoc.load(fileName);

                // --
                fXmlNodeFam = fXmlDoc.selectSingleNode(FXmlTagFAM.E_FAMate);
                fIdPointer.reset(UInt64.Parse(fXmlNodeFam.get_attrVal(FXmlTagFAM.A_UniqueIdPointer, FXmlTagFAM.D_UniqueIdPointer)));
                // --
                fXmlNodeScdl = fXmlNodeFam.selectSingleNode(FXmlTagSCDL.E_SecsDriver);

                // --                

                if (m_fIdPointer != null)
                {
                    m_fIdPointer.Dispose();
                    m_fIdPointer = null;
                }

                if (m_fXmlDoc != null)
                {
                    m_fXmlDoc.Dispose();
                    m_fXmlDoc = null;
                }

                // --

                m_fIdPointer = fIdPointer;
                m_fXmlDoc = fXmlDoc;
                m_fXmlNodeScdl = fXmlNodeScdl;

                // --

                if (fIdPointer.currentId == 0)
                {
                    FSecsDriverLogCommon.resetLogUniqueId(m_fIdPointer, m_fXmlNodeScdl);
                }

                // --

                migrateLogFile();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fIdPointer = null;
                fXmlDoc = null;
                fXmlNodeScdl = null;
                if (fXmlNodeFam != null)
                {
                    fXmlNodeFam.Dispose();          
                    fXmlNodeFam = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void saveLogFile(
            string fileName
            )
        {
            FXmlNode fXmlNodeFam = null;

            try
            {
                fXmlNodeFam = m_fXmlDoc.selectSingleNode(FXmlTagFAM.E_FAMate);
                fXmlNodeFam.set_attrVal(FXmlTagFAM.A_UniqueIdPointer, FXmlTagFAM.D_UniqueIdPointer, m_fIdPointer.currentId.ToString());
                fXmlNodeFam.set_attrVal(FXmlTagFAM.A_FileUpdateTime, FXmlTagFAM.D_FileUpdateTime, FDataConvert.defaultNowDateTimeToString());

                // -- 

                m_fXmlDoc.save(fileName);
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

        private void migrateLogFile(
            )
        {
            FXmlNodeList fXmlNodeList = null;
            string xpath = string.Empty;

            try
            {
                // ***
                // No Format SECS Item Log Migration
                // ***
                xpath = "//" + FXmlTagSITL.E_SecsItem + "[not(@" + FXmlTagSITL.A_Format + ")]";
                fXmlNodeList = m_fXmlDoc.selectNodes(xpath);
                if (fXmlNodeList.count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("NoFormatSecsItemLogCount=" + fXmlNodeList.count.ToString());
                    // --
                    foreach (FXmlNode fXmlNode in fXmlNodeList)
                    {
                        fXmlNode.set_attrVal(FXmlTagSITL.A_Format, FXmlTagSITL.D_Format, "L");    // Default Format: List
                    }
                }

                // --

                // ***
                // No Pattern Secs Item Migration
                // ***
                xpath = "//" + FXmlTagSITL.E_SecsItem + "[not(@" + FXmlTagSITL.A_Pattern + ")]";
                fXmlNodeList = m_fXmlDoc.selectNodes(xpath);
                if (fXmlNodeList.count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("NoPatternSecsItemLogCount=" + fXmlNodeList.count.ToString());
                    // --
                    foreach (FXmlNode fXmlNode in fXmlNodeList)
                    {
                        fXmlNode.set_attrVal(FXmlTagSITL.A_Pattern, FXmlTagSITL.D_Pattern, "F");  // Default Pattern: Fixed
                    }
                }

                // -- 

                // ***
                // No Format Host Item Log Migration
                // ***
                xpath = "//" + FXmlTagHITL.E_HostItem + "[not(@" + FXmlTagHITL.A_Format + ")]";
                fXmlNodeList = m_fXmlDoc.selectNodes(xpath);
                if (fXmlNodeList.count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("NoFormatHostItemLogCount=" + fXmlNodeList.count.ToString());
                    // --
                    foreach (FXmlNode fXmlNode in fXmlNodeList)
                    {
                        fXmlNode.set_attrVal(FXmlTagHITL.A_Format, FXmlTagHITL.D_Format, "L");    // Default Format: List
                    }
                }

                // --

                // ***
                // No Pattern Host Item Log Migration
                // ***
                xpath = "//" + FXmlTagHITL.E_HostItem + "[not(@" + FXmlTagHITL.A_Pattern + ")]";
                fXmlNodeList = m_fXmlDoc.selectNodes(xpath);
                if (fXmlNodeList.count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("NoPatternHostItemLogCount=" + fXmlNodeList.count.ToString());
                    // --
                    foreach (FXmlNode fXmlNode in fXmlNodeList)
                    {
                        fXmlNode.set_attrVal(FXmlTagHITL.A_Pattern, FXmlTagHITL.D_Pattern, "F");    // Default Pattern: Fxied
                    }
                }

                // --

                // ***
                // No Format Data Log Migration
                // ***
                xpath = "//" + FXmlTagDATL.E_Data + "[not(@" + FXmlTagDATL.A_Format + ")]";
                fXmlNodeList = m_fXmlDoc.selectNodes(xpath);
                if (fXmlNodeList.count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("NoFormatDataLogCount=" + fXmlNodeList.count.ToString());
                    // --
                    foreach (FXmlNode fXmlNode in fXmlNodeList)
                    {
                        fXmlNode.set_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format, "L");    // Default Format: List
                    }
                }

                // --

                // ***
                // No Pattern Data Log Migration
                // ***
                xpath = "//" + FXmlTagDATL.E_Data + "[not(@" + FXmlTagDATL.A_Pattern + ")]";
                fXmlNodeList = m_fXmlDoc.selectNodes(xpath);
                if (fXmlNodeList.count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("NoPatternDataLogCount=" + fXmlNodeList.count.ToString());
                    // --
                    foreach (FXmlNode fXmlNode in fXmlNodeList)
                    {
                        fXmlNode.set_attrVal(FXmlTagDATL.A_Pattern, FXmlTagDATL.D_Pattern, "F");  // Default Pattern: Fixed
                    }
                } 
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeList = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
