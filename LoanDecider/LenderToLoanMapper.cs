using System.Collections.Generic;

namespace LoanDecider
{
    public class LenderToLoanMapper : ILenderToLoanMapper
    {
        public IList<Loan> Map(ILenderRepository marketDateRepository)
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

    public interface ILenderToLoanMapper
    {
        IList<Loan> Map(ILenderRepository marketDateRepository);
    }
}