using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string> { "jkj", "124", "12.3" };
            var intt = decimal.Parse(list[2]);
            Console.WriteLine(intt);
        }
    }
}
