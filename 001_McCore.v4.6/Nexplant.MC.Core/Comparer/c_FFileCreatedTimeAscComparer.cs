/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FFileCreatedTimeAscComparer.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2012.03.16
--  Description     : FAMate Core FaCommon File Created Time Ascending Order Comparer Class
--  History         : Created by byungyun.jeon at 2012.03.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.IO;

namespace Nexplant.MC.Core.FaCommon
{
    public class FFileCreatedTimeAscComparer : IComparer, IDisposable
    {
    
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FFileCreatedTimeAscComparer(
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FFileCreatedTimeAscComparer(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region IDisposable 멤버

        public void Dispose(
            )
        {
            myDispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public int Compare(
            object obj1,
            object obj2
            )
        {
            try
            {
                if (((FileInfo)obj1).CreationTime.ToBinary() > ((FileInfo)obj2).CreationTime.ToBinary())
                {
                    return 1;
                }
                else if (((FileInfo)obj1).CreationTime.ToBinary() < ((FileInfo)obj2).CreationTime.ToBinary())
                {
                    return -1;
                }
                return 0;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end