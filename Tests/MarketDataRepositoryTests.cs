using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LoanDecider;
using System.IO;
using Moq;

namespace Tests
{
    [TestFixture]
    public class MarketDataRepositoryTests
    {
        MarketDataRepository subject;
        Mock<ICSVParser> mockCSVParser;
        IList<Lender> lendersData;
        FileInfo filePath;

        [SetUp]
        public void SetUp()
        {
            mockCSVParser = new Mock<ICSVParser>();
           

            lendersData = new List<Lender>
            {
               new Lender( "Bob",0.075M,640),
               new Lender("Jane",0.069M,480),

            };

            mockCSVParser.Setup(x => x.Parse(It.IsAny<FileInfo>())).Returns(lendersData);

            subject = new MarketDataRepository(mockCSVParser.Object);
        }


        [Test]
        public void LoadsInvokesCSVParserWhenLoadingMarketDataFromCsvFile()
        {
            filePath = new FileInfo("test-market-data.csv");

            subject.Load(filePath);

            mockCSVParser.Verify(x => x.Parse(filePath), Times.Once);
        }

        [Test]
        public void ReturnsAvailableLoanWhenLendersAreSufficient()
        {

            subject.Load(filePath);

            long requestedAmount = 500;

            var loan = subject.GetLoan(requestedAmount);

            Assert.That(loan.Rate, Is.EqualTo(3.05M));
            Assert.That(loan.MonthlyRepayment, Is.EqualTo(400.26M));
            Assert.That(loan.TotalRepayment, Is.EqualTo(780.32M));

            


        }





    }
}
