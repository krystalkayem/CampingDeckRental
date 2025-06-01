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
        static string jsonFilePath = "campingItems.json";

        public JsonFileDataService()
        {
            ReadJsonDataFromFile();
        }

        private void ReadJsonDataFromFile()
        {
            if (!File.Exists(jsonFilePath))
            {
                File.Create(jsonFilePath).Close();
                return;
            }

            string jsonText = File.ReadAllText(jsonFilePath);

            items = JsonSerializer.Deserialize<List<CampingCommon>>(jsonText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                ?? new List<CampingCommon>();
        }

        private void WriteJsonDataToFile()
        {
            string jsonString = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(jsonFilePath, jsonString);
        }

        public void Save(List<CampingCommon> newItems)
        {
            items = new List<CampingCommon>(newItems);
            WriteJsonDataToFile();
        }

        public List<CampingCommon> Load()
        {
            return items;
        }
    }
}
