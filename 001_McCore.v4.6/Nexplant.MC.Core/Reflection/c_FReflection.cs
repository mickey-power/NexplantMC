/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FReflection.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.21
--  Description     : FAMate Core FaCommon Reflection Class 
--  History         : Created by spike.lee at 2011.03.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Nexplant.MC.Core.FaCommon
{
    public static class FReflection
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        static FReflection(
            )
        {

        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static object createInstance(
            string fileName, 
            string typeName,
            object[] args
            )
        {
            Assembly assembly = null;
            Type type = null;

            try
            {
                assembly = Assembly.LoadFrom(fileName);
                type = assembly.GetType(typeName);
                if (type == null)
                {
                    return null;
                }

                // --
                
                if (args == null)
                {
                    return Activator.CreateInstance(type);
                }
                return Activator.CreateInstance(type, args);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                assembly = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static object createInstance(
            string fileName, 
            string typeName
            )
        {
            try
            {
                return createInstance(fileName, typeName, null);
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

        public static Type getType(
            string fileName,
            string typeName
            )
        {
            Assembly assembly = null;

            try
            {
                assembly = Assembly.LoadFile(fileName);
                return assembly.GetType(typeName);
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

        public static object createInstanceInMemory(
            string fileName, 
            string typeName, 
            object[] args
            )
        {
            FileStream fs = null;
            byte[] buf = null;
            Assembly assembly = null;
            Type type = null;

            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                buf = new byte[fs.Length];
                fs.Read(buf, 0, buf.Length);
                // --
                fs.Close();
                fs.Dispose();
                fs = null;
                // --
                assembly = Assembly.Load(buf);
                type = assembly.GetType(typeName);
                if (type == null)
                {
                    return null;
                }

                

                // --

                if (args == null)
                {
                    return Activator.CreateInstance(type);
                }
                return Activator.CreateInstance(type, args);
            }
            catch (TargetInvocationException targetEx)
            {
                return null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                    fs = null;
                }
                assembly = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static object createInstanceInMemory(
            string fileName, 
            string typeName
            )
        {
            try
            {
                return createInstance(fileName, typeName, null);
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

        public static object invokeMethod(
            object instance, 
            Type type, 
            string methodName, 
            object[] args
            )
        {
            MethodInfo methodInfo = null;
            List<Type> argTypes = null;

            try
            {
                argTypes = new List<Type>();
                foreach (object arg in args)
                {
                    argTypes.Add(arg.GetType());
                }
                
                // -- 
                
                methodInfo = type.GetMethod(methodName, argTypes.ToArray());
                if (methodInfo == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0003, "Method"));
                }
                
                // --

                return methodInfo.Invoke(instance, args);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                methodInfo = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static object invokeMethod(
            object instance, 
            string typeName,
            string methodName, 
            object[] args
            )
        {
            Type type = null;
            MethodInfo methodInfo = null;

            try
            {
                type = Type.GetType(typeName);
                if (type == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0003, "Type"));
                }

                // --

                methodInfo = type.GetMethod(methodName);
                if (methodInfo == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0003, "Method"));
                }

                // --

                return methodInfo.Invoke(instance, args);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                type = null;
                methodInfo = null;                
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static object invokeMethod(
            object instance, 
            string typeName,
            string methodName
            )
        {
            try
            {
                return invokeMethod(instance, typeName, methodName, null);
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
