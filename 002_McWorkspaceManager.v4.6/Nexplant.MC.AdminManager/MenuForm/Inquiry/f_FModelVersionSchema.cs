/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FModelVersionSchema.cs
--  Creator         : mjkim
--  Create Date     : 2012.04.20
--  Description     : FAMate Admin Manager View Model Version Schema Form Class 
--  History         : Created by mjkim at 2012.04.20
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FModelVersionSchema : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------
        
        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string m_lastSelectedSchema = string.Empty;
        private string m_lastSelectedEnv = string.Empty;
 
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FModelVersionSchema(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FModelVersionSchema(
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

        protected override void changeControlFontName(
            )
        {
            try
            {
                base.changeControlFontName();
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

        public static int getLength(
            FFormat fFormat,
            string value
            )
        {

            try
            {
                if (value == string.Empty)
                {
                    return 0;
                }

                // --

                if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                {
                    return System.Text.Encoding.Default.GetByteCount(value);
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private string getSchemaObjectText(
            FXmlNode fXmlNode
            )
        {
            string info = string.Empty;
            FFormat fFormat;
            string length = string.Empty;
            string value = string.Empty;
            string name = string.Empty;
            string desc = string.Empty;

            try
            {
                if (fXmlNode.name == FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.E_SecsDriver)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.A_Name,
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.A_Description,
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.D_Description
                        ).Trim();
                    // --
                    info = name;
                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }
                else if (fXmlNode.name == FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.E_SecsDevice)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Name,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Description,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Description
                        ).Trim();
                    // --
                    info = name;
                    // --
                    info += " Protocol=[";
                    info += fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Protocol,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Protocol
                        ).Trim();
                    info += "]";
                    // --

                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }
                else if (fXmlNode.name == FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.E_SecsSession)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_Name,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_Description,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_Description
                        ).Trim();
                    // --
                    info = name;
                    // --
                    info += " SessionID=[";
                    info += fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_SessionId,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_SessionId
                        ).Trim();
                    info += "]";
                    // --
                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }
                else if (fXmlNode.name == FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.E_HostDevice)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Name,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Description,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Description
                        ).Trim();
                    // --
                    info = name;
                    // --
                    info += " Driver=[";
                    info += fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Driver,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Driver
                        ).Trim();
                    info += "]";
                    // --

                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }
                else if (fXmlNode.name == FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.E_HostSession)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.A_Name,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.A_Description,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.D_Description
                        ).Trim();
                    // --
                    info = name;
                    // --
                    info += " MachineID=[";
                    info += fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.A_MachineId,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.D_MachineId
                        ).Trim();
                    info += "]";
                    // --
                    info += " SessionID=[";
                    info += fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.A_SessionId,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.D_SessionId
                        ).Trim();
                    info += "]";
                    // --
                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }
                else if (fXmlNode.name == FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.E_Equipment)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.A_Name,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.A_Description,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.D_Description
                        ).Trim();
                    // --                    
                    info += name;
                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }
                else if (fXmlNode.name == FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.E_EnvironmentList)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.A_Name,
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.A_Description,
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.D_Description
                        ).Trim();
                    // --
                    info = name;
                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }
                else if (fXmlNode.name == FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.E_Environment)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Name,
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Description,
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Description
                        ).Trim();
                    fFormat = (FFormat)Enum.Parse(
                        typeof(FFormat), 
                        fXmlNode.get_elemVal(FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Format, FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Format)
                        );
                    length = fXmlNode.get_elemVal(
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Length,
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Length
                        ).Trim();
                    value = fXmlNode.get_elemVal(
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Value,
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Value
                        ).Trim();
                    
                    // --

                    info = ((FFormatShortName)fFormat).ToString() + "[" + length + "]";
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        info += " " + name;
                    }
                    else
                    {
                        info += " " + name + "=\"" + value + "\"";
                    }
                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }

                // --

                return info;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------   

        private Image getImageOfEapDriver(
           FTreeView tvwTree,
           FXmlNode fXmlNode
           )
        {
            string type = string.Empty;

            try
            {
                if (fXmlNode.name == FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.E_SecsDriver)
                {
                    type = fXmlNode.get_elemVal(
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.A_ModelType,
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.D_ModelType
                        );
                    // --
                    if (type == FModelType.SECS.ToString())
                    {
                        return tvwTree.ImageList.Images["SecsDriver"];
                    }
                    //else if (type == FModelType.PLC.ToString())
                    //{
                    //    return tvwTree.ImageList.Images["PlcDriver"];
                    //}
                    else if (type == FModelType.OPC.ToString())
                    {
                        return tvwTree.ImageList.Images["OpcDriver"];
                    }
                    else if (type == FModelType.TCP.ToString())
                    {
                        return tvwTree.ImageList.Images["TcpDriver"];
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
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private Image getImageOfModelSchemaEapDevice(
            FTreeView tvwTree,
            FXmlNode fXmlNode
            )
        {
            string type = string.Empty;

            try
            {
                if (fXmlNode.name == FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.E_SecsDevice)
                {
                    type = fXmlNode.get_elemVal(
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_ModelType,
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_ModelType
                        );
                    // --
                    if (type == FModelType.SECS.ToString())
                    {
                        return tvwTree.ImageList.Images["SecsDevice"];
                    }
                    //else if (type == FModelType.PLC.ToString())
                    //{
                    //    return tvwTree.ImageList.Images["PlcDevice"];
                    //}
                    else if (type == FModelType.OPC.ToString())
                    {
                        return tvwTree.ImageList.Images["OpcDevice"];
                    }
                    else if (type == FModelType.TCP.ToString())
                    {
                        return tvwTree.ImageList.Images["TcpDevice"];
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
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private Image getImageOfModelSchemaEapSession(
            FTreeView tvwTree,
            FXmlNode fXmlNode
            )
        {
            string type = string.Empty;

            try
            {
                if (fXmlNode.name == FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.E_SecsSession)
                {
                    type = fXmlNode.get_elemVal(
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_ModelType,
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_ModelType
                        );
                    // --
                    if (type == FModelType.SECS.ToString())
                    {
                        return tvwTree.ImageList.Images["SecsSession"];
                    }
                    //else if (type == FModelType.PLC.ToString())
                    //{
                    //    return tvwTree.ImageList.Images["PlcSession"];
                    //}
                    else if (type == FModelType.OPC.ToString())
                    {
                        return tvwTree.ImageList.Images["OpcSession"];
                    }
                    else if (type == FModelType.TCP.ToString())
                    {
                        return tvwTree.ImageList.Images["TcpSession"];
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
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------   

        private Image getImageOfEnvironment(
            FXmlNode fXmlNode
            )
        {
            FFormat fFormat;

            try
            {
                fFormat = (FFormat)Enum.Parse(typeof(FFormat), fXmlNode.get_elemVal(
                   FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Format,
                   FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Format
                   ));
                // --
                if (fFormat == FFormat.List)
                {
                    return tvwEnv.ImageList.Images["Environment_List"];
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return tvwEnv.ImageList.Images["Environment"];
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void clearModelDetail(
            )
        {
            try
            {
                // ***
                // EAP Schema Clear
                // ***
                tvwSchema.beginUpdate();
                tvwSchema.Nodes.Clear();
                tvwSchema.endUpdate();
                // --
                pgdSchema.selectedObject = null;

                // --

                // ***
                // EAP Environment Clear
                // ***
                tvwEnv.beginUpdate();
                tvwEnv.Nodes.Clear();
                tvwEnv.endUpdate();
                // --
                pgdEnv.selectedObject = null;
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

        private void clear(
            )
        {
            try
            {
                // ***
                // EAP List Clear
                // ***
                grdList.beginUpdate();
                grdList.removeAllDataRow();
                grdList.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdList.endUpdate();

                // --

                refreshVersionTotal();

                // --

                // ***
                // Model Detail Information Clear
                // ***
                clearModelDetail();
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void designGridOfVersion(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;

                // --

                uds.Band.Columns.Add("Version");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("File");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Version"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
                grdList.DisplayLayout.Bands[0].Columns["File"].Width = 180;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Version"].Header.Fixed = true;

                // --

                grdList.ImageList = new ImageList();
                // --
                grdList.ImageList.Images.Add("ModelVersion_Secs", Properties.Resources.ModelVersion_Secs);
                grdList.ImageList.Images.Add("ModelVersion_Plc", Properties.Resources.ModelVersion_Plc);
                grdList.ImageList.Images.Add("ModelVersion_Opc", Properties.Resources.ModelVersion_Opc);
                grdList.ImageList.Images.Add("ModelVersion_Tcp", Properties.Resources.ModelVersion_Tcp);
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

        private void designTreeOfSchema(
            )
        {
            try
            {
                tvwSchema.ImageList = new ImageList();
                // --
                tvwSchema.ImageList.Images.Add("SecsDriver", Properties.Resources.SecsDriver);
                tvwSchema.ImageList.Images.Add("SecsDevice", Properties.Resources.SecsDevice);
                tvwSchema.ImageList.Images.Add("SecsSession", Properties.Resources.SecsSession);
                tvwSchema.ImageList.Images.Add("PlcDriver", Properties.Resources.PlcDriver);
                tvwSchema.ImageList.Images.Add("PlcDevice", Properties.Resources.PlcDevice);
                tvwSchema.ImageList.Images.Add("PlcSession", Properties.Resources.PlcSession);
                tvwSchema.ImageList.Images.Add("OpcDriver", Properties.Resources.OpcDriver);
                tvwSchema.ImageList.Images.Add("OpcDevice", Properties.Resources.OpcDevice);
                tvwSchema.ImageList.Images.Add("OpcSession", Properties.Resources.OpcSession);
                tvwSchema.ImageList.Images.Add("TcpDriver", Properties.Resources.TcpDriver);
                tvwSchema.ImageList.Images.Add("TcpDevice", Properties.Resources.TcpDevice);
                tvwSchema.ImageList.Images.Add("TcpSession", Properties.Resources.TcpSession);
                tvwSchema.ImageList.Images.Add("HostDevice", Properties.Resources.HostDevice);
                tvwSchema.ImageList.Images.Add("HostSession", Properties.Resources.HostSession);
                tvwSchema.ImageList.Images.Add("Equipment", Properties.Resources.Equipment);
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

        private void designTreeOfEnvironment(
            )
        {
            try
            {
                tvwEnv.ImageList = new ImageList();
                // --
                tvwEnv.ImageList.Images.Add("SecsDriver", Properties.Resources.SecsDriver);
                tvwEnv.ImageList.Images.Add("PlcDriver", Properties.Resources.PlcDriver);
                tvwEnv.ImageList.Images.Add("OpcDriver", Properties.Resources.OpcDriver);
                tvwEnv.ImageList.Images.Add("TcpDriver", Properties.Resources.TcpDriver);
                tvwEnv.ImageList.Images.Add("Equipment", Properties.Resources.Equipment);
                tvwEnv.ImageList.Images.Add("EnvironmentList", Properties.Resources.EnvironmentList);
                tvwEnv.ImageList.Images.Add("Environment", Properties.Resources.Environment);
                tvwEnv.ImageList.Images.Add("Environment_List", Properties.Resources.Environment_List);
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

        private void refreshGridOfVersion(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string beforeKey = string.Empty;
            string key = string.Empty;
            int nextRowNumber = 0;
            string modelVer = string.Empty;
            int index = 0;

            try
            {
                clearModelDetail();

                // --

                beforeKey = grdList.activeDataRowKey;
                // --
                grdList.beginUpdate(false);
                grdList.removeAllDataRow();
                grdList.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                if (txtModel.Text == string.Empty)
                {
                    grdList.endUpdate(false);
                    txtModel.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { "Model" }));
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("model", txtModel.Text);
                // --   
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ModelVerSchema", "ListModelVer", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            string.Format("{0}{1}", r[0], ((FYesNo)Enum.Parse(typeof(FYesNo), r[3].ToString()) == FYesNo.Yes ? "*" : string.Empty)), // Version
                            r[1],   // Description
                            r[2]    // Model File
                            };
                        key = (string)r[0];
                        index = grdList.appendDataRow(key, cellValues).Index;
                        // --
                        grdList.Rows.GetRowWithListIndex(index).Cells[0].Appearance.Image = FCommon.getImageOfModelVersion(grdList, (string)txtModel.Tag);
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

                refreshVersionTotal();

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
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshModelSchema(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSch = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutScd = null;
            string modelVer = string.Empty;

            try
            {
                if (grdList.activeDataRow == null)
                {
                    return;
                }

                // --

                modelVer = grdList.activeDataRowKey;
                modelVer = modelVer.Contains("*") ? modelVer.Substring(0, modelVer.IndexOf("*", 0)) : modelVer;

                // --

                // ***
                // Model Schema Request
                // ***
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_InqModelVerSchemaSearch_In.E_ADMADS_InqModelVerSchemaSearch_In);
                fXmlNodeIn.set_elemVal(FADMADS_InqModelVerSchemaSearch_In.A_hLanguage, FADMADS_InqModelVerSchemaSearch_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_InqModelVerSchemaSearch_In.A_hFactory, FADMADS_InqModelVerSchemaSearch_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_InqModelVerSchemaSearch_In.A_hUserId, FADMADS_InqModelVerSchemaSearch_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_InqModelVerSchemaSearch_In.A_hStep, FADMADS_InqModelVerSchemaSearch_In.D_hStep, "1");
                // --
                fXmlNodeInSch = fXmlNodeIn.set_elem(FADMADS_InqModelVerSchemaSearch_In.FSchema.E_Schema);
                fXmlNodeInSch.set_elemVal(
                    FADMADS_InqModelVerSchemaSearch_In.FSchema.A_Model,
                    FADMADS_InqModelVerSchemaSearch_In.FSchema.D_Model,
                    txtModel.Text
                    );
                fXmlNodeInSch.set_elemVal(
                    FADMADS_InqModelVerSchemaSearch_In.FSchema.A_Version,
                    FADMADS_InqModelVerSchemaSearch_In.FSchema.A_Version,
                    modelVer
                    );

                // --

                FADMADSCaster.ADMADS_InqModelVerSchemaSearch_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_InqModelVerSchemaSearch_Out.A_hStatus, FADMADS_InqModelVerSchemaSearch_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_InqModelVerSchemaSearch_Out.A_hStatusMessage, FADMADS_InqModelVerSchemaSearch_Out.D_hStatusMessage)
                        );
                }

                // --

                fXmlNodeOutScd = fXmlNodeOut.get_elem(FADMADS_InqModelVerSchemaSearch_Out.FSchema.E_Schema).get_elem(FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.E_SecsDriver);

                // --

                refreshTreeOfModelSchema(fXmlNodeOutScd);
                refreshTreeOfModelEnvironment(fXmlNodeOutScd);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInSch = null;
                fXmlNodeOut = null;
                fXmlNodeOutScd = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshTreeOfModelSchema(
            FXmlNode fXmlNodeScd
            )
        {
            UltraTreeNode tNodeScd = null;
            UltraTreeNode tNodeSdv = null;
            UltraTreeNode tNodeSsn = null;
            UltraTreeNode tNodeHdv = null;
            UltraTreeNode tNodeHsn = null;
            UltraTreeNode tNodeEqp = null;
            int keyIndex = 0;

            try
            {
                tvwSchema.beginUpdate();
                tvwSchema.Nodes.Clear();
                pgdSchema.selectedObject = null;
                // --
                if (fXmlNodeScd == null)
                {
                    tvwSchema.endUpdate();
                    return;
                }

                // --

                // ***
                // SECS Driver Load
                // ***
                tNodeScd = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeScd));
                tNodeScd.Override.NodeAppearance.Image = getImageOfEapDriver(tvwSchema, fXmlNodeScd);
                tNodeScd.Tag = fXmlNodeScd;
                keyIndex++;

                // --

                // ***
                // SECS Device Load
                // ***
                foreach (FXmlNode fXmlNodeSdv in fXmlNodeScd.get_elemList(FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.E_SecsDevice))
                {
                    tNodeSdv = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeSdv));
                    tNodeSdv.Override.NodeAppearance.Image = getImageOfModelSchemaEapDevice(tvwSchema, fXmlNodeSdv);
                    tNodeSdv.Tag = fXmlNodeSdv;
                    keyIndex++;

                    // --

                    // ***
                    // SECS Session Load
                    // ***
                    foreach (FXmlNode fXmlNodeSsn in fXmlNodeSdv.get_elemList(FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.E_SecsSession))
                    {
                        tNodeSsn = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeSsn));
                        tNodeSsn.Override.NodeAppearance.Image = getImageOfModelSchemaEapSession(tvwSchema, fXmlNodeSsn);
                        tNodeSsn.Tag = fXmlNodeSsn;
                        keyIndex++;
                        // --
                        tNodeSdv.Nodes.Add(tNodeSsn);
                    }

                    // --

                    tNodeScd.Nodes.Add(tNodeSdv);
                }

                // --

                // ***
                // Host Device Load
                // ***
                foreach (FXmlNode fXmlNodeHdv in fXmlNodeScd.get_elemList(FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.E_HostDevice))
                {
                    tNodeHdv = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeHdv));
                    tNodeHdv.Override.NodeAppearance.Image = tvwSchema.ImageList.Images["HostDevice"];
                    tNodeHdv.Tag = fXmlNodeHdv;
                    keyIndex++;

                    // --

                    // ***
                    // Host Session Load
                    // *** 
                    foreach (FXmlNode fXmlNodeHsn in fXmlNodeHdv.get_elemList(FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.E_HostSession))
                    {
                        tNodeHsn = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeHsn));
                        tNodeHsn.Override.NodeAppearance.Image = tvwSchema.ImageList.Images["HostSession"];
                        tNodeHsn.Tag = fXmlNodeHsn;
                        keyIndex++;
                        // --
                        tNodeHdv.Nodes.Add(tNodeHsn);
                    }

                    // --

                    tNodeScd.Nodes.Add(tNodeHdv);
                }

                // --

                // ***
                // Equipment Load
                // ***
                foreach (FXmlNode fXmlNodeEqp in fXmlNodeScd.get_elemList(FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.E_Equipment))
                {
                    tNodeEqp = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeEqp));
                    tNodeEqp.Override.NodeAppearance.Image = tvwSchema.ImageList.Images["Equipment"];
                    tNodeEqp.Tag = fXmlNodeEqp;
                    keyIndex++;
                    // --
                    tNodeScd.Nodes.Add(tNodeEqp);
                }

                // --

                tNodeScd.Expanded = true;
                tvwSchema.Nodes.Add(tNodeScd);
                tvwSchema.endUpdate();

                // --

                if (tvwSchema.Nodes.Count > 0)
                {
                    if (m_lastSelectedSchema != string.Empty)
                    {
                        tvwSchema.ActiveNode = tvwSchema.GetNodeByKey(m_lastSelectedSchema);
                    }
                    if (m_lastSelectedSchema == string.Empty || tvwSchema.ActiveNode == null)
                    {
                        tvwSchema.ActiveNode = tvwSchema.Nodes[0];
                    }
                }
            }
            catch (Exception ex)
            {
                tvwSchema.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeScd = null;
                tNodeSdv = null;
                tNodeSsn = null;
                tNodeHdv = null;
                tNodeHsn = null;
                tNodeEqp = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshTreeOfModelEnvironment(
            FXmlNode fXmlNodeScd
            )
        {
            UltraTreeNode tNodeScd = null;
            UltraTreeNode tNodeEnl = null;
            UltraTreeNode tNodeEnv = null;
            int keyIndex = 0;

            try
            {
                tvwEnv.beginUpdate();
                tvwEnv.Nodes.Clear();
                pgdEnv.selectedObject = null;
                // --
                if (fXmlNodeScd == null)
                {
                    tvwEnv.endUpdate();
                    return;
                }

                // --

                // ***
                // SECS Driver Load
                // ***
                tNodeScd = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeScd));
                tNodeScd.Override.NodeAppearance.Image = getImageOfEapDriver(tvwEnv, fXmlNodeScd);
                tNodeScd.Tag = fXmlNodeScd;
                keyIndex++;
                
                // --

                // ***
                // Environment List Load
                // ***
                foreach (FXmlNode fXmlNodeEnl in fXmlNodeScd.get_elemList(FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.E_EnvironmentList))
                {
                    tNodeEnl = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeEnl));
                    tNodeEnl.Override.NodeAppearance.Image = tvwEnv.ImageList.Images["EnvironmentList"];
                    tNodeEnl.Tag = fXmlNodeEnl;
                    keyIndex++;

                    // --

                    // ***
                    // Environment Load
                    // *** 
                    foreach (FXmlNode fXmlNodeEnv in fXmlNodeEnl.get_elemList(FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.E_Environment))
                    {
                        tNodeEnv = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeEnv));
                        tNodeEnv.Override.NodeAppearance.Image = getImageOfEnvironment(fXmlNodeEnv);
                        tNodeEnv.Tag = fXmlNodeEnv;
                        keyIndex++;
                        // --
                        tNodeEnl.Nodes.Add(tNodeEnv);
                    }

                    // --

                    tNodeScd.Nodes.Add(tNodeEnl);
                }

                // --

                tNodeScd.Expanded = true;
                tvwEnv.Nodes.Add(tNodeScd);
                tvwEnv.endUpdate();

                // --

                if (tvwEnv.Nodes.Count > 0)
                {
                    if (m_lastSelectedEnv != string.Empty)
                    {
                        tvwEnv.ActiveNode = tvwEnv.GetNodeByKey(m_lastSelectedEnv);
                    }
                    if (m_lastSelectedEnv == string.Empty || tvwEnv.ActiveNode == null)
                    {
                        tvwEnv.ActiveNode = tvwEnv.Nodes[0];
                    }
                }
            }
            catch (Exception ex)
            {
                tvwEnv.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeScd = null;
                tNodeScd = null;
                tNodeEnl = null;
                tNodeEnv = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------   

        private void refresh(
            )
        {
            try
            {
                refreshGridOfVersion();
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

        private void refreshVersionTotal(
            )
        {
            try
            {
                lblVersionTotal.Text = grdList.Rows.Count.ToString("#,##0");
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

        #region Model Popup Menu

        private void procMenuModelStatus(
            )
        {
            FModelStatus fModelStatus = null;

            try
            {
                fModelStatus = (FModelStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FModelStatus));
                if (fModelStatus == null)
                {
                    fModelStatus = new FModelStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fModelStatus);
                }
                fModelStatus.activate();
                fModelStatus.attach(txtModel.Text, (string)txtModel.Tag, grdList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fModelStatus = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FModelVersionSchema Form Event Handler

        private void FModelVersionSchema_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfVersion();
                designTreeOfSchema();
                designTreeOfEnvironment();

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

        private void FModelVersionSchema_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                txtModel.Focus();
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

        private void FModelVersionSchema_FormClosing(
            object sender, 
            System.Windows.Forms.FormClosingEventArgs e
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

        //------------------------------------------------------------------------------------------------------------------------

        private void FModelVersionSchema_KeyDown(
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
                    refresh();
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

                if (e.Tool.Key == FMenuKey.MenuMvsRefresh)
                {
                    refresh();
                }
                else if (e.Tool.Key == FMenuKey.MenuMvsExport)
                {
                    //export();
                }

                // --

                else if (e.Tool.Key == FMenuKey.MenuMvsModelStatus)
                {
                    procMenuModelStatus();
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

        #region txtModel Control Event Handler

        private void txtModel_EditorButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            FModelSelector fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FModelSelector(m_fAdmCore, txtModel.Text);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtModel.Tag = fDialog.selectedType;
                txtModel.Text = fDialog.selectedModel;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                if (fDialog != null)
                {
                    fDialog.Dispose();
                    fDialog = null;
                }

                // --

                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void txtModel_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                clear();
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

        private void grdList_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshModelSchema();
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

                mnuMenu.Tools[FMenuKey.MenuMvsModelStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ModelStatus);
                
                // --

                mnuMenu.ShowPopup(FMenuKey.MenuMvsPopupMenu);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
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

        #region tvwSchema Control Event Handler

        private void tvwSchema_AfterActivate(
            object sender,
            NodeEventArgs e
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                FCursor.waitCursor();

                if (e.TreeNode == null)
                {
                    return;
                }

                // --

                fXmlNode = (FXmlNode)e.TreeNode.Tag;

                // --

                if (fXmlNode.name == FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.E_SecsDriver)
                {
                    pgdSchema.selectedObject = new FPropMshScd(m_fAdmCore, pgdSchema, fXmlNode);
                }
                else if (fXmlNode.name == FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.E_SecsDevice)
                {
                    pgdSchema.selectedObject = new FPropMshSdv(m_fAdmCore, pgdSchema, fXmlNode);
                }
                else if (fXmlNode.name == FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.E_SecsSession)
                {
                    pgdSchema.selectedObject = new FPropMshSsn(m_fAdmCore, pgdSchema, fXmlNode);
                }
                else if (fXmlNode.name == FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.E_HostDevice)
                {
                    pgdSchema.selectedObject = new FPropMshHdv(m_fAdmCore, pgdSchema, fXmlNode);
                }
                else if (fXmlNode.name == FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.E_HostSession)
                {
                    pgdSchema.selectedObject = new FPropMshHsn(m_fAdmCore, pgdSchema, fXmlNode);
                }
                if (fXmlNode.name == FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.E_Equipment)
                {
                    pgdSchema.selectedObject = new FPropMshEqp(m_fAdmCore, pgdSchema, fXmlNode);
                }

                // --

                m_lastSelectedSchema = e.TreeNode.Key;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fXmlNode = null;

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region tvwEnvironment Control Event Handler

        private void tvwEnvironment_AfterActivate(
            object sender, 
            NodeEventArgs e
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.TreeNode == null)
                {
                    return;
                }

                // --

                fXmlNode = (FXmlNode)e.TreeNode.Tag;

                // --

                if (fXmlNode.name == FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.E_SecsDriver)
                {
                    pgdEnv.selectedObject = new FPropMshScd(m_fAdmCore, pgdEnv, fXmlNode);
                }
                if (fXmlNode.name == FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.E_EnvironmentList)
                {
                    pgdEnv.selectedObject = new FPropMshEnl(m_fAdmCore, pgdEnv, fXmlNode);
                }
                if (fXmlNode.name == FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.E_Environment)
                {
                    pgdEnv.selectedObject = new FPropMshEnv(m_fAdmCore, pgdEnv, fXmlNode);
                }

                // --

                m_lastSelectedEnv = e.TreeNode.Key;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fXmlNode = null;

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region rstToolbar Control Event Handler

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

    }   //  Class end
}   // Namespace end
