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
    public sealed partial class frmUsed : AdminApp.frmProductsList
    {
        private static readonly frmUsed Instance = new frmUsed();

        public frmUsed()
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
        //    txtCategory2.Text = lcProduct.Category.ToString();
        //    txtProductName2.Text = lcProduct.ProductName.ToString();
        //    txtProductType2.Text = lcProduct.ProductType.ToString();
        //    txtBrand2.Text = lcProduct.Brand.ToString();
        //    txtCondition.Text = lcProduct.Condition.ToString();
        //    txtPrice2.Text = lcProduct.Price.ToString();
        //    txtQuantity2.Text = lcProduct.Quantity.ToString();
        //}

        //protected override void pushData()
        //{
        //    clsProduct lcProduct = _Product;
        //    lcProduct.Category = txtCategory2.Text;
        //    lcProduct.ProductName = txtProductName2.Text;
        //    lcProduct.ProductType = txtProductType2.Text;
        //    lcProduct.Brand = txtBrand2.Text;
        //    lcProduct.Condition = txtCondition.Text;
        //    lcProduct.Price = decimal.Parse(txtPrice2.Text);
        //    lcProduct.Quantity = int.Parse(txtQuantity2.Text);
        //}
    }
}
