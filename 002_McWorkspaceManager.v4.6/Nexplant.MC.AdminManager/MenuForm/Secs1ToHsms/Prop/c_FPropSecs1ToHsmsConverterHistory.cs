/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropSecs1ToHsmsConverterHistory.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.28
--  Description     : FAmate Admin Manager SECS1 To HSMS Converter History Property Source Object Class 
--  History         : Created by spike.lee at 2017.04.28
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
    public class FPropSecs1ToHsmsConverterHistory : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryEvent = "[02] Event";
        private const string CategoryState = "[03] State";
        private const string CategoryData = "[04] Data Field";
        private const string CategoryComment = "[05] Comments";

        // --

        private bool m_disposed = false;
        string m_tranTime = string.Empty;
        string m_converter = string.Empty;
        string m_converterIp = string.Empty;
        string m_eventId = string.Empty;
        string m_upDown = string.Empty;
        string m_secs1State = string.Empty;
        string m_hsmsState = string.Empty;
        string m_userId = string.Empty;
        string m_eventHeader1 = string.Empty;
        string m_eventData1 = string.Empty;
        string m_eventHeader2 = string.Empty;
        string m_eventData2 = string.Empty;
        string m_eventHeader3 = string.Empty;
        string m_eventData3 = string.Empty;
        string m_eventHeader4 = string.Empty;
        string m_eventData4 = string.Empty;
        string m_eventHeader5 = string.Empty;
        string m_eventData5 = string.Empty;
        string m_eventHeader6 = string.Empty;
        string m_eventData6 = string.Empty;
        string m_eventHeader7 = string.Empty;
        string m_eventData7 = string.Empty;
        string m_eventHeader8 = string.Empty;
        string m_eventData8 = string.Empty;
        string m_eventHeader9 = string.Empty;
        string m_eventData9 = string.Empty;
        string m_eventHeader10 = string.Empty;
        string m_eventData10 = string.Empty;
        string m_eventHeader11 = string.Empty;
        string m_eventData11 = string.Empty;
        string m_eventHeader12 = string.Empty;
        string m_eventData12 = string.Empty;
        string m_eventHeader13 = string.Empty;
        string m_eventData13 = string.Empty;
        string m_eventHeader14 = string.Empty;
        string m_eventData14 = string.Empty;
        string m_eventHeader15 = string.Empty;
        string m_eventData15 = string.Empty;
        string m_eventHeader16 = string.Empty;
        string m_eventData16 = string.Empty;
        string m_eventHeader17 = string.Empty;
        string m_eventData17 = string.Empty;
        string m_eventHeader18 = string.Empty;
        string m_eventData18 = string.Empty;
        string m_eventHeader19 = string.Empty;
        string m_eventData19 = string.Empty;
        string m_eventHeader20 = string.Empty;
        string m_eventData20 = string.Empty;
        string m_comments = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropSecs1ToHsmsConverterHistory(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            DataRow dr
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            init(dr);   
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropSecs1ToHsmsConverterHistory(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid
            )
            : this(fAdmCore, fPropGrid, null)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropSecs1ToHsmsConverterHistory(
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

        #region  General

        [Category(CategoryGeneral)]
        public string Time
        {
            get
            {
                try
                {
                    return m_tranTime;
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
        }        

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        public string ConverterIp
        {
            get
            {
                try
                {
                    return m_converterIp;
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
        public string UserId
        {
            get
            {
                try
                {
                    return m_userId;
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

        #region Event
        
        [Category(CategoryEvent)]
        public string EventId
        {
            get
            {
                try
                {
                    return m_eventId;
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

        #region State

        [Category(CategoryGeneral)]
        public string UpDown
        {
            get
            {
                try
                {
                    return m_upDown;
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

        [Category(CategoryState)]
        public string Secs1State
        {
            get
            {
                try
                {
                    return m_secs1State;
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

        [Category(CategoryState)]
        public string HsmsState
        {
            get
            {
                try
                {
                    return m_hsmsState;
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

        #region Customizing Field

        [Category(CategoryData)]
        public string Data1
        {
            get
            {
                try
                {
                    return m_eventData1;
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

        [Category(CategoryData)]
        public string Data2
        {
            get
            {
                try
                {
                    return m_eventData2;
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

        [Category(CategoryData)]
        public string Data3
        {
            get
            {
                try
                {
                    return m_eventData3;
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

        [Category(CategoryData)]
        public string Data4
        {
            get
            {
                try
                {
                    return m_eventData4;
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

        [Category(CategoryData)]
        public string Data5
        {
            get
            {
                try
                {
                    return m_eventData5;
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

        [Category(CategoryData)]
        public string Data6
        {
            get
            {
                try
                {
                    return m_eventData6;
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

        [Category(CategoryData)]
        public string Data7
        {
            get
            {
                try
                {
                    return m_eventData7;
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

        [Category(CategoryData)]
        public string Data8
        {
            get
            {
                try
                {
                    return m_eventData8;
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

        [Category(CategoryData)]
        public string Data9
        {
            get
            {
                try
                {
                    return m_eventData9;
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

        [Category(CategoryData)]
        public string Data10
        {
            get
            {
                try
                {
                    return m_eventData10;
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

        [Category(CategoryData)]
        public string Data11
        {
            get
            {
                try
                {
                    return m_eventData11;
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

        [Category(CategoryData)]
        public string Data12
        {
            get
            {
                try
                {
                    return m_eventData12;
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

        [Category(CategoryData)]
        public string Data13
        {
            get
            {
                try
                {
                    return m_eventData13;
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

        [Category(CategoryData)]
        public string Data14
        {
            get
            {
                try
                {
                    return m_eventData14;
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

        [Category(CategoryData)]
        public string Data15
        {
            get
            {
                try
                {
                    return m_eventData15;
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

        [Category(CategoryData)]
        public string Data16
        {
            get
            {
                try
                {
                    return m_eventData16;
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

        [Category(CategoryData)]
        public string Data17
        {
            get
            {
                try
                {
                    return m_eventData17;
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

        [Category(CategoryData)]
        public string Data18
        {
            get
            {
                try
                {
                    return m_eventData18;
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

        [Category(CategoryData)]
        public string Data19
        {
            get
            {
                try
                {
                    return m_eventData19;
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

        [Category(CategoryData)]
        public string Data20
        {
            get
            {
                try
                {
                    return m_eventData20;
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

        #region Comments

        [Category(CategoryComment)]
        [Editor(typeof(FPropAttrCommentViewUITypeEditor), typeof(UITypeEditor))]
        public string Comment
        {
            get
            {
                try
                {
                    return m_comments;
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
            DataRow dr
            )
        {
            try
            {
                if (dr != null)
                {
                    m_tranTime          = FDataConvert.defaultDataTimeFormating(dr["TRAN_TIME"].ToString());
                    m_converter         = dr["CVT_NAME"].ToString();
                    m_converterIp       = dr["CVT_IP"].ToString();
                    m_eventId           = dr["EVENT_ID"].ToString();
                    m_upDown            = dr["UP_DOWN"].ToString();
                    m_secs1State        = dr["SECS1_STATE"].ToString();
                    m_hsmsState         = dr["HSMS_STATE"].ToString();
                    m_userId            = dr["TRAN_USER_ID"].ToString();
                    m_eventHeader1      = dr["EVT_H_1"].ToString();
                    m_eventData1        = dr["EVT_D_1"].ToString();
                    m_eventHeader2      = dr["EVT_H_2"].ToString();
                    m_eventData2        = dr["EVT_D_2"].ToString();
                    m_eventHeader3      = dr["EVT_H_3"].ToString();
                    m_eventData3        = dr["EVT_D_3"].ToString();
                    m_eventHeader4      = dr["EVT_H_4"].ToString();
                    m_eventData4        = dr["EVT_D_4"].ToString();
                    m_eventHeader5      = dr["EVT_H_5"].ToString();
                    m_eventData5        = dr["EVT_D_5"].ToString();
                    m_eventHeader6      = dr["EVT_H_6"].ToString();
                    m_eventData6        = dr["EVT_D_6"].ToString();
                    m_eventHeader7      = dr["EVT_H_7"].ToString();
                    m_eventData7        = dr["EVT_D_7"].ToString();
                    m_eventHeader8      = dr["EVT_H_8"].ToString();
                    m_eventData8        = dr["EVT_D_8"].ToString();
                    m_eventHeader9      = dr["EVT_H_9"].ToString();
                    m_eventData9        = dr["EVT_D_9"].ToString();
                    m_eventHeader10     = dr["EVT_H_10"].ToString();
                    m_eventData10       = dr["EVT_D_10"].ToString();
                    m_eventHeader11     = dr["EVT_H_11"].ToString();
                    m_eventData11       = dr["EVT_D_11"].ToString();
                    m_eventHeader12     = dr["EVT_H_12"].ToString();
                    m_eventData12       = dr["EVT_D_12"].ToString();
                    m_eventHeader13     = dr["EVT_H_13"].ToString();
                    m_eventData13       = dr["EVT_D_13"].ToString();
                    m_eventHeader14     = dr["EVT_H_14"].ToString();
                    m_eventData14       = dr["EVT_D_14"].ToString();
                    m_eventHeader15     = dr["EVT_H_15"].ToString();
                    m_eventData15       = dr["EVT_D_15"].ToString();
                    m_eventHeader16     = dr["EVT_H_16"].ToString();
                    m_eventData16       = dr["EVT_D_16"].ToString();
                    m_eventHeader17     = dr["EVT_H_17"].ToString();
                    m_eventData17       = dr["EVT_D_17"].ToString();
                    m_eventHeader18     = dr["EVT_H_18"].ToString();
                    m_eventData18       = dr["EVT_D_18"].ToString();
                    m_eventHeader19     = dr["EVT_H_19"].ToString();
                    m_eventData19       = dr["EVT_D_19"].ToString();
                    m_eventHeader20     = dr["EVT_H_20"].ToString();
                    m_eventData20       = dr["EVT_D_20"].ToString();
                    m_comments          = dr["TRAN_COMMENT"].ToString();
                }

                // --

                base.fTypeDescriptor.properties["Time"].attributes.replace(new DisplayNameAttribute("Time"));
                base.fTypeDescriptor.properties["Converter"].attributes.replace(new DisplayNameAttribute("Converter"));
                base.fTypeDescriptor.properties["Converter IP"].attributes.replace(new DisplayNameAttribute("Converter IP"));
                base.fTypeDescriptor.properties["UserId"].attributes.replace(new DisplayNameAttribute("User ID"));
                // --
                base.fTypeDescriptor.properties["EventId"].attributes.replace(new DisplayNameAttribute("Event ID"));
                // --
                base.fTypeDescriptor.properties["UpDown"].attributes.replace(new DisplayNameAttribute("Up/Down"));
                base.fTypeDescriptor.properties["Secs1State"].attributes.replace(new DisplayNameAttribute("SECS1 State"));
                base.fTypeDescriptor.properties["HsmsState"].attributes.replace(new DisplayNameAttribute("HSMS State"));
                // --
                base.fTypeDescriptor.properties["Data1"].attributes.replace(new DisplayNameAttribute(m_eventHeader1));
                base.fTypeDescriptor.properties["Data2"].attributes.replace(new DisplayNameAttribute(m_eventHeader2));
                base.fTypeDescriptor.properties["Data3"].attributes.replace(new DisplayNameAttribute(m_eventHeader3));
                base.fTypeDescriptor.properties["Data4"].attributes.replace(new DisplayNameAttribute(m_eventHeader4));
                base.fTypeDescriptor.properties["Data5"].attributes.replace(new DisplayNameAttribute(m_eventHeader5));
                base.fTypeDescriptor.properties["Data6"].attributes.replace(new DisplayNameAttribute(m_eventHeader6));
                base.fTypeDescriptor.properties["Data7"].attributes.replace(new DisplayNameAttribute(m_eventHeader7));
                base.fTypeDescriptor.properties["Data8"].attributes.replace(new DisplayNameAttribute(m_eventHeader8));
                base.fTypeDescriptor.properties["Data9"].attributes.replace(new DisplayNameAttribute(m_eventHeader9));
                base.fTypeDescriptor.properties["Data10"].attributes.replace(new DisplayNameAttribute(m_eventHeader10));
                base.fTypeDescriptor.properties["Data11"].attributes.replace(new DisplayNameAttribute(m_eventHeader11));
                base.fTypeDescriptor.properties["Data12"].attributes.replace(new DisplayNameAttribute(m_eventHeader12));
                base.fTypeDescriptor.properties["Data13"].attributes.replace(new DisplayNameAttribute(m_eventHeader13));
                base.fTypeDescriptor.properties["Data14"].attributes.replace(new DisplayNameAttribute(m_eventHeader14));
                base.fTypeDescriptor.properties["Data15"].attributes.replace(new DisplayNameAttribute(m_eventHeader15));
                base.fTypeDescriptor.properties["Data16"].attributes.replace(new DisplayNameAttribute(m_eventHeader16));
                base.fTypeDescriptor.properties["Data17"].attributes.replace(new DisplayNameAttribute(m_eventHeader17));
                base.fTypeDescriptor.properties["Data18"].attributes.replace(new DisplayNameAttribute(m_eventHeader18));
                base.fTypeDescriptor.properties["Data19"].attributes.replace(new DisplayNameAttribute(m_eventHeader19));
                base.fTypeDescriptor.properties["Data20"].attributes.replace(new DisplayNameAttribute(m_eventHeader20));
                // --
                base.fTypeDescriptor.properties["Comment"].attributes.replace(new DisplayNameAttribute("Comment"));

                // --

				base.fTypeDescriptor.properties["Time"].attributes.replace(new DefaultValueAttribute(m_tranTime));
                base.fTypeDescriptor.properties["Converter"].attributes.replace(new DefaultValueAttribute(m_converter));
                base.fTypeDescriptor.properties["ConverterIp"].attributes.replace(new DefaultValueAttribute(m_converterIp));
                base.fTypeDescriptor.properties["UserId"].attributes.replace(new DefaultValueAttribute(m_userId));
                // --
                base.fTypeDescriptor.properties["EventId"].attributes.replace(new DefaultValueAttribute(m_eventId));
                // --
                base.fTypeDescriptor.properties["UpDown"].attributes.replace(new DefaultValueAttribute(m_upDown));
                base.fTypeDescriptor.properties["Secs1State"].attributes.replace(new DefaultValueAttribute(m_secs1State));
                base.fTypeDescriptor.properties["HsmsState"].attributes.replace(new DefaultValueAttribute(m_hsmsState));
                // --
                base.fTypeDescriptor.properties["Data1"].attributes.replace(new DefaultValueAttribute(m_eventData1));
                base.fTypeDescriptor.properties["Data2"].attributes.replace(new DefaultValueAttribute(m_eventData2));
                base.fTypeDescriptor.properties["Data3"].attributes.replace(new DefaultValueAttribute(m_eventData3));
                base.fTypeDescriptor.properties["Data4"].attributes.replace(new DefaultValueAttribute(m_eventData4));
                base.fTypeDescriptor.properties["Data5"].attributes.replace(new DefaultValueAttribute(m_eventData5));
                base.fTypeDescriptor.properties["Data6"].attributes.replace(new DefaultValueAttribute(m_eventData6));
                base.fTypeDescriptor.properties["Data7"].attributes.replace(new DefaultValueAttribute(m_eventData7));
                base.fTypeDescriptor.properties["Data8"].attributes.replace(new DefaultValueAttribute(m_eventData8));
                base.fTypeDescriptor.properties["Data9"].attributes.replace(new DefaultValueAttribute(m_eventData9));
                base.fTypeDescriptor.properties["Data10"].attributes.replace(new DefaultValueAttribute(m_eventData10));
                base.fTypeDescriptor.properties["Data11"].attributes.replace(new DefaultValueAttribute(m_eventData11));
                base.fTypeDescriptor.properties["Data12"].attributes.replace(new DefaultValueAttribute(m_eventData12));
                base.fTypeDescriptor.properties["Data13"].attributes.replace(new DefaultValueAttribute(m_eventData13));
                base.fTypeDescriptor.properties["Data14"].attributes.replace(new DefaultValueAttribute(m_eventData14));
                base.fTypeDescriptor.properties["Data15"].attributes.replace(new DefaultValueAttribute(m_eventData15));
                base.fTypeDescriptor.properties["Data16"].attributes.replace(new DefaultValueAttribute(m_eventData16));
                base.fTypeDescriptor.properties["Data17"].attributes.replace(new DefaultValueAttribute(m_eventData17));
                base.fTypeDescriptor.properties["Data18"].attributes.replace(new DefaultValueAttribute(m_eventData18));
                base.fTypeDescriptor.properties["Data19"].attributes.replace(new DefaultValueAttribute(m_eventData19));
                base.fTypeDescriptor.properties["Data20"].attributes.replace(new DefaultValueAttribute(m_eventData20));
                // --
                base.fTypeDescriptor.properties["Comment"].attributes.replace(new DefaultValueAttribute(m_comments));

                // --

                base.fTypeDescriptor.properties["Data1"].attributes.replace(new BrowsableAttribute(m_eventHeader1 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data2"].attributes.replace(new BrowsableAttribute(m_eventHeader2 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data3"].attributes.replace(new BrowsableAttribute(m_eventHeader3 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data4"].attributes.replace(new BrowsableAttribute(m_eventHeader4 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data5"].attributes.replace(new BrowsableAttribute(m_eventHeader5 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data6"].attributes.replace(new BrowsableAttribute(m_eventHeader6 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data7"].attributes.replace(new BrowsableAttribute(m_eventHeader7 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data8"].attributes.replace(new BrowsableAttribute(m_eventHeader8 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data9"].attributes.replace(new BrowsableAttribute(m_eventHeader9 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data10"].attributes.replace(new BrowsableAttribute(m_eventHeader10 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data11"].attributes.replace(new BrowsableAttribute(m_eventHeader11 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data12"].attributes.replace(new BrowsableAttribute(m_eventHeader12 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data13"].attributes.replace(new BrowsableAttribute(m_eventHeader13 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data14"].attributes.replace(new BrowsableAttribute(m_eventHeader14 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data15"].attributes.replace(new BrowsableAttribute(m_eventHeader15 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data16"].attributes.replace(new BrowsableAttribute(m_eventHeader16 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data17"].attributes.replace(new BrowsableAttribute(m_eventHeader17 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data18"].attributes.replace(new BrowsableAttribute(m_eventHeader18 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data19"].attributes.replace(new BrowsableAttribute(m_eventHeader19 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data20"].attributes.replace(new BrowsableAttribute(m_eventHeader20 == string.Empty ? false : true));
                
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
