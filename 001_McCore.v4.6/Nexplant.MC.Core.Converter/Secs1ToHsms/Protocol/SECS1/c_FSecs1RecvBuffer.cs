/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecs1RecvBuffer.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.10
--  Description     : FAmate Converter FaSecs1ToHsms SECS1 Recveived Buffer Class
--  History         : Created by spike.lee at 2017.04.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    internal class FSecs1RecvBuffer: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private List<byte> m_data = null;       

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecs1RecvBuffer(            
            )
        {
            m_data = new List<byte>();
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
            byte data = 0;

            try
            {
                data = m_data[0];
                m_data.RemoveAt(0);
                // --
                return data;
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

        //------------------------------------------------------------------------------------------------------------------------

        public byte[] output(
            int length
            )
        {
            byte[] data = null;

            try
            {
                data = m_data.GetRange(0, length).ToArray();
                m_data.RemoveRange(0, length);
                // --
                return data;
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
