/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropSetupOption.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.29
--  Description     : FAMate Workspace Manager Setup Option Property Source Object Class 
--  History         : Created by spike.lee at 2010.12.29
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.WorkspaceManager
{
    public class FPropSetupOption : FDynPropCusBase<FWsmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryLanguage = "[01] Language";
        private const string CategoryFont = "[02] Font";
        private const string CategoryDebugLog = "[03] Debug Log";
        private const string CategoryApplicationEnabled = "[04] Application Enabled";

        // --

        private bool m_disposed = false;      
        // --
        private FLanguage m_language = FLanguage.Default;
        private string m_fontName = string.Empty;
        private string m_debugLogFileSubfix = string.Empty;
        private int m_debugLogFileKeepingPeriod = 0;
        private FYesNo m_developmentToolEnabled = FYesNo.No;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropSetupOption(
            FWsmCore fWsmCore,
            FDynPropGrid fPropGrid
            )
            : base(fWsmCore, fWsmCore.fUIWizard, fPropGrid)
        {
            init();   
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropSetupOption(
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

        #region Language

        [Category(CategoryLanguage)]
        public FLanguage Language
        {
            get
            {
                try
                {
                    return m_language;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
                return FLanguage.Default;
            }

            set
            {
                try
                {
                    m_language = value;
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

        #region Font

        [Category(CategoryFont)]        
        [TypeConverter(typeof(FontConverter.FontNameConverter)), Editor(typeof(FontNameEditor), typeof(UITypeEditor))] 
        public string FontName
        {
            get
            {
                try
                {
                    return m_fontName;
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
                    m_fontName = (new FontFamily(value)).Name;                    
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                    m_fontName = base.mainObject.fWsmOption.fontName;
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Debug Log

        [Category(CategoryDebugLog)]        
        public string DebugLogFileSubfix
        {
            get
            {
                try
                {
                    return m_debugLogFileSubfix;
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
                    m_debugLogFileSubfix = value;
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

        [Category(CategoryDebugLog)]
        public int DebugLogFileKeepingPeriod
        {
            get
            {
                try
                {
                    return m_debugLogFileKeepingPeriod;
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
                    m_debugLogFileKeepingPeriod = value;
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

        #region Application Enabled

        [Category(CategoryApplicationEnabled)]
        public FYesNo DevelopmentToolEnabled
        {
            get
            {
                try
                {
                    return m_developmentToolEnabled;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
                return FYesNo.No;
            }

            set
            {
                try
                {
                    m_developmentToolEnabled = value;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                m_language = base.mainObject.fOption.language;
                m_fontName = base.mainObject.fOption.fontName;
                m_debugLogFileSubfix = base.mainObject.fOption.debugLogFileSubfix;
                m_debugLogFileKeepingPeriod = base.mainObject.fOption.debugLogFileKeepingPeriod;
                m_developmentToolEnabled = base.mainObject.fOption.developmentToolEnabled;

                // --                

                base.fTypeDescriptor.properties["Language"].attributes.replace(new DisplayNameAttribute("Language"));
                base.fTypeDescriptor.properties["FontName"].attributes.replace(new DisplayNameAttribute("Font Name"));
                base.fTypeDescriptor.properties["DebugLogFileSubfix"].attributes.replace(new DisplayNameAttribute("File Subfix"));
                base.fTypeDescriptor.properties["DebugLogFileKeepingPeriod"].attributes.replace(new DisplayNameAttribute("File Keeping Period (Day)"));
                // --
                base.fTypeDescriptor.properties["DevelopmentToolEnabled"].attributes.replace(new DisplayNameAttribute("Development Tool"));

                // --

                base.fTypeDescriptor.properties["Language"].attributes.replace(new DefaultValueAttribute(m_language));
                base.fTypeDescriptor.properties["FontName"].attributes.replace(new DefaultValueAttribute(m_fontName));
                base.fTypeDescriptor.properties["DebugLogFileSubfix"].attributes.replace(new DefaultValueAttribute(m_debugLogFileSubfix));
                base.fTypeDescriptor.properties["DebugLogFileKeepingPeriod"].attributes.replace(new DefaultValueAttribute(m_debugLogFileKeepingPeriod));
                // --
                base.fTypeDescriptor.properties["DevelopmentToolEnabled"].attributes.replace(new DefaultValueAttribute(m_developmentToolEnabled));
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
