using System;

namespace LoanDecider
{
    public class RepaymentCalculator
    {
        const double term = 36d;

        internal static decimal GetMonthlyRate(Lender l, long requestedAmount)
        {
            double monthlyRate = 0;

            monthlyRate = (((double)l.Rate / 100d / term) * requestedAmount) /
                (1 - Math.Pow((1 + ((double)l.Rate / 100d / term)), (-term)));


            return (decimal) monthlyRate ;
        }

        internal static decimal GetTotalRepayment(Lender l, long requestedAmount)
        {
            return GetMonthlyRate(l, requestedAmount) * (decimal)term;
        }
    }
}
    

