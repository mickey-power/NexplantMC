/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FConstants.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.10
--  Description     : Nexplant MC Counter Constants Definition Class 
--  History         : Created by mjkim at 2019.09.10
----------------------------------------------------------------------------------------------------------*/

namespace Nexplant.MC.Counter
{
    internal static class FConstants
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string Language = "Default";
        public const string FileFormat = "\\{0}.{1}";
        public const string BackupFileFormat = "{0}_{1}.{2}";   // 날짜(yyyyMMddHHmmssfff) + "_" + BcrName + ".zip";
        public const string ZipFileExtension = "zip";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
