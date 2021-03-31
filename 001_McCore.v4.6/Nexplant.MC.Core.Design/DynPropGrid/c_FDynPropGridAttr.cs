/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDynPropGridAttr.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.28
--  Description     : FAMate Core FaUIs Dynamic Property Grid Attribute Class
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
    public class FDynPropGridAttr : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private Attribute m_value = null;
        private Type m_type;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDynPropGridAttr(
            Attribute value
            )
        {
            m_type = value.GetType();
            m_value = value;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDynPropGridAttr(
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
                    m_value = null;
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

        public Attribute value
        {
            get
            {
                try
                {
                    return m_value;
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

        public Type type
        {
            get
            {
                try
                {
                    return m_type;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Instance Comparison Method

        public override bool Equals(
            object obj
            )
        {
            Type type;

            try
            {
                type = obj.GetType();
                if (type.Name == "RuntimeType")
                {
                    return equal(this, (Type)obj);
                }

                if (type == typeof(FDynPropGridAttr))
                {
                    return equal(this, (FDynPropGridAttr)obj);
                }
                else if (type == typeof(Attribute) || type.IsAssignableFrom(typeof(Attribute)))
                {
                    return equal(this, (Attribute)obj);
                }
                return false;
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
       
        public override int GetHashCode(
            )
        {
            return m_type.FullName.ToString().GetHashCode();
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static bool equal(
            Type type1,
            Type type2
            )
        {
            try
            {
                return type1.IsAssignableFrom(type2);
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

        private static bool equal(
           FDynPropGridAttr dynAttr1,
           FDynPropGridAttr dynAttr2
           )
        {
            try
            {
                return equal(dynAttr1.type, dynAttr2.type);
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

        private static bool equal(
            FDynPropGridAttr dynAttr,
            Attribute attr
            )
        {
            try
            {
                return equal(dynAttr.type, attr.GetType());
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

        private static bool equal(
            FDynPropGridAttr dynAttr,
            Type type
            )
        {
            try
            {
                return equal(dynAttr.type, type);
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
