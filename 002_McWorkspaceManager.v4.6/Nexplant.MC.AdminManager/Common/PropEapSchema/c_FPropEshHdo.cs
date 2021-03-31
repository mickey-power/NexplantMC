/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_fPropHdo.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2012.04.16
--  Description     : FAMate Host Driver for Admin System Option PropertySource Class
--  History         : Created by byungyun.jeon at 2012.04.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using Nexplant.MC.Adminmanager;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public class FPropHdo : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryStation = "[01] Station";
        private const string CategoryChannel = "[02] Channel";

        // --

        private bool m_disposed = false;
        // --
        private FXmlNode m_fXmlNodeHdo = null;
        private bool m_readOnly = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropHdo(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FXmlNode fXmlNodeHdo,
            bool readOnly
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {

            m_fXmlNodeHdo = fXmlNodeHdo;
            m_readOnly = readOnly;
            // --
            init();
        }       

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropHdo(
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
                    //--
                    m_fXmlNodeHdo = null;
                }
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
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
                    return m_fXmlNodeHdo.get_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_StationConnectString,
                            FFileDriver.FHostDevice.FHostOption.D_StationConnectString
                            );
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
                    m_fXmlNodeHdo.set_elemVal(
                        FFileDriver.FHostDevice.FHostOption.A_StationConnectString,
                        FFileDriver.FHostDevice.FHostOption.D_StationConnectString,
                        value
                        );
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
        public string StationVersion
        {
            get
            {
                try
                {
                    return m_fXmlNodeHdo.get_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_StationVersion,
                            FFileDriver.FHostDevice.FHostOption.D_StationVersion
                            );
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
                    m_fXmlNodeHdo.set_elemVal(
                             FFileDriver.FHostDevice.FHostOption.A_StationVersion,
                             FFileDriver.FHostDevice.FHostOption.D_StationVersion,
                             value
                             );
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
                    return int.Parse(m_fXmlNodeHdo.get_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_StationTimeOut,
                            FFileDriver.FHostDevice.FHostOption.D_StationTimeOut
                            ));
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
                    m_fXmlNodeHdo.set_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_StationTimeOut,
                            FFileDriver.FHostDevice.FHostOption.D_StationTimeOut,
                            value.ToString());
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
        public int GuaranteedTimeout
        {
            get
            {
                try
                {
                    return int.Parse(m_fXmlNodeHdo.get_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_GuaranteedtimeOut,
                            FFileDriver.FHostDevice.FHostOption.D_GuaranteedtimeOut
                            ));
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
                    m_fXmlNodeHdo.set_elemVal(
                        FFileDriver.FHostDevice.FHostOption.A_GuaranteedtimeOut,
                        FFileDriver.FHostDevice.FHostOption.D_GuaranteedtimeOut,
                        value.ToString()
                        );
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryStation)]
        public int MaxSpooling
        {
            get
            {
                try
                {
                    return int.Parse(m_fXmlNodeHdo.get_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_GuaranteedtimeOut,
                            FFileDriver.FHostDevice.FHostOption.D_GuaranteedtimeOut
                            ));
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
                    m_fXmlNodeHdo.set_elemVal(
                        FFileDriver.FHostDevice.FHostOption.A_GuaranteedtimeOut,
                        FFileDriver.FHostDevice.FHostOption.D_GuaranteedtimeOut,
                        value.ToString()
                        );
                        
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region ADM Service Channel

        [Category(CategoryChannel)]
        public int SessionId
        {
            get
            {
                try
                {
                    return int.Parse(m_fXmlNodeHdo.get_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_SessionId,
                            FFileDriver.FHostDevice.FHostOption.D_SessionId
                            ));
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
                    m_fXmlNodeHdo.set_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_SessionId,
                            FFileDriver.FHostDevice.FHostOption.D_SessionId,
                            value.ToString()
                            );
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

        [Category(CategoryChannel)]
        public string ModuleName
        {
            get
            {
                try
                {
                    return m_fXmlNodeHdo.get_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_ModuleName,
                            FFileDriver.FHostDevice.FHostOption.D_ModuleName
                            );
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
                    m_fXmlNodeHdo.set_elemVal(
                             FFileDriver.FHostDevice.FHostOption.A_ModuleName,
                             FFileDriver.FHostDevice.FHostOption.D_ModuleName,
                             value
                             );
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

        [Category(CategoryChannel)]
        public string TuneChannel
        {
            get
            {
                try
                {
                    return m_fXmlNodeHdo.get_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_TuneChannel,
                            FFileDriver.FHostDevice.FHostOption.D_TuneChannel
                            );
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
                    m_fXmlNodeHdo.set_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_TuneChannel,
                            FFileDriver.FHostDevice.FHostOption.D_TuneChannel,
                            value
                            );
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

        [Category(CategoryChannel)]
        public string CastChannel
        {
            get
            {
                try
                {
                    return m_fXmlNodeHdo.get_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_CastChannel,
                            FFileDriver.FHostDevice.FHostOption.D_CastChannel
                            );
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
                    m_fXmlNodeHdo.set_elemVal(
                             FFileDriver.FHostDevice.FHostOption.A_CastChannel,
                             FFileDriver.FHostDevice.FHostOption.D_CastChannel,
                             value
                             );
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

        public void init(
            )
        {
            try
            {
                base.fTypeDescriptor.properties["StationConnectString"].attributes.replace(new DisplayNameAttribute("Connect String"));
                base.fTypeDescriptor.properties["StationVersion"].attributes.replace(new DisplayNameAttribute("Version"));
                base.fTypeDescriptor.properties["StationTimeout"].attributes.replace(new DisplayNameAttribute("Timeout"));
                base.fTypeDescriptor.properties["GuaranteedTimeout"].attributes.replace(new DisplayNameAttribute("Guaranteed Timeout"));
                base.fTypeDescriptor.properties["MaxSpooling"].attributes.replace(new DisplayNameAttribute("Max Spooling"));
                // --
                base.fTypeDescriptor.properties["SessionId"].attributes.replace(new DisplayNameAttribute("Session ID"));
                base.fTypeDescriptor.properties["ModuleName"].attributes.replace(new DisplayNameAttribute("Module Name"));
                base.fTypeDescriptor.properties["TuneChannel"].attributes.replace(new DisplayNameAttribute("Tune Channel"));
                base.fTypeDescriptor.properties["CastChannel"].attributes.replace(new DisplayNameAttribute("Cast Channel"));

                // --

                base.fTypeDescriptor.properties["StationConnectString"].attributes.replace(new DefaultValueAttribute(this.StationConnectString));
                base.fTypeDescriptor.properties["StationVersion"].attributes.replace(new DefaultValueAttribute(this.StationVersion));
                base.fTypeDescriptor.properties["StationTimeout"].attributes.replace(new DefaultValueAttribute(this.StationTimeout));
                base.fTypeDescriptor.properties["GuaranteedTimeout"].attributes.replace(new DefaultValueAttribute(this.GuaranteedTimeout));
                base.fTypeDescriptor.properties["MaxSpooling"].attributes.replace(new DefaultValueAttribute(this.MaxSpooling));
                // --
                base.fTypeDescriptor.properties["SessionId"].attributes.replace(new DefaultValueAttribute(this.SessionId));
                base.fTypeDescriptor.properties["ModuleName"].attributes.replace(new DefaultValueAttribute(this.ModuleName));
                base.fTypeDescriptor.properties["TuneChannel"].attributes.replace(new DefaultValueAttribute(this.TuneChannel));
                base.fTypeDescriptor.properties["CastChannel"].attributes.replace(new DefaultValueAttribute(this.CastChannel));

                // -- 

                if (m_readOnly)
                {
                    base.fTypeDescriptor.properties["StationConnectString"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["StationVersion"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["StationTimeout"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["GuaranteedTimeout"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["MaxSpooling"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["SessionId"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["ModuleName"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["TuneChannel"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["CastChannel"].attributes.replace(new ReadOnlyAttribute(true));
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

        private void term(
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end