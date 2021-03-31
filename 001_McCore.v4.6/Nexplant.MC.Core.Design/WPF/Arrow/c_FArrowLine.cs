using System;
using System.Windows;
/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FArrowLine.cs
--  Creator         : byjeon
--  Create Date     : 2012.09.27
--  Description     : FAMate Core FaUIs WPF Arrow Line Class
--  History         : Created by byjeon at 2012.09.27
----------------------------------------------------------------------------------------------------------*/
using System.Windows.Media;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs.WPF
{
    public class FArrowLine : FArrowLineBase, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FArrowLine(
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FArrowLine(
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
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Dependency Property

        public static readonly DependencyProperty X1Property =
            DependencyProperty.Register(
                "X1",
                typeof(double),
                typeof(FArrowLine),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure)
                );

        //------------------------------------------------------------------------------------------------------------------------

        public double X1
        {
            set
            {
                try
                {
                    SetValue(X1Property, value); 
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
                    return (double)GetValue(X1Property); 
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

        public static readonly DependencyProperty Y1Property =
            DependencyProperty.Register(
                "Y1",
                typeof(double),
                typeof(FArrowLine),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure)
                );

        //------------------------------------------------------------------------------------------------------------------------

        public double Y1
        {
            set
            {
                try
                {
                    SetValue(Y1Property, value); 
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
                    return (double)GetValue(Y1Property); 
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

        public static readonly DependencyProperty X2Property =
            DependencyProperty.Register(
                "X2",
                typeof(double),
                typeof(FArrowLine),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure)
                );

        //------------------------------------------------------------------------------------------------------------------------

        public double X2
        {
            set
            {
                try
                {
                    SetValue(X2Property, value); 
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
                    return (double)GetValue(X2Property); 
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

        public static readonly DependencyProperty Y2Property =
            DependencyProperty.Register(
                "Y2",
                typeof(double),
                typeof(FArrowLine),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure)
                );

        //------------------------------------------------------------------------------------------------------------------------

        public double Y2
        {
            set
            {
                try
                {
                    SetValue(Y2Property, value); 
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
                    return (double)GetValue(Y2Property); 
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods 

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

        protected override Geometry DefiningGeometry
        {
            get
            {
                try
                {
                    // Clear out the PathGeometry.
                    m_pathgeo.Figures.Clear();

                    // Define a single PathFigure with the points.
                    m_pathfigLine.StartPoint = new Point(X1, Y1);
                    m_polysegLine.Points.Clear();
                    m_polysegLine.Points.Add(new Point(X2, Y2));
                    m_pathgeo.Figures.Add(m_pathfigLine);

                    // Call the base property to add arrows on the ends.
                    return base.DefiningGeometry;
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

    } // Class end
} // Namespace end