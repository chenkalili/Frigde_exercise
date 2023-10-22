using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator_exercise
{
    public class FridgeList
    {
        private static int lastFridgeID = 0;
        public int _listID { get; }
        public string _listName { get; set; }
        public int _numOfFridge { get; set; }
        public double _spaceInFridges { get; set; }
        public List<Fridge> _fridges { get; set; }
       
        public FridgeList(string listName, int numOfFridge) 
        {
            _listID = ++lastFridgeID;
            _spaceInFridges = 0;
            _fridges = new List<Fridge>();
            _numOfFridge = numOfFridge;
            _listName = listName;
        }

        public void SortFridgesBySpace()
        {
            List<Fridge> sortFridges = _fridges.OrderBy(fridge => fridge._spaceInFridge).ToList();
            foreach (Fridge fridge in sortFridges)
            {
                fridge.PrintFridge();
            }
        }
        public void AddFridge(Fridge newFridge)
        {
            _fridges.Add(newFridge);
        }
        public override string ToString()
        {
            string fridgesData = $"listID: {_listID}\n" + $"ListName: {_listName}\n" + $"NumOfFridge: {_numOfFridge}\n"  + $"SpaceInFridges: {_spaceInFridges}\n\n";
            foreach(Fridge fridge in _fridges) 
            { 
                fridgesData+= fridge.ToString()+ "\n";
            }
            return fridgesData; 
        }

        public void SpaceInFridges()
        {
            foreach(Fridge fridge in _fridges)
            {
                _spaceInFridges += fridge._spaceInFridge;
            }

            Console.WriteLine($"Space in fridges: {_spaceInFridges}");
        }

        public void RemoveFridge()
        {
            try
            {
                Console.Write("Enter the fridgeId to remove: ");
                if (int.TryParse(Console.ReadLine(), out int fridgeID))
                {
                    Fridge fridgeToRemove = _fridges.FirstOrDefault(f => f._fridgeID == fridgeID);
                    if (fridgeToRemove != null)
                    {
                        _fridges.Remove(fridgeToRemove);
                        _spaceInFridges += fridgeToRemove._spaceInFridge;
                        Console.WriteLine("The fridge has been successfully removed\n");
                    }
                    else
                    {
                        throw new Exception("Fridge not found for the specified ID.");
                    }
                }
                else
                {
                    throw new Exception("Invalid input for fridge ID. Please enter a valid integer.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        public void MenuForOneFridge()
        {
            OneFridgeMenu oneFridgeMenu = new OneFridgeMenu();
            try
            {
                Console.Write("Enter the fridgeId: ");
                if (int.TryParse(Console.ReadLine(), out int fridgeID))
                {
                    Fridge fridge = _fridges.FirstOrDefault(f => f._fridgeID == fridgeID);
                    if (fridge != null)
                    {
                        oneFridgeMenu.ConsoleOneFridge(fridge);
                    }
                    else
                    {
                        throw new Exception("Fridge not found for the specified ID.");
                    }
                }
                else
                {
                    throw new Exception("Invalid input for fridge ID. Please enter a valid integer.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void AddFridge()
        {
            try
            {
                Console.Write("Enter model, color, and number of shelves (separated by spaces): ");
                string[] inputs = Console.ReadLine().Split(' ');
                string model = inputs[0];
                string color = inputs[1];
                if (!int.TryParse(inputs[2], out int numberOfShelves))
                {
                    throw new ApplicationException("Invalid input or user exclusion based on input criteria.");
                }

                _fridges.Add(new Fridge(model, color, numberOfShelves));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
