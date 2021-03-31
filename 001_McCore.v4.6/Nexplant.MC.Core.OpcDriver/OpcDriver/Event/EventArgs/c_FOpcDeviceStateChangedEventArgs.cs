/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOpcDeviceStateChangedEventArgs.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.25
--  Description     : FAMate Core FaOpcDriver OPC Device State Changed Event Arguments Class 
--  History         : Created by Jeff.Kim at 2013.07.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    [Serializable]
    public class FOpcDeviceStateChangedEventArgs : FEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpcDriver m_fOpcDriver = null;
        private FOpcDevice m_fOpcDevice = null;
        private FOpcDeviceStateChangedLog m_fOpcDeviceStateChangedLog = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FOpcDeviceStateChangedEventArgs(            
            FEventId fEventId,
            FOpcDriver fOpcDriver,
            FOpcDevice fOpcDevice,
            FOpcDeviceStateChangedLog fOpcDeviceStateChangedLog            
            )
            : base(fEventId)
        {
            m_fOpcDriver = fOpcDriver;
            m_fOpcDevice = fOpcDevice;
            m_fOpcDeviceStateChangedLog = fOpcDeviceStateChangedLog;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOpcDeviceStateChangedEventArgs(
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
                    m_fOpcDriver = null;
                    m_fOpcDevice = null;
                    m_fOpcDeviceStateChangedLog = null;                            
                }                

                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FOpcDriver fOpcDriver
        {
            get
            {
                try
                {
                    return m_fOpcDriver;
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

        public FOpcDevice fOpcDevice
        {
            get
            {
                try
                {
                    return m_fOpcDevice;
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

        public FOpcDeviceStateChangedLog fOpcDeviceStateChangedLog
        {
            get
            {
                try
                {
                    return m_fOpcDeviceStateChangedLog;
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
