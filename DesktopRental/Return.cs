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
    public partial class Return: Form
    {
        public Return()
        {
            InitializeComponent();
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text.Trim(), out int itemId))
            {
                MessageBox.Show("Please enter a valid item ID number.");
                return;
            }

            CampingDeckRentalProcess rentalProcess = new CampingDeckRentalProcess();
            bool result = rentalProcess.ReturnItem(itemId);

            if (result)
            {
                MessageBox.Show("Item returned successfully!");
            }
            else
            {
                MessageBox.Show("Could not return item. It may not be borrowed yet.");
            }
        }
    }
}
