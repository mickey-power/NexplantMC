/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSerialStateChangedEventArgs.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2011.10.21
--  Description     : FAMate Core FaCommon Serial State Changed Event Arguments Class
--  History         : Created by byungyun.jeon at 2011.10.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    [Serializable]
    public class FSerialStateChangedEventArgs : FSerialEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FISerial m_fOwnerSerial = null;
        private FSerialState m_fState = FSerialState.Closed;
        private string m_portName = string.Empty;
        private int m_baudRate = 0;
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FSerialStateChangedEventArgs(
            FISerial fOwnerSerial,
            FSerialState fState,
            string portName,
            int baudRate
            ) 
            : base (FSerialEventId.SerialStateChanged)
        {
            m_fOwnerSerial = fOwnerSerial;
            m_fState = fState;
            m_portName = portName;
            m_baudRate = baudRate;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSerialStateChangedEventArgs(
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
                    m_fOwnerSerial = null;
                }
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FISerial fOwnerSerial
        {
            get
            {
                try
                {
                    return m_fOwnerSerial;
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

        public FSerialState fState
        {
            get
            {
                try
                {
                    return m_fState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FSerialState.Closed;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string portName
        {
            get
            {
                try
                {
                    return m_portName;
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

        public int baudRate
        {
            get
            {
                try
                {
                    return m_baudRate;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
