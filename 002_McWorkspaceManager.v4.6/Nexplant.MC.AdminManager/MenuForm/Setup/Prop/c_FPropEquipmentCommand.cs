/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropEquipmentCommand.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2015.10.15
--  Description     : FAMate Admin Manager Equipment Command Property Source Object Class 
--  History         : Created by Jeff.Kim at 2015.10.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public class FPropEquipmentCommand : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryTimeOut = "[02] Time Out";

        // --

        private bool m_disposed = false;
        // --
        private string m_equipment = string.Empty;
        private string m_commandId = string.Empty;
        private string m_description = string.Empty;
        private int m_timeOut = 5;
        // --
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropEquipmentCommand(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            DataTable dt,
            bool tranEnabled
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            if (dt != null)
            {
                m_equipment = dt.Rows[0][0].ToString();
                m_commandId = dt.Rows[0][1].ToString();
                m_description = dt.Rows[0][2].ToString();
                m_timeOut = int.Parse(dt.Rows[0][3].ToString());
            }

            m_tranEnabled = tranEnabled;
            // --

            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropEquipmentCommand(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            string equipment,
            bool tranEnabled
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_tranEnabled = tranEnabled;
            
            // --

            m_equipment = equipment;
            m_timeOut = 5;

            // --

            init();
        }
                
        //------------------------------------------------------------------------------------------------------------------------

        ~FPropEquipmentCommand(
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
        public string Equipment
        {
            get
            {
                try
                {
                    return m_equipment;
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
        public string CommandId
        {
            get
            {
                try
                {
                    return m_commandId;
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
                    m_commandId = value;
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

        #region Time Out

        [Category(CategoryTimeOut)]
        public int TimeOut
        {
            get
            {
                try
                {
                    return m_timeOut;
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

                    m_timeOut = value;
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
                base.fTypeDescriptor.properties["Equipment"].attributes.replace(new DisplayNameAttribute("Equipment"));                
                base.fTypeDescriptor.properties["CommandId"].attributes.replace(new DisplayNameAttribute("Command ID"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                base.fTypeDescriptor.properties["TimeOut"].attributes.replace(new DisplayNameAttribute("Time Out (sec)"));

                // --

                base.fTypeDescriptor.properties["Equipment"].attributes.replace(new DefaultValueAttribute(m_equipment));                
                base.fTypeDescriptor.properties["CommandId"].attributes.replace(new DefaultValueAttribute(m_commandId));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_description));
                base.fTypeDescriptor.properties["TimeOut"].attributes.replace(new DefaultValueAttribute(m_timeOut));
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
