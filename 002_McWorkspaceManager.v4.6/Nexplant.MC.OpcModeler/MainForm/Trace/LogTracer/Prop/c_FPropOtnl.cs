/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropOtnl.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.11.07
--  Description     : FAMate OPC Modeler OPC Transmitter Raised Log Property Source Object Class 
--  History         : Created by jungyoul.moon at 2013.11.07
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.OpcModeler
{
    public class FPropOtnl : FDynPropCusBase<FOpmCore>
    {
        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryResult = "[01] Result";
        private const string CategoryGeneral = "[02] General";
        private const string CategoryFont = "[03] Font";
        private const string CategoryEquipment = "[04] Equipment";
        private const string CategoryScenario = "[05] Scenario";
        private const string CategoryAutoAction = "[06] Auto Action";
        private const string CategoryAutoCycle = "[07] Auto Cycle";
        private const string CategoryUserTag = "[08] User Tag";

        // --

        private bool m_disposed = false;
        // --
        private FOpcTransmitterRaisedLog m_fOtnl = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropOtnl(
            FOpmCore fOpmCore,
            FDynPropGrid fPropGrid,
            FOpcTransmitterRaisedLog fOtnl
            )
            :base(fOpmCore, fOpmCore.fUIWizard, fPropGrid)
        {
            m_fOtnl = fOtnl;
            // --            
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropOtnl(
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
                    m_fOtnl = null;
                }

                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Result

        [Category(CategoryResult)]
        public string Time
        {
            get
            {
                try
                {
                    return m_fOtnl.time;
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

        [Category(CategoryResult)]
        public FResultCode ResultCode
        {
            get
            {
                try
                {
                    return m_fOtnl.fResultCode;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FResultCode.Error;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryResult)]
        public string ResultMessage
        {
            get
            {
                try
                {
                    return m_fOtnl.resultMessage;
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

        #region General

        [Category(CategoryGeneral)]
        public string Type
        {
            get
            {
                try
                {
                    return m_fOtnl.fObjectLogType.ToString();
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
                    return m_fOtnl.uniqueIdToString;
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
        public string Name
        {
            get
            {
                try
                {
                    return m_fOtnl.name;
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
                    return m_fOtnl.description;
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
                    return m_fOtnl.fontColor;
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
                    return m_fOtnl.fontBold;
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

        #region Equipment

        [Category(CategoryEquipment)]
        public string EquipmentId
        {
            get
            {
                try
                {
                    return m_fOtnl.equipmentUniqueIdToString;
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

        [Category(CategoryEquipment)]
        public string EquipmentName
        {
            get
            {
                try
                {
                    return m_fOtnl.equipmentName;
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

        #region Scenario

        [Category(CategoryScenario)]
        public string ScenarioId
        {
            get
            {
                try
                {
                    return m_fOtnl.scenarioUniqueIdToString;
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

        [Category(CategoryScenario)]
        public string ScenarioName
        {
            get
            {
                try
                {
                    return m_fOtnl.scenarioName;
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

        #region Auto Action

        [Category(CategoryAutoAction)]
        public bool AutoActionFirstSelect
        {
            get
            {
                try
                {
                    return m_fOtnl.autoActionFirstSelect;
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

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryAutoAction)]
        public bool AutoActionFirstClose
        {
            get
            {
                try
                {
                    return m_fOtnl.autoActionFirstClose;
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

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryAutoAction)]
        public bool AutoActionAlwaysSelect
        {
            get
            {
                try
                {
                    return m_fOtnl.autoActionAlwaysSelect;
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

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryAutoAction)]
        public bool AutoActionAlwaysClose
        {
            get
            {
                try
                {
                    return m_fOtnl.autoActionAlwaysClose;
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

        #region Auto Cycle

        [Category(CategoryAutoCycle)]
        public bool UsedAutoCycle
        {
            get
            {
                try
                {
                    return m_fOtnl.usedAutoCycle;
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

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryAutoCycle)]
        public int AutoCyclePeriod
        {
            get
            {
                try
                {
                    return m_fOtnl.autoCyclePeriod;
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

        [Category(CategoryAutoCycle)]
        public FAutoCycleAction AutoCycleAction
        {
            get
            {
                try
                {
                    return m_fOtnl.fAutoCycleAction;
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
                    return m_fOtnl.userTag1;
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
                    return m_fOtnl.userTag2;
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
                    return m_fOtnl.userTag3;
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
                    return m_fOtnl.userTag4;
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
                    return m_fOtnl.userTag5;
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
        public FOpcTransmitterRaisedLog fOpcTransmitterRaisedLog
        {
            get
            {
                try
                {
                    return m_fOtnl;
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
                base.fTypeDescriptor.properties["Time"].attributes.replace(new DisplayNameAttribute("Time"));
                base.fTypeDescriptor.properties["ResultCode"].attributes.replace(new DisplayNameAttribute("Result Code"));
                base.fTypeDescriptor.properties["ResultMessage"].attributes.replace(new DisplayNameAttribute("Result Message"));
                // --
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Type"));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DisplayNameAttribute("ID"));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DisplayNameAttribute("Name"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DisplayNameAttribute("Color"));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DisplayNameAttribute("Bold"));
                // --
                base.fTypeDescriptor.properties["EquipmentId"].attributes.replace(new DisplayNameAttribute("ID"));
                base.fTypeDescriptor.properties["EquipmentName"].attributes.replace(new DisplayNameAttribute("Name"));
                // --
                base.fTypeDescriptor.properties["ScenarioId"].attributes.replace(new DisplayNameAttribute("ID"));
                base.fTypeDescriptor.properties["ScenarioName"].attributes.replace(new DisplayNameAttribute("Name"));
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
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DisplayNameAttribute("User Tag1"));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DisplayNameAttribute("User Tag2"));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DisplayNameAttribute("User Tag3"));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DisplayNameAttribute("User Tag4"));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DisplayNameAttribute("User Tag5"));

                // --

                base.fTypeDescriptor.properties["Time"].attributes.replace(new DefaultValueAttribute(m_fOtnl.time));
                base.fTypeDescriptor.properties["ResultCode"].attributes.replace(new DefaultValueAttribute(m_fOtnl.fResultCode));
                base.fTypeDescriptor.properties["ResultMessage"].attributes.replace(new DefaultValueAttribute(m_fOtnl.resultMessage));
                // --
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fOtnl.fObjectLogType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fOtnl.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fOtnl.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fOtnl.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fOtnl.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fOtnl.fontBold));
                // --
                base.fTypeDescriptor.properties["EquipmentId"].attributes.replace(new DefaultValueAttribute(m_fOtnl.equipmentUniqueIdToString));
                base.fTypeDescriptor.properties["EquipmentName"].attributes.replace(new DefaultValueAttribute(m_fOtnl.equipmentName));
                // -- 
                base.fTypeDescriptor.properties["ScenarioId"].attributes.replace(new DefaultValueAttribute(m_fOtnl.scenarioUniqueIdToString));
                base.fTypeDescriptor.properties["ScenarioName"].attributes.replace(new DefaultValueAttribute(m_fOtnl.scenarioName));
                // --
                base.fTypeDescriptor.properties["AutoActionFirstSelect"].attributes.replace(new DefaultValueAttribute(m_fOtnl.autoActionFirstSelect));
                base.fTypeDescriptor.properties["AutoActionFirstClose"].attributes.replace(new DefaultValueAttribute(m_fOtnl.autoActionFirstClose));
                base.fTypeDescriptor.properties["AutoActionAlwaysSelect"].attributes.replace(new DefaultValueAttribute(m_fOtnl.autoActionAlwaysSelect));
                base.fTypeDescriptor.properties["AutoActionAlwaysClose"].attributes.replace(new DefaultValueAttribute(m_fOtnl.autoActionAlwaysClose));
                // --
                base.fTypeDescriptor.properties["UsedAutoCycle"].attributes.replace(new DefaultValueAttribute(m_fOtnl.usedAutoCycle));
                base.fTypeDescriptor.properties["AutoCyclePeriod"].attributes.replace(new DefaultValueAttribute(m_fOtnl.autoCyclePeriod));
                base.fTypeDescriptor.properties["AutoCycleAction"].attributes.replace(new DefaultValueAttribute(m_fOtnl.fAutoCycleAction));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DefaultValueAttribute(m_fOtnl.userTag1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DefaultValueAttribute(m_fOtnl.userTag2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DefaultValueAttribute(m_fOtnl.userTag3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DefaultValueAttribute(m_fOtnl.userTag4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DefaultValueAttribute(m_fOtnl.userTag5));

                // --

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

        //------------------------------------------------------------------------------------------------------------------------

        private void setChangedUsedAutoCycle(
            )
        {
            bool browsable = false;

            try
            {
                browsable = m_fOtnl.usedAutoCycle;
                // --
                base.fTypeDescriptor.properties["AutoCyclePeriod"].attributes.replace(new BrowsableAttribute(browsable));
                base.fTypeDescriptor.properties["AutoCycleAction"].attributes.replace(new BrowsableAttribute(browsable));
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