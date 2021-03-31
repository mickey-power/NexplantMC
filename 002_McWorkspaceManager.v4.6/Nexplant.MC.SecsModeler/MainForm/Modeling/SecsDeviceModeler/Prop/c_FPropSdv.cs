/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropSdv.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.15
--  Description     : FAMate SECS Modeler SECS Device Property Source Object Class 
--  History         : Created by spike.lee at 2011.03.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.SecsModeler
{
    public class FPropSdv : FDynPropCusBase<FSsmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryFont = "[02] Font";
        private const string CategoryProtocol = "[03] Protocol";
        private const string CategoryTimeout = "[04] Timeout";
        private const string CategoryUserTag = "[05] User Tag";   

        // --

        private bool m_disposed = false;
        // --
        private FSecsDevice m_fSdv = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropSdv(
            FSsmCore fSsmCore,
            FDynPropGrid fPropGrid,
            FSecsDevice fSdv
            )
            : base(fSsmCore, fSsmCore.fUIWizard, fPropGrid)
        {
            m_fSdv = fSdv;
            // --
            init();   
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropSdv(
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
                    m_fSdv = null;
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
                    return m_fSdv.fObjectType.ToString();
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
                    return m_fSdv.uniqueIdToString;
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
        [TypeConverter(typeof(FPropAttrNameStringConverter))]
        public string Name
        {
            get
            {
                try
                {
                    return m_fSdv.name;
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
                    FCommon.validateName(value, true, this.mainObject.fUIWizard);

                    // --

                    m_fSdv.name = value;
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
                    return m_fSdv.description;
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
                    m_fSdv.description = value;
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

        #region Font

        [Category(CategoryFont)]
        public Color FontColor
        {
            get
            {
                try
                {
                    return m_fSdv.fontColor;
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

            set
            {
                try
                {
                    m_fSdv.fontColor = value;
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

        [Category(CategoryFont)]
        public bool FontBold
        {
            get
            {
                try
                {
                    return m_fSdv.fontBold;
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
                    m_fSdv.fontBold = value;
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

        #region Protocol

        [Category(CategoryProtocol)]
        public FDeviceMode Mode
        {
            get
            {
                try
                {
                    return m_fSdv.fDeviceMode;
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

            set
            {
                try
                {
                    m_fSdv.fDeviceMode = value;
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

        [Category(CategoryProtocol)]
        public FProtocol Protocol
        {
            get
            {
                try
                {
                    return m_fSdv.fProtocol;
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

            set
            {
                try
                {
                    m_fSdv.fProtocol = value;
                    setChangedProtocol();
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

        [Category(CategoryProtocol)]
        public FConnectMode ConnectMode
        {
            get
            {
                try
                {
                    return m_fSdv.fConnectMode;
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

            set
            {
                try
                {
                    m_fSdv.fConnectMode = value;
                    setChangedProtocol();
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

        [Category(CategoryProtocol)]
        public string LocalIp
        {
            get
            {
                try
                {
                    return m_fSdv.localIp;
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
                    if (value.Trim() == string.Empty)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // --

                    m_fSdv.localIp = value;
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

        [Category(CategoryProtocol)]
        public int LocalPort
        {
            get
            {
                try
                {
                    return m_fSdv.localPort;
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
                    if (value < 0 || value > 65535)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // --

                    m_fSdv.localPort = value;
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

        [Category(CategoryProtocol)]
        public string RemoteIp
        {
            get
            {
                try
                {
                    return m_fSdv.remoteIp;
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
                    if (value.Trim() == string.Empty)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // --

                    m_fSdv.remoteIp = value;
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

        [Category(CategoryProtocol)]
        public int RemotePort
        {
            get
            {
                try
                {
                    return m_fSdv.remotePort;
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
                    if (value < 0 || value > 65535)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // --

                    m_fSdv.remotePort = value;
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

        [Category(CategoryProtocol)]
        [TypeConverter(typeof(FPropAttrSdvSerialPortStringConverter))]
        public string SerialPort
        {
            get
            {
                try
                {
                    return m_fSdv.serialPort;
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
                    if (value.Trim() == string.Empty)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // --

                    m_fSdv.serialPort = value;
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

        [Category(CategoryProtocol)]
        [TypeConverter(typeof(FPropAttrSdvBaudInt32Converter))]
        public int Baud
        {
            get
            {
                try
                {
                    return m_fSdv.baud;
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
                    if (value < 1)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // --

                    m_fSdv.baud = value;
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

        [Category(CategoryProtocol)]
        public bool RBit
        {
            get
            {
                try
                {
                    return m_fSdv.rbit;
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
                    m_fSdv.rbit = value;
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

        [Category(CategoryProtocol)]
        public bool Interleave
        {
            get
            {
                try
                {
                    return m_fSdv.interleave;
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
                    m_fSdv.interleave = value;
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

        [Category(CategoryProtocol)]
        public bool DuplicateError
        {
            get
            {
                try
                {
                    return m_fSdv.duplicateError;
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
                    m_fSdv.duplicateError = value;
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

        [Category(CategoryProtocol)]
        public bool IgnoreSystemBytes
        {
            get
            {
                try
                {
                    return m_fSdv.ignoreSystemBytes;
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
                    m_fSdv.ignoreSystemBytes = value;
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

        [Category(CategoryProtocol)]
        public int LinkTestPeriod
        {
            get
            {
                try
                {
                    return m_fSdv.linkTestTimePeriod;
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
                    if (value < 0 || value > 240)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // --

                    m_fSdv.linkTestTimePeriod = value;
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

        [Category(CategoryProtocol)]
        public int RetryLimit
        {
            get
            {
                try
                {
                    return m_fSdv.retryLimit;
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
                    if (value < 0 || value > 31)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // --

                    m_fSdv.retryLimit = value;
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

        [Category(CategoryProtocol)]
        public int MaxSystemBytes
        {
            get
            {
                try
                {
                    return (int)m_fSdv.maxSystemBytes;
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
                    if (value < 0 || value > int.MaxValue)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // --

                    m_fSdv.maxSystemBytes = (uint)value;
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

        #region Timeout

        [Category(CategoryTimeout)]
        public float T1Timeout
        {
            get
            {
                try
                {
                    return m_fSdv.t1Timeout;
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
                decimal setValue = 0;
                decimal resolution = 0.1m;

                try
                {
                    setValue = (decimal)value;

                    // validate range (applied to SEMI E4-0699 p10.)
                    if (setValue < 0.1m || setValue > 10.0m)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // validate resolution (applied to SEMI E4-0699 p10.) 
                    if (setValue % resolution != 0)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // --

                    m_fSdv.t1Timeout = value;
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

        [Category(CategoryTimeout)]
        public float T2Timeout
        {
            get
            {
                try
                {
                    return m_fSdv.t2Timeout;
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
                decimal setValue = 0;
                decimal resolution = 0.2m;

                try
                {
                    setValue = (decimal)value;

                    // validate range (applied to SEMI E4-0699 p10.)
                    if (setValue < 0.2m || setValue > 25.0m)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // validate resolution (applied to SEMI E4-0699 p10.) 
                    if (setValue % resolution != 0)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // --

                    m_fSdv.t2Timeout = value;
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

        [Category(CategoryTimeout)]
        public int T3Timeout
        {
            get
            {
                try
                {
                    return m_fSdv.t3Timeout;
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
                    if (value < 1 || value > 120)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // --

                    m_fSdv.t3Timeout = value;
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

        [Category(CategoryTimeout)]
        public int T4Timeout
        {
            get
            {
                try
                {
                    return m_fSdv.t4Timeout;
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
                    if (value < 1 || value > 120)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // --

                    m_fSdv.t4Timeout = value;
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

        [Category(CategoryTimeout)]
        public int T5Timeout
        {
            get
            {
                try
                {
                    return m_fSdv.t5Timeout;
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
                    if (value < 1 || value > 240)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // --

                    m_fSdv.t5Timeout = value;
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

        [Category(CategoryTimeout)]
        public int T6Timeout
        {
            get
            {
                try
                {
                    return m_fSdv.t6Timeout;
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
                    if (value < 1 || value > 240)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // --

                    m_fSdv.t6Timeout = value;
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

        [Category(CategoryTimeout)]
        public int T7Timeout
        {
            get
            {
                try
                {
                    return m_fSdv.t7Timeout;
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
                    if (value < 1 || value > 240)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // --

                    m_fSdv.t7Timeout = value;
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

        [Category(CategoryTimeout)]
        public int T8Timeout
        {
            get
            {
                try
                {
                    return m_fSdv.t8Timeout;
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
                    if (value < 1 || value > 120)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value"}));
                    }

                    // --

                    m_fSdv.t8Timeout = value;
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

        #region User Tag

        [Category(CategoryUserTag)]
        public string UserTag1
        {
            get
            {
                try
                {
                    return m_fSdv.userTag1;
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
                    m_fSdv.userTag1 = value;
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

        [Category(CategoryUserTag)]
        public string UserTag2
        {
            get
            {
                try
                {
                    return m_fSdv.userTag2;
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
                    m_fSdv.userTag2 = value;
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

        [Category(CategoryUserTag)]
        public string UserTag3
        {
            get
            {
                try
                {
                    return m_fSdv.userTag3;
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
                    m_fSdv.userTag3 = value;
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

        [Category(CategoryUserTag)]
        public string UserTag4
        {
            get
            {
                try
                {
                    return m_fSdv.userTag4;
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
                    m_fSdv.userTag4 = value;
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

        [Category(CategoryUserTag)]
        public string UserTag5
        {
            get
            {
                try
                {
                    return m_fSdv.userTag5;
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
                    m_fSdv.userTag5 = value;
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

        [Browsable(false)]
        public FSecsDevice fSecsDevice
        {
            get
            {
                try
                {
                    return m_fSdv;
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
                base.fTypeDescriptor.properties["MaxSystemBytes"].attributes.replace(new DisplayNameAttribute("Max System Bytes"));
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
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DisplayNameAttribute(m_fSdv.defUserTagName1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DisplayNameAttribute(m_fSdv.defUserTagName2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DisplayNameAttribute(m_fSdv.defUserTagName3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DisplayNameAttribute(m_fSdv.defUserTagName4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DisplayNameAttribute(m_fSdv.defUserTagName5));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fSdv.fObjectType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fSdv.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fSdv.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fSdv.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fSdv.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fSdv.fontBold));
                // --
                base.fTypeDescriptor.properties["Mode"].attributes.replace(new DefaultValueAttribute(m_fSdv.fDeviceMode));
                base.fTypeDescriptor.properties["Protocol"].attributes.replace(new DefaultValueAttribute(m_fSdv.fProtocol));
                base.fTypeDescriptor.properties["ConnectMode"].attributes.replace(new DefaultValueAttribute(m_fSdv.fConnectMode));
                base.fTypeDescriptor.properties["LocalIp"].attributes.replace(new DefaultValueAttribute(m_fSdv.localIp));
                base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new DefaultValueAttribute(m_fSdv.localPort));
                base.fTypeDescriptor.properties["RemoteIp"].attributes.replace(new DefaultValueAttribute(m_fSdv.remoteIp));
                base.fTypeDescriptor.properties["RemotePort"].attributes.replace(new DefaultValueAttribute(m_fSdv.remotePort));
                base.fTypeDescriptor.properties["SerialPort"].attributes.replace(new DefaultValueAttribute(m_fSdv.serialPort));
                base.fTypeDescriptor.properties["Baud"].attributes.replace(new DefaultValueAttribute(m_fSdv.baud));
                base.fTypeDescriptor.properties["RBit"].attributes.replace(new DefaultValueAttribute(m_fSdv.rbit));
                base.fTypeDescriptor.properties["Interleave"].attributes.replace(new DefaultValueAttribute(m_fSdv.interleave));
                base.fTypeDescriptor.properties["DuplicateError"].attributes.replace(new DefaultValueAttribute(m_fSdv.duplicateError));
                base.fTypeDescriptor.properties["IgnoreSystemBytes"].attributes.replace(new DefaultValueAttribute(m_fSdv.ignoreSystemBytes));
                base.fTypeDescriptor.properties["LinkTestPeriod"].attributes.replace(new DefaultValueAttribute(m_fSdv.linkTestTimePeriod));
                base.fTypeDescriptor.properties["RetryLimit"].attributes.replace(new DefaultValueAttribute(m_fSdv.retryLimit));
                base.fTypeDescriptor.properties["MaxSystemBytes"].attributes.replace(new DefaultValueAttribute((int)m_fSdv.maxSystemBytes));
                // --
                base.fTypeDescriptor.properties["T1Timeout"].attributes.replace(new DefaultValueAttribute(m_fSdv.t1Timeout));
                base.fTypeDescriptor.properties["T2Timeout"].attributes.replace(new DefaultValueAttribute(m_fSdv.t2Timeout));
                base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new DefaultValueAttribute(m_fSdv.t3Timeout));
                base.fTypeDescriptor.properties["T4Timeout"].attributes.replace(new DefaultValueAttribute(m_fSdv.t4Timeout));
                base.fTypeDescriptor.properties["T5Timeout"].attributes.replace(new DefaultValueAttribute(m_fSdv.t5Timeout));
                base.fTypeDescriptor.properties["T6Timeout"].attributes.replace(new DefaultValueAttribute(m_fSdv.t6Timeout));
                base.fTypeDescriptor.properties["T7Timeout"].attributes.replace(new DefaultValueAttribute(m_fSdv.t7Timeout));
                base.fTypeDescriptor.properties["T8Timeout"].attributes.replace(new DefaultValueAttribute(m_fSdv.t8Timeout));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DefaultValueAttribute(m_fSdv.userTag1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DefaultValueAttribute(m_fSdv.userTag2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DefaultValueAttribute(m_fSdv.userTag3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DefaultValueAttribute(m_fSdv.userTag4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DefaultValueAttribute(m_fSdv.userTag5));

                // --

                procRefreshRequested();

                // --

                this.fPropGrid.DynPropGridRefreshRequested += new FDynPropGridRefreshRequestedEventHandler(fPropGrid_DynPropGridRefreshRequested);
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
                this.fPropGrid.DynPropGridRefreshRequested -= new FDynPropGridRefreshRequestedEventHandler(fPropGrid_DynPropGridRefreshRequested);
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

        private void procRefreshRequested(
            )
        {
            try
            {
                setChangedProtocol();
                setChangedState(m_fSdv.fState);
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
                base.fTypeDescriptor.properties["MaxSystemBytes"].attributes.replace(new BrowsableAttribute(false));
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
                
                if (m_fSdv.fProtocol == FProtocol.SECS1)
                {
                    base.fTypeDescriptor.properties["SerialPort"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Baud"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["RBit"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Interleave"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["DuplicateError"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["IgnoreSystemBytes"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["RetryLimit"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["MaxSystemBytes"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["T1Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T2Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T4Timeout"].attributes.replace(new BrowsableAttribute(true));
                }
                else if (
                    m_fSdv.fProtocol == FProtocol.TCPIP ||
                    m_fSdv.fProtocol == FProtocol.TELNET
                    )
                {
                    base.fTypeDescriptor.properties["ConnectMode"].attributes.replace(new BrowsableAttribute(true));
                    if (m_fSdv.fConnectMode == FConnectMode.Passive)
                    {
                        base.fTypeDescriptor.properties["LocalIp"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new BrowsableAttribute(true));
                    }
                    else
                    {
                        base.fTypeDescriptor.properties["LocalIp"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["RemoteIp"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["RemotePort"].attributes.replace(new BrowsableAttribute(true));
                    }
                    base.fTypeDescriptor.properties["RBit"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Interleave"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["DuplicateError"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["IgnoreSystemBytes"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["RetryLimit"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["MaxSystemBytes"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["T1Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T2Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T4Timeout"].attributes.replace(new BrowsableAttribute(true));
                }
                else if (m_fSdv.fProtocol == FProtocol.HSMS)
                {
                    base.fTypeDescriptor.properties["ConnectMode"].attributes.replace(new BrowsableAttribute(true));
                    if (m_fSdv.fConnectMode == FConnectMode.Passive)
                    {
                        base.fTypeDescriptor.properties["LocalIp"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new BrowsableAttribute(true));
                    }
                    else
                    {
                        base.fTypeDescriptor.properties["LocalIp"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["RemoteIp"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["RemotePort"].attributes.replace(new BrowsableAttribute(true));
                    }      
                    base.fTypeDescriptor.properties["LinkTestPeriod"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["MaxSystemBytes"].attributes.replace(new BrowsableAttribute(true));
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

        //------------------------------------------------------------------------------------------------------------------------

        public void setChangedState(
            FDeviceState fDeviceState
            )
        {
            bool stateCheck = false;

            try
            {
                if (fDeviceState != FDeviceState.Closed)
                {
                    stateCheck = true;
                }

                // --
                
                base.fTypeDescriptor.properties["Mode"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["Protocol"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["ConnectMode"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["LocalIp"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["RemoteIp"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["RemotePort"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["SerialPort"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["Baud"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["RBit"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["Interleave"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["DuplicateError"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["IgnoreSystemBytes"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["LinkTestPeriod"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["RetryLimit"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["MaxSystemBytes"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                // --
                base.fTypeDescriptor.properties["T1Timeout"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["T2Timeout"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["T4Timeout"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["T5Timeout"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["T6Timeout"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["T7Timeout"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["T8Timeout"].attributes.replace(new ReadOnlyAttribute(stateCheck));        

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

        #region fPropGrid Event Handler

        private void fPropGrid_DynPropGridRefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                procRefreshRequested();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
