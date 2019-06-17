namespace AdminApp
{
    partial class frmProductsList
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
            this.listProducts = new System.Windows.Forms.ListBox();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.btnAddNewProduct = new System.Windows.Forms.Button();
            this.btnAddUsedProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listProducts
            // 
            this.listProducts.FormattingEnabled = true;
            this.listProducts.Location = new System.Drawing.Point(12, 86);
            this.listProducts.Name = "listProducts";
            this.listProducts.Size = new System.Drawing.Size(950, 251);
            this.listProducts.TabIndex = 0;
            this.listProducts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listProducts_MouseDoubleClick);
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Location = new System.Drawing.Point(12, 9);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(35, 13);
            this.lblCategoryName.TabIndex = 1;
            this.lblCategoryName.Text = "label1";
            // 
            // btnAddNewProduct
            // 
            this.btnAddNewProduct.Location = new System.Drawing.Point(582, 343);
            this.btnAddNewProduct.Name = "btnAddNewProduct";
            this.btnAddNewProduct.Size = new System.Drawing.Size(101, 23);
            this.btnAddNewProduct.TabIndex = 2;
            this.btnAddNewProduct.Text = "Add New Product";
            this.btnAddNewProduct.UseVisualStyleBackColor = true;
            this.btnAddNewProduct.Click += new System.EventHandler(this.btnAddNewProduct_Click);
            // 
            // btnAddUsedProduct
            // 
            this.btnAddUsedProduct.Location = new System.Drawing.Point(689, 343);
            this.btnAddUsedProduct.Name = "btnAddUsedProduct";
            this.btnAddUsedProduct.Size = new System.Drawing.Size(102, 23);
            this.btnAddUsedProduct.TabIndex = 3;
            this.btnAddUsedProduct.Text = "Add Used Product";
            this.btnAddUsedProduct.UseVisualStyleBackColor = true;
            this.btnAddUsedProduct.Click += new System.EventHandler(this.btnAddUsedProduct_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Location = new System.Drawing.Point(797, 343);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(87, 23);
            this.btnDeleteProduct.TabIndex = 4;
            this.btnDeleteProduct.Text = "Delete Product";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(890, 343);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 5;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 31);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(35, 13);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Product Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(635, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Date Modified";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(539, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(430, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(327, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "NewOrUsed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Brand";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Product Type";
            // 
            // frmProductsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 378);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnDeleteProduct);
            this.Controls.Add(this.btnAddUsedProduct);
            this.Controls.Add(this.btnAddNewProduct);
            this.Controls.Add(this.lblCategoryName);
            this.Controls.Add(this.listProducts);
            this.Name = "frmProductsList";
            this.Text = "frmProducts";
            this.Load += new System.EventHandler(this.frmProductsList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listProducts;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.Button btnAddNewProduct;
        private System.Windows.Forms.Button btnAddUsedProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}