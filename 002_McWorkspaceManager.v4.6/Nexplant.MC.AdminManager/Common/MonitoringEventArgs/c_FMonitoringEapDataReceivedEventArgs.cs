/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMonitoringEapDataReceivedEventArgs.cs
--  Creator         : spike.lee
--  Create Date     : 2013.01.18
--  Description     : FAMate Admin Manager Monitroing EAP Data Received Event Arguments Class 
--  History         : Created by spike.lee at 2013.01.18
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.AdminManager
{
    [Serializable]
    public class FMonitoringEapDataReceivedEventArgs : EventArgs, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FMonitoringDataType m_fType = FMonitoringDataType.Update;
        private string m_factory = string.Empty;
        private string m_eap = string.Empty;
        private FXmlNode m_fXmlNode = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FMonitoringEapDataReceivedEventArgs(            
            FMonitoringDataType fType,
            string factory,
            string eap,
            FXmlNode fXmlNode
            )
        {
            m_fType = fType;
            m_factory = factory;
            m_eap = eap;
            m_fXmlNode = fXmlNode;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FMonitoringEapDataReceivedEventArgs(
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
                    m_fXmlNode = null;
                }                
                // --
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

        public FMonitoringDataType fType
        {
            get
            {
                try
                {
                    return m_fType;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FMonitoringDataType.Update;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string factory
        {
            get
            {
                try
                {
                    return m_factory;
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

        public string eap
        {
            get
            {
                try
                {
                    return m_eap;
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

        public FXmlNode fXmlNode
        {
            get
            {
                try
                {
                    return m_fXmlNode;
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
