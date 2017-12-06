namespace LoanDecider
{
    public class Loan
    {
        private double rate;
        private decimal monthlyRepayment;
        private decimal totalRepayment;

        public Loan(double rate, decimal monthlyRepayment, decimal totalRepayment)
        {
            this.rate = rate;
            this.monthlyRepayment = monthlyRepayment;
            this.totalRepayment = totalRepayment;
        }

        public double Rate { get => rate; }
        public decimal MonthlyRepayment { get => monthlyRepayment;  }
        public decimal TotalRepayment { get => totalRepayment;  }
    }
}