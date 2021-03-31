/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2016 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDragDropData.cs
--  Creator         : spike.lee
--  Create Date     : 2016.07.11
--  Description     : FAMate OPC Modeler DragDropData Class 
--  History         : Created by spike.lee at 2016.07.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;  
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.Core.FaUIs.WPF;
using Infragistics.Win.UltraWinTree;

namespace Nexplant.MC.OpcModeler
{
    [Serializable()]
    public class FDragDropData : MarshalByRefObject, ISerializable, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FIObject m_fObject = null;
        private FIObjectLog m_fObjectLog = null;
        private string m_sessionUniqueId = string.Empty;
        private string m_refSessionUniqueId = string.Empty;
        // --
        private UltraTreeNode m_oldRefNode = null;
        private FIFlowCtrl m_oldRefFlowCtrl = null;
        // --
        private bool m_serializableSuccess = true;
        private string m_serializableErrorMessage = string.Empty;
        // --
        private int m_internalChecker = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDragDropData(                        
            FIObject fObject
            )
        {
            m_fObject = fObject;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDragDropData(
            FIObjectLog fObjectLog
            )
        {
            m_fObjectLog = fObjectLog;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDragDropData(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_fObject = null;
                    m_fObjectLog = null;
                    m_oldRefNode = null;
                    m_oldRefFlowCtrl = null;
                }                

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region ISerializable 멤버

        protected FDragDropData(
            SerializationInfo info,
            StreamingContext context
            )
        {
            IntPtr addr;
            GCHandle handle;

            try
            {
                m_internalChecker = (int)info.GetValue("m_internalChecker", typeof(int));
                if (m_internalChecker != System.Diagnostics.Process.GetCurrentProcess().Id)
                {
                    m_serializableSuccess = false;
                    return;
                }

                // --

                addr = (IntPtr)info.GetValue("m_fObject", typeof(IntPtr));
                handle = GCHandle.FromIntPtr(addr);
                m_fObject = (FIObject)handle.Target;
                handle.Free();

                // --

                addr = (IntPtr)info.GetValue("m_fObjectLog", typeof(IntPtr));
                handle = GCHandle.FromIntPtr(addr);
                m_fObjectLog = (FIObjectLog)handle.Target;
                handle.Free();

                // --

                addr = (IntPtr)info.GetValue("m_sessionUniqueId", typeof(IntPtr));
                handle = GCHandle.FromIntPtr(addr);
                m_sessionUniqueId = (string)handle.Target;
                handle.Free();

                // --

                addr = (IntPtr)info.GetValue("m_refSessionUniqueId", typeof(IntPtr));
                handle = GCHandle.FromIntPtr(addr);
                m_refSessionUniqueId = (string)handle.Target;
                handle.Free();

                // --

                addr = (IntPtr)info.GetValue("m_oldRefNode", typeof(IntPtr));
                handle = GCHandle.FromIntPtr(addr);
                m_oldRefNode = (UltraTreeNode)handle.Target;
                handle.Free();

                // --

                addr = (IntPtr)info.GetValue("m_oldRefFlowCtrl", typeof(IntPtr));
                handle = GCHandle.FromIntPtr(addr);
                m_oldRefFlowCtrl = (FIFlowCtrl)handle.Target;
                handle.Free();

                // --

                m_serializableSuccess = true;
            }
            catch (Exception ex)
            {
                m_serializableSuccess = false;
                m_serializableErrorMessage = ex.Message;
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void GetObjectData(
            SerializationInfo info,
            StreamingContext context
            )
        {
            IntPtr addr;
            GCHandle handle;

            try
            {
                m_internalChecker = System.Diagnostics.Process.GetCurrentProcess().Id;
                info.AddValue("m_internalChecker", m_internalChecker);

                // --

                handle = GCHandle.Alloc(m_fObject);
                addr = GCHandle.ToIntPtr(handle);
                info.AddValue("m_fObject", addr);

                // --

                handle = GCHandle.Alloc(m_fObjectLog);
                addr = GCHandle.ToIntPtr(handle);
                info.AddValue("m_fObjectLog", addr);

                // --

                handle = GCHandle.Alloc(m_sessionUniqueId);
                addr = GCHandle.ToIntPtr(handle);
                info.AddValue("m_sessionUniqueId", addr);

                // --

                handle = GCHandle.Alloc(m_refSessionUniqueId);
                addr = GCHandle.ToIntPtr(handle);
                info.AddValue("m_refSessionUniqueId", addr);

                // --

                handle = GCHandle.Alloc(m_oldRefNode);
                addr = GCHandle.ToIntPtr(handle);
                info.AddValue("m_oldRefNode", addr);

                // --

                handle = GCHandle.Alloc(m_oldRefFlowCtrl);
                addr = GCHandle.ToIntPtr(handle);
                info.AddValue("m_oldRefFlowCtrl", addr);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

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
                
        public FIObject fObject
        {
            get
            {
                try
                {
                    return m_fObject;
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
                    m_fObject = value;
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

        public FIObjectLog fObjectLog
        {
            get
            {
                try
                {
                    return m_fObjectLog;
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
                    m_fObjectLog = value;
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

        public string sessionUniqueId
        {
            get
            {
                try
                {
                    return m_sessionUniqueId;
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

            set
            {
                try
                {
                    m_sessionUniqueId = value;
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

        public string refSessionUniqueId
        {
            get
            {
                try
                {
                    return m_refSessionUniqueId;
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

            set
            {
                try
                {
                    m_refSessionUniqueId = value;
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

        public UltraTreeNode oldRefNode
        {
            get
            {
                try
                {
                    return m_oldRefNode;
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
                    m_oldRefNode = value;
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

        public FIFlowCtrl oldRefFlowCtrl
        {
            get
            {
                try
                {
                    return m_oldRefFlowCtrl;
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
                    m_oldRefFlowCtrl = value;
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

        public bool serializableSuccess
        {
            get
            {
                try
                {
                    return m_serializableSuccess;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string serializableErrorMessage
        {
            get
            {
                try
                {
                    return m_serializableErrorMessage;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
