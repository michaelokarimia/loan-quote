using System;

namespace LoanDecider
{
    public class RepaymentCalculator
    {
        const double term = 36d;

        public static decimal GetMonthlyRepayments(double rate, long requestedAmount)
        {
            if(rate == 0)
            {
                throw new ArgumentOutOfRangeException("Interest rate can not be set to 0%");
            }
            double monthlyRate = 0;

            monthlyRate = ((rate / 100d / term) * requestedAmount) /
                (1 - Math.Pow((1 + (rate / 100d / term)), (-term)));


            return (decimal) monthlyRate ;
        }

        public static decimal GetTotalRepayment(double rate, long requestedAmount)
        {
            return GetMonthlyRepayments(rate, requestedAmount) * (decimal)term;
        }
    }
}
    

