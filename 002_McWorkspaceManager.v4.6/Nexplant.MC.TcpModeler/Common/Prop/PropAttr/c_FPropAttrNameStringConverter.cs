/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrNameStringConverter.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.28
--  Description     : FAMate TCP Modeler Object Name String Conveter Attribute Class 
--  History         : Created by spike.lee at 2011.03.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.TcpModeler
{
    public class FPropAttrNameStringConverter : StringConverter
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override bool GetStandardValuesExclusive(
            ITypeDescriptorContext context
            )
        {
            try
            {
                return false;   // Keyboard Input Enable
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {

            }
            return base.GetStandardValuesExclusive(context);
        }

        //------------------------------------------------------------------------------------------------------------------------

        public override bool GetStandardValuesSupported(
            ITypeDescriptorContext context
            )
        {
            try
            {
                return true;    // Standard Input Enable
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {

            }
            return base.GetStandardValuesSupported(context);
        }

        //------------------------------------------------------------------------------------------------------------------------

        public override StandardValuesCollection GetStandardValues(
            ITypeDescriptorContext context
            )
        {
            FDynPropBase fProp = null;
            FObjectNameCollection fObnCollection = null;
            string[] values = null;

            try
            {
                fProp = (FDynPropBase)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                if (fProp is FPropTcd)
                {
                    fObnCollection = ((FPropTcd)fProp).fTcpDriver.fObjectNameCollection;
                }
                // --
                else if (fProp is FPropOnl)
                {
                    fObnCollection = ((FPropOnl)fProp).fObjectNameList.fObjectNameCollection;
                }
                else if (fProp is FPropObn)
                {
                    fObnCollection = ((FPropObn)fProp).fObjectName.fObjectNameCollection;
                }
                // --
                else if (fProp is FPropFnl)
                {
                    fObnCollection = ((FPropFnl)fProp).fFunctionNameList.fObjectNameCollection;
                }
                else if (fProp is FPropFna)
                {
                    fObnCollection = ((FPropFna)fProp).fFunctionName.fObjectNameCollection;
                }
                else if (fProp is FPropPna)
                {
                    fObnCollection = ((FPropPna)fProp).fParameterName.fObjectNameCollection;
                }
                else if (fProp is FPropArg)
                {
                    fObnCollection = ((FPropArg)fProp).fArgument.fObjectNameCollection;
                }
                // --
                else if (fProp is FPropRpl)
                {
                    fObnCollection = ((FPropRpl)fProp).fRepositoryList.fObjectNameCollection;
                }
                else if (fProp is FPropRps)
                {
                    fObnCollection = ((FPropRps)fProp).fRepository.fObjectNameCollection;
                }
                else if (fProp is FPropCol)
                {
                    fObnCollection = ((FPropCol)fProp).fColumn.fObjectNameCollection;
                }
                // --
                else if (fProp is FPropEnl)
                {
                    fObnCollection = ((FPropEnl)fProp).fEnvironmentList.fObjectNameCollection;
                }
                else if (fProp is FPropEnv)
                {
                    fObnCollection = ((FPropEnv)fProp).fEnvironment.fObjectNameCollection;
                }
                // --
                else if (fProp is FPropUtn)
                {
                    fObnCollection = ((FPropUtn)fProp).fUserTagName.fObjectNameCollection;
                }
                //--
                else if (fProp is FPropTlg)
                {
                    fObnCollection = ((FPropTlg)fProp).fTcpLibraryGroup.fObjectNameCollection;
                }
                else if (fProp is FPropTlb)
                {
                    fObnCollection = ((FPropTlb)fProp).fTcpLibrary.fObjectNameCollection;
                }
                else if (fProp is FPropTml)
                {
                    fObnCollection = ((FPropTml)fProp).fTcpMessageList.fObjectNameCollection;
                }
                else if (fProp is FPropTms)
                {
                    fObnCollection = ((FPropTms)fProp).fTcpMessages.fObjectNameCollection;
                }
                else if (fProp is FPropTmg)
                {
                    fObnCollection = ((FPropTmg)fProp).fTcpMessage.fObjectNameCollection;
                }
                else if (fProp is FPropTit)
                {
                    fObnCollection = ((FPropTit)fProp).fTcpItem.fObjectNameCollection;
                }
                // --
                else if (fProp is FPropTdv)
                {
                    fObnCollection = ((FPropTdv)fProp).fTcpDevice.fObjectNameCollection;
                }
                else if (fProp is FPropTsn)
                {
                    fObnCollection = ((FPropTsn)fProp).fTcpSession.fObjectNameCollection;
                }
                // --
                else if (fProp is FPropHlg)
                {
                    fObnCollection = ((FPropHlg)fProp).fHostLibraryGroup.fObjectNameCollection;
                }
                else if (fProp is FPropHlb)
                {
                    fObnCollection = ((FPropHlb)fProp).fHostLibrary.fObjectNameCollection;
                }
                else if (fProp is FPropHml)
                {
                    fObnCollection = ((FPropHml)fProp).fHostMessageList.fObjectNameCollection;
                }
                else if (fProp is FPropTms)
                {
                    fObnCollection = ((FPropTms)fProp).fTcpMessages.fObjectNameCollection;
                }
                else if (fProp is FPropHmg)
                {
                    fObnCollection = ((FPropHmg)fProp).fHostMessage.fObjectNameCollection;
                }
                else if (fProp is FPropHit)
                {
                    fObnCollection = ((FPropHit)fProp).fHostItem.fObjectNameCollection;
                }
                // --
                else if (fProp is FPropHdv)
                {
                    fObnCollection = ((FPropHdv)fProp).fHostDevice.fObjectNameCollection;
                }
                else if (fProp is FPropHsn)
                {
                    fObnCollection = ((FPropHsn)fProp).fHostSession.fObjectNameCollection;
                }
                // --
                else if (fProp is FPropEqp)
                {
                    fObnCollection = ((FPropEqp)fProp).fEquipment.fObjectNameCollection;
                }
                else if (fProp is FPropSng)
                {
                    fObnCollection = ((FPropSng)fProp).fScenarioGroup.fObjectNameCollection;
                }
                else if (fProp is FPropSnr)
                {
                    fObnCollection = ((FPropSnr)fProp).fScenario.fObjectNameCollection;
                }
                else if (fProp is FPropTtr)
                {
                    fObnCollection = ((FPropTtr)fProp).fTcpTrigger.fObjectNameCollection;
                }
                else if (fProp is FPropTcn)
                {
                    fObnCollection = ((FPropTcn)fProp).fTcpCondition.fObjectNameCollection;
                }
                else if (fProp is FPropTep)
                {
                    fObnCollection = ((FPropTep)fProp).fTcpExpression.fObjectNameCollection;
                }
                else if (fProp is FPropTtn)
                {
                    fObnCollection = ((FPropTtn)fProp).fTcpTransmitter.fObjectNameCollection;
                }
                else if (fProp is FPropTtf)
                {
                    fObnCollection = ((FPropTtf)fProp).fTcpTransfer.fObjectNameCollection;
                }
                else if (fProp is FPropHtr)
                {
                    fObnCollection = ((FPropHtr)fProp).fHostTrigger.fObjectNameCollection;
                }
                else if (fProp is FPropHcn)
                {
                    fObnCollection = ((FPropHcn)fProp).fHostCondition.fObjectNameCollection;
                }
                else if (fProp is FPropHep)
                {
                    fObnCollection = ((FPropHep)fProp).fHostExpression.fObjectNameCollection;
                }
                else if (fProp is FPropHtn)
                {
                    fObnCollection = ((FPropHtn)fProp).fHostTransmitter.fObjectNameCollection;
                }
                else if (fProp is FPropHtf)
                {
                    fObnCollection = ((FPropHtf)fProp).fHostTransfer.fObjectNameCollection;
                }
                else if (fProp is FPropJdm)
                {
                    fObnCollection = ((FPropJdm)fProp).fJudgement.fObjectNameCollection;
                }
                else if (fProp is FPropJcn)
                {
                    fObnCollection = ((FPropJcn)fProp).fJudgementCondition.fObjectNameCollection;
                }
                else if (fProp is FPropJep)
                {
                    fObnCollection = ((FPropJep)fProp).fJudgementExpression.fObjectNameCollection;
                }
                else if (fProp is FPropMap)
                {
                    fObnCollection = ((FPropMap)fProp).fMapper.fObjectNameCollection;
                }
                else if (fProp is FPropEsa)
                {
                    fObnCollection = ((FPropEsa)fProp).fEquipmentStateSetAlterer.fObjectNameCollection;
                }
                else if (fProp is FPropStg)
                {
                    fObnCollection = ((FPropStg)fProp).fStorage.fObjectNameCollection;
                }
                else if (fProp is FPropCbk)
                {
                    fObnCollection = ((FPropCbk)fProp).fCallback.fObjectNameCollection;
                }
                else if (fProp is FPropFun)
                {
                    fObnCollection = ((FPropFun)fProp).fFunction.fObjectNameCollection;
                }
                else if (fProp is FPropBrn)
                {
                    fObnCollection = ((FPropBrn)fProp).fBranch.fObjectNameCollection;
                }
                else if (fProp is FPropCmt)
                {
                    fObnCollection = ((FPropCmt)fProp).fComment.fObjectNameCollection;
                }

                // --

                if (fObnCollection == null)
                {
                    return base.GetStandardValues(context);
                }

                // --

                values = new string[fObnCollection.count];
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = fObnCollection[i].name;
                }

                // --

                return new StandardValuesCollection(values);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {
                fProp = null;
                fObnCollection = null;
            }
            return base.GetStandardValues(context);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
