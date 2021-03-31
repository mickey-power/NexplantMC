/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FEventHandler.cs
--  Creator         : spike.lee
--  Create Date     : 2013.07.10
--  Description     : FAMate Core FaOpcDriver Event Handler Class 
--  History         : Created by spike.lee at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
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
        public event FOpcDeviceStateChangedEventHandler OpcDeviceStateChanged = null;
        public event FOpcDeviceErrorRaisedEventHandler OpcDeviceErrorRaised = null;
        public event FOpcDeviceTimeoutRaisedEventHandler OpcDeviceTimeoutRaised = null;        
        public event FOpcDeviceDataMessageReadEventHandler OpcDeviceDataMessageRead = null;
        public event FOpcDeviceDataMessageWrittenEventHandler OpcDeviceDataMessageWritten = null;
        // --
        public event FOpcSessionItemNameRefreshedEventHandler OpcSessionItemNameRefreshed = null;
        // --
        public event FHostDeviceStateChangedEventHandler HostDeviceStateChanged = null;
        public event FHostDeviceErrorRaisedEventHandler HostDeviceErrorRaised = null;
        public event FHostDeviceVfeiReceivedEventHandler HostDeviceVfeiReceived = null;
        public event FHostDeviceVfeiSentEventHandler HostDeviceVfeiSent = null;
        public event FHostDeviceDataMessageReceivedEventHandler HostDeviceDataMessageReceived = null;
        public event FHostDeviceDataMessageSentEventHandler HostDeviceDataMessageSent = null;
        //--
        public event FOpcTriggerRaisedEventHandler OpcTriggerRaised = null;
        public event FOpcTransmitterRaisedEventHandler OpcTransmitterRaised = null;
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
        private FOpcDriver m_fOpcDriver = null;
        private Control m_invoker = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEventHandler(
            FOpcDriver fOpcDriver,
            Control invoker
            )
        {
            m_fOpcDriver = fOpcDriver;
            m_invoker = invoker;                     

            // --

            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEventHandler(
            FOpcDriver fOpcDriver
            )
            : this(fOpcDriver, null)
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

                    m_fOpcDriver = null;
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

        public FOpcDriver fOpcDriver
        {
            get
            {
                try
                {
                    return m_fOpcDriver;
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
                    return m_fOpcDriver.eventCount;
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
                    return m_fOpcDriver.isCompletedEventHandling;
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
                m_fOpcDriver.ModelingFileOpenCompleted += new FModelingFileOpenCompletedEventHandler(m_fOpcDriver_ModelingFileOpenCompleted);
                m_fOpcDriver.ModelingFileReopenPrecompleted += new FModelingFileReopenPrecompletedEventHandler(m_fOpcDriver_ModelingFileReopenPrecompleted);
                m_fOpcDriver.ModelingFileReopenCompleted += new FModelingFileReopenCompletedEventHandler(m_fOpcDriver_ModelingFileReopenCompleted);
                m_fOpcDriver.ModelingFileReopenFailed += new FModelingFileReopenFailedEventHandler(m_fOpcDriver_ModelingFileReopenFailed);
                m_fOpcDriver.ModelingFileSaveCompleted += new FModelingFileSaveCompletedEventHandler(m_fOpcDriver_ModelingFileSaveCompleted);
                // --               
                m_fOpcDriver.ObjectModifyCompleted += new FObjectModifyCompletedEventHandler(m_fOpcDriver_ObjectModifyCompleted);                
                m_fOpcDriver.ObjectInsertBeforeCompleted += new FObjectInsertBeforeCompletedEventHandler(m_fOpcDriver_ObjectInsertBeforeCompleted);
                m_fOpcDriver.ObjectInsertAfterCompleted += new FObjectInsertAfterCompletedEventHandler(m_fOpcDriver_ObjectInsertAfterCompleted);
                m_fOpcDriver.ObjectAppendCompleted += new FObjectAppendCompletedEventHandler(m_fOpcDriver_ObjectAppendCompleted);
                m_fOpcDriver.ObjectRemoveCompleted += new FObjectRemoveCompletedEventHandler(m_fOpcDriver_ObjectRemoveCompleted);
                m_fOpcDriver.ObjectMoveUpCompleted += new FObjectMoveUpCompletedEventHandler(m_fOpcDriver_ObjectMoveUpCompleted);
                m_fOpcDriver.ObjectMoveDownCompleted += new FObjectMoveDownCompletedEventHandler(m_fOpcDriver_ObjectMoveDownCompleted);
                m_fOpcDriver.ObjectMoveToCompleted += new FObjectMoveToCompletedEventHandler(m_fOpcDriver_ObjectMoveToCompleted);
                // --
                m_fOpcDriver.OpcDeviceStateChanged += new FOpcDeviceStateChangedEventHandler(m_fOpcDriver_OpcDeviceStateChanged);
                m_fOpcDriver.OpcDeviceErrorRaised += new FOpcDeviceErrorRaisedEventHandler(m_fOpcDriver_OpcDeviceErrorRaised);
                m_fOpcDriver.OpcDeviceTimeoutRaised += new FOpcDeviceTimeoutRaisedEventHandler(m_fOpcDriver_OpcDeviceTimeoutRaised);                
                m_fOpcDriver.OpcDeviceDataMessageRead += new FOpcDeviceDataMessageReadEventHandler(m_fOpcDriver_OpcDeviceDataMessageRead);
                m_fOpcDriver.OpcDeviceDataMessageWritten += new FOpcDeviceDataMessageWrittenEventHandler(m_fOpcDriver_OpcDeviceDataMessageWritten);
                // --
                m_fOpcDriver.OpcSessionItemNameRefreshed += new FOpcSessionItemNameRefreshedEventHandler(m_fOpcDriver_OpcSessionItemNameRefreshed);
                // -- 
                m_fOpcDriver.HostDeviceStateChanged += new FHostDeviceStateChangedEventHandler(m_fOpcDriver_HostDeviceStateChanged);
                m_fOpcDriver.HostDeviceErrorRaised += new FHostDeviceErrorRaisedEventHandler(m_fOpcDriver_HostDeviceErrorRaised);
                m_fOpcDriver.HostDeviceVfeiReceived += new FHostDeviceVfeiReceivedEventHandler(m_fOpcDriver_HostDeviceVfeiReceived);
                m_fOpcDriver.HostDeviceVfeiSent += new FHostDeviceVfeiSentEventHandler(m_fOpcDriver_HostDeviceVfeiSent);
                m_fOpcDriver.HostDeviceDataMessageReceived += new FHostDeviceDataMessageReceivedEventHandler(m_fOpcDriver_HostDeviceDataMessageReceived);
                m_fOpcDriver.HostDeviceDataMessageSent += new FHostDeviceDataMessageSentEventHandler(m_fOpcDriver_HostDeviceDataMessageSent);
                // --
                m_fOpcDriver.OpcTriggerRaised += new FOpcTriggerRaisedEventHandler(m_fOpcDriver_OpcTriggerRaised);
                m_fOpcDriver.OpcTransmitterRaised += new FOpcTransmitterRaisedEventHandler(m_fOpcDriver_OpcTransmitterRaised);
                m_fOpcDriver.HostTriggerRaised += new FHostTriggerRaisedEventHandler(m_fOpcDriver_HostTriggerRaised);
                m_fOpcDriver.HostTransmitterRaised += new FHostTransmitterRaisedEventHandler(m_fOpcDriver_HostTransmitterRaised);
                m_fOpcDriver.JudgementPerformed += new FJudgementPerformedEventHandler(m_fOpcDriver_JudgementPerformed);
                m_fOpcDriver.EquipmentStateSetAltererPerformed += new FEquipmentStateSetAltererPerformedEventHandler(m_fOpcDriver_EquipmentStateSetAltererPerformed);
                m_fOpcDriver.MapperPerformed += new FMapperPerformedEventHandler(m_fOpcDriver_MapperPerformed);
                m_fOpcDriver.StoragePerformed += new FStoragePerformedEventHandler(m_fOpcDriver_StoragePerformed);
                m_fOpcDriver.CallbackRaised += new FCallbackRaisedEventHandler(m_fOpcDriver_CallbackRaised);
                m_fOpcDriver.FunctionCalled += new FFunctionCalledEventHandler(m_fOpcDriver_FunctionCalled);
                m_fOpcDriver.BranchRaised += new FBranchRaisedEventHandler(m_fOpcDriver_BranchRaised);
                m_fOpcDriver.CommentWritten += new FCommentWrittenEventHandler(m_fOpcDriver_CommentWritten);
                m_fOpcDriver.EntryPointCalled += new FEntryPointCalledEventHandler(m_fOpcDriver_EntryPointCalled);
                m_fOpcDriver.PauserRaised += new FPauserRaisedEventHandler(m_fOpcDriver_PauserRaised);
                m_fOpcDriver.ApplicationWritten += new FApplicationWrittenEventHandler(m_fOpcDriver_ApplicationWritten);
                // --
                // ***
                // 2017.05.31 by spike.lee
                // Repository Material Saved 이벤트 추가
                // ***
                m_fOpcDriver.RepositoryMaterialSaved += new FRepositoryMaterialSavedEventHandler(m_fOpcDriver_RepositoryMaterialSaved);
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
                m_fOpcDriver.ModelingFileOpenCompleted -= new FModelingFileOpenCompletedEventHandler(m_fOpcDriver_ModelingFileOpenCompleted);
                m_fOpcDriver.ModelingFileReopenPrecompleted -= new FModelingFileReopenPrecompletedEventHandler(m_fOpcDriver_ModelingFileReopenPrecompleted);
                m_fOpcDriver.ModelingFileReopenCompleted -= new FModelingFileReopenCompletedEventHandler(m_fOpcDriver_ModelingFileReopenCompleted);
                m_fOpcDriver.ModelingFileReopenFailed -= new FModelingFileReopenFailedEventHandler(m_fOpcDriver_ModelingFileReopenFailed);
                m_fOpcDriver.ModelingFileSaveCompleted -= new FModelingFileSaveCompletedEventHandler(m_fOpcDriver_ModelingFileSaveCompleted);
                //--
                m_fOpcDriver.ObjectModifyCompleted -= new FObjectModifyCompletedEventHandler(m_fOpcDriver_ObjectModifyCompleted);
                m_fOpcDriver.ObjectInsertBeforeCompleted -= new FObjectInsertBeforeCompletedEventHandler(m_fOpcDriver_ObjectInsertBeforeCompleted);
                m_fOpcDriver.ObjectInsertAfterCompleted -= new FObjectInsertAfterCompletedEventHandler(m_fOpcDriver_ObjectInsertAfterCompleted);
                m_fOpcDriver.ObjectAppendCompleted -= new FObjectAppendCompletedEventHandler(m_fOpcDriver_ObjectAppendCompleted);
                m_fOpcDriver.ObjectRemoveCompleted -= new FObjectRemoveCompletedEventHandler(m_fOpcDriver_ObjectRemoveCompleted);
                m_fOpcDriver.ObjectMoveUpCompleted -= new FObjectMoveUpCompletedEventHandler(m_fOpcDriver_ObjectMoveUpCompleted);
                m_fOpcDriver.ObjectMoveDownCompleted -= new FObjectMoveDownCompletedEventHandler(m_fOpcDriver_ObjectMoveDownCompleted);
                m_fOpcDriver.ObjectMoveToCompleted -= new FObjectMoveToCompletedEventHandler(m_fOpcDriver_ObjectMoveToCompleted);
                // --
                m_fOpcDriver.OpcDeviceStateChanged -= new FOpcDeviceStateChangedEventHandler(m_fOpcDriver_OpcDeviceStateChanged);
                m_fOpcDriver.OpcDeviceErrorRaised -= new FOpcDeviceErrorRaisedEventHandler(m_fOpcDriver_OpcDeviceErrorRaised);
                m_fOpcDriver.OpcDeviceTimeoutRaised -= new FOpcDeviceTimeoutRaisedEventHandler(m_fOpcDriver_OpcDeviceTimeoutRaised);
                m_fOpcDriver.OpcDeviceDataMessageRead -= new FOpcDeviceDataMessageReadEventHandler(m_fOpcDriver_OpcDeviceDataMessageRead);
                m_fOpcDriver.OpcDeviceDataMessageWritten -= new FOpcDeviceDataMessageWrittenEventHandler(m_fOpcDriver_OpcDeviceDataMessageWritten);
                // --
                m_fOpcDriver.OpcSessionItemNameRefreshed -= new FOpcSessionItemNameRefreshedEventHandler(m_fOpcDriver_OpcSessionItemNameRefreshed);
                // --
                m_fOpcDriver.HostDeviceStateChanged -= new FHostDeviceStateChangedEventHandler(m_fOpcDriver_HostDeviceStateChanged);
                m_fOpcDriver.HostDeviceErrorRaised -= new FHostDeviceErrorRaisedEventHandler(m_fOpcDriver_HostDeviceErrorRaised);
                m_fOpcDriver.HostDeviceVfeiReceived -= new FHostDeviceVfeiReceivedEventHandler(m_fOpcDriver_HostDeviceVfeiReceived);
                m_fOpcDriver.HostDeviceVfeiSent -= new FHostDeviceVfeiSentEventHandler(m_fOpcDriver_HostDeviceVfeiSent);
                m_fOpcDriver.HostDeviceDataMessageReceived -= new FHostDeviceDataMessageReceivedEventHandler(m_fOpcDriver_HostDeviceDataMessageReceived);
                m_fOpcDriver.HostDeviceDataMessageSent -= new FHostDeviceDataMessageSentEventHandler(m_fOpcDriver_HostDeviceDataMessageSent);
                // --
                m_fOpcDriver.OpcTriggerRaised -= new FOpcTriggerRaisedEventHandler(m_fOpcDriver_OpcTriggerRaised);
                m_fOpcDriver.OpcTransmitterRaised -= new FOpcTransmitterRaisedEventHandler(m_fOpcDriver_OpcTransmitterRaised);
                m_fOpcDriver.HostTriggerRaised -= new FHostTriggerRaisedEventHandler(m_fOpcDriver_HostTriggerRaised);
                m_fOpcDriver.HostTransmitterRaised -= new FHostTransmitterRaisedEventHandler(m_fOpcDriver_HostTransmitterRaised);
                m_fOpcDriver.CallbackRaised -= new FCallbackRaisedEventHandler(m_fOpcDriver_CallbackRaised);
                m_fOpcDriver.JudgementPerformed -= new FJudgementPerformedEventHandler(m_fOpcDriver_JudgementPerformed);
                m_fOpcDriver.EquipmentStateSetAltererPerformed -= new FEquipmentStateSetAltererPerformedEventHandler(m_fOpcDriver_EquipmentStateSetAltererPerformed);
                m_fOpcDriver.MapperPerformed -= new FMapperPerformedEventHandler(m_fOpcDriver_MapperPerformed);
                m_fOpcDriver.StoragePerformed -= new FStoragePerformedEventHandler(m_fOpcDriver_StoragePerformed);
                m_fOpcDriver.FunctionCalled -= new FFunctionCalledEventHandler(m_fOpcDriver_FunctionCalled);
                m_fOpcDriver.BranchRaised -= new FBranchRaisedEventHandler(m_fOpcDriver_BranchRaised);
                m_fOpcDriver.CommentWritten -= new FCommentWrittenEventHandler(m_fOpcDriver_CommentWritten);
                m_fOpcDriver.EntryPointCalled -= new FEntryPointCalledEventHandler(m_fOpcDriver_EntryPointCalled);
                m_fOpcDriver.PauserRaised += new FPauserRaisedEventHandler(m_fOpcDriver_PauserRaised);
                m_fOpcDriver.ApplicationWritten -= new FApplicationWrittenEventHandler(m_fOpcDriver_ApplicationWritten);
                // --
                // ***
                // 2017.05.31 by spike.lee
                // Repository Material Saved 이벤트 추가
                // ***
                m_fOpcDriver.RepositoryMaterialSaved -= new FRepositoryMaterialSavedEventHandler(m_fOpcDriver_RepositoryMaterialSaved);
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
                m_fOpcDriver.waitEventHandlingCompleted();
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

        #region m_fOpcDriver Modeling Event Handler

        private void m_fOpcDriver_ModelingFileOpenCompleted(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_ModelingFileReopenPrecompleted(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_ModelingFileReopenCompleted(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_ModelingFileReopenFailed(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_ModelingFileSaveCompleted(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_ObjectInsertBeforeCompleted(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_ObjectInsertAfterCompleted(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_ObjectAppendCompleted(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_ObjectRemoveCompleted(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }
         
        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_ObjectModifyCompleted(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_ObjectMoveUpCompleted(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_ObjectMoveDownCompleted(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_ObjectMoveToCompleted(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_RepositoryMaterialSaved(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }  

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fOpcDriver Communication Event Handler

        private void m_fOpcDriver_OpcDeviceStateChanged(
            object sender,
            FOpcDeviceStateChangedEventArgs e
            )
        {
            try
            {
                if (OpcDeviceStateChanged == null)
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
                    OpcDeviceStateChanged(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        OpcDeviceStateChanged(this, e);
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_OpcDeviceErrorRaised(
            object sender,
            FOpcDeviceErrorRaisedEventArgs e
            )
        {
            try
            {
                if (OpcDeviceErrorRaised == null)
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
                    OpcDeviceErrorRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        OpcDeviceErrorRaised(this, e);
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void m_fOpcDriver_OpcDeviceDataMessageRead(
            object sender,
            FOpcDeviceDataMessageReadEventArgs e
            )
        {
            try
            {
                if (OpcDeviceDataMessageRead == null)
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
                    OpcDeviceDataMessageRead(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        OpcDeviceDataMessageRead(this, e);
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_OpcDeviceDataMessageWritten(
            object sender, 
            FOpcDeviceDataMessageWrittenEventArgs e
            )
        {
            try
            {
                if (OpcDeviceDataMessageWritten == null)
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
                    OpcDeviceDataMessageWritten(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        OpcDeviceDataMessageWritten(this, e);
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_OpcDeviceTimeoutRaised(
            object sender,
            FOpcDeviceTimeoutRaisedEventArgs e
            )
        {
            try
            {
                if (OpcDeviceTimeoutRaised == null)
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
                    OpcDeviceTimeoutRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        OpcDeviceTimeoutRaised(this, e);
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_HostDeviceStateChanged(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_HostDeviceErrorRaised(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_HostDeviceVfeiReceived(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_HostDeviceVfeiSent(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_HostDeviceDataMessageReceived(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_HostDeviceDataMessageSent(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_OpcTriggerRaised(
            object sender, 
            FOpcTriggerRaisedEventArgs e
            )
        {
            try
            {
                if (OpcTriggerRaised == null)
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
                    OpcTriggerRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        OpcTriggerRaised(this, e);
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_OpcTransmitterRaised(
            object sender, 
            FOpcTransmitterRaisedEventArgs e
            )
        {
            try
            {
                if (OpcTransmitterRaised == null)
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
                    OpcTransmitterRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        OpcTransmitterRaised(this, e);
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_HostTriggerRaised(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_HostTransmitterRaised(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_JudgementPerformed(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_EquipmentStateSetAltererPerformed(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_MapperPerformed(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_StoragePerformed(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_CallbackRaised(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_FunctionCalled(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_BranchRaised(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_CommentWritten(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_EntryPointCalled(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_PauserRaised(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_ApplicationWritten(
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fOpcDriver_OpcSessionItemNameRefreshed(
            object sender, 
            FOpcSessionItemNameRefreshedEventArgs e
            )
        {
            try
            {
                if (OpcSessionItemNameRefreshed == null)
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
                    OpcSessionItemNameRefreshed(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        OpcSessionItemNameRefreshed(this, e);
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
                FMessageBox.showError("FOpcEventHandler", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namepsace end
