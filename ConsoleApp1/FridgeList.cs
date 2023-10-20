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

        public double _spaceInFridges = 0;
        public List<Fridge> _fridges { get; set; }

        public FridgeList(string listName, int numOfFridge) 
        {
            _listID = ++lastFridgeID;
            _fridges = new List<Fridge>();
            _numOfFridge = numOfFridge;
            _spaceInFridges = 15;
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
        public void AddFridge(Fridge fridge)
        {
            _fridges.Add(fridge);
        }

        public void RemoveFridgeByID(Fridge fridge)
        {
            _fridges.Remove(fridge);
        }

        public void Clear()
        {
            _fridges.Clear();
        }
        public override string ToString()
        {
            string fridgesData = $"_listID: {_listID}\n" + $"ListName: {_listName}\n" + $"NumOfFridge: {_numOfFridge}\n"  + $"SpaceInFridges: {_spaceInFridges}\n\n";
            foreach(Fridge fridge in _fridges) 
            { 
                fridgesData+= fridge.ToString()+ "\n";
            }
            return fridgesData; 
        }
    }
}
