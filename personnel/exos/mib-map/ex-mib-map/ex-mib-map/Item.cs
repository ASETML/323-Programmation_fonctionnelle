using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_mib_map
{
    internal class Item
    {
        public string producer;
        public string cat;
        public string CA;
        public Item(string producer, string cat, string CA)
        {
            this.producer = producer;
            this.cat = cat;
            this.CA = CA;
        }
    }
}
