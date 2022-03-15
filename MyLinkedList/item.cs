using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList
{
    public sealed class Item<T>: IComparer
    {
        public T data;
        


        public Item(T Data) => data = Data;

        public T Data { get { return data; } set { data = value; } }


        public Item<T> Next { get; set; }
        public Item<T> Prev { get; set; }

        public int Compare(object x, object y)
        {
            Item<int> temp = x as Item<int>;
            Item<int> temp1 = y as Item<int>;
            if (temp != null && temp1 != null)
            {

                return temp.Data - temp1.Data;


            }
            else
            {
                throw new Exception("Argument is not MyLinkedList");
            }
        }
    }
}
