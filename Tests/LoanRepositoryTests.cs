using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using LoanDecider;
using Moq;

namespace Tests
{
    [TestFixture]
    public class LoanRepositoryTests
    {
        private LoanRepository subject;
        private Mock<MarketToLenderMapper> mockMarketToLenderMapper = new Mock<MarketToLenderMapper>();
        private Mock<IMarketDataRepository> mockMarketData = new Mock<IMarketDataRepository>();

        [SetUp]
        public void Setup()
        {
            var lenderList = new List<Lender>
            {
                new Lender("Bob", 5.0, 400),
                new Lender("Jane", 6.5, 750),
                new Lender("Rita", 4.5, 350),

            };

            mockMarketToLenderMapper.Setup(x => x.Map(It.IsAny<IMarketDataRepository>())).Returns(lenderList);


            subject = new LoanRepository(mockMarketToLenderMapper.Object, mockMarketData.Object);

            mockMarketToLenderMapper.Verify(x => x.Map(It.IsAny<IMarketDataRepository>()), Times.Once);


        }

        [Test]
        public void ReturnsALoanWhenLenderCanSupplyTheRequestedAmount()
        {
            long requestedAmount = 500;

            var loans = subject.GetLoans(requestedAmount);

            Assert.That(loans.Count > 0);

            var loan = loans.First();

            Assert.That(loan.Rate, Is.EqualTo(6.5));
            Assert.That(loan.MonthlyRepayment, Is.EqualTo(14.357697881845));
            Assert.That(loan.TotalRepayment, Is.EqualTo(516.87712374642));
        }
    }
}
    

