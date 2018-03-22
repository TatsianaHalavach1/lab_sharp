using System;

namespace app_01
{
    class NumberInputter
    {
        string CurrentLine { get; set; }
        public int IntValue  { get; private set; }//int value matching to current line

        //Singleton realization
        private static NumberInputter instance;
        private NumberInputter(){}
        public static NumberInputter getInstance()
        {
            if (instance == null)
                instance = new NumberInputter();
            return instance;
        }
        //Reading 1 line from console
        public void GetConsoleLine()
        {
            Console.WriteLine("Input number:");
            CurrentLine = Console.ReadLine();
            ConvertLineToInt();
        }
        //Reading 1 line from file
        public void GetFileLine(FileWorker fileWorker)
        {
            CurrentLine = fileWorker.ReadNextLine();
            ConvertLineToInt();
        }

        //Converting to int
        public void ConvertLineToInt()
        {
            if (Int32.TryParse(CurrentLine, out int number))
            {
                IntValue = number;
            }
            else
                throw new FormatException();
        }
    }
}
