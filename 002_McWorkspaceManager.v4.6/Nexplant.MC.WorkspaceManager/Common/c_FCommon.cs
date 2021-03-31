/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FCommon.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2014.08.12
--  Description     : FAMate Workspace Manager Common Function Class 
--  History         : Created by jungyoul.moon at 2014.08.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Drawing;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.WorkspaceManager
{
    public static class FCommon
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static void validateName(
            string name,
            bool emptyError,
            FUIWizard fUIWizard,
            params object[] args
            )
        {
            char[] c = { ' ', '\\', '/', '.', ',', '\'', '"', '&', '|', '[', ']', '(', ')', ':', ';', '`', '~', '!', '@', '#', '$', '%', '^', '*', '+', '=', '\n', '\r' };

            try
            {
                if (name == string.Empty && emptyError)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", args));
                }

                if (name.IndexOfAny(c) > -1)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0015", args));
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static bool validateName(
            string name,
            bool emptyError,
            ref string errorMessage,
            FUIWizard fUIWizard,
            params object[] args
            )
        {
            char[] c = { ' ', '\\', '/', '.', ',', '\'', '"', '&', '|', '[', ']', '(', ')', ':', ';', '`', '~', '!', '@', '#', '$', '%', '^', '*', '+', '=', '\n', '\r' };

            try
            {
                errorMessage = string.Empty;

                if (name == string.Empty && emptyError)
                {
                    errorMessage = fUIWizard.generateMessage("E0004", args);
                    return false;
                }

                if (name.IndexOfAny(c) > -1)
                {
                    errorMessage = fUIWizard.generateMessage("E0015", args);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNode(
            string elementName
            )
        {
            FXmlDocument fXmlDoc = null;

            try
            {
                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;
                fXmlDoc.appendChild(fXmlDoc.createNode(elementName));
                // --
                return fXmlDoc.fFirstChild;
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
