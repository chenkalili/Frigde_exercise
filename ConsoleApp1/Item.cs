using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigerator_exercise
{
    public class Item
    {
        public int ItemID { get; }
        public string ProductName { get; set; }
        public Shelf ItemShelf { get; set; }
        public ItemType Type { get; set; }
        public KosherType Kosher { get; set; }
        public DateTime ExpiryDate { get; set; }
        public double SpaceInSquareMeters { get; set; }

        public Item(string productName, Shelf itemShelf, ItemType type, KosherType kosher, DateTime expiryDate, double spaceInSquareMeters)
        {
            ProductName = productName;
            ItemShelf = itemShelf;
            Type = type;
            Kosher = kosher;
            ExpiryDate = expiryDate;
            SpaceInSquareMeters = spaceInSquareMeters;
        }
    }

    public enum ItemType
    {
        Food,
        Drink
    }

    public enum KosherType
    {
        Meat,
        Dairy,
        Pareve
    }

}