/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FOpcTagSelector.cs
--  Creator         : hongmi.pak
--  Create Date     : 2020.07.09
--  Description     : Nexplant MC OPC Modeler OPC Tag Selector Form Class
--  History         : Created by hongmi.park at 2020.07.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaOpcDriver;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;

namespace Nexplant.MC.OpcModeler
{
    public partial class FOpcTagSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private string m_csvFileName = "";
        List<object[]> m_fSelectEventTagList = null;
        List<object[]> m_fSelectTagList = null;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOpcTagSelector()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcTagSelector(
            FOpmCore fOpmCore
            )
            : this()
        {
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
                    m_fSelectEventTagList = null;
                    m_fSelectTagList = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public List<object[]> fSelectEventTagList
        {
            get
            {
                try
                {
                    return m_fSelectEventTagList;
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

        public List<object[]> fSelectTagList
        {
            get
            {
                try
                {
                    return m_fSelectTagList;
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

        private void designOfOpcEventTagList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdOpcEventTags.dataSource;
                // --
                uds.Band.Columns.Add("Check", typeof(bool));
                uds.Band.Columns.Add("Tag Name");
                uds.Band.Columns.Add("Data Type");
                uds.Band.Columns.Add("Array", typeof(bool));
                uds.Band.Columns.Add("Always", typeof(bool));
                uds.Band.Columns.Add("Ignore", typeof(bool));
                uds.Band.Columns.Add("Format");
                uds.Band.Columns.Add("Description");

                // --
                
                grdOpcEventTags.DisplayLayout.Bands[0].Columns["Tag Name"].CellAppearance.Image = Properties.Resources.OpcEventItem_unlock;
                // --
                grdOpcEventTags.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "";
                grdOpcEventTags.DisplayLayout.Bands[0].Columns["Check"].Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor;
                grdOpcEventTags.DisplayLayout.Bands[0].Columns["Check"].Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection;
                grdOpcEventTags.DisplayLayout.Bands[0].Columns["Check"].Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;
                // --
                grdOpcEventTags.DisplayLayout.Bands[0].Columns["Check"].Width = 30;
                grdOpcEventTags.DisplayLayout.Bands[0].Columns["Tag Name"].Width = 100;
                grdOpcEventTags.DisplayLayout.Bands[0].Columns["Data Type"].Width = 100;
                grdOpcEventTags.DisplayLayout.Bands[0].Columns["Always"].Width = 63;
                grdOpcEventTags.DisplayLayout.Bands[0].Columns["Ignore"].Width = 63;
                grdOpcEventTags.DisplayLayout.Bands[0].Columns["Format"].Width = 80;
                grdOpcEventTags.DisplayLayout.Bands[0].Columns["Description"].Width = 50;
                // --
                grdOpcEventTags.DisplayLayout.Bands[0].Columns["Array"].CellDisplayStyle = CellDisplayStyle.FormattedText;
                // --
                grdOpcEventTags.DisplayLayout.Bands[0].Columns["Always"].Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor;
                grdOpcEventTags.DisplayLayout.Bands[0].Columns["Always"].Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection;
                grdOpcEventTags.DisplayLayout.Bands[0].Columns["Always"].Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;
                // --
                grdOpcEventTags.DisplayLayout.Bands[0].Columns["Ignore"].Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor;
                grdOpcEventTags.DisplayLayout.Bands[0].Columns["Ignore"].Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection;
                grdOpcEventTags.DisplayLayout.Bands[0].Columns["Ignore"].Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;
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

        private void designOfOpcTagList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdOpcTags.dataSource;
                // --
                uds.Band.Columns.Add("Check", typeof(bool));
                uds.Band.Columns.Add("Tag Name");
                uds.Band.Columns.Add("Data Type");
                uds.Band.Columns.Add("Array", typeof(bool));
                uds.Band.Columns.Add("Format");
                uds.Band.Columns.Add("Description");
                
                // --

                grdOpcTags.DisplayLayout.Bands[0].Columns["Tag Name"].CellAppearance.Image = Properties.Resources.OpcItem_unlock;
                // --
                grdOpcTags.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "";
                grdOpcTags.DisplayLayout.Bands[0].Columns["Check"].Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor;
                grdOpcTags.DisplayLayout.Bands[0].Columns["Check"].Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection;
                grdOpcTags.DisplayLayout.Bands[0].Columns["Check"].Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;
                // --
                grdOpcTags.DisplayLayout.Bands[0].Columns["Check"].Width = 30;
                grdOpcTags.DisplayLayout.Bands[0].Columns["Tag Name"].Width = 150;
                grdOpcTags.DisplayLayout.Bands[0].Columns["Data Type"].Width = 110;
                grdOpcTags.DisplayLayout.Bands[0].Columns["Format"].Width = 80;
                grdOpcTags.DisplayLayout.Bands[0].Columns["Description"].Width = 50;
                // --
                grdOpcTags.DisplayLayout.Bands[0].Columns["Array"].CellDisplayStyle = CellDisplayStyle.FormattedText;

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

        private void loadCsvFile(
            )
        {
            OpenFileDialog ofd = null;
            string key = string.Empty;


            try
            {
                ofd = new OpenFileDialog();
                ofd.Title = "Open CSV File";
                ofd.InitialDirectory = "";
                ofd.Multiselect = false;
                ofd.Filter = FConstants.CsvFileFilter;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    m_csvFileName = ofd.FileName;

                    grdOpcEventTags.removeAllDataRow();
                    grdOpcTags.removeAllDataRow();
                    
                    key = tabMain.ActiveTab.Key;

                    if (key == "Item")
                    {
                        key = "Event";

                        tabMain.ActiveTab.Visible = false;
                        tabMain.ActiveTab = tabMain.Tabs[key];
                        tabMain.ActiveTab.Visible = true;
                    }

                    refreshGridOfOpcEventTagList();

                    grdOpcEventTags.Visible = true;
                    grdOpcTags.Visible = false;
                    grdOpcEventTags.Focus();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                ofd = null;
            }
        }

        private void exportCsvFile(
            )
        {
            SaveFileDialog sfd = null;
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                sfd = new SaveFileDialog();
                sfd.Title = "Export CSV File";
                sfd.InitialDirectory = "";
                sfd.Filter = FConstants.CsvFileFilter;
                sfd.FileName = "Sample.csv";

                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                    sw = new StreamWriter(fs);

                    sw.WriteLine("Tag Name,Address,Data Type");
                    sw.WriteLine("Tag1,Tag1,Boolean");

                    sw.Close();
                    fs.Close();
                }
                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                sfd = null;
                fs = null;
                sw = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfOpcEventTagList(
            )
        {
            string[] splitHeader = null;
            string[] splitData = null;
            string[] indexData = null;
            char[] splitOption = { ',' };
            int index_tag = -1;
            int index_addr = -1;
            int index_type = -1;
            int index_desc = -1;
            int cnt_evn = 0;
            int cnt_itm = 0;
            bool check = false;
            bool alwaysEvent = false;
            bool ignoreFirst = false;
            bool isString = false;
            object[] cellEventValues = null;
            object[] cellValues = null;
            int i = 0;
            int select_n = 0;
            UltraDataRow dataRow_evn = null;
            UltraDataRow dataRow_itm = null;
            string activeDataRowKey_evn = string.Empty;
            string activeDataRowKey_itm = string.Empty;

            try
            {
                grdOpcEventTags.beginUpdate(false);
                grdOpcTags.beginUpdate(false);

                // --

                if (m_csvFileName == string.Empty)
                {
                    grdOpcEventTags.endUpdate(false);
                    grdOpcTags.endUpdate(false);
                    return;
                }

                // --

                StreamReader sr = new StreamReader(m_csvFileName, Encoding.Default);

                splitHeader = sr.ReadLine().Split(splitOption);
                if (splitHeader.Length < 3)
                {
                    FMessageBox.showError(FConstants.ApplicationName, "There are no more than three items.", m_fOpmCore.fWsmCore.fWsmContainer);

                    grdOpcEventTags.endUpdate(false);
                    grdOpcTags.endUpdate(false);

                    return;
                }

                // --

                for (i = 0; i < splitHeader.Length; i++)
                {
                    if (splitHeader[i] == "Tag Name")
                    {
                        index_tag = i;
                    }
                    else if (splitHeader[i] == "Address")
                    {
                        index_addr = i;
                    }
                    else if (splitHeader[i] == "Data Type")
                    {
                        index_type = i;
                    }
                    else if (splitHeader[i] == "Description")
                    {
                        index_desc = i;
                    }
                }

                if (
                    index_tag < 0 ||
                    index_addr < 0 ||
                    index_type < 0
                    )
                {
                    FMessageBox.showError(FConstants.ApplicationName, "There are no required items.", m_fOpmCore.fWsmCore.fWsmContainer);

                    grdOpcEventTags.endUpdate(false);
                    grdOpcTags.endUpdate(false);

                    return;
                }

                // --

                indexData = new string[splitHeader.Length];

                while (sr.Peek() >= 0)
                {
                    splitData = sr.ReadLine().Split(splitOption);

                    if (
                        splitData.Length == 0 ||
                        splitData[index_tag] == ""
                        )
                    {
                        continue;
                    }

                    for (i = 0; i < splitHeader.Length; i++)
                    {
                        indexData[i] = string.Empty;
                    }

                    select_n = 0;
                    for (i = 0; i < splitData.Length; i++)
                    {
                        if (select_n == splitHeader.Length)
                        {
                            break;
                        }

                        if (splitData[i].Length == 0)
                        {
                            indexData[select_n] = splitData[i];
                            select_n++;
                        }
                        else
                        {
                            if (isString)
                            {
                                indexData[select_n] += splitData[i];


                                if (splitData[i].Substring(splitData[i].Length - 1, 1) == "\"") // string 끝
                                {
                                    isString = false;

                                    select_n++;
                                }
                            }
                            else
                            {
                                if (splitData[i].Substring(0, 1) == "\"") // string 시작
                                {
                                    isString = true;

                                    indexData[select_n] = splitData[i];

                                    if (splitData[i].Substring(splitData[i].Length - 1, 1) == "\"")
                                    {
                                        isString = false;
                                        select_n++;
                                    }
                                }
                                else
                                {
                                    indexData[select_n] = splitData[i];
                                    select_n++;
                                }
                            }
                        }

                        
                    }

                    // 0:check  1:Tag Name  2:Data Type  3:IsArray  4:AlwaysEvent  5:IgnoreFirst  6:Format  7:Description  
                    cellEventValues = new object[]{
                                    check,
                                    indexData[index_tag].Replace('"',' ').Trim(),
                                    null,
                                    false,
                                    alwaysEvent,
                                    ignoreFirst,
                                    null,
                                    string.Empty
                                };
                    // 0:check  1:Tag Name  2:Data Type  3:IsArray  4:Format  5:Description  
                    cellValues = new object[]{
                                    check,
                                    indexData[index_tag].Replace('"',' ').Trim(),
                                    null,
                                    false,
                                    null,
                                    string.Empty
                                };

                    switch (indexData[index_type])
                    {
                        case "Boolean":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.Boolean;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.Boolean;
                                cellValues[FConstants.OtsDataType] = FTagFormat.Boolean;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.Boolean;
                            }
                            break;
                        case "String":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.String;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.Ascii;
                                cellValues[FConstants.OtsDataType] = FTagFormat.String;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.Ascii;
                            }
                            break;
                        case "Long":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.Long;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.I4;
                                cellValues[FConstants.OtsDataType] = FTagFormat.Long;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.I4;
                            }
                            break;
                        case "Short":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.Short;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.I2;
                                cellValues[FConstants.OtsDataType] = FTagFormat.Short;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.I2;
                            }
                            break;
                        case "Double":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.Double;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.F8;
                                cellValues[FConstants.OtsDataType] = FTagFormat.Double;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.F8;
                            }
                            break;
                        case "Float":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.Float;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.F4;
                                cellValues[FConstants.OtsDataType] = FTagFormat.Float;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.F4;
                            }
                            break;
                        case "Byte":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.Byte;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.U1;
                                cellValues[FConstants.OtsDataType] = FTagFormat.Byte;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.U1;
                            }
                            break;
                        case "Word":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.Word;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.U2;
                                cellValues[FConstants.OtsDataType] = FTagFormat.Word;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.U2;
                            }
                            break;
                        case "Dword":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.DWord;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.U4;
                                cellValues[FConstants.OtsDataType] = FTagFormat.DWord;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.U4;
                            }
                            break;
                        case "Char":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.Char;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.Ascii;
                                cellValues[FConstants.OtsDataType] = FTagFormat.Char;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.Ascii;
                            }
                            break;
                        case "BCD":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.BCD;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.U2;
                                cellValues[FConstants.OtsDataType] = FTagFormat.BCD;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.U2;
                            }
                            break;
                        case "LBCD":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.LBCD;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.U4;
                                cellValues[FConstants.OtsDataType] = FTagFormat.LBCD;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.U4;
                            }
                            break;
                        case "Date":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.Date;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.Ascii;
                                cellValues[FConstants.OtsDataType] = FTagFormat.Date;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.Ascii;
                            }
                            break;
                        case "String Array":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.String;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.Ascii;
                                cellEventValues[FConstants.OtsEArray] = true;
                                cellValues[FConstants.OtsDataType] = FTagFormat.String;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.Ascii;
                                cellValues[FConstants.OtsArray] = true;
                            }
                            break;
                        case "Boolean Array":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.Boolean;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.Boolean;
                                cellEventValues[FConstants.OtsEArray] = true;
                                cellValues[FConstants.OtsDataType] = FTagFormat.Boolean;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.Boolean;
                                cellValues[FConstants.OtsArray] = true;
                            }
                            break;
                        case "Char Array":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.Char;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.Ascii;
                                cellEventValues[FConstants.OtsEArray] = true;
                                cellValues[FConstants.OtsDataType] = FTagFormat.Char;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.Ascii;
                                cellValues[FConstants.OtsArray] = true;
                            }
                            break;
                        case "Byte Array":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.Byte;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.U1;
                                cellEventValues[FConstants.OtsEArray] = true;
                                cellValues[FConstants.OtsDataType] = FTagFormat.Byte;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.U1;
                                cellValues[FConstants.OtsArray] = true;
                            }
                            break;
                        case "Short Array":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.Short;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.I2;
                                cellEventValues[FConstants.OtsEArray] = true;
                                cellValues[FConstants.OtsDataType] = FTagFormat.Short;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.I2;
                                cellValues[FConstants.OtsArray] = true;
                            }
                            break;
                        case "Word Array":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.Word;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.U2;
                                cellEventValues[FConstants.OtsEArray] = true;
                                cellValues[FConstants.OtsDataType] = FTagFormat.Word;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.U2;
                                cellValues[FConstants.OtsArray] = true;
                            }
                            break;
                        case "Long Array":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.Long;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.I4;
                                cellEventValues[FConstants.OtsEArray] = true;
                                cellValues[FConstants.OtsDataType] = FTagFormat.Long;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.I4;
                                cellValues[FConstants.OtsArray] = true;
                            }
                            break;
                        case "DWord Array":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.DWord;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.U4;
                                cellEventValues[FConstants.OtsEArray] = true;
                                cellValues[FConstants.OtsDataType] = FTagFormat.DWord;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.U4;
                                cellValues[FConstants.OtsArray] = true;
                            }
                            break;
                        case "Float Array":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.Float;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.I4;
                                cellEventValues[FConstants.OtsEArray] = true;
                                cellValues[FConstants.OtsDataType] = FTagFormat.Float;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.I4;
                                cellValues[FConstants.OtsArray] = true;
                            }
                            break;
                        case "Double Array":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.Double;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.I8;
                                cellEventValues[FConstants.OtsEArray] = true;
                                cellValues[FConstants.OtsDataType] = FTagFormat.Double;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.I8;
                                cellValues[FConstants.OtsArray] = true;
                            }
                            break;
                        case "BCD Array":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.BCD;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.U2;
                                cellEventValues[FConstants.OtsEArray] = true;
                                cellValues[FConstants.OtsDataType] = FTagFormat.BCD;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.U2;
                                cellValues[FConstants.OtsArray] = true;
                            }
                            break;
                        case "LBCD Array":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.LBCD;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.U4;
                                cellEventValues[FConstants.OtsEArray] = true;
                                cellValues[FConstants.OtsDataType] = FTagFormat.LBCD;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.U4;
                                cellValues[FConstants.OtsArray] = true;
                            }
                            break;
                        case "Date Array":
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.String;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.Ascii;
                                cellEventValues[FConstants.OtsEArray] = true;
                                cellValues[FConstants.OtsDataType] = FTagFormat.String;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.Ascii;
                                cellValues[FConstants.OtsArray] = true;
                            }
                            break;
                        default:
                            {
                                cellEventValues[FConstants.OtsEDataType] = FTagFormat.String;
                                cellEventValues[FConstants.OtsEFormat] = FOpcFormat.Ascii;
                                cellValues[FConstants.OtsDataType] = FTagFormat.String;
                                cellValues[FConstants.OtsFormat] = FOpcFormat.Ascii;
                            }
                            break;
                    } //    switch end

                    if (index_desc >= 0)
                    {
                        cellEventValues[FConstants.OtsEDescription] = indexData[index_desc].Replace('"', ' ').Trim();
                        cellValues[FConstants.OtsDescription] = indexData[index_desc].Replace('"', ' ').Trim();
                    }

                    dataRow_evn = grdOpcEventTags.appendDataRow(cnt_evn++.ToString(), cellEventValues);
                    dataRow_evn.Tag = cellEventValues;

                    dataRow_itm = grdOpcTags.appendDataRow(cnt_itm++.ToString(), cellValues);
                    dataRow_itm.Tag = cellValues;
                }

                // --

                grdOpcEventTags.endUpdate(false);
                grdOpcTags.endUpdate(false);

                // --

                if (grdOpcEventTags.Rows.Count > 0)
                {
                    if (activeDataRowKey_evn == string.Empty)
                    {
                        grdOpcEventTags.ActiveRow = grdOpcEventTags.Rows[0];
                    }
                    else
                    {
                        grdOpcEventTags.activateDataRow(activeDataRowKey_evn);
                    }
                }

                if (grdOpcTags.Rows.Count > 0)
                {
                    if (activeDataRowKey_itm == string.Empty)
                    {
                        grdOpcTags.ActiveRow = grdOpcTags.Rows[0];
                    }
                    else
                    {
                        grdOpcTags.activateDataRow(activeDataRowKey_itm);
                    }
                }

            }
            catch (Exception ex)
            {
                grdOpcEventTags.endUpdate(false);
                grdOpcTags.endUpdate(false);

                // --

                FDebug.throwException(ex);
            }
            finally
            {
                splitHeader = null;
                splitData = null;
                dataRow_evn = null;
                dataRow_itm = null;
                cellEventValues = null;
                cellValues = null;
                indexData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procPreviousStep(
                )
        {
            string key = string.Empty;

            try
            {
                key = tabMain.ActiveTab.Key;

                // --

                if (key == "Event")
                {

                }
                else if (key == "Item")
                {
                    key = "Event";

                    // --

                    btnPrevious.Enabled = false;
                    btnNext.Enabled = true;
                    btnOk.Enabled = false;
                    // --
                    grdOpcEventTags.Visible = true;
                    grdOpcTags.Visible = false;
                    grdOpcEventTags.Focus();
                }

                // --

                tabMain.ActiveTab.Visible = false;
                tabMain.ActiveTab = tabMain.Tabs[key];
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

        private void procNextStep(
            )
        {
            string key = string.Empty;

            try
            {
                key = tabMain.ActiveTab.Key;

                // --

                if (key == "Event")
                {
                    key = "Item";

                    // --

                    btnPrevious.Enabled = true;
                    btnNext.Enabled = false;
                    btnOk.Enabled = true;
                    // --
                    grdOpcEventTags.Visible = false;
                    grdOpcTags.Visible = true;
                    grdOpcTags.Focus();
                }
                else if (key == "Item")
                {

                }

                // --

                tabMain.ActiveTab.Visible = false;
                tabMain.ActiveTab = tabMain.Tabs[key];
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

        private void createOpcMsgOfSelectTag(
            )
        {
            object[] obj = null;

            try
            {
                m_fSelectEventTagList = new List<object[]>();
                foreach (UltraDataRow uEventRow in grdOpcEventTags.dataSource.Rows)
                {
                    if (uEventRow.GetCellValue(0).ToString() == "True")
                    {
                        obj = (object[])uEventRow.Tag;
                        obj[FConstants.OtsEAlwaysEvent] = uEventRow.GetCellValue(FConstants.OtsEAlwaysEvent);
                        obj[FConstants.OtsEIgnoreFirst] = uEventRow.GetCellValue(FConstants.OtsEIgnoreFirst);
                        m_fSelectEventTagList.Add(obj);
                    }
                }

                // --

                m_fSelectTagList = new List<object[]>();
                foreach (UltraDataRow uDataRow in grdOpcTags.dataSource.Rows)
                {
                    if (uDataRow.GetCellValue(0).ToString() == "True")
                    {
                        obj = (object[])uDataRow.Tag;
                        m_fSelectTagList.Add(obj);
                    }
                }

                // --

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                obj = null;

            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnPrevious Control Event Handler

        private void btnPrevious_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procPreviousStep();
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

        #region btnNext Control Event Handler

        private void btnNext_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procNextStep();
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

        #region btnOk Control Event Handler

        private void btnOk_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                createOpcMsgOfSelectTag();

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

        #region btnCancel Control Event Handler

        private void btnCancel_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
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

        #region FOpcTagSelector Form Event Handler

        private void FOpcTagSelector_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designOfOpcEventTagList();
                designOfOpcTagList();

                // --

                grdOpcEventTags.Visible = true;
                grdOpcTags.Visible = false;

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

        private void FOpcTagSelector_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                //refreshGridOfOpcEventTagList();

                // --
                
                if (grdOpcEventTags.activeDataRow != null)
                {
                    btnNext.Enabled = true;
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

        #region grdOpcEventTags Control Event Handler

        private void grdOpcEventTags_ClickCell(
            object sender,
            ClickCellEventArgs e
            )
        {
            try
            {
                if (
                    e.Cell.Column.ToString() != "Check" && 
                    e.Cell.Column.ToString() != "Always" && 
                    e.Cell.Column.ToString() != "Ignore"
                    )
                {
                    return;
                }

                // --

                if (e.Cell.Row.Cells[e.Cell.Column].Value.ToString() == "False")
                {
                    e.Cell.Row.Cells[e.Cell.Column].SetValue("True", false);
                    // --
                    if (
                        e.Cell.Column.ToString() == "Always" ||
                        e.Cell.Column.ToString() == "Ignore"
                        )
                    {
                        e.Cell.Row.Cells["Check"].SetValue("True", false);
                    }
                }
                else
                {
                    if (e.Cell.Column.ToString() == "Check")
                    {
                        e.Cell.Row.Cells["Always"].SetValue("False", false);
                        e.Cell.Row.Cells["Ignore"].SetValue("False", false);
                        e.Cell.Row.Cells[e.Cell.Column].SetValue("False", false);
                    }
                    else
                    {
                        e.Cell.Row.Cells[e.Cell.Column].SetValue("False", false);
                    }
                }

                grdOpcEventTags.Refresh();
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

        #region grdOpcTags Control Event Handler

        private void grdOpcTags_ClickCell(
            object sender,
            ClickCellEventArgs e
            )
        {
            try
            {
                if (e.Cell.Row.Cells[0].Value.ToString() == "False")
                {
                    e.Cell.Row.Cells[0].SetValue("True", false);
                }
                else
                {
                    e.Cell.Row.Cells[0].SetValue("False", false);
                }

                // --
                
                grdOpcTags.Refresh();
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

        #region tabMain Control Event Handler

        private void tabMain_ActiveTabChanging(
            object sender, 
            Infragistics.Win.UltraWinTabControl.ActiveTabChangingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                e.Tab.Visible = true;
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

                if (e.Tool.Key == FMenuKey.MenuOtsOpen)
                {
                    loadCsvFile();

                    btnPrevious.Enabled = false;
                    btnOk.Enabled = false;

                    if (grdOpcEventTags.activeDataRow != null)
                    {
                        btnNext.Enabled = true;
                    }
                    else
                    {
                        btnNext.Enabled = false;
                    }
                }
                else if (e.Tool.Key == FMenuKey.MenuOtsExportSample)
                {
                    exportCsvFile();
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

    }   // Class end
}   // Namespace end
