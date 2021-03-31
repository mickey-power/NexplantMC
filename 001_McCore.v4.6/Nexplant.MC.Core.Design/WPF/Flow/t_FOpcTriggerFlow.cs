/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FOpcTriggerFlow.cs
--  Creator         : duchoi
--  Create Date     : 2013.08.22
--  Description     : FAMate Core FaUIs OPC Trigger Flow Control
--  History         : Created by duchoi at 2013.08.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs.WPF
{
    public partial class FOpcTriggerFlow : FBaseFlowCtrl, FIFlowCtrl
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_key = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOpcTriggerFlow(
            )
            : this(Nexplant.MC.Core.Properties.Resources.not_defined)
        {
            
        }
       
        //------------------------------------------------------------------------------------------------------------------------
        
        public FOpcTriggerFlow(
            Image image
            )
            : base("OpcTriggerFlow", image)
        {
            InitializeComponent();
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcTriggerFlow(
            string key
            )
            : this(Nexplant.MC.Core.Properties.Resources.not_defined)
        {
            m_key = key;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcTriggerFlow(
            string key,
            Image image
            )
            : this(image)
        {
            m_key = key;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOpcTriggerFlow(
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
                    return FFlowCtrlType.OpcTrigger;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FFlowCtrlType.OpcTrigger;
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
                    fArrowLine.Stroke = System.Windows.Media.Brushes.Red;
                    fArrowLine.StrokeThickness = strokeThickness;
                    // --
                    fArrowLine.Points.Add(new System.Windows.Point(eqPosition + 1, height - verticalMargin - additionalY));
                    fArrowLine.Points.Add(new System.Windows.Point(eapPosition - 2, height - verticalMargin - additionalY));
                    // --
                    flowCanvas.Children.Add(fArrowLine);

                    // --

                    oldStyle = panel.Style;
                    panel.MouseDown -= FBaseFlowCtrl_MouseDown;
                    // --
                    panel = drawImageAndText(FFlowCtrlType.OpcTrigger, text);
                    panel.Style = oldStyle;
                    panel.MouseDown += FBaseFlowCtrl_MouseDown;

                    // -- 

                    flowCanvas.Children.Add(eqBaseLine);
                    flowCanvas.Children.Add(eapBaseLine);
                    flowCanvas.Children.Add(hostBaseLine);
                    flowCanvas.Children.Add(panel);

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
