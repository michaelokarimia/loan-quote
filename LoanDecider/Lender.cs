namespace LoanDecider
{
    public class Lender
    {
        private string name;
        private double rate;
        private double amount;

        public Lender(string name, double rate, double amount)
        {
            this.name = name;
            this.rate = rate;
            this.amount = amount;
        }

        public double Amount { get => amount; }
        public double Rate { get => rate; }
    }
}