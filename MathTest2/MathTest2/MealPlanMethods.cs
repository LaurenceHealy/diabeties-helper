using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetiesProgram
{
    internal class MealPlanMethods
    {
        #region DisplayMenuMethod
        public static void DisplayMenu(string restName)
        {
            try
            {
                string fileDir = @"D:\Diabeties\foodmenus\";
                string upperRestName = restName.ToUpper();
                
                StreamReader menuReader = new StreamReader($"{fileDir}{restName}");
                Console.WriteLine($"==============={upperRestName}===============");
                Console.WriteLine(menuReader.ReadToEnd());
                menuReader.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region UpdateMenuWithNewItemMethod
        public static void UpdateMenuWithNewItem(string restName, MenuItem item)
        {
            try
            {
                string fileDir = @"D:\Diabeties\foodmenus\";
                if (!File.Exists($"{fileDir}{restName}"))
                {
                    Console.Clear();
                    Console.WriteLine("That menu does not exist");
                    Menu.MealPlanning();
                }
                else
                {
                    StreamWriter writer = File.AppendText($"{fileDir}{restName}");
                    writer.WriteLine("{0}, {1}", item.ItemName, item.Carbs.ToString());
                    writer.Close();
                }
                try
                {
                    Console.Clear();
                    Console.WriteLine("Updated the Menu!!  Enter another item or type end to return to previous menu.");
                    string upperRestName = restName.ToUpper();
                    Console.WriteLine($"==============={upperRestName}===============");
                    StreamReader menuReader = new StreamReader($"{fileDir}{restName}");
                    Console.WriteLine(menuReader.ReadToEnd());
                    menuReader.Close();

                    CreatMenuItem(restName);
                }
                 catch (Exception)
                {
                    string message = "Unexpected Error Returning to Main Menu";
                    Console.WriteLine(message);
                    Menu.MainScreen();
                }
            }
            catch (Exception)
            {
                string message = "Unexpected Error Returning to Main Menu";
                Console.WriteLine(message);
                Menu.MainScreen();
            }

        }
        #endregion

        #region SelectMenuToAddTooMethod
        public static void SelectMenuToAddToo()
        {
            DisplayResturauntList();
            Console.WriteLine("Please enter the name of a resturant that you want to add an item to.");

            string fileDir = @"D:\Diabeties\foodmenus\";
            string restName = Console.ReadLine();
            string lowRestName = restName.ToLower();
            if (!File.Exists($"{fileDir}{lowRestName}"))
            {
                Console.Clear();
                Console.WriteLine($"That Resturaunt doesn't exist. Would you like to create it? Type yes or no");
                string sel = Console.ReadLine();
                string lowerSel = sel.ToLower();
                if (lowerSel == "yes")
                {
                    CreateMenu(lowRestName);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please reenter resturaunt name.");
                    SelectMenuToAddToo();
                }
            }
            else
            {
                DisplayMenu(lowRestName);
                CreatMenuItem($"{restName}");
            }
        } 
        #endregion

        #region DisplayResturauntListMethod
        public static void DisplayResturauntList()
        {
            Console.WriteLine("========== RESTURAUNT LIST ==========");
            string[] fileName = Directory.GetFiles(@"D:\Diabeties\foodmenus\");
            for (int i = 0; i < fileName.Length; i++)
            {
                string path = fileName[i];
                Console.WriteLine(Path.GetFileName(path));
            }
        } 
        #endregion

        #region CreateMenuItemMethod
        static void CreatMenuItem(string restName)
        {
            string name;
            string carb;

            try
            {
                Console.WriteLine("Enter item name:");
                name = Console.ReadLine();

                while (name != "end")
                {
                    Console.WriteLine("Enter item carbohydrates;");
                    carb = Console.ReadLine();

                    MenuItem newItem = new MenuItem(name, carb);

                    UpdateMenuWithNewItem(restName, newItem); 
                }
                Console.Clear();
                Menu.MealPlanning();
            }
            catch (FormatException)
            {
                Console.Clear();
                string message = "Invalid input, please try again";
                Console.WriteLine(message);
                SelectMenuToAddToo();
            }
        }
        #endregion

        #region CreatNewMenuMethod
        public static void CreateNewMenu()
        {
            DisplayResturauntList();

            Console.WriteLine("Please enter a new resturant name.");
            string resturantName = Console.ReadLine();
            string lowerRestName = resturantName.ToLower();

            CreateMenu(lowerRestName);
        }
        public static void CreateMenu(string restName)
        {
            string fileDir = @"D:\Diabeties\foodmenus\";
            if (!File.Exists($"{fileDir}{restName}"))
            {
                string upperRestName = restName.ToUpper();
                StreamWriter newMenuWriter = new StreamWriter($"{fileDir}{restName}");
                newMenuWriter.Close();
                Console.Clear();
                Console.WriteLine($"New menu for {restName} created! Would you like to add a menu item to it? Type yes or no");
                string sel = Console.ReadLine();
                string lowerSel = sel.ToLower();
                if (lowerSel == "yes")
                {
                    Console.WriteLine($"==============={upperRestName}===============");
                    CreatMenuItem($"{restName}");
                }
                else
                {
                    Menu.MealPlanning();
                }
            }
            else
            {
                Console.WriteLine($"A menu for {restName} already exists. Would you like to add a menu item to it? Type yes or no");
                string sel = Console.ReadLine();
                string lowerSel = sel.ToLower();
                if(lowerSel == "yes")
                {
                    CreatMenuItem(restName);
                }
                else
                {
                    Menu.MealPlanning();
                }
            }
        

            Menu.MealPlanning();
        } 
        #endregion
    }
}