using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Raniuk_Lab5
{
    class Service
    {
        public Service(string name, float price)
        {
            _total_price = price;
            _name = name;
        }
        public float _total_price { get; set; }
        public string _name { get; set; }
    }
}
