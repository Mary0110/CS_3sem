using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Raniuk_Lab5
{
    class Service: IEquatable<Service>
    {
        public Service(string name, float price)
        {
            _total_price = price;
            _name = name;
        }
        public float _total_price { get; set; }
        public string _name { get; set; }

        public bool Equals(Service other)
        {
            if (other == null)
                return false;

            return (this._name == other._name && this._total_price == other._total_price);
        }
    }
}
