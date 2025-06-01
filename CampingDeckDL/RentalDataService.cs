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
            rentalDataService = new InMemoryDataService();
            //rentalDataService = new JsonFileDataService();
            //rentalDataService = new DBDataService();
        }

        public List<CampingCommon> GetItems()
        {
            return rentalDataService.Load();
        }

        public void SaveItems()
        {
            rentalDataService.Save(rentalDataService.Load());
        }

        public bool BorrowItem(int index, string borrowerName)
        {
            var items = rentalDataService.Load();

            if (index >= 0 && index < items.Count && items[index].Quantity > 0 && string.IsNullOrEmpty(items[index].Borrower))
            {
                items[index].Quantity--;
                items[index].Borrower = borrowerName;
                rentalDataService.Save(items);
                return true;
            }
            return false;
        }

        public bool ReturnItem(int index)
        {
            var items = rentalDataService.Load();

            if (index >= 0 && index < items.Count && !string.IsNullOrEmpty(items[index].Borrower))
            {
                items[index].Quantity++;
                items[index].Borrower = null;
                rentalDataService.Save(items);
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
