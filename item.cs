using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    class item
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string desc { get; set; }
        public int rate { get; set; }
        public int qtypcs { get; set; }
        public int qtycart { get; set; }
        public string tag { get; set; }
        public string expiry { get; set; }
        public string tradeOffer { get; set; }
        public double total { get; set; }
        public int crt { get; set; }
        public int product_id { get; set; } 
        public int maxCart { get; set; }
        public int maxPcs { get; set; }
    }
}
