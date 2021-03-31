/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FAdminAgentOption.cs
--  Creator         : baehyun.seo
--  Create Date     : 2012.12.21
--  Description     : FAMate Admin Agent Application Log Optioin Form Class 
--  History         : Created by baehyun.seo at 2012.12.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinEditors;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;
using Infragistics.Win.UltraWinDataSource;

namespace Nexplant.MC.AdminManager
{
    public partial class FAdminAgentOption : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private FADAOption m_fAdaOption = null;
        private bool m_isModified = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FAdminAgentOption()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FAdminAgentOption(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
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
                    m_fAdmCore = null;
                    m_fAdaOption = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void setTitle(
           )
        {
            try
            {
                base.changeControlCaption();
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

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
                base.fUIWizard.changeControlCaption(mnuMenu);
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

        protected override void changeControlFontName(
            )
        {
            try
            {
                base.changeControlFontName();
                base.fUIWizard.changeControlCaption(mnuMenu);
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

        private void controlMenu(
            )
        {
            try
            {
                mnuMenu.beginUpdate();

                // --

                mnuMenu.Tools[FMenuKey.MenuAaoUpdate].SharedProps.Enabled = m_isModified && FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.AdminAgentOption);

                // --

                mnuMenu.endUpdate();
            }
            catch (Exception ex)
            {
                mnuMenu.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void clear(
            )
        {
            try
            {
                m_fAdaOption = new FADAOption();
                setPropOfOption(exbCategory.ActiveItem);

                // --

                m_isModified = false;
                // --
                controlMenu();
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

        private void designExplorerBarOfCategory(
            )
        {
            try
            {
                exbCategory.beginUpdate();

                // --

                exbCategory.Groups[0].Items.Add(FAdminAgentOptionCategory.General.ToString(), "General");
                exbCategory.Groups[0].Items.Add(FAdminAgentOptionCategory.Highway101.ToString(), "Highway 101");
                exbCategory.Groups[0].Items.Add(FAdminAgentOptionCategory.DetectionPolicy.ToString(), "Detection Policy");
                exbCategory.Groups[0].Items.Add(FAdminAgentOptionCategory.ResourceCollectionPolicy.ToString(), "Resource Collection Policy");
                exbCategory.Groups[0].Items.Add(FAdminAgentOptionCategory.LogPolicy.ToString(), "Log Policy");

                // --

                exbCategory.endUpdate();

                // --

                exbCategory.Groups[0].Items[0].Active = true;
            }
            catch (Exception ex)
            {
                exbCategory.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void setPropOfOption(
            UltraExplorerBarItem item
            )
        {
            try
            {
                if (item.Key == FAdminAgentOptionCategory.General.ToString())
                {
                    pgdProp.selectedObject = new FPropAdaGeneral(m_fAdmCore, pgdProp, m_fAdaOption);
                }
                else if (item.Key == FAdminAgentOptionCategory.Highway101.ToString())
                {
                    pgdProp.selectedObject = new FPropAdaHighway101(m_fAdmCore, pgdProp, m_fAdaOption);
                }
                else if (item.Key == FAdminAgentOptionCategory.DetectionPolicy.ToString())
                {
                    pgdProp.selectedObject = new FPropAdaDetectionPolicy(m_fAdmCore, pgdProp, m_fAdaOption);
                }
                else if (item.Key == FAdminAgentOptionCategory.ResourceCollectionPolicy.ToString())
                {
                    pgdProp.selectedObject = new FPropAdaResourceCollection(m_fAdmCore, pgdProp, m_fAdaOption);
                }
                else if (item.Key == FAdminAgentOptionCategory.LogPolicy.ToString())
                {
                    pgdProp.selectedObject = new FPropAdaLogPolicy(m_fAdmCore, pgdProp, m_fAdaOption);
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

        private void refreshPropOfOption(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInOpt = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutOpt = null;
            FXmlNode fXmlNodeOutTmp = null;
            string key = string.Empty;

            try
            {
                #region Validation

                if (txtSvrName.Text.Trim() == string.Empty)
                {
                    txtSvrName.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { "Server" }));
                }

                #endregion

                // --

                m_fAdaOption = new FADAOption();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolAdminAgentOptionSearch_In.E_ADMADS_TolAdminAgentOptionSearch_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentOptionSearch_In.A_hLanguage, FADMADS_TolAdminAgentOptionSearch_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentOptionSearch_In.A_hFactory, FADMADS_TolAdminAgentOptionSearch_In.D_hLanguage, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentOptionSearch_In.A_hUserId, FADMADS_TolAdminAgentOptionSearch_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentOptionSearch_In.A_hStep, FADMADS_TolAdminAgentOptionSearch_In.D_hStep, "1");
                // --
                fXmlNodeInOpt = fXmlNodeIn.set_elem(FADMADS_TolAdminAgentOptionSearch_In.FOption.E_Option);
                fXmlNodeInOpt.set_elemVal(FADMADS_TolAdminAgentOptionSearch_In.FOption.A_Server, FADMADS_TolAdminAgentOptionSearch_In.FOption.D_Server, txtSvrName.Text);
                
                // --

                FADMADSCaster.ADMADS_TolAdminAgentOptionSearch_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolAdminAgentOptionSearch_Out.A_hStatus, FADMADS_TolAdminAgentOptionSearch_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_TolAdminAgentOptionSearch_Out.A_hStatusMessage, FADMADS_TolAdminAgentOptionSearch_Out.D_hStatusMessage)
                        );
                }

                // --

                fXmlNodeOutOpt = fXmlNodeOut.get_elem(FADMADS_TolAdminAgentOptionSearch_Out.FOption.E_Option);

                // --

                #region General Option Load

                fXmlNodeOutTmp = fXmlNodeOutOpt.get_elem(FADMADS_TolAdminAgentOptionSearch_Out.FOption.FGeneral.E_General);
                // --
                m_fAdaOption.factory = fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FGeneral.A_Factory,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FGeneral.D_Factory
                    );
                m_fAdaOption.server = fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FGeneral.A_Server,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FGeneral.D_Server
                    );
                m_fAdaOption.user = fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FGeneral.A_User,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FGeneral.D_User
                    );
                // --
                m_fAdaOption.serverThreadingCount = int.Parse(fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FGeneral.A_ServerThreadingCount,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FGeneral.D_ServerThreadingCount
                    ));
                // --
                m_fAdaOption.dataFolder = fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FGeneral.A_DataFolder,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FGeneral.D_DataFolder
                    );
                m_fAdaOption.logFolder = fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FGeneral.A_LogFolder, 
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FGeneral.D_LogFolder
                    );
                m_fAdaOption.ftpIp = fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FGeneral.A_FtpIp,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FGeneral.D_FtpIp
                    );
                m_fAdaOption.ftpUsedAnonymous = Boolean.Parse(fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FGeneral.A_FtpUsedAnonymous,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FGeneral.D_FtpUsedAnonymous
                    ));
                m_fAdaOption.ftpUser = fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FGeneral.A_FtpUser,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FGeneral.D_FtpUser
                    );
                m_fAdaOption.ftpPassword = fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FGeneral.A_FtpPassword,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FGeneral.D_FtpPassword
                    );

                #endregion

                // --

                #region Highway 101 Option Load

                fXmlNodeOutTmp = fXmlNodeOutOpt.get_elem(FADMADS_TolAdminAgentOptionSearch_Out.FOption.FHighway101.E_Highway101);
                // --
                m_fAdaOption.stationConnectString = fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FHighway101.A_StationConnectString,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FHighway101.D_StationConnectString
                    );
                m_fAdaOption.stationTimeout = int.Parse(fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FHighway101.A_StationTimeout,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FHighway101.D_StationTimeout
                    ));
                // --
                m_fAdaOption.adsTuneChannel = fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FHighway101.A_AdsTuneChannel,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FHighway101.D_AdsTuneChannel
                    );
                m_fAdaOption.adsCastChannel = fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FHighway101.A_AdsCastChannel,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FHighway101.D_AdsCastChannel
                    );

                #endregion

                // --

                #region Detection Policy Option Load

                fXmlNodeOutTmp = fXmlNodeOutOpt.get_elem(FADMADS_TolAdminAgentOptionSearch_Out.FOption.FDetectionPolicy.E_DetectionPolicy);
                // --
                m_fAdaOption.eapWatchEnabled = (FYesNo)Enum.Parse(typeof(FYesNo), fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FDetectionPolicy.A_EapWatchEnabled,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FDetectionPolicy.D_EapWatchEnabled
                    ));
                // --
                m_fAdaOption.eapWatchCycleTime = int.Parse(fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FDetectionPolicy.A_EapWatchCycleTime,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FDetectionPolicy.D_EapWatchCycleTime
                    ));
                // --
                m_fAdaOption.opcServerWatchEnabled = (FYesNo)Enum.Parse(typeof(FYesNo), fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FDetectionPolicy.A_OpcServerWatchEnabled,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FDetectionPolicy.D_OpcServerWatchEnabled
                    ));
                // --
                m_fAdaOption.opcServerWatchCycleTime = int.Parse(fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FDetectionPolicy.A_OpcServerWatchCycleTime,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FDetectionPolicy.D_OpcServerWatchCycleTime
                    ));
                // --
                m_fAdaOption.opcServerProcessName = fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FDetectionPolicy.A_OpcServerProcessName,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FDetectionPolicy.D_OpcServerProcessName
                    );

                #endregion

                // --

                #region Resource Collection Policy Option Load

                fXmlNodeOutTmp = fXmlNodeOutOpt.get_elem(FADMADS_TolAdminAgentOptionSearch_Out.FOption.FResourceCollectionPolicy.E_ResourceCollectionPolicy);
                // --
                m_fAdaOption.resourceCollectionEnabled = (FYesNo)Enum.Parse(typeof(FYesNo), fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FResourceCollectionPolicy.A_ResourceCollectionEnabled,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FResourceCollectionPolicy.D_ResourceCollectionEnabled
                    ));
                m_fAdaOption.resourceCollectionCycleTime = int.Parse(fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FResourceCollectionPolicy.A_ResourceCollectionCycleTime,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FResourceCollectionPolicy.D_ResourceCollectionCycleTime
                    ));

                #endregion

                // -- 

                #region Log Policy Option Load

                fXmlNodeOutTmp = fXmlNodeOutOpt.get_elem(FADMADS_TolAdminAgentOptionSearch_Out.FOption.FLogPolicy.E_LogPolicy);
                // --
                m_fAdaOption.adaLogFileSize = int.Parse(fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FLogPolicy.A_AdaLogFileSize,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FLogPolicy.D_AdaLogFileSize
                    ));
                m_fAdaOption.adaLogBackupCycleTime = int.Parse(fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FLogPolicy.A_AdaLogFileBackupCycleTime,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FLogPolicy.A_AdaLogFileBackupCycleTime
                    ));
                m_fAdaOption.adaLogFileKeepingPeriod = int.Parse(fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FLogPolicy.A_AdaLogFileKeepingPeriod,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FLogPolicy.D_AdaLogFileKeepingPeriod
                    ));
                m_fAdaOption.adaLogFileCompressCount = int.Parse(fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FLogPolicy.A_AdaLogFileCompressCount,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FLogPolicy.D_AdaLogFileCompressCount
                    ));
                m_fAdaOption.eapBackupCycleTime = int.Parse(fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FLogPolicy.A_EapLogFileBackupCycleTime,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FLogPolicy.A_EapLogFileBackupCycleTime
                    ));
                m_fAdaOption.eapLogFileKeepingPeriod = int.Parse(fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FLogPolicy.A_EapLogFileKeepingPeriod,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FLogPolicy.D_EapLogFileKeepingPeriod
                    ));
                m_fAdaOption.eapLogFileCompressCount = int.Parse(fXmlNodeOutTmp.get_elemVal(
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FLogPolicy.A_EapLogFileCompressCount,
                    FADMADS_TolAdminAgentOptionSearch_Out.FOption.FLogPolicy.D_EapLogFileCompressCount
                    ));

                #endregion

                // --

                if (exbCategory.ActiveItem != null)
                {
                    setPropOfOption(exbCategory.ActiveItem);
                }

                // --    

                m_isModified = false;
                controlMenu();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);                    
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInOpt = null;
                fXmlNodeOut = null;
                fXmlNodeOutOpt = null;
                fXmlNodeOutTmp = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void update(
            )
        {
            try
            {
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fWsmCore.fUIWizard.generateMessage("Q0015", new object[] { "Admin Agent Option" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                updatePropOfOption();

                // --

                m_isModified = false;
                controlMenu();
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

        private void updatePropOfOption(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInOpt = null;
            FXmlNode fXmlNodeInGen = null;
            FXmlNode fXmlNodeInHig = null;
            FXmlNode fXmlNodeInDep = null;
            FXmlNode fXmlNodeInRsc = null;
            FXmlNode fXmlNodeInLop = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolAdminAgentOptionUpdate_In.E_ADMADS_TolAdminAgentOptionUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.A_hLanguage, FADMADS_TolAdminAgentOptionUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.A_hFactory, FADMADS_TolAdminAgentOptionUpdate_In.D_hLanguage, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.A_hUserId, FADMADS_TolAdminAgentOptionUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.A_hHostIp, FADMADS_TolAdminAgentOptionUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.A_hHostName, FADMADS_TolAdminAgentOptionUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.A_hStep, FADMADS_TolAdminAgentOptionUpdate_In.D_hStep, "1");
                // --
                fXmlNodeInOpt = fXmlNodeIn.set_elem(FADMADS_TolAdminAgentOptionUpdate_In.FOption.E_Option);
                fXmlNodeInOpt.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.A_Server, FADMADS_TolAdminAgentOptionUpdate_In.FOption.D_Server, txtSvrName.Text);
                // --

                #region General Option

                fXmlNodeInGen = fXmlNodeInOpt.set_elem(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FGeneral.E_General);
                fXmlNodeInGen.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FGeneral.A_Factory, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FGeneral.D_Factory, m_fAdaOption.factory);
                fXmlNodeInGen.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FGeneral.A_Server, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FGeneral.D_Server, m_fAdaOption.server);
                fXmlNodeInGen.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FGeneral.A_User, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FGeneral.D_User, m_fAdaOption.user);
                fXmlNodeInGen.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FGeneral.A_ServerThreadingCount, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FGeneral.D_ServerThreadingCount, m_fAdaOption.serverThreadingCount.ToString());
                fXmlNodeInGen.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FGeneral.A_DataFolder, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FGeneral.D_DataFolder, m_fAdaOption.dataFolder);
                fXmlNodeInGen.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FGeneral.A_LogFolder, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FGeneral.D_LogFolder, m_fAdaOption.logFolder);
                fXmlNodeInGen.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FGeneral.A_FtpIp, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FGeneral.D_FtpIp, m_fAdaOption.ftpIp);
                fXmlNodeInGen.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FGeneral.A_FtpUsedAnonymous, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FGeneral.D_FtpUsedAnonymous, m_fAdaOption.ftpUsedAnonymous.ToString());
                fXmlNodeInGen.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FGeneral.A_FtpUser, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FGeneral.D_FtpUser, m_fAdaOption.ftpUser);
                fXmlNodeInGen.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FGeneral.A_FtpPassword, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FGeneral.D_FtpPassword, m_fAdaOption.ftpPassword);

                #endregion

                // --

                #region Highway 101 Option

                fXmlNodeInHig = fXmlNodeInOpt.set_elem(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FHighway101.E_Highway101);
                fXmlNodeInHig.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FHighway101.A_StationConnectString, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FHighway101.D_StationConnectString, m_fAdaOption.stationConnectString);
                fXmlNodeInHig.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FHighway101.A_StationTimeout, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FHighway101.D_StationTimeout, m_fAdaOption.stationTimeout.ToString());
                fXmlNodeInHig.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FHighway101.A_AdsTuneChannel, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FHighway101.D_AdsTuneChannel, m_fAdaOption.adsTuneChannel);
                fXmlNodeInHig.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FHighway101.A_AdsCastChannel, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FHighway101.D_AdsCastChannel, m_fAdaOption.adsCastChannel);

                #endregion

                // --

                #region Detection Policy Option

                fXmlNodeInDep = fXmlNodeInOpt.set_elem(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FDetectionPolicy.E_DetectionPolicy);
                fXmlNodeInDep.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FDetectionPolicy.A_EapWatchEnabled, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FDetectionPolicy.D_EapWatchEnabled, m_fAdaOption.eapWatchEnabled.ToString());
                fXmlNodeInDep.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FDetectionPolicy.A_EapWatchCycleTime, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FDetectionPolicy.D_EapWatchCycleTime, m_fAdaOption.eapWatchCycleTime.ToString());
                fXmlNodeInDep.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FDetectionPolicy.A_OpcServerWatchEnabled, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FDetectionPolicy.D_OpcServerWatchEnabled, m_fAdaOption.opcServerWatchEnabled.ToString());
                fXmlNodeInDep.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FDetectionPolicy.A_OpcServerWatchCycleTime, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FDetectionPolicy.D_OpcServerWatchCycleTime, m_fAdaOption.opcServerWatchCycleTime.ToString());
                fXmlNodeInDep.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FDetectionPolicy.A_OpcServerProcessName, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FDetectionPolicy.D_OpcServerProcessName, m_fAdaOption.opcServerProcessName);

                #endregion

                // --

                #region Resource Collection Policy Option

                fXmlNodeInRsc = fXmlNodeInOpt.set_elem(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FResourceCollectionPolicy.E_ResourceCollectionPolicy);
                fXmlNodeInRsc.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FResourceCollectionPolicy.A_ResourceCollectionEnabled, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FResourceCollectionPolicy.D_ResourceCollectionEnabled, m_fAdaOption.resourceCollectionEnabled.ToString());
                fXmlNodeInRsc.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FResourceCollectionPolicy.A_ResourceCollectionCycleTime, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FResourceCollectionPolicy.D_ResourceCollectionCycleTime, m_fAdaOption.resourceCollectionCycleTime.ToString());

                #endregion

                // --

                #region Log Policy Option

                fXmlNodeInLop = fXmlNodeInOpt.set_elem(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FLogPolicy.E_LogPolicy);
                fXmlNodeInLop.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FLogPolicy.A_AdaLogFileSize, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FLogPolicy.D_AdaLogFileSize, m_fAdaOption.adaLogFileSize.ToString());
                fXmlNodeInLop.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FLogPolicy.A_AdaLogFileBackupCycleTime, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FLogPolicy.D_AdaLogFileBackupCycleTime, m_fAdaOption.adaLogBackupCycleTime.ToString());
                fXmlNodeInLop.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FLogPolicy.A_AdaLogFileKeepingPeriod, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FLogPolicy.D_AdaLogFileKeepingPeriod, m_fAdaOption.adaLogFileKeepingPeriod.ToString());
                fXmlNodeInLop.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FLogPolicy.A_AdaLogFileCompressCount, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FLogPolicy.D_AdaLogFileCompressCount, m_fAdaOption.adaLogFileCompressCount.ToString());
                fXmlNodeInLop.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FLogPolicy.A_EapLogFileBackupCycleTime, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FLogPolicy.D_EapLogFileBackupCycleTime, m_fAdaOption.eapBackupCycleTime.ToString());
                fXmlNodeInLop.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FLogPolicy.A_EapLogFileKeepingPeriod, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FLogPolicy.D_EapLogFileKeepingPeriod, m_fAdaOption.eapLogFileKeepingPeriod.ToString());
                fXmlNodeInLop.set_elemVal(FADMADS_TolAdminAgentOptionUpdate_In.FOption.FLogPolicy.A_EapLogFileCompressCount, FADMADS_TolAdminAgentOptionUpdate_In.FOption.FLogPolicy.D_EapLogFileCompressCount, m_fAdaOption.eapLogFileCompressCount.ToString());

                #endregion

                // --

                FADMADSCaster.ADMADS_TolAdminAgentOptionUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn, 
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolAdminAgentOptionUpdate_Out.A_hStatus, FADMADS_TolAdminAgentOptionUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_TolAdminAgentOptionUpdate_Out.A_hStatusMessage, FADMADS_TolAdminAgentOptionUpdate_Out.D_hStatusMessage)
                        );
                }
   
                // --

                FMessageBox.showInformation(FConstants.ApplicationName, m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0012"), this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;                
                fXmlNodeInOpt = null;
                fXmlNodeInGen = null;
                fXmlNodeInHig = null;
                fXmlNodeInDep = null;
                fXmlNodeInRsc = null;
                fXmlNodeInLop = null;
                fXmlNodeOut = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region FAdminAgentOption Form Event Handler

        private void FAdminAgentOption_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fAdaOption = new FADAOption();

                // --

                designExplorerBarOfCategory();

                // --

                m_fAdmCore.fOption.fChildFormList.add(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void FAdminAgentOption_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_isModified = false;
                controlMenu();

                // --

                txtSvrName.Focus();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void FAdminAgentOption_FormClosing(
            object sender,
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fAdmCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FAdminAgentOption_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    FCursor.waitCursor();
                    // --
                    refreshPropOfOption();
                    // --
                    FCursor.defaultCursor();
                }
            }
            catch (Exception ex)
            {
                FCursor.defaultCursor();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region mnuMenu Control Event Handler

        private void mnuMenu_ToolClick(
            object sender,
            Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuAaoRefresh)
                {
                    refreshPropOfOption();
                }
                else if (e.Tool.Key == FMenuKey.MenuAaoUpdate)
                {
                    update();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region exbCategory Control Event Handler

        private void exbCategory_ActiveItemChanged(
            object sender, 
            Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfOption(e.Item);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region pgdProp Control Event Handler

        private void pgdProp_PropertyValueChanged(
            object s, 
            PropertyValueChangedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.ChangedItem.Value != e.OldValue)
                {
                    m_isModified = true;
                    controlMenu();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region txtSvrName Control Event Handler

        private void txtSvrName_EditorButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            FServerSelector fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FServerSelector(m_fAdmCore, FServerType.Real.ToString(), txtSvrName.Text, "N");
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtSvrName.Text = fDialog.selectedServer;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                if (fDialog != null)
                {
                    fDialog.Dispose();
                    fDialog = null;
                }

                // --

                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void txtSvrName_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                clear();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
