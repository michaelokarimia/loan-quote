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
        private Mock<ILenderToLoanMapper> mockMarketToLenderMapper = new Mock<ILenderToLoanMapper>();
        private Mock<ILenderRepository> mockMarketData = new Mock<ILenderRepository>();

        [SetUp]
        public void Setup()
        {
            var availableLoans = new List<Loan>
            {
                new Loan("Bob", 500, 5.6, 0, 0),
                new Loan("Jane", 250, 2.6, 0, 0),
                new Loan("Sara", 490, 7.6, 0, 0),
                
            };
                
            mockMarketToLenderMapper.Setup(x => x.Map(It.IsAny<ILenderRepository>())).Returns(availableLoans);

            subject = new LoanRepository(mockMarketToLenderMapper.Object, mockMarketData.Object);
        }

        [Test]

        public void MapperIsCalled()
        {
            mockMarketToLenderMapper.Verify(x => x.Map(It.IsAny<ILenderRepository>()), Times.Once);

            subject.GetLoans(100);
        }


        [Test]
        public void ReturnsALoanWhenLenderCanSupplyTheRequestedAmount()
        {
            long requestedAmount = 500;

            var loans = subject.GetLoans(requestedAmount);

            Assert.That(loans.Count > 0);

            var loan = loans.First();

            Assert.That(loan.Rate, Is.EqualTo(5.6d));
            Assert.That(loan.Principal, Is.EqualTo(500));
            Assert.That(loan.Lender, Is.EqualTo("Bob"));
        }

        [Test]
        public void ReturnsEmptyListOfLoansWhenNoLenderCanLendtheRequestedAmount()
        {
            long requestedAmount = 1000;

            var loans = subject.GetLoans(requestedAmount);

            Assert.That(loans.Count == 0);
        }
    }
}
    

