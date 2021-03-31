/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMessageConverter.cs
--  Creator         : spike.lee
--  Create Date     : 2015.06.16
--  Description     : FAMate Core FaOpcDriver Message Converter Class
--  History         : Created by spike.lee at 2015.06.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
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
        // Add by Jeff.Kim 2015.12.15
        // MES Lot 복구시에 Trs 형식으로 로그를 전달 할수 있도록 하기위해 추가
        public static string convertHmlToTrs(
            FXmlNode fXmlNodeHml
            )
        {
            StringBuilder trsText = null;

            try
            {
                trsText = new StringBuilder();

                // --

                if (fXmlNodeHml.hasChildNode)
                {
                    foreach (FXmlNode fXmlNodeHms in fXmlNodeHml.selectNodes(FXmlTagHMS.E_HostMessages))
                    {
                        if (fXmlNodeHms.hasChildNode)
                        {
                            foreach (FXmlNode fXmlNodeHmg in fXmlNodeHms.selectNodes(FXmlTagHMG.E_HostMessage))
                            {
                                trsText.Append(convertHmgToTrs(fXmlNodeHmg));
                                trsText.Append(Environment.NewLine);
                            }
                        }
                    }
                }

                // --

                return trsText.ToString();
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
        // Add by Jeff.Kim 2015.12.15
        // MES Lot 복구시에 Trs 형식으로 로그를 전달 할수 있도록 하기위해 추가
        public static string convertHmsToTrs(
            FXmlNode fXmlNodeHms
            )
        {
            StringBuilder trsText = null;

            try
            {
                trsText = new StringBuilder();

                // --

                if (fXmlNodeHms.hasChildNode)
                {
                    foreach (FXmlNode fXmlNodeHmg in fXmlNodeHms.selectNodes(FXmlTagHMG.E_HostMessage))
                    {
                        trsText.Append(convertHmgToTrs(fXmlNodeHmg));
                        trsText.Append(Environment.NewLine);
                    }
                }

                // --

                return trsText.ToString();
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
        // Add by Jeff.Kim 2015.12.15
        // MES Lot 복구시에 Trs 형식으로 로그를 전달 할수 있도록 하기위해 추가
        public static string convertHmgToTrs(
            FXmlNode fHdmg
            )
        {
            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlMsgNode = null;
            FXmlNode fXmlNode = null;
            FXmlNode fXmlBoby = null;
            // --
            string command = string.Empty;

            try
            {
                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;

                // --

                command = fHdmg.get_attrVal(FXmlTagHDMG.A_Command, FXmlTagHDMG.D_Command);

                // --                

                fXmlMsgNode = fXmlDoc.createNode("MESSAGE");
                fXmlMsgNode.set_attrVal(FXmlTagTRS.A_Version, FXmlTagTRS.D_Version, "1.0");
                fXmlMsgNode.set_attrVal(FXmlTagTRS.A_FunctionName, FXmlTagTRS.D_FunctionName, command);
                // --
                fXmlBoby = fXmlMsgNode.set_elem(FXmlTagTRS.E_Body);
                // --
                fXmlNode = fXmlBoby.add_elem(FXmlTagTRS.E_Data);
                fXmlNode.set_attrVal(FXmlTagTRS.A_Name, FXmlTagTRS.D_Name, "_SERVICE_NAME");
                fXmlNode.set_attrVal(FXmlTagTRS.A_Type, FXmlTagTRS.D_Type, "S");
                fXmlNode.innerXml = command;
                // --
                fXmlNode = fXmlBoby.add_elem(FXmlTagTRS.E_Data);
                fXmlNode.set_attrVal(FXmlTagTRS.A_Name, FXmlTagTRS.D_Name, "_MODULE_NAME");
                fXmlNode.set_attrVal(FXmlTagTRS.A_Type, FXmlTagTRS.D_Type, "S");
                fXmlNode.innerXml = "EIS";
                // --
                fXmlNode = fXmlBoby.add_elem(FXmlTagTRS.E_Data);
                fXmlNode.set_attrVal(FXmlTagTRS.A_Name, FXmlTagTRS.D_Name, "PASSPORT");
                fXmlNode.set_attrVal(FXmlTagTRS.A_Type, FXmlTagTRS.D_Type, "S");
                // --
                fXmlNode = fXmlBoby.add_elem(FXmlTagTRS.E_Data);
                fXmlNode.set_attrVal(FXmlTagTRS.A_Name, FXmlTagTRS.D_Name, "LANGUAGE");
                fXmlNode.set_attrVal(FXmlTagTRS.A_Type, FXmlTagTRS.D_Type, "C");
                // --
                fXmlNode = fXmlBoby.add_elem(FXmlTagTRS.E_Data);
                fXmlNode.set_attrVal(FXmlTagTRS.A_Name, FXmlTagTRS.D_Name, "LOGLEVEL");
                fXmlNode.set_attrVal(FXmlTagTRS.A_Type, FXmlTagTRS.D_Type, "C");
                fXmlNode.set_attrVal("NL", "Y");

                // --

                if (fHdmg.hasChildNode)
                {
                    foreach (FXmlNode fXmlNodeHit in fHdmg.selectNodes(FXmlTagHIT.E_HostItem))
                    {
                        convertHitToTrs(fXmlBoby, fXmlNodeHit);
                    }
                }

                // --

                return fXmlMsgNode.outerXml;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNode != null)
                {
                    fXmlNode.Dispose();
                    fXmlNode = null;
                }
                if (fXmlMsgNode != null)
                {
                    fXmlMsgNode.Dispose();
                    fXmlMsgNode = null;
                }
                if (fXmlBoby != null)
                {
                    fXmlBoby.Dispose();
                    fXmlBoby = null;
                }
                if (fXmlDoc != null)
                {
                    fXmlDoc.Dispose();
                    fXmlDoc = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------
        // Add by Jeff.Kim 2015.12.15
        // MES Lot 복구시에 Trs 형식으로 로그를 전달 할수 있도록 하기위해 추가
        private static void convertHitToTrs(
            FXmlNode fXmlNodeParent,
            FXmlNode fXmlNodeHit
            )
        {
            FXmlNode fXmlNode = null;
            // --
            FFormat fFormat;
            // --
            string value = string.Empty;
            int length = 0;

            try
            {   
                // --

                fFormat = FEnumConverter.toFormat(fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format));
                length = int.Parse(fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length));

                // --

                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                {
                    fXmlNode = fXmlNodeParent.add_elem(FXmlTagTRS.E_List);
                    fXmlNode.set_attrVal(FXmlTagTRS.A_Name, fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Name, FXmlTagHIT.D_Name));

                    // -- 

                    foreach (FXmlNode fXmlNodeChild in fXmlNodeHit.selectNodes(FXmlTagHIT.E_HostItem))
                    {
                        convertHitToTrs(fXmlNode, fXmlNodeChild);
                    }                    
                }
                else
                {
                    fXmlNode = fXmlNodeParent.add_elem(FXmlTagTRS.E_Data);
                    fXmlNode.set_attrVal(FXmlTagTRS.A_Name, fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Name, FXmlTagHIT.D_Name));
                    // --
                    if (fFormat == FFormat.Ascii || fFormat == FFormat.A2 || fFormat == FFormat.JIS8)
                    {
                        fXmlNode.set_attrVal(FXmlTagTRS.A_Type, "S");

                        // --
                        value = FValueConverter.toTransformedEncodingValue(
                            fFormat,
                            fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value),
                            fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Transformer, FXmlTagHIT.D_Transformer),
                            ref length
                            );
                    }
                    else
                    {
                        fXmlNode.set_attrVal(FXmlTagTRS.A_Type, fFormat.ToString());
                        // --
                        value = FValueConverter.toTransformedStringValue(
                            fFormat,
                            fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value),
                            fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Transformer, FXmlTagHIT.D_Transformer),
                            ref length
                            );
                    }                    
                    fXmlNode.innerXml = value;
                }
            }
            catch(Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
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
                else if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
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

        //------------------------------------------------------------------------------------------------------------------------

        public static string convertOmglToXml(
            FXmlNode fXmlNodeOmgl
            )
        {
            StringBuilder xmlText = null;
            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlNodeMsg = null;
            FXmlNode fXmlNodeChild1 = null;
            FXmlNode fXmlNodeChild2 = null;
            FFormat fFormat = FFormat.List;
            int length = 0;

            try
            {
                xmlText = new StringBuilder();
                // --
                xmlText.AppendLine(
                    fXmlNodeOmgl.get_attrVal(FXmlTagOMGL.A_Name, FXmlTagOMGL.D_Name)
                    );

                // --

                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;

                // --

                fXmlNodeMsg = fXmlDoc.createNode("MESSAGE");
                // --
                foreach (FXmlNode x1 in fXmlNodeOmgl.selectNodes(FXmlTagOELL.E_OpcEventItemList))
                {
                    fXmlNodeChild1 = fXmlNodeMsg.appendChild(fXmlDoc.createNode(x1.get_attrVal(FXmlTagOELL.A_Name, FXmlTagOELL.D_Name)));
                    // --
                    foreach (FXmlNode x2 in x1.selectNodes(FXmlTagOEIL.E_OpcEventItem))
                    {
                        fFormat = (FFormat)FEnumConverter.toOpcFormat(x2.get_attrVal(FXmlTagOEIL.A_Format, FXmlTagOEIL.D_Format));
                        fXmlNodeChild2 = fXmlNodeChild1.appendChild(fXmlDoc.createNode(x2.get_attrVal(FXmlTagOEIL.A_Name, FXmlTagOEIL.D_Name)));
                        // --
                        if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                        {
                            fXmlNodeChild2.innerText = FValueConverter.toDataConversionedEncodingValue(
                                fFormat,
                                x2.get_attrVal(FXmlTagOEIL.A_Value, FXmlTagOEIL.D_Value),
                                x2.get_attrVal(FXmlTagOEIL.A_Transformer, FXmlTagOEIL.D_Transformer),
                                string.Empty,
                                ref length
                                );
                        }
                        else
                        {
                            fXmlNodeChild2.innerText = FValueConverter.toDataConversionStringValue(
                                fFormat,
                                x2.get_attrVal(FXmlTagOEIL.A_Value, FXmlTagOEIL.D_Value),
                                x2.get_attrVal(FXmlTagOEIL.A_Transformer, FXmlTagOEIL.D_Transformer),
                                string.Empty,
                                ref length
                                );
                        }
                    }
                }
                // --
                foreach (FXmlNode x1 in fXmlNodeOmgl.selectNodes(FXmlTagOILL.E_OpcItemList))
                {
                    fXmlNodeChild1 = fXmlNodeMsg.appendChild(fXmlDoc.createNode(x1.get_attrVal(FXmlTagOILL.A_Name, FXmlTagOILL.D_Name)));
                    // --
                    foreach (FXmlNode x2 in x1.selectNodes(FXmlTagOITL.E_OpcItem))
                    {
                        fFormat = (FFormat)FEnumConverter.toOpcFormat(x2.get_attrVal(FXmlTagOEIL.A_Format, FXmlTagOEIL.D_Format));
                        fXmlNodeChild2 = fXmlNodeChild1.appendChild(fXmlDoc.createNode(x2.get_attrVal(FXmlTagOITL.A_Name, FXmlTagOITL.D_Name)));
                        // --
                        if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                        {
                            fXmlNodeChild2.innerText = FValueConverter.toDataConversionedEncodingValue(
                                fFormat,
                                x2.get_attrVal(FXmlTagOITL.A_Value, FXmlTagOITL.D_Value),
                                x2.get_attrVal(FXmlTagOITL.A_Transformer, FXmlTagOITL.D_Transformer),
                                x2.get_attrVal(FXmlTagOITL.A_DataConversionSetExpression, FXmlTagOITL.D_DataConversionSetExpression),
                                ref length
                                );
                        }
                        else
                        {
                            fXmlNodeChild2.innerText = FValueConverter.toDataConversionStringValue(
                                fFormat,
                                x2.get_attrVal(FXmlTagOITL.A_Value, FXmlTagOITL.D_Value),
                                x2.get_attrVal(FXmlTagOITL.A_Transformer, FXmlTagOITL.D_Transformer),
                                x2.get_attrVal(FXmlTagOITL.A_DataConversionSetExpression, FXmlTagOITL.D_DataConversionSetExpression),
                                ref length
                                );
                        }
                    }
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
                fXmlNodeChild1 = null;
                fXmlNodeChild2 = null;
                if (fXmlDoc != null)
                {
                    fXmlDoc.Dispose();
                    fXmlDoc = null;
                }
                xmlText = null;
            }
            return string.Empty;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
