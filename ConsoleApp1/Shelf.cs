using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigerator_exercise
{
    public class Shelf
    {
        private static int lastShelfID = 0;

        public int ShelfID { get; }
        public int FloorNumber { get; set; }
        public double SpaceInSquareMeters { get; set; }
        public List<Item> Items { get; set; }

        public Shelf(int floorNumber, double spaceInSquareMeters)
        {
            ShelfID = ++lastShelfID;
            FloorNumber = floorNumber;
            SpaceInSquareMeters = spaceInSquareMeters;
            Items = new List<Item>();
        }
    }
}
