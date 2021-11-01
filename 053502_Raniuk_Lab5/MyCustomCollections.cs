using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Raniuk_Lab5
{

    public class MyCustomCollections<T>: ICustomCollection<T>
        where T: IEquatable<T>
    {
        Node<T> Head;
        Node<T> cursor;

        public MyCustomCollections()
        {
            Head = default;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                  throw new IndexOutOfRangeException("Invalid index input");
                Node<T> current = this.Head;
                for (int i = 0; i <= Count; i++)
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

                if (index < 0 || index > Count)
                    throw new IndexOutOfRangeException("Invalid index");
                if (index == 0)
                {
                    newNode.next = current;
                    this.Head = newNode;
                    Count++;
                }
                else if (index == Count)
                {
                    for(int i = 0; i < Count-1; i++)
                    {
                        current = current.next;
                       // Console.WriteLine("aaaaaaaaaa"+ current._data);
                    }
                    newNode.next = null;
                    current.next = newNode;
                    Count++;
                }
                else
                {
                    current = current.next;

                    for (int i = 1; i < Count; i++)
                    {
                        if (i == index)
                        {
                            newNode.next = current.next;
                            current.next = newNode;
                            Count++;
                            break;
                        }
                        current = current.next;
                    }
                }
            }
        }

        public void Reset() { cursor = this.Head;}
        public void Next() 
        { 
            if(cursor.next != default)
                cursor = cursor.next;
        }
        public T Current() {return cursor._data; }
        public int Count { get; private set; } = 0;
        public void Add(T item) { this[Count] = item; }
        public void Remove(T item)
        {
            Node<T> current = this.Head;
            for (int i = 0; i < Count - 1; i++)
            {
                if (i == 0 && current.Compare(item) == true)
                {
                    this.Head = current.next;
                    Count--;
                    break;
                }
                else if (current.next.Compare(item) == true)
                {
                    current.next = current.next.next;
                    Count--;
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
