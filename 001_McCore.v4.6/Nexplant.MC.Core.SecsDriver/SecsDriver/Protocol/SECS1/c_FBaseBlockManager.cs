/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FBaseBlockManager.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2011.11.22
--  Description     : FAMate Core FaSecsDriver SECS-I Block Manager Base Class 
--  History         : Created by byungyun.jeon at 2011.11.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal abstract class FBaseBlockManager : IDisposable
    {
        
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;        
        // --
        protected List<byte[]> m_blockList = null;
        // --
        protected bool m_rbit = false;
        protected UInt16 m_sessionId = 0;
        protected bool m_wbit = false;
        protected int m_stream = 0;
        protected int m_function = 0;
        protected UInt32 m_systemBytes = 0;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FBaseBlockManager(
            )
        {
            m_blockList = new List<byte[]>();
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        ~FBaseBlockManager(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_blockList.Clear();
                    m_blockList = null;
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

        public bool rbit
        {
            get
            {
                try
                {
                    return m_rbit;
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
                    m_rbit = value;
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

        public UInt16 sessionId
        {
            get
            {
                try
                {
                    return m_sessionId;
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

        public bool wbit
        {
            get
            {
                try
                {
                    return m_wbit;
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

        public int stream
        {
            get
            {
                try
                {
                    return m_stream;
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

        public int function
        {
            get
            {
                try
                {
                    return m_function;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return function;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        public UInt32 systemBytes
        {
            get
            {
                try
                {
                    return m_systemBytes;
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

        abstract public bool isCompleted
        {
            get;            
        }

        //------------------------------------------------------------------------------------------------------------------------

        abstract public byte[] body
        {
            get;
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        abstract public  byte[] message
        {
            get;
        }

        //------------------------------------------------------------------------------------------------------------------------

        abstract public  UInt32 length
        {
            get;
        }

        //------------------------------------------------------------------------------------------------------------------------

        abstract protected int bodyLength
        {
            get;
        }
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public void init(
            byte[] block
            )
        {
            FBlockInfo fBlockInfo = null;

            try
            {
                fBlockInfo = new FBlockInfo(block);

                // --

                m_rbit = fBlockInfo.rbit;
                m_sessionId = fBlockInfo.sessionId;
                m_wbit = fBlockInfo.wbit;
                m_stream = fBlockInfo.stream;
                m_function = fBlockInfo.function;
                m_systemBytes = fBlockInfo.systemBytes;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fBlockInfo = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        public void init(
            bool rbit,
            UInt16 sessionId,
            bool wbit,
            int stream,
            int function,
            UInt32 systemBytes
            )
        {
            try
            {
                m_rbit = rbit;
                m_sessionId = sessionId;
                m_wbit = wbit;
                m_stream = stream;
                m_function = function;
                m_systemBytes = systemBytes;
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