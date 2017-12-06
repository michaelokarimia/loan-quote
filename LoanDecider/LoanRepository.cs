using System.Collections.Generic;
using System.Linq;

namespace LoanDecider
{
    public class LoanRepository : ILoanRepository
    {
        private IList<Lender> lenders;

        public LoanRepository(IMarketToLenderMapper marketDataMapper, IMarketDataRepository marketDateRepository)
        {
            lenders = marketDataMapper.Map(marketDateRepository);
        }

        public IList<Loan> GetLoans(long requestedAmount)
        {
            IList<Loan> loansForCustomer = new List<Loan>();

            var validLenders = lenders.Where(x => x.Amount >= requestedAmount);

            foreach (Lender l in validLenders)
            {
                loansForCustomer.Add(new Loan(l.Rate,
                    RepaymentCalculator.GetMonthlyRate(l, requestedAmount),
                    RepaymentCalculator.GetTotalRepayment(l, requestedAmount)));
            }


            return loansForCustomer;
        }
    }
        public interface ILoanRepository
        {
            IList<Loan> GetLoans(long requestedAmount);
        }
    
}
    

