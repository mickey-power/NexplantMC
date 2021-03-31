/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagFAM.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.28
--  Description     : FAMate Core FaSecsDriver FAMate XML Tag Definition Class 
--  History         : Created by spike.lee at 2011.01.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal static class FXmlTagFAM
    {
        
        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // FAMate Element and Attribute 
        // ***
        public const string E_FAMate = "FAM";
        // --
        public const string A_FileFormat = "FFT";
        public const string A_FileVersion = "FVR";
        public const string A_FileCreationTime = "FCT";
        public const string A_FileUpdateTime = "FUT";
        public const string A_FileDescription = "FDE";
        public const string A_UniqueIdPointer = "UIP";
        // --
        public const string D_FileFormat = "";
        public const string D_FileVersion = "";
        public const string D_FileCreationTime = "";
        public const string D_FileUpdateTime = "";
        public const string D_FileDescription = "";
        public const string D_UniqueIdPointer = "0";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
