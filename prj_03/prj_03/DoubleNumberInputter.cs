using System;

namespace lib_Equation
{
    static class DoubleNumberInputter
    {
        public static double ReadNumberFromConsole(LogFileWriter logWriter)
        {
            string stringForParse;
            double numberAfterParse;
            Console.WriteLine("Input double coefficient:");
            stringForParse = Console.ReadLine();
            while (!double.TryParse(stringForParse.Replace(',', '.'), out numberAfterParse))
            {
                Console.WriteLine("Incorrect coefficient! Try again:");
                logWriter.WriteIncorrectDataToLog(stringForParse);
                stringForParse = Console.ReadLine();
            }
            return numberAfterParse;
        }
        public static void ReadNumberNotZero(ref double x, LogFileWriter logWriter)
        {
            if (x == 0)
            {
                Console.WriteLine("Incorrect data: leading coefficient = 0! Try again:");
                logWriter.WriteIncorrectDataToLog("leading coefficient = " + x.ToString());
                x = DoubleNumberInputter.ReadNumberFromConsole(logWriter);
            }
        }
    }
}
