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

            //assumes that there is a one to one relationship between lenders and loans.
            //Does NOT pool together lenders sums into a single loan.
            var loans = this.loans.Where(x => x.Principal >= requestedAmount);

            foreach (Loan l in loans)
            {

                loansForCustomer.Add(
                    new Loan(l.Lender,
                            l.Principal,
                            l.Rate,
                            RepaymentCalculator.GetMonthlyRepayment(l.Rate, requestedAmount),
                            RepaymentCalculator.GetTotalRepayment(l.Rate, requestedAmount)));
            };

            //cheapest loans at the start of the list
            return loansForCustomer.OrderBy(x => x.Rate).ToList();
        }
    }
        public interface ILoanRepository
        {
            IList<Loan> GetLoans(long requestedAmount);
        }
    
}
    

