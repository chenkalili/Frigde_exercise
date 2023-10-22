using System;
using System.Collections.Generic;

namespace Refrigerator_exercise
{
    public class OneFridgeMenu
    {
        public void ConsoleOneFridge(Fridge fridge)
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
                Console.WriteLine("8. Print Shelf By Space");
                Console.WriteLine("10. Ready For Shopping");
                Console.WriteLine("100. Exit");
                Console.Write("Please choose an option: \n");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine();
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