/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecs1RecvBuffer.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2011.11.16
--  Description     : FAMate Core FaSecsDriver SECS-I Receive Buffer Class 
--  History         : Created by byungyun.jeon at 2011.11.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal class FSecs1RecvBuffer : IDisposable
    {
        
        //------------------------------------------------------------------------------------------------------------------------
                
        private bool m_disposed = false;
        // --
        private ArrayList m_data = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecs1RecvBuffer(
            )
        {
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        ~FSecs1RecvBuffer(
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
                    m_data = null;
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

        public int length
        {
            get
            {
                try
                {
                    return m_data.Count;
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
                m_data = new ArrayList();
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

        public void clear(
            )
        {
            try
            {
                m_data.Clear();
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

        public void input(
            byte[] data
            )
        {
            try
            {
                m_data.AddRange(data);
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
        
        public byte output(
            )
        {
            byte[] bytes = null;

            try
            {
                bytes = this.output(1);
                return bytes[0];
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                bytes = null;
            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        public byte[] output(
            int count
            )
        {
            byte[] bytes = null;

            try
            {
                if (this.m_data.Count < count)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                }

                // --

                bytes = (byte[])this.m_data.GetRange(0, count).ToArray(typeof(byte));
                this.m_data.RemoveRange(0, count);

                // --

                return bytes;
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

        //------------------------------------------------------------------------------------------------------------------------

        public byte watch(
            )
        {
            byte[] bytes = null;

            try
            {
                bytes = this.watch(1);
                return bytes[0];
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                bytes = null;
            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public byte[] watch(
            int count
            )
        {
            try
            {
                if (this.m_data.Count < count)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                }

                // -- 

                return (byte[])this.m_data.GetRange(0, count).ToArray(typeof(byte));
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
