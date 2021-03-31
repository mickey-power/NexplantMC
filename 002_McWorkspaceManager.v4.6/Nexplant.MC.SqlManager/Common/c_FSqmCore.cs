/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSqmCore.cs
--  Creator         : mj.kim
--  Create Date     : 2011.09.23
--  Description     : FAMate SQL Manager Core Class 
--  History         : Created by mj.kim at 2011.09.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.SqlManager
{
    public class FSqmCore : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------        
        
        public event FPropSqlCode.FSqlQueryValueChangedEventHandler SqlQueryValueChanged = null;

        // --

        private bool m_disposed = false;
        // --        
        private FOption m_fOption = null;
        private FIWsmCore m_fWsmCore = null;
        private FSqmContainer m_fSqmContainer = null;
        // --
        private FH101 m_fH101 = null;
        private FIDPointer64 m_fFormIdPointer = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSqmCore(
            FIWsmCore fWsmCore,
            FSqmContainer fSqmContainer
            )
        {
            m_fWsmCore = fWsmCore;
            m_fSqmContainer = fSqmContainer;

            // --

            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSqmCore(
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
                    m_fSqmContainer = null;
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

        public FSqmContainer fSqmContainer
        {
            get
            {
                try
                {
                    return m_fSqmContainer;
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

        public FH101 fH101
        {
            get
            {
                try
                {
                    return m_fH101;
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
                termH101();
                
                // --

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

        //------------------------------------------------------------------------------------------------------------------------

        public void initH101(
            )
        {
            try
            {
                termH101();

                // --

                m_fH101 = new FH101(
                    FConstants.StationSessionId, 
                    fOption.connectionStationConnectString, 
                    FConstants.StationVersion,
                    fOption.connectionStationTimeout,
                    FConstants.GuaranteedTimeout,
                    true,
                    false
                    );
                m_fH101.init(FH101StationMode.Inter);
                // --
                FSQMSQSCaster.sqmsqsChannel = m_fOption.connectionCastChannelId;
                FSQMSQSCaster.sqmsqsTtl = m_fOption.connectionStationTimeout;
                // --
                m_fH101.registerDispatcher("SQMSQS", new FSQMSQSCallback(this));
                // --
                m_fH101.tune(m_fOption.connectionTuneChannelId, true, false);
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

        public void termH101(
            )
        {
            try
            {
                if (m_fH101 == null)
                {
                    return;
                }

                // --

                if (m_fH101.started)
                {
                    m_fH101.untune(m_fOption.connectionTuneChannelId, true, false);
                }
                // --
                m_fH101.term();
                m_fH101.Dispose();
                m_fH101 = null;
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

        internal void onSqlQueryValueChanged(
            object sender,
            PropertyValueChangedEventArgs args
            )
        {
            try
            {
                if (SqlQueryValueChanged != null)
                {
                    SqlQueryValueChanged(sender, args);
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
