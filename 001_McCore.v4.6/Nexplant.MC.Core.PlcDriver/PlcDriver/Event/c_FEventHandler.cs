/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FEventHandler.cs
--  Creator         : spike.lee
--  Create Date     : 2013.07.10
--  Description     : FAMate Core FaPlcDriver Event Handler Class 
--  History         : Created by spike.lee at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    public class FEventHandler : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FModelingFileOpenCompletedEventHandler ModelingFileOpenCompleted = null;
        public event FModelingFileReopenPrecompletedEventHandler ModelingFileReopenPrecompleted = null;
        public event FModelingFileReopenCompletedEventHandler ModelingFileReopenCompleted = null;
        public event FModelingFileReopenFailedEventHandler ModelingFileReopenFailed = null;
        public event FModelingFileSaveCompletedEventHandler ModelingFileSaveCompleted = null;
        // --        
        public event FObjectModifyCompletedEventHandler ObjectModifyCompleted = null;
        public event FObjectInsertBeforeCompletedEventHandler ObjectInsertBeforeCompleted = null;
        public event FObjectInsertAfterCompletedEventHandler ObjectInsertAfterCompleted = null;
        public event FObjectAppendCompletedEventHandler ObjectAppendCompleted = null;
        public event FObjectRemoveCompletedEventHandler ObjectRemoveCompleted = null;
        public event FObjectMoveUpCompletedEventHandler ObjectMoveUpCompleted = null;
        public event FObjectMoveDownCompletedEventHandler ObjectMoveDownCompleted = null;
        public event FObjectMoveToCompletedEventHandler ObjectMoveToCompleted = null;
        // --
        public event FPlcDeviceStateChangedEventHandler PlcDeviceStateChanged = null;
        public event FPlcDeviceErrorRaisedEventHandler PlcDeviceErrorRaised = null;
        public event FPlcDeviceTimeoutRaisedEventHandler PlcDeviceTimeoutRaised = null;
        public event FPlcDeviceDataReceivedEventHandler PlcDeviceDataReceived = null;
        public event FPlcDeviceDataSentEventHandler PlcDeviceDataSent = null;
        public event FPlcDeviceDataMessageReadEventHandler PlcDeviceDataMessageRead = null;
        public event FPlcDeviceDataMessageWrittenEventHandler PlcDeviceDataMessageWritten = null;
        // --
        public event FHostDeviceStateChangedEventHandler HostDeviceStateChanged = null;
        public event FHostDeviceErrorRaisedEventHandler HostDeviceErrorRaised = null;
        public event FHostDeviceVfeiReceivedEventHandler HostDeviceVfeiReceived = null;
        public event FHostDeviceVfeiSentEventHandler HostDeviceVfeiSent = null;
        public event FHostDeviceDataMessageReceivedEventHandler HostDeviceDataMessageReceived = null;
        public event FHostDeviceDataMessageSentEventHandler HostDeviceDataMessageSent = null;
        //--
        public event FPlcTriggerRaisedEventHandler PlcTriggerRaised = null;
        public event FPlcTransmitterRaisedEventHandler PlcTransmitterRaised = null;
        public event FHostTriggerRaisedEventHandler HostTriggerRaised = null;
        public event FHostTransmitterRaisedEventHandler HostTransmitterRaised = null;
        public event FJudgementPerformedEventHandler JudgementPerformed = null;
        public event FMapperPerformedEventHandler MapperPerformed = null;
        public event FEquipmentStateSetAltererPerformedEventHandler EquipmentStateSetAltererPerformed = null;
        public event FStoragePerformedEventHandler StoragePerformed = null;
        public event FCallbackRaisedEventHandler CallbackRaised = null;
        public event FFunctionCalledEventHandler FunctionCalled = null;
        public event FBranchRaisedEventHandler BranchRaised = null;
        public event FCommentWrittenEventHandler CommentWritten = null;
        public event FEntryPointCalledEventHandler EntryPointCalled = null;
        public event FApplicationWrittenEventHandler ApplicationWritten = null;
        public event FPauserRaisedEventHandler PauserRaised = null;
        // ***
        // 2017.05.31 by spike.lee
        // Repository Material Saved Event Handler 추가
        // ***
        public event FRepositoryMaterialSavedEventHandler RepositoryMaterialSaved = null;

        //--

        private bool m_disposed = false;
        // --
        private FPlcDriver m_fPlcDriver = null;
        private Control m_invoker = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEventHandler(
            FPlcDriver fPlcDriver,
            Control invoker
            )
        {
            m_fPlcDriver = fPlcDriver;
            m_invoker = invoker;                     

            // --

            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEventHandler(
            FPlcDriver fPlcDriver
            )
            : this(fPlcDriver, null)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FEventHandler(
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
                    term();
                    
                    // --

                    m_fPlcDriver = null;
                    m_invoker = null;
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

        internal Control invoker
        {
            get
            {
                try
                {
                    return m_invoker;
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

        public FPlcDriver fPlcDriver
        {
            get
            {
                try
                {
                    return m_fPlcDriver;
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

        public int eventCount
        {
            get
            {
                try
                {
                    return m_fPlcDriver.eventCount;
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool isCompletedEventHandling
        {
            get
            {
                try
                {
                    return m_fPlcDriver.isCompletedEventHandling;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                m_fPlcDriver.ModelingFileOpenCompleted += new FModelingFileOpenCompletedEventHandler(m_fPlcDriver_ModelingFileOpenCompleted);
                m_fPlcDriver.ModelingFileReopenPrecompleted += new FModelingFileReopenPrecompletedEventHandler(m_fPlcDriver_ModelingFileReopenPrecompleted);
                m_fPlcDriver.ModelingFileReopenCompleted += new FModelingFileReopenCompletedEventHandler(m_fPlcDriver_ModelingFileReopenCompleted);
                m_fPlcDriver.ModelingFileReopenFailed += new FModelingFileReopenFailedEventHandler(m_fPlcDriver_ModelingFileReopenFailed);
                m_fPlcDriver.ModelingFileSaveCompleted += new FModelingFileSaveCompletedEventHandler(m_fPlcDriver_ModelingFileSaveCompleted);
                // --               
                m_fPlcDriver.ObjectModifyCompleted += new FObjectModifyCompletedEventHandler(m_fPlcDriver_ObjectModifyCompleted);                
                m_fPlcDriver.ObjectInsertBeforeCompleted += new FObjectInsertBeforeCompletedEventHandler(m_fPlcDriver_ObjectInsertBeforeCompleted);
                m_fPlcDriver.ObjectInsertAfterCompleted += new FObjectInsertAfterCompletedEventHandler(m_fPlcDriver_ObjectInsertAfterCompleted);
                m_fPlcDriver.ObjectAppendCompleted += new FObjectAppendCompletedEventHandler(m_fPlcDriver_ObjectAppendCompleted);
                m_fPlcDriver.ObjectRemoveCompleted += new FObjectRemoveCompletedEventHandler(m_fPlcDriver_ObjectRemoveCompleted);
                m_fPlcDriver.ObjectMoveUpCompleted += new FObjectMoveUpCompletedEventHandler(m_fPlcDriver_ObjectMoveUpCompleted);
                m_fPlcDriver.ObjectMoveDownCompleted += new FObjectMoveDownCompletedEventHandler(m_fPlcDriver_ObjectMoveDownCompleted);
                m_fPlcDriver.ObjectMoveToCompleted += new FObjectMoveToCompletedEventHandler(m_fPlcDriver_ObjectMoveToCompleted);
                // --
                m_fPlcDriver.PlcDeviceStateChanged += new FPlcDeviceStateChangedEventHandler(m_fPlcDriver_PlcDeviceStateChanged);
                m_fPlcDriver.PlcDeviceErrorRaised += new FPlcDeviceErrorRaisedEventHandler(m_fPlcDriver_PlcDeviceErrorRaised);
                m_fPlcDriver.PlcDeviceTimeoutRaised += new FPlcDeviceTimeoutRaisedEventHandler(m_fPlcDriver_PlcDeviceTimeoutRaised);
                m_fPlcDriver.PlcDeviceDataReceived += new FPlcDeviceDataReceivedEventHandler(m_fPlcDriver_PlcDeviceDataReceived);
                m_fPlcDriver.PlcDeviceDataSent += new FPlcDeviceDataSentEventHandler(m_fPlcDriver_PlcDeviceDataSent);
                m_fPlcDriver.PlcDeviceDataMessageRead += new FPlcDeviceDataMessageReadEventHandler(m_fPlcDriver_PlcDeviceDataMessageRead);
                m_fPlcDriver.PlcDeviceDataMessageWritten += new FPlcDeviceDataMessageWrittenEventHandler(m_fPlcDriver_PlcDeviceDataMessageWritten);
                // --
                m_fPlcDriver.HostDeviceStateChanged += new FHostDeviceStateChangedEventHandler(m_fPlcDriver_HostDeviceStateChanged);
                m_fPlcDriver.HostDeviceErrorRaised += new FHostDeviceErrorRaisedEventHandler(m_fPlcDriver_HostDeviceErrorRaised);
                m_fPlcDriver.HostDeviceVfeiReceived += new FHostDeviceVfeiReceivedEventHandler(m_fPlcDriver_HostDeviceVfeiReceived);
                m_fPlcDriver.HostDeviceVfeiSent += new FHostDeviceVfeiSentEventHandler(m_fPlcDriver_HostDeviceVfeiSent);
                m_fPlcDriver.HostDeviceDataMessageReceived += new FHostDeviceDataMessageReceivedEventHandler(m_fPlcDriver_HostDeviceDataMessageReceived);
                m_fPlcDriver.HostDeviceDataMessageSent += new FHostDeviceDataMessageSentEventHandler(m_fPlcDriver_HostDeviceDataMessageSent);
                // --
                m_fPlcDriver.PlcTriggerRaised += new FPlcTriggerRaisedEventHandler(m_fPlcDriver_PlcTriggerRaised);
                m_fPlcDriver.PlcTransmitterRaised += new FPlcTransmitterRaisedEventHandler(m_fPlcDriver_PlcTransmitterRaised);
                m_fPlcDriver.HostTriggerRaised += new FHostTriggerRaisedEventHandler(m_fPlcDriver_HostTriggerRaised);
                m_fPlcDriver.HostTransmitterRaised += new FHostTransmitterRaisedEventHandler(m_fPlcDriver_HostTransmitterRaised);
                m_fPlcDriver.JudgementPerformed += new FJudgementPerformedEventHandler(m_fPlcDriver_JudgementPerformed);
                m_fPlcDriver.EquipmentStateSetAltererPerformed += new FEquipmentStateSetAltererPerformedEventHandler(m_fPlcDriver_EquipmentStateSetAltererPerformed);
                m_fPlcDriver.MapperPerformed += new FMapperPerformedEventHandler(m_fPlcDriver_MapperPerformed);
                m_fPlcDriver.StoragePerformed += new FStoragePerformedEventHandler(m_fPlcDriver_StoragePerformed);
                m_fPlcDriver.CallbackRaised += new FCallbackRaisedEventHandler(m_fPlcDriver_CallbackRaised);
                m_fPlcDriver.FunctionCalled += new FFunctionCalledEventHandler(m_fPlcDriver_FunctionCalled);
                m_fPlcDriver.BranchRaised += new FBranchRaisedEventHandler(m_fPlcDriver_BranchRaised);
                m_fPlcDriver.CommentWritten += new FCommentWrittenEventHandler(m_fPlcDriver_CommentWritten);
                m_fPlcDriver.EntryPointCalled += new FEntryPointCalledEventHandler(m_fPlcDriver_EntryPointCalled);
                m_fPlcDriver.PauserRaised += new FPauserRaisedEventHandler(m_fPlcDriver_PauserRaised);
                m_fPlcDriver.ApplicationWritten += new FApplicationWrittenEventHandler(m_fPlcDriver_ApplicationWritten);
                // --
                // ***
                // 2017.05.31 by spike.lee
                // Repository Material Saved 이벤트 추가
                // ***
                m_fPlcDriver.RepositoryMaterialSaved += new FRepositoryMaterialSavedEventHandler(m_fPlcDriver_RepositoryMaterialSaved);
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

        private void term(
            )
        {
            try
            {
                m_fPlcDriver.ModelingFileOpenCompleted -= new FModelingFileOpenCompletedEventHandler(m_fPlcDriver_ModelingFileOpenCompleted);
                m_fPlcDriver.ModelingFileReopenPrecompleted -= new FModelingFileReopenPrecompletedEventHandler(m_fPlcDriver_ModelingFileReopenPrecompleted);
                m_fPlcDriver.ModelingFileReopenCompleted -= new FModelingFileReopenCompletedEventHandler(m_fPlcDriver_ModelingFileReopenCompleted);
                m_fPlcDriver.ModelingFileReopenFailed -= new FModelingFileReopenFailedEventHandler(m_fPlcDriver_ModelingFileReopenFailed);
                m_fPlcDriver.ModelingFileSaveCompleted -= new FModelingFileSaveCompletedEventHandler(m_fPlcDriver_ModelingFileSaveCompleted);
                //--
                m_fPlcDriver.ObjectModifyCompleted -= new FObjectModifyCompletedEventHandler(m_fPlcDriver_ObjectModifyCompleted);
                m_fPlcDriver.ObjectInsertBeforeCompleted -= new FObjectInsertBeforeCompletedEventHandler(m_fPlcDriver_ObjectInsertBeforeCompleted);
                m_fPlcDriver.ObjectInsertAfterCompleted -= new FObjectInsertAfterCompletedEventHandler(m_fPlcDriver_ObjectInsertAfterCompleted);
                m_fPlcDriver.ObjectAppendCompleted -= new FObjectAppendCompletedEventHandler(m_fPlcDriver_ObjectAppendCompleted);
                m_fPlcDriver.ObjectRemoveCompleted -= new FObjectRemoveCompletedEventHandler(m_fPlcDriver_ObjectRemoveCompleted);
                m_fPlcDriver.ObjectMoveUpCompleted -= new FObjectMoveUpCompletedEventHandler(m_fPlcDriver_ObjectMoveUpCompleted);
                m_fPlcDriver.ObjectMoveDownCompleted -= new FObjectMoveDownCompletedEventHandler(m_fPlcDriver_ObjectMoveDownCompleted);
                m_fPlcDriver.ObjectMoveToCompleted -= new FObjectMoveToCompletedEventHandler(m_fPlcDriver_ObjectMoveToCompleted);
                // --
                m_fPlcDriver.PlcDeviceStateChanged -= new FPlcDeviceStateChangedEventHandler(m_fPlcDriver_PlcDeviceStateChanged);
                m_fPlcDriver.PlcDeviceErrorRaised -= new FPlcDeviceErrorRaisedEventHandler(m_fPlcDriver_PlcDeviceErrorRaised);
                m_fPlcDriver.PlcDeviceTimeoutRaised -= new FPlcDeviceTimeoutRaisedEventHandler(m_fPlcDriver_PlcDeviceTimeoutRaised);
                m_fPlcDriver.PlcDeviceDataReceived -= new FPlcDeviceDataReceivedEventHandler(m_fPlcDriver_PlcDeviceDataReceived);
                m_fPlcDriver.PlcDeviceDataSent -= new FPlcDeviceDataSentEventHandler(m_fPlcDriver_PlcDeviceDataSent);
                m_fPlcDriver.PlcDeviceDataMessageRead -= new FPlcDeviceDataMessageReadEventHandler(m_fPlcDriver_PlcDeviceDataMessageRead);
                m_fPlcDriver.PlcDeviceDataMessageWritten -= new FPlcDeviceDataMessageWrittenEventHandler(m_fPlcDriver_PlcDeviceDataMessageWritten);
                // --
                m_fPlcDriver.HostDeviceStateChanged -= new FHostDeviceStateChangedEventHandler(m_fPlcDriver_HostDeviceStateChanged);
                m_fPlcDriver.HostDeviceErrorRaised -= new FHostDeviceErrorRaisedEventHandler(m_fPlcDriver_HostDeviceErrorRaised);
                m_fPlcDriver.HostDeviceVfeiReceived -= new FHostDeviceVfeiReceivedEventHandler(m_fPlcDriver_HostDeviceVfeiReceived);
                m_fPlcDriver.HostDeviceVfeiSent -= new FHostDeviceVfeiSentEventHandler(m_fPlcDriver_HostDeviceVfeiSent);
                m_fPlcDriver.HostDeviceDataMessageReceived -= new FHostDeviceDataMessageReceivedEventHandler(m_fPlcDriver_HostDeviceDataMessageReceived);
                m_fPlcDriver.HostDeviceDataMessageSent -= new FHostDeviceDataMessageSentEventHandler(m_fPlcDriver_HostDeviceDataMessageSent);
                // --
                m_fPlcDriver.PlcTriggerRaised -= new FPlcTriggerRaisedEventHandler(m_fPlcDriver_PlcTriggerRaised);
                m_fPlcDriver.PlcTransmitterRaised -= new FPlcTransmitterRaisedEventHandler(m_fPlcDriver_PlcTransmitterRaised);
                m_fPlcDriver.HostTriggerRaised -= new FHostTriggerRaisedEventHandler(m_fPlcDriver_HostTriggerRaised);
                m_fPlcDriver.HostTransmitterRaised -= new FHostTransmitterRaisedEventHandler(m_fPlcDriver_HostTransmitterRaised);
                m_fPlcDriver.CallbackRaised -= new FCallbackRaisedEventHandler(m_fPlcDriver_CallbackRaised);
                m_fPlcDriver.JudgementPerformed -= new FJudgementPerformedEventHandler(m_fPlcDriver_JudgementPerformed);
                m_fPlcDriver.EquipmentStateSetAltererPerformed -= new FEquipmentStateSetAltererPerformedEventHandler(m_fPlcDriver_EquipmentStateSetAltererPerformed);
                m_fPlcDriver.MapperPerformed -= new FMapperPerformedEventHandler(m_fPlcDriver_MapperPerformed);
                m_fPlcDriver.StoragePerformed -= new FStoragePerformedEventHandler(m_fPlcDriver_StoragePerformed);
                m_fPlcDriver.FunctionCalled -= new FFunctionCalledEventHandler(m_fPlcDriver_FunctionCalled);
                m_fPlcDriver.BranchRaised -= new FBranchRaisedEventHandler(m_fPlcDriver_BranchRaised);
                m_fPlcDriver.CommentWritten -= new FCommentWrittenEventHandler(m_fPlcDriver_CommentWritten);
                m_fPlcDriver.EntryPointCalled -= new FEntryPointCalledEventHandler(m_fPlcDriver_EntryPointCalled);
                m_fPlcDriver.PauserRaised += new FPauserRaisedEventHandler(m_fPlcDriver_PauserRaised);
                m_fPlcDriver.ApplicationWritten -= new FApplicationWrittenEventHandler(m_fPlcDriver_ApplicationWritten);
                // --
                // ***
                // 2017.05.31 by spike.lee
                // Repository Material Saved 이벤트 추가
                // ***
                m_fPlcDriver.RepositoryMaterialSaved -= new FRepositoryMaterialSavedEventHandler(m_fPlcDriver_RepositoryMaterialSaved);
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

        private bool validateInvoker(
            )
        {
            try
            {
                if (m_invoker != null)
                {
                    if (!m_invoker.Created || !m_invoker.IsHandleCreated)
                    {
                        return false;
                    }
                }                
                return true;
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

        public void waitEventHandlingCompleted(
            )
        {
            try
            {
                m_fPlcDriver.waitEventHandlingCompleted();
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

        #region m_fPlcDriver Modeling Event Handler

        private void m_fPlcDriver_ModelingFileOpenCompleted(
            object sender, 
            FModelingFileOpenCompletedEventArgs e
            )
        {
            try
            {
                if (ModelingFileOpenCompleted == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    ModelingFileOpenCompleted(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        ModelingFileOpenCompleted(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_ModelingFileReopenPrecompleted(
            object sender,
            FModelingFileReopenPrecompletedEventArgs e
            )
        {
            try
            {
                if (ModelingFileReopenPrecompleted == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    ModelingFileReopenPrecompleted(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        ModelingFileReopenPrecompleted(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_ModelingFileReopenCompleted(
            object sender, 
            FModelingFileReopenCompletedEventArgs e
            )
        {
            try
            {
                if (ModelingFileReopenCompleted == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    ModelingFileReopenCompleted(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        ModelingFileReopenCompleted(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_ModelingFileReopenFailed(
            object sender, 
            FModelingFileReopenFailedEventArgs e
            )
        {
            try
            {
                if (ModelingFileReopenFailed == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    ModelingFileReopenFailed(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        ModelingFileReopenFailed(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_ModelingFileSaveCompleted(
            object sender, 
            FModelingFileSaveCompletedEventArgs e
            )
        {
            try
            {
                if (ModelingFileSaveCompleted == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    ModelingFileSaveCompleted(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        ModelingFileSaveCompleted(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_ObjectInsertBeforeCompleted(
            object sender, 
            FObjectEventArgs e
            )
        {
            try
            {
                if (ObjectInsertBeforeCompleted == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }
                
                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    ObjectInsertBeforeCompleted(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        ObjectInsertBeforeCompleted(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_ObjectInsertAfterCompleted(
            object sender, 
            FObjectEventArgs e
            )
        {
            try
            {
                if (ObjectInsertAfterCompleted == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    ObjectInsertAfterCompleted(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        ObjectInsertAfterCompleted(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_ObjectAppendCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (ObjectAppendCompleted == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    ObjectAppendCompleted(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        ObjectAppendCompleted(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_ObjectRemoveCompleted(
            object sender, 
            FObjectEventArgs e
            )
        {
            try
            {
                if (ObjectRemoveCompleted == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    ObjectRemoveCompleted(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        ObjectRemoveCompleted(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }
         
        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_ObjectModifyCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (ObjectModifyCompleted == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    ObjectModifyCompleted(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        ObjectModifyCompleted(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_ObjectMoveUpCompleted(
            object sender, 
            FObjectEventArgs e
            )
        {
            try
            {
                if (ObjectMoveUpCompleted == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    ObjectMoveUpCompleted(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        ObjectMoveUpCompleted(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_ObjectMoveDownCompleted(
            object sender, 
            FObjectEventArgs e
            )
        {
            try
            {
                if (ObjectMoveDownCompleted == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    ObjectMoveDownCompleted(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        ObjectMoveDownCompleted(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_ObjectMoveToCompleted(
            object sender,
            FObjectMoveToCompletedEventArgs e
            )
        {
            try
            {
                if (ObjectMoveToCompleted == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    ObjectMoveToCompleted(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        ObjectMoveToCompleted(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_RepositoryMaterialSaved(
            object sender,
            FRepositoryMaterialSavedEventArgs e
            )
        {
            try
            {
                if (RepositoryMaterialSaved == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    RepositoryMaterialSaved(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        RepositoryMaterialSaved(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }  

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fPlcDriver Communication Event Handler

        private void m_fPlcDriver_PlcDeviceStateChanged(
            object sender,
            FPlcDeviceStateChangedEventArgs e
            )
        {
            try
            {
                if (PlcDeviceStateChanged == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    PlcDeviceStateChanged(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        PlcDeviceStateChanged(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_PlcDeviceErrorRaised(
            object sender,
            FPlcDeviceErrorRaisedEventArgs e
            )
        {
            try
            {
                if (PlcDeviceErrorRaised == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    PlcDeviceErrorRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        PlcDeviceErrorRaised(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void m_fPlcDriver_PlcDeviceDataReceived(
            object sender,
            FPlcDeviceDataReceivedEventArgs e
            )
        {
            try
            {
                if (PlcDeviceDataReceived == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    PlcDeviceDataReceived(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        PlcDeviceDataReceived(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_PlcDeviceDataSent(
            object sender,
            FPlcDeviceDataSentEventArgs e
            )
        {
            try
            {
                if (PlcDeviceDataSent == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    PlcDeviceDataSent(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        PlcDeviceDataSent(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_PlcDeviceDataMessageRead(
            object sender,
            FPlcDeviceDataMessageReadEventArgs e
            )
        {
            try
            {
                if (PlcDeviceDataMessageRead == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    PlcDeviceDataMessageRead(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        PlcDeviceDataMessageRead(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_PlcDeviceDataMessageWritten(
            object sender, 
            FPlcDeviceDataMessageWrittenEventArgs e
            )
        {
            try
            {
                if (PlcDeviceDataMessageWritten == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    PlcDeviceDataMessageWritten(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        PlcDeviceDataMessageWritten(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_PlcDeviceTimeoutRaised(
            object sender,
            FPlcDeviceTimeoutRaisedEventArgs e
            )
        {
            try
            {
                if (PlcDeviceTimeoutRaised == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    PlcDeviceTimeoutRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        PlcDeviceTimeoutRaised(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_HostDeviceStateChanged(
            object sender,
            FHostDeviceStateChangedEventArgs e
            )
        {
            try
            {
                if (HostDeviceStateChanged == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    HostDeviceStateChanged(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        HostDeviceStateChanged(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_HostDeviceErrorRaised(
            object sender,
            FHostDeviceErrorRaisedEventArgs e
            )
        {
            try
            {
                if (HostDeviceErrorRaised == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    HostDeviceErrorRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        HostDeviceErrorRaised(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_HostDeviceVfeiReceived(
            object sender,
            FHostDeviceVfeiReceivedEventArgs e
            )
        {
            try
            {
                if (HostDeviceVfeiReceived == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    HostDeviceVfeiReceived(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        HostDeviceVfeiReceived(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_HostDeviceVfeiSent(
            object sender,
            FHostDeviceVfeiSentEventArgs e
            )
        {
            try
            {
                if (HostDeviceVfeiSent == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    HostDeviceVfeiSent(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        HostDeviceVfeiSent(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_HostDeviceDataMessageReceived(
            object sender,
            FHostDeviceDataMessageReceivedEventArgs e
            )
        {
            try
            {
                if (HostDeviceDataMessageReceived == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    HostDeviceDataMessageReceived(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        HostDeviceDataMessageReceived(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_HostDeviceDataMessageSent(
            object sender,
            FHostDeviceDataMessageSentEventArgs e
            )
        {
            try
            {
                if (HostDeviceDataMessageSent == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    HostDeviceDataMessageSent(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        HostDeviceDataMessageSent(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_PlcTriggerRaised(
            object sender, 
            FPlcTriggerRaisedEventArgs e
            )
        {
            try
            {
                if (PlcTriggerRaised == null)
                {
                    return;
                }

                // --

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    PlcTriggerRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        PlcTriggerRaised(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_PlcTransmitterRaised(
            object sender, 
            FPlcTransmitterRaisedEventArgs e
            )
        {
            try
            {
                if (PlcTransmitterRaised == null)
                {
                    return;
                }

                // --

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    PlcTransmitterRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        PlcTransmitterRaised(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_HostTriggerRaised(
            object sender,
            FHostTriggerRaisedEventArgs e
            )
        {
            try
            {
                if (HostTriggerRaised == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    HostTriggerRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        HostTriggerRaised(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_HostTransmitterRaised(
            object sender,
            FHostTransmitterRaisedEventArgs e
            )
        {
            try
            {
                if (HostTransmitterRaised == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    HostTransmitterRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        HostTransmitterRaised(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_JudgementPerformed(
            object sender, 
            FJudgementPerformedEventArgs e
            )
        {
            try
            {
                if (JudgementPerformed == null)
                {
                    return;
                }

                // --

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    JudgementPerformed(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        JudgementPerformed(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_EquipmentStateSetAltererPerformed(
            object sender, 
            FEquipmentStateSetAltererPerformedEventArgs e
            )
        {
            try
            {
                if (EquipmentStateSetAltererPerformed == null)
                {
                    return;
                }

                // --

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    EquipmentStateSetAltererPerformed(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        EquipmentStateSetAltererPerformed(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_MapperPerformed(
            object sender, 
            FMapperPerformedEventArgs e
            )
        {
            try
            {
                if (MapperPerformed == null)
                {
                    return;
                }
                
                // --

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    MapperPerformed(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        MapperPerformed(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_StoragePerformed(
            object sender, 
            FStoragePerformedEventArgs e
            )
        {
            try
            {
                if (StoragePerformed == null)
                {
                    return;
                }

                // --

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    StoragePerformed(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        StoragePerformed(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_CallbackRaised(
            object sender,
            FCallbackRaisedEventArgs e
            )
        {
            try
            {
                if (CallbackRaised == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    CallbackRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        CallbackRaised(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_FunctionCalled(
            object sender,
            FFunctionCalledEventArgs e
            )
        {
            try
            {
                if (FunctionCalled == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    FunctionCalled(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        FunctionCalled(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_BranchRaised(
            object sender,
            FBranchRaisedEventArgs e
            )
        {
            try
            {
                if (BranchRaised == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    BranchRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        BranchRaised(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_CommentWritten(
            object sender,
            FCommentWrittenEventArgs e
            )
        {
            try
            {
                if (CommentWritten == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    CommentWritten(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        CommentWritten(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_EntryPointCalled(
            object sender, 
            FEntryPointCalledEventArgs e
            )
        {
            try
            {
                if (EntryPointCalled == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    EntryPointCalled(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        EntryPointCalled(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_PauserRaised(
            object sender,
            FPauserRaisedEventArgs e
            )
        {
            try
            {
                if (PauserRaised == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    PauserRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        PauserRaised(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fPlcDriver_ApplicationWritten(
            object sender,
            FApplicationWrittenEventArgs e
            )
        {
            try
            {
                if (CommentWritten == null)
                {
                    return;
                }

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    ApplicationWritten(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        ApplicationWritten(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
                // --
                FMessageBox.showError("FPlcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namepsace end
