namespace AdminApp
{
    partial class frmOrderList
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
            this.listOrderDetails = new System.Windows.Forms.ListBox();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listOrderDetails
            // 
            this.listOrderDetails.FormattingEnabled = true;
            this.listOrderDetails.Location = new System.Drawing.Point(12, 52);
            this.listOrderDetails.Name = "listOrderDetails";
            this.listOrderDetails.Size = new System.Drawing.Size(855, 251);
            this.listOrderDetails.TabIndex = 0;
            this.listOrderDetails.SelectedIndexChanged += new System.EventHandler(this.listOrderDetails_DoubleClick);
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Location = new System.Drawing.Point(711, 328);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteOrder.TabIndex = 2;
            this.btnDeleteOrder.Text = "Delete Order";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(792, 328);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 3;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // frmOrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 363);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnDeleteOrder);
            this.Controls.Add(this.listOrderDetails);
            this.Name = "frmOrderDetails";
            this.Text = "frmOrderDetails";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listOrderDetails;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Button btnQuit;
    }
}