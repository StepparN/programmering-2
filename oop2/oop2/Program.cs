using System;

namespace oop2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till affären, vänligen välj produkt.");
            Console.WriteLine("Snus");
            Console.WriteLine("Nocco");
            Console.WriteLine("Choklad");
            Console.WriteLine("Cola");
            var val = Console.ReadLine();

            switch (val)
            {
                case "Snus":
                    Console.WriteLine("Du valde Snus");
                    break;

                case "Nocco":
                    Console.WriteLine("Du valde Nocco");
                    break;

                case "Choklad":
                    Console.WriteLine("Du valde Choklad");
                    break;

                case "Cola":
                    Console.WriteLine("Du valde Cola");
                    break;

            }

        }
        }
    }

