/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FClipboard.cs
--  Creator         : spike.lee
--  Create Date     : 2011.08.16
--  Description     : FAMate Core FaCommon Clipbard Class 
--  History         : Created by spike.lee at 2011.08.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows; 

namespace Nexplant.MC.Core.FaCommon
{
    public static class FClipboard
    {
        //------------------------------------------------------------------------------------------------------------------------       

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr GetOpenClipboardWindow();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int GetWindowText(int hwnd, StringBuilder text, int count);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr CloseClipboard();

        //------------------------------------------------------------------------------------------------------------------------       

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------       

        #region Methods

        public static bool containsData(
            string format
            )
        {
            try
            {
                return Clipboard.ContainsData(format);
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

        public static void setData(
            string format, 
            object data
            )
        {
            try
            {
                CloseClipboard();
                // --
                Clipboard.Clear();
                Clipboard.SetData(format, data);
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

        public static void setStringData(
            string format, 
            string data
            )
        {
            try
            {
                setData(format, (object)data);
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

        public static void setText(
            string data
            )
        {
            try
            {
                // Requested Clipboard did not success Exception 방지
                CloseClipboard();
                
                // --

                // --                
                // Clipboard.Clear();
                // Clipboard.SetText(data);                
                
                // --

                // ***
                // 2017.05.25 by spike.lee
                // CLIPBRD_E_CANT_OPEN 오류 문제로 인해 SetDataObject 메소드로 변경합니다.
                // ***
                Clipboard.Clear();
                Clipboard.SetDataObject(data);
            }
            catch (Exception ex)
            {
                FDebug.throwException(new Exception(string.Format("[{0}] {1}", getOpenClipboardWindowText(), ex.Message)));
            }
            finally
            {

            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------       

        public static object getData(
            string format
            )
        {
            object obj = null;
            int cnt = 0;

            try
            {
                while (true)
                {
                    try
                    {
                        obj = Clipboard.GetData(format);
                        break;
                    }
                    catch (System.Runtime.InteropServices.COMException comEx)
                    {
                        if (cnt > 3)
                        {
                            FDebug.throwException(comEx);
                        }
                        System.Threading.Thread.Sleep(1);
                    }
                    catch (Exception inEx)
                    {
                        FDebug.throwException(inEx);
                    }
                    cnt++;
                }

                // --

                return obj;
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

        public static string getStringData(
            string format
            )
        {
            try
            {
                return (string)getData(format);
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

        public static void clear(
            )
        {
            try
            {
                Clipboard.Clear();
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

        private static string getOpenClipboardWindowText(
            )
        {
            string wndText = string.Empty;
            try
            {
                // --
                IntPtr hwnd = GetOpenClipboardWindow();
                StringBuilder sb = new StringBuilder(501);
                GetWindowText(hwnd.ToInt32(), sb, 500);
                // --
                wndText = sb.ToString();
                // --
                return wndText;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            return wndText;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------       

    }   // Class end
}   // Namespace end
