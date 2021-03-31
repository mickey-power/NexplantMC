/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011   Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTelnetByteBuffer.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2012.01.17
--  Description     : FAMate Core FaCommon Telnet Send Buffer Class
--  History         : Created by byungyun.jeon at 2012.01.17
----------------------------------------------------------------------------------------------------------*/
using System;

namespace Nexplant.MC.Core.FaCommon
{
    public class FTelnetByteBuffer : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const int DefaultCapacity = 256;

        // -- 

        private bool m_disposed = false;
        // --
        private int m_count;
        private byte[] m_data;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Conststruction and Destruction

        public FTelnetByteBuffer()
        {
            m_count = 0;
            m_data = new byte[DefaultCapacity];
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTelnetByteBuffer(
            int capacity
            )
        {
            if (capacity < 1)
            {
                FDebug.throwFException(string.Format(FConstants.err_m_0005, "Capacity"));
            }

            // -- 

            m_count = 0;
            m_data = new byte[capacity];
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTelnetByteBuffer(
            byte[] data
            )
        {
            if (data == null)
            {
                FDebug.throwFException(string.Format(FConstants.err_m_0016, "Data"));
            }

            // --

            m_data = new byte[data.Length];
            // --
            data.CopyTo(m_data, 0);
            // --
            m_count = data.Length;
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
                    term();
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

        public int capacity
        {
            get
            {
                try
                {
                    return m_data.Length;
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

            set
            {
                try
                {
                    if (value < 1)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0005, "Value"));
                    }

                    if (value == m_count)
                    {
                        return;
                    }

                    if (value < m_count)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                    }

                    // --

                    byte[] newData = new byte[value];
                    // --
                    Array.Copy(
                        m_data,     // sourceArray
                        0,          // sourceIndex,
                        newData,    // destinationArray
                        0,          // destinationIndex
                        m_count);   // length
                    // --
                    m_data = newData;
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

        public int count
        {
            get
            {
                try
                {
                    return m_count;
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

        public byte this[int index]
        {
            get
            {
                try
                {
                    if ((index < 0) || (index >= m_count))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0005, "Index"));
                    }

                    // -- 

                    return m_data[index];
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

            set
            {
                try
                {
                    if ((index < 0) || (index >= m_count))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0005, "Index"));
                    }

                    // -- 

                    m_data[index] = value;
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

        private void init(
            )
        {
            try
            {

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

        private void term(
            )
        {
            try
            {
                m_data = null;
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

        public void append(
            byte value
            )
        {
            ensureCapacity(m_count + 1);
            m_data[m_count++] = value;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void append(
            byte[] byteArray
            )
        {
            if (byteArray == null)
            {
                FDebug.throwFException(string.Format(FConstants.err_m_0016, "Byte Array"));
            }

            if (byteArray.Length == 0)
            {
                return;
            }

            // --

            ensureCapacity(m_count + byteArray.Length);

            Array.Copy(
                byteArray,          // sourceArray
                0,                  // sourceIndex
                m_data,             // destinationArray
                m_count,            // destinationIndex
                byteArray.Length);  // length

            m_count += byteArray.Length;
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public void clear(
            )
        {
            try
            {
                if (m_count > 0)
                {
                    m_count = 0;
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

        public void collapseDoubles(
            byte value
            )
        {
            int index = 0;

            try
            {
                if (this.m_count < 2)
                {
                    return;
                }

                // -- 

                index = 0;

                do
                {
                    index = Array.IndexOf<byte>(m_data, value, index);

                    if ((index == -1) || (index >= m_count - 1))
                    {
                        break;
                    }

                    if (m_data[++index] == value)
                    {
                        removeAt(index);
                    }

                } while (index <= m_count);
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

        public bool contains(
            byte value
            )
        {
            try
            {
                if (m_count == 0)
                {
                    return false;
                }

                // -- 

                for (int i = 0; i < m_count; i++)
                {
                    if (m_data[i] == value)
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

        public void doDouble(
            byte value
            )
        {
            int index = 0;

            try
            {
                index = indexOf(value);
                // --
                while (index != -1)
                {
                    insert(index, value);
                    index = indexOf(value, index + 2);
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

        private void ensureCapacity(
            int minCapacity
            )
        {
            int newCapacity = 0;

            try
            {
                if (m_data.Length < minCapacity)
                {
                    newCapacity = (m_data.Length == 0) ? 16 : m_data.Length * 2;

                    // -- 

                    if (newCapacity < minCapacity)
                    {
                        newCapacity = minCapacity;
                    }
                    // -- 
                    this.capacity = newCapacity;
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

        public int indexOf(
            byte value
            )
        {
            try
            {
                if (m_count == 0)
                {
                    return -1;
                }
                return Array.IndexOf(m_data, value, 0, m_count);
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

        public int indexOf(
            byte value,
            int startIndex
            )
        {
            try
            {
                if ((m_count == 0) || (m_count - startIndex > 0))
                {
                    return -1;
                }
                return Array.IndexOf(m_data, value, startIndex, m_count - startIndex);
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

        public void insert(
            int index,
            byte value
            )
        {
            try
            {
                if ((index < 0) || (index > m_count))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0005, "Index"));
                }

                // --

                if (m_count == m_data.Length)
                {
                    ensureCapacity(m_count + 1);
                }

                // --

                if (index < m_count)
                {
                    Array.Copy(
                        m_data,             // sourceArray
                        index,              // sourceIndex
                        m_data,             // destinationArray
                        index + 1,          // destinationIndex,
                        m_count - index);   // length
                }
                // --
                m_data[index] = value;
                m_count++;
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
            byte[] values
            )
        {
            try
            {
                if ((index < 0) || (index > m_count))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0005, "Index"));
                }

                if (values.Length == 0)
                {
                    return;
                }

                // --

                ensureCapacity(m_count + values.Length);

                if (index < m_count)
                {
                    Array.Copy(
                        m_data,                 // sourceArray
                        index,                  // sourceIndex
                        m_data,                 // destinationArray
                        index + values.Length,  // destinationIndex
                        m_count - index);       // length
                }

                // -- 

                Array.Copy(
                    values,             // sourceArray
                    0,                  // sourceIndex
                    m_data,             // destinationArray
                    index,              // destinationIndex
                    values.Length);     // length
                // -- 
                m_count += values.Length;
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

        public void removeAt(
            int index
            )
        {
            try
            {
                if ((index < 0) || (index >= m_count))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0005, "Index"));
                }

                // -- 

                if (index == m_count - 1)
                {
                    m_count--;
                    return;
                }
                // --
                if (index < m_count)
                {
                    Array.Copy(
                        m_data,                 // sourceArray
                        index + 1,              // sourceIndex
                        m_data,                 // destinationArray
                        index,                  // destinationIndex
                        m_count - index - 1);   // length
                    // -- 
                    m_count--;
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

        public void replace(
            byte value,
            byte[] newValue
            )
        {
            int index;

            try
            {
                if (newValue == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "New Value"));
                }

                // -- 

                index = indexOf(value);
                // --
                while (index != -1)
                {
                    removeAt(index);
                    insert(index, newValue);
                    index = indexOf(value, index + newValue.Length);
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

        public byte[] toArrary(
            )
        {
            byte[] returnArray = null;

            try
            {
                returnArray = new byte[m_count];

                // -- 

                Buffer.BlockCopy(
                    m_data,
                    0,
                    returnArray,
                    0,
                    m_count);

                // -- 

                return returnArray;
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
