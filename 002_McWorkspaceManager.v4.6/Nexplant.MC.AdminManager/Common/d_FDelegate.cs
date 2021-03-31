/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : d_Delegate.cs
--  Creator         : spike.lee
--  Create Date     : 2013.01.16
--  Description     : FAMate Admin Manager Delegate Definition File 
--  History         : Created by spike.lee at 2013.01.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.AdminManager
{

    //------------------------------------------------------------------------------------------------------------------------       

    public delegate void FMonitoringServerDataReceivedEventHandler(object sender, FMonitoringServerDataReceivedEventArgs e);
    public delegate void FMonitoringPackageDataReceivedEventHandler(object sender, FMonitoringPackageDataReceivedEventArgs e);
    public delegate void FMonitoringPackageVerDataReceivedEventHandler(object sender, FMonitoringPackageVerDataReceivedEventArgs e);
    public delegate void FMonitoringModelDataReceivedEventHandler(object sender, FMonitoringModelDataReceivedEventArgs e);
    public delegate void FMonitoringModelVerDataReceivedEventHandler(object sender, FMonitoringModelVerDataReceivedEventArgs e);
    public delegate void FMonitoringComponentDataReceivedEventHandler(object sender, FMonitoringComponentDataReceivedEventArgs e);
    public delegate void FMonitoringComponentVerDataReceivedEventHandler(object sender, FMonitoringComponentVerDataReceivedEventArgs e);
    public delegate void FMonitoringEapDataReceivedEventHandler(object sender, FMonitoringEapDataReceivedEventArgs e);
    public delegate void FMonitoringEquipmentTypeDataReceivedEventHandler(object sender, FMonitoringEquipmentTypeDataReceivedEventArgs e);
    public delegate void FMonitoringEquipmentAreaDataReceivedEventHandler(object sender, FMonitoringEquipmentAreaDataReceivedEventArgs e);
    public delegate void FMonitoringEquipmentLineDataReceivedEventHandler(object sender, FMonitoringEquipmentLineDataReceivedEventArgs e);
    public delegate void FMonitoringEquipmentDataReceivedEventHandler(object sender, FMonitoringEquipmentDataReceivedEventArgs e);
    public delegate void FMonitoringDeviceDataReceivedEventHandler(object sender, FMonitoringDeviceDataReceivedEventArgs e);
    public delegate void FMonitoringSecs1ToHsmsConverterDataReceivedEventHandler(object sender, FMonitoringSecs1ToHsmsConverterDataReceivedEventArgs e);
    public delegate void FMonitoringSecs1ToHsmsConverterDisconnectDataReceivedEventHandler(object sender, FMonitoringSecs1ToHsmsConverterDisconnectDataReceivedEventArgs e);
    // --
    public delegate void FServerIssueEventRefreshEventHandler(object sender, EventArgs e);
    public delegate void FEapIssueEventRefreshEventHandler(object sender, EventArgs e);
    public delegate void FEquipmentIssueEventRefreshEventHandler(object sender, EventArgs e);

    //------------------------------------------------------------------------------------------------------------------------       
    
}   // Namespace end
