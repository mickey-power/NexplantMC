/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOpcEventItemValueTransformer.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.08.09
--  Description     : FAMate Core FaOpcDriver OPC Event Item Value Transformer Class 
--  History         : Created by jungyoul.moon at 2013.08.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public class FOpcEventItemValueTransformer : FValueTransformerBase, FIValueTransformer
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FOpcEventItem m_fOei = null;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FOpcEventItemValueTransformer(            
            FOpcEventItem fOei
            ) 
            : base()
        {
            m_fOei = fOei;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOpcEventItemValueTransformer(
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
                    m_fOei = null;
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
                    return (FFormat)m_fOei.fFormat;
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
                    return new FOpcEventItemValueFormulaCollection(m_fOei.fXmlNode);
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
                val = m_fOei.fXmlNode.get_attrVal(FXmlTagOEI.A_Transformer, FXmlTagOEI.D_Transformer);
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
                m_fOei.fXmlNode.set_attrVal(
                    FXmlTagOEI.A_Transformer,
                    FXmlTagOEI.D_Transformer,
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
