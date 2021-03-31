/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : i_FIComponent.cs
--  Creator         : spike.lee
--  Create Date     : 2012.10.05
--  Description     : FAMate Component Interface Component Interface
--  History         : Created by spike.lee at 2012.10.05
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Nexplant.MC.ComponentInterface
{
    public interface FIComponent : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        FISystemFunctionArgs createSystemFunctionArgs(
            object[] args
            );

        //------------------------------------------------------------------------------------------------------------------------

        void callSystemFunction(
            string functionName, 
            FISystemFunctionArgs args
            );

        //------------------------------------------------------------------------------------------------------------------------

        void onRmsReplyCommand(
            string cmd,
            XmlDocument parameter
            );

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Interface end
}   // Namespace end
