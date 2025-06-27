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
    public partial class Rent: Form
    {
        public Rent()
        {
            InitializeComponent();
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text.Trim(), out int itemId))
            {
                MessageBox.Show("Please enter a valid item ID.");
                return;
            }
            string borrowerName = textBox2.Text.Trim();

            CampingDeckRentalProcess rentalProcess = new CampingDeckRentalProcess();
            bool result = rentalProcess.BorrowItem(itemId, borrowerName);

            if (result)
            {
                MessageBox.Show("Item rented successfully!");
            }
            else
            {
                MessageBox.Show("Item not available or already rented.");
            }
        }
    }
}
