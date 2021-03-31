/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FFDynPropGridPropCollection.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.28
--  Description     : FAMate Core FaUIs Dynamic Property Grid Property Collection Class
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
    public class FDynPropGridPropCollection : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private Dictionary<string, FDynPropGridProp> m_dynProps = null;
        private object m_defaultProp = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDynPropGridPropCollection(
            )
        {
            m_dynProps = new Dictionary<string, FDynPropGridProp>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDynPropGridPropCollection(
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
                    m_dynProps = null;
                    m_defaultProp = null;
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

        public FDynPropGridProp this[string name]
        {
            get
            {
                FDynPropGridProp dynProp = null;

                try
                {
                    if (!m_dynProps.TryGetValue(name, out dynProp))
                    {
                        dynProp = new FDynPropGridProp();
                        m_dynProps.Add(name, dynProp);
                    }
                    return dynProp;
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

            set
            {
                try
                {
                    if (m_dynProps.ContainsKey(name))
                    {
                        m_dynProps[name] = value;
                    }
                    else
                    {
                        m_dynProps.Add(name, value);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public object defaultProperty
        {
            get
            {
                try
                {
                    return m_defaultProp;
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

            set
            {
                try
                {
                    m_defaultProp = value;
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

        public int count
        {
            get
            {
                try
                {
                    return m_dynProps.Count;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public void clear(
            )
        {
            try
            {
                m_dynProps.Clear();
                m_defaultProp = null;
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

        public int removeAttributesByType(
            Type[] types
            )
        {
            FDynPropGridProp dynProp = null;
            FDynPropGridAttr dynAttr = null;
            int rCnt = 0;

            try
            {
                foreach (KeyValuePair<string, FDynPropGridProp> obj in m_dynProps)
                {
                    dynProp = obj.Value;
                    for (int i = 0; i < types.Length; i++)
                    {
                        for (int j = dynProp.attributes.count - 1; j >= 0; j--)
                        {
                            dynAttr = dynProp.attributes[j];
                            if (dynAttr.Equals(types[i]))
                            {
                                dynProp.attributes.removeAt(j);
                                rCnt++;
                            }
                        }
                    }
                }
                return rCnt;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dynProp = null;
                dynAttr = null;
            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool tryGetValue(
            string key,
            out FDynPropGridProp dynProp
            )
        {
            dynProp = null;

            try
            {
                return m_dynProps.TryGetValue(key, out dynProp);
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

        public FDynPropGridProp[] getPropertyArray(
            )
        {
            FDynPropGridProp[] array = null;
            int i = 0;

            try
            {
                if (m_dynProps.Count == 0)
                {
                    return null;
                }

                // --                

                array = new FDynPropGridProp[m_dynProps.Count];
                foreach (FDynPropGridProp p in m_dynProps.Values)
                {
                    array[i++] = p;
                }
                return array;
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
