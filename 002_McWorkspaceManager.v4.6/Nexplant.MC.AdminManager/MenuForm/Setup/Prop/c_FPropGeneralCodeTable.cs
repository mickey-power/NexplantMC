/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropGeneralCodeTable.cs
--  Creator         : mj.kim
--  Create Date     : 2012.03.12
--  Description     : FAMate Admin Manager General Code Table Property Source Object Class 
--  History         : Created by mj.kim at 2012.03.12
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
    public class FPropGeneralCodeTable : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategorySystemTable = "[02] System Table";
        private const string CategoryKey1    = "[03] Key 1";
        private const string CategoryKey2    = "[04] Key 2";
        private const string CategoryData1   = "[05] Data 1";
        private const string CategoryData2   = "[06] Data 2";
        private const string CategoryData3   = "[07] Data 3";
        private const string CategoryData4   = "[08] Data 4";
        private const string CategoryData5   = "[09] Data 5";
        private const string CategoryData6   = "[10] Data 6";
        private const string CategoryData7   = "[11] Data 7";
        private const string CategoryData8   = "[12] Data 8";
        private const string CategoryData9   = "[13] Data 9";
        private const string CategoryData10  = "[14] Data 10";

        // --

        private bool m_disposed = false;
        // --
        private bool m_tranEanbled = false;
        // --
        private string m_table = string.Empty;
        private string m_description = string.Empty;
        private FYesNo m_systemTable = FYesNo.No;
        private FGeneralCodeColumn[] m_keyList = null;
        private FGeneralCodeColumn[] m_dataList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropGeneralCodeTable(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            DataTable dt,
            bool tranEnabled
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_tranEanbled = tranEnabled;
            // --
            init(dt);   
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropGeneralCodeTable(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            bool tranEnabled
            )
            : this(fAdmCore, fPropGrid, null, tranEnabled)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropGeneralCodeTable(
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
        public string Table
        {
            get
            {
                try
                {
                    return m_table;
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
                    m_table = value;
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
        public string Description
        {
            get
            {
                try
                {
                    return m_description;
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
                   m_description = value;
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

        #region System Table

        [Category(CategorySystemTable)]
        [Browsable(false)]
        public FYesNo SystemTable
        {
            get
            {
                try
                {
                    return m_systemTable;
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
                    m_systemTable = value;
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

        #region Key

        [Category(CategoryKey1)]
        public string Key_1_Prt
        {
            get
            {
                try
                {
                    return m_keyList[0].prt;
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
                    m_keyList[0].prt = value;
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

        [Category(CategoryKey1)]
        public FGeneralCodeFormat Key_1_Fmt
        {
            get
            {
                try
                {
                    return m_keyList[0].fmt;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FGeneralCodeFormat.Ascii;
            }

            set
            {
                try
                {
                    if (value == FGeneralCodeFormat.Ascii)
                    {
                        base.fTypeDescriptor.properties["Key_1_Size"].attributes.replace(new BrowsableAttribute(true));
                        m_keyList[0].size = 30;
                    }
                    else if (value == FGeneralCodeFormat.Number)
                    {
                        base.fTypeDescriptor.properties["Key_1_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_keyList[0].size = 10;
                    }
                    else if (value == FGeneralCodeFormat.Double)
                    {
                        base.fTypeDescriptor.properties["Key_1_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_keyList[0].size = 39;
                    }

                    // --

                    m_keyList[0].fmt = value;
                    base.fPropGrid.Refresh();
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

        [Category(CategoryKey1)]
        public int Key_1_Size
        {
            get
            {
                try
                {
                    return m_keyList[0].size;
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
                    m_keyList[0].size = value;
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

        [Category(CategoryKey2)]
        public string Key_2_Prt
        {
            get
            {
                try
                {
                    return m_keyList[1].prt;
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
                    m_keyList[1].prt = value;
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

        [Category(CategoryKey2)]
        public FGeneralCodeFormat Key_2_Fmt
        {
            get
            {
                try
                {
                    return m_keyList[1].fmt;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FGeneralCodeFormat.Ascii;
            }

            set
            {
                try
                {
                    if (value == FGeneralCodeFormat.Ascii)
                    {
                        base.fTypeDescriptor.properties["Key_2_Size"].attributes.replace(new BrowsableAttribute(true));
                        m_keyList[1].size = 30;
                    }
                    else if (value == FGeneralCodeFormat.Number)
                    {
                        base.fTypeDescriptor.properties["Key_2_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_keyList[1].size = 10;
                    }
                    else if (value == FGeneralCodeFormat.Double)
                    {
                        base.fTypeDescriptor.properties["Key_2_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_keyList[1].size = 39;
                    }

                    // --

                    m_keyList[1].fmt = value;
                    base.fPropGrid.Refresh();
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

        [Category(CategoryKey2)]
        public int Key_2_Size
        {
            get
            {
                try
                {
                    return m_keyList[1].size;
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
                    m_keyList[1].size = value;
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

        [Category(CategoryData1)]
        public string Data_1_Prt
        {
            get
            {
                try
                {
                    return m_dataList[0].prt;
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
                    m_dataList[0].prt = value;
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

        [Category(CategoryData1)]
        public FGeneralCodeFormat Data_1_Fmt
        {
            get
            {
                try
                {
                    return m_dataList[0].fmt;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FGeneralCodeFormat.Ascii;
            }

            set
            {
                try
                {
                    if (value == FGeneralCodeFormat.Ascii)
                    {
                        base.fTypeDescriptor.properties["Data_1_Size"].attributes.replace(new BrowsableAttribute(true));
                        m_dataList[0].size = 50;
                    }
                    else if (value == FGeneralCodeFormat.Number)
                    {
                        base.fTypeDescriptor.properties["Data_1_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_dataList[0].size = 10;
                    }
                    else if (value == FGeneralCodeFormat.Double)
                    {
                        base.fTypeDescriptor.properties["Data_1_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_dataList[0].size = 39;
                    }

                    // --

                    m_dataList[0].fmt = value;
                    base.fPropGrid.Refresh();
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

        [Category(CategoryData1)]
        public int Data_1_Size
        {
            get
            {
                try
                {
                    return m_dataList[0].size;
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
                    m_dataList[0].size = value;
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

        [Category(CategoryData2)]
        public string Data_2_Prt
        {
            get
            {
                try
                {
                    return m_dataList[1].prt;
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
                    m_dataList[1].prt = value;
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

        [Category(CategoryData2)]
        public FGeneralCodeFormat Data_2_Fmt
        {
            get
            {
                try
                {
                    return m_dataList[1].fmt;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FGeneralCodeFormat.Ascii;
            }

            set
            {
                try
                {
                    if (value == FGeneralCodeFormat.Ascii)
                    {
                        base.fTypeDescriptor.properties["Data_2_Size"].attributes.replace(new BrowsableAttribute(true));
                        m_dataList[1].size = 50;
                    }
                    else if (value == FGeneralCodeFormat.Number)
                    {
                        base.fTypeDescriptor.properties["Data_2_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_dataList[1].size = 10;
                    }
                    else if (value == FGeneralCodeFormat.Double)
                    {
                        base.fTypeDescriptor.properties["Data_2_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_dataList[1].size = 39;
                    }

                    // --

                    m_dataList[1].fmt = value;
                    base.fPropGrid.Refresh();
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

        [Category(CategoryData2)]
        public int Data_2_Size
        {
            get
            {
                try
                {
                    return m_dataList[1].size;
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
                    m_dataList[1].size = value;
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

        [Category(CategoryData3)]
        public string Data_3_Prt
        {
            get
            {
                try
                {
                    return m_dataList[2].prt;
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
                    m_dataList[2].prt = value;
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

        [Category(CategoryData3)]
        public FGeneralCodeFormat Data_3_Fmt
        {
            get
            {
                try
                {
                    return m_dataList[2].fmt;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FGeneralCodeFormat.Ascii;
            }

            set
            {
                try
                {
                    if (value == FGeneralCodeFormat.Ascii)
                    {
                        base.fTypeDescriptor.properties["Data_3_Size"].attributes.replace(new BrowsableAttribute(true));
                        m_dataList[2].size = 50;
                    }
                    else if (value == FGeneralCodeFormat.Number)
                    {
                        base.fTypeDescriptor.properties["Data_3_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_dataList[2].size = 10;
                    }
                    else if (value == FGeneralCodeFormat.Double)
                    {
                        base.fTypeDescriptor.properties["Data_3_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_dataList[2].size = 39;
                    }

                    // --

                    m_dataList[2].fmt = value;
                    base.fPropGrid.Refresh();
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

        [Category(CategoryData3)]
        public int Data_3_Size
        {
            get
            {
                try
                {
                    return m_dataList[2].size;
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
                    m_dataList[2].size = value;
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

        [Category(CategoryData4)]
        public string Data_4_Prt
        {
            get
            {
                try
                {
                    return m_dataList[3].prt;
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
                    m_dataList[3].prt = value;
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

        [Category(CategoryData4)]
        public FGeneralCodeFormat Data_4_Fmt
        {
            get
            {
                try
                {
                    return m_dataList[3].fmt;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FGeneralCodeFormat.Ascii;
            }

            set
            {
                try
                {
                    if (value == FGeneralCodeFormat.Ascii)
                    {
                        base.fTypeDescriptor.properties["Data_4_Size"].attributes.replace(new BrowsableAttribute(true));
                        m_dataList[1].size = 50;
                    }
                    else if (value == FGeneralCodeFormat.Number)
                    {
                        base.fTypeDescriptor.properties["Data_4_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_dataList[1].size = 10;
                    }
                    else if (value == FGeneralCodeFormat.Double)
                    {
                        base.fTypeDescriptor.properties["Data_4_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_dataList[1].size = 39;
                    }

                    // --

                    m_dataList[3].fmt = value;
                    base.fPropGrid.Refresh();
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

        [Category(CategoryData4)]
        public int Data_4_Size
        {
            get
            {
                try
                {
                    return m_dataList[3].size;
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
                    m_dataList[3].size = value;
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

        [Category(CategoryData5)]
        public string Data_5_Prt
        {
            get
            {
                try
                {
                    return m_dataList[4].prt;
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
                    m_dataList[4].prt = value;
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

        [Category(CategoryData5)]
        public FGeneralCodeFormat Data_5_Fmt
        {
            get
            {
                try
                {
                    return m_dataList[4].fmt;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FGeneralCodeFormat.Ascii;
            }

            set
            {
                try
                {
                    if (value == FGeneralCodeFormat.Ascii)
                    {
                        base.fTypeDescriptor.properties["Data_5_Size"].attributes.replace(new BrowsableAttribute(true));
                        m_dataList[4].size = 50;
                    }
                    else if (value == FGeneralCodeFormat.Number)
                    {
                        base.fTypeDescriptor.properties["Data_5_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_dataList[4].size = 10;
                    }
                    else if (value == FGeneralCodeFormat.Double)
                    {
                        base.fTypeDescriptor.properties["Data_5_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_dataList[4].size = 39;
                    }

                    // --

                    m_dataList[4].fmt = value;
                    base.fPropGrid.Refresh();
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

        [Category(CategoryData5)]
        public int Data_5_Size
        {
            get
            {
                try
                {
                    return m_dataList[4].size;
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
                    m_dataList[4].size = value;
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

        [Category(CategoryData6)]
        public string Data_6_Prt
        {
            get
            {
                try
                {
                    return m_dataList[5].prt;
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
                    m_dataList[5].prt = value;
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

        [Category(CategoryData6)]
        public FGeneralCodeFormat Data_6_Fmt
        {
            get
            {
                try
                {
                    return m_dataList[5].fmt;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FGeneralCodeFormat.Ascii;
            }

            set
            {
                try
                {
                    if (value == FGeneralCodeFormat.Ascii)
                    {
                        base.fTypeDescriptor.properties["Data_6_Size"].attributes.replace(new BrowsableAttribute(true));
                        m_dataList[5].size = 50;
                    }
                    else if (value == FGeneralCodeFormat.Number)
                    {
                        base.fTypeDescriptor.properties["Data_6_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_dataList[5].size = 10;
                    }
                    else if (value == FGeneralCodeFormat.Double)
                    {
                        base.fTypeDescriptor.properties["Data_6_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_dataList[5].size = 39;
                    }

                    // --

                    m_dataList[5].fmt = value;
                    base.fPropGrid.Refresh();
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

        [Category(CategoryData6)]
        public int Data_6_Size
        {
            get
            {
                try
                {
                    return m_dataList[5].size;
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
                    m_dataList[5].size = value;
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

        [Category(CategoryData7)]
        public string Data_7_Prt
        {
            get
            {
                try
                {
                    return m_dataList[6].prt;
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
                    m_dataList[6].prt = value;
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

        [Category(CategoryData7)]
        public FGeneralCodeFormat Data_7_Fmt
        {
            get
            {
                try
                {
                    return m_dataList[6].fmt;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FGeneralCodeFormat.Ascii;
            }

            set
            {
                try
                {
                    if (value == FGeneralCodeFormat.Ascii)
                    {
                        base.fTypeDescriptor.properties["Data_7_Size"].attributes.replace(new BrowsableAttribute(true));
                        m_dataList[6].size = 50;
                    }
                    else if (value == FGeneralCodeFormat.Number)
                    {
                        base.fTypeDescriptor.properties["Data_7_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_dataList[6].size = 10;
                    }
                    else if (value == FGeneralCodeFormat.Double)
                    {
                        base.fTypeDescriptor.properties["Data_7_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_dataList[6].size = 39;
                    }

                    // --

                    m_dataList[6].fmt = value;
                    base.fPropGrid.Refresh();
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

        [Category(CategoryData7)]
        public int Data_7_Size
        {
            get
            {
                try
                {
                    return m_dataList[6].size;
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
                    m_dataList[6].size = value;
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

        [Category(CategoryData8)]
        public string Data_8_Prt
        {
            get
            {
                try
                {
                    return m_dataList[7].prt;
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
                    m_dataList[7].prt = value;
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

        [Category(CategoryData8)]
        public FGeneralCodeFormat Data_8_Fmt
        {
            get
            {
                try
                {
                    return m_dataList[7].fmt;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FGeneralCodeFormat.Ascii;
            }

            set
            {
                try
                {
                    if (value == FGeneralCodeFormat.Ascii)
                    {
                        base.fTypeDescriptor.properties["Data_8_Size"].attributes.replace(new BrowsableAttribute(true));
                        m_dataList[7].size = 50;
                    }
                    else if (value == FGeneralCodeFormat.Number)
                    {
                        base.fTypeDescriptor.properties["Data_8_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_dataList[7].size = 10;
                    }
                    else if (value == FGeneralCodeFormat.Double)
                    {
                        base.fTypeDescriptor.properties["Data_8_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_dataList[7].size = 39;
                    }

                    // --

                    m_dataList[7].fmt = value;
                    base.fPropGrid.Refresh();
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

        [Category(CategoryData8)]
        public int Data_8_Size
        {
            get
            {
                try
                {
                    return m_dataList[7].size;
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
                    m_dataList[7].size = value;
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

        [Category(CategoryData9)]
        public string Data_9_Prt
        {
            get
            {
                try
                {
                    return m_dataList[8].prt;
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
                    m_dataList[8].prt = value;
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

        [Category(CategoryData9)]
        public FGeneralCodeFormat Data_9_Fmt
        {
            get
            {
                try
                {
                    return m_dataList[8].fmt;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FGeneralCodeFormat.Ascii;
            }

            set
            {
                try
                {
                    if (value == FGeneralCodeFormat.Ascii)
                    {
                        base.fTypeDescriptor.properties["Data_9_Size"].attributes.replace(new BrowsableAttribute(true));
                        m_dataList[8].size = 50;
                    }
                    else if (value == FGeneralCodeFormat.Number)
                    {
                        base.fTypeDescriptor.properties["Data_9_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_dataList[8].size = 10;
                    }
                    else if (value == FGeneralCodeFormat.Double)
                    {
                        base.fTypeDescriptor.properties["Data_9_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_dataList[8].size = 39;
                    }

                    // --

                    m_dataList[8].fmt = value;
                    base.fPropGrid.Refresh();
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

        [Category(CategoryData9)]
        public int Data_9_Size
        {
            get
            {
                try
                {
                    return m_dataList[8].size;
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
                    m_dataList[8].size = value;
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

        [Category(CategoryData10)]
        public string Data_10_Prt
        {
            get
            {
                try
                {
                    return m_dataList[9].prt;
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
                    m_dataList[9].prt = value;
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

        [Category(CategoryData10)]
        public FGeneralCodeFormat Data_10_Fmt
        {
            get
            {
                try
                {
                    return m_dataList[9].fmt;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FGeneralCodeFormat.Ascii;
            }

            set
            {
                try
                {
                    if (value == FGeneralCodeFormat.Ascii)
                    {
                        base.fTypeDescriptor.properties["Data_10_Size"].attributes.replace(new BrowsableAttribute(true));
                        m_dataList[9].size = 50;
                    }
                    else if (value == FGeneralCodeFormat.Number)
                    {
                        base.fTypeDescriptor.properties["Data_10_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_dataList[9].size = 10;
                    }
                    else if (value == FGeneralCodeFormat.Double)
                    {
                        base.fTypeDescriptor.properties["Data_10_Size"].attributes.replace(new BrowsableAttribute(false));
                        m_dataList[9].size = 39;
                    }

                    // --

                    m_dataList[9].fmt = value;
                    base.fPropGrid.Refresh();
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

        [Category(CategoryData10)]
        public int Data_10_Size
        {
            get
            {
                try
                {
                    return m_dataList[9].size;
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
                    m_dataList[9].size = value;
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
        public FGeneralCodeColumn[] GeneralCodeTableKey
        {
            get
            {
                try
                {
                    return m_keyList;
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

        //------------------------------------------------------------------------------------------------------------------------

        [Browsable(false)]
        public FGeneralCodeColumn[] GeneralCodeTableData
        {
            get
            {
                try
                {
                    return m_dataList;
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
            DataTable dt
            )
        {
            int index = 0;

            try
            {
                m_keyList = new FGeneralCodeColumn[2];
                for (int i = 0; i < m_keyList.Length; i++)
                {
                    m_keyList[i] = new FGeneralCodeColumn(string.Empty, FGeneralCodeFormat.Ascii.ToString(), "30");
                }

                m_dataList = new FGeneralCodeColumn[10];
                for (int i = 0; i < m_dataList.Length; i++)
                {
                    m_dataList[i] = new FGeneralCodeColumn(string.Empty, FGeneralCodeFormat.Ascii.ToString(), "50");
                }

                // --

                if (dt != null)
                {
                    index = 0;
                    m_table = dt.Rows[0][index++].ToString();
                    m_description = dt.Rows[0][index++].ToString();
                    m_systemTable = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][index++].ToString());
                    // --
                    for (int i = 0; i < m_keyList.Length; i++)
                    {
                        m_keyList[i].prt = dt.Rows[0][index++].ToString();
                        m_keyList[i].fmt = (FGeneralCodeFormat)Enum.Parse(typeof(FGeneralCodeFormat), dt.Rows[0][index++].ToString());
                        m_keyList[i].size = int.Parse(dt.Rows[0][index++].ToString());
                    }
                    // --
                    for (int i = 0; i < m_dataList.Length; i++)
                    {
                        m_dataList[i].prt = dt.Rows[0][index++].ToString();
                        m_dataList[i].fmt = (FGeneralCodeFormat)Enum.Parse(typeof(FGeneralCodeFormat), dt.Rows[0][index++].ToString());
                        m_dataList[i].size = int.Parse(dt.Rows[0][index++].ToString());
                    }
                }

                // --

                base.fTypeDescriptor.properties["Table"].attributes.replace(new DisplayNameAttribute("Table"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                base.fTypeDescriptor.properties["SystemTable"].attributes.replace(new DisplayNameAttribute("System Table"));
                // --
                for (int i = 0; i < m_keyList.Length; i++)
                {
                    index = i + 1;
                    base.fTypeDescriptor.properties["Key_" + index + "_Prt"].attributes.replace(new DisplayNameAttribute("Prompt"));
                    base.fTypeDescriptor.properties["Key_" + index + "_Fmt"].attributes.replace(new DisplayNameAttribute("Format"));
                    base.fTypeDescriptor.properties["Key_" + index + "_Size"].attributes.replace(new DisplayNameAttribute("Size"));
                }
                // --
                for (int i = 0; i < m_dataList.Length; i++)
                {
                    index = i + 1;
                    base.fTypeDescriptor.properties["Data_" + index + "_Prt"].attributes.replace(new DisplayNameAttribute("Prompt"));
                    base.fTypeDescriptor.properties["Data_" + index + "_Fmt"].attributes.replace(new DisplayNameAttribute("Format"));
                    base.fTypeDescriptor.properties["Data_" + index + "_Size"].attributes.replace(new DisplayNameAttribute("Size"));
                }

                // --

                // ***
                // 2014.09.10 by spike.lee
                // 데이터 키 정의
                // ***
                base.fTypeDescriptor.properties["Table"].attributes.replace(new ParenthesizePropertyNameAttribute(true));

                // --

                base.fTypeDescriptor.properties["Table"].attributes.replace(new DefaultValueAttribute(m_table));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_description));
                base.fTypeDescriptor.properties["SystemTable"].attributes.replace(new DefaultValueAttribute(m_systemTable));
                // --
                for (int i = 0; i < m_keyList.Length; i++)
                {
                    index = i + 1;
                    base.fTypeDescriptor.properties["Key_" + index + "_Prt"].attributes.replace(new DefaultValueAttribute(m_keyList[i].prt));
                    base.fTypeDescriptor.properties["Key_" + index + "_Fmt"].attributes.replace(new DefaultValueAttribute((FGeneralCodeFormat)m_keyList[i].fmt));
                    base.fTypeDescriptor.properties["Key_" + index + "_Size"].attributes.replace(new DefaultValueAttribute((int)m_keyList[i].size));
                    base.fTypeDescriptor.properties["Key_" + index + "_Size"].attributes.replace(new BrowsableAttribute(
                        (FGeneralCodeFormat)m_keyList[i].fmt == FGeneralCodeFormat.Ascii ? true : false
                        ));
                }
                // --
                for (int i = 0; i < m_dataList.Length; i++)
                {
                    index = i + 1;
                    base.fTypeDescriptor.properties["Data_" + index + "_Prt"].attributes.replace(new DefaultValueAttribute(m_dataList[i].prt));
                    base.fTypeDescriptor.properties["Data_" + index + "_Fmt"].attributes.replace(new DefaultValueAttribute((FGeneralCodeFormat)m_dataList[i].fmt));
                    base.fTypeDescriptor.properties["Data_" + index + "_Size"].attributes.replace(new DefaultValueAttribute((int)m_dataList[i].size));
                    base.fTypeDescriptor.properties["Data_" + index + "_Size"].attributes.replace(new BrowsableAttribute(
                        (FGeneralCodeFormat)m_dataList[i].fmt == FGeneralCodeFormat.Ascii ? true : false
                        ));
                }

                // --

                if (!m_tranEanbled)
                {
                    base.fTypeDescriptor.properties["Table"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Description"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["SystemTable"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    for (int i = 0; i < m_keyList.Length; i++)
                    {
                        index = i + 1;
                        base.fTypeDescriptor.properties["Key_" + index + "_Prt"].attributes.replace(new ReadOnlyAttribute(true));
                        base.fTypeDescriptor.properties["Key_" + index + "_Fmt"].attributes.replace(new ReadOnlyAttribute(true));
                        base.fTypeDescriptor.properties["Key_" + index + "_Size"].attributes.replace(new ReadOnlyAttribute(true));
                    }
                    // --
                    for (int i = 0; i < m_dataList.Length; i++)
                    {
                        index = i + 1;
                        base.fTypeDescriptor.properties["Data_" + index + "_Prt"].attributes.replace(new ReadOnlyAttribute(true));
                        base.fTypeDescriptor.properties["Data_" + index + "_Fmt"].attributes.replace(new ReadOnlyAttribute(true));
                        base.fTypeDescriptor.properties["Data_" + index + "_Size"].attributes.replace(new ReadOnlyAttribute(true));
                    }
                }

                // --

                if (this.mainObject.fOption.authority.allAuthority == FYesNo.Yes)
                {
                    base.fTypeDescriptor.properties["SystemTable"].attributes.replace(new BrowsableAttribute(true));
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
