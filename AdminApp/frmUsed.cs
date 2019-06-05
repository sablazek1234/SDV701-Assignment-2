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
    public sealed partial class frmUsed : CustomerApp.frmProductDetail
    {
        private static readonly frmUsed Instance = new frmUsed();

        private frmUsed()
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
            txtCondition.Text = _Product.Condition.ToString();
        }

        protected override void pushData()
        {
            base.pushData();
            _Product.Condition = txtCondition.Text;
        }
    }
}
