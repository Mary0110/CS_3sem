using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Raniuk_Lab5
{
    class HousingMaintainanceService
    {
        MyCustomCollections<Tariff> TList = new MyCustomCollections<Tariff>();
        MyCustomCollections<Person> PList = new MyCustomCollections<Person>();
        MyCustomCollections<(Person,Service)> PSList = new MyCustomCollections<(Person, Service)>();
        MyCustomCollections<Service> SList = new MyCustomCollections<Service>();
        
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

        public void AddService(string serviceName, float amount)
        {
            Tariff tariff = SearchT(serviceName);
            if (tariff != default)
            {
                float cost = tariff.Cost;
                float total = cost * amount;
                Service s = new Service(serviceName, total);
                SList.Add((s));
            }
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
                PSList.Add((pers, s));
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
                for (int i = 0; i < PSList.Count; i++)
                {
                    if (PSList[i].Item1.Equals(t))
                        price += PSList[i].Item2._total_price;
                }
            }
            return price;
        }

        public float WholeSum()
        {
            float price = 0;
            for (int i = 0; i < PSList.Count; i++)
            {
                price += PSList[i].Item2._total_price;
            }   
            return price;
        }

        public bool PIsEmpty()
        {
            if (PList.Count == 0)
                return true;
            else
                return false;
        }

        public bool TIsEmpty()
        {
            if (TList.Count == 0)
                return true;
            else
                return false;
        }
    }
}
