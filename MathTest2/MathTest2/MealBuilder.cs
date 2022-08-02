using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetiesProgram
{
    internal class MealBuilder
    {
        public static void RestSelect()
        {
            Console.Clear();
            Console.WriteLine("=========MEAL BUILDER==========");
            MealPlanMethods.DisplayResturauntList();
            Console.WriteLine("Please select a resturaunt to view its menu.");
            string menuName = Console.ReadLine();
            string restName = menuName.ToLower();
            FileRead.ReadMenuToList(restName);
            
           //itemPicker()
        }
        //static void itemPicker(Array[] thing)
        //{
        //    Console.WriteLine(food[0, 2]);
        //}
    }
}
