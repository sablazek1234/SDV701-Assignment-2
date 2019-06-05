using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerApp
{
    public partial class frmProductsList : Form
    {
        protected clsCategory _Category;

        private static readonly frmProductsList _Instance = new frmProductsList();

        //private static Dictionary<string, frmProductsList> _ProductsList =
        //new Dictionary<string, frmProductsList>();

        public delegate void LoadWorkFormDelegate(clsProduct prProduct);

        public static Dictionary<char, Delegate> _ProductsList = new Dictionary<char, Delegate>
        {
            {'N', new LoadWorkFormDelegate(frmNew.Run)},
            {'U', new LoadWorkFormDelegate(frmUsed.Run)}
        };

        public frmProductsList()
        {
            InitializeComponent();
        }

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

        //??????????????????????????????????????????????????????????????
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

            lblCategoryName.Text = _Category.Category;
            lblDescription.Text = _Category.Description;
            listProducts.DataSource = null;
            listProducts.DataSource = _Category.ProductList;

            //listProducts.DataSource = null;
            //if (_Product.ProductList != null)
            //    listProducts.DataSource = _Product.ProductList;
        }

        //????????????????????????????????????????????????????
        //public void SetDetails(clsCategory prCategory)
        //{
        //    _Category = prCategory;
        //    UpdateDisplay();
        //    Show();
        //}

        private void listProducts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                frmProductDetail.DispatchWorkForm(listProducts.SelectedValue as clsProduct);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "This should never occur");
            }
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
            MessageBox.Show(await ServiceClient.DeleteProductAsync(listProducts.SelectedItem as clsProduct));
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
