using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS
{
    public class Portfolio
    {
        [CsvColumn(Name = "PortfolioId", FieldIndex = 1, CanBeNull = false)]
        public int Id { get; set; }
       
        [CsvColumn(Name = "PortfolioCode", FieldIndex = 2, CanBeNull = false)]
        public string Code { get; set; }
    }
}
