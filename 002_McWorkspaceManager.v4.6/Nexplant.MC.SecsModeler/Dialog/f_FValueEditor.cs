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
 *                    Modified by byJeon at 2011.08.11
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
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Nexplant.MC.SecsModeler
{
    public partial class FValueEditor : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FSsmCore m_fSsmCore = null;
        private FIObject m_fObject = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FValueEditor(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FValueEditor(
            FSsmCore fSsmCore,            
            FIObject fObject
            )
            : this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;
            m_fObject = fObject;
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
                    m_fObject = null;
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
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FValueEditor Form Event Handler

        private void FValueEditor_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
                
                if (m_fObject.fObjectType == FObjectType.SecsItem)
                {
                    rtxValue.Text = ((FSecsItem)m_fObject).originalStringValue;
                }
                else if (m_fObject.fObjectType == FObjectType.HostItem)
                {
                    rtxValue.Text = ((FHostItem)m_fObject).originalStringValue;
                }
                else if (m_fObject.fObjectType == FObjectType.Data)
                {
                    rtxValue.Text = ((FData)m_fObject).originalStringValue;
                }
                else if (m_fObject.fObjectType == FObjectType.Environment)
                {
                    rtxValue.Text = ((FEnvironment)m_fObject).stringValue;
                }
                else if (m_fObject.fObjectType == FObjectType.Column)
                {
                    rtxValue.Text = ((FColumn)m_fObject).originalStringValue;
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
                
                if (m_fObject.fObjectType == FObjectType.SecsItem)
                {
                    ((FSecsItem)m_fObject).originalStringValue = rtxValue.Text;
                }
                else if (m_fObject.fObjectType == FObjectType.HostItem)
                {
                    ((FHostItem)m_fObject).originalStringValue = rtxValue.Text;
                }
                else if (m_fObject.fObjectType == FObjectType.Data)
                {
                    ((FData)m_fObject).originalStringValue = rtxValue.Text;
                }
                else if (m_fObject.fObjectType == FObjectType.Environment)
                {
                    ((FEnvironment)m_fObject).stringValue = rtxValue.Text;
                }
                else if (m_fObject.fObjectType == FObjectType.Column)
                {
                    ((FColumn)m_fObject).originalStringValue = rtxValue.Text;
                }

                // --

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
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

    }   // Class end
}   // Namespace end
