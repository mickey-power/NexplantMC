/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FConstant.cs
--  Creator         : spike.lee
--  Create Date     : 2013.07.10
--  Description     : FAMate Core FaOpcDriver Constant Definition Class 
--  History         : Created by spike.lee at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaOpcDriver
{
    internal static class FConstants
    {

        //------------------------------------------------------------------------------------------------------------------------       

        // ***
        // {0} = Namespace 
        // {1} = Channel (Channel + Device)
        // {2} = Tag Name
        // ***
        // public const string ItemNameFormat = "ns={0};s={1}{2}";

        // ***
        // {0} = Channel (Channel + Device)
        // {1} = Tag Name
        // ***
        public const string DaItemNameFormat = "{0}{1}";

        // ***
        // {0} = Namespace 
        // {1} = Channel (Channel + Device)        
        // ***
        //public const string BrowerItemNameFormat = "ns={0};s={1}";

        // ***
        // {0} = Channel (Channel + Device)
        // ***
        public const string BrowerDaItemNameFormat = "{0}";

        // ***
        // System Error Tag Name (PLC State Check Tag)
        // ***
        /// <summary>
        /// _System._Error
        /// </summary>
        public const string SystemErrorTagName = "_System._Error";
        public const string HeartbeatTagName = "HEARTBEAT";

        // --

        public const char ValueFormulaSeparator = (char)0x1E;       // Record Separator
        public const char ValueFormulaUnitSeparator = (char)0x1F;   // Unit Separator
        // --
        public const char PreconditionValueSeparator = (char)0x1E;  // Record Separator
        // --        
        public const char DataCovnersionExpressionSeparator = (char)0x0E;   // Shift out
        public const char DataConversionSeparator = (char)0x1C;             // File Separator
        public const char DataConversionUnitSeparator = (char)0x1D;         // Group Separator        

        // --
        
        // ***
        // Host Driver Namespace
        // ***
        public const string HostDriverName = "Nexplant.MC.HostDriver.OPC.FHostDriver";        
        // --
        public const string DirectionSymbolBoth = "H<->E";
        public const string DirectionSymbolEquipment = "H<-E";
        public const string DirectionSymbolHost = "H->E";

        // --

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
        /// The {0} is not defined.
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
        /// The {0} is received.
        /// </summary>
        #endregion
        public const string err_m_0036 = "The {0} is received.";

        #region Comments
        /// <summary>
        /// The {0} timeout occurred.
        /// </summary>
        #endregion
        public const string err_m_0037 = "The {0} timeout occurred.";

        #region Comments
        /// <summary>
        /// The {0} was failed to {1}.
        /// </summary>
        #endregion
        public const string err_m_0038 = "The {0} was failed to {1}.";

        #region Comments
        /// <summary>
        /// The {0} occurred.
        /// </summary>
        #endregion
        public const string err_m_0039 = "The {0} has occurred. ({1})";
        
        #region Comments
        /// <summary>
        /// The Host driver is not supported. Host Driver Property will be reset.
        /// </summary>
        #endregion
        public const string err_m_0040 = "The Host Driver is not supported. The Property of the Host Driver will be reset.";
        
        #region Comments
        /// <summary>
        /// Failed to create an instance of the Host Driver.
        /// </summary>
        #endregion
        public const string err_m_0041 = "Failed to create an instance of the {0}.";

        #region Comments
        /// <summary>
        /// The {0} cannot change the {1} for {2}.
        /// </summary>
        #endregion
        public const string err_m_0042 = "The {0} cannot change the {1} for {2}.";

        #region Comments
        /// <summary>
        /// An error has occurred partly Subscribe to registration operation. ({0})
        /// </summary>
        #endregion
        public const string err_m_0043 = "The {0} an error has occurred partly {1} Subscribe to registration operation. ({2})";

        #region Comments
        /// <summary>
        /// Subscribe faied for item. Session:{0}, Channel:{1}, ItemName:{2}
        /// </summary>
        public const string err_m_0044 = "Subscribe failed for item. Session: {0}, ItemName: {1}";
        #endregion 

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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------       

    }   // Class end
}   // Namespace end
