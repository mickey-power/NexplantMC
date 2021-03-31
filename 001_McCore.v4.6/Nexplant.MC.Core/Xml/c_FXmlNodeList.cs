/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlNodeList.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.27
--  Description     : FAMate Core FaCommon XML Node List Class
--  History         : Created by spike.lee at 2010.12.27
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Xml;

namespace Nexplant.MC.Core.FaCommon
{
    public class FXmlNodeList : IDisposable, IEnumerable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FXmlCore m_fXmlCore = null;
        private XmlNodeList m_xmlNodeList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FXmlNodeList(
            FXmlCore fXmlCore,
            XmlNodeList xmlNodeList
            )
        {
            m_fXmlCore = fXmlCore;
            m_xmlNodeList = xmlNodeList;
        }
        
        //------------------------------------------------------------------------------------------------------------------------       

        ~FXmlNodeList(
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
                    m_xmlNodeList = null;                    
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

        #region IEnumerable 멤버

        public IEnumerator GetEnumerator(
            )
        {
            try
            {
                return new FXmlNodeListEnumerator(this);
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

        #region Properties

        internal XmlNodeList baseXml
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    return m_xmlNodeList;
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

        public int count
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    return m_xmlNodeList.Count;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    m_fXmlCore.set();
                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlNode this[int i]
        {
            get
            {
                XmlNode xmlNode = null;

                try
                {
                    m_fXmlCore.wait();
                    xmlNode = m_xmlNodeList[i];
                    if (xmlNode == null)
                    {
                        return null;
                    }
                    return new FXmlNode(m_fXmlCore, xmlNode);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public FXmlNode item(
            int index
            )
        {
            XmlNode xmlNode = null;

            try
            {
                m_fXmlCore.wait();
                xmlNode = m_xmlNodeList.Item(index);
                if (xmlNode == null)
                {
                    return null;
                }
                return new FXmlNode(m_fXmlCore, xmlNode);
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
                if (obj == null || !(obj is FXmlNodeList))
                {
                    return false;
                }

                return m_xmlNodeList.Equals(
                    ((FXmlNodeList)obj).baseXml
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
            FXmlNodeList lhs,
            FXmlNodeList rhs
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
            FXmlNodeList lhs,
            FXmlNodeList rhs
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
