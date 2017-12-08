using System;
using NUnit.Framework;
using LoanDecider;

namespace Tests
{
    [TestFixture]
    public class RepaymentCalculatorTests
    {

        [Test]
        public void CalculatesLoanRepaymentsWithValidInterestRate()
        {

            Assert.That(Math.Round( RepaymentCalculator.GetMonthlyRepayment(0.075, 5000),2), Is.EqualTo(155.53));
            Assert.That(Math.Round(RepaymentCalculator.GetTotalRepayment(0.075, 5000),2), Is.EqualTo(5599.12));
        }


        [Test]
        public void ThrowsExceptionsIfInterestRateIsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => RepaymentCalculator.GetMonthlyRepayment(0, 100));
            Assert.Throws<ArgumentOutOfRangeException>(() => RepaymentCalculator.GetTotalRepayment(0, 100));
        }
    }
}
