/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropVfm.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.03
--  Description     : FAMate SECS Modeler Value Formula Property Source Object Class 
--  History         : Created by spike.lee at 2011.03.03
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
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinDataSource;

namespace Nexplant.MC.SecsModeler
{
    public class FPropBmj : FDynPropCusBase<FSsmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryParameter = "[02] Parameter";

        // --

        private bool m_disposed = false;
        // --
        private FBatchModifierJob m_batchModifierJob;
        private UltraDataRow m_dataRow = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropBmj(
            FSsmCore fSsmCore,
            FDynPropGrid fPropGrid,
            FBatchModifierJob fBatchModifierJob,
            UltraDataRow dataRow
            )
            : base(fSsmCore, fSsmCore.fUIWizard, fPropGrid)
        {
            m_batchModifierJob = fBatchModifierJob;
            m_dataRow = dataRow;
            // --
            init();   
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropBmj(
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
        public FBatchModifierType Type
        {
            get
            {
                try
                {
                    return m_batchModifierJob.fTargetObjectType;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FBatchModifierType.SecsItem;
            }

            set
            {
                try
                {
                    // --
                    m_batchModifierJob.fTargetObjectType = value;

                    // --
                    if (value == FBatchModifierType.SecsItem)
                    {                        
                        m_batchModifierJob.Target = FBatchModifierTarget.Format.ToString();
                    }

                    // --

                    replaceTarget();
                    setTargetType();
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

        #region Parameter

        [Category(CategoryParameter)]
        public FBatchModifierTarget Target
        {
            get
            {
                try
                {
                    return (FBatchModifierTarget)Enum.Parse(typeof(FBatchModifierTarget), m_batchModifierJob.Target);
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FBatchModifierTarget.Format;
            }

            set
            {
                try
                {
                    m_batchModifierJob.Target = value.ToString();
                    if (value == FBatchModifierTarget.Format)
                    {
                        m_batchModifierJob.Value = FFormat.Ascii.ToString();
                    }
                    else
                    {
                        m_batchModifierJob.Value = string.Empty;
                    }
                    // --
                    replaceTarget();
                    setTargetValue();
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
        
        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryParameter)]
        public FFormat Format
        {
            get
            {
                try
                {
                    return (FFormat)Enum.Parse(typeof(FFormat), m_batchModifierJob.Value);
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FFormat.Ascii;
            }

            set
            {
                try
                {
                    m_batchModifierJob.Value = value.ToString();
                    replaceTarget();
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
        
        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryParameter)]
        public string Value
        {
            get
            {
                try
                {
                    return m_batchModifierJob.Value;
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
                    m_batchModifierJob.Value = value;
                    replaceTarget();
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
        public FBatchModifierJob fBatchModifierJob
        {
            get
            {
                try
                {
                    return m_batchModifierJob;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return new FBatchModifierJob();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            FBatchModifierTarget mTarget = FBatchModifierTarget.Format;
            FFormat fFormat = FFormat.Ascii;
            try
            {
                // ***
                // Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Type"));
                base.fTypeDescriptor.properties["Target"].attributes.replace(new DisplayNameAttribute("Target"));
                base.fTypeDescriptor.properties["Format"].attributes.replace(new DisplayNameAttribute("Format"));
                base.fTypeDescriptor.properties["Value"].attributes.replace(new DisplayNameAttribute("Value"));
                
                // --

                // ***
                // Type Default Value Attribute Set
                // ***
                mTarget = (FBatchModifierTarget)Enum.Parse(typeof(FBatchModifierTarget), m_batchModifierJob.Target);
                // --
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_batchModifierJob.fTargetObjectType));
                base.fTypeDescriptor.properties["Target"].attributes.replace(new DefaultValueAttribute(mTarget));
                // --

                if (mTarget == FBatchModifierTarget.Format)
                {
                    if (!Enum.TryParse<FFormat>(m_batchModifierJob.Value, out fFormat))
                    {
                        fFormat = FFormat.Ascii;
                    }
                    // --
                    base.fTypeDescriptor.properties["Format"].attributes.replace(new DefaultValueAttribute(fFormat));
                }
                else
                {
                    base.fTypeDescriptor.properties["Value"].attributes.replace(new DefaultValueAttribute(m_batchModifierJob.Value));
                }

                // --

                setTargetType();
                setTargetValue();
                // --
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

        //------------------------------------------------------------------------------------------------------------------------

        private void setTargetType(
            )
        {
            try
            {
                // ***
                // Parameter Browsable All Disable
                // ***
                base.fTypeDescriptor.properties["Target"].attributes.replace(new BrowsableAttribute(false));

                // --

                if (m_batchModifierJob.fTargetObjectType == FBatchModifierType.SecsItem)
                {
                    base.fTypeDescriptor.properties["Target"].attributes.replace(new BrowsableAttribute(true));
                }  

                // --

                this.fPropGrid.Refresh();
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

        private void setTargetValue(
            )
        {
            try
            {
                // ***
                // Parameter Browsable All Disable
                // ***
                base.fTypeDescriptor.properties["Format"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["Value"].attributes.replace(new BrowsableAttribute(false));

                // --

                if (Target == FBatchModifierTarget.Format)
                {
                    base.fTypeDescriptor.properties["Format"].attributes.replace(new BrowsableAttribute(true));
                }
                else if (Target == FBatchModifierTarget.Value)
                {
                    base.fTypeDescriptor.properties["Value"].attributes.replace(new BrowsableAttribute(true));
                }

                // --

                this.fPropGrid.Refresh();
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

        private void replaceTarget(
            )
        {
            try
            {                
                // --
                m_dataRow.Tag = m_batchModifierJob;
                m_dataRow.SetCellValue("Type", m_batchModifierJob.fTargetObjectType.ToString());
                m_dataRow.SetCellValue("Target", m_batchModifierJob.Target);
                m_dataRow.SetCellValue("Value", m_batchModifierJob.Value);                
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
