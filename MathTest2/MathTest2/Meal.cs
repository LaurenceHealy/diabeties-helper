using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetiesProgram
{
    internal class Meal
    {

        public static void Bolus()
        {
            
            Console.WriteLine("==========MEAL BOLUS CALCULATOR==========");
            Console.WriteLine();

            try
            {
                double carRat = FileRead.ReadSetting("Carbohydrate Ratio");
                double tarBG = FileRead.ReadSetting("Target Blood Glucose Level");
                double corFac = FileRead.ReadSetting("Insulin Correction Factor");

                Console.WriteLine("What is your current blood glucose level?");
                double curBG = Convert.ToDouble(Console.ReadLine());
                Warning.LowBloodSugar(curBG);

                double bgCorr = curBG - tarBG;

                double carbTotal = CarbTotal();
                Console.WriteLine($"Carb total is: {carbTotal}, and your mealtime bolus is: {MealInsulin(carbTotal, carRat, corFac, bgCorr)}, units");
                CorrectionDeclaration(corFac, bgCorr);

                Console.WriteLine();
                Console.WriteLine("Press any key to return to the Main Menu");
                Console.ReadKey();
                Console.Clear();
                Menu.MainScreen();
            }
            catch (FormatException)
            {
                Console.Clear();
                string message = "Invalid entry. Please Try Again. Press any key to continue.";
                Console.WriteLine(message);
                Bolus();
            }
        }
        static double CarbTotal()
        {
            double total = 0;

            Console.WriteLine("Enter Carbs for first meal item");
            double carbs = Convert.ToDouble(Console.ReadLine());

            while (carbs != 999)
            {
                total = total + carbs;
                Console.WriteLine("Enter another food item's carbs or enter 999 to complete list.");
                carbs = Convert.ToDouble(Console.ReadLine());
            }
            return total;
        }
      

        public static void Bolus(int mealCarb)
        {

            Console.WriteLine("==========MEAL BOLUS CALCULATOR==========");
            Console.WriteLine();

            try
            {
                double carRat = FileRead.ReadSetting("Carbohydrate Ratio");
                double tarBG = FileRead.ReadSetting("Target Blood Glucose Level");
                double corFac = FileRead.ReadSetting("Insulin Correction Factor");

                Console.WriteLine("What is your current blood glucose level?");
                double curBG = Convert.ToDouble(Console.ReadLine());
                Warning.LowBloodSugar(curBG);

                double bgCorr = curBG - tarBG;

                double carbTotal = Convert.ToDouble(mealCarb);
                Console.WriteLine($"Carb total is: {carbTotal}, and your mealtime bolus is: {MealInsulin(carbTotal, carRat, corFac, bgCorr)}, units");
                CorrectionDeclaration(corFac, bgCorr);

                Console.WriteLine();
                Console.WriteLine("Press any key to return to the Main Menu");
                Console.ReadKey();
                Console.Clear();
                Menu.MainScreen();
            }
            catch (FormatException)
            {
                Console.Clear();
                string message = "Invalid entry. Please Try Again. Press any key to continue.";
                Console.WriteLine(message);
                Bolus();
            }
        }
        
        static double MealInsulin(double total, double carbRatio, double correctionFactor, double bgCorrect)
        {
            double correctionBolus = bgCorrect / correctionFactor;

            double insulinNeeded = (total / carbRatio) + correctionBolus;
            return Math.Round(insulinNeeded, 2);
        }
        static void CorrectionDeclaration(double correctionFactor, double bgCorrect)
        {
            double correctionBolus = bgCorrect / correctionFactor;

            if (correctionBolus < 0)
            {
                Console.WriteLine($"Your meal bolus was decrease by {-1 * Math.Round(correctionBolus, 2)} units, due to below target blood glucose level.");
            }
            else if (correctionBolus > 0)
            {
                Console.WriteLine($"Your meal bolus was increased by {Math.Round(correctionBolus, 2)} units, due to above target blood glucose level.");
            }
            else
            {
                Console.WriteLine(" Your meal bolus was not adjusted because you are at target blood glucose level");
            }
        }


    }
}
