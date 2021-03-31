/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropUserGroupFunction.cs
--  Creator         : mjkim
--  Create Date     : 2013.01.29
--  Description     : FAMate Admin Manager User Group Function Property Source Object Class 
--  History         : Created by mjkim at 2013.01.29
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public class FPropUserGroupFunction : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryTransaction = "[02] Transaction";

        // --

        private bool m_disposed = false;
        // --
        private bool m_tranEnabled = false;
        // --
        private string m_application = string.Empty;
        private string m_function = string.Empty;
        private string m_description = string.Empty;
        private FYesNo m_usedTransaction = FYesNo.No; 

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropUserGroupFunction(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            string application,
            DataTable dt,
            bool tranEnabled
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_application = application;
            m_tranEnabled = tranEnabled;
            // --
            init(dt);   
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropUserGroupFunction(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            string application,
            bool tranEnabled
            )
            : this(fAdmCore, fPropGrid, application, null, tranEnabled)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropUserGroupFunction(
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
        public string Application
        {
            get
            {
                try
                {
                    return m_application;
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
        public string Function
        {
            get
            {
                try
                {
                    return m_function;
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
                    m_function = value;
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

        #region Transaction

        [Category(CategoryTransaction)]
        public FYesNo UsedTransaction
        {
            get
            {
                try
                {
                    return m_usedTransaction;
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
            set
            {
                try
                {
                    m_usedTransaction = value;
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
                    m_function = dt.Rows[0][1].ToString();
                    m_description = dt.Rows[0][2].ToString();
                    m_usedTransaction = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][3].ToString());
                }

                // --

                base.fTypeDescriptor.properties["Application"].attributes.replace(new DisplayNameAttribute("Application"));
                base.fTypeDescriptor.properties["Function"].attributes.replace(new DisplayNameAttribute("Function"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                base.fTypeDescriptor.properties["UsedTransaction"].attributes.replace(new DisplayNameAttribute("Used Transaction"));                

                // --

                base.fTypeDescriptor.properties["Application"].attributes.replace(new DefaultValueAttribute(m_application));
                base.fTypeDescriptor.properties["Function"].attributes.replace(new DefaultValueAttribute(m_function));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_description));
                base.fTypeDescriptor.properties["UsedTransaction"].attributes.replace(new DefaultValueAttribute(m_usedTransaction));

                // --

                if (!m_tranEnabled)
                {
                    base.fTypeDescriptor.properties["Application"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Function"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Description"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["UsedTransaction"].attributes.replace(new ReadOnlyAttribute(true));
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
