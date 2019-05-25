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
    public sealed partial class frmCategories : Form
    {
        private clsCategory _Category = new clsCategory();

        private static Dictionary<clsCategory, frmCategories> _CategoryList =
        new Dictionary<clsCategory, frmCategories>();

        private frmCategories()
        {
            InitializeComponent();
        }

        public static void Run(clsCategory prCategoryName)
        {
            frmCategories lcCategoryForm;
            if (!_CategoryList.TryGetValue(prCategoryName, out lcCategoryForm))
            {
                lcCategoryForm = new frmCategories();
                _CategoryList.Add(prCategoryName, lcCategoryForm);
                lcCategoryForm.SetDetails(prCategoryName);
            }
            else
            {
                lcCategoryForm.Show();
                lcCategoryForm.Activate();
            }
        }

        private async void refreshFormFromDB(string prCategoryName)
        {
            SetDetails(await ServiceClient.GetCategoryAsync(prCategoryName));
        }

        private void updateTitle(string prInventoryName)
        {
            if (!string.IsNullOrEmpty(prInventoryName))
                Text = "Product Details - " + prInventoryName;
        }

        public void UpdateDisplay()
        {
            listCategories.DataSource = null;
            clsCategory[] lcDisplayList = new clsCategory[_CategoryList.Count];
            _CategoryList.Keys.CopyTo(lcDisplayList, 0);
            listCategories.DataSource = lcDisplayList;
        }

        public void SetDetails(clsCategory prCategory)
        {
            _Category = prCategory;
            UpdateDisplay();
            Show();
        }

        private void listCategories_DoubleClick(object sender, EventArgs e)
        {
            //string lcKey;

            //lcKey = Convert.ToString(listCategories.SelectedItem);
            //if (lcKey != null)
            //    try
            //    {
            //        frmProducts.Run(_CategoryList[lcKey]);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "This should never occur");
            //    }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCategories_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }
    }
}
