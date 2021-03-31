/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011   Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTelnetClient.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2012.02.11
--  Description     : FAMate Core FaCommon Telnet Client Class
--  History         : Created by byungyun.jeon at 2012.01.17
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace Nexplant.MC.Core.FaCommon
{
    public class FTelnetClient : IDisposable
    {
        
        //------------------------------------------------------------------------------------------------------------------------

        public event FTelnetStateChangedEventHandler TelnetStateChanged;
        public event FTelnetPacketReceivedEventHandler TelnetPacketReceived;
        public event FTelnetPacketSentEventHandler TelnetPacketSent;

        public const int DefaultPort = 23;

        private bool m_disposed = false;
        // --
        private BitArray m_enabledOptions = null;
        private BitArray m_localOptions = null;
        private BitArray m_remoteOptions = null;
        private List<FTelnetOptionPacket> m_fReqQueue = null;
        private FTelnetParser m_fParser = null;
        // --
        private FCodeLock m_fMainSync = null;
        private FTelnetEventPusher m_fEventPusher = null;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Constructions and Destruction

        private FTelnetClient(
            )
        {
            this.m_enabledOptions = new BitArray(256, false);
            this.m_localOptions = new BitArray(256, false);
            this.m_remoteOptions = new BitArray(256, false);

            this.m_fReqQueue = new List<FTelnetOptionPacket>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTelnetClient(
            FTcpClient fTcpClient
            )
            : this()
        {
            this.m_fParser = new FTelnetParser(fTcpClient);
            // --
            init();
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        ~FTelnetClient(
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

        public FTelnetParser fParser
        {
            get
            {
                try
                {
                    return this.m_fParser;
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

        private void init(
            )
        {
            try
            {
                m_fMainSync = new FCodeLock();
                m_fEventPusher = new FTelnetEventPusher(this, false);
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

        private void term(
            )
        {
            try
            {
                if (this.m_fParser != null)
                {
                    this.m_fParser.Dispose();
                    this.m_fParser = null;
                }

                if (this.m_fMainSync != null)
                {
                    this.m_fMainSync.Dispose();
                    this.m_fMainSync = null;
                }

                this.m_localOptions = null;
                this.m_remoteOptions = null;

                if (m_fEventPusher != null)
                {
                    m_fEventPusher.waitEventHandlingCompleted();
                    m_fEventPusher.Dispose();
                    m_fEventPusher = null;
                }
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

        public void close(
            )
        {
            try
            {
                this.m_fParser.close();
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

        public void enableService(
            FTelnetOption fTargetOption,
            bool enable
            )
        {
            try
            {
                this.m_enabledOptions[(int)fTargetOption] = enable;
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

        public bool doingLocalOption(
            FTelnetOption fOption
            )
        {
            try
            {
                this.m_fMainSync.wait();

                // -- 

                return this.m_localOptions[(int)fOption];
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally 
            {
                this.m_fMainSync.set();                
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool doingRemoteOption(
            FTelnetOption fOption
            )
        {
            try
            {
                this.m_fMainSync.wait();

                // -- 

                return this.m_remoteOptions[(int)fOption];
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                this.m_fMainSync.set();
            }
            return false;
        }
                
        //------------------------------------------------------------------------------------------------------------------------

        public void parse(
            byte[] buffer
            )
        {
            FITelnetPacket fPacket = null;

            try
            {
                this.fParser.appendData(buffer);

                // -- 

                fPacket = this.fParser.readNext();

                while(fPacket != null)
                {
                    this.pushPacketReceived(fPacket);
                    // -- 
                    if (fPacket.fPacketType == FTelnetPacketType.Option)
                    {
                        if (((FTelnetOptionPacket)fPacket).fCommand == FTelnetCommand.Do)
                        {
                            this.procDoOption(((FTelnetOptionPacket)fPacket).fOption);
                        }
                        else if (((FTelnetOptionPacket)fPacket).fCommand == FTelnetCommand.Dont)
                        {
                            this.procDontOption(((FTelnetOptionPacket)fPacket).fOption);
                        }
                        else if (((FTelnetOptionPacket)fPacket).fCommand == FTelnetCommand.Will)
                        {
                            this.procWillOption(((FTelnetOptionPacket)fPacket).fOption);
                        }
                        else if (((FTelnetOptionPacket)fPacket).fCommand == FTelnetCommand.Wont)
                        {
                            this.procWontOption(((FTelnetOptionPacket)fPacket).fOption);
                        }
                    }

                    // -- 

                    fPacket = this.fParser.readNext();

                } 
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
        
        public void sendData(
            byte value
            )
        {
            try
            {
                this.pushPacketSent(new FTelnetDataPacket(new byte[] { value }));
                this.fParser.sendEscaped(new byte[]{ value });
            }
            catch(Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void sendData(
            byte[] buffer            
            )
        {
            try
            {
                this.pushPacketSent(new FTelnetDataPacket(buffer));
                this.fParser.sendEscaped(buffer);
            }
            catch(Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void sendGoAhead(
            )
        {
            try
            {
                this.pushPacketSent(new FTelnetCommandPacket(FTelnetCommand.GoAhead));
                this.fParser.sendGoAhead();
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

        public void sendDo(
            FTelnetOption fOption
            )
        {
            FTelnetOptionPacket fPacket = null; 

            try
            {
                fPacket = new FTelnetOptionPacket(FTelnetCommand.Do, fOption);

                // -- 

                this.pushPacketSent(fPacket);
                this.m_fReqQueue.Add(fPacket);

                // -- 

                this.fParser.sendDo(fOption);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fPacket != null)
                {
                    fPacket.Dispose();
                    fPacket = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void sendDont(
            FTelnetOption fOption
            )
        {
            FTelnetOptionPacket fPacket = null; 

            try
            {
                fPacket = new FTelnetOptionPacket(FTelnetCommand.Dont, fOption);

                // --

                this.pushPacketSent(fPacket);
                this.m_fReqQueue.Add(fPacket);

                // -- 

                this.fParser.sendDont(fOption);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fPacket != null)
                {
                    fPacket.Dispose();
                    fPacket = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void sendWill(
            FTelnetOption fOption
            )
        {
            FTelnetOptionPacket fPacket = null; 

            try
            {
                fPacket = new FTelnetOptionPacket(FTelnetCommand.Will, fOption);

                // -- 

                this.pushPacketSent(fPacket);
                this.m_fReqQueue.Add(fPacket);

                // -- 

                this.fParser.sendWill(fOption);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fPacket != null)
                {
                    fPacket.Dispose();
                    fPacket = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void sendWont(
            FTelnetOption fOption
            )
        {
            FTelnetOptionPacket fPacket = null; 

            try
            {
                fPacket = new FTelnetOptionPacket(FTelnetCommand.Wont, fOption);
                
                // -- 
                
                this.pushPacketSent(fPacket);
                this.m_fReqQueue.Add(fPacket);

                // -- 

                this.fParser.sendWont(fOption);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fPacket != null)
                {
                    fPacket.Dispose();
                    fPacket = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void pushStateChanged(
            FTelnetOption fOption,
            FTelnetPosition fPosition,
            FTelnetOptionState fOptionState
            )
        {
            try
            {
                this.m_fEventPusher.pushEvent(new FTelnetStateChangedEventArgs(fOption, fPosition, fOptionState));
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

        private void pushPacketReceived(
            FITelnetPacket fPacket
            )
        {
            try
            {
                this.m_fEventPusher.pushEvent(new FTelnetPacketReceivedEventArgs(fPacket));
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

        private void pushPacketSent(
            FITelnetPacket fPacket
            )
        {
            try
            {
                this.m_fEventPusher.pushEvent(new FTelnetPacketSentEventArgs(fPacket));
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

        internal void onTelnetStateChanged(
            FTelnetEventArgsBase args
            )
        {
            try
            {
                if (this.TelnetStateChanged != null)
                {
                    this.TelnetStateChanged(this, (FTelnetStateChangedEventArgs)args);
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

        internal void onTelnetPacketReceived(
            FTelnetEventArgsBase args
            )
        {
            try
            {
                if (this.TelnetPacketReceived != null)
                {
                    this.TelnetPacketReceived(this, (FTelnetPacketReceivedEventArgs)args);
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

        internal void onTelnetPacketSent(
            FTelnetEventArgsBase args
            )
        {
            try
            {
                if (this.TelnetPacketSent != null)
                {
                    this.TelnetPacketSent(this, (FTelnetPacketSentEventArgs)args);
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

        private void procDoOption(
            FTelnetOption fOption
            )
        {
            int option;
            bool isResponse;

            try
            {
                option = (int)fOption;
                isResponse = isResponseDoOption(fOption);

                if (this.m_enabledOptions[option]) 
                {
                    if (!this.m_localOptions[option])
                    {
                        this.m_localOptions[option] = true;
                        pushStateChanged(fOption, FTelnetPosition.Local, FTelnetOptionState.On);
                        
                        // --

                        if (!isResponse)
                        {
                            this.sendWill(fOption);
                        }                        
                    }
                }
                else
                {
                    if (this.m_localOptions[option])
                    {
                        this.m_localOptions[option] = false;
                        pushStateChanged(fOption, FTelnetPosition.Local, FTelnetOptionState.Off);
                    }
                    
                    // --
                    
                    if (!isResponse)
                    {
                        this.sendWont(fOption);
                    }                    
                }
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
        
        private void procDontOption(
            FTelnetOption fOption
            )
        {
            int option;
            bool isResponse;

            try
            {
                this.m_fMainSync.wait();

                // -- 

                option = (int)fOption;
                isResponse = isResponseDontOption(fOption);

                if (
                    this.m_enabledOptions[option] &&
                    this.m_localOptions[option]
                    )
                {
                    if (this.m_localOptions[option])
                    {
                        this.m_localOptions[option] = false;
                        pushStateChanged(fOption, FTelnetPosition.Local, FTelnetOptionState.Off);
                    }                    
                    
                    // -- 

                    if (!isResponse)
                    {
                        this.sendWont(fOption);
                    }                    
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procWillOption(
            FTelnetOption fOption
            )
        {
            int option;
            bool isResponse;

            try
            {
                m_fMainSync.wait();

                // -- 

                option = (int)fOption;
                isResponse = isResponseWillOption(fOption);

                if (this.m_enabledOptions[option] != this.m_remoteOptions[option])
                {
                    this.m_remoteOptions[option] = this.m_enabledOptions[option];
                    // --
                    this.pushStateChanged(
                        fOption,
                        FTelnetPosition.Remote,
                        this.m_remoteOptions[option] ? FTelnetOptionState.On : FTelnetOptionState.Off
                        );

                    // -- 

                    if (!isResponse)
                    {
                        if (this.m_enabledOptions[option])
                        {
                            this.sendDo(fOption);
                        }
                        else
                        {
                            this.sendDont(fOption);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procWontOption(
            FTelnetOption fOption
            )
        {
            int option;
            bool isResponse;

            try
            {
                m_fMainSync.wait();

                // -- 

                option = (int)fOption;
                isResponse = isResponseWontOption(fOption);

                if (this.m_remoteOptions[option])
                {
                    if (!isResponse)
                    {
                        this.sendDont(fOption);
                    }
                    
                    // -- 

                    if (this.m_remoteOptions[option])
                    {
                        this.m_remoteOptions[option] = false;
                        this.pushStateChanged(fOption, FTelnetPosition.Remote, FTelnetOptionState.Off);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool isResponseDoOption(
            FTelnetOption fOption
            )
        {
            try
            {                
                for (int i = 0; i < m_fReqQueue.Count; i++)
                {
                    if (
                        m_fReqQueue[i].fCommand == FTelnetCommand.Will &&
                        m_fReqQueue[i].fOption == fOption
                        )
                    {
                        m_fReqQueue.RemoveAt(i);
                        return true;
                    }
                }
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

        private bool isResponseDontOption(
            FTelnetOption fOption
            )
        {
            try
            {
                for (int i = 0; i < m_fReqQueue.Count; i++)
                {
                    if (
                        (m_fReqQueue[i].fCommand == FTelnetCommand.Will || m_fReqQueue[i].fCommand == FTelnetCommand.Wont) && 
                        m_fReqQueue[i].fOption == fOption
                        )
                    {
                        m_fReqQueue.RemoveAt(i);
                        return true;
                    }
                }
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

        private bool isResponseWillOption(
            FTelnetOption fOption
            )
        {
            try
            {
                for (int i = 0; i < m_fReqQueue.Count; i++)
                {
                    if (
                        m_fReqQueue[i].fCommand == FTelnetCommand.Do &&
                        m_fReqQueue[i].fOption == fOption
                        )
                    {
                        m_fReqQueue.RemoveAt(i);
                        return true;
                    }
                }
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

        private bool isResponseWontOption(
            FTelnetOption fOption
            )
        {
            try
            {
                for (int i = 0; i < m_fReqQueue.Count; i++)
                {
                    if (
                        (m_fReqQueue[i].fCommand == FTelnetCommand.Do || m_fReqQueue[i].fCommand == FTelnetCommand.Dont) &&
                        m_fReqQueue[i].fOption == fOption
                        )
                    {
                        m_fReqQueue.RemoveAt(i);
                        return true;
                    }
                }
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
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end