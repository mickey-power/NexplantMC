/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FResourceData.cs
--  Creator         : spike.lee
--  Create Date     : 2011.12.08
--  Description     : FAMate Core FaSecsDriver Resource Data Class 
--  History         : Created by spike.lee at 2011.12.08
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FResourceData : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_eapName = string.Empty;
        private string m_equipmentName = string.Empty;
        private string m_secsDeviceName = string.Empty;
        private string m_secsSessionName = string.Empty;
        private string m_secsSessionId = string.Empty;
        private string m_hostDeviceName = string.Empty;
        private string m_hostSessionName = string.Empty;
        private string m_hostSessionId = string.Empty;
        private string m_hostMachineId = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FResourceData(                        
            )
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FResourceData(
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

        public string eapName
        {
            get
            {
                try
                {
                    return m_eapName;
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

        public string equipmentName
        {
            get
            {
                try
                {
                    return m_equipmentName;
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

        public string secsDeviceName
        {
            get
            {
                try
                {
                    return m_secsDeviceName;
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

        public string secsSessionName
        {
            get
            {
                try
                {
                    return m_secsSessionName;
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

        public string secsSessionId
        {
            get
            {
                try
                {
                    return m_secsSessionId;
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

        public string hostDeviceName
        {
            get
            {
                try
                {
                    return m_hostDeviceName;
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

        public string hostSessionName
        {
            get
            {
                try
                {
                    return m_hostSessionName;
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

        public string hostSessionId
        {
            get
            {
                try
                {
                    return m_hostSessionId;
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

        public string hostMachineId
        {
            get
            {
                try
                {
                    return m_hostMachineId;
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

        internal void setEapName(
            string value
            )
        {
            try
            {
                m_eapName = value;
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

        internal void setEquipmentName(
            string value
            )
        {
            try
            {
                m_equipmentName = value;
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

        internal void setSecsDeviceName(
            string value
            )
        {
            try
            {
                m_secsDeviceName = value;
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

        internal void setSecsSessionName(
            string value
            )
        {
            try
            {
                m_secsSessionName = value;
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

        internal void setSecsSessionId(
            string value
            )
        {
            try
            {
                m_secsSessionId = value;
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

        internal void setHostDeviceName(
            string value
            )
        {
            try
            {
                m_hostDeviceName = value;
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

        internal void setHostSessionName(
            string value
            )
        {
            try
            {
                m_hostSessionName = value;
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

        internal void setHostSessionId(
            string value
            )
        {
            try
            {
                m_hostSessionId = value;
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

        internal void setHostMachineId(
            string value
            )
        {
            try
            {
                m_hostMachineId = value;
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

        internal void clear(
            )
        {
            try
            {
                m_eapName = string.Empty;
                m_equipmentName = string.Empty;
                m_secsDeviceName = string.Empty;
                m_secsSessionName = string.Empty;
                m_secsSessionId = string.Empty;
                m_hostDeviceName = string.Empty;
                m_hostSessionName = string.Empty;
                m_hostSessionId = string.Empty;
                m_hostMachineId = string.Empty;
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
