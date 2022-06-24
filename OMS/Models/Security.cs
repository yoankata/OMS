using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS
{
    public class Security
    {
        [CsvColumn(Name = "SecurityId", FieldIndex = 1, CanBeNull = false)]
        public int Id { get; set; }

        [CsvColumn(Name = "ISIN", FieldIndex = 2, CanBeNull = false, CharLength = 12)]
        public string ISIN { get; set; }

        [CsvColumn(Name = "Ticker", FieldIndex = 3, CanBeNull = false)]
        public string Ticker { get; set; }

        [CsvColumn(Name = "CUSIP", FieldIndex = 4, CanBeNull = false, CharLength = 9)]
        public string Cusip { get; set; }
    }
}
