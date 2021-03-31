/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropMakerGroup.cs
--  Creator         : tjkim
--  Create Date     : 2012.05.21
--  Description     : FAMate Admin Manager Maker Property Source Object Class 
--  History         : Created by tjkim at 2012.05.21
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
    public class FPropMaker : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryContacts = "[02] Contacts";

        // --

        private bool m_disposed = false;
        // --
        private bool m_tranEnabled = false;
        // --
        private string m_maker = string.Empty;
        private string m_description = string.Empty;
        private string m_engineer = string.Empty;
        private string m_phoneOffice = string.Empty;
        private string m_phoneMobile = string.Empty;
        private string m_eMailId = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropMaker(
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

        public FPropMaker(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            bool readOnly
            )
            : this(fAdmCore, fPropGrid, null, readOnly)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropMaker(
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
        public string Maker
        {
            get
            {
                try
                {
                    return m_maker;
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
                    m_maker = value;
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

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryContacts)]
        public string Engineer
        {
            get
            {
                try
                {
                    return m_engineer;
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
                    m_engineer = value;
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

        [Category(CategoryContacts)]
        public string PhoneOffice
        {
            get
            {
                try
                {
                    return m_phoneOffice;
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
                    m_phoneOffice = value;
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

        [Category(CategoryContacts)]
        public string PhoneMobile
        {
            get
            {
                try
                {
                    return m_phoneMobile;
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
                    m_phoneMobile = value;
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

        [Category(CategoryContacts)]
        public string EmailId
        {
            get
            {
                try
                {
                    return m_eMailId;
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
                    m_eMailId = value;
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
            DataTable dt
            )
        {
            try
            {
                if (dt != null)
                {
                    m_maker = dt.Rows[0][0].ToString();
                    m_description = dt.Rows[0][1].ToString();
                    m_engineer = dt.Rows[0][2].ToString();
                    m_phoneOffice = dt.Rows[0][3].ToString();
                    m_phoneMobile = dt.Rows[0][4].ToString();
                    m_eMailId = dt.Rows[0][5].ToString();
                }

                // --

                base.fTypeDescriptor.properties["Maker"].attributes.replace(new DisplayNameAttribute("Maker"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                base.fTypeDescriptor.properties["Engineer"].attributes.replace(new DisplayNameAttribute("Engineer"));
                base.fTypeDescriptor.properties["PhoneOffice"].attributes.replace(new DisplayNameAttribute("Phone Office"));
                base.fTypeDescriptor.properties["PhoneMobile"].attributes.replace(new DisplayNameAttribute("Phone Mobile"));
                base.fTypeDescriptor.properties["EmailId"].attributes.replace(new DisplayNameAttribute("e-Mail"));
                
                // --

                // ***
                // 2014.09.10 by spike.lee
                // 데이터 키 정의
                // ***
                base.fTypeDescriptor.properties["Maker"].attributes.replace(new ParenthesizePropertyNameAttribute(true));

                // --
                
                base.fTypeDescriptor.properties["Maker"].attributes.replace(new DefaultValueAttribute(m_maker));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_description));
                base.fTypeDescriptor.properties["Engineer"].attributes.replace(new DefaultValueAttribute(m_engineer));
                base.fTypeDescriptor.properties["PhoneOffice"].attributes.replace(new DefaultValueAttribute(m_phoneOffice));
                base.fTypeDescriptor.properties["PhoneMobile"].attributes.replace(new DefaultValueAttribute(m_phoneMobile));
                base.fTypeDescriptor.properties["EmailId"].attributes.replace(new DefaultValueAttribute(m_eMailId));

                // --

                if (!m_tranEnabled)
                {
                    base.fTypeDescriptor.properties["Maker"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Description"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Engineer"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["PhoneOffice"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["PhoneMobile"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["EmailId"].attributes.replace(new ReadOnlyAttribute(true));
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
