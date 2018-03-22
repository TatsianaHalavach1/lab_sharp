using System;

namespace TaskB
{
    class Program
    {
        static void Main(string[] args)
        {
            string lineFromConsole;
            ConsoleStringList slist = ConsoleStringList.GetInstance();
            Console.WriteLine("Input your strings or 'exit':");
            lineFromConsole = Console.ReadLine();
            while (lineFromConsole != "exit")
            {
                slist.AddStringToList(lineFromConsole);
                lineFromConsole = Console.ReadLine();
            }
            Console.WriteLine(slist.showAll());
            Console.ReadLine();
        }
    }
}
