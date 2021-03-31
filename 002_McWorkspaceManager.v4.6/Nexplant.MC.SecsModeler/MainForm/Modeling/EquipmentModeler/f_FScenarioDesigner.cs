/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FScenarioDesigner.cs
--  Creator         : byjeon
--  Create Date     : 2012.09.20
--  Description     : FAMate SECS Modeler Scenario Designer Form Class 
--  History         : Created by byjeon at 2012.09.20
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaUIs.WPF;
using System.Windows.Forms.Integration;

namespace Nexplant.MC.SecsModeler
{
    public partial class FScenarioDesigner : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private FEventHandler m_fEventHandler = null;
        private FScenario m_fSnr = null;
        private FIObject m_fActiveObject = null;
        private Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl m_fDragDropOldRefFlowCtrl = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FScenarioDesigner(
            )
        {
            InitializeComponent();            
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FScenarioDesigner(
            FSsmCore fSsmCore,
            FScenario fSnr
            )
            : this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;
            m_fSnr = fSnr;
            changeAliasName();
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
                    m_fSsmCore = null;
                    m_fSnr = null;
                    m_fActiveObject = null;
                    m_fDragDropOldRefFlowCtrl = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FScenario fScenario
        {
            get
            {
                try
                {
                    return m_fSnr;
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

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
                base.fUIWizard.changeControlCaption(mnuMenu);
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

        protected override void changeControlFontName(
            )
        {
            try
            {
                base.changeControlFontName();
                base.fUIWizard.changeControlFontName(mnuMenu);
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

        private void designTreeOfScenarioDesigner(
            )
        {
            try
            {
                tvwFlow.ImageList = new ImageList();
                // --
                tvwFlow.ImageList.Images.Add("SecsTrigger", Properties.Resources.SecsTrigger);
                tvwFlow.ImageList.Images.Add("SecsCondition_Expression", Properties.Resources.SecsCondition_Expression);
                tvwFlow.ImageList.Images.Add("SecsCondition_Timeout", Properties.Resources.SecsCondition_Timeout);
                tvwFlow.ImageList.Images.Add("SecsCondition_Connection_Closed", Properties.Resources.SecsCondition_Connection_Closed);
                tvwFlow.ImageList.Images.Add("SecsCondition_Connection_Opened", Properties.Resources.SecsCondition_Connection_Opened);
                tvwFlow.ImageList.Images.Add("SecsCondition_Connection_Connected", Properties.Resources.SecsCondition_Connection_Connected);
                tvwFlow.ImageList.Images.Add("SecsCondition_Connection_Selected", Properties.Resources.SecsCondition_Connection_Selected);
                tvwFlow.ImageList.Images.Add("SecsExpression_Bracket", Properties.Resources.SecsExpression_Bracket);
                tvwFlow.ImageList.Images.Add("SecsExpression_Comparison_Value_EquipmentState", Properties.Resources.SecsExpression_Comparison_Value_EquipmentState);
                tvwFlow.ImageList.Images.Add("SecsExpression_Comparison_Value_Environment", Properties.Resources.SecsExpression_Comparison_Value_Environment);
                tvwFlow.ImageList.Images.Add("SecsExpression_Comparison_Value_SecsItem", Properties.Resources.SecsExpression_Comparison_Value_SecsItem);
                tvwFlow.ImageList.Images.Add("SecsExpression_Comparison_Length_Environment", Properties.Resources.SecsExpression_Comparison_Length_Environment);
                tvwFlow.ImageList.Images.Add("SecsExpression_Comparison_Length_SecsItem", Properties.Resources.SecsExpression_Comparison_Length_SecsItem);
                tvwFlow.ImageList.Images.Add("SecsTransmitter", Properties.Resources.SecsTransmitter);
                tvwFlow.ImageList.Images.Add("SecsTransfer", Properties.Resources.SecsTransfer);
                tvwFlow.ImageList.Images.Add("HostTrigger", Properties.Resources.HostTrigger);
                tvwFlow.ImageList.Images.Add("HostCondition_Expression", Properties.Resources.HostCondition_Expression);
                tvwFlow.ImageList.Images.Add("HostCondition_Timeout", Properties.Resources.HostCondition_Timeout);
                tvwFlow.ImageList.Images.Add("HostCondition_Connection_Closed", Properties.Resources.HostCondition_Connection_Closed);
                tvwFlow.ImageList.Images.Add("HostCondition_Connection_Opened", Properties.Resources.HostCondition_Connection_Opened);
                tvwFlow.ImageList.Images.Add("HostCondition_Connection_Connected", Properties.Resources.HostCondition_Connection_Connected);
                tvwFlow.ImageList.Images.Add("HostCondition_Connection_Selected", Properties.Resources.HostCondition_Connection_Selected);
                tvwFlow.ImageList.Images.Add("HostExpression_Bracket", Properties.Resources.HostExpression_Bracket);
                tvwFlow.ImageList.Images.Add("HostExpression_Comparison_Value_EquipmentState", Properties.Resources.HostExpression_Comparison_Value_EquipmentState);
                tvwFlow.ImageList.Images.Add("HostExpression_Comparison_Value_Environment", Properties.Resources.HostExpression_Comparison_Value_Environment);
                tvwFlow.ImageList.Images.Add("HostExpression_Comparison_Value_HostItem", Properties.Resources.HostExpression_Comparison_Value_HostItem);
                tvwFlow.ImageList.Images.Add("HostExpression_Comparison_Length_Environment", Properties.Resources.HostExpression_Comparison_Length_Environment);
                tvwFlow.ImageList.Images.Add("HostExpression_Comparison_Length_HostItem", Properties.Resources.HostExpression_Comparison_Length_HostItem);
                tvwFlow.ImageList.Images.Add("HostTransmitter", Properties.Resources.HostTransmitter);
                tvwFlow.ImageList.Images.Add("HostTransfer", Properties.Resources.HostTransfer);
                tvwFlow.ImageList.Images.Add("EquipmentStateSetAlterer", Properties.Resources.EquipmentStateSetAlterer);
                tvwFlow.ImageList.Images.Add("EquipmentStateAlterer", Properties.Resources.EquipmentStateAlterer);
                tvwFlow.ImageList.Images.Add("Judgement", Properties.Resources.Judgement);
                tvwFlow.ImageList.Images.Add("JudgementCondition", Properties.Resources.JudgementCondition);
                tvwFlow.ImageList.Images.Add("JudgementExpression_Bracket", Properties.Resources.JudgementExpression_Bracket);
                tvwFlow.ImageList.Images.Add("JudgementExpression_Comparison_Length", Properties.Resources.JudgementExpression_Comparison_Length);
                tvwFlow.ImageList.Images.Add("JudgementExpression_Comparison_Value", Properties.Resources.JudgementExpression_Comparison_Value);
                tvwFlow.ImageList.Images.Add("Mapper", Properties.Resources.Mapper);
                tvwFlow.ImageList.Images.Add("Storage", Properties.Resources.Storage);
                tvwFlow.ImageList.Images.Add("Callback", Properties.Resources.Callback);
                tvwFlow.ImageList.Images.Add("Function", Properties.Resources.Function);
                tvwFlow.ImageList.Images.Add("Branch", Properties.Resources.Branch);
                tvwFlow.ImageList.Images.Add("Comment", Properties.Resources.Comment);
                tvwFlow.ImageList.Images.Add("Pauser", Properties.Resources.Pauser);
                tvwFlow.ImageList.Images.Add("EntryPoint", Properties.Resources.EntryPoint);
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

        private void changeAliasName(
            )
        {
            try
            {
                flcContainer.eapAlias = m_fSnr.fParent.eapAlias;
                flcContainer.eqAlias = m_fSnr.fParent.equipmentAlias;
                flcContainer.hostAlias = m_fSnr.fParent.hostAlias;
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

        private bool haveVisibleTools(
            PopupMenuTool popupTool
            )
        {
            try
            {
                foreach (ToolBase t in popupTool.Tools)
                {
                    if (t.SharedProps.Visible)
                    {
                        return true;
                    }
                }

                // --

                return false;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void controlMenu(
            )
        {
            try
            {
                mnuMenu.beginUpdate();

                // --

                foreach (ToolBase t in mnuMenu.Tools)
                {
                    if (
                        t.Key == FMenuKey.MenuSnrExpand || 
                        t.Key == FMenuKey.MenuSnrCollapse ||
                        t.Key == FMenuKey.MenuSnrRelation
                        )
                    {
                        continue;
                    }
                    else if (
                        t.Key == FMenuKey.MenuSnrRemove ||
                        t.Key == FMenuKey.MenuSnrReplace || 
                        t.Key == FMenuKey.MenuSnrCut ||
                        t.Key == FMenuKey.MenuSnrCopy ||
                        t.Key == FMenuKey.MenuSnrPasteChild ||
                        t.Key == FMenuKey.MenuSnrPasteSibling ||
                        t.Key == FMenuKey.MenuSnrMoveDown ||
                        t.Key == FMenuKey.MenuSnrMoveUp
                        )
                    {
                        t.SharedProps.Enabled = false;
                    }
                    else
                    {
                        t.SharedProps.Visible = false;
                    }
                }

                // --

                if (m_fActiveObject.fObjectType == FObjectType.Scenario)
                {
                    mnuMenu.Tools[FMenuKey.MenuSnrExpand].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuSnrCollapse].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuSnrCut].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuSnrCopy].SharedProps.Enabled = m_fActiveObject.canCopy;
                    mnuMenu.Tools[FMenuKey.MenuSnrPasteSibling].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuSnrPasteChild].SharedProps.Enabled = m_fActiveObject.canPasteChild;
                    mnuMenu.Tools[FMenuKey.MenuSnrRemove].SharedProps.Enabled = false;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSnrAppendSecsTrigger].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSnrAppendSecsTransmitter].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSnrAppendHostTrigger].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSnrAppendHostTransmitter].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSnrAppendEquipmentStateSetAlterer].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSnrAppendJudgement].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSnrAppendMapper].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSnrAppendStorage].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSnrAppendCallback].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSnrAppendBranch].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSnrAppendComment].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSnrAppendPauser].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSnrAppendEntryPoint].SharedProps.Visible = true;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuSnrExpand].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuSnrCollapse].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuSnrCut].SharedProps.Enabled = m_fActiveObject.canCut;
                    mnuMenu.Tools[FMenuKey.MenuSnrCopy].SharedProps.Enabled = m_fActiveObject.canCopy;
                    mnuMenu.Tools[FMenuKey.MenuSnrPasteSibling].SharedProps.Enabled = m_fActiveObject.canPasteSibling;
                    mnuMenu.Tools[FMenuKey.MenuSnrPasteChild].SharedProps.Enabled = m_fActiveObject.canPasteChild;
                    mnuMenu.Tools[FMenuKey.MenuSnrRemove].SharedProps.Enabled = m_fActiveObject.canRemove;   
                    // --
                    if (
                        m_fActiveObject.fObjectType == FObjectType.SecsTrigger ||
                        m_fActiveObject.fObjectType == FObjectType.SecsTransmitter ||
                        m_fActiveObject.fObjectType == FObjectType.HostTrigger ||
                        m_fActiveObject.fObjectType == FObjectType.HostTransmitter ||
                        m_fActiveObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                        m_fActiveObject.fObjectType == FObjectType.Judgement ||
                        m_fActiveObject.fObjectType == FObjectType.Mapper ||
                        m_fActiveObject.fObjectType == FObjectType.Storage ||
                        m_fActiveObject.fObjectType == FObjectType.Callback ||
                        m_fActiveObject.fObjectType == FObjectType.Branch ||
                        m_fActiveObject.fObjectType == FObjectType.Comment ||
                        m_fActiveObject.fObjectType == FObjectType.Pauser ||
                        m_fActiveObject.fObjectType == FObjectType.EntryPoint
                        )
                    {
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeSecsTrigger].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterSecsTrigger].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeSecsTransmitter].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterSecsTransmitter].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeHostTrigger].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterHostTrigger].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeHostTransmitter].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterHostTransmitter].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeEquipmentStateSetAlterer].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterEquipmentStateSetAlterer].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeJudgement].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterJudgement].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeMapper].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterMapper].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeStorage].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterStorage].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeCallback].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterCallback].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeBranch].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterBranch].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeComment].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterComment].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforePauser].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterPauser].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeEntryPoint].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterEntryPoint].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;

                        // --

                        if (m_fActiveObject.fObjectType == FObjectType.SecsTrigger)
                        {
                            mnuMenu.Tools[FMenuKey.MenuSnrAppendSecsCondition].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        }
                        else if (m_fActiveObject.fObjectType == FObjectType.SecsTransmitter)
                        {
                            mnuMenu.Tools[FMenuKey.MenuSnrAppendSecsTransfer].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        }
                        else if (m_fActiveObject.fObjectType == FObjectType.HostTrigger)
                        {
                            mnuMenu.Tools[FMenuKey.MenuSnrAppendHostCondition].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        }
                        else if (m_fActiveObject.fObjectType == FObjectType.HostTransmitter)
                        {
                            mnuMenu.Tools[FMenuKey.MenuSnrAppendHostTransfer].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        }
                        else if (m_fActiveObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                        {
                            mnuMenu.Tools[FMenuKey.MenuSnrAppendEquipmentStateAlterer].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        }
                        else if (m_fActiveObject.fObjectType == FObjectType.Judgement)
                        {
                            mnuMenu.Tools[FMenuKey.MenuSnrAppendJudgementCondition].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        }
                        else if (m_fActiveObject.fObjectType == FObjectType.Callback)
                        {
                            mnuMenu.Tools[FMenuKey.MenuSnrAppendFunction].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        }
                    }
                    else if (m_fActiveObject.fObjectType == FObjectType.SecsCondition)
                    {
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeSecsCondition].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterSecsCondition].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrAppendSecsExpression].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;
                    }
                    else if (m_fActiveObject.fObjectType == FObjectType.SecsExpression)
                    {
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeSecsExpression].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterSecsExpression].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrAppendSecsExpression].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;
                    }
                    else if (m_fActiveObject.fObjectType == FObjectType.SecsTransfer)
                    {
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeSecsTransfer].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterSecsTransfer].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;
                    }
                    else if (m_fActiveObject.fObjectType == FObjectType.HostCondition)
                    {
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeHostCondition].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterHostCondition].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrAppendHostExpression].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;
                    }
                    else if (m_fActiveObject.fObjectType == FObjectType.HostExpression)
                    {
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeHostExpression].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterHostExpression].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrAppendHostExpression].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;
                    }
                    else if (m_fActiveObject.fObjectType == FObjectType.HostTransfer)
                    {
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeHostTransfer].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterHostTransfer].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;
                    }
                    else if (m_fActiveObject.fObjectType == FObjectType.EquipmentStateAlterer)
                    {
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeEquipmentStateAlterer].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterEquipmentStateAlterer].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;
                    }
                    else if (m_fActiveObject.fObjectType == FObjectType.JudgementCondition)
                    {
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeJudgementCondition].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterJudgementCondition].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrAppendJudgementExpression].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;
                    }
                    else if (m_fActiveObject.fObjectType == FObjectType.JudgementExpression)
                    {
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeJudgementExpression].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterJudgementExpression].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrAppendJudgementExpression].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;
                    }
                    else if (m_fActiveObject.fObjectType == FObjectType.Function)
                    {
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertBeforeFunction].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuSnrInsertAfterFunction].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuSnrMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;
                    }     
                }
                
                // --

                mnuMenu.Tools[FMenuKey.MenuSnrInsertBefore].SharedProps.Visible = haveVisibleTools((PopupMenuTool)(mnuMenu.Tools[FMenuKey.MenuSnrInsertBefore]));
                mnuMenu.Tools[FMenuKey.MenuSnrInsertAfter].SharedProps.Visible = haveVisibleTools((PopupMenuTool)(mnuMenu.Tools[FMenuKey.MenuSnrInsertAfter]));

                // --

                // ***
                // 2016.04.26 by spike.lee
                // Replace Menu 제어
                // ***
                mnuMenu.Tools[FMenuKey.MenuSnrReplace].SharedProps.Enabled = true;

                // --

                mnuMenu.endUpdate();
            }
            catch (Exception ex)
            {
                mnuMenu.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadContainerOfFlow(
            )
        {
            FIObject fObject = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fFlowCtrl = null;

            try
            {
                FCommon.refreshFlowContainerOfObject(m_fSnr, flcContainer);
                flcContainer.Tag = m_fSnr;                

                // --

                foreach (FIFlow fFlow in m_fSnr.fChildFlowCollection)
                {
                    fObject = (FIObject)fFlow;

                    if (fFlow.fFlowType == FFlowType.SecsTrigger)
                    {
                        fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FSecsTriggerFlow(fObject.uniqueIdToString));
                    }
                    else if (fFlow.fFlowType == FFlowType.SecsTransmitter)
                    {
                        fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FSecsTransmitterFlow(fObject.uniqueIdToString));
                    }
                    else if (fFlow.fFlowType == FFlowType.HostTrigger)
                    {
                        fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FHostTriggerFlow(fObject.uniqueIdToString));
                    }
                    else if (fFlow.fFlowType == FFlowType.HostTransmitter)
                    {
                        fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FHostTransmitterFlow(fObject.uniqueIdToString));
                    }
                    else if (fFlow.fFlowType == FFlowType.EquipmentStateSetAlterer)
                    {
                        fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FEquipmentStateSetAltererFlow(fObject.uniqueIdToString));
                    }
                    else if (fFlow.fFlowType == FFlowType.Judgement)
                    {
                        fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FJudgementFlow(fObject.uniqueIdToString));
                    }
                    else if (fFlow.fFlowType == FFlowType.Mapper)
                    {
                        fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FMapperFlow(fObject.uniqueIdToString));
                    }
                    else if (fFlow.fFlowType == FFlowType.Storage)
                    {
                        fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FStorageFlow(fObject.uniqueIdToString));
                    }
                    else if (fFlow.fFlowType == FFlowType.Callback)
                    {
                        fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FCallbackFlow(fObject.uniqueIdToString));
                    }
                    else if (fFlow.fFlowType == FFlowType.Branch)
                    {
                        fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FBranchFlow(fObject.uniqueIdToString));
                    }
                    else if (fFlow.fFlowType == FFlowType.Comment)
                    {
                        fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FCommentFlow(fObject.uniqueIdToString));
                    }
                    else if (fFlow.fFlowType == FFlowType.Pauser)
                    {
                        fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FPauserFlow(fObject.uniqueIdToString));
                    }
                    else if (fFlow.fFlowType == FFlowType.EntryPoint)
                    {
                        fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FEntryPointFlow(fObject.uniqueIdToString));
                    }

                    FCommon.refreshFlowCtrlOfObject(fObject, fFlowCtrl, tvwFlow);                    
                    fFlowCtrl.Tag = fObject;
                }                

                // --

                flcContainer.activateFlowContainer();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fObject = null;
                fFlowCtrl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfFlow(            
            )
        {
            UltraTreeNode tNodeFlw = null;
            UltraTreeNode tNode1 = null;
            UltraTreeNode tNode2 = null;

            try
            {
                tvwFlow.beginUpdate();

                // --

                tvwFlow.Nodes.Clear();

                // --

                if (m_fActiveObject.fObjectType == FObjectType.SecsTrigger)
                {
                    tNodeFlw = new UltraTreeNode(m_fActiveObject.uniqueIdToString);
                    tNodeFlw.Tag = m_fActiveObject;
                    FCommon.refreshTreeNodeOfObject(m_fActiveObject, tvwFlow, tNodeFlw);

                    // --

                    foreach (FSecsCondition fScn in ((FSecsTrigger)m_fActiveObject).fChildSecsConditionCollection)
                    {
                        tNode1 = new UltraTreeNode(fScn.uniqueIdToString);
                        tNode1.Tag = fScn;
                        FCommon.refreshTreeNodeOfObject(fScn, tvwFlow, tNode1);

                        // --

                        foreach (FSecsExpression fSep in fScn.fChildSecsExpressionCollection)
                        {
                            tNode2 = new UltraTreeNode(fSep.uniqueIdToString);
                            tNode2.Tag = fSep;
                            FCommon.refreshTreeNodeOfObject(fSep, tvwFlow, tNode2);
                            
                            // --

                            tNode1.Nodes.Add(tNode2);
                        }

                        // --

                        tNode1.Expanded = false;
                        tNodeFlw.Nodes.Add(tNode1);
                    }

                    // --

                    tNodeFlw.Expanded = true;
                    tvwFlow.Nodes.Add(tNodeFlw);
                    tvwFlow.ActiveNode = tNodeFlw;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.SecsTransmitter)
                {
                    tNodeFlw = new UltraTreeNode(m_fActiveObject.uniqueIdToString);
                    tNodeFlw.Tag = m_fActiveObject;
                    FCommon.refreshTreeNodeOfObject(m_fActiveObject, tvwFlow, tNodeFlw);

                    // --

                    foreach (FSecsTransfer fStf in ((FSecsTransmitter)m_fActiveObject).fChildSecsTransferCollection)
                    {
                        tNode1 = new UltraTreeNode(fStf.uniqueIdToString);
                        tNode1.Tag = fStf;
                        FCommon.refreshTreeNodeOfObject(fStf, tvwFlow, tNode1);
                        
                        // --
                        
                        tNodeFlw.Nodes.Add(tNode1);
                    }

                    // --

                    tNodeFlw.Expanded = true;
                    tvwFlow.Nodes.Add(tNodeFlw);
                    tvwFlow.ActiveNode = tNodeFlw;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.HostTrigger)
                {
                    tNodeFlw = new UltraTreeNode(m_fActiveObject.uniqueIdToString);
                    tNodeFlw.Tag = m_fActiveObject;
                    FCommon.refreshTreeNodeOfObject(m_fActiveObject, tvwFlow, tNodeFlw);

                    // --

                    foreach (FHostCondition fHcn in ((FHostTrigger)m_fActiveObject).fChildHostConditionCollection)
                    {
                        tNode1 = new UltraTreeNode(fHcn.uniqueIdToString);
                        tNode1.Tag = fHcn;
                        FCommon.refreshTreeNodeOfObject(fHcn, tvwFlow, tNode1);

                        // --

                        foreach (FHostExpression fHep in fHcn.fChildHostExpressionCollection)
                        {
                            tNode2 = new UltraTreeNode(fHep.uniqueIdToString);
                            tNode2.Tag = fHep;
                            FCommon.refreshTreeNodeOfObject(fHep, tvwFlow, tNode2);

                            // --

                            tNode1.Nodes.Add(tNode2);
                        }

                        // --

                        tNode1.Expanded = false;
                        tNodeFlw.Nodes.Add(tNode1);
                    }

                    // --

                    tNodeFlw.Expanded = true;
                    tvwFlow.Nodes.Add(tNodeFlw);
                    tvwFlow.ActiveNode = tNodeFlw;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.HostTransmitter)
                {
                    tNodeFlw = new UltraTreeNode(m_fActiveObject.uniqueIdToString);
                    tNodeFlw.Tag = m_fActiveObject;
                    FCommon.refreshTreeNodeOfObject(m_fActiveObject, tvwFlow, tNodeFlw);

                    // --

                    foreach (FHostTransfer fHtf in ((FHostTransmitter)m_fActiveObject).fChildHostTransferCollection)
                    {
                        tNode1 = new UltraTreeNode(fHtf.uniqueIdToString);
                        tNode1.Tag = fHtf;
                        FCommon.refreshTreeNodeOfObject(fHtf, tvwFlow, tNode1);

                        // --

                        tNodeFlw.Nodes.Add(tNode1);
                    }

                    // --

                    tNodeFlw.Expanded = true;
                    tvwFlow.Nodes.Add(tNodeFlw);
                    tvwFlow.ActiveNode = tNodeFlw;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    tNodeFlw = new UltraTreeNode(m_fActiveObject.uniqueIdToString);
                    tNodeFlw.Tag = m_fActiveObject;
                    FCommon.refreshTreeNodeOfObject(m_fActiveObject, tvwFlow, tNodeFlw);

                    // --

                    foreach (FEquipmentStateAlterer fEsa in ((FEquipmentStateSetAlterer)m_fActiveObject).fChildEquipmentStateAltererCollection)
                    {
                        tNode1 = new UltraTreeNode(fEsa.uniqueIdToString);
                        tNode1.Tag = fEsa;
                        FCommon.refreshTreeNodeOfObject(fEsa, tvwFlow, tNode1);

                        // --

                        tNodeFlw.Nodes.Add(tNode1);
                    }

                    // --

                    tNodeFlw.Expanded = true;
                    tvwFlow.Nodes.Add(tNodeFlw);
                }
                else if (m_fActiveObject.fObjectType == FObjectType.Callback)
                {
                    tNodeFlw = new UltraTreeNode(m_fActiveObject.uniqueIdToString);
                    tNodeFlw.Tag = m_fActiveObject;
                    FCommon.refreshTreeNodeOfObject(m_fActiveObject, tvwFlow, tNodeFlw);

                    // --

                    foreach (FFunction fFun in ((FCallback)m_fActiveObject).fChildFunctionCollection)
                    {
                        tNode1 = new UltraTreeNode(fFun.uniqueIdToString);
                        tNode1.Tag = fFun;
                        FCommon.refreshTreeNodeOfObject(fFun, tvwFlow, tNode1);

                        // --

                        tNodeFlw.Nodes.Add(tNode1);
                    }

                    // --

                    tNodeFlw.Expanded = true;
                    tvwFlow.Nodes.Add(tNodeFlw);
                }
                else if (m_fActiveObject.fObjectType == FObjectType.Judgement)
                {
                    tNodeFlw = new UltraTreeNode(m_fActiveObject.uniqueIdToString);
                    tNodeFlw.Tag = m_fActiveObject;
                    FCommon.refreshTreeNodeOfObject(m_fActiveObject, tvwFlow, tNodeFlw);

                    // --

                    foreach (FJudgementCondition fJcn in ((FJudgement)m_fActiveObject).fChildJudgementConditionCollection)
                    {
                        tNode1 = new UltraTreeNode(fJcn.uniqueIdToString);
                        tNode1.Tag = fJcn;
                        FCommon.refreshTreeNodeOfObject(fJcn, tvwFlow, tNode1);

                        // --

                        foreach (FJudgementExpression fJep in fJcn.fChildJudgementExpressionCollection)
                        {
                            tNode2 = new UltraTreeNode(fJep.uniqueIdToString);
                            tNode2.Tag = fJep;
                            FCommon.refreshTreeNodeOfObject(fJep, tvwFlow, tNode2);

                            // --

                            tNode1.Nodes.Add(tNode2);
                        }

                        // --

                        tNode1.Expanded = false;
                        tNodeFlw.Nodes.Add(tNode1);
                    }

                    // --

                    tNodeFlw.Expanded = true;
                    tvwFlow.Nodes.Add(tNodeFlw);
                }
                else if (
                    m_fActiveObject.fObjectType == FObjectType.Mapper  ||
                    m_fActiveObject.fObjectType == FObjectType.Storage ||
                    m_fActiveObject.fObjectType == FObjectType.Branch  ||
                    m_fActiveObject.fObjectType == FObjectType.Comment ||
                    m_fActiveObject.fObjectType == FObjectType.Pauser ||
                    m_fActiveObject.fObjectType == FObjectType.EntryPoint
                    )
                {
                    tNodeFlw = new UltraTreeNode(m_fActiveObject.uniqueIdToString);
                    tNodeFlw.Tag = m_fActiveObject;
                    FCommon.refreshTreeNodeOfObject(m_fActiveObject, tvwFlow, tNodeFlw);

                    // --

                    tNodeFlw.Expanded = true;
                    tvwFlow.Nodes.Add(tNodeFlw);
                }

                // --

                tvwFlow.endUpdate();
            }
            catch (Exception ex)
            {
                tvwFlow.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeFlw = null;
                tNode1 = null;
                tNode2 = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfChildFlow(
            UltraTreeNode tNodeParent
            )
        {
            FIObject fParent = null;
            UltraTreeNode tNodeChild = null;

            try
            {
                tvwFlow.beginUpdate();

                // --

                fParent = (FIObject)tNodeParent.Tag;
                // --
                if (fParent.fObjectType == FObjectType.SecsTrigger)
                {
                    foreach (FSecsCondition fScn in ((FSecsTrigger)fParent).fChildSecsConditionCollection)
                    {
                        tNodeChild = new UltraTreeNode(fScn.uniqueIdToString);
                        tNodeChild.Tag = fScn;
                        FCommon.refreshTreeNodeOfObject(fScn, tvwFlow, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsCondition)
                {
                    foreach (FSecsExpression fSep in ((FSecsCondition)fParent).fChildSecsExpressionCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSep.uniqueIdToString);
                        tNodeChild.Tag = fSep;
                        FCommon.refreshTreeNodeOfObject(fSep, tvwFlow, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsExpression)
                {
                    foreach (FSecsExpression fSep in ((FSecsExpression)fParent).fChildSecsExpressionCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSep.uniqueIdToString);
                        tNodeChild.Tag = fSep;
                        FCommon.refreshTreeNodeOfObject(fSep, tvwFlow, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                // --
                else if (fParent.fObjectType == FObjectType.SecsTransmitter)
                {
                    foreach (FSecsTransfer fStf in ((FSecsTransmitter)fParent).fChildSecsTransferCollection)
                    {
                        tNodeChild = new UltraTreeNode(fStf.uniqueIdToString);
                        tNodeChild.Tag = fStf;
                        FCommon.refreshTreeNodeOfObject(fStf, tvwFlow, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                // --
                else if (fParent.fObjectType == FObjectType.HostTrigger)
                {
                    foreach (FHostCondition fHcn in ((FHostTrigger)fParent).fChildHostConditionCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHcn.uniqueIdToString);
                        tNodeChild.Tag = fHcn;
                        FCommon.refreshTreeNodeOfObject(fHcn, tvwFlow, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostCondition)
                {
                    foreach (FHostExpression fHep in ((FHostCondition)fParent).fChildHostExpressionCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHep.uniqueIdToString);
                        tNodeChild.Tag = fHep;
                        FCommon.refreshTreeNodeOfObject(fHep, tvwFlow, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }                
                else if (fParent.fObjectType == FObjectType.HostExpression)
                {
                    foreach (FHostExpression fHep in ((FHostExpression)fParent).fChildHostExpressionCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHep.uniqueIdToString);
                        tNodeChild.Tag = fHep;
                        FCommon.refreshTreeNodeOfObject(fHep, tvwFlow, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                // --
                else if (fParent.fObjectType == FObjectType.HostTransmitter)
                {
                    foreach (FHostTransfer fHtf in ((FHostTransmitter)fParent).fChildHostTransferCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHtf.uniqueIdToString);
                        tNodeChild.Tag = fHtf;
                        FCommon.refreshTreeNodeOfObject(fHtf, tvwFlow, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                // --
                else if (fParent.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    foreach (FEquipmentStateAlterer fEat in ((FEquipmentStateSetAlterer)fParent).fChildEquipmentStateAltererCollection)
                    {
                        tNodeChild = new UltraTreeNode(fEat.uniqueIdToString);
                        tNodeChild.Tag = fEat;
                        FCommon.refreshTreeNodeOfObject(fEat, tvwFlow, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                // --
                else if (fParent.fObjectType == FObjectType.Judgement)
                {
                    foreach (FJudgementCondition fJcn in ((FJudgement)fParent).fChildJudgementConditionCollection)
                    {
                        tNodeChild = new UltraTreeNode(fJcn.uniqueIdToString);
                        tNodeChild.Tag = fJcn;
                        FCommon.refreshTreeNodeOfObject(fJcn, tvwFlow, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.JudgementCondition)
                {
                    foreach (FJudgementExpression fJep in ((FJudgementCondition)fParent).fChildJudgementExpressionCollection)
                    {
                        tNodeChild = new UltraTreeNode(fJep.uniqueIdToString);
                        tNodeChild.Tag = fJep;
                        FCommon.refreshTreeNodeOfObject(fJep, tvwFlow, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.JudgementExpression)
                {
                    foreach (FJudgementExpression fJep in ((FJudgementExpression)fParent).fChildJudgementExpressionCollection)
                    {
                        tNodeChild = new UltraTreeNode(fJep.uniqueIdToString);
                        tNodeChild.Tag = fJep;
                        FCommon.refreshTreeNodeOfObject(fJep, tvwFlow, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                // --
                else if (fParent.fObjectType == FObjectType.Callback)
                {
                    foreach (FFunction fFun in ((FCallback)fParent).fChildFunctionCollection)
                    {
                        tNodeChild = new UltraTreeNode(fFun.uniqueIdToString);
                        tNodeChild.Tag = fFun;
                        FCommon.refreshTreeNodeOfObject(fFun, tvwFlow, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }

                // --

                tvwFlow.endUpdate();
            }
            catch (Exception ex)
            {
                tvwFlow.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
                tNodeChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void addContainerOfFlow(
            FIObject fParent, 
            FIObject fNewChild
            )
        {
            FIObject fRefChild = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fNewChildFlowCtrl = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fRefChildFlowCtrl = null;

            try
            {
                if (!fParent.Equals(flcContainer.Tag))
                {
                    return;
                }
                
                fNewChildFlowCtrl = flcContainer.getFlowCtrl(fNewChild.uniqueIdToString);
                if (fNewChildFlowCtrl != null)
                {
                    return;
                }

                // --

                if (fNewChild.fObjectType == FObjectType.SecsTrigger)
                {
                    fRefChild = (FIObject)((FSecsTrigger)fNewChild).fNextSibling;
                    fNewChildFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FSecsTriggerFlow(fNewChild.uniqueIdToString);
                }
                else if (fNewChild.fObjectType == FObjectType.SecsTransmitter)
                {
                    fRefChild = (FIObject)((FSecsTransmitter)fNewChild).fNextSibling;
                    fNewChildFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FSecsTransmitterFlow(fNewChild.uniqueIdToString);
                }
                else if (fNewChild.fObjectType == FObjectType.HostTrigger)
                {
                    fRefChild = (FIObject)((FHostTrigger)fNewChild).fNextSibling;
                    fNewChildFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FHostTriggerFlow(fNewChild.uniqueIdToString);
                }
                else if (fNewChild.fObjectType == FObjectType.HostTransmitter)
                {
                    fRefChild = (FIObject)((FHostTransmitter)fNewChild).fNextSibling;
                    fNewChildFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FHostTransmitterFlow(fNewChild.uniqueIdToString);
                }
                else if (fNewChild.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    fRefChild = (FIObject)((FEquipmentStateSetAlterer)fNewChild).fNextSibling;
                    fNewChildFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FEquipmentStateSetAltererFlow(fNewChild.uniqueIdToString);
                }
                else if (fNewChild.fObjectType == FObjectType.Judgement)
                {
                    fRefChild = (FIObject)((FJudgement)fNewChild).fNextSibling;
                    fNewChildFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FJudgementFlow(fNewChild.uniqueIdToString);
                }
                else if (fNewChild.fObjectType == FObjectType.Mapper)
                {
                    fRefChild = (FIObject)((FMapper)fNewChild).fNextSibling;
                    fNewChildFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FMapperFlow(fNewChild.uniqueIdToString);
                }
                else if (fNewChild.fObjectType == FObjectType.Storage)
                {
                    fRefChild = (FIObject)((FStorage)fNewChild).fNextSibling;
                    fNewChildFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FStorageFlow(fNewChild.uniqueIdToString);
                }
                else if (fNewChild.fObjectType == FObjectType.Callback)
                {
                    fRefChild = (FIObject)((FCallback)fNewChild).fNextSibling;
                    fNewChildFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FCallbackFlow(fNewChild.uniqueIdToString);
                }
                else if (fNewChild.fObjectType == FObjectType.Branch)
                {
                    fRefChild = (FIObject)((FBranch)fNewChild).fNextSibling;
                    fNewChildFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FBranchFlow(fNewChild.uniqueIdToString);
                }
                else if (fNewChild.fObjectType == FObjectType.Comment)
                {
                    fRefChild = (FIObject)((FComment)fNewChild).fNextSibling;
                    fNewChildFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FCommentFlow(fNewChild.uniqueIdToString);
                }
                else if (fNewChild.fObjectType == FObjectType.Pauser)
                {
                    fRefChild = (FIObject)((FComment)fNewChild).fNextSibling;
                    fNewChildFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FPauserFlow(fNewChild.uniqueIdToString);
                }
                else if (fNewChild.fObjectType == FObjectType.EntryPoint)
                {
                    fRefChild = (FIObject)((FEntryPoint)fNewChild).fNextSibling;
                    fNewChildFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FEntryPointFlow(fNewChild.uniqueIdToString);
                }

                // --

                if (fRefChild != null)
                {
                    fRefChildFlowCtrl = flcContainer.getFlowCtrl(fRefChild.uniqueIdToString);
                }
                // --
                if (fRefChildFlowCtrl != null)
                {
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(fNewChildFlowCtrl, fRefChildFlowCtrl);
                }
                else
                {
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(fNewChildFlowCtrl);
                }
                // --
                FCommon.refreshFlowCtrlOfObject(fNewChild, fNewChildFlowCtrl, tvwFlow);
                fNewChildFlowCtrl.Tag = fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fRefChild = null;
                fNewChildFlowCtrl = null;
                fRefChildFlowCtrl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void addTreeOfChildFlow(
            FIObject fParent,
            FIObject fNewChild
            )
        {
            FIObject fRefChild = null;
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeNewChild = null;
            UltraTreeNode tNodeRefChild = null;

            try
            {
                tNodeNewChild = tvwFlow.GetNodeByKey(fNewChild.uniqueIdToString);
                if (tNodeNewChild != null)
                {
                    return;
                }

                // --

                if (fNewChild.fObjectType == FObjectType.SecsCondition)
                {
                    tNodeParent = tvwFlow.GetNodeByKey(fParent.uniqueIdToString);                    
                    if (tNodeParent == null)
                    {
                        return;
                    }
                    fRefChild = ((FSecsCondition)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.SecsExpression)
                {
                    tNodeParent = tvwFlow.GetNodeByKey(fParent.uniqueIdToString);
                    if (
                        tNodeParent == null ||
                        (!tNodeParent.Parent.Expanded && tNodeParent.Nodes.Count == 0)
                        )
                    {
                        if (tNodeParent != null && tNodeParent.Expanded)
                        {
                            tNodeParent.Expanded = false;
                        }
                        return;
                    }
                    fRefChild = ((FSecsExpression)fNewChild).fNextSibling;
                }
                // --
                else if (fNewChild.fObjectType == FObjectType.SecsTransfer)
                {
                    tNodeParent = tvwFlow.GetNodeByKey(fParent.uniqueIdToString);
                    if (tNodeParent == null)
                    {
                        return;
                    }
                    fRefChild = ((FSecsTransfer)fNewChild).fNextSibling;
                }
                // --
                else if (fNewChild.fObjectType == FObjectType.HostCondition)
                {
                    tNodeParent = tvwFlow.GetNodeByKey(fParent.uniqueIdToString);
                    if (tNodeParent == null)
                    {
                        return;
                    }
                    fRefChild = ((FHostCondition)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.HostExpression)
                {
                    tNodeParent = tvwFlow.GetNodeByKey(fParent.uniqueIdToString);
                    if (
                        tNodeParent == null ||
                        (!tNodeParent.Parent.Expanded && tNodeParent.Nodes.Count == 0)
                        )
                    {
                        if (tNodeParent != null && tNodeParent.Expanded)
                        {
                            tNodeParent.Expanded = false;
                        }
                        return;
                    }
                    fRefChild = ((FHostExpression)fNewChild).fNextSibling;
                }
                // --
                else if (fNewChild.fObjectType == FObjectType.HostTransfer)
                {
                    tNodeParent = tvwFlow.GetNodeByKey(fParent.uniqueIdToString);
                    if (tNodeParent == null)
                    {
                        return;
                    }
                    fRefChild = ((FHostTransfer)fNewChild).fNextSibling;
                }
                // --
                else if (fNewChild.fObjectType == FObjectType.EquipmentStateAlterer)
                {
                    tNodeParent = tvwFlow.GetNodeByKey(fParent.uniqueIdToString);
                    if (tNodeParent == null)
                    {
                        return;
                    }
                    fRefChild = ((FEquipmentStateAlterer)fNewChild).fNextSibling;
                }
                // --
                else if (fNewChild.fObjectType == FObjectType.JudgementCondition)
                {
                    tNodeParent = tvwFlow.GetNodeByKey(fParent.uniqueIdToString);
                    if (tNodeParent == null)
                    {
                        return;
                    }
                    fRefChild = ((FJudgementCondition)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.JudgementExpression)
                {
                    tNodeParent = tvwFlow.GetNodeByKey(fParent.uniqueIdToString);
                    if (
                        tNodeParent == null ||
                        (!tNodeParent.Parent.Expanded && tNodeParent.Nodes.Count == 0)
                        )
                    {
                        if (tNodeParent != null && tNodeParent.Expanded)
                        {
                            tNodeParent.Expanded = false;
                        }
                        return;
                    }
                    fRefChild = ((FJudgementExpression)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.Function)
                {
                    tNodeParent = tvwFlow.GetNodeByKey(fParent.uniqueIdToString);
                    if (tNodeParent == null)
                    {
                        return;
                    }
                    fRefChild = ((FFunction)fNewChild).fNextSibling;
                }

                // --

                tvwFlow.beginUpdate();

                // --

                tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwFlow, tNodeNewChild);

                // --

                if (fRefChild != null)
                {
                    tNodeRefChild = tvwFlow.GetNodeByKey(fRefChild.uniqueIdToString);
                }
                // --
                if (tNodeRefChild != null)
                {
                    tNodeParent.Nodes.Insert(tNodeRefChild.Index, tNodeNewChild);
                }
                else
                {
                    tNodeParent.Nodes.Add(tNodeNewChild);
                }

                // --

                loadTreeOfChildFlow(tNodeNewChild);

                // --

                tvwFlow.endUpdate();
            }
            catch (Exception ex)
            {
                tvwFlow.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fRefChild = null;
                tNodeParent = null;
                tNodeNewChild = null;
                tNodeRefChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void moveUpContainerOfFlow(
            FIObject fObject
            )
        {
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fFlowCtrl = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fPrevFlowCtrl = null;

            try
            {
                fFlowCtrl = flcContainer.getFlowCtrl(fObject.uniqueIdToString);
                if (fFlowCtrl == null)
                {
                    return;
                }
                fPrevFlowCtrl = fFlowCtrl.fPreviousSibling;

                // --

                if (fObject.fObjectType == FObjectType.SecsTrigger)
                {
                    if (((FSecsTrigger)fObject).fPreviousSibling == null)
                    {
                        if (fPrevFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsTrigger)fObject).fPreviousSibling.Equals(fPrevFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsTransmitter)
                {
                    if (((FSecsTransmitter)fObject).fPreviousSibling == null)
                    {
                        if (fPrevFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsTransmitter)fObject).fPreviousSibling.Equals(fPrevFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostTrigger)
                {
                    if (((FHostTrigger)fObject).fPreviousSibling == null)
                    {
                        if (fPrevFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostTrigger)fObject).fPreviousSibling.Equals(fPrevFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostTransmitter)
                {
                    if (((FHostTransmitter)fObject).fPreviousSibling == null)
                    {
                        if (fPrevFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostTransmitter)fObject).fPreviousSibling.Equals(fPrevFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    if (((FEquipmentStateSetAlterer)fObject).fPreviousSibling == null)
                    {
                        if (fPrevFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FEquipmentStateSetAlterer)fObject).fPreviousSibling.Equals(fPrevFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.Judgement)
                {
                    if (((FJudgement)fObject).fPreviousSibling == null)
                    {
                        if (fPrevFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FJudgement)fObject).fPreviousSibling.Equals(fPrevFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.Mapper)
                {
                    if (((FMapper)fObject).fPreviousSibling == null)
                    {
                        if (fPrevFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FMapper)fObject).fPreviousSibling.Equals(fPrevFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.Storage)
                {
                    if (((FStorage)fObject).fPreviousSibling == null)
                    {
                        if (fPrevFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FStorage)fObject).fPreviousSibling.Equals(fPrevFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.Callback)
                {
                    if (((FCallback)fObject).fPreviousSibling == null)
                    {
                        if (fPrevFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FCallback)fObject).fPreviousSibling.Equals(fPrevFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.Branch)
                {
                    if (((FBranch)fObject).fPreviousSibling == null)
                    {
                        if (fPrevFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FBranch)fObject).fPreviousSibling.Equals(fPrevFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.Comment)
                {
                    if (((FComment)fObject).fPreviousSibling == null)
                    {
                        if (fPrevFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FComment)fObject).fPreviousSibling.Equals(fPrevFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.Pauser)
                {
                    if (((FPauser)fObject).fPreviousSibling == null)
                    {
                        if (fPrevFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FPauser)fObject).fPreviousSibling.Equals(fPrevFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.EntryPoint)
                {
                    if (((FEntryPoint)fObject).fPreviousSibling == null)
                    {
                        if (fPrevFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FEntryPoint)fObject).fPreviousSibling.Equals(fPrevFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }

                // --

                flcContainer.moveUpFlowCtrl(fFlowCtrl);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fFlowCtrl = null;
                fPrevFlowCtrl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void moveUpTreeOfChildFlow(
            FIObject fObject
            )
        {
            UltraTreeNode tNode = null;
            UltraTreeNode tPrevNode = null;

            try
            {
                tNode = tvwFlow.GetNodeByKey(fObject.uniqueIdToString);
                if (tNode == null)
                {
                    return;
                }
                tPrevNode = tNode.GetSibling(NodePosition.Previous);

                // --

                if (fObject.fObjectType == FObjectType.SecsCondition)
                {
                    if (((FSecsCondition)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsCondition)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsExpression)
                {
                    if (((FSecsExpression)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsExpression)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsTransfer)
                {
                    if (((FSecsTransfer)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsTransfer)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostCondition)
                {
                    if (((FHostCondition)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostCondition)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostExpression)
                {
                    if (((FHostExpression)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostExpression)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostTransfer)
                {
                    if (((FHostTransfer)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostTransfer)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateAlterer)
                {
                    if (((FEquipmentStateAlterer)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FEquipmentStateAlterer)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.JudgementCondition)
                {
                    if (((FJudgementCondition)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FJudgementCondition)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.JudgementExpression)
                {
                    if (((FJudgementExpression)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FJudgementExpression)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.Function)
                {
                    if (((FFunction)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FFunction)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }

                // --

                tvwFlow.beginUpdate();
                // --
                tvwFlow.moveUpNode(tNode);
                FCommon.refreshTreeNodeOfObject(fObject, tvwFlow, tNode);
                FCommon.refreshTreeNodeOfObject((FIObject)tPrevNode.Tag, tvwFlow, tPrevNode);
                // --
                pgdProp.onDynPropGridRefreshRequested();
                // --
                tvwFlow.endUpdate();
            }
            catch (Exception ex)
            {
                tvwFlow.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                tPrevNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void moveDownContainerOfFlow(
            FIObject fObject
            )
        {
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fFlowCtrl = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fNextFlowCtrl = null;

            try
            {
                fFlowCtrl = flcContainer.getFlowCtrl(fObject.uniqueIdToString);
                if (fFlowCtrl == null)
                {
                    return;
                }
                fNextFlowCtrl = fFlowCtrl.fNextSibling;

                // --

                if (fObject.fObjectType == FObjectType.SecsTrigger)
                {
                    if (((FSecsTrigger)fObject).fNextSibling == null)
                    {
                        if (fNextFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsTrigger)fObject).fNextSibling.Equals(fNextFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsTransmitter)
                {
                    if (((FSecsTransmitter)fObject).fNextSibling == null)
                    {
                        if (fNextFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsTransmitter)fObject).fNextSibling.Equals(fNextFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostTrigger)
                {
                    if (((FHostTrigger)fObject).fNextSibling == null)
                    {
                        if (fNextFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostTrigger)fObject).fNextSibling.Equals(fNextFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostTransmitter)
                {
                    if (((FHostTransmitter)fObject).fNextSibling == null)
                    {
                        if (fNextFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostTransmitter)fObject).fNextSibling.Equals(fNextFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    if (((FEquipmentStateSetAlterer)fObject).fNextSibling == null)
                    {
                        if (fNextFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FEquipmentStateSetAlterer)fObject).fNextSibling.Equals(fNextFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.Judgement)
                {
                    if (((FJudgement)fObject).fNextSibling == null)
                    {
                        if (fNextFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FJudgement)fObject).fNextSibling.Equals(fNextFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.Mapper)
                {
                    if (((FMapper)fObject).fNextSibling == null)
                    {
                        if (fNextFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FMapper)fObject).fNextSibling.Equals(fNextFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.Storage)
                {
                    if (((FStorage)fObject).fNextSibling == null)
                    {
                        if (fNextFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FStorage)fObject).fNextSibling.Equals(fNextFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.Callback)
                {
                    if (((FCallback)fObject).fNextSibling == null)
                    {
                        if (fNextFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FCallback)fObject).fNextSibling.Equals(fNextFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.Branch)
                {
                    if (((FBranch)fObject).fNextSibling == null)
                    {
                        if (fNextFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FBranch)fObject).fNextSibling.Equals(fNextFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.Comment)
                {
                    if (((FComment)fObject).fNextSibling == null)
                    {
                        if (fNextFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FComment)fObject).fNextSibling.Equals(fNextFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.Pauser)
                {
                    if (((FPauser)fObject).fNextSibling == null)
                    {
                        if (fNextFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FPauser)fObject).fNextSibling.Equals(fNextFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.EntryPoint)
                {
                    if (((FEntryPoint)fObject).fNextSibling == null)
                    {
                        if (fNextFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FEntryPoint)fObject).fNextSibling.Equals(fNextFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }

                // --

                flcContainer.moveDownFlowCtrl(fFlowCtrl);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fFlowCtrl = null;
                fNextFlowCtrl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void moveDownTreeOfChildFlow(
            FIObject fObject
            )
        {
            UltraTreeNode tNode = null;
            UltraTreeNode tNextNode = null;

            try
            {
                tNode = tvwFlow.GetNodeByKey(fObject.uniqueIdToString);
                if (tNode == null)
                {
                    return;
                }
                tNextNode = tNode.GetSibling(NodePosition.Next);

                // --

                if (fObject.fObjectType == FObjectType.SecsCondition)
                {
                    if (((FSecsCondition)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsCondition)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsExpression)
                {
                    if (((FSecsExpression)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsExpression)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsTransfer)
                {
                    if (((FSecsTransfer)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsTransfer)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostCondition)
                {
                    if (((FHostCondition)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostCondition)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostExpression)
                {
                    if (((FHostExpression)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostExpression)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostTransfer)
                {
                    if (((FHostTransfer)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostTransfer)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateAlterer)
                {
                    if (((FEquipmentStateAlterer)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FEquipmentStateAlterer)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.JudgementCondition)
                {
                    if (((FJudgementCondition)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FJudgementCondition)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.JudgementExpression)
                {
                    if (((FJudgementExpression)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FJudgementExpression)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.Function)
                {
                    if (((FFunction)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FFunction)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }

                // --

                tvwFlow.beginUpdate();
                // --
                tvwFlow.moveDownNode(tNode);
                FCommon.refreshTreeNodeOfObject(fObject, tvwFlow, tNode);
                FCommon.refreshTreeNodeOfObject((FIObject)tNextNode.Tag, tvwFlow, tNextNode);
                // --
                pgdProp.onDynPropGridRefreshRequested();
                // --
                tvwFlow.endUpdate();
            }
            catch (Exception ex)
            {
                tvwFlow.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                tNextNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void moveToContainerOfFlow(
            FIObject fObject,
            FIObject fRefObject
            )
        {
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fFlowCtrl = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fRefFlowCtrl = null;

            try
            {
                fFlowCtrl = flcContainer.getFlowCtrl(fObject.uniqueIdToString);
                fRefFlowCtrl = flcContainer.getFlowCtrl(fRefObject.uniqueIdToString);

                // --

                if (fRefFlowCtrl == null)
                {
                    if (fFlowCtrl != null)
                    {
                        flcContainer.removeFlowCtrl(fFlowCtrl);
                    }
                }
                else
                {
                    if (fFlowCtrl != null)
                    {
                        if (fRefFlowCtrl.fNextSibling == null || !fRefFlowCtrl.fNextSibling.Equals(fFlowCtrl))
                        {
                            flcContainer.removeFlowCtrl(fFlowCtrl);
                            fFlowCtrl = null;
                        }
                    }
                    // --
                    if (fFlowCtrl == null)
                    {
                        if (fObject.fObjectType == FObjectType.SecsTrigger)
                        {
                            fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FSecsTriggerFlow(fObject.uniqueIdToString);
                        }
                        else if (fObject.fObjectType == FObjectType.SecsTransmitter)
                        {
                            fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FSecsTransmitterFlow(fObject.uniqueIdToString);
                        }
                        else if (fObject.fObjectType == FObjectType.HostTrigger)
                        {
                            fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FHostTriggerFlow(fObject.uniqueIdToString);
                        }
                        else if (fObject.fObjectType == FObjectType.HostTransmitter)
                        {
                            fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FHostTransmitterFlow(fObject.uniqueIdToString);
                        }
                        else if (fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                        {
                            fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FEquipmentStateSetAltererFlow(fObject.uniqueIdToString);
                        }
                        else if (fObject.fObjectType == FObjectType.Judgement)
                        {
                            fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FJudgementFlow(fObject.uniqueIdToString);
                        }
                        else if (fObject.fObjectType == FObjectType.Mapper)
                        {
                            fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FMapperFlow(fObject.uniqueIdToString);
                        }
                        else if (fObject.fObjectType == FObjectType.Storage)
                        {
                            fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FStorageFlow(fObject.uniqueIdToString);
                        }
                        else if (fObject.fObjectType == FObjectType.Callback)
                        {
                            fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FCallbackFlow(fObject.uniqueIdToString);
                        }
                        else if (fObject.fObjectType == FObjectType.Branch)
                        {
                            fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FBranchFlow(fObject.uniqueIdToString);
                        }
                        else if (fObject.fObjectType == FObjectType.Comment)
                        {
                            fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FCommentFlow(fObject.uniqueIdToString);
                        }
                        else if (fObject.fObjectType == FObjectType.Pauser)
                        {
                            fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FPauserFlow(fObject.uniqueIdToString);
                        }
                        else if (fObject.fObjectType == FObjectType.EntryPoint)
                        {
                            fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FEntryPointFlow(fObject.uniqueIdToString);
                        }

                        // --

                        FCommon.refreshFlowCtrlOfObject(fObject, fFlowCtrl, tvwFlow);
                        fFlowCtrl.Tag = fObject;
                        // --
                        flcContainer.insertAfterFlowCtrl(fFlowCtrl, fRefFlowCtrl);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fFlowCtrl = null;
                fRefFlowCtrl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void moveToTreeOfChildFlow(
            FIObject fObject,
            FIObject fRefObject
            )
        {
            UltraTreeNode tRefNode = null;
            UltraTreeNode tNode = null;
            UltraTreeNode tParentNode = null;

            try
            {
                tvwFlow.beginUpdate();

                // --                

                tRefNode = tvwFlow.GetNodeByKey(fRefObject.uniqueIdToString);
                tNode = tvwFlow.GetNodeByKey(fObject.uniqueIdToString);

                // --

                if (tRefNode == null)
                {
                    if (tNode != null)
                    {
                        tNode.Remove();
                    }
                }
                else
                {
                    if (tNode != null)
                    {
                        tParentNode = tNode.Parent;

                        // --

                        if (fRefObject.fObjectType == fObject.fObjectType)
                        {
                            if (tRefNode.Parent != tNode.Parent || tRefNode.Index != tNode.Index - 1)
                            {
                                tNode.Remove();
                                tNode = null;
                            }
                        }
                        else
                        {
                            if (tRefNode.Nodes.Count == 0 || tRefNode.Nodes[tRefNode.Nodes.Count - 1] != tNode)
                            {
                                tNode.Remove();
                                tNode = null;
                            }
                        }
                    }
                    // --
                    if (tNode == null)
                    {
                        tNode = new UltraTreeNode(fObject.uniqueIdToString);
                        tNode.Tag = fObject;
                        FCommon.refreshTreeNodeOfObject(fObject, tvwFlow, tNode);

                        // --

                        if (fRefObject.fObjectType == fObject.fObjectType)
                        {
                            tRefNode.Parent.Nodes.Insert(tRefNode.Index + 1, tNode);
                            loadTreeOfChildFlow(tNode);
                        }
                        else
                        {
                            if (tRefNode.Nodes.Count == 0)
                            {
                                loadTreeOfChildFlow(tRefNode);
                                // --
                                if (tRefNode.Nodes.Exists(tNode.Key))
                                {
                                    tNode = tRefNode.Nodes[tNode.Key];
                                    loadTreeOfChildFlow(tNode);
                                }
                                // --
                                tRefNode.Expanded = false;
                            }
                            else
                            {
                                tRefNode.Nodes.Add(tNode);
                                loadTreeOfChildFlow(tNode);
                            }
                        }

                        // --

                        if (
                            fObject.fObjectType == FObjectType.SecsExpression ||
                            fObject.fObjectType == FObjectType.HostExpression ||
                            fObject.fObjectType == FObjectType.JudgementExpression
                            )
                        {
                            if (tParentNode != null && tParentNode.Nodes.Count > 0)
                            {
                                tNode = tParentNode.Nodes[0];
                                FCommon.refreshTreeNodeOfObject((FIObject)tNode.Tag, tvwFlow, tNode);
                            }
                        }
                    }
                }

                // --

                tvwFlow.endUpdate();
            }
            catch (Exception ex)
            {
                tvwFlow.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tRefNode = null;
                tNode = null;
                tParentNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void removeContainerOfFlow(
            FIObject fChild
            )
        {
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fChildFlowCtrl = null;

            try
            {
                fChildFlowCtrl = flcContainer.getFlowCtrl(fChild.uniqueIdToString);
                if (fChildFlowCtrl == null)
                {
                    return;
                }

                // --

                flcContainer.removeFlowCtrl(fChildFlowCtrl);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fChildFlowCtrl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void removeTreeOfChildFlow(
            FIObject fChild
            )
        {
            UltraTreeNode tNodeChild = null;

            try
            {
                tNodeChild = tvwFlow.GetNodeByKey(fChild.uniqueIdToString);
                if (tNodeChild == null)
                {
                    return;
                }

                // --

                tvwFlow.beginUpdate();
                tNodeChild.Remove();
                tvwFlow.endUpdate();
            }
            catch (Exception ex)
            {
                tvwFlow.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuInsertBeforeFlow(
            string menuKey
            )
        {
            FIObject fRefChild = null;
            FIObject fNewChild = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fRefChildFlowCtrl = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fNewChildFlowCtrl = null;

            try
            {
                fRefChildFlowCtrl = flcContainer.fActiveFlowCtrl;
                fRefChild = (FIObject)fRefChildFlowCtrl.Tag;

                // --

                if (menuKey == FMenuKey.MenuSnrInsertBeforeSecsTrigger)
                {
                    fNewChild = (FIObject)m_fSnr.insertBeforeChildFlow(                        
                        new FSecsTrigger(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FSecsTriggerFlow(fNewChild.uniqueIdToString), 
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertBeforeSecsTransmitter)
                {
                    fNewChild = (FIObject)m_fSnr.insertBeforeChildFlow(
                        new FSecsTransmitter(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FSecsTransmitterFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertBeforeHostTrigger)
                {
                    fNewChild = (FIObject)m_fSnr.insertBeforeChildFlow(
                        new FHostTrigger(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FHostTriggerFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertBeforeHostTransmitter)
                {
                    fNewChild = (FIObject)m_fSnr.insertBeforeChildFlow(
                        new FHostTransmitter(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FHostTransmitterFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertBeforeEquipmentStateSetAlterer)
                {
                    fNewChild = (FIObject)m_fSnr.insertBeforeChildFlow(
                        new FEquipmentStateSetAlterer(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FEquipmentStateSetAltererFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertBeforeJudgement)
                {
                    fNewChild = (FIObject)m_fSnr.insertBeforeChildFlow(
                        new FJudgement(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FJudgementFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertBeforeMapper)
                {
                    fNewChild = (FIObject)m_fSnr.insertBeforeChildFlow(
                        new FMapper(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FMapperFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertBeforeStorage)
                {
                    fNewChild = (FIObject)m_fSnr.insertBeforeChildFlow(
                        new FStorage(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FStorageFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertBeforeCallback)
                {
                    fNewChild = (FIObject)m_fSnr.insertBeforeChildFlow(
                        new FCallback(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FCallbackFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertBeforeBranch)
                {
                    fNewChild = (FIObject)m_fSnr.insertBeforeChildFlow(
                        new FBranch(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FBranchFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertBeforeComment)
                {
                    fNewChild = (FIObject)m_fSnr.insertBeforeChildFlow(
                        new FComment(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FCommentFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertBeforePauser)
                {
                    fNewChild = (FIObject)m_fSnr.insertBeforeChildFlow(
                        new FPauser(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FPauserFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertBeforeEntryPoint)
                {
                    fNewChild = (FIObject)m_fSnr.insertBeforeChildFlow(
                        new FEntryPoint(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FEntryPointFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }

                // --

                FCommon.refreshFlowCtrlOfObject(fNewChild, fNewChildFlowCtrl, tvwFlow);
                fNewChildFlowCtrl.Tag = fNewChild;
                flcContainer.activateFlowCtrl(fNewChildFlowCtrl);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fRefChild = null;
                fNewChild = null;
                fRefChildFlowCtrl = null;
                fNewChildFlowCtrl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuInsertAfterFlow(
            string menuKey
            )
        {
            FIObject fRefChild = null;
            FIObject fNewChild = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fRefChildFlowCtrl = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fNewChildFlowCtrl = null;

            try
            {
                fRefChildFlowCtrl = flcContainer.fActiveFlowCtrl;
                fRefChild = (FIObject)fRefChildFlowCtrl.Tag;

                // --

                if (menuKey == FMenuKey.MenuSnrInsertAfterSecsTrigger)
                {
                    fNewChild = (FIObject)m_fSnr.insertAfterChildFlow(
                        new FSecsTrigger(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FSecsTriggerFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertAfterSecsTransmitter)
                {
                    fNewChild = (FIObject)m_fSnr.insertAfterChildFlow(
                        new FSecsTransmitter(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FSecsTransmitterFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertAfterHostTrigger)
                {
                    fNewChild = (FIObject)m_fSnr.insertAfterChildFlow(
                        new FHostTrigger(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FHostTriggerFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertAfterHostTransmitter)
                {
                    fNewChild = (FIObject)m_fSnr.insertAfterChildFlow(
                        new FHostTransmitter(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FHostTransmitterFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertAfterEquipmentStateSetAlterer)
                {
                    fNewChild = (FIObject)m_fSnr.insertAfterChildFlow(
                        new FEquipmentStateSetAlterer(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FEquipmentStateSetAltererFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertAfterJudgement)
                {
                    fNewChild = (FIObject)m_fSnr.insertAfterChildFlow(
                        new FJudgement(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FJudgementFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertAfterMapper)
                {
                    fNewChild = (FIObject)m_fSnr.insertAfterChildFlow(
                        new FMapper(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FMapperFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertAfterStorage)
                {
                    fNewChild = (FIObject)m_fSnr.insertAfterChildFlow(
                        new FStorage(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FStorageFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertAfterCallback)
                {
                    fNewChild = (FIObject)m_fSnr.insertAfterChildFlow(
                        new FCallback(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FCallbackFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertAfterBranch)
                {
                    fNewChild = (FIObject)m_fSnr.insertAfterChildFlow(
                        new FBranch(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FBranchFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertAfterComment)
                {
                    fNewChild = (FIObject)m_fSnr.insertAfterChildFlow(
                        new FComment(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FCommentFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertAfterPauser)
                {
                    fNewChild = (FIObject)m_fSnr.insertAfterChildFlow(
                        new FPauser(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FPauserFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuSnrInsertAfterEntryPoint)
                {
                    fNewChild = (FIObject)m_fSnr.insertAfterChildFlow(
                        new FEntryPoint(m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FEntryPointFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }

                // --

                FCommon.refreshFlowCtrlOfObject(fNewChild, fNewChildFlowCtrl, tvwFlow);
                fNewChildFlowCtrl.Tag = fNewChild;
                flcContainer.activateFlowCtrl(fNewChildFlowCtrl);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fRefChild = null;
                fNewChild = null;
                fRefChildFlowCtrl = null;
                fNewChildFlowCtrl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAppendFlow(
            string menuKey
            )
        {
            FIObject fNewChild = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fNewChildFlowCtrl = null;

            try
            {
                if (menuKey == FMenuKey.MenuSnrAppendSecsTrigger)
                {
                    fNewChild = (FIObject)m_fSnr.appendChildFlow(
                        new FSecsTrigger(m_fSsmCore.fSsmFileInfo.fSecsDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FSecsTriggerFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuSnrAppendSecsTransmitter)
                {
                    fNewChild = (FIObject)m_fSnr.appendChildFlow(
                        new FSecsTransmitter(m_fSsmCore.fSsmFileInfo.fSecsDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FSecsTransmitterFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuSnrAppendHostTrigger)
                {
                    fNewChild = (FIObject)m_fSnr.appendChildFlow(
                        new FHostTrigger(m_fSsmCore.fSsmFileInfo.fSecsDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FHostTriggerFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuSnrAppendHostTransmitter)
                {
                    fNewChild = (FIObject)m_fSnr.appendChildFlow(
                        new FHostTransmitter(m_fSsmCore.fSsmFileInfo.fSecsDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FHostTransmitterFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuSnrAppendEquipmentStateSetAlterer)
                {
                    fNewChild = (FIObject)m_fSnr.appendChildFlow(
                        new FEquipmentStateSetAlterer(m_fSsmCore.fSsmFileInfo.fSecsDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FEquipmentStateSetAltererFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuSnrAppendJudgement)
                {
                    fNewChild = (FIObject)m_fSnr.appendChildFlow(
                        new FJudgement(m_fSsmCore.fSsmFileInfo.fSecsDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FJudgementFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuSnrAppendMapper)
                {
                    fNewChild = (FIObject)m_fSnr.appendChildFlow(
                        new FMapper(m_fSsmCore.fSsmFileInfo.fSecsDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FMapperFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuSnrAppendStorage)
                {
                    fNewChild = (FIObject)m_fSnr.appendChildFlow(
                        new FStorage(m_fSsmCore.fSsmFileInfo.fSecsDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FStorageFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuSnrAppendCallback)
                {
                    fNewChild = (FIObject)m_fSnr.appendChildFlow(
                        new FCallback(m_fSsmCore.fSsmFileInfo.fSecsDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FCallbackFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuSnrAppendBranch)
                {
                    fNewChild = (FIObject)m_fSnr.appendChildFlow(
                        new FBranch(m_fSsmCore.fSsmFileInfo.fSecsDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FBranchFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuSnrAppendComment)
                {
                    fNewChild = (FIObject)m_fSnr.appendChildFlow(
                        new FComment(m_fSsmCore.fSsmFileInfo.fSecsDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FCommentFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuSnrAppendPauser)
                {
                    fNewChild = (FIObject)m_fSnr.appendChildFlow(
                        new FPauser(m_fSsmCore.fSsmFileInfo.fSecsDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FPauserFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuSnrAppendEntryPoint)
                {
                    fNewChild = (FIObject)m_fSnr.appendChildFlow(
                        new FEntryPoint(m_fSsmCore.fSsmFileInfo.fSecsDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FEntryPointFlow(fNewChild.uniqueIdToString));
                }

                // --

                FCommon.refreshFlowCtrlOfObject(fNewChild, fNewChildFlowCtrl, tvwFlow);
                fNewChildFlowCtrl.Tag = fNewChild;
                flcContainer.activateFlowCtrl(fNewChildFlowCtrl);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fNewChild = null;
                fNewChildFlowCtrl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRemoveFlow(
            )
        {
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fChildFlowCtrl = null;
            FIObject fChild = null;
            FScenario fSnr = null;

            try
            {
                if (flcContainer.fActiveFlowCtrl == null)
                {
                    return;
                }

                // --

                fChildFlowCtrl = flcContainer.fActiveFlowCtrl;
                fChild = (FIObject)fChildFlowCtrl.Tag;
                fSnr = (FScenario)flcContainer.Tag;

                // --

                flcContainer.removeFlowCtrl(fChildFlowCtrl);
                fSnr.removeChildFlow((FIFlow)fChild);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fChildFlowCtrl = null;
                fChild = null;
                fSnr = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuInsertBeforeChildFlow(
            string menuKey
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeRefChild = null;
            UltraTreeNode tNodeNewChild = null;
            FIObject fParent = null;
            FIObject fRefChild = null;
            FIObject fNewChild = null;

            try
            {
                tvwFlow.beginUpdate();

                // --

                tNodeRefChild = tvwFlow.ActiveNode;
                tNodeParent = tNodeRefChild.Parent;
                fRefChild = (FIObject)tNodeRefChild.Tag;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.SecsTrigger)
                {
                    fNewChild = ((FSecsTrigger)fParent).insertBeforeChildSecsCondition(
                        new FSecsCondition(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsCondition)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.SecsCondition)
                {
                    fNewChild = ((FSecsCondition)fParent).insertBeforeChildSecsExpression(
                        new FSecsExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsExpression)fRefChild
                        );

                    // --

                    if (((FSecsExpression)fNewChild).fPreviousSibling == null)
                    {
                        FCommon.refreshTreeNodeOfObject(fRefChild, tvwFlow, tNodeRefChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsExpression)
                {
                    fNewChild = ((FSecsExpression)fParent).insertBeforeChildSecsExpression(
                        new FSecsExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsExpression)fRefChild
                        );

                    // --

                    if (((FSecsExpression)fNewChild).fPreviousSibling == null)
                    {
                        FCommon.refreshTreeNodeOfObject(fRefChild, tvwFlow, tNodeRefChild);
                    }
                }
                // --
                else if (fParent.fObjectType == FObjectType.SecsTransmitter)
                {
                    fNewChild = ((FSecsTransmitter)fParent).insertBeforeChildSecsTransfer(
                        new FSecsTransfer(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsTransfer)fRefChild
                        );
                }
                // --
                else if (fParent.fObjectType == FObjectType.HostTrigger)
                {
                    fNewChild = ((FHostTrigger)fParent).insertBeforeChildHostCondition(
                        new FHostCondition(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FHostCondition)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.HostCondition)
                {
                    fNewChild = ((FHostCondition)fParent).insertBeforeChildHostExpression(
                        new FHostExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FHostExpression)fRefChild
                        );

                    // --

                    if (((FHostExpression)fNewChild).fPreviousSibling == null)
                    {
                        FCommon.refreshTreeNodeOfObject(fRefChild, tvwFlow, tNodeRefChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostExpression)
                {
                    fNewChild = ((FHostExpression)fParent).insertBeforeChildHostExpression(
                        new FHostExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FHostExpression)fRefChild
                        );

                    // --

                    if (((FHostExpression)fNewChild).fPreviousSibling == null)
                    {
                        FCommon.refreshTreeNodeOfObject(fRefChild, tvwFlow, tNodeRefChild);
                    }
                }
                // --
                else if (fParent.fObjectType == FObjectType.HostTransmitter)
                {
                    fNewChild = ((FHostTransmitter)fParent).insertBeforeChildHostTransfer(
                        new FHostTransfer(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FHostTransfer)fRefChild
                        );
                }
                // --
                else if (fParent.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    fNewChild = ((FEquipmentStateSetAlterer)fParent).insertBeforeChildEquipmentStateAlterer(
                        new FEquipmentStateAlterer(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FEquipmentStateAlterer)fRefChild
                        );
                }
                // --
                else if (fParent.fObjectType == FObjectType.Judgement)
                {
                    fNewChild = ((FJudgement)fParent).insertBeforeChildJudgementCondition(
                        new FJudgementCondition(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FJudgementCondition)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.JudgementCondition)
                {
                    fNewChild = ((FJudgementCondition)fParent).insertBeforeChildJudgementExpression(
                        new FJudgementExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FJudgementExpression)fRefChild
                        );

                    // --

                    if (((FJudgementExpression)fNewChild).fPreviousSibling == null)
                    {
                        FCommon.refreshTreeNodeOfObject(fRefChild, tvwFlow, tNodeRefChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.JudgementExpression)
                {
                    fNewChild = ((FJudgementExpression)fParent).insertBeforeChildJudgementExpression(
                        new FJudgementExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FJudgementExpression)fRefChild
                        );

                    // --

                    if (((FJudgementExpression)fNewChild).fPreviousSibling == null)
                    {
                        FCommon.refreshTreeNodeOfObject(fRefChild, tvwFlow, tNodeRefChild);
                    }
                }
                // --
                else if (fParent.fObjectType == FObjectType.Callback)
                {
                    fNewChild = ((FCallback)fParent).insertBeforeChildFunction(
                        new FFunction(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FFunction)fRefChild
                        );
                }

                // --

                tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwFlow, tNodeNewChild);
                tNodeParent.Nodes.Insert(tNodeRefChild.Index, tNodeNewChild);
                // --
                tvwFlow.SelectedNodes.Clear();
                tvwFlow.ActiveNode = tNodeNewChild;
                tvwFlow.Focus();

                // --

                tvwFlow.endUpdate();
            }
            catch (Exception ex)
            {
                tvwFlow.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeParent = null;
                tNodeRefChild = null;
                tNodeNewChild = null;
                fParent = null;
                fRefChild = null;
                fNewChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuInsertAfterChildFlow(
            string menuKey
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeRefChild = null;
            UltraTreeNode tNodeNewChild = null;
            FIObject fParent = null;
            FIObject fRefChild = null;
            FIObject fNewChild = null;

            try
            {
                tvwFlow.beginUpdate();

                // --

                tNodeRefChild = tvwFlow.ActiveNode;
                tNodeParent = tNodeRefChild.Parent;
                fRefChild = (FIObject)tNodeRefChild.Tag;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.SecsTrigger)
                {
                    fNewChild = ((FSecsTrigger)fParent).insertAfterChildSecsCondition(
                        new FSecsCondition(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsCondition)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.SecsCondition)
                {
                    fNewChild = ((FSecsCondition)fParent).insertAfterChildSecsExpression(
                        new FSecsExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsExpression)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.SecsExpression)
                {
                    fNewChild = ((FSecsExpression)fParent).insertAfterChildSecsExpression(
                        new FSecsExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsExpression)fRefChild
                        );
                }
                // --
                else if (fParent.fObjectType == FObjectType.SecsTransmitter)
                {
                    fNewChild = ((FSecsTransmitter)fParent).insertAfterChildSecsTransfer(
                        new FSecsTransfer(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsTransfer)fRefChild
                        );
                }
                // --
                else if (fParent.fObjectType == FObjectType.HostTrigger)
                {
                    fNewChild = ((FHostTrigger)fParent).insertAfterChildHostCondition(
                        new FHostCondition(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FHostCondition)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.HostCondition)
                {
                    fNewChild = ((FHostCondition)fParent).insertAfterChildHostExpression(
                        new FHostExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FHostExpression)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.HostExpression)
                {
                    fNewChild = ((FHostExpression)fParent).insertAfterChildHostExpression(
                        new FHostExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FHostExpression)fRefChild
                        );
                }
                // --
                else if (fParent.fObjectType == FObjectType.HostTransmitter)
                {
                    fNewChild = ((FHostTransmitter)fParent).insertAfterChildHostTransfer(
                        new FHostTransfer(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FHostTransfer)fRefChild
                        );
                }
                // --
                else if (fParent.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    fNewChild = ((FEquipmentStateSetAlterer)fParent).insertAfterChildEquipmentStateAlterer(
                        new FEquipmentStateAlterer(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FEquipmentStateAlterer)fRefChild
                        );
                }
                // --
                else if (fParent.fObjectType == FObjectType.Judgement)
                {
                    fNewChild = ((FJudgement)fParent).insertAfterChildJudgementCondition(
                        new FJudgementCondition(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FJudgementCondition)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.JudgementCondition)
                {
                    fNewChild = ((FJudgementCondition)fParent).insertAfterChildJudgementExpression(
                        new FJudgementExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FJudgementExpression)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.JudgementExpression)
                {
                    fNewChild = ((FJudgementExpression)fParent).insertAfterChildJudgementExpression(
                        new FJudgementExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FJudgementExpression)fRefChild
                        );
                }
                // --
                else if (fParent.fObjectType == FObjectType.Callback)
                {
                    fNewChild = ((FCallback)fParent).insertAfterChildFunction(
                        new FFunction(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FFunction)fRefChild
                        );
                }

                // --

                tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwFlow, tNodeNewChild);
                tNodeParent.Nodes.Insert(tNodeRefChild.Index + 1, tNodeNewChild);
                // --
                tvwFlow.SelectedNodes.Clear();
                tvwFlow.ActiveNode = tNodeNewChild;
                tvwFlow.Focus();

                // --

                tvwFlow.endUpdate();
            }
            catch (Exception ex)
            {
                tvwFlow.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeParent = null;
                tNodeRefChild = null;
                tNodeNewChild = null;
                fParent = null;
                fRefChild = null;
                fNewChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAppendChildFlow(
            string menuKey
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeNewChild = null;
            FIObject fParent = null;
            FIObject fNewChild = null;

            try
            {
                tvwFlow.beginUpdate();

                // --

                tNodeParent = tvwFlow.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.SecsTrigger)
                {
                    fNewChild = ((FSecsTrigger)fParent).appendChildSecsCondition(new FSecsCondition(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }
                else if (fParent.fObjectType == FObjectType.SecsCondition)
                {
                    fNewChild = ((FSecsCondition)fParent).appendChildSecsExpression(new FSecsExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }
                else if (fParent.fObjectType == FObjectType.SecsExpression)
                {
                    fNewChild = ((FSecsExpression)fParent).appendChildSecsExpression(new FSecsExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }
                // --
                else if (fParent.fObjectType == FObjectType.SecsTransmitter)
                {
                    fNewChild = ((FSecsTransmitter)fParent).appendChildSecsTransfer(new FSecsTransfer(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }
                // --
                else if (fParent.fObjectType == FObjectType.HostTrigger)
                {
                    fNewChild = ((FHostTrigger)fParent).appendChildHostCondition(new FHostCondition(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }
                else if (fParent.fObjectType == FObjectType.HostCondition)
                {
                    fNewChild = ((FHostCondition)fParent).appendChildHostExpression(new FHostExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }
                else if (fParent.fObjectType == FObjectType.HostExpression)
                {
                    fNewChild = ((FHostExpression)fParent).appendChildHostExpression(new FHostExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }
                // --
                else if (fParent.fObjectType == FObjectType.HostTransmitter)
                {
                    fNewChild = ((FHostTransmitter)fParent).appendChildHostTransfer(new FHostTransfer(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }
                // --
                else if (fParent.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    fNewChild = ((FEquipmentStateSetAlterer)fParent).appendChildEquipmentStateAlterer(new FEquipmentStateAlterer(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }
                // --
                else if (fParent.fObjectType == FObjectType.Judgement)
                {
                    fNewChild = ((FJudgement)fParent).appendChildJudgementCondition(new FJudgementCondition(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }
                else if (fParent.fObjectType == FObjectType.JudgementCondition)
                {
                    fNewChild = ((FJudgementCondition)fParent).appendChildJudgementExpression(new FJudgementExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }
                else if (fParent.fObjectType == FObjectType.JudgementExpression)
                {
                    fNewChild = ((FJudgementExpression)fParent).appendChildJudgementExpression(new FJudgementExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }
                // --
                else if (fParent.fObjectType == FObjectType.Callback)
                {
                    fNewChild = ((FCallback)fParent).appendChildFunction(new FFunction(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }

                // --

                tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwFlow, tNodeNewChild);
                // --
                tNodeParent.Nodes.Add(tNodeNewChild);
                tvwFlow.SelectedNodes.Clear();
                tvwFlow.ActiveNode = tNodeNewChild;
                tvwFlow.Focus();

                // --

                tvwFlow.endUpdate();
            }
            catch (Exception ex)
            {
                tvwFlow.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeParent = null;
                tNodeNewChild = null;
                fParent = null;
                fNewChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRemoveChildFlow(
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeChild = null;
            FIObject fParent = null;
            FIObject[] fChilds = null;
            FIObject fChild = null;
            DialogResult dialogResult;

            try
            {
                tvwFlow.ActiveNode.Selected = true;
                tNodeParent = tvwFlow.ActiveNode.Parent;
                fParent = (FIObject)tNodeParent.Tag;

                // --                

                // ***
                // Remove SECS Object가 1개 이상일 경우 사용자에게 Confirm를 받는다.
                // ***
                if (tvwFlow.SelectedNodes.Count > 1)
                {
                    dialogResult = FMessageBox.showQuestion(
                        FConstants.ApplicationName,
                        m_fSsmCore.fWsmCore.fUIWizard.generateMessage("Q0004", new object[] { "Object" }),
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button2,
                        m_fSsmCore.fWsmCore.fWsmContainer
                        );
                    if (dialogResult == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }

                // --

                // ***
                // SECS Object Remove
                // ***
                if (fParent.fObjectType == FObjectType.SecsTrigger)
                {
                    fChilds = new FSecsCondition[tvwFlow.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwFlow.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FSecsCondition)tvwFlow.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FSecsTrigger)fParent).removeChildSecsCondition((FSecsCondition[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.SecsCondition)
                {
                    fChilds = new FSecsExpression[tvwFlow.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwFlow.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FSecsExpression)tvwFlow.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FSecsCondition)fParent).removeChildSecsExpression((FSecsExpression[])fChilds);
                    
                    // --
                    
                    if (fParent.hasChild)
                    {
                        fChild = ((FSecsCondition)fParent).fChildSecsExpressionCollection[0];
                        tNodeChild = tvwFlow.GetNodeByKey(fChild.uniqueIdToString);
                        if (tNodeChild != null)
                        {
                            FCommon.refreshTreeNodeOfObject(fChild, tvwFlow, tNodeChild);
                        }                        
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsExpression)
                {
                    fChilds = new FSecsExpression[tvwFlow.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwFlow.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FSecsExpression)tvwFlow.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FSecsExpression)fParent).removeChildSecsExpression((FSecsExpression[])fChilds);

                    // --

                    if (fParent.hasChild)
                    {
                        fChild = ((FSecsExpression)fParent).fChildSecsExpressionCollection[0];
                        tNodeChild = tvwFlow.GetNodeByKey(fChild.uniqueIdToString);
                        if (tNodeChild != null)
                        {
                            FCommon.refreshTreeNodeOfObject(fChild, tvwFlow, tNodeChild);
                        }
                    }
                }
                // --
                else if (fParent.fObjectType == FObjectType.SecsTransmitter)
                {
                    fChilds = new FSecsTransfer[tvwFlow.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwFlow.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FSecsTransfer)tvwFlow.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FSecsTransmitter)fParent).removeChildSecsTransfer((FSecsTransfer[])fChilds);
                }
                // --
                else if (fParent.fObjectType == FObjectType.HostTrigger)
                {
                    fChilds = new FHostCondition[tvwFlow.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwFlow.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FHostCondition)tvwFlow.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FHostTrigger)fParent).removeChildHostCondition((FHostCondition[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.HostCondition)
                {
                    fChilds = new FHostExpression[tvwFlow.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwFlow.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FHostExpression)tvwFlow.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FHostCondition)fParent).removeChildHostExpression((FHostExpression[])fChilds);

                    // --

                    if (fParent.hasChild)
                    {
                        fChild = ((FHostCondition)fParent).fChildHostExpressionCollection[0];
                        tNodeChild = tvwFlow.GetNodeByKey(fChild.uniqueIdToString);
                        if (tNodeChild != null)
                        {
                            FCommon.refreshTreeNodeOfObject(fChild, tvwFlow, tNodeChild);
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostExpression)
                {
                    fChilds = new FHostExpression[tvwFlow.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwFlow.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FHostExpression)tvwFlow.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FHostExpression)fParent).removeChildHostExpression((FHostExpression[])fChilds);

                    // --

                    if (fParent.hasChild)
                    {
                        fChild = ((FHostExpression)fParent).fChildHostExpressionCollection[0];
                        tNodeChild = tvwFlow.GetNodeByKey(fChild.uniqueIdToString);
                        if (tNodeChild != null)
                        {
                            FCommon.refreshTreeNodeOfObject(fChild, tvwFlow, tNodeChild);
                        }
                    }
                }
                // --
                else if (fParent.fObjectType == FObjectType.HostTransmitter)
                {
                    fChilds = new FHostTransfer[tvwFlow.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwFlow.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FHostTransfer)tvwFlow.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FHostTransmitter)fParent).removeChildHostTransfer((FHostTransfer[])fChilds);
                }
                // --
                else if (fParent.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    fChilds = new FEquipmentStateAlterer[tvwFlow.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwFlow.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FEquipmentStateAlterer)tvwFlow.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FEquipmentStateSetAlterer)fParent).removeChildEquipmentStateAlterer((FEquipmentStateAlterer[])fChilds);
                }
                // --
                else if (fParent.fObjectType == FObjectType.Judgement)
                {
                    fChilds = new FJudgementCondition[tvwFlow.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwFlow.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FJudgementCondition)tvwFlow.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FJudgement)fParent).removeChildJudgementCondition((FJudgementCondition[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.JudgementCondition)
                {
                    fChilds = new FJudgementExpression[tvwFlow.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwFlow.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FJudgementExpression)tvwFlow.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FJudgementCondition)fParent).removeChildJudgementExpression((FJudgementExpression[])fChilds);

                    // --

                    if (fParent.hasChild)
                    {
                        fChild = ((FJudgementCondition)fParent).fChildJudgementExpressionCollection[0];
                        tNodeChild = tvwFlow.GetNodeByKey(fChild.uniqueIdToString);
                        if (tNodeChild != null)
                        {
                            FCommon.refreshTreeNodeOfObject(fChild, tvwFlow, tNodeChild);
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.JudgementExpression)
                {
                    fChilds = new FJudgementExpression[tvwFlow.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwFlow.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FJudgementExpression)tvwFlow.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FJudgementExpression)fParent).removeChildJudgementExpression((FJudgementExpression[])fChilds);

                    // --

                    if (fParent.hasChild)
                    {
                        fChild = ((FJudgementExpression)fParent).fChildJudgementExpressionCollection[0];
                        tNodeChild = tvwFlow.GetNodeByKey(fChild.uniqueIdToString);
                        if (tNodeChild != null)
                        {
                            FCommon.refreshTreeNodeOfObject(fChild, tvwFlow, tNodeChild);
                        }
                    }
                }
                // --
                else if (fParent.fObjectType == FObjectType.Callback)
                {
                    fChilds = new FFunction[tvwFlow.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwFlow.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FFunction)tvwFlow.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FCallback)fParent).removeChildFunction((FFunction[])fChilds);
                }                
                
                // --

                tvwFlow.beginUpdate();

                // --

                foreach (FIObject f in fChilds)
                {
                    tvwFlow.GetNodeByKey(f.uniqueIdToString).Remove();
                }

                // --

                // ***
                // 모든 자식 노드가 삭제될 경우 Parent Node가 Active되게 처리
                // (그렇지 않을 경우 Root Node가 Active되나 Active Event가 발생하지 않음)
                // ***
                if (tNodeParent.Nodes.Count == 0)
                {
                    tvwFlow.ActiveNode = tNodeParent;
                }

                // --

                tvwFlow.endUpdate();
            }
            catch (Exception ex)
            {
                tvwFlow.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeParent = null;
                tNodeChild = null;
                fParent = null;
                fChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuExpand(
            )
        {
            try
            {
                tvwFlow.beginUpdate();
                // --
                tvwFlow.ActiveNode.ExpandAll();
                // --
                tvwFlow.endUpdate();
            }
            catch (Exception ex)
            {
                tvwFlow.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCollapse(
            )
        {
            try
            {
                tvwFlow.beginUpdate();
                // --
                tvwFlow.ActiveNode.CollapseAll();
                // --
                tvwFlow.endUpdate();
            }
            catch (Exception ex)
            {
                tvwFlow.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuMoveUpFlow(
            )
        {
            UltraTreeNode tNode = null;
            UltraTreeNode tNextNode = null;
            FIObject fObject = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fFlowCtrl = null;  
          
            try
            {
                if (m_fActiveObject.fObjectType == FObjectType.Scenario)
                {
                    return;
                }
                else if (
                    m_fActiveObject.fObjectType == FObjectType.SecsTrigger ||
                    m_fActiveObject.fObjectType == FObjectType.SecsTransmitter ||
                    m_fActiveObject.fObjectType == FObjectType.HostTrigger ||
                    m_fActiveObject.fObjectType == FObjectType.HostTransmitter ||
                    m_fActiveObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                    m_fActiveObject.fObjectType == FObjectType.Judgement ||
                    m_fActiveObject.fObjectType == FObjectType.Mapper ||
                    m_fActiveObject.fObjectType == FObjectType.Storage ||
                    m_fActiveObject.fObjectType == FObjectType.Callback ||
                    m_fActiveObject.fObjectType == FObjectType.Branch ||
                    m_fActiveObject.fObjectType == FObjectType.Comment ||
                    m_fActiveObject.fObjectType == FObjectType.Pauser ||
                    m_fActiveObject.fObjectType == FObjectType.EntryPoint
                    )
                {
                    fFlowCtrl = flcContainer.fActiveFlowCtrl;
                    fObject = (FIObject)fFlowCtrl.Tag;
                }
                else
                {
                    tvwFlow.beginUpdate();

                    // --

                    tNode = tvwFlow.ActiveNode;
                    fObject = (FIObject)tNode.Tag;
                }                

                //--
                
                if (fObject.fObjectType == FObjectType.SecsTrigger)
                {
                    ((FSecsTrigger)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.SecsCondition)
                {
                    ((FSecsCondition)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.SecsExpression)
                {
                    ((FSecsExpression)fObject).moveUp();
                }
                // --
                else if (fObject.fObjectType == FObjectType.SecsTransmitter)
                {
                    ((FSecsTransmitter)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.SecsTransfer)
                {
                    ((FSecsTransfer)fObject).moveUp();
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostTrigger)
                {
                    ((FHostTrigger)fObject).moveUp() ;
                }
                else if (fObject.fObjectType == FObjectType.HostCondition)
                {
                    ((FHostCondition)fObject).moveUp() ;
                }
                else if (fObject.fObjectType == FObjectType.HostExpression)
                {
                    ((FHostExpression)fObject).moveUp();
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostTransmitter)
                {
                    ((FHostTransmitter)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.HostTransfer)
                {
                    ((FHostTransfer)fObject).moveUp();
                }
                // --
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    ((FEquipmentStateSetAlterer)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateAlterer)
                {
                    ((FEquipmentStateAlterer)fObject).moveUp();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Judgement)
                {
                    ((FJudgement)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.JudgementCondition)
                {
                    ((FJudgementCondition)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.JudgementExpression)
                {
                    ((FJudgementExpression)fObject).moveUp();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Mapper)
                {
                    ((FMapper)fObject).moveUp();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Storage)
                {
                    ((FStorage)fObject).moveUp();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Callback)
                {
                    ((FCallback)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.Function)
                {
                    ((FFunction)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.Branch)
                {
                    ((FBranch)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.Comment)
                {
                    ((FComment)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.Pauser)
                {
                    ((FPauser)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.EntryPoint)
                {
                    ((FEntryPoint)fObject).moveUp();
                }
                
                // -- 

                if (
                   m_fActiveObject.fObjectType == FObjectType.SecsTrigger ||
                   m_fActiveObject.fObjectType == FObjectType.SecsTransmitter ||
                   m_fActiveObject.fObjectType == FObjectType.HostTrigger ||
                   m_fActiveObject.fObjectType == FObjectType.HostTransmitter ||
                   m_fActiveObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                   m_fActiveObject.fObjectType == FObjectType.Judgement ||
                   m_fActiveObject.fObjectType == FObjectType.Mapper ||
                   m_fActiveObject.fObjectType == FObjectType.Storage ||
                   m_fActiveObject.fObjectType == FObjectType.Callback ||
                   m_fActiveObject.fObjectType == FObjectType.Branch ||
                   m_fActiveObject.fObjectType == FObjectType.Comment ||
                   m_fActiveObject.fObjectType == FObjectType.Pauser ||
                   m_fActiveObject.fObjectType == FObjectType.EntryPoint
                   )
                {
                    flcContainer.moveUpFlowCtrl(fFlowCtrl);                    
                    flcContainer.activateFlowCtrl(fFlowCtrl);
                }
                else
                {
                    tvwFlow.moveUpNode(tNode);
                    tvwFlow.SelectedNodes.Clear();
                    tvwFlow.ActiveNode = tNode;
                    
                    // --

                    tNextNode = tNode.GetSibling(NodePosition.Next);
                    // --
                    FCommon.refreshTreeNodeOfObject(fObject, tvwFlow, tNode);
                    FCommon.refreshTreeNodeOfObject((FIObject)tNextNode.Tag, tvwFlow, tNextNode);

                    // --

                    tvwFlow.endUpdate();
                }                
            }
            catch (Exception ex)
            {
                tvwFlow.endUpdate();                
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                tNextNode = null;
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuMoveDownFlow(
            )
        {

            UltraTreeNode tNode = null;
            UltraTreeNode tPrevNode = null;
            FIObject fObject = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fFlowCtrl = null;

            try
            {
                if (m_fActiveObject.fObjectType == FObjectType.Scenario)
                {
                    return;
                }
                else if (
                    m_fActiveObject.fObjectType == FObjectType.SecsTrigger ||
                    m_fActiveObject.fObjectType == FObjectType.SecsTransmitter ||
                    m_fActiveObject.fObjectType == FObjectType.HostTrigger ||
                    m_fActiveObject.fObjectType == FObjectType.HostTransmitter ||
                    m_fActiveObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                    m_fActiveObject.fObjectType == FObjectType.Judgement ||
                    m_fActiveObject.fObjectType == FObjectType.Mapper ||
                    m_fActiveObject.fObjectType == FObjectType.Storage ||
                    m_fActiveObject.fObjectType == FObjectType.Callback ||
                    m_fActiveObject.fObjectType == FObjectType.Branch ||
                    m_fActiveObject.fObjectType == FObjectType.Comment ||
                    m_fActiveObject.fObjectType == FObjectType.Pauser ||
                    m_fActiveObject.fObjectType == FObjectType.EntryPoint
                    )
                {
                    fFlowCtrl = flcContainer.fActiveFlowCtrl;
                    fObject = (FIObject)fFlowCtrl.Tag;
                }
                else
                {
                    tvwFlow.beginUpdate();

                    // -- 

                    tNode = tvwFlow.ActiveNode;
                    fObject = (FIObject)tNode.Tag;
                }
                
                //--
                
                if (fObject.fObjectType == FObjectType.SecsTrigger)
                {
                    ((FSecsTrigger)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.SecsCondition)
                {
                    ((FSecsCondition)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.SecsExpression)
                {
                    ((FSecsExpression)fObject).moveDown();
                }
                // --
                else if (fObject.fObjectType == FObjectType.SecsTransmitter)
                {
                    ((FSecsTransmitter)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.SecsTransfer)
                {
                    ((FSecsTransfer)fObject).moveDown();
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostTrigger)
                {
                    ((FHostTrigger)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.HostCondition)
                {
                    ((FHostCondition)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.HostExpression)
                {
                    ((FHostExpression)fObject).moveDown();
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostTransmitter)
                {
                    ((FHostTransmitter)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.HostTransfer)
                {
                    ((FHostTransfer)fObject).moveDown();
                }
                // --
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    ((FEquipmentStateSetAlterer)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateAlterer)
                {
                    ((FEquipmentStateAlterer)fObject).moveDown();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Judgement)
                {
                    ((FJudgement)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.JudgementCondition)
                {
                    ((FJudgementCondition)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.JudgementExpression)
                {
                    ((FJudgementExpression)fObject).moveDown();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Mapper)
                {
                    ((FMapper)fObject).moveDown();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Storage)
                {
                    ((FStorage)fObject).moveDown();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Callback)
                {
                    ((FCallback)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.Function)
                {
                    ((FFunction)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.Branch)
                {
                    ((FBranch)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.Comment)
                {
                    ((FComment)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.Pauser)
                {
                    ((FPauser)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.EntryPoint)
                {
                    ((FEntryPoint)fObject).moveDown();
                }

                // -- 

                if (
                    m_fActiveObject.fObjectType == FObjectType.SecsTrigger ||
                    m_fActiveObject.fObjectType == FObjectType.SecsTransmitter ||
                    m_fActiveObject.fObjectType == FObjectType.HostTrigger ||
                    m_fActiveObject.fObjectType == FObjectType.HostTransmitter ||
                    m_fActiveObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                    m_fActiveObject.fObjectType == FObjectType.Judgement ||
                    m_fActiveObject.fObjectType == FObjectType.Mapper ||
                    m_fActiveObject.fObjectType == FObjectType.Storage ||
                    m_fActiveObject.fObjectType == FObjectType.Callback ||
                    m_fActiveObject.fObjectType == FObjectType.Branch ||
                    m_fActiveObject.fObjectType == FObjectType.Comment ||
                    m_fActiveObject.fObjectType == FObjectType.Pauser ||
                    m_fActiveObject.fObjectType == FObjectType.EntryPoint
                   )
                {
                    flcContainer.moveDownFlowCtrl(fFlowCtrl);
                    flcContainer.activateFlowCtrl(fFlowCtrl);
                }
                else
                {
                    tvwFlow.moveDownNode(tNode);
                    tvwFlow.SelectedNodes.Clear();
                    tvwFlow.ActiveNode = tNode;

                    // --

                    tPrevNode = tNode.GetSibling(NodePosition.Previous);
                    // --                    
                    FCommon.refreshTreeNodeOfObject(fObject, tvwFlow, tNode);
                    FCommon.refreshTreeNodeOfObject((FIObject)tPrevNode.Tag, tvwFlow, tPrevNode);

                    // --

                    tvwFlow.endUpdate();
                }
            }
            catch (Exception ex)
            {
                tvwFlow.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                tPrevNode = null;
                fObject = null;
            }
        }
                
        //------------------------------------------------------------------------------------------------------------------------

        private void refreshScenario(
            FIObject fObject
            )
        {
            try
            {
                if ((FScenario)fObject != (FScenario)flcContainer.Tag)
                {
                    return;
                }

                // --
                
                if (flcContainer.isActive && !pgdProp.Focused)
                {
                    pgdProp.onDynPropGridRefreshRequested();
                }

                // --

                FCommon.refreshFlowContainerOfObject(fObject, flcContainer);

                // --

                controlMenu();
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

        private void refreshFlow(
            FIObject fObject
            )
        {
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fFlowCtrl = null;
            UltraTreeNode tNode = null;

            try
            {
                fFlowCtrl = flcContainer.getFlowCtrl(fObject.uniqueIdToString);
                if (fFlowCtrl == null)
                {
                    return;
                }

                // --

                if (fFlowCtrl.isActive && !pgdProp.Focused)
                {
                    pgdProp.onDynPropGridRefreshRequested();
                }

                // --

                FCommon.refreshFlowCtrlOfObject(fObject, fFlowCtrl, tvwFlow);

                // --

                tNode = tvwFlow.GetNodeByKey(fObject.uniqueIdToString);
                if (tNode != null)
                {
                    tvwFlow.beginUpdate();
                    FCommon.refreshTreeNodeOfObject(fObject, tvwFlow, tNode);
                    tvwFlow.endUpdate();
                }

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fFlowCtrl = null;
                tNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshChildFlow(
            FIObject fObject
            )
        {
            UltraTreeNode tNode = null;

            try
            {
                tNode = tvwFlow.GetNodeByKey(fObject.uniqueIdToString);
                if (tNode == null)
                {
                    return;
                }

                // --

                if (tNode.IsActive && !pgdProp.Focused)
                {
                    pgdProp.onDynPropGridRefreshRequested();
                }

                // --

                tvwFlow.beginUpdate();
                FCommon.refreshTreeNodeOfObject(fObject, tvwFlow, tNode);
                tvwFlow.endUpdate();

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                tvwFlow.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCopy(
            )
        {
            UltraTreeNode tNode = null;
            FIObject fObject = null;

            try
            {
                if (this.m_fActiveObject.fObjectType == FObjectType.Scenario)
                {
                    fObject = m_fActiveObject;
                }
                else
                {
                    tNode = tvwFlow.ActiveNode;
                    fObject = (FIObject)tNode.Tag;
                }

                // --

                if (fObject.fObjectType == FObjectType.Scenario)
                {
                    ((FScenario)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.SecsTrigger)
                {
                    ((FSecsTrigger)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.SecsCondition)
                {
                    ((FSecsCondition)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.SecsExpression)
                {
                    ((FSecsExpression)fObject).copy();
                }
                // --
                else if (fObject.fObjectType == FObjectType.SecsTransmitter)
                {
                    ((FSecsTransmitter)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.SecsTransfer)
                {
                    ((FSecsTransfer)fObject).copy();
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostTrigger)
                {
                    ((FHostTrigger)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.HostCondition)
                {
                    ((FHostCondition)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.HostExpression)
                {
                    ((FHostExpression)fObject).copy();
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostTransmitter)
                {
                    ((FHostTransmitter)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.HostTransfer)
                {
                    ((FHostTransfer)fObject).copy();
                }
                // --
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    ((FEquipmentStateSetAlterer)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateAlterer)
                {
                    ((FEquipmentStateAlterer)fObject).copy();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Judgement)
                {
                    ((FJudgement)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.JudgementCondition)
                {
                    ((FJudgementCondition)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.JudgementExpression)
                {
                    ((FJudgementExpression)fObject).copy();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Mapper)
                {
                    ((FMapper)fObject).copy();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Storage)
                {
                    ((FStorage)fObject).copy();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Callback)
                {
                    ((FCallback)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.Function)
                {
                    ((FFunction)fObject).copy();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Branch)
                {
                    ((FBranch)fObject).copy();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Comment)
                {
                    ((FComment)fObject).copy();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Pauser)
                {
                    ((FPauser)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.EntryPoint)
                {
                    ((FEntryPoint)fObject).copy();
                }

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuReplace(
            )
        {
            FReplaceNameDialog dialog = null;
            string findWhat = string.Empty;

            try
            {
                if (m_fActiveObject.fObjectType == FObjectType.SecsTrigger)
                {
                    findWhat = ((FSecsTrigger)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.SecsCondition)
                {
                    findWhat = ((FSecsCondition)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.SecsExpression)
                {
                    findWhat = ((FSecsExpression)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.SecsTransmitter)
                {
                    findWhat = ((FSecsTransmitter)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.SecsTransfer)
                {
                    findWhat = ((FSecsTransfer)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.HostTrigger)
                {
                    findWhat = ((FHostTrigger)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.HostCondition)
                {
                    findWhat = ((FHostCondition)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.HostExpression)
                {
                    findWhat = ((FHostExpression)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.HostTransmitter)
                {
                    findWhat = ((FHostTransmitter)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.HostTransfer)
                {
                    findWhat = ((FHostTransfer)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    findWhat = ((FEquipmentStateSetAlterer)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.EquipmentStateAlterer)
                {
                    findWhat = ((FEquipmentStateAlterer)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.Judgement)
                {
                    findWhat = ((FJudgement)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.JudgementCondition)
                {
                    findWhat = ((FJudgementCondition)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.JudgementExpression)
                {
                    findWhat = ((FJudgementExpression)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.Mapper)
                {
                    findWhat = ((FMapper)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.Storage)
                {
                    findWhat = ((FStorage)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.Callback)
                {
                    findWhat = ((FCallback)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.Function)
                {
                    findWhat = ((FFunction)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.Branch)
                {
                    findWhat = ((FBranch)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.Pauser)
                {
                    findWhat = ((FPauser)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.Comment)
                {
                    findWhat = ((FComment)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.EntryPoint)
                {
                    findWhat = ((FEntryPoint)m_fActiveObject).name;
                }
                else
                {
                    return;
                }

                // --

                dialog = new FReplaceNameDialog(
                    m_fSsmCore,
                    findWhat
                    );
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                // --

                procMenuReplaceObject(m_fActiveObject, dialog.findWhat, dialog.replaceWith);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (dialog != null)
                {
                    dialog.Dispose();
                    dialog = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuReplaceObject(
            FIObject fObject,
            string findWhat,
            string replaceWith
            )
        {
            try
            {
                if (fObject.fObjectType == FObjectType.SecsTrigger)
                {
                    foreach (FIObject o in ((FSecsTrigger)fObject).fChildSecsConditionCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FSecsTrigger)fObject).name = ((FSecsTrigger)fObject).name.Replace(findWhat, replaceWith);
                    ((FSecsTrigger)fObject).description = ((FSecsTrigger)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.SecsCondition)
                {
                    foreach (FIObject o in ((FSecsCondition)fObject).fChildSecsExpressionCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FSecsCondition)fObject).name = ((FSecsCondition)fObject).name.Replace(findWhat, replaceWith);
                    ((FSecsCondition)fObject).description = ((FSecsCondition)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.SecsExpression)
                {
                    foreach (FIObject o in ((FSecsExpression)fObject).fChildSecsExpressionCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FSecsExpression)fObject).name = ((FSecsExpression)fObject).name.Replace(findWhat, replaceWith);
                    ((FSecsExpression)fObject).description = ((FSecsExpression)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.SecsTransmitter)
                {
                    foreach (FIObject o in ((FSecsTransmitter)fObject).fChildSecsTransferCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FSecsTransmitter)fObject).name = ((FSecsTransmitter)fObject).name.Replace(findWhat, replaceWith);
                    ((FSecsTransmitter)fObject).description = ((FSecsTransmitter)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.SecsTransfer)
                {
                    ((FSecsTransfer)fObject).name = ((FSecsTransfer)fObject).name.Replace(findWhat, replaceWith);
                    ((FSecsTransfer)fObject).description = ((FSecsTransfer)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.HostTrigger)
                {
                    foreach (FIObject o in ((FHostTrigger)fObject).fChildHostConditionCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FHostTrigger)fObject).name = ((FHostTrigger)fObject).name.Replace(findWhat, replaceWith);
                    ((FHostTrigger)fObject).description = ((FHostTrigger)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.HostCondition)
                {
                    foreach (FIObject o in ((FHostCondition)fObject).fChildHostExpressionCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FHostCondition)fObject).name = ((FHostCondition)fObject).name.Replace(findWhat, replaceWith);
                    ((FHostCondition)fObject).description = ((FHostCondition)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.HostExpression)
                {
                    foreach (FIObject o in ((FHostExpression)fObject).fChildHostExpressionCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FHostExpression)fObject).name = ((FHostExpression)fObject).name.Replace(findWhat, replaceWith);
                    ((FHostExpression)fObject).description = ((FHostExpression)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.HostTransmitter)
                {
                    foreach (FIObject o in ((FHostTransmitter)fObject).fChildHostTransferCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FHostTransmitter)fObject).name = ((FHostTransmitter)fObject).name.Replace(findWhat, replaceWith);
                    ((FHostTransmitter)fObject).description = ((FHostTransmitter)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.HostTransfer)
                {
                    ((FHostTransfer)fObject).name = ((FHostTransfer)fObject).name.Replace(findWhat, replaceWith);
                    ((FHostTransfer)fObject).description = ((FHostTransfer)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    foreach (FIObject o in ((FEquipmentStateSetAlterer)fObject).fChildEquipmentStateAltererCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FEquipmentStateSetAlterer)fObject).name = ((FEquipmentStateSetAlterer)fObject).name.Replace(findWhat, replaceWith);
                    ((FEquipmentStateSetAlterer)fObject).description = ((FEquipmentStateSetAlterer)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateAlterer)
                {
                    ((FEquipmentStateAlterer)fObject).name = ((FEquipmentStateAlterer)fObject).name.Replace(findWhat, replaceWith);
                    ((FEquipmentStateAlterer)fObject).description = ((FEquipmentStateAlterer)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.Judgement)
                {
                    foreach (FIObject o in ((FJudgement)fObject).fChildJudgementConditionCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FJudgement)fObject).name = ((FJudgement)fObject).name.Replace(findWhat, replaceWith);
                    ((FJudgement)fObject).description = ((FJudgement)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.JudgementCondition)
                {
                    foreach (FIObject o in ((FJudgementCondition)fObject).fChildJudgementExpressionCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FJudgementCondition)fObject).name = ((FJudgementCondition)fObject).name.Replace(findWhat, replaceWith);
                    ((FJudgementCondition)fObject).description = ((FJudgementCondition)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.JudgementExpression)
                {
                    foreach (FIObject o in ((FJudgementExpression)fObject).fChildJudgementExpressionCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FJudgementExpression)fObject).name = ((FJudgementExpression)fObject).name.Replace(findWhat, replaceWith);
                    ((FJudgementExpression)fObject).description = ((FJudgementExpression)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.Mapper)
                {
                    ((FMapper)fObject).name = ((FMapper)fObject).name.Replace(findWhat, replaceWith);
                    ((FMapper)fObject).description = ((FMapper)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.Storage)
                {
                    ((FStorage)fObject).name = ((FStorage)fObject).name.Replace(findWhat, replaceWith);
                    ((FStorage)fObject).description = ((FStorage)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.Callback)
                {
                    foreach (FIObject o in ((FCallback)fObject).fChildFunctionCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FCallback)fObject).name = ((FCallback)fObject).name.Replace(findWhat, replaceWith);
                    ((FCallback)fObject).description = ((FCallback)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.Function)
                {
                    ((FFunction)fObject).name = ((FFunction)fObject).name.Replace(findWhat, replaceWith);
                    ((FFunction)fObject).description = ((FFunction)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.Branch)
                {
                    ((FBranch)fObject).name = ((FBranch)fObject).name.Replace(findWhat, replaceWith);
                    ((FBranch)fObject).description = ((FBranch)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.Pauser)
                {
                    ((FPauser)fObject).name = ((FPauser)fObject).name.Replace(findWhat, replaceWith);
                    ((FPauser)fObject).description = ((FPauser)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.Comment)
                {
                    ((FComment)fObject).name = ((FComment)fObject).name.Replace(findWhat, replaceWith);
                    ((FComment)fObject).description = ((FComment)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.EntryPoint)
                {
                    ((FEntryPoint)fObject).name = ((FEntryPoint)fObject).name.Replace(findWhat, replaceWith);
                    ((FEntryPoint)fObject).description = ((FEntryPoint)fObject).description.Replace(findWhat, replaceWith);
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

        private void procMenuCut(
            )
        {
            UltraTreeNode tNode = null;
            FIObject fObject = null;

            try
            {
                tNode = tvwFlow.ActiveNode;
                fObject = (FIObject)tNode.Tag;

                // --

                if (fObject.fObjectType == FObjectType.SecsTrigger)
                {
                    ((FSecsTrigger)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.SecsCondition)
                {
                    ((FSecsCondition)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.SecsExpression)
                {
                    ((FSecsExpression)fObject).cut();
                }
                // --
                else if (fObject.fObjectType == FObjectType.SecsTransmitter)
                {
                    ((FSecsTransmitter)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.SecsTransfer)
                {
                    ((FSecsTransfer)fObject).cut();
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostTrigger)
                {
                    ((FHostTrigger)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.HostCondition)
                {
                    ((FHostCondition)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.HostExpression)
                {
                    ((FHostExpression)fObject).cut();
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostTransmitter)
                {
                    ((FHostTransmitter)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.HostTransfer)
                {
                    ((FHostTransfer)fObject).cut();
                }
                // --
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    ((FEquipmentStateSetAlterer)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateAlterer)
                {
                    ((FEquipmentStateAlterer)fObject).cut();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Judgement)
                {
                    ((FJudgement)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.JudgementCondition)
                {
                    ((FJudgementCondition)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.JudgementExpression)
                {
                    ((FJudgementExpression)fObject).cut();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Mapper)
                {
                    ((FMapper)fObject).cut();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Storage)
                {
                    ((FStorage)fObject).cut();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Callback)
                {
                    ((FCallback)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.Function)
                {
                    ((FFunction)fObject).cut();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Branch)
                {
                    ((FBranch)fObject).cut();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Comment)
                {
                    ((FComment)fObject).cut();
                }
                // --
                else if (fObject.fObjectType == FObjectType.Pauser)
                {
                    ((FPauser)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.EntryPoint)
                {
                    ((FEntryPoint)fObject).cut();
                }

                // --

                if (
                    fObject.fObjectType == FObjectType.SecsTrigger ||
                    fObject.fObjectType == FObjectType.SecsTransmitter ||
                    fObject.fObjectType == FObjectType.HostTrigger ||
                    fObject.fObjectType == FObjectType.HostTransmitter ||
                    fObject.fObjectType == FObjectType.Judgement ||
                    fObject.fObjectType == FObjectType.Mapper ||
                    fObject.fObjectType == FObjectType.Storage ||
                    fObject.fObjectType == FObjectType.Callback ||
                    fObject.fObjectType == FObjectType.Branch ||
                    fObject.fObjectType == FObjectType.Comment ||
                    fObject.fObjectType == FObjectType.Pauser ||
                    fObject.fObjectType == FObjectType.EntryPoint
                    )
                {
                    removeContainerOfFlow(fObject);
                }
                else
                {
                    removeTreeOfChildFlow(fObject);
                }
            }
            catch (Exception ex)
            {                
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPasteSiblingOfFlow(
            )
        {
            FIObject fRefFlowObject = null;
            FIObject fNewFlowObject = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fRefFlowCtrl = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fNewFlowCtrl = null;

            try
            {
                fRefFlowCtrl = flcContainer.fActiveFlowCtrl;
                fRefFlowObject = (FIObject)fRefFlowCtrl.Tag;

                // --                               

                fNewFlowObject = (FIObject)((FIFlow)fRefFlowObject).pasteSibling();

                if (fNewFlowObject.fObjectType == FObjectType.SecsTrigger)
                {
                    fNewFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FSecsTriggerFlow(fNewFlowObject.uniqueIdToString),
                        fRefFlowCtrl
                        );
                }
                else if (fNewFlowObject.fObjectType == FObjectType.SecsTransmitter)
                {
                    fNewFlowCtrl = flcContainer.insertAfterFlowCtrl(
                       new Nexplant.MC.Core.FaUIs.WPF.FSecsTransmitterFlow(fNewFlowObject.uniqueIdToString),
                       fRefFlowCtrl
                       );
                }
                else if (fNewFlowObject.fObjectType == FObjectType.HostTrigger)
                {
                    fNewFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FHostTriggerFlow(fNewFlowObject.uniqueIdToString),
                        fRefFlowCtrl
                        );
                }
                else if (fNewFlowObject.fObjectType == FObjectType.HostTransmitter)
                {
                    fNewFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FHostTransmitterFlow(fNewFlowObject.uniqueIdToString),
                        fRefFlowCtrl
                        );
                }
                else if (fNewFlowObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    fNewFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FEquipmentStateSetAltererFlow(fNewFlowObject.uniqueIdToString),
                        fRefFlowCtrl
                        );
                }
                else if (fNewFlowObject.fObjectType == FObjectType.Judgement)
                {
                    fNewFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FJudgementFlow(fNewFlowObject.uniqueIdToString),
                        fRefFlowCtrl
                        );
                }
                else if (fNewFlowObject.fObjectType == FObjectType.Mapper)
                {
                    fNewFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FMapperFlow(fNewFlowObject.uniqueIdToString),
                        fRefFlowCtrl
                        );
                }
                else if (fNewFlowObject.fObjectType == FObjectType.Storage)
                {
                    fNewFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FStorageFlow(fNewFlowObject.uniqueIdToString),
                        fRefFlowCtrl
                        );
                }
                else if (fNewFlowObject.fObjectType == FObjectType.Callback)
                {
                    fNewFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FCallbackFlow(fNewFlowObject.uniqueIdToString),
                        fRefFlowCtrl
                        );
                }
                else if (fNewFlowObject.fObjectType == FObjectType.Branch)
                {
                    fNewFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FBranchFlow(fNewFlowObject.uniqueIdToString),
                        fRefFlowCtrl
                        );
                }
                else if (fNewFlowObject.fObjectType == FObjectType.Comment)
                {
                    fNewFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FCommentFlow(fNewFlowObject.uniqueIdToString),
                        fRefFlowCtrl
                        );
                }
                else if (fNewFlowObject.fObjectType == FObjectType.Pauser)
                {
                    fNewFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FPauserFlow(fNewFlowObject.uniqueIdToString),
                        fRefFlowCtrl
                        );
                }
                else if (fNewFlowObject.fObjectType == FObjectType.EntryPoint)
                {
                    fNewFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FEntryPointFlow(fNewFlowObject.uniqueIdToString),
                        fRefFlowCtrl
                        );
                }

                // --

                FCommon.refreshFlowCtrlOfObject((FIObject)fNewFlowObject, fNewFlowCtrl, tvwFlow);
                fNewFlowCtrl.Tag = fNewFlowObject;
                flcContainer.activateFlowCtrl(fNewFlowCtrl);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fNewFlowCtrl = null;
                fRefFlowCtrl = null;
                fRefFlowObject = null;
                fNewFlowObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPasteSiblingOfChildFlow(
            )
        {
            UltraTreeNode tNodeRef = null;
            UltraTreeNode tNodeNew = null;
            FIObject fRefObject = null;
            FIObject fNewObject = null;

            try
            {
                tNodeRef = tvwFlow.ActiveNode;
                fRefObject = (FIObject)tNodeRef.Tag;
                
                // --

                if (fRefObject.fObjectType == FObjectType.SecsCondition)
                {
                    fNewObject = ((FSecsCondition)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.SecsExpression)
                {
                    fNewObject = ((FSecsExpression)fRefObject).pasteSibling();
                }
                // --
                else if (fRefObject.fObjectType == FObjectType.SecsTransfer)
                {
                    fNewObject = ((FSecsTransfer)fRefObject).pasteSibling();
                }
                // --
                else if (fRefObject.fObjectType == FObjectType.HostCondition)
                {
                    fNewObject = ((FHostCondition)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.HostExpression)
                {
                    fNewObject = ((FHostExpression)fRefObject).pasteSibling();
                }
                // --
                else if (fRefObject.fObjectType == FObjectType.HostTransfer)
                {
                    fNewObject = ((FHostTransfer)fRefObject).pasteSibling();
                }
                // --
                else if (fRefObject.fObjectType == FObjectType.EquipmentStateAlterer)
                {
                    fNewObject = ((FEquipmentStateAlterer)fRefObject).pasteSibling();
                }
                // --
                else if (fRefObject.fObjectType == FObjectType.JudgementCondition)
                {
                    fNewObject = ((FJudgementCondition)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.JudgementExpression)
                {
                    fNewObject = ((FJudgementExpression)fRefObject).pasteSibling();
                }
                // --
                else if (fRefObject.fObjectType == FObjectType.Function)
                {
                    fNewObject = ((FFunction)fRefObject).pasteSibling();
                }

                // --

                tvwFlow.beginUpdate();
                
                // --

                tNodeNew = new UltraTreeNode(fNewObject.uniqueIdToString);
                tNodeNew.Tag = fNewObject;
                FCommon.refreshTreeNodeOfObject(fNewObject, tvwFlow, tNodeNew);

                // --

                loadTreeOfChildFlow(tNodeNew);
                tNodeRef.Parent.Nodes.Insert(tNodeRef.Index + 1, tNodeNew);
                // --
                tvwFlow.SelectedNodes.Clear();
                tvwFlow.ActiveNode = tNodeNew;

                // --

                tvwFlow.endUpdate();
            }
            catch (Exception ex)
            {
                tvwFlow.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeRef = null;
                tNodeNew = null;
                fRefObject = null;
                fNewObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPasteChildOfFlow(
            )
        {
            FIObject fNewFlowObject = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fNewFlowCtrl = null;

            try
            {
                fNewFlowObject = (FIObject)m_fSnr.pasteChild();

                // --

                if (fNewFlowObject.fObjectType == FObjectType.SecsTrigger)
                {
                    fNewFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FSecsTriggerFlow(fNewFlowObject.uniqueIdToString));                    
                }
                else if (fNewFlowObject.fObjectType == FObjectType.SecsTransmitter)
                {
                    fNewFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FSecsTransmitterFlow(fNewFlowObject.uniqueIdToString));                    
                }
                else if (fNewFlowObject.fObjectType == FObjectType.HostTrigger)
                {
                    fNewFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FHostTriggerFlow(fNewFlowObject.uniqueIdToString));                    
                }
                else if (fNewFlowObject.fObjectType == FObjectType.HostTransmitter)
                {
                    fNewFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FHostTransmitterFlow(fNewFlowObject.uniqueIdToString));
                }
                else if (fNewFlowObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    fNewFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FEquipmentStateSetAltererFlow(fNewFlowObject.uniqueIdToString));
                }
                else if (fNewFlowObject.fObjectType == FObjectType.Judgement)
                {
                    fNewFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FJudgementFlow(fNewFlowObject.uniqueIdToString));
                }
                else if (fNewFlowObject.fObjectType == FObjectType.Mapper)
                {
                    fNewFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FMapperFlow(fNewFlowObject.uniqueIdToString));
                }
                else if (fNewFlowObject.fObjectType == FObjectType.Storage)
                {
                    fNewFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FStorageFlow(fNewFlowObject.uniqueIdToString));
                }
                else if (fNewFlowObject.fObjectType == FObjectType.Callback)
                {
                    fNewFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FCallbackFlow(fNewFlowObject.uniqueIdToString));
                }
                else if (fNewFlowObject.fObjectType == FObjectType.Branch)
                {
                    fNewFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FBranchFlow(fNewFlowObject.uniqueIdToString));
                }
                else if (fNewFlowObject.fObjectType == FObjectType.Comment)
                {
                    fNewFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FCommentFlow(fNewFlowObject.uniqueIdToString));
                }
                else if (fNewFlowObject.fObjectType == FObjectType.Pauser)
                {
                    fNewFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FPauserFlow(fNewFlowObject.uniqueIdToString));
                }
                else if (fNewFlowObject.fObjectType == FObjectType.EntryPoint)
                {
                    fNewFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FEntryPointFlow(fNewFlowObject.uniqueIdToString));
                }

                // --

                FCommon.refreshFlowCtrlOfObject((FIObject)fNewFlowObject, fNewFlowCtrl, tvwFlow);
                fNewFlowCtrl.Tag = fNewFlowObject;
                flcContainer.activateFlowCtrl(fNewFlowCtrl);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fNewFlowCtrl = null;
                fNewFlowObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPasteChildOfChildFlow(
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeChild = null;
            FIObject fParent = null;
            FIObject fChild = null;

            try
            {
                tNodeParent = tvwFlow.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;

                // --
                
                if (fParent.fObjectType == FObjectType.SecsTrigger)
                {
                    fChild = ((FSecsTrigger)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.SecsCondition)
                {
                    fChild = ((FSecsCondition)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.SecsExpression)
                {
                    fChild = ((FSecsExpression)fParent).pasteChild();
                }
                // --
                else if (fParent.fObjectType == FObjectType.SecsTransmitter)
                {
                    fChild = ((FSecsTransmitter)fParent).pasteChild();
                }
                // --
                else if (fParent.fObjectType == FObjectType.HostTrigger)
                {
                    fChild = ((FHostTrigger)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.HostCondition)
                {
                    fChild = ((FHostCondition)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.HostExpression)
                {
                    fChild = ((FHostExpression)fParent).pasteChild();
                }
                // --
                else if (fParent.fObjectType == FObjectType.HostTransmitter)
                {
                    fChild = ((FHostTransmitter)fParent).pasteChild();
                }
                // --
                else if (fParent.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    fChild = ((FEquipmentStateSetAlterer)fParent).pasteChild();
                }
                // --
                else if (fParent.fObjectType == FObjectType.Judgement)
                {
                    fChild = ((FJudgement)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.JudgementCondition)
                {
                    fChild = ((FJudgementCondition)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.JudgementExpression)
                {
                    fChild = ((FJudgementExpression)fParent).pasteChild();
                }
                // --
                else if (fParent.fObjectType == FObjectType.Callback)
                {
                    fChild = ((FCallback)fParent).pasteChild();
                }

                tNodeChild = new UltraTreeNode(fChild.uniqueIdToString);
                tNodeChild.Tag = fChild;
                FCommon.refreshTreeNodeOfObject(fChild, tvwFlow, tNodeChild);
                
                // --

                loadTreeOfChildFlow(tNodeChild);
                tNodeParent.Nodes.Add(tNodeChild);
                // --
                tvwFlow.SelectedNodes.Clear();
                tvwFlow.ActiveNode = tNodeChild;

                // --

                tvwFlow.endUpdate();
            }
            catch (Exception ex)
            {
                tvwFlow.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeParent = null;
                tNodeChild = null;
                fParent = null;
                fChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRelation(
            )
        {
            FIObject fObject = null;

            try
            {
                if (m_fActiveObject.fObjectType == FObjectType.Scenario)
                {
                    fObject = m_fActiveObject;
                }
                else
                {
                    fObject = (FIObject)tvwFlow.ActiveNode.Tag;
                }

                // --

                m_fSsmCore.fSsmContainer.showRelationViewer(fObject);
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

        private void procMenuSearchFlow(
            string searchWord
            )
        {
            FScenario fSnr = null;
            UltraTreeNode tNode = null;
            FIObject fObject = null;
            FIObject fResult = null;

            try
            {                
                fSnr = (FScenario)flcContainer.Tag;                
                if (fSnr == null)
                {
                    FMessageBox.showInformation("Search", m_fSsmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
                    return;
                }                

                // --

                if (tvwFlow.ActiveNode == null)
                {
                    fObject = null;
                }
                else
                {
                    fObject = (FIObject)tvwFlow.ActiveNode.Tag;
                }

                // --
                
                fResult = m_fSsmCore.fSsmFileInfo.fSecsDriver.searchScenarioSeries(fObject, fSnr, searchWord);
                if (fResult == null)
                {
                    FMessageBox.showInformation("Search", m_fSsmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
                    return;
                }

                // --
                
                activateContainerForSearchFlow(fResult);
                
                // --

                tvwFlow.beginUpdate();

                // --

                expandTreeForSearchFlow(fResult);
                tNode = tvwFlow.GetNodeByKey(fResult.uniqueIdToString);
                tvwFlow.SelectedNodes.Clear();
                tvwFlow.ActiveNode = tNode;                

                // --

                tvwFlow.endUpdate();
            }
            catch (Exception ex)
            {
                tvwFlow.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSnr = null;
                tNode = null;
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void activateContainerForSearchFlow(
            FIObject fObject
            )
        {
            try
            {
                if (
                    fObject.fObjectType == FObjectType.SecsTrigger ||
                    fObject.fObjectType == FObjectType.SecsTransmitter ||
                    fObject.fObjectType == FObjectType.HostTrigger ||
                    fObject.fObjectType == FObjectType.HostTransmitter ||
                    fObject.fObjectType == FObjectType.Judgement ||
                    fObject.fObjectType == FObjectType.Mapper ||
                    fObject.fObjectType == FObjectType.Storage ||
                    fObject.fObjectType == FObjectType.Callback ||
                    fObject.fObjectType == FObjectType.Branch ||
                    fObject.fObjectType == FObjectType.Comment ||
                    fObject.fObjectType == FObjectType.Pauser ||
                    fObject.fObjectType == FObjectType.EntryPoint
                    )
                {
                    foreach (Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fFlowCtrl in flcContainer.fFlowCtrlCollection)
                    {
                        // ***
                        // 2012.11.22 by spike.lee
                        // 찾았으면 break해서 빠저나오면 조금 빠르지 않을까?
                        // ***
                        if (((FIObject)fFlowCtrl.Tag).uniqueIdToString == fObject.uniqueIdToString)
                        {
                            flcContainer.activateFlowCtrl(fFlowCtrl);
                            break;
                        }
                    }

                }
                else
                {
                    activateContainerForSearchFlow(m_fSsmCore.fSsmFileInfo.fSecsDriver.getParentOfObject(fObject));
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

        private void expandTreeForSearchFlow(
            FIObject fObject
            )
        {
            FIObject fParent = null;
            UltraTreeNode tNodeParent = null;

            try
            {
                if (fObject.fObjectType == FObjectType.Scenario)
                {
                    return;
                }

                // --

                fParent = m_fSsmCore.fSsmFileInfo.fSecsDriver.getParentOfObject(fObject);

                // --

                tNodeParent = tvwFlow.GetNodeByKey(fParent.uniqueIdToString);
                if (tNodeParent == null || !tNodeParent.Expanded)
                {
                    expandTreeForSearchFlow(fParent);
                }

                // --

                if (tNodeParent == null)
                {
                    tNodeParent = tvwFlow.GetNodeByKey(fObject.uniqueIdToString);
                }
                tNodeParent.Expanded = true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
                tNodeParent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        public FIObject getFlowCtrl(
            FIObject fObject
            )
        {
            try
            {
                if (
                    fObject.fObjectType == FObjectType.SecsTrigger ||
                    fObject.fObjectType == FObjectType.SecsTransmitter||
                    fObject.fObjectType == FObjectType.HostTrigger ||
                    fObject.fObjectType == FObjectType.HostTransmitter ||
                    fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                    fObject.fObjectType == FObjectType.Judgement ||
                    fObject.fObjectType == FObjectType.Mapper ||
                    fObject.fObjectType == FObjectType.Storage ||
                    fObject.fObjectType == FObjectType.Callback ||
                    fObject.fObjectType == FObjectType.Branch ||
                    fObject.fObjectType == FObjectType.Comment ||
                    fObject.fObjectType == FObjectType.Pauser ||
                    fObject.fObjectType == FObjectType.EntryPoint
                    )
                {
                    return fObject;
                }
                // --
                else if (fObject.fObjectType == FObjectType.SecsCondition)
                {
                    return getFlowCtrl(((FSecsCondition)fObject).fParent);
                }
                else if (fObject.fObjectType == FObjectType.SecsExpression)
                {
                    return getFlowCtrl(((FSecsExpression)fObject).fParent);
                }
                // --                
                else if (fObject.fObjectType == FObjectType.SecsTransfer)
                {
                    return getFlowCtrl(((FSecsTransfer)fObject).fParent);
                }
                // --                
                else if (fObject.fObjectType == FObjectType.HostCondition)
                {
                    return getFlowCtrl(((FHostCondition)fObject).fParent);
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostExpression)
                {
                    return getFlowCtrl(((FHostExpression)fObject).fParent);
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostTransfer)
                {
                    return getFlowCtrl(((FHostTransfer)fObject).fParent);
                }
                // --                
                else if (fObject.fObjectType == FObjectType.EquipmentStateAlterer)
                {
                    return getFlowCtrl(((FEquipmentStateAlterer)fObject).fParent);
                }
                // --
                else if (fObject.fObjectType == FObjectType.JudgementCondition)
                {
                    return getFlowCtrl(((FJudgementCondition)fObject).fParent);
                }
                else if (fObject.fObjectType == FObjectType.JudgementExpression)
                {
                    return getFlowCtrl(((FJudgementExpression)fObject).fParent);
                }
                else if (fObject.fObjectType == FObjectType.Function)
                {
                    return getFlowCtrl(((FFunction)fObject).fParent);
                }                
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

        //------------------------------------------------------------------------------------------------------------------------

        public void searchScenario(
            string flowId
            )
        {
            try
            {
                foreach (Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl searchFlow in flcContainer.fFlowCtrlCollection)
                {
                    if (((FIObject)searchFlow.Tag).uniqueIdToString == flowId)
                    {
                        flcContainer.activateFlowCtrl(searchFlow);
                    }
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

        public void searchFlowCtrl(
            FIObject fObject
            )
        {
            UltraTreeNode tNodeParent = null;
            FIObject fParent = null;    

            try
            {
                if (fObject.fObjectType == FObjectType.SecsTrigger)
                {
                    fParent = ((FSecsTrigger)fObject);
                }
                else if (fObject.fObjectType == FObjectType.SecsCondition)
                {
                    fParent = ((FSecsCondition)fObject).fParent;
                }
                else if (fObject.fObjectType == FObjectType.SecsExpression)
                {
                    fParent = ((FSecsExpression)fObject).fParent;
                }
                // --
                else if (fObject.fObjectType == FObjectType.SecsTransmitter)
                {
                    fParent = ((FSecsTransmitter)fObject);
                }
                else if (fObject.fObjectType == FObjectType.SecsTransfer)
                {
                    fParent = ((FSecsTransfer)fObject).fParent;
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostTrigger)
                {
                    fParent = ((FHostTrigger)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostCondition)
                {
                    fParent = ((FHostCondition)fObject).fParent;
                }
                else if (fObject.fObjectType == FObjectType.HostExpression)
                {
                    fParent = ((FHostExpression)fObject).fParent;
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostTransmitter)
                {
                    fParent = ((FHostTransmitter)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostTransfer)
                {
                    fParent = ((FHostTransfer)fObject).fParent;
                }                
                // --
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    fParent = ((FEquipmentStateSetAlterer)fObject);
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateAlterer)
                {
                    fParent = ((FEquipmentStateAlterer)fObject).fParent;
                }
                // --
                else if (fObject.fObjectType == FObjectType.Judgement)
                {
                    fParent = ((FJudgement)fObject);
                }
                else if (fObject.fObjectType == FObjectType.JudgementCondition)
                {
                    fParent = ((FJudgementCondition)fObject).fParent;
                }
                else if (fObject.fObjectType == FObjectType.JudgementExpression)
                {
                    fParent = ((FJudgementExpression)fObject).fParent;
                }
                // --
                else if (fObject.fObjectType == FObjectType.Mapper)
                {
                    fParent = ((FMapper)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Storage)
                {
                    fParent = ((FStorage)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Callback)
                {
                    fParent = ((FCallback)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Function)
                {
                    fParent = ((FFunction)fObject).fParent;
                }
                else if (fObject.fObjectType == FObjectType.Branch)
                {
                    fParent = ((FBranch)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Comment)
                {
                    fParent = ((FComment)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Pauser)
                {
                    fParent = ((FPauser)fObject);
                }
                else if (fObject.fObjectType == FObjectType.EntryPoint)
                {
                    fParent = ((FPauser)fObject);
                }
                // --                              

                tNodeParent = tvwFlow.GetNodeByKey(fObject.uniqueIdToString);

                // --

                if (tNodeParent == null)
                {
                    searchFlowCtrl(fParent);
                    // --

                    if (tvwFlow.ActiveNode.Parent != null)
                    {
                        tvwFlow.ActiveNode.Parent.Expanded = true;
                    }
                    tvwFlow.ActiveNode.Expanded = true;
                }
                else
                {
                    tvwFlow.ActiveNode = tNodeParent;
                }

                // --

                if (
                    fObject != fParent &&
                    tNodeParent == null
                    )
                {
                    tvwFlow.ActiveNode = tvwFlow.GetNodeByKey(fObject.uniqueIdToString);
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

        private string getAppendFlowMenuKey(
            FFlowCtrlType fFlowCtrlType
            )
        {
            string menuKey = string.Empty;

            try
            {
                if (fFlowCtrlType == FFlowCtrlType.SecsTrigger)
                {
                    menuKey = FMenuKey.MenuSnrAppendSecsTrigger;
                }
                else if(fFlowCtrlType == FFlowCtrlType.SecsTransmitter)
                {
                    menuKey = FMenuKey.MenuSnrAppendSecsTransmitter;
                }
                else if(fFlowCtrlType == FFlowCtrlType.HostTrigger)
                {
                    menuKey = FMenuKey.MenuSnrAppendHostTrigger;
                }
                else if(fFlowCtrlType == FFlowCtrlType.HostTransmitter)
                {
                    menuKey = FMenuKey.MenuSnrAppendHostTransmitter;
                }
                else if(fFlowCtrlType == FFlowCtrlType.EquipmentStateSetAlterer)
                {
                    menuKey = FMenuKey.MenuSnrAppendEquipmentStateSetAlterer;
                }
                else if(fFlowCtrlType == FFlowCtrlType.Judgement)
                {
                    menuKey = FMenuKey.MenuSnrAppendJudgement;
                }
                else if(fFlowCtrlType == FFlowCtrlType.Mapper)
                {
                    menuKey = FMenuKey.MenuSnrAppendMapper;
                }
                else if(fFlowCtrlType == FFlowCtrlType.Storage)
                {
                    menuKey = FMenuKey.MenuSnrAppendStorage;
                }
                else if(fFlowCtrlType == FFlowCtrlType.Callback)
                {
                    menuKey = FMenuKey.MenuSnrAppendCallback;
                }
                else if(fFlowCtrlType == FFlowCtrlType.Branch)
                {
                    menuKey = FMenuKey.MenuSnrAppendBranch;
                }
                else if(fFlowCtrlType == FFlowCtrlType.Comment)
                {
                    menuKey = FMenuKey.MenuSnrAppendComment;
                }
                return menuKey;
            }
            catch(Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
            
            }
            return string.Empty;            
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FScenarioDesigner Form Event Handler

        private void FScenarioDesigner_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();
                
                // --

                designTreeOfScenarioDesigner();

                // --

                // ***
                // Popup Menu 설정
                // ***
                flcContainer.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuSnrPopupMenu]);
                tvwFlow.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuSnrPopupMenu]);

                // --
                
                // ***
                // flcContainer Event Handler 설정
                // ***
                flcContainer.KeyDown += new System.Windows.Input.KeyEventHandler(flcContainer_KeyDown);                
                flcContainer.FlowContainerActivated += new Nexplant.MC.Core.FaUIs.WPF.FFlowContainerActivatedEventHandler(flcContainer_FlowContainerActivated);
                flcContainer.FlowCtrlActivated += new Nexplant.MC.Core.FaUIs.WPF.FFlowCtrlActivatedEventHandler(flcContainer_FlowCtrlActivated);
                flcContainer.FlowMouseMove += new Core.FaUIs.WPF.FFlowMouseMoveEventHandler(flcContainer_FlowMouseMove);
                flcContainer.FlowDragOver += new Core.FaUIs.WPF.FFlowDragOverEventHandler(flcContainer_FlowDragOver);
                flcContainer.FlowDragDrop += new Core.FaUIs.WPF.FFlowDragDropEventHandler(flcContainer_FlowDragDrop);

                // --

                // ***
                // Secs Event Handler 설정
                // ***                
                m_fEventHandler = new FEventHandler(m_fSsmCore.fSsmFileInfo.fSecsDriver, this);                
                // --
                m_fEventHandler.ObjectInsertBeforeCompleted += new FObjectInsertBeforeCompletedEventHandler(m_fEventHandler_ObjectInsertBeforeCompleted);
                m_fEventHandler.ObjectInsertAfterCompleted += new FObjectInsertAfterCompletedEventHandler(m_fEventHandler_ObjectInsertAfterCompleted);
                m_fEventHandler.ObjectAppendCompleted += new FObjectAppendCompletedEventHandler(m_fEventHandler_ObjectAppendCompleted);
                m_fEventHandler.ObjectRemoveCompleted += new FObjectRemoveCompletedEventHandler(m_fEventHandler_ObjectRemoveCompleted);
                m_fEventHandler.ObjectMoveUpCompleted += new FObjectMoveUpCompletedEventHandler(m_fEventHandler_ObjectMoveUpCompleted);
                m_fEventHandler.ObjectMoveDownCompleted += new FObjectMoveDownCompletedEventHandler(m_fEventHandler_ObjectMoveDownCompleted);
                m_fEventHandler.ObjectMoveToCompleted += new FObjectMoveToCompletedEventHandler(m_fEventHandler_ObjectMoveToCompleted);
                m_fEventHandler.ObjectModifyCompleted += new FObjectModifyCompletedEventHandler(m_fEventHandler_ObjectModifyCompleted);

                // --

                m_fSsmCore.fOption.fChildFormList.add(this, this.Text + " - [" + m_fSnr.name + "]");
            }
            catch (Exception ex)
            {                
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FScenarioDesigner_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                loadContainerOfFlow();

                // --

                flowContHost.Focus();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FScenarioDesigner_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                // ***
                // Secs Event Handler 해제
                // ***
                if (m_fEventHandler != null)
                {
                    m_fSsmCore.fSsmFileInfo.fSecsDriver.waitEventHandlingCompleted();

                    // --

                    m_fEventHandler.Dispose();
                    // --
                    m_fEventHandler.ObjectInsertBeforeCompleted -= new FObjectInsertBeforeCompletedEventHandler(m_fEventHandler_ObjectInsertBeforeCompleted);
                    m_fEventHandler.ObjectInsertAfterCompleted -= new FObjectInsertAfterCompletedEventHandler(m_fEventHandler_ObjectInsertAfterCompleted);
                    m_fEventHandler.ObjectAppendCompleted -= new FObjectAppendCompletedEventHandler(m_fEventHandler_ObjectAppendCompleted);
                    m_fEventHandler.ObjectRemoveCompleted -= new FObjectRemoveCompletedEventHandler(m_fEventHandler_ObjectRemoveCompleted);
                    m_fEventHandler.ObjectMoveUpCompleted -= new FObjectMoveUpCompletedEventHandler(m_fEventHandler_ObjectMoveUpCompleted);
                    m_fEventHandler.ObjectMoveDownCompleted -= new FObjectMoveDownCompletedEventHandler(m_fEventHandler_ObjectMoveDownCompleted);
                    m_fEventHandler.ObjectMoveToCompleted -= new FObjectMoveToCompletedEventHandler(m_fEventHandler_ObjectMoveToCompleted);
                    m_fEventHandler.ObjectModifyCompleted -= new FObjectModifyCompletedEventHandler(m_fEventHandler_ObjectModifyCompleted);
                    // --
                    m_fEventHandler = null;
                }

                // --

                // ***
                // flcContainer Event Handler 설정
                // ***
                flcContainer.KeyDown -= new System.Windows.Input.KeyEventHandler(flcContainer_KeyDown);                
                flcContainer.FlowContainerActivated -= new Nexplant.MC.Core.FaUIs.WPF.FFlowContainerActivatedEventHandler(flcContainer_FlowContainerActivated);
                flcContainer.FlowCtrlActivated -= new Nexplant.MC.Core.FaUIs.WPF.FFlowCtrlActivatedEventHandler(flcContainer_FlowCtrlActivated);
                flcContainer.FlowMouseMove -= new Core.FaUIs.WPF.FFlowMouseMoveEventHandler(flcContainer_FlowMouseMove);
                flcContainer.FlowDragOver -= new Core.FaUIs.WPF.FFlowDragOverEventHandler(flcContainer_FlowDragOver);
                flcContainer.FlowDragDrop -= new Core.FaUIs.WPF.FFlowDragDropEventHandler(flcContainer_FlowDragDrop);

                // --

                m_fSsmCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region fEventHandler Object Event Handler

        private void m_fEventHandler_ObjectInsertBeforeCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.SecsTrigger ||
                    e.fObject.fObjectType == FObjectType.SecsTransmitter ||
                    e.fObject.fObjectType == FObjectType.HostTrigger ||
                    e.fObject.fObjectType == FObjectType.HostTransmitter ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                    e.fObject.fObjectType == FObjectType.Judgement ||
                    e.fObject.fObjectType == FObjectType.Mapper ||
                    e.fObject.fObjectType == FObjectType.Storage ||
                    e.fObject.fObjectType == FObjectType.Callback ||
                    e.fObject.fObjectType == FObjectType.Branch ||
                    e.fObject.fObjectType == FObjectType.Comment ||
                    e.fObject.fObjectType == FObjectType.Pauser ||
                    e.fObject.fObjectType == FObjectType.EntryPoint
                    )
                {
                    addContainerOfFlow(e.fParentObject, e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.SecsCondition ||
                    e.fObject.fObjectType == FObjectType.SecsExpression ||
                    e.fObject.fObjectType == FObjectType.SecsTransfer ||
                    e.fObject.fObjectType == FObjectType.HostCondition ||                    
                    e.fObject.fObjectType == FObjectType.HostExpression ||
                    e.fObject.fObjectType == FObjectType.HostTransfer ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateAlterer ||
                    e.fObject.fObjectType == FObjectType.JudgementCondition ||
                    e.fObject.fObjectType == FObjectType.JudgementExpression ||
                    e.fObject.fObjectType == FObjectType.Function 
                    )
                {
                    addTreeOfChildFlow(e.fParentObject, e.fObject);   
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ObjectInsertAfterCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.SecsTrigger ||
                    e.fObject.fObjectType == FObjectType.SecsTransmitter ||
                    e.fObject.fObjectType == FObjectType.HostTrigger ||
                    e.fObject.fObjectType == FObjectType.HostTransmitter ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                    e.fObject.fObjectType == FObjectType.Judgement ||
                    e.fObject.fObjectType == FObjectType.Mapper ||
                    e.fObject.fObjectType == FObjectType.Storage ||
                    e.fObject.fObjectType == FObjectType.Callback ||
                    e.fObject.fObjectType == FObjectType.Branch ||
                    e.fObject.fObjectType == FObjectType.Comment ||
                    e.fObject.fObjectType == FObjectType.Pauser ||
                    e.fObject.fObjectType == FObjectType.EntryPoint
                    )
                {
                    addContainerOfFlow(e.fParentObject, e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.SecsCondition ||
                    e.fObject.fObjectType == FObjectType.SecsExpression ||
                    e.fObject.fObjectType == FObjectType.SecsTransfer ||
                    e.fObject.fObjectType == FObjectType.HostCondition ||
                    e.fObject.fObjectType == FObjectType.HostExpression ||
                    e.fObject.fObjectType == FObjectType.HostTransfer ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateAlterer ||
                    e.fObject.fObjectType == FObjectType.JudgementCondition ||
                    e.fObject.fObjectType == FObjectType.JudgementExpression ||
                    e.fObject.fObjectType == FObjectType.Function 
                    )
                {
                    addTreeOfChildFlow(e.fParentObject, e.fObject);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ObjectAppendCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.SecsTrigger ||
                    e.fObject.fObjectType == FObjectType.SecsTransmitter ||
                    e.fObject.fObjectType == FObjectType.HostTrigger ||
                    e.fObject.fObjectType == FObjectType.HostTransmitter ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                    e.fObject.fObjectType == FObjectType.Judgement ||
                    e.fObject.fObjectType == FObjectType.Mapper ||
                    e.fObject.fObjectType == FObjectType.Storage || 
                    e.fObject.fObjectType == FObjectType.Callback ||
                    e.fObject.fObjectType == FObjectType.Branch ||
                    e.fObject.fObjectType == FObjectType.Comment ||
                    e.fObject.fObjectType == FObjectType.Pauser ||
                    e.fObject.fObjectType == FObjectType.EntryPoint
                    )
                {
                    addContainerOfFlow(e.fParentObject, e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.SecsCondition ||
                    e.fObject.fObjectType == FObjectType.SecsExpression ||
                    e.fObject.fObjectType == FObjectType.SecsTransfer ||
                    e.fObject.fObjectType == FObjectType.HostCondition ||
                    e.fObject.fObjectType == FObjectType.HostExpression ||
                    e.fObject.fObjectType == FObjectType.HostTransfer ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateAlterer ||
                    e.fObject.fObjectType == FObjectType.JudgementCondition ||
                    e.fObject.fObjectType == FObjectType.JudgementExpression ||
                    e.fObject.fObjectType == FObjectType.Function 
                    )
                {
                    addTreeOfChildFlow(e.fParentObject, e.fObject);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ObjectRemoveCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (e.fObject.fObjectType == FObjectType.Scenario)
                {
                    if (e.fObject == m_fSnr)
                    {
                        this.BeginInvoke(new MethodInvoker(delegate()
                        {
                            this.Close();
                        }));                            
                    }
                }
                else if (
                    e.fObject.fObjectType == FObjectType.SecsTrigger ||
                    e.fObject.fObjectType == FObjectType.SecsTransmitter ||
                    e.fObject.fObjectType == FObjectType.HostTrigger ||
                    e.fObject.fObjectType == FObjectType.HostTransmitter ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                    e.fObject.fObjectType == FObjectType.Judgement ||
                    e.fObject.fObjectType == FObjectType.Mapper ||
                    e.fObject.fObjectType == FObjectType.Storage ||
                    e.fObject.fObjectType == FObjectType.Callback ||
                    e.fObject.fObjectType == FObjectType.Branch ||
                    e.fObject.fObjectType == FObjectType.Comment ||
                    e.fObject.fObjectType == FObjectType.Pauser ||
                    e.fObject.fObjectType == FObjectType.EntryPoint
                    )
                {
                    removeContainerOfFlow(e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.SecsCondition ||
                    e.fObject.fObjectType == FObjectType.SecsExpression ||
                    e.fObject.fObjectType == FObjectType.SecsTransfer ||
                    e.fObject.fObjectType == FObjectType.HostCondition ||
                    e.fObject.fObjectType == FObjectType.HostExpression ||
                    e.fObject.fObjectType == FObjectType.HostTransfer ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateAlterer ||
                    e.fObject.fObjectType == FObjectType.JudgementCondition ||
                    e.fObject.fObjectType == FObjectType.JudgementExpression ||
                    e.fObject.fObjectType == FObjectType.Function 
                    )
                {
                    removeTreeOfChildFlow(e.fObject);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ObjectMoveUpCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.SecsTrigger ||
                    e.fObject.fObjectType == FObjectType.SecsTransmitter ||
                    e.fObject.fObjectType == FObjectType.HostTrigger ||
                    e.fObject.fObjectType == FObjectType.HostTransmitter ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                    e.fObject.fObjectType == FObjectType.Judgement ||
                    e.fObject.fObjectType == FObjectType.Mapper ||
                    e.fObject.fObjectType == FObjectType.Storage ||
                    e.fObject.fObjectType == FObjectType.Callback ||
                    e.fObject.fObjectType == FObjectType.Branch ||
                    e.fObject.fObjectType == FObjectType.Comment ||
                    e.fObject.fObjectType == FObjectType.Pauser ||
                    e.fObject.fObjectType == FObjectType.EntryPoint
                    )
                {
                    moveUpContainerOfFlow(e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.SecsCondition ||
                    e.fObject.fObjectType == FObjectType.SecsExpression ||
                    e.fObject.fObjectType == FObjectType.SecsTransfer ||
                    e.fObject.fObjectType == FObjectType.HostCondition ||
                    e.fObject.fObjectType == FObjectType.HostExpression ||
                    e.fObject.fObjectType == FObjectType.HostTransfer ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateAlterer ||
                    e.fObject.fObjectType == FObjectType.JudgementCondition ||
                    e.fObject.fObjectType == FObjectType.JudgementExpression ||
                    e.fObject.fObjectType == FObjectType.Function
                    )
                {
                    moveUpTreeOfChildFlow(e.fObject);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ObjectMoveDownCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.SecsTrigger ||
                    e.fObject.fObjectType == FObjectType.SecsTransmitter ||
                    e.fObject.fObjectType == FObjectType.HostTrigger ||
                    e.fObject.fObjectType == FObjectType.HostTransmitter ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                    e.fObject.fObjectType == FObjectType.Judgement ||
                    e.fObject.fObjectType == FObjectType.Mapper ||
                    e.fObject.fObjectType == FObjectType.Storage ||
                    e.fObject.fObjectType == FObjectType.Callback ||
                    e.fObject.fObjectType == FObjectType.Branch ||
                    e.fObject.fObjectType == FObjectType.Comment ||
                    e.fObject.fObjectType == FObjectType.Pauser ||
                    e.fObject.fObjectType == FObjectType.EntryPoint
                    )
                {
                    moveDownContainerOfFlow(e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.SecsCondition ||
                    e.fObject.fObjectType == FObjectType.SecsExpression ||
                    e.fObject.fObjectType == FObjectType.SecsTransfer ||
                    e.fObject.fObjectType == FObjectType.HostCondition ||
                    e.fObject.fObjectType == FObjectType.HostExpression ||
                    e.fObject.fObjectType == FObjectType.HostTransfer ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateAlterer ||
                    e.fObject.fObjectType == FObjectType.JudgementCondition ||
                    e.fObject.fObjectType == FObjectType.JudgementExpression ||
                    e.fObject.fObjectType == FObjectType.Function
                    )
                {
                    moveDownTreeOfChildFlow(e.fObject);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ObjectMoveToCompleted(
            object sender,
            FObjectMoveToCompletedEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.SecsTrigger ||
                    e.fObject.fObjectType == FObjectType.SecsTransmitter ||
                    e.fObject.fObjectType == FObjectType.HostTrigger ||
                    e.fObject.fObjectType == FObjectType.HostTransmitter ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                    e.fObject.fObjectType == FObjectType.Judgement ||
                    e.fObject.fObjectType == FObjectType.Mapper ||
                    e.fObject.fObjectType == FObjectType.Storage ||
                    e.fObject.fObjectType == FObjectType.Callback ||
                    e.fObject.fObjectType == FObjectType.Branch ||
                    e.fObject.fObjectType == FObjectType.Comment ||
                    e.fObject.fObjectType == FObjectType.Pauser ||
                    e.fObject.fObjectType == FObjectType.EntryPoint
                    )
                {
                    moveToContainerOfFlow(e.fObject, e.fRefObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.SecsCondition ||
                    e.fObject.fObjectType == FObjectType.SecsExpression ||
                    e.fObject.fObjectType == FObjectType.SecsTransfer ||
                    e.fObject.fObjectType == FObjectType.HostCondition ||
                    e.fObject.fObjectType == FObjectType.HostExpression ||
                    e.fObject.fObjectType == FObjectType.HostTransfer ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateAlterer ||
                    e.fObject.fObjectType == FObjectType.JudgementCondition ||
                    e.fObject.fObjectType == FObjectType.JudgementExpression ||
                    e.fObject.fObjectType == FObjectType.Function
                    )
                {
                    moveToTreeOfChildFlow(e.fObject, e.fRefObject);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_ObjectModifyCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (e.fObject.fObjectType == FObjectType.Scenario)
                {
                    refreshScenario(e.fObject);
                    // --
                    foreach (FIObject fObject in ((FScenario)e.fObject).fReferenceObjectCollection)
                    {
                        if (
                            fObject.fObjectType == FObjectType.Judgement ||
                            fObject.fObjectType == FObjectType.Branch
                            )
                        {
                            refreshFlow(fObject);
                        }
                    }
                }
                else if (
                    e.fObject.fObjectType == FObjectType.SecsTrigger ||
                    e.fObject.fObjectType == FObjectType.SecsTransmitter ||
                    e.fObject.fObjectType == FObjectType.HostTrigger ||
                    e.fObject.fObjectType == FObjectType.HostTransmitter ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                    e.fObject.fObjectType == FObjectType.Judgement ||
                    e.fObject.fObjectType == FObjectType.Mapper ||
                    e.fObject.fObjectType == FObjectType.Storage ||
                    e.fObject.fObjectType == FObjectType.Callback ||
                    e.fObject.fObjectType == FObjectType.Branch ||
                    e.fObject.fObjectType == FObjectType.Comment ||
                    e.fObject.fObjectType == FObjectType.Pauser ||
                    e.fObject.fObjectType == FObjectType.EntryPoint
                    )
                {
                    refreshFlow(e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.SecsCondition ||
                    e.fObject.fObjectType == FObjectType.SecsExpression ||
                    e.fObject.fObjectType == FObjectType.SecsTransfer ||
                    e.fObject.fObjectType == FObjectType.HostCondition ||
                    e.fObject.fObjectType == FObjectType.HostExpression  ||
                    e.fObject.fObjectType == FObjectType.HostTransfer ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateAlterer ||
                    e.fObject.fObjectType == FObjectType.JudgementCondition ||
                    e.fObject.fObjectType == FObjectType.JudgementExpression ||
                    e.fObject.fObjectType == FObjectType.Function 
                    )
                {
                    refreshChildFlow(e.fObject);
                }
                else if (e.fObject.fObjectType == FObjectType.SecsDevice)
                {
                    foreach (FIObject fObject in ((FSecsDevice)e.fObject).fReferenceObjectCollection)
                    {
                        if (
                            fObject.fObjectType == FObjectType.SecsCondition ||
                            fObject.fObjectType == FObjectType.SecsTransfer 
                            )
                        {
                            refreshChildFlow(fObject);
                        }                        
                    }
                }
                else if (e.fObject.fObjectType == FObjectType.SecsSession)
                {
                    foreach (FIObject fObject in ((FSecsSession)e.fObject).fReferenceObjectCollection)
                    {
                        if (
                            fObject.fObjectType == FObjectType.SecsCondition ||
                            fObject.fObjectType == FObjectType.SecsTransfer 
                            )
                        {
                            refreshChildFlow(fObject);
                        }
                    }
                }
                else if (e.fObject.fObjectType == FObjectType.SecsMessage)
                {
                    foreach (FIObject fObject in ((FSecsMessage)e.fObject).fReferenceObjectCollection)
                    {
                        if (
                            fObject.fObjectType == FObjectType.SecsCondition ||
                            fObject.fObjectType == FObjectType.SecsTransfer 
                            )
                        {
                            refreshChildFlow(fObject);
                        }
                    }
                }
                else if (e.fObject.fObjectType == FObjectType.SecsItem)
                {
                    foreach (FIObject fObject in ((FSecsItem)e.fObject).fReferenceObjectCollection)
                    {
                        if (fObject.fObjectType == FObjectType.SecsExpression)
                        {
                            refreshChildFlow(fObject);
                            refreshChildFlow(((FSecsExpression)fObject).fAncestorSecsCondition);
                        }
                    }
                }
                else if (e.fObject.fObjectType == FObjectType.HostDevice)
                {
                    foreach (FIObject fObject in ((FHostDevice)e.fObject).fReferenceObjectCollection)
                    {
                        if (
                            fObject.fObjectType == FObjectType.HostCondition ||
                            fObject.fObjectType == FObjectType.HostTransfer
                            )
                        {
                            refreshChildFlow(fObject);
                        }
                    }
                }
                else if (e.fObject.fObjectType == FObjectType.HostSession)
                {
                    foreach (FIObject fObject in ((FHostSession)e.fObject).fReferenceObjectCollection)
                    {
                        if (
                            fObject.fObjectType == FObjectType.HostCondition ||
                            fObject.fObjectType == FObjectType.HostTransfer 
                            )
                        {
                            refreshChildFlow(fObject);
                        }
                    }
                }
                else if (e.fObject.fObjectType == FObjectType.HostMessage)
                {
                    foreach (FIObject fObject in ((FHostMessage)e.fObject).fReferenceObjectCollection)
                    {
                        if (
                            fObject.fObjectType == FObjectType.HostCondition ||
                            fObject.fObjectType == FObjectType.HostTransfer
                            )
                        {
                            refreshChildFlow(fObject);
                        }
                    }
                }
                else if (e.fObject.fObjectType == FObjectType.HostItem)
                {
                    foreach (FIObject fObject in ((FHostItem)e.fObject).fReferenceObjectCollection)
                    {
                        if (fObject.fObjectType == FObjectType.HostExpression)
                        {
                            refreshChildFlow(fObject);
                            refreshChildFlow(((FHostExpression)fObject).fAncestorHostCondition);
                        }
                    }
                }
                else if (e.fObject.fObjectType == FObjectType.Environment)
                {
                    foreach (FIObject fObject in ((FEnvironment)e.fObject).fReferenceObjectCollection)
                    {
                        if (fObject.fObjectType == FObjectType.SecsExpression)
                        {
                            refreshChildFlow(fObject);
                            refreshChildFlow(((FSecsExpression)fObject).fAncestorSecsCondition);
                        }
                        else if (fObject.fObjectType == FObjectType.HostExpression)
                        {
                            refreshChildFlow(fObject);
                            refreshChildFlow(((FHostExpression)fObject).fAncestorHostCondition);
                        }
                    }
                }
                else if (e.fObject.fObjectType == FObjectType.ScenarioGroup)
                {                    
                    changeAliasName();
                }
                else if (e.fObject.fObjectType == FObjectType.DataSet)
                {
                    foreach (FIObject fObject in ((FDataSet)e.fObject).fReferenceObjectCollection)
                    {
                        if (fObject.fObjectType == FObjectType.Mapper)
                        {
                            refreshFlow(fObject);
                        }
                        else if (fObject.fObjectType == FObjectType.JudgementCondition)
                        {
                            refreshChildFlow(fObject);
                        }
                    }
                }
                else if (e.fObject.fObjectType == FObjectType.Data)
                {
                    foreach (FIObject fObject in ((FData)e.fObject).fReferenceObjectCollection)
                    {
                        if (fObject.fObjectType == FObjectType.JudgementExpression)
                        {
                            refreshChildFlow(fObject);
                            refreshChildFlow(((FJudgementExpression)fObject).fAncestorJudgementCondition);
                        }
                    }
                }
                else if (e.fObject.fObjectType == FObjectType.Repository)
                {
                    foreach (FIObject fObject in ((FRepository)e.fObject).fReferenceObjectCollection)
                    {
                        if (fObject.fObjectType == FObjectType.Storage)
                        {
                            refreshFlow(fObject);
                        }
                        else if (fObject.fObjectType == FObjectType.JudgementCondition)
                        {
                            refreshChildFlow(fObject);
                        }
                    }
                }
                else if (e.fObject.fObjectType == FObjectType.EquipmentStateSet)
                {
                    foreach (FIObject fObject in ((FEquipmentStateSet)e.fObject).fReferenceObjectCollection)
                    {
                        if (fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                        {
                            refreshFlow(fObject);
                        }
                    }
                }
                else if (e.fObject.fObjectType == FObjectType.EquipmentState)
                {
                    foreach (FIObject fObject in ((FEquipmentState)e.fObject).fReferenceObjectCollection)
                    {
                        if (fObject.fObjectType == FObjectType.EquipmentStateAlterer)
                        {
                            refreshChildFlow(fObject);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region mnuMenu Control Event Handler

        private void mnuMenu_ToolClick(
            object sender,
            ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuSnrExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuSnrCollapse)
                {
                    procMenuCollapse();
                }
                else if (e.Tool.Key == FMenuKey.MenuSnrReplace)
                {
                    procMenuReplace();
                }
                else if (e.Tool.Key == FMenuKey.MenuSnrCut)
                {
                    procMenuCut();
                }
                else if (e.Tool.Key == FMenuKey.MenuSnrCopy)
                {
                    procMenuCopy();
                }
                else if (e.Tool.Key == FMenuKey.MenuSnrRelation)
                {
                    procMenuRelation();
                }
                else if (e.Tool.Key == FMenuKey.MenuSnrMoveUp)
                {
                    procMenuMoveUpFlow();
                }
                else if (e.Tool.Key == FMenuKey.MenuSnrMoveDown)
                {
                    procMenuMoveDownFlow();
                }
                else if (e.Tool.Key == FMenuKey.MenuSnrPasteSibling)
                {
                    if (
                       m_fActiveObject.fObjectType == FObjectType.SecsTrigger ||
                       m_fActiveObject.fObjectType == FObjectType.SecsTransmitter ||
                       m_fActiveObject.fObjectType == FObjectType.HostTrigger ||
                       m_fActiveObject.fObjectType == FObjectType.HostTransmitter ||
                       m_fActiveObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                       m_fActiveObject.fObjectType == FObjectType.Judgement ||
                       m_fActiveObject.fObjectType == FObjectType.Mapper ||
                       m_fActiveObject.fObjectType == FObjectType.Storage ||
                       m_fActiveObject.fObjectType == FObjectType.Callback ||
                       m_fActiveObject.fObjectType == FObjectType.Branch ||
                       m_fActiveObject.fObjectType == FObjectType.Comment ||
                       m_fActiveObject.fObjectType == FObjectType.Pauser
                       )
                    {
                        procMenuPasteSiblingOfFlow();
                    }
                    else
                    {
                        procMenuPasteSiblingOfChildFlow();
                    }
                }
                else if (e.Tool.Key == FMenuKey.MenuSnrPasteChild)
                {
                    if (m_fActiveObject.fObjectType == FObjectType.Scenario)
                    {
                        procMenuPasteChildOfFlow();
                    }
                    else
                    {
                        procMenuPasteChildOfChildFlow();
                    }
                }
                else if (e.Tool.Key == FMenuKey.MenuSnrRemove)
                {
                    if (
                        m_fActiveObject.fObjectType == FObjectType.SecsTrigger ||
                        m_fActiveObject.fObjectType == FObjectType.SecsTransmitter ||
                        m_fActiveObject.fObjectType == FObjectType.HostTrigger ||
                        m_fActiveObject.fObjectType == FObjectType.HostTransmitter ||
                        m_fActiveObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                        m_fActiveObject.fObjectType == FObjectType.Judgement ||
                        m_fActiveObject.fObjectType == FObjectType.Mapper ||
                        m_fActiveObject.fObjectType == FObjectType.Storage ||
                        m_fActiveObject.fObjectType == FObjectType.Callback ||
                        m_fActiveObject.fObjectType == FObjectType.Branch ||
                        m_fActiveObject.fObjectType == FObjectType.Comment ||
                        m_fActiveObject.fObjectType == FObjectType.Pauser ||
                        m_fActiveObject.fObjectType == FObjectType.EntryPoint
                        )
                    {
                        procMenuRemoveFlow();
                    }
                    else
                    {
                        procMenuRemoveChildFlow();
                    }
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeSecsTrigger ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeSecsTransmitter ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeHostTrigger ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeHostTransmitter ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeEquipmentStateSetAlterer ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeJudgement ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeMapper ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeStorage ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeCallback ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeBranch ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeComment ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforePauser ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeEntryPoint
                    )
                {
                    procMenuInsertBeforeFlow(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterSecsTrigger ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterSecsTransmitter ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterHostTrigger ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterHostTransmitter ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterEquipmentStateSetAlterer ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterJudgement ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterMapper ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterStorage ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterCallback ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterBranch ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterComment ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterPauser ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterEntryPoint
                    )
                {
                    procMenuInsertAfterFlow(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuSnrAppendSecsTrigger ||
                    e.Tool.Key == FMenuKey.MenuSnrAppendSecsTransmitter ||
                    e.Tool.Key == FMenuKey.MenuSnrAppendHostTrigger ||
                    e.Tool.Key == FMenuKey.MenuSnrAppendHostTransmitter ||
                    e.Tool.Key == FMenuKey.MenuSnrAppendEquipmentStateSetAlterer ||
                    e.Tool.Key == FMenuKey.MenuSnrAppendJudgement ||
                    e.Tool.Key == FMenuKey.MenuSnrAppendMapper ||
                    e.Tool.Key == FMenuKey.MenuSnrAppendStorage ||
                    e.Tool.Key == FMenuKey.MenuSnrAppendCallback ||
                    e.Tool.Key == FMenuKey.MenuSnrAppendBranch ||
                    e.Tool.Key == FMenuKey.MenuSnrAppendComment ||
                    e.Tool.Key == FMenuKey.MenuSnrAppendPauser ||
                    e.Tool.Key == FMenuKey.MenuSnrAppendEntryPoint
                    )
                {
                    procMenuAppendFlow(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeSecsCondition ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeSecsExpression ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeSecsTransfer ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeHostCondition ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeHostExpression ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeHostTransfer ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeEquipmentStateAlterer ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeJudgementCondition ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeJudgementExpression ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertBeforeFunction
                    )
                {
                    procMenuInsertBeforeChildFlow(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterSecsCondition ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterSecsExpression ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterSecsTransfer ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterHostCondition ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterHostExpression ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterHostTransfer ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterEquipmentStateAlterer ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterJudgementCondition ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterJudgementExpression ||
                    e.Tool.Key == FMenuKey.MenuSnrInsertAfterFunction
                    )
                {
                    procMenuInsertAfterChildFlow(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuSnrAppendSecsCondition ||
                    e.Tool.Key == FMenuKey.MenuSnrAppendSecsExpression ||
                    e.Tool.Key == FMenuKey.MenuSnrAppendSecsTransfer ||
                    e.Tool.Key == FMenuKey.MenuSnrAppendHostCondition ||
                    e.Tool.Key == FMenuKey.MenuSnrAppendHostExpression ||
                    e.Tool.Key == FMenuKey.MenuSnrAppendHostTransfer ||
                    e.Tool.Key == FMenuKey.MenuSnrAppendEquipmentStateAlterer ||
                    e.Tool.Key == FMenuKey.MenuSnrAppendJudgementCondition ||
                    e.Tool.Key == FMenuKey.MenuSnrAppendJudgementExpression ||
                    e.Tool.Key == FMenuKey.MenuSnrAppendFunction
                    )
                {
                    procMenuAppendChildFlow(e.Tool.Key);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region flcContainer Control Event Handler

        private void flcContainer_FlowContainerActivated(
            object sender,
            Nexplant.MC.Core.FaUIs.WPF.FFlowContainerActivatedEventArgs e
            )
        {
            FIObject fObject = null;

            try
            {
                fObject = (FIObject)e.fActiveFlowContainer.Tag;
                pgdProp.selectedObject = new FPropSnr(m_fSsmCore, pgdProp, (FScenario)fObject);
                // --
                m_fActiveObject = fObject;
                
                // --

                loadTreeOfFlow();
                controlMenu();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void flcContainer_FlowCtrlActivated(
            object sender,
            Nexplant.MC.Core.FaUIs.WPF.FFlowCtrlActivatedEventArgs e
            )
        {
            FIObject fObject = null;

            try
            {
                fObject = (FIObject)e.fActiveFlowCtrl.Tag;
                // --
                if (fObject.fObjectType == FObjectType.SecsTrigger)
                {
                    pgdProp.selectedObject = new FPropStr(m_fSsmCore, pgdProp, (FSecsTrigger)fObject);
                }
                else if (fObject.fObjectType == FObjectType.SecsTransmitter)
                {
                    pgdProp.selectedObject = new FPropStn(m_fSsmCore, pgdProp, (FSecsTransmitter)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostTrigger)
                {
                    pgdProp.selectedObject = new FPropHtr(m_fSsmCore, pgdProp, (FHostTrigger)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostTransmitter)
                {
                    pgdProp.selectedObject = new FPropHtn(m_fSsmCore, pgdProp, (FHostTransmitter)fObject);
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    pgdProp.selectedObject = new FPropEsa(m_fSsmCore, pgdProp, (FEquipmentStateSetAlterer)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Judgement)
                {
                    pgdProp.selectedObject = new FPropJdm(m_fSsmCore, pgdProp, (FJudgement)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Mapper)
                {
                    pgdProp.selectedObject = new FPropMap(m_fSsmCore, pgdProp, (FMapper)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Storage)
                {
                    pgdProp.selectedObject = new FPropStg(m_fSsmCore, pgdProp, (FStorage)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Callback)
                {
                    pgdProp.selectedObject = new FPropCbk(m_fSsmCore, pgdProp, (FCallback)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Branch)
                {
                    pgdProp.selectedObject = new FPropBrn(m_fSsmCore, pgdProp, (FBranch)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Comment)
                {
                    pgdProp.selectedObject = new FPropCmt(m_fSsmCore, pgdProp, (FComment)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Pauser)
                {
                    pgdProp.selectedObject = new FPropPau(m_fSsmCore, pgdProp, (FPauser)fObject);
                }
                else if (fObject.fObjectType == FObjectType.EntryPoint)
                {
                    pgdProp.selectedObject = new FPropEtp(m_fSsmCore, pgdProp, (FEntryPoint)fObject);
                }
                
                // --
                
                m_fActiveObject = fObject;
            
                // --

                loadTreeOfFlow();
                controlMenu();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void flcContainer_KeyDown(
            object sender,
            System.Windows.Input.KeyEventArgs e
            )
        {
            try
            {
                if (e.Key == System.Windows.Input.Key.Delete)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSnrRemove].SharedProps.Enabled)
                    {
                        procMenuRemoveFlow();
                    }
                }
                else if (
                    e.KeyboardDevice.IsKeyDown(System.Windows.Input.Key.LeftCtrl) ||
                    e.KeyboardDevice.IsKeyDown(System.Windows.Input.Key.RightCtrl)
                    )
                {
                    if (e.Key == System.Windows.Input.Key.X)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuSnrCut].SharedProps.Enabled)
                        {
                            procMenuCut();
                        }
                    }
                    else if (e.Key == System.Windows.Input.Key.C)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuSnrCopy].SharedProps.Enabled)
                        {
                            procMenuCopy();
                        }
                    }
                    else if (e.Key == System.Windows.Input.Key.V)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuSnrPasteSibling].SharedProps.Enabled)
                        {
                            procMenuPasteSiblingOfFlow();
                        }
                    }
                    else if (e.Key == System.Windows.Input.Key.B)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuSnrPasteChild].SharedProps.Enabled)
                        {
                            procMenuPasteChildOfChildFlow();
                        }
                    }
                    else if (e.Key == System.Windows.Input.Key.U)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuSnrMoveUp].SharedProps.Enabled)
                        {
                            procMenuMoveUpFlow();
                        }
                    }
                    else if (e.Key == System.Windows.Input.Key.D)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuSnrMoveDown].SharedProps.Enabled)
                        {
                            procMenuMoveDownFlow();
                        }
                    }
                    else if (e.Key == System.Windows.Input.Key.E)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuSnrExpand].SharedProps.Enabled)
                        {
                            procMenuExpand();
                        }
                    }
                    else if (e.Key == System.Windows.Input.Key.L)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuSnrCollapse].SharedProps.Enabled)
                        {
                            procMenuCollapse();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void flcContainer_FlowMouseMove(
            object sender,
            Core.FaUIs.WPF.FFlowMouseEventArgs e
            )
        {
            FIObject fObject = null;
            FDragDropData fDragDropData = null;

            try
            {
                if (
                    e.buttons != System.Windows.Forms.MouseButtons.Left ||
                    e.fFlowCtrl == null
                    )
                {
                    return;
                }

                // --

                fObject = (FIObject)e.fFlowCtrl.Tag;
                fDragDropData = new FDragDropData(fObject);
                // --
                flcContainer.doDragDrop(new System.Windows.DataObject(fDragDropData), System.Windows.DragDropEffects.All);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fObject = null;
                fDragDropData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void flcContainer_FlowDragOver(
            object sender,
            Core.FaUIs.WPF.FFlowDragEventArgs e
            )
        {
            FDragDropData fDragDropData = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fRefFlowCtrl = null;
            FIObject fRefObject = null;

            try
            {
                fRefFlowCtrl = e.fRefFlowCtrl;
                fDragDropData = e.data.GetData(typeof(FDragDropData).ToString(), true) as FDragDropData;
                if (fRefFlowCtrl == null || fDragDropData == null || !fDragDropData.serializableSuccess)
                {
                    if (fDragDropData != null && fDragDropData.oldRefFlowCtrl != null)
                    {
                        FCommon.resetDragOverFlowCtrl(fDragDropData.oldRefFlowCtrl);
                        fDragDropData.oldRefFlowCtrl = null;
                    }
                    m_fDragDropOldRefFlowCtrl = null;
                    // --
                    e.effect = System.Windows.DragDropEffects.None;
                    return;
                }

                // --

                if (fDragDropData.oldRefFlowCtrl != null)
                {
                    FCommon.resetDragOverFlowCtrl(fDragDropData.oldRefFlowCtrl);
                }
                // --
                if (m_fDragDropOldRefFlowCtrl != null)
                {
                    FCommon.resetDragOverFlowCtrl(m_fDragDropOldRefFlowCtrl);
                }
                // --
                FCommon.setDragOverFlowCtrl(fRefFlowCtrl);
                fDragDropData.oldRefFlowCtrl = fRefFlowCtrl;
                m_fDragDropOldRefFlowCtrl = fRefFlowCtrl;

                // --

                fRefObject = (FIObject)fRefFlowCtrl.Tag;

                // --

                if (fDragDropData.fObject != null)
                {
                    #region FObject

                    if (fRefObject.fObjectType == FObjectType.SecsTrigger)
                    {
                        #region SecsTrigger

                        if (
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                            fDragDropData.fObject.fObjectType == FObjectType.Judgement ||
                            fDragDropData.fObject.fObjectType == FObjectType.Mapper ||
                            fDragDropData.fObject.fObjectType == FObjectType.Storage ||
                            fDragDropData.fObject.fObjectType == FObjectType.Callback ||
                            fDragDropData.fObject.fObjectType == FObjectType.Branch ||
                            fDragDropData.fObject.fObjectType == FObjectType.Comment ||
                            fDragDropData.fObject.fObjectType == FObjectType.Pauser ||
                            fDragDropData.fObject.fObjectType == FObjectType.EntryPoint
                            )
                        {
                            #region Flow

                            if (((FSecsTrigger)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    ((FSecsTrigger)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    (((FSecsTrigger)fRefObject).fNextSibling == null || !((FSecsTrigger)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.effect = System.Windows.DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsDevice)
                        {
                            #region SecsDevice

                            if (((FSecsTrigger)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessage)
                        {
                            #region SecsMessage

                            if (((FSecsTrigger)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (fDragDropData.sessionUniqueId != string.Empty)
                                {
                                    e.effect = System.Windows.DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsTransmitter)
                    {
                        #region SecsTransmitter

                        if (
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                            fDragDropData.fObject.fObjectType == FObjectType.Judgement ||
                            fDragDropData.fObject.fObjectType == FObjectType.Mapper ||
                            fDragDropData.fObject.fObjectType == FObjectType.Storage ||
                            fDragDropData.fObject.fObjectType == FObjectType.Callback ||
                            fDragDropData.fObject.fObjectType == FObjectType.Branch ||
                            fDragDropData.fObject.fObjectType == FObjectType.Comment ||
                            fDragDropData.fObject.fObjectType == FObjectType.Pauser ||
                            fDragDropData.fObject.fObjectType == FObjectType.EntryPoint
                            )
                        {
                            #region Flow

                            if (((FSecsTransmitter)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    ((FSecsTransmitter)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    (((FSecsTransmitter)fRefObject).fNextSibling == null || !((FSecsTransmitter)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.effect = System.Windows.DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessage)
                        {
                            #region SecsMessage

                            if (((FSecsTransmitter)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (fDragDropData.sessionUniqueId != string.Empty)
                                {
                                    e.effect = System.Windows.DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.HostTrigger)
                    {
                        #region HostTrigger

                        if (
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                            fDragDropData.fObject.fObjectType == FObjectType.Judgement ||
                            fDragDropData.fObject.fObjectType == FObjectType.Mapper ||
                            fDragDropData.fObject.fObjectType == FObjectType.Storage ||
                            fDragDropData.fObject.fObjectType == FObjectType.Callback ||
                            fDragDropData.fObject.fObjectType == FObjectType.Branch ||
                            fDragDropData.fObject.fObjectType == FObjectType.Comment ||
                            fDragDropData.fObject.fObjectType == FObjectType.Pauser ||
                            fDragDropData.fObject.fObjectType == FObjectType.EntryPoint
                            )
                        {
                            #region Flow

                            if (((FHostTrigger)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    ((FHostTrigger)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    (((FHostTrigger)fRefObject).fNextSibling == null || !((FHostTrigger)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.effect = System.Windows.DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostDevice)
                        {
                            #region HostDevice

                            if (((FHostTrigger)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostMessage)
                        {
                            #region HostMessage

                            if (((FHostTrigger)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (fDragDropData.sessionUniqueId != string.Empty)
                                {
                                    e.effect = System.Windows.DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.HostTransmitter)
                    {
                        #region HostTransmitter

                        if (
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                            fDragDropData.fObject.fObjectType == FObjectType.Judgement ||
                            fDragDropData.fObject.fObjectType == FObjectType.Mapper ||
                            fDragDropData.fObject.fObjectType == FObjectType.Storage ||
                            fDragDropData.fObject.fObjectType == FObjectType.Callback ||
                            fDragDropData.fObject.fObjectType == FObjectType.Branch ||
                            fDragDropData.fObject.fObjectType == FObjectType.Comment ||
                            fDragDropData.fObject.fObjectType == FObjectType.Pauser ||
                            fDragDropData.fObject.fObjectType == FObjectType.EntryPoint
                            )
                        {
                            #region Flow

                            if (((FHostTransmitter)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    ((FHostTransmitter)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    (((FHostTransmitter)fRefObject).fNextSibling == null || !((FHostTransmitter)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.effect = System.Windows.DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostMessage)
                        {
                            #region HostMessage

                            if (((FHostTransmitter)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (fDragDropData.sessionUniqueId != string.Empty)
                                {
                                    e.effect = System.Windows.DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                    {
                        #region EquipmentStateSetAlterer

                        if (
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                            fDragDropData.fObject.fObjectType == FObjectType.Judgement ||
                            fDragDropData.fObject.fObjectType == FObjectType.Mapper ||
                            fDragDropData.fObject.fObjectType == FObjectType.Storage ||
                            fDragDropData.fObject.fObjectType == FObjectType.Callback ||
                            fDragDropData.fObject.fObjectType == FObjectType.Branch ||
                            fDragDropData.fObject.fObjectType == FObjectType.Comment ||
                            fDragDropData.fObject.fObjectType == FObjectType.Pauser ||
                            fDragDropData.fObject.fObjectType == FObjectType.EntryPoint
                            )
                        {
                            #region Flow

                            if (((FEquipmentStateSetAlterer)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    ((FEquipmentStateSetAlterer)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    (((FEquipmentStateSetAlterer)fRefObject).fNextSibling == null || !((FEquipmentStateSetAlterer)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.effect = System.Windows.DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSet)
                        {
                            #region EquipmentStateSet

                            if (((FEquipmentStateSetAlterer)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentState)
                        {
                            #region EquipmentState

                            if (((FEquipmentStateSetAlterer)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FEquipmentStateSetAlterer)fRefObject).fEquipmentStateSet != null &&
                                    ((FEquipmentStateSetAlterer)fRefObject).fEquipmentStateSet.Equals(((FEquipmentState)fDragDropData.fObject).fParent)
                                    )
                                {
                                    e.effect = System.Windows.DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Judgement)
                    {
                        #region Judgement

                        if (
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                            fDragDropData.fObject.fObjectType == FObjectType.Judgement ||
                            fDragDropData.fObject.fObjectType == FObjectType.Mapper ||
                            fDragDropData.fObject.fObjectType == FObjectType.Storage ||
                            fDragDropData.fObject.fObjectType == FObjectType.Callback ||
                            fDragDropData.fObject.fObjectType == FObjectType.Branch ||
                            fDragDropData.fObject.fObjectType == FObjectType.Comment ||
                            fDragDropData.fObject.fObjectType == FObjectType.Pauser ||
                            fDragDropData.fObject.fObjectType == FObjectType.EntryPoint
                            )
                        {
                            #region Flow

                            if (((FJudgement)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    ((FJudgement)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    (((FJudgement)fRefObject).fNextSibling == null || !((FJudgement)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.effect = System.Windows.DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataSet)
                        {
                            #region DataSet

                            if (((FJudgement)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Scenario)
                        {
                            #region Scenario

                            if (((FJudgement)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Mapper)
                    {
                        #region Mapper

                        if (
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                            fDragDropData.fObject.fObjectType == FObjectType.Judgement ||
                            fDragDropData.fObject.fObjectType == FObjectType.Mapper ||
                            fDragDropData.fObject.fObjectType == FObjectType.Storage ||
                            fDragDropData.fObject.fObjectType == FObjectType.Callback ||
                            fDragDropData.fObject.fObjectType == FObjectType.Branch ||
                            fDragDropData.fObject.fObjectType == FObjectType.Comment ||
                            fDragDropData.fObject.fObjectType == FObjectType.Pauser ||
                            fDragDropData.fObject.fObjectType == FObjectType.EntryPoint
                            )
                        {
                            #region Flow

                            if (((FMapper)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    ((FMapper)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    (((FMapper)fRefObject).fNextSibling == null || !((FMapper)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.effect = System.Windows.DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataSet)
                        {
                            #region DataSet

                            if (((FMapper)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Storage)
                    {
                        #region Storage

                        if (
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                            fDragDropData.fObject.fObjectType == FObjectType.Judgement ||
                            fDragDropData.fObject.fObjectType == FObjectType.Mapper ||
                            fDragDropData.fObject.fObjectType == FObjectType.Storage ||
                            fDragDropData.fObject.fObjectType == FObjectType.Callback ||
                            fDragDropData.fObject.fObjectType == FObjectType.Branch ||
                            fDragDropData.fObject.fObjectType == FObjectType.Comment ||
                            fDragDropData.fObject.fObjectType == FObjectType.Pauser ||
                            fDragDropData.fObject.fObjectType == FObjectType.EntryPoint
                            )
                        {
                            #region Flow

                            if (((FStorage)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    ((FStorage)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    (((FStorage)fRefObject).fNextSibling == null || !((FStorage)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.effect = System.Windows.DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Repository)
                        {
                            #region Repository

                            if (((FStorage)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Callback)
                    {
                        #region Callback

                        if (
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                            fDragDropData.fObject.fObjectType == FObjectType.Judgement ||
                            fDragDropData.fObject.fObjectType == FObjectType.Mapper ||
                            fDragDropData.fObject.fObjectType == FObjectType.Storage ||
                            fDragDropData.fObject.fObjectType == FObjectType.Callback ||
                            fDragDropData.fObject.fObjectType == FObjectType.Branch ||
                            fDragDropData.fObject.fObjectType == FObjectType.Comment ||
                            fDragDropData.fObject.fObjectType == FObjectType.Pauser ||
                            fDragDropData.fObject.fObjectType == FObjectType.EntryPoint
                            )
                        {
                            #region Flow

                            if (((FCallback)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    ((FCallback)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    (((FCallback)fRefObject).fNextSibling == null || !((FCallback)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.effect = System.Windows.DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.FunctionName)
                        {
                            #region FunctionName

                            if (((FCallback)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Branch)
                    {
                        #region Branch

                        if (
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                            fDragDropData.fObject.fObjectType == FObjectType.Judgement ||
                            fDragDropData.fObject.fObjectType == FObjectType.Mapper ||
                            fDragDropData.fObject.fObjectType == FObjectType.Storage ||
                            fDragDropData.fObject.fObjectType == FObjectType.Callback ||
                            fDragDropData.fObject.fObjectType == FObjectType.Branch ||
                            fDragDropData.fObject.fObjectType == FObjectType.Comment ||
                            fDragDropData.fObject.fObjectType == FObjectType.Pauser ||
                            fDragDropData.fObject.fObjectType == FObjectType.EntryPoint
                            )
                        {
                            #region Flow

                            if (((FBranch)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    ((FBranch)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    (((FBranch)fRefObject).fNextSibling == null || !((FBranch)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.effect = System.Windows.DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Scenario)
                        {
                            #region Scenario

                            if (((FBranch)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Comment)
                    {
                        #region Comment

                        if (
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                            fDragDropData.fObject.fObjectType == FObjectType.Judgement ||
                            fDragDropData.fObject.fObjectType == FObjectType.Mapper ||
                            fDragDropData.fObject.fObjectType == FObjectType.Storage ||
                            fDragDropData.fObject.fObjectType == FObjectType.Callback ||
                            fDragDropData.fObject.fObjectType == FObjectType.Branch ||
                            fDragDropData.fObject.fObjectType == FObjectType.Comment ||
                            fDragDropData.fObject.fObjectType == FObjectType.Pauser ||
                            fDragDropData.fObject.fObjectType == FObjectType.EntryPoint
                            )
                        {
                            #region Flow

                            if (((FComment)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    ((FComment)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    (((FComment)fRefObject).fNextSibling == null || !((FComment)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.effect = System.Windows.DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Pauser)
                    {
                        #region Pauser

                        if (
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                            fDragDropData.fObject.fObjectType == FObjectType.Judgement ||
                            fDragDropData.fObject.fObjectType == FObjectType.Mapper ||
                            fDragDropData.fObject.fObjectType == FObjectType.Storage ||
                            fDragDropData.fObject.fObjectType == FObjectType.Callback ||
                            fDragDropData.fObject.fObjectType == FObjectType.Branch ||
                            fDragDropData.fObject.fObjectType == FObjectType.Comment ||
                            fDragDropData.fObject.fObjectType == FObjectType.Pauser ||
                            fDragDropData.fObject.fObjectType == FObjectType.EntryPoint
                            )
                        {
                            #region Flow

                            if (((FPauser)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    ((FPauser)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    (((FPauser)fRefObject).fNextSibling == null || !((FPauser)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.effect = System.Windows.DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.EntryPoint)
                    {
                        #region EntryPoint

                        if (
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter ||
                            fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                            fDragDropData.fObject.fObjectType == FObjectType.Judgement ||
                            fDragDropData.fObject.fObjectType == FObjectType.Mapper ||
                            fDragDropData.fObject.fObjectType == FObjectType.Storage ||
                            fDragDropData.fObject.fObjectType == FObjectType.Callback ||
                            fDragDropData.fObject.fObjectType == FObjectType.Branch ||
                            fDragDropData.fObject.fObjectType == FObjectType.Comment ||
                            fDragDropData.fObject.fObjectType == FObjectType.Pauser ||
                            fDragDropData.fObject.fObjectType == FObjectType.EntryPoint
                            )
                        {
                            #region Flow

                            if (((FEntryPoint)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    ((FEntryPoint)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    (((FEntryPoint)fRefObject).fNextSibling == null || !((FEntryPoint)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.effect = System.Windows.DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }

                        #endregion
                    }

                    #endregion
                }

                // --

                FCommon.resetDragOverFlowCtrl(fRefFlowCtrl);
                e.effect = System.Windows.DragDropEffects.None;
                // --
                m_fDragDropOldRefFlowCtrl = null;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fDragDropData = null;
                fRefFlowCtrl = null;
                fRefObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void flcContainer_FlowDragDrop(
            object sender,
            Core.FaUIs.WPF.FFlowDragEventArgs e
            )
        {
            FDragDropAction fAction = FDragDropAction.Move;
            FDragDropData fDragDropData = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fRefFlowCtrl = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fFlowCtrl = null;
            FIObject fRefObject = null;
            FIObject fChildObject = null;
            FIObject fDevice = null;
            FIObject fSession = null;
            UltraTreeNode tParentNode = null;
            UltraTreeNode tChildNode = null;
            string uniqueId = string.Empty;

            try
            {
                fRefFlowCtrl = e.fRefFlowCtrl;
                fDragDropData = e.data.GetData(typeof(FDragDropData).ToString(), true) as FDragDropData;
                if (fRefFlowCtrl == null || fDragDropData == null)
                {
                    if (fDragDropData != null && fDragDropData.oldRefFlowCtrl != null)
                    {
                        FCommon.resetDragOverFlowCtrl(fDragDropData.oldRefFlowCtrl);
                        fDragDropData.oldRefFlowCtrl = null;
                    }
                    m_fDragDropOldRefFlowCtrl = null;
                    return;
                }

                // --

                if (fDragDropData.oldRefFlowCtrl != null)
                {
                    FCommon.resetDragOverFlowCtrl(fDragDropData.oldRefFlowCtrl);
                }
                // --
                if (m_fDragDropOldRefFlowCtrl != null)
                {
                    FCommon.resetDragOverFlowCtrl(m_fDragDropOldRefFlowCtrl);
                    m_fDragDropOldRefFlowCtrl = null;
                }

                // --

                fRefObject = (FIObject)fRefFlowCtrl.Tag;

                // --

                if (fDragDropData.fObject != null)
                {
                    #region FObject

                    if (fRefObject.fObjectType == FObjectType.SecsTrigger)
                    {
                        #region SecsTrigger

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger)
                        {
                            #region SecsTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter)
                        {
                            #region SecsTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTrigger)
                        {
                            #region HostTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter)
                        {
                            #region HostTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                        {
                            #region EquipmentStateSetAlterer

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Judgement)
                        {
                            #region Judgement

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FJudgement)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FJudgement)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Mapper)
                        {
                            #region Mapper

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FMapper)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FMapper)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Storage)
                        {
                            #region Storage

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FStorage)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FStorage)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Callback)
                        {
                            #region Callback

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FCallback)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FCallback)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Branch)
                        {
                            #region Branch

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FBranch)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FBranch)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Comment)
                        {
                            #region Comment

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FComment)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FComment)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Pauser)
                        {
                            #region Pauser

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FPauser)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FPauser)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EntryPoint)
                        {
                            #region EntryPoint

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEntryPoint)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEntryPoint)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsDevice)
                        {
                            #region SecsDevice

                            if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                fChildObject = ((FSecsTrigger)fRefObject).appendChildSecsCondition(new FSecsCondition(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                ((FSecsCondition)fChildObject).fConditionMode = FConditionMode.Connection;
                                ((FSecsCondition)fChildObject).setDevice((FSecsDevice)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessage)
                        {
                            #region SecsMessage

                            if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                fSession = this.m_fSsmCore.fSsmFileInfo.fSecsDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FSecsSession)fSession).fParent;
                                // --
                                fChildObject = ((FSecsTrigger)fRefObject).appendChildSecsCondition(new FSecsCondition(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                ((FSecsCondition)fChildObject).fConditionMode = FConditionMode.Expression;
                                ((FSecsCondition)fChildObject).setMessage((FSecsDevice)fDevice, (FSecsSession)fSession, (FSecsMessage)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsTransmitter)
                    {
                        #region SecsTransmitter

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger)
                        {
                            #region SecsTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter)
                        {
                            #region SecsTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTrigger)
                        {
                            #region HostTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter)
                        {
                            #region HostTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                        {
                            #region EquipmentStateSetAlterer

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Judgement)
                        {
                            #region Judgement

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FJudgement)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FJudgement)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Mapper)
                        {
                            #region Mapper

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FMapper)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FMapper)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Storage)
                        {
                            #region Storage

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FStorage)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FStorage)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Callback)
                        {
                            #region Callback

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FCallback)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FCallback)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Branch)
                        {
                            #region Branch

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FBranch)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FBranch)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Comment)
                        {
                            #region Comment

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FComment)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FComment)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Pauser)
                        {
                            #region Pauser

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FPauser)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FPauser)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EntryPoint)
                        {
                            #region EntryPoint

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEntryPoint)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEntryPoint)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FSecsTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessage)
                        {
                            #region SecsMessage

                            if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                fSession = this.m_fSsmCore.fSsmFileInfo.fSecsDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FSecsSession)fSession).fParent;
                                // --
                                fChildObject = ((FSecsTransmitter)fRefObject).appendChildSecsTransfer(new FSecsTransfer(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                ((FSecsTransfer)fChildObject).setMessage((FSecsDevice)fDevice, (FSecsSession)fSession, (FSecsMessage)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.HostTrigger)
                    {
                        #region HostTrigger

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger)
                        {
                            #region SecsTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter)
                        {
                            #region SecsTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTrigger)
                        {
                            #region HostTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter)
                        {
                            #region HostTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                        {
                            #region EquipmentStateSetAlterer

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Judgement)
                        {
                            #region Judgement

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FJudgement)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FJudgement)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Mapper)
                        {
                            #region Mapper

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FMapper)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FMapper)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Storage)
                        {
                            #region Storage

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FStorage)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FStorage)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Callback)
                        {
                            #region Callback

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FCallback)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FCallback)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Branch)
                        {
                            #region Branch

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FBranch)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FBranch)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Comment)
                        {
                            #region Comment

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FComment)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FComment)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Pauser)
                        {
                            #region Pauser

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FPauser)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FPauser)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EntryPoint)
                        {
                            #region EntryPoint

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEntryPoint)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEntryPoint)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostDevice)
                        {
                            #region HostDevice

                            if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                fChildObject = ((FHostTrigger)fRefObject).appendChildHostCondition(new FHostCondition(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                ((FHostCondition)fChildObject).fConditionMode = FConditionMode.Connection;
                                ((FHostCondition)fChildObject).setDevice((FHostDevice)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostMessage)
                        {
                            #region HostMessage

                            if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                fSession = this.m_fSsmCore.fSsmFileInfo.fSecsDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FHostSession)fSession).fParent;
                                // --
                                fChildObject = ((FHostTrigger)fRefObject).appendChildHostCondition(new FHostCondition(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                ((FHostCondition)fChildObject).fConditionMode = FConditionMode.Expression;
                                ((FHostCondition)fChildObject).setMessage((FHostDevice)fDevice, (FHostSession)fSession, (FHostMessage)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.HostTransmitter)
                    {
                        #region HostTransmitter

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger)
                        {
                            #region SecsTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter)
                        {
                            #region SecsTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTrigger)
                        {
                            #region HostTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter)
                        {
                            #region HostTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                        {
                            #region EquipmentStateSetAlterer

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Judgement)
                        {
                            #region Judgement

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FJudgement)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FJudgement)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Mapper)
                        {
                            #region Mapper

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FMapper)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FMapper)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Storage)
                        {
                            #region Storage

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FStorage)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FStorage)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Callback)
                        {
                            #region Callback

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FCallback)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FCallback)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Branch)
                        {
                            #region Branch

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FBranch)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FBranch)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Comment)
                        {
                            #region Comment

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FComment)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FComment)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Pauser)
                        {
                            #region Pauser

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FPauser)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FPauser)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EntryPoint)
                        {
                            #region EntryPoint

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEntryPoint)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEntryPoint)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostMessage)
                        {
                            #region HostMessage

                            if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                fSession = this.m_fSsmCore.fSsmFileInfo.fSecsDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FHostSession)fSession).fParent;
                                // --
                                fChildObject = ((FHostTransmitter)fRefObject).appendChildHostTransfer(new FHostTransfer(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                ((FHostTransfer)fChildObject).setMessage((FHostDevice)fDevice, (FHostSession)fSession, (FHostMessage)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                    {
                        #region EquipmentStateSetAlterer

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger)
                        {
                            #region SecsTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEquipmentStateSetAlterer)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter)
                        {
                            #region SecsTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEquipmentStateSetAlterer)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTrigger)
                        {
                            #region HostTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEquipmentStateSetAlterer)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter)
                        {
                            #region HostTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEquipmentStateSetAlterer)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                        {
                            #region EquipmentStateSetAlterer

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEquipmentStateSetAlterer)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Judgement)
                        {
                            #region Judgement

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FJudgement)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FJudgement)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEquipmentStateSetAlterer)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Mapper)
                        {
                            #region Mapper

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FMapper)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FMapper)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEquipmentStateSetAlterer)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Storage)
                        {
                            #region Storage

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FStorage)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FStorage)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEquipmentStateSetAlterer)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Callback)
                        {
                            #region Callback

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FCallback)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FCallback)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEquipmentStateSetAlterer)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Branch)
                        {
                            #region Branch

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FBranch)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FBranch)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEquipmentStateSetAlterer)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Comment)
                        {
                            #region Comment

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FComment)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FComment)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEquipmentStateSetAlterer)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Pauser)
                        {
                            #region Pauser

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FPauser)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FPauser)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEquipmentStateSetAlterer)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EntryPoint)
                        {
                            #region EntryPoint

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEntryPoint)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEntryPoint)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEquipmentStateSetAlterer)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSet)
                        {
                            #region EquipmentStateSet

                            if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEquipmentStateSetAlterer)fRefObject).setEquipmentStateSet((FEquipmentStateSet)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentState)
                        {
                            #region EquipmentState

                            if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                fChildObject = ((FEquipmentStateSetAlterer)fRefObject).appendChildEquipmentStateAlterer(new FEquipmentStateAlterer(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                ((FEquipmentStateAlterer)fChildObject).setEquipmentState((FEquipmentState)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Judgement)
                    {
                        #region Judgement

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger)
                        {
                            #region SecsTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FJudgement)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter)
                        {
                            #region SecsTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FJudgement)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTrigger)
                        {
                            #region HostTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FJudgement)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter)
                        {
                            #region HostTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FJudgement)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                        {
                            #region EquipmentStateSetAlterer

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FJudgement)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Judgement)
                        {
                            #region Judgement

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FJudgement)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FJudgement)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FJudgement)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Mapper)
                        {
                            #region Mapper

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FMapper)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FMapper)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FJudgement)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Storage)
                        {
                            #region Storage

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FStorage)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FStorage)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FJudgement)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Callback)
                        {
                            #region Callback

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FCallback)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FCallback)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FJudgement)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Branch)
                        {
                            #region Branch

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FBranch)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FBranch)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FJudgement)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Comment)
                        {
                            #region Comment

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FComment)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FComment)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FJudgement)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Pauser)
                        {
                            #region Pauser

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FPauser)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FPauser)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FJudgement)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EntryPoint)
                        {
                            #region EntryPoint

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEntryPoint)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEntryPoint)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FJudgement)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataSet)
                        {
                            #region DataSet

                            if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                fChildObject = ((FJudgement)fRefObject).appendChildJudgementCondition(new FJudgementCondition(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                ((FJudgementCondition)fChildObject).setDataSet((FDataSet)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Scenario)
                        {
                            #region Scenario

                            if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FJudgement)fRefObject).usedBranch = true;
                                ((FJudgement)fRefObject).setLocation((FScenario)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Mapper)
                    {
                        #region Mapper

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger)
                        {
                            #region SecsTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FMapper)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter)
                        {
                            #region SecsTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FMapper)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTrigger)
                        {
                            #region HostTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FMapper)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter)
                        {
                            #region HostTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FMapper)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                        {
                            #region EquipmentStateSetAlterer

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FMapper)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Judgement)
                        {
                            #region Judgement

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FJudgement)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FJudgement)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FMapper)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Mapper)
                        {
                            #region Mapper

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FMapper)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FMapper)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FMapper)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Storage)
                        {
                            #region Storage

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FStorage)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FStorage)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FMapper)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Callback)
                        {
                            #region Callback

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FCallback)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FCallback)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FMapper)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Branch)
                        {
                            #region Branch

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FBranch)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FBranch)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FMapper)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Comment)
                        {
                            #region Comment

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FComment)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FComment)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FMapper)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Pauser)
                        {
                            #region Pauser

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FPauser)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FPauser)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FMapper)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EntryPoint)
                        {
                            #region EntryPoint

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEntryPoint)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEntryPoint)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FMapper)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataSet)
                        {
                            #region DataSet

                            if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FMapper)fRefObject).setDataSet((FDataSet)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Storage)
                    {
                        #region Storage

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger)
                        {
                            #region SecsTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FStorage)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter)
                        {
                            #region SecsTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FStorage)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTrigger)
                        {
                            #region HostTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FStorage)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter)
                        {
                            #region HostTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FStorage)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                        {
                            #region EquipmentStateSetAlterer

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FStorage)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Judgement)
                        {
                            #region Judgement

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FJudgement)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FJudgement)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FStorage)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Mapper)
                        {
                            #region Mapper

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FMapper)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FMapper)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FStorage)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Storage)
                        {
                            #region Storage

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FStorage)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FStorage)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FStorage)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Callback)
                        {
                            #region Callback

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FCallback)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FCallback)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FStorage)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Branch)
                        {
                            #region Branch

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FBranch)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FBranch)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FStorage)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Comment)
                        {
                            #region Comment

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FComment)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FComment)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FStorage)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Pauser)
                        {
                            #region Pauser

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FPauser)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FPauser)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FStorage)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EntryPoint)
                        {
                            #region EntryPoint

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEntryPoint)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEntryPoint)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FStorage)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Repository)
                        {
                            #region Repository

                            if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FStorage)fRefObject).setRepository((FRepository)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Callback)
                    {
                        #region Callback

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger)
                        {
                            #region SecsTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FCallback)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter)
                        {
                            #region SecsTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FCallback)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTrigger)
                        {
                            #region HostTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FCallback)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter)
                        {
                            #region HostTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FCallback)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                        {
                            #region EquipmentStateSetAlterer

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FCallback)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Judgement)
                        {
                            #region Judgement

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FJudgement)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FJudgement)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FCallback)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Mapper)
                        {
                            #region Mapper

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FMapper)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FMapper)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FCallback)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Storage)
                        {
                            #region Storage

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FStorage)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FStorage)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FCallback)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Callback)
                        {
                            #region Callback

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FCallback)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FCallback)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FCallback)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Branch)
                        {
                            #region Branch

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FBranch)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FBranch)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FCallback)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Comment)
                        {
                            #region Comment

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FComment)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FComment)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FCallback)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Pauser)
                        {
                            #region Pauser

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FPauser)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FPauser)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FCallback)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EntryPoint)
                        {
                            #region EntryPoint

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEntryPoint)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEntryPoint)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FCallback)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.FunctionName)
                        {
                            #region FunctionName

                            if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                fChildObject = ((FCallback)fRefObject).appendChildFunction(new FFunction(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                ((FFunction)fChildObject).functionName = ((FFunctionName)fDragDropData.fObject).name;
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Branch)
                    {
                        #region Branch

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger)
                        {
                            #region SecsTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FBranch)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter)
                        {
                            #region SecsTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FBranch)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTrigger)
                        {
                            #region HostTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FBranch)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter)
                        {
                            #region HostTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FBranch)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                        {
                            #region EquipmentStateSetAlterer

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FBranch)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Judgement)
                        {
                            #region Judgement

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FJudgement)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FJudgement)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FBranch)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Mapper)
                        {
                            #region Mapper

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FMapper)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FMapper)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FBranch)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Storage)
                        {
                            #region Storage

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FStorage)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FStorage)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FBranch)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Callback)
                        {
                            #region Callback

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FCallback)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FCallback)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FBranch)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Branch)
                        {
                            #region Branch

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FBranch)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FBranch)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FBranch)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Comment)
                        {
                            #region Comment

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FComment)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FComment)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FBranch)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Pauser)
                        {
                            #region Pauser

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FPauser)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FPauser)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FBranch)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EntryPoint)
                        {
                            #region EntryPoint

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEntryPoint)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEntryPoint)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FBranch)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Scenario)
                        {
                            #region Scenario

                            if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FBranch)fRefObject).setLocation((FScenario)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Comment)
                    {
                        #region Comment

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger)
                        {
                            #region SecsTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FComment)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter)
                        {
                            #region SecsTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FComment)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTrigger)
                        {
                            #region HostTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FComment)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter)
                        {
                            #region HostTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FComment)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                        {
                            #region EquipmentStateSetAlterer

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FComment)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Judgement)
                        {
                            #region Judgement

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FJudgement)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FJudgement)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FComment)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Mapper)
                        {
                            #region Mapper

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FMapper)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FMapper)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FComment)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Storage)
                        {
                            #region Storage

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FStorage)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FStorage)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FComment)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Callback)
                        {
                            #region Callback

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FCallback)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FCallback)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FComment)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Branch)
                        {
                            #region Branch

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FBranch)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FBranch)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FComment)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Comment)
                        {
                            #region Comment

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FComment)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FComment)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FComment)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Pauser)
                        {
                            #region Pauser

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FPauser)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FPauser)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FComment)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EntryPoint)
                        {
                            #region EntryPoint

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEntryPoint)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEntryPoint)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FComment)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Pauser)
                    {
                        #region Pauser

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger)
                        {
                            #region SecsTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FPauser)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter)
                        {
                            #region SecsTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FPauser)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTrigger)
                        {
                            #region HostTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FPauser)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter)
                        {
                            #region HostTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FPauser)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                        {
                            #region EquipmentStateSetAlterer

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FPauser)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Judgement)
                        {
                            #region Judgement

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FJudgement)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FJudgement)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FPauser)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Mapper)
                        {
                            #region Mapper

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FMapper)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FMapper)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FPauser)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Storage)
                        {
                            #region Storage

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FStorage)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FStorage)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FPauser)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Callback)
                        {
                            #region Callback

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FCallback)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FCallback)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FPauser)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Branch)
                        {
                            #region Branch

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FBranch)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FBranch)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FPauser)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Comment)
                        {
                            #region Comment

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FComment)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FComment)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FPauser)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Pauser)
                        {
                            #region Pauser

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FPauser)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FPauser)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FPauser)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EntryPoint)
                        {
                            #region EntryPoint

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEntryPoint)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEntryPoint)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FPauser)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.EntryPoint)
                    {
                        #region EntryPoint

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger)
                        {
                            #region SecsTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEntryPoint)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter)
                        {
                            #region SecsTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FSecsTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEntryPoint)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTrigger)
                        {
                            #region HostTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEntryPoint)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter)
                        {
                            #region HostTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FHostTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEntryPoint)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                        {
                            #region EquipmentStateSetAlterer

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEquipmentStateSetAlterer)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEntryPoint)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Judgement)
                        {
                            #region Judgement

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FJudgement)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FJudgement)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEntryPoint)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Mapper)
                        {
                            #region Mapper

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FMapper)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FMapper)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEntryPoint)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Storage)
                        {
                            #region Storage

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FStorage)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FStorage)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEntryPoint)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Callback)
                        {
                            #region Callback

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FCallback)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FCallback)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEntryPoint)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Branch)
                        {
                            #region Branch

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FBranch)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FBranch)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEntryPoint)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Comment)
                        {
                            #region Comment

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FComment)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FComment)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEntryPoint)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Pauser)
                        {
                            #region Pauser

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FPauser)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FPauser)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEntryPoint)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EntryPoint)
                        {
                            #region EntryPoint

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FEntryPoint)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FEntryPoint)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEntryPoint)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else
                    {
                        return;
                    }

                    #endregion
                }
                else
                {
                    return;
                }

                // --

                if (fAction == FDragDropAction.Move || fAction == FDragDropAction.Copy)
                {
                    #region Move or Copy

                    uniqueId = fDragDropData.fObject.uniqueIdToString;

                    // --

                    fFlowCtrl = flcContainer.getFlowCtrl(uniqueId);
                    if (fFlowCtrl != null)
                    {
                        flcContainer.removeFlowCtrl(fFlowCtrl);
                    }

                    // --

                    if (fDragDropData.fObject.fObjectType == FObjectType.SecsTrigger)
                    {
                        fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FSecsTriggerFlow(uniqueId);
                    }
                    else if (fDragDropData.fObject.fObjectType == FObjectType.SecsTransmitter)
                    {
                        fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FSecsTransmitterFlow(uniqueId);
                    }
                    else if (fDragDropData.fObject.fObjectType == FObjectType.HostTrigger)
                    {
                        fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FHostTriggerFlow(uniqueId);
                    }
                    else if (fDragDropData.fObject.fObjectType == FObjectType.HostTransmitter)
                    {
                        fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FHostTransmitterFlow(uniqueId);
                    }
                    else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                    {
                        fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FEquipmentStateSetAltererFlow(uniqueId);
                    }
                    else if (fDragDropData.fObject.fObjectType == FObjectType.Judgement)
                    {
                        fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FJudgementFlow(uniqueId);
                    }
                    else if (fDragDropData.fObject.fObjectType == FObjectType.Mapper)
                    {
                        fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FMapperFlow(uniqueId);
                    }
                    else if (fDragDropData.fObject.fObjectType == FObjectType.Storage)
                    {
                        fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FStorageFlow(uniqueId);
                    }
                    else if (fDragDropData.fObject.fObjectType == FObjectType.Callback)
                    {
                        fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FCallbackFlow(uniqueId);
                    }
                    else if (fDragDropData.fObject.fObjectType == FObjectType.Branch)
                    {
                        fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FBranchFlow(uniqueId);
                    }
                    else if (fDragDropData.fObject.fObjectType == FObjectType.Comment)
                    {
                        fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FCommentFlow(uniqueId);
                    }
                    else if (fDragDropData.fObject.fObjectType == FObjectType.Pauser)
                    {
                        fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FPauserFlow(uniqueId);
                    }
                    else if (fDragDropData.fObject.fObjectType == FObjectType.EntryPoint)
                    {
                        fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FEntryPointFlow(uniqueId);
                    }
                    else
                    {
                        fFlowCtrl = null;
                    }

                    // --

                    if (fFlowCtrl != null)
                    {
                        flcContainer.insertAfterFlowCtrl(fFlowCtrl, fRefFlowCtrl);
                        FCommon.refreshFlowCtrlOfObject(fDragDropData.fObject, fFlowCtrl, tvwFlow);
                        fFlowCtrl.Tag = fDragDropData.fObject;
                        // --
                        flcContainer.activateFlowCtrl(fFlowCtrl);
                    }

                    #endregion
                }
                else if (fAction == FDragDropAction.Set)
                {
                    #region Set

                    if (
                        (fRefObject.fObjectType == FObjectType.EquipmentStateSetAlterer && fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSet) ||
                        (fRefObject.fObjectType == FObjectType.Judgement && fDragDropData.fObject.fObjectType == FObjectType.Scenario) ||
                        fRefObject.fObjectType == FObjectType.Mapper ||
                        fRefObject.fObjectType == FObjectType.Storage ||
                        fRefObject.fObjectType == FObjectType.Branch
                        )
                    {
                        fRefFlowCtrl = flcContainer.getFlowCtrl(fRefObject.uniqueIdToString);
                        if (fRefFlowCtrl != null)
                        {
                            flcContainer.activateFlowCtrl(fRefFlowCtrl);
                        }
                    }
                    else if (
                        fRefObject.fObjectType == FObjectType.SecsTrigger ||
                        fRefObject.fObjectType == FObjectType.SecsTransmitter ||
                        fRefObject.fObjectType == FObjectType.HostTrigger ||
                        fRefObject.fObjectType == FObjectType.HostTransmitter ||
                        (fRefObject.fObjectType == FObjectType.EquipmentStateSetAlterer && fDragDropData.fObject.fObjectType == FObjectType.EquipmentState) ||
                        (fRefObject.fObjectType == FObjectType.Judgement && fDragDropData.fObject.fObjectType == FObjectType.DataSet) ||
                        fRefObject.fObjectType == FObjectType.Callback
                        )
                    {
                        fRefFlowCtrl = flcContainer.getFlowCtrl(fRefObject.uniqueIdToString);
                        if (fRefFlowCtrl != null)
                        {
                            flcContainer.activateFlowCtrl(fRefFlowCtrl);
                        }
                        // --
                        tvwFlow.beginUpdate();
                        tParentNode = tvwFlow.GetNodeByKey(fRefObject.uniqueIdToString);
                        if (tParentNode != null)
                        {
                            tChildNode = tvwFlow.GetNodeByKey(fChildObject.uniqueIdToString);
                            if (tChildNode == null)
                            {
                                tChildNode = new UltraTreeNode(fChildObject.uniqueIdToString);
                                tChildNode.Tag = fChildObject;
                                FCommon.refreshTreeNodeOfObject(fChildObject, tvwFlow, tChildNode);
                                // --
                                tParentNode.Nodes.Add(tChildNode);
                            }
                            tvwFlow.SelectedNodes.Clear();
                            tvwFlow.ActiveNode = tChildNode;
                        }
                        tvwFlow.endUpdate();
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fDragDropData = null;
                fRefFlowCtrl = null;
                fFlowCtrl = null;
                fRefObject = null;
                fChildObject = null;
                fDevice = null;
                fSession = null;
                tParentNode = null;
                tChildNode = null;
            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

        #region tvwFlow Control Event Handler

        private void tvwFlow_AfterExpand(
            object sender,
            NodeEventArgs e
            )
        {
            try
            {
                tvwFlow.beginUpdate();

                // --

                foreach (UltraTreeNode tNode in e.TreeNode.Nodes)
                {
                    if (tNode.Nodes.Count > 0)
                    {
                        continue;
                    }
                    loadTreeOfChildFlow(tNode);
                }

                // --

                tvwFlow.endUpdate();
            }
            catch (Exception ex)
            {
                tvwFlow.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwFlow_AfterActivate(
            object sender,
            NodeEventArgs e
            )
        {
            FIObject fObject = null;

            try
            {
                if (tvwFlow.ActiveNode == null)
                {
                    return;
                }

                // --

                fObject = (FIObject)tvwFlow.ActiveNode.Tag;
                // --
                if (fObject.fObjectType == FObjectType.SecsTrigger)
                {
                    pgdProp.selectedObject = new FPropStr(m_fSsmCore, pgdProp, (FSecsTrigger)fObject);
                }
                else if (fObject.fObjectType == FObjectType.SecsCondition)
                {
                    pgdProp.selectedObject = new FPropScn(m_fSsmCore, pgdProp, (FSecsCondition)fObject);
                }
                else if (fObject.fObjectType == FObjectType.SecsExpression)
                {
                    pgdProp.selectedObject = new FPropSep(m_fSsmCore, pgdProp, (FSecsExpression)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.SecsTransmitter)
                {
                    pgdProp.selectedObject = new FPropStn(m_fSsmCore, pgdProp, (FSecsTransmitter)fObject);
                }
                else if (fObject.fObjectType == FObjectType.SecsTransfer)
                {
                    pgdProp.selectedObject = new FPropStf(m_fSsmCore, pgdProp, (FSecsTransfer)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostTrigger)
                {
                    pgdProp.selectedObject = new FPropHtr(m_fSsmCore, pgdProp, (FHostTrigger)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostCondition)
                {
                    pgdProp.selectedObject = new FPropHcn(m_fSsmCore, pgdProp, (FHostCondition)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostExpression)
                {
                    pgdProp.selectedObject = new FPropHep(m_fSsmCore, pgdProp, (FHostExpression)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostTransmitter)
                {
                    pgdProp.selectedObject = new FPropHtn(m_fSsmCore, pgdProp, (FHostTransmitter)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostTransfer)
                {
                    pgdProp.selectedObject = new FPropHtf(m_fSsmCore, pgdProp, (FHostTransfer)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    pgdProp.selectedObject = new FPropEsa(m_fSsmCore, pgdProp, (FEquipmentStateSetAlterer)fObject);
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateAlterer)
                {
                    pgdProp.selectedObject = new FPropEat(m_fSsmCore, pgdProp, (FEquipmentStateAlterer)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Judgement)
                {
                    pgdProp.selectedObject = new FPropJdm(m_fSsmCore, pgdProp, (FJudgement)fObject);
                }
                else if (fObject.fObjectType == FObjectType.JudgementCondition)
                {
                    pgdProp.selectedObject = new FPropJcn(m_fSsmCore, pgdProp, (FJudgementCondition)fObject);
                }
                else if (fObject.fObjectType == FObjectType.JudgementExpression)
                {
                    pgdProp.selectedObject = new FPropJep(m_fSsmCore, pgdProp, (FJudgementExpression)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Mapper)
                {
                    pgdProp.selectedObject = new FPropMap(m_fSsmCore, pgdProp, (FMapper)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Storage)
                {
                    pgdProp.selectedObject = new FPropStg(m_fSsmCore, pgdProp, (FStorage)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Callback)
                {
                    pgdProp.selectedObject = new FPropCbk(m_fSsmCore, pgdProp, (FCallback)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Function)
                {
                    pgdProp.selectedObject = new FPropFun(m_fSsmCore, pgdProp, (FFunction)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Branch)
                {
                    pgdProp.selectedObject = new FPropBrn(m_fSsmCore, pgdProp, (FBranch)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Comment)
                {
                    pgdProp.selectedObject = new FPropCmt(m_fSsmCore, pgdProp, (FComment)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Pauser)
                {
                    pgdProp.selectedObject = new FPropPau(m_fSsmCore, pgdProp, (FPauser)fObject);
                }
                // --
                m_fActiveObject = fObject;

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwFlow_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSnrRemove].SharedProps.Enabled == true)
                    {
                        procMenuRemoveChildFlow();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.X)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSnrCut].SharedProps.Enabled == true)
                    {
                        procMenuCut();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.C)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSnrCopy].SharedProps.Enabled == true)
                    {
                        procMenuCopy();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSnrPasteSibling].SharedProps.Enabled == true)
                    {
                        if (
                            m_fActiveObject.fObjectType == FObjectType.SecsTrigger ||
                            m_fActiveObject.fObjectType == FObjectType.SecsTransmitter ||
                            m_fActiveObject.fObjectType == FObjectType.HostTrigger ||
                            m_fActiveObject.fObjectType == FObjectType.HostTransmitter ||
                            m_fActiveObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                            m_fActiveObject.fObjectType == FObjectType.Judgement ||
                            m_fActiveObject.fObjectType == FObjectType.Mapper ||
                            m_fActiveObject.fObjectType == FObjectType.Storage ||
                            m_fActiveObject.fObjectType == FObjectType.Callback ||
                            m_fActiveObject.fObjectType == FObjectType.Branch ||
                            m_fActiveObject.fObjectType == FObjectType.Comment ||
                            m_fActiveObject.fObjectType == FObjectType.Pauser
                            )
                        {
                            procMenuPasteSiblingOfFlow();
                        }
                        else
                        {
                            procMenuPasteSiblingOfChildFlow();
                        }
                    }
                }
                else if (e.Control && e.KeyCode == Keys.B)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSnrPasteChild].SharedProps.Enabled == true)
                    {
                        procMenuPasteChildOfChildFlow();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.U)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSnrMoveUp].SharedProps.Enabled == true)
                    {                        
                        procMenuMoveUpFlow();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.D)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSnrMoveDown].SharedProps.Enabled == true)
                    {
                        procMenuMoveDownFlow();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.E)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSnrExpand].SharedProps.Enabled == true)
                    {
                        procMenuExpand();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.L)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSnrCollapse].SharedProps.Enabled == true)
                    {
                        procMenuCollapse();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.R)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSnrRelation].SharedProps.Enabled == true)
                    {
                        procMenuRelation();
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwFlow_Enter(
            object sender, 
            EventArgs e
            )
        {
            FIObject fObject = null;

            try
            {
                if (tvwFlow.ActiveNode == null)
                {
                    return;
                }

                // --

                fObject = (FIObject)tvwFlow.ActiveNode.Tag;
                // --
                if (fObject.fObjectType == FObjectType.SecsTrigger)
                {
                    pgdProp.selectedObject = new FPropStr(m_fSsmCore, pgdProp, (FSecsTrigger)fObject);
                }
                else if (fObject.fObjectType == FObjectType.SecsCondition)
                {
                    pgdProp.selectedObject = new FPropScn(m_fSsmCore, pgdProp, (FSecsCondition)fObject);
                }
                else if (fObject.fObjectType == FObjectType.SecsExpression)
                {
                    pgdProp.selectedObject = new FPropSep(m_fSsmCore, pgdProp, (FSecsExpression)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.SecsTransmitter)
                {
                    pgdProp.selectedObject = new FPropStn(m_fSsmCore, pgdProp, (FSecsTransmitter)fObject);
                }
                else if (fObject.fObjectType == FObjectType.SecsTransfer)
                {
                    pgdProp.selectedObject = new FPropStf(m_fSsmCore, pgdProp, (FSecsTransfer)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostTrigger)
                {
                    pgdProp.selectedObject = new FPropHtr(m_fSsmCore, pgdProp, (FHostTrigger)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostCondition)
                {
                    pgdProp.selectedObject = new FPropHcn(m_fSsmCore, pgdProp, (FHostCondition)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostExpression)
                {
                    pgdProp.selectedObject = new FPropHep(m_fSsmCore, pgdProp, (FHostExpression)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostTransmitter)
                {
                    pgdProp.selectedObject = new FPropHtn(m_fSsmCore, pgdProp, (FHostTransmitter)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostTransfer)
                {
                    pgdProp.selectedObject = new FPropHtf(m_fSsmCore, pgdProp, (FHostTransfer)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    pgdProp.selectedObject = new FPropEsa(m_fSsmCore, pgdProp, (FEquipmentStateSetAlterer)fObject);
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateAlterer)
                {
                    pgdProp.selectedObject = new FPropEat(m_fSsmCore, pgdProp, (FEquipmentStateAlterer)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Judgement)
                {
                    pgdProp.selectedObject = new FPropJdm(m_fSsmCore, pgdProp, (FJudgement)fObject);
                }
                else if (fObject.fObjectType == FObjectType.JudgementCondition)
                {
                    pgdProp.selectedObject = new FPropJcn(m_fSsmCore, pgdProp, (FJudgementCondition)fObject);
                }
                else if (fObject.fObjectType == FObjectType.JudgementExpression)
                {
                    pgdProp.selectedObject = new FPropJep(m_fSsmCore, pgdProp, (FJudgementExpression)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Mapper)
                {
                    pgdProp.selectedObject = new FPropMap(m_fSsmCore, pgdProp, (FMapper)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Storage)
                {
                    pgdProp.selectedObject = new FPropStg(m_fSsmCore, pgdProp, (FStorage)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Callback)
                {
                    pgdProp.selectedObject = new FPropCbk(m_fSsmCore, pgdProp, (FCallback)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Function)
                {
                    pgdProp.selectedObject = new FPropFun(m_fSsmCore, pgdProp, (FFunction)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Branch)
                {
                    pgdProp.selectedObject = new FPropBrn(m_fSsmCore, pgdProp, (FBranch)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Comment)
                {
                    pgdProp.selectedObject = new FPropCmt(m_fSsmCore, pgdProp, (FComment)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Pauser)
                {
                    pgdProp.selectedObject = new FPropPau(m_fSsmCore, pgdProp, (FPauser)fObject);
                }
                // --
                m_fActiveObject = fObject;

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwFlow_MouseMove(
            object sender,
            MouseEventArgs e
            )
        {
            UltraTreeNode tNode = null;
            FIObject fObject = null;
            FDragDropData fDragDropData = null;

            try
            {
                if (e.Button != System.Windows.Forms.MouseButtons.Left)
                {
                    return;
                }

                // --

                tNode = tvwFlow.GetNodeFromPoint(e.X, e.Y);
                if (tNode == null)
                {
                    return;
                }

                // --                               

                fObject = (FIObject)tNode.Tag;
                fDragDropData = new FDragDropData(fObject);
                // --
                tvwFlow.DoDragDrop(new DataObject(fDragDropData), DragDropEffects.All);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                tNode = null;
                fObject = null;
                fDragDropData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwFlow_DragOver(
            object sender,
            DragEventArgs e
            )
        {
            FDragDropData fDragDropData = null;
            UltraTreeNode tRefNode = null;
            FIObject fRefObject = null;
            int cnt = 0;
            FFormat fFormat = FFormat.Unknown;

            try
            {
                tRefNode = tvwFlow.GetNodeFromPoint(tvwFlow.PointToClient(new System.Drawing.Point(e.X, e.Y)));
                fDragDropData = e.Data.GetData(typeof(FDragDropData).ToString(), true) as FDragDropData;
                if (tRefNode == null || fDragDropData == null || !fDragDropData.serializableSuccess)
                {
                    if (fDragDropData != null && fDragDropData.oldRefNode != null)
                    {
                        FCommon.resetDragOverTreeNode(fDragDropData.oldRefNode);
                        fDragDropData.oldRefNode = null;
                    }
                    // --
                    e.Effect = DragDropEffects.None;
                    return;
                }

                // --

                if (fDragDropData.oldRefNode != null)
                {
                    FCommon.resetDragOverTreeNode(fDragDropData.oldRefNode);
                }
                // --
                FCommon.setDragOverTreeNode(tRefNode);
                fDragDropData.oldRefNode = tRefNode;

                // --

                fRefObject = (FIObject)tRefNode.Tag;

                // --

                if (fDragDropData.fObject != null)
                {
                    #region FObject

                    if (fRefObject.fObjectType == FObjectType.SecsTrigger)
                    {
                        #region SecsTrigger

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsCondition)
                        {
                            #region SecsCondition

                            if (((FSecsTrigger)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FSecsTrigger)fRefObject).containsObject(fDragDropData.fObject))
                                {
                                    cnt = ((FSecsTrigger)fRefObject).fChildSecsConditionCollection.count;
                                    fRefObject = ((FSecsTrigger)fRefObject).fChildSecsConditionCollection[cnt - 1];
                                    if (!fRefObject.Equals(fDragDropData.fObject))
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsDevice)
                        {
                            #region SecsDevice

                            if (((FSecsTrigger)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessage)
                        {
                            #region SecsMessage

                            if (((FSecsTrigger)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (fDragDropData.sessionUniqueId != string.Empty)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsCondition)
                    {
                        #region SecsCondition

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsCondition)
                        {
                            #region SecsCondition

                            if (((FSecsCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FSecsCondition)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FSecsCondition)fRefObject).fNextSibling == null || !((FSecsCondition)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsExpression)
                        {
                            #region SecsExpression

                            if (((FSecsCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FSecsCondition)fRefObject).containsObject(fDragDropData.fObject))
                                {
                                    cnt = ((FSecsCondition)fRefObject).fChildSecsExpressionCollection.count;
                                    fRefObject = ((FSecsCondition)fRefObject).fChildSecsExpressionCollection[cnt - 1];
                                    if (!fRefObject.Equals(fDragDropData.fObject))
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsDevice)
                        {
                            #region SecsDevice

                            if (((FSecsCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (!((FSecsCondition)fRefObject).hasChild)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessage)
                        {
                            #region SecsMessage

                            if (((FSecsCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (fDragDropData.sessionUniqueId != string.Empty)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }    
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsItem)
                        {
                            #region SecsEventItem

                            if (((FSecsCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FSecsCondition)fRefObject).hasMessage &&
                                    ((FSecsCondition)fRefObject).fMessage.Equals(((FSecsItem)fDragDropData.fObject).fAncestorSecsMessage)
                                    )
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentState)
                        {
                            #region EquipmentState

                            if (((FSecsCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FSecsCondition)fRefObject).hasMessage)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }                                
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Environment)
                        {
                            #region Environment

                            if (((FSecsCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FSecsCondition)fRefObject).hasMessage)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsExpression)
                    {
                        #region SecsExpression

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsExpression)
                        {
                            #region SecsExpression

                            if (((FSecsExpression)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FSecsExpression)fRefObject).fAncestorSecsCondition.containsObject(fDragDropData.fObject) &&
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    !((FSecsExpression)fDragDropData.fObject).containsObject(fRefObject) &&
                                    (((FSecsExpression)fRefObject).fNextSibling == null || !((FSecsExpression)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataConversionSet)
                        {
                            #region DataConversionSet

                            if (((FSecsExpression)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FSecsExpression)fRefObject).hasOperand && ((FSecsExpression)fRefObject).fOperandType == FSecsOperandType.SecsItem)
                                {
                                    fFormat = ((FSecsExpression)fRefObject).fOperandFormat;
                                    // --
                                    if (
                                        fFormat != FFormat.List &&
                                        fFormat != FFormat.AsciiList &&
                                        fFormat != FFormat.Raw &&
                                        fFormat != FFormat.Unknown
                                        )
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsItem)
                        {
                            #region SecsItem

                            if (((FSecsExpression)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FSecsExpression)fRefObject).fAncestorSecsCondition.hasMessage &&
                                    ((FSecsExpression)fRefObject).fAncestorSecsCondition.fMessage.Equals(((FSecsItem)fDragDropData.fObject).fAncestorSecsMessage)
                                    )
                                {
                                    if (
                                        ((FSecsExpression)fRefObject).fExpressionType != FExpressionType.Bracket ||
                                        !((FSecsExpression)fRefObject).hasChild
                                        )
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentState)
                        {
                            #region EquipmentState

                            if (((FSecsExpression)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FSecsExpression)fRefObject).fAncestorSecsCondition.hasMessage)
                                {
                                    if (
                                        ((FSecsExpression)fRefObject).fExpressionType != FExpressionType.Bracket ||
                                        !((FSecsExpression)fRefObject).hasChild
                                        )
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Environment)
                        {
                            #region Environment

                            if (((FSecsExpression)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FSecsExpression)fRefObject).fAncestorSecsCondition.hasMessage)
                                {
                                    if (
                                        ((FSecsExpression)fRefObject).fExpressionType != FExpressionType.Bracket ||
                                        !((FSecsExpression)fRefObject).hasChild
                                        )
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsTransmitter)
                    {
                        #region SecsTransmitter

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsTransfer)
                        {
                            #region SecsTransfer

                            if (((FSecsTransmitter)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FSecsTransmitter)fRefObject).containsObject(fDragDropData.fObject))
                                {
                                    cnt = ((FSecsTransmitter)fRefObject).fChildSecsTransferCollection.count;
                                    fRefObject = ((FSecsTransmitter)fRefObject).fChildSecsTransferCollection[cnt - 1];
                                    if (!fRefObject.Equals(fDragDropData.fObject))
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessage)
                        {
                            #region SecsMessage

                            if (((FSecsTransmitter)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (fDragDropData.sessionUniqueId != string.Empty)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }    
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsTransfer)
                    {
                        #region SecsTransfer

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsTransfer)
                        {
                            #region SecsTransfer

                            if (((FSecsTransfer)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FSecsTransfer)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FSecsTransfer)fRefObject).fNextSibling == null || !((FSecsTransfer)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessage)
                        {
                            #region SecsMessage

                            if (((FSecsTransfer)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (fDragDropData.sessionUniqueId != string.Empty)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }    
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.HostTrigger)
                    {
                        #region HostTrigger

                        if (fDragDropData.fObject.fObjectType == FObjectType.HostCondition)
                        {
                            #region HostCondition

                            if (((FHostTrigger)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FHostTrigger)fRefObject).containsObject(fDragDropData.fObject))
                                {
                                    cnt = ((FHostTrigger)fRefObject).fChildHostConditionCollection.count;
                                    fRefObject = ((FHostTrigger)fRefObject).fChildHostConditionCollection[cnt - 1];
                                    if (!fRefObject.Equals(fDragDropData.fObject))
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostDevice)
                        {
                            #region HostDevice

                            if (((FHostTrigger)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostMessage)
                        {
                            #region HostMessage

                            if (((FHostTrigger)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (fDragDropData.sessionUniqueId != string.Empty)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.HostCondition)
                    {
                        #region HostCondition

                        if (fDragDropData.fObject.fObjectType == FObjectType.HostCondition)
                        {
                            #region HostCondition

                            if (((FHostCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FHostCondition)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FHostCondition)fRefObject).fNextSibling == null || !((FHostCondition)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostExpression)
                        {
                            #region HostExpression

                            if (((FHostCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FHostCondition)fRefObject).containsObject(fDragDropData.fObject))
                                {
                                    cnt = ((FHostCondition)fRefObject).fChildHostExpressionCollection.count;
                                    fRefObject = ((FHostCondition)fRefObject).fChildHostExpressionCollection[cnt - 1];
                                    if (!fRefObject.Equals(fDragDropData.fObject))
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostDevice)
                        {
                            #region HostDevice

                            if (((FHostCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (!((FHostCondition)fRefObject).hasChild)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostMessage)
                        {
                            #region HostMessage

                            if (((FHostCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (fDragDropData.sessionUniqueId != string.Empty)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }    
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostItem)
                        {
                            #region HostEventItem

                            if (((FHostCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FHostCondition)fRefObject).hasMessage &&
                                    ((FHostCondition)fRefObject).fMessage.Equals(((FHostItem)fDragDropData.fObject).fAncestorHostMessage)
                                    )
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentState)
                        {
                            #region EquipmentState

                            if (((FHostCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FHostCondition)fRefObject).hasMessage)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Environment)
                        {
                            #region Environment

                            if (((FHostCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FHostCondition)fRefObject).hasMessage)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.HostExpression)
                    {
                        #region HostExpression

                        if (fDragDropData.fObject.fObjectType == FObjectType.HostExpression)
                        {
                            #region HostExpression

                            if (((FHostExpression)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FHostExpression)fRefObject).fAncestorHostCondition.containsObject(fDragDropData.fObject) &&
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    !((FHostExpression)fDragDropData.fObject).containsObject(fRefObject) &&
                                    (((FHostExpression)fRefObject).fNextSibling == null || !((FHostExpression)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataConversionSet)
                        {
                            #region DataConversionSet

                            if (((FHostExpression)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FHostExpression)fRefObject).hasOperand && ((FHostExpression)fRefObject).fOperandType == FHostOperandType.HostItem)
                                {
                                    fFormat = ((FHostExpression)fRefObject).fOperandFormat;
                                    // --
                                    if (
                                        fFormat != FFormat.List &&
                                        fFormat != FFormat.AsciiList &&
                                        fFormat != FFormat.Raw &&
                                        fFormat != FFormat.Unknown
                                        )
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostItem)
                        {
                            #region HostItem

                            if (((FHostExpression)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FHostExpression)fRefObject).fAncestorHostCondition.hasMessage &&
                                    ((FHostExpression)fRefObject).fAncestorHostCondition.fMessage.Equals(((FHostItem)fDragDropData.fObject).fAncestorHostMessage)
                                    )
                                {
                                    if (
                                        ((FHostExpression)fRefObject).fExpressionType != FExpressionType.Bracket ||
                                        !((FHostExpression)fRefObject).hasChild
                                        )
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentState)
                        {
                            #region EquipmentState

                            if (((FHostExpression)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FHostExpression)fRefObject).fAncestorHostCondition.hasMessage)
                                {
                                    if (
                                        ((FHostExpression)fRefObject).fExpressionType != FExpressionType.Bracket ||
                                        !((FHostExpression)fRefObject).hasChild
                                        )
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Environment)
                        {
                            #region Environment

                            if (((FHostExpression)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FHostExpression)fRefObject).fAncestorHostCondition.hasMessage)
                                {
                                    if (
                                        ((FHostExpression)fRefObject).fExpressionType != FExpressionType.Bracket ||
                                        !((FHostExpression)fRefObject).hasChild
                                        )
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.HostTransmitter)
                    {
                        #region HostTransmitter

                        if (fDragDropData.fObject.fObjectType == FObjectType.HostTransfer)
                        {
                            #region HostTransfer

                            if (((FHostTransmitter)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FHostTransmitter)fRefObject).containsObject(fDragDropData.fObject))
                                {
                                    cnt = ((FHostTransmitter)fRefObject).fChildHostTransferCollection.count;
                                    fRefObject = ((FHostTransmitter)fRefObject).fChildHostTransferCollection[cnt - 1];
                                    if (!fRefObject.Equals(fDragDropData.fObject))
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostMessage)
                        {
                            #region HostMessage

                            if (((FHostTransmitter)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (fDragDropData.sessionUniqueId != string.Empty)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }    
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.HostTransfer)
                    {
                        #region HostTransfer

                        if (fDragDropData.fObject.fObjectType == FObjectType.HostTransfer)
                        {
                            #region HostTransfer

                            if (((FHostTransfer)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FHostTransfer)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FHostTransfer)fRefObject).fNextSibling == null || !((FHostTransfer)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostMessage)
                        {
                            #region HostMessage

                            if (((FHostTransfer)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (fDragDropData.sessionUniqueId != string.Empty)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }    
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                    {
                        #region EquipmentStateSetAlterer

                        if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateAlterer)
                        {
                            #region EquipmentStateAlterer

                            if (((FEquipmentStateSetAlterer)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FEquipmentStateSetAlterer)fRefObject).containsObject(fDragDropData.fObject))
                                {
                                    cnt = ((FEquipmentStateSetAlterer)fRefObject).fChildEquipmentStateAltererCollection.count;
                                    fRefObject = ((FEquipmentStateSetAlterer)fRefObject).fChildEquipmentStateAltererCollection[cnt - 1];
                                    if (!fRefObject.Equals(fDragDropData.fObject))
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSet)
                        {
                            #region EquipmentStateSet

                            if (((FEquipmentStateSetAlterer)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentState)
                        {
                            #region EquipmentState

                            if (((FEquipmentStateSetAlterer)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FEquipmentStateSetAlterer)fRefObject).fEquipmentStateSet != null &&
                                    ((FEquipmentStateSetAlterer)fRefObject).fEquipmentStateSet.Equals(((FEquipmentState)fDragDropData.fObject).fParent)
                                    )
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.EquipmentStateAlterer)
                    {
                        #region EquipmentStateAlterer

                        if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateAlterer)
                        {
                            #region EquipmentStateAlterer

                            if (((FEquipmentStateAlterer)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FEquipmentStateAlterer)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FEquipmentStateAlterer)fRefObject).fNextSibling == null || !((FEquipmentStateAlterer)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentState)
                        {
                            #region EquipmentState

                            if (((FEquipmentStateAlterer)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FEquipmentStateAlterer)fRefObject).fParent.fEquipmentStateSet != null &&
                                    ((FEquipmentStateAlterer)fRefObject).fParent.fEquipmentStateSet.Equals(((FEquipmentState)fDragDropData.fObject).fParent)
                                    )
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Judgement)
                    {
                        #region Judgement

                        if (fDragDropData.fObject.fObjectType == FObjectType.JudgementCondition)
                        {
                            #region JudgementCondition

                            if (((FJudgement)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FJudgement)fRefObject).containsObject(fDragDropData.fObject))
                                {
                                    cnt = ((FJudgement)fRefObject).fChildJudgementConditionCollection.count;
                                    fRefObject = ((FJudgement)fRefObject).fChildJudgementConditionCollection[cnt - 1];
                                    if (!fRefObject.Equals(fDragDropData.fObject))
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataSet)
                        {
                            #region DataSet

                            if (((FJudgement)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Scenario)
                        {
                            #region Scenario

                            if (((FJudgement)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.JudgementCondition)
                    {
                        #region JudgementCondition

                        if (fDragDropData.fObject.fObjectType == FObjectType.JudgementCondition)
                        {
                            #region JudgementCondition

                            if (((FJudgementCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FJudgementCondition)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FJudgementCondition)fRefObject).fNextSibling == null || !((FJudgementCondition)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.JudgementExpression)
                        {
                            #region JudgementExpression

                            if (((FJudgementCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FJudgementCondition)fRefObject).containsObject(fDragDropData.fObject))
                                {
                                    cnt = ((FJudgementCondition)fRefObject).fChildJudgementExpressionCollection.count;
                                    fRefObject = ((FJudgementCondition)fRefObject).fChildJudgementExpressionCollection[cnt - 1];
                                    if (!fRefObject.Equals(fDragDropData.fObject))
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataSet)
                        {
                            #region DataSet

                            if (((FJudgementCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Data)
                        {
                            #region Data

                            if (((FJudgementCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FJudgementCondition)fRefObject).fDataSet != null &&
                                    ((FJudgementCondition)fRefObject).fDataSet.Equals(((FData)fDragDropData.fObject).fAncestorDataSet)
                                    )
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.JudgementExpression)
                    {
                        #region JudgementExpression

                        if (fDragDropData.fObject.fObjectType == FObjectType.JudgementExpression)
                        {
                            #region JudgementExpression

                            if (((FJudgementExpression)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FJudgementExpression)fRefObject).fAncestorJudgementCondition.containsObject(fDragDropData.fObject) &&
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    !((FJudgementExpression)fDragDropData.fObject).containsObject(fRefObject) &&
                                    (((FJudgementExpression)fRefObject).fNextSibling == null || !((FJudgementExpression)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataConversionSet)
                        {
                            #region DataConversionSet

                            if (((FJudgementExpression)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FJudgementExpression)fRefObject).hasOperand)
                                {
                                    fFormat = ((FJudgementExpression)fRefObject).fOperandFormat;
                                    // --
                                    if (
                                        fFormat != FFormat.List &&
                                        fFormat != FFormat.AsciiList &&
                                        fFormat != FFormat.Raw &&
                                        fFormat != FFormat.Unknown
                                        )
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Data)
                        {
                            #region Data

                            if (((FJudgementExpression)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FJudgementExpression)fRefObject).fAncestorJudgementCondition.fDataSet != null &&
                                    ((FJudgementExpression)fRefObject).fAncestorJudgementCondition.fDataSet.Equals(((FData)fDragDropData.fObject).fAncestorDataSet)
                                    )
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Mapper)
                    {
                        #region Mapper

                        if (fDragDropData.fObject.fObjectType == FObjectType.DataSet)
                        {
                            #region DataSet

                            if (((FMapper)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Storage)
                    {
                        #region Storage

                        if (fDragDropData.fObject.fObjectType == FObjectType.Repository)
                        {
                            #region Repository

                            if (((FStorage)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Callback)
                    {
                        #region Callback

                        if (fDragDropData.fObject.fObjectType == FObjectType.Function)
                        {
                            #region Function

                            if (((FCallback)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FCallback)fRefObject).containsObject(fDragDropData.fObject))
                                {
                                    cnt = ((FCallback)fRefObject).fChildFunctionCollection.count;
                                    fRefObject = ((FCallback)fRefObject).fChildFunctionCollection[cnt - 1];
                                    if (!fRefObject.Equals(fDragDropData.fObject))
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.FunctionName)
                        {
                            #region FunctionName

                            if (((FCallback)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Function)
                    {
                        #region Function

                        if (fDragDropData.fObject.fObjectType == FObjectType.Function)
                        {
                            #region Function

                            if (((FFunction)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FFunction)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FFunction)fRefObject).fNextSibling == null || !((FFunction)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.FunctionName)
                        {
                            #region FunctionName

                            if (((FFunction)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Branch)
                    {
                        #region Branch

                        if (fDragDropData.fObject.fObjectType == FObjectType.Scenario)
                        {
                            #region Scenario

                            if (((FBranch)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }

                        #endregion
                    }

                    #endregion
                }

                // --

                FCommon.resetDragOverTreeNode(tRefNode);
                e.Effect = DragDropEffects.None;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                tRefNode = null;
                fRefObject = null;
                fDragDropData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwFlow_DragDrop(
            object sender,
            DragEventArgs e
            )
        {
            FDragDropAction fAction = FDragDropAction.Move;
            FDragDropData fDragDropData = null;
            UltraTreeNode tRefNode = null;
            UltraTreeNode tNode = null;
            UltraTreeNode tParentNode = null;
            FIObject fRefObject = null;
            FIObject fChildObject = null;
            FIObject fDevice = null;
            FIObject fSession = null;
            string uniqueId = string.Empty;
            string refUniqueId = string.Empty;
            FFormat fFormat = FFormat.Unknown;

            try
            {
                tRefNode = tvwFlow.GetNodeFromPoint(tvwFlow.PointToClient(new System.Drawing.Point(e.X, e.Y)));
                fDragDropData = e.Data.GetData(typeof(FDragDropData).ToString(), true) as FDragDropData;
                if (tRefNode == null || fDragDropData == null)
                {
                    if (fDragDropData != null && fDragDropData.oldRefNode != null)
                    {
                        FCommon.resetDragOverTreeNode(fDragDropData.oldRefNode);
                        fDragDropData.oldRefNode = null;
                    }
                    return;
                }

                // --

                if (fDragDropData.oldRefNode != null)
                {
                    FCommon.resetDragOverTreeNode(fDragDropData.oldRefNode);
                }

                // --

                fRefObject = (FIObject)tRefNode.Tag;

                // --

                if (fDragDropData.fObject != null)
                {
                    #region FObject

                    if (fRefObject.fObjectType == FObjectType.SecsTrigger)
                    {
                        #region SecsTrigger

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsCondition)
                        {
                            #region SecsCondition

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FSecsCondition)fDragDropData.fObject).moveTo((FSecsTrigger)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsCondition)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsTrigger)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsDevice)
                        {
                            #region SecsDevice

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fChildObject = ((FSecsTrigger)fRefObject).appendChildSecsCondition(new FSecsCondition(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                ((FSecsCondition)fChildObject).fConditionMode = FConditionMode.Connection;
                                ((FSecsCondition)fChildObject).setDevice((FSecsDevice)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessage)
                        {
                            #region SecsMessage

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fSession = this.m_fSsmCore.fSsmFileInfo.fSecsDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FSecsSession)fSession).fParent;
                                // --
                                fChildObject = ((FSecsTrigger)fRefObject).appendChildSecsCondition(new FSecsCondition(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                ((FSecsCondition)fChildObject).fConditionMode = FConditionMode.Expression;
                                ((FSecsCondition)fChildObject).setMessage((FSecsDevice)fDevice, (FSecsSession)fSession, (FSecsMessage)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsCondition)
                    {
                        #region SecsCondition

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsCondition)
                        {
                            #region SecsCondition

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FSecsCondition)fDragDropData.fObject).moveTo((FSecsCondition)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsCondition)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsCondition)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsExpression)
                        {
                            #region SecsExpression

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FSecsExpression)fDragDropData.fObject).moveTo((FSecsCondition)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsExpression)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsCondition)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsDevice)
                        {
                            #region SecsDevice

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsCondition)fRefObject).fConditionMode = FConditionMode.Connection;
                                ((FSecsCondition)fRefObject).setDevice((FSecsDevice)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessage)
                        {
                            #region SecsMessage

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fSession = this.m_fSsmCore.fSsmFileInfo.fSecsDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FSecsSession)fSession).fParent;
                                // --
                                ((FSecsCondition)fRefObject).fConditionMode = FConditionMode.Expression;
                                ((FSecsCondition)fRefObject).setMessage((FSecsDevice)fDevice, (FSecsSession)fSession, (FSecsMessage)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsItem)
                        {
                            #region SecsItem

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fChildObject = ((FSecsCondition)fRefObject).appendChildSecsExpression(new FSecsExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                fFormat = ((FSecsItem)fDragDropData.fObject).fFormat;
                                if (
                                    fFormat == FFormat.List ||
                                    fFormat == FFormat.AsciiList ||
                                    fFormat == FFormat.Raw ||
                                    fFormat == FFormat.Unknown
                                    )
                                {
                                    ((FSecsExpression)fChildObject).fComparisonMode = FComparisonMode.Length;
                                }
                                else
                                {
                                    ((FSecsExpression)fChildObject).fComparisonMode = FComparisonMode.Value;
                                }
                                ((FSecsExpression)fChildObject).fOperandType = FSecsOperandType.SecsItem;
                                ((FSecsExpression)fChildObject).setOperand((FISecsOperand)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentState)
                        {
                            #region EquipmentState

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fChildObject = ((FSecsCondition)fRefObject).appendChildSecsExpression(new FSecsExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                ((FSecsExpression)fChildObject).fOperandType = FSecsOperandType.EquipmentState;
                                ((FSecsExpression)fChildObject).setOperand((FISecsOperand)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Environment)
                        {
                            #region Environment

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fChildObject = ((FSecsCondition)fRefObject).appendChildSecsExpression(new FSecsExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                fFormat = ((FEnvironment)fDragDropData.fObject).fFormat;
                                if (
                                    fFormat == FFormat.List ||
                                    fFormat == FFormat.AsciiList ||
                                    fFormat == FFormat.Raw ||
                                    fFormat == FFormat.Unknown
                                    )
                                {
                                    ((FSecsExpression)fChildObject).fComparisonMode = FComparisonMode.Length;
                                }
                                else
                                {
                                    ((FSecsExpression)fChildObject).fComparisonMode = FComparisonMode.Value;
                                }
                                ((FSecsExpression)fChildObject).fOperandType = FSecsOperandType.Environment;
                                ((FSecsExpression)fChildObject).setOperand((FISecsOperand)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsExpression)
                    {
                        #region SecsExpression

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsExpression)
                        {
                            #region SecsExpression

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FSecsExpression)fDragDropData.fObject).moveTo((FSecsExpression)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsExpression)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsExpression)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataConversionSet)
                        {
                            #region DataConversionSet

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsExpression)fRefObject).setDataConversionSet((FDataConversionSet)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsItem)
                        {
                            #region SecsItem

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsExpression)fRefObject).fExpressionType = FExpressionType.Comparison;
                                fFormat = ((FSecsItem)fDragDropData.fObject).fFormat;
                                if (
                                    fFormat == FFormat.List ||
                                    fFormat == FFormat.AsciiList ||
                                    fFormat == FFormat.Raw ||
                                    fFormat == FFormat.Unknown
                                    )
                                {
                                    ((FSecsExpression)fRefObject).fComparisonMode = FComparisonMode.Length;
                                }
                                else
                                {
                                    ((FSecsExpression)fRefObject).fComparisonMode = FComparisonMode.Value;
                                }
                                ((FSecsExpression)fRefObject).fOperandType = FSecsOperandType.SecsItem;
                                ((FSecsExpression)fRefObject).setOperand((FISecsOperand)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentState)
                        {
                            #region EquipmentState

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsExpression)fRefObject).fExpressionType = FExpressionType.Comparison;
                                ((FSecsExpression)fRefObject).fOperandType = FSecsOperandType.EquipmentState;
                                ((FSecsExpression)fRefObject).setOperand((FISecsOperand)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Environment)
                        {
                            #region Environment

                            ((FSecsExpression)fRefObject).fExpressionType = FExpressionType.Comparison;
                            fFormat = ((FEnvironment)fDragDropData.fObject).fFormat;
                            if (
                                fFormat == FFormat.List ||
                                fFormat == FFormat.AsciiList ||
                                fFormat == FFormat.Raw ||
                                fFormat == FFormat.Unknown
                                )
                            {
                                ((FSecsExpression)fRefObject).fComparisonMode = FComparisonMode.Length;
                            }
                            else
                            {
                                ((FSecsExpression)fRefObject).fComparisonMode = FComparisonMode.Value;
                            }
                            ((FSecsExpression)fRefObject).fOperandType = FSecsOperandType.Environment;
                            ((FSecsExpression)fRefObject).setOperand((FISecsOperand)fDragDropData.fObject);
                            fAction = FDragDropAction.Set;

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsTransmitter)
                    {
                        #region SecsTransmitter

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsTransfer)
                        {
                            #region SecsTransfer

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FSecsTransfer)fDragDropData.fObject).moveTo((FSecsTransmitter)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsTransfer)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsTransmitter)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessage)
                        {
                            #region SecsMessage

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fSession = this.m_fSsmCore.fSsmFileInfo.fSecsDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FSecsSession)fSession).fParent;
                                // --
                                fChildObject = ((FSecsTransmitter)fRefObject).appendChildSecsTransfer(new FSecsTransfer(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                ((FSecsTransfer)fChildObject).setMessage((FSecsDevice)fDevice, (FSecsSession)fSession, (FSecsMessage)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsTransfer)
                    {
                        #region SecsTransfer

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsTransfer)
                        {
                            #region SecsTransfer

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FSecsTransfer)fDragDropData.fObject).moveTo((FSecsTransfer)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsTransfer)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsTransfer)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessage)
                        {
                            #region SecsMessage

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fSession = this.m_fSsmCore.fSsmFileInfo.fSecsDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FSecsSession)fSession).fParent;
                                // --                                
                                ((FSecsTransfer)fRefObject).setMessage((FSecsDevice)fDevice, (FSecsSession)fSession, (FSecsMessage)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.HostTrigger)
                    {
                        #region HostTrigger

                        if (fDragDropData.fObject.fObjectType == FObjectType.HostCondition)
                        {
                            #region HostCondition

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FHostCondition)fDragDropData.fObject).moveTo((FHostTrigger)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostCondition)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FHostTrigger)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostDevice)
                        {
                            #region HostDevice

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fChildObject = ((FHostTrigger)fRefObject).appendChildHostCondition(new FHostCondition(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                ((FHostCondition)fChildObject).fConditionMode = FConditionMode.Connection;
                                ((FHostCondition)fChildObject).setDevice((FHostDevice)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostMessage)
                        {
                            #region HostMessage

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fSession = this.m_fSsmCore.fSsmFileInfo.fSecsDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FHostSession)fSession).fParent;
                                // --
                                fChildObject = ((FHostTrigger)fRefObject).appendChildHostCondition(new FHostCondition(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                ((FHostCondition)fChildObject).fConditionMode = FConditionMode.Expression;
                                ((FHostCondition)fChildObject).setMessage((FHostDevice)fDevice, (FHostSession)fSession, (FHostMessage)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.HostCondition)
                    {
                        #region HostCondition

                        if (fDragDropData.fObject.fObjectType == FObjectType.HostCondition)
                        {
                            #region HostCondition

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FHostCondition)fDragDropData.fObject).moveTo((FHostCondition)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostCondition)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FHostCondition)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostExpression)
                        {
                            #region HostExpression

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FHostExpression)fDragDropData.fObject).moveTo((FHostCondition)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostExpression)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FHostCondition)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostDevice)
                        {
                            #region HostDevice

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostCondition)fRefObject).fConditionMode = FConditionMode.Connection;
                                ((FHostCondition)fRefObject).setDevice((FHostDevice)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostMessage)
                        {
                            #region HostMessage

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fSession = this.m_fSsmCore.fSsmFileInfo.fSecsDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FHostSession)fSession).fParent;
                                // --
                                ((FHostCondition)fRefObject).fConditionMode = FConditionMode.Expression;
                                ((FHostCondition)fRefObject).setMessage((FHostDevice)fDevice, (FHostSession)fSession, (FHostMessage)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostItem)
                        {
                            #region HostItem

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fChildObject = ((FHostCondition)fRefObject).appendChildHostExpression(new FHostExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                fFormat = ((FHostItem)fDragDropData.fObject).fFormat;
                                if (
                                    fFormat == FFormat.List ||
                                    fFormat == FFormat.AsciiList ||
                                    fFormat == FFormat.Raw ||
                                    fFormat == FFormat.Unknown
                                    )
                                {
                                    ((FHostExpression)fChildObject).fComparisonMode = FComparisonMode.Length;
                                }
                                else
                                {
                                    ((FHostExpression)fChildObject).fComparisonMode = FComparisonMode.Value;
                                }
                                ((FHostExpression)fChildObject).fOperandType = FHostOperandType.HostItem;
                                ((FHostExpression)fChildObject).setOperand((FIHostOperand)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentState)
                        {
                            #region EquipmentState

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fChildObject = ((FHostCondition)fRefObject).appendChildHostExpression(new FHostExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                ((FHostExpression)fChildObject).fOperandType = FHostOperandType.EquipmentState;
                                ((FHostExpression)fChildObject).setOperand((FIHostOperand)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Environment)
                        {
                            #region Environment

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fChildObject = ((FHostCondition)fRefObject).appendChildHostExpression(new FHostExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                fFormat = ((FEnvironment)fDragDropData.fObject).fFormat;
                                if (
                                    fFormat == FFormat.List ||
                                    fFormat == FFormat.AsciiList ||
                                    fFormat == FFormat.Raw ||
                                    fFormat == FFormat.Unknown
                                    )
                                {
                                    ((FHostExpression)fChildObject).fComparisonMode = FComparisonMode.Length;
                                }
                                else
                                {
                                    ((FHostExpression)fChildObject).fComparisonMode = FComparisonMode.Value;
                                }
                                ((FHostExpression)fChildObject).fOperandType = FHostOperandType.Environment;
                                ((FHostExpression)fChildObject).setOperand((FIHostOperand)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.HostExpression)
                    {
                        #region HostExpression

                        if (fDragDropData.fObject.fObjectType == FObjectType.HostExpression)
                        {
                            #region HostExpression

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FHostExpression)fDragDropData.fObject).moveTo((FHostExpression)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostExpression)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FHostExpression)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataConversionSet)
                        {
                            #region DataConversionSet

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostExpression)fRefObject).setDataConversionSet((FDataConversionSet)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostItem)
                        {
                            #region HostItem

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostExpression)fRefObject).fExpressionType = FExpressionType.Comparison;
                                fFormat = ((FHostItem)fDragDropData.fObject).fFormat;
                                if (
                                    fFormat == FFormat.List ||
                                    fFormat == FFormat.AsciiList ||
                                    fFormat == FFormat.Raw ||
                                    fFormat == FFormat.Unknown
                                    )
                                {
                                    ((FHostExpression)fRefObject).fComparisonMode = FComparisonMode.Length;
                                }
                                else
                                {
                                    ((FHostExpression)fRefObject).fComparisonMode = FComparisonMode.Value;
                                }
                                ((FHostExpression)fRefObject).fOperandType = FHostOperandType.HostItem;
                                ((FHostExpression)fRefObject).setOperand((FIHostOperand)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentState)
                        {
                            #region EquipmentState

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostExpression)fRefObject).fExpressionType = FExpressionType.Comparison;
                                ((FHostExpression)fRefObject).fOperandType = FHostOperandType.EquipmentState;
                                ((FHostExpression)fRefObject).setOperand((FIHostOperand)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Environment)
                        {
                            #region Environment

                            ((FHostExpression)fRefObject).fExpressionType = FExpressionType.Comparison;
                            fFormat = ((FEnvironment)fDragDropData.fObject).fFormat;
                            if (
                                fFormat == FFormat.List ||
                                fFormat == FFormat.AsciiList ||
                                fFormat == FFormat.Raw ||
                                fFormat == FFormat.Unknown
                                )
                            {
                                ((FHostExpression)fRefObject).fComparisonMode = FComparisonMode.Length;
                            }
                            else
                            {
                                ((FHostExpression)fRefObject).fComparisonMode = FComparisonMode.Value;
                            }
                            ((FHostExpression)fRefObject).fOperandType = FHostOperandType.Environment;
                            ((FHostExpression)fRefObject).setOperand((FIHostOperand)fDragDropData.fObject);
                            fAction = FDragDropAction.Set;

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.HostTransmitter)
                    {
                        #region HostTransmitter

                        if (fDragDropData.fObject.fObjectType == FObjectType.HostTransfer)
                        {
                            #region HostTransfer

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FHostTransfer)fDragDropData.fObject).moveTo((FHostTransmitter)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostTransfer)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FHostTransmitter)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostMessage)
                        {
                            #region HostMessage

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fSession = this.m_fSsmCore.fSsmFileInfo.fSecsDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FHostSession)fSession).fParent;
                                // --
                                fChildObject = ((FHostTransmitter)fRefObject).appendChildHostTransfer(new FHostTransfer(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                ((FHostTransfer)fChildObject).setMessage((FHostDevice)fDevice, (FHostSession)fSession, (FHostMessage)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.HostTransfer)
                    {
                        #region HostTransfer

                        if (fDragDropData.fObject.fObjectType == FObjectType.HostTransfer)
                        {
                            #region HostTransfer

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FHostTransfer)fDragDropData.fObject).moveTo((FHostTransfer)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostTransfer)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FHostTransfer)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostMessage)
                        {
                            #region HostMessage

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fSession = this.m_fSsmCore.fSsmFileInfo.fSecsDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FHostSession)fSession).fParent;
                                // --                                
                                ((FHostTransfer)fRefObject).setMessage((FHostDevice)fDevice, (FHostSession)fSession, (FHostMessage)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                    {
                        #region EquipmentStateSetAlterer

                        if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateAlterer)
                        {
                            #region EquipmentStateAlterer

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FEquipmentStateAlterer)fDragDropData.fObject).moveTo((FEquipmentStateSetAlterer)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FEquipmentStateAlterer)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FEquipmentStateSetAlterer)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSet)
                        {
                            #region EquipmentStateSet

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FEquipmentStateSetAlterer)fRefObject).setEquipmentStateSet((FEquipmentStateSet)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentState)
                        {
                            #region EquipmentState

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fChildObject = ((FEquipmentStateSetAlterer)fRefObject).appendChildEquipmentStateAlterer(new FEquipmentStateAlterer(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                ((FEquipmentStateAlterer)fChildObject).setEquipmentState((FEquipmentState)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.EquipmentStateAlterer)
                    {
                        #region EquipmentStateAlterer

                        if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateAlterer)
                        {
                            #region EquipmentStateAlterer

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FEquipmentStateAlterer)fDragDropData.fObject).moveTo((FEquipmentStateAlterer)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FEquipmentStateAlterer)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FEquipmentStateAlterer)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentState)
                        {
                            #region EquipmentState

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FEquipmentStateAlterer)fRefObject).setEquipmentState((FEquipmentState)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Judgement)
                    {
                        #region Judgement

                        if (fDragDropData.fObject.fObjectType == FObjectType.JudgementCondition)
                        {
                            #region JudgementCondition

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FJudgementCondition)fDragDropData.fObject).moveTo((FJudgement)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FJudgementCondition)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FJudgement)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataSet)
                        {
                            #region DataSet

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fChildObject = ((FJudgement)fRefObject).appendChildJudgementCondition(new FJudgementCondition(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                ((FJudgementCondition)fChildObject).setDataSet((FDataSet)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Scenario)
                        {
                            #region Scenario

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FJudgement)fRefObject).usedBranch = true;
                                ((FJudgement)fRefObject).setLocation((FScenario)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.JudgementCondition)
                    {
                        #region JudgementCondition

                        if (fDragDropData.fObject.fObjectType == FObjectType.JudgementCondition)
                        {
                            #region JudgementCondition

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FJudgementCondition)fDragDropData.fObject).moveTo((FJudgementCondition)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FJudgementCondition)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FJudgementCondition)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.JudgementExpression)
                        {
                            #region JudgementExpression

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FJudgementExpression)fDragDropData.fObject).moveTo((FJudgementCondition)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FJudgementExpression)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FJudgementCondition)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataSet)
                        {
                            #region DataSet

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FJudgementCondition)fRefObject).setDataSet((FDataSet)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Data)
                        {
                            #region Data

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fChildObject = ((FJudgementCondition)fRefObject).appendChildJudgementExpression(new FJudgementExpression(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                ((FJudgementExpression)fChildObject).setOperand((FData)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.JudgementExpression)
                    {
                        #region JudgementExpression

                        if (fDragDropData.fObject.fObjectType == FObjectType.JudgementExpression)
                        {
                            #region JudgementExpression

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FJudgementExpression)fDragDropData.fObject).moveTo((FJudgementExpression)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FJudgementExpression)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FJudgementExpression)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataConversionSet)
                        {
                            #region DataConversionSet

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FJudgementExpression)fRefObject).setDataConversionSet((FDataConversionSet)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Data)
                        {
                            #region Data

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FJudgementExpression)fRefObject).setOperand((FData)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Mapper)
                    {
                        #region Mapper

                        if (fDragDropData.fObject.fObjectType == FObjectType.DataSet)
                        {
                            #region DataSet

                            ((FMapper)fRefObject).setDataSet((FDataSet)fDragDropData.fObject);
                            fAction = FDragDropAction.Set;

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Storage)
                    {
                        #region Storage

                        if (fDragDropData.fObject.fObjectType == FObjectType.Repository)
                        {
                            #region Repository

                            ((FStorage)fRefObject).setRepository((FRepository)fDragDropData.fObject);
                            fAction = FDragDropAction.Set;

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Callback)
                    {
                        #region Callback

                        if (fDragDropData.fObject.fObjectType == FObjectType.Function)
                        {
                            #region Function

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FFunction)fDragDropData.fObject).moveTo((FCallback)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FFunction)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FCallback)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.FunctionName)
                        {
                            #region FunctionName

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fChildObject = ((FCallback)fRefObject).appendChildFunction(new FFunction(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                                ((FFunction)fChildObject).functionName = ((FFunctionName)fDragDropData.fObject).name;
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Function)
                    {
                        #region Function

                        if (fDragDropData.fObject.fObjectType == FObjectType.Function)
                        {
                            #region Function

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FFunction)fDragDropData.fObject).moveTo((FFunction)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FFunction)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FFunction)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.FunctionName)
                        {
                            #region FunctionName

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FFunction)fRefObject).functionName = ((FFunctionName)fDragDropData.fObject).name;
                                fAction = FDragDropAction.Set;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.Branch)
                    {
                        #region Branch

                        if (fDragDropData.fObject.fObjectType == FObjectType.Scenario)
                        {
                            #region Scenario

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FBranch)fRefObject).setLocation((FScenario)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else
                    {
                        return;
                    }

                    #endregion
                }
                else
                {
                    return;
                }

                // --

                tvwFlow.beginUpdate();

                // --

                if (fAction == FDragDropAction.Move || fAction == FDragDropAction.Copy)
                {
                    #region Move or Copy

                    uniqueId = fDragDropData.fObject.uniqueIdToString;
                    tNode = tvwFlow.GetNodeByKey(uniqueId);
                    if (tNode != null)
                    {
                        tParentNode = tNode.Parent;
                        tNode.Remove();
                    }
                    tNode = new UltraTreeNode(uniqueId);
                    tNode.Tag = fDragDropData.fObject;
                    FCommon.refreshTreeNodeOfObject(fDragDropData.fObject, tvwFlow, tNode);
                    loadTreeOfChildFlow(tNode);

                    // --

                    refUniqueId = fRefObject.uniqueIdToString;
                    tRefNode = tvwFlow.GetNodeByKey(refUniqueId);
                    if (fRefObject.fObjectType == fDragDropData.fObject.fObjectType)
                    {
                        tRefNode.Parent.Nodes.Insert(tRefNode.Index + 1, tNode);
                    }
                    else
                    {
                        tRefNode.Nodes.Add(tNode);
                    }
                    // --
                    tvwFlow.SelectedNodes.Clear();
                    tvwFlow.ActiveNode = tNode;

                    // --

                    if (
                        fDragDropData.fObject.fObjectType == FObjectType.SecsExpression ||
                        fDragDropData.fObject.fObjectType == FObjectType.HostExpression ||
                        fDragDropData.fObject.fObjectType == FObjectType.JudgementExpression
                        )
                    {
                        if (tParentNode != null && tParentNode.Nodes.Count > 0)
                        {
                            tNode = tParentNode.Nodes[0];
                            FCommon.refreshTreeNodeOfObject((FIObject)tNode.Tag, tvwFlow, tNode);
                        }
                    }

                    #endregion
                }
                else if (fAction == FDragDropAction.Set)
                {
                    #region Set

                    if (
                        (fRefObject.fObjectType == FObjectType.SecsCondition && fDragDropData.fObject.fObjectType == FObjectType.SecsDevice) ||
                        (fRefObject.fObjectType == FObjectType.SecsCondition && fDragDropData.fObject.fObjectType == FObjectType.SecsMessage) ||
                        fRefObject.fObjectType == FObjectType.SecsExpression ||
                        fRefObject.fObjectType == FObjectType.SecsTransfer ||
                        (fRefObject.fObjectType == FObjectType.HostCondition && fDragDropData.fObject.fObjectType == FObjectType.HostDevice) ||
                        (fRefObject.fObjectType == FObjectType.HostCondition && fDragDropData.fObject.fObjectType == FObjectType.HostMessage) ||
                        fRefObject.fObjectType == FObjectType.HostExpression ||
                        fRefObject.fObjectType == FObjectType.HostTransfer ||
                        (fRefObject.fObjectType == FObjectType.Judgement && fDragDropData.fObject.fObjectType == FObjectType.Scenario) ||
                        (fRefObject.fObjectType == FObjectType.JudgementCondition && fDragDropData.fObject.fObjectType == FObjectType.DataSet) ||
                        fRefObject.fObjectType == FObjectType.JudgementExpression ||
                        (fRefObject.fObjectType == FObjectType.EquipmentStateSetAlterer && fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSet) ||
                        fRefObject.fObjectType == FObjectType.EquipmentStateAlterer ||
                        fRefObject.fObjectType == FObjectType.Mapper ||
                        fRefObject.fObjectType == FObjectType.Storage ||
                        fRefObject.fObjectType == FObjectType.Function
                        )
                    {
                        tRefNode = tvwFlow.GetNodeByKey(fRefObject.uniqueIdToString);
                        if (tRefNode != null)
                        {
                            tvwFlow.SelectedNodes.Clear();
                            tvwFlow.ActiveNode = tRefNode;
                        }
                    }
                    else if (
                        fRefObject.fObjectType == FObjectType.SecsTrigger ||
                        (fRefObject.fObjectType == FObjectType.SecsCondition && fDragDropData.fObject.fObjectType == FObjectType.SecsItem) ||
                        (fRefObject.fObjectType == FObjectType.SecsCondition && fDragDropData.fObject.fObjectType == FObjectType.EquipmentState) ||
                        (fRefObject.fObjectType == FObjectType.SecsCondition && fDragDropData.fObject.fObjectType == FObjectType.Environment) ||
                        fRefObject.fObjectType == FObjectType.SecsTransmitter ||
                        fRefObject.fObjectType == FObjectType.HostTrigger ||
                        (fRefObject.fObjectType == FObjectType.HostCondition && fDragDropData.fObject.fObjectType == FObjectType.HostItem) ||
                        (fRefObject.fObjectType == FObjectType.HostCondition && fDragDropData.fObject.fObjectType == FObjectType.EquipmentState) ||
                        (fRefObject.fObjectType == FObjectType.HostCondition && fDragDropData.fObject.fObjectType == FObjectType.Environment) ||
                        fRefObject.fObjectType == FObjectType.HostTransmitter ||
                        (fRefObject.fObjectType == FObjectType.EquipmentStateSetAlterer && fDragDropData.fObject.fObjectType == FObjectType.EquipmentState) ||
                        (fRefObject.fObjectType == FObjectType.Judgement && fDragDropData.fObject.fObjectType == FObjectType.DataSet) ||
                        (fRefObject.fObjectType == FObjectType.JudgementCondition && fDragDropData.fObject.fObjectType == FObjectType.Data) ||
                        fRefObject.fObjectType == FObjectType.Callback
                        )
                    {
                        tParentNode = tvwFlow.GetNodeByKey(fRefObject.uniqueIdToString);
                        if (tParentNode != null)
                        {
                            tNode = tvwFlow.GetNodeByKey(fChildObject.uniqueIdToString);
                            if (tNode == null)
                            {
                                tNode = new UltraTreeNode(fChildObject.uniqueIdToString);
                                tNode.Tag = fChildObject;
                                FCommon.refreshTreeNodeOfObject(fChildObject, tvwFlow, tNode);
                                // --
                                tParentNode.Nodes.Add(tNode);
                            }
                            tvwFlow.SelectedNodes.Clear();
                            tvwFlow.ActiveNode = tNode;
                        }
                    }

                    #endregion
                }

                // --

                tvwFlow.endUpdate();
            }
            catch (Exception ex)
            {
                tvwFlow.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fDragDropData = null;
                tRefNode = null;
                tNode = null;
                tParentNode = null;
                fRefObject = null;
                fDevice = null;
                fSession = null;
                fChildObject = null;
            }
        }

        #endregion                        
                
        //------------------------------------------------------------------------------------------------------------------------

        #region rstFlowToolbar Control Event handler

        private void rstFlowToolbar_SearchRequested(
            object sender, 
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                procMenuSearchFlow(e.searchWord);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region pgdProp Control Event Handler

        private void pgdProp_Leave(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                flowContHost.Focus();                    
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end