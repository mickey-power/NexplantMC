/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTelnetStateChangedEventArgs.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2012.02.13
--  Description     : FAMate Core FaCommon FTelnet State Changed Event Arguments Class
--  History         : Created by byungyun.jeon at 2012.02.13
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    [Serializable]
    public class FTelnetStateChangedEventArgs : FTelnetEventArgsBase
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        FTelnetOption m_fOption;
        FTelnetPosition m_fPosition;
        FTelnetOptionState m_fOptionState;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FTelnetStateChangedEventArgs(
            FTelnetOption fOption,
            FTelnetPosition fPosition,
            FTelnetOptionState fOptionState
            ) 
            : base (FTelnetEventId.TelnetStateChanged)
        {
            m_fOption = fOption;
            m_fPosition = fPosition;
            m_fOptionState = fOptionState;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTelnetStateChangedEventArgs(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void myDispose(
            bool disposing
            )
        {
            if (!this.m_disposed)
            {
                if (disposing)
                {

                }
                this.m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FTelnetOption fOption
        {
            get
            {
                try
                {
                    return this.m_fOption;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return this.m_fOption;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTelnetPosition fPosition
        {
            get
            {
                try
                {
                    return m_fPosition;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return m_fPosition;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTelnetOptionState fOptionState
        {
            get
            {
                try
                {
                    return m_fOptionState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return m_fOptionState;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    } // Class end
} // Namespace end