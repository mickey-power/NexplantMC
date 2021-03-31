/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropParameter.cs
--  Creator         : mj.kim
--  Create Date     : 2011.11.22
--  Description     : FAMate SQL Manager Parameter Property Source Object Class 
--  History         : Created by mj.kim at 2011.11.22
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
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.SqlManager
{
    public class FPropParameter : FDynPropCusBase<FSqmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------
        
        private const string CategoryGeneral = "[01] General";

        // --

        private bool m_disposed = false;   
        // --        
        private FSqlParameter m_source = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropParameter(
            FSqmCore fSqmCore,
            FDynPropGrid fPropGrid,
            FSqlParameter source
            )
            : base(fSqmCore, fSqmCore.fUIWizard, fPropGrid)
        {            
            m_source = source;
            // --
            init();   
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropParameter(
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
        public string Parameter
        {
            get
            {
                try
                {
                    return m_source.parameter;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        public bool Nullable
        {
            get
            {
                try
                {
                    return m_source.nullable;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    m_source.nullable = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        public FType Type
        {
            get
            {
                try
                {
                    return m_source.type;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
                }
                finally
                {

                }
                return FType.text;
            }

            set
            {
                try
                {
                    m_source.type = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

         [Category(CategoryGeneral)]
        public string Value
        {
            get
            {
                try
                {
                    return (string)m_source.value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
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
                    m_source.value = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
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
        public FSqlParameter source
        {
            get
            {
                try
                {
                    return m_source;
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
                base.fTypeDescriptor.properties["Parameter"].attributes.replace(new DisplayNameAttribute("Name"));
                base.fTypeDescriptor.properties["Nullable"].attributes.replace(new DisplayNameAttribute("Nullable"));
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Data Type"));
                base.fTypeDescriptor.properties["Value"].attributes.replace(new DisplayNameAttribute("Value"));

                // --

                base.fTypeDescriptor.properties["Parameter"].attributes.replace(new DefaultValueAttribute(m_source.parameter));
                base.fTypeDescriptor.properties["Nullable"].attributes.replace(new DefaultValueAttribute(m_source.nullable));
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_source.type));
                base.fTypeDescriptor.properties["Value"].attributes.replace(new DefaultValueAttribute(m_source.value));
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
