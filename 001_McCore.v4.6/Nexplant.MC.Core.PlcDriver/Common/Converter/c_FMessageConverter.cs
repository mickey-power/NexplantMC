/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMessageConverter.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.16
--  Description     : FAMate Core FaPlcDriver Message Converter Class
--  History         : Created by Jeff.Kim at 2013.07.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal static class FMessageConverter
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

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
                        if (fFormat == FFormat.Ascii || fFormat == FFormat.A2 || fFormat == FFormat.JIS8)
                        {
                            vfeiText.Append("=");
                        }
                    }                    
                }
                else
                {
                    vfeiText.Append(name + "/" + FEnumConverter.fromFormat(fFormat));
                    // --
                    if (fFormat == FFormat.Ascii || fFormat == FFormat.A2 || fFormat == FFormat.JIS8)
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
                        if (fFormat == FFormat.Ascii || fFormat == FFormat.A2 || fFormat == FFormat.JIS8)
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
