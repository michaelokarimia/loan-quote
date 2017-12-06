using System;

namespace LoanDecider
{
    public class RepaymentCalculator
    {
        const double term = 36d;

        internal static decimal GetMonthlyRate(double rate, long requestedAmount)
        {
            double monthlyRate = 0;

            monthlyRate = ((rate / 100d / term) * requestedAmount) /
                (1 - Math.Pow((1 + (rate / 100d / term)), (-term)));


            return (decimal) monthlyRate ;
        }

        internal static decimal GetTotalRepayment(double rate, long requestedAmount)
        {
            return GetMonthlyRate(rate, requestedAmount) * (decimal)term;
        }
    }
}
    

