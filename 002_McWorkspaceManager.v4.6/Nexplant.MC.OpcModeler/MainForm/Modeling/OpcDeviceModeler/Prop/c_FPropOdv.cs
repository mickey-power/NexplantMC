/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropOdv.cs
--  Creator         : duchoi
--  Create Date     : 2013.07.24
--  Description     : FAMate OPC Modeler OPC Device Property Source Object Class 
--  History         : Created by duchoi at 2011.07.24
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
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.OpcModeler
{
    public class FPropOdv : FDynPropCusBase<FOpmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryFont = "[02] Font";
        private const string CategoryProtocol = "[03] Protocol";
        private const string CategorySecurity = "[04] Security Policy";
        private const string CategoryTimeout = "[05] Timeout";
        private const string CategoryUserTag = "[06] User Tag";   

        // --

        private bool m_disposed = false;
        // --
        private FOpcDevice m_fOdv = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropOdv(
            FOpmCore fOpmCore,
            FDynPropGrid fPropGrid,
            FOpcDevice fOdv
            )
            : base(fOpmCore, fOpmCore.fUIWizard, fPropGrid)
        {
            m_fOdv = fOdv;
            // --
            init();   
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropOdv(
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
                    m_fOdv = null;
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
                    return m_fOdv.fObjectType.ToString();
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
                    return m_fOdv.uniqueIdToString;
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
                    return m_fOdv.name;
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

                    m_fOdv.name = value;
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
                    return m_fOdv.description;
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
                    m_fOdv.description = value;
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
                    return m_fOdv.fontColor;
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
                    m_fOdv.fontColor = value;
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
                    return m_fOdv.fontBold;
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
                    m_fOdv.fontBold = value;
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
        public FProtocol Protocol
        {
            get
            {
                try
                {
                    return m_fOdv.fProtocol;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FProtocol.KEPWARE;
            }

            set
            {
                try
                {
                    m_fOdv.fProtocol = value;
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
        public string Url
        {
            get
            {
                try
                {
                    return m_fOdv.url;
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

                    m_fOdv.url = value;
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

        // ***
        // Modified by spike.lee
        // OPC DA를 지원하기 위한 COM ID 추가
        // ***
        [Category(CategoryProtocol)]
        public string ProgId
        {
            get
            {
                try
                {
                    return m_fOdv.progId;
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

                    m_fOdv.progId = value;
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
        public int HandleId
        {
            get
            {
                try
                {
                    return m_fOdv.clientHandle;
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

                    m_fOdv.clientHandle = value;
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
        public string LocalId
        {
            get
            {
                try
                {
                    return m_fOdv.localId;
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

                    m_fOdv.localId = value;
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
        public string ItemNameFormat
        {
            get
            {
                try
                {
                    return m_fOdv.itemNameFormat;
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

                    m_fOdv.itemNameFormat = value;
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
        public string BrowerItemNameFormat
        {
            get
            {
                try
                {
                    return m_fOdv.browerItemNameFormat;
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

                    m_fOdv.browerItemNameFormat = value;
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
        public string Namespace
        {
            get
            {
                try
                {
                    return m_fOdv.defaultNamespace;
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

                    m_fOdv.defaultNamespace = value;
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
        public int KeepAliveTime
        {
            get
            {
                try
                {
                    return m_fOdv.keepAliveTime;
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
                    // ***
                    // Jungyoul 주석 : 범위 설정 필요.
                    // ***
                    if (value < 1 || value > 120)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // --

                    m_fOdv.keepAliveTime = value;
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
        public int EventReloadTime
        {
            get
            {
                try
                {
                    return m_fOdv.eventReloadTime;
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
                    // ***
                    // Jungyoul 주석 : 범위 설정 필요.
                    // ***
                    if (value < 1 || value > 120)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // --

                    m_fOdv.eventReloadTime = value;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
        #region  Security Policy

        //***
        //Add by Sunghoon.Park at 2019.06.26
        //OPC UA Security Policy 설정 Property 추가 
        [Category(CategorySecurity)]
        public FSecurityPolicy SecurityPolicy
        {
            get
            {
                try
                {
                    return m_fOdv.fSecurityPolicy;
                }
                catch(Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FSecurityPolicy.None;
            }
            set
            {
                try
                {
                    m_fOdv.fSecurityPolicy = value;
                    //--
                    setChangeSecurityPolicy();
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
        [Category(CategorySecurity)]
        public FSecurityMode SecurityMode
        {
            get
            {
                try
                {
                    return m_fOdv.fSecurityMode;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FSecurityMode.Sign;
            }
            set
            {
                try
                {
                    m_fOdv.fSecurityMode = value;
                    //--
                   
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
        [Category(CategorySecurity)]
        public string CertificateUrl
        {
            get
            {
                try
                {
                    return m_fOdv.certificateUrl;
                }
                catch(Exception ex)
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
                    if(value.Trim() == string.Empty)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    m_fOdv.certificateUrl = value;
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
        [Category(CategorySecurity)]
        public string StoreName
        {
            get
            {
                try
                {
                    return m_fOdv.storeName;
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

                    m_fOdv.storeName = value;
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

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryTimeout)]
        public float T2Timeout
        {
            get
            {
                try
                {
                    return m_fOdv.t2Timeout;
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

                    m_fOdv.t2Timeout = value;
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
                    return m_fOdv.t3Timeout;
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

                    m_fOdv.t3Timeout = value;
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
                    return m_fOdv.t5Timeout;
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

                    m_fOdv.t5Timeout = value;
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
                    return m_fOdv.userTag1;
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
                    m_fOdv.userTag1 = value;
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
                    return m_fOdv.userTag2;
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
                    m_fOdv.userTag2 = value;
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
                    return m_fOdv.userTag3;
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
                    m_fOdv.userTag3 = value;
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
                    return m_fOdv.userTag4;
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
                    m_fOdv.userTag4 = value;
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
                    return m_fOdv.userTag5;
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
                    m_fOdv.userTag5 = value;
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
        public FOpcDevice fOpcDevice
        {
            get
            {
                try
                {
                    return m_fOdv;
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
                base.fTypeDescriptor.properties["Protocol"].attributes.replace(new DisplayNameAttribute("Protocol"));
                base.fTypeDescriptor.properties["Url"].attributes.replace(new DisplayNameAttribute("Url"));
                base.fTypeDescriptor.properties["ProgId"].attributes.replace(new DisplayNameAttribute("Prog ID"));
                base.fTypeDescriptor.properties["HandleId"].attributes.replace(new DisplayNameAttribute("Handle ID"));
                base.fTypeDescriptor.properties["LocalId"].attributes.replace(new DisplayNameAttribute("Local ID"));
                base.fTypeDescriptor.properties["ItemNameFormat"].attributes.replace(new DisplayNameAttribute("Item Name Format"));
                base.fTypeDescriptor.properties["BrowerItemNameFormat"].attributes.replace(new DisplayNameAttribute("Brower Item Name Format"));
                base.fTypeDescriptor.properties["Namespace"].attributes.replace(new DisplayNameAttribute("Default Namespace"));
                base.fTypeDescriptor.properties["KeepAliveTime"].attributes.replace(new DisplayNameAttribute("Keep Alive Time"));
                base.fTypeDescriptor.properties["EventReloadTime"].attributes.replace(new DisplayNameAttribute("Event Reload Time"));
                //-- 
                base.fTypeDescriptor.properties["SecurityPolicy"].attributes.replace(new DisplayNameAttribute("Security"));
                base.fTypeDescriptor.properties["SecurityMode"].attributes.replace(new DisplayNameAttribute("Mode"));
                base.fTypeDescriptor.properties["CertificateUrl"].attributes.replace(new DisplayNameAttribute("Certificate Url"));
                base.fTypeDescriptor.properties["StoreName"].attributes.replace(new DisplayNameAttribute("Store Name"));
                // --
                base.fTypeDescriptor.properties["T2Timeout"].attributes.replace(new DisplayNameAttribute("T2 Timeout"));
                base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new DisplayNameAttribute("T3 Timeout"));
                base.fTypeDescriptor.properties["T5Timeout"].attributes.replace(new DisplayNameAttribute("T5 Timeout"));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DisplayNameAttribute(m_fOdv.defUserTagName1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DisplayNameAttribute(m_fOdv.defUserTagName2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DisplayNameAttribute(m_fOdv.defUserTagName3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DisplayNameAttribute(m_fOdv.defUserTagName4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DisplayNameAttribute(m_fOdv.defUserTagName5));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fOdv.fObjectType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fOdv.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fOdv.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fOdv.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fOdv.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fOdv.fontBold));
                // --
                base.fTypeDescriptor.properties["Protocol"].attributes.replace(new DefaultValueAttribute(m_fOdv.fProtocol));
                base.fTypeDescriptor.properties["Url"].attributes.replace(new DefaultValueAttribute(m_fOdv.url));
                base.fTypeDescriptor.properties["ProgId"].attributes.replace(new DefaultValueAttribute(m_fOdv.progId));
                base.fTypeDescriptor.properties["HandleId"].attributes.replace(new DefaultValueAttribute(m_fOdv.clientHandle));
                base.fTypeDescriptor.properties["LocalId"].attributes.replace(new DefaultValueAttribute(m_fOdv.localId));
                base.fTypeDescriptor.properties["ItemNameFormat"].attributes.replace(new DefaultValueAttribute(m_fOdv.itemNameFormat));
                base.fTypeDescriptor.properties["BrowerItemNameFormat"].attributes.replace(new DefaultValueAttribute(m_fOdv.browerItemNameFormat));
                base.fTypeDescriptor.properties["Namespace"].attributes.replace(new DefaultValueAttribute(m_fOdv.defaultNamespace));
                base.fTypeDescriptor.properties["KeepAliveTime"].attributes.replace(new DefaultValueAttribute(m_fOdv.keepAliveTime));
                base.fTypeDescriptor.properties["EventReloadTime"].attributes.replace(new DefaultValueAttribute(m_fOdv.eventReloadTime));
                //--
                base.fTypeDescriptor.properties["SecurityPolicy"].attributes.replace(new DefaultValueAttribute(m_fOdv.fSecurityPolicy));
                base.fTypeDescriptor.properties["SecurityMode"].attributes.replace(new DefaultValueAttribute(m_fOdv.fSecurityMode));
                base.fTypeDescriptor.properties["CertificateUrl"].attributes.replace(new DefaultValueAttribute(m_fOdv.certificateUrl));
                base.fTypeDescriptor.properties["StoreName"].attributes.replace(new DefaultValueAttribute(m_fOdv.storeName));
                // --
                base.fTypeDescriptor.properties["T2Timeout"].attributes.replace(new DefaultValueAttribute(m_fOdv.t2Timeout));
                base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new DefaultValueAttribute(m_fOdv.t3Timeout));
                base.fTypeDescriptor.properties["T5Timeout"].attributes.replace(new DefaultValueAttribute(m_fOdv.t5Timeout));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DefaultValueAttribute(m_fOdv.userTag1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DefaultValueAttribute(m_fOdv.userTag2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DefaultValueAttribute(m_fOdv.userTag3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DefaultValueAttribute(m_fOdv.userTag4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DefaultValueAttribute(m_fOdv.userTag5));

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
                setChangeSecurityPolicy();
                setChangedState(m_fOdv.fState);
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
                base.fTypeDescriptor.properties["Url"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["ProgId"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["HandleId"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["LocalId"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["ItemNameFormat"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["BrowerItemNameFormat"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["Namespace"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["KeepAliveTime"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["EventReloadTime"].attributes.replace(new BrowsableAttribute(false));          
                       
                // --

                // ***
                // Modified by spike.lee at 2016.01.19
                // 프로토콜이 OPC DA인 경우에만 COM ID 입력 가능하도록 처리
                // ***
                if (m_fOdv.fProtocol == FProtocol.KEPWARE || m_fOdv.fProtocol == FProtocol.OPCUA)
                {
                    base.fTypeDescriptor.properties["Url"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["HandleId"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["LocalId"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["ItemNameFormat"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["BrowerItemNameFormat"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Namespace"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["KeepAliveTime"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["EventReloadTime"].attributes.replace(new BrowsableAttribute(true));
                }
                else if (m_fOdv.fProtocol == FProtocol.OPCDA) 
                {
                    base.fTypeDescriptor.properties["Url"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["ProgId"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["HandleId"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["LocalId"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["ItemNameFormat"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["BrowerItemNameFormat"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Namespace"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["KeepAliveTime"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["EventReloadTime"].attributes.replace(new BrowsableAttribute(true));
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
        public void setChangeSecurityPolicy(
            )
        {
            try
            {

                base.fTypeDescriptor.properties["SecurityMode"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["CertificateUrl"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["StoreName"].attributes.replace(new BrowsableAttribute(false));

                if (m_fOdv.fSecurityPolicy == FSecurityPolicy.None)
                {
                    base.fTypeDescriptor.properties["SecurityMode"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["CertificateUrl"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["StoreName"].attributes.replace(new BrowsableAttribute(false));
                }
                else if(m_fOdv.fSecurityPolicy == FSecurityPolicy.Basic128Rsa15 || m_fOdv.fSecurityPolicy == FSecurityPolicy.Basic256)
                {
                    base.fTypeDescriptor.properties["SecurityMode"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["CertificateUrl"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["StoreName"].attributes.replace(new BrowsableAttribute(true));
                }
            }
            catch(Exception ex)
            {
                FDebug.throwException(ex);
            }

        }

        //------------------------------------------------------------------------------------------------------------------------
        public void setChangeSecurityMode()
        {
            try
            {
                base.fTypeDescriptor.properties["CertificateUrl"].attributes.replace(new DefaultValueAttribute(""));
                base.fTypeDescriptor.properties["StoreName"].attributes.replace(new DefaultValueAttribute(""));
            }
            catch(Exception ex)
            {
                FDebug.throwException(ex);
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
                
                base.fTypeDescriptor.properties["Protocol"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["Url"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["ProgId"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["HandleId"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["LocalId"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["ItemNameFormat"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["BrowerItemNameFormat"].attributes.replace(new ReadOnlyAttribute(stateCheck));              
                base.fTypeDescriptor.properties["Namespace"].attributes.replace(new ReadOnlyAttribute(stateCheck));              
                base.fTypeDescriptor.properties["KeepAliveTime"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["EventReloadTime"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["SecurityPolicy"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["SecurityMode"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["CertificateUrl"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["StoreName"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["T2Timeout"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new ReadOnlyAttribute(stateCheck));
                base.fTypeDescriptor.properties["T5Timeout"].attributes.replace(new ReadOnlyAttribute(stateCheck));              

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
