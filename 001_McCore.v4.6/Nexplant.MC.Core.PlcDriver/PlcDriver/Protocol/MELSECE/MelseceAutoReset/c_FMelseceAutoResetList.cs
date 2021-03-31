/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMelseceAutoResetList.cs
--  Creator         : spike.lee
--  Create Date     : 2013.11.06
--  Description     : FAMate Core FaPlcDriver Melsec Ethernet Auto Reset List Data Class 
--  History         : Created by spike.lee at 2013.11.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal class FMelseceAutoResetList : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FCodeLock m_fLock = null;
        private Dictionary<string, FMelseceAutoReset> m_fList = null;
        private int m_timeout = 0;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FMelseceAutoResetList(                        
            int timeout
            )
        {
            m_fLock = new FCodeLock();
            m_fList = new Dictionary<string, FMelseceAutoReset>();
            m_timeout = timeout;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FMelseceAutoResetList(
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
                    if (m_fLock != null)
                    {
                        m_fLock.Dispose();
                        m_fLock = null;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static string generateKey(
            string bitDeviceCode, 
            UInt32 bitStartAddress, 
            UInt32 bitAddress
            )
        {
            string key = string.Empty;

            try
            {
                key = bitDeviceCode + "-" + bitStartAddress.ToString() + "-" + bitAddress.ToString();
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool contains(
            string bitDeviceCode,
            UInt32 bitStartAddress,
            UInt32 bitAddress
            )
        {
            string key = string.Empty;

            try
            {
                key = FMelseceAutoResetList.generateKey(bitDeviceCode, bitStartAddress, bitAddress);
                // --
                return m_fList.ContainsKey(key);
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

        //------------------------------------------------------------------------------------------------------------------------

        public void add(
            FMelseceAutoReset fData
            )
        {
            try
            {
                m_fLock.wait();

                // --
                if (m_fList.ContainsKey(fData.key))
                {
                    return;
                }
                // --
                m_fList.Add(fData.key, fData);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void remove(
            string bitDeviceCode,
            UInt32 bitStartAddress,
            UInt32 bitAddress
            )
        {
            string key = string.Empty;

            try
            {
                m_fLock.wait();

                // --

                key = FMelseceAutoResetList.generateKey(bitDeviceCode, bitStartAddress, bitAddress);
                // --
                if (!m_fList.ContainsKey(key))
                {
                    return;
                }
                // --
                m_fList.Remove(key);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void clear(
            )
        {
            try
            {
                m_fLock.wait();

                // --

                m_fList.Clear();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FMelseceAutoReset[] getTimeoutData(
            )
        {
            List<FMelseceAutoReset> fTimeoutList = null;

            try
            {
                m_fLock.wait();

                // --

                fTimeoutList = new List<FMelseceAutoReset>();
                // --
                foreach (FMelseceAutoReset fData in m_fList.Values)
                {
                    if (FTickCount.timeout(fData.ticks, m_timeout))
                    {
                        fTimeoutList.Add(fData);
                    }
                }
                // --
                foreach (FMelseceAutoReset fData in fTimeoutList)
                {
                    m_fList.Remove(fData.key);
                }
                // --
                return fTimeoutList.ToArray();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTimeoutList = null;

                // --

                m_fLock.set();
            }
            return null;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
