/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDbErrorCode.cs
--  Creator         : kitae
--  Create Date     : 2011.03.10
--  Description     : FAMate Core FaCommon Database FDbErrorCode Class
--  History         : Created by kitae at 2011.03.10
----------------------------------------------------------------------------------------------------------*/
using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    internal static class FDbErrorCode
    {

        //------------------------------------------------------------------------------------------------------------------------
        
        #region Oracle DB Error Code Definition
        
        #region Comments
        /// <summary>
        /// Oracle DB Error Code(유일성 제약조건에 위배됩니다), //unique constraint violated
        /// </summary>
        #endregion
        public const int ORA_00001 = 1; //unique constraint violated

        #region Comments
        /// <summary>
        /// Oracle DB Error Code(자원 대기중 교착상태가 검출되었습니다. / deadlock detected while waiting for resource.)
        /// </summary>
        #endregion
        public const int ORA_00060 = 60; 

        #region Comments
        /// <summary>        
        ///Oracle DB Critical Error Code (아카이버 오류. 해제되기 전에는 내부 연결만 가능)
        /// </summary>
        #endregion
        public const int ORA_00257 = 257;

        #region Comments
        /// <summary>
        /// Oracle DB Error Code: 잘못된 변수명/번호
        /// </summary>
        #endregion
        public const int ORA_01036 = 1036;

        #region Comments
        /// <summary>
        /// Oracle DB Critical Error Code(정지 처리(즉시)중입니다 조작은 허가되지 않습니다.)
        /// </summary>
        #endregion
        public const int ORA_01089 = 1089;

        #region Comments
        /// <summary>
        /// Oracle DB Critical Error Code(테이블 %s.%s를 %s에 의해 %s 테이블 공간에서 확장할 수 없습니다.)
        /// </summary>
        #endregion
        public const int ORA_01653 = 1653;

        #region Comments
        /// <summary>
        /// Oracle DB Critical Error Code(색인 %s.%s를 %s에 의해 %s 테이블 공간에서 확장할 수 없습니다.)
        /// </summary>
        #endregion
        public const int ORA_01654 = 1654;
        
        #region Comments
        /// <summary>
        /// Oracle DB Critical Error Code(테이블스페이스 %s에 세그먼트에 대한 INITIAL 익스텐트를 작성할 수 없습니다.)
        /// </summary>
        #endregion
        public const int ORA_01658 = 1658;

        #region Comments
        /// <summary>
        /// Oracle DB Critical Error Code(분산 트랜잭션이 이미 시작되었습니다)
        /// </summary>
        #endregion
        public const int ORA_02046 = 2046;

        #region Comments
        /// <summary>
        /// Oracle DB Critical Error Code(%s%s로 부터의 다음의 치명적인 오류가 있습니다)
        /// </summary>
        #endregion
        public const int ORA_02068 = 2068;

        #region Comments
        /// <summary>
        /// Oracle DB Critical Error Code(통신 채널에 EOF 가 있습니다)
        /// </summary>
        #endregion
        public const int ORA_03113 = 3113;

        #region Comments
        /// <summary>
        /// Oracle DB Critical Error Code(ORACLE에 연결되어 있지 않습니다)
        /// </summary>
        #endregion
        public const int ORA_03114 = 3114;
        
        #region Comments
        /// <summary>
        /// Oracle DB Critical Error Code(TNS: 접속 시간 초과가 발생)
        /// </summary>
        #endregion
        public const int ORA_12170 = 12170;

        #region Comments
        /// <summary>
        /// Oracle DB Critical Error Code(TNS:리스너가 전용 서버 프로세스를 시작하는데 실패했습니다.)
        /// </summary>
        #endregion
        public const int ORA_12500 = 12500;

        #region Comments
        /// <summary>
        /// Oracle DB Critical Error Code(TNS:리스너가 아닙니다.)
        /// </summary>
        #endregion
        public const int ORA_12541 = 12541;

        #region Comments
        /// <summary>
        /// Oracle DB Critical Error Code(TNS:연결이 끊어졌습니다.)
        /// </summary>
        #endregion
        public const int ORA_12547 = 12547;

        #region Comments
        /// <summary>
        /// Oracle DB Critical Error Code(TNS:패킷 라이터 실패 )
        /// </summary>
        #endregion
        public const int ORA_12571 = 12571;
        
        #endregion 
       
        //------------------------------------------------------------------------------------------------------------------------

        #region MSSQL DB Error Code Definition
        
        //***
        //MSSQL DB Error Code
        //***
        #region Comments
        /// <summary>
        /// MSSQL DB Error Code( 트랜잭션이 리소스에서 다른 프로세스와의 교착 상태가 발생하여 실행이 중지)
        /// </summary>
        #endregion
        public const int SQL_01205 = 1205;

        #region Comments
        /// <summary>
        /// MSSQL DB Critical Error Code(데이터 베이스가 오프라인 상태로 열수 없습니다.)
        /// </summary>
        #endregion
        public const int SQL_00942 = 0942;

        #region Comments
        /// <summary>
        /// MSSQL DB Critical Error Code(프로시저의 매개변수가 아닙니다.)
        /// </summary>
        #endregion
        public const int SQL_08145 = 8145;
        
        #region Comments
        /// <summary>
        /// MSSQL DB Critical Error Code(내부쿼리 프로세서 오류 : 쿼리 프로세서에서 필요한 인터페이스에 대한 엑세스 권한을 얻을수 없습니다.)
        /// </summary>
        #endregion
        public const int SQL_08601 = 8601;

        #region Comments
        /// <summary>
        /// MSSQL DB Critical Error Code(공급자에서 예기치 않은 치명적인 오류발생)
        /// </summary>
        #endregion
        public const int SQL_10001 = 10001;
        
        #region Comments
        /// <summary>
        /// MSSQL DB Critical Error Code(공급자에서 해당 기능을 구현할 수 없습니다.)
        /// </summary>
        #endregion
        public const int SQL_10002 = 10002;

        #region Comments
        /// <summary>
        /// MSSQL DB Critical Error Code(공급자의 메모리가 부족합니다.)
        /// </summary>
        #endregion
        public const int SQL_10003 = 10003;

        #region Comments
        /// <summary>
        /// MSSQL DB Critical Error Code(공급자가 작업을 종료했습니다.)
        /// </summary>
        #endregion
        public const int SQL_10008 = 10008;

        #region Comments
        /// <summary>
        /// MSSQL DB Critical Error Code(액세스가 거부되었습니다.)
        /// </summary>
        #endregion
        public const int SQL_10011 = 10011;
        
        #region Comments
        /// <summary>
        /// MSSQL DB Critical Error Code( SQL Server 인스턴스가 연결되어 있는 IP 주소를 찾을 수 없습니다.)
        /// </summary>
        #endregion
        public const int SQL_26054 = 26054;

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
    }
}
