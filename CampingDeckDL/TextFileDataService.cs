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
        string filePath = "campingItems.txt";
        List<CampingCommon> items = new List<CampingCommon>();

        public TextFileDataService()
        {
            LoadDataFromFile();
        }

        private void LoadDataFromFile()
        {
            if (!File.Exists(filePath))
                return;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');

                items.Add(new CampingCommon(parts[0], int.Parse(parts[1]))
                {
                    Borrower = string.IsNullOrEmpty(parts[2]) ? null : parts[2]
                }); 
            }
        }

        private void WriteDataTofile()
        {
            var lines = new string[items.Count];

            for (int i = 0; i < items.Count; i++)
            {
                lines[i] = $"{items[i].Name} | {items[i].Quantity} | {items[i].Borrower}";
            }

            File.WriteAllLines(filePath, lines);
        }

        public void Save(List<CampingCommon> newItems)
        {
            items = new List<CampingCommon>(newItems);
            WriteDataTofile();
        }

        public List<CampingCommon> Load()
        {
            return items;
        }
    }
}
