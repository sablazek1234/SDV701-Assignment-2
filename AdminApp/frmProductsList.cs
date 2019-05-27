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
    public partial class frmProductsList : Form
    {
        protected clsProduct _Product = new clsProduct();

        private static readonly frmProductsList _Instance = new frmProductsList();

        private static Dictionary<string, frmProductsList> _ProductsList =
        new Dictionary<string, frmProductsList>();

        //public delegate void LoadWorkFormDelegate(clsProduct prProduct);

        //public static Dictionary<char, Delegate> _ProductsList = new Dictionary<char, Delegate>
        //{
        //    {'N', new LoadWorkFormDelegate(frmNew.Run)},
        //    {'U', new LoadWorkFormDelegate(frmUsed.Run)}
        //};

        public frmProductsList()
        {
            InitializeComponent();
        }

        public static frmProductsList Instance
        {
            get { return _Instance; }
        }

        public static void Run(string prProductName)
        {
            frmProductsList lcProductForm;
            if (string.IsNullOrEmpty(prProductName) ||
            !_ProductsList.TryGetValue(prProductName, out lcProductForm))
            {
                lcProductForm = new frmProductsList();
                if (string.IsNullOrEmpty(prProductName))
                    lcProductForm.SetDetails(new clsProduct());
                else
                {
                    _ProductsList.Add(prProductName, lcProductForm);
                    lcProductForm.refreshFormFromDB(prProductName);
                }
            }
            else
            {
                lcProductForm.Show();
                lcProductForm.Activate();
            }
        }

        private async void refreshFormFromDB(string prProductName)
        {
            SetDetails(await ServiceClient.GetProductAsync(prProductName));
        }

        private void updateTitle(string prInventoryName)
        {
            if (!string.IsNullOrEmpty(prInventoryName))
                Text = "Product Details - " + prInventoryName;
        }

        private async void UpdateDisplay()
        {
            listProducts.DataSource = null;
            listProducts.DataSource = await ServiceClient.GetProductNamesAsync();

            //listProducts.DataSource = null;
            //if (_Product.ProductList != null)
            //    listProducts.DataSource = _Product.ProductList;
        }

        public void SetDetails(clsProduct prProduct)
        {
            _Product = prProduct;
            UpdateDisplay();
            Show();
        }

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            //frmNew.Show();
        }

        private void btnAddUsedProduct_Click(object sender, EventArgs e)
        {
            //frmUsed.Show();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
