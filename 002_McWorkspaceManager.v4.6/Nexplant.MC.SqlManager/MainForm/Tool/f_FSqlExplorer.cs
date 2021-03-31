/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSqlExplorer.cs
--  Creator         : mj.kim
--  Create Date     : 2011.11.10
--  Description     : FAMate SQL Explorer Form Class
--  History         : Created by mj.kim at 2011.11.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.SqlManager
{
    public partial class FSqlExplorer : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private char[] KeySeparator = { '-' };
        private const string KeyFormat = "{0}-{1}";// System Name + Unique ID
        private const string Prefix = "FAMATE_";

        private const string FCbFormatSystem = Prefix + FXmlTagSystem.E_System;
        private const string FCbFormatModule = Prefix + FXmlTagModule.E_Module;
        private const string FCbFormatFunction = Prefix + FXmlTagFunction.E_Function;
        private const string FCbFormatSqlCode = Prefix + FXmlTagSqlCode.E_SqlCode;
        
        // --

        private bool m_disposed = false;
        // --
        private FSqmCore m_fSqmCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSqlExplorer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSqlExplorer(
            FSqmCore fSsmCore
            )
            :this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSqmCore = fSsmCore;
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
                    m_fSqmCore = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        private bool canPaste
        {
            get
            {
                FXmlNode n = null;

                try
                {
                    if (tvwTree.ActiveNode == null)
                    {
                        return (FClipboard.containsData(FCbFormatSystem) ? true : false);
                    }

                    // --

                    n = (FXmlNode)tvwTree.ActiveNode.Tag;
                    if (n.name == FXmlTagSystem.E_System)
                    {
                        if (
                            FClipboard.containsData(FCbFormatSystem) ||
                            FClipboard.containsData(FCbFormatModule)
                            )
                        {
                            return true;
                        }
                    }
                    else if (n.name == FXmlTagModule.E_Module)
                    {
                        if (
                            FClipboard.containsData(FCbFormatModule) ||
                            FClipboard.containsData(FCbFormatFunction)
                            )
                        {
                            return true;
                        }
                    }
                    else if (n.name == FXmlTagFunction.E_Function)
                    {
                        if (
                            FClipboard.containsData(FCbFormatFunction) ||
                            FClipboard.containsData(FCbFormatSqlCode)
                            )
                        {
                            return true;
                        }
                    }
                    else if (n.name == FXmlTagSqlCode.E_SqlCode)
                    {
                        if (FClipboard.containsData(FCbFormatSqlCode))
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
                    n = null;
                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool canRemove
        {
            get
            {
                try
                {
                    foreach (UltraTreeNode t in tvwTree.SelectedNodes)
                    {
                        if (t.Nodes.Count > 0)
                        {
                            return false;
                        }
                    }

                    // --

                    return true;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool canMoveUp
        {
            get
            {
                try
                {
                    foreach (UltraTreeNode t in tvwTree.SelectedNodes)
                    {
                        if (t.GetSibling(NodePosition.Previous) == null)
                        {
                            return false;
                        }
                    }

                    // --

                    return true;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool canMoveDown
        {
            get
            {
                try
                {
                    foreach (UltraTreeNode t in tvwTree.SelectedNodes)
                    {
                        if (t.GetSibling(NodePosition.Next) == null)
                        {
                            return false;
                        }
                    }

                    // --

                    return true;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void setTitle(
            )
        {
            try
            {
                this.Text = m_fSqmCore.fWsmCore.fUIWizard.searchCaption(this.Text);
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
            FXmlNode x = null;
            UltraTreeNode n = null;

            try
            {
                mnuMenu.beginUpdate();

                // --

                foreach (ToolBase t in mnuMenu.Tools)
                {
                    if (                        
                        t.Key == FMenuKey.MenuSqeExpand     ||
                        t.Key == FMenuKey.MenuSqeCollapse   ||
                        t.Key == FMenuKey.MenuSqeCompatible ||
                        t.Key == FMenuKey.MenuSqeCopy       ||
                        t.Key == FMenuKey.MenuSqeDownload   ||
                        t.Key == FMenuKey.MenuSqeMigration
                        )
                    {
                        continue;
                    }
                    else if (
                        t.Key == FMenuKey.MenuSqePaste    ||
                        t.Key == FMenuKey.MenuSqeRemove   ||
                        t.Key == FMenuKey.MenuSqeMoveUp   ||
                        t.Key == FMenuKey.MenuSqeMoveDown                         
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

                n = tvwTree.ActiveNode;
                if (n == null)
                {
                    mnuMenu.Tools[FMenuKey.MenuSqePaste].SharedProps.Enabled = this.canPaste;
                    mnuMenu.Tools[FMenuKey.MenuSqeAppendSystem].SharedProps.Visible = true;
                }
                else
                {
                    x = (FXmlNode)n.Tag;
                    if (x.name == FXmlTagSystem.E_System)
                    {
                        mnuMenu.Tools[FMenuKey.MenuSqePaste].SharedProps.Enabled = this.canPaste;
                        mnuMenu.Tools[FMenuKey.MenuSqeRemove].SharedProps.Enabled = this.canRemove;
                        mnuMenu.Tools[FMenuKey.MenuSqeAppendModule].SharedProps.Visible = true;
                    }
                    else if (x.name == FXmlTagModule.E_Module)
                    {
                        mnuMenu.Tools[FMenuKey.MenuSqePaste].SharedProps.Enabled = this.canPaste;
                        mnuMenu.Tools[FMenuKey.MenuSqeRemove].SharedProps.Enabled = this.canRemove;
                        mnuMenu.Tools[FMenuKey.MenuSqeMoveUp].SharedProps.Enabled = this.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuSqeMoveDown].SharedProps.Enabled = this.canMoveDown;
                        mnuMenu.Tools[FMenuKey.MenuSqeInsertBeforeModule].SharedProps.Visible = true;
                        mnuMenu.Tools[FMenuKey.MenuSqeInsertAfterModule].SharedProps.Visible = true;
                        mnuMenu.Tools[FMenuKey.MenuSqeAppendFunction].SharedProps.Visible = true;
                    }
                    else if (x.name == FXmlTagFunction.E_Function)
                    {
                        mnuMenu.Tools[FMenuKey.MenuSqePaste].SharedProps.Enabled = this.canPaste;
                        mnuMenu.Tools[FMenuKey.MenuSqeRemove].SharedProps.Enabled = this.canRemove;
                        mnuMenu.Tools[FMenuKey.MenuSqeMoveUp].SharedProps.Enabled = this.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuSqeMoveDown].SharedProps.Enabled = this.canMoveDown;
                        mnuMenu.Tools[FMenuKey.MenuSqeInsertBeforeFunction].SharedProps.Visible = true;
                        mnuMenu.Tools[FMenuKey.MenuSqeInsertAfterFunction].SharedProps.Visible = true;
                        mnuMenu.Tools[FMenuKey.MenuSqeAppendSqlCode].SharedProps.Visible = true;
                    }
                    else if (x.name == FXmlTagSqlCode.E_SqlCode)
                    {
                        mnuMenu.Tools[FMenuKey.MenuSqeParameter].SharedProps.Visible = true;
                        mnuMenu.Tools[FMenuKey.MenuSqePaste].SharedProps.Enabled = this.canPaste;
                        mnuMenu.Tools[FMenuKey.MenuSqeRemove].SharedProps.Enabled = true;
                        mnuMenu.Tools[FMenuKey.MenuSqeMoveUp].SharedProps.Enabled = this.canMoveUp;
                        mnuMenu.Tools[FMenuKey.MenuSqeMoveDown].SharedProps.Enabled = this.canMoveDown;
                        mnuMenu.Tools[FMenuKey.MenuSqeExecuteSql].SharedProps.Visible = true;
                        mnuMenu.Tools[FMenuKey.MenuSqeInsertBeforeSqlCode].SharedProps.Visible = true;
                        mnuMenu.Tools[FMenuKey.MenuSqeInsertAfterSqlCode].SharedProps.Visible = true;
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
                x = null;
                n = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void designTreeOfSqlExplorer(
            )
        {
            try
            {
                tvwTree.ImageList = new ImageList();
                // --
                tvwTree.ImageList.Images.Add("System", Properties.Resources.System);
                tvwTree.ImageList.Images.Add("Module", Properties.Resources.Module);
                tvwTree.ImageList.Images.Add("Function", Properties.Resources.Function);
                tvwTree.ImageList.Images.Add("SqlCode", Properties.Resources.SqlCode);
                tvwTree.ImageList.Images.Add("SqlCode_NotCompatible", Properties.Resources.SqlCode_NotCompatible);
                tvwTree.ImageList.Images.Add("Parameter", Properties.Resources.Parameter);
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

        private FXmlNode updateSystem(
            string hStep,
            string uniqueIdToString,
            string system,
            string description,
            string standardDb,
            string reference
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSys = null;
            FXmlNode fXmlNodeInRef = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeSys = null;

            try
            {
                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetSystemUpdate_In.E_SQMSQS_SetSystemUpdate_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSystemUpdate_In.A_hLanguage, FSQMSQS_SetSystemUpdate_In.D_hLanguage, m_fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSystemUpdate_In.A_hStep, FSQMSQS_SetSystemUpdate_In.D_hStep, hStep);
                // --
                fXmlNodeInSys = fXmlNodeIn.set_elem(FSQMSQS_SetSystemUpdate_In.FSystem.E_System);
                fXmlNodeInSys.set_elemVal(FSQMSQS_SetSystemUpdate_In.FSystem.A_UniqueId, FSQMSQS_SetSystemUpdate_In.FSystem.D_UniqueId, uniqueIdToString);
                fXmlNodeInSys.set_elemVal(FSQMSQS_SetSystemUpdate_In.FSystem.A_System, FSQMSQS_SetSystemUpdate_In.FSystem.D_System, system);
                fXmlNodeInSys.set_elemVal(FSQMSQS_SetSystemUpdate_In.FSystem.A_Description, FSQMSQS_SetSystemUpdate_In.FSystem.D_Description, description);
                fXmlNodeInSys.set_elemVal(FSQMSQS_SetSystemUpdate_In.FSystem.A_StandardDatabase, FSQMSQS_SetSystemUpdate_In.FSystem.D_StandardDatabase, standardDb);
                // --
                fXmlNodeInRef = fXmlNodeIn.set_elem(FSQMSQS_SetSystemUpdate_In.FReference.E_Reference);
                fXmlNodeInRef.set_elemVal(FSQMSQS_SetSystemUpdate_In.FReference.A_System, FSQMSQS_SetSystemUpdate_In.FReference.D_System, reference);

                // --

                FSQMSQSCaster.SQMSQS_SetSystemUpdate_Req(
                    m_fSqmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FSQMSQS_SetSystemUpdate_Out.A_hStatus, FSQMSQS_SetSystemUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_SetSystemUpdate_Out.A_hStatusMessage, FSQMSQS_SetSystemUpdate_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeSys = FCommon.createXmlNodeIn(FXmlTagSystem.E_System);
                fXmlNodeSys.set_elemVal(FXmlTagSystem.A_UniqueId, FXmlTagSystem.D_UniqueId, "0");
                fXmlNodeSys.set_elemVal(FXmlTagSystem.A_System, FXmlTagSystem.D_System, system);
                fXmlNodeSys.set_elemVal(FXmlTagSystem.A_Description, FXmlTagSystem.D_Description, description);
                fXmlNodeSys.set_elemVal(FXmlTagSystem.A_StandardDatabase, FXmlTagSystem.D_StandardDatabase, standardDb);

                return fXmlNodeSys;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInSys = null;
                fXmlNodeInRef = null;
                fXmlNodeOut = null;
                fXmlNodeSys = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FXmlNode updateModule(
            string hStep,
            string system,
            string uniqueIdToString,
            string module,
            string description,
            string reference
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInMod = null;
            FXmlNode fXmlNodeInRef = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeMod = null;

            try
            {
                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetModuleUpdate_In.E_SQMSQS_SetModuleUpdate_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetModuleUpdate_In.A_hLanguage, FSQMSQS_SetModuleUpdate_In.D_hLanguage, m_fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetModuleUpdate_In.A_hStep, FSQMSQS_SetModuleUpdate_In.D_hStep, hStep);
                // --
                fXmlNodeInMod = fXmlNodeIn.set_elem(FSQMSQS_SetModuleUpdate_In.FModule.E_Module);
                fXmlNodeInMod.set_elemVal(FSQMSQS_SetModuleUpdate_In.FModule.A_System, FSQMSQS_SetModuleUpdate_In.FModule.D_System, system);
                fXmlNodeInMod.set_elemVal(FSQMSQS_SetModuleUpdate_In.FModule.A_UniqueId, FSQMSQS_SetModuleUpdate_In.FModule.D_UniqueId, uniqueIdToString);
                fXmlNodeInMod.set_elemVal(FSQMSQS_SetModuleUpdate_In.FModule.A_Module, FSQMSQS_SetModuleUpdate_In.FModule.D_Module, module);
                fXmlNodeInMod.set_elemVal(FSQMSQS_SetModuleUpdate_In.FModule.A_Description, FSQMSQS_SetModuleUpdate_In.FModule.D_Description, description);
                // --
                fXmlNodeInRef = fXmlNodeIn.set_elem(FSQMSQS_SetModuleUpdate_In.FReference.E_Reference);
                fXmlNodeInRef.set_elemVal(FSQMSQS_SetModuleUpdate_In.FReference.A_UniqueId, FSQMSQS_SetModuleUpdate_In.FReference.D_UniqueId, reference);

                // --

                FSQMSQSCaster.SQMSQS_SetModuleUpdate_Req(
                    m_fSqmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FSQMSQS_SetModuleUpdate_Out.A_hStatus, FSQMSQS_SetModuleUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_SetModuleUpdate_Out.A_hStatusMessage, FSQMSQS_SetModuleUpdate_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeMod = FCommon.createXmlNodeIn(FXmlTagModule.E_Module);
                fXmlNodeMod.set_elemVal(FXmlTagModule.A_UniqueId, FXmlTagModule.D_UniqueId,
                    fXmlNodeOut.get_elem(FSQMSQS_SetModuleUpdate_Out.FModule.E_Module).get_elemVal(FSQMSQS_SetModuleUpdate_Out.FModule.A_UniqueId, FSQMSQS_SetModuleUpdate_Out.FModule.D_UniqueId)
                    );
                fXmlNodeMod.set_elemVal(FXmlTagModule.A_Module, FXmlTagModule.D_Module, module);
                fXmlNodeMod.set_elemVal(FXmlTagModule.A_Description, FXmlTagModule.D_Description, description);

                return fXmlNodeMod;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInMod = null;
                fXmlNodeInRef = null;
                fXmlNodeOut = null;
                fXmlNodeMod = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FXmlNode updateFunction(
            string hStep,
            string system,
            string module,
            string uniqueIdToString,
            string function,
            string description,
            string reference
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInFun = null;
            FXmlNode fXmlNodeInRef = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeFun = null;

            try
            {
                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetFunctionUpdate_In.E_SQMSQS_SetFunctionUpdate_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetFunctionUpdate_In.A_hLanguage, FSQMSQS_SetFunctionUpdate_In.D_hLanguage, m_fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetFunctionUpdate_In.A_hStep, FSQMSQS_SetFunctionUpdate_In.D_hStep, hStep);

                fXmlNodeInFun = fXmlNodeIn.set_elem(FSQMSQS_SetFunctionUpdate_In.FFunction.E_Function);
                fXmlNodeInFun.set_elemVal(FSQMSQS_SetFunctionUpdate_In.FFunction.A_System, FSQMSQS_SetFunctionUpdate_In.FFunction.D_System, system);
                fXmlNodeInFun.set_elemVal(FSQMSQS_SetFunctionUpdate_In.FFunction.A_Module, FSQMSQS_SetFunctionUpdate_In.FFunction.D_Module, module);
                fXmlNodeInFun.set_elemVal(FSQMSQS_SetFunctionUpdate_In.FFunction.A_UniqueId, FSQMSQS_SetFunctionUpdate_In.FFunction.D_UniqueId, uniqueIdToString);
                fXmlNodeInFun.set_elemVal(FSQMSQS_SetFunctionUpdate_In.FFunction.A_Function, FSQMSQS_SetFunctionUpdate_In.FFunction.D_Function, function);
                fXmlNodeInFun.set_elemVal(FSQMSQS_SetFunctionUpdate_In.FFunction.A_Description, FSQMSQS_SetFunctionUpdate_In.FFunction.D_Description, description);

                fXmlNodeInRef = fXmlNodeIn.set_elem(FSQMSQS_SetFunctionUpdate_In.FReference.E_Reference);
                fXmlNodeInRef.set_elemVal(FSQMSQS_SetFunctionUpdate_In.FReference.A_UniqueId, FSQMSQS_SetFunctionUpdate_In.FReference.D_UniqueId, reference);

                FSQMSQSCaster.SQMSQS_SetFunctionUpdate_Req(
                    m_fSqmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );

                if (fXmlNodeOut.get_elemVal(FSQMSQS_SetFunctionUpdate_Out.A_hStatus, FSQMSQS_SetFunctionUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_SetFunctionUpdate_Out.A_hStatusMessage, FSQMSQS_SetFunctionUpdate_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeFun = FCommon.createXmlNodeIn(FXmlTagFunction.E_Function);
                fXmlNodeFun.set_elemVal(FXmlTagFunction.A_UniqueId, FXmlTagFunction.D_UniqueId,
                    fXmlNodeOut.get_elem(FSQMSQS_SetFunctionUpdate_Out.FFunction.E_Function).get_elemVal(FSQMSQS_SetFunctionUpdate_Out.FFunction.A_UniqueId, FSQMSQS_SetFunctionUpdate_Out.FFunction.D_UniqueId)
                    );
                fXmlNodeFun.set_elemVal(FXmlTagFunction.A_Function, FXmlTagFunction.D_Function, function);
                fXmlNodeFun.set_elemVal(FXmlTagFunction.A_Description, FXmlTagFunction.D_Description, description);

                return fXmlNodeFun;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInFun = null;
                fXmlNodeInRef = null;
                fXmlNodeOut = null;
                fXmlNodeFun = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FXmlNode updateSqlCode(
            string hStep,
            string system,
            string module,
            string function,
            string uniqueIdToString,
            string sqlCode,
            string description,
            FYesNo usedMigration,
            string msSqlQuery,
            string oracleQuery,
            string mySqlQuery,
            string mariaDbQuery,
            string postgreSqlQuery,
            string reference
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSqc = null;
            FXmlNode fXmlNodeInSqy = null;
            FXmlNode fXmlNodeInSqp = null;
            FXmlNode fXmlNodeInRef = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeSqc = null;
            FXmlNode fXmlNodeSqy = null;
            FXmlNode fXmlNodeSqp = null;

            try
            {
                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetSqlCodeUpdate_In.E_SQMSQS_SetSqlCodeUpdate_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.A_hLanguage, FSQMSQS_SetSqlCodeUpdate_In.D_hLanguage, m_fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.A_hStep, FSQMSQS_SetSqlCodeUpdate_In.D_hStep, hStep);

                fXmlNodeInSqc = fXmlNodeIn.set_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.E_SqlCode);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_System, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_System, system);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_Module, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_Module, module);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_Function, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_Function, function);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_UniqueId, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_UniqueId, uniqueIdToString);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_SqlCode, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_SqlCode, sqlCode);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_Description, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_Description, description);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_UsedMigration, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_UsedMigration, usedMigration.ToString());
                // --
                fXmlNodeInSqy = fXmlNodeInSqc.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.E_Query);
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_DbProvider, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_DbProvider, FDbProvider.MsSqlServer.ToString());
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_Query, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_Query, msSqlQuery);
                foreach (FSqlParameter fSqlParameter in FCommon.parseSqlParameter(FDbProvider.MsSqlServer.ToString(), msSqlQuery).Values)
                {
                    fXmlNodeInSqp = fXmlNodeInSqy.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.E_Parameter);
                    fXmlNodeInSqp.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.A_Parameter, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.D_Parameter, fSqlParameter.parameter);
                }
                // --
                fXmlNodeInSqy = fXmlNodeInSqc.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.E_Query);
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_DbProvider, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_DbProvider, FDbProvider.Oracle.ToString());
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_Query, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_Query, oracleQuery);
                foreach (FSqlParameter fSqlParameter in FCommon.parseSqlParameter(FDbProvider.Oracle.ToString(), oracleQuery).Values)
                {
                    fXmlNodeInSqp = fXmlNodeInSqy.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.E_Parameter);
                    fXmlNodeInSqp.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.A_Parameter, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.D_Parameter, fSqlParameter.parameter);
                }
                    // --
                    fXmlNodeInSqy = fXmlNodeInSqc.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.E_Query);
                    fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_DbProvider, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_DbProvider, FDbProvider.MySql.ToString());
                    fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_Query, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_Query, mySqlQuery);
                    foreach (FSqlParameter fSqlParameter in FCommon.parseSqlParameter(FDbProvider.MySql.ToString(), mySqlQuery).Values)
                    {
                        fXmlNodeInSqp = fXmlNodeInSqy.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.E_Parameter);
                        fXmlNodeInSqp.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.A_Parameter, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.D_Parameter, fSqlParameter.parameter);
                    }
                    // --
                    fXmlNodeInSqy = fXmlNodeInSqc.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.E_Query);
                    fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_DbProvider, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_DbProvider, FDbProvider.MariaDb.ToString());
                    fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_Query, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_Query, mariaDbQuery);
                    foreach (FSqlParameter fSqlParameter in FCommon.parseSqlParameter(FDbProvider.MariaDb.ToString(), mariaDbQuery).Values)
                    {
                        fXmlNodeInSqp = fXmlNodeInSqy.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.E_Parameter);
                        fXmlNodeInSqp.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.A_Parameter, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.D_Parameter, fSqlParameter.parameter);
                    }
                    // --
                    fXmlNodeInSqy = fXmlNodeInSqc.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.E_Query);
                    fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_DbProvider, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_DbProvider, FDbProvider.PostgreSql.ToString());
                    fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_Query, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_Query, postgreSqlQuery);
                    foreach (FSqlParameter fSqlParameter in FCommon.parseSqlParameter(FDbProvider.PostgreSql.ToString(), postgreSqlQuery).Values)
                    {
                        fXmlNodeInSqp = fXmlNodeInSqy.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.E_Parameter);
                        fXmlNodeInSqp.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.A_Parameter, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.D_Parameter, fSqlParameter.parameter);
                    }

                    fXmlNodeInRef = fXmlNodeIn.set_elem(FSQMSQS_SetSqlCodeUpdate_In.FReference.E_Reference);
                    fXmlNodeInRef.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FReference.A_UniqueId, FSQMSQS_SetSqlCodeUpdate_In.FReference.D_UniqueId, reference);

                FSQMSQSCaster.SQMSQS_SetSqlCodeUpdate_Req(
                    m_fSqmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );

                if (fXmlNodeOut.get_elemVal(FSQMSQS_SetSqlCodeUpdate_Out.A_hStatus, FSQMSQS_SetSqlCodeUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_SetSqlCodeUpdate_Out.A_hStatusMessage, FSQMSQS_SetSqlCodeUpdate_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeSqc = FCommon.createXmlNodeIn(FXmlTagSqlCode.E_SqlCode);
                fXmlNodeSqc.set_elemVal(FXmlTagSqlCode.A_UniqueId, FXmlTagSqlCode.D_UniqueId,
                    fXmlNodeOut.get_elem(FSQMSQS_SetSqlCodeUpdate_Out.FSqlCode.E_SqlCode).get_elemVal(FSQMSQS_SetSqlCodeUpdate_Out.FSqlCode.A_UniqueId, FSQMSQS_SetSqlCodeUpdate_Out.FSqlCode.D_UniqueId)
                    );
                fXmlNodeSqc.set_elemVal(FXmlTagSqlCode.A_SqlCode, FXmlTagSqlCode.D_SqlCode, sqlCode);
                fXmlNodeSqc.set_elemVal(FXmlTagSqlCode.A_Description, FXmlTagSqlCode.D_Description, description);
                // --
                fXmlNodeSqy = fXmlNodeSqc.add_elem(FXmlTagSqlQuery.E_SqlQuery);
                fXmlNodeSqy.set_elemVal(FXmlTagSqlQuery.A_DbProvider, FXmlTagSqlQuery.D_DbProvider, FDbProvider.MsSqlServer.ToString());
                fXmlNodeSqy.set_elemVal(FXmlTagSqlQuery.A_SqlQuery, FXmlTagSqlQuery.D_SqlQuery, msSqlQuery);
                foreach (FSqlParameter fSqlParameter in FCommon.parseSqlParameter(FDbProvider.MsSqlServer.ToString(), msSqlQuery).Values)
                {
                    fXmlNodeSqp = fXmlNodeSqy.add_elem(FXmlTagSqlParameter.E_SqlParameter);
                    fXmlNodeSqp.set_elemVal(FXmlTagSqlParameter.A_SqlParameter, FXmlTagSqlParameter.D_SqlParameter, fSqlParameter.parameter);
                }
                // --
                fXmlNodeSqy = fXmlNodeSqc.add_elem(FXmlTagSqlQuery.E_SqlQuery);
                fXmlNodeSqy.set_elemVal(FXmlTagSqlQuery.A_DbProvider, FXmlTagSqlQuery.D_DbProvider, FDbProvider.Oracle.ToString());
                fXmlNodeSqy.set_elemVal(FXmlTagSqlQuery.A_SqlQuery, FXmlTagSqlQuery.D_SqlQuery, oracleQuery);
                foreach (FSqlParameter fSqlParameter in FCommon.parseSqlParameter(FDbProvider.Oracle.ToString(), oracleQuery).Values)
                {
                    fXmlNodeSqp = fXmlNodeSqy.add_elem(FXmlTagSqlParameter.E_SqlParameter);
                    fXmlNodeSqp.set_elemVal(FXmlTagSqlParameter.A_SqlParameter, FXmlTagSqlParameter.D_SqlParameter, fSqlParameter.parameter);
                }
                // --
                fXmlNodeSqy = fXmlNodeSqc.add_elem(FXmlTagSqlQuery.E_SqlQuery);
                fXmlNodeSqy.set_elemVal(FXmlTagSqlQuery.A_DbProvider, FXmlTagSqlQuery.D_DbProvider, FDbProvider.MySql.ToString());
                fXmlNodeSqy.set_elemVal(FXmlTagSqlQuery.A_SqlQuery, FXmlTagSqlQuery.D_SqlQuery, mySqlQuery);
                foreach (FSqlParameter fSqlParameter in FCommon.parseSqlParameter(FDbProvider.MySql.ToString(), mySqlQuery).Values)
                {
                    fXmlNodeSqp = fXmlNodeSqy.add_elem(FXmlTagSqlParameter.E_SqlParameter);
                    fXmlNodeSqp.set_elemVal(FXmlTagSqlParameter.A_SqlParameter, FXmlTagSqlParameter.D_SqlParameter, fSqlParameter.parameter);
                }
                // --
                fXmlNodeSqy = fXmlNodeSqc.add_elem(FXmlTagSqlQuery.E_SqlQuery);
                fXmlNodeSqy.set_elemVal(FXmlTagSqlQuery.A_DbProvider, FXmlTagSqlQuery.D_DbProvider, FDbProvider.MariaDb.ToString());
                fXmlNodeSqy.set_elemVal(FXmlTagSqlQuery.A_SqlQuery, FXmlTagSqlQuery.D_SqlQuery, mariaDbQuery);
                foreach (FSqlParameter fSqlParameter in FCommon.parseSqlParameter(FDbProvider.MariaDb.ToString(), mariaDbQuery).Values)
                {
                    fXmlNodeSqp = fXmlNodeSqy.add_elem(FXmlTagSqlParameter.E_SqlParameter);
                    fXmlNodeSqp.set_elemVal(FXmlTagSqlParameter.A_SqlParameter, FXmlTagSqlParameter.D_SqlParameter, fSqlParameter.parameter);
                }
                // --
                fXmlNodeSqy = fXmlNodeSqc.add_elem(FXmlTagSqlQuery.E_SqlQuery);
                fXmlNodeSqy.set_elemVal(FXmlTagSqlQuery.A_DbProvider, FXmlTagSqlQuery.D_DbProvider, FDbProvider.PostgreSql.ToString());
                fXmlNodeSqy.set_elemVal(FXmlTagSqlQuery.A_SqlQuery, FXmlTagSqlQuery.D_SqlQuery, postgreSqlQuery);
                foreach (FSqlParameter fSqlParameter in FCommon.parseSqlParameter(FDbProvider.PostgreSql.ToString(), postgreSqlQuery).Values)
                {
                    fXmlNodeSqp = fXmlNodeSqy.add_elem(FXmlTagSqlParameter.E_SqlParameter);
                    fXmlNodeSqp.set_elemVal(FXmlTagSqlParameter.A_SqlParameter, FXmlTagSqlParameter.D_SqlParameter, fSqlParameter.parameter);
                }

                return fXmlNodeSqc;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInSqc = null;
                fXmlNodeInSqy = null;
                fXmlNodeInSqp = null;
                fXmlNodeInRef = null;
                fXmlNodeOut = null;
                fXmlNodeSqc = null;
                fXmlNodeSqy = null;
                fXmlNodeSqp = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private DataTable getPropOfSystem(
            UltraTreeNode tNode
            )
        {
            string[] keys = null;
            string system = string.Empty;

            try
            {
                keys = tNode.Key.Split(KeySeparator);
                system = keys[0];
                
                // --

                return FCommon.getSystemInfo(m_fSqmCore, system);
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

        private DataTable getPropOfModule(
            UltraTreeNode tNode
            )
        {
            FXmlNode n = null;
            string[] keys = null;
            string system = string.Empty;
            string uniqueIdToString = string.Empty;
            string module = string.Empty;

            try
            {
                keys = tNode.Key.Split(KeySeparator);
                system = keys[0];
                uniqueIdToString = keys[1];

                // --

                n = (FXmlNode)tNode.Tag;
                if (n != null)
                {
                    module = n.get_elemVal(FXmlTagModule.A_Module, FXmlTagModule.D_Module);
                }

                // --

                return FCommon.getModuleInfo(m_fSqmCore, system, uniqueIdToString, module);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                n = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private DataTable getPropOfFunction(
            UltraTreeNode tNode
            )
        {
            FXmlNode n = null;
            string [] keys = null;
            string system = string.Empty;
            string uniqueIdToString = string.Empty;
            string function = string.Empty;

            try
            {
                keys = tNode.Key.Split(KeySeparator);
                system = keys[0];
                uniqueIdToString = keys[1];

                // --

                n = (FXmlNode)tNode.Tag;
                if (n != null)
                {
                    function = n.get_elemVal(FXmlTagFunction.A_Function, FXmlTagFunction.D_Function);
                }

                // --

                return FCommon.getFunctionInfo(m_fSqmCore, system, uniqueIdToString, function);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                n = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private DataTable getPropOfSqlCode(
            UltraTreeNode tNode
            )
        {
            FXmlNode n = null;
            string [] keys = null;
            string system = string.Empty;
            string uniqueIdToString = string.Empty;
            string sqlCode = string.Empty;

            try
            {
                keys = tNode.Key.Split(KeySeparator);
                system = keys[0];
                uniqueIdToString = keys[1];

                // --

                n = (FXmlNode)tNode.Tag;
                if (n != null)
                {
                    sqlCode = n.get_elemVal(FXmlTagSqlCode.A_SqlCode, FXmlTagSqlCode.D_SqlCode);
                }

                // --

                return FCommon.getSqlCodeInfo(m_fSqmCore, system, uniqueIdToString, sqlCode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                n = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void expand(
            UltraTreeNode tNode,
            bool expanded
            )
        {
            try
            {
                tNode.Expanded = expanded;
                foreach (UltraTreeNode t in tNode.Nodes)
                {
                    t.Expanded = expanded;

                    // -- 

                    expand(t, expanded);
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

        private string generateName(
            string str
            )
        {
            string oldText = string.Empty;
            string newText = string.Empty;
            int i = 0;
            int j = 0;

            try
            {
                while (true)
                {
                    newText = string.Format("{0}{1}", str, (i == 0 ? string.Empty : i.ToString()));
                    for (j = 0; j < tvwTree.Nodes.Count; j++)
                    {
                        oldText = ((FXmlNode)tvwTree.Nodes[j].Tag).get_elemVal(FXmlTagSystem.A_System, FXmlTagSystem.D_System);
                        if (newText == oldText)
                        {
                            break;
                        }
                    }
                    if (j == tvwTree.Nodes.Count)
                    {
                        break;
                    }
                    i++;
                }

                return newText;
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

        private string generateName(
            UltraTreeNode tNode,
            string hStep,
            string str
            )
        {
            FXmlNode n = null;
            UltraTreeNode t = null;
            string oldText = string.Empty;
            string newText = string.Empty;
            int i = 0;
            int j = 0;

            try
            {
                t = hStep == "3" ? tNode : tNode.Parent;

                while (true)
                {
                    newText = string.Format("{0}{1}", str, (i == 0 ? string.Empty : i.ToString()));
                    for (j = 0; j < t.Nodes.Count; j++)
                    {
                        n = (FXmlNode)t.Nodes[j].Tag;
                        if (n.name == FXmlTagModule.E_Module)
                        {
                            oldText = n.get_elemVal(FXmlTagModule.A_Module, FXmlTagModule.D_Module);
                        }
                        else if (n.name == FXmlTagFunction.E_Function)
                        {
                            oldText = n.get_elemVal(FXmlTagFunction.A_Function, FXmlTagFunction.D_Function);
                        }
                        else if (n.name == FXmlTagSqlCode.E_SqlCode)
                        {
                            oldText = n.get_elemVal(FXmlTagSqlCode.A_SqlCode, FXmlTagSqlCode.D_SqlCode);
                        }
                        if (newText == oldText)
                        {
                            break;
                        }
                    }
                    if (j == t.Nodes.Count)
                    {
                        break;
                    }
                    i++;
                }

                return newText;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                n = null;
                t = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void replaceNodeKey(
            UltraTreeNode tNode,
            string system
            )
        {
            string[] keys = null;

            try
            {
                keys = tNode.Key.Split(KeySeparator);
                tNode.Key = string.Format(KeyFormat, system, keys[1]);

                foreach (UltraTreeNode t in tNode.Nodes)
                {
                    keys = t.Key.Split(KeySeparator);
                    t.Key = string.Format(KeyFormat, system, keys[1]);

                    // --

                    replaceNodeKey(t, system);
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

        private string refreshNodeText(
            string name,
            string description
            )
        {
            string info = string.Empty;

            try
            {
                info = name;
                if (description != string.Empty)
                {
                    info += " Desc=[" + description + "]";
                }
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

        private void refreshTreeOfSystem(
            )
        {
            DataTable dt = null;
            FXmlNode fXmlNode = null;
            UltraTreeNode tNode = null;
            string uniqueIdToString = string.Empty;
            string system = string.Empty;
            string description = string.Empty;
            int nextRowNumber = 0;

            try
            {
                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();

                // --

                do
                {
                    dt = FCommon.requestSystemList(m_fSqmCore, ref nextRowNumber);
                    foreach (DataRow r in dt.Rows)
                    {
                        uniqueIdToString = r[0].ToString();
                        system = r[1].ToString();
                        description = r[2].ToString();

                        // --

                        fXmlNode = FCommon.createXmlNodeIn(FXmlTagSystem.E_System);
                        // --
                        fXmlNode.set_elemVal(FXmlTagSystem.A_UniqueId, FXmlTagSystem.D_UniqueId, uniqueIdToString);
                        fXmlNode.set_elemVal(FXmlTagSystem.A_System, FXmlTagSystem.D_System, system);
                        fXmlNode.set_elemVal(FXmlTagSystem.A_Description, FXmlTagSystem.D_Description, description);
 
                        // --

                        tNode = new UltraTreeNode(
                            String.Format(KeyFormat, system, uniqueIdToString),
                            refreshNodeText(system, description)
                            );
                        tNode.Expanded = true;
                        tNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["System"];
                        tNode.Tag = fXmlNode;

                        // --

                        refreshTreeOfModule(tNode);

                        // --

                        tvwTree.Nodes.Add(tNode);                        
                    }
                } while (nextRowNumber >= 0);

                // --

                tvwTree.endUpdate();
                if (tvwTree.Nodes.Count > 0)
                {
                    tvwTree.ActiveNode = tvwTree.Nodes[0];
                }
                else
                {
                    controlMenu();
                }
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                dt = null;
                fXmlNode = null;
                tNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshTreeOfModule(
            UltraTreeNode tParentNode
            )
        {
            DataTable dt = null;
            FXmlNode fXmlNode = null; 
            UltraTreeNode tNode = null;
            string system = string.Empty;
            string uniqueIdToString = string.Empty;
            string module = string.Empty;
            string description = string.Empty;
            int nextRowNumber = 0;

            try
            {
                system = tParentNode.Key.Split(KeySeparator)[0];

                do
                {
                    dt = FCommon.requestModuleList(m_fSqmCore, system, ref nextRowNumber);
                    foreach (DataRow r in dt.Rows)
                    {
                        uniqueIdToString = r[0].ToString();
                        module = r[1].ToString();
                        description = r[2].ToString();
                        // -- 
                        fXmlNode = FCommon.createXmlNodeIn(FXmlTagModule.E_Module);
                        fXmlNode.set_elemVal(FXmlTagModule.A_UniqueId, FXmlTagModule.D_UniqueId, uniqueIdToString);
                        fXmlNode.set_elemVal(FXmlTagModule.A_Module, FXmlTagModule.D_Module, module);
                        fXmlNode.set_elemVal(FXmlTagModule.A_Description, FXmlTagModule.D_Description, description);
                        // -- 
                        tNode = tParentNode.Nodes.Add(
                            string.Format(KeyFormat, system, uniqueIdToString),
                            refreshNodeText(module, description)
                            );
                        tNode.Expanded = false;
                        tNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Module"];
                        tNode.Tag = fXmlNode;
                        // -- 
                        refreshTreeOfFunction(tNode);
                    }
                } while (nextRowNumber >= 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dt = null;
                fXmlNode = null;
                tNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshTreeOfFunction(
            UltraTreeNode tParentNode
            )
        {
            DataTable dt = null;
            FXmlNode fXmlNode = null; 
            UltraTreeNode tNode = null;
            string[] keys = null;
            string system = string.Empty;
            string module = string.Empty;
            string uniqueIdToString = string.Empty;
            string function = string.Empty;
            string description = string.Empty;
            int nextRowNumber = 0;

            try
            {
                keys = tParentNode.Key.Split(KeySeparator);
                system = keys[0];
                module = ((FXmlNode)tParentNode.Tag).get_elemVal(FXmlTagModule.A_Module, FXmlTagModule.D_Module);

                // --

                do
                {
                    dt = FCommon.requestFunctionList(m_fSqmCore, system, module, ref nextRowNumber);
                    foreach (DataRow r in dt.Rows)
                    {
                        uniqueIdToString = r[0].ToString();
                        function = r[1].ToString();
                        description = r[2].ToString();
                        // --
                        fXmlNode = FCommon.createXmlNodeIn(FXmlTagFunction.E_Function);
                        fXmlNode.set_elemVal(FXmlTagFunction.A_UniqueId, FXmlTagFunction.D_UniqueId, uniqueIdToString);
                        fXmlNode.set_elemVal(FXmlTagFunction.A_Function, FXmlTagFunction.D_Function, function);
                        fXmlNode.set_elemVal(FXmlTagFunction.A_Description, FXmlTagFunction.D_Description, description);
                        // -- 
                        tNode = tParentNode.Nodes.Add(
                            string.Format(KeyFormat, system, uniqueIdToString),
                            refreshNodeText(function, description)
                            );
                        tNode.Expanded = false;
                        tNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Function"];
                        tNode.Tag = fXmlNode;
                        // -- 
                        refreshTreeOfSqlCode(tNode);
                    }
                } while (nextRowNumber >= 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dt = null;
                fXmlNode = null;
                tNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshTreeOfSqlCode(
            UltraTreeNode tParentNode
            )
        {
            DataTable dt = null;
            UltraTreeNode tNode = null;
            string[] keys = null;
            string system = string.Empty;
            string module = string.Empty;
            string function = string.Empty;
            string usedSqlMigration = string.Empty;
            int nextRowNumber = 0;

            try
            {
                keys = tParentNode.Key.Split(KeySeparator);
                system = keys[0];
                module = ((FXmlNode)tParentNode.Parent.Tag).get_elemVal(FXmlTagModule.A_Module, FXmlTagModule.D_Module);
                function = ((FXmlNode)tParentNode.Tag).get_elemVal(FXmlTagFunction.A_Function, FXmlTagFunction.D_Function);

                // --

                do
                {
                    dt = FCommon.requestSqlCodeList(m_fSqmCore, system, module, function, ref nextRowNumber);
                    foreach (DataRow r in dt.Rows)
                    {
                        tNode = tParentNode.Nodes.Add(
                            string.Format(KeyFormat, system, r[0].ToString()),
                            refreshNodeText(r[1].ToString(), r[2].ToString())
                            );

                        if (r[3].ToString() == FYesNo.Yes.ToString())
                        {
                            tNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["SqlCode"];
                        }
                        else
                        {
                            tNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["SqlCode_NotCompatible"];
                        }
                        tNode.Tag = FCommon.dataRowToSqlCodeNode(r);
                        // -- 
                        //refreshTreeOfSqlQuery(tNode);
                    }
                } while (nextRowNumber >= 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dt = null;
                tNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshTreeOfSqlParameter(
            UltraTreeNode tParentNode
            )
        {
            UltraTreeNode tNode = null;
            string sqlParameter = string.Empty;

            try
            {
                tParentNode.Nodes.Clear();
                foreach (FXmlNode n in ((FXmlNode)tParentNode.Tag).get_elemList(FXmlTagSqlParameter.E_SqlParameter))
                {
                    sqlParameter = n.get_elemVal(FXmlTagSqlParameter.A_SqlParameter, FXmlTagSqlParameter.D_SqlParameter);
                    tNode = tParentNode.Nodes.Add(
                        string.Format("{0}({1})", tParentNode.Key, sqlParameter),
                        sqlParameter
                        );
                    tNode.Expanded = true;
                    tNode.Override.ImageSize = new Size(16, 16);
                    tNode.Override.NodeAppearance.ForeColor = Color.DimGray;
                    tNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Parameter"];
                    tNode.Override.SelectionType = SelectType.None;
                    tNode.Tag = n;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void pasteTreeOfSystem(
            UltraTreeNode copiedNode,
            UltraTreeNode activeNode
            )
        {
            DataTable dt = null;
            FXmlNode fXmlNodePst = null;
            UltraTreeNode tPastedNode = null;
            string system = string.Empty;
            string description = string.Empty;
            string standardDb = string.Empty;

            try
            {
                dt = getPropOfSystem(copiedNode);
                system = generateName((string)dt.Rows[0][1]);
                description = (string)dt.Rows[0][2];
                standardDb = (string)dt.Rows[0][3];

                fXmlNodePst = updateSystem("3", string.Empty, system, description, standardDb, string.Empty);

                // --

                tvwTree.beginUpdate();

                // --

                tPastedNode = new UltraTreeNode(
                    string.Format(KeyFormat, system, "0"),
                    refreshNodeText(fXmlNodePst.get_elemVal(FXmlTagSystem.A_System, FXmlTagSystem.D_System), fXmlNodePst.get_elemVal(FXmlTagSystem.A_Description, FXmlTagSystem.D_Description))
                    );
                tPastedNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["System"];
                tPastedNode.Tag = fXmlNodePst;

                if (activeNode != null)
                {
                    tvwTree.Nodes.Insert(activeNode.Index + 1, tPastedNode);
                }
                else
                {
                    tvwTree.Nodes.Add(tPastedNode);
                }

                foreach (UltraTreeNode t in copiedNode.Nodes)
                {
                    pasteTreeOfModule("3", t, tPastedNode);
                }

                // --

                tvwTree.endUpdate();

                // --

                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tPastedNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dt = null;
                fXmlNodePst = null;
                tPastedNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void pasteTreeOfModule(
            string hStep,
            UltraTreeNode copiedNode,
            UltraTreeNode activeNode
            )
        {
            DataTable dt = null;
            FXmlNode fXmlNodePst = null;
            UltraTreeNode tPastedNode = null;
            string[] keys = null;
            string system = string.Empty;
            string module = string.Empty;
            string desceiption = string.Empty;
            string refUniqueIdToString = string.Empty;

            try
            {
                keys = activeNode.Key.Split(KeySeparator);

                dt = getPropOfModule(copiedNode);
                system = keys[0];
                module = generateName(activeNode, hStep, (string)dt.Rows[0][1]);
                desceiption = (string)dt.Rows[0][2];
                refUniqueIdToString = keys[1];

                fXmlNodePst = updateModule(hStep, system, string.Empty, module, desceiption, refUniqueIdToString);

                // --

                tvwTree.beginUpdate();

                // --

                tPastedNode = new UltraTreeNode(
                    string.Format(KeyFormat, system, fXmlNodePst.get_elemVal(FXmlTagModule.A_UniqueId, FXmlTagModule.D_UniqueId)),
                    refreshNodeText(fXmlNodePst.get_elemVal(FXmlTagModule.A_Module, FXmlTagModule.D_Module), fXmlNodePst.get_elemVal(FXmlTagModule.A_Description, FXmlTagModule.D_Description))
                    );
                tPastedNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Module"];
                tPastedNode.Tag = fXmlNodePst;

                if (hStep == "5")
                {
                    activeNode.Parent.Nodes.Insert(activeNode.Index + 1, tPastedNode);
                }
                else
                {
                    activeNode.Nodes.Add(tPastedNode);
                }

                foreach (UltraTreeNode t in copiedNode.Nodes)
                {
                    pasteTreeOfFunction("3", t, tPastedNode);
                }

                // --

                tvwTree.endUpdate();

                // --

                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tPastedNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dt = null;
                fXmlNodePst = null;
                tPastedNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void pasteTreeOfFunction(
            string hStep,
            UltraTreeNode copiedNode,
            UltraTreeNode activeNode
            )
        {
            DataTable dt = null;
            FXmlNode fXmlNodePst = null;
            UltraTreeNode tPastedNode = null;
            string[] keys = null;
            string system = string.Empty;
            string module = string.Empty;
            string function = string.Empty;
            string description = string.Empty;
            string refUniqueIdToString = string.Empty;

            try
            {
                keys = activeNode.Key.Split(KeySeparator);

                dt = getPropOfFunction(copiedNode);
                system = keys[0];
                module = ((FXmlNode)(hStep == "3" ? activeNode.Tag : activeNode.Parent.Tag)).get_elemVal(FXmlTagModule.A_Module, FXmlTagModule.D_Module);
                function = generateName(activeNode, hStep, (string)dt.Rows[0][1]);
                description = (string)dt.Rows[0][2];
                refUniqueIdToString = keys[1];

                fXmlNodePst = updateFunction(hStep, system, module, string.Empty, function, description, refUniqueIdToString);

                // --

                tvwTree.beginUpdate();

                // --

                tPastedNode = new UltraTreeNode(
                    string.Format(KeyFormat, system, fXmlNodePst.get_elemVal(FXmlTagFunction.A_UniqueId, FXmlTagFunction.D_UniqueId)),
                    refreshNodeText(fXmlNodePst.get_elemVal(FXmlTagFunction.A_Function, FXmlTagFunction.D_Function), fXmlNodePst.get_elemVal(FXmlTagFunction.A_Description, FXmlTagFunction.D_Description))
                    );
                tPastedNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Function"];
                tPastedNode.Tag = fXmlNodePst;

                if (hStep == "5")
                {
                    activeNode.Parent.Nodes.Insert(activeNode.Index + 1, tPastedNode);
                }
                else
                {
                    activeNode.Nodes.Add(tPastedNode);
                }

                foreach (UltraTreeNode t in copiedNode.Nodes)
                {
                    pasteTreeOfSqlCode("3", t, tPastedNode);
                }

                // --

                tvwTree.endUpdate();

                // --

                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tPastedNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dt = null;
                fXmlNodePst = null;
                tPastedNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void pasteTreeOfSqlCode(
            string hStep,
            UltraTreeNode copiedNode,
            UltraTreeNode activeNode
            )
        {
            DataTable dt = null;
            FXmlNode fXmlNodePst = null;
            UltraTreeNode tPastedNode = null;
            string[] keys = null;
            string system = string.Empty;
            string module = string.Empty;
            string function = string.Empty;
            FYesNo usedSqlMigration = FYesNo.Yes;
            string sqlCode = string.Empty;
            string description = string.Empty;
            string msSqlQuery = string.Empty;
            string orcleQuery = string.Empty;
            string mySqlQuery = string.Empty;
            string mariaDbQuery = string.Empty;
            string PostgreSqlQuery = string.Empty;
            string refUniqueIdToString = string.Empty;

            try
            {
                keys = activeNode.Key.Split(KeySeparator);

                dt = getPropOfSqlCode(copiedNode);
                system = keys[0];
                module = ((FXmlNode)(hStep == "3" ? activeNode.Parent.Tag : activeNode.Parent.Parent.Tag)).get_elemVal(FXmlTagModule.A_Module, FXmlTagModule.D_Module);
                function = ((FXmlNode)(hStep == "3" ? activeNode.Tag : activeNode.Parent.Tag)).get_elemVal(FXmlTagFunction.A_Function, FXmlTagFunction.D_Function);
                sqlCode = generateName(activeNode, hStep, (string)dt.Rows[0][1]);
                description = (string)dt.Rows[0][2];
                usedSqlMigration = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][3].ToString());
                msSqlQuery = (string)dt.Rows[0][4];
                orcleQuery = (string)dt.Rows[0][6];
                mySqlQuery = (string)dt.Rows[0][8];
                mariaDbQuery = (string)dt.Rows[0][10];
                PostgreSqlQuery = (string)dt.Rows[0][12];

                refUniqueIdToString = keys[1];

                fXmlNodePst = updateSqlCode(hStep, system, module, function, string.Empty, sqlCode, description, usedSqlMigration, msSqlQuery, orcleQuery, mySqlQuery, mariaDbQuery, PostgreSqlQuery, refUniqueIdToString);

                // --

                tvwTree.beginUpdate();

                // --

                tPastedNode = new UltraTreeNode(
                    string.Format(KeyFormat, system, fXmlNodePst.get_elemVal(FXmlTagSqlCode.A_UniqueId, FXmlTagSqlCode.D_UniqueId)),
                    refreshNodeText(fXmlNodePst.get_elemVal(FXmlTagSqlCode.A_SqlCode, FXmlTagSqlCode.D_SqlCode), fXmlNodePst.get_elemVal(FXmlTagSqlCode.A_Description, FXmlTagSqlCode.D_Description))
                    );
                tPastedNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["SqlCode"];
                tPastedNode.Tag = fXmlNodePst;

                if (hStep == "5")
                {
                    activeNode.Parent.Nodes.Insert(activeNode.Index + 1, tPastedNode);
                }
                else
                {
                    activeNode.Nodes.Add(tPastedNode);
                }

                //refreshTreeOfSqlQuery(tPastedNode);

                // --

                tvwTree.endUpdate();

                // --

                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tPastedNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dt = null;
                fXmlNodePst = null;
                tPastedNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void moveTree(
            string step,
            string system,
            string uniqueIdToString
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSrc = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_TolMove_In.E_SQMSQS_TolMove_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_TolMove_In.A_hLanguage, FSQMSQS_TolMove_In.D_hLanguage, m_fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_TolMove_In.A_hStep, FSQMSQS_TolMove_In.D_hStep, step);

                fXmlNodeInSrc = fXmlNodeIn.set_elem(FSQMSQS_TolMove_In.FSource.E_Source);
                fXmlNodeInSrc.set_elemVal(FSQMSQS_TolMove_In.FSource.A_System, FSQMSQS_TolMove_In.FSource.D_System, system);
                fXmlNodeInSrc.set_elemVal(FSQMSQS_TolMove_In.FSource.A_UniqueId, FSQMSQS_TolMove_In.FSource.D_UniqueId, uniqueIdToString);

                FSQMSQSCaster.SQMSQS_TolMove_Req(
                    m_fSqmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );

                if (fXmlNodeOut.get_elemVal(FSQMSQS_TolMove_Out.A_hStatus, FSQMSQS_TolMove_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_TolMove_Out.A_hStatusMessage, FSQMSQS_TolMove_Out.D_hStatusMessage));
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInSrc = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FXmlNode removeTreeOfSystem(
            UltraTreeNode tNode
            )
        {
            string[] keys = null;
            string uniqueIdToString = string.Empty;
            string system = string.Empty;
            string standardDb = string.Empty;

            try
            {
                keys = tNode.Key.Split(KeySeparator);
                system = keys[0];
                uniqueIdToString = keys[1];

                // --

                return updateSystem("2", uniqueIdToString, system, string.Empty, string.Empty, string.Empty);
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

        private FXmlNode removeTreeOfModule(
            UltraTreeNode tNode
            )
        {
            string[] keys = null;
            string system = string.Empty;
            string uniqueIdToString = string.Empty;
            string module = string.Empty;

            try
            {
                keys = tNode.Key.Split(KeySeparator);
                system = keys[0];
                uniqueIdToString = keys[1];
                module = ((FXmlNode)tNode.Tag).get_elemVal(FXmlTagModule.A_Module, FXmlTagModule.D_Module);

                // --

                return updateModule("2", system, uniqueIdToString, module, string.Empty, string.Empty);
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

        private FXmlNode removeTreeOfFunction(
            UltraTreeNode tNode
            )
        {
            string[] keys = null;
            string system = string.Empty;
            string module = string.Empty;
            string uniqueIdToString = string.Empty;
            string function = string.Empty;

            try
            {
                keys = tNode.Key.Split(KeySeparator);
                system = keys[0];
                module = ((FXmlNode)tNode.Parent.Tag).get_elemVal(FXmlTagModule.A_Module, FXmlTagModule.D_Module);
                uniqueIdToString = keys[1];
                function = ((FXmlNode)tNode.Tag).get_elemVal(FXmlTagFunction.A_Function, FXmlTagFunction.D_Function);

                // --

                return updateFunction("2", system, module, uniqueIdToString, function, string.Empty, string.Empty);
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

        private FXmlNode removeTreeOfSqlCode(
            UltraTreeNode tNode
            )
        {
            string[] keys = null;
            string system = string.Empty;
            string module = string.Empty;
            string function = string.Empty;
            string uniqueIdToString = string.Empty;
            string sqlCode = string.Empty;

            try
            {
                keys = tNode.Key.Split(KeySeparator);
                system = keys[0];
                module = ((FXmlNode)tNode.Parent.Parent.Tag).get_elemVal(FXmlTagModule.A_Module, FXmlTagModule.D_Module);
                function = ((FXmlNode)tNode.Parent.Tag).get_elemVal(FXmlTagFunction.A_Function, FXmlTagFunction.D_Function);
                uniqueIdToString = keys[1];
                sqlCode = ((FXmlNode)tNode.Tag).get_elemVal(FXmlTagSqlCode.A_SqlCode, FXmlTagSqlCode.D_SqlCode);

                // --

                return updateSqlCode("2", system, module, function, uniqueIdToString, sqlCode, string.Empty, FYesNo.Yes, string.Empty,string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
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

        private FXmlNode appendTreeOfSystem(
            string hStep
            )
        {
            string system = string.Empty;

            try
            {
                system = generateName("System");

                // --

                return updateSystem(hStep, "0", system, string.Empty, FDbProvider.MsSqlServer.ToString(), string.Empty);
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

        private FXmlNode appendTreeOfModule(
            string hStep,
            UltraTreeNode tNode
            )
        {
            string[] keys = null;
            string system = string.Empty;
            string module = string.Empty;
            string uniqueIdToString = string.Empty;

            try
            {
                keys = tNode.Key.Split(KeySeparator);
                system = keys[0];
                uniqueIdToString = keys[1];
                module = generateName(tNode, hStep, "Module");

                // --

                return updateModule(hStep, system, string.Empty, module, string.Empty, uniqueIdToString);
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

        private FXmlNode appendTreeOfFunction(
            string hStep,
            UltraTreeNode tNode
            )
        {
            string[] keys = null;
            string system = string.Empty;
            string module = string.Empty;
            string function = string.Empty;
            string uniqueIdToString = string.Empty;

            try
            {
                keys = tNode.Key.Split(KeySeparator);
                system = keys[0];
                uniqueIdToString = keys[1];
                module = ((FXmlNode)((hStep == "3") ? tNode.Tag : tNode.Parent.Tag)).get_elemVal(FXmlTagModule.A_Module, FXmlTagModule.D_Module);
                function = generateName(tNode, hStep, "Function");

                // --

                return updateFunction(hStep, system, module, string.Empty, function, string.Empty, uniqueIdToString);
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

        private FXmlNode appendTreeOfSqlCode(
            string hStep,
            UltraTreeNode tNode
            )
        {
            string[] keys = null;
            string system = string.Empty;
            string module = string.Empty;
            string function = string.Empty;
            string sqlCode = string.Empty;
            string uniqueIdToString = string.Empty;

            try
            {
                keys = tNode.Key.Split(KeySeparator);
                system = keys[0];
                uniqueIdToString = keys[1];

                if (hStep == "3")
                {
                    module = ((FXmlNode)tNode.Parent.Tag).get_elemVal(FXmlTagModule.A_Module, FXmlTagModule.D_Module);
                    function = ((FXmlNode)tNode.Tag).get_elemVal(FXmlTagFunction.A_Function, FXmlTagFunction.D_Function);
                }
                else 
                {
                    module = ((FXmlNode)tNode.Parent.Parent.Tag).get_elemVal(FXmlTagModule.A_Module, FXmlTagModule.D_Module);
                    function = ((FXmlNode)tNode.Parent.Tag).get_elemVal(FXmlTagFunction.A_Function, FXmlTagFunction.D_Function);
                }

                sqlCode = generateName(tNode, hStep, "SQLCode");

                // --

                return updateSqlCode(hStep, system, module, function, string.Empty, sqlCode, string.Empty, FYesNo.Yes, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, uniqueIdToString);
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

        private FXmlNode updateTreeOfSystem(
            FPropSystem fPropSystem,
            string system
            )
        {
            try
            {
                return updateSystem("6", fPropSystem.ID, fPropSystem.System, fPropSystem.Description, fPropSystem.StandardDb.ToString(), system);
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

        private FXmlNode updateTreeOfModule(
            FPropModule fPropModule
            )
        {
            try
            {
                return updateModule("6", fPropModule.System, fPropModule.ID, fPropModule.Module, fPropModule.Description, string.Empty);
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

        private FXmlNode updateTreeOfFunction(
            FPropFunction fPropFunction
            )
        {
            try
            {
                return updateFunction("6", fPropFunction.System, fPropFunction.Module, fPropFunction.ID, fPropFunction.Function, fPropFunction.Description, string.Empty);
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

        private FXmlNode updateTreeOfSqlCode(
            FPropSqlCode fPropSqlCode
            )
        {
            try
            {
                return updateSqlCode("6", fPropSqlCode.System, fPropSqlCode.Module, fPropSqlCode.Function, fPropSqlCode.ID, fPropSqlCode.SqlCode, fPropSqlCode.Description, fPropSqlCode.UsedMigration,
                    fPropSqlCode.MsSqlQuery, fPropSqlCode.OracleQuery, fPropSqlCode.MySqlQuery, fPropSqlCode.MariaDbQuery, fPropSqlCode.PostgreSqlQuery, string.Empty);
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

        private bool searchTree(
            UltraTreeNode tStartNode,
            UltraTreeNode tSearchNode,
            string str,
            ref UltraTreeNode tResultNode
            )
        {
            try
            {
                if (((FXmlNode)tSearchNode.Tag).name == FXmlTagSqlCode.E_SqlCode)
                {
                    return true;
                }

                foreach (UltraTreeNode t in tSearchNode.Nodes)
                {
                    if (t == tStartNode)
                    {
                        if (t.Text.ToLower().IndexOf(str.ToLower()) > -1)
                        {
                            tResultNode = t;
                        }
                        return false;
                    }

                    if (t.Text.ToLower().IndexOf(str.ToLower()) > -1)
                    {
                        tResultNode = t;
                        return false;
                    }

                    if (((FXmlNode)t.Tag).name != FXmlTagSqlCode.E_SqlCode)
                    {
                        if (
                            searchTree(tStartNode, t, str, ref tResultNode) == false ||
                            tResultNode != null
                           )
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return true;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private UltraTreeNode getNextSibling(
            UltraTreeNode tNode
            )
        {
            UltraTreeNode tNextNode = null;

            try
            {
                tNextNode = tNode.GetSibling(NodePosition.Next);

                while (tNextNode == null)
                {
                    tNextNode = tNode.Parent == null ? tvwTree.Nodes[0] : getNextSibling(tNode.Parent);
                }

                return tNextNode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return tNode;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRefresh(
            )
        {
            try
            {
                refreshTreeOfSystem();
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
            try
            {
                tvwTree.beginUpdate();
                expand(tvwTree.ActiveNode, true);
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

        private void procMenuCollapse(
            )
        {
            try
            {
                tvwTree.beginUpdate();
                expand(tvwTree.ActiveNode, false);
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

        private void procMenuCompatible(
            )
        {
            bool visible = false;

            try
            {
                tvwTree.beginUpdate();

                // --

                visible = ((StateButtonTool)mnuMenu.Tools[FMenuKey.MenuSqeCompatible]).Checked ? false : true;

                // --

                foreach (UltraTreeNode tNodeSys in tvwTree.Nodes)
                {
                    foreach (UltraTreeNode tNodeMod in tNodeSys.Nodes)
                    {
                        foreach (UltraTreeNode tNodeFun in tNodeMod.Nodes)
                        {
                            foreach (UltraTreeNode tNodeSqc in tNodeFun.Nodes)
                            {
                                if (((StateButtonTool)mnuMenu.Tools[FMenuKey.MenuSqeCompatible]).Checked == false)
                                {
                                    tNodeSqc.Visible = true;
                                }
                                else
                                {
                                    tNodeSqc.Visible = ((FXmlNode)tNodeSqc.Tag).get_elemVal(FXmlTagSqlCode.A_UsedSqlMigration, FXmlTagSqlCode.D_UsedSqlMigration) == FYesNo.No.ToString() ? 
                                        true : false;
                                }
                            }
                            tNodeFun.Visible = tNodeFun.HasVisibleNodes ? true : false;
                        }
                        tNodeMod.Visible = tNodeMod.HasVisibleNodes ? true : false;
                    }
                    tNodeSys.Visible = tNodeSys.HasVisibleNodes ? true : false;
                }                

                // --

                tvwTree.endUpdate();

                // --

                tvwTree.ActiveNode.BringIntoView();
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

        private void procMenuRemove(
            )
        {
            FXmlNode n = null;
            UltraTreeNode[] tSelectedNodes = null;
            UltraTreeNode tDeleteNode = null;
            UltraTreeNode tActiveNode = null;
            DialogResult dialogResult;
            string key = string.Empty;

            try
            {
                n = (FXmlNode)tvwTree.ActiveNode.Tag;
                if (n.name == FXmlTagSystem.E_System)
                {
                    key = "System";
                }
                else if (n.name == FXmlTagModule.E_Module)
                {
                    key = "Module";
                }
                else if (n.name == FXmlTagFunction.E_Function)
                {
                    key = "Function";
                }
                if (n.name == FXmlTagSqlCode.E_SqlCode)
                {
                    key = "SQL Code";
                }
                // --
                dialogResult = FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fSqmCore.fWsmCore.fUIWizard.generateMessage("Q0004", new object[] { key }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    m_fSqmCore.fWsmCore.fWsmContainer
                    );
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                // --

                //tvwTree.beginUpdate();

                // --

                tSelectedNodes = new UltraTreeNode[tvwTree.SelectedNodes.Count];
                for (int i = 0; i < tSelectedNodes.Length; i++)
                {
                    tSelectedNodes[i] = tvwTree.SelectedNodes[i];
                }

                for (int i = tSelectedNodes.Length - 1; i >= 0; i--)
                {
                    tDeleteNode = tSelectedNodes[i];
                    n = (FXmlNode)tDeleteNode.Tag;
                    if (n.name == FXmlTagSystem.E_System)
                    {
                        removeTreeOfSystem(tDeleteNode);
                    }
                    else if (n.name == FXmlTagModule.E_Module)
                    {
                        removeTreeOfModule(tDeleteNode);
                    }
                    else if (n.name == FXmlTagFunction.E_Function)
                    {
                        removeTreeOfFunction(tDeleteNode);
                    }
                    else if (n.name == FXmlTagSqlCode.E_SqlCode)
                    {
                        removeTreeOfSqlCode(tDeleteNode);
                    }

                    // --

                    tActiveNode = tDeleteNode.GetSibling(NodePosition.Next);
                    if (tActiveNode == null)
                    {
                        tActiveNode = tDeleteNode.GetSibling(NodePosition.Previous);
                        if (tActiveNode == null)
                        {
                            tActiveNode = tDeleteNode.GetSibling(NodePosition.Previous);
                        }
                    }
                    if (tActiveNode == null && tDeleteNode.Parent != null)
                    {
                        tActiveNode = tDeleteNode.Parent;
                    }

                    if (tvwTree.GetNodeCount(true) == 1)
                    {
                        tvwTree.Nodes.Clear();
                    }
                    else
                    {
                        tDeleteNode.Remove();
                    }
                }

                // --

                //tvwTree.endUpdate();

                // --

                tvwTree.SelectedNodes.Clear();
                if (tActiveNode != null)
                {
                    tvwTree.ActiveNode = tActiveNode;
                }
                tvwTree.ActiveNode.Selected = true;
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                n = null;
                tSelectedNodes = null;
                tDeleteNode = null;
                tActiveNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCopy(
            )
        {
            FXmlNode n = null;
            UltraTreeNode t = null;

            try
            {
                if (tvwTree.ActiveNode == null)
                {
                    return;
                }

                // --

                t = tvwTree.ActiveNode;
                n = (FXmlNode)t.Tag;
                // --
                if (n.name == FXmlTagSystem.E_System)
                {
                    FClipboard.setData(FCbFormatSystem, t);
                }
                else if (n.name == FXmlTagModule.E_Module)
                {
                    FClipboard.setData(FCbFormatModule, t);
                }
                else if (n.name == FXmlTagFunction.E_Function)
                {
                    FClipboard.setData(FCbFormatFunction, t);
                }
                else if (n.name == FXmlTagSqlCode.E_SqlCode)
                {
                    FClipboard.setData(FCbFormatSqlCode, t);
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
                n = null;
                t = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCut(
            )
        {
            try
            {
                if (tvwTree.ActiveNode == null)
                {
                    return;
                }

                // --

                procMenuCopy();

                // --
                
                tvwTree.BeginUpdate();
                tvwTree.ActiveNode.Remove();
                tvwTree.endUpdate();

                // --

                controlMenu();
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

        private void procMenuPaste(
            )
        {
            FXmlNode n = null;
            UltraTreeNode tActiveNode = null;
            UltraTreeNode tCopiedNode = null;

            try
            {
                tActiveNode = tvwTree.ActiveNode;
                if (tActiveNode == null)
                {
                    if (FClipboard.containsData(FCbFormatSystem))
                    {
                        tCopiedNode = (UltraTreeNode)FClipboard.getData(FCbFormatSystem);
                        pasteTreeOfSystem(tCopiedNode, null);
                    }
                }
                else
                {
                    n = (FXmlNode)tActiveNode.Tag;
                    if (n.name == FXmlTagSystem.E_System)
                    {
                        if (FClipboard.containsData(FCbFormatSystem))
                        {
                            tCopiedNode = (UltraTreeNode)FClipboard.getData(FCbFormatSystem);
                            pasteTreeOfSystem(tCopiedNode, tActiveNode);
                        }
                        else if (FClipboard.containsData(FCbFormatModule))
                        {
                            tCopiedNode = (UltraTreeNode)FClipboard.getData(FCbFormatModule);
                            pasteTreeOfModule("3", tCopiedNode, tActiveNode);
                        }
                    }
                    else if (n.name == FXmlTagModule.E_Module)
                    {
                        if (FClipboard.containsData(FCbFormatModule))
                        {
                            tCopiedNode = (UltraTreeNode)FClipboard.getData(FCbFormatModule);
                            pasteTreeOfModule("5", tCopiedNode, tActiveNode);
                        }
                        else if (FClipboard.containsData(FCbFormatFunction))
                        {
                            tCopiedNode = (UltraTreeNode)FClipboard.getData(FCbFormatFunction);
                            pasteTreeOfFunction("3", tCopiedNode, tActiveNode);
                        }
                    }
                    else if (n.name == FXmlTagFunction.E_Function)
                    {
                        if (FClipboard.containsData(FCbFormatFunction))
                        {
                            tCopiedNode = (UltraTreeNode)FClipboard.getData(FCbFormatFunction);
                            pasteTreeOfFunction("5", tCopiedNode, tActiveNode);
                        }
                        else if (FClipboard.containsData(FCbFormatSqlCode))
                        {
                            tCopiedNode = (UltraTreeNode)FClipboard.getData(FCbFormatSqlCode);
                            pasteTreeOfSqlCode("3", tCopiedNode, tActiveNode);
                        }
                    }
                    else if (n.name == FXmlTagSqlCode.E_SqlCode)
                    {
                        if (FClipboard.containsData(FCbFormatSqlCode))
                        {
                            tCopiedNode = (UltraTreeNode)FClipboard.getData(FCbFormatSqlCode);
                            pasteTreeOfSqlCode("5", tCopiedNode, tActiveNode);
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
                n = null;
                tActiveNode = null;
                tCopiedNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuMoveUp(
            )
        {
            UltraTreeNode tActiveNode = null;
            UltraTreeNode[] selectedNodes = null;
            string[] keys = null;

            try
            {
                tActiveNode = tvwTree.ActiveNode;

                // --

                tvwTree.beginUpdate();

                // --
          
                selectedNodes = new UltraTreeNode[tvwTree.SelectedNodes.Count];
                for (int i = 0; i <= selectedNodes.GetLength(0) - 1; i++)
                {
                    selectedNodes[i] = tvwTree.SelectedNodes[0];
                    keys = selectedNodes[i].Key.Split(KeySeparator);
                    moveTree("1", keys[0], keys[1]);
                    tvwTree.moveUpNode(selectedNodes[i]);
                }

                // --

                tvwTree.endUpdate();

                // --

                tvwTree.SelectedNodes.Clear();
                for (int i = 0; i <= selectedNodes.GetLength(0) - 1; i++)
                {
                    selectedNodes[i].Selected = true;
                    if (selectedNodes[i] == tActiveNode)
                    {
                        tvwTree.ActiveNode = selectedNodes[i];
                    }
                }
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tActiveNode = null;
                selectedNodes = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuMoveDown(
            )
        {
            UltraTreeNode tActiveNode = null;
            UltraTreeNode[] selectedNodes = null;
            string[] keys = null;

            try
            {
                tActiveNode = tvwTree.ActiveNode;

                // --

                tvwTree.beginUpdate();

                // --

                selectedNodes = new UltraTreeNode[tvwTree.SelectedNodes.Count];
                for (int i = tvwTree.SelectedNodes.Count - 1; i >= 0; i--)
                {
                    selectedNodes[i] = tvwTree.SelectedNodes[i];
                    keys = selectedNodes[i].Key.Split(KeySeparator);
                    moveTree("2", keys[0], keys[1]);
                    tvwTree.moveDownNode(tvwTree.SelectedNodes[i]);
                }

                // --

                tvwTree.endUpdate();

                // --

                tvwTree.SelectedNodes.Clear();
                for (int i = 0; i <= selectedNodes.GetLength(0) - 1; i++)
                {
                    selectedNodes[i].Selected = true;
                    if (selectedNodes[i] == tActiveNode)
                    {
                        tvwTree.ActiveNode = selectedNodes[i];
                    }
                }
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tActiveNode = null;
                selectedNodes = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuDownload(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSys = null;
            FXmlNode fXmlNodeInDbs = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutSys = null;
            FFtp fFtp = null;
            FDatabaseSelector dialog = null;
            FolderBrowserDialog fbd = null;
            DialogResult dialogResult;
            string tempFilePath = string.Empty;
            string zipFileName = string.Empty;
            string [] downDbList = null;

            try
            {
                dialog = new  FDatabaseSelector(
                    m_fSqmCore
                    );
                if (dialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                fbd = new FolderBrowserDialog();
                fbd.SelectedPath = m_fSqmCore.fOption.recentDownloadPath;
                if (fbd.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                m_fSqmCore.fOption.recentDownloadPath = fbd.SelectedPath;

                // --

                fFtp = FCommon.createFtp(m_fSqmCore);
                
                // --

                // ***
                // Temp Directory create
                // ***
                tempFilePath = Path.Combine(m_fSqmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetSystemDownload_In.E_SQMSQS_SetSystemDownload_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSystemDownload_In.A_hLanguage, FSQMSQS_SetSystemDownload_In.D_hLanguage, m_fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSystemDownload_In.A_hStep, FSQMSQS_SetSystemDownload_In.D_hStep, "1");
                // --
                fXmlNodeInDbs = fXmlNodeIn.set_elem(FSQMSQS_SetSystemDownload_In.FDatabase.E_Database);

                // --

                downDbList = m_fSqmCore.fOption.downloadDatabase.Split(';');
                // --
                foreach (string db in downDbList)
                {
                    fXmlNodeInDbs.add_elemVal(FSQMSQS_SetSystemDownload_In.FDatabase.A_Type, FSQMSQS_SetSystemDownload_In.FDatabase.D_Type, db);
                }

                // --

                fXmlNodeInSys = fXmlNodeIn.set_elem(FSQMSQS_SetSystemDownload_In.FSystem.E_System);
                // --
                foreach (UltraTreeNode t in tvwTree.SelectedNodes)
                {
                    fXmlNodeInSys.set_elemVal(FSQMSQS_SetSystemDownload_In.FSystem.A_System, FSQMSQS_SetSystemDownload_In.FSystem.D_System, t.Key.Split(KeySeparator)[0]);
                    // --
                    FSQMSQSCaster.SQMSQS_SetSystemDownload_Req(
                        m_fSqmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FSQMSQS_SetSystemDownload_Out.A_hStatus, FSQMSQS_SetSystemDownload_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_SetSystemDownload_Out.A_hStatusMessage, FSQMSQS_SetSystemDownload_Out.D_hStatusMessage));
                    }

                    // ***
                    // FTP File download
                    // ***
                    fXmlNodeOutSys = fXmlNodeOut.get_elem(FSQMSQS_SetSystemDownload_Out.FSystem.E_System);
                    zipFileName = fXmlNodeOutSys.get_elemVal(FSQMSQS_SetSystemDownload_Out.FSystem.A_FilePath, FSQMSQS_SetSystemDownload_Out.FSystem.D_FilePath);

                    // --

                    fFtp.downloadFiles(tempFilePath, zipFileName);
                    fFtp.deleteFiles(zipFileName);

                    // --

                    F7Zip.unpack(tempFilePath + "\\" + zipFileName, fbd.SelectedPath);
                }

                // --

                // ***
                // Temp Directory delete
                // ***
                Directory.Delete(tempFilePath, true);

                // --

                // ***
                // Folder open
                // ***
                dialogResult = FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fSqmCore.fUIWizard.generateMessage("Q0005"),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    );
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                // -- 

                Process.Start("explorer.exe", fbd.SelectedPath);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInSys = null;
                fXmlNodeInDbs = null;
                fXmlNodeOut = null;
                fXmlNodeOutSys = null;
                fbd = null;
                fFtp = null;
                dialog = null;

                // --

                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuMigration(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSys = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fSqmCore.fUIWizard.generateMessage("Q0022", new object[] { "Migration" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetSystemMigration_In.E_SQMSQS_SetSystemMigration_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSystemMigration_In.A_hLanguage, FSQMSQS_SetSystemMigration_In.D_hLanguage, m_fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSystemMigration_In.A_hStep, FSQMSQS_SetSystemMigration_In.D_hStep, "1");
                
                // --

                fXmlNodeInSys = fXmlNodeIn.set_elem(FSQMSQS_SetSystemMigration_In.FSystem.E_System);
                // --
                foreach (UltraTreeNode t in tvwTree.SelectedNodes)
                {
                    fXmlNodeInSys.set_elemVal(FSQMSQS_SetSystemMigration_In.FSystem.A_System, FSQMSQS_SetSystemMigration_In.FSystem.D_System, t.Key.Split(KeySeparator)[0]);
                    // --
                    FSQMSQSCaster.SQMSQS_SetSystemMigration_Req(
                        m_fSqmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FSQMSQS_SetSystemMigration_Out.A_hStatus, FSQMSQS_SetSystemMigration_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_SetSystemMigration_Out.A_hStatusMessage, FSQMSQS_SetSystemMigration_Out.D_hStatusMessage));
                    }
                }

                // --

                FMessageBox.showInformation(FConstants.ApplicationName, m_fSqmCore.fWsmCore.fUIWizard.generateMessage("M0012"), this);

            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInSys = null;
                fXmlNodeOut = null;

                // --

                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuViewParameter(
            )
        {
            FParameterViewer fParameterViewer = null;

            try
            {
                if (tvwTree.ActiveNode == null)
                {
                    return;
                }

                // --

                fParameterViewer = new FParameterViewer(m_fSqmCore, (FXmlNode)tvwTree.ActiveNode.Tag);
                fParameterViewer.ShowDialog(this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fParameterViewer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuExecuteSql(
            )
        {
            FSqlWorksheet fSqlWorksheet = null;
            string[] keys = null;
            string system = string.Empty;
            string module = string.Empty;
            string function = string.Empty;
            string uniqueIdToString = string.Empty;
            string sqlCode = string.Empty;

            try
            {
                keys = tvwTree.ActiveNode.Key.Split(KeySeparator);
                system = keys[0];
                uniqueIdToString = keys[1];
                module = ((FXmlNode)tvwTree.ActiveNode.Parent.Parent.Tag).get_elemVal(FXmlTagModule.A_Module, FXmlTagModule.D_Module);
                function = ((FXmlNode)tvwTree.ActiveNode.Parent.Tag).get_elemVal(FXmlTagFunction.A_Function, FXmlTagFunction.D_Function);
                sqlCode = ((FXmlNode)tvwTree.ActiveNode.Tag).get_elemVal(FXmlTagSqlCode.A_SqlCode, FXmlTagSqlCode.D_SqlCode);                
                // --
                fSqlWorksheet = new FSqlWorksheet(m_fSqmCore);
                m_fSqmCore.fSqmContainer.showChild(fSqlWorksheet);
                fSqlWorksheet.activate();
                fSqlWorksheet.appendSqlCode(system, module, function, uniqueIdToString, sqlCode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlWorksheet = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAppendSystem(
            )
        {
            UltraTreeNode tAppendNode = null;
            FXmlNode fXmlNode = null;
            string system = string.Empty;

            try
            {
                fXmlNode = appendTreeOfSystem("3");
                system = fXmlNode.get_elemVal(FXmlTagSystem.A_System, FXmlTagSystem.D_System);

                // --

                tvwTree.beginUpdate();

                // --

                tAppendNode = new UltraTreeNode(
                    string.Format(KeyFormat, system, "0"),
                    refreshNodeText(system, fXmlNode.get_elemVal(FXmlTagSystem.A_Description, FXmlTagSystem.D_Description))
                    );
                tAppendNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["System"];
                tAppendNode.Tag = fXmlNode;

                tvwTree.Nodes.Add(tAppendNode);

                // --

                tvwTree.endUpdate();

                // --

                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tAppendNode;
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tAppendNode = null;
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAppendModule(
            )
        {
            UltraTreeNode tActiveNode = null;
            UltraTreeNode tAppendNode = null;
            FXmlNode fXmlNode = null;

            try
            {
                tActiveNode = tvwTree.ActiveNode;
                fXmlNode = appendTreeOfModule("3", tActiveNode);

                // --

                tvwTree.beginUpdate();

                // --
                
                tAppendNode = new UltraTreeNode(
                    string.Format(KeyFormat, tActiveNode.Key.Split(KeySeparator)[0], fXmlNode.get_elemVal(FXmlTagModule.A_UniqueId, FXmlTagModule.D_UniqueId)),
                    refreshNodeText(fXmlNode.get_elemVal(FXmlTagModule.A_Module, FXmlTagModule.D_Module), fXmlNode.get_elemVal(FXmlTagModule.A_Description, FXmlTagModule.D_Description))
                    );
                tAppendNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Module"];
                tAppendNode.Tag = fXmlNode;

                tActiveNode.Nodes.Add(tAppendNode);

                // --

                tvwTree.endUpdate();

                // --

                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tAppendNode;
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tActiveNode = null;
                tAppendNode = null;
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuInsertBeforeModule(
            )
        {
            UltraTreeNode tActiveNode = null;
            UltraTreeNode tInsertNode = null;
            FXmlNode fXmlNode = null;

            try
            {
                tActiveNode = tvwTree.ActiveNode;
                fXmlNode = appendTreeOfModule("4", tActiveNode);

                // --

                tvwTree.beginUpdate();

                // --

                tInsertNode = new UltraTreeNode(
                    string.Format(KeyFormat, tActiveNode.Key.Split(KeySeparator)[0], fXmlNode.get_elemVal(FXmlTagModule.A_UniqueId, FXmlTagModule.D_UniqueId)),
                    refreshNodeText(fXmlNode.get_elemVal(FXmlTagModule.A_Module, FXmlTagModule.D_Module), fXmlNode.get_elemVal(FXmlTagModule.A_Description, FXmlTagModule.D_Description))
                    );
                tInsertNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Module"];
                tInsertNode.Tag = fXmlNode;

                tActiveNode.Parent.Nodes.Insert(tActiveNode.Index, tInsertNode);

                // --

                tvwTree.endUpdate();

                // --

                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tInsertNode;
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tActiveNode = null;
                tInsertNode = null;
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuInsertAfterModule(
            )
        {
            UltraTreeNode tActiveNode = null;
            UltraTreeNode tInsertNode = null;
            FXmlNode fXmlNode = null;

            try
            {
                tActiveNode = tvwTree.ActiveNode;
                fXmlNode = appendTreeOfModule("5", tActiveNode);

                // --

                tvwTree.beginUpdate();

                tInsertNode = new UltraTreeNode(
                    string.Format(KeyFormat, tActiveNode.Key.Split(KeySeparator)[0], fXmlNode.get_elemVal(FXmlTagModule.A_UniqueId, FXmlTagModule.D_UniqueId)),
                    refreshNodeText(fXmlNode.get_elemVal(FXmlTagModule.A_Module, FXmlTagModule.D_Module), fXmlNode.get_elemVal(FXmlTagModule.A_Description, FXmlTagModule.D_Description))
                    );
                tInsertNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Module"];
                tInsertNode.Tag = fXmlNode;

                tActiveNode.Parent.Nodes.Insert(tActiveNode.Index + 1, tInsertNode);

                // --

                tvwTree.endUpdate();

                // --

                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tInsertNode;
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tActiveNode = null;
                tInsertNode = null;
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAppendFunction(
            )
        {
            UltraTreeNode tActiveNode = null;
            UltraTreeNode tAppendNode = null;
            FXmlNode fXmlNode = null;

            try
            {
                tActiveNode = tvwTree.ActiveNode;
                fXmlNode = appendTreeOfFunction("3", tActiveNode);

                // --

                tvwTree.beginUpdate();

                // --

                tAppendNode = new UltraTreeNode(
                    string.Format(KeyFormat, tActiveNode.Key.Split(KeySeparator)[0], fXmlNode.get_elemVal(FXmlTagFunction.A_UniqueId, FXmlTagFunction.D_UniqueId)),
                    refreshNodeText(fXmlNode.get_elemVal(FXmlTagFunction.A_Function, FXmlTagFunction.D_Function), fXmlNode.get_elemVal(FXmlTagFunction.A_Description, FXmlTagFunction.D_Description))
                    );
                tAppendNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Function"];
                tAppendNode.Tag = fXmlNode;

                tActiveNode.Nodes.Add(tAppendNode);

                // --

                tvwTree.endUpdate();

                // --

                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tAppendNode;
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tActiveNode = null;
                tAppendNode = null;
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuInsertBeforeFunction(
            )
        {
            UltraTreeNode tActiveNode = null;
            UltraTreeNode tInsertNode = null;
            FXmlNode fXmlNode = null;

            try
            {
                tActiveNode = tvwTree.ActiveNode;
                fXmlNode = appendTreeOfFunction("4", tActiveNode);

                // --

                tvwTree.beginUpdate();

                // --

                tInsertNode = new UltraTreeNode(
                    string.Format(KeyFormat, tActiveNode.Key.Split(KeySeparator)[0], fXmlNode.get_elemVal(FXmlTagFunction.A_UniqueId, FXmlTagFunction.D_UniqueId)),
                    refreshNodeText(fXmlNode.get_elemVal(FXmlTagFunction.A_Function, FXmlTagFunction.D_Function), fXmlNode.get_elemVal(FXmlTagFunction.A_Description, FXmlTagFunction.D_Description))
                    );
                tInsertNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Function"];
                tInsertNode.Tag = fXmlNode;

                tActiveNode.Parent.Nodes.Insert(tActiveNode.Index, tInsertNode);
                
                // --

                tvwTree.endUpdate();

                // --

                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tInsertNode;
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tActiveNode = null;
                tInsertNode = null;
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuInsertAfterFunction(
            )
        {
            UltraTreeNode tActiveNode = null;
            UltraTreeNode tInsertNode = null;
            FXmlNode fXmlNode = null;

            try
            {
                tActiveNode = tvwTree.ActiveNode;
                fXmlNode = appendTreeOfFunction("5", tActiveNode);

                // --

                tvwTree.beginUpdate();

                // --

                tInsertNode = new UltraTreeNode(
                    string.Format(KeyFormat, tActiveNode.Key.Split(KeySeparator)[0], fXmlNode.get_elemVal(FXmlTagFunction.A_UniqueId, FXmlTagFunction.D_UniqueId)),
                    refreshNodeText(fXmlNode.get_elemVal(FXmlTagFunction.A_Function, FXmlTagFunction.D_Function), fXmlNode.get_elemVal(FXmlTagFunction.A_Description, FXmlTagFunction.D_Description))
                    );
                tInsertNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Function"];
                tInsertNode.Tag = fXmlNode;

                tActiveNode.Parent.Nodes.Insert(tActiveNode.Index + 1, tInsertNode);

                // --

                tvwTree.endUpdate();

                // --

                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tInsertNode;
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tActiveNode = null;
                tInsertNode = null;
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAppendSqlCode(
            )
        {
            UltraTreeNode tActiveNode = null;
            UltraTreeNode tAppendNode = null;
            FXmlNode fXmlNode = null;

            try
            {
                tActiveNode = tvwTree.ActiveNode;
                fXmlNode = appendTreeOfSqlCode("3", tActiveNode);

                // --

                tvwTree.beginUpdate();

                // --

                tAppendNode = new UltraTreeNode(
                    string.Format(KeyFormat, tActiveNode.Key.Split(KeySeparator)[0], fXmlNode.get_elemVal(FXmlTagSqlCode.A_UniqueId, FXmlTagSqlCode.D_UniqueId)),
                    refreshNodeText(fXmlNode.get_elemVal(FXmlTagSqlCode.A_SqlCode, FXmlTagSqlCode.D_SqlCode), fXmlNode.get_elemVal(FXmlTagSqlCode.A_Description, FXmlTagSqlCode.D_Description))
                    );
                tAppendNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["SqlCode"];
                tAppendNode.Tag = fXmlNode;

                tActiveNode.Nodes.Add(tAppendNode);

                // --

                tvwTree.endUpdate();

                // --

                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tAppendNode;
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tActiveNode = null;
                tAppendNode = null;
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuInsertBeforeSqlCode(
            )
        {
            UltraTreeNode tActiveNode = null;
            UltraTreeNode tInsertNode = null;
            FXmlNode fXmlNode = null;

            try
            {
                tActiveNode = tvwTree.ActiveNode;
                fXmlNode = appendTreeOfSqlCode("4", tActiveNode);

                // --

                tvwTree.beginUpdate();

                // --

                tInsertNode = new UltraTreeNode(
                    string.Format(KeyFormat, tActiveNode.Key.Split(KeySeparator)[0], fXmlNode.get_elemVal(FXmlTagSqlCode.A_UniqueId, FXmlTagSqlCode.D_UniqueId)),
                    refreshNodeText(fXmlNode.get_elemVal(FXmlTagSqlCode.A_SqlCode, FXmlTagSqlCode.D_SqlCode), fXmlNode.get_elemVal(FXmlTagSqlCode.A_Description, FXmlTagSqlCode.D_Description))
                    );
                tInsertNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["SqlCode"];
                tInsertNode.Tag = fXmlNode;

                tActiveNode.Parent.Nodes.Insert(tActiveNode.Index, tInsertNode);

                // --

                tvwTree.endUpdate();

                // --

                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tInsertNode;
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tActiveNode = null;
                tInsertNode = null;
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuInsertAfterSqlCode(
            )
        {
            UltraTreeNode tActiveNode = null;
            UltraTreeNode tInsertNode = null;
            FXmlNode fXmlNode = null;

            try
            {
                tActiveNode = tvwTree.ActiveNode;
                fXmlNode = appendTreeOfSqlCode("5", tActiveNode);

                // --

                tvwTree.beginUpdate();

                // --

                tInsertNode = new UltraTreeNode(
                    string.Format(KeyFormat, tActiveNode.Key.Split(KeySeparator)[0], fXmlNode.get_elemVal(FXmlTagSqlCode.A_UniqueId, FXmlTagSqlCode.D_UniqueId)),
                    refreshNodeText(fXmlNode.get_elemVal(FXmlTagSqlCode.A_SqlCode, FXmlTagSqlCode.D_SqlCode), fXmlNode.get_elemVal(FXmlTagSqlCode.A_Description, FXmlTagSqlCode.D_Description))
                    );
                tInsertNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["SqlCode"];
                tInsertNode.Tag = fXmlNode;

                tActiveNode.Parent.Nodes.Insert(tActiveNode.Index + 1, tInsertNode);

                // --

                tvwTree.endUpdate();

                // --

                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tInsertNode;
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tActiveNode = null;
                tInsertNode = null;
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSearch(
           string searchWord
           )
        {
            UltraTreeNode tStartNode = null;
            UltraTreeNode tSearchNode = null;
            UltraTreeNode tResultNode = null;

            try
            {
                
                tStartNode = tvwTree.ActiveNode;
                tSearchNode = tStartNode;

                // --

                while(true)
                {
                    if (
                        searchTree(tStartNode, tSearchNode, searchWord, ref tResultNode) == false ||
                        tResultNode != null
                       )
                    {
                        break;
                    }

                    tSearchNode = getNextSibling(tSearchNode);
                    if (tSearchNode == tStartNode)
                    {
                        break;
                    }
                    if (tSearchNode.Text.ToLower().IndexOf(searchWord.ToLower()) > -1)
                    {
                        tResultNode = tSearchNode;
                        break;
                    }
                }

                // --

                tvwTree.SelectedNodes.Clear();
                if (tResultNode != null)
                {
                    tvwTree.ActiveNode = tResultNode;
                }
                else
                {
                    FMessageBox.showInformation("Search", m_fSqmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tStartNode = null;
                tSearchNode = null;
                tResultNode = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FSqlExplorer Form Event Handler

        private void FSqlExplorer_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designTreeOfSqlExplorer();
                tvwTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuPopupMenu]);

                // --

                m_fSqmCore.SqlQueryValueChanged += new FPropSqlCode.FSqlQueryValueChangedEventHandler(sqlQueryValueChanged);

                // --

                m_fSqmCore.fOption.fChildList.add(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FSqlExplorer_Shown(
            object sender, 
            EventArgs e
            )
        {
            FProgress fProgress = null;

            try
            {
                fProgress = new FProgress();
                fProgress.show(m_fSqmCore.fWsmCore.fWsmContainer);

                // --

                refreshTreeOfSystem();

                // --

                tvwTree.Focus();
            }
            catch (Exception ex)
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }
                // --
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void FSqlExplorer_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fSqmCore.SqlQueryValueChanged -= new FPropSqlCode.FSqlQueryValueChangedEventHandler(sqlQueryValueChanged);
                // --
                m_fSqmCore.fOption.fChildList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
       
        #region mnuMenu Control Event Handler

        private void mnuMenu_BeforeShortcutKeyProcessed(
            object sender, 
            BeforeShortcutKeyProcessedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (this.ContainsFocus == false)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mnuMenu_ToolClick(
            object sender,
            ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuSqeExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqeCollapse)
                {
                    procMenuCollapse();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqeCompatible)
                {
                    procMenuCompatible();
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuSqeRemove &&
                    pgdProp.ContainsFocus == false
                    )
                {
                    procMenuRemove();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqeCopy)
                {
                    procMenuCopy();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqeCut)
                {
                    procMenuCut();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqePaste)
                {
                    procMenuPaste();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqeMoveUp)
                {
                    procMenuMoveUp();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqeMoveDown)
                {
                    procMenuMoveDown();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqeDownload)
                {
                    procMenuDownload();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqeMigration)
                {
                    procMenuMigration();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqeParameter)
                {
                    procMenuViewParameter();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqeExecuteSql)
                {
                    procMenuExecuteSql();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuSqeAppendSystem)
                {
                    procMenuAppendSystem();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuSqeAppendModule)
                {
                    procMenuAppendModule();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqeInsertBeforeModule)
                {
                    procMenuInsertBeforeModule();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqeInsertAfterModule)
                {
                    procMenuInsertAfterModule();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuSqeAppendFunction)
                {
                    procMenuAppendFunction();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqeInsertBeforeFunction)
                {
                    procMenuInsertBeforeFunction();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqeInsertAfterFunction)
                {
                    procMenuInsertAfterFunction();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuSqeAppendSqlCode)
                {
                    procMenuAppendSqlCode();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqeInsertBeforeSqlCode)
                {
                    procMenuInsertBeforeSqlCode();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqeInsertAfterSqlCode)
                {
                    procMenuInsertAfterSqlCode();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

        #region tvwTree Control Event Handler

        private void tvwTree_AfterActivate(
            object sender, 
            NodeEventArgs e
            )
        {
            DataTable dt = null;
            FXmlNode n = null;
            string[] keys = null;
            string system = string.Empty;
            string module = string.Empty;
            string function = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.TreeNode == null)
                {
                    return;
                }

                // --

                keys = e.TreeNode.Key.Split(KeySeparator);
                system = keys[0];
                n = (FXmlNode)e.TreeNode.Tag;

                // --

                if (n.name == FXmlTagSystem.E_System)
                {
                    dt = getPropOfSystem(e.TreeNode);
                    pgdProp.selectedObject = new FPropSystem(m_fSqmCore, pgdProp, dt);
                }
                else if (n.name == FXmlTagModule.E_Module)
                {
                    dt = getPropOfModule(e.TreeNode);
                    pgdProp.selectedObject = new FPropModule(m_fSqmCore, pgdProp, system, dt);
                }
                else if (n.name == FXmlTagFunction.E_Function)
                {
                    module = ((FXmlNode)e.TreeNode.Parent.Tag).get_elemVal(FXmlTagModule.A_Module, FXmlTagModule.D_Module);
                    dt = getPropOfFunction(e.TreeNode);
                    pgdProp.selectedObject = new FPropFunction(m_fSqmCore, pgdProp, system, module, dt);
                }
                else if (n.name == FXmlTagSqlCode.E_SqlCode)
                {
                    module = ((FXmlNode)e.TreeNode.Parent.Parent.Tag).get_elemVal(FXmlTagModule.A_Module, FXmlTagModule.D_Module);
                    function = ((FXmlNode)e.TreeNode.Parent.Tag).get_elemVal(FXmlTagFunction.A_Function, FXmlTagFunction.D_Function);
                    dt = getPropOfSqlCode(e.TreeNode);
                    pgdProp.selectedObject = new FPropSqlCode(m_fSqmCore, pgdProp, system, module, function, dt);
                }

                // --

                e.TreeNode.Selected = true;
                controlMenu();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                dt = null;
                n = null;

                // --

                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwTree_AfterSelect(
            object sender, 
            SelectEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwTree_BeforeActivate(
            object sender, 
            CancelableNodeEventArgs e
            )
        {
            FXmlNode n = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.TreeNode == null)
                {
                    e.Cancel = true;
                    return;
                }

                // --

                n = (FXmlNode)e.TreeNode.Tag;
                if (
                    n.name != FXmlTagSystem.E_System &&
                    n.name != FXmlTagModule.E_Module &&
                    n.name != FXmlTagFunction.E_Function &&
                    n.name != FXmlTagSqlCode.E_SqlCode
                    )
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                n = null;

                // --

                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwTree_BeforeSelect(
            object sender, 
            BeforeSelectEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                foreach (UltraTreeNode t in e.NewSelections)
                {
                    if (t.Override.SelectionType == SelectType.None)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }

        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwTree_KeyDown(
            object sender,
            KeyEventArgs e
            )
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSqeRemove].SharedProps.Enabled == true)
                    {
                        procMenuRemove();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.C)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSqeCopy].SharedProps.Enabled == true)
                    {
                        procMenuCopy();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSqePaste].SharedProps.Enabled == true)
                    {
                        procMenuPaste();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.U)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSqeMoveUp].SharedProps.Enabled == true)
                    {
                        procMenuMoveUp();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.D)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSqeMoveDown].SharedProps.Enabled == true)
                    {
                        procMenuMoveDown();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.E)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSqeExpand].SharedProps.Enabled == true)
                    {
                        procMenuExpand();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.L)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSqeCollapse].SharedProps.Enabled == true)
                    {
                        procMenuCollapse();
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region pgdProp Control Event Handler

        private void pgdProp_PropertyValueChanged(
            object s, 
            PropertyValueChangedEventArgs e
            )
        {
            FDynPropBase fProp = null;
            FPropSystem fPropSystem = null;
            FPropModule fPropModule = null;
            FPropFunction fPropFunction = null;
            FPropSqlCode fPropSqlCode = null;
            FXmlNode fXmlNode = null;
            UltraTreeNode tActiveNode = null;
            string changedName = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.OldValue == e.ChangedItem.Value)
                {
                    return;
                }

                fProp = pgdProp.selectedObject;
                if (fProp is FPropSystem)
                {
                    fPropSystem = (FPropSystem)fProp;
                    fXmlNode = updateTreeOfSystem(fPropSystem, 
                        e.ChangedItem.Label == "Name" ? (string)e.OldValue : fPropSystem.System
                        );
                    changedName = refreshNodeText(fPropSystem.System, fPropSystem.Description);
                }
                else if (fProp is FPropModule)
                {
                    fPropModule = (FPropModule)fProp;
                    fXmlNode = updateTreeOfModule(fPropModule);
                    changedName = refreshNodeText(fPropModule.Module, fPropModule.Description);
                }
                else if (fProp is FPropFunction)
                {
                    fPropFunction = (FPropFunction)fProp;
                    fXmlNode = updateTreeOfFunction(fPropFunction);
                    changedName = refreshNodeText(fPropFunction.Function, fPropFunction.Description);
                }
                else if (fProp is FPropSqlCode)
                {
                    fPropSqlCode = (FPropSqlCode)fProp;
                    fXmlNode = updateTreeOfSqlCode(fPropSqlCode);
                    changedName = refreshNodeText(fPropSqlCode.SqlCode, fPropSqlCode.Description);
                }

                // --

                tvwTree.beginUpdate();

                // --

                tActiveNode = tvwTree.ActiveNode;
                tActiveNode.Text = changedName;
                tActiveNode.Tag = fXmlNode;
                if (
                    fXmlNode.name == FXmlTagSystem.E_System &&
                    tActiveNode.Key.Split(KeySeparator)[0] != fXmlNode.get_elemVal(FXmlTagSystem.A_System, FXmlTagSystem.D_System)
                   )
                {
                    replaceNodeKey(tActiveNode, changedName);
                }
                else
                {
                    if (fXmlNode.name == FXmlTagSqlCode.E_SqlCode)
                    {
                        if (fPropSqlCode.UsedMigration == FYesNo.Yes)
                        {
                            tActiveNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["SqlCode"];
                        }
                        else
                        {
                            tActiveNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["SqlCode_NotCompatible"];
                        }

                        //refreshTreeOfSqlQuery(tActiveNode);
                    }
                }

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fProp = null;
                fPropSystem = null;
                fPropModule = null;
                fPropFunction = null;
                fPropSqlCode = null;
                fXmlNode = null;
                tActiveNode = null;

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Sql Query Value Changed Event Handler

        private void sqlQueryValueChanged (
            object s,
            PropertyValueChangedEventArgs e
            )
        {
            FDynPropBase fProp = null;            
            FPropSqlCode fPropSqlCode = null;
            FXmlNode fXmlNode = null;
            UltraTreeNode tActiveNode = null;
            string changedName = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                fProp = pgdProp.selectedObject;
                
                if (fProp is FPropSqlCode)
                {
                    fPropSqlCode = (FPropSqlCode)fProp;
                    fXmlNode = updateTreeOfSqlCode(fPropSqlCode);
                    changedName = refreshNodeText(fPropSqlCode.SqlCode, fPropSqlCode.Description);
                }

                // --

                tvwTree.beginUpdate();

                // --

                tActiveNode = tvwTree.ActiveNode;
                tActiveNode.Text = changedName;
                tActiveNode.Tag = fXmlNode;
                
                if (fXmlNode.name == FXmlTagSqlCode.E_SqlCode)
                {
                    //refreshTreeOfSqlQuery(tActiveNode);
                }                

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fProp = null;        
                fPropSqlCode = null;
                fXmlNode = null;
                tActiveNode = null;

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
                procMenuSearch(e.searchWord);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void rstToolbar_RefreshRequested(
            object sender, 
            EventArgs e
            )
        {
            FProgress fProgress = null;

            try
            {
                fProgress = new FProgress();
                fProgress.show(m_fSqmCore.fWsmCore.fWsmContainer);

                // --

                procMenuRefresh();
            }
            catch (Exception ex)
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }
                // --
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }
            }
        }

        #endregion
        
        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
