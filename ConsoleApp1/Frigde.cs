using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigerator_exercise
{ 
    public class Frigde
    {
        private static int lastFrigdeID = 0;

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
            InputInit();
        }

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
        }

        public double SpaceInFridge()
        {
            double sum = 0;
            foreach (Shelf shelf in _shelves)
            {
                sum += shelf._spaceOnShelf;
            }
            Console.WriteLine("The Empty Space In Fridge is: " + sum);
            return sum;
        }

        public override string ToString()
        {
            string fridgeData = $"ID: {_frigdeID}\n" +$"NumberOfShelves: {_numOfShelves}\n" +$"Model: {_model}\n" +$"Color: {_color}\n";
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
                if(shelf._spaceOnShelf >= newItem._lengthItem)
                {
                    shelf._items.Add(newItem);
                    break;
                }
            }
        }
        public void CleanFridge()
        {
            foreach (Shelf shelf in _shelves)
            {
                shelf._items.RemoveAll(item => item._expiryDate <= DateTime.Today);
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
            return frigdes.OrderBy(fridge => fridge.SpaceInFridge()).ToList();
        }

        public Item RemoveItemByID(int ItemID)
        {
            foreach (Shelf shelf in _shelves)
            {
                Item itemToRemove = shelf._items.Find(i => i._itemID == ItemID);
                if (itemToRemove != null)
                {
                    shelf._items.Remove(itemToRemove);
                    return itemToRemove;
                }
            }
            return null;
        }

        public string ReadyForShopping()
        { 

            return string.Empty; 
        }
    }
}
