using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Raniuk_Lab5
{
    class Entities
    {
        MyCustomCollections<Tariff> TList = new MyCustomCollections<Tariff>();
        MyCustomCollections<Person> PList = new MyCustomCollections<Person>();
        MyCustomCollections<(Person,Service)> SList = new MyCustomCollections<(Person, Service)>();

        /*public class Person: IEquatable<Person>
        {
            public Person(string surname)
            {
                _surname = surname; 
            }
            public  string _surname { get; set; }
            public bool Equals(Person other)
            {
                if (other == null)
                    return false;

                if (this._surname == other._surname)
                    return true;
                else
                    return false;
            }
        }

        public class Service
        {
            public Service(string name, float price)
            {
                _total_price = price;
                _name = name;
            }
            public float _total_price { get; set; }
            public string _name { get; set; }
        }
        public class Tariff: IEquatable<Tariff>
        {
            public float _cost;

            public bool Equals(Tariff other)
            {
                if (other == null)
                    return false;

                if (this._tariffName == other._tariffName)
                    return true;
                else
                    return false;
            }

            public Tariff(string RateName, float Cost)
            {
                _tariffName = RateName;
                _cost = Cost;
            }

            public string _tariffName { get; set; }
            public float Cost
            {
                get => _cost;
                set
                {
                    if((value >= 0) && (value < 1000))
                    { 
                        _cost = value;
                    }
                }
            }
        }
        */
        public void AddTariffToList(string name, float cost)
        {
            Tariff t = new Tariff(name, cost);
            TList.Add(t);
        }

        public void AddPersonToList(string name)
        {
            Person p = new Person(name);
            PList.Add(p);
        }

        public void AddServiceToList(string serviceName, float amount, string surname)
        {
            Tariff tariff = SearchT(serviceName);
            Person pers = SearchP(surname);
            if (tariff != default && pers != default)
            {
                float cost = tariff.Cost;
                float total = cost * amount;
                Service s = new Service(serviceName, total);
                SList.Add((pers, s));
            }
        }

        public Person SearchP(string str)
        {
            for (int i = 0; i < PList.Count; i++)
            {
                if (PList[i]._surname == str)
                    return PList[i];
            }
            return default;
        }

        public Tariff SearchT(string str)
        {
            for (int i = 0; i < PList.Count; i++)
            {
                if (TList[i]._tariffName == str)
                    return TList[i];
            }
            return default;
        }

        public float SumBySurname(string sur)
        {
            Person t = SearchP(sur);
            float price = 0;
            if (t != default)
            {
                for (int i = 0; i < SList.Count; i++)
                {
                    if (SList[i].Item1.Equals(t))
                        price += SList[i].Item2._total_price;
                }
            }
            return price;
        }

        public float WholeSum()
        {
            float price = 0;
            for (int i = 0; i < SList.Count; i++)
            {
                price += SList[i].Item2._total_price;
            }   
            return price;
        }
    }
}
