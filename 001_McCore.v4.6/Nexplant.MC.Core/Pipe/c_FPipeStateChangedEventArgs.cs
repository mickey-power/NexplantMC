/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPipeStateChangedEventArgs.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.16
--  Description     : FAMate Core FaCommon FPipe State Changed Event Arguments Class
--  History         : Created by spike.lee at 2011.09.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    [Serializable]
    public class FPipeStateChangedEventArgs : FPipeEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FIPipe m_fOwnerPipe = null;
        private FPipeState m_fState = FPipeState.Closed;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FPipeStateChangedEventArgs(
            FIPipe fOwnerPipe,
            FPipeState fState
            ) 
            : base (FPipeEventId.PipeStateChanged)
        {
            m_fOwnerPipe = fOwnerPipe;
            m_fState = fState;            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPipeStateChangedEventArgs(
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
                    m_fOwnerPipe = null;
                }
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FIPipe fOwnerPipe
        {
            get
            {
                try
                {
                    return m_fOwnerPipe;
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

        public FPipeState fState
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
                return FPipeState.Closed;
            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
