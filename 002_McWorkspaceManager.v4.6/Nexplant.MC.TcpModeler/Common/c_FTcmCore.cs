/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcmCore.cs
--  Creator         : mjkim
--  Create Date     : 2012.10.25
--  Description     : FAMate TCP Modeler Core Class 
--  History         : Created by mjkim at 2012.10.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.TcpModeler
{
    public class FTcmCore : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        public event FModelingFileModifiedEventHandler ModelingFileModified = null;

        // --
        private bool m_disposed = false;
        // --
        private FIWsmCore m_fWsmCore = null;
        private FTcmContainer m_fTcmContainer = null;
        private FTcpDriver m_fStandardTcpLibrary = null;
        // --
        private FTcmFileInfo m_fTcmFileInfo = null;
        private FOption m_fOption = null;    
        private FIDPointer64 m_fFormIdPointer = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcmCore(
            FIWsmCore fWsmCore,
            FTcmContainer fTcmContainer
            )
        {
            m_fWsmCore = fWsmCore;
            m_fTcmContainer = fTcmContainer;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Library Clone 전용
        // ***
        public FTcmCore(
            FIWsmCore fWsmCore,
            FTcmContainer fTcmContainer,
            FTcpDriver fTcpDriver
            )
        {
            m_fWsmCore = fWsmCore;
            m_fTcmContainer = fTcmContainer;
            // --
            init(fTcpDriver);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcmCore(
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
                    m_fTcmContainer = null;
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

        public FTcmContainer fTcmContainer
        {
            get
            {
                try
                {
                    return m_fTcmContainer;
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

        public FTcmFileInfo fTcmFileInfo
        {
            get
            {
                try
                {
                    return m_fTcmFileInfo;
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

        public FTcpDriver standardTcpLibrary
        {
            get
            {
                try
                {
                    if (m_fStandardTcpLibrary == null)
                    {
                        m_fStandardTcpLibrary = new FTcpDriver(m_fWsmCore.appPath + "\\License\\license.lic");
                        m_fStandardTcpLibrary.openModelingFile(m_fWsmCore.appPath + "\\Library\\FAmateStandardTcpLibrary.tsm");
                    }
                    return m_fStandardTcpLibrary;
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
                if (fLicInfo.fLicTcp.productEnabled == FYesNo.No)
                {
                    fLic.rasieValidationError("product.enabled");
                }

                // --

                // ***
                // Network Deployed (ClickOnce or Standalone) 여부 체크
                // ***
                if (fLicInfo.fLicTcp.networkDeployed == FYesNo.Yes && !System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    fLic.rasieValidationError("network.deployed");
                }
                if (fLicInfo.fLicTcp.networkDeployed == FYesNo.No && System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    fLic.rasieValidationError("network.deployed");
                }

                // --

                // ***
                // 사용기간 체크
                // ***
                if (fLicInfo.fLicTcp.expireIssuedCheck == FYesNo.Yes && !fLic.validateExpireIssueDate(fLicInfo.fLicTcp.expireIssuedDate))
                {
                    fLic.rasieValidationError("expire.issued.date");
                }

                // ---

                // ***
                // Mac Address 체크
                // ***
                if (fLicInfo.fLicTcp.macAddresscheck == FYesNo.Yes && !fLic.validateMacAddress(fLicInfo.fLicTcp.macAddress))
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

                m_fTcmFileInfo = new FTcmFileInfo(this);
                m_fTcmFileInfo.ModelingFileModlfied += new FModelingFileModifiedEventHandler(m_fTcmFileInfo_ModelingFileModlfied);                
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
        // Library Clone 전용
        // ***
        private void init(
            FTcpDriver fTcpDriver
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

                m_fTcmFileInfo = new FTcmFileInfo(this, fTcpDriver);
                m_fTcmFileInfo.ModelingFileModlfied += new FModelingFileModifiedEventHandler(m_fTcmFileInfo_ModelingFileModlfied);
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
                if (m_fTcmFileInfo != null)
                {
                    m_fTcmFileInfo.ModelingFileModlfied -= new FModelingFileModifiedEventHandler(m_fTcmFileInfo_ModelingFileModlfied);
                    // --
                    m_fTcmFileInfo.Dispose();
                    m_fTcmFileInfo = null;
                }

                // --

                if (m_fStandardTcpLibrary != null)
                {
                    m_fStandardTcpLibrary.Dispose();
                    m_fStandardTcpLibrary = null;
                }

                // --

                if (m_fFormIdPointer != null)
                {
                    m_fFormIdPointer.Dispose();
                    m_fFormIdPointer = null;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fTcmFileInfo Object Event Handler

        private void m_fTcmFileInfo_ModelingFileModlfied(
            object sender,
            FModelingFileModifiedEventArgs e
            )
        {
            try
            {
                if (ModelingFileModified != null)
                {
                    ModelingFileModified(this, e);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
