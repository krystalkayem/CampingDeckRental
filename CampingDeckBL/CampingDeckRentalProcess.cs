namespace CampingDeckBL
{
    public class CampingDeckRentalProcess
    {
        public static string[] items = new string[] { "Bike", "Tent", "Camping Chairs", "Camping Tables", "Sleeping Bags", "Umbrella", "Lights", "Cooking Utensils", "Sleeping pads", "Sunshade", "Axe", "Pillow", "Blankets" };
        public static int[] quantities = new int[] { 10, 15, 30, 20, 20, 10, 20, 10, 15, 10, 10, 10, 10 };
        public static bool[] rented = new bool[items.Length];
        public static string[] borrowers = new string[items.Length];
        public static int pin = 041205;

        public static bool BorrowItem(int itemNumber, string name)
        {
            if (itemNumber > 0 && itemNumber <= items.Length && !rented[itemNumber - 1] && quantities[itemNumber - 1] > 0 && !string.IsNullOrWhiteSpace(name))
            {
                rented[itemNumber - 1] = true;
                borrowers[itemNumber - 1] = name;
                quantities[itemNumber - 1]--;
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool ReturnItem(int itemNumber)
        {
            if (itemNumber > 0 && itemNumber <= items.Length && rented[itemNumber - 1])
            {
                rented[itemNumber - 1] = false;
                borrowers[itemNumber - 1] = null;
                quantities[itemNumber - 1]++;
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
    }
}
//quantity, remove getavailable items, remove properties