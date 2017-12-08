using System;
using LoanDecider;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var application = new LoanDeciderConsoleUI();

            application.Start(args);
           

            Console.ReadKey();
        }
    }
}
