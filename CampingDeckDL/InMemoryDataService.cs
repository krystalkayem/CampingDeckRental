using System;
using RentalCommon;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampingDeckDL
{
    public class InMemoryDataService : IRentalDataService 
    {
        List<CampingCommon> items = new List<CampingCommon>();
        
        public InMemoryDataService()
        {
            CreateDummyCampingItems();
        }
         
        private void CreateDummyCampingItems()
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

        public List <CampingCommon> GetItems()
        {
            return items;
        }

        public void UpdateItem(CampingCommon item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ItemName == item.ItemName)
                {
                    items[i].Quantity = item.Quantity;
                    items[i].Borrower = item.Borrower;
                    return;
                }
            }
        }
    }
}
