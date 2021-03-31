/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropFun.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.25
--  Description     : FAMate OPC Modeler Function Property Source Object Class 
--  History         : Created by Jeff.Kim at 2013.07.25
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
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.OpcModeler
{
    public class FPropFun : FDynPropCusBase<FOpmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryFont = "[02] Font";
        private const string CategoryFunction = "[03] Function";
        private const string CategoryParameter = "[04] Parameter";
        private const string CategoryErrorAction = "[05] Error Action";
        private const string CategoryUserTag = "[06] User Tag";   

        // --

        private bool m_disposed = false;
        // --
        private FFunction m_fFun = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropFun(
            FOpmCore fOpmCore,
            FDynPropGrid fPropGrid,
            FFunction fFun
            )
            : base(fOpmCore, fOpmCore.fUIWizard, fPropGrid)
        {
            m_fFun = fFun;
            // --
            init();   
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropFun(
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
                    m_fFun = null;
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
                    return m_fFun.fObjectType.ToString();
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
                    return m_fFun.uniqueIdToString;
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
                    return m_fFun.name;
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

                    m_fFun.name = value;
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
                    return m_fFun.description;
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
                    m_fFun.description = value;
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
                    return m_fFun.fontColor;
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
                    m_fFun.fontColor = value;
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
                    return m_fFun.fontBold;
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
                    m_fFun.fontBold = value;
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

        #region Function

        [Category(CategoryFunction)]
        [Editor(typeof(FPropAttrFunFunctionUITypeEditor), typeof(UITypeEditor))]
        public string FunctionName
        {
            get
            {
                try
                {
                    return m_fFun.functionName;
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
                    m_fFun.functionName = value;
                    setChangedFunctionName();
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

        #region Parameter

        [Category(CategoryParameter)]
        [TypeConverter(typeof(FPropAttrFunParameterStringConverter))]
        public string Parameter1
        {
            get
            {
                try
                {
                    return m_fFun.parameter1;
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
                    m_fFun.parameter1 = value;
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

        [Category(CategoryParameter)]
        [TypeConverter(typeof(FPropAttrFunParameterStringConverter))]
        public string Parameter2
        {
            get
            {
                try
                {
                    return m_fFun.parameter2;
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
                    m_fFun.parameter2 = value;
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

        [Category(CategoryParameter)]
        [TypeConverter(typeof(FPropAttrFunParameterStringConverter))]
        public string Parameter3
        {
            get
            {
                try
                {
                    return m_fFun.parameter3;
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
                    m_fFun.parameter3 = value;
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

        [Category(CategoryParameter)]
        [TypeConverter(typeof(FPropAttrFunParameterStringConverter))]
        public string Parameter4
        {
            get
            {
                try
                {
                    return m_fFun.parameter4;
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
                    m_fFun.parameter4 = value;
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

        [Category(CategoryParameter)]
        [TypeConverter(typeof(FPropAttrFunParameterStringConverter))]
        public string Parameter5
        {
            get
            {
                try
                {
                    return m_fFun.parameter5;
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
                    m_fFun.parameter5 = value;
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

        #region Error Action

        [Category(CategoryErrorAction)]
        public FErrorAction ErrorAction
        {
            get
            {
                try
                {
                    return m_fFun.fErrorAction;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FErrorAction.Stop;
            }

            set
            {
                try
                {
                    m_fFun.fErrorAction = value;
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
                    return m_fFun.userTag1;
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
                    m_fFun.userTag1 = value;
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
                    return m_fFun.userTag2;
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
                    m_fFun.userTag2 = value;
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
                    return m_fFun.userTag3;
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
                    m_fFun.userTag3 = value;
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
                    return m_fFun.userTag4;
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
                    m_fFun.userTag4 = value;
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
                    return m_fFun.userTag5;
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
                    m_fFun.userTag5 = value;
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
        public FFunction fFunction
        {
            get
            {
                try
                {
                    return m_fFun;
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
                base.fTypeDescriptor.properties["FunctionName"].attributes.replace(new DisplayNameAttribute("Function Name"));
                // --
                base.fTypeDescriptor.properties["Parameter1"].attributes.replace(new DisplayNameAttribute(m_fFun.defParameterName1));
                base.fTypeDescriptor.properties["Parameter2"].attributes.replace(new DisplayNameAttribute(m_fFun.defParameterName2));
                base.fTypeDescriptor.properties["Parameter3"].attributes.replace(new DisplayNameAttribute(m_fFun.defParameterName3));
                base.fTypeDescriptor.properties["Parameter4"].attributes.replace(new DisplayNameAttribute(m_fFun.defParameterName4));
                base.fTypeDescriptor.properties["Parameter5"].attributes.replace(new DisplayNameAttribute(m_fFun.defParameterName5));
                // --
                base.fTypeDescriptor.properties["ErrorAction"].attributes.replace(new DisplayNameAttribute("Error Action"));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DisplayNameAttribute(m_fFun.defUserTagName1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DisplayNameAttribute(m_fFun.defUserTagName2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DisplayNameAttribute(m_fFun.defUserTagName3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DisplayNameAttribute(m_fFun.defUserTagName4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DisplayNameAttribute(m_fFun.defUserTagName5));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fFun.fObjectType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fFun.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fFun.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fFun.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fFun.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fFun.fontBold));
                // --
                base.fTypeDescriptor.properties["FunctionName"].attributes.replace(new DefaultValueAttribute(m_fFun.functionName));
                // --
                base.fTypeDescriptor.properties["Parameter1"].attributes.replace(new DefaultValueAttribute(m_fFun.parameter1));
                base.fTypeDescriptor.properties["Parameter2"].attributes.replace(new DefaultValueAttribute(m_fFun.parameter2));
                base.fTypeDescriptor.properties["Parameter3"].attributes.replace(new DefaultValueAttribute(m_fFun.parameter3));
                base.fTypeDescriptor.properties["Parameter4"].attributes.replace(new DefaultValueAttribute(m_fFun.parameter4));
                base.fTypeDescriptor.properties["Parameter5"].attributes.replace(new DefaultValueAttribute(m_fFun.parameter5));
                // --
                base.fTypeDescriptor.properties["ErrorAction"].attributes.replace(new DefaultValueAttribute(m_fFun.fErrorAction));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DefaultValueAttribute(m_fFun.userTag1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DefaultValueAttribute(m_fFun.userTag2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DefaultValueAttribute(m_fFun.userTag3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DefaultValueAttribute(m_fFun.userTag4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DefaultValueAttribute(m_fFun.userTag5));      
          
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
                setChangedFunctionName();
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

        public void setChangedFunctionName(
            )
        {
            try
            {
                base.fTypeDescriptor.properties["Parameter1"].attributes.replace(new DisplayNameAttribute(m_fFun.defParameterName1));
                base.fTypeDescriptor.properties["Parameter2"].attributes.replace(new DisplayNameAttribute(m_fFun.defParameterName2));
                base.fTypeDescriptor.properties["Parameter3"].attributes.replace(new DisplayNameAttribute(m_fFun.defParameterName3));
                base.fTypeDescriptor.properties["Parameter4"].attributes.replace(new DisplayNameAttribute(m_fFun.defParameterName4));
                base.fTypeDescriptor.properties["Parameter5"].attributes.replace(new DisplayNameAttribute(m_fFun.defParameterName5));
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
