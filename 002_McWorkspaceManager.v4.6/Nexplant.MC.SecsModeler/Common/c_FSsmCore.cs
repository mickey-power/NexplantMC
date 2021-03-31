/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSsmCore.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.27
--  Description     : FAMate SECS Modeler Core Class 
--  History         : Created by spike.lee at 2011.01.27
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.SecsModeler
{
    public class FSsmCore : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FModelingFileModifiedEventHandler ModelingFileModified = null;

        // --

        private bool m_disposed = false;
        // --        
        private FIWsmCore m_fWsmCore = null;
        private FSsmContainer m_fSsmContainer = null;
        private FSecsDriver m_fStandardSecsLibrary = null;
        // --
        private FSsmFileInfo m_fSsmFileInfo = null;
        private FOption m_fOption = null;
        private FIDPointer64 m_fFormIdPointer = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSsmCore(
            FIWsmCore fWsmCore,
            FSsmContainer fSsmContainer
            )
        {
            m_fWsmCore = fWsmCore;
            m_fSsmContainer = fSsmContainer;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Library Clone 전용
        // ***
        public FSsmCore(
            FIWsmCore fWsmCore,
            FSsmContainer fSsmContainer,
            FSecsDriver fSecsDriver
            )
        {
            m_fWsmCore = fWsmCore;
            m_fSsmContainer = fSsmContainer;
            // --
            init(fSecsDriver);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSsmCore(
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
                    m_fSsmContainer = null;
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

        public FSsmContainer fSsmContainer
        {
            get
            {
                try
                {
                    return m_fSsmContainer;
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

        public FSsmFileInfo fSsmFileInfo
        {
            get
            {
                try
                {
                    return m_fSsmFileInfo;
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
        
        public FSecsDriver standardSecsLibrary
        {
            get
            {
                try
                {
                    if (m_fStandardSecsLibrary == null)
                    {
                        m_fStandardSecsLibrary = new FSecsDriver(m_fWsmCore.appPath + "\\License\\license.lic");
                        m_fStandardSecsLibrary.openModelingFile(m_fWsmCore.appPath + "\\Library\\NexplantMcStandardSecsLibrary.ssm");
                    }
                    return m_fStandardSecsLibrary;
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
                if (fLicInfo.fLicSecs.productEnabled == FYesNo.No)
                {
                    fLic.rasieValidationError("product.enabled");
                }

                // --

                // ***
                // Network Deployed (ClickOnce or Standalone) 여부 체크
                // ***
#if (!DEBUG)
                if (fLicInfo.fLicSecs.networkDeployed == FYesNo.Yes && !System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    fLic.rasieValidationError("network.deployed");
                }
                if (fLicInfo.fLicSecs.networkDeployed == FYesNo.No && System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    fLic.rasieValidationError("network.deployed");
                }

#endif

                // --

                // ***
                // 사용기간 체크
                // ***
                if (fLicInfo.fLicSecs.expireIssuedCheck == FYesNo.Yes && !fLic.validateExpireIssueDate(fLicInfo.fLicSecs.expireIssuedDate))
                {
                    fLic.rasieValidationError("expire.issued.date");
                }

                // ---

                // ***
                // Mac Address 체크
                // ***
                if (fLicInfo.fLicSecs.macAddresscheck == FYesNo.Yes && !fLic.validateMacAddress(fLicInfo.fLicSecs.macAddress))
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
                
                m_fSsmFileInfo = new FSsmFileInfo(this);
                m_fSsmFileInfo.ModelingFileModlfied += new FModelingFileModifiedEventHandler(m_fSsmFileInfo_ModelingFileModlfied);                
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
            FSecsDriver fSecsDriver
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

                m_fSsmFileInfo = new FSsmFileInfo(this, fSecsDriver);
                m_fSsmFileInfo.ModelingFileModlfied += new FModelingFileModifiedEventHandler(m_fSsmFileInfo_ModelingFileModlfied);
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
                if (m_fSsmFileInfo != null)
                {
                    m_fSsmFileInfo.ModelingFileModlfied -= new FModelingFileModifiedEventHandler(m_fSsmFileInfo_ModelingFileModlfied);
                    // --
                    m_fSsmFileInfo.Dispose();
                    m_fSsmFileInfo = null;
                }

                // --

                if (m_fStandardSecsLibrary != null)
                {
                    m_fStandardSecsLibrary.Dispose();
                    m_fStandardSecsLibrary = null;
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

        #region m_fSsmFileInfo Object Event Handler

        private void m_fSsmFileInfo_ModelingFileModlfied(
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
