/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropPackage.cs
--  Creator         : kitae
--  Create Date     : 2012.03.22
--  Description     : FAMate Admin Manager Package Property Source Object Class 
--  History         : Created by kitae at 2012.03.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using System.Data;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public class FPropPackage : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryType = "[02] Type";
        private const string CategoryVersion = "[03] Version";

        // --

        private bool m_disposed = false;
        // --        
        private bool m_tranEnabled = false;
        // --
        private string m_package = string.Empty;
        private string m_description = string.Empty;
        private FEapType m_fType = FEapType.SECS;
        private string m_releaseVer = string.Empty;
        private string m_lastVer = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropPackage(
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

        public FPropPackage(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            bool tranEnabled
            )
            : this(fAdmCore, fPropGrid, null, tranEnabled)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropPackage(
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
        public string Package
        {
            get
            {
                try
                {
                    return m_package;
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
                    m_package = value;
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
        public FEapType Type
        {
            get
            {
                try
                {
                    return m_fType;
                }
                catch (Exception ex) 
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FEapType.SECS;
            }

            set
            {
                try
                {
                    m_fType = value;
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

        #region Version

        [Category(CategoryVersion)]
        public string ReleaseVersion
        {
            get
            {
                try
                {
                    return m_releaseVer;
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

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryVersion)]
        public string LastVersion
        {
            get
            {
                try
                {
                    return m_lastVer;
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

        #region Properties

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
                    m_package = dt.Rows[0][0].ToString();
                    m_description = dt.Rows[0][1].ToString();
                    m_fType = (FEapType)Enum.Parse(typeof(FEapType), dt.Rows[0][2].ToString());
                    m_releaseVer = dt.Rows[0][3].ToString();
                    m_lastVer = dt.Rows[0][4].ToString();
                }

                // --
                
                base.fTypeDescriptor.properties["Package"].attributes.replace(new DisplayNameAttribute("Package"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Type"));
                base.fTypeDescriptor.properties["ReleaseVersion"].attributes.replace(new DisplayNameAttribute("Release"));                
                base.fTypeDescriptor.properties["LastVersion"].attributes.replace(new DisplayNameAttribute("Last"));

                // --

                // ***
                // 2014.09.10 by spike.lee
                // 데이터 키 정의
                // ***
                base.fTypeDescriptor.properties["Package"].attributes.replace(new ParenthesizePropertyNameAttribute(true));

                // --

                base.fTypeDescriptor.properties["Package"].attributes.replace(new DefaultValueAttribute(m_package));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_description));
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fType));                
                base.fTypeDescriptor.properties["ReleaseVersion"].attributes.replace(new DefaultValueAttribute(m_releaseVer));
                base.fTypeDescriptor.properties["LastVersion"].attributes.replace(new DefaultValueAttribute(m_lastVer));

                // --

                if (!m_tranEnabled)
                {
                    base.fTypeDescriptor.properties["Package"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Type"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Description"].attributes.replace(new ReadOnlyAttribute(true));
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
