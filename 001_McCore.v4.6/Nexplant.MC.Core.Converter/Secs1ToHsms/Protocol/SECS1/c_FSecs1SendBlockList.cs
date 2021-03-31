/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecs1SendBlockList.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.12
--  Description     : FAmate Converter FaSecs1ToHsms SECS1 Send Block List Class
--  History         : Created by spike.lee at 2017.04.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    internal class FSecs1SendBlockList: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSecs1ToHsms m_fSecs1ToHsms = null;
        private FSecsDataMessage m_fSecsDataMessage = null;
        private List<FSecs1SendBlock> m_fBlockList = null;
        private int m_blockIndex = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecs1SendBlockList(            
            FSecs1ToHsms fSecs1ToHsms,
            FSecsDataMessage fSecsDataMessage
            )
        {
            m_fSecs1ToHsms = fSecs1ToHsms;
            m_fSecsDataMessage = fSecsDataMessage;
            m_fBlockList = new List<FSecs1SendBlock>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecs1SendBlockList(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_fSecs1ToHsms = null;
                    m_fSecsDataMessage = null;
                    m_fBlockList = null;
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

        public int length
        {
            get
            {
                try
                {
                    return m_fBlockList.Count;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FSecs1SendBlock fCurrentBlock            
        {
            get
            {
                try
                {
                    return m_fBlockList[m_blockIndex];
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsDataMessage fSecsDataMessage
        {
            get
            {
                try
                {
                    return m_fSecsDataMessage;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public void addBlock(
            FSecs1SendBlock fBlock
            )
        {
            try
            {
                m_fBlockList.Add(fBlock);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool next(
            )
        {
            int index = 0;

            try
            {
                index = m_blockIndex + 1;
                if (index >= m_fBlockList.Count)
                {
                    return false;
                }
                // --
                m_blockIndex = index;
                return true;
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
