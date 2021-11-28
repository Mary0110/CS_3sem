using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Raniuk_Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            HousingMaintainanceService HMS = new HousingMaintainanceService();
            Journal j1 = new Journal();

            HMS.ListChanged += j1.OnListChanged;

            Menu m1 = new Menu(HMS, j1);

            
            m1.Run();
        }
    }
}
