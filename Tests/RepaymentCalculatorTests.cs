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

            Assert.That(RepaymentCalculator.GetMonthlyRepayments(7.5, 2340), Is.EqualTo(67.5356190565202m));
            Assert.That(RepaymentCalculator.GetTotalRepayment(7.5, 2340), Is.EqualTo(2431.2822860347272m));
        }


        [Test]
        public void ThrowsExceptionsIfInterestRateIsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => RepaymentCalculator.GetMonthlyRepayments(0, 100));
            Assert.Throws<ArgumentOutOfRangeException>(() => RepaymentCalculator.GetTotalRepayment(0, 100));
        }
    }
}
