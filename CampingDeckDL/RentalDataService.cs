using System;
using RentalCommon;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CampingDeckDL
{
    public class RentalDataService
    {
        IRentalDataService rentalDataService;

        public RentalDataService()
        { 
            //rentalDataService = new TextFileDataService();
            //rentalDataService = new InMemoryDataService();
            //rentalDataService = new JsonFileDataService();
            rentalDataService = new DBDataService();
        }

        public List<CampingCommon> GetAllItems()
        {
            return rentalDataService.GetItems();
        }

        public bool BorrowItem(int itemIndex, string borrowerName)
        {
            var items = rentalDataService.GetItems();

            if (itemIndex >= 0 && itemIndex < items.Count && items[itemIndex].Quantity > 0 && string.IsNullOrEmpty(items[itemIndex].Borrower))
            {
                items[itemIndex].Quantity--;
                items[itemIndex].Borrower = borrowerName;
                rentalDataService.UpdateItem(items[itemIndex]);
                return true;
            }
            return false;
        }

        public bool ReturnItem(int itemIndex)
        {
            var items = rentalDataService.GetItems();

            if (itemIndex >= 0 && itemIndex < items.Count && !string.IsNullOrEmpty(items[itemIndex].Borrower))
            {
                items[itemIndex].Quantity++;
                items[itemIndex].Borrower = null;
                rentalDataService.UpdateItem(items[itemIndex]);
                return true;
            }
            return false;
        }

        public bool ValidateAdminPin(string pin)
        {
            const string AdminPin = "123456";
            return pin == AdminPin;
        }
    }

}
