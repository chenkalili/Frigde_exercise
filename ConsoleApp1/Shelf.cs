using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;

namespace Refrigerator_exercise
{
    public class Shelf
    {
        private static int lastShelfID = 0, lastFloor=0;
        public int _shelfID { get; }
        public int _floorNumber { get; set; }
        public double _spaceOnShelf { get; set; }
        public List<Item> _items { get; set; }

        public Shelf(double emptySpace)
        {
            _shelfID = ++lastShelfID;
            _floorNumber = ++lastFloor;
            _spaceOnShelf = emptySpace;
            _items = new List<Item>();
            Init();
        }

        public void Init()
        {
            Console.WriteLine("Enter item details (productName itemShelf itemType kosherType lengthItem):");
            string input = Console.ReadLine();
            string[] inputParts = input.Split(' ');
            DateTime yourDateTime = new DateTime(2023, 10, 19, 15, 30, 0); // Year, Month, Day, Hour, Minute, Second
            if (inputParts.Length == 5 &&
                int.TryParse(inputParts[1], out int itemShelf) && Enum.TryParse(inputParts[2], out ItemType itemType) &&
                Enum.TryParse(inputParts[3], out KosherType kosherType) && double.TryParse(inputParts[4], out double lengthItem))
            // DateTime.TryParse(inputParts[4], out DateTime expiryDate) &&
            {
                _items.Add(new Item(inputParts[0], itemShelf, itemType, kosherType, yourDateTime, lengthItem));
                Console.WriteLine("Item added successfully.");
            }
        }
        public override string ToString()
        {
            string result = $"ShelfID: {_shelfID}\n" +
                   $"FloorNumber: {_floorNumber}\n" +
                   $"EmptySpaceOnShelf: {_spaceOnShelf}\n";

            foreach (Item item in _items)
            {
                result += item.ToString() + "\n";
            }
            return result;
        }
    }
}
