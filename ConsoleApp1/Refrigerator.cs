using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigerator_exercise
{ 
    public class Refrigerator
    {
        private static int lastRefrigeratorID = 0;

        public int _refrigeratorID { get; }
        public string _model { get; set; }
        public string _color { get; set; }
        public int _numOfShelves { get; set; }
        public List<Shelf> _shelves { get; set; }

        public Refrigerator(string model, string color, int numberOfShelves)
        {
            _refrigeratorID = ++lastRefrigeratorID;
            _model = model;
            _color = color;
            _shelves = new List<Shelf>();
            _numOfShelves = numberOfShelves;
            for (int i = 0; i < numberOfShelves; i++)
            {
                Console.WriteLine("Enter the spaceInSquareMeters of the shelf:");
                string input = Console.ReadLine();
                string[] inputParts = input.Split(' ');
                if (double.TryParse(inputParts[0], out double spaceInSquareMeters))
                {
                    _shelves.Add(new Shelf(spaceInSquareMeters));
                    Console.WriteLine("Shelf added");
                }
            }
        }

        public double EmptySpaceInFridge()
        {
            double sum = 0;
            foreach (Shelf shelf in _shelves)
            {
                sum += shelf._emptySpaceOnShelf;
            }
            Console.WriteLine("The Empty Space In Fridge is: " + sum);
            return sum;
        }

        public override string ToString()
        {
            string result = $"ID: {_refrigeratorID}\n" +
                   $"NumberOfShelves: {_numOfShelves}\n" +
                   $"Model: {_model}\n" +
                   $"Color: {_color}\n";

            foreach (Shelf shelf in _shelves)
            {
                result += shelf.ToString() + "\n";
            }
            return result;
        }
        public void AddItem(Item item)
        {
            foreach (Shelf shelf in _shelves)
            {
                if(shelf._emptySpaceOnShelf >= item.LengthItem)
                {
                    shelf.Items.Add(item);
                    break;
                }
            }
        }

        public Item RemoveItemByID(int ItemID)
        {
            Item findItem=null;
            foreach (Shelf shelf in _shelves)
            {
                findItem = shelf.RemoveItemFromShelf(ItemID);
            }
            return findItem;
        }
        public void CleanFridge()
        {
            foreach (Shelf shelf in _shelves)
            {
                shelf.Items.RemoveAll(item => item.ExpiryDate <= DateTime.Today);
            }
        }
        public List<Item> whatToEat(KosherType kosher, ItemType type)
        {
            List <Item> foodInFridge=null, foodInOneShelf = null;
            CleanFridge();
            foreach (Shelf shelf in _shelves)
            {
                foodInOneShelf = shelf.Items.Where(item => item.Type == type && item.Kosher == kosher).ToList();
                foodInFridge.AddRange(foodInOneShelf);
            }
            return foodInFridge;
        }

        public List<Item> SortItemsByExpirateDate()
        {
            List<Item> allItem = new List<Item>();
            foreach (Shelf shelf in _shelves)
            {
                allItem.AddRange(shelf.Items);
            }
            return allItem.OrderBy(item => item.ExpiryDate).ToList();
        }
        public List<Shelf> SortShelvesBy
    }
}
