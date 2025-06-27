using CampingDeckBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopRental
{
    public partial class Menu: Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void btnRentItem_Click(object sender, EventArgs e)
        {
            var rentForm = new Rent();
            rentForm.ShowDialog();
        }

        private void btnReturnItem_Click(object sender, EventArgs e)
        {
            var returnForm = new Return();
            returnForm.ShowDialog();
        }

        private void btnViewAllItems_Click(object sender, EventArgs e)
        {
            var viewForm = new ViewItems();
            viewForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
