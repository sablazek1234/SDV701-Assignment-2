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
    public partial class frmMain : Form
    {
        private static readonly frmMain _Instance = new frmMain();

        private clsCategory _CategoryList = new clsCategory();
        private clsOrderDetails _OrderDetailsList = new clsOrderDetails();

        private frmMain()
        {
            InitializeComponent();
        }

        public static frmMain Instance
        {
            get { return frmMain._Instance; }
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            try
            {
                frmCategories.Run(new clsCategory(_CategoryList));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnOrderDetails_Click(object sender, EventArgs e)
        {
            try
            {
                frmOrderDetails.Run(new clsOrderDetails(_OrderDetailsList));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {

        }
    }
}
