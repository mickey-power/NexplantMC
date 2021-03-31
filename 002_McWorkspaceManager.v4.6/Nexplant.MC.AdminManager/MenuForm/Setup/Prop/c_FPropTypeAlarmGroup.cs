/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropModelAlarmGroup.cs
--  Creator         : tjkim
--  Create Date     : 2013.05.22
--  Description     : FAMate Admin Manager Model Alarm Group Property Source Object Class 
--  History         : Created by mjkim at 2013.05.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public class FPropTypeAlarmGroup : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryAlarmLevel = "[02] Alarm Level";

        // --

        private bool m_disposed = false;
        // --
        private string m_type = string.Empty;
        private string m_alarmGroup = string.Empty;
        private string m_description = string.Empty;
        private FAlarmLevel m_alarmLevel = FAlarmLevel.Lowest;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropTypeAlarmGroup(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            DataTable dt
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            if (dt != null)
            {
                m_type = dt.Rows[0][0].ToString();
                m_alarmGroup = dt.Rows[0][1].ToString();
                m_description = dt.Rows[0][2].ToString();
                m_alarmLevel = (FAlarmLevel)Enum.Parse(typeof(FAlarmLevel), dt.Rows[0][3].ToString());
            }

            // --

            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropTypeAlarmGroup(
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

        ~FPropTypeAlarmGroup(
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
        public string AlarmGroup
        {
            get
            {
                try
                {
                    return m_alarmGroup;
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
                    m_alarmGroup = value;
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

        #region Alarm Level

        [Category(CategoryAlarmLevel)]
        public FAlarmLevel AlarmLevel
        {
            get
            {
                try
                {
                    return m_alarmLevel;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FAlarmLevel.Lowest;
            }
            set
            {
                try
                {
                    m_alarmLevel = value;
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
                base.fTypeDescriptor.properties["AlarmGroup"].attributes.replace(new DisplayNameAttribute("Alarm Group"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                base.fTypeDescriptor.properties["AlarmLevel"].attributes.replace(new DisplayNameAttribute("Alarm Level"));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_type));
                base.fTypeDescriptor.properties["AlarmGroup"].attributes.replace(new DefaultValueAttribute(m_alarmGroup));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_description));
                base.fTypeDescriptor.properties["AlarmLevel"].attributes.replace(new DefaultValueAttribute(m_alarmLevel));
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
