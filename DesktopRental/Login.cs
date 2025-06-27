using CampingDeckBL;

namespace DesktopRental
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            var pin = textBox1.Text;

            CampingDeckRentalProcess rentalProcess = new CampingDeckRentalProcess();

            bool result = rentalProcess.ValidateAdminPin(pin);

            if (result)
            {
                MessageBox.Show("Successful");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

    }
}
