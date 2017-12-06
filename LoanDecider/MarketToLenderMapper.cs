using System.Collections.Generic;

namespace LoanDecider
{
    public interface MarketToLenderMapper
    {
        IList<Lender> Map(IMarketDataRepository marketDateRepository);
    }
}