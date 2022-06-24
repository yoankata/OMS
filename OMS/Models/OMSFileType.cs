using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Models
{
    public abstract class OMSFileType
    {
        public string PortfolioCode { get; set; } //  Lookup from portfolio file
        public decimal Nominal { get; set; } // Quantity of contracts
        public string TransactionType { get; set; } // BUY or SELL
    }
}
