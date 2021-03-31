/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSecs1ToHsmsConverterMonitor.cs
--  Creator         : spike.lee
--  Create Date     : 2017.05.10
--  Description     : FAMate Admin Manager SECS1 To HSMS Converter Monitor Form Class 
--  History         : Created by spike.lee at 2017.05.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FSecs1ToHsmsConverterMonitor : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecs1ToHsmsConverterMonitor(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecs1ToHsmsConverterMonitor(
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
        
        private void designGridOfList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Converter");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Type");
                uds.Band.Columns.Add("Converter IP");
                uds.Band.Columns.Add("Up/Down");
                uds.Band.Columns.Add("SECS1 State");
                uds.Band.Columns.Add("HSMS State");
                // --
                uds.Band.Columns.Add("SECS1 Session ID");
                uds.Band.Columns.Add("SECS1 Serial Port");
                uds.Band.Columns.Add("SECS1 Baud");
                uds.Band.Columns.Add("SECS1 R-Bit");
                uds.Band.Columns.Add("SECS1 Interleave");
                uds.Band.Columns.Add("SECS1 Duplicate Error");
                uds.Band.Columns.Add("SECS1 Ignore System Bytes");
                uds.Band.Columns.Add("SECS1 Retry Limit");
                uds.Band.Columns.Add("SECS1 T1");
                uds.Band.Columns.Add("SECS1 T2");
                uds.Band.Columns.Add("SECS1 T3");
                uds.Band.Columns.Add("SECS1 T4");
                // --
                uds.Band.Columns.Add("HSMS Session ID");
                uds.Band.Columns.Add("HSMS Connect Mode");
                uds.Band.Columns.Add("HSMS Local IP");
                uds.Band.Columns.Add("HSMS Local Port");
                uds.Band.Columns.Add("HSMS Remote IP");
                uds.Band.Columns.Add("HSMS Remote Port");
                uds.Band.Columns.Add("HSMS Link Test Period");
                uds.Band.Columns.Add("HSMS T3");
                uds.Band.Columns.Add("HSMS T5");
                uds.Band.Columns.Add("HSMS T6");
                uds.Band.Columns.Add("HSMS T7");
                uds.Band.Columns.Add("HSMS T8");

                // --

                grdList.DisplayLayout.Bands[0].Columns["SECS1 Session ID"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdList.DisplayLayout.Bands[0].Columns["SECS1 Baud"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdList.DisplayLayout.Bands[0].Columns["SECS1 Retry Limit"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdList.DisplayLayout.Bands[0].Columns["SECS1 T1"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdList.DisplayLayout.Bands[0].Columns["SECS1 T2"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdList.DisplayLayout.Bands[0].Columns["SECS1 T3"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdList.DisplayLayout.Bands[0].Columns["SECS1 T4"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdList.DisplayLayout.Bands[0].Columns["HSMS Session ID"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdList.DisplayLayout.Bands[0].Columns["HSMS Local Port"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdList.DisplayLayout.Bands[0].Columns["HSMS Remote Port"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdList.DisplayLayout.Bands[0].Columns["HSMS Link Test Period"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdList.DisplayLayout.Bands[0].Columns["HSMS T3"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdList.DisplayLayout.Bands[0].Columns["HSMS T5"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdList.DisplayLayout.Bands[0].Columns["HSMS T6"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdList.DisplayLayout.Bands[0].Columns["HSMS T7"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdList.DisplayLayout.Bands[0].Columns["HSMS T8"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;                

                // --

                grdList.DisplayLayout.Bands[0].Columns["Converter"].Header.Fixed = true;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Converter"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Type"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["Converter IP"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["Up/Down"].Width = 60;
                grdList.DisplayLayout.Bands[0].Columns["SECS1 State"].Width = 70;
                grdList.DisplayLayout.Bands[0].Columns["HSMS State"].Width = 70;
                // --
                grdList.DisplayLayout.Bands[0].Columns["SECS1 Session ID"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["SECS1 Serial Port"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["SECS1 Baud"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["SECS1 R-Bit"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["SECS1 Interleave"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["SECS1 Duplicate Error"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["SECS1 Ignore System Bytes"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["SECS1 Retry Limit"].Width = 70;
                grdList.DisplayLayout.Bands[0].Columns["SECS1 T1"].Width = 70;
                grdList.DisplayLayout.Bands[0].Columns["SECS1 T2"].Width = 70;
                grdList.DisplayLayout.Bands[0].Columns["SECS1 T3"].Width = 70;
                grdList.DisplayLayout.Bands[0].Columns["SECS1 T4"].Width = 70;
                // --
                grdList.DisplayLayout.Bands[0].Columns["HSMS Session ID"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["HSMS Connect Mode"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["HSMS Local IP"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["HSMS Local Port"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["HSMS Remote IP"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["HSMS Remote Port"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["HSMS Link Test Period"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["HSMS T3"].Width = 70;
                grdList.DisplayLayout.Bands[0].Columns["HSMS T5"].Width = 70;
                grdList.DisplayLayout.Bands[0].Columns["HSMS T6"].Width = 70;
                grdList.DisplayLayout.Bands[0].Columns["HSMS T7"].Width = 70;
                grdList.DisplayLayout.Bands[0].Columns["HSMS T8"].Width = 70;

                // --

                grdList.ImageList = new ImageList();
                // --
                grdList.ImageList.Images.Add("Converter_Up", Properties.Resources.S2HCvt_Up);
                grdList.ImageList.Images.Add("Converter_Down", Properties.Resources.S2HCvt_Down);
                grdList.ImageList.Images.Add("Converter_Alarm", Properties.Resources.S2HCvt_Alarm);
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

        private void refreshGridOfList(
             )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraGridRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            string key = string.Empty;
            string beforeKey = string.Empty;
            int nextRowNumber = 0;
            int index = 0;
            string upDown = string.Empty;
            string alarm = string.Empty;
            
            try
            {
                beforeKey = grdList.activeDataRowKey;
                // --
                grdList.beginUpdate(false);
                grdList.removeAllDataRow();
                grdList.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Secs1ToHsms", "Secs1ToHsmsConverterMonitor", "ListSecs1ToHsmsConverter", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        upDown = r[4].ToString();
                        alarm = r[31].ToString();

                        // --

                        cellValues = new object[] {
                            r[0].ToString(),    // Converter
                            r[1].ToString(),    // Description
                            r[2].ToString(),    // Type
                            r[3].ToString(),    // Converter IP
                            r[4].ToString(),    // Up/Down                            
                            r[5].ToString(),    // SECS1 State
                            r[6].ToString(),    // HSMS State
                            // --
                            r[7].ToString(),    // SECS1 Session ID
                            r[8].ToString(),    // SECS1 Serial Port
                            r[9].ToString(),    // SECS1 Baud
                            r[10].ToString(),   // SECS1 R-Bit
                            r[11].ToString(),   // SECS1 Interleave
                            r[12].ToString(),   // SECS1 Duplidate Error                             
                            r[13].ToString(),   // SECS1 Ignore System Bytes
                            r[14].ToString(),   // SECS1 Retry Limit                     
                            r[15].ToString(),   // SECS1 T1
                            r[16].ToString(),   // SECS1 T2
                            r[17].ToString(),   // SECS1 T3
                            r[18].ToString(),   // SECS1 T4
                            // --
                            r[19].ToString(),   // HSMS Session ID
                            r[20].ToString(),   // HSMS Connect Mode
                            r[21].ToString(),   // HSMS Local IP
                            r[22].ToString(),   // HSMS Local Port
                            r[23].ToString(),   // HSMS Remote IP
                            r[24].ToString(),   // HSMS Remote Port
                            r[25].ToString(),   // HSMS Link Test Period
                            r[26].ToString(),   // HSMS T3
                            r[27].ToString(),   // HSMS T5
                            r[28].ToString(),   // HSMS T6
                            r[29].ToString(),   // HSMS T7
                            r[30].ToString()    // HSMS T8
                            };
                        key = (string)cellValues[0];
                        index = grdList.appendDataRow(key, cellValues).Index;

                        // --

                        row = grdList.Rows.GetRowWithListIndex(index);

                        // --

                        cell = row.Cells["Converter"];
                        if (upDown == FUpDown.Down.ToString())
                        {
                            cell.Appearance.Image = grdList.ImageList.Images["Converter_Down"];
                        }
                        else if (alarm == FYesNo.Yes.ToString())
                        {
                            cell.Appearance.Image = grdList.ImageList.Images["Converter_Alarm"];
                        }
                        else
                        {
                            cell.Appearance.Image = grdList.ImageList.Images["Converter_Up"];
                        }

                        // --

                        cell = row.Cells["Up/Down"];
                        if (cell.Text == FUpDown.Down.ToString())
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }

                        cell = row.Cells["SECS1 State"];
                        if (cell.Text != FCommunicationState.Selected.ToString())
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }

                        cell = row.Cells["HSMS State"];
                        if (cell.Text != FCommunicationState.Selected.ToString())
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }                      
                    }
                } while (nextRowNumber >= 0);

                // --

                grdList.endUpdate(false);

                // --

                if (grdList.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdList.activateDataRow(beforeKey);
                    }
                    if (grdList.activeDataRow == null)
                    {
                        grdList.ActiveRow = grdList.Rows[0];
                    }
                }

                // --

                lblTotal.Text = grdList.Rows.Count.ToString("#,##0");

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
                fSqlParams = null;
                dt = null;
                row = null;
                cell = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void procMonitoringSecs1ToHsmsConverterData(
            FMonitoringSecs1ToHsmsConverterDataReceivedEventArgs args
            )
        {
            UltraGridRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            int index = 0;
            string converter = string.Empty;
            string upDown = string.Empty;
            string alarm = string.Empty;

            try
            {
                grdList.beginUpdate(false);

                // --

                converter = args.converter;
                
                // --
                
                if (args.fType == FMonitoringDataType.Update)
                {
                    // ***
                    // Insert or Update SECS1 To HSMS Converter
                    // ***
                    upDown = args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_UpDown, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_UpDown);
                    alarm = args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_Alarm, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_Alarm);

                    // --

                    cellValues = new object[] {
                        converter,
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_Description, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_Description),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_Type, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_Type),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_IpAddress, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_IpAddress),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_UpDown, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_UpDown),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_Secs1State, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_Secs1State),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_HsmsState, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_HsmsState),
                        // --
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_Secs1SessionId, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_Secs1SessionId),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_Secs1SerialPort, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_Secs1SerialPort),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_Secs1Baud, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_Secs1Baud),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_Secs1RBit, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_Secs1RBit),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_Secs1Interleave, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_Secs1Interleave),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_Secs1DuplicateError, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_Secs1DuplicateError),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_Secs1IgnoreSystemBytes, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_Secs1IgnoreSystemBytes),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_Secs1RetryLimit, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_Secs1RetryLimit),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_Secs1T1Timeout, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_Secs1T1Timeout),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_Secs1T2Timeout, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_Secs1T2Timeout),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_Secs1T3Timeout, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_Secs1T3Timeout),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_Secs1T4Timeout, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_Secs1T4Timeout),
                        // --
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_HsmsSessionId, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_HsmsSessionId),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_HsmsConnectMode, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_HsmsConnectMode),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_HsmsLocalIp, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_HsmsLocalIp),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_HsmsLocalPort, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_HsmsLocalPort),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_HsmsRemoteIp, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_HsmsRemoteIp),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_HsmsRemotePort, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_HsmsRemotePort),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_HsmsLinkTestPeriod, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_HsmsLinkTestPeriod),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_HsmsT3Timeout, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_HsmsT3Timeout),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_HsmsT5Timeout, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_HsmsT5Timeout),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_HsmsT6Timeout, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_HsmsT6Timeout),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_HsmsT7Timeout, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_HsmsT7Timeout),
                        args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_HsmsT8Timeout, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_HsmsT8Timeout)
                        };
                    index = grdList.appendOrUpdateDataRow(converter, cellValues).Index;
                    
                    // --
                    
                    row = grdList.Rows.GetRowWithListIndex(index);
                    
                    // --

                    cell = row.Cells["Converter"];
                    if (upDown == FUpDown.Down.ToString())
                    {
                        cell.Appearance.Image = grdList.ImageList.Images["Converter_Down"];
                    }
                    else if (alarm == FYesNo.Yes.ToString())
                    {
                        cell.Appearance.Image = grdList.ImageList.Images["Converter_Alarm"];
                    }
                    else
                    {
                        cell.Appearance.Image = grdList.ImageList.Images["Converter_Up"];
                    }

                    // --

                    cell = row.Cells["Up/Down"];
                    if (cell.Text == FUpDown.Down.ToString())
                    {
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Red;
                    }
                    else
                    {
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                        cell.Appearance.ForeColor = Color.Black;
                    }

                    cell = row.Cells["SECS1 State"];
                    if (cell.Text != FCommunicationState.Selected.ToString())
                    {
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Red;
                    }
                    else
                    {
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                        cell.Appearance.ForeColor = Color.Black;
                    }

                    cell = row.Cells["HSMS State"];
                    if (cell.Text != FCommunicationState.Selected.ToString())
                    {
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Red;
                    }
                    else
                    {
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                        cell.Appearance.ForeColor = Color.Black;
                    }
                }
                else
                {
                    // ***
                    // Delete SECS1 To HSMS Convereter
                    // ***
                    grdList.removeDataRow(converter);                    
                }

                // --

                grdList.endUpdate(false);

                // --

                lblTotal.Text = grdList.Rows.Count.ToString("#,##0");
            }
            catch (Exception ex)
            {
                grdList.endUpdate(false);
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                row = null;
                cell = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public void attachConverter(
            string converter
            )
        {
            try
            {                
                if (grdList.containsDataRow(converter))
                {
                    grdList.activateDataRow(converter);
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

        #region SECS1 To HSMS Convereter Popup Menu

        private void procMenuSecs1ToHsmsConverterStatus(
            )
        {
            FSecs1ToHsmsConverterStatus fSecs1ToHsmsConverterStatus = null;

            try
            {
                fSecs1ToHsmsConverterStatus = (FSecs1ToHsmsConverterStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FSecs1ToHsmsConverterStatus));
                if (fSecs1ToHsmsConverterStatus == null)
                {
                    fSecs1ToHsmsConverterStatus = new FSecs1ToHsmsConverterStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fSecs1ToHsmsConverterStatus);
                }
                fSecs1ToHsmsConverterStatus.activate();
                fSecs1ToHsmsConverterStatus.attach(grdList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecs1ToHsmsConverterStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSecs1ToHsmsConverterHistory(
            )
        {
            FSecs1ToHsmsConverterHistory fSecs1ToHsmsConverterHistory = null;

            try
            {
                fSecs1ToHsmsConverterHistory = (FSecs1ToHsmsConverterHistory)m_fAdmCore.fAdmContainer.getChild(typeof(FSecs1ToHsmsConverterHistory));
                if (fSecs1ToHsmsConverterHistory == null)
                {
                    fSecs1ToHsmsConverterHistory = new FSecs1ToHsmsConverterHistory(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fSecs1ToHsmsConverterHistory);
                }
                fSecs1ToHsmsConverterHistory.activate();
                fSecs1ToHsmsConverterHistory.attach(grdList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecs1ToHsmsConverterHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procMenuSecs1ToHsmsConverterLogList(
            )
        {
            FSecs1ToHsmsConverterLogList fSecs1ToHsmsConverterLogList = null;

            try
            {
                fSecs1ToHsmsConverterLogList = (FSecs1ToHsmsConverterLogList)m_fAdmCore.fAdmContainer.getChild(typeof(FSecs1ToHsmsConverterLogList));
                if (fSecs1ToHsmsConverterLogList == null)
                {
                    fSecs1ToHsmsConverterLogList = new FSecs1ToHsmsConverterLogList(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fSecs1ToHsmsConverterLogList);
                }
                fSecs1ToHsmsConverterLogList.activate();
                fSecs1ToHsmsConverterLogList.attach(grdList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecs1ToHsmsConverterLogList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procMenuSecs1ToHsmsConverterBackupLogList(
            )
        {
            FSecs1ToHsmsConverterBackupLogList fSecs1ToHsmsConverterBackupLogList = null;

            try
            {
                fSecs1ToHsmsConverterBackupLogList = (FSecs1ToHsmsConverterBackupLogList)m_fAdmCore.fAdmContainer.getChild(typeof(FSecs1ToHsmsConverterBackupLogList));
                if (fSecs1ToHsmsConverterBackupLogList == null)
                {
                    fSecs1ToHsmsConverterBackupLogList = new FSecs1ToHsmsConverterBackupLogList(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fSecs1ToHsmsConverterBackupLogList);
                }
                fSecs1ToHsmsConverterBackupLogList.activate();
                fSecs1ToHsmsConverterBackupLogList.attach(grdList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecs1ToHsmsConverterBackupLogList = null;
            }
        }

        #endregion

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region FSecs1ToHsmsConverterMonitor Form Event Handler

        private void FSecs1ToHsmsConverterMonitor_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfList();

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

        private void FSecs1ToHsmsConverterMonitor_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfList();

                // --

                // ***
                // FAdsCore Event Handler 설정
                // ***
                m_fAdmCore.MonitoringSecs1ToHsmsConverterDataReceived += new FMonitoringSecs1ToHsmsConverterDataReceivedEventHandler(m_fAdmCore_MonitoringSecs1ToHsmsConverterDataReceived);

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

        private void FSecs1ToHsmsConverterMonitor_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                // ***
                // FAdsCore Event Handler 설정
                // ***
                m_fAdmCore.MonitoringSecs1ToHsmsConverterDataReceived -= new FMonitoringSecs1ToHsmsConverterDataReceivedEventHandler(m_fAdmCore_MonitoringSecs1ToHsmsConverterDataReceived);

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

        //------------------------------------------------------------------------------------------------------------------------        

        private void FSecs1ToHsmsConverterMonitor_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    FCursor.waitCursor();
                    // --
                    refreshGridOfList();
                    // --
                    FCursor.defaultCursor();
                }
            }
            catch (Exception ex)
            {
                FCursor.defaultCursor();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
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
            Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuSecs1ToHsmsConverterStatus)
                {
                    procMenuSecs1ToHsmsConverterStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecs1ToHsmsConverterHistory)
                {
                    procMenuSecs1ToHsmsConverterHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecs1ToHsmsConverterLogList)
                {
                    procMenuSecs1ToHsmsConverterLogList();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecs1ToHsmsConverterBackupLogList)
                {
                    procMenuSecs1ToHsmsConverterBackupLogList();
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

        #region grdList Control Event Handler

        private void grdList_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            UltraGridRow r = null;
            
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Button != MouseButtons.Right || grdList.Rows.Count == 0)
                {
                    return;
                }

                // --

                r = (UltraGridRow)grdList.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).
                    GetContext(typeof(UltraGridRow));
                if (r != null)
                {
                    grdList.ActiveRow = grdList.Rows[r.Index];
                }

                // --

                mnuMenu.Tools[FMenuKey.MenuSecs1ToHsmsConverterStatus].SharedProps.Enabled = grdList.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverterStatus) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuSecs1ToHsmsConverterHistory].SharedProps.Enabled = grdList.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverterHistory) ? true : false;
                // --                
                mnuMenu.Tools[FMenuKey.MenuSecs1ToHsmsConverterLogList].SharedProps.Enabled = grdList.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverterLogList) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuSecs1ToHsmsConverterBackupLogList].SharedProps.Enabled = grdList.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverterBackupLogList) ? true : false;

                // --

                mnuMenu.ShowPopup(FMenuKey.MenuS2HCvtMonitorPopupMenu);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                r = null;
                // --
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdList_DoubleClickRow(
            object sender, 
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (grdList.ActiveRow == null || !FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverterHistory))
                {
                    return;
                }

                // --

                procMenuSecs1ToHsmsConverterHistory();
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

                refreshGridOfList();
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

        private void rstToolbar_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdList.searchGridRow(e.searchWord))
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

        #region m_fAdmCore Object Event Handler

        private void m_fAdmCore_MonitoringSecs1ToHsmsConverterDataReceived(
            object sender, 
            FMonitoringSecs1ToHsmsConverterDataReceivedEventArgs e
            )
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        procMonitoringSecs1ToHsmsConverterData(e);
                    }));
                }
                else
                {
                    procMonitoringSecs1ToHsmsConverterData(e);
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

    }   // Class end
}   // Namespace end
