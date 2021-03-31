/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_HostDevice.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.15
--  Description     : FAMate Core FaOpcDriver Host Device Class 
--  History         : Created by Jeff.Kim at 2013.07.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public class FHostDevice : FBaseObject<FHostDevice>, FIObject, FIDevice
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHostDevice(
            FOpcDriver fOpcDriver
            )
            : base(fOpcDriver.fOcdCore, FOpcDriverCommon.createXmlNodeHDV(fOpcDriver.fOcdCore.fXmlDoc))
        {
            // init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FHostDevice(
            FOcdCore fOpcCore,
            FXmlNode fXmlNode
            )
            : base(fOpcCore, fXmlNode)
        {
            // init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHostDevice(
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
                    // term();
                }

                term();
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
                    return FObjectType.HostDevice;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                }
                return FObjectType.HostDevice;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDeviceType fDeviceType
        {
            get
            {
                try
                {
                    return FDeviceType.HostDevice;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                }
                return FDeviceType.HostDevice;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHDV.A_UniqueId, FXmlTagHDV.D_UniqueId);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHDV.A_Locked, FXmlTagHDV.D_Locked));
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
                    return this.fXmlNode.getIndex(false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHDV.A_Name, FXmlTagHDV.D_Name);
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

                    this.fXmlNode.set_attrVal(FXmlTagHDV.A_Name, FXmlTagHDV.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHDV.A_Description, FXmlTagHDV.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagHDV.A_Description, FXmlTagHDV.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagHDV.A_FontColor, FXmlTagHDV.D_FontColor));
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
                {
                    try
                    {
                        this.fXmlNode.set_attrVal(FXmlTagHDV.A_FontColor, FXmlTagHDV.D_FontColor, value.Name, true);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool fontBold
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHDV.A_FontBold, FXmlTagHDV.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagHDV.A_FontBold, FXmlTagHDV.D_FontBold, FBoolean.fromBool(value), true);
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

        public FDeviceMode fDeviceMode
        {
            get
            {
                try
                {
                    return (FDeviceMode)Enum.Parse(typeof(FDeviceMode), this.fXmlNode.get_attrVal(FXmlTagHDV.A_Mode, FXmlTagHDV.D_Mode));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDeviceMode.Both;
            }

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagHDV.A_Mode, FXmlTagHDV.D_Mode, value.ToString(), true);
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

        public string driver
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHDV.A_Driver, FXmlTagHDV.D_Driver);
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

        public string driverDescription
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHDV.A_DriverDescription, FXmlTagHDV.D_DriverDescription);
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

        public string driverOption
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHDV.A_DriverOption, FXmlTagHDV.D_DriverOption);
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
                FBaseProtocol fBaseProtocol = null;

                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagHDV.A_DriverOption, FXmlTagHDV.D_DriverOption, value, true);
                    
                    // --  

                    if (this.isModelingObject)
                    {
                        fBaseProtocol = this.fOcdCore.fProtocolAgent.getProtocol(this.uniqueId);
                        if (fBaseProtocol != null)
                        {
                            ((FHostProtocol)fBaseProtocol).setDriverOption();
                        }
                    }
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    fBaseProtocol = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int transactionTimeout
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagHDV.A_TransactionTimeout, FXmlTagHDV.D_TransactionTimeout));
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
                    if (value < 1 || value > 120)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Transaction Timeout"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagHDV.A_TransactionTimeout, FXmlTagHDV.D_TransactionTimeout, value.ToString(), true);
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

        public string userTag1
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHDV.A_UserTag1, FXmlTagHDV.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagHDV.A_UserTag1, FXmlTagHDV.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHDV.A_UserTag2, FXmlTagHDV.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagHDV.A_UserTag2, FXmlTagHDV.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHDV.A_UserTag3, FXmlTagHDV.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagHDV.A_UserTag3, FXmlTagHDV.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHDV.A_UserTag4, FXmlTagHDV.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagHDV.A_UserTag4, FXmlTagHDV.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHDV.A_UserTag5, FXmlTagHDV.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagHDV.A_UserTag5, FXmlTagHDV.D_UserTag5, value, true);
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
                catch(Exception ex)
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

        public FOpcDriver fParent
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

                    return this.fOpcDriver;
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

        public FHostDevice fPreviousSibling
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

                    return new FHostDevice(this.fOcdCore, this.fXmlNode.fPreviousSibling);
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

        public FHostDevice fNextSibling
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

                    return new FHostDevice(this.fOcdCore, this.fXmlNode.fNextSibling);
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

        public FHostSessionCollection fChildHostSessionCollection
        {
            get
            {
                try
                {
                    return new FHostSessionCollection(this.fOcdCore, this.fXmlNode.selectNodes(FXmlTagHSN.E_HostSession));
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
                        "../../" + FXmlTagEQM.E_EquipmentModeling +
                        "/" + FXmlTagEQP.E_Equipment +
                        "/" + FXmlTagSNG.E_ScenarioGroup +
                        "/" + FXmlTagSNR.E_Scenario +
                        "/" + FXmlTagHTR.E_HostTrigger +
                        "/" + FXmlTagHCN.E_HostCondition + "[@" + FXmlTagHCN.A_HostDeviceId + "='" + this.uniqueIdToString + "']" +
                        " | " +
                        "../../" + FXmlTagEQM.E_EquipmentModeling +
                        "/" + FXmlTagEQP.E_Equipment +
                        "/" + FXmlTagSNG.E_ScenarioGroup +
                        "/" + FXmlTagSNR.E_Scenario +
                        "/" + FXmlTagHTN.E_HostTransmitter +
                        "/" + FXmlTagHTF.E_HostTransfer + "[@" + FXmlTagHTF.A_HostDeviceId + "='" + this.uniqueIdToString + "']";
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
                    return this.fXmlNode.containsNode(FXmlTagHSN.E_HostSession);
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

        public bool hasDriver
        {
            get
            {
                try
                {
                    return this.driver == string.Empty ? false : true;
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
                        !FClipboard.containsData(FCbObjectFormat.HostDevice)
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
                    if (!FClipboard.containsData(FCbObjectFormat.HostSession))
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

        public FDeviceState fState
        {
            get
            {
                try
                {
                    return FEnumConverter.toDeviceState(this.fXmlNode.get_attrVal(FXmlTagHDV.A_State, FXmlTagHDV.D_State));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDeviceState.Closed;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Method

        internal void init(
            )
        {
            try
            {
                this.fOcdCore.ModelingFileChanged += new FModelingFileChangedEventHandler(fOcdCore_ModelingFileChanged);
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

        internal void term(
            )
        {
            try
            {
                this.fOcdCore.ModelingFileChanged -= new FModelingFileChangedEventHandler(fOcdCore_ModelingFileChanged);
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
                    info = this.name + " Driver=[" + this.driver + "]";
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

        public FHostSession appendChildHostSession(
            FHostSession fNewChild
            )
        {
            try
            {
                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

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

        public FHostSession insertBeforeChildHostSession(
            FHostSession fNewChild,
            FHostSession fRefChild
            )
        {
            try
            {
                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                // --                
                if (this.isModelingObject)
                {
                    FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this.fOpcDriver, this, fNewChild)
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

        public FHostSession insertAfterChildHostSession(
            FHostSession fNewChild,
            FHostSession fRefChild
            )
        {
            try
            {
                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                // --                
                if (this.isModelingObject)
                {
                    FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this.fOpcDriver, this, fNewChild)
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

        public FHostSession removeChildHostSession(
            FHostSession fChild
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

        public void removeChildHostSession(
            FHostSession[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FHostSession fHsn in fChilds)
                {
                    FOpcDriverCommon.validateRemoveChildObject(this.fXmlNode, fHsn.fXmlNode);
                }

                // --

                foreach (FHostSession fHsn in fChilds)
                {
                    fHsn.remove();
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

        public void removeAllChildHostSession(
            )
        {
            FHostSessionCollection fHsnCollection = null;

            try
            {
                fHsnCollection = this.fChildHostSessionCollection;
                if (fHsnCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FHostSession fHsn in fHsnCollection)
                {
                    if (fHsn.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FHostSession fHsn in fHsnCollection)
                {
                    fHsn.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fHsnCollection != null)
                {
                    fHsnCollection.Dispose();
                    fHsnCollection = null;
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
            FHostDevice fRefObject
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

        public void setHostDriver(
            string fileName
            )
        {
            string driver = string.Empty;
            FIHostDriver fHostDriver = null;            

            try
            {
                // ***
                // 이 Host Device 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Device", "Modeling File"));
                }

                // --

                driver = System.IO.Path.GetFileName(fileName);
                if (this.driver == driver)
                {
                    return;
                }
                
                // --
                
                fHostDriver = createHostDriver(fileName);
                if (fHostDriver == null)
                {
                    this.resetHostDriver();
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagHDV.A_DriverDescription, FXmlTagHDV.D_DriverDescription, fHostDriver.description);
                this.fXmlNode.set_attrVal(FXmlTagHDV.A_DriverOption, FXmlTagHDV.D_DriverOption, fHostDriver.option.toString());
                this.fXmlNode.set_attrVal(FXmlTagHDV.A_Driver, FXmlTagHDV.D_Driver, driver, true);                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostDriver = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void resetHostDriver(
            bool isModifyEvent
            )
        {
            try
            {
                if (this.driver == string.Empty)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagHDV.A_DriverDescription, FXmlTagHDV.D_DriverDescription, string.Empty);
                this.fXmlNode.set_attrVal(FXmlTagHDV.A_DriverOption, FXmlTagHDV.D_DriverOption, string.Empty);
                this.fXmlNode.set_attrVal(FXmlTagHDV.A_Driver, FXmlTagHDV.D_Driver, string.Empty, isModifyEvent);
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

        public void resetHostDriver(
            )
        {
            try
            {
                resetHostDriver(true);
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
                resetHostDriver(false);

                // --

                foreach (FHostSession fHsn in this.fChildHostSessionCollection)
                {
                    fHsn.resetRelation();
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

        public FIHostDriver createHostDriver(
            string fileName
            )
        {
            try
            {
                if (!this.isModelingObject)
                {
                    return null;
                }

                // --

#if DEBUG
                return (FIHostDriver)FReflection.createInstance(
                    fileName,
                    FConstants.HostDriverName,
                    new object[] { new FHostDriverArgs(this.fOpcDriver, this) }
                );

#else 
                return (FIHostDriver)FReflection.createInstanceInMemory(
                    fileName,
                    FConstants.HostDriverName,
                    new object[] { new FHostDriverArgs(this.fOpcDriver, this) }
                    );

#endif
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

        public FIHostDriver createHostDriver(
            )
        {
            try
            {
                if (!this.isModelingObject || this.driver == string.Empty)
                {
                    return null;
                }
                // --
                return createHostDriver(this.fOpcDriver.hostDriverDirectory + "//" + this.driver);
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

        public FIHostDriverOption createHostDriverOption(
            string fileName
            )
        {
            FIHostDriver fHostDriver = null;

            try
            {
                fHostDriver = createHostDriver(fileName);
                if (fHostDriver == null)
                {
                    this.resetHostDriver();
                    FDebug.throwFException(FConstants.err_m_0040);
                }
                // --
                return fHostDriver.option;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostDriver = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIHostDriverOption createHostDriverOption(
            )
        {
            FIHostDriver fHostDriver = null;

            try
            {
                fHostDriver = createHostDriver();
                if (fHostDriver == null)
                {
                    this.resetHostDriver();
                    FDebug.throwFException(FConstants.err_m_0040);
                }
                // --
                return fHostDriver.option;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostDriver = null;
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

                this.fXmlNode.set_attrVal(FXmlTagHDV.A_Locked, FXmlTagHDV.D_Locked, FBoolean.True, true);
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
                // Lock이 설정된 자식 Host Session이 존재할 경우 Unlock 작업을 취소한다.
                // ***
                xpath = FXmlTagHSN.E_HostSession + "[@" + FXmlTagHSN.A_Locked + "='" + FBoolean.True + "']" +
                    " | " +
                    "../../" + FXmlTagEQM.E_EquipmentModeling +
                    "/" + FXmlTagEQP.E_Equipment +
                    "/" + FXmlTagSNG.E_ScenarioGroup +
                    "/" + FXmlTagSNR.E_Scenario +
                    "/" + FXmlTagHTR.E_HostTrigger +
                    "/" + FXmlTagHCN.E_HostCondition + "[@" + FXmlTagHCN.A_HostDeviceId + "='" + this.uniqueIdToString + "']";
                // --
                if (this.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagHDV.A_Locked, FXmlTagHDV.D_Locked, FBoolean.False, true);
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

        public void open(
            )
        {
            try
            {
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Device", "Modeling File"));
                }

                // --

                if (this.fState != FDeviceState.Closed)
                {
                    return;
                }

                // --

                this.fOcdCore.fProtocolAgent.openHostDevice(this);
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

        public void close(
            )
        {
            try
            {
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Device", "Modeling File"));
                }

                // --

                if (this.fState == FDeviceState.Closed)
                {
                    return;
                }

                // --

                this.fOcdCore.fProtocolAgent.closeHostDevice(this);
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

        internal void changeState(
            FDeviceState fState
            )
        {
            try
            {
                if (this.fState == fState)
                {
                    return;
                }
                this.fXmlNode.set_attrVal(FXmlTagHDV.A_State, FXmlTagHDV.D_State, FEnumConverter.fromDeviceState(fState));
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
                this.copyObject(FCbObjectFormat.HostDevice, this.fXmlNode);
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

                this.copyObject(FCbObjectFormat.HostDevice, fXmlNode);
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

        public FHostDevice pasteSibling(
            )
        {
            FHostDevice fHostDevice = null;

            try
            {
                FOpcDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.HostDevice);

                // --

                fHostDevice = (FHostDevice)this.pasteObject(FCbObjectFormat.HostDevice);
                // --
                fHostDevice.changeState(FDeviceState.Closed);
                // --
                foreach (FHostSession fHsn in fHostDevice.fChildHostSessionCollection)
                {
                    fHsn.fXmlNode.set_attrVal(FXmlTagHSN.A_HostLibraryId, FXmlTagHSN.D_HostLibraryId, "");
                }
                return this.fParent.insertAfterChildHostDevice(fHostDevice, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostDevice = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostSession pasteChild(
            )
        {
            FHostSession fHostSession = null;

            try
            {
                FOpcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.HostSession);
                
                // --

                fHostSession = (FHostSession)this.pasteObject(FCbObjectFormat.HostSession);                
                fHostSession.fXmlNode.set_attrVal(FXmlTagHSN.A_HostLibraryId, FXmlTagHSN.D_HostLibraryId, "");
                return this.appendChildHostSession(fHostSession);
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

        public FHostSessionCollection selectHostSessionByName(
            string name
            )
        {
            const string xpath = FXmlTagHSN.E_HostSession + "[@" + FXmlTagHSN.A_Name + "='{0}']";

            try
            {
                return new FHostSessionCollection(
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

        public FHostSession selectSingleHostSessionByName(
            string name
            )
        {
            const string xpath = FXmlTagHSN.E_HostSession + "[@" + FXmlTagHSN.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostSession(this.fOcdCore, fXmlNode);
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

        #region fOcdCore Object Event Handler

        private void fOcdCore_ModelingFileChanged(
            object sender, 
            FModelingFileChangedEventArgs e
            )
        {
            const string xpath =
                FXmlTagHDM.E_HostDeviceModeling +
                "/" + FXmlTagHDV.E_HostDevice + "[@" + FXmlTagHDV.A_UniqueId + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fOcdCore.fXmlNodeOcd.selectSingleNode(string.Format(xpath, this.uniqueIdToString));
                fXmlNode.set_attrVal(FXmlTagHDV.A_State, FXmlTagHDV.D_State, FEnumConverter.fromDeviceState(this.fState)); // 기존 상태 유지

                // --

                this.replace(this.fOcdCore, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fXmlNode = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
