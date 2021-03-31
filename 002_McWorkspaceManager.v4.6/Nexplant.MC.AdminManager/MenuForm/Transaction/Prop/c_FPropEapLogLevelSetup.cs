/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropEapLogLevelSetup.cs
--  Creator         : spike.lee
--  Create Date     : 2017.07.05
--  Description     : FAmate Admin Manager EAP Log Level Setup Property Source Object Class 
--  History         : Created by spike.lee at 2017.07.05
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
    public class FPropEapLogLevelSetup : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryLogLevel = "[02] Log Level";
        
        // --

        private bool m_disposed = false;
        // --
        private string[] m_logLevelCap = null;
        private bool m_tranEnabled = false;
        // --        
        private string m_eqp = string.Empty;
        private string m_description = string.Empty;
        // --
        private FYesNo m_logLevel1 = FYesNo.Yes;
        private FYesNo m_logLevel2 = FYesNo.No;
        private FYesNo m_logLevel3 = FYesNo.No;
        private FYesNo m_logLevel4 = FYesNo.No;
        private FYesNo m_logLevel5 = FYesNo.No;
        private FYesNo m_logLevel6 = FYesNo.No;
        private FYesNo m_logLevel7 = FYesNo.No;
        private FYesNo m_logLevel8 = FYesNo.No;
        private FYesNo m_logLevel9 = FYesNo.No;
        private FYesNo m_logLevel10 = FYesNo.No;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropEapLogLevelSetup(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            string[] logLevelCap,
            DataTable dt,
            bool tranEnabled
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_logLevelCap = logLevelCap;
            m_tranEnabled = tranEnabled;
            // --
            init(dt);   
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropEapLogLevelSetup(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            string[] logLevelCap,
            bool readOnly
            )
            : this(fAdmCore, fPropGrid, logLevelCap, null, readOnly)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropEapLogLevelSetup(
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
        public string MC
        {
            get
            {
                try
                {
                    return m_eqp;
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

        #region Log Level

        [Category(CategoryLogLevel)]        
        public FYesNo LogLevel1
        {
            get
            {
                try
                {
                    return m_logLevel1;
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
                    m_logLevel1 = value;
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

        [Category(CategoryLogLevel)]
        public FYesNo LogLevel2
        {
            get
            {
                try
                {
                    return m_logLevel2;
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
                    m_logLevel2 = value;
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

        [Category(CategoryLogLevel)]
        public FYesNo LogLevel3
        {
            get
            {
                try
                {
                    return m_logLevel3;
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
                    m_logLevel3 = value;
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

        [Category(CategoryLogLevel)]
        public FYesNo LogLevel4
        {
            get
            {
                try
                {
                    return m_logLevel4;
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
                    m_logLevel4 = value;
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

        [Category(CategoryLogLevel)]
        public FYesNo LogLevel5
        {
            get
            {
                try
                {
                    return m_logLevel5;
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
                    m_logLevel5 = value;
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

        [Category(CategoryLogLevel)]
        public FYesNo LogLevel6
        {
            get
            {
                try
                {
                    return m_logLevel6;
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
                    m_logLevel6 = value;
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

        [Category(CategoryLogLevel)]
        public FYesNo LogLevel7
        {
            get
            {
                try
                {
                    return m_logLevel7;
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
                    m_logLevel7 = value;
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

        [Category(CategoryLogLevel)]
        public FYesNo LogLevel8
        {
            get
            {
                try
                {
                    return m_logLevel8;
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
                    m_logLevel8 = value;
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

        [Category(CategoryLogLevel)]
        public FYesNo LogLevel9
        {
            get
            {
                try
                {
                    return m_logLevel9;
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
                    m_logLevel9 = value;
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

        [Category(CategoryLogLevel)]
        public FYesNo LogLevel10
        {
            get
            {
                try
                {
                    return m_logLevel10;
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
                    m_logLevel10 = value;
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
                    m_eqp = dt.Rows[0][0].ToString();
                    m_description = dt.Rows[0][1].ToString();
                    // --
                    if (dt.Rows[0][2].ToString().Trim() != string.Empty)
                    {
                        m_logLevel1 = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][2].ToString());
                    }
                    if (dt.Rows[0][3].ToString().Trim() != string.Empty)
                    {
                        m_logLevel2 = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][3].ToString());
                    }
                    if (dt.Rows[0][4].ToString().Trim() != string.Empty)
                    {
                        m_logLevel3 = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][4].ToString());
                    }
                    if (dt.Rows[0][5].ToString().Trim() != string.Empty)
                    {
                        m_logLevel4 = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][5].ToString());
                    }
                    if (dt.Rows[0][6].ToString().Trim() != string.Empty)
                    {
                        m_logLevel5 = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][6].ToString());
                    }
                    if (dt.Rows[0][7].ToString().Trim() != string.Empty)
                    {
                        m_logLevel6 = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][7].ToString());
                    }
                    if (dt.Rows[0][8].ToString().Trim() != string.Empty)
                    {
                        m_logLevel7 = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][8].ToString());
                    }
                    if (dt.Rows[0][9].ToString().Trim() != string.Empty)
                    {
                        m_logLevel8 = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][9].ToString());
                    }
                    if (dt.Rows[0][10].ToString().Trim() != string.Empty)
                    {
                        m_logLevel9 = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][10].ToString());
                    }
                    if (dt.Rows[0][11].ToString().Trim() != string.Empty)
                    {
                        m_logLevel10 = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][11].ToString());
                    }
                }

                // --

                base.fTypeDescriptor.properties["EAP"].attributes.replace(new DisplayNameAttribute("EAP"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                // --
                base.fTypeDescriptor.properties["LogLevel1"].attributes.replace(new DisplayNameAttribute(m_logLevelCap[0]));
                base.fTypeDescriptor.properties["LogLevel2"].attributes.replace(new DisplayNameAttribute(m_logLevelCap[1]));
                base.fTypeDescriptor.properties["LogLevel3"].attributes.replace(new DisplayNameAttribute(m_logLevelCap[2]));
                base.fTypeDescriptor.properties["LogLevel4"].attributes.replace(new DisplayNameAttribute(m_logLevelCap[3]));
                base.fTypeDescriptor.properties["LogLevel5"].attributes.replace(new DisplayNameAttribute(m_logLevelCap[4]));
                base.fTypeDescriptor.properties["LogLevel6"].attributes.replace(new DisplayNameAttribute(m_logLevelCap[5]));
                base.fTypeDescriptor.properties["LogLevel7"].attributes.replace(new DisplayNameAttribute(m_logLevelCap[6]));
                base.fTypeDescriptor.properties["LogLevel8"].attributes.replace(new DisplayNameAttribute(m_logLevelCap[7]));
                base.fTypeDescriptor.properties["LogLevel9"].attributes.replace(new DisplayNameAttribute(m_logLevelCap[8]));
                base.fTypeDescriptor.properties["LogLevel10"].attributes.replace(new DisplayNameAttribute(m_logLevelCap[9]));

                // --

                base.fTypeDescriptor.properties["EAP"].attributes.replace(new ParenthesizePropertyNameAttribute(true));

                // --

                base.fTypeDescriptor.properties["EAP"].attributes.replace(new DefaultValueAttribute(m_eqp));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_description));
                // --
                base.fTypeDescriptor.properties["LogLevel1"].attributes.replace(new DefaultValueAttribute(m_logLevel1));
                base.fTypeDescriptor.properties["LogLevel2"].attributes.replace(new DefaultValueAttribute(m_logLevel2));
                base.fTypeDescriptor.properties["LogLevel3"].attributes.replace(new DefaultValueAttribute(m_logLevel3));
                base.fTypeDescriptor.properties["LogLevel4"].attributes.replace(new DefaultValueAttribute(m_logLevel4));
                base.fTypeDescriptor.properties["LogLevel5"].attributes.replace(new DefaultValueAttribute(m_logLevel5));
                base.fTypeDescriptor.properties["LogLevel6"].attributes.replace(new DefaultValueAttribute(m_logLevel6));
                base.fTypeDescriptor.properties["LogLevel7"].attributes.replace(new DefaultValueAttribute(m_logLevel7));
                base.fTypeDescriptor.properties["LogLevel8"].attributes.replace(new DefaultValueAttribute(m_logLevel8));
                base.fTypeDescriptor.properties["LogLevel9"].attributes.replace(new DefaultValueAttribute(m_logLevel9));
                base.fTypeDescriptor.properties["LogLevel10"].attributes.replace(new DefaultValueAttribute(m_logLevel10));

                // --

                if (!m_tranEnabled)
                {
                    base.fTypeDescriptor.properties["LogLevel1"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["LogLevel2"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["LogLevel3"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["LogLevel4"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["LogLevel5"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["LogLevel6"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["LogLevel7"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["LogLevel8"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["LogLevel9"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["LogLevel10"].attributes.replace(new ReadOnlyAttribute(true));                    
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
