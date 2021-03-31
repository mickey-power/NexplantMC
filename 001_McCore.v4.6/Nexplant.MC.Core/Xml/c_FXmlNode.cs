/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlNode.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.24
--  Description     : FAMate Core FaCommon XML Node Class
--  History         : Created by spike.lee at 2010.12.24
--                  : Modified by spike.lee at 2011.01.31
--                    - FXmlNode Modified Event add
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Nexplant.MC.Core.FaCommon
{
    public class FXmlNode : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FXmlNodeModifiedEventHandler XmlNodeModified = null;

        // ***
        // Attribute Element를 지원하기 위한 Value Name
        // ***
        private const string A_Value = "v";

        private bool m_disposed = false;
        // --
        private FXmlCore m_fXmlCore = null;
        private XmlNode m_xmlNode = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FXmlNode(
            FXmlCore fXmlCore,
            XmlNode xmlNode
            )
        {
            m_fXmlCore = fXmlCore;
            m_xmlNode = xmlNode;
        }
        
        //------------------------------------------------------------------------------------------------------------------------       

        ~FXmlNode(
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
                    m_xmlNode = null;                    
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

        internal XmlNode baseXml
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    return m_xmlNode;
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
                    return m_xmlNode.Name;
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
                    return m_xmlNode.Value;
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
                    m_xmlNode.Value = value;
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

        public FXmlDocument fOwnerDocument
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    return m_fXmlCore.xmlDocument;
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

        public FXmlNode fParentNode
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    if (m_xmlNode.ParentNode == null)
                    {
                        return null;
                    }
                    return new FXmlNode(m_fXmlCore, m_xmlNode.ParentNode);
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

        public FXmlNode fPreviousSibling
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    if (m_xmlNode.PreviousSibling == null)
                    {
                        return null;
                    }
                    return new FXmlNode(m_fXmlCore, m_xmlNode.PreviousSibling);
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

        public FXmlNode fNextSibling
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    if (m_xmlNode.NextSibling == null)
                    {
                        return null;
                    }
                    return new FXmlNode(m_fXmlCore, m_xmlNode.NextSibling);
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

        public FXmlAttributeCollection fAttributes
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    return new FXmlAttributeCollection(m_fXmlCore, m_xmlNode.Attributes);
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
                    return m_xmlNode.HasChildNodes;
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
                    return new FXmlNodeList(m_fXmlCore, m_xmlNode.ChildNodes);
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
                    if (m_xmlNode.FirstChild == null)
                    {
                        return null;
                    }
                    return new FXmlNode(m_fXmlCore, m_xmlNode.FirstChild);
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
                    if (m_xmlNode.LastChild == null)
                    {
                        return null;
                    }
                    return new FXmlNode(m_fXmlCore, m_xmlNode.LastChild);
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

        public string innerXml
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    return m_xmlNode.InnerXml;
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

            set
            {
                try
                {
                    m_fXmlCore.wait();
                    m_xmlNode.InnerXml = value;
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

        public string outerXml
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    return m_xmlNode.OuterXml;
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

        public string innerText
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    return ((XmlElement)m_xmlNode).InnerText;
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
                    ((XmlElement)m_xmlNode).InnerText = value;
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

        public FXmlNodeType fNodeType
        {
            get
            {
                try
                {
                    return (FXmlNodeType)m_xmlNode.NodeType;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                
                }
                return FXmlNodeType.Element;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public FXmlNode importNode(
            FXmlNode fXmlNode, 
            bool deep
            )
        {
            try
            {
                m_fXmlCore.wait();
                if (m_xmlNode.OwnerDocument.Equals(fXmlNode.baseXml.OwnerDocument))
                {
                    return new FXmlNode(m_fXmlCore, fXmlNode.baseXml.CloneNode(deep));
                }
                return new FXmlNode(m_fXmlCore, m_xmlNode.OwnerDocument.ImportNode(fXmlNode.baseXml, deep));
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

        public FXmlNode clone(
            bool deep
            )
        {
            try
            {
                m_fXmlCore.wait();
                return new FXmlNode(m_fXmlCore, m_xmlNode.CloneNode(deep));
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
                if (m_xmlNode.OwnerDocument.Equals(newChild.baseXml.OwnerDocument))
                {
                    xmlNode = m_xmlNode.AppendChild(newChild.baseXml);
                }
                else
                {
                    xmlNode = m_xmlNode.AppendChild(m_xmlNode.OwnerDocument.ImportNode(newChild.baseXml, true));
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
                if (m_xmlNode.OwnerDocument.Equals(newChild.baseXml.OwnerDocument))
                {
                    xmlNode = m_xmlNode.InsertBefore(newChild.baseXml, refChild.baseXml);
                }
                else
                {
                    xmlNode = m_xmlNode.InsertBefore(m_xmlNode.OwnerDocument.ImportNode(newChild.baseXml, true), refChild.baseXml);
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

        public FXmlNode insertAfter(
            FXmlNode newChild,
            FXmlNode refChild
            )
        {
            XmlNode xmlNode = null;

            try
            {
                m_fXmlCore.wait();
                if (m_xmlNode.OwnerDocument.Equals(newChild.baseXml.OwnerDocument))
                {
                    xmlNode = m_xmlNode.InsertAfter(newChild.baseXml, refChild.baseXml);
                }
                else
                {
                    xmlNode = m_xmlNode.InsertAfter(m_xmlNode.OwnerDocument.ImportNode(newChild.baseXml, true), refChild.baseXml);
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

        public FXmlNode removeChild(
            FXmlNode oldChild
            )
        {
            XmlNode xmlNode = null;

            try
            {
                m_fXmlCore.wait();
                xmlNode = m_xmlNode.RemoveChild(oldChild.baseXml);
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

        public FXmlNode moveUp(
            )
        {
            XmlNode xmlNodeParent = null;
            XmlNode xmlNodePrev = null;

            try
            {
                m_fXmlCore.wait();
                xmlNodeParent = m_xmlNode.ParentNode;
                xmlNodePrev = m_xmlNode.PreviousSibling;
                xmlNodeParent.RemoveChild(m_xmlNode);
                xmlNodeParent.InsertBefore(m_xmlNode, xmlNodePrev);
                return new FXmlNode(m_fXmlCore, m_xmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fXmlCore.set();
                xmlNodeParent = null;
                xmlNodePrev = null; 
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlNode moveDown(            
            )
        {
            XmlNode xmlNodeParent = null;
            XmlNode xmlNodePrev = null;

            try
            {
                m_fXmlCore.wait();
                xmlNodeParent = m_xmlNode.ParentNode;
                xmlNodePrev = m_xmlNode.NextSibling;
                xmlNodeParent.RemoveChild(m_xmlNode);
                xmlNodeParent.InsertAfter(m_xmlNode, xmlNodePrev);
                return new FXmlNode(m_fXmlCore, m_xmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fXmlCore.set();
                xmlNodeParent = null;
                xmlNodePrev = null; 
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
                m_xmlNode.RemoveAll();
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
                xmlNode = m_xmlNode.SelectSingleNode(xpath);
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
                return new FXmlNodeList(m_fXmlCore, m_xmlNode.SelectNodes(xpath));
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
            XmlDocument xmlDoc = null;

            XmlWriter xmlWriter = null;
            XmlWriterSettings settings = null;            
            StringBuilder stringBuilder = null;
            
            try
            {
                m_fXmlCore.wait();
                
                // -- 

                if (!preserveWhiteSpace)
                {
                    return m_xmlNode.OuterXml;
                }
                
                xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(m_xmlNode.OuterXml);
                
                // -- 

                settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                settings.Indent = true;
                // settings.IndentChars = "\t";
                settings.IndentChars = "  ";    // by spike.lee
                settings.NewLineHandling = NewLineHandling.Replace;
                settings.CheckCharacters = false;
                // --
                stringBuilder = new StringBuilder();
                xmlWriter = XmlWriter.Create(stringBuilder, settings);
                // -- 
                xmlDoc.Save(xmlWriter);

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

        //------------------------------------------------------------------------------------------------------------------------

        public bool containsNode(
            string xpath
            )
        {
            try
            {
                m_fXmlCore.wait();
                return (m_xmlNode.SelectSingleNode(xpath) == null ? false : true);                
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

        //------------------------------------------------------------------------------------------------------------------------

        public string get_attrVal(
            string name
            )
        {
            XmlAttribute xmlAttr = null;

            try
            {
                m_fXmlCore.wait();
                xmlAttr = m_xmlNode.Attributes[name];
                if (xmlAttr == null)
                {
                    return string.Empty;
                }
                return xmlAttr.Value;
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

        //------------------------------------------------------------------------------------------------------------------------

        public string get_attrVal(
            string name,
            string defaultValue
            )
        {
            XmlAttribute xmlAttr = null;

            try
            {
                m_fXmlCore.wait();
                xmlAttr = m_xmlNode.Attributes[name];
                if (xmlAttr == null)
                {
                    return defaultValue;
                }
                return xmlAttr.Value;
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

        //------------------------------------------------------------------------------------------------------------------------

        public void set_attrVal(
            string name, 
            string value
            )
        {
            XmlAttribute xmlAttr = null;

            try
            {
                m_fXmlCore.wait();
                xmlAttr = m_xmlNode.Attributes[name];
                if (xmlAttr == null)
                {
                    xmlAttr = m_xmlNode.Attributes.Append(m_xmlNode.OwnerDocument.CreateAttribute(name));
                }
                xmlAttr.Value = value;
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

        public void set_attrVal(
            string name,
            string defaultValue,
            string value            
            )
        {
            XmlAttribute xmlAttr = null;

            try
            {
                m_fXmlCore.wait();
                xmlAttr = m_xmlNode.Attributes[name];
                if (defaultValue == value)
                {
                    if (xmlAttr != null)
                    {
                        m_xmlNode.Attributes.Remove(xmlAttr);                        
                    }
                }
                else
                {
                    if (xmlAttr == null)
                    {
                        xmlAttr = m_xmlNode.Attributes.Append(m_xmlNode.OwnerDocument.CreateAttribute(name));
                    }
                    xmlAttr.Value = value;
                }                
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

        public void set_attrVal(
            string name,
            string value,
            bool isModifyEvent
            )
        {
            XmlAttribute xmlAttr = null;

            try
            {
                m_fXmlCore.wait();
                xmlAttr = m_xmlNode.Attributes[name];
                if (xmlAttr == null)
                {
                    xmlAttr = m_xmlNode.Attributes.Append(m_xmlNode.OwnerDocument.CreateAttribute(name));
                }
                // --
                if (xmlAttr.Value != value)
                {
                    xmlAttr.Value = value;
                    if (isModifyEvent)
                    {
                        onXmlNodeModified();
                    }
                }                
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

        public void set_attrVal(
            string name,
            string defaultValue,
            string value,
            bool isModifyEvent
            )
        {
            XmlAttribute xmlAttr = null;

            try
            {
                m_fXmlCore.wait();
                xmlAttr = m_xmlNode.Attributes[name];
                if (defaultValue == value)
                {
                    if (xmlAttr != null)
                    {
                        m_xmlNode.Attributes.Remove(xmlAttr);
                        if (isModifyEvent)
                        {
                            onXmlNodeModified();
                        }
                    }
                }
                else
                {
                    if (xmlAttr == null)
                    {
                        xmlAttr = m_xmlNode.Attributes.Append(m_xmlNode.OwnerDocument.CreateAttribute(name));
                    }
                    // --
                    if (xmlAttr.Value != value)
                    {
                        xmlAttr.Value = value;
                        if (isModifyEvent)
                        {
                            onXmlNodeModified();
                        }
                    }                    
                }
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

        public FXmlNode get_elem(
            string name
            )
        {
            XmlNode x = null;

            try
            {
                m_fXmlCore.wait();
                // --
                x = m_xmlNode.SelectSingleNode(name);
                if (x == null)
                {
                    return null;
                }
                return new FXmlNode(m_fXmlCore, x);
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

        public FXmlNodeList get_elemList(
            string name
            )
        {
            try
            {
                m_fXmlCore.wait();
                // --
                return new FXmlNodeList(m_fXmlCore, m_xmlNode.SelectNodes(name));
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

        public FXmlNode set_elem(
            string name
            )
        {
            XmlNode x = null;

            try
            {
                m_fXmlCore.wait();
                // --
                x = m_xmlNode.SelectSingleNode(name);
                if (x == null)
                {
                    x = m_xmlNode.AppendChild(m_xmlNode.OwnerDocument.CreateNode(XmlNodeType.Element, name, string.Empty));                    
                }
                return new FXmlNode(m_fXmlCore, x);
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

        public string get_elemVal(
            string name
            )
        {
            XmlNode x = null;
            XmlAttribute a = null;

            try
            {
                m_fXmlCore.wait();
                // --
                x = m_xmlNode.SelectSingleNode(name);
                if (x == null)
                {
                    return string.Empty;
                }
                // --
                a = x.Attributes[A_Value];
                if (a == null)
                {
                    return string.Empty;
                }
                return a.Value;
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

        //------------------------------------------------------------------------------------------------------------------------

        public string get_elemVal(
            string name, 
            string defaultValue
            )
        {
            XmlNode x = null;
            XmlAttribute a = null;

            try
            {
                m_fXmlCore.wait();
                // --
                x = m_xmlNode.SelectSingleNode(name);
                if (x == null)
                {
                    return defaultValue;
                }
                // --
                a = x.Attributes[A_Value];
                if (a == null)
                {
                    return defaultValue;
                }
                return a.Value;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlNode set_elemVal(
            string name, 
            string value
            )
        {
            XmlNode x = null;
            XmlAttribute a = null;

            try
            {
                m_fXmlCore.wait();
                // --
                x = m_xmlNode.SelectSingleNode(name);
                if (x == null)
                {
                    x = m_xmlNode.AppendChild(m_xmlNode.OwnerDocument.CreateNode(XmlNodeType.Element, name, string.Empty));
                }
                // --
                a = x.Attributes[A_Value];
                if (a == null)
                {
                    a = x.Attributes.Append(m_xmlNode.OwnerDocument.CreateAttribute(A_Value));
                }
                // --
                a.Value = value;
                // --
                return new FXmlNode(m_fXmlCore, x);
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

        public FXmlNode set_elemVal(
            string name,
            string defaultValue,
            string value
            )
        {
            XmlNode x = null;
            XmlAttribute a = null;

            try
            {
                m_fXmlCore.wait();
                // --
                x = m_xmlNode.SelectSingleNode(name);
                if (x == null)
                {
                    x = m_xmlNode.AppendChild(m_xmlNode.OwnerDocument.CreateNode(XmlNodeType.Element, name, string.Empty));
                }
                // --
                a = x.Attributes[A_Value];
                if (a == null)
                {
                    if (value != defaultValue)
                    {
                        x.Attributes.Append(m_xmlNode.OwnerDocument.CreateAttribute(A_Value)).Value = value;
                    }                    
                }
                else
                {
                    if (value == defaultValue)
                    {
                        x.Attributes.Remove(a);
                    }
                    else
                    {
                        a.Value = value;
                    }
                }
                // --
                return new FXmlNode(m_fXmlCore, x);
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

        public FXmlNode add_elem(
            string name
            )
        {
            try
            {
                m_fXmlCore.wait();
                // --                
                return new FXmlNode(
                    m_fXmlCore, 
                    m_xmlNode.AppendChild(m_xmlNode.OwnerDocument.CreateNode(XmlNodeType.Element, name, string.Empty))
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

        public FXmlNode add_elemVal(
            string name, 
            string value
            )
        {
            XmlNode x = null;

            try
            {
                m_fXmlCore.wait();
                // --
                x = m_xmlNode.AppendChild(m_xmlNode.OwnerDocument.CreateNode(XmlNodeType.Element, name, string.Empty));
                x.Attributes.Append(m_xmlNode.OwnerDocument.CreateAttribute(A_Value)).Value = value;
                // --
                return new FXmlNode(m_fXmlCore, x);
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

        public FXmlNode add_elemVal(
            string name, 
            string defaultValue,
            string value            
            )
        {
            XmlNode x = null;

            try
            {
                m_fXmlCore.wait();
                // --
                x = m_xmlNode.AppendChild(m_xmlNode.OwnerDocument.CreateNode(XmlNodeType.Element, name, string.Empty));
                if (value != defaultValue)
                {
                    x.Attributes.Append(m_xmlNode.OwnerDocument.CreateAttribute(A_Value)).Value = value;
                }
                // --
                return new FXmlNode(m_fXmlCore, x);
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

        public bool containElem(
            string name
            )
        {
            try
            {
                m_fXmlCore.wait();
                // --
                if (m_xmlNode.SelectSingleNode(name) == null)
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
                m_fXmlCore.set();
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool containElemVal(
            string name
            )
        {
            XmlNode x = null;

            try
            {
                m_fXmlCore.wait();
                // --
                x = m_xmlNode.SelectSingleNode(name);
                if (x == null)
                {
                    return false;
                }
                // --
                if (x.Attributes[A_Value] == null)
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
                m_fXmlCore.set();
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string get_val(
            )
        {
            XmlAttribute a = null;

            try
            {
                m_fXmlCore.wait();
                // --
                a = m_xmlNode.Attributes[A_Value];
                if (a == null)
                {
                    return string.Empty;
                }
                return a.Value;
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

        //------------------------------------------------------------------------------------------------------------------------

        public string get_val(
            string defaultValue
            )
        {
            XmlAttribute a = null;

            try
            {
                m_fXmlCore.wait();
                // --
                a = m_xmlNode.Attributes[A_Value];
                if (a == null)
                {
                    return defaultValue;
                }
                return a.Value;
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

        //------------------------------------------------------------------------------------------------------------------------

        public void set_val(
            string value
            )
        {
            XmlAttribute a = null;

            try
            {
                m_fXmlCore.wait();
                // --
                a = m_xmlNode.Attributes[A_Value];
                if (a == null)
                {
                    a = m_xmlNode.Attributes.Append(m_xmlNode.OwnerDocument.CreateAttribute(A_Value));
                }
                a.Value = value;
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

        public void set_val(
            string defaultValue,
            string value
            )
        {
            XmlAttribute a = null;

            try
            {
                m_fXmlCore.wait();
                // --
                a = m_xmlNode.Attributes[A_Value];
                if (a == null)
                {
                    if (value != defaultValue)
                    {
                        m_xmlNode.Attributes.Append(m_xmlNode.OwnerDocument.CreateAttribute(A_Value)).Value = value;
                    }
                }
                else
                {
                    if (value == defaultValue)
                    {
                        m_xmlNode.Attributes.Remove(a);
                    }
                    else
                    {
                        a.Value = value;
                    }
                }
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

        public bool containVal(
            )
        {
            try
            {
                m_fXmlCore.wait();
                // --
                if (m_xmlNode.Attributes[A_Value] == null)
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
                m_fXmlCore.set();
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int getIndex(
            bool isError
            )
        {
            int index = -1;

            try
            {
                m_fXmlCore.wait();
                // --
                if (m_xmlNode.ParentNode != null)
                {
                    for (int i = 0; i < m_xmlNode.ParentNode.ChildNodes.Count; i++)
                    {
                        if (m_xmlNode == m_xmlNode.ParentNode.ChildNodes[i])
                        {
                            index = i;
                            break;
                        }
                    }                    
                }
                // --
                if (isError && index == -1)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0003, "Parent"));
                }
                return index;                
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

        //------------------------------------------------------------------------------------------------------------------------

        private void onXmlNodeModified(
            )
        {
            try
            {
                if (XmlNodeModified != null)
                {
                    XmlNodeModified(this, new FXmlNodeModifiedEventArgs(this));
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
                if (obj == null || !(obj is FXmlNode))
                {
                    return false;
                }

                return m_xmlNode.Equals(
                    ((FXmlNode)obj).baseXml
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
            FXmlNode lhs,
            FXmlNode rhs
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
            FXmlNode lhs,
            FXmlNode rhs
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
