/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEquipmentModeler.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.25
--  Description     : FAMate OPC Modeler Equipment Modeler Form Class 
--  History         : Created by Jeff.Kim at 2013.07.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinToolbars;

namespace Nexplant.MC.OpcModeler
{
    public partial class FEquipmentModeler : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private FEventHandler m_fEventHandler = null;
        private FIObject m_fActiveObject = null;
        private Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl m_fDragDropOldRefFlowCtrl = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEquipmentModeler(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentModeler(
            FOpmCore fOpmCore
            )
            : this()
        {
            base.fUIWizard = fOpmCore.fUIWizard;
            m_fOpmCore = fOpmCore;
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
                    m_fOpmCore = null;
                    m_fActiveObject = null;
                    m_fDragDropOldRefFlowCtrl = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

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

        private void designTreeOfScenario(
            )
        {
            try
            {
                tvwScenario.ImageList = new ImageList();
                // --
                tvwScenario.ImageList.Images.Add("OpcDriver", Properties.Resources.OpcDriver);
                tvwScenario.ImageList.Images.Add("Equipment_unlock", Properties.Resources.Equipment_unlock);
                tvwScenario.ImageList.Images.Add("Equipment_lock", Properties.Resources.Equipment_lock);
                tvwScenario.ImageList.Images.Add("ScenarioGroup_unlock", Properties.Resources.ScenarioGroup_unlock);
                tvwScenario.ImageList.Images.Add("ScenarioGroup_lock", Properties.Resources.ScenarioGroup_lock);
                tvwScenario.ImageList.Images.Add("Scenario_unlock", Properties.Resources.Scenario_unlock);
                tvwScenario.ImageList.Images.Add("Scenario_lock", Properties.Resources.Scenario_lock);
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

        private void designTreeOfFlow(
            )
        {
            try
            {
                tvwFlow.ImageList = new ImageList();
                // --
                tvwFlow.ImageList.Images.Add("OpcTrigger", Properties.Resources.OpcTrigger);
                tvwFlow.ImageList.Images.Add("OpcCondition_Expression", Properties.Resources.OpcCondition_Expression);
                tvwFlow.ImageList.Images.Add("OpcCondition_Connection_Closed", Properties.Resources.OpcCondition_Connection_Closed);
                tvwFlow.ImageList.Images.Add("OpcCondition_Connection_Opened", Properties.Resources.OpcCondition_Connection_Opened);
                tvwFlow.ImageList.Images.Add("OpcCondition_Connection_Connected", Properties.Resources.OpcCondition_Connection_Connected);
                tvwFlow.ImageList.Images.Add("OpcCondition_Connection_Selected", Properties.Resources.OpcCondition_Connection_Selected);
                tvwFlow.ImageList.Images.Add("OpcCondition_Connection_Error", Properties.Resources.OpcCondition_Connection_Error);
                tvwFlow.ImageList.Images.Add("OpcExpression_Bracket", Properties.Resources.OpcExpression_Bracket);
                tvwFlow.ImageList.Images.Add("OpcExpression_Comparison_Value_EquipmentState", Properties.Resources.OpcExpression_Comparison_Value_EquipmentState);
                tvwFlow.ImageList.Images.Add("OpcExpression_Comparison_Value_Environment", Properties.Resources.OpcExpression_Comparison_Value_Environment);
                tvwFlow.ImageList.Images.Add("OpcExpression_Comparison_Value_Item", Properties.Resources.OpcExpression_Comparison_Value_Item);
                tvwFlow.ImageList.Images.Add("OpcExpression_Comparison_Length_Environment", Properties.Resources.OpcExpression_Comparison_Length_Environment);
                tvwFlow.ImageList.Images.Add("OpcExpression_Comparison_Length_Item", Properties.Resources.OpcExpression_Comparison_Length_Item);
                tvwFlow.ImageList.Images.Add("OpcTransmitter", Properties.Resources.OpcTransmitter);
                tvwFlow.ImageList.Images.Add("OpcTransfer", Properties.Resources.OpcTransfer);
                tvwFlow.ImageList.Images.Add("HostTrigger", Properties.Resources.HostTrigger);
                tvwFlow.ImageList.Images.Add("HostCondition_Expression", Properties.Resources.HostCondition_Expression);
                tvwFlow.ImageList.Images.Add("HostCondition_Timeout", Properties.Resources.HostCondition_Timeout);
                tvwFlow.ImageList.Images.Add("HostExpression_Bracket", Properties.Resources.HostExpression_Bracket);
                tvwFlow.ImageList.Images.Add("HostExpression_Comparison_Length_Environment", Properties.Resources.HostExpression_Comparison_Length_Environment);
                tvwFlow.ImageList.Images.Add("HostExpression_Comparison_Length_HostItem", Properties.Resources.HostExpression_Comparison_Length_HostItem);
                tvwFlow.ImageList.Images.Add("HostExpression_Comparison_Value_EquipmentState", Properties.Resources.HostExpression_Comparison_Value_EquipmentState);
                tvwFlow.ImageList.Images.Add("HostExpression_Comparison_Value_Environment", Properties.Resources.HostExpression_Comparison_Value_Environment);
                tvwFlow.ImageList.Images.Add("HostExpression_Comparison_Value_HostItem", Properties.Resources.HostExpression_Comparison_Value_HostItem);
                tvwFlow.ImageList.Images.Add("OpcTransmitter", Properties.Resources.OpcTransmitter);
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
                        t.Key == FMenuKey.MenuEqmExpand ||
                        t.Key == FMenuKey.MenuEqmCollapse ||
                        t.Key == FMenuKey.MenuEqmRelation
                        )
                    {
                        continue;
                    }
                    else if (
                        t.Key == FMenuKey.MenuEqmRemove ||
                        t.Key == FMenuKey.MenuEqmReplace ||
                        t.Key == FMenuKey.MenuEqmCopy ||
                        t.Key == FMenuKey.MenuEqmCut ||
                        t.Key == FMenuKey.MenuEqmPasteChild ||
                        t.Key == FMenuKey.MenuEqmPasteSibling ||
                        t.Key == FMenuKey.MenuEqmMoveDown ||
                        t.Key == FMenuKey.MenuEqmMoveUp
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

                if (m_fActiveObject.fObjectType == FObjectType.OpcDriver)
                {
                    mnuMenu.Tools[FMenuKey.MenuEqmAppendEquipment].SharedProps.Visible = ((FOpcDriver)m_fActiveObject).canAppendChildEquipment;
                    // -- 
                    mnuMenu.Tools[FMenuKey.MenuEqmPasteChild].SharedProps.Enabled = ((FOpcDriver)m_fActiveObject).canPasteChildEquipment;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.Equipment)
                {
                    mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeEquipment].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterEquipment].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuEqmAppendScenarioGroup].SharedProps.Visible = m_fActiveObject.canAppendChild;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.ScenarioGroup)
                {
                    mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeScenarioGroup].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterScenarioGroup].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuEqmAppendScenario].SharedProps.Visible = m_fActiveObject.canAppendChild;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.Scenario)
                {
                    mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeScenario].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterScenario].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuEqmScenarioModeler].SharedProps.Visible = true;
                }

                // --

                if (m_fActiveObject.fObjectType == FObjectType.Equipment ||
                    m_fActiveObject.fObjectType == FObjectType.ScenarioGroup
                   )
                {
                    mnuMenu.Tools[FMenuKey.MenuEqmExpand].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuEqmCollapse].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuEqmCopy].SharedProps.Enabled = m_fActiveObject.canCopy;
                    mnuMenu.Tools[FMenuKey.MenuEqmCut].SharedProps.Enabled = m_fActiveObject.canCut;
                    mnuMenu.Tools[FMenuKey.MenuEqmPasteSibling].SharedProps.Enabled = m_fActiveObject.canPasteSibling;
                    mnuMenu.Tools[FMenuKey.MenuEqmPasteChild].SharedProps.Enabled = m_fActiveObject.canPasteChild;
                    mnuMenu.Tools[FMenuKey.MenuEqmMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                    mnuMenu.Tools[FMenuKey.MenuEqmMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;                    
                    mnuMenu.Tools[FMenuKey.MenuEqmRemove].SharedProps.Enabled = m_fActiveObject.canRemove;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.Scenario)
                {
                    mnuMenu.Tools[FMenuKey.MenuEqmExpand].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuEqmCollapse].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuEqmCopy].SharedProps.Enabled = m_fActiveObject.canCopy;
                    mnuMenu.Tools[FMenuKey.MenuEqmCut].SharedProps.Enabled = m_fActiveObject.canCut;
                    mnuMenu.Tools[FMenuKey.MenuEqmPasteSibling].SharedProps.Enabled = m_fActiveObject.canPasteSibling;
                    mnuMenu.Tools[FMenuKey.MenuEqmPasteChild].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuEqmMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                    mnuMenu.Tools[FMenuKey.MenuEqmMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;
                    mnuMenu.Tools[FMenuKey.MenuEqmRemove].SharedProps.Enabled = m_fActiveObject.canRemove;
                }

                // --

                // ***
                // 2016.04.26 by spike.lee
                // Replace Menu 제어
                // ***
                if (m_fActiveObject.fObjectType == FObjectType.Scenario)
                {
                    mnuMenu.Tools[FMenuKey.MenuEqmReplace].SharedProps.Enabled = true;
                }

                // ***
                // 2016.04.26 by spike.lee
                // Clone Menu 제어
                // ***
                if (
                    m_fActiveObject.fObjectType == FObjectType.Equipment ||
                    m_fActiveObject.fObjectType == FObjectType.ScenarioGroup ||
                    m_fActiveObject.fObjectType == FObjectType.Scenario
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuEqmClone].SharedProps.Visible = true;
                }
                
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

        private void controlMenuOfScenario(
            )
        {
            try
            {
                mnuMenu.beginUpdate();

                // --

                foreach (ToolBase t in mnuMenu.Tools)
                {
                    if (
                        t.Key == FMenuKey.MenuEqmExpand ||
                        t.Key == FMenuKey.MenuEqmCollapse ||
                        t.Key == FMenuKey.MenuEqmRelation
                        )
                    {
                        continue;
                    }
                    else if (
                        t.Key == FMenuKey.MenuEqmRemove ||
                        t.Key == FMenuKey.MenuEqmWriteOpcMessage ||
                        t.Key == FMenuKey.MenuEqmSendHostMessage ||
                        t.Key == FMenuKey.MenuEqmReplace ||
                        t.Key == FMenuKey.MenuEqmCopy ||
                        t.Key == FMenuKey.MenuEqmCut ||
                        t.Key == FMenuKey.MenuEqmPasteChild ||
                        t.Key == FMenuKey.MenuEqmPasteSibling ||
                        t.Key == FMenuKey.MenuEqmMoveDown ||
                        t.Key == FMenuKey.MenuEqmMoveUp
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
                    mnuMenu.Tools[FMenuKey.MenuEqmWriteOpcMessage].SharedProps.Visible = false;
                    mnuMenu.Tools[FMenuKey.MenuEqmExpand].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuEqmCollapse].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuEqmCut].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuEqmCopy].SharedProps.Enabled = m_fActiveObject.canCopy;
                    mnuMenu.Tools[FMenuKey.MenuEqmPasteSibling].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuEqmPasteChild].SharedProps.Enabled = m_fActiveObject.canPasteChild;
                    mnuMenu.Tools[FMenuKey.MenuEqmRemove].SharedProps.Enabled = m_fActiveObject.canRemove;//false;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuEqmAppendOpcTrigger].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuEqmAppendOpcTransmitter].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuEqmAppendHostTrigger].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuEqmAppendHostTransmitter].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuEqmAppendEquipmentStateSetAlterer].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuEqmAppendJudgement].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuEqmAppendMapper].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuEqmAppendStorage].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuEqmAppendCallback].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuEqmAppendBranch].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuEqmAppendComment].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuEqmAppendPauser].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuEqmAppendEntryPoint].SharedProps.Visible = true;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuEqmExpand].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuEqmCollapse].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuEqmCut].SharedProps.Enabled = m_fActiveObject.canCut;
                    mnuMenu.Tools[FMenuKey.MenuEqmCopy].SharedProps.Enabled = m_fActiveObject.canCopy;
                    mnuMenu.Tools[FMenuKey.MenuEqmPasteSibling].SharedProps.Enabled = m_fActiveObject.canPasteSibling;
                    mnuMenu.Tools[FMenuKey.MenuEqmPasteChild].SharedProps.Enabled = m_fActiveObject.canPasteChild;
                    mnuMenu.Tools[FMenuKey.MenuEqmRemove].SharedProps.Enabled = m_fActiveObject.canRemove;
                    // --
                    if (
                        m_fActiveObject.fObjectType == FObjectType.OpcTrigger ||
                        m_fActiveObject.fObjectType == FObjectType.OpcTransmitter ||
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
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeOpcTrigger].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterOpcTrigger].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeOpcTransmitter].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterOpcTransmitter].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeHostTrigger].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterHostTrigger].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeHostTransmitter].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterHostTransmitter].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeEquipmentStateSetAlterer].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterEquipmentStateSetAlterer].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeJudgement].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterJudgement].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeMapper].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterMapper].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeStorage].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterStorage].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeCallback].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterCallback].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeBranch].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterBranch].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeComment].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterComment].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforePauser].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterPauser].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeEntryPoint].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterEntryPoint].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmWriteOpcMessage].SharedProps.Visible = false;
                        mnuMenu.Tools[FMenuKey.MenuEqmSendHostMessage].SharedProps.Visible = false;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;

                        // --

                        if (m_fActiveObject.fObjectType == FObjectType.OpcTrigger)
                        {
                            mnuMenu.Tools[FMenuKey.MenuEqmAppendOpcCondition].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        }
                        else if (m_fActiveObject.fObjectType == FObjectType.OpcTransmitter)
                        {
                            mnuMenu.Tools[FMenuKey.MenuEqmAppendOpcTransfer].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        }
                        else if (m_fActiveObject.fObjectType == FObjectType.HostTrigger)
                        {
                            mnuMenu.Tools[FMenuKey.MenuEqmAppendHostCondition].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        }
                        else if (m_fActiveObject.fObjectType == FObjectType.HostTransmitter)
                        {
                            mnuMenu.Tools[FMenuKey.MenuEqmAppendHostTransfer].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        }
                        else if (m_fActiveObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                        {
                            mnuMenu.Tools[FMenuKey.MenuEqmAppendEquipmentStateAlterer].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        }
                        else if (m_fActiveObject.fObjectType == FObjectType.Judgement)
                        {
                            mnuMenu.Tools[FMenuKey.MenuEqmAppendJudgementCondition].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        }
                        else if (m_fActiveObject.fObjectType == FObjectType.Callback)
                        {
                            mnuMenu.Tools[FMenuKey.MenuEqmAppendFunction].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        }
                    }
                    else if (m_fActiveObject.fObjectType == FObjectType.OpcCondition)
                    {
                        mnuMenu.Tools[FMenuKey.MenuEqmApplyOsmFiles].SharedProps.Visible = true;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeOpcCondition].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterOpcCondition].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmAppendOpcExpression].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;
                    }
                    else if (m_fActiveObject.fObjectType == FObjectType.OpcExpression)
                    {
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeOpcExpression].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterOpcExpression].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmAppendOpcExpression].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;
                    }
                    else if (m_fActiveObject.fObjectType == FObjectType.OpcTransfer)
                    {
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeOpcTransfer].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterOpcTransfer].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmWriteOpcMessage].SharedProps.Visible = true;
                        // --
                        if (((FOpcTransfer)tvwFlow.ActiveNode.Tag).fMessage != null)
                        {
                            if (((FOpcTransfer)tvwFlow.ActiveNode.Tag).fDevice.fState == FDeviceState.Selected)
                            {
                                mnuMenu.Tools[FMenuKey.MenuEqmWriteOpcMessage].SharedProps.Enabled = true;
                            }
                        }
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;
                    }
                    else if (m_fActiveObject.fObjectType == FObjectType.HostCondition)
                    {
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeHostCondition].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterHostCondition].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmAppendHostExpression].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;
                    }
                    else if (m_fActiveObject.fObjectType == FObjectType.HostExpression)
                    {
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeHostExpression].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterHostExpression].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmAppendHostExpression].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;
                    }
                    else if (m_fActiveObject.fObjectType == FObjectType.HostTransfer)
                    {
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeHostTransfer].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterHostTransfer].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmSendHostMessage].SharedProps.Visible = true;
                        // --
                        if (((FHostTransfer)tvwFlow.ActiveNode.Tag).fMessage != null)
                        {
                            if (((FHostTransfer)tvwFlow.ActiveNode.Tag).fDevice.fState == FDeviceState.Selected)
                            {
                                mnuMenu.Tools[FMenuKey.MenuEqmSendHostMessage].SharedProps.Enabled = true;
                            }
                        }
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;
                    }
                    else if (m_fActiveObject.fObjectType == FObjectType.EquipmentStateAlterer)
                    {
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeEquipmentStateAlterer].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterEquipmentStateAlterer].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;
                    }
                    else if (m_fActiveObject.fObjectType == FObjectType.JudgementCondition)
                    {
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeJudgementCondition].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterJudgementCondition].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmAppendJudgementExpression].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;
                    }
                    else if (m_fActiveObject.fObjectType == FObjectType.JudgementExpression)
                    {
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeJudgementExpression].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterJudgementExpression].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmAppendJudgementExpression].SharedProps.Visible = m_fActiveObject.canAppendChild;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;
                    }
                    else if (m_fActiveObject.fObjectType == FObjectType.Function)
                    {
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertBeforeFunction].SharedProps.Visible = m_fActiveObject.canInsertBefore;
                        mnuMenu.Tools[FMenuKey.MenuEqmInsertAfterFunction].SharedProps.Visible = m_fActiveObject.canInsertAfter;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveUp].SharedProps.Enabled = m_fActiveObject.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuEqmMoveDown].SharedProps.Enabled = m_fActiveObject.canMoveDown;
                    }
                }

                // --

                mnuMenu.Tools[FMenuKey.MenuEqmInsertBefore].SharedProps.Visible = haveVisibleTools((PopupMenuTool)(mnuMenu.Tools[FMenuKey.MenuEqmInsertBefore]));
                mnuMenu.Tools[FMenuKey.MenuEqmInsertAfter].SharedProps.Visible = haveVisibleTools((PopupMenuTool)(mnuMenu.Tools[FMenuKey.MenuEqmInsertAfter]));

                // --

                // ***
                // 2016.04.26 by spike.lee
                // Replace Menu 제어
                // ***
                if (m_fActiveObject.fObjectType != FObjectType.Equipment && m_fActiveObject.fObjectType != FObjectType.ScenarioGroup)
                {
                    mnuMenu.Tools[FMenuKey.MenuEqmReplace].SharedProps.Enabled = true;
                }

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

        private bool haveVisibleTools(
            PopupMenuTool popupTool
            )
        {
            try
            {
                foreach(ToolBase t in popupTool.Tools)
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

        private void loadTreeOfObject(
            )
        {
            FOpcDriver fOcd = null;
            UltraTreeNode tNodeOcd = null;
            UltraTreeNode tNodeEqp = null;
            UltraTreeNode tNodeSng = null;
            UltraTreeNode tNodeSnr = null;            

            try
            {
                tvwScenario.beginUpdate();

                // --

                // ***
                // OPC Driver Load
                // ***
                fOcd = m_fOpmCore.fOpmFileInfo.fOpcDriver;
                tNodeOcd = new UltraTreeNode(fOcd.uniqueIdToString);
                tNodeOcd.Tag = fOcd;
                FCommon.refreshTreeNodeOfObject(fOcd, tvwScenario, tNodeOcd);

                // --

                // ***
                // Equipment Load
                // ***
                foreach (FEquipment fEqp in fOcd.fChildEquipmentCollection)
                {
                    tNodeEqp = new UltraTreeNode(fEqp.uniqueIdToString);
                    tNodeEqp.Tag = fEqp;
                    FCommon.refreshTreeNodeOfObject(fEqp, tvwScenario, tNodeEqp);

                    // --

                    // ***
                    // Scenario Group Load
                    // ***
                    foreach (FScenarioGroup fSng in fEqp.fChildScenarioGroupCollection)
                    {
                        tNodeSng = new UltraTreeNode(fSng.uniqueIdToString);
                        tNodeSng.Tag = fSng;
                        FCommon.refreshTreeNodeOfObject(fSng, tvwScenario, tNodeSng);

                        // --

                        // ***
                        // Scenario Load
                        // ***
                        foreach (FScenario fSnr in fSng.fChildScenarioCollection)
                        {
                            tNodeSnr = new UltraTreeNode(fSnr.uniqueIdToString);
                            tNodeSnr.Tag = fSnr;
                            FCommon.refreshTreeNodeOfObject(fSnr, tvwScenario, tNodeSnr);
                            
                            // --
                            
                            tNodeSng.Nodes.Add(tNodeSnr);
                        }

                        tNodeSng.Expanded = true;
                        tNodeEqp.Nodes.Add(tNodeSng);
                    }

                    // --

                    tNodeEqp.Expanded = true;
                    tNodeOcd.Nodes.Add(tNodeEqp);
                }

                // --

                tNodeOcd.Expanded = true;
                tvwScenario.Nodes.Add(tNodeOcd);
                tvwScenario.ActiveNode = tNodeOcd;

                // --

                tvwScenario.endUpdate();
            }
            catch (Exception ex)
            {
                tvwScenario.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fOcd = null;
                tNodeOcd = null;
                tNodeEqp = null;
                tNodeSng = null;
                tNodeSnr = null;                
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfChildObject(
            UltraTreeNode tNodeParent
            )
        {
            FIObject fParent = null;
            UltraTreeNode tNodeChild = null;

            try
            {
                tvwScenario.beginUpdate();

                // --

                fParent = (FIObject)tNodeParent.Tag;
                // --
                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    foreach (FEquipment fEqp in ((FOpcDriver)fParent).fChildEquipmentCollection)
                    {
                        tNodeChild = new UltraTreeNode(fEqp.uniqueIdToString);
                        tNodeChild.Tag = fEqp;
                        FCommon.refreshTreeNodeOfObject(fEqp, tvwScenario, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.Equipment)
                {
                    foreach (FScenarioGroup fSng in ((FEquipment)fParent).fChildScenarioGroupCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSng.uniqueIdToString);
                        tNodeChild.Tag = fSng;
                        FCommon.refreshTreeNodeOfObject(fSng, tvwScenario, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.ScenarioGroup)
                {
                    foreach (FScenario fSnr in ((FScenarioGroup)fParent).fChildScenarioCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSnr.uniqueIdToString);
                        tNodeChild.Tag = fSnr;
                        FCommon.refreshTreeNodeOfObject(fSnr, tvwScenario, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }                

                // --

                tvwScenario.endUpdate();
            }
            catch (Exception ex)
            {
                tvwScenario.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
                tNodeChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void addTreeOfObject(
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
                tNodeNewChild = tvwScenario.GetNodeByKey(fNewChild.uniqueIdToString);
                if (tNodeNewChild != null)
                {
                    return;
                }

                // --

                if (fNewChild.fObjectType == FObjectType.Equipment)
                {
                    tNodeParent = tvwScenario.GetNodeByKey(fParent.uniqueIdToString);                    
                    fRefChild = ((FEquipment)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.ScenarioGroup)
                {
                    tNodeParent = tvwScenario.GetNodeByKey(fParent.uniqueIdToString);
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
                    fRefChild = ((FScenarioGroup)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.Scenario)
                {
                    tNodeParent = tvwScenario.GetNodeByKey(fParent.uniqueIdToString);
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
                    fRefChild = ((FScenario)fNewChild).fNextSibling;
                }                
                else
                {
                    return;
                }

                // --

                tvwScenario.beginUpdate();

                // --

                tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwScenario, tNodeNewChild);

                // --

                if (fRefChild != null)
                {
                    tNodeRefChild = tvwScenario.GetNodeByKey(fRefChild.uniqueIdToString);
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

                loadTreeOfChildObject(tNodeNewChild);

                // --

                tvwScenario.endUpdate();
            }
            catch (Exception ex)
            {
                tvwScenario.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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

        private void removeTreeOfObject(
            FIObject fChild
            )
        {
            UltraTreeNode tNodeChild = null;
            UltraTreeNode tNodeParent = null;

            try
            {
                tNodeChild = tvwScenario.GetNodeByKey(fChild.uniqueIdToString);
                if (tNodeChild == null)
                {
                    return;
                }
                // --
                tNodeParent = tNodeChild.Parent;

                // --

                tvwScenario.beginUpdate();

                // --

                tNodeChild.Remove();

                // --

                if (tNodeParent.Nodes.Count == 0)
                {
                    tvwScenario.ActiveNode = tNodeParent;
                }

                // --

                tvwScenario.endUpdate();
            }
            catch (Exception ex)
            {
                tvwScenario.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeChild = null;
                tNodeParent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshObject(
            FIObject fObject
            )
        {
            UltraTreeNode tNode = null;

            try
            {
                tNode = tvwScenario.GetNodeByKey(fObject.uniqueIdToString);
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

                tvwScenario.beginUpdate();
                FCommon.refreshTreeNodeOfObject(fObject, tvwScenario, tNode);
                tvwScenario.endUpdate();

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                tvwScenario.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuApplyOSMFiles(
            )
        {
            UltraTreeNode tNode = null;
            FIObject fObject = null;

            try
            {
                tNode = tvwFlow.ActiveNode;
                fObject = (FIObject)tNode.Tag;

                // --

                if (fObject.fObjectType == FObjectType.OpcCondition)
                {
                    ((FOpcCondition)fObject).forceCopy();
                    // --
                    m_fOpmCore.fOpmContainer.procMenuApplyOSMFiles();
                }

                // --
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

        private void procMenuAppendObject(
            string menuKey
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeNewChild = null;
            FIObject fParent = null;
            FIObject fNewChild = null;

            try
            {
                tvwScenario.beginUpdate();

                // --

                tNodeParent = tvwScenario.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fNewChild = ((FOpcDriver)fParent).appendChildEquipment(new FEquipment(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.Equipment)
                {
                    fNewChild = ((FEquipment)fParent).appendChildScenarioGroup(new FScenarioGroup(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.ScenarioGroup)
                {
                    fNewChild = ((FScenarioGroup)fParent).appendChildScenario(new FScenario(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }                

                // --

                tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwScenario, tNodeNewChild);                
                // --
                tNodeParent.Nodes.Add(tNodeNewChild);
                tvwScenario.SelectedNodes.Clear();
                tvwScenario.ActiveNode = tNodeNewChild;

                // --

                tvwScenario.endUpdate();
            }
            catch (Exception ex)
            {
                tvwScenario.endUpdate();
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

        private void procMenuInsertBeforeObject(
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
                tvwScenario.beginUpdate();

                // --

                tNodeRefChild = tvwScenario.ActiveNode;
                tNodeParent = tNodeRefChild.Parent;
                fRefChild = (FIObject)tNodeRefChild.Tag;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fNewChild = ((FOpcDriver)fParent).insertBeforeChildEquipment(
                        new FEquipment(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FEquipment)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.Equipment)
                {
                    fNewChild = ((FEquipment)fParent).insertBeforeChildScenarioGroup(
                        new FScenarioGroup(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FScenarioGroup)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.ScenarioGroup)
                {
                    fNewChild = ((FScenarioGroup)fParent).insertBeforeChildScenario(
                        new FScenario(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FScenario)fRefChild
                        );
                }                

                // --

                tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwScenario, tNodeNewChild);
                tNodeParent.Nodes.Insert(tNodeRefChild.Index, tNodeNewChild);
                // --
                tvwScenario.SelectedNodes.Clear();
                tvwScenario.ActiveNode = tNodeNewChild;

                // --

                tvwScenario.endUpdate();
            }
            catch (Exception ex)
            {
                tvwScenario.endUpdate();
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

        private void procMenuInsertAfterObject(
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
                tvwScenario.beginUpdate();

                // --

                tNodeRefChild = tvwScenario.ActiveNode;
                tNodeParent = tNodeRefChild.Parent;
                fRefChild = (FIObject)tNodeRefChild.Tag;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fNewChild = ((FOpcDriver)fParent).insertAfterChildEquipment(
                        new FEquipment(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FEquipment)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.Equipment)
                {
                    fNewChild = ((FEquipment)fParent).insertAfterChildScenarioGroup(
                        new FScenarioGroup(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FScenarioGroup)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.ScenarioGroup)
                {
                    fNewChild = ((FScenarioGroup)fParent).insertAfterChildScenario(
                        new FScenario(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FScenario)fRefChild
                        );
                }                         

                // --

                tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwScenario, tNodeNewChild);
                tNodeParent.Nodes.Insert(tNodeRefChild.Index + 1, tNodeNewChild);
                // --
                tvwScenario.SelectedNodes.Clear();
                tvwScenario.ActiveNode = tNodeNewChild;

                // --

                tvwScenario.endUpdate();
            }
            catch (Exception ex)
            {
                tvwScenario.endUpdate();
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

        private void procMenuRemoveObject(
            )
        {
            UltraTreeNode tNodeParent = null;
            FIObject fParent = null;
            FIObject fChild = null;
            FIObject[] fChilds = null;
            DialogResult dialogResult;

            try
            {
                tvwScenario.ActiveNode.Selected = true;
                tNodeParent = tvwScenario.ActiveNode.Parent;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                // ***
                // Removing OPC Object Validate
                // ***
                if (fParent.fObjectType == FObjectType.Equipment)
                {
                    foreach (UltraTreeNode tNode in tvwScenario.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FScenarioGroup)fChild).locked)
                        {
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.ScenarioGroup)
                {
                    foreach (UltraTreeNode tNode in tvwScenario.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FScenario)fChild).locked)
                        {
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }                 

                // --

                // ***
                // Remove OPC Object가 1개 이상일 경우 사용자에게 Confirm를 받는다.
                // ***
                if (tvwScenario.SelectedNodes.Count > 1)
                {
                    dialogResult = FMessageBox.showQuestion(
                        FConstants.ApplicationName,
                        m_fOpmCore.fWsmCore.fUIWizard.generateMessage("Q0004", new object[] { "Object" }),
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button2,
                        m_fOpmCore.fWsmCore.fWsmContainer
                        );
                    if (dialogResult == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }

                // --

                // ***
                // OPC Object Remove
                // ***
                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fChilds = new FEquipment[tvwScenario.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwScenario.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FEquipment)tvwScenario.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FOpcDriver)fParent).removeChildEquipment((FEquipment[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.Equipment)
                {
                    fChilds = new FScenarioGroup[tvwScenario.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwScenario.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FScenarioGroup)tvwScenario.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FEquipment)fParent).removeChildScenarioGroup((FScenarioGroup[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.ScenarioGroup)
                {
                    fChilds = new FScenario[tvwScenario.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwScenario.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FScenario)tvwScenario.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FScenarioGroup)fParent).removeChildScenario((FScenario[])fChilds);
                }                

                // --

                tvwScenario.beginUpdate();

                // --

                foreach (FIObject f in fChilds)
                {
                    tvwScenario.GetNodeByKey(f.uniqueIdToString).Remove();
                }

                // --

                if (tNodeParent.Nodes.Count == 0)
                {
                    tvwScenario.ActiveNode = tNodeParent;
                }

                // --

                tvwScenario.endUpdate();
            }
            catch (Exception ex)
            {
                tvwScenario.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeParent = null;
                fParent = null;
                fChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuScenarioDesigner(
           )
        {
            FScenarioDesigner fScenarioDesigner = null;
            FScenario fSnr = null;

            try
            {
                fSnr = (FScenario)tvwScenario.ActiveNode.Tag;
                foreach (FBaseTabChildForm f in m_fOpmCore.fOpmContainer.fChilds)
                {
                    if (f is FScenarioDesigner && fSnr == ((FScenarioDesigner)f).fScenario)
                    {
                        fScenarioDesigner = (FScenarioDesigner)f;
                        break;
                    }
                }

                // --
                
                if (fScenarioDesigner == null)
                {
                    fScenarioDesigner = new FScenarioDesigner(m_fOpmCore, fSnr);
                    m_fOpmCore.fOpmContainer.showChild(fScenarioDesigner);
                }
                fScenarioDesigner.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fScenarioDesigner = null;
                fSnr = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRelation(
            )
        {
            try
            {
                m_fOpmCore.fOpmContainer.showRelationViewer(m_fActiveObject);
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

        private void procMenuExpand(
            )
        {
            FTreeView tvwTree = null;

            try
            {
                tvwTree = tvwScenario.Focused ? tvwScenario : tvwFlow;

                // --

                tvwTree.beginUpdate();
                // --
                tvwTree.ActiveNode.ExpandAll();
                // --
                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tvwTree = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCollapse(
            )
        {
            FTreeView tvwTree = null;

            try
            {
                tvwTree = tvwScenario.Focused ? tvwScenario : tvwFlow;

                // --

                tvwTree.beginUpdate();
                // --
                tvwTree.ActiveNode.CollapseAll();
                // --
                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwScenario.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tvwTree = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuMoveUp(
            string menuKey
            )
        {
            UltraTreeNode tNode = null;
            FIObject fObject = null;

            try
            {
                tvwScenario.beginUpdate();

                // --

                tNode = tvwScenario.ActiveNode;
                fObject = (FIObject)tNode.Tag;

                // --

                if (fObject.fObjectType == FObjectType.Equipment)
                {
                    ((FEquipment)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.ScenarioGroup)
                {
                    ((FScenarioGroup)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.Scenario)
                {
                    ((FScenario)fObject).moveUp();
                }

                // --

                tvwScenario.moveUpNode(tNode);
                tvwScenario.SelectedNodes.Clear();
                tvwScenario.ActiveNode = tNode;

                // --

                tvwScenario.endUpdate();
            }
            catch (Exception ex)
            {
                tvwScenario.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuMoveDown(
            )
        {
            UltraTreeNode tNode = null;
            FIObject fObject = null;

            try
            {
                tvwScenario.beginUpdate();

                // --

                tNode = tvwScenario.ActiveNode;
                fObject = (FIObject)tNode.Tag;

                // --

                if (fObject.fObjectType == FObjectType.Equipment)
                {
                    ((FEquipment)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.ScenarioGroup)
                {
                    ((FScenarioGroup)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.Scenario)
                {
                    ((FScenario)fObject).moveDown();
                }

                // --

                tvwScenario.moveDownNode(tNode);
                tvwScenario.SelectedNodes.Clear();
                tvwScenario.ActiveNode = tNode;

                // --

                tvwScenario.endUpdate();
            }
            catch (Exception ex)
            {
                tvwScenario.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPasteChild(
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeChild = null;
            FIObject fParent = null;
            FIObject fChild = null;

            try
            {
                tNodeParent = tvwScenario.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fChild = ((FOpcDriver)fParent).pasteChildEquipment();
                }
                else if (fParent.fObjectType == FObjectType.Equipment)
                {
                    fChild = ((FEquipment)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.ScenarioGroup)
                {
                    fChild = ((FScenarioGroup)fParent).pasteChild();
                }

                tNodeChild = new UltraTreeNode(fChild.uniqueIdToString);
                tNodeChild.Tag = fChild;
                FCommon.refreshTreeNodeOfObject(fChild, tvwScenario, tNodeChild);

                // --

                loadTreeOfChildObject(tNodeChild);
                tNodeParent.Nodes.Add(tNodeChild);
                // --
                tvwScenario.SelectedNodes.Clear();
                tvwScenario.ActiveNode = tNodeChild;

                // --

                tvwScenario.endUpdate();
            }
            catch (Exception ex)
            {
                tvwScenario.endUpdate();
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

        private void procMenuPasteSibling(
            )
        {
            UltraTreeNode tNodeRef = null;
            UltraTreeNode tNodeNew = null;
            FIObject fRefObject = null;
            FIObject fNewObject = null;

            try
            {
                tNodeRef = tvwScenario.ActiveNode;
                fRefObject = (FIObject)tNodeRef.Tag;

                // --

                tvwScenario.beginUpdate();
                // --
                if (fRefObject.fObjectType == FObjectType.Equipment)
                {
                    fNewObject = ((FEquipment)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.ScenarioGroup)
                {
                    fNewObject = ((FScenarioGroup)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.Scenario)
                {
                    fNewObject = ((FScenario)fRefObject).pasteSibling();
                }

                tNodeNew = new UltraTreeNode(fNewObject.uniqueIdToString);
                tNodeNew.Tag = fNewObject;
                FCommon.refreshTreeNodeOfObject(fNewObject, tvwScenario, tNodeNew);

                // --

                loadTreeOfChildObject(tNodeNew);
                tNodeRef.Parent.Nodes.Insert(tNodeRef.Index + 1, tNodeNew);
                // --
                tvwScenario.SelectedNodes.Clear();
                tvwScenario.ActiveNode = tNodeNew;

                // --

                tvwScenario.endUpdate();
            }
            catch (Exception ex)
            {
                tvwScenario.endUpdate();
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

        private void procMenuReplace(
            )
        {
            FReplaceNameDialog dialog = null;
            string findWhat = string.Empty;

            try
            {
                if (m_fActiveObject.fObjectType == FObjectType.Scenario)
                {
                    findWhat = ((FScenario)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.OpcTrigger)
                {
                    findWhat = ((FOpcTrigger)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.OpcCondition)
                {
                    findWhat = ((FOpcCondition)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.OpcExpression)
                {
                    findWhat = ((FOpcExpression)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.OpcTransmitter)
                {
                    findWhat = ((FOpcTransmitter)m_fActiveObject).name;
                }
                else if (m_fActiveObject.fObjectType == FObjectType.OpcTransfer)
                {
                    findWhat = ((FOpcTransfer)m_fActiveObject).name;
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
                    m_fOpmCore,
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
                if (fObject.fObjectType == FObjectType.Scenario)
                {
                    foreach (FIObject o in ((FScenario)fObject).fChildFlowCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FScenario)fObject).name = ((FScenario)fObject).name.Replace(findWhat, replaceWith);
                    ((FScenario)fObject).description = ((FScenario)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.OpcTrigger)
                {
                    foreach (FIObject o in ((FOpcTrigger)fObject).fChildOpcConditionCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FOpcTrigger)fObject).name = ((FOpcTrigger)fObject).name.Replace(findWhat, replaceWith);
                    ((FOpcTrigger)fObject).description = ((FOpcTrigger)fObject).description.Replace(findWhat, replaceWith);                    
                }
                else if (fObject.fObjectType == FObjectType.OpcCondition)
                {
                    foreach (FIObject o in ((FOpcCondition)fObject).fChildOpcExpressionCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FOpcCondition)fObject).name = ((FOpcCondition)fObject).name.Replace(findWhat, replaceWith);
                    ((FOpcCondition)fObject).description = ((FOpcCondition)fObject).description.Replace(findWhat, replaceWith);                    
                }
                else if (fObject.fObjectType == FObjectType.OpcExpression)
                {
                    foreach (FIObject o in ((FOpcExpression)fObject).fChildOpcExpressionCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FOpcExpression)fObject).name = ((FOpcExpression)fObject).name.Replace(findWhat, replaceWith);
                    ((FOpcExpression)fObject).description = ((FOpcExpression)fObject).description.Replace(findWhat, replaceWith);                    
                }
                else if (fObject.fObjectType == FObjectType.OpcTransmitter)
                {
                    foreach (FIObject o in ((FOpcTransmitter)fObject).fChildOpcTransferCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FOpcTransmitter)fObject).name = ((FOpcTransmitter)fObject).name.Replace(findWhat, replaceWith);
                    ((FOpcTransmitter)fObject).description = ((FOpcTransmitter)fObject).description.Replace(findWhat, replaceWith);                    
                }
                else if (fObject.fObjectType == FObjectType.OpcTransfer)
                {
                    ((FOpcTransfer)fObject).name = ((FOpcTransfer)fObject).name.Replace(findWhat, replaceWith);
                    ((FOpcTransfer)fObject).description = ((FOpcTransfer)fObject).description.Replace(findWhat, replaceWith);
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
            FIObject fObject = null;

            try
            {
                fObject = m_fActiveObject;

                // --

                if (fObject.fObjectType == FObjectType.Equipment)
                {
                    ((FEquipment)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.ScenarioGroup)
                {
                    ((FScenarioGroup)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.Scenario)
                {
                    ((FScenario)fObject).cut();
                }
                // --
                else if (fObject.fObjectType == FObjectType.OpcTrigger)
                {
                    ((FOpcTrigger)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.OpcCondition)
                {
                    ((FOpcCondition)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.OpcExpression)
                {
                    ((FOpcExpression)fObject).cut();
                }
                // --
                else if (fObject.fObjectType == FObjectType.OpcTransmitter)
                {
                    ((FOpcTransmitter)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.OpcTransfer)
                {
                    ((FOpcTransfer)fObject).cut();
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
                    fObject.fObjectType == FObjectType.Equipment ||
                    fObject.fObjectType == FObjectType.ScenarioGroup ||
                    fObject.fObjectType == FObjectType.Scenario
                   )
                {
                    removeTreeOfObject(fObject);
                }
                else if (
                    fObject.fObjectType == FObjectType.OpcTrigger ||
                    fObject.fObjectType == FObjectType.OpcTransmitter ||
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
                tvwScenario.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fObject = null;
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
                if (
                    this.m_fActiveObject.fObjectType == FObjectType.Equipment ||
                    this.m_fActiveObject.fObjectType == FObjectType.ScenarioGroup ||
                    this.m_fActiveObject.fObjectType == FObjectType.Scenario
                   )
                {
                    fObject = m_fActiveObject;
                }
                else 
                {
                    tNode = tvwFlow.ActiveNode;
                    fObject = (FIObject)tNode.Tag;
                }

                // --

                if (fObject.fObjectType == FObjectType.Equipment)
                {
                    ((FEquipment)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.ScenarioGroup)
                {
                    ((FScenarioGroup)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.Scenario)
                {
                    ((FScenario)fObject).copy();
                }
                // --
                else if (fObject.fObjectType == FObjectType.OpcTrigger)
                {
                    ((FOpcTrigger)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.OpcCondition)
                {
                    ((FOpcCondition)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.OpcExpression)
                {
                    ((FOpcExpression)fObject).copy();
                }
                // --
                else if (fObject.fObjectType == FObjectType.OpcTransmitter)
                {
                    ((FOpcTransmitter)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.OpcTransfer)
                {
                    ((FOpcTransfer)fObject).copy();
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
                else if (fObject.fObjectType == FObjectType.Pauser)
                {
                    ((FPauser)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.EntryPoint)
                {
                    ((FEntryPoint)fObject).copy();
                }

                // --

                if (
                    this.m_fActiveObject.fObjectType == FObjectType.Equipment ||
                    this.m_fActiveObject.fObjectType == FObjectType.ScenarioGroup ||
                    this.m_fActiveObject.fObjectType == FObjectType.Scenario
                   )
                {
                    controlMenu();
                }
                else
                {
                    controlMenuOfScenario();
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

        private void procMenuClone(
            )
        {
            FIObject fObject = null;
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeRef = null;
            UltraTreeNode tNodeNew = null;

            try
            {
                if (m_fActiveObject.fObjectType == FObjectType.Equipment)
                {
                    fObject = ((FEquipment)m_fActiveObject).clone();
                }
                else if (m_fActiveObject.fObjectType == FObjectType.ScenarioGroup)
                {
                    fObject = ((FScenarioGroup)m_fActiveObject).clone();
                }
                else if (m_fActiveObject.fObjectType == FObjectType.Scenario)
                {
                    fObject = ((FScenario)m_fActiveObject).clone();
                }
                else
                {
                    return;
                }

                // --

                tvwScenario.beginUpdate();

                // --

                tNodeRef = tvwScenario.ActiveNode;
                tNodeParent = tNodeRef.Parent;
                // --
                tNodeNew = new UltraTreeNode(fObject.uniqueIdToString);
                tNodeNew.Tag = fObject;
                FCommon.refreshTreeNodeOfObject(fObject, tvwScenario, tNodeNew);
                loadTreeOfChildObject(tNodeNew);
                tNodeParent.Nodes.Insert(tNodeRef.Index + 1, tNodeNew);
                // --
                tvwScenario.SelectedNodes.Clear();
                tvwScenario.ActiveNode = tNodeNew;

                // --

                tvwScenario.endUpdate();
            }
            catch (Exception ex)
            {
                tvwScenario.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fObject = null;
                tNodeParent = null;
                tNodeRef = null;
                tNodeNew = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuMerge(
            )
        {
            // --
            FScenarioSelector dialog = null;
            // --
            FScenario fSourceScenario = null;
            FScenario fTargetScenario = null;
            try
            {
                if (m_fActiveObject.fObjectType == FObjectType.Scenario)
                {
                    fSourceScenario = ((FScenario)m_fActiveObject);
                }
                else
                {
                    return;
                }

                // --

                dialog = new FScenarioSelector(
                    this.m_fOpmCore,
                    fSourceScenario
                    );
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
                fTargetScenario = dialog.fSelectedScenario;

                // --
                fTargetScenario.merge(fSourceScenario);

                // --
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dialog = null;
                // --
                fSourceScenario = null;
                fTargetScenario = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSearch(
           string searchWord
           )
        {
            UltraTreeNode tNode = null;
            FIObject fBase = null;
            FIObject fResult = null;

            try
            {
                tNode = tvwScenario.ActiveNode;
                fBase = (FIObject)tNode.Tag;

                // --

                fResult = m_fOpmCore.fOpmFileInfo.fOpcDriver.searchEquipmentSeries(fBase, searchWord);
                if (fResult == null)
                {
                    FMessageBox.showInformation("Search", m_fOpmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
                    return;
                }

                // --

                tvwScenario.beginUpdate();

                // --

                expandTreeForSearch(fResult);
                tNode = tvwScenario.GetNodeByKey(fResult.uniqueIdToString);
                tvwScenario.SelectedNodes.Clear();
                tvwScenario.ActiveNode = tNode;

                // --

                tvwScenario.endUpdate();
            }
            catch (Exception ex)
            {
                tvwScenario.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                fBase = null;
                fResult = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void searchObject(
            FIObject fObject
            )
        {
            UltraTreeNode tNode = null;

            try
            {
                tvwScenario.beginUpdate();

                // --

                expandTreeForSearch(fObject);
                tNode = tvwScenario.GetNodeByKey(fObject.uniqueIdToString);
                tvwScenario.SelectedNodes.Clear();
                tvwScenario.ActiveNode = tNode;

                // --

                tvwScenario.endUpdate();
            }
            catch (Exception ex)
            {
                tvwScenario.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void expandTreeForSearch(
            FIObject fObject
            )
        {
            FIObject fParent = null;
            UltraTreeNode tNodeParent = null;

            try
            {
                if (fObject.fObjectType == FObjectType.OpcDriver)
                {
                    return;
                }

                // --

                fParent = m_fOpmCore.fOpmFileInfo.fOpcDriver.getParentOfObject(fObject);

                // --

                tNodeParent = tvwScenario.GetNodeByKey(fParent.uniqueIdToString);
                if (tNodeParent == null || !tNodeParent.Expanded)
                {
                    expandTreeForSearch(fParent);
                }

                // --

                if (tNodeParent == null)
                {
                    tNodeParent = tvwScenario.GetNodeByKey(fObject.uniqueIdToString);
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

        #region Flow Part

        private void changeAliasName(
            )
        {
            FIObject fObject = null;
            FScenarioGroup fSng = null;
            FScenario fSnr = null;

            try
            {
                fObject = (FIObject)tvwScenario.ActiveNode.Tag;

                // --

                if (fObject.fObjectType == FObjectType.ScenarioGroup)
                {
                    fSng = (FScenarioGroup)fObject;
                    // --
                    flcContainer.eapAlias = fSng.eapAlias;
                    flcContainer.eqAlias = fSng.equipmentAlias;
                    flcContainer.hostAlias = fSng.hostAlias;
                }
                else if (fObject.fObjectType == FObjectType.Scenario)
                {
                    fSnr = (FScenario)fObject;
                    // --
                    flcContainer.eapAlias = fSnr.fParent.eapAlias;
                    flcContainer.eqAlias = fSnr.fParent.equipmentAlias;
                    flcContainer.hostAlias = fSnr.fParent.hostAlias;
                }
                else
                {
                    flcContainer.eapAlias = "EAP";
                    flcContainer.eqAlias = "EQ";
                    flcContainer.hostAlias = "HOST";
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fObject = null;
                fSng = null;
                fSnr = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadContainerOfFlow(
            )
        {
            FScenario fSnr = null;
            FIObject fObject = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fFlowCtrl = null;

            try
            {
                flcContainer.removeAllFlowCtrl();
                FCommon.refreshFlowContainerOfObject(m_fActiveObject, flcContainer);
                changeAliasName();

                 // --

                if (m_fActiveObject.fObjectType != FObjectType.Scenario)
                {
                    flcContainer.Tag = fSnr;
                    return;
                }

                // --

                fSnr = (FScenario)m_fActiveObject;

                // --

                foreach (FIFlow fFlow in fSnr.fChildFlowCollection)
                {
                    fObject = (FIObject)fFlow;

                    if (fFlow.fFlowType == FFlowType.OpcTrigger)
                    {
                        fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FOpcTriggerFlow(fObject.uniqueIdToString));
                    }
                    else if (fFlow.fFlowType == FFlowType.OpcTransmitter)
                    {
                        fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FOpcTransmitterFlow(fObject.uniqueIdToString));
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
                flcContainer.Tag = fSnr;

                // --

                flcContainer.activateFlowContainer();                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSnr = null;
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

                if (m_fActiveObject.fObjectType == FObjectType.OpcTrigger)
                {
                    tNodeFlw = new UltraTreeNode(m_fActiveObject.uniqueIdToString);
                    tNodeFlw.Tag = m_fActiveObject;
                    FCommon.refreshTreeNodeOfObject(m_fActiveObject, tvwFlow, tNodeFlw);

                    // --

                    foreach (FOpcCondition fPcn in ((FOpcTrigger)m_fActiveObject).fChildOpcConditionCollection)
                    {
                        tNode1 = new UltraTreeNode(fPcn.uniqueIdToString);
                        tNode1.Tag = fPcn;
                        FCommon.refreshTreeNodeOfObject(fPcn, tvwFlow, tNode1);

                        // --

                        foreach (FOpcExpression fPep in fPcn.fChildOpcExpressionCollection)
                        {
                            tNode2 = new UltraTreeNode(fPep.uniqueIdToString);
                            tNode2.Tag = fPep;
                            FCommon.refreshTreeNodeOfObject(fPep, tvwFlow, tNode2);

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
                else if (m_fActiveObject.fObjectType == FObjectType.OpcTransmitter)
                {
                    tNodeFlw = new UltraTreeNode(m_fActiveObject.uniqueIdToString);
                    tNodeFlw.Tag = m_fActiveObject;
                    FCommon.refreshTreeNodeOfObject(m_fActiveObject, tvwFlow, tNodeFlw);

                    // --

                    foreach (FOpcTransfer fPtf in ((FOpcTransmitter)m_fActiveObject).fChildOpcTransferCollection)
                    {
                        tNode1 = new UltraTreeNode(fPtf.uniqueIdToString);
                        tNode1.Tag = fPtf;
                        FCommon.refreshTreeNodeOfObject(fPtf, tvwFlow, tNode1);

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
                    m_fActiveObject.fObjectType == FObjectType.Mapper ||
                    m_fActiveObject.fObjectType == FObjectType.Storage ||
                    m_fActiveObject.fObjectType == FObjectType.Branch ||
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
                if (fParent.fObjectType == FObjectType.OpcTrigger)
                {
                    foreach (FOpcCondition fOcn in ((FOpcTrigger)fParent).fChildOpcConditionCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOcn.uniqueIdToString);
                        tNodeChild.Tag = fOcn;
                        FCommon.refreshTreeNodeOfObject(fOcn, tvwFlow, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcCondition)
                {
                    foreach (FOpcExpression fOep in ((FOpcCondition)fParent).fChildOpcExpressionCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOep.uniqueIdToString);
                        tNodeChild.Tag = fOep;
                        FCommon.refreshTreeNodeOfObject(fOep, tvwFlow, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcExpression)
                {
                    foreach (FOpcExpression fOep in ((FOpcExpression)fParent).fChildOpcExpressionCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOep.uniqueIdToString);
                        tNodeChild.Tag = fOep;
                        FCommon.refreshTreeNodeOfObject(fOep, tvwFlow, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                // --
                else if (fParent.fObjectType == FObjectType.OpcTransmitter)
                {
                    foreach (FOpcTransfer fOtf in ((FOpcTransmitter)fParent).fChildOpcTransferCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOtf.uniqueIdToString);
                        tNodeChild.Tag = fOtf;
                        FCommon.refreshTreeNodeOfObject(fOtf, tvwFlow, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
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

                if (fNewChild.fObjectType == FObjectType.OpcTrigger)
                {
                    fRefChild = (FIObject)((FOpcTrigger)fNewChild).fNextSibling;
                    fNewChildFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FOpcTriggerFlow(fNewChild.uniqueIdToString);
                }
                else if (fNewChild.fObjectType == FObjectType.OpcTransmitter)
                {
                    fRefChild = (FIObject)((FOpcTransmitter)fNewChild).fNextSibling;
                    fNewChildFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FOpcTransmitterFlow(fNewChild.uniqueIdToString);
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
                // --
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
                    fRefChild = (FIObject)((FPauser)fNewChild).fNextSibling;
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

                if (fNewChild.fObjectType == FObjectType.OpcCondition)
                {
                    tNodeParent = tvwFlow.GetNodeByKey(fParent.uniqueIdToString);                    
                    if (tNodeParent == null)
                    {                        
                        return;
                    }
                    fRefChild = ((FOpcCondition)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.OpcExpression)
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
                    fRefChild = ((FOpcExpression)fNewChild).fNextSibling;
                }
                // --
                else if (fNewChild.fObjectType == FObjectType.OpcTransfer)
                {
                    tNodeParent = tvwFlow.GetNodeByKey(fParent.uniqueIdToString);                    
                    if (tNodeParent == null)
                    {
                        return;
                    }
                    fRefChild = ((FOpcTransfer)fNewChild).fNextSibling;
                }
                // --
                if (fNewChild.fObjectType == FObjectType.HostCondition)
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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

                if (fObject.fObjectType == FObjectType.OpcTrigger)
                {
                    if (((FOpcTrigger)fObject).fPreviousSibling == null)
                    {
                        if (fPrevFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcTrigger)fObject).fPreviousSibling.Equals(fPrevFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcTransmitter)
                {
                    if (((FOpcTransmitter)fObject).fPreviousSibling == null)
                    {
                        if (fPrevFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcTransmitter)fObject).fPreviousSibling.Equals(fPrevFlowCtrl.Tag))
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

                if (fObject.fObjectType == FObjectType.OpcCondition)
                {
                    if (((FOpcCondition)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcCondition)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcExpression)
                {
                    if (((FOpcExpression)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcExpression)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcTransfer)
                {
                    if (((FOpcTransfer)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcTransfer)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
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

                if (fObject.fObjectType == FObjectType.OpcTrigger)
                {
                    if (((FOpcTrigger)fObject).fNextSibling == null)
                    {
                        if (fNextFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcTrigger)fObject).fNextSibling.Equals(fNextFlowCtrl.Tag))
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcTransmitter)
                {
                    if (((FOpcTransmitter)fObject).fNextSibling == null)
                    {
                        if (fNextFlowCtrl == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcTransmitter)fObject).fNextSibling.Equals(fNextFlowCtrl.Tag))
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

                if (fObject.fObjectType == FObjectType.OpcCondition)
                {
                    if (((FOpcCondition)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcCondition)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcExpression)
                {
                    if (((FOpcExpression)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcExpression)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcTransfer)
                {
                    if (((FOpcTransfer)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcTransfer)fObject).fNextSibling == (FIObject)tNextNode.Tag)
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
                        if (fObject.fObjectType == FObjectType.OpcTrigger)
                        {
                            fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FOpcTriggerFlow(fObject.uniqueIdToString);
                        }
                        else if (fObject.fObjectType == FObjectType.OpcTransmitter)
                        {
                            fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FOpcTransmitterFlow(fObject.uniqueIdToString);
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
                            fObject.fObjectType == FObjectType.OpcExpression ||
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
            FScenario fSnr = null;
            FIObject fRefChild = null;
            FIObject fNewChild = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fRefChildFlowCtrl = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fNewChildFlowCtrl = null;

            try
            {
                fSnr = (FScenario)flcContainer.Tag;
                fRefChildFlowCtrl = flcContainer.fActiveFlowCtrl;
                fRefChild = (FIObject)fRefChildFlowCtrl.Tag;

                // --

                if (menuKey == FMenuKey.MenuEqmInsertBeforeOpcTrigger)
                {
                    fNewChild = (FIObject)fSnr.insertBeforeChildFlow(
                        new FOpcTrigger(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FOpcTriggerFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertBeforeOpcTransmitter)
                {
                    fNewChild = (FIObject)fSnr.insertBeforeChildFlow(
                        new FOpcTransmitter(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FOpcTransmitterFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                if (menuKey == FMenuKey.MenuEqmInsertBeforeHostTrigger)
                {
                    fNewChild = (FIObject)fSnr.insertBeforeChildFlow(
                        new FHostTrigger(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FHostTriggerFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertBeforeHostTransmitter)
                {
                    fNewChild = (FIObject)fSnr.insertBeforeChildFlow(
                        new FHostTransmitter(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FHostTransmitterFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertBeforeEquipmentStateSetAlterer)
                {
                    fNewChild = (FIObject)fSnr.insertBeforeChildFlow(
                        new FEquipmentStateSetAlterer(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FEquipmentStateSetAltererFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertBeforeJudgement)
                {
                    fNewChild = (FIObject)fSnr.insertBeforeChildFlow(
                        new FJudgement(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FJudgementFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertBeforeMapper)
                {
                    fNewChild = (FIObject)fSnr.insertBeforeChildFlow(
                        new FMapper(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FMapperFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertBeforeStorage)
                {
                    fNewChild = (FIObject)fSnr.insertBeforeChildFlow(
                        new FStorage(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FStorageFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertBeforeCallback)
                {
                    fNewChild = (FIObject)fSnr.insertBeforeChildFlow(
                        new FCallback(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FCallbackFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertBeforeBranch)
                {
                    fNewChild = (FIObject)fSnr.insertBeforeChildFlow(
                        new FBranch(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FBranchFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertBeforeComment)
                {
                    fNewChild = (FIObject)fSnr.insertBeforeChildFlow(
                        new FComment(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FCommentFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertBeforePauser)
                {
                    fNewChild = (FIObject)fSnr.insertBeforeChildFlow(
                        new FPauser(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertBeforeFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FPauserFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertBeforeEntryPoint)
                {
                    fNewChild = (FIObject)fSnr.insertBeforeChildFlow(
                        new FEntryPoint(m_fOpmCore.fOpmFileInfo.fOpcDriver),
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
                fSnr = null;
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
            FScenario fSnr = null;
            FIObject fRefChild = null;
            FIObject fNewChild = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fRefChildFlowCtrl = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fNewChildFlowCtrl = null;

            try
            {
                fSnr = (FScenario)flcContainer.Tag;
                fRefChildFlowCtrl = flcContainer.fActiveFlowCtrl;
                fRefChild = (FIObject)fRefChildFlowCtrl.Tag;

                // --

                if (menuKey == FMenuKey.MenuEqmInsertAfterOpcTrigger)
                {
                    fNewChild = (FIObject)fSnr.insertAfterChildFlow(
                        new FOpcTrigger(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FOpcTriggerFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertAfterOpcTransmitter)
                {
                    fNewChild = (FIObject)fSnr.insertAfterChildFlow(
                        new FOpcTransmitter(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FOpcTransmitterFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertAfterHostTrigger)
                {
                    fNewChild = (FIObject)fSnr.insertAfterChildFlow(
                        new FHostTrigger(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FHostTriggerFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertAfterHostTransmitter)
                {
                    fNewChild = (FIObject)fSnr.insertAfterChildFlow(
                        new FHostTransmitter(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FHostTransmitterFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertAfterEquipmentStateSetAlterer)
                {
                    fNewChild = (FIObject)fSnr.insertAfterChildFlow(
                        new FEquipmentStateSetAlterer(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FEquipmentStateSetAltererFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertAfterJudgement)
                {
                    fNewChild = (FIObject)fSnr.insertAfterChildFlow(
                        new FJudgement(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FJudgementFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertAfterMapper)
                {
                    fNewChild = (FIObject)fSnr.insertAfterChildFlow(
                        new FMapper(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FMapperFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertAfterStorage)
                {
                    fNewChild = (FIObject)fSnr.insertAfterChildFlow(
                        new FStorage(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FStorageFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertAfterCallback)
                {
                    fNewChild = (FIObject)fSnr.insertAfterChildFlow(
                        new FCallback(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FCallbackFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertAfterBranch)
                {
                    fNewChild = (FIObject)fSnr.insertAfterChildFlow(
                        new FBranch(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FBranchFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertAfterComment)
                {
                    fNewChild = (FIObject)fSnr.insertAfterChildFlow(
                        new FComment(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FCommentFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertAfterPauser)
                {
                    fNewChild = (FIObject)fSnr.insertAfterChildFlow(
                        new FPauser(m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FIFlow)fRefChild
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FPauserFlow(fNewChild.uniqueIdToString),
                        fRefChildFlowCtrl
                        );
                }
                else if (menuKey == FMenuKey.MenuEqmInsertAfterEntryPoint)
                {
                    fNewChild = (FIObject)fSnr.insertAfterChildFlow(
                        new FEntryPoint(m_fOpmCore.fOpmFileInfo.fOpcDriver),
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
                fSnr = null;
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
            FScenario fSnr = null;
            FIObject fNewChild = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fNewChildFlowCtrl = null;

            try
            {
                fSnr = (FScenario)flcContainer.Tag;

                // --

                if (menuKey == FMenuKey.MenuEqmAppendOpcTrigger)
                {
                    fNewChild = (FIObject)fSnr.appendChildFlow(
                        new FOpcTrigger(m_fOpmCore.fOpmFileInfo.fOpcDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FOpcTriggerFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuEqmAppendOpcTransmitter)
                {
                    fNewChild = (FIObject)fSnr.appendChildFlow(
                        new FOpcTransmitter(m_fOpmCore.fOpmFileInfo.fOpcDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FOpcTransmitterFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuEqmAppendHostTrigger)
                {
                    fNewChild = (FIObject)fSnr.appendChildFlow(
                        new FHostTrigger(m_fOpmCore.fOpmFileInfo.fOpcDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FHostTriggerFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuEqmAppendHostTransmitter)
                {
                    fNewChild = (FIObject)fSnr.appendChildFlow(
                        new FHostTransmitter(m_fOpmCore.fOpmFileInfo.fOpcDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FHostTransmitterFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuEqmAppendEquipmentStateSetAlterer)
                {
                    fNewChild = (FIObject)fSnr.appendChildFlow(
                        new FEquipmentStateSetAlterer(m_fOpmCore.fOpmFileInfo.fOpcDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FEquipmentStateSetAltererFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuEqmAppendJudgement)
                {
                    fNewChild = (FIObject)fSnr.appendChildFlow(
                        new FJudgement(m_fOpmCore.fOpmFileInfo.fOpcDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FJudgementFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuEqmAppendMapper)
                {
                    fNewChild = (FIObject)fSnr.appendChildFlow(
                        new FMapper(m_fOpmCore.fOpmFileInfo.fOpcDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FMapperFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuEqmAppendStorage)
                {
                    fNewChild = (FIObject)fSnr.appendChildFlow(
                        new FStorage(m_fOpmCore.fOpmFileInfo.fOpcDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FStorageFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuEqmAppendCallback)
                {
                    fNewChild = (FIObject)fSnr.appendChildFlow(
                        new FCallback(m_fOpmCore.fOpmFileInfo.fOpcDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FCallbackFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuEqmAppendBranch)
                {
                    fNewChild = (FIObject)fSnr.appendChildFlow(
                        new FBranch(m_fOpmCore.fOpmFileInfo.fOpcDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FBranchFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuEqmAppendComment)
                {
                    fNewChild = (FIObject)fSnr.appendChildFlow(
                        new FComment(m_fOpmCore.fOpmFileInfo.fOpcDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FCommentFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuEqmAppendPauser)
                {
                    fNewChild = (FIObject)fSnr.appendChildFlow(
                        new FPauser(m_fOpmCore.fOpmFileInfo.fOpcDriver)
                        );
                    // --
                    fNewChildFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FPauserFlow(fNewChild.uniqueIdToString));
                }
                else if (menuKey == FMenuKey.MenuEqmAppendEntryPoint)
                {
                    fNewChild = (FIObject)fSnr.appendChildFlow(
                        new FEntryPoint(m_fOpmCore.fOpmFileInfo.fOpcDriver)
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
                fSnr = null;
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

                if (fParent.fObjectType == FObjectType.OpcTrigger)
                {
                    fNewChild = ((FOpcTrigger)fParent).insertBeforeChildOpcCondition(
                        new FOpcCondition(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FOpcCondition)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.OpcCondition)
                {
                    fNewChild = ((FOpcCondition)fParent).insertBeforeChildOpcExpression(
                        new FOpcExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FOpcExpression)fRefChild
                        );

                    // --

                    if (((FOpcExpression)fNewChild).fPreviousSibling == null)
                    {
                        FCommon.refreshTreeNodeOfObject(fRefChild, tvwFlow, tNodeRefChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcExpression)
                {
                    fNewChild = ((FOpcExpression)fParent).insertBeforeChildOpcExpression(
                        new FOpcExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FOpcExpression)fRefChild
                        );

                    // --

                    if (((FOpcExpression)fNewChild).fPreviousSibling == null)
                    {
                        FCommon.refreshTreeNodeOfObject(fRefChild, tvwFlow, tNodeRefChild);
                    }
                }
                // --
                else if (fParent.fObjectType == FObjectType.OpcTransmitter)
                {
                    fNewChild = ((FOpcTransmitter)fParent).insertBeforeChildOpcTransfer(
                        new FOpcTransfer(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FOpcTransfer)fRefChild
                        );
                }
                // --
                else if (fParent.fObjectType == FObjectType.HostTrigger)
                {
                    fNewChild = ((FHostTrigger)fParent).insertBeforeChildHostCondition(
                        new FHostCondition(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FHostCondition)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.HostCondition)
                {
                    fNewChild = ((FHostCondition)fParent).insertBeforeChildHostExpression(
                        new FHostExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
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
                        new FHostExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
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
                        new FHostTransfer(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FHostTransfer)fRefChild
                        );
                }
                // --
                else if (fParent.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    fNewChild = ((FEquipmentStateSetAlterer)fParent).insertBeforeChildEquipmentStateAlterer(
                        new FEquipmentStateAlterer(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FEquipmentStateAlterer)fRefChild
                        );
                }
                // --
                else if (fParent.fObjectType == FObjectType.Judgement)
                {
                    fNewChild = ((FJudgement)fParent).insertBeforeChildJudgementCondition(
                        new FJudgementCondition(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FJudgementCondition)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.JudgementCondition)
                {
                    fNewChild = ((FJudgementCondition)fParent).insertBeforeChildJudgementExpression(
                        new FJudgementExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
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
                        new FJudgementExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
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
                        new FFunction(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
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

                if (fParent.fObjectType == FObjectType.OpcTrigger)
                {
                    fNewChild = ((FOpcTrigger)fParent).insertAfterChildOpcCondition(
                        new FOpcCondition(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FOpcCondition)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.OpcCondition)
                {
                    fNewChild = ((FOpcCondition)fParent).insertAfterChildOpcExpression(
                        new FOpcExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FOpcExpression)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.OpcExpression)
                {
                    fNewChild = ((FOpcExpression)fParent).insertAfterChildOpcExpression(
                        new FOpcExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FOpcExpression)fRefChild
                        );
                }
                // --
                else if (fParent.fObjectType == FObjectType.OpcTransmitter)
                {
                    fNewChild = ((FOpcTransmitter)fParent).insertAfterChildOpcTransfer(
                        new FOpcTransfer(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FOpcTransfer)fRefChild
                        );
                }
                // --
                else if (fParent.fObjectType == FObjectType.HostTrigger)
                {
                    fNewChild = ((FHostTrigger)fParent).insertAfterChildHostCondition(
                        new FHostCondition(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FHostCondition)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.HostCondition)
                {
                    fNewChild = ((FHostCondition)fParent).insertAfterChildHostExpression(
                        new FHostExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FHostExpression)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.HostExpression)
                {
                    fNewChild = ((FHostExpression)fParent).insertAfterChildHostExpression(
                        new FHostExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FHostExpression)fRefChild
                        );
                }
                // --
                else if (fParent.fObjectType == FObjectType.HostTransmitter)
                {
                    fNewChild = ((FHostTransmitter)fParent).insertAfterChildHostTransfer(
                        new FHostTransfer(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FHostTransfer)fRefChild
                        );
                }
                // --
                else if (fParent.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    fNewChild = ((FEquipmentStateSetAlterer)fParent).insertAfterChildEquipmentStateAlterer(
                        new FEquipmentStateAlterer(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FEquipmentStateAlterer)fRefChild
                        );
                }
                // --
                else if (fParent.fObjectType == FObjectType.Judgement)
                {
                    fNewChild = ((FJudgement)fParent).insertAfterChildJudgementCondition(
                        new FJudgementCondition(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FJudgementCondition)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.JudgementCondition)
                {
                    fNewChild = ((FJudgementCondition)fParent).insertAfterChildJudgementExpression(
                        new FJudgementExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FJudgementExpression)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.JudgementExpression)
                {
                    fNewChild = ((FJudgementExpression)fParent).insertAfterChildJudgementExpression(
                        new FJudgementExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FJudgementExpression)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.Callback)
                {
                    fNewChild = ((FCallback)fParent).insertAfterChildFunction(
                        new FFunction(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
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


                if (fParent.fObjectType == FObjectType.OpcTrigger)
                {
                    fNewChild = ((FOpcTrigger)fParent).appendChildOpcCondition(new FOpcCondition(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.OpcCondition)
                {
                    fNewChild = ((FOpcCondition)fParent).appendChildOpcExpression(new FOpcExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.OpcExpression)
                {
                    fNewChild = ((FOpcExpression)fParent).appendChildOpcExpression(new FOpcExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                // --
                else if (fParent.fObjectType == FObjectType.OpcTransmitter)
                {
                    fNewChild = ((FOpcTransmitter)fParent).appendChildOpcTransfer(new FOpcTransfer(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.HostTrigger)
                {
                    fNewChild = ((FHostTrigger)fParent).appendChildHostCondition(new FHostCondition(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.HostCondition)
                {
                    fNewChild = ((FHostCondition)fParent).appendChildHostExpression(new FHostExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.HostExpression)
                {
                    fNewChild = ((FHostExpression)fParent).appendChildHostExpression(new FHostExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                // --
                else if (fParent.fObjectType == FObjectType.HostTransmitter)
                {
                    fNewChild = ((FHostTransmitter)fParent).appendChildHostTransfer(new FHostTransfer(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                // --
                else if (fParent.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    fNewChild = ((FEquipmentStateSetAlterer)fParent).appendChildEquipmentStateAlterer(new FEquipmentStateAlterer(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                // --
                else if (fParent.fObjectType == FObjectType.Judgement)
                {
                    fNewChild = ((FJudgement)fParent).appendChildJudgementCondition(new FJudgementCondition(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.JudgementCondition)
                {
                    fNewChild = ((FJudgementCondition)fParent).appendChildJudgementExpression(new FJudgementExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.JudgementExpression)
                {
                    fNewChild = ((FJudgementExpression)fParent).appendChildJudgementExpression(new FJudgementExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.Callback)
                {
                    fNewChild = ((FCallback)fParent).appendChildFunction(new FFunction(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
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
                // Remove OPC Object가 1개 이상일 경우 사용자에게 Confirm를 받는다.
                // ***
                if (tvwFlow.SelectedNodes.Count > 1)
                {
                    dialogResult = FMessageBox.showQuestion(
                        FConstants.ApplicationName,
                        m_fOpmCore.fWsmCore.fUIWizard.generateMessage("Q0004", new object[] { "Object" }),
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button2,
                        m_fOpmCore.fWsmCore.fWsmContainer
                        );
                    if (dialogResult == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }

                // --

                // ***
                // OPC Object Remove
                // ***
                if (fParent.fObjectType == FObjectType.OpcTrigger)
                {
                    fChilds = new FOpcCondition[tvwFlow.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwFlow.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FOpcCondition)tvwFlow.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FOpcTrigger)fParent).removeChildOpcCondition((FOpcCondition[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.OpcCondition)
                {
                    fChilds = new FOpcExpression[tvwFlow.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwFlow.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FOpcExpression)tvwFlow.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FOpcCondition)fParent).removeChildOpcExpression((FOpcExpression[])fChilds);

                    // --

                    if (fParent.hasChild)
                    {
                        fChild = ((FOpcCondition)fParent).fChildOpcExpressionCollection[0];
                        tNodeChild = tvwFlow.GetNodeByKey(fChild.uniqueIdToString);
                        if (tNodeChild != null)
                        {
                            FCommon.refreshTreeNodeOfObject(fChild, tvwFlow, tNodeChild);
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcExpression)
                {
                    fChilds = new FOpcExpression[tvwFlow.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwFlow.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FOpcExpression)tvwFlow.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FOpcExpression)fParent).removeChildOpcExpression((FOpcExpression[])fChilds);

                    // --

                    if (fParent.hasChild)
                    {
                        fChild = ((FOpcExpression)fParent).fChildOpcExpressionCollection[0];
                        tNodeChild = tvwFlow.GetNodeByKey(fChild.uniqueIdToString);
                        if (tNodeChild != null)
                        {
                            FCommon.refreshTreeNodeOfObject(fChild, tvwFlow, tNodeChild);
                        }
                    }
                }
                // --
                else if (fParent.fObjectType == FObjectType.OpcTransmitter)
                {
                    fChilds = new FOpcTransfer[tvwFlow.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwFlow.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FOpcTransfer)tvwFlow.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FOpcTransmitter)fParent).removeChildOpcTransfer((FOpcTransfer[])fChilds);
                }
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
                    m_fActiveObject.fObjectType == FObjectType.OpcTrigger ||
                    m_fActiveObject.fObjectType == FObjectType.OpcTransmitter ||
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

                if (fObject.fObjectType == FObjectType.OpcTrigger)
                {
                    ((FOpcTrigger)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.OpcCondition)
                {
                    ((FOpcCondition)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.OpcExpression)
                {
                    ((FOpcExpression)fObject).moveUp();
                }
                // --
                else if (fObject.fObjectType == FObjectType.OpcTransmitter)
                {
                    ((FOpcTransmitter)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.OpcTransfer)
                {
                    ((FOpcTransfer)fObject).moveUp();
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostTrigger)
                {
                    ((FHostTrigger)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.HostCondition)
                {
                    ((FHostCondition)fObject).moveUp();
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
                    m_fActiveObject.fObjectType == FObjectType.OpcTrigger ||
                    m_fActiveObject.fObjectType == FObjectType.OpcTransmitter ||
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
                    m_fActiveObject.fObjectType == FObjectType.OpcTrigger ||
                    m_fActiveObject.fObjectType == FObjectType.OpcTransmitter ||
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

                if (fObject.fObjectType == FObjectType.OpcTrigger)
                {
                    ((FOpcTrigger)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.OpcCondition)
                {
                    ((FOpcCondition)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.OpcExpression)
                {
                    ((FOpcExpression)fObject).moveDown();
                }
                // --
                else if (fObject.fObjectType == FObjectType.OpcTransmitter)
                {
                    ((FOpcTransmitter)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.OpcTransfer)
                {
                    ((FOpcTransfer)fObject).moveDown();
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
                    m_fActiveObject.fObjectType == FObjectType.OpcTrigger ||
                    m_fActiveObject.fObjectType == FObjectType.OpcTransmitter ||
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

                controlMenuOfScenario();
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

                controlMenuOfScenario();
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

                controlMenuOfScenario();
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

                if (fNewFlowObject.fObjectType == FObjectType.OpcTrigger)
                {
                    fNewFlowCtrl = flcContainer.insertAfterFlowCtrl(
                        new Nexplant.MC.Core.FaUIs.WPF.FOpcTriggerFlow(fNewFlowObject.uniqueIdToString),
                        fRefFlowCtrl
                        );
                }
                else if (fNewFlowObject.fObjectType == FObjectType.OpcTransmitter)
                {
                    fNewFlowCtrl = flcContainer.insertAfterFlowCtrl(
                       new Nexplant.MC.Core.FaUIs.WPF.FOpcTransmitterFlow(fNewFlowObject.uniqueIdToString),
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

                if (fRefObject.fObjectType == FObjectType.OpcCondition)
                {
                    fNewObject = ((FOpcCondition)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.OpcExpression)
                {
                    fNewObject = ((FOpcExpression)fRefObject).pasteSibling();
                }
                // --
                else if (fRefObject.fObjectType == FObjectType.OpcTransfer)
                {
                    fNewObject = ((FOpcTransfer)fRefObject).pasteSibling();
                }
                // --
                if (fRefObject.fObjectType == FObjectType.HostCondition)
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
            FScenario fSnr = null;
            FIObject fNewFlowObject = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fNewFlowCtrl = null;

            try
            {
                fSnr = (FScenario)flcContainer.Tag;
                fNewFlowObject = (FIObject)fSnr.pasteChild();

                // --

                if (fNewFlowObject.fObjectType == FObjectType.OpcTrigger)
                {
                    fNewFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FOpcTriggerFlow(fNewFlowObject.uniqueIdToString));
                }
                else if (fNewFlowObject.fObjectType == FObjectType.OpcTransmitter)
                {
                    fNewFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FOpcTransmitterFlow(fNewFlowObject.uniqueIdToString));
                }
                if (fNewFlowObject.fObjectType == FObjectType.HostTrigger)
                {
                    fNewFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FHostTriggerFlow(fNewFlowObject.uniqueIdToString));
                }
                else if (fNewFlowObject.fObjectType == FObjectType.HostTransmitter)
                {
                    fNewFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FHostTransmitterFlow(fNewFlowObject.uniqueIdToString));
                }
                // --
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
                fSnr = null;
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

                if (fParent.fObjectType == FObjectType.OpcTrigger)
                {
                    fChild = ((FOpcTrigger)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.OpcCondition)
                {
                    fChild = ((FOpcCondition)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.OpcExpression)
                {
                    fChild = ((FOpcExpression)fParent).pasteChild();
                }
                // --
                else if (fParent.fObjectType == FObjectType.OpcTransmitter)
                {
                    fChild = ((FOpcTransmitter)fParent).pasteChild();
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
                    FMessageBox.showInformation("Search", m_fOpmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
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

                fResult = m_fOpmCore.fOpmFileInfo.fOpcDriver.searchScenarioSeries(fObject, fSnr, searchWord);
                if (fResult == null)
                {
                    FMessageBox.showInformation("Search", m_fOpmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
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

        private void procMenuWriteOpcMessage(
            )
        {
            FIObject fObject = null;
            FOpcTransfer fOpcTransfer = null;
            FOpcMessageTransfer fOpcMessageTransfer = null;

            try
            {
                fObject = (FIObject)tvwFlow.ActiveNode.Tag;
                // --

                if (fObject.fObjectType != FObjectType.OpcTransfer)
                {
                    return;
                }

                // -- 

                fOpcTransfer = (FOpcTransfer)fObject;
                // --
                fOpcMessageTransfer = fOpcTransfer.fMessage.createTransfer();
                fOpcMessageTransfer.write(fOpcTransfer.fSession);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fObject = null;
                fOpcTransfer = null;
                fOpcMessageTransfer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSendHostMessage(
            )
        {
            FIObject fObject = null;
            FHostTransfer fHostTransfer = null;
            FHostMessageTransfer fHostMessageTransfer = null;

            try
            {
                fObject = (FIObject)tvwFlow.ActiveNode.Tag;
                // --

                if (fObject.fObjectType != FObjectType.HostTransfer)
                {
                    return;
                }

                // -- 

                fHostTransfer = (FHostTransfer)fObject;
                // --
                fHostMessageTransfer = fHostTransfer.fMessage.createTransfer();
                fHostMessageTransfer.send(fHostTransfer.fSession);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fObject = null;
                fHostTransfer = null;
                fHostMessageTransfer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void searchFlow(
            FIObject fObject
            )
        {
            FIObject fSnr = null;
            UltraTreeNode tNode = null;

            try
            {
                fSnr = m_fOpmCore.fOpmFileInfo.fOpcDriver.getParentOfObject(fObject);
                while (fSnr.fObjectType != FObjectType.Scenario)
                {
                    fSnr = m_fOpmCore.fOpmFileInfo.fOpcDriver.getParentOfObject(fSnr);
                }
                searchObject(fSnr);

                // --

                activateContainerForSearchFlow(fObject);

                // --

                tvwFlow.beginUpdate();

                // --

                expandTreeForSearchFlow(fObject);
                tNode = tvwFlow.GetNodeByKey(fObject.uniqueIdToString);
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
                tNode = null;
                fSnr = null;
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
                    fObject.fObjectType == FObjectType.OpcTrigger ||
                    fObject.fObjectType == FObjectType.OpcTransmitter ||
                    fObject.fObjectType == FObjectType.HostTrigger ||
                    fObject.fObjectType == FObjectType.HostTransmitter ||
                    fObject.fObjectType == FObjectType.Judgement ||
                    fObject.fObjectType == FObjectType.Mapper ||
                    fObject.fObjectType == FObjectType.Storage ||
                    fObject.fObjectType == FObjectType.Callback ||
                    fObject.fObjectType == FObjectType.Branch ||
                    fObject.fObjectType == FObjectType.Comment ||
                    fObject.fObjectType == FObjectType.Pauser ||
                    fObject.fObjectType == FObjectType.EntryPoint ||
                    fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                    fObject.fObjectType == FObjectType.EquipmentStateAlterer
                    )
                {
                    foreach (Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fFlowCtrl in flcContainer.fFlowCtrlCollection)
                    {
                        if (((FIObject)fFlowCtrl.Tag).uniqueIdToString == fObject.uniqueIdToString)
                        {
                            flcContainer.activateFlowCtrl(fFlowCtrl);
                            break;
                        }
                    }

                }
                else
                {
                    activateContainerForSearchFlow(m_fOpmCore.fOpmFileInfo.fOpcDriver.getParentOfObject(fObject));
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

                fParent = m_fOpmCore.fOpmFileInfo.fOpcDriver.getParentOfObject(fObject);

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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FEquipmentModeler Form Event Handler

        private void FEquipmentModeler_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designTreeOfScenario();
                designTreeOfFlow();

                // --

                tvwScenario.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuEqmPopupMenu]);
                flcContainer.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuEqmPopupMenu]);
                tvwFlow.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuEqmPopupMenu]);

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

                tvwScenario.BeforeMouseDown += new FTreeViewBeforeMouseDownEventHandler(tvwScenario_BeforeMouseDown);

                // --

                m_fEventHandler = new FEventHandler(m_fOpmCore.fOpmFileInfo.fOpcDriver, this);
                // --
                m_fEventHandler.ObjectInsertBeforeCompleted += new FObjectInsertBeforeCompletedEventHandler(m_fEventHandler_ObjectInsertBeforeCompleted);
                m_fEventHandler.ObjectInsertAfterCompleted += new FObjectInsertAfterCompletedEventHandler(m_fEventHandler_ObjectInsertAfterCompleted);
                m_fEventHandler.ObjectAppendCompleted += new FObjectAppendCompletedEventHandler(m_fEventHandler_ObjectAppendCompleted);
                m_fEventHandler.ObjectRemoveCompleted += new FObjectRemoveCompletedEventHandler(m_fEventHandler_ObjectRemoveCompleted);
                m_fEventHandler.ObjectMoveUpCompleted += new FObjectMoveUpCompletedEventHandler(m_fEventHandler_ObjectMoveUpCompleted);
                m_fEventHandler.ObjectMoveDownCompleted += new FObjectMoveDownCompletedEventHandler(m_fEventHandler_ObjectMoveDownCompleted);
                m_fEventHandler.ObjectMoveToCompleted += new FObjectMoveToCompletedEventHandler(m_fEventHandler_ObjectMoveToCompleted);
                m_fEventHandler.ObjectModifyCompleted += new FObjectModifyCompletedEventHandler(m_fEventHandler_ObjectModifyCompleted);
                m_fEventHandler.OpcDeviceStateChanged += new FOpcDeviceStateChangedEventHandler(m_fEventHandler_OpcDeviceStateChanged);
                m_fEventHandler.HostDeviceStateChanged += new FHostDeviceStateChangedEventHandler(m_fEventHandler_HostDeviceStateChanged);

                // --

                m_fOpmCore.fOption.fChildFormList.add(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }             

        //------------------------------------------------------------------------------------------------------------------------

        private void FEquipmentModeler_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                loadTreeOfObject();

                // --

                tvwScenario.Focus();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FEquipmentModeler_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                if (m_fEventHandler != null)
                {
                    m_fOpmCore.fOpmFileInfo.fOpcDriver.waitEventHandlingCompleted();

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
                    m_fEventHandler.OpcDeviceStateChanged -= new FOpcDeviceStateChangedEventHandler(m_fEventHandler_OpcDeviceStateChanged);
                    m_fEventHandler.HostDeviceStateChanged -= new FHostDeviceStateChangedEventHandler(m_fEventHandler_HostDeviceStateChanged);
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

                tvwScenario.BeforeMouseDown -= new FTreeViewBeforeMouseDownEventHandler(tvwScenario_BeforeMouseDown);
               
                // --

                m_fOpmCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }        

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fEventHandler Object Evnet Handler

        private void m_fEventHandler_ObjectInsertBeforeCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.Equipment ||
                    e.fObject.fObjectType == FObjectType.ScenarioGroup ||
                    e.fObject.fObjectType == FObjectType.Scenario                    
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.OpcTrigger ||
                    e.fObject.fObjectType == FObjectType.OpcTransmitter ||
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
                    e.fObject.fObjectType == FObjectType.OpcCondition ||
                    e.fObject.fObjectType == FObjectType.OpcExpression ||
                    e.fObject.fObjectType == FObjectType.OpcTransfer ||
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                    e.fObject.fObjectType == FObjectType.Equipment ||
                    e.fObject.fObjectType == FObjectType.ScenarioGroup ||
                    e.fObject.fObjectType == FObjectType.Scenario        
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.OpcTrigger ||
                    e.fObject.fObjectType == FObjectType.OpcTransmitter ||
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
                    e.fObject.fObjectType == FObjectType.OpcCondition ||
                    e.fObject.fObjectType == FObjectType.OpcExpression ||
                    e.fObject.fObjectType == FObjectType.OpcTransfer ||
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                    e.fObject.fObjectType == FObjectType.Equipment ||
                    e.fObject.fObjectType == FObjectType.ScenarioGroup ||
                    e.fObject.fObjectType == FObjectType.Scenario   
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.OpcTrigger ||
                    e.fObject.fObjectType == FObjectType.OpcTransmitter ||
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
                    e.fObject.fObjectType == FObjectType.OpcCondition ||
                    e.fObject.fObjectType == FObjectType.OpcExpression ||
                    e.fObject.fObjectType == FObjectType.OpcTransfer ||
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                if (
                    e.fObject.fObjectType == FObjectType.Equipment ||
                    e.fObject.fObjectType == FObjectType.ScenarioGroup ||
                    e.fObject.fObjectType == FObjectType.Scenario   
                    )
                {
                    removeTreeOfObject(e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.OpcTrigger ||
                    e.fObject.fObjectType == FObjectType.OpcTransmitter ||
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
                    e.fObject.fObjectType == FObjectType.OpcCondition ||
                    e.fObject.fObjectType == FObjectType.OpcExpression ||
                    e.fObject.fObjectType == FObjectType.OpcTransfer ||
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                    e.fObject.fObjectType == FObjectType.OpcTrigger ||
                    e.fObject.fObjectType == FObjectType.OpcTransmitter ||
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
                    e.fObject.fObjectType == FObjectType.OpcCondition ||
                    e.fObject.fObjectType == FObjectType.OpcExpression ||
                    e.fObject.fObjectType == FObjectType.OpcTransfer ||
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                    e.fObject.fObjectType == FObjectType.OpcTrigger ||
                    e.fObject.fObjectType == FObjectType.OpcTransmitter ||
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
                    e.fObject.fObjectType == FObjectType.OpcCondition ||
                    e.fObject.fObjectType == FObjectType.OpcExpression ||
                    e.fObject.fObjectType == FObjectType.OpcTransfer ||
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                    e.fObject.fObjectType == FObjectType.OpcTrigger ||
                    e.fObject.fObjectType == FObjectType.OpcTransmitter ||
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
                    e.fObject.fObjectType == FObjectType.OpcCondition ||
                    e.fObject.fObjectType == FObjectType.OpcExpression ||
                    e.fObject.fObjectType == FObjectType.OpcTransfer ||
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                if (
                    e.fObject.fObjectType == FObjectType.OpcDriver ||
                    e.fObject.fObjectType == FObjectType.Equipment ||
                    e.fObject.fObjectType == FObjectType.ScenarioGroup
                    )
                {
                    refreshObject(e.fObject);
                }
                else if (e.fObject.fObjectType == FObjectType.Scenario)
                {
                    refreshObject(e.fObject);
                    refreshScenario(e.fObject);
                    // --
                    foreach (FIObject fObject in ((FScenario)e.fObject).fReferenceObjectCollection)
                    {
                        if (
                            fObject.fObjectType == FObjectType.Branch
                            )
                        {
                            refreshFlow(fObject);
                        }
                    }
                }
                else if (
                    e.fObject.fObjectType == FObjectType.OpcTrigger ||
                    e.fObject.fObjectType == FObjectType.OpcTransmitter ||
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
                    e.fObject.fObjectType == FObjectType.OpcCondition ||
                    e.fObject.fObjectType == FObjectType.OpcExpression ||
                    e.fObject.fObjectType == FObjectType.OpcTransfer ||
                    e.fObject.fObjectType == FObjectType.HostCondition ||
                    e.fObject.fObjectType == FObjectType.HostExpression ||
                    e.fObject.fObjectType == FObjectType.HostTransfer ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateAlterer ||
                    e.fObject.fObjectType == FObjectType.JudgementCondition ||
                    e.fObject.fObjectType == FObjectType.JudgementExpression ||
                    e.fObject.fObjectType == FObjectType.Function
                    )
                {
                    refreshChildFlow(e.fObject);
                }
                else if (e.fObject.fObjectType == FObjectType.OpcDevice)
                {
                    foreach (FIObject fObject in ((FOpcDevice)e.fObject).fReferenceObjectCollection)
                    {
                        if (
                            fObject.fObjectType == FObjectType.OpcCondition ||
                            fObject.fObjectType == FObjectType.OpcTransfer
                            )
                        {
                            refreshChildFlow(fObject);
                        }
                    }
                }
                else if (e.fObject.fObjectType == FObjectType.OpcSession)
                {
                    foreach (FIObject fObject in ((FOpcSession)e.fObject).fReferenceObjectCollection)
                    {
                        if (
                            fObject.fObjectType == FObjectType.OpcCondition ||
                            fObject.fObjectType == FObjectType.OpcTransfer
                            )
                        {
                            refreshChildFlow(fObject);
                        }
                    }
                }
                // --
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
                        if (fObject.fObjectType == FObjectType.OpcExpression)
                        {
                            refreshChildFlow(fObject);
                            refreshChildFlow(((FOpcExpression)fObject).fAncestorOpcCondition);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_OpcDeviceStateChanged(
            object sender, 
            FOpcDeviceStateChangedEventArgs e
            )
        {
            try
            {
                if (tvwFlow.ActiveNode != null)
                {
                    if (((FIObject)tvwFlow.ActiveNode.Tag).fObjectType == FObjectType.OpcTransfer)
                    {
                        controlMenuOfScenario();
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            { 
            
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_HostDeviceStateChanged(
            object sender, 
            FHostDeviceStateChangedEventArgs e
            )
        {
            try
            {
                if (tvwFlow.ActiveNode != null)
                {
                    if (((FIObject)tvwFlow.ActiveNode.Tag).fObjectType == FObjectType.HostTransfer)
                    {
                        controlMenuOfScenario();
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                if (e.Tool.Key == FMenuKey.MenuEqmWriteOpcMessage)
                {
                    procMenuWriteOpcMessage();
                }
                else if (e.Tool.Key == FMenuKey.MenuEqmSendHostMessage)
                {
                    procMenuSendHostMessage();
                }
                else if (e.Tool.Key == FMenuKey.MenuEqmExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuEqmCollapse)
                {
                    procMenuCollapse();
                }
                else if (e.Tool.Key == FMenuKey.MenuEqmReplace)
                {
                    procMenuReplace();
                }
                else if (e.Tool.Key == FMenuKey.MenuEqmCut)
                {
                    procMenuCut();
                }
                else if (e.Tool.Key == FMenuKey.MenuEqmCopy)
                {
                    procMenuCopy();
                }
                else if (e.Tool.Key == FMenuKey.MenuEqmClone)
                {
                    procMenuClone();
                }
                else if (e.Tool.Key == FMenuKey.MenuEqmRelation)
                {
                    procMenuRelation();
                }
                else if (e.Tool.Key == FMenuKey.MenuEqmApplyOsmFiles)
                {
                    procMenuApplyOSMFiles();
                }
                else if (e.Tool.Key == FMenuKey.MenuEqmMoveUp)
                {
                    if (tvwScenario.Focused)
                    {
                        procMenuMoveUp(e.Tool.Key);
                    }
                    else
                    {
                        procMenuMoveUpFlow();
                    }
                }
                else if (e.Tool.Key == FMenuKey.MenuEqmMoveDown)
                {
                    if (tvwScenario.Focused)
                    {
                        procMenuMoveDown();
                    }
                    else
                    {
                        procMenuMoveDownFlow();
                    }
                }
                else if (e.Tool.Key == FMenuKey.MenuEqmPasteSibling)
                {
                    if (
                       m_fActiveObject.fObjectType == FObjectType.Equipment ||
                       m_fActiveObject.fObjectType == FObjectType.ScenarioGroup ||
                       m_fActiveObject.fObjectType == FObjectType.Scenario
                       )
                    {
                        procMenuPasteSibling();
                    }
                    else if (
                        m_fActiveObject.fObjectType == FObjectType.OpcTrigger ||
                        m_fActiveObject.fObjectType == FObjectType.OpcTransmitter ||
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
                        procMenuPasteSiblingOfFlow();
                    }
                    else
                    {
                        procMenuPasteSiblingOfChildFlow();
                    }
                }
                else if (e.Tool.Key == FMenuKey.MenuEqmPasteChild)
                {
                    if (
                       m_fActiveObject.fObjectType == FObjectType.OpcDriver ||
                       m_fActiveObject.fObjectType == FObjectType.Equipment ||
                       m_fActiveObject.fObjectType == FObjectType.ScenarioGroup
                       )
                    {
                        procMenuPasteChild();
                    }
                    else if (m_fActiveObject.fObjectType == FObjectType.Scenario)
                    {
                        procMenuPasteChildOfFlow();
                    }
                    else
                    {
                        procMenuPasteChildOfChildFlow();
                    }
                }
                else if (e.Tool.Key == FMenuKey.MenuEqmRemove)
                {
                    if (
                        m_fActiveObject.fObjectType == FObjectType.OpcDriver ||
                        m_fActiveObject.fObjectType == FObjectType.Equipment ||
                        m_fActiveObject.fObjectType == FObjectType.ScenarioGroup ||
                        m_fActiveObject.fObjectType == FObjectType.Scenario
                        )
                    {
                        procMenuRemoveObject();
                    }
                    else if (
                        m_fActiveObject.fObjectType == FObjectType.OpcTrigger ||
                        m_fActiveObject.fObjectType == FObjectType.OpcTransmitter ||
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
                else if (e.Tool.Key == FMenuKey.MenuEqmScenarioModeler)
                {
                    procMenuScenarioDesigner();
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeEquipment ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeScenarioGroup ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeScenario
                    )
                {
                    procMenuInsertBeforeObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterEquipment ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterScenarioGroup ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterScenario
                    )
                {
                    procMenuInsertAfterObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuEqmAppendEquipment ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendScenarioGroup ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendScenario
                    )
                {
                    procMenuAppendObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeOpcTrigger ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeOpcTransmitter ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeOpcTrigger ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeOpcTransmitter ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeHostTrigger ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeHostTransmitter ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeEquipmentStateSetAlterer ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeJudgement ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeMapper ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeStorage ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeCallback ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeBranch ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeComment ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforePauser ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeEntryPoint
                    )
                {
                    procMenuInsertBeforeFlow(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterOpcTrigger ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterOpcTransmitter ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterOpcTrigger ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterOpcTransmitter ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterHostTrigger ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterHostTransmitter ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterEquipmentStateSetAlterer ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterJudgement ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterMapper ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterStorage ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterCallback ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterBranch ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterComment ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterPauser ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterEntryPoint
                    )
                {
                    procMenuInsertAfterFlow(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuEqmAppendOpcTrigger ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendOpcTransmitter ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendHostTrigger ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendHostTransmitter ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendEquipmentStateSetAlterer ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendJudgement ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendMapper ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendStorage ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendCallback ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendBranch ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendComment ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendPauser ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendEntryPoint
                    )
                {
                    procMenuAppendFlow(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeOpcCondition ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeOpcExpression ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeOpcTransfer ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeHostCondition ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeHostExpression ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeHostTransfer ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeEquipmentStateAlterer ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeJudgementCondition ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeJudgementExpression ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertBeforeFunction
                    )
                {
                    procMenuInsertBeforeChildFlow(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterOpcCondition ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterOpcExpression ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterOpcTransfer ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterHostCondition ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterHostExpression ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterHostTransfer ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterEquipmentStateAlterer ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterJudgementCondition ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterJudgementExpression ||
                    e.Tool.Key == FMenuKey.MenuEqmInsertAfterFunction
                    )
                {
                    procMenuInsertAfterChildFlow(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuEqmAppendOpcCondition ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendOpcExpression ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendOpcTransfer ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendHostCondition ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendHostExpression ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendHostTransfer ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendEquipmentStateAlterer ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendJudgementCondition ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendJudgementExpression ||
                    e.Tool.Key == FMenuKey.MenuEqmAppendFunction
                    )
                {
                    procMenuAppendChildFlow(e.Tool.Key);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }        

        #endregion                        

        //------------------------------------------------------------------------------------------------------------------------

        #region tvwScenario Control Event Handler

        private void tvwScenario_AfterExpand(
            object sender,
            NodeEventArgs e
            )
        {
            try
            {
                tvwScenario.beginUpdate();

                // --

                foreach (UltraTreeNode tNode in e.TreeNode.Nodes)
                {
                    if (tNode.Nodes.Count > 0)
                    {
                        continue;
                    }
                    loadTreeOfChildObject(tNode);
                }

                // --

                tvwScenario.endUpdate();
            }
            catch (Exception ex)
            {
                tvwScenario.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwScenario_AfterActivate(
            object sender,
            NodeEventArgs e
            )
        {
            FIObject fObject = null;

            try
            {
                if (tvwScenario.ActiveNode == null)
                {
                    return;
                }

                // --

                fObject = (FIObject)tvwScenario.ActiveNode.Tag;
                // --
                if (fObject.fObjectType == FObjectType.OpcDriver)
                {
                    pgdProp.selectedObject = new FPropOcd(m_fOpmCore, pgdProp, (FOpcDriver)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Equipment)
                {
                    pgdProp.selectedObject = new FPropEqp(m_fOpmCore, pgdProp, (FEquipment)fObject);
                }
                else if (fObject.fObjectType == FObjectType.ScenarioGroup)
                {
                    pgdProp.selectedObject = new FPropSng(m_fOpmCore, pgdProp, (FScenarioGroup)fObject);
                }
                // --
                m_fActiveObject = fObject;

                // --

                loadContainerOfFlow();
                controlMenu();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        private void tvwScenario_Enter(
            object sender, 
            EventArgs e
            )
        {
            FIObject fObject = null;

            try
            {
                if (tvwScenario.ActiveNode == null)
                {
                    return;
                }

                // --

                fObject = (FIObject)tvwScenario.ActiveNode.Tag;
                // --
                if (fObject.fObjectType == FObjectType.OpcDriver)
                {
                    pgdProp.selectedObject = new FPropOcd(m_fOpmCore, pgdProp, (FOpcDriver)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Equipment)
                {
                    pgdProp.selectedObject = new FPropEqp(m_fOpmCore, pgdProp, (FEquipment)fObject);
                }
                else if (fObject.fObjectType == FObjectType.ScenarioGroup)
                {
                    pgdProp.selectedObject = new FPropSng(m_fOpmCore, pgdProp, (FScenarioGroup)fObject);
                }
                // --
                m_fActiveObject = fObject;

                // --

                loadContainerOfFlow();
                controlMenu();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        private void tvwScenario_Leave(
            object sender, 
            EventArgs e
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwScenario_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {            
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEqmRemove].SharedProps.Enabled)
                    {
                        procMenuRemoveObject();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.X)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEqmCut].SharedProps.Enabled)
                    {
                        procMenuCut();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.C)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEqmCopy].SharedProps.Enabled)
                    {
                        procMenuCopy();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {                    
                    if (mnuMenu.Tools[FMenuKey.MenuEqmPasteSibling].SharedProps.Enabled)
                    {
                        procMenuPasteSibling();
                    }                    
                }
                else if (e.Control && e.KeyCode == Keys.B)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEqmPasteChild].SharedProps.Enabled)
                    {
                        procMenuPasteChild();
                    }                    
                }
                else if (e.Control && e.KeyCode == Keys.U)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEqmMoveUp].SharedProps.Enabled)
                    {
                        procMenuMoveUp(FMenuKey.MenuEqmMoveUp);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.D)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEqmMoveDown].SharedProps.Enabled)
                    {
                        procMenuMoveDown();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.E)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEqmExpand].SharedProps.Enabled)
                    {
                        procMenuExpand();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.L)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEqmCollapse].SharedProps.Enabled)
                    {
                        procMenuCollapse();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.R)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEqmRelation].SharedProps.Enabled)
                    {
                        procMenuRelation();
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwScenario_BeforeMouseDown(
           object sender,
           FTreeViewBeforeMouseDownEventArgs e
           )
        {
            try
            {
                if (tvwScenario.ActiveNode == e.tNode)
                {
                    controlMenu();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwScenario_MouseMove(
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

                tNode = tvwScenario.GetNodeFromPoint(e.X, e.Y);
                if (tNode == null)
                {
                    return;
                }

                // --                               

                fObject = (FIObject)tNode.Tag;
                fDragDropData = new FDragDropData(fObject);
                // --                
                tvwScenario.DoDragDrop(new System.Windows.Forms.DataObject(fDragDropData), DragDropEffects.All);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                tNode = null;
                fObject = null;
                fDragDropData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwScenario_DragOver(
            object sender,
            DragEventArgs e
            )
        {
            FDragDropData fDragDropData = null;
            UltraTreeNode tRefNode = null;
            FIObject fRefObject = null;
            int cnt = 0;

            try
            {                
                tRefNode = tvwScenario.GetNodeFromPoint(tvwScenario.PointToClient(new System.Drawing.Point(e.X, e.Y)));                
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

                    if (fRefObject.fObjectType == FObjectType.OpcDriver)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.Equipment)
                        {
                            #region Equipment

                            if (((FOpcDriver)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FOpcDriver)fRefObject).fChildEquipmentCollection.count;
                                fRefObject = ((FOpcDriver)fRefObject).fChildEquipmentCollection[cnt - 1];
                                if (!fRefObject.Equals(fDragDropData.fObject))
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
                    }
                    else if (fRefObject.fObjectType == FObjectType.Equipment)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.Equipment)
                        {
                            #region Equipment

                            if (((FEquipment)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FEquipment)fRefObject).fNextSibling == null || !((FEquipment)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.ScenarioGroup)
                        {
                            #region ScenarioGroup

                            if (((FEquipment)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FEquipment)fRefObject).fChildScenarioGroupCollection.count;
                                if (cnt == 0)
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                                else
                                {
                                    fRefObject = ((FEquipment)fRefObject).fChildScenarioGroupCollection[cnt - 1];
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
                    }                    
                    else if (fRefObject.fObjectType == FObjectType.ScenarioGroup)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.ScenarioGroup)
                        {
                            #region ScenarioGroup

                            if (((FScenarioGroup)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FScenarioGroup)fRefObject).fNextSibling == null || !((FScenarioGroup)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Scenario)
                        {
                            #region Scenario

                            if (((FScenarioGroup)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FScenarioGroup)fRefObject).fChildScenarioCollection.count;
                                if (cnt == 0)
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                                else
                                {
                                    fRefObject = ((FScenarioGroup)fRefObject).fChildScenarioCollection[cnt - 1];
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
                    }
                    else if (fRefObject.fObjectType == FObjectType.Scenario)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.Scenario)
                        {
                            #region Scenario

                            if (((FScenario)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FScenario)fRefObject).fNextSibling == null || !((FScenario)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                    }                    

                    #endregion
                }

                // --

                FCommon.resetDragOverTreeNode(tRefNode);
                e.Effect = DragDropEffects.None;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                tRefNode = null;
                fRefObject = null;
                fDragDropData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwScenario_DragDrop(
            object sender,
            DragEventArgs e
            )
        {
            FDragDropAction fAction = FDragDropAction.Move;
            FDragDropData fDragDropData = null;
            UltraTreeNode tRefNode = null;
            UltraTreeNode tNode = null;
            FIObject fRefObject = null;
            int cnt = 0;
            string uniqueId = string.Empty;
            string refUniqueId = string.Empty;

            try
            {
                tRefNode = tvwScenario.GetNodeFromPoint(tvwScenario.PointToClient(new System.Drawing.Point(e.X, e.Y)));
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

                    if (fRefObject.fObjectType == FObjectType.OpcDriver)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.Equipment)
                        {
                            #region Equipment

                            if (e.Effect == DragDropEffects.Move)
                            {
                                cnt = ((FOpcDriver)fRefObject).fChildEquipmentCollection.count;
                                fRefObject = ((FOpcDriver)fRefObject).fChildEquipmentCollection[cnt - 1];
                                ((FEquipment)fDragDropData.fObject).moveTo((FEquipment)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FEquipment)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcDriver)fRefObject).pasteChildEquipment();
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
                    }
                    else if (fRefObject.fObjectType == FObjectType.Equipment)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.Equipment)
                        {
                            #region Equipment

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FEquipment)fDragDropData.fObject).moveTo((FEquipment)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FEquipment)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FEquipment)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.ScenarioGroup)
                        {
                            #region ScenarioGroup

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FScenarioGroup)fDragDropData.fObject).moveTo((FEquipment)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FScenarioGroup)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FEquipment)fRefObject).pasteChild();
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
                    }
                    else if (fRefObject.fObjectType == FObjectType.ScenarioGroup)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.ScenarioGroup)
                        {
                            #region ScenarioGroup

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FScenarioGroup)fDragDropData.fObject).moveTo((FScenarioGroup)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FScenarioGroup)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FScenarioGroup)fRefObject).pasteSibling();
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

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FScenario)fDragDropData.fObject).moveTo((FScenarioGroup)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FScenario)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FScenarioGroup)fRefObject).pasteChild();
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
                    }
                    else if (fRefObject.fObjectType == FObjectType.Scenario)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.Scenario)
                        {
                            #region Scenario

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FScenario)fDragDropData.fObject).moveTo((FScenario)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FScenario)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FScenario)fRefObject).pasteSibling();
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

                tvwScenario.beginUpdate();

                // --

                if (fAction == FDragDropAction.Move || fAction == FDragDropAction.Copy)
                {
                    uniqueId = fDragDropData.fObject.uniqueIdToString;
                    tNode = tvwScenario.GetNodeByKey(uniqueId);
                    if (tNode != null)
                    {
                        tNode.Remove();
                    }
                    tNode = new UltraTreeNode(uniqueId);
                    tNode.Tag = fDragDropData.fObject;
                    FCommon.refreshTreeNodeOfObject(fDragDropData.fObject, tvwScenario, tNode);
                    loadTreeOfChildObject(tNode);

                    // --

                    refUniqueId = fRefObject.uniqueIdToString;
                    tRefNode = tvwScenario.GetNodeByKey(refUniqueId);
                    if (fRefObject.fObjectType == fDragDropData.fObject.fObjectType)
                    {
                        tRefNode.Parent.Nodes.Insert(tRefNode.Index + 1, tNode);
                    }
                    else
                    {
                        tRefNode.Nodes.Add(tNode);
                    }
                    // --
                    tvwScenario.SelectedNodes.Clear();
                    tvwScenario.ActiveNode = tNode;
                }
                else if (fAction == FDragDropAction.Set)
                {

                }                

                // --

                tvwScenario.endUpdate();
            }
            catch (Exception ex)
            {
                tvwScenario.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fDragDropData = null;
                tRefNode = null;
                tNode = null;
                fRefObject = null;
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
                if (fObject == null)
                {
                    fObject = (FIObject)tvwScenario.ActiveNode.Tag;
                    if (fObject.fObjectType != FObjectType.Scenario)
                    {
                        return;
                    }
                }

                // --

                pgdProp.selectedObject = new FPropSnr(m_fOpmCore, pgdProp, (FScenario)fObject);
                // --
                m_fActiveObject = fObject;

                // --

                loadTreeOfFlow();
                controlMenuOfScenario();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                if (fObject.fObjectType == FObjectType.OpcTrigger)
                {
                    pgdProp.selectedObject = new FPropOtr(m_fOpmCore, pgdProp, (FOpcTrigger)fObject);
                }
                else if (fObject.fObjectType == FObjectType.OpcTransmitter)
                {
                    pgdProp.selectedObject = new FPropOtn(m_fOpmCore, pgdProp, (FOpcTransmitter)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostTrigger)
                {
                    pgdProp.selectedObject = new FPropHtr(m_fOpmCore, pgdProp, (FHostTrigger)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostTransmitter)
                {
                    pgdProp.selectedObject = new FPropHtn(m_fOpmCore, pgdProp, (FHostTransmitter)fObject);
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    pgdProp.selectedObject = new FPropEsa(m_fOpmCore, pgdProp, (FEquipmentStateSetAlterer)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Judgement)
                {
                    pgdProp.selectedObject = new FPropJdm(m_fOpmCore, pgdProp, (FJudgement)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Mapper)
                {
                    pgdProp.selectedObject = new FPropMap(m_fOpmCore, pgdProp, (FMapper)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Storage)
                {
                    pgdProp.selectedObject = new FPropStg(m_fOpmCore, pgdProp, (FStorage)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Callback)
                {
                    pgdProp.selectedObject = new FPropCbk(m_fOpmCore, pgdProp, (FCallback)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Branch)
                {
                    pgdProp.selectedObject = new FPropBrn(m_fOpmCore, pgdProp, (FBranch)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Comment)
                {
                    pgdProp.selectedObject = new FPropCmt(m_fOpmCore, pgdProp, (FComment)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Pauser)
                {
                    pgdProp.selectedObject = new FPropPau(m_fOpmCore, pgdProp, (FPauser)fObject);
                }
                else if (fObject.fObjectType == FObjectType.EntryPoint)
                {
                    pgdProp.selectedObject = new FPropEtp(m_fOpmCore, pgdProp, (FEntryPoint)fObject);
                }
                // --
                m_fActiveObject = fObject;

                // --

                loadTreeOfFlow();
                controlMenuOfScenario();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                    if (mnuMenu.Tools[FMenuKey.MenuEqmRemove].SharedProps.Enabled)
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
                        if (mnuMenu.Tools[FMenuKey.MenuEqmCut].SharedProps.Enabled)
                        {
                            procMenuCut();
                        }
                    }
                    else if (e.Key == System.Windows.Input.Key.C)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuEqmCopy].SharedProps.Enabled)
                        {
                            procMenuCopy();
                        }
                    }
                    else if (e.Key == System.Windows.Input.Key.V)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuEqmPasteSibling].SharedProps.Enabled)
                        {
                            procMenuPasteSiblingOfFlow();
                        }
                    }
                    else if (e.Key == System.Windows.Input.Key.B)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuEqmPasteChild].SharedProps.Enabled)
                        {
                            procMenuPasteChildOfChildFlow();
                        }
                    }
                    else if (e.Key == System.Windows.Input.Key.U)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuEqmMoveUp].SharedProps.Enabled)
                        {
                            procMenuMoveUpFlow();
                        }
                    }
                    else if (e.Key == System.Windows.Input.Key.D)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuEqmMoveDown].SharedProps.Enabled)
                        {
                            procMenuMoveDownFlow();
                        }
                    }
                    else if (e.Key == System.Windows.Input.Key.E)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuEqmExpand].SharedProps.Enabled)
                        {
                            procMenuExpand();
                        }
                    }
                    else if (e.Key == System.Windows.Input.Key.L)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuEqmCollapse].SharedProps.Enabled)
                        {
                            procMenuCollapse();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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

                    if (fRefObject.fObjectType == FObjectType.OpcTrigger)
                    {
                        #region OpcTrigger

                        if (
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter ||
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

                            if (((FOpcTrigger)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    ((FOpcTrigger)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    (((FOpcTrigger)fRefObject).fNextSibling == null || !((FOpcTrigger)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcDevice)
                        {
                            #region OpcDevice

                            if (((FOpcTrigger)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.effect = System.Windows.DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessage)
                        {
                            #region OpcMessage

                            if (((FOpcTrigger)fRefObject).equalsModelingFile(fDragDropData.fObject))
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
                    else if (fRefObject.fObjectType == FObjectType.OpcTransmitter)
                    {
                        #region OpcTransmitter

                        if (
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter ||
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

                            if (((FOpcTransmitter)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    ((FOpcTransmitter)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    (((FOpcTransmitter)fRefObject).fNextSibling == null || !((FOpcTransmitter)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessage)
                        {
                            #region OpcMessage

                            if (((FOpcTransmitter)fRefObject).equalsModelingFile(fDragDropData.fObject))
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
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter ||
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
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter ||
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
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter ||
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
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter ||
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
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter ||
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
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter ||
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
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter ||
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
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter ||
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
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter ||
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
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter ||
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
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger ||
                            fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter ||
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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

                    if (fRefObject.fObjectType == FObjectType.OpcTrigger)
                    {
                        #region OpcTrigger

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger)                        
                        {
                            #region OpcTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {                                
                                ((FOpcTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FOpcTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter)
                        {
                            #region OpcTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FOpcTrigger)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTrigger)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTrigger)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTrigger)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTrigger)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTrigger)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTrigger)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTrigger)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTrigger)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTrigger)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTrigger)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcDevice)
                        {
                            #region OpcDevice

                            if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                fChildObject = ((FOpcTrigger)fRefObject).appendChildOpcCondition(new FOpcCondition(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                                ((FOpcCondition)fChildObject).fConditionMode = FOpcConditionMode.Connection;
                                ((FOpcCondition)fChildObject).setDevice((FOpcDevice)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessage)
                        {
                            #region OpcMessage

                            if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                fSession = this.m_fOpmCore.fOpmFileInfo.fOpcDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FOpcSession)fSession).fParent;
                                // --
                                fChildObject = ((FOpcTrigger)fRefObject).appendChildOpcCondition(new FOpcCondition(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                                ((FOpcCondition)fChildObject).fConditionMode = FOpcConditionMode.Expression;
                                ((FOpcCondition)fChildObject).setMessage((FOpcDevice)fDevice, (FOpcSession)fSession, (FOpcMessage)fDragDropData.fObject);
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
                    else if (fRefObject.fObjectType == FObjectType.OpcTransmitter)
                    {
                        #region OpcTransmitter

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger)
                        {
                            #region OpcTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FOpcTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter)
                        {
                            #region OpcTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FOpcTransmitter)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTransmitter)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTransmitter)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTransmitter)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTransmitter)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTransmitter)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTransmitter)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTransmitter)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTransmitter)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTransmitter)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTransmitter)fRefObject).pasteSibling();
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
                                fDragDropData.fObject = (FIObject)((FOpcTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessage)
                        {
                            #region OpcMessage

                            if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                fSession = this.m_fOpmCore.fOpmFileInfo.fOpcDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FOpcSession)fSession).fParent;
                                // --
                                fChildObject = ((FOpcTransmitter)fRefObject).appendChildOpcTransfer(new FOpcTransfer(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));                                
                                ((FOpcTransfer)fChildObject).setMessage((FOpcDevice)fDevice, (FOpcSession)fSession, (FOpcMessage)fDragDropData.fObject);
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

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger)
                        {
                            #region OpcTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTrigger)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter)
                        {
                            #region OpcTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).copy();
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
                                fChildObject = ((FHostTrigger)fRefObject).appendChildHostCondition(new FHostCondition(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
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
                                fSession = this.m_fOpmCore.fOpmFileInfo.fOpcDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FHostSession)fSession).fParent;
                                // --
                                fChildObject = ((FHostTrigger)fRefObject).appendChildHostCondition(new FHostCondition(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
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

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger)
                        {
                            #region OpcTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FHostTransmitter)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter)
                        {
                            #region OpcTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).copy();
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
                                fSession = this.m_fOpmCore.fOpmFileInfo.fOpcDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FHostSession)fSession).fParent;
                                // --
                                fChildObject = ((FHostTransmitter)fRefObject).appendChildHostTransfer(new FHostTransfer(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
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

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger)
                        {
                            #region OpcTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEquipmentStateSetAlterer)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter)
                        {
                            #region OpcTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).copy();
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
                                fChildObject = ((FEquipmentStateSetAlterer)fRefObject).appendChildEquipmentStateAlterer(new FEquipmentStateAlterer(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
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

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger)
                        {
                            #region OpcTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FJudgement)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter)
                        {
                            #region OpcTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).copy();
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
                                fChildObject = ((FJudgement)fRefObject).appendChildJudgementCondition(new FJudgementCondition(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
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

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger)
                        {
                            #region OpcTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FMapper)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter)
                        {
                            #region OpcTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).copy();
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

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger)
                        {
                            #region OpcTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FStorage)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter)
                        {
                            #region OpcTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).copy();
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

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger)
                        {
                            #region OpcTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FCallback)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter)
                        {
                            #region OpcTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).copy();
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
                                fChildObject = ((FCallback)fRefObject).appendChildFunction(new FFunction(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
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

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger)
                        {
                            #region OpcTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FBranch)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter)
                        {
                            #region OpcTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).copy();
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

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger)
                        {
                            #region OpcTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FComment)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter)
                        {
                            #region OpcTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).copy();
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

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger)
                        {
                            #region OpcTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FPauser)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter)
                        {
                            #region OpcTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).copy();
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

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger)
                        {
                            #region OpcTrigger

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTrigger)fDragDropData.fObject).copy();
                                fDragDropData.fObject = (FIObject)((FEntryPoint)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter)
                        {
                            #region OpcTransmitter

                            if (e.effect == System.Windows.DragDropEffects.Move)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).moveTo((FIFlow)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.effect == System.Windows.DragDropEffects.Copy)
                            {
                                ((FOpcTransmitter)fDragDropData.fObject).copy();
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

                    if (fDragDropData.fObject.fObjectType == FObjectType.OpcTrigger)
                    {
                        fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FOpcTriggerFlow(uniqueId);
                    }
                    else if (fDragDropData.fObject.fObjectType == FObjectType.OpcTransmitter)
                    {
                        fFlowCtrl = new Nexplant.MC.Core.FaUIs.WPF.FOpcTransmitterFlow(uniqueId);
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
                        fRefObject.fObjectType == FObjectType.OpcTrigger ||                        
                        fRefObject.fObjectType == FObjectType.OpcTransmitter ||
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
                tvwFlow.endUpdate();                           
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                if (fObject.fObjectType == FObjectType.OpcTrigger)
                {
                    pgdProp.selectedObject = new FPropOtr(m_fOpmCore, pgdProp, (FOpcTrigger)fObject);
                }
                else if (fObject.fObjectType == FObjectType.OpcCondition)
                {
                    pgdProp.selectedObject = new FPropOcn(m_fOpmCore, pgdProp, (FOpcCondition)fObject);
                }
                else if (fObject.fObjectType == FObjectType.OpcExpression)
                {
                    pgdProp.selectedObject = new FPropOep(m_fOpmCore, pgdProp, (FOpcExpression)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.OpcTransmitter)
                {
                    pgdProp.selectedObject = new FPropOtn(m_fOpmCore, pgdProp, (FOpcTransmitter)fObject);
                }
                else if (fObject.fObjectType == FObjectType.OpcTransfer)
                {
                    pgdProp.selectedObject = new FPropOtf(m_fOpmCore, pgdProp, (FOpcTransfer)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostTrigger)
                {
                    pgdProp.selectedObject = new FPropHtr(m_fOpmCore, pgdProp, (FHostTrigger)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostCondition)
                {
                    pgdProp.selectedObject = new FPropHcn(m_fOpmCore, pgdProp, (FHostCondition)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostExpression)
                {
                    pgdProp.selectedObject = new FPropHep(m_fOpmCore, pgdProp, (FHostExpression)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.OpcTransmitter)
                {
                    pgdProp.selectedObject = new FPropOtn(m_fOpmCore, pgdProp, (FOpcTransmitter)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostTransmitter)
                {
                    pgdProp.selectedObject = new FPropHtn(m_fOpmCore, pgdProp, (FHostTransmitter)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostTransfer)
                {
                    pgdProp.selectedObject = new FPropHtf(m_fOpmCore, pgdProp, (FHostTransfer)fObject);
                }                
                // --
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    pgdProp.selectedObject = new FPropEsa(m_fOpmCore, pgdProp, (FEquipmentStateSetAlterer)fObject);
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateAlterer)
                {
                    pgdProp.selectedObject = new FPropEat(m_fOpmCore, pgdProp, (FEquipmentStateAlterer)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Judgement)
                {
                    pgdProp.selectedObject = new FPropJdm(m_fOpmCore, pgdProp, (FJudgement)fObject);
                }
                else if (fObject.fObjectType == FObjectType.JudgementCondition)
                {
                    pgdProp.selectedObject = new FPropJcn(m_fOpmCore, pgdProp, (FJudgementCondition)fObject);
                }
                else if (fObject.fObjectType == FObjectType.JudgementExpression)
                {
                    pgdProp.selectedObject = new FPropJep(m_fOpmCore, pgdProp, (FJudgementExpression)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Mapper)
                {
                    pgdProp.selectedObject = new FPropMap(m_fOpmCore, pgdProp, (FMapper)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Storage)
                {
                    pgdProp.selectedObject = new FPropStg(m_fOpmCore, pgdProp, (FStorage)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Callback)
                {
                    pgdProp.selectedObject = new FPropCbk(m_fOpmCore, pgdProp, (FCallback)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Function)
                {
                    pgdProp.selectedObject = new FPropFun(m_fOpmCore, pgdProp, (FFunction)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Branch)
                {
                    pgdProp.selectedObject = new FPropBrn(m_fOpmCore, pgdProp, (FBranch)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Comment)
                {
                    pgdProp.selectedObject = new FPropCmt(m_fOpmCore, pgdProp, (FComment)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Pauser)
                {
                    pgdProp.selectedObject = new FPropPau(m_fOpmCore, pgdProp, (FPauser)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.EntryPoint)
                {
                    pgdProp.selectedObject = new FPropEtp(m_fOpmCore, pgdProp, (FEntryPoint)fObject);
                }
                // --
                m_fActiveObject = fObject;

                // --

                controlMenuOfScenario();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                    if (mnuMenu.Tools[FMenuKey.MenuEqmRemove].SharedProps.Enabled == true)
                    {
                        if (
                            m_fActiveObject.fObjectType == FObjectType.OpcDriver ||
                            m_fActiveObject.fObjectType == FObjectType.Equipment ||
                            m_fActiveObject.fObjectType == FObjectType.ScenarioGroup ||
                            m_fActiveObject.fObjectType == FObjectType.Scenario
                            )
                        {
                            procMenuRemoveObject();
                        }
                        else if (
                            m_fActiveObject.fObjectType == FObjectType.OpcTrigger ||
                            m_fActiveObject.fObjectType == FObjectType.OpcTransmitter ||
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
                }
                else if (e.Control && e.KeyCode == Keys.X)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEqmCut].SharedProps.Enabled == true)
                    {
                        procMenuCut();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.C)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEqmCopy].SharedProps.Enabled == true)
                    {
                        procMenuCopy();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEqmPasteSibling].SharedProps.Enabled == true)
                    {
                        if (
                            m_fActiveObject.fObjectType == FObjectType.OpcTrigger ||
                            m_fActiveObject.fObjectType == FObjectType.OpcTransmitter ||
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
                    if (mnuMenu.Tools[FMenuKey.MenuEqmPasteChild].SharedProps.Enabled == true)
                    {
                        procMenuPasteChildOfChildFlow();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.U)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEqmMoveUp].SharedProps.Enabled == true)
                    {
                        procMenuMoveUpFlow();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.D)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEqmMoveDown].SharedProps.Enabled == true)
                    {
                        procMenuMoveDownFlow();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.E)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEqmExpand].SharedProps.Enabled == true)
                    {
                        procMenuExpand();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.L)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEqmCollapse].SharedProps.Enabled == true)
                    {
                        procMenuCollapse();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.R)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEqmRelation].SharedProps.Enabled == true)
                    {
                        procMenuRelation();
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                if (fObject.fObjectType == FObjectType.OpcTrigger)
                {
                    pgdProp.selectedObject = new FPropOtr(m_fOpmCore, pgdProp, (FOpcTrigger)fObject);
                }
                else if (fObject.fObjectType == FObjectType.OpcCondition)
                {
                    pgdProp.selectedObject = new FPropOcn(m_fOpmCore, pgdProp, (FOpcCondition)fObject);
                }
                else if (fObject.fObjectType == FObjectType.OpcExpression)
                {
                    pgdProp.selectedObject = new FPropOep(m_fOpmCore, pgdProp, (FOpcExpression)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.OpcTransmitter)
                {
                    pgdProp.selectedObject = new FPropOtn(m_fOpmCore, pgdProp, (FOpcTransmitter)fObject);
                }
                else if (fObject.fObjectType == FObjectType.OpcTransfer)
                {
                    pgdProp.selectedObject = new FPropOtf(m_fOpmCore, pgdProp, (FOpcTransfer)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostTrigger)
                {
                    pgdProp.selectedObject = new FPropHtr(m_fOpmCore, pgdProp, (FHostTrigger)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostCondition)
                {
                    pgdProp.selectedObject = new FPropHcn(m_fOpmCore, pgdProp, (FHostCondition)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostExpression)
                {
                    pgdProp.selectedObject = new FPropHep(m_fOpmCore, pgdProp, (FHostExpression)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.OpcTransmitter)
                {
                    pgdProp.selectedObject = new FPropOtn(m_fOpmCore, pgdProp, (FOpcTransmitter)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostTransmitter)
                {
                    pgdProp.selectedObject = new FPropHtn(m_fOpmCore, pgdProp, (FHostTransmitter)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostTransfer)
                {
                    pgdProp.selectedObject = new FPropHtf(m_fOpmCore, pgdProp, (FHostTransfer)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    pgdProp.selectedObject = new FPropEsa(m_fOpmCore, pgdProp, (FEquipmentStateSetAlterer)fObject);
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateAlterer)
                {
                    pgdProp.selectedObject = new FPropEat(m_fOpmCore, pgdProp, (FEquipmentStateAlterer)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Judgement)
                {
                    pgdProp.selectedObject = new FPropJdm(m_fOpmCore, pgdProp, (FJudgement)fObject);
                }
                else if (fObject.fObjectType == FObjectType.JudgementCondition)
                {
                    pgdProp.selectedObject = new FPropJcn(m_fOpmCore, pgdProp, (FJudgementCondition)fObject);
                }
                else if (fObject.fObjectType == FObjectType.JudgementExpression)
                {
                    pgdProp.selectedObject = new FPropJep(m_fOpmCore, pgdProp, (FJudgementExpression)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Mapper)
                {
                    pgdProp.selectedObject = new FPropMap(m_fOpmCore, pgdProp, (FMapper)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Storage)
                {
                    pgdProp.selectedObject = new FPropStg(m_fOpmCore, pgdProp, (FStorage)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Callback)
                {
                    pgdProp.selectedObject = new FPropCbk(m_fOpmCore, pgdProp, (FCallback)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Function)
                {
                    pgdProp.selectedObject = new FPropFun(m_fOpmCore, pgdProp, (FFunction)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Branch)
                {
                    pgdProp.selectedObject = new FPropBrn(m_fOpmCore, pgdProp, (FBranch)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Comment)
                {
                    pgdProp.selectedObject = new FPropCmt(m_fOpmCore, pgdProp, (FComment)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.Pauser)
                {
                    pgdProp.selectedObject = new FPropPau(m_fOpmCore, pgdProp, (FPauser)fObject);
                }
                // --
                else if (fObject.fObjectType == FObjectType.EntryPoint)
                {
                    pgdProp.selectedObject = new FPropEtp(m_fOpmCore, pgdProp, (FEntryPoint)fObject);
                }
                // --
                m_fActiveObject = fObject;

                // --

                controlMenuOfScenario();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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

                    if (fRefObject.fObjectType == FObjectType.OpcTrigger)
                    {
                        #region OpcTrigger

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcCondition)
                        {
                            #region OpcCondition

                            if (((FOpcTrigger)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FOpcTrigger)fRefObject).containsObject(fDragDropData.fObject))
                                {
                                    cnt = ((FOpcTrigger)fRefObject).fChildOpcConditionCollection.count;
                                    fRefObject = ((FOpcTrigger)fRefObject).fChildOpcConditionCollection[cnt - 1];
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcDevice)
                        {
                            #region OpcDevice

                            if (((FOpcTrigger)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessage)
                        {
                            #region OpcMessage

                            if (((FOpcTrigger)fRefObject).equalsModelingFile(fDragDropData.fObject))
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
                    else if (fRefObject.fObjectType == FObjectType.OpcCondition)
                    {
                        #region OpcCondition

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcCondition)
                        {
                            #region OpcCondition

                            if (((FOpcCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FOpcCondition)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FOpcCondition)fRefObject).fNextSibling == null || !((FOpcCondition)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcExpression)
                        {
                            #region OpcExpression

                            if (((FOpcCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FOpcCondition)fRefObject).containsObject(fDragDropData.fObject))
                                {
                                    cnt = ((FOpcCondition)fRefObject).fChildOpcExpressionCollection.count;
                                    fRefObject = ((FOpcCondition)fRefObject).fChildOpcExpressionCollection[cnt - 1];
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcDevice)
                        {
                            #region OpcDevice

                            if (((FOpcCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (!((FOpcCondition)fRefObject).hasChild)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessage)
                        {
                            #region OpcMessage

                            if (((FOpcCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (fDragDropData.sessionUniqueId != string.Empty)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }    
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcEventItem)
                        {
                            #region OpcEventItem

                            if (((FOpcCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FOpcCondition)fRefObject).hasMessage && 
                                    ((FOpcCondition)fRefObject).fMessage.Equals(((FOpcEventItem)fDragDropData.fObject).fAncestorOpcMessage)
                                    )
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcItem)
                        {
                            #region OpcItem

                            if (((FOpcCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FOpcCondition)fRefObject).hasMessage &&
                                    ((FOpcCondition)fRefObject).fMessage.Equals(((FOpcItem)fDragDropData.fObject).fAncestorOpcMessage)
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

                            if (((FOpcCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FOpcCondition)fRefObject).hasMessage)
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

                            if (((FOpcCondition)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FOpcCondition)fRefObject).hasMessage)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }                                
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcExpression)
                    {
                        #region OpcExpression

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcExpression)
                        {
                            #region OpcExpression

                            if (((FOpcExpression)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FOpcExpression)fRefObject).fAncestorOpcCondition.containsObject(fDragDropData.fObject) &&
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    !((FOpcExpression)fDragDropData.fObject).containsObject(fRefObject) &&
                                    (((FOpcExpression)fRefObject).fNextSibling == null || !((FOpcExpression)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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

                            if (((FOpcExpression)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FOpcExpression)fRefObject).hasOperand && ((FOpcExpression)fRefObject).fOperandType == FOpcOperandType.OpcItem)
                                {
                                    fFormat = ((FOpcExpression)fRefObject).fOperandFormat;
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcEventItem)
                        {
                            #region OpcEventItem

                            if (((FOpcExpression)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FOpcExpression)fRefObject).fAncestorOpcCondition.hasMessage &&
                                    ((FOpcExpression)fRefObject).fAncestorOpcCondition.fMessage.Equals(((FOpcEventItem)fDragDropData.fObject).fAncestorOpcMessage)
                                    )
                                {
                                    if (
                                        ((FOpcExpression)fRefObject).fExpressionType != FExpressionType.Bracket ||
                                        !((FOpcExpression)fRefObject).hasChild
                                        )
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                                
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcItem)
                        {
                            #region OpcItem

                            if (((FOpcExpression)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FOpcExpression)fRefObject).fAncestorOpcCondition.hasMessage &&
                                    ((FOpcExpression)fRefObject).fAncestorOpcCondition.fMessage.Equals(((FOpcItem)fDragDropData.fObject).fAncestorOpcMessage)
                                    )
                                {
                                    if (
                                        ((FOpcExpression)fRefObject).fExpressionType != FExpressionType.Bracket ||
                                        !((FOpcExpression)fRefObject).hasChild
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

                            if (((FOpcExpression)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FOpcExpression)fRefObject).fAncestorOpcCondition.hasMessage)
                                {
                                    if (
                                        ((FOpcExpression)fRefObject).fExpressionType != FExpressionType.Bracket ||
                                        !((FOpcExpression)fRefObject).hasChild
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

                            if (((FOpcExpression)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FOpcExpression)fRefObject).fAncestorOpcCondition.hasMessage)
                                {
                                    if (
                                        ((FOpcExpression)fRefObject).fExpressionType != FExpressionType.Bracket ||
                                        !((FOpcExpression)fRefObject).hasChild
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
                    else if (fRefObject.fObjectType == FObjectType.OpcTransmitter)
                    {
                        #region OpcTransmitter

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcTransfer)
                        {
                            #region OpcTransfer

                            if (((FOpcTransmitter)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FOpcTransmitter)fRefObject).containsObject(fDragDropData.fObject))
                                {
                                    cnt = ((FOpcTransmitter)fRefObject).fChildOpcTransferCollection.count;
                                    fRefObject = ((FOpcTransmitter)fRefObject).fChildOpcTransferCollection[cnt - 1];
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessage)
                        {
                            #region OpcMessage

                            if (((FOpcTransmitter)fRefObject).equalsModelingFile(fDragDropData.fObject))
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
                    else if (fRefObject.fObjectType == FObjectType.OpcTransfer)
                    {
                        #region OpcTransfer

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcTransfer)
                        {
                            #region OpcTransfer

                            if (((FOpcTransfer)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FOpcTransfer)fRefObject).fParent.containsObject(fDragDropData.fObject) &&
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FOpcTransfer)fRefObject).fNextSibling == null || !((FOpcTransfer)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessage)
                        {
                            #region OpcMessage

                            if (((FOpcTransfer)fRefObject).equalsModelingFile(fDragDropData.fObject))
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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

                    if (fRefObject.fObjectType == FObjectType.OpcTrigger)
                    {
                        #region OpcTrigger

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcCondition)
                        {
                            #region OpcCondition

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FOpcCondition)fDragDropData.fObject).moveTo((FOpcTrigger)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcCondition)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcTrigger)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcDevice)
                        {
                            #region OpcDevice

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fChildObject = ((FOpcTrigger)fRefObject).appendChildOpcCondition(new FOpcCondition(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                                ((FOpcCondition)fChildObject).fConditionMode = FOpcConditionMode.Connection;
                                ((FOpcCondition)fChildObject).setDevice((FOpcDevice)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessage)
                        {
                            #region OpcMessage

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fSession = this.m_fOpmCore.fOpmFileInfo.fOpcDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FOpcSession)fSession).fParent;
                                // --
                                fChildObject = ((FOpcTrigger)fRefObject).appendChildOpcCondition(new FOpcCondition(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                                ((FOpcCondition)fChildObject).fConditionMode = FOpcConditionMode.Expression;
                                ((FOpcCondition)fChildObject).setMessage((FOpcDevice)fDevice, (FOpcSession)fSession, (FOpcMessage)fDragDropData.fObject);
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
                    else if (fRefObject.fObjectType == FObjectType.OpcCondition)
                    {
                        #region OpcCondition

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcCondition)
                        {
                            #region OpcCondition

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FOpcCondition)fDragDropData.fObject).moveTo((FOpcCondition)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcCondition)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcCondition)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcExpression)
                        {
                            #region OpcExpression

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FOpcExpression)fDragDropData.fObject).moveTo((FOpcCondition)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcExpression)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcCondition)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcDevice)
                        {
                            #region OpcDevice

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcCondition)fRefObject).fConditionMode = FOpcConditionMode.Connection;
                                ((FOpcCondition)fRefObject).setDevice((FOpcDevice)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessage)
                        {
                            #region OpcMessage

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fSession = this.m_fOpmCore.fOpmFileInfo.fOpcDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FOpcSession)fSession).fParent;
                                // --
                                ((FOpcCondition)fRefObject).fConditionMode = FOpcConditionMode.Expression;
                                ((FOpcCondition)fRefObject).setMessage((FOpcDevice)fDevice, (FOpcSession)fSession, (FOpcMessage)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcEventItem)
                        {
                            #region OpcEventItem

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fChildObject = ((FOpcCondition)fRefObject).appendChildOpcExpression(new FOpcExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                                ((FOpcExpression)fChildObject).fOperandType = FOpcOperandType.OpcEventItem;
                                ((FOpcExpression)fChildObject).setOperand((FIOpcOperand)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcItem)
                        {
                            #region OpcItem

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fChildObject = ((FOpcCondition)fRefObject).appendChildOpcExpression(new FOpcExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                                ((FOpcExpression)fChildObject).fOperandType = FOpcOperandType.OpcItem;
                                ((FOpcExpression)fChildObject).setOperand((FIOpcOperand)fDragDropData.fObject);
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
                                fChildObject = ((FOpcCondition)fRefObject).appendChildOpcExpression(new FOpcExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                                ((FOpcExpression)fChildObject).fOperandType = FOpcOperandType.EquipmentState;
                                ((FOpcExpression)fChildObject).setOperand((FIOpcOperand)fDragDropData.fObject);
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
                                fChildObject = ((FOpcCondition)fRefObject).appendChildOpcExpression(new FOpcExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                                fFormat = ((FEnvironment)fDragDropData.fObject).fFormat;
                                if (
                                    fFormat == FFormat.List ||
                                    fFormat == FFormat.AsciiList ||
                                    fFormat == FFormat.Raw ||
                                    fFormat == FFormat.Unknown
                                    )
                                {
                                    ((FOpcExpression)fChildObject).fComparisonMode = FComparisonMode.Length;
                                }
                                else
                                {
                                    ((FOpcExpression)fChildObject).fComparisonMode = FComparisonMode.Value;
                                }
                                ((FOpcExpression)fChildObject).fOperandType = FOpcOperandType.Environment;
                                ((FOpcExpression)fChildObject).setOperand((FIOpcOperand)fDragDropData.fObject);
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
                    else if (fRefObject.fObjectType == FObjectType.OpcExpression)
                    {
                        #region OpcExpression

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcExpression)
                        {
                            #region OpcExpression

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FOpcExpression)fDragDropData.fObject).moveTo((FOpcExpression)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcExpression)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcExpression)fRefObject).pasteSibling();
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
                                ((FOpcExpression)fRefObject).setDataConversionSet((FDataConversionSet)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcEventItem)
                        {
                            #region OpcEventItem

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcExpression)fRefObject).fExpressionType = FExpressionType.Comparison;                                
                                ((FOpcExpression)fRefObject).fOperandType = FOpcOperandType.OpcEventItem;
                                ((FOpcExpression)fRefObject).setOperand((FIOpcOperand)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcItem)
                        {
                            #region OpcItem

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcExpression)fRefObject).fExpressionType = FExpressionType.Comparison;
                                ((FOpcExpression)fRefObject).fOperandType = FOpcOperandType.OpcItem;
                                ((FOpcExpression)fRefObject).setOperand((FIOpcOperand)fDragDropData.fObject);                                
                                fAction = FDragDropAction.Set;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentState)
                        {
                            #region EquipmentState

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcExpression)fRefObject).fExpressionType = FExpressionType.Comparison;
                                ((FOpcExpression)fRefObject).fOperandType = FOpcOperandType.EquipmentState;
                                ((FOpcExpression)fRefObject).setOperand((FIOpcOperand)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Environment)
                        {
                            #region Environment

                            ((FOpcExpression)fRefObject).fExpressionType = FExpressionType.Comparison;
                            fFormat = ((FEnvironment)fDragDropData.fObject).fFormat;
                            if (
                                fFormat == FFormat.List ||
                                fFormat == FFormat.AsciiList ||
                                fFormat == FFormat.Raw ||
                                fFormat == FFormat.Unknown
                                )
                            {
                                ((FOpcExpression)fRefObject).fComparisonMode = FComparisonMode.Length;
                            }
                            else
                            {
                                ((FOpcExpression)fRefObject).fComparisonMode = FComparisonMode.Value;
                            }
                            ((FOpcExpression)fRefObject).fOperandType = FOpcOperandType.Environment;
                            ((FOpcExpression)fRefObject).setOperand((FIOpcOperand)fDragDropData.fObject);
                            fAction = FDragDropAction.Set;

                            #endregion
                        }
                        else
                        {
                            return;
                        }

                        #endregion
                    }
                    else if (fRefObject.fObjectType == FObjectType.OpcTransmitter)
                    {
                        #region OpcTransmitter

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcTransfer)
                        {
                            #region OpcTransfer

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FOpcTransfer)fDragDropData.fObject).moveTo((FOpcTransmitter)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcTransfer)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcTransmitter)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessage)
                        {
                            #region OpcMessage

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fSession = this.m_fOpmCore.fOpmFileInfo.fOpcDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FOpcSession)fSession).fParent;
                                // --
                                fChildObject = ((FOpcTransmitter)fRefObject).appendChildOpcTransfer(new FOpcTransfer(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));                                
                                ((FOpcTransfer)fChildObject).setMessage((FOpcDevice)fDevice, (FOpcSession)fSession, (FOpcMessage)fDragDropData.fObject);
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
                    else if (fRefObject.fObjectType == FObjectType.OpcTransfer)
                    {
                        #region OpcTransfer

                        if (fDragDropData.fObject.fObjectType == FObjectType.OpcTransfer)
                        {
                            #region OpcTransfer

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FOpcTransfer)fDragDropData.fObject).moveTo((FOpcTransfer)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FOpcTransfer)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcTransfer)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcMessage)
                        {
                            #region OpcMessage

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fSession = this.m_fOpmCore.fOpmFileInfo.fOpcDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FOpcSession)fSession).fParent;
                                // --                                
                                ((FOpcTransfer)fRefObject).setMessage((FOpcDevice)fDevice, (FOpcSession)fSession, (FOpcMessage)fDragDropData.fObject);
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
                                fChildObject = ((FHostTrigger)fRefObject).appendChildHostCondition(new FHostCondition(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
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
                                fSession = this.m_fOpmCore.fOpmFileInfo.fOpcDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FHostSession)fSession).fParent;
                                // --
                                fChildObject = ((FHostTrigger)fRefObject).appendChildHostCondition(new FHostCondition(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
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
                                fSession = this.m_fOpmCore.fOpmFileInfo.fOpcDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
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
                                fChildObject = ((FHostCondition)fRefObject).appendChildHostExpression(new FHostExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
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
                                fChildObject = ((FHostCondition)fRefObject).appendChildHostExpression(new FHostExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
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
                                fChildObject = ((FHostCondition)fRefObject).appendChildHostExpression(new FHostExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
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
                                fSession = this.m_fOpmCore.fOpmFileInfo.fOpcDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
                                fDevice = ((FHostSession)fSession).fParent;
                                // --
                                fChildObject = ((FHostTransmitter)fRefObject).appendChildHostTransfer(new FHostTransfer(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
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
                                fSession = this.m_fOpmCore.fOpmFileInfo.fOpcDriver.selectSingleObjectByUniqueId(UInt64.Parse(fDragDropData.sessionUniqueId));
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
                                fChildObject = ((FEquipmentStateSetAlterer)fRefObject).appendChildEquipmentStateAlterer(new FEquipmentStateAlterer(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
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
                                fChildObject = ((FJudgement)fRefObject).appendChildJudgementCondition(new FJudgementCondition(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
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
                                fChildObject = ((FJudgementCondition)fRefObject).appendChildJudgementExpression(new FJudgementExpression(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
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
                                fChildObject = ((FCallback)fRefObject).appendChildFunction(new FFunction(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
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
                        fDragDropData.fObject.fObjectType == FObjectType.OpcExpression ||
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
                        (fRefObject.fObjectType == FObjectType.OpcCondition && fDragDropData.fObject.fObjectType == FObjectType.OpcDevice) ||
                        (fRefObject.fObjectType == FObjectType.OpcCondition && fDragDropData.fObject.fObjectType == FObjectType.OpcMessage) ||
                        fRefObject.fObjectType == FObjectType.OpcExpression ||
                        fRefObject.fObjectType == FObjectType.OpcTransfer ||
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
                        fRefObject.fObjectType == FObjectType.OpcTrigger ||                        
                        (fRefObject.fObjectType == FObjectType.OpcCondition && fDragDropData.fObject.fObjectType == FObjectType.OpcEventItem) ||
                        (fRefObject.fObjectType == FObjectType.OpcCondition && fDragDropData.fObject.fObjectType == FObjectType.OpcItem) ||
                        (fRefObject.fObjectType == FObjectType.OpcCondition && fDragDropData.fObject.fObjectType == FObjectType.EquipmentState) ||
                        (fRefObject.fObjectType == FObjectType.OpcCondition && fDragDropData.fObject.fObjectType == FObjectType.Environment) || 
                        fRefObject.fObjectType == FObjectType.OpcTransmitter ||
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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

        #region rstSnrToolbar Control Event Handler

        private void rstSnrToolbar_SearchRequested(
            object sender, 
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                procMenuSearch(e.searchWord);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region pgdProp Control Event handler

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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
