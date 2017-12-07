using System.Collections.Generic;
using System.Linq;

namespace LoanDecider
{
    public class LoanRepository : ILoanRepository
    {
        private IList<Loan> loans;

        public LoanRepository(ILenderToLoanMapper marketDataMapper, ILenderRepository marketDateRepository)
        {
            loans = marketDataMapper.Map(marketDateRepository);
        }

        public IList<Loan> GetLoans(long requestedAmount)
        {
            IList<Loan> loansForCustomer = new List<Loan>();

            var loans = this.loans.Where(x => x.Principal >= requestedAmount);

            foreach (Loan l in loans)
            {

                loansForCustomer.Add(new Loan(l.Lender,
                    l.Principal,
                    l.Rate,
                    RepaymentCalculator.GetMonthlyRepayments(l.Rate, requestedAmount),
                    RepaymentCalculator.GetTotalRepayment(l.Rate, requestedAmount)));
            }


            return loansForCustomer;
        }
    }
        public interface ILoanRepository
        {
            IList<Loan> GetLoans(long requestedAmount);
        }
    
}
    

