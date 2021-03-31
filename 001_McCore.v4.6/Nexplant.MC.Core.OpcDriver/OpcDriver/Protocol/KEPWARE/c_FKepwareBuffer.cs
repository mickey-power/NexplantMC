/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FKepwareBuffer.cs
--  Creator         : spike.lee
--  Create Date     : 2015.06.22
--  Description     : FAMate Core FaOpcDriver OPC Write/Read Buffer Class 
--  History         : Created by spike.lee at 2015.06.22
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
    internal class FKepwareBuffer : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FOpcSession m_fOsn = null;
        private FOpcMessageTransfer m_fOmt = null;                
        private List<ItemIdentifier> m_opcIdList = null;                
        private List<ItemValue> m_opcValueList = null;
        private List<ItemValueCallback> m_opcValueCallbackList = null;        
        private List<ItemResultCallback> m_opcResultCallbackList = null;
        private bool m_isError = false;
        // --
        // Add by Jeff.Kim 2015.10.12
        // Subscribe Event에 의해서 읽는 것인지 Flag 관리
        private bool m_readByEvent = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FKepwareBuffer(
            FOpcSession fOsn,
            FOpcMessageTransfer fOmt
            )
        {
            m_fOsn = fOsn;
            m_fOmt = fOmt;
            m_opcIdList = new List<ItemIdentifier>();            
            m_opcValueList = new List<ItemValue>();
            m_opcValueCallbackList = new List<ItemValueCallback>();
            m_opcResultCallbackList = new List<ItemResultCallback>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FKepwareBuffer(
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
                    m_fOsn = null;
                    m_fOmt = null;
                    // --
                    if (m_opcIdList != null)
                    {
                        m_opcIdList.Clear();
                        m_opcIdList = null;
                    }
                    // --
                    if (m_opcValueList != null)
                    {
                        m_opcValueList.Clear();
                        m_opcValueList = null;
                    }
                    // --
                    if (m_opcValueCallbackList != null)
                    {
                        m_opcValueCallbackList.Clear();
                        m_opcValueCallbackList = null;
                    }                                                            
                    // --
                    if (m_opcResultCallbackList != null)
                    {
                        m_opcResultCallbackList.Clear();
                        m_opcResultCallbackList = null;
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

        public FOpcSession fOpcSession
        {
            get
            {
                try
                {
                    return m_fOsn;
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

        public FOpcMessageTransfer fOpcMessageTransfer
        {
            get
            {
                try
                {
                    return m_fOmt;
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

        public List<ItemIdentifier> opcIdList
        {
            get
            {
                try
                {
                    return m_opcIdList;
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

        public List<ItemValue> opcValueList
        {
            get
            {
                try
                {
                    return m_opcValueList;
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

        public List<ItemValueCallback> opcValueCallbackList
        {
            get
            {
                try
                {
                    return m_opcValueCallbackList; 
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

        public List<ItemResultCallback> opcResultCallbackList
        {
            get
            {
                try
                {
                    return m_opcResultCallbackList;
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

        public bool isError
        {
            get
            {
                try
                {
                    return m_isError;
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
                    m_isError = value;
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

        public bool readByEvent
        {
            get
            {
                try
                {
                    return m_readByEvent;
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
                    m_readByEvent = value;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
