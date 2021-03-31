/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FEntryPointFlow.cs
--  Creator         : mjkim
--  Create Date     : 2014.03.20
--  Description     : FAMate Core FaUIs Entry Point Flow Control
--  History         : Created by mjkim at 2014.03.20
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs.WPF
{
    public partial class FEntryPointFlow : FBaseFlowCtrl, FIFlowCtrl
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_key = string.Empty;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEntryPointFlow(
            )
            : this(Nexplant.MC.Core.Properties.Resources.not_defined)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------
        
        public FEntryPointFlow(
            Image image
            )            
            : base("EntryPointFlow", image)
        {
            InitializeComponent();
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEntryPointFlow(
            string key
            )
            : this(Nexplant.MC.Core.Properties.Resources.not_defined)
        {
            m_key = key;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEntryPointFlow(
            string key,
            Image image
            )
            : this(image)
        {
            m_key = key;            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FEntryPointFlow(
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
                }

                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FFlowCtrlType fFlowCtrlType
        {
            get
            {
                try
                {
                    return FFlowCtrlType.EntryPoint;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FFlowCtrlType.EntryPoint;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string key
        {
            get
            {
                try
                {
                    return m_key;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public System.Windows.Controls.Canvas symbol
        {
            get
            {
                System.Windows.Controls.Canvas flowCanvas = null;
                FArrowPolyline fArrowLine = null;
                System.Windows.Media.RotateTransform xform = null;
                System.Windows.Style oldStyle = null; 

                try
                {
                    applyWindowSize();

                    // --

                    flowCanvas = new System.Windows.Controls.Canvas();
                    fArrowLine = new FArrowPolyline();
                    xform = new System.Windows.Media.RotateTransform();
                    // --
                    fArrowLine.LayoutTransform = xform;
                    fArrowLine.ArrowEnds = FArrowEnds.End;
                    fArrowLine.Stroke = System.Windows.Media.Brushes.Blue;
                    fArrowLine.StrokeThickness = strokeThickness;
                    // --
                    fArrowLine.Points.Add(new System.Windows.Point(leftCenter, verticalMargin + additionalY));
                    fArrowLine.Points.Add(new System.Windows.Point(leftCenter, height - verticalMargin - additionalY));
                    fArrowLine.Points.Add(new System.Windows.Point(rightCenter, height - verticalMargin - additionalY));
                    
                    // --
                    flowCanvas.Children.Add(fArrowLine);

                    // -- 
                    
                    oldStyle = panel.Style;
                    panel.MouseDown -= FBaseFlowCtrl_MouseDown;
                    // -- 
                    panel = drawImageAndText(FFlowCtrlType.EntryPoint, text);
                    panel.Style = oldStyle;
                    panel.MouseDown += FBaseFlowCtrl_MouseDown;
                    
                    // --

                    flowCanvas.Children.Add(eqBaseLine);
                    flowCanvas.Children.Add(eapBaseLine);
                    flowCanvas.Children.Add(hostBaseLine);
                    flowCanvas.Children.Add(fillSymbol);
                    flowCanvas.Children.Add(panel);
                    
                    // --

                    flowCanvas.Background = System.Windows.Media.Brushes.Transparent;

                    // --
                    
                    System.Windows.Controls.Canvas.SetZIndex(fArrowLine, 100);
                    System.Windows.Controls.Canvas.SetZIndex(panel, 101);

                    // -- 

                    return flowCanvas;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    xform = null;
                    fArrowLine = null;
                    flowCanvas = null;
                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private System.Windows.Shapes.Polygon fillSymbol
        {
            get
            {
                System.Windows.Shapes.Polygon polygon = null;
                System.Windows.Media.PointCollection points = null;

                try
                {
                    polygon = new System.Windows.Shapes.Polygon();
                    points = new System.Windows.Media.PointCollection();
                    points.Add(new System.Windows.Point(leftCenter, verticalMargin + additionalY));
                    points.Add(new System.Windows.Point(rightCenter, verticalMargin + additionalY));
                    points.Add(new System.Windows.Point(rightCenter, height - verticalMargin - additionalY));
                    points.Add(new System.Windows.Point(leftCenter, height - verticalMargin - additionalY));
                    polygon.Points = points;
                    polygon.Fill = defaultBgColor;

                    return polygon;
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
                panel = new System.Windows.Controls.StackPanel();
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
                if (panel != null)
                {
                    panel.MouseDown -= FBaseFlowCtrl_MouseDown;
                    panel = null;
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