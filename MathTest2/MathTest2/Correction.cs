using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetiesProgram
{
    internal class Correction
    {
        public static void Bolus()
        {
            Console.WriteLine("==========CORRECTION BOLUS CALCULATOR==========");
            Console.WriteLine();

            try
            {
                double insulinActionTime = FileRead.ReadSetting("Insulin Action Time");
                double tarBG = FileRead.ReadSetting("Target Blood Glucose Level");
                double corFactor = FileRead.ReadSetting("Insulin Correction Factor");


                Console.WriteLine("Hour many minutes ago did you last take insulin?");
                double minutesElapsed = Convert.ToDouble(Console.ReadLine());
                double hourElapsed = minutesElapsed / 60;

                Console.WriteLine("How much insulin did you take?");
                double pastInsulinAmount = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("What is your current blood glucose level?");
                double curBG = Convert.ToDouble(Console.ReadLine());
                Warning.LowBloodSugar(curBG);



                Console.WriteLine($"Your insulin onboard is: {IOB(hourElapsed, insulinActionTime, pastInsulinAmount)} units");
                Console.WriteLine($"Your correction Bolus is: {CorrectionBolus(curBG, tarBG, corFactor)} units");

                Console.WriteLine("Press any key to return to the Main Menu");
                Console.ReadKey();
                Console.Clear();
                Menu.MainScreen();
            }
            catch (FormatException)
            {
                Console.Clear();
                string message = "Invalid entry. Please Try Again.";
                Console.WriteLine(message);
                Bolus();
            }
        }
        static double IOB(double hours, double actionTime, double prevInsulin)
        {
            double insulinActionPercent = 1 - (hours / actionTime);            
            double iob = prevInsulin * insulinActionPercent;
            return Math.Round(iob, 2);
        }      
        static double CorrectionBolus(double currentBG, double targetBG, double correctionFactor)
        {
            double correctionBG = currentBG - targetBG;
            double correctionBolus = correctionBG / correctionFactor;
            return Math.Round(correctionBolus, 2);
        }   

    }

}
