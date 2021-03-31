/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FBaseObject.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.28
--  Description     : FAMate Core FaSecsDriver Base Object Class 
--  History         : Created by spike.lee at 2011.01.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public abstract class FBaseObject<T> : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FScdCore m_fScdCore = null;
        private FXmlNode m_fXmlNode = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        // ***
        // 2014.02.03 by spike.lee
        // SECS Driver 생성에 사용
        // ***
        internal FBaseObject(                 
            string licFileName
            )
        {
            validateLicense(licFileName);          
            
            // --
            
            m_fScdCore = new FScdCore();
            m_fXmlNode = m_fScdCore.fXmlNodeScd;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // SECS Driver reopenModelingFile Method에서 사용
        // ***
        internal FBaseObject(
            )
        {
            m_fScdCore = new FScdCore();
            m_fXmlNode = m_fScdCore.fXmlNodeScd;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // SECS Driver Clone에 사용
        // ***
        internal FBaseObject(
            FXmlDocument fXmlDoc
            )
        {
            m_fScdCore = new FScdCore(fXmlDoc);
            m_fXmlNode = m_fScdCore.fXmlNodeScd;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // SECS Driver Instance 복사에 사용
        // ***
        internal FBaseObject(
            FScdCore fScdCore, 
            FXmlNode fXmlNode
            )            
        {
            m_fScdCore = fScdCore;
            m_fXmlNode = fXmlNode;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // SECS Object Instance 복사에 사용
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

                    if (this is FSecsDriver && m_fScdCore != null)
                    {
                        m_fScdCore.Dispose();
                    }
                    m_fScdCore = null;

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
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FSecsDriver fSecsDriver
        {
            get
            {
                try
                {
                    return m_fScdCore.fSecsDriver;
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
                    m_fScdCore.fSecsDriver = value;
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
                if (fLicInfo.fLicSecs.productEnabled == FYesNo.No)
                {
                    fLic.rasieValidationError("product.enabled");
                }

                // --

                // ***
                // 사용기간 체크
                // ***
                if (fLicInfo.fLicSecs.expireIssuedCheck == FYesNo.Yes && !fLic.validateExpireIssueDate(fLicInfo.fLicSecs.expireIssuedDate))
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
            FScdCore fScdCore,
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

                m_fScdCore = fScdCore;
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

        internal FSecsLibrary getAncestorSecsLibrary(
            )
        {
            FXmlNode fXmlNodeParent = null;

            try
            {
                fXmlNodeParent = this.fXmlNode.fParentNode;
                while (fXmlNodeParent != null)
                {
                    if (fXmlNodeParent.name == FXmlTagSLB.E_SecsLibrary)
                    {
                        return new FSecsLibrary(this.fScdCore, fXmlNodeParent);
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
                        return new FHostLibrary(this.fScdCore, fXmlNodeParent);
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

        internal FSecsMessage getAncestorSecsMessage(
            )
        {
            FXmlNode fXmlNodeParent = null;

            try
            {
                fXmlNodeParent = this.fXmlNode.fParentNode;
                while (fXmlNodeParent != null)
                {
                    if (fXmlNodeParent.name == FXmlTagSMG.E_SecsMessage)
                    {
                        return new FSecsMessage(this.fScdCore, fXmlNodeParent);
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
                        return new FDataSet(this.fScdCore, fXmlNodeParent);
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
                        return new FHostMessage(this.fScdCore, fXmlNodeParent);
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

        internal FSecsCondition getAncestorSecsCondition(
            )
        {
            FXmlNode fXmlNodeParent = null;

            try
            {
                fXmlNodeParent = this.fXmlNode.fParentNode;
                while (fXmlNodeParent != null)
                {
                    if (fXmlNodeParent.name == FXmlTagSCN.E_SecsCondition) 
                    {
                        return new FSecsCondition(this.fScdCore, fXmlNodeParent);
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
                        return new FHostCondition(this.fScdCore, fXmlNodeParent);
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
                        return new FRepository(this.fScdCore, fXmlNodeParent);
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
                        return new FJudgementCondition(this.fScdCore, fXmlNodeParent);
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
                        return new FEnvironmentList(this.fScdCore, fXmlNodeParent);
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
                        return new FEquipmentStateSetList(this.fScdCore, fXmlNodeParent);
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
                        return new FDataConversionSet(this.fScdCore, fXmlNodeParent);
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
                        FXmlTagONL.E_ObjectNameList + "[@" + FXmlTagONL.A_ObjectType + "='" + FSecsDriverCommon.getObjectType(m_fXmlNode).ToString() + "']/" +
                        FXmlTagONA.E_ObjectName;
                }
                else
                {
                    xpath = "NULL"; // 개수가 0인 Node List 생성
                }
                // --
                return new FObjectNameCollection(m_fScdCore, this.fSecsDriver.fXmlNode.selectNodes(xpath));
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
                        FXmlTagUTN.E_UserTagName + "[@" + FXmlTagUTN.A_ObjectType + "='" + FSecsDriverCommon.getObjectType(m_fXmlNode).ToString() + "']";
                    fXmlNodeUtn = this.fSecsDriver.fXmlNode.selectSingleNode(xpath);

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

                fXmlNode = FSecsDriverCommon.getObjectXmlNode(fObject);
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
                FSecsDriverCommon.resetLocked(fXmlNode);
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
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fXmlNode);
                return FSecsDriverCommon.createObject(fScdCore, fXmlNode);
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
                        m_fScdCore.fSecsDriver, 
                        FSecsDriverCommon.createObject(m_fScdCore, this.fXmlNode.fParentNode), 
                        (FIObject)this
                        );
                    // --
                    m_fScdCore.fEventPusher.pushEvent(args);                        
                }                
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FSecsBase", ex, null);
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
