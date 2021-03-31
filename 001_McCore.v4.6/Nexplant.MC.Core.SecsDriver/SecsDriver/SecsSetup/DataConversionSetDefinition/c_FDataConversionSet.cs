/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDataConversionSet.cs
--  Creator         : spike.lee
--  Create Date     : 2012.03.06
--  Description     : FAMate Core FaSecsDriver Data Conversion Set Class 
--  History         : Created by spike.lee at 2012.03.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FDataConversionSet : FBaseObject<FDataConversionSet>, FIObject
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDataConversionSet(
            FSecsDriver fSecsDriver
            )
            : base(fSecsDriver.fScdCore, FSecsDriverCommon.createXmlNodeDCS(fSecsDriver.fScdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FDataConversionSet(
            FScdCore fScdCore,
            FXmlNode fXmlNode
            )
            : base(fScdCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDataConversionSet(
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
                    return FObjectType.DataConversionSet;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.DataConversionSet;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDCS.A_UniqueId, FXmlTagDCS.D_UniqueId);
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
                catch(Exception ex)
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagDCS.A_Locked, FXmlTagDCS.D_Locked));
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

        public string name
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDCS.A_Name, FXmlTagDCS.D_Name);
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
            
            set
            {
                try
                {
                    FSecsDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagDCS.A_Name, FXmlTagDCS.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDCS.A_Description, FXmlTagDCS.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagDCS.A_Description, FXmlTagDCS.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagDCS.A_FontColor, FXmlTagDCS.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagDCS.A_FontColor, FXmlTagDCS.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagDCS.A_FontBold, FXmlTagDCS.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagDCS.A_FontBold, FXmlTagDCS.D_FontBold, FBoolean.fromBool(value), true);
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

        public string expression
        {
            get
            {
                try
                {
                    return buildExpression();
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

        public string userTag1
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDCS.A_UserTag1, FXmlTagDCS.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagDCS.A_UserTag1, FXmlTagDCS.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDCS.A_UserTag2, FXmlTagDCS.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagDCS.A_UserTag2, FXmlTagDCS.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDCS.A_UserTag3, FXmlTagDCS.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagDCS.A_UserTag3, FXmlTagDCS.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDCS.A_UserTag4, FXmlTagDCS.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagDCS.A_UserTag4, FXmlTagDCS.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDCS.A_UserTag5, FXmlTagDCS.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagDCS.A_UserTag5, FXmlTagDCS.D_UserTag5, value, true);
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

        public FDataConversionSetList fParent
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

                    return new FDataConversionSetList(this.fScdCore, this.fXmlNode.fParentNode);
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

        public FDataConversionSet fPreviousSibling
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

                    return new FDataConversionSet(this.fScdCore, this.fXmlNode.fPreviousSibling);
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

        public FDataConversionSet fNextSibling
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

                    return new FDataConversionSet(this.fScdCore, this.fXmlNode.fNextSibling);
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

        public FDataConversionCollection fChildDataConversionCollection
        {
            get
            {
                try
                {
                    return new FDataConversionCollection(this.fScdCore, this.fXmlNode.selectNodes(FXmlTagDCV.E_DataConversion));
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
                        "../../../../" + FXmlTagSLM.E_SecsLibraryModeling +
                        "/" + FXmlTagSLG.E_SecsLibraryGroup +
                        "/" + FXmlTagSLB.E_SecsLibrary +
                        "/" + FXmlTagSML.E_SecsMessageList +
                        "/" + FXmlTagSMS.E_SecsMessages +
                        "/" + FXmlTagSMG.E_SecsMessage +
                        "//" + FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_DataConversionSetID + "='" + this.uniqueIdToString + "']" +
                        " | " +
                        "../../../../" + FXmlTagHLM.E_HostLibraryModeling +
                        "/" + FXmlTagHLG.E_HostLibraryGroup +
                        "/" + FXmlTagHLB.E_HostLibrary +
                        "/" + FXmlTagHML.E_HostMessageList +
                        "/" + FXmlTagHMS.E_HostMessages +
                        "/" + FXmlTagHMG.E_HostMessage +
                        "//" + FXmlTagHIT.E_HostItem + "[@" + FXmlTagHIT.A_DataConversionSetID + "='" + this.uniqueIdToString + "']" +
                        " | " +
                        "../../../../" + FXmlTagSET.E_Setup +
                        "/" + FXmlTagDSD.E_DataSetDefinition +
                        "/" + FXmlTagDSL.E_DataSetList +
                        "/" + FXmlTagDTS.E_DataSet +
                        "//" + FXmlTagDAT.E_Data + "[@" + FXmlTagDAT.A_DataConversionSetID + "='" + this.uniqueIdToString + "']" +
                        " | " +
                        "../../../../" + FXmlTagSET.E_Setup +
                        "/" + FXmlTagRPD.E_RepositoryDefinition +
                        "/" + FXmlTagRPL.E_RepositoryList +
                        "/" + FXmlTagRPS.E_Repository +
                        "//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_DataConversionSetID + "='" + this.uniqueIdToString + "']" +
                        " | " +
                        "../../../../" + FXmlTagEQM.E_EquipmentModeling +
                        "/" + FXmlTagEQP.E_Equipment +
                        "/" + FXmlTagSNG.E_ScenarioGroup +
                        "/" + FXmlTagSNR.E_Scenario +
                        "/" + FXmlTagSTR.E_SecsTrigger +
                        "/" + FXmlTagSCN.E_SecsCondition +
                        "//" + FXmlTagSEP.E_SecsExpression + "[@" + FXmlTagSEP.A_DataConversionSetID + "='" + this.uniqueIdToString + "']" +
                        " | " +
                        "../../../../" + FXmlTagEQM.E_EquipmentModeling +
                        "/" + FXmlTagEQP.E_Equipment +
                        "/" + FXmlTagSNG.E_ScenarioGroup +
                        "/" + FXmlTagSNR.E_Scenario +
                        "/" + FXmlTagHTR.E_HostTrigger +
                        "/" + FXmlTagHCN.E_HostCondition +
                        "//" + FXmlTagHEP.E_HostExpression + "[@" + FXmlTagHEP.A_DataConversionSetID + "='" + this.uniqueIdToString + "']" +
                        " | " +
                        "../../../../" + FXmlTagEQM.E_EquipmentModeling +
                        "/" + FXmlTagEQP.E_Equipment +
                        "/" + FXmlTagSNG.E_ScenarioGroup +
                        "/" + FXmlTagSNR.E_Scenario +
                        "/" + FXmlTagJDM.E_Judgement +
                        "/" + FXmlTagJCN.E_JudgementCondition +
                        "//" + FXmlTagJEP.E_JudgementExpression + "[@" + FXmlTagJEP.A_DataConversionSetID + "='" + this.uniqueIdToString + "']";
                    // --
                    return new FObjectCollection(this.fScdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FObjectCollection(this.fScdCore, this.fXmlNode.selectNodes("NULL"));
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
                    return this.fXmlNode.containsNode(FXmlTagDCV.E_DataConversion);
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

        public bool canPasteChild
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.DataConversion))
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
                        !FClipboard.containsData(FCbObjectFormat.DataConversionSet)
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
                    info = this.name;
                }

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

        internal void noticeChildModified(
            )
        {
            try
            {
                updateExpressionReferenceObjectCollection();

                // --

                if (this.isModelingObject)
                {
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fSecsDriver, this.fParent, this)
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

        public FDataConversion appendChildDataConversion(
            FDataConversion fNewChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));                
                // --
                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fSecsDriver, this, fNewChild)
                        );

                    noticeChildModified();
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

        public FDataConversion insertBeforeChildDataConversion(
            FDataConversion fNewChild,
            FDataConversion fRefChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                // --
                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this.fSecsDriver, this, fNewChild)
                        );
                    noticeChildModified();
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

        public FDataConversion insertAfterChildDataConversion(
            FDataConversion fNewChild,
            FDataConversion fRefChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                // --
                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this.fSecsDriver, this, fNewChild)
                        );
                    noticeChildModified();
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
                FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);

                // --

                fParent = this.fParent;
                isModelingObject = this.isModelingObject;
                this.replace(this.fScdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));

                // --

                if (isModelingObject)
                {
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fSecsDriver, fParent, this)
                        );
                    noticeChildModified();
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

        public FDataConversion removeChildDataConversion(
            FDataConversion fChild
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

        public void removeChildDataConversion(
            FDataConversion[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FDataConversion fDcv in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode, fDcv.fXmlNode);
                }

                // --

                foreach (FDataConversion fDcv in fChilds)
                {
                    fDcv.remove();
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

        public void removeAllChildDataConversion(
            )
        {
            FDataConversionCollection fDcvCollection = null;

            try
            {
                fDcvCollection = this.fChildDataConversionCollection;
                if (fDcvCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FDataConversion fDcv in fDcvCollection)
                {
                    fDcv.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fDcvCollection != null)
                {
                    fDcvCollection.Dispose();
                    fDcvCollection = null;
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
                FSecsDriverCommon.validateMoveUpObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fScdCore, this.fXmlNode.moveUp());

                // --

                if (isModelingObject)
                {
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveUpCompleted, this.fSecsDriver, fParent, this)
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
                FSecsDriverCommon.validateMoveDownObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fScdCore, this.fXmlNode.moveDown());

                // --

                if (isModelingObject)
                {
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveDownCompleted, this.fSecsDriver, fParent, this)
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
            FDataConversionSet fRefObject
            )
        {
            FDataConversionSetList fOldParent = null;

            try
            {
                FSecsDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

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

                fOldParent = this.fParent;

                // --

                this.replace(this.fScdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fScdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                if (!this.fParent.Equals(fOldParent) && this.locked)
                {
                    fOldParent.unlockObject();
                    this.fParent.lockObject();
                }

                // --

                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fSecsDriver, this, fRefObject)
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOldParent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void moveTo(
            FDataConversionSetList fRefObject
            )
        {
            FDataConversionSetList fOldParent = null;

            try
            {
                FSecsDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

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

                if (fRefObject.fChildDataConversionSetCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildDataConversionSetCollection[fRefObject.fChildDataConversionSetCollection.count - 1]))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "same localtion"));
                    }
                }  

                // --              

                fOldParent = this.fParent;

                // --

                this.replace(this.fScdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fScdCore, fRefObject.fXmlNode.appendChild(this.fXmlNode));

                // --

                if (!fRefObject.Equals(fOldParent) && this.locked)
                {
                    fOldParent.unlockObject();
                    fRefObject.lockObject();
                }

                // --

                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fSecsDriver, this, fRefObject)
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOldParent = null;
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

                // ***
                // Data Conversion Set 에 대한 Lock 처리
                // ***
                this.fXmlNode.set_attrVal(FXmlTagDCS.A_Locked, FXmlTagDCS.D_Locked, FBoolean.True, true);

                // --

                // ***
                // Parent Data Conversion Set 에 대한 Lock 처리
                // ***
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

                // --                

                // ***
                // Data Conversion Set이 사용되었을 경우 Unlock 작업을 취소한다.
                // ***
                xpath =
                    "../../../../" + FXmlTagSET.E_Setup +
                    "/" + FXmlTagRPD.E_RepositoryDefinition +
                    "/" + FXmlTagRPL.E_RepositoryList +
                    "/" + FXmlTagRPS.E_Repository +
                    "//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_DataConversionSetID + "='" + this.uniqueIdToString + "']" +
                    " | " +
                    "../../../../" + FXmlTagSET.E_Setup +
                    "/" + FXmlTagDSD.E_DataSetDefinition +
                    "/" + FXmlTagDSL.E_DataSetList +
                    "/" + FXmlTagDTS.E_DataSet +
                    "//" + FXmlTagDAT.E_Data + "[@" + FXmlTagDAT.A_DataConversionSetID + "='" + this.uniqueIdToString + "']" +
                    " | " +
                    "../../../../" + FXmlTagSLM.E_SecsLibraryModeling +
                    "/" + FXmlTagSLG.E_SecsLibraryGroup +
                    "/" + FXmlTagSLB.E_SecsLibrary +
                    "/" + FXmlTagSML.E_SecsMessageList +
                    "/" + FXmlTagSMS.E_SecsMessages +
                    "/" + FXmlTagSMG.E_SecsMessage +
                    "//" + FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_DataConversionSetID + "='" + this.uniqueIdToString + "']" +
                    " | " +
                    "../../../../" + FXmlTagHLM.E_HostLibraryModeling +
                    "/" + FXmlTagHLG.E_HostLibraryGroup +
                    "/" + FXmlTagHLB.E_HostLibrary +
                    "/" + FXmlTagHML.E_HostMessageList +
                    "/" + FXmlTagHMS.E_HostMessages +
                    "/" + FXmlTagHMG.E_HostMessage +
                    "//" + FXmlTagHIT.E_HostItem + "[@" + FXmlTagHIT.A_DataConversionSetID + "='" + this.uniqueIdToString + "']" +
                    " | " +
                    "../../../../" + FXmlTagEQM.E_EquipmentModeling +
                    "/" + FXmlTagEQP.E_Equipment +
                    "/" + FXmlTagSNG.E_ScenarioGroup +
                    "/" + FXmlTagSNR.E_Scenario +
                    "/" + FXmlTagSTR.E_SecsTrigger +
                    "/" + FXmlTagSCN.E_SecsCondition +
                    "//" + FXmlTagSEP.E_SecsExpression + "[@" + FXmlTagSEP.A_DataConversionSetID + "='" + this.uniqueIdToString + "']" +
                    " | " +
                    "../../../../" + FXmlTagEQM.E_EquipmentModeling +
                    "/" + FXmlTagEQP.E_Equipment +
                    "/" + FXmlTagSNG.E_ScenarioGroup +
                    "/" + FXmlTagSNR.E_Scenario +
                    "/" + FXmlTagHTR.E_HostTrigger +
                    "/" + FXmlTagHCN.E_HostCondition +
                    "//" + FXmlTagHEP.E_HostExpression + "[@" + FXmlTagHEP.A_DataConversionSetID + "='" + this.uniqueIdToString + "']" +
                    " | " +
                    "../../../../" + FXmlTagEQM.E_EquipmentModeling +
                    "/" + FXmlTagEQP.E_Equipment +
                    "/" + FXmlTagSNG.E_ScenarioGroup +
                    "/" + FXmlTagSNR.E_Scenario +
                    "/" + FXmlTagJDM.E_Judgement +
                    "/" + FXmlTagJCN.E_JudgementCondition +
                    "//" + FXmlTagJEP.E_JudgementExpression + "[@" + FXmlTagJEP.A_DataConversionSetID + "='" + this.uniqueIdToString + "']";
                // --
                if (this.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // --

                // ***
                // Data Conversion Set Item에 대한 Unlock 처리
                // ***
                this.fXmlNode.set_attrVal(FXmlTagDCS.A_Locked, FXmlTagDCS.D_Locked, FBoolean.False, true);

                // --

                // ***
                // Parent Data Conversion Set List 에 대한 Unlcok 처리
                // ***
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
                FSecsDriverCommon.validateCutObject(this.fXmlNode);
                
                // --

                this.remove();
                this.copyObject(FCbObjectFormat.DataConversionSet, fXmlNode);
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
                this.copyObject(FCbObjectFormat.DataConversionSet, fXmlNode);
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

        public FDataConversionSet pasteSibling(
            )
        {
            FDataConversionSet fDataConversionSet = null;

            try
            {
                FSecsDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.DataConversionSet);

                // --

                fDataConversionSet = (FDataConversionSet)this.pasteObject(FCbObjectFormat.DataConversionSet);
                this.fParent.insertAfterChildDataConversionSet(fDataConversionSet, this);

                return fDataConversionSet;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fDataConversionSet = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataConversion pasteChild(
            )
        {
            FDataConversion fDataConversion = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.DataConversion);

                // --

                fDataConversion = (FDataConversion)this.pasteObject(FCbObjectFormat.DataConversion);
                return this.appendChildDataConversion(fDataConversion);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fDataConversion = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataConversionCollection selectDataConversionByName(
            string name
            )
        {
            const string xpath = FXmlTagDCV.E_DataConversion + "[@" + FXmlTagDCV.A_Name + "='{0}']";

            try
            {
                return new FDataConversionCollection(
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

        public FDataConversion selectSingleDataConversionByName(
            string name
            )
        {
            const string xpath = FXmlTagDCV.E_DataConversion + "[@" + FXmlTagDCV.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FDataConversion(this.fScdCore, fXmlNode);
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

        private string buildExpression(
           )
        {
            StringBuilder exp = null;

            try
            {
                exp = new StringBuilder();
                foreach (FDataConversion fDcv in this.fChildDataConversionCollection)
                {
                    buildExpression(fDcv, exp);
                }
                return exp.ToString();
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

        private void buildExpression(
            FDataConversion fDcv,
            StringBuilder exp
            )
        {
            List<string> valueFormulaList = null;
            try
            {
                valueFormulaList = fDcv.fValueTransformer.getValueFormulaList();
                if (valueFormulaList.Count > 0)
                {
                    exp.Append(string.Join(FConstants.ValueFormulaSeparator.ToString(), valueFormulaList.ToArray()));                    
                }
                exp.Append(FConstants.DataCovnersionExpressionSeparator); // Value Transformer
                exp.Append(FEnumConverter.fromComparisonMode(fDcv.fComparisonMode)); // COMPARISON MODE
                exp.Append(FConstants.DataConversionUnitSeparator);
                exp.Append(FEnumConverter.fromFormat(fDcv.fFormat)); // FORMAT
                exp.Append(FConstants.DataConversionUnitSeparator);
                exp.Append(fDcv.operandIndex); // INDEX
                exp.Append(FConstants.DataConversionUnitSeparator);
                exp.Append(FEnumConverter.fromOperation(fDcv.fOperation)); // OPERATION
                exp.Append(FConstants.DataConversionUnitSeparator);
                exp.Append(FEnumConverter.fromConversionMode(fDcv.fConversionMode)); // CONVERSION MODE
                exp.Append(FConstants.DataConversionUnitSeparator);
                if (fDcv.fConversionMode == FConversionMode.Value)
                {
                    exp.Append(fDcv.stringValue); // VALUE
                }
                else
                {
                    exp.Append(fDcv.min); // MIN
                    exp.Append(FConstants.DataConversionUnitSeparator);
                    exp.Append(fDcv.max); // MAX
                }
                exp.Append(FConstants.DataConversionUnitSeparator);
                exp.Append(fDcv.conversionValue); // CONVERSION VALUE
                exp.Append(FConstants.DataConversionSeparator);
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

        private void updateExpressionReferenceObjectCollection(
            )
        {
            string expression = string.Empty;
            try
            {
                expression = this.expression;
                foreach (FIObject obj in this.fReferenceObjectCollection)
                {
                    if (obj.fObjectType == FObjectType.SecsItem)
                    {
                        ((FSecsItem)obj).dataConversionSetName = this.name;
                        ((FSecsItem)obj).dataConversionSetExpression = expression;                        
                    }
                    else if (obj.fObjectType == FObjectType.HostItem)
                    {
                        ((FHostItem)obj).dataConversionSetName = this.name;
                        ((FHostItem)obj).dataConversionSetExpression = expression;
                    }
                    else if (obj.fObjectType == FObjectType.Column)
                    {
                        ((FColumn)obj).dataConversionSetName = this.name;
                        ((FColumn)obj).dataConversionSetExpression = expression;
                    }
                    else if (obj.fObjectType == FObjectType.Data)
                    {
                        ((FData)obj).dataConversionSetName = this.name;
                        ((FData)obj).dataConversionSetExpression = expression;
                    }
                    else if (obj.fObjectType == FObjectType.SecsExpression)
                    {
                        ((FSecsExpression)obj).dataConversionSetName = this.name;
                        ((FSecsExpression)obj).dataConversionSetExpression = expression;
                    }
                    else if (obj.fObjectType == FObjectType.HostExpression)
                    {
                        ((FHostExpression)obj).dataConversionSetName = this.name;
                        ((FHostExpression)obj).dataConversionSetExpression = expression;
                    }
                    else if (obj.fObjectType == FObjectType.JudgementExpression)
                    {
                        ((FJudgementExpression)obj).dataConversionSetName = this.name;
                        ((FJudgementExpression)obj).dataConversionSetExpression = expression;
                    }
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
