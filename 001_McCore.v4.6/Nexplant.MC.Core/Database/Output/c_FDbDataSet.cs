/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDbDataSet.cs
--  Creator         : byjeon
--  Create Date     : 2014.08.11
--  Description     : FAMate Core FaCommon Database DataSet Output Type Class
--  History         : Created by byjeon at 2014.08.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nexplant.MC.Core.FaCommon
{
    public class FDbDataSet : FIDbOutput, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        
        // -- 

        private DataSet m_dataSet = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction 

        public FDbDataSet(
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDbDataSet(
            DataSet dataSet
            )
        {
            m_dataSet = dataSet;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDbDataSet(
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

                }
            }
            m_disposed = true;
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

        public string name
        {
            get
            {
                try
                {
                    return "DataSet";
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

        public FOutputType fType
        {
            get
            {
                try
                {
                    return FOutputType.DataSet;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);

                }
                finally
                {

                }
                return FOutputType.DataSet;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public DataSet dataSet
        {
            get
            {
                try
                {
                    return m_dataSet;
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
                    m_dataSet = value;
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
        
        public DataTable this[string name]
        {
            get
            {
                try
                {
                    if (m_dataSet.Tables.Contains(name))
                    {
                        return m_dataSet.Tables[name];
                    }
                    return null;
                }
                catch(Exception ex)
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

    } // End Class
} // End Namespace
