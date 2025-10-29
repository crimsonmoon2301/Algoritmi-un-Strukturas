using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8prak
{
    class Koks
    {
        public List<Zars> zari;
        public void Drukat()
        {

        }
        public void Meklet()
        {

        }
    }
    class Zars
    {
        public List<Zars> zari;
        public Rajons rajons;
    }
    class Rajons
    {
        public string Nosaukums;
        public string Platiba;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Koks koks = new Koks();
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("0 - Beigt darbu");
                Console.WriteLine("1 - Pievienot pamatrajonu");
                Console.WriteLine("2 - Pievienot apakšrajonu");
                Console.WriteLine("3 - Labot rajona datus");
                Console.WriteLine("4 - Izvadīt rajonu un apakšrajonu datus");
                string opcija = Console.ReadLine();
                if (!int.TryParse(opcija, out int derigs))
                {
                    Console.WriteLine("Tev ir jāievada skaitlis");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    switch (derigs)
                    {
                        case 0:
                            stop = true;
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        default:
                            Console.WriteLine("Tādas opcijas nav");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
            }
        }
    }
}