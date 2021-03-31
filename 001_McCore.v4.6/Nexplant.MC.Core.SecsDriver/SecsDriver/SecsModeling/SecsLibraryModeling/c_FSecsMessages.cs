/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsMessages.cs
--  Creator         : spike.lee
--  Create Date     : 2011.02.10
--  Description     : FAMate Core FaSecsDriver SECS Messages Class 
--  History         : Created by spike.lee at 2011.02.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FSecsMessages : FBaseObject<FSecsMessages>, FIObject
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecsMessages(
            FSecsDriver fSecsDriver
            )
            : base(fSecsDriver.fScdCore, FSecsDriverCommon.createXmlNodeSMS(fSecsDriver.fScdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FSecsMessages(
            FScdCore fScdCore,
            FXmlNode fXmlNode
            )
            : base(fScdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsMessages(
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
                    return FObjectType.SecsMessages;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.SecsDriver;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSMS.A_UniqueId, FXmlTagSMS.D_UniqueId);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSMS.A_Locked, FXmlTagSMS.D_Locked));
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMS.A_Name, FXmlTagSMS.D_Name);
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
                    FSecsDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSMS.A_Name, FXmlTagSMS.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMS.A_Description, FXmlTagSMS.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagSMS.A_Description, FXmlTagSMS.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagSMS.A_FontColor, FXmlTagSMS.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagSMS.A_FontColor, FXmlTagSMS.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSMS.A_FontBold, FXmlTagSMS.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagSMS.A_FontBold, FXmlTagSMS.D_FontBold, FBoolean.fromBool(value), true);
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

        public int stream
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSMS.A_Stream, FXmlTagSMS.D_Stream));
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
                    if (this.stream == value)
                    {
                        return;
                    }

                    // --

                    if (value < 0 || value > 127)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Stream"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSMS.A_Stream, FXmlTagSMS.D_Stream, value.ToString(), true);
                    changeSfv();
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

        public int function
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSMS.A_Function, FXmlTagSMS.D_Function));
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
                    if (this.function == value)
                    {
                        return;
                    }

                    // --

                    if (value < 0 || value > 255)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Function"));
                    }                    

                    if (value == 0)
                    {
                        if (this.hasChildSecondarySecsMessage)
                        {
                            FDebug.throwFException(
                                string.Format(FConstants.err_m_0009, "SECS Messages which the Function is 0", "Secondary SECS Message")
                                );
                        }
                    }
                    else if (value % 2 == 0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "Function of SECS Messages", "Even Number"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSMS.A_Function, FXmlTagSMS.D_Function, value.ToString(), true);
                    changeSfv();
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSMS.A_Version, FXmlTagSMS.D_Version));
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

                    this.fXmlNode.set_attrVal(FXmlTagSMS.A_Version, FXmlTagSMS.D_Version, value.ToString(), true);

                    // --

                    changeSfv();
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
                    return FEnumConverter.toDirection(this.fXmlNode.get_attrVal(FXmlTagSMS.A_Direction, FXmlTagSMS.D_Direction));
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
                    this.fXmlNode.set_attrVal(FXmlTagSMS.A_Direction, FXmlTagSMS.D_Direction, FEnumConverter.fromDirection(value), true);

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

        public string userTag1
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSMS.A_UserTag1, FXmlTagSMS.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagSMS.A_UserTag1, FXmlTagSMS.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMS.A_UserTag2, FXmlTagSMS.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagSMS.A_UserTag2, FXmlTagSMS.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMS.A_UserTag3, FXmlTagSMS.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagSMS.A_UserTag3, FXmlTagSMS.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMS.A_UserTag4, FXmlTagSMS.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagSMS.A_UserTag4, FXmlTagSMS.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMS.A_UserTag5, FXmlTagSMS.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagSMS.A_UserTag5, FXmlTagSMS.D_UserTag5, value, true);
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
                catch (Exception Exception)
                {
                    FDebug.throwException(Exception);
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

        public FSecsMessageList fParent
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

                    return new FSecsMessageList(this.fScdCore, this.fXmlNode.fParentNode);
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

        public FSecsMessages fPreviousSibling
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

                    return new FSecsMessages(this.fScdCore, this.fXmlNode.fPreviousSibling);
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

        public FSecsMessages fNextSibling
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

                    return new FSecsMessages(this.fScdCore, this.fXmlNode.fNextSibling);
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

        public FSecsMessageCollection fChildSecsMessageCollection
        {
            get
            {
                try
                {
                    return new FSecsMessageCollection(this.fScdCore, this.fXmlNode.selectNodes(FXmlTagSMG.E_SecsMessage));
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
                    return new FObjectCollection(this.fScdCore, this.fXmlNode.selectNodes("NULL"));
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
                    return new FObjectCollection(this.fScdCore, this.fXmlNode.selectNodes("NULL"));
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
                    return this.fXmlNode.containsNode(FXmlTagSMG.E_SecsMessage);
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

        public bool hasChildPrimarySecsMessage
        {
            get
            {
                try
                {
                    return this.fXmlNode.containsNode(
                        FXmlTagSMG.E_SecsMessage + "[@" + FXmlTagSMG.A_Function + "='" + this.function.ToString() + "']"
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

        public bool hasChildSecondarySecsMessage
        {
            get
            {
                try
                {
                    return this.fXmlNode.containsNode(
                        FXmlTagSMG.E_SecsMessage + "[@" + FXmlTagSMG.A_Function + "='" + (this.function + 1).ToString() + "']"
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
                    if (this.function == 0)
                    {
                        if (this.fXmlNode.selectNodes(FXmlTagSMG.E_SecsMessage).count >= 1)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (this.fXmlNode.selectNodes(FXmlTagSMG.E_SecsMessage).count >= 2)
                        {
                            return false;
                        }
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

        public bool canAppendChildPrimarySecsMessage
        {
            get
            {
                try
                {
                    return !this.hasChildPrimarySecsMessage;
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

        public bool canAppendChildSecondarySecsMessage
        {
            get
            {
                try
                {
                    // ***
                    // Function이 0인 SECS Messsages는 Primary SECS Message만을
                    // 추가할 수 있다.
                    // ***
                    if (this.function == 0 || this.hasChildSecondarySecsMessage)
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

        public FSecsLibrary fAncestorSecsLibrary
        {
            get
            {
                try
                {
                    return this.getAncestorSecsLibrary();
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
                    if (
                        this.fXmlNode.fParentNode == null ||
                        !FClipboard.containsData(FCbObjectFormat.SecsMessages)
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

        public bool canPastePrimarySecsMessage
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.SecsMessage))
                    {
                        return false;
                    }
                    return this.canAppendChildPrimarySecsMessage;
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

        public bool canPasteSecondarySecsMessage
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.SecsMessage))
                    {
                        return false;
                    }
                    return this.canAppendChildSecondarySecsMessage;
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
            string s = string.Empty;
            string f = string.Empty;
            string v = string.Empty;

            try
            {
                if (option == FStringOption.Detail)
                {
                    s = this.stream.ToString();
                    f = this.function.ToString();
                    v = this.version.ToString();
                    info = "[S" + s + " F" + f + " V" + v + "] ";
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

        public FSecsMessage appendChildPrimarySecsMessage(
            FSecsMessage fNewChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                // --
                if (this.hasChildPrimarySecsMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0003, "Primary SECS Message"));
                }

                // --

                fNewChild.stream = this.stream;
                fNewChild.function = this.function;
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

                if (this.fXmlNode.fFirstChild == null)
                {
                    fNewChild.replace(this.fScdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));
                }
                else
                {
                    fNewChild.replace(this.fScdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, this.fXmlNode.fFirstChild));
                }
                
                //--                
                
                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fSecsDriver, this, fNewChild)
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

        public FSecsMessage appendChildSecondarySecsMessage(
            FSecsMessage fNewChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                // --
                if (this.hasChildSecondarySecsMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0003, "Secondary SECS Message"));
                }
                // --
                if (this.function == 0)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0007, "SECS Messages which the Function is 0", "Secondary SECS Message"));
                }

                // --

                fNewChild.stream = this.stream;
                fNewChild.function = this.function + 1;
                fNewChild.version = this.version;
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

                fNewChild.replace(this.fScdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));                
                // --
                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fSecsDriver, this, fNewChild)
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
                FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);

                // --

                resetRelation();

                // --

                fParent = this.fParent;
                isModelingObject = this.isModelingObject;
                this.replace(this.fScdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));

                // --

                if (isModelingObject)
                {
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fSecsDriver, fParent, this)
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

        public FSecsMessage removeChildSecsMessage(
            FSecsMessage fChild
            )
        {
            try
            {
                FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode, fChild.fXmlNode);

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

        public void removeChildSecsMessage(
            FSecsMessage[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FSecsMessage fSmg in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode, fSmg.fXmlNode);
                }

                // --

                foreach (FSecsMessage fSmg in fChilds)
                {
                    fSmg.remove();
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

        public void removeAllChildSecsMessage(
            )
        {
            FSecsMessageCollection fSmgCollection = null;

            try
            {
                fSmgCollection = this.fChildSecsMessageCollection;
                if (fSmgCollection.count == 0)
                {
                    return;
                }                

                // --

                foreach (FSecsMessage fSmg in fSmgCollection)
                {
                    if (fSmg.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FSecsMessage fSmg in fSmgCollection)
                {
                    fSmg.remove();
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fSmgCollection != null)
                {
                    fSmgCollection.Dispose();
                    fSmgCollection = null;
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
                FSecsDriverCommon.validateMoveUpObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fScdCore, this.fXmlNode.moveUp());

                // --

                if (isModelingObject)
                {
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveUpCompleted, this.fSecsDriver, fParent, this)
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
                FSecsDriverCommon.validateMoveDownObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fScdCore, this.fXmlNode.moveDown());

                // --

                if (isModelingObject)
                {
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveDownCompleted, this.fSecsDriver, fParent, this)
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
           FSecsMessages fRefObject
           )
        {
            FSecsMessageList fOldParent = null;

            try
            {
                FSecsDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

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

                if (!this.fAncestorSecsLibrary.Equals(fRefObject.fAncestorSecsLibrary))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "SECS Library", "same"));
                }

                // --       

                fOldParent = this.fParent;

                // --

                this.replace(this.fScdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fScdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                // ***
                // SECS Messages가 Lock되어 있을 경우 Old 부모는 Unlock하고 New 부모는 Lock 한다.
                // ***
                if (!this.fParent.Equals(fOldParent) && this.locked)
                {
                    fOldParent.unlockObject();
                    this.fParent.lockObject();
                }

                // --

                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fSecsDriver, this, fRefObject)
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
            FSecsMessageList fRefObject
            )
        {
            FSecsMessageList fOldParent = null;

            try
            {
                FSecsDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

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

                if (!this.fAncestorSecsLibrary.Equals(fRefObject.fAncestorSecsLibrary))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "SECS Library", "same"));
                }

                if (fRefObject.fChildSecsMessagesCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildSecsMessagesCollection[fRefObject.fChildSecsMessagesCollection.count - 1]))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "same localtion"));
                    }
                }   

                // --

                fOldParent = this.fParent;

                // --                

                this.replace(this.fScdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fScdCore, fRefObject.fXmlNode.appendChild(this.fXmlNode));

                // --

                if (!fRefObject.Equals(fOldParent) && this.locked)
                {
                    fOldParent.unlockObject();
                    fRefObject.lockObject();
                }

                // --

                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fSecsDriver, this, fRefObject)
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

        private void changeSfv(
            )
        {
            int new_s = 0;
            int new_f = 0;
            int new_v = 0;
            int old_f = 0;
            bool isModelingObject = false;
            FXmlNodeList fXmlNodeListSmg = null;

            try
            {
                new_s = this.stream;
                new_f = this.function;
                new_v = this.version;
                isModelingObject = this.isModelingObject;

                // --

                // ***
                // SECS Messages의 Stream, Function, Version이 변경될 경우,
                // Child SECS Message의 Stream, Function, Version를 변경한다.
                // ***
                fXmlNodeListSmg = this.fXmlNode.selectNodes(FXmlTagSMG.E_SecsMessage);
                foreach (FXmlNode fXmlNodeSmg in fXmlNodeListSmg)
                {
                    old_f = int.Parse(fXmlNodeSmg.get_attrVal(FXmlTagSMG.A_Function, FXmlTagSMG.D_Function));
                    // --
                    fXmlNodeSmg.set_attrVal(FXmlTagSMG.A_Stream, FXmlTagSMG.D_Stream, new_s.ToString());
                    if (old_f == 0 || old_f % 2 == 1)
                    {
                        fXmlNodeSmg.set_attrVal(FXmlTagSMG.A_Function, FXmlTagSMG.D_Function, new_f.ToString());
                    }
                    else
                    {
                        fXmlNodeSmg.set_attrVal(FXmlTagSMG.A_Function, FXmlTagSMG.D_Function, (new_f + 1).ToString());
                    }
                    fXmlNodeSmg.set_attrVal(FXmlTagSMG.A_Version, FXmlTagSMG.D_Version, new_v.ToString());

                    // --
                    
                    if (isModelingObject)
                    {
                        this.fScdCore.fEventPusher.pushEvent(
                            new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fSecsDriver, this, FSecsDriverCommon.createObject(this.fScdCore, fXmlNodeSmg))
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
                if (fXmlNodeListSmg != null)
                {
                    fXmlNodeListSmg.Dispose();
                    fXmlNodeListSmg = null;
                }
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
                // SECS Messages의 Direction이 변경될 경우,
                // Child SECS Message의 Color를 변경한다.
                // ***
                if (this.fDirection == FDirection.Host)
                {
                    this.fontColor = Color.DarkGreen;

                    foreach (FSecsMessage msg in this.fChildSecsMessageCollection)
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
                            this.fScdCore.fEventPusher.pushEvent(
                                new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fSecsDriver, this, FSecsDriverCommon.createObject(this.fScdCore, msg.fXmlNode))
                                );
                        }
                    }
                }
                else if (this.fDirection == FDirection.Equipment)
                {
                    this.fontColor = Color.DarkRed;

                    foreach (FSecsMessage msg in this.fChildSecsMessageCollection)
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
                            this.fScdCore.fEventPusher.pushEvent(
                                new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fSecsDriver, this, FSecsDriverCommon.createObject(this.fScdCore, msg.fXmlNode))
                                );
                        }
                    }
                }
                else if (this.fDirection == FDirection.Both)
                {
                    this.fontColor = Color.Black;

                    foreach (FSecsMessage msg in this.fChildSecsMessageCollection)
                    {
                        msg.fontColor = Color.Black;

                        // --

                        if (isModelingObject)
                        {
                            this.fScdCore.fEventPusher.pushEvent(
                                new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fSecsDriver, this, FSecsDriverCommon.createObject(this.fScdCore, msg.fXmlNode))
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

        public string convertToSml(
            )
        {
            try
            {
                return FMessageConverter.convertSmsToSml(this.fXmlNode);
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
                // SECS Messages에 대한 Lock 처리
                // ***
                this.fXmlNode.set_attrVal(FXmlTagSMS.A_Locked, FXmlTagSMS.D_Locked, FBoolean.True, true);

                // --

                // ***
                // Parent인 SECS Message List에 대한 Lock 처리
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
                // Lock이 설정되어 있는 자식 SECS Message가 존재할 경우 Unlock 작업을 취소한다.
                // ***
                xpath = FXmlTagSMG.E_SecsMessage + "[@" + FXmlTagSMG.A_Locked + "='" + FBoolean.True + "']";
                if (this.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagSMS.A_Locked, FXmlTagSMS.D_Locked, FBoolean.False, true);

                // --

                // ***
                // Parent인 SECS Message List에 대한 Unlock 처리
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
                FSecsDriverCommon.validateCutObject(this.fXmlNode);

                // --

                this.remove();

                // --

                resetFlowNode(this.fXmlNode);
                this.copyObject(FCbObjectFormat.SecsMessages, this.fXmlNode);
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
                this.copyObject(FCbObjectFormat.SecsMessages, fXmlNode);
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

        public FSecsMessages pasteSibling(
            )
        {
            FSecsMessages fSecsMessages = null;

            try
            {
                FSecsDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.SecsMessages);
                
                // --

                fSecsMessages = (FSecsMessages)this.pasteObject(FCbObjectFormat.SecsMessages);
                return this.fParent.insertAfterChildSecsMessages(fSecsMessages, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsMessages = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsMessage pastePrimarySecsMessage(
            )
        {
            FSecsMessage fSecsMessage = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.SecsMessage);
                // --
                if (this.hasChildPrimarySecsMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "SECS Messages","Primary SECS Message"));
                }

                // -- 

                fSecsMessage = (FSecsMessage)this.pasteObject(FCbObjectFormat.SecsMessage);
                return this.appendChildPrimarySecsMessage(fSecsMessage);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsMessage = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsMessage pasteSecondarySecsMessage(
            )
        {
            FSecsMessage fSecsMessage = null;

            try
            {

                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.SecsMessage);
                // --
                if (this.hasChildSecondarySecsMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "SECS Messages", "Secondary SECS Message"));
                }

                // --

                fSecsMessage = (FSecsMessage)this.pasteObject(FCbObjectFormat.SecsMessage);             
                return this.appendChildSecondarySecsMessage(fSecsMessage);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsMessage = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsMessageCollection selectSecsMessageByName(
            string name
            )
        {
            const string xpath = FXmlTagSMG.E_SecsMessage + "[@" + FXmlTagSMG.A_Name + "='{0}']";

            try
            {
                return new FSecsMessageCollection(
                    this.fScdCore,
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

        public FSecsMessage selectSingleSecsMessageByName(
            string name
            )
        {
            const string xpath = FXmlTagSMG.E_SecsMessage + "[@" + FXmlTagSMG.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsMessage(this.fScdCore, fXmlNode);
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

        public FSecsMessageCollection selectSecsMessageByHeader(
            string stream,
            string function,
            string version
            )
        {
            const string xpath = FXmlTagSMG.E_SecsMessage + "[@" + FXmlTagSMG.A_Stream + "='{0}' and @" + FXmlTagSMG.A_Function + "='{1}' and @" + FXmlTagSMG.A_Version + "='{2}']";

            try
            {
                return new FSecsMessageCollection(
                    this.fScdCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, stream, function, version))
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

        public FSecsMessage selectSingleSecsMessageByHeader(
            string stream,
            string function,
            string version
            )
        {
            const string xpath = FXmlTagSMG.E_SecsMessage + "[@" + FXmlTagSMG.A_Stream + "='{0}' and @" + FXmlTagSMG.A_Function + "='{1}' and @" + FXmlTagSMG.A_Version + "='{2}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, stream, function, version));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsMessage(this.fScdCore, fXmlNode);
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

        internal void resetRelation(
            )
        {
            try
            {
                foreach (FSecsMessage fSmg in this.fChildSecsMessageCollection)
                {
                    fSmg.resetRelation();
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
                foreach (FXmlNode fXmlNodeSmg in fXmlNode.selectNodes(FXmlTagSMG.E_SecsMessage))
                {
                    FSecsMessage.resetFlowNode(fXmlNodeSmg);
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
