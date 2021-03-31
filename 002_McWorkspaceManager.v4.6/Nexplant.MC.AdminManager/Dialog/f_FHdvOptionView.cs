using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.AdminManager
{
    public partial class FHdvOptionView : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {
        private bool m_disposed = false;
        // --
        private bool m_readOnly = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private FPropHdo m_fPropHdo = null;
        private string m_hdvOption = null;

        #region Class Construction and Destruction

        public FHdvOptionView()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHdvOptionView(
            FAdmCore fAdmCore,
            string sHdvOption
            )
            : this()
        {
            m_fAdmCore = fAdmCore;
            m_hdvOption = sHdvOption;
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHdvOptionView(
            FAdmCore fAdmCore,
            string sHdvOption,
            bool readOnly
            )
            : this(fAdmCore, sHdvOption)
        {
            m_readOnly = readOnly;
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
            }
            m_disposed = true;
        }

        #endregion
        
        //------------------------------------------------------------------------------------------------------------------------

        #region FHostD Device Option Form Event Handler

        private void FHdvOptionView_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                
                m_fPropHdo = new FPropHdo(m_fAdmCore, pgdProp, FCommon.ConvertFileEapHostOptionStringtoXml(m_hdvOption), m_readOnly);
                
                
                pgdProp.selectedObject = m_fPropHdo;
                // --
                if (m_readOnly)
                {
                    btnOk.Visible = false;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        #endregion
    }
}
