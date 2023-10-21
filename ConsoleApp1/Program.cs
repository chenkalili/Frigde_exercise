
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
            Item item1 = new Item("Milk", ItemType.DRINK, KosherType.DARIY, new DateTime(2023, 10, 29), 5);
            Item item2 = new Item("Pizza", ItemType.FOOD, KosherType.DARIY, new DateTime(2023, 10, 24), 10);
            Item item3 = new Item("Chicken", ItemType.FOOD, KosherType.MEAT, new DateTime(2023, 10, 29), 12);
            Item item4 = new Item("Fish", ItemType.FOOD, KosherType.PARVE, new DateTime(2023, 10, 25), 8);
            Item item5 = new Item("Pasta", ItemType.FOOD, KosherType.DARIY, new DateTime(2021, 10, 23), 2);
            fridge.AddItem(item1);
            fridge.AddItem(item2);
            fridge.AddItem(item3);
            fridge.AddItem(item4);
            fridge.AddItem(item5);
            fridgeList.AddFridge(fridge);
            ConsoleListFridge(fridgeList);
        }

        public static void ConsoleListFridge(FridgeList fridgeList)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1.Menu for one fridge ");
                Console.WriteLine("2. Add a fridge");
                Console.WriteLine("3. Remove a fridge");
                Console.WriteLine("4. Print all fridges");
                Console.WriteLine("5. View space in the fridge");
                Console.WriteLine("6. Sort Fridges By Space");
                Console.WriteLine("7. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        fridgeList.MenuForOneFridge();
                        break;
                    case 2:
                        fridgeList.AddFridge();
                        break;
                    case 3:
                        fridgeList.RemoveFridge();
                        break;
                    case 4:
                        Console.WriteLine(fridgeList.ToString());
                        break;
                    case 5:
                        Console.WriteLine($"Space in fridges: {fridgeList._spaceInFridges}");
                        break;
                    case 6:
                        fridgeList.SortFridgesBySpace();
                        break;
                    case 7:
                        exit=true;
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
    }
}
