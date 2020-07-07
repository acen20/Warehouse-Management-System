using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Warehouse
{
    class itemreport
    {
        public string name { get; set; } 
        public int totalCart { get; set; }
        public int totalpc { get; set; }
        public int returnedcart { get; set; }
        public int returnedpc { get; set; }
        public int replacedcart { get; set; }
        public int replacedpc { get; set; }
        public int soldcart { get; set; }
        public int soldpc { get; set; }
        public int tradeoffer { get; set; }
        public int rate { get; set; }
        public string expiry { get; set; }
        public int crt { get; set; }

        static public List<itemreport> saleTable =new List<itemreport>();
    }
}
