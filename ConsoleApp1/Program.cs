
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
            Frigde fridge = new Frigde("Samsung Family Hub", "Black", 5);
            Item item1 = new Item("Milk", ItemType._drink, KosherType._dairy, new DateTime(2023, 10, 15), 5);
            Item item2 = new Item("Pizza", ItemType._food, KosherType._dairy, new DateTime(2023, 10, 23), 10);
            Item item3 = new Item("Chicken", ItemType._food, KosherType._meat, new DateTime(2023, 10, 17), 12);
            Item item4 = new Item("Fish", ItemType._food, KosherType._pareve, new DateTime(2023, 10, 25), 8);
            Item item5 = new Item("Pasta", ItemType._food, KosherType._dairy, new DateTime(2023, 10, 23), 15);
            fridge.AddItem(item1);
            fridge.AddItem(item2);
            fridge.AddItem(item3);
            fridge.AddItem(item4);
            fridge.AddItem(item5);
            Menu(fridge);
        }
        public static void Menu(Frigde fridge)
        {
            bool exit = false;
            Console.WriteLine("Refrigerator Menu:");
            Console.WriteLine("1. Print all items in the refrigerator");
            Console.WriteLine("2. Print available space in the fridge");
            Console.WriteLine("3. Add an item to the refrigerator");
            Console.WriteLine("4. Remove an item from the refrigerator");
            Console.WriteLine("5. Clean the refrigerator");
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
                        fridge.SpaceInFridge();
                        break;
                    case 3:
                        fridge.AddItem();
                        break;
                    case 4:
                        fridge.RemoveItemByID();
                        break;
                    case 5:
                        fridge.CleanFridge();
                        break;
                    case 6:
                        //fridge.whatToEat(); ask the user what he want
                        break;
                    case 7:
                        //fridge
                        break;
                    case 8:
                        //fridge
                        break;
                    case 9:
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

            Console.WriteLine();
        }
        
    }
}
