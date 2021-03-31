/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FEventArgsBase.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.23
--  Description     : FAmate Converter FaSerialToEthernet Event Arguments Base Class
--  History         : Created by mjkim at 2019.09.23
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSerialToEthernet
{
    [Serializable]
    public class FEventArgsBase: EventArgs, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSerialToEthernet m_fSerialToEthernet = null;
        private FEventId m_fEventId = FEventId.None;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FEventArgsBase(
            FSerialToEthernet fSerialToEthernet,
            FEventId fEventId
            )
        {
            m_fSerialToEthernet = fSerialToEthernet;
            m_fEventId = fEventId;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FEventArgsBase(
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
                    m_fSerialToEthernet = null;
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

        public FSerialToEthernet fSerialToEthernet
        {
            get
            {
                try
                {
                    return m_fSerialToEthernet;
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

        public FEventId fEventId
        {
            get
            {
                try
                {
                    return m_fEventId;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FEventId.None;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
