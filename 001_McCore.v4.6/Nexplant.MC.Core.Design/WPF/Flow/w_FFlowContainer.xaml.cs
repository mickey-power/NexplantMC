/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : w_FFlowContainer.cs
--  Creator         : byjeon
--  Create Date     : 2012.10.04
--  Description     : FAMate Core FaUIs WPF Flow Container Control
--  History         : Created by byjeon at 2012.10.04
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Infragistics.Win.UltraWinToolbars;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs.WPF
{
    public partial class FFlowContainer : UserControl, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FFlowContainerActivatedEventHandler FlowContainerActivated;
        public event FFlowCtrlActivatedEventHandler FlowCtrlActivated;
        public event FFlowMouseMoveEventHandler FlowMouseMove;
        public event FFlowDragOverEventHandler FlowDragOver;
        public event FFlowDragDropEventHandler FlowDragDrop;
        // -- 
        public event FFlowCtrlDroppedEventHandler FlowCtrlDropped;
        
        // -- 

        private const int DragWaitCounterLimit = 7;

        // --

        private bool m_disposed = false;
        // --
        private PopupMenuTool m_popupMenu = null;
        // -- 
        private int m_oldIndex = -1;
        private FDragAdorner m_fDragAdorner = null;
        private FInsertAdorner m_fInsertAdorner = null;
        private FIFlowCtrl m_fActiveFlowCtrl = null;        
        private int m_dragScrollWaitCount = DragWaitCounterLimit;
        // --
        private Dictionary<string, FIFlowCtrl> m_flowCtrlKeys = null;    
        // --
        private DragDropEffects m_dragDropEffect = DragDropEffects.None;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Contruction and Destruction

        public FFlowContainer(
            )
        {
            InitializeComponent();
            // -- 
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FFlowContainer(
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

        internal PopupMenuTool popupMenu
        {
            get
            {
                try
                {
                    return m_popupMenu;
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

        public bool isActive
        {
            get
            {
                try
                {
                    if (fActiveFlowCtrl == null)
                    {
                        return true;
                    }
                    return false;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string title
        {
            get
            {
                string title = string.Empty;

                try
                {
                    title = m_titleBar.Text;
                    return title.Trim();
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
                    m_titleBar.Text = value;
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

        public System.Windows.Media.Brush fontColor
        {
            get
            {
                try
                {
                    return m_titleBar.Foreground;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return System.Windows.Media.Brushes.Black;
            }

            set
            {
                try
                {
                    m_titleBar.Foreground = value;
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

        public bool fontBold
        {
            get
            {
                try
                {
                    if (m_titleBar.FontWeight == FontWeights.Bold)
                    {
                        return true;
                    }
                    return false;
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
                    m_titleBar.FontWeight = value ? FontWeights.Bold : FontWeights.Normal;                    
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

        private FFlowItems fFlowItems
        {
            get
            {
                try
                {
                    return Resources["fFlowItems"] as FFlowItems;
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

        // ***
        // 2012.11.22 by spike.lee
        // Core 쪽에 내부적으로 사용하는 Property나 Method를 public으로 노출하면 많은 버그가 발생할 수 있습니다.
        // 주의해서 하세요.
        // ***
        private List<FIFlowCtrl> fFlowCtrlList
        {
            get
            {
                List<FIFlowCtrl> ctrlList = null;

                try                
                {
                    ctrlList = new List<FIFlowCtrl>();

                    foreach (FIFlowCtrl fFlowCtrl in this.fFlowItems)
                    {
                        ctrlList.Add(fFlowCtrl);
                    }                    
                    return ctrlList;
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

        public FFlowCtrlCollection fFlowCtrlCollection
        {
            get
            {
                try
                {
                    return new FFlowCtrlCollection(fFlowCtrlList);
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

        public FIFlowCtrl fActiveFlowCtrl
        {
            get
            {
                try
                {
                    return m_fActiveFlowCtrl;
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

        public string eqAlias
        {
            get
            {
                try
                {
                    return m_eqTextBlock.Text;
                }
                catch(Exception ex)
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
                    m_eqTextBlock.Text = value;
                    m_eqTextBlock.FontWeight = FontWeights.Bold;
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

        public string eapAlias
        {
            get
            {
                try
                {
                    return m_eapTextBlock.Text;
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
                    m_eapTextBlock.Text = value;
                    m_eapTextBlock.FontWeight = FontWeights.Bold;
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

        public string hostAlias
        {
            get
            {
                try
                {
                    return m_hostTextBlock.Text;
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
                    m_hostTextBlock.Text = value;
                    m_hostTextBlock.FontWeight = FontWeights.Bold;
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

        public Style activateFlowCtrlStyle
        {
            get
            {
                try
                {
                    return Resources["activateFlowCtrlStyle"] as Style;
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

        public Style deactivateFlowCtrlStyle
        {
            get
            {
                try
                {
                    return Resources["deactivateFlowCtrlStyle"] as Style;
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

        public Style activateTitleBarStyle
        {
            get
            {
                try
                {
                    return Resources["activateTitleBarStyle"] as Style;
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

        public Style deactivateTitleBarStyle
        {
            get
            {
                try
                {
                    //return Resources["deactiveTitleBarStyle"] as Style;
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
                m_dragScrollWaitCount = DragWaitCounterLimit;
                m_flowCtrlKeys = new Dictionary<string, FIFlowCtrl>();

                // --

                this.m_flowBody.AllowDrop = true;
                
                // -- 
                
                this.SizeChanged += new System.Windows.SizeChangedEventHandler(fFlowContainer_SizeChanged);
                
                // --

                this.m_flowBase.MouseDown += new System.Windows.Input.MouseButtonEventHandler(flowBase_MouseDown);
                 
                // --

                this.m_flowBody.SelectionChanged += new SelectionChangedEventHandler(flowBody_SelectionChanged);
                //this.m_flowBody.PreviewDragEnter += new DragEventHandler(flowBody_PreviewDragEnter);
                //this.m_flowBody.PreviewDragLeave += new DragEventHandler(flowBody_PreviewDragLeave);
                //this.m_flowBody.PreviewDragOver += new DragEventHandler(flowBody_PreviewDragOver);
                //this.m_flowBody.PreviewDrop += new DragEventHandler(flowBody_PreviewDrop);

                // --

                // ***
                // 2017.01.18 by spike.lee
                // DragDrop 구현을 위한 기능 추가
                // ***
                this.m_flowBody.MouseMove += new System.Windows.Input.MouseEventHandler(m_flowBody_MouseMove);
                this.m_flowBody.DragOver += new DragEventHandler(m_flowBody_DragOver);
                this.m_flowBody.Drop += new DragEventHandler(m_flowBody_Drop);                
                
                // --
                
                this.applyWindowSize();
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
                m_popupMenu = null;
                m_flowCtrlKeys = null;

                // --

                this.SizeChanged -= new System.Windows.SizeChangedEventHandler(fFlowContainer_SizeChanged);

                // --

                this.m_flowBase.MouseDown -= new System.Windows.Input.MouseButtonEventHandler(flowBase_MouseDown);

                // --

                this.m_flowBody.SelectionChanged -= new SelectionChangedEventHandler(flowBody_SelectionChanged);
                //this.m_flowBody.PreviewDragEnter -= new DragEventHandler(flowBody_PreviewDragEnter);
                //this.m_flowBody.PreviewDragLeave -= new DragEventHandler(flowBody_PreviewDragLeave);
                //this.m_flowBody.PreviewDragOver -= new DragEventHandler(flowBody_PreviewDragOver);
                //this.m_flowBody.PreviewDrop -= new DragEventHandler(flowBody_PreviewDrop);

                // --

                // ***
                // 2017.01.18 by spike.lee
                // DragDrop 구현을 위한 기능 추가
                // ***
                this.m_flowBody.MouseMove -= new System.Windows.Input.MouseEventHandler(m_flowBody_MouseMove);
                this.m_flowBody.DragOver -= new DragEventHandler(m_flowBody_DragOver);
                this.m_flowBody.Drop -= new DragEventHandler(m_flowBody_Drop);                

                // --

                if (m_fDragAdorner != null)
                {
                    m_fDragAdorner.Dispose();
                    m_fDragAdorner = null;
                }

                if (m_fInsertAdorner != null)
                {
                    m_fInsertAdorner.Dispose();
                    m_fInsertAdorner = null;
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

        public void setPopupMenu(
            PopupMenuTool popupMenu
            )
        {
            try
            {
                m_popupMenu = popupMenu;
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

        public FIFlowCtrl appendFlowCtrl(
            FIFlowCtrl fNewFlowCtrl
            )
        {
            try
            {
                if (fNewFlowCtrl.fParent != null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "New Object", "Parent"));
                }

                // -- 

                m_flowCtrlKeys.Add(fNewFlowCtrl.key, fNewFlowCtrl);
                fFlowItems.Add(fNewFlowCtrl);
                fNewFlowCtrl.fParent = this;

                // -- 

                return fNewFlowCtrl;
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

        public FIFlowCtrl insertFlowCtrl(
            FIFlowCtrl fNewFlowCtrl,
            int index
            )
        {
            try
            {
                if (fNewFlowCtrl.fParent != null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "New Object", "Parent"));
                }

                // -- 

                if (fFlowItems.Count < index)
                {                    
                    FDebug.throwFException(string.Format(FConstants.err_m_0001, "Index"));
                }

                // --

                m_flowCtrlKeys.Add(fNewFlowCtrl.key, fNewFlowCtrl);
                fFlowItems.Insert(index, fNewFlowCtrl);
                fNewFlowCtrl.fParent = this;

                // -- 

                return fNewFlowCtrl;
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

        public FIFlowCtrl insertBeforeFlowCtrl(
            FIFlowCtrl fNewFlowCtrl,
            FIFlowCtrl fRefFlowCtrl
            )
        {
            int index = 0;

            try
            {
                if (fNewFlowCtrl.fParent != null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "New Object", "Parent"));
                }

                if (!fFlowItems.Contains(fRefFlowCtrl))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Reference Object", "Child"));
                }

                // -- 

                index = fFlowItems.IndexOf(fRefFlowCtrl);

                // -- 

                m_flowCtrlKeys.Add(fNewFlowCtrl.key, fNewFlowCtrl);
                fFlowItems.Insert(index, fNewFlowCtrl);
                fNewFlowCtrl.fParent = this;
                
                // -- 

                return fNewFlowCtrl;
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

        public FIFlowCtrl insertAfterFlowCtrl(
            FIFlowCtrl fNewFlowCtrl,
            FIFlowCtrl fRefFlowCtrl
            )
        {
            int index = 0;

            try
            {
                if (fNewFlowCtrl.fParent != null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "New Object", "Parent"));
                }

                if (!fFlowItems.Contains(fRefFlowCtrl))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Reference Object", "Child"));
                }

                // -- 

                index = fFlowItems.IndexOf(fRefFlowCtrl);

                // -- 

                m_flowCtrlKeys.Add(fNewFlowCtrl.key, fNewFlowCtrl);
                fFlowItems.Insert(index + 1, fNewFlowCtrl);
                fNewFlowCtrl.fParent = this;

                // -- 

                return fNewFlowCtrl;
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

        public FIFlowCtrl removeFlowCtrl(
            FIFlowCtrl fFlowCtrl
            )
        {
            int index = 0;
            FIFlowCtrl fOldActiveFlowCtrl = null;
            FIFlowCtrl fActiveFlowCtrl = null;

            try
            {
                if (fFlowCtrl.fParent == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0005, "Object"));
                }

                if (!fFlowItems.Contains(fFlowCtrl))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "Child"));
                }

                // -- 

                index = fFlowItems.IndexOf(fFlowCtrl);

                // -- 

                fOldActiveFlowCtrl = fActiveFlowCtrl;
                m_flowCtrlKeys.Remove(fFlowCtrl.key);
                fFlowItems.Remove(fFlowCtrl);
                // fFlowCtrl.fParent = null;
                
                // -- 

                if (fFlowItems.Count > 0)
                {
                    if (index >= fFlowItems.Count)
                    {
                        fActiveFlowCtrl = fFlowCtrlList[index - 1];
                    }
                    else
                    {
                        fActiveFlowCtrl = fFlowCtrlList[index];
                    }
                    activateFlowCtrl(fActiveFlowCtrl);
                }
                else
                {
                    activateFlowContainer();
                }

                // -- 

                return fFlowCtrl;
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

        public void removeAllFlowCtrl(
            )
        {
            try
            {
                //foreach (FIFlowCtrl f in fFlowItems)
                //{
                //    f.fParent = null;
                //}
                // --
                m_flowCtrlKeys.Clear();
                fFlowItems.Clear();
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

        public FIFlowCtrl getFlowCtrl(
            string key
            )
        {
            try
            {
                if (m_flowCtrlKeys.ContainsKey(key))
                {
                    return m_flowCtrlKeys[key];
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

        public FIFlowCtrl getFlowCtrl(
            int index
            )
        {
            try
            {
                if (fFlowCtrlCollection.count > index)
                {
                    return fFlowCtrlCollection[index];
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

        public void activateFlowContainer(
            )
        {
            try
            {
                if(m_fActiveFlowCtrl != null)
                {
                    m_fActiveFlowCtrl.panel.Style = deactivateFlowCtrlStyle;
                }                
                
                // -- 

                if (FlowContainerActivated != null)
                {
                    FlowContainerActivated(this, new FFlowContainerActivatedEventArgs(this));
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

        public void activateFlowCtrl(
            FIFlowCtrl fFlowCtrl
            )
        {
            try
            {
                if (!fFlowItems.Contains(fFlowCtrl))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "Child"));
                }                

                // -- 

                this.m_flowBody.SelectedItem = fFlowCtrl;
                this.m_flowBody.ScrollIntoView(fFlowCtrl);
                fFlowCtrl.panel.Style = activateFlowCtrlStyle;                
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

        public void moveUpFlowCtrl(
            FIFlowCtrl fFlowCtrl
            )
        {
            int index = 0;
            FIFlowCtrl fOldFlowCtrl = null;
            FIFlowCtrl fPrevFlowCtrl = null;

            try
            {
                if (fFlowCtrl.fParent == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0005, "Object"));
                }

                if (!fFlowItems.Contains(fFlowCtrl))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "Child"));
                }

                if (fFlowCtrl.fPreviousSibling == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "PreviousSibling"));
                }

                // -- 

                index = fFlowItems.IndexOf(fFlowCtrl);
                fPrevFlowCtrl = fFlowCtrl.fPreviousSibling;

                fOldFlowCtrl = fFlowCtrl;
                m_flowCtrlKeys.Remove(fFlowCtrl.key);

                // --

                fFlowItems.Remove(fFlowCtrl);
                                
                // --

                index = fFlowItems.IndexOf(fPrevFlowCtrl);
                fFlowItems.Insert(index, fOldFlowCtrl);
                m_flowCtrlKeys.Add(fOldFlowCtrl.key, fOldFlowCtrl);
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

        public void moveDownFlowCtrl(
            FIFlowCtrl fFlowCtrl
            )
        {
            int index = 0;
            FIFlowCtrl fOldFlowCtrl = null;
            FIFlowCtrl fNextFlowCtrl = null;
            try
            {
                if (fFlowCtrl.fParent == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0005, "Object"));
                }

                if (!fFlowItems.Contains(fFlowCtrl))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "Child"));
                }

                if (fFlowCtrl.fNextSibling == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "NextSibling"));
                }

                // --

                index = fFlowItems.IndexOf(fFlowCtrl);
                fNextFlowCtrl = fFlowCtrl.fNextSibling;
                fOldFlowCtrl = fFlowCtrl;
                m_flowCtrlKeys.Remove(fFlowCtrl.key);

                // -- 

                fFlowItems.Remove(fFlowCtrl);

                // -- 

                index = fFlowItems.IndexOf(fNextFlowCtrl);
                fFlowItems.Insert(index + 1, fOldFlowCtrl);
                m_flowCtrlKeys.Add(fOldFlowCtrl.key, fOldFlowCtrl);
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

        private void applyWindowSize(
            )
        {
            try
            {                
                if (this.ActualWidth - 10 > 0)
                {
                    m_titleBar.Width = this.ActualWidth - 10;
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

        public void refreshFlowContainer(
            )
        {
            try
            {
                m_flowBody.Items.Refresh();
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

        public void changeAliasName(
            string eqAlias,
            string eapAlias,
            string hostAlias
            )
        {
            try
            {
                this.eqAlias = eqAlias;
                this.eapAlias = eapAlias;
                this.hostAlias = hostAlias;
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
                for (int i = 0; i < this.m_flowBody.Items.Count; i++)
                {
                    listBoxItem = getListBoxItem(m_flowBody, i);
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
                    if (FCommon.isPointInTopHalf(itemsControl, e))
                    {
                        return index;
                    }
                    else
                    {
                        return index + 1;
                    }
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
            return -1;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private ListBoxItem getListBoxItem(
            ListBox listBox,
            int index
            )
        {
            ListBoxItem listBoxItem = null;
            
            try
            {
                if (listBox.ItemContainerGenerator.Status == System.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated)
                {
                    listBoxItem = listBox.ItemContainerGenerator.ContainerFromIndex(index) as ListBoxItem;
                }
                return listBoxItem;
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
            Rect bounds;
            Point mousePos;

            try
            {
                if (target != null)
                {
                    bounds = VisualTreeHelper.GetDescendantBounds(target);
                    mousePos = getPosition((IInputElement)target);

                    return bounds.Contains(mousePos);
                }
                return false;
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

                if(m_fDragAdorner != null)
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

        private void initDragAdorner(
            ItemsControl itemsControl,
            DragEventArgs e
            )
        {
            FIFlowCtrl fFlowCtrl = null;

            try
            {
                if (m_fDragAdorner == null)
                {
                    if (!this.isFlowCtrl(e.Data as DataObject))
                    {
                        return;
                    }

                    fFlowCtrl = convertFlowCtrlToDataObject(e.Data as DataObject);
                    var adornerLayer = AdornerLayer.GetAdornerLayer(itemsControl);
                    m_fDragAdorner = new FDragAdorner(itemsControl, fFlowCtrl.text, adornerLayer);
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
            AdornerLayer adornerLayer = null;

            try
            {
                if (m_fInsertAdorner == null)
                {
                    adornerLayer = AdornerLayer.GetAdornerLayer(itemsControl);
                    itemContainer = FCommon.getItemContainerFromPoint(itemsControl, e.GetPosition(itemsControl));
                    if (itemContainer != null)
                    {
                        isPointInTopHalf = FCommon.isPointInTopHalf(itemsControl, e);
                        m_fInsertAdorner = new FInsertAdorner(itemContainer, isPointInTopHalf, adornerLayer);
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

        private void handleDragScrolling(
            ItemsControl itemsControl,
            DragEventArgs e
            )
        {
            bool? isMouseAtTop = null;
            ScrollViewer scrollViewer = null;

            try
            {
                scrollViewer = FCommon.findScrollViewer(m_flowBody);
                isMouseAtTop = FCommon.isMousePointerAtTop(scrollViewer.ActualHeight, e.GetPosition(scrollViewer));

                // -- 

                if (isMouseAtTop.HasValue)
                {
                    if (m_dragScrollWaitCount == DragWaitCounterLimit)
                    {
                        m_dragScrollWaitCount = 0;
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
                        m_dragScrollWaitCount++;
                    }
                }
                else
                {
                    e.Effects =
                        ((e.KeyStates & DragDropKeyStates.ControlKey) != 0) ?
                        DragDropEffects.Copy : DragDropEffects.Move;
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

        private FIFlowCtrl convertFlowCtrlToDataObject(
            DataObject dataObject
            )
        {
            Type flowCtrlType = null;
            Type[] flowCtrlTypeList = 
                {
                    typeof(FSecsTriggerFlow),
                    typeof(FSecsTransmitterFlow),
                    typeof(FHostTriggerFlow),
                    typeof(FHostTransmitterFlow),
                    typeof(FEquipmentStateSetAltererFlow),
                    typeof(FJudgementFlow),
                    typeof(FMapperFlow),
                    typeof(FStorageFlow),
                    typeof(FCallbackFlow),
                    typeof(FBranchFlow),
                    typeof(FCommentFlow),
                    typeof(FPauserFlow),
                    typeof(FEntryPointFlow)
                };

            try
            {
                foreach (Type type in flowCtrlTypeList)
                {
                    if (dataObject.GetDataPresent(type))
                    {
                        flowCtrlType = type;
                        break;
                    }
                }

                // -- 

                return (FIFlowCtrl)dataObject.GetData(flowCtrlType);
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

        private bool isFlowCtrl(
            DataObject dataObject
            )
        {
            bool isFlowCtrl = false;

            try
            {
                if (
                    dataObject.GetDataPresent(typeof(FSecsTriggerFlow)) ||
                    dataObject.GetDataPresent(typeof(FSecsTransmitterFlow)) ||
                    dataObject.GetDataPresent(typeof(FHostTriggerFlow)) ||
                    dataObject.GetDataPresent(typeof(FHostTransmitterFlow)) ||
                    dataObject.GetDataPresent(typeof(FEquipmentStateSetAltererFlow)) ||
                    dataObject.GetDataPresent(typeof(FJudgementFlow)) ||
                    dataObject.GetDataPresent(typeof(FMapperFlow)) ||
                    dataObject.GetDataPresent(typeof(FStorageFlow)) ||
                    dataObject.GetDataPresent(typeof(FCallbackFlow)) ||
                    dataObject.GetDataPresent(typeof(FBranchFlow)) ||
                    dataObject.GetDataPresent(typeof(FCommentFlow)) ||
                    dataObject.GetDataPresent(typeof(FPauserFlow)) ||
                    dataObject.GetDataPresent(typeof(FEntryPointFlow))
                    )
                {
                    isFlowCtrl = true;
                }
                return isFlowCtrl;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FIFlowCtrl getPreviousFlowCtrl(
            FIFlowCtrl fFlowCtrl)
        {
            int index = -1;

            try
            {
                index = fFlowItems.IndexOf(fFlowCtrl);

                if (index <= 0)
                {
                    return null;
                }

                return fFlowItems[index - 1];
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

        public FIFlowCtrl getNextFlowCtrl(
            FIFlowCtrl fFlowCtrl
            )
        {
            int index = -1;

            try
            {
                index = fFlowItems.IndexOf(fFlowCtrl);

                if (index >= fFlowItems.Count - 1)
                {
                    return null;
                }

                return fFlowItems[index + 1];
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

        public System.Drawing.Bitmap getImage(            
            )
        {
            RenderTargetBitmap rtb = null;
            System.Drawing.Bitmap bitmapImage = null;
            BitmapEncoder pngBitmapEncoder = null;

            try
            {
                // --

                this.Measure(new Size(this.Width, this.Height));
                this.Arrange(new Rect(new Size(this.Width, this.Height)));
                this.UpdateLayout();

                // --
                
                rtb = new RenderTargetBitmap(
                    (int)this.RenderSize.Width,
                    (int)this.RenderSize.Height, 
                    96d, 
                    96d, 
                    System.Windows.Media.PixelFormats.Default
                    );
                rtb.Render(this);

                // --

                pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(rtb));

                // --

                using (var stream = new System.IO.MemoryStream())
                {
                    pngBitmapEncoder.Save(stream);
                    stream.Seek(0, System.IO.SeekOrigin.Begin);
                    bitmapImage = new System.Drawing.Bitmap(stream);
                    stream.Close();
                }

                // --

                return bitmapImage;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                rtb = null;
                bitmapImage = null;
                pngBitmapEncoder = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void activateFlowCtrl(
            object sender,
            FIFlowCtrl fFlowCtrl
            )
        {
            try
            {
                if (FlowCtrlActivated != null)
                {
                    FlowCtrlActivated(sender, new FFlowCtrlActivatedEventArgs(fFlowCtrl));
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

        public DragDropEffects doDragDrop(
            object data, 
            DragDropEffects allowedEffects
            )
        {
            try
            {
                return DragDrop.DoDragDrop(this, data, allowedEffects);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return DragDropEffects.None;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FFlowContainer Event Handler

        private void fFlowContainer_SizeChanged(
            object sender,
            System.Windows.SizeChangedEventArgs e
            )
        {
            const double BlockSize = 70.0;
            double middlePosition = 0.0;
            double eapLeftMargin = 0.0;
            double hostLeftMargin = 0.0;

            try
            {
                middlePosition = e.NewSize.Width / 2;
                eapLeftMargin = middlePosition - (BlockSize / 2) - 8;
                hostLeftMargin = e.NewSize.Width - BlockSize - 5;

                // -- 

                if (eapLeftMargin < 3)
                {
                    eapLeftMargin = 3;
                }

                if (hostLeftMargin < 3)
                {
                    hostLeftMargin = 3;
                }

                // -- 

                middlePosition = e.NewSize.Width / 2;
                eqBlock.Margin = new Thickness(3, 5, 0, 0);
                eapBlock.Margin = new Thickness(eapLeftMargin, 5, 0, 0);
                hostBlock.Margin = new Thickness(hostLeftMargin, 5, 0, 0);
                // --
                m_eqLine.Margin = new Thickness(3, 0, 0, 0);
                m_eapLine.Margin = new Thickness(eapLeftMargin, 0, 0, 0);
                m_hostLine.Margin = new Thickness(hostLeftMargin, 0, 0, 0);

                m_flowBody.Height = bodyContainer.ActualHeight;
                m_flowBody.Width = bodyContainer.ActualWidth;

                // -- 

                applyWindowSize();
                refreshFlowContainer();
            }
            catch(Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Flow Base Event Handler

        private void flowBase_MouseDown(
            object sender,
            System.Windows.Input.MouseButtonEventArgs e
            )
        {
            try
            {
                this.activateFlowContainer();
                m_flowBody.UnselectAll();

                // -- 

                if (
                    popupMenu != null &&
                    e.RightButton == System.Windows.Input.MouseButtonState.Pressed
                    )
                {
                    popupMenu.ShowPopup();
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

        #region Flow Body Event Handler

        private void flowBody_SelectionChanged(
            object sender,
            SelectionChangedEventArgs e
            )
        {
            try
            {
                if (e.AddedItems.Count != 1)
                {
                    m_fActiveFlowCtrl = null;
                    return;
                }

                // -- 

                if (m_fActiveFlowCtrl != null)
                {
                    m_fActiveFlowCtrl.panel.Style = deactivateFlowCtrlStyle;
                }

                // -- 

                m_fActiveFlowCtrl = e.AddedItems[0] as FIFlowCtrl;

                // -- 

                if (m_fActiveFlowCtrl.panel != null)
                {
                    m_fActiveFlowCtrl.panel.Style = activateFlowCtrlStyle;
                }

                // -- 

                if (FlowCtrlActivated != null)
                {
                    FlowCtrlActivated(this, new FFlowCtrlActivatedEventArgs(m_fActiveFlowCtrl));
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

        private void flowBody_PreviewMouseLeftButtonDown(
            object sender,
            System.Windows.Input.MouseButtonEventArgs e
            )
        {
            FIFlowCtrl fFlowCtrl = null;

            try
            {                
                m_oldIndex = this.getCurrentIndex(e.GetPosition);

                if (m_oldIndex < 0)
                {
                    return;
                }
                
                // --

                fFlowCtrl = this.m_flowBody.Items[m_oldIndex] as FIFlowCtrl;

                if (fFlowCtrl == null)
                {
                    return;
                }

                // --

                DragDrop.DoDragDrop(this.m_flowBody, fFlowCtrl, DragDropEffects.Move | DragDropEffects.Copy);

                fFlowCtrl.panel.Style = activateFlowCtrlStyle;

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

        private void flowBody_PreviewDragEnter(
            object sender,
            DragEventArgs e
            )
        {
            ItemsControl itemsControl = null;

            try
            {
                if (
                    !this.isFlowCtrl(e.Data as DataObject) && 
                    !e.Data.GetDataPresent(typeof(FToolboxItem))
                    )
                {
                    e.Effects = DragDropEffects.None;
                }
                else
                {
                    itemsControl = sender as ItemsControl;
                    // -- 
                    this.initDragAdorner(itemsControl, e);
                    this.initInsertAdorner(itemsControl, e);
                }
                
                // -- 
                
                e.Handled = true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                itemsControl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void flowBody_PreviewDragLeave(
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

        private void flowBody_PreviewDragOver(
            object sender,
            DragEventArgs e
            )
        {
            ItemsControl itemsControl = null;

            try
            {
                if (!this.isFlowCtrl(e.Data as DataObject) &&
                    !e.Data.GetDataPresent(typeof(FToolboxItem))
                    )
                {
                    e.Effects = DragDropEffects.None;
                    e.Handled = true;
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
                itemsControl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void flowBody_PreviewDrop(
            object sender,
            DragEventArgs e
            )
        {
            int index = -1;
            ItemsControl itemsControl = null;
            FIFlowCtrl fFlowCtrl = null;
            FFlowCtrlType fFlowCtrlType = FFlowCtrlType.Branch;
            
            try
            {
                detachAdorners();

                // -- 

                if (
                    !e.Data.GetDataPresent(typeof(FToolboxItem)) &&
                    !isFlowCtrl(e.Data as DataObject)
                    )
                {
                    return;
                }
                 
                // -- 

                itemsControl = sender as ItemsControl;
                index = findInsertIndex(itemsControl, e);

                // -- 

                if (e.Data.GetDataPresent(typeof(FToolboxItem)))
                {
                    fFlowCtrlType = ((FToolboxItem)e.Data.GetData(typeof(FToolboxItem))).fFlowCtrlType;

                    if (FlowCtrlDropped != null)
                    {
                        FlowCtrlDropped(this, new FFlowCtrlDroppedEventArgs(fFlowCtrlType, index));
                    }
                }
                else
                {
                    fFlowItems.RemoveAt(m_oldIndex);
                    fFlowCtrl = convertFlowCtrlToDataObject(e.Data as DataObject);

                    // --

                    if (index > 0 && m_oldIndex < index)
                    {
                        index -= 1;
                    }

                    // -- 

                    insertFlowCtrl(fFlowCtrl, index);
                }

                // --
                
                resetState();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                itemsControl = null;
                fFlowCtrl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_flowBody_MouseMove(
            object sender, 
            System.Windows.Input.MouseEventArgs e
            )
        {   
            System.Windows.Forms.MouseButtons mb = System.Windows.Forms.MouseButtons.None;
            FIFlowCtrl fFlowCtrl = null;
            int index = 0;

            try
            {
                if (FlowMouseMove == null)
                {
                    return;
                }

                // --

                if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                {
                    mb = System.Windows.Forms.MouseButtons.Left;
                }
                else if (e.RightButton == System.Windows.Input.MouseButtonState.Pressed)
                {
                    mb = System.Windows.Forms.MouseButtons.Right;
                }
                else if (e.MiddleButton == System.Windows.Input.MouseButtonState.Pressed)
                {
                    mb = System.Windows.Forms.MouseButtons.Middle;
                }
                else
                {
                    mb = System.Windows.Forms.MouseButtons.None;
                }
                
                // --

                index = this.getCurrentIndex(e.GetPosition);
                if (index >= 0)
                {
                    fFlowCtrl = this.m_flowBody.Items[index] as FIFlowCtrl;
                }

                // --

                FlowMouseMove(this, new FFlowMouseEventArgs(mb, fFlowCtrl));       
         
                // --

                e.Handled = true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fFlowCtrl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_flowBody_DragOver(
            object sender, 
            DragEventArgs e
            )
        {
            FIFlowCtrl fRefFlowCtrl = null;
            int index = 0;
            FFlowDragEventArgs eventArgs = null;

            try
            {
                if (FlowDragOver == null)
                {
                    return;
                }          
      
                // --

                index = this.getCurrentIndex(e.GetPosition);
                if (index >= 0)
                {
                    fRefFlowCtrl = this.m_flowBody.Items[index] as FIFlowCtrl;
                }

                // --

                eventArgs = new FFlowDragEventArgs(e.AllowedEffects, e.Data, fRefFlowCtrl);
                FlowDragOver(this, eventArgs);

                // --
                
                e.Effects = eventArgs.effect;
                m_dragDropEffect = eventArgs.effect;

                // --

                e.Handled = true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fRefFlowCtrl = null;
                eventArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_flowBody_Drop(
            object sender, 
            DragEventArgs e
            )
        {
            FIFlowCtrl fRefFlowCtrl = null;
            int index = 0;
            FFlowDragEventArgs eventArgs = null;

            try
            {
                if (FlowDragDrop == null)
                {
                    return;
                }

                // --

                index = this.getCurrentIndex(e.GetPosition);
                if (index >= 0)
                {
                    fRefFlowCtrl = this.m_flowBody.Items[index] as FIFlowCtrl;
                }

                // --

                eventArgs = new FFlowDragEventArgs(m_dragDropEffect, e.Data, fRefFlowCtrl);
                FlowDragDrop(this, eventArgs);
                m_dragDropEffect = DragDropEffects.None;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fRefFlowCtrl = null;
                eventArgs = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
    
    } // Class end
} // Namespace end