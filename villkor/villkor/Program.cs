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
            int sprit = 3;
            switch (sprit)
            {
                case 1:
                    Console.WriteLine("Gin");
                    break;

                case 2:
                    Console.WriteLine("Vodka");
                    break;

                case 3:
                    Console.WriteLine("Tequila");
                    break;

                case 4:
                    Console.WriteLine("Whisky");
                    break;
            }

            int age1 = 18;

            while (age1 < 20){
                Console.WriteLine("Du får snart köpa alkohol");
                age1++;
            }
                
        }
    }
}
