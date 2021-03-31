/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FOpcLogFilter.cs
--  Creator         : mjkim
--  Create Date     : 2015.08.03
--  Description     : FAMate Admin Manager OPC Log Filter Class
--  History         : Created by mjkim at 2015.08.03
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;
//using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.Core.FaUIs;
using System.IO;

namespace Nexplant.MC.AdminManager
{
    public class FOpcLogFilter2 : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        // --
        private string m_opcLogFilterFileName = string.Empty;
        private FXmlDocument m_fXmlDocOpt = null;
        // --
        private bool m_enabledFilterOfOpcDeviceState = true;
        private bool m_enabledFilterOfOpcDeviceError = true;
        private bool m_enabledFilterOfOpcDeviceTimeout = true;
        private bool m_enabledFilterOfOpcDeviceDataMessage = true;
        // --
        private bool m_enabledFilterOfHostDeviceState = true;
        private bool m_enabledFilterOfHostDeviceError = true;
        private bool m_enabledFilterOfHostDeviceVfei = false;
        private bool m_enabledFilterOfHostDeviceDataMessage = true;
        // --
        private bool m_enabledFilterOfScenario = true;
        // --
        private bool m_enabledFilterOfApplication = true;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOpcLogFilter2(
            FAdmCore fAdmCore
            )
        {
            m_fAdmCore = fAdmCore;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcLogFilter2(
            FAdmCore fAdmCore,
            FOpcLogFilter2 fFilter
            )
        {
            if (fFilter == null)
            {
                return;
            }

            // --

            m_fAdmCore = fAdmCore;

            // -- 

            m_enabledFilterOfOpcDeviceState = fFilter.enabledFilterOfOpcDeviceState;
            m_enabledFilterOfOpcDeviceError = fFilter.enabledFilterOfOpcDeviceState;
            m_enabledFilterOfOpcDeviceTimeout = fFilter.enabledFilterOfOpcDeviceTimeout;
            m_enabledFilterOfOpcDeviceDataMessage = fFilter.enabledFilterOfOpcDeviceDataMessage;
            // --
            m_enabledFilterOfHostDeviceState = fFilter.enabledFilterOfHostDeviceState;
            m_enabledFilterOfHostDeviceError = fFilter.enabledFilterOfHostDeviceError;
            m_enabledFilterOfHostDeviceVfei = fFilter.enabledFilterOfHostDeviceVfei;
            m_enabledFilterOfHostDeviceDataMessage = fFilter.enabledFilterOfHostDeviceDataMessage;
            // --
            m_enabledFilterOfScenario = fFilter.enabledFilterOfScenario;
            // --
            m_enabledFilterOfApplication = fFilter.enabledFilterOfApplication;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOpcLogFilter2(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    term();
                    // --
                    m_fAdmCore = null;
                    
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

        public bool enabledFilterOfOpcDeviceState
        {
            get
            {
                try
                {
                    return m_enabledFilterOfOpcDeviceState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    m_enabledFilterOfOpcDeviceState = value;
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

        public bool enabledFilterOfOpcDeviceError
        {
            get
            {
                try
                {
                    return m_enabledFilterOfOpcDeviceError;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    m_enabledFilterOfOpcDeviceError = value;
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

        public bool enabledFilterOfOpcDeviceTimeout
        {
            get
            {
                try
                {
                    return m_enabledFilterOfOpcDeviceTimeout;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    m_enabledFilterOfOpcDeviceTimeout = value;
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

        public bool enabledFilterOfOpcDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_enabledFilterOfOpcDeviceDataMessage;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    m_enabledFilterOfOpcDeviceDataMessage = value;
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
        
        public bool enabledFilterOfHostDeviceState
        {
            get
            {
                try
                {
                    return m_enabledFilterOfHostDeviceState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    m_enabledFilterOfHostDeviceState = value;
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

        public bool enabledFilterOfHostDeviceError
        {
            get
            {
                try
                {
                    return m_enabledFilterOfHostDeviceError;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    m_enabledFilterOfHostDeviceError = value;
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

        public bool enabledFilterOfHostDeviceVfei
        {
            get
            {
                try
                {
                    return m_enabledFilterOfHostDeviceVfei;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    m_enabledFilterOfHostDeviceVfei = value;
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

        public bool enabledFilterOfHostDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_enabledFilterOfHostDeviceDataMessage;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    m_enabledFilterOfHostDeviceDataMessage = value;
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

        public bool enabledFilterOfScenario
        {
            get
            {
                try
                {
                    return m_enabledFilterOfScenario;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    m_enabledFilterOfScenario = value;
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

        public bool enabledFilterOfApplication
        {
            get
            {
                try
                {
                    return m_enabledFilterOfApplication;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    m_enabledFilterOfApplication = value;
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
                // --

                m_opcLogFilterFileName = m_fAdmCore.fWsmCore.optionPath + "\\NexplantMcAdminManagerLogFilter.cfg";
                // --
                if (File.Exists(m_opcLogFilterFileName))
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
                if (m_fXmlDocOpt != null)
                {
                    m_fXmlDocOpt.Dispose();
                    m_fXmlDocOpt = null;
                }

                // --
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

        private void createOption(
            )
        {
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeAdo = null;
            string creationTime = string.Empty;
            string dirName = string.Empty;

            try
            {
                creationTime = FDataConvert.defaultNowDateTimeToString();

                // --

                m_enabledFilterOfOpcDeviceState = true;
                m_enabledFilterOfOpcDeviceError = true;
                m_enabledFilterOfOpcDeviceTimeout = true;
                m_enabledFilterOfOpcDeviceDataMessage = true;
                // --
                m_enabledFilterOfHostDeviceState = true;
                m_enabledFilterOfHostDeviceError = true;
                m_enabledFilterOfHostDeviceVfei = true;
                m_enabledFilterOfHostDeviceDataMessage = true;
                // --
                m_enabledFilterOfScenario = true;
                // --
                m_enabledFilterOfApplication = true;

                // --

                // ***
                // Option XML Document Create
                // ***       
                if (m_fXmlDocOpt != null)
                {
                    m_fXmlDocOpt.Dispose();
                    m_fXmlDocOpt = null;
                }
                // --
                m_fXmlDocOpt = new FXmlDocument();
                m_fXmlDocOpt.preserveWhiteSpace = false;
                m_fXmlDocOpt.appendChild(m_fXmlDocOpt.createXmlDeclaration("1.0", string.Empty, string.Empty));

                // --

                // ***
                // FAMate Element Create
                // ***
                fXmlNodeFam = m_fXmlDocOpt.appendChild(m_fXmlDocOpt.createNode(FXmlTagFAMate.E_FAMate));
                // --
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileFormat, FXmlTagFAMate.D_FileFormat, "CFG");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileVersion, FXmlTagFAMate.D_FileVersion, "4.1.0.1");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileCreationTime, FXmlTagFAMate.D_FileCreationTime, creationTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileUpdateTime, FXmlTagFAMate.D_FileUpdateTime, creationTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileDescription, FXmlTagFAMate.D_FileDescription, "Nexplant MC Admin Manager Log Filter File");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_UniqueIdPointer, FXmlTagFAMate.D_UniqueIdPointer, "0");

                // --

                // ***
                // Admin Manager Opc Log Filter Element Create
                // ***
                fXmlNodeAdo = fXmlNodeFam.appendChild(m_fXmlDocOpt.createNode(FXmlTagOpcLogFilter.E_OpcLogFilter));

                // --

                // ***
                // Default Option Save
                // ***
                save();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeFam = null;
                fXmlNodeAdo = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadOption(
            )
        {
            FXmlNode fXmlNodeOlf = null;

            try
            {
                // ***
                // Option XML Document Load
                // *** 
                if (m_fXmlDocOpt != null)
                {
                    m_fXmlDocOpt.Dispose();
                    m_fXmlDocOpt = null;
                }
                // --
                m_fXmlDocOpt = new FXmlDocument();
                m_fXmlDocOpt.preserveWhiteSpace = false;
                m_fXmlDocOpt.load(m_opcLogFilterFileName);

                // --

                // ***
                // Admin Manger Opc Log Filter Load
                // ***
                fXmlNodeOlf = m_fXmlDocOpt.selectSingleNode(FXmlTagFAMate.E_FAMate + "/" + FXmlTagOpcLogFilter.E_OpcLogFilter);
                if (fXmlNodeOlf == null)
                {
                    createOption();
                    return;
                }

                // -- 

                m_enabledFilterOfOpcDeviceState = (fXmlNodeOlf.get_attrVal(FXmlTagOpcLogFilter.A_OpcDeviceState, FXmlTagOpcLogFilter.D_OpcDeviceState) == FBoolean.True.ToString());
                m_enabledFilterOfOpcDeviceError = (fXmlNodeOlf.get_attrVal(FXmlTagOpcLogFilter.A_OpcDeviceError, FXmlTagOpcLogFilter.D_OpcDeviceError) == FBoolean.True.ToString());
                m_enabledFilterOfOpcDeviceTimeout = (fXmlNodeOlf.get_attrVal(FXmlTagOpcLogFilter.A_OpcDeviceTimeOut, FXmlTagOpcLogFilter.D_OpcDeviceTimeOut) == FBoolean.True.ToString());
                m_enabledFilterOfOpcDeviceDataMessage = (fXmlNodeOlf.get_attrVal(FXmlTagOpcLogFilter.A_OpcDeviceDataMessage, FXmlTagOpcLogFilter.D_OpcDeviceDataMessage) == FBoolean.True.ToString());
                // --
                m_enabledFilterOfHostDeviceState = (fXmlNodeOlf.get_attrVal(FXmlTagOpcLogFilter.A_HostDeviceState, FXmlTagOpcLogFilter.D_HostDeviceState) == FBoolean.True.ToString());
                m_enabledFilterOfHostDeviceError = (fXmlNodeOlf.get_attrVal(FXmlTagOpcLogFilter.A_HostDeviceError, FXmlTagOpcLogFilter.D_HostDeviceError) == FBoolean.True.ToString());
                m_enabledFilterOfHostDeviceVfei = (fXmlNodeOlf.get_attrVal(FXmlTagOpcLogFilter.A_HostDeviceVfei, FXmlTagOpcLogFilter.D_HostDeviceVfei) == FBoolean.True.ToString());
                m_enabledFilterOfHostDeviceDataMessage = (fXmlNodeOlf.get_attrVal(FXmlTagOpcLogFilter.A_HostDeviceDataMessage, FXmlTagOpcLogFilter.D_HostDeviceDataMessage) == FBoolean.True.ToString());
                // --
                m_enabledFilterOfScenario = (fXmlNodeOlf.get_attrVal(FXmlTagOpcLogFilter.A_Scenario, FXmlTagOpcLogFilter.D_Scenario) == FBoolean.True.ToString());
                // --
                m_enabledFilterOfApplication = (fXmlNodeOlf.get_attrVal(FXmlTagOpcLogFilter.A_Application, FXmlTagOpcLogFilter.D_Application) == FBoolean.True.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                // --
                fXmlNodeOlf = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void save(
            )
        {
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeOlf = null;
            string updateTime = string.Empty;
            string dirName = string.Empty;

            try
            {
                if (m_fXmlDocOpt == null)
                {
                    return;
                }

                // --

                updateTime = FDataConvert.defaultNowDateTimeToString();

                // --

                // ***
                // FAMate Element Set
                // ***
                fXmlNodeFam = m_fXmlDocOpt.selectSingleNode(FXmlTagFAMate.E_FAMate);
                // --
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileUpdateTime, FXmlTagFAMate.D_FileUpdateTime, updateTime);

                // --

                // ***
                // Admin Manger Opc Log Filter Element set
                // ***
                fXmlNodeOlf = fXmlNodeFam.selectSingleNode(FXmlTagOpcLogFilter.E_OpcLogFilter);

                // --

                fXmlNodeOlf.set_attrVal(FXmlTagOpcLogFilter.A_OpcDeviceState, FXmlTagOpcLogFilter.D_OpcDeviceState, (m_enabledFilterOfOpcDeviceState) ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeOlf.set_attrVal(FXmlTagOpcLogFilter.A_OpcDeviceError, FXmlTagOpcLogFilter.D_OpcDeviceError, (m_enabledFilterOfOpcDeviceError) ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeOlf.set_attrVal(FXmlTagOpcLogFilter.A_OpcDeviceTimeOut, FXmlTagOpcLogFilter.D_OpcDeviceTimeOut, (m_enabledFilterOfOpcDeviceTimeout) ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeOlf.set_attrVal(FXmlTagOpcLogFilter.A_OpcDeviceDataMessage, FXmlTagOpcLogFilter.D_OpcDeviceDataMessage, (m_enabledFilterOfOpcDeviceDataMessage) ? FBoolean.True.ToString() : FBoolean.False.ToString());
                // --
                fXmlNodeOlf.set_attrVal(FXmlTagOpcLogFilter.A_HostDeviceState, FXmlTagOpcLogFilter.D_HostDeviceState, (m_enabledFilterOfHostDeviceState) ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeOlf.set_attrVal(FXmlTagOpcLogFilter.A_HostDeviceError, FXmlTagOpcLogFilter.D_HostDeviceError, (m_enabledFilterOfHostDeviceError) ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeOlf.set_attrVal(FXmlTagOpcLogFilter.A_HostDeviceVfei, FXmlTagOpcLogFilter.D_HostDeviceVfei, (m_enabledFilterOfHostDeviceVfei) ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeOlf.set_attrVal(FXmlTagOpcLogFilter.A_HostDeviceDataMessage, FXmlTagOpcLogFilter.D_HostDeviceDataMessage, (m_enabledFilterOfHostDeviceDataMessage) ? FBoolean.True.ToString() : FBoolean.False.ToString());
                // --
                fXmlNodeOlf.set_attrVal(FXmlTagOpcLogFilter.A_Scenario, FXmlTagOpcLogFilter.D_Scenario, (m_enabledFilterOfScenario) ? FBoolean.True.ToString() : FBoolean.False.ToString());
                // --
                fXmlNodeOlf.set_attrVal(FXmlTagOpcLogFilter.A_Application, FXmlTagOpcLogFilter.D_Application, (m_enabledFilterOfApplication) ? FBoolean.True.ToString() : FBoolean.False.ToString());

                // --

                // ***
                // Option save
                // ***  
                dirName = Path.GetDirectoryName(m_opcLogFilterFileName);
                if (!Directory.Exists(dirName))
                {
                    Directory.CreateDirectory(dirName);
                }
                m_fXmlDocOpt.save(m_opcLogFilterFileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                // --
                fXmlNodeFam = null;
                fXmlNodeOlf = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end