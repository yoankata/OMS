using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS
{
    public class Transaction
    {
        [CsvColumn(Name = "SecurityId", FieldIndex = 1, CanBeNull = false)]
        public int SecurityId { get; set; } //Unique security identifier

        [CsvColumn(Name = "PortfolioId", FieldIndex = 2, CanBeNull = false)]
        public int PortfolioId { get; set; } //Unique portfolio Id

        [CsvColumn(Name = "Nominal", FieldIndex = 3, CanBeNull = false)]
        public decimal Nominal { get; set; } //Quantity of contracts to be purchased

        [CsvColumn(Name = "OMS", FieldIndex = 4, CanBeNull = false, CharLength = 3)]
        public OMS OMS { get; set; }  //Possible values AAA, BBB and CCC

        [CsvColumn(Name = "TransactionType", FieldIndex = 5, CanBeNull = false)]
        public TransactionType TransactionType { get; set; } //Possible values BUY or SELL

    }
}
