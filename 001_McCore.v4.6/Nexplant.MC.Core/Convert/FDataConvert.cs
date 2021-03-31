/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDataConvert.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.13
--  Description     : FAMate Core FaCommon Data Convert Class
--  History         : Created by spike.lee at 2011.01.13
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public static class FDataConvert
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        static FDataConvert(
            )
        {

        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static string defaultNowDateTimeToString(
            )
        {
            try
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
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

        public static string defaultDataTimeFormating(
            string dateTime // 항상 17자리가 들어와야합.
            )
        {
            string dt = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(dateTime))
                {
                    dt = dateTime.PadRight(17, '0');

                    // --

                    return dt.Substring(0, 4) + "-" + dt.Substring(4, 2) + "-" + dt.Substring(6, 2) + " " + dt.Substring(8, 2) + ":" + dt.Substring(10, 2) + ":" + dt.Substring(12, 2) + "." + dt.Substring(14, 3);
                }
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

        public static string volumeSizeToString(
            long byteCount,
            FVolumnOption option
            )
        {
            try
            {
                if ((option == FVolumnOption.TeraByte) ||
                    (option == FVolumnOption.Auto && byteCount >= 1099511627776))
                {
                    return string.Format("{0:0.##}TB", byteCount / 1099511627776.0);
                }
                else if ((option == FVolumnOption.GigaByte) ||
                    (option == FVolumnOption.Auto && byteCount >= 1073741824))
                {
                    return string.Format("{0:0.##}GB", byteCount / 1073741824.0);
                }
                else if ((option == FVolumnOption.MegaByte) ||
                    (option == FVolumnOption.Auto && byteCount >= 1048576))
                {
                    return string.Format("{0}MB", Math.Ceiling(byteCount / 1048576.0));
                }
                else if ((option == FVolumnOption.KiloByte) ||
                    (option == FVolumnOption.Auto && byteCount >= 1024))
                {
                    return string.Format("{0}KB", Math.Ceiling(byteCount / 1024.0));
                }
                else if ((option == FVolumnOption.Byte) ||
                    (option == FVolumnOption.Auto && byteCount > 0 && byteCount < 1024))
                {
                    return string.Format("{0}Bytes", byteCount);
                }
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

        public static string volumeSizeToString(
            long byteCount
            )
        {
            try
            {
                return volumeSizeToString(byteCount, FVolumnOption.Auto);
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

        public static DateTime stringToDateTime(
            string dateTime
            )
        {
            DateTime result;

            try
            {
                return DateTime.TryParse(defaultDataTimeFormating(dateTime), out result) ? result : new DateTime();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return new DateTime();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static bool trySpanTime(
            string startTime,
            string endTime,
            out TimeSpan result
            )
        {
            DateTime dtStart, dtEnd;
            bool bStartTime, bEndTime;
            // --
            result = new TimeSpan();

            try
            {
                bStartTime = DateTime.TryParse(defaultDataTimeFormating(startTime), out dtStart);
                bEndTime = DateTime.TryParse(defaultDataTimeFormating(endTime), out dtEnd);
                
                if (bStartTime && bEndTime)
                {
                    result = dtEnd - dtStart;
                    return true;
                }
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

        public static FXmlNode stringToXmlNode(
            string data
            )
        {
            FXmlDocument fDoc = null;

            try
            {
                fDoc = new FXmlDocument();
                fDoc.preserveWhiteSpace = false;
                fDoc.loadXml(string.Format("<node>{0}</node>", data));

                return fDoc.fFirstChild.fFirstChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fDoc = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode stringToXmlNode(
            bool isTrs,
            string data
            )
        {
            FXmlDocument fDoc = null;
            int xmlHeaderIdx = 0;

            try
            {
                // --
                if (isTrs)
                {
                    // --
                    // <?xml version="1.0" encoding="UTF-8"?>
                    // Trs의 경우 Xml 선언문을 제거한후 Load 한다. 
                    // Add by Jeff.Kim 2015.08.18 in Mexico
                    xmlHeaderIdx = data.IndexOf("?>");
                    if (xmlHeaderIdx > 0)
                    {
                        data = data.Substring(xmlHeaderIdx + 2);
                    }
                }

                // --

                fDoc = new FXmlDocument();
                fDoc.preserveWhiteSpace = false;
                fDoc.loadXml(string.Format("<node>{0}</node>", data));

                return fDoc.fFirstChild.fFirstChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fDoc = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static byte[] stringToBytes(
            string data
            )
        {
            ASCIIEncoding ascii = null;

            try
            {
                ascii = new ASCIIEncoding();
                return ascii.GetBytes(data);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                ascii = null;
            }
            return null;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
