using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigerator_exercise
{
    public class Refrigerator
    {
        public int RefrigeratorID { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int NumberOfShelves { get; set; }
        public List<Shelf> Shelves { get; set; }

        public Refrigerator(string model, string color, int numberOfShelves)
        {
            Model = model;
            Color = color;
            NumberOfShelves = numberOfShelves;
            Shelves = new List<Shelf>();
        }
    }
}
