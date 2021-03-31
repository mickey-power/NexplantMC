/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FCellCollection.cs
--  Creator         : byjeon
--  Create Date     : 2013.12.02
--  Description     : FAMate UI WaferChart FCellCollection Class
--  History         : Created by byjeon at 2013.12.02
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public class FCellCollection : IDisposable, IEnumerable
    {
        
        //------------------------------------------------------------------------------------------------------------------------

        private const string KeyFormat = "{0}-{1}";

        // -- 

        private bool m_disposed = false;
        // --
        private List<string> m_keyList = null;
        private Dictionary<string, FCell> m_fCellDic = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FCellCollection(
            )
        {
            m_keyList = new List<string>();
            m_fCellDic = new Dictionary<string, FCell>();
        }

        //------------------------------------------------------------------------------------------------------------------------

         ~FCellCollection(
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
                    m_fCellDic = null;
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

        #region IEnumerable 멤버

        public IEnumerator GetEnumerator()
        {
            try
            {
                return new FCellCollectionEnumerator(this);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public int count
        {
            get
            {
                try
                {
                    return m_keyList.Count;
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

        public FCell this[int i]
        {
            get
            {
                try
                {
                    if (i < 0 || i >= m_keyList.Count)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0001, "Index"));
                    }

                    // -- 

                    return m_fCellDic[m_keyList[i]];
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

        public FCell this[int row, int column]
        {
            get
            {
                string key = string.Empty;

                try
                {
                    key = makeKey(row, column);

                    // -- 

                    if (m_fCellDic.ContainsKey(key))
                    {
                        return m_fCellDic[key];
                    }
                    return null;                    
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

        private string makeKey(
            int row,
            int column
            )
        {
            try
            {
                return string.Format(KeyFormat, row, column); 
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

        public void add(
            int row,
            int column,
            FCell fCell
            )
        {
            string key = string.Empty;
            
            try
            {
                key = makeKey(row, column);

                // -- 

                if (m_fCellDic.ContainsKey(key))
                {
                    m_fCellDic.Remove(key);                    
                }

                // -- 

                m_fCellDic.Add(key, fCell);
            }
            catch(Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void remove(
            int row,
            int column
            )
        {
            string key = string.Empty;

            try
            {
                key = makeKey(row, column);
                
                // --
                
                m_fCellDic.Remove(key);
                m_keyList.Remove(key);                
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

        public void clear(
            )
        {
            try
            {
                m_fCellDic.Clear();
                m_keyList.Clear();
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

    } // End Class
} // End Namespace