/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FKepwareItem.cs
--  Creator         : spike.lee
--  Create Date     : 2015.06.26
--  Description     : FAMate Core FaOpcDriver Subscribe Item Class 
--  History         : Created by spike.lee at 2015.06.26
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
    internal class FKepwareItem : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private UInt64 m_osnUniqueId = 0;
        private UInt64 m_oeiUniqueId = 0;
        private FTagFormat m_fItemFormat = FTagFormat.Byte;
        private string m_itemName = string.Empty;
        private FOpcFormat m_fFormat = FOpcFormat.Boolean;
        private bool m_ignoreFirst = false;
        private bool m_firstValueSet = false;
        private object m_oldValue = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FKepwareItem(            
            UInt64 osnUniqueId,
            UInt64 oeiUniqueId,
            FTagFormat fItemFormat,
            string itemName,
            FOpcFormat fFormat,
            bool ignoreFirst
            )
        {
            m_osnUniqueId = osnUniqueId;
            m_oeiUniqueId = oeiUniqueId;
            m_fItemFormat = fItemFormat;
            m_itemName = itemName;
            m_fFormat = fFormat;
            m_ignoreFirst = ignoreFirst;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FKepwareItem(
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

        public UInt64 osnUniqueId
        {
            get
            {
                try
                {
                    return m_osnUniqueId;
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

        public UInt64 oeiUniqueId
        {
            get
            {
                try
                {
                    return m_oeiUniqueId;
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

        public FTagFormat fItemFormat
        {
            get
            {
                try
                {
                    return m_fItemFormat;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FTagFormat.Byte;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string itemName
        {
            get
            {
                try
                {
                    return m_itemName;
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

        public FOpcFormat fFormat
        {
            get
            {
                try
                {
                    return m_fFormat;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FOpcFormat.Boolean;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool ignoreFirst
        {
            get
            {
                try
                {
                    return m_ignoreFirst;
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

        public bool firstValueSet
        {
            get
            {
                try
                {
                    return m_firstValueSet;
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
            set
            {
                try
                {
                    m_firstValueSet = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public object oldValue
        {
            get
            {
                try
                {
                    return m_oldValue;
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

            set
            {
                try
                {
                    m_oldValue = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
