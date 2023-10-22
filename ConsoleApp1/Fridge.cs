using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Refrigerator_exercise
{ 
    public class Fridge
    {
        private static int lastFridgeID = 0;
        public double _spaceInFridge {  get; set; }
        public int _fridgeID { get; }
        public string _model { get; set; }
        public string _color { get; set; }
        public int _numOfShelves { get; set; }
        public List<Shelf> _shelves { get; set; }

        const int SPACE= 15;

        public Fridge(string model, string color, int numberOfShelves)
        {
            _fridgeID = ++lastFridgeID;
            _spaceInFridge = numberOfShelves * SPACE;
            _model = model;
            _color = color;
            _shelves = new List<Shelf>();
            _numOfShelves = numberOfShelves;
            AddShelfInFridge();
        }

        public void AddShelfInFridge()
        {
            for(int i=0;  i<_numOfShelves; i++)
            {
                Shelf newShelf = new Shelf(i);
                _shelves.Add(newShelf);
            }
        }

        public override string ToString()
        {
            string fridgeData = $"fridgeID: {_fridgeID}\n" + $"NumberOfShelves: {_numOfShelves}\n" + $"Model: {_model}\n" + $"Color: {_color}\n\n";
            foreach (Shelf shelf in _shelves)
            {
                fridgeData += shelf.ToString() + "\n";
            }
            return fridgeData;
        }
        
        public void AddItem(Item newItem)
        {
            foreach (Shelf shelf in _shelves)
            {
                if (shelf._spaceOnShelf >= newItem._lengthItem)
                {
                    shelf._spaceOnShelf -= newItem._lengthItem;
                    newItem._itemShelf = shelf._floorNumber;
                    _spaceInFridge -= newItem._lengthItem;
                    shelf._items.Add(newItem);
                    Console.WriteLine("Item added successfully.");
                    break;
                }
            }
        }
        
        public List<Item> CleanFridge()
        {
            List<Item> cleanItems = new List<Item>();
            foreach (Shelf shelf in _shelves)
            {
                shelf._items.RemoveAll(item =>
                {
                    if (item._expiryDate <= DateTime.Today)
                    {
                        cleanItems.Add(item);
                        shelf._spaceOnShelf += item._lengthItem;
                        _spaceInFridge += item._lengthItem;
                        return true;
                    }
                    return false;
                });
            }
            return cleanItems;
        }

        public List<Item> whatToEat(KosherType kosher, ItemType type)
        {
            List<Item> foodInFridge = new List<Item>();
            CleanFridge();
            foreach (Shelf shelf in _shelves)
            {
                foreach (Item itemInFridge in shelf._items)
                {
                    if (itemInFridge._type == type && itemInFridge._kosher == kosher)
                    {
                        Item item = itemInFridge;
                        foodInFridge.Add(item);
                    }
                }
            }
            return foodInFridge;
        }


        public List<Item> SortItemsByExpirateDate()
        {
            List<Item> allItem = new List<Item>();
            foreach (Shelf shelf in _shelves)
            {
                allItem.AddRange(shelf._items);
            }
            return allItem.OrderBy(item => item._expiryDate).ToList();
        }

        public List<Shelf> SortShelvesBySpace()
        {
            return _shelves.OrderBy(shelf => shelf._spaceOnShelf).ToList();
        }

        public List<Fridge> SortFridgeBySpace(List<Fridge> fridges)
        {
            return fridges.OrderBy(fridge => fridge._spaceInFridge).ToList();
        }

        public void ReadyForShopping()
        {
            double enoughSpace = 90, newSpace=0;
            if(_spaceInFridge <= enoughSpace)
            {
                CleanFridge();
                if (_spaceInFridge <= enoughSpace)
                {
                    newSpace += checkIfToRemoveItem(KosherType.DARIY, 3);
                    newSpace += checkIfToRemoveItem(KosherType.MEAT, 7);
                    newSpace += checkIfToRemoveItem(KosherType.PARVE, 1);
                    if((newSpace + _spaceInFridge) > enoughSpace)
                    {
                        RemoveItemByPramas(KosherType.DARIY, 3);
                        RemoveItemByPramas(KosherType.MEAT, 7);
                        RemoveItemByPramas(KosherType.PARVE, 1);
                    }
                    else
                    {
                        Console.WriteLine("it's not time to do a shopping\n");
                    }
                }
                else
                {
                    Console.WriteLine("You are ready for shopping\n");
                }
            }
            else
            {
                Console.WriteLine("You are ready for shopping\n");
            }
        }

        public void RemoveItemByPramas(KosherType food, double days )
        {
            foreach (Shelf shelf in _shelves)
            {
                shelf._items.RemoveAll(item =>
                {
                    if (item._kosher == food && item._expiryDate < DateTime.Today.AddDays(days))
                    {
                        shelf._spaceOnShelf += item._lengthItem;
                        Console.WriteLine($"The item '{item._productName}' has been thrown away.");
                        return true;
                    }
                    return false;
                });
            }
        }

        public double checkIfToRemoveItem(KosherType food, double days)
        {
            double sumOfNewSpace =0;
            foreach (Shelf shelf in _shelves)
            {
                foreach (Item item in shelf._items)
                {
                    if (item._kosher == food && item._expiryDate == DateTime.Today.AddDays(-days))
                    {
                        sumOfNewSpace += item._lengthItem;
                    }
                }
            }
            return sumOfNewSpace;
        }

        public void PrintSpaceInFridge()
        {
            double sum = 0;
            foreach (Shelf shelf in _shelves)
            {
                sum += shelf._spaceOnShelf;
            }
            Console.WriteLine("The Empty Space In Fridge is: " + sum);
            _spaceInFridge = sum;
        }
        public void PrintFridge()
        {
            Console.WriteLine(ToString());
        }

        public void PrintItemByDate()
        {
            List<Item> items = SortItemsByExpirateDate();
            foreach (Item item in items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }

        public void PrintShelfBySpace()
        {
            List<Shelf> shelves = SortShelvesBySpace();
            foreach (Shelf shelf in shelves)
            {
                Console.WriteLine(shelf.ToString());
            }
            Console.WriteLine();
        }
        public void PrintCleanFridge()
        {
            List<Item> items = CleanFridge();
            Console.WriteLine("The items removed from the refrigerator due to cleaning:");
            foreach (Item item in items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }

        public void AddItem()
        {
            Console.WriteLine("Enter item details: item Name,item Type, kosher Type, Expiry Date and lengthItem):");
            string input = Console.ReadLine();
            string[] inputParts = input.Split(' '), date = inputParts[3].Split('-');

            if (inputParts.Length == 5 && date.Length == 3 &&
                Enum.TryParse(inputParts[1], out ItemType itemType) &&
                Enum.TryParse(inputParts[2], out KosherType kosherType) &&
                double.TryParse(inputParts[4], out double lengthItem) &&
                int.TryParse(date[0], out int year) &&
                int.TryParse(date[1], out int day) &&
                int.TryParse(date[2], out int month))
            {
                DateTime expiryDate = new DateTime(year, month, day);
                AddItem(new Item(inputParts[0], itemType, kosherType, expiryDate, lengthItem));
            }
        }
        public void AskWhatToEat()
        {
            Console.WriteLine("Enter what you want to eat (Kosher Type, Item Type):");
            string input = Console.ReadLine();
            string[] inputParts = input.Split(' ');
            try
            {
                if (inputParts.Length != 2)
                {
                    throw new FormatException("Invalid input. Please enter Kosher Type and Item Type separated by a space.");
                }

                if (!Enum.TryParse(inputParts[0], out KosherType kosherType) ||
                    !Enum.TryParse(inputParts[1], out ItemType itemType))
                {
                    throw new FormatException("Invalid input. Please enter valid Kosher Type and Item Type.");
                }

                List<Item> items = whatToEat(kosherType, itemType);
                foreach (Item item in items)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public Item RemoveItemByID()
        {
            Console.Write("Enter the item number you want to take out of the fridge: ");
            if (int.TryParse(Console.ReadLine(), out int itemID))
            {
                foreach (Shelf shelf in _shelves)
                {
                    Item itemToRemove = shelf._items.Find(i => i._itemID == itemID);
                    if (itemToRemove != null)
                    {
                        shelf._items.Remove(itemToRemove);
                        shelf._spaceOnShelf += itemToRemove._lengthItem;
                        _spaceInFridge += itemToRemove._lengthItem;
                        Console.WriteLine("The item has been successfully removed\n");
                        return itemToRemove;
                    }
                }
            }
            return null;
        }
    }
}

