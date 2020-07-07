using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    class saleReturn
    {
        public int id { get; set; }
        public string billno { get; set; }
        public int returnedCart { get; set; }
        public int returnedpc { get; set; }
        public int replacedCart { get; set; }
        public int replacedpc { get; set; }
        public int payid { get; set; }
        public int productID { get; set; }
        public int total { get; set; }
    }
}
