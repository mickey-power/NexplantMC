/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FApplicationWrittenEventArgs.cs
--  Creator         : spike.lee
--  Create Date     : 2012.04.25
--  Description     : FAMate Core FaSecsDriver Application Written Event Arguments Class 
--  History         : Created by spike.lee at 2012.04.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    [Serializable]
    public class FApplicationWrittenEventArgs : FEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSecsDriver m_fSecsDriver = null;
        private FApplicationWrittenLog m_fApplicationWrittenLog = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FApplicationWrittenEventArgs(            
            FEventId fEventId,
            FSecsDriver fSecsDriver,
            FApplicationWrittenLog fApplicationWrittenLog
            )
            : base(fEventId)
        {
            m_fSecsDriver = fSecsDriver;
            m_fApplicationWrittenLog = fApplicationWrittenLog;            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FApplicationWrittenEventArgs(
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
                    m_fSecsDriver = null;
                    m_fApplicationWrittenLog = null;
                }
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FSecsDriver fSecsDriver
        {
            get
            {
                try
                {
                    return m_fSecsDriver;
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

        public FApplicationWrittenLog fApplicationWrittenLog
        {
            get
            {
                try
                {
                    return m_fApplicationWrittenLog;
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
