namespace LoanDecider
{
    public class Lender
    {
        private string name;
        private decimal rate;
        private long amount;

        public Lender(string name, decimal rate, long amount)
        {
            this.name = name;
            this.rate = rate;
            this.amount = amount;
        }
    }
}