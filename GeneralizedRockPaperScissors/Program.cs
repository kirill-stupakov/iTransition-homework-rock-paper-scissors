using System;
using System.Collections.Generic;

namespace GeneralizedRockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>();
            list.Add("A");
            list.Add("B");
            list.Add("C");
            list.Add("D");
            list.Add("E");
            list.Add("F");
            list.Add("G");

            var a = new Table(list);
            a.Print();
        }
    }
}
