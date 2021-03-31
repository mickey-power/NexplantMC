/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FBaseObjectLog.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.06
--  Description     : FAMate Core FaSecsDriver Base Object Log Class 
--  History         : Created by spike.lee at 2011.09.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public abstract class FBaseObjectLog<T> : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FScdlCore m_fScdlCore = null;
        private FXmlNode m_fXmlNode = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FBaseObjectLog(
            )
        {
            // ***
            // FSecsDriverLog 생성자 Only
            // ***
            m_fScdlCore = new FScdlCore();
            //
            m_fXmlNode = m_fScdlCore.fXmlNodeScdl;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FBaseObjectLog(
            FScdlCore fScdlCore,
            FXmlNode fXmlNode
            )
        {
            m_fScdlCore = fScdlCore;
            m_fXmlNode = fXmlNode;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FBaseObjectLog(                        
            FXmlNode fXmlNode
            )
        {
            m_fXmlNode = fXmlNode;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FBaseObjectLog(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    if (this is FSecsDriverLog && m_fScdlCore != null)
                    {
                        m_fScdlCore.Dispose();
                    }
                    m_fScdlCore = null;

                    // --

                    if (m_fXmlNode != null)
                    {
                        m_fXmlNode.Dispose();
                        m_fXmlNode = null;
                    }            
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

        internal FScdlCore fScdlCore
        {
            get
            {
                try
                {
                    return m_fScdlCore;
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

        internal FXmlNode fXmlNode
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

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsDriverLog fSecsDriverLog
        {
            get
            {
                try
                {
                    if (m_fScdlCore == null)
                    {
                        return null;
                    }
                    return m_fScdlCore.fSecsDriverLog;
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

            internal set
            {
                try
                {
                    m_fScdlCore.fSecsDriverLog = value;
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

        public bool isLoggingObject
        {
            get
            {
                FXmlNode fXmlNodeParent = null;

                try
                {
                    fXmlNodeParent = this.fXmlNode.fParentNode;
                    while (fXmlNodeParent != null)
                    {
                        if (fXmlNodeParent.name == FXmlTagFAM.E_FAMate)
                        {
                            return true;
                        }
                        fXmlNodeParent = fXmlNodeParent.fParentNode;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    if (fXmlNodeParent != null)
                    {
                        fXmlNodeParent.Dispose();
                        fXmlNodeParent = null;
                    }
                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool removed
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null)
                    {
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        internal virtual void replace(
            FScdlCore fScdlCore,
            FXmlNode fXmlNode
            )
        {
            try
            {
                m_fScdlCore = fScdlCore;
                m_fXmlNode = fXmlNode;
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

        public override int GetHashCode(
            )
        {
            return base.GetHashCode();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public override bool Equals(
            object obj
            )
        {
            try
            {
                if (obj == null || !(obj is T))
                {
                    return false;
                }
                // --
                return m_fXmlNode.Equals(((FBaseObjectLog<T>)obj).fXmlNode);
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

        //------------------------------------------------------------------------------------------------------------------------

        public static bool operator ==(
            FBaseObjectLog<T> lhs,
            object rhs
            )
        {
            try
            {
                if ((object)lhs == null)
                {
                    return ((object)rhs == null ? true : false);
                }
                // --
                return lhs.Equals(rhs);
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

        //------------------------------------------------------------------------------------------------------------------------

        public static bool operator !=(
            FBaseObjectLog<T> lhs,
            object rhs
            )
        {
            try
            {
                if ((object)lhs == null)
                {
                    return ((object)rhs == null ? false : true);
                }
                // --
                return !lhs.Equals(rhs);
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

        //------------------------------------------------------------------------------------------------------------------------

        internal void copyObject(
            string format,
            FXmlNode fXmlNode
            )
        {
            try
            {
                // ***
                // 2016.12.22 by spike.lee
                // Log Object는 Lock 속성을 모두 제거하도록 했지만 이전 버전 Log Object에 Lock 속성이 있을 수 있어
                // Log Object Copy 시, Lock 속성을 모두 제거하도록 처리
                // ***
                FSecsDriverCommon.resetLocked(fXmlNode);
                FClipboard.setStringData(format, fXmlNode.outerXml);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
