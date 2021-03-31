/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FEapCore.cs
--  Creator         : hongmi.park
--  Create Date     : 2019.08.23
--  Description     : Nexplant MC OPC Modeler Log Tracer Eap Core Class
--  History         : Created by hongmi.park at 2019.08.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.ComponentInterface;
using Nexplant.MC.Core.FaOpcDriver;

namespace Nexplant.MC.OpcModeler
{
    public class FEapCore : FIEapCore
    {
        //------------------------------------------------------------------------------------------------------------------------

        // --
        private bool m_disposed = false;
        // --
        private string m_package = string.Empty;
        private string m_packageVer = string.Empty;
        private string m_model = string.Empty;
        private string m_modelVer = string.Empty;
        private string m_usedComponent = string.Empty;
        private string m_component = string.Empty;
        private string m_componentVer = string.Empty;
        private FEapStatus m_fEapStatus = FEapStatus.Main;
        // --
        private string m_startTime = string.Empty;
        private string m_appPath = string.Empty;
        private string m_logPath = string.Empty;
        private string m_eapName = string.Empty;
        // --
        private object m_fDriver = null;
        private object m_fEventHandler = null;
        private FConfig m_fConfig = null;
        private List<object> m_savedDataList = null;
        // --
        private FOpmCore m_fOpmCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEapCore(
            FOpmCore fOpmCore,
            FOpcDriver fOpcDriver,
            FEventHandler fEventHandler
            )
        {
            m_fOpmCore = fOpmCore;
            m_fDriver = (object)fOpcDriver;
            m_fEventHandler = (object)fEventHandler;

            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FEapCore(
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
                    // --
                    term();

                    // --
                    m_fOpmCore = null;
                    m_fDriver = null;
                    m_fEventHandler = null;
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

        public string package
        {
            get
            {
                try
                {
                    return m_package;
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

        public string packageVer
        {
            get
            {
                try
                {
                    return m_packageVer;
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

        public string model
        {
            get
            {
                try
                {
                    return m_model;
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

        public string modelVer
        {
            get
            {
                try
                {
                    return m_modelVer;
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

        public string usedComponent
        {
            get
            {
                try
                {
                    return m_usedComponent;
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

        public string component
        {
            get
            {
                try
                {
                    return m_component;
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

        public string componentVer
        {
            get
            {
                try
                {
                    return m_componentVer;
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

        public FEapStatus fEapStatus
        {
            get
            {
                try
                {
                    return m_fEapStatus;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FEapStatus.Main;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string startTime
        {
            get
            {
                try
                {
                    return m_startTime;
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

        public string appPath
        {
            get
            {
                try
                {
                    return m_appPath;
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

        public string logPath
        {
            get
            {
                try
                {
                    return m_logPath;
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

        public string eapName
        {
            get
            {
                try
                {
                    return m_eapName;
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

        public FIConfig fConfig
        {
            get
            {
                try
                {
                    return m_fConfig;
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

        public object fDriver
        {
            get
            {
                try
                {
                    return m_fDriver;
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

        public object fEventHandler
        {
            get
            {
                try
                {
                    return m_fEventHandler;
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

        public List<object> savedDataList
        {
            get
            {
                try
                {
                    return m_savedDataList;
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

        public void init()
        {
            try
            {
                // ***
                // SECS Driver Create
                // ***
                m_fConfig = new FConfig();

                // ***
                // Component 생성
                // ***
                m_savedDataList = new List<object>();   // Component Reload 시 저장 데이터 보관 리스트
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

        public void term(
            )
        {
            try
            {
                if (m_fConfig != null)
                {
                    m_fConfig.Dispose();
                    m_fConfig = null;
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

        public void onEapReload(
            string package,
            string packageVer,
            string model,
            string modelVer,
            string usedComponent,
            string component,
            string componentVer,
            FEapStatus fEapState
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public void onEapStop(
            )
        {
            try
            {

            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
    }
}
