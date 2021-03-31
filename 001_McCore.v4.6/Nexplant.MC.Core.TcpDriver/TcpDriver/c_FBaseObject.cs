/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FBaseObject.cs
--  Creator         : spike.lee
--  Create Date     : 2013.07.10
--  Description     : FAMate Core FaTcpDriver Base Object Class 
--  History         : Created by spike.lee at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public abstract class FBaseObject<T> : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcdCore m_fTcdCore = null;
        private FXmlNode m_fXmlNode = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        // ***
        // 2014.02.03 by spike.lee
        // TCP Driver 생성에 사용
        // ***
        internal FBaseObject(
            string licFileName
            )
        {
            validateLicense(licFileName);           

            // --

            // ***
            // FTcpDriver 생성자 Only
            // ***
            m_fTcdCore = new FTcdCore();
            m_fXmlNode = m_fTcdCore.fXmlNodeTcd;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // TCP Driver reopenModelingFile Method에서 사용
        // ***
        internal FBaseObject(                 
            )
        {
            // ***
            // FTcpDriver 생성자 Only
            // ***
            m_fTcdCore = new FTcdCore();
            m_fXmlNode = m_fTcdCore.fXmlNodeTcd;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // TCP Driver Clone에 사용
        // ***
        internal FBaseObject(
            FXmlDocument fXmlDoc
            )
        {
            // ***
            // TCP Driver Clone 전용
            // ***
            m_fTcdCore = new FTcdCore(fXmlDoc);
            m_fXmlNode = m_fTcdCore.fXmlNodeTcd;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // TCP Driver Instance 복사에 사용
        // ***
        internal FBaseObject(
            FTcdCore fTcdCore, 
            FXmlNode fXmlNode
            )            
        {
            m_fTcdCore = fTcdCore;
            m_fXmlNode = fXmlNode;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // TCP Object Instance 복사에 사용
        // ***
        internal FBaseObject(                        
            FXmlNode fXmlNode
            )
        {
            m_fXmlNode = fXmlNode;
            // --
            init();
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        ~FBaseObject(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    term();

                    // --

                    if (this is FTcpDriver && m_fTcdCore != null)
                    {
                        m_fTcdCore.Dispose();
                    }
                    m_fTcdCore = null;

                    // --

                    if (m_fXmlNode != null)
                    {
                        m_fXmlNode.Dispose();
                        m_fXmlNode = null;
                    }
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

        internal FTcdCore fTcdCore
        {
            get
            {
                try
                {
                    return m_fTcdCore;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FTcpDriver fTcpDriver
        {
            get
            {
                try
                {
                    return m_fTcdCore.fTcpDriver;
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
                    m_fTcdCore.fTcpDriver = value;
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

        public bool isModelingObject
        {
            get
            {
                FXmlNode fXmlNodeParent = null;

                try
                {
                    fXmlNodeParent = this.fXmlNode.fParentNode;
                    while (fXmlNodeParent != null)
                    {
                        if (fXmlNodeParent.name == FXmlTagFAM.E_FAMate)
                        {
                            return true;
                        }
                        fXmlNodeParent = fXmlNodeParent.fParentNode;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    if (fXmlNodeParent != null)
                    {
                        fXmlNodeParent.Dispose();
                        fXmlNodeParent = null;
                    }
                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool removed
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null)
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

        internal FObjectNameCollection getObjectNameCollection(
            )
        {
            string xpath = string.Empty;

            try
            {
                if (this.isModelingObject)
                {
                    xpath =
                        FXmlTagSET.E_Setup + "/" +
                        FXmlTagOND.E_ObjectNameDefinition + "/" +
                        FXmlTagONL.E_ObjectNameList + "[@" + FXmlTagONL.A_ObjectType + "='" + FTcpDriverCommon.getObjectType(m_fXmlNode).ToString() + "']/" +
                        FXmlTagONA.E_ObjectName;
                }
                else
                {
                    xpath = "NULL"; // 개수가 0인 Node List 생성
                }
                // --
                return new FObjectNameCollection(m_fTcdCore, this.fTcpDriver.fXmlNode.selectNodes(xpath));
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

        internal string getDefUserTagName(
            int userTagNo
            )
        {
            FXmlNode fXmlNodeUtn = null;
            string xpath = string.Empty;
            string attrName = string.Empty;
            string defValue = string.Empty;
            string userTagName = string.Empty;

            try
            {
                if (this.isModelingObject)
                {
                    xpath =
                        FXmlTagSET.E_Setup + "/" +
                        FXmlTagUTD.E_UserTagNameDefinition + "/" +
                        FXmlTagUTN.E_UserTagName + "[@" + FXmlTagUTN.A_ObjectType + "='" + FTcpDriverCommon.getObjectType(m_fXmlNode).ToString() + "']";
                    fXmlNodeUtn = this.fTcpDriver.fXmlNode.selectSingleNode(xpath);

                    // --

                    if (fXmlNodeUtn != null)
                    {
                        if (userTagNo == 1)
                        {
                            attrName = FXmlTagUTN.A_UserTagName1;
                            defValue = FXmlTagUTN.D_UserTagName1;
                        }
                        else if (userTagNo == 2)
                        {
                            attrName = FXmlTagUTN.A_UserTagName2;
                            defValue = FXmlTagUTN.D_UserTagName2;
                        }
                        else if (userTagNo == 3)
                        {
                            attrName = FXmlTagUTN.A_UserTagName3;
                            defValue = FXmlTagUTN.D_UserTagName3;
                        }
                        else if (userTagNo == 4)
                        {
                            attrName = FXmlTagUTN.A_UserTagName4;
                            defValue = FXmlTagUTN.D_UserTagName4;
                        }
                        else
                        {
                            attrName = FXmlTagUTN.A_UserTagName5;
                            defValue = FXmlTagUTN.D_UserTagName5;
                        }
                        // --
                        userTagName = fXmlNodeUtn.get_attrVal(attrName, defValue);
                    }
                }

                // --

                if (userTagName == string.Empty)
                {
                    userTagName = "User Tag" + userTagNo.ToString();
                }
                return userTagName;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeUtn != null)
                {
                    fXmlNodeUtn.Dispose();
                    fXmlNodeUtn = null;
                }
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FJudgementCondition getAncestorJudgementCondition(
            )
        {
            FXmlNode fXmlNodeParent = null;

            try
            {
                fXmlNodeParent = this.fXmlNode.fParentNode;
                while (fXmlNodeParent != null)
                {
                    if (fXmlNodeParent.name == FXmlTagJCN.E_JudgementCondition)
                    {
                        return new FJudgementCondition(this.fTcdCore, fXmlNodeParent);
                    }
                    fXmlNodeParent = fXmlNodeParent.fParentNode;
                }
                return null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeParent = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FEnvironmentList getAncestorEnvironmentList(
            )
        {
            FXmlNode fXmlNodeParent = null;

            try
            {
                fXmlNodeParent = this.fXmlNode.fParentNode;
                while (fXmlNodeParent != null)
                {
                    if (fXmlNodeParent.name == FXmlTagENL.E_EnvironmentList)
                    {
                        return new FEnvironmentList(this.fTcdCore, fXmlNodeParent);
                    }
                    fXmlNodeParent = fXmlNodeParent.fParentNode;
                }
                return null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeParent = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FEquipmentStateSetList getAncestorEquipmentStateSetList(
            )
        {
            FXmlNode fXmlNodeParent = null;

            try
            {
                fXmlNodeParent = this.fXmlNode.fParentNode;
                while (fXmlNodeParent != null)
                {
                    if (fXmlNodeParent.name == FXmlTagESL.E_EquipmentStateSetList)
                    {
                        return new FEquipmentStateSetList(this.fTcdCore, fXmlNodeParent);
                    }
                    fXmlNodeParent = fXmlNodeParent.fParentNode;
                }
                return null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeParent = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FDataConversionSet getAncestorDataConversionSet(
            )
        {
            FXmlNode fXmlNodeParent = null;

            try
            {
                fXmlNodeParent = this.fXmlNode.fParentNode;
                while (fXmlNodeParent != null)
                {
                    if (fXmlNodeParent.name == FXmlTagDCS.E_DataConversionSet)
                    {
                        return new FDataConversionSet(this.fTcdCore, fXmlNodeParent);
                    }
                    fXmlNodeParent = fXmlNodeParent.fParentNode;
                }
                return null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeParent = null;
            }
            return null;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void validateLicense(
            string fileName
            )
        {
            // ***
            // New License File 적용
            // *** 
            FLic2License fLic = null;
            FLic2Info fLicInfo = null;

            try
            {
                fLic = new FLic2License();
                fLicInfo = fLic.validate(fileName);

                // --

                // ***
                // Product 허가 여부 체크
                // ***
                if (fLicInfo.fLicTcp.productEnabled == FYesNo.No)
                {
                    fLic.rasieValidationError("product.enabled");
                }

                // --

                // ***
                // 사용기간 체크
                // ***
                if (fLicInfo.fLicTcp.expireIssuedCheck == FYesNo.Yes && !fLic.validateExpireIssueDate(fLicInfo.fLicTcp.expireIssuedDate))
                {
                    fLic.rasieValidationError("expire.issued.date");
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fLic != null)
                {
                    fLic.Dispose();
                    fLic = null;
                }

                if (fLicInfo != null)
                {
                    fLicInfo.Dispose();
                    fLicInfo = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void init(
            )
        {
            try
            {
                m_fXmlNode.XmlNodeModified += new FXmlNodeModifiedEventHandler(m_fXmlNode_XmlNodeModified);
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

        private void term(
            )
        {
            try
            {
                m_fXmlNode.XmlNodeModified -= new FXmlNodeModifiedEventHandler(m_fXmlNode_XmlNodeModified);
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

        internal virtual void replace(
            FTcdCore fTcdCore,
            FXmlNode fXmlNode
            )
        {
            try
            {
                if (m_fXmlNode != null)
                {
                    m_fXmlNode.XmlNodeModified -= new FXmlNodeModifiedEventHandler(m_fXmlNode_XmlNodeModified);
                }

                // --

                m_fTcdCore = fTcdCore;
                // --
                m_fXmlNode = fXmlNode;
                m_fXmlNode.XmlNodeModified += new FXmlNodeModifiedEventHandler(m_fXmlNode_XmlNodeModified);
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

        public override int GetHashCode(
            )
        {
            return base.GetHashCode();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public override bool Equals(
            object obj
            )
        {
            try
            {
                if (obj == null || !(obj is T))
                {
                    return false;
                }
                // --
                return m_fXmlNode.Equals(((FBaseObject<T>)obj).fXmlNode);
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

        //------------------------------------------------------------------------------------------------------------------------

        public static bool operator ==(
            FBaseObject<T> lhs,
            object rhs
            )
        {
            try
            {
                if ((object)lhs == null)
                {
                    return ((object)rhs == null ? true : false);
                }
                // --
                return lhs.Equals(rhs);
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

        //------------------------------------------------------------------------------------------------------------------------

        public static bool operator !=(
            FBaseObject<T> lhs,
            object rhs
            )
        {
            try
            {
                if ((object)lhs == null)
                {
                    return ((object)rhs == null ? false : true);
                }
                // --
                return !lhs.Equals(rhs);
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

        //------------------------------------------------------------------------------------------------------------------------

        internal FTcpLibrary getAncestorTcpLibrary(
            )
        {
            FXmlNode fXmlNodeParent = null;

            try
            {
                fXmlNodeParent = this.fXmlNode.fParentNode;
                while (fXmlNodeParent != null)
                {
                    if (fXmlNodeParent.name == FXmlTagTLB.E_TcpLibrary)
                    {
                        return new FTcpLibrary(this.fTcdCore, fXmlNodeParent);
                    }
                    fXmlNodeParent = fXmlNodeParent.fParentNode;
                }
                return null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeParent = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FTcpMessage getAncestorTcpMessage(
            )
        {
            try
            {
                FXmlNode fXmlNodeParent = null;

                try
                {
                    fXmlNodeParent = this.fXmlNode.fParentNode;
                    while (fXmlNodeParent != null)
                    {
                        if (fXmlNodeParent.name == FXmlTagTMG.E_TcpMessage)
                        {
                            return new FTcpMessage(this.fTcdCore, fXmlNodeParent);
                        }
                        fXmlNodeParent = fXmlNodeParent.fParentNode;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    fXmlNodeParent = null;
                }
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

        //------------------------------------------------------------------------------------------------------------------------

        internal FTcpCondition getAncestorTcpCondition(
            )
        {
            FXmlNode fXmlNodeParent = null;

            try
            {
                fXmlNodeParent = this.fXmlNode.fParentNode;
                while (fXmlNodeParent != null)
                {
                    if (fXmlNodeParent.name == FXmlTagTCN.E_TcpCondition)
                    {
                        return new FTcpCondition(this.fTcdCore, fXmlNodeParent);
                    }
                    fXmlNodeParent = fXmlNodeParent.fParentNode;
                }
                return null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeParent = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FHostLibrary getAncestorHostLibrary(
            )
        {
            FXmlNode fXmlNodeParent = null;

            try
            {
                fXmlNodeParent = this.fXmlNode.fParentNode;
                while (fXmlNodeParent != null)
                {
                    if (fXmlNodeParent.name == FXmlTagHLB.E_HostLibrary)
                    {
                        return new FHostLibrary(this.fTcdCore, fXmlNodeParent);
                    }
                    fXmlNodeParent = fXmlNodeParent.fParentNode;
                }
                return null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeParent = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FHostMessage getAncestorHostMessage(
            )
        {
            FXmlNode fXmlNodeParent = null;

            try
            {
                fXmlNodeParent = this.fXmlNode.fParentNode;
                while (fXmlNodeParent != null)
                {
                    if (fXmlNodeParent.name == FXmlTagHMG.E_HostMessage)
                    {
                        return new FHostMessage(this.fTcdCore, fXmlNodeParent);
                    }
                    fXmlNodeParent = fXmlNodeParent.fParentNode;
                }
                return null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeParent = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FHostCondition getAncestorHostCondition(
            )
        {
            FXmlNode fXmlNodeParent = null;

            try
            {
                fXmlNodeParent = this.fXmlNode.fParentNode;
                while (fXmlNodeParent != null)
                {
                    if (fXmlNodeParent.name == FXmlTagHCN.E_HostCondition)
                    {
                        return new FHostCondition(this.fTcdCore, fXmlNodeParent);
                    }
                    fXmlNodeParent = fXmlNodeParent.fParentNode;
                }
                return null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeParent = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FRepository getAncestorRepository(
            )
        {
            FXmlNode fXmlNodeParent = null;

            try
            {
                fXmlNodeParent = this.fXmlNode.fParentNode;
                while (fXmlNodeParent != null)
                {
                    if (fXmlNodeParent.name == FXmlTagRPS.E_Repository)
                    {
                        return new FRepository(this.fTcdCore, fXmlNodeParent);
                    }
                    fXmlNodeParent = fXmlNodeParent.fParentNode;
                }
                return null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeParent = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FDataSet getAncestorDataSet(
            )
        {
            FXmlNode fXmlNodeParent = null;

            try
            {
                fXmlNodeParent = this.fXmlNode.fParentNode;
                while (fXmlNodeParent != null)
                {
                    if (fXmlNodeParent.name == FXmlTagDTS.E_DataSet)
                    {
                        return new FDataSet(this.fTcdCore, fXmlNodeParent);
                    }
                    fXmlNodeParent = fXmlNodeParent.fParentNode;
                }
                return null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeParent = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool containsObject(
            FIObject fObject
            )
        {
            try
            {
                return this.fXmlNode.containsNode(
                    ".//*[@" + FXmlTagCommon.A_UniqueId + "='" + fObject.uniqueIdToString + "']"
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool equalsModelingFile(
            FIObject fObject
            )
        {
            PropertyInfo propInfo = null;
            bool isModelingObject = false;
            FXmlNode fXmlNode = null;

            try
            {
                propInfo = fObject.GetType().GetProperty("isModelingObject");
                if (propInfo == null)
                {
                    return false;
                }

                // --

                isModelingObject = (bool)propInfo.GetValue(fObject, null);
                if (!this.isModelingObject || !isModelingObject)
                {
                    return false;
                }

                // --

                fXmlNode = FTcpDriverCommon.getObjectXmlNode(fObject);
                if (fXmlNode == null || this.fXmlNode.fOwnerDocument != fXmlNode.fOwnerDocument)
                {
                    return false;
                }

                // --

                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void copyObject(
            string format,
            FXmlNode fXmlNode
            )
        {
            try
            {
                FTcpDriverCommon.resetLocked(fXmlNode);
                FClipboard.setStringData(format, fXmlNode.outerXml);
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

        internal FIObject pasteObject(
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
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fXmlNode);
                return FTcpDriverCommon.createObject(fTcdCore, fXmlNode);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fXmlNode Object Event Handler

        private void m_fXmlNode_XmlNodeModified(
            object sender, 
            FXmlNodeModifiedEventArgs e
            )
        {
            FObjectEventArgs args = null;

            try
            {
                if (this.isModelingObject)
                {
                    args = new FObjectEventArgs(
                        FEventId.ObjectModifyCompleted,
                        m_fTcdCore.fTcpDriver,
                        FTcpDriverCommon.createObject(m_fTcdCore, this.fXmlNode.fParentNode),
                        (FIObject)this
                        );
                    // --
                    m_fTcdCore.fEventPusher.pushEvent(args);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FTcpBase", ex, null);
            }
            finally
            {
                args = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
