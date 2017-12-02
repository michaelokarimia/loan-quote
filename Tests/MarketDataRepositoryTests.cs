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
        IMarketDataRepository subject;
        Mock<ICSVParser> mockCSVParser;


        [SetUp]
        public void SetUp()
        {
            mockCSVParser = new Mock<ICSVParser>();

            subject = new MarketDataRepository(mockCSVParser.Object);
        }


        [Test]
        public void LoadsInvokesCSVParserWhenLoadingMarketDataFromCsvFile()
        {
            var filePath = new FileInfo(@"\\.\\test-market-data.csv");

            subject.Load(filePath);

            mockCSVParser.Verify(x => x.Parse(filePath), Times.Once);
        }
    }
}
