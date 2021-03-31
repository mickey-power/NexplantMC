/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropMainEquipment.cs
--  Creator         : iskim
--  Create Date     : 2014.09.10
--  Description     : FAMate DCS Manager Main Equipment Property Source Object Class 
--  History         : Created by iskim at 2014.09.10
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
    public class FPropMainEquipment : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryRelation = "[02] Relation";
        
        // --

        private bool m_disposed = false;
        // --
        private bool m_tranEnabled = false;
        // --        
        private string m_equipment = string.Empty;
        private int m_equipmentId = 0;
        private string m_description = string.Empty;
        private string m_type = string.Empty;
        private string m_area = string.Empty;
        private string m_line = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropMainEquipment(
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

        public FPropMainEquipment(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            bool readOnly
            )
            : this(fAdmCore, fPropGrid, null, readOnly)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropMainEquipment(
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region CategoryRelation

        [Category(CategoryRelation)]
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

        [Category(CategoryRelation)]
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryRelation)]
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
                    m_type = dt.Rows[0][3].ToString();
                    m_area = dt.Rows[0][4].ToString();
                    m_line = dt.Rows[0][5].ToString();
                }

                // --

                base.fTypeDescriptor.properties["Equipment"].attributes.replace(new DisplayNameAttribute("Equipment"));
                base.fTypeDescriptor.properties["EquipmentId"].attributes.replace(new DisplayNameAttribute("Equipment ID"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                // --
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Equipment Type"));
                base.fTypeDescriptor.properties["Area"].attributes.replace(new DisplayNameAttribute("Equipment Area"));
                base.fTypeDescriptor.properties["Line"].attributes.replace(new DisplayNameAttribute("Equipment Line"));

                // --

                base.fTypeDescriptor.properties["Equipment"].attributes.replace(new DefaultValueAttribute(m_equipment));
                base.fTypeDescriptor.properties["EquipmentId"].attributes.replace(new DefaultValueAttribute(m_equipmentId));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_description));
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
                    base.fTypeDescriptor.properties["Type"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Area"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Line"].attributes.replace(new ReadOnlyAttribute(true));

                    // --

                    base.fTypeDescriptor.properties["Type"].attributes.replace(new EditorAttribute(string.Empty, typeof(UITypeEditor)));
                    base.fTypeDescriptor.properties["Area"].attributes.replace(new EditorAttribute(string.Empty, typeof(UITypeEditor)));
                    base.fTypeDescriptor.properties["Line"].attributes.replace(new EditorAttribute(string.Empty, typeof(UITypeEditor)));
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
