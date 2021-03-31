/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FEnvironmentListCollectionEnumerator.cs
--  Creator         : kitae
--  Create Date     : 2011.04.25
--  Description     : FAMate Core FaOpcDriver Evnironment List Collection Enumerator Class
--  History         : Created by kitae at 2011.04.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public class FEnvironmentListCollectionEnumerator : FBaseCollectionEnumerator<FEnvironmentListCollection>
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEnvironmentListCollectionEnumerator(
            FEnvironmentListCollection collection
            )
            : base(collection)
        {

        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
    }   // Class end
}   // Namespace end
