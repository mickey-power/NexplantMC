/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEapStart.cs
--  Creator         : mjkim
--  Create Date     : 2012.05.04
--  Description     : FAMate Admin Manager Transaction - EAP Start Form Class 
--  History         : Created by mjkim at 2012.05.04
                      Modified by spike.lee at 2012.06.01
                        - 기능 구현
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
// --
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
// --
using Nexplant.MC.Core.FaSecsDriver;

namespace Nexplant.MC.SecsModeler
{
    public partial class FDataSetValidation : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm, FITransaction
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private bool m_tranEnabled = false;
        private bool m_cancel = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDataSetValidation(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataSetValidation(
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

        public bool cancel
        {
            get
            {
                try
                {
                    return m_cancel;
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

            set
            {
                try
                {
                    m_cancel = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void setTitle(
            )
        {
            try
            {
                this.Text = m_fSsmCore.fWsmCore.fUIWizard.searchCaption(this.Text);
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

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
                // --
                setTitle();
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

        private void designGridOfDataSet(
            )
        {
            UltraDataSource uds = null;            

            try
            {
                uds = grdList.dataSource;

                // --

                uds.Band.Columns.Add("DataSet");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Result");
                uds.Band.Columns.Add("Message");

                // --

                grdList.DisplayLayout.Bands[0].Columns["DataSet"].Width = 300;
                grdList.DisplayLayout.Bands[0].Columns["DataSet"].CellAppearance.Image = Properties.Resources.DataSet_unlock;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Result"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Message"].Width = 300;
                // --
                grdList.DisplayLayout.Bands[0].Columns["DataSet"].Header.Fixed = true;

                // --

                grdList.ImageList = new ImageList();
                // --
                grdList.ImageList.Images.Add("Transaction_Target", Properties.Resources.Trn_Target);
                grdList.ImageList.Images.Add("Transaction_Result_Success", Properties.Resources.Trn_Result_Success);
                grdList.ImageList.Images.Add("Transaction_Result_Fail", Properties.Resources.Trn_Result_Fail);
                grdList.ImageList.Images.Add("Transaction_Result_Cancel", Properties.Resources.Trn_Result_Cancel);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                uds = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------   

        private Image getImageOfDataSet(
            string result
            )
        {
            try
            {
                if (result == "Success")
                {
                    return grdList.ImageList.Images["Transaction_Result_Success"];
                }
                else if (result == "Fail")
                {
                    return grdList.ImageList.Images["Transaction_Result_Fail"];
                }
                else if (result == "Pass")
                {
                    return grdList.ImageList.Images["Transaction_Result_Cancel"];
                }
                else if (result == "Cancel")
                {
                    return grdList.ImageList.Images["Transaction_Result_Cancel"];
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return grdList.ImageList.Images["File_Log"];
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void attach(
            )
        {
            object[] cellValues = null;
            int index = 0;
            int key = 0;

            try
            {
                grdList.beginUpdate(false);

                // --

                foreach (FDataSetList dsl in m_fSsmCore.fSsmFileInfo.fSecsDriver.fChildDataSetListCollection)
                {
                    foreach (FDataSet ds in dsl.fChildDataSetCollection)
                    {
                        if (!ds.locked)
                        {
                            continue;
                        }

                        // --
                        cellValues = new object[] {
                            ds.name,
                            ds.description
                            };
                        index = grdList.appendOrUpdateDataRow((++key).ToString(), cellValues).Index;

                        // --
                        grdList.Rows[index].Cells["DataSet"].Appearance.Image = grdList.ImageList.Images["Transaction_Target"];
                        grdList.Rows[index].Tag = new FDataSetValidationSet(ds);

                        // --
                    }
                }

                // --

                grdList.endUpdate(false);

                // --

                if (grdList.activeDataRow == null)
                {
                    grdList.ActiveRow = grdList.Rows[0];
                }

                // --

                btnStart.Enabled = m_tranEnabled;

                // --

                grdList.Focus();
            }
            catch (Exception ex)
            {
                grdList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void action(
            )
        {
            // --
            FDataSetValidationSet fvs = null;
            FDataSet ds = null;
            FMapper fMapper = null;
            // --
            Dictionary<FFlowType, FIFlow> fRetFlowList = null;
            Dictionary<FFlowType, FIFlow> fRetNextFlowList = null;
            StringBuilder resultMsg = null;
            // --
            string eap = string.Empty;
            string result = string.Empty;
            string msg = string.Empty;
            Stopwatch sw = null;
            int sCnt = 0;
            int fCnt = 0;
            int cCnt = 0;

            try
            {
                btnStart.Enabled = false;
                m_cancel = false;
                sw = new Stopwatch();
                             
                // --
                resultMsg = new StringBuilder();
                foreach (UltraDataRow r in grdList.dataSource.Rows)
                {
                    sw.Reset();
                    sw.Start();
                    // --
                    Application.DoEvents();

                    // --

                    eap = grdList.getDataRowKey(r.Index);

                    // --

                    grdList.activateDataRow(eap);

                    // --
                    msg = string.Empty;
                    resultMsg.Clear();
                    result = "Success";

                    // --
                    if (m_cancel)
                    {
                        grdList.Rows[r.Index].Cells["DataSet"].Appearance.Image = getImageOfDataSet("Cancel");
                        result = this.fUIWizard.searchCaption("Cancel");
                        msg = this.fUIWizard.generateMessage("M0011");
                        cCnt++;
                    }
                    else
                    {
                        fvs = grdList.Rows[r.Index].Tag as FDataSetValidationSet;
                        // --
                        ds = fvs.fDataSet;

                        // --
                        
                        foreach (FIObject fChild in ds.fReferenceObjectCollection)
                        {
                            // --

                            if (fChild.fObjectType != FObjectType.Mapper)
                            {
                                continue;
                            }

                            // --
                            fMapper = fChild as FMapper;
                            // --

                            fRetFlowList = getPrevRefObject(fMapper);
                            fRetNextFlowList = getNextRefObject(fMapper);
                            // --

                            validationData(
                                ds.fChildDataCollection,
                                fRetFlowList,
                                fRetNextFlowList,
                                ref fvs
                                );

                            // --

                            if (fvs.resultMessage.Length > 0)
                            {
                                msg = fvs.resultMessage.ToString();
                                result = "Fail";
                                break;
                            }

                            // --
                        }

                        // --
                        if (result.Equals("Fail"))
                        {
                            fCnt++;
                        }
                        else
                        {
                            sCnt++;
                        }

                        // --
                    }

                    // --

                    sw.Stop();

                    // --
                    grdList.Rows[r.Index].Cells["DataSet"].Appearance.Image = getImageOfDataSet(result);

                    // --

                    r["Result"] = result;
                    r["Message"] = msg;                    
                }

                // --

                lblSuccess.Text = sCnt.ToString();
                lblFail.Text = fCnt.ToString();
                lblCancel.Text = cCnt.ToString();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                // --
                ds = null;
                fMapper = null;
                // --
                fRetFlowList = null;
                resultMsg = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void validationData(
            FDataCollection fDataCollection,
            Dictionary<FFlowType, FIFlow> prevFlowList,
            Dictionary<FFlowType, FIFlow> nextFlowList,
            ref FDataSetValidationSet resultSet
            )
        {
            // --
            FSecsTrigger fSecsTrigger = null;
            FHostTrigger fHostTrigger = null;
            // --
            FSecsTransmitter fSecsTransmitter = null;
            FHostTransmitter fHostTransmitter = null;

            try
            {
                // --

                foreach (FData fData in fDataCollection)
                {
                    if (fData.fFormat == FFormat.List)
                    {
                        validationData(fData.fChildDataCollection, prevFlowList, nextFlowList, ref resultSet);
                    }
                    else
                    {
                        if (fData.fSourceType == FDataSourceType.Item)
                        {
                            if (prevFlowList.ContainsKey(FFlowType.SecsTrigger))
                            {
                                fSecsTrigger = (FSecsTrigger)prevFlowList[FFlowType.SecsTrigger];
                                foreach (FSecsCondition fCondition in fSecsTrigger.fChildSecsConditionCollection)
                                {
                                    if (!fCondition.hasMessage)
                                    {
                                        resultSet.fData = fData;
                                        resultSet.resultMessage.AppendFormat("SecsMessage is nothing in SecsTrigger Condition.[{0}]", fCondition.ToString(FStringOption.Detail));
                                        break;
                                    }

                                    //--
                                    if (string.IsNullOrEmpty(fData.sourceItem))
                                    {
                                        resultSet.fData = fData;
                                        resultSet.resultMessage.AppendFormat("DataSet source item name is nothing.[{0}]", fData.name);
                                        break;
                                    }

                                    //--
                                    if (fCondition.fMessage.selectAllSecsItemByName(fData.sourceItem).count == 0)
                                    {
                                        resultSet.fData = fData;
                                        resultSet.fSource = fCondition.fMessage;
                                        resultSet.resultMessage.AppendFormat("SecsItem is nothing in {0}. [{1}]", fCondition.fMessage.ToString(FStringOption.Detail), fData.sourceItem);
                                        break;
                                    }

                                    // --
                                }
                            }
                            else if (prevFlowList.ContainsKey(FFlowType.HostTrigger))
                            {
                                fHostTrigger = (FHostTrigger)prevFlowList[FFlowType.HostTrigger];
                                foreach (FHostCondition fCondition in fHostTrigger.fChildHostConditionCollection)
                                {
                                    if (!fCondition.hasMessage)
                                    {
                                        resultSet.fData = fData;
                                        resultSet.resultMessage.AppendFormat("HostMessage is nothing in SecsTrigger Condition.[{0}]", fCondition.ToString(FStringOption.Detail));
                                        break;
                                    }

                                    //--
                                    if (string.IsNullOrEmpty(fData.sourceItem))
                                    {
                                        resultSet.fData = fData;
                                        resultSet.resultMessage.AppendFormat("DataSet source item name is nothing.[{0}]", fData.name);
                                        break;
                                    }

                                    //--
                                    if (fCondition.fMessage.selectAllHostItemByName(fData.sourceItem).count == 0)
                                    {
                                        resultSet.fData = fData;
                                        resultSet.fSource = fCondition.fMessage;
                                        resultSet.resultMessage.AppendFormat("HostItem is nothing in {0}. [{1}]", fCondition.fMessage.ToString(FStringOption.Detail), fData.sourceItem);
                                        break;
                                    }

                                    // --
                                }
                            }
                            else
                            {
                                resultSet.resultMessage.Append("Message Nothing.");
                            }
                        }

                        // --

                        if (fData.fTargetType == FDataTargetType.Item)
                        {
                            if (nextFlowList.ContainsKey(FFlowType.SecsTransmitter))
                            {
                                fSecsTransmitter = (FSecsTransmitter)nextFlowList[FFlowType.SecsTransmitter];
                                foreach (FSecsTransfer fTransfer in fSecsTransmitter.fChildSecsTransferCollection)
                                {
                                    if (!fTransfer.hasMessage)
                                    {
                                        resultSet.fData = fData;
                                        resultSet.resultMessage.AppendFormat("SecsMessage is nothing in SecsTransfer.[{0}]", fTransfer.ToString(FStringOption.Detail));
                                        break;
                                    }

                                    //--
                                    if (string.IsNullOrEmpty(fData.targetItem))
                                    {
                                        resultSet.fData = fData;
                                        resultSet.resultMessage.AppendFormat("DataSet target item name is nothing.[{0}]", fData.name);
                                        break;
                                    }

                                    //--
                                    if (fTransfer.fMessage.selectAllSecsItemByName(fData.targetItem).count == 0)
                                    {
                                        resultSet.fData = fData;
                                        resultSet.fSource = fTransfer.fMessage;
                                        resultSet.resultMessage.AppendFormat("SecsItem is nothing in {0}. [{1}]", fTransfer.fMessage.ToString(FStringOption.Detail), fData.targetItem);
                                        break;
                                    }

                                    // --
                                }
                            }
                            else if (nextFlowList.ContainsKey(FFlowType.HostTransmitter))
                            {
                                fHostTransmitter = (FHostTransmitter)nextFlowList[FFlowType.HostTransmitter];
                                foreach (FHostTransfer fHostTransfer in fHostTransmitter.fChildHostTransferCollection)
                                {
                                    if (!fHostTransfer.hasMessage)
                                    {
                                        resultSet.fData = fData;
                                        resultSet.resultMessage.AppendFormat("HostMessage is nothing in Host Transfer.[{0}]", fHostTransfer.ToString(FStringOption.Detail));
                                        break;
                                    }

                                    //--
                                    if (string.IsNullOrEmpty(fData.targetItem))
                                    {
                                        resultSet.fData = fData;
                                        resultSet.resultMessage.AppendFormat("DataSet target item name is nothing.[{0}]", fData.name);
                                        break;
                                    }

                                    //--
                                    if (fHostTransfer.fMessage.selectAllHostItemByName(fData.targetItem).count == 0)
                                    {
                                        resultSet.fData = fData;
                                        resultSet.fSource = fHostTransfer.fMessage;
                                        resultSet.resultMessage.AppendFormat("HostItem is nothing in {0}. [{1}]", fHostTransfer.fMessage.ToString(FStringOption.Detail), fData.targetItem);
                                        break;
                                    }

                                    // --
                                }
                            }
                            else
                            {
                                resultSet.resultMessage.Append("Message Nothing.");
                            }
                        }

                        // --
                        if (resultSet.resultMessage.Length > 0)
                        {
                            break;
                        }

                        // --
                    }
                }

                // --
            }
            catch (Exception ex)
            {
                resultSet.resultMessage.Append(ex.Message);
            }
            finally
            {
                // --
                fSecsTrigger = null;
                fHostTrigger = null;
                // --
                fSecsTransmitter = null;
                fHostTransmitter = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public Dictionary<FFlowType, FIFlow> getPrevRefObject(
            FIFlow fFlow
            )
        {
            Dictionary<FFlowType, FIFlow> fRetFlowList = null;
            FIFlow fRetFlow = null;
            try
            {
                fRetFlowList = new Dictionary<FFlowType, FIFlow>();
                // --
                fRetFlow = fFlow.fPreviousSibling;
                while (fRetFlow != null)
                {
                    // --

                    if (fRetFlow.fFlowType == FFlowType.SecsTrigger ||
                        fRetFlow.fFlowType == FFlowType.HostTrigger ||
                        fRetFlow.fFlowType == FFlowType.Storage
                        )
                    {
                        if (fRetFlowList.ContainsKey(fRetFlow.fFlowType))
                            break;

                        fRetFlowList.Add(fRetFlow.fFlowType, fRetFlow);
                    }

                    // --
                    if (fRetFlow.fFlowType == FFlowType.SecsTrigger ||
                        fRetFlow.fFlowType == FFlowType.HostTrigger)
                    {
                        break;
                    }

                    // --
                    fRetFlow = fRetFlow.fPreviousSibling;
                }

                // --
                return fRetFlowList;
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

        public Dictionary<FFlowType, FIFlow> getNextRefObject(
            FIFlow fFlow
            )
        {
            Dictionary<FFlowType, FIFlow> fRetFlowList = null;
            FIFlow fRetFlow = null;
            try
            {
                fRetFlowList = new Dictionary<FFlowType, FIFlow>();
                // --
                fRetFlow = fFlow.fNextSibling;
                while (fRetFlow != null)
                {
                    // --

                    if (fRetFlow.fFlowType == FFlowType.SecsTransmitter ||
                        fRetFlow.fFlowType == FFlowType.HostTransmitter
                        )
                    {
                        if (fRetFlowList.ContainsKey(fRetFlow.fFlowType))
                            break;

                        // --
                        fRetFlowList.Add(fRetFlow.fFlowType, fRetFlow);
                        break;
                    }
                    
                    // --
                    fRetFlow = fRetFlow.fNextSibling;
                }

                // --
                return fRetFlowList;
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

        public void procMenuGoto(
            string menuKey
            )
        {
            FDataSetValidationSet fvs = null;
            try
            {
                if (grdList.ActiveRow != null)
                {
                    fvs = grdList.ActiveRow.Tag as FDataSetValidationSet;
                    if (string.IsNullOrEmpty(menuKey))
                    {
                        if (fvs.fDataSet != null)
                        {
                            m_fSsmCore.fSsmContainer.gotoRelation(fvs.fDataSet);
                        }
                    }
                    else if (menuKey.Equals(FMenuKey.MenuDsdGotoData))
                    {
                        if (fvs.fData != null)
                        {
                            m_fSsmCore.fSsmContainer.gotoRelation(fvs.fData);
                        }
                    }
                    else if (menuKey.Equals(FMenuKey.MenuDsdGotoSource))
                    {
                        if (fvs.fSource != null)
                        {
                            m_fSsmCore.fSsmContainer.gotoRelation(fvs.fSource);
                        }
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FDataSetValidation Form Event Handler

        private void FDataSetValidation_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
                m_tranEnabled = true;

                // --

                designGridOfDataSet();

                // --

                attach();
                
                // --

                m_fSsmCore.fOption.fChildFormList.add(this);
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

        private void FDataSetValidation_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();
                
                // --

                grdList.Focus();
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

        private void FDataSetValidation_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fSsmCore.fOption.fChildFormList.remove(this);
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

        #region btnStart Control Event Handler

        private void btnStart_Click(
            object sender, 
            EventArgs e
            )
        {
            FTransactionProgress fPrgDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fPrgDialog = new FTransactionProgress(
                    m_fSsmCore,
                    this,
                    this.fUIWizard.generateMessage("M0010", new object[] { "Start" })
                    );
                fPrgDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                if (fPrgDialog != null)
                {
                    fPrgDialog.Dispose();
                    fPrgDialog = null;
                }

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdList Control Event Handler
              
        private void grdList_DoubleClickRow(
            object sender, 
            DoubleClickRowEventArgs e
            )
        {
            FDataSetValidationSet fvs = null;
            try
            {
                FCursor.waitCursor();

                // --
                fvs = e.Row.Tag as FDataSetValidationSet;
                // --
                procMenuGoto(string.Empty);      
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fvs = null;
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdList_MouseDown(
            object sender,
            MouseEventArgs e
            )
        {
            UltraGridRow r = null;
            FDataSetValidationSet fvs = null;
            string serverType = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Button != MouseButtons.Right || grdList.Rows.Count == 0)
                {
                    return;
                }

                // --

                r = (UltraGridRow)grdList.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).GetContext(typeof(UltraGridRow));
                if (r != null)
                {
                    grdList.ActiveRow = grdList.Rows[r.Index];
                }

                // --
                fvs = r.Tag as FDataSetValidationSet;

                // --
                
                #region Menu Control

                mnuMenu.Tools[FMenuKey.MenuDsdGotoData].SharedProps.Enabled = fvs.fData == null ? false : true;
                mnuMenu.Tools[FMenuKey.MenuDsdGotoSource].SharedProps.Enabled = fvs.fSource == null ? false : true;
                // --

                #endregion

                // -- 

                mnuMenu.ShowPopup(FMenuKey.MenuDsdPopupMenu);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                r = null;
                // --
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region mnuMenu Control Event Handler

        private void mnuMenu_ToolClick(
            object sender,
            Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
                procMenuGoto(e.Tool.Key); 

                // --
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
