using System.Collections.Generic;

namespace LoanDecider
{
    public interface IMarketToLenderMapper
    {
        IList<Lender> Map(IMarketDataRepository marketDateRepository);
    }
}