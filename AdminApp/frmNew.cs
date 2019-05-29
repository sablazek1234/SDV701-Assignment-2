using System;
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
    public sealed partial class frmNew : AdminApp.frmProductDetail
    {
        private static readonly frmNew Instance = new frmNew();

        private frmNew()
        {
            InitializeComponent();
        }

        protected override void updateForm()
        {
            txtProductName.Text = _Category.ProductName.ToString();
            txtProductType.Text = _Category.ProductType.ToString();
            txtBrand.Text = _Category.Brand.ToString();
            txtWarranty.Text = _Category.Warranty.ToString();
            txtPrice.Text = _Category.Price.ToString();
            txtQuantity.Text = _Category.Quantity.ToString();
        }

        protected override void pushData()
        {
            _Category.ProductName = txtProductName.Text;
            _Category.ProductType = txtProductType.Text;
            _Category.Brand = txtBrand.Text;
            _Category.Warranty = txtWarranty.Text;
            _Category.Price = decimal.Parse(txtPrice.Text);
            _Category.Quantity = int.Parse(txtQuantity.Text);
        }
    }
}
