/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropOptionLog.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.04
--  Description     : FAMate Opc Modeler Option of Log Property Source Object Class 
--  History         : Created by spike.lee at 2017.04.04
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.OpcModeler
{
    public class FPropOptionLog : FDynPropCusBase<FOpmCore>
    {
        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryDirectory = "[01] Directory";
        private const string CategoryLogEnabled = "[02] Log Enabled";
        private const string CategoryMaxLogFileSize = "[03] Max Log File Size";

        // --

        private bool m_disposed = false;
        // --
        private FOptionSource m_fOptionSource = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropOptionLog(
            FOpmCore fOpmCore,
            FDynPropGrid fPropGrid,
            FOptionSource fOptionSource
            )
            : base(fOpmCore, fOpmCore.fUIWizard, fPropGrid)
        {
            m_fOptionSource = fOptionSource;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropOptionLog(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    term();
                    // --
                    m_fOptionSource = null;
                }
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
        
        #region Directory

        [Category(CategoryDirectory)]
        [Editor(typeof(FPropAttrFolderUITypeEditor), typeof(UITypeEditor))]
        public string LogDirectory
        {
            get
            {
                try
                {
                    return m_fOptionSource.logDirectory;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
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
                    m_fOptionSource.logDirectory = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Log Enabled

        [Category(CategoryLogEnabled)]
        public bool EnabledLogOfOpc
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledLogOfOpc;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_fOptionSource.enabledLogOfOpc = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryLogEnabled)]
        public bool EnabledLogOfVfei
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledLogOfVfei;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_fOptionSource.enabledLogOfVfei = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Log File Size

        [Category(CategoryMaxLogFileSize)]
        public long MaxLogFileSizeOfOpc
        {
            get
            {
                try
                {
                    return m_fOptionSource.maxLogFileSizeOfOpc / 1024 / 1024;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return 0;
            }

            set
            {
                try
                {
                    if (value < 1)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Max OPC Log File Size" }));
                    }
                    // --
                    m_fOptionSource.maxLogFileSizeOfOpc = value * 1024 * 1024;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryMaxLogFileSize)]
        public long MaxLogFileSizeOfVfei
        {
            get
            {
                try
                {
                    return m_fOptionSource.maxLogFileSizeOfVfei / 1024 / 1024;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return 0;
            }

            set
            {
                try
                {
                    if (value < 1)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Max VFEI Log File Size" }));
                    }
                    // --
                    m_fOptionSource.maxLogFileSizeOfVfei = value * 1024 * 1024;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                base.fTypeDescriptor.properties["LogDirectory"].attributes.replace(new DisplayNameAttribute("Log File"));
                // --
                base.fTypeDescriptor.properties["EnabledLogOfOpc"].attributes.replace(new DisplayNameAttribute("OPC Log File"));
                base.fTypeDescriptor.properties["EnabledLogOfVfei"].attributes.replace(new DisplayNameAttribute("VFEI Log File"));
                // --
                base.fTypeDescriptor.properties["MaxLogFileSizeOfOpc"].attributes.replace(new DisplayNameAttribute("OPC Log File Size (MB)"));
                base.fTypeDescriptor.properties["MaxLogFileSizeOfVfei"].attributes.replace(new DisplayNameAttribute("VFEI Log File Size (MB)"));

                // --

                base.fTypeDescriptor.properties["LogDirectory"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.logDirectory));
                // --
                base.fTypeDescriptor.properties["EnabledLogOfOpc"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledLogOfOpc));
                base.fTypeDescriptor.properties["EnabledLogOfVfei"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledLogOfVfei));
                // --
                base.fTypeDescriptor.properties["MaxLogFileSizeOfOpc"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.maxLogFileSizeOfOpc / 1024 / 1024));
                base.fTypeDescriptor.properties["MaxLogFileSizeOfVfei"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.maxLogFileSizeOfVfei / 1024 / 1024));

                // --

                this.fPropGrid.DynPropGridRefreshRequested += new FDynPropGridRefreshRequestedEventHandler(fPropGrid_DynPropGridRefreshRequested);
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
                this.fPropGrid.DynPropGridRefreshRequested -= new FDynPropGridRefreshRequestedEventHandler(fPropGrid_DynPropGridRefreshRequested);
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

        private void procRefreshRequested(
            )
        {
            try
            {
                this.fPropGrid.Refresh();
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

        #region fPropGrid Event Handler

        private void fPropGrid_DynPropGridRefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                procRefreshRequested();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end


