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

        private static readonly frmCategories _Instance = new frmCategories();

        private static Dictionary<string, frmCategories> _CategoryList =
        new Dictionary<string, frmCategories>();

        private frmCategories()
        {
            InitializeComponent();
        }

        public static frmCategories Instance
        {
            get { return _Instance; }
        }

        public static void Run(string prCategoryName)
        {
            frmCategories lcCategoryForm;
            if (string.IsNullOrEmpty(prCategoryName) ||
            !_CategoryList.TryGetValue(prCategoryName, out lcCategoryForm))
            {
                lcCategoryForm = new frmCategories();
                if (string.IsNullOrEmpty(prCategoryName))
                    lcCategoryForm.SetDetails(new clsCategory());
                else
                {
                    _CategoryList.Add(prCategoryName, lcCategoryForm);
                    lcCategoryForm.refreshFormFromDB(prCategoryName);
                }
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
                Text = "Category Details - " + prInventoryName;
        }

        public async void UpdateDisplay()
        {
            listCategories.DataSource = null;
            listCategories.DataSource = await ServiceClient.GetCategoryNamesAsync();
            //clsCategory[] lcDisplayList = new clsCategory[_CategoryList.Count];
            //_CategoryList.Keys.CopyTo(lcDisplayList, 0);
            //listCategories.DataSource = lcDisplayList;
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
            try
            {
                frmProductsList.Run(listCategories.SelectedItem as string);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "This should never occur");
            }
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
