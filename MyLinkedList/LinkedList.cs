using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList
{
    public class MyLinkedList<T> : IEnumerable<T>, ICloneable,  ICollection<T>, IComparable, IComparer
    {
        #region  Заглушки
        public string GetHashCode()
        {
            return "59941933";
        }

        public string GetObjectData() { return null; }

        public string GetType() { return "MyLinkedList[int32]"; }

        public string MemberwiseClone() { return null; }

        public string OneDeserialization() { return null; }
        public string ToString() {
            return "System.Func`1[System.String]";
        }
        #endregion 
        public Item<T> Head { get;  set; }
        public Item<T> Tail { get; private set; }

        public MyLinkedList(T data)
        {
            Item<T> item = new Item<T>(data);
            Head = item;
            Tail = Head;
        }
        public MyLinkedList(Item<T> node)
        {

            Head = node;
            Tail = Head;
        }

       

        public MyLinkedList()
        {

        }

        public Item<T> First { get { return this.Head; } }
        public Item<T> Last { get { return this.Tail; } }

        public int Count => count();
            

        public bool IsReadOnly => throw new NotImplementedException();

        public void AddAfter(Item<T> prev, Item<T> nev)
        {
            if (nev == null) throw new ArgumentNullException(nameof(nev));
            nev.Prev = null;
            nev.Next = null;
            if(prev == Tail)
            {
                AddLast(nev);
            }
            else
            {
                prev.Next.Prev = nev;
                nev.Prev = prev;
                nev.Next = prev.Next;
                prev.Next = nev;
            }

        }
        public void AddAfter(Item<T> prev, T data)
        {
            Item<T> node = new Item<T>(data);
            AddAfter(prev, node);
            
        }//+

        public void AddBefore(Item<T> prev, Item<T> nev)
        {
            nev.Prev = null;
            nev.Next = null;
            if (prev == this.Head)
            {
                AddFirst(nev);
            }
            else
            {

                prev.Prev.Next = nev;
                nev.Prev = prev.Prev;
                nev.Next = prev;
                prev.Prev = nev;
            }


        }//+


        public void AddBefore(Item<T> prev, T data)
        {
            Item<T> node = new Item<T>(data);
            AddBefore(prev, node);
            


        }//+

        public void AddFirst(Item<T> node)//+
        {
            node.Prev = null;
            node.Next = null;
            if (this.Head == null)
            {
                this.Tail = node;


            }
            else
            {
                this.Head.Prev = node;
                node.Next = this.Head;
                this.Head = node;
            }

        }

        public void AddFirst(T data)
        {
            Item<T> node = new Item<T>(data);
            AddFirst(node);

        }//+

        public void AddLast(Item<T> node)
        {
            node.Prev = null;
            node.Next = null;
            if (Head == null)
            {               
                Head = node;
                Tail = Head;
            }
            else
            { 
                Tail.Next = node;
                node.Prev = Tail;
                Tail = node;
            }
            

        } //+

        public void AddLast(T data)
        {
            Item<T> item = new Item<T>(data);
            AddLast(item);
        }  //+

        public void Clear()
        {
            Head = null;
            Tail = null;    
        }  //+

        public bool Contains(T Data)
        {
            if (Find(Data) == null)
            {
                return false;
            }
            return true;

        } //+

        public void CopyTo(T[] arr, int ind)
        {
            int e = 0;
            Item<T> temp = this[ind];

            //Console.WriteLine(temp.Data);
            while (temp != null)
            {
                arr[e] = temp.Data;

                temp = temp.Next;
                e++;

            }


        } //+

        public bool Equals(MyLinkedList<T> newlist)
        {
            if (this.count() == newlist.count())
            {
                Item<T> temp = Head;
                Item<T> temp1 = newlist.Head;
                while (temp != null)
                {
                    if (!(temp.Data.Equals(temp1.Data)))
                    {
                        return false;
                    }
                    temp = temp.Next;
                    temp1 = temp1.Next;
                }
                return true;
            }
            return false;
        } //+

        public Item<T> Find(T data)
        {
            Item<T> temp = Head;
            while (temp != null)
            {
                if (temp.Data.Equals(data))
                {

                    return temp;
                }


                temp = temp.Next;

            }
            return null;
        }//+

        public Item<T> FindLast(T data)
        {
            Item<T> temp = Tail;
            while (temp != null)
            {
                if (temp.Data.Equals(data))
                {

                    return temp;
                }


                temp = temp.Prev;

            }
            return null;
        }//+

       

        public void Remove(Item<T> node)
        {
            if (node != null)
            {

                if (node == Head)
                {
                    RemoveFirst();
                }
                else if (node == Tail)
                {
                    RemoveLast();
                }
                else
                {
                    node.Prev.Next = node.Next;
                    node.Next.Prev = node.Prev;
                }
            }
        }//+

        public void Remove(T data)//+
        {
            if (Contains(data))
            {
                
                Remove(Find(data));
            }
            
        }

        public void RemoveFirst()
        {
            if (Head == null)
            {
                return;
            }
            if (Head.Next == null)
            {
                Head = null;
                Tail = null;
            }
            Head = Head.Next;
            Head.Prev = null;

        }//+

        public void RemoveLast()
        {
            if (Head == null)
            {
                return;
            }

            Tail = Tail.Prev;
            Tail.Next = null;
        }//+

        

        public Item<T> this[int index]
        {
            get
            {
                Item<T> temp = Head;
                while (index > 0)
                {
                    temp = temp.Next;
                    index--;
                }
                return temp;
            }
            set
            {
                if (Head != Tail)
                {
                    Item<T> temp = Head;
                    while (index > 1 )
                    {
                        temp = temp.Next;
                        index--;
                    }
                    temp.Next.Prev = value;
                    value.Prev = temp.Prev;
                    value.Next = temp.Next.Next;
                    temp.Next = value;

                }
                else { Head = value; Tail = Head; }
                
            }
        } //+
        public void Show()
        {
            Item<T> temp = Head;
            if (temp != null)
            {
                Console.Write(temp.Data);
                Console.WriteLine();
                while (temp.Next != null)
                {
                    temp = temp.Next;

                    Console.Write(temp.Data);
                    Console.WriteLine();

                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("List is empty");
                Console.WriteLine();
            }


        }//+

        public int count()
        {
            if(Head == Tail)
            {
                return 0;
            }
            else { 

            
                int count = 0;
                Item<T> temp = Head;
                while (temp != null)
                {
                    count++;
                    temp = temp.Next;
                }
                return count;
            }
        }//+

        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }//+

        public int CompareTo(object obj)
        {
            MyLinkedList<T> temp = obj as MyLinkedList<T>;
            if (temp != null) {

                return temp.count() - this.count();


            }
            else
            {
                throw new Exception("Argument is not MyLinkedList");
            }
        }//+
        

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }//+
        public void Sort() => this.Sort(count(),null);//+

        public void Sort(IComparer comparer) => this.Sort(count(), comparer);

        public void Sort(int count,IComparer comparer)
        {

            MergeSort(this);
        }
        public MyLinkedList<T> Merge_sort2(MyLinkedList<T> array, int low, int high)
        {
            int med = (low + high) / 2;
            if (low < high)
            {
                Merge_sort2(array, low, med);
                Merge_sort2(array, med + 1, high);
                Merge2(array, low, med, high);
            }
            return array;
        }


        public void Merge2(MyLinkedList<T> array, int l, int left, int right)
        {
            int r = left + 1, t = 0, k = l;
            MyLinkedList<T> vrem = new MyLinkedList<T>();

            while (l <= left && r <= right)
            {
                if (Compare(array[l],(array[r]))>0)
                {
                    vrem[t] = array[r];

                    r++;
                }
                else
                {
                    vrem[t] = array[l];
                    l++;
                }
                t++;
            }
            while (l <= left)
            {
                vrem[t] = array[l];
                l++;
                t++;
            }
            while (r <= right)
            {
                vrem[t] = array[r];
                r++;
                t++;
            }
            
            for (int i = 0; i < vrem.Count; i++)
            {
                
                array[i + k] = vrem[i];
            }
            array.Show();
        }

        public void Merge(MyLinkedList<T> array, MyLinkedList<T> array1, MyLinkedList<T> array2)
        {
            int Array1MinIndex = 0;
            int Array2MinIndex = 0;

            int targetIndex = 0;
            while (Array1MinIndex<array1.Count && Array2MinIndex < array2.Count)
            {
                if (Compare(array1[Array1MinIndex],array2[Array2MinIndex])<=0)
                {
                    array[targetIndex]=array1[Array1MinIndex];
                    Array1MinIndex++;
                }
                else
                {
                    array[targetIndex] = array2[Array2MinIndex];
                    Array2MinIndex++;
                }
                targetIndex++;
            }
            while(Array2MinIndex < array2.Count)
            {
                array[targetIndex] = array2[Array2MinIndex];
                Array2MinIndex++;
                targetIndex++;
            }
            while (Array1MinIndex < array1.Count)
            {
                array[targetIndex] = array1[Array1MinIndex];
                Array1MinIndex++;
                targetIndex++;
            }

        }
        public void MergeSort(MyLinkedList<T> array)
        {
            if(array.Count <1)
            {
                return;
            }
            int mid = array.Count / 2;
            MyLinkedList<T> left = new MyLinkedList<T>();
            MyLinkedList<T> right = new MyLinkedList<T>();
            for(int i = 0; i < mid; i++)
            {
                left[i] = array[i];

            }
            for (int i = mid; i < array.Count; i++)
            {
               right[i-mid] = array[i];

            }
            MergeSort(left);
            MergeSort(right);
            Merge(array,left,right);

        }

        public object Clone() 
        { 
            MyLinkedList<T> temp = new MyLinkedList<T>();
            foreach(T item in this)
            {
                
                if(item != null) {temp.AddLast(item); }
                

            }
            return temp;
        }

        public void Add(T item)
        {
            this.AddLast(item);
        }

        bool ICollection<T>.Remove(T item)
        {
            if (Find(item)!=null)
            {
                this.Remove(item);
                return true;
            }
            return false;
            
        }

        public  int Compare(object x, object y)
        {
            Item<int> temp = x as Item<int>;
            Item<int> temp1 = y as Item<int>;
            if (temp != null && temp1!=null)
            {

                return temp.Data-temp1.Data;


            }
            else
            {
                throw new Exception("Argument is not MyLinkedList");
            }
        }
    }
}
