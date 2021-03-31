/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FCrypt.cs
--  Creator         : mj.kim
--  Create Date     : 2011.08.25
--  Description     : FAMate Core FaCommon Crypt Class
--  History         : Created by mj.kim at 2011.08.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.InteropServices;

namespace Nexplant.MC.Core.FaCommon
{
    public class FCrypt : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        [DllImport(@"Nexplant.Mc.Core.Securities32.v4.6.dll", EntryPoint = "_encrypt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr encrypt32(IntPtr plainData);

        //------------------------------------------------------------------------------------------------------------------------

        [DllImport(@"Nexplant.Mc.Core.Securities32.v4.6.dll", EntryPoint = "_decrypt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr decrypt32(IntPtr cipherData);

        //------------------------------------------------------------------------------------------------------------------------

        [DllImport(@"Nexplant.Mc.Core.Securities64.v4.6.dll", EntryPoint = "_encrypt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr encrypt64(IntPtr plainData);

        //------------------------------------------------------------------------------------------------------------------------

        [DllImport(@"Nexplant.Mc.Core.Securities64.v4.6.dll", EntryPoint = "_decrypt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr decrypt64(IntPtr cipherData);
        
        //------------------------------------------------------------------------------------------------------------------------

        private const string DefaultKey = "MjByBhKt";
        private const int BlockSize = 16;        
       
        // --

        private bool m_disposed = false;
        // --
        private byte[] m_key = null;
        // --
        private IntPtr inputPtr = IntPtr.Zero;
        private IntPtr outputPtr = IntPtr.Zero;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FCrypt(
            string key
            )
        {            
            m_key = ASCIIEncoding.ASCII.GetBytes(key);
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FCrypt(
            )
            : this (DefaultKey)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FCrypt(
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
                    m_key = null;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public string encrypt(
            string plainStr
            )
        {
            DESCryptoServiceProvider desCES = null;
            MemoryStream ms = null;
            CryptoStream cs = null;
            byte[] data = null;

            try
            {
                if (m_key == null || m_key.Length != 8)
                {
                    FDebug.throwFException(FConstants.err_m_0006);
                }

                // --

                if (plainStr == string.Empty)
                {
                    return string.Empty;
                }

                // --

                desCES = new DESCryptoServiceProvider();
                ms = new MemoryStream();
                cs = new CryptoStream(ms, desCES.CreateEncryptor(m_key, m_key), CryptoStreamMode.Write);

                // --

                data = Encoding.UTF8.GetBytes(plainStr.ToCharArray ());
                cs.Write(data, 0, data.Length);
                cs.FlushFinalBlock();

                // --

                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (cs != null)
                {
                    cs.Dispose();
                    cs = null;
                }
                if (ms != null)
                {
                    ms.Dispose();
                    ms = null;
                }

                if (desCES != null)
                {
                    desCES.Dispose();
                    desCES = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string decrypt(
            string cypherStr
            )
        {
            DESCryptoServiceProvider desCSP = null;
            MemoryStream ms = null;
            CryptoStream cs = null;
            byte[] data = null;

            try
            {
                if (m_key == null || m_key.Length != 8)
                {
                    FDebug.throwFException(FConstants.err_m_0006);
                }

                // --

                if (cypherStr == string.Empty)
                {
                    return string.Empty;
                }

                // --

                desCSP = new DESCryptoServiceProvider();
                ms = new MemoryStream();
                cs = new CryptoStream(ms, desCSP.CreateDecryptor(m_key, m_key), CryptoStreamMode.Write);

                // --

                data = Convert.FromBase64String(cypherStr);
                cs.Write(data, 0, data.Length);
                cs.FlushFinalBlock();

                // --

                return Encoding.UTF8.GetString(ms.GetBuffer()).Trim((char)0x00);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (cs != null)
                {
                    cs.Dispose();
                    cs = null;
                }
                if (ms != null)
                {
                    ms.Dispose();
                    ms = null;
                }

                if (desCSP != null)
                {
                    desCSP.Dispose();
                    desCSP = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string encrypt2(
            string plainStr
            )
        {
            int binCursor = 0;
            int dataLength = 0;
            byte[] binData = null;
            byte[] blockData = null;
            string dataBuffer = string.Empty;

            try
            {
                binCursor = 0;
                dataBuffer = string.Empty;
                binData = Encoding.ASCII.GetBytes(plainStr);
                blockData = new byte[BlockSize];
                
                // -- 
                
                while(binCursor < binData.Length)
                {
                    dataLength = (binCursor + BlockSize < binData.Length) ? BlockSize : binData.Length - binCursor;
                    if (dataLength < BlockSize)
                    {
                        blockData = new byte[BlockSize];
                    }
                    Buffer.BlockCopy(binData, binCursor, blockData, 0, dataLength);
                    dataBuffer += encrypt2_ecb(blockData);
                    binCursor += dataLength;
                }

                // -- 

                return dataBuffer;
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

        public string decrypt2(
            string cipherStr
            )
        {
            int binCursor = 0;
            int dataLength = 0;
            byte[] binData = null;
            byte[] blockData = null;
            string dataBuffer = string.Empty;

            try
            {
                cipherStr = cipherStr.Replace("\r", "");
                cipherStr = cipherStr.Replace("\n", "");

                // -- 

                binCursor = 0;
                dataBuffer = string.Empty;
                binData = Hex2Bytes(cipherStr);
                blockData = new byte[BlockSize];

                // --

                while (binCursor < binData.Length)
                {
                    dataLength = (binCursor + BlockSize < binData.Length) ? BlockSize : binData.Length - binCursor;
                    if (dataLength < BlockSize)
                    {
                        blockData = new byte[BlockSize];
                    }
                    Buffer.BlockCopy(binData, binCursor, blockData, 0, dataLength);
                    dataBuffer += decrypt2_ecb(blockData);
                    binCursor += dataLength;
                }

                // -- 

                return dataBuffer.Replace("\0", "");
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

        private string encrypt2_ecb(
            byte[] plainBin
            )
        {
            byte[] dataBuffer = null;

            try
            {
                if (plainBin.Length > BlockSize)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0005, "Inputted Value"));
                }

                // -- 

                // ***
                // Data Binding from byte[] to IntPtr
                // ***
                dataBuffer = new byte[BlockSize];
                Buffer.BlockCopy(plainBin, 0, dataBuffer, 0, plainBin.Length);
                inputPtr = Marshal.AllocHGlobal(BlockSize);
                Marshal.Copy(dataBuffer, 0, inputPtr, BlockSize);

                //////////////////////////////////////////////////
                if (Environment.Is64BitProcess)
                {
                    outputPtr = encrypt64(inputPtr);
                }
                else
                {
                    outputPtr = encrypt32(inputPtr);
                }
                
                //////////////////////////////////////////////////

                // ***
                // Result Data Binding from IntPtr to byte[]
                // ***
                dataBuffer = new byte[BlockSize];
                Marshal.Copy(outputPtr, dataBuffer, 0, BlockSize);

                // --

                return Bytes2Hex(dataBuffer);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (inputPtr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(inputPtr);
                    inputPtr = IntPtr.Zero;
                }
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private string decrypt2_ecb(
            byte[] cipherBin
            )
        {
            byte[] dataBuffer = null;

            try
            {
                if (cipherBin.Length > BlockSize)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0005, "Inputted Value"));
                }

                // -- 

                // ***
                // Data Binding from byte[] to IntPtr
                // ***
                dataBuffer = new byte[BlockSize];
                Buffer.BlockCopy(cipherBin, 0, dataBuffer, 0, cipherBin.Length);
                inputPtr = Marshal.AllocHGlobal(BlockSize);
                Marshal.Copy(dataBuffer, 0, inputPtr, BlockSize);

                //////////////////////////////////////////////////
                if (Environment.Is64BitProcess)
                {
                    outputPtr = decrypt64(inputPtr);
                }
                else
                {
                    outputPtr = decrypt32(inputPtr);
                }                
                //////////////////////////////////////////////////

                // ***
                // Result Data Binding from IntPtr to byte[] 
                // ***
                dataBuffer = new byte[BlockSize];
                Marshal.Copy(outputPtr, dataBuffer, 0, BlockSize);

                // -- 

                return Encoding.ASCII.GetString(dataBuffer);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (inputPtr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(inputPtr);
                    inputPtr = IntPtr.Zero;
                }
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private string Bytes2Hex(
            byte[] binData,
            bool isLowerCase = false
            )
        {
            StringBuilder hexExpr = null; 
            string notationFormat = string.Empty;

            try
            {
                hexExpr = new StringBuilder();
                notationFormat = isLowerCase ? "{0:x2}" : "{0:X2}";
                foreach (byte bin in binData)
                {
                    hexExpr.AppendFormat(notationFormat, bin);
                }                
                return hexExpr.ToString();
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

        private byte[] Hex2Bytes(
            string hexExpr
            )
        {
            int binLength = 0;
            byte[] binData = null;

            try
            {
                hexExpr.Replace(" ", "");

                // --

                binLength = hexExpr.Length / 2;
                binData = new byte[binLength];

                for (int i = 0; i < binLength; i++)
                {
                    binData[i] = (byte)Convert.ToByte(hexExpr.Substring(i * 2, 2), 16);
                }

                return binData;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end    
}   // Namespace end