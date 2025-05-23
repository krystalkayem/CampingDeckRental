using RentalCommon;

namespace CampingDeckDL
{
    public class RentalDataService
    {
        IRentalDataService rentalDataService;

        public RentalDataService()
        {
            // rentalDataService = new TextFileDataService();
            // rentalDataService = new InMemoryDataService();
            rentalDataService = new JsonFileDataService();
        }

        public List<CampingCommon> GetAllItems()
        {
            return rentalDataService.GetItems();
        }

        public bool RentItem(int itemIndex, string borrower)
        {
            List<CampingCommon> items = rentalDataService.GetItems();
            if (itemIndex >= 0 && itemIndex < items.Count && items[itemIndex].Quantity > 0 && string.IsNullOrEmpty(items[itemIndex].Borrower))
            {
                items[itemIndex].Quantity--;
                items[itemIndex].Borrower = borrower;
                rentalDataService.UpdateItem(items[itemIndex]);
                return true;
            }
            return false;
        }

        public bool ReturnItem(int itemIndex)
        {
            List<CampingCommon> items = rentalDataService.GetItems();
            if (itemIndex >= 0 && itemIndex < items.Count && !string.IsNullOrEmpty(items[itemIndex].Borrower))
            {
                items[itemIndex].Quantity++;
                items[itemIndex].Borrower = null;
                rentalDataService.UpdateItem(items[itemIndex]);
                return true;
            }
            return false;
        }
    }
}
