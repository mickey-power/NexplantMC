/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FUserTagNameDefinition.cs
--  Creator         : duchoi
--  Create Date     : 2013.07.17
--  Description     : FAMate OPC Modeler User Tag Name Definition Form Class 
--  History         : Created by duchoi at 2013.07.17
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Nexplant.MC.OpcModeler
{
    public partial class FUserTagNameDefinition : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private FEventHandler m_fEventHandler = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FUserTagNameDefinition(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FUserTagNameDefinition(
            FOpmCore fOpmCore
            )
            :this()
        {
            base.fUIWizard = fOpmCore.fUIWizard;
            m_fOpmCore = fOpmCore;
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void myDispose(
            bool disposing
            )
        {
            if (m_disposed)
            {
                if (disposing)
                {
                    m_fOpmCore = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Mesthods

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
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

        private void designGridOfCaption(
            )
        {
            UltraDataSource uds = null;           

            try
            {
                uds = grdList.dataSource;
                
                // --
                
                uds.Band.Columns.Add("OPC Object Type");
                uds.Band.Columns.Add("Name");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("User Tag Name1");
                uds.Band.Columns.Add("User Tag Name2");
                uds.Band.Columns.Add("User Tag Name3");
                uds.Band.Columns.Add("User Tag Name4");
                uds.Band.Columns.Add("User Tag Name5");

                // --
                
                grdList.DisplayLayout.Bands[0].Columns["OPC Object Type"].Header.Fixed = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["OPC Object Type"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Name"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["User Tag Name1"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["User Tag Name2"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["User Tag Name3"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["User Tag Name4"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["User Tag Name5"].Width = 100;

                // --

                grdList.DisplayLayout.Bands[0].Columns["OPC Object Type"].CellAppearance.Image = Properties.Resources.OmdUserTagName;
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
       
        private void refreshGridOfUserTagName(
            )
        {
            object[] cellValues = null;
            FOpcDriver fOcd = null;
            
            try
            {
                grdList.beginUpdate(false);

                // --

                grdList.removeAllDataRow();               

                // --

                fOcd = m_fOpmCore.fOpmFileInfo.fOpcDriver;

                // --                        
              
                foreach (FUserTagName fUtn in fOcd.fChildUserTagNameCollection)
                {
                    cellValues = new object[]
                    {                       
                        fUtn.objectType.ToString(),
                        fUtn.name,               
                        fUtn.description,
                        fUtn.userTagName1,
                        fUtn.userTagName2,
                        fUtn.userTagName3,
                        fUtn.userTagName4,
                        fUtn.userTagName5                       
                    };
                    // --
                    grdList.appendDataRow(fUtn.uniqueIdToString, cellValues).Tag = fUtn;       
                }

                // --
                                
                grdList.endUpdate(false);

                // --
                
                if (grdList.Rows.Count > 0)
                {
                    grdList.ActiveRow = grdList.Rows[0];
                }
            }
            catch (Exception ex)
            {
                grdList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fOcd = null;
            }
        }
       
        //------------------------------------------------------------------------------------------------------------------------

        private void setPropOfCaption(
            )
        {            
            FIObject fObject = null;

            try
            {

                fObject = (FIObject)grdList.activeDataRow.Tag;

                // --

                if (fObject == null)
                {
                    return;
                }

                // -- 

                pgdProp.selectedObject = new FPropUtn(m_fOpmCore, pgdProp, (FUserTagName)fObject);
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

        protected void refreshObject(
            FIObject fObject
            )
        {
            FUserTagName fUtn = null;
            string key = string.Empty;
            object[] cellValues = null;
            UltraDataRow dataRow = null;

            try
            {
                fUtn = (FUserTagName)fObject;

                // --

                cellValues = new object[]
                {
                    fUtn.objectType.ToString(),
                    fUtn.name,               
                    fUtn.description,
                    fUtn.userTagName1,
                    fUtn.userTagName2,
                    fUtn.userTagName3,
                    fUtn.userTagName4,
                    fUtn.userTagName5
                };                

                // --

                grdList.beginUpdate();

                // --                   
    
                dataRow = grdList.appendOrUpdateDataRow(fUtn.uniqueIdToString, cellValues);                
                FCommon.refreshGridRowOfObject(fObject, grdList.Rows.GetRowWithListIndex(dataRow.Index));
                
                //--
                
                grdList.endUpdate();                
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fUtn = null;
                dataRow = null;
            }          
        }
        
        #endregion 

        //------------------------------------------------------------------------------------------------------------------------

        #region FUserTagNameDefinition Form Event Handler

        private void FUserTagNameDefinition_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfCaption();

                // --

                m_fEventHandler = new FEventHandler(m_fOpmCore.fOpmFileInfo.fOpcDriver, grdList);
                // --
                m_fEventHandler.ObjectModifyCompleted += new FObjectModifyCompletedEventHandler(m_fEventHandler_ObjectModifyCompleted);

                // --

                m_fOpmCore.fOption.fChildFormList.add(this);
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

        private void FUserTagNameDefinition_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfUserTagName();

                // --

                grdList.Focus();
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

        private void FUserTagNameDefinition_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                if (m_fEventHandler != null)
                {
                    m_fOpmCore.fOpmFileInfo.fOpcDriver.waitEventHandlingCompleted();

                    // --
                    
                    m_fEventHandler.Dispose();
                    // --
                    m_fEventHandler.ObjectModifyCompleted -= new FObjectModifyCompletedEventHandler(m_fEventHandler_ObjectModifyCompleted);
                    // --                    
                    m_fEventHandler = null;
                }

                // --

                m_fOpmCore.fOption.fChildFormList.remove(this);
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

                setPropOfCaption();
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

        #region m_fEventHandler Object Event Handler

        private void m_fEventHandler_ObjectModifyCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (e.fObject.fObjectType == FObjectType.UserTagName)
                {
                    refreshObject(e.fObject);
                }
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

        #region rstToolbar Event Handler

        private void rstToolbar_SearchRequested(
            object sender, 
            FSearchRequestedEventArgs e
            )
        {
            FIObject fResult = null;

            try
            {
                FCursor.waitCursor();

                // --

                fResult = m_fOpmCore.fOpmFileInfo.fOpcDriver.searchUserTagNameSeries((FIObject)grdList.activeDataRow.Tag, e.searchWord);
                if (fResult == null)
                {
                    FMessageBox.showInformation("Search", m_fOpmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
                    return;
                }

                // --

                grdList.activateDataRow(fResult.uniqueIdToString);  
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fResult = null;
                FCursor.defaultCursor();
            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
