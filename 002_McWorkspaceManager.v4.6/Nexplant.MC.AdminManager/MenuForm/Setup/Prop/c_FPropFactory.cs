/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropFactory.cs
--  Creator         : mj.kim
--  Create Date     : 2012.01.09
--  Description     : FAMate Admin Manager Factory Property Source Object Class 
--  History         : Created by mj.kim at 2012.01.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Data;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public class FPropFactory : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryServerResourceRange = "[02] Server Resource Range";
        private const string CategoryEapResourceRange = "[03] MC Resource Range";
        private const string CategoryEapLogLevelCaption = "[04] MC Log Level Caption";

        // --

        private bool m_disposed = false;
        // --
        private bool m_tranEnabled = false;
        // --
        private string m_factory = string.Empty;
        private string m_description = string.Empty;
        // --
        private int m_serverCpuDangerRate = 0;
        private int m_serverCpuCautionRate = 0;
        private int m_serverMemoryDangerRate = 0;
        private int m_serverMemoryCautionRate = 0;
        private int m_serverDiskDangerRate = 0;
        private int m_serverDiskCautionRate = 0;
        // --
        private int m_eapCpuDangerRate = 0;
        private int m_eapCpuCautionRate = 0;
        private int m_eapMemoryDangerRate = 0;
        private int m_eapMemoryCautionRate = 0;
        private int m_eapDiskDangerRate = 0;
        private int m_eapDiskCautionRate = 0;
        private int m_eapReloadLimit = 0;
        // --
        private string m_logLevel1 = string.Empty;
        private string m_logLevel2 = string.Empty;
        private string m_logLevel3 = string.Empty;
        private string m_logLevel4 = string.Empty;
        private string m_logLevel5 = string.Empty;
        private string m_logLevel6 = string.Empty;
        private string m_logLevel7 = string.Empty;
        private string m_logLevel8 = string.Empty;
        private string m_logLevel9 = string.Empty;
        private string m_logLevel10 = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropFactory(
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

        public FPropFactory(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            bool readOnly
            )
            : this(fAdmCore, fPropGrid, null, readOnly)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropFactory(
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
        public string Factory
        {
            get
            {
                try
                {
                    return m_factory;
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
                    m_factory = value;
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

        #region Server Resource Range

        [Category(CategoryServerResourceRange)]
        public int ServerCpuDangerRate
        {
            get
            {
                try
                {
                    return m_serverCpuDangerRate;
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
                    m_serverCpuDangerRate = value;
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

        [Category(CategoryServerResourceRange)]
        public int ServerCpuCautionRate
        {
            get
            {
                try
                {
                    return m_serverCpuCautionRate;
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
                    m_serverCpuCautionRate = value;
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

        [Category(CategoryServerResourceRange)]
        public int ServerMemoryDangerRate
        {
            get
            {
                try
                {
                    return m_serverMemoryDangerRate;
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
                    m_serverMemoryDangerRate = value;
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

        [Category(CategoryServerResourceRange)]
        public int ServerMemoryCautionRate
        {
            get
            {
                try
                {
                    return m_serverMemoryCautionRate;
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
                    m_serverMemoryCautionRate = value;
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

        [Category(CategoryServerResourceRange)]
        public int ServerDiskDangerRate
        {
            get
            {
                try
                {
                    return m_serverDiskDangerRate;
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
                    m_serverDiskDangerRate = value;
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

        [Category(CategoryServerResourceRange)]
        public int ServerDiskCautionRate
        {
            get
            {
                try
                {
                    return m_serverDiskCautionRate;
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
                    m_serverDiskCautionRate = value;
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

        #region EAP Resource Range

        [Category(CategoryEapResourceRange)]
        public int EapCpuDangerRate
        {
            get
            {
                try
                {
                    return m_eapCpuDangerRate;
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
                    m_eapCpuDangerRate = value;
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

        [Category(CategoryEapResourceRange)]
        public int EapCpuCautionRate
        {
            get
            {
                try
                {
                    return m_eapCpuCautionRate;
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
                    m_eapCpuCautionRate = value;
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

        [Category(CategoryEapResourceRange)]
        public int EapMemoryDangerRate
        {
            get
            {
                try
                {
                    return m_eapMemoryDangerRate;
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
                    m_eapMemoryDangerRate = value;
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

        [Category(CategoryEapResourceRange)]
        public int EapMemoryCautionRate
        {
            get
            {
                try
                {
                    return m_eapMemoryCautionRate;
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
                    m_eapMemoryCautionRate = value;
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

        [Category(CategoryEapResourceRange)]
        public int EapDiskDangerRate
        {
            get
            {
                try
                {
                    return m_eapDiskDangerRate;
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
                    m_eapDiskDangerRate = value;
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

        [Category(CategoryEapResourceRange)]
        public int EapDiskCautionRate
        {
            get
            {
                try
                {
                    return m_eapDiskCautionRate;
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
                    m_eapDiskCautionRate = value;
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

        [Category(CategoryEapResourceRange)]
        public int EapReloadLimit
        {
            get
            {
                try
                {
                    return m_eapReloadLimit;
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
                    m_eapReloadLimit = value;
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

        #region EAP Log Level Caption

        [Category(CategoryEapLogLevelCaption)]
        public string LogLevel1
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
                return string.Empty;
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

        [Category(CategoryEapLogLevelCaption)]
        public string LogLevel2
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
                return string.Empty;
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

        [Category(CategoryEapLogLevelCaption)]
        public string LogLevel3
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
                return string.Empty;
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

        [Category(CategoryEapLogLevelCaption)]
        public string LogLevel4
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
                return string.Empty;
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

        [Category(CategoryEapLogLevelCaption)]
        public string LogLevel5
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
                return string.Empty;
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

        [Category(CategoryEapLogLevelCaption)]
        public string LogLevel6
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
                return string.Empty;
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

        [Category(CategoryEapLogLevelCaption)]
        public string LogLevel7
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
                return string.Empty;
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

        [Category(CategoryEapLogLevelCaption)]
        public string LogLevel8
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
                return string.Empty;
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

        [Category(CategoryEapLogLevelCaption)]
        public string LogLevel9
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
                return string.Empty;
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

        [Category(CategoryEapLogLevelCaption)]
        public string LogLevel10
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
                return string.Empty;
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
                    m_factory = dt.Rows[0][0].ToString();
                    m_description = dt.Rows[0][1].ToString();
                    // --
                    m_serverCpuDangerRate = int.Parse(dt.Rows[0][2].ToString());
                    m_serverCpuCautionRate = int.Parse(dt.Rows[0][3].ToString());
                    m_serverMemoryDangerRate = int.Parse(dt.Rows[0][4].ToString());
                    m_serverMemoryCautionRate = int.Parse(dt.Rows[0][5].ToString());
                    m_serverDiskDangerRate = int.Parse(dt.Rows[0][6].ToString());
                    m_serverDiskCautionRate = int.Parse(dt.Rows[0][7].ToString());
                    // --
                    m_eapCpuDangerRate = int.Parse(dt.Rows[0][8].ToString());
                    m_eapCpuCautionRate = int.Parse(dt.Rows[0][9].ToString());
                    m_eapMemoryDangerRate = int.Parse(dt.Rows[0][10].ToString());
                    m_eapMemoryCautionRate = int.Parse(dt.Rows[0][11].ToString());
                    m_eapDiskDangerRate = (int)double.Parse(dt.Rows[0][12].ToString());
                    m_eapDiskCautionRate = (int)double.Parse(dt.Rows[0][13].ToString());
                    m_eapReloadLimit = int.Parse(dt.Rows[0][14].ToString());
                    // --
                    m_logLevel1 = dt.Rows[0][15].ToString();
                    m_logLevel2 = dt.Rows[0][16].ToString();
                    m_logLevel3 = dt.Rows[0][17].ToString();
                    m_logLevel4 = dt.Rows[0][18].ToString();
                    m_logLevel5 = dt.Rows[0][19].ToString();
                    m_logLevel6 = dt.Rows[0][20].ToString();
                    m_logLevel7 = dt.Rows[0][21].ToString();
                    m_logLevel8 = dt.Rows[0][22].ToString();
                    m_logLevel9 = dt.Rows[0][23].ToString();
                    m_logLevel10 = dt.Rows[0][24].ToString();
                }

                // --

                base.fTypeDescriptor.properties["Factory"].attributes.replace(new DisplayNameAttribute("Factory"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                // --
                base.fTypeDescriptor.properties["ServerCpuDangerRate"].attributes.replace(new DisplayNameAttribute("CPU Danger Rate(%)"));
                base.fTypeDescriptor.properties["ServerCpuCautionRate"].attributes.replace(new DisplayNameAttribute("CPU Caution Rate(%)"));
                base.fTypeDescriptor.properties["ServerMemoryDangerRate"].attributes.replace(new DisplayNameAttribute("Memory Danger Rate(%)"));
                base.fTypeDescriptor.properties["ServerMemoryCautionRate"].attributes.replace(new DisplayNameAttribute("Memory Caution Rate(%)"));
                base.fTypeDescriptor.properties["ServerDiskDangerRate"].attributes.replace(new DisplayNameAttribute("Disk Danger Rate(%)"));
                base.fTypeDescriptor.properties["ServerDiskCautionRate"].attributes.replace(new DisplayNameAttribute("Disk Caution Rate(%)"));
                // --
                base.fTypeDescriptor.properties["EapCpuDangerRate"].attributes.replace(new DisplayNameAttribute("CPU Danger Rate(%)"));
                base.fTypeDescriptor.properties["EapCpuCautionRate"].attributes.replace(new DisplayNameAttribute("CPU Caution Rate(%)"));
                base.fTypeDescriptor.properties["EapMemoryDangerRate"].attributes.replace(new DisplayNameAttribute("Memory Danger Rate(MB)"));
                base.fTypeDescriptor.properties["EapMemoryCautionRate"].attributes.replace(new DisplayNameAttribute("Memory Caution Rate(MB)"));
                base.fTypeDescriptor.properties["EapDiskDangerRate"].attributes.replace(new DisplayNameAttribute("Disk Danger Rate(MB)"));
                base.fTypeDescriptor.properties["EapDiskCautionRate"].attributes.replace(new DisplayNameAttribute("Disk Caution Rate(MB)"));
                base.fTypeDescriptor.properties["EapReloadLimit"].attributes.replace(new DisplayNameAttribute("EAP Reload Limit"));
                // --
                base.fTypeDescriptor.properties["LogLevel1"].attributes.replace(new DisplayNameAttribute("Log Level 1"));
                base.fTypeDescriptor.properties["LogLevel2"].attributes.replace(new DisplayNameAttribute("Log Level 2"));
                base.fTypeDescriptor.properties["LogLevel3"].attributes.replace(new DisplayNameAttribute("Log Level 3"));
                base.fTypeDescriptor.properties["LogLevel4"].attributes.replace(new DisplayNameAttribute("Log Level 4"));
                base.fTypeDescriptor.properties["LogLevel5"].attributes.replace(new DisplayNameAttribute("Log Level 5"));
                base.fTypeDescriptor.properties["LogLevel6"].attributes.replace(new DisplayNameAttribute("Log Level 6"));
                base.fTypeDescriptor.properties["LogLevel7"].attributes.replace(new DisplayNameAttribute("Log Level 7"));
                base.fTypeDescriptor.properties["LogLevel8"].attributes.replace(new DisplayNameAttribute("Log Level 8"));
                base.fTypeDescriptor.properties["LogLevel9"].attributes.replace(new DisplayNameAttribute("Log Level 9"));
                base.fTypeDescriptor.properties["LogLevel10"].attributes.replace(new DisplayNameAttribute("Log Level 10"));

                // --

                // ***
                // 2014.09.10 by spike.lee
                // 데이터 키 정의
                // ***
                base.fTypeDescriptor.properties["Factory"].attributes.replace(new ParenthesizePropertyNameAttribute(true));

                // --

                base.fTypeDescriptor.properties["Factory"].attributes.replace(new DefaultValueAttribute(m_factory));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_description));   
                // --
                base.fTypeDescriptor.properties["ServerCpuDangerRate"].attributes.replace(new DefaultValueAttribute(m_serverCpuDangerRate));
                base.fTypeDescriptor.properties["ServerCpuCautionRate"].attributes.replace(new DefaultValueAttribute(m_serverCpuCautionRate));
                base.fTypeDescriptor.properties["ServerMemoryDangerRate"].attributes.replace(new DefaultValueAttribute(m_serverMemoryDangerRate));
                base.fTypeDescriptor.properties["ServerMemoryCautionRate"].attributes.replace(new DefaultValueAttribute(m_serverMemoryCautionRate));
                base.fTypeDescriptor.properties["ServerDiskDangerRate"].attributes.replace(new DefaultValueAttribute(m_serverDiskDangerRate));
                base.fTypeDescriptor.properties["ServerDiskCautionRate"].attributes.replace(new DefaultValueAttribute(m_serverDiskCautionRate));   
                // --
                base.fTypeDescriptor.properties["EapCpuDangerRate"].attributes.replace(new DefaultValueAttribute(m_eapCpuDangerRate));
                base.fTypeDescriptor.properties["EapCpuCautionRate"].attributes.replace(new DefaultValueAttribute(m_eapCpuCautionRate));
                base.fTypeDescriptor.properties["EapMemoryDangerRate"].attributes.replace(new DefaultValueAttribute(m_eapMemoryDangerRate));
                base.fTypeDescriptor.properties["EapMemoryCautionRate"].attributes.replace(new DefaultValueAttribute(m_eapMemoryCautionRate));
                base.fTypeDescriptor.properties["EapDiskDangerRate"].attributes.replace(new DefaultValueAttribute(m_eapDiskDangerRate));
                base.fTypeDescriptor.properties["EapDiskCautionRate"].attributes.replace(new DefaultValueAttribute(m_eapDiskCautionRate));
                base.fTypeDescriptor.properties["EapReloadLimit"].attributes.replace(new DefaultValueAttribute(m_eapReloadLimit));
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
                    base.fTypeDescriptor.properties["Factory"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Description"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["ServerCpuDangerRate"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["ServerCpuCautionRate"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["ServerMemoryDangerRate"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["ServerMemoryCautionRate"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["ServerDiskDangerRate"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["ServerDiskCautionRate"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["EapCpuDangerRate"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["EapCpuCautionRate"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["EapMemoryDangerRate"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["EapMemoryCautionRate"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["EapDiskDangerRate"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["EapDiskCautionRate"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["EapReloadLimit"].attributes.replace(new ReadOnlyAttribute(true));
                    // -- 
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
