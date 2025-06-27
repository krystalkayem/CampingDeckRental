using CampingDeckBL;
using RentalCommon;

namespace CampingDeck
{
    internal class Program
    {
        static string[] actions = new string[] { "[1] Rent an Item", "[2] Return an Item", "[3] View All Items", "[4] Exit" };
        static CampingDeckRentalProcess rentalProcess = new CampingDeckRentalProcess();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Campingdeck Rentals! :)");

            string userPin = string.Empty; 

            Console.Write("Enter Admin PIN: ");
            userPin = Console.ReadLine();

            if (rentalProcess.ValidateAdminPin(userPin))
            {
                Console.WriteLine("PIN verified. Welcome, you are now logged in!!");

                int userAction;
                do
                {
                    DisplayActions();
                    userAction = GetUserInput();
                    Console.WriteLine("-----------------------------");

                    switch (userAction)
                    {
                        case 1:
                            RentItem();
                            break;
                        case 2:
                            ReturnItem();
                            break;
                        case 3:
                            ViewAllItems();
                            break;
                        case 4:
                            Console.WriteLine("Thank you for renting at Campingdeck Rentals. Enjoy!!");
                            break;
                        default:
                            Console.WriteLine("Invalid action. Please enter between 1-3 only.");
                            break;
                    }
                } while (userAction != 4);
            }
            else
            {
                Console.WriteLine("Incorrect PIN. Access Denied.");
            }
        }

        static void DisplayActions()
        {
            Console.WriteLine("\n-----------------------------");
            foreach (var action in actions)
            {
                Console.WriteLine(action);
            }
        }

        static int GetUserInput()
        {
            Console.Write("Enter Action: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static void ViewAllItems()
        {
            var items = rentalProcess.GetItems();
            if (items.Count == 0)
            {
                Console.WriteLine("No items found.");
                return;
            }
            Console.WriteLine("\nAll Camping Items:");
            foreach (var item in items)
            {
                Console.WriteLine($"- {item.ItemName} (Oty:{item.Quantity})");
            }
        }

        static void RentItem()
        {
            var items = rentalProcess.GetItems();
            if (items.Count == 0)
            {
                Console.WriteLine("No items available to rent.");
                return;
            }
            Console.WriteLine("\nAvailable Items:");
            for (int i = 0; i <  items.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {items[i].ItemName} (Qty: {items[i].Quantity})");
            }
            Console.Write("Enter the number of the item you want to rent: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > items.Count)
            {
                Console.WriteLine("Invalid item number.");
                return;
            }
            Console.Write("Enter your full name: ");
            string name = Console.ReadLine();

            if (rentalProcess.BorrowItem(index - 1, name))
                Console.WriteLine("Item successfully rented!");
            else
                Console.WriteLine("Failed to rent item.");
        }

        public static void ReturnItem()
        {
            var rentedItems = rentalProcess.GetRentedItems();
            if (rentedItems.Count == 0)
            {
                Console.WriteLine("No items currently rented.");
                return;
            }
            Console.WriteLine("\nRented Items:");
            for (int i = 0; i < rentedItems.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {rentedItems[i].ItemName} - Borrowed by: {rentedItems[i].Borrower}");
            }
            Console.Write("Enter the number of the item you want to return:");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > rentedItems.Count)
            {
                Console.Write("Invalid selection.");
                return;
            }
            if (rentalProcess.ReturnItem(index - 1))
                Console.WriteLine("Item successfully returned!");
            else
                Console.WriteLine("Failed to return item.");
        }
    }
}