﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp
{
    public partial class frmProductDetail : AdminApp.frmProductsList
    {
        private static readonly frmProductDetail Instance = new frmProductDetail();

        public frmProductDetail()
        {
            InitializeComponent();
        }

        public static void Run(clsProduct prProductDetail)
        {
            Instance.SetDetails(prProductDetail);
        }

        protected virtual void updateForm()
        {
            txtProductName.Text = _Product.ProductName.ToString();
            txtProductType.Text = _Product.ProductType.ToString();
            txtBrand.Text = _Product.Brand.ToString();
            txtNewOrUsed.Text = _Product.NewOrUsed.ToString();
            txtWarranty.Text = _Product.Warranty.ToString();
            txtPrice.Text = _Product.Price.ToString();
            txtQuantity.Text = _Product.Quantity.ToString();
            txtDateModified.Text = _Product.DateModified.ToString();
        }

        protected virtual void pushData()
        {
            _Product.ProductName = txtProductName.Text;
            _Product.ProductType = txtProductType.Text;
            _Product.Brand = txtBrand.Text;
            _Product.NewOrUsed = txtNewOrUsed.Text;
            _Product.Warranty = txtWarranty.Text;
            _Product.Price = Decimal.Parse(txtPrice.Text);
            _Product.Quantity = int.Parse(txtQuantity.Text);
            _Product.DateModified = DateTime.Parse(txtDateModified.Text);
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();
                if (txtProductName.Enabled)
                    MessageBox.Show(await ServiceClient.InsertProductAsync(_Product));
                else
                    MessageBox.Show(await ServiceClient.UpdateProductAsync(_Product));

                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual bool isValid()
        {
            return true;
        }
    }
}