/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsMessageTransfer.cs
--  Creator         : spike.lee
--  Create Date     : 2011.10.12
--  Description     : FAMate Core FaSecsDriver SECS Message Transfer Class
--  History         : Created by spike.lee at 2011.10.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FSecsMessageTransfer : FIObject, FIMessageTransfer, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FScdCore m_fScdCore = null;
        private FXmlNode m_fXmlNode = null;
        private bool m_hasSystemBytes = false;
        private UInt32 m_systemBytes = 0;
        private FRepositoryMaterial m_fRepositoryMaterial = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FSecsMessageTransfer(        
            FScdCore fScdCore,
            FXmlNode fXmlNode
            ) 
        {
            m_fScdCore = fScdCore;
            m_fXmlNode = fXmlNode;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FSecsMessageTransfer(
            FScdCore fScdCore,
            FXmlNode fXmlNode,
            UInt32 systemBytes
            )
            : this(fScdCore, fXmlNode)
        {
            m_systemBytes = systemBytes;
            m_hasSystemBytes = true;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsMessageTransfer(
            FSecsDriver fSecsDriver
            )
        {
            m_fScdCore = fSecsDriver.fScdCore;
            m_fXmlNode = FSecsDriverCommon.createXmlNodeSMT(m_fScdCore.fXmlDoc);
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsMessageTransfer(
            FSecsDriver fSecsDriver,
            UInt32 systemBytes
            )            
            : this (fSecsDriver)
        {
            m_systemBytes = systemBytes;
            m_hasSystemBytes = true;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsMessageTransfer(
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
                    m_fScdCore = null;
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
                    return FObjectType.SecsMessageTransfer;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.SecsMessageTransfer;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FMessageTransferType fMessageTransferType
        {
            get
            {
                try
                {
                    return FMessageTransferType.SecsMessageTransfer;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FMessageTransferType.SecsMessageTransfer;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FScdCore fScdCore
        {
            get
            {
                try
                {
                    return m_fScdCore;
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMT.A_UniqueId, FXmlTagSMT.D_UniqueId);
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
                    return m_fXmlNode.get_attrVal(FXmlTagSMT.A_Name, FXmlTagSMT.D_Name);
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

                    m_fXmlNode.set_attrVal(FXmlTagSMT.A_Name, FXmlTagSMT.D_Name, value);
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
                    return m_fXmlNode.get_attrVal(FXmlTagSMT.A_Description, FXmlTagSMT.D_Description);
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
                    m_fXmlNode.set_attrVal(FXmlTagSMT.A_Description, FXmlTagSMT.D_Description, value);
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
                    return Color.FromName(m_fXmlNode.get_attrVal(FXmlTagSMT.A_FontColor, FXmlTagSMT.D_FontColor));
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
                    m_fXmlNode.set_attrVal(FXmlTagSMT.A_FontColor, FXmlTagSMT.D_FontColor, value.Name);
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
                    return FBoolean.toBool(m_fXmlNode.get_attrVal(FXmlTagSMT.A_FontBold, FXmlTagSMT.D_FontBold));
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
                    m_fXmlNode.set_attrVal(FXmlTagSMT.A_FontBold, FXmlTagSMT.D_FontBold, FBoolean.fromBool(value));
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
                    return int.Parse(m_fXmlNode.get_attrVal(FXmlTagSMT.A_Stream, FXmlTagSMT.D_Stream));
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
                    if (value < 0 || value > 127)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Stream"));
                    }

                    // --

                    m_fXmlNode.set_attrVal(FXmlTagSMT.A_Stream, FXmlTagSMT.D_Stream, value.ToString());
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
                    return int.Parse(m_fXmlNode.get_attrVal(FXmlTagSMT.A_Function, FXmlTagSMT.D_Function));
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
                    if (value < 0 || value > 255)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Function"));
                    }

                    // --

                    if (value != 0 && value % 2 == 0)
                    {
                        // ***
                        // Secondary Message로 설정할 경우 WBit를 False로 설정한다.
                        // ***
                        m_fXmlNode.set_attrVal(FXmlTagSMT.A_WBit, FXmlTagSMT.D_WBit, FBoolean.False);
                    }                    
                    // --
                    m_fXmlNode.set_attrVal(FXmlTagSMT.A_Function, FXmlTagSMT.D_Function, value.ToString());
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
                    return int.Parse(m_fXmlNode.get_attrVal(FXmlTagSMT.A_Version, FXmlTagSMT.D_Version));
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

                    m_fXmlNode.set_attrVal(FXmlTagSMT.A_Version, FXmlTagSMT.D_Version, value.ToString());
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

        public bool wBit
        {
            get
            {
                int f = 0;

                try
                {
                    // ***
                    // Function이 0이거나 Primary Message일 경우에만 WBit 값을 반화하고 Secondary Message일 경우
                    // 항상 False를 반환한다.
                    // ***                    
                    f = this.function;
                    if (f != 0 && f % 2 == 0)
                    {
                        return false;
                    }
                    return FBoolean.toBool(m_fXmlNode.get_attrVal(FXmlTagSMT.A_WBit, FXmlTagSMT.D_WBit));
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
                int f = 0;

                try
                {
                    // ***
                    // Function이 0이거나 Primary Message일 경우에만 WBit 값을 설정할 수 있도록 한다.
                    // ***
                    f = this.function;
                    if (f != 0 && f % 2 == 0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "Secondary SECS Message", "W-Bit"));
                    }
                    
                    // --

                    m_fXmlNode.set_attrVal(FXmlTagSMT.A_WBit, FXmlTagSMT.D_WBit, FBoolean.fromBool(value));
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
                    return m_fXmlNode.get_attrVal(FXmlTagSMT.A_UserTag1, FXmlTagSMT.D_UserTag1);
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
                    m_fXmlNode.set_attrVal(FXmlTagSMT.A_UserTag1, FXmlTagSMT.D_UserTag1, value);
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
                    return m_fXmlNode.get_attrVal(FXmlTagSMT.A_UserTag2, FXmlTagSMT.D_UserTag2);
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
                    m_fXmlNode.set_attrVal(FXmlTagSMT.A_UserTag2, FXmlTagSMT.D_UserTag2, value);
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
                    return m_fXmlNode.get_attrVal(FXmlTagSMT.A_UserTag3, FXmlTagSMT.D_UserTag3);
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
                    m_fXmlNode.set_attrVal(FXmlTagSMT.A_UserTag3, FXmlTagSMT.D_UserTag3, value);
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
                    return m_fXmlNode.get_attrVal(FXmlTagSMT.A_UserTag4, FXmlTagSMT.D_UserTag4);
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
                    m_fXmlNode.set_attrVal(FXmlTagSMT.A_UserTag4, FXmlTagSMT.D_UserTag4, value);
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
                    return m_fXmlNode.get_attrVal(FXmlTagSMT.A_UserTag5, FXmlTagSMT.D_UserTag5);
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
                    m_fXmlNode.set_attrVal(FXmlTagSMT.A_UserTag5, FXmlTagSMT.D_UserTag5, value);
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
                    if (this.function == 0 || this.function % 2 == 1)
                    {
                        return true;
                    }
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
                    return m_fXmlNode.containsNode(FXmlTagSIT.E_SecsItem);
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
                    return !this.hasChild;
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
                    if (!FClipboard.containsData(FCbObjectFormat.SecsItem) || this.hasChild)
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

        public FSecsItemCollection fChildSecsItemCollection
        {
            get
            {
                try
                {
                    return new FSecsItemCollection(this.m_fScdCore, this.fXmlNode.selectNodes(FXmlTagSIT.E_SecsItem));
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
                    return new FObjectCollection(m_fScdCore, this.fXmlNode.selectNodes("NULL"));
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
                    return new FObjectCollection(m_fScdCore, this.fXmlNode.selectNodes("NULL"));
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

        internal bool hasSystemBytes
        {
            get
            {
                try
                {
                    return m_hasSystemBytes;
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

        public UInt32 systemBytes
        {
            get
            {
                try
                {
                    return m_systemBytes;
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
            FSecsSession fSecsSession
            )
        {
            try
            {
                m_fScdCore.fProtocolAgent.sendSecsMessageTransfer(fSecsSession, this);
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

        public FSecsItem appendChildSecsItem(
            FSecsItem fNewChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                // --
                if (this.hasChild)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0003, "SECS Item"));
                }

                // --

                fNewChild.replace(this.m_fScdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));                
                
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

        public FSecsItem appendChildSecsItem(
            FSecsDriver fSecsDriver,
            string name,
            FFormat fFormat,
            string stringValue
            )
        {
            try
            {
                return appendChildSecsItem(new FSecsItem(fSecsDriver, name, fFormat, stringValue));
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

        public FSecsItem removeChildSecsItem(
            FSecsItem fChild
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

        public void removeChildSecsItem(
            FSecsItem[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FSecsItem fSit in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode, fSit.fXmlNode);
                }

                // --

                foreach (FSecsItem fSit in fChilds)
                {
                    fSit.remove();
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

        public void removeAllChildSecsItem(
            )
        {
            FSecsItemCollection fSitCollection = null;

            try
            {
                fSitCollection = this.fChildSecsItemCollection;
                if (fSitCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FSecsItem fSit in fSitCollection)
                {
                    if (fSit.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FSecsItem fSit in fSitCollection)
                {
                    fSit.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fSitCollection != null)
                {
                    fSitCollection.Dispose();
                    fSitCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsItem pasteChild(
            )
        {
            FSecsItem fSecsItem = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.SecsItem);

                // --

                fSecsItem = this.pasteObject(FCbObjectFormat.SecsItem);
                return this.appendChildSecsItem(fSecsItem);                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsItem = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FSecsItem pasteObject(
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
                return (FSecsItem)FSecsDriverCommon.createObject(m_fScdCore, fXmlNode);
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

        public void setSystemBytes(
            UInt32 systemBytes
            )
        {
            try
            {
                m_systemBytes = systemBytes;
                m_hasSystemBytes = true;
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

        public FSecsItemCollection selectSecsItemByName(
            string name
            )
        {
            const string xpath = FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_Name + "='{0}']";

            try
            {
                return new FSecsItemCollection(
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

        public FSecsItem selectSingleSecsItemByName(
            string name
            )
        {
            const string xpath = FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItem(this.fScdCore, fXmlNode);
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

        public FSecsItemCollection selectAllSecsItemByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_Name + "='{0}']";

            try
            {
                return new FSecsItemCollection(
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

        public FSecsItem selectSingleAllSecsItemByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItem(this.fScdCore, fXmlNode);
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

        public FSecsItemCollection selectSecsItemByReservedWord(
            string reservedWord
            )
        {
            const string xpath = FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_ReservedWord + "='{0}']";

            try
            {
                return new FSecsItemCollection(
                    this.fScdCore,
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

        public FSecsItem selectSingleSecsItemByReservedWord(
            string reservedWord
            )
        {
            const string xpath = FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_ReservedWord + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, reservedWord));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItem(this.fScdCore, fXmlNode);
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

        public FSecsItemCollection selectAllSecsItemByReservedWord(
            string reservedWord
            )
        {
            const string xpath = ".//" + FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_ReservedWord + "='{0}']";

            try
            {
                return new FSecsItemCollection(
                    this.fScdCore,
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

        public FSecsItem selectSingleAllSecsItemByReservedWord(
            string reservedWord
            )
        {
            const string xpath = ".//" + FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_ReservedWord + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, reservedWord));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItem(this.fScdCore, fXmlNode);
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

        public FSecsItemCollection selectSecsItemByExtraction(
            )
        {
            const string xpath = FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_Extraction + "='{0}']";

            try
            {
                return new FSecsItemCollection(
                    this.fScdCore,
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

        public FSecsItem selectSingleSecsItemByExtraction(
            )
        {
            const string xpath = FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_Extraction + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, FBoolean.True));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItem(this.fScdCore, fXmlNode);
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

        public FSecsItemCollection selectAllSecsItemByExtraction(
            )
        {
            const string xpath = ".//" + FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_Extraction + "='{0}']";

            try
            {
                return new FSecsItemCollection(
                    this.fScdCore,
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

        public FSecsItem selectAllSingleSecsItemByExtraction(
            )
        {
            const string xpath = ".//" + FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_Extraction + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, FBoolean.True));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItem(this.fScdCore, fXmlNode);
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

        public FSecsItem selectSingleAllSecsItemByIndex(
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
                return new FSecsItem(this.fScdCore, fXmlNode);
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
