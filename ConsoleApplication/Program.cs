using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanDecider;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var application = new LoanDeciderApp();

            if (args.Length < 2)
            {
                Console.WriteLine("usage: supply two arguments: [a market_file csv file] [loan_amount]");
            }
            else
            {
                try
                {
                    if (string.IsNullOrEmpty(args[0]))
                    {
                        throw new ArgumentNullException("Please supply a valid file name for the market data CSV file");
                    }

                    if (string.IsNullOrEmpty(args[1]))
                    {
                        throw new ArgumentNullException("Please supply a valid file name for the market data CSV file and a loan amount");
                    }

                    application.Start(args[0], args[1]);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }

            Console.ReadKey();
        }
    }
}
