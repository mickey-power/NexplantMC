/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcmFileInfo.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.10 
--  Description     : FAMate TCP Modeling File Information Class 
--  History         : Created by Jeff.Kim at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaTcpDriver;

namespace Nexplant.MC.TcpModeler
{
    public class FTcmFileInfo : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        public event FModelingFileModifiedEventHandler ModelingFileModlfied = null;

        private bool m_disposed = false;
        // --
        private FTcmCore m_fTcmCore = null;
        private static FIDPointer32 m_fFileIdPointer = new FIDPointer32();
        // --
        private bool m_isClosedFile = true;
        private bool m_isNewFile = false;
        private bool m_isModifiedFile = false;
        // --
        private string m_fileFullName = string.Empty;
        private string m_fileName = string.Empty;
        // --
        private FTcpDriver m_fTcpDriver = null;
        private FEventHandler m_fEventHandler = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcmFileInfo(
            FTcmCore fTcmCore            
            )
        {
            m_fTcmCore = fTcmCore;            
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        //***
        //Library Clone 전용
        //***
        public FTcmFileInfo(
            FTcmCore fTcmCore,
            FTcpDriver fTcpDriver
            )
        {
            m_fTcmCore = fTcmCore;
            // --
            cloneFile(fTcpDriver);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcmFileInfo(
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
                    m_fTcmCore = null;                    
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
                termTcpDriver();
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

        private void initTcpDriver(
            )
        {
            try
            {
                // ***
                // TCP Driver가 New File로 생성될 경우 Default Modeling File를 만들어 준다.
                // ***
                m_fTcpDriver.hostDriverDirectory = m_fTcmCore.fWsmCore.usrPath + "\\HostDriver";
                if (!Directory.Exists(m_fTcpDriver.hostDriverDirectory))
                {
                    Directory.CreateDirectory(m_fTcpDriver.hostDriverDirectory);
                }
                // --
                m_fTcpDriver.logDirectory = m_fTcmCore.fWsmCore.usrPath + "\\Log";
                if (!Directory.Exists(m_fTcpDriver.logDirectory))
                {
                    Directory.CreateDirectory(m_fTcpDriver.logDirectory);
                }

                //--

                //***
                // 2012.11.19 by spike.lee
                // TCP Driver Configuration Set
                //***
                setTcpDriverConfig();

                // --

                // ***
                // TCP Event Handler Create
                // ***
                m_fEventHandler = new FEventHandler(m_fTcpDriver, m_fTcmCore.fTcmContainer);
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

        private void termTcpDriver(
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

                if (m_fTcpDriver != null)
                {
                    m_fTcpDriver.Dispose();
                    m_fTcpDriver = null;
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
            const string DefaultFileName = "NexplantMcTcpModelingFile{0}.tsm";

            try
            {
                return string.Format(DefaultFileName, FTcmFileInfo.m_fFileIdPointer.uniqueId.ToString());
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
            FTcpLibraryGroup fTlg = null;
            FTcpLibrary fTlb = null;
            FTcpDevice fTdv = null;
            FTcpSession fTsn = null;
            FHostLibraryGroup fHlg = null;
            FHostLibrary fHlb = null;
            FHostDevice fHdv = null;
            FHostSession fHsn = null;

            try
            {
                termTcpDriver();

                // --

                m_fTcpDriver = new FTcpDriver(m_fTcmCore.fWsmCore.licenseFileName);
                // --
                m_fTcpDriver.appendChildFuntionNameList(new FFunctionNameList(m_fTcpDriver));
                m_fTcpDriver.appendChildDataConversionSetList(new FDataConversionSetList(m_fTcpDriver));
                m_fTcpDriver.appendChildEquipmentStateSetList(new FEquipmentStateSetList(m_fTcpDriver));
                m_fTcpDriver.appendChildRepositoryList(new FRepositoryList(m_fTcpDriver));
                m_fTcpDriver.appendChildEnvironmentList(new FEnvironmentList(m_fTcpDriver));
                m_fTcpDriver.appendChildDataSetList(new FDataSetList(m_fTcpDriver));
                // --
                fTlg = m_fTcpDriver.appendChildTcpLibraryGroup(new FTcpLibraryGroup(m_fTcpDriver));
                fTlb = fTlg.appendChildTcpLibrary(new FTcpLibrary(m_fTcpDriver));
                fTlb.appendChildTcpMessageList(new FTcpMessageList(m_fTcpDriver));
                // --
                fTdv = m_fTcpDriver.appendChildTcpDevice(new FTcpDevice(m_fTcpDriver));
                fTsn = fTdv.appendChildTcpSession(new FTcpSession(m_fTcpDriver));
                fTsn.setLibrary(fTlb);
                // --
                fHlg = m_fTcpDriver.appendChildHostLibraryGroup(new FHostLibraryGroup(m_fTcpDriver));
                fHlb = fHlg.appendChildHostLibrary(new FHostLibrary(m_fTcpDriver));
                fHlb.appendChildHostMessageList(new FHostMessageList(m_fTcpDriver));
                // --
                fHdv = m_fTcpDriver.appendChildHostDevice(new FHostDevice(m_fTcpDriver));
                fHsn = fHdv.appendChildHostSession(new FHostSession(m_fTcpDriver));
                fHsn.setLibrary(fHlb);
                // --
                m_fTcpDriver.appendChildEquipment(new FEquipment(m_fTcpDriver));
                                
                // --
                // ***
                // 위에 Default TCP Moddeling File를 생성하는 동안 발생한 Event가 모두 제거될 때까지 대기한다.
                // ***
                m_fTcpDriver.waitEventHandlingCompleted();

                // --

                initTcpDriver();

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
                fTlg = null;
                fTlb = null;
                fTdv = null;
                fTsn = null;
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
                termTcpDriver();

                // --

                m_fTcpDriver = new FTcpDriver(m_fTcmCore.fWsmCore.licenseFileName);
                m_fTcpDriver.openModelingFile(fileName);
                // --
                initTcpDriver();

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
                
        private void cloneFile(
            FTcpDriver fTcpDriver
            )
        {
            try
            {
                termTcpDriver();

                // --

                m_fTcpDriver = fTcpDriver;
                // --
                initTcpDriver();

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

                m_fTcpDriver.saveModelingFile(fileName);

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
                termTcpDriver();

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

        public void setTcpDriverConfig(
            )
        {
            try
            {
                if (m_fTcpDriver == null)
                {
                    return;
                }

                // --

                m_fTcpDriver.enabledEventsOfTcpDeviceState = m_fTcmCore.fOption.enabledEventsOfTcpDeviceState;
                m_fTcpDriver.enabledEventsOfTcpDeviceError = m_fTcmCore.fOption.enabledEventsOfTcpDeviceError;
                m_fTcpDriver.enabledEventsOfTcpDeviceTimeout = m_fTcmCore.fOption.enabledEventsOfTcpDeviceTimeout;
                m_fTcpDriver.enabledEventsOfTcpDeviceXml = m_fTcmCore.fOption.enabledEventsOfTcpDeviceXlg;
                m_fTcpDriver.enabledEventsOfTcpDeviceDataMessage = m_fTcmCore.fOption.enabledEventsOfTcpDeviceDataMessage;
                m_fTcpDriver.enabledEventsOfHostDeviceState = m_fTcmCore.fOption.enabledEventsOfHostDeviceState;
                m_fTcpDriver.enabledEventsOfHostDeviceError = m_fTcmCore.fOption.enabledEventsOfHostDeviceError;
                m_fTcpDriver.enabledEventsOfHostDeviceVfei = m_fTcmCore.fOption.enabledEventsOfHostDeviceVfei;
                m_fTcpDriver.enabledEventsOfHostDeviceDataMessage = m_fTcmCore.fOption.enabledEventsOfHostDeviceDataMessage;
                m_fTcpDriver.enabledEventsOfScenario = m_fTcmCore.fOption.enabledEventsOfScenario;
                m_fTcpDriver.enabledEventsOfApplication = m_fTcmCore.fOption.enabledEventsOfApplication;
                // --
                m_fTcpDriver.logDirectory = m_fTcmCore.fOption.logDirectory;        
                // --
                m_fTcpDriver.enabledLogOfBinary = m_fTcmCore.fOption.enabledLogOfBinary;
                m_fTcpDriver.enabledLogOfXml = m_fTcmCore.fOption.enabledLogOfXlg;
                m_fTcpDriver.enabledLogOfVfei = m_fTcmCore.fOption.enabledLogOfVfei;
                m_fTcpDriver.enabledLogOfTcp = m_fTcmCore.fOption.enabledLogOfTcp;
                // --
                m_fTcpDriver.maxLogFileSizeOfBinary = m_fTcmCore.fOption.maxLogFileSizeOfBinary;
                m_fTcpDriver.maxLogFileSizeOfXml = m_fTcmCore.fOption.maxLogFileSizeOfXlg;
                m_fTcpDriver.maxLogFileSizeOfVfei = m_fTcmCore.fOption.maxLogFileSizeOfVfei;
                m_fTcpDriver.maxLogFileSizeOfTcp = m_fTcmCore.fOption.maxLogFileSizeOfTcp;
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
