using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetiesProgram
{
    internal class Warning
    {
        #region BGLowLevelAlertMethod
        public static void LowBloodSugar(double currentBG)
        {
            if (currentBG <= FileRead.ReadSetting("Low Blood Glucose Alert Level"))
            {
                Console.WriteLine(@"
**************************************************
=====================WARNING======================
**************************************************
");
                Console.WriteLine();
                Console.WriteLine("Correct Low Blood Glucos Level Before Bolusing");
                Console.WriteLine("Press any key to return to the Main Menu");
                Console.ReadKey();
                Console.Clear();
                Menu.MainScreen();
            }
        } 
        #endregion
    }
}
