using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Raniuk_Lab5
{
    class Person : IEquatable<Person>
    {
        public Person(string surname)
        {
            _surname = surname;
        }
        public string _surname { get; set; }
        public bool Equals(Person other)
        {
            if (other == null)
                return false;

            return this._surname == other._surname;     
        }
    }
}

