/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropPrc.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.10
--  Description     : FAMate OPC Modeler Precondition Properties Source Object Class 
--  History         : Created by spike.lee at 2011.02.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinDataSource;

namespace Nexplant.MC.OpcModeler
{
    public class FPropPrc : FDynPropCusBase<FOpmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";        

        // --

        private bool m_disposed = false;
        // --
        private FIPrecondition m_fPrecondition = null;
        private string m_value = string.Empty;
        private UltraDataRow m_dataRow = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropPrc(
            FOpmCore fOpmCore,
            FDynPropGrid fPropGrid,
            FIPrecondition fPrecondition,
            string value,
            UltraDataRow dataRow
            )
            : base(fOpmCore, fOpmCore.fUIWizard, fPropGrid)
        {
            m_fPrecondition = fPrecondition;
            m_value = value;
            m_dataRow = dataRow;
            // --
            init();   
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropPrc(
           )
        {
            myDispose(false);
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
                    term();     
                    // --
                    m_fPrecondition = null;
                    m_dataRow = null;
                }                

                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region General

        [Category(CategoryGeneral)]
        public string PreconditionValue
        {
            get
            {
                try
                {
                    return m_value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
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
                    m_value = m_fPrecondition.replaceStringValue(m_dataRow.Index, value);
                    // --
                    m_dataRow.Tag = m_value;
                    m_dataRow.SetCellValue("Precondition Value", m_value);                
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        [Browsable(false)]
        public FIPrecondition fPrecondition
        {
            get
            {
                try
                {
                    return m_fPrecondition;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                base.fTypeDescriptor.properties["PreconditionValue"].attributes.replace(new DisplayNameAttribute("Precondition Value"));

                // --

                base.fTypeDescriptor.properties["PreconditionValue"].attributes.replace(new DefaultValueAttribute(m_value));               
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

    }   // Class end
}   // Namespace end
