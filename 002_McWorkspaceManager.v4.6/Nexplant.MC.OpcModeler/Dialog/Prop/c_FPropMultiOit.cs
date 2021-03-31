/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropMultiOit.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2015.07.29
--  Description     : FAMate OPC Modeler Multi OPC Item Property Source Object Class 
--  History         : Created by Jeff.Kim at 2015.07.29
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Text;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.OpcModeler
{
    public class FPropMultiOit : FDynPropCusBase<FOpmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryFont = "[02] Font";
        private const string CategoryTag = "[03] Tag";
        private const string CategoryFormat = "[04] Format";
        private const string CategoryScan = "[05] Scan";
        private const string CategoryCollection = "[06] Collection";
        private const string CategoryUserTag = "[07] User Tag";

        // --

        private bool m_disposed = false;
        // --
        private FOpcSession m_fOsn = null;
        private FOpcItem m_fOit = null;
        private string m_realAddress = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropMultiOit(
            FOpmCore fOpmCore,
            FDynPropGrid fPropGrid,
            FOpcItem fOit
            )
            : this(fOpmCore, fPropGrid, fOit, null)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropMultiOit(
            FOpmCore fOpmCore,
            FDynPropGrid fPropGrid,
            FOpcItem fOit,
            FOpcSession fOsn
            )
            : base(fOpmCore, fOpmCore.fUIWizard, fPropGrid)
        {
            m_fOsn = fOsn;
            m_fOit = fOit;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropMultiOit(
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
                    m_fOsn = null;
                    m_fOit = null;
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
                    return m_fOit.fObjectType.ToString();
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
                    return m_fOit.name;
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

                    m_fOit.name = value;
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
                    return m_fOit.description;
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
                    m_fOit.description = value;
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
                    return m_fOit.fontColor;
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
                    m_fOit.fontColor = value;
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
                    return m_fOit.fontBold;
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
                    m_fOit.fontBold = value;
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

        #region Tag

        [Category(CategoryTag)]
        public FTagFormat ItemFormat
        {
            get
            {
                try
                {
                    return m_fOit.fItemFormat;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FTagFormat.Boolean;
            }

            set
            {
                try
                {
                    m_fOit.fItemFormat = value;
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

        [Category(CategoryTag)]
        public bool ItemArray
        {
            get
            {
                try
                {
                    return m_fOit.itemArray;
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
                    m_fOit.itemArray = value;
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

        #region Format

        [Category(CategoryFormat)]
        public FOpcFormat Format
        {
            get
            {
                try
                {
                    return m_fOit.fFormat;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FOpcFormat.Boolean;
            }

            set
            {
                try
                {
                    m_fOit.fFormat = value;
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

        #region Scan

        [Category(CategoryScan)]
        public FDataScanMode ScanMode
        {
            get
            {
                try
                {
                    return m_fOit.fScanMode;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FDataScanMode.Local;
            }

            set
            {
                try
                {
                    m_fOit.fScanMode = value;
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

        #region Collection

        [Category(CategoryCollection)]
        public string ReservedWord
        {
            get
            {
                try
                {
                    return m_fOit.reservedWord;
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
                    m_fOit.reservedWord = value;
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

        [Category(CategoryCollection)]
        public bool Extraction
        {
            get
            {
                try
                {
                    return m_fOit.extraction;
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
                    m_fOit.extraction = value;
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
                    return m_fOit.userTag1;
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
                    m_fOit.userTag1 = value;
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
                    return m_fOit.userTag2;
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
                    m_fOit.userTag2 = value;
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
                    return m_fOit.userTag3;
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
                    m_fOit.userTag3 = value;
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
                    return m_fOit.userTag4;
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
                    m_fOit.userTag4 = value;
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
                    return m_fOit.userTag5;
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
                    m_fOit.userTag5 = value;
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
        public FOpcSession fOpcSession
        {
            get
            {
                try
                {
                    return m_fOsn;
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

        //------------------------------------------------------------------------------------------------------------------------

        [Browsable(false)]
        public FOpcItem fOpcItem
        {
            get
            {
                try
                {
                    return m_fOit;
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
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DisplayNameAttribute("Name"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DisplayNameAttribute("Color"));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DisplayNameAttribute("Bold"));
                // --
                base.fTypeDescriptor.properties["ItemFormat"].attributes.replace(new DisplayNameAttribute("Item Format"));
                base.fTypeDescriptor.properties["ItemArray"].attributes.replace(new DisplayNameAttribute("Item Array"));
                // --                
                base.fTypeDescriptor.properties["Format"].attributes.replace(new DisplayNameAttribute("Format"));
                // --
                base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new DisplayNameAttribute("Scan Mode"));
                // --
                base.fTypeDescriptor.properties["ReservedWord"].attributes.replace(new DisplayNameAttribute("Reserved Word"));
                base.fTypeDescriptor.properties["Extraction"].attributes.replace(new DisplayNameAttribute("Extraction"));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DisplayNameAttribute(m_fOit.defUserTagName1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DisplayNameAttribute(m_fOit.defUserTagName2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DisplayNameAttribute(m_fOit.defUserTagName3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DisplayNameAttribute(m_fOit.defUserTagName4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DisplayNameAttribute(m_fOit.defUserTagName5));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fOit.fObjectType.ToString()));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fOit.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fOit.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fOit.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fOit.fontBold));
                // --
                base.fTypeDescriptor.properties["ItemFormat"].attributes.replace(new DefaultValueAttribute(m_fOit.fItemFormat));
                base.fTypeDescriptor.properties["ItemArray"].attributes.replace(new DefaultValueAttribute(m_fOit.itemArray));
                // --
                base.fTypeDescriptor.properties["Format"].attributes.replace(new DefaultValueAttribute(m_fOit.fFormat));
                // --
                base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new DefaultValueAttribute(m_fOit.fScanMode));
                // --
                base.fTypeDescriptor.properties["ReservedWord"].attributes.replace(new DefaultValueAttribute(m_fOit.reservedWord));
                base.fTypeDescriptor.properties["Extraction"].attributes.replace(new DefaultValueAttribute(m_fOit.extraction));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DefaultValueAttribute(m_fOit.userTag1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DefaultValueAttribute(m_fOit.userTag2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DefaultValueAttribute(m_fOit.userTag3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DefaultValueAttribute(m_fOit.userTag4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DefaultValueAttribute(m_fOit.userTag5));
                
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

        public string getDisplayValue(
            string value
            )
        {
            StringBuilder val = null;

            try
            {
                val = new StringBuilder();
                val.Append(value);
                if (val.Length > 1000)
                {
                    return val.ToString(0, 1000);
                }
                return val.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                val = null;
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
