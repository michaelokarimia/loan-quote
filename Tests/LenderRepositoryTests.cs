﻿using System.Collections.Generic;
using NUnit.Framework;
using LoanDecider;
using System.IO;
using Moq;

namespace Tests
{
    [TestFixture]
    public class LenderRepositoryTests
    {
        LenderRepository subject;
        Mock<ICSVParser> mockCSVParser;
        IList<Lender> lendersData;
        FileInfo filePath;

        [SetUp]
        public void SetUp()
        {
            mockCSVParser = new Mock<ICSVParser>();
           

            lendersData = new List<Lender>
            {
               new Lender( "Bob",0.075,640),
               new Lender("Jane",0.069,480),

            };

            mockCSVParser.Setup(x => x.Parse(It.IsAny<FileInfo>())).Returns(lendersData);

            filePath = new FileInfo("test-market-data.csv");


            subject = new LenderRepository(mockCSVParser.Object, filePath);

            mockCSVParser.Verify(x => x.Parse(filePath), Times.Once);

        }
        
    }
}
