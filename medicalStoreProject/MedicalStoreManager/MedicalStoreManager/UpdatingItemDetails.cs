using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockUpdateModule
{
    public class UpdatingItemDetails
    {
        public int batchNum { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public int discount { get; set; }
        public string mfgDate { get; set; }
        public string expDate { get; set; }
        public double unitPrice { get; set; }
    }
}
