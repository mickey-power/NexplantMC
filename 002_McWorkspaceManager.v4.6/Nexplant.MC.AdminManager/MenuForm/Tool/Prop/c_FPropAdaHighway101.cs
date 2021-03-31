/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAdaHighway101.cs
--  Creator         : baehyun.seo
--  Create Date     : 2012.12.21
--  Description     : FAMate Admin Manager Admin Agent Option Highway101 Source Object Class 
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
    public class FPropAdaHighway101 : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryStation = "[01] Station";
        private const string CategoryAdminServiceChannel = "[02] Admin Service Channel";

        // --

        private bool m_disposed = false;
        private FADAOption m_source = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropAdaHighway101(
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

        ~FPropAdaHighway101(
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

        #region Station

        [Category(CategoryStation)]
        public string StationConnectString
        {
            get
            {
                try
                {
                    return m_source.stationConnectString;
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
                    if (value.Trim() == string.Empty)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { "Value" }));
                    }

                    // --

                    m_source.stationConnectString = value;
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

        [Category(CategoryStation)]
        public int StationTimeout
        {
            get
            {
                try
                {
                    return m_source.stationTimeout;
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
                    if (value < 1000)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Value" }));
                    }

                    // --

                    m_source.stationTimeout = value;
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

        #region Admin Manager Channel

        [Category(CategoryAdminServiceChannel)]
        public string AdmTuneChannel
        {
            get
            {
                try
                {
                    return m_source.adsTuneChannel;
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
                    if (value.Trim() == string.Empty)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { "Value" }));
                    }

                    // --

                    m_source.adsTuneChannel = value;
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

        [Category(CategoryAdminServiceChannel)]
        public string AdmCastChannel
        {
            get
            {
                try
                {
                    return m_source.adsCastChannel;
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
                    if (value.Trim() == string.Empty)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { "Value" }));
                    }

                    // --

                    m_source.adsCastChannel = value;
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
                base.fTypeDescriptor.properties["StationConnectString"].attributes.replace(new DisplayNameAttribute("Station Connect String"));
                base.fTypeDescriptor.properties["StationTimeout"].attributes.replace(new DisplayNameAttribute("Timeout (ms)"));            
                // --
                base.fTypeDescriptor.properties["AdmTuneChannel"].attributes.replace(new DisplayNameAttribute("Tune Channel"));
                base.fTypeDescriptor.properties["AdmCastChannel"].attributes.replace(new DisplayNameAttribute("Cast Channel"));

                // --

                base.fTypeDescriptor.properties["StationConnectString"].attributes.replace(new DefaultValueAttribute(this.StationConnectString));
                base.fTypeDescriptor.properties["StationTimeout"].attributes.replace(new DefaultValueAttribute(this.StationTimeout));
                // --
                base.fTypeDescriptor.properties["AdmTuneChannel"].attributes.replace(new DefaultValueAttribute(this.AdmTuneChannel));
                base.fTypeDescriptor.properties["AdmCastChannel"].attributes.replace(new DefaultValueAttribute(this.AdmCastChannel));
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
