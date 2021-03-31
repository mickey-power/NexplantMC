/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropCaption.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.06
--  Description     : FAMate Language Editor Caption Property Source Object Class 
--  History         : Created by spike.lee at 2011.01.06
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

namespace Nexplant.MC.LanguageFileEditor
{
    public class FPropCaption : FDynPropCusBase<FLfeCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryLanguage = "[02] Language";
        private const string CategoryDescription = "[03] Description";        

        // --

        private bool m_disposed = false;
        // --
        private FXmlNode m_fXmlNodeCap = null;
        private string m_default = string.Empty;
        private string m_english = string.Empty;
        private string m_korean = string.Empty;
        private string m_chinese = string.Empty;
        private string m_description = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropCaption(
            FLfeCore fLfeCore,
            FDynPropGrid fPropGrid,
            FXmlNode fXmlNodeCap
            )
            : base(fLfeCore, fLfeCore.fUIWizard, fPropGrid)
        {
            m_fXmlNodeCap = fXmlNodeCap;            
            // --
            init();   
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropCaption(
            FLfeCore fLfeCore,
            FDynPropGrid fPropGrid
            )
            : this(fLfeCore, fPropGrid, null)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropCaption(
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
                base.myDispose(disposing);

                if (disposing)
                {
                    term();
                    // --
                    m_fXmlNodeCap = null;
                }                

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Language

        [Category(CategoryGeneral)]
        public string Default
        {
            get
            {
                try
                {
                    return m_default;
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
                    m_default = value;
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

        [Category(CategoryLanguage)]
        public string English
        {
            get
            {
                try
                {
                    return m_english;
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
                    m_english = value;
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

        [Category(CategoryLanguage)]
        public string Korean
        {
            get
            {
                try
                {
                    return m_korean;
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
                    m_korean = value;
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

        [Category(CategoryLanguage)]
        public string Chinese
        {
            get
            {
                try
                {
                    return m_chinese;
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
                    m_chinese = value;
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

        #region Description

        [Category(CategoryDescription)]
        public string Description
        {
            get
            {
                try
                {
                    return m_description;
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
                    m_description = value;
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
                if (m_fXmlNodeCap != null)
                {
                    m_default = m_fXmlNodeCap.get_attrVal(FLanguage.Default.ToString(), FXmlTagCaption.D_Language);
                    m_english = m_fXmlNodeCap.get_attrVal(FLanguage.English.ToString(), FXmlTagCaption.D_Language);
                    m_korean = m_fXmlNodeCap.get_attrVal(FLanguage.Korean.ToString(), FXmlTagCaption.D_Language);
                    m_chinese = m_fXmlNodeCap.get_attrVal(FLanguage.Chinese.ToString(), FXmlTagCaption.D_Language);
                    m_description = m_fXmlNodeCap.get_attrVal(FXmlTagCaption.A_Description, FXmlTagCaption.D_Description);
                }

                // --

                base.fTypeDescriptor.properties["Default"].attributes.replace(new DisplayNameAttribute("Default"));
                base.fTypeDescriptor.properties["English"].attributes.replace(new DisplayNameAttribute("English"));
                base.fTypeDescriptor.properties["Korean"].attributes.replace(new DisplayNameAttribute("Korean"));
                base.fTypeDescriptor.properties["Chinese"].attributes.replace(new DisplayNameAttribute("Chinese"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));

                // --

                base.fTypeDescriptor.properties["Default"].attributes.replace(new DefaultValueAttribute(m_default));
                base.fTypeDescriptor.properties["English"].attributes.replace(new DefaultValueAttribute(m_english));
                base.fTypeDescriptor.properties["Korean"].attributes.replace(new DefaultValueAttribute(m_korean));
                base.fTypeDescriptor.properties["Chinese"].attributes.replace(new DefaultValueAttribute(m_chinese));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_description));                
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
