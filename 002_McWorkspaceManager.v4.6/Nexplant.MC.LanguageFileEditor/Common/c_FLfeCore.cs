
/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FLfeCore.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.30
--  Description     : FAMate Language File Editor Core Class 
--  History         : Created by spike.lee at 2010.12.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;
namespace Nexplant.MC.LanguageFileEditor
{
    public class FLfeCore : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FLanguageFileModifiedEventHandler LangugeFileModified = null;

        // --

        private bool m_disposed = false;
        // --        
        private FIWsmCore m_fWsmCore = null;
        private FLfeContainer m_fLfeContainer = null;
        // --
        private FLfeFileInfo m_fLfeFileInfo = null;
        private FOption m_fOption = null;
        private FIDPointer64 m_fFormIdPointer = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FLfeCore(
            FIWsmCore fWsmCore,
            FLfeContainer fLfeContainer
            )
        {
            m_fWsmCore = fWsmCore;
            m_fLfeContainer = fLfeContainer;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FLfeCore(
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
                    m_fLfeContainer = null;
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

        public FLfeContainer fLfeContainer
        {
            get
            {
                try
                {
                    return m_fLfeContainer;
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

        public FLfeFileInfo fLfeFileInfo
        {
            get
            {
                try
                {
                    return m_fLfeFileInfo;
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
                m_fLfeFileInfo = new FLfeFileInfo(this);

                // --
                
                m_fLfeFileInfo.LanguageFileModified += new FLanguageFileModifiedEventHandler(m_fLfeFileInfo_LanguageFileModified);
                
                // --

                m_fOption = new FOption(this);

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
                m_fLfeFileInfo.LanguageFileModified -= new FLanguageFileModifiedEventHandler(m_fLfeFileInfo_LanguageFileModified);

                // --

                if (m_fFormIdPointer != null)
                {
                    m_fFormIdPointer.Dispose();
                    m_fFormIdPointer = null;
                }

                // --
                
                if (m_fLfeFileInfo != null)
                {
                    m_fLfeFileInfo.Dispose();
                    m_fLfeFileInfo = null;
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

        #region m_fLfeFileInfo Object Event Handler

        private void m_fLfeFileInfo_LanguageFileModified(
            object sender, 
            FLanguageFileModifiedEventArgs e
            )
        {
            try
            {
                if (LangugeFileModified != null)
                {
                    LangugeFileModified(this, e);
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
