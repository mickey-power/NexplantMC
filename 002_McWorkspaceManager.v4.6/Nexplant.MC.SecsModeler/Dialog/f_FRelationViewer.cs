/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FRelationViewer.cs
--  Creator         : spike.lee (이건 내가 한게 아닌데 왜 내 이름이 봍이 있을까요?)
--  Create Date     : 2012.02.07
--  Description     : FAMate SECS Modeler Relation Viewer Form Class 
--  History         : Created by spike.lee at 2012.02.07
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win;

namespace Nexplant.MC.SecsModeler
{
    public partial class FRelationViewer : Nexplant.MC.Core.FaUIs.FBaseStandardForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private FIObject m_fSelectObject = null;

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2012.11.23 by spike.lee
        // region 붙이는게 어렵나요? 왜 이건 빼먹었습니까?
        // ***
        #region Class Construction and Destruction

        public FRelationViewer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FRelationViewer(
            FSsmCore fSsmCore
            )
            : this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;
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

        private void designTreeOfRelationViewer(
            )
        {
            try
            {
                tvwTree.ImageList = new ImageList();
                // --
                tvwTree.ImageList.Images.Add("Relation_Reference", Properties.Resources.Relation_Reference);
                tvwTree.ImageList.Images.Add("Relation_Inclusion", Properties.Resources.Relation_Inclusion);
                // --
                tvwTree.ImageList.Images.Add("SecsDriver", Properties.Resources.SecsDriver);
                // --
                tvwTree.ImageList.Images.Add("ObjectNameList", Properties.Resources.SmdObjectNameList);
                tvwTree.ImageList.Images.Add("ObjectName", Properties.Resources.SmdObjectName);
                tvwTree.ImageList.Images.Add("FunctionNameList", Properties.Resources.SmdFunctionNameList);
                tvwTree.ImageList.Images.Add("FunctionName", Properties.Resources.SmdFunctionName);
                tvwTree.ImageList.Images.Add("ParameterName", Properties.Resources.SmdParameterName);
                tvwTree.ImageList.Images.Add("Argument", Properties.Resources.SmdArgument);
                tvwTree.ImageList.Images.Add("DataConversionSetList_unlock", Properties.Resources.DataConversionSetList_unlock);
                tvwTree.ImageList.Images.Add("DataConversionSetList_lock", Properties.Resources.DataConversionSetList_lock);
                tvwTree.ImageList.Images.Add("DataConversionSet_unlock", Properties.Resources.DataConversionSet_unlock);
                tvwTree.ImageList.Images.Add("DataConversionSet_lock", Properties.Resources.DataConversionSet_lock);
                tvwTree.ImageList.Images.Add("DataConversion", Properties.Resources.DataConversion);
                tvwTree.ImageList.Images.Add("EquipmentStateSetList_unlock", Properties.Resources.EquipmentStateSetList_unlock);
                tvwTree.ImageList.Images.Add("EquipmentStateSetList_lock", Properties.Resources.EquipmentStateSetList_lock);
                tvwTree.ImageList.Images.Add("EquipmentStateSet_unlock", Properties.Resources.EquipmentStateSet_unlock);
                tvwTree.ImageList.Images.Add("EquipmentStateSet_lock", Properties.Resources.EquipmentStateSet_lock);
                tvwTree.ImageList.Images.Add("EquipmentState_unlock", Properties.Resources.EquipmentState_unlock);
                tvwTree.ImageList.Images.Add("EquipmentState_lock", Properties.Resources.EquipmentState_lock);
                tvwTree.ImageList.Images.Add("StateValue", Properties.Resources.StateValue);
                tvwTree.ImageList.Images.Add("RepositoryList_unlock", Properties.Resources.RepositoryList_unlock);
                tvwTree.ImageList.Images.Add("RepositoryList_lock", Properties.Resources.RepositoryList_lock);
                tvwTree.ImageList.Images.Add("Repository_unlock", Properties.Resources.Repository_unlock);
                tvwTree.ImageList.Images.Add("Repository_lock", Properties.Resources.Repository_lock);
                tvwTree.ImageList.Images.Add("Column_List", Properties.Resources.Column_List);
                tvwTree.ImageList.Images.Add("Column", Properties.Resources.Column);
                tvwTree.ImageList.Images.Add("EnvironmentList_unlock", Properties.Resources.EnvironmentList_unlock);
                tvwTree.ImageList.Images.Add("EnvironmentList_lock", Properties.Resources.EnvironmentList_lock);
                tvwTree.ImageList.Images.Add("Environment_List_unlock", Properties.Resources.Environment_List_unlock);
                tvwTree.ImageList.Images.Add("Environment_List_lock", Properties.Resources.Environment_List_lock);
                tvwTree.ImageList.Images.Add("Environment_unlock", Properties.Resources.Environment_unlock);
                tvwTree.ImageList.Images.Add("Environment_lock", Properties.Resources.Environment_lock);
                tvwTree.ImageList.Images.Add("DataSetList_unlock", Properties.Resources.DataSetList_unlock);
                tvwTree.ImageList.Images.Add("DataSetList_lock", Properties.Resources.DataSetList_lock);
                tvwTree.ImageList.Images.Add("DataSet_unlock", Properties.Resources.DataSet_unlock);
                tvwTree.ImageList.Images.Add("DataSet_lock", Properties.Resources.DataSet_lock);
                tvwTree.ImageList.Images.Add("Data_List_unlock", Properties.Resources.Data_List_unlock);
                tvwTree.ImageList.Images.Add("Data_List_lock", Properties.Resources.Data_List_lock);
                tvwTree.ImageList.Images.Add("Data_unlock", Properties.Resources.Data_unlock);
                tvwTree.ImageList.Images.Add("Data_lock", Properties.Resources.Data_lock);
                // --
                tvwTree.ImageList.Images.Add("HostDevice", Properties.Resources.HostDevice);
                tvwTree.ImageList.Images.Add("HostDevice_Closed_unlock", Properties.Resources.HostDevice_Closed_unlock);
                tvwTree.ImageList.Images.Add("HostDevice_Closed_lock", Properties.Resources.HostDevice_Closed_lock);
                tvwTree.ImageList.Images.Add("HostDevice_Opened_unlock", Properties.Resources.HostDevice_Opened_unlock);
                tvwTree.ImageList.Images.Add("HostDevice_Opened_lock", Properties.Resources.HostDevice_Opened_lock);
                tvwTree.ImageList.Images.Add("HostDevice_Connected_unlock", Properties.Resources.HostDevice_Connected_unlock);
                tvwTree.ImageList.Images.Add("HostDevice_Connected_lock", Properties.Resources.HostDevice_Connected_lock);
                tvwTree.ImageList.Images.Add("HostDevice_Selected_unlock", Properties.Resources.HostDevice_Selected_unlock);
                tvwTree.ImageList.Images.Add("HostDevice_Selected_lock", Properties.Resources.HostDevice_Selected_lock);
                tvwTree.ImageList.Images.Add("HostSession_unlock", Properties.Resources.HostSession_unlock);
                tvwTree.ImageList.Images.Add("HostSession_lock", Properties.Resources.HostSession_lock);
                tvwTree.ImageList.Images.Add("HostMessageList_unlock", Properties.Resources.HostMessageList_unlock);
                tvwTree.ImageList.Images.Add("HostMessageList_lock", Properties.Resources.HostMessageList_lock);
                tvwTree.ImageList.Images.Add("HostMessages_Eq_unlock", Properties.Resources.HostMessages_Eq_unlock);
                tvwTree.ImageList.Images.Add("HostMessages_Eq_lock", Properties.Resources.HostMessages_Eq_lock);
                tvwTree.ImageList.Images.Add("HostMessages_Host_unlock", Properties.Resources.HostMessages_Host_unlock);
                tvwTree.ImageList.Images.Add("HostMessages_Host_lock", Properties.Resources.HostMessages_Host_lock);
                tvwTree.ImageList.Images.Add("HostMessages_Both_unlock", Properties.Resources.HostMessages_Both_unlock);
                tvwTree.ImageList.Images.Add("HostMessages_Both_lock", Properties.Resources.HostMessages_Both_lock);
                tvwTree.ImageList.Images.Add("HostMessage_Command_unlock", Properties.Resources.HostMessage_Command_unlock);
                tvwTree.ImageList.Images.Add("HostMessage_Command_lock", Properties.Resources.HostMessage_Command_lock);
                tvwTree.ImageList.Images.Add("HostMessage_Reply_unlock", Properties.Resources.HostMessage_Reply_unlock);
                tvwTree.ImageList.Images.Add("HostMessage_Reply_lock", Properties.Resources.HostMessage_Reply_lock);
                tvwTree.ImageList.Images.Add("HostMessage_Unsolicited_unlock", Properties.Resources.HostMessage_Unsolicited_unlock);
                tvwTree.ImageList.Images.Add("HostMessage_Unsolicited_lock", Properties.Resources.HostMessage_Unsolicited_lock);
                tvwTree.ImageList.Images.Add("HostItem_List_unlock", Properties.Resources.HostItem_List_unlock);
                tvwTree.ImageList.Images.Add("HostItem_List_lock", Properties.Resources.HostItem_List_lock);
                tvwTree.ImageList.Images.Add("HostItem_unlock", Properties.Resources.HostItem_unlock);
                tvwTree.ImageList.Images.Add("HostItem_lock", Properties.Resources.HostItem_lock);
                tvwTree.ImageList.Images.Add("HostLibraryGroup_unlock", Properties.Resources.HostLibraryGroup_unlock);
                tvwTree.ImageList.Images.Add("HostLibraryGroup_lock", Properties.Resources.HostLibraryGroup_lock);
                tvwTree.ImageList.Images.Add("HostLibrary_unlock", Properties.Resources.HostLibrary_unlock);
                tvwTree.ImageList.Images.Add("HostLibrary_lock", Properties.Resources.HostLibrary_lock);
                tvwTree.ImageList.Images.Add("SecsDevice", Properties.Resources.SecsDevice);
                tvwTree.ImageList.Images.Add("SecsDevice_Closed_unlock", Properties.Resources.SecsDevice_Closed_unlock);
                tvwTree.ImageList.Images.Add("SecsDevice_Closed_lock", Properties.Resources.SecsDevice_Closed_lock);
                tvwTree.ImageList.Images.Add("SecsDevice_Opened_unlock", Properties.Resources.SecsDevice_Opened_unlock);
                tvwTree.ImageList.Images.Add("SecsDevice_Opened_lock", Properties.Resources.SecsDevice_Opened_lock);
                tvwTree.ImageList.Images.Add("SecsDevice_Connected_unlock", Properties.Resources.SecsDevice_Connected_unlock);
                tvwTree.ImageList.Images.Add("SecsDevice_Connected_lock", Properties.Resources.SecsDevice_Connected_lock);
                tvwTree.ImageList.Images.Add("SecsDevice_Selected_unlock", Properties.Resources.SecsDevice_Selected_unlock);
                tvwTree.ImageList.Images.Add("SecsDevice_Selected_lock", Properties.Resources.SecsDevice_Selected_lock);
                tvwTree.ImageList.Images.Add("SecsSession_unlock", Properties.Resources.SecsSession_unlock);
                tvwTree.ImageList.Images.Add("SecsSession_lock", Properties.Resources.SecsSession_lock);
                tvwTree.ImageList.Images.Add("SecsMessageList_unlock", Properties.Resources.SecsMessageList_unlock);
                tvwTree.ImageList.Images.Add("SecsMessageList_lock", Properties.Resources.SecsMessageList_lock);
                tvwTree.ImageList.Images.Add("SecsMessages_Eq_unlock", Properties.Resources.SecsMessages_Eq_unlock);
                tvwTree.ImageList.Images.Add("SecsMessages_Eq_lock", Properties.Resources.SecsMessages_Eq_lock);
                tvwTree.ImageList.Images.Add("SecsMessages_Host_unlock", Properties.Resources.SecsMessages_Host_unlock);
                tvwTree.ImageList.Images.Add("SecsMessages_Host_lock", Properties.Resources.SecsMessages_Host_lock);
                tvwTree.ImageList.Images.Add("SecsMessages_Both_unlock", Properties.Resources.SecsMessages_Both_unlock);
                tvwTree.ImageList.Images.Add("SecsMessages_Both_lock", Properties.Resources.SecsMessages_Both_lock);
                tvwTree.ImageList.Images.Add("SecsMessage_Primary_unlock", Properties.Resources.SecsMessage_Primary_unlock);
                tvwTree.ImageList.Images.Add("SecsMessage_Primary_lock", Properties.Resources.SecsMessage_Primary_lock);
                tvwTree.ImageList.Images.Add("SecsMessage_Secondary_unlock", Properties.Resources.SecsMessage_Secondary_unlock);
                tvwTree.ImageList.Images.Add("SecsMessage_Secondary_lock", Properties.Resources.SecsMessage_Secondary_lock);
                tvwTree.ImageList.Images.Add("SecsItem_List_unlock", Properties.Resources.SecsItem_List_unlock);
                tvwTree.ImageList.Images.Add("SecsItem_List_lock", Properties.Resources.SecsItem_List_lock);
                tvwTree.ImageList.Images.Add("SecsItem_unlock", Properties.Resources.SecsItem_unlock);
                tvwTree.ImageList.Images.Add("SecsItem_lock", Properties.Resources.SecsItem_lock);
                tvwTree.ImageList.Images.Add("SecsLibraryGroup_unlock", Properties.Resources.SecsLibraryGroup_unlock);
                tvwTree.ImageList.Images.Add("SecsLibraryGroup_lock", Properties.Resources.SecsLibraryGroup_lock);
                tvwTree.ImageList.Images.Add("SecsLibrary_unlock", Properties.Resources.SecsLibrary_unlock);
                tvwTree.ImageList.Images.Add("SecsLibrary_lock", Properties.Resources.SecsLibrary_lock);
                tvwTree.ImageList.Images.Add("SecsTrigger", Properties.Resources.SecsTrigger);
                tvwTree.ImageList.Images.Add("SecsCondition_Expression", Properties.Resources.SecsCondition_Expression);
                tvwTree.ImageList.Images.Add("SecsCondition_Timeout", Properties.Resources.SecsCondition_Timeout);
                tvwTree.ImageList.Images.Add("SecsCondition_Connection_Closed", Properties.Resources.SecsCondition_Connection_Closed);
                tvwTree.ImageList.Images.Add("SecsCondition_Connection_Opened", Properties.Resources.SecsCondition_Connection_Opened);
                tvwTree.ImageList.Images.Add("SecsCondition_Connection_Connected", Properties.Resources.SecsCondition_Connection_Connected);
                tvwTree.ImageList.Images.Add("SecsCondition_Connection_Selected", Properties.Resources.SecsCondition_Connection_Selected);
                tvwTree.ImageList.Images.Add("SecsExpression_Bracket", Properties.Resources.SecsExpression_Bracket);
                tvwTree.ImageList.Images.Add("SecsExpression_Comparison_Length_Environment", Properties.Resources.SecsExpression_Comparison_Length_Environment);
                tvwTree.ImageList.Images.Add("SecsExpression_Comparison_Length_SecsItem", Properties.Resources.SecsExpression_Comparison_Length_SecsItem);
                tvwTree.ImageList.Images.Add("SecsExpression_Comparison_Value_Environment", Properties.Resources.SecsExpression_Comparison_Value_Environment);
                tvwTree.ImageList.Images.Add("SecsExpression_Comparison_Value_SecsItem", Properties.Resources.SecsExpression_Comparison_Value_SecsItem);
                tvwTree.ImageList.Images.Add("SecsTransmitter", Properties.Resources.SecsTransmitter);
                tvwTree.ImageList.Images.Add("SecsTransfer", Properties.Resources.SecsTransfer);
                tvwTree.ImageList.Images.Add("HostTrigger", Properties.Resources.HostTrigger);
                tvwTree.ImageList.Images.Add("HostCondition_Expression", Properties.Resources.HostCondition_Expression);
                tvwTree.ImageList.Images.Add("HostCondition_Timeout", Properties.Resources.HostCondition_Timeout);
                tvwTree.ImageList.Images.Add("HostCondition_Connection_Closed", Properties.Resources.HostCondition_Connection_Closed);
                tvwTree.ImageList.Images.Add("HostCondition_Connection_Opened", Properties.Resources.HostCondition_Connection_Opened);
                tvwTree.ImageList.Images.Add("HostCondition_Connection_Connected", Properties.Resources.HostCondition_Connection_Connected);
                tvwTree.ImageList.Images.Add("HostCondition_Connection_Selected", Properties.Resources.HostCondition_Connection_Selected);
                tvwTree.ImageList.Images.Add("HostExpression_Bracket", Properties.Resources.HostExpression_Bracket);
                tvwTree.ImageList.Images.Add("HostExpression_Comparison_Length_Environment", Properties.Resources.HostExpression_Comparison_Length_Environment);
                tvwTree.ImageList.Images.Add("HostExpression_Comparison_Length_HostItem", Properties.Resources.HostExpression_Comparison_Length_HostItem);
                tvwTree.ImageList.Images.Add("HostExpression_Comparison_Value_Environment", Properties.Resources.HostExpression_Comparison_Value_Environment);
                tvwTree.ImageList.Images.Add("HostExpression_Comparison_Value_HostItem", Properties.Resources.HostExpression_Comparison_Value_HostItem);
                tvwTree.ImageList.Images.Add("HostTransmitter", Properties.Resources.HostTransmitter);
                tvwTree.ImageList.Images.Add("HostTransfer", Properties.Resources.HostTransfer);
                tvwTree.ImageList.Images.Add("EquipmentStateSetAlterer", Properties.Resources.EquipmentStateSetAlterer);
                tvwTree.ImageList.Images.Add("EquipmentStateAlterer", Properties.Resources.EquipmentStateAlterer);
                tvwTree.ImageList.Images.Add("Judgement", Properties.Resources.Judgement);
                tvwTree.ImageList.Images.Add("JudgementCondition", Properties.Resources.JudgementCondition);
                tvwTree.ImageList.Images.Add("JudgementExpression_Bracket", Properties.Resources.JudgementExpression_Bracket);
                tvwTree.ImageList.Images.Add("JudgementExpression_Comparison_Length", Properties.Resources.JudgementExpression_Comparison_Length);
                tvwTree.ImageList.Images.Add("JudgementExpression_Comparison_Value", Properties.Resources.JudgementExpression_Comparison_Value);
                tvwTree.ImageList.Images.Add("Mapper", Properties.Resources.Mapper);
                tvwTree.ImageList.Images.Add("Storage", Properties.Resources.Storage);
                tvwTree.ImageList.Images.Add("Callback", Properties.Resources.Callback);
                tvwTree.ImageList.Images.Add("Function", Properties.Resources.Function);
                tvwTree.ImageList.Images.Add("Branch", Properties.Resources.Branch);
                tvwTree.ImageList.Images.Add("Pauser", Properties.Resources.Pauser);
                tvwTree.ImageList.Images.Add("Comment", Properties.Resources.Comment);
                tvwTree.ImageList.Images.Add("EntryPoint", Properties.Resources.EntryPoint);
                tvwTree.ImageList.Images.Add("Equipment_unlock", Properties.Resources.Equipment_unlock);
                tvwTree.ImageList.Images.Add("Equipment_lock", Properties.Resources.Equipment_lock);
                tvwTree.ImageList.Images.Add("ScenarioGroup_unlock", Properties.Resources.ScenarioGroup_unlock);
                tvwTree.ImageList.Images.Add("ScenarioGroup_lock", Properties.Resources.ScenarioGroup_lock);
                tvwTree.ImageList.Images.Add("Scenario_unlock", Properties.Resources.Scenario_unlock);
                tvwTree.ImageList.Images.Add("Scenario_lock", Properties.Resources.Scenario_lock);
                tvwTree.ImageList.Images.Add("DataSet_unlock", Properties.Resources.DataSet_unlock);
                tvwTree.ImageList.Images.Add("DataSet_lock", Properties.Resources.DataSet_lock);
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

        public void refresh(
            FIObject fObject
            )
        {
            UltraTreeNode tNode = null;
            UltraTreeNode refNode = null;
            UltraTreeNode incNode = null;
            Image icon = null;

            try
            {   
                tNode = new UltraTreeNode(fObject.name);
                tNode.Tag = fObject;
                m_fSelectObject = fObject;
                icon = FCommon.getImageOfObject(fObject, tvwTree);
                if( icon != null)
                {
                    tNode.Override.ImageSize = new Size(16, 16);
                    tNode.Override.NodeAppearance.Image = icon;
                }

                refNode = new UltraTreeNode("Reference");
                refNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Relation_Reference"];
                addReferenceNode(refNode, fObject);
                refNode.Expanded = true;
                // --
                
                incNode = new UltraTreeNode("Inclusion");
                incNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Relation_Inclusion"];
                addInclusionNode(incNode, fObject);
                incNode.Expanded = true;
                
                // --
                
                tNode.Text = fObject.ToString(FStringOption.Detail);
                tNode.Nodes.Add(refNode);
                tNode.Nodes.Add(incNode);
                tNode.Expanded = true;

                // --

                tvwTree.beginUpdate();
                // --
                tvwTree.Nodes.Clear();                
                tvwTree.Nodes.Add(tNode);                
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

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void addReferenceNode(
            UltraTreeNode tNode,
            FIObject fObject
            )
        {
            UltraTreeNode tChildNode = null;            
            Image icon = null;            

            try
            {
                if (fObject.fReferenceObjectCollection != null)
                {
                    foreach (FIObject fChild in fObject.fReferenceObjectCollection)
                    {
                        tChildNode = new UltraTreeNode(fChild.name);
                        tChildNode.Tag = fChild;
                        
                        if (fChild.fReferenceObjectCollection != null && fChild.fReferenceObjectCollection.count > 0)
                        {
                            if (m_fSelectObject.fObjectType == FObjectType.Scenario)
                            {
                                if (fChild.name != m_fSelectObject.name)
                                {
                                    addReferenceNode(tChildNode, fChild);
                                }
                                
                            }
                            else
                            {
                                if (fChild.fObjectType != FObjectType.Scenario)
                                {
                                    addReferenceNode(tChildNode, fChild);
                                }
                            }
                        }

                        // --

                        icon = FCommon.getImageOfObject(fChild, tvwTree);
                        if (icon != null)
                        {
                            tChildNode.Override.ImageSize = new Size(16, 16);
                            tChildNode.Override.NodeAppearance.Image = icon;
                        }

                        // --

                        tChildNode.Text = fChild.ToString(FStringOption.Detail);
                        tNode.Nodes.Add(tChildNode);
                        tNode.Expanded = true;
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

        public void addInclusionNode(
            UltraTreeNode tNode,
            FIObject fObject
            )
        {
            UltraTreeNode tChildNode = null;
            Image icon = null;
            UltraTreeNode tAncestorNode = null;
            FIObject fAncestorObject = null;

            try
            {
                if (fObject.fInclusionObjectCollection.count  > 0)
                {
                    foreach (FIObject fChild in fObject.fInclusionObjectCollection)
                    {
                        tChildNode = new UltraTreeNode(fChild.name);
                        tChildNode.Tag = fChild;
                        if (fChild.fInclusionObjectCollection != null)
                        {
                            addInclusionNode(tChildNode, fChild);
                        }                        

                        // --

                        icon = FCommon.getImageOfObject(fChild, tvwTree);
                        if (icon != null)
                        {
                            tChildNode.Override.ImageSize = new Size(16, 16);
                            tChildNode.Override.NodeAppearance.Image = icon;
                        }

                        // --    
           
                        tChildNode.Text = fChild.ToString(FStringOption.Detail);
                        tNode.Nodes.Add(tChildNode);
                        tNode.Expanded = true;
                    }
                }
                else if (m_fSelectObject.fObjectType == FObjectType.SecsExpression)
                {
                    fAncestorObject = ((FSecsItem)fObject).fAncestorSecsMessage;                   
                }
                else if (m_fSelectObject.fObjectType == FObjectType.HostExpression)
                {
                    if(fObject.fObjectType == FObjectType.HostItem)
                    {
                        fAncestorObject = ((FHostItem)fObject).fAncestorHostMessage;                   
                    }
                }
                else if (m_fSelectObject.fObjectType == FObjectType.JudgementExpression)
                {
                    fAncestorObject = ((FData)fObject).fAncestorDataSet;
                }
                // --
                if (fAncestorObject != null)
                {
                    tAncestorNode = new UltraTreeNode(fAncestorObject.name);
                    tAncestorNode.Tag = fAncestorObject;
                    // --
                    tAncestorNode.Override.ImageSize = new Size(16, 16);
                    tAncestorNode.Override.NodeAppearance.Image = FCommon.getImageOfObject(fAncestorObject, tvwTree);
                    tAncestorNode.Text = fAncestorObject.ToString(FStringOption.Detail);
                    tNode.Nodes.Add(tAncestorNode);
                    tNode.Expanded = true;
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

        public void procMenuGoto(
            )
        {
            UltraTreeNode fSelectedNode = null;
            FIObject fObject = null;            

            try
            {
                if (tvwTree.Nodes.Count > 0)
                {
                    fSelectedNode = tvwTree.ActiveNode;
                    fObject = (FIObject)fSelectedNode.Tag;
                    if (fObject != null)
                    {
                        m_fSsmCore.fSsmContainer.gotoRelation(fObject);
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

        public void procMenuRefresh(
            )
        {
            try
            {
                FCursor.waitCursor();
                
                // --

                if (m_fSelectObject != null)
                {
                    refresh(m_fSelectObject);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FRelationViewer Form Event Handler

        private void FRelationViewer_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();
                // --
                designTreeOfRelationViewer();
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

        private void FRelationViewer_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
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

        #region tvwTree Control Event Handler

        private void tvwTree_DoubleClick(
            object sender, 
            EventArgs e
            )
        {
            try
            {                
                procMenuGoto();
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

        #region  mnuMenu Control Event Handler

        private void mnuMenu_ToolClick(
            object sender, 
            Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuRelGoto)
                {
                    procMenuGoto();
                }
                else if (e.Tool.Key == FMenuKey.MenuRefresh)
                {
                    procMenuRefresh();
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

    }   // Class end
}   // Namespace end
