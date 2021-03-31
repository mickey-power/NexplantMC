/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : i_FIPreconditionValueCollection.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.15
--  Description     : FAMate Core FaOpcDriver Precondition Value Collection Interface
--  History         : Created by Jeff.Kim at 2013.07.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public interface FIPreconditionValueCollection : FIEnumerable
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        string this[int i]
        {
            get;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        string getStringValue(
            int index
            );

        //------------------------------------------------------------------------------------------------------------------------

        object getValue(
            int index
            );

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Interface end
}   // Class end
