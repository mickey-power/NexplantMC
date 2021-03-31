/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropEquipmentTypeState.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.07.09
--  Description     : FAMate Admin Manager Equipment Type State Property Source Object Class 
--  History         : Created by jungyoul.moon at 2013.07.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public class FPropEquipmentTypeState : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryDefault = "[02] Default";

        // --

        private bool m_disposed = false;
        // --
        private string m_type = string.Empty;
        private string m_state = string.Empty;
        private FEquipmentPrimaryState m_priState = FEquipmentPrimaryState.POWER_OFF;
        private string m_default = FYesNo.No.ToString();

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropEquipmentTypeState(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            DataTable dt
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            if (dt != null)
            {
                m_type = dt.Rows[0][0].ToString();
                m_state = dt.Rows[0][1].ToString();
                m_priState = (FEquipmentPrimaryState)Enum.Parse(typeof(FEquipmentPrimaryState), dt.Rows[0][2].ToString());
                m_default = dt.Rows[0][3].ToString();
            }

            // --

            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropEquipmentTypeState(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            string type
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_type = type;

            // --

            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropEquipmentTypeState(
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
        public string Type
        {
            get
            {
                try
                {
                    return m_type;
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
        public string State
        {
            get
            {
                try
                {
                    return m_state;
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
                    m_state = value;
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
        public FEquipmentPrimaryState PriState
        {
            get
            {
                try
                {
                    return m_priState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FEquipmentPrimaryState.POWER_OFF;
            }
            set
            {
                try
                {
                    m_priState = value;
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

        #region Default

        [Category(CategoryDefault)]
        public FYesNo Default
        {
            get
            {
                try
                {
                    return (FYesNo)Enum.Parse(typeof(FYesNo), m_default);
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
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
                    m_default = value.ToString();
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
            )
        {
            try
            {
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Type"));
                base.fTypeDescriptor.properties["State"].attributes.replace(new DisplayNameAttribute("State"));
                base.fTypeDescriptor.properties["PriState"].attributes.replace(new DisplayNameAttribute("Primary State"));
                base.fTypeDescriptor.properties["Default"].attributes.replace(new DisplayNameAttribute("Default"));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_type));
                base.fTypeDescriptor.properties["State"].attributes.replace(new DefaultValueAttribute(m_state));
                base.fTypeDescriptor.properties["PriState"].attributes.replace(new DefaultValueAttribute(m_priState));
                base.fTypeDescriptor.properties["Default"].attributes.replace(new DefaultValueAttribute(m_default));
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
