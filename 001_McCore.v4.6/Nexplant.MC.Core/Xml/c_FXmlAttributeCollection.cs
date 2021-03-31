/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlAttributeCollection.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.27
--  Description     : FAMate Core FaCommon XML Attribute Collection Class
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
    public class FXmlAttributeCollection : IDisposable, IEnumerable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FXmlCore m_fXmlCore = null;
        private XmlAttributeCollection m_xmlAttrCol = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FXmlAttributeCollection(
            FXmlCore fXmlCore,
            XmlAttributeCollection xmlAttrCol
            )
        {
            m_fXmlCore = fXmlCore;
            m_xmlAttrCol = xmlAttrCol;
        }
        
        //------------------------------------------------------------------------------------------------------------------------       

        ~FXmlAttributeCollection(
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
                    m_xmlAttrCol = null;                    
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
                return new FXmlAttributeCollectionEnumerator(this);
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

        internal XmlAttributeCollection baseXml
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    return m_xmlAttrCol;
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
                    return m_xmlAttrCol.Count;
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

        public FXmlAttribute this[int i]
        {
            get
            {
                XmlAttribute xmlAttr = null;

                try
                {
                    m_fXmlCore.wait();
                    xmlAttr = m_xmlAttrCol[i];
                    if (xmlAttr == null)
                    {
                        return null;
                    }                    
                    return new FXmlAttribute(m_fXmlCore, xmlAttr);
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

        public FXmlAttribute this[string name]
        {
            get
            {
                XmlAttribute xmlAttr = null;

                try
                {
                    m_fXmlCore.wait();
                    xmlAttr = m_xmlAttrCol[name];
                    if (xmlAttr == null)
                    {
                        return null;
                    }
                    return new FXmlAttribute(m_fXmlCore, xmlAttr);
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

        public FXmlAttribute item(
            int index
            )
        {
            XmlAttribute xmlAttr = null;

            try
            {
                m_fXmlCore.wait();
                xmlAttr = (XmlAttribute)m_xmlAttrCol.Item(index);                
                if (xmlAttr == null)
                {
                    return null;
                }
                return new FXmlAttribute(m_fXmlCore, xmlAttr);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlAttribute getNamedItem(
            string name
            )
        {
            XmlAttribute xmlAttr = null;

            try
            {
                m_fXmlCore.wait();
                xmlAttr = (XmlAttribute)m_xmlAttrCol.GetNamedItem(name);
                if (xmlAttr == null)
                {
                    return null;
                }
                return new FXmlAttribute(m_fXmlCore, xmlAttr);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlAttribute setNamedItem(
            FXmlAttribute fXmlAttr
            )
        {
            XmlAttribute xmlAttr = null;

            try
            {
                m_fXmlCore.wait();
                xmlAttr = (XmlAttribute)m_xmlAttrCol.SetNamedItem(fXmlAttr.baseXml);
                if (xmlAttr == null)
                {
                    return null;
                }
                return new FXmlAttribute(m_fXmlCore, xmlAttr);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlAttribute removeNamedItem(
            string name
            )
        {
            XmlAttribute xmlAttr = null;

            try
            {
                m_fXmlCore.wait();
                xmlAttr = (XmlAttribute)m_xmlAttrCol.RemoveNamedItem(name);
                if (xmlAttr == null)
                {
                    return null;
                }
                return new FXmlAttribute(m_fXmlCore, xmlAttr);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlAttribute append(
            FXmlAttribute fXmlAttr
            )
        {
            XmlAttribute xmlAttr = null;

            try
            {
                m_fXmlCore.wait();
                xmlAttr = m_xmlAttrCol.Append(fXmlAttr.baseXml);
                if (xmlAttr == null)
                {
                    return null;
                }
                return new FXmlAttribute(m_fXmlCore, xmlAttr);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlAttribute remove(
            FXmlAttribute fXmlAttr
            )
        {
            XmlAttribute xmlAttr = null;

            try
            {
                m_fXmlCore.wait();
                xmlAttr = m_xmlAttrCol.Remove(fXmlAttr.baseXml);
                if (xmlAttr == null)
                {
                    return null;
                }
                return new FXmlAttribute(m_fXmlCore, xmlAttr);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlAttribute removeAt(
            int i
            )
        {
            XmlAttribute xmlAttr = null;

            try
            {
                m_fXmlCore.wait();
                xmlAttr = m_xmlAttrCol.RemoveAt(i);
                if (xmlAttr == null)
                {
                    return null;
                }
                return new FXmlAttribute(m_fXmlCore, xmlAttr);
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

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAll(
            )
        {
            try
            {
                m_fXmlCore.wait();
                m_xmlAttrCol.RemoveAll();
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
                if (obj == null || !(obj is FXmlAttributeCollection))
                {
                    return false;
                }

                return m_xmlAttrCol.Equals(
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
            FXmlAttributeCollection lhs,
            FXmlAttributeCollection rhs
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
            FXmlAttributeCollection lhs,
            FXmlAttributeCollection rhs
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
