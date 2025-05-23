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
            if (!File.Exists(filePath)) return;

            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                items.Add(new CampingCommon(parts[0], int.Parse(parts[1])) { Borrower = parts.Length > 2 ? parts[2] : null });
            }
        }

        private void WriteDataToFile()
        {
            string[] lines = new string[items.Count];
            for (int i = 0; i < items.Count; i++)
            {
                lines[i] = $"{items[i].Name} | {items[i].Quantity} | {items[i].Borrower ?? ""}"; 
            }
            File.WriteAllLines(filePath, lines);
        }

        public List<CampingCommon> GetItems() => items;
        public void CreateItem(CampingCommon item) { items.Add(item); WriteDataToFile(); }
        public void UpdateItem(CampingCommon item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == item.Name)
                {
                    items[i].Borrower = item.Borrower;
                    WriteDataToFile();
                    return;
                }
            }
        }
        public void RemoveItem(CampingCommon item) { items.RemoveAll(i => i.Name == item.Name); WriteDataToFile(); }
    }
}
