using RentalCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampingDeckDL
{
    public class TextFileDataService : IRentalDataService
    {
        string filePath = "camping_items.txt";
        List<CampingCommon> items = new List<CampingCommon>();

        public TextFileDataService()
        { 
            GetDataFromFile();
        }

        private void GetDataFromFile()
        {
            if (!File.Exists(filePath))
                return;

            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length >= 2 && int.TryParse(parts[1], out int quantity))
                {
                    var item = new CampingCommon(parts[0], quantity);
                    item.Borrower = parts.Length > 2 ? parts[2] : string.Empty;
                    items.Add(item);
                }
            }
        }

        private void WriteDataTofile()
        {
            List<string> lines = new List<string>();
            foreach (var item in items)
            {
                lines.Add($"{item.ItemName} | {item.Quantity} | {item.Borrower ?? ""}");
            }

            File.WriteAllLines(filePath, lines);
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
                    WriteDataTofile();
                    return;
                }
            }
        }
    }
}
