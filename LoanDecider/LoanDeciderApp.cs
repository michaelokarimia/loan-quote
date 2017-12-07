using System;
using System.Linq;

namespace LoanDecider
{
    public class LoanDeciderApp
    {

        public void Start(string marketData, string requestStr)
        {

            var lenderRepo = new LenderRepository(new CSVParser());

            lenderRepo.Load(new System.IO.FileInfo(marketData));

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

                Console.WriteLine("Requested Amount {0}", requestedLoanAmount);
                Console.WriteLine("Rate: {0:0.0}%", bestLoan.Rate * 100);
                Console.WriteLine("Monthly repayment: £{0:0.00}", bestLoan.MonthlyRepayment);
                Console.WriteLine("Total repayment: £{0:0.00}", bestLoan.TotalRepayment);

            }
            else
            {
                Console.WriteLine("It is not possible to provide a quote at that time");
            }

        }
    }
}
