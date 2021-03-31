/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FValueTransformerLogBase.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2011.10.19
--  Description     : FAMate Core FaSecsDriver Value Transformer Log Base Class 
--  History         : Created by byungyun.jeon at 2011.10.19
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public abstract class FValueTransformerLogBase : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FValueTransformerLogBase(                    
            )            
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FValueTransformerLogBase(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    
                }                

                m_disposed = true;                
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region IDisposable 멤버

        public void Dispose(
            )
        {
            myDispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public abstract FFormat fFormat
        {
            get;            
        }
              
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        internal abstract List<string> getValueFormulaList(
            );

        //------------------------------------------------------------------------------------------------------------------------
        
        public override string ToString(
            )
        {
            List<string> valueFormulaList = null;
            StringBuilder info = null;

            try
            {
                valueFormulaList = getValueFormulaList();                

                // --

                info = new StringBuilder();
                foreach (string valueFormula in valueFormulaList)
                {
                    info.Append(FValueFormulaBase.createValueFormula(valueFormula).ToString());
                    info.Append(";");
                }

                // --

                return info.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueFormulaList = null;
                info = null;
            }
            return string.Empty;
        }        
                
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
