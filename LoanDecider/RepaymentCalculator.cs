using System;

namespace LoanDecider
{
    public class RepaymentCalculator
    {
        const double term = 36d;

        public static double GetMonthlyRepayment(double rate, long requestedAmount)
        {
            if(rate == 0)
            {
                throw new ArgumentOutOfRangeException("Interest rate can not be set to 0%");
            }
            double monthlyRepayment = 0;

            monthlyRepayment = ((rate / 100d / term) * requestedAmount) /
                (1 - Math.Pow((1 + (rate / 100d / term)), (-term)));

            rate = rate / 12;


           monthlyRepayment = requestedAmount * (rate + (rate / (Math.Pow(1 + rate, term) -1)));

            return monthlyRepayment ;
        }

        public static double GetTotalRepayment(double rate, long requestedAmount)
        {
            return GetMonthlyRepayment(rate, requestedAmount) * term;
        }
    }
}
    

