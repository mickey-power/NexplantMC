/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FKepware2.cs
--  Creator         : spike.lee
--  Create Date     : 2015.06.22
--  Description     : FAMate Core FaOpcDriver Kepware2 Parser Class
--  History         : Created by Jeff.Kim at 2013.07.29
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Nexplant.MC.Core.FaCommon;
using Kepware.ClientAce.OpcDaClient;

namespace Nexplant.MC.Core.FaOpcDriver
{
    internal static class FKepware2
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static void setOpcMessageLogInfo(
            FXmlNode fXmlNodeOmgl,
            FOpcDevice fOdv,
            FOpcSession fOsn
            )
        {
            try
            {
                // ***
                // OPC Device Info. Set
                // ***
                fXmlNodeOmgl.set_attrVal(FXmlTagOMGL.A_OpcDeviceId, FXmlTagOMGL.D_OpcDeviceId, fOdv.uniqueIdToString);
                fXmlNodeOmgl.set_attrVal(FXmlTagOMGL.A_OpcDeviceName, FXmlTagOMGL.D_OpcDeviceName, fOdv.name);
                fXmlNodeOmgl.set_attrVal(FXmlTagOMGL.A_OpcDeviceDefaultNamespace, FXmlTagOMGL.D_OpcDeviceDefaultNamespace, fOdv.defaultNamespace);

                // ***
                // OPC Session Info. Set
                // ***
                fXmlNodeOmgl.set_attrVal(FXmlTagOMGL.A_OpcSessionId, FXmlTagOMGL.D_OpcSessionId, fOsn.uniqueIdToString);
                fXmlNodeOmgl.set_attrVal(FXmlTagOMGL.A_OpcSessionName, FXmlTagOMGL.D_OpcSessionName, fOsn.name);
                fXmlNodeOmgl.set_attrVal(FXmlTagOMGL.A_OpcSessionChannel, FXmlTagOMGL.D_OpcSessionChannel, fOsn.channel);
                fXmlNodeOmgl.set_attrVal(FXmlTagOMGL.A_SessionId, FXmlTagOMGL.D_SessionId, fOsn.sessionId.ToString());
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

        public static FXmlNode getReplyMessage(            
            FOpcSession fOsn,
            string primaryUniqueId
            )
        {
            const string OpcMessageQuery =                
                FXmlTagOML.E_OpcMessageList +
                "/" + FXmlTagOMS.E_OpcMessages +
                "/" + FXmlTagOMG.E_OpcMessage + "[@" + FXmlTagOMG.A_UniqueId + "='{0}']";

            // --

            FXmlNode fXmlNodeOmg = null;

            try
            {
                if (!fOsn.hasLibrary)
                {
                    return null;
                }

                // --

                fXmlNodeOmg = fOsn.fLibrary.fXmlNode.selectSingleNode(
                    string.Format(OpcMessageQuery, primaryUniqueId)
                    );
                return fXmlNodeOmg == null ? null : fXmlNodeOmg.fNextSibling;                
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

        public static FXmlNode parseVirtualOpcRead(
            FOpcSession fOpcSession,
            FOpcMessageTransfer fOmt
            )
        {            
            FXmlNode fXmlNodeOmgl = null;
            // --
            try
            {
                // --

                fXmlNodeOmgl = fOmt.fXmlNode.clone(true);
                              
                // --

                setOpcMessageLogInfo(fXmlNodeOmgl, fOpcSession.fParent, fOpcSession);

                // --

                return fXmlNodeOmgl;
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

        public static FXmlNode parseOpcRead(
            FKepwareBuffer fTagRdBuf,
            ref FResultCode fResultCode,
            ref string resultMessage,
            ref bool isEvent
            )
        {
            const string OpcEventItemLogQuery = FXmlTagOELL.E_OpcEventItemList + "/" + FXmlTagOEIL.E_OpcEventItem;                
            const string OpcItemLogQuery = FXmlTagOILL.E_OpcItemList + "/" + FXmlTagOITL.E_OpcItem;

            // --
            FXmlNodeList fXmlNodeList = null;
            FXmlNode fXmlNodeOmgl = null;
            int index = 0;
            ItemIdentifier tagId = null;
            ItemValueCallback tagVc = null;            
            FOpcFormat fFormat = FOpcFormat.Ascii;
            FTagFormat fTagFormat = FTagFormat.Byte;            
            string value = string.Empty;            
            int length = 0;
            // --
            bool alwaysEvent = false;
            bool ignoreReadResult = false;
            // --
            string transformer = string.Empty;
            string orgValue = string.Empty;            
            string compVal1 = null;
            string compVal2 = null;

            try
            {   
                fXmlNodeOmgl = fTagRdBuf.fOpcMessageTransfer.fXmlNode.clone(true);
                ignoreReadResult = FBoolean.toBool(fXmlNodeOmgl.get_attrVal(FXmlTagOMGL.A_IgnoreReadResult, FXmlTagOMGL.D_IgnoreReadResult));
                // --
                if (fTagRdBuf.isError)
                {
                    if (ignoreReadResult)
                    {
                        fResultCode = FResultCode.Warninig;
                    }
                    else
                    {
                        fResultCode = FResultCode.Error;
                    }
                    resultMessage = string.Format(FConstants.err_m_0038, "OPC Server", "Read");                    
                }
                else
                {
                    fResultCode = FResultCode.Success;
                }

                // --                

                #region OPC Event Item Parsing

                // Modify by Jeff.Kim 2015.10.12
                // Subscribe 에서 Event가 발생할 당시의 값과 다시 읽었을 경우에 값이 바뀌는
                // 경우가 발생. Event에 의해서 Read 할경우 OpcEventItem은 읽지 않는다. 
                if (!fTagRdBuf.readByEvent)
                {
                    fXmlNodeList = fXmlNodeOmgl.selectNodes(OpcEventItemLogQuery);
                    foreach (FXmlNode x in fXmlNodeList)
                    {
                        tagId = fTagRdBuf.opcIdList[index];
                        tagVc = fTagRdBuf.opcValueCallbackList[index];
                        index++;

                        // --

                        alwaysEvent = FBoolean.toBool(x.get_attrVal(FXmlTagOEIL.A_AlwaysEvent, FXmlTagOEIL.D_AlwaysEvent));
                        fTagFormat = FEnumConverter.toTagFormat(x.get_attrVal(FXmlTagOEIL.A_ItemFormat, FXmlTagOEIL.D_ItemFormat));
                        fFormat = FEnumConverter.toOpcFormat(x.get_attrVal(FXmlTagOEIL.A_Format, FXmlTagOEIL.D_Format));
                        value = string.Empty;
                        length = 0;

                        if (tagVc.ResultID.Succeeded)
                        {
                            transformer = x.get_attrVal(FXmlTagOEIL.A_Transformer, FXmlTagOEIL.D_Transformer);
                            orgValue = x.get_attrVal(FXmlTagOEIL.A_Value, FXmlTagOEIL.D_Value);

                            // --

                            value = FOpcValueConverter.fromStringValueByOriginalValue(
                                fFormat,
                                parseTagValue(fTagFormat, fFormat, tagVc.Value),
                                out length
                                );
                            // --
                            x.set_attrVal(FXmlTagOEIL.A_Value, FXmlTagOEIL.D_Value, value);
                            x.set_attrVal(FXmlTagOEIL.A_Length, FXmlTagOEIL.D_Length, length.ToString());

                            // --
                            // Modify by Jeff.Kim 2015.09.18
                            // AlwaysEvent 의 경우 Auto Reply를 위해 값을 확인 하지 않고 무조건 isEvent를 True 변경
                            if (!alwaysEvent)
                            {
                                compVal1 = FValueConverter.toDataConversionStringValue((FFormat)fFormat, value, transformer, string.Empty);
                                compVal2 = FValueConverter.toDataConversionStringValue((FFormat)fFormat, orgValue, transformer, string.Empty);
                                if (compVal1 == compVal2)
                                {
                                    isEvent = true;
                                }
                            }
                            else
                            {
                                isEvent = true;
                            }
                        }
                        else
                        {
                            x.set_attrVal(FXmlTagOEIL.A_Value, FXmlTagOEIL.D_Value, FXmlTagOEIL.D_Value);
                            x.set_attrVal(FXmlTagOEIL.A_Length, FXmlTagOEIL.D_Length, FXmlTagOEIL.D_Length);
                            x.set_attrVal(FXmlTagOEIL.A_Result, FXmlTagOEIL.D_Result, tagVc.ResultID.Description);

                            // --                                                      
                            if (fResultCode == FResultCode.Success)
                            {   
                                fResultCode = FResultCode.Warninig;                                    
                                resultMessage = string.Format(FConstants.err_m_0015, "Message Structure");                                
                            }
                        }
                    }
                }

                // --
                // Modify by Jeff.Kim 2015.09.18
                // Event Item이 없을 경우에도 Auto Reply 가 가능하도록 isEvent 값을 True로 한다. 
                if (fXmlNodeList == null || fXmlNodeList.count == 0)
                    isEvent = true;

                #endregion

                // --                

                #region OPC Item Parsing

                foreach (FXmlNode x in fXmlNodeOmgl.selectNodes(OpcItemLogQuery))
                {
                    tagId = fTagRdBuf.opcIdList[index];
                    tagVc = fTagRdBuf.opcValueCallbackList[index];
                    index++;

                    // --

                    fTagFormat = FEnumConverter.toTagFormat(x.get_attrVal(FXmlTagOITL.A_ItemFormat, FXmlTagOITL.D_ItemFormat));
                    fFormat = FEnumConverter.toOpcFormat(x.get_attrVal(FXmlTagOITL.A_Format, FXmlTagOITL.D_Format));
                    value = string.Empty;
                    length = 0;

                    if (tagVc.ResultID.Succeeded)
                    {
                        value = FOpcValueConverter.fromStringValueByOriginalValue(
                            fFormat,
                            parseTagValue(fTagFormat, fFormat, tagVc.Value), 
                            out length
                            );
                        // --                         
                        x.set_attrVal(FXmlTagOITL.A_Value, FXmlTagOITL.D_Value, value);
                        x.set_attrVal(FXmlTagOITL.A_Length, FXmlTagOITL.D_Length, length.ToString());                        
                    }
                    else
                    {
                        x.set_attrVal(FXmlTagOITL.A_Value, FXmlTagOITL.D_Value, FXmlTagOITL.D_Value);
                        x.set_attrVal(FXmlTagOITL.A_Length, FXmlTagOITL.D_Length, FXmlTagOITL.D_Length);
                        x.set_attrVal(FXmlTagOITL.A_Result, FXmlTagOITL.D_Result, tagVc.ResultID.Description);

                        // --

                        if (fResultCode == FResultCode.Success)
                        {
                            fResultCode = FResultCode.Warninig;
                            resultMessage = string.Format(FConstants.err_m_0015, "Message Structure");                            
                        }                            
                    }
                }

                #endregion

                // --
                
                setOpcMessageLogInfo(fXmlNodeOmgl, fTagRdBuf.fOpcSession.fParent, fTagRdBuf.fOpcSession); 

                // --

                return fXmlNodeOmgl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tagId = null;
                tagVc = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode parseOpcWritten(
            FKepwareBuffer fTagWtBuf,
            ref FResultCode fResultCode,
            ref string resultMessage
            )
        {
            const string OpcEventItemLogQuery = FXmlTagOELL.E_OpcEventItemList + "/" + FXmlTagOEIL.E_OpcEventItem;
            const string OpcItemLogQuery = FXmlTagOILL.E_OpcItemList + "/" + FXmlTagOITL.E_OpcItem;

            // --

            FXmlNode fXmlNodeOmgl = null;
            int index = 0;                        
            ItemResultCallback tagRt = null;            

            try
            {
                if (fTagWtBuf.isError)
                {
                    fResultCode = FResultCode.Error;
                    resultMessage = string.Format(FConstants.err_m_0038, "OPC Server", "Write");
                }
                else
                {
                    fResultCode = FResultCode.Success;
                }

                // --                

                fXmlNodeOmgl = fTagWtBuf.fOpcMessageTransfer.fXmlNode.clone(true);

                // --

                #region OPC Item Paring

                foreach (FXmlNode x in fXmlNodeOmgl.selectNodes(OpcItemLogQuery))
                {
                    tagRt = fTagWtBuf.opcResultCallbackList[index];
                    index++;

                    // --                   

                    if (!tagRt.ResultID.Succeeded)
                    {
                        x.set_attrVal(FXmlTagOEIL.A_Result, FXmlTagOEIL.D_Result, tagRt.ResultID.Description);

                        // --

                        if (fResultCode == FResultCode.Success)
                        {
                            fResultCode = FResultCode.Warninig;
                            resultMessage = string.Format(FConstants.err_m_0015, "Message Structure");
                        }
                    }
                }

                #endregion

                // --

                #region OPC Event Item Parsing

                foreach (FXmlNode x in fXmlNodeOmgl.selectNodes(OpcEventItemLogQuery))
                {
                    tagRt = fTagWtBuf.opcResultCallbackList[index];
                    index++;

                    // --                   

                    if (!tagRt.ResultID.Succeeded)
                    {
                        x.set_attrVal(FXmlTagOEIL.A_Result, FXmlTagOEIL.D_Result, tagRt.ResultID.Description);

                        // --

                        if (fResultCode == FResultCode.Success)
                        {
                            fResultCode = FResultCode.Warninig;
                            resultMessage = string.Format(FConstants.err_m_0015, "Message Structure");
                        }
                    }
                }

                #endregion

                // --
                
                setOpcMessageLogInfo(fXmlNodeOmgl, fTagWtBuf.fOpcSession.fParent, fTagWtBuf.fOpcSession); 

                // --

                return fXmlNodeOmgl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {   
                tagRt = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------
        // Modify Jeff.Kim 2015.09.08
        // BCD 타입 Parsing을 위해 수정
        public static string parseTagValue(
            FTagFormat fTagFormat,
            FOpcFormat fFormat,
            object tagValue
            )
        {
            StringBuilder val = null;
            byte[] byteArr = null;
            int lenByte = 0;
            int len = 0;
            int index = 0;

            try
            {
                // ***
                // Tag Value를 모두 Byte Array로 변환한 후, OPC Format 맞게 재구성
                // ***
                parseValueToArray(tagValue, ref byteArr);
                if (byteArr == null)
                {
                    return tagValue == null ? string.Empty : tagValue.ToString();
                }

                // --

                val = new StringBuilder();

                // --

                if (fTagFormat == FTagFormat.BCD)
                {
                    // --
                    // 1. hex 형태로 변환
                    Array.Reverse(byteArr);
                    for (int i = 0; i < byteArr.Length; i++)
                    {
                        val.Append(byteArr[i].ToString("X2"));
                    }

                    // --

                    int tempVal = int.Parse(val.ToString());

                    // --
                    val.Clear();
                    val.Append(tempVal);                   
                }
                else
                {
                    if (fFormat == FOpcFormat.Binary)
                    {
                        for (int i = 0; i < byteArr.Length; i++)
                        {
                            val.Append(byteArr[i].ToString("X2"));

                            // --

                            if (i < byteArr.Length - 1)
                            {
                                val.Append(" ");
                            }
                        }
                    }
                    else if (fFormat == FOpcFormat.Boolean)
                    {
                        for (int i = 0; i < byteArr.Length; i++)
                        {
                            if (byteArr[i] == 0)
                            {
                                val.Append(FBoolean.False);
                            }
                            else
                            {
                                val.Append(FBoolean.True);
                            }

                            // --

                            if (i < byteArr.Length - 1)
                            {
                                val.Append(" ");
                            }
                        }
                    }
                    else if (fFormat == FOpcFormat.Ascii)
                    {
                        val.Append(Encoding.Default.GetString(byteArr));
                    }
                    else if (fFormat == FOpcFormat.I8)
                    {
                        lenByte = 8;
                        len = byteArr.Length / lenByte;
                        for (int i = 0; i < len; i++)
                        {
                            val.Append(BitConverter.ToInt64(byteArr, index));
                            index += lenByte;

                            // --

                            if (i < len - 1)
                            {
                                val.Append(" ");
                            }
                        }
                        // --
                        if ((byteArr.Length % lenByte) > 0)   // 짜투리
                        {
                            val.Append(" ");

                            // --

                            byte[] temp = new byte[lenByte];
                            for (int i = 0; i < byteArr.Length - index; i++)
                            {
                                temp[i] = byteArr[index];
                            }
                            val.Append(BitConverter.ToInt64(temp, 0));
                        }
                    }
                    else if (fFormat == FOpcFormat.I4)
                    {
                        lenByte = 4;
                        len = byteArr.Length / lenByte;
                        for (int i = 0; i < len; i++)
                        {
                            val.Append(BitConverter.ToInt32(byteArr, index));
                            index += lenByte;

                            // --

                            if (i < len - 1)
                            {
                                val.Append(" ");
                            }
                        }
                        // --
                        if ((byteArr.Length % lenByte) > 0)   // 짜투리
                        {
                            val.Append(" ");

                            // --

                            byte[] temp = new byte[lenByte];
                            for (int i = 0; i < byteArr.Length - index; i++)
                            {
                                temp[i] = byteArr[index];
                            }
                            val.Append(BitConverter.ToInt32(temp, 0));
                        }
                    }
                    else if (fFormat == FOpcFormat.I2)
                    {
                        lenByte = 2;
                        len = byteArr.Length / lenByte;
                        for (int i = 0; i < len; i++)
                        {
                            val.Append(BitConverter.ToInt16(byteArr, index));
                            index += lenByte;

                            // --

                            if (i < len - 1)
                            {
                                val.Append(" ");
                            }
                        }
                        // --
                        if ((byteArr.Length % lenByte) > 0)   // 짜투리
                        {
                            val.Append(" ");

                            // --

                            byte[] temp = new byte[lenByte];
                            for (int i = 0; i < byteArr.Length - index; i++)
                            {
                                temp[i] = byteArr[index];
                            }
                            val.Append(BitConverter.ToInt16(temp, 0));
                        }
                    }
                    else if (fFormat == FOpcFormat.I1)
                    {
                        for (int i = 0; i < byteArr.Length; i++)
                        {
                            val.Append((sbyte)byteArr[i]);

                            // --

                            if (i < byteArr.Length - 1)
                            {
                                val.Append(" ");
                            }
                        }
                    }
                    else if (fFormat == FOpcFormat.F8)
                    {
                        lenByte = 8;
                        len = byteArr.Length / lenByte;
                        for (int i = 0; i < len; i++)
                        {
                            val.Append(BitConverter.ToDouble(byteArr, index));
                            index += lenByte;

                            // --

                            if (i < len - 1)
                            {
                                val.Append(" ");
                            }
                        }
                        // --
                        if ((byteArr.Length % lenByte) > 0)   // 짜투리
                        {
                            val.Append(" ");

                            // --

                            byte[] temp = new byte[lenByte];
                            for (int i = 0; i < byteArr.Length - index; i++)
                            {
                                temp[i] = byteArr[index];
                            }
                            val.Append(BitConverter.ToDouble(temp, 0));
                        }
                    }
                    else if (fFormat == FOpcFormat.F4)
                    {
                        lenByte = 4;
                        len = byteArr.Length / lenByte;
                        for (int i = 0; i < len; i++)
                        {
                            val.Append(BitConverter.ToSingle(byteArr, index));
                            index += lenByte;

                            // --

                            if (i < len - 1)
                            {
                                val.Append(" ");
                            }
                        }
                        // --
                        if ((byteArr.Length % lenByte) > 0)   // 짜투리
                        {
                            val.Append(" ");

                            // --

                            byte[] temp = new byte[lenByte];
                            for (int i = 0; i < byteArr.Length - index; i++)
                            {
                                temp[i] = byteArr[index];
                            }
                            val.Append(BitConverter.ToSingle(temp, 0));
                        }
                    }
                    else if (fFormat == FOpcFormat.U8)
                    {
                        lenByte = 8;
                        len = byteArr.Length / lenByte;
                        for (int i = 0; i < len; i++)
                        {
                            val.Append(BitConverter.ToUInt64(byteArr, index));
                            index += lenByte;

                            // --

                            if (i < len - 1)
                            {
                                val.Append(" ");
                            }
                        }
                        // --
                        if ((byteArr.Length % lenByte) > 0)   // 짜투리
                        {
                            val.Append(" ");

                            // --

                            byte[] temp = new byte[lenByte];
                            for (int i = 0; i < byteArr.Length - index; i++)
                            {
                                temp[i] = byteArr[index];
                            }
                            val.Append(BitConverter.ToUInt64(temp, 0));
                        }
                    }
                    else if (fFormat == FOpcFormat.U4)
                    {
                        lenByte = 4;
                        len = byteArr.Length / lenByte;
                        for (int i = 0; i < len; i++)
                        {
                            val.Append(BitConverter.ToUInt32(byteArr, index));
                            index += lenByte;

                            // --

                            if (i < len - 1)
                            {
                                val.Append(" ");
                            }
                        }
                        // --
                        if ((byteArr.Length % lenByte) > 0)   // 짜투리
                        {
                            val.Append(" ");

                            // --

                            byte[] temp = new byte[lenByte];
                            for (int i = 0; i < byteArr.Length - index; i++)
                            {
                                temp[i] = byteArr[index];
                            }
                            val.Append(BitConverter.ToUInt32(temp, 0));
                        }
                    }
                    else if (fFormat == FOpcFormat.U2)
                    {
                        lenByte = 2;
                        len = byteArr.Length / lenByte;
                        for (int i = 0; i < len; i++)
                        {
                            val.Append(BitConverter.ToUInt16(byteArr, index));
                            index += lenByte;

                            // --

                            if (i < len - 1)
                            {
                                val.Append(" ");
                            }
                        }
                        // --
                        if ((byteArr.Length % lenByte) > 0)   // 짜투리
                        {
                            val.Append(" ");

                            // --

                            byte[] temp = new byte[lenByte];
                            for (int i = 0; i < byteArr.Length - index; i++)
                            {
                                temp[i] = byteArr[index];
                            }
                            val.Append(BitConverter.ToUInt16(temp, 0));
                        }
                    }
                    else if (fFormat == FOpcFormat.U1)
                    {
                        for (int i = 0; i < byteArr.Length; i++)
                        {
                            val.Append(byteArr[i]);

                            // --

                            if (i < byteArr.Length - 1)
                            {
                                val.Append(" ");
                            }
                        }
                    }
                    else
                    {
                        val.Append(tagValue == null ? string.Empty : tagValue.ToString());
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

            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static object parseOpcValue(
            FTagFormat fTagFormat,
            bool isArray,
            object opcValue,
            int length
            )
        {
            object val = null;
            byte[] byteArr = null;
            int lenByte = 0;
            int len = 0;
            int index = 0;

            try
            {
                // ***
                // OPC Value를 모두 Byte Array로 변환한 후, Tag Format 맞게 재구성
                // ***
                parseValueToArray(opcValue, ref byteArr);
                
                // --
                
                // ***
                //값이 없을 경우 byteArr는 0으로 초기화, string은 공백, 다른값들은 0으로 처리
                // ***
                if (byteArr == null)
                {
                    byteArr = new byte[0];
                    
                    // --
                    
                    if (fTagFormat == FTagFormat.String)
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return Convert.ToByte(0);
                    }
                }

                // --

                if (fTagFormat == FTagFormat.Boolean)
                {
                    Boolean[] arr = new Boolean[byteArr.Length]; 
                    // --
                    for (int i = 0; i < byteArr.Length; i++)
                    {
                        arr[i] = (byteArr[i] == 0 ? false : true);
                    }

                    // --

                    if (isArray || length > 1)
                    {
                        val = arr;
                    }
                    else
                    {
                        val = arr[0];
                    }
                }
                else if (fTagFormat == FTagFormat.Char)
                {                    
                    SByte[] arr = new SByte[byteArr.Length];
                    // --
                    for (int i = 0; i < byteArr.Length; i++)
                    {
                        arr[i] = (SByte)byteArr[i];
                    }

                    // --

                    if (isArray || length > 1)
                    {
                        val = arr;
                    }
                    else
                    {
                        val = arr[0];
                    }
                }
                else if (fTagFormat == FTagFormat.Byte)
                {
                    if (isArray || length > 1)
                    {
                        val = byteArr;
                    }
                    else
                    {
                        val = byteArr[0];
                    }
                }
                else if (fTagFormat == FTagFormat.Short)
                {
                    List<Int16> v = new List<Int16>();
                    lenByte = 2;
                    len = byteArr.Length / lenByte;  
                  

                    for (int i = 0; i < len; i++)
                    {
                        v.Add(BitConverter.ToInt16(byteArr, index));                        
                        index += lenByte;
                    }
                    // --
                    if ((byteArr.Length % lenByte) > 0)   // 짜투리
                    {
                        byte[] temp = new byte[lenByte];
                        for (int i = 0; i < byteArr.Length - index; i++)
                        {
                            temp[i] = byteArr[index];
                        }
                        v.Add(BitConverter.ToInt16(temp, 0));
                    }

                    // --

                    if (isArray || length > 1)
                    {
                        val = v.ToArray();
                    }
                    else
                    {
                        val = v[0];
                    }
                }
                else if (fTagFormat == FTagFormat.Word)
                {
                    List<UInt16> v = new List<UInt16>();
                    lenByte = 2;
                    len = byteArr.Length / lenByte;


                    for (int i = 0; i < len; i++)
                    {
                        v.Add(BitConverter.ToUInt16(byteArr, index));
                        index += lenByte;
                    }
                    // --
                    if ((byteArr.Length % lenByte) > 0)   // 짜투리
                    {
                        byte[] temp = new byte[lenByte];
                        for (int i = 0; i < byteArr.Length - index; i++)
                        {
                            temp[i] = byteArr[index];
                        }
                        v.Add(BitConverter.ToUInt16(temp, 0));
                    }

                    // --

                    if (isArray || length > 1)
                    {
                        val = v.ToArray();
                    }
                    else
                    {
                        val = v[0];
                    }
                }
                else if (fTagFormat == FTagFormat.BCD)
                {
                    // --

                    UInt16 value = (UInt16)opcValue;
                    byte[] v = new byte[2];                    
                    for (int i = 0; i < 2; i++)
                    {
                        v[i] = (byte)(value % 10);
                        value /= 10;
                        v[i] |= (byte)((value % 10) << 4);
                        value /= 10;
                    }

                    // --

                    if (opcValue.GetType() == typeof(byte))
                    {
                        val = v[0];
                    }
                    else
                    {
                        val = BitConverter.ToUInt16(v, 0);
                    }
                    
                    // --
                }
                else if (fTagFormat == FTagFormat.Long)
                {
                    List<Int32> v = new List<Int32>();
                    lenByte = 4;
                    len = byteArr.Length / lenByte;


                    for (int i = 0; i < len; i++)
                    {
                        v.Add(BitConverter.ToInt32(byteArr, index));
                        index += lenByte;
                    }
                    // --
                    if ((byteArr.Length % lenByte) > 0)   // 짜투리
                    {
                        byte[] temp = new byte[lenByte];
                        for (int i = 0; i < byteArr.Length - index; i++)
                        {
                            temp[i] = byteArr[index];
                        }
                        v.Add(BitConverter.ToInt32(temp, 0));
                    }

                    // --

                    if (isArray || length > 1)
                    {
                        val = v.ToArray();
                    }
                    else
                    {
                        val = v[0];
                    }
                }
                else if (fTagFormat == FTagFormat.DWord)
                {
                    List<UInt32> v = new List<UInt32>();
                    lenByte = 4;
                    len = byteArr.Length / lenByte;


                    for (int i = 0; i < len; i++)
                    {
                        v.Add(BitConverter.ToUInt32(byteArr, index));
                        index += lenByte;
                    }
                    // --
                    if ((byteArr.Length % lenByte) > 0)   // 짜투리
                    {
                        byte[] temp = new byte[lenByte];
                        for (int i = 0; i < byteArr.Length - index; i++)
                        {
                            temp[i] = byteArr[index];
                        }
                        v.Add(BitConverter.ToUInt32(temp, 0));
                    }

                    // --

                    if (isArray || length > 1)
                    {
                        val = v.ToArray();
                    }
                    else
                    {
                        val = v[0];
                    }
                }
                else if (fTagFormat == FTagFormat.Float)
                {
                    List<Single> v = new List<Single>();
                    lenByte = 4;
                    len = byteArr.Length / lenByte;


                    for (int i = 0; i < len; i++)
                    {
                        v.Add(BitConverter.ToSingle(byteArr, index));
                        index += lenByte;
                    }
                    // --
                    if ((byteArr.Length % lenByte) > 0)   // 짜투리
                    {
                        byte[] temp = new byte[lenByte];
                        for (int i = 0; i < byteArr.Length - index; i++)
                        {
                            temp[i] = byteArr[index];
                        }
                        v.Add(BitConverter.ToSingle(temp, 0));
                    }

                    // --

                    if (isArray || length > 1)
                    {
                        val = v.ToArray();
                    }
                    else
                    {
                        val = v[0];
                    }
                }
                else if (fTagFormat == FTagFormat.Double)
                {
                    List<Double> v = new List<Double>();
                    lenByte = 8;
                    len = byteArr.Length / lenByte;


                    for (int i = 0; i < len; i++)
                    {
                        v.Add(BitConverter.ToDouble(byteArr, index));
                        index += lenByte;
                    }
                    // --
                    if ((byteArr.Length % lenByte) > 0)   // 짜투리
                    {
                        byte[] temp = new byte[lenByte];
                        for (int i = 0; i < byteArr.Length - index; i++)
                        {
                            temp[i] = byteArr[index];
                        }
                        v.Add(BitConverter.ToDouble(temp, 0));
                    }

                    // --

                    if (isArray || length > 1)
                    {
                        val = v.ToArray();
                    }
                    else
                    {
                        val = v[0];
                    }
                }
                else if (fTagFormat == FTagFormat.String)
                {
                    val = Encoding.Default.GetString(byteArr);
                }
                else if (fTagFormat == FTagFormat.BCD)
                {
                    List<UInt16> v = new List<UInt16>();
                    lenByte = 2;
                    len = byteArr.Length / lenByte;


                    for (int i = 0; i < len; i++)
                    {
                        v.Add(BitConverter.ToUInt16(byteArr, index));
                        index += lenByte;
                    }
                    // --
                    if ((byteArr.Length % lenByte) > 0)   // 짜투리
                    {
                        byte[] temp = new byte[lenByte];
                        for (int i = 0; i < byteArr.Length - index; i++)
                        {
                            temp[i] = byteArr[index];
                        }
                        v.Add(BitConverter.ToUInt16(temp, 0));
                    }

                    // --

                    if (isArray || length > 1)
                    {
                        val = v.ToArray();
                    }
                    else
                    {
                        val = v[0];
                    }
                }
                else if (fTagFormat == FTagFormat.LBCD)
                {
                    List<UInt32> v = new List<UInt32>();
                    lenByte = 4;
                    len = byteArr.Length / lenByte;


                    for (int i = 0; i < len; i++)
                    {
                        v.Add(BitConverter.ToUInt32(byteArr, index));
                        index += lenByte;
                    }
                    // --
                    if ((byteArr.Length % lenByte) > 0)   // 짜투리
                    {
                        byte[] temp = new byte[lenByte];
                        for (int i = 0; i < byteArr.Length - index; i++)
                        {
                            temp[i] = byteArr[index];
                        }
                        v.Add(BitConverter.ToUInt32(temp, 0));
                    }

                    // --

                    if (isArray || length > 1)
                    {
                        val = v.ToArray();
                    }
                    else
                    {
                        val = v[0];
                    }
                }
                else if (fTagFormat == FTagFormat.Date)
                {
                    // ???
                }

                // --

                return val;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                byteArr = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static bool parseValueToArray(            
            object value,
            ref byte[] byteArr
            )
        {
            Type t;
            int index = 0;
            int byteLen = 0;

            try
            {
                if (value == null)
                {
                    byteArr = null;
                    return true;
                }

                // --

                t = value.GetType();

                // --                

                if (t.IsArray)
                {
                    #region Array Value

                    if (t == typeof(byte[]))
                    {
                        // ***
                        // Byte
                        // ***
                        byteArr = (byte[])value;
                    }
                    else if (t == typeof(UInt16[]))
                    {
                        // ***
                        // Word or BCD
                        // ***
                        UInt16[] arrVal = (UInt16[])value;
                        byteLen = 2;

                        // --
                        
                        byteArr = new byte[arrVal.Length * byteLen];
                        // --
                        foreach (UInt16 v in (UInt16[])arrVal)
                        {
                            Array.Copy(BitConverter.GetBytes(v), 0, byteArr, index, byteLen);
                            index += byteLen;
                        }
                    }
                    else if (t == typeof(Boolean[]))
                    {
                        // ***
                        // Boolean
                        // ***
                        Boolean[] arrVal = (Boolean[])value;                        

                        // --                         

                        byteArr = new byte[arrVal.Length];
                        // --
                        foreach (Boolean v in (Boolean[])arrVal)
                        {
                            byteArr[index] = BitConverter.GetBytes(v)[0];
                            index++; 
                        }
                    }
                    else if (t == typeof(SByte[]))
                    {
                        // ***
                        // Char
                        // ***
                        SByte[] arrVal = (SByte[])value;                        

                        // --                         

                        byteArr = new byte[arrVal.Length];
                        // --
                        foreach (SByte v in (SByte[])arrVal)
                        {
                            byteArr[index] = BitConverter.GetBytes(v)[0];
                            index++;
                        }
                    }
                    else if (t == typeof(Int16[]))
                    {
                        // ***
                        // Short
                        // ***                        
                        Int16[] arrVal = (Int16[])value;
                        byteLen = 2;

                        // --

                        byteArr = new byte[arrVal.Length * byteLen];
                        // --
                        foreach (Int16 v in (Int16[])arrVal)
                        {
                            Array.Copy(BitConverter.GetBytes(v), 0, byteArr, index, byteLen);
                            index += byteLen;
                        }
                    }
                    else if (t == typeof(Int32[]))
                    {
                        // ***
                        // Long
                        // ***
                        Int32[] arrVal = (Int32[])value;
                        byteLen = 4;

                        // --

                        byteArr = new byte[arrVal.Length * byteLen];
                        // --
                        foreach (Int32 v in (Int32[])arrVal)
                        {
                            Array.Copy(BitConverter.GetBytes(v), 0, byteArr, index, byteLen);
                            index += byteLen;
                        }
                    }
                    else if (t == typeof(UInt32[]))
                    {
                        // ***
                        // DWord or LBCD
                        // ***
                        UInt32[] arrVal = (UInt32[])value;
                        byteLen = 4;

                        // --

                        byteArr = new byte[arrVal.Length * byteLen];
                        // --
                        foreach (UInt32 v in (UInt32[])arrVal)
                        {
                            Array.Copy(BitConverter.GetBytes(v), 0, byteArr, index, byteLen);
                            index += byteLen;
                        }
                    }
                    else if (t == typeof(Single[]))
                    {
                        // ***
                        // Float
                        // ***
                        Single[] arrVal = (Single[])value;
                        byteLen = 4;

                        // --

                        byteArr = new byte[arrVal.Length * byteLen];
                        // --
                        foreach (Single v in (Single[])arrVal)
                        {
                            Array.Copy(BitConverter.GetBytes(v), 0, byteArr, index, byteLen);
                            index += byteLen;
                        }
                    }
                    else if (t == typeof(Double[]))
                    {
                        // ***
                        // Double
                        // ***
                        Double[] arrVal = (Double[])value;
                        byteLen = 8;

                        // --

                        byteArr = new byte[arrVal.Length * byteLen];
                        // --
                        foreach (Double v in (Double[])arrVal)
                        {
                            Array.Copy(BitConverter.GetBytes(v), 0, byteArr, index, byteLen);
                            index += byteLen;
                        }
                    }
                    else
                    {
                        return false;
                    }

                    #endregion
                }
                else
                {
                    #region No Array Value

                    if (t == typeof(byte))
                    {
                        // ***
                        // Byte
                        // ***
                        byteArr = new byte[1] { (byte)value };
                    }
                    else if (t == typeof(UInt16))
                    {
                        // ***
                        // Word or BCD
                        // ***
                        byteArr = BitConverter.GetBytes((UInt16)value);
                    }
                    else if (t == typeof(Boolean))
                    {
                        // ***
                        // Boolean
                        // ***
                        byteArr = BitConverter.GetBytes((Boolean)value);
                    }
                    else if (t == typeof(SByte))
                    {
                        // ***
                        // Char
                        // ***
                        byteArr = BitConverter.GetBytes((SByte)value);
                    }
                    else if (t == typeof(Int16))
                    {
                        // ***
                        // Short
                        // ***
                        byteArr = BitConverter.GetBytes((Int16)value);
                    }
                    else if (t == typeof(Int32))
                    {
                        // ***
                        // Long
                        // ***
                        byteArr = BitConverter.GetBytes((Int32)value);
                    }
                    else if (t == typeof(UInt32))
                    {
                        // ***
                        // DWord or LBCD
                        // ***
                        byteArr = BitConverter.GetBytes((UInt32)value);
                    }
                    else if (t == typeof(Single))
                    {
                        // ***
                        // Float
                        // ***
                        byteArr = BitConverter.GetBytes((Single)value);
                    }
                    else if (t == typeof(Double))
                    {
                        // ***
                        // Double
                        // ***
                        byteArr = BitConverter.GetBytes((Double)value);
                    }
                    else if (t == typeof(DateTime))
                    {
                        // ***
                        // DateTime
                        // ***                        
                        byteArr = Encoding.Default.GetBytes(((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss.fff"));                        
                    }
                    else if (t == typeof(string))
                    {
                        // ***
                        // String
                        // ***
                        byteArr = Encoding.Default.GetBytes((string)value);
                    }
                    else
                    {
                        return false;
                    }

                    #endregion
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

            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode[] parseExpressionTrigger(
            FOpcDriver fOcd,
            FXmlNode fXmlNodeOmgl
            )
        {
            const string OpcConditionQuery =
                FXmlTagEQM.E_EquipmentModeling +
                "/" + FXmlTagEQP.E_Equipment +
                "/" + FXmlTagSNG.E_ScenarioGroup +
                "/" + FXmlTagSNR.E_Scenario +
                "/" + FXmlTagOTR.E_OpcTrigger +
                "/" + FXmlTagOCN.E_OpcCondition +
                "[@" + FXmlTagOCN.A_ConditionMode + "='{0}' and" +
                " @" + FXmlTagOCN.A_OpcDeviceId   + "='{1}' and" +
                " @" + FXmlTagOCN.A_OpcSessionId  + "='{2}' and" +
                " @" + FXmlTagOCN.A_OpcMessageId  + "='{3}']";

            // --

            FXmlNodeList fXmlNodeListOcn = null;
            FXmlNodeList fXmlNodeListOep = null;
            FXmlNode fXmlNodeOtr = null;
            bool result = false;
            string xpath = string.Empty;
            HashSet<string> otrKeys = null;
            List<FXmlNode> otrList = null;
            string otrUniqueId = string.Empty;

            try
            {
                otrKeys = new HashSet<string>();
                otrList = new List<FXmlNode>();

                xpath = string.Format(
                    OpcConditionQuery,
                    FEnumConverter.fromConditionMode(FConditionMode.Expression),
                    fXmlNodeOmgl.get_attrVal(FXmlTagOMGL.A_OpcDeviceId, FXmlTagOMGL.D_OpcDeviceId),
                    fXmlNodeOmgl.get_attrVal(FXmlTagOMGL.A_OpcSessionId, FXmlTagOMGL.D_OpcSessionId),
                    fXmlNodeOmgl.get_attrVal(FXmlTagOMGL.A_UniqueId, FXmlTagOMGL.D_UniqueId)
                    );
                // --
                fXmlNodeListOcn = fOcd.fXmlNode.selectNodes(xpath);
                foreach (FXmlNode fXmlNodeOcn in fXmlNodeListOcn)
                {
                    // ***
                    // 중복 조건 검사
                    // ***
                    fXmlNodeOtr = fXmlNodeOcn.fParentNode;
                    otrUniqueId = fXmlNodeOtr.get_attrVal(FXmlTagOTR.A_UniqueId, FXmlTagOTR.D_UniqueId);
                    if (otrKeys.Contains(otrUniqueId))
                    {
                        continue;
                    }

                    // --

                    result = true;
                    fXmlNodeListOep = fXmlNodeOcn.selectNodes(FXmlTagOEP.E_OpcExpression);
                    foreach (FXmlNode fXmlNodeOep in fXmlNodeListOep)
                    {
                        compareCondition(fOcd, fXmlNodeOmgl, fXmlNodeOep, ref result);
                    }

                    if (result)
                    {
                        otrList.Add(fXmlNodeOtr);
                        otrKeys.Add(otrUniqueId);
                    }
                }

                // --

                return otrList.ToArray();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListOcn = null;
                fXmlNodeListOep = null;
                fXmlNodeOtr = null;
                otrKeys = null;
                otrList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode[] parseConnectionTrigger(
            FOpcDriver fOcd,
            FXmlNode fXmlNodeOvcl,
            FDeviceState fDeviceState
            )
        {
            const string OpcConditionQuery =
                FXmlTagEQM.E_EquipmentModeling +
                "/" + FXmlTagEQP.E_Equipment +
                "/" + FXmlTagSNG.E_ScenarioGroup +
                "/" + FXmlTagSNR.E_Scenario +
                "/" + FXmlTagOTR.E_OpcTrigger +
                "/" + FXmlTagOCN.E_OpcCondition +
                "[@" + FXmlTagOCN.A_ConditionMode   + "='{0}' and" +
                " @" + FXmlTagOCN.A_OpcDeviceId     + "='{1}' and" +
                " @" + FXmlTagOCN.A_ConnectionState + "='{2}']";

            // --

            FXmlNodeList fXmlNodeListOcn = null;
            FXmlNode fXmlNodeOtr = null;
            string xpath = string.Empty;
            HashSet<string> otrKeys = null;
            List<FXmlNode> otrList = null;
            string otrUniqueId = string.Empty;

            try
            {
                xpath = string.Format(
                    OpcConditionQuery,
                    FEnumConverter.fromConditionMode(FConditionMode.Connection),
                    fXmlNodeOvcl.get_attrVal(FXmlTagODV.A_UniqueId, FXmlTagODV.D_UniqueId),
                    FEnumConverter.fromDeviceState(fDeviceState)
                    );
                fXmlNodeListOcn = fOcd.fXmlNode.selectNodes(xpath);

                // --

                otrKeys = new HashSet<string>();
                otrList = new List<FXmlNode>();
                // --
                foreach (FXmlNode fXmlNodeScn in fXmlNodeListOcn)
                {
                    // ***
                    // 중복 조건 검사
                    // ***
                    fXmlNodeOtr = fXmlNodeScn.fParentNode;
                    otrUniqueId = fXmlNodeOtr.get_attrVal(FXmlTagOTR.A_UniqueId, FXmlTagOTR.D_UniqueId);
                    if (otrKeys.Contains(otrUniqueId))
                    {
                        continue;
                    }

                    // --

                    otrList.Add(fXmlNodeOtr);
                    otrKeys.Add(otrUniqueId);
                }

                // --

                return otrList.ToArray();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListOcn = null;
                fXmlNodeOtr = null;
                otrKeys = null;
                otrList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------
        // Add by Jeff.Kim 2015.10.08
        // Session 별로 Connection State 처리를 위해 추가
        public static FXmlNode[] parseConnectionTrigger2(
            FOpcDriver fOcd,
            FOpcSession fOsn,
            FXmlNode fXmlNodeOvcl,
            FDeviceState fDeviceState
            )
        {
            const string OpcConditionQuery =
                FXmlTagEQM.E_EquipmentModeling +
                "/" + FXmlTagEQP.E_Equipment +
                "[@" + FXmlTagEQP.A_Name + "='{0}']" +
                "/" + FXmlTagSNG.E_ScenarioGroup +
                "/" + FXmlTagSNR.E_Scenario +
                "/" + FXmlTagOTR.E_OpcTrigger +
                "/" + FXmlTagOCN.E_OpcCondition +
                "[@" + FXmlTagOCN.A_ConditionMode + "='{1}' and" +
                " @" + FXmlTagOCN.A_OpcDeviceId + "='{2}' and" +                
                " @" + FXmlTagOCN.A_ConnectionState + "='{3}']";

            // --

            FXmlNodeList fXmlNodeListOcn = null;
            FXmlNode fXmlNodeOtr = null;
            string xpath = string.Empty;
            HashSet<string> otrKeys = null;
            List<FXmlNode> otrList = null;
            string otrUniqueId = string.Empty;

            try
            {
                xpath = string.Format(
                    OpcConditionQuery,
                    fOsn.name,
                    FEnumConverter.fromConditionMode(FConditionMode.Connection),
                    fXmlNodeOvcl.get_attrVal(FXmlTagODV.A_UniqueId, FXmlTagODV.D_UniqueId),                    
                    FEnumConverter.fromDeviceState(fDeviceState)
                    );
                fXmlNodeListOcn = fOcd.fXmlNode.selectNodes(xpath);

                // --

                otrKeys = new HashSet<string>();
                otrList = new List<FXmlNode>();
                // --
                foreach (FXmlNode fXmlNodeScn in fXmlNodeListOcn)
                {
                    // ***
                    // 중복 조건 검사
                    // ***
                    fXmlNodeOtr = fXmlNodeScn.fParentNode;
                    otrUniqueId = fXmlNodeOtr.get_attrVal(FXmlTagOTR.A_UniqueId, FXmlTagOTR.D_UniqueId);
                    if (otrKeys.Contains(otrUniqueId))
                    {
                        continue;
                    }

                    // --

                    otrList.Add(fXmlNodeOtr);
                    otrKeys.Add(otrUniqueId);
                }

                // --

                return otrList.ToArray();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListOcn = null;
                fXmlNodeOtr = null;
                otrKeys = null;
                otrList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void compareCondition(
            FOpcDriver fOcd,
            FXmlNode fXmlNodeOmgl,
            FXmlNode fXmlNodeOep,
            ref bool oldResult
            )
        {
            const string OpcItemLogQuery = ".//" + FXmlTagOITL.E_OpcItem + "[@" + FXmlTagOITL.A_UniqueId + "='{0}']";
            // --

            const string OpcEventItemLogQuery = ".//" + FXmlTagOEIL.E_OpcEventItem + "[@" + FXmlTagOEIL.A_UniqueId + "='{0}']";

            // --
            const string EnvironmentQuery =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagEND.E_EnvironmentDefinition +
                "/" + FXmlTagENL.E_EnvironmentList +
                "//" + FXmlTagENV.E_Environment + "[@" + FXmlTagENV.A_UniqueId + "='{0}']";
            // --
            const string EquipmentStateQuery =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagESD.E_EquipmentStateSetDefinition +
                "/" + FXmlTagESL.E_EquipmentStateSetList +
                "/" + FXmlTagESS.E_EquipmentStateSet +
                "/" + FXmlTagEST.E_EquipmentState + "[@" + FXmlTagEST.A_UniqueId + "='{0}']";

            // --

            FXmlNodeList fXmlNodeListChild = null;
            FXmlNodeList fXmlNodeListOpe = null;
            FXmlNode fXmlNodeOpe = null;
            FXmlNode fXmlNodeEq = null;
            string operandUniqueId = string.Empty;
            int operandIndex = 0;
            FFormat fOperandFormat = FFormat.Ascii;
            FOperation fOperation = FOperation.Equal;
            FLogical fLogical = FLogical.And;
            FExpressionType fExpressionType = FExpressionType.Bracket;
            FComparisonMode fComparisonMode = FComparisonMode.Value;
            FOpcOperandType fOperandType = FOpcOperandType.OpcItem;
            FExpressionValueType fExpressionValueType = FExpressionValueType.Value;
            FOpcResourceSourceType fResourceSourceType = FOpcResourceSourceType.None;
            FEquipmentStateMaterial fEquipmentStateMaterial = null;
            string operandValue = string.Empty;
            int operandValueLength = 0;
            string value = string.Empty;
            string eqUniqueId = string.Empty;
            int length = 0;
            object oVal1 = null;
            object oVal2 = null;
            bool newResult = false;

            try
            {
                fExpressionType = FEnumConverter.toExpressionType(fXmlNodeOep.get_attrVal(FXmlTagOEP.A_ExpressionType, FXmlTagOEP.D_ExpressionType));
                fLogical = FEnumConverter.toLogical(fXmlNodeOep.get_attrVal(FXmlTagOEP.A_Logical, FXmlTagOEP.D_Logical));

                // --

                if (fExpressionType == FExpressionType.Bracket)
                {
                    newResult = true;
                    fXmlNodeListChild = fXmlNodeOep.selectNodes(FXmlTagOEP.E_OpcExpression);
                    foreach (FXmlNode fXmlNodeChild in fXmlNodeListChild)
                    {
                        compareCondition(fOcd, fXmlNodeOmgl, fXmlNodeChild, ref newResult);
                    }
                    oldResult = compareResult(fLogical, oldResult, newResult);
                    return;
                }

                // --

                // ***
                // Operand가 존재하지 않을 경우 False 설정
                // ***
                operandUniqueId = fXmlNodeOep.get_attrVal(FXmlTagOEP.A_OperandId, FXmlTagOEP.D_OperandId);
                if (operandUniqueId == string.Empty)
                {
                    oldResult = compareResult(fLogical, oldResult, false);
                    return;
                }

                // --

                fComparisonMode = FEnumConverter.toComparisonMode(fXmlNodeOep.get_attrVal(FXmlTagOEP.A_ComparisonMode, FXmlTagOEP.D_ComparisonMode));
                operandIndex = int.Parse(fXmlNodeOep.get_attrVal(FXmlTagOEP.A_OperandIndex, FXmlTagOEP.D_OperandIndex));
                fOperation = FEnumConverter.toOperation(fXmlNodeOep.get_attrVal(FXmlTagOEP.A_Operation, FXmlTagOEP.D_Operation));
                fOperandType = FEnumConverter.toOpcOperandType(fXmlNodeOep.get_attrVal(FXmlTagOEP.A_OperandType, FXmlTagOEP.D_OperandType));
                fOperandFormat = FEnumConverter.toFormat(fXmlNodeOep.get_attrVal(FXmlTagOEP.A_OperandFormat, FXmlTagOEP.D_OperandFormat));
                fExpressionValueType = FEnumConverter.toExpressionValueType(fXmlNodeOep.get_attrVal(FXmlTagOEP.A_ExpressionValueType, FXmlTagOEP.D_ExpressionValueType));

                // --

                // ***
                // Operand Length는 Ascii 계열이외에만 사용되고 Operand Length는 0 또는 1만을 가질수 있기 때문에
                // 값이 존재하지 않을 경우 0처리하고 값이 존재할 경우 1처리한다.
                // Operand Format이 Ascii 계열인 경우 Operand Length를 사용하지 않는다.
                // ***
                if (fExpressionValueType == FExpressionValueType.Value)
                {
                    operandValue = fXmlNodeOep.get_attrVal(FXmlTagOEP.A_Value, FXmlTagOEP.D_Value);
                }
                else
                {
                    fResourceSourceType = FEnumConverter.toOpcResourceSourceType(fXmlNodeOep.get_attrVal(FXmlTagOEP.A_Resource, FXmlTagOEP.D_Resource));

                    // --

                    if (fResourceSourceType == FOpcResourceSourceType.EapName)
                    {
                        operandValue = fOcd.eapName;
                    }
                    else if (fResourceSourceType == FOpcResourceSourceType.EquipmentName)
                    {
                        fXmlNodeEq = fXmlNodeOep.fParentNode.fParentNode.fParentNode.fParentNode.fParentNode;
                        operandValue = fXmlNodeEq.get_attrVal(FXmlTagEQP.A_Name, FXmlTagEQP.D_Name);
                    }
                    else if (fResourceSourceType == FOpcResourceSourceType.OpcDeviceName)
                    {
                        operandValue = fXmlNodeOmgl.get_attrVal(FXmlTagOMGL.A_OpcDeviceName, FXmlTagOMGL.D_OpcDeviceName);
                    }
                    else if (fResourceSourceType == FOpcResourceSourceType.OpcSessionName)
                    {
                        operandValue = fXmlNodeOmgl.get_attrVal(FXmlTagOMGL.A_OpcSessionName, FXmlTagOMGL.D_OpcSessionName);
                    }
                    else if (fResourceSourceType == FOpcResourceSourceType.OpcSessionId)
                    {
                        operandValue = fXmlNodeOmgl.get_attrVal(FXmlTagOMGL.A_OpcSessionId, FXmlTagOMGL.D_OpcSessionId);
                    }
                    else
                    {
                        operandValue = string.Empty;
                    }
                }
                operandValueLength = (operandValue == string.Empty ? 0 : 1);

                // --                    

                if (fOperandType == FOpcOperandType.OpcItem)
                {
                    // ***
                    // Operand가 존재하지 않을 경우 False 설정
                    // ***
                    fXmlNodeListOpe = fXmlNodeOmgl.selectNodes(string.Format(OpcItemLogQuery, operandUniqueId));
                    if (operandIndex >= fXmlNodeListOpe.count)
                    {
                        oldResult = compareResult(fLogical, oldResult, false);
                        return;
                    }

                    // --

                    fXmlNodeOpe = fXmlNodeListOpe[operandIndex];
                    length = int.Parse(fXmlNodeOpe.get_attrVal(FXmlTagOITL.A_Length, FXmlTagOITL.D_Length));
                    value = FValueConverter.toDataConversionStringValue(
                        fOperandFormat,
                        fXmlNodeOpe.get_attrVal(FXmlTagOITL.A_Value, FXmlTagOITL.D_Value),
                        fXmlNodeOpe.get_attrVal(FXmlTagOITL.A_Transformer, FXmlTagOITL.D_Transformer),
                        fXmlNodeOpe.get_attrVal(FXmlTagOITL.A_DataConversionSetExpression, FXmlTagOITL.D_DataConversionSetExpression),
                        ref length
                        );
                }
                else if (fOperandType == FOpcOperandType.OpcEventItem)
                {
                    // ***
                    // Operand가 존재하지 않을 경우 False 설정
                    // ***
                    fXmlNodeListOpe = fXmlNodeOmgl.selectNodes(string.Format(OpcEventItemLogQuery, operandUniqueId));
                    if (operandIndex >= fXmlNodeListOpe.count)
                    {
                        oldResult = compareResult(fLogical, oldResult, false);
                        return;
                    }

                    // --

                    fXmlNodeOpe = fXmlNodeListOpe[operandIndex];
                    length = int.Parse(fXmlNodeOpe.get_attrVal(FXmlTagOEIL.A_Length, FXmlTagOEIL.D_Length));
                    value = FValueConverter.toDataConversionStringValue(
                        fOperandFormat,
                        fXmlNodeOpe.get_attrVal(FXmlTagOEIL.A_Value, FXmlTagOEIL.D_Value),
                        fXmlNodeOpe.get_attrVal(FXmlTagOEIL.A_Transformer, FXmlTagOEIL.D_Transformer),
                        string.Empty,
                        ref length
                        );
                }
                else if (fOperandType == FOpcOperandType.Environment)
                {
                    // ***
                    // Operand가 존재하지 않을 경우 False 설정
                    // ***
                    fXmlNodeListOpe = fOcd.fXmlNode.selectNodes(string.Format(EnvironmentQuery, operandUniqueId));
                    if (operandIndex >= fXmlNodeListOpe.count)
                    {
                        oldResult = compareResult(fLogical, oldResult, false);
                        return;
                    }

                    // --

                    fXmlNodeOpe = fXmlNodeListOpe[operandIndex];
                    length = int.Parse(fXmlNodeOpe.get_attrVal(FXmlTagENV.A_Length, FXmlTagENV.D_Length));
                    value = fXmlNodeOpe.get_attrVal(FXmlTagENV.A_Value, FXmlTagENV.D_Value);
                }
                else if (fOperandType == FOpcOperandType.EquipmentState)
                {
                    // ***
                    // Operand가 존재하지 않을 경우 False 설정
                    // ***
                    fXmlNodeListOpe = fOcd.fXmlNode.selectNodes(string.Format(EquipmentStateQuery, operandUniqueId));
                    if (operandIndex >= fXmlNodeListOpe.count)
                    {
                        oldResult = compareResult(fLogical, oldResult, false);
                        return;
                    }

                    // --

                    fXmlNodeEq = fXmlNodeOep.fParentNode.fParentNode.fParentNode.fParentNode.fParentNode;
                    eqUniqueId = fXmlNodeEq.get_attrVal(FXmlTagEQP.A_UniqueId, FXmlTagEQP.D_UniqueId);

                    // --

                    fEquipmentStateMaterial = fOcd.fEquipmentStateMaterialStorage.getEquipmentStateMaterial(
                        eqUniqueId,
                        operandUniqueId
                        );
                    if (fEquipmentStateMaterial == null)
                    {
                        oldResult = compareResult(fLogical, oldResult, false);
                        return;
                    }

                    // --

                    length = 1;
                    value = fEquipmentStateMaterial.stateValue;
                }

                // --

                // ***
                // OPC Expression Transformer 적용
                // ***
                value = FValueConverter.toDataConversionStringValue(
                    fOperandFormat,
                    value,
                    fXmlNodeOep.get_attrVal(FXmlTagOEP.A_Transformer, FXmlTagOEP.D_Transformer),
                    fXmlNodeOep.get_attrVal(FXmlTagOEP.A_DataConversionSetExpression, FXmlTagOEP.D_DataConversionSetExpression),
                    ref length
                    );

                // --

                newResult = true;

                // --

                if (fComparisonMode == FComparisonMode.Value)
                {
                    if (fOperandFormat == FFormat.Ascii || fOperandFormat == FFormat.A2 || fOperandFormat == FFormat.JIS8)
                    {
                        #region Ascii

                        if (fOperation == FOperation.Equal)
                        {
                            newResult = (string.Compare(value, operandValue) == 0 ? true : false);
                        }
                        else if (fOperation == FOperation.NotEqual)
                        {
                            newResult = (string.Compare(value, operandValue) != 0 ? true : false);
                        }
                        else if (fOperation == FOperation.MoreThan)
                        {
                            newResult = (string.Compare(value, operandValue) > 0 ? true : false);
                        }
                        else if (fOperation == FOperation.MoreThanOrEqual)
                        {
                            newResult = (string.Compare(value, operandValue) >= 0 ? true : false);
                        }
                        else if (fOperation == FOperation.LessThan)
                        {
                            newResult = (string.Compare(value, operandValue) < 0 ? true : false);
                        }
                        else if (fOperation == FOperation.LessThanOrEqual)
                        {
                            newResult = (string.Compare(value, operandValue) <= 0 ? true : false);
                        }

                        #endregion
                    }
                    else
                    {
                        #region Not Ascii

                        if (length > 1)
                        {
                            // ***
                            // Ascii 계열이 아니고 Length가 1 보다 클 경우 False 처리
                            // ***
                            newResult = false;
                        }
                        else if (length == 0)
                        {
                            if (operandValueLength > 1)
                            {
                                newResult = false;
                            }
                            else if (operandValueLength == 0)
                            {
                                if (
                                    fOperation == FOperation.Equal ||
                                    fOperation == FOperation.MoreThanOrEqual ||
                                    fOperation == FOperation.LessThanOrEqual
                                    )
                                {
                                    newResult = true;
                                }
                                else
                                {
                                    newResult = false;
                                }
                            }
                            else
                            {
                                if (
                                    fOperation == FOperation.NotEqual ||
                                    fOperation == FOperation.LessThan ||
                                    fOperation == FOperation.LessThanOrEqual
                                    )
                                {
                                    newResult = true;
                                }
                                else
                                {
                                    newResult = false;
                                }
                            }
                        }
                        else
                        {
                            oVal1 = FValueConverter.toValue(fOperandFormat, value);

                            // --

                            if (operandValueLength > 1)
                            {
                                newResult = false;
                            }
                            else if (operandValueLength == 0)
                            {
                                if (
                                    fOperation == FOperation.NotEqual ||
                                    fOperation == FOperation.MoreThan ||
                                    fOperation == FOperation.MoreThanOrEqual
                                    )
                                {
                                    newResult = true;
                                }
                                else
                                {
                                    newResult = false;
                                }
                            }
                            else
                            {
                                oVal2 = FValueConverter.toValue(fOperandFormat, operandValue);

                                // --

                                if (fOperandFormat == FFormat.Binary)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((byte)oVal1 == (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((byte)oVal1 != (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((byte)oVal1 > (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((byte)oVal1 >= (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((byte)oVal1 < (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((byte)oVal1 <= (byte)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.Boolean)
                                {
                                    if (
                                        fOperation == FOperation.Equal ||
                                        fOperation == FOperation.MoreThanOrEqual ||
                                        fOperation == FOperation.LessThanOrEqual
                                        )
                                    {
                                        newResult = ((bool)oVal1 == (bool)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((bool)oVal1 != (bool)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.I8)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((Int64)oVal1 == (Int64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((Int64)oVal1 != (Int64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((Int64)oVal1 > (Int64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((Int64)oVal1 >= (Int64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((Int64)oVal1 < (Int64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((Int64)oVal1 <= (Int64)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.I4)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((Int32)oVal1 == (Int32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((Int32)oVal1 != (Int32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((Int32)oVal1 > (Int32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((Int32)oVal1 >= (Int32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((Int32)oVal1 < (Int32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((Int32)oVal1 <= (Int32)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.I2)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((Int16)oVal1 == (Int16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((Int16)oVal1 != (Int16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((Int16)oVal1 > (Int16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((Int16)oVal1 >= (Int16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((Int16)oVal1 < (Int16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((Int16)oVal1 <= (Int16)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.I1)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((sbyte)oVal1 == (sbyte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((sbyte)oVal1 != (sbyte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((sbyte)oVal1 > (sbyte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((sbyte)oVal1 >= (sbyte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((sbyte)oVal1 < (sbyte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((sbyte)oVal1 <= (sbyte)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.F8)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((Double)oVal1 == (Double)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((Double)oVal1 != (Double)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((Double)oVal1 > (Double)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((Double)oVal1 >= (Double)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((Double)oVal1 < (Double)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((Double)oVal1 <= (Double)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.F4)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((Single)oVal1 == (Single)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((Single)oVal1 != (Single)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((Single)oVal1 > (Single)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((Single)oVal1 >= (Single)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((Single)oVal1 < (Single)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((Single)oVal1 <= (Single)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.U8)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((UInt64)oVal1 == (UInt64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((UInt64)oVal1 != (UInt64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((UInt64)oVal1 > (UInt64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((UInt64)oVal1 >= (UInt64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((UInt64)oVal1 < (UInt64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((UInt64)oVal1 <= (UInt64)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.U4)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((UInt32)oVal1 == (UInt32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((UInt32)oVal1 != (UInt32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((UInt32)oVal1 > (UInt32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((UInt32)oVal1 >= (UInt32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((UInt32)oVal1 < (UInt32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((UInt32)oVal1 <= (UInt32)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.U2)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((UInt16)oVal1 == (UInt16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((UInt16)oVal1 != (UInt16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((UInt16)oVal1 > (UInt16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((UInt16)oVal1 >= (UInt16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((UInt16)oVal1 < (UInt16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((UInt16)oVal1 <= (UInt16)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.U1)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((byte)oVal1 == (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((byte)oVal1 != (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((byte)oVal1 > (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((byte)oVal1 >= (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((byte)oVal1 < (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((byte)oVal1 <= (byte)oVal2 ? true : false);
                                    }
                                }
                            }
                        }   // length compare end

                        #endregion
                    }   // ascii or no ascii if end                          
                }
                else
                {
                    if (!int.TryParse(operandValue, out operandValueLength))
                    {
                        newResult = false;
                    }
                    else
                    {
                        if (fOperation == FOperation.Equal)
                        {
                            newResult = (length == operandValueLength ? true : false);
                        }
                        else if (fOperation == FOperation.NotEqual)
                        {
                            newResult = (length != operandValueLength ? true : false);
                        }
                        else if (fOperation == FOperation.MoreThan)
                        {
                            newResult = (length > operandValueLength ? true : false);
                        }
                        else if (fOperation == FOperation.MoreThanOrEqual)
                        {
                            newResult = (length >= operandValueLength ? true : false);
                        }
                        else if (fOperation == FOperation.LessThan)
                        {
                            newResult = (length < operandValueLength ? true : false);
                        }
                        else if (fOperation == FOperation.LessThanOrEqual)
                        {
                            newResult = (length <= operandValueLength ? true : false);
                        }
                    }
                }   // comparison if end

                // --

                oldResult = compareResult(fLogical, oldResult, newResult);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListChild = null;
                fXmlNodeListOpe = null;
                fXmlNodeOpe = null;
                fXmlNodeEq = null;
                fEquipmentStateMaterial = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static bool compareResult(
            FLogical fLogical,
            bool oldResult,
            bool newResult
            )
        {
            try
            {
                if (fLogical == FLogical.And)
                {
                    return oldResult & newResult;
                }
                return oldResult | newResult;
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

        public static void parseItemName(
            BrowseElement be,
            ref string itemName,
            ref FTagFormat fTagFormat,
            ref bool isArray
            )
        {
            Type t = null;

            try
            {
                itemName = be.Name;                
                // --
                foreach (ItemProperty prop in be.ItemProperties.RequestedItemProperties)
                {
                    if (prop.Description == "Item Value")
                    {
                        t = prop.Value.GetType();
                        isArray = t.IsArray;
                        break;
                    }
                }

                if (t == null)
                {
                    return;
                }

                // --

                if (t == typeof(string) || t == typeof(string[]))
                {
                    // ***
                    // string
                    // ***
                    fTagFormat = FTagFormat.String;
                }
                else if (t == typeof(byte) || t == typeof(byte[]))
                {
                    // ***
                    // Byte
                    // ***
                    fTagFormat = FTagFormat.Byte;
                }
                else if (t == typeof(UInt16) || t == typeof(UInt16[]))
                {
                    // ***
                    // Word or BCD
                    // ***
                    fTagFormat = FTagFormat.Word;
                }
                else if (t == typeof(Boolean) || t == typeof(Boolean[]))
                {
                    // ***
                    // Boolean
                    // ***
                    fTagFormat = FTagFormat.Boolean;
                }
                else if (t == typeof(SByte) || t == typeof(SByte[]))
                {
                    // ***
                    // Char
                    // ***                    
                    fTagFormat = FTagFormat.Char;
                }
                else if (t == typeof(Int16) || t == typeof(Int16[]))
                {
                    // ***
                    // Short
                    // ***                    
                    fTagFormat = FTagFormat.Short;
                }
                else if (t == typeof(Int32) || t == typeof(Int32[]))
                {
                    // ***
                    // Long
                    // ***
                    fTagFormat = FTagFormat.Long;
                }
                else if (t == typeof(UInt32) || t == typeof(UInt32[]))
                {
                    // ***
                    // DWord or LBCD
                    // ***
                    fTagFormat = FTagFormat.DWord;
                }
                else if (t == typeof(Single) || t == typeof(Single[]))
                {
                    // ***
                    // Float
                    // ***
                    fTagFormat = FTagFormat.Float;
                }
                else if (t == typeof(Double) || t == typeof(Double[]))
                {
                    // ***
                    // Double
                    // ***
                    fTagFormat = FTagFormat.Double;
                }
                else if (t == typeof(DateTime) || t == typeof(DateTime[]))
                {
                    // ***
                    // DateTime
                    // ***                        
                    fTagFormat = FTagFormat.Date;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
