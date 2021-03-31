/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FConstant.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.07
--  Description     : FAMate Core FaSecsDriver Constant Definition Class 
--  History         : Created by spike.lee at 2011.01.07
                      Modified by spike.lee at 2011.09.08
                        - HSMS Status and Reason Error Message Define
                        - HSMS Timeout Description and Error Message Define
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal static class FConstants
    {

        //------------------------------------------------------------------------------------------------------------------------       

        public const char ValueFormulaSeparator = (char)0x1E;       // Record Separator
        public const char ValueFormulaUnitSeparator = (char)0x1F;   // Unit Separator
        // --
        public const char PreconditionValueSeparator = (char)0x1E;  // Record Separator
        // --        
        public const char DataCovnersionExpressionSeparator = (char)0x0E;   // Shift out
        public const char DataConversionSeparator = (char)0x1C;             // File Separator
        public const char DataConversionUnitSeparator = (char)0x1D;         // Group Separator
        // --
        public const string DirectionSymbolBoth = "H<->E";
        public const string DirectionSymbolEquipment = "H<-E";
        public const string DirectionSymbolHost = "H->E";

        //------------------------------------------------------------------------------------------------------------------------       

        // ***
        // Host Driver Namespace
        // ***
        public const string HostDriverName = "Nexplant.MC.HostDriver.SECS.FHostDriver";

        //------------------------------------------------------------------------------------------------------------------------       

        // ***
        // 2017.04.04 by spike.lee
        // Repository File Name
        // ***
        public const string RepositoryFileName = "repository.rpm";

        //------------------------------------------------------------------------------------------------------------------------       

        #region Error Message Definition

        #region Comments
        /// <summary>
        /// A string literal contained an invalid character.
        /// </summary>
        #endregion
        public const string err_m_0001 = "A string literal contained an invalid character.";

        #region Comments
        /// <summary>
        /// A string literal is empty.
        /// </summary>
        #endregion
        public const string err_m_0002 = "A string literal is empty.";

        #region Comments
        /// <summary>
        /// The {0} already exists.
        /// </summary>
        #endregion
        public const string err_m_0003 = "The {0} already exists.";

        #region Comments
        /// <summary>
        /// The {0} is already having the {1}.
        /// </summary>
        #endregion        
        public const string err_m_0004 = "The {0} is already having the {1}.";

        #region Comments
        /// <summary>
        /// The {0} was already removed.
        /// </summary>
        #endregion
        public const string err_m_0005 = "The {0} was already removed.";

        #region Comments
        /// <summary>
        /// The {0} cannot set the {1}.
        /// </summary>
        #endregion        
        public const string err_m_0006 = "The {0} cannot set the {1}.";

        #region Comments
        /// <summary>
        /// The {0} cannot append the {1}.
        /// </summary>
        #endregion        
        public const string err_m_0007 = "The {0} cannot append the {1}.";

        #region Comments
        /// <summary>
        /// The {0} cannot change the {1}.
        /// </summary>
        #endregion
        public const string err_m_0008 = "The {0} cannot change the {1}.";

        #region Comments
        /// <summary>
        /// The {0} cannot have the {1}.
        /// </summary>
        #endregion
        public const string err_m_0009 = "The {0} cannot have the {1}.";        

        #region Comments
        /// <summary>
        /// The {0} is the {1}.
        /// </summary>
        #endregion
        public const string err_m_0010 = "The {0} is the {1}.";

        #region Comments
        /// <summary>
        /// The {0} is not the {1}.
        /// </summary>
        #endregion
        public const string err_m_0011 = "The {0} is not the {1}.";

        #region Comments
        /// <summary>
        /// The {0} was locked.
        /// </summary>
        #endregion
        public const string err_m_0012 = "The {0} was locked.";

        #region Comments
        /// <summary>
        /// The {0} exists.
        /// </summary>
        #endregion
        public const string err_m_0013 = "The {0} exists.";

        #region Comments
        /// <summary>
        /// The {0} is out of range.
        /// </summary>
        #endregion
        public const string err_m_0014 = "The {0} is out of range.";

        #region Comments
        /// <summary>
        /// The {0} is invalid.
        /// </summary>
        #endregion
        public const string err_m_0015 = "The {0} is invalid.";

        #region Comments
        /// <summary>
        /// The {0} does not exist.
        /// </summary>
        #endregion
        public const string err_m_0016 = "The {0} does not exist.";

        #region Comments
        /// <summary>
        /// The {0} is not included in the {1}.
        /// </summary>
        #endregion
        public const string err_m_0017 = "The {0} is not included in the {1}.";
       
        #region Comments
        /// <summary>
        /// The {0} cannot append more then {1}.
        /// </summary>
        #endregion
        public const string err_m_0018 = "The {0} cannot append more then {1}.";

        #region Comments
        /// <summary>
        /// The {0} cannot be used.
        /// </summary>
        #endregion
        public const string err_m_0019 = "The {0} cannot be used.";

        #region Comments
        /// <summary>
        /// The {0} cannot append the {1}.
        /// </summary>
        #endregion
        public const string err_m_0020 = "The {0} cannot append the {1}.";

        #region Comments
        /// <summary>
        /// The {0} cannot be moved up.
        /// </summary>
        #endregion
        public const string err_m_0021 = "The {0} cannot be moved up.";
        
        #region Comments
        /// <summary>
        /// The {0} cannot be moved down.
        /// </summary>
        #endregion
        public const string err_m_0022 = "The {0} cannot be moved down.";

        #region Comments
        /// <summary>
        /// The {0} was connected.
        /// </summary>
        #endregion
        public const string err_m_0023 = "The {0} was connected.";

        #region Comments
        /// <summary>
        /// The {0} was closed.
        /// </summary>
        #endregion
        public const string err_m_0024 = "The {0} was closed.";

        #region Comments
        /// <summary>
        /// The {0} was sent to {1}.
        /// </summary>
        #endregion
        public const string err_m_0025 = "The {0} was sent to {1}.";

        #region Comments
        /// <summary>
        /// The {0} was received from {1}.
        /// </summary>
        #endregion
        public const string err_m_0026 = "The {0} was received from {1}.";

        #region Comments
        /// <summary>
        /// The {0} is currently open.
        /// </summary>
        #endregion
        public const string err_m_0027 = "The {0} is currently open.";

        #region Comments
        /// <summary>
        /// The {0} is not defined.
        /// </summary>
        #endregion
        public const string err_m_0028 = "The {0} is not defined.";

        #region Comments
        /// <summary>
        /// The {0} is not open.
        /// </summary>
        #endregion
        public const string err_m_0029 = "The {0} is not open.";

        #region Comments
        /// <summary>
        /// The {0} is not the SELECTED state.
        /// </summary>
        #endregion
        public const string err_m_0030 = "The {0} is not the SELECTED state.";

        #region Comments
        /// <summary>
        /// Transaction Not Open. A Response data message was received when there was no outstanding request message which corresponded to it.
        /// </summary>
        #endregion
        public const string err_m_0031 = "Transaction Not Open. A Response data message was received when there was no outstanding request message which corresponded to it.";

        #region Comments
        /// <summary>
        /// Transaction reply timeout occured.
        /// </summary>
        #endregion
        public const string err_m_0032 = "Transaction reply timeout occured.";

        #region Comments
        /// <summary>
        /// The {0} is empty.
        /// </summary>
        #endregion
        public const string err_m_0033 = "The {0} is empty.";

        #region Comments
        /// <summary>
        /// The {0} is not used.
        /// </summary>
        #endregion
        public const string err_m_0034 = "The {0} is not used.";

        #region Comments
        /// <summary>
        /// The {0} is discrepancy.
        /// </summary>
        #endregion
        public const string err_m_0035 = "The {0} is discrepancy.";

        #region Comments
        /// <summary>
        /// The Host Driver is not supported. The Property of the Host Driver will be reset.
        /// </summary>
        #endregion
        public const string err_m_0036 = "The Host Driver is not supported. The Property of the Host Driver will be reset.";

        #region Comments
        /// <summary>
        /// Failed to create an instance of the Host Driver.
        /// </summary>
        #endregion
        public const string err_m_0037 = "Failed to create an instance of the {0}.";

        #region Comments
        /// <summary>
        /// The {0} cannot be move to the {0}.
        /// </summary>
        #endregion
        public const string err_m_0060 = "The {0} cannot be move to the {1}.";

        #region Comments
        /// <summary>
        /// The {0} is not {1}.
        /// </summary>
        #endregion
        public const string err_m_0061 = "The {0} is not {1}.";

        // --

        #region Comments
        /// <summary>
        /// Communication Already Active. A previous select has already established communications to the entity being selected in this select.
        /// </summary>
        #endregion
        public const string err_m_12001 = "Communication Already Active. A previous select has already established communications to the entity being selected in this select.";

        #region Comments
        /// <summary>
        /// Connection Not Ready. The Connection is not yet ready to accept select requests.
        /// </summary>
        #endregion
        public const string err_m_12002 = "Connection Not Ready. The Connection is not yet ready to accept select requests.";

        #region Comments
        /// <summary>
        /// Connect Exhaust. The connection was accepted, but the entity is already servicing a separate TCP/IP connection and is unable to service more than one at any given time.
        /// </summary>
        #endregion
        public const string err_m_12003 = "Connect Exhaust. The connection was accepted, but the entity is already servicing a separate TCP/IP connection and is unable to service more than one at any given time.";

        #region Comments
        /// <summary>
        /// Reserved for subsidiary standard-specific reasons for select failure.
        /// </summary>
        #endregion
        public const string err_m_12004 = "Reserved for subsidiary standard-specific reasons for select failure.";

        #region Comments
        /// <summary>
        /// Reserved for local entity-specific reasons for select failure.
        /// </summary>
        #endregion
        public const string err_m_12128 = "Reserved for local entity-specific reasons for select failure.";

        #region Comments
        /// <summary>
        /// Communication Not Established. HSMS communications has not yet been established with a select, or has already been ended with a previous Deselect.
        /// </summary>
        #endregion
        public const string err_m_14001 = "Communication Not Established. HSMS communications has not yet been established with a select, or has already been ended with a previous Deselect.";

        #region Comments
        /// <summary>
        /// Communication Busy. The session is still in use by the responding entity and so it cannot yet relinquish it gracefully. In this case, if the original requester must terminate communications, the separate procedure should be used as a last resort.
        /// </summary>
        #endregion
        public const string err_m_14002 = "Communication Busy. The session is still in use by the responding entity and so it cannot yet relinquish it gracefully. In this case, if the original requester must terminate communications, the separate procedure should be used as a last resort.";

        #region Comments
        /// <summary>
        /// Reserved for subsidiary standard-specific reasons for Deselect failure.
        /// </summary>
        #endregion
        public const string err_m_14003 = "Reserved for subsidiary standard-specific reasons for Deselect failure.";

        #region Comments
        /// <summary>
        /// Reserved for local entity-specific reasons for Deselect failure.
        /// </summary>
        #endregion
        public const string err_m_14128 = "Reserved for local entity-specific reasons for Deselect failure.";

        #region Comments
        /// <summary>
        /// The received message ({0}) is not valid.
        /// </summary>
        #endregion
        public const string err_m_16001 = "The received message (0x{0,2:X2}) is not valid.";

        #region Comments
        /// <summary>
        /// A retry-out occurred when sending the message.
        /// </summary>
        #endregion
        public const string err_m_16002 = "A retry-out occurred when sending the message.";

        #region Comments
        /// <summary>
        /// The received message is not a host message.
        /// </summary>
        #endregion
        public const string err_m_16003 = "The received message is not a host message.";

        #region Comments
        /// <summary>
        /// This block has been sent from unknown devices.
        /// </summary>
        #endregion
        public const string err_m_16004 = "This block has been sent from unknown devices.";

        #region Comments
        /// <summary>
        /// This block has been duplicated. Block is discarded.
        /// </summary>
        #endregion
        public const string err_m_16005 = "This block has been duplicated. Block is discarded.";
        
        #region Comments
        /// <summary>
        /// Unexpected block has been received.
        /// </summary>
        #endregion
        public const string err_m_16006 = "Unexpected block has been received.";

        #region Comments
        /// <summary>
        /// This baud rate is not valid.
        /// </summary>
        #endregion
        public const string err_m_16007 = "This baud rate is not valid.";

        #region Comments
        /// <summary>
        /// The current setting does not support the 'Interleave Mode'.
        /// </summary>
        #endregion
        public const string err_m_16008 = "The current setting does not support the 'Interleave Mode'.";

        #region Comments
        /// <summary>
        /// The Contention Status has occurred.
        /// </summary>
        #endregion
        public const string err_m_16009 = "The Contention Status has occurred.";

        #region Comments
        /// <summary>
        /// Checksum error was detected. This block is discarded.
        /// </summary>
        #endregion
        public const string err_m_16010 = "Checksum error of the block has been detected. This block is discarded.";

        #region Comments
        /// <summary>
        /// Length Byte has exceeded the allowable range.
        /// </summary>
        #endregion
        public const string err_m_16011 = "Length Byte has exceeded the allowable range.";
        
        #region Comments
        /// <summary>
        /// No results for transaction key ({0}).
        /// </summary>
        #endregion
        public const string err_m_16900 = "No results for transaction key ({0}).";

        #region Comments
        /// <summary>
        /// SType Not Supported. A message was received whose SType value not defined in the HSMS standard or the particular subsidiary standard(s) supported by the entity.
        /// </summary>
        #endregion
        public const string err_m_17001 = "SType Not Supported. A message was received whose SType value not defined in the HSMS standard or the particular subsidiary standard(s) supported by the entity.";

        #region Comments
        /// <summary>
        /// PType Not Supported. As above, but for PType.
        /// </summary>
        #endregion
        public const string err_m_17002 = "PType Not Supported. As above, but for PType.";

        #region Comments
        /// <summary>
        /// Transaction Not Open. A Response control message was received when there was no outstanding request message which corresponded to it. 
        /// </summary>
        #endregion
        public const string err_m_17003 = "Transaction Not Open. A Response control message was received when there was no outstanding request message which corresponded to it.";

        #region Comments
        /// <summary>
        /// Entity Not Selected. A data message was received when not in the SELECTED state.
        /// </summary>
        #endregion
        public const string err_m_17004 = "Entity Not Selected. A data message was received when not in the SELECTED state.";

        #region Comments
        /// <summary>
        /// Reserved for subsidiary standard-specific reasons for reject.
        /// </summary>
        #endregion
        public const string err_m_17005 = "Reserved for subsidiary standard-specific reasons for reject.";

        #region Comments
        /// <summary>
        /// Reserved for local entity-specific reasons for reject.
        /// </summary>
        #endregion
        public const string err_m_17128 = "Reserved for local entity-specific reasons for reject.";

        #region Comments
        /// <summary>
        /// T1 inter-character timeout occured.
        /// </summary>
        #endregion
        public const string err_m_20001 = "T1 inter-character timeout occurred.";

        #region Comments
        /// <summary>
        /// T2 protocol timeout occured.
        /// </summary>
        #endregion
        public const string err_m_20002 = "T2 protocol timeout occurred.";

        #region Comments
        /// <summary>
        /// T3 reply timeout occured.
        /// </summary>
        #endregion
        public const string err_m_20003 = "T3 reply timeout occurred.";

        #region Comments
        /// <summary>
        /// T4 inter-block timeout occured.
        /// </summary>
        #endregion
        public const string err_m_20004 = "T4 inter-block timeout occurred.";

        #region Comments
        /// <summary>
        /// T5 connect separation timeout occured.
        /// </summary>
        #endregion
        public const string err_m_20005 = "T5 connect separation timeout occurred.";

        #region Comments
        /// <summary>
        /// T6 control transaction timeout occured.
        /// </summary>
        #endregion
        public const string err_m_20006 = "T6 control transaction timeout occurred.";

        #region Comments
        /// <summary>
        /// T7 NOT SELECTED timeout occured.
        /// </summary>
        #endregion
        public const string err_m_20007 = "T7 NOT SELECTED timeout occurred.";

        #region Comments
        /// <summary>
        /// T8 network intercharacter occured.
        /// </summary>
        #endregion
        public const string err_m_20008 = "T8 network intercharacter occurred.";

        #region Comments
        /// <summary>
        /// Inter-character timeout. Detects an interruption between characters.
        /// </summary>
        #endregion
        public const string err_m_21001 = "Inter-character timeout. Detects an interruption between characters.";

        #region Comments
        /// <summary>
        /// Reply timeout. Detects a lack of protocol response.
        /// </summary>
        #endregion
        public const string err_m_21002 = "Reply timeout. Detects a lack of protocol response.";
        
        #region Comments
        /// <summary>
        /// Reply timeout. Specifies maximum amount of time an entity expecting a reply message will wait for that reply.
        /// </summary>
        #endregion
        public const string err_m_21003 = "Reply timeout. Specifies maximum amount of time an entity expecting a reply message will wait for that reply.";

        #region Comments
        /// <summary>
        /// Inter-block timeout. Detects an interruption in a multi-block message.
        /// </summary>
        #endregion
        public const string err_m_21004 = "Inter-block timeout. Detects an interruption in a multi-block message.";

        #region Comments
        /// <summary>
        /// Connection Separation Timeout. Specifies the amount of time which must elapse between successive attempts to connect to a given remote entity.
        /// </summary>
        #endregion
        public const string err_m_21005 = "Connection Separation Timeout. Specifies the amount of time which must elapse between successive attempts to connect to a given remote entity.";

        #region Comments
        /// <summary>
        /// Control Transaction Timeout. Specifies the time which a control transaction may remain open before it is considered a communications failure.
        /// </summary>
        #endregion
        public const string err_m_21006 = "Control Transaction Timeout. Specifies the time which a control transaction may remain open before it is considered a communications failure.";

        #region Comments
        /// <summary>
        /// Time which a TCP/IP connection can remain in NOT SELECTED state (i.e., no HSMS activity) before it is considered a communications failure.
        /// </summary>
        #endregion
        public const string err_m_21007 = "Time which a TCP/IP connection can remain in NOT SELECTED state (i.e., no HSMS activity) before it is considered a communications failure.";

        #region Comments
        /// <summary>
        /// Maximum time between successive bytes of a single HSMS message which may expire before it is considered a communications failure.
        /// </summary>
        #endregion
        public const string err_m_21008 = "Maximum time between successive bytes of a single HSMS message which may expire before it is considered a communications failure.";

        #endregion

        //------------------------------------------------------------------------------------------------------------------------       

    }   // Class end
}   // Namespace end
