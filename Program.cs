using System;

namespace IntegrativeProg
{
    class Program
    {
        static void Main(string[] args)
        {
            int adminPin = 041205;
            bool isAuthenticated = false;
            string[] items = new string[10] { "Bike", "Tent", "Camping chairs", "Camping tables", "Sleeping bags", "Lighting", "Kitchen gear", "Sleeping pads", "Sunshade", "Axe" };  //items
            bool[] rented = new bool[10];  // false = not rented, true = rented
            string[] borrowers = new string[10]; // Adjusted size to match the items array

            Console.WriteLine("Welcome to Campingdeck Rentals!");

            while (!isAuthenticated)
            {
                Console.Write("Enter PIN to rent an item: ");
                if (int.TryParse(Console.ReadLine(), out int enteredPin) && enteredPin == adminPin)
                {
                    isAuthenticated = true;
                    Console.WriteLine("PIN verified. Welcome, you are now logged in!");
                }
                else
                {
                    Console.WriteLine("Incorrect PIN. Please try again.");
                }
            }

            bool exit = false;
            while (!exit)
            {
                // display available items
                Console.WriteLine("\nAvailable Items:");
                for (int i = 0; i < items.Length; i++)
                {
                    string availability = rented[i] ? $"Rented by {borrowers[i]}" : "Available";
                    Console.WriteLine($"[{i + 1}] {items[i]} - {availability}");
                }

                Console.WriteLine("\nEnter the number of the item you want to rent, 11 to return an item, or 0 to exit:");
                int action = Convert.ToInt32(Console.ReadLine());

                if (action == 0)
                {
                    exit = true;
                    Console.WriteLine("Thank you for renting at Campingdeck Rentals!");
                }
                else if (action == 11) // option to return the item
                {
                    Console.WriteLine("\nEnter the number of the item you want to return (1-10):");
                    int returnAction = Convert.ToInt32(Console.ReadLine());

                    if (returnAction >= 1 && returnAction <= items.Length)
                    {
                        int index = returnAction - 1;
                        if (rented[index])
                        {
                            Console.WriteLine($"'{items[index]}' is currently rented by {borrowers[index]}. Do you want to return it? (Y/N)");
                            string confirmation = Console.ReadLine().ToUpper();

                            if (confirmation == "Y")
                            {
                                rented[index] = false; // mark item as returned
                                Console.WriteLine($"'{items[index]}' has been returned. Thank you!");
                                borrowers[index] = null; // clear the borrower's name
                            }
                            else
                            {
                                Console.WriteLine("Item return cancelled.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("This item was not rented.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid item number.");
                    }
                }
                else if (action >= 1 && action <= items.Length) // rent an item
                {
                    int index = action - 1;
                    if (rented[index])
                    {
                        Console.WriteLine("Sorry, the item is already rented.");
                    }
                    else
                    {
                        Console.Write("Enter your name: ");
                        borrowers[index] = Console.ReadLine(); // store the borrower's name
                        rented[index] = true;  // mark item as rented
                        Console.WriteLine($"You have successfully rented the {items[index]}.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }
    }
}