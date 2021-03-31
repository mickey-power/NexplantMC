/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsItemLogPrecondition.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2011.10.19
--  Description     : FAMate Core FaSecsDriver SECS Item Log Precondition Class 
--  History         : Created by byungyun.jeon at 2011.10.19
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FSecsItemLogPrecondition : FIPreconditionLog, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FSecsItemLog m_fSitl = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FSecsItemLogPrecondition(            
            FSecsItemLog fSitl
            )            
        {
            m_fSitl = fSitl;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsItemLogPrecondition(
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
                    m_fSitl = null;
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
                    return m_fSitl.fFormat;
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
                    return new FSecsItemPreconditionValueCollection(m_fSitl.fXmlNode);
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
                fFormat = m_fSitl.fFormat;

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
                val = m_fSitl.fXmlNode.get_attrVal(FXmlTagSIT.A_Precondition, FXmlTagSIT.D_Precondition);
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
