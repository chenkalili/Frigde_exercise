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
        public int _itemID { get; }
        public string _productName { get; set; }
        public int _itemShelf { get; set; }
        public ItemType _type { get; set; }
        public KosherType _kosher { get; set; }
        public DateTime _expiryDate { get; set; }
        public double _lengthItem { get; set; }

        public Item(string productName, ItemType type, KosherType kosher, DateTime expiryDate, double lengthItem)
        {
            _itemID = ++lastItemID; ;
            _productName = productName;
            _type = type;
            _kosher = kosher;
            _expiryDate = expiryDate;
            _lengthItem = lengthItem;
        }
        public override string ToString()
        {
            return $"ItemID: {_itemID}\n" +
                   $"ProductName: {_productName}\n" +
                   $"ItemShelf: {_itemShelf}\n" +
                   $"Type: {_type}\n"+
                   $"Kosher: {_kosher}\n" +
                   $"ExpiryDate: {_expiryDate}\n" +
                   $"LengthItem: {_lengthItem}\n";
        }
    }

    public enum ItemType
    {
        FOOD,
        DRINK
    }

    public enum KosherType
    {
        MEAT,
        DARIY,
        PARVE
    }
}