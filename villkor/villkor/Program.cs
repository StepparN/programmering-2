using System;

namespace villkor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Skriv in din ålder");
            var age = Convert.ToInt32(Console.ReadLine());
            if (age >= 20)
            {
                Console.WriteLine("Du får köpa alkohol");
            }
            else
            {
                Console.WriteLine("Du får inte köpa alkohol");
            }
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(i);
            }
                
        }
    }
}
