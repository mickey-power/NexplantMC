/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FAdmCore.cs
--  Creator         : mj.kim
--  Create Date     : 2011.09.22
--  Description     : FAMate Admin Core Core Class 
--  History         : Created by mj.kim at 2011.09.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.AdminManager
{
    public class FAdmCore : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FMonitoringServerDataReceivedEventHandler MonitoringServerDataReceived = null;
        public event FMonitoringPackageDataReceivedEventHandler MonitoringPackageDataReceived = null;
        public event FMonitoringPackageVerDataReceivedEventHandler MonitoringPackageVerDataReceived = null;
        public event FMonitoringModelDataReceivedEventHandler MonitoringModelDataReceived = null;
        public event FMonitoringModelVerDataReceivedEventHandler MonitoringModelVerDataReceived = null;
        public event FMonitoringComponentDataReceivedEventHandler MonitoringComponentDataReceived = null;
        public event FMonitoringComponentVerDataReceivedEventHandler MonitoringComponentVerDataReceived = null;
        public event FMonitoringEapDataReceivedEventHandler MonitoringEapDataReceived = null;
        public event FMonitoringEquipmentTypeDataReceivedEventHandler MonitoringEquipmentTypeDataReceived = null;
        public event FMonitoringEquipmentAreaDataReceivedEventHandler MonitoringEquipmentAreaDataReceived = null;
        public event FMonitoringEquipmentLineDataReceivedEventHandler MonitoringEquipmentLineDataReceived = null;
        public event FMonitoringEquipmentDataReceivedEventHandler MonitoringEquipmentDataReceived = null;
        public event FMonitoringDeviceDataReceivedEventHandler MonitoringDeviceDataReceived = null;
        public event FMonitoringSecs1ToHsmsConverterDataReceivedEventHandler MonitoringSecs1ToHsmsConverterDataReceived = null;
        public event FMonitoringSecs1ToHsmsConverterDisconnectDataReceivedEventHandler MonitoringSecs1ToHsmsConverterDisconnectDataReceived = null;
        // --
        public event FServerIssueEventRefreshEventHandler ServerIssueEventRefresh = null;
        public event FEapIssueEventRefreshEventHandler EapIssueEventRefresh = null;
        public event FEquipmentIssueEventRefreshEventHandler EquipmentIssueEventRefresh = null;

        // --

        private bool m_disposed = false;
        // --        
        private FIWsmCore m_fWsmCore = null;
        private FAdmContainer m_fAdmContainer = null;
        private FOption m_fOption = null;        
        private FH101 m_fH101 = null;
        private FIDPointer64 m_fFormIdPointer = null;
        // --
        private FOpcLogObjectViewer m_fOpcLogObjectViewer = null;
        // --
        private FSecsLogFilter m_fSecsLogFilter = null;
        private FOpcLogFilter m_fOpcLogFilter = null;
        private FTcpLogFilter m_fTcpLogFilter = null;
        //private FPlcLogFilter m_fPlcLogFilter = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FAdmCore(
            FIWsmCore fWsmCore,
            FAdmContainer fAdmContainer
            )
        {
            m_fWsmCore = fWsmCore;
            m_fAdmContainer = fAdmContainer;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FAdmCore(
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
                    m_fAdmContainer = null;
                    m_fWsmCore = null;                    
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

        public FOption fOption
        {
            get
            {
                try
                {
                    return m_fOption;
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

        public FIWsmCore fWsmCore
        {
            get
            {
                try
                {
                    return m_fWsmCore;
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

        public FIWsmOption fWsmOption
        {
            get
            {
                try
                {
                    return m_fWsmCore.fWsmOption;
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

        public FUIWizard fUIWizard
        {
            get
            {
                try
                {
                    return m_fWsmCore.fUIWizard;
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

        public FAdmContainer fAdmContainer
        {
            get
            {
                try
                {
                    return m_fAdmContainer;
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

        public FOpcLogObjectViewer fOpcLogObjectViewer
        {
            get
            {
                try
                {
                    return m_fOpcLogObjectViewer;
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

            set
            {
                try
                {
                    m_fOpcLogObjectViewer = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public UInt64 formUniqueId
        {
            get
            {
                try
                {
                    return m_fFormIdPointer.uniqueId;
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

        public FH101 fH101
        {
            get
            {
                try
                {
                    return m_fH101;
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

        public FSecsLogFilter fSecsLogFilter
        {
            get
            {
                try
                {
                    return m_fSecsLogFilter;
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

        public FOpcLogFilter fOpcLogFilter
        {
            get
            {
                try
                {
                    return m_fOpcLogFilter;
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

        public FTcpLogFilter fTcpLogFilter
        {
            get
            {
                try
                {
                    return m_fTcpLogFilter;
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

        //public FPlcLogFilter fPlcLogFilter
        //{
        //    get
        //    {
        //        try
        //        {
        //            return m_fPlcLogFilter;
        //        }
        //        catch (Exception ex)
        //        {
        //            FDebug.throwException(ex);
        //        }
        //        finally
        //        {

        //        }
        //        return null;
        //    }
        //}

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void validateLicense(
            )
        {
            // ***
            // New License File 적용
            // *** 
            FLic2License fLic = null;
            FLic2Info fLicInfo = null;

            try
            {
                fLic = new FLic2License();
                fLicInfo = fLic.validate(m_fWsmCore.licenseFileName);

                // --

                // ***
                // Product 허가 여부 체크
                // ***
                if (fLicInfo.fLicAdm.productEnabled == FYesNo.No)
                {
                    fLic.rasieValidationError("product.enabled");
                }

                // --

                // ***
                // Network Deployed (ClickOnce or Standalone) 여부 체크
                // ***
#if (DEBUG)
                if (fLicInfo.fLicAdm.networkDeployed == FYesNo.Yes && !System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    fLic.rasieValidationError("network.deployed");
                }
#endif
                if (fLicInfo.fLicAdm.networkDeployed == FYesNo.No && System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    fLic.rasieValidationError("network.deployed");
                }

                // --

                // ***
                // 사용기간 체크
                // ***
                if (fLicInfo.fLicAdm.expireIssuedCheck == FYesNo.Yes && !fLic.validateExpireIssueDate(fLicInfo.fLicAdm.expireIssuedDate))
                {
                    fLic.rasieValidationError("expire.issued.date");
                }

                // ---

                // ***
                // Mac Address 체크
                // ***
                if (fLicInfo.fLicAdm.macAddresscheck == FYesNo.Yes && !fLic.validateMacAddress(fLicInfo.fLicAdm.macAddress))
                {
                    fLic.rasieValidationError("mac.address");
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fLic != null)
                {
                    fLic.Dispose();
                    fLic = null;
                }

                if (fLicInfo != null)
                {
                    fLicInfo.Dispose();
                    fLicInfo = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void init(
            )
        {
            try
            {
                validateLicense();

                // --

                m_fOption = new FOption(this);

                // --

                m_fFormIdPointer = new FIDPointer64();

                // --

                m_fSecsLogFilter = new FSecsLogFilter();
                m_fOpcLogFilter = new FOpcLogFilter();
                m_fTcpLogFilter = new FTcpLogFilter();
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
                termH101();

                // --

                if (m_fSecsLogFilter != null)
                {
                    m_fSecsLogFilter.Dispose();
                    m_fSecsLogFilter = null;
                }

                if (m_fOpcLogFilter != null)
                {
                    m_fOpcLogFilter.Dispose();
                    m_fOpcLogFilter = null;
                }

                if (m_fTcpLogFilter != null)
                {
                    m_fTcpLogFilter.Dispose();
                    m_fTcpLogFilter = null;
                }

                //if (m_fPlcLogFilter != null)
                //{
                //    m_fPlcLogFilter.Dispose();
                //    m_fPlcLogFilter = null;
                //}

                // --

                if (m_fFormIdPointer != null)
                {
                    m_fFormIdPointer.Dispose();
                    m_fFormIdPointer = null;
                }

                // --

                if (m_fOpcLogObjectViewer != null && !m_fOpcLogObjectViewer.IsDisposed)
                {
                    m_fOpcLogObjectViewer.Close();
                    m_fOpcLogObjectViewer.Dispose();
                    m_fOpcLogObjectViewer = null;
                }

                // --

                if (m_fOption != null)
                {
                    m_fOption.save();
                    // --
                    m_fOption.Dispose();
                    m_fOption = null;
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

        public void initH101(
            )
        {
            try
            {
                termH101();

                // --

                m_fH101 = new FH101(
                    FConstants.StationSessionID, 
                    fOption.stationConnectString, 
                    FConstants.StationVersion,
                    fOption.stationTimeout,
                    FConstants.GuaranteedTimeout,
                    true,
                    false
                    );
                m_fH101.init(FH101StationMode.Inter);
                // --
                FADMADSCaster.admadsChannel = m_fOption.castChannelId;
                FADMADSCaster.admadsTtl = m_fOption.stationTimeout;
                // --
                m_fH101.registerDispatcher("ADMADS", new FADMADSCallback(this));
                // --
                m_fH101.tune(m_fOption.tuneChannelId + "/" + m_fOption.factory, true, false);
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

        public void termH101(
            )
        {
            try
            {
                if (m_fH101 == null)
                {
                    return;
                }                

                // --

                if (m_fH101.started)
                {
                    m_fH101.untune(m_fOption.tuneChannelId + "/" + m_fOption.factory, true, false);
                }
                // --
                m_fH101.term();
                m_fH101.Dispose();
                m_fH101 = null;
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

        public void changeSecsLogFilter(
            FSecsLogFilter fSecsLogFilter
            )
        {
            try
            {
                if (m_fSecsLogFilter != null)
                {
                    m_fSecsLogFilter.Dispose();
                    m_fSecsLogFilter = null;
                }
                // --
                m_fSecsLogFilter = new FSecsLogFilter(fSecsLogFilter);
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

        public void changeOpcLogFilter(
            FOpcLogFilter fOpcLogFilter
            )
        {
            try
            {
                if (m_fOpcLogFilter != null)
                {
                    m_fOpcLogFilter.Dispose();
                    m_fOpcLogFilter = null;
                }
                // --
                m_fOpcLogFilter = new FOpcLogFilter(fOpcLogFilter);
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

        public void changeTcpLogFilter(
            FTcpLogFilter fTcpLogFilter
            )
        {
            try
            {
                if (m_fTcpLogFilter != null)
                {
                    m_fTcpLogFilter.Dispose();
                    m_fTcpLogFilter = null;
                }
                // --
                m_fTcpLogFilter = new FTcpLogFilter(fTcpLogFilter);
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

        //public void changePlcLogFilter(
        //    FPlcLogFilter fPlcLogFilter
        //    )
        //{
        //    try
        //    {
        //        if (m_fPlcLogFilter != null)
        //        {
        //            m_fPlcLogFilter.Dispose();
        //            m_fPlcLogFilter = null;
        //        }
        //        // --
        //        m_fPlcLogFilter = new FPlcLogFilter(fPlcLogFilter);
        //    }
        //    catch (Exception ex)
        //    {
        //        FDebug.throwException(ex);
        //    }
        //    finally
        //    {

        //    }
        //}

        //------------------------------------------------------------------------------------------------------------------------

        public void onMonitoringServerDataReceived(
            FMonitoringServerDataReceivedEventArgs e
            )
        {
            try
            {
                if (MonitoringServerDataReceived != null)
                {
                    MonitoringServerDataReceived(this, e);
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

        public void onMonitoringPackageDataReceived(
            FMonitoringPackageDataReceivedEventArgs e
            )
        {
            try
            {
                if (MonitoringPackageDataReceived != null)
                {
                    MonitoringPackageDataReceived(this, e);
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

        public void onMonitoringPackageVerDataReceived(
            FMonitoringPackageVerDataReceivedEventArgs e
            )
        {
            try
            {
                if (MonitoringPackageVerDataReceived != null)
                {
                    MonitoringPackageVerDataReceived(this, e);
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

        public void onMonitoringModelDataReceived(
            FMonitoringModelDataReceivedEventArgs e
            )
        {
            try
            {
                if (MonitoringModelDataReceived != null)
                {
                    MonitoringModelDataReceived(this, e);
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

        public void onMonitoringModelVerDataReceived(
            FMonitoringModelVerDataReceivedEventArgs e
            )
        {
            try
            {
                if (MonitoringModelVerDataReceived != null)
                {
                    MonitoringModelVerDataReceived(this, e);
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

        public void onMonitoringComponentDataReceived(
            FMonitoringComponentDataReceivedEventArgs e
            )
        {
            try
            {
                if (MonitoringComponentDataReceived != null)
                {
                    MonitoringComponentDataReceived(this, e);
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

        public void onMonitoringComponentVerDataReceived(
            FMonitoringComponentVerDataReceivedEventArgs e
            )
        {
            try
            {
                if (MonitoringComponentVerDataReceived != null)
                {
                    MonitoringComponentVerDataReceived(this, e);
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

        public void onMonitoringEapDataReceived(
            FMonitoringEapDataReceivedEventArgs e
            )
        {
            try
            {
                if (MonitoringEapDataReceived != null)
                {
                    MonitoringEapDataReceived(this, e);
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

        public void onMonitoringEquipmentTypeDataReceived(
            FMonitoringEquipmentTypeDataReceivedEventArgs e
            )
        {
            try
            {
                if (MonitoringEquipmentTypeDataReceived != null)
                {
                    MonitoringEquipmentTypeDataReceived(this, e);
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

        public void onMonitoringEquipmentAreaDataReceived(
            FMonitoringEquipmentAreaDataReceivedEventArgs e
            )
        {
            try
            {
                if (MonitoringEquipmentAreaDataReceived != null)
                {
                    MonitoringEquipmentAreaDataReceived(this, e);
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

        public void onMonitoringEquipmentLineDataReceived(
            FMonitoringEquipmentLineDataReceivedEventArgs e
            )
        {
            try
            {
                if (MonitoringEquipmentLineDataReceived != null)
                {
                    MonitoringEquipmentLineDataReceived(this, e);
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

        public void onMonitoringEquipmentDataReceived(
            FMonitoringEquipmentDataReceivedEventArgs e
            )
        {
            try
            {
                if (MonitoringEquipmentDataReceived != null)
                {
                    MonitoringEquipmentDataReceived(this, e);
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

        public void onMonitoringDeviceDataReceived(
            FMonitoringDeviceDataReceivedEventArgs e
            )
        {
            try
            {
                if (MonitoringDeviceDataReceived != null)
                {
                    MonitoringDeviceDataReceived(this, e);
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

        public void onMonitoringSecs1ToHsmsConverterDataReceived(
            FMonitoringSecs1ToHsmsConverterDataReceivedEventArgs e
            )
        {
            try
            {
                if (MonitoringSecs1ToHsmsConverterDataReceived != null)
                {
                    MonitoringSecs1ToHsmsConverterDataReceived(this, e);
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

        public void onMonitoringSecs1ToHsmsConverterDisconnectDataReceived(
            FMonitoringSecs1ToHsmsConverterDisconnectDataReceivedEventArgs e
            )
        {
            try
            {
                if (MonitoringSecs1ToHsmsConverterDisconnectDataReceived != null)
                {
                    MonitoringSecs1ToHsmsConverterDisconnectDataReceived(this, e);
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

        public void onServerIssueEventRefresh(
            EventArgs e
            )
        {
            try
            {
                if (ServerIssueEventRefresh != null)
                {
                    ServerIssueEventRefresh(this, e);
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

        public void onEapIssueEventRefresh(
            EventArgs e
            )
        {
            try
            {
                if (EapIssueEventRefresh != null)
                {
                    EapIssueEventRefresh(this, e);
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

        public void onEquipmentIssueEventRefresh(
            EventArgs e
            )
        {
            try
            {
                if (EquipmentIssueEventRefresh != null)
                {
                    EquipmentIssueEventRefresh(this, e);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
