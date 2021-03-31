/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : Program.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.10
--  Description     : Nexplant MC Counter Program (주 진입점) Class 
--  History         : Created by mjkim at 2019.09.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;

namespace Nexplant.MC.Counter
{
    static class Program
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        [STAThread]
        static void Main(
            )
        {
            FCntCore fCntCore = null;

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                // --
                fCntCore = new FCntCore();
                Application.Run(fCntCore.fMainContainer);

                // --

                if (fCntCore != null)
                {
                    fCntCore.Dispose();
                    fCntCore = null;
                }
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(null, ex.Message); 
            }
            finally
            {
                if (fCntCore != null)
                {
                    fCntCore.Dispose();
                    fCntCore = null;
                }
            }           
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // class end
}   // Namespace end
