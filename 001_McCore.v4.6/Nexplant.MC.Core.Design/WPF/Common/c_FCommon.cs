/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FCommon.cs
--  Creator         : byjeon
--  Create Date     : 2012.09.28
--  Description     : FAMate Core FaUIs WPF Common Class
--  History         : Created by byjeon at 2012.09.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs.WPF
{
    public static class FCommon
    {
       
        //------------------------------------------------------------------------------------------------------------------------

        public static bool isPointInTopHalf(
            ItemsControl itemsControl,
            DragEventArgs e
            )
        {
            double middlePoint = 0.0;
            UIElement itemContainer = null;
            System.Windows.Point mousePosition;

            try
            {
                itemContainer = getItemContainerFromPoint(itemsControl, e.GetPosition(itemsControl));

                // -- 

                middlePoint = (itemContainer as FrameworkElement).ActualHeight / 2;
                mousePosition = e.GetPosition(itemContainer);

                // -- 

                return mousePosition.Y < middlePoint;
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

        //------------------------------------------------------------------------------------------------------------------------

        public static UIElement getItemContainerFromPoint(
            ItemsControl itemsControl,
            System.Windows.Point pt
            )
        {
            object item = null;
            UIElement element = null;

            try
            {
                element = itemsControl.InputHitTest(pt) as UIElement;
                while (element != null)
                {
                    if (element == itemsControl)
                    {
                        return null;
                    }

                    item = itemsControl.ItemContainerGenerator.ItemFromContainer(element);
                    if (item != DependencyProperty.UnsetValue)
                    {
                        return element;
                    }
                    else
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;
                    }
                }
                return null;
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

        //------------------------------------------------------------------------------------------------------------------------

        public static bool? isMousePointerAtTop(
            double height,
            System.Windows.Point pt
            )
        {
            try
            {
                if (pt.Y > 0.0 && pt.Y < 25)
                {
                    return true;
                }
                else if (pt.Y > height - 25 && pt.Y < height)
                {
                    return false;
                }
                return null;
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

        //------------------------------------------------------------------------------------------------------------------------

        public static ScrollViewer findScrollViewer(
            ItemsControl itemsControl
            )
        {
            UIElement element = null;

            try
            {
                element = itemsControl;

                while (element != null)
                {
                    if (VisualTreeHelper.GetChildrenCount(element) == 0)
                    {
                        element = null;
                    }
                    else
                    {
                        element = VisualTreeHelper.GetChild(element, 0) as UIElement;
                        if(element != null && element is ScrollViewer)
                        {
                            return element as ScrollViewer;
                        }
                    }
                }
                return null;
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

        //------------------------------------------------------------------------------------------------------------------------

        public static System.Windows.Controls.Image bindImageFromGdiImage(
            System.Drawing.Image gdiImage
            )
        {
            IntPtr hBitmap;
            System.Drawing.Bitmap gdiBitmap = null;            
            System.Windows.Media.ImageSource wpfBitmap = null;
            System.Windows.Controls.Image wpfImage = null;

            try
            {
                gdiBitmap = new System.Drawing.Bitmap(gdiImage);
                hBitmap = gdiBitmap.GetHbitmap();

                // -- 

                wpfBitmap =
                    System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                        hBitmap,
                        IntPtr.Zero,
                        Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions()
                        );
                
                // -- 
                
                wpfImage = new System.Windows.Controls.Image();
                wpfImage.Source = wpfBitmap;
                wpfImage.Width = (double)gdiBitmap.Width;
                wpfImage.Height = (double)gdiBitmap.Height;
                wpfImage.Stretch = System.Windows.Media.Stretch.Fill;

                // --

                return wpfImage;
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
        
        //------------------------------------------------------------------------------------------------------------------------

        public static System.Windows.Media.Color convertWinColorToWpfColor(
           System.Drawing.Color color
           )
        {
            System.Windows.Media.Color wpfColor = System.Windows.Media.Colors.Black;

            try
            {
                wpfColor.R = color.R;
                wpfColor.G = color.G;
                wpfColor.B = color.B;
                wpfColor.A = color.A;

                return wpfColor;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return System.Windows.Media.Colors.Black;
        }

        //------------------------------------------------------------------------------------------------------------------------

    } // Class end
} // Namespace end