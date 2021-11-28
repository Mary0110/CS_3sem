using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Raniuk_Lab5
{
    class Journal
    {
        MyCustomCollections<MyEventArgs> EList = new MyCustomCollections<MyEventArgs>();
        public void Print()
        {
            for(int i = 0; i < EList.Count; i++)
            {
                Console.WriteLine( EList[i].Name);
            }    
        }

        public void OnListChanged(object sender, MyEventArgs e)
        {
            EList.Add(e);
        }
    }
}
