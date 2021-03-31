/*----------------------------------------------------------------------------------------------------------
--  ��� ���α׷��� ���� ���۱��� ������ ���������� (��)�̶��޾��̾ؾ��� ������, (��)�̶��޾��̾ؾ���
--  ��������� ������� ���� ���, ����, ����, ��3�ڿ��� ����, ������ ������ �����Ǹ�, (��)�̶��޾��̾ؾ���
--  �������� ħ�ؿ� �ش�˴ϴ�.
--  (Copyright �� 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FArrowPolyline.cs
--  Creator         : byjeon
--  Create Date     : 2012.09.27
--  Description     : FAMate Core FaUIs WPF Arrow Polyline Class
--  History         : Created by byjeon at 2012.09.27
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows;
using System.Windows.Media;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs.WPF
{
    public class FArrowPolyline : FArrowLineBase, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FArrowPolyline(
            )
        {
            Points = new PointCollection();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FArrowPolyline(
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

        #region Dependency Properties

        public static readonly DependencyProperty PointsProperty =
            DependencyProperty.Register(
                "Points",
                typeof(PointCollection), 
                typeof(FArrowPolyline),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure)
                );

        //------------------------------------------------------------------------------------------------------------------------

        public PointCollection Points
        {
            set
            {
                try
                {
                    SetValue(PointsProperty, value);
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
                    return (PointCollection)GetValue(PointsProperty);
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

        #region Properties

        protected override Geometry DefiningGeometry
        {
            get 
            {
                try
                {
                    // Clear out the PathGeometry.
                    m_pathgeo.Figures.Clear();

                    // -- 

                    // Try to avoid unnecessary indexing exceptions.
                    if (Points.Count > 0)
                    {
                        // Define a PathFigure containing the points.
                        m_pathfigLine.StartPoint = Points[0];
                        m_polysegLine.Points.Clear();

                        for (int i = 1; i < Points.Count; i++)
                        {
                            m_polysegLine.Points.Add(Points[i]);
                        }
                        m_pathgeo.Figures.Add(m_pathfigLine);
                    }

                    // -- 

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

        #region Methods

        private void term(
            )
        {
            try
            {

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

    } // Class end
} // Namespace end