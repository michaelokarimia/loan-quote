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
        private IList<Lender> lenders;

        public LenderRepository(ICSVParser parser)
        {
            this.parser = parser;
            lenders = new List<Lender>();
        }

        public IList<Lender> Get()
        {
            return lenders;
        }

        public void Load(FileInfo filePath)
        {
            lenders =  parser.Parse(filePath);
        }
    }



}