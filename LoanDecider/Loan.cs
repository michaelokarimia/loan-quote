namespace LoanDecider
{
    public class Loan
    {
        private double rate;
        private decimal monthlyRepayment;
        private decimal totalRepayment;
        private double principal;
        private string lenderName;

        public Loan(string lenderName, double principal, double rate, decimal monthlyRepayment, decimal totalRepayment)
        {
            this.rate = rate;
            this.monthlyRepayment = monthlyRepayment;
            this.totalRepayment = totalRepayment;
            this.principal = principal;
            this.lenderName = lenderName;
        }

        public double Rate { get => rate; }
        public decimal MonthlyRepayment { get => monthlyRepayment;  }
        public decimal TotalRepayment { get => totalRepayment;  }
        public double Principal { get => principal; }
        public string Lender { get => lenderName; }
    }
}