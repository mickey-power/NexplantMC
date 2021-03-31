/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHostMessages.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.16
--  Description     : FAMate Core FaOpcDriver Host Messages Class 
--  History         : Created by Jeff.Kim at 2013.07.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public class FHostMessages : FBaseObject<FHostMessages>, FIObject
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHostMessages(
            FOpcDriver fOpcDriver
            )
            : base(fOpcDriver.fOcdCore, FOpcDriverCommon.createXmlNodeHMS(fOpcDriver.fOcdCore.fXmlDoc))
        {
 
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FHostMessages(
            FOcdCore fOcdCore,
            FXmlNode fXmlNode
            )
            : base(fOcdCore, fXmlNode)
        {
 
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHostMessages(
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
                    return FObjectType.HostMessages;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                { 
                
                }
                return FObjectType.HostMessages;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHMS.A_UniqueId, FXmlTagHMS.D_UniqueId);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHMS.A_Locked, FXmlTagHMS.D_Locked));
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
                    return this.fXmlNode.get_attrVal(FXmlTagHMS.A_Name, FXmlTagHMS.D_Name);
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
                    FOpcDriverCommon.validateName(value, true);

                    this.fXmlNode.set_attrVal(FXmlTagHMS.A_Name, FXmlTagHMS.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHMS.A_Description, FXmlTagHMS.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagHMS.A_Description, FXmlTagHMS.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagHMS.A_FontColor, FXmlTagHMS.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagHMS.A_FontColor, FXmlTagHMS.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHMS.A_FontBold, FXmlTagHMS.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagHMS.A_FontBold, FXmlTagHMS.D_FontBold, FBoolean.fromBool(value), true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHMS.A_Command, FXmlTagHMS.D_Command);
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

                    FOpcDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagHMS.A_Command, FXmlTagHMS.D_Command, value, true);
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagHMS.A_Version, FXmlTagHMS.D_Version));
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

                    this.fXmlNode.set_attrVal(FXmlTagHMS.A_Version, FXmlTagHMS.D_Version, value.ToString(), true);
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

        public FDirection fDirection
        {
            get
            {
                try
                {
                    return FEnumConverter.toDirection(this.fXmlNode.get_attrVal(FXmlTagHMS.A_Direction, FXmlTagHMS.D_Direction));
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
                    this.fXmlNode.set_attrVal(FXmlTagHMS.A_Direction, FXmlTagHMS.D_Direction, FEnumConverter.fromDirection(value), true);

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
                    return this.fXmlNode.get_attrVal(FXmlTagHMS.A_UserTag1, FXmlTagHMS.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagHMS.A_UserTag1, FXmlTagHMS.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHMS.A_UserTag2, FXmlTagHMS.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagHMS.A_UserTag2, FXmlTagHMS.D_UserTag2, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }//------------------------------------------------------------------------------------------------------------------------

        public string userTag3
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHMS.A_UserTag3, FXmlTagHMS.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagHMS.A_UserTag3, FXmlTagHMS.D_UserTag3, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }//------------------------------------------------------------------------------------------------------------------------

        public string userTag4
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHMS.A_UserTag4, FXmlTagHMS.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagHMS.A_UserTag4, FXmlTagHMS.D_UserTag4, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }//------------------------------------------------------------------------------------------------------------------------

        public string userTag5
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHMS.A_UserTag5, FXmlTagHMS.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagHMS.A_UserTag5, FXmlTagHMS.D_UserTag5, value, true);
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

        public FHostMessageList fParent
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

                    return new FHostMessageList(this.fOcdCore, this.fXmlNode.fParentNode);
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

        public FHostMessages fPreviousSibling
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

                    return new FHostMessages(this.fOcdCore, this.fXmlNode.fPreviousSibling);
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

        public FHostMessages fNextSibling
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

                    return new FHostMessages(this.fOcdCore, this.fXmlNode.fNextSibling);
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

        public FHostMessageCollection fChildHostMessageCollection
        {
            get
            {
                try
                {
                    return new FHostMessageCollection(this.fOcdCore, this.fXmlNode.selectNodes(FXmlTagHMG.E_HostMessage));
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
                    return new FObjectCollection(this.fOcdCore, this.fXmlNode.selectNodes("NULL"));
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
                    return new FObjectCollection(this.fOcdCore, this.fXmlNode.selectNodes("NULL"));
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
                    return this.fXmlNode.containsNode(FXmlTagHMG.E_HostMessage);
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

        public bool hasHashTagChild
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

        public bool hasChildPrimaryHostMessage
        {
            get
            {
                try
                {
                    return this.fXmlNode.containsNode(
                        FXmlTagHMG.E_HostMessage + "[@" + FXmlTagHMG.A_HostMessageType + "!='" + FEnumConverter.fromHostMessageType(FHostMessageType.Reply) + "']"
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

        public bool hasChildSecondaryHostMessage
        {
            get
            {
                try
                {
                    return this.fXmlNode.containsNode(
                        FXmlTagHMG.E_HostMessage + "[@" + FXmlTagHMG.A_HostMessageType + "='" + FEnumConverter.fromHostMessageType(FHostMessageType.Reply) + "']"
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
                    //if (this.fXmlNode.selectNodes(FXmlTagSMG.E_OpcMessage).count >= 2)
                    //{
                    //    return false;
                    //}
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

        public bool canAppendChildPrimaryHostMessage
        {
            get
            {
                try
                {
                    return !this.hasChildPrimaryHostMessage;
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

        public bool canAppendChildSecondaryHostMessage
        {
            get
            {
                try
                {
                   return !this.hasChildSecondaryHostMessage;
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

        public FHostLibrary fAncestorHostLibrary
        {
            get
            {
                try
                {
                    return this.getAncestorHostLibrary();
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
                        !FClipboard.containsData(FCbObjectFormat.HostMessages)
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

        public bool canPastePrimaryHostMessage
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.HostMessage))
                    {
                        return false;
                    }         
                    return this.canAppendChildPrimaryHostMessage;
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

        public bool canPasteSecondaryHostMessage
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.HostMessage))
                    {
                        return false;
                    }
                    return this.canAppendChildSecondaryHostMessage;
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

        internal void resetRelation(
            )
        {
            try
            {
                foreach (FHostMessage fHmg in this.fChildHostMessageCollection)
                {
                    fHmg.resetRelation();
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
                foreach (FXmlNode fXmlNodeHmg in fXmlNode.selectNodes(FXmlTagHMG.E_HostMessage))
                {
                    FHostMessage.resetFlowNode(fXmlNodeHmg);
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

        public FHostMessage appendChildPrimaryHostMessage(
            FHostMessage fNewChild
            )
        {
            try
            {
                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                // --
                if (this.hasChildPrimaryHostMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0003, "Primary Host Message"));
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

                if (fNewChild.fHostMessageType == FHostMessageType.Reply)
                {
                    fNewChild.fHostMessageType = FHostMessageType.Unsolicited;
                }

                // --

                if (this.fXmlNode.fFirstChild == null)
                {
                    fNewChild.replace(this.fOcdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));
                }
                else
                {
                    fNewChild.replace(this.fOcdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, this.fXmlNode.fFirstChild));
                }

                //--

                if (this.isModelingObject)
                {
                    FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fOpcDriver, this, fNewChild)
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

        public FHostMessage appendChildSecondaryHostMessage(
            FHostMessage fNewChild
            )
        {
            try
            {
                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                // --
                if (this.hasChildSecondaryHostMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0003, "Secondary Host Message"));
                }
                
                // --
                
                fNewChild.version = this.version;
                fNewChild.fHostMessageType = FHostMessageType.Reply;
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

                fNewChild.replace(this.fOcdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));
                // --
                if (this.isModelingObject)
                {
                    FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fOpcDriver, this, fNewChild)
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
                FOpcDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);

                // --

                resetRelation();

                // --

                fParent = this.fParent;
                isModelingObject = this.isModelingObject;
                this.replace(this.fOcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));

                // --

                if (isModelingObject)
                {
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fOpcDriver, fParent, this)
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
        // Add by Jeff.Kim 2015.11.07
        // Relation Reset 없이 삭제 하기 위함
        // 특정 Host Message에 대해서 여러 모델링 파일을 한번에 수정하기 위함
        public void forceRemove(
            )
        {
            try
            {
                // --

                this.replace(this.fOcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));

                // --
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

        public FHostMessage removeChildHostMessage(
            FHostMessage fChild
            )
        {
            try
            {
                FOpcDriverCommon.validateRemoveChildObject(this.fXmlNode, fChild.fXmlNode);

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

        public void removeChildHostMessage(
            FHostMessage[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FHostMessage fHmg in fChilds)
                {
                    FOpcDriverCommon.validateRemoveChildObject(this.fXmlNode, fHmg.fXmlNode);
                }

                // --

                foreach (FHostMessage fHmg in fChilds)
                {
                    fHmg.remove();
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

        public void removeAllChildHostMessage(
            )
        {
            FHostMessageCollection fHmgCollection = null;

            try
            {
                fHmgCollection = this.fChildHostMessageCollection;
                if (fHmgCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FHostMessage fHmg in fHmgCollection)
                {
                    if (fHmg.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FHostMessage fHmg in fHmgCollection)
                {
                    fHmg.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fHmgCollection != null)
                {
                    fHmgCollection.Dispose();
                    fHmgCollection = null;
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
                FOpcDriverCommon.validateMoveUpObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fOcdCore, this.fXmlNode.moveUp());

                // --

                if (isModelingObject)
                {
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveUpCompleted, this.fOpcDriver, fParent, this)
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
                FOpcDriverCommon.validateMoveDownObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fOcdCore, this.fXmlNode.moveDown());

                // --

                if (isModelingObject)
                {
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveDownCompleted, this.fOpcDriver, fParent, this)
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
           FHostMessages fRefObject
           )
        {
            FHostMessageList fOldParent = null;

            try
            {
                FOpcDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

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

                if (!this.fAncestorHostLibrary.Equals(fRefObject.fAncestorHostLibrary))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Host Library", "same"));
                }

                // --       

                fOldParent = this.fParent;

                // --

                this.replace(this.fOcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fOcdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                if (!this.fParent.Equals(fOldParent) && this.locked)
                {
                    fOldParent.unlockObject();
                    this.fParent.lockObject();
                }

                // --

                this.fOcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fOpcDriver, this, fRefObject)
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
            FHostMessageList fRefObject
            )
        {
            FHostMessageList fOldParent = null;

            try
            {
                FOpcDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

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

                if (!this.fAncestorHostLibrary.Equals(fRefObject.fAncestorHostLibrary))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Host Library", "same"));
                }

                if (fRefObject.fChildHostMessagesCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildHostMessagesCollection[fRefObject.fChildHostMessagesCollection.count - 1]))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "same localtion"));
                    }
                }    

                // --

                fOldParent = this.fParent;

                // --                

                this.replace(this.fOcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fOcdCore, fRefObject.fXmlNode.appendChild(this.fXmlNode));

                // --

                if (!fRefObject.Equals(fOldParent) && this.locked)
                {
                    fOldParent.unlockObject();
                    fRefObject.lockObject();
                }

                // --

                this.fOcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fOpcDriver, this, fRefObject)
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

        private void changeCv(
            string oldCommand
           )           
        {
            string new_c = string.Empty;
            int new_v = 0;            
            bool isModelingObject = false;
            FXmlNodeList fXmlNodeListHmg = null;

            try
            {
                new_c = this.command;                
                new_v = this.version;
                isModelingObject = this.isModelingObject;

                // --

                // ***
                // Host Messages의 Command, Version이 변경될 경우, Child Host Message의 Command, Version를 변경한다.
                // ***
                fXmlNodeListHmg = this.fXmlNode.selectNodes(FXmlTagHMG.E_HostMessage);
                foreach (FXmlNode fXmlNodeHmg in fXmlNodeListHmg)
                {
                    // ***
                    // Command가 변경되었을 경우, Host Messages의 Command와 동일한 Host Message의 Command를 변경한다.
                    // ***
                    if (fXmlNodeHmg.get_attrVal(FXmlTagHMG.A_Command, FXmlTagHMG.D_Command) == oldCommand)
                    {
                        fXmlNodeHmg.set_attrVal(FXmlTagHMG.A_Command, FXmlTagHMG.D_Command, new_c);
                    }                    
                    fXmlNodeHmg.set_attrVal(FXmlTagHMG.A_Version, FXmlTagHMG.D_Version, new_v.ToString());

                    // --

                    if (isModelingObject)
                    {
                        this.fOcdCore.fEventPusher.pushEvent(
                            new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fOpcDriver, this, FOpcDriverCommon.createObject(this.fOcdCore, fXmlNodeHmg))
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
                if (fXmlNodeListHmg != null)
                {
                    fXmlNodeListHmg.Dispose();
                    fXmlNodeListHmg = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void changeDirection(
            )
        {
            string messageType = string.Empty;
            bool isModelingObject = false;
            FXmlNodeList fXmlNodeListHmg = null;

            try
            {
                isModelingObject = this.isModelingObject;

                // --

                // ***
                // Host Messages의 Direction이 변경될 경우,
                // Child Host Message의 Color를 변경한다.
                // ***
                if (this.fDirection == FDirection.Host)
                {
                    this.fontColor = Color.DarkGreen;
                    foreach (FHostMessage msg in this.fChildHostMessageCollection)
                    {
                        if (msg.isPrimary == true)
                        {
                            msg.fontColor = Color.DarkGreen;
                        }
                        else
                        {
                            msg.fontColor = Color.DarkRed;
                        }

                        // --

                        if (isModelingObject)
                        {
                            this.fOcdCore.fEventPusher.pushEvent(
                                new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fOpcDriver, this, FOpcDriverCommon.createObject(this.fOcdCore, msg.fXmlNode))
                                );
                        }
                    }
                }
                else if (this.fDirection == FDirection.Equipment)
                {
                    this.fontColor = Color.DarkRed;
                    foreach (FHostMessage msg in this.fChildHostMessageCollection)
                    {
                        if (msg.isPrimary == true)
                        {
                            msg.fontColor = Color.DarkRed;
                        }
                        else
                        {
                            msg.fontColor = Color.DarkGreen;
                        }

                        // --

                        if (isModelingObject)
                        {
                            this.fOcdCore.fEventPusher.pushEvent(
                                new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fOpcDriver, this, FOpcDriverCommon.createObject(this.fOcdCore, msg.fXmlNode))
                                );
                        }
                    }
                }
                else if (this.fDirection == FDirection.Both)
                {
                    this.fontColor = Color.Black;
                    foreach (FHostMessage msg in this.fChildHostMessageCollection)
                    {
                        msg.fontColor = Color.Black;

                        // --

                        if (isModelingObject)
                        {
                            this.fOcdCore.fEventPusher.pushEvent(
                                new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fOpcDriver, this, FOpcDriverCommon.createObject(this.fOcdCore, msg.fXmlNode))
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
                if (fXmlNodeListHmg != null)
                {
                    fXmlNodeListHmg.Dispose();
                    fXmlNodeListHmg = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string convertToVfei(
            )
        {
            try
            {
                return FMessageConverter.convertHmsToVfei(this.fXmlNode);
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

        public string convertToTrs(
            )
        {
            try
            {
                return FMessageConverter.convertHmsToTrs(this.fXmlNode);
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
                // Host Messages에 대한 Lock 처리
                // ***
                this.fXmlNode.set_attrVal(FXmlTagHMS.A_Locked, FXmlTagHMS.D_Locked, FBoolean.True, true);

                // --

                // ***
                // Parent인 Host Message List에 대한 Lock 처리
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
                // Lock이 설정되어 있는 Host Message가 존재할 경우 Unlock 작업을 취소한다.
                // ***
                xpath = FXmlTagHMG.E_HostMessage + "[@" + FXmlTagHMG.A_Locked + "='" + FBoolean.True + "']";                
                if (this.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagHMS.A_Locked, FXmlTagHMS.D_Locked, FBoolean.False, true);

                // --

                // ***
                // Parent인 Host Message List에 대한 Unlock 처리
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
                FOpcDriverCommon.validateCutObject(this.fXmlNode);

                // --

                this.remove();

                // --

                resetFlowNode(this.fXmlNode);
                this.copyObject(FCbObjectFormat.HostMessages, fXmlNode);
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
                this.copyObject(FCbObjectFormat.HostMessages, fXmlNode);
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

        public FHostMessages pasteSibling(
            )
        {
            FHostMessages fHostMessages = null;
            try
            {
                FOpcDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.HostMessages);

                // --

                fHostMessages = (FHostMessages)this.pasteObject(FCbObjectFormat.HostMessages);
                return this.fParent.insertAfterChildHostMessages(fHostMessages, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostMessages = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        public FHostMessage pastePrimaryHostMessage(
            )
        {
            FHostMessage fHostMessage = null;

            try
            {
                FOpcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.HostMessage);
                // --
                if (this.hasChildPrimaryHostMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "Host Messages", "Primary Host Message"));
                }

                // --

                fHostMessage = (FHostMessage)this.pasteObject(FCbObjectFormat.HostMessage);
                return this.appendChildPrimaryHostMessage(fHostMessage);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostMessage = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostMessage pasteSecondaryHostMessage(
            )
        {
            FHostMessage fHostMessage = null;

            try
            {
                FOpcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.HostMessage);
                // --
                if (this.hasChildSecondaryHostMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "Host Messages", "Primary Host Message"));
                }

                // --

                fHostMessage = (FHostMessage)this.pasteObject(FCbObjectFormat.HostMessage);
                return this.appendChildSecondaryHostMessage(fHostMessage);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostMessage = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostMessageCollection selectHostMessageByName(
            string name
            )
        {
            const string xpath = FXmlTagHMG.E_HostMessage + "[@" + FXmlTagHMG.A_Name + "='{0}']";

            try
            {
                return new FHostMessageCollection(
                    this.fOcdCore,
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

        public FHostMessage selectSingleHostMessageByName(
            string name
            )
        {
            const string xpath = FXmlTagHMG.E_HostMessage + "[@" + FXmlTagHMG.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostMessage(this.fOcdCore, fXmlNode);
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

        public FHostMessageCollection selectHostMessageByHeader(
            string command,
            string version,
            string hostMessageType
            )
        {
            const string xpath = FXmlTagHMG.E_HostMessage + "[@" + FXmlTagHMG.A_Command + "='{0}' and @" + FXmlTagHMG.A_Version + "='{1}' and @" + FXmlTagHMG.A_HostMessageType + "='{2}']";

            try
            {
                return new FHostMessageCollection(
                    this.fOcdCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, command, version, hostMessageType))
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

        public FHostMessage selectSingleHostMessageByHeader(
            string command,
            string version,
            string hostMessageType
            )
        {
            const string xpath = FXmlTagHMG.E_HostMessage + "[@" + FXmlTagHMG.A_Command + "='{0}' and @" + FXmlTagHMG.A_Version + "='{1}' and @" + FXmlTagHMG.A_HostMessageType + "='{2}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, command, version, hostMessageType));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostMessage(this.fOcdCore, fXmlNode);
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
