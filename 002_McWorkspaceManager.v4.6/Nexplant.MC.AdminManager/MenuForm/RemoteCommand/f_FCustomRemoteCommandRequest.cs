/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FCustoRemoteCommandRequest.cs
--  Creator         : hsshim
--  Create Date     : 2013.02.14
--  Description     : FAMate Admin Manager Remote Command - Custom Remote Command
--  History         : Created by hsshim at 2013.06.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.Data;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Nexplant.MC.AdminManager
{
    public partial class FCustomRemoteCommandRequest : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm, FIRemoteCommand
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_cancel = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FCustomRemoteCommandRequest(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FCustomRemoteCommandRequest(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
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
                    m_fAdmCore = null;
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
                this.Text = m_fAdmCore.fWsmCore.fUIWizard.searchCaption(this.Text);
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
                base.fUIWizard.changeControlCaption(mnuMenu);
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

        private void designGridOfEquipment(
            )
        {
            UltraDataSource uds = null;            

            try
            {
                uds = grdList.dataSource;

                // --

                uds.Band.Columns.Add("Equipment");
                uds.Band.Columns.Add("EAP");
                uds.Band.Columns.Add("Result");
                uds.Band.Columns.Add("Proc. Time (ms)");
                uds.Band.Columns.Add("Message");                
                                
                // --

                grdList.DisplayLayout.Bands[0].Columns["Equipment"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["EAP"].Width = 150;
                grdList.DisplayLayout.Bands[0].Columns["Result"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Proc. Time (ms)"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["Proc. Time (ms)"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdList.DisplayLayout.Bands[0].Columns["Message"].Width = 80;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Equipment"].Header.Fixed = true;

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

        private void designGridOfCommand(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdRcmdList.dataSource;
                // --
                uds.Band.Columns.Add("Command");
                uds.Band.Columns.Add("Description");

                // --

                grdRcmdList.DisplayLayout.Bands[0].Columns["Command"].CellAppearance.Image = Properties.Resources.Command;
                // --
                grdRcmdList.DisplayLayout.Bands[0].Columns["Command"].Header.Fixed = true;
                // --
                grdRcmdList.DisplayLayout.Bands[0].Columns["Command"].Width = 200;
                grdRcmdList.DisplayLayout.Bands[0].Columns["Description"].Width = 90;
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

        public void attach(
            string [] equipmentList,
            string eapName
            )
        {
            object[] cellValues = null;
            int index = 0;

            try
            {
                grdList.beginUpdate(false);

                // --

                procMenuClear();

                // --

                foreach (string equipment in equipmentList)
                {
                    cellValues = new object[] {
                        equipment,
                        eapName,
                        string.Empty
                        };
                    index = grdList.appendOrUpdateDataRow(equipment, cellValues).Index;
                    grdList.Rows[index].Cells["Equipment"].Appearance.Image = grdList.ImageList.Images["Transaction_Target"];
                }

                // --

                grdList.endUpdate(false);

                // --

                if (grdList.activeDataRow == null)
                {
                    grdList.ActiveRow = grdList.Rows[0];
                }
                btnRequest.Enabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.EquipmentEventDefineRequest);

                // --

                grdList.Focus();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void attach(
            string[,] equipmentList
            )
        {
            object[] cellValues = null;
            int index = 0;

            try
            {
                grdList.beginUpdate(false);

                // --

                procMenuClear();

                // --

                for (int i = 0; i < equipmentList.GetLength(0); i++)
                {
                    cellValues = new object[] {
                        equipmentList[i,0],
                        equipmentList[i,1],
                        string.Empty
                        };
                    index = grdList.appendOrUpdateDataRow(equipmentList[i,0], cellValues).Index;
                    grdList.Rows[index].Cells["Equipment"].Appearance.Image = grdList.ImageList.Images["Transaction_Target"];

                }

                // --

                grdList.endUpdate(false);

                // --

                if (grdList.activeDataRow == null)
                {
                    grdList.ActiveRow = grdList.Rows[0];
                }
                btnRequest.Enabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.EquipmentEventDefineRequest);

                // --

                grdList.Focus();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void attach(
            UltraDataRow[] dataRow
            )
        {
            object[] cellValues = null;
            int index = 0;

            try
            {
                grdList.beginUpdate(false);

                // --

                procMenuClear();

                // --

                foreach (UltraDataRow r in dataRow)
                {
                    cellValues = new object[] {
                        r["Equipment"].ToString(),
                        r["EAP"].ToString(),
                        string.Empty
                        };
                    index =  grdList.appendOrUpdateDataRow(r["Equipment"].ToString(), cellValues).Index;
                    grdList.Rows[index].Cells["Equipment"].Appearance.Image = grdList.ImageList.Images["Transaction_Target"];
                }

                // --

                grdList.endUpdate(false);

                // --

                if (grdList.activeDataRow == null)
                {
                    grdList.ActiveRow = grdList.Rows[0];
                }
                btnRequest.Enabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.EquipmentEventDefineRequest);

                // --

                grdList.Focus();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAttach(
            )
        {
            FEquipmentClassSelector fEqpSelector = null;
            object[] cellValues = null;
            int index = 0;

            try
            {
                fEqpSelector = new FEquipmentClassSelector(m_fAdmCore);
                if (fEqpSelector.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                grdList.beginUpdate(false);

                // --

                foreach (DictionaryEntry de in fEqpSelector.selectedEquipmentList)
                {
                    cellValues = new object[] {
                        de.Key.ToString(),
                        de.Value.ToString()
                        };
                    // --
                    index = grdList.appendOrUpdateDataRow(de.Key.ToString(), cellValues).Index;
                    grdList.Rows[index].Cells["Equipment"].Appearance.Image = grdList.ImageList.Images["Transaction_Target"];
                }

                // --

                grdList.endUpdate(false);

                // --

                if (grdList.activeDataRow == null)
                {
                    grdList.ActiveRow = grdList.Rows[0];
                }
                btnRequest.Enabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.EquipmentEventDefineRequest);

                // --

                refreshGridOfCommand();
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                if (fEqpSelector != null)
                {
                    fEqpSelector.Dispose();
                    fEqpSelector = null;
                }
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuDetach(
            )
        {
            try
            {
                if (grdList.Rows.Count == 0)
                {
                    return;
                }

                // --

                grdList.beginUpdate();
                
                // --

                grdList.removeDataRows(grdList.selectedDataRowKeys);

                // --

                grdList.endUpdate();

                // --

                if (grdList.Rows.Count == 0)
                {
                    btnRequest.Enabled = false;
                }
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

        private void procMenuClear(
            )
        {
            try
            {
                grdList.beginUpdate();

                // --

                grdList.removeAllDataRow();

                // --

                grdList.endUpdate();

                // --

                lblSuccess.Text = "0";
                lblFail.Text = "0";
                lblCancel.Text = "0";

                // --

                mnuMenu.Tools["Attach"].SharedProps.Enabled = true;
                mnuMenu.Tools["Detach"].SharedProps.Enabled = true;
                btnRequest.Enabled = false;
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

        private void procMenuReset(
            )
        {
            try
            {
                grdList.beginUpdate();

                // --

                foreach (UltraDataRow r in grdList.dataSource.Rows)
                {
                    r["Result"] = string.Empty;
                    r["Proc. Time (ms)"] = string.Empty;
                    r["Proc. Time (ms)"] = string.Empty;
                    r["Message"] = string.Empty;
                }

                // --

                grdList.endUpdate();

                // --

                lblSuccess.Text = "0";
                lblFail.Text = "0";
                lblCancel.Text = "0";
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
            FPropCustomRemoteCommandParameter fPropCrcp = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEap = null;
            FXmlNode fXmlNodeInEqp = null;
            FXmlNode fXmlNodeInDataList = null;
            FXmlNode fXmlNodeOut = null;
            string result = string.Empty;
            string msg = string.Empty;
            Stopwatch sw = null;
            int sCnt = 0;
            int fCnt = 0;
            int cCnt = 0;

            try
            {
                mnuMenu.Tools["Attach"].SharedProps.Enabled = false;
                mnuMenu.Tools["Detach"].SharedProps.Enabled = false;
                btnRequest.Enabled = false;
                m_cancel = false;
                sw = new Stopwatch();

                // --

                fPropCrcp = (FPropCustomRemoteCommandParameter)pgdProp.selectedObject;
                
                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_RcmEquipmentCustomRequest_In.E_ADMADS_RcmEquipmentCustomRequest_In);
                fXmlNodeIn.set_elemVal(
                    FADMADS_RcmEquipmentCustomRequest_In.A_hLanguage, 
                    FADMADS_RcmEquipmentCustomRequest_In.D_hLanguage, 
                    m_fAdmCore.fWsmOption.language.ToString()
                    );
                fXmlNodeIn.set_elemVal(
                    FADMADS_RcmEquipmentCustomRequest_In.A_hStep, 
                    FADMADS_RcmEquipmentCustomRequest_In.D_hStep, 
                    "1"
                    );
                fXmlNodeIn.set_elemVal(
                    FADMADS_RcmEquipmentCustomRequest_In.A_hFactory, 
                    FADMADS_RcmEquipmentCustomRequest_In.D_hFactory, 
                    m_fAdmCore.fOption.factory
                    );
                fXmlNodeIn.set_elemVal(
                    FADMADS_RcmEquipmentCustomRequest_In.A_hUserId, 
                    FADMADS_RcmEquipmentCustomRequest_In.D_hUserId, 
                    m_fAdmCore.fOption.user
                    );
                fXmlNodeIn.set_elemVal(
                    FADMADS_RcmEquipmentCustomRequest_In.A_hHostIp, 
                    FADMADS_RcmEquipmentCustomRequest_In.D_hHostIp, 
                    m_fAdmCore.fOption.hostIPAddrress
                    );
                fXmlNodeIn.set_elemVal(
                    FADMADS_RcmEquipmentCustomRequest_In.A_hHostName, 
                    FADMADS_RcmEquipmentCustomRequest_In.D_hHostName, 
                    m_fAdmCore.fOption.hostName
                    );
                // --

                fXmlNodeInEap = fXmlNodeIn.set_elem(FADMADS_RcmEquipmentCustomRequest_In.FEap.E_Eap);

                // --

                foreach (UltraDataRow r in grdList.dataSource.Rows)
                {
                    sw.Reset();
                    sw.Start();
                    // --
                    Application.DoEvents();                    

                    // --

                    if (m_cancel)
                    {
                        grdList.Rows[r.Index].Cells["Equipment"].Appearance.Image = getImageOfCommandResult("Cancel");
                        result = this.fUIWizard.searchCaption("Cancel");
                        msg = this.fUIWizard.generateMessage("M0011");
                        // --
                        cCnt++;
                    }
                    else
                    {
                        fXmlNodeInEap.set_elemVal(
                            FADMADS_RcmEquipmentCustomRequest_In.FEap.A_EapId, 
                            FADMADS_RcmEquipmentCustomRequest_In.FEap.D_EapId, 
                            r["EAP"].ToString()
                            );
                        fXmlNodeInEap.set_elemVal(
                            FADMADS_RcmEquipmentCustomRequest_In.FEap.A_Command,
                            FADMADS_RcmEquipmentCustomRequest_In.FEap.D_Command,
                            this.grdRcmdList.activeDataRowKey
                            );

                        // --

                        fXmlNodeInEqp = fXmlNodeInEap.set_elem(FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.E_Equipment);
                        fXmlNodeInEqp.set_elemVal(
                            FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.A_EquipmentId, 
                            FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.D_EquipmentId, 
                            r["Equipment"].ToString()
                            );

                        // --

                        fXmlNodeInDataList = fXmlNodeInEqp.set_elem(FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.FDataList.E_DataList);

                        // --

                        if (fPropCrcp.fTypeDescriptor.propertyDescriptors[0].IsBrowsable)
                        {
                            fXmlNodeInDataList.add_elemVal(
                                FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.FDataList.A_Data,
                                FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.FDataList.D_Data, 
                                fPropCrcp.Data_1
                                );
                        }
                        // --
                        if (fPropCrcp.fTypeDescriptor.propertyDescriptors[1].IsBrowsable)
                        {
                            fXmlNodeInDataList.add_elemVal(
                                FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.FDataList.A_Data,
                                FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.FDataList.D_Data,
                                fPropCrcp.Data_2
                                );
                        }
                        // --
                        if (fPropCrcp.fTypeDescriptor.propertyDescriptors[2].IsBrowsable)
                        {
                            fXmlNodeInDataList.add_elemVal(
                                FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.FDataList.A_Data,
                                FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.FDataList.D_Data,
                                fPropCrcp.Data_3
                                );
                        }
                        // --
                        if (fPropCrcp.fTypeDescriptor.propertyDescriptors[3].IsBrowsable)
                        {
                            fXmlNodeInDataList.add_elemVal(
                                FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.FDataList.A_Data,
                                FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.FDataList.D_Data,
                                fPropCrcp.Data_4
                                );
                        }
                        // --
                        if (fPropCrcp.fTypeDescriptor.propertyDescriptors[4].IsBrowsable)
                        {
                            fXmlNodeInDataList.add_elemVal(
                                FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.FDataList.A_Data,
                                FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.FDataList.D_Data,
                                fPropCrcp.Data_5
                                );
                        }
                        // --
                        if (fPropCrcp.fTypeDescriptor.propertyDescriptors[5].IsBrowsable)
                        {
                            fXmlNodeInDataList.add_elemVal(
                                FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.FDataList.A_Data,
                                FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.FDataList.D_Data,
                                fPropCrcp.Data_6
                                );
                        }
                        // --
                        if (fPropCrcp.fTypeDescriptor.propertyDescriptors[6].IsBrowsable)
                        {
                            fXmlNodeInDataList.add_elemVal(
                                FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.FDataList.A_Data,
                                FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.FDataList.D_Data,
                                fPropCrcp.Data_7
                                );
                        }
                        // --
                        if (fPropCrcp.fTypeDescriptor.propertyDescriptors[7].IsBrowsable)
                        {
                            fXmlNodeInDataList.add_elemVal(
                                FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.FDataList.A_Data,
                                FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.FDataList.D_Data,
                                fPropCrcp.Data_8
                                );
                        }
                        // --
                        if (fPropCrcp.fTypeDescriptor.propertyDescriptors[8].IsBrowsable)
                        {
                            fXmlNodeInDataList.add_elemVal(
                                FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.FDataList.A_Data,
                                FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.FDataList.D_Data,
                                fPropCrcp.Data_9
                                );
                        }
                        // --
                        if (fPropCrcp.fTypeDescriptor.propertyDescriptors[9].IsBrowsable)
                        {
                            fXmlNodeInDataList.add_elemVal(
                                FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.FDataList.A_Data,
                                FADMADS_RcmEquipmentCustomRequest_In.FEap.FEquipment.FDataList.D_Data,
                                fPropCrcp.Data_10
                                );
                        }
                                                
                        // --
                        
                        try
                        {
                            FADMADSCaster.ADMADS_RcmEquipmentCustomRequest_Req(
                                m_fAdmCore.fH101,
                                fXmlNodeIn,
                                ref fXmlNodeOut
                                );

                            if (fXmlNodeOut.get_elemVal(FADMADS_RcmEquipmentCustomRequest_Out.A_hStatus, FADMADS_RcmEquipmentCustomRequest_Out.D_hStatus) != "0")
                            {
                                grdList.Rows[r.Index].Cells["Equipment"].Appearance.Image = getImageOfCommandResult("Fail");
                                result = this.fUIWizard.searchCaption("Fail");
                                msg = fXmlNodeOut.get_elemVal(FADMADS_RcmEquipmentCustomRequest_Out.A_hStatusMessage, FADMADS_RcmEquipmentCustomRequest_Out.D_hStatusMessage);
                                // --
                                fCnt++;
                            }
                            else
                            {
                                grdList.Rows[r.Index].Cells["Equipment"].Appearance.Image = getImageOfCommandResult("Success");
                                result = this.fUIWizard.searchCaption("Success");
                                msg = this.fUIWizard.generateMessage("M0012");
                                // --
                                sCnt++;
                            }
                        }
                        catch (Exception ex)
                        {
                            grdList.Rows[r.Index].Cells["Equipment"].Appearance.Image = getImageOfCommandResult("Fail");
                            result = this.fUIWizard.searchCaption("Fail");
                            msg = ex.Message;
                            // --
                            fCnt++;
                        }
                    }                    

                    // --

                    sw.Stop();

                    // --

                    r["Result"] = result;
                    r["Proc. Time (ms)"] = sw.ElapsedMilliseconds.ToString();
                    r["Message"] = msg;
                }

                // --

                lblSuccess.Text = sCnt.ToString();
                lblFail.Text = fCnt.ToString();
                lblCancel.Text = cCnt.ToString();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInEap = null;
                fXmlNodeInEqp = null;
                fXmlNodeInDataList = null;
                fXmlNodeOut = null;
                sw = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfCommand(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string beforeKey = string.Empty;
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {
                if (grdRcmdList.activeDataRow != null)
                {
                    beforeKey = grdRcmdList.activeDataRowKey;
                }

                // --

                // --
                grdRcmdList.beginUpdate();
                grdRcmdList.removeAllDataRow();
                grdRcmdList.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);

                // --

                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "RemoteCommand", "CustomRemoteCommandRequest", "ListCommand", fSqlParams, false, ref nextRowNumber);
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Command
                            r[1].ToString(),   // Description
                            };
                        key = (string)cellValues[0];
                        grdRcmdList.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                grdRcmdList.endUpdate();

                // --

                if (grdRcmdList.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdRcmdList.activateDataRow(beforeKey);
                    }
                    if (grdRcmdList.activeDataRow == null)
                    {
                        grdRcmdList.ActiveRow = grdRcmdList.Rows[0];
                    }
                }

                // --

                refreshCommandTotal();
            }
            catch (Exception ex)
            {
                grdRcmdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshCommandTotal(
            )
        {
            try
            {
                lblTotal.Text = grdRcmdList.Rows.Count.ToString("#,##0");
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

        private void setPropRemoteCommandParameter(
           )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdRcmdList.activeDataRow == null)
                {
                    return;
                }

                // -- 

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("command", grdRcmdList.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "RemoteCommand", "CustomRemoteCommandRequest", "ListCommandParameter", fSqlParams, true);

                // --

                pgdProp.selectedObject = new FPropCustomRemoteCommandParameter(m_fAdmCore, pgdProp, dt);

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

        private Image getImageOfCommandResult(
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FCustomRemoteCommandRequest Form Event Handler

        private void FCustomRemoteCommandRequest_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfEquipment();
                designGridOfCommand();
                // --

                btnRequest.Enabled = false;

                // --

                m_fAdmCore.fOption.fChildFormList.add(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FCustomRemoteCommandRequest_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfCommand();

                // --

                grdList.Focus();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FCustomRemoteCommandRequest_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fAdmCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
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

                if (e.Tool.Key == "Attach")
                {
                    procMenuAttach();
                }
                else if (e.Tool.Key == "Detach")
                {
                    procMenuDetach();
                }
                else if (e.Tool.Key == "Clear")
                {
                    procMenuClear();
                }
                
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

        #region btnRequest Control Event Handler

        private void btnRequest_Click(
            object sender,
            EventArgs e
            )
        {
            FPropCustomRemoteCommandParameter fPropCrcp = null;
            FRemoteCommandProgress fPrgDialog = null;
            
            // --
            string command = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                fPropCrcp = (FPropCustomRemoteCommandParameter)pgdProp.selectedObject;

                // --

                #region Validation

                if (fPropCrcp.fTypeDescriptor.propertyDescriptors[0].IsBrowsable && fPropCrcp.Data_1.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { fPropCrcp.fTypeDescriptor.propertyDescriptors[0].DisplayName }));
                }
                // --
                if (fPropCrcp.fTypeDescriptor.propertyDescriptors[1].IsBrowsable && fPropCrcp.Data_2.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { fPropCrcp.fTypeDescriptor.propertyDescriptors[1].DisplayName }));
                }
                // --
                if (fPropCrcp.fTypeDescriptor.propertyDescriptors[2].IsBrowsable && fPropCrcp.Data_3.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { fPropCrcp.fTypeDescriptor.propertyDescriptors[2].DisplayName }));
                }
                // --
                if (fPropCrcp.fTypeDescriptor.propertyDescriptors[3].IsBrowsable && fPropCrcp.Data_4.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { fPropCrcp.fTypeDescriptor.propertyDescriptors[3].DisplayName }));
                }
                // --
                if (fPropCrcp.fTypeDescriptor.propertyDescriptors[4].IsBrowsable && fPropCrcp.Data_5.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { fPropCrcp.fTypeDescriptor.propertyDescriptors[4].DisplayName }));
                }
                // --
                if (fPropCrcp.fTypeDescriptor.propertyDescriptors[5].IsBrowsable && fPropCrcp.Data_6.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { fPropCrcp.fTypeDescriptor.propertyDescriptors[5].DisplayName }));
                }
                // --
                if (fPropCrcp.fTypeDescriptor.propertyDescriptors[6].IsBrowsable && fPropCrcp.Data_7.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { fPropCrcp.fTypeDescriptor.propertyDescriptors[6].DisplayName }));
                }
                // --
                if (fPropCrcp.fTypeDescriptor.propertyDescriptors[7].IsBrowsable && fPropCrcp.Data_8.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { fPropCrcp.fTypeDescriptor.propertyDescriptors[7].DisplayName }));
                }
                // --
                if (fPropCrcp.fTypeDescriptor.propertyDescriptors[8].IsBrowsable && fPropCrcp.Data_9.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { fPropCrcp.fTypeDescriptor.propertyDescriptors[8].DisplayName }));
                }
                // --
                if (fPropCrcp.fTypeDescriptor.propertyDescriptors[9].IsBrowsable && fPropCrcp.Data_10.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { fPropCrcp.fTypeDescriptor.propertyDescriptors[9].DisplayName }));
                }

                #endregion

                // --

                procMenuReset();

                // --

                fPrgDialog = new FRemoteCommandProgress(
                    m_fAdmCore,
                    this,
                    this.fUIWizard.generateMessage("M0010", new object[] { "Request" })
                    );
                fPrgDialog.ShowDialog();

                // --

                mnuMenu.Tools["Attach"].SharedProps.Enabled = true;
                mnuMenu.Tools["Detach"].SharedProps.Enabled = true;
                btnRequest.Enabled = true;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fPropCrcp = null;
                // --
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

        #region rstToolbar Control Event Handler

        private void rstToolbar_RefreshRequested(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfCommand();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void rstToolbar_SearchRequested(object sender, FSearchRequestedEventArgs e)
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdRcmdList.searchGridRow(e.searchWord))
                {
                    FMessageBox.showInformation("Search", m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdRcmd Control Event Handler

        private void grdRcmdList_AfterRowActivate(object sender, EventArgs e)
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropRemoteCommandParameter();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
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
