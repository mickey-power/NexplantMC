/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FConstants.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.23
--  Description     : FAmate Converter FaSerialToEthernet Constants Class
--  History         : Created by mjkim at 2019.09.23
----------------------------------------------------------------------------------------------------------*/

namespace Nexplant.MC.Core.FaSerialToEthernet
{
    internal static class FConstants
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Error Message Definition

        #region Comments
        /// <summary>
        /// The {0} is invalid.
        /// </summary>
        #endregion
        public const string err_m_0015 = "The {0} is invalid.";

        #region Comments
        /// <summary>
        /// The {0} does not exist.
        /// </summary>
        #endregion
        public const string err_m_0016 = "The {0} does not exist.";

        #region Comments
        /// <summary>
        /// The {0} is currently open.
        /// </summary>
        #endregion
        public const string err_m_0027 = "The {0} is currently open.";

        #region Comments
        /// <summary>
        /// The {0} is not the SELECTED state.
        /// </summary>
        #endregion
        public const string err_m_0030 = "The {0} is not the CONNECTED state.";

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
