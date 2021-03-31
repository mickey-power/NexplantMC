/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHostMessageTransfer.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.16
--  Description     : FAMate Core FaPlcDriver Host Message Transfer Class
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
    public class FHostMessageTransfer : FIObject, FIMessageTransfer, IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FPcdCore m_fPcdCore = null;
        private FXmlNode m_fXmlNode = null;
        private bool m_hasTid = false;        
        private UInt32 m_tid = 0;
        private FRepositoryMaterial m_fRepositoryMaterial = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FHostMessageTransfer(
            FPcdCore fPcdCore,
            FXmlNode fXmlNode
            )
        {
            m_fPcdCore = fPcdCore;
            m_fXmlNode = fXmlNode;
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        internal FHostMessageTransfer(
            FPcdCore fPcdCore,
            FXmlNode fXmlNode,            
            UInt32 tid
            )
            : this(fPcdCore, fXmlNode)
        {
            m_tid = tid;
            m_hasTid = true;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostMessageTransfer(
            FPlcDriver fPlcDriver
            )
        {
            m_fPcdCore = fPlcDriver.fPcdCore;
            m_fXmlNode = FPlcDriverCommon.createXmlNodeHMT(m_fPcdCore.fXmlDoc);
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostMessageTransfer(
            FPlcDriver fPlcDriver,
            UInt32 systemBytes
            )
            : this(fPlcDriver)
        {
            m_tid = systemBytes;
            m_hasTid = true;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHostMessageTransfer(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_fPcdCore = null;
                    m_fXmlNode = null;
                    m_fRepositoryMaterial = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region IDisposable 멤버

        public void Dispose(
            )
        {
            myDispose(true);
            GC.SuppressFinalize(this);
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
                    return FObjectType.HostMessageTransfer;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.HostMessageTransfer;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FMessageTransferType fMessageTransferType
        {
            get
            {
                try
                {
                    return FMessageTransferType.HostMessageTransfer;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FMessageTransferType.HostMessageTransfer;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FXmlNode fXmlNode
        {
            get
            {
                try
                {
                    return m_fXmlNode;
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

            set
            {
                try
                {
                    m_fXmlNode = value;
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

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHMT.A_UniqueId, FXmlTagHMT.D_UniqueId);
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
                    return m_fXmlNode.get_attrVal(FXmlTagHMT.A_Name, FXmlTagHMT.D_Name);
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

                    m_fXmlNode.set_attrVal(FXmlTagHMT.A_Name, FXmlTagHMT.D_Name, value);
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
                    return m_fXmlNode.get_attrVal(FXmlTagHMT.A_Description, FXmlTagHMT.D_Description);
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
                    m_fXmlNode.set_attrVal(FXmlTagHMT.A_Description, FXmlTagHMT.D_Description, value);
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
                    return Color.FromName(m_fXmlNode.get_attrVal(FXmlTagHMT.A_FontColor, FXmlTagHMT.D_FontColor));
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
                    m_fXmlNode.set_attrVal(FXmlTagHMT.A_FontColor, FXmlTagHMT.D_FontColor, value.Name);
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
                    return FBoolean.toBool(m_fXmlNode.get_attrVal(FXmlTagHMT.A_FontBold, FXmlTagHMT.D_FontBold));
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
                    m_fXmlNode.set_attrVal(FXmlTagHMT.A_FontBold, FXmlTagHMT.D_FontBold, FBoolean.fromBool(value));
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
        // 2016.06.08 Jungyoul (WISOL)
        // ***
        public string equipmentName
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHMT.A_EquipmentName, FXmlTagHMT.D_EquipmentName);
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
                    this.fXmlNode.set_attrVal(FXmlTagHMT.A_EquipmentName, FXmlTagHMT.D_EquipmentName, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHMT.A_Command, FXmlTagHMT.D_Command);
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
                    this.fXmlNode.set_attrVal(FXmlTagHMT.A_Command, FXmlTagHMT.D_Command, value, true);
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
                    return int.Parse(m_fXmlNode.get_attrVal(FXmlTagHMT.A_Version, FXmlTagHMT.D_Version));
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
                    if (value < 0 || value > 65535)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Version"));
                    }

                    // --

                    m_fXmlNode.set_attrVal(FXmlTagHMT.A_Version, FXmlTagHMT.D_Version, value.ToString());
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

        public FHostMessageType fHostMessageType
        {
            get
            {
                try
                {
                    return FEnumConverter.toHostMessageType(this.fXmlNode.get_attrVal(FXmlTagHMT.A_HostMessageType, FXmlTagHMT.D_HostMessageType));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FHostMessageType.Command;
            }

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagHMT.A_HostMessageType, FXmlTagHMT.D_HostMessageType, FEnumConverter.fromHostMessageType(value));                    
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

        public bool multiCastMessage
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHMT.A_MultiCastMessage, FXmlTagHMT.D_MultiCastMessage));
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
                    this.fXmlNode.set_attrVal(FXmlTagHMT.A_MultiCastMessage, FXmlTagHMT.D_MultiCastMessage, FBoolean.fromBool(value), true);
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

        public bool guaranteedMessage
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHMT.A_GuaranteedMessage, FXmlTagHMT.D_GuaranteedMessage));
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
                    this.fXmlNode.set_attrVal(FXmlTagHMT.A_GuaranteedMessage, FXmlTagHMT.D_GuaranteedMessage, FBoolean.fromBool(value), true);
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
                    return m_fXmlNode.get_attrVal(FXmlTagHMT.A_UserTag1, FXmlTagHMT.D_UserTag1);
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
                    m_fXmlNode.set_attrVal(FXmlTagHMT.A_UserTag1, FXmlTagHMT.D_UserTag1, value);
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
                    return m_fXmlNode.get_attrVal(FXmlTagHMT.A_UserTag2, FXmlTagHMT.D_UserTag2);
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
                    m_fXmlNode.set_attrVal(FXmlTagHMT.A_UserTag2, FXmlTagHMT.D_UserTag2, value);
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
                    return m_fXmlNode.get_attrVal(FXmlTagHMT.A_UserTag3, FXmlTagHMT.D_UserTag3);
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
                    m_fXmlNode.set_attrVal(FXmlTagHMT.A_UserTag3, FXmlTagHMT.D_UserTag3, value);
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
                    return m_fXmlNode.get_attrVal(FXmlTagHMT.A_UserTag4, FXmlTagHMT.D_UserTag4);
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
                    m_fXmlNode.set_attrVal(FXmlTagHMT.A_UserTag4, FXmlTagHMT.D_UserTag4, value);
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
                    return m_fXmlNode.get_attrVal(FXmlTagHMT.A_UserTag5,FXmlTagHMT.D_UserTag5);
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
                    m_fXmlNode.set_attrVal(FXmlTagHMT.A_UserTag5, FXmlTagHMT.D_UserTag5, value);
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
                    return this.fHostMessageType == FHostMessageType.Reply ? false : true;
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

        public bool hasChild
        {
            get
            {
                try
                {
                    return m_fXmlNode.containsNode(FXmlTagHIT.E_HostItem);
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
                    xpath = FXmlTagHIT.E_HostItem + "[@" + FXmlTagHIT.A_Pattern + "='" + FEnumConverter.fromPattern(FPattern.Fixed) + "']";
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
                    xpath = FXmlTagHIT.E_HostItem + "[@" + FXmlTagHIT.A_Pattern + "='" + FEnumConverter.fromPattern(FPattern.Variable) + "']";
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

        public bool canInsertAfter
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

        public bool canRemove
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

        public bool canCut
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

        public bool canCopy
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
                    if (!FClipboard.containsData(FCbObjectFormat.HostItem))
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

        public FHostItemCollection fChildHostItemCollection
        {
            get
            {
                try
                {
                    return new FHostItemCollection(this.m_fPcdCore, this.fXmlNode.selectNodes(FXmlTagHIT.E_HostItem));
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
                    return null;
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
                    return new FObjectCollection(m_fPcdCore, this.fXmlNode.selectNodes("NULL"));
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
                    return new FObjectCollection(m_fPcdCore, this.fXmlNode.selectNodes("NULL"));
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

        internal bool hasTid
        {
            get
            {
                try
                {
                    return m_hasTid;
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

        public UInt32 tid
        {
            get
            {
                try
                {
                    return m_tid;
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

        internal FRepositoryMaterial fRepositoryMaterial
        {
            get
            {
                try
                {
                    return m_fRepositoryMaterial;
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

            set
            {
                try
                {
                    m_fRepositoryMaterial = value;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public void send(
            FHostSession fHostSession
            )
        {
            try
            {
                m_fPcdCore.fProtocolAgent.sendHostMessageTransfer(fHostSession, this);
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

        public FHostItem appendChildHostItem(
            FHostItem fNewChild
            )
        {
            try
            {
                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);                

                // --

                fNewChild.replace(this.m_fPcdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));

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

        public FHostItem appendChildHostItem(
            FPlcDriver fPlcDriver,
            string name,
            FFormat fFormat,
            string stringValue
            )
        {
            try
            {
                return appendChildHostItem(new FHostItem(fPlcDriver, name, fFormat, stringValue));
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

        public FHostItem insertBeforeChildHostItem(
            FHostItem fNewChild,
            FHostItem fRefChild
            )
        {
            try
            {
                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.m_fPcdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));

                // --                

                if (
                    (fNewChild.fPreviousSibling != null && fNewChild.fPreviousSibling.fPattern == FPattern.Variable) &&
                    (fNewChild.fNextSibling != null && fNewChild.fNextSibling.fPattern == FPattern.Variable)
                    )
                {
                    fNewChild.fXmlNode.set_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Variable));
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

        public FHostItem insertAfterChildHostItem(
            FHostItem fNewChild,
            FHostItem fRefChild
            )
        {
            try
            {
                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // --

                fNewChild.replace(m_fPcdCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));

                // --                

                if (
                    (fNewChild.fPreviousSibling != null && fNewChild.fPreviousSibling.fPattern == FPattern.Variable) &&
                    (fNewChild.fNextSibling != null && fNewChild.fNextSibling.fPattern == FPattern.Variable)
                    )
                {
                    fNewChild.fXmlNode.set_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Variable));
                }

                //--

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

        public FHostItem removeChildHostItem(
            FHostItem fChild
            )
        {
            try
            {
                FPlcDriverCommon.validateRemoveChildObject(this.fXmlNode, fChild.fXmlNode);

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

        public void removeChildHostItem(
            FHostItem[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FHostItem fHit in fChilds)
                {
                    FPlcDriverCommon.validateRemoveChildObject(this.fXmlNode, fHit.fXmlNode);                    
                    // --
                    if (fHit.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FHostItem fHit in fChilds)
                {
                    fHit.remove();
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

        public void removeAllChildHostItem(
            )
        {
            FHostItemCollection fHitCollection = null;

            try
            {
                fHitCollection = this.fChildHostItemCollection;
                if (fHitCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FHostItem fHit in fHitCollection)
                {
                    if (fHit.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FHostItem fHit in fHitCollection)
                {
                    fHit.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fHitCollection != null)
                {
                    fHitCollection.Dispose();
                    fHitCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostItem pasteChild(
            )
        {
            FHostItem fHostItem = null;

            try
            {
                FPlcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.HostItem);

                // --

                fHostItem = (FHostItem)this.pasteObject(FCbObjectFormat.HostItem);
                return this.appendChildHostItem(fHostItem);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostItem = null;
            }
            return null;


        }

        //------------------------------------------------------------------------------------------------------------------------

        private FHostItem pasteObject(
            string format
            )
        {
            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlNode = null;
            
            try
            {
                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;
                fXmlDoc.loadXml(FClipboard.getStringData(format));
                fXmlNode = fXmlDoc.fFirstChild.clone(true);
                // --
                return (FHostItem)FPlcDriverCommon.createObject(m_fPcdCore, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlDoc = null;
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void setTid(
            UInt32 tid
            )
        {
            try
            {
                m_tid = tid;
                m_hasTid = true;
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
