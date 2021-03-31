/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FEnvironmentList.cs
--  Creator         : kitae
--  Create Date     : 2011.04.25
--  Description     : FAMate Core FaSecsDriver Evnironment Class
--  History         : Created by kitae at 2011.04.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FEnvironment : FBaseObject<FEnvironment>, FIObject, FISecsOperand, FIHostOperand
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEnvironment(
           FSecsDriver fSecsDriver
            )
            : base(fSecsDriver.fScdCore, FSecsDriverCommon.createXmlNodeENV(fSecsDriver.fScdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FEnvironment(
            FScdCore fScdCore,
            FXmlNode fXmlNode
            )
            : base(fScdCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FEnvironment(
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
                    return FObjectType.Environment;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.Environment;
            }                 
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsOperandType fSecsOperandType
        {
            get
            {
                try
                {
                    return FSecsOperandType.Environment;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FSecsOperandType.Environment;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostOperandType fHostOperandType
        {
            get
            {
                try
                {
                    return FHostOperandType.Environment;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FHostOperandType.Environment;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagENV.A_UniqueId, FXmlTagENV.D_UniqueId);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagENV.A_Locked,FXmlTagENV.D_Locked));
                }
                catch(Exception ex)
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
                    return this.fXmlNode.get_attrVal(FXmlTagENV.A_Name,FXmlTagENV.D_Name);
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
                    FSecsDriverCommon.validateName(value,true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagENV.A_Name, FXmlTagENV.D_Name,value,true);
                }
                catch(Exception ex)
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
                    return this.fXmlNode.get_attrVal(FXmlTagENV.A_Description,FXmlTagENV.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagENV.A_Description,FXmlTagENV.D_Description,value, true);
                }
                catch(Exception ex)
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagENV.A_FontColor,FXmlTagENV.D_FontColor));
                }
                catch(Exception ex)
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
                    this.fXmlNode.set_attrVal(FXmlTagENV.A_FontColor, FXmlTagENV.D_FontColor,value.Name,true);
                }
                catch(Exception ex)
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagENV.A_FontBold,FXmlTagENV.D_FontBold));
                }
                catch(Exception ex)
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
                    this.fXmlNode.set_attrVal(FXmlTagENV.A_FontBold,FXmlTagENV.D_FontBold,FBoolean.fromBool(value),true);
                }
                catch(Exception ex)
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
                    return FEnumConverter.toFormat(this.fXmlNode.get_attrVal(FXmlTagENV.A_Format, FXmlTagENV.D_Format));
                }
                catch(Exception ex)
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
                        return ;
                    }

                    // --

                    // ***
                    // Locked 되어 있는 Environment 의 Format은 변경할 수 없다.
                    // ***
                    if (this.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012,"Object"));
                    }

                    // ***
                    // 자식이 존재하는 List Format의 Environment의 Format은 변경 할 수 없다.
                    // (자식이 존재하는 Environment의 Format은 변경할 수 없다.)
                    // ***
                    if (this.hasChild)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0013,"Objects Child"));
                    }

                    // ***
                    // 부모가 Environment이고 부모의 Format이 AsciiList인 경우 Format를 변경할 수 없다.
                    // ***
                    if (this.fParent != null && this.fParent.fObjectType == FObjectType.Environment && ((FEnvironment)this.fParent).fFormat == FFormat.AsciiList)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0010, "Parent's Format", "AsciiList"));
                    }
                    
                    // --

                    setChangedFormat();
                    this.fXmlNode.set_attrVal(FXmlTagENV.A_Format,FXmlTagENV.D_Format,FEnumConverter.fromFormat(value),true);
                }
                catch(Exception ex)
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
                    return this.fXmlNode.get_attrVal(FXmlTagENV.A_Value, FXmlTagENV.D_Value);
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
                FFormat fFormat;
                int length = 0;
                string val = string.Empty;

                try
                {
                    fFormat = this.fFormat;

                    // --

                    // ***
                    // List, Unknown, Raw Format은 Value를 설정할 수 없다.
                    // ***
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Value"));
                    }

                    // --

                    val = FValueConverter.fromStringValue(fFormat, value, out length);
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagENV.A_Length, FXmlTagENV.D_Length, length.ToString());
                    this.fXmlNode.set_attrVal(FXmlTagENV.A_Value, FXmlTagENV.D_Value, val, true);
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

        public string[] stringArrayValue
        {
            get
            {
                try
                {
                    return FValueConverter.toStringArrayValue(this.fFormat, this.stringValue);
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
                FFormat fFormat;
                int length = 0;
                string val = string.Empty;

                try
                {
                    fFormat = this.fFormat;

                    // --

                    // ***
                    // List, Unknown, Raw Format은 Value를 설정할 수 없다.
                    // ***
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Value"));
                    }

                    // --

                    val = FValueConverter.fromStringArrayValue(fFormat, value, out length);
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagENV.A_Length, FXmlTagENV.D_Length, length.ToString());
                    this.fXmlNode.set_attrVal(FXmlTagENV.A_Value, FXmlTagENV.D_Value, val, true);
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

        public object value
        {
            get
            {
                try
                {
                    return FValueConverter.toValue(this.fFormat, this.stringValue, this.length);
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
                FFormat fFormat;
                int length = 0;
                string val = string.Empty;
                try
                {
                    fFormat = this.fFormat;

                    // --

                    // ***
                    // List, Unknown,Raw Format은 Value를 설정할 수 없다.
                    // ***
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Value"));
                    }

                    // --

                    val = FValueConverter.fromValue(fFormat, value, out length);
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagENV.A_Length, FXmlTagENV.D_Length, length.ToString());
                    this.fXmlNode.set_attrVal(FXmlTagENV.A_Value, FXmlTagENV.D_Value, val, true);
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

        public string encodingValue
        {
            get
            {
                try
                {
                    return FValueConverter.toEncodingValue(this.fFormat, this.stringValue);
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

        public int length
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagENV.A_Length, FXmlTagENV.D_Length));
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

        public bool isArrayValue
        {
            get
            {
                FFormat fFormat;
                try
                {
                    fFormat = this.fFormat;
                    if (
                        fFormat == FFormat.List ||
                        fFormat == FFormat.AsciiList ||
                        fFormat == FFormat.Ascii ||
                        fFormat == FFormat.Char ||
                        fFormat == FFormat.JIS8 ||
                        fFormat == FFormat.A2 ||
                        fFormat == FFormat.Unknown ||
                        fFormat == FFormat.Raw
                        )
                    {
                        return false;
                    }

                    // --

                    if (this.length > 1)
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

        public bool isNullValue
        {
            get
            {
                try
                {
                    fFormat = this.fFormat;
                    if (
                        fFormat == FFormat.List ||
                        fFormat == FFormat.AsciiList ||
                        fFormat == FFormat.Unknown ||
                        fFormat == FFormat.Raw
                        )
                    {
                        return true;
                    }

                    // --

                    if (this.length == 0)
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

        public Type valueType
        {
            get
            {
                try
                {
                    return FValueConverter.getValueType(this.fFormat);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return typeof(object);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag1
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagENV.A_UserTag1, FXmlTagENV.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagENV.A_UserTag1, FXmlTagENV.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagENV.A_UserTag2, FXmlTagENV.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagENV.A_UserTag2, FXmlTagENV.D_UserTag2,value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagENV.A_UserTag3, FXmlTagENV.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagENV.A_UserTag3, FXmlTagENV.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagENV.A_UserTag4, FXmlTagENV.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagENV.A_UserTag4, FXmlTagENV.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagENV.A_UserTag5, FXmlTagENV.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagENV.A_UserTag5, FXmlTagENV.D_UserTag5, value, true);
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
        
        public FEnvironmentCollection fChildEnvironmentCollection
        {
            get
            {
                try
                {
                    return new FEnvironmentCollection(this.fScdCore, this.fXmlNode.selectNodes(FXmlTagENV.E_Environment));
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

        public FIObject fParent
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

                    if (this.fXmlNode.fParentNode.name == FXmlTagENL.E_EnvironmentList)
                    {
                        return new FEnvironmentList(this.fScdCore, this.fXmlNode.fParentNode);
                    }
                    return new FEnvironment(this.fScdCore, this.fXmlNode.fParentNode);
                }
                catch(Exception ex)
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

        public FEnvironment fPreviousSibling
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

                    return new FEnvironment(this.fScdCore, this.fXmlNode.fPreviousSibling);
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

        public FEnvironment fNextSibling
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

                    return new FEnvironment(this.fScdCore, this.fXmlNode.fNextSibling);
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
                    return this.fXmlNode.containsNode(FXmlTagENV.E_Environment);                    
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
                    if (this.fFormat == FFormat.List || this.fFormat == FFormat.AsciiList)
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

        public FEnvironmentList fAncestorEnvironmentList
        {
            get
            {
                try
                {
                    return this.getAncestorEnvironmentList();
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
                FEnvironmentList fEnl = null;
                string xpath = string.Empty;

                try
                {
                    fEnl = this.fAncestorEnvironmentList;
                    if (fEnl == null)
                    {
                        xpath = "NULL";
                    }
                    else
                    {
                        xpath =
                            "../../../" + FXmlTagEQM.E_EquipmentModeling +
                            "/" + FXmlTagEQP.E_Equipment +
                            "/" + FXmlTagSNG.E_ScenarioGroup +
                            "/" + FXmlTagSNR.E_Scenario +
                            "/" + FXmlTagSTR.E_SecsTrigger +
                            "/" + FXmlTagSCN.E_SecsCondition +
                            "//" + FXmlTagSEP.E_SecsExpression + "[@" + FXmlTagSEP.A_OperandId + "='" + this.uniqueIdToString + "']" +
                            " | " +
                            "../../../" + FXmlTagEQM.E_EquipmentModeling +
                            "/" + FXmlTagEQP.E_Equipment +
                            "/" + FXmlTagSNG.E_ScenarioGroup +
                            "/" + FXmlTagSNR.E_Scenario +
                            "/" + FXmlTagHTR.E_HostTrigger +
                            "/" + FXmlTagHCN.E_HostCondition +
                            "//" + FXmlTagHEP.E_HostExpression + "[@" + FXmlTagHEP.A_OperandId + "='" + this.uniqueIdToString + "']";
                    }
                    // --
                    return new FObjectCollection(this.fScdCore, fEnl.fXmlNode.selectNodes(xpath));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    fEnl = null;
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
                    if (
                        this.fXmlNode.fParentNode == null ||
                        !FClipboard.containsData(FCbObjectFormat.Environment)
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
                    if (
                        !FClipboard.containsData(FCbObjectFormat.Environment) ||
                        (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
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
            StringBuilder info = null;
            FFormat fFormat;
            string value = string.Empty;

            try
            {
                info = new StringBuilder();

                // --

                if (option == FStringOption.Default)
                {
                    info.Append(this.name);
                }
                else
                {
                    fFormat = this.fFormat;

                    // --

                    info.Append(FEnumConverter.fromFormat(fFormat) + "[" + this.length.ToString() + "]");
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        info.Append(" " + this.name);
                    }
                    else if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                    {
                        value = this.encodingValue;

                        // --

                        info.Append(" " + this.name + "=\"");
                        // --
                        if (value.Length > 1000)
                        {
                            info.Append(value.Substring(0, 1000));
                        }
                        else
                        {
                            info.Append(value);
                        }                        
                        // --
                        info.Append("\"");
                    }
                    else
                    {
                        value = this.stringValue;

                        // --                        

                        info.Append(" " + this.name + "=\"");
                        // --
                        if (value.Length > 1000)
                        {
                            info.Append(value.Substring(0, 1000));
                        }
                        else
                        {
                            info.Append(value);
                        }
                        // --
                        info.Append("\"");
                    }
                }

                // --

                if (this.description != string.Empty)
                {
                    info.Append(" Desc=[" + this.description + "]");
                }
                // --
                return info.ToString();
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

        public FEnvironment appendChildEnvironment(
            FEnvironment fNewChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                // --
                // ***
                // Format이 list인 Environment,만이  Child enviroment를 가질수 있다.
                // ***
                if(this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Environment's Format", "List or the AsciiList"));
                }

                // ***
                // Format이 AsciiList인 경우 Ascii Format의 Child Environment만을 가질 수 있다.
                // ***
                if (this.fFormat == FFormat.AsciiList && fNewChild.fFormat != FFormat.Ascii)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format of New Child", "Ascii"));
                }

                // -- 

                fNewChild.replace(this.fScdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));

                // --

                // ***
                // 현재 Environment의 Length 1증가
                // ***
                this.fXmlNode.set_attrVal(FXmlTagENV.A_Length, FXmlTagENV.D_Length, (this.length+1).ToString());

                // --

                if(this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fSecsDriver, this, fNewChild),
                        new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fSecsDriver, this.fParent, this)
                    });
                }

                // --

                return fNewChild;
            }
            catch(Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEnvironment insertBeforeChildEnvironment(
            FEnvironment fNewChild,
            FEnvironment fRefChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);
                // --
                if (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Environment's Format", "List or the AsciiList"));
                }

                // ***
                // Format이 AsciiList인 경우 Ascii Format의 Child Environment만을 가질 수 있다.
                // ***
                if (this.fFormat == FFormat.AsciiList && fNewChild.fFormat != FFormat.Ascii)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format of New Child", "Ascii"));
                }

                // --

                fNewChild.replace(this.fScdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));

                // --

                // ***
                // 현재 Environment 의 Length 1증가
                // ***
                this.fXmlNode.set_attrVal(FXmlTagENV.A_Length, FXmlTagENV.D_Length, (this.length + 1).ToString());

                // --

                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                        new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this.fSecsDriver, this, fNewChild),
                        new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fSecsDriver, this.fParent, this)
                        });
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

        public FEnvironment insertAfterChildEnvironment(
            FEnvironment fNewChild,
            FEnvironment fRefChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);
                // --
                if (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Environment's Format", "List or the AsciiList"));
                }

                // ***
                // Format이 AsciiList인 경우 Ascii Format의 Child Environment만을 가질 수 있다.
                // ***
                if (this.fFormat == FFormat.AsciiList && fNewChild.fFormat != FFormat.Ascii)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format of New Child", "Ascii"));
                }

                // -- 

                fNewChild.replace(this.fScdCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));

                // --

                // ***
                // 현재 Environment 의 Length 1증가
                // ***
                this.fXmlNode.set_attrVal(FXmlTagENV.A_Length, FXmlTagENV.D_Length, (this.length + 1).ToString());

                // --
                
                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(new FEventArgsBase[] {
                        new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this.fSecsDriver, this, fNewChild),
                        new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fSecsDriver, this.fParent, this)
                    });
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
            int length = 0;

            try
            {
                FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                fParent = this.fParent;
                if (fParent.fObjectType == FObjectType.EnvironmentList)
                {
                    this.replace(this.fScdCore, ((FEnvironmentList)fParent).fXmlNode.removeChild(this.fXmlNode));
                }
                else
                {
                    this.replace(this.fScdCore, ((FEnvironment)fParent).fXmlNode.removeChild(this.fXmlNode));
                    // --
                    length = int.Parse(((FEnvironment)fParent).fXmlNode.get_attrVal(FXmlTagENV.A_Length,FXmlTagENV.D_Length))-1;
                    ((FEnvironment)fParent).fXmlNode.set_attrVal(FXmlTagENV.A_Length, FXmlTagENV.D_Length, length.ToString());
                }

                // --

                if (isModelingObject)
                {
                    if (fParent.fObjectType == FObjectType.EnvironmentList)
                    {
                        this.fScdCore.fEventPusher.pushEvent(
                            new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fSecsDriver, fParent, this)
                            );
                    }
                    else
                    {
                        this.fScdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                            new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fSecsDriver, fParent, this),
                            new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fSecsDriver, ((FEnvironment)fParent).fParent, fParent)
                        });
                    }
                }
            }
            catch(Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEnvironment removeChildEnvironment(
            FEnvironment fChild
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

        public void removeChildEnvironment(
            FEnvironment[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FEnvironment fEnv in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode, fEnv.fXmlNode);
                }

                // --

                foreach (FEnvironment fEnv in fChilds)
                {
                    fEnv.remove();
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

        public void removeAllChildEnvironment(
            )
        {
            FEnvironmentCollection fEnvCollection = null;

            try
            {
                fEnvCollection = this.fChildEnvironmentCollection;
                if(fEnvCollection.count == 0)
                {
                    return;
                }

                // --

                foreach(FEnvironment fEnv in fEnvCollection)
                {
                    if(fEnv.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012,"object"));
                    }
                }

                // --

                foreach(FEnvironment fEnv in fEnvCollection)
                {
                    fEnv.remove();
                } 
            }
            catch(Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if(fEnvCollection != null)
                {
                    fEnvCollection.Dispose();
                    fEnvCollection = null;
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
            FEnvironment fRefObject
            )
        {
            FIObject fOldParent = null;

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

                if (this.containsObject(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "Child"));
                }

                // --

                fOldParent = this.fParent;

                // --                

                this.replace(this.fScdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fScdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                if (!this.fParent.Equals(fOldParent))
                {
                    if (this.locked)
                    {
                        if (fOldParent.fObjectType == FObjectType.EnvironmentList)
                        {
                            ((FEnvironmentList)fOldParent).unlockObject();
                        }
                        else
                        {
                            ((FEnvironment)fOldParent).unlockObject();
                        }
                        // --
                        if (this.fParent.fObjectType == FObjectType.EnvironmentList)
                        {
                            ((FEnvironmentList)this.fParent).lockObject();
                        }
                        else
                        {
                            ((FEnvironment)this.fParent).lockObject();
                        }
                    }

                    // --

                    if (fOldParent.fObjectType == FObjectType.Environment)
                    {
                        ((FEnvironment)fOldParent).fXmlNode.set_attrVal(FXmlTagENV.A_Length, FXmlTagENV.D_Length, (((FEnvironment)fOldParent).length - 1).ToString(), true);
                    }
                    // --
                    if (this.fParent.fObjectType == FObjectType.Environment)
                    {
                        ((FEnvironment)this.fParent).fXmlNode.set_attrVal(FXmlTagENV.A_Length, FXmlTagENV.D_Length, (((FEnvironment)this.fParent).length + 1).ToString(), true);
                    }
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
            FEnvironmentList fRefObject
            )
        {
            FIObject fOldParent = null;

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

                if (fRefObject.fChildEnvironmentCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildEnvironmentCollection[fRefObject.fChildEnvironmentCollection.count - 1]))
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

                if (!this.fParent.Equals(fOldParent))
                {
                    if (this.locked)
                    {
                        if (fOldParent.fObjectType == FObjectType.EnvironmentList)
                        {
                            ((FEnvironmentList)fOldParent).unlockObject();
                        }
                        else
                        {
                            ((FEnvironment)fOldParent).unlockObject();
                        }
                        // --                        
                        ((FEnvironmentList)this.fParent).lockObject();
                    }

                    // --

                    if (fOldParent.fObjectType == FObjectType.Environment)
                    {
                        ((FEnvironment)fOldParent).fXmlNode.set_attrVal(FXmlTagENV.A_Length, FXmlTagENV.D_Length, (((FEnvironment)fOldParent).length - 1).ToString(), true);
                    }
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

        private void setChangedFormat(
            )
        {
            try
            {
                this.fXmlNode.set_attrVal(FXmlTagENV.A_Value, FXmlTagENV.D_Value, FXmlTagENV.D_Value);
                this.fXmlNode.set_attrVal(FXmlTagENV.A_Length, FXmlTagENV.D_Length, FXmlTagENV.D_Length);
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

                // ***
                // Environment에 대한 Lock 처리
                // ***
                this.fXmlNode.set_attrVal(FXmlTagENV.A_Locked, FXmlTagENV.D_Locked, FBoolean.True, true);

                // --

                // ***
                // Parent에 대한 Lock 처리
                // ***
                if (this.fParent.fObjectType == FObjectType.EnvironmentList)
                {
                    ((FEnvironmentList)this.fParent).lockObject();
                }
                else
                {
                    ((FEnvironment)this.fParent).lockObject();
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
                // Lock이 설정된 자식 Environment가 존재할 경우 Unlock 작업을 취소한다.
                // ***
                xpath = FXmlTagENV.E_Environment + "[@" + FXmlTagENV.A_Locked + "='" + FBoolean.True + "']";
                if (this.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // ***
                // Environment가 SECS Expression이나 Host Expression에 사용되었을 경우 Unlock 작업을 취소한다.
                // ***
                xpath =
                    FXmlTagEQM.E_EquipmentModeling +
                    "/" + FXmlTagEQP.E_Equipment +
                    "/" + FXmlTagSNG.E_ScenarioGroup +
                    "/" + FXmlTagSNR.E_Scenario +
                    "/" + FXmlTagSTR.E_SecsTrigger +
                    "/" + FXmlTagSCN.E_SecsCondition +
                    "//" + FXmlTagSEP.E_SecsExpression + "[@" + FXmlTagSEP.A_OperandId + "='" + this.uniqueIdToString + "']" +
                    " | " +
                    FXmlTagEQM.E_EquipmentModeling +
                    "/" + FXmlTagEQP.E_Equipment +
                    "/" + FXmlTagSNG.E_ScenarioGroup +
                    "/" + FXmlTagSNR.E_Scenario +
                    "/" + FXmlTagHTR.E_HostTrigger +
                    "/" + FXmlTagHCN.E_HostCondition +
                    "//" + FXmlTagHEP.E_HostExpression + "[@" + FXmlTagHEP.A_OperandId + "='" + this.uniqueIdToString + "']";
                if (this.fSecsDriver.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // --

                // ***
                // Environment에 대한 Unlock 처리
                // ***
                this.fXmlNode.set_attrVal(FXmlTagENV.A_Locked, FXmlTagENV.D_Locked, FBoolean.False, true);

                // --

                // ***
                // Parent에 대한 Unlcok 처리
                // ***
                if (this.fParent.fObjectType == FObjectType.EnvironmentList)
                {
                    ((FEnvironmentList)this.fParent).unlockObject();
                }
                else
                {
                    ((FEnvironment)this.fParent).unlockObject();
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

        public void cut(
            )
        {
            try
            {
                FSecsDriverCommon.validateCutObject(this.fXmlNode);

                // --

                this.remove();
                this.copyObject(FCbObjectFormat.Environment, this.fXmlNode);
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

                this.copyObject(FCbObjectFormat.Environment, fXmlNode);
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

        public FEnvironment pasteSibling(
            )
        {
            FEnvironment fEnvironment = null;

            try
            {
                FSecsDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.Environment);

                // --

                fEnvironment = (FEnvironment)this.pasteObject(FCbObjectFormat.Environment);
                if (this.fParent.fObjectType == FObjectType.EnvironmentList)
                {
                    return ((FEnvironmentList)this.fParent).insertAfterChildEnvironment(fEnvironment, this);
                }
                return ((FEnvironment)this.fParent).insertAfterChildEnvironment(fEnvironment, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEnvironment = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEnvironment pasteChild(
            )
        {
            FEnvironment fEnvironment = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.Environment);

                // --

                fEnvironment = (FEnvironment)this.pasteObject(FCbObjectFormat.Environment);
                return this.appendChildEnvironment(fEnvironment);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEnvironment = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEnvironmentCollection selectEnvironmentByName(
            string name
            )
        {
            const string xpath = FXmlTagENV.E_Environment + "[@" + FXmlTagENV.A_Name + "='{0}']";

            try
            {
                return new FEnvironmentCollection(
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

        public FEnvironment selectSingleEnvironmentByName(
            string name
            )
        {
            const string xpath = FXmlTagENV.E_Environment + "[@" + FXmlTagENV.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FEnvironment(this.fScdCore, fXmlNode);
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

        public FEnvironmentCollection selectAllEnvironmentByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagENV.E_Environment + "[@" + FXmlTagENV.A_Name + "='{0}']";

            try
            {
                return new FEnvironmentCollection(
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

        public FEnvironment selectSingleAllEnvironmentByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagENV.E_Environment + "[@" + FXmlTagENV.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FEnvironment(this.fScdCore, fXmlNode);
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

        public FEnvironment selectSingleAllEnvironmentByIndex(
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
                return new FEnvironment(this.fScdCore, fXmlNode);
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

    }    // Class end
}    // Namespace end
