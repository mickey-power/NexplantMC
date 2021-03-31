/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMelseceWordResult.cs
--  Creator         : spike.lee
--  Create Date     : 2013.10.23
--  Description     : FAMate Core FaPlcDriver Melsec Ethernet Word Result Class 
--  History         : Created by spike.lee at 2013.10.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal class FMelseceWordResult : FMelseceResult, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private byte[] m_bytes = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FMelseceWordResult(
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FMelseceWordResult(
            UInt16 exitCode,
            UInt16 command,
            UInt16 subCommand
            )
            : base(exitCode, command, subCommand)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FMelseceWordResult(
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
        }

        #endregion
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public override FPlcResultType fType
        {
            get
            {
                try
                {
                    return FPlcResultType.Word;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FPlcResultType.Word;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public byte[] bytes
        {
            get
            {
                try
                {
                    return m_bytes;
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

            set
            {
                try
                {
                    m_bytes = value;
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
