/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FCommentFlow.cs
--  Creator         : spike.lee
--  Create Date     : 2011.11.02
--  Description     : FAMate Core FaUIs Comment Flow Control
--  History         : Created by spike.lee at 2011.11.02
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs.WPF
{
    public partial class FCommentFlow : FBaseFlowCtrl, FIFlowCtrl
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_key = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FCommentFlow(
            )
            : this(Nexplant.MC.Core.Properties.Resources.not_defined)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FCommentFlow(
            Image image
            )
            : base("CommentFlow", image)
        {
            InitializeComponent();
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FCommentFlow(
            string key
            )
            : this(Nexplant.MC.Core.Properties.Resources.not_defined)
        {
            m_key = key;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FCommentFlow(
            string key,
            Image image
            )
            : this(image)
        {
            m_key = key;
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        ~FCommentFlow(
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
                    return FFlowCtrlType.Comment;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FFlowCtrlType.Comment;
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
                System.Windows.Shapes.Line slash1Line = null;
                System.Windows.Shapes.Line slash2Line = null;
                System.Windows.Shapes.Line underLine = null;
                System.Windows.Style oldStyle = null;

                try
                {
                    applyWindowSize();

                    // --

                    flowCanvas = new System.Windows.Controls.Canvas();
                    slash1Line = new System.Windows.Shapes.Line();
                    slash2Line = new System.Windows.Shapes.Line();
                    underLine = new System.Windows.Shapes.Line();
                    // --
                    slash1Line.X1 = leftCenter + additionalX;
                    slash1Line.Y1 = verticalMargin + additionalY;
                    slash1Line.X2 = leftCenter;
                    slash1Line.Y2 = height - verticalMargin - additionalY - 3;
                    slash1Line.Stroke = System.Windows.Media.Brushes.BlueViolet;
                    slash1Line.StrokeThickness = strokeThickness;
                    flowCanvas.Children.Add(slash1Line);
                    // --
                    slash2Line.X1 = slash1Line.X1 + 5;
                    slash2Line.Y1 = slash1Line.Y1;
                    slash2Line.X2 = slash1Line.X2 + 5;
                    slash2Line.Y2 = slash1Line.Y2;
                    slash2Line.Stroke = System.Windows.Media.Brushes.BlueViolet;
                    slash2Line.StrokeThickness = strokeThickness;
                    flowCanvas.Children.Add(slash2Line);
                    // --
                    underLine.X1 = leftCenter;
                    underLine.Y1 = height - verticalMargin - additionalY;
                    underLine.X2 = rightCenter;
                    underLine.Y2 = height - verticalMargin - additionalY;
                    underLine.Stroke = System.Windows.Media.Brushes.BlueViolet;
                    underLine.StrokeThickness = strokeThickness;
                    flowCanvas.Children.Add(underLine);
                    
                    // --
                    
                    oldStyle = panel.Style;
                    panel.MouseDown -= FBaseFlowCtrl_MouseDown;
                    // --
                    panel = drawImageAndText(FFlowCtrlType.Comment, text);
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

                    System.Windows.Controls.Canvas.SetZIndex(slash1Line, 100);
                    System.Windows.Controls.Canvas.SetZIndex(slash2Line, 100);
                    System.Windows.Controls.Canvas.SetZIndex(underLine, 100);
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
