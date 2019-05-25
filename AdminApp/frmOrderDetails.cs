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
    public partial class frmOrderDetails : Form
    {
        public frmOrderDetails()
        {
            InitializeComponent();
        }

        private static Dictionary<string, frmOrderDetails> _OrderDetailsList =
        new Dictionary<string, frmOrderDetails>();

        public static void Run(string prOrderDetailsName)
        {
            frmOrderDetails lcOrderDetailsForm;
            if (string.IsNullOrEmpty(prOrderDetailsName) ||
            !_OrderDetailsList.TryGetValue(prOrderDetailsName, out lcOrderDetailsForm))
            {
                lcOrderDetailsForm = new frmOrderDetails();
                if (string.IsNullOrEmpty(prOrderDetailsName))
                    lcOrderDetailsForm.SetDetails(new clsOrderDetails());
                else
                {
                    _OrderDetailsList.Add(prOrderDetailsName, lcOrderDetailsForm);
                    lcOrderDetailsForm.refreshFormFromDB(prOrderDetailsName);
                }
            }
            else
            {
                lcOrderDetailsForm.Show();
                lcOrderDetailsForm.Activate();
            }
        }

        private async void refreshFormFromDB(string prOrderDetailsName)
        {
            //SetDetails(await ServiceClient.GetCategoryAsync(prOrderDetailsName));
        }

        private void updateTitle(string prInventoryName)
        {
            if (!string.IsNullOrEmpty(prInventoryName))
                Text = "Product Details - " + prInventoryName;
        }

        private void UpdateDisplay()
        {
            //listOrderDetails.DataSource = null;
            //if (_OrderDetailsList.OrderDetailsList != null)
            //    listOrderDetails.DataSource = _OrderDetailsList.OrderDetailsList;
        }

        public void SetDetails(clsOrderDetails prOrderDetails)
        {
            //_OrderDetailsList = prOrderDetails;
            //UpdateDisplay();
            //Show();
        }

        private void listOrderDetails_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    frmOrderDetails.DispatchWorkForm(listOrderDetails.SelectedValue as clsProduct);
            //    UpdateDisplay();
            //    frmOrderDetails.Instance.UpdateDisplay();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void frmOrderDetails_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        //????????????????????????????????????????????????????????????
        private void btnCategories_Click(object sender, EventArgs e)
        {
            //frmCategories.Show();
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
