using System;
using System.Linq;

namespace LoanDecider
{
    public class LoanDeciderConsoleUI
    {

        public void Start(string[] args)      
        {
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




                    string marketData = args[0];
                    string requestStr = args[1];


                    var lenderRepo = new LenderRepository(new CSVParser(), new System.IO.FileInfo(marketData));

                    var repo = new LoanRepository(new LenderToLoanMapper(), lenderRepo);

                    long requestedLoanAmount = 0;

                    if (!long.TryParse(requestStr, out requestedLoanAmount)
                        || requestedLoanAmount % 100 != 0
                        || requestedLoanAmount < 1000
                        || requestedLoanAmount > 15000)
                    {
                        throw new ArgumentOutOfRangeException("Please request a loan of any £100 increment between £1000 and £15000 inclusive");

                    }

                    var availableLoans = repo.GetLoans(requestedLoanAmount);

                    if (availableLoans.Count > 0)
                    {

                        var bestLoan = availableLoans.First();

                        Console.WriteLine("Requested Amount £{0}", requestedLoanAmount);
                        Console.WriteLine("Rate: {0:0.0}%", bestLoan.Rate * 100);
                        Console.WriteLine("Monthly repayment: £{0:0.00}", bestLoan.MonthlyRepayment);
                        Console.WriteLine("Total repayment: £{0:0.00}", bestLoan.TotalRepayment);

                    }
                    else
                    {
                        Console.WriteLine("It is not possible to provide a quote at this time");
                    }


                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}
