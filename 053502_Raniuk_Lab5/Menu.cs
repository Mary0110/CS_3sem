using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Raniuk_Lab5
{
    class Menu
    {
        static string CheckInput(string str)
        {
            int count = -1;
            while (count != str.Length)
            {
                count = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    if (i == 0 && str[i] >= 'A' && str[i] <= 'Z')
                    {
                        count++;
                    }
                    else if (i > 0 && str[i] >= 'a' && str[i] <= 'z')
                    {
                        count++;
                    }
                }
                if (count != str.Length)
                {
                    Console.WriteLine($"{str} - invalid data. Try again");
                    str = Console.ReadLine();
                    count = -1;
                }
            }
            return str;
        }

        public HousingMaintainanceService hms { get; set; }
        public Journal journal { get; set; }

        public Menu(HousingMaintainanceService HMS, Journal j)
        {
            hms = HMS;
            journal = j;
        }

        private void AddPeople()
        {
            do
            {
                Console.WriteLine("Enter tenant's surname:");
                string str = Console.ReadLine();
                string sur = CheckInput(str);
                hms.AddPersonToList(sur);
                Console.WriteLine("Press 1 to continue input, other key - exit");
            } while (Console.ReadLine() == "1");
        }

        private void AddTariffPlan()
        {
            do
            {
                Console.WriteLine("Enter tariff name:");
                string name = Console.ReadLine();
                float cost;

                do
                {
                    Console.WriteLine("Enter tariff cost:");
                    string str = Console.ReadLine();
                    float.TryParse(str, out cost);
                } while (cost < 0 || cost > 1000);

                hms.AddTariffToList(name, cost);
                Console.WriteLine("Press 1 to continue input, other key - exit");
            } while (Console.ReadLine() == "1");
        }

        private void AddServices()
        {
            do
            {
                string sur;

                do
                {
                    Console.WriteLine("Enter surname:");
                    sur = Console.ReadLine();
                } while (hms.SearchP(sur) == default);

                string name;

                do
                {
                   Console.WriteLine("Enter service name:");
                 name = Console.ReadLine(); 
                } while (hms.SearchT(name) == default);

                float amount;

                do
                {
                    Console.WriteLine("Enter amount of consumed services:");
                    string str = Console.ReadLine();
                    float.TryParse(str, out amount);
                } while (amount < 0);

                hms.AddServiceToList(name, amount, sur);
                hms.AddService(name, amount);
                Console.WriteLine("Press 1 to continue input, other key - exit");
            } while (Console.ReadLine() == "1");
        }

        private void DisplayBySurname()
        {
            do
            { 
                Console.WriteLine("Enter surname:");
                string sur = Console.ReadLine();
                float sum = hms.SumBySurname(sur);
                Console.WriteLine($"The sum of service is {sum}");;
                Console.WriteLine("Press 1 to continue input, other key - exit");
            } while (Console.ReadLine() == "1");
        }

        private void DisplayWholeSum()
        {
            do
            {
                float sum = hms.WholeSum();
                journal.Print();
                Console.WriteLine($"The sum of all services is {sum}");
                Console.WriteLine("Press 1 to continue input, other key - exit");
            } while (Console.ReadLine() == "1");
        }

        public void Run()
        {
            bool endApp = false;
            do
            {
                Console.WriteLine("Choose option: 1 - add tenants");
                Console.WriteLine("\t2 - add tariff plan");
                Console.WriteLine("\t3 - add services");
                Console.WriteLine("\t4 - display service cost by surname");
                Console.WriteLine("\t5 - display total cost");
                Console.WriteLine("\t6 - exit");
                string s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        {
                            AddPeople();
                        }
                        break;
                    case "2":
                        {
                            AddTariffPlan();
                        }
                        break;
                    case "3":
                        {
                            if(hms.PIsEmpty())
                            {
                                Console.WriteLine("List of tenants is empty.");
                                AddPeople();
                            }
                            if(hms.TIsEmpty())
                            {
                                Console.WriteLine("Tariff plan is not completed.");
                                AddTariffPlan();                               
                            }
                            hms.ListChanged += (o, e) => { Console.WriteLine(e.Name); };
                            AddServices();
                            hms.ListChanged -= (o, e) => { Console.WriteLine(e.Name); };

                        }
                        break;
                    case "4":
                        {
                            DisplayBySurname();
                        }
                        break;
                    case "5":
                        {
                            DisplayWholeSum();
                        }
                        break;
                    case "6":
                    default:
                        {
                            endApp = true;
                        }
                        break;
                }
            } while (!endApp);
        }
    }
}
