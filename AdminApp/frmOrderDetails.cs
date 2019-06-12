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

        private static readonly frmOrderDetails Instance = new frmOrderDetails();       

        protected clsOrderDetails _Orders;

        //public static void DispatchWorkForm(clsOrderDetails prOrders)
        //{
        //    _ProductsList[Convert.ToChar(prOrders.)].DynamicInvoke(prOrders);
        //}

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
            txtProductName.Text = _Orders.CustomerName;
            txtProductType.Text = _Orders.CustomerPhone;
            txtDateModified.Text = _Orders.DateOfPurchase.ToString();
            txtPrice.Text = _Orders.Price.ToString();
            txtQuantity.Text = _Orders.Quantity.ToString();
            
            Text = "Editing Product #" + _Orders.OrderID;
        }

        protected virtual void pushData()
        {
            _Orders.CustomerName = txtProductName.Text;
            _Orders.CustomerPhone = txtProductType.Text;
            _Orders.DateOfPurchase = DateTime.Parse(txtDateModified.Text);
            _Orders.Price = Decimal.Parse(txtPrice.Text);
            _Orders.Quantity = int.Parse(txtQuantity.Text);
        }
    }
}
