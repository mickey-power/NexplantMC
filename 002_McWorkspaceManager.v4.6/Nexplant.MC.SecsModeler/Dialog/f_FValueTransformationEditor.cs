/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FValueTransformationEditor.cs
--  Creator         : spike.lee
--  Create Date     : 2011.02.28
--  Description     : FAMate SECS Modeler Value Transformation Editor Form Class 
--  History         : Created by spike.lee at 2011.02.28
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
    public partial class FValueTransformationEditor : Nexplant.MC.Core.FaUIs.FBaseStandardForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private FFormat m_fFormat = FFormat.Ascii;
        private FIValueTransformer m_fValueTransformer = null;
        // --
        private int m_keyIndex = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FValueTransformationEditor(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FValueTransformationEditor(
            FSsmCore fSsmCore,
            FFormat fFormat,
            FIValueTransformer fValueTransformer
            )
            : this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;
            m_fFormat = fFormat;
            m_fValueTransformer = fValueTransformer;
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
                    m_fValueTransformer = null;
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
                    mnuMenu.Tools[FMenuKey.MenuVteInsertBeforeValueFormula].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuVteInsertAfterValueFormula].SharedProps.Enabled = true;
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

        private void deisngGridOfValueFormula(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Key");
                uds.Band.Columns.Add("Index");
                uds.Band.Columns.Add("Value Formula");                

                // --

                grdList.DisplayLayout.Bands[0].Columns["Index"].CellAppearance.Image = Properties.Resources.ValueFormula;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Key"].Hidden = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Index"].Width = 60;
                grdList.DisplayLayout.Bands[0].Columns["Value Formula"].Width = 120;                

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

        private void refreshGridOfValueFormula(
            )
        {
            FIValueFormulaCollection fValueFormulaCollection = null;
            FIValueFormula fValueFormula = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;

            try
            {
                grdList.beginUpdate();

                // --

                fValueFormulaCollection = m_fValueTransformer.fValueFormulaCollection;                
                // --
                for (int i = 0; i < fValueFormulaCollection.count; i++) 
                {
                    fValueFormula = fValueFormulaCollection[i];
                    // --
                    cellValues = new object[] 
                    {
                        m_keyIndex.ToString(),
                        i.ToString(),
                        fValueFormula.ToString()
                    };
                    // --
                    dataRow = grdList.appendDataRow((string)cellValues[0], cellValues);
                    dataRow.Tag = fValueFormula;

                    // --

                    m_keyIndex++;
                }

                // --

                grdList.endUpdate();

                // --

                if (grdList.Rows.Count > 0)
                {
                    grdList.ActiveRow = grdList.Rows[0];
                }
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fValueFormulaCollection = null;
                fValueFormula = null;
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void updateValueFormulaIndex(
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

        private void procMenuInsertBeforeValueFormula(
            )
        {
            FIValueFormula fValueFormula = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            int index = 0;            

            try
            {
                index = grdList.activeDataRow.Index;

                // --

                if (m_fFormat == FFormat.Ascii || m_fFormat == FFormat.A2 || m_fFormat == FFormat.JIS8)
                {
                    // ***
                    // Format이 String 계열인 경우 Trim Value Formula를 Default로 사용한다.
                    // ***
                    fValueFormula = m_fValueTransformer.insertBeforeValueFormula(index, new FTrim());
                }
                else
                {
                    // ***
                    // Format이 Numeric 계열인 경우 Select Array Value Formula를 Default로 사용한다.
                    // ***
                    fValueFormula = m_fValueTransformer.insertBeforeValueFormula(index, new FSelectArray());
                }

                // --

                cellValues = new object[] 
                {
                    m_keyIndex.ToString(),
                    string.Empty,
                    fValueFormula.ToString()
                };
                m_keyIndex++;
                // --
                dataRow = grdList.insertBeforeDataRow(index, (string)cellValues[0], cellValues);
                dataRow.Tag = fValueFormula;
                updateValueFormulaIndex();
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
                fValueFormula = null;
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuInsertAfterValueFormula(
            )
        {
            FIValueFormula fValueFormula = null;
            object[] cellValues = null;
            int index = 0;
            UltraDataRow dataRow = null;

            try
            {
                index = grdList.activeDataRow.Index;

                // --

                if (m_fFormat == FFormat.Ascii || m_fFormat == FFormat.A2 || m_fFormat == FFormat.JIS8)
                {
                    // ***
                    // Format이 String 계열인 경우 Trim Value Formula를 Default로 사용한다.
                    // ***
                    fValueFormula = m_fValueTransformer.insertAfterValueFormula(index, new FTrim());
                }
                else
                {
                    // ***
                    // Format이 Numeric 계열인 경우 Select Array Value Formula를 Default로 사용한다.
                    // ***
                    fValueFormula = m_fValueTransformer.insertAfterValueFormula(index, new FSelectArray());
                }

                // --

                cellValues = new object[] 
                {
                    m_keyIndex.ToString(),
                    string.Empty,
                    fValueFormula.ToString()
                };
                m_keyIndex++;
                // --
                dataRow = grdList.insertAfterDataRow(index, (string)cellValues[0], cellValues);
                dataRow.Tag = fValueFormula;
                updateValueFormulaIndex();
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
                fValueFormula = null;
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAppendValueFormula(
            )
        {
            FIValueFormula fValueFormula = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;

            try
            {
                if (m_fFormat == FFormat.Ascii || m_fFormat == FFormat.A2 || m_fFormat == FFormat.JIS8)
                {
                    // ***
                    // Format이 String 계열인 경우 Trim Value Formula를 Default로 사용한다.
                    // ***
                    fValueFormula = m_fValueTransformer.appendValueFormula(new FTrim());
                }
                else
                {
                    // ***
                    // Format이 Numeric 계열인 경우 Select Array Value Formula를 Default로 사용한다.
                    // ***
                    fValueFormula = m_fValueTransformer.appendValueFormula(new FSelectArray());
                }

                // --

                cellValues = new object[] 
                {
                    m_keyIndex.ToString(),
                    string.Empty,
                    fValueFormula.ToString()
                };
                m_keyIndex++;
                // --
                dataRow = grdList.appendDataRow((string)cellValues[0], cellValues);
                dataRow.Tag = fValueFormula;
                updateValueFormulaIndex();
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
                fValueFormula = null;
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRemoveValueFormula(
            )
        {
            int index = 0;

            try
            {
                index = grdList.activeDataRow.Index;

                // --

                m_fValueTransformer.removeValueFormula(index);
                grdList.removeDataRow(index);
                updateValueFormulaIndex();

                // --

                if (grdList.Rows.Count == 0)
                {
                    initPropOfValueFormula();
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

        private void procMenuRemoveAllValueFormula(
            )
        {
            try
            {
                m_fValueTransformer.removeAllValueFormula();
                grdList.removeAllDataRow();

                // --

                initPropOfValueFormula();
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
                m_fValueTransformer.moveUpValueFormula(grdList.activeDataRow.Index);
                // --
                grdList.moveUpDataRow(grdList.activeDataRow.Index);
                updateValueFormulaIndex();
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
                m_fValueTransformer.moveDownValueFormula(grdList.activeDataRow.Index);
                // --
                grdList.moveDownDataRow(grdList.activeDataRow.Index);
                updateValueFormulaIndex();
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

        private void initPropOfValueFormula(
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

        private void setPropOfValueFormula(
            )
        {
            try
            {
                pgdProp.selectedObject = new FPropVfm(
                    m_fSsmCore,
                    pgdProp,
                    m_fValueTransformer,
                    (FIValueFormula)grdList.activeDataRow.Tag,
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

        #region FValueTransformationEditor Form Event Handler

        private void FValueTransformationEditor_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                deisngGridOfValueFormula();
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

        private void FValueTransformationEditor_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfValueFormula();
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

        private void FValueTransformationEditor_KeyDown(
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

                if (e.Tool.Key == FMenuKey.MenuVteInsertBeforeValueFormula)
                {
                    procMenuInsertBeforeValueFormula();
                }
                else if (e.Tool.Key == FMenuKey.MenuVteInsertAfterValueFormula)
                {
                    procMenuInsertAfterValueFormula();
                }
                else if (e.Tool.Key == FMenuKey.MenuVteAppendValueFormula)
                {
                    procMenuAppendValueFormula();
                }
                else if (e.Tool.Key == FMenuKey.MenuVteRemoveValueFormula)
                {
                    procMenuRemoveValueFormula();
                }
                else if (e.Tool.Key == FMenuKey.MenuVteRemoveAllValueFormula)
                {
                    procMenuRemoveAllValueFormula();
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

                setPropOfValueFormula();
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

    }   // Class end
}   // Namespace end
