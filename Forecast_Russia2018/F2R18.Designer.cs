namespace Forecast_Russia2018
{
    partial class F2R18
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbUkupniPlasman = new System.Windows.Forms.TextBox();
            this.tbRezultati = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tbUkupniPlasman
            // 
            this.tbUkupniPlasman.AcceptsTab = true;
            this.tbUkupniPlasman.Font = new System.Drawing.Font("Tw Cen MT", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUkupniPlasman.Location = new System.Drawing.Point(490, 12);
            this.tbUkupniPlasman.Multiline = true;
            this.tbUkupniPlasman.Name = "tbUkupniPlasman";
            this.tbUkupniPlasman.ReadOnly = true;
            this.tbUkupniPlasman.Size = new System.Drawing.Size(339, 569);
            this.tbUkupniPlasman.TabIndex = 1;
            // 
            // tbRezultati
            // 
            this.tbRezultati.AcceptsTab = true;
            this.tbRezultati.Font = new System.Drawing.Font("Tw Cen MT", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRezultati.Location = new System.Drawing.Point(12, 12);
            this.tbRezultati.Name = "tbRezultati";
            this.tbRezultati.ReadOnly = true;
            this.tbRezultati.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.tbRezultati.Size = new System.Drawing.Size(472, 569);
            this.tbRezultati.TabIndex = 2;
            this.tbRezultati.Text = "";
            // 
            // F2R18
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(841, 593);
            this.Controls.Add(this.tbRezultati);
            this.Controls.Add(this.tbUkupniPlasman);
            this.Name = "F2R18";
            this.Text = "F2R18";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbUkupniPlasman;
        private System.Windows.Forms.RichTextBox tbRezultati;
    }
}