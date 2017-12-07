using System.Collections.Generic;

namespace LoanDecider
{
    public interface IMarketDataToLoansMapper
    {
        IList<Loan> Map(IMarketDataRepository marketDateRepository);
    }

    public class MarketDataToLoansMapper : IMarketDataToLoansMapper
    {
        public IList<Loan> Map(IMarketDataRepository marketDateRepository)
        {
            var loans = new List<Loan>();

            var lenders = marketDateRepository.Get();

            foreach (var l in lenders)
            {
                loans.Add(new Loan(l.Name, l.Amount, l.Rate, 0, 0));
            }

            return loans;
        }
    }
}