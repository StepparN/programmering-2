using System;
using System.Linq;

namespace listorr
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] namn = new string[5];

            Console.WriteLine("Skriv 5 namn:");

            for (int i = 0; i < namn.Length; i++)
            {
                namn[i] = Console.ReadLine();
            }
            Array.Reverse(namn);
            Console.WriteLine("Här är namnen:");

            for (int i = 0; i < namn.Length; i++)
            {
                Console.WriteLine(namn[i]);
            }


        }
    }
}
