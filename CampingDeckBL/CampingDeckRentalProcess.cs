using CampingDeckDL;
using RentalCommon;
using System.Collections.Generic;
using System.Linq;

namespace CampingDeckBL
{
    public class CampingDeckRentalProcess
    {
        RentalDataService rentalDataService = new RentalDataService();


        public List<CampingCommon> GetItems()
        {
            return rentalDataService.GetItems();
        }

        public List<CampingCommon> GetRentedItems()
        {
            return rentalDataService.GetItems().Where(i => !string.IsNullOrEmpty(i.Borrower)).ToList();
        }

        public bool BorrowItem(int itemIndex, string borrower)
        {
            return rentalDataService.BorrowItem(itemIndex, borrower);
        }

        public bool ReturnItem(int itemIndex)
        {
            return rentalDataService.ReturnItem(itemIndex);
        }

        public bool ValidateAdminPin(string pin)
        {
            return rentalDataService.ValidateAdminPin(pin);
        }
        
    }
}