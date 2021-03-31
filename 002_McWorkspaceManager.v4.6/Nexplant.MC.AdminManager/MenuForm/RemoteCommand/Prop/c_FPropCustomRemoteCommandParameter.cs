/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropCustomRemoteCommandParameter.cs
--  Creator         : iskim
--  Create Date     : 2013.06.17
--  Description     : FAMate Admin Manager Custom Remote Command Parameter Property Source Object Class 
--  History         : Created by iskim at 2013.06.17
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using System.Data;
using Infragistics.Win.UltraWinDataSource;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public class FPropCustomRemoteCommandParameter : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";

        // --

        private bool m_disposed = false;
        // --
        private string[] m_dataList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropCustomRemoteCommandParameter(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            DataTable dt
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            init(dt);   
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropCustomRemoteCommandParameter(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid
            )
            : this(fAdmCore, fPropGrid, null)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropCustomRemoteCommandParameter(
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
        public string Data_1
        {
            get
            {
                try
                {
                    return m_dataList[0]; 
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
                    m_dataList[0] = value;
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

        [Category(CategoryGeneral)]
        public string Data_2
        {
            get
            {
                try
                {
                    return m_dataList[1];
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
                    m_dataList[1] = value;
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

        [Category(CategoryGeneral)]
        public string Data_3
        {
            get
            {
                try
                {
                    return m_dataList[2];
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
                    m_dataList[2] = value;
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

        [Category(CategoryGeneral)]
        public string Data_4
        {
            get
            {
                try
                {
                    return m_dataList[3];
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
                    m_dataList[3] = value;
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

        [Category(CategoryGeneral)]
        public string Data_5
        {
            get
            {
                try
                {
                    return m_dataList[4];
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
                    m_dataList[4] = value;
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

        [Category(CategoryGeneral)]
        public string Data_6
        {
            get
            {
                try
                {
                    return m_dataList[5];
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
                    m_dataList[5] = value;
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

        [Category(CategoryGeneral)]
        public string Data_7
        {
            get
            {
                try
                {
                    return m_dataList[6];
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
                    m_dataList[6] = value;
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

        [Category(CategoryGeneral)]
        public string Data_8
        {
            get
            {
                try
                {
                    return m_dataList[7];
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
                    m_dataList[7] = value;
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

        [Category(CategoryGeneral)]
        public string Data_9
        {
            get
            {
                try
                {
                    return m_dataList[8];
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
                    m_dataList[8] = value;
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

        [Category(CategoryGeneral)]
        public string Data_10
        {
            get
            {
                try
                {
                    return m_dataList[9];
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
                    m_dataList[9] = value;
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
            DataTable dt
            )
        {
            int index = 0;

            try
            {
                m_dataList = new string[10];

                // --

                if (dt != null)
                {
                    index = 0 ;
                    m_dataList[0] = dt.Rows[0][index++].ToString();
                    m_dataList[1] = dt.Rows[0][index++].ToString();
                    m_dataList[2] = dt.Rows[0][index++].ToString();
                    m_dataList[3] = dt.Rows[0][index++].ToString();
                    m_dataList[4] = dt.Rows[0][index++].ToString();
                    m_dataList[5] = dt.Rows[0][index++].ToString();
                    m_dataList[6] = dt.Rows[0][index++].ToString();
                    m_dataList[7] = dt.Rows[0][index++].ToString();
                    m_dataList[8] = dt.Rows[0][index++].ToString();
                    m_dataList[9] = dt.Rows[0][index++].ToString();
                }

                for (int i = 0; i < m_dataList.Length; i++)
                {
                    index = i + 1;
                    base.fTypeDescriptor.properties["Data_" + index].attributes.replace(new DisplayNameAttribute(m_dataList[i]));
                    base.fTypeDescriptor.properties["Data_" + index].attributes.replace(new BrowsableAttribute(
                        m_dataList[i] != string.Empty ? true : false
                        ));
                    m_dataList[i] = string.Empty;
                }

                // --

                base.fTypeDescriptor.properties["Data_1"].attributes.replace(new DefaultValueAttribute(string.Empty));
                base.fTypeDescriptor.properties["Data_2"].attributes.replace(new DefaultValueAttribute(string.Empty));
                base.fTypeDescriptor.properties["Data_3"].attributes.replace(new DefaultValueAttribute(string.Empty));
                base.fTypeDescriptor.properties["Data_4"].attributes.replace(new DefaultValueAttribute(string.Empty));
                base.fTypeDescriptor.properties["Data_5"].attributes.replace(new DefaultValueAttribute(string.Empty));
                base.fTypeDescriptor.properties["Data_6"].attributes.replace(new DefaultValueAttribute(string.Empty));
                base.fTypeDescriptor.properties["Data_7"].attributes.replace(new DefaultValueAttribute(string.Empty));
                base.fTypeDescriptor.properties["Data_8"].attributes.replace(new DefaultValueAttribute(string.Empty));
                base.fTypeDescriptor.properties["Data_9"].attributes.replace(new DefaultValueAttribute(string.Empty));
                base.fTypeDescriptor.properties["Data_10"].attributes.replace(new DefaultValueAttribute(string.Empty));
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
