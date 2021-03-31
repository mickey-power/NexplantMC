/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlAttribute.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.27
--  Description     : FAMate Core FaCommon XML Attribute Class
--  History         : Created by spike.lee at 2010.12.27
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Nexplant.MC.Core.FaCommon
{
    public class FXmlAttribute : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FXmlCore m_fXmlCore = null;
        private XmlAttribute m_xmlAttr = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FXmlAttribute(
            FXmlCore fXmlCore,
            XmlAttribute xmlAttr
            )
        {
            m_fXmlCore = fXmlCore;
            m_xmlAttr = xmlAttr;
        }
        
        //------------------------------------------------------------------------------------------------------------------------       

        ~FXmlAttribute(
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
                    m_xmlAttr = null;                    
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

        internal XmlAttribute baseXml
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    return m_xmlAttr;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    m_fXmlCore.set();
                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string name
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    return m_xmlAttr.Name;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    m_fXmlCore.set();
                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string value
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    return m_xmlAttr.Value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    m_fXmlCore.set();
                }
                return string.Empty;
            }

            set
            {
                try
                {
                    m_fXmlCore.wait();
                    m_xmlAttr.Value = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    m_fXmlCore.set();
                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Instance Comparison Method

        public override int GetHashCode(
            )
        {
            try
            {
                return base.GetHashCode();
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

        //------------------------------------------------------------------------------------------------------------------------

        public override bool Equals(
           object obj
           )
        {
            try
            {
                if (obj == null || !(obj is FXmlAttribute))
                {
                    return false;
                }

                return m_xmlAttr.Equals(
                    ((FXmlAttribute)obj).baseXml
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

        public static bool operator ==(
            FXmlAttribute lhs,
            FXmlAttribute rhs
            )
        {
            try
            {
                if ((object)lhs == null)
                {
                    return ((object)rhs == null ? true : false);
                }
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
            FXmlAttribute lhs,
            FXmlAttribute rhs
            )
        {
            try
            {
                if ((object)lhs == null)
                {
                    return ((object)rhs == null ? false : true);
                }
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
