/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FKepwareSession.cs
--  Creator         : spike.lee
--  Create Date     : 2015.07.14
--  Description     : FAMate Core FaOpcDriver Subscribe Session Class 
--  History         : Created by spike.lee at 2015.07.14
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
    internal class FKepwareSession : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --                
        private string m_name = string.Empty;
        private UInt64 m_osnUniqueId = 0;
        private UInt64 m_osnOriginalUniqueId = 0;
        private string m_channel = string.Empty;
        private int m_updateRate = 0;
        private float m_deadBand = 0;
        private int m_serverHandle = 0;        
        private bool m_completed = false;
        private bool m_registerSucceed = false;
        private bool m_firstDataChanged = false;
        private Dictionary<UInt64, FKepwareItem> m_fItemList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FKepwareSession(            
            UInt64 osnUniqueId,
            string channel,
            int updateRate,
            float deadBand
            )
        {
            m_osnUniqueId = osnUniqueId;
            m_channel = channel;
            m_updateRate = updateRate;
            m_deadBand = deadBand;
            // --
            m_fItemList = new Dictionary<ulong, FKepwareItem>();
        }

        public FKepwareSession(
            UInt64 osnUniqueId,
            UInt64 osnOriginalUniqueId,
            string channel,
            int updateRate,
            float deadBand
            )
            : this(osnUniqueId, channel, updateRate, deadBand)
        {
            m_osnOriginalUniqueId = osnOriginalUniqueId;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FKepwareSession(
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
                    if (m_fItemList != null)
                    {
                        m_fItemList.Clear();
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

        public UInt64 osnUniqueId
        {
            get
            {
                try
                {
                    return m_osnUniqueId;
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

        //------------------------------------------------------------------------------------------------------------------------

        public UInt64 osnOriginalUniqueId
        {
            get
            {
                try
                {
                    return m_osnOriginalUniqueId;
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

        //------------------------------------------------------------------------------------------------------------------------

        public string name
        {
            get
            {
                try
                {
                    return m_name;
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
                    m_name = value;
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

        public string channel
        {
            get
            {
                try
                {
                    return m_channel;
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

        public int updateRate
        {
            get
            {
                try
                {
                    return m_updateRate;
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

        //------------------------------------------------------------------------------------------------------------------------

        public float deadBand
        {
            get
            {
                try
                {
                    return m_deadBand;
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

        //------------------------------------------------------------------------------------------------------------------------

        public int serverHandle
        {
            get
            {
                try
                {
                    return m_serverHandle;
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
                    m_serverHandle = value;
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
                    return m_completed;
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
                    m_completed = value;
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

        public bool registerSucceed
        {
            get
            {
                try
                {
                    return m_registerSucceed;
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
                    m_registerSucceed = value;
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

        public bool firstDataChanged
        {
            get
            {
                try
                {
                    return m_firstDataChanged;
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
                    m_firstDataChanged = value;
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

        public Dictionary<UInt64, FKepwareItem> fItemList
        {
            get
            {
                try
                {
                    return m_fItemList;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
