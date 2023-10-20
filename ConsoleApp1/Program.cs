
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace Refrigerator_exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            FridgeList fridgeList = new FridgeList("ListBoschFridge", 7);
            Fridge fridge = new Fridge("Samsung Family Hub", "Black", 5);
            Item item1 = new Item("Milk", ItemType.DRINK, KosherType.DARIY, new DateTime(2023, 10, 15), 5);
            Item item2 = new Item("Pizza", ItemType.FOOD, KosherType.DARIY, new DateTime(2023, 10, 23), 10);
            Item item3 = new Item("Chicken", ItemType.FOOD, KosherType.MEAT, new DateTime(2023, 10, 29), 12);
            Item item4 = new Item("Fish", ItemType.FOOD, KosherType.Parve, new DateTime(2023, 10, 25), 8);
            Item item5 = new Item("Pasta", ItemType.FOOD, KosherType.DARIY, new DateTime(2023, 10, 23), 2);
            fridge.AddItem(item1);
            fridge.AddItem(item2);
            fridge.AddItem(item3);
            fridge.AddItem(item4);
            fridge.AddItem(item5);
            Menu(fridge, fridgeList);
        }
        using System;
using System.Collections.Generic;

namespace Refrigerator_exercise
    {
        class Program
        {
            static void Main(string[] args)
            {
                FridgeList fridgeList = new FridgeList("My Fridge List", 3); // Example initialization

                while (true)
                {
                    Console.WriteLine("\nMenu:");
                    Console.WriteLine("1. View space in the fridge");
                    Console.WriteLine("2. Add a fridge");
                    Console.WriteLine("3. Remove a fridge");
                    Console.WriteLine("4. Print all fridges");
                    Console.WriteLine("5. Select a specific fridge");
                    Console.WriteLine("6. Exit");

                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"Space in fridges: {fridgeList._spaceInFridges}");
                            break;

                        case 2:
                            Fridge newFridge = new Fridge(); // Initialize a new fridge (complete this according to your Fridge class)
                            fridgeList.AddFridge(newFridge);
                            Console.WriteLine("Fridge added to the list.");
                            break;

                        case 3:
                            // You can list the fridges and remove one by choosing its index
                            List<Fridge> fridges = fridgeList._fridges;
                            Console.WriteLine("Select a fridge to remove:");
                            for (int i = 0; i < fridges.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {fridges[i]}");
                            }
                            Console.Write("Enter the index of the fridge to remove: ");
                            int indexToRemove = int.Parse(Console.ReadLine()) - 1;
                            if (indexToRemove >= 0 && indexToRemove < fridges.Count)
                            {
                                fridgeList.RemoveFridgeByID(fridges[indexToRemove]);
                                Console.WriteLine("Fridge removed from the list.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid index. No fridge removed.");
                            }
                            break;

                        case 4:
                            Console.WriteLine(fridgeList.ToString());
                            break;

                        case 5:
                            // You can select a specific fridge and interact with it (complete this according to your Fridge class)
                            Console.WriteLine("Select a specific fridge:");
                            for (int i = 0; i < fridgeList._fridges.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {fridgeList._fridges[i]}");
                            }
                            Console.Write("Enter the index of the fridge to select: ");
                            int selectedIndex = int.Parse(Console.ReadLine()) - 1;
                            if (selectedIndex >= 0 && selectedIndex < fridgeList._fridges.Count)
                            {
                                Fridge selectedFridge = fridgeList._fridges[selectedIndex];
                                // Add code to interact with the selected fridge
                                Console.WriteLine($"You selected: {selectedFridge}");
                            }
                            else
                            {
                                Console.WriteLine("Invalid index. No fridge selected.");
                            }
                            break;

                        case 6:
                            Console.WriteLine("Exiting...");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
            }
        }
    }

    public static void Menu(Fridge fridge, FridgeList fridges)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Refrigerator Menu:");
                Console.WriteLine("1. Print all items in the fridge");
                Console.WriteLine("2. Print available space in the fridge");
                Console.WriteLine("3. Add an item to the fridge");
                Console.WriteLine("4. Remove an item from the fridge");
                Console.WriteLine("5. Clean the fridge");
                Console.WriteLine("6. Retrieve a product to eat");
                Console.WriteLine("7. Print all products sorted by expiration date");
                Console.WriteLine("8. Print all shelves sorted by available space");
                Console.WriteLine("9. Exit");
                Console.Write("Please choose an option: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            fridge.PrintFridge();
                            break;
                        case 2:
                            fridge.PrintSpaceInFridge();
                            break;
                        case 3:
                            fridge.AddItem();
                            break;
                        case 4:
                            fridge.RemoveItemByID();
                            break;
                        case 5:
                            fridge.PrintCleanFridge();
                            break;
                        case 6:
                            fridge.AskWhatToEat();
                            break;
                        case 7:
                            fridge.PrintItemByDate();
                            break;
                        case 8:
                            fridge.PrintShelfBySpace();
                            break;
                        case 9:
                            fridges.SortFridgesBySpace();
                            break;
                        case 10:
                            fridge.ReadyForShopping();
                            break;
                        case 100:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please choose a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid option number.");
                }
            }
            Console.WriteLine();
        }
        
    }
}
