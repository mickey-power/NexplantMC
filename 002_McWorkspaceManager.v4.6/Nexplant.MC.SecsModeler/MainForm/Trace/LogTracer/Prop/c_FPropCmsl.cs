/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropCmsl.cs
--  Creator         : byJeon
--  Create Date     : 2011.10.04
--  Description     : FAMate SECS Modeler SECS Device Control Message Sent Log Property Source Object Class 
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
    public class FPropCmsl : FDynPropCusBase<FSsmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryResult = "[01] Result";
        private const string CategoryGeneral = "[02] General";
        private const string CategoryFont = "[03] Font";
        private const string CategoryMessage = "[04] Message";

        // --

        private bool m_disposed = false;
        // --
        private FSecsDeviceControlMessageSentLog m_fCmsl = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropCmsl(
            FSsmCore fSsmCore,
            FDynPropGrid fPropGrid,
            FSecsDeviceControlMessageSentLog fCmsl
            )
            : base(fSsmCore, fSsmCore.fUIWizard, fPropGrid)
        {
            m_fCmsl = fCmsl;
            // --
            init();   
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropCmsl(
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
                    m_fCmsl = null;
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
                    return m_fCmsl.time;
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
                    return m_fCmsl.fResultCode;
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
                    return m_fCmsl.resultMessage;
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
                    return m_fCmsl.fObjectLogType.ToString();
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
                    return m_fCmsl.uniqueIdToString;
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
                    return m_fCmsl.name;
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
                    return m_fCmsl.description;
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
                    return m_fCmsl.fontColor;
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
                    return m_fCmsl.fontBold;
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

        #region Message

        [Category(CategoryMessage)]
        public FControlMessageType ControlMessageType
        {
            get
            {
                try
                {
                    return m_fCmsl.fType;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FControlMessageType.SelectReq;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryMessage)]
        public string Reason
        {
            get
            {
                try
                {
                    return m_fCmsl.reason;
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

        [Category(CategoryMessage)]
        public int SessionID
        {
            get
            {
                try
                {
                    return m_fCmsl.sessionId;
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

        [Category(CategoryMessage)]
        public byte Byte2
        {
            get
            {
                try
                {
                    return m_fCmsl.byte2;
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

        [Category(CategoryMessage)]
        public byte Byte3
        {
            get
            {
                try
                {
                    return m_fCmsl.byte3;
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

        [Category(CategoryMessage)]
        public byte Ptype
        {
            get
            {
                try
                {
                    return m_fCmsl.ptype;
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

        [Category(CategoryMessage)]
        public byte Stype
        {
            get
            {
                try
                {
                    return m_fCmsl.stype;
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

        [Category(CategoryMessage)]
        public long SystemBytes
        {
            get
            {
                try
                {
                    return m_fCmsl.systemBytes;
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

        [Category(CategoryMessage)]
        public long Length
        {
            get
            {
                try
                {
                    return m_fCmsl.length;
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
        public FSecsDeviceControlMessageSentLog fSecsDeviceControlMessageReceivedLog
        {
            get
            {
                try
                {
                    return m_fCmsl;
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
                base.fTypeDescriptor.properties["ControlMessageType"].attributes.replace(new DisplayNameAttribute("Control Message Type"));
                base.fTypeDescriptor.properties["Reason"].attributes.replace(new DisplayNameAttribute("Reason"));
                base.fTypeDescriptor.properties["SessionID"].attributes.replace(new DisplayNameAttribute("Session ID"));
                base.fTypeDescriptor.properties["Byte2"].attributes.replace(new DisplayNameAttribute("Byte2"));
                base.fTypeDescriptor.properties["Byte3"].attributes.replace(new DisplayNameAttribute("Byte3"));
                base.fTypeDescriptor.properties["Ptype"].attributes.replace(new DisplayNameAttribute("P-Type"));
                base.fTypeDescriptor.properties["Stype"].attributes.replace(new DisplayNameAttribute("S-Type"));
                base.fTypeDescriptor.properties["SystemBytes"].attributes.replace(new DisplayNameAttribute("System Bytes"));
                base.fTypeDescriptor.properties["Length"].attributes.replace(new DisplayNameAttribute("Length"));
                
                // --

                base.fTypeDescriptor.properties["Time"].attributes.replace(new DefaultValueAttribute(m_fCmsl.time));
                base.fTypeDescriptor.properties["ResultCode"].attributes.replace(new DefaultValueAttribute(m_fCmsl.fResultCode));
                base.fTypeDescriptor.properties["ResultMessage"].attributes.replace(new DefaultValueAttribute(m_fCmsl.resultMessage));                
                // --
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fCmsl.fObjectLogType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fCmsl.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fCmsl.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fCmsl.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fCmsl.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fCmsl.fontBold));
                // --
                base.fTypeDescriptor.properties["ControlMessageType"].attributes.replace(new DefaultValueAttribute(m_fCmsl.fType));
                base.fTypeDescriptor.properties["Reason"].attributes.replace(new DefaultValueAttribute(m_fCmsl.reason));
                base.fTypeDescriptor.properties["SessionID"].attributes.replace(new DefaultValueAttribute(m_fCmsl.sessionId));
                base.fTypeDescriptor.properties["Byte2"].attributes.replace(new DefaultValueAttribute(m_fCmsl.byte2));
                base.fTypeDescriptor.properties["Byte3"].attributes.replace(new DefaultValueAttribute(m_fCmsl.byte3));
                base.fTypeDescriptor.properties["Ptype"].attributes.replace(new DefaultValueAttribute(m_fCmsl.ptype));
                base.fTypeDescriptor.properties["Stype"].attributes.replace(new DefaultValueAttribute(m_fCmsl.stype));
                base.fTypeDescriptor.properties["SystemBytes"].attributes.replace(new DefaultValueAttribute(m_fCmsl.systemBytes));
                base.fTypeDescriptor.properties["Length"].attributes.replace(new DefaultValueAttribute(m_fCmsl.length));
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

    }   // Class end
}   // Namespace end
