/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FConstants.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.28
--  Description     : FAMate Workspace Manager Constants Definition Class 
--  History         : Created by spike.lee at 2010.12.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.WorkspaceManager
{
    public static class FConstants
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string ApplicationName = "Nexplant MC Workspace Manager v4.6";

        // --

        // ***
        // Recent - Gen & Modeling Library & Log File Max Count
        // ***
        public const int RecentMaxCount = 10;

        // --

        public const string StationSessionID = "WSM";
        public const string StationVersion = "4.6";
        public const int GuaranteedTimeout = 86400000;

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
