/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FAutoCycleData.cs
--  Creator         : spike.lee
--  Create Date     : 2011.11.25
--  Description     : FAMate Core FaSecsDriver Auto Cycle Data Class 
--  History         : Created by spike.lee at 2011.11.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal class FAutoCycleData : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_uniqueId = string.Empty;
        private int m_period = 0;
        private FAutoCycleAction m_fAction = FAutoCycleAction.Once;
        private FXmlNode m_fXmlNode = null;
        private long m_ticks = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FAutoCycleData(
            string uniqueId,
            int period,
            FAutoCycleAction fAction,
            FXmlNode fXmlNode
            )
        {
            m_uniqueId = uniqueId;
            m_period = period;
            m_fAction = fAction;
            m_fXmlNode = fXmlNode;
            m_ticks = FTickCount.ticks;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FAutoCycleData(
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

        public string uniqueId
        {
            get
            {
                try
                {
                    return m_uniqueId;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int period
        {
            get
            {
                try
                {
                    return m_period;
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

        public FAutoCycleAction fAction
        {
            get
            {
                try
                {
                    return m_fAction;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FAutoCycleAction.Once;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlNode fXmlNode
        {
            get
            {
                try
                {
                    return m_fXmlNode;
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

        public bool elasped(
            )
        {
            try
            {
                if (FTickCount.timeout(m_ticks, m_period))
                {
                    if (m_fAction == FAutoCycleAction.Repeat)
                    {
                        m_ticks = FTickCount.addTicks(m_ticks, period);
                    }
                    return true;
                }
                return false;
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
