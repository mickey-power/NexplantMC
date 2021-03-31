/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMessageBox.cs
--  Creator         : spike.lee
--  Create Date     : 2010.11.25
--  Description     : FAMate Core FaCommon Message Box Class
--  History         : Created by spike.lee at 2010.11.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nexplant.MC.Core.FaCommon
{
    public static class FMessageBox
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        static FMessageBox(
            )
        {

        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static void showError(
            string caption,
            string message,
            IWin32Window owner
            )
        {
            try
            {
                if (owner == null)
                {
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(owner, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static void showError(
            string caption,
            Exception exception,
            IWin32Window owner
            )
        {
            try
            {
                FDebug.writeLog(exception);
                
                if (owner == null)
                {
                    MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(owner, exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static DialogResult showQuestion(
            string caption,
            string message,
            MessageBoxButtons buttons,
            MessageBoxDefaultButton defaultButton,
            IWin32Window owner
            )
        {
            try
            {
                if (owner == null)
                {
                    return MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question, defaultButton);
                }
                else
                {
                    return MessageBox.Show(owner, message, caption, buttons, MessageBoxIcon.Question, defaultButton);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return DialogResult.None;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void showInformation(
            string caption,
            string message,
            IWin32Window owner
            )
        {
            try
            {
                if (owner == null)
                {
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(owner, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
