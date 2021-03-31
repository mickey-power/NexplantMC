/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropSmsl.cs
--  Creator         : byJeon
--  Create Date     : 2011.10.13
--  Description     : FAMate SECS Modeler SECS Device Sml Sent Log Property Source Object Class 
--  History         : Created by byJeon at 2011.10.13
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager.FaSecsLogViewer
{
    class FPropSmsl : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryResult = "[01] Result";
        private const string CategoryGeneral = "[02] General";
        private const string CategoryFont = "[03] Font";
        private const string CategoryLength = "[04] Length";
        private const string CategoryHeader = "[05] Header";

        // --

        private bool m_disposed = false;
        // --
        private FSecsDeviceSmlSentLog m_fSmsl = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropSmsl(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FSecsDeviceSmlSentLog fSmsl
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_fSmsl = fSmsl;
            // --
            init();   
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropSmsl(
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
                    m_fSmsl = null;
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
                    return m_fSmsl.time;
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
                    return m_fSmsl.fResultCode;
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
                    return m_fSmsl.resultMessage;
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
                    return m_fSmsl.fObjectLogType.ToString();
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
                    return m_fSmsl.uniqueIdToString;
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
                    return m_fSmsl.name;
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
                    return m_fSmsl.description;
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
                    return m_fSmsl.fontColor;
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
                    return m_fSmsl.fontBold;
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

        #region Length

        [Category(CategoryLength)]
        public long Length
        {
            get
            {
                try
                {
                    return m_fSmsl.length;
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

        #region Header

        [Category(CategoryHeader)]
        public int SessionId
        {
            get
            {
                try
                {
                    return m_fSmsl.sessionId;
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

        [Category(CategoryHeader)]
        public int Stream
        {
            get
            {
                try
                {
                    return m_fSmsl.stream;
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

        [Category(CategoryHeader)]
        public int Function
        {
            get
            {
                try
                {
                    return m_fSmsl.function;
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

        [Category(CategoryHeader)]
        public bool WBit
        {
            get
            {
                try
                {
                    return m_fSmsl.wBit;
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

        [Category(CategoryHeader)]
        public long SystemBytes
        {
            get
            {
                try
                {
                    return m_fSmsl.systemBytes;
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

        #region Properties

        [Browsable(false)]
        public FSecsDeviceSmlSentLog fSecsDeviceSmlSentLog
        {
            get
            {
                try
                {
                    return m_fSmsl;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
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
                base.fTypeDescriptor.properties["Length"].attributes.replace(new DisplayNameAttribute("Length"));
                // --
                base.fTypeDescriptor.properties["SessionId"].attributes.replace(new DisplayNameAttribute("Session ID"));
                base.fTypeDescriptor.properties["Stream"].attributes.replace(new DisplayNameAttribute("Stream"));
                base.fTypeDescriptor.properties["Function"].attributes.replace(new DisplayNameAttribute("Function"));
                base.fTypeDescriptor.properties["WBit"].attributes.replace(new DisplayNameAttribute("W-Bit"));
                base.fTypeDescriptor.properties["SystemBytes"].attributes.replace(new DisplayNameAttribute("System Bytes"));

                // -- 

                base.fTypeDescriptor.properties["Time"].attributes.replace(new DefaultValueAttribute(m_fSmsl.time));
                base.fTypeDescriptor.properties["ResultCode"].attributes.replace(new DefaultValueAttribute(m_fSmsl.fResultCode));
                base.fTypeDescriptor.properties["ResultMessage"].attributes.replace(new DefaultValueAttribute(m_fSmsl.resultMessage));
                // --
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fSmsl.fObjectLogType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fSmsl.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fSmsl.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fSmsl.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fSmsl.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fSmsl.fontBold));
                // --
                base.fTypeDescriptor.properties["Length"].attributes.replace(new DefaultValueAttribute(m_fSmsl.length));
                // --
                base.fTypeDescriptor.properties["SessionId"].attributes.replace(new DefaultValueAttribute(m_fSmsl.sessionId));
                base.fTypeDescriptor.properties["Stream"].attributes.replace(new DefaultValueAttribute(m_fSmsl.stream));
                base.fTypeDescriptor.properties["Function"].attributes.replace(new DefaultValueAttribute(m_fSmsl.function));
                base.fTypeDescriptor.properties["WBit"].attributes.replace(new DefaultValueAttribute(m_fSmsl.wBit));
                base.fTypeDescriptor.properties["SystemBytes"].attributes.replace(new DefaultValueAttribute(m_fSmsl.systemBytes));
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    } // Class end
} // Namespace end