/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHostItemPrecondition.cs
--  Creator         : Kimsh
--  Create Date     : 2011.03.10
--  Description     : FAMate Core FaTcpDriver Host Item Precondition Class 
--  History         : Created by Kimsh at 2011.03.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public class FHostItemPrecondition : FIPrecondition, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FHostItem m_fHit = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FHostItemPrecondition(
            FHostItem fHit
            )
        {
            m_fHit = fHit;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHostItemPrecondition(
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
                    m_fHit = null;
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

        public FFormat fFormat
        {
            get
            {
                try
                {
                    return m_fHit.fFormat;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIPreconditionValueCollection fPreconditionValueCollection
        {
            get
            {
                try
                {
                    return new FHostItemPreconditionValueCollection(m_fHit.fXmlNode);
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

        public bool canInsertBeforeValue
        {
            get
            {
                FFormat fFormat;
                List<string> valueList = null;

                try
                {
                    fFormat = m_fHit.fFormat;
                    // --
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        return false;
                    }

                    // --

                    valueList = getValueList();
                    // --
                    if (valueList.Count == 0)
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
                
                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canInsertAfterValue
        {
            get
            {
                try
                {
                    return canInsertBeforeValue;
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

        public bool canAppendValue
        {
            get
            {
                FFormat fFormat;

                try
                {

                    fFormat = m_fHit.fFormat;
                    // --
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
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

        public bool canReplaceValue
        {
            get
            {
                try
                {
                    return canInsertBeforeValue;
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

        public bool canRemoveValue
        {
            get
            {
                FFormat fFormat;
                List<string> valueList = null;

                try
                {

                    fFormat = m_fHit.fFormat;
                    // --
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        return false;
                    }

                    // --

                    valueList = getValueList();
                    // --
                    if (valueList.Count == 0)
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
                
                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canRemoveAllValue
        {
            get
            {
                FFormat fFormat;

                try
                {

                    fFormat = m_fHit.fFormat;
                    // --
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
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

        public override string ToString(
            )
        {
            List<string> valueList = null;
            StringBuilder info = null;

            try
            {
                valueList = getValueList();

                // --

                info = new StringBuilder();
                foreach (string value in valueList)
                {
                    info.Append(value);
                    info.Append(";");
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
                valueList = null;
                info = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void validateFormat(
            )
        {
            FFormat fFormat;

            try
            {
                fFormat = m_fHit.fFormat;

                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Value Formula"));
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

        private List<string> getValueList(
            )
        {
            string val = string.Empty;

            try
            {
                val = m_fHit.fXmlNode.get_attrVal(FXmlTagHIT.A_Precondition, FXmlTagHIT.D_Precondition);
                if (val == string.Empty)
                {
                    return new List<string>();
                }
                else
                {
                    return new List<string>(val.Split(FConstants.PreconditionValueSeparator));
                }
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

        private void setValueList(
            List<string> valueList
            )
        {
            try
            {
                m_fHit.fXmlNode.set_attrVal(
                    FXmlTagHIT.A_Precondition,
                    FXmlTagHIT.D_Precondition,
                    string.Join(FConstants.PreconditionValueSeparator.ToString(), valueList.ToArray()),
                    true
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

        public string insertBeforeStringValue(
            int index,
            string value
            )
        {
            List<string> valueList = null;
            FFormat fFormat;
            int length = 0;

            try
            {
                validateFormat();

                // --

                valueList = getValueList();
                // --
                if (index < 0 || index >= valueList.Count)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                }// --
                fFormat = this.fFormat;
                value = FValueConverter.fromStringValue(fFormat, value, out length);
                if (length == 0)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0006, "Precondition value", "null"));
                }
                else if (length > 1)
                {
                    if (fFormat != FFormat.Ascii && fFormat != FFormat.JIS8 && fFormat != FFormat.A2)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "Precondition value", "Array"));
                    }
                }

                // --

                valueList.Insert(index, value);
                setValueList(valueList);

                // --

                return value;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueList = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public object insertBeforeValue(
            int index,
            object value
            )
        {
            List<string> valueList = null;
            FFormat fFormat;
            string stringValue = string.Empty;
            int length = 0;

            try
            {
                validateFormat();

                // --

                valueList = getValueList();
                // --
                if (index < 0 || index >= valueList.Count)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                }
                // --
                fFormat = this.fFormat;
                stringValue = FValueConverter.fromValue(fFormat, value, out length);
                if (length == 0)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0006, "Precondition Value", "Null"));
                }
                else if (length > 1)
                {
                    if (fFormat != FFormat.Ascii && fFormat != FFormat.JIS8 && fFormat != FFormat.A2)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "Precondition Value", "Array"));
                    }
                }

                // --

                valueList.Insert(index, stringValue);
                setValueList(valueList);

                // --

                return value;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueList = null;            
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string insertAfterStringValue(
            int index,
            string value
            )
        {
            List<string> valueList = null;
            FFormat fFormat;
            int length = 0;

            try
            {
                validateFormat();

                // --

                valueList = getValueList();
                // --
                if (index < 0 || index >= valueList.Count)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                }
                // --
                fFormat = this.fFormat;
                value = FValueConverter.fromStringValue(fFormat, value, out length);
                if (length == 0)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0006, "Precondition Value", "null"));
                }
                else if (length > 1)
                {
                    if (fFormat != FFormat.Ascii && fFormat != FFormat.JIS8 && fFormat != FFormat.A2)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "Precondition Value", "Array"));
                    }
                }

                // --

                valueList.Insert(index + 1, value);
                setValueList(valueList);

                // --

                return value;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueList = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public object insertAfterValue(
            int index,
            object value
            )
        {
            List<string> valueList = null;
            FFormat fFormat;
            string stringValue = string.Empty;
            int length = 0;

            try
            {
                validateFormat();

                // --

                valueList = getValueList();
                // --
                if (index < 0 || index >= valueList.Count)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                }
                // --
                fFormat = this.fFormat;
                stringValue = FValueConverter.fromValue(fFormat, value, out length);
                if (length == 0)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0006, "Precondition Value", "Null"));
                }
                else if (length > 1)
                {
                    if (fFormat != FFormat.Ascii && fFormat != FFormat.JIS8 && fFormat != FFormat.A2)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "Precondition Value", "Array"));
                    }
                }

                // --

                valueList.Insert(index + 1, stringValue);
                setValueList(valueList);

                // --

                return value;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string appendStringValue(
            string value
            )
        {
            List<string> valueList = null;
            FFormat fFormat;
            int length = 0;

            try
            {
                validateFormat();

                // --

                valueList = getValueList();
                // --
                fFormat = this.fFormat;
                value = FValueConverter.fromStringValue(fFormat, value, out length);
                if (length == 0)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0006, "Precondition Value", "Null"));
                }
                else if (length > 1)
                {
                    if (fFormat != FFormat.Ascii && fFormat != FFormat.JIS8 && fFormat != FFormat.A2)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "Precondition Value", "Array"));
                    }
                }

                // --

                valueList.Add(value);
                setValueList(valueList);

                // --

                return value;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueList = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public object appendValue(
            object value
            )
        {
            List<string> valueList = null;
            FFormat fFormat;
            string stringValue = string.Empty;
            int length = 0;

            try
            {
                validateFormat();

                // --

                valueList = getValueList();
                // --
                fFormat = this.fFormat;
                stringValue = FValueConverter.fromValue(fFormat, value, out length);
                if (length == 0)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0006, "Precondition Value", "Null"));
                }
                else if (length > 1)
                {
                    if (fFormat != FFormat.Ascii && fFormat != FFormat.JIS8 && fFormat != FFormat.A2)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "Precondition Value", "Array"));
                    }
                }

                // --

                valueList.Add(stringValue);
                setValueList(valueList);

                // --

                return value;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string replaceStringValue(
            int index,
            string value
            )
        {
            List<string> valueList = null;
            FFormat fFormat;
            int length = 0;

            try
            {
                validateFormat();

                // --

                valueList = getValueList();
                // --
                if (index < 0 || index >= valueList.Count)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                }
                // --
                fFormat = this.fFormat;
                value = FValueConverter.fromStringValue(fFormat, value, out length);
                if (length == 0)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0006, "Precondition Value", "Null"));
                }
                else if (length > 1)
                {
                    if (fFormat != FFormat.Ascii && fFormat != FFormat.JIS8 && fFormat != FFormat.A2)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "Precondition Value", "Array"));
                    }
                }

                // --

                valueList[index] = value;
                setValueList(valueList);

                // --

                return value;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueList = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public object replaceValue(
            int index,
            object value
            )
        {
            List<string> valueList = null;
            FFormat fFormat;
            string stringValue = string.Empty;
            int length = 0;

            try
            {
                validateFormat();

                // --

                valueList = getValueList();
                // --
                if (index < 0 || index > valueList.Count)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                }
                // --
                fFormat = this.fFormat;
                stringValue = FValueConverter.fromValue(fFormat, value, out length);
                if (length == 0)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0006, "Precondition Value", "Null"));
                }
                else if (length > 1)
                {
                    if (fFormat != FFormat.Ascii && fFormat != FFormat.JIS8 && fFormat != FFormat.A2)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "Precondition Value", "Array"));
                    }
                }

                // --

                valueList[index] = stringValue;
                setValueList(valueList);

                // --

                return value;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string removeStringValue(
            int index
            )
        {
            List<string> valueList = null;
            string value = string.Empty;

            try
            {
                validateFormat();

                // --

                valueList = getValueList();
                // --
                if (index < 0 || index >= valueList.Count)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                }
                // --
                value = valueList[index];
                valueList.RemoveAt(index);
                setValueList(valueList);

                // --

                return value;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueList = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public object removeValue(
            int index
            )
        {
            List<string> valueList = null;
            string value = string.Empty;

            try
            {
                validateFormat();

                // --

                valueList = getValueList();
                // --
                if (index < 0 || index >= valueList.Count)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                }
                // --
                value = valueList[index];
                valueList.RemoveAt(index);
                setValueList(valueList);

                // --

                return FValueConverter.toValue(this.fFormat, value, 1);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAllValue(
            )
        {
            try
            {
                validateFormat();

                // --

                setValueList(new List<string>());
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

        public string moveUpStringValue(
            int index
            )
        {
            List<string> valueList = null;
            string value = string.Empty;

            try
            {
                validateFormat();

                // --

                valueList = getValueList();
                if (index <= 0 || index >= valueList.Count)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                }

                // --

                value = valueList[index];
                valueList.RemoveAt(index);
                valueList.Insert(--index, value);
                setValueList(valueList);

                // --

                return value;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueList = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public object moveUpValue(
            int index
            )
        {
            List<string> valueList = null;
            string value = string.Empty;

            try
            {
                validateFormat();

                // --

                valueList = getValueList();
                if (index <= 0 || index >= valueList.Count)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                }

                // --

                value = valueList[index];
                valueList.RemoveAt(index);
                valueList.Insert(--index, value);
                setValueList(valueList);

                // --

                return FValueConverter.toValue(this.fFormat, value, 1);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string moveDownStringValue(
            int index
            )
        {
            List<string> valueList = null;
            string value = string.Empty;

            try
            {
                validateFormat();

                // --

                valueList = getValueList();
                if (index < 0 || index >= valueList.Count - 1)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                }

                // --

                value = valueList[index];
                valueList.RemoveAt(index);
                valueList.Insert(++index, value);
                setValueList(valueList);

                // --

                return value;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueList = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public object moveDownValue(
            int index
            )
        {
            List<string> valueList = null;
            string value = string.Empty;

            try
            {
                validateFormat();

                // --

                valueList = getValueList();
                if (index < 0 || index >= valueList.Count - 1)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                }

                // --

                value = valueList[index];
                valueList.RemoveAt(index);
                valueList.Insert(++index, value);
                setValueList(valueList);

                // --

                return FValueConverter.toValue(this.fFormat, value, 1);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueList = null;
            }
            return string.Empty;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
