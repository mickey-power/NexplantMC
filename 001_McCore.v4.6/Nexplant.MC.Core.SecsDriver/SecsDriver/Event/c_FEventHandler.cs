/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FEventHandler.cs
--  Creator         : spike.lee
--  Create Date     : 2011.02.01
--  Description     : FAMate Core FaSecsDriver Event Handler Class 
--  History         : Created by spike.lee at 2011.02.01
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
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
        public event FSecsDeviceStateChangedEventHandler SecsDeviceStateChanged = null;
        public event FSecsDeviceErrorRaisedEventHandler SecsDeviceErrorRaised = null;
        public event FSecsDeviceTimeoutRaisedEventHandler SecsDeviceTimeoutRaised = null;
        public event FSecsDeviceDataReceivedEventHandler SecsDeviceDataReceived = null;
        public event FSecsDeviceDataSentEventHandler SecsDeviceDataSent = null;
        public event FSecsDeviceTelnetPacketReceivedEventHandler SecsDeviceTelnetPacketReceived = null;
        public event FSecsDeviceTelnetPacketSentEventHandler SecsDeviceTelnetPacketSent = null;
        public event FSecsDeviceTelnetStateChangedEventHandler SecsDeviceTelnetStateChanged = null;
        public event FSecsDeviceHandshakeReceivedEventHandler SecsDeviceHandshakeReceived = null;
        public event FSecsDeviceHandshakeSentEventHandler SecsDeviceHandshakeSent = null;
        public event FSecsDeviceControlMessageReceivedEventHandler SecsDeviceControlMessageReceived = null;
        public event FSecsDeviceControlMessageSentEventHandler SecsDeviceControlMessageSent = null;
        public event FSecsDeviceBlockReceivedEventHandler SecsDeviceBlockReceived = null;
        public event FSecsDeviceBlockSentEventHandler SecsDeviceBlockSent = null;
        public event FSecsDeviceSmlReceivedEventHandler SecsDeviceSmlReceived = null;
        public event FSecsDeviceSmlSentEventHandler SecsDeviceSmlSent = null;
        public event FSecsDeviceDataMessageReceivedEventHandler SecsDeviceDataMessageReceived = null;
        public event FSecsDeviceDataMessageSentEventHandler SecsDeviceDataMessageSent = null;
        // --
        public event FHostDeviceStateChangedEventHandler HostDeviceStateChanged = null;
        public event FHostDeviceErrorRaisedEventHandler HostDeviceErrorRaised = null;
        public event FHostDeviceVfeiReceivedEventHandler HostDeviceVfeiReceived = null;
        public event FHostDeviceVfeiSentEventHandler HostDeviceVfeiSent = null;
        public event FHostDeviceDataMessageReceivedEventHandler HostDeviceDataMessageReceived = null;
        public event FHostDeviceDataMessageSentEventHandler HostDeviceDataMessageSent = null;
        //--
        public event FSecsTriggerRaisedEventHandler SecsTriggerRaised = null;
        public event FSecsTransmitterRaisedEventHandler SecsTransmitterRaised = null;
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
        private FSecsDriver m_fSecsDriver = null;
        private Control m_invoker = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEventHandler(
            FSecsDriver fSecsDriver,
            Control invoker
            )
        {
            m_fSecsDriver = fSecsDriver;
            m_invoker = invoker;
            
            // --

            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEventHandler(
            FSecsDriver fSecsDriver
            )
            : this(fSecsDriver, null)
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

                    m_fSecsDriver = null;
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

        public FSecsDriver fSecsDriver
        {
            get
            {
                try
                {
                    return m_fSecsDriver;
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
                    return m_fSecsDriver.eventCount;
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
                    return m_fSecsDriver.isCompletedEventHandling;
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
                m_fSecsDriver.ModelingFileOpenCompleted += new FModelingFileOpenCompletedEventHandler(m_fSecsDriver_ModelingFileOpenCompleted);
                m_fSecsDriver.ModelingFileReopenPrecompleted += new FModelingFileReopenPrecompletedEventHandler(m_fSecsDriver_ModelingFileReopenPrecompleted);
                m_fSecsDriver.ModelingFileReopenCompleted += new FModelingFileReopenCompletedEventHandler(m_fSecsDriver_ModelingFileReopenCompleted);
                m_fSecsDriver.ModelingFileReopenFailed += new FModelingFileReopenFailedEventHandler(m_fSecsDriver_ModelingFileReopenFailed);
                m_fSecsDriver.ModelingFileSaveCompleted += new FModelingFileSaveCompletedEventHandler(m_fSecsDriver_ModelingFileSaveCompleted);
                // --               
                m_fSecsDriver.ObjectModifyCompleted += new FObjectModifyCompletedEventHandler(m_fSecsDriver_ObjectModifyCompleted);                
                m_fSecsDriver.ObjectInsertBeforeCompleted += new FObjectInsertBeforeCompletedEventHandler(m_fSecsDriver_ObjectInsertBeforeCompleted);
                m_fSecsDriver.ObjectInsertAfterCompleted += new FObjectInsertAfterCompletedEventHandler(m_fSecsDriver_ObjectInsertAfterCompleted);
                m_fSecsDriver.ObjectAppendCompleted += new FObjectAppendCompletedEventHandler(m_fSecsDriver_ObjectAppendCompleted);
                m_fSecsDriver.ObjectRemoveCompleted += new FObjectRemoveCompletedEventHandler(m_fSecsDriver_ObjectRemoveCompleted);
                m_fSecsDriver.ObjectMoveUpCompleted += new FObjectMoveUpCompletedEventHandler(m_fSecsDriver_ObjectMoveUpCompleted);
                m_fSecsDriver.ObjectMoveDownCompleted += new FObjectMoveDownCompletedEventHandler(m_fSecsDriver_ObjectMoveDownCompleted);
                m_fSecsDriver.ObjectMoveToCompleted += new FObjectMoveToCompletedEventHandler(m_fSecsDriver_ObjectMoveToCompleted);
                // --
                m_fSecsDriver.SecsDeviceStateChanged += new FSecsDeviceStateChangedEventHandler(m_fSecsDriver_SecsDeviceStateChanged);
                m_fSecsDriver.SecsDeviceErrorRaised += new FSecsDeviceErrorRaisedEventHandler(m_fSecsDriver_SecsDeviceErrorRaised);
                m_fSecsDriver.SecsDeviceTimeoutRaised += new FSecsDeviceTimeoutRaisedEventHandler(m_fSecsDriver_SecsDeviceTimeoutRaised);
                m_fSecsDriver.SecsDeviceDataReceived += new FSecsDeviceDataReceivedEventHandler(m_fSecsDriver_SecsDeviceDataReceived);
                m_fSecsDriver.SecsDeviceDataSent += new FSecsDeviceDataSentEventHandler(m_fSecsDriver_SecsDeviceDataSent);
                m_fSecsDriver.SecsDeviceTelnetPacketReceived += new FSecsDeviceTelnetPacketReceivedEventHandler(m_fSecsDriver_SecsDeviceTelnetPacketReceived);
                m_fSecsDriver.SecsDeviceTelnetPacketSent += new FSecsDeviceTelnetPacketSentEventHandler(m_fSecsDriver_SecsDeviceTelnetPacketSent);
                m_fSecsDriver.SecsDeviceTelnetStateChanged += new FSecsDeviceTelnetStateChangedEventHandler(m_fSecsDriver_SecsDeviceTelnetStateChanged);
                m_fSecsDriver.SecsDeviceHandshakeReceived += new FSecsDeviceHandshakeReceivedEventHandler(m_fSecsDriver_SecsDeviceHandshakeReceived);
                m_fSecsDriver.SecsDeviceHandshakeSent += new FSecsDeviceHandshakeSentEventHandler(m_fSecsDriver_SecsDeviceHandshakeSent);
                m_fSecsDriver.SecsDeviceControlMessageReceived += new FSecsDeviceControlMessageReceivedEventHandler(m_fSecsDriver_SecsDeviceControlMessageReceived);
                m_fSecsDriver.SecsDeviceControlMessageSent += new FSecsDeviceControlMessageSentEventHandler(m_fSecsDriver_SecsDeviceControlMessageSent);
                m_fSecsDriver.SecsDeviceBlockReceived += new FSecsDeviceBlockReceivedEventHandler(m_fSecsDriver_SecsDeviceBlockReceived);
                m_fSecsDriver.SecsDeviceBlockSent += new FSecsDeviceBlockSentEventHandler(m_fSecsDriver_SecsDeviceBlockSent);
                m_fSecsDriver.SecsDeviceSmlReceived += new FSecsDeviceSmlReceivedEventHandler(m_fSecsDriver_SecsDeviceSmlReceived);
                m_fSecsDriver.SecsDeviceSmlSent += new FSecsDeviceSmlSentEventHandler(m_fSecsDriver_SecsDeviceSmlSent);
                m_fSecsDriver.SecsDeviceDataMessageReceived += new FSecsDeviceDataMessageReceivedEventHandler(m_fSecsDriver_SecsDeviceDataMessageReceived);
                m_fSecsDriver.SecsDeviceDataMessageSent += new FSecsDeviceDataMessageSentEventHandler(m_fSecsDriver_SecsDeviceDataMessageSent);
                // --
                m_fSecsDriver.HostDeviceStateChanged += new FHostDeviceStateChangedEventHandler(m_fSecsDriver_HostDeviceStateChanged);
                m_fSecsDriver.HostDeviceErrorRaised += new FHostDeviceErrorRaisedEventHandler(m_fSecsDriver_HostDeviceErrorRaised);
                m_fSecsDriver.HostDeviceVfeiReceived += new FHostDeviceVfeiReceivedEventHandler(m_fSecsDriver_HostDeviceVfeiReceived);
                m_fSecsDriver.HostDeviceVfeiSent += new FHostDeviceVfeiSentEventHandler(m_fSecsDriver_HostDeviceVfeiSent);
                m_fSecsDriver.HostDeviceDataMessageReceived += new FHostDeviceDataMessageReceivedEventHandler(m_fSecsDriver_HostDeviceDataMessageReceived);
                m_fSecsDriver.HostDeviceDataMessageSent += new FHostDeviceDataMessageSentEventHandler(m_fSecsDriver_HostDeviceDataMessageSent);
                // --
                m_fSecsDriver.SecsTriggerRaised += new FSecsTriggerRaisedEventHandler(m_fSecsDriver_SecsTriggerRaised);
                m_fSecsDriver.SecsTransmitterRaised += new FSecsTransmitterRaisedEventHandler(m_fSecsDriver_SecsTransmitterRaised);
                m_fSecsDriver.HostTriggerRaised += new FHostTriggerRaisedEventHandler(m_fSecsDriver_HostTriggerRaised);
                m_fSecsDriver.HostTransmitterRaised += new FHostTransmitterRaisedEventHandler(m_fSecsDriver_HostTransmitterRaised);
                m_fSecsDriver.JudgementPerformed += new FJudgementPerformedEventHandler(m_fSecsDriver_JudgementPerformed);
                m_fSecsDriver.EquipmentStateSetAltererPerformed += new FEquipmentStateSetAltererPerformedEventHandler(m_fSecsDriver_EquipmentStateSetAltererPerformed);
                m_fSecsDriver.MapperPerformed += new FMapperPerformedEventHandler(m_fSecsDriver_MapperPerformed);
                m_fSecsDriver.StoragePerformed += new FStoragePerformedEventHandler(m_fSecsDriver_StoragePerformed);
                m_fSecsDriver.CallbackRaised += new FCallbackRaisedEventHandler(m_fSecsDriver_CallbackRaised);
                m_fSecsDriver.FunctionCalled += new FFunctionCalledEventHandler(m_fSecsDriver_FunctionCalled);
                m_fSecsDriver.BranchRaised += new FBranchRaisedEventHandler(m_fSecsDriver_BranchRaised);
                m_fSecsDriver.CommentWritten += new FCommentWrittenEventHandler(m_fSecsDriver_CommentWritten);
                m_fSecsDriver.EntryPointCalled += new FEntryPointCalledEventHandler(m_fSecsDriver_EntryPointCalled);
                m_fSecsDriver.PauserRaised += new FPauserRaisedEventHandler(m_fSecsDriver_PauserRaised);
                m_fSecsDriver.ApplicationWritten += new FApplicationWrittenEventHandler(m_fSecsDriver_ApplicationWritten);
                // --
                // ***
                // 2017.05.31 by spike.lee
                // Repository Material Saved 이벤트 추가
                // ***
                m_fSecsDriver.RepositoryMaterialSaved += new FRepositoryMaterialSavedEventHandler(m_fSecsDriver_RepositoryMaterialSaved);

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
                m_fSecsDriver.ModelingFileOpenCompleted -= new FModelingFileOpenCompletedEventHandler(m_fSecsDriver_ModelingFileOpenCompleted);
                m_fSecsDriver.ModelingFileReopenPrecompleted -= new FModelingFileReopenPrecompletedEventHandler(m_fSecsDriver_ModelingFileReopenPrecompleted);
                m_fSecsDriver.ModelingFileReopenCompleted -= new FModelingFileReopenCompletedEventHandler(m_fSecsDriver_ModelingFileReopenCompleted);
                m_fSecsDriver.ModelingFileReopenFailed -= new FModelingFileReopenFailedEventHandler(m_fSecsDriver_ModelingFileReopenFailed);
                m_fSecsDriver.ModelingFileSaveCompleted -= new FModelingFileSaveCompletedEventHandler(m_fSecsDriver_ModelingFileSaveCompleted);
                //--
                m_fSecsDriver.ObjectModifyCompleted -= new FObjectModifyCompletedEventHandler(m_fSecsDriver_ObjectModifyCompleted);
                m_fSecsDriver.ObjectInsertBeforeCompleted -= new FObjectInsertBeforeCompletedEventHandler(m_fSecsDriver_ObjectInsertBeforeCompleted);
                m_fSecsDriver.ObjectInsertAfterCompleted -= new FObjectInsertAfterCompletedEventHandler(m_fSecsDriver_ObjectInsertAfterCompleted);
                m_fSecsDriver.ObjectAppendCompleted -= new FObjectAppendCompletedEventHandler(m_fSecsDriver_ObjectAppendCompleted);
                m_fSecsDriver.ObjectRemoveCompleted -= new FObjectRemoveCompletedEventHandler(m_fSecsDriver_ObjectRemoveCompleted);
                m_fSecsDriver.ObjectMoveUpCompleted -= new FObjectMoveUpCompletedEventHandler(m_fSecsDriver_ObjectMoveUpCompleted);
                m_fSecsDriver.ObjectMoveDownCompleted -= new FObjectMoveDownCompletedEventHandler(m_fSecsDriver_ObjectMoveDownCompleted);
                m_fSecsDriver.ObjectMoveToCompleted -= new FObjectMoveToCompletedEventHandler(m_fSecsDriver_ObjectMoveToCompleted);
                //--
                m_fSecsDriver.SecsDeviceStateChanged -= new FSecsDeviceStateChangedEventHandler(m_fSecsDriver_SecsDeviceStateChanged);
                m_fSecsDriver.SecsDeviceErrorRaised -= new FSecsDeviceErrorRaisedEventHandler(m_fSecsDriver_SecsDeviceErrorRaised);
                m_fSecsDriver.SecsDeviceTimeoutRaised -= new FSecsDeviceTimeoutRaisedEventHandler(m_fSecsDriver_SecsDeviceTimeoutRaised);
                m_fSecsDriver.SecsDeviceDataReceived -= new FSecsDeviceDataReceivedEventHandler(m_fSecsDriver_SecsDeviceDataReceived);
                m_fSecsDriver.SecsDeviceDataSent -= new FSecsDeviceDataSentEventHandler(m_fSecsDriver_SecsDeviceDataSent);
                m_fSecsDriver.SecsDeviceTelnetPacketReceived -= new FSecsDeviceTelnetPacketReceivedEventHandler(m_fSecsDriver_SecsDeviceTelnetPacketReceived);
                m_fSecsDriver.SecsDeviceTelnetPacketSent -= new FSecsDeviceTelnetPacketSentEventHandler(m_fSecsDriver_SecsDeviceTelnetPacketSent);
                m_fSecsDriver.SecsDeviceTelnetStateChanged -= new FSecsDeviceTelnetStateChangedEventHandler(m_fSecsDriver_SecsDeviceTelnetStateChanged);
                m_fSecsDriver.SecsDeviceHandshakeReceived -= new FSecsDeviceHandshakeReceivedEventHandler(m_fSecsDriver_SecsDeviceHandshakeReceived);
                m_fSecsDriver.SecsDeviceHandshakeSent -= new FSecsDeviceHandshakeSentEventHandler(m_fSecsDriver_SecsDeviceHandshakeSent);
                m_fSecsDriver.SecsDeviceControlMessageReceived -= new FSecsDeviceControlMessageReceivedEventHandler(m_fSecsDriver_SecsDeviceControlMessageReceived);
                m_fSecsDriver.SecsDeviceControlMessageSent -= new FSecsDeviceControlMessageSentEventHandler(m_fSecsDriver_SecsDeviceControlMessageSent);
                m_fSecsDriver.SecsDeviceBlockReceived -= new FSecsDeviceBlockReceivedEventHandler(m_fSecsDriver_SecsDeviceBlockReceived);
                m_fSecsDriver.SecsDeviceBlockSent -= new FSecsDeviceBlockSentEventHandler(m_fSecsDriver_SecsDeviceBlockSent);
                m_fSecsDriver.SecsDeviceSmlReceived -= new FSecsDeviceSmlReceivedEventHandler(m_fSecsDriver_SecsDeviceSmlReceived);
                m_fSecsDriver.SecsDeviceSmlSent -= new FSecsDeviceSmlSentEventHandler(m_fSecsDriver_SecsDeviceSmlSent);
                m_fSecsDriver.SecsDeviceDataMessageReceived -= new FSecsDeviceDataMessageReceivedEventHandler(m_fSecsDriver_SecsDeviceDataMessageReceived);
                m_fSecsDriver.SecsDeviceDataMessageSent -= new FSecsDeviceDataMessageSentEventHandler(m_fSecsDriver_SecsDeviceDataMessageSent);
                // --
                m_fSecsDriver.HostDeviceStateChanged -= new FHostDeviceStateChangedEventHandler(m_fSecsDriver_HostDeviceStateChanged);
                m_fSecsDriver.HostDeviceErrorRaised -= new FHostDeviceErrorRaisedEventHandler(m_fSecsDriver_HostDeviceErrorRaised);
                m_fSecsDriver.HostDeviceVfeiReceived -= new FHostDeviceVfeiReceivedEventHandler(m_fSecsDriver_HostDeviceVfeiReceived);
                m_fSecsDriver.HostDeviceVfeiSent -= new FHostDeviceVfeiSentEventHandler(m_fSecsDriver_HostDeviceVfeiSent);
                m_fSecsDriver.HostDeviceDataMessageReceived -= new FHostDeviceDataMessageReceivedEventHandler(m_fSecsDriver_HostDeviceDataMessageReceived);
                m_fSecsDriver.HostDeviceDataMessageSent -= new FHostDeviceDataMessageSentEventHandler(m_fSecsDriver_HostDeviceDataMessageSent);
                // --
                m_fSecsDriver.SecsTriggerRaised -= new FSecsTriggerRaisedEventHandler(m_fSecsDriver_SecsTriggerRaised);
                m_fSecsDriver.SecsTransmitterRaised -= new FSecsTransmitterRaisedEventHandler(m_fSecsDriver_SecsTransmitterRaised);
                m_fSecsDriver.HostTriggerRaised -= new FHostTriggerRaisedEventHandler(m_fSecsDriver_HostTriggerRaised);
                m_fSecsDriver.HostTransmitterRaised -= new FHostTransmitterRaisedEventHandler(m_fSecsDriver_HostTransmitterRaised);
                m_fSecsDriver.JudgementPerformed -= new FJudgementPerformedEventHandler(m_fSecsDriver_JudgementPerformed);
                m_fSecsDriver.EquipmentStateSetAltererPerformed -= new FEquipmentStateSetAltererPerformedEventHandler(m_fSecsDriver_EquipmentStateSetAltererPerformed);
                m_fSecsDriver.MapperPerformed -= new FMapperPerformedEventHandler(m_fSecsDriver_MapperPerformed);
                m_fSecsDriver.StoragePerformed -= new FStoragePerformedEventHandler(m_fSecsDriver_StoragePerformed);
                m_fSecsDriver.CallbackRaised -= new FCallbackRaisedEventHandler(m_fSecsDriver_CallbackRaised);
                m_fSecsDriver.FunctionCalled -= new FFunctionCalledEventHandler(m_fSecsDriver_FunctionCalled);
                m_fSecsDriver.BranchRaised -= new FBranchRaisedEventHandler(m_fSecsDriver_BranchRaised);
                m_fSecsDriver.CommentWritten -= new FCommentWrittenEventHandler(m_fSecsDriver_CommentWritten);
                m_fSecsDriver.EntryPointCalled -= new FEntryPointCalledEventHandler(m_fSecsDriver_EntryPointCalled);
                m_fSecsDriver.PauserRaised -= new FPauserRaisedEventHandler(m_fSecsDriver_PauserRaised);
                m_fSecsDriver.ApplicationWritten -= new FApplicationWrittenEventHandler(m_fSecsDriver_ApplicationWritten);
                // --
                // ***
                // 2017.05.31 by spike.lee
                // Repository Material Saved 이벤트 추가
                // ***
                m_fSecsDriver.RepositoryMaterialSaved -= new FRepositoryMaterialSavedEventHandler(m_fSecsDriver_RepositoryMaterialSaved);
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
                m_fSecsDriver.waitEventHandlingCompleted();
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

        #region m_fSecsDriver Modeling Event Handler

        private void m_fSecsDriver_ModelingFileOpenCompleted(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_ModelingFileReopenPrecompleted(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_ModelingFileReopenCompleted(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_ModelingFileReopenFailed(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_ModelingFileSaveCompleted(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_ObjectInsertBeforeCompleted(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_ObjectInsertAfterCompleted(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_ObjectAppendCompleted(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_ObjectRemoveCompleted(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_ObjectModifyCompleted(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_ObjectMoveUpCompleted(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_ObjectMoveDownCompleted(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_ObjectMoveToCompleted(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_RepositoryMaterialSaved(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }  

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fSecsDriver Communication Event Handler

        private void m_fSecsDriver_SecsDeviceStateChanged(
            object sender, 
            FSecsDeviceStateChangedEventArgs e
            )
        {
            try
            {
                if (SecsDeviceStateChanged == null)
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
                    SecsDeviceStateChanged(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        SecsDeviceStateChanged(this, e);
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_SecsDeviceErrorRaised(
            object sender,
            FSecsDeviceErrorRaisedEventArgs e
            )
        {
            try
            {
                if (SecsDeviceErrorRaised == null)
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
                    SecsDeviceErrorRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        SecsDeviceErrorRaised(this, e);
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_SecsDeviceTimeoutRaised(
            object sender,
            FSecsDeviceTimeoutRaisedEventArgs e
            )
        {
            try
            {
                if (SecsDeviceTimeoutRaised == null)
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
                    SecsDeviceTimeoutRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        SecsDeviceTimeoutRaised(this, e);
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_SecsDeviceDataReceived(
            object sender,
            FSecsDeviceDataReceivedEventArgs e
            )
        {
            try
            {
                if (SecsDeviceDataReceived == null)
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
                    SecsDeviceDataReceived(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        SecsDeviceDataReceived(this, e);
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_SecsDeviceDataSent(
            object sender,
            FSecsDeviceDataSentEventArgs e
            )
        {
            try
            {
                if (SecsDeviceDataSent == null)
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
                    SecsDeviceDataSent(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        SecsDeviceDataSent(this, e);
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_SecsDeviceTelnetPacketReceived(
            object sender,
            FSecsDeviceTelnetPacketReceivedEventArgs e
            )
        {
            try
            {
                if (SecsDeviceTelnetPacketReceived == null)
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
                    SecsDeviceTelnetPacketReceived(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        SecsDeviceTelnetPacketReceived(this, e);
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_SecsDeviceTelnetPacketSent(
            object sender,
            FSecsDeviceTelnetPacketSentEventArgs e
            )
        {
            try
            {
                if (SecsDeviceTelnetPacketSent == null)
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
                    SecsDeviceTelnetPacketSent(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        SecsDeviceTelnetPacketSent(this, e);
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_SecsDeviceTelnetStateChanged(
            object sender,
            FSecsDeviceTelnetStateChangedEventArgs e
            )
        {
            try
            {
                if (SecsDeviceTelnetStateChanged == null)
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
                    SecsDeviceTelnetStateChanged(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        SecsDeviceTelnetStateChanged(this, e);
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_SecsDeviceHandshakeReceived(
            object sender,
            FSecsDeviceHandshakeReceivedEventArgs e
            )
        {
            try
            {
                if (SecsDeviceHandshakeReceived == null)
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
                    SecsDeviceHandshakeReceived(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        SecsDeviceHandshakeReceived(this, e);
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_SecsDeviceHandshakeSent(
            object sender,
            FSecsDeviceHandshakeSentEventArgs e
            )
        {
            try
            {
                if (SecsDeviceHandshakeSent == null)
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
                    SecsDeviceHandshakeSent(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        SecsDeviceHandshakeSent(this, e);
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_SecsDeviceControlMessageReceived(
            object sender,
            FSecsDeviceControlMessageReceivedEventArgs e
            )
        {
            try
            {
                if (SecsDeviceControlMessageReceived == null)
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
                    SecsDeviceControlMessageReceived(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        SecsDeviceControlMessageReceived(this, e);
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_SecsDeviceControlMessageSent(
            object sender,
            FSecsDeviceControlMessageSentEventArgs e
            )
        {
            try
            {
                if (SecsDeviceControlMessageSent == null)
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
                    SecsDeviceControlMessageSent(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        SecsDeviceControlMessageSent(this, e);
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_SecsDeviceBlockReceived(
            object sender,
            FSecsDeviceBlockReceivedEventArgs e
            )
        {
            try
            {
                if (SecsDeviceBlockReceived == null)
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
                    SecsDeviceBlockReceived(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        SecsDeviceBlockReceived(this, e);
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_SecsDeviceBlockSent(
            object sender,
            FSecsDeviceBlockSentEventArgs e
            )
        {
            try
            {
                if (SecsDeviceBlockSent == null)
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
                    SecsDeviceBlockSent(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        SecsDeviceBlockSent(this, e);
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_SecsDeviceSmlReceived(
            object sender,
            FSecsDeviceSmlReceivedEventArgs e
            )
        {
            try
            {
                if (SecsDeviceSmlReceived == null)
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
                    SecsDeviceSmlReceived(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        SecsDeviceSmlReceived(this, e);
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_SecsDeviceSmlSent(
            object sender,
            FSecsDeviceSmlSentEventArgs e
            )
        {
            try
            {
                if (SecsDeviceSmlSent == null)
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
                    SecsDeviceSmlSent(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        SecsDeviceSmlSent(this, e);
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }     

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_SecsDeviceDataMessageReceived(
            object sender, 
            FSecsDeviceDataMessageReceivedEventArgs e
            )
        {
            try
            {
                if (SecsDeviceDataMessageReceived == null)
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
                    SecsDeviceDataMessageReceived(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        SecsDeviceDataMessageReceived(this, e);
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_SecsDeviceDataMessageSent(
            object sender, 
            FSecsDeviceDataMessageSentEventArgs e
            )
        {
            try
            {
                if (SecsDeviceDataMessageSent == null)
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
                    SecsDeviceDataMessageSent(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        SecsDeviceDataMessageSent(this, e);
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_HostDeviceStateChanged(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_HostDeviceErrorRaised(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_HostDeviceVfeiReceived(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_HostDeviceVfeiSent(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }  

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_HostDeviceDataMessageReceived(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_HostDeviceDataMessageSent(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_SecsTriggerRaised(
            object sender, 
            FSecsTriggerRaisedEventArgs e
            )
        {
            try
            {
                if (SecsTriggerRaised == null)
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
                    SecsTriggerRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        SecsTriggerRaised(this, e);
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_SecsTransmitterRaised(
            object sender, 
            FSecsTransmitterRaisedEventArgs e
            )
        {
            try
            {
                if (SecsTransmitterRaised == null)
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
                    SecsTransmitterRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        SecsTransmitterRaised(this, e);
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_HostTriggerRaised(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_HostTransmitterRaised(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_JudgementPerformed(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_MapperPerformed(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_EquipmentStateSetAltererPerformed(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_StoragePerformed(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_CallbackRaised(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_FunctionCalled(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_BranchRaised(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_CommentWritten(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_EntryPointCalled(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_PauserRaised(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSecsDriver_ApplicationWritten(
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
                FMessageBox.showError("FSecsEventHandler", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namepsace end
