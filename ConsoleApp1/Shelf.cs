using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;

namespace Refrigerator_exercise
{
    public class Shelf
    {
        private static int lastShelfID = 0;
        public int _shelfID { get; }
        public int _floorNumber { get; set; }
        public double _spaceOnShelf { get; set; }
        public List<Item> _items { get; set; }


        const double SPACE = 15;

        public Shelf(int floorIndex)
        {
            _shelfID = ++lastShelfID;
            _floorNumber = floorIndex;
            _spaceOnShelf = SPACE;
            _items = new List<Item>();
        }

        public override string ToString()
        {
            string result = $"ShelfID: {_shelfID}\n" +
                   $"FloorNumber: {_floorNumber}\n" +
                   $"EmptySpaceOnShelf: {_spaceOnShelf}\n\n";

            foreach (Item item in _items)
            {
                result += item.ToString() + "\n";
            }
            return result;
        }
    }
}
