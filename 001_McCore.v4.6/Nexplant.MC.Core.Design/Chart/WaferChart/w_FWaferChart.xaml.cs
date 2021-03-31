/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : w_FWaferChart.xaml
--  Creator         : byjeon
--  Create Date     : 2013.12.02
--  Description     : FAMate UI WaferChart Class
--  History         : Created by byjeon at 2013.12.02
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    /// <summary>
    /// w_WaferChart.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FWaferChart : UserControl, IDisposable
    {
        private bool m_disposed = false;
        // --
        private bool m_isUpdating = false;
        private FCellCollection m_fCells = null;
        private FFlagCollection m_fFlags = null;
        // -- 
        private DependencyProperty RowsProperty;
        private DependencyProperty ColumnsProperty;
        private DependencyProperty CellMarginProperty;
        private DependencyProperty WaferBorderProperty;
        private DependencyProperty WaferBorderThicknessProperty;
        private DependencyProperty LegendVisibilityProperty;
        private DependencyProperty TitleVisibilityProperty;
        private DependencyProperty TitleProperty;

        //------------------------------------------------------------------------------------------------------------------------
        
        #region Class Construction and Destruction

        public FWaferChart(
            )
        {
            InitializeComponent();
            // --
            registDependencyProperty();
            // --
            m_fFlags = new FFlagCollection(flagItems);
            m_fCells = new FCellCollection();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FWaferChart(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    if (m_fCells != null)
                    {
                        m_fCells.Dispose();
                        m_fCells = null;
                    }

                    if (m_fFlags != null)
                    {
                        m_fFlags.Dispose();
                        m_fFlags = null;
                    }
                }
            }

            m_disposed = true;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region IDisposable 멤버

        public void Dispose(
            )
        {
            myDispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties
        
        public FCellCollection fCells
        {
            get
            {
                try
                {
                    return m_fCells;
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

        public FFlagCollection fFlags
        {
            get
            {
                try
                {
                    return m_fFlags;
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

        #region Dependency Properties

        public int Rows
        {
            get
            {
                try
                {
                    return (int)GetValue(RowsProperty);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 10;
            }

            set
            {
                try
                {
                    SetValue(RowsProperty, value);
                    drawChart();
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int Columns
        {
            get
            {
                try
                {
                    return (int)GetValue(ColumnsProperty);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 10;
            }

            set
            {
                try
                {
                    SetValue(ColumnsProperty, value);
                    drawChart();
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public int CellMargin
        {
            get
            {
                try
                {
                    return (int)GetValue(CellMarginProperty);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 10;
            }

            set
            {
                try
                {
                    SetValue(CellMarginProperty, value);
                    //drawChart();
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public Color WaferBorder
        {
            get
            {
                try
                {
                    return (Color)GetValue(WaferBorderProperty);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return Colors.Silver;
            }

            set
            {
                try
                {
                    SetValue(WaferBorderProperty, value);
                    waferLayout.Stroke = new SolidColorBrush(WaferBorder);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int WaferBorderThickness
        {
            get
            {
                try
                {
                    return (int)GetValue(WaferBorderThicknessProperty);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 2;
            }

            set
            {
                try
                {
                    SetValue(WaferBorderThicknessProperty, value);
                    waferLayout.StrokeThickness = WaferBorderThickness;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool LegendVisibility
        {
            get
            {
                try
                {
                    return (bool)GetValue(LegendVisibilityProperty);

                    
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    SetValue(LegendVisibilityProperty, value);
                    legendGroupBox.Visibility = value ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool TitleVisibility
        {
            get
            {
                try
                {
                    return (bool)GetValue(TitleVisibilityProperty);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    SetValue(TitleVisibilityProperty, value);
                    tbTitle.Visibility = value ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string Title
        {
            get
            {
                try
                {
                    return (string)GetValue(TitleProperty);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    SetValue(TitleProperty, value);
                    tbTitle.Text = string.IsNullOrWhiteSpace(value) ? "<Untitled Chart>" : value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public void beginUpdate(
            )
        {
            try
            {
                m_isUpdating = true;
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

        public void endUpdate(
            )
        {
            try
            {
                m_isUpdating = false;
                drawChart();
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

        private void registDependencyProperty(
            )
        {
            try
            {
                RowsProperty = DependencyProperty.Register("Rows", typeof(int), typeof(FWaferChart), new PropertyMetadata(10, OnRowsPropertyChangedCallback));
                ColumnsProperty = DependencyProperty.Register("Columns", typeof(int), typeof(FWaferChart), new PropertyMetadata(10, OnColumnsPropertyChangedCallback));
                CellMarginProperty = DependencyProperty.Register("CellMargin", typeof(int), typeof(FWaferChart), new PropertyMetadata(0, OnCellMarginPropertyChangedCallback));
                // --
                WaferBorderProperty = DependencyProperty.Register("WaferBorder", typeof(Color), typeof(FWaferChart), new PropertyMetadata(Colors.Silver, OnWaferBorderPropertyChangedCallback));
                WaferBorderThicknessProperty = DependencyProperty.Register("WaferBorderThickness", typeof(int), typeof(FWaferChart), new PropertyMetadata(2, OnWaferBorderThicknessPropertyChangedCallback));
                // -- 
                LegendVisibilityProperty = DependencyProperty.Register("EnabledLegend", typeof(bool), typeof(FWaferChart), new PropertyMetadata(true, OnLegendVisibilityPropertyChangedCallback));
                // -- 
                TitleVisibilityProperty = DependencyProperty.Register("EnabledTitle", typeof(bool), typeof(FWaferChart), new PropertyMetadata(false, OnTitleVisibilityPropertyChangedCallback));
                TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(FWaferChart), new PropertyMetadata("<Untitled Chart>", OnTitlePropertyChangedCallback));
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

        public void drawChart(
            )
        {
            Rectangle rect;

            try
            {
                if (m_isUpdating)
                {
                    return;
                }

                cellLayout.Children.Clear();
                cellLayout.RowDefinitions.Clear();
                cellLayout.ColumnDefinitions.Clear();

                // ***
                // Add Rows
                // ***
                for (int i = 0; i < Rows; i++)
                {
                    cellLayout.RowDefinitions.Add(
                        new RowDefinition()
                        {
                            Height = new GridLength(1, GridUnitType.Star)
                        });
                }

                // ***
                // Add Columns
                // ***
                for (int i = 0; i < Columns; i++)
                {
                    cellLayout.ColumnDefinitions.Add(
                        new ColumnDefinition()
                        {
                            Width = new GridLength(1, GridUnitType.Star)
                        });
                }

                // ***
                // Add Cells
                // ***
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        rect = new Rectangle();
                        rect.Stretch = Stretch.Fill;
                        rect.Fill = new SolidColorBrush(getCellColor(i, j));
                        rect.Margin = new Thickness(CellMargin);
                        Grid.SetRow(rect, i);
                        Grid.SetColumn(rect, j);
                        cellLayout.Children.Add(rect);
                    }
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

        //------------------------------------------------------------------------------------------------------------------------

        private void resize(
            )
        {
            double size = 0d;

            try
            {
                // ***
                // Calculate Wafer Map Size
                // ***
                size = (ActualWidth > ActualHeight) ? ActualHeight : ActualWidth;
                size -= RootLayout.RowDefinitions[0].ActualHeight;
                
                // --

                // ***
                // Resize Root Layout
                // ***                
                column.Width = new GridLength(size + 10);
                row.Height = new GridLength(size + 10);
                
                // ***
                // Resize Wafer Map
                // ***
                bodyCanvas.Width = size;
                bodyCanvas.Height = size;
                cellLayout.Width = size;
                cellLayout.Height = size;
                waferLayout.Width = size;
                waferLayout.Height = size;

                // -- 

                // ***
                // Canvas Position
                // ***
                Canvas.SetLeft(legendGroupBox, size + 10);
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

        private Color getCellColor(
            int row,
            int column
            )
        {
            FCell fCell = null;

            try
            {
                if ((fCell = fCells[row, column]) != null)
                {
                    return fFlags.matchColor(fCell.value);
                }
                return Colors.Transparent;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return Colors.Transparent;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Callbacks

        private void OnRowsPropertyChangedCallback(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e
            )
        {
            try
            {
                Rows = (int)e.NewValue;
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

        private void OnColumnsPropertyChangedCallback(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e
            )
        {
            try
            {
                Columns = (int)e.NewValue;
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

        private void OnCellMarginPropertyChangedCallback(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e
            )
        {
            try
            {
                CellMargin = (int)e.NewValue;
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

        private void OnWaferBorderPropertyChangedCallback(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e
            )
        {
            try
            {
                WaferBorder = (Color)e.NewValue;
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

        private void OnWaferBorderThicknessPropertyChangedCallback(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e
            )
        {
            try
            {
                WaferBorderThickness = (int)e.NewValue;
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

        private void OnLegendVisibilityPropertyChangedCallback(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e
            )
        {
            try
            {
                LegendVisibility = (bool)e.NewValue;
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

        private void OnTitleVisibilityPropertyChangedCallback(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e
            )
        {
            try
            {
                TitleVisibility = (bool)e.NewValue;                
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

        private void OnTitlePropertyChangedCallback(
           DependencyObject d,
           DependencyPropertyChangedEventArgs e
           )
        {
            try
            {
                Title = e.NewValue.ToString();
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

        #region fWaferChart Event Handler

        private void fWaferChart_SizeChanged(
            object sender,
            SizeChangedEventArgs e
            )
        {
            try
            {
                resize();
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

        private void fWaferChart_Loaded(
            object sender, 
            RoutedEventArgs e
            )
        {
            try
            {
                resize();
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

    } // End Class
} // End Namespace