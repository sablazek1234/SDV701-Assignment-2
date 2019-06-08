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
    public sealed partial class frmNew : AdminApp.frmProductDetail
    {
        private static readonly frmNew Instance = new frmNew();

        private frmNew()
        {
            InitializeComponent();
        }

        public static void Run(clsProduct prProduct)
        {
            Instance.SetDetails(prProduct);
        }

        protected override void updateForm()
        {
            base.updateForm();
            txtWarranty.Text = _Product.Warranty.ToString();
        }

        protected override void pushData()
        {
            base.pushData();
            _Product.Warranty = txtWarranty.Text;
        }
    }
}
