/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropScn.cs
--  Creator         : spike.lee
--  Create Date     : 2011.07.27
--  Description     : FAMate SECS Modeler SECS Condition Property Source Object Class 
--  History         : Created by spike.lee at 2011.07.27
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
    public class FPropScn : FDynPropCusBase<FSsmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryFont = "[02] Font";
        private const string CategoryBehavior = "[03] Behavior";
        private const string CategoryMessage = "[04] Message";
        private const string CategoryExpression = "[05] Expression";
        private const string CategoryRetry = "[06] Retry";
        private const string CategoryConnection = "[07] Connection";
        private const string CategoryUserTag = "[08] User Tag";   

        // --

        private bool m_disposed = false;
        // --
        private FSecsCondition m_fScn = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropScn(
            FSsmCore fSsmCore,
            FDynPropGrid fPropGrid,
            FSecsCondition fScn
            )
            : base(fSsmCore, fSsmCore.fUIWizard, fPropGrid)
        {
            m_fScn = fScn;
            // --
            init();   
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropScn(
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
                    m_fScn = null;
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
                    return m_fScn.fObjectType.ToString();
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
                    return m_fScn.uniqueIdToString;
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
                    return m_fScn.name;
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

                    m_fScn.name = value;
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
                    return m_fScn.description;
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
                    m_fScn.description = value;
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
                    return m_fScn.fontColor;
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
                    m_fScn.fontColor = value;
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
                    return m_fScn.fontBold;
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
                    m_fScn.fontBold = value;
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

        #region Behavior

        [Category(CategoryBehavior)]
        public FConditionMode ConditionMode
        {
            get
            {
                try
                {
                    return m_fScn.fConditionMode;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FConditionMode.Expression;
            }

            set
            {
                try
                {
                    m_fScn.fConditionMode = value;
                    // --
                    setChangedConditionMode();
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

        #region Message

        [Category(CategoryMessage)]
        [Editor(typeof(FPropAttrScnDeviceUITypeEditor), typeof(UITypeEditor))]
        public string Device
        {
            get
            {
                try
                {
                    return m_fScn.hasDevice ? m_fScn.fDevice.name : string.Empty;
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

        [Category(CategoryMessage)]
        public string Session
        {
            get
            {
                try
                {
                    return m_fScn.hasSession ? m_fScn.fSession.name : string.Empty;
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

        [Category(CategoryMessage)]
        [Editor(typeof(FPropAttrScnMessageUITypeEditor), typeof(UITypeEditor))]
        public string Message
        {
            get
            {
                FSecsMessage fSmg = null;

                try
                {
                    if (m_fScn.hasMessage)
                    {
                        fSmg = m_fScn.fMessage;
                        return "[S" + fSmg.stream.ToString() + " F" + fSmg.function.ToString() + " V" + fSmg.version.ToString() + "] " + fSmg.name;
                    }
                    return string.Empty;                    
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

        #region Expression

        [Category(CategoryExpression)]
        [Editor(typeof(FPropAttrScnExpressionUITypeEditor), typeof(UITypeEditor))]
        public string Expression
        {
            get
            {
                try
                {
                    return m_fScn.expression;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Connection State

        [Category(CategoryConnection)]
        public FDeviceState ConnectionState
        {
            get
            {
                try
                {
                    return m_fScn.fConnectionState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDeviceState.Closed;
            }

            set
            {
                try
                {
                    m_fScn.fConnectionState = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Retry

        [Category(CategoryRetry)]
        public int RetryLimit
        {
            get
            {
                try
                {
                    return m_fScn.retryLimit;
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

            set
            {
                try
                {
                    if (value < 0)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }
                    
                    // --
                    
                    m_fScn.retryLimit = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    return m_fScn.userTag1;
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
                    m_fScn.userTag1 = value;
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
                    return m_fScn.userTag2;
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
                    m_fScn.userTag2 = value;
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
                    return m_fScn.userTag3;
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
                    m_fScn.userTag3 = value;
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
                    return m_fScn.userTag4;
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
                    m_fScn.userTag4 = value;
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
                    return m_fScn.userTag5;
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
                    m_fScn.userTag5 = value;
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
        public FSecsCondition fSecsCondition
        {
            get
            {
                try
                {
                    return m_fScn;
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
            FSecsMessage fSmg = null;

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
                base.fTypeDescriptor.properties["ConditionMode"].attributes.replace(new DisplayNameAttribute("Condition Mode"));
                // --
                base.fTypeDescriptor.properties["Device"].attributes.replace(new DisplayNameAttribute("Device"));
                base.fTypeDescriptor.properties["Session"].attributes.replace(new DisplayNameAttribute("Session"));
                base.fTypeDescriptor.properties["Message"].attributes.replace(new DisplayNameAttribute("Message"));
                // --
                base.fTypeDescriptor.properties["Expression"].attributes.replace(new DisplayNameAttribute("Expression"));
                // --
                base.fTypeDescriptor.properties["RetryLimit"].attributes.replace(new DisplayNameAttribute("Retry Limit"));
                // --
                base.fTypeDescriptor.properties["ConnectionState"].attributes.replace(new DisplayNameAttribute("Connection State"));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DisplayNameAttribute(m_fScn.defUserTagName1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DisplayNameAttribute(m_fScn.defUserTagName2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DisplayNameAttribute(m_fScn.defUserTagName3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DisplayNameAttribute(m_fScn.defUserTagName4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DisplayNameAttribute(m_fScn.defUserTagName5));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fScn.fObjectType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fScn.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fScn.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fScn.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fScn.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fScn.fontBold));
                // --
                base.fTypeDescriptor.properties["ConditionMode"].attributes.replace(new DefaultValueAttribute(m_fScn.fConditionMode));
                // --
                base.fTypeDescriptor.properties["Device"].attributes.replace(new DefaultValueAttribute(m_fScn.hasDevice ? m_fScn.fDevice.name : string.Empty));
                base.fTypeDescriptor.properties["Session"].attributes.replace(new DefaultValueAttribute(m_fScn.hasSession ? m_fScn.fSession.name : string.Empty));
                if (m_fScn.hasMessage)
                {
                    fSmg = m_fScn.fMessage;
                    base.fTypeDescriptor.properties["Message"].attributes.replace(
                        new DefaultValueAttribute("[S" + fSmg.stream.ToString() + " F" + fSmg.function.ToString() + " V" + fSmg.version.ToString() + "] " + fSmg.name)
                        );
                }
                else
                {
                    base.fTypeDescriptor.properties["Message"].attributes.replace(new DefaultValueAttribute(string.Empty));
                }                
                // --
                base.fTypeDescriptor.properties["Expression"].attributes.replace(new DefaultValueAttribute(m_fScn.expression));
                // --
                base.fTypeDescriptor.properties["RetryLimit"].attributes.replace(new DefaultValueAttribute(m_fScn.retryLimit));
                // --
                base.fTypeDescriptor.properties["ConnectionState"].attributes.replace(new DefaultValueAttribute(m_fScn.fConnectionState));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DefaultValueAttribute(m_fScn.userTag1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DefaultValueAttribute(m_fScn.userTag2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DefaultValueAttribute(m_fScn.userTag3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DefaultValueAttribute(m_fScn.userTag4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DefaultValueAttribute(m_fScn.userTag5));

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
                fSmg = null;
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
                if (m_fScn.hasChild)
                {
                    base.fTypeDescriptor.properties["ConditionMode"].attributes.replace(new ReadOnlyAttribute(true));
                }

                // --

                setChangedConditionMode();
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

        private void setChangedConditionMode(
            )
        {
            try
            {
                if (m_fScn.fConditionMode == FConditionMode.Expression)
                {
                    base.fTypeDescriptor.properties["Expression"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["RetryLimit"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["ConnectionState"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Session"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Message"].attributes.replace(new BrowsableAttribute(true));
                }
                else if (m_fScn.fConditionMode == FConditionMode.Connection)
                {
                    base.fTypeDescriptor.properties["Expression"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["RetryLimit"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["ConnectionState"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Session"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Message"].attributes.replace(new BrowsableAttribute(false));
                }
                else
                {
                    base.fTypeDescriptor.properties["Expression"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["RetryLimit"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["ConnectionState"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Session"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Message"].attributes.replace(new BrowsableAttribute(true));
                }

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
