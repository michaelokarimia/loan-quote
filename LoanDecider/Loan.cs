namespace LoanDecider
{
    public class Loan
    {
        private double rate;
        private double monthlyRepayment;
        private double totalRepayment;
        private double principal;
        private string lenderName;

        public Loan(string lenderName, double principal, double rate, double monthlyRepayment, double totalRepayment)
        {
            this.rate = rate;
            this.monthlyRepayment = monthlyRepayment;
            this.totalRepayment = totalRepayment;
            this.principal = principal;
            this.lenderName = lenderName;
        }

        public double Rate { get => rate; }
        public double MonthlyRepayment { get => monthlyRepayment;  }
        public double TotalRepayment { get => totalRepayment;  }
        public double Principal { get => principal; }
        public string Lender { get => lenderName; }
    }
}