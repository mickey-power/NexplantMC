/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FValueFormulaCollectionBase.cs
--  Creator         : spike.lee
--  Create Date     : 2011.08.02
--  Description     : FAMate Core FaTcpDriver Value Formula Base Collection Class 
--  History         : Created by spike.lee at 2011.08.02
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public abstract class FValueFormulaCollectionBase : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FValueFormulaCollectionBase(            
            )            
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FValueFormulaCollectionBase(
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

        internal abstract string value
        {
            get;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int count
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = this.value;
                    if (val == string.Empty)
                    {
                        return 0;
                    }

                    // --

                    return val.Split(FConstants.ValueFormulaSeparator).Count();
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIValueFormula this[int i]
        {
            get
            {
                string[] valueFormulaList = null;                

                try
                {
                    valueFormulaList = this.value.Split(FConstants.ValueFormulaSeparator);
                    // --
                    if (i < 0 || i >= valueFormulaList.Length)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                    }

                    // --

                    return FValueFormulaBase.createValueFormula(valueFormulaList[i]);
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
        }
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods        

        public object item(
            int index
            )
        {
            try
            {
                return this[index];
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
