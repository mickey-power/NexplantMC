/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPlcTransfer.cs
--  Creator         : spike.lee
--  Create Date     : 2013.08.22
--  Description     : FAMate Core FaPlcDriver PLC Transfer Class 
--  History         : Created by Jeff.Kim at 2013.08.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    public class FPlcTransfer : FBaseObject<FPlcTransfer>, FIObject, FITransfer
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPlcTransfer(
            FPlcDriver fPlcDriver
            )
            : base(fPlcDriver.fPcdCore, FPlcDriverCommon.createXmlNodePTF(fPlcDriver.fPcdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FPlcTransfer(
            FPcdCore fPcdCore,
            FXmlNode fXmlNode
            )
            : base(fPcdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPlcTransfer(
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
                    return FObjectType.PlcTransfer;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.PlcTransfer;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTransferType fTransferType
        {
            get
            {
                try
                {
                    return FTransferType.PlcTransfer;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FTransferType.PlcTransfer;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagPTF.A_UniqueId, FXmlTagPTF.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPTF.A_Name, FXmlTagPTF.D_Name);
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

                    this.fXmlNode.set_attrVal(FXmlTagPTF.A_Name, FXmlTagPTF.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPTF.A_Description, FXmlTagPTF.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagPTF.A_Description, FXmlTagPTF.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagPTF.A_FontColor, FXmlTagPTF.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagPTF.A_FontColor, FXmlTagPTF.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagPTF.A_FontBold, FXmlTagPTF.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagPTF.A_FontBold, FXmlTagPTF.D_FontBold, FBoolean.fromBool(value), true);
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

        public FPlcDevice fDevice
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagPTF.A_PlcDeviceId, FXmlTagPTF.D_PlcDeviceId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagPDM.E_PlcDeviceModeling +
                        "/" + FXmlTagPDV.E_PlcDevice + "[@" + FXmlTagPDV.A_UniqueId + "='" + id + "']";
                    // --
                    return new FPlcDevice(this.fPcdCore, this.fPlcDriver.fXmlNode.selectSingleNode(xpath));
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

        public FPlcSession fSession
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagPTF.A_PlcSessionId, FXmlTagPTF.D_PlcSessionId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagPDM.E_PlcDeviceModeling +
                        "/" + FXmlTagPDV.E_PlcDevice +
                        "/" + FXmlTagPSN.E_PlcSession + "[@" + FXmlTagPSN.A_UniqueId + "='" + id + "']";
                    // --
                    return new FPlcSession(this.fPcdCore, this.fPlcDriver.fXmlNode.selectSingleNode(xpath));
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

        public FPlcMessage fMessage
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagPTF.A_PlcMessageId, FXmlTagPTF.D_PlcMessageId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagPLM.E_PlcLibraryModeling +
                        "/" + FXmlTagPLG.E_PlcLibraryGroup +
                        "/" + FXmlTagPLB.E_PlcLibrary +
                        "/" + FXmlTagPML.E_PlcMessageList +     
                        "/" + FXmlTagPMS.E_PlcMessages +
                        "/" + FXmlTagPMG.E_PlcMessage + "[@" + FXmlTagPMG.A_UniqueId + "='" + id + "']";
                    // --
                    return new FPlcMessage(this.fPcdCore, this.fPlcDriver.fXmlNode.selectSingleNode(xpath));
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
                    return this.fXmlNode.get_attrVal(FXmlTagPTF.A_UserTag1, FXmlTagPTF.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagPTF.A_UserTag1, FXmlTagPTF.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPTF.A_UserTag2, FXmlTagPTF.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagPTF.A_UserTag2, FXmlTagPTF.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPTF.A_UserTag3, FXmlTagPTF.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagPTF.A_UserTag3, FXmlTagPTF.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPTF.A_UserTag4, FXmlTagPTF.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagPTF.A_UserTag4, FXmlTagPTF.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPTF.A_UserTag5, FXmlTagPTF.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagPTF.A_UserTag5, FXmlTagPTF.D_UserTag5, value, true);
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

        public FPlcTransmitter fParent
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

                    return new FPlcTransmitter(this.fPcdCore, this.fXmlNode.fParentNode);
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

        public FPlcTransfer fPreviousSibling
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

                    return new FPlcTransfer(this.fPcdCore, this.fXmlNode.fPreviousSibling);
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

        public FPlcTransfer fNextSibling
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

                    return new FPlcTransfer(this.fPcdCore, this.fXmlNode.fNextSibling);
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
                            "../../" + FXmlTagPTN.E_PlcTransmitter + "[@" + FXmlTagPTN.A_UniqueId + "='" + fParent.uniqueIdToString + "']";
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
                        "../../../../../../" + FXmlTagPDM.E_PlcDeviceModeling +
                        "/" + FXmlTagPDV.E_PlcDevice + "[@" + FXmlTagPDV.A_UniqueId + "='" + this.fDevice.uniqueIdToString + "']" +
                        " | " +
                        "../../../../../../" + FXmlTagPDM.E_PlcDeviceModeling +
                        "/" + FXmlTagPDV.E_PlcDevice +
                        "/" + FXmlTagPSN.E_PlcSession + "[@" + FXmlTagPSN.A_UniqueId + "='" + this.fSession.uniqueIdToString + "']" +
                        " | " +
                        "../../../../../../" + FXmlTagPLM.E_PlcLibraryModeling +
                        "/" + FXmlTagPLG.E_PlcLibraryGroup +
                        "/" + FXmlTagPLB.E_PlcLibrary +
                        "/" + FXmlTagPML.E_PlcMessageList +
                        "/" + FXmlTagPMS.E_PlcMessages +
                        "/" + FXmlTagPMG.E_PlcMessage + "[@" + FXmlTagPMG.A_UniqueId + "='" + this.fMessage.uniqueIdToString + "']";
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
                    if (this.fXmlNode.get_attrVal(FXmlTagPTF.A_PlcDeviceId, FXmlTagPTF.D_PlcDeviceId) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagPTF.A_PlcSessionId, FXmlTagPTF.D_PlcSessionId) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagPTF.A_PlcMessageId, FXmlTagPTF.D_PlcMessageId) == string.Empty)
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
                        !FClipboard.containsData(FCbObjectFormat.PlcTransfer)
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
            FPlcMessage fPmg = null;
            string info = string.Empty;

            try
            {
                info = this.name;

                // --            

                if (option == FStringOption.Detail)
                {
                    if (this.hasMessage)
                    {
                        fPmg = this.fMessage;
                        // --
                        info +=
                            " Msg.=[" + this.fDevice.name + " / " + this.fSession.name + " / " + fPmg.name + "]";
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
                fPmg = null;
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
            FPlcDevice fPlcDevice,
            FPlcSession fPlcSession,
            FPlcMessage fPlcMessage
            )
        {
            string oldPdvId = string.Empty;
            string oldPsnId = string.Empty;
            string oldPmgId = string.Empty;
            string newPdvId = string.Empty;
            string newPsnId = string.Empty;
            string newPmgId = string.Empty;

            try
            {
                // ***
                // PLC Device 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fPlcDevice.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "PLC Device", "Modeling File"));
                }

                // ***
                // PLC Session 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fPlcSession.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "PLC Session", "Modeling File"));
                }

                // ***
                // PLC Message 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fPlcMessage.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "PLC Message", "Modeling File"));
                }

                // ***
                // PLC Transfer 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "PLC Transfer", "Modeling File"));
                }

                // ***
                // PLC Device와 PLC Transfer의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fPlcDevice))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the PLC Device and the PLC Transfer", "same"));
                }

                // ***
                // PLC Session과 PLC Transfer의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fPlcSession))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the PLC Session and the PLC Transfer", "same"));
                }

                // ***
                // PLC Message와 PLC Transfer의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fPlcMessage))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the PLC Message and the PLC Transfer", "same"));
                }

                // ***
                // PLC Session 개체가 PLC Device 개체의 자식인지 검사
                // ***
                if (!fPlcDevice.containsObject(fPlcSession))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "PLC Session", "PLC Device"));
                }

                // ***
                // PLC Session의 Library와 PLC Message의 Library가 동일한지 검사
                // ***
                if (fPlcSession.fLibrary != fPlcMessage.fAncestorPlcLibrary)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "PLC Library of the PLC Session and the PLC Message", "same"));
                }

                // --

                oldPdvId = this.fXmlNode.get_attrVal(FXmlTagPTF.A_PlcDeviceId, FXmlTagPTF.D_PlcDeviceId);
                oldPsnId = this.fXmlNode.get_attrVal(FXmlTagPTF.A_PlcSessionId, FXmlTagPTF.D_PlcSessionId);
                oldPmgId = this.fXmlNode.get_attrVal(FXmlTagPTF.A_PlcMessageId, FXmlTagPTF.D_PlcMessageId);
                // --
                newPdvId = fPlcDevice.uniqueIdToString;
                newPsnId = fPlcSession.uniqueIdToString;
                newPmgId = fPlcMessage.uniqueIdToString;
                // --
                if (oldPdvId == newPdvId && oldPsnId == newPsnId && oldPmgId == newPmgId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 PLC Message가 존재할 경우 Reset 한다.
                // ***
                if (oldPmgId != string.Empty)
                {
                    resetMessage(false);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagPTF.A_PlcDeviceId, FXmlTagPTF.D_PlcDeviceId, newPdvId, false);
                this.fXmlNode.set_attrVal(FXmlTagPTF.A_PlcSessionId, FXmlTagPTF.D_PlcSessionId, newPsnId, false);
                this.fXmlNode.set_attrVal(FXmlTagPTF.A_PlcMessageId, FXmlTagPTF.D_PlcMessageId, newPmgId, true);
                // --
                fPlcSession.lockObject();
                fPlcMessage.lockObject();
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
            FPlcSession fPlcSession = null;
            FPlcMessage fPlcMessage = null;

            try
            {
                fPlcSession = this.fSession;
                fPlcMessage = this.fMessage;
                if (fPlcMessage == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagPTF.A_PlcDeviceId, FXmlTagPTF.D_PlcDeviceId, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagPTF.A_PlcSessionId, FXmlTagPTF.D_PlcSessionId, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagPTF.A_PlcMessageId, FXmlTagPTF.D_PlcMessageId, string.Empty, isModifyEvent);
                // --
                fPlcSession.unlockObject();
                fPlcMessage.unlockObject();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPlcSession = null;
                fPlcMessage = null;
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
                fXmlNode.set_attrVal(FXmlTagPTF.A_PlcDeviceId, FXmlTagPTF.D_PlcDeviceId, FXmlTagPTF.D_PlcDeviceId);
                fXmlNode.set_attrVal(FXmlTagPTF.A_PlcSessionId, FXmlTagPTF.D_PlcSessionId, FXmlTagPTF.D_PlcSessionId);
                fXmlNode.set_attrVal(FXmlTagPTF.A_PlcMessageId, FXmlTagPTF.D_PlcMessageId, FXmlTagPTF.D_PlcMessageId);
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
                this.copyObject(FCbObjectFormat.PlcTransfer, fXmlNode);
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
                this.copyObject(FCbObjectFormat.PlcTransfer, this.fXmlNode);
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

        public FPlcTransfer pasteSibling(
            )
        {
            FPlcTransfer fPlcTransfer = null;

            try
            {
                FPlcDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.PlcTransfer);

                // --

                fPlcTransfer = (FPlcTransfer)this.pasteObject(FCbObjectFormat.PlcTransfer);
                return this.fParent.insertAfterChildPlcTransfer(fPlcTransfer, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPlcTransfer = null;
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
            FPlcTransfer fRefObject
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
            FPlcTransmitter fRefObject
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

                if (fRefObject.fChildPlcTransferCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildPlcTransferCollection[fRefObject.fChildPlcTransferCollection.count - 1]))
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
