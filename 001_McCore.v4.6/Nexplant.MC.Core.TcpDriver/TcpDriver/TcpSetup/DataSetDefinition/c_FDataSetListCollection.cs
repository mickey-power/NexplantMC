/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDataSetListCollection.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.08.26
--  Description     : FAMate Core FaTcpDriver Data Set List Collection Class
--  History         : Created by jungyoul.moon at 2013.08.26
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public class FDataSetListCollection : FBaseObjectCollection<FDataSetListCollection, FDataSetList>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FDataSetListCollection(
            FTcdCore fTcdCore,
            FXmlNodeList fXmlNodeList
            )
            : base(fTcdCore, fXmlNodeList)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDataSetListCollection(
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

                }
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region properties

        public override FDataSetList this[int i]
        {
            get
            {
                FXmlNode fXmlNode = null;
                try
                {
                    fXmlNode = fXmlNodeList[i];
                    if (fXmlNode == null)
                    {
                        return null;
                    }
                    return new FDataSetList(fTcdCore, fXmlNode);
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

        public override System.Collections.IEnumerator GetEnumerator(
            )
        {
            try
            {
                return new FDataSetListCollectionEnumerator(this);
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
