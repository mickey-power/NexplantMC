/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FValueEditor.cs
--  Creator         : kitae kim
--  Create Date     : 2011.08.10
--  Description     : FAMate Workspace Manager ValueEditor Form Class 
--  History         : Created by kitae kim at 2011.08.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.OpcModeler
{
    public partial class FMultiItemEditor : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FOpmCore m_fOpmCore = null;
        private FIObject m_fIObject = null;
        // --
        private List<string> m_changeList = null;
        // --
        private bool m_applyAll = true;
        private int m_startIndex = 0;
        private int m_endIndex = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FMultiItemEditor(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FMultiItemEditor(
            FOpmCore fOpmCore,
            FIObject fIObject
            )
            : this()
        {
            base.fUIWizard = fOpmCore.fUIWizard;
            m_fOpmCore = fOpmCore;
            m_fIObject = fIObject;
            m_changeList = new List<string>();
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
                    m_fIObject = null;
                    // --
                    m_changeList = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties
        
        public FIObject fIObject
        {
            get
            {
                try
                {
                    return m_fIObject;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        public List<string> ChangedPropertyList
        {
            get
            {
                try
                {
                    return m_changeList;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool ApplyAll
        {
            get
            {
                try
                {
                    return m_applyAll;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int StartIndex
        {
            get
            {
                try
                {
                    return m_startIndex;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int EndIndex
        {
            get
            {
                try
                {
                    return m_endIndex;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                return 0;
            }
        }
     
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region  btnOk Control Event Handler

        private void btnOk_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
                m_applyAll = chkAll.Checked;
                if (!chkAll.Checked)
                {
                    string tempIndex = txtFrom.Text.Trim();
                    if (tempIndex == string.Empty)
                    {
                        FMessageBox.showInformation("Multi Item Editor", "Please, Input start index.", this);
                        return;
                    }

                    if (!int.TryParse(tempIndex, out m_startIndex))
                    {
                        FMessageBox.showInformation("Multi Item Editor", "The start index format is not integer.", this);
                        return;
                    }

                    tempIndex = txtTo.Text.Trim();
                    if (tempIndex == string.Empty)
                    {
                        FMessageBox.showInformation("Multi Item Editor", "Please, Input end index.", this);
                        return;
                    }

                    if (!int.TryParse(tempIndex, out m_endIndex))
                    {
                        FMessageBox.showInformation("Multi Item Editor", "The end index format is not integer.", this);
                        return;
                    }
                }

                // --

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
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

        #region FOpcDeviceModeler Form Event Handler

        private void FMultiItemEditor_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                pgdProp.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(pgdProp_PropertyValueChanged);
                if (m_fIObject.fObjectType == FObjectType.OpcEventItem)
                {
                    // --
                    pgdProp.selectedObject = new FPropMultiOei(m_fOpmCore, pgdProp, (FOpcEventItem)m_fIObject);
                }
                else if (m_fIObject.fObjectType == FObjectType.OpcItem)
                {
                    // --
                    pgdProp.selectedObject = new FPropMultiOit(m_fOpmCore, pgdProp, (FOpcItem)m_fIObject);
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

        #region Property Grid Event Handler

        private void pgdProp_PropertyValueChanged(
            object s, 
            System.Windows.Forms.PropertyValueChangedEventArgs e
            )
        {
            try
            {
                if (!m_changeList.Contains(e.ChangedItem.Label))
                {
                    m_changeList.Add(e.ChangedItem.Label);
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

        #region CheckBox Event Handler

        private void chkAll_CheckedChanged(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                txtFrom.Enabled = !chkAll.Checked;
                txtTo.Enabled = !chkAll.Checked;
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

    }   // Class end
}   // Namespace end