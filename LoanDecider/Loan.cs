namespace LoanDecider
{
    public class Loan
    {
        private decimal rate;
        private decimal monthlyRepayment;
        private decimal totalRepayment;

        public Loan(decimal rate, decimal monthlyRepayment, decimal totalRepayment)
        {
            this.rate = rate;
            this.monthlyRepayment = monthlyRepayment;
            this.totalRepayment = totalRepayment;
        }

        public decimal Rate { get => rate; }
        public decimal MonthlyRepayment { get => monthlyRepayment;  }
        public decimal TotalRepayment { get => totalRepayment;  }
    }
}