using System;
using System.IO;

namespace LoanDecider
{
    public interface IMarketDataRepository
    {
        void Load(FileInfo filePath);
    }


    public class MarketDataRepository : IMarketDataRepository
    {
        private ICSVParser parser;

        public MarketDataRepository(ICSVParser parser)
        {
            this.parser = parser;
        }

        public void Load(FileInfo filePath)
        {
            parser.Parse(filePath);
        }

        public Loan GetLoan(long requestedAmount)
        {

            var rate = 3.56M;
            var monthlyRepayment = 450.34M;
            var totalRepayment = 732.39M;

            return new Loan(rate, monthlyRepayment, totalRepayment);
        }
    }



}