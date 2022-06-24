using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Models
{
    public class CCCTransaction : OutputTransaction
    {
        [CsvColumn(Name = "PortfolioCode", FieldIndex = 1, CanBeNull = false)]
        public string PortfolioCode { get; set; } //  Lookup from portfolio file

        [CsvColumn(Name = "Ticker", FieldIndex = 2, CanBeNull = false)]
        public string Ticker { get; set; }  //Lookup from security file

        [CsvColumn(Name = "Nominal", FieldIndex = 3, CanBeNull = false)]
        public decimal Nominal { get; set; } // Quantity of contracts

        [CsvColumn(Name = "TransactionType", FieldIndex = 4, CanBeNull = false, CharLength = 1)]
        public TransactionTypeConcise TransactionType { get; set; } // B or S
    }
}
