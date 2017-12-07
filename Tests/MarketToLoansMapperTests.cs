using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using LoanDecider;

namespace Tests
{
    [TestFixture]
    public class MarketToLoansMapperTests
    {
        IMarketDataToLoansMapper subject;

        [SetUp]
        public void Setup()
        {
            subject = new MarketDataToLoansMapper();
        }


        [Test]
        public void CanMapMarketDataToLoans()
        {
            var lenderList = new List<Lender>
            {
                new Lender("Bob", 5.0, 400),
                new Lender("Jane", 6.5, 750),
                new Lender("Rita", 4.5, 350),

            };



            Mock<IMarketDataRepository> mockmarketDateRepository = new Mock<IMarketDataRepository>();

            mockmarketDateRepository.Setup(x => x.Get()).Returns(lenderList);

            
            var results = subject.Map(mockmarketDateRepository.Object);

            Assert.AreEqual(results[0].Principal, 400);
            Assert.AreEqual(results[0].Rate, 5.0);
            Assert.AreEqual(results[0].Lender, "Bob");
        }
    }

    
}
