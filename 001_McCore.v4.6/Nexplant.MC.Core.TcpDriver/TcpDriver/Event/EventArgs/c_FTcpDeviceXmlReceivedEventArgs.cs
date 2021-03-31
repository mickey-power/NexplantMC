/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpDeviceXmlReceivedEventArgs.cs
--  Creator         : spike.lee
--  Create Date     : 2016.04.18
--  Description     : FAMate Core FaTcpDriver TCP Device XML Received Event Arguments Class 
--  History         : Created by spike.lee at 2016.04.18
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    [Serializable]
    public class FTcpDeviceXmlReceivedEventArgs : FEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcpDriver m_fTcpDriver = null;
        private FTcpDevice m_fTcpDevice = null;
        private FTcpDeviceXmlReceivedLog m_fTcpDeviceXmlReceivedLog = null;
        private string m_xml = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FTcpDeviceXmlReceivedEventArgs(            
            FEventId fEventId,
            FTcpDriver fTcpDriver,
            FTcpDevice fTcpDevice,
            FTcpDeviceXmlReceivedLog fTcpDeviceXmlReceivedLog,
            string xml
            )
            : base(fEventId)
        {
            m_fTcpDriver = fTcpDriver;
            m_fTcpDevice = fTcpDevice;
            m_fTcpDeviceXmlReceivedLog = fTcpDeviceXmlReceivedLog;
            m_xml = xml;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpDeviceXmlReceivedEventArgs(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_fTcpDriver = null;
                    m_fTcpDevice = null;
                    m_fTcpDeviceXmlReceivedLog = null;
                }                

                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FTcpDriver fTcpDriver
        {
            get
            {
                try
                {
                    return m_fTcpDriver;
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

        public FTcpDevice fTcpDevice
        {
            get
            {
                try
                {
                    return m_fTcpDevice;
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

        public FTcpDeviceXmlReceivedLog fTcpDeviceXmlReceivedLog
        {
            get
            {
                try
                {
                    return m_fTcpDeviceXmlReceivedLog;
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

        public string xml
        {
            get
            {
                try
                {
                    return m_xml;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
