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
            return rentalDataService.GetAllItems();
        }

        public List<CampingCommon> GetRentedItems()
        {
            var rentedItems = new List<CampingCommon>();
            foreach (var item in rentalDataService.GetAllItems())
            {
                if (!string.IsNullOrEmpty(item.Borrower))
                {
                    rentedItems.Add(item);
                }
            }
            return rentedItems;
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