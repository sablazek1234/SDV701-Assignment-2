namespace CustomerApp
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
            this.SuspendLayout();
            // 
            // listProducts
            // 
            this.listProducts.FormattingEnabled = true;
            this.listProducts.Location = new System.Drawing.Point(12, 67);
            this.listProducts.Name = "listProducts";
            this.listProducts.Size = new System.Drawing.Size(855, 251);
            this.listProducts.TabIndex = 0;
            this.listProducts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listProducts_MouseDoubleClick);
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Location = new System.Drawing.Point(13, 23);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(35, 13);
            this.lblCategoryName.TabIndex = 1;
            this.lblCategoryName.Text = "label1";
            // 
            // btnAddNewProduct
            // 
            this.btnAddNewProduct.Location = new System.Drawing.Point(486, 329);
            this.btnAddNewProduct.Name = "btnAddNewProduct";
            this.btnAddNewProduct.Size = new System.Drawing.Size(101, 23);
            this.btnAddNewProduct.TabIndex = 2;
            this.btnAddNewProduct.Text = "Add New Product";
            this.btnAddNewProduct.UseVisualStyleBackColor = true;
            this.btnAddNewProduct.Click += new System.EventHandler(this.btnAddNewProduct_Click);
            // 
            // btnAddUsedProduct
            // 
            this.btnAddUsedProduct.Location = new System.Drawing.Point(593, 329);
            this.btnAddUsedProduct.Name = "btnAddUsedProduct";
            this.btnAddUsedProduct.Size = new System.Drawing.Size(102, 23);
            this.btnAddUsedProduct.TabIndex = 3;
            this.btnAddUsedProduct.Text = "Add Used Product";
            this.btnAddUsedProduct.UseVisualStyleBackColor = true;
            this.btnAddUsedProduct.Click += new System.EventHandler(this.btnAddUsedProduct_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Location = new System.Drawing.Point(701, 329);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(87, 23);
            this.btnDeleteProduct.TabIndex = 4;
            this.btnDeleteProduct.Text = "Delete Product";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(794, 329);
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
            this.lblDescription.Location = new System.Drawing.Point(12, 51);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(35, 13);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "label1";
            // 
            // frmProductsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 364);
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
    }
}