using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Raniuk_Lab5
{
    public class Node<T>
        where T: IEquatable<T>
    {
        public Node(T data)
        {
            _data = data;
            next = null;
            //_index++;
        }
        public T _data { get; set; }
        //static int _index = 0;
        public Node<T> next { get; set; }
        public bool Compare(T other)
        {
            if (_data.Equals(other))
                return true;
            else
                return false;
        }
    }

    public class MyCustomCollections<T>: ICustomCollection<T>
        where T: IEquatable<T>
    {
        Node<T> Head;
        int Length;
        static int size = 0;
        Node<T> cursor;
        public MyCustomCollections()
        {
            Length = 0;
            Head = default;
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                  throw new IndexOutOfRangeException("Invalid index input");
                Node<T> current = this.Head;
                for (int i = 0; i < size; i++)
                {
                    if (i == index)
                        return current._data;
                    current = current.next;
                }
                return default;
            }
            set
            {
                Node<T> current = this.Head;
                Node<T> newNode = new Node<T>(value);

                for (int i = 0; i <= size; i++)
                {
                    if (i == index && i == 0)
                    {
                        newNode.next = current;
                        this.Head = newNode;
                        size++;
                        break;
                    }
                    else if (index == i && i == size)
                    {
                        newNode.next = null;
                        current.next = newNode;
                        size++;
                        break;
                    }
                    else
                    {
                        newNode.next = current.next;
                        current.next = newNode;
                        size++;
                        break;
                    }
                    current = current.next;
                }
            }
        }
        public void Reset() { cursor = this.Head;}
        public void Next() { cursor = cursor.next; }
        public T Current() {return cursor._data; }
                
                 
        public int Count { get => size; }
        public void Add(T item) { this[size] = item; }
        public void Remove(T item)
        {
            Node<T> current = this.Head;
            for (int i = 0; i < size - 1; i++)
            {
                if (i == 0 && current.Compare(item) == true)
                {
                    this.Head = current.next;
                    size--;
                    break;
                }
                else if (current.next.Compare(item) == true)
                {
                    current.next = current.next.next;
                    size--;
                    break;
                }
            }
        }
       public T RemoveCurrent() 
       {
            Remove(cursor._data);
            return cursor._data;
       }
       
    }
}
