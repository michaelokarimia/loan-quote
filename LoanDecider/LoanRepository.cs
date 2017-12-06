using System.Collections.Generic;
using System.Linq;

namespace LoanDecider
{
    public class LoanRepository : ILoanRepository
    {
        private IList<Lender> lenders;

        public LoanRepository(MarketToLenderMapper marketDataMapper, IMarketDataRepository marketDateRepository)
        {
            lenders = marketDataMapper.Map(marketDateRepository);
        }

        public IList<Loan> GetLoans(long requestedAmount)
        {
            IList<Loan> loansForCustomer = new List<Loan>();

            var validLenders = lenders.Where(x => x.Amount >= requestedAmount);

            foreach (Lender l in validLenders)
            {
                double rate = (double)l.Rate;

                loansForCustomer.Add(new Loan(rate,
                    RepaymentCalculator.GetMonthlyRate(rate, requestedAmount),
                    RepaymentCalculator.GetTotalRepayment(rate, requestedAmount)));
            }


            return loansForCustomer;
        }
    }
        public interface ILoanRepository
        {
            IList<Loan> GetLoans(long requestedAmount);
        }
    
}
    

