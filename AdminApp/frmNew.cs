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
    public sealed partial class frmNew : AdminApp.frmProductsList
    {
        private static readonly frmNew Instance = new frmNew();

        private frmNew()
        {
            InitializeComponent();
        }

        public static void Run(clsProduct prNewProduct)
        {
            Instance.SetDetails(prNewProduct);
        }

        //protected override void updateForm()
        //{
        //    clsProduct lcProduct = _Product;
        //    txtCategory.Text = lcProduct.Category.ToString();
        //    txtProductName.Text = lcProduct.ProductName.ToString();
        //    txtProductType.Text = lcProduct.ProductType.ToString();
        //    txtBrand.Text = lcProduct.Brand.ToString();
        //    txtWarranty.Text = lcProduct.Warranty.ToString();
        //    txtPrice.Text = lcProduct.Price.ToString();
        //    txtQuantity.Text = lcProduct.Quantity.ToString();       
        //}

        //protected override void pushData()
        //{
        //    clsProduct lcProduct = _Product;
        //    lcProduct.Category = txtCategory.Text;
        //    lcProduct.ProductName = txtProductName.Text;
        //    lcProduct.ProductType = txtProductType.Text;
        //    lcProduct.Brand = txtBrand.Text;
        //    lcProduct.Warranty = txtWarranty.Text;
        //    lcProduct.Price = decimal.Parse(txtPrice.Text);
        //    lcProduct.Quantity = int.Parse(txtQuantity.Text);
        //}
    }
}
