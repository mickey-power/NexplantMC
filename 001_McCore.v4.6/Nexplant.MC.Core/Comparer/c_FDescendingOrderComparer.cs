/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDescendingOrderComparer.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2012.03.14
--  Description     : FAMate Core FaCommon Descending Order Comparer Class
--  History         : Created by byungyun.jeon at 2012.03.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.IO;

namespace Nexplant.MC.Core.FaCommon
{
    public class FDescendingOrderComparer : IComparer, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDescendingOrderComparer(
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDescendingOrderComparer(
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
                if (obj1 is string && obj2 is string)
                {
                    return -String.Compare((string)obj1, (string)obj2);
                }
                else if (obj1 is int && obj2 is int)
                {
                    if ((int)obj1 > (int)obj2)
                    {
                        return -1;
                    }
                    else if ((int)obj1 < (int)obj2)
                    {
                        return 1;
                    }
                    return 0;
                }
                else if (obj1 is double && obj2 is double)
                {
                    if ((double)obj1 > (double)obj2)
                    {
                        return -1;
                    }
                    else if ((double)obj1 < (double)obj2)
                    {
                        return 1;
                    }
                    return 0;
                }
                else if (obj1 is FileInfo && obj2 is FileInfo)
                {
                    return -String.Compare(((FileInfo)obj1).Name, ((FileInfo)obj2).Name);
                }
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