/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDataConversion.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.08.06
--  Description     : FAMate Core FaTcpDriver Data Conversion Class 
--  History         : Created by jungyoul.moon at 2013.08.06
--                    Modified by byjeon at 2014.01.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public class FDataConversion : FBaseObject<FDataConversion>, FIObject
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDataConversion(
            FTcpDriver fTcpDriver
            )
            : base(fTcpDriver.fTcdCore, FTcpDriverCommon.createXmlNodeDCV(fTcpDriver.fTcdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FDataConversion(
            FTcdCore fTcdCore,
            FXmlNode fXmlNode
            )
            : base(fTcdCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDataConversion(
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
                    return FObjectType.DataConversion;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.DataConversion;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDCV.A_UniqueId, FXmlTagDCV.D_UniqueId);
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

        public string name
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDCV.A_Name, FXmlTagDCV.D_Name);
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
                    FTcpDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagDCV.A_Name, FXmlTagDCV.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDCV.A_Description, FXmlTagDCV.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagDCV.A_Description, FXmlTagDCV.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagDCV.A_FontColor, FXmlTagDCV.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagDCV.A_FontColor, FXmlTagDCV.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagDCV.A_FontBold, FXmlTagDCV.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagDCV.A_FontBold, FXmlTagDCV.D_FontBold, FBoolean.fromBool(value), true);
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

        public FComparisonMode fComparisonMode
        {
            get
            {
                try
                {
                    return FEnumConverter.toComparisonMode(this.fXmlNode.get_attrVal(FXmlTagDCV.A_ComparisonMode, FXmlTagDCV.D_ComparisonMode));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FComparisonMode.Value;
            }

            set
            {
                try
                {
                    if (this.fComparisonMode == value)
                    {
                        return;
                    }

                    // -- 

                    changeComparisonMode(value);

                    // --

                    noticeModified(this.fAncestorDataConversionSet);
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

        public FFormat fFormat
        {
            get
            {
                try
                {
                    return FEnumConverter.toFormat(this.fXmlNode.get_attrVal(FXmlTagDCV.A_OperandFormat, FXmlTagDCV.D_OperandFormat));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FFormat.Ascii;
            }

            set
            {
                try
                {
                    if (this.fFormat == value)
                    {
                        return;
                    }

                    // --

                    changeFormat(value);

                    // --

                    noticeModified(this.fAncestorDataConversionSet);
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

        public int operandIndex
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagDCV.A_OperandIndex, FXmlTagDCV.D_OperandIndex));
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
                    if (value < 0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0014, "Operand Index"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagDCV.A_OperandIndex, FXmlTagDCV.D_OperandIndex, value.ToString(), true);
                    // --
                    noticeModified(this.fAncestorDataConversionSet);
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

        public FConversionMode fConversionMode
        {
            get
            {
                try
                {
                    return FEnumConverter.toConversionMode(this.fXmlNode.get_attrVal(FXmlTagDCV.A_ConversionMode, FXmlTagDCV.D_ConversionMode));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FConversionMode.Value;
            }

            set
            {
                try
                {
                    if (this.fConversionMode == value)
                    {
                        return;
                    }

                    // --

                    changeConversionMode(value);

                    // --

                    noticeModified(this.fAncestorDataConversionSet);
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

        public FOperation fOperation
        {
            get
            {
                try
                {
                    return FEnumConverter.toOperation(this.fXmlNode.get_attrVal(FXmlTagDCV.A_Operation, FXmlTagDCV.D_Operation));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FOperation.Equal;
            }

            set
            {
                try
                {  
                    this.fXmlNode.set_attrVal(FXmlTagDCV.A_Operation, FXmlTagDCV.D_Operation, FEnumConverter.fromOperation(value), true);
                    
                    // --

                    noticeModified(this.fAncestorDataConversionSet);
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

        public string stringValue
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDCV.A_Value, FXmlTagDCV.D_Value);
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
                    if (!FTcpDriverCommon.validateFormatRange(fFormat, value))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0014, "Value"));
                    }

                    if (this.fConversionMode != FConversionMode.Value)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Conversion Mode", "Value"));
                    }

                    // -- 

                    this.fXmlNode.set_attrVal(FXmlTagDCV.A_Value, FXmlTagDCV.D_Value, value, true);
                    
                    // --
                    
                    noticeModified(this.fAncestorDataConversionSet);
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

        public string min
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDCV.A_Min, FXmlTagDCV.D_Min);
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
                    if (this.fConversionMode != FConversionMode.Range)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Conversion Mode", "Range"));
                    }

                    if (!FTcpDriverCommon.validateFormatRange(fFormat, value))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0014, "Min"));
                    }

                    if (!FTcpDriverCommon.validateMinMax(fFormat, value, max))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0014, "Min"));
                    }

                    // -- 
                    
                    this.fXmlNode.set_attrVal(FXmlTagDCV.A_Min, FXmlTagDCV.D_Min, value, true);
                    
                    // --

                    noticeModified(this.fAncestorDataConversionSet);
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

        public string max
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDCV.A_Max, FXmlTagDCV.D_Max);
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
                    if (this.fConversionMode != FConversionMode.Range)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Conversion Mode", "Range"));
                    }

                    if (!FTcpDriverCommon.validateFormatRange(fFormat, value))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0014, "Max"));
                    }

                    if (!FTcpDriverCommon.validateMinMax(fFormat, min, value))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0014, "Max"));
                    }
                    
                    // -- 

                    this.fXmlNode.set_attrVal(FXmlTagDCV.A_Max, FXmlTagDCV.D_Max, value, true);
                    
                    // --
                    
                    noticeModified(this.fAncestorDataConversionSet);
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

        public string conversionValue
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDCV.A_ConversionValue, FXmlTagDCV.D_ConversionValue);
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
                    this.fXmlNode.set_attrVal(FXmlTagDCV.A_ConversionValue, FXmlTagDCV.D_ConversionValue, value, true);
                    
                    // --
                    
                    noticeModified(this.fAncestorDataConversionSet);
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

        public FDataConversionValueTransformer fValueTransformer
        {
            get
            {
                try
                {
                    return new FDataConversionValueTransformer(this);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDCV.A_UserTag1, FXmlTagDCV.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagDCV.A_UserTag1, FXmlTagDCV.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDCV.A_UserTag2, FXmlTagDCV.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagDCV.A_UserTag2, FXmlTagDCV.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDCV.A_UserTag3, FXmlTagDCV.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagDCV.A_UserTag3, FXmlTagDCV.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDCV.A_UserTag4, FXmlTagDCV.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagDCV.A_UserTag4, FXmlTagDCV.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDCV.A_UserTag5, FXmlTagDCV.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagDCV.A_UserTag5, FXmlTagDCV.D_UserTag5, value, true);
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

        public FDataConversionSet fParent
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

                    return new FDataConversionSet(this.fTcdCore, this.fXmlNode.fParentNode);
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

        public FDataConversion fPreviousSibling
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

                    return new FDataConversion(this.fTcdCore, this.fXmlNode.fPreviousSibling);
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

        public FDataConversion fNextSibling
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

                    return new FDataConversion(this.fTcdCore, this.fXmlNode.fNextSibling);
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
                try
                {
                    return new FObjectCollection(this.fTcdCore, this.fXmlNode.selectNodes("NULL"));
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
                    return new FObjectCollection(this.fTcdCore, this.fXmlNode.selectNodes("NULL"));
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

        public FDataConversionSet fAncestorDataConversionSet
        {
            get
            {
                try
                {
                    return this.getAncestorDataConversionSet();
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool canPasteSibling
        {
            get
            {
                try
                {
                    if (
                        this.fXmlNode.fParentNode == null ||
                        !FClipboard.containsData(FCbObjectFormat.DataConversion)
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
                info = FEnumConverter.fromFormat(fFormat);
                if (option == FStringOption.Detail)
                {
                    if (this.fComparisonMode == FComparisonMode.Value)
                    {
                        info += " " + this.name + "[" + this.operandIndex.ToString() + "]";
                    }
                    else
                    {
                        info += " Len( " + this.name + " )";
                    }

                    // --

                    if (fConversionMode == FConversionMode.Value)
                    {
                        info += " " + FEnumConverter.toOperationExp(this.fOperation) + " ";
                        info += stringValue;
                    }
                    else
                    {
                        info += " ⊂ Range(" + min + ", " + max + ") ";
                    }

                    // --

                    info += " → " + conversionValue;
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

        public void remove(
           )
        {
            FIObject fParent = null;
            bool isModelingObject = false;

            try
            {
                FTcpDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);

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
                    noticeModified((FDataConversionSet)fParent);
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
            FDataConversion fRefObject
            )
        {
            FDataConversionSet fOldParent = null;

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

                // --

                fOldParent = this.fParent;

                // --

                this.replace(this.fTcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fTcdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                if (this.fParent.Equals(fOldParent))
                {
                    this.fParent.noticeChildModified();
                }
                else
                {
                    fOldParent.noticeChildModified();
                    this.fParent.noticeChildModified();
                }

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
                fOldParent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void moveTo(
            FDataConversionSet fRefObject
            )
        {
            FDataConversionSet fOldParent = null;

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

                if (fRefObject.fChildDataConversionCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildDataConversionCollection[fRefObject.fChildDataConversionCollection.count - 1]))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "same localtion"));
                    }
                }  

                // --

                fOldParent = this.fParent;

                // --
                
                this.replace(this.fTcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fTcdCore, fRefObject.fXmlNode.appendChild(this.fXmlNode));

                // --

                if (fRefObject.Equals(fOldParent))
                {
                    fRefObject.noticeChildModified();
                }
                else
                {
                    fOldParent.noticeChildModified();
                    fRefObject.noticeChildModified();
                }

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
                fOldParent = null;
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
                this.copyObject(FCbObjectFormat.DataConversion, fXmlNode);
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
                fXmlNode = this.fXmlNode;
                this.copyObject(FCbObjectFormat.DataConversion, fXmlNode);
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

        public FDataConversion pasteSibling(
            )
        {
            FDataConversion fDataConversion = null;

            try
            {
                FTcpDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.DataConversion);

                // --

                fDataConversion = (FDataConversion)this.pasteObject(FCbObjectFormat.DataConversion);
                return this.fParent.insertAfterChildDataConversion(fDataConversion, this);
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

        private void changeFormat(
            FFormat fFormat
            )
        {
            try
            {
                this.fXmlNode.set_attrVal(FXmlTagDCV.A_OperandIndex, FXmlTagDCV.D_OperandIndex, false);
                this.fXmlNode.set_attrVal(FXmlTagDCV.A_Operation, FXmlTagDCV.D_Operation, false);
                this.fXmlNode.set_attrVal(FXmlTagDCV.A_Value, FXmlTagDCV.D_Value, false);
                this.fXmlNode.set_attrVal(FXmlTagDCV.A_Transformer, FXmlTagDCV.D_Transformer, false);
                this.fXmlNode.set_attrVal(FXmlTagDCV.A_ConversionMode, FXmlTagDCV.D_ConversionMode, false);

                // -- 

                if (
                    fFormat == FFormat.List ||
                    fFormat == FFormat.AsciiList ||
                    fFormat == FFormat.Unknown ||
                    fFormat == FFormat.Raw
                    )
                {
                    this.fXmlNode.set_attrVal(FXmlTagDCV.A_ComparisonMode, FXmlTagDCV.D_ComparisonMode, FEnumConverter.fromComparisonMode(FComparisonMode.Length), false);
                }
                else
                {
                    this.fXmlNode.set_attrVal(FXmlTagDCV.A_ComparisonMode, FXmlTagDCV.D_ComparisonMode, FEnumConverter.fromComparisonMode(FComparisonMode.Value), false);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagDCV.A_OperandFormat, FXmlTagDCV.D_OperandFormat, FEnumConverter.fromFormat(fFormat), true);
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

        private void changeComparisonMode(
            FComparisonMode fComparisonMode
            )
        {
            try
            {
                this.fXmlNode.set_attrVal(FXmlTagDCV.A_OperandIndex, FXmlTagDCV.D_OperandIndex, false);
                this.fXmlNode.set_attrVal(FXmlTagDCV.A_ConversionMode, FXmlTagDCV.D_ConversionMode, false);
                this.fXmlNode.set_attrVal(FXmlTagDCV.A_Value, FXmlTagDCV.D_Value, false);
                this.fXmlNode.set_attrVal(FXmlTagDCV.A_Min, FXmlTagDCV.D_Min, false);
                this.fXmlNode.set_attrVal(FXmlTagDCV.A_Max, FXmlTagDCV.D_Max, false);

                // -- 

                this.fXmlNode.set_attrVal(FXmlTagDCV.A_ComparisonMode, FXmlTagDCV.D_ComparisonMode, FEnumConverter.fromComparisonMode(fComparisonMode), true);
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

        private void changeConversionMode(
           FConversionMode fConversionMode
           )
        {
            try
            {
                if (fConversionMode == FConversionMode.Range)
                {
                    if (
                        this.fFormat == FFormat.List ||
                        this.fFormat == FFormat.AsciiList ||
                        this.fFormat == FFormat.Unknown ||
                        this.fFormat == FFormat.Raw ||
                        // --
                        this.fFormat == FFormat.Ascii ||
                        this.fFormat == FFormat.A2 ||
                        this.fFormat == FFormat.JIS8 ||
                        // --
                        this.fFormat == FFormat.Boolean
                        )
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format", "Numeric"));
                    }
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagDCV.A_Value, FXmlTagDCV.D_Value, false);
                this.fXmlNode.set_attrVal(FXmlTagDCV.A_Operation, FXmlTagDCV.D_Operation, false);
                this.fXmlNode.set_attrVal(FXmlTagDCV.A_Min, FXmlTagDCV.D_Min, false);
                this.fXmlNode.set_attrVal(FXmlTagDCV.A_Max, FXmlTagDCV.D_Max, false);

                // --

                this.fXmlNode.set_attrVal(FXmlTagDCV.A_ConversionMode, FXmlTagDCV.D_ConversionMode, FEnumConverter.fromConversionMode(fConversionMode), true);
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

        internal void noticeModified(
            FDataConversionSet fDataConversionSet
            )
        {
            try
            {
                if (fDataConversionSet != null)
                {
                    fDataConversionSet.noticeChildModified();
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

        public void noticeModified(            
            )
        {
            try
            {
                if (fAncestorDataConversionSet != null)
                {
                    fAncestorDataConversionSet.noticeChildModified();
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
