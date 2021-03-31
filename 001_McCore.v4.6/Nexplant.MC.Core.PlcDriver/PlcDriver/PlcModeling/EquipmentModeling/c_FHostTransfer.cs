/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHostTransfer.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.16
--  Description     : FAMate Core FaPlcDriver Host Transfer Class 
--  History         : Created by Jeff.Kim at 2013.07.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    public class FHostTransfer : FBaseObject<FHostTransfer>, FIObject, FITransfer
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHostTransfer(
            FPlcDriver fPlcDriver
            )
            : base(fPlcDriver.fPcdCore, FPlcDriverCommon.createXmlNodeHTF(fPlcDriver.fPcdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FHostTransfer(
            FPcdCore fPcdCore,
            FXmlNode fXmlNode
            )
            : base(fPcdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHostTransfer(
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
                    return FObjectType.HostTransfer;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.HostTransfer;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTransferType fTransferType
        {
            get
            {
                try
                {
                    return FTransferType.HostTransfer;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FTransferType.HostTransfer;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHTF.A_UniqueId, FXmlTagHTF.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHTF.A_Name, FXmlTagHTF.D_Name);
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
                    FPlcDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagHTF.A_Name, FXmlTagHTF.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHTF.A_Description, FXmlTagHTF.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagHTF.A_Description, FXmlTagHTF.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagHTF.A_FontColor, FXmlTagHTF.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagHTF.A_FontColor, FXmlTagHTF.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHTF.A_FontBold, FXmlTagHTF.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagHTF.A_FontBold, FXmlTagHTF.D_FontBold, FBoolean.fromBool(value), true);
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

        public FHostDevice fDevice
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagHTF.A_HostDeviceId, FXmlTagHTF.D_HostDeviceId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagHDM.E_HostDeviceModeling +
                        "/" + FXmlTagHDV.E_HostDevice + "[@" + FXmlTagHDV.A_UniqueId + "='" + id + "']";
                    // --
                    return new FHostDevice(this.fPcdCore, this.fPlcDriver.fXmlNode.selectSingleNode(xpath));
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

        public FHostSession fSession
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagHTF.A_HostSessionId, FXmlTagHTF.D_HostSessionId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagHDM.E_HostDeviceModeling +
                        "/" + FXmlTagHDV.E_HostDevice +
                        "/" + FXmlTagHSN.E_HostSession + "[@" + FXmlTagHSN.A_UniqueId + "='" + id + "']";
                    // --
                    return new FHostSession(this.fPcdCore, this.fPlcDriver.fXmlNode.selectSingleNode(xpath));
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

        public FHostMessage fMessage
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagHTF.A_HostMessageId, FXmlTagHTF.D_HostMessageId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagHLM.E_HostLibraryModeling +
                        "/" + FXmlTagHLG.E_HostLibraryGroup +
                        "/" + FXmlTagHLB.E_HostLibrary +
                        "/" + FXmlTagHML.E_HostMessageList +
                        "/" + FXmlTagHMS.E_HostMessages +
                        "/" + FXmlTagHMG.E_HostMessage + "[@" + FXmlTagHMG.A_UniqueId + "='" + id + "']";
                    // --
                    return new FHostMessage(this.fPcdCore, this.fPlcDriver.fXmlNode.selectSingleNode(xpath));
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
                    return this.fXmlNode.get_attrVal(FXmlTagHTF.A_UserTag1, FXmlTagHTF.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagHTF.A_UserTag1, FXmlTagHTF.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHTF.A_UserTag2, FXmlTagHTF.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagHTF.A_UserTag2, FXmlTagHTF.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHTF.A_UserTag3, FXmlTagHTF.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagHTF.A_UserTag3, FXmlTagHTF.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHTF.A_UserTag4, FXmlTagHTF.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagHTF.A_UserTag4, FXmlTagHTF.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHTF.A_UserTag5, FXmlTagHTF.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagHTF.A_UserTag5, FXmlTagHTF.D_UserTag5, value, true);
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

        public FHostTransmitter fParent
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

                    return new FHostTransmitter(this.fPcdCore, this.fXmlNode.fParentNode);
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

        public FHostTransfer fPreviousSibling
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

                    return new FHostTransfer(this.fPcdCore, this.fXmlNode.fPreviousSibling);
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

        public FHostTransfer fNextSibling
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

                    return new FHostTransfer(this.fPcdCore, this.fXmlNode.fNextSibling);
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
                            "../../" + FXmlTagHTN.E_HostTransmitter + "[@" + FXmlTagHTN.A_UniqueId + "='" + fParent.uniqueIdToString + "']";
                    }
                    return new FObjectCollection(this.fPcdCore, this.fXmlNode.selectNodes(xpath));
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
                        "../../../../../../" + FXmlTagHDM.E_HostDeviceModeling +
                        "/" + FXmlTagHDV.E_HostDevice + "[@" + FXmlTagHDV.A_UniqueId + "='" + this.fDevice.uniqueIdToString + "']" +
                        " | " +
                        "../../../../../../" + FXmlTagHDM.E_HostDeviceModeling +
                        "/" + FXmlTagHDV.E_HostDevice +
                        "/" + FXmlTagHSN.E_HostSession + "[@" + FXmlTagHSN.A_UniqueId + "='" + this.fSession.uniqueIdToString + "']" +
                        " | " +
                        "../../../../../../" + FXmlTagHLM.E_HostLibraryModeling +
                        "/" + FXmlTagHLG.E_HostLibraryGroup +
                        "/" + FXmlTagHLB.E_HostLibrary +
                        "/" + FXmlTagHML.E_HostMessageList +
                        "/" + FXmlTagHMS.E_HostMessages +
                        "/" + FXmlTagHMG.E_HostMessage + "[@" + FXmlTagHMG.A_UniqueId + "='" + this.fMessage.uniqueIdToString + "']";
                    }
                    else
                    {
                        xpath = "NULL";
                    }
                    // --
                    return new FObjectCollection(this.fPcdCore, this.fXmlNode.selectNodes(xpath));
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

        public bool hasDevice
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagHTF.A_HostDeviceId, FXmlTagHTF.D_HostDeviceId) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagHTF.A_HostSessionId, FXmlTagHTF.D_HostSessionId) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagHTF.A_HostMessageId, FXmlTagHTF.D_HostMessageId) == string.Empty)
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
                        !FClipboard.containsData(FCbObjectFormat.HostTransfer)
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
            FHostMessage fHmg = null;
            string info = string.Empty;

            try
            {
                info = this.name;

                // --            

                if (option == FStringOption.Detail)
                {
                    if (this.hasMessage)
                    {
                        fHmg = this.fMessage;
                        // --
                        info +=
                            " Message=[" + this.fDevice.name + " / " + this.fSession.name + " /" +
                            " " + fHmg.command + " V" + fHmg.version.ToString() + " : " + fHmg.name + "]";
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
                fHmg = null;
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
                FPlcDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);                

                // --

                resetRelation();

                // --

                fParent = this.fParent;
                isModelingObject = this.isModelingObject;
                this.replace(this.fPcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));

                // --

                if (isModelingObject)
                {
                    this.fPcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fPlcDriver, fParent, this)
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
            FHostDevice fHostDevice,
            FHostSession fHostSession,
            FHostMessage fHostMessage
            )
        {
            string oldHdvId = string.Empty;
            string oldHsnId = string.Empty;
            string oldHmgId = string.Empty;
            string newHdvId = string.Empty;
            string newHsnId = string.Empty;
            string newHmgId = string.Empty;

            try
            {
                // ***
                // Host Device 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fHostDevice.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Device", "Modeling File"));
                }

                // ***
                // Host Session 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fHostSession.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Session", "Modeling File"));
                }

                // ***
                // Host Message 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fHostMessage.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Message", "Modeling File"));
                }

                // ***
                // Host Transfer 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Transfer", "Modeling File"));
                }

                // ***
                // Host Device와 SECS Transfer의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fHostDevice))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Host Device and the Host Transfer", "same"));
                }

                // ***
                // Host Session과 Host Transfer의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fHostSession))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Host Session and the Host Transfer", "same"));
                }

                // ***
                // Host Message와 Host Transfer의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fHostMessage))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Host Message and the Host Transfer", "same"));
                }

                // ***
                // Host Session 개체가 Host Device 개체의 자식인지 검사
                // ***
                if (!fHostDevice.containsObject(fHostSession))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Session", "Host Device"));
                }

                // ***
                // Host Session의 Library와 Host Message의 Library가 동일한지 검사
                // ***
                if (fHostSession.fLibrary != fHostMessage.fAncestorHostLibrary)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Host Library of the Host Session and the Host Message", "same"));
                }

                // --

                oldHdvId = this.fXmlNode.get_attrVal(FXmlTagHTF.A_HostDeviceId, FXmlTagHTF.D_HostDeviceId);
                oldHsnId = this.fXmlNode.get_attrVal(FXmlTagHTF.A_HostSessionId, FXmlTagHTF.D_HostSessionId);
                oldHmgId = this.fXmlNode.get_attrVal(FXmlTagHTF.A_HostMessageId, FXmlTagHTF.D_HostMessageId);
                // --
                newHdvId = fHostDevice.uniqueIdToString;
                newHsnId = fHostSession.uniqueIdToString;
                newHmgId = fHostMessage.uniqueIdToString;
                // --
                if (oldHdvId == newHdvId && oldHsnId == newHsnId && oldHmgId == newHmgId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 Host Message가 존재할 경우 Reset 한다.
                // ***
                if (oldHmgId != string.Empty)
                {
                    resetMessage(false);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagHTF.A_HostDeviceId, FXmlTagHTF.D_HostDeviceId, newHdvId, false);
                this.fXmlNode.set_attrVal(FXmlTagHTF.A_HostSessionId, FXmlTagHTF.D_HostSessionId, newHsnId, false);
                this.fXmlNode.set_attrVal(FXmlTagHTF.A_HostMessageId, FXmlTagHTF.D_HostMessageId, newHmgId, true);
                // --
                fHostSession.lockObject();
                fHostMessage.lockObject();
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
            FHostSession fHostSession = null;
            FHostMessage fHostMessage = null;

            try
            {
                fHostSession = this.fSession;
                fHostMessage = this.fMessage;
                if (fHostMessage == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagHTF.A_HostDeviceId, FXmlTagHTF.D_HostDeviceId, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagHTF.A_HostSessionId, FXmlTagHTF.D_HostSessionId, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagHTF.A_HostMessageId, FXmlTagHTF.D_HostMessageId, string.Empty, isModifyEvent);
                // --
                fHostSession.unlockObject();
                fHostMessage.unlockObject();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostSession = null;
                fHostMessage = null;
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
                fXmlNode.set_attrVal(FXmlTagHTF.A_HostDeviceId, FXmlTagHTF.D_HostDeviceId, FXmlTagHTF.D_HostDeviceId);
                fXmlNode.set_attrVal(FXmlTagHTF.A_HostSessionId, FXmlTagHTF.D_HostSessionId, FXmlTagHTF.D_HostSessionId);
                fXmlNode.set_attrVal(FXmlTagHTF.A_HostMessageId, FXmlTagHTF.D_HostMessageId, FXmlTagHTF.D_HostMessageId);
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
                this.copyObject(FCbObjectFormat.HostTransfer, fXmlNode);
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
                FPlcDriverCommon.validateCutObject(this.fXmlNode);

                // --

                this.remove();

                // --

                resetFlowNode(this.fXmlNode);
                this.copyObject(FCbObjectFormat.HostTransfer, this.fXmlNode);
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

        public FHostTransfer pasteSibling(
            )
        {
            FHostTransfer fHostTransfer = null;

            try
            {
                FPlcDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.HostTransfer);

                // --

                fHostTransfer = (FHostTransfer)this.pasteObject(FCbObjectFormat.HostTransfer);
                return this.fParent.insertAfterChildHostTransfer(fHostTransfer, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostTransfer = null;
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
                FPlcDriverCommon.validateMoveUpObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fPcdCore, this.fXmlNode.moveUp());

                // --

                if (isModelingObject)
                {
                    this.fPcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveUpCompleted, this.fPlcDriver, fParent, this)
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
                FPlcDriverCommon.validateMoveDownObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fPcdCore, this.fXmlNode.moveDown());

                // --

                if (isModelingObject)
                {
                    this.fPcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveDownCompleted, this.fPlcDriver, fParent, this)
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
            FHostTransfer fRefObject
            )
        {
            try
            {
                FPlcDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

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

                this.replace(this.fPcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fPcdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                this.fPcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fPlcDriver, this, fRefObject)
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
            FHostTransmitter fRefObject
            )
        {
            try
            {
                FPlcDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

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

                if (fRefObject.fChildHostTransferCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildHostTransferCollection[fRefObject.fChildHostTransferCollection.count - 1]))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "same localtion"));
                    }
                }

                // --

                this.replace(this.fPcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fPcdCore, fRefObject.fXmlNode.appendChild(this.fXmlNode));

                // --

                this.fPcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fPlcDriver, this, fRefObject)
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
