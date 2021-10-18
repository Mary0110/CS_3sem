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

        public HousingMaintainanceService g { get; set; }
        public Menu(HousingMaintainanceService HMS)
        {
            g = HMS;
        }

        private void AddPeople()
        {
            do
            {
                Console.WriteLine("Enter tenant's surname:");
                string str = Console.ReadLine();
                string sur = CheckInput(str);
                g.AddPersonToList(sur);
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

                g.AddTariffToList(name, cost);
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
                } while (g.SearchP(sur) == default);

                string name;

                do
                {
                   Console.WriteLine("Enter service name:");
                 name = Console.ReadLine(); 
                } while (g.SearchT(name) == default);

                float amount;

                do
                {
                    Console.WriteLine("Enter amount of consumed services:");
                    string str = Console.ReadLine();
                    float.TryParse(str, out amount);
                } while (amount < 0);

                g.AddServiceToList(name, amount, sur);
                g.AddService(name, amount);
                Console.WriteLine("Press 1 to continue input, other key - exit");
            } while (Console.ReadLine() == "1");
        }

        private void DisplayBySurname()
        {
            do
            { 
                Console.WriteLine("Enter surname:");
                string sur = Console.ReadLine();
                float sum = g.SumBySurname(sur);
                Console.WriteLine($"The sum of service is {sum}");;
                Console.WriteLine("Press 1 to continue input, other key - exit");
            } while (Console.ReadLine() == "1");
        }

        private void DisplayWholeSum()
        {
            do
            {
                float sum = g.WholeSum();
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
                            if(g.PIsEmpty())
                            {
                                Console.WriteLine("List of tenants is empty.");
                                AddPeople();
                            }
                            if(g.TIsEmpty())
                            {
                                Console.WriteLine("Tariff plan is not completed.");
                                AddTariffPlan();
                            }
                            AddServices();
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
