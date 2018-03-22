using System;
using System.Configuration;
using lib_01;

namespace app_01
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                NumberInputter inputter = NumberInputter.getInstance();
                int firstNumber = 0, secondNumber = 0;

                string readAttr = ConfigurationManager.AppSettings.Get("Read");
                switch (readAttr)
                {
                    case "file":
                        FileWorker fileWorker = FileWorker.getInstance(args[0]);
                        inputter.GetFileLine(fileWorker);
                        firstNumber = inputter.IntValue;
                        inputter.GetFileLine(fileWorker);
                        secondNumber = inputter.IntValue;
                        break;
                    case "console":
                        inputter.GetConsoleLine();
                        firstNumber = inputter.IntValue;
                        inputter.GetConsoleLine();
                        secondNumber = inputter.IntValue;
                        break;
                    default:
                        Console.WriteLine("Reading mode isn't determined");
                        break;
                }

                string calcAttr = ConfigurationManager.AppSettings.Get("Calculate");
                switch (calcAttr)
                {
                    case "method":
                        Program prog = new Program();
                        prog.Sum(firstNumber, secondNumber);
                        break;
                    case "library":
                        SimpleCalculator calculator = new SimpleCalculator(firstNumber, secondNumber);
                        calculator.DemonstrateAll();
                        break;
                    default:
                        Console.WriteLine("Calculate mode isn't determined");
                        break;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void Sum(int a, int b)
        {
            Console.WriteLine("Method: " + a + " + " + b + " = " + (a + b));
        }
    }
}
