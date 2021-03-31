/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FEnumConverter.cs
--  Creator         : spike.lee
--  Create Date     : 2011.02.10
--  Description     : FAMate Core FaSecsDriver Enum Converter Function Class 
--  History         : Created by spike.lee at 2011.01.28
                    : Modified by spike.lee at 2011.09.08
                        - FResultCode Enum Converter Add
                        - FSecsDeviceTimeout Enum Converter Add
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal static class FEnumConverter
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static string fromDirection(
            FDirection value
            )
        {
            try
            {
                if (value == FDirection.Equipment)
                {
                    return "E";
                }
                else if (value == FDirection.Host)
                {
                    return "H";
                }
                return "B";
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

        public static FDirection toDirection(
            string value
            )
        {
            try
            {
                if (value == "E")
                {
                    return FDirection.Equipment;
                }
                else if (value == "H")
                {
                    return FDirection.Host;
                }
                return FDirection.Both;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FDirection.Both;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromPattern(
            FPattern value
            )
        {
            try
            {
                if (value == FPattern.Variable)
                {
                    return "V";
                }
                return "F";
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

        public static FPattern toPattern(
            string value
            )
        {
            try
            {
               if (value == "V")
                {
                    return FPattern.Variable;
                }
                return FPattern.Fixed;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FPattern.Fixed;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromFormat(
            FFormat value
            )
        {
            try
            {
                return ((FFormatShortName)value).ToString();
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

        public static FFormat toFormat(
            string value
            )
        {
            try
            {
                return (FFormat)Enum.Parse(typeof(FFormatShortName), value);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FFormat.Ascii;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FFormat toFormat(
            int value
            )
        {
            try
            {
                if (value == 0)
                {
                    return FFormat.List;
                }
                else if (value == 8)
                {
                    return FFormat.Binary;
                }
                else if (value == 9)
                {
                    return FFormat.Boolean;
                }
                else if (value == 16)
                {
                    return FFormat.Ascii;
                }
                else if (value == 17)
                {
                    return FFormat.JIS8;
                }
                else if (value == 18)
                {
                    return FFormat.A2;
                }
                else if (value == 24)
                {
                    return FFormat.I8;
                }
                else if (value == 28)
                {
                    return FFormat.I4;
                }
                else if (value == 26)
                {
                    return FFormat.I2;
                }
                else if (value == 25)
                {
                    return FFormat.I1;
                }
                else if (value == 32)
                {
                    return FFormat.F8;
                }
                else if (value == 36)
                {
                    return FFormat.F4;
                }
                else if (value == 40)
                {
                    return FFormat.U8;
                }
                else if (value == 44)
                {
                    return FFormat.U4;
                }
                else if (value == 42)
                {
                    return FFormat.U2;
                }
                else if (value == 41)
                {
                    return FFormat.U1;
                }
                else if (value == 65) // Host Message 사용
                {
                    return FFormat.Char;
                }

                return FFormat.Unknown;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FFormat.Ascii;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromSecsLengthBytes(
            FSecsLengthBytes value
            )
        {
            try
            {
                return value.ToString("d");
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

        public static FSecsLengthBytes toSecsLengthBytes(
            string value
            )
        {
            try
            {
                return (FSecsLengthBytes)Enum.Parse(typeof(FSecsLengthBytes), value);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FSecsLengthBytes.Auto;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromLibraryType(
            FLibraryType value
            )
        {
            try
            {
                if (value == FLibraryType.SecsLibrary)                
                {
                    return "S";
                }
                return "H";
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

        public static FLibraryType toLibraryType(
            string value
            )
        {
            try
            {
                if (value == "S")
                {
                    return FLibraryType.SecsLibrary;
                }
                return FLibraryType.HostLibrary;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FLibraryType.SecsLibrary;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromConditionMode(
            FConditionMode value
            )
        {
            try
            {
                if (value == FConditionMode.Expression)
                {
                    return "E";
                }
                else if (value == FConditionMode.Connection)
                {
                    return "C";
                }
                return "T";
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

        public static FConditionMode toConditionMode(
            string value
            )
        {
            try
            {
                if (value == "E")
                {
                    return FConditionMode.Expression;
                }
                else if (value == "C")
                {
                    return FConditionMode.Connection;
                }
                return FConditionMode.Timeout;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FConditionMode.Expression;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromErrorAction(
            FErrorAction value
            )
        {
            try
            {
                if (value == FErrorAction.Stop)
                {
                    return "S";
                }
                return "I";
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

        public static FErrorAction toErrorAction(
            string value
            )
        {
            try
            {
                if (value == "S")
                {
                    return FErrorAction.Stop;
                }
                return FErrorAction.Ignore;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FErrorAction.Stop;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromDataSourceType(
            FDataSourceType value
            )
        {
            try
            {
                if (value == FDataSourceType.Constant)
                {
                    return "C";
                }
                else if (value == FDataSourceType.Resource)
                {
                    return "R";
                }
                else if (value == FDataSourceType.Message)
                {
                    return "M";
                }
                else if (value == FDataSourceType.EquipmentState)
                {
                    return "S";
                }
                else if (value == FDataSourceType.Environment)
                {
                    return "E";
                }
                else if (value == FDataSourceType.Column)
                {
                    return "O";
                }
                else if (value == FDataSourceType.ItemTag1)
                {
                    return "IT1";
                }
                else if (value == FDataSourceType.ItemTag2)
                {
                    return "IT2";
                }
                else if (value == FDataSourceType.ItemTag3)
                {
                    return "IT3";
                }
                else if (value == FDataSourceType.ItemTag4)
                {
                    return "IT4";
                }
                else if (value == FDataSourceType.ItemTag5)
                {
                    return "IT5";
                }
                return "I";                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return "I";
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FDataSourceType toDataSourceType(
            string value
            )
        {
            try
            {
                if (value == "C")
                {
                    return FDataSourceType.Constant;
                }
                else if (value == "R")
                {
                    return FDataSourceType.Resource;
                }
                else if (value == "M")
                {
                    return FDataSourceType.Message;
                }
                else if (value == "S")
                {
                    return FDataSourceType.EquipmentState;
                }
                else if (value == "E")
                {
                    return FDataSourceType.Environment;
                }
                else if (value == "O")
                {
                    return FDataSourceType.Column;
                }
                else if (value == "IT1")
                {
                    return FDataSourceType.ItemTag1;
                }
                else if (value == "IT2")
                {
                    return FDataSourceType.ItemTag2;
                }
                else if (value == "IT3")
                {
                    return FDataSourceType.ItemTag3;
                }
                else if (value == "IT4")
                {
                    return FDataSourceType.ItemTag4;
                }
                else if (value == "IT5")
                {
                    return FDataSourceType.ItemTag5;
                }
                return FDataSourceType.Item;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FDataSourceType.Item;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromDataTargetType(
            FDataTargetType value
            )
        {
            try
            {
                if (value == FDataTargetType.Constant)
                {
                    return "C";
                }
                else if (value == FDataTargetType.Column)
                {
                    return "O";
                }
                return "I";
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return "I";
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FDataTargetType toDataTargetType(
            string value
            )
        {
            try
            {
                if (value == "C")
                {
                    return FDataTargetType.Constant;
                }
                else if (value == "O")
                {
                    return FDataTargetType.Column;
                }
                return FDataTargetType.Item;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FDataTargetType.Item;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromHostMessageType(
            FHostMessageType value
            )
        {
            try
            {
                if (value == FHostMessageType.Command)
                {
                    return "C";
                }
                else if (value == FHostMessageType.Unsolicited)
                {
                    return "E";
                }
                return "R";
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

        public static FHostMessageType toHostMessageType(
            string value
            )
        {
            try
            {
                if (value == "C")
                {
                    return FHostMessageType.Command;
                }
                else if (value == "E")
                {
                    return FHostMessageType.Unsolicited;
                }
                return FHostMessageType.Reply;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FHostMessageType.Command;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromLogical(
            FLogical value
            )
        {
            try
            {
                if (value == FLogical.And)
                {
                    return "A";
                }
                return "O";
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

        public static FLogical toLogical(
            string value
            )
        {
            try
            {
                if (value == "A")
                {
                    return FLogical.And;
                }
                return FLogical.Or;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FLogical.And;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string toLogicalExp(
            FLogical value
            )
        {
            try
            {
                if (value == FLogical.And)
                {
                    return "And";
                }
                return "Or";
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

        public static string fromExpressionType(
            FExpressionType value
            )
        {
            try
            {
                if (value == FExpressionType.Bracket)
                {
                    return "B";
                }
                return "C";
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

        public static FExpressionType toExpressionType(
            string value
            )
        {
            try
            {
                if (value == "B")
                {
                    return FExpressionType.Bracket;
                }
                return FExpressionType.Comparison;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FExpressionType.Bracket;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromComparisonMode(
            FComparisonMode value
            )
        {
            try
            {
                if (value == FComparisonMode.Length)
                {
                    return "L";
                }
                return "V";
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

        public static FComparisonMode toComparisonMode(
            string value
            )
        {
            try
            {
                if (value == "L")
                {
                    return FComparisonMode.Length;
                }
                return FComparisonMode.Value;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FComparisonMode.Length;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromSecsOperandType(
            FSecsOperandType value
            )
        {
            try
            {
                if (value == FSecsOperandType.SecsItem)
                {
                    return "S";
                }
                else if (value == FSecsOperandType.Environment)
                {
                    return "E";
                }
                return "Q";
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

        public static FSecsOperandType toSecsOperandType(
            string value
            )
        {
            try
            {
                if (value == "S")
                {
                    return FSecsOperandType.SecsItem;
                }
                else if (value == "E")
                {
                    return FSecsOperandType.Environment;
                }
                return FSecsOperandType.EquipmentState;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FSecsOperandType.SecsItem;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromHostOperandType(
            FHostOperandType value
            )
        {
            try
            {
                if (value == FHostOperandType.HostItem)
                {
                    return "H";
                }
                else if (value == FHostOperandType.Environment)
                {
                    return "E";
                }
                return "Q";
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

        public static FHostOperandType toHostOperandType(
            string value
            )
        {
            try
            {
                if (value == "H")
                {
                    return FHostOperandType.HostItem;
                }
                else if (value == "E")
                {
                    return FHostOperandType.Environment;
                }
                return FHostOperandType.EquipmentState;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FHostOperandType.HostItem;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromExpressionValueType(
            FExpressionValueType value
            )
        {
            try
            {
                if (value == FExpressionValueType.Value)
                {
                    return "V";
                }
                return "R";
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

        public static FExpressionValueType toExpressionValueType(
            string value
            )
        {
            try
            {
                if (value == "V")
                {
                    return FExpressionValueType.Value;
                }
                return FExpressionValueType.Resource;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FExpressionValueType.Value;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromOperation(
            FOperation value
            )
        {
            try
            {
                if (value == FOperation.Equal)
                {
                    return "E";
                }
                else if (value == FOperation.NotEqual)
                {
                    return "NE";
                }
                else if (value == FOperation.MoreThan)
                {
                    return "M";
                }
                else if (value == FOperation.MoreThanOrEqual)
                {
                    return "ME";
                }
                else if (value == FOperation.LessThan)
                {
                    return "L";
                }
                return "LE";
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

        public static FOperation toOperation(
            string value
            )
        {
            try
            {
                if (value == "E")
                {
                    return FOperation.Equal;
                }
                else if (value == "NE")
                {
                    return FOperation.NotEqual;
                }
                else if (value == "M")
                {
                    return FOperation.MoreThan;
                }
                else if (value == "ME")
                {
                    return FOperation.MoreThanOrEqual;
                }
                else if (value == "L")
                {
                    return FOperation.LessThan;
                }
                return FOperation.LessThanOrEqual;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FOperation.Equal;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromConversionMode(
            FConversionMode value
            )
        {
            try
            {
                if (value == FConversionMode.Value)
                {
                    return "V";
                }
                return "R";
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

        public static FConversionMode toConversionMode(
            string value
            )
        {
            try
            {
                if (value == "V")
                {
                    return FConversionMode.Value;
                }
                return FConversionMode.Range;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FConversionMode.Value;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromPauserMode(
            FPauserMode value
            )
        {
            try
            {
                if (value == FPauserMode.Fixed)
                {
                    return "F";
                }
                return "R";
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

        public static FPauserMode toPauserMode(
            string value
            )
        {
            try
            {
                if (value == "F")
                {
                    return FPauserMode.Fixed;
                }
                return FPauserMode.Random;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FPauserMode.Fixed;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string toOperationExp(
            FOperation value
            )
        {
            try
            {
                if (value == FOperation.Equal)
                {
                    return "==";
                }
                else if (value == FOperation.NotEqual)
                {
                    return "!=";
                }
                else if (value == FOperation.MoreThan)
                {
                    return ">";
                }
                else if (value == FOperation.MoreThanOrEqual)
                {
                    return ">=";
                }
                else if (value == FOperation.LessThan)
                {
                    return "<";
                }
                return "<=";                
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

        public static string fromDeviceState(
            FDeviceState value
            )
        {
            try
            {
                if (value == FDeviceState.Opened)
                {
                    return "O";
                }
                else if (value == FDeviceState.Connected)
                {
                    return "N";
                }
                else if (value == FDeviceState.Selected)
                {
                    return "S";
                }
                return "C";
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

        public static FDeviceState toDeviceState(
            string value
            )
        {
            try
            {
                if (value == "O")
                {
                    return FDeviceState.Opened;
                }
                else if (value == "N")
                {
                    return FDeviceState.Connected;
                }
                else if (value == "S")
                {
                    return FDeviceState.Selected;
                }
                return FDeviceState.Closed;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FDeviceState.Closed;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromControlMessageType(
            FControlMessageType value
            )
        {
            try
            {
                return value.ToString("d");
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

        public static FControlMessageType toControlMessageType(
            string value
            )
        {
            try
            {
                return (FControlMessageType)Enum.Parse(typeof(FControlMessageType), value);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FControlMessageType.SelectReq;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromResultCode(
            FResultCode value
            )
        {
            try
            {
                if (value == FResultCode.Success)
                {
                    return "S";
                }
                else if (value == FResultCode.Warninig)
                {
                    return "W";
                }
                return "E";
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

        public static FResultCode toResultCode(
            string value
            )
        {
            try
            {
                if (value == "S")
                {
                    return FResultCode.Success;
                }
                else if (value == "W")
                {
                    return FResultCode.Warninig;
                }
                return FResultCode.Error;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FResultCode.Success;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromProtocol(
            FProtocol fProtocol
            )
        {
            try
            {
                if (fProtocol == FProtocol.HSMS)
                {
                    return "HSMS";
                }
                else if (fProtocol == FProtocol.SECS1)
                {
                    return "SECS1";
                }
                else if(fProtocol == FProtocol.TCPIP)
                {
                    return "TCPIP";
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

        public static string fromSecsDeviceTimeout(
            FSecsDeviceTimeout value
            )
        {
            try
            {
                return value.ToString("d");
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

        public static FSecsDeviceTimeout toSecsDeviceTimeout(
            string value
            )
        {
            try
            {
                return (FSecsDeviceTimeout)Enum.Parse(typeof(FSecsDeviceTimeout), value);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FSecsDeviceTimeout.T1;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromAutoCycleAction(
            FAutoCycleAction value
            )
        {
            try
            {
                if (value == FAutoCycleAction.Once)
                {
                    return "O";
                }
                return "R";
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

        public static FAutoCycleAction toAutoCycleAction(
            string value
            )
        {
            try
            {
                if (value == "O")
                {
                    return FAutoCycleAction.Once;
                }
                return FAutoCycleAction.Repeat;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FAutoCycleAction.Once;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromMessageSourceType(
            FMessageSourceType value
            )
        {
            try
            {
                if (value == FMessageSourceType.SystemBytes)
                {
                    return "S";
                }
                return "N";
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

        public static FMessageSourceType toMessageSourceType(
            string value
            )
        {
            try
            {
                if (value == "S")
                {
                    return FMessageSourceType.SystemBytes;
                }
                return FMessageSourceType.None;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FMessageSourceType.SystemBytes;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromResourceSourceType(
            FResourceSourceType value
            )
        {
            try
            {
                if (value == FResourceSourceType.EapName)
                {
                    return "PN";
                }
                else if (value == FResourceSourceType.EquipmentName)
                {
                    return "EN";
                }
                else if (value == FResourceSourceType.SecsDeviceName)
                {
                    return "SDN";
                }
                else if (value == FResourceSourceType.SecsSessionName)
                {
                    return "SSN";
                }
                else if (value == FResourceSourceType.SecsSessionId)
                {
                    return "SSI";
                }
                else if (value == FResourceSourceType.HostDeviceName)
                {
                    return "HDN";
                }
                else if (value == FResourceSourceType.HostSessionName)
                {
                    return "HSN";
                }
                else if (value == FResourceSourceType.HostSessionId)
                {
                    return "HSI";
                }
                else if (value == FResourceSourceType.HostMachineId)
                {
                    return "HMI";
                }
                return "N";
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

        public static FResourceSourceType toResourceSourceType(
            string value
            )
        {
            try
            {
                if (value == "PN")
                {
                    return FResourceSourceType.EapName;
                }
                else if (value == "EN")
                {
                    return FResourceSourceType.EquipmentName;
                }
                else if (value == "SDN")
                {
                    return FResourceSourceType.SecsDeviceName;
                }
                else if (value == "SSN")
                {
                    return FResourceSourceType.SecsSessionName;
                }
                else if (value == "SSI")
                {
                    return FResourceSourceType.SecsSessionId;
                }
                else if (value == "HDN")
                {
                    return FResourceSourceType.HostDeviceName;
                }
                else if (value == "HSN")
                {
                    return FResourceSourceType.HostSessionName;
                }
                else if (value == "HSI")
                {
                    return FResourceSourceType.HostSessionId;
                }
                else if (value == "HMI")
                {
                    return FResourceSourceType.HostMachineId;
                }
                return FResourceSourceType.None;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FResourceSourceType.EapName;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromSecsResourceSourceType(
            FSecsResourceSourceType value
            )
        {
            try
            {
                if (value == FSecsResourceSourceType.EapName)
                {
                    return "PN";
                }
                else if (value == FSecsResourceSourceType.EquipmentName)
                {
                    return "EN";
                }
                else if (value == FSecsResourceSourceType.SecsDeviceName)
                {
                    return "SDN";
                }
                else if (value == FSecsResourceSourceType.SecsSessionName)
                {
                    return "SSN";
                }
                else if (value == FSecsResourceSourceType.SecsSessionId)
                {
                    return "SSI";
                }
                return "N";
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

        public static FSecsResourceSourceType toSecsResourceSourceType(
            string value
            )
        {
            try
            {
                if (value == "PN")
                {
                    return FSecsResourceSourceType.EapName;
                }
                else if (value == "EN")
                {
                    return FSecsResourceSourceType.EquipmentName;
                }
                else if (value == "SDN")
                {
                    return FSecsResourceSourceType.SecsDeviceName;
                }
                else if (value == "SSN")
                {
                    return FSecsResourceSourceType.SecsSessionName;
                }
                else if (value == "SSI")
                {
                    return FSecsResourceSourceType.SecsSessionId;
                }

                return FSecsResourceSourceType.None;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FSecsResourceSourceType.EapName;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromHostResourceSourceType(
            FHostResourceSourceType value
            )
        {
            try
            {
                if (value == FHostResourceSourceType.EapName)
                {
                    return "PN";
                }
                else if (value == FHostResourceSourceType.EquipmentName)
                {
                    return "EN";
                }
                else if (value == FHostResourceSourceType.HostDeviceName)
                {
                    return "HDN";
                }
                else if (value == FHostResourceSourceType.HostSessionName)
                {
                    return "HSN";
                }
                else if (value == FHostResourceSourceType.HostSessionId)
                {
                    return "HSI";
                }
                else if (value == FHostResourceSourceType.HostMachineId)
                {
                    return "HMI";
                }
                return "N";
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

        public static FHostResourceSourceType toHostResourceSourceType(
            string value
            )
        {
            try
            {
                if (value == "PN")
                {
                    return FHostResourceSourceType.EapName;
                }
                else if (value == "EN")
                {
                    return FHostResourceSourceType.EquipmentName;
                }
                else if (value == "HDN")
                {
                    return FHostResourceSourceType.HostDeviceName;
                }
                else if (value == "HSN")
                {
                    return FHostResourceSourceType.HostSessionName;
                }
                else if (value == "HSI")
                {
                    return FHostResourceSourceType.HostSessionId;
                }
                else if (value == "HMI")
                {
                    return FHostResourceSourceType.HostMachineId;
                }
                return FHostResourceSourceType.None;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FHostResourceSourceType.EapName;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromDataScanMode(
            FDataScanMode value
            )
        {
            try
            {
                if (value == FDataScanMode.Local)
                {
                    return "L";
                }
                return "G";
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

        public static FDataScanMode toDataScanMode(
            string value
            )
        {
            try
            {
                if (value == "L")
                {
                    return FDataScanMode.Local;
                }
                return FDataScanMode.Global;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FDataScanMode.Local;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromStorageAction(
            FStorageAction value
            )
        {
            try
            {
                if (value == FStorageAction.Create)
                {
                    return "C";
                }
                else if (value == FStorageAction.Update)
                {
                    // ***
                    // 2017.04.03 by spike.lee
                    // Update 구현
                    // ***
                    return "U";
                }
                else if (value == FStorageAction.Remove)
                {
                    return "R";
                }
                else if (value == FStorageAction.RemoveAll)
                {
                    // ***
                    // 2017.04.03 by spike.lee
                    // Remove All 구현
                    // ***
                    return "RA";
                }
                return "S";
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

        public static FStorageAction toStorageAction(
            string value
            )
        {
            try
            {
                if (value == "C")
                {
                    return FStorageAction.Create;
                }
                else if (value == "U")
                {
                    // ***
                    // 2017.04.03 by spike.lee
                    // Update 구현
                    // *** 
                    return FStorageAction.Update;
                }
                else if (value == "R")
                {
                    return FStorageAction.Remove;
                }
                else if (value == "RA")
                {
                    // ***
                    // 2017.04.03 by spike.lee
                    // Remove All 구현
                    // ***
                    return FStorageAction.RemoveAll;
                }
                return FStorageAction.Select;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FStorageAction.Select;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromOperandIndexType(
            FOperandIndexType value
            )
        {
            try
            {
                if (value == FOperandIndexType.All)
                {
                    return "A";
                }
                return "P";
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

        public static FOperandIndexType toOperandIndexType(
            string value
            )
        {
            try
            {
                if (value == "A")
                {
                    return FOperandIndexType.All;
                }
                return FOperandIndexType.Position;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FOperandIndexType.All;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromOperandValueType(
            FOperandValueType value
            )
        {
            try
            {
                if (value == FOperandValueType.Data)
                {
                    return "D";
                }
                return "V";
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

        public static FOperandValueType toOperandValueType(
            string value
            )
        {
            try
            {
                if (value == "D")
                {
                    return FOperandValueType.Data;
                }
                return FOperandValueType.Value;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FOperandValueType.Value;
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        public static string fromTelnetPacketType(
            FTelnetPacketType value
            )
        {
            try
            {
                if (value == FTelnetPacketType.Data)
                {
                    return "D";
                }
                else if (value == FTelnetPacketType.Command)
                {
                    return "C";
                }
                else if (value == FTelnetPacketType.Option)
                {
                    return "O";
                }                
                else if (value == FTelnetPacketType.Subnegotiation)
                {
                    return "S";
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return "D";
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FTelnetPacketType toTelnetPacketType(
            string value
            )
        {
            try
            {
                if (value == "D")
                {
                    return FTelnetPacketType.Data;
                }
                else if (value == "C")
                {
                    return FTelnetPacketType.Command;
                }
                else if (value == "O")
                {
                    return FTelnetPacketType.Option;
                }
                else if (value == "S")
                {
                    return FTelnetPacketType.Subnegotiation;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FTelnetPacketType.Data;
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        public static string fromTelnetCommand(
            FTelnetCommand value
            )
        {
            try
            {
                if (value == FTelnetCommand.Will)
                {
                    return "WO";
                }
                else if (value == FTelnetCommand.Wont)
                {
                    return "WX";
                }
                else if (value == FTelnetCommand.Do)
                {
                    return "DO";
                }
                else if (value == FTelnetCommand.Dont)
                {
                    return "DX";
                }
                // --
                else if (value == FTelnetCommand.NoOperation)
                {
                    return "NO";
                }
                else if (value == FTelnetCommand.DataMark)
                {
                    return "DM";
                }
                else if (value == FTelnetCommand.Break)
                {
                    return "B";
                }
                else if(value == FTelnetCommand.InterruptProcess)
                {
                    return "IP";
                }
                else if (value == FTelnetCommand.AbortOutput)
                {
                    return "AO";
                }
                else if (value == FTelnetCommand.AreYouThere)
                {
                    return "AYT";
                }
                else if (value == FTelnetCommand.EraseCharacter)
                {
                    return "EC";
                }
                else if (value == FTelnetCommand.EraseLine)
                {
                    return "EL";
                }
                else if (value == FTelnetCommand.GoAhead)
                {
                    return "GA";
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

        public static FTelnetCommand toTelnetCommand(
            string value
            )
        {
            try
            {
                if (value == "WO")
                {
                    return FTelnetCommand.Will;
                }
                else if (value == "WX")
                {
                    return FTelnetCommand.Wont;
                }
                else if (value == "DO")
                {
                    return FTelnetCommand.Do;
                }
                else if (value == "DX")
                {
                    return FTelnetCommand.Dont;
                }
                // --
                else if (value == "NO")
                {
                    return FTelnetCommand.NoOperation;
                }
                else if (value == "DM")
                {
                    return FTelnetCommand.DataMark;
                }
                else if (value == "B")
                {
                    return FTelnetCommand.Break;
                }
                else if (value == "IP")
                {
                    return FTelnetCommand.InterruptProcess;
                }
                else if (value == "AO")
                {
                    return FTelnetCommand.AbortOutput;
                }
                else if (value == "AYT")
                {
                    return FTelnetCommand.AreYouThere;
                }
                else if (value == "EC")
                {
                    return FTelnetCommand.EraseCharacter;
                }
                else if (value == "EL")
                {
                    return FTelnetCommand.EraseLine;
                }
                else if (value == "GA")
                {
                    return FTelnetCommand.GoAhead;
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FTelnetCommand.NoOperation;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromTelnetOption(
            FTelnetOption value
            )
        {
            try
            {
                if (value == FTelnetOption.TransmitBinary)
                {
                    return "TB";
                }
                else if (value == FTelnetOption.Echo)
                {
                    return "E";
                }
                else if (value == FTelnetOption.Reconnection)
                {
                    return "R";
                }
                else if(value == FTelnetOption.SuppressGoAhead)
                {
                    return "SGA";
                }
                else if (value == FTelnetOption.ApproximateMessageSizeNegotiation)
                {
                    return "AMS";
                }
                else if (value == FTelnetOption.Status)
                {
                    return "S";
                }
                else if (value == FTelnetOption.TimingMark)
                {
                    return "TM";
                }
                else if (value == FTelnetOption.Rcte)
                {
                    return "RC";
                }
                else if (value == FTelnetOption.OutputLineWidth)
                {
                    return "OLW";
                }
                else if (value == FTelnetOption.OutputPageSize)
                {
                    return "OPS";
                }
                else if (value == FTelnetOption.OutputCarriageReturnDisposition)
                {
                    return "OCR";
                }
                else if (value == FTelnetOption.OutputHorizontalTabStops)
                {
                    return "OHS";
                }
                else if (value == FTelnetOption.OutputHorizontalTabDisposition)
                {
                    return "OHD";
                }
                else if (value == FTelnetOption.OutputFormfeedDisposition)
                {
                    return "OFD";
                }
                else if (value == FTelnetOption.OutputVerticalTabStops)
                {
                    return "OVS";
                }
                else if (value == FTelnetOption.OutputVerticalTabDisposition)
                {
                    return "OVD";
                }
                else if (value == FTelnetOption.OutputLinefeedDisposition)
                {
                    return "OLD";
                }
                else if (value == FTelnetOption.ExtendedAscii)
                {
                    return "EA";
                }
                else if (value == FTelnetOption.Logout)
                {
                    return "L";
                }
                else if (value == FTelnetOption.ByteMacro)
                {
                    return "BM";
                }
                else if (value == FTelnetOption.DataEntryTerminal)
                {
                    return "DET";
                }
                else if (value == FTelnetOption.SUPDUP)
                {
                    return "SD";
                }
                else if (value == FTelnetOption.SupdupOutput)
                {
                    return "SDO";
                }
                else if (value == FTelnetOption.SendLocation)
                {
                    return "SL";
                }
                else if (value == FTelnetOption.TerminalType)
                {
                    return "TT";
                }
                else if (value == FTelnetOption.EndOfRecord)
                {
                    return "EOR";
                }
                else if (value == FTelnetOption.TacacsUserId)
                {
                    return "TUI";
                }
                else if (value == FTelnetOption.OutputMarking)
                {
                    return "OM";
                }
                else if (value == FTelnetOption.TerminalLocation)
                {
                    return "TL";
                }
                else if (value == FTelnetOption.Ibm3270Regime)
                {
                    return "I3R";
                }
                else if (value == FTelnetOption.X3Pad)
                {
                    return "X3P";
                }
                else if (value == FTelnetOption.NAWS)
                {
                    return "WS";
                }
                else if (value == FTelnetOption.TerminalSpeed)
                {
                    return "TS";
                }
                else if (value == FTelnetOption.ToggleFlowControl)
                {
                    return "TFC";
                }
                else if (value == FTelnetOption.LineMode)
                {
                    return "LM";
                }
                else if (value == FTelnetOption.XDisplayLocation)
                {
                    return "XDL";
                }
                else if (value == FTelnetOption.Environment)
                {
                    return "ENV";
                }
                else if (value == FTelnetOption.Authentication)
                {
                    return "AUT";
                }
                else if (value == FTelnetOption.Encryption)
                {
                    return "ENC";
                }
                else if (value == FTelnetOption.NewEnvironment)
                {
                    return "NE";
                }
                else if (value == FTelnetOption.TN3270E)
                {
                    return "T3E";
                }
                else if (value == FTelnetOption.XAUTH)
                {
                    return "XA";
                }
                else if (value == FTelnetOption.CharacterSet)
                {
                    return "CS";
                }
                else if (value == FTelnetOption.RemoteSerialPort)
                {
                    return "RSP";
                }
                else if (value == FTelnetOption.ComPort)
                {
                    return "CP";
                }
                else if (value == FTelnetOption.SuppressLocalEcho)
                {
                    return "SLE";
                }
                else if (value == FTelnetOption.StartTLS)
                {
                    return "ST";
                }
                else if (value == FTelnetOption.Kermit)
                {
                    return "K";
                }
                else if (value == FTelnetOption.SendUrl)
                {
                    return "SU";
                }
                else if (value == FTelnetOption.ForwardX)
                {
                    return "FX";
                }
                else if (value == FTelnetOption.TeloptPragmaLogon)
                {
                    return "TPL";
                }
                else if (value == FTelnetOption.TeloptSspiLogon)
                {
                    return "TSL";
                }
                else if (value == FTelnetOption.TeloptPragmaHeartBeat)
                {
                    return "TPH";
                }
                else if (value == FTelnetOption.ExtendedOptionsList)
                {
                    return "EOL";
                }
            }
            catch(Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return string.Empty;
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public static FTelnetOption toTelnetOption(
            string value
            )
        {
            try
            {
                if (value == "TB")
                {
                    return FTelnetOption.TransmitBinary;
                }
                else if (value == "E")
                {
                    return FTelnetOption.Echo;
                }
                else if (value == "R")
                {
                    return FTelnetOption.Reconnection;
                }
                else if (value == "SGA")
                {
                    return FTelnetOption.SuppressGoAhead;
                }
                else if (value == "AMS")
                {
                    return FTelnetOption.ApproximateMessageSizeNegotiation;
                }
                else if (value == "S")
                {
                    return FTelnetOption.Status;
                }
                else if (value == "TM")
                {
                    return FTelnetOption.TimingMark;
                }
                else if (value == "RC")
                {
                    return FTelnetOption.Rcte;
                }
                else if (value == "OLW")
                {
                    return FTelnetOption.OutputLineWidth;
                }
                else if (value == "OPS")
                {
                    return FTelnetOption.OutputPageSize;
                }
                else if (value == "OCR")
                {
                    return FTelnetOption.OutputCarriageReturnDisposition;
                }
                else if (value == "OHS")
                {
                    return FTelnetOption.OutputHorizontalTabStops;
                }
                else if (value == "OHD")
                {
                    return FTelnetOption.OutputHorizontalTabDisposition;
                }
                else if (value == "OFD")
                {
                    return FTelnetOption.OutputFormfeedDisposition;
                }
                else if (value == "OVS")
                {
                    return FTelnetOption.OutputVerticalTabStops;
                }
                else if (value == "OVD")
                {
                    return FTelnetOption.OutputVerticalTabDisposition;
                }
                else if (value == "OLD")
                {
                    return FTelnetOption.OutputLinefeedDisposition;
                }
                else if (value == "EA")
                {
                    return FTelnetOption.ExtendedAscii;
                }
                else if (value == "L")
                {
                    return FTelnetOption.Logout;
                }
                else if (value == "BM")
                {
                    return FTelnetOption.ByteMacro;
                }
                else if (value == "DET")
                {
                    return FTelnetOption.DataEntryTerminal;
                }
                else if (value == "SD")
                {
                    return FTelnetOption.SUPDUP;
                }
                else if (value == "SDO")
                {
                    return FTelnetOption.SupdupOutput;
                }
                else if (value == "SL")
                {
                    return FTelnetOption.SendLocation;
                }
                else if (value == "TT")
                {
                    return FTelnetOption.TerminalType;
                }
                else if (value == "EOR")
                {
                    return FTelnetOption.EndOfRecord;
                }
                else if (value == "TUI")
                {
                    return FTelnetOption.TacacsUserId;
                }
                else if (value == "OM")
                {
                    return FTelnetOption.OutputMarking;
                }
                else if (value == "TL")
                {
                    return FTelnetOption.TerminalLocation;
                }
                else if (value == "I3R")
                {
                    return FTelnetOption.Ibm3270Regime;
                }
                else if (value == "X3P")
                {
                    return FTelnetOption.X3Pad;
                }
                else if (value == "WS")
                {
                    return FTelnetOption.NAWS;
                }
                else if (value == "TS")
                {
                    return FTelnetOption.TerminalSpeed;
                }
                else if (value == "TFC")
                {
                    return FTelnetOption.ToggleFlowControl;
                }
                else if (value == "LM")
                {
                    return FTelnetOption.LineMode;
                }
                else if (value == "XDL")
                {
                    return FTelnetOption.XDisplayLocation;
                }
                else if (value == "ENV")
                {
                    return FTelnetOption.Environment;
                }
                else if (value == "AUT")
                {
                    return FTelnetOption.Authentication;
                }
                else if (value == "ENC")
                {
                    return FTelnetOption.Encryption;
                }
                else if (value == "NE")
                {
                    return FTelnetOption.NewEnvironment;
                }
                else if (value == "T3E")
                {
                    return FTelnetOption.TN3270E;
                }
                else if (value == "XA")
                {
                    return FTelnetOption.XAUTH;
                }
                else if (value == "CS")
                {
                    return FTelnetOption.CharacterSet;
                }
                else if (value == "RSP")
                {
                    return FTelnetOption.RemoteSerialPort;
                }
                else if (value == "CP")
                {
                    return FTelnetOption.ComPort;
                }
                else if (value == "SLE")
                {
                    return FTelnetOption.SuppressLocalEcho;
                }
                else if (value == "ST")
                {
                    return FTelnetOption.StartTLS;
                }
                else if (value == "K")
                {
                    return FTelnetOption.Kermit;
                }
                else if (value == "SU")
                {
                    return FTelnetOption.SendUrl;
                }
                else if (value == "FX")
                {
                    return FTelnetOption.ForwardX;
                }
                else if (value == "TPL")
                {
                    return FTelnetOption.TeloptPragmaLogon;
                }
                else if (value == "TSL")
                {
                    return FTelnetOption.TeloptSspiLogon;
                }
                else if (value == "TPH")
                {
                    return FTelnetOption.TeloptPragmaHeartBeat;
                }
                else if (value == "EOL")
                {
                    return FTelnetOption.ExtendedOptionsList;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FTelnetOption.TransmitBinary;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromTelnetPosition(
            FTelnetPosition value
            )
        {
            try
            {
                if (value == FTelnetPosition.Local)
                {
                    return "L";
                }
                else if (value == FTelnetPosition.Remote)
                {
                    return "R";
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

        public static FTelnetPosition toTelnetPosition(
            string value
            )
        {
            try
            {
                if (value == "R")
                {
                    return FTelnetPosition.Remote;
                }
                else if (value == "L")
                {
                    return FTelnetPosition.Local;
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FTelnetPosition.Local;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromTelnetOptionState(
            FTelnetOptionState fTelnetOptionState
            )
        {
            try
            {
                if (fTelnetOptionState == FTelnetOptionState.Off)
                {
                    return "F";
                }
                else if (fTelnetOptionState == FTelnetOptionState.On)
                {
                    return "O";
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

        public static FTelnetOptionState toTelnetOptionState(
            string value
            )
        {
            try
            {
                if (value == "F")
                {
                    return FTelnetOptionState.Off;
                }
                else if (value == "O")
                {
                    return FTelnetOptionState.On;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FTelnetOptionState.Off;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromOperandIndexOption(
            FOperandIndexOption value
            )
        {
            try
            {
                if (value == FOperandIndexOption.And)
                {
                    return "A";
                }
                return "O";
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

        public static FOperandIndexOption toOperandIndexOption(
            string value
            )
        {
            try
            {
                if (value == "A")
                {
                    return FOperandIndexOption.And;
                }
                return FOperandIndexOption.Or;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FOperandIndexOption.And;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromStorageMode(
            FStorageMode value
            )
        {
            try
            {
                if (value == FStorageMode.Part)
                {
                    return "P";
                }
                return "A";
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return "I";
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FStorageMode toStorageMode(
            string value
            )
        {
            try
            {
                if (value == "P")
                {
                    return FStorageMode.Part;
                }
                return FStorageMode.All;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FStorageMode.All;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string fromLogLevel(
            FLogLevel value
            )
        {
            try
            {
                return ((int)value).ToString();                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return "1";
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FLogLevel toLogLevel(
            string value
            )
        {
            try
            {
                return (FLogLevel)int.Parse(value);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FLogLevel.Level1;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namesapce end