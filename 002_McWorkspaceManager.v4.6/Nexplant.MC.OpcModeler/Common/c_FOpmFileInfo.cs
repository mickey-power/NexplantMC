/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPlmFileInfo.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.10
--  Description     : FAMate OPC Modeling File Information Class 
--  History         : Created by Jeff.Kim at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaOpcDriver;

namespace Nexplant.MC.OpcModeler
{
    public class FOpmFileInfo : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        public event FModelingFileModifiedEventHandler ModelingFileModlfied = null;

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private static FIDPointer32 m_fFileIdPointer = new FIDPointer32();
        // --
        private bool m_isClosedFile = true;
        private bool m_isNewFile = false;
        private bool m_isModifiedFile = false;
        // --
        private string m_fileFullName = string.Empty;
        private string m_fileName = string.Empty;
        // --
        private FOpcDriver m_fOpcDriver = null;
        private FEventHandler m_fEventHandler = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOpmFileInfo(
            FOpmCore fOpmCore            
            )
        {
            m_fOpmCore = fOpmCore;            
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        //***
        //Library Clone 전용
        //***
        public FOpmFileInfo(
            FOpmCore fOpmCore,
            FOpcDriver fOpcDriver
            )
        {
            m_fOpmCore = fOpmCore;
            // --
            cloneFile(fOpcDriver);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOpmFileInfo(
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
                    m_fOpmCore = null;                    
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
                termOpcDriver();
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

        private void initOpcDriver(
            )
        {
            try
            {
                // ***
                // Opc Driver가 New File로 생성될 경우 Default Modeling File를 만들어 준다.
                // ***
                m_fOpcDriver.hostDriverDirectory = m_fOpmCore.fWsmCore.usrPath + "\\HostDriver";
                if (!Directory.Exists(m_fOpcDriver.hostDriverDirectory))
                {
                    Directory.CreateDirectory(m_fOpcDriver.hostDriverDirectory);
                }
                // --
                m_fOpcDriver.logDirectory = m_fOpmCore.fWsmCore.usrPath + "\\Log";
                if (!Directory.Exists(m_fOpcDriver.logDirectory))
                {
                    Directory.CreateDirectory(m_fOpcDriver.logDirectory);
                }

                //--

                //***
                // 2012.11.19 by spike.lee
                // OPC Driver Configuration Set
                //***
                setOpcDriverConfig();

                // --

                // ***
                // OPC Event Handler Create
                // ***
                m_fEventHandler = new FEventHandler(m_fOpcDriver, m_fOpmCore.fOpmContainer);
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

        private void termOpcDriver(
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

                if (m_fOpcDriver != null)
                {
                    m_fOpcDriver.Dispose();
                    m_fOpcDriver = null;
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
            const string DefaultFileName = "NexplantMcOpcModelingFile{0}.osm";

            try
            {
                return string.Format(DefaultFileName, FOpmFileInfo.m_fFileIdPointer.uniqueId.ToString());
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
            FOpcLibraryGroup fOlg = null;
            FOpcLibrary fOlb = null;
            FOpcDevice fOdv = null;
            FOpcSession fOsn = null;
            FHostLibraryGroup fHlg = null;
            FHostLibrary fHlb = null;
            FHostDevice fHdv = null;
            FHostSession fHsn = null;

            try
            {
                termOpcDriver();

                // --

                m_fOpcDriver = new FOpcDriver(m_fOpmCore.fWsmCore.licenseFileName, FOpcRunMode.WorkspaceManager);
                // --
                m_fOpcDriver.appendChildFuntionNameList(new FFunctionNameList(m_fOpcDriver));
                m_fOpcDriver.appendChildDataConversionSetList(new FDataConversionSetList(m_fOpcDriver));
                m_fOpcDriver.appendChildEquipmentStateSetList(new FEquipmentStateSetList(m_fOpcDriver));
                m_fOpcDriver.appendChildRepositoryList(new FRepositoryList(m_fOpcDriver));
                m_fOpcDriver.appendChildEnvironmentList(new FEnvironmentList(m_fOpcDriver));
                m_fOpcDriver.appendChildDataSetList(new FDataSetList(m_fOpcDriver));
                // --
                fOlg = m_fOpcDriver.appendChildOpcLibraryGroup(new FOpcLibraryGroup(m_fOpcDriver));
                fOlb = fOlg.appendChildOpcLibrary(new FOpcLibrary(m_fOpcDriver));
                fOlb.appendChildOpcMessageList(new FOpcMessageList(m_fOpcDriver));
                // --
                fOdv = m_fOpcDriver.appendChildOpcDevice(new FOpcDevice(m_fOpcDriver));
                fOsn = fOdv.appendChildOpcSession(new FOpcSession(m_fOpcDriver));
                fOsn.setLibrary(fOlb);
                // --
                fHlg = m_fOpcDriver.appendChildHostLibraryGroup(new FHostLibraryGroup(m_fOpcDriver));
                fHlb = fHlg.appendChildHostLibrary(new FHostLibrary(m_fOpcDriver));
                fHlb.appendChildHostMessageList(new FHostMessageList(m_fOpcDriver));
                // --
                fHdv = m_fOpcDriver.appendChildHostDevice(new FHostDevice(m_fOpcDriver));
                fHsn = fHdv.appendChildHostSession(new FHostSession(m_fOpcDriver));
                fHsn.setLibrary(fHlb);
                // --
                m_fOpcDriver.appendChildEquipment(new FEquipment(m_fOpcDriver));
                                
                // --
                // ***
                // 위에 Default Opc Moddeling File를 생성하는 동안 발생한 Event가 모두 제거될 때까지 대기한다.
                // ***
                m_fOpcDriver.waitEventHandlingCompleted();

                // --

                initOpcDriver();

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
                fOlg = null;
                fOlb = null;
                fOdv = null;
                fOsn = null;
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
                termOpcDriver();

                // --

                m_fOpcDriver = new FOpcDriver(m_fOpmCore.fWsmCore.licenseFileName, FOpcRunMode.WorkspaceManager);
                m_fOpcDriver.openModelingFile(fileName);
                // --
                initOpcDriver();

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
            FOpcDriver fOpcDriver
            )
        {
            try
            {
                termOpcDriver();

                // --

                m_fOpcDriver = fOpcDriver;
                // --
                initOpcDriver();

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

                m_fOpcDriver.saveModelingFile(fileName);

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
                termOpcDriver();

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

        public void setOpcDriverConfig(
            )
        {
            try
            {
                if (m_fOpcDriver == null)
                {
                    return;
                }

                // --

                m_fOpcDriver.enabledEventsOfOpcDeviceState = m_fOpmCore.fOption.enabledEventsOfOpcDeviceState;
                m_fOpcDriver.enabledEventsOfOpcDeviceError = m_fOpmCore.fOption.enabledEventsOfOpcDeviceError;
                m_fOpcDriver.enabledEventsOfOpcDeviceTimeout = m_fOpmCore.fOption.enabledEventsOfOpcDeviceTimeout;                
                m_fOpcDriver.enabledEventsOfOpcDeviceDataMessage = m_fOpmCore.fOption.enabledEventsOfOpcDeviceDataMessage;
                // --
                m_fOpcDriver.enabledEventsOfHostDeviceState = m_fOpmCore.fOption.enabledEventsOfHostDeviceState;
                m_fOpcDriver.enabledEventsOfHostDeviceError = m_fOpmCore.fOption.enabledEventsOfHostDeviceError;
                m_fOpcDriver.enabledEventsOfHostDeviceVfei = m_fOpmCore.fOption.enabledEventsOfHostDeviceVfei;
                m_fOpcDriver.enabledEventsOfHostDeviceDataMessage = m_fOpmCore.fOption.enabledEventsOfHostDeviceDataMessage;
                // --
                m_fOpcDriver.enabledEventsOfScenario = m_fOpmCore.fOption.enabledEventsOfScenario;
                m_fOpcDriver.enabledEventsOfApplication = m_fOpmCore.fOption.enabledEventsOfApplication;
                // --
                m_fOpcDriver.logDirectory = m_fOpmCore.fOption.logDirectory;                
                m_fOpcDriver.enabledLogOfVfei = m_fOpmCore.fOption.enabledLogOfVfei;
                m_fOpcDriver.enabledLogOfOpc = m_fOpmCore.fOption.enabledLogOfOpc;
                // --                
                m_fOpcDriver.maxLogFileSizeOfVfei = m_fOpmCore.fOption.maxLogFileSizeOfVfei;
                m_fOpcDriver.maxLogFileSizeOfOpc = m_fOpmCore.fOption.maxLogFileSizeOfOpc;
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
