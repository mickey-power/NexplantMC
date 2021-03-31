/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropPaul.cs
--  Creator         : jeff.kim
--  Create Date     : 2013.01.23
--  Description     : FAMate SECS Modeler Pauser Log Property Source Object Class 
--  History         : Created by jeff.kim at 2013.01.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.SecsModeler
{
    public class FPropPaul : FDynPropCusBase<FSsmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryFont = "[02] Font";
        private const string CategoryMode = "[03] Mode";
        private const string CategoryTime = "[04] Time";
        private const string CategoryUserTag = "[05] User Tag";   

        // --

        private bool m_disposed = false;
        // --
        private FPauserRaisedLog m_fPaul = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropPaul(
            FSsmCore fSsmCore,
            FDynPropGrid fPropGrid,
            FPauserRaisedLog fPaul
            )
            : base(fSsmCore, fSsmCore.fUIWizard, fPropGrid)
        {
            m_fPaul = fPaul;
            // --
            init();   
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropPaul(
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
                    // --
                    m_fPaul = null;
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
        public string Type
        {
            get
            {
                try
                {
                    return m_fPaul.fObjectLogType.ToString();
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        public string ID
        {
            get
            {
                try
                {
                    return m_fPaul.uniqueIdToString;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        [TypeConverter(typeof(FPropAttrNameStringConverter))]
        public string Name
        {
            get
            {
                try
                {
                    return m_fPaul.name;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        public string Description
        {
            get
            {
                try
                {
                    return m_fPaul.description;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Font

        [Category(CategoryFont)]
        public Color FontColor
        {
            get
            {
                try
                {
                    return m_fPaul.fontColor;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return Color.Black;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryFont)]
        public bool FontBold
        {
            get
            {
                try
                {
                    return m_fPaul.fontBold;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Mode

        [Category(CategoryMode)]
        public FPauserMode PauseMode
        {
            get
            {
                try
                {
                    return m_fPaul.fPauserMode;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FPauserMode.Fixed;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Time
                
        [Category(CategoryTime)]
        public int PauseMinTime
        {
            get
            {
                try
                {
                    return m_fPaul.pauseMinTime;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryTime)]
        public int PauseMaxTime
        {
            get
            {
                try
                {
                    return m_fPaul.pauseMaxTime;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryTime)]
        public int PauseTime
        {
            get
            {
                try
                {
                    return m_fPaul.pauseTime;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region User Tag

        [Category(CategoryUserTag)]
        public string UserTag1
        {
            get
            {
                try
                {
                    return m_fPaul.userTag1;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryUserTag)]
        public string UserTag2
        {
            get
            {
                try
                {
                    return m_fPaul.userTag2;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryUserTag)]
        public string UserTag3
        {
            get
            {
                try
                {
                    return m_fPaul.userTag3;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryUserTag)]
        public string UserTag4
        {
            get
            {
                try
                {
                    return m_fPaul.userTag4;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryUserTag)]
        public string UserTag5
        {
            get
            {
                try
                {
                    return m_fPaul.userTag5;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        [Browsable(false)]
        public FPauserRaisedLog fPauserRaisedLog
        {
            get
            {
                try
                {
                    return m_fPaul;
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
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Type"));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DisplayNameAttribute("ID"));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DisplayNameAttribute("Name"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DisplayNameAttribute("Color"));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DisplayNameAttribute("Bold"));
                // --
                base.fTypeDescriptor.properties["PauseMode"].attributes.replace(new DisplayNameAttribute("Pause Mode"));
                // --
                base.fTypeDescriptor.properties["PauseMaxTime"].attributes.replace(new DisplayNameAttribute("Pause Max Time (ms)"));
                base.fTypeDescriptor.properties["PauseMinTime"].attributes.replace(new DisplayNameAttribute("Pause Min Time (ms)"));
                base.fTypeDescriptor.properties["PauseTime"].attributes.replace(new DisplayNameAttribute("PauseTime"));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DisplayNameAttribute("User Tag1"));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DisplayNameAttribute("User Tag2"));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DisplayNameAttribute("User Tag3"));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DisplayNameAttribute("User Tag4"));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DisplayNameAttribute("User Tag5"));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fPaul.fObjectLogType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fPaul.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fPaul.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fPaul.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fPaul.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fPaul.fontBold));
                // --
                base.fTypeDescriptor.properties["PauseMode"].attributes.replace(new DefaultValueAttribute(m_fPaul.fPauserMode));
                // --
                base.fTypeDescriptor.properties["PauseMaxTime"].attributes.replace(new DefaultValueAttribute(m_fPaul.pauseMaxTime));
                base.fTypeDescriptor.properties["PauseMinTime"].attributes.replace(new DefaultValueAttribute(m_fPaul.pauseMinTime));
                base.fTypeDescriptor.properties["PauseTime"].attributes.replace(new DefaultValueAttribute(m_fPaul.pauseTime));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DefaultValueAttribute(m_fPaul.userTag1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DefaultValueAttribute(m_fPaul.userTag2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DefaultValueAttribute(m_fPaul.userTag3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DefaultValueAttribute(m_fPaul.userTag4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DefaultValueAttribute(m_fPaul.userTag5));

                // --

                if (m_fPaul.fPauserMode == FPauserMode.Fixed)
                {
                    // --

                    base.fTypeDescriptor.properties["PauseMaxTime"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["PauseMinTime"].attributes.replace(new BrowsableAttribute(false));
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
