using System;
using System.Collections.Generic;
using System.IO;

namespace LoanDecider
{

    public interface ICSVParser
    {
        IList<Lender> Parse(FileInfo filepath);
    }

    public class CSVParser : ICSVParser
    {
        public IList<Lender> Parse(FileInfo filepath)
        {
            var lenderList = new List<Lender>();

            return lenderList;
        }
    }
}