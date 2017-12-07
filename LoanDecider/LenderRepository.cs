using System;
using System.Collections.Generic;
using System.IO;

namespace LoanDecider
{
    public interface ILenderRepository
    {
        void Load(FileInfo filePath);
        IList<Lender> Get();
    }


    public class LenderRepository : ILenderRepository
    {
        private ICSVParser parser;

        public LenderRepository(ICSVParser parser)
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