using System;

namespace IntegrativeProg
{
    internal class Program
    {
        //rent an item, return item, exit
        static string[] actions = new string[] { "[1] Rent an Item", "[2] Return an Item", "[3] Exit" };
        static string[] items = new string[] { "Bike", "Tent", "Camping Chairs", "Camping Tables", "Sleeping Bags", "Umbrella", "Lights", "Cooking Utensils", "Sleeping pads", "Sunshade", "Axe", "Pillow", "Blankets" };
        static bool[] rented = new bool[items.Length];
        static string[] borrowers = new string[items.Length];

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Campingdeck Rentals!!");

            //pin, rent an item, return an item
            int pin = 041205;
            int userPin = 0;

            Console.Write("Enter Admin PIN: ");
            userPin = Convert.ToInt32(Console.ReadLine());

            if (userPin == pin)
            {
                Console.WriteLine("PIN verified. Welcome, you are now logged in!!");

                int userAction;
                do
                {
                    DisplayActions();
                    Console.WriteLine("-----------------------------");
                    Console.Write("Enter Action: ");
                    userAction = Convert.ToInt32(Console.ReadLine());

                    switch (userAction)
                    {
                        case 1:
                            BorrowItem();
                            break;
                        case 2:
                            ReturnItem();
                            break;
                        case 3:
                            Console.WriteLine("Thank you for renting at Campingdeck Rentals. Enjoy!!");
                            break;
                        default:
                            Console.WriteLine("Invalid action. Please enter between 1-3 only.");
                            break;
                    }
                } while (userAction != 3);
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
        static void BorrowItem()
        {
            Console.WriteLine("\nAvailable items: ");
            for (int i = 0; i < items.Length; i++)
            {
                if (!rented[i])
                {
                    Console.WriteLine($"[{i + 1}] {items[i]}");
                }
            }

            Console.Write("Enter the number of the item you want to borrow: ");
            int itemNumber = Convert.ToInt32(Console.ReadLine());

            if (itemNumber > 0 && itemNumber <= items.Length && !rented[itemNumber - 1])
            {
                Console.Write("Enter your full name: ");
                string name = Console.ReadLine();

                rented[itemNumber - 1] = true;
                borrowers[itemNumber - 1] = name;

                Console.WriteLine($"Thank you, {name}. You have successfully borrowed the {items[itemNumber - 1]}.");
            }
            else
            {
                Console.WriteLine("Invalid selection or item or item already rented. Please try again.");
            }
        }

        static void ReturnItem()
        {
            Console.WriteLine("\nItems Currently Rented: ");
            for (int i = 0; i < items.Length; i++)
            {
                if (rented[i])
                {
                    Console.WriteLine($"[{i + 1}] {items[i]} Rented by {borrowers[i]}");
                }
            }

            Console.Write("\nEnter the number of the item you want to return: ");
            int itemNumber = Convert.ToInt32(Console.ReadLine());

            if (itemNumber > 0 && itemNumber <= items.Length && rented[itemNumber - 1])
            {
                Console.WriteLine($"Thank you, {borrowers[itemNumber - 1]}, for returning the {items[itemNumber - 1]}.");
                rented[itemNumber - 1] = false;
                borrowers[itemNumber - 1] = null;
            }
            else
            {
                Console.WriteLine("Invalid selection or item not currently rented. Please try again.");
            }
        }
    }
          

}