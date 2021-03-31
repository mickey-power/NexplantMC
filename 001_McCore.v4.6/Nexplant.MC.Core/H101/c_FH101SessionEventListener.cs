/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FH101SessionEventListener.cs
--  Creator         : spike.lee
--  Create Date     : 2015.07.31
--  Description     : FAMate Core FaCommon Highway101 Session Event Listener Class
--  History         : Created by spike.lee at 2015.07.31
--
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;
using com.miracom.transceiverx.session;
using com.miracom.transceiverx.message;

namespace Nexplant.MC.Core.FaCommon
{
    internal class FH101SessionEventListener : SessionEventListener, IDisposable 
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FH101 m_fH101 = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FH101SessionEventListener(
            FH101 fH101
            )
        {
            m_fH101 = fH101;            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FH101SessionEventListener(
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
                    m_fH101 = null;                    
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
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region SessionEventListener 멤버

        public void onConnect(
            Session ss
            )
        {
            try
            {
                if (m_fH101 != null)
                {
                    m_fH101.onH101Connected();
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex); 
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void onDisconnect(
            Session ss
            )
        {
            try
            {
                if (m_fH101 != null)
                {
                    m_fH101.onH101Disconnected();
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex); 
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end

