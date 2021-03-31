/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : w_FToolBox.xaml.cs
--  Creator         : byjeon
--  Create Date     : 2012.10.04
--  Description     : FAMate Core FaUIs WPF ToolBox
--  History         : Created by byjeon at 2012.10.04
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs.WPF
{
    public partial class FToolBox : UserControl, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const int DragWaitCounterLimit = 10;    
        
        // --

        private bool m_disposed = false;
        // --
        private int m_oldIndex = -1;        
        private FDragAdorner m_fDragAdorner = null;
        private FInsertAdorner m_fInsertAdorner = null;
        private int m_dragScrollWaitCounter;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Contruction and Destruction

        public FToolBox(
            )
        {
            InitializeComponent();
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FToolBox(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    term();
                }
                m_disposed = true;
            }            
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

        public FToolboxItems fToolboxItems
        {
            get
            {
                try
                {
                    return Resources["fToolboxItems"] as FToolboxItems;
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
                this.m_dragScrollWaitCounter = DragWaitCounterLimit;
                // --
                toolBox.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(FToolBox_PreviewMouseLeftButtonDown);
                toolBox.PreviewDrop += new DragEventHandler(FToolBox_PreviewDrop);
                toolBox.PreviewDragEnter += new DragEventHandler(FToolBox_PreviewDragEnter);
                toolBox.PreviewDragLeave += new DragEventHandler(FToolBox_PreviewDragLeave);
                toolBox.PreviewDragOver += new DragEventHandler(FToolBox_PreviewDragOver);
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
                if (toolBox != null)
                {
                    toolBox.PreviewMouseLeftButtonDown -= new MouseButtonEventHandler(FToolBox_PreviewMouseLeftButtonDown);
                    toolBox.PreviewDrop -= new DragEventHandler(FToolBox_PreviewDrop);
                    toolBox.PreviewDragEnter -= new DragEventHandler(FToolBox_PreviewDragEnter);
                    toolBox.PreviewDragLeave -= new DragEventHandler(FToolBox_PreviewDragLeave);
                    toolBox.PreviewDragOver -= new DragEventHandler(FToolBox_PreviewDragOver);
                    toolBox = null;
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

        private int getCurrentIndex(
            GetPositionDelegate getPosition
            )
        {
            int index = -1;
            ListBoxItem listBoxItem = null;

            try
            {
                for (int i = 0; i < this.toolBox.Items.Count; i++)
                {
                    listBoxItem = getToolboxItem(i);
                    if (this.isMouseOverTarget(listBoxItem, getPosition))
                    {
                        index = i;
                        break;
                    }
                }
                return index;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return -1;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private int findInsertIndex(
            ItemsControl itemsControl,
            DragEventArgs e
            )
        {
            int index = -1;
            UIElement dropTargetContainer = null;

            try
            {
                dropTargetContainer = FCommon.getItemContainerFromPoint(itemsControl, e.GetPosition(itemsControl));
                if (dropTargetContainer != null)
                {
                    index = itemsControl.ItemContainerGenerator.IndexFromContainer(dropTargetContainer);
                    if (!FCommon.isPointInTopHalf(itemsControl, e))
                    {
                        index += 1;
                    }
                    return index;
                }
                return itemsControl.Items.Count;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
            
            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private ListBoxItem getToolboxItem(
            int index
            )
        {
            ListBoxItem item = null;

            try
            {
                if (this.toolBox.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
                {
                    item = this.toolBox.ItemContainerGenerator.ContainerFromIndex(index) as ListBoxItem;
                }
                return item;
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

        private bool isMouseOverTarget(
            Visual target,
            GetPositionDelegate getPosition
            )
        {
            System.Windows.Rect bounds;
            System.Windows.Point mousePos;

            try
            {
                bounds = VisualTreeHelper.GetDescendantBounds(target);
                mousePos = getPosition((IInputElement)target);

                return bounds.Contains(mousePos);
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

        private void initDragAdorner(
            ItemsControl itemsControl,
            DragEventArgs e
            )
        {
            FToolboxItem fToolboxItem = null;
            AdornerLayer adornerLayer = null;

            try
            {
                if (m_fDragAdorner == null)
                {
                    if (!e.Data.GetDataPresent(typeof(FToolboxItem)))
                    {
                        return;
                    }

                    fToolboxItem = e.Data.GetData(typeof(FToolboxItem)) as FToolboxItem;
                    adornerLayer = AdornerLayer.GetAdornerLayer(itemsControl);
                    m_fDragAdorner = new FDragAdorner(itemsControl, fToolboxItem.text, adornerLayer);
                    updateDragAdorner(itemsControl, e);
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

        private void updateDragAdorner(
            ItemsControl itemsControl,
            DragEventArgs e
            )
        {
            try
            {
                if (m_fDragAdorner != null)
                {
                    m_fDragAdorner.position = e.GetPosition(itemsControl) + new Vector(10, 10);
                    InvalidateVisual();
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

        private void initInsertAdorner(
            ItemsControl itemsControl,
            DragEventArgs e
            )
        {
            bool isPointInTopHalf = false;
            UIElement itemContainer = null;

            try
            {
                if (m_fInsertAdorner != null)
                {
                    m_fInsertAdorner.destroy();
                }

                var adornerLayer = AdornerLayer.GetAdornerLayer(itemsControl);
                itemContainer = FCommon.getItemContainerFromPoint(itemsControl, e.GetPosition(itemsControl));

                if (itemContainer != null)
                {
                    isPointInTopHalf = FCommon.isPointInTopHalf(itemsControl, e);
                    m_fInsertAdorner = new FInsertAdorner(itemContainer, isPointInTopHalf, adornerLayer);
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

        private void updateInsertAdorner(
            ItemsControl itemsControl,
            DragEventArgs e
            )
        {
            try
            {
                if (m_fInsertAdorner != null)
                {
                    m_fInsertAdorner.isTopHalf = FCommon.isPointInTopHalf(itemsControl, e);
                    m_fInsertAdorner.InvalidateVisual();
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

        private void detachAdorners(
            )
        {
            try
            {
                if (m_fInsertAdorner != null)
                {
                    m_fInsertAdorner.destroy();
                    m_fInsertAdorner = null;
                }

                if (m_fDragAdorner != null)
                {
                    m_fDragAdorner.destroy();
                    m_fDragAdorner = null;
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

        private void handleDragScrolling(
            ItemsControl itemsControl,
            DragEventArgs e
            )
        {
            bool? isMouseAtTop = null;
            ScrollViewer scrollViewer = null;

            try
            {
                scrollViewer = FCommon.findScrollViewer(toolBox);
                isMouseAtTop = FCommon.isMousePointerAtTop(scrollViewer.ActualHeight, e.GetPosition(scrollViewer));

                if (isMouseAtTop.HasValue)
                {
                    if (m_dragScrollWaitCounter == DragWaitCounterLimit)
                    {
                        m_dragScrollWaitCounter = 0;
                        if (scrollViewer.ComputedVerticalScrollBarVisibility == Visibility.Visible)
                        {
                            if (isMouseAtTop.Value)
                            {
                                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - 1.0);
                            }
                            else
                            {
                                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + 1.0);
                            }
                            e.Effects = DragDropEffects.Scroll;
                        }
                    }
                    else
                    {
                        m_dragScrollWaitCounter++;
                    }
                }
                else
                {
                    e.Effects = DragDropEffects.Move;                        
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

        private void resetState(
            )
        {
            try
            {
                m_oldIndex = -1;
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

        #region FToolbox Event Handler

        private void FToolBox_PreviewMouseLeftButtonDown(
            object sender,
            MouseButtonEventArgs e
            )
        {
            FToolboxItem fSelectedItem = null;

            try
            {
                m_oldIndex = this.getCurrentIndex(e.GetPosition);

                if (m_oldIndex < 0)
                {
                    return;
                }

                // -- 

                fSelectedItem = this.toolBox.Items[m_oldIndex] as FToolboxItem;

                if(fSelectedItem == null)
                {
                    return ;
                }

                // -- 

                DragDrop.DoDragDrop(this.toolBox, fSelectedItem, DragDropEffects.Move);

                // -- 

                e.Handled = true;
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

        private void FToolBox_PreviewDragEnter(
            object sender,
            DragEventArgs e
            )
        {
            ItemsControl itemsControl = null;

            try
            {
                if (!e.Data.GetDataPresent(typeof(FToolboxItem)))
                {
                    return;
                }

                // --

                itemsControl = sender as ItemsControl;

                // --

                this.initDragAdorner(itemsControl, e);
                this.initInsertAdorner(itemsControl, e);

                // -- 

                e.Handled = true;
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

        private void FToolBox_PreviewDragOver(
            object sender,
            DragEventArgs e
            )
        {
            ItemsControl itemsControl = null;

            try
            {
                if(!e.Data.GetDataPresent(typeof(FToolboxItem)))
                {
                    return;
                }

                // -- 

                itemsControl = sender as ItemsControl;

                // --

                updateDragAdorner(itemsControl, e);
                updateInsertAdorner(itemsControl, e);
                handleDragScrolling(itemsControl, e);

                // -- 

                e.Handled = true;
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

        private void FToolBox_PreviewDragLeave(
            object sender,
            DragEventArgs e
            )
        {
            try
            {
                detachAdorners();

                // -- 

                e.Handled = true;
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

        private void FToolBox_PreviewDrop(
            object sender,
            DragEventArgs e
            )
        {
            int index = -1;
            ItemsControl itemsControl = null;
            FToolboxItem droppedItem = null;

            try
            {
                detachAdorners();

                // -- 

                if (!e.Data.GetDataPresent(typeof(FToolboxItem)))
                {
                    return ;
                }

                // -- 

                itemsControl = sender as ItemsControl;
                index = findInsertIndex(itemsControl, e);
                droppedItem = e.Data.GetData(typeof(FToolboxItem)) as FToolboxItem;
                // -- 
                fToolboxItems.RemoveAt(m_oldIndex);

                // -- 

                if (
                    index > 0 &&
                    m_oldIndex < index
                    )
                {
                    index -= 1;
                }

                // -- 

                fToolboxItems.Insert(index, droppedItem);
                resetState();
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

    } // Class end
} // Namespace end