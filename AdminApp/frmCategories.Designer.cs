﻿namespace AdminApp
{
    partial class frmCategories
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
            this.listCategories = new System.Windows.Forms.ListBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listCategories
            // 
            this.listCategories.FormattingEnabled = true;
            this.listCategories.Location = new System.Drawing.Point(12, 12);
            this.listCategories.Name = "listCategories";
            this.listCategories.Size = new System.Drawing.Size(120, 264);
            this.listCategories.TabIndex = 0;
            this.listCategories.SelectedIndexChanged += new System.EventHandler(this.listCategories_DoubleClick);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(183, 327);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // frmCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 362);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.listCategories);
            this.Name = "frmCategories";
            this.Text = "frmCategories";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listCategories;
        private System.Windows.Forms.Button btnQuit;
    }
}