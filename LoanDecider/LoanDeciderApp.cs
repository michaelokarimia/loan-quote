using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanDecider
{
    public class LoanDeciderApp
    {

        public void Start(string marketData, string requestStr)
        {

            var lenderRepo = new LenderRepository(new CSVParser());

            lenderRepo.Load(new System.IO.FileInfo(@"C:\code\LoanDecider\ConsoleApplication\market-data.csv"));

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
                Console.WriteLine("Best loans is {0}", availableLoans[0].Lender);
            }
            else
            {
                Console.WriteLine("It is not possible to provide a quote at that time");
            }

            Console.ReadKey();
        }
    }
}
