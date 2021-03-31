/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDynPropGridPropDescriptor.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.28
--  Description     : FAMate Core FaUIs Dynamic Property Grid Property Descriptor Class
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
    public class FDynPropGridPropDescriptor : PropertyDescriptor, IDisposable 
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private object m_instance = null;
        private PropertyDescriptor m_propDescriptor = null;
        private FDynPropGridPropCollection m_dynProps = null;
        private FDynPropGridProp m_dynProp = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDynPropGridPropDescriptor(
            object instance,
            PropertyDescriptor propDescriptor,
            FDynPropGridPropCollection dynProps,
            FDynPropGridProp dynProp,
            Attribute[] attributes
            ) 
            : base(propDescriptor.Name, attributes)
        {
            m_instance = instance;
            m_propDescriptor = propDescriptor;
            m_dynProps = dynProps;
            m_dynProp = dynProp;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDynPropGridPropDescriptor(
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
                    m_propDescriptor = null;
                    m_dynProps = null;
                    m_dynProp = null;
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

        #region Properties

        public override Type ComponentType
        {
            get
            {
                try
                {
                    return m_propDescriptor.ComponentType;
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

        public override bool IsReadOnly
        {
            get
            {
                object attr = null;

                try
                {
                    attr = getAttribute(typeof(ReadOnlyAttribute));
                    if (attr != null)
                    {
                        return ((ReadOnlyAttribute)attr).IsReadOnly;
                    }
                    return m_propDescriptor.IsReadOnly;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    attr = null;
                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public override Type PropertyType
        {
            get
            {
                try
                {
                    return m_propDescriptor.PropertyType;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return this.GetType();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override bool CanResetValue(
            object component
            )
        {
            object defVal = null;
            bool equaled = false;
            bool shouldSerializable = false;
            MethodInfo mi = null;

            try
            {
                if (checkDefaultValue(component, out equaled, out defVal))
                {
                    return !equaled;
                }

                if (invokeShouldSerialize(component, out shouldSerializable))
                {
                    return shouldSerializable;
                }

                mi = FindMethod(ComponentType, "Reset" + Name, new Type[] { }, null);
                if (mi != null)
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
                defVal = null;
                mi = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public override void ResetValue(
           object component
           )
        {
            object defVal = null;
            bool equaled = false;
            MethodInfo mi = null;

            try
            {
                if (checkDefaultValue(component, out equaled, out defVal))
                {
                    SetValue(component, defVal);
                    return;
                }

                mi = FindMethod(ComponentType, "Reset" + Name, new Type[] { }, null);
                if (mi != null)
                {
                    mi.Invoke(component, null);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                defVal = null;
                mi = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public override object GetValue(
            object component
            )
        {
            try
            {
                // ***
                // 2009.07.03 by spike.lee
                // ***
                if (component == null)
                {
                    return null;
                }

                return component.GetType().InvokeMember(
                    Name,
                    BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.Public,
                    null,
                    component,
                    null
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

        public override void SetValue(
            object component,
            object value
            )
        {
            try
            {
                //
                // 2008.06.03 by spike.lee
                // * Description
                //   Property가 ReadOnly일 경우 Value를 설정하지 않는다.
                //
                if (IsReadOnly)
                {
                    return;
                }

                component.GetType().InvokeMember(
                    Name,
                    BindingFlags.Instance | BindingFlags.SetProperty | BindingFlags.Public,
                    null,
                    component,
                    new object[] { value }
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

        public override bool ShouldSerializeValue(
           object component
           )
        {
            object defVal = null;
            bool equaled = false;
            bool shouldSerializable = false;

            try
            {
                if (checkDefaultValue(component, out equaled, out defVal))
                {
                    return !equaled;
                }

                if (invokeShouldSerialize(component, out shouldSerializable))
                {
                    return shouldSerializable;
                }
                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                defVal = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public override object GetEditor(
            Type editorBaseType
            )
        {
            try
            {
                return base.GetEditor(editorBaseType);
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

        public object GetDefaultValue(
            )
        {
            object defVal = null;

            try
            {
                if (getDefaultValue(out defVal))
                {
                    return defVal;
                }
                return null;
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

        public object getAttribute(
            Type type
            )
        {
            try
            {
                foreach (Attribute attr in base.Attributes)
                {
                    if (isAssignableFrom(attr.GetType(), type))
                    {
                        return attr;
                    }
                }
                return null;
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

        public static bool isAssignableFrom(
            Type type,
            Type baseType
            )
        {
            try
            {
                return baseType.IsAssignableFrom(type);
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

        private bool checkDefaultValue(
            object component,
            out bool equaled,
            out object convertedDefVal
            )
        {
            object val = null;

            equaled = false;
            convertedDefVal = null;

            try
            {
                if (getDefaultValue(out convertedDefVal))
                {
                    val = GetValue(component);
                    if (val.GetType() == convertedDefVal.GetType())
                    {
                        equaled = Equals(val, convertedDefVal);
                        return true;
                    }

                    if (Converter.CanConvertFrom(convertedDefVal.GetType()))
                    {
                        try
                        {
                            convertedDefVal = Converter.ConvertFrom(convertedDefVal);
                            equaled = Equals(val, convertedDefVal);
                        }
                        catch
                        {
                            equaled = false;
                        }
                    }
                    else
                    {
                        equaled = compareObject(val, convertedDefVal);
                    }
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
                val = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool getDefaultValue(
            out object value
            )
        {
            object defVal = null;

            value = null;

            try
            {
                if (m_dynProps.defaultProperty != null)
                {
                    value = GetValue(m_dynProps.defaultProperty);
                    return true;
                }

                defVal = getAttribute(typeof(DefaultValueAttribute));
                if (defVal != null)
                {
                    value = ((DefaultValueAttribute)defVal).Value;
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
                defVal = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool invokeShouldSerialize(
            object component,
            out bool shouldSerializable
            )
        {
            MethodInfo mi = null;
            object ret = false;

            shouldSerializable = true;

            try
            {
                mi = FindMethod(ComponentType, "ShouldSerialize" + Name, new Type[] { }, typeof(bool));
                if (mi != null)
                {
                    ret = mi.Invoke(component, null);
                    shouldSerializable = (bool)ret;
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
                mi = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool compareObject(
            object obj1,
            object obj2
            )
        {
            try
            {
                if (obj1.GetType().IsClass || obj2.GetType().IsClass || obj1.GetType() != obj2.GetType())
                {
                    return obj1.Equals(obj2);
                }
                else
                {
                    return (obj1 == obj2 ? true : false);
                }
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
