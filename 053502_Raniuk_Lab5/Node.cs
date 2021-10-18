using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Raniuk_Lab5
{
    public class Node<T>
    where T : IEquatable<T>
    {
        public T _data { get; set; }
        public Node<T> next { get; set; }
        public Node(T data)
        {
            _data = data;
            next = null;
        }
        public bool Compare(T other)
        {
            return _data.Equals(other);
        }
    }
}
