/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDynPropGridTypeDescriptor.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.28
--  Description     : FAMate Core FaUIs Dynamic Property Grid Type Descriptor Class
--  History         : Created by spike.lee at 2010.12.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public class FDynPropGridTypeDescriptor : IDisposable, ICustomTypeDescriptor
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private bool m_inherited = false;
        private object m_instance = null;
        private FDynPropGridSortTypes m_propSortType = FDynPropGridSortTypes.Default;
        private FDynPropGridPropCollection m_dynProps = null;
        private List<FDynPropGridPropDescriptor> m_dynPropDescriptors = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDynPropGridTypeDescriptor(
            object instance,
            bool inherited
            )
        {
            m_instance = instance;
            m_inherited = inherited;
            m_dynProps = new FDynPropGridPropCollection();
            m_dynPropDescriptors = new List<FDynPropGridPropDescriptor>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDynPropGridTypeDescriptor(
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
                    m_instance = null;
                    m_dynProps = null;
                    m_dynPropDescriptors = null;
                }
            }

            m_disposed = true;
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

        #region ICustomTypeDescriptor 멤버

        public AttributeCollection GetAttributes(
            )
        {
            try
            {
                return TypeDescriptor.GetAttributes(m_instance, m_inherited);
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

        public string GetClassName(
            )
        {
            try
            {
                return TypeDescriptor.GetClassName(m_instance, m_inherited);
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

        public string GetComponentName(
            )
        {
            try
            {
                return TypeDescriptor.GetComponentName(m_instance, m_inherited);
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

        public TypeConverter GetConverter(
            )
        {
            try
            {
                return TypeDescriptor.GetConverter(m_instance, m_inherited);
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

        public EventDescriptor GetDefaultEvent(
            )
        {
            try
            {
                return TypeDescriptor.GetDefaultEvent(m_instance, m_inherited);
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

        public PropertyDescriptor GetDefaultProperty(
            )
        {
            try
            {
                return TypeDescriptor.GetDefaultProperty(m_instance, m_inherited);
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

        public object GetEditor(
            Type editorBaseType
            )
        {
            try
            {
                return TypeDescriptor.GetEditor(m_instance, editorBaseType, m_inherited);
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

        public EventDescriptorCollection GetEvents(
            )
        {
            try
            {
                return TypeDescriptor.GetEvents(m_instance, m_inherited);
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

        public EventDescriptorCollection GetEvents(
            Attribute[] attributes
            )
        {
            try
            {
                return TypeDescriptor.GetEvents(m_instance, attributes, m_inherited);
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

        public PropertyDescriptorCollection GetProperties(
            )
        {
            try
            {
                return TypeDescriptor.GetProperties(m_instance, m_inherited);
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

        public PropertyDescriptorCollection GetProperties(
            Attribute[] attributes
            )
        {
            PropertyDescriptorCollection propDescriptors = null;
            PropertyDescriptor propDescriptor = null;
            FDynPropGridProp dynProp = null;
            List<Attribute> attrList = null;
            Attribute[] attrArray = null;
            List<FDynPropGridPropDescriptor> dynPropDescriptors = null;
            FDynPropGridPropDescriptor dynPropDescriptor = null;

            try
            {
                propDescriptors = TypeDescriptor.GetProperties(m_instance, m_inherited);
                dynPropDescriptors = new List<FDynPropGridPropDescriptor>(propDescriptors.Count);

                for (int i = 0; i < propDescriptors.Count; i++)
                {
                    propDescriptor = propDescriptors[i];
                    attrList = new List<Attribute>(propDescriptor.Attributes.Count);

                    foreach (Attribute attr in propDescriptor.Attributes)
                    {
                        attrList.Add(attr);
                    }

                    dynProp = null;
                    if (m_dynProps.tryGetValue(propDescriptor.Name, out dynProp))
                    {
                        if (dynProp.attributes.count > 0)
                        {
                            doAttributes(dynProp, attrList);
                        }
                    }

                    attrArray = new Attribute[attrList.Count];
                    attrList.CopyTo(attrArray);

                    dynPropDescriptor = new FDynPropGridPropDescriptor(m_instance, propDescriptor, m_dynProps, dynProp, attrArray);
                    dynPropDescriptors.Add(dynPropDescriptor);
                }

                return sortPropertyDescriptorCollection(dynPropDescriptors);
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

        public object GetPropertyOwner(
            PropertyDescriptor pd
            )
        {
            try
            {
                return m_instance;
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

        public FDynPropGridSortTypes sortType
        {
            get
            {
                try
                {
                    return m_propSortType;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDynPropGridSortTypes.Default;
            }

            set
            {
                try
                {
                    m_propSortType = value;
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

        public FDynPropGridPropCollection properties
        {
            get
            {
                try
                {
                    return m_dynProps;
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

        public List<FDynPropGridPropDescriptor> propertyDescriptors
        {
            get
            {
                try
                {
                    return m_dynPropDescriptors;
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

        private void doAttributes(
            FDynPropGridProp dynProp,
            List<Attribute> attributes
            )
        {
            int index = 0;

            try
            {
                foreach (FDynPropGridAttr dynAttr in dynProp.attributes)
                {
                    index = -1;
                    if (dynAttr == null)
                    {
                        continue;
                    }

                    for (int i = 0; i < attributes.Count; i++)
                    {
                        if (dynAttr.Equals(attributes[i]))
                        {
                            index = i;
                            break;
                        }
                    }

                    if (index == -1)
                    {
                        attributes.Add(dynAttr.value);
                    }
                    else
                    {
                        attributes.RemoveAt(index);
                        attributes.Insert(index, dynAttr.value);
                    }
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

        private PropertyDescriptorCollection sortPropertyDescriptorCollection(
            List<FDynPropGridPropDescriptor> dynPropGridPropDescriptors
            )
        {
            PropertyInfo[] propInfos = null;
            PropertyDescriptor[] sortedProps = null;

            try
            {
                switch (m_propSortType)
                {
                    case FDynPropGridSortTypes.Natural:
                        propInfos = m_instance.GetType().GetProperties();
                        dynPropGridPropDescriptors = FDynPropGridPropSortByNatural.sort(propInfos, dynPropGridPropDescriptors);
                        break;

                    case FDynPropGridSortTypes.UsePropertySortAttributes:
                        dynPropGridPropDescriptors.Sort(new FDynPropGridPropSortByAttribute());
                        break;
                }
                m_dynPropDescriptors = dynPropGridPropDescriptors;

                sortedProps = new PropertyDescriptor[dynPropGridPropDescriptors.Count];
                for (int i = 0; i < dynPropGridPropDescriptors.Count; i++)
                {
                    sortedProps[i] = dynPropGridPropDescriptors[i];
                }

                return new PropertyDescriptorCollection(sortedProps);
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
