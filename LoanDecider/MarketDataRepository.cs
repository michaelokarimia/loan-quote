using System.IO;

namespace LoanDecider
{
    public interface IMarketDataRepository
    {
        void Load(FileInfo filePath);
    }


    public class MarketDataRepository : IMarketDataRepository
    {
        private ICSVParser parser;

        public MarketDataRepository(ICSVParser parser)
        {
            this.parser = parser;
        }

        public void Load(FileInfo filePath)
        {
            parser.Parse(filePath);
        }
    }



}