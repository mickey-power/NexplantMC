/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FArrowLineBase.cs
--  Creator         : byjeon
--  Create Date     : 2012.09.27
--  Description     : FAMate Core FaUIs WPF Arrow Line Base Class
--  History         : Created by byjeon at 2012.09.27
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs.WPF
{    
    public abstract class FArrowLineBase : Shape, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        protected PathGeometry m_pathgeo;
        protected PathFigure m_pathfigLine;
        protected PolyLineSegment m_polysegLine;
        // --
        private PathFigure m_pathfigHead1;
        private PolyLineSegment m_polysegHead1;
        private PathFigure m_pathfigHead2;
        private PolyLineSegment m_polysegHead2;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FArrowLineBase(
            )
        {
            m_pathgeo = new PathGeometry();

            m_pathfigLine = new PathFigure();
            m_polysegLine = new PolyLineSegment();
            m_pathfigLine.Segments.Add(m_polysegLine);

            m_pathfigHead1 = new PathFigure();
            m_polysegHead1 = new PolyLineSegment();
            m_pathfigHead1.Segments.Add(m_polysegHead1);

            m_pathfigHead2 = new PathFigure();
            m_polysegHead2 = new PolyLineSegment();
            m_pathfigHead2.Segments.Add(m_polysegHead2);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FArrowLineBase(
            )
        {
            myDispose(false);
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
            }
            m_disposed = true;
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

        #region Dependency Property

        public static readonly DependencyProperty ArrowAngleProperty =
            DependencyProperty.Register(
                "ArrowAngle",
                typeof(double), 
                typeof(FArrowLineBase),
                new FrameworkPropertyMetadata(45.0, FrameworkPropertyMetadataOptions.AffectsMeasure)
                );

        //------------------------------------------------------------------------------------------------------------------------

        public double ArrowAngle
        {
            set
            {
                try
                {
                    SetValue(ArrowAngleProperty, value);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                
                }               
            }
            
            get
            {
                try
                {
                    return (double)GetValue(ArrowAngleProperty);
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

        public static readonly DependencyProperty ArrowLengthProperty =
            DependencyProperty.Register(
                "ArrowLength",
                typeof(double), 
                typeof(FArrowLineBase),
                new FrameworkPropertyMetadata(8.0, FrameworkPropertyMetadataOptions.AffectsMeasure)
                );

        //------------------------------------------------------------------------------------------------------------------------

        public double ArrowLength
        {
            set
            {
                try
                {
                    SetValue(ArrowLengthProperty, value);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }                
            }

            get
            {
                try
                {
                    return (double)GetValue(ArrowLengthProperty);
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

        public static readonly DependencyProperty ArrowEndsProperty =
            DependencyProperty.Register("ArrowEnds",
                typeof(FArrowEnds), typeof(FArrowLineBase),
                new FrameworkPropertyMetadata(FArrowEnds.End,
                        FrameworkPropertyMetadataOptions.AffectsMeasure));

        //------------------------------------------------------------------------------------------------------------------------

        public FArrowEnds ArrowEnds
        {
            set
            {
                try
                {
                    SetValue(ArrowEndsProperty, value);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }                
            }

            get
            {
                try
                {
                    return (FArrowEnds)GetValue(ArrowEndsProperty);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FArrowEnds.None;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static readonly DependencyProperty IsArrowClosedProperty =
            DependencyProperty.Register(
                "IsArrowClosed",
                typeof(bool), 
                typeof(FArrowLineBase),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure)
                );

        //------------------------------------------------------------------------------------------------------------------------

        public bool IsArrowClosed
        {
            set
            {
                try
                {
                    SetValue(IsArrowClosedProperty, value);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                
                }               
            }

            get
            {
                try
                {
                    return (bool)GetValue(IsArrowClosedProperty);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        protected override Geometry DefiningGeometry
        {
            get
            {
                int count = 0;
                Point pt1;
                Point pt2;

                try
                {
                    count = m_polysegLine.Points.Count;

                    if (count > 0)
                    {
                        // Draw the arrow at the start of the line.
                        if ((ArrowEnds & FArrowEnds.Start) == FArrowEnds.Start)
                        {
                            pt1 = m_pathfigLine.StartPoint;
                            pt2 = m_polysegLine.Points[0];
                            m_pathgeo.Figures.Add(CalculateArrow(m_pathfigHead1, pt2, pt1));
                        }

                        // Draw the arrow at the end of the line.
                        if ((ArrowEnds & FArrowEnds.End) == FArrowEnds.End)
                        {
                            pt1 = count == 1 ? m_pathfigLine.StartPoint :
                                                     m_polysegLine.Points[count - 2];
                            pt2 = m_polysegLine.Points[count - 1];
                            m_pathgeo.Figures.Add(CalculateArrow(m_pathfigHead2, pt1, pt2));
                        }
                    }
                    return m_pathgeo;
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

        private void term(
            )
        {
            try
            {
                if (m_pathgeo != null)
                {
                    m_pathgeo = null;
                }

                if (m_pathfigLine != null)
                {
                    m_pathfigLine = null;
                }

                if (m_polysegLine != null)
                {
                    m_polysegLine = null;
                }

                if (m_pathfigHead1 != null)
                {
                    m_pathfigHead1 = null;
                }

                if (m_pathfigHead2 != null)
                {
                    m_pathfigHead2 = null;
                }

                if (m_polysegHead1 != null)
                {
                    m_polysegHead1 = null;
                }

                if (m_polysegHead2 != null)
                {
                    m_polysegHead2 = null;
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

        private PathFigure CalculateArrow(
            PathFigure pathFigure,
            Point pt1,
            Point pt2
            )
        {
            Matrix matrix;
            Vector vector;
            PolyLineSegment polyLineSegment = null;

            try
            {
                matrix = new Matrix();
                vector = pt1 - pt2;
                vector.Normalize();
                vector *= ArrowLength;

                polyLineSegment = pathFigure.Segments[0] as PolyLineSegment;
                polyLineSegment.Points.Clear();
                matrix.Rotate(ArrowAngle / 2);
                pathFigure.StartPoint = pt2 + vector * matrix;
                polyLineSegment.Points.Add(pt2);

                matrix.Rotate(-ArrowAngle);
                polyLineSegment.Points.Add(pt2 + vector * matrix);
                pathFigure.IsClosed = IsArrowClosed;

                return pathFigure;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    } // Class end
} // Namespace end