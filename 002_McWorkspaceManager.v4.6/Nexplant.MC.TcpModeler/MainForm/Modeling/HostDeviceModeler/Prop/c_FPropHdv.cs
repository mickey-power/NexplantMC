/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropHdv.cs
--  Creator         : duchoi
--  Create Date     : 2013.07.24
--  Description     : FAMate TCP Modeler Host Device Property Source Object Class 
--  History         : Created by duchoi at 2013.07.24
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
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.TcpModeler
{
    public class FPropHdv : FDynPropCusBase<FTcmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryFont = "[02] Font";
        private const string CategoryProtocol = "[03] Protocol";
        private const string CategoryTimeout = "[04] Timeout";
        private const string CategoryUserTag = "[05] User Tag";

        // --

        private bool m_disposed = false;
        // --
        private FHostDevice m_fHdv = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropHdv(
            FTcmCore fTcmCore,
            FDynPropGrid fPropGrid,
            FHostDevice fHdv
            )
            : base(fTcmCore, fTcmCore.fUIWizard, fPropGrid)
        {
            m_fHdv = fHdv;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropHdv(
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
                    m_fHdv = null;
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
                    return m_fHdv.fObjectType.ToString();
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
                    return m_fHdv.uniqueIdToString;
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
                    return m_fHdv.name;
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

                    m_fHdv.name = value;
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
                    return m_fHdv.description;
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
                    m_fHdv.description = value;
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
                    return m_fHdv.fontColor;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                return Color.Black;
            }

            set
            {
                try
                {
                    m_fHdv.fontColor = value;
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
                    return m_fHdv.fontBold;
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
                    m_fHdv.fontBold = value;
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

        #region Protocol

        [Category(CategoryProtocol)]
        public FDeviceMode Mode
        {
            get
            {
                try
                {
                    return m_fHdv.fDeviceMode;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FDeviceMode.Both;
            }

            set
            {
                try
                {
                    m_fHdv.fDeviceMode = value;
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

        [Category(CategoryProtocol)]
        [Editor(typeof(FPropAttrHdvDriverUITypeEditor), typeof(UITypeEditor))]
        public string Driver
        {
            get
            {
                try
                {
                    return m_fHdv.driver;
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

        [Category(CategoryProtocol)]
        public string DriverDescription
        {
            get
            {
                try
                {
                    return m_fHdv.driverDescription;
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

        [Category(CategoryProtocol)]
        [Editor(typeof(FPropAttrHdvDriverOptionUITypeEditor), typeof(UITypeEditor))]
        public string DriverOption
        {
            get
            {
                try
                {
                    return getDriverOption();
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

        #region Timeout

        [Category(CategoryTimeout)]
        public int TransactionTimeout
        {
            get
            {
                try
                {
                    return m_fHdv.transactionTimeout;
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
                    if (value < 1 || value > 120)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // --

                    m_fHdv.transactionTimeout = value;
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
                    return m_fHdv.userTag1;
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
                    m_fHdv.userTag1 = value;
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
                    return m_fHdv.userTag2;
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
                    m_fHdv.userTag2 = value;
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
                    return m_fHdv.userTag3;
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
                    m_fHdv.userTag3 = value;
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
                    return m_fHdv.userTag4;
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
                    m_fHdv.userTag4 = value;
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
                    return m_fHdv.userTag5;
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
                    m_fHdv.userTag5 = value;
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
        public FHostDevice fHostDevice
        {
            get
            {
                try
                {
                    return m_fHdv;
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
                base.fTypeDescriptor.properties["Mode"].attributes.replace(new DisplayNameAttribute("Mode"));
                base.fTypeDescriptor.properties["Driver"].attributes.replace(new DisplayNameAttribute("Driver"));
                base.fTypeDescriptor.properties["DriverDescription"].attributes.replace(new DisplayNameAttribute("Driver Description"));
                base.fTypeDescriptor.properties["DriverOption"].attributes.replace(new DisplayNameAttribute("Driver Option"));
                // --
                base.fTypeDescriptor.properties["TransactionTimeout"].attributes.replace(new DisplayNameAttribute("Transaction Timeout"));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DisplayNameAttribute(m_fHdv.defUserTagName1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DisplayNameAttribute(m_fHdv.defUserTagName2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DisplayNameAttribute(m_fHdv.defUserTagName3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DisplayNameAttribute(m_fHdv.defUserTagName4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DisplayNameAttribute(m_fHdv.defUserTagName5));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fHdv.fObjectType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fHdv.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fHdv.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fHdv.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fHdv.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fHdv.fontBold));
                // --
                base.fTypeDescriptor.properties["Mode"].attributes.replace(new DefaultValueAttribute(m_fHdv.fDeviceMode));
                base.fTypeDescriptor.properties["Driver"].attributes.replace(new DefaultValueAttribute(m_fHdv.driver));
                base.fTypeDescriptor.properties["DriverDescription"].attributes.replace(new DefaultValueAttribute(m_fHdv.driverDescription));
                base.fTypeDescriptor.properties["DriverOption"].attributes.replace(new DefaultValueAttribute(getDriverOption()));
                // --
                base.fTypeDescriptor.properties["TransactionTimeout"].attributes.replace(new DefaultValueAttribute(m_fHdv.transactionTimeout));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DefaultValueAttribute(m_fHdv.userTag1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DefaultValueAttribute(m_fHdv.userTag2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DefaultValueAttribute(m_fHdv.userTag3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DefaultValueAttribute(m_fHdv.userTag4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DefaultValueAttribute(m_fHdv.userTag5));

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
                setChangedState(m_fHdv.fState);
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

        public void setChangedState(
            FDeviceState fDeviceState
            )
        {
            bool stateCheck = false;

            try
            {
                if (fDeviceState != FDeviceState.Closed)
                {
                    stateCheck = true;
                }

                // --

                base.fTypeDescriptor.properties["Mode"].attributes.replace(new ReadOnlyAttribute(stateCheck));                
                
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

        //------------------------------------------------------------------------------------------------------------------------

        private string getDriverOption(
            )
        {
            FIHostDriverOption fHostDriverOption = null;

            try
            {
                if (m_fHdv.driver != string.Empty)
                {
                    fHostDriverOption = m_fHdv.createHostDriverOption();
                }
                return fHostDriverOption == null ? string.Empty : fHostDriverOption.ToString();
            }
            catch (Exception ex)
            {
                m_fHdv.resetHostDriver();
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return string.Empty;
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
