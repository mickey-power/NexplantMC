/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FLic2AdminService.cs
--  Creator         : spike.lee
--  Create Date     : 2017.08.28
--  Description     : FAmate Core FaCommon Lic2 Admin Service Class
--  History         : Created by spike.lee at 2017.08.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Management;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
using System.Security.Principal;

namespace Nexplant.MC.Core.FaCommon
{
    public class FLic2AdminService : FLic2Common
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private int m_eapRuntime = 0;
        private int m_equipmentRuntime = 0;
        private int m_secs1HsmsConverterRuntime = 0;
        private int m_opcTagRuntime = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FLic2AdminService(
            )
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FLic2AdminService(
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
                    
                }   
                m_disposed = true;
            }
            base.myDispose(disposing);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public int eapRuntime
        {
            get
            {
                try
                {
                    return m_eapRuntime;
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

            internal set
            {
                try
                {
                    m_eapRuntime = value;
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

        public int equipmentRuntime
        {
            get
            {
                try
                {
                    return m_equipmentRuntime;
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

            internal set
            {
                try
                {
                    m_equipmentRuntime = value;
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

        public int secs1HsmsConverterRuntime
        {
            get
            {
                try
                {
                    return m_secs1HsmsConverterRuntime;
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

            internal set
            {
                try
                {
                    m_secs1HsmsConverterRuntime = value;
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

        public int opcTagRuntime
        {
            get
            {
                try
                {
                    return m_opcTagRuntime;
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

            internal set
            {
                try
                {
                    m_opcTagRuntime = value;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end    
}   // Namespace end