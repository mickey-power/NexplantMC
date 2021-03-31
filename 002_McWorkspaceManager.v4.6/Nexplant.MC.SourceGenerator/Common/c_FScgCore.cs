/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FScgCore.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.20
--  Description     : FAMate Source Generator Core Class 
--  History         : Created by spike.lee at 2011.09.20
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.SourceGenerator
{
    public class FScgCore : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FOption m_fOption = null;        
        private FIWsmCore m_fWsmCore = null;
        private FScgContainer m_fScgContainer = null;
        private FIDPointer32 m_fFileIdPointer = null;
        private FIDPointer64 m_fFormIdPointer = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FScgCore(
            FIWsmCore fWsmCore,
            FScgContainer fScgContainer
            )
        {
            m_fWsmCore = fWsmCore;
            m_fScgContainer = fScgContainer;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FScgCore(
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
                    m_fScgContainer = null;
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

        public FScgContainer fScgContainer
        {
            get
            {
                try
                {
                    return m_fScgContainer;
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

        public FIDPointer32 fFileIdPointer
        {
            get
            {
                try
                {
                    return m_fFileIdPointer;
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
                m_fOption = new FOption(this);
                m_fFileIdPointer = new FIDPointer32();

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

                if (m_fFileIdPointer != null)
                {
                    m_fFileIdPointer.Dispose();
                    m_fFileIdPointer = null;
                }

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
