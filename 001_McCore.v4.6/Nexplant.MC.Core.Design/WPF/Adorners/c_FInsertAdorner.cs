/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FInsertAdorner.cs
--  Creator         : byjeon
--  Create Date     : 2012.09.28
--  Description     : FAMate Core FaUIs WPF Insert Adorner Class
--  History         : Created by byjeon at 2012.09.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs.WPF
{
    public class FInsertAdorner : Adorner, IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private bool m_isTopHalf = false;
        private System.Windows.Media.Pen m_pen;
        // -- 
        private AdornerLayer m_adornerLayer = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Contruction and Destruction

        public FInsertAdorner(
            System.Windows.UIElement adornedElement,
            bool isTopHalf,
            AdornerLayer adornerLayer
            )
            : base(adornedElement)
        {
            m_isTopHalf = isTopHalf;
            m_adornerLayer = adornerLayer;
            m_adornerLayer.Add(this);

            // -- 

            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FInsertAdorner(
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

        public bool isTopHalf
        {
            get
            {
                try
                {
                    return m_isTopHalf;
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
                    m_isTopHalf = value;
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

        public void init(
            )
        {
            DoubleAnimation animation = null;

            try
            {
                m_pen = new System.Windows.Media.Pen(new SolidColorBrush(Colors.Black), 1.0);
                // --
                animation = new DoubleAnimation(0.5, 1, new Duration(TimeSpan.FromSeconds(3)));
                animation.AutoReverse = true;
                animation.RepeatBehavior = RepeatBehavior.Forever;
                // --
                m_pen.Brush.BeginAnimation(Brush.OpacityProperty, animation);
            }
            catch(Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

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
            double width = 0, height = 0;
            System.Windows.Point startPoint, endPoint;

            try
            {
                width = this.AdornedElement.RenderSize.Width;
                height = this.AdornedElement.RenderSize.Height;

                // --

                if (!this.isTopHalf)
                {
                    startPoint = new System.Windows.Point(0, height);
                    endPoint = new System.Windows.Point(width, height);
                }
                else
                {
                    startPoint = new System.Windows.Point(0, 0);
                    endPoint = new System.Windows.Point(width, 0);
                }

                // --

                drawingContext.DrawLine(m_pen, startPoint, endPoint);
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