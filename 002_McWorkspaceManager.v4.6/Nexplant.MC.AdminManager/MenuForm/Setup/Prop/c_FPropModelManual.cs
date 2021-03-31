/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropModelManual.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2014.01.16
--  Description     : FAMate Admin Manager Model Manual Property Source Object Class 
--  History         : Created by jungyoul.moon at 2014.01.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public class FPropModelManual : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryType = "[02] Type";
        private const string CategoryManualFile = "[03] Manual File";

        // --

        private bool m_disposed = false;
        // --
        private bool m_tranEnabled = false;
        // --
        private string m_model = string.Empty;
        private string m_manualName = string.Empty;
        private string m_description = string.Empty;
        private string m_manualType = string.Empty;
        private string m_manualPath = string.Empty;
        private string m_oldFile = string.Empty;
        private string m_newFile = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropModelManual(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            DataTable dt,
            bool tranEnabled
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_tranEnabled = tranEnabled;
            
            // --

            init(dt);   
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropModelManual(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            string model,
            bool tranEnabled
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_model = model;
            m_tranEnabled = tranEnabled;

            // --

            init(null);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropModelManual(
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
        public string Model
        {
            get
            {
                try
                {
                    return m_model;
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
        public string ManualName
        {
            get
            {
                try
                {
                    return m_manualName;
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
                    m_manualName = value;
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

        #region Type

        [Category(CategoryType)]
        [Editor(typeof(FPropAttrGeneralCodeDataUITypeEditor), typeof(UITypeEditor))]
        public string ManualType
        {
            get
            {
                try
                {
                    return m_manualType;
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
                    m_manualType = value;
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

        #region Manual File

        [Category(CategoryManualFile)]
        [Editor(typeof(FPropAttrFileBrowserUITypeEditor), typeof(UITypeEditor))]
        public string File
        {
            get
            {                
                try
                {
                    if (m_newFile == string.Empty)
                    {
                        return m_manualPath;
                    }
                    return m_newFile;
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
        public FYesNo FileChange
        {
            get
            {
                try
                {
                    if (m_newFile != string.Empty &&
                        m_newFile != m_oldFile
                        )
                    {
                        return FYesNo.Yes;
                    }
                    return FYesNo.No;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FYesNo.No;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Browsable(false)]
        public string OldFile
        {
            get
            {
                try
                {
                    return m_oldFile;
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
        public string NewFile
        {
            get
            {
                try
                {
                    return m_newFile;
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

            set
            {
                try
                {
                    m_newFile = value;
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

        #region Methods

        private void init(
            DataTable dt
            )
        {            
            try
            {
                if (dt != null)
                {
                    m_model = dt.Rows[0][0].ToString();
                    m_manualName = dt.Rows[0][1].ToString();
                    m_description = dt.Rows[0][2].ToString();
                    m_manualType = dt.Rows[0][3].ToString();
                    m_oldFile = dt.Rows[0][4].ToString();
                    m_manualPath = dt.Rows[0][5].ToString();
                }

                // --

                base.fTypeDescriptor.properties["Model"].attributes.replace(new DisplayNameAttribute("Model"));
                base.fTypeDescriptor.properties["ManualName"].attributes.replace(new DisplayNameAttribute("Manual Name"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                base.fTypeDescriptor.properties["ManualType"].attributes.replace(new DisplayNameAttribute("Manual Type"));
                base.fTypeDescriptor.properties["File"].attributes.replace(new DisplayNameAttribute("File"));

                // --

                // ***
                // 2014.09.10 by spike.lee
                // 데이터 키 정의
                // ***
                base.fTypeDescriptor.properties["Model"].attributes.replace(new ParenthesizePropertyNameAttribute(true));
                base.fTypeDescriptor.properties["ManualName"].attributes.replace(new ParenthesizePropertyNameAttribute(true));

                // --

                base.fTypeDescriptor.properties["Model"].attributes.replace(new DefaultValueAttribute(m_model));
                base.fTypeDescriptor.properties["ManualName"].attributes.replace(new DefaultValueAttribute(m_manualName));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_description));
                base.fTypeDescriptor.properties["ManualType"].attributes.replace(new DefaultValueAttribute(m_manualType));
                base.fTypeDescriptor.properties["File"].attributes.replace(new DefaultValueAttribute(m_manualPath));

                // --

                if (!m_tranEnabled)
                {
                    base.fTypeDescriptor.properties["Model"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["ManualName"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Description"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["ManualType"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["File"].attributes.replace(new ReadOnlyAttribute(true));

                    // --

                    base.fTypeDescriptor.properties["ManualType"].attributes.replace(new EditorAttribute("", typeof(UITypeEditor)));
                    base.fTypeDescriptor.properties["File"].attributes.replace(new EditorAttribute("", typeof(UITypeEditor)));
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
