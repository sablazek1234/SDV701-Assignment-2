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

        private static Dictionary<string, frmOrderList> _OrdersList =
        new Dictionary<string, frmOrderList>();

        private static readonly frmOrderDetails Instance = new frmOrderDetails();       

        protected clsOrderDetails _Orders;

        public static void DispatchWorkForm(clsOrderDetails prOrders)
        {
           // _OrdersList[Convert.ToString(prOrders.ProductID)].DynamicInvoke(prOrders);
        }

        public static void Run(clsOrderDetails prOrders)
        {
            Instance.SetDetails(prOrders);
        }

        public void SetDetails(clsOrderDetails prOrders)
        {
            _Orders = prOrders;
            updateForm();
            ShowDialog();
        }

        protected virtual void updateForm()
        {
            _Orders.DateOfPurchase = DateTime.Today;
            txtCustomerName.Text = _Orders.CustomerName;
            txtCustomerPhone.Text = _Orders.CustomerPhone;
            txtDateOfPurchase.Text = _Orders.DateOfPurchase.ToString();
            txtPrice.Text = _Orders.Price.ToString();
            txtQuantity.Text = _Orders.Quantity.ToString();            
            Text = "Editing Product #" + _Orders.OrderID;
        }

        protected virtual void pushData()
        {
            _Orders.CustomerName = txtCustomerName.Text;
            _Orders.CustomerPhone = txtCustomerPhone.Text;
            _Orders.DateOfPurchase = DateTime.Parse(txtDateOfPurchase.Text);
            _Orders.Price = Decimal.Parse(txtPrice.Text);
            _Orders.Quantity = int.Parse(txtQuantity.Text);
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                _Orders.DateOfPurchase = DateTime.Today;
                pushData();
                MessageBox.Show(await ServiceClient.UpdateOrderAsync(_Orders));

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
