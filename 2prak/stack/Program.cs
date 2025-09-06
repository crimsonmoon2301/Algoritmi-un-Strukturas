using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stack
{
    internal class Program
    {
        static bool stop = false;
        static Stack saraksts = new Stack();
        static void Main(string[] args)
        {
            Console.WriteLine("Sveicināti! Izvēlieties savu darbību");
            while (!stop)
            {
                Console.WriteLine("1 - Aizpildīt stack ar elementiem");
                Console.WriteLine("2 - Izvadīt stack elementus uz ekrāna");
                Console.WriteLine("3 - Izdzēst stack");
                Console.WriteLine("4 - Izveidot masīvu un to izvadīt uz ekrāna");
                Console.WriteLine("5 - Beigt programmu");

                Console.Write("\nTava izvēle: ");
                int izvele = int.Parse(Console.ReadLine());
                switch (izvele)
                {
                    case 1:
                        
                        Console.Clear();
                        Console.WriteLine("Cik elementus vēlies pievienot sarakstā?");
                        Console.Write("\nVēlamo elementu skaits: ");

                        int skaits = int.Parse(Console.ReadLine());

                        for (int i = 0; i < skaits; i++)
                        {
                            Console.Write("Ievadi elementu: ");
                            string elements = Console.ReadLine();
                            saraksts.Push(elements);
                        }
                        Console.WriteLine("Elementi pievienoti. Spied jebkuru pogu, lai turpinātu.");
                        break;
                    case 2:
                        Console.Clear();
                        if (saraksts.Count == 0)
                        {
                            Console.WriteLine("Saraksts ir tukšs! Izveido to, nospiežot 1 pie galvenās izvēlnes.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Saraksta elementi:");
                            foreach (var elementi in saraksts)
                            {
                                Console.WriteLine(elementi);
                            }
                            Console.WriteLine("Spied jebkuru pogu, lai turpinātu.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 3:
                        Console.Clear();
                        if (saraksts.Count == 0)
                        {
                            Console.WriteLine("Saraksts ir tukšs! Izveido to, nospiežot 1 pie galvenās izvēlnes.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            saraksts.Clear();
                        }
                        Console.WriteLine("Saraksts izdzēsts. Nospied jebkuru pogu, lai turpinātu");
                        Console.ReadKey();
                        Console.Clear();
                
                        break;
                    case 4:
                        Console.Clear();
                        if (saraksts.Count == 0)
                        {
                            Console.WriteLine("Saraksts ir tukšs. Masīvu izveidot nav iespējams.");
                        }
                        else
                        {
                            // Izveido objekta masīvu, kur tiks izmantota toarray funkcija, lai pārvietotu stack elementus objektu masīvā. 
                            // Kāpēc tieši object masīvs? Viņš satur visu. Sarakstu elementi skaitās kā objekti
                            object[] masivs = saraksts.ToArray(); // this is cursed but it works. i am scared
                            Console.WriteLine("Masīvs izveidots. Nospiediet jebkuru pogu, lai to apskatītu.");
                            Console.ReadKey();
                            Console.Clear();
                            Console.WriteLine("Masīva elementi: ");
                            foreach (var elementi in masivs)
                            {
                                Console.WriteLine(elementi);
                            }
                        }
                        break;
                    case 5:
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("Tādas darbības nav!");
                        break;
                }
            }
        }
    }
}
