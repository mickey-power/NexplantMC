/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropGeneralCodeData.cs
--  Creator         : mj.kim
--  Create Date     : 2012.04.05
--  Description     : FAMate Admin Manager General Code Data Property Source Object Class 
--  History         : Created by mj.kim at 2012.04.05
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.AdminManager
{
    public class FPropGeneralCodeData : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryKey = "[02] Key";
        private const string CategoryData = "[03] Data";

        // --

        private bool m_disposed = false;
        // --
        private bool m_tranEnabled = false;
        // --
        private string m_generalCodeTable = string.Empty;
        private string[] m_keyList = null;
        private string[] m_dataList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropGeneralCodeData(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FGeneralCodeColumn[] tableKeyList,
            FGeneralCodeColumn[] tableDataList,
            DataTable dt,
            bool tranEnabled
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_tranEnabled = tranEnabled;
            // --
            init(tableKeyList, tableDataList, dt);   
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropGeneralCodeData(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid, 
            string generalCodeTable,
            FGeneralCodeColumn[] tableKeyList,
            FGeneralCodeColumn[] tableDataList,
            bool tranEnabled
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_tranEnabled = tranEnabled;
            // --
            m_generalCodeTable = generalCodeTable;

            // --

            init(tableKeyList, tableDataList, null);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropGeneralCodeData(
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
        public string GeneralCodeTable
        {
            get
            {
                try
                {
                    return m_generalCodeTable;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Key

        [Category(CategoryKey)]
        public string Key_1
        {
            get
            {
                try
                {
                    return m_keyList[0];
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
                    m_keyList[0] = value;
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

        [Category(CategoryKey)]
        public string Key_2
        {
            get
            {
                try
                {
                    return m_keyList[1];
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
                    m_keyList[1] = value;
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

        #region Data

        [Category(CategoryData)]
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

        [Category(CategoryData)]
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

        [Category(CategoryData)]
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

        [Category(CategoryData)]
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

        [Category(CategoryData)]
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

        [Category(CategoryData)]
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

        [Category(CategoryData)]
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

        [Category(CategoryData)]
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

        [Category(CategoryData)]
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

        [Category(CategoryData)]
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
            FGeneralCodeColumn[] tableKeyList,
            FGeneralCodeColumn[] tableDataList,
            DataTable dt
            )
        {
            int index = 0;

            try
            {
                m_keyList = new string[tableKeyList.Length];
                for (int i = 0; i < tableKeyList.Length; i++)
                {
                    index = i + 1;
                    base.fTypeDescriptor.properties["Key_" + index].attributes.replace(new DisplayNameAttribute(tableKeyList[i].prt));
                    base.fTypeDescriptor.properties["Key_" + index].attributes.replace(new BrowsableAttribute(
                        tableKeyList[i].prt != string.Empty ? true : false
                        ));
                    m_keyList[i] = string.Empty;
                }

                m_dataList = new string[tableDataList.Length];
                for (int i = 0; i < tableDataList.Length; i++)
                {
                    index = i + 1;
                    base.fTypeDescriptor.properties["Data_" + index].attributes.replace(new DisplayNameAttribute(tableDataList[i].prt));
                    base.fTypeDescriptor.properties["Data_" + index].attributes.replace(new BrowsableAttribute(
                        tableDataList[i].prt != string.Empty ? true : false
                        ));
                    m_dataList[i] = string.Empty;
                }

                // --

                if (dt != null)
                {
                    index = 0;
                    m_generalCodeTable = dt.Rows[0][index++].ToString();
                    m_keyList[0] = dt.Rows[0][index++].ToString();
                    m_keyList[1] = dt.Rows[0][index++].ToString();
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

                // --

                base.fTypeDescriptor.properties["GeneralCodeTable"].attributes.replace(new DisplayNameAttribute("Table"));
                base.fTypeDescriptor.properties["GeneralCodeTable"].attributes.replace(new DefaultValueAttribute(m_generalCodeTable));
                // --
                base.fTypeDescriptor.properties["Key_1"].attributes.replace(new DefaultValueAttribute(m_keyList[0]));
                base.fTypeDescriptor.properties["Key_2"].attributes.replace(new DefaultValueAttribute(m_keyList[1]));
                base.fTypeDescriptor.properties["Data_1"].attributes.replace(new DefaultValueAttribute(m_dataList[0]));
                base.fTypeDescriptor.properties["Data_2"].attributes.replace(new DefaultValueAttribute(m_dataList[1]));
                base.fTypeDescriptor.properties["Data_3"].attributes.replace(new DefaultValueAttribute(m_dataList[2]));
                base.fTypeDescriptor.properties["Data_4"].attributes.replace(new DefaultValueAttribute(m_dataList[3]));
                base.fTypeDescriptor.properties["Data_5"].attributes.replace(new DefaultValueAttribute(m_dataList[4]));
                base.fTypeDescriptor.properties["Data_6"].attributes.replace(new DefaultValueAttribute(m_dataList[5]));
                base.fTypeDescriptor.properties["Data_7"].attributes.replace(new DefaultValueAttribute(m_dataList[6]));
                base.fTypeDescriptor.properties["Data_8"].attributes.replace(new DefaultValueAttribute(m_dataList[7]));
                base.fTypeDescriptor.properties["Data_9"].attributes.replace(new DefaultValueAttribute(m_dataList[8]));
                base.fTypeDescriptor.properties["Data_10"].attributes.replace(new DefaultValueAttribute(m_dataList[9]));

                // --

                // ***
                // 2014.09.10 by spike.lee
                // 데이터 키 정의
                // ***
                base.fTypeDescriptor.properties["GeneralCodeTable"].attributes.replace(new ParenthesizePropertyNameAttribute(true));
                base.fTypeDescriptor.properties["Key_1"].attributes.replace(new ParenthesizePropertyNameAttribute(true));
                base.fTypeDescriptor.properties["Key_2"].attributes.replace(new ParenthesizePropertyNameAttribute(true));

                // --

                if (!m_tranEnabled)
                {
                    base.fTypeDescriptor.properties["GeneralCodeTable"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["GeneralCodeTable"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["Key_1"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Key_2"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Data_1"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Data_2"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Data_3"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Data_4"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Data_5"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Data_6"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Data_7"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Data_8"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Data_9"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Data_10"].attributes.replace(new ReadOnlyAttribute(true));
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

    }   // Class end
}   // Namespace end
