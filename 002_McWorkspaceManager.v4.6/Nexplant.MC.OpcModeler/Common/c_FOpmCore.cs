/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPlmCore.cs
--  Creator         : mjkim
--  Create Date     : 2012.10.25
--  Description     : FAMate OPC Modeler Core Class 
--  History         : Created by mjkim at 2012.10.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.OpcModeler
{
    public class FOpmCore : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        public event FModelingFileModifiedEventHandler ModelingFileModified = null;

        // --
        private bool m_disposed = false;
        // --
        private FIWsmCore m_fWsmCore = null;
        private FOpmContainer m_fOpmContainer = null;
        private FOpcDriver m_fStandardOpcLibrary = null;
        // --
        private FOpmFileInfo m_fOpmFileInfo = null;
        private FOption m_fOption = null;    
        private FIDPointer64 m_fFormIdPointer = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOpmCore(
            FIWsmCore fWsmCore,
            FOpmContainer fOpmContainer
            )
        {
            m_fWsmCore = fWsmCore;
            m_fOpmContainer = fOpmContainer;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Library Clone 전용
        // ***
        public FOpmCore(
            FIWsmCore fWsmCore,
            FOpmContainer fOpmContainer,
            FOpcDriver fOpcDriver
            )
        {
            m_fWsmCore = fWsmCore;
            m_fOpmContainer = fOpmContainer;
            // --
            init(fOpcDriver);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOpmCore(
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
                    m_fOpmContainer = null;
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

        public FOpmContainer fOpmContainer
        {
            get
            {
                try
                {
                    return m_fOpmContainer;
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

        public FOpmFileInfo fOpmFileInfo
        {
            get
            {
                try
                {
                    return m_fOpmFileInfo;
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

        public FOpcDriver standardOpcLibrary
        {
            get
            {
                try
                {
                    if (m_fStandardOpcLibrary == null)
                    {
                        m_fStandardOpcLibrary = new FOpcDriver(m_fWsmCore.appPath + "\\License\\license.lic", FOpcRunMode.WorkspaceManager);
                        m_fStandardOpcLibrary.openModelingFile(m_fWsmCore.appPath + "\\Library\\NexplantMcStandardOpcLibrary.osm");
                    }
                    return m_fStandardOpcLibrary;
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
                if (fLicInfo.fLicOpc.productEnabled == FYesNo.No)
                {
                    fLic.rasieValidationError("product.enabled");
                }

                // --

                // ***
                // Network Deployed (ClickOnce or Standalone) 여부 체크
                // ***
                if (fLicInfo.fLicOpc.networkDeployed == FYesNo.Yes && !System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    fLic.rasieValidationError("network.deployed");
                }
                if (fLicInfo.fLicOpc.networkDeployed == FYesNo.No && System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    fLic.rasieValidationError("network.deployed");
                }

                // --

                // ***
                // 사용기간 체크
                // ***
                if (fLicInfo.fLicOpc.expireIssuedCheck == FYesNo.Yes && !fLic.validateExpireIssueDate(fLicInfo.fLicOpc.expireIssuedDate))
                {
                    fLic.rasieValidationError("expire.issued.date");
                }

                // ---

                // ***
                // Mac Address 체크
                // ***
                if (fLicInfo.fLicOpc.macAddresscheck == FYesNo.Yes && !fLic.validateMacAddress(fLicInfo.fLicOpc.macAddress))
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

                m_fOpmFileInfo = new FOpmFileInfo(this);
                m_fOpmFileInfo.ModelingFileModlfied += new FModelingFileModifiedEventHandler(m_fOpmFileInfo_ModelingFileModlfied);                
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
            FOpcDriver fOpcDriver
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

                m_fOpmFileInfo = new FOpmFileInfo(this, fOpcDriver);
                m_fOpmFileInfo.ModelingFileModlfied += new FModelingFileModifiedEventHandler(m_fOpmFileInfo_ModelingFileModlfied);
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
                if (m_fOpmFileInfo != null)
                {
                    m_fOpmFileInfo.ModelingFileModlfied -= new FModelingFileModifiedEventHandler(m_fOpmFileInfo_ModelingFileModlfied);
                    // --
                    m_fOpmFileInfo.Dispose();
                    m_fOpmFileInfo = null;
                }

                // --

                if (m_fStandardOpcLibrary != null)
                {
                    m_fStandardOpcLibrary.Dispose();
                    m_fStandardOpcLibrary = null;
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

        #region m_fOpmFileInfo Object Event Handler

        private void m_fOpmFileInfo_ModelingFileModlfied(
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
