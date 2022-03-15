using System;
using System.Text;
using System.Collections.Generic;
using MyLinkedList;
using System.Diagnostics;

public class Example
{
    public static void Main()
    {
        // Create the link list.

        //Test();

        TestInterfaces();



        Console.ReadLine();

    }
    public static void Test()
    {   
        
        Stopwatch sw = new Stopwatch();
        Stopwatch Sw = new Stopwatch();

        Sw.Start();

        for (int i = 0; i < 10000; i++) { TestLinkedList(); }

        Sw.Stop();
        sw.Start();

        for (int i = 0; i < 10000; i++) { TestMyLinkedList(); }

        sw.Stop();


        Console.WriteLine(Sw.ElapsedMilliseconds);
        Console.WriteLine(sw.ElapsedMilliseconds);

    }

    public static void TestLinkedList()
    {
        Random rd = new Random();
        LinkedList<string> sentence = new LinkedList<string>();
        for (int i = 0; i < 10000; i++)
        {
            sentence.AddLast(rd.Next(70, 140).ToString());

        }



        sentence.Contains("76");


        sentence.AddFirst("13324214312421");
        //Console.WriteLine(sentence.First.Value);


        LinkedListNode<string> mark1 = sentence.First;
        sentence.RemoveFirst();
        sentence.AddLast(mark1);



        sentence.RemoveLast();
        sentence.AddLast("node");
        //Console.WriteLine(sentence.Last.Value);






        sentence.RemoveFirst();
        LinkedListNode<string> current = sentence.FindLast("node");



        sentence.AddAfter(current, "1311");
        sentence.AddAfter(current, "fox");



        current = sentence.Find("fox");



        sentence.AddBefore(current, "quick");
        sentence.AddBefore(current, "brown");



        mark1 = current;
        LinkedListNode<string> mark2 = current.Previous;
        current = sentence.Find("quick");






        sentence.Remove(mark1);
        sentence.AddBefore(current, mark1);



        sentence.Remove(current);



        sentence.AddAfter(mark2, current);



        sentence.Remove("fox");






       string[] sArray = new string[sentence.Count];
        sentence.CopyTo(sArray, 0);

        /*foreach (string s in sArray)
        {
            Console.Write(s);
            Console.Write("  ");

        }*/


        sentence.Clear();

        //Console.WriteLine();
        sentence.Contains("jumps");

        
    }
    public static void TestMyLinkedList()
    {
        MyLinkedList<string> list = new MyLinkedList<string>();
        Random rd = new Random();
        for (int i = 0; i < 10000; i++)
        {
            list.AddLast(rd.Next(70, 140).ToString());

        }
        list.Contains("76");


        list.AddFirst("13324214312421");
        //Console.WriteLine(sentence.First.Value);


        Item<string> mark1 = list.First;
        list.RemoveFirst();
        list.AddLast(mark1);



        list.RemoveLast();
        list.AddLast("node");
        //Console.WriteLine(sentence.Last.Value);






        list.RemoveFirst();
        Item<string> current = list.FindLast("node");



        list.AddAfter(current, "1311");
        list.AddAfter(current, "fox");



        current = list.Find("fox");



        list.AddBefore(current, "quick");
        list.AddBefore(current, "brown");



        mark1 = current;
        Item<string> mark2 = current.Prev;
        current = list.Find("quick");






        list.Remove(mark1);
        list.AddBefore(current, mark1);



        list.Remove(current);



        list.AddAfter(mark2, current);



        list.Remove("fox");






        string[] sArray = new string[list.count()];
        list.CopyTo(sArray, 0);

        /*foreach (string s in sArray)
        {
            Console.Write(s);
            Console.Write("  ");

        }*/


        list.Clear();

        //Console.WriteLine();
        list.Contains("jumps");
    }
    public static void TestInterfaces()
    {
        /*//IClone
        MyLinkedList<string> list = new MyLinkedList<string>("parrot");
        list.AddLast("dog");
        list.AddLast("cat");
        MyLinkedList<string> list1 = (MyLinkedList<string>)list.Clone();
        list1.RemoveLast();//удаляем последний элемент у 2 списка, при этом 1 не меняется
        list.Show();
        Console.WriteLine();
        list1.Show();

        //ICollection
        Console.WriteLine();
        ICollection<string> list2 = new MyLinkedList<string>();
        list2.Add("smthg");
        list2.Add("anthg");
        list2.Remove("anthg");
        Console.WriteLine(list2.Count);

        foreach(string s in list2)
        {
            Console.WriteLine(s);
        }

        //ICompareble
        Console.WriteLine();
        MyLinkedList<int> temp1 = new MyLinkedList<int>();
        temp1.Add(1);
        MyLinkedList<int> temp2 = new MyLinkedList<int>();
        temp2.Add(2);
        temp2.Add(3);
        temp2.Add(3);
        temp2.Add(3);
        MyLinkedList<int> temp3 = new MyLinkedList<int>();
        temp3.Add(2);
        temp3.Add(3);
        MyLinkedList<int>[] megalist = new MyLinkedList<int>[3];
        megalist[0] = temp1;
        megalist[1] = temp2;    
        megalist[2] = temp3;
        Array.Sort(megalist);
        for(int i = megalist.Length-1; i >-1; i--)
        {
            Console.WriteLine(megalist[i].count());
        }

        //IEnumerable
        Console.WriteLine();
        MyLinkedList<int> list3 = new MyLinkedList<int>();
        list3.Add(2);
        list3.Add(3);
        list3.Add(4);
        list3.Add(5);
        foreach(int i in list3)
        {
            Console.WriteLine(i);
        }*/

        //Sort()
        
        MyLinkedList<int> list4 = new MyLinkedList<int>();
        Item<int> item = new Item<int>(4);
        list4.Add(2);
        list4.Add(4);
        list4.Add(8);
        list4.Add(5);
      
        list4.Sort();
        list4.Show();
       
        /*MyLinkedList<string> list5 = new MyLinkedList<string>("b");
        list5.Add("d");
        list5.Add("a");
        list5.Add("c");
        list5.Add("f");
        list5.Sort()*/;

        //list4.Show();
        /*Console.WriteLine();
        list5.Show();*/


    }
}

