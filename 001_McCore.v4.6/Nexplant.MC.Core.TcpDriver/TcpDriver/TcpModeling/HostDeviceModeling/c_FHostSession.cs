/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHostSession.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.16
--  Description     : FAMate Core FaTcpDriver Host Session Class 
--  History         : Created by Jeff.Kim at 2013.07.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public class FHostSession : FBaseObject<FHostSession>, FIObject, FISession
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHostSession(
            FTcpDriver fTcpDriver
            )
            : base(fTcpDriver.fTcdCore, FTcpDriverCommon.createXmlNodeHSN(fTcpDriver.fTcdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FHostSession(
            FTcdCore fTcdCore,
            FXmlNode fXmlNode
            )
            : base(fTcdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHostSession(
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
                    return FObjectType.HostSession;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.HostSession;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSessionType fSessionType
        {
            get
            {
                try
                {
                    return FSessionType.HostSession;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FSessionType.HostSession;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHSN.A_UniqueId, FXmlTagHSN.D_UniqueId);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHSN.A_Locked, FXmlTagHSN.D_Locked));
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

        public int index
        {
            get
            {
                try
                {
                    this.fXmlNode.getIndex(false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHSN.A_Name, FXmlTagHSN.D_Name);
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

                    this.fXmlNode.set_attrVal(FXmlTagHSN.A_Name, FXmlTagHSN.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHSN.A_Description, FXmlTagHSN.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagHSN.A_Description, FXmlTagHSN.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagHSN.A_FontColor, FXmlTagHSN.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagHSN.A_FontColor, FXmlTagHSN.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHSN.A_FontBold, FXmlTagHSN.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagHSN.A_FontBold, FXmlTagHSN.D_FontBold, FBoolean.fromBool(value), true);
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

        public string machineId
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHSN.A_MachineId, FXmlTagHSN.D_MachineID);
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
                    this.fXmlNode.set_attrVal(FXmlTagHSN.A_MachineId, FXmlTagHSN.D_MachineID, value, true);
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

        public int sessionId
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagHSN.A_SessionId, FXmlTagHSN.D_SessionId));
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
                    if (value < 0 || value > 32767)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Session ID"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagHSN.A_SessionId, FXmlTagHSN.D_SessionId, value.ToString(), true);
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

        public FHostLibrary fLibrary
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;                

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagHSN.A_HostLibraryId, FXmlTagHSN.D_HostLibraryId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagHLM.E_HostLibraryModeling +
                        "/" + FXmlTagHLG.E_HostLibraryGroup +
                        "/" + FXmlTagHLB.E_HostLibrary + "[@" + FXmlTagHLB.A_UniqueId + "='" + id + "']";
                    // --
                    return new FHostLibrary(this.fTcdCore, this.fTcpDriver.fXmlNode.selectSingleNode(xpath));
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
                    return this.fXmlNode.get_attrVal(FXmlTagHSN.A_UserTag1, FXmlTagHSN.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagHSN.A_UserTag1, FXmlTagHSN.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHSN.A_UserTag2, FXmlTagHSN.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagHSN.A_UserTag2, FXmlTagHSN.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHSN.A_UserTag3, FXmlTagHSN.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagHSN.A_UserTag3, FXmlTagHSN.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHSN.A_UserTag4, FXmlTagHSN.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagHSN.A_UserTag4, FXmlTagHSN.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHSN.A_UserTag5, FXmlTagHSN.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagHSN.A_UserTag5, FXmlTagHSN.D_UserTag5, value, true);
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

        public FHostDevice fParent
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

                    return new FHostDevice(this.fTcdCore, this.fXmlNode.fParentNode);
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

        public FHostSession fPreviousSibling
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

                    return new FHostSession(this.fTcdCore, this.fXmlNode.fPreviousSibling);
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

        public FHostSession fNextSibling
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

                    return new FHostSession(this.fTcdCore, this.fXmlNode.fNextSibling);
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
                        "../../../" + FXmlTagEQM.E_EquipmentModeling +
                        "/" + FXmlTagEQP.E_Equipment +
                        "/" + FXmlTagSNG.E_ScenarioGroup +
                        "/" + FXmlTagSNR.E_Scenario +
                        "/" + FXmlTagHTR.E_HostTrigger +
                        "/" + FXmlTagHCN.E_HostCondition + "[@" + FXmlTagHCN.A_HostSessionId + "='" + this.uniqueIdToString + "']" +
                        " | " +
                        "../../../" + FXmlTagEQM.E_EquipmentModeling +
                        "/" + FXmlTagEQP.E_Equipment +
                        "/" + FXmlTagSNG.E_ScenarioGroup +
                        "/" + FXmlTagSNR.E_Scenario +
                        "/" + FXmlTagHTN.E_HostTransmitter +
                        "/" + FXmlTagHTF.E_HostTransfer + "[@" + FXmlTagHTF.A_HostSessionId + "='" + this.uniqueIdToString + "']";
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
                string xpath = string.Empty;

                try
                {
                    xpath =
                    "../../../" + FXmlTagHLM.E_HostLibraryModeling +
                    "/" + FXmlTagHLG.E_HostLibraryGroup +
                    "/" + FXmlTagHLB.E_HostLibrary + "[@" + FXmlTagHLB.A_UniqueId + "='" + this.fLibrary.uniqueIdToString + "']";
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

        public bool hasLibrary
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagHSN.A_HostLibraryId, FXmlTagHSN.D_HostLibraryId) == string.Empty)
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
                    if(
                        this.fXmlNode.fParentNode == null ||
                        !FClipboard.containsData(FCbObjectFormat.HostSession)
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
                    if(!FClipboard.containsData(FCbObjectFormat.HostMessageList))
                    {
                        return false;
                    }
                    return hasLibrary;
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

            try
            {
                if (option == FStringOption.Default)
                {
                    info = this.name;
                }
                else
                {
                    info = this.name + " MachineID=[" + this.machineId + "] SessionID=[" + this.sessionId.ToString() + "]";
                    if (this.hasLibrary)
                    {
                        info += " Library=[" + this.fLibrary.name + "]";
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
            FHostSession fRefObject
            )
        {
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

                if (this.locked && !this.fParent.Equals(fRefObject.fParent))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0008, "Locked Object", "Parent"));
                }

                // --                

                this.replace(this.fTcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fTcdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

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

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void moveTo(
            FHostDevice fRefObject
            )
        {
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

                if (this.locked && !this.fParent.Equals(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0008, "Locked Object", "Parent"));
                }

                if (fRefObject.fChildHostSessionCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildHostSessionCollection[fRefObject.fChildHostSessionCollection.count - 1]))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "same localtion"));
                    }
                } 

                // --                

                this.replace(this.fTcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fTcdCore, fRefObject.fXmlNode.appendChild(this.fXmlNode));

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

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void setLibrary(
            FHostLibrary fHostLibrary
            )
        {
            string oldId = string.Empty;
            string newId = string.Empty;

            try
            {
                // ***
                // TCP Library 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fHostLibrary.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Library", "Modeling File"));
                }

                // ***
                // 이 Host Session 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Session", "Modeling File"));
                }

                // ***
                // Host Library와 Host Session의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fHostLibrary))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Host Library and the Host Session", "same"));
                }

                // --

                oldId = this.fXmlNode.get_attrVal(FXmlTagHSN.A_HostLibraryId, FXmlTagHSN.D_HostLibraryId);
                newId = fHostLibrary.uniqueIdToString;
                if (oldId == newId)
                {
                    return;
                }

                // --

                // ***
                // TCP Session에 이전에 설정된 TCP Library가 존재할 경우 Reset 한다.
                // ***
                if (oldId != string.Empty)
                {
                    resetLibrary(false);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagHSN.A_HostLibraryId, FXmlTagHSN.D_HostLibraryId, newId, true);
                fHostLibrary.lockObject();
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

        internal void resetLibrary(
            bool isModifyEvent
            )
        {
            FHostLibrary fHostLibrary = null;

            try
            {
                fHostLibrary = this.fLibrary;
                if (fHostLibrary == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagHSN.A_HostLibraryId, FXmlTagHSN.D_HostLibraryId, string.Empty, isModifyEvent);
                fHostLibrary.unlockObject();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostLibrary = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void resetLibrary(
            )
        {
            try
            {
                resetLibrary(true);
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
                resetLibrary(false);
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

                this.fXmlNode.set_attrVal(FXmlTagHSN.A_Locked, FXmlTagHSN.D_Locked, FBoolean.True, true);
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

                // ---

                // ***
                // Host Session이 Host Condition이나 Host Transfer에 사용되어 있을 경우 Unlock 작업을 취소한다.
                // ***
                xpath =
                    FXmlTagEQM.E_EquipmentModeling +
                    "/" + FXmlTagEQP.E_Equipment +
                    "/" + FXmlTagSNG.E_ScenarioGroup +
                    "/" + FXmlTagSNR.E_Scenario +
                    "/" + FXmlTagHTR.E_HostTrigger +
                    "/" + FXmlTagHCN.E_HostCondition + "[@" + FXmlTagHCN.A_HostSessionId + "='" + this.uniqueIdToString + "']" +
                    " | " +
                    FXmlTagEQM.E_EquipmentModeling +
                    "/" + FXmlTagEQP.E_Equipment +
                    "/" + FXmlTagSNG.E_ScenarioGroup +
                    "/" + FXmlTagSNR.E_Scenario +
                    "/" + FXmlTagHTN.E_HostTransmitter +
                    "/" + FXmlTagHTF.E_HostTransfer + "[@" + FXmlTagHTF.A_HostSessionId + "='" + this.uniqueIdToString + "']";
                // --
                if (this.fTcpDriver.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagHSN.A_Locked, FXmlTagHSN.D_Locked, FBoolean.False, true);
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
                this.copyObject(FCbObjectFormat.HostSession, this.fXmlNode);
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
                
                this.copyObject(FCbObjectFormat.HostSession, fXmlNode);
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

        public FHostSession pasteSibling(
            )
        {
            FHostSession fHostSession = null;

            try
            {
                FTcpDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.HostSession);

                // --

                fHostSession = (FHostSession)this.pasteObject(FCbObjectFormat.HostSession);
                fHostSession.fXmlNode.set_attrVal(FXmlTagHSN.A_HostLibraryId, FXmlTagHSN.D_HostLibraryId, "");
                return this.fParent.insertAfterChildHostSession(fHostSession, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostSession = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostMessageCollection selectHostMessageByName(
            string name
            )
        {
            const string xpath = FXmlTagHML.E_HostMessageList +
                "/" + FXmlTagHMS.E_HostMessages +
                "/" + FXmlTagHMG.E_HostMessage + "[@" + FXmlTagHMG.A_Name + "='{0}']";

            try
            {
                if (this.fLibrary == null)
                {
                    return null;
                }

                // --

                return new FHostMessageCollection(
                    this.fTcdCore,
                    this.fLibrary.fXmlNode.selectNodes(string.Format(xpath, name))
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
            const string xpath = FXmlTagHML.E_HostMessageList +
                "/" + FXmlTagHMS.E_HostMessages +
                "/" + FXmlTagHMG.E_HostMessage + "[@" + FXmlTagHMG.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                if (this.fLibrary == null)
                {
                    return null;
                }

                // --

                fXmlNode = this.fLibrary.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostMessage(this.fTcdCore, fXmlNode);
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
            const string xpath = FXmlTagHML.E_HostMessageList +
                "/" + FXmlTagHMS.E_HostMessages +
                "/" + FXmlTagHMG.E_HostMessage + "[@" + FXmlTagHMG.A_Command + "='{0}' and @" + FXmlTagHMG.A_Version + "='{1}' and @" + FXmlTagHMG.A_HostMessageType + "='{2}']";

            try
            {
                if (this.fLibrary == null)
                {
                    return null;
                }

                // --

                return new FHostMessageCollection(
                    this.fTcdCore,
                    this.fLibrary.fXmlNode.selectNodes(string.Format(xpath, command, version, hostMessageType))
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
            const string xpath = FXmlTagHML.E_HostMessageList +
               "/" + FXmlTagHMS.E_HostMessages +
               "/" + FXmlTagHMG.E_HostMessage + "[@" + FXmlTagHMG.A_Command + "='{0}' and @" + FXmlTagHMG.A_Version + "='{1}' and @" + FXmlTagHMG.A_HostMessageType + "='{2}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                if (this.fLibrary == null)
                {
                    return null;
                }

                // --

                fXmlNode = this.fLibrary.fXmlNode.selectSingleNode(string.Format(xpath, command, version, hostMessageType));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostMessage(this.fTcdCore, fXmlNode);
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
