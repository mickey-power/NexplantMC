/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FEquipmentStateMaterial.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.06.26
--  Description     : FAMate Core FaSecsDriver Equipment State Material Class 
--  History         : Created by Jeff.Kim at 2013.06.26
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FEquipmentStateMaterial : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private const string KeyFormat = "{0}-{1}";    // Equipment Unique ID + Equipment State Unique ID

        // --

        private bool m_disposed = false;
        // --
        private FScdCore m_fScdCore = null;
        private string m_equipmentState = string.Empty;
        private string m_equipmentStateMaterialKey = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FEquipmentStateMaterial(
            FScdCore fScdCore,
            string state
            )
        {
            m_fScdCore = fScdCore;
            m_equipmentState = state;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FEquipmentStateMaterial(
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
                    m_fScdCore = null;
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

        public FObjectType fObjectType
        {
            get
            {
                try
                {
                    return FObjectType.EquipmentStateMaterial;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.EquipmentStateMaterial;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public string stateValue
        {
            get
            {
                try
                {
                    return m_equipmentState;
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

        public string equipmentStateMaterialKey
        {
            get
            {
                try
                {
                    return m_equipmentStateMaterialKey;
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
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public string ToString(
            FStringOption option
            )
        {
            string info = string.Empty;
            try
            {
                info = this.equipmentStateMaterialKey;
                // --
                info += " Value=[" + this.stateValue + "]";
                // --
                return info;
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

        //------------------------------------------------------------------------------------------------------------------------

        private string makeEquipmentStateKey(
            UInt64 eqUniqueId,
            UInt64 estUniqueId
            )
        {
            try
            {
                return string.Format(KeyFormat, eqUniqueId, estUniqueId);
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

        //------------------------------------------------------------------------------------------------------------------------

        internal void setEquipmentStateKey(
            UInt64 eqUniqueId, 
            UInt64 estUniqueId
            )
        {
            string key = string.Empty;

            try
            {
                m_equipmentStateMaterialKey = makeEquipmentStateKey(eqUniqueId, estUniqueId);
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

        internal bool containsEquipmentStateKey(
            UInt64 eqUniqueId,
            UInt64 estUniqueId
            )
        {
            try
            {
                return (m_equipmentStateMaterialKey == string.Format(KeyFormat, eqUniqueId, estUniqueId));
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
