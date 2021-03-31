/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAdaLogPolicy.cs
--  Creator         : baehyun.seo
--  Create Date     : 2012.12.21
--  Description     : FAMate Admin Manager Admin Agent Option Log Policy Source Object Class 
--  History         : Created by baehyun.seo at 2012.12.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Design;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public class FPropAdaLogPolicy : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryAdminAgentLogFile = "[01] Admin Agent Log File";
        private const string CategoryAdminAgentLogFileBackup = "[02] Admin Agent Log File Backup";
        private const string CategoryEapLogFileBackup = "[03] MC Log File Backup";

        // --

        private bool m_disposed = false;
        private FADAOption m_source = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropAdaLogPolicy(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FADAOption source
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_source = source;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropAdaLogPolicy(
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
                    m_source = null;
                }
            }
            m_disposed = true;

            // --

            base.myDispose(disposing);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Admin Agent Log File

        [Category(CategoryAdminAgentLogFile)]
        public int LogFileSize
        {
            get
            {
                try
                {
                    return m_source.adaLogFileSize;
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
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Value" }));
                    }

                    // --

                    m_source.adaLogFileSize = value;
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

        #region Admin Agent Log File Backup

        [Category(CategoryAdminAgentLogFileBackup)]
        public int AdaBackupCycleTime
        {
            get
            {
                try
                {
                    return m_source.adaLogBackupCycleTime;
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
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Value" }));
                    }

                    // --

                    m_source.adaLogBackupCycleTime = value;
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

        [Category(CategoryAdminAgentLogFileBackup)]
        public int AdaLogFileCompressCount
        {
            get
            {
                try
                {
                    return m_source.adaLogFileCompressCount;
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
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Value" }));
                    }

                    // --

                    m_source.adaLogFileCompressCount = value;
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

        [Category(CategoryAdminAgentLogFileBackup)]
        public int AdaLogFileKeepingPeriod
        {
            get
            {
                try
                {
                    return m_source.adaLogFileKeepingPeriod;
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
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Value" }));
                    }

                    // --

                    m_source.adaLogFileKeepingPeriod = value;
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

        #region EAP Log File Backup

        [Category(CategoryEapLogFileBackup)]
        public int EapBackupCycleTime
        {
            get
            {
                try
                {
                    return m_source.eapBackupCycleTime;
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
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Value" }));
                    }

                    // --

                    m_source.eapBackupCycleTime = value;
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

        [Category(CategoryEapLogFileBackup)]
        public int EapLogFileCompressCount
        {
            get
            {
                try
                {
                    return m_source.eapLogFileCompressCount;
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
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Value" }));
                    }

                    // --

                    m_source.eapLogFileCompressCount = value;
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

        [Category(CategoryEapLogFileBackup)]
        public int EapLogFileKeepingPeriod
        {
            get
            {
                try
                {
                    return m_source.eapLogFileKeepingPeriod;
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
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Value" }));
                    }

                    // --

                    m_source.eapLogFileKeepingPeriod = value;
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
                base.fTypeDescriptor.properties["LogFileSize"].attributes.replace(new DisplayNameAttribute("Log File Size (MB)"));
                // --
                base.fTypeDescriptor.properties["AdaBackupCycleTime"].attributes.replace(new DisplayNameAttribute("Backup Cycle Time (min)"));
                base.fTypeDescriptor.properties["AdaLogFileCompressCount"].attributes.replace(new DisplayNameAttribute("Log File Compress Count"));
                base.fTypeDescriptor.properties["AdaLogFileKeepingPeriod"].attributes.replace(new DisplayNameAttribute("Log File Keeping Period (Day)"));
                // --
                base.fTypeDescriptor.properties["EapBackupCycleTime"].attributes.replace(new DisplayNameAttribute("Backup Cycle Time (min)"));
                base.fTypeDescriptor.properties["EapLogFileCompressCount"].attributes.replace(new DisplayNameAttribute("Log File Compress Count"));
                base.fTypeDescriptor.properties["EapLogFileKeepingPeriod"].attributes.replace(new DisplayNameAttribute("Log File Keeping Period (Day)"));

                // --

                base.fTypeDescriptor.properties["LogFileSize"].attributes.replace(new DefaultValueAttribute(this.LogFileSize));
                // --
                base.fTypeDescriptor.properties["AdaBackupCycleTime"].attributes.replace(new DefaultValueAttribute(this.AdaBackupCycleTime));
                base.fTypeDescriptor.properties["AdaLogFileCompressCount"].attributes.replace(new DefaultValueAttribute(this.AdaLogFileCompressCount));
                base.fTypeDescriptor.properties["AdaLogFileKeepingPeriod"].attributes.replace(new DefaultValueAttribute(this.AdaLogFileKeepingPeriod));
                // --
                base.fTypeDescriptor.properties["EapBackupCycleTime"].attributes.replace(new DefaultValueAttribute(this.EapBackupCycleTime));
                base.fTypeDescriptor.properties["EapLogFileCompressCount"].attributes.replace(new DefaultValueAttribute(this.EapLogFileCompressCount));
                base.fTypeDescriptor.properties["EapLogFileKeepingPeriod"].attributes.replace(new DefaultValueAttribute(this.EapLogFileKeepingPeriod));
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

    }   // Class end
}   // Namespace end
