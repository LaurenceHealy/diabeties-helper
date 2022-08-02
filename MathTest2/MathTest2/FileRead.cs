using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DiabetiesProgram
{
    internal class FileRead
    {
        public static double ReadSetting(string setName)
        {
            string fileDir = @"D:\Diabeties\settings\";

            StreamReader settingReader = new StreamReader($"{fileDir}{setName}.txt");
            string settingValue = settingReader.ReadLine();
            settingReader.Close();

            double value = Convert.ToDouble(settingValue);
            return value;
        }
        public static void ReadMenuToList(string restName)
        {
            
            string filePath = @"D:\Diabeties\foodmenus\";
            string upperRestName = restName.ToUpper();          
            Console.WriteLine($"==============={upperRestName}===============");

            //SortedList<int, string> lines = new SortedList<int, string>();
            SortedList<int, MenuItem> food = new SortedList<int, MenuItem>();
            string[] things = File.ReadAllLines($"{filePath}{restName}");
            int i = 0;
            
            foreach (string thing in things)
            {
                i++;
                string[] items = thing.Split(',');
                MenuItem f = new MenuItem(items[0], items[1]);
                food.Add(i, f);
            }
            foreach ( KeyValuePair<int, MenuItem> kvp in food )
            {
                Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
            }
            CarbAdder();
            
            int CarbAdder()
            {
                Console.WriteLine("Use item numbers to selece a food to add to meal.");
                int c = Convert.ToInt32(Console.ReadLine());

                int total = 0;
                while (c != 99)
                {
                    var carbs = food[c].ToString();
                    var carbohydrate = Regex.Match(carbs, @"\d+\.*\d*").Value;
                    int carbos = Convert.ToInt32(carbohydrate);
                    total = total + carbos;
                    Console.WriteLine(total);
                    Console.WriteLine("Select another menu item, or enter 99 to exit");
                    c = Convert.ToInt32(Console.ReadLine());
                }
                
                int mealTotal = total;

                Console.WriteLine("Do you want to calculate a meal bolus for  carbs? 1 - Yes,  2 - No");
                int picker = Convert.ToInt32(Console.ReadLine());
                switch (picker)
                {
                    case 1:
                        Console.Clear();
                        Meal.Bolus(mealTotal);
                        break;
                    case 2:
                        Console.Clear();
                        Menu.MealPlanning();
                        break;
                    default:
                        Console.WriteLine("Please enter 1 for Yes, or 2 for NO.");
                        break;

                }
                return total;
            }
            




            

           
        }
        

    }
}
