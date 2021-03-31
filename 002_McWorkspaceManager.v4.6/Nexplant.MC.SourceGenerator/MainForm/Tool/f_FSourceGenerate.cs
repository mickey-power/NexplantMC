/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSourceGenerator.cs
--  Creator         : baehyun seo
--  Create Date     : 2011.10.05
--  Description     : FAMate Source Generator Form Class
--  History         : Created by baehyun seo at 2011.10.05
                    : Modified by kitae at 2012.03.20
                        - Recent Library 
                        - procMenuGenerate
                        - procMenuDownload
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using Infragistics.Win.UltraWinToolbars;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Infragistics.Win.UltraWinTree;
using System.Diagnostics;

namespace Nexplant.MC.SourceGenerator
{
    public partial class FSourceGenerate : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FScgCore m_fScgCore = null;
        private string m_fileName = string.Empty;        
        private FXmlDocument m_fXmlDoc = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSourceGenerate(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSourceGenerate(
            FScgCore fScgCore,
            string fileName
            )
            : this()
        {
            base.fUIWizard = fScgCore.fUIWizard;
            m_fScgCore = fScgCore;
            m_fileName = fileName;
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
                    m_fScgCore = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public string fileName
        {
            get 
            {
                try
                {
                    return m_fileName; 
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

            set
            {
                try
                {
                    m_fileName = value;    
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

        public void setTitle(
            )
        {
            try
            {
                this.Text = m_fScgCore.fWsmCore.fUIWizard.searchCaption(this.Text);
             
                // --
                
                txtFileName.Text = Path.GetFileName(m_fileName);
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

        private void designTreeOfGenerate(
            )
        {
            try
            {
                tvwTree.ImageList = new ImageList();
                // --
                tvwTree.ImageList.Images.Add("Namespace", Properties.Resources.Namespace);
                tvwTree.ImageList.Images.Add("Group", Properties.Resources.Group);
                tvwTree.ImageList.Images.Add("Parameter", Properties.Resources.Parameter);
                tvwTree.ImageList.Images.Add("Element", Properties.Resources.Element);
                tvwTree.ImageList.Images.Add("Attribute", Properties.Resources.Attribute);
                tvwTree.ImageList.Images.Add("Function", Properties.Resources.Function);
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

        private void procMenuOpen(
            )
        {
            OpenFileDialog dialog = null;

            try
            {                
                dialog = new OpenFileDialog();
                dialog.Title = fUIWizard.searchCaption("Open GEN File");
                dialog.Filter = "GEN Files | *.gen";
                dialog.DefaultExt = "gen";
                dialog.InitialDirectory = m_fScgCore.fOption.recentOpenPath;
                // --
                if (dialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                m_fileName = dialog.FileName;

                // --

                loadGenerateFile();

                // --

                m_fScgCore.fOption.recentOpenPath = Path.GetDirectoryName(m_fileName);
                changeRecentLibraryFile(m_fileName);

                // --

                setTitle();
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

        private void changeRecentLibraryFile(
            string fileName
            )
        {
            try
            {
                if (m_fScgCore.fOption.recentGenFileList.Contains(fileName))
                {
                    m_fScgCore.fOption.recentGenFileList.Remove(fileName);
                }
                else if (m_fScgCore.fOption.recentGenFileList.Count == 4)
                {
                    m_fScgCore.fOption.recentGenFileList.RemoveAt(3);
                }
                m_fScgCore.fOption.recentGenFileList.Insert(0, fileName);
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

        private void procMenuGenerate(
            )
        {
            FGenerate fGenerate = null;
            string namespaceName = string.Empty;
            string moduleName = string.Empty;
            string modulePath = string.Empty;
            DialogResult dialogResult;

            try
            {
                // --

                // ***
                // H101 Module만 Generate하기 위해 주석처리.
                // ***
                //if (!hasCheckedNode())
                //{
                //    FDebug.throwFException(m_fScgCore.fUIWizard.generateMessage("E0020"));
                //}

                // --

                fGenerate = new FGenerate(m_fScgCore);
                if (fGenerate.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                //--

                foreach (UltraTreeNode tNodeNam in tvwTree.Nodes)
                {
                    namespaceName = ((FXmlNode)tNodeNam.Tag).get_attrVal(FXmlTagNamespace.A_NamespaceName, FXmlTagNamespace.A_NamespaceName);
                    moduleName = ((FXmlNode)tNodeNam.Tag).get_attrVal(FXmlTagNamespace.A_NamespaceModuleName, FXmlTagNamespace.D_NamespaceModuleName);
                    modulePath = m_fScgCore.fOption.optionSavePath + "\\" + moduleName;                    

                    // --

                    if (m_fScgCore.fOption.oldFilesClear)
                    {
                        if (Directory.Exists(modulePath))
                        {
                            deleteDirectory(modulePath);
                        }                        
                    }

                    // --

                    if (!Directory.Exists(modulePath))
                    {
                        Directory.CreateDirectory(modulePath);
                    }

                    // --

                    if (m_fScgCore.fOption.paramGenerator)
                    {
                        if (m_fScgCore.fOption.internalClass)
                        {
                            generateParameterFile(true, moduleName, modulePath, namespaceName, tNodeNam);
                        }
                        else
                        {
                            generateParameterFile(false, moduleName, modulePath, namespaceName, tNodeNam);
                        }
                    }

                    // --

                    if (m_fScgCore.fOption.funcGenerator)
                    {
                        if (m_fScgCore.fOption.internalClass)
                        {
                            generateFunctionFile(true, moduleName, modulePath, namespaceName, tNodeNam);
                        }
                        else
                        {
                            generateFunctionFile(false, moduleName, modulePath, namespaceName, tNodeNam);
                        }
                    }

                    // --

                    if (m_fScgCore.fOption.h101BaseGenerator)
                    {
                        if (m_fScgCore.fOption.internalClass)
                        {
                            generateH101BaseCodeCasterFile(true, moduleName, modulePath, namespaceName, tNodeNam);
                            generateH101BaseCodeSkeletonFile(true, moduleName, modulePath, namespaceName, tNodeNam);
                            generateH101BaseCodeTunerFile(true, moduleName, modulePath, namespaceName, tNodeNam);
                        }
                        else
                        {
                            generateH101BaseCodeCasterFile(false, moduleName, modulePath, namespaceName, tNodeNam);
                            generateH101BaseCodeSkeletonFile(false, moduleName, modulePath, namespaceName, tNodeNam);
                            generateH101BaseCodeTunerFile(false, moduleName, modulePath, namespaceName, tNodeNam);
                        }
                    }
                }

                // --

                // ***
                // folder open
                // ***
                dialogResult = FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fScgCore.fUIWizard.generateMessage("Q0006"),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    );
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                Process.Start("explorer.exe", m_fScgCore.fOption.optionSavePath);
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

        private void procMenuCheckAll(
            )
        {
            try
            {
                foreach (UltraTreeNode tNode in tvwTree.Nodes)
                {
                    tNode.CheckedState = CheckState.Unchecked;
                    tNode.CheckedState = CheckState.Checked;
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

        private void procMenuUncheckAll(
            )
        {
            try
            {
                foreach (UltraTreeNode tNode in tvwTree.Nodes)
                {
                    tNode.CheckedState = CheckState.Checked;
                    tNode.CheckedState = CheckState.Unchecked;
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

        private void procMenuCheckAllParameter(
            )
        {
            CheckState state;

            try
            {
                if (((StateButtonTool)mnuMenu.Tools[FMenuKey.MenuScgCheckAllParameter]).Checked)
                {
                    state = CheckState.Checked;
                }
                else
                {
                    state = CheckState.Unchecked;
                }

                // --

                foreach (UltraTreeNode tNodeNam in tvwTree.Nodes)
                {
                    foreach (UltraTreeNode tNodeGrp in tNodeNam.Nodes)
                    {
                        foreach (UltraTreeNode tNode in tNodeGrp.Nodes)
                        {
                            if (((FXmlNode)tNode.Tag).name == FXmlTagParameters.E_Parameters)
                            {
                                tNode.CheckedState = state;
                            }
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

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCheckAllFunction(
            )
        {
            CheckState state;

            try
            {
                if (((StateButtonTool)mnuMenu.Tools[FMenuKey.MenuScgCheckAllFunction]).Checked)
                {
                    state = CheckState.Checked;
                }
                else
                {
                    state = CheckState.Unchecked;
                }

                // --

                foreach (UltraTreeNode tNodeNam in tvwTree.Nodes)
                {
                    foreach (UltraTreeNode tNodeGrp in tNodeNam.Nodes)
                    {
                        foreach (UltraTreeNode tNode in tNodeGrp.Nodes)
                        {
                            if (((FXmlNode)tNode.Tag).name == FXmlTagFunction.E_Function)
                            {
                                tNode.CheckedState = state;
                            }
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

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuChooseAllParameter(
            )
        {
            bool visible = false;

            try
            {
                tvwTree.beginUpdate();

                // --

                if (((StateButtonTool)mnuMenu.Tools[FMenuKey.MenuScgChooseAllParameter]).Checked)
                {
                    visible = false;
                }
                else
                {
                    visible = true;
                }

                // --

                foreach (UltraTreeNode tNodeNam in tvwTree.Nodes)
                {
                    foreach (UltraTreeNode tNodeGrp in tNodeNam.Nodes)
                    {
                        foreach (UltraTreeNode tNode in tNodeGrp.Nodes)
                        {
                            if (((FXmlNode)tNode.Tag).name == FXmlTagFunction.E_Function)
                            {
                                tNode.Visible = visible;
                            }
                            else
                            {
                                tNode.Visible = true;
                            }
                        }
                    }
                }

                // --

                tvwTree.EndUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.EndUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuChooseAllFunction(
            )
        {
            bool visible = false;

            try
            {
                tvwTree.beginUpdate();

                // --

                if (((StateButtonTool)mnuMenu.Tools[FMenuKey.MenuScgChooseAllFunction]).Checked)
                {
                    visible = false;
                }
                else
                {
                    visible = true;
                }

                // --

                foreach (UltraTreeNode tNodeNam in tvwTree.Nodes)
                {
                    foreach (UltraTreeNode tNodeGrp in tNodeNam.Nodes)
                    {
                        foreach (UltraTreeNode tNode in tNodeGrp.Nodes)
                        {
                            if (((FXmlNode)tNode.Tag).name == FXmlTagParameters.E_Parameters)
                            {
                                tNode.Visible = visible;
                            }
                            else
                            {
                                tNode.Visible = true;
                            }
                        }
                    }
                }                

                // --

                tvwTree.EndUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.EndUpdate();
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
 
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCollapse(
            )
        {
            try
            {
                tvwTree.beginUpdate();

                // --

                tvwTree.ActiveNode.CollapseAll();

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
        
        private void procMenuSearchWord(
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

                while (true)
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

                // --
                                
                if (tResultNode != null)
                {
                    tvwTree.ActiveNode = tResultNode;
                }
                else
                {
                    FMessageBox.showInformation("Search", m_fScgCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
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

                    if (
                        searchTree(tStartNode, t, str, ref tResultNode) == false ||
                        tResultNode != null
                       )
                    {
                        return false;
                    }
                    else { }
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

        private void generateParameterFile(
            bool access,
            string moduleName,
            string modulePath,
            string namespaceName,
            UltraTreeNode tNodeNam
            )
        {
            StreamWriter sw = null;
            FXmlNode fXmlNode = null;
            string path = string.Empty;
            string parName = string.Empty;            
            StringBuilder builder = null;
            StringBuilder baseSpace = null;

            try
            {
                path = modulePath + "\\" + moduleName + "Callback\\Parameters";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                builder = new StringBuilder();
                baseSpace = new StringBuilder();

                // --

                foreach (UltraTreeNode tNodeGrp in tNodeNam.Nodes)
                {
                    foreach (UltraTreeNode tNode in tNodeGrp.Nodes)
                    {
                        if (tNode.CheckedState == CheckState.Unchecked)
                        {
                            continue;
                        }
                        
                        fXmlNode = (FXmlNode)tNode.Tag;
                        if (fXmlNode.name != FXmlTagParameters.E_Parameters)
                        {
                            continue;
                        }

                        // --

                        builder.Clear();

                        // --

                        parName = fXmlNode.get_attrVal(FXmlTagParameters.A_ParametersName, FXmlTagParameters.D_ParametersName);

                        // --

                        builder.AppendLine("/*----------------------------------------------------------------------------------------------------------");
                        builder.AppendLine(m_fScgCore.fOption.optionCopyright);
                        builder.AppendLine("--");
                        builder.AppendLine("--  Program Id      : c_" + parName + ".cs");
                        builder.AppendLine("--  Creator         : " + m_fScgCore.fOption.optionCreator);
                        builder.AppendLine("--  Create Date     : " + DateTime.Now.ToString("yyyy.MM.dd"));
                        builder.AppendLine("--  Description     : " + m_fScgCore.fOption.optionDescription);
                        builder.AppendLine("--  History         : Created by " + m_fScgCore.fOption.optionCreator + " at " + DateTime.Now.ToString("yyyy.MM.dd"));
                        builder.AppendLine("----------------------------------------------------------------------------------------------------------*/");
                        builder.AppendLine("using System;");
                        builder.AppendLine("using System.Collections.Generic;");
                        builder.AppendLine("using System.Linq;");
                        builder.AppendLine("using System.Text;");
                        builder.AppendLine();
                        builder.AppendLine("namespace " + namespaceName);
                        builder.AppendLine("{");
                        // --
                        if (access == false)
                        {
                            builder.AppendLine("    public static class " + parName);
                        }
                        else if (access == true)
                        {
                            builder.AppendLine("    internal static class " + parName);
                        }
                        builder.AppendLine("    {");
                        

                        // --

                        baseSpace.Clear();
                        baseSpace.Append("        ");

                        // --

                        foreach (UltraTreeNode tNodeElm in tNode.Nodes)
                        {
                            builder.AppendLine();
                            builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                            builder.AppendLine();

                            // --

                            generateElement(tNodeElm, baseSpace, builder);
                            generateSubElement(tNodeElm, baseSpace, builder);
                        }
                        // --

                        builder.AppendLine();
                        builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                        builder.AppendLine();
                        builder.AppendLine("    }   // Class end");
                        builder.AppendLine("}   // Namespace end");

                        // --

                        //
                        // Save 
                        //
                        sw = new StreamWriter(path + "\\c_" + parName + ".cs", false, Encoding.Default);
                        sw.Write(builder.ToString());
                        sw.Close();
                        sw.Dispose();
                        sw = null;
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                    sw = null;
                }
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void generateSubElement(
            UltraTreeNode tNodeParent,
            StringBuilder baseSapce,
            StringBuilder builder
            )
        {
            FXmlNode fXmlNode = null;
            string elmName = string.Empty;

            try
            {
                foreach (UltraTreeNode tNode in tNodeParent.Nodes)
                {
                    fXmlNode = (FXmlNode)tNode.Tag;
                    if (fXmlNode.name != FXmlTagElement.E_Element)
                    {
                        continue;
                    }

                    // --

                    elmName = fXmlNode.get_attrVal(FXmlTagElement.A_ElementName, FXmlTagElement.D_ElementName);

                    // --

                    builder.AppendLine();
                    builder.AppendLine(baseSapce.ToString() + "// --");
                    builder.AppendLine();

                    // --

                    builder.AppendLine(baseSapce + "public static class F" + elmName);
                    builder.AppendLine(baseSapce + "{");

                    // --

                    baseSapce.Append("    ");
                    // --
                    generateElement(tNode, baseSapce, builder);
                    generateSubElement(tNode, baseSapce, builder);

                    // --

                    baseSapce.Remove(0, 4);
                    builder.AppendLine(baseSapce + "}");                    
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void generateElement(
            UltraTreeNode tNodeElm,
            StringBuilder baseSapce,
            StringBuilder builder
            )
        {
            FXmlNode fXmlNodeElm = null;
            FXmlNode fXmlNode = null;
            string elmName = string.Empty;
            string elmTag = string.Empty;
            string atrName = string.Empty;
            string atrTag = string.Empty;
            string atrValue = string.Empty;

            try
            {
                fXmlNodeElm = (FXmlNode)tNodeElm.Tag;
                // --
                elmName = fXmlNodeElm.get_attrVal(FXmlTagElement.A_ElementName, FXmlTagElement.D_ElementName);
                elmTag = fXmlNodeElm.get_attrVal(FXmlTagElement.A_ElementTag, FXmlTagElement.D_ElementTag);
                if (elmTag == string.Empty)
                {
                    elmTag = elmName;
                }

                // --

                // ***
                // Element Name Write
                // ***
                builder.AppendLine(baseSapce.ToString() + "public const string E_" + elmName + " = \"" + elmTag + "\";");
                builder.AppendLine();
                builder.AppendLine(baseSapce.ToString() + "// --");
                builder.AppendLine();

                // --

                // ***
                // Attribute Name Write
                // ***
                foreach (UltraTreeNode tNode in tNodeElm.Nodes)
                {
                    fXmlNode = ((FXmlNode)tNode.Tag);
                    if (fXmlNode.name != FXmlTagAttribute.E_Attribute)
                    {
                        continue;
                    }

                    // --

                    atrName = fXmlNode.get_attrVal(FXmlTagAttribute.A_AttributeName, FXmlTagAttribute.D_AttributeName);
                    atrTag = fXmlNode.get_attrVal(FXmlTagAttribute.A_AttributeTag, FXmlTagAttribute.D_AttributeTag);
                    if (atrTag == string.Empty)
                    {
                        atrTag = atrName;
                    }

                    // --

                    builder.AppendLine(baseSapce + "public const string A_" + atrName + " = \"" + atrTag + "\";");
                }

                // --

                builder.AppendLine();
                builder.AppendLine(baseSapce.ToString() + "// --");
                builder.AppendLine();

                // --

                // ***
                // Attribute Defualt Value Write
                // ***
                foreach (UltraTreeNode tNode in tNodeElm.Nodes)
                {
                    fXmlNode = ((FXmlNode)tNode.Tag);
                    if (fXmlNode.name != FXmlTagAttribute.E_Attribute)
                    {
                        continue;
                    }

                    // --

                    atrName = fXmlNode.get_attrVal(FXmlTagAttribute.A_AttributeName, FXmlTagAttribute.D_AttributeName);
                    atrValue = fXmlNode.get_attrVal(FXmlTagAttribute.A_AttributeDefaultValue, FXmlTagAttribute.D_AttributeDefaultValue);

                    // --

                    builder.AppendLine(baseSapce + "public const string D_" + atrName + " = \"" + atrValue + "\";");
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeElm = null;
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void generateFunctionFile(
            bool access,
            string moduleName,
            string modulePath,
            string namespaceName,
            UltraTreeNode tNodeNam
            )
        {
            StreamWriter sw = null;
            FXmlNode fXmlNode = null;
            string path = string.Empty;
            string className = string.Empty;
            string functionName = string.Empty;
            string deliveryMode = string.Empty;
            StringBuilder builder = null;            

            try
            {
                path = modulePath + "\\" + moduleName + "Callback";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                builder = new StringBuilder();
                
                // --

                foreach (UltraTreeNode tNodeGrp in tNodeNam.Nodes)
                {
                    foreach (UltraTreeNode tNode in tNodeGrp.Nodes)
                    {
                        if (tNode.CheckedState == CheckState.Unchecked)
                        {
                            continue;
                        }

                        fXmlNode = (FXmlNode)tNode.Tag;
                        if (fXmlNode.name != FXmlTagFunction.E_Function)
                        {
                            continue;
                        }

                        // --

                        builder.Clear();

                        // --

                        className = fXmlNode.get_attrVal(FXmlTagFunction.A_FunctionClass, FXmlTagFunction.D_FunctionClass);
                        functionName = fXmlNode.get_attrVal(FXmlTagFunction.A_FunctionName, FXmlTagFunction.D_FunctionName);
                        deliveryMode = fXmlNode.get_attrVal(FXmlTagFunction.A_FunctionDeliveryMode, FXmlTagFunction.D_FunctionDeliveryMode);

                        // --

                        builder.AppendLine("/*----------------------------------------------------------------------------------------------------------");
                        builder.AppendLine(m_fScgCore.fOption.optionCopyright);
                        builder.AppendLine("--");
                        builder.AppendLine("--  Program Id      : c_" + functionName + ".cs");
                        builder.AppendLine("--  Creator         : " + m_fScgCore.fOption.optionCreator);
                        builder.AppendLine("--  Create Date     : " + DateTime.Now.ToString("yyyy.MM.dd"));
                        builder.AppendLine("--  Description     : " + m_fScgCore.fOption.optionDescription);
                        builder.AppendLine("--  History         : Created by " + m_fScgCore.fOption.optionCreator + " at " + DateTime.Now.ToString("yyyy.MM.dd"));
                        builder.AppendLine("----------------------------------------------------------------------------------------------------------*/");
                        builder.AppendLine("using System;");
                        builder.AppendLine("using System.Collections;");
                        builder.AppendLine("using System.Collections.Generic;");
                        builder.AppendLine("using System.Linq;");
                        builder.AppendLine("using System.Text;");
                        builder.AppendLine("using System.Data;");
                        if (m_fScgCore.fOption.optionUsingNamespace.Trim().Length > 0)
                        {
                            builder.AppendLine(m_fScgCore.fOption.optionUsingNamespace);
                        }
                        builder.AppendLine();
                        builder.AppendLine("namespace " + namespaceName);
                        builder.AppendLine("{");
                        if (access == false)
                        {
                            builder.AppendLine("    public partial class " + className);
                        }
                        else if (access == true)
                        {
                            builder.AppendLine("    internal partial class " + className);
                        }
                        builder.AppendLine("    {");
                        builder.AppendLine();
                        builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                        builder.AppendLine();
                        builder.AppendLine("        public override void " + functionName + "(");

                        // --

                        if (deliveryMode == "REQUEST")
                        {
                            builder.AppendLine("            FXmlNode fXmlNodeIn,");
                            builder.AppendLine("            ref FXmlNode fXmlNodeOut");
                        }
                        else
                        {
                            builder.AppendLine("            FXmlNode fXmlNodeIn");                        
                        }

                        // --

                        builder.AppendLine("            )");
                        builder.AppendLine("        {");
                        builder.AppendLine("            try");
                        builder.AppendLine("            {");
                        builder.AppendLine();
                        builder.AppendLine("            }");
                        builder.AppendLine("            catch (Exception ex)");
                        builder.AppendLine("            {");
                        builder.AppendLine("                FDebug.writeLog(ex);");
                        builder.AppendLine("            }");
                        builder.AppendLine("            finally");
                        builder.AppendLine("            {");
                        builder.AppendLine();
                        builder.AppendLine("            }");
                        builder.AppendLine("        }");
                        builder.AppendLine();
                        builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                        builder.AppendLine();
                        builder.AppendLine("    }   // Class end");
                        builder.AppendLine("}   // Namespace end");

                        // --

                        sw = new StreamWriter(path + "\\c_F" + functionName + ".cs", false, Encoding.Default);
                        sw.Write(builder.ToString());
                        sw.Close();
                        sw.Dispose();
                        sw = null;
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                    sw = null;
                }
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        #region Load Tree Of Generate File 

        private void loadGenerateFile(
            )
        {
            int keyPointer = 0;

            try
            {
                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();

                // --

                if (m_fXmlDoc != null)
                {
                    m_fXmlDoc.Dispose();
                }
                // --
                m_fXmlDoc = new FXmlDocument();
                m_fXmlDoc.preserveWhiteSpace = false;
                m_fXmlDoc.load(m_fileName);

                // --

                foreach (FXmlNode fXmlNodeNam in m_fXmlDoc.selectNodes(FXmlTagFAMate.E_FAMate + "/" + FXmlTagNamespace.E_Namespace))
                {
                    loadTreeOfNamespace(fXmlNodeNam, ref keyPointer);
                }

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

        private void loadTreeOfNamespace(
            FXmlNode fXmlNodeNam, 
            ref int keyPointer
            )
        {
            UltraTreeNode tNodeNam = null;

            try
            {
                tNodeNam = new UltraTreeNode(keyPointer.ToString());
                tNodeNam.Text =
                    fXmlNodeNam.get_attrVal(FXmlTagNamespace.A_NamespaceName, FXmlTagNamespace.D_NamespaceName)
                    + " ModuleName=[" + fXmlNodeNam.get_attrVal(FXmlTagNamespace.A_NamespaceModuleName, FXmlTagNamespace.D_NamespaceModuleName) + "]";
                // --
                tNodeNam.Override.NodeStyle = NodeStyle.CheckBox;
                tNodeNam.Override.ImageSize = new Size(16, 16);
                tNodeNam.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Namespace"];
                tNodeNam.Tag = fXmlNodeNam;
                tNodeNam.Expanded = true;
                // --
                keyPointer++;

                // --

                foreach (FXmlNode fXmlNodeGrp in fXmlNodeNam.selectNodes(FXmlTagGroup.E_Group))
                {
                    loadTreeOfGroup(tNodeNam, fXmlNodeGrp, ref keyPointer);
                }

                // --

                tvwTree.Nodes.Add(tNodeNam);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeNam = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfGroup(
            UltraTreeNode tNodeParent,
            FXmlNode fXmlNodeGrp,
            ref int keyPointer
            )
        {
            UltraTreeNode tNodeGrp = null;

            try
            {
                tNodeGrp = new UltraTreeNode(keyPointer.ToString());
                tNodeGrp.Text = fXmlNodeGrp.get_attrVal(FXmlTagGroup.A_GroupName, FXmlTagGroup.D_GroupName);
                // --
                tNodeGrp.Override.NodeStyle = NodeStyle.CheckBox;
                tNodeGrp.Override.ImageSize = new Size(16, 16);
                tNodeGrp.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Group"];
                tNodeGrp.Tag = fXmlNodeGrp;
                tNodeGrp.Expanded = true;
                // --
                keyPointer++;

                // --

                foreach (FXmlNode fXmlNodeChild in fXmlNodeGrp.selectNodes(FXmlTagParameters.E_Parameters + " | " + FXmlTagFunction.E_Function))
                {
                    if (fXmlNodeChild.name == FXmlTagParameters.E_Parameters)
                    {
                        loadTreeOfParameter(tNodeGrp, fXmlNodeChild, ref keyPointer);
                    }
                    else
                    {
                        loadTreeOfFunction(tNodeGrp, fXmlNodeChild, ref keyPointer);
                    }
                }

                // --

                tNodeParent.Nodes.Add(tNodeGrp);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeGrp = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfParameter(
            UltraTreeNode tNodeParent, 
            FXmlNode fXmlNodePar, 
            ref int keyPointer
            )
        {
            UltraTreeNode tNodePar = null;

            try
            {
                tNodePar = new UltraTreeNode(keyPointer.ToString());
                tNodePar.Text = fXmlNodePar.get_attrVal(FXmlTagParameters.A_ParametersName, FXmlTagParameters.D_ParametersName);
                // --
                tNodePar.Override.NodeStyle = NodeStyle.CheckBox;
                tNodePar.Override.ImageSize = new Size(16, 16);
                tNodePar.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Parameter"]; ;
                tNodePar.Tag = fXmlNodePar;
                tNodePar.Expanded = false;
                // --
                keyPointer++;

                // --

                foreach (FXmlNode fXmlNodeElm in fXmlNodePar.selectNodes(FXmlTagElement.E_Element))
                {
                    loadTreeOfElement(tNodePar, fXmlNodeElm, ref keyPointer);
                }

                // --

                tNodeParent.Nodes.Add(tNodePar);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
                throw;
            }
            finally
            {
 
            }

        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfElement(
            UltraTreeNode tNodeParent,
            FXmlNode fXmlNodeElm,
            ref int keyPointer
            )
        {
            UltraTreeNode tNodeElm = null;
            string tagName = string.Empty;

            try
            {
                tagName = fXmlNodeElm.get_attrVal(FXmlTagElement.A_ElementTag, FXmlTagElement.D_ElementTag);
                if (tagName == string.Empty)
                {
                    tagName = fXmlNodeElm.get_attrVal(FXmlTagElement.A_ElementName, FXmlTagElement.D_ElementName);
                }

                // --

                tNodeElm = new UltraTreeNode(keyPointer.ToString());
                tNodeElm.Text =
                    fXmlNodeElm.get_attrVal(FXmlTagElement.A_ElementName, FXmlTagElement.D_ElementName) +
                    " Tag=[" + tagName + "]";
                // --
                tNodeElm.Override.ImageSize = new Size(16, 16);
                tNodeElm.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Element"]; ;
                tNodeElm.Tag = fXmlNodeElm;
                tNodeElm.Expanded = false;
                // --
                keyPointer++;

                // --

                foreach (FXmlNode fXmlNodeChild in fXmlNodeElm.selectNodes(FXmlTagElement.E_Element + " | " + FXmlTagAttribute.E_Attribute))
                {
                    if (fXmlNodeChild.name == FXmlTagElement.E_Element)
                    {
                        loadTreeOfElement(tNodeElm, fXmlNodeChild, ref keyPointer);
                    }
                    else
                    {
                        loadTreeOfAttribute(tNodeElm, fXmlNodeChild, ref keyPointer);
                    }
                }

                // --

                tNodeParent.Nodes.Add(tNodeElm);
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

        private void loadTreeOfAttribute(
            UltraTreeNode tNodeParent,
            FXmlNode fXmlNodeAtr,
            ref int keyPointer
            )
        {
            UltraTreeNode tNodeAtr = null;
            string tagName = string.Empty;

            try
            {
                tagName = fXmlNodeAtr.get_attrVal(FXmlTagAttribute.A_AttributeTag, FXmlTagAttribute.D_AttributeTag);
                if (tagName == string.Empty)
                {
                    tagName = fXmlNodeAtr.get_attrVal(FXmlTagElement.A_ElementName, FXmlTagElement.D_ElementName);
                }

                // --

                tNodeAtr = new UltraTreeNode(keyPointer.ToString());
                tNodeAtr.Text =
                    fXmlNodeAtr.get_attrVal(FXmlTagAttribute.A_AttributeName, FXmlTagAttribute.D_AttributeName) +
                    " Tag=[" + tagName + "]" +
                    " DefaultValue=[" + fXmlNodeAtr.get_attrVal(FXmlTagAttribute.A_AttributeDefaultValue, FXmlTagAttribute.D_AttributeDefaultValue) + "]";
                // --
                tNodeAtr.Override.ImageSize = new Size(16, 16);
                tNodeAtr.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Attribute"];
                tNodeAtr.Tag = fXmlNodeAtr;
                tNodeAtr.Expanded = false;
                // --
                keyPointer++;

                // --

                tNodeParent.Nodes.Add(tNodeAtr);
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

        private void loadTreeOfFunction(
            UltraTreeNode tNodeParent,
            FXmlNode fXmlNodeFun,
            ref int keyPointer
            )
        {
            UltraTreeNode tNodeFun = null;

            try
            {
                tNodeFun = new UltraTreeNode(keyPointer.ToString());
                tNodeFun.Text =
                    fXmlNodeFun.get_attrVal(FXmlTagFunction.A_FunctionClass, FXmlTagFunction.D_FunctionClass) +
                    " DeliveryMode=[" + fXmlNodeFun.get_attrVal(FXmlTagFunction.A_FunctionDeliveryMode, FXmlTagFunction.D_FunctionDeliveryMode) + "]" +
                    " Name=[" + fXmlNodeFun.get_attrVal(FXmlTagFunction.A_FunctionName, FXmlTagFunction.D_FunctionName) + "]" +
                    " Async=[" + fXmlNodeFun.get_attrVal(FXmlTagFunction.A_FunctionAsync, FXmlTagFunction.D_FunctionAsync) + "]" +
                    " Guaranteed=["+fXmlNodeFun.get_attrVal(FXmlTagFunction.A_FunctionGuaranteed,FXmlTagFunction.D_FunctionGuaranteed)+"]";
                // --
                tNodeFun.Override.NodeStyle = NodeStyle.CheckBox;
                tNodeFun.Override.ImageSize = new Size(16, 16);
                tNodeFun.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Function"]; ;
                tNodeFun.Tag = fXmlNodeFun;
                tNodeFun.Expanded = false;
                // --
                keyPointer++;

                // --

                tNodeParent.Nodes.Add(tNodeFun);
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

        #region Generate H101 Base Code File

        private void generateH101BaseCodeCasterFile(
            bool access,
            string moduleName,
            string modulePath,
            string namespaceName,
            UltraTreeNode tNodeNam
            )
        {
            StreamWriter sw = null;
            FXmlNode fXmlNode = null;
            string path = string.Empty;
            string functionName = string.Empty;
            string deliveryMode = string.Empty;
            string async = string.Empty;
            string guaranteed = string.Empty;
            StringBuilder builder = null;
            int index = 0;

            try
            {
                path = modulePath;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                builder = new StringBuilder();

                // --

                builder.AppendLine("/*----------------------------------------------------------------------------------------------------------");
                builder.AppendLine(m_fScgCore.fOption.optionCopyright);
                builder.AppendLine("--");
                builder.AppendLine("--  Program Id      : c_F" + moduleName + "Caster.cs ");
                builder.AppendLine("--  Creator         : " + m_fScgCore.fOption.optionCreator);
                builder.AppendLine("--  Create Date     : " + DateTime.Now.ToString("yyyy.MM.dd"));
                builder.AppendLine("--  Description     : " + m_fScgCore.fOption.optionDescription);
                builder.AppendLine("--  History         : Created by " + m_fScgCore.fOption.optionCreator + " at " + DateTime.Now.ToString("yyyy.MM.dd"));
                builder.AppendLine("----------------------------------------------------------------------------------------------------------*/");
                builder.AppendLine("using System;");
                builder.AppendLine("using System.Collections.Generic;");
                builder.AppendLine("using System.Linq;");
                builder.AppendLine("using System.Text;");
                builder.AppendLine("using System.Data;");
                if (m_fScgCore.fOption.optionUsingNamespace.Trim().Length > 0)
                {
                    builder.AppendLine(m_fScgCore.fOption.optionUsingNamespace);
                }
                builder.AppendLine();
                builder.AppendLine("namespace " + namespaceName);
                builder.AppendLine("{");
                if (access == false)
                {
                    builder.AppendLine("    public class F" + moduleName + "Caster : IDisposable");
                }
                else if (access == true)
                {
                    builder.AppendLine("    internal class F" + moduleName + "Caster : IDisposable");
                }
                builder.AppendLine("    {");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        private bool m_disposed = false;");
                builder.AppendLine("        // --");
                builder.AppendLine("        private static string m_" + moduleName.ToLower() + "Channel = string.Empty;");
                builder.AppendLine("        private static int m_" + moduleName.ToLower() + "Ttl = 0;");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        #region Class Construction and Destruction");
                builder.AppendLine();
                builder.AppendLine("        public F" + moduleName + "Caster(");
                builder.AppendLine("            )");
                builder.AppendLine("        {");
                builder.AppendLine();
                builder.AppendLine("        }");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        ~F" + moduleName + "Caster(");
                builder.AppendLine("           )");
                builder.AppendLine("        {");
                builder.AppendLine("            myDispose(false);");
                builder.AppendLine("        }");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        protected void myDispose(");
                builder.AppendLine("            bool disposing");
                builder.AppendLine("            )");
                builder.AppendLine("        {");
                builder.AppendLine("            if (!m_disposed)");
                builder.AppendLine("            {");
                builder.AppendLine("                if (disposing)");
                builder.AppendLine("                {");
                builder.AppendLine();
                builder.AppendLine("                }");
                builder.AppendLine();
                builder.AppendLine("                m_disposed = true;");
                builder.AppendLine("            }");
                builder.AppendLine("        }");
                builder.AppendLine();
                builder.AppendLine("        #endregion");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        #region IDisposable 멤버");
                builder.AppendLine();
                builder.AppendLine("        public void Dispose(");
                builder.AppendLine("            )");
                builder.AppendLine("        {");
                builder.AppendLine("            myDispose(true);");
                builder.AppendLine("            GC.SuppressFinalize(this);");
                builder.AppendLine("        }");
                builder.AppendLine();
                builder.AppendLine("        #endregion");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        #region Properties");
                builder.AppendLine();
                builder.AppendLine("        public static string " + moduleName.ToLower() + "Channel");
                builder.AppendLine("        {");
                builder.AppendLine("            get");
                builder.AppendLine("            {");
                builder.AppendLine("                try");
                builder.AppendLine("                {");
                builder.AppendLine("                    return m_" + moduleName.ToLower() + "Channel;");
                builder.AppendLine("                }");
                builder.AppendLine("                catch (Exception ex)");
                builder.AppendLine("                {");
                builder.AppendLine("                    FDebug.throwException(ex);");
                builder.AppendLine("                }");
                builder.AppendLine("                finally");
                builder.AppendLine("                {");
                builder.AppendLine();
                builder.AppendLine("                }");
                builder.AppendLine("                return null;");
                builder.AppendLine("           }");
                builder.AppendLine();
                builder.AppendLine("            set");
                builder.AppendLine("            {");
                builder.AppendLine("                try");
                builder.AppendLine("                {");
                builder.AppendLine("                    m_" + moduleName.ToLower() + "Channel = value;");
                builder.AppendLine("                }");
                builder.AppendLine("                catch (Exception ex)");
                builder.AppendLine("                {");
                builder.AppendLine("                    FDebug.throwException(ex);");
                builder.AppendLine("                }");
                builder.AppendLine("                finally");
                builder.AppendLine("                {");
                builder.AppendLine();
                builder.AppendLine("                }");
                builder.AppendLine("            }");
                builder.AppendLine("        }");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        public static int " + moduleName.ToLower() + "Ttl");
                builder.AppendLine("        {");
                builder.AppendLine("            get");
                builder.AppendLine("            {");
                builder.AppendLine("                try");
                builder.AppendLine("                {");
                builder.AppendLine("                    return m_" + moduleName.ToLower() + "Ttl;");
                builder.AppendLine("                }");
                builder.AppendLine("                catch (Exception ex)");
                builder.AppendLine("                {");
                builder.AppendLine("                    FDebug.throwException(ex);");
                builder.AppendLine("                }");
                builder.AppendLine("                finally");
                builder.AppendLine("                {");
                builder.AppendLine();
                builder.AppendLine("                }");
                builder.AppendLine("                return 0;");
                builder.AppendLine("           }");
                builder.AppendLine();
                builder.AppendLine("            set");
                builder.AppendLine("            {");
                builder.AppendLine("                try");
                builder.AppendLine("                {");
                builder.AppendLine("                    m_" + moduleName.ToLower() + "Ttl = value;");
                builder.AppendLine("                }");
                builder.AppendLine("                catch (Exception ex)");
                builder.AppendLine("                {");
                builder.AppendLine("                    FDebug.throwException(ex);");
                builder.AppendLine("                }");
                builder.AppendLine("                finally");
                builder.AppendLine("                {");
                builder.AppendLine();
                builder.AppendLine("                }");
                builder.AppendLine("            }");
                builder.AppendLine("        }");
                builder.AppendLine();
                builder.AppendLine("        #endregion");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        #region Methods");
                builder.AppendLine();

                // --

                foreach (UltraTreeNode tNodeGrp in tNodeNam.Nodes)
                {
                    foreach (UltraTreeNode tNode in tNodeGrp.Nodes)
                    {
                        fXmlNode = (FXmlNode)tNode.Tag;
                        if (fXmlNode.name != FXmlTagFunction.E_Function)
                        {
                            continue;
                        }

                        // -- 

                        functionName = fXmlNode.get_attrVal(FXmlTagFunction.A_FunctionName, FXmlTagFunction.D_FunctionName);
                        deliveryMode = fXmlNode.get_attrVal(FXmlTagFunction.A_FunctionDeliveryMode, FXmlTagFunction.D_FunctionDeliveryMode);
                        async = fXmlNode.get_attrVal(FXmlTagFunction.A_FunctionAsync, FXmlTagFunction.D_FunctionAsync);
                        guaranteed = fXmlNode.get_attrVal(FXmlTagFunction.A_FunctionGuaranteed, FXmlTagFunction.D_FunctionGuaranteed);

                        // --

                        if (index > 0)
                        {
                            builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                            builder.AppendLine();
                        }

                        // --

                        builder.AppendLine("        public static void " + functionName + "(");
                        builder.AppendLine("            FH101 instance,");

                        // --

                        if (deliveryMode == "REQUEST")
                        {
                            builder.AppendLine("            FXmlNode fXmlNodeIn,");
                            builder.AppendLine("            ref FXmlNode fXmlNodeOut");
                        }
                        else
                        {
                            builder.AppendLine("            FXmlNode fXmlNodeIn");
                        }
                       
                        // --

                        builder.AppendLine("            )");
                        builder.AppendLine("        {");
                        builder.AppendLine("            try");
                        builder.AppendLine("            {");

                        // --

                        if (deliveryMode == "REQUEST")
                        {
                            builder.AppendLine("                " + functionName + "(instance, fXmlNodeIn, ref fXmlNodeOut, \"\", 0);");
                        }
                        else
                        {
                            builder.AppendLine("                " + functionName + "(instance, fXmlNodeIn, \"\", 0);");
                        }                       

                        // --

                        builder.AppendLine("            }");
                        builder.AppendLine("            catch (Exception ex)");
                        builder.AppendLine("            {");
                        builder.AppendLine("                FDebug.throwException(ex);");
                        builder.AppendLine("            }");
                        builder.AppendLine("            finally");
                        builder.AppendLine("            {");
                        builder.AppendLine();
                        builder.AppendLine("            }");
                        builder.AppendLine("        }");
                        builder.AppendLine();
                        builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                        builder.AppendLine();
                        builder.AppendLine("        public static void " + functionName + "(");
                        builder.AppendLine("            FH101 instance,");
                        builder.AppendLine("            FXmlNode fXmlNodeIn,");

                        // --

                        if (deliveryMode == "REQUEST")
                        {
                            builder.AppendLine("            ref FXmlNode fXmlNodeOut,");
                        }

                        // --

                        builder.AppendLine("            string channel,");
                        builder.AppendLine("            int ttl");
                        builder.AppendLine("            )");
                        builder.AppendLine("        {");
                        builder.AppendLine("            try");
                        builder.AppendLine("            {");
                        builder.AppendLine("                if (null == channel || channel.Trim().Equals(" + '"' + '"' + "))");
                        builder.AppendLine("                {");
                        builder.AppendLine("                    if (null == m_" + moduleName.ToLower() + "Channel || m_" + moduleName.ToLower() + "Channel.Trim().Equals(" + '"' + '"' + "))");
                        builder.AppendLine("                    {");
                        builder.AppendLine("                        FDebug.throwFException(FH101.INVALID_CHANNEL);");
                        builder.AppendLine("                    }");
                        builder.AppendLine("                    channel = m_" + moduleName.ToLower() + "Channel;");
                        builder.AppendLine("                }");
                        builder.AppendLine("                ttl = (ttl <= 0 ? m_" + moduleName.ToLower() + "Ttl : ttl);");
                        builder.AppendLine();
                        
                        // --

                        if (deliveryMode == "REQUEST")
                        {
                            builder.AppendLine("                fXmlNodeOut = instance.sendRequest(");
                            builder.AppendLine("                    " + '"' + moduleName + '"' + ",");
                            builder.AppendLine("                    " + '"' + functionName + '"' + ",");
                            builder.AppendLine("                    fXmlNodeIn,");
                            builder.AppendLine("                    channel,");
                            builder.AppendLine("                    ttl,");
                            builder.AppendLine("                    " + async.ToLower());
                            builder.AppendLine("                    );");
                            builder.AppendLine();
                            builder.AppendLine("                if (null == fXmlNodeOut)");
                            builder.AppendLine("                {");
                            builder.AppendLine("                    FDebug.throwFException(FH101.INVALID_MESSAGE);");
                            builder.AppendLine("                }");
                        }
                        else if (deliveryMode == "UNICAST")
                        {
                            if (guaranteed == "True")
                            {
                                builder.AppendLine("                instance.sendGuaranteedUnicast(");
                                builder.AppendLine("                    " + '"' + moduleName + '"' + ",");
                                builder.AppendLine("                    " + '"' + functionName + '"' + ",");
                                builder.AppendLine("                    fXmlNodeIn,");
                                builder.AppendLine("                    channel,");
                                builder.AppendLine("                    ttl");
                                builder.AppendLine("                    );");
                            }
                            else
                            {
                                builder.AppendLine("                instance.sendUnicast(");
                                builder.AppendLine("                    " + '"' + moduleName + '"' + ",");
                                builder.AppendLine("                    " + '"' + functionName + '"' + ",");
                                builder.AppendLine("                    fXmlNodeIn,");
                                builder.AppendLine("                    channel,");
                                builder.AppendLine("                    ttl");
                                builder.AppendLine("                    );");
                            }
                        }
                        else
                        {
                            if (guaranteed == "True")
                            {
                                builder.AppendLine("                instance.sendGuaranteedMulticast(");
                                builder.AppendLine("                    " + '"' + moduleName + '"' + ",");
                                builder.AppendLine("                    " + '"' + functionName + '"' + ",");
                                builder.AppendLine("                    fXmlNodeIn,");
                                builder.AppendLine("                    channel,");
                                builder.AppendLine("                    ttl");
                                builder.AppendLine("                    );");
                            }
                            else
                            {
                                builder.AppendLine("                instance.sendMulticast(");
                                builder.AppendLine("                    " + '"' + moduleName + '"' + ",");
                                builder.AppendLine("                    " + '"' + functionName + '"' + ",");
                                builder.AppendLine("                    fXmlNodeIn,");
                                builder.AppendLine("                    channel,");
                                builder.AppendLine("                    ttl");
                                builder.AppendLine("                    );");
                            }
                        }                        

                        // --

                        builder.AppendLine("            }");
                        builder.AppendLine("            catch (Exception ex)");
                        builder.AppendLine("            {");
                        builder.AppendLine("                FDebug.throwException(ex);");
                        builder.AppendLine("            }");
                        builder.AppendLine("            finally");
                        builder.AppendLine("            {");
                        builder.AppendLine();
                        builder.AppendLine("            }");
                        builder.AppendLine("        }");
                        builder.AppendLine();

                        // --

                        index++;
                    }
                }

                // --

                builder.AppendLine("        #endregion");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("    }   // Class end");
                builder.AppendLine("}   // Namespace end");

                // --

                sw = new StreamWriter(path + "\\c_F" + moduleName + "Caster.cs", false, Encoding.Default);
                sw.Write(builder.ToString());
                sw.Close();
                sw.Dispose();
                sw = null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                    sw = null;
                }
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void generateH101BaseCodeSkeletonFile(
            bool access,
            string moduleName,
            string modulePath,
            string namespaceName,
            UltraTreeNode tNodeNam
            )
        {
            StreamWriter sw = null;
            FXmlNode fXmlNode = null;
            string path = string.Empty;
            string functionName = string.Empty;
            string deliveryMode = string.Empty;
            StringBuilder builder = null;
            int index = 0;

            try
            {
                path = modulePath;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                builder = new StringBuilder();

                // --

                builder.AppendLine("/*----------------------------------------------------------------------------------------------------------");
                builder.AppendLine(m_fScgCore.fOption.optionCopyright);
                builder.AppendLine("--");
                builder.AppendLine("--  Program Id      : c_F" + moduleName + "Skeleton.cs ");
                builder.AppendLine("--  Creator         : " + m_fScgCore.fOption.optionCreator);
                builder.AppendLine("--  Create Date     : " + DateTime.Now.ToString("yyyy.MM.dd"));
                builder.AppendLine("--  Description     : " + m_fScgCore.fOption.optionDescription);
                builder.AppendLine("--  History         : Created by " + m_fScgCore.fOption.optionCreator + " at " + DateTime.Now.ToString("yyyy.MM.dd"));
                builder.AppendLine("----------------------------------------------------------------------------------------------------------*/");
                builder.AppendLine("using System;");
                builder.AppendLine("using System.Collections.Generic;");
                builder.AppendLine("using System.Linq;");
                builder.AppendLine("using System.Text;");
                builder.AppendLine("using System.Data;");
                if (m_fScgCore.fOption.optionUsingNamespace.Trim().Length > 0)
                {
                    builder.AppendLine(m_fScgCore.fOption.optionUsingNamespace);
                }
                builder.AppendLine();
                builder.AppendLine("namespace " + namespaceName);
                builder.AppendLine("{");
                if (access == false)
                {
                    builder.AppendLine("    public class F" + moduleName + "Skeleton : F" + moduleName + "Tuner");
                }
                else if (access == true)
                {
                    builder.AppendLine("    internal class F" + moduleName + "Skeleton : F" + moduleName + "Tuner");
                }
                builder.AppendLine("    {");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        private bool m_disposed = false;");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        #region Class Construction and Destruction");
                builder.AppendLine();
                builder.AppendLine("        public F" + moduleName + "Skeleton(");
                builder.AppendLine("            FH101 fH101");
                builder.AppendLine("            ) : base(fH101)");
                builder.AppendLine("        {");
                builder.AppendLine();
                builder.AppendLine("        }");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        ~F" + moduleName + "Skeleton(");
                builder.AppendLine("           )");
                builder.AppendLine("        {");
                builder.AppendLine("            myDispose(false);");
                builder.AppendLine("        }");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        protected override void myDispose(");
                builder.AppendLine("            bool disposing");
                builder.AppendLine("            )");
                builder.AppendLine("        {");
                builder.AppendLine("            if (!m_disposed)");
                builder.AppendLine("            {");
                builder.AppendLine("                if (disposing)");
                builder.AppendLine("                {");
                builder.AppendLine();
                builder.AppendLine("                }");
                builder.AppendLine();
                builder.AppendLine("                m_disposed = true;");
                builder.AppendLine();
                builder.AppendLine("                // --");
                builder.AppendLine();
                builder.AppendLine("                base.myDispose(disposing);");
                builder.AppendLine("            }");
                builder.AppendLine("        }");
                builder.AppendLine();
                builder.AppendLine("        #endregion");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        #region Properties");
                builder.AppendLine();
                builder.AppendLine("        #endregion");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        #region Methods");
                builder.AppendLine();

                // --

                foreach (UltraTreeNode tNodeGrp in tNodeNam.Nodes)
                {
                    foreach (UltraTreeNode tNode in tNodeGrp.Nodes)
                    {
                        fXmlNode = (FXmlNode)tNode.Tag;
                        if (fXmlNode.name != FXmlTagFunction.E_Function)
                        {
                            continue;
                        }

                        // -- 

                        functionName = fXmlNode.get_attrVal(FXmlTagFunction.A_FunctionName, FXmlTagFunction.D_FunctionName);
                        deliveryMode = fXmlNode.get_attrVal(FXmlTagFunction.A_FunctionDeliveryMode, FXmlTagFunction.D_FunctionDeliveryMode);

                        // --

                        if (index > 0)
                        {
                            builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                            builder.AppendLine();
                        }

                        // --

                        builder.AppendLine("        public override void " + functionName + "(");

                        // --

                        if (deliveryMode == "REQUEST")
                        {
                            builder.AppendLine("            FXmlNode fXmlNodeIn,");
                            builder.AppendLine("            ref FXmlNode fXmlNodeOut");
                        }
                        else
                        {
                            builder.AppendLine("            FXmlNode fXmlNodeIn");                            
                        }

                        // --
                        
                        builder.AppendLine("            )");
                        builder.AppendLine("        {");
                        builder.AppendLine("            try");
                        builder.AppendLine("            {");
                        builder.AppendLine();
                        builder.AppendLine("            }");
                        builder.AppendLine("            catch (Exception ex)");
                        builder.AppendLine("            {");
                        builder.AppendLine("                FDebug.throwException(ex);");
                        builder.AppendLine("            }");
                        builder.AppendLine("            finally");
                        builder.AppendLine("            {");
                        builder.AppendLine();
                        builder.AppendLine("            }");
                        builder.AppendLine("        }");
                        builder.AppendLine();

                        // --

                        index++;
                    }
                }

                // --

                builder.AppendLine("        #endregion");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("    }   // Class end");
                builder.AppendLine("}   // Namespace end");

                // --

                sw = new StreamWriter(path + "\\c_F" + moduleName + "Skeleton.cs", false, Encoding.Default);
                sw.Write(builder.ToString());
                sw.Close();
                sw.Dispose();
                sw = null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                    sw = null;
                }
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void generateH101BaseCodeTunerFile(
            bool access,
            string moduleName,
            string modulePath,
            string namespaceName,
            UltraTreeNode tNodeNam
            )
        {
            StreamWriter sw = null;
            FXmlNode fXmlNode = null;
            string path = string.Empty;
            string functionName = string.Empty;
            string deliveryMode = string.Empty;
            StringBuilder builder = null;
            int index = 0;

            try
            {
                path = modulePath;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                builder = new StringBuilder();

                // --

                builder.AppendLine("/*----------------------------------------------------------------------------------------------------------");
                builder.AppendLine(m_fScgCore.fOption.optionCopyright);
                builder.AppendLine("--");
                builder.AppendLine("--  Program Id      : c_F" + moduleName + "Tuner.cs ");
                builder.AppendLine("--  Creator         : " + m_fScgCore.fOption.optionCreator);
                builder.AppendLine("--  Create Date     : " + DateTime.Now.ToString("yyyy.MM.dd"));
                builder.AppendLine("--  Description     : " + m_fScgCore.fOption.optionDescription);
                builder.AppendLine("--  History         : Created by " + m_fScgCore.fOption.optionCreator + " at " + DateTime.Now.ToString("yyyy.MM.dd"));
                builder.AppendLine("----------------------------------------------------------------------------------------------------------*/");
                builder.AppendLine("using System;");
                builder.AppendLine("using System.Collections.Generic;");
                builder.AppendLine("using System.Linq;");
                builder.AppendLine("using System.Text;");
                builder.AppendLine("using System.Data;");
                if (m_fScgCore.fOption.optionUsingNamespace.Trim().Length > 0)
                {
                    builder.AppendLine(m_fScgCore.fOption.optionUsingNamespace);
                }
                builder.AppendLine();
                builder.AppendLine("namespace " + namespaceName);
                builder.AppendLine("{");
                if (access == false)
                {
                    builder.AppendLine("    public abstract class F" + moduleName + "Tuner : FIH101Dispatcher, IDisposable");
                }
                else if (access == true)
                {
                    builder.AppendLine("    internal abstract class F" + moduleName + "Tuner : FIH101Dispatcher, IDisposable");
                }
                builder.AppendLine("    {");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        private bool m_disposed = false;");
                builder.AppendLine("        // --");
                builder.AppendLine("        private FH101 m_fH101 = null;");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        #region Class Construction and Destruction");
                builder.AppendLine();
                builder.AppendLine("        public F" + moduleName + "Tuner(");
                builder.AppendLine("            FH101 fH101");
                builder.AppendLine("            )");
                builder.AppendLine("        {");
                builder.AppendLine("            m_fH101 = fH101;");
                builder.AppendLine("        }");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        ~F" + moduleName + "Tuner(");
                builder.AppendLine("           )");
                builder.AppendLine("        {");
                builder.AppendLine("            myDispose(false);");
                builder.AppendLine("        }");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        protected virtual void myDispose(");
                builder.AppendLine("            bool disposing");
                builder.AppendLine("            )");
                builder.AppendLine("        {");
                builder.AppendLine("            if (!m_disposed)");
                builder.AppendLine("            {");
                builder.AppendLine("                if (disposing)");
                builder.AppendLine("                {");
                builder.AppendLine("                    m_fH101.Dispose();");
                builder.AppendLine("                    m_fH101 = null;");
                builder.AppendLine("                }");
                builder.AppendLine();
                builder.AppendLine("                m_disposed = true;");
                builder.AppendLine("            }");
                builder.AppendLine("        }");
                builder.AppendLine();
                builder.AppendLine("        #endregion");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        #region IDisposable member");
                builder.AppendLine();
                builder.AppendLine("        public void Dispose(");
                builder.AppendLine("            )");
                builder.AppendLine("        {");
                builder.AppendLine("            myDispose(true);");
                builder.AppendLine("            GC.SuppressFinalize(this);");
                builder.AppendLine("        }");
                builder.AppendLine();
                builder.AppendLine("        #endregion");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        #region Properties");
                builder.AppendLine();
                builder.AppendLine("        #endregion");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        #region FIH101Dispatcher member");
                builder.AppendLine();
                builder.AppendLine("        public Exception dispatch(");
                builder.AppendLine("            FH101DataReceivedArgs e");
                builder.AppendLine("            )");
                builder.AppendLine("        {");
                builder.AppendLine("            try");
                builder.AppendLine("            {");
                builder.AppendLine("                switch (e.operation)");
                builder.AppendLine("                {");

                // --

                foreach (UltraTreeNode tNodeGrp in tNodeNam.Nodes)
                {
                    foreach (UltraTreeNode tNode in tNodeGrp.Nodes)
                    {
                        fXmlNode = (FXmlNode)tNode.Tag;
                        if (fXmlNode.name != FXmlTagFunction.E_Function)
                        {
                            continue;
                        }

                        // -- 

                        functionName = fXmlNode.get_attrVal(FXmlTagFunction.A_FunctionName, FXmlTagFunction.D_FunctionName);

                        // --

                        builder.AppendLine("                    case \"" + functionName + "\":");
                        builder.AppendLine("                        recv_" + functionName + "(e);");
                        builder.AppendLine("                        break;");
                        builder.AppendLine();
                    }
                }

                // --

                builder.AppendLine("                    default:");
                builder.AppendLine("                        if (e.isRequest)");
                builder.AppendLine("                        {");
                builder.AppendLine("                            e.sendReply(" + '"' + "-23" + '"' + "," + " string.Format(" + '"' + "Unexpected Operation!(Operation:{0})" + '"' + "," + " e.operation)" + ");");
                builder.AppendLine("                        }");
                builder.AppendLine("                        // --");
                builder.AppendLine("                        FDebug.throwFException (");
                builder.AppendLine("                            string.Format(" + '"' + "Unexpected Operation!(Operation:{0})" + '"' + "," + " e.operation)");
                builder.AppendLine("                           );");
                builder.AppendLine("                        break;");
                builder.AppendLine("                }");
                builder.AppendLine("            }");
                builder.AppendLine("            catch (Exception ex)");
                builder.AppendLine("            {");
                builder.AppendLine("                FDebug.throwException(ex);");
                builder.AppendLine("            }");
                builder.AppendLine("            finally");
                builder.AppendLine("            {");
                builder.AppendLine();
                builder.AppendLine("            }");
                builder.AppendLine("            return null;");
                builder.AppendLine("        }");
                builder.AppendLine();
                builder.AppendLine("        #endregion");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("        #region Methods");
                builder.AppendLine();

                // --

                foreach (UltraTreeNode tNodeGrp in tNodeNam.Nodes)
                {
                    foreach (UltraTreeNode tNode in tNodeGrp.Nodes)
                    {
                        fXmlNode = (FXmlNode)tNode.Tag;
                        if (fXmlNode.name != FXmlTagFunction.E_Function)
                        {
                            continue;
                        }

                        // -- 

                        functionName = fXmlNode.get_attrVal(FXmlTagFunction.A_FunctionName, FXmlTagFunction.D_FunctionName);
                        deliveryMode = fXmlNode.get_attrVal(FXmlTagFunction.A_FunctionDeliveryMode, FXmlTagFunction.D_FunctionDeliveryMode);

                        // --

                        if (index > 0)
                        {
                            builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                            builder.AppendLine();
                        }

                        // --

                        builder.AppendLine("        public abstract void " + functionName + "(");

                        // --

                        if (deliveryMode == "REQUEST")
                        {
                            builder.AppendLine("            FXmlNode fXmlNodeIn,");
                            builder.AppendLine("            ref FXmlNode fXmlNodeOut");
                        }
                        else
                        {
                            builder.AppendLine("            FXmlNode fXmlNodeIn");                            
                        }

                        // --
                        
                        builder.AppendLine("            );");   // 추상 메소드
                        builder.AppendLine();
                        builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                        builder.AppendLine();
                        builder.AppendLine("        private void recv_" + functionName + "(");
                        builder.AppendLine("            FH101DataReceivedArgs e");
                        builder.AppendLine("            )");
                        builder.AppendLine("        {");
                        builder.AppendLine("            FXmlNode fXmlNodeIn = null;");

                        // --

                        if (deliveryMode == "REQUEST")
                        {
                            builder.AppendLine("            FXmlNode fXmlNodeOut = null;");
                        }                        

                        // --
                        
                        builder.AppendLine();
                        builder.AppendLine("            try");
                        builder.AppendLine("            {");
                        builder.AppendLine("                fXmlNodeIn = e.dataToXmlNode;");
                        
                        // --

                        if (deliveryMode == "REQUEST")
                        {
                            builder.AppendLine("                " + functionName + "(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */");
                            builder.AppendLine();
                            builder.AppendLine("                if (e.isRequest) /* Just RequestReply */");
                            builder.AppendLine("                {");
                            builder.AppendLine("                    e.sendReply(fXmlNodeOut);");
                            builder.AppendLine("                }");
                        }
                        else
                        {
                            builder.AppendLine("                " + functionName + "(fXmlNodeIn); /* Call User Procedure */");                            
                        }

                        // --                        

                        builder.AppendLine("            }");
                        builder.AppendLine("            catch (Exception ex)");
                        builder.AppendLine("            {");
                        builder.AppendLine("                FDebug.throwException(ex);");
                        builder.AppendLine("            }");
                        builder.AppendLine("            finally");
                        builder.AppendLine("            {");
                        builder.AppendLine("                fXmlNodeIn = null;");

                        // --

                        if (deliveryMode == "REQUEST")
                        {
                            builder.AppendLine("                fXmlNodeOut = null;");
                        }

                        // --
                        
                        builder.AppendLine("            }");
                        builder.AppendLine("        }");
                        builder.AppendLine();   // 메소드

                        // --

                        index++;
                    }
                }

                // --

                builder.AppendLine("        #endregion");
                builder.AppendLine();
                builder.AppendLine("        //------------------------------------------------------------------------------------------------------------------------");
                builder.AppendLine();
                builder.AppendLine("    }   // Class end");
                builder.AppendLine("}   // Namespace end");

                // --

                sw = new StreamWriter(path + "\\c_F" + moduleName + "Tuner.cs", false, Encoding.Default);
                sw.Write(builder.ToString());
                sw.Close();
                sw.Dispose();
                sw = null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                    sw = null;
                }
                fXmlNode = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        private bool hasCheckedNode(
            )
        {
            try
            {
                foreach (UltraTreeNode tNodeNam in tvwTree.Nodes)
                {
                    foreach (UltraTreeNode tNodeGrp in tNodeNam.Nodes)
                    {
                        foreach (UltraTreeNode tNode in tNodeGrp.Nodes)
                        {
                            if (tNode.CheckedState == CheckState.Checked)
                            {
                                return true;
                            }
                        }
                    }
                }
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

        private void deleteDirectory(
            string targetDir
            )
        {
            string[] files = null;
            string[] dirs = null;

            try
            {
                files = Directory.GetFiles(targetDir);
                foreach (string file in files)
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }

                // --

                dirs = Directory.GetDirectories(targetDir);
                foreach (string dir in dirs)
                {
                    deleteDirectory(dir);
                }
                
                // -- 

                Directory.Delete(targetDir, false);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                files = null;
                dirs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void refreshGenerate(
            )
        {
            try
            {
                loadGenerateFile();
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

        #region FSourceGenerator Form Event Handler

        private void FSourceGenerator_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();
                
                // --

                designTreeOfGenerate();
                tvwTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuScgPopupMenu]);

                // --

                m_fScgCore.fOption.fChildFormList.add(this, this.Text + " - [" + Path.GetFileName(m_fileName) + "]");
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fScgCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FSourceGenerator_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fileName == string.Empty)
                {
                    procMenuOpen();
                }
                else
                {
                    loadGenerateFile();
                }

                // --

                setTitle();

                // --

                tvwTree.Focus();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fScgCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FSourceGenerate_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fScgCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fScgCore.fWsmCore.fWsmContainer);
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
            ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuOpen)
                {
                    procMenuOpen();
                }
                else if (e.Tool.Key == FMenuKey.MenuScgGenerate)
                {
                    procMenuGenerate();
                }
                else if (e.Tool.Key == FMenuKey.MenuScgCheckAll)
                {
                    procMenuCheckAll();
                }
                else if (e.Tool.Key == FMenuKey.MenuScgUncheckAll)
                {
                    procMenuUncheckAll();
                }
                else if (e.Tool.Key == FMenuKey.MenuScgCheckAllParameter)
                {
                    procMenuCheckAllParameter();
                }
                else if (e.Tool.Key == FMenuKey.MenuScgCheckAllFunction)
                {
                    procMenuCheckAllFunction();
                }
                else if (e.Tool.Key == FMenuKey.MenuScgChooseAllFunction)
                {
                    procMenuChooseAllFunction();
                }
                else if (e.Tool.Key == FMenuKey.MenuScgChooseAllParameter)
                {
                    procMenuChooseAllParameter();
                }
                else if (e.Tool.Key == FMenuKey.MenuScgExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuScgCollapse)
                {
                    procMenuCollapse();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fScgCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region tvwTree Control Event Handler
        
        private void tvwTree_AfterCheck(
            object sender, 
            NodeEventArgs e
            )
        {
            CheckState state;

            try
            {
                state = e.TreeNode.CheckedState;

                // --

                foreach (UltraTreeNode tNode in e.TreeNode.Nodes)
                {
                    if (tNode.Override.NodeStyle != NodeStyle.CheckBox)
                    {
                        break;
                    }
                    // --
                    tNode.CheckedState = state;
                }               
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fScgCore.fWsmCore.fWsmContainer);
            }
            finally
            {
 
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
                if (e.Control && e.KeyCode == Keys.E)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuScgExpand].SharedProps.Enabled == true)
                    {
                        procMenuExpand();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.L)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuScgCollapse].SharedProps.Enabled == true)
                    {
                        procMenuCollapse();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.G)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuScgGenerate].SharedProps.Enabled == true)
                    {
                        procMenuGenerate();
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fScgCore.fWsmCore.fWsmContainer);
            }
            finally
            {
 
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
                procMenuSearchWord(e.searchWord);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fScgCore.fWsmCore.fWsmContainer);
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
            try
            {
                if (m_fileName != string.Empty)
                {
                    loadGenerateFile();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fScgCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion                

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
