using System;
using System.IO;

namespace LoanDecider
{

    public interface ICSVParser
    {
        void Parse(FileInfo filepath);
    }

    public class CSVParser : ICSVParser
    {
        public void Parse(FileInfo filePath)
        {
            throw new NotImplementedException();
        }
    }
}