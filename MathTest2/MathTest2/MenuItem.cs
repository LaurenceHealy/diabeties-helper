using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetiesProgram
{
    internal class MenuItem
    {
        private string _itemName;
        private string _carbs;

        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }
        public string Carbs
        {
            get { return _carbs; }
            set { _carbs = value; }
        }

        public MenuItem(string itemName, string carbs)
        {
            _itemName = itemName;
            _carbs = carbs;
        }

        public override string ToString()
        {
            return ItemName + Carbs;
        }
    }
}

