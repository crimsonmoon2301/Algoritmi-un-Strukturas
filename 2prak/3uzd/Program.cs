using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3uzd
{
    internal class Program
    {
        static Queue saraksts = new Queue();
        static bool stop = false;
        static void Main(string[] args)
        {
            Console.WriteLine("Sveicināti! Izvēlies savu vēlamo darbību:");
            while (!stop)
            {
                Console.WriteLine("1 - Pievienot sarakstam jaunus elementus");
                Console.WriteLine("2 - Izvadīt informāciju par sarakstu uz ekrāna");
                Console.WriteLine("3 - Izdzēst sarakstu");
                Console.WriteLine("4 - Izdzēst noteikta skaita elementu no saraksta");
                Console.WriteLine("5 - Atrast sarakstā elementu");
                Console.WriteLine("6 - Beigt programmu");

                Console.Write("\nTava izvēle: ");
                int izvele = int.Parse(Console.ReadLine());

                switch (izvele)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Cik elementus vēlies pievienot sarakstam? ");
                        Console.Write("\nVēlamo elementu skaits: ");
                        int skaits = int.Parse(Console.ReadLine());
                        for (int i = 0; i < skaits; i++)
                        {
                            Console.Write("Ievadi elementu: ");
                            string elements = Console.ReadLine();
                            saraksts.Enqueue(elements);
                        }
                        Console.WriteLine("Elementi pievienoti. Spied jebkuru pogu, lai turpinātu.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        if (saraksts.Count == 0)
                        {
                            Console.WriteLine("Saraksts ir tukšs!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Saraksta elementi:");
                            foreach (var elementi in saraksts)
                            {
                                Console.WriteLine(elementi);
                            }
                            Console.WriteLine($"Elementu skaits: {saraksts.Count}");
                            Console.WriteLine("Spied jebkuru pogu, lai turpinātu.");
                        }
                        break;
                    case 3:
                        if (saraksts.Count == 0)
                        {
                            Console.WriteLine("Saraksts ir jau tukšs!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            saraksts.Clear();
                            Console.WriteLine("Saraksts izdzēsts. Spied jebkuru pogu, lai turpinātu.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 4:
                        Console.Clear();
                        if (saraksts.Count == 0)
                        {
                            Console.WriteLine("Saraksts ir tukšs!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Cik elementus vēlies izdzēst no saraksta? ");
                            Console.Write("\nDzēšamo elementu skaits: ");
                            int dzestosk = int.Parse(Console.ReadLine());
                            if (dzestosk > saraksts.Count)
                            {
                                Console.WriteLine("Dzesamais elementu skaits pārsniedz saraksta izmēru!");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                for (int i = 0; i < dzestosk; i++)
                                {
                                    saraksts.Dequeue(); // Noņem elementu no saraksta un atgriež to sākumā? Jāiztestē kārtīgāk.
                                }
                                Console.WriteLine("Elementi izdzēsti. Spied jebkuru pogu, lai turpinātu.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        break;
                    case 5:
                        if (saraksts.Count == 0)
                        {
                            Console.WriteLine("Saraksts ir tukšs!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Ievadi meklējamo elementu: ");
                            string meklet = Console.ReadLine();
                            if (saraksts.Contains(meklet))
                            {

                                Console.WriteLine("Elements atrasts sarakstā!");
                                ArrayList temp = new ArrayList();
                                temp.AddRange(saraksts);
                                int numurs = temp.IndexOf(meklet) + 1; // Izveido pagaidu sarakstu, ar kuru var atrast elementa numuru. Izrādās ka queue to nepiedāvā. Tā vismaz stackoverflow saka...


                                Console.WriteLine($"Elements ir ar numuru {numurs}");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Elements nav sarakstā!");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        }
                    case 6:
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("Tādu opciju nav!");
                        break;
                }


            }
        }
    }
}
