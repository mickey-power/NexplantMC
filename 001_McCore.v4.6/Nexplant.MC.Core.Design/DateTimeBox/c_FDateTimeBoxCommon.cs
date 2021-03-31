/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDateTimeBoxCommon.cs
--  Creator         : mj.kim
--  Create Date     : 2011.09.22
--  Description     : FAMate Core FaUIs DateTimeBox Common Function Class
--  History         : Created by mj.kim at 2011.09.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    internal static class FDateTimeBoxCommon
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        static FDateTimeBoxCommon(
            )
        {

        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public static Appearance stateButtonAppearance
        {
            get
            {
                Appearance appearance = null;

                try
                {
                    appearance = new Appearance();
                    appearance.BackColor = Color.White;
                    appearance.BackGradientStyle = GradientStyle.None;
                    appearance.BorderColor = Color.White;
                    return appearance;
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

        public static Appearance spinButtonAppearance
        {
            get
            {
                Appearance appearance = null;

                try
                {
                    appearance = new Appearance();
                    appearance.BackColor = Color.White;
                    appearance.ForeColor = Color.DimGray;
                    return appearance;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
