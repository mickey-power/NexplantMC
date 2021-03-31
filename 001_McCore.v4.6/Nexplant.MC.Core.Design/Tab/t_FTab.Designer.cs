namespace Nexplant.MC.Core.FaUIs
{
    partial class FTab
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            // ***
            // myDispose
            // ***
            myDispose(disposing);

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // --

            this.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.Appearance.ForeColor = System.Drawing.Color.Silver;
            // -- 
            this.ActiveTabAppearance.ForeColor = System.Drawing.Color.Black;
            // --
            this.ClientAreaAppearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientAreaAppearance.BackColor2 = System.Drawing.Color.WhiteSmoke;
            this.ClientAreaAppearance.BorderColor = System.Drawing.Color.Silver;
            // --
            this.SelectedTabAppearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.SelectedTabAppearance.BackColor2 = System.Drawing.Color.Lavender;
            this.SelectedTabAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            // --
            this.ScrollButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button;
            this.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon;
            this.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
        }

        #endregion
    }
}
