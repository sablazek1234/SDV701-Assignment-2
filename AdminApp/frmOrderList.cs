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
    public partial class frmOrderList : Form
    {
        public frmOrderList()
        {
            InitializeComponent();
        }

        // protected clsCategory _Category;

        private List<clsOrderDetails> _OrderList;

        private static readonly frmOrderList _Instance = new frmOrderList();

        //private static Dictionary<string, frmOrderList> _OrdersList =
        //new Dictionary<string, frmOrderList>();

        public static frmOrderList Instance
        {
            get { return _Instance; }
        }

        //public static void Run(string prOrder)
        //{
        //    frmOrderList lcOrderForm;
        //    if (string.IsNullOrEmpty(prOrder) ||
        //    !_OrdersList.TryGetValue(prOrder, out lcOrderForm))
        //    {
        //        lcOrderForm = new frmOrderList();
        //        if (string.IsNullOrEmpty(prOrder))
        //            lcOrderForm.SetDetails(new clsCategory());
        //        else
        //        {
        //            _OrdersList.Add(prOrder, lcOrderForm);
        //            lcOrderForm.refreshFormFromDB(prOrder);
        //        }
        //    }
        //    else
        //    {
        //        lcOrderForm.Show();
        //        lcOrderForm.Activate();
        //    }
        //}

        //public async void ShowDialog(string prCategoryName)
        //{
        //    _Category = await ServiceClient.GetCategoryAsync(prCategoryName);
        //    UpdateDisplay();
        //    ShowDialog();
        //}

        public async void refreshFormFromDB()
        {
            _OrderList = await ServiceClient.GetOrdersAsync();
            UpdateDisplay();
        }

        //private void updateTitle(string prInventoryName)
        //{
        //    if (!string.IsNullOrEmpty(prInventoryName))
        //        Text = "Product Details - " + prInventoryName;
        //}

        private void UpdateDisplay()
        {
            listOrderDetails.DataSource = null;
            listOrderDetails.DataSource = _OrderList;
        }

        //public void SetDetails(clsCategory prCategory)
        //{
        //    _Category = prCategory;
        //    UpdateDisplay();
        //    //  Show();
        //}

        private void listOrderDetails_DoubleClick(object sender, EventArgs e)
        {
            try
            {
              ///  frmOrderDetails.DispatchWorkForm(listOrderDetails.SelectedValue as clsOrderDetails);
               // refreshFormFromDB();
                //UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "This should never occur");
            }
        }

        private async void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show(await ServiceClient.DeleteOrderAsync(listOrderDetails.SelectedItem as clsOrderDetails));
            refreshFormFromDB();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmOrderList_Load(object sender, EventArgs e)
        {
            refreshFormFromDB();
        }
    }
}
