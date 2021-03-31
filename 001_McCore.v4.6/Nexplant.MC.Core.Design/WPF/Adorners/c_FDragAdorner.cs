/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDragAdorner.cs
--  Creator         : byjeon
--  Create Date     : 2012.09.28
--  Description     : FAMate Core FaUIs WPF Drag Adorner Class
--  History         : Created by byjeon at 2012.09.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs.WPF
{
    public class FDragAdorner : Adorner, IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_text = string.Empty;
        private System.Windows.Point m_position;
        // -- 
        private AdornerLayer m_adornerLayer = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Contruction and Destruction

        public FDragAdorner(
            System.Windows.UIElement adornedElement,
            string text,
            AdornerLayer adornerLayer
            )
            : base(adornedElement)
        {
            m_text = text;
            m_adornerLayer = adornerLayer;
            m_adornerLayer.Add(this);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDragAdorner(
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

        public System.Windows.Point position
        {
            get
            {
                try
                {
                    return m_position;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return new System.Windows.Point();
            }

            set
            {
                try
                {
                    m_position = value;
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

        public void destroy(
            )
        {
            try
            {
                m_adornerLayer.Remove(this);
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

        protected override void OnRender(
            System.Windows.Media.DrawingContext drawingContext
            )
        {
            try
            {
                drawingContext.DrawRoundedRectangle(
                    new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(25, 25, 25, 200)),
                    new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black, 1),
                    new System.Windows.Rect(this.position, this.position + new Vector(250, 40)),
                    5, 
                    5
                    );

                drawingContext.DrawText(
                    new System.Windows.Media.FormattedText(this.text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, new Typeface("Verdanda"), 13, Brushes.Black),
                    this.position + new Vector(12, 12)
                    );
   
                base.OnRender(drawingContext);
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