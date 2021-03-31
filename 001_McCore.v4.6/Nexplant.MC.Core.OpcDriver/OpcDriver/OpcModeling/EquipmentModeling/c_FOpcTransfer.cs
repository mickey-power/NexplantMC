/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOpcTransfer.cs
--  Creator         : spike.lee
--  Create Date     : 2013.08.22
--  Description     : FAMate Core FaOpcDriver OPC Transfer Class 
--  History         : Created by Jeff.Kim at 2013.08.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public class FOpcTransfer : FBaseObject<FOpcTransfer>, FIObject, FITransfer
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOpcTransfer(
            FOpcDriver fOpcDriver
            )
            : base(fOpcDriver.fOcdCore, FOpcDriverCommon.createXmlNodeOTF(fOpcDriver.fOcdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FOpcTransfer(
            FOcdCore fOcdCore,
            FXmlNode fXmlNode
            )
            : base(fOcdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOpcTransfer(
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
                    return FObjectType.OpcTransfer;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.OpcTransfer;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTransferType fTransferType
        {
            get
            {
                try
                {
                    return FTransferType.OpcTransfer;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FTransferType.OpcTransfer;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOTF.A_UniqueId, FXmlTagOTF.D_UniqueId);
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

        public string name
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOTF.A_Name, FXmlTagOTF.D_Name);
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

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagOTF.A_Name, FXmlTagOTF.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOTF.A_Description, FXmlTagOTF.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagOTF.A_Description, FXmlTagOTF.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagOTF.A_FontColor, FXmlTagOTF.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagOTF.A_FontColor, FXmlTagOTF.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOTF.A_FontBold, FXmlTagOTF.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagOTF.A_FontBold, FXmlTagOTF.D_FontBold, FBoolean.fromBool(value), true);
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

        public FOpcDevice fDevice
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagOTF.A_OpcDeviceId, FXmlTagOTF.D_OpcDeviceId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagODM.E_OpcDeviceModeling +
                        "/" + FXmlTagODV.E_OpcDevice + "[@" + FXmlTagODV.A_UniqueId + "='" + id + "']";
                    // --
                    return new FOpcDevice(this.fOcdCore, this.fOpcDriver.fXmlNode.selectSingleNode(xpath));
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

        public FOpcSession fSession
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagOTF.A_OpcSessionId, FXmlTagOTF.D_OpcSessionId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagODM.E_OpcDeviceModeling +
                        "/" + FXmlTagODV.E_OpcDevice +
                        "/" + FXmlTagOSN.E_OpcSession + "[@" + FXmlTagOSN.A_UniqueId + "='" + id + "']";
                    // --
                    return new FOpcSession(this.fOcdCore, this.fOpcDriver.fXmlNode.selectSingleNode(xpath));
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

        public FOpcMessage fMessage
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagOTF.A_OpcMessageId, FXmlTagOTF.D_OpcMessageId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagOLM.E_OpcLibraryModeling +
                        "/" + FXmlTagOLG.E_OpcLibraryGroup +
                        "/" + FXmlTagOLB.E_OpcLibrary +
                        "/" + FXmlTagOML.E_OpcMessageList +
                        "/" + FXmlTagOMS.E_OpcMessages +
                        "/" + FXmlTagOMG.E_OpcMessage + "[@" + FXmlTagOMG.A_UniqueId + "='" + id + "']";
                    // --
                    return new FOpcMessage(this.fOcdCore, this.fOpcDriver.fXmlNode.selectSingleNode(xpath));
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

        public string userTag1
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOTF.A_UserTag1, FXmlTagOTF.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagOTF.A_UserTag1, FXmlTagOTF.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOTF.A_UserTag2, FXmlTagOTF.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagOTF.A_UserTag2, FXmlTagOTF.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOTF.A_UserTag3, FXmlTagOTF.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagOTF.A_UserTag3, FXmlTagOTF.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOTF.A_UserTag4, FXmlTagOTF.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagOTF.A_UserTag4, FXmlTagOTF.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOTF.A_UserTag5, FXmlTagOTF.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagOTF.A_UserTag5, FXmlTagOTF.D_UserTag5, value, true);
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

        public FOpcTransmitter fParent
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

                    return new FOpcTransmitter(this.fOcdCore, this.fXmlNode.fParentNode);
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

        public FOpcTransfer fPreviousSibling
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

                    return new FOpcTransfer(this.fOcdCore, this.fXmlNode.fPreviousSibling);
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

        public FOpcTransfer fNextSibling
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

                    return new FOpcTransfer(this.fOcdCore, this.fXmlNode.fNextSibling);
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
                    if (this.fParent != null)
                    {
                        xpath =
                            "../../" + FXmlTagOTN.E_OpcTransmitter + "[@" + FXmlTagOTN.A_UniqueId + "='" + fParent.uniqueIdToString + "']";
                    }
                    return new FObjectCollection(this.fOcdCore, this.fXmlNode.selectNodes(xpath));
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
                string xpath = string.Empty;

                try
                {
                    if (this.fMessage != null)
                    {
                        xpath =
                        "../../../../../../" + FXmlTagODM.E_OpcDeviceModeling +
                        "/" + FXmlTagODV.E_OpcDevice + "[@" + FXmlTagODV.A_UniqueId + "='" + this.fDevice.uniqueIdToString + "']" +
                        " | " +
                        "../../../../../../" + FXmlTagODM.E_OpcDeviceModeling +
                        "/" + FXmlTagODV.E_OpcDevice +
                        "/" + FXmlTagOSN.E_OpcSession + "[@" + FXmlTagOSN.A_UniqueId + "='" + this.fSession.uniqueIdToString + "']" +
                        " | " +
                        "../../../../../../" + FXmlTagOLM.E_OpcLibraryModeling +
                        "/" + FXmlTagOLG.E_OpcLibraryGroup +
                        "/" + FXmlTagOLB.E_OpcLibrary +
                        "/" + FXmlTagOML.E_OpcMessageList +
                        "/" + FXmlTagOMS.E_OpcMessages +
                        "/" + FXmlTagOMG.E_OpcMessage + "[@" + FXmlTagOMG.A_UniqueId + "='" + this.fMessage.uniqueIdToString + "']";
                    }
                    else
                    {
                        xpath = "NULL";
                    }
                    // --
                    return new FObjectCollection(this.fOcdCore, this.fXmlNode.selectNodes(xpath));
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

        public bool hasDevice
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagOTF.A_OpcDeviceId, FXmlTagOTF.D_OpcDeviceId) == string.Empty)
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

        public bool hasSession
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagOTF.A_OpcSessionId, FXmlTagOTF.D_OpcSessionId) == string.Empty)
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

        public bool hasMessage
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagOTF.A_OpcMessageId, FXmlTagOTF.D_OpcMessageId) == string.Empty)
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

        public bool canAppendChild
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

        public bool canCut
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

        public bool canPasteSibling
        {
            get
            {
                try
                {
                    if (
                        this.fXmlNode.fParentNode == null ||
                        !FClipboard.containsData(FCbObjectFormat.OpcTransfer)
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public string ToString(
            FStringOption option
            )
        {
            FOpcMessage fOmg = null;
            string info = string.Empty;

            try
            {
                info = this.name;

                // --            

                if (option == FStringOption.Detail)
                {
                    if (this.hasMessage)
                    {
                        fOmg = this.fMessage;
                        // --
                        info +=
                            " Msg.=[" + this.fDevice.name + " / " + this.fSession.name + " / " + fOmg.name + "]";
                    }
                }
                
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
                fOmg = null;
            }
            return string.Empty;
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

        public void setMessage(
            FOpcDevice fOpcDevice,
            FOpcSession fOpcSession,
            FOpcMessage fOpcMessage
            )
        {
            string oldOdvId = string.Empty;
            string oldOsnId = string.Empty;
            string oldOmgId = string.Empty;
            string newOdvId = string.Empty;
            string newOsnId = string.Empty;
            string newOmgId = string.Empty;

            try
            {
                // ***
                // OPC Device 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fOpcDevice.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "OPC Device", "Modeling File"));
                }

                // ***
                // OPC Session 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fOpcSession.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "OPC Session", "Modeling File"));
                }

                // ***
                // OPC Message 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fOpcMessage.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "OPC Message", "Modeling File"));
                }

                // ***
                // OPC Transfer 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "OPC Transfer", "Modeling File"));
                }

                // ***
                // OPC Device와 OPC Transfer의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fOpcDevice))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the OPC Device and the OPC Transfer", "same"));
                }

                // ***
                // OPC Session과 OPC Transfer의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fOpcSession))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the OPC Session and the OPC Transfer", "same"));
                }

                // ***
                // OPC Message와 OPC Transfer의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fOpcMessage))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the OPC Message and the OPC Transfer", "same"));
                }

                // ***
                // OPC Session 개체가 OPC Device 개체의 자식인지 검사
                // ***
                if (!fOpcDevice.containsObject(fOpcSession))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "OPC Session", "OPC Device"));
                }

                // ***
                // OPC Session의 Library와 OPC Message의 Library가 동일한지 검사
                // ***
                if (fOpcSession.fLibrary != fOpcMessage.fAncestorOpcLibrary)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "OPC Library of the OPC Session and the OPC Message", "same"));
                }

                // --

                oldOdvId = this.fXmlNode.get_attrVal(FXmlTagOTF.A_OpcDeviceId, FXmlTagOTF.D_OpcDeviceId);
                oldOsnId = this.fXmlNode.get_attrVal(FXmlTagOTF.A_OpcSessionId, FXmlTagOTF.D_OpcSessionId);
                oldOmgId = this.fXmlNode.get_attrVal(FXmlTagOTF.A_OpcMessageId, FXmlTagOTF.D_OpcMessageId);
                // --
                newOdvId = fOpcDevice.uniqueIdToString;
                newOsnId = fOpcSession.uniqueIdToString;
                newOmgId = fOpcMessage.uniqueIdToString;
                // --
                if (oldOdvId == newOdvId && oldOsnId == newOsnId && oldOmgId == newOmgId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 Opc Message가 존재할 경우 Reset 한다.
                // ***
                if (oldOmgId != string.Empty)
                {
                    resetMessage(false);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagOTF.A_OpcDeviceId, FXmlTagOTF.D_OpcDeviceId, newOdvId, false);
                this.fXmlNode.set_attrVal(FXmlTagOTF.A_OpcSessionId, FXmlTagOTF.D_OpcSessionId, newOsnId, false);
                this.fXmlNode.set_attrVal(FXmlTagOTF.A_OpcMessageId, FXmlTagOTF.D_OpcMessageId, newOmgId, true);
                // --
                fOpcSession.lockObject();
                fOpcMessage.lockObject();
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

        internal void resetMessage(
            bool isModifyEvent
            )
        {
            FOpcSession fOpcSession = null;
            FOpcMessage fOpcMessage = null;

            try
            {
                fOpcSession = this.fSession;
                fOpcMessage = this.fMessage;
                if (fOpcMessage == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagOTF.A_OpcDeviceId, FXmlTagOTF.D_OpcDeviceId, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagOTF.A_OpcSessionId, FXmlTagOTF.D_OpcSessionId, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagOTF.A_OpcMessageId, FXmlTagOTF.D_OpcMessageId, string.Empty, isModifyEvent);
                // --
                fOpcSession.unlockObject();
                fOpcMessage.unlockObject();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOpcSession = null;
                fOpcMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void resetMessage(
            )
        {
            try
            {
                resetMessage(true);
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

        internal void resetRelation(
            )
        {
            try
            {
                resetMessage(false);
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
                fXmlNode.set_attrVal(FXmlTagOTF.A_OpcDeviceId, FXmlTagOTF.D_OpcDeviceId, FXmlTagOTF.D_OpcDeviceId);
                fXmlNode.set_attrVal(FXmlTagOTF.A_OpcSessionId, FXmlTagOTF.D_OpcSessionId, FXmlTagOTF.D_OpcSessionId);
                fXmlNode.set_attrVal(FXmlTagOTF.A_OpcMessageId, FXmlTagOTF.D_OpcMessageId, FXmlTagOTF.D_OpcMessageId);
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
                this.copyObject(FCbObjectFormat.OpcTransfer, fXmlNode);
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
                FOpcDriverCommon.validateCutObject(this.fXmlNode);

                // --

                this.remove();

                // --

                resetFlowNode(this.fXmlNode);
                this.copyObject(FCbObjectFormat.OpcTransfer, this.fXmlNode);
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

        public FOpcTransfer pasteSibling(
            )
        {
            FOpcTransfer fOpcTransfer = null;

            try
            {
                FOpcDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.OpcTransfer);

                // --

                fOpcTransfer = (FOpcTransfer)this.pasteObject(FCbObjectFormat.OpcTransfer);
                return this.fParent.insertAfterChildOpcTransfer(fOpcTransfer, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOpcTransfer = null;
            }
            return null;
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
            FOpcTransfer fRefObject
            )
        {
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

                if (!this.fParent.Equals(fRefObject.fParent))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0008, "Object", "Parent"));
                }

                // --

                this.replace(this.fOcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fOcdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

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

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void moveTo(
            FOpcTransmitter fRefObject
            )
        {
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

                if (!this.fParent.Equals(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0008, "Object", "Parent"));
                }

                if (fRefObject.fChildOpcTransferCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildOpcTransferCollection[fRefObject.fChildOpcTransferCollection.count - 1]))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "same localtion"));
                    }
                }

                // --

                this.replace(this.fOcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fOcdCore, fRefObject.fXmlNode.appendChild(this.fXmlNode));

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

            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
