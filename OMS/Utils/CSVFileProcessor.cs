using LINQtoCSV;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Utils
{
    public static class CSVFileProcessor
    {
        public static IEnumerable<T> ReadCSV<T>(string file) where T : class, new()
        {
            IEnumerable<T> result = new List<T>();
            var inputFileDescription = new CsvFileDescription
            {
                // cool - I can specify my own separator!
                SeparatorChar = ',',
                FirstLineHasColumnNames = true,
                QuoteAllFields = true,
                EnforceCsvColumnAttribute = true
            };

            using (var reader = new StreamReader(file))
            {            
                CsvContext cc = new CsvContext();
                result = cc.Read<T>(reader, inputFileDescription);
            }



            return result;
        }


    }
}
