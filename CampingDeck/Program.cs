using CampingDeckBL;

namespace CampingDeck
{
    internal class Program
    {
        //rent an item, return item, view all items, exit
        static string[] actions = new string[] { "[1] Rent an Item", "[2] Return an Item", "[3] View All Items", "[4] Exit" };


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Campingdeck Rentals! :)");

            //pin, rent an item, return an item, view all items
            int userPin = 0;

            Console.Write("Enter Admin PIN: ");
            userPin = Convert.ToInt32(Console.ReadLine());

            if (CampingDeckRentalProcess.ValidatePIN(userPin))
            {
                Console.WriteLine("PIN verified. Welcome, you are now logged in!!");

                int userAction;
                do
                {
                    DisplayActions();
                    userAction = GetUserInput();
                    Console.WriteLine("-----------------------------");
                    //Console.Write("Enter Action: ");
                    //userAction = Convert.ToInt32(Console.ReadLine());

                    switch (userAction)
                    {
                        case 1:
                            BorrowItem();
                            break;
                        case 2:
                            ReturnItem();
                            break;
                        case 3:
                            DisplayItems();
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

        static void DisplayItems()
        {
            Console.WriteLine("\nAll Camping Items: ");
            Console.WriteLine("Item Name               Quantity");
            Console.WriteLine("-----------------------------------------");

            for (int i = 0; i < CampingDeckRentalProcess.items.Length; i++)
            {
                string itemName = CampingDeckRentalProcess.items[i];
                int quantity = CampingDeckRentalProcess.quantities[i];

                if (itemName.Length < 25)
                {
                    itemName += new string(' ', 25 - itemName.Length);
                }
                Console.WriteLine(itemName + quantity);
            }
        }

        static void BorrowItem()
        {
            Console.WriteLine("\nAvailable Items:");
            Console.WriteLine("No.   Item Name               Quantity");
            Console.WriteLine("-----------------------------------------");

            for (int i = 0; i < CampingDeckRentalProcess.items.Length; i++)
            {
                string itemName = CampingDeckRentalProcess.items[i];
                int quantity = CampingDeckRentalProcess.quantities[i];

                if (quantity > 0)
                {
                    if (itemName.Length < 25)
                    {
                        itemName += new string(' ', 25 - itemName.Length);
                    }
                    Console.WriteLine($"{i + 1,-4} {itemName}{quantity}");
                }
            }

            Console.Write("Enter the number of the item you want to borrow: ");
            int selection = Convert.ToInt32(Console.ReadLine());

            if (selection < 0 || selection > CampingDeckRentalProcess.items.Length || CampingDeckRentalProcess.quantities[selection - 1] == 0)
            {
                Console.WriteLine("Invalid selection or item out of stock. Please try again.");
                return;
            }

            Console.Write("Enter your full name: ");
            string name = Console.ReadLine();

            if (CampingDeckRentalProcess.BorrowItem(selection, name))
            {
                Console.WriteLine($"Thank you, {name}. You have successfully borrowed the {CampingDeckRentalProcess.items[selection - 1]}.");
            }
            else
            {
                Console.WriteLine("Borrowing failed. The item may already be rented or the selection was invalid.");
            }

        }

        public static void ReturnItem()
        {
            Console.WriteLine("\nRented Items:");
            for (int i = 0; i < CampingDeckRentalProcess.items.Length; i++)
            {
                if (CampingDeckRentalProcess.rented[i])
                {
                    Console.WriteLine($"[{i + 1}] {CampingDeckRentalProcess.items[1]} (Rented by {CampingDeckRentalProcess.borrowers[i]})");
                }
            }
            Console.Write("Enter the number of the item you want to return: ");
            int selection = Convert.ToInt32(Console.ReadLine());

            if (selection < 0 || selection > CampingDeckRentalProcess.items.Length || !CampingDeckRentalProcess.rented[selection - 1])
            {
                Console.WriteLine("Invalid selection. Please try again.");
                return;
            }

            if (CampingDeckRentalProcess.ReturnItem(selection))
            {
                Console.WriteLine($"Item {CampingDeckRentalProcess.items[selection - 1]} has been returned successfully.");
            }
            else
            {
                Console.WriteLine("Return failed. The selection might be invalid or the item is not rented.");
            }
        }
    }
}