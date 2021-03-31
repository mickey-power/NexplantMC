/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FCallbackFlow.cs
--  Creator         : spike.lee
--  Create Date     : 2011.07.22
--  Description     : FAMate Core FaUIs Callback Flow Control
--  History         : Created by spike.lee at 2011.07.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs.WPF
{
    public partial class FCallbackFlow : FBaseFlowCtrl, FIFlowCtrl
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_key = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FCallbackFlow(
            )
            : this(Nexplant.MC.Core.Properties.Resources.not_defined)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FCallbackFlow(
            Image image
            )
            : base("CallbackFlow", image)
        {
            InitializeComponent();
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FCallbackFlow(
            string key
            )
            : this(Nexplant.MC.Core.Properties.Resources.not_defined)
        {
            m_key = key;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FCallbackFlow(
            string key,
            Image image
            )
            : this(image)
        {
            m_key = key;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FCallbackFlow(
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
                    return FFlowCtrlType.Callback;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FFlowCtrlType.Callback;
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
                System.Windows.Shapes.Line upperLine = null;
                System.Windows.Shapes.Line lowerLine = null;
                System.Windows.Style oldStyle = null;

                try
                {
                    applyWindowSize();

                    // --

                    flowCanvas = new System.Windows.Controls.Canvas();
                    upperLine = new System.Windows.Shapes.Line();
                    lowerLine = new System.Windows.Shapes.Line();
                    // --
                    upperLine.Stroke = System.Windows.Media.Brushes.Olive;
                    upperLine.StrokeThickness = strokeThickness;
                    upperLine.X1 = leftCenter;
                    upperLine.Y1 = verticalMargin + additionalY;
                    upperLine.X2 = rightCenter;
                    upperLine.Y2 = verticalMargin + additionalY;
                    flowCanvas.Children.Add(upperLine);
                    // --
                    lowerLine.Stroke = System.Windows.Media.Brushes.Olive;
                    lowerLine.StrokeThickness = strokeThickness;
                    lowerLine.X1 = leftCenter;
                    lowerLine.Y1 = height - verticalMargin - additionalY;
                    lowerLine.X2 = rightCenter;
                    lowerLine.Y2 = height - verticalMargin - additionalY;
                    flowCanvas.Children.Add(lowerLine);
                    // --

                    oldStyle = panel.Style;
                    panel.MouseDown -= FBaseFlowCtrl_MouseDown;
                    // --
                    panel = drawImageAndText(FFlowCtrlType.Callback, text);
                    panel.Style = oldStyle;
                    panel.MouseDown += FBaseFlowCtrl_MouseDown;

                    // -- 

                    flowCanvas.Children.Add(eqBaseLine);
                    flowCanvas.Children.Add(eapBaseLine);
                    flowCanvas.Children.Add(hostBaseLine);
                    flowCanvas.Children.Add(fillSymbol);
                    flowCanvas.Children.Add(panel);

                    // -- 

                    System.Windows.Controls.Canvas.SetZIndex(upperLine, 100);
                    System.Windows.Controls.Canvas.SetZIndex(lowerLine, 100);
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
