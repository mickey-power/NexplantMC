/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropStn.cs
--  Creator         : spike.lee
--  Create Date     : 2011.07.25
--  Description     : FAMate SECS Modeler SECS Transmitter Property Source Object Class 
--  History         : Created by spike.lee at 2011.07.25
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
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.SecsModeler
{
    public class FPropStn : FDynPropCusBase<FSsmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryFont = "[02] Font";
        private const string CategoryAutoAction = "[03] Auto Action";
        private const string CategoryAutoCycle = "[04] Auto Cycle";
        private const string CategoryUserTag = "[05] User Tag";   

        // --

        private bool m_disposed = false;
        // --
        private FSecsTransmitter m_fStn = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropStn(
            FSsmCore fSsmCore,
            FDynPropGrid fPropGrid,
            FSecsTransmitter fStn
            )
            : base(fSsmCore, fSsmCore.fUIWizard, fPropGrid)
        {
            m_fStn = fStn;
            // --
            init();   
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropStn(
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
                    m_fStn = null;
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
                    return m_fStn.fObjectType.ToString();
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
                    return m_fStn.uniqueIdToString;
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
                    return m_fStn.name;
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
                    FCommon.validateName(value, true, this.mainObject.fUIWizard);

                    // --

                    m_fStn.name = value;
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

        [Category(CategoryGeneral)]
        public string Description
        {
            get
            {
                try
                {
                    return m_fStn.description;
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
                    m_fStn.description = value;
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

        #region Font

        [Category(CategoryFont)]
        public Color FontColor
        {
            get
            {
                try
                {
                    return m_fStn.fontColor;
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

            set
            {
                try
                {
                    m_fStn.fontColor = value;
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

        [Category(CategoryFont)]
        public bool FontBold
        {
            get
            {
                try
                {
                    return m_fStn.fontBold;
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

            set
            {
                try
                {
                    m_fStn.fontBold = value;
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

        #region Auto Begining

        [Category(CategoryAutoAction)]
        public bool AutoActionFirstSelect
        {
            get
            {
                try
                {
                    return m_fStn.autoActionFirstSelect;
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

            set
            {
                try
                {
                    m_fStn.autoActionFirstSelect = value;
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

        [Category(CategoryAutoAction)]
        public bool AutoActionFirstClose
        {
            get
            {
                try
                {
                    return m_fStn.autoActionFirstClose;
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

            set
            {
                try
                {
                    m_fStn.autoActionFirstClose = value;
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

        [Category(CategoryAutoAction)]
        public bool AutoActionAlwaysSelect
        {
            get
            {
                try
                {
                    return m_fStn.autoActionAlwaysSelect;
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

            set
            {
                try
                {
                    m_fStn.autoActionAlwaysSelect = value;
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

        [Category(CategoryAutoAction)]
        public bool AutoActionAlwaysClose
        {
            get
            {
                try
                {
                    return m_fStn.autoActionAlwaysClose;
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

            set
            {
                try
                {
                    m_fStn.autoActionAlwaysClose = value;
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

        #region Auto Cycle

        [Category(CategoryAutoCycle)]
        public bool UsedAutoCycle
        {
            get
            {
                try
                {
                    return m_fStn.usedAutoCycle;
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

            set
            {
                try
                {
                    m_fStn.usedAutoCycle = value;
                    // --
                    setChangedUsedAutoCycle();
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

        [Category(CategoryAutoCycle)]
        public int AutoCyclePeriod
        {
            get
            {
                try
                {
                    return m_fStn.autoCyclePeriod;
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
                    if (value < 1)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }
                    // --
                    m_fStn.autoCyclePeriod = value;
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

        [Category(CategoryAutoCycle)]
        public FAutoCycleAction AutoCycleAction
        {
            get
            {
                try
                {
                    return m_fStn.fAutoCycleAction;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FAutoCycleAction.Once;
            }

            set
            {
                try
                {
                    m_fStn.fAutoCycleAction = value;
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

        #region User Tag

        [Category(CategoryUserTag)]
        public string UserTag1
        {
            get
            {
                try
                {
                    return m_fStn.userTag1;
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
                    m_fStn.userTag1 = value;
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

        [Category(CategoryUserTag)]
        public string UserTag2
        {
            get
            {
                try
                {
                    return m_fStn.userTag2;
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
                    m_fStn.userTag2 = value;
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

        [Category(CategoryUserTag)]
        public string UserTag3
        {
            get
            {
                try
                {
                    return m_fStn.userTag3;
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
                    m_fStn.userTag3 = value;
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

        [Category(CategoryUserTag)]
        public string UserTag4
        {
            get
            {
                try
                {
                    return m_fStn.userTag4;
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
                    m_fStn.userTag4 = value;
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

        [Category(CategoryUserTag)]
        public string UserTag5
        {
            get
            {
                try
                {
                    return m_fStn.userTag5;
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
                    m_fStn.userTag5 = value;
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

        [Browsable(false)]
        public FSecsTransmitter fSecsTransmitter
        {
            get
            {
                try
                {
                    return m_fStn;
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
                base.fTypeDescriptor.properties["AutoActionFirstSelect"].attributes.replace(new DisplayNameAttribute("First Select"));
                base.fTypeDescriptor.properties["AutoActionFirstClose"].attributes.replace(new DisplayNameAttribute("First Close"));
                base.fTypeDescriptor.properties["AutoActionAlwaysSelect"].attributes.replace(new DisplayNameAttribute("Always Select"));
                base.fTypeDescriptor.properties["AutoActionAlwaysClose"].attributes.replace(new DisplayNameAttribute("Always Close"));    
                // --
                base.fTypeDescriptor.properties["UsedAutoCycle"].attributes.replace(new DisplayNameAttribute("Used"));
                base.fTypeDescriptor.properties["AutoCyclePeriod"].attributes.replace(new DisplayNameAttribute("Period"));
                base.fTypeDescriptor.properties["AutoCycleAction"].attributes.replace(new DisplayNameAttribute("Action"));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DisplayNameAttribute(m_fStn.defUserTagName1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DisplayNameAttribute(m_fStn.defUserTagName2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DisplayNameAttribute(m_fStn.defUserTagName3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DisplayNameAttribute(m_fStn.defUserTagName4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DisplayNameAttribute(m_fStn.defUserTagName5));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fStn.fObjectType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fStn.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fStn.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fStn.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fStn.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fStn.fontBold));
                // --
                base.fTypeDescriptor.properties["AutoActionFirstSelect"].attributes.replace(new DefaultValueAttribute(m_fStn.autoActionFirstSelect));
                base.fTypeDescriptor.properties["AutoActionFirstClose"].attributes.replace(new DefaultValueAttribute(m_fStn.autoActionFirstClose));
                base.fTypeDescriptor.properties["AutoActionAlwaysSelect"].attributes.replace(new DefaultValueAttribute(m_fStn.autoActionAlwaysSelect));
                base.fTypeDescriptor.properties["AutoActionAlwaysClose"].attributes.replace(new DefaultValueAttribute(m_fStn.autoActionAlwaysClose));
                // --
                base.fTypeDescriptor.properties["UsedAutoCycle"].attributes.replace(new DefaultValueAttribute(m_fStn.usedAutoCycle));
                base.fTypeDescriptor.properties["AutoCyclePeriod"].attributes.replace(new DefaultValueAttribute(m_fStn.autoCyclePeriod));
                base.fTypeDescriptor.properties["AutoCycleAction"].attributes.replace(new DefaultValueAttribute(m_fStn.fAutoCycleAction));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DefaultValueAttribute(m_fStn.userTag1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DefaultValueAttribute(m_fStn.userTag2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DefaultValueAttribute(m_fStn.userTag3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DefaultValueAttribute(m_fStn.userTag4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DefaultValueAttribute(m_fStn.userTag5));

                // --

                procRefreshRequested();

                // --

                this.fPropGrid.DynPropGridRefreshRequested += new FDynPropGridRefreshRequestedEventHandler(fPropGrid_DynPropGridRefreshRequested);
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
                this.fPropGrid.DynPropGridRefreshRequested -= new FDynPropGridRefreshRequestedEventHandler(fPropGrid_DynPropGridRefreshRequested);
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

        private void procRefreshRequested(
            )
        {
            try
            {
                setChangedUsedAutoCycle();
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

        private void setChangedUsedAutoCycle(
            )
        {
            bool browsable = false;

            try
            {
                browsable = m_fStn.usedAutoCycle;
                // --
                base.fTypeDescriptor.properties["AutoCyclePeriod"].attributes.replace(new BrowsableAttribute(browsable));
                base.fTypeDescriptor.properties["AutoCycleAction"].attributes.replace(new BrowsableAttribute(browsable));
                
                // --

                this.fPropGrid.Refresh();
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

        #region fPropGrid Event Handler

        private void fPropGrid_DynPropGridRefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                procRefreshRequested();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
