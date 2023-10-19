using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;

namespace Refrigerator_exercise
{
    public class Item
    {
        private static int lastItemID = 0;

        public int ItemID { get; }
        public string ProductName { get; set; }
        public int ItemShelf { get; set; }
        public ItemType Type { get; set; }
        public KosherType Kosher { get; set; }
        public DateTime ExpiryDate { get; set; }
        public double LengthItem { get; set; }

        public Item(string productName, int itemShelf, ItemType type, KosherType kosher, DateTime expiryDate, double lengthItem)
        {
            ItemID = ++lastItemID; ;
            ProductName = productName;
            ItemShelf = itemShelf;
            Type = type;
            Kosher = kosher;
            ExpiryDate = expiryDate;
            LengthItem = lengthItem;
        }
        public override string ToString()
        {
            return $"ItemID: {ItemID}\n" +
                   $"ProductName: {ProductName}\n" +
                   $"ItemShelf: {ItemShelf}\n" +
                   $"Type: {Type}\n"+
                   $"Kosher: {Kosher}\n" +
                   $"ExpiryDate: {ExpiryDate}\n" +
                   $"LengthItem: {LengthItem}\n";
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