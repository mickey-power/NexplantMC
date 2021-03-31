/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropSecs1ToHsmsConverter.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.24
--  Description     : FAMate Admin Manager SECS1 To HSMS Converter Property Source Object Class 
--  History         : Created by spike.lee at 2017.04.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Reflection;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public class FPropSecs1ToHsmsConverter : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategorySECS1 = "[02] SECS1";
        private const string CategoryHSMS = "[03] HSMS";

        // --

        private bool m_disposed = false;
        // --
        private bool m_tranEnabled = false;
        // --
        private string m_converter = string.Empty;
        private string m_description = string.Empty;
        private string m_type = string.Empty;
        private string m_ipAddress = string.Empty;
        // --
        private int m_secs1SessionId = 0;
        private string m_secs1SerialPort = "COM1";
        private int m_secs1Baud = 9600;
        private bool m_secs1RBit = false;
        private bool m_secs1Interleave = true;
        private bool m_secs1DuplicateError = true;
        private bool m_secs1IgnoreSystemBytes = false;
        private byte m_secs1RetryLimit = 3;
        private float m_secs1T1Timeout = 0.5f;
        private float m_secs1T2Timeout = 10;
        private byte m_secs1T3Timeout = 45;
        private byte m_secs1T4Timeout = 45;
        // --
        private int m_hsmsSessionId = 0;
        private FS2HConnectMode m_hsmsConnectMode = FS2HConnectMode.Passive;
        private string m_hsmsLocalIp = "127.0.0.1";
        private int m_hsmsLocalPort = 5000;
        private string m_hsmsRemoteIp = "127.0.0.1";
        private int m_hsmsRemotePort = 5000;
        private byte m_hsmsLinkTestPeriod = 10;
        private byte m_hsmsT3Timeout = 45;
        private byte m_hsmsT5Timeout = 10;
        private byte m_hsmsT6Timeout = 5;
        private byte m_hsmsT7Timeout = 10;
        private byte m_hsmsT8Timeout = 5;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropSecs1ToHsmsConverter(
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

        public FPropSecs1ToHsmsConverter(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            bool readOnly
            )
            : this(fAdmCore, fPropGrid, null, readOnly)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropSecs1ToHsmsConverter(
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
        public string Converter
        {
            get
            {
                try
                {
                    return m_converter;
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
                    m_converter = value;
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

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        [Editor(typeof(FPropAttrGeneralCodeDataUITypeEditor), typeof(UITypeEditor))]
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

            set
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

        [Category(CategoryGeneral)]
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

        #region SECS1

        [Category(CategorySECS1)]
        public int Secs1SessionId
        {
            get
            {
                try
                {
                    return m_secs1SessionId;
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
                    m_secs1SessionId = value;
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

        [Category(CategorySECS1)]
        [TypeConverter(typeof(FPropAttrSecs1ToHsmsConverterSecs1SerialPortStringConverter))]
        public string Secs1SerialPort
        {
            get
            {
                try
                {
                    return m_secs1SerialPort;
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
                    m_secs1SerialPort = value;
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

        [Category(CategorySECS1)]
        [TypeConverter(typeof(FPropAttrSecs1ToHsmsConverterSecs1BaudStringConverter))]
        public int Secs1Baud
        {
            get
            {
                try
                {
                    return m_secs1Baud;
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
                    m_secs1Baud= value;
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

        [Category(CategorySECS1)]
        public bool Secs1RBit
        {
            get
            {
                try
                {
                    return m_secs1RBit;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_secs1RBit = value;
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

        [Category(CategorySECS1)]
        public bool Secs1Interleave
        {
            get
            {
                try
                {
                    return m_secs1Interleave;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_secs1Interleave = value;
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

        [Category(CategorySECS1)]
        public bool Secs1DuplicateError
        {
            get
            {
                try
                {
                    return m_secs1DuplicateError;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_secs1DuplicateError = value;
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

        [Category(CategorySECS1)]
        public bool Secs1IgnoreSystemBytes
        {
            get
            {
                try
                {
                    return m_secs1IgnoreSystemBytes;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_secs1IgnoreSystemBytes = value;
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

        [Category(CategorySECS1)]
        public byte Secs1RetryLimit
        {
            get
            {
                try
                {
                    return m_secs1RetryLimit;
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
                    m_secs1RetryLimit = value;
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

        [Category(CategorySECS1)]
        public float Secs1T1Timeout
        {
            get
            {
                try
                {
                    return m_secs1T1Timeout;
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
                    m_secs1T1Timeout = value;
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

        [Category(CategorySECS1)]
        public float Secs1T2Timeout
        {
            get
            {
                try
                {
                    return m_secs1T2Timeout;
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
                    m_secs1T2Timeout = value;
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

        [Category(CategorySECS1)]
        public byte Secs1T3Timeout
        {
            get
            {
                try
                {
                    return m_secs1T3Timeout;
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
                    m_secs1T3Timeout = value;
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

        [Category(CategorySECS1)]
        public byte Secs1T4Timeout
        {
            get
            {
                try
                {
                    return m_secs1T4Timeout;
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
                    m_secs1T4Timeout = value;
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

        #region HSMS

        [Category(CategoryHSMS)]
        public int HsmsSessionId
        {
            get
            {
                try
                {
                    return m_hsmsSessionId;
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
                    m_hsmsSessionId = value;
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

        [Category(CategoryHSMS)]
        public FS2HConnectMode HsmsConnectMode
        {
            get
            {
                try
                {
                    return m_hsmsConnectMode;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FS2HConnectMode.Passive;
            }

            set
            {
                try
                {
                    m_hsmsConnectMode = value;
                    // --
                    setChangedHsmsConnectMode();
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

        [Category(CategoryHSMS)]
        public string HsmsLocalIp
        {
            get
            {
                try
                {
                    return m_hsmsLocalIp;
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
                    m_hsmsLocalIp = value;
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

        [Category(CategoryHSMS)]
        public int HsmsLocalPort
        {
            get
            {
                try
                {
                    return m_hsmsLocalPort;
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
                    m_hsmsLocalPort = value;
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

        [Category(CategoryHSMS)]
        public string HsmsRemoteIp
        {
            get
            {
                try
                {
                    return m_hsmsRemoteIp;
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
                    m_hsmsRemoteIp = value;
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

        [Category(CategoryHSMS)]
        public int HsmsRemotePort
        {
            get
            {
                try
                {
                    return m_hsmsRemotePort;
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
                    m_hsmsRemotePort = value;
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

        [Category(CategoryHSMS)]
        public byte HsmsLinkTestPeriod
        {
            get
            {
                try
                {
                    return m_hsmsLinkTestPeriod;
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
                    m_hsmsLinkTestPeriod = value;
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

        [Category(CategoryHSMS)]
        public byte HsmsT3Timeout
        {
            get
            {
                try
                {
                    return m_hsmsT3Timeout;
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
                    m_hsmsT3Timeout = value;
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

        [Category(CategoryHSMS)]
        public byte HsmsT5Timeout
        {
            get
            {
                try
                {
                    return m_hsmsT5Timeout;
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
                    m_hsmsT5Timeout = value;
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

        [Category(CategoryHSMS)]
        public byte HsmsT6Timeout
        {
            get
            {
                try
                {
                    return m_hsmsT6Timeout;
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
                    m_hsmsT6Timeout = value;
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

        [Category(CategoryHSMS)]
        public byte HsmsT7Timeout
        {
            get
            {
                try
                {
                    return m_hsmsT7Timeout;
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
                    m_hsmsT7Timeout = value;
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

        [Category(CategoryHSMS)]
        public byte HsmsT8Timeout
        {
            get
            {
                try
                {
                    return m_hsmsT8Timeout;
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
                    m_hsmsT8Timeout = value;
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
                    m_converter = dt.Rows[0][0].ToString();
                    m_description = dt.Rows[0][1].ToString();
                    m_type = dt.Rows[0][2].ToString();
                    m_ipAddress = dt.Rows[0][3].ToString();
                    // --
                    m_secs1SessionId = int.Parse(dt.Rows[0][4].ToString());
                    m_secs1SerialPort = dt.Rows[0][5].ToString();
                    m_secs1Baud = int.Parse(dt.Rows[0][6].ToString());
                    m_secs1RBit = bool.Parse(dt.Rows[0][7].ToString());
                    m_secs1Interleave = bool.Parse(dt.Rows[0][8].ToString());
                    m_secs1DuplicateError = bool.Parse(dt.Rows[0][9].ToString());
                    m_secs1IgnoreSystemBytes = bool.Parse(dt.Rows[0][10].ToString());
                    m_secs1RetryLimit = byte.Parse(dt.Rows[0][11].ToString());
                    m_secs1T1Timeout = float.Parse(dt.Rows[0][12].ToString());
                    m_secs1T2Timeout = float.Parse(dt.Rows[0][13].ToString());
                    m_secs1T3Timeout = byte.Parse(dt.Rows[0][14].ToString());
                    m_secs1T4Timeout = byte.Parse(dt.Rows[0][15].ToString());
                    // --
                    m_hsmsSessionId = int.Parse(dt.Rows[0][16].ToString());
                    m_hsmsConnectMode = (FS2HConnectMode)Enum.Parse(typeof(FS2HConnectMode), dt.Rows[0][17].ToString());
                    m_hsmsLocalIp = dt.Rows[0][18].ToString();
                    m_hsmsLocalPort = int.Parse(dt.Rows[0][19].ToString());
                    m_hsmsRemoteIp = dt.Rows[0][20].ToString();
                    m_hsmsRemotePort = int.Parse(dt.Rows[0][21].ToString());
                    m_hsmsLinkTestPeriod = byte.Parse(dt.Rows[0][22].ToString());
                    m_hsmsT3Timeout = byte.Parse(dt.Rows[0][23].ToString());
                    m_hsmsT5Timeout = byte.Parse(dt.Rows[0][24].ToString());
                    m_hsmsT6Timeout = byte.Parse(dt.Rows[0][25].ToString());
                    m_hsmsT7Timeout = byte.Parse(dt.Rows[0][26].ToString());
                    m_hsmsT8Timeout = byte.Parse(dt.Rows[0][27].ToString());
                }

                // --

                base.fTypeDescriptor.properties["Converter"].attributes.replace(new DisplayNameAttribute("Converter"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Type"));
                base.fTypeDescriptor.properties["IpAddress"].attributes.replace(new DisplayNameAttribute("IP Address"));
                // --
                base.fTypeDescriptor.properties["Secs1SessionId"].attributes.replace(new DisplayNameAttribute("Session ID"));
                base.fTypeDescriptor.properties["Secs1SerialPort"].attributes.replace(new DisplayNameAttribute("Serial Port"));
                base.fTypeDescriptor.properties["Secs1Baud"].attributes.replace(new DisplayNameAttribute("Baud"));
                base.fTypeDescriptor.properties["Secs1RBit"].attributes.replace(new DisplayNameAttribute("R Bit"));
                base.fTypeDescriptor.properties["Secs1Interleave"].attributes.replace(new DisplayNameAttribute("Interleave"));
                base.fTypeDescriptor.properties["Secs1DuplicateError"].attributes.replace(new DisplayNameAttribute("Duplicate Error"));
                base.fTypeDescriptor.properties["Secs1IgnoreSystemBytes"].attributes.replace(new DisplayNameAttribute("Ignore System Bytes"));
                base.fTypeDescriptor.properties["Secs1RetryLimit"].attributes.replace(new DisplayNameAttribute("Retry Limit"));
                base.fTypeDescriptor.properties["Secs1T1Timeout"].attributes.replace(new DisplayNameAttribute("T1 Timeout"));
                base.fTypeDescriptor.properties["Secs1T2Timeout"].attributes.replace(new DisplayNameAttribute("T2 Timeout"));
                base.fTypeDescriptor.properties["Secs1T3Timeout"].attributes.replace(new DisplayNameAttribute("T3 Timeout"));
                base.fTypeDescriptor.properties["Secs1T4Timeout"].attributes.replace(new DisplayNameAttribute("T4 Timeout"));
                // --
                base.fTypeDescriptor.properties["HsmsSessionId"].attributes.replace(new DisplayNameAttribute("Session ID "));
                base.fTypeDescriptor.properties["HsmsConnectMode"].attributes.replace(new DisplayNameAttribute("Connect Mode"));
                base.fTypeDescriptor.properties["HsmsLocalIp"].attributes.replace(new DisplayNameAttribute("Local IP"));
                base.fTypeDescriptor.properties["HsmsLocalPort"].attributes.replace(new DisplayNameAttribute("Local Port"));
                base.fTypeDescriptor.properties["HsmsRemoteIp"].attributes.replace(new DisplayNameAttribute("Remote IP"));
                base.fTypeDescriptor.properties["HsmsRemotePort"].attributes.replace(new DisplayNameAttribute("Remote Port"));
                base.fTypeDescriptor.properties["HsmsLinkTestPeriod"].attributes.replace(new DisplayNameAttribute("Link Test Period"));
                base.fTypeDescriptor.properties["HsmsT3Timeout"].attributes.replace(new DisplayNameAttribute("T3 Timeout "));
                base.fTypeDescriptor.properties["HsmsT5Timeout"].attributes.replace(new DisplayNameAttribute("T5 Timeout"));
                base.fTypeDescriptor.properties["HsmsT6Timeout"].attributes.replace(new DisplayNameAttribute("T6 Timeout"));
                base.fTypeDescriptor.properties["HsmsT7Timeout"].attributes.replace(new DisplayNameAttribute("T7 Timeout"));
                base.fTypeDescriptor.properties["HsmsT8Timeout"].attributes.replace(new DisplayNameAttribute("T8 Timeout"));

                // --

                // ***
                // 데이터 키 정의
                // ***
                base.fTypeDescriptor.properties["Converter"].attributes.replace(new ParenthesizePropertyNameAttribute(true));

                // --

                base.fTypeDescriptor.properties["Converter"].attributes.replace(new DefaultValueAttribute(m_converter));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_description));
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_type));
                base.fTypeDescriptor.properties["IpAddress"].attributes.replace(new DefaultValueAttribute(m_ipAddress));
                // --
                base.fTypeDescriptor.properties["Secs1SessionId"].attributes.replace(new DefaultValueAttribute(m_secs1SessionId));
                base.fTypeDescriptor.properties["Secs1SerialPort"].attributes.replace(new DefaultValueAttribute(m_secs1SerialPort));
                base.fTypeDescriptor.properties["Secs1Baud"].attributes.replace(new DefaultValueAttribute(m_secs1Baud));
                base.fTypeDescriptor.properties["Secs1RBit"].attributes.replace(new DefaultValueAttribute(m_secs1RBit));
                base.fTypeDescriptor.properties["Secs1Interleave"].attributes.replace(new DefaultValueAttribute(m_secs1Interleave));
                base.fTypeDescriptor.properties["Secs1DuplicateError"].attributes.replace(new DefaultValueAttribute(m_secs1DuplicateError));
                base.fTypeDescriptor.properties["Secs1IgnoreSystemBytes"].attributes.replace(new DefaultValueAttribute(m_secs1IgnoreSystemBytes));
                base.fTypeDescriptor.properties["Secs1RetryLimit"].attributes.replace(new DefaultValueAttribute(m_secs1RetryLimit));
                base.fTypeDescriptor.properties["Secs1T1Timeout"].attributes.replace(new DefaultValueAttribute(m_secs1T1Timeout));
                base.fTypeDescriptor.properties["Secs1T2Timeout"].attributes.replace(new DefaultValueAttribute(m_secs1T2Timeout));
                base.fTypeDescriptor.properties["Secs1T3Timeout"].attributes.replace(new DefaultValueAttribute(m_secs1T3Timeout));
                base.fTypeDescriptor.properties["Secs1T4Timeout"].attributes.replace(new DefaultValueAttribute(m_secs1T4Timeout));
                // --
                base.fTypeDescriptor.properties["HsmsSessionId"].attributes.replace(new DefaultValueAttribute(m_hsmsSessionId));
                base.fTypeDescriptor.properties["HsmsConnectMode"].attributes.replace(new DefaultValueAttribute(m_hsmsConnectMode));
                base.fTypeDescriptor.properties["HsmsLocalIp"].attributes.replace(new DefaultValueAttribute(m_hsmsLocalIp));
                base.fTypeDescriptor.properties["HsmsLocalPort"].attributes.replace(new DefaultValueAttribute(m_hsmsLocalPort));
                base.fTypeDescriptor.properties["HsmsRemoteIp"].attributes.replace(new DefaultValueAttribute(m_hsmsRemoteIp));
                base.fTypeDescriptor.properties["HsmsRemotePort"].attributes.replace(new DefaultValueAttribute(m_hsmsRemotePort));
                base.fTypeDescriptor.properties["HsmsLinkTestPeriod"].attributes.replace(new DefaultValueAttribute(m_hsmsLinkTestPeriod));
                base.fTypeDescriptor.properties["HsmsT3Timeout"].attributes.replace(new DefaultValueAttribute(m_hsmsT3Timeout));
                base.fTypeDescriptor.properties["HsmsT5Timeout"].attributes.replace(new DefaultValueAttribute(m_hsmsT5Timeout));
                base.fTypeDescriptor.properties["HsmsT6Timeout"].attributes.replace(new DefaultValueAttribute(m_hsmsT6Timeout));
                base.fTypeDescriptor.properties["HsmsT7Timeout"].attributes.replace(new DefaultValueAttribute(m_hsmsT7Timeout));
                base.fTypeDescriptor.properties["HsmsT8Timeout"].attributes.replace(new DefaultValueAttribute(m_hsmsT8Timeout));

                // --

                if (!m_tranEnabled)
                {
                    base.fTypeDescriptor.properties["Converter"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Description"].attributes.replace(new ReadOnlyAttribute(true));                    
                    base.fTypeDescriptor.properties["Type"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["IpAddress"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["Secs1SessionId"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Secs1SerialPort"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Secs1Baud"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Secs1RBit"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Secs1Interleave"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Secs1DuplicateError"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Secs1IgnoreSystemBytes"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Secs1RetryLimit"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Secs1T1Timeout"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Secs1T2Timeout"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Secs1T3Timeout"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Secs1T4Timeout"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["HsmsSessionId"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["HsmsConnectMode"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["HsmsLocalIp"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["HsmsLocalPort"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["HsmsRemoteIp"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["HsmsRemotePort"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["HsmsLinkTestPeriod"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["HsmsT3Timeout"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["HsmsT5Timeout"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["HsmsT6Timeout"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["HsmsT7Timeout"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["HsmsT8Timeout"].attributes.replace(new ReadOnlyAttribute(true));                    
                }

                // --

                setChangedHsmsConnectMode();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void setChangedHsmsConnectMode(
            )
        {
            try
            {
                if (m_hsmsConnectMode == FS2HConnectMode.Passive)
                {
                    base.fTypeDescriptor.properties["HsmsLocalPort"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["HsmsRemoteIp"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["HsmsRemotePort"].attributes.replace(new BrowsableAttribute(false));
                }
                else
                {
                    base.fTypeDescriptor.properties["HsmsLocalPort"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["HsmsRemoteIp"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["HsmsRemotePort"].attributes.replace(new BrowsableAttribute(true));
                }

                // --

                this.fPropGrid.Refresh();
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
