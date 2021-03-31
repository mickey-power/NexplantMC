/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FConstants.cs
--  Creator         : mjkim
--  Create Date     : 2012.10.25
--  Description     : FAMate TCP Modeler Constants Definition Class 
--  History         : Created by mjkim at 2012.10.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.TcpModeler
{
    public static class FConstants
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string ApplicationName = "Nexplant MC TCP Modeler v4.6";

        // ***
        // Tracer (TCP Binary Tracer, VFEI Tracer) 계열 Trace Count 상한값, 하한값
        // ***
        public const int TraceMaxCount = 999;
        public const int TraceMinCount = 1;

        // ***
        // Trace (TCP Binary Tracer, VFEI Tracer) 계열과 Viewer (XLG Viewer, VFEI Viewer) 계열 Font Size 상한값, 하한값
        // ***
        public const int FontMaxSize = 72;
        public const int FontMinSize = 8;

        // --

        // ***
        // Recent - TCP Modeling Library & Log File Max Count
        // ***
        public const int RecentMaxCount = 10;

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
