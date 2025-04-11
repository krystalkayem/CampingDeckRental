using CampingDeckDL;
using RentalCommon;
using System.Collections.Generic;
using System.Linq;

namespace CampingDeckBL
{
    public class CampingDeckRentalProcess
    {
        RentalDataLogic rentalDataLogic = new RentalDataLogic();


        public List<CampingCommon> GetItems()
        {
            return rentalDataLogic.GetItems();
        }

        public List<CampingCommon> GetRentedItems()
        {
            return rentalDataLogic.GetItems().Where(i => !string.IsNullOrEmpty(i.Borrower)).ToList();
        }

        public bool BorrowItem(int itemIndex, string borrower)
        {
            return rentalDataLogic.BorrowItem(itemIndex, borrower);
        }

        public bool ReturnItem(int itemIndex)
        {
            return rentalDataLogic.ReturnItem(itemIndex);
        }

        public bool ValidateAdminPin(string pin)
        {
            return rentalDataLogic.ValidateAdminPin(pin);
        }
        
    }
}