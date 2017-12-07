using System;
using System.Collections.Generic;
using System.IO;

namespace LoanDecider
{
    public interface IMarketDataRepository
    {
        void Load(FileInfo filePath);
        IList<Lender> Get();
    }


    public class MarketDataRepository : IMarketDataRepository
    {
        private ICSVParser parser;

        public MarketDataRepository(ICSVParser parser)
        {
            this.parser = parser;
        }

        public IList<Lender> Get()
        {
            throw new NotImplementedException();
        }

        public void Load(FileInfo filePath)
        {
             parser.Parse(filePath);
        }
    }



}