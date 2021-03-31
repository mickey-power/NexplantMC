/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpMessage.cs
--  Creator         : spike.lee
--  Create Date     : 2013.10.29
--  Description     : FAMate Core FaTcpDriver TCP Message Class 
--  History         : Created by heonsik at 2013.10.29
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public class FTcpMessage : FBaseObject<FTcpMessage>, FIObject, FIMessage
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpMessage(
            FTcpDriver fTcpDriver
            )
            : base(fTcpDriver.fTcdCore, FTcpDriverCommon.createXmlNodeTMG(fTcpDriver.fTcdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FTcpMessage(
            FTcdCore fTcdCore,
            FXmlNode fXmlNode
            )
            : base(fTcdCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpMessage(
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

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FObjectType fObjectType
        {
            get
            {
                try
                {
                    return FObjectType.TcpMessage;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.TcpMessage;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FMessageType fMessageType
        {
            get
            {
                try
                {
                    return FMessageType.TcpMessage;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FMessageType.TcpMessage;
            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTMG.A_UniqueId, FXmlTagTMG.D_UniqueId);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public UInt64 uniqueId
        {
            get
            {
                try
                {
                    return UInt64.Parse(this.uniqueIdToString);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool locked
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagTMG.A_Locked, FXmlTagTMG.D_Locked));
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string name
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTMG.A_Name, FXmlTagTMG.D_Name);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }

            set
            {
                try
                {
                    FTcpDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagTMG.A_Name, FXmlTagTMG.D_Name, value, true);
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

        //------------------------------------------------------------------------------------------------------------------------

        public string description
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTMG.A_Description, FXmlTagTMG.D_Description);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagTMG.A_Description, FXmlTagTMG.D_Description, value, true);
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

        //------------------------------------------------------------------------------------------------------------------------

        public Color fontColor
        {
            get
            {
                try
                {
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagTMG.A_FontColor, FXmlTagTMG.D_FontColor));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return Color.Black;
            }

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagTMG.A_FontColor, FXmlTagTMG.D_FontColor, value.Name, true);
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool fontBold
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagTMG.A_FontBold, FXmlTagTMG.D_FontBold));
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagTMG.A_FontBold, FXmlTagTMG.D_FontBold, FBoolean.fromBool(value), true);
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

        //------------------------------------------------------------------------------------------------------------------------

        public string command
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTMG.A_Command, FXmlTagTMG.D_Command);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagTMG.A_Command, FXmlTagTMG.D_Command, value, true);
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

        //------------------------------------------------------------------------------------------------------------------------

        public int version
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagTMG.A_Version, FXmlTagTMG.D_Version));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }

            set
            {
                try
                {
                    // ***
                    // Parent가 존재할 경우 Version은 Parent에서만 변경할 수 있도록 처리
                    // ***
                    if (this.fXmlNode.fParentNode != null)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0008, "TCP Message which has the Parent", "Version"));
                    }

                    if (value < 0 || value > 65535)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Version"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagTMG.A_Version, FXmlTagTMG.D_Version, value.ToString(), true);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpMessageType fTcpMessageType
        {
            get
            {
                try
                {
                    return FEnumConverter.toTcpMessageType(this.fXmlNode.get_attrVal(FXmlTagTMG.A_TcpMessageType, FXmlTagTMG.D_TcpMessageType));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FTcpMessageType.Command;
            }

            set
            {
                try
                {
                    if (this.fTcpMessageType == value)
                    {
                        return;
                    }

                    // --

                    // ***
                    // Parent가 존재할 경우, TCP Message Type이 Command나 Unsolicited일 경우 상호 변경할 수 있으나 Reply로 변경할 
                    // 수 없고, Reply일 경우 TCP Message Type를 변경할 수 없다.
                    // ***
                    if (this.fXmlNode.fParentNode != null)
                    {
                        if (this.fTcpMessageType == FTcpMessageType.Command || this.fTcpMessageType == FTcpMessageType.Unsolicited)
                        {
                            if (value == FTcpMessageType.Reply)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0006, "TCP Message Type of the Primary TCP Message", value.ToString()));
                            }
                        }
                        else
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0006, "TCP Message Type of the Secondary TCP Message", value.ToString()));
                        }
                    }

                    // --

                    if (value != FTcpMessageType.Reply)
                    {
                        this.fXmlNode.set_attrVal(FXmlTagTMG.A_AutoReply, FXmlTagTMG.D_AutoReply, FBoolean.False);
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagTMG.A_TcpMessageType, FXmlTagTMG.D_TcpMessageType, FEnumConverter.fromTcpMessageType(value), true);
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool autoReply
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagTMG.A_AutoReply, FXmlTagTMG.D_AutoReply));
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

            set
            {
                try
                {
                    // ***
                    // TCP Message Type이 Reply일 경우에만 Auto Reply를 설정할 수 있다.
                    // ***
                    if (this.fTcpMessageType != FTcpMessageType.Reply)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "Primary TCP Message", "Auto-Reply"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagTMG.A_AutoReply, FXmlTagTMG.D_AutoReply, FBoolean.fromBool(value), true);
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool logEnabled
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagTMG.A_LogEnabled, FXmlTagTMG.D_LogEnabled));
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
            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagTMG.A_LogEnabled, FXmlTagTMG.D_LogEnabled, FBoolean.fromBool(value), true);
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

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2017.07.04 by spike.lee
        // Log Level Add
        // ***
        public FLogLevel logLevel
        {
            get
            {
                try
                {
                    return FEnumConverter.toLogLevel(this.fXmlNode.get_attrVal(FXmlTagTMG.A_LogLevel, FXmlTagTMG.D_LogLevel));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FLogLevel.Level1;
            }

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagTMG.A_LogLevel, FXmlTagTMG.D_LogLevel, FEnumConverter.fromLogLevel(value), true);
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool isPrimary
        {
            get
            {
                try
                {
                    return this.fTcpMessageType == FTcpMessageType.Reply ? false : true;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool isSecondary
        {
            get
            {
                try
                {
                    return !this.isPrimary;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag1
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTMG.A_UserTag1, FXmlTagTMG.D_UserTag1);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagTMG.A_UserTag1, FXmlTagTMG.D_UserTag1, value, true);
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

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag2
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTMG.A_UserTag2, FXmlTagTMG.D_UserTag2);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagTMG.A_UserTag2, FXmlTagTMG.D_UserTag2, value, true);
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

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag3
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTMG.A_UserTag3, FXmlTagTMG.D_UserTag3);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagTMG.A_UserTag3, FXmlTagTMG.D_UserTag3, value, true);
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

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag4
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTMG.A_UserTag4, FXmlTagTMG.D_UserTag4);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagTMG.A_UserTag4, FXmlTagTMG.D_UserTag4, value, true);
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

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag5
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTMG.A_UserTag5, FXmlTagTMG.D_UserTag5);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagTMG.A_UserTag5, FXmlTagTMG.D_UserTag5, value, true);
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

        //------------------------------------------------------------------------------------------------------------------------

        public string defUserTagName1
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(1);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string defUserTagName2
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(2);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string defUserTagName3
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(3);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string defUserTagName4
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(4);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string defUserTagName5
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(5);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpMessages fParent
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null)
                    {
                        return null;
                    }

                    // --

                    return new FTcpMessages(this.fTcdCore, this.fXmlNode.fParentNode);
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

        public FTcpMessage fPreviousSibling
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fPreviousSibling == null)
                    {
                        return null;
                    }

                    // --

                    return new FTcpMessage(this.fTcdCore, this.fXmlNode.fPreviousSibling);
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

        public FTcpMessage fNextSibling
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fNextSibling == null)
                    {
                        return null;
                    }

                    // --

                    return new FTcpMessage(this.fTcdCore, this.fXmlNode.fNextSibling);
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

        public FTcpItemCollection fChildTcpItemCollection
        {
            get
            {
                try
                {
                    return new FTcpItemCollection(this.fTcdCore, this.fXmlNode.selectNodes(FXmlTagTIT.E_TcpItem));
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

        public FObjectNameCollection fObjectNameCollection
        {
            get
            {
                try
                {
                    return this.getObjectNameCollection();
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

        public FObjectCollection fReferenceObjectCollection
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath =
                        "../../../../../../" + FXmlTagEQM.E_EquipmentModeling +
                        "/" + FXmlTagEQP.E_Equipment +
                        "/" + FXmlTagSNG.E_ScenarioGroup +
                        "/" + FXmlTagSNR.E_Scenario +
                        "/" + FXmlTagTTR.E_TcpTrigger +
                        "/" + FXmlTagTCN.E_TcpCondition + "[@" + FXmlTagTCN.A_TcpMessageId + "='" + this.uniqueIdToString + "']" +
                        " | " +
                        "../../../../../../" + FXmlTagEQM.E_EquipmentModeling +
                        "/" + FXmlTagEQP.E_Equipment +
                        "/" + FXmlTagSNG.E_ScenarioGroup +
                        "/" + FXmlTagSNR.E_Scenario +
                        "/" + FXmlTagTTN.E_TcpTransmitter +
                        "/" + FXmlTagTTF.E_TcpTransfer + "[@" + FXmlTagTTF.A_TcpMessageId + "='" + this.uniqueIdToString + "']";
                    // --
                    return new FObjectCollection(this.fTcdCore, this.fXmlNode.selectNodes(xpath));
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

        public FObjectCollection fInclusionObjectCollection
        {
            get
            {
                try
                {
                    return new FObjectCollection(this.fTcdCore, this.fXmlNode.selectNodes("NULL"));
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

        public bool hasChild
        {
            get
            {
                try
                {
                    return this.fXmlNode.containsNode(FXmlTagTIT.E_TcpItem);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool hasFixedChild
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_Pattern + "='" + FEnumConverter.fromPattern(FPattern.Fixed) + "']";
                    return this.fXmlNode.containsNode(xpath);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool hasVariableChild
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_Pattern + "='" + FEnumConverter.fromPattern(FPattern.Variable) + "']";
                    return this.fXmlNode.containsNode(xpath);
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
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public bool canAppendChild
        {
            get
            {
                try
                {
                    return true;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canInsertBefore
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null)
                    {
                        return false;
                    }
                    return true;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canInsertAfter
        {
            get
            {
                try
                {
                    return this.canInsertBefore;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canRemove
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null || this.locked)
                    {
                        return false;
                    }
                    return true;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canMoveUp
        {
            get
            {
                try
                {   
                    return false;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canMoveDown
        {
            get
            {
                try
                {   
                    return false;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpLibrary fAncestorTcpLibrary
        {
            get
            {
                try
                {
                    return this.getAncestorTcpLibrary();
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

        public bool canCut
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null || this.locked)
                    {
                        return false;
                    }
                    return true;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canCopy
        {
            get
            {
                try
                {
                    return true;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canPasteSibling
        {
            get
            {
                try
                {
                    return false;
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
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public bool canPasteChild
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.TcpItem))
                    {
                        return false;
                    }
                    return true;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public string ToString(
            FStringOption option
            )
        {
            string info = string.Empty;
            string c = string.Empty;
            string v = string.Empty;

            try
            {
                if (option == FStringOption.Detail)
                {
                    c = this.command;
                    v = this.version.ToString();
                    info = "[" + c + " V" + v + "] ";
                }

                // --

                info += this.name;

                // --

                if (this.description != string.Empty)
                {
                    info += " Desc=[" + this.description + "]";
                }

                // --

                return info;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return string.Empty;
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public FTcpItem appendChildTcpItem(
            FTcpItem fNewChild
            )
        {
            try
            {
                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));
                // --                
                if (this.isModelingObject)
                {
                    FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fTcpDriver, this, fNewChild)
                        );
                }

                // --

                return fNewChild;
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

        public FTcpItem appendChildTcpItem(
            FTcpDriver fTcpDriver,
            string name,
            FFormat fFormat,
            string stringValue
            )
        {
            try
            {
                return appendChildTcpItem(new FTcpItem(fTcpDriver, name, fFormat, stringValue));
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

        public FTcpItem insertBeforeChildTcpItem(
            FTcpItem fNewChild,
            FTcpItem fRefChild
            )
        {
            try
            {
                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));

                // --                

                if (
                    (fNewChild.fPreviousSibling != null && fNewChild.fPreviousSibling.fPattern == FPattern.Variable) &&
                    (fNewChild.fNextSibling != null && fNewChild.fNextSibling.fPattern == FPattern.Variable)
                    )
                {
                    fNewChild.fXmlNode.set_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Variable));
                }

                // --

                if (this.isModelingObject)
                {
                    FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this.fTcpDriver, this, fNewChild)
                        );
                }

                // --

                return fNewChild;
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

        public FTcpItem insertAfterChildTcpItem(
            FTcpItem fNewChild,
            FTcpItem fRefChild
            )
        {
            try
            {
                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));

                // --                

                if (
                    (fNewChild.fPreviousSibling != null && fNewChild.fPreviousSibling.fPattern == FPattern.Variable) &&
                    (fNewChild.fNextSibling != null && fNewChild.fNextSibling.fPattern == FPattern.Variable)
                    )
                {
                    fNewChild.fXmlNode.set_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Variable));
                }

                // --

                if (this.isModelingObject)
                {
                    FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this.fTcpDriver, this, fNewChild)
                        );
                }

                // --

                return fNewChild;
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

        public void remove(
            )
        {
            FIObject fParent = null;
            bool isModelingObject = false;

            try
            {
                FTcpDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);

                // --

                resetRelation();

                // --

                fParent = this.fParent;
                isModelingObject = this.isModelingObject;
                this.replace(this.fTcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));

                // -- 

                if (isModelingObject)
                {
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fTcpDriver, fParent, this)
                        );
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpItem removeChildTcpItem(
            FTcpItem fChild
            )
        {
            try
            {
                FTcpDriverCommon.validateRemoveChildObject(this.fXmlNode, fChild.fXmlNode);

                // --

                fChild.remove();

                // --

                return fChild;
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

        public void removeChildTcpItem(
            FTcpItem[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FTcpItem fTit in fChilds)
                {
                    FTcpDriverCommon.validateRemoveChildObject(this.fXmlNode, fTit.fXmlNode);
                }

                // --

                foreach (FTcpItem fTit in fChilds)
                {
                    fTit.remove();
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

        public void removeAllChildTcpItem(
            )
        {
            FTcpItemCollection fTitCollection = null;

            try
            {
                fTitCollection = this.fChildTcpItemCollection;
                if (fTitCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FTcpItem fTit in fTitCollection)
                {
                    if (fTit.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // -- 

                foreach (FTcpItem fTit in fTitCollection)
                {
                    fTit.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fTitCollection != null)
                {
                    fTitCollection.Dispose();
                    fTitCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void lockObject(
            )
        {
            try
            {
                if (this.locked)
                {
                    return;
                }

                // --

                // ***
                // TCP Message에 대한 Lock 처리
                // ***
                this.fXmlNode.set_attrVal(FXmlTagTMG.A_Locked, FXmlTagTMG.D_Locked, FBoolean.True, true);

                // --

                // ***
                // Parent인 TCP Messages에 대한 Lock 처리
                // ***
                this.fParent.lockObject();
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

        internal void unlockObject(
            )
        {
            string xpath = string.Empty;

            try
            {
                if (!this.locked)
                {
                    return;
                }

                // --

                // ***
                // TCP Message가 TCP Condition이나 TCP Transfer에 사용되어 있을 경우 Unlock 작업을 취소한다.
                // ***
                xpath =
                    FXmlTagEQM.E_EquipmentModeling +
                    "/" + FXmlTagEQP.E_Equipment +
                    "/" + FXmlTagSNG.E_ScenarioGroup +
                    "/" + FXmlTagSNR.E_Scenario +
                    "/" + FXmlTagTTR.E_TcpTrigger +
                    "/" + FXmlTagTCN.E_TcpCondition + "[@" + FXmlTagTCN.A_TcpMessageId + "='" + this.uniqueIdToString + "']" +
                    " | " +
                    FXmlTagEQM.E_EquipmentModeling +
                    "/" + FXmlTagEQP.E_Equipment +
                    "/" + FXmlTagSNG.E_ScenarioGroup +
                    "/" + FXmlTagSNR.E_Scenario +
                    "/" + FXmlTagTTN.E_TcpTransmitter +
                    "/" + FXmlTagTTF.E_TcpTransfer + "[@" + FXmlTagTTF.A_TcpMessageId + "='" + this.uniqueIdToString + "']";
                // --
                if (this.fTcpDriver.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // --

                // ***
                // TCP Message에 대한 Unlock 처리
                // ***
                this.fXmlNode.set_attrVal(FXmlTagTMG.A_Locked, FXmlTagTMG.D_Locked, FBoolean.False, true);

                // --

                // ***
                // Parent인 TCP Messages에 대한 Unlock 처리
                // ***
                this.fParent.unlockObject();
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

        public void cut(
            )
        {
            try
            {
                FTcpDriverCommon.validateCutObject(this.fXmlNode);

                // --

                this.remove();

                // --

                resetFlowNode(this.fXmlNode);
                this.copyObject(FCbObjectFormat.TcpMessage, this.fXmlNode);
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

        public void copy(
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.clone(true);

                // --           

                resetFlowNode(fXmlNode);
                this.copyObject(FCbObjectFormat.TcpMessage, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpItem pasteChild(
            )
        {
            FTcpItem fTcpItem = null;

            try
            {
                FTcpDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.TcpItem);

                // --

                fTcpItem = (FTcpItem)this.pasteObject(FCbObjectFormat.TcpItem);

                // --

                this.appendChildTcpItem(fTcpItem);
                return fTcpItem;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTcpItem = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpMessageTransfer createTransfer(
            )
        {
            FXmlNode fXmlNodeTmt = null;

            try
            {
                fXmlNodeTmt = this.fXmlNode.clone(true);

                // --

                // ***
                // 2016.12.22 by spike.lee
                // Message Transfer 생성 시, 모델링 객체의 Lock 제거하도록 수정
                // ***
                FTcpDriverCommon.resetLocked(fXmlNodeTmt);
                
                // --
                
                fXmlNodeTmt.set_attrVal(FXmlTagTMT.A_MessageType, FXmlTagTMT.D_MessageType, FXmlTagTMT.M_MessageTransfer);
                return new FTcpMessageTransfer(this.fTcdCore, fXmlNodeTmt);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeTmt = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpMessageTransfer createTransfer(
            UInt32 tid
            )
        {
            FXmlNode fXmlNodeTmt = null;

            try
            {
                fXmlNodeTmt = this.fXmlNode.clone(true);

                // --

                // ***
                // 2016.12.22 by spike.lee
                // Message Transfer 생성 시, 모델링 객체의 Lock 제거하도록 수정
                // ***
                FTcpDriverCommon.resetLocked(fXmlNodeTmt);
                
                // --
                
                fXmlNodeTmt.set_attrVal(FXmlTagHMT.A_MessageType, FXmlTagHMT.D_MessageType, FXmlTagHMT.M_MessageTransfer);
                return new FTcpMessageTransfer(this.fTcdCore, fXmlNodeTmt, tid);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeTmt = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpItemCollection selectTcpItemByName(
            string name
            )
        {
            const string xpath = FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_Name + "='{0}']";

            try
            {
                return new FTcpItemCollection(
                    this.fTcdCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, name))
                    );
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

        public FTcpItem selectSingleTcpItemByName(
            string name
            )
        {
            const string xpath = FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FTcpItem(this.fTcdCore, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpItemCollection selectAllTcpItemByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_Name + "='{0}']";

            try
            {
                return new FTcpItemCollection(
                    this.fTcdCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, name))
                    );
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

        public FTcpItem selectSingleAllTcpItemByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FTcpItem(this.fTcdCore, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpItemCollection selectTcpItemByReservedWord(
            string reservedWord
            )
        {
            const string xpath = FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_ReservedWord + "='{0}']";

            try
            {
                return new FTcpItemCollection(
                    this.fTcdCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, reservedWord))
                    );
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

        public FTcpItem selectSingleTcpItemByReservedWord(
            string reservedWord
            )
        {
            const string xpath = FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_ReservedWord + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, reservedWord));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FTcpItem(this.fTcdCore, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpItemCollection selectAllTcpItemByReservedWord(
            string reservedWord
            )
        {
            const string xpath = ".//" + FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_ReservedWord + "='{0}']";

            try
            {
                return new FTcpItemCollection(
                    this.fTcdCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, reservedWord))
                    );
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

        public FTcpItem selectSingleAllTcpItemByReservedWord(
            string reservedWord
            )
        {
            const string xpath = ".//" + FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_ReservedWord + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, reservedWord));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FTcpItem(this.fTcdCore, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpItemCollection selectTcpItemByExtraction(
            )
        {
            const string xpath = FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_Extraction + "='{0}']";

            try
            {
                return new FTcpItemCollection(
                    this.fTcdCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, FBoolean.True))
                    );
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

        public FTcpItem selectSingleTcpItemByExtraction(
            )
        {
            const string xpath = FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_Extraction + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, FBoolean.True));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FTcpItem(this.fTcdCore, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpItemCollection selectAllTcpItemByExtraction(
            )
        {
            const string xpath = ".//" + FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_Extraction + "='{0}']";

            try
            {
                return new FTcpItemCollection(
                    this.fTcdCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, FBoolean.True))
                    );
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

        public FTcpItem selectAllSingleTcpItemByExtraction(
            )
        {
            const string xpath = ".//" + FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_Extraction + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, FBoolean.True));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FTcpItem(this.fTcdCore, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpItem selectSingleAllTcpItemByIndex(
            params object[] args
            )
        {
            FXmlNode fXmlNode = null;
            int index = 0;

            try
            {
                if (args == null || args.Length == 0)
                {
                    return null;
                }

                // --

                fXmlNode = this.fXmlNode;
                // --
                foreach (object obj in args)
                {
                    index = (int)obj;
                    // --
                    if (index >= fXmlNode.fChildNodes.count)
                    {
                        return null;
                    }
                    // --
                    fXmlNode = fXmlNode.fChildNodes[index];
                }
                // --
                return new FTcpItem(this.fTcdCore, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string convertToXml(
            FProtocol fProtocol
            )
        {
            try
            {
                return FMessageConverter.convertTmgToXml(fProtocol, this.fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void resetRelation(
            )
        {
            try
            {
                foreach (FTcpItem fTit in this.fChildTcpItemCollection)
                {
                    fTit.resetRelation();
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

        internal static void resetFlowNode(
            FXmlNode fXmlNode
            )
        {
            try
            {
                foreach (FXmlNode fXmlNodeTit in fXmlNode.selectNodes(FXmlTagTIT.E_TcpItem))
                {
                    FTcpItem.resetFlowNode(fXmlNodeTit);
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

        // ***
        // 2017.05.01 by spike.lee
        // 객체 Clone 기능 추가
        // ***
        public FTcpMessage clone(
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.clone(true);

                // --

                resetFlowNode(fXmlNode);
                FTcpDriverCommon.resetLocked(fXmlNode);
                return new FTcpMessage(this.fTcdCore, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
