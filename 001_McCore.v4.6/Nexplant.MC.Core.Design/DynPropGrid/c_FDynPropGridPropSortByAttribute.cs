/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDynPropGridPropSortByAttribute.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.28
--  Description     : FAMate Core FaUIs Dynamic Property Grid Property SortBy Attribute Class
--  History         : Created by spike.lee at 2010.12.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public class FDynPropGridPropSortByAttribute : IComparer<FDynPropGridPropDescriptor> 
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public int Compare(
            FDynPropGridPropDescriptor x,
            FDynPropGridPropDescriptor y
            )
        {
            FDynPropGridPropSortAttribute attrx = null;
            FDynPropGridPropSortAttribute attry = null;

            try
            {
                attrx = (FDynPropGridPropSortAttribute)x.getAttribute(typeof(FDynPropGridPropSortAttribute));
                attry = (FDynPropGridPropSortAttribute)y.getAttribute(typeof(FDynPropGridPropSortAttribute));

                if (attrx != null && attry != null)
                {
                    return attrx.position.CompareTo(attry.position);
                }
                else if (attrx != null && attry == null)
                {
                    return 1;
                }
                else if (attrx == null && attry != null)
                {
                    return -1;
                }
                else
                {
                    return x.Name.CompareTo(y.Name);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                attrx = null;
                attry = null;
            }
            return 0;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
