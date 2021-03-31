/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropWsmOption.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2014.08.11
--  Description     : FAMate Workspace Manager User Log In Option Property Source Object Class 
--  History         : Created by jungyoul.moon at 2014.08.11
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
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.WorkspaceManager
{
    public class FPropWsmOption : FDynPropCusBase<FWsmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryStation = "[02] Station";
        private const string CategoryChannelId = "[03] Channel ID";

        // --

        private bool m_disposed = false;      
        // --
        private bool m_tranEnabled = false;
        // --
        private FWsmSiteOption m_source = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropWsmOption(
            FWsmCore fWsmCore,
            FDynPropGrid fPropGrid,
            FWsmSiteOption source,
            bool tranEnabled
            )
            : base(fWsmCore, fWsmCore.fUIWizard, fPropGrid)
        {
            m_source = source;
            m_tranEnabled = tranEnabled;
            // --
            init();   
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropWsmOption(
            FWsmCore fWsmCore,
            FDynPropGrid fPropGrid,
            FWsmSiteOption source
            )
            : this(fWsmCore, fPropGrid, source, true)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropWsmOption(
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

                }                
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region General

        [Category(CategoryGeneral)]
        public string Site
        {
            get
            {
                try
                {
                    return m_source.site;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.site = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        public string Factory
        {
            get
            {
                try
                {
                    return m_source.factory;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.factory = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        public string Description
        {
            get
            {
                try
                {
                    return m_source.description;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.description = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
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
                    return m_source.stationConnectString;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.stationConnectString = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.stationTimeout = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Channel ID

        [Category(CategoryChannelId)]
        public string TuneChannelId
        {
            get
            {
                try
                {
                    return m_source.tuneChannelId;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.tuneChannelId = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryChannelId)]
        public string CastChannelId
        {
            get
            {
                try
                {
                    return m_source.castChannelId;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.castChannelId = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        [Browsable(false)]
        public FWsmSiteOption source
        {
            get
            {
                try
                {
                    return m_source;
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
                base.fTypeDescriptor.properties["Site"].attributes.replace(new DisplayNameAttribute("Site"));
                base.fTypeDescriptor.properties["Factory"].attributes.replace(new DisplayNameAttribute("Factory"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                // --
                base.fTypeDescriptor.properties["StationConnectString"].attributes.replace(new DisplayNameAttribute("Connect String"));
                base.fTypeDescriptor.properties["StationTimeout"].attributes.replace(new DisplayNameAttribute("Timeout (ms)"));
                // --
                base.fTypeDescriptor.properties["TuneChannelId"].attributes.replace(new DisplayNameAttribute("Tune"));
                base.fTypeDescriptor.properties["CastChannelId"].attributes.replace(new DisplayNameAttribute("Cast"));
                
                // --

                base.fTypeDescriptor.properties["Site"].attributes.replace(new DefaultValueAttribute(m_source.site));
                base.fTypeDescriptor.properties["Factory"].attributes.replace(new DefaultValueAttribute(m_source.factory));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_source.description));
                // --
                base.fTypeDescriptor.properties["StationConnectString"].attributes.replace(new DefaultValueAttribute(m_source.stationConnectString));
                base.fTypeDescriptor.properties["StationTimeout"].attributes.replace(new DefaultValueAttribute(m_source.stationTimeout));
                // --
                base.fTypeDescriptor.properties["TuneChannelId"].attributes.replace(new DefaultValueAttribute(m_source.tuneChannelId));
                base.fTypeDescriptor.properties["CastChannelId"].attributes.replace(new DefaultValueAttribute(m_source.castChannelId));

                // --

                if (!m_tranEnabled)
                {
                    base.fTypeDescriptor.properties["Site"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Factory"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Description"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["StationConnectString"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["StationTimeout"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["TuneChannelId"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["CastChannelId"].attributes.replace(new ReadOnlyAttribute(true));
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
