/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropSdsl.cs
--  Creator         : byJeon
--  Create Date     : 2011.10.04
--  Description     : FAMate SECS Modeler SECS Device Data Sent Log Property Source Object Class 
--  History         : Created by byJeon at 2011.10.04
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.SecsModeler
{
    public class FPropSdsl : FDynPropCusBase<FSsmCore>
    {
        
        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryResult = "[01] Result";
        private const string CategoryGeneral = "[02] General";
        private const string CategoryFont = "[03] Font";
        private const string CategoryProtocol = "[04] Protocol";
        private const string CategoryTimeout = "[05] Timeout";
        private const string CategoryUserTag = "[06] User Tag";

        // --

        private bool m_disposed = false;
        // --
        private FSecsDeviceDataSentLog m_fSdsl = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropSdsl(
            FSsmCore fSsmCore,
            FDynPropGrid fPropGrid,
            FSecsDeviceDataSentLog fSdsl
            )
            : base(fSsmCore, fSsmCore.fUIWizard, fPropGrid)
        {
            m_fSdsl = fSdsl;
            // --
            init();   
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropSdsl(
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
                    term();     
                    // --
                    m_fSdsl = null;
                }                

                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Result

        [Category(CategoryResult)]
        public string Time
        {
            get
            {
                try
                {
                    return m_fSdsl.time;
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

        [Category(CategoryResult)]
        public FResultCode ResultCode
        {
            get
            {
                try
                {
                    return m_fSdsl.fResultCode;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FResultCode.Error;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryResult)]
        public string ResultMessage
        {
            get
            {
                try
                {
                    return m_fSdsl.resultMessage;
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

        #region General

        [Category(CategoryGeneral)]
        public string Type
        {
            get
            {
                try
                {
                    return m_fSdsl.fObjectLogType.ToString();
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
        public string ID
        {
            get
            {
                try
                {
                    return m_fSdsl.uniqueIdToString;
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
        public string Name
        {
            get
            {
                try
                {
                    return m_fSdsl.name;
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
                    return m_fSdsl.description;
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

        #region Font

        [Category(CategoryFont)]
        public Color FontColor
        {
            get
            {
                try
                {
                    return m_fSdsl.fontColor;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return Color.Black;
            }

        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryFont)]
        public bool FontBold
        {
            get
            {
                try
                {
                    return m_fSdsl.fontBold;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
        
        #region Protocol

        [Category(CategoryProtocol)]
        public FDeviceMode Mode
        {
            get
            {
                try
                {
                    return m_fSdsl.fDeviceMode;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FDeviceMode.Both;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryProtocol)]
        public FProtocol Protocol
        {
            get
            {
                try
                {
                    return m_fSdsl.fProtocol;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FProtocol.SECS1;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryProtocol)]
        public FConnectMode ConnectMode
        {
            get
            {
                try
                {
                    return m_fSdsl.fConnectMode;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FConnectMode.Active;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryProtocol)]
        public string LocalIp
        {
            get
            {
                try
                {
                    return m_fSdsl.localIp;
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

        [Category(CategoryProtocol)]
        public int LocalPort
        {
            get
            {
                try
                {
                    return m_fSdsl.localPort;
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

        [Category(CategoryProtocol)]
        public string RemoteIp
        {
            get
            {
                try
                {
                    return m_fSdsl.remoteIp;
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

        [Category(CategoryProtocol)]
        public int RemotePort
        {
            get
            {
                try
                {
                    return m_fSdsl.remotePort;
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

        [Category(CategoryProtocol)]
        [TypeConverter(typeof(FPropAttrSdvSerialPortStringConverter))]
        public string SerialPort
        {
            get
            {
                try
                {
                    return m_fSdsl.serialPort;
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

        [Category(CategoryProtocol)]
        [TypeConverter(typeof(FPropAttrSdvBaudInt32Converter))]
        public int Baud
        {
            get
            {
                try
                {
                    return m_fSdsl.baud;
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

        [Category(CategoryProtocol)]
        public bool RBit
        {
            get
            {
                try
                {
                    return m_fSdsl.rbit;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryProtocol)]
        public bool Interleave
        {
            get
            {
                try
                {
                    return m_fSdsl.interleave;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryProtocol)]
        public bool DuplicateError
        {
            get
            {
                try
                {
                    return m_fSdsl.duplicateError;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryProtocol)]
        public bool IgnoreSystemBytes
        {
            get
            {
                try
                {
                    return m_fSdsl.ignoreSystemBytes;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryProtocol)]
        public int LinkTestPeriod
        {
            get
            {
                try
                {
                    return m_fSdsl.linkTestTimePeriod;
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

        [Category(CategoryProtocol)]
        public int RetryLimit
        {
            get
            {
                try
                {
                    return m_fSdsl.retryLimit;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Timeout

        [Category(CategoryTimeout)]
        public float T1Timeout
        {
            get
            {
                try
                {
                    return m_fSdsl.t1Timeout;
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

        [Category(CategoryTimeout)]
        public float T2Timeout
        {
            get
            {
                try
                {
                    return m_fSdsl.t2Timeout;
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

        [Category(CategoryTimeout)]
        public int T3Timeout
        {
            get
            {
                try
                {
                    return m_fSdsl.t3Timeout;
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

        [Category(CategoryTimeout)]
        public int T4Timeout
        {
            get
            {
                try
                {
                    return m_fSdsl.t4Timeout;
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

        [Category(CategoryTimeout)]
        public int T5Timeout
        {
            get
            {
                try
                {
                    return m_fSdsl.t5Timeout;
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

        [Category(CategoryTimeout)]
        public int T6Timeout
        {
            get
            {
                try
                {
                    return m_fSdsl.t6Timeout;
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

        [Category(CategoryTimeout)]
        public int T7Timeout
        {
            get
            {
                try
                {
                    return m_fSdsl.t7Timeout;
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

        [Category(CategoryTimeout)]
        public int T8Timeout
        {
            get
            {
                try
                {
                    return m_fSdsl.t8Timeout;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region User Tag

        [Category(CategoryUserTag)]
        public string UserTag1
        {
            get
            {
                try
                {
                    return m_fSdsl.userTag1;
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

        [Category(CategoryUserTag)]
        public string UserTag2
        {
            get
            {
                try
                {
                    return m_fSdsl.userTag2;
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

        [Category(CategoryUserTag)]
        public string UserTag3
        {
            get
            {
                try
                {
                    return m_fSdsl.userTag3;
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

        [Category(CategoryUserTag)]
        public string UserTag4
        {
            get
            {
                try
                {
                    return m_fSdsl.userTag4;
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

        [Category(CategoryUserTag)]
        public string UserTag5
        {
            get
            {
                try
                {
                    return m_fSdsl.userTag5;
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

        [Browsable(false)]
        public FSecsDeviceDataSentLog fSecsDeviceDataSentLog
        {
            get
            {
                try
                {
                    return m_fSdsl;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
        
        #region Methods

        private void init(
            )
        {
            try
            {
                base.fTypeDescriptor.properties["Time"].attributes.replace(new DisplayNameAttribute("Time"));
                base.fTypeDescriptor.properties["ResultCode"].attributes.replace(new DisplayNameAttribute("Result Code"));
                base.fTypeDescriptor.properties["ResultMessage"].attributes.replace(new DisplayNameAttribute("Result Message"));
                // --
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Type"));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DisplayNameAttribute("ID"));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DisplayNameAttribute("Name"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DisplayNameAttribute("Color"));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DisplayNameAttribute("Bold"));
                // --
                base.fTypeDescriptor.properties["Mode"].attributes.replace(new DisplayNameAttribute("Mode"));
                base.fTypeDescriptor.properties["Protocol"].attributes.replace(new DisplayNameAttribute("Protocol"));
                base.fTypeDescriptor.properties["ConnectMode"].attributes.replace(new DisplayNameAttribute("Connect Mode"));
                base.fTypeDescriptor.properties["LocalIp"].attributes.replace(new DisplayNameAttribute("Local IP"));
                base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new DisplayNameAttribute("Local Port"));
                base.fTypeDescriptor.properties["RemoteIp"].attributes.replace(new DisplayNameAttribute("Remote IP"));
                base.fTypeDescriptor.properties["RemotePort"].attributes.replace(new DisplayNameAttribute("Remote Port"));
                base.fTypeDescriptor.properties["SerialPort"].attributes.replace(new DisplayNameAttribute("Serial Port"));
                base.fTypeDescriptor.properties["Baud"].attributes.replace(new DisplayNameAttribute("Baud"));
                base.fTypeDescriptor.properties["RBit"].attributes.replace(new DisplayNameAttribute("R-Bit"));
                base.fTypeDescriptor.properties["Interleave"].attributes.replace(new DisplayNameAttribute("Interleave"));
                base.fTypeDescriptor.properties["DuplicateError"].attributes.replace(new DisplayNameAttribute("Duplicate Error"));
                base.fTypeDescriptor.properties["IgnoreSystemBytes"].attributes.replace(new DisplayNameAttribute("Ignore System Bytes"));
                base.fTypeDescriptor.properties["LinkTestPeriod"].attributes.replace(new DisplayNameAttribute("Link-Test Period"));
                base.fTypeDescriptor.properties["RetryLimit"].attributes.replace(new DisplayNameAttribute("Retry Limit"));
                // --
                base.fTypeDescriptor.properties["T1Timeout"].attributes.replace(new DisplayNameAttribute("T1 Timeout"));
                base.fTypeDescriptor.properties["T2Timeout"].attributes.replace(new DisplayNameAttribute("T2 Timeout"));
                base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new DisplayNameAttribute("T3 Timeout"));
                base.fTypeDescriptor.properties["T4Timeout"].attributes.replace(new DisplayNameAttribute("T4 Timeout"));
                base.fTypeDescriptor.properties["T5Timeout"].attributes.replace(new DisplayNameAttribute("T5 Timeout"));
                base.fTypeDescriptor.properties["T6Timeout"].attributes.replace(new DisplayNameAttribute("T6 Timeout"));
                base.fTypeDescriptor.properties["T7Timeout"].attributes.replace(new DisplayNameAttribute("T7 Timeout"));
                base.fTypeDescriptor.properties["T8Timeout"].attributes.replace(new DisplayNameAttribute("T8 Timeout"));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DisplayNameAttribute("User Tag1"));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DisplayNameAttribute("User Tag2"));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DisplayNameAttribute("User Tag3"));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DisplayNameAttribute("User Tag4"));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DisplayNameAttribute("User Tag5"));

                // --

                base.fTypeDescriptor.properties["Time"].attributes.replace(new DefaultValueAttribute(m_fSdsl.time));
                base.fTypeDescriptor.properties["ResultCode"].attributes.replace(new DefaultValueAttribute(m_fSdsl.fResultCode));
                base.fTypeDescriptor.properties["ResultMessage"].attributes.replace(new DefaultValueAttribute(m_fSdsl.resultMessage));
                // --
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fSdsl.fObjectLogType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fSdsl.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fSdsl.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fSdsl.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fSdsl.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fSdsl.fontBold));
                // --
                base.fTypeDescriptor.properties["Mode"].attributes.replace(new DefaultValueAttribute(m_fSdsl.fDeviceMode));
                base.fTypeDescriptor.properties["Protocol"].attributes.replace(new DefaultValueAttribute(m_fSdsl.fProtocol));
                base.fTypeDescriptor.properties["ConnectMode"].attributes.replace(new DefaultValueAttribute(m_fSdsl.fConnectMode));
                base.fTypeDescriptor.properties["LocalIp"].attributes.replace(new DefaultValueAttribute(m_fSdsl.localIp));
                base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new DefaultValueAttribute(m_fSdsl.localPort));
                base.fTypeDescriptor.properties["RemoteIp"].attributes.replace(new DefaultValueAttribute(m_fSdsl.remoteIp));
                base.fTypeDescriptor.properties["RemotePort"].attributes.replace(new DefaultValueAttribute(m_fSdsl.remotePort));
                base.fTypeDescriptor.properties["SerialPort"].attributes.replace(new DefaultValueAttribute(m_fSdsl.serialPort));
                base.fTypeDescriptor.properties["Baud"].attributes.replace(new DefaultValueAttribute(m_fSdsl.baud));
                base.fTypeDescriptor.properties["RBit"].attributes.replace(new DefaultValueAttribute(m_fSdsl.rbit));
                base.fTypeDescriptor.properties["Interleave"].attributes.replace(new DefaultValueAttribute(m_fSdsl.interleave));
                base.fTypeDescriptor.properties["DuplicateError"].attributes.replace(new DefaultValueAttribute(m_fSdsl.duplicateError));
                base.fTypeDescriptor.properties["IgnoreSystemBytes"].attributes.replace(new DefaultValueAttribute(m_fSdsl.ignoreSystemBytes));
                base.fTypeDescriptor.properties["LinkTestPeriod"].attributes.replace(new DefaultValueAttribute(m_fSdsl.linkTestTimePeriod));
                base.fTypeDescriptor.properties["RetryLimit"].attributes.replace(new DefaultValueAttribute(m_fSdsl.retryLimit));
                // --
                base.fTypeDescriptor.properties["T1Timeout"].attributes.replace(new DefaultValueAttribute(m_fSdsl.t1Timeout));
                base.fTypeDescriptor.properties["T2Timeout"].attributes.replace(new DefaultValueAttribute(m_fSdsl.t2Timeout));
                base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new DefaultValueAttribute(m_fSdsl.t3Timeout));
                base.fTypeDescriptor.properties["T4Timeout"].attributes.replace(new DefaultValueAttribute(m_fSdsl.t4Timeout));
                base.fTypeDescriptor.properties["T5Timeout"].attributes.replace(new DefaultValueAttribute(m_fSdsl.t5Timeout));
                base.fTypeDescriptor.properties["T6Timeout"].attributes.replace(new DefaultValueAttribute(m_fSdsl.t6Timeout));
                base.fTypeDescriptor.properties["T7Timeout"].attributes.replace(new DefaultValueAttribute(m_fSdsl.t7Timeout));
                base.fTypeDescriptor.properties["T8Timeout"].attributes.replace(new DefaultValueAttribute(m_fSdsl.t8Timeout));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DefaultValueAttribute(m_fSdsl.userTag1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DefaultValueAttribute(m_fSdsl.userTag2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DefaultValueAttribute(m_fSdsl.userTag3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DefaultValueAttribute(m_fSdsl.userTag4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DefaultValueAttribute(m_fSdsl.userTag5));

                // --

                setChangedProtocol();
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

        private void term(
            )
        {
            try
            {

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

        private void setChangedProtocol(
            )
        {
            try
            {
                base.fTypeDescriptor.properties["ConnectMode"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["LocalIp"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["RemoteIp"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["RemotePort"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["SerialPort"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["Baud"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["RBit"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["Interleave"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["DuplicateError"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["IgnoreSystemBytes"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["LinkTestPeriod"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["RetryLimit"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["T1Timeout"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["T2Timeout"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["T4Timeout"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["T5Timeout"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["T6Timeout"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["T7Timeout"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["T8Timeout"].attributes.replace(new BrowsableAttribute(false));

                // --

                if (m_fSdsl.fProtocol == FProtocol.SECS1)
                {
                    base.fTypeDescriptor.properties["SerialPort"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Baud"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["RBit"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Interleave"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["DuplicateError"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["IgnoreSystemBytes"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["RetryLimit"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["T1Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T2Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T4Timeout"].attributes.replace(new BrowsableAttribute(true));
                }
                else if (
                    m_fSdsl.fProtocol == FProtocol.TCPIP ||
                    m_fSdsl.fProtocol == FProtocol.TELNET
                    )
                {
                    base.fTypeDescriptor.properties["ConnectMode"].attributes.replace(new BrowsableAttribute(true));
                    if (m_fSdsl.fConnectMode == FConnectMode.Passive)
                    {
                        base.fTypeDescriptor.properties["LocalIp"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new BrowsableAttribute(true));
                    }
                    else
                    {
                        base.fTypeDescriptor.properties["LocalIp"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["RemoteIp"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["RemotePort"].attributes.replace(new BrowsableAttribute(true));
                    }
                    base.fTypeDescriptor.properties["RBit"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Interleave"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["DuplicateError"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["IgnoreSystemBytes"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["RetryLimit"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["T1Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T2Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T4Timeout"].attributes.replace(new BrowsableAttribute(true));
                }
                else if (m_fSdsl.fProtocol == FProtocol.HSMS)
                {
                    base.fTypeDescriptor.properties["ConnectMode"].attributes.replace(new BrowsableAttribute(true));
                    if (m_fSdsl.fConnectMode == FConnectMode.Passive)
                    {
                        base.fTypeDescriptor.properties["LocalIp"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new BrowsableAttribute(true));
                    }
                    else
                    {
                        base.fTypeDescriptor.properties["LocalIp"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["RemoteIp"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["RemotePort"].attributes.replace(new BrowsableAttribute(true));
                    }
                    base.fTypeDescriptor.properties["LinkTestPeriod"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T5Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T6Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T7Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T8Timeout"].attributes.replace(new BrowsableAttribute(true));
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
