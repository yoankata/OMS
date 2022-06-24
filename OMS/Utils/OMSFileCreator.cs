using LINQtoCSV;
using Microsoft.VisualBasic.FileIO;
using OMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Utils
{
    public static class OMSFileCreator
    {
        public static void CreateCSV<T>(IEnumerable<T> transactions) 
            where T : OutputTransaction, new()
        {
            var outputFolder = @"..\..\..\..\output\";
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            var outputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true,
                QuoteAllFields = false,
                EnforceCsvColumnAttribute = true
            };

            var fileExt = FileExtensionFactory.GetTypeExtension(typeof(T));
            var file = outputFolder + @"transactions." + fileExt;
            
            CsvContext cc = new CsvContext();
            var txt = new StreamWriter(file);


            foreach (var transaction in transactions)
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.WriteLine(transaction);
                }
            }
        }
    }
}
