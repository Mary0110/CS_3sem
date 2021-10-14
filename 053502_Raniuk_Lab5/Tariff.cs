using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Raniuk_Lab5
{
    class Tariff : IEquatable<Tariff>
    {
        public Tariff(string RateName, float Cost)
        {
            _tariffName = RateName;
            _cost = Cost;
        }

        public float _cost;
        public string _tariffName { get; set; }

        public float Cost
        {
            get => _cost;
            set
            {
                if ((value >= 0) && (value < 1000))
                {
                    _cost = value;
                }
            }
        }

        public bool Equals(Tariff other)
        {
            if (other == null)
                return false;

            if (this._tariffName == other._tariffName)
                return true;
            else
                return false;
        }
    }
}

