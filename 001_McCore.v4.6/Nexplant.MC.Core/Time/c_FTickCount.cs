/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTickCount.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.22
--  Description     : FAMate Core FaCommon TickCount Handling Class
--  History         : Created by spike.lee at 2010.12.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public static class FTickCount
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        static FTickCount(
            )
        {

        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public static long ticks
        {
            get
            {
                try
                {
                    // ***
                    // 24.9 days recycle
                    // ***
                    return Environment.TickCount & Int32.MaxValue;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static long addTicks(
            long baseTicks,
            long value
            )
        {
            try
            {
                return (baseTicks + value) & Int32.MaxValue;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static bool timeout(
            long ticks, 
            int dueTime
            )
        {
            long newTicks = 0;
            long result = 0;

            try
            {
                newTicks = FTickCount.ticks;
                result = (newTicks - ticks) & Int32.MaxValue;               
                return (result < dueTime ? false : true);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return false;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
