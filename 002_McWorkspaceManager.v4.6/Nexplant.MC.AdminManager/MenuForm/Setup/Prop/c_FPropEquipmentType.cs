/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropEquipmentType.cs
--  Creator         : mjkim
--  Create Date     : 2013.12.03
--  Description     : FAMate DCS Manager Equipmnet Type Property Source Object Class 
--  History         : Created by mjkim at 2013.12.03
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
    public class FPropEquipmentType : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryMaker = "[02] Maker";
        private const string CategoryEquipmentAttribute = "[03] Equipment Attribute";
        private const string CategorySystemUsed = "[04] System Used";
        private const string CategoryAutoRecipe = "[05] Auto Recipe";
        private const string CategoryRMSGeneral = "[06] RMS General";
        private const string CategoryFWRecipeDownloadRule = "[07] FW Recipe Download Rule";
        private const string CategoryWORecipeDownloadRule = "[08] WO Recipe Download Rule";
        
        // --

        private bool m_disposed = false;
        // --
        private bool m_tranEnabled = false;
        // --        
        private string m_eqpType = string.Empty;
        private string m_description = string.Empty;
        private string m_maker = string.Empty;
        // --
        private FProcessMode m_processMode = FProcessMode.SingleLot;
        private FQtyUnit m_qtyUnit = FQtyUnit.Panel;
        private FYesNo m_rmsUsed = FYesNo.Yes;
        private FYesNo m_pmsUsed = FYesNo.Yes;
        // --
        private FYesNo m_remoteStartUsed = FYesNo.Yes;
        private FYesNo m_remotePauseUsed = FYesNo.Yes;
        // --
        private FLotCancelRule m_lotCancelRule = FLotCancelRule.Single;
        // --
        private FAutoRecipeMode m_autoRecipeMode = FAutoRecipeMode.Spec;
        private FRecipeCreationMode m_recipeCreationMode = FRecipeCreationMode.NotUsed;
        private string m_generateFormat = string.Empty;
        // --
        private FRecipeType m_rcpType = FRecipeType.Parameter;
        private FStandardRecipeRule m_stdRcpRule = FStandardRecipeRule.Master;
        private FYesNo m_rcpDownloadUsed = FYesNo.Yes;
        private FYesNo m_rcpSelectUsed = FYesNo.Yes;
        private FYesNo m_rcpValidationUsed = FYesNo.Yes;
        // --
        private FRecipeDownloadRule m_fwRcpDownloadRule1 = FRecipeDownloadRule.NotUsed;
        private FRecipeDownloadRule m_fwRcpDownloadRule2 = FRecipeDownloadRule.NotUsed;
        private FRecipeDownloadRule m_fwRcpDownloadRule3 = FRecipeDownloadRule.NotUsed;
        private FRecipeDownloadRule m_fwRcpDownloadRule4 = FRecipeDownloadRule.NotUsed;
        private FRecipeDownloadRule m_fwRcpDownloadRule5 = FRecipeDownloadRule.NotUsed;
        // --
        private FRecipeDownloadRule m_woRcpDownloadRule1 = FRecipeDownloadRule.NotUsed;
        private FRecipeDownloadRule m_woRcpDownloadRule2 = FRecipeDownloadRule.NotUsed;
        private FRecipeDownloadRule m_woRcpDownloadRule3 = FRecipeDownloadRule.NotUsed;
        private FRecipeDownloadRule m_woRcpDownloadRule4 = FRecipeDownloadRule.NotUsed;
        private FRecipeDownloadRule m_woRcpDownloadRule5 = FRecipeDownloadRule.NotUsed;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropEquipmentType(
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

        public FPropEquipmentType(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            bool readOnly
            )
            : this(fAdmCore, fPropGrid, null, readOnly)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropEquipmentType(
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
        public string Type
        {
            get
            {
                try
                {
                    return m_eqpType;
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
                    m_eqpType = value;
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

        #region Maker

        [Category(CategoryMaker)]
        [Editor(typeof(FPropAttrEquipmentTypeMakerUITypeEditor), typeof(UITypeEditor))]
        public string Maker
        {
            get
            {
                try
                {
                    return m_maker;
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

            internal set
            {
                try
                {
                    m_maker = value;
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

        #region EquipmentAttribute

        [Category(CategoryEquipmentAttribute)]
        public FProcessMode ProcessMode
        {
            get
            {
                try
                {
                    return m_processMode;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FProcessMode.SingleLot;
            }

            set
            {
                try
                {
                    m_processMode = value;
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

        [Category(CategoryEquipmentAttribute)]
        public FQtyUnit QtyUnit
        {
            get
            {
                try
                {
                    return m_qtyUnit;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FQtyUnit.Panel;
            }

            set
            {
                try
                {
                    m_qtyUnit = value;
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

        [Category(CategoryEquipmentAttribute)]
        public FYesNo RemoteStartUsed
        {
            get
            {
                try
                {
                    return m_remoteStartUsed;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FYesNo.Yes;
            }

            set
            {
                try
                {
                    m_remoteStartUsed = value;
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

        [Category(CategoryEquipmentAttribute)]
        public FYesNo RemotePauseUsed
        {
            get
            {
                try
                {
                    return m_remotePauseUsed;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FYesNo.Yes;
            }

            set
            {
                try
                {
                    m_remotePauseUsed = value;
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

        [Category(CategoryEquipmentAttribute)]
        public FLotCancelRule LotCancelRule
        {
            get
            {
                try
                {
                    return m_lotCancelRule;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FLotCancelRule.Single;
            }

            set
            {
                try
                {
                    m_lotCancelRule = value;
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

        #region SystemUsed

        [Category(CategorySystemUsed)]
        public FYesNo RMSUsed
        {
            get
            {
                try
                {
                    return m_rmsUsed;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FYesNo.Yes;
            }

            set
            {
                try
                {
                    m_rmsUsed = value;
                    setChangedRMSUsed();
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

        [Category(CategorySystemUsed)]
        public FYesNo PMSUsed
        {
            get
            {
                try
                {
                    return m_pmsUsed;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FYesNo.Yes;
            }

            set
            {
                try
                {
                    m_pmsUsed = value;
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

        #region AutoRecipe

        [Category(CategoryAutoRecipe)]
        public FAutoRecipeMode AutoRecipeMode
        {
            get
            {
                try
                {
                    return m_autoRecipeMode;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FAutoRecipeMode.Spec;
            }

            set
            {
                try
                {
                    m_autoRecipeMode = value;
                    setChangedAutoRecipeMode();
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

        [Category(CategoryAutoRecipe)]
        public FRecipeCreationMode RecipeCreationMode
        {
            get
            {
                try
                {
                    return m_recipeCreationMode;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FRecipeCreationMode.NotUsed;
            }

            set
            {
                try
                {
                    m_recipeCreationMode = value;
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

        [Category(CategoryAutoRecipe)]
        public string GenerateFormat
        {
            get
            {
                try
                {
                    return m_generateFormat;
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
                    m_generateFormat = value;
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

        #region RMSGeneral

        [Category(CategoryRMSGeneral)]
        public FRecipeType RecipeType
        {
            get
            {
                try
                {
                    return m_rcpType;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FRecipeType.Parameter;
            }

            set
            {
                try
                {
                    m_rcpType = value;
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

        [Category(CategoryRMSGeneral)]
        public FStandardRecipeRule StandardRecipeRule
        {
            get
            {
                try
                {
                    return m_stdRcpRule;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FStandardRecipeRule.Master;
            }

            set
            {
                try
                {
                    m_stdRcpRule = value;
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

        [Category(CategoryRMSGeneral)]
        public FYesNo RecipeDownloadUsed
        {
            get
            {
                try
                {
                    return m_rcpDownloadUsed;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FYesNo.Yes;
            }

            set
            {
                try
                {
                    m_rcpDownloadUsed = value;
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

        [Category(CategoryRMSGeneral)]
        public FYesNo RecipeSelectUsed
        {
            get
            {
                try
                {
                    return m_rcpSelectUsed;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FYesNo.Yes;
            }

            set
            {
                try
                {
                    m_rcpSelectUsed = value;
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

        [Category(CategoryRMSGeneral)]
        public FYesNo RecipeValidationUsed
        {
            get
            {
                try
                {
                    return m_rcpValidationUsed;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FYesNo.Yes;
            }

            set
            {
                try
                {
                    m_rcpValidationUsed = value;
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

        #region FWRecipeDownloadRule

        [Category(CategoryFWRecipeDownloadRule)]
        public FRecipeDownloadRule FWRecipeDownloadRule1
        {
            get
            {
                try
                {
                    return m_fwRcpDownloadRule1;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FRecipeDownloadRule.NotUsed;
            }

            set
            {
                try
                {
                    m_fwRcpDownloadRule1 = value;
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

        [Category(CategoryFWRecipeDownloadRule)]
        public FRecipeDownloadRule FWRecipeDownloadRule2
        {
            get
            {
                try
                {
                    return m_fwRcpDownloadRule2;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FRecipeDownloadRule.NotUsed;
            }

            set
            {
                try
                {
                    m_fwRcpDownloadRule2 = value;
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

        [Category(CategoryFWRecipeDownloadRule)]
        public FRecipeDownloadRule FWRecipeDownloadRule3
        {
            get
            {
                try
                {
                    return m_fwRcpDownloadRule3;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FRecipeDownloadRule.NotUsed;
            }

            set
            {
                try
                {
                    m_fwRcpDownloadRule3 = value;
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

        [Category(CategoryFWRecipeDownloadRule)]
        public FRecipeDownloadRule FWRecipeDownloadRule4
        {
            get
            {
                try
                {
                    return m_fwRcpDownloadRule4;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FRecipeDownloadRule.NotUsed;
            }

            set
            {
                try
                {
                    m_fwRcpDownloadRule4 = value;
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

        [Category(CategoryFWRecipeDownloadRule)]
        public FRecipeDownloadRule FWRecipeDownloadRule5
        {
            get
            {
                try
                {
                    return m_fwRcpDownloadRule5;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FRecipeDownloadRule.NotUsed;
            }

            set
            {
                try
                {
                    m_fwRcpDownloadRule5 = value;
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

        #region WORecipeDownloadRule

        [Category(CategoryWORecipeDownloadRule)]
        public FRecipeDownloadRule WORecipeDownloadRule1
        {
            get
            {
                try
                {
                    return m_woRcpDownloadRule1;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FRecipeDownloadRule.NotUsed;
            }

            set
            {
                try
                {
                    m_woRcpDownloadRule1 = value;
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

        [Category(CategoryWORecipeDownloadRule)]
        public FRecipeDownloadRule WORecipeDownloadRule2
        {
            get
            {
                try
                {
                    return m_woRcpDownloadRule2;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FRecipeDownloadRule.NotUsed;
            }

            set
            {
                try
                {
                    m_woRcpDownloadRule2 = value;
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

        [Category(CategoryWORecipeDownloadRule)]
        public FRecipeDownloadRule WORecipeDownloadRule3
        {
            get
            {
                try
                {
                    return m_woRcpDownloadRule3;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FRecipeDownloadRule.NotUsed;
            }

            set
            {
                try
                {
                    m_woRcpDownloadRule3 = value;
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

        [Category(CategoryWORecipeDownloadRule)]
        public FRecipeDownloadRule WORecipeDownloadRule4
        {
            get
            {
                try
                {
                    return m_woRcpDownloadRule4;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FRecipeDownloadRule.NotUsed;
            }

            set
            {
                try
                {
                    m_woRcpDownloadRule4 = value;
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

        [Category(CategoryWORecipeDownloadRule)]
        public FRecipeDownloadRule WORecipeDownloadRule5
        {
            get
            {
                try
                {
                    return m_woRcpDownloadRule5;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FRecipeDownloadRule.NotUsed;
            }

            set
            {
                try
                {
                    m_woRcpDownloadRule5 = value;
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
                    m_eqpType = dt.Rows[0][0].ToString();
                    m_description = dt.Rows[0][1].ToString();
                    m_maker = dt.Rows[0][2].ToString();
                    // --
                    m_processMode = (FProcessMode)Enum.Parse(typeof(FProcessMode), dt.Rows[0][3].ToString());
                    m_qtyUnit = (FQtyUnit)Enum.Parse(typeof(FQtyUnit), dt.Rows[0][4].ToString());
                    m_remoteStartUsed = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][5].ToString());
                    m_remotePauseUsed = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][6].ToString());
                    m_lotCancelRule = (FLotCancelRule)Enum.Parse(typeof(FLotCancelRule), dt.Rows[0][27].ToString());
                    // --
                    m_rmsUsed = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][7].ToString());
                    m_pmsUsed = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][8].ToString());
                    // --
                    m_autoRecipeMode = (FAutoRecipeMode)Enum.Parse(typeof(FAutoRecipeMode), dt.Rows[0][9].ToString());
                    m_recipeCreationMode = (FRecipeCreationMode)Enum.Parse(typeof(FRecipeCreationMode), dt.Rows[0][10].ToString());
                    m_generateFormat = dt.Rows[0][11].ToString();
                    // --
                    m_rcpType = (FRecipeType)Enum.Parse(typeof(FRecipeType), dt.Rows[0][12].ToString());
                    m_stdRcpRule = (FStandardRecipeRule)Enum.Parse(typeof(FStandardRecipeRule), dt.Rows[0][13].ToString());
                    m_rcpDownloadUsed = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][14].ToString());
                    m_rcpSelectUsed = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][15].ToString());
                    m_rcpValidationUsed = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][16].ToString());
                    // --
                    m_fwRcpDownloadRule1 = (FRecipeDownloadRule)Enum.Parse(typeof(FRecipeDownloadRule), dt.Rows[0][17].ToString());
                    m_fwRcpDownloadRule2 = (FRecipeDownloadRule)Enum.Parse(typeof(FRecipeDownloadRule), dt.Rows[0][18].ToString());
                    m_fwRcpDownloadRule3 = (FRecipeDownloadRule)Enum.Parse(typeof(FRecipeDownloadRule), dt.Rows[0][19].ToString());
                    m_fwRcpDownloadRule4 = (FRecipeDownloadRule)Enum.Parse(typeof(FRecipeDownloadRule), dt.Rows[0][20].ToString());
                    m_fwRcpDownloadRule5 = (FRecipeDownloadRule)Enum.Parse(typeof(FRecipeDownloadRule), dt.Rows[0][21].ToString());
                    // --
                    m_woRcpDownloadRule1 = (FRecipeDownloadRule)Enum.Parse(typeof(FRecipeDownloadRule), dt.Rows[0][22].ToString());
                    m_woRcpDownloadRule2 = (FRecipeDownloadRule)Enum.Parse(typeof(FRecipeDownloadRule), dt.Rows[0][23].ToString());
                    m_woRcpDownloadRule3 = (FRecipeDownloadRule)Enum.Parse(typeof(FRecipeDownloadRule), dt.Rows[0][24].ToString());
                    m_woRcpDownloadRule4 = (FRecipeDownloadRule)Enum.Parse(typeof(FRecipeDownloadRule), dt.Rows[0][25].ToString());
                    m_woRcpDownloadRule5 = (FRecipeDownloadRule)Enum.Parse(typeof(FRecipeDownloadRule), dt.Rows[0][26].ToString());
                }

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Equipment Type"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                base.fTypeDescriptor.properties["Maker"].attributes.replace(new DisplayNameAttribute("Maker"));
                // --
                base.fTypeDescriptor.properties["ProcessMode"].attributes.replace(new DisplayNameAttribute("Process Mode"));
                base.fTypeDescriptor.properties["QtyUnit"].attributes.replace(new DisplayNameAttribute("Qty Unit"));
                base.fTypeDescriptor.properties["RemoteStartUsed"].attributes.replace(new DisplayNameAttribute("Remote Start Used"));
                base.fTypeDescriptor.properties["RemotePauseUsed"].attributes.replace(new DisplayNameAttribute("Remote Pause Used"));
                base.fTypeDescriptor.properties["LotCancelRule"].attributes.replace(new DisplayNameAttribute("Lot Cancel Rule"));
                // --
                base.fTypeDescriptor.properties["RMSUsed"].attributes.replace(new DisplayNameAttribute("RMS Used"));
                base.fTypeDescriptor.properties["PMSUsed"].attributes.replace(new DisplayNameAttribute("PMS Used"));
                // --
                base.fTypeDescriptor.properties["AutoRecipeMode"].attributes.replace(new DisplayNameAttribute("Auto Recipe Mode"));
                base.fTypeDescriptor.properties["RecipeCreationMode"].attributes.replace(new DisplayNameAttribute("Recipe Creation Mode"));
                base.fTypeDescriptor.properties["GenerateFormat"].attributes.replace(new DisplayNameAttribute("Generate Format"));
                // --
                base.fTypeDescriptor.properties["RecipeType"].attributes.replace(new DisplayNameAttribute("Recipe Type"));
                base.fTypeDescriptor.properties["StandardRecipeRule"].attributes.replace(new DisplayNameAttribute("Standard Recipe Rule"));
                // --
                base.fTypeDescriptor.properties["RecipeDownloadUsed"].attributes.replace(new DisplayNameAttribute("Recipe Download Used"));
                base.fTypeDescriptor.properties["RecipeSelectUsed"].attributes.replace(new DisplayNameAttribute("Recipe Select Used"));
                base.fTypeDescriptor.properties["RecipeValidationUsed"].attributes.replace(new DisplayNameAttribute("Recipe Validation Used"));
                // --
                base.fTypeDescriptor.properties["FWRecipeDownloadRule1"].attributes.replace(new DisplayNameAttribute("FW Recipe Download Rule 1"));
                base.fTypeDescriptor.properties["FWRecipeDownloadRule2"].attributes.replace(new DisplayNameAttribute("FW Recipe Download Rule 2"));
                base.fTypeDescriptor.properties["FWRecipeDownloadRule3"].attributes.replace(new DisplayNameAttribute("FW Recipe Download Rule 3"));
                base.fTypeDescriptor.properties["FWRecipeDownloadRule4"].attributes.replace(new DisplayNameAttribute("FW Recipe Download Rule 4"));
                base.fTypeDescriptor.properties["FWRecipeDownloadRule5"].attributes.replace(new DisplayNameAttribute("FW Recipe Download Rule 5"));
                // --
                base.fTypeDescriptor.properties["WORecipeDownloadRule1"].attributes.replace(new DisplayNameAttribute("WO Recipe Download Rule 1"));
                base.fTypeDescriptor.properties["WORecipeDownloadRule2"].attributes.replace(new DisplayNameAttribute("WO Recipe Download Rule 2"));
                base.fTypeDescriptor.properties["WORecipeDownloadRule3"].attributes.replace(new DisplayNameAttribute("WO Recipe Download Rule 3"));
                base.fTypeDescriptor.properties["WORecipeDownloadRule4"].attributes.replace(new DisplayNameAttribute("WO Recipe Download Rule 4"));
                base.fTypeDescriptor.properties["WORecipeDownloadRule5"].attributes.replace(new DisplayNameAttribute("WO Recipe Download Rule 5"));

                // --

                // ***
                // 2014.09.10 by spike.lee
                // 데이터 키 정의
                // ***
                base.fTypeDescriptor.properties["Type"].attributes.replace(new ParenthesizePropertyNameAttribute(true));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_eqpType));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_description));
                base.fTypeDescriptor.properties["Maker"].attributes.replace(new DefaultValueAttribute(m_maker));
                // --
                base.fTypeDescriptor.properties["ProcessMode"].attributes.replace(new DefaultValueAttribute(m_processMode));
                base.fTypeDescriptor.properties["QtyUnit"].attributes.replace(new DefaultValueAttribute(m_qtyUnit));
                base.fTypeDescriptor.properties["RemoteStartUsed"].attributes.replace(new DefaultValueAttribute(m_remoteStartUsed));
                base.fTypeDescriptor.properties["RemotePauseUsed"].attributes.replace(new DefaultValueAttribute(m_remotePauseUsed));
                base.fTypeDescriptor.properties["LotCancelRule"].attributes.replace(new DefaultValueAttribute(m_lotCancelRule));
                // --
                base.fTypeDescriptor.properties["RMSUsed"].attributes.replace(new DefaultValueAttribute(m_rmsUsed));
                base.fTypeDescriptor.properties["PMSUsed"].attributes.replace(new DefaultValueAttribute(m_pmsUsed));
                // --
                base.fTypeDescriptor.properties["AutoRecipeMode"].attributes.replace(new DefaultValueAttribute(m_autoRecipeMode));
                base.fTypeDescriptor.properties["RecipeCreationMode"].attributes.replace(new DefaultValueAttribute(m_recipeCreationMode));
                base.fTypeDescriptor.properties["GenerateFormat"].attributes.replace(new DefaultValueAttribute(m_generateFormat));
                // --
                base.fTypeDescriptor.properties["RecipeType"].attributes.replace(new DefaultValueAttribute(m_rcpType));
                base.fTypeDescriptor.properties["StandardRecipeRule"].attributes.replace(new DefaultValueAttribute(m_stdRcpRule));
                // --
                base.fTypeDescriptor.properties["RecipeDownloadUsed"].attributes.replace(new DefaultValueAttribute(m_rcpDownloadUsed));
                base.fTypeDescriptor.properties["RecipeSelectUsed"].attributes.replace(new DefaultValueAttribute(m_rcpSelectUsed));
                base.fTypeDescriptor.properties["RecipeValidationUsed"].attributes.replace(new DefaultValueAttribute(m_rcpValidationUsed));
                // --
                base.fTypeDescriptor.properties["FWRecipeDownloadRule1"].attributes.replace(new DefaultValueAttribute(m_fwRcpDownloadRule1));
                base.fTypeDescriptor.properties["FWRecipeDownloadRule2"].attributes.replace(new DefaultValueAttribute(m_fwRcpDownloadRule2));
                base.fTypeDescriptor.properties["FWRecipeDownloadRule3"].attributes.replace(new DefaultValueAttribute(m_fwRcpDownloadRule3));
                base.fTypeDescriptor.properties["FWRecipeDownloadRule4"].attributes.replace(new DefaultValueAttribute(m_fwRcpDownloadRule4));
                base.fTypeDescriptor.properties["FWRecipeDownloadRule5"].attributes.replace(new DefaultValueAttribute(m_fwRcpDownloadRule5));
                // --
                base.fTypeDescriptor.properties["WORecipeDownloadRule1"].attributes.replace(new DefaultValueAttribute(m_woRcpDownloadRule1));
                base.fTypeDescriptor.properties["WORecipeDownloadRule2"].attributes.replace(new DefaultValueAttribute(m_woRcpDownloadRule2));
                base.fTypeDescriptor.properties["WORecipeDownloadRule3"].attributes.replace(new DefaultValueAttribute(m_woRcpDownloadRule3));
                base.fTypeDescriptor.properties["WORecipeDownloadRule4"].attributes.replace(new DefaultValueAttribute(m_woRcpDownloadRule4));
                base.fTypeDescriptor.properties["WORecipeDownloadRule5"].attributes.replace(new DefaultValueAttribute(m_woRcpDownloadRule5));

                // --

                setChangedRMSUsed();

                // --

                if (!m_tranEnabled)
                {
                    base.fTypeDescriptor.properties["Type"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Description"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Maker"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["ProcessMode"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["QtyUnit"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["RemoteStartUsed"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["RemotePauseUsed"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["LotCancelRule"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["RMSUsed"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["PMSUsed"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["AutoRecipeMode"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["RecipeCreationMode"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["GenerateFormat"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["RecipeType"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["StandardRecipeRule"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["RecipeDownloadUsed"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["RecipeSelectUsed"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["RecipeValidationUsed"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["FWRecipeDownloadRule1"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["FWRecipeDownloadRule2"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["FWRecipeDownloadRule3"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["FWRecipeDownloadRule4"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["FWRecipeDownloadRule5"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["WORecipeDownloadRule1"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["WORecipeDownloadRule2"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["WORecipeDownloadRule3"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["WORecipeDownloadRule4"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["WORecipeDownloadRule5"].attributes.replace(new ReadOnlyAttribute(true));

                    // --

                    base.fTypeDescriptor.properties["Maker"].attributes.replace(new EditorAttribute(string.Empty, typeof(UITypeEditor)));
                }

                // --

                base.fTypeDescriptor.properties["ProcessMode"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["QtyUnit"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["RemoteStartUsed"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["RemotePauseUsed"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["LotCancelRule"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["RMSUsed"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["PMSUsed"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["AutoRecipeMode"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["RecipeCreationMode"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["GenerateFormat"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["RecipeType"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["StandardRecipeRule"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["RecipeDownloadUsed"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["RecipeSelectUsed"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["RecipeValidationUsed"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["FWRecipeDownloadRule1"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["FWRecipeDownloadRule2"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["FWRecipeDownloadRule3"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["FWRecipeDownloadRule4"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["FWRecipeDownloadRule5"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["WORecipeDownloadRule1"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["WORecipeDownloadRule2"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["WORecipeDownloadRule3"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["WORecipeDownloadRule4"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["WORecipeDownloadRule5"].attributes.replace(new BrowsableAttribute(false));
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

        private void setChangedRMSUsed(
            )
        {
            try
            {
                base.fTypeDescriptor.properties["AutoRecipeMode"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["RecipeCreationMode"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["GenerateFormat"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["RecipeType"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["StandardRecipeRule"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["RecipeDownloadUsed"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["RecipeSelectUsed"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["RecipeValidationUsed"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["FWRecipeDownloadRule1"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["FWRecipeDownloadRule2"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["FWRecipeDownloadRule3"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["FWRecipeDownloadRule4"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["FWRecipeDownloadRule5"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["WORecipeDownloadRule1"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["WORecipeDownloadRule2"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["WORecipeDownloadRule3"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["WORecipeDownloadRule4"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["WORecipeDownloadRule5"].attributes.replace(new BrowsableAttribute(false));

                // --
                
                if (m_rmsUsed == FYesNo.Yes)
                {
                    base.fTypeDescriptor.properties["AutoRecipeMode"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["RecipeType"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["StandardRecipeRule"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["RecipeDownloadUsed"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["RecipeSelectUsed"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["RecipeValidationUsed"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["FWRecipeDownloadRule1"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["FWRecipeDownloadRule2"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["FWRecipeDownloadRule3"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["FWRecipeDownloadRule4"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["FWRecipeDownloadRule5"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["WORecipeDownloadRule1"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["WORecipeDownloadRule2"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["WORecipeDownloadRule3"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["WORecipeDownloadRule4"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["WORecipeDownloadRule5"].attributes.replace(new BrowsableAttribute(true));
                }
                else
                {
                    // --

                    m_rcpDownloadUsed = FYesNo.No;
                    m_rcpSelectUsed = FYesNo.No;
                    m_rcpValidationUsed = FYesNo.No;
                    // --
                    m_autoRecipeMode = FAutoRecipeMode.Spec;
                    // --
                    m_rcpType = FRecipeType.Parameter;
                    m_stdRcpRule = FStandardRecipeRule.Master;
                    m_fwRcpDownloadRule1 = FRecipeDownloadRule.NotUsed;
                    m_fwRcpDownloadRule2 = FRecipeDownloadRule.NotUsed;
                    m_fwRcpDownloadRule3 = FRecipeDownloadRule.NotUsed;
                    m_fwRcpDownloadRule4 = FRecipeDownloadRule.NotUsed;
                    m_fwRcpDownloadRule5 = FRecipeDownloadRule.NotUsed;
                    // --
                    m_woRcpDownloadRule1 = FRecipeDownloadRule.NotUsed;
                    m_woRcpDownloadRule2 = FRecipeDownloadRule.NotUsed;
                    m_woRcpDownloadRule3 = FRecipeDownloadRule.NotUsed;
                    m_woRcpDownloadRule4 = FRecipeDownloadRule.NotUsed;
                    m_woRcpDownloadRule5 = FRecipeDownloadRule.NotUsed;
                }

                // --

                setChangedAutoRecipeMode();

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

        //------------------------------------------------------------------------------------------------------------------------

        private void setChangedAutoRecipeMode(
            )
        {
            try
            {
                base.fTypeDescriptor.properties["RecipeCreationMode"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["GenerateFormat"].attributes.replace(new BrowsableAttribute(false));

                // --

                if (m_autoRecipeMode == FAutoRecipeMode.Generate)
                {
                    base.fTypeDescriptor.properties["RecipeCreationMode"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["GenerateFormat"].attributes.replace(new BrowsableAttribute(true));
                }
                else
                {
                    m_recipeCreationMode = FRecipeCreationMode.NotUsed;
                    m_generateFormat = string.Empty;
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
