using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigerator_exercise
{ 
    public class Frigde
    {
        private static int lastFrigdeID = 0;
        public double _spaceInFridge = 0;

        public int _frigdeID { get; }
        public string _model { get; set; }
        public string _color { get; set; }
        public int _numOfShelves { get; set; }
        public List<Shelf> _shelves { get; set; }

        public Frigde(string model, string color, int numberOfShelves)
        {
            _frigdeID = ++lastFrigdeID;
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
        

        public void SpaceInFridge()
        {
            double sum = 0;
            foreach (Shelf shelf in _shelves)
            {
                sum += shelf._spaceOnShelf;
            }
            Console.WriteLine("The Empty Space In Fridge is: " + sum);
            _spaceInFridge= sum;
        }

        public override string ToString()
        {
            string fridgeData = $"fridgeID: {_frigdeID}\n" + $"NumberOfShelves: {_numOfShelves}\n" + $"Model: {_model}\n" + $"Color: {_color}\n\n";
            foreach (Shelf shelf in _shelves)
            {
                fridgeData += shelf.ToString() + "\n";
            }
            return fridgeData;
        }
        public void AddItem()
        {
            int shelfID = 0;
            Console.WriteLine("Enter item details: item Name,item Type, kosher Type, Expiry Date and lengthItem):");
            string input = Console.ReadLine();
            string[] inputParts = input.Split(' ');

            if (inputParts.Length == 5 &&
                Enum.TryParse(inputParts[1], out ItemType itemType) && 
                Enum.TryParse(inputParts[2], out KosherType kosherType)&& 
                DateTime.TryParse(inputParts[4], out DateTime expiryDate) && 
                double.TryParse(inputParts[4], out double lengthItem))
            {
                AddItem(new Item(inputParts[0], itemType, kosherType, expiryDate, lengthItem));
                Console.WriteLine("Item added successfully.");
            }
         
        }
        public void AddItem(Item newItem)
        {
            foreach (Shelf shelf in _shelves)
            {
                if (shelf._spaceOnShelf >= newItem._lengthItem)
                {
                    newItem._itemShelf = shelf._floorNumber;
                    shelf._items.Add(newItem);
                    break;
                }
            }
        }
        
        public void CleanFridge()
        {
            foreach (Shelf shelf in _shelves)
            {
                shelf._items.RemoveAll(item =>
                {
                    if (item._expiryDate <= DateTime.Today)
                    {
                        shelf._spaceOnShelf += item._lengthItem;
                        _spaceInFridge += item._lengthItem;
                        return true;
                    }
                    return false;
                });
            }
        }

        public List<Item> whatToEat(KosherType kosher, ItemType type)
        {
            List<Item> foodInFridge = new List<Item>();
            CleanFridge();
            foreach (Shelf shelf in _shelves)
            {
                List<Item> foodInOneShelf = shelf._items.Where(item => item._type == type && item._kosher == kosher).ToList();
                foodInFridge.AddRange(foodInOneShelf);
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

        public static List<Frigde> SortFrigdeBySpace(List<Frigde> frigdes)
        {
            return frigdes.OrderBy(fridge => fridge._spaceInFridge).ToList();
        }

        public Item RemoveItemByID()
        {
            Console.Write("Enter the item number you want to take out of the fridge: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int itemID))
            {
                foreach (Shelf shelf in _shelves)
                {
                    Item itemToRemove = shelf._items.Find(i => i._itemID == itemID);
                    if (itemToRemove != null)
                    {
                        shelf._items.Remove(itemToRemove);
                        shelf._spaceOnShelf += itemToRemove._lengthItem;
                        _spaceInFridge += itemToRemove._lengthItem;
                        return itemToRemove;
                    }
                }
            }
            return null;
        }

        public string ReadyForShopping()
        {
            double enoughSpace = 20, newSpace=0;
            if(_spaceInFridge <= enoughSpace)
            {
                CleanFridge();
                if (_spaceInFridge <= enoughSpace)
                {
                    newSpace += checkIfToRemoveItem(KosherType._dairy, 3);
                    newSpace += checkIfToRemoveItem(KosherType._meat, 7);
                    newSpace += checkIfToRemoveItem(KosherType._pareve, 1);
                    if((newSpace + _spaceInFridge) > enoughSpace)
                    {
                        RemoveItemByPramas(KosherType._dairy, 3);
                        RemoveItemByPramas(KosherType._meat, 7);
                        RemoveItemByPramas(KosherType._pareve, 1);
                    }
                    else
                    {
                        return "it's not time to do a shopping";
                    }
                }
            }
            return string.Empty; 
        }

        public void RemoveItemByPramas(KosherType food, double days )
        {
            foreach (Shelf shelf in _shelves)
            {
                shelf._items.RemoveAll(item =>
                {
                    if (item._kosher == food && item._expiryDate == DateTime.Today.AddDays(-days))
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
        public void PrintFridge()
        {
            Console.WriteLine(ToString());
        }
    }
}


/**
         
        public void InputInit()
        {
            for (int i = 0; i < _shelves.Count; i++)
            {
                Console.WriteLine("Enter the emptySpace of the shelf:");
                string input = Console.ReadLine();
                string[] inputParts = input.Split(' ');
                if (double.TryParse(inputParts[0], out double emptySpace))
                {
                    _shelves.Add(new Shelf(emptySpace));
                    Console.WriteLine("Shelf added");
                }
            }
        }*/