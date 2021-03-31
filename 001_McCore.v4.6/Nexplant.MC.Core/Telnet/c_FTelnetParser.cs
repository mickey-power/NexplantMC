/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011   Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTelnetParser.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2012.02.11
--  Description     : FAMate Core FaCommon Telnet Parser Class
--  History         : Created by byungyun.jeon at 2012.01.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Net.Sockets;

namespace Nexplant.MC.Core.FaCommon
{
    public class FTelnetParser : IDisposable
    {
        
        //------------------------------------------------------------------------------------------------------------------------

        public const byte IAC = 255;

        private bool m_disposed = false;
        // -- 
        private FTcpClient m_fTcpClient = null;
        private FTelnetParserState m_fState;
        private FTelnetRecvBuffer m_fRecvBuffer = null;

        //------------------------------------------------------------------------------------------------------------------------    

        #region Class Constructions and Destruction

        public FTelnetParser(
            FTcpClient fTcpClient
            )
        {
            if (fTcpClient == null)
            {
                FDebug.throwFException(string.Format(FConstants.err_m_0016, "TCP Client"));
            }
            // --
            if (fTcpClient.fState == FTcpClientState.Closed)
            {
                FDebug.throwFException(string.Format(FConstants.err_m_0013, "TCP Client"));
            }
            // --
            this.m_fTcpClient = fTcpClient;
            
            // -- 
            
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------    

        ~FTelnetParser(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------    

        protected void myDispose(
            bool disposing
            )
        {
            if(!m_disposed)
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

        public FTcpClient fTcpClient
        {
            get
            {
                try
                {
                    return this.m_fTcpClient;
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

        public FTelnetParserState fState
        {
            get
            {
                try
                {
                    return this.m_fState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FTelnetParserState.Data;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------    

        #region Methods

        private void init(
            )
        {
            m_fRecvBuffer = new FTelnetRecvBuffer();
        }

        //------------------------------------------------------------------------------------------------------------------------    

        private void term(
            )
        {
            try
            {
                if (m_fRecvBuffer != null)
                {
                    m_fRecvBuffer.Dispose();
                    m_fRecvBuffer = null;
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
                this.m_fTcpClient.close();
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
        
        public void appendData(
            byte[] data
            )
        {
            try
            {
                m_fRecvBuffer.input(data);
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

        public FITelnetPacket readNext(
            )
        {
            int index = 0;
            bool isReturn = false;

            byte byteValue;
            byte[] buffer = null;
            FITelnetPacket fPacket = null;
            FTelnetByteBuffer fDataPacket = null;
            
            try
            {
                fDataPacket = new FTelnetByteBuffer();
                
                index = 0;
                buffer = m_fRecvBuffer.watch(m_fRecvBuffer.length);

                do
                {
                    if (buffer.Length == index)
                    {
                        if (index != 0)
                        {
                            m_fRecvBuffer.output(index);
                        }
                        return fPacket;
                    }

                    byteValue = buffer[index++];

                    if (this.fState == FTelnetParserState.Data)
                    {
                        #region [Data State]

                        if (byteValue == FAsciiByte.CR)
                        {
                            fDataPacket.append(FAsciiByte.CR);
                            this.m_fState = FTelnetParserState.ReceivedCarriageReturn;
                        }
                        else if (byteValue == (byte)FTelnetCommand.Iac)
                        {
                            if (fDataPacket.count > 0)
                            {
                                m_fRecvBuffer.output(fDataPacket.count);
                                return new FTelnetDataPacket(fDataPacket.toArrary());
                            }
                            this.m_fState = FTelnetParserState.ReceivedIAC;
                        }
                        else
                        {
                            fDataPacket.append(byteValue);
                        }

                        #endregion
                    }
                    else if(this.fState == FTelnetParserState.ReceivedCarriageReturn)
                    {
                        #region [Received Carriage Return State]

                        if (byteValue != FAsciiByte.NUL)
                        {
                            fDataPacket.append(byteValue);
                        }
                        this.m_fState = FTelnetParserState.Data;

                        #endregion
                    }
                    else if (this.fState == FTelnetParserState.ReceivedIAC)
                    {
                        #region [ Received IAC State ]

                        if (byteValue == (byte)FTelnetCommand.Iac)
                        {
                            fDataPacket.append(byteValue);
                            this.m_fState = FTelnetParserState.Data;
                        }
                        else
                        {
                            if (
                                byteValue == (byte)FTelnetCommand.AbortOutput ||
                                byteValue == (byte)FTelnetCommand.AreYouThere ||
                                byteValue == (byte)FTelnetCommand.Break ||
                                byteValue == (byte)FTelnetCommand.DataMark ||
                                byteValue == (byte)FTelnetCommand.EraseCharacter ||
                                byteValue == (byte)FTelnetCommand.EraseLine ||
                                byteValue == (byte)FTelnetCommand.GoAhead ||
                                byteValue == (byte)FTelnetCommand.InterruptProcess ||
                                byteValue == (byte)FTelnetCommand.NoOperation 
                                )
                            {
                                m_fRecvBuffer.output(index);
                                fPacket = new FTelnetCommandPacket((FTelnetCommand)byteValue);
                                this.m_fState = FTelnetParserState.Data;
                            }
                            else if (byteValue == (byte)FTelnetCommand.Do)
                            {
                                this.m_fState = FTelnetParserState.ReceivedDo;
                            }
                            else if (byteValue == (byte)FTelnetCommand.Dont)
                            {
                                this.m_fState = FTelnetParserState.ReceivedDont;
                            }
                            else if (byteValue == (byte)FTelnetCommand.Will)
                            {
                                this.m_fState = FTelnetParserState.ReceivedWill;
                            }
                            else if (byteValue == (byte)FTelnetCommand.Wont)
                            {
                                this.m_fState = FTelnetParserState.ReceivedWont;
                            }
                            else
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0015, "Command"));
                            }
                        }

                        #endregion

                    }
                    else if (this.fState == FTelnetParserState.ReceivedDo)
                    {
                        m_fRecvBuffer.output(index);
                        fPacket = new FTelnetOptionPacket(FTelnetCommand.Do, byteValue);
                        this.m_fState = FTelnetParserState.Data;
                    }
                    else if (this.fState == FTelnetParserState.ReceivedDont)
                    {
                        m_fRecvBuffer.output(index);
                        fPacket = new FTelnetOptionPacket(FTelnetCommand.Dont, byteValue);
                        this.m_fState = FTelnetParserState.Data;
                    }
                    else if (this.fState == FTelnetParserState.ReceivedWill)
                    {
                        m_fRecvBuffer.output(index);
                        fPacket = new FTelnetOptionPacket(FTelnetCommand.Will, byteValue);
                        this.m_fState = FTelnetParserState.Data;
                    }
                    else if (this.fState == FTelnetParserState.ReceivedWont)
                    {
                        m_fRecvBuffer.output(index);
                        fPacket = new FTelnetOptionPacket(FTelnetCommand.Wont, byteValue);
                        this.m_fState = FTelnetParserState.Data;
                    }
                    
                    // --

                    if (fPacket == null && fDataPacket.count > 0)
                    {
                        isReturn = (fDataPacket.count == m_fRecvBuffer.length);

                        if (!isReturn)
                        {
                            isReturn = (index == m_fRecvBuffer.length);                                
                        }

                        if (isReturn)
                        {
                            m_fRecvBuffer.clear();
                            return new FTelnetDataPacket(fDataPacket.toArrary());
                        }
                    }

                } while (fPacket == null);

                return fPacket;
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

        //------------------------------------------------------------------------------------------------------------------------    

        public void sendCommand(
            FTelnetCommand fCommand
            )
        {
            try
            {
                if (
                    fCommand == FTelnetCommand.AbortOutput ||
                    fCommand == FTelnetCommand.AreYouThere ||
                    fCommand == FTelnetCommand.Break ||
                    fCommand == FTelnetCommand.DataMark ||
                    fCommand == FTelnetCommand.EraseCharacter ||
                    fCommand == FTelnetCommand.EraseLine ||
                    fCommand == FTelnetCommand.GoAhead ||
                    fCommand == FTelnetCommand.Iac ||
                    fCommand == FTelnetCommand.InterruptProcess ||
                    fCommand == FTelnetCommand.NoOperation
                    )
                {
                    sendRaw(new byte[] { IAC, (byte)fCommand });
                }                
                else
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0015, "Command"));
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

        public void sendCommand(
            FTelnetCommand fCommand,
            FTelnetOption fOption
            )
        {
            try
            {
                if (
                    fCommand == FTelnetCommand.Do ||
                    fCommand == FTelnetCommand.Dont ||
                    fCommand == FTelnetCommand.Will ||
                    fCommand == FTelnetCommand.Wont
                    )
                {
                    sendRaw(new byte[] { IAC, (byte)fCommand, (byte)fOption });
                }
                else
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0015, "Command"));
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

        public void sendDo(
            byte option
            )
        {
            try
            {
                sendRaw(new byte[] { IAC, (byte)FTelnetCommand.Do, option });
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
            try
            {
                sendRaw(new byte[] { IAC, (byte)FTelnetCommand.Do, (byte)fOption });
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

        public void sendDont(
            byte option
            )
        {
            try
            {
                sendRaw(new byte[] { IAC, (byte)FTelnetCommand.Dont, option });
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

        public void sendDont(
            FTelnetOption fOption
            )
        {
            try
            {
                sendRaw(new byte[] { IAC, (byte)FTelnetCommand.Dont, (byte)fOption });
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
        
        public void sendWill(
            byte option
            )
        {
            try
            {
                sendRaw(new byte[] { IAC, (byte)FTelnetCommand.Will, option });
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

        public void sendWill(
            FTelnetOption fOption
            )
        {
            try
            {
                sendRaw(new byte[] { IAC, (byte)FTelnetCommand.Will, (byte)fOption });
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

        public void sendWont(
            byte option
            )
        {
            try
            {
                sendRaw(new byte[] { IAC, (byte)FTelnetCommand.Wont, option });
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

        public void sendWont(
            FTelnetOption fOption
            )
        {
            try
            {
                sendRaw(new byte[] { IAC, (byte)FTelnetCommand.Wont, (byte)fOption });
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
               
        public void sendEscaped(
            byte[] buffer
            )
        {
            FTelnetByteBuffer fEscapeBuffer = null;

            try
            {
                if (buffer == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Buffer"));
                }

                // --

                fEscapeBuffer = new FTelnetByteBuffer(buffer);
                fEscapeBuffer.doDouble(IAC);
                sendRaw(fEscapeBuffer.toArrary());
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

        public void sendGoAhead()
        {
            try
            {
                sendCommand(FTelnetCommand.GoAhead);
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

        public void sendRaw(
            byte[] buffer
            )
        {
            try
            {
                if (buffer == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Buffer"));
                }
                this.m_fTcpClient.send(new FSocketSendData(buffer));
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