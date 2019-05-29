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
        protected clsCategory _Category;

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

        //public static void DispatchWorkForm(clsProduct prProduct)
        //{
        //    _ProductsList[prProduct.ProductName].DynamicInvoke(prProduct);
        //}

        public static frmProductsList Instance
        {
            get { return _Instance; }
        }

        //public static void Run(string prProductName)
        //{
        //    frmProductsList lcProductForm;
        //    if (string.IsNullOrEmpty(prProductName) ||
        //    !_ProductsList.TryGetValue(prProductName, out lcProductForm))
        //    {
        //        lcProductForm = new frmProductsList();
        //        if (string.IsNullOrEmpty(prProductName))
        //            lcProductForm.SetDetails(new clsProduct());
        //        else
        //        {
        //            _ProductsList.Add(prProductName, lcProductForm);
        //            //lcProductForm.refreshFormFromDB(prProductName);
        //        }
        //    }
        //    else
        //    {
        //        lcProductForm.Show();
        //        lcProductForm.Activate();
        //    }
        //}


        public async void ShowDialog(string prCategoryName)
        {
            _Category = await ServiceClient.GetCategoryAsync(prCategoryName);
            UpdateDisplay();
            ShowDialog();
        }

        //public async void refreshFormFromDB(string prCategoryName)
        //{
        //    clsCategory lcCategory = await ServiceClient.GetCategoryAsync(prCategoryName);
        //    SetDetails(lcCategory);
        //}

        //private void updateTitle(string prInventoryName)
        //{
        //    if (!string.IsNullOrEmpty(prInventoryName))
        //        Text = "Product Details - " + prInventoryName;
        //}

        private void UpdateDisplay()
        {

            lblCategoryName.Text = _Category.Category + "  " + _Category.Description;
            listProducts.DataSource = null;
            listProducts.DataSource = _Category.ProductList;

            //listProducts.DataSource = null;
            //if (_Product.ProductList != null)
            //    listProducts.DataSource = _Product.ProductList;
        }

        //public void SetDetails(clsCategory prCategory)
        //{
        //    _Category = prCategory;
        //    UpdateDisplay();
        //    Show();
        //}

        private void listProducts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //try
            //{
            //    frmProductDetail.Run(listProducts.SelectedItem as string);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "This should never occur");
            //}
        }

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            try
            {
                frmNew.Run(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "This should never occur");
            }
        }

        private void btnAddUsedProduct_Click(object sender, EventArgs e)
        {
            try
            {
                frmUsed.Run(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "This should never occur");
            }
        }

        private async void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            //string lcKey;

            //lcKey = Convert.ToString(listProducts.SelectedItem);
            //if (lcKey != null && MessageBox.Show("Are you sure?", "Deleting Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    try
            //    {
            //        MessageBox.Show(await ServiceClient.DeleteProductAsync(lcKey));
            //        listProducts.ClearSelected();
            //        UpdateDisplay();

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Error deleting product");
            //    }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmProductsList_Load(object sender, EventArgs e)
        {
            //     SetDetails();
        }

        
    }
}
