/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FKepwareSubscriberData.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2015.10.09
--  Description     : FAMate Core FaOpcDriver SubscriberData Class 
--  History         : Created by Jeff.Kim at 2015.10.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;
using Kepware.ClientAce.OpcDaClient;

namespace Nexplant.MC.Core.FaOpcDriver
{
    internal class FKepwareSubscriberData : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --             
        private int m_clientSubscription = 0;
        private bool m_allQualitiesGood = false;
        private bool m_noErrors = false;
        private ItemValueCallback[] m_itemValues = null;


        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FKepwareSubscriberData(       
            int clientSubscription, 
            bool allQualitiesGood, 
            bool noErrors, 
            ItemValueCallback[] itemValues
            )
        {
            m_clientSubscription = clientSubscription;
            m_allQualitiesGood = allQualitiesGood;
            m_noErrors = noErrors;
            m_itemValues = itemValues;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FKepwareSubscriberData(
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
                    m_itemValues = null;
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

        public int clientSubscription
        {
            get
            {
                try
                {
                    return m_clientSubscription;
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

        public bool allQualitiesGood
        {
            get
            {
                try
                {
                    return m_allQualitiesGood;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool noErrors
        {
            get
            {
                try
                {
                    // --

                    return m_noErrors;
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
        }
               
        //------------------------------------------------------------------------------------------------------------------------

        public ItemValueCallback[] itemValues
        {
            get
            {
                try
                {
                    return m_itemValues;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
