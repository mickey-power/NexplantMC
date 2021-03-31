/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlDocument.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.24
--  Description     : FAMate Core FaCommon XML Document Class
--  History         : Created by spike.lee at 2010.12.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Nexplant.MC.Core.FaCommon
{
    public class FXmlDocument : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FXmlCore m_fXmlCore = null;
        private XmlDocument m_xmlDoc = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FXmlDocument(
            )
        {
            m_fXmlCore = new FXmlCore(this);
            m_xmlDoc = new XmlDocument();            
        }

        //------------------------------------------------------------------------------------------------------------------------       

        internal FXmlDocument(
            XmlDocument xmlDoc
            )
        {
            m_fXmlCore = new FXmlCore(this);
            m_xmlDoc = xmlDoc;            
        }

        //------------------------------------------------------------------------------------------------------------------------       

        ~FXmlDocument(
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
                    m_xmlDoc = null;
                    // --
                    if (m_fXmlCore != null)
                    {
                        m_fXmlCore.Dispose();
                        m_fXmlCore = null;
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

        internal XmlDocument baseXml
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    return m_xmlDoc;
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
                    return m_xmlDoc.Name;
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

        public bool preserveWhiteSpace
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    return m_xmlDoc.PreserveWhitespace;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    m_fXmlCore.set();
                }
                return false;
            }

            set
            {
                try
                {
                    m_fXmlCore.wait();
                    m_xmlDoc.PreserveWhitespace = value;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlAttributeCollection fAttributes
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    return new FXmlAttributeCollection(m_fXmlCore, m_xmlDoc.Attributes);
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

        public bool hasChildNode
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    return m_xmlDoc.HasChildNodes;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    m_fXmlCore.set();
                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlNodeList fChildNodes
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();                        
                    return new FXmlNodeList(m_fXmlCore, m_xmlDoc.ChildNodes);
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

        public FXmlNode fFirstChild
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    if (m_xmlDoc.FirstChild == null)
                    {
                        return null;
                    }
                    return new FXmlNode(m_fXmlCore, m_xmlDoc.FirstChild);
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

        public FXmlNode fLastChild
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    if (m_xmlDoc.LastChild == null)
                    {
                        return null;
                    }
                    return new FXmlNode(m_fXmlCore, m_xmlDoc.LastChild);
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

        public string outerXml
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    return m_xmlDoc.OuterXml;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public void load(
            string fileName
            )
        {
            try
            {
                m_fXmlCore.wait();
                m_xmlDoc.Load(fileName);
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

        //------------------------------------------------------------------------------------------------------------------------

        public void loadXml(
            string xml
            )
        {
            try
            {
                m_fXmlCore.wait();
                m_xmlDoc.LoadXml(xml);
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

        //------------------------------------------------------------------------------------------------------------------------

        public void save(
            string fileName
            )
        {
            try
            {
                m_fXmlCore.wait();
                m_xmlDoc.Save(fileName);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlDocument clone(
            bool deep
            )
        {
            try
            {
                m_fXmlCore.wait();
                return new FXmlDocument((XmlDocument)m_xmlDoc.CloneNode(deep));
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

        public FXmlNode createXmlDeclaration(
            string version, 
            string encoding, 
            string standalone
            )
        {
            try
            {
                m_fXmlCore.wait();
                return new FXmlNode(
                    m_fXmlCore, 
                    (XmlNode)m_xmlDoc.CreateXmlDeclaration(version, encoding, standalone)
                    );
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

        public FXmlNode createNode(
            string name
            )
        {
            try
            {
                m_fXmlCore.wait();
                return new FXmlNode(
                    m_fXmlCore,
                    m_xmlDoc.CreateNode(XmlNodeType.Element, name, string.Empty)
                    );
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

        public FXmlComment createComment(
            string data
            )
        {
            try
            {
                m_fXmlCore.wait();
                return new FXmlComment(
                    m_fXmlCore,
                    m_xmlDoc.CreateComment(data)
                    );
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

        public FXmlAttribute createAttribute(
            string name
            )
        {
            try
            {
                m_fXmlCore.wait();
                return new FXmlAttribute(m_fXmlCore, m_xmlDoc.CreateAttribute(name));
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

        public FXmlNode appendChild(
            FXmlNode newChild
            )
        {
            XmlNode xmlNode = null;

            try
            {
                m_fXmlCore.wait();
                if (m_xmlDoc.Equals(newChild.baseXml.OwnerDocument))
                {
                    xmlNode = m_xmlDoc.AppendChild(newChild.baseXml);
                }
                else
                {
                    xmlNode = m_xmlDoc.AppendChild(m_xmlDoc.ImportNode(newChild.baseXml, true));
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

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlNode insertBefore(
            FXmlNode newChild,
            FXmlNode refChild
            )
        {
            XmlNode xmlNode = null;

            try
            {
                m_fXmlCore.wait();
                if (m_xmlDoc.Equals(newChild.baseXml.OwnerDocument))
                {
                    xmlNode = m_xmlDoc.InsertBefore(newChild.baseXml, refChild.baseXml);
                }
                else
                {
                    xmlNode = m_xmlDoc.InsertBefore(m_xmlDoc.ImportNode(newChild.baseXml, true), refChild.baseXml);
                }
                return new FXmlNode(m_fXmlCore, xmlNode);
            }
            catch (FException ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fXmlCore.set();
            }
            return null;
        }

        ////------------------------------------------------------------------------------------------------------------------------

        //public FXmlNode insertBefore(
        //    FXmlComment newChild,
        //    FXmlNode refChild
        //    )
        //{
        //    XmlNode xmlNode = null;

        //    try
        //    {
        //        m_fXmlCore.wait();
        //        if (m_xmlDoc.Equals(newChild.baseXml.OwnerDocument))
        //        {
        //            xmlNode = m_xmlDoc.InsertBefore(newChild.baseXml, refChild.baseXml);
        //        }
        //        else
        //        {
        //            xmlNode = m_xmlDoc.InsertBefore(m_xmlDoc.ImportNode(newChild.baseXml, true), refChild.baseXml);
        //        }
        //        return new FXmlNode(m_fXmlCore, xmlNode);
        //    }
        //    catch (FException ex)
        //    {
        //        FDebug.throwException(ex);
        //    }
        //    finally
        //    {
        //        m_fXmlCore.set();
        //    }
        //    return null;
        //}

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlNode insertAfter(
            FXmlNode newChild,
            FXmlNode refChild
            )
        {
            XmlNode xmlNode = null;

            try
            {
                m_fXmlCore.wait();
                if (m_xmlDoc.Equals(newChild.baseXml.OwnerDocument))
                {
                    xmlNode = m_xmlDoc.InsertAfter(newChild.baseXml, refChild.baseXml);
                }
                else
                {
                    xmlNode = m_xmlDoc.InsertAfter(m_xmlDoc.ImportNode(newChild.baseXml, true), refChild.baseXml);
                }
                return new FXmlNode(m_fXmlCore, xmlNode);
            }
            catch (FException ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fXmlCore.set();
            }
            return null;
        }

        ////------------------------------------------------------------------------------------------------------------------------

        public FXmlNode insertAfter(
            FXmlComment newChild,
            FXmlNode refChild
            )
        {
            XmlNode xmlNode = null;

            try
            {
                m_fXmlCore.wait();
                if (m_xmlDoc.Equals(newChild.baseXml.OwnerDocument))
                {
                    xmlNode = m_xmlDoc.InsertAfter(newChild.baseXml, refChild.baseXml);
                }
                else
                {
                    xmlNode = m_xmlDoc.InsertAfter(m_xmlDoc.ImportNode(newChild.baseXml, true), refChild.baseXml);
                }
                return new FXmlNode(m_fXmlCore, xmlNode);
            }
            catch (FException ex)
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

        public FXmlNode removeChild(
            FXmlNode oldChild
            )
        {
            XmlNode xmlNode = null;

            try
            {
                m_fXmlCore.wait();
                xmlNode = m_xmlDoc.RemoveChild(oldChild.baseXml);
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

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAll(
            )
        {
            try
            {
                m_fXmlCore.wait();
                m_xmlDoc.RemoveAll();
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

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlNode selectSingleNode(
            string xpath
            )
        {
            XmlNode xmlNode = null;

            try
            {
                m_fXmlCore.wait();
                xmlNode = m_xmlDoc.SelectSingleNode(xpath);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlNodeList selectNodes(
            string xpath
            )
        {
            try
            {
                m_fXmlCore.wait();
                return new FXmlNodeList(m_fXmlCore, m_xmlDoc.SelectNodes(xpath));
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

        public string xmlToString(
            bool preserveWhiteSpace
            )
        {
            XmlWriter xmlWriter = null;
            XmlWriterSettings settings = null;
            StringBuilder stringBuilder = null;
            
            try
            {
                m_fXmlCore.wait();

                if (!preserveWhiteSpace)
                {
                    return this.outerXml;
                }

                settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "\t";
                settings.NewLineHandling = NewLineHandling.Replace;                
                settings.CheckCharacters = false;
                // --
                stringBuilder = new StringBuilder();
                xmlWriter = XmlWriter.Create(stringBuilder, settings);
                // --
                m_xmlDoc.Save(xmlWriter);

                // --

                return stringBuilder.ToString();
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
                if (obj == null || !(obj is FXmlDocument))
                {
                    return false;
                }

                return m_xmlDoc.Equals(
                    ((FXmlDocument)obj).baseXml
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
            FXmlDocument lhs,
            FXmlDocument rhs
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
            FXmlDocument lhs,
            FXmlDocument rhs
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
