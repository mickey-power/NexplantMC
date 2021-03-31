/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropUserGroup.cs
--  Creator         : kitae
--  Create Date     : 2012.04.03
--  Description     : FAMate Admin Manager UserGroup Property Source Object Class 
--  History         : Created by kitae at 2012.03.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public class FPropUser : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryGroup = "[02] Group";
        private const string CategoryContacts = "[03] Contacts";

        // --

        private bool m_disposed = false;
        // --
        private bool m_tranEnabled = false;
        // --
        private string m_userId = string.Empty;
        private string m_userName = string.Empty;
        private string m_description = string.Empty;
        private string m_userGroup = string.Empty;
        private string m_phoneOffice = string.Empty;
        private string m_phoneMobile = string.Empty;
        private string m_eMail = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropUser(
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

        public FPropUser(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            bool readOnly
            )
            : this(fAdmCore, fPropGrid, null, readOnly)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropUser(
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
        public string UserId
        {
            get
            {
                try
                {
                    return m_userId;
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
                    m_userId = value;
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
        public string UserName
        {
            get
            {
                try
                {
                    return m_userName;
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
                    m_userName = value;
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

        #region Group

        [Category(CategoryGroup)]
        [Editor(typeof(FPropAttrUserGroupUITypeEditor), typeof(UITypeEditor))]
        public string UserGroup
        {
            get
            {
                try
                {
                    return m_userGroup;
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

            internal set
            {
                try
                {
                    m_userGroup = value;
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

        #region Contacts

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
        public string EMail
        {
            get
            {
                try
                {
                    return m_eMail;
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
                    m_eMail = value;
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
                    m_userId = dt.Rows[0][0].ToString();
                    m_userName = dt.Rows[0][1].ToString();
                    m_description = dt.Rows[0][2].ToString();
                    m_userGroup = dt.Rows[0][3].ToString();
                    m_phoneOffice = dt.Rows[0][4].ToString();
                    m_phoneMobile = dt.Rows[0][5].ToString();
                    m_eMail = dt.Rows[0][6].ToString();
                }

                // --

                base.fTypeDescriptor.properties["UserId"].attributes.replace(new DisplayNameAttribute("User ID"));
                base.fTypeDescriptor.properties["UserName"].attributes.replace(new DisplayNameAttribute("User Name"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                base.fTypeDescriptor.properties["UserGroup"].attributes.replace(new DisplayNameAttribute("User Group"));
                base.fTypeDescriptor.properties["PhoneOffice"].attributes.replace(new DisplayNameAttribute("Phone Office"));
                base.fTypeDescriptor.properties["PhoneMobile"].attributes.replace(new DisplayNameAttribute("Phone Mobile"));
                base.fTypeDescriptor.properties["EMail"].attributes.replace(new DisplayNameAttribute("e-Mail"));
                
                // --

                base.fTypeDescriptor.properties["UserId"].attributes.replace(new DefaultValueAttribute(m_userId));
                base.fTypeDescriptor.properties["UserName"].attributes.replace(new DefaultValueAttribute(m_userName));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_description));
                base.fTypeDescriptor.properties["UserGroup"].attributes.replace(new DefaultValueAttribute(m_userGroup));
                base.fTypeDescriptor.properties["PhoneOffice"].attributes.replace(new DefaultValueAttribute(m_phoneOffice));
                base.fTypeDescriptor.properties["PhoneMobile"].attributes.replace(new DefaultValueAttribute(m_phoneMobile));
                base.fTypeDescriptor.properties["EMail"].attributes.replace(new DefaultValueAttribute(m_eMail));

                // --

                if (!m_tranEnabled)
                {
                    base.fTypeDescriptor.properties["UserId"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["UserName"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Description"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["UserGroup"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["PhoneOffice"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["PhoneMobile"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["EMail"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["UserGroup"].attributes.replace(new EditorAttribute("", typeof(UITypeEditor)));
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
