﻿namespace Forecast_Russia2018
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
            this.tbRezultati = new System.Windows.Forms.TextBox();
            this.tbUkupniPlasman = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbRezultati
            // 
            this.tbRezultati.AcceptsTab = true;
            this.tbRezultati.AllowDrop = true;
            this.tbRezultati.Location = new System.Drawing.Point(16, 12);
            this.tbRezultati.Multiline = true;
            this.tbRezultati.Name = "tbRezultati";
            this.tbRezultati.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRezultati.Size = new System.Drawing.Size(338, 569);
            this.tbRezultati.TabIndex = 0;
            // 
            // tbUkupniPlasman
            // 
            this.tbUkupniPlasman.Location = new System.Drawing.Point(363, 12);
            this.tbUkupniPlasman.Multiline = true;
            this.tbUkupniPlasman.Name = "tbUkupniPlasman";
            this.tbUkupniPlasman.Size = new System.Drawing.Size(339, 569);
            this.tbUkupniPlasman.TabIndex = 1;
            // 
            // F2R18
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(720, 593);
            this.Controls.Add(this.tbUkupniPlasman);
            this.Controls.Add(this.tbRezultati);
            this.Name = "F2R18";
            this.Text = "F2R18";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbRezultati;
        private System.Windows.Forms.TextBox tbUkupniPlasman;
    }
}