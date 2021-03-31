/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSsmFileInfo.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.27
--  Description     : FAMate SECS Modeling File Information Class 
--  History         : Created by spike.lee at 2011.01.27
                    : Modified by spike.lee at 2012.11.19
                        - initSecsDriver 전면 수정 
                          newFile, openFile, cloneFile Method에서 동일하게 사용할 수 있도록 수정
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaSecsDriver;

namespace Nexplant.MC.SecsModeler
{
    public class FSsmFileInfo : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FModelingFileModifiedEventHandler ModelingFileModlfied = null;

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private static FIDPointer32 m_fFileIdPointer = new FIDPointer32();
        // --
        private bool m_isClosedFile = true;
        private bool m_isNewFile = false;
        private bool m_isModifiedFile = false;
        // --
        private string m_fileFullName = string.Empty;
        private string m_fileName = string.Empty;
        // --
        private FSecsDriver m_fSecsDriver = null;
        private FEventHandler m_fEventHandler = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSsmFileInfo(
            FSsmCore fSsmCore            
            )
        {
            m_fSsmCore = fSsmCore;            
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Library Clone 전용
        // ***
        public FSsmFileInfo(
            FSsmCore fSsmCore,
            FSecsDriver fSecsDriver
            )
        {
            m_fSsmCore = fSsmCore;
            // --
            cloneFile(fSecsDriver);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSsmFileInfo(
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
                    m_fSsmCore = null;                    
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

        public string fileFullName
        {
            get
            {
                try
                {
                    return m_fileFullName;
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

        //------------------------------------------------------------------------------------------------------------------------

        public string fileName
        {
            get
            {
                try
                {
                    return m_fileName;
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool isClosedFile
        {
            get
            {
                try
                {
                    return m_isClosedFile;
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

        public bool isNewFile
        {
            get
            {
                try
                {
                    return m_isNewFile;
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

        public bool isModifiedFile
        {
            get
            {
                try
                {
                    return m_isModifiedFile;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {

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
                termSecsDriver();
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

        private void initSecsDriver(
            )
        {
            try
            {
                // ***
                // SECS Driver가 New File로 생성될 경우 Default Modeling File를 만들어 준다.
                // ***
                m_fSecsDriver.hostDriverDirectory = m_fSsmCore.fWsmCore.usrPath + "\\HostDriver";
                if (!Directory.Exists(m_fSecsDriver.hostDriverDirectory))
                {
                    Directory.CreateDirectory(m_fSecsDriver.hostDriverDirectory);
                }
                // --
                m_fSecsDriver.logDirectory = m_fSsmCore.fWsmCore.usrPath + "\\Log";
                if (!Directory.Exists(m_fSecsDriver.logDirectory))
                {
                    Directory.CreateDirectory(m_fSecsDriver.logDirectory);
                }

                // --

                // ***
                // 2012.11.19 by spike.lee
                // SECS Driver Configuration Set
                // ***
                setSecsDriverConfig();

                // --

                // ***
                // SECS Event Handler Create
                // ***
                m_fEventHandler = new FEventHandler(m_fSecsDriver, m_fSsmCore.fSsmContainer);
                // --
                m_fEventHandler.ModelingFileOpenCompleted += new FModelingFileOpenCompletedEventHandler(m_fEventHandler_ModelingFileOpenCompleted);
                m_fEventHandler.ModelingFileSaveCompleted += new FModelingFileSaveCompletedEventHandler(m_fEventHandler_ModelingFileSaveCompleted);
                // --
                m_fEventHandler.ObjectInsertBeforeCompleted += new FObjectInsertBeforeCompletedEventHandler(m_fEventHandler_ObjectInsertBeforeCompleted);
                m_fEventHandler.ObjectInsertAfterCompleted += new FObjectInsertAfterCompletedEventHandler(m_fEventHandler_ObjectInsertAfterCompleted);
                m_fEventHandler.ObjectAppendCompleted += new FObjectAppendCompletedEventHandler(m_fEventHandler_ObjectAppendCompleted);
                m_fEventHandler.ObjectRemoveCompleted += new FObjectRemoveCompletedEventHandler(m_fEventHandler_ObjectRemoveCompleted);
                m_fEventHandler.ObjectMoveUpCompleted += new FObjectMoveUpCompletedEventHandler(m_fEventHandler_ObjectMoveUpCompleted);
                m_fEventHandler.ObjectMoveDownCompleted += new FObjectMoveDownCompletedEventHandler(m_fEventHandler_ObjectMoveDownCompleted);
                m_fEventHandler.ObjectMoveToCompleted += new FObjectMoveToCompletedEventHandler(m_fEventHandler_ObjectMoveToCompleted);
                m_fEventHandler.ObjectModifyCompleted += new FObjectModifyCompletedEventHandler(m_fEventHandler_ObjectModifyCompleted);                
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

        private void termSecsDriver(
            )
        {
            try
            {
                if (m_fEventHandler != null)
                {
                    m_fEventHandler.waitEventHandlingCompleted();

                    // --

                    m_fEventHandler.Dispose();
                    // --
                    m_fEventHandler.ModelingFileOpenCompleted -= new FModelingFileOpenCompletedEventHandler(m_fEventHandler_ModelingFileOpenCompleted);
                    m_fEventHandler.ModelingFileSaveCompleted -= new FModelingFileSaveCompletedEventHandler(m_fEventHandler_ModelingFileSaveCompleted);
                    // --
                    m_fEventHandler.ObjectInsertBeforeCompleted -= new FObjectInsertBeforeCompletedEventHandler(m_fEventHandler_ObjectInsertBeforeCompleted);
                    m_fEventHandler.ObjectInsertAfterCompleted -= new FObjectInsertAfterCompletedEventHandler(m_fEventHandler_ObjectInsertAfterCompleted);
                    m_fEventHandler.ObjectAppendCompleted -= new FObjectAppendCompletedEventHandler(m_fEventHandler_ObjectAppendCompleted);
                    m_fEventHandler.ObjectRemoveCompleted -= new FObjectRemoveCompletedEventHandler(m_fEventHandler_ObjectRemoveCompleted);
                    m_fEventHandler.ObjectMoveUpCompleted -= new FObjectMoveUpCompletedEventHandler(m_fEventHandler_ObjectMoveUpCompleted);
                    m_fEventHandler.ObjectMoveDownCompleted -= new FObjectMoveDownCompletedEventHandler(m_fEventHandler_ObjectMoveDownCompleted);
                    m_fEventHandler.ObjectMoveToCompleted -= new FObjectMoveToCompletedEventHandler(m_fEventHandler_ObjectMoveToCompleted);
                    m_fEventHandler.ObjectModifyCompleted -= new FObjectModifyCompletedEventHandler(m_fEventHandler_ObjectModifyCompleted);                    
                    // --
                    m_fEventHandler = null;
                }

                // --

                if (m_fSecsDriver != null)
                {
                    m_fSecsDriver.Dispose();
                    m_fSecsDriver = null;
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

        private string createDefaultFileName(
            )
        {
            const string DefaultFileName = "NexplantMcSecsModelingFile{0}.ssm";

            try
            {
                return string.Format(DefaultFileName, FSsmFileInfo.m_fFileIdPointer.uniqueId.ToString());
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

        public void newFile(
            )
        {
            FSecsLibraryGroup fSlg = null;
            FSecsLibrary fSlb = null;
            FSecsDevice fSdv = null;
            FSecsSession fSsn = null;
            FHostLibraryGroup fHlg = null;
            FHostLibrary fHlb = null;
            FHostDevice fHdv = null;
            FHostSession fHsn = null;

            try
            {
                termSecsDriver();

                // --

                m_fSecsDriver = new FSecsDriver(m_fSsmCore.fWsmCore.licenseFileName);
                
                // --
                
                m_fSecsDriver.appendChildFuntionNameList(new FFunctionNameList(m_fSecsDriver));
                m_fSecsDriver.appendChildDataConversionSetList(new FDataConversionSetList(m_fSecsDriver));
                m_fSecsDriver.appendChildEquipmentStateSetList(new FEquipmentStateSetList(m_fSecsDriver));
                m_fSecsDriver.appendChildRepositoryList(new FRepositoryList(m_fSecsDriver));
                m_fSecsDriver.appendChildEnvironmentList(new FEnvironmentList(m_fSecsDriver));
                m_fSecsDriver.appendChildDataSetList(new FDataSetList(m_fSecsDriver));
                // --
                fSlg = m_fSecsDriver.appendChildSecsLibraryGroup(new FSecsLibraryGroup(m_fSecsDriver));
                fSlb = fSlg.appendChildSecsLibrary(new FSecsLibrary(m_fSecsDriver));
                fSlb.appendChildSecsMessageList(new FSecsMessageList(m_fSecsDriver));
                // --
                fSdv = m_fSecsDriver.appendChildSecsDevice(new FSecsDevice(m_fSecsDriver));
                fSsn = fSdv.appendChildSecsSession(new FSecsSession(m_fSecsDriver));
                fSsn.setLibrary(fSlb);
                // --
                fHlg = m_fSecsDriver.appendChildHostLibraryGroup(new FHostLibraryGroup(m_fSecsDriver));
                fHlb = fHlg.appendChildHostLibrary(new FHostLibrary(m_fSecsDriver));
                fHlb.appendChildHostMessageList(new FHostMessageList(m_fSecsDriver));
                // --
                fHdv = m_fSecsDriver.appendChildHostDevice(new FHostDevice(m_fSecsDriver));
                fHsn = fHdv.appendChildHostSession(new FHostSession(m_fSecsDriver));
                fHsn.setLibrary(fHlb);
                // --
                m_fSecsDriver.appendChildEquipment(new FEquipment(m_fSecsDriver));
                // --
                // ***
                // 위에 Default SECS Moddeling File를 생성하는 동안 발생한 Event가 모두 제거될 때까지 대기한다.
                // ***
                m_fSecsDriver.waitEventHandlingCompleted();                    
                
                // --
                
                initSecsDriver();

                // --

                m_fileFullName = createDefaultFileName();
                m_fileName = m_fileFullName;
                m_isClosedFile = false;
                m_isNewFile = true;
                m_isModifiedFile = false;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSlg = null;
                fSlb = null;
                fSdv = null;
                fSsn = null;
                fHlg = null;
                fHlb = null;
                fHdv = null;
                fHsn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void openFile(
            string fileName
            )
        {
            try
            {
                termSecsDriver();

                // --

                m_fSecsDriver = new FSecsDriver(m_fSsmCore.fWsmCore.licenseFileName);
                m_fSecsDriver.openModelingFile(fileName);
                // --
                initSecsDriver();                

                // --

                m_fileFullName = fileName;
                m_fileName = Path.GetFileName(fileName);
                m_isClosedFile = false;
                m_isNewFile = false;
                m_isModifiedFile = false;                
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
        
        // ***
        // 2012.11.19 by spike.lee
        // 이 Method는 생성자에서만 호출되는 Method입니다. 왜 public으로 선언되어 있습니까?
        // 좀 더 세밀하게 생각하면서 하세요.
        // ***
        private void cloneFile(
            FSecsDriver fSecsDriver
            )
        {
            try
            {
                termSecsDriver();

                // --

                m_fSecsDriver = fSecsDriver;
                // --
                initSecsDriver();                
                
                // --

                // ***
                // 2012.11.19 by spike.lee
                // Clone Library는 기존 Library를 복제하여 New File로 생성하는 겁니다.
                // 구현 시, 정확이 이해하고해야 합니다.
                // 이 부분 때문에 Clone Library로 생성된 Library 파일 Save시 빈문자열이 사용되었다는 오류가 발생했습니다.
                // 이런글 일고도 똑같이 일한다면 당신은 개발자 길을 포기해야 합니다. 다른일 찾아 보세요.
                // ***
                m_fileFullName = createDefaultFileName();
                m_fileName = m_fileFullName;
                m_isClosedFile = false;
                m_isNewFile = true;
                m_isModifiedFile = false;
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

        public void saveFile(
            string fileName
            )
        {
            string dir = string.Empty;

            try
            {
                dir = Path.GetDirectoryName(fileName);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                // --

                m_fSecsDriver.saveModelingFile(fileName);

                // --

                m_fileFullName = fileName;
                m_fileName = Path.GetFileName(fileName);
                m_isNewFile = false;
                m_isModifiedFile = false;
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

        public void closeFile(
            )
        {
            try
            {
                termSecsDriver();

                // --

                m_fileFullName = string.Empty;
                m_fileName = string.Empty;
                m_isClosedFile = true;
                m_isNewFile = false;
                m_isModifiedFile = false;                
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

        public void onModelingFileModified(
            )
        {
            try
            {
                if (m_isModifiedFile)
                {
                    return;
                }
                m_isModifiedFile = true;

                // --

                if (ModelingFileModlfied != null)
                {
                    ModelingFileModlfied(this, new FModelingFileModifiedEventArgs(this));
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

        public void setSecsDriverConfig(
            )
        {
            try
            {
                if (m_fSecsDriver == null)
                {
                    return;
                }

                // --

                m_fSecsDriver.enabledEventsOfSecsDeviceState = m_fSsmCore.fOption.enabledEventsOfSecsDeviceState;
                m_fSecsDriver.enabledEventsOfSecsDeviceError = m_fSsmCore.fOption.enabledEventsOfSecsDeviceError;
                m_fSecsDriver.enabledEventsOfSecsDeviceTimeout = m_fSsmCore.fOption.enabledEventsOfSecsDeviceTimeout;
                m_fSecsDriver.enabledEventsOfSecsDeviceData = m_fSsmCore.fOption.enabledEventsOfSecsDeviceData;
                m_fSecsDriver.enabledEventsOfSecsDeviceTelnet = m_fSsmCore.fOption.enabledEventsOfSecsDeviceTelnet;
                m_fSecsDriver.enabledEventsOfSecsDeviceHandshake = m_fSsmCore.fOption.enabledEventsOfSecsDeviceHandshake;
                m_fSecsDriver.enabledEventsOfSecsDeviceControlMessage = m_fSsmCore.fOption.enabledEventsOfSecsDeviceControlMessage;
                m_fSecsDriver.enabledEventsOfSecsDeviceBlock = m_fSsmCore.fOption.enabledEventsOfSecsDeviceBlock;
                m_fSecsDriver.enabledEventsOfSecsDeviceSml = m_fSsmCore.fOption.enabledEventsOfSecsDeviceSml;
                m_fSecsDriver.enabledEventsOfSecsDeviceDataMessage = m_fSsmCore.fOption.enabledEventsOfSecsDeviceDataMessage;
                m_fSecsDriver.enabledEventsOfHostDeviceState = m_fSsmCore.fOption.enabledEventsOfHostDeviceState;
                m_fSecsDriver.enabledEventsOfHostDeviceError = m_fSsmCore.fOption.enabledEventsOfHostDeviceError;
                m_fSecsDriver.enabledEventsOfHostDeviceVfei = m_fSsmCore.fOption.enabledEventsOfHostDeviceVfei;
                m_fSecsDriver.enabledEventsOfHostDeviceDataMessage = m_fSsmCore.fOption.enabledEventsOfHostDeviceDataMessage;
                m_fSecsDriver.enabledEventsOfScenario = m_fSsmCore.fOption.enabledEventsOfScenario;
                m_fSecsDriver.enabledEventsOfApplication = m_fSsmCore.fOption.enabledEventsOfApplication;
                // --
                m_fSecsDriver.logDirectory = m_fSsmCore.fOption.logDirectory;
                m_fSecsDriver.enabledLogOfBinary = m_fSsmCore.fOption.enabledLogOfBinary;
                m_fSecsDriver.enabledLogOfSml = m_fSsmCore.fOption.enabledLogOfSml;
                m_fSecsDriver.enabledLogOfVfei = m_fSsmCore.fOption.enabledLogOfVfei;
                m_fSecsDriver.enabledLogOfSecs = m_fSsmCore.fOption.enabledLogOfSecs;
                // --
                m_fSecsDriver.maxLogFileSizeOfBinary = m_fSsmCore.fOption.maxLogFileSizeOfBinary;
                m_fSecsDriver.maxLogFileSizeOfSml = m_fSsmCore.fOption.maxLogFileSizeOfSml;
                m_fSecsDriver.maxLogFileSizeOfVfei = m_fSsmCore.fOption.maxLogFileSizeOfVfei;
                m_fSecsDriver.maxLogFileSizeOfSecs = m_fSsmCore.fOption.maxLogFileSizeOfSecs;
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

        #region m_fEventHandler Event Handler

        private void m_fEventHandler_ModelingFileOpenCompleted(
            object sender, 
            FModelingFileOpenCompletedEventArgs e
            )
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("ModelingFileOpened=" + e.fileName);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ModelingFileSaveCompleted(
            object sender, 
            FModelingFileSaveCompletedEventArgs e
            )
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("ModelingFileSaved=" + e.fileName);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ObjectInsertBeforeCompleted(
            object sender, 
            FObjectEventArgs e
            )
        {
            try
            {
                onModelingFileModified();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ObjectInsertAfterCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                onModelingFileModified();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ObjectAppendCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                onModelingFileModified();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ObjectRemoveCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                onModelingFileModified();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ObjectMoveUpCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                onModelingFileModified();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ObjectMoveDownCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                onModelingFileModified();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ObjectMoveToCompleted(
            object sender, 
            FObjectMoveToCompletedEventArgs e
            )
        {
            try
            {
                onModelingFileModified();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ObjectModifyCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                onModelingFileModified();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
