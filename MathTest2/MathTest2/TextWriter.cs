using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetiesProgram
{
    internal class TextWriter
    {
        public static void SettingInput(string setName)
        {
            try
            {
                Console.WriteLine($"Enter new value for {setName}");
                double newVal = Convert.ToDouble(Console.ReadLine());
                SettingChanger(setName, newVal);
            }
            catch (FormatException)
            {
                Console.Clear();
                string message = "Enter numbers only.";
                Console.WriteLine(message);
                Menu.Settings();
            }                       
        }
        static void SettingChanger(string setName, double num)
        {
               string fileDir = @"D:\Diabeties\settings\";

                StreamWriter setWriter = File.CreateText($"{fileDir}{setName}.txt");
                setWriter.WriteLine(num);
                setWriter.Close();

                Console.Clear();
                Console.WriteLine($"Value for {setName} has been changed to {num}");
                Menu.Settings();           
            
        }

    }
}
