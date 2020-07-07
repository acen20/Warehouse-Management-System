using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    class Payment
    {
        public string name { get; set; }
        public int id { get; set; }
        public string mode { get; set; }
        public string n5000 { get; set; }
        public string n1000 { get; set; }
        public string n500 { get; set; }
        public string n100 { get; set; }
        public string other { get; set; }
        public string bank { get; set; }
        public string account { get; set; }
        public int total { get; set; }
        public int amount { get; set; }
        public string billno { get; set; }
    }
}
