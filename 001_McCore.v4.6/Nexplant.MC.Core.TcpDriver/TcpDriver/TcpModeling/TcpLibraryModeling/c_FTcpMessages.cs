/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpMessages.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.10.29
--  Description     : FAMate Core FaTcpDriver TCP Messages Class 
--  History         : Created by jungyoul.moon at 2013.10.29
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public class FTcpMessages : FBaseObject<FTcpMessages>, FIObject
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpMessages(
            FTcpDriver fTcpDriver
            )
            : base(fTcpDriver.fTcdCore, FTcpDriverCommon.createXmlNodeTMS(fTcpDriver.fTcdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FTcpMessages(
            FTcdCore fTcdCore,
            FXmlNode fXmlNode
            )
            : base(fTcdCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpMessages(
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
                    return FObjectType.TcpMessages;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.TcpMessages;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTMS.A_UniqueId, FXmlTagTMS.D_UniqueId);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagTMS.A_Locked, FXmlTagTMS.D_Locked));
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
                    return this.fXmlNode.get_attrVal(FXmlTagTMS.A_Name, FXmlTagTMS.D_Name);
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

                    this.fXmlNode.set_attrVal(FXmlTagTMS.A_Name, FXmlTagTMS.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTMS.A_Description, FXmlTagTMS.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagTMS.A_Description, FXmlTagTMS.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagTMS.A_FontColor, FXmlTagTMS.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagTMS.A_FontColor, FXmlTagTMS.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagTMS.A_FontBold, FXmlTagTMS.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagTMS.A_FontBold, FXmlTagTMS.D_FontBold, FBoolean.fromBool(value), true);
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

        public FDirection fDirection
        {
            get
            {
                try
                {
                    return FEnumConverter.toDirection(this.fXmlNode.get_attrVal(FXmlTagTMS.A_Direction, FXmlTagTMS.D_Direction));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDirection.Both;
            }

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagTMS.A_Direction, FXmlTagTMS.D_Direction, FEnumConverter.fromDirection(value), true);

                    // --

                    changeDirection();
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

        public string directionSymbol
        {
            get
            {
                string symbol = string.Empty;
                try
                {
                    if (fDirection == FDirection.Both)
                    {
                        symbol = FConstants.DirectionSymbolBoth;
                    }
                    else if (fDirection == FDirection.Equipment)
                    {
                        symbol = FConstants.DirectionSymbolEquipment;
                    }
                    else if (fDirection == FDirection.Host)
                    {
                        symbol = FConstants.DirectionSymbolHost;
                    }

                    return symbol;
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

        public string command
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTMS.A_Command, FXmlTagTMS.D_Command);
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
                string old_c = string.Empty;

                try
                {
                    old_c = this.command;
                    if (old_c == value)
                    {
                        return;
                    }

                    // --

                    FTcpDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagTMS.A_Command, FXmlTagTMS.D_Command, value, true);
                    changeCv(old_c);
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagTMS.A_Version, FXmlTagTMS.D_Version));
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
                    if (this.version == value)
                    {
                        return;
                    }

                    // --

                    if (value < 0 || value > 65535)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Version"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagTMS.A_Version, FXmlTagTMS.D_Version, value.ToString(), true);
                    changeCv(this.command);
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

        private void changeCv(
            string oldCommand
           )
        {
            string new_c = string.Empty;
            int new_v = 0;
            bool isModelingObject = false;
            FXmlNodeList fXmlNodeListTmg = null;

            try
            {
                new_c = this.command;
                new_v = this.version;
                isModelingObject = this.isModelingObject;

                // --

                // ***
                // TCP Messages의 Command, Version이 변경될 경우, Child TCP Message의 Command, Version를 변경한다.
                // ***
                fXmlNodeListTmg = this.fXmlNode.selectNodes(FXmlTagTMG.E_TcpMessage);
                foreach (FXmlNode fXmlNodeTmg in fXmlNodeListTmg)
                {
                    // ***
                    // Command가 변경되었을 경우, TCP Messages의 Command와 동일한 TCP Message의 Command를 변경한다.
                    // ***
                    if (fXmlNodeTmg.get_attrVal(FXmlTagTMG.A_Command, FXmlTagTMG.D_Command) == oldCommand)
                    {
                        fXmlNodeTmg.set_attrVal(FXmlTagTMG.A_Command, FXmlTagTMG.D_Command, new_c);
                    }
                    fXmlNodeTmg.set_attrVal(FXmlTagTMG.A_Version, FXmlTagTMG.D_Version, new_v.ToString());

                    // --

                    if (isModelingObject)
                    {
                        this.fTcdCore.fEventPusher.pushEvent(
                            new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fTcpDriver, this, FTcpDriverCommon.createObject(this.fTcdCore, fXmlNodeTmg))
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeListTmg != null)
                {
                    fXmlNodeListTmg.Dispose();
                    fXmlNodeListTmg = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag1
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTMS.A_UserTag1, FXmlTagTMS.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagTMS.A_UserTag1, FXmlTagTMS.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTMS.A_UserTag2, FXmlTagTMS.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagTMS.A_UserTag2, FXmlTagTMS.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTMS.A_UserTag3, FXmlTagTMS.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagTMS.A_UserTag3, FXmlTagTMS.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTMS.A_UserTag4, FXmlTagTMS.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagTMS.A_UserTag4, FXmlTagTMS.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTMS.A_UserTag5, FXmlTagTMS.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagTMS.A_UserTag5, FXmlTagTMS.D_UserTag5, value, true);
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

        public string defUserTagNaem1
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

        public FTcpMessageList fParent
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

                    return new FTcpMessageList(this.fTcdCore, this.fXmlNode.fParentNode);
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

        public FTcpMessages fPreviousSibling
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

                    return new FTcpMessages(this.fTcdCore, this.fXmlNode.fPreviousSibling);
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

        public FTcpMessages fNextSibling
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

                    return new FTcpMessages(this.fTcdCore, this.fXmlNode.fNextSibling);
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

        public FTcpMessageCollection fChildTcpMessageCollection
        {
            get
            {
                try
                {
                    return new FTcpMessageCollection(this.fTcdCore, this.fXmlNode.selectNodes(FXmlTagTMG.E_TcpMessage));
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
                    return this.fXmlNode.containsNode(FXmlTagTMG.E_TcpMessage);
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

        public bool hasChildPrimaryTcpMessage
        {
            get
            {
                try
                {
                    return this.fXmlNode.containsNode(
                        FXmlTagTMG.E_TcpMessage + "[@" + FXmlTagTMG.A_TcpMessageType + "!='" + FEnumConverter.fromTcpMessageType(FTcpMessageType.Reply) + "']"
                        );
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

        public bool hasChildSecondaryTcpMessage
        {
            get
            {
                try
                {
                    return this.fXmlNode.containsNode(
                        FXmlTagTMG.E_TcpMessage + "[@" + FXmlTagTMG.A_TcpMessageType + "='" + FEnumConverter.fromTcpMessageType(FTcpMessageType.Reply) + "']"
                        );
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

        //-----------------------------------------------------------------------------------------------------------------------

        public bool canAppendChildPrimaryTcpMessage
        {
            get
            {
                try
                {
                    return !this.hasChildPrimaryTcpMessage;
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

        //-----------------------------------------------------------------------------------------------------------------------

        public bool canAppendChildSecondaryTcpMessage
        {
            get
            {
                try
                {
                    return !this.hasChildSecondaryTcpMessage;
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

        //-----------------------------------------------------------------------------------------------------------------------

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
                    if (this.fXmlNode.fParentNode == null || this.fXmlNode.fPreviousSibling == null)
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

        public bool canMoveDown
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null || this.fXmlNode.fNextSibling == null)
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
                    if (fXmlNode.fParentNode == null || this.locked)
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
                    if (
                        this.fXmlNode.fParentNode == null ||
                        !FClipboard.containsData(FCbObjectFormat.TcpMessages)
                        )
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

        public bool canPasteChild
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

        public bool canPastePrimaryTcpMessage
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.TcpMessage))
                    {
                        return false;
                    }
                    return this.canAppendChildPrimaryTcpMessage;
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

        public bool canPasteSecondaryTcpMessage
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.TcpMessage))
                    {
                        return false;
                    }
                    return this.canAppendChildSecondaryTcpMessage;
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
                    info += (" Desc=[" + this.description + "]");
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

        public FTcpMessage appendChildPrimaryTcpMessage(
            FTcpMessage fNewChild
            )
        {
            try
            {
                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                // --
                if (this.hasChildPrimaryTcpMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0003, "Primary TCP Message"));
                }

                // --

                fNewChild.version = this.version;
                // --
                if (this.fDirection == FDirection.Host)
                {
                    fNewChild.fontColor = Color.DarkGreen;
                }
                else if (this.fDirection == FDirection.Equipment)
                {
                    fNewChild.fontColor = Color.DarkRed;
                }
                else
                {
                    fNewChild.fontColor = Color.Black;
                }

                // --

                if (fNewChild.fTcpMessageType == FTcpMessageType.Reply)
                {
                    fNewChild.fTcpMessageType = FTcpMessageType.Unsolicited;
                }

                // --

                if (this.fXmlNode.fFirstChild == null)
                {
                    fNewChild.replace(this.fTcdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));
                }
                else
                {
                    fNewChild.replace(this.fTcdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, this.fXmlNode.fFirstChild));
                }

                //--

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

        public FTcpMessage appendChildSecondaryTcpMessage(
            FTcpMessage fNewChild
            )
        {
            try
            {
                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                // --
                if (this.hasChildSecondaryTcpMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0003, "Secondary TCP Message"));
                }

                // --

                fNewChild.version = this.version;
                fNewChild.fTcpMessageType = FTcpMessageType.Reply;
                // --
                if (this.fDirection == FDirection.Host)
                {
                    fNewChild.fontColor = Color.DarkRed;
                }
                else if (this.fDirection == FDirection.Equipment)
                {
                    fNewChild.fontColor = Color.DarkGreen;
                }
                else
                {
                    fNewChild.fontColor = Color.Black;
                }

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

        public FTcpMessage removeChildTcpMessage(
            FTcpMessage fChild
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

        public void removeChildTcpMessage(
            FTcpMessage[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FTcpMessage fTmg in fChilds)
                {
                    FTcpDriverCommon.validateRemoveChildObject(this.fXmlNode, fTmg.fXmlNode);
                }

                // --

                foreach (FTcpMessage fTmg in fChilds)
                {
                    fTmg.remove();
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

        public void removeAllChildTcpMessage(
            )
        {
            FTcpMessageCollection fTmgCollection = null;

            try
            {
                fTmgCollection = this.fChildTcpMessageCollection;
                if (fTmgCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FTcpMessage fTmg in fTmgCollection)
                {
                    if (fTmg.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FTcpMessage fTmg in fTmgCollection)
                {
                    fTmg.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fTmgCollection != null)
                {
                    fTmgCollection.Dispose();
                    fTmgCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void moveUp(
            )
        {
            bool isModelingObject = false;

            try
            {
                FTcpDriverCommon.validateMoveUpObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fTcdCore, this.fXmlNode.moveUp());

                // --

                if (isModelingObject)
                {
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveUpCompleted, this.fTcpDriver, fParent, this)
                        );
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

        public void moveDown(
            )
        {
            bool isModelingObject = false;

            try
            {
                FTcpDriverCommon.validateMoveDownObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fTcdCore, this.fXmlNode.moveDown());

                // --

                if (isModelingObject)
                {
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveDownCompleted, this.fTcpDriver, fParent, this)
                        );
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

        public void moveTo(
           FTcpMessages fRefObject
           )
        {
            FTcpMessageList fOldParent = null;

            try
            {
                FTcpDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

                // --

                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "Modeling Object"));
                }

                if (!fRefObject.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Reference Object", "Modeling Object"));
                }

                if (!this.equalsModelingFile(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Modeling File", "same"));
                }

                if (!this.fAncestorTcpLibrary.Equals(fRefObject.fAncestorTcpLibrary))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "TCP Library", "same"));
                }

                // --       

                fOldParent = this.fParent;

                // --

                this.replace(this.fTcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fTcdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                // ***
                // Tcp Messages가 Lock되어 있을 경우 Old 부모는 Unlock하고 New 부모는 Lock 한다.
                // ***
                if (!this.fParent.Equals(fOldParent) && this.locked)
                {
                    fOldParent.unlockObject();
                    this.fParent.lockObject();
                }

                // --

                this.fTcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fTcpDriver, this, fRefObject)
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOldParent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void moveTo(
            FTcpMessageList fRefObject
            )
        {
            FTcpMessageList fOldParent = null;

            try
            {
                FTcpDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

                // --

                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "Modeling Object"));
                }

                if (!fRefObject.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Reference Object", "Modeling Object"));
                }

                if (!this.equalsModelingFile(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Modeling File", "same"));
                }

                if (!this.fAncestorTcpLibrary.Equals(fRefObject.fAncestorTcpLibrary))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "TCP Library", "same"));
                }

                if (fRefObject.fChildTcpMessagesCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildTcpMessagesCollection[fRefObject.fChildTcpMessagesCollection.count - 1]))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "same localtion"));
                    }
                }    

                // --

                fOldParent = this.fParent;

                // --                

                this.replace(this.fTcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fTcdCore, fRefObject.fXmlNode.appendChild(this.fXmlNode));

                // --

                if (!fRefObject.Equals(fOldParent) && this.locked)
                {
                    fOldParent.unlockObject();
                    fRefObject.lockObject();
                }

                // --

                this.fTcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fTcpDriver, this, fRefObject)
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOldParent = null;
            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        private void changeDirection(
            )
        {
            bool isModelingObject = false;

            try
            {
                isModelingObject = this.isModelingObject;

                // --

                // ***
                // TCP Messages의 Direction이 변경될 경우,
                // Child TCP Message의 Color를 변경한다.
                // ***
                if (this.fDirection == FDirection.Host)
                {
                    this.fontColor = Color.DarkGreen;

                    foreach (FTcpMessage msg in this.fChildTcpMessageCollection)
                    {
                        if (msg.isPrimary)
                        {
                            msg.fontColor = Color.DarkGreen;
                        }
                        else if (msg.isSecondary)
                        {
                            msg.fontColor = Color.DarkRed;
                        }
                        // --

                        if (isModelingObject)
                        {
                            this.fTcdCore.fEventPusher.pushEvent(
                                new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fTcpDriver, this, FTcpDriverCommon.createObject(this.fTcdCore, msg.fXmlNode))
                                );
                        }
                    }
                }
                else if (this.fDirection == FDirection.Equipment)
                {
                    this.fontColor = Color.DarkRed;

                    foreach (FTcpMessage msg in this.fChildTcpMessageCollection)
                    {
                        if (msg.isPrimary)
                        {
                            msg.fontColor = Color.DarkRed;
                        }
                        else if (msg.isSecondary)
                        {
                            msg.fontColor = Color.DarkGreen;
                        }
                        // --

                        if (isModelingObject)
                        {
                            this.fTcdCore.fEventPusher.pushEvent(
                                new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fTcpDriver, this, FTcpDriverCommon.createObject(this.fTcdCore, msg.fXmlNode))
                                );
                        }
                    }
                }
                else if (this.fDirection == FDirection.Both)
                {
                    this.fontColor = Color.Black;

                    foreach (FTcpMessage msg in this.fChildTcpMessageCollection)
                    {
                        msg.fontColor = Color.Black;

                        // --

                        if (isModelingObject)
                        {
                            this.fTcdCore.fEventPusher.pushEvent(
                                new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fTcpDriver, this, FTcpDriverCommon.createObject(this.fTcdCore, msg.fXmlNode))
                                );
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
                // TCP Messages에 대한 Lock 처리
                // ***
                this.fXmlNode.set_attrVal(FXmlTagTMS.A_Locked, FXmlTagTMS.D_Locked, FBoolean.True, true);

                // --

                // ***
                // Parent인 TCP Message List에 대한 Lock 처리
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
                // Lock되어 있는 자식 TCP Message가 존재하는지 검사
                // ***
                xpath = FXmlTagTMG.E_TcpMessage + "[@" + FXmlTagTMG.A_Locked + "='" + FBoolean.True + "']";
                // --
                if (this.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagTMS.A_Locked, FXmlTagTMS.D_Locked, FBoolean.False, true);

                // --

                // ***
                // Parent인 TCP Message List에 대한 Unlock 처리
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

        public void copy(
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.clone(true);

                // --

                resetFlowNode(fXmlNode);
                this.copyObject(FCbObjectFormat.TcpMessages, fXmlNode);
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
                this.copyObject(FCbObjectFormat.TcpMessages, this.fXmlNode);
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

        public FTcpMessages pasteSibling(
            )
        {
            FTcpMessages fTcpMessages = null;

            try
            {
                FTcpDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.TcpMessages);

                // --

                fTcpMessages = (FTcpMessages)this.pasteObject(FCbObjectFormat.TcpMessages);
                return this.fParent.insertAfterChildTcpMessages(fTcpMessages, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTcpMessages = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpMessage pastePrimaryTcpMessage(
            )
        {
            FTcpMessage fTmg = null;

            try
            {
                FTcpDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.TcpMessage);
                // --
                if (this.hasChildPrimaryTcpMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "PLC Messages", "Primary PLC Message"));
                }

                // -- 

                fTmg = (FTcpMessage)this.pasteObject(FCbObjectFormat.TcpMessage);
                return this.appendChildPrimaryTcpMessage(fTmg);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTmg = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpMessage pasteSecondaryTcpMessage(
            )
        {
            FTcpMessage fTmg = null;

            try
            {

                FTcpDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.TcpMessage);
                // --
                if (this.hasChildSecondaryTcpMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "TCP Messages", "Secondary TCP Message"));
                }

                // --

                fTmg = (FTcpMessage)this.pasteObject(FCbObjectFormat.TcpMessage);
                return this.appendChildSecondaryTcpMessage(fTmg);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTmg = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpMessageCollection selectTcpMessageByName(
            string name
            )
        {
            const string xpath = FXmlTagTMG.E_TcpMessage + "[@" + FXmlTagTMG.A_Name + "='{0}']";

            try
            {
                return new FTcpMessageCollection(
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

        public FTcpMessage selectSingleTcpMessageByName(
            string name
            )
        {
            const string xpath = FXmlTagTMG.E_TcpMessage + "[@" + FXmlTagTMG.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
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

        //------------------------------------------------------------------------------------------------------------------------

        public string convertToXml(
            FProtocol fProtocol
            )
        {
            try
            {
                return FMessageConverter.convertTmsToXml(fProtocol, this.fXmlNode);
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
                foreach (FTcpMessage fOmg in this.fChildTcpMessageCollection)
                {
                    fOmg.resetRelation();
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
                foreach (FXmlNode fXmlNodeOmg in fXmlNode.selectNodes(FXmlTagTMG.E_TcpMessage))
                {
                    FTcpMessage.resetFlowNode(fXmlNodeOmg);
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
 
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
