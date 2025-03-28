namespace CampingDeckBL
{
    public class CampingDeckRentalProcess
    {
        public static string[] items = new string[] { "Bike", "Tent", "Camping Chairs", "Camping Tables", "Sleeping Bags", "Umbrella", "Lights", "Cooking Utensils", "Sleeping pads", "Sunshade", "Axe", "Pillow", "Blankets" };
        public static bool[] rented = new bool[items.Length];
        public static string[] borrowers = new string[items.Length];
        public static int pin = 041205;

        public static bool BorrowItem(int itemNumber, string name)
        {
            if (itemNumber > 0 && itemNumber <= items.Length && !rented[itemNumber - 1] && !string.IsNullOrWhiteSpace(name))
            {
                rented[itemNumber - 1] = true;
                borrowers[itemNumber - 1] = name;
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool ReturnItem(int itemNumber)
        {
            if (itemNumber > 1 && itemNumber <= items.Length && rented[itemNumber - 1])
            {
                rented[itemNumber - 1] = false;
                borrowers[itemNumber - 1] = null;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidatePIN(int userPin)
        {
            return userPin == pin;
        }

        public static RentalItem[] GetAvailableItems()
        {
            var available = new List<RentalItem>();
            for (int i = 0; i < items.Length; i++)
            {
                if (!rented[i])
                {
                    available.Add(new RentalItem
                    {
                        Index = i + 1,
                        ItemName = items[i]
                    });
                }
            }
            return available.ToArray();
        }

        public static RentalItem[] GetRentedItems()
        {
            var rentedList = new List<RentalItem>();
            for (int i = 0; i < items.Length; i++)
            {
                if (rented[i])
                {
                    rentedList.Add(new RentalItem
                    {
                        Index = i + 1,
                        ItemName = items[i],
                        Borrower = borrowers[i]
                    });
                }
            }
            return rentedList.ToArray();
        }

        public class RentalItem
        {
            public int Index { get; set; }
            public string ItemName { get; set; } = string.Empty;
            public string? Borrower { get; set; }
        }
    }
}
