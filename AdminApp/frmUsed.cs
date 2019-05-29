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
    public sealed partial class frmUsed : AdminApp.frmProductDetail
    {
        private static readonly frmUsed Instance = new frmUsed();

        private frmUsed()
        {
            InitializeComponent();
        }

        public static void Run(clsProduct prNewProduct)
        {
    //        Instance.SetDetails(prNewProduct);
        }

        protected override void updateForm()
        {
            txtProductName.Text = _Product.ProductName.ToString();
            txtProductType.Text = _Product.ProductType.ToString();
            txtBrand.Text = _Product.Brand.ToString();
            txtCondition.Text = _Product.Condition.ToString();
            txtPrice.Text = _Product.Price.ToString();
            txtQuantity.Text = _Product.Quantity.ToString();
        }

        protected override void pushData()
        {
            _Product.ProductName = txtProductName.Text;
            _Product.ProductType = txtProductType.Text;
            _Product.Brand = txtBrand.Text;
            _Product.Condition = txtCondition.Text;
            _Product.Price = decimal.Parse(txtPrice.Text);
            _Product.Quantity = int.Parse(txtQuantity.Text);
        }
    }
}
