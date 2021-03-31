/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpItemPrecondition.cs
--  Creator         : spike.lee
--  Create Date     : 2016.04.12
--  Description     : FAMate Core FaTcpDriver TCP Item Precondition Class 
--  History         : Created by spike.lee at 2016.04.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public class FTcpItemLogPrecondition : FIPreconditionLog, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcpItemLog m_fTitl = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FTcpItemLogPrecondition(
            FTcpItemLog fTitl
            )
        {
            m_fTitl = fTitl;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpItemLogPrecondition(
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
                    m_fTitl = null;
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
                    return m_fTitl.fFormat;
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
                    return new FTcpItemPreconditionValueCollection(m_fTitl.fXmlNode);
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
                fFormat = m_fTitl.fFormat;

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
                val = m_fTitl.fXmlNode.get_attrVal(FXmlTagTIT.A_Precondition, FXmlTagTIT.D_Precondition);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
