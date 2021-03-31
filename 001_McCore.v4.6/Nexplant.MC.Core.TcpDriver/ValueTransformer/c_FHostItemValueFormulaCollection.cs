/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHostItemValueFormulaCollection.cs
--  Creator         : Kimsh
--  Create Date     : 2011.03.07
--  Description     : FAMate Core FaTcpDriver Host Item Value Formula Collection Class 
--  History         : Created by Kimsh at 2011.03.07
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public class FHostItemValueFormulaCollection : FValueFormulaCollectionBase, FIValueFormulaCollection
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FXmlNode m_fXmlNodeHit = null; 

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FHostItemValueFormulaCollection(
            FXmlNode fXmlNodeHit
            )
        {
            m_fXmlNodeHit = fXmlNodeHit;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHostItemValueFormulaCollection(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_fXmlNodeHit = null;
                }

                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        internal override string value
        {
            get
            {
                try
                {
                    return m_fXmlNodeHit.get_attrVal(FXmlTagHIT.A_Transformer, FXmlTagHIT.D_Transformer);
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
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public IEnumerator GetEnumerator(
            )
        {
            try
            {
                return new FHostItemValueFormulaCollectionEnumerator(this);
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
