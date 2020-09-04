using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Skriv in namn:");
            string namn = Console.ReadLine();
            Console.WriteLine("Namn:" + namn);

            Console.WriteLine("Skriv in din ålder:");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ålder:" + age);

            Console.WriteLine("Är du vid liv, Ja / Nej ?");
            Console.ReadLine();
            bool Ja = true;
            bool Nej = false;
            Console.WriteLine("Är du vid liv?" + Ja);
            Console.WriteLine("Är du vid liv?" + Nej);

        }
    }
}