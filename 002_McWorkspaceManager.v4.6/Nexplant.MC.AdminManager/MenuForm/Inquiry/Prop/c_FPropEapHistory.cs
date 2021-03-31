/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropEapHistory.cs
--  Creator         : hsshim
--  Create Date     : 2013.01.28
--  Description     : FAMate Admin Manager Eap History Property Source Object Class 
--  History         : Created by hsshim at 2013.01.28
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
    public class FPropEapHistory : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryEvent = "[02] Event";
        private const string CategoryNeedAction = "[03] Need Action";
        private const string CategoryState = "[04] State";
        private const string CategoryPackage = "[05] Package";
        private const string CategoryModel = "[06] Model";
        private const string CategoryComponent = "[07] Component";
        private const string CategoryData = "[08] Data Field";
        private const string CategoryComment = "[09] Comments";

        // --

        private bool m_disposed = false;
        string m_tranTime = string.Empty;
        string m_eventId = string.Empty;
        string m_eap = string.Empty;
        string m_server = string.Empty;
        string m_step = string.Empty;
        string m_upDown = string.Empty;
        string m_status = string.Empty;
        string m_operationStatus = string.Empty;
        string m_tranUser = string.Empty;
        string m_needAction = string.Empty;
        string m_nextNeedAction = string.Empty;
        string m_setPackage = string.Empty;
        string m_setPackageVer = string.Empty;
        string m_releasePackage = string.Empty;
        string m_releasePackageVer = string.Empty;
        string m_applyPackage = string.Empty;
        string m_applyPackageVer = string.Empty;
        string m_setModel = string.Empty;
        string m_setModelVer = string.Empty;
        string m_releaseModel = string.Empty;
        string m_releaseModelVer = string.Empty;
        string m_applyModel = string.Empty;
        string m_applyModelVer = string.Empty;
        string m_setUsedComponent = string.Empty;
        string m_setComponent = string.Empty;
        string m_setComponentVer = string.Empty;
        string m_releaseUsedCom = string.Empty;
        string m_releaseCom = string.Empty;
        string m_releaseComVer = string.Empty;
        string m_applyUsedComponent = string.Empty;
        string m_applyComponent = string.Empty;
        string m_applyComponentVer = string.Empty;
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

        public FPropEapHistory(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            DataRow dr
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            init(dr);   
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropEapHistory(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid
            )
            : this(fAdmCore, fPropGrid, null)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropEapHistory(
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
        public string Eap
        {
            get
            {
                try
                {
                    return m_eap;
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
        public string Server
        {
            get
            {
                try
                {
                    return m_server;
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
        public string TranUser
        {
            get
            {
                try
                {
                    return m_tranUser;
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

        #region NeedAction

        [Category(CategoryNeedAction)]
        public string NeedAction
        {
            get
            {
                try
                {
                    return m_needAction;
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

        [Category(CategoryNeedAction)]
        public string NextNeedAction
        {
            get
            {
                try
                {
                    return m_nextNeedAction;
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

        [Category(CategoryState)]
        public string Step
        {
            get
            {
                try
                {
                    return m_step;
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
        public string Status
        {
            get
            {
                try
                {
                    return m_status;
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
        public string OperationStatus
        {
            get
            {
                try
                {
                    return m_operationStatus;
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

        #region Package Field

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryPackage)]
        public string SetPackage
        {
            get
            {
                try
                {
                    return m_setPackage;
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

        [Category(CategoryPackage)]
        public string ReleasePackage
        {
            get
            {
                try
                {
                    return m_releasePackage;
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

        [Category(CategoryPackage)]
        public string ApplyPackage
        {
            get
            {
                try
                {
                    return m_applyPackage;
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

        #region Model Field

        [Category(CategoryModel)]
        public string SetModel
        {
            get
            {
                try
                {
                    return m_setModel;
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

        [Category(CategoryModel)]
        public string ReleaseModel
        {
            get
            {
                try
                {
                    return m_releaseModel;
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

        [Category(CategoryModel)]
        public string ApplyModel
        {
            get
            {
                try
                {
                    return m_applyModel;
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

        #region Component Field

        [Category(CategoryComponent)]
        public string SetComponent
        {
            get
            {
                try
                {
                    return m_setComponent;
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

        [Category(CategoryComponent)]
        public string ReleaseComponent
        {
            get
            {
                try
                {
                    return m_releaseCom;
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

        [Category(CategoryComponent)]
        public string ApplyComponent
        {
            get
            {
                try
                {
                    return m_applyComponent;
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
                    m_eap               = dr["EAP"].ToString();
                    m_eventId           = dr["EVENT_ID"].ToString();
                    m_server            = dr["SERVER"].ToString();
                    m_step              = dr["STEP"].ToString();
                    m_upDown            = dr["UP_DOWN"].ToString();
                    m_status            = dr["STATUS"].ToString();
                    m_operationStatus   = dr["OPERATION_STATUS"].ToString();
                    m_needAction        = dr["NEED_ACTION"].ToString();
                    m_nextNeedAction    = dr["NEXT_NEED_ACTION"].ToString();
                    m_tranUser          = dr["TRAN_USER_ID"].ToString();
                    m_setPackage        = dr["SET_PACKAGE"].ToString();
                    m_setPackageVer     = dr["SET_PKG_VER"].ToString();
                    m_releasePackage    = dr["REL_PACKAGE"].ToString();
                    m_releasePackageVer = dr["REL_PKG_VER"].ToString();
                    m_applyPackage      = dr["APL_PACKAGE"].ToString();
                    m_applyPackageVer   = dr["APL_PKG_VER"].ToString();
                    m_setModel          = dr["SET_MODEL"].ToString();
                    m_setModelVer       = dr["SET_MDL_VER"].ToString();
                    m_releaseModel      = dr["REL_MODEL"].ToString();
                    m_releaseModelVer   = dr["REL_MDL_VER"].ToString();
                    m_applyModel        = dr["APL_MODEL"].ToString();
                    m_applyModelVer     = dr["APL_MDL_VER"].ToString();
                    m_setUsedComponent  = dr["SET_USED_COM"].ToString();
                    m_setComponent      = dr["SET_COMPONENT"].ToString();
                    m_setComponentVer   = dr["SET_COM_VER"].ToString();
                    m_releaseUsedCom    = dr["REL_USED_COM"].ToString();
                    m_releaseCom        = dr["REL_COMPONENT"].ToString();
                    m_releaseComVer     = dr["REL_COM_VER"].ToString();
                    m_applyUsedComponent= dr["APL_USED_COM"].ToString();
                    m_applyComponent    = dr["APL_COMPONENT"].ToString();
                    m_applyComponentVer = dr["APL_COM_VER"].ToString();
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
                base.fTypeDescriptor.properties["Eap"].attributes.replace(new DisplayNameAttribute("EAP"));
                base.fTypeDescriptor.properties["EventId"].attributes.replace(new DisplayNameAttribute("Event"));
                base.fTypeDescriptor.properties["Server"].attributes.replace(new DisplayNameAttribute("Server"));
                base.fTypeDescriptor.properties["Step"].attributes.replace(new DisplayNameAttribute("Step"));
                base.fTypeDescriptor.properties["UpDown"].attributes.replace(new DisplayNameAttribute("Up/Down"));
                base.fTypeDescriptor.properties["Status"].attributes.replace(new DisplayNameAttribute("Status"));
                base.fTypeDescriptor.properties["OperationStatus"].attributes.replace(new DisplayNameAttribute("Operation Status"));
                base.fTypeDescriptor.properties["NeedAction"].attributes.replace(new DisplayNameAttribute("Need Action"));
                base.fTypeDescriptor.properties["NextNeedAction"].attributes.replace(new DisplayNameAttribute("Next Need Action"));
                base.fTypeDescriptor.properties["TranUser"].attributes.replace(new DisplayNameAttribute("User ID"));
                base.fTypeDescriptor.properties["SetPackage"].attributes.replace(new DisplayNameAttribute("Setup"));
                base.fTypeDescriptor.properties["ReleasePackage"].attributes.replace(new DisplayNameAttribute("Released"));
                base.fTypeDescriptor.properties["ApplyPackage"].attributes.replace(new DisplayNameAttribute("Applied"));
                base.fTypeDescriptor.properties["SetModel"].attributes.replace(new DisplayNameAttribute("Setup"));
                base.fTypeDescriptor.properties["ReleaseModel"].attributes.replace(new DisplayNameAttribute("Released"));
                base.fTypeDescriptor.properties["ApplyModel"].attributes.replace(new DisplayNameAttribute("Applied"));
                base.fTypeDescriptor.properties["SetComponent"].attributes.replace(new DisplayNameAttribute("Setup"));
                base.fTypeDescriptor.properties["ReleaseComponent"].attributes.replace(new DisplayNameAttribute("Released"));
                base.fTypeDescriptor.properties["ApplyComponent"].attributes.replace(new DisplayNameAttribute("Applied"));
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

                if (!String.IsNullOrWhiteSpace(m_setPackage))
                {
                    m_setPackage = m_setPackage + " [ver. " + m_setPackageVer + "]";
                }
                else
                {
                    m_setPackage = string.Empty;
                }

                // --

                if (!String.IsNullOrWhiteSpace(m_setModel))
                {
                    m_setModel = m_setModel + " [ver. " + m_setModelVer + "]";
                }
                else
                {
                    m_setModel = string.Empty;
                }

                // --

                if (!String.IsNullOrWhiteSpace(m_releasePackage))
                {
                    m_releasePackage = m_releasePackage + " [ver. " + m_releasePackageVer + "]";
                }
                else
                {
                    m_releasePackage = string.Empty;
                }

                // --

                if (!String.IsNullOrWhiteSpace(m_applyPackage))
                {
                    m_applyPackage = m_applyPackage + " [ver. " + m_applyPackageVer + "]";
                }
                else
                {
                    m_applyPackage = string.Empty;
                }

                // --

                if (!String.IsNullOrWhiteSpace(m_releaseModel))
                {
                    m_releaseModel = m_releaseModel + " [ver. " + m_releaseModelVer + "]";
                }
                else
                {
                    m_releaseModel = string.Empty;
                }

                // --

                if (!String.IsNullOrWhiteSpace(m_applyModel))
                {
                    m_applyModel = m_applyModel + " [ver. " + m_applyModelVer + "]";
                }
                else
                {
                    m_applyModel = string.Empty;
                }

                // --

                if (m_setUsedComponent == FYesNo.Yes.ToString())
                {
                    if (!String.IsNullOrWhiteSpace(m_setComponent))
                    {
                        m_setComponent = "(" + m_setUsedComponent + ") " + m_setComponent + " [Ver. " + m_setComponentVer + "]";
                    }
                    else
                    {
                        m_setComponent = "(" + m_setUsedComponent + ")";
                    }
                }

                // --

                if (m_releaseUsedCom == FYesNo.Yes.ToString())
                {
                    if (!String.IsNullOrWhiteSpace(m_releaseCom))
                    {
                        m_releaseCom = "(" + m_releaseUsedCom + ") " + m_releaseCom + " [Ver. " + m_releaseComVer + "]";
                    }
                    else
                    {
                        m_releaseCom = "(" + m_releaseUsedCom + ")";
                    }
                }

                // --

                if (m_applyUsedComponent == FYesNo.Yes.ToString())
                {
                    if (!String.IsNullOrWhiteSpace(m_applyComponent))
                    {
                        m_applyComponent = "(" + m_applyUsedComponent + ") " + m_applyComponent + " [Ver. " + m_applyComponentVer + "]";
                    }
                    else
                    {
                        m_applyComponent = "(" + m_applyUsedComponent + ")";
                    }
                }

                // --

				base.fTypeDescriptor.properties["Time"].attributes.replace(new DefaultValueAttribute(m_tranTime));
                base.fTypeDescriptor.properties["Eap"].attributes.replace(new DefaultValueAttribute(m_eap));
                base.fTypeDescriptor.properties["EventId"].attributes.replace(new DefaultValueAttribute(m_eventId));
                base.fTypeDescriptor.properties["Server"].attributes.replace(new DefaultValueAttribute(m_server));
                base.fTypeDescriptor.properties["Step"].attributes.replace(new DefaultValueAttribute(m_step));
                base.fTypeDescriptor.properties["UpDown"].attributes.replace(new DefaultValueAttribute(m_upDown));
                base.fTypeDescriptor.properties["Status"].attributes.replace(new DefaultValueAttribute(m_status));
                base.fTypeDescriptor.properties["OperationStatus"].attributes.replace(new DefaultValueAttribute(m_operationStatus));
                base.fTypeDescriptor.properties["NeedAction"].attributes.replace(new DefaultValueAttribute(m_needAction));
                base.fTypeDescriptor.properties["NextNeedAction"].attributes.replace(new DefaultValueAttribute(m_nextNeedAction));
                base.fTypeDescriptor.properties["TranUser"].attributes.replace(new DefaultValueAttribute(m_tranUser));
                base.fTypeDescriptor.properties["SetPackage"].attributes.replace(new DefaultValueAttribute(m_setPackage));
                base.fTypeDescriptor.properties["ReleasePackage"].attributes.replace(new DefaultValueAttribute(m_releasePackage));
                base.fTypeDescriptor.properties["ApplyPackage"].attributes.replace(new DefaultValueAttribute(m_applyPackage));
                base.fTypeDescriptor.properties["SetModel"].attributes.replace(new DefaultValueAttribute(m_setModel));
                base.fTypeDescriptor.properties["ReleaseModel"].attributes.replace(new DefaultValueAttribute(m_releaseModel));
                base.fTypeDescriptor.properties["ApplyModel"].attributes.replace(new DefaultValueAttribute(m_applyModel));
                base.fTypeDescriptor.properties["SetComponent"].attributes.replace(new DefaultValueAttribute(m_setComponent));
                base.fTypeDescriptor.properties["ReleaseComponent"].attributes.replace(new DefaultValueAttribute(m_releaseCom));
                base.fTypeDescriptor.properties["ApplyComponent"].attributes.replace(new DefaultValueAttribute(m_applyComponent));
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
