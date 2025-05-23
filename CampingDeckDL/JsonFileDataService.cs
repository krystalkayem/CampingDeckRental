using RentalCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CampingDeckDL
{
    public class JsonFileDataService : IRentalDataService
    {
        static List<CampingCommon> items = new List<CampingCommon>();
        static string jsonFilePath = "camping_items.json";

        public JsonFileDataService() 
        { 
            ReadJsonDataFromFile();
        }

        private void ReadJsonDataFromFile()
        {
            if (File.Exists(jsonFilePath))
            {
                string jsonText = File.ReadAllText(jsonFilePath);
                items = JsonSerializer.Deserialize<List<CampingCommon>>(jsonText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<CampingCommon>();
            }
        }

        private void WriteJsonDataToFile()
        {
            string jsonString = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonFilePath, jsonString);
        }

        public List<CampingCommon> GetItems() => items;
        public void CreateItem(CampingCommon item) { items.Add(item); WriteJsonDataToFile(); }
        public void UpdateItem(CampingCommon item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == item.Name)
                {
                    items[i].Quantity = item.Quantity;
                    items[i].Borrower = item.Borrower;
                    WriteJsonDataToFile();
                    return;
                }
            }
        }

        public void RemoveItem(CampingCommon item) { items.RemoveAll(i => i.Name == item.Name); WriteJsonDataToFile(); }
    }
    
}
