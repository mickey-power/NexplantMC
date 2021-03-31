/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_F7Zip.cs
--  Creator         : mjkim
--  Create Date     : 2013.03.22
--  Description     : FAMate Core FaCommon 7-ZIP Class
--  History         : Created by mjkim at 2013.03.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using SevenZip;
//using Miracom.FAMate.Core.FaCommon;

namespace Nexplant.MC.Core.FaCommon
{
    public static class F7Zip
    {        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        static F7Zip(
            )
        {

        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static void pack(
            string zipName,
            string[] source
            )
        {
            SevenZipCompressor cmp = null;

            try
            {
                if (Environment.Is64BitProcess)
                {
                    SevenZipCompressor.SetLibraryPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "7z64.dll"));
                }

                // --

                cmp = new SevenZipCompressor();
                // --
                cmp.ArchiveFormat = OutArchiveFormat.Zip;
                cmp.CompressionMethod = SevenZip.CompressionMethod.Deflate64;
                cmp.CompressionLevel = CompressionLevel.Fast;

                // --

                cmp.CompressFiles(zipName, source);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                cmp = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void pack(
            string zipName,
            string source
            )
        {
            SevenZipCompressor cmp = null;

            try
            {
                if (Environment.Is64BitProcess)
                {
                    SevenZipCompressor.SetLibraryPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "7z64.dll"));
                }

                // --

                cmp = new SevenZipCompressor();
                // --
                cmp.ArchiveFormat = OutArchiveFormat.Zip;
                cmp.CompressionMethod = SevenZip.CompressionMethod.Deflate64;
                cmp.CompressionLevel = CompressionLevel.Fast;

                // --

                cmp.CompressFiles(zipName, new string[] { source });
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                cmp = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void unpack(
            string zipName,
            string targetDir
            )
        {
            SevenZipExtractor extr = null;

            try
            {
                if (Environment.Is64BitProcess)
                {
                    SevenZipExtractor.SetLibraryPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "7z64.dll"));
                }

                // --

                extr = new SevenZipExtractor(zipName);

                // --

                extr.ExtractArchive(targetDir);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (extr != null)
                {
                    extr.Dispose();
                    extr = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FZipEntryCollection fZipEntryCollection(
            string zipName
            )
        {
            Dictionary<string, FZipEntry> entryDict = null;
            List<FZipEntry> entryList = null;
            FZipEntry fze = null;

            try
            {
                entryDict = new Dictionary<string, FZipEntry>();
                entryList = new List<FZipEntry>();
                // --
                if (Environment.Is64BitProcess)
                {
                    SevenZipExtractor.SetLibraryPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "7z64.dll"));
                }

                // --

                using (SevenZipExtractor extr = new SevenZipExtractor(File.OpenRead(zipName)))
                {
                    foreach (ArchiveFileInfo fi in extr.ArchiveFileData)
                    {
                        fze = new FZipEntry(fi.FileName);
                        fze.creationTime = fi.CreationTime;
                        fze.lastWriteTime = fi.LastWriteTime;
                        fze.lastAccessTime = fi.LastAccessTime;
                        fze.size = (long)fi.Size;
                        // --
                        if (!entryDict.ContainsKey(fze.name))
                        {
                            entryDict.Add(fze.name, fze);
                            entryList.Add(fze);
                        }
                    }
                }

                // --

                return new FZipEntryCollection(entryDict, entryList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                entryDict = null;
                entryList = null;
                fze = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string compress(
            string source
            )
        {
            byte[] buffer = null;
            byte[] compressed = null;
            byte[] gzBuffer = null;

            try
            {
                buffer = Encoding.UTF8.GetBytes(source);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (GZipStream gZip = new GZipStream(ms, System.IO.Compression.CompressionMode.Compress, true))
                    {
                        gZip.Write(buffer, 0, buffer.Length);
                        gZip.Close();
                    }
                    ms.Position = 0;
                    compressed = new byte[ms.Length];
                    ms.Read(compressed, 0, compressed.Length);
                    ms.Close();
                }
                gzBuffer = new byte[compressed.Length + 4];
                System.Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);
                System.Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4);

                return Convert.ToBase64String(gzBuffer);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                buffer = null;
                compressed = null;
                gzBuffer = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string decompress(
            string source
            )
        {
            byte[] gzBuffer = null;
            byte[] buffer = null;
            int msgLength = 0;

            try
            {
                gzBuffer = Convert.FromBase64String(source);

                using (MemoryStream ms = new MemoryStream())
                {
                    msgLength = BitConverter.ToInt32(gzBuffer, 0);
                    ms.Write(gzBuffer, 4, gzBuffer.Length - 4);

                    buffer = new byte[msgLength];

                    ms.Position = 0;
                    using (GZipStream zip = new GZipStream(ms, System.IO.Compression.CompressionMode.Decompress))
                    {
                        zip.Read(buffer, 0, buffer.Length);
                        zip.Close();
                    }
                    ms.Close();

                    return Encoding.UTF8.GetString(buffer);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                gzBuffer = null;
                buffer = null;
            }
            return string.Empty;
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
