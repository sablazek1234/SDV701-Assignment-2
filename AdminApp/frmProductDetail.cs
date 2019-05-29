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
    public partial class frmProductDetail : Form
    {
        private static readonly frmProductDetail Instance = new frmProductDetail();

        protected clsCategory _Category;

        public frmProductDetail()
        {
            InitializeComponent();
        }

        protected virtual void updateForm()
        {
            txtProductName.Text = _Category.ProductName.ToString();
            txtProductType.Text = _Category.ProductType.ToString();
            txtBrand.Text = _Category.Brand.ToString();
            txtPrice.Text = _Category.Price.ToString();
            txtQuantity.Text = _Category.Quantity.ToString();
            txtDateModified.Text = _Category.DateModified.ToString();
        }

        protected virtual void pushData()
        {
            _Category.ProductName = txtProductName.Text;
            _Category.ProductType = txtProductType.Text;
            _Category.Brand = txtBrand.Text;
            _Category.Price = Decimal.Parse(txtPrice.Text);
            _Category.Quantity = int.Parse(txtQuantity.Text);
            _Category.DateModified = DateTime.Parse(txtDateModified.Text);
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();
                if (txtProductName.Enabled)
                    MessageBox.Show(await ServiceClient.InsertProductAsync(_Category));
                else
                    MessageBox.Show(await ServiceClient.UpdateProductAsync(_Category));

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
