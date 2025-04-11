using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCommon
{
    public class CampingCommon
    {
        private string _userPin;

        public string UserPin
        {
            get { return _userPin; }
            set
            {
                if (value.Length == 4 || value.Length == 6)
                {
                    _userPin = value;
                }
            }
        }

        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Borrower { get; set; }
        public CampingCommon(string name, int quantity, string pin = "123456")
        {
            Name = name;
            Quantity = quantity;
            UserPin = pin;
            Borrower = null;
        }
    }
}
