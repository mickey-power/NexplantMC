/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FKepwareSubscriber.cs
--  Creator         : spike.lee
--  Create Date     : 2015.06.26
--  Description     : FAMate Core FaOpcDriver Subscriber Class 
--  History         : Created by spike.lee at 2015.06.26
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;
using Kepware.ClientAce.OpcDaClient;

namespace Nexplant.MC.Core.FaOpcDriver
{
    internal class FKepwareSubscriber : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --                
        private bool m_enabled = false;
        private Dictionary<UInt64, FKepwareSession> m_fSessionList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FKepwareSubscriber(            
            )
        {
            m_fSessionList = new Dictionary<UInt64, FKepwareSession>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FKepwareSubscriber(
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
                    if (m_fSessionList != null)
                    {
                        m_fSessionList.Clear();
                        m_fSessionList = null;
                    }
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

        public bool enabled
        {
            get
            {
                try
                {
                    return m_enabled;
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

            set
            {
                try
                {
                    m_enabled = value;
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

        public bool completed
        {
            get
            {
                try
                {
                    foreach (FKepwareSession s in m_fSessionList.Values)
                    {
                        if (!s.completed)
                        {
                            return false;
                        }
                    }
                    return true;
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

        public bool succeed
        {
            get
            {
                try
                {
                    // --

                    if (m_fSessionList.Count == 0)
                        return false;

                    // --

                    foreach (FKepwareSession s in m_fSessionList.Values)
                    {
                        if (!s.registerSucceed)
                        {
                            return false;
                        }
                    }
                    return true;
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

        public Dictionary<UInt64, FKepwareSession> fSessionList
        {
            get
            {
                try
                {
                    return m_fSessionList;
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
                    m_fSessionList = value;
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

        public void init(
            )
        {
            try
            {
                m_enabled = false;
                m_fSessionList.Clear();
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
