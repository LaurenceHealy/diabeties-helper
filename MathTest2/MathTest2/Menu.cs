using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetiesProgram
{
    internal class Menu
    {
        #region MainScreenMenuMethod
        public static void MainScreen()
        {
            Console.WriteLine("Welcome the Insulin Management Program 1.2.0");
            Console.WriteLine("Please select a number from the menu:");
            Console.WriteLine(@"
======================================
||                                  ||
||  1 - Calculate Meal Bolus        ||
||  2 - Calculate Correction Bolus  ||
||  3 - Meal Planning               ||
||  4 - User Settings               ||
||                                  ||
======================================
");
            try
            {
                int menuSelect = Convert.ToInt32(Console.ReadLine());
                switch (menuSelect)
                {
                    case 1:
                        {
                            Console.Clear();
                            Meal.Bolus();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Correction.Bolus();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            MealPlanning();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Settings();
                            break;
                        }

                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Please Select a number from the menu.");
                            MainScreen();
                            break;
                        }
                }
            }
            catch (FormatException)
            {
                Console.Clear();
                string message = "Please enter a number from the menu.";
                Console.WriteLine(message);                
                MainScreen();
            }
        }
        #endregion

        #region UserSettingsMenuMethod
        public static void Settings()
        {
            
            ViewSettings.Personal();
            Console.WriteLine();
            Console.WriteLine("==========CHANGE SETTINGS MENU==========");
            Console.WriteLine("Please select a number from the menu to adjust that setting.");
            Console.WriteLine(@"
=========================================
||                                     ||
||  1 - Target Blood Glucose Level     ||
||  2 - Low Blood Glucose Alert Level  ||
||  3 - Insulin Correction Factor      ||
||  4 - Carbohydrate Ratio             ||
||  5 - Insulin Action Time            ||
||  6 - Return to Main Menu            ||
||                                     ||
=========================================
");
            try
            {
                int menuSelect = Convert.ToInt32(Console.ReadLine());
                switch (menuSelect)
                {
                    case 1:
                        {                            
                            TextWriter.SettingInput("Target Blood Glucose Level");
                            break;
                        }
                    case 2:
                        {
                            TextWriter.SettingInput("Low Blood Glucose Alert Level");
                            break;
                        }
                    case 3:
                        {
                            TextWriter.SettingInput("Insulin Correction Factor");

                            break;
                        }
                    case 4:
                        {
                            TextWriter.SettingInput("Carbohydrate Ratio");
                            break;
                        }
                    case 5:
                        {
                            TextWriter.SettingInput("Insulin Action Time");
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            MainScreen();
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Please Select a number from the menu.");
                            Settings();
                            break;
                        }
                }
            }
            catch (FormatException)
            {
                string message = "Please enter a number from the menu";
                Console.Clear();
                Console.WriteLine(message);
                Settings();
            }
        }
        #endregion

        #region MealPlanningMenuMethod
        public static void MealPlanning()
        {
            Console.WriteLine("==========MEAL PLANNING MENU==========");
            Console.WriteLine("Please select a number from the menu to adjust that setting.");
            Console.WriteLine(@"
==================================
||                              ||
||  1 - Create Meal             ||
||  2 - Add Item to Menu        ||
||  3 - Create New Reusturaunt  || 
||  4 - Home Screen             ||
||                              ||
==================================
");
            try
            {
                int menuSelect = Convert.ToInt32(Console.ReadLine());
                switch (menuSelect)
                {
                    case 1:
                        {
                            Console.Clear();
                            MealBuilder.RestSelect();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            MealPlanMethods.SelectMenuToAddToo();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            MealPlanMethods.CreateNewMenu();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            MainScreen();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please Select a number from the menu. Press any key to continue.");
                            Console.ReadKey();
                            MealPlanning();
                            break;
                        }
                }
            }
            catch (FormatException)
            {
                string message = "Please enter a number from the menu, Press any key to Continue";
                Console.WriteLine(message);
                Console.ReadKey();
                MealPlanning();
            }
        } 
        #endregion

    }
}
