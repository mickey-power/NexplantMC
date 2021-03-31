/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDataValueTransformer.cs
--  Creator         : spike.lee
--  Create Date     : 2011.12.06
--  Description     : FAMate Core FaSecsDriver Data Value Transformer Class 
--  History         : Created by spike.lee at 2011.12.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FDataValueTransformer : FValueTransformerBase, FIValueTransformer
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FData m_fDat = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FDataValueTransformer(            
            FData fDat
            ) 
            : base()
        {
            m_fDat = fDat;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDataValueTransformer(
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
                    m_fDat = null;
                }
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public override FFormat fFormat
        {
            get
            {
                try
                {
                    return m_fDat.fFormat;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIValueFormulaCollection fValueFormulaCollection
        {
            get
            {
                try
                {
                    return new FDataValueFormulaCollection(m_fDat.fXmlNode);
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

        internal override List<string> getValueFormulaList(
            )
        {
            string val = string.Empty;

            try
            {
                val = m_fDat.fXmlNode.get_attrVal(FXmlTagDAT.A_Transformer, FXmlTagDAT.D_Transformer);
                if (val == string.Empty)
                {
                    return new List<string>();
                }
                else
                {
                    return new List<string>(val.Split(FConstants.ValueFormulaSeparator));
                }
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

        internal override void setValueFormulaList(
            List<string> valueFormulaList
            )
        {
            try
            {
                m_fDat.fXmlNode.set_attrVal(
                    FXmlTagDAT.A_Transformer,
                    FXmlTagDAT.D_Transformer,
                    string.Join(FConstants.ValueFormulaSeparator.ToString(), valueFormulaList.ToArray()),
                    true
                    );
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
