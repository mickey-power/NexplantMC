/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTelnetOptionPacket.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2012.02.22
--  Description     : FAMate Core FaCommon Telnet Option Packet Class
--  History         : Created by byungyun.jeon at 2012.02.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public class FTelnetOptionPacket : FITelnetPacket, IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTelnetCommand m_fCommand;
        private FTelnetOption m_fOption;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Contruction and Destruction

        public FTelnetOptionPacket(
            FTelnetCommand fCommand,
            FTelnetOption fOption
            )
        {
            if (
                fCommand == FTelnetCommand.Do ||
                fCommand == FTelnetCommand.Dont ||
                fCommand == FTelnetCommand.Will ||
                fCommand == FTelnetCommand.Wont
                )
            {
                this.m_fCommand = fCommand;
                this.m_fOption = fOption;
            }
            else
            {
                FDebug.throwFException(string.Format(FConstants.err_m_0015, "Command"));
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTelnetOptionPacket(
            FTelnetCommand fCommand,
            byte option
            )
            : this(fCommand, (FTelnetOption)option)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTelnetOptionPacket(
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
                    term();
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

        public FTelnetPacketType fPacketType
        {
            get
            {
                try
                {
                    return FTelnetPacketType.Option;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FTelnetPacketType.Option;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTelnetCommand fCommand
        {
            get
            {
                try
                {
                    return this.m_fCommand;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FTelnetCommand.NoOperation;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTelnetOption fOption
        {
            get
            {
                try
                {
                    return m_fOption;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FTelnetOption.TransmitBinary;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void term()
        {
            try
            {
    
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