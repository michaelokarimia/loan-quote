using System;
using System.Collections.Generic;
using System.IO;

namespace LoanDecider
{
    public interface ILenderRepository
    {
        IList<Lender> Get();
    }

    public class LenderRepository : ILenderRepository
    {
        private ICSVParser parser;
        private IList<Lender> lenders;

        public LenderRepository(ICSVParser parser, FileInfo filePath)
        {
            this.parser = parser;
            lenders = parser.Parse(filePath);
        }

        public IList<Lender> Get()
        {
            return lenders;
        }
    }
}