using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigerator_exercise
{
    class Program
    {
        static void Main()
        {
            //DateTime yourDateTime = new DateTime(2023, 10, 19, 15, 30, 0);
            Console.WriteLine("Enter the model, color, and capacity of the refrigerator (separated by spaces):");
            string input = Console.ReadLine();
            string[] inputParts = input.Split(' ');
            string model = inputParts[0];
            string color = inputParts[1];
            if (int.TryParse(inputParts[2], out int capacity))
            {
                Refrigerator myObject = new Refrigerator(model, color, capacity);
                //Item it= new Item("cola",1,ItemType.Drink,KosherType.Dairy, yourDateTime,2);
                //myObject.AddItem(it);
                Console.WriteLine(myObject.ToString());
            }
        }
    }
}
