using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

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

            if (filepath.Extension.ToLowerInvariant() != ".csv")
                throw new InvalidDataException("File type was not in a .csv extention");

            var lenderList = new List<Lender>();

            using (var parser = new TextFieldParser(filepath.OpenText()))
            {

                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                while(!parser.EndOfData)
                {
                    var fields = parser.ReadFields();

                    //check if not first line in csv
                    if(fields[0] != "Lender" && fields[1] != "Rate" && fields[2] != "Available")
                    {
                        try
                        {
                            var name = fields[0];
                            double rate = double.Parse(fields[1]);

                            long amount = long.Parse(fields[2]);


                            lenderList.Add(new Lender(name, rate, amount));
                        }
                        catch (Exception)
                        {
                            throw new FormatException(string.Format("Invalid row, unable to parse: {0}, {1}, {2}", fields[0], fields[1], fields[2]));
                        }


                    }
                }
            }

                return lenderList;
        }
    }
}