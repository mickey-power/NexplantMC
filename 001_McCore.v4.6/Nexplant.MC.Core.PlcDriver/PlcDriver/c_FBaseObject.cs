/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FBaseObject.cs
--  Creator         : spike.lee
--  Create Date     : 2013.07.10
--  Description     : FAMate Core FaPlcDriver Base Object Class 
--  History         : Created by spike.lee at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    public abstract class FBaseObject<T> : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FPcdCore m_fPcdCore = null;
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
            FLicLicense fLic = new FLicLicense();
            fLic.validate(licFileName);
            fLic.Dispose();
            fLic = null;            

            // --

            // ***
            // FSecsDriver 생성자 Only
            // ***
            m_fPcdCore = new FPcdCore();
            m_fXmlNode = m_fPcdCore.fXmlNodePcd;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // PLC Driver reopenModelingFile Method에서 사용
        // ***
        internal FBaseObject(                 
            )
        {
            // ***
            // FSecsDriver 생성자 Only
            // ***
            m_fPcdCore = new FPcdCore();
            m_fXmlNode = m_fPcdCore.fXmlNodePcd;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // PLC Driver Clone에 사용
        // ***
        internal FBaseObject(
            FXmlDocument fXmlDoc
            )
        {
            // ***
            // PLC Driver Clone 전용
            // ***
            m_fPcdCore = new FPcdCore(fXmlDoc);
            m_fXmlNode = m_fPcdCore.fXmlNodePcd;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // PLC Driver Instance 복사에 사용
        // ***
        internal FBaseObject(
            FPcdCore fPcdCore, 
            FXmlNode fXmlNode
            )            
        {
            m_fPcdCore = fPcdCore;
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

                    if (this is FPlcDriver && m_fPcdCore != null)
                    {
                        m_fPcdCore.Dispose();
                    }
                    m_fPcdCore = null;

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

        internal FPcdCore fPcdCore
        {
            get
            {
                try
                {
                    return m_fPcdCore;
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

        internal FPlcDriver fPlcDriver
        {
            get
            {
                try
                {
                    return m_fPcdCore.fPlcDriver;
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
                    m_fPcdCore.fPlcDriver = value;
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
                        FXmlTagONL.E_ObjectNameList + "[@" + FXmlTagONL.A_ObjectType + "='" + FPlcDriverCommon.getObjectType(m_fXmlNode).ToString() + "']/" +
                        FXmlTagONA.E_ObjectName;
                }
                else
                {
                    xpath = "NULL"; // 개수가 0인 Node List 생성
                }
                // --
                return new FObjectNameCollection(m_fPcdCore, this.fPlcDriver.fXmlNode.selectNodes(xpath));
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
                        FXmlTagUTN.E_UserTagName + "[@" + FXmlTagUTN.A_ObjectType + "='" + FPlcDriverCommon.getObjectType(m_fXmlNode).ToString() + "']";
                    fXmlNodeUtn = this.fPlcDriver.fXmlNode.selectSingleNode(xpath);

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
                        return new FJudgementCondition(this.fPcdCore, fXmlNodeParent);
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
                        return new FEnvironmentList(this.fPcdCore, fXmlNodeParent);
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
                        return new FEquipmentStateSetList(this.fPcdCore, fXmlNodeParent);
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
                        return new FDataConversionSet(this.fPcdCore, fXmlNodeParent);
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
            FPcdCore fPcdCore,
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

                m_fPcdCore = fPcdCore;
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

        internal FPlcLibrary getAncestorPlcLibrary(
            )
        {
            FXmlNode fXmlNodeParent = null;

            try
            {
                fXmlNodeParent = this.fXmlNode.fParentNode;
                while (fXmlNodeParent != null)
                {
                    if (fXmlNodeParent.name == FXmlTagPLB.E_PlcLibrary)
                    {
                        return new FPlcLibrary(this.fPcdCore, fXmlNodeParent);
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

        internal FPlcMessage getAncestorPlcMessage(
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
                        if (fXmlNodeParent.name == FXmlTagPMG.E_PlcMessage)
                        {
                            return new FPlcMessage(this.fPcdCore, fXmlNodeParent);
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

        internal FPlcBitList getAncestorPlcBitList(
            )
        {
            FXmlNode fXmlNodeParent = null;

            try
            {
                fXmlNodeParent = this.fXmlNode.fParentNode;
                while (fXmlNodeParent != null)
                {
                    if (fXmlNodeParent.name == FXmlTagPBL.E_PlcBitList)
                    {
                        return new FPlcBitList(this.fPcdCore, fXmlNodeParent);
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

        internal FPlcWordList getAncestorPlcWordList(
            )
        {
            FXmlNode fXmlNodeParent = null;

            try
            {
                fXmlNodeParent = this.fXmlNode.fParentNode;
                while (fXmlNodeParent != null)
                {
                    if (fXmlNodeParent.name == FXmlTagPWL.E_PlcWordList)
                    {
                        return new FPlcWordList(this.fPcdCore, fXmlNodeParent);
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

        internal FPlcCondition getAncestorPlcCondition(
            )
        {
            FXmlNode fXmlNodeParent = null;

            try
            {
                fXmlNodeParent = this.fXmlNode.fParentNode;
                while (fXmlNodeParent != null)
                {
                    if (fXmlNodeParent.name == FXmlTagPCN.E_PlcCondition)
                    {
                        return new FPlcCondition(this.fPcdCore, fXmlNodeParent);
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
                        return new FHostLibrary(this.fPcdCore, fXmlNodeParent);
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
                        return new FHostMessage(this.fPcdCore, fXmlNodeParent);
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
                        return new FHostCondition(this.fPcdCore, fXmlNodeParent);
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
                        return new FRepository(this.fPcdCore, fXmlNodeParent);
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
                        return new FDataSet(this.fPcdCore, fXmlNodeParent);
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

                fXmlNode = FPlcDriverCommon.getObjectXmlNode(fObject);
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
                FPlcDriverCommon.resetLocked(fXmlNode);
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
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fXmlNode);
                return FPlcDriverCommon.createObject(fPcdCore, fXmlNode);
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
                        m_fPcdCore.fPlcDriver,
                        FPlcDriverCommon.createObject(m_fPcdCore, this.fXmlNode.fParentNode),
                        (FIObject)this
                        );
                    // --
                    m_fPcdCore.fEventPusher.pushEvent(args);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FPlcBase", ex, null);
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
