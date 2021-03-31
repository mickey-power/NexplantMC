/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOpcItemLogValueTransformer.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.10.31
--  Description     : FAMate Core FaOpcDriver OPC Item Log Value Transformer Class 
--  History         : Created by jungyoul.moon at 2013.10.31
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public class FOpcItemLogValueTransformer : FValueTransformerLogBase, FIValueTransformerLog
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FOpcItemLog m_fOitl = null;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FOpcItemLogValueTransformer(            
            FOpcItemLog fOitl
            ) 
            : base()
        {
            m_fOitl = fOitl;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOpcItemLogValueTransformer(
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
                    m_fOitl = null;
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
                    return (FFormat)m_fOitl.fFormat;
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
                    return new FOpcItemValueFormulaCollection(m_fOitl.fXmlNode);
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
                val = m_fOitl.fXmlNode.get_attrVal(FXmlTagOITL.A_Transformer, FXmlTagOITL.D_Transformer);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
