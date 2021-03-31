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
    public partial class FPlcAddressEditor : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FOpmCore m_fOpmCore = null;
        private FIObject m_fIObject = null;
        // --
        private int m_dataBlock = 0;
        private int m_adjustValue = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPlcAddressEditor(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPlcAddressEditor(
            FOpmCore fOpmCore,
            FIObject fIObject
            )
            : this()
        {
            base.fUIWizard = fOpmCore.fUIWizard;
            m_fOpmCore = fOpmCore;
            m_fIObject = fIObject;
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

        public int DataBlock
        {
            get
            {
                try
                {
                    return m_dataBlock;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        public int AdjustValue
        {
            get
            {
                try
                {
                    return m_adjustValue;
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
            string oldVal = string.Empty;
            string newVal = string.Empty;
            // --
            int iOldVal = 0;
            int iNewVal = 0;

            try
            {
                FCursor.waitCursor();

                // --
                oldVal = txtOld.Text;
                newVal = txtNew.Text;

                // --
                if (!int.TryParse(txtDataBlock.Text, out m_dataBlock))
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0015", new object[] { "Data Block" }));
                    return;
                }

                // --
                if (!int.TryParse(oldVal, out iOldVal))
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0015", new object[] { "Old Address" }));
                    return;
                }

                // --
                if (!int.TryParse(newVal, out iNewVal))
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0015", new object[] { "New Address" }));
                    return;
                }

                // --
                m_adjustValue = iNewVal - iOldVal;
                                
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

        #region FPlcAddressEditor Form Event Handler

        private void FPlcAddressEditor_Load(
            object sender, 
            EventArgs e
            )
        {
            string tagName = string.Empty;
            // --
            int db = 0;
            string dataType = string.Empty;
            string subfixAddress = string.Empty;
            int address = 0;

            try
            {
                // --

                if (m_fIObject.fObjectType == FObjectType.OpcEventItem)
                {
                    // --
                    tagName = ((FOpcEventItem)m_fIObject).itemName;
                }
                else if (m_fIObject.fObjectType == FObjectType.OpcItem)
                {
                    // --
                    tagName = ((FOpcItem)m_fIObject).itemName;
                }

                // --
                FCommon.getSimensAddress(tagName, out db, out dataType, out address, out subfixAddress);

                // --
                
                txtDataBlock.Text = db.ToString();
                lblDataType.Text = "." + dataType;

                // --
                txtOld.Text = address.ToString();

                // --
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