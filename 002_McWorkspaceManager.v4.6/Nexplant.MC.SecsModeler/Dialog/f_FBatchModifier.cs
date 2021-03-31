/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FBatchModifier.cs
--  Creator         : jeff.Kim
--  Create Date     : 2018.03.24
--  Description     : FAMate SECS Modeler Batch Modifier Form Class 
--  History         : Created by jeff.kim at 2018.03.24
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
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Nexplant.MC.SecsModeler
{
    public partial class FBatchModifier : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm, FITransaction
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private FSecsLibrary m_fSecsLibrary = null;
        private bool m_cancel = false;
        // --
        private int m_keyIndex = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FBatchModifier(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FBatchModifier(
            FSsmCore fSsmCore,
            FSecsLibrary fSecsLibrary
            )
            : this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;
            m_fSecsLibrary = fSecsLibrary;
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
                    m_fSecsLibrary = null;
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

        private void controlMenu(
            )
        {
            try
            {
                mnuMenu.beginUpdate();

                // --

                foreach (ToolBase t in mnuMenu.Tools)
                {
                    t.SharedProps.Enabled = false;                   
                }

                // --

                if (grdList.activeDataRow == null)
                {
                    mnuMenu.Tools[FMenuKey.MenuVteAppendValueFormula].SharedProps.Enabled = true;
                }
                else
                {
                    // --
                    mnuMenu.Tools[FMenuKey.MenuVteAppendValueFormula].SharedProps.Enabled = true;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuVteRemoveValueFormula].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuVteRemoveAllValueFormula].SharedProps.Enabled = true;

                    // --

                    if (grdList.activeDataRow.Index > 0)
                    {
                        mnuMenu.Tools[FMenuKey.MenuVteMoveUp].SharedProps.Enabled = true;
                    }

                    if (grdList.activeDataRow.Index < grdList.Rows.Count - 1)
                    {
                        mnuMenu.Tools[FMenuKey.MenuVteMoveDown].SharedProps.Enabled = true;
                    }
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

        private void deisngGridOfBatchModifier(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Key");
                uds.Band.Columns.Add("Index");
                uds.Band.Columns.Add("Result");
                uds.Band.Columns.Add("Message");
                uds.Band.Columns.Add("Type");
                uds.Band.Columns.Add("Target");
                uds.Band.Columns.Add("Value");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Index"].CellAppearance.Image = Properties.Resources.SecsItem_unlock;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Key"].Hidden = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Index"].Width = 60;
                grdList.DisplayLayout.Bands[0].Columns["Result"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Message"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Type"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Target"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Value"].Width = 120;

                // --

                grdList.ImageList = new ImageList();
                // --
                grdList.ImageList.Images.Add("Transaction_Target", Properties.Resources.Trn_Target);
                grdList.ImageList.Images.Add("Transaction_Result_Success", Properties.Resources.Trn_Result_Success);
                grdList.ImageList.Images.Add("Transaction_Result_Fail", Properties.Resources.Trn_Result_Fail);
                grdList.ImageList.Images.Add("Transaction_Result_Cancel", Properties.Resources.Trn_Result_Cancel);

                // --

                grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
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

        private Image getImageOfList(
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

        private void updateBatchJobIndex(
            )
        {
            try
            {
                grdList.beginUpdate();

                // --

                for (int i = 0; i < grdList.Rows.Count; i++)
                {
                    grdList.getDataRow(i).SetCellValue("Index", i.ToString());
                }

                // --

                grdList.endUpdate();
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void action(
            )
        {
            string command = string.Empty;
            string station = string.Empty;
            string castChannel = string.Empty;
            string module = string.Empty;
            string result = string.Empty;
            string msg = string.Empty;
            // --
            FBatchModifierJob fModifiedJob;
            FFormat fFormat = FFormat.Ascii;

            try
            {
                // --

                foreach (UltraDataRow r in grdList.dataSource.Rows)
                {
                    // --
                    Application.DoEvents();

                    // --

                    command = grdList.getDataRowKey(r.Index);

                    // --

                    grdList.activateDataRow(command);

                    // --
                                        
                    try
                    {
                        fModifiedJob = (FBatchModifierJob)r.Tag;
                        if (fModifiedJob.fTargetObjectType == FBatchModifierType.SecsItem)
                        {
                            if (fModifiedJob.Target == "FFormat")
                            {
                                fFormat = (FFormat)Enum.Parse(typeof(FFormat), fModifiedJob.Value);
                                foreach (FSecsMessageList fsm in m_fSecsLibrary.fChildSecsMessageListCollection)
                                {
                                    foreach (FSecsMessages fsmes in fsm.fChildSecsMessagesCollection)
                                    {
                                        foreach (FSecsMessage fmsg in fsmes.fChildSecsMessageCollection)
                                        {
                                            itemFormatChange(fFormat, fmsg.fChildSecsItemCollection);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (FSecsMessageList fsm in m_fSecsLibrary.fChildSecsMessageListCollection)
                                {
                                    foreach (FSecsMessages fsmes in fsm.fChildSecsMessagesCollection)
                                    {
                                        foreach (FSecsMessage fmsg in fsmes.fChildSecsMessageCollection)
                                        {
                                            itemValueChange(fModifiedJob.Value, fmsg.fChildSecsItemCollection);
                                        }
                                    }
                                }
                            }
                        }
                        // --
                        result = "Success";
                    }
                    catch (Exception ex)
                    {
                        result = "Fail";
                        msg = ex.Message;
                    }
                   
                    // --

                    r["Result"] = result;
                    r["Message"] = msg;

                    // --
                    grdList.Rows[r.Index].Cells["Index"].Appearance.Image = getImageOfList(result);

                    // --
                }

                // --
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

        public void itemFormatChange(
            FFormat fFormat,
            FSecsItemCollection fSecsItemCollection            
            )
        {        
            try
            {
                // --

                foreach (FSecsItem fItm in fSecsItemCollection)
                {
                    // --
                    
                    if (fItm.fFormat == FFormat.List)
                    {
                        itemFormatChange(fFormat, fItm.fChildSecsItemCollection);
                        continue;
                    }

                    // --
                    fItm.fFormat = fFormat;

                    // --
                }

                // --
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

        public void itemValueChange(
            string value,
            FSecsItemCollection fSecsItemCollection
            )
        {
            try
            {
                // --

                foreach (FSecsItem fItm in fSecsItemCollection)
                {
                    // --

                    if (fItm.fFormat == FFormat.List)
                    {
                        itemValueChange(value, fItm.fChildSecsItemCollection);
                        continue;
                    }

                    // --
                    fItm.originalStringValue = value;

                    // --
                }

                // --
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

        private void procMenuAppendBatchJob(
            )
        {
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            FBatchModifierJob fBatchModifierJob;
            try
            {                
                // --
                fBatchModifierJob = new FBatchModifierJob(
                    FBatchModifierType.SecsItem,
                    FBatchModifierTarget.Format.ToString(), 
                    FFormat.Ascii.ToString()
                    );

                // --

                cellValues = new object[] 
                {
                    m_keyIndex.ToString(),
                    string.Empty,
                    fBatchModifierJob.fTargetObjectType.ToString(),
                    fBatchModifierJob.Target,
                    fBatchModifierJob.Value
                };
                m_keyIndex++;
                // --
                dataRow = grdList.appendDataRow((string)cellValues[0], cellValues);
                dataRow.Tag = fBatchModifierJob;
                updateBatchJobIndex();
                grdList.activateDataRow((string)cellValues[0]);

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRemoveBatchJob(
            )
        {
            int index = 0;

            try
            {
                index = grdList.activeDataRow.Index;

                // --

                grdList.removeDataRow(index);
                updateBatchJobIndex();

                // --

                if (grdList.Rows.Count == 0)
                {
                    initPropOfBatchJob();
                }
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

        private void procMenuRemoveAllBatchJob(
            )
        {
            try
            {
                grdList.removeAllDataRow();

                // --

                initPropOfBatchJob();
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

        private void procMenuMoveUp(
            )
        {
            try
            {
                // --
                grdList.moveUpDataRow(grdList.activeDataRow.Index);
                updateBatchJobIndex();
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

        private void procMenuMoveDown(
            )
        {
            try
            {
                // --
                grdList.moveDownDataRow(grdList.activeDataRow.Index);
                updateBatchJobIndex();
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

        private void initPropOfBatchJob(
            )
        {
            try
            {
                pgdProp.selectedObject = null;
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

        private void setPropOfBatchModifierJob(
            )
        {
            try
            {
                pgdProp.selectedObject = new FPropBmj(
                    m_fSsmCore,
                    pgdProp,                    
                    (FBatchModifierJob)grdList.activeDataRow.Tag,
                    grdList.activeDataRow
                    );                
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

        #region FBatchModifier Form Event Handler

        private void FBatchModifier_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                deisngGridOfBatchModifier();
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

        private void FBatchModifier_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                controlMenu();

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

        private void FBatchModifier_KeyDown(
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
                FDebug.throwException(ex);
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

               if (e.Tool.Key == FMenuKey.MenuVteAppendValueFormula)
                {
                    procMenuAppendBatchJob();
                }
                else if (e.Tool.Key == FMenuKey.MenuVteRemoveValueFormula)
                {
                    procMenuRemoveBatchJob();
                }
                else if (e.Tool.Key == FMenuKey.MenuVteRemoveAllValueFormula)
                {
                    procMenuRemoveAllBatchJob();
                }
                else if (e.Tool.Key == FMenuKey.MenuVteMoveUp)
                {
                    procMenuMoveUp();
                }
                else if (e.Tool.Key == FMenuKey.MenuVteMoveDown)
                {
                    procMenuMoveDown();
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

        #region grdList Control Event Handler

        private void grdList_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfBatchModifierJob();
                controlMenu();
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

        private void grdList_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            UIElement element = null;
            UltraGridRow gridRow = null;

            try
            {
                if (e.Button != System.Windows.Forms.MouseButtons.Right)
                {
                    return;
                }

                // --

                element = grdList.DisplayLayout.UIElement.ElementFromPoint(e.Location);
                if (element != null)
                {
                    gridRow = (UltraGridRow)element.GetContext(typeof(UltraGridRow));
                    if (gridRow != null)
                    {
                        grdList.ActiveRow = gridRow;
                    }
                }

                // --

                mnuMenu.ShowPopup(FMenuKey.MenuVtePopupMenu);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                element = null;
                gridRow = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region BtnOk Event Handler 

        private void btnOk_Click(
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

    }   // Class end
}   // Namespace end
