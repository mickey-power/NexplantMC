/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FFlagCollection.cs
--  Creator         : byjeon
--  Create Date     : 2013.12.02
--  Description     : FAMate UI WaferChart ItemCollection Class
--  History         : Created by byjeon at 2013.12.02
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Media;
using Nexplant.MC.Core.FaCommon;
using System.Windows.Controls;

namespace Nexplant.MC.Core.FaUIs
{
    public class FFlagCollection : IDisposable, IEnumerable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string TheOthersFlagName = "The others";

        // -- 

        private bool m_disposed = false;
        // --
        private FFlag m_fFlagOfTheOthers = null;
        private List<FFlag> m_fFlagList = null;
        private ItemsControl m_flagsControl = null;
        // -- 
        private Color[] m_colorList = {
                                        Colors.Red, 
                                        Colors.Blue, 
                                        Colors.Orange, 
                                        Colors.Green, 
                                        Colors.Purple, 
                                        Colors.Navy, 
                                        Colors.Violet, 
                                        Colors.Olive, 
                                        Colors.Lime, 
                                        Colors.Cyan
                                      };
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FFlagCollection(
            )
        {
            m_fFlagList = new List<FFlag>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FFlagCollection(
            List<FFlag> fFlagList
            )
        {
            m_fFlagList = fFlagList;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FFlagCollection(
            ItemsControl flagsControl
            )
        {
            m_fFlagList = new List<FFlag>();
            this.flagsControl = flagsControl;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FFlagCollection(
            List<FFlag> fFlagList,
            ItemsControl flagsControl
            )
        {
            m_fFlagList = fFlagList;
            this.flagsControl = flagsControl;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FFlagCollection(
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
                    m_fFlagList = null;
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
                return new FFlagCollectionEnumerator(this);
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
                    return m_fFlagList.Count;
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

        public FFlag this[int i]
        {
            get
            {
                try
                {
                    if (i < 0 || i >= m_fFlagList.Count)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0001, "Index"));
                    }

                    // -- 

                    return m_fFlagList[i];
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

        public ItemsControl flagsControl
        {
            set
            {
                try
                {
                    m_flagsControl = value;
                    sync();
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }                
            }

            get
            {
                try
                {
                    return m_flagsControl;
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

        private Color defaultColor
        {
            get
            {
                List<Color> colorList = null;

                try
                {
                    colorList = new List<Color>(m_colorList);

                    // -- 

                    foreach (FFlag fFlag in m_fFlagList)
                    {
                        colorList.Remove(fFlag.color);
                    }

                    // -- 

                    if (colorList.Count == 0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0001, "Color List"));
                    }
                    return colorList[0];
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return Colors.Transparent;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public void add(
            string name,
            double value            
            )
        {
            try
            {
                insert(m_fFlagList.Count, name, value, defaultColor);
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
            string name,
            double value,
            Color color
            )
        {
            try
            {
                insert(m_fFlagList.Count, name, value, color);
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

        public void insert(
            int index,
            string name,
            double value
            )
        {
            try
            {
                insert(index, name, value, defaultColor);
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

        public void insert(
            int index,
            string name,
            double value,
            Color color
            )
        {
            FFlag fFlag = null;

            try
            {
                // ***
                // Validation
                // ***
                if (index > m_fFlagList.Count)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0001, "Flag"));
                }

                if (indexOf(name) >= 0)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0013, "Flag Name"));
                }

                if (existValue(value))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0013, "Flag Value"));
                }
                
                // --
                
                // ***
                // Insert
                // ***
                fFlag = new FFlag(name, value, color);
                m_fFlagList.Insert(index, fFlag);
                m_flagsControl.Items.Insert(index, fFlag);

                // -- 

                // ***
                // Remove & Add Others Flag
                // ***
                if (m_fFlagOfTheOthers != null)
                {
                    m_flagsControl.Items.Remove(m_fFlagOfTheOthers);
                    m_flagsControl.Items.Add(m_fFlagOfTheOthers);
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fFlag != null)
                {
                    fFlag.Dispose();
                    fFlag = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void remove(
            string name
            )
        {
            int index = 0;

            try
            {
                index = indexOf(name);
                if (index >= 0)
                {
                    m_fFlagList.RemoveAt(index);
                    m_flagsControl.Items.RemoveAt(index);
                }
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
                m_fFlagList.Clear();
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

        public Color matchColor(
            double value
            )
        {
            try
            {
                return getFlagByValue(value).color;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return Colors.Transparent;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FFlag getFlagByValue(
            double value
            )
        {
            try
            {
                foreach (FFlag fFlag in m_fFlagList)
                {
                    if (fFlag.value == value)
                    {
                        return fFlag;
                    }
                }
                //--

                if (m_fFlagOfTheOthers != null)
                {
                    return m_fFlagOfTheOthers;
                }

                FDebug.throwFException(string.Format(FConstants.err_m_0012, "Flag"));                
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool existValue(
            double value
            )
        {
            try
            {
                return (getFlagByValue(value) != m_fFlagOfTheOthers) ? true : false;
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
        
        public bool existColor(
            Color color
            )
        {
            try
            {
                foreach (FFlag fFlag in m_fFlagList)
                {
                    if (fFlag.color == color)
                    {
                        return true;
                    }
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

        //------------------------------------------------------------------------------------------------------------------------
        
        private int indexOf(
            string name
            )
        {
            try
            {
                for (int i = 0; i < m_fFlagList.Count; i++)
                {
                    if (m_fFlagList[i].name == name)
                    {
                        return i;
                    }
                }
                return -1;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return -1;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sync(
            )
        {            
            try
            {
                if (m_flagsControl == null)
                {
                    return;
                }

                // --

                m_flagsControl.Items.Clear();
                foreach (FFlag fFlag in m_fFlagList)
                {
                    m_flagsControl.Items.Add(fFlag);
                }

                // --

                if (m_fFlagOfTheOthers != null)
                {
                    m_flagsControl.Items.Add(m_fFlagOfTheOthers);
                }
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

        public void setOthers(
            Color color
            )
        {
            try
            {
                // ***
                // Remove & Add Others Flag
                // ***
                if (m_fFlagOfTheOthers != null)
                {
                    m_flagsControl.Items.Remove(m_fFlagOfTheOthers);                    
                }

                // -- 

                m_fFlagOfTheOthers = new FFlag(TheOthersFlagName, 0, color);
                m_flagsControl.Items.Add(m_fFlagOfTheOthers);
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