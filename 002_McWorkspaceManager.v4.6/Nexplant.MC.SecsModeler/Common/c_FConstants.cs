/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FConstants.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.27
--  Description     : FAMate SECS Modeler Constants Definition Class 
--  History         : Created by spike.lee at 2011.01.27
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.SecsModeler
{
    public static class FConstants
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string ApplicationName = "Nexplant MC SECS Modeler v4.6";

        // --

        public const string ComFileFilter = "DLL (*.dll)|*.dll";

        // ***
        // Tracer (SECS Binary Tracer, SML Tracer, VFEI Tracer) 계열 Trace Count 상한값, 하한값
        // ***
        public const int TraceMaxCount = 999;
        public const int TraceMinCount = 1;

        // ***
        // Trace (SECS Binary Tracer, SML Tracer, VFEI Tracer) 계열과 Viewer (SML Viewer, VFEI Viewer) 계열 Font Size 상한값, 하한값
        // ***
        public const int FontMaxSize = 72;
        public const int FontMinSize = 8;

        // --

        // ***
        // Recent - SECS Modeling Library & Log File Max Count
        // ***
        public const int RecentMaxCount = 10;

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
