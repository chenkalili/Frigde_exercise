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
        public double _emptySpaceOnShelf { get; set; }
        public List<Item> Items { get; set; }

        public Shelf(double spaceInSquareMeters)
        {
            _shelfID = ++lastShelfID;
            _floorNumber = ++lastFloor;
            _emptySpaceOnShelf = spaceInSquareMeters;
            Items = new List<Item>();

            Console.WriteLine("Enter item details (productName itemShelf itemType kosherType lengthItem):");
            string input = Console.ReadLine();
            string[] inputParts = input.Split(' ');
            DateTime yourDateTime = new DateTime(2023, 10, 19, 15, 30, 0); // Year, Month, Day, Hour, Minute, Second
            if (inputParts.Length == 5 &&
                int.TryParse(inputParts[1], out int itemShelf) && Enum.TryParse(inputParts[2], out ItemType itemType) &&
                Enum.TryParse(inputParts[3], out KosherType kosherType) && double.TryParse(inputParts[4], out double lengthItem))
                // DateTime.TryParse(inputParts[4], out DateTime expiryDate) &&
            {
                Items.Add(new Item(inputParts[0], itemShelf, itemType, kosherType, yourDateTime, lengthItem));
                Console.WriteLine("Item added successfully.");
            }
        }
        public override string ToString()
        {
            string result = $"ShelfID: {_shelfID}\n" +
                   $"FloorNumber: {_floorNumber}\n" +
                   $"EmptySpaceOnShelf: {_emptySpaceOnShelf}\n";

            foreach (Item item in Items)
            {
                result += item.ToString() + "\n";
            }
            return result;
        }
        public Item RemoveItemFromShelf(int itemID)
        {
            foreach (Item item in Items)
            {
                if (item.ItemID == itemID)
                {
                    Items.Remove(item);
                    return item;
                }
            }
            return null;
        }
    }
}
