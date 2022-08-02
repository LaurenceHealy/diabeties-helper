using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetiesProgram
{
    internal class ViewSettings
    {
        public static void Personal()
        {
            Console.WriteLine("==========USER SETTINGS==========");

            string targetBGLevel = "Target Blood Glucose Level";
            string lowLevelAlert = "Low Blood Glucose Alert Level";
            string carbRatio = "Carbohydrate Ratio";
            string correctionFactor = "Insulin Correction Factor";
            string insulinActionTime = "Insulin Action Time";

            Console.Write("Target Blood Glucose Level: "); DisplaySetting(targetBGLevel);
            Console.WriteLine();
            Console.Write("Low Blood Glucose Alarm Level: "); DisplaySetting(lowLevelAlert);
            Console.WriteLine();
            Console.Write("Insulin Correction Factor: "); DisplaySetting(correctionFactor);
            Console.WriteLine();
            Console.Write("Carbohydrate Ratio: "); DisplaySetting(carbRatio);
            Console.WriteLine();            
            Console.Write("Insulin Action Time: "); DisplaySetting(insulinActionTime);
        }
        static void DisplaySetting(string setName)
        {
            try
            {
                string fileDir = @"D:\Diabeties\settings\";

                StreamReader setReader = new StreamReader($"{fileDir}{setName}.txt");
                Console.WriteLine(setReader.ReadLine());
                setReader.Close();
               
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

    }
}
