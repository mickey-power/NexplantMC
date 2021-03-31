/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAdaGeneral.cs
--  Creator         : baehyun.seo
--  Create Date     : 2012.12.21
--  Description     : FAMate Admin Manager Admin Agent Option General Source Object Class 
--  History         : Created by baehyun.seo at 2012.12.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Design;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public class FPropAdaResourceCollection : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryResourceCollection = "[01] Resource Collection";

        // --

        private bool m_disposed = false;
        // --
        private FADAOption m_source = null;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropAdaResourceCollection(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FADAOption source
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_source = source;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropAdaResourceCollection(
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
                    m_source = null;
                }
            }
            m_disposed = true;

            // --

            base.myDispose(disposing);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Resource Collection

        [Category(CategoryResourceCollection)]
        public FYesNo ResourceCollectionEnabled
        {
            get
            {
                try
                {
                    return m_source.resourceCollectionEnabled;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FYesNo.No;
            }

            set
            {
                try
                {
                    m_source.resourceCollectionEnabled = value;
                    // --
                    setChangedResourceCollectionEnabled();
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

        [Category(CategoryResourceCollection)]
        public int ResourceCollectionCycleTime
        {
            get
            {
                try
                {
                    return m_source.resourceCollectionCycleTime;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return 0;
            }

            set
            {
                try
                {
                    m_source.resourceCollectionCycleTime = value;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                base.fTypeDescriptor.properties["ResourceCollectionEnabled"].attributes.replace(new DisplayNameAttribute("Enabled"));
                base.fTypeDescriptor.properties["ResourceCollectionCycleTime"].attributes.replace(new DisplayNameAttribute("Resource Collection Cycle Time (min)"));
                
                // --

                base.fTypeDescriptor.properties["ResourceCollectionEnabled"].attributes.replace(new DefaultValueAttribute(this.ResourceCollectionEnabled));
                base.fTypeDescriptor.properties["ResourceCollectionCycleTime"].attributes.replace(new DefaultValueAttribute(this.ResourceCollectionCycleTime));

                // -- 

                setChangedResourceCollectionEnabled();
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

        private void setChangedResourceCollectionEnabled(
            )
        {
            try
            {
                if (this.ResourceCollectionEnabled == FYesNo.Yes)
                {
                    base.fTypeDescriptor.properties["ResourceCollectionCycleTime"].attributes.replace(new BrowsableAttribute(true));
                }
                else
                {
                    base.fTypeDescriptor.properties["ResourceCollectionCycleTime"].attributes.replace(new BrowsableAttribute(false));
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
