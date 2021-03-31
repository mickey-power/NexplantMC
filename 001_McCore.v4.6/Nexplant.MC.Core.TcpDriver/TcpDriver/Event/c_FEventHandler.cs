/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FEventHandler.cs
--  Creator         : spike.lee
--  Create Date     : 2013.07.10
--  Description     : FAMate Core FaTcpDriver Event Handler Class 
--  History         : Created by spike.lee at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
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
        public event FTcpDeviceStateChangedEventHandler TcpDeviceStateChanged = null;
        public event FTcpDeviceDataReceivedEventHandler TcpDeviceDataReceived = null;
        public event FTcpDeviceDataSentEventHandler TcpDeviceDataSent = null;
        public event FTcpDeviceXmlReceivedEventHandler TcpDeviceXmlReceived = null;
        public event FTcpDeviceXmlSentEventHandler TcpDeviceXmlSent = null;
        public event FTcpDeviceErrorRaisedEventHandler TcpDeviceErrorRaised = null;
        public event FTcpDeviceTimeoutRaisedEventHandler TcpDeviceTimeoutRaised = null;        
        public event FTcpDeviceDataMessageReceivedEventHandler TcpDeviceDataMessageReceived = null;
        public event FTcpDeviceDataMessageSentEventHandler TcpDeviceDataMessageSent = null;        
        // --
        public event FHostDeviceStateChangedEventHandler HostDeviceStateChanged = null;
        public event FHostDeviceErrorRaisedEventHandler HostDeviceErrorRaised = null;
        public event FHostDeviceVfeiReceivedEventHandler HostDeviceVfeiReceived = null;
        public event FHostDeviceVfeiSentEventHandler HostDeviceVfeiSent = null;
        public event FHostDeviceDataMessageReceivedEventHandler HostDeviceDataMessageReceived = null;
        public event FHostDeviceDataMessageSentEventHandler HostDeviceDataMessageSent = null;
        //--
        public event FTcpTriggerRaisedEventHandler TcpTriggerRaised = null;
        public event FTcpTransmitterRaisedEventHandler TcpTransmitterRaised = null;
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
        private FTcpDriver m_fTcpDriver = null;
        private Control m_invoker = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEventHandler(
            FTcpDriver fTcpDriver,
            Control invoker
            )
        {
            m_fTcpDriver = fTcpDriver;
            m_invoker = invoker;                     

            // --

            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEventHandler(
            FTcpDriver fTcpDriver
            )
            : this(fTcpDriver, null)
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

                    m_fTcpDriver = null;
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

        public FTcpDriver fTcpDriver
        {
            get
            {
                try
                {
                    return m_fTcpDriver;
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
                    return m_fTcpDriver.eventCount;
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
                    return m_fTcpDriver.isCompletedEventHandling;
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
                m_fTcpDriver.ModelingFileOpenCompleted += new FModelingFileOpenCompletedEventHandler(m_fTcpDriver_ModelingFileOpenCompleted);
                m_fTcpDriver.ModelingFileReopenPrecompleted += new FModelingFileReopenPrecompletedEventHandler(m_fTcpDriver_ModelingFileReopenPrecompleted);
                m_fTcpDriver.ModelingFileReopenCompleted += new FModelingFileReopenCompletedEventHandler(m_fTcpDriver_ModelingFileReopenCompleted);
                m_fTcpDriver.ModelingFileReopenFailed += new FModelingFileReopenFailedEventHandler(m_fTcpDriver_ModelingFileReopenFailed);
                m_fTcpDriver.ModelingFileSaveCompleted += new FModelingFileSaveCompletedEventHandler(m_fTcpDriver_ModelingFileSaveCompleted);
                // --               
                m_fTcpDriver.ObjectModifyCompleted += new FObjectModifyCompletedEventHandler(m_fTcpDriver_ObjectModifyCompleted);                
                m_fTcpDriver.ObjectInsertBeforeCompleted += new FObjectInsertBeforeCompletedEventHandler(m_fTcpDriver_ObjectInsertBeforeCompleted);
                m_fTcpDriver.ObjectInsertAfterCompleted += new FObjectInsertAfterCompletedEventHandler(m_fTcpDriver_ObjectInsertAfterCompleted);
                m_fTcpDriver.ObjectAppendCompleted += new FObjectAppendCompletedEventHandler(m_fTcpDriver_ObjectAppendCompleted);
                m_fTcpDriver.ObjectRemoveCompleted += new FObjectRemoveCompletedEventHandler(m_fTcpDriver_ObjectRemoveCompleted);
                m_fTcpDriver.ObjectMoveUpCompleted += new FObjectMoveUpCompletedEventHandler(m_fTcpDriver_ObjectMoveUpCompleted);
                m_fTcpDriver.ObjectMoveDownCompleted += new FObjectMoveDownCompletedEventHandler(m_fTcpDriver_ObjectMoveDownCompleted);
                m_fTcpDriver.ObjectMoveToCompleted += new FObjectMoveToCompletedEventHandler(m_fTcpDriver_ObjectMoveToCompleted);
                // --
                m_fTcpDriver.TcpDeviceStateChanged += new FTcpDeviceStateChangedEventHandler(m_fTcpDriver_TcpDeviceStateChanged);
                m_fTcpDriver.TcpDeviceDataReceived += new FTcpDeviceDataReceivedEventHandler(m_fTcpDriver_TcpDeviceDataReceived);
                m_fTcpDriver.TcpDeviceDataSent += new FTcpDeviceDataSentEventHandler(m_fTcpDriver_TcpDeviceDataSent);
                m_fTcpDriver.TcpDeviceXmlReceived += new FTcpDeviceXmlReceivedEventHandler(m_fTcpDriver_TcpDeviceXmlReceived);
                m_fTcpDriver.TcpDeviceXmlSent += new FTcpDeviceXmlSentEventHandler(m_fTcpDriver_TcpDeviceXmlSent);
                m_fTcpDriver.TcpDeviceErrorRaised += new FTcpDeviceErrorRaisedEventHandler(m_fTcpDriver_TcpDeviceErrorRaised);
                m_fTcpDriver.TcpDeviceTimeoutRaised += new FTcpDeviceTimeoutRaisedEventHandler(m_fTcpDriver_TcpDeviceTimeoutRaised);                
                m_fTcpDriver.TcpDeviceDataMessageReceived += new FTcpDeviceDataMessageReceivedEventHandler(m_fTcpDriver_TcpDeviceDataMessageReceived);
                m_fTcpDriver.TcpDeviceDataMessageSent += new FTcpDeviceDataMessageSentEventHandler(m_fTcpDriver_TcpDeviceDataMessageSent);               
                // -- 
                m_fTcpDriver.HostDeviceStateChanged += new FHostDeviceStateChangedEventHandler(m_fTcpDriver_HostDeviceStateChanged);
                m_fTcpDriver.HostDeviceErrorRaised += new FHostDeviceErrorRaisedEventHandler(m_fTcpDriver_HostDeviceErrorRaised);
                m_fTcpDriver.HostDeviceVfeiReceived += new FHostDeviceVfeiReceivedEventHandler(m_fTcpDriver_HostDeviceVfeiReceived);
                m_fTcpDriver.HostDeviceVfeiSent += new FHostDeviceVfeiSentEventHandler(m_fTcpDriver_HostDeviceVfeiSent);
                m_fTcpDriver.HostDeviceDataMessageReceived += new FHostDeviceDataMessageReceivedEventHandler(m_fTcpDriver_HostDeviceDataMessageReceived);
                m_fTcpDriver.HostDeviceDataMessageSent += new FHostDeviceDataMessageSentEventHandler(m_fTcpDriver_HostDeviceDataMessageSent);
                // --
                m_fTcpDriver.TcpTriggerRaised += new FTcpTriggerRaisedEventHandler(m_fTcpDriver_TcpTriggerRaised);
                m_fTcpDriver.TcpTransmitterRaised += new FTcpTransmitterRaisedEventHandler(m_fTcpDriver_TcpTransmitterRaised);
                m_fTcpDriver.HostTriggerRaised += new FHostTriggerRaisedEventHandler(m_fTcpDriver_HostTriggerRaised);
                m_fTcpDriver.HostTransmitterRaised += new FHostTransmitterRaisedEventHandler(m_fTcpDriver_HostTransmitterRaised);
                m_fTcpDriver.JudgementPerformed += new FJudgementPerformedEventHandler(m_fTcpDriver_JudgementPerformed);
                m_fTcpDriver.EquipmentStateSetAltererPerformed += new FEquipmentStateSetAltererPerformedEventHandler(m_fTcpDriver_EquipmentStateSetAltererPerformed);
                m_fTcpDriver.MapperPerformed += new FMapperPerformedEventHandler(m_fTcpDriver_MapperPerformed);
                m_fTcpDriver.StoragePerformed += new FStoragePerformedEventHandler(m_fTcpDriver_StoragePerformed);
                m_fTcpDriver.CallbackRaised += new FCallbackRaisedEventHandler(m_fTcpDriver_CallbackRaised);
                m_fTcpDriver.FunctionCalled += new FFunctionCalledEventHandler(m_fTcpDriver_FunctionCalled);
                m_fTcpDriver.BranchRaised += new FBranchRaisedEventHandler(m_fTcpDriver_BranchRaised);
                m_fTcpDriver.CommentWritten += new FCommentWrittenEventHandler(m_fTcpDriver_CommentWritten);
                m_fTcpDriver.EntryPointCalled += new FEntryPointCalledEventHandler(m_fTcpDriver_EntryPointCalled);
                m_fTcpDriver.PauserRaised += new FPauserRaisedEventHandler(m_fTcpDriver_PauserRaised);
                m_fTcpDriver.ApplicationWritten += new FApplicationWrittenEventHandler(m_fTcpDriver_ApplicationWritten);
                // --
                // ***
                // 2017.05.31 by spike.lee
                // Repository Material Saved 이벤트 추가
                // ***
                m_fTcpDriver.RepositoryMaterialSaved += new FRepositoryMaterialSavedEventHandler(m_fTcpDriver_RepositoryMaterialSaved);
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
                m_fTcpDriver.ModelingFileOpenCompleted -= new FModelingFileOpenCompletedEventHandler(m_fTcpDriver_ModelingFileOpenCompleted);
                m_fTcpDriver.ModelingFileReopenPrecompleted -= new FModelingFileReopenPrecompletedEventHandler(m_fTcpDriver_ModelingFileReopenPrecompleted);
                m_fTcpDriver.ModelingFileReopenCompleted -= new FModelingFileReopenCompletedEventHandler(m_fTcpDriver_ModelingFileReopenCompleted);
                m_fTcpDriver.ModelingFileReopenFailed -= new FModelingFileReopenFailedEventHandler(m_fTcpDriver_ModelingFileReopenFailed);
                m_fTcpDriver.ModelingFileSaveCompleted -= new FModelingFileSaveCompletedEventHandler(m_fTcpDriver_ModelingFileSaveCompleted);
                //--
                m_fTcpDriver.ObjectModifyCompleted -= new FObjectModifyCompletedEventHandler(m_fTcpDriver_ObjectModifyCompleted);
                m_fTcpDriver.ObjectInsertBeforeCompleted -= new FObjectInsertBeforeCompletedEventHandler(m_fTcpDriver_ObjectInsertBeforeCompleted);
                m_fTcpDriver.ObjectInsertAfterCompleted -= new FObjectInsertAfterCompletedEventHandler(m_fTcpDriver_ObjectInsertAfterCompleted);
                m_fTcpDriver.ObjectAppendCompleted -= new FObjectAppendCompletedEventHandler(m_fTcpDriver_ObjectAppendCompleted);
                m_fTcpDriver.ObjectRemoveCompleted -= new FObjectRemoveCompletedEventHandler(m_fTcpDriver_ObjectRemoveCompleted);
                m_fTcpDriver.ObjectMoveUpCompleted -= new FObjectMoveUpCompletedEventHandler(m_fTcpDriver_ObjectMoveUpCompleted);
                m_fTcpDriver.ObjectMoveDownCompleted -= new FObjectMoveDownCompletedEventHandler(m_fTcpDriver_ObjectMoveDownCompleted);
                m_fTcpDriver.ObjectMoveToCompleted -= new FObjectMoveToCompletedEventHandler(m_fTcpDriver_ObjectMoveToCompleted);
                // --
                m_fTcpDriver.TcpDeviceStateChanged -= new FTcpDeviceStateChangedEventHandler(m_fTcpDriver_TcpDeviceStateChanged);
                m_fTcpDriver.TcpDeviceDataReceived -= new FTcpDeviceDataReceivedEventHandler(m_fTcpDriver_TcpDeviceDataReceived);
                m_fTcpDriver.TcpDeviceDataSent -= new FTcpDeviceDataSentEventHandler(m_fTcpDriver_TcpDeviceDataSent);
                m_fTcpDriver.TcpDeviceXmlReceived -= new FTcpDeviceXmlReceivedEventHandler(m_fTcpDriver_TcpDeviceXmlReceived);
                m_fTcpDriver.TcpDeviceXmlSent -= new FTcpDeviceXmlSentEventHandler(m_fTcpDriver_TcpDeviceXmlSent);
                m_fTcpDriver.TcpDeviceErrorRaised -= new FTcpDeviceErrorRaisedEventHandler(m_fTcpDriver_TcpDeviceErrorRaised);
                m_fTcpDriver.TcpDeviceTimeoutRaised -= new FTcpDeviceTimeoutRaisedEventHandler(m_fTcpDriver_TcpDeviceTimeoutRaised);
                m_fTcpDriver.TcpDeviceDataMessageReceived -= new FTcpDeviceDataMessageReceivedEventHandler(m_fTcpDriver_TcpDeviceDataMessageReceived);
                m_fTcpDriver.TcpDeviceDataMessageSent -= new FTcpDeviceDataMessageSentEventHandler(m_fTcpDriver_TcpDeviceDataMessageSent);               
                // --
                m_fTcpDriver.HostDeviceStateChanged -= new FHostDeviceStateChangedEventHandler(m_fTcpDriver_HostDeviceStateChanged);
                m_fTcpDriver.HostDeviceErrorRaised -= new FHostDeviceErrorRaisedEventHandler(m_fTcpDriver_HostDeviceErrorRaised);
                m_fTcpDriver.HostDeviceVfeiReceived -= new FHostDeviceVfeiReceivedEventHandler(m_fTcpDriver_HostDeviceVfeiReceived);
                m_fTcpDriver.HostDeviceVfeiSent -= new FHostDeviceVfeiSentEventHandler(m_fTcpDriver_HostDeviceVfeiSent);
                m_fTcpDriver.HostDeviceDataMessageReceived -= new FHostDeviceDataMessageReceivedEventHandler(m_fTcpDriver_HostDeviceDataMessageReceived);
                m_fTcpDriver.HostDeviceDataMessageSent -= new FHostDeviceDataMessageSentEventHandler(m_fTcpDriver_HostDeviceDataMessageSent);
                // --
                m_fTcpDriver.TcpTriggerRaised -= new FTcpTriggerRaisedEventHandler(m_fTcpDriver_TcpTriggerRaised);
                m_fTcpDriver.TcpTransmitterRaised -= new FTcpTransmitterRaisedEventHandler(m_fTcpDriver_TcpTransmitterRaised);
                m_fTcpDriver.HostTriggerRaised -= new FHostTriggerRaisedEventHandler(m_fTcpDriver_HostTriggerRaised);
                m_fTcpDriver.HostTransmitterRaised -= new FHostTransmitterRaisedEventHandler(m_fTcpDriver_HostTransmitterRaised);
                m_fTcpDriver.CallbackRaised -= new FCallbackRaisedEventHandler(m_fTcpDriver_CallbackRaised);
                m_fTcpDriver.JudgementPerformed -= new FJudgementPerformedEventHandler(m_fTcpDriver_JudgementPerformed);
                m_fTcpDriver.EquipmentStateSetAltererPerformed -= new FEquipmentStateSetAltererPerformedEventHandler(m_fTcpDriver_EquipmentStateSetAltererPerformed);
                m_fTcpDriver.MapperPerformed -= new FMapperPerformedEventHandler(m_fTcpDriver_MapperPerformed);
                m_fTcpDriver.StoragePerformed -= new FStoragePerformedEventHandler(m_fTcpDriver_StoragePerformed);
                m_fTcpDriver.FunctionCalled -= new FFunctionCalledEventHandler(m_fTcpDriver_FunctionCalled);
                m_fTcpDriver.BranchRaised -= new FBranchRaisedEventHandler(m_fTcpDriver_BranchRaised);
                m_fTcpDriver.CommentWritten -= new FCommentWrittenEventHandler(m_fTcpDriver_CommentWritten);
                m_fTcpDriver.EntryPointCalled -= new FEntryPointCalledEventHandler(m_fTcpDriver_EntryPointCalled);
                m_fTcpDriver.PauserRaised += new FPauserRaisedEventHandler(m_fTcpDriver_PauserRaised);
                m_fTcpDriver.ApplicationWritten -= new FApplicationWrittenEventHandler(m_fTcpDriver_ApplicationWritten);
                // --
                // ***
                // 2017.05.31 by spike.lee
                // Repository Material Saved 이벤트 추가
                // ***
                m_fTcpDriver.RepositoryMaterialSaved -= new FRepositoryMaterialSavedEventHandler(m_fTcpDriver_RepositoryMaterialSaved);
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
                m_fTcpDriver.waitEventHandlingCompleted();
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

        #region m_fTcpDriver Modeling Event Handler

        private void m_fTcpDriver_ModelingFileOpenCompleted(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_ModelingFileReopenPrecompleted(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_ModelingFileReopenCompleted(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_ModelingFileReopenFailed(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_ModelingFileSaveCompleted(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_ObjectInsertBeforeCompleted(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_ObjectInsertAfterCompleted(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_ObjectAppendCompleted(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_ObjectRemoveCompleted(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }
         
        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_ObjectModifyCompleted(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_ObjectMoveUpCompleted(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_ObjectMoveDownCompleted(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_ObjectMoveToCompleted(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_RepositoryMaterialSaved(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }  

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fTcpDriver Communication Event Handler

        private void m_fTcpDriver_TcpDeviceStateChanged(
            object sender,
            FTcpDeviceStateChangedEventArgs e
            )
        {
            try
            {
                if (TcpDeviceStateChanged == null)
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
                    TcpDeviceStateChanged(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        TcpDeviceStateChanged(this, e);
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_TcpDeviceDataSent(
            object sender, 
            FTcpDeviceDataSentEventArgs e
            )
        {
            try
            {
                if (TcpDeviceDataSent == null)
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
                    TcpDeviceDataSent(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        TcpDeviceDataSent(this, e);
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_TcpDeviceDataReceived(
            object sender, 
            FTcpDeviceDataReceivedEventArgs e
            )
        {
            try
            {
                if (TcpDeviceDataReceived == null)
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
                    TcpDeviceDataReceived(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        TcpDeviceDataReceived(this, e);
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_TcpDeviceXmlReceived(
            object sender,
            FTcpDeviceXmlReceivedEventArgs e
            )
        {
            try
            {
                if (TcpDeviceXmlReceived == null)
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
                    TcpDeviceXmlReceived(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        TcpDeviceXmlReceived(this, e);
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_TcpDeviceXmlSent(
            object sender,
            FTcpDeviceXmlSentEventArgs e
            )
        {
            try
            {
                if (TcpDeviceXmlSent == null)
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
                    TcpDeviceXmlSent(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        TcpDeviceXmlSent(this, e);
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_TcpDeviceErrorRaised(
            object sender,
            FTcpDeviceErrorRaisedEventArgs e
            )
        {
            try
            {
                if (TcpDeviceErrorRaised == null)
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
                    TcpDeviceErrorRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        TcpDeviceErrorRaised(this, e);
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void m_fTcpDriver_TcpDeviceDataMessageReceived(
            object sender,
            FTcpDeviceDataMessageReceivedEventArgs e
            )
        {
            try
            {
                if (TcpDeviceDataMessageReceived == null)
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
                    TcpDeviceDataMessageReceived(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        TcpDeviceDataMessageReceived(this, e);
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_TcpDeviceDataMessageSent(
            object sender, 
            FTcpDeviceDataMessageSentEventArgs e
            )
        {
            try
            {
                if (TcpDeviceDataMessageSent == null)
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
                    TcpDeviceDataMessageSent(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        TcpDeviceDataMessageSent(this, e);
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_TcpDeviceTimeoutRaised(
            object sender,
            FTcpDeviceTimeoutRaisedEventArgs e
            )
        {
            try
            {
                if (TcpDeviceTimeoutRaised == null)
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
                    TcpDeviceTimeoutRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        TcpDeviceTimeoutRaised(this, e);
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_HostDeviceStateChanged(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_HostDeviceErrorRaised(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_HostDeviceVfeiReceived(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_HostDeviceVfeiSent(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_HostDeviceDataMessageReceived(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_HostDeviceDataMessageSent(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_TcpTriggerRaised(
            object sender, 
            FTcpTriggerRaisedEventArgs e
            )
        {
            try
            {
                if (TcpTriggerRaised == null)
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
                    TcpTriggerRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        TcpTriggerRaised(this, e);
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_TcpTransmitterRaised(
            object sender, 
            FTcpTransmitterRaisedEventArgs e
            )
        {
            try
            {
                if (TcpTransmitterRaised == null)
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
                    TcpTransmitterRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        TcpTransmitterRaised(this, e);
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_HostTriggerRaised(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_HostTransmitterRaised(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_JudgementPerformed(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_EquipmentStateSetAltererPerformed(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_MapperPerformed(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_StoragePerformed(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_CallbackRaised(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_FunctionCalled(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_BranchRaised(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_CommentWritten(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_EntryPointCalled(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_PauserRaised(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpDriver_ApplicationWritten(
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
                FMessageBox.showError("FTcpEventHandler", ex, null);
            }
            finally
            {

            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namepsace end
