/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropModelAlarm.cs
--  Creator         : tjkim
--  Create Date     : 2013.05.23
--  Description     : FAMate Admin Manager Model Alarm Property Source Object Class 
--  History         : Created by tjkim at 2013.05.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public class FPropTypeAlarm : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryAutoClear = "[02] Auto Clear";

        // --

        private bool m_disposed = false;
        // --
        private string m_type = string.Empty;
        private string m_alarmGroup = string.Empty;
        private string m_alarmId = string.Empty;
        private string m_description = string.Empty;
        private int m_autoClearTime = 4;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropTypeAlarm(
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
                m_alarmId = dt.Rows[0][2].ToString();
                m_description = dt.Rows[0][3].ToString();
                m_autoClearTime = int.Parse(dt.Rows[0][4].ToString());
            }

            // --

            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropTypeAlarm(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            string type,
            string alarmGroup
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_type = type;
            m_alarmGroup = alarmGroup;
            m_autoClearTime = 4;

            // --

            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropTypeAlarm(
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        public string AlarmId
        {
            get
            {
                try
                {
                    return m_alarmId;
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
                    m_alarmId = value;
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

        #region Auto Clear

        [Category(CategoryAutoClear)]
        public int AutoClearTime
        {
            get
            {
                try
                {
                    return m_autoClearTime;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return 4;
            }

            set
            {
                try
                {
                    if (value < 1 || value > 999)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // --

                    m_autoClearTime = value;
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
                base.fTypeDescriptor.properties["AlarmId"].attributes.replace(new DisplayNameAttribute("Alarm ID"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                base.fTypeDescriptor.properties["AutoClearTime"].attributes.replace(new DisplayNameAttribute("Clear Time (hour)"));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_type));
                base.fTypeDescriptor.properties["AlarmGroup"].attributes.replace(new DefaultValueAttribute(m_alarmGroup));
                base.fTypeDescriptor.properties["AlarmId"].attributes.replace(new DefaultValueAttribute(m_alarmId));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_description));
                base.fTypeDescriptor.properties["AutoClearTime"].attributes.replace(new DefaultValueAttribute(m_autoClearTime));
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
