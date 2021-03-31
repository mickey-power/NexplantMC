/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : Program.cs
--  Creator         : spike.lee
--  Create Date     : 2012.11.30
--  Description     : FAMate Admin Service Container Program (주 진입점) Class 
--  History         : Created by spike.lee at 2012.11.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Miracom.FAMate.Core.FaCommon;

namespace Miracom.FAMate.SqlServiceContainer
{
    static class Program
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Comments
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        #endregion
        [STAThread]
        static void Main()
        {
            FSqsContainer fAdsContainer = null;

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // --

                fAdsContainer = new FSqsContainer();
                Application.Run(fAdsContainer);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                if (fAdsContainer != null)
                {
                    fAdsContainer.Dispose();
                    fAdsContainer = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
