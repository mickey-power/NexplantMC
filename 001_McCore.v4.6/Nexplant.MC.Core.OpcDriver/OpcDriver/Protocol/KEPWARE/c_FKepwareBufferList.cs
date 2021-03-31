/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FKepwareBufferList.cs
--  Creator         : spike.lee
--  Create Date     : 2015.06.22
--  Description     : FAMate Core FaOpcDriver OPC Buffer List Class 
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
    internal class FKepwareBufferList : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FCodeLock m_fCodeLock = null;
        private Dictionary<UInt32, FKepwareBuffer> m_fBufList = null; 

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FKepwareBufferList(            
            )
        {
            m_fCodeLock = new FCodeLock();
            m_fBufList = new Dictionary<uint, FKepwareBuffer>();            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FKepwareBufferList(
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
                    if (m_fBufList != null)
                    {
                        m_fBufList.Clear();
                        m_fBufList = null;
                    }

                    // --

                    if (m_fCodeLock != null)
                    {
                        m_fCodeLock.Dispose();
                        m_fCodeLock = null;
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

        public int count
        {
            get
            {
                try
                {
                    m_fCodeLock.wait();
                    return m_fBufList.Count;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    m_fCodeLock.set();
                }
                return 0;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods        

        public bool contains(
            UInt32 tid
            )
        {
            try
            {
                m_fCodeLock.wait();
                return m_fBufList.ContainsKey(tid); 
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fCodeLock.set();
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void add(
            UInt32 tid, 
            FKepwareBuffer fBuf
            )
        {
            try
            {
                m_fCodeLock.wait();
                m_fBufList.Add(tid, fBuf);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fCodeLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FKepwareBuffer remove(
            UInt32 tid
            )
        {
            FKepwareBuffer fBuf = null;

            try
            {
                m_fCodeLock.wait();

                // --

                if (!m_fBufList.ContainsKey(tid))
                {
                    return null;
                }
                fBuf = m_fBufList[tid];
                m_fBufList.Remove(tid);
                return fBuf;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fCodeLock.set();
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void clear(
            )
        {
            try
            {
                m_fCodeLock.wait();
                m_fBufList.Clear();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fCodeLock.set();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
