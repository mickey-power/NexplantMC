/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FEnumConverter.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.15
--  Description     : FAMate Core FaTcpDriver Enum Converter Function Class 
--  History         : Created by Jeff.Kim at 2013.07.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
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

        public static bool toArrayList(
            string value
            )
        {
            try
            {
                if (value == "T")
                {
                    return true;
                }
                else
                {
                    return false;
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

        public static string fromTcpMessageType(
            FTcpMessageType value
            )
        {
            try
            {
                if (value == FTcpMessageType.Command)
                {
                    return "C";
                }
                else if (value == FTcpMessageType.Unsolicited)
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

        public static FTcpMessageType toTcpMessageType(
            string value
            )
        {
            try
            {
                if (value == "C")
                {
                    return FTcpMessageType.Command;
                }
                else if (value == "E")
                {
                    return FTcpMessageType.Unsolicited;
                }
                return FTcpMessageType.Reply;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FTcpMessageType.Command;
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

        public static string fromConversionMode(
            FConversionMode value
            )
        {
            try
            {
                if (value == FConversionMode.Range)
                {
                    return "R";
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

        public static FConversionMode toConversionMode(
            string value
            )
        {
            try
            {
                if (value == "R")
                {
                    return FConversionMode.Range;
                }
                return FConversionMode.Value;
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

        public static string fromTcpOperandType(
            FTcpOperandType value
            )
        {
            try
            {
                if (value == FTcpOperandType.TcpItem)
                {
                    return "T";
                }                
                else if (value == FTcpOperandType.Environment)
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

        public static FTcpOperandType toTcpOperandType(
            string value
            )
        {
            try
            {
                if (value == "T")
                {
                    return FTcpOperandType.TcpItem;
                }               
                else if (value == "E")
                {
                    return FTcpOperandType.Environment;
                }
                return FTcpOperandType.EquipmentState;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FTcpOperandType.TcpItem;
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

        public static string fromHostResourceSourceType(
            FHostResourceSourceType value
            )
        {
            try
            {
                if (value == FHostResourceSourceType.EapName)
                {
                    return "ON";
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
                if (value == "ON")
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

        public static string fromTcpResourceSourceType(
            FTcpResourceSourceType value
            )
        {
            try
            {
                if (value == FTcpResourceSourceType.EapName)
                {
                    return "ON";
                }
                else if (value == FTcpResourceSourceType.EquipmentName)
                {
                    return "EN";
                }
                else if (value == FTcpResourceSourceType.TcpDeviceName)
                {
                    return "ODN";
                }
                else if (value == FTcpResourceSourceType.TcpSessionName)
                {
                    return "OSN";
                }
                else if (value == FTcpResourceSourceType.TcpSessionId)
                {
                    return "OSI";
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

        public static FTcpResourceSourceType toTcpResourceSourceType(
            string value
            )
        {
            try
            {
                if (value == "ON")
                {
                    return FTcpResourceSourceType.EapName;
                }
                else if (value == "EN")
                {
                    return FTcpResourceSourceType.EquipmentName;
                }
                else if (value == "ODN")
                {
                    return FTcpResourceSourceType.TcpDeviceName;
                }
                else if (value == "OSN")
                {
                    return FTcpResourceSourceType.TcpSessionName;
                }
                else if (value == "OSI")
                {
                    return FTcpResourceSourceType.TcpSessionId;
                }
                return FTcpResourceSourceType.None;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FTcpResourceSourceType.EapName;
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
                    return "ON";
                }
                else if (value == FResourceSourceType.EquipmentName)
                {
                    return "EN";
                }
                else if (value == FResourceSourceType.TcpDeviceName)
                {
                    return "ODN";
                }
                else if (value == FResourceSourceType.TcpSessionName)
                {
                    return "OSN";
                }
                else if (value == FResourceSourceType.TcpSessionId)
                {
                    return "OSI";
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
                if (value == "ON")
                {
                    return FResourceSourceType.EapName;
                }
                else if (value == "EN")
                {
                    return FResourceSourceType.EquipmentName;
                }
                else if (value == "ODN")
                {
                    return FResourceSourceType.TcpDeviceName;
                }
                else if (value == "OSN")
                {
                    return FResourceSourceType.TcpSessionName;
                }
                else if (value == "OSI")
                {
                    return FResourceSourceType.TcpSessionId;
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

        public static string fromTcpDeviceTimeout(
            FTcpDeviceTimeout value
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

        public static FTcpDeviceTimeout toTcpDeviceTimeout(
            string value
            )
        {
            try
            {
                return (FTcpDeviceTimeout)Enum.Parse(typeof(FTcpDeviceTimeout), value);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FTcpDeviceTimeout.T3;
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