using RentalCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CampingDeckDL
{
    public class JsonFileDataService : IRentalDataService
    {
        static List<CampingCommon> items = new List<CampingCommon>();
        static string jsonFilePath = "camping_items.json";

        public JsonFileDataService() 
        {
            LoadItemsFromFile();
        }

        private void LoadItemsFromFile()
        {
            if (!File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                var loadedItems = JsonSerializer.Deserialize<List<CampingCommon>>(json);
                if (loadedItems != null)
                {
                    items = loadedItems;
                }
            }
        }

        private void SaveItemsToFile()
        {
            string json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(jsonFilePath, json);
        }

        public List<CampingCommon> GetItems()
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
                    SaveItemsToFile();
                    return;
                }
            }
        }
    }
}
