/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FBaseFlowCtrl.cs
--  Creator         : byjeon
--  Create Date     : 2011.06.02
--  Description     : FAMate Core FaUIs WPF Base Flow Control
--  History         : Created by spike.lee at 2011.06.02
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs.WPF
{
    public partial class FBaseFlowCtrl : System.Windows.Controls.UserControl
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_text = "BaseFlowCtrl";
        private FFlowContainer m_fParent = null;
        private Color m_fontColor = Color.Black;
        private Image m_image = null;
        private bool m_fontBold = false;
        // --
        private System.Windows.Controls.StackPanel m_panel = null;
    
        // -- 

        private double m_width = 0.0;
        private double m_height = 0.0;
        // --
        private double m_horizontalMargin = 0.0;
        private double m_verticalMargin = 0.0;
        private double m_additionalX = 0.0;
        private double m_additionalY = 0.0;
        // --
        private double m_middlePosition = 0.0;
        private double m_eqPosition = 0.0;
        private double m_eapPosition = 0.0;
        private double m_hostPosition = 0.0;
        // --
        private double m_leftCenter = 0.0;
        private double m_rightCenter = 0.0;
        // -- 
        private double m_strokeThickness = 2;
        private System.Windows.Media.SolidColorBrush m_defaultBgColor = System.Windows.Media.Brushes.WhiteSmoke;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FBaseFlowCtrl(
            )
        {
            InitializeComponent();
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FBaseFlowCtrl(
            string text,
            Image image
            )
            : this()
        {
            m_text = text;
            m_image = image;
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void myDispose(
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

        #region Properties

        public string text
        {
            get
            {
                try
                {
                    return m_text;
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
                    m_text = value;
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

        public Image image
        {
            get
            {
                try
                {
                    return m_image;
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

            set
            {
                try
                {
                    m_image = value;
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

        public Color fontColor
        {
            get
            {
                try
                {
                    return m_fontColor;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return Color.Black;
            }

            set
            {
                try
                {
                    m_fontColor = value;
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
                    return m_fontBold;
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
                    m_fontBold = value;
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

        public System.Windows.Controls.StackPanel panel
        {
            get
            {
                try
                {
                    return m_panel;
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

            set
            {
                try
                {
                    m_panel = value;
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

        public bool isActive
        {
            get
            {
                try
                {
                    if (m_fParent != null && m_fParent.fActiveFlowCtrl == this)
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

        internal System.Windows.Shapes.Line eqBaseLine
        {
            get
            {
                try
                {
                    return
                        new System.Windows.Shapes.Line(
                            )
                        {
                            Stroke = System.Windows.Media.Brushes.Gray,
                            StrokeThickness = m_strokeThickness,
                            X1 = m_eqPosition,
                            Y1 = 0,
                            X2 = m_eqPosition,
                            Y2 = m_height
                        };
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

        internal System.Windows.Shapes.Line eapBaseLine
        {
            get
            {
                try
                {
                    return
                        new System.Windows.Shapes.Line(
                            )
                        {
                            Stroke = System.Windows.Media.Brushes.Gray,
                            StrokeThickness = m_strokeThickness,
                            X1 = m_eapPosition,
                            Y1 = 0,
                            X2 = m_eapPosition,
                            Y2 = m_height
                        };
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

        internal System.Windows.Shapes.Line hostBaseLine
        {
            get
            {
                try
                {
                    return
                        new System.Windows.Shapes.Line(
                            )
                        {
                            Stroke = System.Windows.Media.Brushes.Gray,
                            StrokeThickness = m_strokeThickness,
                            X1 = m_hostPosition,
                            Y1 = 0,
                            X2 = m_hostPosition,
                            Y2 = m_height
                        };
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

        public FFlowContainer fParent
        {
            get
            {
                try
                {
                    return m_fParent;
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

            set
            {
                try
                {
                    m_fParent = value;
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

        public FIFlowCtrl fPreviousSibling
        {
            get
            {
                try
                {
                    if (fParent == null)
                    {
                        return null;
                    }

                    return (FIFlowCtrl)fParent.getPreviousFlowCtrl(this as FIFlowCtrl);
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

        public FIFlowCtrl fNextSibling
        {
            get
            {
                try
                {
                    if (fParent == null)
                    {
                        return null;
                    }

                    return (FIFlowCtrl)fParent.getNextFlowCtrl(this as FIFlowCtrl);
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

        public double width
        {
            get
            {
                try
                {
                    return m_width;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0.0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public double height
        {
            get
            {
                try
                {
                    return m_height;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0.0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public double horizontalMargin
        {
            get
            {
                try
                {
                    return m_horizontalMargin;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0.0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public double verticalMargin
        {
            get
            {
                try
                {
                    return m_verticalMargin;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0.0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public double additionalX
        {
            get
            {
                try
                {
                    return m_additionalX;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0.0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public double additionalY
        {
            get
            {
                try
                {
                    return m_additionalY;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0.0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public double middlePosition
        {
            get
            {
                try
                {
                    return m_middlePosition;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0.0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public double eqPosition
        {
            get
            {
                try
                {
                    return m_eqPosition;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0.0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public double eapPosition
        {
            get
            {
                try
                {
                    return m_eapPosition;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0.0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public double hostPosition
        {
            get
            {
                try
                {
                    return m_hostPosition;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0.0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public double leftCenter
        {
            get
            {
                try
                {
                    return m_leftCenter;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0.0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public double rightCenter
        {
            get
            {
                try
                {
                    return m_rightCenter;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0.0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public double strokeThickness
        {
            get
            {
                try
                {
                    return m_strokeThickness;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public System.Windows.Media.SolidColorBrush defaultBgColor
        {
            get
            {
                try
                {
                    return m_defaultBgColor;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return System.Windows.Media.Brushes.WhiteSmoke;
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

        internal void applyWindowSize(
            )
        {
            double eqPosition = 0.0;
            double eapPosition = 0.0;
            double hostPosition = 0.0;

            try
            {
                if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 1) // Windows 7
                {
                    eqPosition = 37;
                    eapPosition = this.fParent.ActualWidth / 2 - 9;
                    hostPosition = this.fParent.ActualWidth - 41;
                }
                else
                {
                    eqPosition = 34;
                    eapPosition = this.fParent.ActualWidth / 2 - 12;
                    hostPosition = this.fParent.ActualWidth - 44;
                }

                // --

                m_width = this.fParent.ActualWidth;
                m_height = 36;
                // --
                m_horizontalMargin = 30;
                m_verticalMargin = 3;
                m_additionalX = 10;
                m_additionalY = 4;
                // --
                m_middlePosition = m_height / 2;
                // --
                m_eqPosition = eqPosition;
                m_eapPosition = (eapPosition > m_eqPosition) ? eapPosition : m_eqPosition;
                m_hostPosition = (hostPosition > m_eapPosition) ? hostPosition : m_eapPosition;
                // -- 
                m_leftCenter = (m_eqPosition + m_eapPosition) / 2;
                m_rightCenter = (m_eapPosition + m_hostPosition) / 2;
                // -- 
                m_strokeThickness = 2;
                m_defaultBgColor = System.Windows.Media.Brushes.WhiteSmoke;
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
        
        internal System.Windows.Controls.StackPanel drawImageAndText(
            FFlowCtrlType fFlowCtrlType,            
            string text
            )
        {
            double startX = 0.0, startY = 0.0;
            double textWidth = 0.0;
            System.Windows.Controls.Image wpfImage = null;
            System.Windows.Controls.TextBlock textBlock = null;
            System.Windows.Controls.StackPanel stackPanel = null;

            try
            {
                wpfImage = FCommon.bindImageFromGdiImage(this.image);
                wpfImage.Margin = new System.Windows.Thickness(4, 0, 0, 0);
                // -- 
                textBlock = new System.Windows.Controls.TextBlock();
                textBlock.Margin = new System.Windows.Thickness(4, 0, 0, 0);                

                // -- 

                if (
                    fFlowCtrlType == FFlowCtrlType.SecsTransmitter ||
                    fFlowCtrlType == FFlowCtrlType.SecsTrigger ||
                    fFlowCtrlType == FFlowCtrlType.PlcTransmitter ||
                    fFlowCtrlType == FFlowCtrlType.PlcTrigger ||
                    fFlowCtrlType == FFlowCtrlType.OpcTransmitter ||
                    fFlowCtrlType == FFlowCtrlType.OpcTrigger ||
                    fFlowCtrlType == FFlowCtrlType.TcpTransmitter ||
                    fFlowCtrlType == FFlowCtrlType.TcpTrigger

                    )
                {
                    startX = m_eqPosition + 12;
                    startY = m_verticalMargin + m_additionalY + 1;
                    textWidth = m_eapPosition - m_eqPosition - 47;
                    if (textWidth > 0)
                    {
                        textBlock.Width = textWidth;
                    }
                }
                else if (
                    fFlowCtrlType == FFlowCtrlType.HostTransmitter ||
                    fFlowCtrlType == FFlowCtrlType.HostTrigger
                    )
                {
                    startX = m_eapPosition + 12;
                    startY = m_verticalMargin + m_additionalY + 1;
                    textWidth = m_hostPosition - m_eapPosition - 47;
                    if (textWidth > 0)
                    {
                        textBlock.Width = textWidth;
                    }
                }
                else
                {
                    startX = m_leftCenter + 15;
                    startY = m_verticalMargin + m_additionalY + 3;
                    textWidth = m_rightCenter - m_leftCenter - 51;
                    if (textWidth > 0)
                    {
                        textBlock.Width = textWidth;
                    }
                }
                textBlock.Text = adjustTextForWidth(text, textBlock);

                // -- 
               
                stackPanel = new System.Windows.Controls.StackPanel()
                {
                    Orientation = System.Windows.Controls.Orientation.Horizontal,
                    Margin = new System.Windows.Thickness(startX, startY, 0, 0)
                };
                
                // --

                if (fontBold)
                {
                    textBlock.FontWeight = System.Windows.FontWeights.Bold;
                }
                textBlock.Foreground = new System.Windows.Media.SolidColorBrush(FCommon.convertWinColorToWpfColor(fontColor));

                stackPanel.Children.Add(wpfImage);
                stackPanel.Children.Add(textBlock);

                // -- 

                return stackPanel;
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

        private string adjustTextForWidth(
            string text,
            System.Windows.Controls.TextBlock textBlock
            )
        {
            int length = 0;
            string resultText = string.Empty;
            System.Windows.Media.Typeface typeface = null;
            System.Windows.Media.FormattedText formattedText = null;

            try
            {
                if (textBlock.Width <= 0)
                {
                    return string.Empty;
                }

                typeface =
                    new System.Windows.Media.Typeface(
                        textBlock.FontFamily,
                        textBlock.FontStyle,
                        textBlock.FontWeight,
                        textBlock.FontStretch
                        );

                // -- 

                resultText = text;
                for (length = text.Length; length >= 0; length--)
                {
                    formattedText =
                        new System.Windows.Media.FormattedText(
                            resultText,
                            textBlock.Language.GetSpecificCulture(),
                            textBlock.FlowDirection,
                            typeface,
                            textBlock.FontSize,
                            textBlock.Foreground
                            );

                    if (formattedText.Width <= textBlock.Width - 12)
                    {
                        break;
                    }
                    else
                    {
                        if (length > 0)
                        {
                            resultText = text.Substring(0, length) + "...";
                        }
                        else
                        {
                            resultText = string.Empty;
                            break;
                        }
                    }
                }
                return resultText;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FBaseFlowCtrl Control Event Handler

        protected void FBaseFlowCtrl_MouseDown(
            object sender,
            System.Windows.Input.MouseButtonEventArgs e
            )
        {
            try
            {
                //if (fParent == null)
                //{
                //    return;
                //}

                // --

                fParent.activateFlowCtrl(this, (FIFlowCtrl)this);

                if (
                    m_fParent.popupMenu != null &&
                    e.RightButton == System.Windows.Input.MouseButtonState.Pressed
                    )
                {
                    if (this.Focusable)
                    {
                        this.Focus();
                    }
                    m_fParent.popupMenu.ShowPopup();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FBaseFlowCtrl", ex, null);
            }
            finally
            {

            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end