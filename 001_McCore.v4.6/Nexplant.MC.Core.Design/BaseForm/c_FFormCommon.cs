/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FFormCommon.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.17
--  Description     : FAMate Core FaUIs Form Common Function Class
--  History         : Created by spike.lee at 2011.01.17
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    internal static class FFormCommon
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        static FFormCommon(
            )
        {

        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods   
     
        public static void paintDialogAreaBar(
            Color backColor,
            Control client
            )
        {

            Rectangle rect;
            Graphics g = null;
            Brush brush = null;
            Pen pen = null;
            Font font = null;

            try
            {
                client.SuspendLayout();

                // --

                rect = client.ClientRectangle;
                if (rect.Width <= 0)
                {
                    return;
                }

                // --

                g = client.CreateGraphics();
                rect = new Rectangle(rect.X + 4, rect.Height - 50, rect.Width - 6, 14);

                // --

                using (BufferedGraphics bGraphic = BufferedGraphicsManager.Current.Allocate(g, rect))
                {
                    bGraphic.Graphics.Clear(backColor);
                    bGraphic.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    bGraphic.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    // --

                    pen = new Pen(Color.LightSteelBlue, 2);
                    brush = new SolidBrush(Color.SteelBlue);
                    font = new Font(client.Font.Name, 7, FontStyle.Bold);
                    // --                    
                    bGraphic.Graphics.DrawLine(pen, 75, rect.Y + 7, rect.Width + 4, rect.Y + 7);
                    bGraphic.Graphics.DrawString("Nexplant MC", font, brush, 6, rect.Y);

                    // --

                    bGraphic.Render(g);

                    // --

                    g.Dispose();
                    g = null;
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (g != null)
                {
                    g.Dispose();
                    g = null;
                }

                if (brush != null)
                {
                    brush.Dispose();
                    brush = null;
                }

                if (pen != null)
                {
                    pen.Dispose();
                    pen = null;
                }

                if (font != null)
                {
                    font.Dispose();
                    font = null;
                }

                client.ResumeLayout();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void dockDialogClientArea(
            Control client, 
            Panel dialogClient
            )
        {
            try
            {
                dialogClient.Left = 3;
                dialogClient.Top = 2;
                dialogClient.Width = client.ClientRectangle.Width - 5;
                dialogClient.Height = client.ClientRectangle.Height - 53;
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
