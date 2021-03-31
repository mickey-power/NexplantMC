/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMessageConverter.cs
--  Creator         : kitae
--  Create Date     : 2011.05.24
--  Description     : FAMate Core FaSecsDriver Message Converter Class
--  History         : Created by kitae at 2011.05.24
                    : Modify by spike.lee at 2011.10.06
                        - Binary to SECS Message (FIObject) Convert 추가
                        - Binary to SECS Message (FIObject) Generate 추가
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal static class FMessageConverter
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        //------------------------------------------------------------------------------------------------------------------------

        public static string convertSmsToSml(
            FXmlNode fXmlNodeSms
            )
        {
            StringBuilder smlText = null;

            try
            {
                smlText = new StringBuilder();
                
                // --
                
                if (fXmlNodeSms.hasChildNode)
                {
                    foreach (FXmlNode fXmlNodeSmg in fXmlNodeSms.selectNodes(FXmlTagSMG.E_SecsMessage))
                    {
                        smlText.Append(convertSmgToSml(fXmlNodeSmg));
                    }
                }

                // --

                return smlText.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return string.Empty; ;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string convertSmgToSml(
            FXmlNode fXmlNodeSmg
            )
        {
            StringBuilder smlText = null;

            try
            {
                smlText = new StringBuilder();
                smlText.Append ( 
                    "S" + fXmlNodeSmg.get_attrVal(FXmlTagSMG.A_Stream, FXmlTagSMG.D_Stream) +
                    "F" + fXmlNodeSmg.get_attrVal(FXmlTagSMG.A_Function, FXmlTagSMG.D_Function) +
                    "V" + fXmlNodeSmg.get_attrVal(FXmlTagSMG.A_Version, FXmlTagSMG.D_Version) +
                    (fXmlNodeSmg.get_attrVal(FXmlTagSMG.A_WBit, FXmlTagSMG.D_WBit) == "T"  ? " W" :  "")
                    );
                
                // --

                if (fXmlNodeSmg.hasChildNode)
                {
                    foreach (FXmlNode fXmlNodeSit in fXmlNodeSmg.selectNodes(FXmlTagSIT.E_SecsItem))
                    {
                        convertSitToSml(smlText, fXmlNodeSit, 0);
                    }
                    if (fXmlNodeSmg.fChildNodes[0].fChildNodes.count == 0)
                    {
                        smlText.Insert(
                             (smlText.Length -
                              ((FXmlNode)fXmlNodeSmg.fChildNodes[0]).get_attrVal(FXmlTagSIT.A_Name, FXmlTagSIT.D_Name).ToString().Length - 7),
                            ".");
                        smlText.AppendLine();
                    }
                    else
                    {
                        smlText.AppendLine(".");
                    }
                    
                }
                else
                {
                    smlText.AppendLine(".");
                }
                smlText.AppendLine();
                return smlText.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                smlText = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void convertSitToSml(
            StringBuilder smlText, 
            FXmlNode fXmlNodeSit,
            int depth
            )
        {
            FFormat fFormat;            
            int length = 0;
            string depthString = string.Empty;
            string value = string.Empty;

            try
            {
                depth++;
                depthString = depthString.PadRight(depth * 2, ' ');
                smlText.AppendLine();

                // --

                fFormat = FEnumConverter.toFormat(fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Format, FXmlTagSIT.D_Format));
                length = int.Parse(fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length));                    

                // --

                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                {
                    if (length == 0)
                    {
                        smlText.Append(depthString + "<" + FFormatShortName.L.ToString() + ">");                        
                        smlText.Append("    // " + fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Name, FXmlTagSIT.D_Name));
                    }
                    else
                    {
                        smlText.Append(depthString + "<" + FFormatShortName.L.ToString());
                        if (length > 1)
                        {
                            smlText.Append(" [" + length.ToString() + "]");
                        }
                        smlText.Append("    // " + fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Name, FXmlTagSIT.D_Name));

                        // --                        

                        foreach (FXmlNode fXmlNodeChild in fXmlNodeSit.selectNodes(FXmlTagSIT.E_SecsItem))
                        {
                            convertSitToSml(smlText, fXmlNodeChild, depth);
                        }

                        // --                        

                        smlText.AppendLine();
                        smlText.Append(depthString + ">");
                    }                    
                }
                else
                {
                    smlText.Append(depthString + "<" + FEnumConverter.fromFormat(fFormat));
                    
                    // --

                    if (fFormat == FFormat.A2 || fFormat == FFormat.Ascii || fFormat == FFormat.JIS8)
                    {
                        value = FValueConverter.toTransformedEncodingValue(
                            fFormat,
                            fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Value, FXmlTagSIT.D_Value),
                            fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Transformer, FXmlTagSIT.D_Transformer),
                            ref length
                            );
                        // --
                        if (length > 1)
                        {
                            smlText.Append(" [" + length.ToString() + "]");
                        }
                        // --
                        if (length == 0)
                        {                         
                            smlText.Append(">");
                        }
                        else
                        {
                            smlText.Append(" '" + value.Replace(Convert.ToChar(0).ToString(), @"\00") + "'>");
                        }
                    }
                    else
                    {
                        value = FValueConverter.toTransformedStringValue(
                            fFormat,
                            fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Value, FXmlTagSIT.D_Value),
                            fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Transformer, FXmlTagSIT.D_Transformer),
                            ref length
                            );
                        // --
                        if (length > 1)
                        {
                            smlText.Append(" [" + length.ToString() + "]");
                        }
                        // --
                        if (length == 0)
                        {                            
                            smlText.Append(">");
                        }
                        else
                        {
                            smlText.Append(" " + value + ">");
                        }                        
                    }
                    smlText.Append("    // " + fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Name, FXmlTagSIT.D_Name));
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

        public static string convertHmsToVfei(
            FXmlNode fXmlNodeHms
            )
        {
            StringBuilder vfeiText = null;

            try
            {
                vfeiText = new StringBuilder();
                
                // --

                if (fXmlNodeHms.hasChildNode)
                {
                    foreach (FXmlNode fXmlNodeHmg in fXmlNodeHms.selectNodes(FXmlTagHMG.E_HostMessage))
                    {
                        vfeiText.Append(convertHmgToVfei(fXmlNodeHmg));
                    }
                }

                // --

                return vfeiText.ToString();
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

        public static string convertHmgToVfei(
            FXmlNode fXmlNodeHmg,
            string machineId,
            int tid
            )
        {
            StringBuilder vfeiText = null;

            try
            {
                vfeiText = new StringBuilder();
                vfeiText.Append(
                    "CMD/A='" + fXmlNodeHmg.get_attrVal(FXmlTagHMG.A_Command, FXmlTagHMG.D_Command) + "' " +
                    "MID/A='" + machineId + "' " +
                    "MTY/A='" + fXmlNodeHmg.get_attrVal(FXmlTagHMG.A_HostMessageType, FXmlTagHMG.D_HostMessageType) + "' " +
                    "TID/U4=" + tid
                    );

                // --

                if (fXmlNodeHmg.hasChildNode)
                {
                    foreach (FXmlNode fXmlNodeHit in fXmlNodeHmg.selectNodes(FXmlTagHIT.E_HostItem))
                    {
                        vfeiText.Append(" ");
                        convertHitToVfei(vfeiText, fXmlNodeHit);
                    }
                    vfeiText.AppendLine();
                }
                else
                {
                    vfeiText.AppendLine();
                }
                vfeiText.AppendLine();

                // --

                return vfeiText.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                vfeiText = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string convertHmgToVfei(
           FXmlNode fXmlNodeHmg
           )
        {
            try
            {
                return convertHmgToVfei(fXmlNodeHmg, string.Empty, 0);
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

        public static string convertHdmgToVfei(
            FXmlNode fXmlNodeHdmg
            )
        {
            StringBuilder vfeiText = null;

            try
            {
                vfeiText = new StringBuilder();
                vfeiText.Append(
                    "CMD/A='" + fXmlNodeHdmg.get_attrVal(FXmlTagHDMG.A_Command, FXmlTagHDMG.D_Command) + "' " +
                    "MID/A='" + fXmlNodeHdmg.get_attrVal(FXmlTagHDMG.A_MachineId, FXmlTagHDMG.D_MachineId) + "' " +
                    "MTY/A='" + fXmlNodeHdmg.get_attrVal(FXmlTagHDMG.A_HostMessageType, FXmlTagHDMG.D_HostMessageType) + "' " +
                    "TID/U4=" + fXmlNodeHdmg.get_attrVal(FXmlTagHDMG.A_TID, FXmlTagHDMG.D_TID)
                    );

                // --

                if (fXmlNodeHdmg.hasChildNode)
                {
                    foreach (FXmlNode fXmlNodeHit in fXmlNodeHdmg.selectNodes(FXmlTagHIT.E_HostItem))
                    {
                        vfeiText.Append(" ");
                        convertHitToVfei(vfeiText, fXmlNodeHit);
                    }
                    vfeiText.AppendLine();
                }
                else
                {
                    vfeiText.AppendLine();
                }
                vfeiText.AppendLine();

                // --

                return vfeiText.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                vfeiText = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void convertHitToVfei(
            StringBuilder vfeiText,
            FXmlNode fXmlNodeHit
            )
        {
            FFormat fParentFormat;
            FFormat fFormat;            
            string name = string.Empty;            
            string value = string.Empty;
            int length = 0;
            int i = 0;            
            
            try
            {   
                fFormat = FEnumConverter.toFormat(fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format));                
                length = int.Parse(fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length));
                name = fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Name, FXmlTagHIT.D_Name);                

                // --

                if (fXmlNodeHit.fParentNode.name == FXmlTagHIT.E_HostItem)
                {
                    fParentFormat = FEnumConverter.toFormat(fXmlNodeHit.fParentNode.get_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format));
                    if (fParentFormat != FFormat.AsciiList)
                    {
                        vfeiText.Append(name + "/" + FEnumConverter.fromFormat(fFormat == FFormat.AsciiList ? FFormat.Ascii : fFormat));
                        // --
                        if (fFormat == FFormat.Ascii || fFormat == FFormat.A2 || fFormat == FFormat.JIS8 || fFormat == FFormat.Char)
                        {
                            vfeiText.Append("=");
                        }
                    }                    
                }
                else
                {
                    vfeiText.Append(name + "/" + FEnumConverter.fromFormat(fFormat));
                    // --
                    if (fFormat == FFormat.Ascii || fFormat == FFormat.A2 || fFormat == FFormat.JIS8 || fFormat == FFormat.Char)
                    {
                        vfeiText.Append("=");
                    }
                }                

                // --                

                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                {
                    if (length == 0)
                    {
                        vfeiText.Append("=''");
                    }
                    else
                    {
                        if (length > 1)
                        {
                            vfeiText.Append("[" + length + "]=[");
                        }
                        else
                        {
                            vfeiText.Append("=");
                        }
                        
                        // --

                        foreach (FXmlNode fXmlNodeChild in fXmlNodeHit.selectNodes(FXmlTagHIT.E_HostItem))
                        {
                            convertHitToVfei(vfeiText, fXmlNodeChild);
                            // --
                            i++;
                            if (i != length)
                            {
                                vfeiText.Append(" ");
                            }
                        }

                        // --
                        
                        if (length > 1)
                        {
                            vfeiText.Append("]");
                        }
                    }
                }
                else
                {
                    if (length == 0)
                    {
                        vfeiText.Append("=''");
                    }
                    else
                    {
                        if (fFormat == FFormat.Ascii || fFormat == FFormat.A2 || fFormat == FFormat.JIS8 || fFormat == FFormat.Char)
                        {
                            value = FValueConverter.toTransformedEncodingValue(
                                fFormat,
                                fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value),
                                fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Transformer, FXmlTagHIT.D_Transformer),
                                ref length
                                );
                            // --
                            vfeiText.Append("'" + value + "'");
                        }
                        else
                        {
                            if (length > 1)
                            {
                                vfeiText.Append("[" + length + "]=[");
                            }
                            else
                            {
                                vfeiText.Append("=");
                            }

                            // --
                            
                            value = FValueConverter.toTransformedStringValue(
                                fFormat,
                                fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value),
                                fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Transformer, FXmlTagHIT.D_Transformer),
                                ref length
                                );
                            // --
                            vfeiText.Append(value);
                            
                            // --

                            if (length > 1)
                            {
                                vfeiText.Append("]");
                            }
                        }
                    }
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

        public static string convertBinToSml(
            int stream,
            int function,
            bool wbit,
            byte[] body,
            UInt32 length,
            ref FResultCode fResultCode,
            ref string resultMessage
            )
        {
            StringBuilder smlText = null;
            UInt32 len = 0;
            UInt32 index = 0;

            try
            {
                fResultCode = FResultCode.Success;
                resultMessage = string.Empty;

                // --

                smlText = new StringBuilder();
                smlText.Append(
                     "S" + stream +
                     "F" + function +
                     ((wbit) ? " W" : "")
                     );     

                // --

                if (body != null)
                {
                    len = (UInt32)(length - 10);    // Header 길이 제거             
                    if (!convertBinToSmlBody(smlText, body, len, ref index, 0) || len != index)
                    {
                        fResultCode = FResultCode.Error;
                        resultMessage = string.Format(FConstants.err_m_0015, "Message Structure");                        
                    }
                }

                // --

                smlText.Append(".");

                // --

                return smlText.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                smlText = null;
            }           
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static bool convertBinToSmlBody(
            StringBuilder smlText,
            byte[] body,
            UInt32 length,
            ref UInt32 index,
            int depth            
            )
        {
            string val = string.Empty;
            string depthString = string.Empty;    
            FFormat fFormat;                        
            int lenBytes = 0;
            UInt32 formatBytes = 0;
            UInt32 len = 0;
            UInt32 itemLen = 0;
            byte[] lengthArr;

            try
            {
                depth++;
                depthString = depthString.PadRight(depth * 2, ' ');
                smlText.AppendLine();
                
                // --
                
                if (index >= length)
                {
                    return false;
                }
                
                // --
                
                fFormat = FEnumConverter.toFormat(body[index] >> 2);
                if (fFormat == FFormat.Unknown)
                {
                    return false;
                }
                
                // --
                
                lenBytes = body[index] & 0x03;
                index++;
                
                // --

                if (lenBytes == 0 || index + lenBytes - 1 >= length)
                {
                    return false;
                }
                
                // --

                lengthArr = new byte[4];
                if (lenBytes == 1)
                {
                    lengthArr[0] = body[index];
                }
                else if (lenBytes == 2)
                {
                    lengthArr[0] = body[index + 1];
                    lengthArr[1] = body[index];
                }
                else
                {
                    lengthArr[0] = body[index + 2];
                    lengthArr[1] = body[index + 1];
                    lengthArr[2] = body[index];
                }
                index += (UInt32)lenBytes;
                len = FByteConverter.toUInt32(lengthArr, false);

                // --
                
                smlText.Append(depthString + "<" + FEnumConverter.fromFormat(fFormat));
                // --                
                if (fFormat == FFormat.List)
                {
                    smlText.Append((len <= 1 ? "" : "[" + len + "] "));                                        
                    // --
                    for (int i = 0; i < len; i++)
                    {
                        if (!convertBinToSmlBody(smlText, body, length, ref index, depth))
                        {
                            return false;
                        }
                    }                    
                    // --
                    if (len >= 1)
                    {
                        smlText.AppendLine();
                        smlText.Append(depthString);
                    } 
                    // --
                    smlText.Append(">");
                }
                else
                {                    
                    if (index + len - 1 >= length)
                    {
                        return false;
                    }

                    // --

                    formatBytes = FValueConverter.getFormatBytes(fFormat);
                    itemLen = len / formatBytes;
                    smlText.Append(((itemLen) <= 1 ? "" : "[" + (itemLen) + "]"));

                    // --

                    if (len % formatBytes != 0)
                    {
                        return false;
                    }

                    // --

                    if (itemLen > 0)
                    {
                        smlText.Append(" ");
                    }
                    val = FValueConverter.fromBinValue(fFormat, body, index, (int)(itemLen), formatBytes);
                    index += len;

                    // --

                    if (fFormat == FFormat.Ascii || fFormat == FFormat.A2 || fFormat == FFormat.JIS8)
                    {
                        if (len != 0)
                        {
                            smlText.Append(@"'" + val + @"'");
                        }                        
                    }
                    else
                    {
                        smlText.Append(val);
                    }
                    // --                                        
                    smlText.Append(">");                   
                }                
                
                // --                               

                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                lengthArr = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string convertBinToString(
            byte[] data,
            int columnLength
            )
        {
            StringBuilder val = null;

            try
            {
                val = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    val.Append(data[i].ToString("X2"));
                    // --
                    if (i < data.Length - 1)
                    {
                        if ((i + 1) % columnLength == 0)
                        {
                            val.Append(Environment.NewLine);
                        }
                        else
                        {
                            val.Append(" ");
                        }
                    }
                }
                return val.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                val = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string convertSmgToXmlToWisol(
            FXmlNode fXmlNodeSmg
            )
        {
            StringBuilder xmlText = null;

            try
            {
                xmlText = new StringBuilder();
                xmlText.Append(
                    string.Format("[S{0}F{1} V{2}] {3}",
                        fXmlNodeSmg.get_attrVal(FXmlTagSMG.A_Stream, FXmlTagSMG.D_Stream),
                        fXmlNodeSmg.get_attrVal(FXmlTagSMG.A_Function, FXmlTagSMG.D_Function),
                        fXmlNodeSmg.get_attrVal(FXmlTagSMG.A_Version, FXmlTagSMG.D_Version),
                        fXmlNodeSmg.get_attrVal(FXmlTagSMG.A_Name, FXmlTagSMG.D_Name)
                        ));

                // --

                if (fXmlNodeSmg.hasChildNode)
                {
                    foreach (FXmlNode fXmlNodeSit in fXmlNodeSmg.selectNodes(FXmlTagSIT.E_SecsItem))
                    {
                        convertSitToXmlToWisol(xmlText, fXmlNodeSit, 0);
                    }
                    if (fXmlNodeSmg.fChildNodes[0].fChildNodes.count == 0)
                    {
                        xmlText.Insert(
                             (xmlText.Length -
                              ((FXmlNode)fXmlNodeSmg.fChildNodes[0]).get_attrVal(FXmlTagSIT.A_Name, FXmlTagSIT.D_Name).ToString().Length - 7),
                            ".");
                        xmlText.AppendLine();
                    }
                    else
                    {
                        xmlText.AppendLine(".");
                    }

                }
                else
                {
                    xmlText.AppendLine(".");
                }
                xmlText.AppendLine();
                return xmlText.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                xmlText = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void convertSitToXmlToWisol(
            StringBuilder smlText,
            FXmlNode fXmlNodeSit,
            int depth
            )
        {
            FFormat fFormat;
            int length = 0;
            string name = string.Empty;
            string desc = string.Empty;
            string depthString = string.Empty;
            string value = string.Empty;

            try
            {
                depth++;
                depthString = depthString.PadRight(depth * 2, ' ');
                smlText.AppendLine();

                // --

                name = fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Name, FXmlTagSIT.D_Name);
                desc = fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Description, FXmlTagSIT.D_Description);
                fFormat = FEnumConverter.toFormat(fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Format, FXmlTagSIT.D_Format));
                length = int.Parse(fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length));

                // --

                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                {
                    // ***
                    // <L[3] L Desc=[Wafer Info]> 
                    // ***
                    smlText.Append(depthString +
                            string.Format("<{0}[{1}] {2}{3}>",
                                FFormatShortName.L.ToString(),
                                length,
                                name,
                                desc == string.Empty ? string.Empty : " Desc=[" + desc + "]"
                                ));

                    // --

                    if (length > 0)
                    {
                        foreach (FXmlNode fXmlNodeChild in fXmlNodeSit.selectNodes(FXmlTagSIT.E_SecsItem))
                        {
                            convertSitToXmlToWisol(smlText, fXmlNodeChild, depth);
                        }
                    }
                }
                else
                {
                    if (fFormat == FFormat.A2 || fFormat == FFormat.Ascii || fFormat == FFormat.JIS8)
                    {
                        value = FValueConverter.toTransformedEncodingValue(
                            fFormat,
                            fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Value, FXmlTagSIT.D_Value),
                            fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Transformer, FXmlTagSIT.D_Transformer),
                            ref length
                            );

                        // --

                        // ***
                        // <A[3] WAFER_ID="001" Desc=[Wafer Id]> 
                        // ***
                        smlText.Append(depthString +
                            string.Format("<{0}[{1}] {2}=\"{3}\"{4}>",
                                FEnumConverter.fromFormat(fFormat),
                                length,
                                name,
                                value.Replace(Convert.ToChar(0).ToString(), @"\00"),
                                desc == string.Empty ? string.Empty : " Desc=[" + desc + "]"
                                ));
                    }
                    else
                    {
                        value = FValueConverter.toTransformedStringValue(
                            fFormat,
                            fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Value, FXmlTagSIT.D_Value),
                            fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Transformer, FXmlTagSIT.D_Transformer),
                            ref length
                            );

                        // --

                        // ***
                        // <U2[1] CONTROL_MODE="5" Desc=[3:Offline,4:Local,5:Remote]> 
                        // ***
                        smlText.Append(depthString +
                            string.Format("<{0}[{1}] {2}=\"{3}\"{4}>",
                                FEnumConverter.fromFormat(fFormat),
                                length,
                                name,
                                value,
                                desc == string.Empty ? string.Empty : " Desc=[" + desc + "]"
                                ));
                    }
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

        public static string convertHmgToXmlToWisol(
            FXmlNode fXmlNodeHmg
            )
        {
            const string E_MESSAGE = "MESSAGE";
            const string E_HEADER = "HEADER";
            const string E_MSG_ID = "MSG_ID";
            const string E_DATE = "DATE";
            // --
            StringBuilder xmlText = null;
            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlNodeMsg = null;
            FXmlNode fXmlNode = null;
            FXmlNode fXmlNodeMsgId = null;
            FXmlNode fXmlNodeDate = null;


            try
            {
                xmlText = new StringBuilder();
                xmlText.AppendLine(
                    "[" +
                    fXmlNodeHmg.get_attrVal(FXmlTagHMG.A_Command, FXmlTagHMG.D_Command) + " V" +
                    fXmlNodeHmg.get_attrVal(FXmlTagHMG.A_Version, FXmlTagHMG.D_Version) +
                    "] " +
                    fXmlNodeHmg.get_attrVal(FXmlTagHMG.A_Name, FXmlTagHMG.D_Name) + " " +
                    fXmlNodeHmg.get_attrVal(FXmlTagHMG.A_HostMessageType, FXmlTagHMG.A_HostMessageType)
                    );

                // --

                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;

                // --

                fXmlNodeMsg = fXmlDoc.createNode(E_MESSAGE);
                foreach (FXmlNode x in fXmlNodeHmg.selectNodes(FXmlTagHIT.E_HostItem))
                {
                    convertHitToXmlToWisol(fXmlDoc, fXmlNodeMsg, x);
                }

                // --

                // ***
                // Generate Header
                // MSG_ID, DATE Item이 존재하고 값이 설정되어 있지 않을 경우 설정한다.
                // ***
                fXmlNodeMsgId = fXmlNodeMsg.selectSingleNode(E_HEADER + "/" + E_MSG_ID);
                if (fXmlNodeMsgId != null)
                {
                    fXmlNode = fXmlNodeHmg.selectSingleNode(
                        FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_Name + "='" + E_HEADER + "']/" +
                        FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_Name + "='" + E_MSG_ID + "']"
                        );
                    if (
                        fXmlNode != null &&
                        FEnumConverter.toFormat(fXmlNode.get_attrVal(FXmlTagHITL.A_Format, FXmlTagHITL.D_Format)) == FFormat.Ascii &&
                        fXmlNode.get_attrVal(FXmlTagHITL.A_Value, FXmlTagHITL.D_Value) == string.Empty
                        )
                    {
                        fXmlNodeMsgId.set_attrVal(
                            FXmlTagHITL.A_Value,
                            FXmlTagHITL.D_Value,
                            fXmlNodeHmg.get_attrVal(FXmlTagHMGL.A_Command, FXmlTagHMGL.D_Command)
                            );
                    }
                }
                // --
                fXmlNodeDate = fXmlNodeMsg.selectSingleNode(E_HEADER + "/" + E_DATE);
                if (fXmlNodeDate != null)
                {
                    fXmlNode = fXmlNodeHmg.selectSingleNode(
                        FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_Name + "='" + E_HEADER + "']/" +
                        FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_Name + "='" + E_DATE + "']"
                        );
                    if (
                        fXmlNode != null &&
                        FEnumConverter.toFormat(fXmlNode.get_attrVal(FXmlTagHITL.A_Format, FXmlTagHITL.D_Format)) == FFormat.Ascii &&
                        fXmlNode.get_attrVal(FXmlTagHITL.A_Value, FXmlTagHITL.D_Value) == string.Empty
                        )
                    {
                        fXmlNodeDate.set_attrVal(
                            FXmlTagHITL.A_Value,
                            FXmlTagHITL.D_Value,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                    }
                }

                // --

                xmlText.AppendLine(fXmlNodeMsg.xmlToString(true));
                xmlText.AppendLine();
                return xmlText.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeMsgId = null;
                fXmlNodeDate = null;
                fXmlNode = null;
                // --
                if (fXmlDoc != null)
                {
                    fXmlDoc.Dispose();
                    fXmlDoc = null;
                }
                xmlText = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void convertHitToXmlToWisol(
            FXmlDocument fXmlDoc,
            FXmlNode fXmlNodeParent,
            FXmlNode fXmlNodeTit
            )
        {
            FXmlNode fXmlNode = null;
            string name = string.Empty;
            FFormat fFormat = FFormat.Unknown;

            try
            {
                name = fXmlNodeTit.get_attrVal(FXmlTagHIT.A_Name, FXmlTagHIT.D_Name);
                fFormat = FEnumConverter.toFormat(fXmlNodeTit.get_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format));

                // --

                fXmlNode = fXmlNodeParent.appendChild(fXmlDoc.createNode(name));
                // --
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                {
                    foreach (FXmlNode x in fXmlNodeTit.selectNodes(FXmlTagHIT.E_HostItem))
                    {
                        convertHitToXmlToWisol(fXmlDoc, fXmlNode, x);
                    }
                }
                else
                {
                    fXmlNode.innerText = FValueConverter.toTransformedEncodingValue(
                        fFormat,
                        fXmlNodeTit.get_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value),
                        fXmlNodeTit.get_attrVal(FXmlTagHIT.A_Transformer, FXmlTagHIT.D_Transformer)
                        );
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string convertSmglToXml(
            FXmlNode fXmlNodeSmgl
            )
        {
            StringBuilder xmlText = null;
            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlNodeMsg = null;

            try
            {
                xmlText = new StringBuilder();
                // --
                xmlText.AppendLine(
                    string.Format("[S{0}F{1} V{2}] {3}",
                        fXmlNodeSmgl.get_attrVal(FXmlTagSMGL.A_Stream, FXmlTagSMGL.D_Stream),
                        fXmlNodeSmgl.get_attrVal(FXmlTagSMGL.A_Function, FXmlTagSMGL.D_Function),
                        fXmlNodeSmgl.get_attrVal(FXmlTagSMGL.A_Version, FXmlTagSMGL.D_Version),
                        fXmlNodeSmgl.get_attrVal(FXmlTagSMGL.A_Name, FXmlTagSMGL.D_Name)
                        ));

                // --

                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;
                
                // --

                fXmlNodeMsg = fXmlDoc.createNode("MESSAGE");
                // --
                foreach (FXmlNode x in fXmlNodeSmgl.selectNodes(FXmlTagSITL.E_SecsItem))
                {
                    convertSitlToXml(fXmlDoc, fXmlNodeMsg, x);
                }
                // --
                xmlText.AppendLine(fXmlNodeMsg.xmlToString(true));
                xmlText.AppendLine();

                // --

                return xmlText.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeMsg = null;
                if (fXmlDoc != null)
                {
                    fXmlDoc.Dispose();
                    fXmlDoc = null;
                }
                xmlText = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string convertSitlToXml(
            FXmlDocument fXmlDoc, 
            FXmlNode fXmlNodeParent, 
            FXmlNode fXmlNodeSitl
            )
        {
            FFormat fFormat = FFormat.List;
            int length = 0;
            FXmlNode fXmlNode = null;

            try
            {
                fFormat = FEnumConverter.toFormat(fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Format, FXmlTagSITL.D_Format));
                
                // --

                fXmlNode = fXmlNodeParent.appendChild(
                    fXmlDoc.createNode(fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Name, FXmlTagSITL.D_Name))
                    );
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                {
                    foreach (FXmlNode x in fXmlNodeSitl.selectNodes(FXmlTagSITL.E_SecsItem))
                    {
                        convertSitlToXml(fXmlDoc, fXmlNode, x); 
                    }
                }
                else if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                {
                    fXmlNode.innerText = FValueConverter.toDataConversionedEncodingValue(
                        fFormat,
                        fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Value, FXmlTagSITL.D_Value),
                        fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Transformer, FXmlTagSITL.D_Transformer),
                        fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_DataConversionSetExpression, FXmlTagSITL.D_DataConversionSetExpression),
                        ref length
                        );
                }
                else
                {
                    fXmlNode.innerText = FValueConverter.toDataConversionStringValue(
                        fFormat,
                        fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Value, FXmlTagSITL.D_Value),
                        fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_Transformer, FXmlTagSITL.D_Transformer),
                        fXmlNodeSitl.get_attrVal(FXmlTagSITL.A_DataConversionSetExpression, FXmlTagSITL.D_DataConversionSetExpression),
                        ref length
                        );
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string convertHmglToXml(
            FXmlNode fXmlNodeHmgl
            )
        {
            StringBuilder xmlText = null;
            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlNodeMsg = null;

            try
            {
                xmlText = new StringBuilder();
                // --
                xmlText.AppendLine(
                    "[" +
                    fXmlNodeHmgl.get_attrVal(FXmlTagHMGL.A_Command, FXmlTagHMGL.D_Command) + " V" +
                    fXmlNodeHmgl.get_attrVal(FXmlTagHMGL.A_Version, FXmlTagHMGL.D_Version) +
                    "] " +
                    fXmlNodeHmgl.get_attrVal(FXmlTagHMGL.A_Name, FXmlTagHMGL.D_Name) + " " +
                    fXmlNodeHmgl.get_attrVal(FXmlTagHMGL.A_HostMessageType, FXmlTagHMGL.D_HostMessageType)
                    );

                // --

                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;

                // --

                fXmlNodeMsg = fXmlDoc.createNode("MESSAGE");
                // --
                foreach (FXmlNode x in fXmlNodeHmgl.selectNodes(FXmlTagHITL.E_HostItem))
                {
                    convertHitlToXml(fXmlDoc, fXmlNodeMsg, x);
                }
                // --
                xmlText.AppendLine(fXmlNodeMsg.xmlToString(true));
                xmlText.AppendLine();

                // --

                return xmlText.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeMsg = null;
                if (fXmlDoc != null)
                {
                    fXmlDoc.Dispose();
                    fXmlDoc = null;
                }
                xmlText = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string convertHitlToXml(
            FXmlDocument fXmlDoc,
            FXmlNode fXmlNodeParent,
            FXmlNode fXmlNodeHitl
            )
        {
            FFormat fFormat = FFormat.List;
            int length = 0;
            FXmlNode fXmlNode = null;

            try
            {
                fFormat = FEnumConverter.toFormat(fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Format, FXmlTagHITL.D_Format));

                // --

                fXmlNode = fXmlNodeParent.appendChild(
                    fXmlDoc.createNode(fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Name, FXmlTagHITL.D_Name))
                    );
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                {
                    foreach (FXmlNode x in fXmlNodeHitl.selectNodes(FXmlTagHITL.E_HostItem))
                    {
                        convertHitlToXml(fXmlDoc, fXmlNode, x);
                    }
                }
                else if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2 || fFormat == FFormat.Char)
                {
                    fXmlNode.innerText = FValueConverter.toDataConversionedEncodingValue(
                        fFormat,
                        fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Value, FXmlTagHITL.D_Value),
                        fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Transformer, FXmlTagHITL.D_Transformer),
                        fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_DataConversionSetExpression, FXmlTagHITL.D_DataConversionSetExpression),
                        ref length
                        );
                }
                else
                {
                    fXmlNode.innerText = FValueConverter.toDataConversionStringValue(
                        fFormat,
                        fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Value, FXmlTagHITL.D_Value),
                        fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_Transformer, FXmlTagHITL.D_Transformer),
                        fXmlNodeHitl.get_attrVal(FXmlTagHITL.A_DataConversionSetExpression, FXmlTagHITL.D_DataConversionSetExpression),
                        ref length
                        );
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return string.Empty;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
