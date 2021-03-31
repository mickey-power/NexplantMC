/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDynPropGrid.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.28
--  Description     : FAMate Core FaUIs Dynamic Property Grid Control
--  History         : Created by spike.lee at 2010.12.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FDynPropGrid : PropertyGrid
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FDynPropNoticeRaisedEventHandler DynPropNoticeRaised = null;
        public event FDynPropGridRefreshRequestedEventHandler DynPropGridRefreshRequested = null;

        private bool m_disposed = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDynPropGrid(
            )
        {
            InitializeComponent();
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    term();
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FDynPropBase selectedObject
        {
            get
            {
                try
                {
                    if (this.SelectedObject == null)
                    {
                        return null;
                    }
                    else
                    {
                        return (FDynPropBase)((FDynPropGridTypeDescriptor)this.SelectedObject).GetPropertyOwner(null);
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

            set
            {
                try
                {
                    if (this.selectedObject != null)
                    {
                        ((FDynPropBase)((FDynPropGridTypeDescriptor)this.SelectedObject).GetPropertyOwner(null)).Dispose();
                    }

                    // --

                    if (value == null)
                    {
                        this.SelectedObject = null;
                    }
                    else
                    {
                        this.SelectedObject = value.fTypeDescriptor;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                this.HandleCreated += new EventHandler(FDynPropGrid_HandleCreated);
                this.SelectedObjectsChanged += new EventHandler(FDynPropGrid_SelectedObjectsChanged);
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

        private void term(
            )
        {
            try
            {
                this.HandleCreated -= new EventHandler(FDynPropGrid_HandleCreated);
                this.SelectedObjectsChanged -= new EventHandler(FDynPropGrid_SelectedObjectsChanged);
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

        public void onDynPropNoticeRaised(
            FDynPropBase fDynProp, 
            string contents
            )
        {
            try
            {
                if (DynPropNoticeRaised != null)
                {
                    DynPropNoticeRaised(this, new FDynPropNoticeRaisedEventArgs(fDynProp, contents));
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

        public void onDynPropGridRefreshRequested(
            )
        {
            try
            {
                if (DynPropGridRefreshRequested != null)
                {
                    DynPropGridRefreshRequested(this, new EventArgs());
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

        #region FDynPropGrid Control Event Handler

        private void FDynPropGrid_HandleCreated(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                //this.Font = new Font("Verdana", 8.25F);
                //this.BackColor = Color.Gainsboro;
                //this.CategoryForeColor = Color.DimGray;
                //this.CommandsBackColor = Color.Gainsboro;
                //this.LineColor = Color.Silver;
                //this.PropertySort = PropertySort.Categorized;
                //this.HelpVisible = false;
                //this.ToolbarVisible = false;
                //this.ViewBackColor = Color.WhiteSmoke;
                //this.ViewForeColor = Color.Black;
                //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FDynPropGrid", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FDynPropGrid Control Event Handler

        private void FDynPropGrid_SelectedObjectsChanged(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                if (
                    this.selectedObject != null &&
                    this.selectedObject.fUIWizard != null
                   )
                {
                    this.selectedObject.fUIWizard.changeControlCaption(this);
                }                
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FDynPropGrid", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
