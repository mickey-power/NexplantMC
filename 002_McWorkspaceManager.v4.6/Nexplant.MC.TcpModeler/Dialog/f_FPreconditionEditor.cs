/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FPreconditionEditor.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.10
--  Description     : FAMate TCP Modeler Precondition Editor Form Class 
--  History         : Created by spike.lee at 2011.03.10
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
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Nexplant.MC.TcpModeler
{
    public partial class FPreconditionEditor : Nexplant.MC.Core.FaUIs.FBaseStandardForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcmCore m_fTcmCore = null;
        private FFormat m_fFormat = FFormat.Ascii;
        private FIPrecondition m_fPrecondition = null;
        // --
        private int m_keyIndex = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPreconditionEditor(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPreconditionEditor(
            FTcmCore fTcmCore,
            FFormat fFormat,
            FIPrecondition fPrecondition
            )
            : this()
        {
            base.fUIWizard = fTcmCore.fUIWizard;
            m_fTcmCore = fTcmCore;
            m_fFormat = fFormat;
            m_fPrecondition = fPrecondition;
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
                    m_fTcmCore = null;
                    m_fPrecondition = null;
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
                    mnuMenu.Tools[FMenuKey.MenuPrcAppendValue].SharedProps.Enabled = true;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuPrcInsertBeforeValue].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuPrcInsertAfterValue].SharedProps.Enabled = true;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuPrcAppendValue].SharedProps.Enabled = true;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuPrcRemoveValue].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuPrcRemoveAllValue].SharedProps.Enabled = true;

                    // --

                    if (grdList.activeDataRow.Index > 0)
                    {
                        mnuMenu.Tools[FMenuKey.MenuPrcMoveUp].SharedProps.Enabled = true;
                    }

                    if (grdList.activeDataRow.Index < grdList.Rows.Count - 1)
                    {
                        mnuMenu.Tools[FMenuKey.MenuPrcMoveDown].SharedProps.Enabled = true;
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

        private void designGridOfValue(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Key");
                uds.Band.Columns.Add("Index");
                uds.Band.Columns.Add("Precondition Value");                

                // --

                grdList.DisplayLayout.Bands[0].Columns["Index"].CellAppearance.Image = Properties.Resources.Value;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Key"].Hidden = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Index"].Width = 60;
                grdList.DisplayLayout.Bands[0].Columns["Precondition Value"].Width = 120;                

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

        private void refreshGridOfValue(
            )
        {
            FIPreconditionValueCollection fPreconditionValueCollection = null;
            string value = string.Empty;
            object[] cellValues = null;
            UltraDataRow dataRow = null;

            try
            {
                grdList.beginUpdate();

                // --

                fPreconditionValueCollection = m_fPrecondition.fPreconditionValueCollection;
                // --
                for (int i = 0; i < fPreconditionValueCollection.count; i++) 
                {
                    value = fPreconditionValueCollection[i];
                    // --
                    cellValues = new object[] 
                    {
                        m_keyIndex.ToString(),
                        i.ToString(),
                        value
                    };
                    // --
                    dataRow = grdList.appendDataRow((string)cellValues[0], cellValues);
                    dataRow.Tag = value;

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
                fPreconditionValueCollection = null;
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void updateValueIndex(
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

        private void procMenuInsertBeforeValue(
            )
        {
            string value = string.Empty;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            int index = 0;            

            try
            {
                index = grdList.activeDataRow.Index;

                // --

                if (m_fFormat == FFormat.Ascii || m_fFormat == FFormat.A2 || m_fFormat == FFormat.JIS8)
                {
                    value = m_fPrecondition.insertBeforeStringValue(index, " ");
                }
                else if (m_fFormat == FFormat.Binary)
                {
                    value = m_fPrecondition.insertBeforeStringValue(index, "00");
                }
                else if (m_fFormat == FFormat.Boolean)
                {
                    value = m_fPrecondition.insertBeforeStringValue(index, "T");
                }
                else
                {
                    value = m_fPrecondition.insertBeforeStringValue(index, "0");
                }

                // --

                cellValues = new object[] 
                {
                    m_keyIndex.ToString(),
                    string.Empty,
                    value.ToString()
                };
                m_keyIndex++;
                // --
                dataRow = grdList.insertBeforeDataRow(index, (string)cellValues[0], cellValues);
                dataRow.Tag = value;
                updateValueIndex();
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
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuInsertAfterValue(
            )
        {
            string value = string.Empty;
            object[] cellValues = null;
            int index = 0;
            UltraDataRow dataRow = null;

            try
            {
                index = grdList.activeDataRow.Index;

                // --

                if (m_fFormat == FFormat.Ascii || m_fFormat == FFormat.A2 || m_fFormat == FFormat.JIS8)
                {
                    value = m_fPrecondition.insertAfterStringValue(index, " ");
                }
                else if (m_fFormat == FFormat.Binary)
                {
                    value = m_fPrecondition.insertAfterStringValue(index, "00");
                }
                else if (m_fFormat == FFormat.Boolean)
                {
                    value = m_fPrecondition.insertAfterStringValue(index, "T");
                }
                else
                {
                    value = m_fPrecondition.insertAfterStringValue(index, "0");
                }

                // --

                cellValues = new object[] 
                {
                    m_keyIndex.ToString(),
                    string.Empty,
                    value.ToString()
                };
                m_keyIndex++;
                // --
                dataRow = grdList.insertAfterDataRow(index, (string)cellValues[0], cellValues);
                dataRow.Tag = value;
                updateValueIndex();
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
                value = null;
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAppendValue(
            )
        {
            string value = string.Empty;
            object[] cellValues = null;
            UltraDataRow dataRow = null;

            try
            {
                if (m_fFormat == FFormat.Ascii || m_fFormat == FFormat.A2 || m_fFormat == FFormat.JIS8)
                {
                    value = m_fPrecondition.appendStringValue(" ");
                }
                else if (m_fFormat == FFormat.Binary)
                {
                    value = m_fPrecondition.appendStringValue("00");
                }
                else if (m_fFormat == FFormat.Boolean)
                {
                    value = m_fPrecondition.appendStringValue("T");
                }
                else
                {
                    value = m_fPrecondition.appendStringValue("0");
                }

                // --

                cellValues = new object[] 
                {
                    m_keyIndex.ToString(),
                    string.Empty,
                    value.ToString()
                };
                m_keyIndex++;
                // --
                dataRow = grdList.appendDataRow((string)cellValues[0], cellValues);
                dataRow.Tag = value;
                updateValueIndex();
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
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRemoveValue(
            )
        {
            int index = 0;

            try
            {
                index = grdList.activeDataRow.Index;

                // --

                m_fPrecondition.removeValue(index);
                grdList.removeDataRow(index);
                updateValueIndex();

                // --

                if (grdList.Rows.Count == 0)
                {
                    initPropOfValue();
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

        private void procMenuRemoveAllValue(
            )
        {
            try
            {
                m_fPrecondition.removeAllValue();
                grdList.removeAllDataRow();

                // --

                initPropOfValue();
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
                m_fPrecondition.moveUpValue(grdList.activeDataRow.Index);
                // --
                grdList.moveUpDataRow(grdList.activeDataRow.Index);
                updateValueIndex();
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
                m_fPrecondition.moveDownValue(grdList.activeDataRow.Index);
                // --
                grdList.moveDownDataRow(grdList.activeDataRow.Index);
                updateValueIndex();
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

        private void initPropOfValue(
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
                pgdProp.selectedObject = new FPropPrc(
                    m_fTcmCore,
                    pgdProp,
                    m_fPrecondition,
                    (string)grdList.activeDataRow.Tag,
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

                designGridOfValue();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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

                refreshGridOfValue();
                controlMenu();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FPreconditionEditor_KeyDown(
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

                if (e.Tool.Key == FMenuKey.MenuPrcInsertBeforeValue)
                {
                    procMenuInsertBeforeValue();
                }
                else if (e.Tool.Key == FMenuKey.MenuPrcInsertAfterValue)
                {
                    procMenuInsertAfterValue();
                }
                else if (e.Tool.Key == FMenuKey.MenuPrcAppendValue)
                {
                    procMenuAppendValue();
                }
                else if (e.Tool.Key == FMenuKey.MenuPrcRemoveValue)
                {
                    procMenuRemoveValue();
                }
                else if (e.Tool.Key == FMenuKey.MenuPrcRemoveAllValue)
                {
                    procMenuRemoveAllValue();
                }
                else if (e.Tool.Key == FMenuKey.MenuPrcMoveUp)
                {
                    procMenuMoveUp();
                }
                else if (e.Tool.Key == FMenuKey.MenuPrcMoveDown)
                {
                    procMenuMoveDown();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
