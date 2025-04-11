using System;
using RentalCommon;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CampingDeckDL
{
    public class RentalDataLogic
    {
        public List<CampingCommon> items = new List<CampingCommon>();
        public RentalDataLogic()
        {
            CreateDummyCampingItems();
        }

        public void CreateDummyCampingItems()
        {
            items.Add(new CampingCommon("Bike", 10));
            items.Add(new CampingCommon("Tent", 15));
            items.Add(new CampingCommon("Camping Chairs", 30));
            items.Add(new CampingCommon("Camping Tables", 20));
            items.Add(new CampingCommon("Sleeping Bags", 20));
            items.Add(new CampingCommon("Umbrella", 10));
            items.Add(new CampingCommon("Lights", 20));
            items.Add(new CampingCommon("Cooking Utensils", 10));
            items.Add(new CampingCommon("Sleeping Pads", 15));
            items.Add(new CampingCommon("Sunshade", 10));
            items.Add(new CampingCommon("Axe", 10));
            items.Add(new CampingCommon("Pillow", 10));
            items.Add(new CampingCommon("Blankets", 10));
        }

        public List<CampingCommon> GetItems()
        {
            return items;
        }

        public bool BorrowItem(int index, string borrowName)
        {
            if (index >= 0 && index < items.Count && items[index].Quantity > 0 && string.IsNullOrEmpty(items[index].Borrower))
            {
                items[index].Quantity--;
                items[index].Borrower = borrowName;
                return true;
            }
            return false;
        }

        public bool ReturnItem(int index)
        {
            if (index >= 0 && index < items.Count && !string.IsNullOrEmpty(items[index].Borrower))
            {
                items[index].Quantity++;
                items[index].Borrower = null;
                return true;
            }
            return false;
        }

        public bool ValidateAdminPin(string pin)
        {
            string userPin = "123456";
            return pin == userPin;
        }
    }

}
