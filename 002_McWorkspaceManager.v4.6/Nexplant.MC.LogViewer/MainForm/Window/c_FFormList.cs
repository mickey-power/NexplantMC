/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FFormList.cs
--  Creator         : baehyun.seo
--  Create Date     : 2013.01.30
--  Description     : FAMate Application Log Viewer Form List Class
--  History         : Created by baehyun.seo at 2013.01.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using System.IO;

namespace Nexplant.MC.LogViewer
{
    public class FFormList : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FLvwCore m_fAlvCore = null;
        
        private List<string> m_keyList = null;
        private List<string> m_textList = null;        
        private Dictionary<string, FBaseForm> m_keyDict = null;
        private Dictionary<FBaseForm, string> m_formDict = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FFormList(
            FLvwCore fAlvCore
            )
        {
            m_fAlvCore = fAlvCore;
            // --
            m_keyList = new List<string>();
            m_textList = new List<string>();            
            m_keyDict = new Dictionary<string, FBaseForm>();
            m_formDict = new Dictionary<FBaseForm, string>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FFormList(
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
                    m_keyList = null;
                    m_textList = null;
                    m_keyDict = null;
                    m_formDict = null;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public void add(
            FBaseForm fForm
            )
        {
            try
            {
                add(fForm, fForm.Text);
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

        public void add(
            FBaseForm fForm, 
            string Text
            )
        {
            string key = string.Empty;
            int index = 0;

            try
            {
                if (m_formDict.ContainsKey(fForm))
                {
                    key = m_formDict[fForm];
                    index = m_keyList.IndexOf(key);

                    // --

                    m_keyList.RemoveAt(index);
                    m_textList.RemoveAt(index);
                    m_keyDict.Remove(key);
                    m_formDict.Remove(fForm);   
                }
                else
                {
                    key = m_fAlvCore.formUniqueId.ToString();
                }

                // --

                // ***
                // Form Add
                // ***
                m_keyList.Insert(0, key);
                m_textList.Insert(0, Text);
                m_keyDict.Add(key, fForm);
                m_formDict.Add(fForm, key);
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

        public void remove(
            FBaseForm fForm
            )
        {
            string key = string.Empty;
            int index = 0;

            try
            {
                if (!m_formDict.ContainsKey(fForm))
                {
                    return;
                }

                // --

                key = m_formDict[fForm];
                index = m_keyList.IndexOf(key);

                // --

                m_keyList.RemoveAt(index);
                m_textList.RemoveAt(index);
                m_keyDict.Remove(key);
                m_formDict.Remove(fForm);               
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

        public string getKeyOfIndex(
            int index
            )
        {
            try
            {
                return m_keyList[index];
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

        public string getTextOfIndex(
            int index
            )
        {
            try
            {
                return m_textList[index];
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

        public FBaseForm getFormOfKey(
            string key
            )
        {
            try
            {
                return m_keyDict[key];
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

    }   // Class end
}   // Namespace end
