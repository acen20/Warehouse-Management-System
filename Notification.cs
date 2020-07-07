using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    class Notification
    {
        public int id { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        static public int count { get; set; }
        public static List<Notification> lst = new List<Notification>();
    }
}
