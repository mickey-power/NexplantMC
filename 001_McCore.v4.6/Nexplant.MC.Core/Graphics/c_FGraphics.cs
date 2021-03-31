/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FGraphics.cs
--  Creator         : spike.lee
--  Create Date     : 2010.11.26
--  Description     : FAMate Core FaCommon Graphic Common Function Class
--  History         : Created by spike.lee at 2010.11.26
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Nexplant.MC.Core.FaCommon
{
    public static class FGraphics
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        static FGraphics(
            )
        {

        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static GraphicsPath calculateGraphicsPath(
            Bitmap bitmap,
            int startX,
            int startY
            )
        {
            GraphicsPath gp = null;
            Color color;
            int opCol = 0;
            int nextCol = 0;

            try
            {
                gp = new GraphicsPath();

                //
                // Bitmap에서 제외될 Color를 설정한다.
                // (첫번째 Pixel)
                //
                color = bitmap.GetPixel(0, 0);

                //
                // Row colculate
                //
                for (int row = 0; row < bitmap.Height; row++)
                {
                    opCol = 0;

                    //
                    // Column colculate
                    //
                    for (int col = 0; col < bitmap.Width; col++)
                    {
                        if (bitmap.GetPixel(col, row) != color)
                        {
                            opCol = col;
                            for (nextCol = opCol; nextCol < bitmap.Width; nextCol++)
                            {
                                if (bitmap.GetPixel(nextCol, row) == color)
                                    break;
                            }

                            gp.AddRectangle(new Rectangle(opCol + startX, row + startY, nextCol - opCol, 1));
                            col = nextCol;
                        }
                    }   // Column
                }   // Row

                return gp;
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

        public static GraphicsPath calculateGraphicsPath(
            Bitmap bitmap
            )
        {
            try
            {
                //
                // Start Position를 (0,0)으로 지정하여 영역을 계산한다.
                //
                return calculateGraphicsPath(bitmap, 0, 0);
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
    
    }   // Class end
}   // Namespace end
