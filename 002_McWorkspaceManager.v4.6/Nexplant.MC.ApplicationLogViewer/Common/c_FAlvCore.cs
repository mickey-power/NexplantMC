/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FAlvCore.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.11
--  Description     : FAMate Application Log Viewer Core Class 
--  History         : Created by spike.lee at 2011.01.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.ApplicationLogViewer
{
    public class FAlvCore : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FOption m_fOption = null;
        private FIWsmCore m_fWsmCore = null;
        private FAlvContainer m_fAlgContainer = null;
        private string m_logPath = string.Empty;
        private FIDPointer64 m_fFormIdPointer = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FAlvCore(
            FIWsmCore fWsmCore,
            FAlvContainer fAlgContainer
            )
        {
            m_fWsmCore = fWsmCore;
            m_fAlgContainer = fAlgContainer;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FAlvCore(
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
                    m_fAlgContainer = null;
                    m_fWsmCore = null;                    
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

        public FOption fOption
        {
            get
            {
                try
                {
                    return m_fOption;
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

        public FIWsmCore fWsmCore
        {
            get
            {
                try
                {
                    return m_fWsmCore;
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

        public FIWsmOption fWsmOption
        {
            get
            {
                try
                {
                    return m_fWsmCore.fWsmOption;
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

        public FUIWizard fUIWizard
        {
            get
            {
                try
                {
                    return m_fWsmCore.fUIWizard;
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

        public FAlvContainer fAlgContainer
        {
            get
            {
                try
                {
                    return m_fAlgContainer;
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

        public UInt64 formUniqueId
        {
            get
            {
                try
                {
                    return m_fFormIdPointer.uniqueId;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                m_fOption = new FOption(this);
                m_logPath = m_fWsmCore.usrPath + "\\log";

                // --

                m_fFormIdPointer = new FIDPointer64();
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
                if (m_fFormIdPointer != null)
                {
                    m_fFormIdPointer.Dispose();
                    m_fFormIdPointer = null;
                }

                // --

                if (m_fOption != null)
                {
                    m_fOption.save();
                    // --
                    m_fOption.Dispose();
                    m_fOption = null;
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
