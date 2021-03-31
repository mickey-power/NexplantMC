/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropEquipment.cs
--  Creator         : mjkim
--  Create Date     : 2013.12.03
--  Description     : FAMate DCS Manager Equipment Property Source Object Class 
--  History         : Created by mjkim at 2013.12.03
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
    public class FPropEquipment : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryAttribute = "[02] Attribute";
        private const string CategoryRelation = "[03] Relation";
        
        // --

        private bool m_disposed = false;
        // --
        private bool m_tranEnabled = false;
        // --        
        private string m_equipment = string.Empty;
        private int m_equipmentId = 0;
        private string m_description = string.Empty;
        private FEquipmentClass m_class = FEquipmentClass.Standalone;
        private FYesNo m_deptSkipValidation = FYesNo.No;
        // --
        private FYesNo m_fmbMonitoring = FYesNo.No;
        private string m_ipAddress = string.Empty;
        // --
        private string m_type = string.Empty;
        private string m_area = string.Empty;
        private string m_line = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropEquipment(
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

        public FPropEquipment(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            bool readOnly
            )
            : this(fAdmCore, fPropGrid, null, readOnly)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropEquipment(
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

            set
            {
                try
                {
                    m_equipment = value;
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
        public int EquipmentId
        {
            get
            {
                try
                {
                    return m_equipmentId;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return 0;
            }

            set
            {
                try
                {
                    m_equipmentId = value;
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

        #region CategoryAttribute

        [Category(CategoryAttribute)]
        public FEquipmentClass Class
        {
            get
            {
                try
                {
                    return m_class;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FEquipmentClass.Standalone;
            }

            set
            {
                try
                {
                    m_class = value;
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

        [Category(CategoryAttribute)]
        public FYesNo DeptSkipValidation
        {
            get
            {
                try
                {
                    return m_deptSkipValidation;
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
                    m_deptSkipValidation = value;
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

        [Category(CategoryAttribute)]
        public FYesNo FmbMonitoring
        {
            get
            {
                try
                {
                    return m_fmbMonitoring;
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
                    m_fmbMonitoring = value;
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

        [Category(CategoryAttribute)]
        public string IpAddress
        {
            get
            {
                try
                {
                    return m_ipAddress;
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
                    m_ipAddress = value;
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

        #region CategoryRelation

        [Category(CategoryRelation)]
        [Editor(typeof(FPropAttrEquipmentTypeUITypeEditor), typeof(UITypeEditor))]
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

            internal set
            {
                try
                {
                    m_type = value;
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

        [Category(CategoryRelation)]
        [Editor(typeof(FPropAttrEquipmentAreaUITypeEditor), typeof(UITypeEditor))]
        public string Area
        {
            get
            {
                try
                {
                    return m_area;
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

            internal set
            {
                try
                {
                    m_area = value;
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

        [Category(CategoryRelation)]
        [Editor(typeof(FPropAttrEquipmentLineUITypeEditor), typeof(UITypeEditor))]
        public string Line
        {
            get
            {
                try
                {
                    return m_line;
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

            internal set
            {
                try
                {
                    m_line = value;
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
                    m_equipment = dt.Rows[0][0].ToString();
                    m_equipmentId = int.Parse(dt.Rows[0][1].ToString());
                    m_description = dt.Rows[0][2].ToString();
                    m_class = (FEquipmentClass)Enum.Parse(typeof(FEquipmentClass), dt.Rows[0][3].ToString());
                    m_deptSkipValidation = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][4].ToString());
                    m_type = dt.Rows[0][5].ToString();
                    m_area = dt.Rows[0][6].ToString();
                    m_line = dt.Rows[0][7].ToString();
                    m_fmbMonitoring = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][8].ToString());
                    m_ipAddress =dt.Rows[0][9].ToString();
                }

                // --

                base.fTypeDescriptor.properties["Equipment"].attributes.replace(new DisplayNameAttribute("Equipment"));
                base.fTypeDescriptor.properties["EquipmentId"].attributes.replace(new DisplayNameAttribute("Equipment ID"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                // --
                base.fTypeDescriptor.properties["Class"].attributes.replace(new DisplayNameAttribute("Equipment Class"));
                base.fTypeDescriptor.properties["DeptSkipValidation"].attributes.replace(new DisplayNameAttribute("Dept. Skip Validation"));
                base.fTypeDescriptor.properties["FmbMonitoring"].attributes.replace(new DisplayNameAttribute("FMB Monitoring"));
                base.fTypeDescriptor.properties["IpAddress"].attributes.replace(new DisplayNameAttribute("Ip Address"));
                // --
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Equipment Type"));
                base.fTypeDescriptor.properties["Area"].attributes.replace(new DisplayNameAttribute("Equipment Area"));
                base.fTypeDescriptor.properties["Line"].attributes.replace(new DisplayNameAttribute("Equipment Line"));

                // --

                // ***
                // 2014.09.10 by spike.lee
                // 데이터 키 정의
                // ***
                base.fTypeDescriptor.properties["Equipment"].attributes.replace(new ParenthesizePropertyNameAttribute(true));

                // --

                base.fTypeDescriptor.properties["Equipment"].attributes.replace(new DefaultValueAttribute(m_equipment));
                base.fTypeDescriptor.properties["EquipmentId"].attributes.replace(new DefaultValueAttribute(m_equipmentId));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_description));
                // --
                base.fTypeDescriptor.properties["Class"].attributes.replace(new DefaultValueAttribute(m_class));
                base.fTypeDescriptor.properties["DeptSkipValidation"].attributes.replace(new DefaultValueAttribute(m_deptSkipValidation));
                base.fTypeDescriptor.properties["FmbMonitoring"].attributes.replace(new DefaultValueAttribute(m_fmbMonitoring));
                base.fTypeDescriptor.properties["IpAddress"].attributes.replace(new DefaultValueAttribute(m_ipAddress));
                // --
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_type));
                base.fTypeDescriptor.properties["Area"].attributes.replace(new DefaultValueAttribute(m_area));
                base.fTypeDescriptor.properties["Line"].attributes.replace(new DefaultValueAttribute(m_line));

                // --

                if (!m_tranEnabled)
                {
                    base.fTypeDescriptor.properties["Equipment"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["EquipmentId"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Description"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["Class"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["DeptSkipValidation"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["FmbMonitoring"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["IpAddress"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["Type"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Area"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Line"].attributes.replace(new ReadOnlyAttribute(true));

                    // --

                    base.fTypeDescriptor.properties["Type"].attributes.replace(new EditorAttribute(string.Empty, typeof(UITypeEditor)));
                    base.fTypeDescriptor.properties["Area"].attributes.replace(new EditorAttribute(string.Empty, typeof(UITypeEditor)));
                    base.fTypeDescriptor.properties["Line"].attributes.replace(new EditorAttribute(string.Empty, typeof(UITypeEditor)));
                }

                // --

                base.fTypeDescriptor.properties["DeptSkipValidation"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["FmbMonitoring"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["EquipmentId"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["Class"].attributes.replace(new BrowsableAttribute(false));
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
